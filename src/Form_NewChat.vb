Imports System
Imports System.Linq
Imports System.Windows.Forms

Namespace TmCGPTD
    Public Partial Class Form_NewChat
        Public ReadOnly Property EnteredText As String
            Get
                Return TextBox1.Text
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub ButtonOK_Click(ByVal sender As Object, ByVal e As EventArgs)
            DialogResult = DialogResult.OK
            Close()
        End Sub

        Private Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            DialogResult = DialogResult.Cancel
            Close()
        End Sub

        Private Sub Form_NewChat_Shown(ByVal sender As Object, ByVal e As EventArgs)
            KeyPreview = True ' KeyPreview プロパティを True に設定
        End Sub

        Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Return Then
                Dim controlStr = Controls.Find($"ButtonOK", True)
                Dim buttonStr As Button = TryCast(controlStr.FirstOrDefault(), Button) ' ボタンを取得
                buttonStr.PerformClick()
            End If
        End Sub
    End Class
End Namespace
