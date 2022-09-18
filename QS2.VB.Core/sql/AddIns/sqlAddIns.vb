Imports qs2.core.vb



Public Class sqlAddIns

    Public db1 As New qs2.core.dbBase
    Public sel_daAddIn As String = ""
    Public database As New qs2.core.dbBase

    Public Enum eTypSelAddIn
        ID = 0
        AddInName = 1
        allActivated = 2
    End Enum




    Public Sub initControl()
        Me.sel_daAddIn = Me.daAddIns.SelectCommand.CommandText
    End Sub

    Public Function getAllAddIns(ByVal id As System.Guid, ByRef ds As dsAddIn, ByVal typSel As eTypSelAddIn, AddInName As String) As Boolean
        Me.daAddIns.SelectCommand.CommandText = Me.sel_daAddIn
        database.setConnection(Me.daAddIns)
        Me.daAddIns.SelectCommand.Parameters.Clear()

        If typSel = eTypSelAddIn.ID Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.AddIns.IDColumn.ColumnName)
            Me.daAddIns.SelectCommand.CommandText += sWhere
            Me.daAddIns.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.AddIns.IDColumn.ColumnName), id)

        ElseIf typSel = eTypSelAddIn.AddInName Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.AddIns.AddInNameColumn.ColumnName)
            Me.daAddIns.SelectCommand.CommandText += sWhere
            Me.daAddIns.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.AddIns.AddInNameColumn.ColumnName), AddInName)

        ElseIf typSel = eTypSelAddIn.allActivated Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.AddIns.ActivatedColumn.ColumnName)
            Me.daAddIns.SelectCommand.CommandText += sWhere
            Me.daAddIns.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.AddIns.ActivatedColumn.ColumnName), True)

        Else
            Throw New Exception("sqlAddIns.getAllAddIns: TypSel '" + typSel.ToString() + "' is wrong!")

        End If

        Me.daAddIns.Fill(ds.AddIns)
        Return True

    End Function

    Public Function newRowAddIn(dsAddIn1 As dsAddIn) As dsAddIn.AddInsRow

        Dim rNew As dsAddIn.AddInsRow = dsAddIn1.AddIns.NewRow()
        rNew.ID = System.Guid.NewGuid()
        rNew.Activated = False
        rNew.AddInName = ""
        rNew.Dll = ""
        rNew.Type = ""
        rNew.Description = ""
        rNew.Group = ""
        rNew.Place = ""
        rNew.SetActivatedAtNull()
        rNew.SetActivatedFromNull()

        dsAddIn1.AddIns.Rows.Add(rNew)
        Return rNew

    End Function
    Public Function deleteAddIn(ByVal IDAddIn As System.Guid) As Boolean
        Try
            Dim ds As New dsAddIn()
            Dim cmd As New SqlClient.SqlCommand
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.AddIns.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.AddIns.IDColumn.ColumnName)
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.AddIns.IDColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.AddIns.IDColumn.ColumnName))).Value = IDAddIn
            cmd.Connection = _dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlAddIns.deleteAddIn: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

End Class
