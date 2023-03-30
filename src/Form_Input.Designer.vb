Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Input
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TableLayoutPanel2 = New TableLayoutPanel()
        TextInput5 = New ScintillaNET.Scintilla()
        TextInput3 = New ScintillaNET.Scintilla()
        TextInput4 = New ScintillaNET.Scintilla()
        TextInput2 = New ScintillaNET.Scintilla()
        TextInput1 = New ScintillaNET.Scintilla()
        ComboBoxSearch = New CustomComboBox()
        ButtonPrev = New Button()
        ButtonNext = New Button()
        ButtonRecentLog = New Button()
        ButtonDelete = New Button()
        Label1 = New Label()
        ButtonClear1 = New Button()
        ButtonClear2 = New Button()
        ButtonClear3 = New Button()
        ButtonClear4 = New Button()
        ButtonClear5 = New Button()
        ButtonClearAll = New Button()
        ButtonPost = New Button()
        Label3 = New Label()
        ButtonSave = New Button()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(TextInput5, 0, 4)
        TableLayoutPanel2.Controls.Add(TextInput3, 0, 2)
        TableLayoutPanel2.Controls.Add(TextInput4, 0, 3)
        TableLayoutPanel2.Controls.Add(TextInput2, 0, 1)
        TableLayoutPanel2.Controls.Add(TextInput1, 0, 0)
        TableLayoutPanel2.Location = New Point(0, 44)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 5
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 89F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 67F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(558, 317)
        TableLayoutPanel2.TabIndex = 51
        ' 
        ' TextInput5
        ' 
        TextInput5.AutoCCancelAtStart = False
        TextInput5.AutoCMaxHeight = 9
        TextInput5.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        TextInput5.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        TextInput5.CaretForeColor = Color.White
        TextInput5.CaretLineBackColor = Color.FromArgb(CByte(32), CByte(33), CByte(45))
        TextInput5.CaretLineVisible = True
        TextInput5.Dock = DockStyle.Fill
        TextInput5.Font = New Font("Migu 1M", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        TextInput5.LexerName = Nothing
        TextInput5.Location = New Point(0, 249)
        TextInput5.Margin = New Padding(0)
        TextInput5.Margins.Left = 5
        TextInput5.Margins.Right = 10
        TextInput5.Name = "TextInput5"
        TextInput5.ScrollWidth = 110
        TextInput5.Size = New Size(558, 68)
        TextInput5.TabIndents = True
        TextInput5.TabIndex = 5
        TextInput5.TabStop = False
        TextInput5.UseRightToLeftReadingLayout = False
        TextInput5.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' TextInput3
        ' 
        TextInput3.AutoCCancelAtStart = False
        TextInput3.AutoCMaxHeight = 9
        TextInput3.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        TextInput3.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        TextInput3.CaretForeColor = Color.White
        TextInput3.CaretLineBackColor = Color.FromArgb(CByte(32), CByte(33), CByte(45))
        TextInput3.CaretLineVisible = True
        TextInput3.Dock = DockStyle.Fill
        TextInput3.Font = New Font("Migu 1M", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        TextInput3.LexerName = Nothing
        TextInput3.Location = New Point(0, 153)
        TextInput3.Margin = New Padding(0)
        TextInput3.Margins.Left = 5
        TextInput3.Margins.Right = 10
        TextInput3.Name = "TextInput3"
        TextInput3.ScrollWidth = 110
        TextInput3.Size = New Size(558, 32)
        TextInput3.TabIndents = True
        TextInput3.TabIndex = 3
        TextInput3.TabStop = False
        TextInput3.UseRightToLeftReadingLayout = False
        TextInput3.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' TextInput4
        ' 
        TextInput4.AutoCCancelAtStart = False
        TextInput4.AutoCMaxHeight = 9
        TextInput4.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        TextInput4.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        TextInput4.CaretForeColor = Color.White
        TextInput4.CaretLineBackColor = Color.FromArgb(CByte(32), CByte(33), CByte(45))
        TextInput4.CaretLineVisible = True
        TextInput4.Dock = DockStyle.Fill
        TextInput4.Font = New Font("Migu 1M", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        TextInput4.IndentationGuides = ScintillaNET.IndentView.LookBoth
        TextInput4.LexerName = Nothing
        TextInput4.Location = New Point(0, 185)
        TextInput4.Margin = New Padding(0)
        TextInput4.Margins.Left = 5
        TextInput4.Margins.Right = 10
        TextInput4.Name = "TextInput4"
        TextInput4.ScrollWidth = 110
        TextInput4.Size = New Size(558, 64)
        TextInput4.TabIndents = True
        TextInput4.TabIndex = 4
        TextInput4.TabStop = False
        TextInput4.UseRightToLeftReadingLayout = False
        TextInput4.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways
        TextInput4.WhitespaceSize = 2
        TextInput4.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' TextInput2
        ' 
        TextInput2.AutoCCancelAtStart = False
        TextInput2.AutoCMaxHeight = 9
        TextInput2.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        TextInput2.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        TextInput2.CaretForeColor = Color.White
        TextInput2.CaretLineBackColor = Color.FromArgb(CByte(32), CByte(33), CByte(45))
        TextInput2.CaretLineVisible = True
        TextInput2.Dock = DockStyle.Fill
        TextInput2.Font = New Font("Migu 1M", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        TextInput2.IndentationGuides = ScintillaNET.IndentView.LookBoth
        TextInput2.LexerName = Nothing
        TextInput2.Location = New Point(0, 89)
        TextInput2.Margin = New Padding(0)
        TextInput2.Margins.Left = 5
        TextInput2.Margins.Right = 10
        TextInput2.Name = "TextInput2"
        TextInput2.ScrollWidth = 110
        TextInput2.Size = New Size(558, 64)
        TextInput2.TabIndents = True
        TextInput2.TabIndex = 2
        TextInput2.TabStop = False
        TextInput2.UseRightToLeftReadingLayout = False
        TextInput2.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways
        TextInput2.WhitespaceSize = 2
        TextInput2.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' TextInput1
        ' 
        TextInput1.AutoCCancelAtStart = False
        TextInput1.AutoCMaxHeight = 9
        TextInput1.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled
        TextInput1.BorderStyle = ScintillaNET.BorderStyle.FixedSingle
        TextInput1.CaretForeColor = Color.White
        TextInput1.CaretLineBackColor = Color.FromArgb(CByte(32), CByte(33), CByte(45))
        TextInput1.CaretLineVisible = True
        TextInput1.Dock = DockStyle.Fill
        TextInput1.EdgeColor = Color.FromArgb(CByte(96), CByte(96), CByte(96))
        TextInput1.Font = New Font("Migu 1M", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        TextInput1.LexerName = Nothing
        TextInput1.Location = New Point(0, 0)
        TextInput1.Margin = New Padding(0)
        TextInput1.Margins.Left = 5
        TextInput1.Margins.Right = 10
        TextInput1.Name = "TextInput1"
        TextInput1.ScrollWidth = 110
        TextInput1.Size = New Size(558, 89)
        TextInput1.TabIndents = True
        TextInput1.TabIndex = 1
        TextInput1.TabStop = False
        TextInput1.UseRightToLeftReadingLayout = False
        TextInput1.WrapMode = ScintillaNET.WrapMode.None
        ' 
        ' ComboBoxSearch
        ' 
        ComboBoxSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxSearch.DrawMode = DrawMode.OwnerDrawFixed
        ComboBoxSearch.FlatStyle = FlatStyle.Flat
        ComboBoxSearch.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxSearch.FormattingEnabled = True
        ComboBoxSearch.Location = New Point(56, 8)
        ComboBoxSearch.Margin = New Padding(0)
        ComboBoxSearch.Name = "ComboBoxSearch"
        ComboBoxSearch.Size = New Size(283, 30)
        ComboBoxSearch.TabIndex = 14
        ComboBoxSearch.Text = "Type text here and press Enter to search Editor log."
        ' 
        ' ButtonPrev
        ' 
        ButtonPrev.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonPrev.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonPrev.Location = New Point(345, 6)
        ButtonPrev.Margin = New Padding(6, 3, 3, 3)
        ButtonPrev.Name = "ButtonPrev"
        ButtonPrev.Size = New Size(29, 32)
        ButtonPrev.TabIndex = 15
        ButtonPrev.Text = "<"
        ButtonPrev.UseVisualStyleBackColor = True
        ' 
        ' ButtonNext
        ' 
        ButtonNext.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonNext.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonNext.Location = New Point(377, 6)
        ButtonNext.Margin = New Padding(0, 3, 3, 3)
        ButtonNext.Name = "ButtonNext"
        ButtonNext.Size = New Size(29, 32)
        ButtonNext.TabIndex = 16
        ButtonNext.Text = ">"
        ButtonNext.UseVisualStyleBackColor = True
        ' 
        ' ButtonRecentLog
        ' 
        ButtonRecentLog.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonRecentLog.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonRecentLog.Location = New Point(414, 6)
        ButtonRecentLog.Margin = New Padding(5, 3, 3, 3)
        ButtonRecentLog.Name = "ButtonRecentLog"
        ButtonRecentLog.Size = New Size(64, 32)
        ButtonRecentLog.TabIndex = 17
        ButtonRecentLog.Text = "Recent"
        ButtonRecentLog.UseVisualStyleBackColor = True
        ' 
        ' ButtonDelete
        ' 
        ButtonDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonDelete.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonDelete.Location = New Point(484, 6)
        ButtonDelete.Name = "ButtonDelete"
        ButtonDelete.Size = New Size(64, 32)
        ButtonDelete.TabIndex = 18
        ButtonDelete.Text = "Delete"
        ButtonDelete.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(9, 376)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 19)
        Label1.TabIndex = 73
        Label1.Text = "Clear:"
        Label1.TextAlign = ContentAlignment.TopRight
        ' 
        ' ButtonClear1
        ' 
        ButtonClear1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClear1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear1.Location = New Point(62, 369)
        ButtonClear1.Name = "ButtonClear1"
        ButtonClear1.Size = New Size(40, 32)
        ButtonClear1.TabIndex = 6
        ButtonClear1.Text = "1"
        ButtonClear1.UseVisualStyleBackColor = True
        ' 
        ' ButtonClear2
        ' 
        ButtonClear2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClear2.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear2.Location = New Point(108, 369)
        ButtonClear2.Name = "ButtonClear2"
        ButtonClear2.Size = New Size(40, 32)
        ButtonClear2.TabIndex = 7
        ButtonClear2.Text = "2"
        ButtonClear2.UseVisualStyleBackColor = True
        ' 
        ' ButtonClear3
        ' 
        ButtonClear3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClear3.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear3.Location = New Point(154, 369)
        ButtonClear3.Name = "ButtonClear3"
        ButtonClear3.Size = New Size(40, 32)
        ButtonClear3.TabIndex = 8
        ButtonClear3.Text = "3"
        ButtonClear3.UseVisualStyleBackColor = True
        ' 
        ' ButtonClear4
        ' 
        ButtonClear4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClear4.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear4.Location = New Point(200, 369)
        ButtonClear4.Name = "ButtonClear4"
        ButtonClear4.Size = New Size(40, 32)
        ButtonClear4.TabIndex = 9
        ButtonClear4.Text = "4"
        ButtonClear4.UseVisualStyleBackColor = True
        ' 
        ' ButtonClear5
        ' 
        ButtonClear5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClear5.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear5.Location = New Point(246, 369)
        ButtonClear5.Name = "ButtonClear5"
        ButtonClear5.Size = New Size(40, 32)
        ButtonClear5.TabIndex = 10
        ButtonClear5.Text = "5"
        ButtonClear5.UseVisualStyleBackColor = True
        ' 
        ' ButtonClearAll
        ' 
        ButtonClearAll.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonClearAll.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClearAll.Location = New Point(292, 369)
        ButtonClearAll.Name = "ButtonClearAll"
        ButtonClearAll.Size = New Size(80, 32)
        ButtonClearAll.TabIndex = 11
        ButtonClearAll.Text = "All clear"
        ButtonClearAll.UseVisualStyleBackColor = True
        ' 
        ' ButtonPost
        ' 
        ButtonPost.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonPost.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonPost.Image = My.Resources.Resources.iconWriteBlack
        ButtonPost.ImageAlign = ContentAlignment.MiddleRight
        ButtonPost.Location = New Point(445, 365)
        ButtonPost.Name = "ButtonPost"
        ButtonPost.Size = New Size(100, 40)
        ButtonPost.TabIndex = 13
        ButtonPost.Text = "Post"
        ButtonPost.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlText
        Label3.Location = New Point(12, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 19)
        Label3.TabIndex = 78
        Label3.Text = "Log:"
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonSave.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonSave.Location = New Point(377, 369)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(62, 32)
        ButtonSave.TabIndex = 12
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' Form_Input
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(557, 411)
        Controls.Add(ButtonSave)
        Controls.Add(Label3)
        Controls.Add(ButtonPost)
        Controls.Add(ButtonClear4)
        Controls.Add(ButtonClear3)
        Controls.Add(ButtonClearAll)
        Controls.Add(ButtonClear5)
        Controls.Add(ButtonClear2)
        Controls.Add(Label1)
        Controls.Add(ButtonClear1)
        Controls.Add(ButtonRecentLog)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(ComboBoxSearch)
        Controls.Add(ButtonPrev)
        Controls.Add(ButtonNext)
        Controls.Add(ButtonDelete)
        MinimumSize = New Size(573, 393)
        Name = "Form_Input"
        Text = "Editor"
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextInput1 As ScintillaNET.Scintilla
    Friend WithEvents TextInput2 As ScintillaNET.Scintilla
    Friend WithEvents TextInput3 As ScintillaNET.Scintilla
    Friend WithEvents TextInput4 As ScintillaNET.Scintilla
    Friend WithEvents TextInput5 As ScintillaNET.Scintilla
    Friend WithEvents ComboBoxSearch As CustomComboBox
    Friend WithEvents ButtonPrev As Button
    Friend WithEvents ButtonNext As Button
    Friend WithEvents ButtonRecentLog As Button
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonClear1 As Button
    Friend WithEvents ButtonClear2 As Button
    Friend WithEvents ButtonClear3 As Button
    Friend WithEvents ButtonClear4 As Button
    Friend WithEvents ButtonClear5 As Button
    Friend WithEvents ButtonClearAll As Button
    Friend WithEvents ButtonPost As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonSave As Button
End Class
