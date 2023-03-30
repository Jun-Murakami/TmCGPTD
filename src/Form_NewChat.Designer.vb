<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_NewChat
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
        Label23 = New Label()
        TextBox1 = New TextBox()
        ButtonCancel = New Button()
        ButtonOK = New Button()
        SuspendLayout()
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label23.Location = New Point(19, 19)
        Label23.Margin = New Padding(10)
        Label23.Name = "Label23"
        Label23.Size = New Size(149, 19)
        Label23.TabIndex = 56
        Label23.Text = "Please enter the title."
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(19, 68)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(300, 29)
        TextBox1.TabIndex = 57
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonCancel.Location = New Point(175, 130)
        ButtonCancel.Margin = New Padding(0, 15, 15, 15)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(120, 40)
        ButtonCancel.TabIndex = 59
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonOK.Location = New Point(43, 130)
        ButtonOK.Margin = New Padding(15)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(120, 40)
        ButtonOK.TabIndex = 58
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' Form_NewChat
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(337, 196)
        Controls.Add(ButtonCancel)
        Controls.Add(ButtonOK)
        Controls.Add(TextBox1)
        Controls.Add(Label23)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form_NewChat"
        StartPosition = FormStartPosition.CenterParent
        Text = "New Chat"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
End Class
