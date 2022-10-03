Imports System.Data.OleDb
Imports qs2.core
Imports qs2.core.vb
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Public Class actUsr
    Public Shared rUsr As dsObjects.tblObjectRow
    Public Shared valWinMaximized As Integer = -32000
    Private Shared dsAdjust1 As New dsAdmin()
    Public Shared __UserHasRigthSetCompleted As Boolean = False
    Public Shared sqlAdminRights As sqlAdmin = Nothing
    Public Shared dsAdminRights As dsAdmin = Nothing
    Public Shared sqlAdminRights_Systemuser As sqlAdmin = Nothing
    Public Shared dsAdminRights_Systemuser As dsAdmin = Nothing
    Public Shared UserHasRoleAdministrator As Boolean = False

    Public Shared Function loadActUsr(ByVal ID As Integer, bDesignMode As Boolean) As Boolean
        Try
            Dim sqlObjects1 As New sqlObjects
            Dim dsObjectUsr As New dsObjects()
            dsObjectUsr.Clear()
            sqlObjects1.initControl()
            actUsr.rUsr = sqlObjects1.getObjectRow(ID, sqlObjects.eTypSelObj.ID)

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

        Catch ex As Exception
            Throw New Exception("actUsr.checkRight: Right: " + sExcept + vbNewLine + vbNewLine + ex.ToString())
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

    Public Function SetDirectorySearcher() As DirectorySearcher

        Try

            Dim dEntry As New DirectoryEntry("LDAP://" + ENV.Domäne + ":" + ENV.LDAPPort.ToString())
            Dim dSearcher As New DirectorySearcher(dEntry)
            Return dSearcher

        Catch ex As Exception
            Return New DirectorySearcher

        End Try

    End Function
End Class

