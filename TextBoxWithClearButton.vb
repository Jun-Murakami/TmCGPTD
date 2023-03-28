Imports System.Windows.Forms
Imports System.Drawing

Public Class TextBoxWithClearButton
    Inherits TextBox

    Private WithEvents _clearButton As New Button()

    Public Sub New()
        MyBase.New()

        ' Clear button settings
        _clearButton.Size = New Size(20, Me.ClientSize.Height - 4)
        _clearButton.Location = New Point(Me.ClientSize.Width - _clearButton.Width - 1, +2)
        _clearButton.Cursor = Cursors.Default
        _clearButton.Text = "x"
        _clearButton.FlatStyle = FlatStyle.Flat ' この行を追加
        _clearButton.FlatAppearance.BorderSize = 0 ' この行を追加
        _clearButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        _clearButton.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold)
        _clearButton.Visible = False
        Me.Controls.Add(_clearButton)
    End Sub

    Private Sub _clearButton_Click(sender As Object, e As EventArgs) Handles _clearButton.Click
        Me.Text = String.Empty
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        _clearButton.Visible = Me.Text.Length > 0
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        _clearButton.Size = New Size(20, Me.ClientSize.Height - 4)
        _clearButton.Location = New Point(Me.ClientSize.Width - _clearButton.Width - 1, +2)
    End Sub
End Class
