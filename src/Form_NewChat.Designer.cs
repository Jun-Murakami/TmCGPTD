using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_NewChat : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewChat));
            Label23 = new Label();
            TextBox1 = new TextBox();
            ButtonCancel = new Button();
            ButtonOK = new Button();
            SuspendLayout();
            // 
            // Label23
            // 
            Label23.AutoSize = true;
            Label23.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label23.Location = new Point(27, 37);
            Label23.Margin = new Padding(14, 17, 14, 17);
            Label23.Name = "Label23";
            Label23.Size = new Size(222, 29);
            Label23.TabIndex = 56;
            Label23.Text = "Please enter the title.";
            // 
            // TextBox1
            // 
            TextBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBox1.Location = new Point(27, 113);
            TextBox1.Margin = new Padding(4, 5, 4, 5);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(427, 39);
            TextBox1.TabIndex = 57;
            TextBox1.KeyDown += TextBox1_KeyDown;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonCancel.Location = new Point(250, 191);
            ButtonCancel.Margin = new Padding(0, 25, 21, 25);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(171, 67);
            ButtonCancel.TabIndex = 59;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonOK
            // 
            ButtonOK.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonOK.Location = new Point(58, 191);
            ButtonOK.Margin = new Padding(21, 25, 21, 25);
            ButtonOK.Name = "ButtonOK";
            ButtonOK.Size = new Size(171, 67);
            ButtonOK.TabIndex = 58;
            ButtonOK.Text = "OK";
            ButtonOK.UseVisualStyleBackColor = true;
            ButtonOK.Click += ButtonOK_Click;
            // 
            // Form_NewChat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 278);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOK);
            Controls.Add(TextBox1);
            Controls.Add(Label23);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_NewChat";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Chat";
            Shown += Form_NewChat_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label23;
        internal TextBox TextBox1;
        internal Button ButtonCancel;
        internal Button ButtonOK;
    }
}