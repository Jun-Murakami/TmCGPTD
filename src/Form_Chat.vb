Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports ScintillaNET
Imports WeifenLuo.WinFormsUI.Docking
Imports TmCGPTD.Form1
Imports System.Threading
Imports System.Runtime.CompilerServices

Public Class Form_Chat
    Inherits DockContent
    Public Property MainFormInst As Form1

    Private _lastSearchPos As Integer = 0 ' 検索ボックス用

    Private Sub ChatForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 埋め込みリソースからボタン画像を読み込む
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim resourceStream As Stream = assembly.GetManifestResourceStream("TmCGPTD.iconChatO6.png")
        Dim originalImage As Image = Image.FromStream(resourceStream) ' 元の画像を読み込む
        Dim dpiScaling As Single = Form1.GetDpiScaling() ' DPIスケーリングを取得
        Dim newSize As Integer = CInt(18 * dpiScaling) ' 新しいサイズにリサイズする
        Dim resizedImage As New Bitmap(newSize, newSize)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2)
        End Using
        ButtonNewChat.Image = resizedImage ' ボタンのImageプロパティに設定

        ' 画像の高dpi対応
        'Form1.SetPictureBoxImage("TmCGPTD.iconChat.png", PictureBox1)
        'Form1.SetPictureBoxImage("TmCGPTD.iconTag.png", PictureBox2)
        'Form1.SetPictureBoxImage("TmCGPTD.iconWrite.png", PictureButtonTitle)
        'Form1.SetPictureBoxImage("TmCGPTD.iconWrite.png", PictureButtonTag)

        ' マウスオーバーエフェクト用に画像をタグに保持
        PictureButtonTitle.Tag = PictureButtonTitle.Image
        PictureButtonTag.Tag = PictureButtonTag.Image
        ChangeImageOpacity(PictureButtonTitle, 0.6F) ' アルファ値を75%に設定
        ChangeImageOpacity(PictureButtonTag, 0.6F) ' アルファ値を75%に設定

        ChatBox.Markers(1).Symbol = MarkerSymbol.Background
        ChatBox.Markers(1).SetBackColor(Color.FromArgb(68, 70, 84)) ' マーカーの背景色を設定
        ChatBox.Markers(2).Symbol = MarkerSymbol.Background
        ChatBox.Markers(2).SetBackColor(Color.FromArgb(0, 0, 0)) ' マーカーの背景色を設定(コードスニペット)

        ' ローディングタイマー初期化
        loadingTimer = New Windows.Forms.Timer()
        loadingTimer2 = New Windows.Forms.Timer()
        AddHandler loadingTimer.Tick, AddressOf Timer1_TickAsync
        AddHandler loadingTimer2.Tick, AddressOf Timer2_TickAsync
    End Sub

    Private Async Sub ChatForm_DoubleClickAsync(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Await MainFormInst.UpdateChatSaysMarkerAsync()
        Await MainFormInst.UpdateChatCodeMarkerAsync()
    End Sub

    Public Sub ButtonDown_Click(sender As Object, e As EventArgs) Handles ButtonDown.Click
        Dim searchText As String = Nothing
        searchText = TextBoxChatTextSearch.Text

        Dim startPos As Integer = ChatBox.SelectionStart + (ChatBox.SelectionEnd - ChatBox.SelectionStart)
        If startPos >= ChatBox.Text.Length Then startPos = 0

        Dim resultPos As Integer = ChatBox.Text.IndexOf(searchText, startPos, StringComparison.OrdinalIgnoreCase)

        If resultPos <> -1 Then
            ChatBox.SelectionStart = resultPos
            ChatBox.SelectionEnd = resultPos + searchText.Length
            _lastSearchPos = resultPos
            ChatBox.ScrollCaret()
        Else
            MessageBox.Show("No matching results.")
        End If

    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        Dim searchText As String = TextBoxChatTextSearch.Text
        Dim startPos As Integer = ChatBox.SelectionStart - 1
        If startPos < 0 Then startPos = ChatBox.Text.Length - 1

        Dim resultPos As Integer = ChatBox.Text.LastIndexOf(searchText, startPos, StringComparison.OrdinalIgnoreCase)

        If resultPos <> -1 Then
            ChatBox.SelectionStart = resultPos
            ChatBox.SelectionEnd = resultPos + searchText.Length
            _lastSearchPos = resultPos
            ChatBox.ScrollCaret()
        Else
            MessageBox.Show("No matching results.")
        End If
    End Sub

    ' Form2は閉じれないようにする。--------------------------------------------------------------
    Private Sub PreviewForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mainForm As Form1 = CType(Application.OpenForms.OfType(Of Form1).FirstOrDefault(), Form1)
        If Not mainForm.cts.Token.IsCancellationRequested Then
            Me.Hide() ' フォームを閉じるのではなく、非表示にする
            e.Cancel = True ' イベントをキャンセルし、フォームが閉じないようにする
        Else
            e.Cancel = False
        End If
    End Sub

    ' 画像ボタンのマウスオーバー処理--------------------------------------------------------------
    Private Sub PictureButton_MouseEnter(sender As Object, e As EventArgs) Handles PictureButtonTitle.MouseEnter, PictureButtonTag.MouseEnter
        ChangeImageOpacity(CType(sender, PictureBox), 1.0F) ' アルファ値を100%に設定
    End Sub

    Private Sub PictureButton_MouseLeave(sender As Object, e As EventArgs) Handles PictureButtonTitle.MouseLeave, PictureButtonTag.MouseLeave
        ChangeImageOpacity(CType(sender, PictureBox), 0.6F) ' アルファ値を75%に設定
    End Sub

    Public Sub ChangeImageOpacity(pictureBox As PictureBox, opacity As Single)
        If Not isDone OrElse pictureBox.Tag Is Nothing Then Return

        Dim originalImage As Image = CType(pictureBox.Tag, Image)
        Dim bmp As New Bitmap(originalImage.Width, originalImage.Height)

        Using g As Graphics = Graphics.FromImage(bmp)
            Dim colormatrix As New Imaging.ColorMatrix()
            colormatrix.Matrix33 = opacity
            Dim imgAttribute As New Imaging.ImageAttributes()
            imgAttribute.SetColorMatrix(colormatrix, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)

            g.DrawImage(originalImage, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imgAttribute)
        End Using

        pictureBox.Image = bmp
    End Sub
    ' タイトル編集--------------------------------------------------------------
    Private Async Sub PictureButtonTitle_ClickAsync(sender As Object, e As EventArgs) Handles PictureButtonTitle.Click
        Try
            ' テキストボックスのテキストを読み取り、改行で結合してシングルクォートをエスケープ
            Dim title As String = ""
            Await Task.Run(Sub() TextBoxTitle.BeginInvoke(Sub() title = TextBoxTitle.Text))
            title = title.Replace("'", "''")
            ' データグリッドビューの現在選択行のchatIdカラムの値を読み取る
            If MainFormInst.chatLogForm.DataGrid.CurrentRow IsNot Nothing Then
                isDone = False
                Await Task.Run(Sub() PictureButtonTitle.Invoke(Sub() PictureButtonTitle.Image = My.Resources.iconLoading))
                loadingTimer2.Interval = 100 ' 更新間隔(ms)
                loadingTimer2.Start()
                Dim chatId As Integer = CInt(MainFormInst.chatLogForm.DataGrid.CurrentRow.Cells("chatId").Value)

                ' SQL実行
                Dim query As String = $"UPDATE chatlog SET title = '{title}' WHERE id = {chatId}"
                Await MainFormInst.UpdateDatabaseAsync(query)

                ' 表示更新
                query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
                Dim dT = Await MainFormInst.SearchChatDatabaseAsync(query)
                Await MainFormInst.chatLogForm.ShowChatSearchResultAsync(dT)
                SelectRowByChatId(chatId)
                Await Task.Delay(500)
                isDone = True
            Else
                MessageBox.Show("Please select a row in the DataGrid before updating the title.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' タグ編集--------------------------------------------------------------
    Private Async Sub PictureButtonTag_ClickAsync(sender As Object, e As EventArgs) Handles PictureButtonTag.Click
        Try
            ' テキストボックスのテキストを読み取り、改行で結合してシングルクォートをエスケープ
            Dim tags As String = String.Join(Environment.NewLine, New String() {TextBoxTag1.Text, TextBoxTag2.Text, TextBoxTag3.Text})
            tags = tags.Replace("'", "''")
            ' データグリッドビューの現在選択行のchatIdカラムの値を読み取る
            If MainFormInst.chatLogForm.DataGrid.CurrentRow IsNot Nothing Then
                isDone = False
                Await Task.Run(Sub() PictureButtonTag.Invoke(Sub() PictureButtonTag.Image = My.Resources.iconLoading))
                loadingTimer.Interval = 100 ' 更新間隔(ms)
                loadingTimer.Start()
                Dim chatId As Integer = CInt(MainFormInst.chatLogForm.DataGrid.CurrentRow.Cells("chatId").Value)

                ' SQL実行
                Dim query As String = $"UPDATE chatlog SET tag = '{tags}' WHERE id = {chatId}"
                Await MainFormInst.UpdateDatabaseAsync(query)

                ' 表示更新
                query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
                Dim dT = Await MainFormInst.SearchChatDatabaseAsync(query)
                Await MainFormInst.chatLogForm.ShowChatSearchResultAsync(dT)
                SelectRowByChatId(chatId)
                Await Task.Delay(500)
                isDone = True
            Else
                MessageBox.Show("Please select a row in the DataGrid before updating the tags.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' タイトル編集、タグ編集のアニメーション処理--------------------------------------------------------------
    Private loadingTimer As New System.Windows.Forms.Timer()
    Private loadingTimer2 As New System.Windows.Forms.Timer()
    Private rotationAngle As Integer
    Private isDone As Boolean = True
    Private Async Sub Timer1_TickAsync(sender As Object, e As EventArgs)
        If isDone Then
            Await Task.Run(Sub() PictureButtonTag.Invoke(Sub() PictureButtonTag.Image.Dispose()))
            Await Task.Run(Sub() PictureButtonTag.Invoke(Sub() PictureButtonTag.Image = My.Resources.iconOK))
            Await Task.Delay(700)
            Await Task.Run(Sub() PictureButtonTag.Invoke(Sub() PictureButtonTag.Image.Dispose()))
            ChangeImageOpacity(PictureButtonTag, 0.6F)
            loadingTimer.Stop()
        Else
            Await Task.Run(Sub()
                               PictureButtonTag.Invoke(Sub()
                                                           rotationAngle += 45
                                                           If rotationAngle >= 360 Then rotationAngle = 0
                                                           Dim oldImage As Image = PictureButtonTag.Image
                                                           Dim rotatedImage As Image = RotateImage(oldImage, rotationAngle)
                                                           PictureButtonTag.Image = rotatedImage
                                                           oldImage.Dispose() ' Dispose old image
                                                       End Sub)
                           End Sub)
        End If
    End Sub
    Private Async Sub Timer2_TickAsync(sender As Object, e As EventArgs)
        If isDone Then
            Await Task.Run(Sub() PictureButtonTitle.Invoke(Sub() PictureButtonTitle.Image.Dispose()))
            Await Task.Run(Sub() PictureButtonTitle.Invoke(Sub() PictureButtonTitle.Image = My.Resources.iconOK))
            Await Task.Delay(700)
            Await Task.Run(Sub() PictureButtonTitle.Invoke(Sub() PictureButtonTitle.Image.Dispose()))
            ChangeImageOpacity(PictureButtonTitle, 0.6F)
            loadingTimer2.Stop()

        Else
            Await Task.Run(Sub()
                               PictureButtonTitle.Invoke(Sub()
                                                             rotationAngle += 45
                                                             If rotationAngle >= 360 Then rotationAngle = 0
                                                             Dim oldImage As Image = PictureButtonTitle.Image
                                                             Dim rotatedImage As Image = RotateImage(oldImage, rotationAngle)
                                                             PictureButtonTitle.Image = rotatedImage
                                                             oldImage.Dispose() ' Dispose old image
                                                         End Sub)
                           End Sub)
        End If
    End Sub

    Private Function RotateImage(image As Image, angle As Single) As Image
        Dim rotatedImage As New Bitmap(image.Width, image.Height)
        rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        Using g As Graphics = Graphics.FromImage(rotatedImage)
            g.TranslateTransform(CSng(image.Width / 2), CSng(image.Height / 2))
            g.RotateTransform(angle)
            g.TranslateTransform(CSng(-image.Width / 2), CSng(-image.Height / 2))
            g.DrawImage(image, New PointF(0, 0))
        End Using

        Return rotatedImage
    End Function
    Private Sub SelectRowByChatId(chatId As Integer)
        MainFormInst.chatLogForm.DataGrid.ClearSelection()
        For Each row As DataGridViewRow In MainFormInst.chatLogForm.DataGrid.Rows
            If CInt(row.Cells("chatId").Value) = chatId Then
                row.Selected = True
                MainFormInst.chatLogForm.DataGrid.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    Private Async Sub ButtonNewChat_ClickAsync(sender As Object, e As EventArgs) Handles ButtonNewChat.Click
        Await MainFormInst.InitializeChatAsync()

    End Sub

End Class