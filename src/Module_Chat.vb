Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading.Tasks
Imports Microsoft.Extensions.Configuration
Imports TmCGPTD.Form_Input
Imports TmCGPTD.Form_Chat
Imports ScintillaNET
Imports System.ComponentModel
Imports System.Data.Entity.Core
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

Partial Public Class Form1
    Private Function GetApiKey() As String
        Dim configuration = New ConfigurationBuilder() _
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) _
        .AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True) _
        .Build()

        Return configuration("OpenAI:ApiKey")
    End Function

    Public Async Function GoChatAsync() As Task
        Dim postDate As Date = Now
        If chatForm.ChatBox.Text = "" AndAlso chatForm.TextBoxTitle.Text = "" Then
            If InitializeChat() = "" Then
                Return
            End If
        End If

        AddLog($"[{postDate.ToString}] by You{Environment.NewLine}{Environment.NewLine}{String.Join(Environment.NewLine, recentText).Trim() & Environment.NewLine}")

        If EditorLogAutoSaveToolStripMenuItem.Checked = True Then Await InsertDatabaseAsync()

        StartThinkingAnimation()
        Dim resultMes As String = Await PostChatAsync(recentText)
        StopThinkingAnimation()
        Dim resDate As Date = Now

        AddLog($"[{resDate.ToString}] by ChatGPT{Environment.NewLine}{resultMes}")
        'AddLogAsync(resultMes, True)

        Await InsertDatabaseChatAsync(postDate, resDate, resultMes)

        Dim query As String = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
        Dim dT = Await SearchChatDatabaseAsync(query)
        Await chatLogForm.ShowChatSearchResultAsync(dT)

        Await UpdateChatSaysMarkerAsync()
        Await UpdateChatCodeMarkerAsync()
    End Function

    ' チャットログ表示--------------------------------------------------------------
    Public Sub AddLog(ByVal data As String, Optional ByVal gptSays As Boolean = False)

        Dim initialLineCount As Integer
        Dim finalLineCount As Integer
        initialLineCount = chatForm.ChatBox.Lines.Count ' data を表示する前の行数を取得
        chatForm.ChatBox.AppendText(data & Environment.NewLine) ' data を表示
        finalLineCount = chatForm.ChatBox.Lines.Count ' data を表示した後の行数を取得

        ' 表示された行の最後まで反復してマーカーを設定
        'If gptSays Then
        'For i As Integer = initialLineCount To finalLineCount - 1
        'Dim currentIndex As Integer = i
        'Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentIndex - 1).MarkerAdd(1)))
        'Next
        'End If
        chatForm.ChatBox.GotoPosition(chatForm.ChatBox.Lines(chatForm.ChatBox.Lines.Count).Position)
        chatForm.ChatBox.ScrollCaret()
    End Sub

    ' チャットのAI背景色設定--------------------------------------------------------------
    Public Async Function UpdateChatSaysMarkerAsync() As Task
        Dim pattern As String = "(.+by ChatGPT\r\n)((?:(?!by You).|[\r\n])+)"
        Dim regex As New Regex(pattern, RegexOptions.Multiline)

        ' チャット履歴を取得
        Dim chatHistory As String = ""
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatHistory = chatForm.ChatBox.Text))

        For Each match As Match In regex.Matches(chatHistory)
            Dim [start] As Integer = match.Index
            Dim [end] As Integer = match.Index + match.Length

            Dim startLine As Integer
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() startLine = chatForm.ChatBox.LineFromPosition([start])))
            Dim endLine As Integer
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() endLine = chatForm.ChatBox.LineFromPosition([end])))

            For line As Integer = startLine To endLine - 1
                Dim currentLine As Integer = line
                Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentLine).MarkerAdd(1)))
            Next

        Next
    End Function

    ' チャットのコードスニペット背景色設定--------------------------------------------------------------
    Public Async Function UpdateChatCodeMarkerAsync(Optional ByVal searchKey As String = "") As Task
        Dim pattern As String = "(```)([\w-.]*\r?\n)((?:(?!^```|\r?\n).|\r?\n)*?)(^```)"
        Dim rx As New Regex(pattern, RegexOptions.Multiline)

        ' チャット履歴を取得
        Dim chatHistory As String = ""
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatHistory = chatForm.ChatBox.Text))
        ' コードスニペットの範囲を検索
        For Each match As Match In rx.Matches(chatHistory)
            ' コードスニペットの開始位置と終了位置を取得
            Dim [start] As Integer = match.Index
            Dim [end] As Integer = match.Index + match.Length

            ' コードスニペットの開始位置と終了位置を行番号に変換
            Dim startLine As Integer
            Dim endLine As Integer
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() startLine = chatForm.ChatBox.LineFromPosition([start])))
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() endLine = chatForm.ChatBox.LineFromPosition([end])))

            ' コードスニペットの範囲にマーカー2を設定
            For line As Integer = startLine To endLine
                Dim currentLine As Integer = line
                Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentLine).MarkerDelete(1)))
                Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentLine).MarkerAdd(2)))
            Next

        Next
        searchKey = chatLogForm.TextBoxSearch.Text.Trim()
        If Not searchKey = "" Then
            chatForm.TextBoxChatTextSearch.Text = searchKey
            chatForm.ButtonDown_Click(searchKey, EventArgs.Empty)
        Else
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.GotoPosition(chatForm.ChatBox.Lines(chatForm.ChatBox.Lines.Count).Position)))
            Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.ScrollCaret()))
        End If

    End Function

    ' チャットまとめて表示--------------------------------------------------------------
    Public Async Function ShowChatLogAsync(result As List(Of String), Optional ByVal searchKey As String = "") As Task
        Await Task.Run(Sub() chatForm.TextBoxTitle.Invoke(Sub() chatForm.TextBoxTitle.Text = result(0))) ' タイトル

        Dim tags() As String = Split(result(1), Environment.NewLine) ' タグを分割して各ボックスへ
        Await Task.Run(Sub() chatForm.TextBoxTag1.Invoke(Sub() chatForm.TextBoxTag1.Text = tags(0)))
        If tags.Length > 1 Then Await Task.Run(Sub() chatForm.TextBoxTag2.Invoke(Sub() chatForm.TextBoxTag2.Text = tags(1)))
        If tags.Length > 2 Then Await Task.Run(Sub() chatForm.TextBoxTag3.Invoke(Sub() chatForm.TextBoxTag3.Text = tags(2)))

        Await Task.Run(Sub() conversationHistory = JsonSerializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(result(2))) ' 会話履歴を格納

        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Text = result(3) & Environment.NewLine)) ' 本文更新

        ' 背景色マーカー更新
        Await UpdateChatSaysMarkerAsync()
        If Not searchKey = "" Then
            Await UpdateChatCodeMarkerAsync(searchKey)
        Else
            Await UpdateChatCodeMarkerAsync()
        End If
    End Function

    ' 新しいチャットを初期化--------------------------------------------------------------
    Public Function InitializeChat() As String
        Dim customDialog As New Form_NewChat()
        ' ダイアログのStartPositionプロパティをManualに設定
        customDialog.StartPosition = FormStartPosition.Manual
        ' ダイアログの位置をメインフォームの中央に設定
        customDialog.Location = New Point(
            Me.Location.X + (Me.Width - customDialog.Width) \ 2,
            Me.Location.Y + (Me.Height - customDialog.Height) \ 2)
        If customDialog.ShowDialog() = DialogResult.OK Then
            Dim enteredText As String = customDialog.EnteredText
            customDialog.Dispose()

            If enteredText <> "" Then
                chatForm.TextBoxTitle.Text = enteredText
                conversationHistory = New List(Of Dictionary(Of String, Object))()
                lastRowId = Nothing
                chatForm.ChatBox.Text = ""
                Return enteredText
            Else
                Return ""
            End If

        Else
            Return ""
        End If
    End Function

    ' APIに接続してレスポンス取得--------------------------------------------------------------
    Public conversationHistory As New List(Of Dictionary(Of String, Object)) ' 履歴

    Public Async Function PostChatAsync(chatTextPost As String) As Task(Of String)

        Try
            Dim chatTextRes As String

            Using httpClientStr As New HttpClient()

                httpClientStr.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey())
                httpClientStr.Timeout = TimeSpan.FromSeconds(200)

                ' 過去の会話履歴と現在の入力を結合する前に、過去の会話履歴に含まれるcontent文字列の文字数を取得
                Dim historyContentLength As Integer = conversationHistory.Sum(Function(d) d("content").ToString().Length)
                ' 削除前の文字数を記録
                Dim preDeleteHistoryLength As Integer = historyContentLength

                ' 現在のユーザーの入力を表すディクショナリ
                Dim userInput As New Dictionary(Of String, Object) From {
                     {"role", "user"},
                     {"content", chatTextPost}
                }

                ' もし、過去の会話履歴と現在の入力を結合して制限文字数を超える場合は、会話履歴のuserとassistantのJSONデータを一組分、古いものから削除する
                While historyContentLength + chatTextPost.Length > MAX_CONTENT_LENGTH
                    If conversationHistory.Count = 0 Then
                        ' 会話履歴がないのに、文字数が制限文字数を超える場合は、何もしないで処理を中止する
                        Return $"Error: The total length of conversation history ({historyContentLength + chatTextPost.Length} characters) exceeded the maximum content length ({MAX_CONTENT_LENGTH} characters). Please reduce the input by {historyContentLength + chatTextPost.Length - MAX_CONTENT_LENGTH} characters."

                    End If
                    Dim oldestConversation As Dictionary(Of String, Object) = conversationHistory.First()
                    If oldestConversation("role").ToString() = "assistant" Then
                        ' 最初の会話履歴がassistantだった場合は、次のassistantのデータが出るまで削除する
                        Do
                            conversationHistory.RemoveAt(0)
                            historyContentLength = conversationHistory.Sum(Function(d) d("content").ToString().Length)
                            If conversationHistory.Count = 0 Then
                                ' 会話履歴がなくなった場合は、処理を中止する
                                Return "Error: There is no conversation history left, but the character count still exceeds the limit. Please ensure your input is within the allowed character limit."

                            End If
                        Loop Until conversationHistory.First()("role").ToString() = "assistant"
                    End If
                    ' 最も古い会話履歴を削除する
                    conversationHistory.RemoveAt(0)
                    historyContentLength = conversationHistory.Sum(Function(d) d("content").ToString().Length)
                End While

                ' 過去の会話履歴と現在の入力を結合
                conversationHistory.Add(userInput)

                Dim options As New Dictionary(Of String, Object) From {
                    {"model", api_model},
                    {"messages", conversationHistory}
                }

                ' オプションパラメータを追加
                If api_max_tokens.HasValue Then options.Add("max_tokens", api_max_tokens.Value)
                If api_temperature.HasValue Then options.Add("temperature", api_temperature.Value)
                If api_top_p.HasValue Then options.Add("top_p", api_top_p.Value)
                If api_n.HasValue Then options.Add("n", api_n.Value)
                If api_logprobs.HasValue Then options.Add("logprobs", api_logprobs.Value)
                If api_presence_penalty.HasValue Then options.Add("presence_penalty", api_presence_penalty.Value)
                If api_frequency_penalty.HasValue Then options.Add("frequency_penalty", api_frequency_penalty.Value)
                If api_best_of.HasValue Then options.Add("best_of", api_best_of.Value)

                ' api_stop パラメータの処理
                If Not String.IsNullOrEmpty(api_stop) Then
                    Dim stopSequence() As String = api_stop.Split(","c)
                    options.Add("stop", stopSequence)
                End If

                ' api_logit_bias パラメータの処理
                If Not String.IsNullOrEmpty(api_logit_bias) Then
                    Dim logitBias As Dictionary(Of String, Double) = JsonSerializer.Deserialize(Of Dictionary(Of String, Double))(api_logit_bias)
                    options.Add("logit_bias", logitBias)
                End If

                Dim jsonContent As String = JsonSerializer.Serialize(options)

                Dim content As New StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = Await httpClientStr.PostAsync(api_url, content)

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Dim responseJson As JsonElement = JsonSerializer.Deserialize(Of JsonElement)(responseBody)
                    ' レス本文
                    chatTextRes = Environment.NewLine & responseJson.GetProperty("choices")(0).GetProperty("message").GetProperty("content").GetString().Trim & Environment.NewLine & Environment.NewLine
                    ' usageプロパティだけ取得する
                    Dim usageProperty As JsonElement
                    If responseJson.TryGetProperty("usage", usageProperty) Then
                        Dim usageValue As String = usageProperty.ToString()
                        chatTextRes &= $"usage={usageValue}" & Environment.NewLine
                    End If

                    '下記は全プロパティ取得ver.
                    'For Each prop As JsonProperty In responseJson.EnumerateObject()
                    'If prop.Name <> "choices" Then
                    'Dim propValue As String = prop.Value.ToString()
                    'chatTextRes &= $"{prop.Name}={propValue}" & Environment.NewLine
                    'End If
                    'Next

                    ' 応答を受け取った後、conversationHistory に追加
                    conversationHistory.Add(New Dictionary(Of String, Object) From {{"role", "assistant"}, {"content", chatTextRes}})
                    ' 削除が実行された場合、メソッドの戻り値の最後に削除前の文字数と削除後の文字数をメッセージとして付け加える
                    If preDeleteHistoryLength > historyContentLength Then
                        chatTextRes &= $"-Conversation history has been truncated. Char-before: {preDeleteHistoryLength}, after: {historyContentLength}.{Environment.NewLine}"
                    End If

                Else
                    Dim errorBody As String = Await response.Content.ReadAsStringAsync()
                    Return $"Error: Response status code does not indicate success: {response.StatusCode} ({response.ReasonPhrase}). Response body: {errorBody}"
                End If

            End Using

            Return chatTextRes

        Catch ex As Exception
            Return $"Error: {ex.Message & Environment.NewLine}"
        End Try
    End Function

    Private WithEvents thinkTimer As New System.Windows.Forms.Timer()
    Private thinkCounter As Integer = 0

    Private Sub StartThinkingAnimation()
        thinkTimer.Interval = 400 'アニメーションの速度
        thinkCounter = 0
        chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.AddText("AI: "))
        thinkTimer.Start()
    End Sub

    Private Sub StopThinkingAnimation()
        UpdateMessage("")
        thinkTimer.Stop()
    End Sub

    Private Sub thinkTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles thinkTimer.Tick
        Dim thinkingText As String = "Now thinking"
        Dim thinkAnim As String() = {". _", ".. -", "... |", ".... /"}
        ' ローディングアイコンを回転させる
        thinkingText &= " " & thinkAnim(thinkCounter Mod 4)

        'For i = 0 To thinkCounter Mod 3
        'thinkingText &= "."
        'Next

        UpdateMessage("AI: " & thinkingText)
        thinkCounter += 1
    End Sub

    Private Sub UpdateMessage(thinkingText As String)
        chatForm.ChatBox.Invoke(Sub()
                                    ' 最後の行のインデックスを取得
                                    Dim lastLineIndex As Integer = chatForm.ChatBox.Lines.Count - 1
                                    ' 最後の行の開始位置と長さを取得
                                    Dim lastLineStartPos As Integer = chatForm.ChatBox.Lines(lastLineIndex).Position
                                    Dim lastLineLength As Integer = chatForm.ChatBox.Lines(lastLineIndex).Length
                                    ' 最後の行を新しいテキストで置き換える
                                    chatForm.ChatBox.DeleteRange(lastLineStartPos, lastLineLength)
                                    chatForm.ChatBox.InsertText(lastLineStartPos, thinkingText)
                                End Sub)
    End Sub


End Class
