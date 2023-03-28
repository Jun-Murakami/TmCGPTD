<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ChatLog
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBoxSearch = New TextBoxWithClearButton()
        ButtonCal = New Button()
        ButtonChatDelete = New Button()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        ComboBoxTag = New ComboBox()
        Panel2 = New Panel()
        DataGrid = New DataGridView()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(DataGrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(611, 47)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 6
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 29F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 29F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 31F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 71F))
        TableLayoutPanel1.Controls.Add(TextBoxSearch, 1, 0)
        TableLayoutPanel1.Controls.Add(ButtonCal, 4, 0)
        TableLayoutPanel1.Controls.Add(ButtonChatDelete, 5, 0)
        TableLayoutPanel1.Controls.Add(PictureBox2, 2, 0)
        TableLayoutPanel1.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(ComboBoxTag, 3, 0)
        TableLayoutPanel1.Location = New Point(9, 5)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(594, 35)
        TableLayoutPanel1.TabIndex = 78
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Dock = DockStyle.Fill
        TextBoxSearch.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxSearch.Location = New Point(31, 2)
        TextBoxSearch.Margin = New Padding(2, 2, 6, 2)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(209, 29)
        TextBoxSearch.TabIndex = 1
        ' 
        ' ButtonCal
        ' 
        ButtonCal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonCal.BackgroundImageLayout = ImageLayout.Center
        ButtonCal.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonCal.Location = New Point(492, 0)
        ButtonCal.Margin = New Padding(0)
        ButtonCal.Name = "ButtonCal"
        ButtonCal.Size = New Size(31, 35)
        ButtonCal.TabIndex = 78
        ButtonCal.UseVisualStyleBackColor = True
        ' 
        ' ButtonChatDelete
        ' 
        ButtonChatDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonChatDelete.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonChatDelete.Location = New Point(530, 0)
        ButtonChatDelete.Margin = New Padding(3, 0, 0, 0)
        ButtonChatDelete.Name = "ButtonChatDelete"
        ButtonChatDelete.Size = New Size(64, 35)
        ButtonChatDelete.TabIndex = 79
        ButtonChatDelete.Text = "Delete"
        ButtonChatDelete.UseVisualStyleBackColor = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.iconTag
        PictureBox2.InitialImage = My.Resources.Resources.iconTag
        PictureBox2.Location = New Point(249, 3)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 29)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 80
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.iconSearch
        PictureBox1.InitialImage = My.Resources.Resources.iconChat
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(23, 29)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 79
        PictureBox1.TabStop = False
        ' 
        ' ComboBoxTag
        ' 
        ComboBoxTag.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxTag.DrawMode = DrawMode.OwnerDrawFixed
        ComboBoxTag.FlatStyle = FlatStyle.Flat
        ComboBoxTag.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxTag.ForeColor = SystemColors.WindowText
        ComboBoxTag.FormattingEnabled = True
        ComboBoxTag.Location = New Point(277, 2)
        ComboBoxTag.Margin = New Padding(2, 2, 6, 2)
        ComboBoxTag.Name = "ComboBoxTag"
        ComboBoxTag.Size = New Size(209, 30)
        ComboBoxTag.TabIndex = 77
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.Controls.Add(DataGrid)
        Panel2.Location = New Point(0, 47)
        Panel2.Margin = New Padding(0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(611, 484)
        Panel2.TabIndex = 1
        ' 
        ' DataGrid
        ' 
        DataGrid.AllowUserToAddRows = False
        DataGrid.AllowUserToDeleteRows = False
        DataGrid.AllowUserToOrderColumns = True
        DataGrid.AllowUserToResizeRows = False
        DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGrid.BackgroundColor = Color.FromArgb(CByte(33), CByte(34), CByte(35))
        DataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        DataGridViewCellStyle1.Font = New Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = Color.Silver
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(33), CByte(34), CByte(35))
        DataGridViewCellStyle2.Font = New Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ScrollBar
        DataGridViewCellStyle2.Padding = New Padding(3, 10, 3, 10)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(68), CByte(70), CByte(84))
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGrid.DefaultCellStyle = DataGridViewCellStyle2
        DataGrid.Dock = DockStyle.Fill
        DataGrid.GridColor = SystemColors.ButtonShadow
        DataGrid.Location = New Point(0, 0)
        DataGrid.Margin = New Padding(0)
        DataGrid.Name = "DataGrid"
        DataGrid.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(96), CByte(96), CByte(96))
        DataGridViewCellStyle3.Font = New Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = Color.White
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGrid.RowHeadersVisible = False
        DataGrid.RowHeadersWidth = 40
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(33), CByte(34), CByte(35))
        DataGridViewCellStyle4.ForeColor = Color.Gainsboro
        DataGridViewCellStyle4.Padding = New Padding(3, 10, 3, 10)
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(68), CByte(70), CByte(84))
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGrid.RowsDefaultCellStyle = DataGridViewCellStyle4
        DataGrid.RowTemplate.Height = 33
        DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGrid.Size = New Size(611, 484)
        DataGrid.TabIndex = 0
        ' 
        ' Form_ChatLog
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(611, 535)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Name = "Form_ChatLog"
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Show
        Text = "Chat List"
        Panel1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        CType(DataGrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGrid As DataGridView
    Friend WithEvents ButtonChatDelete As Button
    Friend WithEvents ButtonCal As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ComboBoxTag As ComboBox
    Friend WithEvents TextBoxSearch As TextBoxWithClearButton
End Class
