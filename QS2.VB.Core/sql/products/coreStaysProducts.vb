Imports qs2.core


Public Class coreStaysProducts

    Private _r As Object = Nothing






    Public Sub initControl(Application As String)
        Try


            Return

        Catch ex As Exception
            Throw New Exception("coreStaysProducts.initControl: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub


    Public Property r() As Object
        Get
            Return Me._r
        End Get
        Set(value As Object)
            Me._r = value
        End Set
    End Property

    Public Function getField(FieldName As String) As Object
        Return Me.r.getField(FieldName)
    End Function
    Public Function setField(FieldName As String, val As Object) As Object
        Return Me.r.setField(FieldName, val)
    End Function


    Public Function ColumnNameExists(ColumnName As String) As Boolean
        Try
            Return Me._r.ColumnNameExists(ColumnName)

        Catch ex As Exception
            Throw New Exception("coreStaysProducts.ColumnNameExists: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function loadStays(ByVal rStay As qs2.core.vb.dsObjects.tblStayRow, IDApplication As String) As Boolean
        Try
            Me.r.getSelectCommands(IDApplication)
            Me.r.runSelect(rStay.ID, rStay.IDParticipant, rStay.IDApplication)
            Return True

        Catch ex As OleDb.OleDbException
            qs2.core.dbBase.getOleDbException(ex)
        Catch ex As Exception
            Throw New Exception("coreStaysProducts.loadStays: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function saveStays(ByVal rStay As qs2.core.vb.dsObjects.tblStayRow, IDApplication As String) As Boolean
        Try
            Me.r.getUpdateCommands(IDApplication)
            Me.r.runUpdate(rStay.ID, rStay.IDParticipant, rStay.IDApplication)
            Return True

        Catch ex As Exception
            Throw New Exception("coreStaysProducts.saveStays: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function deleteStays(ByVal tableName As String, ByVal id As Integer) As Boolean
        Try
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + tableName + sqlTxt.where + sqlTxt.getColWhere(qs2.core.sqlTxt.columnID)
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(qs2.core.sqlTxt.columnID), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(qs2.core.sqlTxt.columnID))).Value = id
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("coreStaysProducts.deleteStays: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

End Class
