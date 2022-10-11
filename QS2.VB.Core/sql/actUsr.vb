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

            actUsr.UserHasRigthSetCompleted = True
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


    Public Shared Property UserHasRigthSetCompleted() As Boolean
        Get
            Return actUsr.__UserHasRigthSetCompleted
        End Get
        Set(value As Boolean)
            actUsr.__UserHasRigthSetCompleted = value
        End Set
    End Property
End Class

