

Public Class compSql

    Public selLayoutGrid As String = ""
    Public selLayout As String = ""

    Public Shared iCouterException As Integer = 0




    Public Sub initControl()
        Me.selLayout = Me.daLayout.SelectCommand.CommandText
        Me.selLayoutGrid = Me.daLayoutGrid.SelectCommand.CommandText
    End Sub

    Public Function getLayoutGrid(ByVal IDLayout As System.Guid, ByRef dsLayoutGrid1 As dsManage) As Boolean
        Try
            Me.daLayoutGrid.SelectCommand.CommandText = Me.selLayoutGrid
            Me.daLayoutGrid.SelectCommand.Connection = Settings._conn2
            Me.daLayoutGrid.SelectCommand.Parameters.Clear()

            Dim sWhere As String = " where IDLayout = @IDLayout "
            Dim sOrderBy As String = " order by Band asc, Sort asc "
            Me.daLayoutGrid.SelectCommand.CommandText += sWhere + sOrderBy
            Me.daLayoutGrid.SelectCommand.Parameters.AddWithValue("@IDLayout", IDLayout)

            Me.daLayoutGrid.Fill(dsLayoutGrid1.LayoutGrids)
            compSql.iCouterException = 0
            Return True

        Catch ex As Exception
            If Me.checkExceptionOpendDataReader(ex.ToString()) Then
                Me.getLayoutGrid(IDLayout, dsLayoutGrid1)
                Return True
            Else
                Throw New Exception("compSql.getLayoutGrid: " + ex.ToString())
            End If
        End Try
    End Function

    Public Function getLayout(ByRef dsLayout As dsManage, ByVal LayoutName As String, ByVal IDGuid As System.Guid, ByVal key As String) As Boolean
        Try
            Me.daLayout.SelectCommand.CommandText = Me.selLayout
            Me.daLayout.SelectCommand.Connection = Settings._conn2
            Me.daLayout.SelectCommand.Parameters.Clear()
            Me.daLayout.SelectCommand.Parameters.Clear()

            Dim sWhere As String = " where [Key] = @Key "
            Me.daLayout.SelectCommand.CommandText += sWhere
            Me.daLayout.SelectCommand.Parameters.AddWithValue("@Key", key.Trim())

            Me.daLayout.Fill(dsLayout.Layout)
            compSql.iCouterException = 0
            Return True

        Catch ex As Exception
            If Me.checkExceptionOpendDataReader(ex.ToString()) Then
                Me.getLayout(dsLayout, LayoutName, IDGuid, key)
                Return True
            Else
                compSql.iCouterException = 0
                Throw New Exception("compSql.getLayout: " + ex.ToString())
            End If
        End Try
    End Function

    Public Function checkExceptionOpendDataReader(sExcept As String)
        If compSql.iCouterException >= 5 Then
            Return False
        Else
            If sExcept.Contains(("bereits ein geöffneter DataReader").Trim()) Then
                QS2.core.generic.WaitMilli(200)
                compSql.iCouterException += 1
                Return True
            Else
                Return False
            End If
        End If
    End Function

End Class
