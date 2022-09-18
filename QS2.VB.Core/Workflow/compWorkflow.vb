


Public Class compWorkflow


    Public Function getNewImportInterfaceRow(ByVal ds As dsWorkflow) As dsWorkflow.tblImportInterface1Row

        Dim rImportInterface As dsWorkflow.tblImportInterface1Row = ds.tblImportInterface1.NewRow
        qs2.core.dbBase.initRow(rImportInterface, qs2.core.generic.idMinus, False)
        ds.tblImportInterface1.Rows.Add(rImportInterface)
        Return rImportInterface

    End Function

End Class
