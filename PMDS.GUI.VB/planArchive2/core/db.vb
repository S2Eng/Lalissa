Imports System.Data.OleDb


Public Class db

    Public Shared typeString As String = "System.String"
    Public Shared typeBoolean As String = "System.Boolean"
    Public Shared typeDate As String = "System.Date"
    Public Shared typeDateTime As String = "System.DateTime"
    Public Shared typeInt32 As String = "System.Int32"
    Public Shared typeInt64 As String = "System.In642"
    Public Shared typeDouble As String = "System.Double"
    Public Shared typeDecimal As String = "System.Decimal"
    Public Shared typeGuid As String = "System.Guid"
    Public Shared typeDBNull As String = "System.DBNull"

    Public gen As New General()





    Public Function getConnDB() As OleDbConnection
        Return RBU.DataBase.CONNECTION
    End Function

    Public Sub initRow(ByRef r As DataRow)
        Try

            For i As Integer = 0 To r.Table.Columns.Count - 1
                Dim col As New DataColumn
                col = r.Table.Columns(i)
                Dim typ As System.Type
                typ = col.DataType
                If LCase(typ.ToString) = LCase("System.Boolean") Then
                    r(col.ColumnName) = False
                ElseIf LCase(typ.ToString) = LCase("System.Int32") Or LCase(typ.ToString) = LCase("System.Double") Then
                    r(col.ColumnName) = 0
                ElseIf LCase(typ.ToString) = LCase("System.String") Then
                    r(col.ColumnName) = ""
                ElseIf LCase(typ.ToString) = LCase("System.Date") Or LCase(typ.ToString) = LCase("System.DateTime") Then
                    Dim d As New DateTime
                    r(col.ColumnName) = d   'System.DBNull.Value
                ElseIf LCase(typ.ToString) = LCase("System.Guid") Then
                    r(col.ColumnName) = System.Guid.Empty
                ElseIf LCase(typ.ToString) = LCase("System.Int64") Then
                    r(col.ColumnName) = 0
                End If
            Next

        Catch ex As Exception
            Throw New Exception("db.initRow: " + ex.ToString())
        End Try
    End Sub


    Public Function getAktTimeFromSQLServer() As DateTime
        Dim gen As New GeneralArchiv
        Try

            Dim DataTable As New DataTable
            Dim Command As New OleDbCommand
            Dim DataAdapter As New OleDbDataAdapter
            Dim Sql As String

            Dim conn As New db

            Sql = "SELECT aktDatum from getAktDate "
            Command = New OleDbCommand(Sql, conn.getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return DataTable.Rows(0)("aktDatum")

        Catch ex As OleDbException
            Throw New Exception("db.getAktTimeFromSQLServer: " + ex.ToString())
        End Try
    End Function

    Public Sub setDBConnection_dataAdapter(ByRef da As System.Data.OleDb.OleDbDataAdapter)
        Try
            'da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            If Not Me.gen.IsNull(da.SelectCommand) Then
                da.SelectCommand.Connection = Me.getConnDB()
                da.SelectCommand.CommandTimeout = 0
            End If
            If Not Me.gen.IsNull(da.InsertCommand) Then
                da.InsertCommand.Connection = Me.getConnDB()
                da.InsertCommand.CommandTimeout = 0
            End If
            If Not Me.gen.IsNull(da.UpdateCommand) Then
                da.UpdateCommand.Connection = Me.getConnDB()
                da.UpdateCommand.CommandTimeout = 0
            End If
            If Not Me.gen.IsNull(da.DeleteCommand) Then
                da.DeleteCommand.Connection = Me.getConnDB()
                da.DeleteCommand.CommandTimeout = 0
            End If

        Catch ex As Exception
            Throw New Exception("db.setDBConnection_dataAdapter: " + ex.ToString())
        End Try
    End Sub

End Class
