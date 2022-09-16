

Public Class dbExport


    Public Function getNewRowExportKostenträger(ByVal ds As dsExport) As dsExport.ExportKostentraegerRow
        Dim rNew As dsExport.ExportKostentraegerRow = ds.ExportKostentraeger.NewRow()
        rNew.KontoNr = ""
        rNew.Name = ""
        rNew.Message = ""
        rNew.Matchcode = ""
        rNew.Strasse = ""
        rNew.Postltz = ""
        rNew.Ort = ""
        rNew.Platzhalter = ""
        rNew.Sammelkonto = ""
        rNew.IDKostenträger = System.Guid.NewGuid()

        ds.ExportKostentraeger.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function getNewRowExportBMD(ByVal ds As dsExport, BMDExportTyp As PMDS.Calc.Logic.workCalcDb.eBMDExportTyp) As dsExport.ExportBMDRow
        Dim rNew As dsExport.ExportBMDRow = ds.ExportBMD.NewRow()
        rNew.konto = ""
        rNew.buchdatum = ""
        rNew.gkonto = ""
        rNew.buchcode = "1"
        rNew.belegnr = ""
        rNew.belegdatum = ""
        rNew.prozent = 0
        rNew.betrag = 0
        rNew.steuer = 0
        rNew.text = ""
        rNew.zziel = "0"
        rNew.skontopz = "0"
        rNew.skontotage = "0"
        If BMDExportTyp = workCalcDb.eBMDExportTyp.Standard Then
            rNew.buchsymbol = "AR"
        ElseIf BMDExportTyp = workCalcDb.eBMDExportTyp.MZ Then
            rNew.buchsymbol = "AF"
        End If

        rNew.TypBill = ""
        rNew.IDBillHeader = ""
        rNew.IDBill = ""
        rNew.IDKostIntern = ""
        rNew.IDSR = ""

        rNew.Satzart = 0
        rNew.steuercode = 0
        rNew.ExportiertJN = False

        rNew.IDKostSub = Guid.Empty
        rNew.FiBuKostSub = ""
        rNew.koperiode = ""
        ds.ExportBMD.Rows.Add(rNew)
        Return rNew
    End Function

End Class
