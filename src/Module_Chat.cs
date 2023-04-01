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

        //チャットメインロジック--------------------------------------------------------------
        public static bool isChatRunning = false;//チャット実行中フラグ
        public async Task GoChatAsync()
        {
            if (isChatRunning)//チャット実行中の場合はキャンセル
            {
                return;
            }
            isChatRunning = true;

            var postDate = DateTime.Now;
            if (string.IsNullOrEmpty(chatForm.ChatBox.Text) && string.IsNullOrEmpty(chatForm.TextBoxTitle.Text))//チャット表示無ければ新規と判断
            {
                InitializeChat();
            }

            AddLog($"[{postDate.ToString()}] by You{Environment.NewLine}{Environment.NewLine}{string.Join(Environment.NewLine, recentText).Trim() + Environment.NewLine}");

            if (EditorLogAutoSaveToolStripMenuItem.Checked == true)
            {
                await InsertDatabaseAsync();//オートセーブオンの場合はエディターログを保存
            }

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

            isChatRunning = false;
        }

        // チャットログ表示--------------------------------------------------------------
        public void AddLog(string data, bool gptSays = false)
        {
            chatForm.ChatBox.AppendText(data + Environment.NewLine); // data を表示
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
        public void InitializeChat()
        {
            chatForm.TextBoxTitle.Text = "";
            chatForm.TextBoxTag1.Text = "";
            chatForm.TextBoxTag2.Text = "";
            chatForm.TextBoxTag3.Text = "";
            conversationHistory = new List<Dictionary<string, object>>();
            lastRowId = default;
            chatForm.ChatBox.Text = "";
        }

        // APIに接続してレスポンス取得--------------------------------------------------------------
        public List<Dictionary<string, object>> conversationHistory = new List<Dictionary<string, object>>(); // 履歴

        public async Task<string> PostChatAsync(string chatTextPost)
        {

            try
            {
                string chatTextRes;
                string currentTitle = (string)chatForm.Invoke((Func<string>)(() => chatForm.TextBoxTitle.Text));

                using (var httpClientStr = new HttpClient())
                {

                    httpClientStr.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey());
                    httpClientStr.Timeout = TimeSpan.FromSeconds(200d);

                    // 過去の会話履歴と現在の入力を結合する前に、過去の会話履歴に含まれるcontent文字列のトークン数を取得
                    int historyContentTokenCount = conversationHistory.Sum(d => GetTokenCount(d["content"].ToString()));
                    // 要約前のトークン数を記録
                    int preSummarizedHistoryTokenCount = historyContentTokenCount;

                    // 過去の履歴＋ユーザーの新規入力が制限トークン数「MAX_CONTENT_LENGTH」を超えた場合
                    if (historyContentTokenCount + GetTokenCount(chatTextPost) > MAX_CONTENT_LENGTH)
                    {
                        int historyTokenCount = 0;
                        int messagesToRemove = 0;
                        string forCompMes = "";

                        // 会話履歴の最新のものから、ユーザーとアシスタントを1セットとして、1セットずつトークン数を数えて一時変数「historyTokenCount」に足していく
                        for (int i = 0; i < conversationHistory.Count; i += 2)
                        {
                            int userMessageTokenCount = GetTokenCount(conversationHistory[i]["content"].ToString());
                            int assistantMessageTokenCount = GetTokenCount(conversationHistory[i + 1]["content"].ToString());
                            historyTokenCount += userMessageTokenCount + assistantMessageTokenCount;

                            if (historyTokenCount > (MAX_CONTENT_LENGTH - 300))
                            {
                                forCompMes = conversationHistory.GetRange(messagesToRemove, conversationHistory.Count - messagesToRemove).Select(message => message["content"].ToString()).Reverse().Aggregate((a, b) => a + b);
                                messagesToRemove = i + 1;
                                break;
                            }
                        }

                        // 抽出したテキストを要約APIリクエストに送信
                        try
                        {
                            string summary = await GetSummaryAsync(forCompMes);
                            summary = currentTitle + ": " + summary;
                            MessageBox.Show($"Conversation history was summarized as follows:{Environment.NewLine}{Environment.NewLine}{summary}");

                            historyContentTokenCount = summary.Length;

                            // 返ってきた要約文で、conversationHistoryを書き換える
                            conversationHistory.RemoveRange(0, messagesToRemove + 1);
                            conversationHistory.Insert(0, new Dictionary<string, object>() { { "role", "assistant" }, { "content", summary } });
                        }
                        catch (Exception ex)
                        {
                            return $"Error: {ex.Message + Environment.NewLine}";
                        }
                    }

                    // 現在のユーザーの入力を表すディクショナリ
                    var userInput = new Dictionary<string, object>() { { "role", "user" }, { "content", chatTextPost } };

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

                        // 応答を受け取った後、conversationHistory に追加
                        conversationHistory.Add(new Dictionary<string, object>() { { "role", "assistant" }, { "content", chatTextRes } });

                        // usageプロパティだけ取得する
                        JsonElement usageProperty;
                        if (responseJson.TryGetProperty("usage", out usageProperty))
                        {
                            string usageValue = usageProperty.ToString();
                            chatTextRes += $"usage={usageValue}" + Environment.NewLine;
                        }

                        // 要約が実行された場合、メソッドの戻り値の最後に要約前のトークン数と要約後のトークン数をメッセージとして付け加える
                        if (preSummarizedHistoryTokenCount > GetTokenCount(conversationHistory.Select(d => d["content"].ToString()).Aggregate((a, b) => a + b)))
                        {
                            chatTextRes += $"-Conversation history has been summarized. before: {preSummarizedHistoryTokenCount}, after: {GetTokenCount(conversationHistory.Select(d => d["content"].ToString()).Aggregate((a, b) => a + b))}.{Environment.NewLine}";
                        }
                        //会話が成立した時点でタイトルが空欄だったらタイトルを自動生成する
                        if (string.IsNullOrEmpty(currentTitle))
                        {
                            string title = await GetTitleAsync(currentTitle);

                            chatForm.Invoke((Action)(() =>
                            {
                                chatForm.TextBoxTitle.Text = title;
                            }));
                            await chatForm.EditTitle();
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

        //トークン数計算
        public int GetTokenCount(string text)
        {
            var tokenizer = new System.Text.RegularExpressions.Regex(@"\p{L}+|\p{N}+|[^\p{L}\p{N}\s]+");
            string[] words = text.Split(' ');

            int tokenCount = 0;
            foreach (string word in words)
            {
                if (ContainsDoubleByteCharacter(word))
                {
                    tokenCount += word.Length;
                }
                else
                {
                    tokenCount += tokenizer.Matches(word).Count;
                }
            }

            return tokenCount;
        }

        public bool ContainsDoubleByteCharacter(string text)
        {
            return text.Any(c => c > 0x80);
        }

        //文章要約圧縮メソッド--------------------------------------------------------------
        public async Task<string> GetSummaryAsync(string forCompMes)
        {
            string summary;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey());
                httpClient.Timeout = TimeSpan.FromSeconds(200d);

                var options = new Dictionary<string, object>
        {
            { "model", api_model },
            { "messages", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { { "role", "system" }, { "content", "You are a professional editor. Please summarize the following text in about 500 tokens using the language in which the text is written. For a text that includes multiple conversations, the conversation set that appears at the beginning is the most important." } },
                    new Dictionary<string, object> { { "role", "user" }, { "content", forCompMes } }
                }
            }
        };

                string jsonContent = JsonSerializer.Serialize(options);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(api_url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);
                    summary = responseJson.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString().Trim();
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: Response status code does not indicate success: {response.StatusCode} ({response.ReasonPhrase}). Response body: {errorBody}");
                }
            }

            return summary;
        }

        //タイトル命名メソッド--------------------------------------------------------------
        public async Task<string> GetTitleAsync(string forTitleMes)
        {
            string summary;

            forTitleMes = conversationHistory.Select(message => message["content"].ToString()).Reverse().Aggregate((a, b) => a + b); ;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetApiKey());
                httpClient.Timeout = TimeSpan.FromSeconds(200d);

                var options = new Dictionary<string, object>
        {
            { "model", api_model },
            { "messages", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { { "role", "system" }, { "content", "あなたはプロの編集者です。これから送るチャットログにチャットタイトルをつけてそれだけを回答してください。・ログは冒頭に行くほど重要な情報です。・記号を使わないこと。・短くシンプルに、UNICODEの全角文字に換算して最大でも16文字を絶対に超えないように。これは重要な条件です。" } },
                    new Dictionary<string, object> { { "role", "user" }, { "content", forTitleMes } }
                }
            }
        };

                string jsonContent = JsonSerializer.Serialize(options);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(api_url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);
                    char[] charsToTrim = { ' ','\"', '\'', '[', ']', '「', '」' };
                    summary = responseJson.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString().Trim(charsToTrim);
                    //MessageBox.Show(summary);
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: Response status code does not indicate success: {response.StatusCode} ({response.ReasonPhrase}). Response body: {errorBody}");
                }
            }

            return summary;
        }

        //Thinkingアニメーション--------------------------------------------------------------
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