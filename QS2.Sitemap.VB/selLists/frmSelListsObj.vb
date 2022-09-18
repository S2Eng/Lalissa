Imports qs2.core.vb
Imports qs2.sitemap

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports qs2.Resources




Public Class frmSelListsObj

    Public savedClicked As Boolean = False
    Public _IDRessourceForSave As String = ""






    Private Sub frmAuswahlistenObj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Public Sub loadData(ByVal lstClassification As System.Collections.ArrayList, ByVal AutoFitStyle As Infragistics.Win.UltraWinGrid.AutoFitStyle, _
                         typUI As qs2.sitemap.vb.contSelListsObj.eTypUI, showComboApplications As Boolean, _
                         IDApplication As String, IDParticipant As String, Sublist As String, IDRessourceForSave As String)
        Try
            Me.ContSelListsObj1.mainWindow = Me
            Me._IDRessourceForSave = IDRessourceForSave

            Me.AcceptButton = Me.btnSave2
            Me.CancelButton = Me.btnClose2

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)
            Me.loadRes()

            If Me.ContSelListsObj1.typ = contSelListsObj.eTyp.savedForObject Then
                Me.ContSelListsObj1.initControl(Infragistics.Win.DefaultableBoolean.False, "", True, True, _
                                                lstClassification, AutoFitStyle, typUI, showComboApplications, _
                                                IDApplication, IDParticipant)

            ElseIf Me.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList Then
                Me.ContSelListsObj1.initControl(Infragistics.Win.DefaultableBoolean.True, Sublist, True, True, _
                                                lstClassification, AutoFitStyle, typUI, showComboApplications, _
                                                IDApplication, IDParticipant)

                Dim sqlAdminCheck As New sqlAdmin()
                sqlAdminCheck.initControl()
                'Dim rGroup As dsAdmin.tblSelListGroupRow = sqlAdminCheck.getSelListGroupRow_ParticAppl(Me.ContAuswahllistenObj1.grpToLoad, qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication)

            End If

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)

            System.Windows.Forms.Application.DoEvents()

            Me.ContSelListsObj1.lockUnlock(True)
            Me.lockUnlock(False)

            Dim dOnValueChanged As New qs2.sitemap.vb.contSelListsObj.onValueChanged(AddressOf Me.onValueChanged)
            Me.ContSelListsObj1.delonValueChanged = dOnValueChanged

            Me.setTitle(IDApplication, IDParticipant, IDRessourceForSave)
            Dim dsAdminSub As New dsAdmin()
            Me.ContSelListsObj1.loadData(Me.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay, dsAdminSub,
                                         Me.ContSelListsObj1._IDParticipantStay, Me.ContSelListsObj1._IDApplicationStay,
                                         Me.ContSelListsObj1._IDSelListEntry, Me.ContSelListsObj1._IDSelListEntrySublist, False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
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

    Public Function save() As Boolean
        Try
            Me.ContSelListsObj1.save(Me.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay)
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
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
        Try
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.save() Then
                Me.savedClicked = True
                Me.btnSave2.Enabled = False
                'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DataSaved") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Me.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Public Sub setTitle(IDApplication As String, IDParticipant As String, IDRessourceForSave As String)
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("Assign") + ": " + qs2.core.language.sqlLanguage.getRes(IDRessourceForSave) + "         (" + qs2.core.language.sqlLanguage.getRes("Application") + ": " + IDApplication + ", " + qs2.core.language.sqlLanguage.getRes("Participant") + ": " + IDParticipant + ")"

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Private Sub frmSelListsObj_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class