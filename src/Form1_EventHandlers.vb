Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports ScintillaNET
Imports TmCGPTD.Form_Input
Imports TmCGPTD.Form_Preview
Imports TmCGPTD.Form_Chat
Imports WeifenLuo.WinFormsUI.Docking

Partial Public Class Form1

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveSetting()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        SaveSetting()
    End Sub

    Public Sub InputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputToolStripMenuItem.Click
        If inputForm Is Nothing Then
            inputForm = New Form_Input()
            inputForm.MainFormInst = Me
            DockPanel1.Theme = New VS2015LightTheme
        End If
        inputForm.Show(DockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document)
        ChangeControlColor()
    End Sub

    Public Sub PreviewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewWindowToolStripMenuItem.Click
        If previewForm Is Nothing Then
            previewForm = New Form_Preview()
            previewForm.MainFormInst = Me
            DockPanel1.Theme = New VS2015LightTheme
        End If
        previewForm.Show(DockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockRight)
        ChangeControlColor()
    End Sub
    Public Sub ChatLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatLogToolStripMenuItem.Click
        If chatForm Is Nothing Then
            chatForm = New Form_Chat()
            chatForm.MainFormInst = Me
            DockPanel1.Theme = New VS2015LightTheme
        End If
        chatForm.Show(DockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document)
        ChangeControlColor()
    End Sub

    Public Sub ChatListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatListToolStripMenuItem.Click
        If chatLogForm Is Nothing Then
            chatLogForm = New Form_ChatLog()
            chatLogForm.MainFormInst = Me
            DockPanel1.Theme = New VS2015LightTheme
        End If
        chatLogForm.Show(DockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        ChangeControlColor()
    End Sub
    Public Sub PhrasetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhraseToolStripMenuItem.Click
        If phraseForm Is Nothing Then
            phraseForm = New Form_Phrase()
            phraseForm.MainFormInst = Me
            DockPanel1.Theme = New VS2015LightTheme
        End If
        phraseForm.Show(DockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom)
        ChangeControlColor()
    End Sub
    Private Sub LayoutResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayoutResetToolStripMenuItem.Click
        LoadDefaultDockLayout()
    End Sub

    ' 定型句セーブ--------------------------------------------------------------
    Private Sub SavePresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePresetToolStripMenuItem.Click
        ' 1. テキストボックスの値を取得してリストに格納
        Dim textList As New List(Of String)
        For i = 1 To 20
            Dim textBoxName As String = $"TextBox{i}"
            Dim controlStr = phraseForm.Controls.Find(textBoxName, True)
            Dim textBox = TryCast(controlStr.FirstOrDefault(), TextBox)
            If textBox IsNot Nothing AndAlso Not String.IsNullOrEmpty(textBox.Text) Then
                textList.Add(textBox.Text)
            End If
        Next

        ' 2. ファイル保存ダイアログを表示
        If Not Directory.Exists(phrasePath) Then
            Directory.CreateDirectory(phrasePath)
        End If
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.InitialDirectory = phrasePath
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt"
        If saveFileDialog.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        ' 3. ファイルを保存
        Dim fileName As String = saveFileDialog.FileName
        Dim filePath As String = Path.Combine(phrasePath, Path.GetFileName(fileName))
        Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
            For Each Tex In textList
                writer.WriteLine(Tex)
            Next
        End Using

        ' 4. stereotypedフォルダ内のtxtファイルを列挙してリストボックスに表示
        ClearPresetPhrases()

        For Each file In Directory.GetFiles(phrasePath, "*.txt")
            AddSelectionItem(Path.GetFileName(file))
        Next
    End Sub
    Public Sub ClearPresetPhrases()
        For i As Integer = PhrasePresetsToolStripMenuItem.DropDownItems.Count - 1 To 0 Step -1
            Dim item As ToolStripItem = PhrasePresetsToolStripMenuItem.DropDownItems(i)
            If item.Text IsNot "Save Presets" AndAlso TypeOf item Is ToolStripMenuItem Then
                Dim menuItem As ToolStripMenuItem = CType(item, ToolStripMenuItem)
                RemoveHandler menuItem.Click, AddressOf SelectionItem_Click
                PhrasePresetsToolStripMenuItem.DropDownItems.Remove(menuItem)
            End If
        Next
    End Sub

    ' 排他的に選択できるメニューアイテムを追加するメソッド--------------------------------------------------------------
    Public Sub AddSelectionItem(text As String)
        Dim newItem As New ToolStripMenuItem(text) With {
            .CheckOnClick = False
        }
        AddHandler newItem.Click, AddressOf SelectionItem_Click
        PhrasePresetsToolStripMenuItem.DropDownItems.Add(newItem)
    End Sub

    ' 定型句プリセット選択(ハンドルはメニュー生成時にコードで付加)--------------------------------------------------------------
    Public Sub SelectionItem_Click(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If clickedItem.Checked = True Then Return

        ' 他のメニューアイテムのチェックをクリアする
        For Each item As ToolStripItem In PhrasePresetsToolStripMenuItem.DropDownItems
            If TypeOf item Is ToolStripMenuItem AndAlso item IsNot clickedItem Then
                CType(item, ToolStripMenuItem).Checked = False
            End If
        Next
        Dim filePath = Path.Combine(phrasePath, clickedItem.Text)

        If File.Exists(filePath) Then
            Using reader As New StreamReader(filePath, Encoding.UTF8)
                For i = 1 To 20
                    Dim textBoxName As String = $"TextBox{i}"
                    Dim controlStr = phraseForm.Controls.Find(textBoxName, True)
                    If controlStr IsNot Nothing AndAlso TypeOf controlStr(0) Is TextBox Then
                        Dim texBox As TextBox = CType(controlStr(0), TextBox)
                        Dim line = reader.ReadLine()
                        If line IsNot Nothing Then
                            texBox.Text = line.Trim()
                        Else
                            texBox.Text = ""
                        End If
                    End If
                Next
            End Using
        End If

        ' クリックした項目にチェックを付けてSave
        clickedItem.Checked = True
        My.Settings.DefaultPresets = clickedItem.Text
        My.Settings.Save()
    End Sub

    ' シンタックスハイライト変更--------------------------------------------------------------
    Public Sub SelectionItemLang_Click(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If clickedItem.Checked = True Then Return

        ' 他のメニューアイテムのチェックをクリアする
        ClearChecks(LanguageToolStripMenuItem, clickedItem)
        ' フォントを取得
        Dim fontFamily As String = inputForm.TextInput1.Styles(Style.Default).Font
        Dim fontSize As Integer = inputForm.TextInput1.Styles(Style.Default).Size
        If fontSize < 1 Then fontSize = 1

        Dim fontFamily2 As String = chatForm.ChatBox.Styles(Style.Default).Font
        Dim fontSize2 As Integer = chatForm.ChatBox.Styles(Style.Default).Size
        If fontSize2 < 1 Then fontSize2 = 1

        ' Scintillaの初期化
        ScintillaInitialize(fontFamily, fontSize, clickedItem.Text, fontFamily2, fontSize2)

        nowLangueage = clickedItem.Text

        ' クリックした項目にチェックを付けてSave
        clickedItem.Checked = True
        My.Settings.Language = clickedItem.Text
        My.Settings.Save()
    End Sub

    Private Sub ClearChecks(menuItem As ToolStripMenuItem, clickedItem As ToolStripMenuItem)
        For Each item As ToolStripItem In menuItem.DropDownItems
            If TypeOf item Is ToolStripMenuItem AndAlso item IsNot clickedItem Then
                Dim childMenuItem As ToolStripMenuItem = CType(item, ToolStripMenuItem)
                childMenuItem.Checked = False

                ' 再帰的に子階層のメニューアイテムを処理する
                If childMenuItem.HasDropDownItems Then
                    ClearChecks(childMenuItem, clickedItem)
                End If
            End If
        Next
    End Sub

    ' 排他的に選択できる言語メニューアイテムを追加するメソッド--------------------------------------------------------------
    Public Sub AddSelectionItemLang(text As String)
        Dim newItem As New ToolStripMenuItem(text) With {
            .CheckOnClick = False
        }
        AddHandler newItem.Click, AddressOf SelectionItemLang_Click
        ' 新しいToolStripMenuItemを適切な位置に追加
        ' ここでは、直近に追加されたカテゴリ用のToolStripMenuItemに追加しています。
        If text <> "Default" Then
            Dim lastCategoryItem As ToolStripMenuItem = CType(LanguageToolStripMenuItem.DropDownItems(LanguageToolStripMenuItem.DropDownItems.Count - 1), ToolStripMenuItem)
            lastCategoryItem.DropDownItems.Add(newItem)
        Else
            LanguageToolStripMenuItem.DropDownItems.Add(newItem)
        End If
    End Sub
    ' 再起動時の再帰的検索メソッド
    Public Function FindMenuItemByText(parent As ToolStripItem, targetText As String) As ToolStripMenuItem
        If TypeOf parent Is ToolStripMenuItem Then
            Dim parentMenuItem As ToolStripMenuItem = CType(parent, ToolStripMenuItem)
            If parentMenuItem.Text = targetText Then
                Return parentMenuItem
            End If

            For Each child As ToolStripItem In parentMenuItem.DropDownItems
                Dim result As ToolStripMenuItem = FindMenuItemByText(child, targetText)
                If result IsNot Nothing Then
                    Return result
                End If
            Next
        End If

        Return Nothing
    End Function

    ' フォントファミリ変更--------------------------------------------------------------
    Private Sub InputAreaFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputAreaFontToolStripMenuItem.Click
        ' 現在のフォント設定を取得し、FontDialogにセットする
        Dim fontDialogStr As New FontDialog()
        If inputForm.TextInput2.Styles(Style.Default).Size < 1 Then inputForm.TextInput2.Styles(Style.Default).Size = 1
        fontDialogStr.Font = New Font(inputForm.TextInput1.Styles(Style.Default).Font, inputForm.TextInput2.Styles(Style.Default).Size)
        If fontDialogStr.ShowDialog() = DialogResult.OK Then
            Dim fontPartsStr As String() = fontDialogStr.Font.Name.Split(","c)
            inputFontName = fontPartsStr(0).Trim()
            If fontPartsStr.Length = 2 Then
                inputFontSize = CInt(fontPartsStr(1).Trim())
            Else
                inputFontSize = CInt(fontDialogStr.Font.SizeInPoints)
            End If

            If chatForm.ChatBox.Styles(Style.Default).Size < 1 Then chatForm.ChatBox.Styles(Style.Default).Size = 1

            ' 選択されたフォントを、全てのテキストボックスに適用する
            ScintillaInitialize(inputFontName, inputFontSize, nowLangueage, chatForm.ChatBox.Styles(Style.Default).Font, chatForm.ChatBox.Styles(Style.Default).Size)
            My.Settings.InputFontName = inputFontName
            My.Settings.InputFontSize = inputFontSize
            My.Settings.Save()
        End If
    End Sub

    Private Sub PreviewAreaFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewAreaFontToolStripMenuItem.Click
        ' FontDialogを表示して、フォントを選択する
        Dim fontDialogStr As New FontDialog()
        fontDialogStr.Font = previewForm.TextOut.Font
        If fontDialogStr.ShowDialog() = DialogResult.OK Then
            previewForm.TextOut.Font = fontDialogStr.Font
            My.Settings.OutputFont = previewForm.TextOut.Font
        End If
    End Sub

    Private Sub ChatLogFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatLogFontToolStripMenuItem.Click
        Dim fontDialogStr As New FontDialog()
        If chatForm.ChatBox.Styles(Style.Default).Size < 1 Then chatForm.ChatBox.Styles(Style.Default).Size = 1
        fontDialogStr.Font = New Font(chatForm.ChatBox.Styles(Style.Default).Font, chatForm.ChatBox.Styles(Style.Default).Size)
        If fontDialogStr.ShowDialog() = DialogResult.OK Then
            Dim fontPartsStr As String() = fontDialogStr.Font.Name.Split(","c)
            chatFontName = fontPartsStr(0).Trim()
            If fontPartsStr.Length = 2 Then
                chatFontSize = CInt(fontPartsStr(1).Trim())
            Else
                chatFontSize = CInt(fontDialogStr.Font.SizeInPoints)
            End If
            ' 選択されたフォントを、全てのテキストボックスに適用する
            ScintillaInitialize(inputForm.TextInput1.Styles(Style.Default).Font, inputForm.TextInput2.Styles(Style.Default).Size, nowLangueage, chatFontName, chatFontSize)
            My.Settings.ChatFontName = chatFontName
            My.Settings.ChatFontSize = chatFontSize
            My.Settings.Save()
        End If
    End Sub

    ' APIオプション設定--------------------------------------------------------------
    Private Sub APIOptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APIOptionToolStripMenuItem.Click
        Dim optionForm As New Form_Option() ' Form_Optionをインスタンス化

        ShowCenteredDialog(Me, optionForm) ' Form_Optionをモーダルダイアログとして表示

        optionForm.Dispose() ' Form_Optionを破棄
    End Sub

    ' キーボードショートカット入力--------------------------------------------------------------
    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean 'Ctrl、Altキーのオーバーライド
        If keyData = Keys.Return Then
            Return True
        Else
            Return MyBase.IsInputKey(keyData)
        End If
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt AndAlso e.KeyCode >= Keys.NumPad1 AndAlso e.KeyCode <= Keys.NumPad9 Then
            ' Alt + テンキー1～9 の場合
            Dim buttonIndex As Integer = e.KeyCode - Keys.NumPad1 ' ボタンのインデックス
            If buttonIndex < 0 Then
                buttonIndex = 19 ' テンキー0の場合
            End If
            Dim controlStr = phraseForm.Controls.Find($"Button{buttonIndex + 11}", True)
            Dim buttonStr = TryCast(controlStr.FirstOrDefault(), Button) ' ボタンを取得
            buttonStr.PerformClick() ' ボタンをクリックする
        ElseIf e.Control AndAlso e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9 Then
            ' Ctrl + テンキー1～9, 0 の場合
            Dim buttonIndex As Integer = e.KeyCode - Keys.NumPad1 ' ボタンのインデックス
            If buttonIndex < 0 Then
                buttonIndex = 9 ' テンキー0の場合
            End If
            Dim controlStr = phraseForm.Controls.Find($"Button{buttonIndex + 1}", True)
            Dim buttonStr = TryCast(controlStr.FirstOrDefault(), Button) ' ボタンを取得
            buttonStr.PerformClick() ' ボタンをクリックする
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.Enter Then
            inputForm.ButtonPost.BackColor = SystemColors.GradientInactiveCaption
            inputForm.ButtonPost.PerformClick()
            e.SuppressKeyPress = True ' リターンキーの動作をキャンセルする
        ElseIf e.Control AndAlso e.KeyCode = Keys.s Then
            inputForm.ButtonSave.BackColor = SystemColors.GradientInactiveCaption
            inputForm.ButtonSave.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Return Then ' Ctrlが押された場合
            inputForm.ButtonPost.BackColor = Color.FromArgb(53, 55, 64)
            inputForm.ButtonSave.BackColor = Color.FromArgb(53, 55, 64)
        End If
        If e.KeyCode = Keys.S Then ' sが押された場合
            inputForm.ButtonPost.BackColor = Color.FromArgb(53, 55, 64)
            inputForm.ButtonSave.BackColor = Color.FromArgb(53, 55, 64)
        End If
    End Sub

End Class