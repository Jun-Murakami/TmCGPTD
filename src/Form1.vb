Imports System.Data.SQLite
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Reflection
Imports WeifenLuo.WinFormsUI.Docking
Imports TmCGPTD.Form_Input
Imports TmCGPTD.Form_Preview
Imports TmCGPTD.Form_ChatLog
Imports System.Threading
Imports System.Data.Entity.Core
Imports WeifenLuo.WinFormsUI.ThemeVS2015

Public Class Form1

    Public Shared phrasePath As String = Path.Combine(Application.StartupPath, "phrase_presets") 'フレーズプリセットパス
    Public Shared dbPath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "log.db") ' DBパス
    Public Shared dbBuPath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "log_buckup.db") ' DBバックアップパス
    Public Shared xmlFilePath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Syntax_Setting.xml") ' XMLファイルのパス
    Public Shared memoryConnection As SQLiteConnection ' メモリ上のSQLコネクション
    Public Shared inputFontName As String = "Default" ' デフォルトフォント
    Public Shared inputFontSize As Integer = 11 ' デフォルトフォントサイズ
    Public Shared chatFontName As String = "Default" ' デフォルトフォント
    Public Shared chatFontSize As Integer = 11 ' デフォルトフォントサイズ
    Public Shared nowLangueage As String = "default" '現在の選択言語
    Public cts As New CancellationTokenSource() 'キャンセレーショントークン
    Public chatForm As New Form_Chat() ' formをインスタンス化
    Public inputForm As New Form_Input()
    Public previewForm As New Form_Preview()
    Public chatLogForm As New Form_ChatLog()
    Public phraseForm As New Form_Phrase()
    'APIパラメータ初期化
    Public Shared api_max_tokens As Integer? = If(My.Settings.max_tokens = "Nothing", New Integer?(), Integer.Parse(My.Settings.max_tokens))
    Public Shared api_temperature As Double? = If(My.Settings.temperature = "Nothing", New Double?(), Double.Parse(My.Settings.temperature))
    Public Shared api_top_p As Double? = If(My.Settings.top_p = "Nothing", New Double?(), Double.Parse(My.Settings.top_p))
    Public Shared api_n As Integer? = If(My.Settings.n = "Nothing", New Integer?(), Integer.Parse(My.Settings.n))
    Public Shared api_logprobs As Integer? = If(My.Settings.logprobs = "Nothing", New Integer?(), Integer.Parse(My.Settings.logprobs))
    Public Shared api_presence_penalty As Double? = If(My.Settings.presence_penalty = "Nothing", New Double?(), Double.Parse(My.Settings.presence_penalty))
    Public Shared api_frequency_penalty As Double? = If(My.Settings.frequency_penalty = "Nothing", New Double?(), Double.Parse(My.Settings.frequency_penalty))
    Public Shared api_best_of As Integer? = If(My.Settings.best_of = "Nothing", New Integer?(), Integer.Parse(My.Settings.best_of))
    Public Shared api_stop As String = My.Settings.stop
    Public Shared api_logit_bias As String = My.Settings.logit_bias
    Public Shared api_model As String = My.Settings.model
    Public Shared api_url As String = My.Settings.url



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Cursor = Cursors.WaitCursor '処理中を示すWaitCursorを表示

        ' MainFormインスタンスを設定
        inputForm.MainFormInst = Me
        previewForm.MainFormInst = Me
        chatForm.MainFormInst = Me
        chatLogForm.MainFormInst = Me
        phraseForm.MainFormInst = Me

        DockPanel1.Theme = New VS2015LightTheme

        ' ドック状態の復元
        Dim dockStateFilePath As String = Path.Combine(Application.StartupPath, "DockState.xml")
        If File.Exists(dockStateFilePath) Then
            DockPanel1.LoadFromXml(dockStateFilePath, AddressOf DeserializeDockContent)
        Else
            ' 初回起動時のデフォルトレイアウト
            LoadDefaultDockLayout()
        End If

        ' 各種初回起動チェック＆初期化処理
        If Not Directory.Exists(phrasePath) Then Directory.CreateDirectory(phrasePath)
        If Not File.Exists(dbPath) Then CreateDatabase()
        If Not TableExists("chatlog") Then CreateDatabaseChat()

        ' 定型句読み込み
        For Each file In Directory.GetFiles(phrasePath, "*.txt")
            AddSelectionItem(Path.GetFileName(file))
        Next

        WindowInitialize() ' ウインドウ初期化
        ChangeControlColor() ' 部品色初期化
        chatLogForm.InitializeDataTable() ' データテーブル初期化
        DbLoadToMemory() ' データベースをインメモリに読み込み


        'Me.Cursor = Cursors.Default ' カーソルをデフォルトに戻す
    End Sub
    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FocusRun() ' カーソルちらつき防止

        ' DBからエディターログ初期表示
        Dim query As String = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 30"
        Await SearchDatabaseAsync(query)

        ' DBからチャットログ初期表示
        query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
        Dim dT = Await SearchChatDatabaseAsync(query)
        Await chatLogForm.ShowChatSearchResultAsync(dT)
        Dim rowsCount As New Integer
        Await Task.Run(Sub() chatLogForm.DataGrid.BeginInvoke(Sub() rowsCount = chatLogForm.DataGrid.Rows.Count))
        If rowsCount > 0 Then
            Dim chatId As New Integer
            Await Task.Run(Sub() chatLogForm.DataGrid.BeginInvoke(Sub() chatId = CInt(chatLogForm.DataGrid.Rows(0).Cells("chatId").Value)))
            query = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}"
            Dim result = Await PickChatDatabaseAsync(query)
            Await ShowChatLogAsync(result)
            lastRowId = chatId
        End If
    End Sub

    ' ウィンドウ初期化--------------------------------------------------------------
    Private Sub WindowInitialize()

        ' XMLが存在しない場合に、リソースからファイルをコピー
        If Not File.Exists(xmlFilePath) Then
            Dim currentAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim resourceName As String = "TmCGPTD.Resources.Syntax_Setting.xml"
            Using resourceStream As Stream = currentAssembly.GetManifestResourceStream(resourceName)
                If resourceStream IsNot Nothing Then
                    Using fileStream As New FileStream(xmlFilePath, FileMode.CreateNew, FileAccess.Write)
                        resourceStream.CopyTo(fileStream)
                    End Using
                Else
                    MessageBox.Show("XML resource is not found.: " & resourceName)
                End If
            End Using
        End If

        ' カテゴリごとにメニュー項目を追加する
        Try
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
            Dim settings As XmlReaderSettings = New XmlReaderSettings()
            Dim context = New XmlParserContext(nt:=Nothing, nsMgr:=Nothing, xmlLang:=Nothing, XmlSpace.None)
            'context.Encoding = Encoding.GetEncoding(1252)
            Using reader As XmlReader = XmlReader.Create(xmlFilePath, settings, context)
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(reader)

                Dim categoryNodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("//Category")

                For Each categoryNode As XmlNode In categoryNodes
                    Dim categoryName As String = categoryNode.Attributes("name").Value
                    If categoryName <> "Default" Then LanguageToolStripMenuItem.DropDownItems.Add(categoryName)

                    Dim languageNodes As XmlNodeList = categoryNode.SelectNodes("LexerType")

                    For Each languageNode As XmlNode In languageNodes
                        Dim languageName As String = languageNode.Attributes("desc").Value
                        AddSelectionItemLang(languageName)
                    Next
                Next

            End Using
        Catch ex As Exception
            MessageBox.Show($"XML load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Not My.Settings.WindowPosition.X = -1 Then
            ' My.Settingsからウィンドウの位置とサイズ、フォントを取得して再現する
            Me.Location = My.Settings.WindowPosition
            Me.Size = My.Settings.WindowSize
        End If

        EditorLogAutoSaveToolStripMenuItem.Checked = My.Settings.AutoSave

        Me.KeyPreview = True ' KeyPreview プロパティを True に設定

    End Sub

    ' 終了処理--------------------------------------------------------------
    Private Sub SaveSetting()
        cts.Cancel() ' キャンセレーション発動

        ' ドック状態を保存する（実ファイル版）
        Dim dockStateFilePath As String = Path.Combine(Application.StartupPath, "DockState.xml")
        Try
            DockPanel1.SaveAsXml(dockStateFilePath)
        Catch
        End Try

        ' 画面設定をMy.Settingsに保存する
        My.Settings.WindowPosition = Me.Location
        My.Settings.WindowSize = Me.Size
        My.Settings.Zoom1 = inputForm.TextInput1.Zoom
        My.Settings.Zoom2 = inputForm.TextInput2.Zoom
        My.Settings.Zoom3 = inputForm.TextInput3.Zoom
        My.Settings.Zoom4 = inputForm.TextInput4.Zoom
        My.Settings.Zoom5 = inputForm.TextInput5.Zoom
        My.Settings.ZoomChat = chatForm.ChatBox.Zoom

        My.Settings.Save()

        Application.Exit()
    End Sub

    ' Dockレイアウト--------------------------------------------------------------
    Private Sub LoadDefaultDockLayout()
        ' 現在のレイアウトをクリア
        DockPanel1.SuspendLayout(True)
        For Each window As IDockContent In DockPanel1.Contents.ToList()
            window.DockHandler.DockPanel = Nothing
        Next

        ' 新しいレイアウトをロード
        'DockPanel1.Theme = New VS2015LightTheme
        Dim defaultLayoutXml As String = My.Resources.DefaultDockState
        Using stream As New MemoryStream(Encoding.Unicode.GetBytes(defaultLayoutXml))
            DockPanel1.LoadFromXml(stream, AddressOf DeserializeDockContent)
        End Using
        DockPanel1.ResumeLayout(True, True)

        Dim dpiScaleFactor As Single = CreateGraphics().DpiX / 96.0F
        DockPanel1.DockBottomPortion = DockPanel1.DockBottomPortion * dpiScaleFactor
    End Sub

    ' DeserializeDockContent メソッドを実装して、適切な DockContent インスタンスを返すようにします。
    Private Function DeserializeDockContent(persistentString As String) As IDockContent
        If persistentString = GetType(Form_Chat).ToString() Then
            Return chatForm
        ElseIf persistentString = GetType(Form_Input).ToString() Then
            Return inputForm
        ElseIf persistentString = GetType(Form_Preview).ToString() Then
            Return previewForm
        ElseIf persistentString = GetType(Form_ChatLog).ToString() Then
            Return chatLogForm
        ElseIf persistentString = GetType(Form_Phrase).ToString() Then
            Return phraseForm
        End If

        Return Nothing
    End Function

    ' MainForm内でインスタンスを公開するプロパティを追加--------------------------------------------------------------
    Public ReadOnly Property MainFormPreviewForm As Form_Preview
        Get
            Return previewForm
        End Get
    End Property
    Public ReadOnly Property MainFormInputForm As Form_Input
        Get
            Return inputForm
        End Get
    End Property
    Public ReadOnly Property MainFormChatForm As Form_Chat
        Get
            Return chatForm
        End Get
    End Property

    Public ReadOnly Property MainFormChatLogForm As Form_ChatLog
        Get
            Return chatLogForm
        End Get
    End Property

    Public ReadOnly Property MainFormPhraseForm As Form_Phrase
        Get
            Return phraseForm
        End Get
    End Property

End Class