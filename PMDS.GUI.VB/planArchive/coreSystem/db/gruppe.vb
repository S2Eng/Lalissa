Imports System.Data.OleDb



Public Class gruppe
    Inherits db

    Public DataTable As New DataTable
    Private Command As New OleDbCommand
    Private DataAdapter As New OleDbDataAdapter
    Private Sql As String




    Public Function alleGruppenLesen(ByVal searchTxt As String) As Boolean
        Dim gen As New GeneralArchiv()
        Try
            Me.Command.Parameters.Clear()

            Sql = " SELECT Bezeichnung, ID FROM Gruppe"
            If searchTxt <> "" Then Sql += " where Bezeichnung like '%" + searchTxt + "%' "
            Sql += " order by Bezeichnung asc "

            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function
    Public Function GruppenLesen(ByVal grp As String) As Boolean
        Dim gen As New GeneralArchiv()
        Try
            Me.Command.Parameters.Clear()

            Sql = " SELECT Bezeichnung, ID FROM Gruppe  where Bezeichnung = '" + grp + "' "

            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function


End Class
