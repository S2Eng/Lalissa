
Imports System.Data.OleDb
Imports VB = Microsoft.VisualBasic



Public Class compUserAccounts


    Public Shared daSelUserAccounts As String = ""

    Public Enum eTypSelUserAccounts
        allTypEMailAccount = 0
        id = 10
        usr = 11
        PostOfficeBoxForAll = 12
    End Enum
    Public Enum eTypEMailAccount
        Pop3 = 0
        SMTP = 1
    End Enum

    Public gen As New General()
    Public database As New db()







    Public Function getUserAccountsRow(ByVal id As System.Guid, ByVal usr As String, ByVal typSel As eTypSelUserAccounts,
                                    ByVal typAccount As eTypEMailAccount,
                                    ByVal doExcepNoEntryFound As Boolean,
                                    ByVal doExcepMoreThanOneEntryFound As Boolean) As dsUserAccounts.tblUserAccountsRow
        Try
            Dim ds As New dsUserAccounts()
            Me.getUserAccounts(id, usr, ds, typSel, typAccount, False)
            If ds.tblUserAccounts.Rows.Count = 0 Then
                If doExcepNoEntryFound Then
                    Throw New Exception("getUserAccountsRow.id: No Entry for User '" + usr.ToString() + "' and '" + id.ToString() + "' found!")
                End If
                Return Nothing
            ElseIf ds.tblUserAccounts.Rows.Count = 1 Then
                Return ds.tblUserAccounts.Rows(0)
            ElseIf ds.tblUserAccounts.Rows.Count > 1 Then
                If doExcepMoreThanOneEntryFound Then
                    Throw New Exception("getUserAccountsRow.id: More than one Entry for User '" + usr.ToString() + "' and '" + id.ToString() + "' found!")
                    Return Nothing
                Else
                    Return ds.tblUserAccounts.Rows(0)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("compUserAccounts.getUserAccountsRow: " + ex.ToString())
        End Try
    End Function
    Public Function getUserAccounts(ByVal id As System.Guid, ByVal usr As String, ByRef ds As dsUserAccounts, ByVal typSel As eTypSelUserAccounts,
                                    ByVal typAccount As eTypEMailAccount, ByVal PostOfficeBoxForAll As Boolean) As Boolean
        Try
            Me.daUserAccounts.SelectCommand.CommandText = Me.daSelUserAccounts
            Me.database.setDBConnection_dataAdapter(Me.daUserAccounts)
            Me.daUserAccounts.SelectCommand.Parameters.Clear()

            If typSel = eTypSelUserAccounts.allTypEMailAccount Then
                Dim sWhere As String = " where typ = ? "
                If usr.Trim() <> "" Then
                    sWhere += " and Usr = ? "
                End If
                Me.daUserAccounts.SelectCommand.CommandText += sWhere
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("typ", typAccount.ToString())
                If usr.Trim() <> "" Then
                    Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("Usr", usr.Trim())
                End If

            ElseIf typSel = eTypSelUserAccounts.usr Then
                Dim sWhere As String = " where typ = ? and Usr = ? "
                Me.daUserAccounts.SelectCommand.CommandText += sWhere
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("typ", typAccount.ToString())
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("Usr", usr.ToString())

            ElseIf typSel = eTypSelUserAccounts.PostOfficeBoxForAll Then
                Dim sWhere As String = " where typ = ? and PostOfficeBoxForAll = ? "
                Me.daUserAccounts.SelectCommand.CommandText += sWhere
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("typ", typAccount.ToString())
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("PostOfficeBoxForAll", PostOfficeBoxForAll)

            ElseIf typSel = eTypSelUserAccounts.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daUserAccounts.SelectCommand.CommandText += sWhere
                Me.daUserAccounts.SelectCommand.Parameters.AddWithValue("ID", id)

            Else
                Throw New Exception("getUserAccounts: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daUserAccounts.Fill(ds.tblUserAccounts)
            Return True

        Catch ex As Exception
            Throw New Exception("compUserAccounts.getUserAccounts: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowUserAccounts(ByVal tUserAccounts As dsUserAccounts.tblUserAccountsDataTable) As dsUserAccounts.tblUserAccountsRow
        Try
            Dim rNew As dsUserAccounts.tblUserAccountsRow = tUserAccounts.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.Usr = ""
            rNew.typ = ""
            rNew.AdrFrom = ""
            rNew.AdrTo = ""
            rNew.Server = ""
            rNew.UsrAuthentication = ""
            rNew.PwdAuthentication = ""
            rNew.Port = ""
            rNew.SSL = False
            rNew.Name = ""
            rNew.SetIDAccountNull()
            rNew.SetlastReceiveNull()
            rNew.PostOfficeBoxForAll = False
            rNew.PreferPostOfficeBoxForAll = False
            rNew.OutlookWebAPI = False

            tUserAccounts.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compUserAccounts.getNewRowUserAccounts: " + ex.ToString())
        End Try
    End Function

    Public Function updatelastReceive(ByVal idUserAccount As System.Guid, ByVal lastReceive As Date) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  tblUserAccounts set lastReceive = ?  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.AddWithValue("gesendetAm", lastReceive)
            cmd.Parameters.AddWithValue("ID", idUserAccount)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compUserAccounts.updatelastReceive: " + ex.ToString())
        End Try
    End Function

End Class
