Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic





Public Class doSr
    Inherits calcBase


    Public booking As New booking()
    Public bill As New bill()
    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public print As New print()
    Public doRollung1 As New doRollung()


    Public Class cPatients
        Public IDPatient As String = ""
        Public IDKost As String = ""
        Public IDBill As String = ""
    End Class







    Public Sub run(ByVal IDKost As String, ByVal monat As DateTime, ByVal rechDatum As DateTime,
                          ByVal editor As TXTextControl.TextControl, IDKlinik As System.Guid, ByRef lstSelPatients As System.Collections.Generic.List(Of cPatients))
        Try
            calcBase.errTxt = ""
            IDKost = IDKost.ToLower()

            'Me.sql.alleAllgKostSR_Klienten(dbSR, monat, IDKost)
            Dim tRech As dbPMDS.billsDataTable = Me.sql.readBillsSR(monat, IDKost, IDKlinik)
            If tRech.Rows.Count > 0 Then

                Dim calcSR As New calcData()
                Dim dbSR As New dbPMDS()
                Dim rechnung As String = ""
                Dim sRechNr As String = ""
                Dim sumNetto As Decimal = 0
                Dim AbzüglAndererKost As Decimal = 0
                Dim SumIhrerLeist As Decimal = 0
                Dim sumGSBG As Decimal = 0
                Dim gesSum As Decimal = 0
                Dim tMWStGes As New dbCalc.MWStBasenDataTable
                Dim sumSelbstbehalt As Decimal = 0

                Dim monat1 As New monate
                monat1.init(monat, Me.monatsende(monat), rechDatum, calcSR)

                Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
                billFormat.tableNr = 1
                Dim cols() As QS2.Desktop.Txteditor.tableColumn = Me.bill.getPrintColumns()
                billFormat.columns = cols

                Dim billFormatAbw As New QS2.Desktop.Txteditor.formatAttr()
                Dim colsAbw() As QS2.Desktop.Txteditor.tableColumn = Me.bill.getPrintColumnsAbw()
                billFormatAbw.columns = colsAbw

                Dim billFormatAbwExtended As New QS2.Desktop.Txteditor.formatAttr()
                Dim colsAbwExtended() As QS2.Desktop.Txteditor.tableColumn = Me.bill.getPrintColumnsAbw2()
                billFormatAbwExtended.tableNr = 2
                billFormatAbwExtended.columns = colsAbwExtended

                Dim IDSR As String = VB.LCase(System.Guid.NewGuid.ToString())
                Me.addToProt("Klientenliste für SR:", 2, calcSR)
                Me.sql.readKostenräger(IDKost, dbSR, True)
                Dim rKostDat As dbPMDS.KostentraegerRow = dbSR.Kostentraeger.Rows(0)
                Dim rNewKost As dbCalc.KostenträgerRow = Me.addKostenträger(calcSR.dbCalc, rKostDat)
                calcSR.dbCalc.Kostenträger.Rows.Add(rNewKost)

                print.loadTempStreamToEditor(editor)
                bill.fillFields(IDKost, "", eCalcTyp.abrechnung, monat, rechDatum, editor, eBillTyp.Sammelrechnung, IDKlinik)

                Dim lstMwstDistinct As New System.Collections.Generic.List(Of calculation.cMwst)
                Dim tAbwesenheiten As New dbPMDS.helpDataTable()
                Dim arrKost() As dbPMDS.billsRow = tRech.Select("", "KlientName asc ")
                For Each rRech As dbPMDS.billsRow In arrKost
                    If rRech.Typ <> CInt(eBillTyp.KeineRechnung) Then
                        If Me.checkIfPatientSelected(rRech.IDKlient.Trim(), rRech.IDKost.Trim(), rRech.ID, lstSelPatients) Then
                            If rRech.betrag <> 0 Then
                                Dim rHeader As dbPMDS.billHeaderRow = Me.getHeader(rRech.IDAbrechnung, IDKlinik)
                                Dim dbCalcRech As dbCalc = Me.getDBCalc(rHeader.dbCalc)
                                Dim sPatientZusatz As String = ""
                                Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()

                                    Dim IDKlient As New Guid(rRech.IDKlient.Trim())
                                    Dim tPatient As IQueryable(Of PMDS.db.Entities.Patient) = From o In db.Patient Where o.ID = IDKlient
                                    Dim rPatient As PMDS.db.Entities.Patient = tPatient.First()

                                    If rPatient.Klientennummer <> Nothing Then
                                        sPatientZusatz += IIf(rPatient.Klientennummer.Trim() <> "", ", " + rPatient.Klientennummer.Trim() + " ", "")
                                    End If

                                    Dim tAufenthalt As IQueryable(Of PMDS.db.Entities.Aufenthalt) = Nothing
                                    Dim rAufenthalt As PMDS.db.Entities.Aufenthalt = Nothing
                                    tAufenthalt = From o In db.Aufenthalt Where o.IDPatient = rPatient.ID And o.Entlassungszeitpunkt Is Nothing
                                    If tAufenthalt.Count() = 0 Then
                                        tAufenthalt = From o In db.Aufenthalt Where o.IDPatient = rPatient.ID Order By o.Entlassungszeitpunkt Descending
                                        rAufenthalt = tAufenthalt.First()
                                    ElseIf tAufenthalt.Count() = 1 Then
                                        rAufenthalt = tAufenthalt.First()
                                    Else
                                        Throw New Exception("doSr: tAufenthalt.Count()>1 for IDPatient '" + rPatient.ID.ToString() + "' not allowed!")
                                    End If

                                    Dim tAufenthaltZusatz As IQueryable(Of PMDS.db.Entities.AufenthaltZusatz) = From o In db.AufenthaltZusatz Where o.IDAufenthalt = rAufenthalt.ID
                                    If tAufenthaltZusatz.Count() = 1 Then
                                        Dim rAufenthaltZusatz As PMDS.db.Entities.AufenthaltZusatz = tAufenthaltZusatz.First()
                                        If rAufenthaltZusatz.SozialhilfeBescheidJN Then
                                            If rAufenthaltZusatz.SozialhilfeBescheidGZ <> Nothing Then
                                                sPatientZusatz += IIf(rAufenthaltZusatz.SozialhilfeBescheidGZ.Trim() <> "", " (" + rAufenthaltZusatz.SozialhilfeBescheidGZ.Trim() + ")", "")
                                            End If
                                        End If
                                    End If
                                End Using

                                Dim IDBillRtfRZ6 As System.Guid = System.Guid.NewGuid()
                                bill.setPrintColumn(IDBillRtfRZ6, eTypProt.Name, 0, rRech.KlientName + sPatientZusatz, 0, 0, 0, 0, billFormat)
                                bill.add(IDBillRtfRZ6, eTypProt.Name, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, True)

                                Me.doRechZeilenKlient(dbCalcRech, calcSR, IDKost, rRech, billFormat, tMWStGes, sumNetto, AbzüglAndererKost,
                                                gesSum, sumGSBG, sumSelbstbehalt, editor, rNewKost, lstMwstDistinct)
                                Me.doAbwesenheiten(dbCalcRech, calcSR, IDKost, billFormat, tMWStGes, sumNetto, AbzüglAndererKost,
                                                gesSum, sumGSBG, sumSelbstbehalt, editor, rNewKost,
                                                tAbwesenheiten)

                                ' Leerzeile
                                IDBillRtfRZ6 = System.Guid.NewGuid()
                                bill.setPrintColumn(IDBillRtfRZ6, eTypProt.Leerzeile, 0, " ", 0, 0, 0, 0, billFormat)
                                bill.add(IDBillRtfRZ6, eTypProt.Leerzeile, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)

                                Me.sql.saveIDSR(rRech.ID, IDSR)
                                Me.addToProt("       " + rRech.KlientName, 1, calcSR)
                            End If
                        End If
                    Else
                        Me.addToProt("       " + rRech.KlientName + " - keine Rechnung angegeben in Stammdaten!", 1, calcSR)
                    End If
                Next

                Dim IDBillRtfRZ1 As System.Guid = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ1, eTypProt.GesamtsumNetto, 0, "Gesamtsumme netto", sumNetto, 0, 0, 0, billFormat)
                bill.add(IDBillRtfRZ1, eTypProt.GesamtsumNetto, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, True, True)

                Dim sumMwSt As Double = 0
                For Each cMwst As calculation.cMwst In lstMwstDistinct
                    Dim IDNewIDRechZ As Guid = Guid.NewGuid()
                    If cMwst.sum <> 0 Then
                        Dim Mwst As Double = Math.Round((Math.Round(cMwst.sum, 2) / 100) * cMwst.MwstSatz, 2)
                        sumMwSt += Mwst
                        bill.setPrintColumn(IDNewIDRechZ, eTypProt.MWStSatz, 0, "+ " + Me.decWithProzent(cMwst.MwstSatz) + "  MwSt von " + Me.decWithEuro(cMwst.sum), Mwst, 0, 0, cMwst.MwstSatz, billFormat)
                        bill.add(IDNewIDRechZ, eTypProt.MWStSatz, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung,
                                    Me.decWithEuro(cMwst.sum), 0, Me.decWithEuro(cMwst.MwstSatz), "", editor, False, False, "", "", "", "", "", False)
                    End If
                Next

                'Dim MWStGesamt As Decimal = 0
                'For Each r As dbCalc.MWStBasenRow In tMWStGes
                '    r.MWSt = Math.Round(sumNetto * r.MWStSatz / 100, 2)
                '    Dim IDBillRtfRZ3 As System.Guid = System.Guid.NewGuid()
                '    bill.setPrintColumn(IDBillRtfRZ3, eTypProt.MWStSatz, 0, "+ " + Me.decWithEuro(r.MWStSatz) + "%  MwSt von " + Me.decWithEuro(sumNetto), r.MWSt, 0, 0, r.MWStSatz, billFormat)
                '    bill.add(IDBillRtfRZ3, eTypProt.MWStSatz, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung,
                '             Me.decWithEuro(r.NettoBetrag), Me.decWithEuro(r.BruttoBetrag), Me.decWithEuro(r.MWSt), r.KontoExport,
                '             editor, False, False)
                '    MWStGesamt += r.MWSt
                'Next



                'os: Wenn die Behörde die Sammelrechnung und nicht die Einzelrechnungen erhält
                'Gesamtsumme darf nicht aus den Summen der einzelnen Bruttobeträge berechnet werden, weil sonst die Rundungsdiffernz-Fehler addiert werden
                'es muss die Netto-Summe + MWSt - Selbstbehalte + GSBG berechnet werden.
                'Sonst sumGes aus der Addition der Einzelrechnungen wie bisher (dann aber Netto-Betragssumme und MWSt-Summe auf SR NICHT andrucken, wei die dann falsch wären)
                gesSum = sumNetto + sumMwSt

                'Bruttobetrag
                Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.Gesamtkosten, 0, "Gesamtsumme brutto", 0, 0, gesSum, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.Gesamtkosten, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False)

                'Selbstbehalt
                If sumSelbstbehalt <> 0 Then
                    Dim IDBillRtfRZ5 As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ5, eTypProt.sumSelbstbehalt, 0, "abzüglich Summe der Selbstbehalte", 0, 0, sumSelbstbehalt * -1, 0, billFormat)
                    bill.add(IDBillRtfRZ5, eTypProt.sumSelbstbehalt, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)
                End If
                gesSum -= sumSelbstbehalt

                If sumGSBG <> 0 Then
                    Dim IDBillRtfRZ5 As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ5, eTypProt.sumGSBG, 0, "zuzüglich Summe " + kostenträger.bezGSBG, 0, 0, sumGSBG, 0, billFormat)
                    bill.add(IDBillRtfRZ5, eTypProt.sumGSBG, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)
                End If
                gesSum += sumGSBG

                IDBillRtfRZ = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.GesamtkostenRechnungsbetrag, 0, "Gesamtkosten = Rechnungsbetrag", 0, 0, gesSum, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.GesamtkostenRechnungsbetrag, billFormat, calcSR.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, True, True, "", "", "", "", "", False, "", "")

                Me.print.removeTable(2, editor)
                ' Liste Abwesenheiten drucken
                If tAbwesenheiten.Rows.Count > 0 Then
                    For Each rAbw As dbPMDS.helpRow In tAbwesenheiten.Rows
                        bill.setPrintColumnAbwSimple(rAbw.Name.Trim() + "" + rAbw.ID, billFormatAbw)
                        Me.print.addCollumn(Nothing, billFormatAbw, editor)
                    Next
                End If

                ' Erw. Liste Abwesenheiten berechnen
                Dim listAbwSimple As New ArrayList()
                Dim listAbwExtended As New ArrayList()
                Dim doBill1 As New doBill()
                If calcBase.SrErwAbwesenheit Then
                    For Each rRech As dbPMDS.billsRow In arrKost
                        If rRech.Typ <> CInt(eBillTyp.KeineRechnung) Then
                            Dim rHeader As dbPMDS.billHeaderRow = Me.getHeader(rRech.IDAbrechnung, IDKlinik)
                            Dim dbCalcRech As dbCalc = Me.getDBCalc(rHeader.dbCalc)
                            Dim rOffLeist As dbPMDS.OffeneLeistungenRow = doBill1.doBillPrepare(dbCalcRech, listAbwSimple, listAbwExtended, editor, 1)
                        End If
                    Next
                    ' Erw. Liste Abwesenheiten drucken
                    If listAbwExtended.Count > 0 Then
                        For Each abwFound As doBill.cAbw In listAbwExtended
                            bill.setPrintColumnAbwExtended(abwFound, billFormatAbwExtended)
                            Me.print.addCollumn(Nothing, billFormatAbwExtended, editor, False, IIf(abwFound.NewPatient, True, False))
                        Next
                        Me.doBookmarks.insertPageBreakBeforeTable(editor, 2)
                    Else
                        print.removeTable(2, editor)
                        'Me.doBookmarks.ClearEmptyPage(editor, 2)
                    End If
                Else
                    print.removeTable(2, editor)
                End If

                If (Not calculation.AbwesenheitenAnzeigen) Or tAbwesenheiten.Rows.Count = 0 Then
                    print.removeTable(0, editor)
                End If


                Me.print.doAutoSiteNummbering(editor)
                rechnung = doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)

                ' Buchungen vorbereiten

                'Kundenforderung: eine Buchung auf Erlöse netto + eine Buchung auf Ust
                'os: Zusätzliche Spalte koperiode  JJJJMM für BMD  (monat)



                booking.saveBooking(eKonto.Kundenforderungen, eKonto.Erlöse, monat,
                                    "Rechnungsbetrag", sumNetto + sumSelbstbehalt + sumGSBG, -1, "", "",
                                    IDKost, calcSR, False, eCalcRun.month, IDKlinik)
                booking.saveBooking(eKonto.Kundenforderungen, eKonto.USt, monat,
                                    "USt", sumMwSt, -1, "", "",
                                    IDKost, calcSR, False, eCalcRun.month, IDKlinik)

                Dim rechDatum2 As Date = Me.rowMonat(calcSR.dbCalc).RechDatum.Date
                Me.bill.save(eBillStatus.offen, monat, rechnung, IDSR, IDKost, rNewKost.IDKostIntern, rKostDat.Name, gesSum, calcSR,
                             eBillTyp.Sammelrechnung, "", "", New DateTime(monat.Year, monat.Month, 1), rechDatum, IDKlinik)

            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function checkIfPatientSelected(IDKlient As String, IDKost As String, IDBill As String, ByRef lstSelPatients As System.Collections.Generic.List(Of cPatients)) As Boolean
        Try
            For Each Patient As cPatients In lstSelPatients
                If Patient.IDPatient.Trim().ToLower().Equals(IDKlient.Trim().ToLower()) And Patient.IDKost.Trim().ToLower().Equals(IDKost.Trim().ToLower()) And Patient.IDBill.Trim().ToLower().Equals(IDBill.Trim().ToLower()) Then
                    Return True
                End If
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function addKostenträger(ByRef dbCalc1 As dbCalc, ByRef rKostDat As dbPMDS.KostentraegerRow) As dbCalc.KostenträgerRow

        Dim kostenträgerSR As New kostenträger()
        Dim rNewKost As dbCalc.KostenträgerRow = kostenträgerSR.newKostenträger(dbCalc1)

        rNewKost.FamName = rKostDat.Name

        rNewKost.IDKostIntern = VB.LCase(System.Guid.NewGuid().ToString())
        rNewKost.IDKost = VB.LCase(rKostDat.ID.ToString())
        rNewKost.KlientenbezogenJN = rKostDat.PatientbezogenJN
        If Not rKostDat.IsBetragNull() Then
            rNewKost.MaxBetragBrutto = rKostDat.Betrag
        Else
            rNewKost.MaxBetragBrutto = 0
        End If
        rNewKost.SammelabrechnungJN = rKostDat.SammelabrechnungJN
        rNewKost.RechnungTyp = eBillTyp.Sammelrechnung
        rNewKost.FIBU = rKostDat.FIBUKonto.Trim()
        rNewKost.IDKlient = VB.LCase("")
        rNewKost.Rechnung = ""

        Return rNewKost
    End Function




    Public Sub addMwstToList(ByRef lstMwstDistinct As System.Collections.Generic.List(Of calculation.cMwst), ByRef dbCalc As dbCalc)
        Try
            Dim bMwstExistsInList As Boolean = False
            For Each rMwst As dbCalc.MWStBasenRow In dbCalc.MWStBasen
                For Each MwstExistsInList As calculation.cMwst In lstMwstDistinct
                    If MwstExistsInList.MwstSatz.Equals(rMwst.MWStSatz) Then
                        bMwstExistsInList = True
                    End If
                Next
                If Not bMwstExistsInList Then
                    Dim newMwst As New calculation.cMwst()
                    newMwst.MwstSatz = rMwst.MWStSatz
                    lstMwstDistinct.Add(newMwst)
                End If
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function doRechZeilenKlient(ByRef dbCalcRech As dbCalc, ByRef calc As calcData, ByRef IDKost As String, rRech As dbPMDS.billsRow,
                                       ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef tMWStGes As dbCalc.MWStBasenDataTable,
                                        ByRef sumNetto As Decimal, ByRef AbzüglAndererKost As Decimal,
                                        ByRef gesSum As Decimal, ByRef sumGSBG As Decimal,
                                        ByRef sumSelbstbehalt As Decimal,
                                        ByRef editor As TXTextControl.TextControl,
                                        ByRef rNewKost As dbCalc.KostenträgerRow,
                                        ByRef lstMwstDistinct As System.Collections.Generic.List(Of calculation.cMwst)) As calcData
        Try
            Dim firstLz As Boolean = True
            Dim arrRechZeilen() As dbCalc.KostenKostenträgerRow = dbCalcRech.KostenKostenträger.Select("IDKost='" + IDKost + "'", "lfdNr")

            Dim lfdNrLast As Integer = 0
            Dim SumNettoMwst As Double = 0
            doRollung1.addMwstToList(lstMwstDistinct, dbCalcRech)
            Me.prepareRechZSR(lstMwstDistinct, dbCalcRech, lfdNrLast, SumNettoMwst, True, IDKost)

            Dim n11 As Decimal = 0
            Dim n22 As Decimal = 0
            For Each rRechZ As dbCalc.KostenKostenträgerRow In arrRechZeilen
                If IDKost.Trim().Equals(IDKost.Trim()) Then
                    If rRechZ.Kennung = eTypProt.LZ.ToString() Then

                        'Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        'bill.setPrintColumn(IDBillRtfRZ, eTypProt.LZ, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        'bill.add(IDBillRtfRZ, eTypProt.LZ, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, firstLz, False, rRechZ.FIBU.Trim(), rRechZ.IDLeistung, rRechZ.IDLeistungsKatalog, rRechZ.IDSonderLeistungskatalog, "")
                        'firstLz = False

                        Dim IDRechZeile As System.Guid = System.Guid.NewGuid()

                        Dim rowNewRechZ As dbCalc.KostenKostenträgerRow
                        If rNewKost.IDKostIntern.Trim() = "" Or rNewKost.IDKost.Trim() = "" Then
                            Throw New Exception("doSr.doLZPrintSum: rNewKost.IDKostIntern.Trim() = '' Or rNewKost.IDKost.Trim() = ''  not allowed!")
                        End If

                        rowNewRechZ = Me.bill.newRechZeile(calc.dbCalc)
                        rowNewRechZ.ID = VB.LCase(IDRechZeile.ToString())
                        rowNewRechZ.IDKostIntern = rNewKost.IDKostIntern
                        rowNewRechZ.IDKost = rNewKost.IDKost
                        rowNewRechZ.Kennung = eTypProt.LZ.ToString()
                        Dim BezTmp As String = rRechZ.Bezeichnung
                        rowNewRechZ.Bezeichnung = BezTmp
                        rowNewRechZ.Anzahl = rRechZ.Anzahl
                        rowNewRechZ.Netto = rRechZ.Netto
                        rowNewRechZ.MWSt = rRechZ.MWSt
                        rowNewRechZ.Brutto = rRechZ.Brutto
                        rowNewRechZ.MWStSatz = 0
                        rowNewRechZ.FIBU = rRechZ.FIBU.Trim()
                        rowNewRechZ.IDLeistung = rRechZ.IDLeistung
                        rowNewRechZ.IDSonderLeistungskatalog = rRechZ.IDSonderLeistungskatalog
                        rowNewRechZ.IDLeistungsKatalog = rRechZ.IDLeistungsKatalog
                        rowNewRechZ.IDKlient = LCase(rRech.IDKlient)
                        rowNewRechZ.IDBill = rRech.ID.Trim()
                        rowNewRechZ.IDKostInternBill = rRechZ.IDKostIntern
                        rowNewRechZ.IDKostBill = rRechZ.IDKost
                        bill.lfdNr += 1

                        rowNewRechZ.lfdNr = bill.lfdNr
                        calc.dbCalc.KostenKostenträger.Rows.Add(rowNewRechZ)

                        bill.setPrintColumn(New System.Guid(rRechZ.ID), eTypProt.LZ, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, rRechZ.MWStSatz, billFormat)
                        Me.print.addCollumn(New System.Guid(rRechZ.ID), billFormat, editor, False, False, eTypProt.LZ)

                        'bill.setPrintColumn(IDRechZeile, eTypProt.LZ, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        'bill.add(IDRechZeile, eTypProt.LZ, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, firstLz, False, rRechZ.FIBU.Trim(),
                        '         rRechZ.IDLeistung, rRechZ.IDLeistungsKatalog, rRechZ.IDSonderLeistungskatalog, LCase(rRech.IDKlient))

                        firstLz = False
                    End If

                    If rRechZ.Kennung = eTypProt.SumLeistNetto.ToString() Then
                        Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ, eTypProt.SumLeistNetto, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        bill.add(IDBillRtfRZ, eTypProt.SumLeistNetto, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", False, "", rRech.ID.Trim())
                        n11 = rRechZ.Netto
                    End If

                    If rRechZ.Kennung = eTypProt.AbzüglAndererKost.ToString() Then
                        Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ, eTypProt.AbzüglAndererKost, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        bill.add(IDBillRtfRZ, eTypProt.AbzüglAndererKost, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", False, "", rRech.ID.Trim())
                        If rRechZ.Bezeichnung.Trim().ToLower.Equals(("Summe Ihrer Leistungen netto").Trim().ToLower()) Then
                            n22 = rRechZ.Netto
                        End If
                    End If

                    If rRechZ.Kennung = eTypProt.selbstbehalt.ToString() Then
                        Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ, eTypProt.selbstbehalt, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        bill.add(IDBillRtfRZ, eTypProt.selbstbehalt, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", False, "", rRech.ID.Trim())
                    End If

                    If rRechZ.Kennung = eTypProt.GSGB.ToString() Then
                        Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ, eTypProt.GSGB, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        bill.add(IDBillRtfRZ, eTypProt.GSGB, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", False, "", rRech.ID.Trim())
                    End If
                    If rRechZ.Kennung = eTypProt.Zahlungsbetrag.ToString() Then
                        Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ, eTypProt.Zahlungsbetrag, rRechZ.Anzahl, rRechZ.Bezeichnung, rRechZ.Netto, rRechZ.MWSt, rRechZ.Brutto, 0, billFormat)
                        bill.add(IDBillRtfRZ, eTypProt.Zahlungsbetrag, billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", False, "", rRech.ID.Trim())
                    End If
                    If rRechZ.Kennung = eTypProt.GSGB.ToString() Then
                        sumGSBG += rRechZ.Brutto
                    End If

                    If rRechZ.Kennung = eTypProt.selbstbehalt.ToString() Then
                        sumSelbstbehalt -= rRechZ.Brutto       'wird abgezogen
                    End If

                    ' MWStSätze sortiert lesen und in gesamt-Tabelle speichern(addieren)
                    If rRechZ.Kennung = eTypProt.MWStSatz.ToString() Then
                        Dim found As Boolean = False
                        For Each rGes As dbCalc.MWStBasenRow In tMWStGes
                            If rGes.MWStSatz = rRechZ.MWStSatz Then
                                rGes.NettoBetrag += rRechZ.tempNetto
                                rGes.BruttoBetrag += rRechZ.tempBrutto
                                rGes.MWSt += rRechZ.tempMWSt

                                'Dim MwStGesKlient As Double = 0
                                'MwStGesKlient += rGes.MWSt
                                'bill.setPrintColumn(eTypProt.MwStBetrag, rRechZ.Anzahl, "MwSt. Betrag", MwStGesKlient, 0, rRechZ.MWSt, rGes.MWSt, billFormat)
                                'bill.add(billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)

                                found = True
                            End If
                        Next
                        If Not found Then
                            Dim rNew As dbCalc.MWStBasenRow = tMWStGes.NewRow()
                            rNew.ID = VB.LCase(System.Guid.NewGuid().ToString())
                            rNew.IDKostIntern = System.Guid.NewGuid().ToString()
                            rNew.MWStSatz = rRechZ.MWStSatz
                            rNew.NettoBetrag = rRechZ.tempNetto     '<20120111>      3 tempColumns neu zur getrennten Speicherung von Netto/Brutto pro MWStSatz für Export
                            rNew.BruttoBetrag = rRechZ.tempBrutto
                            rNew.MWSt = rRechZ.tempMWSt
                            rNew.KontoExport = rRechZ.tempKontoExport   '<20120111-2>

                            'Dim MwStGesKlient As Double = 0
                            'MwStGesKlient += rRechZ.tempMWSt
                            'bill.setPrintColumn(eTypProt.MwStBetrag, rRechZ.Anzahl, "MwSt. Betrag", MwStGesKlient, 0, rRechZ.MWSt, rNew.MWStSatz, billFormat)
                            'bill.add(billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)

                            tMWStGes.Rows.Add(rNew)
                        End If
                        'If MwStGesKlient > 0 Then
                        '    bill.setPrintColumn(eTypProt.MwStBetrag, rRechZ.Anzahl, "MwSt. Betrag", MwStGesKlient, 0, 0, rRechZ.MWSt, billFormat)
                        '    bill.add(billFormat, calc.dbCalc, rNewKost.IDKostIntern, rNewKost.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor)
                        'End If

                        If rRechZ.Kennung = eTypProt.Zahlungsbetrag.ToString() Then
                            gesSum += rRechZ.Brutto
                        End If
                    End If
                End If
            Next

            If n22 > 0 Then
                sumNetto += n22
            Else
                sumNetto += n11
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub prepareRechZSR(ByRef lstMwstDistinct As System.Collections.Generic.List(Of calculation.cMwst), ByRef dbCalc As dbCalc, ByRef lfdNrLast As Integer, ByRef SumNetto As Double,
                            ByRef doNotDeleteRows As Boolean, Optional IDKost As String = "")
        Try
            Dim lstRowsToDelete As New System.Collections.Generic.List(Of dbCalc.KostenKostenträgerRow)

            Dim arrKostKostenträger() As dbCalc.KostenKostenträgerRow = dbCalc.KostenKostenträger.Select("", dbCalc.KostenKostenträger.lfdNrColumn.ColumnName + " asc")
            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In arrKostKostenträger
                If IDKost.Trim() = "" Or (IDKost.Trim() <> "" And rKostKostenträger.IDKost.Trim().Equals(IDKost.Trim())) Then
                    If rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.MWStSatz.ToString().Trim().ToLower()) Then
                        For Each Mwst As calculation.cMwst In lstMwstDistinct
                            If Mwst.MwstSatz.Equals(rKostKostenträger.MWStSatz) Then
                                Mwst.sum += rKostKostenträger.tempNetto
                            End If
                        Next

                        SumNetto += rKostKostenträger.Netto
                        If rKostKostenträger.lfdNr > lfdNrLast Then lfdNrLast = rKostKostenträger.lfdNr

                    Else
                        If Not doNotDeleteRows Then
                            lstRowsToDelete.Add(rKostKostenträger)
                        End If
                    End If
                End If
            Next

            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In lstRowsToDelete
                rKostKostenträger.Delete()
            Next
            dbCalc.AcceptChanges()

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function doAbwesenheiten(ByRef dbCalcRech As dbCalc, ByRef calc As calcData, ByRef IDKost As String,
                                    ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef tMWStGes As dbCalc.MWStBasenDataTable,
                                     ByRef sumNetto As Decimal, ByRef AbzüglAndererKost As Decimal,
                                     ByRef gesSum As Decimal, ByRef sumGSBG As Decimal,
                                     ByRef sumSelbstbehalt As Decimal,
                                     ByRef editor As TXTextControl.TextControl,
                                     ByRef rNewKost As dbCalc.KostenträgerRow,
                                     ByRef tAbwesenheiten As dbPMDS.helpDataTable) As calcData
        Try
            Dim arrAbwZeilen() As dbCalc.AbwesenheitenRow = dbCalcRech.Abwesenheiten.Select("", "von, bis")
            Dim rKlient As dbCalc.KlientRow = dbCalcRech.Klient(0)
            If arrAbwZeilen.Length > 0 Then
                Dim bFirstAbw As Boolean = True
                For Each rAbw As dbCalc.AbwesenheitenRow In arrAbwZeilen
                    If bFirstAbw Then
                        Dim rNewAbwKlient As dbPMDS.helpRow = tAbwesenheiten.NewRow()
                        rNewAbwKlient.Name = rKlient.Nachname + " " + rKlient.Vorname
                        rNewAbwKlient.ID = ""
                        tAbwesenheiten.Rows.Add(rNewAbwKlient)
                        bFirstAbw = False
                    End If

                    Dim rNewAbw As dbPMDS.helpRow = tAbwesenheiten.NewRow()
                    rNewAbw.Name = ""

                    Dim sAbwTxt As String = " - von " + rAbw.Von.ToString(Me.dateFormat)
                    sAbwTxt += " bis " & IIf(rAbw.Bis = Me.dat2999, "laufend", rAbw.Bis.ToString(Me.dateFormat))
                    sAbwTxt += " , Grund: " + rAbw.Grund.Trim()
                    rNewAbw.ID = sAbwTxt

                    tAbwesenheiten.Rows.Add(rNewAbw)
                Next
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class
