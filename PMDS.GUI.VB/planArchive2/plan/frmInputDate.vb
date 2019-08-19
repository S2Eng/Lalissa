


Imports System.Windows.Forms

Public Class frmInputDate

    Public gen As New General()
    Public abort As Boolean = True

    Public _TypUI As eTypUI
    Public Enum eTypUI
        SerientermineSaveChanged = 0
    End Enum






    Private Sub frmInputDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(TypUI As eTypUI)
        Try
            Me._TypUI = TypUI
            Me.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS")

            Me.AcceptButton = btnOk
            Me.CancelButton = btnAbrechen

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.btnOk.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.udteDateAt.DateTime = DateTime.Now

            If Me._TypUI = eTypUI.SerientermineSaveChanged Then
                Dim sTxtTranslated As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei dem Termin handelt es sich um einen Serientermin!") + vbNewLine +
                             QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen die Änderungen auf alle zukünftigen Termine des Serientermines übernommen werden?")
                Me.lblTxt.Text = sTxtTranslated
            Else
                Throw New Exception("initControl: Me._TypUI '" + Me._TypUI.ToString() + "' not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("frmInputDate.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.udteDateAt, "")

        Catch ex As Exception
            Throw New Exception("frmInputDate.clearErrorProvider: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function validateData() As Boolean
        Try
            Me.clearErrorProvider()

            If Me.udteDateAt.Value Is Nothing Then
                Dim txt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe erforderlich!")
                Me.ErrorProvider1.SetError(Me.udteDateAt, txt)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "PMDS", MessageBoxButtons.OK, True)
                Me.udteDateAt.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("frmInputDate.validateData: " + ex.ToString())
        Finally
        End Try
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If Me.validateData() Then
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnAbrechen_Click(sender As Object, e As EventArgs) Handles btnAbrechen.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.abort = True
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class