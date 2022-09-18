Imports qs2.core.vb
Imports qs2.sitemap

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports qs2.Resources



Public Class frmSelListsChapter

    Public IDApplication As String = ""
    Public IDParticipant As String = ""

    Public showiSelect As Boolean = False





    Private Sub frmAuswahlistenObj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)

            Me.AcceptButton = Me.btnSave2
            Me.CancelButton = Me.btnClose2

            Me.loadRes()

            Me.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.btnSave2.initControl()
            Me.btnClose2.initControl()

            Me.btnClose2.Text = qs2.core.language.sqlLanguage.getRes("Close")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub loadData()
        Try
            Me.ContSelListsChapter1.frmMain = Me
            If Me.IDApplication.Trim() = "" Then
                Me.IDApplication = Me.ContSelListsChapter1.rGroupSelected.IDApplication.Trim()
            End If
            Me.ContSelListsChapter1.IDApplication = Me.IDApplication

            If Me.IDParticipant.Trim() = "" Then
                Me.IDParticipant = Me.ContSelListsChapter1.rGroupSelected.IDParticipant.Trim()
            End If
            Me.ContSelListsChapter1.IDParticipant = Me.IDParticipant
            Me.setTitle()

            Me.ContSelListsChapter1.initControl(qs2.core.language.sqlLanguage.getRes(qs2.core.vb.sqlAdmin.groupNameCriterias), Me.showiSelect)

            Me.Icon = getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)

            Me.ContSelListsChapter1.lockUnlock(True)
            Me.lockUnlock(False)

            Dim dOnValueChanged As New qs2.sitemap.vb.contSelListsChapter.onValueChanged(AddressOf Me.onValueChanged)
            Me.ContSelListsChapter1.delonValueChanged = dOnValueChanged

            Me.ContSelListsChapter1.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub
    Public Sub setTitle()
        Try
            Dim sqlAdminCheck As New sqlAdmin()
            sqlAdminCheck.initControl()
            Me.Text = QS2.core.language.sqlLanguage.getRes("Assign") + ": " + QS2.core.language.sqlLanguage.getRes(Me.ContSelListsChapter1.rSelEntry.IDRessource) + "         (" + QS2.core.language.sqlLanguage.getRes("Participant") + ": " + Me.IDParticipant + ", " + QS2.core.language.sqlLanguage.getRes("Application") + ": " + Me.IDApplication + ")"
            QS2.core.language.sqlLanguage.getRes("Participant")

        Catch ex As Exception
            Throw New Exception("setTitle: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function save() As Boolean
        Try
            Me.ContSelListsChapter1.save()
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Function

    Private Sub onValueChanged()
        Me.lockUnlock(True)
    End Sub
    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.btnSave2.Enabled = bEdit

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnClose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose2.Click
        Me.Close()
    End Sub
    Private Sub btnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.save() Then
                Me.ContSelListsChapter1.loadData()
                'Me.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub frmSelListsChapter_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class