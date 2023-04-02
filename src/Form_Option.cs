using Microsoft.VisualBasic.CompilerServices;
using static TmCGPTD.Form1;

namespace TmCGPTD
{
    public partial class Form_Option
    {
        private int value1;
        private double value2;
        private double value3;
        private int value4;
        private int value5;
        private double value6;
        private double value7;
        private int value8;
        private string value9;
        private string value10;
        private string value11;
        private int value12;

        public Form_Option()
        {
            InitializeComponent();
        }
        private void Form_Option_Shown(object sender, EventArgs e)
        {
            SetLabelPosition();
            this.Resize += new System.EventHandler(this.Form_Option_Resize);

            if (!(Properties.Settings.Default.max_tokens == "Nothing"))
            {
                CheckBox1.Checked = true;
                TrackBar1.Value = Conversions.ToInteger(Properties.Settings.Default.max_tokens);
            }
            else
            {
                TrackBar1.Value = 2048;
            }
            if (!(Properties.Settings.Default.temperature == "Nothing"))
            {
                CheckBox2.Checked = true;
                TrackBar2.Value = (int)Math.Round(Conversions.ToDouble(Properties.Settings.Default.temperature) * 10d);
            }
            else
            {
                TrackBar2.Value = 10;
            }
            if (!(Properties.Settings.Default.top_p == "Nothing"))
            {
                CheckBox3.Checked = true;
                TrackBar3.Value = (int)Math.Round(Conversions.ToDouble(Properties.Settings.Default.top_p) * 100d);
            }
            else
            {
                TrackBar3.Value = 100;
            }
            if (!(Properties.Settings.Default.n == "Nothing"))
            {
                CheckBox4.Checked = true;
                TrackBar4.Value = Conversions.ToInteger(Properties.Settings.Default.n);
            }
            else
            {
                TrackBar4.Value = 20;
            }
            if (!(Properties.Settings.Default.logprobs == "Nothing"))
            {
                CheckBox5.Checked = true;
                TrackBar5.Value = Conversions.ToInteger(Properties.Settings.Default.logprobs);
            }
            else
            {
                TrackBar5.Value = 1;
            }
            if (!(Properties.Settings.Default.presence_penalty == "Nothing"))
            {
                CheckBox6.Checked = true;
                TrackBar6.Value = (int)Math.Round(Conversions.ToDouble(Properties.Settings.Default.presence_penalty) * 10d);
            }
            else
            {
                TrackBar6.Value = 0;
            }
            if (!(Properties.Settings.Default.frequency_penalty == "Nothing"))
            {
                CheckBox7.Checked = true;
                TrackBar7.Value = (int)Math.Round(Conversions.ToDouble(Properties.Settings.Default.frequency_penalty) * 10d);
            }
            else
            {
                TrackBar7.Value = 0;
            }
            if (!(Properties.Settings.Default.best_of == "Nothing"))
            {
                CheckBox8.Checked = true;
                TrackBar8.Value = Conversions.ToInteger(Properties.Settings.Default.best_of);
            }
            else
            {
                TrackBar8.Value = 1;
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.stop))
            {
                CheckBox9.Checked = true;
                TextBox1.Text = Properties.Settings.Default.stop;
                TextBox1.ForeColor = SystemColors.ControlText;
            }
            else
            {

            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.logit_bias))
            {
                CheckBox10.Checked = true;
                TextBox2.Text = Properties.Settings.Default.logit_bias;
                TextBox2.ForeColor = SystemColors.ControlText;
            }
            else
            {

            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.model))
            {
                ComboBox1.Text = Properties.Settings.Default.model;
            }
            else
            {
                ComboBox1.Text = "gpt-3.5-turbo";
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.url))
            {
                TextBox3.Text = Properties.Settings.Default.url;
            }
            else
            {
                TextBox3.Text = "https://api.openai.com/v1/chat/completions";
            }

            if (!(Properties.Settings.Default.conversation_history_limit == "Nothing"))
            {
                CheckBox11.Checked = true;
                TrackBar9.Value = Conversions.ToInteger(Properties.Settings.Default.conversation_history_limit);
            }
            else
            {
                TrackBar9.Value = 2048;
            }

            TrackBar1_ValueChanged(TrackBar1, EventArgs.Empty);
            TrackBar2_ValueChanged(TrackBar2, EventArgs.Empty);
            TrackBar3_ValueChanged(TrackBar3, EventArgs.Empty);
            TrackBar4_ValueChanged(TrackBar4, EventArgs.Empty);
            TrackBar5_ValueChanged(TrackBar5, EventArgs.Empty);
            TrackBar6_ValueChanged(TrackBar6, EventArgs.Empty);
            TrackBar7_ValueChanged(TrackBar7, EventArgs.Empty);
            TrackBar8_ValueChanged(TrackBar8, EventArgs.Empty);
            TrackBar9_ValueChanged(TrackBar9, EventArgs.Empty);
        }
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            value1 = TrackBar1.Value;
            LabelN1.Text = value1.ToString();
        }
        private void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            value2 = Math.Round(TrackBar2.Value / 10.0d, 1);
            LabelN2.Text = value2.ToString();
        }
        private void TrackBar3_ValueChanged(object sender, EventArgs e)
        {
            value3 = Math.Round(TrackBar3.Value / 100.0d, 2);
            LabelN3.Text = value3.ToString();
        }
        private void TrackBar4_ValueChanged(object sender, EventArgs e)
        {
            value4 = TrackBar4.Value;
            LabelN4.Text = value4.ToString();
        }
        private void TrackBar5_ValueChanged(object sender, EventArgs e)
        {
            value5 = TrackBar5.Value;
            LabelN5.Text = value5.ToString();
        }
        private void TrackBar6_ValueChanged(object sender, EventArgs e)
        {
            value6 = Math.Round(TrackBar6.Value / 10.0d, 1);
            LabelN6.Text = value6.ToString();
        }
        private void TrackBar7_ValueChanged(object sender, EventArgs e)
        {
            value7 = Math.Round(TrackBar7.Value / 10.0d, 1);
            LabelN7.Text = value7.ToString();
        }
        private void TrackBar8_ValueChanged(object sender, EventArgs e)
        {
            value8 = TrackBar8.Value;
            LabelN8.Text = value8.ToString();
        }

        private void TrackBar9_ValueChanged(object sender, EventArgs e)
        {
            value12 = TrackBar9.Value;
            LabelN9.Text = value12.ToString();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                api_max_tokens = value1;
                Properties.Settings.Default.max_tokens = value1.ToString();
            }
            else
            {
                api_max_tokens = default;
                Properties.Settings.Default.max_tokens = "Nothing";
            }

            if (CheckBox2.Checked == true)
            {
                api_temperature = value2;
                Properties.Settings.Default.temperature = value2.ToString();
            }
            else
            {
                api_temperature = default;
                Properties.Settings.Default.temperature = "Nothing";
            }

            if (CheckBox3.Checked == true)
            {
                api_top_p = value3;
                Properties.Settings.Default.top_p = value3.ToString();
            }
            else
            {
                api_top_p = default;
                Properties.Settings.Default.top_p = "Nothing";
            }

            if (CheckBox4.Checked == true)
            {
                api_n = value4;
                Properties.Settings.Default.n = value4.ToString();
            }
            else
            {
                api_n = default;
                Properties.Settings.Default.n = "Nothing";
            }

            if (CheckBox5.Checked == true)
            {
                api_logprobs = value5;
                Properties.Settings.Default.logprobs = value5.ToString();
            }
            else
            {
                api_logprobs = default;
                Properties.Settings.Default.logprobs = "Nothing";
            }

            if (CheckBox6.Checked == true)
            {
                api_presence_penalty = value6;
                Properties.Settings.Default.presence_penalty = value6.ToString();
            }
            else
            {
                api_presence_penalty = default;
                Properties.Settings.Default.presence_penalty = "Nothing";
            }

            if (CheckBox7.Checked == true)
            {
                api_frequency_penalty = value7;
                Properties.Settings.Default.frequency_penalty = value7.ToString();
            }
            else
            {
                api_frequency_penalty = default;
                Properties.Settings.Default.frequency_penalty = "Nothing";
            }

            if (CheckBox8.Checked == true)
            {
                api_best_of = value8;
                Properties.Settings.Default.best_of = value8.ToString();
            }
            else
            {
                api_best_of = default;
                Properties.Settings.Default.best_of = "Nothing";
            }

            if (CheckBox9.Checked == true && !TextBox1.Text.StartsWith("ex") && !string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                api_stop = TextBox1.Text;
                Properties.Settings.Default.stop = TextBox1.Text;
            }
            else
            {
                api_stop = null;
                Properties.Settings.Default.stop = "";
            }

            if (CheckBox10.Checked == true && !TextBox2.Text.StartsWith("ex") && !string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                api_logit_bias = TextBox2.Text;
                Properties.Settings.Default.logit_bias = TextBox2.Text;
            }
            else
            {
                api_logit_bias = null;
                Properties.Settings.Default.logit_bias = "";
            }

            if (!string.IsNullOrWhiteSpace(ComboBox1.Text))
            {
                api_model = ComboBox1.Text;
                Properties.Settings.Default.model = ComboBox1.Text;
            }
            else
            {
                api_model = "gpt-3.5-turbo";
                Properties.Settings.Default.model = "gpt-3.5-turbo";
            }

            if (!string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                api_url = TextBox3.Text;
                Properties.Settings.Default.url = TextBox3.Text;
            }
            else
            {
                api_model = "https://api.openai.com/v1/chat/completions";
                Properties.Settings.Default.model = "https://api.openai.com/v1/chat/completions";
            }

            if (CheckBox11.Checked == true)
            {
                MAX_CONTENT_LENGTH = value12;
                Properties.Settings.Default.conversation_history_limit = value12.ToString();
            }
            else
            {
                MAX_CONTENT_LENGTH = default;
                Properties.Settings.Default.conversation_history_limit = "Nothing";
            }

            Properties.Settings.Default.Save();
            Close();
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (!(TextBox1.ForeColor == SystemColors.ControlText))
                TextBox1.ForeColor = SystemColors.ControlText;
            if (TextBox1.Text.StartsWith("ex", StringComparison.OrdinalIgnoreCase))
                TextBox1.Text = "";
        }

        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            if (!(TextBox2.ForeColor == SystemColors.ControlText))
                TextBox2.ForeColor = SystemColors.ControlText;
            if (TextBox2.Text.StartsWith("ex", StringComparison.OrdinalIgnoreCase))
                TextBox2.Text = "";
        }

        private void SetLabelPosition()
        {
            // 現在のLabel26の位置を取得する
            int x = this.Label26.Location.X;
            int y = this.Label26.Location.Y;

            // フォームのDPIを取得する
            Graphics graphics = this.CreateGraphics();
            float dpiX = graphics.DpiX;
            float dpiY = graphics.DpiY;

            // DPIに合わせてフォントサイズを計算する
            float fontSize = this.Label26.Font.Size;
            float scaledFontSize = fontSize * 96 / dpiY;
            Font scaledFont = new Font(this.Label26.Font.FontFamily, scaledFontSize, this.Label26.Font.Style);

            // Label26のサイズを再設定する
            //this.Label26.Font = scaledFont;
            //this.Label26.AutoSize = true;

            // Label26を中央寄せにする
            x = (this.ClientSize.Width - this.Label26.Width) / 2;
            this.Label26.Location = new Point(x, y);
        }
        // フォームのリサイズイベントでLabel26の位置を再設定する
        private void Form_Option_Resize(object sender, EventArgs e)
        {
            SetLabelPosition();
        }
    }
}