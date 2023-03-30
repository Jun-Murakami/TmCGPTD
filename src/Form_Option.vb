Imports TmCGPTD.My
Imports TmCGPTD.Form1
Public Class Form_Option
    Private value1 As Integer
    Private value2 As Double
    Private value3 As Double
    Private value4 As Integer
    Private value5 As Integer
    Private value6 As Double
    Private value7 As Double
    Private value8 As Integer
    Private value9 As String
    Private value10 As String
    Private value11 As String
    Private value12 As Integer
    Private Sub Form_Option_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not My.Settings.max_tokens = "Nothing" Then
            CheckBox1.Checked = True
            TrackBar1.Value = CType(My.Settings.max_tokens, Integer)
        Else
            TrackBar1.Value = 2048
        End If
        If Not My.Settings.temperature = "Nothing" Then
            CheckBox2.Checked = True
            TrackBar2.Value = CType(CType(My.Settings.temperature, Double) * 10, Integer)
        Else
            TrackBar2.Value = 10
        End If
        If Not My.Settings.top_p = "Nothing" Then
            CheckBox3.Checked = True
            TrackBar3.Value = CType(CType(My.Settings.top_p, Double) * 100, Integer)
        Else
            TrackBar3.Value = 100
        End If
        If Not My.Settings.n = "Nothing" Then
            CheckBox4.Checked = True
            TrackBar4.Value = CType(My.Settings.n, Integer)
        Else
            TrackBar4.Value = 1
        End If
        If Not My.Settings.logprobs = "Nothing" Then
            CheckBox5.Checked = True
            TrackBar5.Value = CType(My.Settings.logprobs, Integer)
        Else
            TrackBar5.Value = 1
        End If
        If Not My.Settings.presence_penalty = "Nothing" Then
            CheckBox6.Checked = True
            TrackBar6.Value = CType(CType(My.Settings.presence_penalty, Double) * 10, Integer)
        Else
            TrackBar6.Value = 0
        End If
        If Not My.Settings.frequency_penalty = "Nothing" Then
            CheckBox7.Checked = True
            TrackBar7.Value = CType(CType(My.Settings.frequency_penalty, Double) * 10, Integer)
        Else
            TrackBar7.Value = 0
        End If
        If Not My.Settings.best_of = "Nothing" Then
            CheckBox8.Checked = True
            TrackBar8.Value = CType(My.Settings.best_of, Integer)
        Else
            TrackBar8.Value = 1
        End If

        If Not My.Settings.stop = "" Then
            CheckBox9.Checked = True
            TextBox1.Text = My.Settings.stop
            TextBox1.ForeColor = SystemColors.ControlText
        Else

        End If

        If Not My.Settings.logit_bias = "" Then
            CheckBox10.Checked = True
            TextBox2.Text = My.Settings.logit_bias
            TextBox2.ForeColor = SystemColors.ControlText
        Else

        End If

        If Not My.Settings.model = "" Then
            ComboBox1.Text = My.Settings.model
        Else
            ComboBox1.Text = "gpt-3.5-turbo"
        End If

        If Not My.Settings.url = "" Then
            TextBox3.Text = My.Settings.url
        Else
            TextBox3.Text = "https://api.openai.com/v1/chat/completions"
        End If

        If Not My.Settings.conversation_history_limit = "Nothing" Then
            TrackBar9.Value = CType(My.Settings.conversation_history_limit, Integer)
        Else
            TrackBar9.Value = 1920
        End If

        TrackBar1_ValueChanged(TrackBar1, EventArgs.Empty)
        TrackBar2_ValueChanged(TrackBar2, EventArgs.Empty)
        TrackBar3_ValueChanged(TrackBar3, EventArgs.Empty)
        TrackBar4_ValueChanged(TrackBar4, EventArgs.Empty)
        TrackBar5_ValueChanged(TrackBar5, EventArgs.Empty)
        TrackBar6_ValueChanged(TrackBar6, EventArgs.Empty)
        TrackBar7_ValueChanged(TrackBar7, EventArgs.Empty)
        TrackBar8_ValueChanged(TrackBar8, EventArgs.Empty)
        TrackBar9_ValueChanged(TrackBar9, EventArgs.Empty)
    End Sub
    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        value1 = TrackBar1.Value
        LabelN1.Text = value1.ToString()
    End Sub
    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        value2 = Math.Round(TrackBar2.Value / 10.0, 1)
        LabelN2.Text = value2.ToString()
    End Sub
    Private Sub TrackBar3_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar3.ValueChanged
        value3 = Math.Round(TrackBar3.Value / 100.0, 2)
        LabelN3.Text = value3.ToString()
    End Sub
    Private Sub TrackBar4_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar4.ValueChanged
        value4 = TrackBar4.Value
        LabelN4.Text = value4.ToString()
    End Sub
    Private Sub TrackBar5_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar5.ValueChanged
        value5 = TrackBar5.Value
        LabelN5.Text = value5.ToString()
    End Sub
    Private Sub TrackBar6_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar6.ValueChanged
        value6 = Math.Round(TrackBar6.Value / 10.0, 1)
        LabelN6.Text = value6.ToString()
    End Sub
    Private Sub TrackBar7_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar7.ValueChanged
        value7 = Math.Round(TrackBar7.Value / 10.0, 1)
        LabelN7.Text = value7.ToString()
    End Sub
    Private Sub TrackBar8_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar8.ValueChanged
        value8 = TrackBar8.Value
        LabelN8.Text = value8.ToString()
    End Sub

    Private Sub TrackBar9_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar9.ValueChanged
        value12 = TrackBar9.Value
        LabelN9.Text = value12.ToString()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If CheckBox1.Checked = True Then
            api_max_tokens = value1
            My.Settings.max_tokens = value1.ToString
        Else
            api_max_tokens = Nothing
            My.Settings.max_tokens = "Nothing"
        End If

        If CheckBox2.Checked = True Then
            api_temperature = value2
            My.Settings.temperature = value2.ToString
        Else
            api_temperature = Nothing
            My.Settings.temperature = "Nothing"
        End If

        If CheckBox3.Checked = True Then
            api_top_p = value3
            My.Settings.top_p = value3.ToString
        Else
            api_top_p = Nothing
            My.Settings.top_p = "Nothing"
        End If

        If CheckBox4.Checked = True Then
            api_n = value4
            My.Settings.n = value4.ToString
        Else
            api_n = Nothing
            My.Settings.n = "Nothing"
        End If

        If CheckBox5.Checked = True Then
            api_logprobs = value5
            My.Settings.logprobs = value5.ToString
        Else
            api_logprobs = Nothing
            My.Settings.logprobs = "Nothing"
        End If

        If CheckBox6.Checked = True Then
            api_presence_penalty = value6
            My.Settings.presence_penalty = value6.ToString
        Else
            api_presence_penalty = Nothing
            My.Settings.presence_penalty = "Nothing"
        End If

        If CheckBox7.Checked = True Then
            api_frequency_penalty = value7
            My.Settings.frequency_penalty = value7.ToString
        Else
            api_frequency_penalty = Nothing
            My.Settings.frequency_penalty = "Nothing"
        End If

        If CheckBox8.Checked = True Then
            api_best_of = value8
            My.Settings.best_of = value8.ToString
        Else
            api_best_of = Nothing
            My.Settings.best_of = "Nothing"
        End If

        If CheckBox9.Checked = True AndAlso Not TextBox1.Text.StartsWith("ex") AndAlso Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            api_stop = TextBox1.Text
            My.Settings.stop = TextBox1.Text
        Else
            api_stop = Nothing
            My.Settings.stop = ""
        End If

        If CheckBox10.Checked = True AndAlso Not TextBox2.Text.StartsWith("ex") AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
            api_logit_bias = TextBox2.Text
            My.Settings.logit_bias = TextBox2.Text
        Else
            api_logit_bias = Nothing
            My.Settings.logit_bias = ""
        End If

        If Not String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            api_model = ComboBox1.Text
            My.Settings.model = ComboBox1.Text
        Else
            api_model = "gpt-3.5-turbo"
            My.Settings.model = "gpt-3.5-turbo"
        End If

        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
            api_url = TextBox3.Text
            My.Settings.url = TextBox3.Text
        Else
            api_model = "https://api.openai.com/v1/chat/completions"
            My.Settings.model = "https://api.openai.com/v1/chat/completions"
        End If

        If CheckBox11.Checked = True Then
            MAX_CONTENT_LENGTH = value12
            My.Settings.conversation_history_limit = value12.ToString
        Else
            MAX_CONTENT_LENGTH = Nothing
            My.Settings.conversation_history_limit = "Nothing"
        End If

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If Not TextBox1.ForeColor = SystemColors.ControlText Then TextBox1.ForeColor = SystemColors.ControlText
        If TextBox1.Text.StartsWith("ex", StringComparison.OrdinalIgnoreCase) Then TextBox1.Text = ""
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If Not TextBox2.ForeColor = SystemColors.ControlText Then TextBox2.ForeColor = SystemColors.ControlText
        If TextBox2.Text.StartsWith("ex", StringComparison.OrdinalIgnoreCase) Then TextBox2.Text = ""
    End Sub

End Class