Imports System.Data.OleDb

Public Class dbBase

    Public Shared Sub setDBConnection_dataAdapter(ByRef da As System.Data.OleDb.OleDbDataAdapter)

        If Not da.SelectCommand Is Nothing Then
            If RBU.DataBase.CONNECTION.State = ConnectionState.Closed Then
                RBU.DataBase.CONNECTION.Open()
            End If
            da.SelectCommand.Connection = RBU.DataBase.CONNECTION
        End If

        If Not da.InsertCommand Is Nothing Then
            If RBU.DataBase.CONNECTION.State = ConnectionState.Closed Then
                RBU.DataBase.CONNECTION.Open()
            End If
            da.InsertCommand.Connection = RBU.DataBase.CONNECTION
        End If

        If Not da.UpdateCommand Is Nothing Then
            If RBU.DataBase.CONNECTION.State = ConnectionState.Closed Then
                RBU.DataBase.CONNECTION.Open()
            End If
            da.UpdateCommand.Connection = RBU.DataBase.CONNECTION
        End If

        If Not da.DeleteCommand Is Nothing Then
            If RBU.DataBase.CONNECTION.State = ConnectionState.Closed Then
                RBU.DataBase.CONNECTION.Open()
            End If
            da.DeleteCommand.Connection = RBU.DataBase.CONNECTION
        End If
    End Sub

    Public Shared Sub setDBConnection_dataAdapterGiboDat(ByRef da As System.Data.OleDb.OleDbDataAdapter)


        If Not da.SelectCommand Is Nothing Then
            If PMDS.Global.ENV.conGiboDat.State = ConnectionState.Closed Then
                PMDS.Global.ENV.conGiboDat.Open()
            End If
            da.SelectCommand.Connection = PMDS.Global.ENV.conGiboDat
        End If

        If Not da.InsertCommand Is Nothing Then
            If PMDS.Global.ENV.conGiboDat.State = ConnectionState.Closed Then
                PMDS.Global.ENV.conGiboDat.Open()
            End If
            da.InsertCommand.Connection = PMDS.Global.ENV.conGiboDat
        End If

        If Not da.UpdateCommand Is Nothing Then
            If PMDS.Global.ENV.conGiboDat.State = ConnectionState.Closed Then
                PMDS.Global.ENV.conGiboDat.Open()
            End If
            da.UpdateCommand.Connection = PMDS.Global.ENV.conGiboDat
        End If

        If Not da.DeleteCommand Is Nothing Then
            If PMDS.Global.ENV.conGiboDat.State = ConnectionState.Closed Then
                PMDS.Global.ENV.conGiboDat.Open()
            End If
            da.DeleteCommand.Connection = PMDS.Global.ENV.conGiboDat
        End If
    End Sub


    Public Shared Sub initRow(ByRef r As DataRow)

        For i As Integer = 0 To r.Table.Columns.Count - 1
            Dim col As New DataColumn
            col = r.Table.Columns(i)
            Dim typ As System.Type
            typ = col.DataType
            If LCase(typ.ToString) = LCase("System.Boolean") Then
                r(col.ColumnName) = False
            ElseIf LCase(typ.ToString) = LCase("System.Int32") Or LCase(typ.ToString) = LCase("System.Double") Or LCase(typ.ToString) = LCase("System.Decimal") Then
                r(col.ColumnName) = 0
            ElseIf LCase(typ.ToString) = LCase("System.String") Or LCase(typ.ToString) = LCase("System.Text") Then
                r(col.ColumnName) = ""
                'ElseIf LCase(typ.ToString) = LCase("System.Date") Or LCase(typ.ToString) = LCase("System.DateTime") Then
                '    Dim d As New DateTime
                '    r(col.ColumnName) = d   'System.DBNull.Value
                'ElseIf LCase(typ.ToString) = LCase("System.Guid") Then
                '    r(col.ColumnName) = System.Guid.Empty
            ElseIf LCase(typ.ToString) = LCase("System.Int64") Then
                r(col.ColumnName) = 0
            End If
        Next


    End Sub





    Public Shared Sub CheckNulls(ByRef r As DataRow)

        For i As Integer = 0 To r.Table.Columns.Count - 1
            Dim col As New DataColumn
            col = r.Table.Columns(i)
            Dim typ As System.Type
            typ = col.DataType

            If IsDBNull(r(col.ColumnName)) Then

                If LCase(typ.ToString) = LCase("System.Boolean") Then
                    r(col.ColumnName) = False
                ElseIf LCase(typ.ToString) = LCase("System.Int32") Or LCase(typ.ToString) = LCase("System.Double") Or LCase(typ.ToString) = LCase("System.Decimal") Then
                    r(col.ColumnName) = 0
                ElseIf LCase(typ.ToString) = LCase("System.String") Or LCase(typ.ToString) = LCase("System.Text") Then
                    r(col.ColumnName) = ""
                    'ElseIf LCase(typ.ToString) = LCase("System.Date") Or LCase(typ.ToString) = LCase("System.DateTime") Then
                    '    Dim d As New DateTime
                    '    r(col.ColumnName) = d   'System.DBNull.Value
                    'ElseIf LCase(typ.ToString) = LCase("System.Guid") Then
                    '    r(col.ColumnName) = System.Guid.Empty
                ElseIf LCase(typ.ToString) = LCase("System.Int64") Then
                    r(col.ColumnName) = 0
                End If
            End If
        Next


    End Sub

End Class
