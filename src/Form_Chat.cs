using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace TmCGPTD
{

    public partial class Form_Chat : DockContent
    {
        public Form1 MainFormInst { get; set; }

        public Form_Chat()
        {
            InitializeComponent();
        }
        private void Form_Chat_Shown(object sender, EventArgs e)
        {
            ChatBox.Zoom = Properties.Settings.Default.ZoomChat;
        }
        // Formは閉じれないようにする。--------------------------------------------------------------
        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (!mainForm.cts.Token.IsCancellationRequested)
            {
                MainFormInst.previewForm.DockState = DockState.Hidden; // フォームを閉じるのではなく、非表示にする
                e.Cancel = true; // イベントをキャンセルし、フォームが閉じないようにする
            }
            else
            {
                e.Cancel = false;
            }
        }

        private int _lastSearchPos = 0; // 検索ボックス用

        private void ChatForm_Load(object sender, EventArgs e)
        {
            // 埋め込みリソースからボタン画像を読み込む
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("TmCGPTD.images.iconChatO6.png");
            var originalImage = Image.FromStream(resourceStream); // 元の画像を読み込む
            float dpiScaling = MainFormInst.GetDpiScaling(); // DPIスケーリングを取得
            int newSize = (int)Math.Round(18f * dpiScaling); // 新しいサイズにリサイズする
            var resizedImage = new Bitmap(newSize, newSize);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newSize - 2, newSize - 2);
            }
            ButtonNewChat.Image = resizedImage; // ボタンのImageプロパティに設定

            // 画像の高dpi対応
            // Form1.SetPictureBoxImage("TmCGPTD.iconChat.png", PictureBox1)
            // Form1.SetPictureBoxImage("TmCGPTD.iconTag.png", PictureBox2)
            // Form1.SetPictureBoxImage("TmCGPTD.iconWrite.png", PictureButtonTitle)
            // Form1.SetPictureBoxImage("TmCGPTD.iconWrite.png", PictureButtonTag)

            // マウスオーバーエフェクト用に画像をタグに保持
            PictureButtonTitle.Tag = PictureButtonTitle.Image;
            PictureButtonTag.Tag = PictureButtonTag.Image;
            ChangeImageOpacity(PictureButtonTitle, 0.6f); // アルファ値を75%に設定
            ChangeImageOpacity(PictureButtonTag, 0.6f); // アルファ値を75%に設定

            ChatBox.Markers[1].Symbol = MarkerSymbol.Background;
            ChatBox.Markers[1].SetBackColor(Color.FromArgb(68, 70, 84)); // マーカーの背景色を設定
            ChatBox.Markers[2].Symbol = MarkerSymbol.Background;
            ChatBox.Markers[2].SetBackColor(Color.FromArgb(0, 0, 0)); // マーカーの背景色を設定(コードスニペット)

            // ローディングタイマー初期化
            loadingTimer = new System.Windows.Forms.Timer();
            loadingTimer2 = new System.Windows.Forms.Timer();
            loadingTimer.Tick += Timer1_TickAsync;
            loadingTimer2.Tick += Timer2_TickAsync;
        }

        private async void ChatForm_DoubleClickAsync(object sender, EventArgs e)
        {
            await MainFormInst.UpdateChatSaysMarkerAsync();
            await MainFormInst.UpdateChatCodeMarkerAsync();
        }

        public void ButtonDown_Click(object sender, EventArgs e)
        {
            string searchText = null;
            searchText = TextBoxChatTextSearch.Text;

            int startPos = ChatBox.SelectionStart + (ChatBox.SelectionEnd - ChatBox.SelectionStart);
            if (startPos >= ChatBox.Text.Length)
                startPos = 0;

            int resultPos = ChatBox.Text.IndexOf(searchText, startPos, StringComparison.OrdinalIgnoreCase);

            if (resultPos != -1)
            {
                ChatBox.SelectionStart = resultPos;
                ChatBox.SelectionEnd = resultPos + searchText.Length;
                _lastSearchPos = resultPos;
                ChatBox.ScrollCaret();
            }
            else
            {
                MessageBox.Show("No matching results.");
            }

        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            string searchText = TextBoxChatTextSearch.Text;
            int startPos = ChatBox.SelectionStart - 1;
            if (startPos < 0)
                startPos = ChatBox.Text.Length - 1;

            int resultPos = ChatBox.Text.LastIndexOf(searchText, startPos, StringComparison.OrdinalIgnoreCase);

            if (resultPos != -1)
            {
                ChatBox.SelectionStart = resultPos;
                ChatBox.SelectionEnd = resultPos + searchText.Length;
                _lastSearchPos = resultPos;
                ChatBox.ScrollCaret();
            }
            else
            {
                MessageBox.Show("No matching results.");
            }
        }

        // 画像ボタンのマウスオーバー処理--------------------------------------------------------------
        private void PictureButton_MouseEnter(object sender, EventArgs e)
        {
            ChangeImageOpacity((PictureBox)sender, 1.0f); // アルファ値を100%に設定
        }

        private void PictureButton_MouseLeave(object sender, EventArgs e)
        {
            ChangeImageOpacity((PictureBox)sender, 0.6f); // アルファ値を75%に設定
        }

        public void ChangeImageOpacity(PictureBox pictureBox, float opacity)
        {
            if (!isDone || pictureBox.Tag is null)
                return;

            Image originalImage = (Image)pictureBox.Tag;
            var bmp = new Bitmap(originalImage.Width, originalImage.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                var colormatrix = new System.Drawing.Imaging.ColorMatrix();
                colormatrix.Matrix33 = opacity;
                var imgAttribute = new System.Drawing.Imaging.ImageAttributes();
                imgAttribute.SetColorMatrix(colormatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);

                g.DrawImage(originalImage, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imgAttribute);
            }

            pictureBox.Image = bmp;
        }
        // タイトル編集--------------------------------------------------------------
        public async void PictureButtonTitle_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await EditTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task EditTitle()
        {
            // テキストボックスのテキストを読み取り、改行で結合してシングルクォートをエスケープ
            string title = "";
            TextBoxTitle.Invoke(() => title = TextBoxTitle.Text);
            title = title.Replace("'", "''");
            // データグリッドビューの現在選択行のchatIdカラムの値またはlastRowIdを読み取る
            if (MainFormInst.chatLogForm.DataGrid.CurrentRow is not null)
            {
                isDone = false;
                PictureButtonTitle.Invoke(() => PictureButtonTitle.Image = Properties.Resources.iconLoading);
                loadingTimer2.Interval = 100; // 更新間隔(ms)
                loadingTimer2.Start();

                // チャット実行中でなければはDB更新して表示
                if (Form1.isChatRunning == false)
                {
                    int chatId = default;
                    MainFormInst.chatLogForm.DataGrid.Invoke(() => chatId = Conversions.ToInteger(MainFormInst.chatLogForm.DataGrid.CurrentRow.Cells["chatId"].Value));

                    // SQL実行
                    string query = $"UPDATE chatlog SET title = '{title}' WHERE id = {chatId}";
                    await MainFormInst.UpdateDatabaseAsync(query);

                    query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
                    var dT = await MainFormInst.SearchChatDatabaseAsync(query);
                    await MainFormInst.chatLogForm.ShowChatSearchResultAsync(dT);
                    SelectRowByChatId(chatId);
                }
                await Task.Delay(500);
                isDone = true;
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGrid before updating the title.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // タグ編集--------------------------------------------------------------
        private async void PictureButtonTag_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                // テキストボックスのテキストを読み取り、改行で結合してシングルクォートをエスケープ
                string tags = string.Join(Environment.NewLine, new string[] { TextBoxTag1.Text, TextBoxTag2.Text, TextBoxTag3.Text });
                tags = tags.Replace("'", "''");
                // データグリッドビューの現在選択行のchatIdカラムの値を読み取る
                if (MainFormInst.chatLogForm.DataGrid.CurrentRow is not null)
                {
                    isDone = false;
                    await Task.Run(() => PictureButtonTag.Invoke(() => PictureButtonTag.Image = Properties.Resources.iconLoading));
                    loadingTimer.Interval = 100; // 更新間隔(ms)
                    loadingTimer.Start();
                    int chatId = Conversions.ToInteger(MainFormInst.chatLogForm.DataGrid.CurrentRow.Cells["chatId"].Value);

                    // SQL実行
                    string query = $"UPDATE chatlog SET tag = '{tags}' WHERE id = {chatId}";
                    await MainFormInst.UpdateDatabaseAsync(query);

                    // 表示更新
                    query = "SELECT id, date, title, tag FROM chatlog ORDER BY date DESC;";
                    var dT = await MainFormInst.SearchChatDatabaseAsync(query);
                    await MainFormInst.chatLogForm.ShowChatSearchResultAsync(dT);
                    SelectRowByChatId(chatId);
                    await Task.Delay(500);
                    isDone = true;
                }
                else
                {
                    MessageBox.Show("Please select a row in the DataGrid before updating the tags.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // タイトル編集、タグ編集のアニメーション処理--------------------------------------------------------------
        private System.Windows.Forms.Timer loadingTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer loadingTimer2 = new System.Windows.Forms.Timer();
        private int rotationAngle;
        private bool isDone = true;
        private async void Timer1_TickAsync(object sender, EventArgs e)
        {
            if (isDone)
            {
                await Task.Run(() => PictureButtonTag.Invoke(() => PictureButtonTag.Image.Dispose()));
                await Task.Run(() => PictureButtonTag.Invoke(() => PictureButtonTag.Image = Properties.Resources.iconOK));
                await Task.Delay(700);
                await Task.Run(() => PictureButtonTag.Invoke(() => PictureButtonTag.Image.Dispose()));
                ChangeImageOpacity(PictureButtonTag, 0.6f);
                loadingTimer.Stop();
            }
            else
            {
                await Task.Run(() => PictureButtonTag.Invoke(() =>
{
    rotationAngle += 45;
    if (rotationAngle >= 360)
        rotationAngle = 0;
    var oldImage = PictureButtonTag.Image;
    var rotatedImage = RotateImage(oldImage, rotationAngle);
    PictureButtonTag.Image = rotatedImage;
    oldImage.Dispose(); // Dispose old image
}));
            }
        }
        private async void Timer2_TickAsync(object sender, EventArgs e)
        {
            if (isDone)
            {
                await Task.Run(() => PictureButtonTitle.Invoke(() => PictureButtonTitle.Image.Dispose()));
                await Task.Run(() => PictureButtonTitle.Invoke(() => PictureButtonTitle.Image = Properties.Resources.iconOK));
                await Task.Delay(700);
                await Task.Run(() => PictureButtonTitle.Invoke(() => PictureButtonTitle.Image.Dispose()));
                ChangeImageOpacity(PictureButtonTitle, 0.6f);
                loadingTimer2.Stop();
            }

            else
            {
                await Task.Run(() => PictureButtonTitle.Invoke(() =>
{
    rotationAngle += 45;
    if (rotationAngle >= 360)
        rotationAngle = 0;
    var oldImage = PictureButtonTitle.Image;
    var rotatedImage = RotateImage(oldImage, rotationAngle);
    PictureButtonTitle.Image = rotatedImage;
    oldImage.Dispose(); // Dispose old image
}));
            }
        }

        private Image RotateImage(Image image, float angle)
        {
            var rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)(image.Width / 2d), (float)(image.Height / 2d));
                g.RotateTransform(angle);
                g.TranslateTransform((float)(-image.Width / 2d), (float)(-image.Height / 2d));
                g.DrawImage(image, new PointF(0f, 0f));
            }

            return rotatedImage;
        }
        private void SelectRowByChatId(int chatId)
        {
            MainFormInst.chatLogForm.DataGrid.ClearSelection();
            foreach (DataGridViewRow row in MainFormInst.chatLogForm.DataGrid.Rows)
            {
                if (Conversions.ToInteger(row.Cells["chatId"].Value) == chatId)
                {
                    row.Selected = true;
                    MainFormInst.chatLogForm.DataGrid.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        // New Chat--------------------------------------------------------------
        private void ButtonNewChat_Click(object sender, EventArgs e)
        {
            MainFormInst.InitializeChat();
        }

        private Size dockedSize;
        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            if (DockState != DockState.Float)
            {
                dockedSize = Size;
            }
        }
        private void MyForm_DockStateChanged(object sender, EventArgs e)
        {
            if (DockState == DockState.Float)
            {
                // ここで DefaultFloatWindowSize を変更する
                Size = dockedSize;
            }
        }

    }
}