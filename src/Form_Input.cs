using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;
using static TmCGPTD.Form1;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{
    public partial class Form_Input : DockContent
    {

        // MainFormインスタンスを保持するプロパティを追加します
        public Form1 MainFormInst { get; set; }

        public Form_Input()
        {
            InitializeComponent();
        }
        private void Form_Input_Load(object sender, EventArgs e)
        {
            // 埋め込みリソースからボタン画像を読み込む
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("TmCGPTD.images.iconWriteO6.png");
            var originalImage = Image.FromStream(resourceStream); // 元の画像を読み込む
            float dpiScaling = MainFormInst.GetDpiScaling(); // DPIスケーリングを取得
            int newSize = (int)Math.Round(18f * dpiScaling); // 新しいサイズにリサイズする
            var resizedImage = new Bitmap(newSize, newSize);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2);
            }
            ButtonPost.Image = resizedImage; // ボタンのImageプロパティに設定
        }

        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (!mainForm.cts.Token.IsCancellationRequested)
            {
                Hide(); // フォームを閉じるのではなく、非表示にする
                e.Cancel = true; // イベントをキャンセルし、フォームが閉じないようにする
            }
            else
            {
                e.Cancel = false;
            }
        }

        // グローバル変数
        public static List<string> inputText = new List<string>();
        public static string recentText;
        public static Scintilla targetScintilla;
        public static int targetCursorPositionStart = 0;
        public static int targetCursorPositionEnd = 0;
        public static bool scintillaPick = true;

        // テキスト入力を出力に反映--------------------------------------------------------------
        private void TextInput_TextChanged(object sender, EventArgs e)
        {
            inputText.Clear();
            inputText.Add(string.Join(Environment.NewLine, TextInput1.Text));
            inputText.Add(string.Join(Environment.NewLine, TextInput2.Text));
            inputText.Add(string.Join(Environment.NewLine, TextInput3.Text));
            inputText.Add(string.Join(Environment.NewLine, TextInput4.Text));
            inputText.Add(string.Join(Environment.NewLine, TextInput5.Text));

            var outputText = inputText;
            outputText.RemoveAll(s => string.IsNullOrWhiteSpace(s)); // 空行を削除

            recentText = string.Join(Environment.NewLine + "---" + Environment.NewLine, outputText).Trim();
            if (!string.IsNullOrWhiteSpace(recentText))
            {
                if (MainFormInst.MainFormPreviewForm is not null)
                {
                    MainFormInst.MainFormPreviewForm.TextOut.Text = recentText;
                }
            }

            Scintilla ScintillaStr = (Scintilla)sender;
            if (ScintillaStr.SelectionStart != targetCursorPositionStart || ScintillaStr.SelectionEnd != targetCursorPositionEnd)
            {
                // 選択範囲が変更されたときの処理
                targetScintilla = ScintillaStr;
                targetCursorPositionStart = ScintillaStr.SelectionStart;
                targetCursorPositionEnd = ScintillaStr.SelectionEnd;
            }
        }

        // フォーカス＆カーソル位置保存--------------------------------------------------------------
        private void TextInput_GotFocus(object sender, EventArgs e)
        {
            if (scintillaPick)
            {
                // 変更されたリッチテキストボックスとカーソル位置を格納する
                Scintilla ScintillaStr = (Scintilla)sender;
                targetScintilla = ScintillaStr;
                targetCursorPositionStart = ScintillaStr.SelectionStart;
                targetCursorPositionEnd = ScintillaStr.SelectionEnd;
            }
        }

        // テキスト入力　カーソル移動--------------------------------------------------------------
        private void TextInputes_KeyDown(object sender, KeyEventArgs e)
        {
            Scintilla textInput = (Scintilla)sender;
            int number = Conversions.ToInteger(textInput.Name.Substring(textInput.Name.Length - 1));
            int lastCharIndex = 0;
            if (textInput.Lines.Count > 1)
            {
                int lastLineIndex = textInput.Lines.Count - 1;
                lastCharIndex = textInput.LineFromPosition(lastLineIndex);
            }

            if (e.KeyCode == Keys.Tab && (e.Modifiers & Keys.Shift) == 0)
            {
                e.SuppressKeyPress = true; // タブ文字の挿入を防止
                SelectNextControl(ActiveControl, true, true, true, true); // 次のフォーカスを移動
            }
            else if (e.KeyCode == Keys.Tab && (e.Modifiers & Keys.Shift) != 0)
            {
                e.SuppressKeyPress = true; // タブ文字の挿入を防止
                SelectNextControl(ActiveControl, false, true, true, true); // 前のフォーカスに移動
            }

            if (e.KeyCode == Keys.Down && textInput.SelectionStart >= lastCharIndex)
            {
                if (number < 5)
                {
                    Scintilla nextTextInput = (Scintilla)Controls.Find($"TextInput{number + 1}", true)[0];
                    nextTextInput.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up && textInput.CurrentLine == 0)
            {
                if (number > 1)
                {
                    Scintilla prevTextInput = (Scintilla)Controls.Find($"TextInput{number - 1}", true)[0];
                    prevTextInput.Focus();
                }
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // リターンキーの動作をキャンセルする
            }
            else if (e.Shift && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // リターンキーの動作をキャンセルする
            }

            if (scintillaPick)
            {
                // 変更されたリッチテキストボックスとカーソル位置を格納する
                Scintilla ScintillaStr = (Scintilla)sender;
                targetScintilla = ScintillaStr;
                targetCursorPositionStart = ScintillaStr.SelectionStart;
                targetCursorPositionEnd = ScintillaStr.SelectionEnd;
            }
        }

        // POSTボタン--------------------------------------------------------------
        private async void ButtonPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(recentText))
            {
                await MainFormInst.GoChatAsync();
                await TextInputAllClearAsync();
            }
        }

        // Saveボタン--------------------------------------------------------------
        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(recentText))
            {
                Clipboard.SetText(recentText, TextDataFormat.UnicodeText);
                await MainFormInst.InsertDatabaseAsync();
            }
        }

        // 最近の200件ボタン--------------------------------------------------------------
        private async void ButtonRecentLog_ClickAsync(object sender, EventArgs e)
        {
            // ドロップダウンリストの項目をクリア
            await Task.Run(() => ComboBoxSearch.BeginInvoke(() => ComboBoxSearch.Items.Clear()));
            ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            // 最新50件
            string query = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 200";
            await MainFormInst.SearchDatabaseAsync(query);
            // ドロップダウンリストを表示する
            await Task.Run(() => ComboBoxSearch.BeginInvoke(() =>
{
    if (!ComboBoxSearch.DroppedDown)
        ComboBoxSearch.DroppedDown = true;
    ComboBoxSearch.Focus();
}));
        }

        // サーチコンボボックス選択イベント--------------------------------------------------------------
        private void ComboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選択された項目を取得
            string selectedItem = ComboBoxSearch.SelectedItem?.ToString();

            // 空、もしくは"No matching results."の場合は何もしない
            if (string.IsNullOrEmpty(selectedItem) || selectedItem.Equals("No matching results."))
                return;

            ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            // 「#」で分割して、IDを取得する
            int id = int.Parse(selectedItem.Substring(selectedItem.LastIndexOf("#") + 1));

            // SQLクエリを構築して実行する
            string query = $"SELECT text FROM log WHERE id = {id}";
            using (var command = new SQLiteCommand(query, memoryConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // textカラムの値を取得して、区切り文字で分割する
                        string[] texts;
                        string text = reader.GetString(0);
                        texts = text.Split(new[] { "<---TMCGPT--->" }, StringSplitOptions.None);
                        for (int i = 0, loopTo = Math.Min(texts.Length - 1, 4); i <= loopTo; i++) // 5要素目までを取得
                        {
                            Scintilla inputBox = (Scintilla)Controls.Find($"TextInput{i + 1}", true)[0];
                            inputBox.Clear();
                            if (!string.IsNullOrWhiteSpace(texts[i]))
                            {
                                inputBox.Text = texts[i].Trim(); // 空白を削除して反映
                            }
                        }
                    }
                }
            }

            // ドロップダウンリストを表示する
            ComboBoxSearch.DroppedDown = true;
        }

        // サーチコンボボックスキーワード検索--------------------------------------------------------------
        private async void ComboBoxSearch_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (ComboBoxSearch.DroppedDown)
                    ComboBoxSearch.DroppedDown = false; // ドロップダウンを閉じる
                                                        // コンボボックスのテキストを取得
                string searchText = ComboBoxSearch.Text.Trim();

                // 検索文字列が空か、検索結果なら終了
                if (string.IsNullOrEmpty(searchText) || Regex.IsMatch(searchText, "^.*#[0-9]+$") || searchText == "No matching results.")
                    return;
                // ドロップダウンリストの項目をクリア
                ComboBoxSearch.Items.Clear();

                // テキストカラムを検索
                string query = $"SELECT id, date, text FROM log WHERE text LIKE '%{searchText}%' ORDER BY id DESC";
                await MainFormInst.SearchDatabaseAsync(query);
                // ドロップダウンリストを表示する
                if (!ComboBoxSearch.DroppedDown)
                    ComboBoxSearch.DroppedDown = true;
            }
        }

        // コンボボックスのインフォメーション--------------------------------------------------------------
        private void ComboBoxSearch_GotFocus(object sender, EventArgs e)
        {

            if (!(ComboBoxSearch.ForeColor == Color.FromArgb(220, 220, 220)))
                ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            if (ComboBoxSearch.Text == "Type text here and press Enter to search Editor log.")
                ComboBoxSearch.Text = "";

        }

        // デリートボタン--------------------------------------------------------------
        private async void ButtonDelete_ClickAsync(object sender, EventArgs e)
        {
            string selectedItem = ComboBoxSearch.SelectedItem?.ToString(); // 選択された項目を取得

            // 空、もしくは"No matching results."の場合は何もしない
            if (string.IsNullOrEmpty(selectedItem) || selectedItem.Equals("No matching results."))
            {
                if (Regex.IsMatch(ComboBoxSearch.Text, "^[0-9]+.+#[0-9]+$"))
                {
                    selectedItem = ComboBoxSearch.Text;
                }
                else
                {
                    return;
                }
            }
            ComboBoxSearch.ForeColor = Color.Black;

            // 「#」で分割して、IDを取得する
            int id = int.Parse(selectedItem.Substring(selectedItem.LastIndexOf("#") + 1));

            var result = MessageBox.Show($"Delete this log?{Environment.NewLine}{Environment.NewLine}{selectedItem}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                // SQLクエリを構築して実行する
                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    // トランザクションを開始
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // レコードを削除
                            using (var command = new SQLiteCommand($"DELETE FROM log WHERE id = '{id}'", connection, transaction))
                            {
                                command.ExecuteNonQuery();
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

                // 最新200件を表示
                ComboBoxSearch.SelectedItem = (object)null;
                ComboBoxSearch.Items.Clear(); // ドロップダウンリストの項目をクリア

                // インメモリをいったん閉じてまた開く
                memoryConnection.Close();
                MainFormInst.DbLoadToMemory();

                if (ComboBoxSearch.DroppedDown)
                    ComboBoxSearch.DroppedDown = false; // ドロップダウンを閉じる
                string query = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 200";

                // 表示更新
                await MainFormInst.SearchDatabaseAsync(query);
                // ドロップダウンリストを表示する
                if (!ComboBoxSearch.DroppedDown)
                    ComboBoxSearch.DroppedDown = true;
            }

        }

        // 前に戻るボタン--------------------------------------------------------------
        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            DateTime searchDate;
            string input = ComboBoxSearch.Text;
            ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            if (string.IsNullOrWhiteSpace(input) || input == "Type text here and press Enter to search Editor log.")
                input = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string pattern = @"^\d{4}[-/]\d{2}[-/]\d{2} \d{2}:\d{2}:\d{2}";
            string rx = Regex.Match(input, pattern).Value;
            if (Regex.IsMatch(input, pattern) && DateTime.TryParse(rx, out searchDate))
            {
                ComboBoxSearch.Items.Clear(); // ドロップダウンリストの項目をクリア

                string searchQuery = "SELECT id, date, text FROM log WHERE datetime(date) < @searchDate ORDER BY date DESC LIMIT 1";
                MainFormInst.SearchDatabaseByDate(searchQuery, searchDate);

                ComboBoxSearch.Focus();
            }
            else
            {
                MessageBox.Show("Invalid search date and time");
            }
        }

        // 次に進むボタン--------------------------------------------------------------
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            DateTime searchDate;
            string input = ComboBoxSearch.Text;
            ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            if (string.IsNullOrWhiteSpace(input) || input == "Type text here and press Enter to search Editor log.")
                input = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string pattern = @"^\d{4}[-/]\d{2}[-/]\d{2} \d{2}:\d{2}:\d{2}";
            string rx = Regex.Match(input, pattern).Value;
            if (Regex.IsMatch(input, pattern) && DateTime.TryParse(rx, out searchDate))
            {
                ComboBoxSearch.Items.Clear(); // ドロップダウンリストの項目をクリア

                string searchQuery = "SELECT id, date, text FROM log WHERE datetime(date) > @searchDate ORDER BY date ASC LIMIT 1";
                MainFormInst.SearchDatabaseByDate(searchQuery, searchDate);

                ComboBoxSearch.Focus();
            }
            else
            {
                MessageBox.Show("Invalid search date and time");
            }
        }

        // クリアボタン--------------------------------------------------------------
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Button buttonStr = (Button)sender;
            string inputBoxName = "TextInput" + buttonStr.Text; // テキストをクリアするリッチテキストボックスの名前を生成
            Scintilla inputBox = Controls.Find(inputBoxName, true).FirstOrDefault() as Scintilla; // リッチテキストボックスを取得
            inputBox.Text = ""; // テキストをクリア
        }

        private async void ButtonClearAll_Click(object sender, EventArgs e)
        {
            await TextInputAllClearAsync();
        }
        private async Task TextInputAllClearAsync()
        {
            await Task.Run(() => TextInput1.BeginInvoke(() => TextInput1.Text = "")); // テキストをクリア
            await Task.Run(() => TextInput2.BeginInvoke(() => TextInput2.Text = ""));
            await Task.Run(() => TextInput3.BeginInvoke(() => TextInput3.Text = ""));
            await Task.Run(() => TextInput4.BeginInvoke(() => TextInput4.Text = ""));
            await Task.Run(() => TextInput5.BeginInvoke(() => TextInput5.Text = ""));
        }
        private void ComboBoxSearch_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Form_Input_Shown(object sender, EventArgs e)
        {
            // テキストエリアを初期化
            MainFormInst.ScintillaInitialize(Properties.Settings.Default.InputFontName, Properties.Settings.Default.InputFontSize, nowLangueage, Properties.Settings.Default.ChatFontName, Properties.Settings.Default.ChatFontSize);

            // 定型句再現
            string lastSelectedMenuItem = Properties.Settings.Default.DefaultPresets;
            foreach (ToolStripItem item in MainFormInst.PhrasePresetsToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem && (((ToolStripMenuItem)item).Text ?? "") == (lastSelectedMenuItem ?? ""))
                {
                    ToolStripMenuItem selectedItem = (ToolStripMenuItem)item;
                    MainFormInst.SelectionItem_Click(selectedItem, EventArgs.Empty);
                    break;
                }
            }
            // シンタックスハイライト再現
            lastSelectedMenuItem = Properties.Settings.Default.Language;
            foreach (ToolStripItem item in MainFormInst.LanguageToolStripMenuItem.DropDownItems)
            {
                var selectedItem = MainFormInst.FindMenuItemByText(item, lastSelectedMenuItem);
                if (selectedItem is not null)
                {
                    selectedItem.Checked = false;
                    MainFormInst.SelectionItemLang_Click(selectedItem, EventArgs.Empty);
                    break;
                }
            }
            targetScintilla = TextInput1;
            TextInput1.Zoom = Properties.Settings.Default.Zoom1;
            TextInput2.Zoom = Properties.Settings.Default.Zoom2;
            TextInput3.Zoom = Properties.Settings.Default.Zoom3;
            TextInput4.Zoom = Properties.Settings.Default.Zoom4;
            TextInput5.Zoom = Properties.Settings.Default.Zoom5;
        }
    }
}