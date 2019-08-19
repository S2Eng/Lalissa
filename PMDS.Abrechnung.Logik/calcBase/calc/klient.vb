Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class klient
    Inherits calcBase


    Public Sub init(ByRef IDKlient As String, ByRef von As Date, ByRef bis As Date, _
                   ByVal CalcTyp As PMDS.Calc.Logic.eCalcTyp, ByVal calcRun As PMDS.Calc.Logic.eCalcRun, _
                   ByRef calc As calcData, ByRef MWSTSätze As dbPMDS.MWSTSätzeDataTable, IDKlinik As System.Guid, _
                   ByRef rKlinikDat As dbPMDS.KlinikRow)
        Try
            Dim qryPat As dbQuery = Me.sql.run("SELECT * FROM Patient WHERE LOWER(ID) = '" & IDKlient & "'", Nothing)
            If qryPat.table.Rows.Count = 1 Then
                Dim rNew As dbCalc.KlientRow = calc.dbCalc.Klient.NewRow()
                rNew.Nachname = qryPat.table.Rows(0)("Nachname")
                rNew.Vorname = qryPat.table.Rows(0)("Vorname")
                rNew.ID = VB.LCase(qryPat.table.Rows(0)("ID").ToString())
                rNew.ZuschlagGrundleistungBetrag = 0
                rNew.ZuschlagGrundleistungJN = False
                rNew.ZuschlagGrundleistungProzent = 0
                rNew.Version = calcBase.Version
                rNew.IDKlinik = IDKlinik
                rNew.KlinikName = rKlinikDat.Bezeichnung.Trim()
                rNew.KürzungLetzterTagAnwesenheit = qryPat.table.Rows(0)("KürzungLetzterTagAnwesenheit")
                'rNew.Version = calcBase.Version
                rNew.calcTyp = CInt(CalcTyp)
                If calcRun = eCalcRun.all Then Throw New Exception("klient.init: Typ eCalcRun.all not allowed!")
                rNew.calcRun = CInt(calcRun)
                calc.dbCalc.Klient.Rows.Add(rNew)
            Else
                Throw New Exception("calc.start: IDKlient '" + IDKlient.ToString() + "' nicht gefunden!")
            End If

            Dim aufenthalt As New Aufenthalt()
            aufenthalt.init(IDKlient, von, bis, calc, IDKlinik)

            Dim abwesenheit As New abwesenheit()
            abwesenheit.init(IDKlient, von, bis, calc, IDKlinik)

            Dim kostenträger As New kostenträger()
            kostenträger.init(IDKlient, von, bis, calc, MWSTSätze, IDKlinik)

            Dim leistung As New leistung()
            leistung.init(IDKlient, von, bis, calc, IDKlinik, calcRun)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


End Class
