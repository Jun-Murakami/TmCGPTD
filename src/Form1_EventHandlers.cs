using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    public partial class Form1
    {

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }
        private async void ExpotChatLogToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            await ExportTableToCsvAsync("chatlog");
        }

        private async void ExportEditorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ExportTableToCsvAsync("log");
        }

        private async void ImportChatLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportCsvToTableAsync("chatlog");
            chatLogForm.TextBoxSearch_TextChangedAsync(chatLogForm.DataGrid, EventArgs.Empty);
        }

        private async void ImportEditorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportCsvToTableAsync("log");
            chatLogForm.TextBoxSearch_TextChangedAsync(chatLogForm.DataGrid, EventArgs.Empty);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }

        public void InputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputForm is null)
            {
                inputForm = new Form_Input();
                inputForm.MainFormInst = this;
                DockPanel1.Theme = new VS2015LightTheme();
            }
            inputForm.Show(DockPanel1, DockState.Document);
            ChangeControlColor();
        }

        public void PreviewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (previewForm is null)
            {
                previewForm = new Form_Preview();
                previewForm.MainFormInst = this;
                DockPanel1.Theme = new VS2015LightTheme();
            }
            previewForm.Show(DockPanel1, DockState.DockRight);
            ChangeControlColor();
        }
        public void ChatLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chatForm is null)
            {
                chatForm = new Form_Chat();
                chatForm.MainFormInst = this;
                DockPanel1.Theme = new VS2015LightTheme();
            }
            chatForm.Show(DockPanel1, DockState.Document);
            ChangeControlColor();
        }

        public void ChatListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chatLogForm is null)
            {
                chatLogForm = new Form_ChatLog();
                chatLogForm.MainFormInst = this;
                DockPanel1.Theme = new VS2015LightTheme();
            }
            chatLogForm.Show(DockPanel1, DockState.DockLeft);
            ChangeControlColor();
        }
        public void PhrasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phraseForm is null)
            {
                phraseForm = new Form_Phrase();
                phraseForm.MainFormInst = this;
                DockPanel1.Theme = new VS2015LightTheme();
            }
            phraseForm.Show(DockPanel1, DockState.DockBottom);
            ChangeControlColor();
        }
        private void LayoutResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDefaultDockLayout();
        }
        private void KeyboardSHortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageForm = new Form()
            {
                Size = new Size(1270, 850),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                BackColor = Color.FromArgb(53, 55, 64),
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                Text = "Keyboard Shortcut"
            };

            var imagePictureBox = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.TmcGPTD_SC,
                Size = new Size(1226, 783),
                Location = new Point((imageForm.ClientSize.Width - 1226) / 2, (imageForm.ClientSize.Height - 783) / 2)
            };

            imageForm.Controls.Add(imagePictureBox);
            imageForm.Click += (s, ea) => imageForm.Close();
            imagePictureBox.Click += (s, ea) => imageForm.Close();

            imageForm.ShowDialog();
        }

        // 定型句セーブ--------------------------------------------------------------
        private void SavePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. テキストボックスの値を取得してリストに格納
            var textList = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                string textBoxName = $"TextBox{i}";
                Control[] controlStr = phraseForm.Controls.Find(textBoxName, true);
                TextBox textBox = controlStr.FirstOrDefault() as TextBox;
                if (textBox is not null && !string.IsNullOrEmpty(textBox.Text))
                {
                    textList.Add(textBox.Text);
                }
            }

            // 2. ファイル保存ダイアログを表示
            if (!Directory.Exists(phrasePath))
            {
                Directory.CreateDirectory(phrasePath);
            }
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = phrasePath;
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // 3. ファイルを保存
            string fileName = saveFileDialog.FileName;
            string filePath = Path.Combine(phrasePath, Path.GetFileName(fileName));
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var Tex in textList)
                    writer.WriteLine(Tex);
            }

            // 4. stereotypedフォルダ内のtxtファイルを列挙してリストボックスに表示
            ClearPresetPhrases();

            foreach (var file in Directory.GetFiles(phrasePath, "*.txt"))
                AddSelectionItem(Path.GetFileName(file));
        }
        public void ClearPresetPhrases()
        {
            for (int i = PhrasePresetsToolStripMenuItem.DropDownItems.Count - 1; i >= 0; i -= 1)
            {
                var item = PhrasePresetsToolStripMenuItem.DropDownItems[i];
                if (!ReferenceEquals(item.Text, "Save Presets") && !ReferenceEquals(item.Text, "Clear Presets") && item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                    menuItem.Click -= SelectionItem_Click;
                    PhrasePresetsToolStripMenuItem.DropDownItems.Remove(menuItem);
                }
            }
        }

        // 排他的に選択できるメニューアイテムを追加するメソッド--------------------------------------------------------------
        public void AddSelectionItem(string text)
        {
            var newItem = new ToolStripMenuItem(text) { CheckOnClick = false };
            newItem.Click += SelectionItem_Click;
            PhrasePresetsToolStripMenuItem.DropDownItems.Add(newItem);
        }

        // 定型句プリセット選択(ハンドルはメニュー生成時にコードで付加)--------------------------------------------------------------
        public void SelectionItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Checked == true)
                return;

            // 他のメニューアイテムのチェックをクリアする
            foreach (ToolStripItem item in PhrasePresetsToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem && !ReferenceEquals(item, clickedItem))
                {
                    ((ToolStripMenuItem)item).Checked = false;
                }
            }
            string filePath = Path.Combine(phrasePath, clickedItem.Text);

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        string textBoxName = $"TextBox{i}";
                        Control[] controlStr = phraseForm.Controls.Find(textBoxName, true);
                        if (controlStr is not null && controlStr[0] is TextBox)
                        {
                            TextBox texBox = (TextBox)controlStr[0];
                            string line = reader.ReadLine();
                            if (line is not null)
                            {
                                texBox.Text = line.Trim();
                            }
                            else
                            {
                                texBox.Text = "";
                            }
                        }
                    }
                }
            }

            // クリックした項目にチェックを付けてSave
            clickedItem.Checked = true;
            Properties.Settings.Default.DefaultPresets = clickedItem.Text;
            Properties.Settings.Default.Save();
        }

        // 定型句クリア--------------------------------------------------------------
        private void ClearPresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // メニューアイテムのチェックをクリアする
            foreach (ToolStripItem item in PhrasePresetsToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)item).Checked = false;
                }
            }

            for (int i = 1; i <= 20; i++)
            {
                string textBoxName = $"TextBox{i}";
                Control[] controlStr = phraseForm.Controls.Find(textBoxName, true);
                if (controlStr is not null && controlStr[0] is TextBox)
                {
                    TextBox texBox = (TextBox)controlStr[0];
                    texBox.Text = "";
                }
            }
        }

        // シンタックスハイライト変更--------------------------------------------------------------
        public void SelectionItemLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Checked == true)
                return;

            // 他のメニューアイテムのチェックをクリアする
            ClearChecks(LanguageToolStripMenuItem, clickedItem);
            // フォントを取得
            string fontFamily = inputForm.TextInput1.Styles[Style.Default].Font;
            int fontSize = inputForm.TextInput1.Styles[Style.Default].Size;
            if (fontSize < 1)
                fontSize = 1;

            string fontFamily2 = chatForm.ChatBox.Styles[Style.Default].Font;
            int fontSize2 = chatForm.ChatBox.Styles[Style.Default].Size;
            if (fontSize2 < 1)
                fontSize2 = 1;

            // Scintillaの初期化
            ScintillaInitialize(fontFamily, fontSize, clickedItem.Text, fontFamily2, fontSize2);

            nowLangueage = clickedItem.Text;

            // クリックした項目にチェックを付けてSave
            clickedItem.Checked = true;
            Properties.Settings.Default.Language = clickedItem.Text;
            Properties.Settings.Default.Save();
        }

        private void ClearChecks(ToolStripMenuItem menuItem, ToolStripMenuItem clickedItem)
        {
            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem && !ReferenceEquals(item, clickedItem))
                {
                    ToolStripMenuItem childMenuItem = (ToolStripMenuItem)item;
                    childMenuItem.Checked = false;

                    // 再帰的に子階層のメニューアイテムを処理する
                    if (childMenuItem.HasDropDownItems)
                    {
                        ClearChecks(childMenuItem, clickedItem);
                    }
                }
            }
        }

        // 排他的に選択できる言語メニューアイテムを追加するメソッド--------------------------------------------------------------
        public void AddSelectionItemLang(string text)
        {
            var newItem = new ToolStripMenuItem(text) { CheckOnClick = false };
            newItem.Click += SelectionItemLang_Click;
            // 新しいToolStripMenuItemを適切な位置に追加
            // ここでは、直近に追加されたカテゴリ用のToolStripMenuItemに追加しています。
            if (text != "Default")
            {
                ToolStripMenuItem lastCategoryItem = (ToolStripMenuItem)LanguageToolStripMenuItem.DropDownItems[LanguageToolStripMenuItem.DropDownItems.Count - 1];
                lastCategoryItem.DropDownItems.Add(newItem);
            }
            else
            {
                LanguageToolStripMenuItem.DropDownItems.Add(newItem);
            }
        }
        // 再起動時の再帰的検索メソッド
        public ToolStripMenuItem FindMenuItemByText(ToolStripItem parent, string targetText)
        {
            if (parent is ToolStripMenuItem)
            {
                ToolStripMenuItem parentMenuItem = (ToolStripMenuItem)parent;
                if ((parentMenuItem.Text ?? "") == (targetText ?? ""))
                {
                    return parentMenuItem;
                }

                foreach (ToolStripItem child in parentMenuItem.DropDownItems)
                {
                    var result = FindMenuItemByText(child, targetText);
                    if (result is not null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        // フォントファミリ変更--------------------------------------------------------------
        private void InputAreaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 現在のフォント設定を取得し、FontDialogにセットする
            var fontDialogStr = new FontDialog();
            if (inputForm.TextInput2.Styles[Style.Default].Size < 1)
                inputForm.TextInput2.Styles[Style.Default].Size = 1;
            fontDialogStr.Font = new Font(inputForm.TextInput1.Styles[Style.Default].Font, inputForm.TextInput2.Styles[Style.Default].Size);
            if (fontDialogStr.ShowDialog() == DialogResult.OK)
            {
                string[] fontPartsStr = fontDialogStr.Font.Name.Split(',');
                inputFontName = fontPartsStr[0].Trim();
                if (fontPartsStr.Length == 2)
                {
                    inputFontSize = Conversions.ToInteger(fontPartsStr[1].Trim());
                }
                else
                {
                    inputFontSize = (int)Math.Round(fontDialogStr.Font.SizeInPoints);
                }

                if (chatForm.ChatBox.Styles[Style.Default].Size < 1)
                    chatForm.ChatBox.Styles[Style.Default].Size = 1;

                // 選択されたフォントを、全てのテキストボックスに適用する
                ScintillaInitialize(inputFontName, inputFontSize, nowLangueage, chatForm.ChatBox.Styles[Style.Default].Font, chatForm.ChatBox.Styles[Style.Default].Size);
                Properties.Settings.Default.InputFontName = inputFontName;
                Properties.Settings.Default.InputFontSize = inputFontSize;
                Properties.Settings.Default.Save();
            }
        }

        private void PreviewAreaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FontDialogを表示して、フォントを選択する
            var fontDialogStr = new FontDialog();
            fontDialogStr.Font = previewForm.TextOut.Font;
            if (fontDialogStr.ShowDialog() == DialogResult.OK)
            {
                previewForm.TextOut.Font = fontDialogStr.Font;
                Properties.Settings.Default.OutputFont = previewForm.TextOut.Font;
            }
        }

        private void ChatLogFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialogStr = new FontDialog();
            if (chatForm.ChatBox.Styles[Style.Default].Size < 1)
                chatForm.ChatBox.Styles[Style.Default].Size = 1;
            fontDialogStr.Font = new Font(chatForm.ChatBox.Styles[Style.Default].Font, chatForm.ChatBox.Styles[Style.Default].Size);
            if (fontDialogStr.ShowDialog() == DialogResult.OK)
            {
                string[] fontPartsStr = fontDialogStr.Font.Name.Split(',');
                chatFontName = fontPartsStr[0].Trim();
                if (fontPartsStr.Length == 2)
                {
                    chatFontSize = Conversions.ToInteger(fontPartsStr[1].Trim());
                }
                else
                {
                    chatFontSize = (int)Math.Round(fontDialogStr.Font.SizeInPoints);
                }
                // 選択されたフォントを、全てのテキストボックスに適用する
                ScintillaInitialize(inputForm.TextInput1.Styles[Style.Default].Font, inputForm.TextInput2.Styles[Style.Default].Size, nowLangueage, chatFontName, chatFontSize);
                Properties.Settings.Default.ChatFontName = chatFontName;
                Properties.Settings.Default.ChatFontSize = chatFontSize;
                Properties.Settings.Default.Save();
            }
        }

        // エディターログのオートセーブ--------------------------------------------------------------
        private void EditorLogAutoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Checked == true)
            {
                clickedItem.Checked = false;
                Properties.Settings.Default.AutoSave = false;
            }
            else
            {
                clickedItem.Checked = true;
                Properties.Settings.Default.AutoSave = true;
            }
            Properties.Settings.Default.Save();
        }

        // APIオプション設定--------------------------------------------------------------
        private void APIOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionForm = new Form_Option(); // Form_Optionをインスタンス化

            ShowCenteredDialog(this, optionForm); // Form_Optionをモーダルダイアログとして表示

            optionForm.Dispose(); // Form_Optionを破棄
        }

        // キーボードショートカット入力--------------------------------------------------------------
        protected override bool IsInputKey(Keys keyData) // Ctrl、Altキーのオーバーライド
        {
            if (keyData == Keys.Return)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                // Alt + テンキー1～9 の場合
                int buttonIndex = (int)e.KeyCode - (int)Keys.NumPad1; // ボタンのインデックス
                if (e.KeyCode == Keys.NumPad0)
                {
                    buttonIndex = 9; // テンキー0の場合
                }
                Control[] controlStr = phraseForm.Controls.Find($"Button{buttonIndex + 11}", true);
                Button buttonStr = controlStr.FirstOrDefault() as Button; // ボタンを取得
                buttonStr.PerformClick(); // ボタンをクリックする
            }
            else if (e.Control && e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                // Ctrl + テンキー1～9, 0 の場合
                int buttonIndex = (int)e.KeyCode - (int)Keys.NumPad1; // ボタンのインデックス
                if (buttonIndex < 0)
                {
                    buttonIndex = 9; // テンキー0の場合
                }
                Control[] controlStr = phraseForm.Controls.Find($"Button{buttonIndex + 1}", true);
                Button buttonStr = controlStr.FirstOrDefault() as Button; // ボタンを取得
                buttonStr.PerformClick(); // ボタンをクリックする
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Enter)
            {
                inputForm.ButtonPost.BackColor = SystemColors.GradientInactiveCaption;
                inputForm.ButtonPost.PerformClick();
                e.SuppressKeyPress = true; // リターンキーの動作をキャンセルする
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                inputForm.ButtonSave.BackColor = SystemColors.GradientInactiveCaption;
                inputForm.ButtonSave.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                chatForm.TextBoxChatTextSearch.Focus();
                e.SuppressKeyPress = true;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // Ctrlが押された場合
            {
                inputForm.ButtonPost.BackColor = Color.FromArgb(53, 55, 64);
                inputForm.ButtonSave.BackColor = Color.FromArgb(53, 55, 64);
            }
            if (e.KeyCode == Keys.S) // sが押された場合
            {
                inputForm.ButtonPost.BackColor = Color.FromArgb(53, 55, 64);
                inputForm.ButtonSave.BackColor = Color.FromArgb(53, 55, 64);
            }
        }

    }
}