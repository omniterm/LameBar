Imports System.Runtime.InteropServices
Imports LameBar.SettingsF
Imports System
Imports System.ComponentModel
Imports System.Convert
Imports System.Text
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class Form1
    Private Const ABM_NEW As Integer = &H0
    Private Const ABM_REMOVE As Integer = &H1
    Private Const ABM_QUERYPOS As Integer = &H2
    Private Const ABM_SETPOS As Integer = &H3
    Private Const ABM_GETSTATE As Integer = &H4
    Private Const ABM_GETTASKBARPOS As Integer = &H5
    Private Const ABM_ACTIVATE As Integer = &H6
    Private Const ABM_GETAUTOHIDEBAR As Integer = &H7
    Private Const ABM_SETAUTOHIDEBAR As Integer = &H8
    Private Const ABM_WINDOWPOSCHANGED As Integer = &H9
    Private Const ABS_AUTOHIDE As Integer = &H1
    Private Const ABS_ALWAYSONTOP As Integer = &H2
    Public SettingBottom As Integer
    Public SettingRight As Integer
    Public SettingBottom1 As Integer
    Public SettingRight1 As Integer
    Public SettingBottom2 As Integer
    Public SettingRight2 As Integer
    Public SettingBottom3 As Integer
    Public SettingRight3 As Integer
    Public MonNum As Integer
    Public DisNum As Integer
    Public abPosition As String

    Public StartLocation As String
    'This is the AppBar message constant to identify the appbar messages when they are recieved in the
    'Overrides WndProc sub. Used to recieve messages from the AppBar. Read the msdn document at link below.
    'http://msdn.microsoft.com/en-us/library/windows/desktop/cc144177%28v=vs.85%29.aspx
    Private Const APPBAR_CALLBACKMESSAGE As Integer = &H401

    Private abd As APPBARDATA

    <DllImport("shell32.dll", EntryPoint:="SHAppBarMessage", CallingConvention:=CallingConvention.StdCall)>
    Private Shared Function SHAppBarMessage(ByVal dwMessage As UInteger, ByRef pData As APPBARDATA) As UIntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="MoveWindow")>
        Private Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, <MarshalAs(UnmanagedType.Bool)> ByVal bRepaint As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

    <StructLayout(LayoutKind.Sequential)>
        Private Structure APPBARDATA
            Dim cbSize As Integer
            Dim hwnd As IntPtr
            Dim uCallbackMessage As Integer
            Dim uEdge As Integer
            Dim rc As RECT
            Dim lParam As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Private Structure RECT
            Dim Left As Integer
            Dim Top As Integer
            Dim Right As Integer
            Dim Bottom As Integer
        End Structure

        Public Enum AppBarrPos As Integer
            ABE_LEFT = &H0
            ABE_TOP = &H1
            ABE_RIGHT = &H2
            ABE_BOTTOM = &H3
        End Enum

        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.Style = cp.Style And -12582913
                cp.Style = cp.Style And -8388609
                Return cp
            End Get
        End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load 'On load, this works, but only with fixed border.
        Me.Visible = False
        SettingsF.Visible = False
        Me.TopMost = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        DisNum = My.Settings.DisNum
        StartLocation = My.Settings.AppBarPosition
        SettingsButtonLocation()
        RegisterNewAppBar() 'Register the AppBar
        SetAppBarPosition(AppBarrPos.ABE_TOP)
    End Sub

    Private Sub LoadSettings()
        If StartLocation = "Top" Then 'Set the edge to start on
            SetAppBarPosition(AppBarrPos.ABE_TOP)
        ElseIf StartLocation = "Bottom" Then
            SetAppBarPosition(AppBarrPos.ABE_BOTTOM)
        ElseIf StartLocation = "Left" Then
            SetAppBarPosition(AppBarrPos.ABE_LEFT)
        ElseIf StartLocation = "Right" Then
            SetAppBarPosition(AppBarrPos.ABE_RIGHT)
        Else
            SetAppBarPosition(AppBarrPos.ABE_TOP)
        End If
    End Sub

    Private Sub SettingsButtonLocation()
        Dim TBWidth1 As Integer
        Dim TBHeight1 As Integer
        Dim TBWidth2 As Integer
        Dim TBHeight2 As Integer
        Dim TBWidth3 As Integer
        Dim TBHeight3 As Integer

        If SystemInformation.MonitorCount > 0 Then
                TBWidth1 = Screen.AllScreens(0).Bounds.Width - Screen.AllScreens(0).WorkingArea.Width
                TBHeight1 = Screen.AllScreens(0).Bounds.Height - Screen.AllScreens(0).WorkingArea.Height
                SettingBottom1 = Screen.AllScreens(0).Bounds.Height - TBHeight1 - 47
                SettingRight1 = Screen.AllScreens(0).Bounds.Width - TBWidth1 - 48
            End If
            If SystemInformation.MonitorCount > 1 Then
                TBWidth2 = Screen.AllScreens(1).Bounds.Width - Screen.AllScreens(1).WorkingArea.Width
                TBHeight2 = Screen.AllScreens(1).Bounds.Height - Screen.AllScreens(1).WorkingArea.Height
                SettingBottom2 = Screen.AllScreens(1).Bounds.Height - TBHeight2 - 47
                SettingRight2 = Screen.AllScreens(1).Bounds.Width - TBWidth2 - 48
            End If
            If SystemInformation.MonitorCount > 2 Then
                TBWidth3 = Screen.AllScreens(2).Bounds.Width - Screen.AllScreens(1).Bounds.Width - Screen.AllScreens(2).WorkingArea.Width
                TBHeight3 = Screen.AllScreens(2).Bounds.Height - Screen.AllScreens(2).WorkingArea.Height
                SettingBottom3 = Screen.AllScreens(2).Bounds.Height - TBHeight3 - 47
                SettingRight3 = Screen.AllScreens(2).Bounds.Width - TBWidth3 - 48
            End If
        End Sub

        Private Sub RegisterNewAppBar()
            abd = New APPBARDATA With {
                .cbSize = Marshal.SizeOf(GetType(APPBARDATA)),
                .hwnd = Me.Handle,
                .uCallbackMessage = APPBAR_CALLBACKMESSAGE
            }
            SHAppBarMessage(ABM_NEW, abd)
        End Sub

        Public Sub SetAppBarPosition(ByVal ab_Position As AppBarrPos)

            If DisNum = 1 Then  'MonNum should be 0
                If MonNum = 1 Or 2 Then
                    SHAppBarMessage(ABM_REMOVE, abd)
                    RegisterNewAppBar()
                End If
            ElseIf DisNum = 2 Then  'MonNum should be 1
                If MonNum = 0 Or 2 Then
                    SHAppBarMessage(ABM_REMOVE, abd)
                    RegisterNewAppBar()
                End If
            ElseIf DisNum = 3 Then  'MonNum should be 2
                If MonNum = 0 Or 1 Then
                    SHAppBarMessage(ABM_REMOVE, abd)
                    RegisterNewAppBar()
                End If
            End If

            With abd
                .uEdge = ab_Position 'set the left, right, top, or bottom edge for the appbar
                abPosition = ab_Position

                'Locate Num of Monitors
                If SystemInformation.MonitorCount = 1 Then
                    DisNum = 1
                    MonNum = 0
                    SettingBottom = SettingBottom1
                    SettingRight = SettingRight1
                ElseIf SystemInformation.MonitorCount = 2 Then
                    If DisNum = 1 Then
                        MonNum = 0
                        SettingBottom = SettingBottom1
                        SettingRight = SettingRight1
                    ElseIf DisNum = 2 Then
                        MonNum = 1
                        SettingBottom = SettingBottom2
                        SettingRight = SettingRight2
                    ElseIf DisNum = 3 Then
                        MonNum = 2
                        SettingBottom = SettingBottom3
                        SettingRight = SettingRight3
                    End If
                ElseIf SystemInformation.MonitorCount = 3 Then
                    If DisNum = 1 Then
                        MonNum = 0
                        SettingBottom = SettingBottom1
                        SettingRight = SettingRight1
                    ElseIf DisNum = 2 Then
                        MonNum = 1
                        SettingBottom = SettingBottom2
                        SettingRight = SettingRight2
                    ElseIf DisNum = 3 Then
                        MonNum = 2
                        SettingBottom = SettingBottom3
                        SettingRight = SettingRight3
                    End If
                End If

            'set the desired rectangle for the appbar and position the buttons
            If ab_Position = AppBarrPos.ABE_RIGHT Then
                .rc.Top = Screen.AllScreens(MonNum).Bounds.Top
                .rc.Left = Screen.AllScreens(MonNum).Bounds.Right - 100
                .rc.Right = Screen.AllScreens(MonNum).Bounds.Right
                .rc.Bottom = Screen.AllScreens(MonNum).Bounds.Height
                Button_Top.Location = New Point(15, 15)
                Button_Bottom.Location = New Point(15, 45)
                Button_Left.Location = New Point(15, 75)
                Button_Right.Location = New Point(15, 105)
                Button_Top2.Location = New Point(15, 135)
                Button_Bottom2.Location = New Point(15, 165)
                Button_Left2.Location = New Point(15, 195)
                Button_Right2.Location = New Point(15, 225)
                Button_Close.Location = New Point(15, 255)
                SettingsPB.Location = New Point(33.5, SettingBottom)
            ElseIf ab_Position = AppBarrPos.ABE_TOP Then
                .rc.Top = Screen.AllScreens(MonNum).Bounds.Top
                .rc.Left = Screen.AllScreens(MonNum).Bounds.Left
                .rc.Right = Screen.AllScreens(MonNum).Bounds.Right
                .rc.Bottom = Screen.AllScreens(MonNum).Bounds.Top + 100
                Button_Top.Location = New Point(15, 37.5)
                Button_Bottom.Location = New Point(95, 37.5)
                Button_Left.Location = New Point(175, 37.5)
                Button_Right.Location = New Point(255, 37.5)
                Button_Top2.Location = New Point(335, 37.5)
                Button_Bottom2.Location = New Point(415, 37.5)
                Button_Left2.Location = New Point(495, 37.5)
                Button_Right2.Location = New Point(575, 37.5)
                Button_Close.Location = New Point(655, 37.5)
                SettingsPB.Location = New Point(SettingRight, 34)
            ElseIf ab_Position = AppBarrPos.ABE_LEFT Then
                .rc.Top = Screen.AllScreens(MonNum).Bounds.Top
                .rc.Left = Screen.AllScreens(MonNum).Bounds.Left
                .rc.Right = Screen.AllScreens(MonNum).Bounds.Right + 100
                .rc.Bottom = Screen.AllScreens(MonNum).Bounds.Height
                Button_Top.Location = New Point(15, 15)
                Button_Bottom.Location = New Point(15, 45)
                Button_Left.Location = New Point(15, 75)
                Button_Right.Location = New Point(15, 105)
                Button_Top2.Location = New Point(15, 135)
                Button_Bottom2.Location = New Point(15, 165)
                Button_Left2.Location = New Point(15, 195)
                Button_Right2.Location = New Point(15, 225)
                Button_Close.Location = New Point(15, 255)
                SettingsPB.Location = New Point(33.5, SettingBottom)
            ElseIf ab_Position = AppBarrPos.ABE_BOTTOM Then
                .rc.Top = Screen.AllScreens(MonNum).Bounds.Bottom - 100
                .rc.Left = Screen.AllScreens(MonNum).Bounds.Left
                .rc.Right = Screen.AllScreens(MonNum).Bounds.Right
                .rc.Bottom = Screen.AllScreens(MonNum).Bounds.Bottom
                Button_Top.Location = New Point(15, 37.5)
                Button_Bottom.Location = New Point(95, 37.5)
                Button_Left.Location = New Point(175, 37.5)
                Button_Right.Location = New Point(255, 37.5)
                Button_Top2.Location = New Point(335, 37.5)
                Button_Bottom2.Location = New Point(415, 37.5)
                Button_Left2.Location = New Point(495, 37.5)
                Button_Right2.Location = New Point(575, 37.5)
                Button_Close.Location = New Point(655, 37.5)
                SettingsPB.Location = New Point(SettingRight, 34)
            End If

                'Request the position and size. When returned the rect is adjusted to not interfere with taskbar and other appbars
                SHAppBarMessage(ABM_QUERYPOS, abd)

                'resets the size of the window if the rect`s position was adjusted by the ABM_QUERYPOS call
                If ab_Position = AppBarrPos.ABE_RIGHT Then
                    .rc.Left = .rc.Right - 100
                ElseIf ab_Position = AppBarrPos.ABE_TOP Then
                    .rc.Bottom = .rc.Top + 100
                ElseIf ab_Position = AppBarrPos.ABE_LEFT Then
                    .rc.Right = .rc.Left + 100
                ElseIf ab_Position = AppBarrPos.ABE_BOTTOM Then
                    .rc.Top = .rc.Bottom - 100
                End If

                SHAppBarMessage(ABM_SETPOS, abd)
                MoveWindow(.hwnd, .rc.Left, .rc.Top, .rc.Right - .rc.Left, .rc.Bottom - .rc.Top, True)
                If Not Me.Visible Then Me.Visible = True
            End With
        End Sub

        Private Sub Button_Top_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Top.Click
            DisNum = 1
            SetAppBarPosition(AppBarrPos.ABE_TOP)
        End Sub

        Private Sub Button_Bottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Bottom.Click
            DisNum = 1
            SetAppBarPosition(AppBarrPos.ABE_BOTTOM)
        End Sub

        Private Sub Button_Left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Left.Click
            DisNum = 1
            SetAppBarPosition(AppBarrPos.ABE_LEFT)
        End Sub

        Private Sub Button_Right_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Right.Click
            DisNum = 1
            SetAppBarPosition(AppBarrPos.ABE_RIGHT)
        End Sub

        Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Close.Click
            Me.Close()
        End Sub

        Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            SHAppBarMessage(ABM_REMOVE, abd)
        End Sub

        Private Sub Button_Top2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Top2.Click
            DisNum = 2
            SetAppBarPosition(AppBarrPos.ABE_TOP)
        End Sub

        Private Sub Button_Bottom2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Bottom2.Click
            DisNum = 2
            SetAppBarPosition(AppBarrPos.ABE_BOTTOM)
        End Sub

        Private Sub Button_Left2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Left2.Click
            DisNum = 2
            SetAppBarPosition(AppBarrPos.ABE_LEFT)
        End Sub

        Private Sub Button_Right2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Right2.Click
            DisNum = 2
            SetAppBarPosition(AppBarrPos.ABE_RIGHT)
        End Sub

        Private Sub SettingsPB_Click(sender As Object, e As EventArgs) Handles SettingsPB.Click
            'Future home of the settings box.
            SettingsF.Visible = True
        End Sub

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            Select Case keyData
                Case Keys.F12
                MsgBox("TempLocation: " & StartLocation & vbCrLf + "AppPosition: " & My.Settings.AppBarPosition)
        End Select

        Return True
        End Function
    End Class