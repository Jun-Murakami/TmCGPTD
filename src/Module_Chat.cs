using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using static TmCGPTD.Form_Input;

namespace TmCGPTD
{

    public partial class Form1
    {
        private string GetApiKey()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();



            return configuration["OpenAI:ApiKey"];
        }

        public async Task GoChatAsync()
        {
            var postDate = DateTime.Now;
            if (string.IsNullOrEmpty(chatForm.ChatBox.Text) && string.IsNullOrEmpty(chatForm.TextBoxTitle.Text))
            {
                if (string.IsNullOrEmpty(InitializeChat()))
                {
                    return;
                }
            }

            AddLog($"[{postDate.ToString()}] by You{Environment.NewLine}{Environment.NewLine}{string.Join(Environment.NewLine, recentText).Trim() + Environment.NewLine}");

            if (EditorLogAutoSaveToolStripMenuItem.Checked == true)
                await InsertDatabaseAsync();

            StartThinkingAnimation();
            string resultMes = await PostChatAsync(recentText);
            StopThinkingAnimation();
            var resDate = DateTime.Now;

            AddLog($"[{resDate.ToString()}] by ChatGPT{Environment.NewLine}{resultMes}");
            // AddLogAsync(resultMes, True)

            await InsertDatabaseChatAsync(postDate, resDate, resultMes);

            string query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
            var dT = await SearchChatDatabaseAsync(query);
            await chatLogForm.ShowChatSearchResultAsync(dT);

            await UpdateChatSaysMarkerAsync();
            await UpdateChatCodeMarkerAsync();
        }

        // チャットログ表示--------------------------------------------------------------
        public void AddLog(string data, bool gptSays = false)
        {

            int initialLineCount;
            int finalLineCount;
            initialLineCount = chatForm.ChatBox.Lines.Count; // data を表示する前の行数を取得
            chatForm.ChatBox.AppendText(data + Environment.NewLine); // data を表示
            finalLineCount = chatForm.ChatBox.Lines.Count; // data を表示した後の行数を取得

            // 表示された行の最後まで反復してマーカーを設定
            // If gptSays Then
            // For i As Integer = initialLineCount To finalLineCount - 1
            // Dim currentIndex As Integer = i
            // Await Task.Run(Sub() chatForm.ChatBox.Invoke(Sub() chatForm.ChatBox.Lines(currentIndex - 1).MarkerAdd(1)))
            // Next
            // End If
            chatForm.ChatBox.GotoPosition(chatForm.ChatBox.Lines[chatForm.ChatBox.Lines.Count].Position);
            chatForm.ChatBox.ScrollCaret();
        }

        // チャットのAI背景色設定--------------------------------------------------------------
        public async Task UpdateChatSaysMarkerAsync()
        {
            string pattern = @"(.+by ChatGPT\r\n)((?:(?!by You).|[\r\n])+)";
            var regex = new Regex(pattern, RegexOptions.Multiline);

            // チャット履歴を取得
            string chatHistory = "";
            await Task.Run(() => chatForm.ChatBox.Invoke(() => chatHistory = chatForm.ChatBox.Text));

            var startLine = default(int);
            var endLine = default(int);
            foreach (Match match in regex.Matches(chatHistory))
            {
                int start = match.Index;
                int end = match.Index + match.Length;
                await Task.Run(() => chatForm.ChatBox.Invoke(() => startLine = chatForm.ChatBox.LineFromPosition(start)));
                await Task.Run(() => chatForm.ChatBox.Invoke(() => endLine = chatForm.ChatBox.LineFromPosition(end)));

                for (int line = startLine, loopTo = endLine - 1; line <= loopTo; line++)
                {
                    int currentLine = line;
                    await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.Lines[currentLine].MarkerAdd(1)));
                }

            }
        }

        // チャットのコードスニペット背景色設定--------------------------------------------------------------
        public async Task UpdateChatCodeMarkerAsync(string searchKey = "")
        {
            string pattern = @"(```)([\w-+.]*\r?\n)((?:(?!^```|\r?\n).|\r?\n)*?)(^```)";
            var rx = new Regex(pattern, RegexOptions.Multiline);

            // チャット履歴を取得
            string chatHistory = "";
            await Task.Run(() => chatForm.ChatBox.Invoke(() => chatHistory = chatForm.ChatBox.Text));
            // コードスニペットの範囲を検索
            var startLine = default(int);
            var endLine = default(int);
            foreach (Match match in rx.Matches(chatHistory))
            {
                // コードスニペットの開始位置と終了位置を取得
                int start = match.Index;

                // コードスニペットの開始位置と終了位置を行番号に変換
                int end = match.Index + match.Length;
                await Task.Run(() => chatForm.ChatBox.Invoke(() => startLine = chatForm.ChatBox.LineFromPosition(start)));
                await Task.Run(() => chatForm.ChatBox.Invoke(() => endLine = chatForm.ChatBox.LineFromPosition(end)));

                // コードスニペットの範囲にマーカー2を設定
                for (int line = startLine, loopTo = endLine; line <= loopTo; line++)
                {
                    int currentLine = line;
                    await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.Lines[currentLine].MarkerDelete(1)));
                    await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.Lines[currentLine].MarkerAdd(2)));
                }

            }
            searchKey = chatLogForm.TextBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchKey))
            {
                chatForm.TextBoxChatTextSearch.Text = searchKey;
                chatForm.ButtonDown_Click(searchKey, EventArgs.Empty);
            }
            else
            {
                await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.GotoPosition(chatForm.ChatBox.Lines[chatForm.ChatBox.Lines.Count].Position)));
                await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.ScrollCaret()));
            }

        }

        // チャットまとめて表示--------------------------------------------------------------
        public async Task ShowChatLogAsync(List<string> result, string searchKey = "")
        {
            await Task.Run(() => chatForm.TextBoxTitle.Invoke(() => chatForm.TextBoxTitle.Text = result[0])); // タイトル

            string[] tags = Strings.Split(result[1], Environment.NewLine); // タグを分割して各ボックスへ
            await Task.Run(() => chatForm.TextBoxTag1.Invoke(() => chatForm.TextBoxTag1.Text = tags[0]));
            if (tags.Length > 1)
                await Task.Run(() => chatForm.TextBoxTag2.Invoke(() => chatForm.TextBoxTag2.Text = tags[1]));
            if (tags.Length > 2)
                await Task.Run(() => chatForm.TextBoxTag3.Invoke(() => chatForm.TextBoxTag3.Text = tags[2]));

            await Task.Run(() => conversationHistory = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(result[2])); // 会話履歴を格納

            await Task.Run(() => chatForm.ChatBox.Invoke(() => chatForm.ChatBox.Text = result[3] + Environment.NewLine)); // 本文更新

            // 背景色マーカー更新
            await UpdateChatSaysMarkerAsync();
            if (!string.IsNullOrEmpty(searchKey))
            {
                await UpdateChatCodeMarkerAsync(searchKey);
            }
            else
            {
                await UpdateChatCodeMarkerAsync();
            }
        }

        // 新しいチャットを初期化--------------------------------------------------------------
        public string InitializeChat()
        {
            var customDialog = new Form_NewChat();
            // ダイアログのStartPositionプロパティをManualに設定
            customDialog.StartPosition = FormStartPosition.Manual;
            // ダイアログの位置をメインフォームの中央に設定
            customDialog.Location = new Point(Location.X + (Width - customDialog.Width) / 2, Location.Y + (Height - customDialog.Height) / 2);
            if (customDialog.ShowDialog() == DialogResult.OK)
            {
                string enteredText = customDialog.EnteredText;
                customDialog.Dispose();

                if (!string.IsNullOrEmpty(enteredText))
                {
                    chatForm.TextBoxTitle.Text = enteredText;
                    conversationHistory = new List<Dictionary<string, object>>();
                    lastRowId = default;
                    chatForm.ChatBox.Text = "";
                    return enteredText;
                }
                else
                {
                    return "";
                }
            }

            else
            {
                return "";
            }
        }

        // APIに接続してレスポンス取得--------------------------------------------------------------
        public List<Dictionary<string, object>> conversationHistory = new List<Dictionary<string, object>>(); // 履歴

        public async Task<string> PostChatAsync(string chatTextPost)
        {

            try
            {
                string chatTextRes;

                using (var httpClientStr = new HttpClient())
                {

                    httpClientStr.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey());
                    httpClientStr.Timeout = TimeSpan.FromSeconds(200d);

                    // 過去の会話履歴と現在の入力を結合する前に、過去の会話履歴に含まれるcontent文字列の文字数を取得
                    int historyContentLength = conversationHistory.Sum(d => d["content"].ToString().Length);
                    // 削除前の文字数を記録
                    int preDeleteHistoryLength = historyContentLength;

                    // 現在のユーザーの入力を表すディクショナリ
                    var userInput = new Dictionary<string, object>() { { "role", "user" }, { "content", chatTextPost } };

                    // もし、過去の会話履歴と現在の入力を結合して制限文字数を超える場合は、会話履歴のuserとassistantのJSONデータを一組分、古いものから削除する
                    while ((bool)(historyContentLength + chatTextPost.Length is { } arg1 && MAX_CONTENT_LENGTH.HasValue ? arg1 > MAX_CONTENT_LENGTH : (bool?)null))
                    {
                        if (conversationHistory.Count == 0)
                        {
                            // 会話履歴がないのに、文字数が制限文字数を超える場合は、何もしないで処理を中止する
                            return $"Error: The total length of conversation history ({historyContentLength + chatTextPost.Length} characters) exceeded the maximum content length ({MAX_CONTENT_LENGTH} characters). Please reduce the input by {historyContentLength + chatTextPost.Length - MAX_CONTENT_LENGTH} characters.";

                        }
                        var oldestConversation = conversationHistory.First();
                        if (oldestConversation["role"].ToString() == "assistant")
                        {
                            // 最初の会話履歴がassistantだった場合は、次のassistantのデータが出るまで削除する
                            do
                            {
                                conversationHistory.RemoveAt(0);
                                historyContentLength = conversationHistory.Sum(d => d["content"].ToString().Length);
                                if (conversationHistory.Count == 0)
                                {
                                    // 会話履歴がなくなった場合は、処理を中止する
                                    return "Error: There is no conversation history left, but the character count still exceeds the limit. Please ensure your input is within the allowed character limit.";

                                }
                            }
                            while (conversationHistory.First()["role"].ToString() != "assistant");
                        }
                        // 最も古い会話履歴を削除する
                        conversationHistory.RemoveAt(0);
                        historyContentLength = conversationHistory.Sum(d => d["content"].ToString().Length);
                    }

                    // 過去の会話履歴と現在の入力を結合
                    conversationHistory.Add(userInput);

                    var options = new Dictionary<string, object>() { { "model", api_model }, { "messages", conversationHistory } };

                    // オプションパラメータを追加
                    if (api_max_tokens.HasValue)
                        options.Add("max_tokens", api_max_tokens.Value);
                    if (api_temperature.HasValue)
                        options.Add("temperature", api_temperature.Value);
                    if (api_top_p.HasValue)
                        options.Add("top_p", api_top_p.Value);
                    if (api_n.HasValue)
                        options.Add("n", api_n.Value);
                    if (api_logprobs.HasValue)
                        options.Add("logprobs", api_logprobs.Value);
                    if (api_presence_penalty.HasValue)
                        options.Add("presence_penalty", api_presence_penalty.Value);
                    if (api_frequency_penalty.HasValue)
                        options.Add("frequency_penalty", api_frequency_penalty.Value);
                    if (api_best_of.HasValue)
                        options.Add("best_of", api_best_of.Value);

                    // api_stop パラメータの処理
                    if (!string.IsNullOrEmpty(api_stop))
                    {
                        string[] stopSequence = api_stop.Split(',');
                        options.Add("stop", stopSequence);
                    }

                    // api_logit_bias パラメータの処理
                    if (!string.IsNullOrEmpty(api_logit_bias))
                    {
                        var logitBias = JsonSerializer.Deserialize<Dictionary<string, double>>(api_logit_bias);
                        options.Add("logit_bias", logitBias);
                    }

                    string jsonContent = JsonSerializer.Serialize(options);

                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClientStr.PostAsync(api_url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);
                        // レス本文
                        chatTextRes = Environment.NewLine + responseJson.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString().Trim() + Environment.NewLine + Environment.NewLine;
                        // usageプロパティだけ取得する
                        JsonElement usageProperty;
                        if (responseJson.TryGetProperty("usage", out usageProperty))
                        {
                            string usageValue = usageProperty.ToString();
                            chatTextRes += $"usage={usageValue}" + Environment.NewLine;
                        }

                        // 下記は全プロパティ取得ver.
                        // For Each prop As JsonProperty In responseJson.EnumerateObject()
                        // If prop.Name <> "choices" Then
                        // Dim propValue As String = prop.Value.ToString()
                        // chatTextRes &= $"{prop.Name}={propValue}" & Environment.NewLine
                        // End If
                        // Next

                        // 応答を受け取った後、conversationHistory に追加
                        conversationHistory.Add(new Dictionary<string, object>() { { "role", "assistant" }, { "content", chatTextRes } });
                        // 削除が実行された場合、メソッドの戻り値の最後に削除前の文字数と削除後の文字数をメッセージとして付け加える
                        if (preDeleteHistoryLength > historyContentLength)
                        {
                            chatTextRes += $"{Environment.NewLine}-Conversation history has been truncated. Chars-before: {preDeleteHistoryLength}, after: {historyContentLength}.{Environment.NewLine}";
                        }
                    }

                    else
                    {
                        string errorBody = await response.Content.ReadAsStringAsync();
                        return $"Error: Response status code does not indicate success: {response.StatusCode} ({response.ReasonPhrase}). Response body: {errorBody}";
                    }

                }

                return chatTextRes;
            }

            catch (Exception ex)
            {
                return $"Error: {ex.Message + Environment.NewLine}";
            }
        }

        private System.Windows.Forms.Timer thinkTimer;
        private int thinkCounter = 0;

        private void StartThinkingAnimation()
        {
            thinkTimer.Interval = 400; // アニメーションの速度
            thinkCounter = 0;
            chatForm.ChatBox.Invoke(() => chatForm.ChatBox.AddText("AI: "));
            thinkTimer.Start();
        }

        private void StopThinkingAnimation()
        {
            UpdateMessage("");
            thinkTimer.Stop();
        }

        private void thinkTimer_Tick(object sender, EventArgs e)
        {
            string thinkingText = "Now thinking";
            string[] thinkAnim = new[] { ". _", ".. -", "... |", ".... /" };
            // ローディングアイコンを回転させる
            thinkingText += " " + thinkAnim[thinkCounter % 4];

            // For i = 0 To thinkCounter Mod 3
            // thinkingText &= "."
            // Next

            UpdateMessage("AI: " + thinkingText);
            thinkCounter += 1;
        }

        private void UpdateMessage(string thinkingText)
        {
            chatForm.ChatBox.Invoke(() =>
                {
                    // 最後の行のインデックスを取得
                    int lastLineIndex = chatForm.ChatBox.Lines.Count - 1;
                    // 最後の行の開始位置と長さを取得
                    int lastLineStartPos = chatForm.ChatBox.Lines[lastLineIndex].Position;
                    int lastLineLength = chatForm.ChatBox.Lines[lastLineIndex].Length;
                    // 最後の行を新しいテキストで置き換える
                    chatForm.ChatBox.DeleteRange(lastLineStartPos, lastLineLength);
                    chatForm.ChatBox.InsertText(lastLineStartPos, thinkingText);
                });
        }


    }
}