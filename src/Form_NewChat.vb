Public Class Form_NewChat
    Public ReadOnly Property EnteredText As String
        Get
            Return TextBox1.Text
        End Get
    End Property

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Form_NewChat_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.KeyPreview = True ' KeyPreview プロパティを True に設定
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim controlStr = Me.Controls.Find($"ButtonOK", True)
            Dim buttonStr = TryCast(controlStr.FirstOrDefault(), Button) ' ボタンを取得
            buttonStr.PerformClick()
        End If
    End Sub
End Class