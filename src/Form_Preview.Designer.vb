Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Preview
    Inherits DockContent

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
        TextOut = New TextBox()
        SuspendLayout()
        ' 
        ' TextOut
        ' 
        TextOut.BackColor = SystemColors.Control
        TextOut.Dock = DockStyle.Fill
        TextOut.Font = New Font("Migu 1M", 8F, FontStyle.Regular, GraphicsUnit.Point)
        TextOut.ForeColor = Color.FromArgb(CByte(42), CByte(43), CByte(55))
        TextOut.Location = New Point(0, 0)
        TextOut.Margin = New Padding(0)
        TextOut.Multiline = True
        TextOut.Name = "TextOut"
        TextOut.ReadOnly = True
        TextOut.ScrollBars = ScrollBars.Both
        TextOut.Size = New Size(800, 450)
        TextOut.TabIndex = 68
        TextOut.WordWrap = False
        ' 
        ' Form_Preview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TextOut)
        Name = "Form_Preview"
        Text = "Preview"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextOut As TextBox
    Friend WithEvents CustomTextBox1 As System.CodeDom.CodeTypeReference
End Class
