using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Web.WebView2.Core;

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
                    await MainFormInst.AnalyzeWebViewContentAsync();
                    return;
                }
                return;
            }
            MessageBox.Show("Please display chat screen.");
        }

    }
}
