Option Strict Off
Option Explicit On
Imports System.Text
Imports VB = Microsoft.VisualBasic



Public Class calculation
    Inherits calcBase


    Public Shared editorPrecalc As TXTextControl.TextControl

    Private _doBill As New doBill()
    Private _sql As New Sql
    Private _bill As New bill()

    Public Shared delgetDBContext As getDBContext = Nothing
    Public Delegate Function getDBContext() As PMDS.db.Entities.ERModellPMDSEntities

    Public Shared delCallFctMainSystem As CallFctMainSystem = Nothing
    Public Delegate Function CallFctMainSystem(TypeMainFct As eTypeMainFct, ByRef retMainSystem As retMainSystem) As Boolean
    Public Class retMainSystem
        Public ID As Nullable(Of Guid) = Nothing
        Public rBill As PMDS.db.Entities.bills = Nothing

        Public db As PMDS.db.Entities.ERModellPMDSEntities = Nothing
    End Class
    Public Enum eTypeMainFct
        getIDKlinik = 0
        NewRowBillEF = 1
    End Enum

    Public Shared delCallFctCalcs As CallFctCalcs = Nothing
    Public Delegate Function CallFctCalcs(TypeCalcsFct As eTypeCalcsFct, ByRef retMainSystem As retMainSystem) As Boolean
    Public Enum eTypeCalcsFct
        loadCalcs = 0
    End Enum

    Public Shared ZahlKondBankeinzug As String = ""
    Public Shared ZahlKondErlagschein As String = ""
    Public Shared ZahlKondÜberweisung As String = ""
    Public Shared ZahlKondBar As String = ""

    Public Shared AbwesenheitenAnzeigen As Boolean = True


    Public Class cBill
        Public rBillToStorno As dbPMDS.billsRow = Nothing
        Public IDBillNew As String = ""
    End Class

    Public Class cMwst
        Public MwstSatz As Double = 0
        Public sum As Double = 0
        Public IDKostIntern As String = ""
        Public IDKost As String = ""
    End Class
    Public Class cSelObj
        Public Property ID As String = ""
        Public Property Brutto As Decimal = 0
        Public Property IDKost As String = ""
        Public Property IDKostIntern As String = ""
        Public Property lfdNr As Integer = -1
    End Class

    Public Sub Init(ByVal connection As OleDb.OleDbConnection, ByVal KürzGrundlLetztTag As Boolean, ByVal reportPath As String,
                        ByVal bookingJN As Boolean, ByVal header As Boolean, ByVal rechFloskel As Boolean, ByVal ZAHLUNG_TAGE As String,
                        ByVal usr As String, ByVal usrID As String, ByVal bezGSBG As String, ByVal TransferTxt As String,
                        ByVal DepotgeldKontoTxt As String,
                        ByVal typRechNr As String,
                        ByVal pathConfig As String,
                        ByVal TageOhneKuerzungGrundleistung As Integer,
                        ByVal KuerzungGrundleistungLetzterTag As Boolean,
                        ByVal RechErwAbwesenheit As Boolean, ByVal SrErwAbwesenheit As Boolean,
                        ZahlKondBankeinzug As String, ZahlKondErlagschein As String, ZahlKondÜberweisung As String, ZahlKondBar As String,
                        AbwesenheitenAnzeigen As Boolean, RechTitelDepotGeld As String)
        Try
            Sql.CONNECTION = connection

            calcBase.bookingJN = bookingJN
            calcBase.KürzGrundLetztTag = KürzGrundlLetztTag
            calcBase.usr = usr
            calcBase.usrID = usrID
            calcBase.pathConfig = pathConfig                                            '<20120111-2>
            calcBase.TageOhneKuerzungGrundleistung = TageOhneKuerzungGrundleistung      'Beginn abwesenheit -  nur default    -->   TageOhneKuerzungGrundleistung
            calcBase.KuerzungGrundleistungLetzterTag = KuerzungGrundleistungLetzterTag  'Ende abwesenheit -  immer    -->           KuerzungGrundleistungLetzterTag   -> in UI
            calcBase.RechErwAbwesenheit = RechErwAbwesenheit
            calcBase.SrErwAbwesenheit = SrErwAbwesenheit

            bill.typRechNr = typRechNr
            bill.zahlTage = ZAHLUNG_TAGE
            bill.header = header
            bill.rechFloskel = rechFloskel
            bill.DepotgeldKontoTxt = DepotgeldKontoTxt
            bill.RechTitelDepotGeld = RechTitelDepotGeld
            print.reportPath = reportPath

            kostenträger.bezGSBG = bezGSBG
            kostenträger.TransferTxt = TransferTxt

            calculation.ZahlKondBankeinzug = ZahlKondBankeinzug
            calculation.ZahlKondErlagschein = ZahlKondErlagschein
            calculation.ZahlKondÜberweisung = ZahlKondÜberweisung
            calculation.ZahlKondBar = ZahlKondBar
            calculation.AbwesenheitenAnzeigen = AbwesenheitenAnzeigen

            MWSTSätze.loadMWSTSätzeFromFile()

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function Run(ByVal IDKlient As String, ByVal von As DateTime, ByVal bis As DateTime, ByVal RechDatum As Date, ByVal clearCalcDB As Boolean,
                                ByVal calcTyp As PMDS.Calc.Logic.eCalcTyp,
                                ByVal calcRun As PMDS.Calc.Logic.eCalcRun,
                                ByVal editor As TXTextControl.TextControl, IDKlinik As System.Guid,
                                ByVal Bereich As String, ByRef Prot As String, ByRef iCounterProt As Integer) As calcData
        Try
            calcBase.errTxt = ""
            Dim calc As New calcData()

            Dim monate As New monate()
            Dim MWSTSätze As New MWSTSätze()
            Dim klient As New klient()
            Dim abwesenheit As New abwesenheit()
            Dim anwesenheit As New anwesenheit()
            Dim leistung As New leistung()
            Dim doCalc As New doCalc()
            Dim doBill As New doBill()

            bill.Bereich = Bereich

            Using dbPMDSRead As New dbPMDS()
                Using dtMWSTSätze As New dbPMDS.MWSTSätzeDataTable
                    monate.init(von, bis, RechDatum, calc)
                    MWSTSätze.init(dtMWSTSätze)
                    Dim rKlinikDat As dbPMDS.KlinikRow
                    sql.readKlinik(dbPMDSRead, IDKlinik)
                    rKlinikDat = dbPMDSRead.Klinik.Rows(0)
                    klient.init(VB.LCase(IDKlient), von, bis, calcTyp, calcRun, calc, dtMWSTSätze, IDKlinik, rKlinikDat)
                End Using
            End Using

            anwesenheit.prepare(calc, IDKlinik)
            abwesenheit.prepare(calc)

            If calc.dbCalc.Leistungen.Rows.Count > 0 Then
                leistung.doTagesLeist(calc)
                If Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then
                    doCalc.runFreeBill(calc)
                Else
                    doCalc.run(calc)
                End If

                doBill.run(calc, editor, IDKlinik, Bereich, Prot, iCounterProt)

                If Me.rowKlient(calc.dbCalc).calcTyp = CInt(eCalcTyp.abrechnung) Then
                    doBill.save(eBillStatus.offen, calc, IDKlinik)
                End If
            End If
            Return calc

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub Load(ByRef klienten As ArrayList, ByVal von As DateTime, ByVal bis As DateTime, vonRechDatum As Nullable(Of DateTime), bisRechDatum As Nullable(Of DateTime),
                    ByRef db As dbPMDS, ByVal rechTyp As PMDS.Calc.Logic.eBillTyp,
                    ByVal status As PMDS.Calc.Logic.eBillStatus, ByVal allKlients As Boolean, IDKlinik As System.Guid, showFreigegebenAndStorniert As Boolean, showExportiere As Boolean, RechNr As String)

        calcBase.errTxt = ""
        For Each IDKlient As String In klienten
            Me._sql.readBills(IDKlient, von, bis, vonRechDatum, bisRechDatum, db, rechTyp, status, allKlients, IDKlinik, showFreigegebenAndStorniert, showExportiere, RechNr)
        Next

        For Each r As dbPMDS.billsRow In db.bills
            Me._sql.readBillHeader(r.ID, db, IDKlinik)
        Next
    End Sub

    Public Sub Load(ByVal von As DateTime, ByVal bis As DateTime, vonErstelltAm As Nullable(Of DateTime), bisErstelltAm As Nullable(Of DateTime),
                ByRef db As dbPMDS, ByVal rechTyp As PMDS.Calc.Logic.eBillTyp,
                ByVal status As PMDS.Calc.Logic.eBillStatus, ByVal allKlients As Boolean, IDKlinik As System.Guid, showFreigegebenAndStorniert As Boolean, showExportiere As Boolean, RechNr As String)
        calcBase.errTxt = ""
        Me._sql.readBills("", von, bis, vonErstelltAm, bisErstelltAm, db, rechTyp, status, allKlients, IDKlinik, showFreigegebenAndStorniert, showExportiere, RechNr)
        For Each r As dbPMDS.billsRow In db.bills
            Me._sql.readBillHeader(r.ID, db, IDKlinik)
        Next
    End Sub

    Public Sub delete(ByVal IDAbrechnung As String, ByVal sr As Boolean, ByVal depot As Boolean, ByVal IDKlinik As System.Guid)
        calcBase.errTxt = ""
        Me._doBill.delete(IDAbrechnung, sr, depot, IDKlinik)
    End Sub

    Public Sub freigeben(ByVal listIDBills As System.Collections.Generic.List(Of String), ByVal sr As Boolean,
                                ByVal editor As TXTextControl.TextControl, ByVal IDKlinik As System.Guid, rechDat As Nullable(Of Date))
        calcBase.errTxt = ""

        'this.calculation.stornieren(listID, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, this.form.editor, PMDS.Global.ENV.IDKlinik);
        Dim listIDDoStorno As New System.Collections.Generic.List(Of dbPMDS.billsRow)()
        Me._doBill.doAction(listIDBills, sr, editor, "f", IDKlinik, False, listIDDoStorno, rechDat)
    End Sub

    Public Sub stornieren(ByVal listIDBills As System.Collections.Generic.List(Of String), ByVal sr As Boolean,
                                ByVal editor As TXTextControl.TextControl, ByVal IDKlinik As System.Guid, datStornodatum As Nullable(Of Date), dbCalcFoundNew As dbCalc)
        calcBase.errTxt = ""
        Dim listIDDoStorno As New System.Collections.Generic.List(Of dbPMDS.billsRow)()
        Me._doBill.doAction(listIDBills, sr, editor, "s", IDKlinik, False, listIDDoStorno, datStornodatum, dbCalcFoundNew)
    End Sub

    Public Shared Function getDbEntityValidationException(ex As System.Data.Entity.Validation.DbEntityValidationException) As String
        Dim sb As New StringBuilder()
        For Each failure As Entity.Validation.DbEntityValidationResult In ex.EntityValidationErrors
            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType())
            For Each err As Entity.Validation.DbValidationError In failure.ValidationErrors
                sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage)
                sb.AppendLine()
            Next
        Next
        Return "Entity Validation Failed - errors follow:\n" + sb.ToString()
    End Function

End Class