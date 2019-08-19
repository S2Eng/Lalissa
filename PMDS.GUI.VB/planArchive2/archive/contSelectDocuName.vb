Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared




Public Class contSelectDocuName

    Public _DocumentnameDefaultWithoutExtension As String = ""
    Public SelListNameDokumentenNamen As String = "DokumentenNamen"

    Public abort As Boolean = True
    Public mainWindow As frmSelectDocuName = Nothing

    Public gen As New General()
    Public doUI1 As New doUI()







    Private Sub contSelectDocuName_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ByRef DocumentnameDefault As String)
        Try
            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.mainWindow.AcceptButton = Me.btnOK
            Me.mainWindow.CancelButton = Me.btnAbort

            Me.btnAddNameToDocumentNameList.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.cboDocumentNames.ButtonsRight(0).Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            'info.ToolTipTitle = compAutoUI.getRes("ImportHistoricalMarketPrice")
            info.ToolTipText = doUI.getRes("AddDocuNameToSelList")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAddNameToDocumentNameList, info)

            Me.loadCboListDocuNames()

            Dim DocumentnameDefaultWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(DocumentnameDefault.Trim())
            If DocumentnameDefaultWithoutExtension.Trim() <> "" Then
                Me._DocumentnameDefaultWithoutExtension = DocumentnameDefaultWithoutExtension.Trim()
                Me.cboDocumentNames.Text = Me._DocumentnameDefaultWithoutExtension.Trim()
            End If

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadCboListDocuNames()
        Try
            Me.cboDocumentNames.Items.Clear()

            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.gen.loadSelList(Nothing, Me.cboDocumentNames, Me.SelListNameDokumentenNamen.Trim(), tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntryReturn)

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.loadCboListDocuNames: " + ex.ToString())
        End Try
    End Sub


    Public Function selectDocuName() As Boolean
        Try
            If Not Me.validateData() Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.selectDocuName: " + ex.ToString())
        End Try
    End Function

    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.cboDocumentNames, "")

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.clearErrorProvider: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function validateData() As Boolean
        Try
            Me.clearErrorProvider()
            If Me.cboDocumentNames.Text.Trim() = "" Then
                Dim txt As String = doUI.getRes("DocuNameInputRequired")
                Me.ErrorProvider1.SetError(Me.cboDocumentNames, txt)
                doUI.doMessageBox2("DocuNameInputRequired", "", "!")
                Me.cboDocumentNames.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.validateData: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function addNameToDocunameSelList() As Boolean
        Try
            If Not Me.validateData() Then
                Return False
            End If

            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Dim NameExistsInSelList As Boolean = False
            Dim MaxIDSelListEntry As Integer = -1
            Me.gen.loadSelList(Nothing, Nothing, Me.SelListNameDokumentenNamen.Trim(), tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntry)
            For Each rSelListDocuname As PMDS.db.Entities.tblSelListEntries In tSelListEntriesReturn
                If rSelListDocuname.Description.Trim().ToLower().Equals(Me.cboDocumentNames.Text.Trim().ToLower()) Then
                    NameExistsInSelList = True
                    Me.cboDocumentNames.Value = rSelListDocuname.Description
                    Me.cboDocumentNames.Text = rSelListDocuname.Description.Trim()
                    Return False
                End If
            Next

            If Not NameExistsInSelList Then
                Dim b As New PMDS.db.PMDSBusiness()
                Dim docuNameToAdd As String = Me.cboDocumentNames.Text.Trim()
                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim rSelListGroup As PMDS.db.Entities.tblSelListGroup = b.getSelListEntryGroup(Me.SelListNameDokumentenNamen.Trim(), db)

                    Dim rNewSelList As PMDS.db.Entities.tblSelListEntries = PMDS.Global.db.ERSystem.EFEntities.newtblSelListEntries(db)
                    'Dim rNewSelList As New PMDS.db.Entities.tblSelListEntries()
                    rNewSelList.IDGroup = rSelListGroup.ID
                    rNewSelList.IDRessource = docuNameToAdd.Trim()
                    rNewSelList.IDGuid = System.Guid.NewGuid()
                    rNewSelList.IDRessource = docuNameToAdd.Trim()
                    rNewSelList.ID = MaxIDSelListEntry + 1
                    db.tblSelListEntries.Add(rNewSelList)
                    db.SaveChanges()

                    Me.loadCboListDocuNames()
                    Me.cboDocumentNames.Value = docuNameToAdd.Trim()
                    Me.cboDocumentNames.Text = docuNameToAdd.Trim()

                    Return True
                End Using
            End If

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.addNameToDocunameSelList: " + ex.ToString())
        End Try
    End Function

    Public Sub editSelList()
        Try
            Me.clearErrorProvider()
            If Me.gen.OpenSelList(Me.SelListNameDokumentenNamen.Trim()) Then
                Me.loadCboListDocuNames()
            End If

        Catch ex As Exception
            Throw New Exception("contSelectDocuName.editSelList: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnAddNameToDocumentNameList_Click(sender As Object, e As EventArgs) Handles btnAddNameToDocumentNameList.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.addNameToDocunameSelList()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboStatus_EditorButtonClick(sender As Object, e As UltraWinEditors.EditorButtonEventArgs) Handles cboDocumentNames.EditorButtonClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If e.Button.Key = "EditSelList" Then
                Me.editSelList()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.selectDocuName() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.abort = True
            Me.mainWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
