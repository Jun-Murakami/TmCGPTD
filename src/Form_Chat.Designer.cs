using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Chat : WeifenLuo.WinFormsUI.Docking.DockContent
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
            ChatBox = new ScintillaNET.Scintilla();
            Panel1 = new Panel();
            ButtonNewChat = new Button();
            TableLayoutPanel1 = new TableLayoutPanel();
            TextBoxTag3 = new TextBoxWithClearButton();
            TextBoxTag2 = new TextBoxWithClearButton();
            TextBoxTag1 = new TextBoxWithClearButton();
            PictureButtonTag = new PictureBox();
            PictureBox2 = new PictureBox();
            Panel2 = new Panel();
            Panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            TextBoxChatTextSearch = new TextBoxWithClearButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            TextBoxTitle = new TextBoxWithClearButton();
            ButtonDown = new Button();
            ButtonUp = new Button();
            PictureBox3 = new PictureBox();
            PictureButtonTitle = new PictureBox();
            PictureBox1 = new PictureBox();
            Panel1.SuspendLayout();
            TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureButtonTag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            Panel2.SuspendLayout();
            Panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureButtonTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ChatBox
            // 
            ChatBox.AutoCMaxHeight = 9;
            ChatBox.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            ChatBox.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            ChatBox.CaretForeColor = Color.White;
            ChatBox.CaretLineBackColor = Color.Black;
            ChatBox.CaretLineBackColorAlpha = 0;
            ChatBox.CaretLineLayer = ScintillaNET.Layer.UnderText;
            ChatBox.CaretLineVisible = true;
            ChatBox.Dock = DockStyle.Fill;
            ChatBox.Font = new Font("Migu 1M", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ChatBox.LexerName = null;
            ChatBox.Location = new Point(0, 0);
            ChatBox.Margin = new Padding(0);
            ChatBox.Margins.Left = 10;
            ChatBox.Margins.Right = 10;
            ChatBox.Name = "ChatBox";
            ChatBox.ScrollWidth = 75;
            ChatBox.Size = new Size(939, 987);
            ChatBox.TabIndents = true;
            ChatBox.TabIndex = 22;
            ChatBox.UseRightToLeftReadingLayout = false;
            ChatBox.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways;
            ChatBox.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // Panel1
            // 
            Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel1.Controls.Add(ButtonNewChat);
            Panel1.Controls.Add(TableLayoutPanel1);
            Panel1.Controls.Add(PictureButtonTag);
            Panel1.Controls.Add(PictureBox2);
            Panel1.Location = new Point(0, 1060);
            Panel1.Margin = new Padding(0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(939, 83);
            Panel1.TabIndex = 1;
            // 
            // ButtonNewChat
            // 
            ButtonNewChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonNewChat.BackColor = SystemColors.ControlLight;
            ButtonNewChat.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonNewChat.Image = Properties.Resources.iconWriteBlack;
            ButtonNewChat.ImageAlign = ContentAlignment.MiddleRight;
            ButtonNewChat.Location = new Point(743, 7);
            ButtonNewChat.Margin = new Padding(4, 5, 4, 5);
            ButtonNewChat.Name = "ButtonNewChat";
            ButtonNewChat.Size = new Size(179, 67);
            ButtonNewChat.TabIndex = 26;
            ButtonNewChat.Text = "New Chat";
            ButtonNewChat.UseVisualStyleBackColor = false;
            ButtonNewChat.Click += ButtonNewChat_Click;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TableLayoutPanel1.ColumnCount = 3;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanel1.Controls.Add(TextBoxTag3, 2, 0);
            TableLayoutPanel1.Controls.Add(TextBoxTag2, 1, 0);
            TableLayoutPanel1.Controls.Add(TextBoxTag1, 0, 0);
            TableLayoutPanel1.Location = new Point(60, 13);
            TableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel1.Size = new Size(614, 53);
            TableLayoutPanel1.TabIndex = 83;
            // 
            // TextBoxTag3
            // 
            TextBoxTag3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxTag3.BackColor = Color.FromArgb(42, 43, 55);
            TextBoxTag3.BorderStyle = BorderStyle.FixedSingle;
            TextBoxTag3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxTag3.ForeColor = SystemColors.ScrollBar;
            TextBoxTag3.Location = new Point(408, 7);
            TextBoxTag3.Margin = new Padding(0);
            TextBoxTag3.Name = "TextBoxTag3";
            TextBoxTag3.Size = new Size(206, 39);
            TextBoxTag3.TabIndex = 25;
            // 
            // TextBoxTag2
            // 
            TextBoxTag2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxTag2.BackColor = Color.FromArgb(42, 43, 55);
            TextBoxTag2.BorderStyle = BorderStyle.FixedSingle;
            TextBoxTag2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxTag2.ForeColor = SystemColors.ScrollBar;
            TextBoxTag2.Location = new Point(204, 7);
            TextBoxTag2.Margin = new Padding(0);
            TextBoxTag2.Name = "TextBoxTag2";
            TextBoxTag2.Size = new Size(204, 39);
            TextBoxTag2.TabIndex = 24;
            // 
            // TextBoxTag1
            // 
            TextBoxTag1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxTag1.BackColor = Color.FromArgb(42, 43, 55);
            TextBoxTag1.BorderStyle = BorderStyle.FixedSingle;
            TextBoxTag1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxTag1.ForeColor = SystemColors.ScrollBar;
            TextBoxTag1.Location = new Point(4, 7);
            TextBoxTag1.Margin = new Padding(4, 0, 0, 0);
            TextBoxTag1.Name = "TextBoxTag1";
            TextBoxTag1.Size = new Size(200, 39);
            TextBoxTag1.TabIndex = 23;
            // 
            // PictureButtonTag
            // 
            PictureButtonTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureButtonTag.Image = Properties.Resources.iconWrite;
            PictureButtonTag.InitialImage = Properties.Resources.iconWrite;
            PictureButtonTag.Location = new Point(683, 20);
            PictureButtonTag.Margin = new Padding(4, 5, 13, 5);
            PictureButtonTag.Name = "PictureButtonTag";
            PictureButtonTag.Size = new Size(34, 40);
            PictureButtonTag.SizeMode = PictureBoxSizeMode.Zoom;
            PictureButtonTag.TabIndex = 82;
            PictureButtonTag.TabStop = false;
            PictureButtonTag.Click += PictureButtonTag_ClickAsync;
            PictureButtonTag.MouseEnter += PictureButton_MouseEnter;
            PictureButtonTag.MouseLeave += PictureButton_MouseLeave;
            // 
            // PictureBox2
            // 
            PictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PictureBox2.Image = Properties.Resources.iconTag;
            PictureBox2.Location = new Point(17, 20);
            PictureBox2.Margin = new Padding(4, 5, 4, 5);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(34, 40);
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox2.TabIndex = 79;
            PictureBox2.TabStop = false;
            // 
            // Panel2
            // 
            Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel2.Controls.Add(ChatBox);
            Panel2.Location = new Point(0, 73);
            Panel2.Margin = new Padding(0);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(939, 987);
            Panel2.TabIndex = 2;
            // 
            // Panel3
            // 
            Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel3.Controls.Add(tableLayoutPanel3);
            Panel3.Controls.Add(tableLayoutPanel2);
            Panel3.Controls.Add(ButtonDown);
            Panel3.Controls.Add(ButtonUp);
            Panel3.Controls.Add(PictureBox3);
            Panel3.Controls.Add(PictureButtonTitle);
            Panel3.Controls.Add(PictureBox1);
            Panel3.Location = new Point(0, 0);
            Panel3.Margin = new Padding(0);
            Panel3.Name = "Panel3";
            Panel3.Size = new Size(939, 73);
            Panel3.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(TextBoxChatTextSearch, 0, 0);
            tableLayoutPanel3.Location = new Point(621, 0);
            tableLayoutPanel3.Margin = new Padding(3, 0, 4, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(200, 73);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // TextBoxChatTextSearch
            // 
            TextBoxChatTextSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxChatTextSearch.BackColor = Color.FromArgb(42, 43, 55);
            TextBoxChatTextSearch.BorderStyle = BorderStyle.FixedSingle;
            TextBoxChatTextSearch.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TextBoxChatTextSearch.ForeColor = SystemColors.ScrollBar;
            TextBoxChatTextSearch.Location = new Point(0, 17);
            TextBoxChatTextSearch.Margin = new Padding(0);
            TextBoxChatTextSearch.Name = "TextBoxChatTextSearch";
            TextBoxChatTextSearch.Size = new Size(200, 39);
            TextBoxChatTextSearch.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(TextBoxTitle, 0, 0);
            tableLayoutPanel2.Location = new Point(60, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(465, 73);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // TextBoxTitle
            // 
            TextBoxTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxTitle.BackColor = Color.FromArgb(42, 43, 55);
            TextBoxTitle.BorderStyle = BorderStyle.FixedSingle;
            TextBoxTitle.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TextBoxTitle.ForeColor = SystemColors.ScrollBar;
            TextBoxTitle.Location = new Point(0, 17);
            TextBoxTitle.Margin = new Padding(0);
            TextBoxTitle.Name = "TextBoxTitle";
            TextBoxTitle.Size = new Size(465, 39);
            TextBoxTitle.TabIndex = 27;
            // 
            // ButtonDown
            // 
            ButtonDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonDown.BackColor = SystemColors.ControlLight;
            ButtonDown.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonDown.ForeColor = SystemColors.ControlText;
            ButtonDown.Location = new Point(880, 10);
            ButtonDown.Margin = new Padding(0, 5, 4, 5);
            ButtonDown.Name = "ButtonDown";
            ButtonDown.Size = new Size(41, 53);
            ButtonDown.TabIndex = 21;
            ButtonDown.Text = "↓";
            ButtonDown.UseVisualStyleBackColor = false;
            ButtonDown.Click += ButtonDown_Click;
            // 
            // ButtonUp
            // 
            ButtonUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUp.BackColor = SystemColors.ControlLight;
            ButtonUp.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUp.ForeColor = SystemColors.ControlText;
            ButtonUp.Location = new Point(834, 10);
            ButtonUp.Margin = new Padding(9, 5, 4, 5);
            ButtonUp.Name = "ButtonUp";
            ButtonUp.Size = new Size(41, 53);
            ButtonUp.TabIndex = 20;
            ButtonUp.Text = "↑";
            ButtonUp.UseVisualStyleBackColor = false;
            ButtonUp.Click += ButtonUp_Click;
            // 
            // PictureBox3
            // 
            PictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureBox3.Image = Properties.Resources.iconSearch;
            PictureBox3.Location = new Point(580, 17);
            PictureBox3.Margin = new Padding(13, 5, 4, 5);
            PictureBox3.Name = "PictureBox3";
            PictureBox3.Size = new Size(34, 40);
            PictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox3.TabIndex = 82;
            PictureBox3.TabStop = false;
            // 
            // PictureButtonTitle
            // 
            PictureButtonTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureButtonTitle.Image = Properties.Resources.iconWrite;
            PictureButtonTitle.InitialImage = Properties.Resources.iconWrite;
            PictureButtonTitle.Location = new Point(529, 17);
            PictureButtonTitle.Margin = new Padding(4, 5, 4, 5);
            PictureButtonTitle.Name = "PictureButtonTitle";
            PictureButtonTitle.Size = new Size(34, 40);
            PictureButtonTitle.SizeMode = PictureBoxSizeMode.Zoom;
            PictureButtonTitle.TabIndex = 81;
            PictureButtonTitle.TabStop = false;
            PictureButtonTitle.Click += PictureButtonTitle_ClickAsync;
            PictureButtonTitle.MouseEnter += PictureButton_MouseEnter;
            PictureButtonTitle.MouseLeave += PictureButton_MouseLeave;
            // 
            // PictureBox1
            // 
            PictureBox1.Image = Properties.Resources.iconChat;
            PictureBox1.Location = new Point(17, 17);
            PictureBox1.Margin = new Padding(4, 5, 4, 5);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(34, 40);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 78;
            PictureBox1.TabStop = false;
            PictureBox1.DoubleClick += ChatForm_DoubleClickAsync;
            // 
            // Form_Chat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 43, 55);
            ClientSize = new Size(939, 1143);
            Controls.Add(Panel3);
            Controls.Add(Panel2);
            Controls.Add(Panel1);
            Name = "Form_Chat";
            Text = "Chat";
            DockStateChanged += MyForm_DockStateChanged;
            FormClosing += PreviewForm_FormClosing;
            Load += ChatForm_Load;
            Shown += Form_Chat_Shown;
            SizeChanged += MyForm_SizeChanged;
            Panel1.ResumeLayout(false);
            TableLayoutPanel1.ResumeLayout(false);
            TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureButtonTag).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            Panel2.ResumeLayout(false);
            Panel3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureButtonTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
        }

        internal ScintillaNET.Scintilla ChatBox;
        internal Panel Panel1;
        internal Panel Panel2;
        internal Panel Panel3;
        internal PictureBox PictureBox1;
        internal PictureBox PictureBox2;
        internal PictureBox PictureButtonTitle;
        internal PictureBox PictureButtonTag;
        internal TableLayoutPanel TableLayoutPanel1;
        internal Button ButtonNewChat;
        internal PictureBox PictureBox3;
        internal Button ButtonUp;
        internal Button ButtonDown;
        internal TmCGPTD.TextBoxWithClearButton TextBoxChatTextSearch;
        internal TmCGPTD.TextBoxWithClearButton TextBoxTag3;
        internal TmCGPTD.TextBoxWithClearButton TextBoxTag2;
        internal TmCGPTD.TextBoxWithClearButton TextBoxTag1;
        internal TmCGPTD.TextBoxWithClearButton TextBoxTitle;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel2;
    }
}