



Public Class frmActivity

    Public Shared info As String = ""
    'Public Shared ms_frmSplashxy As frmActivity = Nothing
    Public Shared ms_oThread As Threading.Thread = Nothing
    'Public Shared closeSplash As Boolean = False

    Public Shared lastFormActivity As frmActivity = Nothing
    Public closeSplash As Boolean = False

    Public Shared _TypeUI As eTypeUI
    Public Enum eTypeUI
        Main = 0
        Stay = 1
    End Enum

    Public Shared Sub ShowSplashScreen(txt As String, TypeUI As eTypeUI)
        'frmActivity._TypeUI = TypeUI
        'frmActivity.info = txt
        ''frmActivity.closeSplash = False
        'Dim ThreadStart1 As New Threading.ThreadStart(AddressOf frmActivity.ShowForm)
        'frmActivity.ms_oThread = New Threading.Thread(ThreadStart1)
        'frmActivity.ms_oThread.IsBackground = True
        'frmActivity.ms_oThread.SetApartmentState(Threading.ApartmentState.STA)
        'frmActivity.ms_oThread.Start()
    End Sub
    Public Shared Sub CloseSplashScreen()
        '''If Not frmActivity.ms_frmSplash Is Nothing Then
        '''frmActivity.ms_frmSplash.Close()
        ''frmActivity.ms_oThread = Nothing
        ''frmActivity.ms_frmSplash = Nothing
        '''End If
        ''frmActivity.closeSplash = True
        'If Not frmActivity.lastFormActivity Is Nothing Then
        '    frmActivity.lastFormActivity.closeSplash = True
        'End If
    End Sub
    Public Shared Sub ShowForm()
        'frmActivity.ms_frmSplash = New frmActivity()
        'System.Windows.Forms.Application.Run(frmActivity.ms_frmSplash)
        Dim NewFormActivity As New frmActivity()
        frmActivity.lastFormActivity = NewFormActivity
        System.Windows.Forms.Application.Run(NewFormActivity)
    End Sub


    Private Sub frmActivity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'If qs2.core.ENV.LoactionMain <> Nothing Then
        If frmActivity._TypeUI = eTypeUI.Stay And qs2.core.ENV.LoactionSizeStay.Width > 10 Then
            Me.Left = qs2.core.ENV.LoactionStay.X + (qs2.core.ENV.LoactionSizeStay.Width / 2) - (Me.Width / 2)
            Me.Top = qs2.core.ENV.LoactionStay.Y + (qs2.core.ENV.LoactionSizeStay.Height / 2) - (Me.Height / 2)
        Else
            Me.Left = qs2.core.ENV.LoactionMain.X + (qs2.core.ENV.LoactionSizeMain.Width / 2) - (Me.Width / 2)
            Me.Top = qs2.core.ENV.LoactionMain.Y + (qs2.core.ENV.LoactionSizeMain.Height / 2) - (Me.Height / 2)
        End If

        'End If
        Me.lblInfo.Text = frmActivity.info.Trim()
        Me.Timer2.Enabled = True
        Me.Timer2.Start()
        Me.UltraActivityIndicator1.Start()
        'Me.TopMost = True
    End Sub

    Private Sub frmActivity_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Timer2.Enabled = False
        Me.Timer2.Stop()
        Me.UltraActivityIndicator1.Stop()
    End Sub
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Me.closeSplash Then
            Me.Close()
        End If
        Me.Refresh()
        System.Windows.Forms.Application.DoEvents()
    End Sub
End Class