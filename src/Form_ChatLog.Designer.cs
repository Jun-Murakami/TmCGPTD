using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_ChatLog : WeifenLuo.WinFormsUI.Docking.DockContent
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Panel1 = new Panel();
            TableLayoutPanel1 = new TableLayoutPanel();
            TextBoxSearch = new TextBoxWithClearButton();
            ButtonCal = new Button();
            ButtonChatDelete = new Button();
            PictureBox2 = new PictureBox();
            PictureBox1 = new PictureBox();
            ComboBoxTag = new CustomComboBox();
            Panel2 = new Panel();
            DataGrid = new DataGridView();
            Panel1.SuspendLayout();
            TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // Panel1
            // 
            Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel1.Controls.Add(TableLayoutPanel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Margin = new Padding(0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(916, 70);
            Panel1.TabIndex = 0;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 6;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            TableLayoutPanel1.Controls.Add(TextBoxSearch, 1, 0);
            TableLayoutPanel1.Controls.Add(ButtonCal, 4, 0);
            TableLayoutPanel1.Controls.Add(ButtonChatDelete, 5, 0);
            TableLayoutPanel1.Controls.Add(PictureBox2, 2, 0);
            TableLayoutPanel1.Controls.Add(PictureBox1, 0, 0);
            TableLayoutPanel1.Controls.Add(ComboBoxTag, 3, 0);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Margin = new Padding(14, 8, 14, 8);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.Padding = new Padding(14, 8, 14, 8);
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel1.Size = new Size(916, 70);
            TableLayoutPanel1.TabIndex = 78;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.None;
            TextBoxSearch.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxSearch.Location = new Point(61, 15);
            TextBoxSearch.Margin = new Padding(3, 3, 9, 3);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(310, 39);
            TextBoxSearch.TabIndex = 69;
            TextBoxSearch.TextChanged += TextBoxSearch_TextChangedAsync;
            // 
            // ButtonCal
            // 
            ButtonCal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonCal.BackgroundImageLayout = ImageLayout.Center;
            ButtonCal.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonCal.Location = new Point(748, 8);
            ButtonCal.Margin = new Padding(0);
            ButtonCal.Name = "ButtonCal";
            ButtonCal.Size = new Size(46, 52);
            ButtonCal.TabIndex = 71;
            ButtonCal.UseVisualStyleBackColor = true;
            ButtonCal.Click += ButtonCal_ClickAsync;
            // 
            // ButtonChatDelete
            // 
            ButtonChatDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonChatDelete.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonChatDelete.Location = new Point(806, 8);
            ButtonChatDelete.Margin = new Padding(4, 0, 0, 0);
            ButtonChatDelete.Name = "ButtonChatDelete";
            ButtonChatDelete.Size = new Size(96, 52);
            ButtonChatDelete.TabIndex = 72;
            ButtonChatDelete.Text = "Delete";
            ButtonChatDelete.UseVisualStyleBackColor = true;
            ButtonChatDelete.Click += ButtonChatDelete_ClickAsync;
            // 
            // PictureBox2
            // 
            PictureBox2.Image = Properties.Resources.iconTag;
            PictureBox2.InitialImage = Properties.Resources.iconTag;
            PictureBox2.Location = new Point(385, 12);
            PictureBox2.Margin = new Padding(4, 4, 4, 4);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(34, 44);
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox2.TabIndex = 80;
            PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            PictureBox1.Image = Properties.Resources.iconSearch;
            PictureBox1.InitialImage = Properties.Resources.iconChat;
            PictureBox1.Location = new Point(18, 12);
            PictureBox1.Margin = new Padding(4, 4, 4, 4);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(34, 44);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 79;
            PictureBox1.TabStop = false;
            // 
            // ComboBoxTag
            // 
            ComboBoxTag.Anchor = AnchorStyles.None;
            ComboBoxTag.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxTag.FlatStyle = FlatStyle.Flat;
            ComboBoxTag.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxTag.FormattingEnabled = true;
            ComboBoxTag.Location = new Point(428, 15);
            ComboBoxTag.Margin = new Padding(3, 3, 9, 3);
            ComboBoxTag.Name = "ComboBoxTag";
            ComboBoxTag.Size = new Size(310, 40);
            ComboBoxTag.TabIndex = 70;
            ComboBoxTag.DrawItem += ComboBoxTag_DrawItem;
            ComboBoxTag.SelectedIndexChanged += ComboBoxTag_SelectedIndexChangedAync;
            // 
            // Panel2
            // 
            Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel2.Controls.Add(DataGrid);
            Panel2.Location = new Point(0, 70);
            Panel2.Margin = new Padding(0);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(916, 726);
            Panel2.TabIndex = 1;
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;
            DataGrid.AllowUserToOrderColumns = true;
            DataGrid.AllowUserToResizeRows = false;
            DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DataGrid.BackgroundColor = Color.FromArgb(33, 34, 35);
            DataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(42, 43, 55);
            dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(42, 43, 55);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 34, 35);
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ScrollBar;
            dataGridViewCellStyle2.Padding = new Padding(3, 10, 3, 10);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(68, 70, 84);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            DataGrid.Dock = DockStyle.Fill;
            DataGrid.GridColor = SystemColors.ButtonShadow;
            DataGrid.Location = new Point(0, 0);
            DataGrid.Margin = new Padding(0);
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(96, 96, 96);
            dataGridViewCellStyle3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.RowHeadersVisible = false;
            DataGrid.RowHeadersWidth = 40;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(33, 34, 35);
            dataGridViewCellStyle4.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle4.Padding = new Padding(3, 10, 3, 10);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(68, 70, 84);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DataGrid.RowTemplate.Height = 33;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(916, 726);
            DataGrid.TabIndex = 73;
            DataGrid.CellClick += DataGrid_CellClick;
            DataGrid.CellValueNeeded += DataGrid_CellValueNeeded;
            // 
            // Form_ChatLog
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(916, 802);
            Controls.Add(Panel2);
            Controls.Add(Panel1);
            Name = "Form_ChatLog";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Chat List";
            DockStateChanged += MyForm_DockStateChanged;
            Activated += Form_ChatLog_Activated;
            FormClosing += ChatLogForm_FormClosing;
            Load += ChatLogForm_Load;
            SizeChanged += MyForm_SizeChanged;
            Panel1.ResumeLayout(false);
            TableLayoutPanel1.ResumeLayout(false);
            TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
        }

        internal Panel Panel1;
        internal Panel Panel2;
        internal DataGridView DataGrid;
        internal Button ButtonChatDelete;
        internal Button ButtonCal;
        internal PictureBox PictureBox1;
        internal PictureBox PictureBox2;
        internal TableLayoutPanel TableLayoutPanel1;
        internal TmCGPTD.CustomComboBox ComboBoxTag;
        internal TmCGPTD.TextBoxWithClearButton TextBoxSearch;
    }
}