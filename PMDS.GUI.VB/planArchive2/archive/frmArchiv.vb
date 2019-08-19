Imports System.Windows.Forms
Imports System.Drawing



Public Class frmArchiv

    Public gen As New General()
    Public isLoaded As Boolean = False
    Public IsInitializedVisible As Boolean = False





    Private Sub frmArchiv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub initForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.Text = doUI.getRes("Documents")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.ContArchivMain1.startTyp = contArchMain.eStart.gesamtsystem
            Me.ContArchivMain1.patient = ""
            Me.ContArchivMain1.ContArchivSuch1.tArchObjects = New dbArchiv.archObjectDataTable()
            Me.ContArchivMain1.loadArchiv(contArchMain.eStart.gesamtsystem)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmArchiv.initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadBenutzerarchiv()
        Try
            Me.initForm()

        Catch ex As Exception
            Throw New Exception("frmArchiv.loadBenutzerarchiv: " + ex.ToString())
        End Try
    End Sub

    Public Sub resizeForm()
        Try
            Application.DoEvents()

        Catch ex As Exception
            Throw New Exception("frmArchiv.resizeForm: " + ex.ToString())
        End Try
    End Sub

    Private Sub frmArchiv_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Dim newRessourcesAdded As Integer = 0
                'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
                Me.IsInitializedVisible = True
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class