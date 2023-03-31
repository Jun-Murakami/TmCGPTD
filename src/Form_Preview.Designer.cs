using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Preview : DockContent
    {

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Windows フォーム デザイナーで必要です。
        private System.ComponentModel.IContainer components;

        // メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        // Windows フォーム デザイナーを使用して変更できます。  
        // コード エディターを使って変更しないでください。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            TextOut = new TextBox();
            TextOut.MouseWheel += new MouseEventHandler(TextOut_MouseWheel);
            SuspendLayout();
            // 
            // TextOut
            // 
            TextOut.BackColor = SystemColors.Control;
            TextOut.Dock = DockStyle.Fill;
            TextOut.Font = new Font("Migu 1M", 8f, FontStyle.Regular, GraphicsUnit.Point);
            TextOut.ForeColor = Color.FromArgb(42, 43, 55);
            TextOut.Location = new Point(0, 0);
            TextOut.Margin = new Padding(0);
            TextOut.Multiline = true;
            TextOut.Name = "TextOut";
            TextOut.ReadOnly = true;
            TextOut.ScrollBars = ScrollBars.Both;
            TextOut.Size = new Size(800, 450);
            TextOut.TabIndex = 68;
            TextOut.WordWrap = false;
            // 
            // Form_Preview
            // 
            AutoScaleDimensions = new SizeF(7f, 15f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextOut);
            Name = "Form_Preview";
            Text = "Preview";
            Shown += new EventHandler(Form_Preview_Shown);
            FormClosing += new FormClosingEventHandler(PreviewForm_FormClosing);
            SizeChanged += new EventHandler(MyForm_SizeChanged);
            DockStateChanged += new EventHandler(MyForm_DockStateChanged);
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox TextOut;
        internal System.CodeDom.CodeTypeReference CustomTextBox1;
    }
}