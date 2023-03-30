Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Public Class CustomComboBox
    Inherits ComboBox

    Private Const WM_PAINT As Integer = &HF

    Public Sub New()
        MyBase.New()
        Me.DropDownStyle = ComboBoxStyle.DropDown
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.FlatStyle = FlatStyle.Flat
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = WM_PAINT Then
            Dim borderColor As Color = Color.FromArgb(106, 108, 125)
            Dim borderRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            Using g As Graphics = Me.CreateGraphics()
                Using borderPen As New Pen(borderColor)
                    g.DrawRectangle(borderPen, borderRectangle)
                End Using

                Dim buttonWidth As Integer = SystemInformation.VerticalScrollBarWidth
                Dim buttonBounds As New Rectangle(Me.Width - buttonWidth - 1, 0, buttonWidth, Me.Height - 1)

                ComboBoxRenderer.DrawDropDownButton(g, buttonBounds, VisualStyles.ComboBoxState.Normal)
                Using buttonBrush As New SolidBrush(borderColor)
                    g.FillRectangle(buttonBrush, New Rectangle(buttonBounds.X, buttonBounds.Y, buttonBounds.Width - 1, buttonBounds.Height))
                End Using
                ComboBoxRenderer.DrawDropDownButton(g, buttonBounds, VisualStyles.ComboBoxState.Normal)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        If e.Index >= 0 Then
            e.DrawBackground()
            e.Graphics.DrawString(Me.Items(e.Index).ToString(), e.Font, New SolidBrush(e.ForeColor), e.Bounds)
        End If
    End Sub
End Class
