Imports System.Data.Common
Imports System.Data.SQLite
Imports System.IO
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Text
Imports System.Text.RegularExpressions
Imports WeifenLuo.WinFormsUI.Docking

Public Class Form_ChatLog
    Inherits DockContent
    Public Property MainFormInst As Form1
    Private Sub ChatLogForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mainForm As Form1 = CType(Application.OpenForms.OfType(Of Form1).FirstOrDefault(), Form1)
        If Not mainForm.cts.Token.IsCancellationRequested Then
            Me.Hide() ' フォームを閉じるのではなく、非表示にする
            e.Cancel = True ' イベントをキャンセルし、フォームが閉じないようにする
        Else
            e.Cancel = False
        End If
    End Sub
    Private Sub ChatLogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form1.SetPictureBoxImage("TmCGPTD.iconChatBlack.png", PictureBox1)
        'Form1.SetPictureBoxImage("TmCGPTD.iconTagBlack.png", PictureBox2)

        ' 埋め込みリソースからボタン画像を読み込む
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim resourceStream As Stream = assembly.GetManifestResourceStream("TmCGPTD.iconCal.png")
        Dim originalImage As Image = Image.FromStream(resourceStream) ' 元の画像を読み込む
        Dim dpiScaling As Single = Form1.GetDpiScaling() ' DPIスケーリングを取得
        Dim newSize As Integer = CInt(26 * dpiScaling) ' 新しいサイズにリサイズする
        Dim resizedImage As New Bitmap(newSize, newSize)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2)
        End Using
        ButtonCal.BackgroundImage = resizedImage ' ボタンのImageプロパティに設定
    End Sub

    ' データグリッド初期化--------------------------------------------------------------
    Private ReadOnly emptyDataTable As New DataTable()
    Public bSource As New BindingSource

    ' 仮想モードハンドラ
    Private Sub DataGrid_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles DataGrid.CellValueNeeded
        ' 必要なセルの値を取得して、e.Valueに設定する
        If e.ColumnIndex = 0 Then
            e.Value = e.RowIndex ' 行番号を設定
        Else
            e.Value = "Data" ' ダミーデータを設定
        End If
    End Sub
    Public Sub InitializeDataTable()

        ' 仮想モードを有効にする
        DataGrid.VirtualMode = True

        ' ダブルバッファリングを有効にする
        Dim dgvType As Type = DataGrid.GetType()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(DataGrid, True, Nothing)

        emptyDataTable.Columns.Add("chatId", GetType(Integer))
        emptyDataTable.Columns.Add("chatDate", GetType(Date))
        emptyDataTable.Columns.Add("chatTitle", GetType(String))
        emptyDataTable.Columns.Add("chatTag", GetType(String))

        bSource.DataSource = emptyDataTable
        DataGrid.DataSource = bSource

        DataGrid.EnableHeadersVisualStyles = False
        'DataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 70, 84)
        DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        DataGrid.Columns(0).HeaderText = "ID"
        DataGrid.Columns(1).HeaderText = "Update"
        DataGrid.Columns(2).HeaderText = "Title"
        DataGrid.Columns(3).HeaderText = "Tags"

        DataGrid.Columns(1).DefaultCellStyle.Format = "yy/MM/dd HH:mm"

        DataGrid.GridColor = Color.FromArgb(84, 85, 99)

        Dim dpiScaleFactor As Single = CreateGraphics().DpiX / 96.0F

        DataGrid.Columns(0).Width = CInt(50 * dpiScaleFactor)
        DataGrid.Columns(1).Width = CInt(106 * dpiScaleFactor)
        DataGrid.Columns(2).Width = CInt(180 * dpiScaleFactor)
        DataGrid.Columns(3).Width = CInt(250 * dpiScaleFactor)
    End Sub

    ' 検索結果表示--------------------------------------------------------------
    Public Async Function ShowChatSearchResultAsync(dT As DataTable) As Task
        'If dT.Rows.Count > 0 Then
        Await Task.Run(Sub()
                           DataGrid.BeginInvoke(Sub()
                                                    ' 自動バインド停止
                                                    'bSource.RaiseListChangedEvents = False
                                                    bSource.SuspendBinding()

                                                    bSource.DataSource = dT ' データ入力

                                                    bSource.RaiseListChangedEvents = True ' データ変更許可
                                                    ' 更新反映
                                                    bSource.ResumeBinding()
                                                    'bSource.ResetBindings(False)
                                                    If DataGrid.Rows.Count > 0 Then DataGrid.Rows(0).Selected = True
                                                End Sub)
                       End Sub)
        'End If
        ' データベースからタグリストを取得
        Dim uniqueTags = Await MainFormInst.GetTagDatabaseAsync()
        Dim tagList As List(Of String) = uniqueTags.ToList()
        Await Task.Run(Sub() ComboBoxTag.BeginInvoke(Sub() ComboBoxTag.Items.Clear()))
        Await Task.Run(Sub() ComboBoxTag.BeginInvoke(Sub() ComboBoxTag.Items.AddRange(tagList.ToArray())))
    End Function

    ' チャット本文ログ表示--------------------------------------------------------------
    Private Async Sub DataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellClick
        If e.RowIndex >= 0 Then ' ヘッダー行を除く
            ' クリックされた行のchatIdカラムの値を取得
            Dim chatId As Integer = CInt(DataGrid.Rows(e.RowIndex).Cells("chatId").Value)
            Dim query As String = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}"
            Dim result As List(Of String) = Await MainFormInst.PickChatDatabaseAsync(query)
            Await MainFormInst.ShowChatLogAsync(result)
            MainFormInst.lastRowId = chatId
        End If
    End Sub

    ' データグリッドの自動選択解除--------------------------------------------------------------
    Private Sub Form_ChatLog_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DataGrid.SelectedColumns.Count = 0 Then
            DataGrid.ClearSelection()
        End If
    End Sub

    Private keywordFilter As String = ""
    Private tagFilter As String = ""
    Private dateFilter As String = ""
    Public startDate As Date = Now
    Public endDate As Date = Now

    ' カレンダー起動--------------------------------------------------------------
    Private Async Sub ButtonCal_ClickAsync(sender As Object, e As EventArgs) Handles ButtonCal.Click
        Dim dateRangeForm As New Form_DateRange() ' DateRangeFormのインスタンスを作成
        Dim buttonScreenLocation As Point = ButtonCal.PointToScreen(Point.Empty) ' ボタンのスクリーン座標を取得
        ' ダイアログの表示位置を計算（ボタンの左下に右寄せ）
        Dim dialogLocation As New Point(buttonScreenLocation.X + CType(ButtonCal.Width, Integer) - CType(dateRangeForm.Width, Integer), buttonScreenLocation.Y + ButtonCal.Height)
        ' ダイアログの表示位置を設定
        dateRangeForm.Location = dialogLocation
        dateRangeForm.DateTimePicker1.Value = startDate
        dateRangeForm.DateTimePicker2.Value = endDate
        ' モーダルダイアログとして表示
        If dateRangeForm.ShowDialog() = DialogResult.OK Then
            ' OKボタンがクリックされた場合、選択された日付範囲を取得
            startDate = dateRangeForm.StartDatePicker.Value
            endDate = dateRangeForm.EndDatePicker.Value

            If endDate < startDate Then
                Dim tempDate As Date = startDate
                startDate = endDate
                endDate = tempDate
            End If
            Await ApplyDateFilterAsync(startDate, endDate)
            ButtonCal.BackColor = Color.FromArgb(146, 148, 165)
        Else
            Await RemoveDateFilterAsync() ' 日付フィルタ解除
            ButtonCal.BackColor = Color.FromArgb(53, 55, 64)
            startDate = Now
            endDate = Now
        End If
    End Sub
    ' 日付フィルタを適用するメソッド
    Private Async Function ApplyDateFilterAsync(startDate As Date, endDate As Date) As Task
        endDate = endDate.AddDays(1) ' endDate に1日加算
        dateFilter = $"chatDate >= #{startDate.ToShortDateString()}# AND chatDate <= #{endDate.ToShortDateString()}#"
        Await UpdateFilterAsync()
    End Function

    ' フィルタを解除するメソッド
    Private Async Function RemoveDateFilterAsync() As Task
        dateFilter = ""
        Await UpdateFilterAsync()
    End Function

    ' フィルタを更新するメソッド
    Private Async Function UpdateFilterAsync() As Task
        Dim filters As New List(Of String)

        If Not String.IsNullOrEmpty(keywordFilter) Then filters.Add(keywordFilter)
        If Not String.IsNullOrEmpty(tagFilter) Then filters.Add(tagFilter)
        If Not String.IsNullOrEmpty(dateFilter) Then filters.Add(dateFilter)

        Await Task.Run(Sub()
                           DataGrid.BeginInvoke(Sub()
                                                    ' 自動バインド停止
                                                    'bSource.RaiseListChangedEvents = False
                                                    bSource.SuspendBinding()

                                                    bSource.Filter = String.Join(" AND ", filters)

                                                    bSource.RaiseListChangedEvents = True ' データ変更許可
                                                    ' 更新反映
                                                    bSource.ResumeBinding()
                                                    'bSource.ResetBindings(False)
                                                    If DataGrid.Rows.Count > 0 Then DataGrid.Rows(0).Selected = True
                                                End Sub)
                       End Sub)
    End Function

    ' キーワード検索やタグ検索を更新する場合
    Private Async Sub ComboBoxTag_SelectedIndexChangedAync(sender As Object, e As EventArgs) Handles ComboBoxTag.SelectedIndexChanged
        ' 選択された項目を取得
        Dim selectedItem As String = Nothing
        Await Task.Run(Sub() ComboBoxTag.BeginInvoke(Sub() selectedItem = ComboBoxTag.SelectedItem?.ToString()))

        ' 空の場合は何もしない
        If String.IsNullOrEmpty(selectedItem) Then Return
        If selectedItem = "(All)" Then selectedItem = ""
        Await UpdateTagFilterAsync(selectedItem)
    End Sub
    Private Async Function UpdateKeywordFilterAsync(newKeyword As String) As Task
        keywordFilter = $"ColumnNameForKeyword LIKE '%{newKeyword}%'"
        Await UpdateFilterAsync()
    End Function

    Private Async Function UpdateTagFilterAsync(newTag As String) As Task
        tagFilter = $"chatTag LIKE '%{newTag}%'"
        Await UpdateFilterAsync()
    End Function

    Private Sub ComboBoxTag_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBoxTag.DrawItem
        If e.Index < 0 Then Return

        Dim comboBoxMod As ComboBox = CType(sender, ComboBox)
        Dim isSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        ' カスタムの背景色とテキスト色を設定します。
        Dim backColor As Color = If(isSelected, Color.FromArgb(106, 108, 125), comboBoxMod.BackColor)
        Dim textColor As Color = If(isSelected, Color.FromArgb(220, 220, 220), comboBoxMod.ForeColor)

        ' 背景を描画します。
        Using brush As New SolidBrush(backColor)
            e.Graphics.FillRectangle(brush, e.Bounds)
        End Using

        ' テキストを描画します。
        Using brush As New SolidBrush(textColor)
            e.Graphics.DrawString(comboBoxMod.Items(e.Index).ToString(), e.Font, brush, e.Bounds)
        End Using

        ' フォーカス矩形を描画します。
        If (e.State And DrawItemState.Focus) = DrawItemState.Focus Then
            e.DrawFocusRectangle()
        End If
    End Sub

    ' インクリメンタルサーチ--------------------------------------------------------------
    Public Async Function TextBoxSearch_TextChangedAsync(sender As Object, e As EventArgs) As Task Handles TextBoxSearch.TextChanged
        Dim searchKey As String = Nothing
        Await Task.Run(Sub() TextBoxSearch.BeginInvoke(Sub() searchKey = TextBoxSearch.Text.Trim()))
        Dim query As String
        Dim dT As DataTable
        If searchKey = "" Then
            query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
            dT = Await MainFormInst.SearchChatDatabaseAsync(query)
        Else
            query = "SELECT id, date, title, tag FROM chatlog WHERE LOWER(text) LIKE LOWER(@searchKey)"
            dT = Await MainFormInst.SearchChatDatabaseAsync(query, searchKey)
        End If
        Await ShowChatSearchResultAsync(dT)
        Dim rowsCount As New Integer
        Await Task.Run(Sub() DataGrid.BeginInvoke(Sub() rowsCount = DataGrid.Rows.Count))
        If rowsCount > 0 Then
            Dim chatId As New Integer
            Await Task.Run(Sub() DataGrid.BeginInvoke(Sub() chatId = CInt(DataGrid.Rows(0).Cells("chatId").Value)))
            query = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}"
            Dim result = Await MainFormInst.PickChatDatabaseAsync(query)
            Await MainFormInst.ShowChatLogAsync(result, searchKey)
            MainFormInst.lastRowId = chatId
        Else

        End If
    End Function

    ' デリートボタン--------------------------------------------------------------
    Private Async Sub ButtonChatDelete_ClickAsync(sender As Object, e As EventArgs) Handles ButtonChatDelete.Click
        Dim chatId As Integer
        Dim chatDate As String
        Dim chatTitle As String
        If DataGrid.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGrid.SelectedRows(0)
            chatId = Convert.ToInt32(selectedRow.Cells("chatId").Value)
            chatDate = selectedRow.Cells("chatDate").Value.ToString
            chatTitle = selectedRow.Cells("chatTitle").Value.ToString
        Else
            Return
        End If

        Dim result = MessageBox.Show($"Delete this chat log?{Environment.NewLine}{Environment.NewLine}{chatDate} {chatTitle}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.Yes Then

            ' SQLクエリを構築して実行する
            Using connection As New SQLiteConnection($"Data Source={Form1.dbPath}")
                connection.Open()
                ' トランザクションを開始
                Using transaction As SQLiteTransaction = connection.BeginTransaction()
                    Try
                        ' レコードを削除
                        Using command As New SQLiteCommand($"DELETE FROM chatlog WHERE id = '{chatId}'", connection, transaction)
                            Await command.ExecuteNonQueryAsync()
                        End Using
                        ' トランザクションをコミット
                        transaction.Commit()
                    Catch ex As Exception
                        ' エラーが発生した場合は、トランザクションをロールバック
                        transaction.Rollback()
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using

            ' インメモリをいったん閉じてまた開く
            Form1.memoryConnection.Close()
            Form1.DbLoadToMemory()

            Await TextBoxSearch_TextChangedAsync(DataGrid, EventArgs.Empty)
        End If

    End Sub

    Private dockedSize As Size
    Private Sub MyForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.DockState <> WeifenLuo.WinFormsUI.Docking.DockState.Float Then
            dockedSize = Me.Size
        End If
    End Sub
    Private Sub MyForm_DockStateChanged(sender As Object, e As EventArgs) Handles MyBase.DockStateChanged
        If Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float Then
            ' ここで DefaultFloatWindowSize を変更する
            Me.Size = dockedSize
        End If
    End Sub

End Class