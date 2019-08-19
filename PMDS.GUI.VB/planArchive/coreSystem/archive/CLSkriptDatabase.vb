Imports System.Drawing
Imports System.Data.OleDb
Imports System.IO



Public Class CLSkriptDatabase

    Private s2General As New GeneralArchiv

    Public Sub ClearDatabaseArchiv()
        Try

            Dim DataSet As New DataSet("Table")
            Dim DataTable As New DataTable
            Dim Command As New OleDbCommand
            Dim Parameter As OleDbParameter
            Dim DataAdapter As New OleDbDataAdapter
            Dim DataRow As DataRow

            Dim conn As New db

            Command.Parameters.Clear()
            Command = New OleDbCommand("ClearArchiv", conn.getConnDB)
            Command.CommandType = CommandType.StoredProcedure
            Command.ExecuteNonQuery()

        Catch ex As Exception
            s2General.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub


End Class
