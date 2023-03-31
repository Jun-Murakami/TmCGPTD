using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_DateRange : Form
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
            ButtonOK = new Button();
            ButtonClear = new Button();
            Label3 = new Label();
            Label1 = new Label();
            DateTimePicker1 = new DateTimePicker();
            DateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // ButtonOK
            // 
            ButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonOK.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonOK.Location = new Point(63, 220);
            ButtonOK.Margin = new Padding(4, 10, 4, 5);
            ButtonOK.Name = "ButtonOK";
            ButtonOK.Size = new Size(119, 53);
            ButtonOK.TabIndex = 78;
            ButtonOK.Text = "OK";
            ButtonOK.UseVisualStyleBackColor = true;
            ButtonOK.Click += ButtonOK_Click;
            // 
            // ButtonClear
            // 
            ButtonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonClear.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear.Location = new Point(190, 220);
            ButtonClear.Margin = new Padding(4, 10, 0, 5);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(119, 53);
            ButtonClear.TabIndex = 79;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Click += ButtonClear_Click;
            // 
            // Label3
            // 
            Label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.ForeColor = SystemColors.ControlText;
            Label3.Location = new Point(17, 20);
            Label3.Margin = new Padding(4, 5, 4, 5);
            Label3.Name = "Label3";
            Label3.Size = new Size(186, 32);
            Label3.TabIndex = 80;
            Label3.Text = "Search Start Date :";
            // 
            // Label1
            // 
            Label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label1.ForeColor = SystemColors.ControlText;
            Label1.Location = new Point(17, 120);
            Label1.Margin = new Padding(4, 15, 4, 5);
            Label1.Name = "Label1";
            Label1.Size = new Size(186, 32);
            Label1.TabIndex = 81;
            Label1.Text = "Search End Date :";
            // 
            // DateTimePicker1
            // 
            DateTimePicker1.Location = new Point(23, 62);
            DateTimePicker1.Margin = new Padding(4, 5, 4, 5);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(284, 31);
            DateTimePicker1.TabIndex = 82;
            // 
            // DateTimePicker2
            // 
            DateTimePicker2.Location = new Point(23, 162);
            DateTimePicker2.Margin = new Padding(4, 5, 4, 5);
            DateTimePicker2.Name = "DateTimePicker2";
            DateTimePicker2.Size = new Size(284, 31);
            DateTimePicker2.TabIndex = 83;
            // 
            // Form_DateRange
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 293);
            Controls.Add(DateTimePicker2);
            Controls.Add(DateTimePicker1);
            Controls.Add(Label1);
            Controls.Add(Label3);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonOK);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_DateRange";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Date Range";
            Load += Form_DateRange_Load;
            ResumeLayout(false);
        }

        internal MonthCalendar MonthCalendar1;
        internal MonthCalendar MonthCalendar2;
        internal Button ButtonOK;
        internal Button ButtonClear;
        internal Label Label3;
        internal Label Label1;
        internal DateTimePicker DateTimePicker1;
        internal DateTimePicker DateTimePicker2;
    }
}