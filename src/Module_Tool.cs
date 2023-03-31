using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TmCGPTD
{

    public partial class Form1
    {
        // ボタン色変更--------------------------------------------------------------
        private void ChangeControlColor()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (!(frm.Name == "Form1"))
                {
                    frm.BackColor = Color.FromArgb(53, 55, 64);
                    frm.ForeColor = Color.FromArgb(220, 220, 220);
                }
                ChangeButtonColorsInContainer(frm);
            }
        }

        private void ChangeButtonColorsInContainer(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Panel)
                {
                    Panel pnl = (Panel)ctrl;
                    pnl.BackColor = Color.FromArgb(53, 55, 64);
                    pnl.ForeColor = Color.FromArgb(220, 220, 220);
                }
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.BackColor = Color.FromArgb(53, 55, 64);
                    btn.ForeColor = Color.FromArgb(255, 255, 255);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(106, 108, 125);
                    btn.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(84, 85, 99);
                    btn.FlatStyle = FlatStyle.Flat;
                    // イベントハンドラの追加
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
                else if (ctrl is Label)
                {
                    Label Lbl = (Label)ctrl;
                    Lbl.BackColor = Color.FromArgb(53, 55, 64);
                    Lbl.ForeColor = Color.FromArgb(220, 220, 220);
                    Lbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                else if (ctrl is TextBox)
                {
                    TextBox tbx = (TextBox)ctrl;
                    tbx.BackColor = Color.FromArgb(53, 55, 64);
                    tbx.ForeColor = Color.FromArgb(220, 220, 220);
                    tbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox)
                {
                    TmCGPTD.CustomComboBox cbx = (TmCGPTD.CustomComboBox)ctrl;
                    cbx.BackColor = Color.FromArgb(53, 55, 64);
                    cbx.ForeColor = Color.FromArgb(220, 220, 220);
                    if (cbx.Name == "ComboBoxSearch")
                        cbx.ForeColor = Color.FromArgb(160, 160, 160);
                }
                else if (ctrl.HasChildren)
                {
                    ChangeButtonColorsInContainer(ctrl);
                }
            }

        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!(btn.BackColor == Color.FromArgb(146, 148, 165)))
            {
                btn.BackColor = Color.FromArgb(164, 165, 179); // 任意のマウスオーバー時の背景色
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!(btn.BackColor == Color.FromArgb(146, 148, 165)))
            {
                btn.BackColor = Color.FromArgb(53, 55, 64); // 元の背景色に戻す
            }
        }

        // 画像の高dpi対応--------------------------------------------------------------
        public void SetPictureBoxImage(string imageFileName, PictureBox pictureBox)
        {
            var assembly = Assembly.GetExecutingAssembly(); // 埋め込みリソースから画像を読み込む
            var originalImage = Image.FromStream(assembly.GetManifestResourceStream(imageFileName)); // 元の画像を読み込む
            var designSize = new Size(pictureBox.Width, pictureBox.Height); // PictureBoxのデザイン時のサイズを取得
            pictureBox.Image = GetResizedImageForDpi(originalImage, designSize); // PictureBoxのImageプロパティにリサイズされた画像を設定
        }

        public Image GetResizedImageForDpi(Image originalImage, Size designSize)
        {
            // DPIスケーリングを取得
            float dpiScaling = GetDpiScaling();

            // 新しいサイズにリサイズする
            int newWidth = (int)Math.Round(designSize.Width * dpiScaling);
            int newHeight = (int)Math.Round(designSize.Height * dpiScaling);
            var resizedImage = new Bitmap(newWidth, newHeight);

            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public float GetDpiScaling()
        {
            // Graphicsオブジェクトを取得
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                // 現在のDPIスケーリングを計算
                float dpiScaling = g.DpiX / 96.0f;
                return dpiScaling;
            }
        }

        // モーダルダイアログプリセット--------------------------------------------------------------
        public void ShowCenteredDialog(Form mainForm, Form dialog)
        {
            // ダイアログのStartPositionプロパティをManualに設定
            dialog.StartPosition = FormStartPosition.Manual;

            // ダイアログの位置をメインフォームの中央に設定
            dialog.Location = new Point(mainForm.Location.X + (mainForm.Width - dialog.Width) / 2, mainForm.Location.Y + (mainForm.Height - dialog.Height) / 2);

            // モーダルダイアログを表示
            dialog.ShowDialog(mainForm);
        }

    }
}