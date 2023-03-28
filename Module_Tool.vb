Imports System.Drawing
Imports WeifenLuo.WinFormsUI.Docking
Imports System.Reflection
Imports WeifenLuo.WinFormsUI.ThemeVS2015

Partial Public Class Form1
    ' ボタン色変更--------------------------------------------------------------
    Private Sub ChangeControlColor()
        For Each frm As Form In Application.OpenForms
            If Not frm.Name = "Form1" Then
                frm.BackColor = Color.FromArgb(53, 55, 64)
                frm.ForeColor = Color.FromArgb(220, 220, 220)
            End If
            ChangeButtonColorsInContainer(frm)
        Next
    End Sub

    Private Sub ChangeButtonColorsInContainer(container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is Panel Then
                Dim pnl As Panel = DirectCast(ctrl, Panel)
                pnl.BackColor = Color.FromArgb(53, 55, 64)
                pnl.ForeColor = Color.FromArgb(220, 220, 220)
            End If
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.BackColor = Color.FromArgb(53, 55, 64)
                btn.ForeColor = Color.FromArgb(255, 255, 255)
                btn.FlatAppearance.BorderColor = Color.FromArgb(106, 108, 125)
                btn.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(84, 85, 99)
                btn.FlatStyle = FlatStyle.Flat
                ' イベントハンドラの追加
                AddHandler btn.MouseEnter, AddressOf Button_MouseEnter
                AddHandler btn.MouseLeave, AddressOf Button_MouseLeave
            ElseIf TypeOf ctrl Is Label Then
                Dim Lbl As Label = DirectCast(ctrl, Label)
                Lbl.BackColor = Color.FromArgb(53, 55, 64)
                Lbl.ForeColor = Color.FromArgb(220, 220, 220)
                Lbl.BorderStyle = BorderStyle.None
            ElseIf TypeOf ctrl Is TextBox Then
                Dim tbx As TextBox = DirectCast(ctrl, TextBox)
                tbx.BackColor = Color.FromArgb(53, 55, 64)
                tbx.ForeColor = Color.FromArgb(220, 220, 220)
                tbx.BorderStyle = BorderStyle.FixedSingle
            ElseIf TypeOf ctrl Is ComboBox Then
                Dim cbx As ComboBox = DirectCast(ctrl, ComboBox)
                cbx.BackColor = Color.FromArgb(53, 55, 64)
                cbx.ForeColor = Color.FromArgb(220, 220, 220)
                If cbx.Name = "ComboBoxSearch" Then cbx.ForeColor = Color.FromArgb(160, 160, 160)
            ElseIf ctrl.HasChildren Then
                ChangeButtonColorsInContainer(ctrl)
            End If
        Next

        chatLogForm.ComboBoxTag.DrawMode = DrawMode.OwnerDrawFixed
        inputForm.ComboBoxSearch.DrawMode = DrawMode.OwnerDrawFixed
    End Sub
    Private Sub Button_MouseEnter(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If Not btn.BackColor = Color.FromArgb(146, 148, 165) Then
            btn.BackColor = Color.FromArgb(164, 165, 179) ' 任意のマウスオーバー時の背景色
        End If
    End Sub
    Private Sub Button_MouseLeave(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If Not btn.BackColor = Color.FromArgb(146, 148, 165) Then
            btn.BackColor = Color.FromArgb(53, 55, 64) ' 元の背景色に戻す
        End If
    End Sub

    ' 画像の高dpi対応--------------------------------------------------------------
    Sub SetPictureBoxImage(imageFileName As String, pictureBox As PictureBox)
        Dim assembly As Assembly = Assembly.GetExecutingAssembly() ' 埋め込みリソースから画像を読み込む
        Dim originalImage As Image = Image.FromStream(assembly.GetManifestResourceStream(imageFileName)) ' 元の画像を読み込む
        Dim designSize As New Size(pictureBox.Width, pictureBox.Height) ' PictureBoxのデザイン時のサイズを取得
        pictureBox.Image = GetResizedImageForDpi(originalImage, designSize) ' PictureBoxのImageプロパティにリサイズされた画像を設定
    End Sub

    Public Function GetResizedImageForDpi(originalImage As Image, designSize As Size) As Image
        ' DPIスケーリングを取得
        Dim dpiScaling As Single = GetDpiScaling()

        ' 新しいサイズにリサイズする
        Dim newWidth As Integer = CInt(designSize.Width * dpiScaling)
        Dim newHeight As Integer = CInt(designSize.Height * dpiScaling)
        Dim resizedImage As New Bitmap(newWidth, newHeight)

        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(originalImage, 0, 0, newWidth, newHeight)
        End Using

        Return resizedImage
    End Function

    Public Function GetDpiScaling() As Single
        ' Graphicsオブジェクトを取得
        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            ' 現在のDPIスケーリングを計算
            Dim dpiScaling As Single = g.DpiX / 96.0F
            Return dpiScaling
        End Using
    End Function

    ' モーダルダイアログプリセット--------------------------------------------------------------
    Public Sub ShowCenteredDialog(mainForm As Form, dialog As Form)
        ' ダイアログのStartPositionプロパティをManualに設定
        dialog.StartPosition = FormStartPosition.Manual

        ' ダイアログの位置をメインフォームの中央に設定
        dialog.Location = New Point(
        mainForm.Location.X + (mainForm.Width - dialog.Width) \ 2,
        mainForm.Location.Y + (mainForm.Height - dialog.Height) \ 2)

        ' モーダルダイアログを表示
        dialog.ShowDialog(mainForm)
    End Sub


End Class