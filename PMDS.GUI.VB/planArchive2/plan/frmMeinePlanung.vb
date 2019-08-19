

Public Class frmMeinePlanung

    Public gen As New General()
    Public isLoaded As Boolean = False




    Private Sub frmMeinePlanung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub initForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.Text = doUI.getRes(" ")
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.ContPlanungMain1._isGesamt = True
            Me.ContPlanungMain1.initForm()

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmMeinePlanung.initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadBenutzerarchiv()
        Try
            Me.initForm()

        Catch ex As Exception
            Throw New Exception("frmMeinePlanung.loadBenutzerarchiv: " + ex.ToString())
        End Try
    End Sub

    Public Sub resizeForm()
        Try

        Catch ex As Exception
            Throw New Exception("frmMeinePlanung.resizeForm: " + ex.ToString())
        End Try
    End Sub

End Class