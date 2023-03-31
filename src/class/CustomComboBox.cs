using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TmCGPTD
{

    public class CustomComboBox : ComboBox
    {

        private const int WM_PAINT = 0xF;

        public CustomComboBox() : base()
        {
            DropDownStyle = ComboBoxStyle.DropDown;
            DrawMode = DrawMode.OwnerDrawFixed;
            FlatStyle = FlatStyle.Flat;
            //DoubleBuffered = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                var borderColor = Color.FromArgb(106, 108, 125);
                var borderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

                using (var g = CreateGraphics())
                {
                    using (var borderPen = new Pen(borderColor))
                    {
                        g.DrawRectangle(borderPen, borderRectangle);
                    }

                    int buttonWidth = SystemInformation.VerticalScrollBarWidth;
                    var buttonBounds = new Rectangle(Width - buttonWidth - 1, 0, buttonWidth, Height - 1);

                    ComboBoxRenderer.DrawDropDownButton(g, buttonBounds, ComboBoxState.Normal);
                    using (var buttonBrush = new SolidBrush(borderColor))
                    {
                        g.FillRectangle(buttonBrush, new Rectangle(buttonBounds.X, buttonBounds.Y, buttonBounds.Width - 1, buttonBounds.Height));
                    }
                    ComboBoxRenderer.DrawDropDownButton(g, buttonBounds, ComboBoxState.Normal);
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }
    }
}