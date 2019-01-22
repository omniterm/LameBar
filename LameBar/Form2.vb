Imports LameBar.Form1

Public Class SettingsF
    Public PositionCBSettings As String

    Private Sub SettingsBOk_Click(sender As Object, e As EventArgs) Handles SettingsBOk.Click
        If PositionCBSettings = "Top" Then
            Form1.SetAppBarPosition(AppBarrPos.ABE_TOP)
        ElseIf PositionCBSettings = "Bottom" Then
            Form1.SetAppBarPosition(AppBarrPos.ABE_BOTTOM)
        ElseIf PositionCBSettings = "Left" Then
            Form1.SetAppBarPosition(AppBarrPos.ABE_LEFT)
        ElseIf PositionCBSettings = "Right" Then
            Form1.SetAppBarPosition(AppBarrPos.ABE_RIGHT)
        End If
        Me.Visible = False
    End Sub

    Private Sub SettingsF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SystemInformation.MonitorCount = 1 Then
            PositionCB.Items.Add("Top")
            PositionCB.Items.Add("Bottom")
            PositionCB.Items.Add("Left")
            PositionCB.Items.Add("Right")
            PositionCB.SelectedIndex = "2"
        ElseIf SystemInformation.MonitorCount = 2 Then
            PositionCB.Items.Add("Mon1: Top")
            PositionCB.Items.Add("Mon1: Bottom")
            PositionCB.Items.Add("Mon1: Left")
            PositionCB.Items.Add("Mon1: Right")
            PositionCB.Items.Add("Mon2: Top")
            PositionCB.Items.Add("Mon2: Bottom")
            PositionCB.Items.Add("Mon2: Left")
            PositionCB.Items.Add("Mon2: Right")
            PositionCB.SelectedIndex = "2"
        ElseIf SystemInformation.MonitorCount = 3 Then
            PositionCB.Items.Add("Mon1: Top")
            PositionCB.Items.Add("Mon1: Bottom")
            PositionCB.Items.Add("Mon1: Left")
            PositionCB.Items.Add("Mon1: Right")
            PositionCB.Items.Add("Mon2: Top")
            PositionCB.Items.Add("Mon2: Bottom")
            PositionCB.Items.Add("Mon2: Left")
            PositionCB.Items.Add("Mon2: Right")
            PositionCB.Items.Add("Mon3: Top")
            PositionCB.Items.Add("Mon3: Bottom")
            PositionCB.Items.Add("Mon3: Left")
            PositionCB.Items.Add("Mon3: Right")
            PositionCB.SelectedIndex = "2"
        End If
    End Sub

    Private Sub PositionCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PositionCB.SelectedIndexChanged
        If PositionCB.SelectedIndex = 0 Then
            Form1.DisNum = 1
            PositionCBSettings = "Top"
        ElseIf PositionCB.SelectedIndex = 1 Then
            Form1.DisNum = 1
            PositionCBSettings = "Bottom"
        ElseIf PositionCB.SelectedIndex = 2 Then
            Form1.DisNum = 1
            PositionCBSettings = "Left"
        ElseIf PositionCB.SelectedIndex = 3 Then
            Form1.DisNum = 1
            PositionCBSettings = "Right"
        ElseIf PositionCB.SelectedIndex = 4 Then
            Form1.DisNum = 2
            PositionCBSettings = "Top"
        ElseIf PositionCB.SelectedIndex = 5 Then
            Form1.DisNum = 2
            PositionCBSettings = "Bottom"
        ElseIf PositionCB.SelectedIndex = 6 Then
            Form1.DisNum = 2
            PositionCBSettings = "Left"
        ElseIf PositionCB.SelectedIndex = 7 Then
            Form1.DisNum = 2
            PositionCBSettings = "Right"
        ElseIf PositionCB.SelectedIndex = 8 Then
            Form1.DisNum = 3
            PositionCBSettings = "Top"
        ElseIf PositionCB.SelectedIndex = 9 Then
            Form1.DisNum = 3
            PositionCBSettings = "Bottom"
        ElseIf PositionCB.SelectedIndex = 10 Then
            Form1.DisNum = 3
            PositionCBSettings = "Left"
        ElseIf PositionCB.SelectedIndex = 11 Then
            Form1.DisNum = 3
            PositionCBSettings = "Right"
        End If
    End Sub
End Class