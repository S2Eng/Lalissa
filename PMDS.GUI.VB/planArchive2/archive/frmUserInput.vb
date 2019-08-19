

Public Class frmUserInput

    Public abort As Boolean = True
    Private genMain As New General
    Public doUI1 As New doUI()

    Public Enum eTypeUI
        NormalTextinput = 0
        SelectNameFromComboBox = 1
    End Enum

    Public SelListNameDokumentenNamen As String = "DokumentenNamen"







    Private Sub frmUserInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = doUI.getRes("ImportDocuments")

            Me.CancelButton = Me.btnAbort
            Me.AcceptButton = Me.btnOK

            Me.doRes()

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.loadCboListDocuNames()

        Catch ex As Exception
            genMain.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub setUI(TypeUI As eTypeUI)
        Try
            If TypeUI = eTypeUI.NormalTextinput Then
                Me.cboDocumentNames.Visible = False
                Me.txtName.Visible = True

            ElseIf TypeUI = eTypeUI.SelectNameFromComboBox Then
                Me.cboDocumentNames.Visible = True
                Me.txtName.Visible = False

            End If

        Catch ex As Exception
            Throw New Exception("frmUserInput.setUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub doRes()
        Try
            Me.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            'Me.Icon = ITSCont.core.SystemDb.getRes.getIcon(core.SystemDb.getRes.ePicture.ico_User)
            Me.cboDocumentNames.ButtonsRight(0).Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)

        Catch ex As Exception
            Throw New Exception("frmUserInput.doRes: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadCboListDocuNames()
        Try
            Me.cboDocumentNames.Items.Clear()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.genMain.loadSelList(Nothing, Me.cboDocumentNames, Me.SelListNameDokumentenNamen.Trim(), tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntryReturn)

        Catch ex As Exception
            Throw New Exception("frmUserInput.loadCboListDocuNames: " + ex.ToString())
        End Try
    End Sub

    Public Sub editSelList()
        Try
            If Me.genMain.OpenSelList(Me.SelListNameDokumentenNamen.Trim()) Then
                Me.loadCboListDocuNames()
            End If

        Catch ex As Exception
            Throw New Exception("frmUserInput.editSelList: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Me.abort = False
            Me.Close()

        Catch ex As Exception
            Me.genMain.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        Try
            Me.Close()

        Catch ex As Exception
            Me.genMain.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub cboDocumentNames_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cboDocumentNames.EditorButtonClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If e.Button.Key = "EditSelList" Then
                Me.editSelList()
            End If

        Catch ex As Exception
            Me.genMain.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class