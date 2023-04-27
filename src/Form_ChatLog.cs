using System.Data;
using System.Data.SQLite;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    public partial class Form_ChatLog : DockContent
    {
        public Form1 MainFormInst { get; set; }

        public Form_ChatLog()
        {
            InitializeComponent();
        }
        private void ChatLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (!mainForm.cts.Token.IsCancellationRequested)
            {
                MainFormInst.chatLogForm.DockState = DockState.Hidden; // フォームを閉じるのではなく、非表示にする
                e.Cancel = true; // イベントをキャンセルし、フォームが閉じないようにする
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void ChatLogForm_Load(object sender, EventArgs e)
        {
            // Form1.SetPictureBoxImage("TmCGPTD.iconChatBlack.png", PictureBox1)
            // Form1.SetPictureBoxImage("TmCGPTD.iconTagBlack.png", PictureBox2)

            // 埋め込みリソースからボタン画像を読み込む
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("TmCGPTD.images.iconCal.png");
            var originalImage = Image.FromStream(resourceStream); // 元の画像を読み込む
            float dpiScaling = MainFormInst.GetDpiScaling(); // DPIスケーリングを取得
            int newSize = (int)Math.Round(26f * dpiScaling); // 新しいサイズにリサイズする
            var resizedImage = new Bitmap(newSize, newSize);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2);
            }
            ButtonCal.BackgroundImage = resizedImage; // ボタンのImageプロパティに設定
        }

        // データグリッド初期化--------------------------------------------------------------
        private readonly DataTable emptyDataTable = new DataTable();
        public BindingSource bSource = new BindingSource();

        // 仮想モードハンドラ
        private void DataGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // 必要なセルの値を取得して、e.Valueに設定する
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex; // 行番号を設定
            }
            else
            {
                e.Value = "Data";
            } // ダミーデータを設定
        }
        public void InitializeDataTable()
        {

            // 仮想モードを有効にする
            DataGrid.VirtualMode = true;

            // ダブルバッファリングを有効にする
            var dgvType = DataGrid.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(DataGrid, true, (object[])null);

            emptyDataTable.Columns.Add("chatId", typeof(int));
            emptyDataTable.Columns.Add("chatDate", typeof(DateTime));
            emptyDataTable.Columns.Add("chatTitle", typeof(string));
            emptyDataTable.Columns.Add("chatTag", typeof(string));

            bSource.DataSource = emptyDataTable;
            DataGrid.DataSource = bSource;

            DataGrid.EnableHeadersVisualStyles = false;
            // DataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 70, 84)
            DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            DataGrid.Columns[0].HeaderText = "ID";
            DataGrid.Columns[1].HeaderText = "Update";
            DataGrid.Columns[2].HeaderText = "Title";
            DataGrid.Columns[3].HeaderText = "Tags";

            DataGrid.Columns[1].DefaultCellStyle.Format = "yy/MM/dd HH:mm";

            DataGrid.GridColor = Color.FromArgb(84, 85, 99);

            float dpiScaleFactor = CreateGraphics().DpiX / 96.0f;

            DataGrid.Columns[0].Width = (int)Math.Round(50f * dpiScaleFactor);
            DataGrid.Columns[1].Width = (int)Math.Round(106f * dpiScaleFactor);
            DataGrid.Columns[2].Width = (int)Math.Round(180f * dpiScaleFactor);
            DataGrid.Columns[3].Width = (int)Math.Round(250f * dpiScaleFactor);
        }

        // 検索結果表示--------------------------------------------------------------
        public async Task ShowChatSearchResultAsync(DataTable dT)
        {
            // If dT.Rows.Count > 0 Then
            await Task.Run(() => DataGrid.BeginInvoke(() =>
{
    // 自動バインド停止
    // bSource.RaiseListChangedEvents = False
    bSource.SuspendBinding();

    bSource.DataSource = dT; // データ入力

    bSource.RaiseListChangedEvents = true; // データ変更許可
                                           // 更新反映
    bSource.ResumeBinding();
    // bSource.ResetBindings(False)
    if (DataGrid.Rows.Count > 0)
        DataGrid.Rows[0].Selected = true;
}));
            // End If
            // データベースからタグリストを取得
            var uniqueTags = await MainFormInst.GetTagDatabaseAsync();
            var tagList = uniqueTags.ToList();
            await Task.Run(() => ComboBoxTag.BeginInvoke(() => ComboBoxTag.Items.Clear()));
            await Task.Run(() => ComboBoxTag.BeginInvoke(() => ComboBoxTag.Items.AddRange(tagList.ToArray())));
        }

        // チャット本文ログ表示--------------------------------------------------------------
        private async void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ヘッダー行を除く
            {
                // クリックされた行のchatIdカラムの値を取得
                int chatId = Conversions.ToInteger(DataGrid.Rows[e.RowIndex].Cells["chatId"].Value);
                string query = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}";
                var result = await MainFormInst.PickChatDatabaseAsync(query);
                await MainFormInst.ShowChatLogAsync(result);
                Form1.lastRowId = chatId;
            }
        }

        // データグリッドの自動選択解除--------------------------------------------------------------
        private void Form_ChatLog_Activated(object sender, EventArgs e)
        {
            if (DataGrid.SelectedColumns.Count == 0)
            {
                DataGrid.ClearSelection();
            }
        }

        private string keywordFilter = "";
        private string tagFilter = "";
        private string dateFilter = "";
        public DateTime startDate = DateTime.Now;
        public DateTime endDate = DateTime.Now;

        // カレンダー起動--------------------------------------------------------------
        private async void ButtonCal_ClickAsync(object sender, EventArgs e)
        {
            var dateRangeForm = new Form_DateRange(); // DateRangeFormのインスタンスを作成
            var buttonScreenLocation = ButtonCal.PointToScreen(Point.Empty); // ボタンのスクリーン座標を取得
                                                                             // ダイアログの表示位置を計算（ボタンの左下に右寄せ）
            var dialogLocation = new Point(buttonScreenLocation.X + ButtonCal.Width - dateRangeForm.Width, buttonScreenLocation.Y + ButtonCal.Height);
            // ダイアログの表示位置を設定
            dateRangeForm.Location = dialogLocation;
            dateRangeForm.DateTimePicker1.Value = startDate;
            dateRangeForm.DateTimePicker2.Value = endDate;
            // モーダルダイアログとして表示
            if (dateRangeForm.ShowDialog() == DialogResult.OK)
            {
                // OKボタンがクリックされた場合、選択された日付範囲を取得
                startDate = dateRangeForm.StartDatePicker.Value;
                endDate = dateRangeForm.EndDatePicker.Value;

                if (endDate < startDate)
                {
                    var tempDate = startDate;
                    startDate = endDate;
                    endDate = tempDate;
                }
                await ApplyDateFilterAsync(startDate, endDate);
                ButtonCal.BackColor = Color.FromArgb(146, 148, 165);
            }
            else
            {
                await RemoveDateFilterAsync(); // 日付フィルタ解除
                ButtonCal.BackColor = Color.FromArgb(53, 55, 64);
                startDate = DateTime.Now;
                endDate = DateTime.Now;
            }
        }
        // 日付フィルタを適用するメソッド
        private async Task ApplyDateFilterAsync(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1d); // endDate に1日加算
            dateFilter = $"chatDate >= #{startDate.ToShortDateString()}# AND chatDate <= #{endDate.ToShortDateString()}#";
            await UpdateFilterAsync();
        }

        // フィルタを解除するメソッド
        private async Task RemoveDateFilterAsync()
        {
            dateFilter = "";
            await UpdateFilterAsync();
        }

        // フィルタを更新するメソッド
        private async Task UpdateFilterAsync()
        {
            var filters = new List<string>();

            if (!string.IsNullOrEmpty(keywordFilter))
                filters.Add(keywordFilter);
            if (!string.IsNullOrEmpty(tagFilter))
                filters.Add(tagFilter);
            if (!string.IsNullOrEmpty(dateFilter))
                filters.Add(dateFilter);

            await Task.Run(() => DataGrid.BeginInvoke(() =>
{
    // 自動バインド停止
    // bSource.RaiseListChangedEvents = False
    bSource.SuspendBinding();

    bSource.Filter = string.Join(" AND ", filters);

    bSource.RaiseListChangedEvents = true; // データ変更許可
                                           // 更新反映
    bSource.ResumeBinding();
    // bSource.ResetBindings(False)
    if (DataGrid.Rows.Count > 0)
        DataGrid.Rows[0].Selected = true;
}));
        }

        // キーワード検索やタグ検索を更新する場合
        private async void ComboBoxTag_SelectedIndexChangedAync(object sender, EventArgs e)
        {
            // 選択された項目を取得
            string selectedItem = null;
            await Task.Run(() => ComboBoxTag.BeginInvoke(() => selectedItem = ComboBoxTag.SelectedItem?.ToString()));

            // 空の場合は何もしない
            if (string.IsNullOrEmpty(selectedItem))
                return;
            if (selectedItem == "(All)")
                selectedItem = "";
            await UpdateTagFilterAsync(selectedItem);
        }
        private async Task UpdateKeywordFilterAsync(string newKeyword)
        {
            keywordFilter = $"ColumnNameForKeyword LIKE '%{newKeyword}%'";
            await UpdateFilterAsync();
        }

        private async Task UpdateTagFilterAsync(string newTag)
        {
            tagFilter = $"chatTag LIKE '%{newTag}%'";
            await UpdateFilterAsync();
        }

        private void ComboBoxTag_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox comboBoxMod = (ComboBox)sender;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            // カスタムの背景色とテキスト色を設定します。
            var backColor = isSelected ? Color.FromArgb(106, 108, 125) : comboBoxMod.BackColor;
            var textColor = isSelected ? Color.FromArgb(220, 220, 220) : comboBoxMod.ForeColor;

            // 背景を描画します。
            using (var brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // テキストを描画します。
            using (var brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(comboBoxMod.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
            }

            // フォーカス矩形を描画します。
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        // インクリメンタルサーチ--------------------------------------------------------------
        public async void TextBoxSearch_TextChangedAsync(object sender, EventArgs e)
        {
            try
            {
                string searchKey = null;
                await Task.Run(() => TextBoxSearch.BeginInvoke(() => searchKey = TextBoxSearch.Text.Trim()));
                string query;
                DataTable dT;
                if (string.IsNullOrEmpty(searchKey))
                {
                    query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
                    dT = await MainFormInst.SearchChatDatabaseAsync(query);
                }
                else
                {
                    query = "SELECT id, date, title, tag FROM chatlog WHERE LOWER(text) LIKE LOWER(@searchKey)";
                    dT = await MainFormInst.SearchChatDatabaseAsync(query, searchKey);
                }
                await ShowChatSearchResultAsync(dT);
                int rowsCount = new int();
                await Task.Run(() => DataGrid.BeginInvoke(() => rowsCount = DataGrid.Rows.Count));
                if (rowsCount > 0)
                {
                    int chatId = new int();
                    await Task.Run(() => DataGrid.BeginInvoke(() => chatId = Conversions.ToInteger(DataGrid.Rows[0].Cells["chatId"].Value)));
                    query = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}";
                    var result = await MainFormInst.PickChatDatabaseAsync(query);
                    await MainFormInst.ShowChatLogAsync(result, searchKey);
                    Form1.lastRowId = chatId;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox( "Error: " + ex.Message, MsgBoxStyle.Exclamation, "Error");
            }
        }

        // デリートボタン--------------------------------------------------------------
        private async void ButtonChatDelete_ClickAsync(object sender, EventArgs e)
        {
            int chatId;
            string chatDate;
            string chatTitle;
            if (DataGrid.SelectedRows.Count > 0)
            {
                var selectedRow = DataGrid.SelectedRows[0];
                chatId = Convert.ToInt32(selectedRow.Cells["chatId"].Value);
                chatDate = selectedRow.Cells["chatDate"].Value.ToString();
                chatTitle = selectedRow.Cells["chatTitle"].Value.ToString();
            }
            else
            {
                return;
            }

            var result = MessageBox.Show($"Delete this chat log?{Environment.NewLine}{Environment.NewLine}{chatDate} {chatTitle}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                // SQLクエリを構築して実行する
                using (var connection = new SQLiteConnection($"Data Source={Form1.dbPath}"))
                {
                    connection.Open();
                    // トランザクションを開始
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // レコードを削除
                            using (var command = new SQLiteCommand($"DELETE FROM chatlog WHERE id = '{chatId}'", connection, transaction))
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                            // トランザクションをコミット
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // エラーが発生した場合は、トランザクションをロールバック
                            transaction.Rollback();
                            Interaction.MsgBox(ex.Message);
                        }
                    }
                }

                // インメモリをいったん閉じてまた開く
                Form1.memoryConnection.Close();
                MainFormInst.DbLoadToMemory();

                TextBoxSearch_TextChangedAsync(DataGrid, EventArgs.Empty);
            }

        }

        private Size dockedSize;
        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            if (DockState != DockState.Float)
            {
                dockedSize = Size;
            }
        }
        private void MyForm_DockStateChanged(object sender, EventArgs e)
        {
            if (DockState == DockState.Float)
            {
                // ここで DefaultFloatWindowSize を変更する
                Size = dockedSize;
            }
        }

    }
}