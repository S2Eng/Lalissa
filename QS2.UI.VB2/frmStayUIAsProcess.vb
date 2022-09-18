Imports System.Runtime.InteropServices


Public Class frmStayUIAsProcess

    Public IsLoaded As Boolean = False

    Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer
    Public bWindowSetToForeground As Boolean = False

    'Public Const MOD_ALT As Integer = &H1
    'Public Const WM_HOTKEY As Integer = &H312

    '<DllImport("User32.dll")>
    'Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr,
    '                    ByVal id As Integer, ByVal fsModifiers As Integer,
    '                    ByVal vk As Integer) As Integer
    'End Function

    '<DllImport("User32.dll")>
    'Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr,
    '                    ByVal id As Integer) As Integer
    'End Function

    'Private frmMCHelp1 As New design.auto.multiControl.frmMCHelp()












    Private Sub StayUIAsProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim p As New System.Drawing.Point(-300, -300)
            Me.Location = p

            Me.TimerSetWindowForeground.Enabled = False
            Me.TimerSetWindowForeground.Stop()

            If qs2.core.ENV.SendSetForgroundToMainStayUI Then
                'Me.TimerSetWindowForeground.Enabled = True
                'Me.TimerSetWindowForeground.Start()
            End If

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Launcher.ico_QS2, 32, 32)
            'RegisterHotKey(Me.Handle, 0, 0, Windows.Forms.Keys.F1)

            Me.IsLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Private Sub frmStayUIAsProcess_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Visible Then

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub frmStayUIAsProcess_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            e.Cancel = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class