using static TmCGPTD.Form_Input;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    public partial class Form_Phrase : DockContent
    {
        public Form1 MainFormInst { get; set; }

        public Form_Phrase()
        {
            InitializeComponent();
        }
        private void PhraseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (!mainForm.cts.Token.IsCancellationRequested)
            {
                MainFormInst.phraseForm.DockState = DockState.Hidden; // フォームを閉じるのではなく、非表示にする
                e.Cancel = true; // イベントをキャンセルし、フォームが閉じないようにする
            }
            else
            {
                e.Cancel = false;
            }
        }


        // 定型句ボタンクリック--------------------------------------------------------------
        private void Button_Click(object sender, EventArgs e)
        {

            // クリックされたボタンのテキスト値を取得する
            Button button = (Button)sender;
            string textBoxName = "TextBox" + button.Text;

            // 該当するテキストボックスが存在するかチェックする
            Control[] controlStr = Controls.Find(textBoxName, true);
            if (controlStr.Length > 0 && controlStr[0] is TextBox)
            {
                TextBox textBoxStr = (TextBox)controlStr[0];
                // テキストボックスのテキストが空でなければ挿入する
                if (!string.IsNullOrEmpty(textBoxStr.Text))
                {

                    targetScintilla.Focus();
                    targetScintilla.SelectionStart = targetCursorPositionStart;
                    targetScintilla.SelectionEnd = targetCursorPositionEnd;
                    scintillaPick = false;
                    targetScintilla.ReplaceSelection(textBoxStr.Text);
                    targetCursorPositionStart = targetScintilla.SelectionStart + textBoxStr.Text.Length;
                    targetCursorPositionEnd = targetCursorPositionStart;
                    scintillaPick = true;
                    // targetScintilla.Focus()
                }
            }
        }

    }
}