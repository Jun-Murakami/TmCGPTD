<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_DateRange
    Inherits System.Windows.Forms.Form

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
        ButtonOK = New Button()
        ButtonClear = New Button()
        Label3 = New Label()
        Label1 = New Label()
        DateTimePicker1 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        SuspendLayout()
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonOK.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonOK.Location = New Point(44, 132)
        ButtonOK.Margin = New Padding(3, 6, 3, 3)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(83, 32)
        ButtonOK.TabIndex = 78
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonClear
        ' 
        ButtonClear.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonClear.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClear.Location = New Point(133, 132)
        ButtonClear.Margin = New Padding(3, 6, 0, 3)
        ButtonClear.Name = "ButtonClear"
        ButtonClear.Size = New Size(83, 32)
        ButtonClear.TabIndex = 79
        ButtonClear.Text = "Clear"
        ButtonClear.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlText
        Label3.Location = New Point(12, 12)
        Label3.Margin = New Padding(3)
        Label3.Name = "Label3"
        Label3.Size = New Size(130, 19)
        Label3.TabIndex = 80
        Label3.Text = "Search Start Date :"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(12, 72)
        Label1.Margin = New Padding(3, 9, 3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(130, 19)
        Label1.TabIndex = 81
        Label1.Text = "Search End Date :"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(16, 37)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 82
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Location = New Point(16, 97)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(200, 23)
        DateTimePicker2.TabIndex = 83
        ' 
        ' Form_DateRange
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(230, 176)
        Controls.Add(DateTimePicker2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label1)
        Controls.Add(Label3)
        Controls.Add(ButtonClear)
        Controls.Add(ButtonOK)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form_DateRange"
        StartPosition = FormStartPosition.Manual
        Text = "Date Range"
        ResumeLayout(False)
    End Sub

    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents MonthCalendar2 As MonthCalendar
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonClear As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
End Class
