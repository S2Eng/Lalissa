Imports System.Data.OleDb
Imports qs2.core
Imports qs2.core.vb

Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Public Class actUsr


    Public Shared rUsr As dsObjects.tblObjectRow
    Public Shared loggedInAsWindowsUser As Boolean = False
    Public Shared rUsrAdr As dsObjects.tblAdressRow

    Public Shared valWinMaximized As Integer = -32000

    Private Shared dsAdjust1 As New dsAdmin()
    Public Shared lstRolesUser As New System.Collections.Generic.List(Of businessFramework.cSelListAndObj)

    Public Shared __UserHasRigthSetCompleted As Boolean = False


    Public Shared sqlAdminRights As sqlAdmin = Nothing
    Public Shared dsAdminRights As dsAdmin = Nothing
    Public Shared sqlAdminRights_Systemuser As sqlAdmin = Nothing
    Public Shared dsAdminRights_Systemuser As dsAdmin = Nothing


    'Public Shared dsGroupsUserLogedIn As dsAdmin = Nothing
    'Public Shared dsAdminRightsTmp As dsAdmin = Nothing
    Public Shared UserHasRoleAdministrator As Boolean = False











    Public Shared Function loadActUsr(ByVal ID As Integer, bDesignMode As Boolean) As Boolean
        Try
            Dim sqlObjects1 As New sqlObjects
            Dim dsObjectUsr As New dsObjects()
            dsObjectUsr.Clear()
            sqlObjects1.initControl()

            actUsr.rUsr = sqlObjects1.getObjectRow(ID, sqlObjects.eTypSelObj.ID)
            actUsr.rUsrAdr = sqlObjects1.getAdressRow(actUsr.rUsr.IDGuid, dsObjectUsr, sqlObjects.eTypSelAdr.idObject)
            Dim LanguageTmp As String = actUsr.adjustRead(actUsr.rUsr.UserName.Trim(), sqlAdmin.eAdjust.LanguageUser, sqlAdmin.eTypSelAdjust.forUsr, "")
            If Not LanguageTmp Is Nothing AndAlso LanguageTmp.Trim() <> "" Then
                ENV.language = LanguageTmp
            End If

            If Not bDesignMode Then
                actUsr.loadRolesUser()
            End If

            actUsr.UserHasRigthSetCompleted = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSetCompleted, False)
            Return True

        Catch ex As Exception
            Throw New Exception("actUsr.loadActUsr: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Shared Sub loadRolesUser()
        Try
            'Dim b As New businessFramework()
            'b.getAllRolesForUser(actUsr.rUsr.ID, actUsr.lstRolesUser, False)
            'If actUsr.lstRolesUser.Count > 0 Then
            'End If

            Dim arrRolesUser() As dsAdmin.getAllUsersWithRolesRow = sqlAdmin.dsAllAdmin.getAllUsersWithRoles.Select("ID=" + actUsr.rUsr.ID.ToString())
            If arrRolesUser.Count > 0 Then
                qs2.core.language.sqlLanguage.IDResRoleLoggedInUser = "Role" + arrRolesUser(0).IDSelListEntry.ToString()   'actUsr.lstRolesUser(0).rSelList.ID.ToString()
            End If

        Catch ex As Exception
            Throw New Exception("actUsr.loadRolesUser: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Shared Function checkRights(ByVal right As qs2.core.Enums.eRights, ByVal message As Boolean, Optional IDUserOptional As Integer = -1) As Boolean
        Dim sExcept As String = right.ToString() + ";"
        Try
            Dim IDUserTmp As Integer = -1
            Dim UserNameTmp As String = ""
            If IDUserOptional > 0 Then
                Dim sqlObjectsRead As New sqlObjects()
                sqlObjectsRead.initControl()
                sExcept += ";1;"
                Dim rUsrOptional As dsObjects.tblObjectRow = sqlObjectsRead.getObjectRow(IDUserOptional, sqlObjects.eTypSelObj.ID)
                If rUsrOptional Is Nothing Then
                    Throw New Exception("checkRights: rUsrOptional Is Nothing for UserID '" + IDUserOptional.ToString() + "'!")
                End If
                IDUserTmp = rUsrOptional.ID
                UserNameTmp = rUsrOptional.UserName.Trim()
                sExcept += ";2;"
                'If actUsr.sqlAdminRights_Systenuser Is Nothing Then
                '    actUsr.sqlAdminRights_Systenuser = New sqlAdmin()
                '    actUsr.sqlAdminRights_Systenuser.initControl()
                'End If
                'actUsr.dsAdminRights_Systemuser.Clear()
                'actUsr.sqlAdminRights_Systenuser.getAllUsersWithRights(actUsr.dsAdminRights_Systemuser, sqlAdmin.eTypAuswahlList.all, IDUserTmp)

                Dim sqlAdminTmp = New core.vb.sqlAdmin()
                sqlAdminTmp.initControl()

                actUsr.sqlAdminRights_Systemuser = New sqlAdmin()
                actUsr.sqlAdminRights_Systemuser.initControl()
                actUsr.dsAdminRights_Systemuser = New dsAdmin()
                sqlAdminTmp.getAllUsersWithRights(actUsr.dsAdminRights_Systemuser, core.vb.sqlAdmin.eTypAuswahlList.all, IDUserOptional)

                Dim sWhere As String = "ID=" + IDUserTmp.ToString() + " and IDOwnStr='" + right.ToString() + "'"
                Dim arrRight() As dsAdmin.getAllUsersWithRightsRow = actUsr.dsAdminRights_Systemuser.getAllUsersWithRights.Select(sWhere)
                sExcept += ";3;"
                If arrRight.Length > 0 Then
                    Return True
                End If

            Else
                IDUserTmp = qs2.core.vb.actUsr.rUsr.ID
                UserNameTmp = actUsr.rUsr.UserName.Trim()

                If actUsr.sqlAdminRights Is Nothing Then
                    actUsr.sqlAdminRights = New sqlAdmin()
                    actUsr.sqlAdminRights.initControl()
                    actUsr.dsAdminRights = New dsAdmin()
                    actUsr.sqlAdminRights.getAllUsersWithRights(actUsr.dsAdminRights, sqlAdmin.eTypAuswahlList.all, IDUserTmp)
                End If

                If UserNameTmp.Trim().ToLower = qs2.core.vb.sqlObjects.userName_Supervisor.Trim().ToLower() Or
                    UserNameTmp.Trim().ToLower = qs2.core.vb.sqlObjects.userName_Supervisor.Trim().ToLower() Then
                    Return True
                End If
                If qs2.core.ENV.adminSecure Then
                    Return True
                End If

                Dim sWhere As String = "ID=" + IDUserTmp.ToString() + " and IDOwnStr='" + right.ToString() + "'"
                Dim arrRight() As dsAdmin.getAllUsersWithRightsRow = actUsr.dsAdminRights.getAllUsersWithRights.Select(sWhere)
                If arrRight.Length > 0 Then
                    Return True
                End If
            End If

            'If actUsr.rUsr.isAdmin Then
            '    Return True
            'End If

        Catch ex As Exception
            Throw New Exception("actUsr.checkRight: Right: " + sExcept + vbNewLine + vbNewLine + ex.ToString())
            Return False
        Finally
        End Try
    End Function
    Public Shared Function checkRightsOld(ByVal right As qs2.core.Enums.eRights, ByVal message As Boolean, Optional IDUserOptional As Integer = -1) As Boolean
        Try
            'Dim IDUserTmp As Integer = -1
            'Dim UserNameTmp As String = ""
            'If IDUserOptional > 0 Then
            '    Dim sqlObjectsRead As New sqlObjects()
            '    sqlObjectsRead.initControl()
            '    Dim rUsrOptional As dsObjects.tblObjectRow = sqlObjectsRead.getObjectRow(IDUserOptional, sqlObjects.eTypSelObj.ID)
            '    If rUsrOptional Is Nothing Then
            '        Throw New Exception("checkRights: rUsrOptional Is Nothing for UserID '" + IDUserOptional.ToString() + "'!")
            '    End If
            '    IDUserTmp = rUsrOptional.ID
            '    UserNameTmp = rUsrOptional.UserName.Trim()
            'Else
            '    IDUserTmp = qs2.core.vb.actUsr.rUsr.ID
            '    UserNameTmp = actUsr.rUsr.UserName.Trim()
            '    If UserNameTmp.Trim().ToLower = qs2.core.vb.sqlObjects.userName_Supervisor.Trim().ToLower() Or
            '        UserNameTmp.Trim().ToLower = qs2.core.vb.sqlObjects.userName_Supervisor.Trim().ToLower() Then
            '        Return True
            '    End If
            '    If qs2.core.ENV.adminSecure Then
            '        Return True
            '    End If
            'End If

            ''If actUsr.rUsr.isAdmin Then
            ''    Return True
            ''End If

            'If actUsr.sqlAdminReadsRights Is Nothing Then
            '    actUsr.sqlAdminReadsRights = New sqlAdmin()
            '    actUsr.sqlAdminReadsRights.initControl()
            '    actUsr.dsAdminAllRights = New dsAdmin()
            '    actUsr.dsGroupsUserLogedIn = New dsAdmin()
            '    actUsr.dsAdminRightsTmp = New dsAdmin()
            '    Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            '    actUsr.sqlAdminReadsRights.getSelListEntrys(Parameters, "RIGHT", qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication, actUsr.dsAdminAllRights, sqlAdmin.eTypAuswahlList.group)
            '    actUsr.dsGroupsUserLogedIn.tblSelListEntriesObj.Rows.Clear()
            '    actUsr.sqlAdminReadsRights.getSelListEntrysObj(IDUserTmp, sqlAdmin.eDbTypAuswObj.Usergroups, "NONE", actUsr.dsGroupsUserLogedIn, sqlAdmin.eTypAuswahlObj.obj, license.doLicense.eApp.ALL.ToString())
            'End If

            '' Read All Rights
            '' Read All GroupRights for LogedIn-User
            'For Each rGroupUserLogedIn As dsAdmin.tblSelListEntriesObjRow In actUsr.dsGroupsUserLogedIn.tblSelListEntriesObj
            '    ' Read all Rights assigned for Usergroup
            '    Dim dsRightsTempGroup As New dsAdmin()
            '    actUsr.dsAdminRightsTmp.tblSelListEntriesObj.Clear()
            '    Dim arrRightsTempGroup() As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = actUsr.sqlAdminReadsRights.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.SubSelList, "RIGHT", actUsr.dsAdminRightsTmp, sqlAdmin.eTypAuswahlObj.RAMRightUser, license.doLicense.eApp.ALL.ToString(), rGroupUserLogedIn.IDSelListEntry)
            '    'sqlAdmin1.getSelListEntrysObj(rGroupUserLogedIn.IDSelListEntry, sqlAdmin.eDbTypAuswObj.SubSelList, "RIGHT", dsRightsTempGroup, sqlAdmin.eTypAuswahlObj.sellist, license.doLicense.eApp.ALL.ToString())

            '    For Each rRightsTempGroup As dsAdmin.tblSelListEntriesObjRow In arrRightsTempGroup
            '        Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            '        actUsr.dsAdminRightsTmp.tblSelListEntries.Clear()
            '        Dim arrSellistEntries() As qs2.core.vb.dsAdmin.tblSelListEntriesRow = actUsr.sqlAdminReadsRights.getSelListEntrys(Parameters, "", "", "", actUsr.dsAdminRightsTmp, core.vb.sqlAdmin.eTypAuswahlList.IDRam, "", -999, "", rRightsTempGroup.IDSelListEntry, "", "")
            '        'Dim rRightTempGroup As dsAdmin.tblSelListEntriesRow = sqlAdmin1.getSelListEntrys("NONE", sqlAdmin.eTypAuswahlList.id, "", 0, "", rRightsTempGroup.IDSelListEntry)
            '        Dim rRightUserLogedInCheck As qs2.core.Enums.eRights = qs2.core.vb.funct.searchEnumRights(arrSellistEntries(0).IDOwnStr, GetType(qs2.core.Enums.eRights))
            '        If rRightUserLogedInCheck <> Enums.eRights.rightNone Then
            '            If rRightUserLogedInCheck = right Then
            '                Return True
            '            End If
            '        Else
            '            Return False
            '        End If

            '        'For Each rRight As dsAdmin.tblSelListEntrysRow In dsAdminAllRights1.tblSelListEntrys
            '        'Next
            '    Next
            'Next

        Catch ex As Exception
            Throw New Exception("actUsr.checkRight: " + vbNewLine + vbNewLine + ex.ToString())
            Return False
        Finally
        End Try
    End Function

    Public Shared Property UserHasRigthSetCompleted() As Boolean
        Get
            Return actUsr.__UserHasRigthSetCompleted
        End Get
        Set(value As Boolean)
            actUsr.__UserHasRigthSetCompleted = value
        End Set
    End Property

    Public Shared Function IsAdminSecureOrSupervisor() As Boolean
        Try
            If IsNothing(actUsr.rUsr) Then
                Return False
            End If

            If actUsr.rUsr.UserName.Equals(qs2.core.vb.sqlObjects.userName_Supervisor, StringComparison.OrdinalIgnoreCase) Or qs2.core.ENV.adminSecure Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("actUsr.IsAdminSecureOrSupervisor: " + vbNewLine + vbNewLine + ex.ToString())
            Return False
        End Try
    End Function
    Public Shared Function IsSuperadmin() As Boolean
        Try
            If actUsr.rUsr.UserName.Trim().ToLower = qs2.core.vb.sqlObjects.userName_Superadmin.Trim().ToLower() Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("actUsr.IsSuperadmin: " + vbNewLine + vbNewLine + ex.ToString())
            Return False
        End Try
    End Function

    Public Shared Function getRoles() As dsAdmin.tblSelListEntriesObjDataTable
        Dim ds As New dsAdmin()
        Dim sqlAdmin1 As New sqlAdmin()
        sqlAdmin1.initControl()
        sqlAdmin1.getSelListEntrysObj(qs2.core.vb.actUsr.rUsr.ID, sqlAdmin.eDbTypAuswObj.Roles, "Roles", ds, sqlAdmin.eTypAuswahlObj.obj, "")
        Return ds.tblSelListEntriesObj
    End Function

    Public Shared Sub getLoggedInUserHasRoleAdministrator()
        Try
            Dim sWhereObjSelList As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='Roles' and " +
                                            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDObjectColumn.ColumnName + "=" + actUsr.rUsr.ID.ToString() + ""
            Dim arrObjRolesLoggedInUser() As dsAdmin.tblSelListEntriesObjRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereObjSelList, "")
            For Each rObjRole As dsAdmin.tblSelListEntriesObjRow In arrObjRolesLoggedInUser
                Dim sWhereSelList As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDColumn.ColumnName + "=" + rObjRole.IDSelListEntry.ToString() + ""
                Dim arrSelListRolesUserLoeggedIn() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhereSelList, "")
                If arrSelListRolesUserLoeggedIn.Length <> 1 Then
                    Throw New Exception("getLoggedInUserHasRoleAdministrator: arrObjRolesLoggedInUser.Length<>1 for IDSelList '" + rObjRole.IDSelListEntry.ToString() + "'!")
                End If
                Dim rSelListRole As dsAdmin.tblSelListEntriesRow = arrSelListRolesUserLoeggedIn(0)
                If rSelListRole.IDOwnInt = 11 And rObjRole.Active Then
                    actUsr.UserHasRoleAdministrator = True
                End If
            Next

        Catch ex As Exception
            Throw New Exception("getLoggedInUserHasRoleAdministrator: " + ex.ToString())
        End Try
    End Sub


    Public Shared Sub readPosxy(ByVal window As System.Windows.Forms.Form)

        Dim actUsr As New actUsr
        Dim left As Integer = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainLeft, sqlAdmin.eTypSelAdjust.forClient, "")
        If left = valWinMaximized Then
            window.WindowState = Windows.Forms.FormWindowState.Maximized
        Else
            window.Left = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainLeft, sqlAdmin.eTypSelAdjust.forClient, "")
            window.Top = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainTop, sqlAdmin.eTypSelAdjust.forClient, "")
            window.Height = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainHeigth, sqlAdmin.eTypSelAdjust.forClient, "")
            window.Width = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainWidth, sqlAdmin.eTypSelAdjust.forClient, "")

            If window.Top < 1 Then window.Top = 100
            If window.Left < 1 Then window.Left = 100
            window.MinimumSize = New System.Drawing.Size(934, 682)

        End If

    End Sub
    Public Shared Sub savePosxy(ByVal window As System.Windows.Forms.Form, Optional ByVal isMaximized As Boolean = False)
        Try
            If isMaximized Then
                actUsr.adjustSave(actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainLeft, sqlAdmin.eTypSelAdjust.forClient, valWinMaximized)
            Else
                actUsr.adjustSave(actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainLeft, sqlAdmin.eTypSelAdjust.forClient, window.Left)
                actUsr.adjustSave(actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainTop, sqlAdmin.eTypSelAdjust.forClient, window.Top)
                actUsr.adjustSave(actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainHeigth, sqlAdmin.eTypSelAdjust.forClient, window.Height)
                actUsr.adjustSave(actUsr.rUsr.UserName, sqlAdmin.eAdjust.mainWidth, sqlAdmin.eTypSelAdjust.forClient, window.Width)
            End If

        Catch ex As Exception
            Throw New Exception("actUsr.savePos: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

    Public Shared Function adjustSave(ByRef UsrToSave As String, ByVal adj As qs2.core.vb.sqlAdmin.eAdjust,
                                        ByVal typ As qs2.core.vb.sqlAdmin.eTypSelAdjust,
                                        ByVal val As Object,
                                        Optional ByVal bytes() As Byte = Nothing, Optional ByVal IDParticipant As String = "",
                                        Optional alwaysInsert As Boolean = False,
                                        Optional IDGuid As System.Guid = Nothing) As Boolean

        Dim sqlAdmin1 As New sqlAdmin()
        sqlAdmin1.initControl()

        actUsr.dsAdjust1.Clear()
        Dim rAdjust As dsAdmin.tblAdjustRow = sqlAdmin1.getAdjustRow(UsrToSave, adj, typ, IDParticipant)
        If (Not alwaysInsert) And (Not rAdjust Is Nothing) Then
            sqlAdmin1.storeVal(rAdjust, val, bytes)
            Dim arrAdjust(0) As dsAdmin.tblAdjustRow
            arrAdjust(0) = rAdjust
            sqlAdmin1.daAdjust.Update(arrAdjust)
        Else
            Dim rNew As dsAdmin.tblAdjustRow = actUsr.dsAdjust1.tblAdjust.NewRow()
            If typ = sqlAdmin.eTypSelAdjust.forClient Then
                rNew.client = My.Computer.Name
                rNew.usrSetting = False
            ElseIf typ = sqlAdmin.eTypSelAdjust.forUsr Then
                rNew.client = UsrToSave.Trim()
                rNew.usrSetting = True
            Else
                rNew.client = sqlAdmin1.settingAll
                rNew.usrSetting = False
            End If
            rNew.setting = adj.ToString()
            sqlAdmin1.storeVal(rNew, val, bytes)
            actUsr.dsAdjust1.tblAdjust.Rows.Add(rNew)
            Dim arrAdjust(0) As dsAdmin.tblAdjustRow
            If alwaysInsert Then
                rNew.client += "_" + IDGuid.ToString()
            End If
            arrAdjust(0) = rNew
            sqlAdmin1.daAdjust.Update(arrAdjust)
        End If

    End Function
    Public Shared Function adjustRead(UsrToLoad As String, ByVal adj As qs2.core.vb.sqlAdmin.eAdjust, ByVal typ As qs2.core.vb.sqlAdmin.eTypSelAdjust, IDParticipant As String) As Object
        Dim sqlAdmin1 As New sqlAdmin()
        sqlAdmin1.initControl()
        Dim dsAdjustPos As New dsAdmin()
        dsAdjustPos.Clear()
        Dim rAdjust As dsAdmin.tblAdjustRow = sqlAdmin1.getAdjustRow(UsrToLoad, adj, typ, IDParticipant)
        If Not rAdjust Is Nothing Then
            If rAdjust.IsbytNull() Then
                Return sqlAdmin1.getVal(rAdjust, Nothing)
            Else
                Return rAdjust.byt
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function SetDirectorySearcher() As DirectorySearcher

        Try

            Dim dEntry As New DirectoryEntry("LDAP://" + ENV.Domäne + ":" + ENV.LDAPPort.ToString())
            Dim dSearcher As New DirectorySearcher(dEntry)
            Return dSearcher

        Catch ex As Exception
            Return New DirectorySearcher

        End Try

    End Function

    Public Function getAllUsersActiveDirectory(ByVal UsrToSearch As String) As ArrayList
        Try

            'Ausführen einer LDAP-Suche im AD
            Dim ret As New ArrayList()
            Dim ergebnisliste As SearchResultCollection

            ' --- Festlegung des Ausgangspunkts
            Dim suche As DirectorySearcher = SetDirectorySearcher()
            suche.Filter = "(&(objectCategory=person))"

            ' --- Ausgabefelder festlegen
            suche.PropertiesToLoad.Add("l")
            suche.PropertiesToLoad.Add("Description")
            suche.PropertiesToLoad.Add("cn")

            '' --- Suchtiefe festlegen
            suche.SearchScope = SearchScope.Subtree

            ' --- Suche starten
            ergebnisliste = suche.FindAll()

            ' --- Ergebnismenge ausgeben
            For Each ergebnis As System.DirectoryServices.SearchResult In ergebnisliste

                Dim entry As System.DirectoryServices.DirectoryEntry
                entry = ergebnis.GetDirectoryEntry
                Dim entryFound As DirectoryEntry = ergebnis.GetDirectoryEntry()
                ret.Add(ergebnis.Path)
                Dim usr As String = ""
                Dim de As DirectoryEntry = ergebnis.GetDirectoryEntry

            Next

            Return ret

        Catch ex As Exception
            Throw New Exception("actUsr.getAllUsersActiveDirectory: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function ValidateActiveDirectoryLogin(ByVal UsrToSearch As String, ByVal Password As String) As Boolean

        Return New PrincipalContext(ContextType.Domain, ENV.Domäne, UsrToSearch, Password).ValidateCredentials(UsrToSearch, Password, ContextOptions.Negotiate)

    End Function
    Public Function checkUserIsInActiveDirectory(ByVal UsrToSearch As String) As Boolean
        Try

            If UsrToSearch = "" Then Return False

            Dim suche As DirectorySearcher = SetDirectorySearcher()
            Dim userliste As SearchResultCollection

            suche.PropertiesToLoad.Add("SamAccountName")
            suche.Filter = "(&(objectCategory=person)(samAccountName=" + UsrToSearch + "))"
            suche.SearchScope = SearchScope.Subtree
            userliste = suche.FindAll()

            Return IIf(userliste.Count = 1, True, False)

        Catch ex As Exception
            Throw New Exception("actUsr.checkUserIsInActiveDirectory: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

End Class

