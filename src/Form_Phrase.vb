Imports WeifenLuo.WinFormsUI.Docking
Imports TmCGPTD.Form1
Imports TmCGPTD.Form_Input
Imports TmCGPTD.Form_Preview
Imports TmCGPTD.Form_Chat
Imports ScintillaNET

Public Class Form_Phrase
    Inherits DockContent
    Public Property MainFormInst As Form1
    Private Sub PhraseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mainForm As Form1 = CType(Application.OpenForms.OfType(Of Form1).FirstOrDefault(), Form1)
        If Not mainForm.cts.Token.IsCancellationRequested Then
            Me.Hide() ' フォームを閉じるのではなく、非表示にする
            e.Cancel = True ' イベントをキャンセルし、フォームが閉じないようにする
        Else
            e.Cancel = False
        End If
    End Sub

    ' 定型句ボタンクリック--------------------------------------------------------------
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click

        ' クリックされたボタンのテキスト値を取得する
        Dim button As Button = CType(sender, Button)
        Dim textBoxName As String = "TextBox" & button.Text

        ' 該当するテキストボックスが存在するかチェックする
        Dim controlStr() As Control = Me.Controls.Find(textBoxName, True)
        If controlStr.Length > 0 AndAlso TypeOf controlStr(0) Is TextBox Then
            Dim textBoxStr As TextBox = CType(controlStr(0), TextBox)
            ' テキストボックスのテキストが空でなければ挿入する
            If Not String.IsNullOrEmpty(textBoxStr.Text) Then

                targetScintilla.Focus()
                targetScintilla.SelectionStart = targetCursorPositionStart
                targetScintilla.SelectionEnd = targetCursorPositionEnd
                scintillaPick = False
                targetScintilla.ReplaceSelection(textBoxStr.Text)
                targetCursorPositionStart = targetScintilla.SelectionStart + textBoxStr.Text.Length
                targetCursorPositionEnd = targetCursorPositionStart
                scintillaPick = True
                'targetScintilla.Focus()
            End If
        End If
    End Sub

End Class