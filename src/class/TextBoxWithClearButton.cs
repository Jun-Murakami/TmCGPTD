using System;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{

    public class TextBoxWithClearButton : TextBox
    {

        private Button _clearButton;

        public TextBoxWithClearButton() : base()
        {
            _clearButton = new Button();
            _clearButton.Click += _clearButton_Click;

            // Clear button settings
            _clearButton.Size = new Size(20, ClientSize.Height - 4);
            _clearButton.Location = new Point(ClientSize.Width - _clearButton.Width - 1, +2);
            _clearButton.Cursor = Cursors.Default;
            _clearButton.Text = "x";
            _clearButton.FlatStyle = FlatStyle.Flat; // この行を追加
            _clearButton.FlatAppearance.BorderSize = 0; // この行を追加
            _clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _clearButton.Font = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);
            _clearButton.Visible = false;
            Controls.Add(_clearButton);
        }

        private void _clearButton_Click(object sender, EventArgs e)
        {
            Text = string.Empty;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _clearButton.Visible = Text.Length > 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _clearButton.Size = new Size(20, ClientSize.Height - 4);
            _clearButton.Location = new Point(ClientSize.Width - _clearButton.Width - 1, +2);
        }
    }
}