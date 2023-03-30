<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Option
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TrackBar1 = New TrackBar()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        TrackBar2 = New TrackBar()
        TrackBar3 = New TrackBar()
        TrackBar4 = New TrackBar()
        TrackBar5 = New TrackBar()
        TrackBar6 = New TrackBar()
        LabelN1 = New Label()
        LabelN2 = New Label()
        LabelN3 = New Label()
        LabelN4 = New Label()
        LabelN5 = New Label()
        LabelN6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        ButtonOK = New Button()
        ButtonCancel = New Button()
        TrackBar7 = New TrackBar()
        Label14 = New Label()
        Label15 = New Label()
        TrackBar8 = New TrackBar()
        Label16 = New Label()
        LabelN7 = New Label()
        LabelN8 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        CheckBox1 = New CheckBox()
        CheckBox2 = New CheckBox()
        CheckBox3 = New CheckBox()
        CheckBox4 = New CheckBox()
        CheckBox5 = New CheckBox()
        CheckBox6 = New CheckBox()
        CheckBox7 = New CheckBox()
        CheckBox8 = New CheckBox()
        CheckBox9 = New CheckBox()
        Label20 = New Label()
        TextBox1 = New TextBox()
        Label21 = New Label()
        TextBox2 = New TextBox()
        CheckBox10 = New CheckBox()
        Label22 = New Label()
        Label23 = New Label()
        ComboBox1 = New ComboBox()
        TextBox3 = New TextBox()
        Label24 = New Label()
        Label25 = New Label()
        TrackBar9 = New TrackBar()
        CheckBox11 = New CheckBox()
        LabelN9 = New Label()
        Label26 = New Label()
        Label27 = New Label()
        CType(TrackBar1, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar2, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar3, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar4, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar5, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar6, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar7, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar8, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar9, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TrackBar1
        ' 
        TrackBar1.Location = New Point(169, 76)
        TrackBar1.Margin = New Padding(3, 40, 3, 3)
        TrackBar1.Maximum = 4096
        TrackBar1.Minimum = 1
        TrackBar1.Name = "TrackBar1"
        TrackBar1.Size = New Size(250, 45)
        TrackBar1.SmallChange = 4
        TrackBar1.TabIndex = 0
        TrackBar1.Value = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(70, 80)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(86, 19)
        Label1.TabIndex = 1
        Label1.Text = "max_tokens"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(67, 114)
        Label2.Margin = New Padding(10)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.Yes
        Label2.Size = New Size(89, 19)
        Label2.TabIndex = 2
        Label2.Text = "temperature"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(110, 154)
        Label3.Margin = New Padding(10)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.Yes
        Label3.Size = New Size(46, 19)
        Label3.TabIndex = 3
        Label3.Text = "top_p"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(136, 193)
        Label4.Margin = New Padding(10)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.Yes
        Label4.Size = New Size(17, 19)
        Label4.TabIndex = 4
        Label4.Text = "n"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.GrayText
        Label5.Location = New Point(91, 231)
        Label5.Margin = New Padding(10)
        Label5.Name = "Label5"
        Label5.RightToLeft = RightToLeft.Yes
        Label5.Size = New Size(65, 19)
        Label5.TabIndex = 5
        Label5.Text = "logprobs"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(29, 271)
        Label6.Margin = New Padding(10)
        Label6.Name = "Label6"
        Label6.RightToLeft = RightToLeft.Yes
        Label6.Size = New Size(124, 19)
        Label6.TabIndex = 6
        Label6.Text = "presence_penalty"
        ' 
        ' TrackBar2
        ' 
        TrackBar2.LargeChange = 1
        TrackBar2.Location = New Point(169, 115)
        TrackBar2.Maximum = 20
        TrackBar2.Name = "TrackBar2"
        TrackBar2.Size = New Size(250, 45)
        TrackBar2.TabIndex = 7
        TrackBar2.Value = 10
        ' 
        ' TrackBar3
        ' 
        TrackBar3.Location = New Point(169, 154)
        TrackBar3.Maximum = 100
        TrackBar3.Name = "TrackBar3"
        TrackBar3.Size = New Size(250, 45)
        TrackBar3.TabIndex = 8
        TrackBar3.Value = 1
        ' 
        ' TrackBar4
        ' 
        TrackBar4.LargeChange = 1
        TrackBar4.Location = New Point(169, 193)
        TrackBar4.Maximum = 128
        TrackBar4.Minimum = 1
        TrackBar4.Name = "TrackBar4"
        TrackBar4.Size = New Size(250, 45)
        TrackBar4.TabIndex = 9
        TrackBar4.Value = 1
        ' 
        ' TrackBar5
        ' 
        TrackBar5.LargeChange = 1
        TrackBar5.Location = New Point(169, 232)
        TrackBar5.Maximum = 5
        TrackBar5.Minimum = 1
        TrackBar5.Name = "TrackBar5"
        TrackBar5.Size = New Size(250, 45)
        TrackBar5.TabIndex = 10
        TrackBar5.Value = 1
        ' 
        ' TrackBar6
        ' 
        TrackBar6.LargeChange = 1
        TrackBar6.Location = New Point(169, 271)
        TrackBar6.Maximum = 20
        TrackBar6.Minimum = -20
        TrackBar6.Name = "TrackBar6"
        TrackBar6.Size = New Size(250, 45)
        TrackBar6.TabIndex = 11
        TrackBar6.Value = 1
        ' 
        ' LabelN1
        ' 
        LabelN1.AutoSize = True
        LabelN1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN1.Location = New Point(422, 76)
        LabelN1.Margin = New Padding(6, 10, 10, 10)
        LabelN1.Name = "LabelN1"
        LabelN1.Size = New Size(17, 19)
        LabelN1.TabIndex = 12
        LabelN1.Text = "0"
        ' 
        ' LabelN2
        ' 
        LabelN2.AutoSize = True
        LabelN2.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN2.Location = New Point(422, 115)
        LabelN2.Margin = New Padding(6, 10, 10, 10)
        LabelN2.Name = "LabelN2"
        LabelN2.Size = New Size(17, 19)
        LabelN2.TabIndex = 13
        LabelN2.Text = "0"
        ' 
        ' LabelN3
        ' 
        LabelN3.AutoSize = True
        LabelN3.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN3.Location = New Point(422, 154)
        LabelN3.Margin = New Padding(6, 10, 10, 10)
        LabelN3.Name = "LabelN3"
        LabelN3.Size = New Size(17, 19)
        LabelN3.TabIndex = 14
        LabelN3.Text = "0"
        ' 
        ' LabelN4
        ' 
        LabelN4.AutoSize = True
        LabelN4.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN4.Location = New Point(422, 193)
        LabelN4.Margin = New Padding(6, 10, 10, 10)
        LabelN4.Name = "LabelN4"
        LabelN4.Size = New Size(17, 19)
        LabelN4.TabIndex = 15
        LabelN4.Text = "0"
        ' 
        ' LabelN5
        ' 
        LabelN5.AutoSize = True
        LabelN5.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN5.Location = New Point(422, 232)
        LabelN5.Margin = New Padding(6, 10, 10, 10)
        LabelN5.Name = "LabelN5"
        LabelN5.Size = New Size(17, 19)
        LabelN5.TabIndex = 16
        LabelN5.Text = "0"
        ' 
        ' LabelN6
        ' 
        LabelN6.AutoSize = True
        LabelN6.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN6.Location = New Point(422, 271)
        LabelN6.Margin = New Padding(6, 10, 10, 10)
        LabelN6.Name = "LabelN6"
        LabelN6.Size = New Size(17, 19)
        LabelN6.TabIndex = 17
        LabelN6.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(548, 75)
        Label7.Margin = New Padding(20, 10, 10, 10)
        Label7.Name = "Label7"
        Label7.Size = New Size(41, 19)
        Label7.TabIndex = 18
        Label7.Text = "2048"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(548, 114)
        Label8.Margin = New Padding(6, 10, 10, 10)
        Label8.Name = "Label8"
        Label8.Size = New Size(17, 19)
        Label8.TabIndex = 19
        Label8.Text = "1"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(548, 153)
        Label9.Margin = New Padding(6, 10, 10, 10)
        Label9.Name = "Label9"
        Label9.Size = New Size(17, 19)
        Label9.TabIndex = 20
        Label9.Text = "1"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.Location = New Point(548, 192)
        Label10.Margin = New Padding(6, 10, 10, 10)
        Label10.Name = "Label10"
        Label10.Size = New Size(25, 19)
        Label10.TabIndex = 21
        Label10.Text = "20"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(548, 231)
        Label11.Margin = New Padding(6, 10, 10, 10)
        Label11.Name = "Label11"
        Label11.Size = New Size(33, 19)
        Label11.TabIndex = 22
        Label11.Text = "null"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.Location = New Point(548, 270)
        Label12.Margin = New Padding(6, 10, 10, 10)
        Label12.Name = "Label12"
        Label12.Size = New Size(29, 19)
        Label12.TabIndex = 23
        Label12.Text = "0.0"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.Location = New Point(534, 45)
        Label13.Margin = New Padding(10)
        Label13.Name = "Label13"
        Label13.Size = New Size(57, 19)
        Label13.TabIndex = 24
        Label13.Text = "Default"
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonOK.Location = New Point(184, 611)
        ButtonOK.Margin = New Padding(15)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(120, 40)
        ButtonOK.TabIndex = 25
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonCancel.Location = New Point(316, 611)
        ButtonCancel.Margin = New Padding(0, 15, 15, 15)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(120, 40)
        ButtonCancel.TabIndex = 27
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' TrackBar7
        ' 
        TrackBar7.LargeChange = 1
        TrackBar7.Location = New Point(169, 310)
        TrackBar7.Maximum = 20
        TrackBar7.Minimum = -20
        TrackBar7.Name = "TrackBar7"
        TrackBar7.Size = New Size(250, 45)
        TrackBar7.TabIndex = 28
        TrackBar7.Value = 1
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.Location = New Point(24, 310)
        Label14.Margin = New Padding(10)
        Label14.Name = "Label14"
        Label14.RightToLeft = RightToLeft.Yes
        Label14.Size = New Size(129, 19)
        Label14.TabIndex = 29
        Label14.Text = "frequency_penalty"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label15.ForeColor = SystemColors.GrayText
        Label15.Location = New Point(95, 349)
        Label15.Margin = New Padding(10)
        Label15.Name = "Label15"
        Label15.RightToLeft = RightToLeft.Yes
        Label15.Size = New Size(58, 19)
        Label15.TabIndex = 30
        Label15.Text = "best_of"
        ' 
        ' TrackBar8
        ' 
        TrackBar8.LargeChange = 1
        TrackBar8.Location = New Point(169, 349)
        TrackBar8.Maximum = 32
        TrackBar8.Minimum = 1
        TrackBar8.Name = "TrackBar8"
        TrackBar8.Size = New Size(250, 45)
        TrackBar8.TabIndex = 31
        TrackBar8.Value = 1
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label16.ForeColor = SystemColors.ControlText
        Label16.Location = New Point(116, 451)
        Label16.Margin = New Padding(10)
        Label16.Name = "Label16"
        Label16.RightToLeft = RightToLeft.Yes
        Label16.Size = New Size(37, 19)
        Label16.TabIndex = 32
        Label16.Text = "stop"
        ' 
        ' LabelN7
        ' 
        LabelN7.AutoSize = True
        LabelN7.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN7.Location = New Point(422, 310)
        LabelN7.Margin = New Padding(6, 10, 10, 10)
        LabelN7.Name = "LabelN7"
        LabelN7.Size = New Size(17, 19)
        LabelN7.TabIndex = 34
        LabelN7.Text = "0"
        ' 
        ' LabelN8
        ' 
        LabelN8.AutoSize = True
        LabelN8.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN8.Location = New Point(422, 349)
        LabelN8.Margin = New Padding(6, 10, 10, 10)
        LabelN8.Name = "LabelN8"
        LabelN8.Size = New Size(17, 19)
        LabelN8.TabIndex = 35
        LabelN8.Text = "0"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label17.Location = New Point(548, 309)
        Label17.Margin = New Padding(6, 10, 10, 10)
        Label17.Name = "Label17"
        Label17.Size = New Size(29, 19)
        Label17.TabIndex = 37
        Label17.Text = "0.0"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.Location = New Point(548, 348)
        Label18.Margin = New Padding(6, 10, 10, 10)
        Label18.Name = "Label18"
        Label18.Size = New Size(17, 19)
        Label18.TabIndex = 38
        Label18.Text = "1"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label19.Location = New Point(548, 450)
        Label19.Margin = New Padding(6, 10, 10, 10)
        Label19.Name = "Label19"
        Label19.Size = New Size(33, 19)
        Label19.TabIndex = 39
        Label19.Text = "null"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(483, 80)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(15, 14)
        CheckBox1.TabIndex = 40
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Location = New Point(483, 119)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(15, 14)
        CheckBox2.TabIndex = 41
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' CheckBox3
        ' 
        CheckBox3.AutoSize = True
        CheckBox3.Location = New Point(483, 158)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(15, 14)
        CheckBox3.TabIndex = 42
        CheckBox3.UseVisualStyleBackColor = True
        ' 
        ' CheckBox4
        ' 
        CheckBox4.AutoSize = True
        CheckBox4.Location = New Point(483, 197)
        CheckBox4.Name = "CheckBox4"
        CheckBox4.Size = New Size(15, 14)
        CheckBox4.TabIndex = 43
        CheckBox4.UseVisualStyleBackColor = True
        ' 
        ' CheckBox5
        ' 
        CheckBox5.AutoSize = True
        CheckBox5.Enabled = False
        CheckBox5.Location = New Point(483, 236)
        CheckBox5.Name = "CheckBox5"
        CheckBox5.Size = New Size(15, 14)
        CheckBox5.TabIndex = 44
        CheckBox5.UseVisualStyleBackColor = True
        ' 
        ' CheckBox6
        ' 
        CheckBox6.AutoSize = True
        CheckBox6.Location = New Point(483, 275)
        CheckBox6.Name = "CheckBox6"
        CheckBox6.Size = New Size(15, 14)
        CheckBox6.TabIndex = 45
        CheckBox6.UseVisualStyleBackColor = True
        ' 
        ' CheckBox7
        ' 
        CheckBox7.AutoSize = True
        CheckBox7.Location = New Point(483, 314)
        CheckBox7.Name = "CheckBox7"
        CheckBox7.Size = New Size(15, 14)
        CheckBox7.TabIndex = 46
        CheckBox7.UseVisualStyleBackColor = True
        ' 
        ' CheckBox8
        ' 
        CheckBox8.AutoSize = True
        CheckBox8.Enabled = False
        CheckBox8.ForeColor = SystemColors.Control
        CheckBox8.Location = New Point(483, 354)
        CheckBox8.Name = "CheckBox8"
        CheckBox8.Size = New Size(15, 14)
        CheckBox8.TabIndex = 47
        CheckBox8.UseVisualStyleBackColor = True
        ' 
        ' CheckBox9
        ' 
        CheckBox9.AutoSize = True
        CheckBox9.Location = New Point(483, 455)
        CheckBox9.Name = "CheckBox9"
        CheckBox9.Size = New Size(15, 14)
        CheckBox9.TabIndex = 48
        CheckBox9.UseVisualStyleBackColor = True
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label20.Location = New Point(465, 45)
        Label20.Margin = New Padding(10)
        Label20.Name = "Label20"
        Label20.Size = New Size(53, 19)
        Label20.TabIndex = 49
        Label20.Text = "Enable"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.ForeColor = SystemColors.GrayText
        TextBox1.Location = New Point(175, 446)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(276, 29)
        TextBox1.TabIndex = 50
        TextBox1.Text = "ex Cat,Dog,Apple"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label21.ForeColor = SystemColors.ControlText
        Label21.Location = New Point(80, 490)
        Label21.Margin = New Padding(10)
        Label21.Name = "Label21"
        Label21.RightToLeft = RightToLeft.Yes
        Label21.Size = New Size(73, 19)
        Label21.TabIndex = 51
        Label21.Text = "logit_bias"
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox2.ForeColor = SystemColors.GrayText
        TextBox2.Location = New Point(175, 485)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(276, 29)
        TextBox2.TabIndex = 52
        TextBox2.Text = "ex {""50256"": -100}, {""50257"": 50}"
        ' 
        ' CheckBox10
        ' 
        CheckBox10.AutoSize = True
        CheckBox10.Location = New Point(483, 494)
        CheckBox10.Name = "CheckBox10"
        CheckBox10.Size = New Size(15, 14)
        CheckBox10.TabIndex = 53
        CheckBox10.UseVisualStyleBackColor = True
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label22.Location = New Point(548, 489)
        Label22.Margin = New Padding(6, 10, 10, 10)
        Label22.Name = "Label22"
        Label22.Size = New Size(33, 19)
        Label22.TabIndex = 54
        Label22.Text = "null"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label23.Location = New Point(107, 25)
        Label23.Margin = New Padding(10)
        Label23.Name = "Label23"
        Label23.Size = New Size(49, 19)
        Label23.TabIndex = 55
        Label23.Text = "model"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"gpt-4", "gpt-4-0314", "gpt-4-32k", "gpt-4-32k-0314", "gpt-3.5-turbo", "gpt-3.5-turbo-0301"})
        ComboBox1.Location = New Point(175, 22)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(177, 27)
        ComboBox1.TabIndex = 56
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox3.ForeColor = SystemColors.ControlText
        TextBox3.Location = New Point(175, 524)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(276, 29)
        TextBox3.TabIndex = 57
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label24.ForeColor = SystemColors.ControlText
        Label24.Location = New Point(127, 529)
        Label24.Margin = New Padding(10)
        Label24.Name = "Label24"
        Label24.RightToLeft = RightToLeft.Yes
        Label24.Size = New Size(26, 19)
        Label24.TabIndex = 58
        Label24.Text = "url"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label25.Location = New Point(13, 388)
        Label25.Margin = New Padding(10)
        Label25.Name = "Label25"
        Label25.RightToLeft = RightToLeft.Yes
        Label25.Size = New Size(140, 38)
        Label25.TabIndex = 59
        Label25.Text = "conversation history" & vbCrLf & "limit"
        ' 
        ' TrackBar9
        ' 
        TrackBar9.Location = New Point(169, 388)
        TrackBar9.Margin = New Padding(3, 40, 3, 3)
        TrackBar9.Maximum = 4096
        TrackBar9.Minimum = 1
        TrackBar9.Name = "TrackBar9"
        TrackBar9.Size = New Size(250, 45)
        TrackBar9.SmallChange = 4
        TrackBar9.TabIndex = 60
        TrackBar9.Value = 4
        ' 
        ' CheckBox11
        ' 
        CheckBox11.AutoSize = True
        CheckBox11.ForeColor = SystemColors.Control
        CheckBox11.Location = New Point(483, 393)
        CheckBox11.Name = "CheckBox11"
        CheckBox11.Size = New Size(15, 14)
        CheckBox11.TabIndex = 62
        CheckBox11.UseVisualStyleBackColor = True
        ' 
        ' LabelN9
        ' 
        LabelN9.AutoSize = True
        LabelN9.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LabelN9.Location = New Point(421, 388)
        LabelN9.Margin = New Padding(6, 10, 10, 10)
        LabelN9.Name = "LabelN9"
        LabelN9.Size = New Size(17, 19)
        LabelN9.TabIndex = 63
        LabelN9.Text = "0"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label26.ForeColor = SystemColors.ControlText
        Label26.Location = New Point(49, 565)
        Label26.Margin = New Padding(10)
        Label26.Name = "Label26"
        Label26.RightToLeft = RightToLeft.No
        Label26.Size = New Size(533, 30)
        Label26.TabIndex = 64
        Label26.Text = """Conversation history limit"" is a client option, not an API parameter. " & vbCrLf & "When the set character limit is exceeded, the conversation history will be automatically deleted."
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label27.Location = New Point(548, 389)
        Label27.Margin = New Padding(6, 10, 10, 10)
        Label27.Name = "Label27"
        Label27.Size = New Size(41, 19)
        Label27.TabIndex = 65
        Label27.Text = "1920"
        ' 
        ' Form_Option
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(622, 675)
        Controls.Add(Label27)
        Controls.Add(Label26)
        Controls.Add(LabelN9)
        Controls.Add(CheckBox11)
        Controls.Add(TrackBar9)
        Controls.Add(Label25)
        Controls.Add(Label24)
        Controls.Add(TextBox3)
        Controls.Add(ComboBox1)
        Controls.Add(Label23)
        Controls.Add(Label22)
        Controls.Add(CheckBox10)
        Controls.Add(TextBox2)
        Controls.Add(Label21)
        Controls.Add(TextBox1)
        Controls.Add(Label20)
        Controls.Add(CheckBox9)
        Controls.Add(CheckBox8)
        Controls.Add(CheckBox7)
        Controls.Add(CheckBox6)
        Controls.Add(CheckBox5)
        Controls.Add(CheckBox4)
        Controls.Add(CheckBox3)
        Controls.Add(CheckBox2)
        Controls.Add(CheckBox1)
        Controls.Add(Label19)
        Controls.Add(Label18)
        Controls.Add(Label17)
        Controls.Add(LabelN8)
        Controls.Add(LabelN7)
        Controls.Add(Label16)
        Controls.Add(TrackBar8)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(TrackBar7)
        Controls.Add(ButtonCancel)
        Controls.Add(ButtonOK)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(LabelN6)
        Controls.Add(LabelN5)
        Controls.Add(LabelN4)
        Controls.Add(LabelN3)
        Controls.Add(LabelN2)
        Controls.Add(LabelN1)
        Controls.Add(TrackBar6)
        Controls.Add(TrackBar5)
        Controls.Add(TrackBar4)
        Controls.Add(TrackBar3)
        Controls.Add(TrackBar2)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TrackBar1)
        Name = "Form_Option"
        RightToLeft = RightToLeft.No
        Text = "API Parameters"
        CType(TrackBar1, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar2, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar3, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar4, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar5, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar6, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar7, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar8, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar9, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents TrackBar3 As TrackBar
    Friend WithEvents TrackBar4 As TrackBar
    Friend WithEvents TrackBar5 As TrackBar
    Friend WithEvents TrackBar6 As TrackBar
    Friend WithEvents LabelN1 As Label
    Friend WithEvents LabelN2 As Label
    Friend WithEvents LabelN3 As Label
    Friend WithEvents LabelN4 As Label
    Friend WithEvents LabelN5 As Label
    Friend WithEvents LabelN6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents TrackBar7 As TrackBar
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TrackBar8 As TrackBar
    Friend WithEvents Label16 As Label
    Friend WithEvents LabelN7 As Label
    Friend WithEvents LabelN8 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents TrackBar9 As TrackBar
    Friend WithEvents CheckBox11 As CheckBox
    Friend WithEvents LabelN9 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
End Class
