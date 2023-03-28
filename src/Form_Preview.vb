Imports System.Windows.Forms
Imports System.Drawing
Imports WeifenLuo.WinFormsUI.Docking
Public Class Form_Preview
    Inherits DockContent

    Public Property MainFormInst As Form1
    Private Sub PreviewForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mainForm As Form1 = CType(Application.OpenForms.OfType(Of Form1).FirstOrDefault(), Form1)
        If Not mainForm.cts.Token.IsCancellationRequested Then
            Me.Hide() ' フォームを閉じるのではなく、非表示にする
            e.Cancel = True ' イベントをキャンセルし、フォームが閉じないようにする
        Else
            e.Cancel = False
        End If
    End Sub

    ' フォントサイズホイール処理--------------------------------------------------------------
    Private Sub TextOut_MouseWheel(sender As Object, e As MouseEventArgs) Handles TextOut.MouseWheel
        If Control.ModifierKeys = Keys.Control Then ' Ctrlキーが押されている場合
            Dim delta As Integer = e.Delta ' マウスホイールの回転量を取得
            Dim fontSizeChange As Integer = If(delta > 0, 1, -1) ' フォントサイズを増減させる量を決定（上回転なら＋1、下回転なら－1）
            If Not TextOut.Font.Size <= 1 Then
                ' フォントサイズを変更する
                TextOut.Font = New Font(TextOut.Font.FontFamily, TextOut.Font.Size + fontSizeChange)
            End If
        End If
    End Sub

End Class