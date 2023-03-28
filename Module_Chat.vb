﻿Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading.Tasks
Imports Microsoft.Extensions.Configuration
Imports TmCGPTD.Form_Input
Imports TmCGPTD.Form_Chat
Imports ScintillaNET
Imports System.ComponentModel
Imports System.Data.Entity.Core
Imports System.Text.RegularExpressions

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
        Await Task.Run(Sub()
                           chatForm.ChatBox.Invoke(Sub()
                                                       If chatForm.ChatBox.Text = "" AndAlso chatForm.TextBoxTitle.Text = "" Then
                                                           Dim prompt As String = "Please enter the title of new chat."
                                                           Dim title As String = "New Chat"
                                                           Dim defaultResponse As String = ""
                                                           Dim chatTitle As String = InputBox(prompt, title, defaultResponse)
                                                           If chatTitle <> "" Then
                                                               chatForm.TextBoxTitle.Text = chatTitle
                                                           Else
                                                               Return
                                                           End If
                                                       End If
                                                   End Sub)
                       End Sub)

        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() AddLogAsync($"[{postDate.ToString}] by You{Environment.NewLine}")))
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() AddLogAsync(String.Join(Environment.NewLine, recentText).Trim() & Environment.NewLine)))
        Await InsertDatabaseAsync()

        Await StartThinkingAnimationAsync()
        Dim resultMes As String = Await PostChatAsync(recentText)
        Await StopThinkingAnimationAsync()
        Dim resDate As Date = Now
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() AddLogAsync($"[{resDate.ToString}] by ChatGPT", False)))
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() AddLogAsync(resultMes, True)))

        Await InsertDatabaseChatAsync(postDate, resDate, resultMes)

        Dim query As String = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;"
        Dim dT = Await SearchChatDatabaseAsync(query)
        Await chatLogForm.ShowChatSearchResultAsync(dT)

        Await UpdateChatSaysMarkerAsync()
        Await UpdateChatCodeMarkerAsync()
    End Function
    ' チャットログ表示--------------------------------------------------------------
    Public Async Sub AddLogAsync(ByVal data As String, Optional ByVal gptSays As Boolean = False)

        Dim initialLineCount As Integer
        Dim finalLineCount As Integer
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() initialLineCount = chatForm.ChatBox.Lines.Count)) ' data を表示する前の行数を取得
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.AppendText(data & Environment.NewLine))) ' data を表示
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() finalLineCount = chatForm.ChatBox.Lines.Count)) ' data を表示した後の行数を取得

        ' 表示された行の最後まで反復してマーカーを設定
        'If gptSays Then
        'For i As Integer = initialLineCount To finalLineCount - 1
        'Dim currentIndex As Integer = i
        'Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentIndex - 1).MarkerAdd(1)))
        'Next
        'End If
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.GotoPosition(chatForm.ChatBox.Lines(chatForm.ChatBox.Lines.Count).Position)))
        Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.ScrollCaret()))
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
    Public Async Function InitializeChatAsync() As Task
        Await Task.Run(Sub()
                           chatForm.ChatBox.Invoke(Sub()
                                                       Dim prompt As String = "Please enter the title of new chat."
                                                       Dim title As String = "New Chat"
                                                       Dim defaultResponse As String = ""
                                                       Dim chatTitle As String = InputBox(prompt, title, defaultResponse)
                                                       If chatTitle <> "" Then
                                                           chatForm.TextBoxTitle.Text = chatTitle
                                                           conversationHistory = New List(Of Dictionary(Of String, Object))()
                                                           lastRowId = Nothing
                                                           chatForm.ChatBox.Text = ""
                                                       Else
                                                           Return
                                                       End If
                                                   End Sub)
                       End Sub)
    End Function

    ' APIに接続してレスポンス取得--------------------------------------------------------------
    Public conversationHistory As New List(Of Dictionary(Of String, Object)) ' 履歴

    Public Async Function PostChatAsync(chatTextPost As String,
                                    Optional max_tokens As Nullable(Of Integer) = Nothing,
                                    Optional temperature As Nullable(Of Double) = Nothing,
                                    Optional top_p As Nullable(Of Double) = Nothing,
                                    Optional presence_penalty As Nullable(Of Double) = Nothing,
                                    Optional frequency_penalty As Nullable(Of Double) = Nothing,
                                    Optional n As Nullable(Of Integer) = Nothing) As Task(Of String)

        Try
            Dim chatTextRes As String

            Using httpClientStr As New HttpClient()

                httpClientStr.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey())
                httpClientStr.Timeout = TimeSpan.FromSeconds(200)

                ' 現在のユーザーの入力を表すディクショナリ
                Dim userInput As New Dictionary(Of String, Object) From {
                    {"role", "user"},
                    {"content", chatTextPost}
                }

                ' 過去の会話履歴と現在の入力を結合
                conversationHistory.Add(userInput)

                Dim options As New Dictionary(Of String, Object) From {
                    {"model", "gpt-3.5-turbo"},
                    {"messages", conversationHistory}
                }

                ' オプションパラメータを追加
                If temperature.HasValue Then options.Add("temperature", temperature.Value)
                If max_tokens.HasValue Then options.Add("max_tokens", max_tokens.Value)
                If top_p.HasValue Then options.Add("top_p", top_p.Value)
                If presence_penalty.HasValue Then options.Add("presence_penalty", presence_penalty.Value)
                If frequency_penalty.HasValue Then options.Add("frequency_penalty", frequency_penalty.Value)
                If n.HasValue Then options.Add("n", n.Value)

                Dim jsonContent As String = JsonSerializer.Serialize(options)

                Dim content As New StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json")

                'form2.AddLog($"JSON : {jsonContent}") 'Json生データ出力

                Dim response As HttpResponseMessage = Await httpClientStr.PostAsync("https://api.openai.com/v1/chat/completions", content)

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
                Else
                    Dim errorBody As String = Await response.Content.ReadAsStringAsync()
                    Return $"Error: Response status code does not indicate success: {response.StatusCode} ({response.ReasonPhrase}). Response body: {errorBody}"
                End If

            End Using

            Return chatTextRes

            ' 応答を受け取った後、conversationHistory に追加
            conversationHistory.Add(New Dictionary(Of String, Object) From {{"role", "assistant"}, {"content", chatTextRes}})

        Catch ex As Exception
            Return $"Error: {ex.Message & Environment.NewLine}"
        End Try
    End Function

    Private WithEvents thinkTimer As New System.Windows.Forms.Timer()
    Private thinkCounter As Integer = 0

    Private Async Function StartThinkingAnimationAsync() As Task
        thinkTimer.Interval = 400 'アニメーションの速度
        thinkCounter = 0
        Await Task.Run(Sub() chatForm.ChatBox.BeginInvoke(Sub() chatForm.ChatBox.AddText("AI: ")))
        thinkTimer.Start()
    End Function

    Private Async Function StopThinkingAnimationAsync() As Task
        Await UpdateMessageAsync("")
        thinkTimer.Stop()
    End Function

    Private Async Sub thinkTimer_TickAsync(ByVal sender As Object, ByVal e As System.EventArgs) Handles thinkTimer.Tick
        Dim thinkingText As String = "Now thinking"
        Dim thinkAnim As String() = {". _", ".. -", "... |", ".... /"}
        ' ローディングアイコンを回転させる
        thinkingText &= " " & thinkAnim(thinkCounter Mod 4)

        'For i = 0 To thinkCounter Mod 3
        'thinkingText &= "."
        'Next

        Await UpdateMessageAsync("AI: " & thinkingText)
        thinkCounter += 1
    End Sub
    Private Async Function UpdateMessageAsync(thinkingText As String) As Task
        Await Task.Run(Sub()
                           chatForm.ChatBox.BeginInvoke(Sub()
                                                            ' 最後の行のインデックスを取得
                                                            Dim lastLineIndex As Integer = chatForm.ChatBox.Lines.Count - 1
                                                            ' 最後の行の開始位置と長さを取得
                                                            Dim lastLineStartPos As Integer = chatForm.ChatBox.Lines(lastLineIndex).Position
                                                            Dim lastLineLength As Integer = chatForm.ChatBox.Lines(lastLineIndex).Length
                                                            ' 最後の行を新しいテキストで置き換える
                                                            chatForm.ChatBox.DeleteRange(lastLineStartPos, lastLineLength)
                                                            chatForm.ChatBox.InsertText(lastLineStartPos, thinkingText)
                                                        End Sub)
                       End Sub)
    End Function

End Class
