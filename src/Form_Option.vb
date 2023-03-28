﻿Imports TmCGPTD.My
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
    Private value9 As Integer
    Private Sub Form_Option_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not My.Settings.max_tokens = "Nothing" Then
            CheckBox1.Checked = True
            TrackBar1.Value = CType(My.Settings.max_tokens, Integer)
        Else
            TrackBar1.Value = 16
        End If
        If Not My.Settings.temperature = "Nothing" Then
            CheckBox2.Checked = True
            TrackBar2.Value = CType(My.Settings.temperature, Integer) * 10
        Else
            TrackBar2.Value = 10
        End If
        If Not My.Settings.top_p = "Nothing" Then
            CheckBox3.Checked = True
            TrackBar3.Value = CType(My.Settings.top_p, Integer) * 100
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
            TrackBar6.Value = CType(My.Settings.presence_penalty, Integer)
        Else
            TrackBar6.Value = 0
        End If
        If Not My.Settings.frequency_penalty = "Nothing" Then
            CheckBox7.Checked = True
            TrackBar7.Value = CType(My.Settings.frequency_penalty, Integer)
        Else
            TrackBar7.Value = 0
        End If
        If Not My.Settings.best_of = "Nothing" Then
            CheckBox8.Checked = True
            TrackBar8.Value = CType(My.Settings.best_of, Integer)
        Else
            TrackBar8.Value = 1
        End If
        If Not My.Settings.logit_bias = "Nothing" Then
            CheckBox9.Checked = True
            TrackBar9.Value = CType(My.Settings.logit_bias, Integer)
        Else
            TrackBar9.Value = 0
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
        value9 = TrackBar9.Value
        LabelN9.Text = value9.ToString()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If CheckBox1.Checked = True Then
            max_tokens = value1
            My.Settings.max_tokens = value1.ToString
        Else
            max_tokens = Nothing
            My.Settings.max_tokens = "Nothing"
        End If

        If CheckBox2.Checked = True Then
            temperature = value2
            My.Settings.temperature = value2.ToString
        Else
            temperature = Nothing
            My.Settings.temperature = "Nothing"
        End If

        If CheckBox3.Checked = True Then
            top_p = value3
            My.Settings.top_p = value3.ToString
        Else
            top_p = Nothing
            My.Settings.top_p = "Nothing"
        End If

        If CheckBox4.Checked = True Then
            n = value4
            My.Settings.n = value4.ToString
        Else
            n = Nothing
            My.Settings.n = "Nothing"
        End If

        If CheckBox5.Checked = True Then
            logprobs = value5
            My.Settings.logprobs = value5.ToString
        Else
            logprobs = Nothing
            My.Settings.logprobs = "Nothing"
        End If

        If CheckBox6.Checked = True Then
            presence_penalty = value6
            My.Settings.presence_penalty = value6.ToString
        Else
            presence_penalty = Nothing
            My.Settings.presence_penalty = "Nothing"
        End If

        If CheckBox7.Checked = True Then
            frequency_penalty = value7
            My.Settings.frequency_penalty = value7.ToString
        Else
            frequency_penalty = Nothing
            My.Settings.frequency_penalty = "Nothing"
        End If

        If CheckBox8.Checked = True Then
            best_of = value8
            My.Settings.best_of = value8.ToString
        Else
            best_of = Nothing
            My.Settings.best_of = "Nothing"
        End If

        If CheckBox9.Checked = True Then
            logit_bias = value9
            My.Settings.logit_bias = value9.ToString
        Else
            logit_bias = Nothing
            My.Settings.logit_bias = "Nothing"
        End If

        My.Settings.Save()
        Me.Close()
    End Sub
End Class