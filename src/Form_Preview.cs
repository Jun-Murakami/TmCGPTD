using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{
    public partial class Form_Preview : DockContent
    {
        public Form1 MainFormInst { get; set; }

        public Form_Preview()
        {
            InitializeComponent();
        }
        private void Form_Preview_Shown(object sender, EventArgs e)
        {
            TextOut.Font = Properties.Settings.Default.OutputFont;
        }
        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
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

        // フォントサイズホイール処理--------------------------------------------------------------
        private void TextOut_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control) // Ctrlキーが押されている場合
            {
                int delta = e.Delta; // マウスホイールの回転量を取得
                int fontSizeChange = delta > 0 ? 1 : -1; // フォントサイズを増減させる量を決定（上回転なら＋1、下回転なら－1）
                if (!(TextOut.Font.Size <= 1f))
                {
                    // フォントサイズを変更する
                    TextOut.Font = new Font(TextOut.Font.FontFamily, TextOut.Font.Size + fontSizeChange);
                }
            }
        }

    }
}