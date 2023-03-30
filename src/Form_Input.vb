Imports System.Globalization
Imports System.Text
Imports System.Xml
Imports ScintillaNET
Imports VPKSoft.ScintillaLexers.CreateSpecificLexer
Imports VPKSoft.ScintillaLexers.HelperClasses
Imports VPKSoft.ScintillaLexers.LexerEnumerations
Imports WeifenLuo.WinFormsUI.Docking
Imports TmCGPTD.Form1
Imports TmCGPTD.Form_Chat
Imports System.Data.SQLite
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Reflection
Public Class Form_Input
    Inherits DockContent

    ' MainFormインスタンスを保持するプロパティを追加します
    Public Property MainFormInst As Form1
    Private Sub Form_Input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 埋め込みリソースからボタン画像を読み込む
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim resourceStream As Stream = assembly.GetManifestResourceStream("TmCGPTD.iconWriteO6.png")
        Dim originalImage As Image = Image.FromStream(resourceStream) ' 元の画像を読み込む
        Dim dpiScaling As Single = Form1.GetDpiScaling() ' DPIスケーリングを取得
        Dim newSize As Integer = CInt(18 * dpiScaling) ' 新しいサイズにリサイズする
        Dim resizedImage As New Bitmap(newSize, newSize)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2)
        End Using
        ButtonPost.Image = resizedImage ' ボタンのImageプロパティに設定
    End Sub

    Private Sub InputForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mainForm As Form1 = CType(Application.OpenForms.OfType(Of Form1).FirstOrDefault(), Form1)
        If Not mainForm.cts.Token.IsCancellationRequested Then
            Me.Hide() ' フォームを閉じるのではなく、非表示にする
            e.Cancel = True ' イベントをキャンセルし、フォームが閉じないようにする
        Else
            e.Cancel = False
        End If
    End Sub

    ' グローバル変数
    Public Shared inputText As New List(Of String)()
    Public Shared recentText As String
    Public Shared targetScintilla As Scintilla = Form_Input.TextInput1
    Public Shared targetCursorPositionStart As Integer = 0
    Public Shared targetCursorPositionEnd As Integer = 0
    Public Shared scintillaPick As Boolean = True

    ' テキスト入力を出力に反映--------------------------------------------------------------
    Private Sub TextInput_TextChanged(sender As Object, e As EventArgs) Handles TextInput1.TextChanged, TextInput2.TextChanged, TextInput3.TextChanged, TextInput4.TextChanged, TextInput5.TextChanged
        inputText.Clear()
        inputText.Add(String.Join(Environment.NewLine, TextInput1.Text))
        inputText.Add(String.Join(Environment.NewLine, TextInput2.Text))
        inputText.Add(String.Join(Environment.NewLine, TextInput3.Text))
        inputText.Add(String.Join(Environment.NewLine, TextInput4.Text))
        inputText.Add(String.Join(Environment.NewLine, TextInput5.Text))

        Dim outputText = inputText
        outputText.RemoveAll(Function(s) String.IsNullOrWhiteSpace(s)) ' 空行を削除

        recentText = String.Join(Environment.NewLine & "---" & Environment.NewLine, outputText).Trim()
        If Not String.IsNullOrWhiteSpace(recentText) Then
            If Form1.MainFormPreviewForm IsNot Nothing Then
                Form1.MainFormPreviewForm.TextOut.Text = recentText
            End If
        End If

        Dim ScintillaStr As Scintilla = CType(sender, Scintilla)
        If ScintillaStr.SelectionStart <> targetCursorPositionStart OrElse ScintillaStr.SelectionEnd <> targetCursorPositionEnd Then
            '選択範囲が変更されたときの処理
            targetScintilla = ScintillaStr
            targetCursorPositionStart = ScintillaStr.SelectionStart
            targetCursorPositionEnd = ScintillaStr.SelectionEnd
        End If
    End Sub

    ' フォーカス＆カーソル位置保存--------------------------------------------------------------
    Private Sub TextInput_GotFocus(sender As Object, e As EventArgs) Handles TextInput1.GotFocus, TextInput2.GotFocus, TextInput3.GotFocus, TextInput4.GotFocus, TextInput5.GotFocus
        If scintillaPick Then
            '変更されたリッチテキストボックスとカーソル位置を格納する
            Dim ScintillaStr As Scintilla = CType(sender, Scintilla)
            targetScintilla = ScintillaStr
            targetCursorPositionStart = ScintillaStr.SelectionStart
            targetCursorPositionEnd = ScintillaStr.SelectionEnd
        End If
    End Sub

    ' テキスト入力　カーソル移動--------------------------------------------------------------
    Private Sub TextInputes_KeyDown(sender As Object, e As KeyEventArgs) Handles TextInput1.KeyDown, TextInput2.KeyDown, TextInput3.KeyDown, TextInput4.KeyDown, TextInput5.KeyDown
        Dim textInput As Scintilla = DirectCast(sender, Scintilla)
        Dim number As Integer = CInt(textInput.Name.Substring(textInput.Name.Length - 1))
        Dim lastCharIndex As Integer = 0
        If textInput.Lines.Count > 1 Then
            Dim lastLineIndex As Integer = textInput.Lines.Count - 1
            lastCharIndex = textInput.LineFromPosition(lastLineIndex)
        End If

        If e.KeyCode = Keys.Tab AndAlso (e.Modifiers And Keys.Shift) = 0 Then
            e.SuppressKeyPress = True 'タブ文字の挿入を防止
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True) '次のフォーカスを移動
        ElseIf e.KeyCode = Keys.Tab AndAlso (e.Modifiers And Keys.Shift) <> 0 Then
            e.SuppressKeyPress = True 'タブ文字の挿入を防止
            Me.SelectNextControl(Me.ActiveControl, False, True, True, True) '前のフォーカスに移動
        End If

        If e.KeyCode = Keys.Down AndAlso textInput.SelectionStart >= lastCharIndex Then
            If number < 5 Then
                Dim nextTextInput = CType(Me.Controls.Find($"TextInput{number + 1}", True)(0), Scintilla)
                nextTextInput.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up AndAlso textInput.CurrentLine = 0 Then
            If number > 1 Then
                Dim prevTextInput = CType(Me.Controls.Find($"TextInput{number - 1}", True)(0), Scintilla)
                prevTextInput.Focus()
            End If
        End If

        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' リターンキーの動作をキャンセルする
        ElseIf e.Shift AndAlso e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' リターンキーの動作をキャンセルする
        End If

        If scintillaPick Then
            '変更されたリッチテキストボックスとカーソル位置を格納する
            Dim ScintillaStr As Scintilla = CType(sender, Scintilla)
            targetScintilla = ScintillaStr
            targetCursorPositionStart = ScintillaStr.SelectionStart
            targetCursorPositionEnd = ScintillaStr.SelectionEnd
        End If
    End Sub

    ' POSTボタン--------------------------------------------------------------
    Private Async Sub ButtonPost_Click(sender As Object, e As EventArgs) Handles ButtonPost.Click
        If Not String.IsNullOrWhiteSpace(recentText) Then
            Await MainFormInst.GoChatAsync()
            Await TextInputAllClearAsync()
        End If
    End Sub

    ' Saveボタン--------------------------------------------------------------
    Private Async Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If Not String.IsNullOrWhiteSpace(recentText) Then
            Clipboard.SetText(recentText, TextDataFormat.UnicodeText)
            Await MainFormInst.InsertDatabaseAsync()
        End If
    End Sub

    ' 最近の200件ボタン--------------------------------------------------------------
    Private Async Sub ButtonRecentLog_ClickAsync(sender As Object, e As EventArgs) Handles ButtonRecentLog.Click
        ' ドロップダウンリストの項目をクリア
        Await Task.Run(Sub() ComboBoxSearch.BeginInvoke(Sub() ComboBoxSearch.Items.Clear()))
        ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
        ' 最新50件
        Dim query As String = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 200"
        Await Form1.SearchDatabaseAsync(query)
        ' ドロップダウンリストを表示する
        Await Task.Run(Sub()
                           ComboBoxSearch.BeginInvoke(Sub()
                                                          If Not ComboBoxSearch.DroppedDown Then ComboBoxSearch.DroppedDown = True
                                                          ComboBoxSearch.Focus()
                                                      End Sub)
                       End Sub)
    End Sub

    ' サーチコンボボックス選択イベント--------------------------------------------------------------
    Private Sub ComboBoxSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSearch.SelectedIndexChanged
        ' 選択された項目を取得
        Dim selectedItem As String = ComboBoxSearch.SelectedItem?.ToString()

        ' 空、もしくは"No matching results."の場合は何もしない
        If String.IsNullOrEmpty(selectedItem) OrElse selectedItem.Equals("No matching results.") Then Return

        ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
        ' 「#」で分割して、IDを取得する
        Dim id As Integer = Integer.Parse(selectedItem.Substring(selectedItem.LastIndexOf("#") + 1))

        ' SQLクエリを構築して実行する
        Dim query As String = $"SELECT text FROM log WHERE id = {id}"
        Using command As New SQLiteCommand(query, memoryConnection)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' textカラムの値を取得して、区切り文字で分割する
                    Dim texts As String()
                    Dim text As String = reader.GetString(0)
                    texts = text.Split({"<---TMCGPT--->"}, StringSplitOptions.None)
                    For i As Integer = 0 To Math.Min(texts.Length - 1, 4) ' 5要素目までを取得
                        Dim inputBox As Scintilla = CType(Me.Controls.Find($"TextInput{i + 1}", True)(0), Scintilla)
                        inputBox.Clear()
                        If Not String.IsNullOrWhiteSpace(texts(i)) Then
                            inputBox.Text = texts(i).Trim() ' 空白を削除して反映
                        End If
                    Next
                End If
            End Using
        End Using

        ' ドロップダウンリストを表示する
        ComboBoxSearch.DroppedDown = True
    End Sub

    ' サーチコンボボックスキーワード検索--------------------------------------------------------------
    Private Async Sub ComboBoxSearch_KeyDownAsync(sender As Object, e As KeyEventArgs) Handles ComboBoxSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
            e.Handled = True
            e.SuppressKeyPress = True
            If ComboBoxSearch.DroppedDown Then ComboBoxSearch.DroppedDown = False ' ドロップダウンを閉じる
            ' コンボボックスのテキストを取得
            Dim searchText As String = ComboBoxSearch.Text.Trim()

            ' 検索文字列が空か、検索結果なら終了
            If String.IsNullOrEmpty(searchText) OrElse Regex.IsMatch(searchText, "^.*#[0-9]+$") OrElse searchText = "No matching results." Then Return
            ' ドロップダウンリストの項目をクリア
            ComboBoxSearch.Items.Clear()

            ' テキストカラムを検索
            Dim query As String = $"SELECT id, date, text FROM log WHERE text LIKE '%{searchText}%' ORDER BY id DESC"
            Await Form1.SearchDatabaseAsync(query)
            ' ドロップダウンリストを表示する
            If Not ComboBoxSearch.DroppedDown Then ComboBoxSearch.DroppedDown = True
        End If
    End Sub

    ' コンボボックスのインフォメーション--------------------------------------------------------------
    Private Sub ComboBoxSearch_GotFocus(sender As Object, e As EventArgs) Handles ComboBoxSearch.GotFocus

        If Not ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220) Then ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
        If ComboBoxSearch.Text = "Type text here and press Enter to search Editor log." Then ComboBoxSearch.Text = ""

    End Sub

    ' デリートボタン--------------------------------------------------------------
    Private Async Sub ButtonDelete_ClickAsync(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        Dim selectedItem As String = ComboBoxSearch.SelectedItem?.ToString() ' 選択された項目を取得

        ' 空、もしくは"No matching results."の場合は何もしない
        If String.IsNullOrEmpty(selectedItem) OrElse selectedItem.Equals("No matching results.") Then
            If Regex.IsMatch(ComboBoxSearch.Text, "^[0-9]+.+#[0-9]+$") Then
                selectedItem = ComboBoxSearch.Text
            Else
                Return
            End If
        End If
        ComboBoxSearch.ForeColor = Color.Black

        ' 「#」で分割して、IDを取得する
        Dim id As Integer = Integer.Parse(selectedItem.Substring(selectedItem.LastIndexOf("#") + 1))

        Dim result = MessageBox.Show($"Delete this log?{Environment.NewLine}{Environment.NewLine}{selectedItem}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.Yes Then

            ' SQLクエリを構築して実行する
            Using connection As New SQLiteConnection($"Data Source={dbPath}")
                connection.Open()
                ' トランザクションを開始
                Using transaction As SQLiteTransaction = connection.BeginTransaction()
                    Try
                        ' レコードを削除
                        Using command As New SQLiteCommand($"DELETE FROM log WHERE id = '{id}'", connection, transaction)
                            command.ExecuteNonQuery()
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

            ' 最新200件を表示
            ComboBoxSearch.SelectedItem = Nothing
            ComboBoxSearch.Items.Clear() ' ドロップダウンリストの項目をクリア

            ' インメモリをいったん閉じてまた開く
            memoryConnection.Close()
            Form1.DbLoadToMemory()

            If ComboBoxSearch.DroppedDown Then ComboBoxSearch.DroppedDown = False ' ドロップダウンを閉じる
            Dim query As String = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 200"

            ' 表示更新
            Await Form1.SearchDatabaseAsync(query)
            ' ドロップダウンリストを表示する
            If Not ComboBoxSearch.DroppedDown Then ComboBoxSearch.DroppedDown = True
        End If

    End Sub

    ' 前に戻るボタン--------------------------------------------------------------
    Private Sub ButtonPrev_Click(sender As Object, e As EventArgs) Handles ButtonPrev.Click
        Dim searchDate As DateTime
        Dim input As String = ComboBoxSearch.Text
        ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
        If String.IsNullOrWhiteSpace(input) OrElse input = "Type text here and press Enter to search Editor log." Then input = Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim pattern As String = "^\d{4}[-/]\d{2}[-/]\d{2} \d{2}:\d{2}:\d{2}"
        Dim rx As String = Regex.Match(input, pattern).Value
        If Regex.IsMatch(input, pattern) AndAlso DateTime.TryParse(rx, searchDate) Then
            ComboBoxSearch.Items.Clear() ' ドロップダウンリストの項目をクリア

            Dim searchQuery As String = "SELECT id, date, text FROM log WHERE datetime(date) < @searchDate ORDER BY date DESC LIMIT 1"
            Form1.SearchDatabaseByDate(searchQuery, searchDate)

            ComboBoxSearch.Focus()
        Else
            MessageBox.Show("Invalid search date and time")
        End If
    End Sub

    ' 次に進むボタン--------------------------------------------------------------
    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        Dim searchDate As DateTime
        Dim input As String = ComboBoxSearch.Text
        ComboBoxSearch.ForeColor = Color.FromArgb(220, 220, 220)
        If String.IsNullOrWhiteSpace(input) OrElse input = "Type text here and press Enter to search Editor log." Then input = Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim pattern As String = "^\d{4}[-/]\d{2}[-/]\d{2} \d{2}:\d{2}:\d{2}"
        Dim rx As String = Regex.Match(input, pattern).Value
        If Regex.IsMatch(input, pattern) AndAlso DateTime.TryParse(rx, searchDate) Then
            ComboBoxSearch.Items.Clear() ' ドロップダウンリストの項目をクリア

            Dim searchQuery As String = "SELECT id, date, text FROM log WHERE datetime(date) > @searchDate ORDER BY date ASC LIMIT 1"
            Form1.SearchDatabaseByDate(searchQuery, searchDate)

            ComboBoxSearch.Focus()
        Else
            MessageBox.Show("Invalid search date and time")
        End If
    End Sub

    ' クリアボタン--------------------------------------------------------------
    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear1.Click, ButtonClear2.Click, ButtonClear3.Click, ButtonClear4.Click, ButtonClear5.Click
        Dim buttonStr As Button = CType(sender, Button)
        Dim inputBoxName As String = "TextInput" & buttonStr.Text ' テキストをクリアするリッチテキストボックスの名前を生成
        Dim inputBox As Scintilla = TryCast(Me.Controls.Find(inputBoxName, True).FirstOrDefault(), Scintilla) ' リッチテキストボックスを取得
        inputBox.Text = "" ' テキストをクリア
    End Sub

    Private Async Sub ButtonClearAll_Click(sender As Object, e As EventArgs) Handles ButtonClearAll.Click
        Await TextInputAllClearAsync()
    End Sub
    Private Async Function TextInputAllClearAsync() As Task
        Await Task.Run(Sub() TextInput1.BeginInvoke(Sub() TextInput1.Text = "")) ' テキストをクリア
        Await Task.Run(Sub() TextInput2.BeginInvoke(Sub() TextInput2.Text = ""))
        Await Task.Run(Sub() TextInput3.BeginInvoke(Sub() TextInput3.Text = ""))
        Await Task.Run(Sub() TextInput4.BeginInvoke(Sub() TextInput4.Text = ""))
        Await Task.Run(Sub() TextInput5.BeginInvoke(Sub() TextInput5.Text = ""))
    End Function
    Private Sub ComboBoxSearch_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBoxSearch.DrawItem
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

    Private Sub Form_Input_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' テキストエリアを初期化
        MainFormInst.ScintillaInitialize(My.Settings.InputFontName, My.Settings.InputFontSize, nowLangueage, My.Settings.ChatFontName, My.Settings.ChatFontSize)

        ' 定型句再現
        Dim lastSelectedMenuItem As String = My.Settings.DefaultPresets
        For Each item As ToolStripItem In MainFormInst.PhrasePresetsToolStripMenuItem.DropDownItems
            If TypeOf item Is ToolStripMenuItem AndAlso CType(item, ToolStripMenuItem).Text = lastSelectedMenuItem Then
                Dim selectedItem As ToolStripMenuItem = CType(item, ToolStripMenuItem)
                MainFormInst.SelectionItem_Click(selectedItem, EventArgs.Empty)
                Exit For
            End If
        Next
        ' シンタックスハイライト再現
        lastSelectedMenuItem = My.Settings.Language
        For Each item As ToolStripItem In MainFormInst.LanguageToolStripMenuItem.DropDownItems
            Dim selectedItem As ToolStripMenuItem = MainFormInst.FindMenuItemByText(item, lastSelectedMenuItem)
            If selectedItem IsNot Nothing Then
                selectedItem.Checked = False
                MainFormInst.SelectionItemLang_Click(selectedItem, EventArgs.Empty)
                Exit For
            End If
        Next

        TextInput1.Zoom = My.Settings.Zoom1
        TextInput2.Zoom = My.Settings.Zoom2
        TextInput3.Zoom = My.Settings.Zoom3
        TextInput4.Zoom = My.Settings.Zoom4
        TextInput5.Zoom = My.Settings.Zoom5
    End Sub
End Class