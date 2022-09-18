


Public Class doProductsAll


    Public Shared dsAdmin1 As qs2.core.vb.dsAdmin
    Public Shared sqlAdmin1 As qs2.core.vb.sqlAdmin
    Public Shared Initialized As Boolean = False





    Public Shared Sub initilize()
        Try
            If Not doProductsAll.Initialized Then
                doProductsAll.dsAdmin1 = New qs2.core.vb.dsAdmin()
                doProductsAll.sqlAdmin1 = New qs2.core.vb.sqlAdmin()
                sqlAdmin1.initControl()
                doProductsAll.Initialized = True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Shared Function getCriteria(ByVal FieldName As String, ByVal Application As qs2.core.license.doLicense.eApp) As qs2.core.vb.dsAdmin.tblCriteriaRow
        Try
            doProductsAll.initilize()

            doProductsAll.dsAdmin1.Clear()
            Dim arrCriterias() As qs2.core.vb.dsAdmin.tblCriteriaRow = doProductsAll.sqlAdmin1.getCriterias(doProductsAll.dsAdmin1, _
                                                                                                            qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, _
                                                                                                            FieldName, Application.ToString(), False, False, _
                                                                                                            False, "", "", False)
            If arrCriterias.Length = 1 Then
                Return arrCriterias(0)
            ElseIf doProductsAll.dsAdmin1.tblCriteria.Rows.Count = 0 Then
                Return Nothing
            Else
                Throw New Exception("getCriteria: Mord than 1 Row found in Criteria for Field '" + FieldName + "'")
            End If

        Catch ex As Exception
            Throw New Exception("doProductsAll.getCriteria:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Shared Function getCriteriaOptions(ByVal FieldName As String, ByVal Application As String) As qs2.core.vb.dsAdmin.tblCriteriaOptRow()
        Try
            doProductsAll.initilize()

            doProductsAll.dsAdmin1.Clear()
            Dim arrCriteriasOpt() As qs2.core.vb.dsAdmin.tblCriteriaOptRow = doProductsAll.sqlAdmin1.getCriteriasOpt(doProductsAll.dsAdmin1, core.vb.sqlAdmin.eTypSelCriteriaOpt.idRam, FieldName, Application)
            Return arrCriteriasOpt

        Catch ex As Exception
            Throw New Exception("doProductsAll.getCriteriaOptions:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

End Class


