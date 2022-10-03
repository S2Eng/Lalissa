Public Class sqlAdmin

    Public database As New qs2.core.dbBase
    Public gen As New qs2.core.generic

    Public sel_daAdjust As String = ""
    Public settingAll As String = "all_11110000-9999-0000-0000-000000000000"

    Public sel_daSelListGroup As String = ""
    Public sel_daSelListEntrys As String = ""
    Public sel_daSelListEntrysSort As String = ""
    Public sel_daSelListEntrysObj As String = ""
    Public sel_daSelListEntrysRelGroup As String = ""
    Public sel_daSelCriteria As String = ""
    Public sel_daSelCriteriaOpt As String = ""
    Public sel_daSelRelationship As String = ""
    Public sel_daSelStayAddistions As String = ""
    Public sel_daSelQueriesDef As String = ""
    Public sel_daSelQueryJoinsTemp As String = ""
    Public sel_daSelSideLogic As String = ""
    Public sel_daMaxSelListGroupID As String = ""
    Public sel_daMaxSelListID As String = ""
    Public sel_davSelListEntriesObj As String = ""
    Public sel_GetAllUsersWithRoles As String = ""
    Public sel_GetButtonsForUser As String = ""
    Public sel_GetChaptersAlwaysEditableAllUsers As String = ""
    Public sel_GetCriteriasForUser As String = ""
    Public sel_GetCriteriasUserForUser As String = ""
    Public sel_GetAllUsersWithRights As String = ""
    Public allCriteriasLoaded As Boolean = False

    Public Shared dsAllAdmin As dsAdmin = New dsAdmin()
    Public Shared dsAllAdminAll As dsAdmin = New dsAdmin()
    Public Shared typIDGroup_CompletedChapters As String = "CompletedChapter"
    Public Shared typIDGroup_ProceduresToStay As String = "ProceduresToStay"
    Public Shared groupNameCriterias As String = "CRITERIAS"
    Public Shared ChapterFreeTopBelow As String = "FreeTopBelow"

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

    Public Enum eAdjust
        'client
        applicationAutoStart = 48000
        dirDefault = 48001
        styleUI = 48002

        mainLeft = 48010
        mainTop = 48011
        mainHeigth = 48012
        mainWidth = 48013
        defaultSearchUser = 48014

        'all
        defaultCountryxy = 48020
        LanguageUser = 48021
        EACTS_ExportNumber = 48022

        ControlOpenStayType = 48024
        ControlOpenStayTypeRoles = 48025
        StartTypeStayUI = 48026
        ControlOpenStayTypeIDParticipant = 48027
        ControlOpenStayTypeRolesIDParticipant = 48028
        UploadPrintAllChapters = 48029

        StayUIOpenForm = 48030
    End Enum
    Public Enum eTypSelAdjust
        forClient = 48100
        forUsr = 48101
        all = 48102
        allGrid = 48103
    End Enum
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
        typ = 50004
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
        AllFldShortsUser = 50024
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
        CompletedChaptersStay = 51011
        IDSelListEntryFldShort = 51012
        RAMRightUser = 51016
        IDSelListEntryIDObject = 51017
        IDStay = 51018
        objOnly = 51019
        FldShortOtherChapters = 51020
    End Enum
    Public Enum eDbTypAuswObj
        Usergroups = 51050
        SubSelList = 51051
        Criterias = 51052
        ProceduresToStay = 51053
        Roles = 51054
        Userrights = 51055
        CompletedChapter = 51056
        UserQueries = 51057
        CriteriasUser = 51058
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
    Public Enum eTypSelStayAdditions
        idStay = 51500
        idStayAll = 51501
        idObject = 51502
        idStay2 = 51503
        idStayORIdPatient = 51504
        IDGuid = 51505
    End Enum

    Public Enum eTypSelQueryDef
        typ = 51600
        IDSelList = 51601
    End Enum
    Public Enum eTypSelQueryJoinsTemp
        all = 51700
    End Enum

    Public Enum eTypeSideLogic
        all = 51810
        FldShortApplication = 51811
        IDSelList = 51812
        IDObj = 51813
        Relationship = 51814
    End Enum

    Public Enum eTypeSelvSelListEntriesObj
        All = 0
    End Enum

    Public Shared IDClassificationChapterAlwaysEditable As String = "Type=EditableWhenCompleted;"

    Public Sub initControl()
        Me.sel_daSelListGroup = Me.daSelListGroup.SelectCommand.CommandText
        Me.sel_daSelListEntrys = Me.daSelListEntrys.SelectCommand.CommandText
        Me.sel_daSelListEntrysSort = Me.daSelListEntriesSort.SelectCommand.CommandText
        Me.sel_daSelListEntrysRelGroup = Me.davListEntriesWithGroup.SelectCommand.CommandText
        Me.sel_daSelListEntrysObj = Me.daSelListEntrysObj.SelectCommand.CommandText
        Me.sel_daAdjust = Me.daAdjust.SelectCommand.CommandText
        Me.sel_daSelCriteria = Me.daCriteria.SelectCommand.CommandText
        Me.sel_daSelCriteriaOpt = Me.daCriteriaOpt.SelectCommand.CommandText
        Me.sel_daSelRelationship = Me.daRelationship.SelectCommand.CommandText
        Me.sel_daSelStayAddistions = Me.daStayAdditions.SelectCommand.CommandText
        Me.sel_daSelQueriesDef = Me.daQueriesDef.SelectCommand.CommandText
        Me.sel_daSelQueryJoinsTemp = Me.daQueryJoinsTemp.SelectCommand.CommandText
        Me.sel_daSelSideLogic = Me.daSideLogic.SelectCommand.CommandText
        Me.sel_daMaxSelListGroupID = Me.daMaxSelListGroupID.SelectCommand.CommandText
        Me.sel_daMaxSelListID = Me.daMaxSelListID.SelectCommand.CommandText
        Me.sel_davSelListEntriesObj = Me.davSelListEntriesObj.SelectCommand.CommandText
        Me.sel_GetAllUsersWithRoles = Me.daGetAllUsersWithRoles.SelectCommand.CommandText
        Me.sel_GetButtonsForUser = Me.daGetButtonsForUser.SelectCommand.CommandText
        Me.sel_GetChaptersAlwaysEditableAllUsers = Me.daGetChaptersAlwaysEditableAllUsers.SelectCommand.CommandText
        Me.sel_GetCriteriasForUser = Me.daGetCriteriasForUser.SelectCommand.CommandText
        Me.sel_GetCriteriasUserForUser = Me.daGetCriteriasUserForUser.SelectCommand.CommandText
        Me.sel_GetAllUsersWithRights = Me.daGetAllUsersWithRights.SelectCommand.CommandText
    End Sub


    Public Sub loadAllSelListEntries(ClearDataTable As Boolean, Optional AddGroup As Boolean = True)
        Try
            'umschreiben - nicht alle löschen >> nut die wo in Stay-UI eine SelList hinzugefügt wurde >> nur die eine SelList nachladen (Alles clear weggeben)
            If ClearDataTable Then
                sqlAdmin.dsAllAdmin.tblSelListEntries.Clear()
            End If
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.getSelListEntrysAll(Parameters, "", sqlAdmin.dsAllAdmin, eTypAuswahlList.all, "", license.doLicense.eApp.ALL.ToString())
            Me.getSelListEntrysSort(-999, "", Me.dsAllAdmin, eTypSelListSort.All, "")

            If ClearDataTable Then
                Dim b As New businessFramework()
                b.autoGenerateObjectFields(False, False, AddGroup)
                b.autoGenerateObjectFields(True, False, AddGroup)
                b.autoGenerateObjectFields(False, True, AddGroup)
            End If

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
        Me.allCriteriasLoaded = False

        If Not ENV.VSDesignerMode Then
            Me.getButtonsForUser(sqlAdmin.dsAllAdmin, eTypAuswahlList.all)
            Me.getChaptersAlwaysEditableAllUsers(sqlAdmin.dsAllAdmin, eTypAuswahlList.all)
        End If
        Me.getCriterias(sqlAdmin.dsAllAdmin, eTypSelCriteria.search, "", license.doLicense.eApp.ALL.ToString(), False, False, False, "", "", False)
        Me.getSelListEntrysObj(-999, eDbTypAuswObj.Criterias, "", sqlAdmin.dsAllAdmin, eTypAuswahlObj.AllSelListObjects, "")
        Me.getSelListEntrysRelGroup("", "", "", sqlAdmin.dsAllAdmin, eTypAuswahlList.all)
        Me.getCriteriasOpt(sqlAdmin.dsAllAdmin, eTypSelCriteriaOpt.all, "", license.doLicense.eApp.ALL.ToString())
        Me.getRelationsship(sqlAdmin.dsAllAdmin, eTypSelRelationship.all, "", license.doLicense.eApp.ALL.ToString(), "")
        Me.getSelListGroup(sqlAdmin.dsAllAdmin, eTypSelGruppen.all, "", "", license.doLicense.eApp.ALL.ToString())
        Me.loadAllSelListEntries(ClearDataTableSelListEntries)
        Me.getSideLogic(sqlAdmin.dsAllAdmin, eTypeSideLogic.all, -999, "", "")
        qs2.core.vb.sqlObjects.loadAllData()

        Dim arrSelListEntrieiesGroupUsers() As dsAdmin.tblSelListGroupRow = sqlAdmin.dsAllAdmin.tblSelListGroup.Select(sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='Users'", "")
        Dim arrAllUsers() As dsObjects.tblObjectRow = sqlObjects.dsAllUsers.tblObject.Select(sqlObjects.dsAllUsers.tblObject.IsUserColumn.ColumnName + "=1", sqlObjects.dsAllUsers.tblObject.NameCombinationColumn.ColumnName + " asc")
        For Each rObject As dsObjects.tblObjectRow In arrAllUsers
            Dim rNewSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getNewRowSelList(sqlAdmin.dsAllAdmin, False)
            rNewSelListEntry.ID = rObject.ID
            rNewSelListEntry.IDRessource = rObject.NameCombination
            rNewSelListEntry.IDGuid = rObject.IDGuid
            rNewSelListEntry.IDOwnInt = rObject.ID
            rNewSelListEntry._Private = rObject.IsUser
            rNewSelListEntry.Extern = rObject.Active
            rNewSelListEntry.IDOwnStr = rObject.UserName
            rNewSelListEntry.IDGroup = arrSelListEntrieiesGroupUsers(0).ID
        Next

        If ClearDataTableSelListEntries Then
            Dim b As New core.vb.businessFramework()
            b.autoGenerateObjectFields(False, False)
            b.autoGenerateObjectFields(True, False)
            b.autoGenerateObjectFields(False, True)
        End If
        Me.allCriteriasLoaded = True
    End Sub

    Public Function getAdjustRow(UsrToLoad As String, ByVal setting As eAdjust, ByVal typSel As eTypSelAdjust, IDParticipant As String) As dsAdmin.tblAdjustRow

        Dim ds As New dsAdmin
        Me.getAdjust(UsrToLoad, setting, ds, typSel, IDParticipant)
        If ds.tblAdjust.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblAdjust.Rows.Count = 1 Then
            Return ds.tblAdjust.Rows(0)
        ElseIf ds.tblAdjust.Rows.Count > 1 Then
            Throw New Exception("getAdjustRow.id: More than one Row for setting '" + setting.ToString() + "' found!")
            Return Nothing
        Else
            Throw New Exception("sqlAdmin.getAdjustRow: TypSel '" + typSel.ToString() + "' is wrong!")
        End If
    End Function
    Public Function getAdjust(UsrToLoad As String, ByVal setting As eAdjust, ByRef ds As dsAdmin, ByVal typSel As eTypSelAdjust, IDParticipant As String) As Boolean

        Me.daAdjust.SelectCommand.CommandText = Me.sel_daAdjust
        Me.database.setConnection(Me.daAdjust)
        Me.daAdjust.SelectCommand.Parameters.Clear()

        If typSel = eTypSelAdjust.forClient Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdjust.settingColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblAdjust.clientColumn.ColumnName) + sqlTxt.and + ds.tblAdjust.usrSettingColumn.ColumnName + " = 0 "
            Me.daAdjust.SelectCommand.CommandText += sWhere
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.settingColumn.ColumnName), setting.ToString())
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.clientColumn.ColumnName), My.Computer.Name)

        ElseIf typSel = eTypSelAdjust.forUsr Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdjust.settingColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblAdjust.clientColumn.ColumnName) + sqlTxt.and + ds.tblAdjust.usrSettingColumn.ColumnName + " = 1 "
            Me.daAdjust.SelectCommand.CommandText += sWhere
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.settingColumn.ColumnName), setting.ToString())
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.clientColumn.ColumnName), UsrToLoad.Trim())

        ElseIf typSel = eTypSelAdjust.all Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdjust.settingColumn.ColumnName) + sqlTxt.and + ds.tblAdjust.clientColumn.ColumnName + "='" + Me.settingAll + "' " + sqlTxt.and + ds.tblAdjust.usrSettingColumn.ColumnName + " = 0 "
            Me.daAdjust.SelectCommand.CommandText += sWhere
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.settingColumn.ColumnName), setting.ToString())

        ElseIf typSel = eTypSelAdjust.allGrid Then
            Dim sWhere As String = sqlTxt.where + " client like '" + typSel.ToString() + "%'" + sqlTxt.and + ds.tblAdjust.usrSettingColumn.ColumnName + " = 0 "
            'Dim sWhere As String = sqlTxt.where + " setting='" + setting.ToString() + "' " + sqlTxt.and + " client like '" + typSel.ToString() + "%'" + sqlTxt.and + ds.tblAdjust.usrSettingColumn.ColumnName + " = 0 "
            Me.daAdjust.SelectCommand.CommandText += sWhere
            Me.daAdjust.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdjust.settingColumn.ColumnName), setting.ToString())

        Else
            Throw New Exception("sqlAdmin.getAdjust: TypSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daAdjust.Fill(ds.tblAdjust)
        Return True
    End Function
    Public Function deleteAdjustment(ByVal type As String) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblAdjust.TableName + sqlTxt.where + " setting like '" + type.Trim() + "%' "
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteAdjustment: " + ex.ToString())
        End Try
    End Function

    Public Function newRowAdjustment(ds As dsAdmin) As dsAdmin.tblAdjustRow
        Try
            Dim rNew As dsAdmin.tblAdjustRow = ds.tblAdjust.NewRow()
            rNew.setting = ""
            rNew.client = ""
            rNew.usrSetting = False
            rNew.type = ""
            rNew.str = ""
            rNew.dbl = 0
            rNew.bool = False
            rNew.SetdatNull()
            rNew.SetbytNull()

            ds.tblAdjust.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("newRowAdjustment: " + ex.ToString())
        End Try
    End Function

    Public Function storeVal(ByVal rAdjust As dsAdmin.tblAdjustRow, ByVal val As Object,
                         Optional ByVal bytes() As Byte = Nothing) As String

        If bytes Is Nothing Then
            Dim bool As Boolean = False
            Dim int32 As Int32 = 0
            Dim int64 As Int64 = 0
            Dim dbl As Double = 0
            Dim dec As Decimal = 0
            Dim int As Decimal = 0
            Dim str As String = ""
            Dim guid As System.Guid = System.Guid.NewGuid()
            Dim dat As Date
            Dim datTim As DateTime


            Dim typ As System.Type
            typ = val.GetType
            If typ.ToString = bool.GetType.ToString() Then
                rAdjust.str = ""
                rAdjust.dbl = 0
                rAdjust.bool = val
                rAdjust.SetdatNull()
                rAdjust.SetbytNull()

            ElseIf typ.ToString = int.GetType.ToString() Or typ.ToString = int32.GetType.ToString() Or typ.ToString = int64.GetType.ToString() Or typ.ToString = dbl.GetType.ToString() Or typ.ToString = dec.GetType.ToString() Then
                rAdjust.str = ""
                rAdjust.dbl = val
                rAdjust.bool = False
                rAdjust.SetdatNull()
                rAdjust.SetbytNull()

            ElseIf typ.ToString = str.GetType.ToString() Or typ.ToString = guid.GetType.ToString() Then
                rAdjust.str = val.ToString()
                rAdjust.dbl = 0
                rAdjust.bool = False
                rAdjust.SetdatNull()
                rAdjust.SetbytNull()

            ElseIf typ.ToString = dat.GetType.ToString() Or typ.ToString = datTim.GetType.ToString() Then
                rAdjust.str = ""
                rAdjust.dbl = 0
                rAdjust.bool = False
                If val = Nothing Then
                    rAdjust.SetdatNull()
                Else
                    rAdjust.dat = val
                End If
                rAdjust.SetbytNull()

            Else
                Throw New Exception("sqlAdmin.storeVal: TypSel '" + typ.ToString() + "' is wrong!")
            End If
            rAdjust.type = typ.ToString

        Else
            rAdjust.str = ""
            rAdjust.dbl = 0
            rAdjust.bool = False
            rAdjust.SetdatNull()
            rAdjust.byt = bytes

            rAdjust.type = qs2.core.generic.typBytes
        End If

    End Function
    Public Function getVal(ByVal rAdjust As dsAdmin.tblAdjustRow, ByVal bytes() As Byte) As Object
        Dim bool As Boolean = False
        Dim int32 As Int32 = 0
        Dim int64 As Int64 = 0
        Dim dbl As Double = 0
        Dim dec As Decimal = 0
        Dim int As Decimal = 0
        Dim str As String = ""
        Dim guid As System.Guid = System.Guid.NewGuid()
        Dim dat As Date
        Dim datTim As DateTime


        If rAdjust.type = bool.GetType.ToString() Then
            Return rAdjust.bool

        ElseIf rAdjust.type.ToString = int.GetType.ToString() Or rAdjust.type.ToString = int32.GetType.ToString() Or
                rAdjust.type.ToString = int64.GetType.ToString() Or rAdjust.type.ToString = dbl.GetType.ToString() Or
                rAdjust.type.ToString = dec.GetType.ToString() Then
            Return rAdjust.dbl

        ElseIf rAdjust.type.ToString = str.GetType.ToString() Or rAdjust.type.ToString = guid.GetType.ToString() Then
            Return rAdjust.str

        ElseIf rAdjust.type.ToString = dat.GetType.ToString() Or rAdjust.type.ToString = datTim.GetType.ToString() Then
            If rAdjust.IsdatNull() Then
                Return Nothing
            Else
                Return rAdjust.dat
            End If

        ElseIf rAdjust.type = qs2.core.generic.typBytes Then
            If rAdjust.IsbytNull() Then
                bytes = Nothing
            Else
                bytes = rAdjust.byt
            End If

        Else
            Throw New Exception("sqlAdmin.getVal: TypSel '" + rAdjust.type.ToString() + "' is wrong!")
        End If
    End Function

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

        'No longer up to four SQL-Queries for one SelListGroupRow
        'Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelListGroupRow(IDGroup, IDParticipant, IDApplication)
        'If rGrp Is Nothing Then
        '    rGrp = Me.getSelListGroupRow(IDGroup, IDParticipant, qs2.core.license.doLicense.eApp.ALL.ToString())
        '    If rGrp Is Nothing Then
        '        rGrp = Me.getSelListGroupRow(IDGroup, qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication)
        '        If rGrp Is Nothing Then
        '            rGrp = Me.getSelListGroupRow(IDGroup, qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.eApp.ALL.ToString())
        '            If rGrp Is Nothing Then
        '                Parameters.GroupNotFoundInAnyApplication = True
        '                If doExecptIfNotFound Then
        '                    Throw New Exception("getSelListGroupRow_PartApp: No Group-Entry for IDGroup '" + IDGroup.ToString() + "' exists in table tblSelListGroup !")
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
        'Return rGrp
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
        database.setConnection(Me.daSelListGroup)
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
                                        Optional ByVal typ As String = "",
                                        Optional ByVal IDOwnInt As Integer = 0,
                                        Optional ByVal IDOwnStr As String = "",
                                        Optional ByVal ID As Integer = 0) As dsAdmin.tblSelListEntriesRow

        Dim ds As New dsAdmin
        Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
        Me.getSelListEntrysAll(Parameters, IDGroup, ds, typSel, qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication, typ, IDOwnInt, IDOwnStr, ID)
        If ds.tblSelListEntries.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblSelListEntries.Rows.Count = 1 Then
            Return ds.tblSelListEntries.Rows(0)
        ElseIf ds.tblSelListEntries.Rows.Count > 1 Then
            Throw New Exception("getSelListEntrysRow.id: More than one Row for idNr '" + IDOwnInt.ToString() + "' found!")
            Return Nothing
        End If
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
        If ds.tblSelListEntries.Rows.Count = 0 Then
            'Me.getSelListEntrys(IDGroup, qs2.core.vb.actUsr.rParticipant.IDParticipant, qs2.core.license.doLicense.AppALL, ds, typSel, typ, IDOwnInt, IDOwnStr)
            'If ds.tblSelListEntrys.Rows.Count = 0 Then
            '    Me.getSelListEntrys(IDGroup, qs2.core.license.doLicense.AppALL, qs2.core.vb.actUsr.rApplication.IDApplication, ds, typSel, typ, IDOwnInt, IDOwnStr)
            '    If ds.tblSelListEntrys.Rows.Count = 0 Then
            '        Me.getSelListEntrys(IDGroup, qs2.core.license.doLicense.AppALL, qs2.core.license.doLicense.AppALL, ds, typSel, typ, IDOwnInt, IDOwnStr)
            '        If ds.tblSelListEntrys.Rows.Count = 0 Then
            'Throw New Exception("getSelListEntrysAll: No SelListEntrys for IDGroup '" + IDGroup.ToString() + "' exists in table SelListEntrys !")
            '        End If
            '    End If
            'End If
        End If
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
            database.setConnection(Me.daSelListEntrys)
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
                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        sWhere += " or IDParticipant='ALL' or IDParticipant = ''"
                    End If
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

                    'sWhere += sqlTxt.or + sqlTxt.ClampRight + ds.tblSelListEntries.CreatedUserColumn.ColumnName + sqlTxt.notEquals + "'" + qs2.core.vb.actUsr.rUsr.UserName.Trim() + "'"
                    'sWhere += sqlTxt.and + ds.tblSelListEntries.PrivateColumn.ColumnName + sqlTxt.equals + "0" + sqlTxt.ClampLeft + sqlTxt.ClampLeft

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
    Public Function deleteSelListEntryObject_IDObject(ByVal IDObject As Integer) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + " IDObject='" + IDObject.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("sqlAdmin.deleteSelListEntryObject_IDObject: " + ex.ToString())
        End Try
    End Function
    Public Function deleteSelListEntryObject_IDObjectGuid(ByVal IDObjectGuid As Guid) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + " IDObjectGuid='" + IDObjectGuid.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.deleteSelListEntryObject_IDObjectGuid: " + ex.ToString())
        End Try
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

    Public Function updateStayAdditionsIDObject(ByVal IDObjectGuidNew As Guid, ByVal IDObjectGuidOld As Guid) As Boolean
        Try
            Dim ds As New dsAdmin
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.Parameters.Clear()
            cmd.CommandText = "Update" + qs2.core.dbBase.dbSchema + ds.tblStayAdditions.TableName + " set IDObject='" + IDObjectGuidNew.ToString() + "' where IDObject='" + IDObjectGuidOld.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.updateStayAdditionsIDObject: " + ex.ToString())
        End Try
    End Function

    Public Shared Function deleteSelListEntryAllQryAdminxy(ByVal IDOwnInt As Integer, ByVal Application As String) As Boolean

        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblQueriesDef.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblQueriesDef.IDSelListColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(ds.tblQueriesDef.ApplicationOwnColumn.ColumnName)
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblQueriesDef.IDSelListColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblQueriesDef.IDSelListColumn.ColumnName))).Value = IDOwnInt
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblQueriesDef.ApplicationOwnColumn.ColumnName), System.Data.SqlDbType.VarChar, 30, sqlTxt.getColPar(ds.tblQueriesDef.ApplicationOwnColumn.ColumnName))).Value = Application

        cmd.ExecuteNonQuery()
        Return True

    End Function
    Public Function getSelListEntrysRelGroup(ByVal IDGroup As String,
                                      ByVal IDParticipant As String, ByVal IDApplication As String,
                                      ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList) As dsAdmin.vListEntriesWithGroupRow()

        Me.davListEntriesWithGroup.SelectCommand.CommandText = Me.sel_daSelListEntrysRelGroup
        database.setConnection(Me.davListEntriesWithGroup)
        Me.davListEntriesWithGroup.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahlList.group Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName)
            Me.davListEntriesWithGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName), IDGroup.ToString())
            If IDApplication <> license.doLicense.eApp.ALL.ToString() Then
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName)
                Me.davListEntriesWithGroup.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName), IDApplication.ToString())
            End If
            Me.davListEntriesWithGroup.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName + sqlTxt.asc + "," + ds.vListEntriesWithGroup.s_IDRessourceColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypAuswahlList.all Then
            Dim str As String = ""

        ElseIf typSel = eTypAuswahlList.IDGroupStrAppRam Then
            Dim sWhere As String = ds.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName + "='" + IDGroup + "'" + sqlTxt.and +
                                    ds.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName + "='" + IDApplication + "'"
            Dim arrSelListWithGroup() As dsAdmin.vListEntriesWithGroupRow = sqlAdmin.dsAllAdmin.vListEntriesWithGroup.Select(sWhere)
            Return arrSelListWithGroup

        Else
            Throw New Exception("sqlAdmin.getSelListEntrysRelGroup: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.davListEntriesWithGroup.Fill(ds.vListEntriesWithGroup)
        Return Nothing

    End Function


    Public Function getSelListEntrysSort(ID As Integer, IDParticipant As String,
                                           ds As dsAdmin, typeSel As eTypSelListSort, sWhere As String) As dsAdmin.tblSelListEntriesSortRow()
        Try
            Me.daSelListEntriesSort.SelectCommand.CommandText = Me.sel_daSelListEntrysSort
            database.setConnection(Me.daSelListEntriesSort)
            Me.daSelListEntriesSort.SelectCommand.Parameters.Clear()

            If typeSel = eTypSelListSort.IDSelListIDParticipantIDRam Then
                'Dim sWhereTmp As String = ds.tblSelListEntriesSort.IDSelListEntryColumn.ColumnName + "=" + ID.ToString() + " and " + ds.tblSelListEntriesSort.IDParticipantColumn.ColumnName + "='" + IDParticipant.Trim() + "'"
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
            database.setConnection(Me.daSelListEntrysObj)
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
                If IDGuid Is Nothing Then
                    Dim str As String = ""
                End If
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

                'Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName) + sqlTxt.and +
                '                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                '                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.FldShortColumn.ColumnName) + sqlTxt.and +
                '                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName) + sqlTxt.and +
                '                        sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDClassificationColumn.ColumnName)
                Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), ID)
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), typDB.ToString())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.FldShortColumn.ColumnName), FldShort.Trim())
                Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationColumn.ColumnName), IDApplication.Trim())
                'Me.daSelListEntrysObj.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDClassificationColumn.ColumnName), "Application=" + Group.Trim())

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

    Public Function deleteSelListEntryObj(ByVal IDStay As Integer, IDParticipantStay As String, IDApplicationStay As String, typIDGroup As String) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), System.Data.SqlDbType.NVarChar, 50, sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName))).Value = typIDGroup
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName))).Value = IDStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 150, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName))).Value = IDParticipantStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 30, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName))).Value = IDApplicationStay

        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function sys_deleteSelListEntryCriterias(IDApplication As String) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = " delete from qs2.tblSelListEntriesObj where typIDGroup='Criterias' and " +
                            " IDSelListEntry in (Select qs2.tblSelListEntries.ID from qs2.tblSelListEntries, qs2.tblSelListGroup " +
                            " where qs2.tblSelListEntries.IDGroup=qs2.tblSelListGroup.ID And qs2.tblSelListGroup.IDApplication='" + IDApplication.Trim() + "') "

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function deleteSelListEntryObj(ByVal IDStay As Integer, IDParticipantStay As String, IDApplicationStay As String, typIDGroup As String, IDSelListEntry As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and + _
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and + _
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and + _
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName) + sqlTxt.and + _
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName)

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), System.Data.SqlDbType.NVarChar, 50, sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName))).Value = typIDGroup
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName))).Value = IDStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 150, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName))).Value = IDParticipantStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 30, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName))).Value = IDApplicationStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName))).Value = IDSelListEntry

        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function updateSelListEntryObjCreated(ByVal IDGuid As Guid, dCreated As Date) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = " update qs2.tblSelListEntriesObj set Created=@Created, Modified=@Modified where IDGuid='" + IDGuid.ToString() + "' "

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created")).Value = dCreated
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modified", System.Data.SqlDbType.DateTime, 0, "Modified")).Value = dCreated

        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function deleteSelListEntryObjOtherChapters(FldShort As String, IDApplicationCrit As String, typIDGroup As String, IDSelListEntryNot As Integer,
                                                       dat As DateTime, IDApplicationChapter As String) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = " delete from qs2.tblSelListEntriesObj where " +
                            " IDSelListEntry<>'" + IDSelListEntryNot.ToString() + "' and typIDGroup='" + typIDGroup.Trim() + "' and " +
                            " IDApplication='" + IDApplicationCrit.Trim() + "' and FldShort='" + FldShort.Trim() + "' and Created<>@Created and " +
                            " IDSelListEntry in (Select qs2.tblSelListEntries.ID from qs2.tblSelListEntries, qs2.tblSelListGroup " +
                            " where qs2.tblSelListEntries.IDGroup=qs2.tblSelListGroup.ID And qs2.tblSelListGroup.IDApplication='" + IDApplicationChapter.Trim() + "') "

        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created")).Value = dat

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function deleteSelListEntryObj(ByVal IDGuid As System.Guid) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDGuidColumn.ColumnName)
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDGuidColumn.ColumnName), System.Data.SqlDbType.UniqueIdentifier, 16, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDGuidColumn.ColumnName))).Value = IDGuid
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function deleteStayByID(ByVal IDStay As Integer, IDParticipantStay As String, IDApplication As String) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDStayColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName)

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDStayColumn.ColumnName))).Value = IDStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 150, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDParticipantStayColumn.ColumnName))).Value = IDParticipantStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 30, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName))).Value = IDApplication

        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function deleteSelListEntryObj(IDApplicationStay As String, typIDGroup As String, IDSelListEntry As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblSelListEntriesObj.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName) + sqlTxt.and +
                            sqlTxt.getColWhere(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName)

        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName), System.Data.SqlDbType.NVarChar, 50, sqlTxt.getColPar(ds.tblSelListEntriesObj.typIDGroupColumn.ColumnName))).Value = typIDGroup
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName), System.Data.SqlDbType.NVarChar, 30, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDApplicationStayColumn.ColumnName))).Value = IDApplicationStay
        cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName))).Value = IDSelListEntry

        cmd.ExecuteNonQuery()
        Return True
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

    Public Function getSelListObjDoubledSelLists(ByRef ds As dsAdmin, ByRef IDSelListEntry As Integer, ByRef IDSelListEntrySublist As Integer, ByRef typIDGroup As String) As Boolean
        Try
            Me.daSelListEntrysObj.SelectCommand.CommandText = Me.sel_daSelListEntrysObj
            database.setConnection(Me.daSelListEntrysObj)
            Me.daSelListEntrysObj.SelectCommand.Parameters.Clear()

            Dim sWhere As String = ""
            sWhere = " where IDSelListEntry=" + IDSelListEntry.ToString() + " and IDSelListEntrySublist=" + IDSelListEntrySublist.ToString() + " and FldShort is null and IDApplication is null and typIDGroup='" + typIDGroup.Trim() + "' and " +
                        "IDObject is null and IDStay is null and IDApplicationStay is null and IDParticipantStay is null and (IDParticipant='' or IDParticipant='ALL') "

            Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
            Me.daSelListEntrysObj.Fill(ds.tblSelListEntriesObj)
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getSelListObjDoubledSelLists: " + ex.ToString())
        End Try
    End Function
    Public Function getSelListObjDoubledFldShorts(ByRef ds As dsAdmin, ByRef IDSelListEntry As Integer, ByRef FldShort As String, IDApplication As String, ByRef typIDGroup As String) As Boolean
        Try
            Me.daSelListEntrysObj.SelectCommand.CommandText = Me.sel_daSelListEntrysObj
            database.setConnection(Me.daSelListEntrysObj)
            Me.daSelListEntrysObj.SelectCommand.Parameters.Clear()

            Dim sWhere As String = ""
            sWhere = " where IDSelListEntry=" + IDSelListEntry.ToString() + " and IDSelListEntrySublist is null and FldShort='" + FldShort.Trim() + "' and IDApplication='" + IDApplication.Trim() + "' and typIDGroup='" + typIDGroup.Trim() + "' and " +
                        "IDObject is null and IDStay is null and IDApplicationStay is null and IDParticipantStay is null and (IDParticipant='' or IDParticipant='ALL') "

            Me.daSelListEntrysObj.SelectCommand.CommandText += sWhere
            Me.daSelListEntrysObj.Fill(ds.tblSelListEntriesObj)
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getSelListObjDoubledSelLists: " + ex.ToString())
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

            'For Each r As dsAdmin.tblSelListEntriesRow In dsAdmin1.tblSelListEntries
            '    Dim resFound As String = qs2.core.language.sqlLanguage.getRes(r.IDRessource, qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication)
            '    If resFound.Trim() = "" Then
            '        resFound = r.IDRessource
            '    End If
            'Next

            'Dim rSelListGroup As dsAdmin.tblSelListGroupRow = sqlAdmin1.getSelListGroupRow(gruppe.Trim(), "", "")
            'Dim arrSelLists As dsAdmin.tblSelListEntriesRow() = Nothing
            'If rSelListGroup.SortColumn.Trim() <> "" Then
            '    arrSelLists = dsAdmin1.tblSelListEntries.Select("", dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName)
            'Else
            '    arrSelLists = dsAdmin1.tblSelListEntries.Select("", rSelListGroup.SortColumn.Trim())
            'End If

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
    Public Function addRowSelListSmall(ByVal dsHelper1 As dsHelper) As dsHelper.SelListSmallRow
        Dim rNew As dsHelper.SelListSmallRow = dsHelper1.SelListSmall.NewRow()
        rNew.ID = System.Guid.NewGuid()
        rNew.IDOwnInt = -999
        rNew.IDOwnStr = ""
        rNew.SelList = ""
        rNew.IDSelList = -999
        rNew.IDGroupStr = ""
        rNew.Application = ""

        dsHelper1.SelListSmall.Rows.Add(rNew)
        Return rNew

    End Function
    Public Function addRowSelListSmall1(ByVal dsHelper1 As dsHelper) As dsHelper.SelListSmall1Row
        Dim rNew As dsHelper.SelListSmall1Row = dsHelper1.SelListSmall1.NewRow()
        rNew.ID = System.Guid.NewGuid()
        rNew.IDOwnInt = -999
        rNew.IDOwnStr = ""
        rNew.SelList = ""
        rNew.IDSelList = -999
        rNew.IDGroupStr = ""
        rNew.Application = ""
        rNew.IDOwnIntParent = -999
        rNew.IDSelListParent = -999

        dsHelper1.SelListSmall1.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getCriterias(ByVal ds As dsAdmin, ByVal typSel As eTypSelCriteria, _
                                 ByVal FldShort As String, _
                                 ByVal IDApplication As String, ByVal onlyNotInChapters As Boolean, _
                                 ByVal doPreferedVisibleUnvisible As Boolean, ByVal bOnlyPrefered As Boolean, _
                                 Chapter As String, IDGroupStr As String, ApplicationAndAll As Boolean) As dsAdmin.tblCriteriaRow()
        Try
            Me.daCriteria.SelectCommand.CommandText = Me.sel_daSelCriteria
            database.setConnection(Me.daCriteria)
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

                    'Dim sWhereSearch As String = (sqlTxt.select + ds.tblCriteria.FldShortColumn.ColumnName + ", " + sqlTxt.select + ds.tblCriteria.IDApplicationColumn.ColumnName + sqlTxt.from + ds.tblCriteria .TableName + sqlTxt .where + ds.tblCriteria.FldShortColumn + sql#
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
                'Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblCriteria.IDApplicationColumn.ColumnName)
                'Me.daCriteria.SelectCommand.CommandText += sWhere
                'Me.daCriteria.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblCriteria.IDApplicationColumn.ColumnName), IDApplication.ToString())

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
            sWhere = " SELECT  qs2.tblCriteria.FldShort " + _
                        " FROM qs2.tblCriteria INNER JOIN " + _
                        " qs2.tblSelListEntriesObj ON qs2.tblCriteria.FldShort = qs2.tblSelListEntriesObj.FldShort AND  " + _
                        " qs2.tblCriteria.IDApplication = qs2.tblSelListEntriesObj.IDApplication INNER JOIN " + _
                        " qs2.tblSelListGroup INNER JOIN  " + _
                        " qs2.tblSelListEntries ON qs2.tblSelListGroup.ID = qs2.tblSelListEntries.IDGroup ON qs2.tblSelListEntriesObj.IDSelListEntry = qs2.tblSelListEntries.ID " + _
                        " WHERE qs2.tblSelListGroup.IDGroupStr = '" + IDGroupStr.ToString() + "' and qs2.tblSelListEntriesObj.typIDGroup = '" + typIDGroup.Trim() + "' AND qs2.tblSelListEntries.IDOwnStr = '" + Chapters.Trim() + "'  "

            'Dim sWhere As String = ""
            'sWhere = " SELECT  qs2.tblCriteria.FldShort " + _
            '            " FROM qs2.tblCriteria INNER JOIN " + _
            '            " qs2.tblSelListEntriesObj ON qs2.tblCriteria.FldShort = qs2.tblSelListEntriesObj.FldShort AND  " + _
            '            " qs2.tblCriteria.IDApplication = qs2.tblSelListEntriesObj.IDApplication INNER JOIN " + _
            '            " qs2.tblSelListGroup INNER JOIN  " + _
            '            " qs2.tblSelListEntries ON qs2.tblSelListGroup.ID = qs2.tblSelListEntries.IDGroup ON qs2.tblSelListEntriesObj.IDSelListEntry = qs2.tblSelListEntries.ID " + _
            '            " WHERE qs2.tblSelListGroup.IDGroupStr = '" + IDGroupStr.ToString() + "' and qs2.tblSelListEntriesObj.typIDGroup = '" + typIDGroup.Trim() + "' AND qs2.tblSelListEntries.IDOwnStr = '" + Chapters.Trim() + "' AND " + _
            '            " (qs2.tblCriteria.IDApplication = '" + IDApplication.Trim() + "' OR qs2.tblCriteria.IDApplication = 'ALL') "

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
        'ds.tblCriteria.Rows.InsertAt(rNew, 0)
        Return rNew

    End Function
    Public Function addRowCriteriaSmall(ByVal dsHelper1 As dsHelper) As dsHelper.CriteriasSmallRow
        Dim rNew As dsHelper.CriteriasSmallRow = dsHelper1.CriteriasSmall.NewRow()
        rNew.FldShort = ""
        rNew.ID = System.Guid.NewGuid()
        rNew.Field = ""
        rNew.FldShort = ""
        rNew.ControlType = ""
        rNew.MinVal = ""
        rNew.MaxVal = ""
        rNew.MinLength = -1
        rNew.MaxLength = -1
        rNew.DefaultValue = ""
        rNew.Chapter = ""
        rNew.FldShortSelList = ""
        rNew.Application = ""
        rNew.Editable = False
        rNew.FUP = False

        dsHelper1.CriteriasSmall.Rows.Add(rNew)
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
    Public Function getCriteriasOpt(ByVal ds As dsAdmin, ByVal typSel As eTypSelCriteriaOpt, _
                                 ByVal FldShort As String, _
                                 ByVal Application As String) As dsAdmin.tblCriteriaOptRow()

        Me.daCriteriaOpt.SelectCommand.CommandText = Me.sel_daSelCriteriaOpt
        database.setConnection(Me.daCriteriaOpt)
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
    Public Function getNewRowCriteriaOpt(ByVal tCriteriaOpt As dsAdmin.tblCriteriaOptDataTable) As dsAdmin.tblCriteriaOptRow
        Dim rNew As dsAdmin.tblCriteriaOptRow = tCriteriaOpt.NewRow()
        rNew.FldShort = ""
        rNew.IDApplication = ""
        rNew.Parameter = ""
        rNew.Value = ""
        rNew.Referenze = ""

        tCriteriaOpt.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getRelationsship(ByVal ds As dsAdmin, ByVal typSel As eTypSelRelationship, _
                             ByVal FldShort As String, _
                             ByVal IDApplication As String, ByVal IDKey As String) As dsAdmin.tblRelationshipRow()

        Me.daRelationship.SelectCommand.CommandText = Me.sel_daSelRelationship
        database.setConnection(Me.daRelationship)
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
            'Dim sWhere As String = ds.tblRelationship.IDKeyColumn.ColumnName + " like '%" + IDKey.Trim() + "%' " + sqlTxt.and + _
            '                        " (" + ds.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + IDApplication + "' or " + _
            '                        " " + ds.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString() + "') "
            Dim arrRelationsship() As dsAdmin.tblRelationshipRow = sqlAdmin.dsAllAdmin.tblRelationship.Select(sWhere, ds.tblRelationship.SortColumn.ColumnName + sqlTxt.asc)
            Return arrRelationsship

        Else
            Throw New Exception("sqlAdmin.getRelationsship: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daRelationship.Fill(ds.tblRelationship)
    End Function
    Public Function getNewRowRelationsship(ByVal tRelationship As dsAdmin.tblRelationshipDataTable) As dsAdmin.tblRelationshipRow
        Dim rNew As dsAdmin.tblRelationshipRow = tRelationship.NewRow()
        rNew.FldShortParent = ""
        rNew.IDApplicationParent = ""
        rNew.SetFldShortChildNull()
        rNew.SetIDApplicationChildNull()
        rNew.Conditions = ""
        rNew.Type = ""
        rNew.TypeSub = ""
        rNew.IDKey = ""
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.ConditionsSub = ""
        rNew.Sort = -1

        tRelationship.Rows.Add(rNew)
        Return rNew

    End Function


    Public Function getStayAdditions(ByVal IDStay As Integer, ByVal IDParticipant As String, ByVal ds As dsAdmin, ByVal typSel As eTypSelStayAdditions,
                                     ByVal typStayAdditions As core.vb.sqlAdmin.eTypStayAdditions,
                                     ByVal IDApplication As String, IDObject As System.Guid, ByVal typStayAdditions2 As String,
                                     ByVal ClearStayAdditions As Boolean, Optional IDGuid As Nullable(Of Guid) = Nothing) As Boolean

        Me.daStayAdditions.SelectCommand.CommandText = Me.sel_daSelStayAddistions
        database.setConnection(Me.daStayAdditions)
        Me.daStayAdditions.SelectCommand.Parameters.Clear()

        If ClearStayAdditions Then
            ds.tblStayAdditions.Clear()
        End If


        If typSel = eTypSelStayAdditions.idStay Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStayAdditions.IDStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDStayParentColumn.ColumnName), IDStay)

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName), IDParticipant)

            If (typStayAdditions2.Trim() = "") Then
                sWhere += " and " + ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions.ToString() + "' "
            Else
                sWhere += " and ( " + ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions.ToString() + "' or " +
                            ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions2.ToString() + "' ) "
            End If

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName), IDApplication)

            Me.daStayAdditions.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblStayAdditions.SortColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelStayAdditions.idStayORIdPatient Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.ClampRight + sqlTxt.getColWhere(ds.tblStayAdditions.IDStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDStayParentColumn.ColumnName), IDStay)

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName), IDParticipant)

            sWhere += sqlTxt.or + sqlTxt.getColWhere(ds.tblStayAdditions.IDPatientColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDPatientColumn.ColumnName), IDObject)

            sWhere += sqlTxt.ClampLeft

            If (typStayAdditions2.Trim() = "") Then
                sWhere += " and " + ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions.ToString() + "' "
            Else
                sWhere += " and ( " + ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions.ToString() + "' or " +
                            ds.tblStayAdditions.typColumn.ColumnName + "='" + typStayAdditions2.ToString() + "' ) "
            End If

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName), IDApplication)

            Me.daStayAdditions.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblStayAdditions.SortColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelStayAdditions.idStay2 Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStayAdditions.IDStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDStayParentColumn.ColumnName), IDStay)

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName), IDParticipant)

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName), IDApplication)

            Me.daStayAdditions.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblStayAdditions.SortColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelStayAdditions.IDGuid Then
            Dim sWhere As String = sqlTxt.where + " IDGuid= '" + IDGuid.ToString() + "'"
            Me.daStayAdditions.SelectCommand.CommandText += sWhere

        ElseIf typSel = eTypSelStayAdditions.idObject Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStayAdditions.IDPatientColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDPatientColumn.ColumnName), IDObject)

            sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.typColumn.ColumnName)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.typColumn.ColumnName), typStayAdditions.ToString())

            'sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStayAdditions.IDApplicationColumn.ColumnName)
            'Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDApplicationColumn.ColumnName), IDApplication)

            Me.daStayAdditions.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblStayAdditions.SortColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelStayAdditions.idStayAll Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStayAdditions.IDStayParentColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName)

            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDStayParentColumn.ColumnName), IDStay)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDParticipantStayParentColumn.ColumnName), IDParticipant)
            Me.daStayAdditions.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStayAdditions.IDApplicationStayParentColumn.ColumnName), IDApplication)
            Me.daStayAdditions.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblStayAdditions.SortColumn.ColumnName + sqlTxt.asc

        Else
            Throw New Exception("sqlAdmin.getStayAdditions: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daStayAdditions.Fill(ds.tblStayAdditions)
        Return True

    End Function

    Public Function updateSortStayAddition(ByVal IDGuidStayAddition As System.Guid, Sort As Integer) As Boolean
        Dim ds As New dsAdmin
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Parameters.Clear()
        cmd.CommandText = " update qs2.tblStayAdditions set Sort=" + Sort.ToString() + " where IDGuid='" + IDGuidStayAddition.ToString() + "'"
        cmd.Connection = qs2.core.dbBase.dbConn
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function getQueriesDef(ByVal ID As Integer, ByVal ds As dsAdmin, ByVal typSel As eTypSelQueryDef, _
                                   ByVal typQueryDef As qs2.core.Enums.eTypQueryDef, _
                                   ByVal IDParticipant As String, ByVal IDApplication As String) As Boolean
        Try


            Me.daQueriesDef.SelectCommand.CommandText = Me.sel_daSelQueriesDef
            database.setConnection(Me.daQueriesDef)
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
            'tblQueriesDef.AddtblQueriesDefRow(rNew)
            'tblQueriesDef.Rows.Add(rNew)
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

    Public Function getQueryJoinsTemp(ByVal IDGuid As System.Guid, ByVal ds As dsAdmin, ByVal typSel As eTypSelQueryJoinsTemp) As Boolean

        Me.daQueryJoinsTemp.SelectCommand.CommandText = Me.sel_daSelQueryJoinsTemp
        database.setConnection(Me.daQueryJoinsTemp)
        Me.daQueryJoinsTemp.SelectCommand.Parameters.Clear()

        If typSel = eTypSelQueryJoinsTemp.all Then
            Dim orderBy As String = sqlTxt.orderBy + "[" + ds.tblQueryJoinsTemp.OrderColumn.ColumnName + "]" + sqlTxt.asc
            Me.daQueryJoinsTemp.SelectCommand.CommandText += orderBy

        Else
            Throw New Exception("sqlAdmin.getQueryJoinsTemp: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daQueryJoinsTemp.Fill(ds.tblQueryJoinsTemp)
        Return True

    End Function


    Public Function getSideLogic(ByVal ds As dsAdmin, ByVal typeSideLogic As eTypeSideLogic, _
                                 ByVal ID As Integer, ByVal FldShort As String, ByVal Application As String) As dsAdmin.tblSideLogicRow()

        Me.daSideLogic.SelectCommand.CommandText = Me.sel_daSelSideLogic
        database.setConnection(Me.daSideLogic)
        Me.daSideLogic.SelectCommand.Parameters.Clear()

        Dim orderBy As String = ds.tblSideLogic.IDApplicationColumn.ColumnName + sqlTxt.asc + ", " + _
                                   ds.tblSideLogic.FldShortColumn.ColumnName + sqlTxt.asc

        If typeSideLogic = eTypeSideLogic.all Then
            Me.daSideLogic.SelectCommand.CommandText += sqlTxt.orderBy + orderBy

        ElseIf typeSideLogic = eTypeSideLogic.FldShortApplication Then
            Dim sWhere As String = ds.tblSideLogic.FldShortColumn.ColumnName + "='" + FldShort + "' and " + _
                                 ds.tblSideLogic.IDApplicationColumn.ColumnName + "='" + Application + "'"
            Dim arrSideLogic As dsAdmin.tblSideLogicRow() = ds.tblSideLogic.Select(sWhere, orderBy)
            Return arrSideLogic

        ElseIf typeSideLogic = eTypeSideLogic.IDSelList Or typeSideLogic = eTypeSideLogic.IDObj Then
            Dim sWhere As String = ds.tblSideLogic.TypeColumn.ColumnName + "='" + typeSideLogic.ToString() + "' and " + _
                                  ds.tblSideLogic.IDColumn.ColumnName + "=" + ID.ToString() + ""
            Dim arrSideLogic As dsAdmin.tblSideLogicRow() = ds.tblSideLogic.Select(sWhere, orderBy)
            Return arrSideLogic

        Else
            Throw New Exception("sqlAdmin.getSideLogic: typSel '" + typeSideLogic.ToString() + "' is wrong!")
        End If

        Me.daSideLogic.Fill(ds.tblSideLogic)
        Return Nothing

    End Function

    Public Function getNewRowSideLogic(ByVal tSideLogic As dsAdmin.tblSideLogicDataTable) As dsAdmin.tblSideLogicRow
        Dim rNew As dsAdmin.tblSideLogicRow = tSideLogic.NewRow()
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.Type = ""
        rNew.Action = ""
        rNew.SetFldShortNull()
        rNew.Chapter = ""
        rNew.SetIDApplicationNull()
        rNew.SetIDNull()
        tSideLogic.Rows.Add(rNew)

        Return rNew
    End Function

    Public Function getNextIDOwnIntSelList(ByRef IDGroup As Integer, Optional countAll As Boolean = False, Optional doSupervisor As Boolean = True) As Integer
        Try
            Dim dsAdminRead As New dsAdmin()
            Dim sqlAdminRead As New sqlAdmin()
            sqlAdminRead.initControl()
            'sqlAdminRead.getSelListGroup(dsAdminRead, eTypSelGruppen.IDGruppe, "", "", "", IDGroup)
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            sqlAdminRead.getSelListEntrys(Parameters, "", "ALL", "", dsAdminRead, sqlAdmin.eTypAuswahlList.IDGroup, "", 0, "", IDGroup, "", "")

            Dim nextIDOwnInt As Integer = 0
            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() And doSupervisor Then
                nextIDOwnInt = 0
            Else
                nextIDOwnInt = 10000
            End If

            For Each rSelList As dsAdmin.tblSelListEntriesRow In dsAdminRead.tblSelListEntries
                If Not rSelList.IsIDOwnIntNull() Then
                    If countAll Then
                        nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
                    Else
                        If rSelList.IDOwnInt >= 10000 Then
                            nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
                        End If
                    End If
                End If
                'If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                '    If Not rSelList.IsIDOwnIntNull() Then
                '        If rSelList.IDOwnInt < 999 Then
                '            nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
                '        End If
                '    End If
                'Else
                '    If Not rSelList.IsIDOwnIntNull() Then
                '        If rSelList.IDOwnInt >= 10000 Then
                '            nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
                '        End If
                '    End If

                'End If
            Next
            Return (nextIDOwnInt + 1)

        Catch ex As Exception
            Throw New Exception("getNextIDOwnIntSelList: " + ex.ToString())
            Return 5000
        End Try
    End Function
    Public Sub getNextIDSelListGeneric(ByRef newIDSelList As Integer, ByRef NextIDOwnStr As String, ByRef NextIDOwnInt As Integer,
                                            ByRef IDGroup As Integer)
        Try
            If NextIDOwnInt < 0 Then
                Throw New Exception("sqlAdmin.getNextIDSelListGeneric:NextIDOwnInt < 0 for new SelListEntry!")
            End If

            newIDSelList = System.Convert.ToInt32(IDGroup.ToString() + NextIDOwnInt.ToString().PadLeft(IIf(qs2.core.vb.actUsr.IsAdminSecureOrSupervisor(), 4, 5), "0").ToString())

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getNextIDSelListGeneric: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Function getNextIDSelListEntries(ByRef ds As dsAdmin, ByRef typSel As eTypSelListGetMaxID, ByRef nrCircleManuell As Integer) As dsAdmin.tblSelListEntriesRow()

        Dim sqlWhere As String = "SELECT MAX(ID) AS MaxID FROM qs2.tblSelListEntries"

        Me.daMaxSelListGroupID.SelectCommand.CommandText = sqlWhere
        database.setConnection(Me.daMaxSelListGroupID)
        Me.daMaxSelListGroupID.SelectCommand.Parameters.Clear()
        If typSel = eTypSelListGetMaxID.GetMaxIDGeneric Then
            Dim sWhere As String = sqlTxt.where + ds.tblSelListEntries.IDColumn.ColumnName + " >= " + (nrCircleManuell).ToString()
            Me.daMaxSelListGroupID.SelectCommand.CommandText += sWhere
        Else
            Throw New Exception("sqlAdmin.getNextIDSelListEntries: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daMaxSelListGroupID.Fill(ds.SelListMaxIDs)

    End Function

    Public Function calcNextIDSelList(ByRef IDNotCalculated As Integer) As Integer

        'If IDNotCalculated = -1 Then
        '    Return 9999
        'ElseIf IDNotCalculated >= 0 Then
        '    If IDNotCalculated < 10 Then
        '        Return 1000 + IDNotCalculated
        '    ElseIf IDNotCalculated < 100 Then
        '        Return 1000 + IDNotCalculated
        '    ElseIf IDNotCalculated < 1000 Then
        '        Return 1000 + IDNotCalculated
        '    ElseIf IDNotCalculated < 10000 Then
        '        Return IDNotCalculated
        '    Else
        '        Throw New Exception("sqlAdmin.getNextID:  IDNotCalculated >= 10000!")
        '    End If
        'Else
        '    Throw New Exception("sqlAdmin.getNextIDSelListGeneric: IDNotCalculated < -1!")
        'End If

        Return (IDNotCalculated + 1)

    End Function

    Public Function getNextIDSelListGroupGeneric() As Integer
        Try
            Dim nrCircleManuell As Integer = -1
            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                nrCircleManuell = 1000
            Else
                'nrCircleManuell = 100000
                Throw New Exception("sqlAdmin: getNextIDSelListGroupGeneric: To add a new group is for normal Users not allowed!")
            End If
            Dim nrCircleMaxManuell As Integer = nrCircleManuell + 999

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
        database.setConnection(Me.daMaxSelListGroupID)
        Me.daMaxSelListGroupID.SelectCommand.Parameters.Clear()
        If typSel = eTypSelListGetMaxID.GetMaxIDGeneric Then
            Dim sWhere As String = sqlTxt.where + ds.tblSelListEntries.IDColumn.ColumnName + " >= " + (nrCircleManuell).ToString() + sqlTxt.and + _
                                            ds.tblSelListEntries.IDColumn.ColumnName + " <= " + (nrCircleMaxManuell).ToString()
            Me.daMaxSelListGroupID.SelectCommand.CommandText += sWhere
        Else
            Throw New Exception("sqlAdmin.getMaxSelListGroup: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daMaxSelListGroupID.Fill(ds.SelListMaxIDs)

    End Function
    Public Function getMaxSelListID(ByRef typSel As eTypSelListGetMaxID, _
                                    ByRef IDGroup As Integer) As Integer

        Dim ds As New dsAdmin()
        Me.daMaxSelListID.SelectCommand.CommandText = Me.sel_daMaxSelListID
        database.setConnection(Me.daMaxSelListID)
        Me.daMaxSelListID.SelectCommand.Parameters.Clear()

        If typSel = eTypSelListGetMaxID.GetMaxIDGeneric Then
            Dim sWhere As String = sqlTxt.where + ds.tblSelListEntries.IDGroupColumn.ColumnName + "=" + IDGroup.ToString() + ""
            Me.daMaxSelListID.SelectCommand.CommandText += sWhere
        Else
            Throw New Exception("sqlAdmin.getMaxSelListID: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daMaxSelListID.Fill(ds.SelListMaxIDs)
        If ds.SelListMaxIDs.Rows.Count = 0 Then
            Return 1

        ElseIf ds.SelListMaxIDs.Rows.Count = 1 Then
            Dim rRowFound As dsAdmin.SelListMaxIDsRow = ds.SelListMaxIDs.Rows(0)
            If rRowFound Is Nothing Then
                Return 1
            Else
                If rRowFound.IsMaxIDNull() Then
                    Return 1
                Else
                    Return (rRowFound.MaxID + 1)
                End If
            End If

        ElseIf ds.SelListMaxIDs.Rows.Count > 1 Then
            Throw New Exception("getMaxSelListID: Error -> ds.SelListMaxIDs.Rows.Count > 1 for IDGroup '" + IDGroup.ToString() + "'!")
        End If

        Return True

    End Function


    Public Function getNewRowProtocol(ByVal tProtokoll As dsAdmin.protokollDataTable) As dsAdmin.protokollRow
        Dim rNew As dsAdmin.protokollRow = tProtokoll.NewRow()
        rNew.TextSub = ""
        rNew.TextControl = ""
        rNew.TextMessage = ""
        rNew.rowAutoUI = ""
        rNew.ID = System.Guid.NewGuid()
        rNew.sys = False
        rNew.admin = False
        rNew.supress = False
        tProtokoll.Rows.Add(rNew)

        Return rNew
    End Function

    Public Function getvSelListEntriesObj(ds As DataSet, ByVal typeSel As eTypeSelvSelListEntriesObj) As Boolean
        Try
            Me.davSelListEntriesObj.SelectCommand.CommandText = Me.sel_davSelListEntriesObj
            database.setConnection(Me.davSelListEntriesObj)
            Me.davSelListEntriesObj.SelectCommand.Parameters.Clear()

            If typeSel = eTypeSelvSelListEntriesObj.All Then
                Dim sWhere As String = ""

            Else
                Throw New Exception("sqlAdmin.getvSelListEntriesObj: typSel '" + typeSel.ToString() + "' is wrong!")
            End If

            Me.davSelListEntriesObj.Fill(ds)
            ds.Tables(0).TableName = "vSelListEntriesObj"
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAdmin.getvSelListEntriesObj: " + ex.ToString())
        End Try
    End Function

    Public Function getAllUsersWithRoles(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList) As Boolean
        Try
            Me.daGetAllUsersWithRoles.SelectCommand.CommandText = Me.sel_GetAllUsersWithRoles
            database.setConnection(Me.daGetAllUsersWithRoles)
            Me.daGetAllUsersWithRoles.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.all Then
                Dim sWhere As String = ""
            Else
                Throw New Exception("sqlAdmin.getAllUsersWithRoles: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetAllUsersWithRoles.Fill(ds.getAllUsersWithRoles)
            Return True

        Catch ex As Exception
            Throw New Exception("getAllUsersWithRoles: " + ex.ToString())
        End Try
    End Function
    Public Function getButtonsForUser(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList) As Boolean
        Try
            Me.daGetButtonsForUser.SelectCommand.CommandText = Me.sel_GetButtonsForUser
            database.setConnection(Me.daGetButtonsForUser)
            Me.daGetButtonsForUser.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.all Then
                Dim sWhere As String = ""
            Else
                Throw New Exception("sqlAdmin.getButtonsForUser: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetButtonsForUser.Fill(ds.getButtonsForUser)
            Return True

        Catch ex As Exception
            Throw New Exception("getButtonsForUser: " + ex.ToString())
        End Try
    End Function
    Public Function getChaptersAlwaysEditableAllUsers(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList) As Boolean
        Try
            Me.daGetChaptersAlwaysEditableAllUsers.SelectCommand.CommandText = Me.sel_GetChaptersAlwaysEditableAllUsers
            database.setConnection(Me.daGetChaptersAlwaysEditableAllUsers)
            Me.daGetChaptersAlwaysEditableAllUsers.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.all Then
                Dim sWhere As String = ""
            Else
                Throw New Exception("sqlAdmin.getChaptersAlwaysEditableAllUsers: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetChaptersAlwaysEditableAllUsers.Fill(ds.GetChaptersAlwaysEditableAllUsers)
            Return True

        Catch ex As Exception
            Throw New Exception("getButtonsForUser: " + ex.ToString())
        End Try
    End Function

    Public Function getCriteriasForUser(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList, IDUser As Integer) As Boolean
        Try
            Me.daGetCriteriasForUser.SelectCommand.CommandText = Me.sel_GetCriteriasForUser
            database.setConnection(Me.daGetCriteriasForUser)
            Me.daGetCriteriasForUser.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.AllFldShortsUser Then
                Dim sWhere As String = " where IDObject=" + IDUser.ToString()
                Me.daGetCriteriasForUser.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("sqlAdmin.getCriteriasForUser: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetCriteriasForUser.Fill(ds.getCriteriasForUser)
            Return True

        Catch ex As Exception
            Throw New Exception("getCriteriasForUser: " + ex.ToString())
        End Try
    End Function
    Public Function getCriteriasUserForUser(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList, IDUser As Integer) As Boolean
        Try
            Me.daGetCriteriasUserForUser.SelectCommand.CommandText = Me.sel_GetCriteriasUserForUser
            database.setConnection(Me.daGetCriteriasUserForUser)
            Me.daGetCriteriasUserForUser.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.AllFldShortsUser Then
                Dim sWhere As String = " where IDObject=" + IDUser.ToString()
                Me.daGetCriteriasUserForUser.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("sqlAdmin.getCriteriasUserForUser: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetCriteriasUserForUser.Fill(ds.getCriteriasUserForUser)
            Return True

        Catch ex As Exception
            Throw New Exception("getCriteriasUserForUser: " + ex.ToString())
        End Try
    End Function
    Public Function getAllUsersWithRights(ByRef ds As dsAdmin, ByVal typSel As eTypAuswahlList, IDUser As Integer) As Boolean
        Try
            Me.daGetAllUsersWithRights.SelectCommand.CommandText = Me.sel_GetAllUsersWithRights
            database.setConnection(Me.daGetAllUsersWithRights)
            Me.daGetAllUsersWithRights.SelectCommand.Parameters.Clear()

            If typSel = eTypAuswahlList.all Then
                Dim sWhere As String = " where ID=" + IDUser.ToString()
                Me.daGetAllUsersWithRights.SelectCommand.CommandText += sWhere
            Else
                Throw New Exception("sqlAdmin.getAllUsersWithRights: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daGetAllUsersWithRights.Fill(ds.getAllUsersWithRights)
            Return True

        Catch ex As Exception
            Throw New Exception("getAllUsersWithRights: " + ex.ToString())
        End Try
    End Function

    Public Function getValueForProductField(FldShort As String, TableName As String, ByRef oValueReturn As Object,
                                            ID As Integer, IDApplication As String, IDParticipant As String) As Boolean
        Try
            Dim dt As New DataTable()
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim da As New System.Data.SqlClient.SqlDataAdapter()
            da.SelectCommand = cmd
            cmd.Parameters.Clear()
            Dim sWhere As String = " ID=" + ID.ToString() + " and IDApplication='" + IDApplication.ToString() + "' and IDParticipant='" + IDParticipant.ToString() + "'"
            cmd.CommandText = " Select " + FldShort.Trim() + " from qs2." + TableName.Trim() + " where " + sWhere
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            da.Fill(dt)
            If dt.Rows.Count <> 1 Then
                Throw New Exception("getValueForProductField: dt.Rows.Count <> 1 for Stay '" + sWhere + "' not allowed!")
            End If
            Dim r As DataRow = dt.Rows(0)
            oValueReturn = r(0)
            Return True

        Catch ex As Exception
            Throw New Exception("getValueForProductField: " + ex.ToString())
        End Try
    End Function

End Class
