Public Class sqlAdmin

    Public database As New qs2.core.dbBase

    Public sel_daSelListGroup As String = ""
    Public sel_daSelListEntrys As String = ""
    Public sel_daSelListEntrysSort As String = ""
    Public sel_daSelListEntrysObj As String = ""
    Public sel_daSelListEntrysRelGroup As String = ""
    Public sel_daSelCriteria As String = ""
    Public sel_daSelCriteriaOpt As String = ""
    Public sel_daSelRelationship As String = ""
    Public sel_daSelQueriesDef As String = ""
    Public sel_daSelQueryJoinsTemp As String = ""
    Public sel_daMaxSelListGroupID As String = ""
    Public sel_GetButtonsForUser As String = ""

    Public Shared dsAllAdmin As dsAdmin = New dsAdmin()
    Public Shared typIDGroup_CompletedChapters As String = "CompletedChapter"
    Public Shared typIDGroup_ProceduresToStay As String = "ProceduresToStay"
    Public Shared groupNameCriterias As String = "CRITERIAS"

    Public Enum eTypStayAdditions
        multiSelLists = 48200
        assignStay = 48201
        multiSelListsRoles = 48202
    End Enum

    Public Class ParametersSelListEntries
        Public rGrpFound As dsAdmin.tblSelListGroupRow = Nothing
        Public doExecptIfNotFound As Boolean = True
        Public GroupNotFoundInAnyApplication As Boolean = False
    End Class

    Public Enum eTypSelGruppen
        all = 49000
        IDGruppeStr = 49001
        IDGruppeRam = 49002
        IDGruppe = 49003
        SelListUsr = 49004
        IDGruppeNoAppPart = 49005
        IDRam = 49006
        ProductAndAll = 49007
        IDGruppeStrNoAppPart = 49008
    End Enum

    Public Enum eTypAuswahlList
        IDGroup = 50000
        group = 50001
        IDOwnInt = 50002
        IDOwnStr = 50003
        id = 50005
        all = 50006
        IDGroupRam = 50007
        groupTypEnum = 50008
        column = 50009
        groupTypEnumUserName = 50010
        groupTypStr = 50011
        IDGroupStrAppRam = 50012
        IDRam = 50013
        IDOwnStrIDGroup = 50023
        IDGroupParticipantAndAll = 50025
        groupParticipantOwnOrAll = 50026
        IDParticipantUserSelList = 50027
    End Enum

    Public Enum eTypSelListSort
        All = 0
        IDSelListIDParticipantIDRam = 1
    End Enum

    Public Enum eTypSelListGetMaxID
        GetMaxIDGeneric = 52300
    End Enum

    Public Enum eTypAuswahlObj
        obj = 51000
        objRAM = 51013
        sellist = 51001
        allCriterias = 51002
        IDSelListEntry = 51003
        IDSelListEntryIDStayTypIDGroup = 51004
        IDSelListEntrySubListIDStayTypIDGroup = 51005
        IDSelListEntrySublist = 51006
        allFldShortRam = 51007
        AllSelListObjects = 51008
        IDStayTypIDGroup = 51009
        IDGuid = 51010
        IDSelListEntryFldShort = 51012
        RAMRightUser = 51016
        IDSelListEntryIDObject = 51017
        IDStay = 51018
        objOnly = 51019
        FldShortOtherChapters = 51020
    End Enum

    Public Enum eDbTypAuswObj
        SubSelList = 51051
        Criterias = 51052
        ProceduresToStay = 51053
        Roles = 51054
        UserQueries = 51057
        UserDocuments = 51059
    End Enum

    Public Enum eTypSelListID
        guid = 51100
        IDOwnInt = 51101
        IDOwnStr = 51102
        Description = 51103
    End Enum

    Public Enum eTypSelCriteria
        search = 51200
        id = 51201
        idRam = 51202
        application = 51203
    End Enum
    Public Enum eTypSelCriteriaOpt
        all = 51300
        id = 51301
        idRam = 51302
    End Enum
    Public Enum eTypSelRelationship
        all = 51400
        id = 51401
        idRam = 51402
        idRamAllChild = 51403
        IDRamAllGroup = 51404
    End Enum

    Public Enum eTypSelQueryDef
        typ = 51600
        IDSelList = 51601
    End Enum

    Public Enum eTypSelQueryJoinsTemp
        all = 51700
    End Enum

    Public Shared IDClassificationChapterAlwaysEditable As String = "Type=EditableWhenCompleted;"

    Public Sub initControl()
        Me.sel_daSelListGroup = Me.daSelListGroup.SelectCommand.CommandText
        Me.sel_daSelListEntrys = Me.daSelListEntrys.SelectCommand.CommandText
        Me.sel_daSelListEntrysSort = Me.daSelListEntriesSort.SelectCommand.CommandText
        Me.sel_daSelListEntrysRelGroup = Me.davListEntriesWithGroup.SelectCommand.CommandText
        Me.sel_daSelListEntrysObj = Me.daSelListEntrysObj.SelectCommand.CommandText
        Me.sel_daSelCriteria = Me.daCriteria.SelectCommand.CommandText
        Me.sel_daSelCriteriaOpt = Me.daCriteriaOpt.SelectCommand.CommandText
        Me.sel_daSelRelationship = Me.daRelationship.SelectCommand.CommandText
        Me.sel_daSelQueriesDef = Me.daQueriesDef.SelectCommand.CommandText
        Me.sel_daSelQueryJoinsTemp = Me.daQueryJoinsTemp.SelectCommand.CommandText
        Me.sel_daMaxSelListGroupID = Me.daMaxSelListGroupID.SelectCommand.CommandText
        Me.sel_GetButtonsForUser = Me.daGetButtonsForUser.SelectCommand.CommandText
    End Sub


    Public Sub loadAllSelListEntries(ClearDataTable As Boolean, Optional AddGroup As Boolean = True)
        Try
            'umschreiben - nicht alle löschen >> nut die wo in Stay-UI eine SelList hinzugefügt wurde >> nur die eine SelList nachladen (Alles clear weggeben)
            If ClearDataTable Then
                sqlAdmin.dsAllAdmin.tblSelListEntries.Clear()
            End If
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.getSelListEntrysAll(Parameters, "", sqlAdmin.dsAllAdmin, eTypAuswahlList.all, "", license.doLicense.eApp.ALL.ToString())
            Me.getSelListEntrysSort(-999, "", dsAllAdmin, eTypSelListSort.All, "")

        Catch ex As Exception
            Throw New Exception("loadAllSelListEntries: " + ex.ToString())
        End Try
    End Sub

    Public Sub ReloadSelListEntriesGrp(IDGroupdToReLoad As String, IDApplication As String, IDParticpant As String)
        Try
            Dim sWhereGrp As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='" + IDGroupdToReLoad.Trim() + "' and " +
                                        qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDApplicationColumn.ColumnName + "='" + IDApplication.Trim() + "' and " +
                                        qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDParticipantColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString().Trim() + "' "
            Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(sWhereGrp, "")
            Dim rSelListGroup As dsAdmin.tblSelListGroupRow = Nothing
            If arrSelListEntryGroup.Length > 1 Then
                Throw New Exception("ReloadSelListEntriesGrp: arrSelListEntryGroup.Length>1 for IDGroupStr '" + IDGroupdToReLoad.Trim() + "'!")
            ElseIf arrSelListEntryGroup.Length = 0 Then
                sWhereGrp = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='" + IDGroupdToReLoad.Trim() + "' and " +
                            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDApplicationColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString().Trim() + "' and " +
                            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDParticipantColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString().Trim() + "' "

                arrSelListEntryGroup = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(sWhereGrp, "")
                If arrSelListEntryGroup.Length <> 1 Then
                    Throw New Exception("ReloadSelListEntriesGrp: arrSelListEntryGroup.Length<>1 for IDGroupStr '" + IDGroupdToReLoad.Trim() + "'!")
                End If
                rSelListGroup = arrSelListEntryGroup(0)
            ElseIf arrSelListEntryGroup.Length = 1 Then
                rSelListGroup = arrSelListEntryGroup(0)
            End If

            Dim sWhereSelList As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDGroupColumn.ColumnName + "='" + rSelListGroup.ID.ToString() + "' "
            Dim arrSelListEntries() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhereSelList, "")
            For Each rSelListToDelete As dsAdmin.tblSelListEntriesRow In arrSelListEntries
                rSelListToDelete.Delete()
            Next
            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.AcceptChanges()

            Dim dsAdminTmp As New dsAdmin()
            Dim sqlAdminTmp As New sqlAdmin()
            sqlAdminTmp.initControl()
            dsAdminTmp.tblSelListEntries.Clear()
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            sqlAdminTmp.getSelListEntrys(Parameters, "", "", "", dsAdminTmp, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroup, "", -999, "", rSelListGroup.ID)
            For Each rSelListInDB As dsAdmin.tblSelListEntriesRow In dsAdminTmp.tblSelListEntries
                Dim rNewSelList1 As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.NewRow()
                rNewSelList1.ItemArray = rSelListInDB.ItemArray
                qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Rows.Add(rNewSelList1)
            Next
            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.AcceptChanges()

        Catch ex As Exception
            Throw New Exception("ReloadSelListEntriesGrp: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadAll(ClearDataTableSelListEntries As Boolean)
        Me.getCriterias(sqlAdmin.dsAllAdmin, eTypSelCriteria.search, "", license.doLicense.eApp.ALL.ToString(), False, False, False, "", "", False)
        Me.getSelListGroup(sqlAdmin.dsAllAdmin, eTypSelGruppen.all, "", "", license.doLicense.eApp.ALL.ToString())
        Me.loadAllSelListEntries(ClearDataTableSelListEntries)
        qs2.core.vb.sqlObjects.loadAllData()
    End Sub

    Public Function getSelListGroupRow_ParticAppl(ByRef Parameters As ParametersSelListEntries, ByVal IDGroup As String, ByVal IDParticipant As String,
                                                  ByVal IDApplication As String, ByVal doExecptIfNotFound As Boolean) As dsAdmin.tblSelListGroupRow

        Dim dtGrpTmp As dsAdmin.tblSelListGroupDataTable = Me.getSelListGroupRows(IDGroup, eTypSelGruppen.IDGruppeStrNoAppPart)
        If Not dtGrpTmp.Any Then
            Parameters.GroupNotFoundInAnyApplication = True
            If doExecptIfNotFound Then
                Throw New Exception("getSelListGroupRow_PartApp: No Group-Entry for IDGroup '" + IDGroup.ToString() + "' exists in table tblSelListGroup !")
            End If
        Else
            'Check in Order of priority in datatable instead of additional queries - for specific IDParticipant and IDApplication
            Dim checkRow = (From tt In dtGrpTmp
                            Where tt.IDParticipant = IDParticipant And tt.IDApplication = IDApplication 'specific for Participant and Application
                            Select tt).FirstOrDefault

            If IsNothing(checkRow) Then
                checkRow = (From tt In dtGrpTmp
                            Where tt.IDParticipant = IDParticipant And tt.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()    'specific for Participant
                            Select tt).FirstOrDefault

                If IsNothing(checkRow) Then
                    checkRow = (From tt In dtGrpTmp
                                Where tt.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString() And tt.IDApplication = IDApplication   'specific for Product
                                Select tt).FirstOrDefault

                    If IsNothing(checkRow) Then
                        checkRow = (From tt In dtGrpTmp
                                    Where tt.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString() And tt.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()   'general
                                    Select tt).FirstOrDefault
                    End If
                End If
            End If
            Return checkRow
        End If
    End Function

    Public Function getSelListGroupRow(ByVal IDGroup As String, ByVal IDParticipant As String, ByVal IDApplication As String) As dsAdmin.tblSelListGroupRow

        Dim ds As New dsAdmin
        Me.getSelListGroup(ds, eTypSelGruppen.IDGruppeStr, IDGroup, IDParticipant, IDApplication)
        If ds.tblSelListGroup.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblSelListGroup.Rows.Count = 1 Then
            Return ds.tblSelListGroup.Rows(0)
        ElseIf ds.tblSelListGroup.Rows.Count > 1 Then
            'Throw New Exception("getSelListGroupRow.idGroup: More than one Row for IDGroup '" + idGruppe.ToString() + "' found!")
            Return Nothing
        End If
    End Function

    Public Function getSelListGroupRowID(ByVal IDGroup As Integer) As dsAdmin.tblSelListGroupRow

        Dim ds As New dsAdmin
        Me.getSelListGroup(ds, eTypSelGruppen.IDGruppeNoAppPart, "", "", "", IDGroup)
        If ds.tblSelListGroup.Rows.Count = 0 Then
            Throw New Exception("getSelListGroupRowID.idGroup: No Row for IDGroup '" + IDGroup.ToString() + "' found!")
        ElseIf ds.tblSelListGroup.Rows.Count = 1 Then
            Return ds.tblSelListGroup.Rows(0)
        ElseIf ds.tblSelListGroup.Rows.Count > 1 Then
            Throw New Exception("getSelListGroupRowID.idGroup: More than one Row for IDGroup '" + IDGroup.ToString() + "' found!")
        End If
    End Function

    Public Function getSelListGroupRows(ByVal IDGroup As String, TypSelListGruppe As eTypSelGruppen) As dsAdmin.tblSelListGroupDataTable
        Dim ds As New dsAdmin
        Me.getSelListGroup(ds, TypSelListGruppe, IDGroup, "", "")
        Return ds.tblSelListGroup
    End Function

    Public Function getSelListGroup(ByRef ds As dsAdmin, ByVal typSel As eTypSelGruppen,
                                  ByVal IDGroup As String, ByVal IDParticipant As String, ByVal IDApplication As String,
                                  Optional ByVal ID As Integer = 0,
                                  Optional ByVal str As String = "") As dsAdmin.tblSelListGroupRow()

        Me.daSelListGroup.SelectCommand.CommandText = Me.sel_daSelListGroup
        core.dbBase.setConnection(Me.daSelListGroup)
        Me.daSelListGroup.SelectCommand.Parameters.Clear()

        If typSel = eTypSelGruppen.all Then
            Dim sWhere As String = "  "
            If IDApplication <> license.doLicense.eApp.ALL.ToString() Then
                sWhere += sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListGroup.IDApplicationColumn.ColumnName)
                Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDApplicationColumn.ColumnName), IDApplication.ToString())
            End If
            Me.daSelListGroup.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListGroup.DescriptionColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelGruppen.IDGruppeStr Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListGroup.IDGroupStrColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListGroup.IDParticipantColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListGroup.IDApplicationColumn.ColumnName)
            Me.daSelListGroup.SelectCommand.CommandText += sWhere
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDGroupStrColumn.ColumnName), IDGroup.ToString())
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDParticipantColumn.ColumnName), IDParticipant)
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDApplicationColumn.ColumnName), IDApplication.ToString())

        ElseIf typSel = eTypSelGruppen.IDGruppeStrNoAppPart Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListGroup.IDGroupStrColumn.ColumnName)
            Me.daSelListGroup.SelectCommand.CommandText += sWhere
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDGroupStrColumn.ColumnName), IDGroup.ToString())

        ElseIf typSel = eTypSelGruppen.IDGruppe Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListGroup.IDColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListGroup.IDParticipantColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListGroup.IDApplicationColumn.ColumnName)
            Me.daSelListGroup.SelectCommand.CommandText += sWhere
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDColumn.ColumnName), ID.ToString())
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDParticipantColumn.ColumnName), IDParticipant)
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDApplicationColumn.ColumnName), IDApplication.ToString())

        ElseIf typSel = eTypSelGruppen.IDGruppeNoAppPart Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListGroup.IDColumn.ColumnName)
            Me.daSelListGroup.SelectCommand.CommandText += sWhere
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDColumn.ColumnName), ID.ToString())

        ElseIf typSel = eTypSelGruppen.SelListUsr Then
            Dim sWhere As String = sqlTxt.where + ds.tblSelListGroup.ClassificationColumn.ColumnName + sqlTxt.likePerc + str.Trim() + sqlTxt.likePercEnd +
                                    sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListGroup.IDApplicationColumn.ColumnName)

            Me.daSelListGroup.SelectCommand.CommandText += sWhere
            Me.daSelListGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListGroup.IDApplicationColumn.ColumnName), IDApplication.ToString())

        ElseIf typSel = eTypSelGruppen.IDGruppeRam Then
            Dim arrSelListGroup() As dsAdmin.tblSelListGroupRow = sqlAdmin.dsAllAdmin.tblSelListGroup.Select(ds.tblSelListGroup.IDGroupStrColumn.ColumnName + "='" + IDGroup + "'" + sqlTxt.and + ds.tblSelListGroup.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'" + sqlTxt.and + ds.tblSelListGroup.IDApplicationColumn.ColumnName + "='" + IDApplication + "'")
            Return arrSelListGroup

        ElseIf typSel = eTypSelGruppen.IDRam Then
            Dim arrSelListGroup() As dsAdmin.tblSelListGroupRow = sqlAdmin.dsAllAdmin.tblSelListGroup.Select(ds.tblSelListGroup.IDColumn.ColumnName + "=" + ID.ToString() + "")
            Return arrSelListGroup

        Else
            Throw New Exception("sqlAdmin.getSelListGroup: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daSelListGroup.Fill(ds.tblSelListGroup)
    End Function

    Public Function getNewRowSelListGroup(ByVal dsAdmin1 As dsAdmin) As dsAdmin.tblSelListGroupRow
        Dim rNew As dsAdmin.tblSelListGroupRow = dsAdmin1.tblSelListGroup.NewRow()
        rNew.ID = -999
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.IDGroupStr = ""
        rNew.IDApplication = ""
        rNew.IDParticipant = ""
        rNew.IDRessource = ""
        rNew.sys = False
        rNew.Sublist = ""
        rNew.TypeEnum = ""
        rNew.SortColumn = ""
        rNew.Classification = ""
        rNew.Description = ""
        rNew.VersionNrFrom = ""
        rNew.VersionNrTo = ""

        dsAdmin1.tblSelListGroup.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function getSelListEntrysRow(ByVal IDGroup As String,
                                        ByVal typSel As eTypAuswahlList,
                                        ByVal IDParticipant As String, ByVal Application As String,
                                        Optional ByVal typ As String = "",
                                        Optional ByVal IDOwnInt As Integer = 0,
                                        Optional ByVal IDOwnStr As String = "",
                                        Optional ByVal ID As Integer = 0) As dsAdmin.tblSelListEntriesRow

        Dim ds As New dsAdmin
        Dim Parameters As New ParametersSelListEntries()
        Me.getSelListEntrysAll(Parameters, IDGroup, ds, typSel, IDParticipant, Application, typ, IDOwnInt, IDOwnStr, ID)
        If ds.tblSelListEntries.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblSelListEntries.Rows.Count = 1 Then
            Return ds.tblSelListEntries.Rows(0)
        ElseIf ds.tblSelListEntries.Rows.Count > 1 Then
            Throw New Exception("getSelListEntrysRow.id: More than one Row for idNr '" + IDOwnInt.ToString() + "' found!")
            Return Nothing
        End If
    End Function

    Public Function getSelListEntrysAll(ByRef Parameters As ParametersSelListEntries, ByVal IDGroup As String,
                                      ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList,
                                      ByVal IDParticipant As String, ByVal IDApplication As String,
                                        Optional ByVal typ As String = "",
                                        Optional ByVal IDOwnInt As Integer = 0,
                                        Optional ByVal IDOwnStr As String = "",
                                        Optional ByVal ID As Integer = 0) As Boolean

        Me.getSelListEntrys(Parameters, IDGroup, IDParticipant, IDApplication, ds, typSel, typ, IDOwnInt, IDOwnStr, ID)
        Return True
    End Function

    Public Function getSelListEntrys(ByRef Parameters As ParametersSelListEntries, ByVal IDGroup As String,
                                        ByVal IDParticipant As String, ByVal IDApplication As String,
                                        ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList,
                                        Optional ByVal typ As String = "",
                                        Optional ByVal IDOwnInt As Integer = 0,
                                        Optional ByVal IDOwnStr As String = "",
                                        Optional ByVal ID As Integer = 0,
                                        Optional ByVal column As String = "",
                                        Optional ByVal table As String = "",
                                        Optional allNotPrivateFromOtherUsers As Boolean = False) As dsAdmin.tblSelListEntriesRow()
        Try
            Me.daSelListEntrys.SelectCommand.CommandText = Me.sel_daSelListEntrys
            core.dbBase.setConnection(Me.daSelListEntrys)
            Me.daSelListEntrys.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.IDGroup Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDGroupColumn.ColumnName)
                Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), ID)

            ElseIf typSel = eTypAuswahlList.IDGroupParticipantAndAll Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDGroupColumn.ColumnName)
                sWhere += " and (IDParticipant='" + IDParticipant.Trim() + "' or IDParticipant='ALL' or IDParticipant = '') "
                Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), ID)

            ElseIf typSel = eTypAuswahlList.IDParticipantUserSelList Then
                Dim sWhere As String = " where IDParticipant='" + IDParticipant.Trim() + "' and IDParticipant<>'ALL' and IDParticipant<>'' "
                Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypAuswahlList.IDOwnStrIDGroup Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDGroupColumn.ColumnName) +
                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntries.IDOwnStrColumn.ColumnName)
                Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), ID)
                Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDOwnStrColumn.ColumnName), IDOwnStr)

            ElseIf typSel = eTypAuswahlList.IDGroupRam Then
                Dim arrSellistEntries() As dsAdmin.tblSelListEntriesRow = sqlAdmin.dsAllAdmin.tblSelListEntries.Select(ds.tblSelListEntries.IDGroupColumn.ColumnName + "=" + ID.ToString(), ds.tblSelListEntries.sortColumn.ColumnName + " asc")
                Return arrSellistEntries

            ElseIf typSel = eTypAuswahlList.IDRam Then
                Dim arrSellistEntries() As dsAdmin.tblSelListEntriesRow = sqlAdmin.dsAllAdmin.tblSelListEntries.Select(ds.tblSelListEntries.IDColumn.ColumnName + "=" + ID.ToString())
                Return arrSellistEntries

            ElseIf typSel = eTypAuswahlList.id Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDColumn.ColumnName)
                Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDColumn.ColumnName), ID)

            ElseIf typSel = eTypAuswahlList.all Then
                Dim bAll As Boolean = True

            Else
                Dim sWhereGrp As String = sqlTxt.getColWhere(ds.tblSelListEntries.IDGroupColumn.ColumnName)
                Parameters.rGrpFound = Me.getSelListGroupRow_ParticAppl(Parameters, IDGroup, IDParticipant, IDApplication, Parameters.doExecptIfNotFound)


                If typSel = eTypAuswahlList.groupParticipantOwnOrAll Then
                    Dim sWhere As String = sqlTxt.where + sWhereGrp
                    sWhere += " and (IDParticipant='" + IDParticipant.Trim() + "' or IDParticipant='ALL' or IDParticipant = '') "
                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)

                ElseIf typSel = eTypAuswahlList.group Then
                    Dim sWhere As String = sqlTxt.where + sWhereGrp
                    sWhere += " and (IDParticipant='" + IDParticipant.Trim() + "'"
                    sWhere += " or IDParticipant='ALL' or IDParticipant = ''"
                    sWhere += ") "
                    daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)

                ElseIf typSel = eTypAuswahlList.groupTypStr Then
                    Dim sWhere As String = sqlTxt.where + sWhereGrp + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntries.TypeStrColumn.ColumnName)
                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.TypeStrColumn.ColumnName), typ)

                ElseIf typSel = eTypAuswahlList.groupTypEnum Then
                    Dim sWhere As String = sqlTxt.where + sWhereGrp + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntries.TypeStrColumn.ColumnName)
                    sWhere += sqlTxt.and + ds.tblSelListEntries.CreatedUserColumn.ColumnName + sqlTxt.equals + "'" + qs2.core.vb.actUsr.rUsr.UserName.Trim() + "'"

                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.TypeStrColumn.ColumnName), typ)

                ElseIf typSel = eTypAuswahlList.groupTypEnumUserName Then
                    Dim sWhere As String = sqlTxt.where + sWhereGrp + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntries.TypeStrColumn.ColumnName)

                    If (Not allNotPrivateFromOtherUsers) Then
                        sWhere += sqlTxt.and + sqlTxt.ClampRight + ds.tblSelListEntries.CreatedUserColumn.ColumnName + sqlTxt.equals + "'" + qs2.core.vb.actUsr.rUsr.UserName.Trim() + "'" + sqlTxt.ClampLeft
                    End If

                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntries.IDRessourceColumn.ColumnName + sqlTxt.asc
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.TypeStrColumn.ColumnName), typ)

                ElseIf typSel = eTypAuswahlList.IDOwnInt Then
                    Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDOwnIntColumn.ColumnName) + sqlTxt.and + sWhereGrp
                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDOwnIntColumn.ColumnName), IDOwnInt)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)

                ElseIf typSel = eTypAuswahlList.IDOwnStr Then
                    Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDOwnStrColumn.ColumnName) + sqlTxt.and + sWhereGrp
                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDOwnStrColumn.ColumnName), IDOwnStr)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDColumn.ColumnName), Parameters.rGrpFound.ID)

                ElseIf typSel = eTypAuswahlList.column Then
                    Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhereClamp(ds.tblSelListEntries.FldShortColumnColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhereClamp(ds.tblSelListEntries.TableColumn.ColumnName) + sqlTxt.and + sWhereGrp
                    Me.daSelListEntrys.SelectCommand.CommandText += sWhere
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.FldShortColumnColumn.ColumnName), column)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.TableColumn.ColumnName), table)
                    Me.daSelListEntrys.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntries.IDGroupColumn.ColumnName), Parameters.rGrpFound.ID)

                Else
                    Throw New Exception("sqlAdmin.getSelListEntrys: typSel '" + typSel.ToString() + "' is wrong!")
                End If
            End If

            Me.daSelListEntrys.Fill(ds.tblSelListEntries)

        Catch ex As Exception
            Throw New Exception("getSelListEntrys: " + ex.ToString())
        End Try
    End Function

    Public Function deleteSelListEntry(ByVal ID As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntries.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntries.IDColumn.ColumnName)
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntries.IDColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntries.IDColumn.ColumnName))).Value = ID
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function deleteSelListEntriesSort(IDSelListEntry As Integer, IDParticipant As String) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = "Delete qs2.tblSelListEntriesSort where IDSelListEntry=" + IDSelListEntry.ToString() + " and IDParticipant='" + IDParticipant.Trim() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.deleteSelListEntriesSort: " + ex.ToString())
        End Try
    End Function

    Public Sub getSelListEntrysRelGroup(ByVal IDGroup As String,
                                      ByVal IDApplication As String,
                                      ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList)

        Me.davListEntriesWithGroup.SelectCommand.CommandText = Me.sel_daSelListEntrysRelGroup
        core.dbBase.setConnection(Me.davListEntriesWithGroup)
        Me.davListEntriesWithGroup.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahlList.group Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName)
            Me.davListEntriesWithGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName), IDGroup.ToString())
            If IDApplication <> license.doLicense.eApp.ALL.ToString() Then
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName)
                Me.davListEntriesWithGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName), IDApplication.ToString())
            End If
            Me.davListEntriesWithGroup.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName + sqlTxt.asc + "," + ds.vListEntriesWithGroup.s_IDRessourceColumn.ColumnName + sqlTxt.asc
        End If

        Me.davListEntriesWithGroup.Fill(ds.vListEntriesWithGroup)
    End Sub

    Public Function getSelListEntrysSort(ID As Integer, IDParticipant As String,
                                           ds As dsAdmin, typeSel As eTypSelListSort, sWhere As String) As dsAdmin.tblSelListEntriesSortRow()
        Try
            Me.daSelListEntriesSort.SelectCommand.CommandText = Me.sel_daSelListEntrysSort
            core.dbBase.setConnection(Me.daSelListEntriesSort)
            Me.daSelListEntriesSort.SelectCommand.Parameters.Clear()

            If typeSel = eTypSelListSort.IDSelListIDParticipantIDRam Then
                Dim sWhereTmp As String = "IDParticipant='" + IDParticipant.Trim() + "' and " + sWhere
                Dim sOrderBy As String = " Sort asc"
                Dim arrSellistEntriesSort() As dsAdmin.tblSelListEntriesSortRow = sqlAdmin.dsAllAdmin.tblSelListEntriesSort.Select(sWhereTmp, sOrderBy)
                Return arrSellistEntriesSort

            ElseIf typeSel = eTypSelListSort.All Then
                Dim sWhereTmp As String = ""

            Else
                Throw New Exception("sqlAdmin.getSelListEntrysSort: typeSel '" + typeSel.ToString() + "' is wrong!")
            End If

            Me.daSelListEntriesSort.Fill(ds.tblSelListEntriesSort)

        Catch ex As Exception
            Throw New Exception("getSelListEntrysSort: " + ex.ToString())
        End Try
    End Function

    Public Function getSelListEntrysObj(ByVal ID As Integer,
                                        ByVal typDB As eDbTypAuswObj,
                                        ByVal Group As String,
                                        ByVal ds As dsAdmin,
                                        ByVal typSel As eTypAuswahlObj,
                                        ByVal IDApplication As String,
                                        Optional ByVal IDSelListEntry As Integer = Nothing,
                                        Optional ByVal FldShort As String = "",
                                        Optional ByVal IDStay As Integer = Nothing,
                                        Optional ByVal IDParticipant As String = "",
                                        Optional ByVal IDSelListEntrySublist As Integer = Nothing,
                                        Optional Chapter As String = "", Optional IDGroupStr As String = "",
                                        Optional ApplicationAndAll As Boolean = False,
                                        Optional IDGuid As Nullable(Of Guid) = Nothing,
                                        Optional sqlCommandReturn As String = "",
                                        Optional typIDGroup As String = "",
                                        Optional dat As Nullable(Of DateTime) = Nothing) As dsAdmin.tblSelListEntriesObjRow()

        Try
            Me.daSelListEntrysObj.SelectCommand.CommandText = Me.sel_daSelListEntrysObj
            core.dbBase.setConnection(Me.daSelListEntrysObj)
            Me.daSelListEntrysObj.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlObj.obj Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), typDB.ToString())

            ElseIf typSel = eTypAuswahlObj.objOnly Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName), ID)

            ElseIf typSel = eTypAuswahlObj.objRAM Then
                Dim sWhere As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDObjectColumn.ColumnName + "=" + ID.ToString() + "" + sqlTxt.and +
                                        sqlAdmin.dsAllAdmin.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='" + typDB.ToString() + "'"
                Dim arrSelListObjs As dsAdmin.tblSelListEntriesObjRow() = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhere, "")
                Return arrSelListObjs

            ElseIf typSel = eTypAuswahlObj.RAMRightUser Then
                Dim sWhere As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName + "=" + IDSelListEntry.ToString() + "" + sqlTxt.and +
                                        sqlAdmin.dsAllAdmin.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='" + Group.ToString() + "'"
                Dim arrSelListObjs As dsAdmin.tblSelListEntriesObjRow() = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhere, "")
                Return arrSelListObjs

            ElseIf typSel = eTypAuswahlObj.IDGuid Then
                Dim sWhere As String = sqlTxt.where + ds.tblSelListEntriesObj.IDGuidColumn.ColumnName + "='" + IDGuid.ToString() + "'"
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypAuswahlObj.sellist Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group.ToString())

            ElseIf typSel = eTypAuswahlObj.IDSelListEntrySublist Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group.ToString())

            ElseIf typSel = eTypAuswahlObj.IDSelListEntry Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group.ToString())

            ElseIf typSel = eTypAuswahlObj.IDSelListEntryIDObject Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), IDSelListEntry)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group.ToString())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDObjectColumn.ColumnName), ID.ToString())

            ElseIf typSel = eTypAuswahlObj.IDSelListEntryFldShort Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.FldShortColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName)

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), typDB.ToString())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.FldShortColumn.ColumnName), FldShort.Trim())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName), IDApplication.Trim())

            ElseIf typSel = eTypAuswahlObj.FldShortOtherChapters Then
                Dim sWhere As String = sqlTxt.where + " IDSelListEntry<>" + ID.ToString() + " " + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.FldShortColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName) + " and Created<>@Created and " +
                                        " IDSelListEntry in (Select qs2.tblSelListEntries.ID from qs2.tblSelListEntries, qs2.tblSelListGroup " +
                                        " where qs2.tblSelListEntries.IDGroup=qs2.tblSelListGroup.ID And qs2.tblSelListGroup.IDApplication='" + Chapter.Trim() + "') "

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), typDB.ToString())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.FldShortColumn.ColumnName), FldShort.Trim())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName), IDApplication.Trim())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.CreatedColumn.ColumnName), dat.Value)

            ElseIf typSel = eTypAuswahlObj.IDSelListEntryIDStayTypIDGroup Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), IDSelListEntry)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), IDStay)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), IDParticipant)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), IDApplication)

            ElseIf typSel = eTypAuswahlObj.IDSelListEntrySubListIDStayTypIDGroup Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName), IDSelListEntrySublist)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), IDStay)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), IDParticipant)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), IDApplication)

            ElseIf typSel = eTypAuswahlObj.IDStayTypIDGroup Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), Group)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), IDStay)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), IDParticipant)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), IDApplication)

            ElseIf typSel = eTypAuswahlObj.IDStay Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), IDStay)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), IDParticipant)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), IDApplication)

            ElseIf typSel = eTypAuswahlObj.allCriterias Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.not + ds.tblSelListEntriesObj.FldShortColumn.ColumnName + " " + sqlTxt.isNull
                If Not ApplicationAndAll Then
                    If IDApplication.ToString() <> license.doLicense.eApp.ALL.ToString() Then
                        sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName)
                        Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName), IDApplication.ToString())
                    End If
                Else
                    Dim sWhereApp As String = " ( " + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName).Trim() + "1 " + " " + sqlTxt.or + " " + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName).Trim() + "2 " + ") "
                    Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "1"), IDApplication.ToString())
                    Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "2"), qs2.core.license.doLicense.eApp.ALL.ToString())
                    sWhere += IIf(sWhere.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + sWhereApp
                End If

                If FldShort.ToString() <> "" Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.FldShortColumn.ColumnName)
                    Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.FldShortColumn.ColumnName), FldShort)
                End If
                If Not IDSelListEntry = Nothing Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName)
                    Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), IDSelListEntry)
                End If

                If Chapter.Trim() <> "" Then
                    sWhere += IIf(sWhere.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + " " + ds.tblSelListEntriesObj.FldShortColumn.ColumnName + " IN (" + Me.getSqlWhereForChapter(Chapter, IDApplication, "Criterias", IDGroupStr) + ") "
                End If
                If typIDGroup.Trim() <> "" Then
                    sWhere += sqlTxt.and + " typIDGroup='" + typIDGroup.Trim() + "' "
                End If
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblSelListEntriesObj.FldShortColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypAuswahlObj.allFldShortRam Then
                Dim sWhere As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.FldShortColumn.ColumnName + "='" + FldShort + "'" + sqlTxt.and +
                                        sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "='" + IDApplication + "'"
                Dim arrSelListObjs As dsAdmin.tblSelListEntriesObjRow() = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhere, "")
                Return arrSelListObjs

            ElseIf typSel = eTypAuswahlObj.AllSelListObjects Then
                Dim sWhere As String = sqlTxt.where + " typIDGroup<>'" + qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters.ToString() +
                                        "' and typIDGroup<>'" + qs2.core.vb.sqlAdmin.typIDGroup_ProceduresToStay.ToString() + "' "
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("sqlAdmin.getSelListEntrysObj: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daSelListEntrysObj.Fill(ds.tblSelListEntriesObj)
            sqlCommandReturn = Me.daSelListEntrysObj.SelectCommand.CommandText

            Return Nothing

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getSelListEntrysObj: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowSelListObj(ByVal dsAdmin1 As dsAdmin) As dsAdmin.tblSelListEntriesObjRow
        Dim rNew As dsAdmin.tblSelListEntriesObjRow = dsAdmin1.tblSelListEntriesObj.NewRow()
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.SetFldShortNull()
        rNew.SetIDApplicationNull()
        rNew.SetIDObjectNull()
        rNew.SetIDSelListEntrySublistNull()
        rNew.IDSelListEntry = -999
        rNew.SetIDStayNull()
        rNew.SetIDParticipantStayNull()
        rNew.SetIDApplicationStayNull()
        rNew.typIDGroup = ""
        rNew.SetFromNull()
        rNew.Set_ToNull()
        rNew.IDClassification = ""
        rNew.SetIDOwnIntNull()
        rNew.Created = Now
        rNew.CreatedBy = ""
        rNew.Modified = Now
        rNew.ModifiedBy = ""
        rNew.Sort = 0
        rNew.Description = ""
        rNew.Active = False
        rNew.IsMain = False
        rNew.IDParticipant = ""
        rNew.SetIDObjectGuidNull()
        rNew.SetTransferedNull()
        rNew.nVisible = -1

        dsAdmin1.tblSelListEntriesObj.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function deleteSelListEntryObj(ByVal IDSelListEntry As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName)
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), System.Data.SqlDbType.Int, 16, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName))).Value = IDSelListEntry
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function deleteSelListEntrySublistObj(ByVal IDSelListEntrySublist As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName)
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName), System.Data.SqlDbType.Int, 16, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName))).Value = IDSelListEntrySublist
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function deleteSelListEntryObj(ByVal IDSelListEntry As Integer, typIDGroup As String) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + " IDSelListEntry=" + IDSelListEntry.ToString() + " And typIDGroup='" + typIDGroup.Trim() + "' "
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.deleteSelListEntryObj: " + ex.ToString())
        End Try
    End Function

    Public Shared Function getSelList(ByVal lst As Infragistics.Win.ValueList,
                   ByVal cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                   ByVal gruppe As String, ByVal typID As eTypSelListID, ByVal dsAdmin1 As dsAdmin,
                   eMandantTyp As qs2.core.vb.sqlAdmin.eTypAuswahlList) As Boolean
        Try
            Return loadSelList(lst, cbo, gruppe, typID, dsAdmin1, "", "", eMandantTyp)

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getSelList: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Shared Function loadSelList(ByVal lst As Infragistics.Win.ValueList,
                            ByVal cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                            ByVal gruppe As String, ByVal typID As eTypSelListID, ByVal dsAdmin1 As dsAdmin,
                            ByVal typ As String,
                            ByVal extern As String,
                            eMandantTyp As qs2.core.vb.sqlAdmin.eTypAuswahlList) As Boolean
        Try
            Dim sqlAdmin1 As New sqlAdmin()
            sqlAdmin1.initControl()

            If Not lst Is Nothing Then lst.ValueListItems.Clear()
            If Not cbo Is Nothing Then cbo.Items.Clear()

            dsAdmin1.Clear()
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            If typ <> "" Then
                sqlAdmin1.getSelListEntrys(Parameters, gruppe,
                                           qs2.core.license.doLicense.rParticipant.IDParticipant,
                                           qs2.core.license.doLicense.rApplication.IDApplication,
                                           dsAdmin1, eMandantTyp, typ)
            Else
                sqlAdmin1.getSelListEntrys(Parameters, gruppe,
                                           qs2.core.license.doLicense.rParticipant.IDParticipant,
                                           qs2.core.license.doLicense.rApplication.IDApplication,
                                           dsAdmin1, eMandantTyp)

                If dsAdmin1.tblSelListEntries.Rows.Count = 0 Then
                    sqlAdmin1.getSelListEntrys(Parameters, gruppe,
                            qs2.core.license.doLicense.rParticipant.IDParticipant,
                            qs2.core.license.doLicense.eApp.ALL.ToString(),
                            dsAdmin1, eMandantTyp)

                    If dsAdmin1.tblSelListEntries.Rows.Count = 0 Then
                        sqlAdmin1.getSelListEntrys(Parameters, gruppe,
                                qs2.core.license.doLicense.eApp.ALL.ToString(),
                                qs2.core.license.doLicense.rApplication.IDApplication,
                                dsAdmin1, eMandantTyp)

                        If dsAdmin1.tblSelListEntries.Rows.Count = 0 Then
                            sqlAdmin1.getSelListEntrys(Parameters, gruppe,
                                    qs2.core.license.doLicense.eApp.ALL.ToString(),
                                    qs2.core.license.doLicense.eApp.ALL.ToString(),
                                    dsAdmin1, eMandantTyp)
                        End If

                    End If
                End If
            End If

            For Each r As dsAdmin.tblSelListEntriesRow In dsAdmin1.tblSelListEntries
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(r.IDRessource, qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication)
                If resFound.Trim() = "" Then
                    resFound = r.IDRessource
                End If

                If Not cbo Is Nothing Then
                    Select Case typID
                        Case eTypSelListID.guid
                            cbo.Items.Add(r.ID, resFound)
                        Case eTypSelListID.IDOwnInt
                            cbo.Items.Add(r.IDOwnInt, resFound)
                        Case eTypSelListID.IDOwnStr
                            cbo.Items.Add(r.IDOwnStr, resFound)
                        Case eTypSelListID.Description
                            cbo.Items.Add(r.IDRessource, resFound)
                    End Select
                End If
                If Not lst Is Nothing Then
                    Select Case typID
                        Case eTypSelListID.guid
                            lst.ValueListItems.Add(r.ID, resFound)
                        Case eTypSelListID.IDOwnInt
                            lst.ValueListItems.Add(r.IDOwnInt, resFound)
                        Case eTypSelListID.IDOwnStr
                            lst.ValueListItems.Add(r.IDOwnStr, resFound)
                        Case eTypSelListID.Description
                            lst.ValueListItems.Add(r.IDRessource, resFound)
                    End Select
                End If

            Next

            If Not cbo Is Nothing Then
                cbo.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
            End If
            If Not lst Is Nothing Then
                lst.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.loadSelList: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getNewRowSelList(ByVal dsAdmin1 As dsAdmin, addCreatedUser As Boolean) As dsAdmin.tblSelListEntriesRow
        Dim rNew As dsAdmin.tblSelListEntriesRow = dsAdmin1.tblSelListEntries.NewRow()
        rNew.ID = -999
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.IDRessource = ""
        rNew.SetIDOwnIntNull()
        rNew.IDOwnStr = ""
        rNew.SetsortNull()
        rNew.IsMain = False
        rNew.TypeQry = ""
        rNew.TypeStr = ""
        rNew._Table = ""
        rNew.FldShortColumn = ""
        rNew.SetpictureNull()
        rNew.IDGroup = -999
        If addCreatedUser Then
            rNew.CreatedUser = qs2.core.vb.actUsr.rUsr.UserName
        Else
            rNew.CreatedUser = "System"
        End If
        rNew._Private = False
        rNew.Classification = ""
        rNew.Created = Now
        rNew.Sql = ""
        rNew.VersionNrFrom = ""
        rNew.VersionNrTo = ""
        rNew.UIType = ""
        rNew.Description = ""
        rNew.IDParticipant = ""
        rNew.Extern = False
        rNew.SubQuery = False
        rNew.LicenseKey = ""
        rNew.Published = True
        rNew.ForServices = False

        dsAdmin1.tblSelListEntries.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function getCriterias(ByVal ds As dsAdmin, ByVal typSel As eTypSelCriteria,
                                 ByVal FldShort As String,
                                 ByVal IDApplication As String, ByVal onlyNotInChapters As Boolean,
                                 ByVal doPreferedVisibleUnvisible As Boolean, ByVal bOnlyPrefered As Boolean,
                                 Chapter As String, IDGroupStr As String, ApplicationAndAll As Boolean) As dsAdmin.tblCriteriaRow()
        Try
            Me.daCriteria.SelectCommand.CommandText = Me.sel_daSelCriteria
            core.dbBase.setConnection(Me.daCriteria)
            Me.daCriteria.SelectCommand.Parameters.Clear()

            If typSel = eTypSelCriteria.search Then
                If FldShort <> "" Then
                    Dim sWhereSearch As String = ""
                    sWhereSearch = ds.tblCriteria.FldShortColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd + sqlTxt.or + ds.tblCriteria.IDApplicationColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd + sqlTxt.or +
                    ds.tblCriteria.ControlTypeColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd + sqlTxt.or + ds.tblCriteria.SourceTableColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd
                    Me.daCriteria.SelectCommand.CommandText += sqlTxt.where + " ( " + sWhereSearch + " ) "
                End If
                If Not ApplicationAndAll Then
                    If IDApplication <> license.doLicense.eApp.ALL.ToString() And Not onlyNotInChapters Then
                        Me.daCriteria.SelectCommand.CommandText += IIf(Me.daCriteria.SelectCommand.CommandText.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + sqlTxt.getColWhere(ds.tblCriteria.IDApplicationColumn.ColumnName)
                        Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName), IDApplication.ToString())
                    End If
                Else
                    Dim sWhereApp As String = " ( " + sqlTxt.getColWhere(ds.tblCriteria.IDApplicationColumn.ColumnName).Trim() + "1 " + " " + sqlTxt.or + " " + sqlTxt.getColWhere(ds.tblCriteria.IDApplicationColumn.ColumnName).Trim() + "2 " + ") "
                    Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName + "1"), IDApplication.ToString())
                    Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName + "2"), qs2.core.license.doLicense.eApp.ALL.ToString())
                    Me.daCriteria.SelectCommand.CommandText += IIf(Me.daCriteria.SelectCommand.CommandText.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + sWhereApp
                End If

                If onlyNotInChapters Then
                    Dim sWhereSearch As String = ""
                    sWhereSearch += " (" + ds.tblCriteria.IDApplicationColumn.ColumnName + "=" + sqlTxt.sMonkey + ds.tblCriteria.IDApplicationColumn.ColumnName + "1" + sqlTxt.or + ds.tblCriteria.IDApplicationColumn.ColumnName + "=" + sqlTxt.sMonkey + ds.tblCriteria.IDApplicationColumn.ColumnName + "2 ) "
                    Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName + "1"), IDApplication.ToString())
                    Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName + "2"), license.doLicense.eApp.ALL.ToString())       'license.doLicense.eApp.ALL.ToString()
                    sWhereSearch += sqlTxt.and + "((" + sqlTxt.select + sqlTxt.countAll +
                                                sqlTxt.from + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName +
                                                sqlTxt.where + " " + ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='Criterias'" + " and (" + ds.tblSelListEntriesObj.FldShortColumn.ColumnName + " = " + ds.tblCriteria.TableName + "." + ds.tblCriteria.FldShortColumn.ColumnName + ") AND (" + ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName + " = " + ds.tblCriteria.TableName + "." + ds.tblCriteria.IDApplicationColumn.ColumnName + ")) = 0)"

                    Me.daCriteria.SelectCommand.CommandText += IIf(Me.daCriteria.SelectCommand.CommandText.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + sWhereSearch
                End If

                If doPreferedVisibleUnvisible Then
                    If bOnlyPrefered Then
                        Me.daCriteria.SelectCommand.CommandText += IIf(Me.daCriteria.SelectCommand.CommandText.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + sqlTxt.getColWhere(ds.tblCriteria.preferedColumn.ColumnName)
                        Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.preferedColumn.ColumnName), True)

                    End If
                End If

                If Chapter.Trim() <> "" Then
                    Me.daCriteria.SelectCommand.CommandText += IIf(Me.daCriteria.SelectCommand.CommandText.Contains(sqlTxt.where), sqlTxt.and, sqlTxt.where) + " " + ds.tblCriteria.FldShortColumn.ColumnName + " IN (" + Me.getSqlWhereForChapter(Chapter, IDApplication, "Criterias", IDGroupStr) + ") "
                End If

                Me.daCriteria.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblCriteria.FldShortColumn.ColumnName + sqlTxt.asc


            ElseIf typSel = eTypSelCriteria.id Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblCriteria.FldShortColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblCriteria.IDApplicationColumn.ColumnName)
                Me.daCriteria.SelectCommand.CommandText += sWhere
                Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.FldShortColumn.ColumnName), FldShort.ToString())
                Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName), IDApplication.ToString())

            ElseIf typSel = eTypSelCriteria.idRam Then
                If doPreferedVisibleUnvisible Then
                    If bOnlyPrefered Then
                        Dim arrCriterias() As dsAdmin.tblCriteriaRow = sqlAdmin.dsAllAdmin.tblCriteria.Select(ds.tblCriteria.FldShortColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblCriteria.IDApplicationColumn.ColumnName + "='" + IDApplication.ToString() + "' " + sqlTxt.and + ds.tblCriteria.preferedColumn.ColumnName + "=1")
                        Return arrCriterias
                    Else
                        Dim arrCriterias() As dsAdmin.tblCriteriaRow = sqlAdmin.dsAllAdmin.tblCriteria.Select(ds.tblCriteria.FldShortColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblCriteria.IDApplicationColumn.ColumnName + "='" + IDApplication.ToString() + "'")
                        Return arrCriterias
                    End If
                Else
                    Dim arrCriterias() As dsAdmin.tblCriteriaRow = sqlAdmin.dsAllAdmin.tblCriteria.Select(ds.tblCriteria.FldShortColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblCriteria.IDApplicationColumn.ColumnName + "='" + IDApplication.ToString() + "'")
                    Return arrCriterias
                End If

            ElseIf typSel = eTypSelCriteria.application Then
                Dim arrCriterias() As dsAdmin.tblCriteriaRow = sqlAdmin.dsAllAdmin.tblCriteria.Select(ds.tblCriteria.IDApplicationColumn.ColumnName + "='" + IDApplication.ToString() + "' ")
                Return arrCriterias

            Else
                Throw New Exception("sqlAdmin.getCriterias: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daCriteria.Fill(ds.tblCriteria)

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getCriterias: " + ex.ToString())
        End Try
    End Function

    Public Function getSqlWhereForChapter(Chapters As String, IDApplication As String, typIDGroup As String, IDGroupStr As String)
        Try
            Dim sWhere As String = ""
            sWhere = " SELECT  qs2.tblCriteria.FldShort " +
                        " FROM qs2.tblCriteria INNER JOIN " +
                        " qs2.tblSelListEntriesObj ON qs2.tblCriteria.FldShort = qs2.tblSelListEntriesObj.FldShort AND  " +
                        " qs2.tblCriteria.IDApplication = qs2.tblSelListEntriesObj.IDApplication INNER JOIN " +
                        " qs2.tblSelListGroup INNER JOIN  " +
                        " qs2.tblSelListEntries ON qs2.tblSelListGroup.ID = qs2.tblSelListEntries.IDGroup ON qs2.tblSelListEntriesObj.IDSelListEntry = qs2.tblSelListEntries.ID " +
                        " WHERE qs2.tblSelListGroup.IDGroupStr = '" + IDGroupStr.ToString() + "' and qs2.tblSelListEntriesObj.typIDGroup = '" + typIDGroup.Trim() + "' AND qs2.tblSelListEntries.IDOwnStr = '" + Chapters.Trim() + "'  "
            Return sWhere

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getSqlWhereForChapter: " + ex.ToString())
        End Try
    End Function

    Public Function addRowCriteria(ByVal ds As qs2.core.vb.dsAdmin) As qs2.core.vb.dsAdmin.tblCriteriaRow

        Dim rNew As qs2.core.vb.dsAdmin.tblCriteriaRow = ds.tblCriteria.NewRow()
        rNew.FldShort = ""
        rNew.IDApplication = ""
        rNew.ControlType = ""
        rNew.SQLValueListSelect = ""
        rNew.AliasFldShort = ""
        rNew.SourceTable = ""
        rNew.ControlPattern = ""
        rNew.MaskInput = ""
        rNew.ControlMinVal = ""
        rNew.ControlMaxVal = ""
        rNew.ControlMinLength = -1
        rNew.ControlMaxLength = -1
        rNew.Used = True
        rNew.Validate = True
        rNew.Editable = True
        rNew.UserDefined = False
        rNew.UseInQueries = True
        rNew.LicenseKey = ""
        rNew.Description = ""
        rNew.ShowAt = ""
        rNew.prefered = False
        rNew.Classification = ""
        rNew.SetDefaultValuesNull()
        rNew.SetDefaultValuesCustomerNull()
        rNew.UsedCustomer = True

        ds.tblCriteria.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function updateDefaultValuesCustomer(ByVal FldShort As String, ByVal IDApplication As String, DefaultValuesCustomer As String, DefaultValuesCustomerIsNull As Boolean,
                                                UsedCustomer As Boolean) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        Dim sDefaultValueCustomerTmp As String = ""
        If DefaultValuesCustomerIsNull Then
            sDefaultValueCustomerTmp = " DefaultValuesCustomer=null "
        Else
            sDefaultValueCustomerTmp = " DefaultValuesCustomer='" + DefaultValuesCustomer.Trim() + "' "
        End If
        Dim sUsedCustomer = ""
        If UsedCustomer Then
            sUsedCustomer = "1"
        Else
            sUsedCustomer = "0"
        End If
        cmd.CommandText = " update qs2.tblCriteria set " + sDefaultValueCustomerTmp + ", UsedCustomer=" + sUsedCustomer + " where FldShort='" + FldShort.Trim() + "' and IDApplication='" + IDApplication.Trim() + "'"
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function getCriteriasOpt(ByVal ds As dsAdmin, ByVal typSel As eTypSelCriteriaOpt,
                                 ByVal FldShort As String,
                                 ByVal Application As String) As dsAdmin.tblCriteriaOptRow()

        Me.daCriteriaOpt.SelectCommand.CommandText = Me.sel_daSelCriteriaOpt
        core.dbBase.setConnection(Me.daCriteriaOpt)
        Me.daCriteriaOpt.SelectCommand.Parameters.Clear()

        If typSel = eTypSelCriteriaOpt.all Then
            If FldShort <> "" Then
                Dim sWhereSearch As String = ""
                sWhereSearch = ds.tblCriteriaOpt.FldShortColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd + sqlTxt.or + ds.tblCriteriaOpt.IDApplicationColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd
                Me.daCriteria.SelectCommand.CommandText += sqlTxt.where + sWhereSearch
            End If
            Me.daCriteria.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblCriteria.FldShortColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelCriteriaOpt.id Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblCriteriaOpt.FldShortColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblCriteriaOpt.IDApplicationColumn.ColumnName)
            Me.daCriteriaOpt.SelectCommand.CommandText += sWhere
            Me.daCriteriaOpt.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteriaOpt.FldShortColumn.ColumnName), FldShort.ToString())
            Me.daCriteriaOpt.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteriaOpt.IDApplicationColumn.ColumnName), Application)

        ElseIf typSel = eTypSelCriteriaOpt.idRam Then
            Dim arrCriteriasOpt() As dsAdmin.tblCriteriaOptRow = sqlAdmin.dsAllAdmin.tblCriteriaOpt.Select(ds.tblCriteriaOpt.FldShortColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblCriteriaOpt.IDApplicationColumn.ColumnName + "='" + Application + "'")
            Return arrCriteriasOpt

        Else
            Throw New Exception("sqlAdmin.getCriteriasOpt: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daCriteriaOpt.Fill(ds.tblCriteriaOpt)
    End Function

    Public Function getRelationsship(ByVal ds As dsAdmin, ByVal typSel As eTypSelRelationship,
                             ByVal FldShort As String,
                             ByVal IDApplication As String, ByVal IDKey As String) As dsAdmin.tblRelationshipRow()

        Me.daRelationship.SelectCommand.CommandText = Me.sel_daSelRelationship
        core.dbBase.setConnection(Me.daRelationship)
        Me.daRelationship.SelectCommand.Parameters.Clear()

        If typSel = eTypSelRelationship.all Then                                                    'lth   IDApplicationParent - IDApplicationChild fehlt noch!           
            If FldShort <> "" Then
                Dim sWhereSearch As String = ""
                sWhereSearch = ds.tblRelationship.FldShortParentColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd + sqlTxt.or + ds.tblRelationship.IDApplicationParentColumn.ColumnName + sqlTxt.likePerc + FldShort + sqlTxt.likePercEnd
                Me.daRelationship.SelectCommand.CommandText += sqlTxt.where + sWhereSearch
            End If
            Me.daRelationship.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblRelationship.FldShortParentColumn.ColumnName + sqlTxt.asc + ""

        ElseIf typSel = eTypSelRelationship.id Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblRelationship.FldShortParentColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblRelationship.IDApplicationParentColumn.ColumnName)
            Me.daRelationship.SelectCommand.CommandText += sWhere
            Me.daRelationship.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblRelationship.FldShortParentColumn.ColumnName), FldShort.ToString())
            Me.daRelationship.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblRelationship.IDApplicationParentColumn.ColumnName), IDApplication)

        ElseIf typSel = eTypSelRelationship.idRam Then
            Dim arrRelationsship() As dsAdmin.tblRelationshipRow = sqlAdmin.dsAllAdmin.tblRelationship.Select(ds.tblRelationship.FldShortParentColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + IDApplication + "'", ds.tblRelationship.SortColumn.ColumnName + sqlTxt.asc)
            Return arrRelationsship

        ElseIf typSel = eTypSelRelationship.idRamAllChild Then
            Dim arrRelationsship() As dsAdmin.tblRelationshipRow = sqlAdmin.dsAllAdmin.tblRelationship.Select(ds.tblRelationship.FldShortChildColumn.ColumnName + "='" + FldShort + "' " + sqlTxt.and + ds.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + IDApplication + "'", ds.tblRelationship.SortColumn.ColumnName + sqlTxt.asc)
            Return arrRelationsship

        ElseIf typSel = eTypSelRelationship.IDRamAllGroup Then
            Dim sWhere As String = ds.tblRelationship.IDKeyColumn.ColumnName + " like '%" + IDKey.Trim() + "%' "
            Dim arrRelationsship() As dsAdmin.tblRelationshipRow = sqlAdmin.dsAllAdmin.tblRelationship.Select(sWhere, ds.tblRelationship.SortColumn.ColumnName + sqlTxt.asc)
            Return arrRelationsship

        Else
            Throw New Exception("sqlAdmin.getRelationsship: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daRelationship.Fill(ds.tblRelationship)
    End Function

    Public Function getQueriesDef(ByVal ID As Integer, ByVal ds As dsAdmin, ByVal typSel As eTypSelQueryDef,
                                   ByVal typQueryDef As qs2.core.Enums.eTypQueryDef,
                                   ByVal IDParticipant As String, ByVal IDApplication As String) As Boolean
        Try


            Me.daQueriesDef.SelectCommand.CommandText = Me.sel_daSelQueriesDef
            core.dbBase.setConnection(Me.daQueriesDef)
            Me.daQueriesDef.SelectCommand.Parameters.Clear()

            If typSel = eTypSelQueryDef.typ Then
                Me.daQueriesDef.SelectCommand.CommandText += sqlTxt.where + sqlTxt.getColWhere(ds.tblQueriesDef.IDSelListColumn.ColumnName) +
                                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblQueriesDef.TypColumn.ColumnName) +
                                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblQueriesDef.ApplicationOwnColumn.ColumnName) +
                                                         sqlTxt.and + sqlTxt.getColWhere(ds.tblQueriesDef.ParticipantOwnColumn.ColumnName)
                Dim orderBy As String = sqlTxt.orderBy + ds.tblQueriesDef.SortColumn.ColumnName + sqlTxt.asc

                Me.daQueriesDef.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblQueriesDef.IDSelListColumn.ColumnName), ID)
                Me.daQueriesDef.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblQueriesDef.TypColumn.ColumnName), typQueryDef.ToString())
                Me.daQueriesDef.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblQueriesDef.ApplicationOwnColumn.ColumnName), IDApplication.ToString())
                Me.daQueriesDef.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblQueriesDef.ParticipantOwnColumn.ColumnName), IDParticipant.ToString())

                Me.daQueriesDef.SelectCommand.CommandText += orderBy

            ElseIf typSel = eTypSelQueryDef.IDSelList Then
                Me.daQueriesDef.SelectCommand.CommandText += sqlTxt.where + " IDSelList=" + ID.ToString() + " order by Sort asc "
            Else
                Throw New Exception("sqlAdmin.getQueriesDef: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daQueriesDef.Fill(ds.tblQueriesDef)
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getQueriesDef: " + ex.ToString())
        End Try
    End Function

    Public Function addRowQueriesDef(ByVal tblQueriesDef As qs2.core.vb.dsAdmin.tblQueriesDefDataTable) As qs2.core.vb.dsAdmin.tblQueriesDefRow
        Try
            Dim rNew As qs2.core.vb.dsAdmin.tblQueriesDefRow = tblQueriesDef.NewtblQueriesDefRow
            Me.addRowQueriesDef2(rNew)
            tblQueriesDef.Rows.InsertAt(rNew, 0)
            Return rNew

        Catch ex As Exception
            Throw New Exception("sqlAdmin.addRowQueriesDef: " + ex.ToString())
        End Try
    End Function

    Public Sub addRowQueriesDef2(ByRef rNew As qs2.core.vb.dsAdmin.tblQueriesDefRow)

        rNew.IDGuid = System.Guid.NewGuid()
        rNew.QryColumn = ""
        rNew.QryTable = ""
        rNew.SetCriteriaFldShortNull()
        rNew.SetCriteriaApplicationNull()
        rNew.IsSQLServerField = False
        rNew.Typ = ""
        rNew.Condition = ""
        rNew.ValueMin = ""
        rNew.UserInput = False
        rNew.Label = ""
        rNew.Max = ""
        rNew.ValueMinIDRes = ""
        rNew.MaxIDRes = ""
        rNew.Combination = ""
        rNew.CombinationEnd = ""
        rNew.Sort = 0
        rNew.ApplicationOwn = ""
        rNew.ParticipantOwn = ""
        rNew.SetControlTypeNull()
        rNew.FunctionPar = False
        rNew.freeSql = ""
        rNew.IDSelList = qs2.core.generic.idMinus
        rNew.All = False
        rNew.SpecialDefinition = ""
        rNew.ComboAsDropDown = False
        rNew.ComboAsDropDownCondition = ""
        rNew.SpecialDefinitionMax = ""
        rNew.Chapter = ""
        rNew.Chapters = ""
        rNew.ChaptersDone = False
        rNew.Placeholder = False
    End Sub

    Public Sub getNextIDSelListGeneric(ByRef newIDSelList As Integer, ByRef NextIDOwnStr As String, ByRef NextIDOwnInt As Integer,
                                            ByRef IDGroup As Integer)
        Try
            If NextIDOwnInt < 0 Then
                Throw New Exception("sqlAdmin.getNextIDSelListGeneric:NextIDOwnInt < 0 for new SelListEntry!")
            End If

            newIDSelList = System.Convert.ToInt32(IDGroup.ToString() + NextIDOwnInt.ToString().PadLeft(4, "0").ToString())

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getNextIDSelListGeneric: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function getNextIDSelListGroupGeneric() As Integer
        Try
            Dim nrCircleManuell As Integer = 1000
            Dim nrCircleMaxManuell As Integer = 1999

            Dim dsNextID As New dsAdmin()
            Me.getMaxSelListGroup(dsNextID, eTypSelListGetMaxID.GetMaxIDGeneric, nrCircleManuell, nrCircleMaxManuell)
            If dsNextID.SelListMaxIDs.Rows.Count = 0 Then
                Return 1
            ElseIf dsNextID.SelListMaxIDs.Rows.Count = 1 Then
                Dim rnextIDFound As dsAdmin.SelListMaxIDsRow = dsNextID.SelListMaxIDs.Rows(0)
                If rnextIDFound.IsMaxIDNull() Then
                    Return nrCircleManuell
                Else
                    Return rnextIDFound.MaxID + 1
                End If
            Else
                Throw New Exception("sqlAdmin.getNextIDSelListGeneric: Error dsNextID.SelListMaxIDs.Rows.Count > 1 !")
            End If

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getNextIDSelListGroupGeneric: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getMaxSelListGroup(ByRef ds As dsAdmin, ByRef typSel As eTypSelListGetMaxID, ByRef nrCircleManuell As Integer, ByRef nrCircleMaxManuell As Integer) As dsAdmin.tblSelListEntriesRow()

        Me.daMaxSelListGroupID.SelectCommand.CommandText = Me.sel_daMaxSelListGroupID
        core.dbBase.setConnection(Me.daMaxSelListGroupID)
        Me.daMaxSelListGroupID.SelectCommand.Parameters.Clear()
        If typSel = eTypSelListGetMaxID.GetMaxIDGeneric Then
            Dim sWhere As String = sqlTxt.where + ds.tblSelListEntries.IDColumn.ColumnName + " >= " + (nrCircleManuell).ToString() + sqlTxt.and +
                                            ds.tblSelListEntries.IDColumn.ColumnName + " <= " + (nrCircleMaxManuell).ToString()
            Me.daMaxSelListGroupID.SelectCommand.CommandText += sWhere
        Else
            Throw New Exception("sqlAdmin.getMaxSelListGroup: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daMaxSelListGroupID.Fill(ds.SelListMaxIDs)
    End Function

End Class
