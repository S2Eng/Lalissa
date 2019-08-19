Imports System.Data.OleDb


Public Class aktZeit


    Public Sub New()

    End Sub

    Public Function getAktTimeFromSQLServer() As DateTime
        Dim gen As New GeneralArchiv
        Try

            Dim DataTable As New DataTable
            Dim Command As New OleDbCommand
            Dim DataAdapter As New OleDbDataAdapter
            Dim Sql As String

            Dim conn As New  db

            Sql = "SELECT aktDatum from getAktDate "
            Command = New OleDbCommand(Sql, conn.getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return DataTable.Rows(0)("aktDatum")

        Catch ex As OleDbException
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function



End Class
