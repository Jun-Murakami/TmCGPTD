using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Input : DockContent
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
            TableLayoutPanel2 = new TableLayoutPanel();
            TextInput5 = new ScintillaNET.Scintilla();
            TextInput3 = new ScintillaNET.Scintilla();
            TextInput4 = new ScintillaNET.Scintilla();
            TextInput2 = new ScintillaNET.Scintilla();
            TextInput1 = new ScintillaNET.Scintilla();
            ComboBoxSearch = new CustomComboBox();
            ButtonPrev = new Button();
            ButtonNext = new Button();
            ButtonRecentLog = new Button();
            ButtonDelete = new Button();
            Label1 = new Label();
            ButtonClear1 = new Button();
            ButtonClear2 = new Button();
            ButtonClear3 = new Button();
            ButtonClear4 = new Button();
            ButtonClear5 = new Button();
            ButtonClearAll = new Button();
            ButtonPost = new Button();
            Label3 = new Label();
            ButtonSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel2
            // 
            TableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TableLayoutPanel2.ColumnCount = 1;
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanel2.Controls.Add(TextInput5, 0, 4);
            TableLayoutPanel2.Controls.Add(TextInput3, 0, 2);
            TableLayoutPanel2.Controls.Add(TextInput4, 0, 3);
            TableLayoutPanel2.Controls.Add(TextInput2, 0, 1);
            TableLayoutPanel2.Controls.Add(TextInput1, 0, 0);
            TableLayoutPanel2.Location = new Point(0, 44);
            TableLayoutPanel2.Margin = new Padding(0);
            TableLayoutPanel2.Name = "TableLayoutPanel2";
            TableLayoutPanel2.RowCount = 5;
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 89F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanel2.Size = new Size(558, 317);
            TableLayoutPanel2.TabIndex = 51;
            // 
            // TextInput5
            // 
            TextInput5.AutoCCancelAtStart = false;
            TextInput5.AutoCMaxHeight = 9;
            TextInput5.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextInput5.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            TextInput5.CaretForeColor = Color.White;
            TextInput5.CaretLineBackColor = Color.FromArgb(32, 33, 45);
            TextInput5.CaretLineVisible = true;
            TextInput5.Dock = DockStyle.Fill;
            TextInput5.Font = new Font("Migu 1M", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextInput5.LexerName = null;
            TextInput5.Location = new Point(0, 249);
            TextInput5.Margin = new Padding(0);
            TextInput5.Margins.Left = 5;
            TextInput5.Margins.Right = 10;
            TextInput5.Name = "TextInput5";
            TextInput5.ScrollWidth = 110;
            TextInput5.Size = new Size(558, 68);
            TextInput5.TabIndents = true;
            TextInput5.TabIndex = 5;
            TextInput5.TabStop = false;
            TextInput5.UseRightToLeftReadingLayout = false;
            TextInput5.WrapMode = ScintillaNET.WrapMode.None;
            TextInput5.TextChanged += TextInput_TextChanged;
            TextInput5.GotFocus += TextInput_GotFocus;
            TextInput5.KeyDown += TextInputes_KeyDown;
            // 
            // TextInput3
            // 
            TextInput3.AutoCCancelAtStart = false;
            TextInput3.AutoCMaxHeight = 9;
            TextInput3.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextInput3.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            TextInput3.CaretForeColor = Color.White;
            TextInput3.CaretLineBackColor = Color.FromArgb(32, 33, 45);
            TextInput3.CaretLineVisible = true;
            TextInput3.Dock = DockStyle.Fill;
            TextInput3.Font = new Font("Migu 1M", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextInput3.LexerName = null;
            TextInput3.Location = new Point(0, 153);
            TextInput3.Margin = new Padding(0);
            TextInput3.Margins.Left = 5;
            TextInput3.Margins.Right = 10;
            TextInput3.Name = "TextInput3";
            TextInput3.ScrollWidth = 110;
            TextInput3.Size = new Size(558, 32);
            TextInput3.TabIndents = true;
            TextInput3.TabIndex = 3;
            TextInput3.TabStop = false;
            TextInput3.UseRightToLeftReadingLayout = false;
            TextInput3.WrapMode = ScintillaNET.WrapMode.None;
            TextInput3.TextChanged += TextInput_TextChanged;
            TextInput3.GotFocus += TextInput_GotFocus;
            TextInput3.KeyDown += TextInputes_KeyDown;
            // 
            // TextInput4
            // 
            TextInput4.AutoCCancelAtStart = false;
            TextInput4.AutoCMaxHeight = 9;
            TextInput4.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextInput4.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            TextInput4.CaretForeColor = Color.White;
            TextInput4.CaretLineBackColor = Color.FromArgb(32, 33, 45);
            TextInput4.CaretLineVisible = true;
            TextInput4.Dock = DockStyle.Fill;
            TextInput4.Font = new Font("Migu 1M", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextInput4.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            TextInput4.LexerName = null;
            TextInput4.Location = new Point(0, 185);
            TextInput4.Margin = new Padding(0);
            TextInput4.Margins.Left = 5;
            TextInput4.Margins.Right = 10;
            TextInput4.Name = "TextInput4";
            TextInput4.ScrollWidth = 110;
            TextInput4.Size = new Size(558, 64);
            TextInput4.TabIndents = true;
            TextInput4.TabIndex = 4;
            TextInput4.TabStop = false;
            TextInput4.UseRightToLeftReadingLayout = false;
            TextInput4.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways;
            TextInput4.WhitespaceSize = 2;
            TextInput4.WrapMode = ScintillaNET.WrapMode.None;
            TextInput4.TextChanged += TextInput_TextChanged;
            TextInput4.GotFocus += TextInput_GotFocus;
            TextInput4.KeyDown += TextInputes_KeyDown;
            // 
            // TextInput2
            // 
            TextInput2.AutoCCancelAtStart = false;
            TextInput2.AutoCMaxHeight = 9;
            TextInput2.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextInput2.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            TextInput2.CaretForeColor = Color.White;
            TextInput2.CaretLineBackColor = Color.FromArgb(32, 33, 45);
            TextInput2.CaretLineVisible = true;
            TextInput2.Dock = DockStyle.Fill;
            TextInput2.Font = new Font("Migu 1M", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextInput2.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            TextInput2.LexerName = null;
            TextInput2.Location = new Point(0, 89);
            TextInput2.Margin = new Padding(0);
            TextInput2.Margins.Left = 5;
            TextInput2.Margins.Right = 10;
            TextInput2.Name = "TextInput2";
            TextInput2.ScrollWidth = 110;
            TextInput2.Size = new Size(558, 64);
            TextInput2.TabIndents = true;
            TextInput2.TabIndex = 2;
            TextInput2.TabStop = false;
            TextInput2.UseRightToLeftReadingLayout = false;
            TextInput2.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways;
            TextInput2.WhitespaceSize = 2;
            TextInput2.WrapMode = ScintillaNET.WrapMode.None;
            TextInput2.TextChanged += TextInput_TextChanged;
            TextInput2.GotFocus += TextInput_GotFocus;
            TextInput2.KeyDown += TextInputes_KeyDown;
            // 
            // TextInput1
            // 
            TextInput1.AutoCCancelAtStart = false;
            TextInput1.AutoCMaxHeight = 9;
            TextInput1.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextInput1.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            TextInput1.CaretForeColor = Color.White;
            TextInput1.CaretLineBackColor = Color.FromArgb(32, 33, 45);
            TextInput1.CaretLineVisible = true;
            TextInput1.Dock = DockStyle.Fill;
            TextInput1.EdgeColor = Color.FromArgb(96, 96, 96);
            TextInput1.Font = new Font("Migu 1M", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextInput1.LexerName = null;
            TextInput1.Location = new Point(0, 0);
            TextInput1.Margin = new Padding(0);
            TextInput1.Margins.Left = 5;
            TextInput1.Margins.Right = 10;
            TextInput1.Name = "TextInput1";
            TextInput1.ScrollWidth = 110;
            TextInput1.Size = new Size(558, 89);
            TextInput1.TabIndents = true;
            TextInput1.TabIndex = 1;
            TextInput1.TabStop = false;
            TextInput1.UseRightToLeftReadingLayout = false;
            TextInput1.WrapMode = ScintillaNET.WrapMode.None;
            TextInput1.TextChanged += TextInput_TextChanged;
            TextInput1.GotFocus += TextInput_GotFocus;
            TextInput1.KeyDown += TextInputes_KeyDown;
            // 
            // ComboBoxSearch
            // 
            ComboBoxSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxSearch.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxSearch.FlatStyle = FlatStyle.Flat;
            ComboBoxSearch.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxSearch.FormattingEnabled = true;
            ComboBoxSearch.Location = new Point(0, 7);
            ComboBoxSearch.Margin = new Padding(0);
            ComboBoxSearch.Name = "ComboBoxSearch";
            ComboBoxSearch.Size = new Size(283, 30);
            ComboBoxSearch.TabIndex = 14;
            ComboBoxSearch.Text = "Type text here and press Enter to search Editor log.";
            ComboBoxSearch.DrawItem += ComboBoxSearch_DrawItem;
            ComboBoxSearch.SelectedIndexChanged += ComboBoxSearch_SelectedIndexChanged;
            ComboBoxSearch.GotFocus += ComboBoxSearch_GotFocus;
            ComboBoxSearch.KeyDown += ComboBoxSearch_KeyDownAsync;
            // 
            // ButtonPrev
            // 
            ButtonPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonPrev.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPrev.Location = new Point(345, 6);
            ButtonPrev.Margin = new Padding(6, 3, 3, 3);
            ButtonPrev.Name = "ButtonPrev";
            ButtonPrev.Size = new Size(29, 32);
            ButtonPrev.TabIndex = 15;
            ButtonPrev.Text = "<";
            ButtonPrev.UseVisualStyleBackColor = true;
            ButtonPrev.Click += ButtonPrev_Click;
            // 
            // ButtonNext
            // 
            ButtonNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonNext.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonNext.Location = new Point(377, 6);
            ButtonNext.Margin = new Padding(0, 3, 3, 3);
            ButtonNext.Name = "ButtonNext";
            ButtonNext.Size = new Size(29, 32);
            ButtonNext.TabIndex = 16;
            ButtonNext.Text = ">";
            ButtonNext.UseVisualStyleBackColor = true;
            ButtonNext.Click += ButtonNext_Click;
            // 
            // ButtonRecentLog
            // 
            ButtonRecentLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonRecentLog.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonRecentLog.Location = new Point(414, 6);
            ButtonRecentLog.Margin = new Padding(5, 3, 3, 3);
            ButtonRecentLog.Name = "ButtonRecentLog";
            ButtonRecentLog.Size = new Size(64, 32);
            ButtonRecentLog.TabIndex = 17;
            ButtonRecentLog.Text = "Recent";
            ButtonRecentLog.UseVisualStyleBackColor = true;
            ButtonRecentLog.Click += ButtonRecentLog_ClickAsync;
            // 
            // ButtonDelete
            // 
            ButtonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonDelete.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonDelete.Location = new Point(484, 6);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(64, 32);
            ButtonDelete.TabIndex = 18;
            ButtonDelete.Text = "Delete";
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_ClickAsync;
            // 
            // Label1
            // 
            Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label1.ForeColor = SystemColors.ControlText;
            Label1.Location = new Point(9, 376);
            Label1.Name = "Label1";
            Label1.Size = new Size(47, 19);
            Label1.TabIndex = 73;
            Label1.Text = "Clear:";
            Label1.TextAlign = ContentAlignment.TopRight;
            // 
            // ButtonClear1
            // 
            ButtonClear1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClear1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear1.Location = new Point(62, 369);
            ButtonClear1.Name = "ButtonClear1";
            ButtonClear1.Size = new Size(40, 32);
            ButtonClear1.TabIndex = 6;
            ButtonClear1.Text = "1";
            ButtonClear1.UseVisualStyleBackColor = true;
            ButtonClear1.Click += ButtonClear_Click;
            // 
            // ButtonClear2
            // 
            ButtonClear2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClear2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear2.Location = new Point(108, 369);
            ButtonClear2.Name = "ButtonClear2";
            ButtonClear2.Size = new Size(40, 32);
            ButtonClear2.TabIndex = 7;
            ButtonClear2.Text = "2";
            ButtonClear2.UseVisualStyleBackColor = true;
            ButtonClear2.Click += ButtonClear_Click;
            // 
            // ButtonClear3
            // 
            ButtonClear3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClear3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear3.Location = new Point(154, 369);
            ButtonClear3.Name = "ButtonClear3";
            ButtonClear3.Size = new Size(40, 32);
            ButtonClear3.TabIndex = 8;
            ButtonClear3.Text = "3";
            ButtonClear3.UseVisualStyleBackColor = true;
            ButtonClear3.Click += ButtonClear_Click;
            // 
            // ButtonClear4
            // 
            ButtonClear4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClear4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear4.Location = new Point(200, 369);
            ButtonClear4.Name = "ButtonClear4";
            ButtonClear4.Size = new Size(40, 32);
            ButtonClear4.TabIndex = 9;
            ButtonClear4.Text = "4";
            ButtonClear4.UseVisualStyleBackColor = true;
            ButtonClear4.Click += ButtonClear_Click;
            // 
            // ButtonClear5
            // 
            ButtonClear5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClear5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClear5.Location = new Point(246, 369);
            ButtonClear5.Name = "ButtonClear5";
            ButtonClear5.Size = new Size(40, 32);
            ButtonClear5.TabIndex = 10;
            ButtonClear5.Text = "5";
            ButtonClear5.UseVisualStyleBackColor = true;
            ButtonClear5.Click += ButtonClear_Click;
            // 
            // ButtonClearAll
            // 
            ButtonClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonClearAll.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonClearAll.Location = new Point(292, 369);
            ButtonClearAll.Name = "ButtonClearAll";
            ButtonClearAll.Size = new Size(80, 32);
            ButtonClearAll.TabIndex = 11;
            ButtonClearAll.Text = "All clear";
            ButtonClearAll.UseVisualStyleBackColor = true;
            ButtonClearAll.Click += ButtonClearAll_Click;
            // 
            // ButtonPost
            // 
            ButtonPost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonPost.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPost.Image = Properties.Resources.iconWriteBlack;
            ButtonPost.ImageAlign = ContentAlignment.MiddleRight;
            ButtonPost.Location = new Point(445, 365);
            ButtonPost.Name = "ButtonPost";
            ButtonPost.Size = new Size(100, 40);
            ButtonPost.TabIndex = 13;
            ButtonPost.Text = "Post";
            ButtonPost.UseVisualStyleBackColor = true;
            ButtonPost.Click += ButtonPost_Click;
            // 
            // Label3
            // 
            Label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.ForeColor = SystemColors.ControlText;
            Label3.Location = new Point(12, 13);
            Label3.Name = "Label3";
            Label3.Size = new Size(41, 19);
            Label3.TabIndex = 78;
            Label3.Text = "Log:";
            // 
            // ButtonSave
            // 
            ButtonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonSave.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonSave.Location = new Point(377, 369);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(62, 32);
            ButtonSave.TabIndex = 12;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(ComboBoxSearch, 0, 0);
            tableLayoutPanel1.Location = new Point(56, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(283, 44);
            tableLayoutPanel1.TabIndex = 79;
            // 
            // Form_Input
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 411);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(ButtonSave);
            Controls.Add(Label3);
            Controls.Add(ButtonPost);
            Controls.Add(ButtonClear4);
            Controls.Add(ButtonClear3);
            Controls.Add(ButtonClearAll);
            Controls.Add(ButtonClear5);
            Controls.Add(ButtonClear2);
            Controls.Add(Label1);
            Controls.Add(ButtonClear1);
            Controls.Add(ButtonRecentLog);
            Controls.Add(TableLayoutPanel2);
            Controls.Add(ButtonPrev);
            Controls.Add(ButtonNext);
            Controls.Add(ButtonDelete);
            MinimumSize = new Size(573, 393);
            Name = "Form_Input";
            Text = "Editor";
            FormClosing += InputForm_FormClosing;
            Load += Form_Input_Load;
            Shown += Form_Input_Shown;
            TableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        internal TableLayoutPanel TableLayoutPanel2;
        internal ScintillaNET.Scintilla TextInput1;
        internal ScintillaNET.Scintilla TextInput2;
        internal ScintillaNET.Scintilla TextInput3;
        internal ScintillaNET.Scintilla TextInput4;
        internal ScintillaNET.Scintilla TextInput5;
        internal TmCGPTD.CustomComboBox ComboBoxSearch;
        internal Button ButtonPrev;
        internal Button ButtonNext;
        internal Button ButtonRecentLog;
        internal Button ButtonDelete;
        internal Label Label1;
        internal Button ButtonClear1;
        internal Button ButtonClear2;
        internal Button ButtonClear3;
        internal Button ButtonClear4;
        internal Button ButtonClear5;
        internal Button ButtonClearAll;
        internal Button ButtonPost;
        internal Label Label3;
        internal Button ButtonSave;
        private TableLayoutPanel tableLayoutPanel1;
    }
}