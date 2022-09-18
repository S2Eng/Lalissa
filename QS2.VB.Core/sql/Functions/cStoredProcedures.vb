


Public Class cStoredProcedures

    Public Class cParStoredProcedure
        Public parName As String = ""
        Public oValue As New Object()
        Public parType As New System.Data.SqlDbType()
    End Class

    Public database As New qs2.core.dbBase()





    Public Function callStoredProceduresUntypedxyxy(ByRef NameStoredProcedure As String, ByRef Parameter As System.Collections.Generic.List(Of qs2.core.vb.cStoredProcedures.cParStoredProcedure)) As Boolean
        Try
            'Dim daSp As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmdSP As New System.Data.SqlClient.SqlCommand()
            cmdSP.CommandType = CommandType.StoredProcedure
            cmdSP.Connection = qs2.core.dbBase.dbConn
            'Me.database.setConnection(daSp)

            If NameStoredProcedure.Trim().ToLower().Equals(("qs2.AddCriteria").Trim().ToLower()) Then
                For Each par As cParStoredProcedure In Parameter
                    Dim newPar As New System.Data.SqlClient.SqlParameter()
                    newPar.ParameterName = par.parName
                    newPar.DbType = par.parType
                    newPar.Value = par.oValue

                    cmdSP.Parameters.Add(newPar)
                Next
                cmdSP.ExecuteNonQuery()

                Return True
                'Dim daAddCriteria As New qs2.core.vb.StoredProdueduresTableAdapters.AddCriteriaTableAdapter()
                'daAddCriteria.GetData()
            Else
                Throw New Exception("cStoredProcedures.callStoredProcedures: NameStoredProcedure '" + NameStoredProcedure + " not supported'!")
            End If

        Catch ex As Exception
            Throw New Exception("cStoredProcedures.callStoredProcedures: " + ex.ToString())
        End Try
    End Function

End Class
