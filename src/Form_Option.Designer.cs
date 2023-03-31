using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Option : Form
    {

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Windows フォーム デザイナーで必要です。
        private System.ComponentModel.IContainer components;

        // メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        // Windows フォーム デザイナーを使用して変更できます。  
        // コード エディターを使って変更しないでください。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            TrackBar1 = new TrackBar();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            TrackBar2 = new TrackBar();
            TrackBar3 = new TrackBar();
            TrackBar4 = new TrackBar();
            TrackBar5 = new TrackBar();
            TrackBar6 = new TrackBar();
            LabelN1 = new Label();
            LabelN2 = new Label();
            LabelN3 = new Label();
            LabelN4 = new Label();
            LabelN5 = new Label();
            LabelN6 = new Label();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            Label11 = new Label();
            Label12 = new Label();
            Label13 = new Label();
            ButtonOK = new Button();
            ButtonCancel = new Button();
            TrackBar7 = new TrackBar();
            Label14 = new Label();
            Label15 = new Label();
            TrackBar8 = new TrackBar();
            Label16 = new Label();
            LabelN7 = new Label();
            LabelN8 = new Label();
            Label17 = new Label();
            Label18 = new Label();
            Label19 = new Label();
            CheckBox1 = new CheckBox();
            CheckBox2 = new CheckBox();
            CheckBox3 = new CheckBox();
            CheckBox4 = new CheckBox();
            CheckBox5 = new CheckBox();
            CheckBox6 = new CheckBox();
            CheckBox7 = new CheckBox();
            CheckBox8 = new CheckBox();
            CheckBox9 = new CheckBox();
            Label20 = new Label();
            TextBox1 = new TextBox();
            Label21 = new Label();
            TextBox2 = new TextBox();
            CheckBox10 = new CheckBox();
            Label22 = new Label();
            Label23 = new Label();
            ComboBox1 = new ComboBox();
            TextBox3 = new TextBox();
            Label24 = new Label();
            Label25 = new Label();
            TrackBar9 = new TrackBar();
            CheckBox11 = new CheckBox();
            LabelN9 = new Label();
            Label26 = new Label();
            Label27 = new Label();
            ((System.ComponentModel.ISupportInitialize)TrackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar9).BeginInit();
            SuspendLayout();
            // 
            // TrackBar1
            // 
            TrackBar1.Location = new Point(169, 76);
            TrackBar1.Margin = new Padding(3, 40, 3, 3);
            TrackBar1.Maximum = 4096;
            TrackBar1.Minimum = 1;
            TrackBar1.Name = "TrackBar1";
            TrackBar1.Size = new Size(250, 45);
            TrackBar1.SmallChange = 4;
            TrackBar1.TabIndex = 0;
            TrackBar1.Value = 4;
            TrackBar1.ValueChanged += TrackBar1_ValueChanged;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label1.Location = new Point(70, 80);
            Label1.Margin = new Padding(10, 10, 10, 10);
            Label1.Name = "Label1";
            Label1.RightToLeft = RightToLeft.Yes;
            Label1.Size = new Size(86, 19);
            Label1.TabIndex = 1;
            Label1.Text = "max_tokens";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.Location = new Point(67, 114);
            Label2.Margin = new Padding(10, 10, 10, 10);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.Yes;
            Label2.Size = new Size(89, 19);
            Label2.TabIndex = 2;
            Label2.Text = "temperature";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.Location = new Point(110, 154);
            Label3.Margin = new Padding(10, 10, 10, 10);
            Label3.Name = "Label3";
            Label3.RightToLeft = RightToLeft.Yes;
            Label3.Size = new Size(46, 19);
            Label3.TabIndex = 3;
            Label3.Text = "top_p";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label4.Location = new Point(136, 193);
            Label4.Margin = new Padding(10, 10, 10, 10);
            Label4.Name = "Label4";
            Label4.RightToLeft = RightToLeft.Yes;
            Label4.Size = new Size(17, 19);
            Label4.TabIndex = 4;
            Label4.Text = "n";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label5.ForeColor = SystemColors.GrayText;
            Label5.Location = new Point(91, 231);
            Label5.Margin = new Padding(10, 10, 10, 10);
            Label5.Name = "Label5";
            Label5.RightToLeft = RightToLeft.Yes;
            Label5.Size = new Size(65, 19);
            Label5.TabIndex = 5;
            Label5.Text = "logprobs";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label6.Location = new Point(29, 271);
            Label6.Margin = new Padding(10, 10, 10, 10);
            Label6.Name = "Label6";
            Label6.RightToLeft = RightToLeft.Yes;
            Label6.Size = new Size(124, 19);
            Label6.TabIndex = 6;
            Label6.Text = "presence_penalty";
            // 
            // TrackBar2
            // 
            TrackBar2.LargeChange = 1;
            TrackBar2.Location = new Point(169, 115);
            TrackBar2.Maximum = 20;
            TrackBar2.Name = "TrackBar2";
            TrackBar2.Size = new Size(250, 45);
            TrackBar2.TabIndex = 7;
            TrackBar2.Value = 10;
            TrackBar2.ValueChanged += TrackBar2_ValueChanged;
            // 
            // TrackBar3
            // 
            TrackBar3.Location = new Point(169, 154);
            TrackBar3.Maximum = 100;
            TrackBar3.Name = "TrackBar3";
            TrackBar3.Size = new Size(250, 45);
            TrackBar3.TabIndex = 8;
            TrackBar3.Value = 1;
            TrackBar3.ValueChanged += TrackBar3_ValueChanged;
            // 
            // TrackBar4
            // 
            TrackBar4.LargeChange = 1;
            TrackBar4.Location = new Point(169, 193);
            TrackBar4.Maximum = 128;
            TrackBar4.Minimum = 1;
            TrackBar4.Name = "TrackBar4";
            TrackBar4.Size = new Size(250, 45);
            TrackBar4.TabIndex = 9;
            TrackBar4.Value = 1;
            TrackBar4.ValueChanged += TrackBar4_ValueChanged;
            // 
            // TrackBar5
            // 
            TrackBar5.LargeChange = 1;
            TrackBar5.Location = new Point(169, 232);
            TrackBar5.Maximum = 5;
            TrackBar5.Minimum = 1;
            TrackBar5.Name = "TrackBar5";
            TrackBar5.Size = new Size(250, 45);
            TrackBar5.TabIndex = 10;
            TrackBar5.Value = 1;
            TrackBar5.ValueChanged += TrackBar5_ValueChanged;
            // 
            // TrackBar6
            // 
            TrackBar6.LargeChange = 1;
            TrackBar6.Location = new Point(169, 271);
            TrackBar6.Maximum = 20;
            TrackBar6.Minimum = -20;
            TrackBar6.Name = "TrackBar6";
            TrackBar6.Size = new Size(250, 45);
            TrackBar6.TabIndex = 11;
            TrackBar6.Value = 1;
            TrackBar6.ValueChanged += TrackBar6_ValueChanged;
            // 
            // LabelN1
            // 
            LabelN1.AutoSize = true;
            LabelN1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN1.Location = new Point(422, 76);
            LabelN1.Margin = new Padding(6, 10, 10, 10);
            LabelN1.Name = "LabelN1";
            LabelN1.Size = new Size(17, 19);
            LabelN1.TabIndex = 12;
            LabelN1.Text = "0";
            // 
            // LabelN2
            // 
            LabelN2.AutoSize = true;
            LabelN2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN2.Location = new Point(422, 115);
            LabelN2.Margin = new Padding(6, 10, 10, 10);
            LabelN2.Name = "LabelN2";
            LabelN2.Size = new Size(17, 19);
            LabelN2.TabIndex = 13;
            LabelN2.Text = "0";
            // 
            // LabelN3
            // 
            LabelN3.AutoSize = true;
            LabelN3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN3.Location = new Point(422, 154);
            LabelN3.Margin = new Padding(6, 10, 10, 10);
            LabelN3.Name = "LabelN3";
            LabelN3.Size = new Size(17, 19);
            LabelN3.TabIndex = 14;
            LabelN3.Text = "0";
            // 
            // LabelN4
            // 
            LabelN4.AutoSize = true;
            LabelN4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN4.Location = new Point(422, 193);
            LabelN4.Margin = new Padding(6, 10, 10, 10);
            LabelN4.Name = "LabelN4";
            LabelN4.Size = new Size(17, 19);
            LabelN4.TabIndex = 15;
            LabelN4.Text = "0";
            // 
            // LabelN5
            // 
            LabelN5.AutoSize = true;
            LabelN5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN5.Location = new Point(422, 232);
            LabelN5.Margin = new Padding(6, 10, 10, 10);
            LabelN5.Name = "LabelN5";
            LabelN5.Size = new Size(17, 19);
            LabelN5.TabIndex = 16;
            LabelN5.Text = "0";
            // 
            // LabelN6
            // 
            LabelN6.AutoSize = true;
            LabelN6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN6.Location = new Point(422, 271);
            LabelN6.Margin = new Padding(6, 10, 10, 10);
            LabelN6.Name = "LabelN6";
            LabelN6.Size = new Size(17, 19);
            LabelN6.TabIndex = 17;
            LabelN6.Text = "0";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label7.Location = new Point(548, 75);
            Label7.Margin = new Padding(20, 10, 10, 10);
            Label7.Name = "Label7";
            Label7.Size = new Size(41, 19);
            Label7.TabIndex = 18;
            Label7.Text = "2048";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label8.Location = new Point(548, 114);
            Label8.Margin = new Padding(6, 10, 10, 10);
            Label8.Name = "Label8";
            Label8.Size = new Size(17, 19);
            Label8.TabIndex = 19;
            Label8.Text = "1";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label9.Location = new Point(548, 153);
            Label9.Margin = new Padding(6, 10, 10, 10);
            Label9.Name = "Label9";
            Label9.Size = new Size(17, 19);
            Label9.TabIndex = 20;
            Label9.Text = "1";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label10.Location = new Point(548, 192);
            Label10.Margin = new Padding(6, 10, 10, 10);
            Label10.Name = "Label10";
            Label10.Size = new Size(25, 19);
            Label10.TabIndex = 21;
            Label10.Text = "20";
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label11.Location = new Point(548, 231);
            Label11.Margin = new Padding(6, 10, 10, 10);
            Label11.Name = "Label11";
            Label11.Size = new Size(33, 19);
            Label11.TabIndex = 22;
            Label11.Text = "null";
            // 
            // Label12
            // 
            Label12.AutoSize = true;
            Label12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label12.Location = new Point(548, 270);
            Label12.Margin = new Padding(6, 10, 10, 10);
            Label12.Name = "Label12";
            Label12.Size = new Size(29, 19);
            Label12.TabIndex = 23;
            Label12.Text = "0.0";
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label13.Location = new Point(534, 45);
            Label13.Margin = new Padding(10, 10, 10, 10);
            Label13.Name = "Label13";
            Label13.Size = new Size(57, 19);
            Label13.TabIndex = 24;
            Label13.Text = "Default";
            // 
            // ButtonOK
            // 
            ButtonOK.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonOK.Location = new Point(184, 629);
            ButtonOK.Margin = new Padding(15, 15, 15, 15);
            ButtonOK.Name = "ButtonOK";
            ButtonOK.Size = new Size(120, 40);
            ButtonOK.TabIndex = 25;
            ButtonOK.Text = "OK";
            ButtonOK.UseVisualStyleBackColor = true;
            ButtonOK.Click += ButtonOK_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonCancel.Location = new Point(316, 629);
            ButtonCancel.Margin = new Padding(0, 15, 15, 15);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(120, 40);
            ButtonCancel.TabIndex = 27;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // TrackBar7
            // 
            TrackBar7.LargeChange = 1;
            TrackBar7.Location = new Point(169, 310);
            TrackBar7.Maximum = 20;
            TrackBar7.Minimum = -20;
            TrackBar7.Name = "TrackBar7";
            TrackBar7.Size = new Size(250, 45);
            TrackBar7.TabIndex = 28;
            TrackBar7.Value = 1;
            TrackBar7.ValueChanged += TrackBar7_ValueChanged;
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label14.Location = new Point(24, 310);
            Label14.Margin = new Padding(10, 10, 10, 10);
            Label14.Name = "Label14";
            Label14.RightToLeft = RightToLeft.Yes;
            Label14.Size = new Size(129, 19);
            Label14.TabIndex = 29;
            Label14.Text = "frequency_penalty";
            // 
            // Label15
            // 
            Label15.AutoSize = true;
            Label15.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label15.ForeColor = SystemColors.GrayText;
            Label15.Location = new Point(95, 349);
            Label15.Margin = new Padding(10, 10, 10, 10);
            Label15.Name = "Label15";
            Label15.RightToLeft = RightToLeft.Yes;
            Label15.Size = new Size(58, 19);
            Label15.TabIndex = 30;
            Label15.Text = "best_of";
            // 
            // TrackBar8
            // 
            TrackBar8.LargeChange = 1;
            TrackBar8.Location = new Point(169, 349);
            TrackBar8.Maximum = 32;
            TrackBar8.Minimum = 1;
            TrackBar8.Name = "TrackBar8";
            TrackBar8.Size = new Size(250, 45);
            TrackBar8.TabIndex = 31;
            TrackBar8.Value = 1;
            TrackBar8.ValueChanged += TrackBar8_ValueChanged;
            // 
            // Label16
            // 
            Label16.AutoSize = true;
            Label16.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label16.ForeColor = SystemColors.ControlText;
            Label16.Location = new Point(116, 451);
            Label16.Margin = new Padding(10, 10, 10, 10);
            Label16.Name = "Label16";
            Label16.RightToLeft = RightToLeft.Yes;
            Label16.Size = new Size(37, 19);
            Label16.TabIndex = 32;
            Label16.Text = "stop";
            // 
            // LabelN7
            // 
            LabelN7.AutoSize = true;
            LabelN7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN7.Location = new Point(422, 310);
            LabelN7.Margin = new Padding(6, 10, 10, 10);
            LabelN7.Name = "LabelN7";
            LabelN7.Size = new Size(17, 19);
            LabelN7.TabIndex = 34;
            LabelN7.Text = "0";
            // 
            // LabelN8
            // 
            LabelN8.AutoSize = true;
            LabelN8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN8.Location = new Point(422, 349);
            LabelN8.Margin = new Padding(6, 10, 10, 10);
            LabelN8.Name = "LabelN8";
            LabelN8.Size = new Size(17, 19);
            LabelN8.TabIndex = 35;
            LabelN8.Text = "0";
            // 
            // Label17
            // 
            Label17.AutoSize = true;
            Label17.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label17.Location = new Point(548, 309);
            Label17.Margin = new Padding(6, 10, 10, 10);
            Label17.Name = "Label17";
            Label17.Size = new Size(29, 19);
            Label17.TabIndex = 37;
            Label17.Text = "0.0";
            // 
            // Label18
            // 
            Label18.AutoSize = true;
            Label18.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label18.Location = new Point(548, 348);
            Label18.Margin = new Padding(6, 10, 10, 10);
            Label18.Name = "Label18";
            Label18.Size = new Size(17, 19);
            Label18.TabIndex = 38;
            Label18.Text = "1";
            // 
            // Label19
            // 
            Label19.AutoSize = true;
            Label19.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label19.Location = new Point(548, 450);
            Label19.Margin = new Padding(6, 10, 10, 10);
            Label19.Name = "Label19";
            Label19.Size = new Size(33, 19);
            Label19.TabIndex = 39;
            Label19.Text = "null";
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(483, 80);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(15, 14);
            CheckBox1.TabIndex = 40;
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            CheckBox2.AutoSize = true;
            CheckBox2.Location = new Point(483, 119);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(15, 14);
            CheckBox2.TabIndex = 41;
            CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            CheckBox3.AutoSize = true;
            CheckBox3.Location = new Point(483, 158);
            CheckBox3.Name = "CheckBox3";
            CheckBox3.Size = new Size(15, 14);
            CheckBox3.TabIndex = 42;
            CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            CheckBox4.AutoSize = true;
            CheckBox4.Location = new Point(483, 197);
            CheckBox4.Name = "CheckBox4";
            CheckBox4.Size = new Size(15, 14);
            CheckBox4.TabIndex = 43;
            CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox5
            // 
            CheckBox5.AutoSize = true;
            CheckBox5.Enabled = false;
            CheckBox5.Location = new Point(483, 236);
            CheckBox5.Name = "CheckBox5";
            CheckBox5.Size = new Size(15, 14);
            CheckBox5.TabIndex = 44;
            CheckBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox6
            // 
            CheckBox6.AutoSize = true;
            CheckBox6.Location = new Point(483, 275);
            CheckBox6.Name = "CheckBox6";
            CheckBox6.Size = new Size(15, 14);
            CheckBox6.TabIndex = 45;
            CheckBox6.UseVisualStyleBackColor = true;
            // 
            // CheckBox7
            // 
            CheckBox7.AutoSize = true;
            CheckBox7.Location = new Point(483, 314);
            CheckBox7.Name = "CheckBox7";
            CheckBox7.Size = new Size(15, 14);
            CheckBox7.TabIndex = 46;
            CheckBox7.UseVisualStyleBackColor = true;
            // 
            // CheckBox8
            // 
            CheckBox8.AutoSize = true;
            CheckBox8.Enabled = false;
            CheckBox8.ForeColor = SystemColors.Control;
            CheckBox8.Location = new Point(483, 354);
            CheckBox8.Name = "CheckBox8";
            CheckBox8.Size = new Size(15, 14);
            CheckBox8.TabIndex = 47;
            CheckBox8.UseVisualStyleBackColor = true;
            // 
            // CheckBox9
            // 
            CheckBox9.AutoSize = true;
            CheckBox9.Location = new Point(483, 455);
            CheckBox9.Name = "CheckBox9";
            CheckBox9.Size = new Size(15, 14);
            CheckBox9.TabIndex = 48;
            CheckBox9.UseVisualStyleBackColor = true;
            // 
            // Label20
            // 
            Label20.AutoSize = true;
            Label20.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label20.Location = new Point(465, 45);
            Label20.Margin = new Padding(10, 10, 10, 10);
            Label20.Name = "Label20";
            Label20.Size = new Size(53, 19);
            Label20.TabIndex = 49;
            Label20.Text = "Enable";
            // 
            // TextBox1
            // 
            TextBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBox1.ForeColor = SystemColors.GrayText;
            TextBox1.Location = new Point(175, 446);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(276, 29);
            TextBox1.TabIndex = 50;
            TextBox1.Text = "ex Cat,Dog,Apple";
            TextBox1.GotFocus += TextBox1_GotFocus;
            // 
            // Label21
            // 
            Label21.AutoSize = true;
            Label21.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label21.ForeColor = SystemColors.ControlText;
            Label21.Location = new Point(80, 490);
            Label21.Margin = new Padding(10, 10, 10, 10);
            Label21.Name = "Label21";
            Label21.RightToLeft = RightToLeft.Yes;
            Label21.Size = new Size(73, 19);
            Label21.TabIndex = 51;
            Label21.Text = "logit_bias";
            // 
            // TextBox2
            // 
            TextBox2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBox2.ForeColor = SystemColors.GrayText;
            TextBox2.Location = new Point(175, 485);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(276, 29);
            TextBox2.TabIndex = 52;
            TextBox2.Text = "ex {\"50256\": -100}, {\"50257\": 50}";
            TextBox2.GotFocus += TextBox2_GotFocus;
            // 
            // CheckBox10
            // 
            CheckBox10.AutoSize = true;
            CheckBox10.Location = new Point(483, 494);
            CheckBox10.Name = "CheckBox10";
            CheckBox10.Size = new Size(15, 14);
            CheckBox10.TabIndex = 53;
            CheckBox10.UseVisualStyleBackColor = true;
            // 
            // Label22
            // 
            Label22.AutoSize = true;
            Label22.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label22.Location = new Point(548, 489);
            Label22.Margin = new Padding(6, 10, 10, 10);
            Label22.Name = "Label22";
            Label22.Size = new Size(33, 19);
            Label22.TabIndex = 54;
            Label22.Text = "null";
            // 
            // Label23
            // 
            Label23.AutoSize = true;
            Label23.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label23.Location = new Point(107, 25);
            Label23.Margin = new Padding(10, 10, 10, 10);
            Label23.Name = "Label23";
            Label23.Size = new Size(49, 19);
            Label23.TabIndex = 55;
            Label23.Text = "model";
            // 
            // ComboBox1
            // 
            ComboBox1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Items.AddRange(new object[] { "gpt-4", "gpt-4-0314", "gpt-4-32k", "gpt-4-32k-0314", "gpt-3.5-turbo", "gpt-3.5-turbo-0301" });
            ComboBox1.Location = new Point(175, 22);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size(177, 27);
            ComboBox1.TabIndex = 56;
            // 
            // TextBox3
            // 
            TextBox3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBox3.ForeColor = SystemColors.ControlText;
            TextBox3.Location = new Point(175, 524);
            TextBox3.Name = "TextBox3";
            TextBox3.Size = new Size(276, 29);
            TextBox3.TabIndex = 57;
            // 
            // Label24
            // 
            Label24.AutoSize = true;
            Label24.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label24.ForeColor = SystemColors.ControlText;
            Label24.Location = new Point(127, 529);
            Label24.Margin = new Padding(10, 10, 10, 10);
            Label24.Name = "Label24";
            Label24.RightToLeft = RightToLeft.Yes;
            Label24.Size = new Size(26, 19);
            Label24.TabIndex = 58;
            Label24.Text = "url";
            // 
            // Label25
            // 
            Label25.AutoSize = true;
            Label25.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label25.Location = new Point(13, 388);
            Label25.Margin = new Padding(10, 10, 10, 10);
            Label25.Name = "Label25";
            Label25.RightToLeft = RightToLeft.Yes;
            Label25.Size = new Size(140, 38);
            Label25.TabIndex = 59;
            Label25.Text = "conversation history\r\nlimit";
            // 
            // TrackBar9
            // 
            TrackBar9.Location = new Point(169, 388);
            TrackBar9.Margin = new Padding(3, 40, 3, 3);
            TrackBar9.Maximum = 4096;
            TrackBar9.Minimum = 1;
            TrackBar9.Name = "TrackBar9";
            TrackBar9.Size = new Size(250, 45);
            TrackBar9.SmallChange = 4;
            TrackBar9.TabIndex = 60;
            TrackBar9.Value = 4;
            TrackBar9.ValueChanged += TrackBar9_ValueChanged;
            // 
            // CheckBox11
            // 
            CheckBox11.AutoSize = true;
            CheckBox11.ForeColor = SystemColors.Control;
            CheckBox11.Location = new Point(483, 393);
            CheckBox11.Name = "CheckBox11";
            CheckBox11.Size = new Size(15, 14);
            CheckBox11.TabIndex = 62;
            CheckBox11.UseVisualStyleBackColor = true;
            // 
            // LabelN9
            // 
            LabelN9.AutoSize = true;
            LabelN9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelN9.Location = new Point(421, 388);
            LabelN9.Margin = new Padding(6, 10, 10, 10);
            LabelN9.Name = "LabelN9";
            LabelN9.Size = new Size(17, 19);
            LabelN9.TabIndex = 63;
            LabelN9.Text = "0";
            // 
            // Label26
            // 
            Label26.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Label26.AutoSize = true;
            Label26.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Label26.ForeColor = SystemColors.ControlText;
            Label26.Location = new Point(122, 567);
            Label26.Margin = new Padding(10, 10, 10, 10);
            Label26.Name = "Label26";
            Label26.RightToLeft = RightToLeft.No;
            Label26.Size = new Size(376, 42);
            Label26.TabIndex = 64;
            Label26.Text = "\"conversation history limit\" is a client option, not an API parameter. \r\nWhen the set value (close to tokens) is exceeded,\r\nthe conversation history will be automatically summarized.";
            // 
            // Label27
            // 
            Label27.AutoSize = true;
            Label27.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label27.Location = new Point(548, 389);
            Label27.Margin = new Padding(6, 10, 10, 10);
            Label27.Name = "Label27";
            Label27.Size = new Size(41, 19);
            Label27.TabIndex = 65;
            Label27.Text = "2048";
            // 
            // Form_Option
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 689);
            Controls.Add(Label27);
            Controls.Add(Label26);
            Controls.Add(LabelN9);
            Controls.Add(CheckBox11);
            Controls.Add(TrackBar9);
            Controls.Add(Label25);
            Controls.Add(Label24);
            Controls.Add(TextBox3);
            Controls.Add(ComboBox1);
            Controls.Add(Label23);
            Controls.Add(Label22);
            Controls.Add(CheckBox10);
            Controls.Add(TextBox2);
            Controls.Add(Label21);
            Controls.Add(TextBox1);
            Controls.Add(Label20);
            Controls.Add(CheckBox9);
            Controls.Add(CheckBox8);
            Controls.Add(CheckBox7);
            Controls.Add(CheckBox6);
            Controls.Add(CheckBox5);
            Controls.Add(CheckBox4);
            Controls.Add(CheckBox3);
            Controls.Add(CheckBox2);
            Controls.Add(CheckBox1);
            Controls.Add(Label19);
            Controls.Add(Label18);
            Controls.Add(Label17);
            Controls.Add(LabelN8);
            Controls.Add(LabelN7);
            Controls.Add(Label16);
            Controls.Add(TrackBar8);
            Controls.Add(Label15);
            Controls.Add(Label14);
            Controls.Add(TrackBar7);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOK);
            Controls.Add(Label13);
            Controls.Add(Label12);
            Controls.Add(Label11);
            Controls.Add(Label10);
            Controls.Add(Label9);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(LabelN6);
            Controls.Add(LabelN5);
            Controls.Add(LabelN4);
            Controls.Add(LabelN3);
            Controls.Add(LabelN2);
            Controls.Add(LabelN1);
            Controls.Add(TrackBar6);
            Controls.Add(TrackBar5);
            Controls.Add(TrackBar4);
            Controls.Add(TrackBar3);
            Controls.Add(TrackBar2);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(TrackBar1);
            MaximizeBox = false;
            Name = "Form_Option";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "API Parameters";
            Shown += Form_Option_Shown;
            ((System.ComponentModel.ISupportInitialize)TrackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar6).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar7).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar8).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBar9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        internal TrackBar TrackBar1;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal TrackBar TrackBar2;
        internal TrackBar TrackBar3;
        internal TrackBar TrackBar4;
        internal TrackBar TrackBar5;
        internal TrackBar TrackBar6;
        internal Label LabelN1;
        internal Label LabelN2;
        internal Label LabelN3;
        internal Label LabelN4;
        internal Label LabelN5;
        internal Label LabelN6;
        internal Label Label7;
        internal Label Label8;
        internal Label Label9;
        internal Label Label10;
        internal Label Label11;
        internal Label Label12;
        internal Label Label13;
        internal Button ButtonOK;
        internal Button ButtonCancel;
        internal TrackBar TrackBar7;
        internal Label Label14;
        internal Label Label15;
        internal TrackBar TrackBar8;
        internal Label Label16;
        internal Label LabelN7;
        internal Label LabelN8;
        internal Label Label17;
        internal Label Label18;
        internal Label Label19;
        internal CheckBox CheckBox1;
        internal CheckBox CheckBox2;
        internal CheckBox CheckBox3;
        internal CheckBox CheckBox4;
        internal CheckBox CheckBox5;
        internal CheckBox CheckBox6;
        internal CheckBox CheckBox7;
        internal CheckBox CheckBox8;
        internal CheckBox CheckBox9;
        internal Label Label20;
        internal TextBox TextBox1;
        internal Label Label21;
        internal TextBox TextBox2;
        internal CheckBox CheckBox10;
        internal Label Label22;
        internal Label Label23;
        internal ComboBox ComboBox1;
        internal TextBox TextBox3;
        internal Label Label24;
        internal Label Label25;
        internal TrackBar TrackBar9;
        internal CheckBox CheckBox11;
        internal Label LabelN9;
        internal Label Label26;
        internal Label Label27;
    }
}