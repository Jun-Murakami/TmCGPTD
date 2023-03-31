using System;
using System.Linq;
using System.Windows.Forms;

namespace TmCGPTD
{
    public partial class Form_NewChat
    {
        public string EnteredText
        {
            get
            {
                return TextBox1.Text;
            }
        }

        public Form_NewChat()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Form_NewChat_Shown(object sender, EventArgs e)
        {
            KeyPreview = true; // KeyPreview プロパティを True に設定
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Control[] controlStr = Controls.Find($"ButtonOK", true);
                Button buttonStr = controlStr.FirstOrDefault() as Button; // ボタンを取得
                buttonStr.PerformClick();
            }
        }
    }
}