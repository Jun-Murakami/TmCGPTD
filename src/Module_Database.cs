using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;
using static TmCGPTD.Form_Input;

namespace TmCGPTD
{

    public partial class Form1
    {
        // SQログLテーブル初期化--------------------------------------------------------------
        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                string sql = "CREATE TABLE log (id INTEGER PRIMARY KEY AUTOINCREMENT, date DATE, text TEXT NOT NULL DEFAULT '');";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // テーブル作成
                    connection.Open();
                    command.ExecuteNonQuery();

                    // インデックス作成
                    sql = "CREATE INDEX idx_text ON log (text);";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        // SQLチャットログテーブルチェック--------------------------------------------------------------
        public bool TableExists(string tableName)
        {
            bool exists = false;
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT count(*) FROM sqlite_master WHERE type='table' AND name=@tableName;", connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
                connection.Close();
            }
            return exists;
        }

        // SQLチャットログテーブル初期化--------------------------------------------------------------
        private void CreateDatabaseChat()
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                string sql = "CREATE TABLE chatlog (id INTEGER PRIMARY KEY AUTOINCREMENT, date DATE, title TEXT NOT NULL DEFAULT '', tag TEXT NOT NULL DEFAULT '', json TEXT NOT NULL DEFAULT '', text TEXT NOT NULL DEFAULT '');";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // テーブルを作成
                    connection.Open();
                    command.ExecuteNonQuery();

                    // インデックス作成
                    sql = "CREATE INDEX idx_chat_text ON chatlog (text);";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        // SQL dbファイルをメモリにロード--------------------------------------------------------------
        public void DbLoadToMemory()
        {
            var fileConnection = new SQLiteConnection($"Data Source={dbPath}");
            fileConnection.Open();
            // メモリ上のDBファイルを作成
            memoryConnection = new SQLiteConnection("Data Source=:memory:");
            memoryConnection.Open();
            try
            {
                // SQL dbをメモリにコピー
                fileConnection.BackupDatabase(memoryConnection, "main", "main", -1, null, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox($"Error : {ex.Message}");
            }
            fileConnection.Close();
        }

        // ローカルにデータベースファイルをバックアップ（未使用）--------------------------------------------------------------
        public void BackupSqlDb()
        {

            File.Copy(dbPath, dbBuPath, true);
            // Task.Delay(500)
            // ローカルファイルにバックアップ
            using (var backupConnection = new SQLiteConnection($"Data Source={dbBuPath}"))
            {
                backupConnection.Open();
                memoryConnection.BackupDatabase(backupConnection, "main", "main", -1, null, 0);
            }

            try
            {
                // バックアップファイルを前のDBに上書き
                File.Move(dbBuPath, dbPath, true);
                File.Delete(dbBuPath);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox($"Error : {ex.Message}");
            }
            // いったん閉じてまた開く
            memoryConnection.Close();
            DbLoadToMemory();
        }

        // データベースにインサートする--------------------------------------------------------------
        public async Task InsertDatabaseAsync()
        {
            if (!string.IsNullOrEmpty(recentText))
            {

                inputText.Clear();
                await Task.Run(() => inputForm.TextInput1.Invoke(() => inputText.Add(string.Join(Environment.NewLine, inputForm.TextInput1.Text))));
                await Task.Run(() => inputForm.TextInput2.Invoke(() => inputText.Add(string.Join(Environment.NewLine, inputForm.TextInput2.Text))));
                await Task.Run(() => inputForm.TextInput3.Invoke(() => inputText.Add(string.Join(Environment.NewLine, inputForm.TextInput3.Text))));
                await Task.Run(() => inputForm.TextInput4.Invoke(() => inputText.Add(string.Join(Environment.NewLine, inputForm.TextInput4.Text))));
                await Task.Run(() => inputForm.TextInput5.Invoke(() => inputText.Add(string.Join(Environment.NewLine, inputForm.TextInput5.Text))));
                string finalText = string.Join(Environment.NewLine + "<---TMCGPT--->" + Environment.NewLine, inputText);

                // 現在時刻を取得する
                var now = DateTime.Now;

                // データベースに接続する
                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    // トランザクションを開始する
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // logテーブルにデータをインサートする
                            using (var command = new SQLiteCommand("INSERT INTO log(date, text) VALUES (@date, @text)", connection))
                            {
                                command.Parameters.AddWithValue("@date", now);
                                command.Parameters.AddWithValue("@text", finalText);
                                await command.ExecuteNonQueryAsync();
                            }

                            // トランザクションをコミットする
                            await Task.Run(() => transaction.Commit());
                        }
                        catch (Exception ex)
                        {
                            // エラーが発生した場合、トランザクションをロールバックする
                            transaction.Rollback();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            // インメモリをいったん閉じてまた開く
            memoryConnection.Close();
            DbLoadToMemory();
        }

        // チャットログを更新--------------------------------------------------------------
        public static long lastRowId = default; // チャットログ書き込み先IDを保持
        public async Task InsertDatabaseChatAsync(DateTime postDate, DateTime resDate, string resText)
        {
            if (!string.IsNullOrEmpty(recentText))
            {
                var insertText = new List<string>();
                insertText.Add($"[{postDate.ToString()}] by You" + Environment.NewLine);
                insertText.Add(recentText + Environment.NewLine);
                insertText.Add($"[{resDate.ToString()}] by ChatGPT");
                insertText.Add(resText);

                string titleText = string.Empty; // chatForm.TextBoxTitleのテキストを取得しておく
                if (chatForm.TextBoxTitle.InvokeRequired)
                {
                    await Task.Run(() => chatForm.TextBoxTitle.BeginInvoke(() => titleText = chatForm.TextBoxTitle.Text));
                }
                else
                {
                    titleText = chatForm.TextBoxTitle.Text;
                }

                var insertTag = new List<string>();
                await Task.Run(() => chatForm.TextBoxTag1.Invoke(() => insertTag.Add(chatForm.TextBoxTag1.Text)));
                await Task.Run(() => chatForm.TextBoxTag2.Invoke(() => insertTag.Add(chatForm.TextBoxTag2.Text)));
                await Task.Run(() => chatForm.TextBoxTag3.Invoke(() => insertTag.Add(chatForm.TextBoxTag3.Text)));
                // insertTag.RemoveAll(Function(s) String.IsNullOrEmpty(s))
                string insertTagStr = string.Join(Environment.NewLine, insertTag);

                string jsonConversationHistory = JsonSerializer.Serialize(conversationHistory);

                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    // トランザクションを開始する
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (lastRowId != default)
                            {
                                // 指定されたIDのデータを取得する
                                string currentText = "";
                                using (var command = new SQLiteCommand("SELECT text FROM chatlog WHERE id=@id", connection))
                                {
                                    command.Parameters.AddWithValue("@id", lastRowId);
                                    using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                                    {
                                        if (reader.Read())
                                        {
                                            currentText = reader.GetString(0);
                                        }
                                    }
                                }

                                // 既存のテキストに新しいメッセージを追加する
                                string newText = currentText + Environment.NewLine + string.Join(Environment.NewLine, insertText);

                                // 指定されたIDに対してデータを更新する
                                using (var command = new SQLiteCommand("UPDATE chatlog SET date=@date, title=@title, tag=@tag, json=@json, text=@text WHERE id=@id", connection))
                                {
                                    await Task.Run(() => command.Parameters.AddWithValue("@date", resDate));
                                    await Task.Run(() => command.Parameters.AddWithValue("@title", titleText));
                                    await Task.Run(() => command.Parameters.AddWithValue("@tag", insertTagStr));
                                    await Task.Run(() => command.Parameters.AddWithValue("@json", jsonConversationHistory));
                                    await Task.Run(() => command.Parameters.AddWithValue("@text", newText));
                                    await Task.Run(() => command.Parameters.AddWithValue("@id", lastRowId));
                                    await command.ExecuteNonQueryAsync();
                                }
                            }
                            else
                            {
                                // logテーブルにデータをインサートする
                                using (var command = new SQLiteCommand("INSERT INTO chatlog(date, title, tag, json, text) VALUES (@date, @title, @tag, @json, @text)", connection))
                                {
                                    await Task.Run(() => command.Parameters.AddWithValue("@date", resDate));
                                    await Task.Run(() => command.Parameters.AddWithValue("@title", titleText));
                                    await Task.Run(() => command.Parameters.AddWithValue("@tag", insertTagStr));
                                    await Task.Run(() => command.Parameters.AddWithValue("@json", jsonConversationHistory));
                                    await Task.Run(() => command.Parameters.AddWithValue("@text", string.Join(Environment.NewLine, insertText)));
                                    await command.ExecuteNonQueryAsync();
                                }

                                // 更新中チャットのIDを取得
                                string sqlLastRowId = "SELECT last_insert_rowid();";
                                using (var command = new SQLiteCommand(sqlLastRowId, connection))
                                {
                                    lastRowId = Conversions.ToLong(command.ExecuteScalar());
                                }
                            }
                            // トランザクションをコミットする
                            await Task.Run(() => transaction.Commit());
                        }
                        catch (Exception ex)
                        {
                            // エラーが発生した場合、トランザクションをロールバックする
                            transaction.Rollback();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            // インメモリをいったん閉じてまた開く
            memoryConnection.Close();
            DbLoadToMemory();
        }

        // データベースからEditorログを検索--------------------------------------------------------------
        public async Task SearchDatabaseAsync(string query)
        {
            using (var cmd = new SQLiteCommand(query, memoryConnection))
            {
                using (SQLiteDataReader reader = (SQLiteDataReader)await cmd.ExecuteReaderAsync())
                {
                    // 検索結果を整形してリストに追加
                    var dropList = new List<string>();
                    var allRecords = new List<string>();
                    while (await reader.ReadAsync())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string dateStr = reader.GetDateTime(1).ToString("yyyy/MM/dd HH:mm:ss");
                        string text = reader.GetString(2).Replace(Constants.vbCrLf, " ").Replace(Constants.vbCr, " ").Replace(Constants.vbLf, " ");

                        text = text.Replace("<---TMCGPT--->", "-");
                        text = text.Length > 80 ? text.Substring(0, 80) + "…" : text;

                        allRecords.Add($"{text} {dateStr} #{id}");
                        dropList.Add($"{text} {dateStr} #{id}");
                    }

                    // 検索結果が空なら、"No matching rows found."をリストに追加
                    if (dropList.Count == 0)
                        dropList.Add("No matching results.");

                    // ドロップダウンリストに設定
                    await Task.Run(() => inputForm.ComboBoxSearch.BeginInvoke(() => inputForm.ComboBoxSearch.Items.AddRange(dropList.ToArray())));
                }
            }
        }

        // タイトルとタグの更新--------------------------------------------------------------
        public async Task UpdateDatabaseAsync(string query)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    await connection.OpenAsync();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // インメモリをいったん閉じてまた開く
            memoryConnection.Close();
            DbLoadToMemory();
        }

        // データベースから表示用タグリストを取得--------------------------------------------------------------
        public async Task<HashSet<string>> GetTagDatabaseAsync()
        {
            // タグを格納するHashSet
            var uniqueTags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            uniqueTags.Add("(All)");
            string query = "SELECT tag FROM chatlog";
            using (var command = new SQLiteCommand(query, memoryConnection))
            {
                using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        // タグを改行で分割
                        string[] tags = reader["tag"].ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        // 重複しないタグをHashSetに追加
                        foreach (string tag in tags)
                            uniqueTags.Add(tag.Trim());
                    }
                }
            }
            return uniqueTags;
        }

        // データベースから表示用チャットログを取得--------------------------------------------------------------
        public async Task<List<string>> PickChatDatabaseAsync(string query)
        {
            var result = new List<string>();
            using (var cmd = new SQLiteCommand(query, memoryConnection))
            {
                using (SQLiteDataReader reader = (SQLiteDataReader)await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.Add(reader.GetString(0));
                        result.Add(reader.GetString(1));
                        result.Add(reader.GetString(2));
                        result.Add(reader.GetString(3));
                    }
                }
            }
            return result;
        }
        // データベースからチャットログを検索--------------------------------------------------------------
        public async Task<DataTable> SearchChatDatabaseAsync(string query, string searchKey = "")
        {
            var dT = new DataTable();
            using (var cmd = new SQLiteCommand(query, memoryConnection))
            {
                if (!string.IsNullOrEmpty(searchKey))
                {
                    searchKey = "%" + searchKey.ToLower() + "%";
                    cmd.Parameters.AddWithValue("@searchKey", searchKey);
                }
                using (SQLiteDataReader reader = (SQLiteDataReader)await cmd.ExecuteReaderAsync())
                {
                    // DataTableのデータ型を明示設定（処理速度を考慮）
                    dT.Columns.Add("chatId", typeof(int));
                    dT.Columns.Add("chatDate", typeof(DateTime));
                    dT.Columns.Add("chatTitle", typeof(string));
                    dT.Columns.Add("chatTag", typeof(string));
                    bool isFirstLine = true;
                    while (await reader.ReadAsync())
                    {
                        var row = dT.NewRow();
                        if (isFirstLine)
                        {
                            lastRowId = reader.GetInt32(0);
                            row["chatId"] = lastRowId;
                            isFirstLine = false;
                        }
                        else
                        {
                            row["chatId"] = reader.GetInt32(0);
                        }
                        row["chatDate"] = reader.GetDateTime(1);
                        row["chatTitle"] = reader.GetString(2);
                        row["chatTag"] = reader.GetString(3).Replace(Environment.NewLine, ", ");
                        dT.Rows.Add(row);
                    }
                }
            }
            return dT;
        }

        // データベースからEditor日付ログを検索--------------------------------------------------------------
        public void SearchDatabaseByDate(string query, DateTime searchDate)
        {
            using (var cmd = new SQLiteCommand(query, memoryConnection))
            {
                cmd.Parameters.AddWithValue("@searchDate", searchDate);
                using (var reader = cmd.ExecuteReader())
                {
                    // 検索結果を整形してリストに追加
                    var dropList = new List<string>();
                    if (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string dateStr = reader.GetDateTime(1).ToString("yyyy/MM/dd HH:mm:ss");
                        string text = reader.GetString(2).Replace(Constants.vbCrLf, " ").Replace(Constants.vbCr, " ").Replace(Constants.vbLf, " ");

                        text = text.Replace("<---TMCGPT--->", "-");
                        text = text.Length > 28 ? text.Substring(0, 28) + "…" : text;
                        dropList.Add($"{text} {dateStr} #{id}");
                        inputForm.ComboBoxSearch.Text = $"{text} {dateStr} #{id}";

                        // textカラムの値を取得して、区切り文字「---」で分割する
                        string[] texts;
                        string textStr = reader.GetString(2);
                        texts = textStr.Split(new[] { "<---TMCGPT--->" }, StringSplitOptions.None);
                        for (int i = 0, loopTo = Math.Min(texts.Length - 1, 4); i <= loopTo; i++) // 5要素目までを取得
                        {
                            Scintilla inputBox = (Scintilla)inputForm.Controls.Find($"TextInput{i + 1}", true)[0];
                            inputBox.Text = "";
                            if (!string.IsNullOrWhiteSpace(texts[i]))
                            {
                                inputBox.Text = texts[i].Trim(); // 空白を削除して反映
                            }
                        }
                    }
                    else
                    {
                        Interaction.MsgBox("There is no more data.");
                        return;
                    }
                    inputForm.ComboBoxSearch.DroppedDown = false; // ドロップダウンリストを表示しない
                    inputForm.ComboBoxSearch.Items.AddRange(dropList.ToArray()); // ドロップダウンリストに設定

                }
            }
        }

        // CSVエキスポート--------------------------------------------------------------
        public async Task ExportTableToCsvAsync(string tableName)
        {
            try
            {
                // ファイル保存ダイアログを表示
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Application.ExecutablePath;
                saveFileDialog.Filter = $"CSV Files (*.csv)|{tableName}.csv";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string fileName = saveFileDialog.FileName;

                int processedCount = 0;

                // SELECT クエリを実行し、テーブルのデータを取得
                var command = new SQLiteCommand($"SELECT * FROM {tableName};", memoryConnection);
                using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                {

                    // CSV ファイルに書き込むための StreamWriter を作成
                    using (var writer = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
                    {

                        // CsvWriter を作成し、設定を適用
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HasHeaderRecord = true,
                            Delimiter = ","
                        };
                        using (var csvWriter = new CsvWriter(writer, config))
                        {

                            var commandRowCount = new SQLiteCommand($"SELECT COUNT(*) FROM {tableName};", memoryConnection);
                            int rowCount = Conversions.ToInteger(commandRowCount.ExecuteScalar());

                            // ヘッダー行を書き込む
                            for (int i = 0, loopTo = reader.FieldCount - 1; i <= loopTo; i++)
                                csvWriter.WriteField(reader.GetName(i));
                            csvWriter.NextRecord();

                            // データ行を書き込む

                            while (await reader.ReadAsync())
                            {
                                for (int i = 0, loopTo1 = reader.FieldCount - 1; i <= loopTo1; i++)
                                {
                                    if (reader.GetFieldType(i) == typeof(DateTime))
                                    {
                                        var dateValue = reader.GetDateTime(i);
                                        csvWriter.WriteField(dateValue.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
                                    }
                                    else
                                    {
                                        csvWriter.WriteField(reader.GetValue(i));
                                    }
                                }
                                csvWriter.NextRecord();
                                // Report progress
                                processedCount += 1;
                                int progressPercentage = (int)Math.Round(processedCount / (double)rowCount * 100d);
                            }
                        }
                    }
                }
                Interaction.MsgBox($"Successfully exported log. ({processedCount} Records)", MsgBoxStyle.Information, "Information");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Failed to export log." + Constants.vbCrLf + "Error: " + ex.Message, MsgBoxStyle.Exclamation, "Error");
            }
        }


        // CSVインポート--------------------------------------------------------------
        public async Task ImportCsvToTableAsync(string tableName)
        {
            // ファイルオープンダイアログを表示
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.ExecutablePath;
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            int processedCount = 0;
            string fileName = openFileDialog.FileName;
            int columnEnd;
            string columnNames;
            if (tableName == "log")
            {
                columnEnd = 2;
                columnNames = "date, text";
            }
            else
            {
                columnEnd = 5;
                columnNames = "date, title, tag, json, text";
            }

            // CSVファイルからデータを読み込む
            using (var reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ","
                };
                using (var csvReader = new CsvReader(reader, config))
                {
                    csvReader.Read(); // ヘッダー行をスキップ

                    using (var con = new SQLiteConnection($"Data Source={dbPath}"))
                    {
                        await con.OpenAsync();
                        using (var transaction = con.BeginTransaction())
                        {
                            try
                            {
                                while (await csvReader.ReadAsync()) // データ行を読み込む
                                {

                                    // データを取得
                                    var rowData = new List<string>();
                                    for (int i = 1, loopTo = columnEnd; i <= loopTo; i++) // 2列目から6列目まで
                                        rowData.Add(csvReader.GetField(i));
                                    // INSERT文を作成
                                    string values = string.Join(", ", Enumerable.Range(0, rowData.Count).Select(i => $"@value{i}"));

                                    string insertQuery = $"INSERT INTO {tableName} ({columnNames}) VALUES ({values});";

                                    // データをデータベースに挿入
                                    using (var command = new SQLiteCommand(insertQuery, con))
                                    {
                                        for (int i = 0, loopTo1 = rowData.Count - 1; i <= loopTo1; i++)
                                            command.Parameters.AddWithValue($"@value{i}", rowData[i]);
                                        await command.ExecuteNonQueryAsync();
                                    }
                                    processedCount += 1;
                                }

                                transaction.Commit();
                                Interaction.MsgBox($"Successfully imported log. ({processedCount} Records)", MsgBoxStyle.Information, "Information");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw;
                                Interaction.MsgBox("Failed to import log." + Constants.vbCrLf + "Error: " + ex.Message, MsgBoxStyle.Exclamation, "Error");
                            }
                        }
                        await con.CloseAsync();
                    }
                }
            }

            // インメモリをいったん閉じてまた開く
            memoryConnection.Close();
            DbLoadToMemory();
        }

    }


}