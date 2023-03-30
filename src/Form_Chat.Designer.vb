<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Chat
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ChatBox = New ScintillaNET.Scintilla()
        Panel1 = New Panel()
        ButtonNewChat = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBoxTag3 = New TextBoxWithClearButton()
        TextBoxTag2 = New TextBoxWithClearButton()
        TextBoxTag1 = New TextBoxWithClearButton()
        PictureButtonTag = New PictureBox()
        PictureBox2 = New PictureBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        TextBoxTitle = New TextBox()
        TextBoxChatTextSearch = New TextBoxWithClearButton()
        ButtonDown = New Button()
        ButtonUp = New Button()
        PictureBox3 = New PictureBox()
        PictureButtonTitle = New PictureBox()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureButtonTag, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureButtonTitle, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ChatBox
        ' 
        ChatBox.AutoCMaxHeight = 9
        ChatBox.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        ChatBox.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        ChatBox.CaretForeColor = Color.White
        ChatBox.CaretLineBackColor = Color.Black
        ChatBox.CaretLineBackColorAlpha = 0
        ChatBox.CaretLineLayer = ScintillaNET.Layer.UnderText
        ChatBox.CaretLineVisible = True
        ChatBox.Dock = DockStyle.Fill
        ChatBox.Font = New Font("Migu 1M", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ChatBox.LexerName = Nothing
        ChatBox.Location = New Point(0, 0)
        ChatBox.Margin = New Padding(0)
        ChatBox.Margins.Left = 10
        ChatBox.Margins.Right = 10
        ChatBox.Name = "ChatBox"
        ChatBox.ScrollWidth = 75
        ChatBox.Size = New Size(657, 592)
        ChatBox.TabIndents = True
        ChatBox.TabIndex = 22
        ChatBox.UseRightToLeftReadingLayout = False
        ChatBox.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways
        ChatBox.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(ButtonNewChat)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Controls.Add(PictureButtonTag)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Location = New Point(0, 636)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(657, 50)
        Panel1.TabIndex = 1
        ' 
        ' ButtonNewChat
        ' 
        ButtonNewChat.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonNewChat.BackColor = SystemColors.ControlLight
        ButtonNewChat.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonNewChat.Image = My.Resources.Resources.iconWriteBlack
        ButtonNewChat.ImageAlign = ContentAlignment.MiddleRight
        ButtonNewChat.Location = New Point(520, 4)
        ButtonNewChat.Name = "ButtonNewChat"
        ButtonNewChat.Size = New Size(125, 40)
        ButtonNewChat.TabIndex = 26
        ButtonNewChat.Text = "New Chat"
        ButtonNewChat.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(TextBoxTag3, 2, 0)
        TableLayoutPanel1.Controls.Add(TextBoxTag2, 1, 0)
        TableLayoutPanel1.Controls.Add(TextBoxTag1, 0, 0)
        TableLayoutPanel1.Location = New Point(42, 10)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(430, 32)
        TableLayoutPanel1.TabIndex = 83
        ' 
        ' TextBoxTag3
        ' 
        TextBoxTag3.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextBoxTag3.BorderStyle = BorderStyle.FixedSingle
        TextBoxTag3.Dock = DockStyle.Fill
        TextBoxTag3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxTag3.ForeColor = SystemColors.ScrollBar
        TextBoxTag3.Location = New Point(286, 0)
        TextBoxTag3.Margin = New Padding(0)
        TextBoxTag3.Name = "TextBoxTag3"
        TextBoxTag3.Size = New Size(144, 29)
        TextBoxTag3.TabIndex = 25
        ' 
        ' TextBoxTag2
        ' 
        TextBoxTag2.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextBoxTag2.BorderStyle = BorderStyle.FixedSingle
        TextBoxTag2.Dock = DockStyle.Fill
        TextBoxTag2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxTag2.ForeColor = SystemColors.ScrollBar
        TextBoxTag2.Location = New Point(143, 0)
        TextBoxTag2.Margin = New Padding(0)
        TextBoxTag2.Name = "TextBoxTag2"
        TextBoxTag2.Size = New Size(143, 29)
        TextBoxTag2.TabIndex = 24
        ' 
        ' TextBoxTag1
        ' 
        TextBoxTag1.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextBoxTag1.BorderStyle = BorderStyle.FixedSingle
        TextBoxTag1.Dock = DockStyle.Fill
        TextBoxTag1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxTag1.ForeColor = SystemColors.ScrollBar
        TextBoxTag1.Location = New Point(3, 0)
        TextBoxTag1.Margin = New Padding(3, 0, 0, 0)
        TextBoxTag1.Name = "TextBoxTag1"
        TextBoxTag1.Size = New Size(140, 29)
        TextBoxTag1.TabIndex = 23
        ' 
        ' PictureButtonTag
        ' 
        PictureButtonTag.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureButtonTag.Image = My.Resources.Resources.iconWrite
        PictureButtonTag.InitialImage = My.Resources.Resources.iconWrite
        PictureButtonTag.Location = New Point(478, 12)
        PictureButtonTag.Margin = New Padding(3, 3, 9, 3)
        PictureButtonTag.Name = "PictureButtonTag"
        PictureButtonTag.Size = New Size(24, 24)
        PictureButtonTag.SizeMode = PictureBoxSizeMode.Zoom
        PictureButtonTag.TabIndex = 82
        PictureButtonTag.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        PictureBox2.Image = My.Resources.Resources.iconTag
        PictureBox2.Location = New Point(12, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(24, 24)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 79
        PictureBox2.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.Controls.Add(ChatBox)
        Panel2.Location = New Point(0, 44)
        Panel2.Margin = New Padding(0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(657, 592)
        Panel2.TabIndex = 2
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel3.Controls.Add(TextBoxTitle)
        Panel3.Controls.Add(TextBoxChatTextSearch)
        Panel3.Controls.Add(ButtonDown)
        Panel3.Controls.Add(ButtonUp)
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(PictureButtonTitle)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Location = New Point(0, 0)
        Panel3.Margin = New Padding(0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(657, 44)
        Panel3.TabIndex = 3
        ' 
        ' TextBoxTitle
        ' 
        TextBoxTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBoxTitle.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextBoxTitle.BorderStyle = BorderStyle.FixedSingle
        TextBoxTitle.Font = New Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxTitle.ForeColor = SystemColors.ScrollBar
        TextBoxTitle.Location = New Point(45, 8)
        TextBoxTitle.Margin = New Padding(2, 2, 3, 2)
        TextBoxTitle.Name = "TextBoxTitle"
        TextBoxTitle.Size = New Size(263, 29)
        TextBoxTitle.TabIndex = 27
        ' 
        ' TextBoxChatTextSearch
        ' 
        TextBoxChatTextSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxChatTextSearch.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextBoxChatTextSearch.BorderStyle = BorderStyle.FixedSingle
        TextBoxChatTextSearch.Font = New Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxChatTextSearch.ForeColor = SystemColors.ScrollBar
        TextBoxChatTextSearch.Location = New Point(391, 8)
        TextBoxChatTextSearch.Margin = New Padding(2, 2, 3, 2)
        TextBoxChatTextSearch.Name = "TextBoxChatTextSearch"
        TextBoxChatTextSearch.Size = New Size(184, 29)
        TextBoxChatTextSearch.TabIndex = 19
        ' 
        ' ButtonDown
        ' 
        ButtonDown.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonDown.BackColor = SystemColors.ControlLight
        ButtonDown.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonDown.ForeColor = SystemColors.ControlText
        ButtonDown.Location = New Point(616, 6)
        ButtonDown.Margin = New Padding(0, 3, 3, 3)
        ButtonDown.Name = "ButtonDown"
        ButtonDown.Size = New Size(29, 32)
        ButtonDown.TabIndex = 21
        ButtonDown.Text = "↓"
        ButtonDown.UseVisualStyleBackColor = False
        ' 
        ' ButtonUp
        ' 
        ButtonUp.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonUp.BackColor = SystemColors.ControlLight
        ButtonUp.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonUp.ForeColor = SystemColors.ControlText
        ButtonUp.Location = New Point(584, 6)
        ButtonUp.Margin = New Padding(6, 3, 3, 3)
        ButtonUp.Name = "ButtonUp"
        ButtonUp.Size = New Size(29, 32)
        ButtonUp.TabIndex = 20
        ButtonUp.Text = "↑"
        ButtonUp.UseVisualStyleBackColor = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox3.Image = My.Resources.Resources.iconSearch
        PictureBox3.Location = New Point(356, 10)
        PictureBox3.Margin = New Padding(9, 3, 3, 3)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(24, 24)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 82
        PictureBox3.TabStop = False
        ' 
        ' PictureButtonTitle
        ' 
        PictureButtonTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureButtonTitle.Image = My.Resources.Resources.iconWrite
        PictureButtonTitle.InitialImage = My.Resources.Resources.iconWrite
        PictureButtonTitle.Location = New Point(314, 10)
        PictureButtonTitle.Name = "PictureButtonTitle"
        PictureButtonTitle.Size = New Size(24, 24)
        PictureButtonTitle.SizeMode = PictureBoxSizeMode.Zoom
        PictureButtonTitle.TabIndex = 81
        PictureButtonTitle.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.iconChat
        PictureBox1.Location = New Point(12, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 78
        PictureBox1.TabStop = False
        ' 
        ' Form_Chat
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        ClientSize = New Size(657, 686)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Name = "Form_Chat"
        Text = "Chat"
        Panel1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureButtonTag, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureButtonTitle, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents ChatBox As ScintillaNET.Scintilla
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureButtonTitle As PictureBox
    Friend WithEvents PictureButtonTag As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonNewChat As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ButtonUp As Button
    Friend WithEvents ButtonDown As Button
    Friend WithEvents TextBoxChatTextSearch As TextBoxWithClearButton
    Friend WithEvents TextBoxTag3 As TextBoxWithClearButton
    Friend WithEvents TextBoxTag2 As TextBoxWithClearButton
    Friend WithEvents TextBoxTag1 As TextBoxWithClearButton
    Friend WithEvents TextBoxTitle As TextBox
End Class
