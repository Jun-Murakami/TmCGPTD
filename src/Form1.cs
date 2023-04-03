using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Initialize thinkTimer
            thinkTimer = new System.Windows.Forms.Timer();
            thinkTimer.Tick += new EventHandler(thinkTimer_Tick);
        }

        public static string phrasePath = Path.Combine(Application.StartupPath, "phrase_presets"); // フレーズプリセットパス
        public static string dbPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "log.db"); // DBパス
        public static string dbBuPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "log_buckup.db"); // DBバックアップパス
        public static string xmlFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Syntax_Setting.xml"); // XMLファイルのパス
        public static SQLiteConnection memoryConnection; // メモリ上のSQLコネクション
        public static string inputFontName = "Default"; // デフォルトフォント
        public static int inputFontSize = 11; // デフォルトフォントサイズ
        public static string chatFontName = "Default"; // デフォルトフォント
        public static int chatFontSize = 11; // デフォルトフォントサイズ
        public static string nowLangueage = "default"; // 現在の選択言語
        public CancellationTokenSource cts = new CancellationTokenSource(); // キャンセレーショントークン
        public Form_Chat chatForm = new Form_Chat(); // formをインスタンス化
        public Form_Input inputForm = new Form_Input();
        public Form_Preview previewForm = new Form_Preview();
        public Form_ChatLog chatLogForm = new Form_ChatLog();
        public Form_Phrase phraseForm = new Form_Phrase();
        public Form_WebView2 webView2Form = new Form_WebView2();
        // APIパラメータ初期化
        public static int? api_max_tokens = Properties.Settings.Default.max_tokens != "Nothing" ? int.Parse(Properties.Settings.Default.max_tokens) : (int?)null;
        public static double? api_temperature = Properties.Settings.Default.temperature != "Nothing" ? double.Parse(Properties.Settings.Default.temperature) : (double?)null; public static double? api_top_p = Properties.Settings.Default.top_p == "Nothing" ? new double?() : double.Parse(Properties.Settings.Default.top_p);
        public static int? api_n = Properties.Settings.Default.n == "Nothing" ? new int?() : int.Parse(Properties.Settings.Default.n);
        public static int? api_logprobs = Properties.Settings.Default.logprobs == "Nothing" ? new int?() : int.Parse(Properties.Settings.Default.logprobs);
        public static double? api_presence_penalty = Properties.Settings.Default.presence_penalty == "Nothing" ? new double?() : double.Parse(Properties.Settings.Default.presence_penalty);
        public static double? api_frequency_penalty = Properties.Settings.Default.frequency_penalty == "Nothing" ? new double?() : double.Parse(Properties.Settings.Default.frequency_penalty);
        public static int? api_best_of = Properties.Settings.Default.best_of == "Nothing" ? new int?() : int.Parse(Properties.Settings.Default.best_of);
        public static string api_stop = Properties.Settings.Default.stop;
        public static string api_logit_bias = Properties.Settings.Default.logit_bias;
        public static string api_model = Properties.Settings.Default.model;
        public static string api_url = Properties.Settings.Default.url;
        public static int? MAX_CONTENT_LENGTH = Properties.Settings.Default.conversation_history_limit == "Nothing" ? 3072 : int.Parse(Properties.Settings.Default.conversation_history_limit);



        private void Form1_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = assembly.GetManifestResourceNames();
            foreach (string resourceName in resourceNames)
            {
                Console.WriteLine(resourceName);
            }

            // Me.Cursor = Cursors.WaitCursor '処理中を示すWaitCursorを表示

            // MainFormインスタンスを設定
            inputForm.MainFormInst = this;
            previewForm.MainFormInst = this;
            chatForm.MainFormInst = this;
            chatLogForm.MainFormInst = this;
            phraseForm.MainFormInst = this;
            webView2Form.MainFormInst = this;

            DockPanel1.Theme = new VS2015LightTheme();

            // ドック状態の復元
            string dockStateFilePath = Path.Combine(Application.StartupPath, "DockState.xml");
            if (File.Exists(dockStateFilePath))
            {
                DockPanel1.LoadFromXml(dockStateFilePath, DeserializeDockContent);
            }
            else
            {
                // 初回起動時のデフォルトレイアウト
                LoadDefaultDockLayout();
            }

            // 各種初回起動チェック＆初期化処理
            if (!Directory.Exists(phrasePath))
                Directory.CreateDirectory(phrasePath);
            if (!File.Exists(dbPath))
                CreateDatabase();
            if (!TableExists("chatlog"))
                CreateDatabaseChat();

            // 定型句読み込み
            foreach (var file in Directory.GetFiles(phrasePath, "*.txt"))
                AddSelectionItem(Path.GetFileName(file));

            WindowInitialize(); // ウインドウ初期化
            ChangeControlColor(); // 部品色初期化
            chatLogForm.InitializeDataTable(); // データテーブル初期化
            DbLoadToMemory(); // データベースをインメモリに読み込み


            // Me.Cursor = Cursors.Default ' カーソルをデフォルトに戻す
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            FocusRun(); // カーソルちらつき防止

            // DBからエディターログ初期表示
            string query = $"SELECT id, date, text FROM log ORDER BY date DESC LIMIT 30";
            await SearchDatabaseAsync(query);

            // DBからチャットログ初期表示
            query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
            var dT = await SearchChatDatabaseAsync(query);
            await chatLogForm.ShowChatSearchResultAsync(dT);
            int rowsCount = new int();
            await Task.Run(() => chatLogForm.DataGrid.Invoke(() => rowsCount = chatLogForm.DataGrid.Rows.Count));
            if (rowsCount > 0)
            {
                int chatId = new int();
                await Task.Run(() => chatLogForm.DataGrid.Invoke(() => chatId = Conversions.ToInteger(chatLogForm.DataGrid.Rows[0].Cells["chatId"].Value)));
                query = $"SELECT title, tag, json, text FROM chatlog WHERE id = {chatId}";
                var result = await PickChatDatabaseAsync(query);
                await ShowChatLogAsync(result);
                lastRowId = chatId;
            }
        }

        // ウィンドウ初期化--------------------------------------------------------------
        private void WindowInitialize()
        {

            if (File.Exists(xmlFilePath))
            {
                // ファイルが存在する場合、何もしない
            }
            else
            {
                // ファイルが存在しない場合、リソースからコピーする
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "TmCGPTD.Syntax_Setting.xml";
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        // リソースが見つからない場合、エラーメッセージを表示する
                        MessageBox.Show("XML resource is not found.: " + resourceName);
                        return;
                    }
                    // ファイルをコピーする
                    using (var fileStream = new FileStream(xmlFilePath, FileMode.CreateNew))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            // カテゴリごとにメニュー項目を追加する
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var settings = new XmlReaderSettings();
                var context = new XmlParserContext(nt: null, nsMgr: null, xmlLang: null, XmlSpace.None);
                // context.Encoding = Encoding.GetEncoding(1252)
                using (var reader = XmlReader.Create(xmlFilePath, settings, context))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);

                    var categoryNodes = xmlDoc.DocumentElement.SelectNodes("//Category");

                    foreach (XmlNode categoryNode in categoryNodes)
                    {
                        string categoryName = categoryNode.Attributes["name"].Value;
                        if (categoryName != "Default")
                            LanguageToolStripMenuItem.DropDownItems.Add(categoryName);

                        var languageNodes = categoryNode.SelectNodes("LexerType");

                        foreach (XmlNode languageNode in languageNodes)
                        {
                            string languageName = languageNode.Attributes["desc"].Value;
                            AddSelectionItemLang(languageName);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"XML load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!(Properties.Settings.Default.WindowPosition.X == -1))
            {
                // My.Settingsからウィンドウの位置とサイズ、フォントを取得して再現する
                Location = Properties.Settings.Default.WindowPosition;
                Size = Properties.Settings.Default.WindowSize;
            }

            EditorLogAutoSaveToolStripMenuItem.Checked = Properties.Settings.Default.AutoSave;

            KeyPreview = true; // KeyPreview プロパティを True に設定

        }

        // 終了処理--------------------------------------------------------------
        private void SaveSetting()
        {
            cts.Cancel(); // キャンセレーション発動

            // ドック状態を保存する（実ファイル版）
            string dockStateFilePath = Path.Combine(Application.StartupPath, "DockState.xml");
            try
            {
                DockPanel1.SaveAsXml(dockStateFilePath);
            }
            catch
            {
            }

            // 画面設定をMy.Settingsに保存する
            Properties.Settings.Default.WindowPosition = Location;
            Properties.Settings.Default.WindowSize = Size;
            Properties.Settings.Default.Zoom1 = inputForm.TextInput1.Zoom;
            Properties.Settings.Default.Zoom2 = inputForm.TextInput2.Zoom;
            Properties.Settings.Default.Zoom3 = inputForm.TextInput3.Zoom;
            Properties.Settings.Default.Zoom4 = inputForm.TextInput4.Zoom;
            Properties.Settings.Default.Zoom5 = inputForm.TextInput5.Zoom;
            Properties.Settings.Default.ZoomChat = chatForm.ChatBox.Zoom;

            Properties.Settings.Default.Save();

            Application.Exit();
        }

        // Dockレイアウト--------------------------------------------------------------
        private void LoadDefaultDockLayout()
        {
            // 現在のレイアウトをクリア
            DockPanel1.SuspendLayout(true);
            foreach (IDockContent window in DockPanel1.Contents.ToList())
                window.DockHandler.DockPanel = null;

            // 新しいレイアウトをロード
            // DockPanel1.Theme = New VS2015LightTheme
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("TmCGPTD.DefaultDockState.xml"))
            {
                DockPanel1.LoadFromXml(stream, DeserializeDockContent);
            }
            DockPanel1.ResumeLayout(true, true);

            float dpiScaleFactor = CreateGraphics().DpiX / 96.0f;
            DockPanel1.DockBottomPortion = DockPanel1.DockBottomPortion * (double)dpiScaleFactor;
        }

        // DeserializeDockContent メソッドを実装して、適切な DockContent インスタンスを返すようにします。
        private IDockContent DeserializeDockContent(string persistentString)
        {
            if ((persistentString ?? "") == (typeof(Form_Chat).ToString() ?? ""))
            {
                return chatForm;
            }
            else if ((persistentString ?? "") == (typeof(Form_Input).ToString() ?? ""))
            {
                return inputForm;
            }
            else if ((persistentString ?? "") == (typeof(Form_Preview).ToString() ?? ""))
            {
                return previewForm;
            }
            else if ((persistentString ?? "") == (typeof(Form_ChatLog).ToString() ?? ""))
            {
                return chatLogForm;
            }
            else if ((persistentString ?? "") == (typeof(Form_Phrase).ToString() ?? ""))
            {
                return phraseForm;
            }
            else if ((persistentString ?? "") == (typeof(Form_WebView2).ToString() ?? ""))
            {
                return webView2Form;
            }

            return null;
        }

        // MainForm内でインスタンスを公開するプロパティを追加--------------------------------------------------------------
        public Form_Preview MainFormPreviewForm
        {
            get
            {
                return previewForm;
            }
        }
        public Form_Input MainFormInputForm
        {
            get
            {
                return inputForm;
            }
        }
        public Form_Chat MainFormChatForm
        {
            get
            {
                return chatForm;
            }
        }

        public Form_ChatLog MainFormChatLogForm
        {
            get
            {
                return chatLogForm;
            }
        }

        public Form_Phrase MainFormPhraseForm
        {
            get
            {
                return phraseForm;
            }
        }

        public Form_WebView2 MainFormWebView2Form
        {
            get
            {
                return webView2Form;
            }
        }
    }
}