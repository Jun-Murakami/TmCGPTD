using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Web.WebView2.Core;
using HtmlAgilityPack;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SQLite;
using System.IO.Packaging;

namespace TmCGPTD
{
    public partial class Form_WebView2 : DockContent
    {
        public Form1 MainFormInst { get; set; }

        public Form_WebView2()
        {
            InitializeComponent();
            webView21.NavigationCompleted += WebView21_NavigationCompleted;
        }
        // Formは閉じれないようにする。--------------------------------------------------------------
        private void webView2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (!mainForm.cts.Token.IsCancellationRequested)
            {
                MainFormInst.webView2Form.DockState = DockState.Hidden; // フォームを閉じるのではなく、非表示にする
                e.Cancel = true; // イベントをキャンセルし、フォームが閉じないようにする
            }
            else
            {
                e.Cancel = false;
            }
        }

        private async void webView2Form_FormLoad(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri("https://chat.openai.com/");
        }

        private async void WebView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (webView21.CoreWebView2 != null)
            {
                if (Form1.buttonClicked && e.WebErrorStatus == CoreWebView2WebErrorStatus.Unknown)
                {
                    Form1.buttonClicked = false;
                    await AnalyzeWebViewContentAsync();
                    return;
                }
                return;
            }
            MessageBox.Show("Please display chat screen.");
        }
        public async Task AnalyzeWebViewContentAsync()
        {
            string webChatTitle;
            List<Dictionary<string, object>> webConversationHistory = new List<Dictionary<string, object>>();
            string webLog = "";

            // WebView2からHTMLソースを取得
            string jsonHtmlSource = await webView21.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
            string htmlSource = JsonSerializer.Deserialize<string>(jsonHtmlSource);

            // HtmlAgilityPackを使ってHTMLを解析
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlSource);

            // h1タグをサーチ
            var h1Tag = htmlDoc.DocumentNode.SelectSingleNode("//h1");
            if (h1Tag.InnerText == "New chat")
            {
                MessageBox.Show("Please display chat screen.");
                return;
            }
            webChatTitle = h1Tag?.InnerText;

            // mainタグをサーチ
            var mainTag = htmlDoc.DocumentNode.SelectSingleNode("//main");
            if (mainTag == null)
            {
                MessageBox.Show("Please display chat screen.");
                return;
            }

            // divタグを取得
            var divTags = mainTag.SelectNodes("./*/*/*/*/div");
            int count = 0;

            // フィルタリングされたdivタグを保持するリスト
            List<HtmlNode> filteredDivs = new List<HtmlNode>();

            // divタグをフィルタリング
            foreach (var div in divTags)
            {
                if (div.ChildNodes.Count == 0 || div.InnerText.Contains("Model:"))
                {
                    continue;
                }
                filteredDivs.Add(div);
            }

            foreach (var div in filteredDivs)
            {
                var className = div.GetAttributeValue("class", "");
                var regex = new Regex(@".*\[#\w{6}\].*");
                var match = regex.Match(className);

                string role;
                string content;

                if (!match.Success)
                {
                    role = "user";
                    // 子ノードのInnerTextを取得し、文字列として結合
                    string htmlString = div.InnerHtml;
                    string pattern = "<span class=.*>[0-9]+ / [0-9]+</span>";
                    htmlString = Regex.Replace(htmlString, pattern, "");

                    // 置換処理が完了した後、再度HTMLドキュメントに戻します。
                    var modifiedHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                    modifiedHtmlDoc.LoadHtml(htmlString);

                    // InnerText要素を結合して、宣言済みの変数contentに文字列として代入します。
                    StringBuilder contentBuilder = new StringBuilder();
                    foreach (var node in modifiedHtmlDoc.DocumentNode.ChildNodes)
                    {
                        if (!string.IsNullOrWhiteSpace(node.InnerText))
                        {
                            contentBuilder.Append(node.InnerText);
                        }
                    }
                    content = contentBuilder.ToString();
                    content = content.Trim();

                    webConversationHistory.Add(new Dictionary<string, object>
                    {
                        { "role", role },
                        { "content", content }
                    });
                    webLog += $"[Web Chat] by You\r\n\r\n{content}\r\n\r\n\r\n";
                }
                else
                {
                    role = "assistant";

                    string htmlString = div.InnerHtml;

                    // 置換処理を行います。
                    htmlString = htmlString.Replace("<pre>", "\r\n\r\n```")
                                           .Replace("</pre>", "\r\n```\r\n\r\n")
                                           .Replace("Copy code", "\r\n")
                                           .Replace("<ol>", "\r\n")
                                           .Replace("</ol>", "\r\n")
                                           .Replace("<ul>", "\r\n")
                                           .Replace("</ul>", "\r\n")
                                           .Replace("<li>", "\r\n- ")
                                           .Replace("</li>", "\r\n");

                    // 正規表現パターンに基づいて削除します。
                    string pattern = "<span class=.*>[0-9]+ / [0-9]+</span>";
                    htmlString = Regex.Replace(htmlString, pattern, "");

                    // 置換処理が完了した後、再度HTMLドキュメントに戻します。
                    var modifiedHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                    modifiedHtmlDoc.LoadHtml(htmlString);

                    // InnerText要素を結合して、宣言済みの変数contentに文字列として代入します。
                    StringBuilder contentBuilder = new StringBuilder();
                    foreach (var node in modifiedHtmlDoc.DocumentNode.ChildNodes)
                    {
                        if (!string.IsNullOrWhiteSpace(node.InnerText))
                        {
                            contentBuilder.Append(node.InnerText);
                        }
                    }
                    content = contentBuilder.ToString();
                    content = content.Trim();

                    webConversationHistory.Add(new Dictionary<string, object>
                    {
                        { "role", role },
                        { "content", content }
                    });
                    webLog += $"[Web Chat] by AI\r\n\r\n{content}\r\n\r\n\r\n";
                }

                count++;
            }
            //MessageBox.Show(webLog);
            await MainFormInst.InsertDatabaseWebChatAsync(webChatTitle, webConversationHistory, webLog);


            string query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
            var dT = await MainFormInst.SearchChatDatabaseAsync(query);
            await MainFormInst.chatLogForm.ShowChatSearchResultAsync(dT);

            await MainFormInst.UpdateChatSaysMarkerAsync();
            await MainFormInst.UpdateChatCodeMarkerAsync();

            Interaction.MsgBox($"Successfully imported log: {webChatTitle} ({count} Messages)", MsgBoxStyle.Information, "Information");

        }

    }
}
