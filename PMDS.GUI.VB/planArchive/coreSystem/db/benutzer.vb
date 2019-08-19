Imports System.Data.OleDb



Public Class benutzer
    Inherits db

    Public DataTable As New DataTable
    Private Command As New OleDbCommand
    Private DataAdapter As New OleDbDataAdapter
    Private Sql As String

    Public gen As New GeneralArchiv()



    Public Function alleBenutzerLesen(ByVal searchTxt As String) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = " SELECT Benutzer, Vorname, Nachname, ID FROM Benutzer "
            If searchTxt <> "" Then Sql += " where Benutzer like '%" + searchTxt + "%' "
            Sql += " order by Benutzer asc "

            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function
    Public Function BenutzerLesen(ByVal ben As String) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = " SELECT Benutzer, Vorname, Nachname, ID FROM Benutzer  where Benutzer = '" + ben + "' "

            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function


End Class
