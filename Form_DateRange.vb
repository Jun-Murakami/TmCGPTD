Public Class Form_DateRange
    Public ReadOnly Property StartDatePicker As DateTimePicker
        Get
            Return DateTimePicker1
        End Get
    End Property

    Public ReadOnly Property EndDatePicker As DateTimePicker
        Get
            Return DateTimePicker2
        End Get
    End Property

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ' OKボタンがクリックされたら、DialogResultをOKに設定し、フォームを閉じる
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        ' キャンセルボタンがクリックされたら、DialogResultをキャンセルに設定し、フォームを閉じる
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Form_DateRange_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub


End Class