Imports qs2.core.vb
Imports Infragistics.Win



Public Class contAddSelList

    Public IDApplication As String = ""
    Public IDParticipant As String = ""
    Public IDGroupStr As String = ""
    Public _UserEntry As Boolean = False

    Public typUI As New eTypUI()
    Public Enum eTypUI
        newQueryUser = 0
        newQueryGroup = 1
    End Enum

    Public mainWindow As frmAddSelList = Nothing
    Public abort As Boolean = True
    Public bCopy As Boolean = False

    Public isNew As Boolean = True
    Public IDSelListToEdit As Integer = -999

    Public rSelListActuell As dsAdmin.tblSelListEntriesRow = Nothing
    Public rGroup As dsAdmin.tblSelListGroupRow = Nothing


    Public funct1 As New qs2.core.vb.funct()

    Public isLoaded As Boolean = False
    Public dsAdminObjFound As New dsAdmin()






    Private Sub contAddSelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            If Not Me.mainWindow Is Nothing Then
                Me.mainWindow.AcceptButton = Me.btnSave
                Me.mainWindow.CancelButton = Me.btnCancel
            End If

            Me.btnSave.initControl()
            Me.btnCancel.initControl()
            Me.btnAssignToMe.initControl()

            Me.SqlAdmin1.initControl()

            'Me.sqlAdmin1.initControl()
            Me.loadRes()

            If Not Me.mainWindow Is Nothing Then
                Me.ContAddQueryType1.MainWindow = Me
            End If

            Me.ContAddQueryType1.Application = Me.IDApplication
            Me.ContAddQueryType1.Participant = Me.IDParticipant
            Me.ContAddQueryType1.initControl()
            Me.ContAddQueryType1.initDefaultTables()

            Me.ContCboSelList1.IDParticipant = Me.IDParticipant
            Me.ContCboSelList1.IDApplication = Me.IDApplication
            Me.btnCopyQuery.Visible = Not Me.isNew

            If Me.typUI = eTypUI.newQueryUser Then
                Me.ContCboSelList1.IDGroupStr = "QueryGroups"
                Me.ContCboSelList1.initControl(True, False, Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDown)
                Me.ContCboSelList1.loadData()

            ElseIf Me.typUI = eTypUI.newQueryGroup Then
                Me.ContCboSelList1.Visible = False
                Me.lblQueryGroup.Visible = False
                Me.chkPrivate.Visible = False
                Me.chkIsSubquery.Visible = False
                If Not Me.mainWindow Is Nothing Then
                    Me.mainWindow.Height = 120
                End If

            End If

            Me.clearUI()

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel")

            Me.chkPrivate.Text = qs2.core.language.sqlLanguage.getRes("Private")
            Me.lblQueryGroup.Text = qs2.core.language.sqlLanguage.getRes("Group")
            Me.chkIsSubquery.Text = qs2.core.language.sqlLanguage.getRes("Subquery")
            Me.chkPublished.Text = qs2.core.language.sqlLanguage.getRes("Published")
            Me.btnAssignToMe.Text = qs2.core.language.sqlLanguage.getRes("AssignToMe")
            Me.btnTakeOwnershipQuery.Text = qs2.core.language.sqlLanguage.getRes("TakeOwnershipQuery")
            Me.chkForServices.Text = qs2.core.language.sqlLanguage.getRes("ForServices")
            Me.btnCopyQuery.Text = qs2.core.language.sqlLanguage.getRes("Copy")

            'Me.btnOK.Appearance.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_OK, 32, 32 )

            If Me.typUI = eTypUI.newQueryUser Then
                Me.lblDescription.Text = qs2.core.language.sqlLanguage.getRes("NameQuery")
                'Me.lblDescription.Text = qs2.core.language.sqlLanguage.getRes("NameQuery")

            ElseIf Me.typUI = eTypUI.newQueryGroup Then
                Me.lblDescription.Text = qs2.core.language.sqlLanguage.getRes("NameGroup")

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub clearUI()
        Try
            Me.txtDescription.Text = ""
            Me.chkPrivate.Checked = False
            Me.chkIsSubquery.Checked = False
            Me.ContCboSelList1.cboSelList.Value = Nothing

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub onChangeQueryType(TableNameToLoad As String, QueryTypeToLoad As qs2.core.print.print.eQueryType)
        Try



        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadGroup()
        Try
            Me.rGroup = Me.SqlAdmin1.getSelListGroupRow(Me.IDGroupStr, Me.IDParticipant, Me.IDApplication)
            If Me.rGroup Is Nothing Then
                Throw New Exception("initControl: IDGroup '" + Me.IDGroupStr + "' not found!")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadData()
        Try
            Me.DsAdmin1.Clear()
            Me.loadGroup()
            Me.btnAssignToMe.Visible = False
            Me.btnTakeOwnershipQuery.Visible = False

            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.SqlAdmin1.getSelListEntrys(Parameters, Me.IDGroupStr, Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, sqlAdmin.eTypAuswahlList.id, "", -999, "", -999)
            If Me.isNew Then
                Me.rSelListActuell = Me.SqlAdmin1.getNewRowSelList(Me.DsAdmin1, True)

                'Dim IDSelListNextCalculated As Integer = -999

                'Dim NextIDOwnInt As Integer = Me.SqlAdmin1.getMaxSelListID(qs2.core.vb.sqlAdmin.eTypSelListGetMaxID.GetMaxIDGeneric, Me.rGroup.ID)
                'Dim sNextIDOwnInt As String = ""
                'If NextIDOwnInt < 10 Then
                '    sNextIDOwnInt = "0000" + NextIDOwnInt.ToString()
                'Else
                '    sNextIDOwnInt = NextIDOwnInt.ToString()
                'End If

                'Dim NextIDOwnIntWithoutGrp As Integer = sNextIDOwnInt.Substring(4, sNextIDOwnInt.Length - 4)
                'Me.rSelListActuell.IDOwnInt = NextIDOwnIntWithoutGrp

                Dim IDOwnStrNext As String = ""
                Dim IDSelListNextCalculated As Integer = -999
                Dim NextIDOwnInt As Integer = Me.SqlAdmin1.getNextIDOwnIntSelList(Me.rGroup.ID)
                Me.SqlAdmin1.getNextIDSelListGeneric(IDSelListNextCalculated, IDOwnStrNext, NextIDOwnInt, Me.rGroup.ID)
                'Dim sIDSelListNextCalculated As String = IDSelListNextCalculated.ToString()
                'If IDSelListNextCalculated < 0 Then
                '    Throw New Exception("contAddSelList.loadData: IDSelListNextCalculated < 0 !")
                'End If
                'If sIDSelListNextCalculated.Length <> Me.rGroup.ID.ToString().Length() + lenID Then
                '    Throw New Exception("contAddSelList.loadData:  Me.rSelListActuell.ID.Length <> " + lenID.ToString() + "!")
                'End If
                Me.rSelListActuell.ID = IDSelListNextCalculated
                Me.rSelListActuell.IDOwnInt = NextIDOwnInt
                Me.rSelListActuell.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()

                If Me.typUI = eTypUI.newQueryUser Then
                    Me.rSelListActuell.TypeStr = core.Enums.eTypeQuery.User.ToString()
                    Me.rSelListActuell._Private = False
                End If
                Me.rSelListActuell.TypeQry = qs2.core.print.print.eQueryType.SimpleView.ToString()
                Me.rSelListActuell.CreatedUser = qs2.core.vb.actUsr.rUsr.UserName
                Me.rSelListActuell.IDGroup = Me.rGroup.ID
                'frmSelListAdd.ContSelList1.doAutoRessource = true;
            Else
                Me.SqlAdmin1.getSelListEntrys(Parameters, Me.IDGroupStr, Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, sqlAdmin.eTypAuswahlList.id, "", -999, "", Me.IDSelListToEdit)
                If Me.DsAdmin1.tblSelListEntries.Rows.Count <> 1 Then
                    Throw New Exception("contAddSelList.loadData: Me.DsAdmin1.tblSelListEntries.Rows.Count <> 1!")
                End If

                Me.rSelListActuell = Me.DsAdmin1.tblSelListEntries.Rows(0)
                If Me.rSelListActuell.IDParticipant.Trim() = "" Then
                    Me.btnAssignToMe.Visible = True
                End If

                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin Then
                    Me.btnTakeOwnershipQuery.Visible = True
                End If
            End If

            Me.chkPrivate.Checked = rSelListActuell._Private
            Me.chkIsSubquery.Checked = rSelListActuell.SubQuery
            Me.chkPublished.Checked = rSelListActuell.Published
            Me.chkForServices.Checked = rSelListActuell.ForServices

            If Not Me.isNew Then
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(Me.rSelListActuell.IDRessource, rGroup.IDParticipant, rGroup.IDApplication, False)
                If resFound.Trim() = "" Then
                    Me.txtDescription.Text = rSelListActuell.IDRessource
                Else
                    Me.txtDescription.Text = resFound
                End If
                Me.loadAssignedGroupForQuery()
            End If

            Me.ContAddQueryType1.loadData(Me.rSelListActuell.TypeQry.Trim(), Me.rSelListActuell._Table.Trim(), Me.isNew)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Public Sub loadAssignedGroupForQuery()
        Try
            Me.dsAdminObjFound.Clear()
            Me.SqlAdmin1.getSelListEntrysObj(Me.IDSelListToEdit, sqlAdmin.eDbTypAuswObj.SubSelList, Me.IDGroupStr, Me.dsAdminObjFound, sqlAdmin.eTypAuswahlObj.IDSelListEntry, "")
            If Me.dsAdminObjFound.tblSelListEntriesObj.Rows.Count > 0 Then
                Dim rFirstObjFound As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.dsAdminObjFound.tblSelListEntriesObj.Rows(0)
                Me.ContCboSelList1.cboSelList.Value = rFirstObjFound.IDSelListEntrySublist
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub clearErrorProvider()

        Me.ErrorProvider1.SetError(Me.txtDescription, "")
        Me.ErrorProvider1.SetError(Me.ContCboSelList1.cboSelList, "")
        Me.ErrorProvider1.SetError(Me.chkPrivate, "")
        Me.ErrorProvider1.SetError(Me.chkIsSubquery, "")

    End Sub
    Public Function validate() As Boolean
        Try
            Me.clearErrorProvider()

            Dim errTxt As String = qs2.core.language.sqlLanguage.getRes("ErrorInput") + "!"
            If Me.txtDescription.Text.Trim() = "" Then
                Me.txtDescription.Focus()
                Me.ErrorProvider1.SetError(Me.txtDescription, errTxt)
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("InputRequired") + "!"
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            If qs2.core.vb.funct.ContainsSpecialChars(Me.txtDescription.Text.Trim()) Then
                Me.txtDescription.Focus()
                Me.ErrorProvider1.SetError(Me.txtDescription, errTxt)
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("TextFieldCanNotContainSpecialCharacters") + "!"
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            If Me.typUI = eTypUI.newQueryUser Then
                If Not Me.funct1.checkComboBoxGrid(Me.ContCboSelList1.cboSelList, False, Me.ContCboSelList1.DsAdmin1.tblSelListEntries, Me.ContCboSelList1.DsAdmin1.tblSelListEntries.IDColumn.ColumnName, True) Then
                    Me.ContCboSelList1.cboSelList.Focus()
                    Me.ErrorProvider1.SetError(Me.ContCboSelList1.cboSelList, errTxt)
                    Return False

                End If
            End If
            Dim b As New qs2.core.db.ERSystem.businessFramework()
            Dim IDSelListAct = -999
            If Not Me.isNew Then
                IDSelListAct = Me.rSelListActuell.ID
            End If

            '    If b.CheckIfSelListIDResExists(Me.txtDescription.Text.Trim(), IDSelListAct) Then
            '        IDResSelListExists = True
            '        'Me.txtDescription.Focus()
            '        'Me.ErrorProvider1.SetError(Me.txtDescription, errTxt)
            '        'Dim txt As String = qs2.core.language.sqlLanguage.getRes("NameAlreadyExists") + "!"
            '        'qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
            '        'Return False
            '    End If

            Return True

        Catch ex As Exception
            Throw New Exception("validate: " + ex.ToString())
        End Try
    End Function
    Public Function save() As Boolean
        Try
            If Not Me.validate() Then
                Return False
            End If
            If Not Me.ContAddQueryType1.validateData() Then
                Return False
            End If

            Me.rSelListActuell.IDRessource = Me.txtDescription.Text.Trim() + "_" + Me.rSelListActuell.IDGuid.ToString()
            'If IDResSelListExists Then
            '    Me.rSelListActuell.IDRessource = Me.txtDescription.Text.Trim() + "_" + Me.rSelListActuell.IDGuid.ToString()
            'Else
            '    Me.rSelListActuell.IDRessource = Me.txtDescription.Text.Trim()
            'End If

            Me.rSelListActuell._Private = Me.chkPrivate.Checked
            Me.rSelListActuell.SubQuery = Me.chkIsSubquery.Checked
            Me.rSelListActuell.Published = Me.chkPublished.Checked
            Me.rSelListActuell.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
            Me.rSelListActuell.ForServices = Me.chkForServices.Checked

            Me.rSelListActuell.TypeQry = Me.ContAddQueryType1.getSelectedQueryType().Trim()
            If Me._UserEntry Then
                Me.rSelListActuell.TypeStr = "User"
            End If

            Dim rActSimpTable As qs2.core.print.dsSimpleQuerySelection.SimpleTablesRow = Me.ContAddQueryType1.getSelectedSelList()
            If Not rActSimpTable Is Nothing Then
                Me.rSelListActuell._Table = rActSimpTable.TableName.Trim()
                Me.rSelListActuell.Classification = rActSimpTable.Classification.Trim()
            End If

            Dim b As New qs2.core.db.ERSystem.businessFramework()
            If Not b.CheckIfSelListIDResExists(Me.txtDescription.Text.Trim() + "_" + Me.rSelListActuell.IDGuid.ToString()) Then
                Dim b2 As New qs2.core.vb.businessFramework()
                Dim rRes As qs2.core.language.dsLanguage.RessourcenRow
                b2.addNewResAuto(Me.rSelListActuell.IDRessource.Trim(), core.Enums.eResourceType.Label, Me.txtDescription.Text.Trim(), Me.txtDescription.Text.Trim(), "User", rRes)
            End If

            Me.SqlAdmin1.daSelListEntrys.Update(Me.DsAdmin1.tblSelListEntries)

            If Me.typUI = eTypUI.newQueryUser Then
                Me.deleteAllSelListToObj()
                Dim rSelSelListSub As dsAdmin.tblSelListEntriesRow = Me.ContCboSelList1.getSelectedSelList(False)
                If Not rSelSelListSub Is Nothing Then
                    If Me.saveSelListToObj(Me.rSelListActuell.ID, rSelSelListSub.ID) Then
                        Return True
                    End If
                Else
                    Return True
                    'Throw New Exception("contAddSelList.save: rSelSelListSub is null!")
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Sub copy()
        Try
            Dim b As New businessFramework()

            Dim dsLanguageUpdate As New qs2.core.language.dsLanguage()
            Dim sqlLanguageUpdate As New qs2.core.language.sqlLanguage()
            sqlLanguageUpdate.initControl()

            Dim dsAdminTmp As New dsAdmin()
            Dim sqlAdminTmp As New sqlAdmin()
            sqlAdminTmp.initControl()

            Dim dsAdminUpdate As New dsAdmin()
            Dim sqlAdminUpdate As New sqlAdmin()
            sqlAdminUpdate.initControl()

            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                sqlAdminTmp.getSelListEntrys(New sqlAdmin.ParametersSelListEntries(), 0, "", "", dsAdminTmp, sqlAdmin.eTypAuswahlList.id, "", 0, "", Me.rSelListActuell.ID)
                Dim rSelListToCopy As dsAdmin.tblSelListEntriesRow = dsAdminTmp.tblSelListEntries.Rows(0)
                sqlAdminUpdate.getSelListEntrys(New sqlAdmin.ParametersSelListEntries(), 0, "", "", dsAdminUpdate, sqlAdmin.eTypAuswahlList.id, "", 0, "", -999999)
                Dim rSelListNew As dsAdmin.tblSelListEntriesRow = sqlAdminUpdate.getNewRowSelList(dsAdminUpdate, True)
                rSelListNew.ItemArray = rSelListToCopy.ItemArray

                'bestehende vollständige Funktion (Berücksichtigung AdminSecure) verwenden
                Dim IDOwnStrNext As String = ""
                Dim IDSelListNextCalculated As Integer = -999
                Dim NextIDOwnInt As Integer = Me.SqlAdmin1.getNextIDOwnIntSelList(Me.rGroup.ID)
                Me.SqlAdmin1.getNextIDSelListGeneric(IDSelListNextCalculated, IDOwnStrNext, NextIDOwnInt, Me.rGroup.ID)
                rSelListNew.ID = IDSelListNextCalculated
                rSelListNew.IDOwnInt = NextIDOwnInt

                'Hannes vom 19.11.2020 - fehlerhaft bei AdminSecure und bestehender User-Query (Ergbnis wäre neunstellig statt achtstellig)
                'rSelListNew.ID = b.getNextIDSelList(db, Me.rSelListActuell.IDGroup)
                'Dim sID As String = rSelListNew.ID.ToString()
                'sID = sID.Substring(4, sID.Length - 4)
                'rSelListNew.IDOwnInt = sID

                Dim InsertFromClipboard1 As New InsertFromClipboard()
                Dim rLanguage As qs2.core.language.dsLanguage.RessourcenRow = Nothing
                InsertFromClipboard1.CopyRessource(rSelListNew.IDRessource, qs2.core.license.doLicense.rApplication.IDApplication, rLanguage, True, qs2.core.license.doLicense.rParticipant.IDParticipant)
                If rLanguage Is Nothing Then
                    InsertFromClipboard1.CopyRessource(rSelListNew.IDRessource, qs2.core.license.doLicense.rApplication.IDApplication, rLanguage, True)
                End If
                If Not rLanguage Is Nothing Then
                    sqlLanguageUpdate.getLanguage(System.Guid.NewGuid.ToString(), dsLanguageUpdate, core.language.sqlLanguage.eTypSelLang.IDRes, core.Enums.eResourceType.Label, "", "")
                    Dim rRessourceNew As qs2.core.language.dsLanguage.RessourcenRow = sqlLanguageUpdate.newRowLanguage(dsLanguageUpdate, "", "", "", "", "", core.Enums.eResourceType.Label, core.Enums.eTypeSub.None, "")
                    rRessourceNew.ItemArray = rLanguage.ItemArray
                    rRessourceNew.IDRes = rRessourceNew.IDRes + "_" + System.Guid.NewGuid.ToString()
                    rRessourceNew.English += " " + DateTime.Now.ToString("yyyyMMddHHmmss").ToString()
                    rRessourceNew.German += " " + DateTime.Now.ToString("yyyyMMddHHmmss").ToString()
                    rRessourceNew.IDGuid = System.Guid.NewGuid()
                    rRessourceNew.LastChange = Now
                    sqlLanguageUpdate.daLanguage.Update(dsLanguageUpdate.Ressourcen)
                    rSelListNew.IDRessource = rRessourceNew.IDRes
                Else
                    rSelListNew.IDRessource += qs2.core.language.sqlLanguage.getRes("Query") + " " + DateTime.Now.ToString("yyyyMMddHHmmss").ToString()
                End If

                rSelListNew.IDGuid = System.Guid.NewGuid()
                sqlAdminUpdate.daSelListEntrys.Update(dsAdminUpdate.tblSelListEntries)

                sqlAdminTmp.getQueriesDef(rSelListActuell.ID, dsAdminTmp, sqlAdmin.eTypSelQueryDef.IDSelList, core.Enums.eTypQueryDef.InputParameters, "", "")
                sqlAdminUpdate.getQueriesDef(-9999, dsAdminUpdate, sqlAdmin.eTypSelQueryDef.IDSelList, core.Enums.eTypQueryDef.InputParameters, "", "")
                For Each rQryDef As dsAdmin.tblQueriesDefRow In dsAdminTmp.tblQueriesDef
                    'dsAdminUpdate.tblQueriesDef.Clear()
                    Dim rNewQryDef As dsAdmin.tblQueriesDefRow = sqlAdminUpdate.addRowQueriesDef(dsAdminUpdate.tblQueriesDef)
                    rNewQryDef.ItemArray = rQryDef.ItemArray
                    rNewQryDef.IDGuid = System.Guid.NewGuid()
                    rNewQryDef.IDSelList = rSelListNew.ID
                Next
                sqlAdminUpdate.daQueriesDef.Update(dsAdminUpdate.tblQueriesDef)

                Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
                sqlLanguage1.loadAllRessources()

                Me.rSelListActuell = rSelListNew
                Me.bCopy = True
                Me.mainWindow.Close()
            End With

        Catch ex As Exception
            Throw New Exception("contAddSelList.copy: " + ex.ToString())
        End Try
    End Sub

    Public Function saveSelListToObj(ByVal IDSelListEntry As Integer, ByVal IDSelListEntrySublist As Integer) As Boolean
        Try
            Me.DsAdmin1.tblSelListEntriesObj.Rows.Clear()
            Me.SqlAdmin1.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.SubSelList, "", Me.DsAdmin1, sqlAdmin.eTypAuswahlObj.sellist, "")

            Dim rNewObj As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.SqlAdmin1.getNewRowSelListObj(Me.DsAdmin1)
            rNewObj.IDSelListEntry = IDSelListEntry
            rNewObj.IDSelListEntrySublist = IDSelListEntrySublist
            rNewObj.typIDGroup = Me.IDGroupStr

            Me.SqlAdmin1.daSelListEntrysObj.Update(Me.DsAdmin1.tblSelListEntriesObj)
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Sub deleteAllSelListToObj()
        Try
            For Each rObjAssignedFound As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow In Me.dsAdminObjFound.tblSelListEntriesObj
                Me.SqlAdmin1.deleteSelListEntryObj(rObjAssignedFound.IDGuid)
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.save() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAssignToMe_Click(sender As Object, e As EventArgs) Handles btnAssignToMe.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.rSelListActuell.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnTakeOwnershipQuery_Click(sender As Object, e As EventArgs) Handles btnTakeOwnershipQuery.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.rSelListActuell.CreatedUser = qs2.core.vb.actUsr.rUsr.UserName

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnCopyQuery_Click(sender As Object, e As EventArgs) Handles btnCopyQuery.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.copy()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
