Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Imports QS2.Desktop.Txteditor



Public Class doBill
    Inherits calcBase

    Public booking As New booking()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public bill As New bill()
    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public print As New print()
    Public dbBill As New dbBill()

    Public Class cAbw
        Public Patient As String = ""

        Public Text As String = ""
        Public ohneKürzung As String = ""
        Public TageReservierung As String = ""
        Public NichtAufgenommen As String = ""
        Public Abwesendheitsgrund As String = ""

        Public countDays As Integer = 0
        Public Anwesenheitsstatus As Integer = -999

        Public tagAb As Integer = 1
        Public tagBis As Integer = 1

        Public NewPatient As Boolean = False
    End Class

    Public doRollung As New doRollung()






    Public Sub run(ByRef calc As calcData, ByRef editor As TXTextControl.TextControl, IDKlinik As System.Guid, Bereich As String, ByRef Prot As String, ByRef iCounterProt As Integer)
        Try
            ' Deklarierung bill (format, columns)
            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr With {
                .tableNr = 1,
                .columns = Me.bill.getPrintColumns()
            }
            billFormat.cellFormat.TopTextDistance = 80
            billFormat.cellFormat.BottomTextDistance = 80

            Dim billFormatAbwSimple As New QS2.Desktop.Txteditor.formatAttr()
            Dim colsAbwSimple() As tableColumn = Me.bill.getPrintColumnsAbw()
            billFormatAbwSimple.columns = colsAbwSimple

            Dim billFormatAbwExtended As New QS2.Desktop.Txteditor.formatAttr()
            Dim colsAbwExtended() As tableColumn = Me.bill.getPrintColumnsAbw2()
            billFormatAbwExtended.tableNr = 2
            billFormatAbwExtended.columns = colsAbwExtended

            Me.addToProt(" Abrechnungsprotokoll für " + Me.rowKlient(calc.dbCalc).Nachname, 1, calc)

            ' Ausgabe Protokoll-Header
            Dim listAbwSimple As New ArrayList()
            Dim listAbwExtended As New ArrayList()
            Dim rOffLeist As dbPMDS.OffeneLeistungenRow = Me.doBillPrepare(calc.dbCalc, listAbwSimple, listAbwExtended, editor, calcBase.RechErwAbwesenheit)

            'Kostenträger auflisten
            Dim arrKostenträger() As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.Select("", "Rang asc")
            For Each rKost As dbCalc.KostenträgerRow In arrKostenträger

                'bill.add(eTypProt.abwesenheit, 0, rAbw.Grund, 0, 0, 0, False, False, calc, rKost)   Abwesenheiten von oben

                print.loadTempStreamToEditor(editor)
                bill.fillFields(rKost.IDKost, Me.rowKlient(calc.dbCalc).ID, Me.rowKlient(calc.dbCalc).calcTyp, Me.rowMonat(calc.dbCalc).Beginn, Me.rowMonat(calc.dbCalc).RechDatum, editor, eBillTyp.Rechnung, IDKlinik)
                If rKost.RechnungTyp = CInt(eBillTyp.Zahlungsbestätigung) Then Me.doBookmarks.setBookmark("[Zahlkond]", "", editor)

                ' Leistungszeilen  'Alle Leistungen, bei denen der Kostenträger mitzahlt, Ergbnis gerundet
                rKost.sumNetto = Me.doLZPrintSum(calc, rKost, billFormat, editor, "N")  'gerundeter Wert

                'Betrag, den der Kostenträger nach Abzug der anderen Kostenträger tatsächlich zahlt - Selbstbehalt nicht berücksichtigt
                Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.SumLeistNetto, 0, "Summe der Leistungen netto gesamt", rKost.sumNetto, 0, 0, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.SumLeistNetto, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor, True)

                'MWSt. berechnen
                Dim SumMWSt As Decimal = 0
                Me.doMWStCalc(calc, rKost.IDKostIntern, rKost.IDKost, billFormat, editor, SumMWSt)  'MWSt. je Kostenträger

                ' Andere Kostenträger berechnen
                Dim AndereKostenträgerNetto As Decimal = 0
                If Math.Round(rKost.sumNetto, 2) - Math.Round(rKost.ZahlungsbetragNetto, 2) <> 0 Then
                    AndereKostenträgerNetto = (rKost.sumNetto - rKost.ZahlungsbetragNetto) * -1
                End If

                ' Andere Kostenträger - nur andrucken
                If rKost.ZahlungsbetragBrutto - rKost.sumBrutto <> 0 Then
                    If AndereKostenträgerNetto <> 0 Then
                        Dim IDBillRtfRZ2 As System.Guid = System.Guid.NewGuid()
                        bill.setPrintColumn(IDBillRtfRZ2, eTypProt.AbzüglAndererKost, 0, "abzüglich andere Kostenträger", AndereKostenträgerNetto, 0, 0, 0, billFormat)
                        bill.add(IDBillRtfRZ2, eTypProt.AbzüglAndererKost, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)
                    End If
                End If


                Dim BetragNettoKostenträger As Decimal = rKost.sumNetto + AndereKostenträgerNetto
                If BetragNettoKostenträger <> rKost.sumNetto Then
                    'Netto Leistungen pro Kostenträger
                    Dim IDBillRtfRZ2 As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ2, eTypProt.AbzüglAndererKost, 0, "Summe Ihrer Leistungen netto", BetragNettoKostenträger, 0, 0, 0, billFormat)
                    bill.add(IDBillRtfRZ2, eTypProt.AbzüglAndererKost, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor, True)
                End If

                'MWSTSätze andrucken 
                Me.doMWStPrint(calc, rKost.IDKostIntern, rKost.IDKost, billFormat, editor)

                Dim BetragBruttoKostenträger As Double = BetragNettoKostenträger + SumMWSt
                IDBillRtfRZ = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.SumLeistBrutto, 0, "Summe Ihrer Leistungen brutto", 0, 0, BetragBruttoKostenträger, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.SumLeistBrutto, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor, True)

                ' Transferleistungen (wenn welche vorhanden, vom Zahlungsbetrag abziehen (immer Brutto)
                If rKost.GrundleistungJN And rKost.RestzahlerJN And Not rKost.TransferzahlerJN Then
                    Dim transferGes As Decimal = Me.doTransfer(calc, rKost.IDKostIntern, rKost.IDKost, billFormat, editor)
                    rKost.ZahlungsbetragBrutto -= transferGes
                End If

                IDBillRtfRZ = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.Gesamtkosten, 0, "Gesamtkosten = Rechnungsbetrag", 0, 0, rKost.ZahlungsbetragBrutto, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.Gesamtkosten, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)

                If rKost.TransferzahlerJN Then
                    rKost.ZahlungsbetragBrutto = rKost.MaxBetragBrutto
                End If

                rKost.Ueberweisungsbetrag = rKost.ZahlungsbetragBrutto

                ' Ende wenn Vorauszahlungsberechnung
                If Me.rowKlient(calc.dbCalc).calcTyp = CInt(PMDS.Calc.Logic.eCalcTyp.vorauszahlung) Then Continue For

                ' Zuschläge
                If rKost.ZuschlagGrundleistungJN And Me.rowKlient(calc.dbCalc).calcRun <> eCalcRun.freeBill Then
                    Dim IDBillRtfRZ2 As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ2, eTypProt.GSGB, 0, kostenträger.bezGSBG, 0, 0, rKost.ZuschlagGrundleistungBetrag, 0, billFormat)
                    bill.add(IDBillRtfRZ2, eTypProt.GSGB, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)

                    rKost.Ueberweisungsbetrag += rKost.ZuschlagGrundleistungBetrag
                End If

                ' Rollung J/N               (Rollung: wenn es für das Abrechnungsmonat bereits eine Buchung am Konto Kundenforderung gibt
                '                            ACHTUNG: Buchung kann auch aus freier Rechnung sein, dann handelt es sich NICHT um eine Rollung
                Dim RollungJN As Boolean = False
                rKost.ForderungBruttoAlt = booking.readBookingSum(Me.rowKlient(calc.dbCalc).ID, False, rKost.IDKost, eKonto.Kundenforderungen.ToString(), eKontoseite.soll, Me.rowMonat(calc.dbCalc).Beginn, Me.rowMonat(calc.dbCalc).Ende, "", eCalcRun.month, IDKlinik) * -1
                'RollungJN = rKost.ForderungBruttoAlt <> 0

                ' Vorauszahlung nächstes Monat
                Me.doNextMonth(calc, rKost, RollungJN, billFormat, editor, IDKlinik, Bereich, Prot, iCounterProt)


                ' Kontostand berücksichtigen (Hole den Saldo der AccontoZahlungen bis einschließlich Abrechnungsmonat)
                Me.doAcconto(calc, rKost, RollungJN, billFormat, editor, IDKlinik)

                ' Rollungsandruck
                If RollungJN And Not Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then
                    rKost.Ueberweisungsbetrag += rKost.ForderungBruttoAlt
                    Dim IDBillRtfRZ2 As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ2, eTypProt.AbzüglSumAccontoZahl, 0, "abzgl. Forderungen aus früheren Rechnungen", 0, 0, rKost.ForderungBruttoAlt, 0, billFormat)
                    bill.add(IDBillRtfRZ2, eTypProt.AbzüglSumAccontoZahl, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)
                End If

                ' Zahlungsbetrag andrucken (letzte Zeile)
                IDBillRtfRZ = System.Guid.NewGuid()
                billFormat.columns(4).printNull = True
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.Zahlungsbetrag, 0, "Zahlungsbetrag", 0, 0, rKost.Ueberweisungsbetrag, 0, billFormat)

                billFormat.columns(0).asField = "[ZahlBetragBez]"
                billFormat.columns(4).asField = "[ZahlBetrag]"
                bill.add(IDBillRtfRZ, eTypProt.Zahlungsbetrag, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor, True, True)
                billFormat.columns(0).asField = ""
                billFormat.columns(4).asField = ""
                billFormat.columns(4).printNull = False

                ' Zahlungsbestätigung J/N
                print.removeTable(2, editor)
                If rKost.RechnungTyp = CInt(eBillTyp.Zahlungsbestätigung) Then
                    print.removeTable(1, editor)
                    Dim txt As String = ""
                    If rKost.TransferzahlerJN Then
                        txt = kostenträger.TransferTxt + " " + Me.decWithEuro(rKost.Ueberweisungsbetrag) + ""
                    Else
                        txt = "Wir bestätigen den Erhalt von " + Me.decWithEuro(rKost.Ueberweisungsbetrag) + ""
                    End If
                    Me.bill.fillFieldZahlungsbest(rKost.Ueberweisungsbetrag, editor, txt)
                End If

                If rKost.RechnungTyp <> CInt(eBillTyp.Beilage) Then
                    ' Liste Abwesenheiten drucken
                    If listAbwExtended.Count > 0 And rKost.RechnungTyp <> CInt(eBillTyp.Zahlungsbestätigung) Then
                        For Each abwFound As cAbw In listAbwExtended
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

                Dim bDeleteAbwesenheiten As Boolean = False
                If listAbwSimple.Count > 0 And rKost.RechnungTyp <> CInt(eBillTyp.Zahlungsbestätigung) Then
                    For Each abwFound As cAbw In listAbwSimple
                        bill.setPrintColumnAbwSimple(abwFound.Text, billFormatAbwSimple)
                        Me.print.addCollumn(Nothing, billFormatAbwSimple, editor)
                    Next
                Else
                    bDeleteAbwesenheiten = True
                End If

                If (Not calculation.AbwesenheitenAnzeigen) Or rKost.RechnungTyp = CInt(eBillTyp.Zahlungsbestätigung) Or bDeleteAbwesenheiten Then
                    print.removeTable(0, editor)
                End If

                If rKost.RechnungTyp = CInt(eBillTyp.Zahlungsbestätigung) Then
                    Dim lstTables As New System.Collections.Generic.List(Of Integer)

                    For i As Integer = 0 To editor.Tables.Count - 1
                        editor.Tables.Remove(0)
                    Next

                    'Dim iCounterTable As Integer = 0
                    'For Each table As TXTextControl.Table In editor.Tables
                    '    lstTables.Add(iCounterTable)
                    '    iCounterTable += 1
                    'Next
                    'For Each iCounterTable2 As Integer In lstTables
                    '    editor.Tables.Remove(iCounterTable2)
                    'Next
                End If

                Me.print.doAutoSiteNummbering(editor)
                If rKost.ZahlungsbetragBrutto <> 0 Then
                    Me.doBillBuchungen(calc, rKost.IDKostIntern, rKost, billFormat, rKost.sumBrutto, editor, IDKlinik)
                End If

                rKost.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
            Next

            If Me.rowKlient(calc.dbCalc).calcTyp = CInt(PMDS.Calc.Logic.eCalcTyp.vorauszahlung) Then Exit Sub

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function doBillPrepare(ByRef dbCalc As dbCalc, ByRef listAbwSimple As ArrayList, ByRef listAbwExtended As ArrayList,
                                  ByRef editor As TXTextControl.TextControl, erwListeOnOff As Boolean) As dbPMDS.OffeneLeistungenRow
        Try
            Dim sAbrechVon As String = Me.rowMonat(dbCalc).Beginn.ToString(Me.dateFormat)
            Dim sAbrechBis As String = Me.rowMonat(dbCalc).Ende.ToString(Me.dateFormat)
            Dim abrechMonat As Date = Me.rowMonat(dbCalc).Beginn

            If Me.rowKlient(dbCalc).calcTyp <> eCalcTyp.vorauszahlung Then

                If dbCalc.Tage.Rows.Count > 0 Then

                    For Each abwesenheit As dbCalc.AbwesenheitenRow In dbCalc.Abwesenheiten
                        Dim cAbwNew As New cAbw()
                        cAbwNew.Text = "Von " + abwesenheit.Von.ToString(Me.dateFormat) + " bis " & IIf(abwesenheit.Bis.ToString(Me.dateFormat) = Me.dat2999, "laufend ", abwesenheit.Bis.ToString(Me.dateFormat)) + " wegen " + abwesenheit.Grund
                        listAbwSimple.Add(cAbwNew)
                    Next

                    If erwListeOnOff Then
                        'Dim AbwPatName As New cAbw()
                        'AbwPatName.Text = Me.rowKlient(dbCalc).Nachname.Trim() + " " + Me.rowKlient(dbCalc).Vorname.Trim()
                        'AbwPatName.NewPatient = True
                        'listAbwExtended.Add(AbwPatName)

                        Dim lastTag As dbCalc.TageRow = Nothing
                        Dim AbwesenheitsstatusAktuell As Integer = 0
                        Dim tageNichtGekürzt As Integer = 0
                        Dim tageGekürzt As Integer = 0
                        Dim tageNichtAufgenommen As Integer = 0
                        Dim lastAbwesenheitsstatus As Integer = -999
                        Dim IDAbwesenheit As String = ""
                        Dim countLine As Integer = 0


                        Dim beginnBlock As Date = abrechMonat.Date
                        Dim endBlock As Date = Nothing

                        Dim arrTage() As dbCalc.TageRow = dbCalc.Tage.Select("", "Tag asc")
                        For Each tag As dbCalc.TageRow In arrTage
                            Dim datDay As New Date(tag.Jahr, tag.Monat, tag.Tag, 0, 0, 0)
                            If tag.Abwesenheitsstatus <> lastAbwesenheitsstatus Then

                                If lastAbwesenheitsstatus = -999 Then
                                    lastAbwesenheitsstatus = tag.Abwesenheitsstatus
                                    If tag.IsIDAbwesenheitNull() Then
                                        IDAbwesenheit = ""
                                    Else
                                        IDAbwesenheit = tag.IDAbwesenheit
                                    End If
                                Else
                                    endBlock = tag.Datum.AddDays(-1)
                                    Me.PrintAbwZeile(endBlock, beginnBlock, tageNichtGekürzt, tageNichtAufgenommen, tageGekürzt, lastAbwesenheitsstatus,
                                                     listAbwExtended, dbCalc, IDAbwesenheit, countLine)

                                    beginnBlock = tag.Datum
                                    lastAbwesenheitsstatus = tag.Abwesenheitsstatus
                                    tageGekürzt = 0
                                    tageNichtGekürzt = 0

                                End If

                            End If

                            'If tag.Abwesenheitsstatus = 0 Then
                            If tag.Anwesenheitsstatus = 0 Then
                                tageNichtAufgenommen += 1

                            ElseIf tag.Anwesenheitsstatus = 1 Then
                                tageNichtGekürzt += 1

                            ElseIf tag.Anwesenheitsstatus = 2 Then
                                tageGekürzt += 1

                            ElseIf tag.Anwesenheitsstatus = 3 Then
                                tageNichtGekürzt += 1

                            ElseIf tag.Anwesenheitsstatus = 4 Then
                                tageNichtAufgenommen += 1

                            End If

                            lastAbwesenheitsstatus = tag.Abwesenheitsstatus
                            If tag.IsIDAbwesenheitNull() Then
                                IDAbwesenheit = ""
                            Else
                                IDAbwesenheit = tag.IDAbwesenheit
                            End If
                            lastTag = tag
                        Next

                        Me.PrintAbwZeile(lastTag.Datum, beginnBlock, tageNichtGekürzt, tageNichtAufgenommen, tageGekürzt, lastAbwesenheitsstatus,
                                         listAbwExtended, dbCalc, IDAbwesenheit, countLine)

                    End If
                End If
            End If

            'Überprüfung: Wurden alle Leistungen von Kostenträgern übernommen bzw. Leistung von Klienten zu bezahlen
            Dim rOffLeist As dbPMDS.OffeneLeistungenRow = Me.doOffKostenGes(dbCalc)
            Return rOffLeist

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub PrintAbwZeile(ByRef endblock As Date, ByRef beginnBlock As Date, ByRef tageNichtGekürzt As Integer, ByRef tageNichtAufgenommen As Integer, ByRef tageGekürzt As Integer,
                           ByRef Abwesenheitsstatus As Integer, ByRef listAbwExtended As ArrayList, ByRef dbCalc As dbCalc,
                           ByRef IDAbwesenheit As String, ByRef countLine As Integer)



        Dim neueZeile As New cAbw()
        countLine += 1

        If countLine = 1 Then
            neueZeile.Patient = Me.rowKlient(dbCalc).Nachname.Trim() + " " + Me.rowKlient(dbCalc).Vorname.Trim()
        End If

        Dim txtTemp As String = ""
        If Abwesenheitsstatus = 0 Then                                      'Nicht aufgenommen
            txtTemp = "Nicht aufgenommen"
            neueZeile.NichtAufgenommen = tageNichtAufgenommen.ToString()

        ElseIf Abwesenheitsstatus = 1 Then                                  'Anwesend
            txtTemp = "Anwesend"
            neueZeile.ohneKürzung = tageNichtGekürzt.ToString()
            neueZeile.TageReservierung = tageGekürzt.ToString()

        ElseIf Abwesenheitsstatus = 2 Then                                  'Abwesend
            If tageNichtGekürzt > 0 And tageGekürzt = 0 Then
                txtTemp = "Abwesenheit"
            Else
                txtTemp = "Reservierung"
            End If
            neueZeile.ohneKürzung = tageNichtGekürzt.ToString()
            neueZeile.TageReservierung = tageGekürzt.ToString()
            Dim sTxtVonBis As String = ""
            Dim sTxtVon As String = ""
            Dim sTxtVonBisGrund As String = ""
            If IDAbwesenheit.Trim() <> "" Then
                Dim abw As dbCalc.AbwesenheitenRow = Me.getAbwesenheit(IDAbwesenheit, dbCalc)
                Me.getTxtAbwesenheitTxt(dbCalc, sTxtVonBis, sTxtVon, sTxtVonBisGrund, abw)
                neueZeile.Abwesendheitsgrund = sTxtVonBisGrund
            End If

        ElseIf Abwesenheitsstatus = 3 Then    'Entlassungstag
            txtTemp = "Entlassung"
            neueZeile.ohneKürzung = tageNichtGekürzt.ToString()
            neueZeile.TageReservierung = tageGekürzt.ToString()

        ElseIf Abwesenheitsstatus = 4 Then    'Entlassungstag
            txtTemp = "Entlassen"
            neueZeile.NichtAufgenommen = tageNichtAufgenommen.ToString()

        Else
            Throw New Exception("PrintAbwZeile: lastAnwStatus " + Abwesenheitsstatus.ToString() + " is wrong!")
        End If

        neueZeile.Text = txtTemp + " " + beginnBlock.ToString(Me.dateFormat) + " - " + endblock.ToString(Me.dateFormat)
        listAbwExtended.Add(neueZeile)
    End Sub

    Public Function getAbwesenheit(IDAbwesenheit As String, ByRef dbCalc As dbCalc) As dbCalc.AbwesenheitenRow
        Dim arrAbwesenheit() As dbCalc.AbwesenheitenRow = dbCalc.Abwesenheiten.Select("ID='" + IDAbwesenheit + "'", "")
        If arrAbwesenheit.Length <> 1 Then
            Throw New Exception("getAbwesenheit: arrAbwesenheit.Length <> 1 !")
        End If
        Return arrAbwesenheit(0)
    End Function

    Public Function getTxtAbwesenheitTxt(ByRef dbCalc As dbCalc,
                                         ByRef sTxtVonBis As String, ByRef sTxtVon As String, ByRef sTxtVonBisGrund As String,
                                         ByRef abwesenheit As dbCalc.AbwesenheitenRow) As String

        sTxtVon = "von " + abwesenheit.Von.ToString(Me.dateFormat)
        sTxtVonBis = sTxtVon + " bis " & IIf(abwesenheit.Bis.ToString(Me.dateFormat) = Me.dat2999, "laufend ", abwesenheit.Bis.ToString(Me.dateFormat))
        sTxtVonBisGrund = abwesenheit.Grund.Trim()    'sTxtVonBis.Trim() + " wegen " + 
    End Function
    Public Sub doNextMonth(ByRef calc As calcData, ByRef rKost As dbCalc.KostenträgerRow, ByRef RollungJN As Boolean,
                           ByRef billFormat As formatAttr, ByRef editor As TXTextControl.TextControl, IDKlinik As System.Guid, Bereich As String,
                           ByRef Prot As String, ByRef iCounterProt As Integer)
        Try

            If rKost.VorauszahlungJN And Not RollungJN And Not Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then  'Vorauszahlung  nur bei Monatsabrechnung berechnen

                Dim nextMonth As Date = Me.rowMonat(calc.dbCalc).Beginn.AddMonths(1)
                Dim calculation As New calculation()
                Dim calcVorausz As calcData = calculation.run(Me.rowKlient(calc.dbCalc).ID, nextMonth,
                                                               Me.monatsende(Me.rowMonat(calc.dbCalc).Beginn.AddMonths(1)),
                                                              Me.rowMonat(calc.dbCalc).RechDatum, False,
                                                              PMDS.Calc.Logic.eCalcTyp.vorauszahlung, eCalcRun.month, calculation.editorPrecalc, IDKlinik, Bereich, Prot, iCounterProt)
                Dim mwstVorausz As Decimal = 0

                For Each rKostVorausz As dbCalc.KostenträgerRow In calcVorausz.dbCalc.Kostenträger
                    If rKostVorausz.IDKost = rKost.IDKost Then
                        If rKostVorausz.ZahlungsbetragNetto > 0 Then

                            'Prüfen, ob die Leistungsart übereinstimmt

                            If rKostVorausz.GrundleistungJN = rKost.GrundleistungJN And rKostVorausz.PeriodischeLeistungJN = rKost.PeriodischeLeistungJN And rKostVorausz.SonderleistungJN = rKost.SonderleistungJN Then
                                Dim sTxtMonthNetto As String = "Vorauszahlung Netto für " + Format(nextMonth, "MMMM yyyy")

                                Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                                bill.setPrintColumn(IDBillRtfRZ, eTypProt.VorauszahlNetto, 0, sTxtMonthNetto, rKostVorausz.ZahlungsbetragNetto, 0, 0, 0, billFormat)
                                bill.add(IDBillRtfRZ, eTypProt.VorauszahlNetto, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)

                                Me.doMWStCalc(calcVorausz, rKostVorausz.IDKostIntern, rKostVorausz.IDKost, billFormat, editor, mwstVorausz)
                                Me.doMWStPrint(calcVorausz, rKostVorausz.IDKostIntern, rKostVorausz.IDKost, billFormat, editor)

                                Dim sTxtMonthBrutto As String = "Vorauszahlung Brutto für " + Format(nextMonth, "MMMM yyyy")
                                IDBillRtfRZ = System.Guid.NewGuid()
                                bill.setPrintColumn(IDBillRtfRZ, eTypProt.VorauszahlBrutto, 0, sTxtMonthBrutto, 0, 0, rKostVorausz.ZahlungsbetragNetto + mwstVorausz, 0, billFormat)
                                bill.add(IDBillRtfRZ, eTypProt.VorauszahlBrutto, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)

                                rKost.Ueberweisungsbetrag += rKostVorausz.ZahlungsbetragBrutto

                                ' Transferleistungen, wenn welche vorhanden, vom Zahlungsbetrag abziehen (immer Brutto)
                                If rKost.GrundleistungJN And rKost.RestzahlerJN And Not rKost.TransferzahlerJN Then
                                    Me.doTransfer(calcVorausz, rKost.IDKostIntern, rKost.IDKost, billFormat, editor)
                                End If
                            End If
                        End If
                    End If
                Next
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub doAcconto(ByRef calc As calcData, ByRef rKost As dbCalc.KostenträgerRow, ByRef RollungJN As Boolean,
                         ByRef billFormat As formatAttr, ByRef editor As TXTextControl.TextControl, IDKlinik As System.Guid)
        Try
            'os 22.9.09: Konto Acconto gestrichen, alle Zahlungen werden brutto von Zahlungen auf Kundenforderungen gebucht

            'Dim OffenesAcconto As Decimal = booking.sollMinusHaben(Me.rowKlient(calc.dbCalc).ID, rKost.IDKost, Me.dat1900, Me.rowMonat(calc.dbCalc).Ende, "Kundenforderungen", "", eCalcRun.month)

            'Keine Einschränkung für Zeitraum. Auch Zahlungen, die für die Zukunft eingetragen sind, werden berücksichtigt. os, 2009-10-08
            Dim OffenesAcconto As Decimal = booking.sollMinusHaben(Me.rowKlient(calc.dbCalc).ID, False, rKost.IDKost, Me.dat1900, Me.dat2999, "Kundenforderungen", "", eCalcRun.month, IDKlinik)

            Dim AccontoVerwendbar As Decimal = 0
            If OffenesAcconto <> 0 And Not RollungJN And Not Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then  'Kontostand nur bei Monatsabrechnung berücksichtigen

                'offenes Acconto kann negativ sein
                AccontoVerwendbar = OffenesAcconto
                If OffenesAcconto < 0 Then
                    rKost.Ueberweisungsbetrag += Math.Abs(AccontoVerwendbar)
                    If AccontoVerwendbar < 0 Then AccontoVerwendbar *= -1
                Else
                    rKost.Ueberweisungsbetrag -= Math.Abs(AccontoVerwendbar)
                    If AccontoVerwendbar > 0 Then AccontoVerwendbar *= -1
                End If

                If OffenesAcconto < 0 Then
                    Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ, eTypProt.AbzüglSumAccontoZahl, 0, "zzgl. offener Forderungen", 0, 0, AccontoVerwendbar, 0, billFormat)
                    bill.add(IDBillRtfRZ, eTypProt.AbzüglSumAccontoZahl, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)
                Else
                    Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ, eTypProt.AbzüglSumAccontoZahl, 0, "abzgl. Saldo Ihrer Zahlungen", 0, 0, AccontoVerwendbar, 0, billFormat)
                    bill.add(IDBillRtfRZ, eTypProt.AbzüglSumAccontoZahl, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor)
                End If
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function doLZPrintSum(ByRef calc As calcData, ByRef rKost As dbCalc.KostenträgerRow,
                         ByRef billFormat As formatAttr, ByRef editor As TXTextControl.TextControl, ByVal nettoBrutto As String) As Decimal
        Try
            Dim alleLeistZeilenProKost As dbPMDS.LeistungzeileDataTable = Me.doLeistZeilen(rKost, calc, True)

            For Each r As dbPMDS.LeistungzeileRow In alleLeistZeilenProKost
                Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                'bill.setPrintColumn(IDBillRtfRZ, eTypProt.LZ, r.Menge, r.Bezeichnung + " á " + Me.dec3WithEuro(r.BetragNettoEH), r.BetragNetto, r.MWStSatz, 0, 0, billFormat)
                'bill.add(IDBillRtfRZ, eTypProt.LZ, billFormat, calc.dbCalc, rKost.IDKostIntern, rKost.IDKost, Me.rowKlient(calc.dbCalc).calcTyp, 0, 0, 0, "", editor, False, False, r.FIBU.Trim(), r.IDLeistung.Trim())

                Dim rowNewRechZ As dbCalc.KostenKostenträgerRow
                If rKost.IDKostIntern.Trim() = "" Or rKost.IDKost.Trim() = "" Then
                    Throw New Exception("doBill.doLZPrintSum: rKost.IDKostIntern.Trim() = '' Or rKost.IDKost.Trim() = ''  not allowed!")
                End If

                rowNewRechZ = Me.bill.newRechZeile(calc.dbCalc)
                rowNewRechZ.ID = VB.LCase(IDBillRtfRZ.ToString())
                rowNewRechZ.IDKostIntern = rKost.IDKostIntern.ToString()
                rowNewRechZ.IDKost = rKost.IDKost.ToString()
                rowNewRechZ.Kennung = eTypProt.LZ.ToString()
                rowNewRechZ.Bezeichnung = r.Bezeichnung.Replace("{Einzelpreis}", " á " + Me.dec3WithEuro(r.BetragNettoEH))
                rowNewRechZ.Anzahl = r.Menge
                rowNewRechZ.Netto = r.BetragNetto
                rowNewRechZ.MWSt = r.MWStSatz
                rowNewRechZ.Brutto = 0
                rowNewRechZ.MWStSatz = 0
                rowNewRechZ.FIBU = r.FIBU.Trim().Trim()
                rowNewRechZ.IDLeistung = r.IDLeistung.Trim().Trim()
                rowNewRechZ.IDSonderLeistungskatalog = r.IDSonderLeistungskatalog.Trim().Trim()
                rowNewRechZ.IDLeistungsKatalog = r.IDLeistungsKatalog.Trim().Trim()
                rowNewRechZ.IDManBuch = r.IDManBuch
                bill.lfdNr += 1

                rowNewRechZ.lfdNr = bill.lfdNr
                calc.dbCalc.KostenKostenträger.Rows.Add(rowNewRechZ)
                'Me.print.addCollumn(IDBillRtfRZ, billFormat, editor, False, False, eTypProt.LZ)
            Next

            'Me.doRollung(rKost, calc)

            Dim SummeLeistungen As Decimal = 0
            For Each r As dbCalc.KostenKostenträgerRow In calc.dbCalc.KostenKostenträger
                If r.Kennung.Trim().ToLower().Equals(eTypProt.LZ.ToString().Trim().ToLower()) Then
                    If r.IDKost.Equals(rKost.IDKost) Then
                        SummeLeistungen += r.Netto
                        bill.setPrintColumn(New System.Guid(r.ID), eTypProt.LZ, r.Anzahl, r.Bezeichnung, r.Netto, r.MWSt, r.Brutto, r.MWStSatz, billFormat)
                        Me.print.addCollumn(New System.Guid(r.ID), billFormat, editor, False, False, eTypProt.LZ)
                    End If
                End If
            Next
            Return SummeLeistungen

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function doMWStCalc(ByRef Calc As calcData, ByVal IDKostIntern As String, ByVal IDKost As String,
                           ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef editor As TXTextControl.TextControl, ByRef SumMWst As Decimal) As Decimal
        Try
            Dim t As New dbCalc.MWStBasenDataTable
            Dim arrMwStBasen As dbCalc.MWStBasenRow()
            arrMwStBasen = Calc.dbCalc.MWStBasen.Select("IDKostIntern='" + IDKostIntern + "'", "MWStSatz asc")
            For Each r As dbCalc.MWStBasenRow In arrMwStBasen
                If r.NettoBetrag <> 0 Then
                    SumMWst += r.MWSt
                End If
            Next
            Return SumMWst

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function doMWStPrint(ByRef Calc As calcData, ByVal IDKostIntern As String, ByVal IDKost As String,
                       ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef editor As TXTextControl.TextControl) As Decimal
        Try
            ' Forderung-Mwst
            Dim t As New dbCalc.MWStBasenDataTable
            Dim arrMwStBasen As dbCalc.MWStBasenRow()
            arrMwStBasen = Calc.dbCalc.MWStBasen.Select("IDKostIntern='" + IDKostIntern + "'", "MWStSatz asc")
            For Each r As dbCalc.MWStBasenRow In arrMwStBasen
                If r.NettoBetrag <> 0 Then
                    'If r.MWSt <> 0 Then                    '<20120111>   Auch 0 Mwst wird in RechZeiel angedruckt für Export
                    Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                    bill.setPrintColumn(IDBillRtfRZ, eTypProt.MWStSatz, 0, "+ " + Me.decWithEuro(r.MWStSatz) + "%  MwSt von " + Me.decWithEuro(r.NettoBetrag), r.MWSt, 0, 0, r.MWStSatz, billFormat)
                    bill.add(IDBillRtfRZ, eTypProt.MWStSatz, billFormat, Calc.dbCalc, IDKostIntern, IDKost, Me.rowKlient(Calc.dbCalc).calcTyp,
                             Me.decWithEuro(r.NettoBetrag), Me.decWithEuro(r.BruttoBetrag), Me.decWithEuro(r.MWSt), r.KontoExport, editor)
                End If
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function doTransfer(ByRef Calc As calcData, ByVal IDKostIntern As String, ByVal IDKost As String,
                        ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef editor As TXTextControl.TextControl) As Decimal
        Try
            Dim sumBetragTransfer As Decimal = 0

            Dim arrKostenträger() As dbCalc.KostenträgerRow = Calc.dbCalc.Kostenträger.Select("Rang = 10", "")
            For Each rKost As dbCalc.KostenträgerRow In arrKostenträger
                sumBetragTransfer += rKost.MaxBetragBrutto
            Next

            If sumBetragTransfer <> 0 Then
                Dim IDBillRtfRZ As System.Guid = System.Guid.NewGuid()
                bill.setPrintColumn(IDBillRtfRZ, eTypProt.selbstbehalt, 0, "abzüglich Eigenleistung", 0, 0, sumBetragTransfer * -1, 0, billFormat)
                bill.add(IDBillRtfRZ, eTypProt.selbstbehalt, billFormat, Calc.dbCalc, IDKostIntern, IDKost, Me.rowKlient(Calc.dbCalc).calcTyp, 0, 0, 0, "", editor)
            End If

            Return sumBetragTransfer

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function doBillBuchungen(ByRef Calc As calcData, ByVal IDKostIntern As String, ByVal rKost As dbCalc.KostenträgerRow,
                     ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByVal sumLeistBrutto As Decimal, ByRef editor As TXTextControl.TextControl, IDKlinik As System.Guid) As Decimal
        Try

            'Bei Transferzahlern den maximalen Zahlungsbetrag buchen. Bei Überzahlung bleibt der Rest als Vortrag fürs nächste Monat stehen.
            If rKost.TransferzahlerJN Then
                booking.saveBooking(eKonto.Zahlungen, eKonto.Kundenforderungen, Me.rowMonat(Calc.dbCalc).Beginn,
                     "Transferzahlungen", rKost.MaxBetragBrutto, -1, "",
                     Me.rowKlient(Calc.dbCalc).ID, rKost.IDKost, Calc, False, Me.rowKlient(Calc.dbCalc).calcRun, IDKlinik)

                booking.saveBooking(eKonto.Kundenforderungen, eKonto.Erlöse, Me.rowMonat(Calc.dbCalc).Beginn,
                     "Transferzahlungen", rKost.MaxBetragBrutto, -1, "",
                     Me.rowKlient(Calc.dbCalc).ID, rKost.IDKost, Calc, False, Me.rowKlient(Calc.dbCalc).calcRun, IDKlinik)

            Else
                Dim MWSt As Decimal = rKost.ZahlungsbetragBrutto - rKost.ZahlungsbetragNetto
                booking.saveBooking(eKonto.Kundenforderungen, eKonto.Erlöse, Me.rowMonat(Calc.dbCalc).Beginn,
                                     "Rechnungsbetrag", rKost.ZahlungsbetragBrutto - MWSt, -1, "",
                                    Me.rowKlient(Calc.dbCalc).ID, rKost.IDKost, Calc, False, Me.rowKlient(Calc.dbCalc).calcRun, IDKlinik)

                booking.saveBooking(eKonto.Kundenforderungen, eKonto.USt, Me.rowMonat(Calc.dbCalc).Beginn,
                                    "USt", MWSt, -1, "",
                                    Me.rowKlient(Calc.dbCalc).ID, rKost.IDKost, Calc, False, Me.rowKlient(Calc.dbCalc).calcRun, IDKlinik)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


    Private Function doLeistZeilen(ByRef rKost As dbCalc.KostenträgerRow, ByRef calc As calcData,
                                   Optional ByVal ForRechnung As Boolean = False) As dbPMDS.LeistungzeileDataTable
        Try
            'Leistungen eines Zeitraums zurückgeben
            Dim TageReduziert As Object
            Dim TageVoll As Integer = 0
            Dim KostenträgerZahlt As Boolean = False
            Dim KostenträgerFürRechnungszeile As Boolean = False
            Dim Nr As Integer = 0

            Dim tLeistZeile As New dbPMDS.LeistungzeileDataTable

            'Kein Filter nach Kostenträger
            Dim IDKostIntern As String = ""
            If Not rKost Is Nothing Then IDKostIntern = rKost.IDKostIntern

            For Each rLeist As dbCalc.LeistungenRow In calc.dbCalc.Leistungen

                KostenträgerZahlt = False
                KostenträgerFürRechnungszeile = False

                If VB.Left(IDKostIntern, 2) = "7d" Then
                    Dim x As String = ""
                    Dim bez As String = rLeist.LeistungBezeichnung
                End If

                'Rückgabe nur jener Zeilen, in der der Kostenträger tatsächlich zahlt.
                Dim arrZahler As dbCalc.ZahlerRow() = calc.dbCalc.Zahler.Select("IDKostIntern='" + IDKostIntern + "' and IDLeistung='" + rLeist.ID.ToString() + "' ")
                For Each r As dbCalc.ZahlerRow In arrZahler
                    If r.IDKostIntern = IDKostIntern Then KostenträgerZahlt = True ' der angegeben Kostenträger zahlt etwas zur Leistung
                Next

                If ForRechnung Then
                    'Rückgabe der Leistungszeilen für die Rechnung
                    'Hier muss der Klient nicht zahlen, er muss nur ein Kostenträger für die jeweilige Leistungsart sein
                    If (rKost.GrundleistungJN And (rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente) Or
                            rKost.PeriodischeLeistungJN And rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Or
                            rKost.SonderleistungJN And rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen) Then
                        KostenträgerFürRechnungszeile = True

                    End If
                End If

                KostenträgerZahlt = KostenträgerZahlt Or KostenträgerFürRechnungszeile

                If KostenträgerZahlt Or IDKostIntern = "" Then
                    If rLeist.MonatsleistungJN = False Then         'Tagesleistungen
                        TageVoll = 0
                        TageReduziert = 0

                        Dim arrTagesLeist As dbCalc.TagesleistungenRow() = calc.dbCalc.Tagesleistungen.Select("IDLeistung='" + rLeist.ID.ToString() + "'")
                        For Each r As dbCalc.TagesleistungenRow In arrTagesLeist       'Anzahl volle Tage und reduziuerte Tage ermitteln
                            If r.Datum >= Me.rowMonat(calc.dbCalc).Beginn And r.Datum <= Me.rowMonat(calc.dbCalc).Ende Then
                                If r.ReduziertJN = True Then TageReduziert += 1
                                If r.ReduziertJN = False Then TageVoll += 1
                            End If
                        Next

                        If TageVoll <> 0 Then
                            Dim rLeistZeile As dbPMDS.LeistungzeileRow = Me.newLeistZeilen(rLeist, Nr, tLeistZeile, calc)
                            rLeistZeile.Menge = TageVoll
                            rLeistZeile.BetragNettoEH = rLeist.TagespreisNetto
                            rLeistZeile.BetragNetto = Math.Round(rLeistZeile.Menge * rLeistZeile.BetragNettoEH, 2)
                            rLeistZeile.FIBU = rLeist.FIBU.Trim()
                            rLeistZeile.IDLeistungsKatalog = rLeist.IDLeistungskatalog
                            rLeistZeile.IDSonderLeistungskatalog = rLeist.IDSonderleistung
                            rLeistZeile.IDManBuch = rLeist.IDManBuch
                            rLeistZeile.Bezeichnung += "{Einzelpreis}"

                            tLeistZeile.Rows.Add(rLeistZeile)
                        End If

                        If TageReduziert <> 0 Then
                            Dim rLeistZeile As dbPMDS.LeistungzeileRow = Me.newLeistZeilen(rLeist, Nr, tLeistZeile, calc)
                            rLeistZeile.Menge = TageReduziert
                            rLeistZeile.BetragNettoEH = rLeist.TagespreisReduziertNetto
                            rLeistZeile.BetragNetto = Math.Round(rLeistZeile.Menge * rLeistZeile.BetragNettoEH, 2)
                            rLeistZeile.FIBU = rLeist.FIBU.Trim()
                            rLeistZeile.IDLeistungsKatalog = rLeist.IDLeistungskatalog
                            rLeistZeile.IDSonderLeistungskatalog = rLeist.IDSonderleistung
                            rLeistZeile.IDManBuch = rLeist.IDManBuch

                            rLeistZeile.Bezeichnung += "{Einzelpreis}"
                            rLeistZeile.Bezeichnung += vbCrLf + "Abwesenheiten:"
                            For Each abw As dbCalc.AbwesenheitenRow In calc.dbCalc.Abwesenheiten
                                Dim strBis As String = IIf(abw.Bis = New Date(2999, 12, 31), "laufend", abw.Bis.ToString("dd.MM.yyyy"))
                                rLeistZeile.Bezeichnung += vbCrLf + abw.Grund + " (" + abw.Von.ToString("dd.MM.yyyy") + "-" + strBis + ")"
                            Next

                            tLeistZeile.Rows.Add(rLeistZeile)
                        End If
                    Else      'Monatsleistung
                        Dim rLeistZeile As dbPMDS.LeistungzeileRow = Me.newLeistZeilen(rLeist, Nr, tLeistZeile, calc)
                        tLeistZeile.Rows.Add(rLeistZeile)
                        rLeistZeile.FIBU = rLeist.FIBU.Trim()
                        rLeistZeile.IDLeistungsKatalog = rLeist.IDLeistungskatalog
                        rLeistZeile.IDSonderLeistungskatalog = rLeist.IDSonderleistung
                        rLeistZeile.IDManBuch = rLeist.IDManBuch

                        If rLeistZeile.Leistungsgruppe = 3 Then     'Sonderleistung
                            rLeistZeile.Menge = rLeistZeile.Menge
                            rLeistZeile.BetragNettoEH = rLeist.TagespreisNetto
                            rLeistZeile.BetragNetto = Math.Round(rLeist.MonatspreisNetto, 2)

                        Else                                        'Grund- und Periodische Leistungen
                            rLeistZeile.BetragNettoEH = rLeist.MonatspreisNetto
                            rLeistZeile.BetragNetto = Math.Round(rLeistZeile.BetragNettoEH, 2)
                            rLeistZeile.Menge = 1

                        End If
                    End If
                End If
            Next

            'Me.doRollung(rKost, calc, tLeistZeile, ForRechnung)

            Return tLeistZeile

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function newLeistZeilen(ByRef rLeist As dbCalc.LeistungenRow, ByRef Nr As Integer,
                                    ByRef tLeistZeile As dbPMDS.LeistungzeileDataTable, ByRef calc As calcData) As dbPMDS.LeistungzeileRow
        Try
            'Leistungszeile anlegen
            Dim rNew As dbPMDS.LeistungzeileRow = tLeistZeile.NewRow()
            Nr += 1
            rNew.Von = Me.rowMonat(calc.dbCalc).Beginn
            rNew.Bis = Me.rowMonat(calc.dbCalc).Ende
            rNew.Bezeichnung = rLeist.LeistungBezeichnung
            rNew.Detail = rLeist.ZeitraumDetail
            rNew.Nummer = Nr
            rNew.MWStSatz = rLeist.MWStSatz
            rNew.IDLeistung = rLeist.ID
            rNew.Leistungsgruppe = rLeist.Leistungsgruppe
            rNew.Menge = rLeist.Anzahl
            rNew.BetragNetto = 0
            rNew.BetragNettoEH = 0
            rNew.FIBU = ""
            rNew.IDLeistungsKatalog = ""
            rNew.IDSonderLeistungskatalog = ""
            rNew.IDManBuch = ""

            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function doOffKostenGes(ByRef dbCalc As dbCalc) As dbPMDS.OffeneLeistungenRow
        Try
            'Gibt alle noch nicht bezahlten Leistungen der angegeben Art im jeweiligen Zeitraum aus
            '0,1 .. Grundleistung
            '2 .. Periodische Leistung
            '3 .. Sonderleistung

            'Offene Leistungen in G rund- und periodischen Leistungen
            'Dim tl As clsTagesleistung
            'Dim l As leistung

            Dim dbHelp As New dbPMDS()
            Dim rOffLeist As dbPMDS.OffeneLeistungenRow = dbHelp.OffeneLeistungen.NewRow()
            rOffLeist.GrundleistungMonatlich = 0
            rOffLeist.GrundleistungMonatlich = 0
            rOffLeist.GrundleistungTäglich = 0
            rOffLeist.PeriodischeLeistungMonatlich = 0
            rOffLeist.PeriodischeLeistungTäglich = 0
            rOffLeist.Sonderleistung = 0

            For Each rLeistIterate As dbCalc.LeistungenRow In dbCalc.Leistungen
                If rLeistIterate.MonatsleistungJN Then
                    Select Case rLeistIterate.Leistungsgruppe
                        Case 0, 1
                            rOffLeist.GrundleistungMonatlich += +rLeistIterate.OffenNetto
                        Case 2
                            rOffLeist.PeriodischeLeistungMonatlich += +rLeistIterate.OffenNetto
                        Case 3
                            rOffLeist.Sonderleistung += +rLeistIterate.OffenNetto
                    End Select
                Else
                    Dim arrTagesLeist As dbCalc.TagesleistungenRow() = dbCalc.Tagesleistungen.Select("IDLeistung='" + rLeistIterate.ID.ToString() + "'")
                    For Each rTagesLeist As dbCalc.TagesleistungenRow In arrTagesLeist
                        If rTagesLeist.Datum >= Me.rowMonat(dbCalc).Beginn And rTagesLeist.Datum <= Me.rowMonat(dbCalc).Ende Then
                            Select Case rTagesLeist.Leistungsgruppe
                                Case 0, 1
                                    rOffLeist.GrundleistungTäglich += rTagesLeist.OffenNetto
                                Case 2
                                    rOffLeist.PeriodischeLeistungTäglich += rTagesLeist.OffenNetto
                                Case 3
                                    'es gibt keine täglichen Sonderleistungen
                            End Select
                        End If
                    Next
                End If
            Next

            Return rOffLeist

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


    Public Sub save(ByVal status As eBillStatus, ByRef calc As calcData, ByVal IDKlinik As System.Guid)
        Try
            Dim bOK As Boolean = False
            Dim IDAbrechnung As String = Me.bill.saveRechKopf(calc, Me.rowKlient(calc.dbCalc).ID.ToString,
                                                                 Me.rowMonat(calc.dbCalc).Beginn.Month,
                                                                 Me.rowMonat(calc.dbCalc).Beginn.Year, IDKlinik)

            If Not IDAbrechnung <> "" And Me.saveBill(IDAbrechnung, status, False, calc, IDKlinik) Then
                Throw New Exception("doBill.save: Error saving bill!")
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Private Function saveBill(ByVal IDAbrechnung As String,
                                    ByVal status As eBillStatus, ByVal freigegeben As Boolean,
                                    ByRef calc As calcData, ByRef IDKlinik As System.Guid) As Boolean
        Try

            For Each rKost As dbCalc.KostenträgerRow In calc.dbCalc.Kostenträger

                'Keine Rechnung -> Rechnung nicht erzeugen. Leere Rechnungen (0-Summen) nicht erzeugen.
                If Not rKost.RechnungJN Or
                        (rKost.Ueberweisungsbetrag = 0 And rKost.sumNetto = 0) Or
                        (rKost.TransferzahlerJN And rKost.Ueberweisungsbetrag = 0) Then
                    Continue For
                End If

                Dim rNew As dbPMDS.billsRow = Me.bill.newRowBill(IDKlinik)
                rNew.ID = System.Guid.NewGuid.ToString()
                rNew.IDKlinik = IDKlinik
                rNew.Freigegeben = freigegeben
                rNew.RechNr = ""
                rNew.datum = New DateTime(Me.rowMonat(calc.dbCalc).Beginn.Year, Me.rowMonat(calc.dbCalc).Beginn.Month, 1).Date
                rNew.KlientName = Me.rowKlient(calc.dbCalc).Nachname + " " + Me.rowKlient(calc.dbCalc).Vorname
                rNew.KostenträgerName = rKost.FamName
                rNew.Status = CInt(status)
                rNew.Typ = IIf(rKost.RechnungJN, rKost.RechnungTyp, CInt(eBillTyp.KeineRechnung))
                rNew.Rechnung = rKost.Rechnung
                rNew.IDKlient = Me.rowKlient(calc.dbCalc).ID.ToString()
                rNew.IDKost = rKost.IDKost.ToString()
                rNew.IDKostIntern = rKost.IDKostIntern.ToString()
                rNew.betrag = rKost.Ueberweisungsbetrag
                rNew.IDAbrechnung = IDAbrechnung
                rNew.IDSR = ""
                rNew.dbBill = Me.dbBill.getXMLDbBill(calc.dbBill)
                rNew.RechDatum = Me.rowMonat(calc.dbCalc).RechDatum.Date

                Me.sql.insertBill(rNew)

                'If rNew.betrag <> 0 Then
                'If Me.checkAndereKostenträgerSumLeist(rKost, IDAbrechnung, status, freigegeben, calc, rNew.KlientName, rNew.datum, IDKlinik, Prot, iCounterProt) Then
                'Me.sql.insertBill(rNew)
                'End If
                'End If
            Next
            Return True

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function checkAndereKostenträgerSumLeist(ByRef rKost As dbCalc.KostenträgerRow, ByVal IDAbrechnung As String,
                                                ByVal status As eBillStatus, ByVal freigegeben As Boolean,
                                                ByRef calc As calcData, ByRef KlientName As String, RechDatum As DateTime, ByRef IDKlinik As System.Guid, ByRef Prot As String, ByRef iCounterProt As Integer) As Boolean
        Try
            Return True

            'Funktioniert nicht bei rundungsdifferenzen und bei Abwesenheiten
            'Dim arrKost() As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.Select("IDKostIntern='" + rKost.IDKostIntern + "'", "")
            'Dim rKostInfo As dbCalc.KostenträgerRow = arrKost(0)

            'Dim arrRechZeilen() As dbCalc.KostenKostenträgerRow = calc.dbCalc.KostenKostenträger.Select("IDKostIntern='" + rKost.IDKostIntern + "'", "lfdNr")
            'For Each rRechZ As dbCalc.KostenKostenträgerRow In arrRechZeilen
            '    Dim NettoSumAlleZahler As Decimal = 0
            '    If rRechZ.Kennung = eTypProt.LZ.ToString() Then
            '        Dim arrZahler() As dbCalc.ZahlerRow = calc.dbCalc.Zahler.Select("IDLeistung='" + rRechZ.IDLeistung + "'", "")
            '        For Each rZahler As dbCalc.ZahlerRow In arrZahler
            '            NettoSumAlleZahler += rZahler.NettoBetragProLeistung
            '        Next
            '    End If
            '    If rRechZ.Netto = NettoSumAlleZahler Then
            '        Return True
            '    Else
            '        Dim arrLeistung() As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.Select("ID='" + rRechZ.IDLeistung + "'", "")
            '        Dim rLeistung As dbCalc.LeistungenRow = arrLeistung(0)

            '        Dim sInfoTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Leistung {0} für Klient {1} im Monat {2} kann nicht vollständig verrechnet werden") + "!"
            '        Dim sMonat As String = RechDatum.Month.ToString() + "-" + RechDatum.Year.ToString()
            '        sInfoTxt = System.String.Format(sInfoTxt, rLeistung.LeistungBezeichnung.Trim(), KlientName, sMonat)

            '        iCounterProt += 1
            '        Prot += iCounterProt.ToString() + "." + QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis") + " - " + sInfoTxt + vbNewLine + vbNewLine
            '        Return False
            '    End If
            'Next
            'Return True

            'If rKost.GrundleistungJN Then
            'ElseIf rKost.PeriodischeLeistungJN Then
            'ElseIf rKost.SonderleistungJN Then
            'End If

            'If r("EnumKostentraegerart") = 0 Or r("EnumKostentraegerart") = 3 Or r("EnumKostentraegerart") = 5 Or r("EnumKostentraegerart") = 7 Or r("EnumKostentraegerart") = 9 Then
            '    rNewKost.GrundleistungJN = True
            'End If
            'If r("EnumKostentraegerart") = 4 Or r("EnumKostentraegerart") = 5 Or r("EnumKostentraegerart") = 8 Or r("EnumKostentraegerart") = 9 Then
            '    rNewKost.PeriodischeLeistungJN = True
            'End If
            'If r("EnumKostentraegerart") = 6 Or r("EnumKostentraegerart") = 7 Or r("EnumKostentraegerart") = 8 Or r("EnumKostentraegerart") = 9 Then
            '    rNewKost.SonderleistungJN = True
            'End If

        Catch exept As Exception
            Throw New Exception("checkAndereKostenträgerSumLeist: " + exept.ToString())
        End Try
    End Function

    Public Sub delete(ByVal IDAbrechnung As String, ByVal sr As Boolean, ByVal depot As Boolean, IDKlinik As System.Guid)
        Try
            Dim dbPMDS As New dbPMDS
            Me.sql.readBills(IDAbrechnung, dbPMDS)
            Dim anzDel As Integer = 0
            For Each rBill As dbPMDS.billsRow In dbPMDS.bills
                If rBill.IDSR = "" Then           'Nicht löschbar, wenn auf Sammelrechung oder aus FSW-ZAUF

                    ' Wenn sr - IDSR in zugehörigen bills rückesetzen
                    If sr Then
                        Dim dbPMDSBillsSR As New dbPMDS
                        Me.sql.readBillsSR(rBill.ID, dbPMDSBillsSR, IDKlinik)
                        For Each rBillInSR As dbPMDS.billsRow In dbPMDSBillsSR.bills
                            Me.sql.saveIDSR(rBillInSR.ID, "")
                        Next
                    ElseIf depot Then
                        Dim rHeader As dbPMDS.billHeaderRow = Me.getHeader(rBill.IDAbrechnung, IDKlinik)
                        Dim dbCalc As dbCalc
                        dbCalc = Me.getDBCalc(rHeader.dbCalc)
                        For Each rID As dbCalc.KostenKostenträgerRow In dbCalc.KostenKostenträger
                            Me.sql.saveDepot(rID.IDKostIntern, False)
                        Next
                    End If

                    'Verweis auf nicht freigegbene Rollung löschen, wenn Rollung vor Freigabe gelöscht wird.
                    Me.sql.delBill(rBill.ID)
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                        Dim tBills3 As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.IDBillStorno.Contains(rBill.ID)
                        For Each rBill33 As db.Entities.bills In tBills3
                            rBill33.IDBillStorno = ""
                            rBill33.RollungAnz = 0
                        Next
                        db.SaveChanges()
                    End Using
                    anzDel += 1
                End If
            Next

            ' Header nur löschen wenn alle bills gelöscht werden konnten
            If anzDel = dbPMDS.bills.Rows.Count Then Me.sql.delBillHeader(IDAbrechnung)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub doAction(ByVal listIDBills As System.Collections.Generic.List(Of String), ByVal sr As Boolean,
                        ByRef editor As TXTextControl.TextControl, ByVal typ As String, ByVal IDKlinik As System.Guid,
                        ByVal checkFreigabe As Boolean, ByRef listIDDoStorno As System.Collections.Generic.List(Of dbPMDS.billsRow), datStornodatum As Nullable(Of Date), Optional dbCalcFoundNew As dbCalc = Nothing)
        Try

            Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                Dim listIDCalculated As New System.Collections.Generic.List(Of String)
                Dim listIDFSW As New System.Collections.Generic.List(Of String)

                For Each IDBill As String In listIDBills
                    If Me.IDIsCalculated(IDBill, listIDCalculated) Then
                        Continue For
                    End If

                    Dim rBill2 As dbPMDS.billsRow = Me.sql.readBill(IDBill)
                    Dim rHeader As dbPMDS.billHeaderRow = Me.getHeader(rBill2.IDAbrechnung, IDKlinik)

                    Dim stxtMsgBox As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es gibt bereits eine freigegebene Rechnung vom {0}. Das Datum dieser Rechnung muss daher auf {1} gesetzt werden.") + vbNewLine +
                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("Soll das durchgeführt werden?")
                    Dim bDateModified As Boolean = False
                    Dim abortRechDatumTmp As Boolean = False
                    Dim dRechDatumTmp As Date = rBill2.RechDatum.Date

                    Dim rLastRechDate As PMDS.db.Entities.bills = Nothing

                    If rBill2.RechNr = "ForStorno;" Then
                        rLastRechDate = (From o In db.bills Where o.Status = eBillStatus.storniert Order By o.RechDatum Descending).FirstOrDefault()
                    ElseIf rBill2.Status = eBillStatus.offen Then
                        rLastRechDate = (From o In db.bills Where o.Status = eBillStatus.freigegeben Order By o.RechDatum Descending).FirstOrDefault()
                    End If

                    If Not rLastRechDate Is Nothing AndAlso rBill2.RechDatum.Date < rLastRechDate.RechDatum.Value.Date Then

                        If datStornodatum Is Nothing Or datStornodatum < rLastRechDate.RechDatum.Value.Date Then
                            If Now.Date < rLastRechDate.RechDatum.Value.Date Then
                                dRechDatumTmp = rLastRechDate.RechDatum.Value.Date
                                stxtMsgBox = String.Format(stxtMsgBox, rLastRechDate.RechDatum.Value.Date.ToString("dd.MM.yyyy"), rLastRechDate.RechDatum.Value.Date.ToString("dd.MM.yyyy"))
                                bDateModified = True
                            Else
                                dRechDatumTmp = Now.Date
                                stxtMsgBox = String.Format(stxtMsgBox, rLastRechDate.RechDatum.Value.Date.ToString("dd.MM.yyyy"), Now.Date.Date.ToString("dd.MM.yyyy"))
                                bDateModified = True
                            End If
                        End If

                    End If

                    If bDateModified Then
                        If Not QS2.Desktop.ControlManagment.ControlManagment.MessageBox(stxtMsgBox, "Rechnungsdatum wird geändert", MessageBoxButtons.YesNo, True) = DialogResult.Yes Then
                            abortRechDatumTmp = True
                        End If
                    End If

                    If Not abortRechDatumTmp Then
                        Using dbCalc As dbCalc = Me.getDBCalc(rHeader.dbCalc)
                            'Dim dbPMDS As New dbPMDS
                            'Me.sql.readBills(idAbrech, dbPMDS)

                            'Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                            '    Dim tBills As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o. =
                            '                            Dim rKlinik As PMDS.db.Entities.Klinik = tKlinik.First()
                            '                            If rKlinik.Rechnungsformular.Trim() <> "" Then
                            '        fileTmp = rKlinik.Rechnungsformular.Trim()
                            '    End If
                            'End Using

                            'For Each rBill As dbPMDS.billsRow In dbPMDS.bills
                            Dim srJN As Boolean = If(sr, False, Me.sammelrechnungJN(dbCalc, rBill2.IDKostIntern))

                            Select Case typ
                                Case "f"
                                    If Not rBill2.Freigegeben Then
                                        Dim sRechNr As String = ""
                                        If rBill2.IDKost <> kostenträger.IDKostKlient Then
                                            'Dim dbHelp As New dbPMDS()
                                            'Me.sql.readKostenräger(r.IDKost, dbHelp, True)
                                            'Dim rKostDatxy As dbPMDS.KostentraegerRow = dbHelp.Kostentraeger.Rows(0)
                                            If sr Then
                                                If rBill2.Typ <> CInt(eBillTyp.Sammelrechnung) Then Throw New Exception("doBill.freigeben: Rechnung ist nicht vom Typ sr!")
                                                If Not checkFreigabe Then
                                                    If rBill2.RechNr.Equals("ForStorno;") Then
                                                        Dim rechNrStorno As String = Me.modifyBill(rBill2, eModify.stornoRech, "[StornoNr]", "", True, editor, dbCalc, bill.typRechNr)
                                                        Dim rBillEFUpdate As PMDS.db.Entities.bills = (From o In db.bills Where o.ID = rBill2.ID).FirstOrDefault()
                                                        rBillEFUpdate.RechNr = rechNrStorno.Trim()
                                                        rBillEFUpdate.Status = CInt(eBillStatus.freigegeben).ToString()
                                                        rBillEFUpdate.Freigegeben = True
                                                        rBillEFUpdate.Status = eBillStatus.storniert
                                                        If bDateModified Then
                                                            rBillEFUpdate.RechDatum = dRechDatumTmp
                                                        End If
                                                        db.SaveChanges()
                                                        If bDateModified Then
                                                            Dim rBillBack As dbPMDS.billsRow = Me.sql.readBill(rBillEFUpdate.ID)
                                                            Me.modifyBill(rBillBack, eModify.rechDatum, "[RechDatum]", "", True, editor, dbCalc, bill.typRechNr, False, dRechDatumTmp.Date, True)
                                                        End If
                                                    Else
                                                        sRechNr = Me.modifyBill(rBill2, eModify.rechNr, "[RechNr]", "", True, editor, dbCalc, bill.typRechNr.ToLower(), False, Nothing, False)
                                                    End If
                                                    If calcBase.bookingJN Then
                                                        Me.saveTempBuchungen(dbCalc, rBill2, sRechNr, eModify.nichts, eCalcRun.month)
                                                    End If
                                                End If
                                            Else
                                                If Not srJN And rBill2.Typ <> CInt(eBillTyp.KeineRechnung) Then
                                                    If Not checkFreigabe Then
                                                        If rBill2.RechNr.Trim().ToLower().Equals(("ForStorno;").Trim().ToLower()) Then
                                                            Dim rechNrStorno As String = Me.modifyBill(rBill2, eModify.stornoRech, "[StornoNr]", "", True, editor, dbCalc, bill.typRechNr)
                                                            Me.sql.saveBillRechNr(rBill2.ID, rechNrStorno.Trim())
                                                            Me.sql.stornieren(rBill2.ID)
                                                            'sRechNr = Me.modifyBill(rBill2, eModify.rechNr, "[RechNr]", "", True, editor, dbCalc, bill.typRechNr.ToLower())
                                                            If bDateModified Then
                                                                Dim rBillBack As dbPMDS.billsRow = Me.sql.readBill(rBill2.ID)
                                                                Me.modifyBill(rBillBack, eModify.rechDatum, "[RechDatum]", "", True, editor, dbCalc, bill.typRechNr, False, dRechDatumTmp.Date, True)
                                                            End If
                                                        Else
                                                            Me.modifyBill(rBill2, eModify.rechDatum, "[RechDatum]", "", True, editor, dbCalc, bill.typRechNr, False, dRechDatumTmp.Date, True)
                                                            sRechNr = Me.modifyBill(rBill2, eModify.rechNr, "[RechNr]", "", True, editor, dbCalc, bill.typRechNr.ToLower())
                                                        End If
                                                        If calcBase.bookingJN Then
                                                            Me.saveTempBuchungen(dbCalc, rBill2, sRechNr, eModify.nichts, Me.rowKlient(dbCalc).calcRun)
                                                        End If
                                                    End If
                                                ElseIf srJN And rBill2.Typ = CInt(eBillTyp.Beilage) Then
                                                    'Beilagen zu Sammelrechnungen dürfen nicht freigegeben werden
                                                    'Throw New Exception("coBill.doAction: srJN And rBill2.Typ = CInt(eBillTyp.Beilage) not allowed!")
                                                    'Me.sql.saveFreigabe(rBill2.ID)
                                                End If
                                            End If
                                        Else
                                            If sr Then Throw New Exception("doBill.freigeben: Rechnung für typ sr kann kein Klientenkostenträger sein!!")
                                            sRechNr = Me.modifyBill(rBill2, eModify.rechNr, "[RechNr]", "", True, editor, dbCalc, bill.typRechNr.ToLower())
                                            ' Überprüfung - Zahlungen aus Transferleistungen buchen - testen!
                                            If calcBase.bookingJN Then
                                                Me.saveTempBuchungen(dbCalc, rBill2, sRechNr, eModify.nichts, Me.rowKlient(dbCalc).calcRun)
                                            End If
                                        End If

                                        listIDCalculated.Add(IDBill)
                                        listIDDoStorno.Add(rBill2)
                                    End If

                                Case "fsw"

                                    'Bereits übertragen = not ok
                                    'freigegeben = ok
                                    Dim a As New PMDS.db.Entities.Abteilung
                                    listIDFSW.Add(IDBill)

                                Case "s"
                                    If rBill2.Freigegeben Then
                                        If rBill2.Typ = eBillTyp.Rechnung Or eBillTyp.FreieRechnung Or sr Then
                                            Dim IDBillGeneratedBack As String = ""
                                            Me.doStornoBill(rBill2, rHeader.ID, sr, editor, datStornodatum, IDBillGeneratedBack, db, dbCalcFoundNew)
                                            If sr And bDateModified Then
                                                Dim rBillBack As dbPMDS.billsRow = Me.sql.readBill(IDBillGeneratedBack)
                                                Me.modifyBill(rBillBack, eModify.rechDatum, "[RechDatum]", "", True, editor, dbCalc, bill.typRechNr, False, dRechDatumTmp.Date, True)
                                                'Dim rBillEFUpdate As PMDS.db.Entities.bills = (From o In db.bills Where o.ID = rBill2.ID).FirstOrDefault()
                                                'rBillEFUpdate.RechDatum = dRechDatumTmp.Date
                                                'db.SaveChanges()
                                            End If
                                        Else
                                            Me.modifyBill(rBill2, eModify.field, "[RechTitel]", "Storno zu", True, editor, dbCalc, bill.typRechNr)
                                            Me.sql.stornieren(rBill2.ID)
                                            If calcBase.bookingJN And Not srJN Then
                                                Me.saveTempBuchungen(dbCalc, rBill2, rBill2.RechNr, eModify.negativ, If(Not sr, Me.rowKlient(dbCalc).calcRun, eCalcRun.month))
                                            End If
                                        End If
                                        listIDCalculated.Add(IDBill)
                                    End If
                            End Select
                        End Using
                    End If
                Next
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub doStornoBill(rBillOrig As dbPMDS.billsRow, IDHeader As String, ByVal sr As Boolean, ByRef editor As TXTextControl.TextControl,
                            rechDat As Nullable(Of Date), ByRef IDBillGeneratedBack As String, db As PMDS.db.Entities.ERModellPMDSEntities, Optional dbCalcFoundNewxy As dbCalc = Nothing)
        Try
            editor.Text = ""
            If rBillOrig.IDBillStorno.Trim() <> "" Then
                Throw New Exception("doStornoBill: rBillOrig.IDBillStorno.Trim()<>'' not allowed for IDBill '" + rBillOrig.ID.Trim() + "'!")
            End If

            'Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
            db.Configuration.LazyLoadingEnabled = False

            Dim rBillToModify As dbPMDS.billsRow = Nothing
            Dim tBillHeader As IQueryable(Of PMDS.db.Entities.billHeader) = From o In db.billHeader.AsNoTracking Where o.ID = rBillOrig.IDAbrechnung
            Dim rBillHeader As PMDS.db.Entities.billHeader = tBillHeader.First()
            Dim rBillHeaderCopy As New PMDS.db.Entities.billHeader()

            rBillHeaderCopy.ID = System.Guid.NewGuid().ToString("D")
            rBillHeaderCopy.dbCalc = rBillHeader.dbCalc
            rBillHeaderCopy.protokoll = rBillHeader.protokoll
            rBillHeaderCopy.IDKlinik = rBillHeader.IDKlinik
            db.billHeader.Add(rBillHeaderCopy)

            Dim rBillCopy As New PMDS.db.Entities.bills()
            rBillCopy.ID = System.Guid.NewGuid().ToString("D")
            rBillCopy.Freigegeben = False
            'rBillCopy.RechNr = rBillOrig.RechNr
            rBillCopy.RechNr = "ForStorno;"
            rBillCopy.RechDatum = rechDat.Value.Date
            rBillCopy.datum = rBillOrig.datum
            rBillCopy.KlientName = rBillOrig.KlientName
            rBillCopy.KostenträgerName = rBillOrig.KostenträgerName
            rBillCopy.Status = eBillStatus.offen      'rBillOrig.Status
            rBillCopy.Typ = rBillOrig.Typ
            rBillCopy.Rechnung = rBillOrig.Rechnung
            rBillCopy.IDKlient = rBillOrig.IDKlient
            rBillCopy.IDKost = rBillOrig.IDKost
            rBillCopy.IDKostIntern = rBillOrig.IDKostIntern
            rBillCopy.betrag = rBillOrig.betrag * -1
            rBillCopy.IDAbrechnung = rBillHeaderCopy.ID
            rBillCopy.Erstellt = calculation.usr
            rBillCopy.ErstellAm = Now
            rBillCopy.dbBill = rBillOrig.dbBill
            If Not rBillOrig.IsIDKlinikNull() Then
                rBillCopy.IDKlinik = rBillOrig.IDKlinik
            Else
                rBillCopy.IDKlinik = Nothing
            End If

            rBillCopy.IDSR = ""                     'os: 2021-03-21: neu erzeugte Storno-Rechnung kann nicht auf einer Sammelrechnung / FSW-ZAUF sein:  rBillCopy.IDSR = rBillOrig.IDSR
            rBillCopy.IDBillStorno = ""             'rBillOrig.ID.Trim() + ";"
            rBillCopy.ExportiertJN = False
            rBillCopy.RollungAnz = 0
            rBillCopy.IDBillsGerollt = ""            'os: 2021-03-30: statt "". Als Kennzeichen für FSW, dass es sich um eine Rollung handelt

            db.bills.Add(rBillCopy)
            db.SaveChanges()

            Using dbCalc2 As dbCalc = Me.getDBCalc(rBillHeaderCopy.dbCalc)
                Dim srJN As Boolean = If(sr, False, Me.sammelrechnungJN(dbCalc2, rBillOrig.IDKostIntern))
                Dim tbillsRN As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = rBillOrig.ID
                Dim rBillRN As PMDS.db.Entities.bills = tbillsRN.First()

                rBillRN.IDBillStorno = rBillCopy.ID.Trim() + ";"
                db.SaveChanges()

                Using SqlUpdate As New Sql()
                    rBillToModify = SqlUpdate.readBill(rBillCopy.ID)
                End Using

                Dim sStornoText = "Storno zu "
                If (rBillOrig.RechNr.Length = 0) Then   'Storno für eine nicht freigegebene Rechnung. Original-Rechnugnsnummer abfragen
                    Dim sRechNrOriginal = Interaction.InputBox("Bitte geben Sie die Original-Rechnungsnummer ein:", rBillOrig.KlientName + ", Rechnung vom " + rBillOrig.RechDatum.ToString("F"), "")
                    sStornoText += sRechNrOriginal
                End If

                Me.modifyBill(rBillToModify, eModify.field, "[RechTitel]", sStornoText, False, editor, dbCalc2, bill.typRechNr)
                Me.modifyBill(rBillToModify, eModify.field, "Zahlungsbetrag", "Stornobetrag", False, editor, dbCalc2, bill.typRechNr, True)
                Me.modifyBill(rBillToModify, eModify.rechDatum, "[RechDatum]", "", True, editor, dbCalc2, bill.typRechNr, False, rBillCopy.RechDatum)

                Dim bAnyChangesXMLDBHeader As Boolean
                Me.modifyBillTableKosten(sr, dbCalc2, rBillToModify.Typ, rBillToModify.Status, New System.Guid(rBillToModify.IDKostIntern), eTypeModifyBill.StornoRechnung, rBillToModify, editor, bAnyChangesXMLDBHeader, dbCalcFoundNewxy)

                If calcBase.bookingJN And Not srJN Then
                    Me.saveTempBuchungen(dbCalc2, rBillToModify, "", eModify.negativ, If(Not sr, Me.rowKlient(dbCalc2).calcRun, eCalcRun.month))
                End If

                Dim XMLDBBill As String = Me.bill.getXMLDbCalc(dbCalc2)
                rBillToModify.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                Me.sql.saveBill(rBillToModify.ID, rBillToModify.Rechnung)
                Me.sql.saveDbBillHeader(rBillHeaderCopy.ID, XMLDBBill)
            End Using

            IDBillGeneratedBack = rBillCopy.ID

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(calculation.getDbEntityValidationException(ex), ex)
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub modifyBillTableKosten(isSR As Boolean, dbCalcFound As dbCalc, billTyp As eBillTyp, billStatus As eBillStatus, IDKostIntern As Guid, TypeModifyBill As eTypeModifyBill, rBillToModify As dbPMDS.billsRow, editor As TXTextControl.TextControl,
                                         ByRef bAnyChangesXMLDBHeader As Boolean, Optional dbCalcFoundNew2xy As dbCalc = Nothing)
        Try
            Dim arrCalcDocu() As DataRow = dbCalcFound.Tables(dbCalcFound.KostenKostenträger.TableName).Select(dbCalcFound.KostenKostenträger.IDKostInternColumn.ColumnName + "='" + IDKostIntern.ToString() + "'",
                                                                                                                 dbCalcFound.KostenKostenträger.lfdNrColumn.ColumnName + " asc")

            For Each rKostenKostenträger As dbCalc.KostenKostenträgerRow In arrCalcDocu
                If rKostenKostenträger.Netto <> 0 Then
                    rKostenKostenträger.Netto = rKostenKostenträger.Netto * -1
                ElseIf rKostenKostenträger.MWSt <> 0 Then
                    rKostenKostenträger.MWSt = rKostenKostenträger.MWSt * -1
                ElseIf rKostenKostenträger.Brutto <> 0 Then
                    rKostenKostenträger.Brutto = rKostenKostenträger.Brutto * -1
                End If
                Me.replaceValueInTXTControlTable(rKostenKostenträger, dbCalcFound, billTyp, billStatus, IDKostIntern, TypeModifyBill, rBillToModify, editor, bAnyChangesXMLDBHeader)
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub replaceValueInTXTControlTable(rKostenKostenträger As dbCalc.KostenKostenträgerRow, dbCalcFound As dbCalc, billTyp As eBillTyp, billStatus As eBillStatus, IDKostIntern As Guid,
                                             TypeModifyBill As eTypeModifyBill, rBillToModify As dbPMDS.billsRow, editor As TXTextControl.TextControl, ByRef bAnyChangesXMLDBHeader As Boolean)
        Try
            Dim nRowNr As Integer = 0
            Dim nCellNr As Integer = 0

            For Each txtField As TXTextControl.TextField In editor.TextFields
                If txtField.Name.Trim().ToLower().Contains(rKostenKostenträger.ID.ToString().Trim().ToLower()) Then
                    If txtField.Name.Trim().ToLower().Contains("_netto_") And rKostenKostenträger.Netto <> 0 Then
                        txtField.Text = String.Format("{0:c}", rKostenKostenträger.Netto)
                        bAnyChangesXMLDBHeader = True
                    ElseIf txtField.Name.Trim().ToLower().Contains("_mwst_") And rKostenKostenträger.MWSt <> 0 Then
                        txtField.Text = rKostenKostenträger.MWSt.ToString() + "" + ""
                        bAnyChangesXMLDBHeader = True
                    ElseIf txtField.Name.Trim().ToLower().Contains("_brutto_") And rKostenKostenträger.Brutto <> 0 Then
                        txtField.Text = String.Format("{0:c}", rKostenKostenträger.Brutto)
                        bAnyChangesXMLDBHeader = True
                    End If
                End If
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function sammelrechnungJN(ByVal dbCalc As dbCalc, ByVal IDKostIntern As String) As Boolean
        Try
            Dim rKost As dbCalc.KostenträgerRow = Me.getKostIntern(dbCalc, IDKostIntern)
            Return rKost.SammelabrechnungJN

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getKostIntern(ByVal dbCalc As dbCalc, ByVal IDKostIntern As String) As dbCalc.KostenträgerRow
        Try
            Dim arrKost() As dbCalc.KostenträgerRow = dbCalc.Kostenträger.Select("IDKostIntern = '" + IDKostIntern + "'")
            If arrKost.Length <> 1 Then Throw New Exception("doAction.Storno: IDKostIntern in dbCalc nicht gefunden!")
            Return arrKost(0)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function SetRechnungKopie(ByVal r As PMDS.Calc.Logic.dbPMDS.billsRow, ByRef editor As TXTextControl.TextControl)
        Try
            editor.Text = ""
            Me.doEditor.showText(r.Rechnung, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editor)
            Me.doBookmarks.setBookmark("[RechNr]", r.RechNr + " - KOPIE", editor)

        Catch except As Exception
            calcBase.doExept(except)
        End Try
    End Function

    Public Function SetRechnungsadresseVersand(ByVal r As PMDS.Calc.Logic.dbPMDS.billsRow, ByRef editor As TXTextControl.TextControl, Titel As String, Nachname As String, Vorname As String, Plz As String, Ort As String, Strasse As String, Empfaenger As String, Betreff As String)
        Try

            editor.Text = ""
            Me.doEditor.showText(r.Rechnung, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editor)
            Me.doBookmarks.setBookmark("[RechNr]", Betreff, editor)
            Me.doBookmarks.setBookmark("[KostAnrede]", Titel, editor)
            Me.doBookmarks.setBookmark("[KostName]", (Vorname + " " + Nachname).Trim(), editor)
            Me.doBookmarks.setBookmark("[KostEmpf]", Empfaenger, editor)
            Me.doBookmarks.setBookmark("[KostStrasse]", Strasse, editor)
            Me.doBookmarks.setBookmark("[KostAnschrift]", (Plz + " " + Ort).Trim(), editor)

            'Me.doBookmarks.setBookmark("[RechDatum]", "------", editor)
            Me.doBookmarks.setBookmark("[Zahlkond]", "", editor)
            Me.doBookmarks.setBookmark("[BankKlinik]", "", editor)
            Me.doBookmarks.setBookmark("[BankUID]", "", editor)
            Me.doBookmarks.setBookmark("[ZVRHeim]", "", editor)
            Me.doBookmarks.setBookmark("[RechFloskel]", "", editor)

        Catch except As Exception
            calcBase.doExept(except)
        End Try
    End Function

    Public Function modifyBill(ByVal r As PMDS.Calc.Logic.dbPMDS.billsRow, ByVal typ As eModify,
                                ByVal fld As String, ByVal txt As String, ByVal saveToDB As Boolean,
                                ByRef editor As TXTextControl.TextControl, ByVal dbCalc As dbCalc,
                                ByVal TypRechNr As String, Optional ReplaceTxt As Boolean = False, Optional rechDat As Nullable(Of Date) = Nothing,
                               Optional saveRechDatumToDB As Boolean = False) As String
        Try
            editor.Text = ""
            Me.doEditor.showText(r.Rechnung, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editor)

            Dim rMonat As dbCalc.MonateRow = dbCalc.Monate.Rows(0)
            Select Case typ
                Case eModify.rechNr
                    Dim sRechNr As String = Me.getRechNr(r, typ, rMonat.RechDatum, TypRechNr)
                    Me.doBookmarks.setBookmark(fld, "Rechnung " + sRechNr, editor)
                    r.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                    If saveToDB Then
                        Me.sql.saveFreigabe(r.ID, sRechNr, r.Rechnung)
                    End If
                    Return sRechNr

                Case eModify.rechNrKopie
                    Me.doBookmarks.setBookmark(fld, "Rechnung " + TypRechNr, editor)
                    r.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                    If saveToDB Then
                        Me.sql.saveFreigabe(r.ID, TypRechNr, r.Rechnung)
                    End If
                    Return TypRechNr

                Case eModify.stornoRech
                    Dim datRechTmp As New Date(Now.Year, rMonat.RechDatum.Month, rMonat.RechDatum.Day, 0, 0, 0)
                    Dim sStornoRechNr As String = Me.getRechNr(r, typ, datRechTmp.Date, TypRechNr)
                    Me.doBookmarks.setBookmark(fld, "StornoNr: " + sStornoRechNr, editor)
                    r.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                    If saveToDB Then Me.sql.saveFreigabe(r.ID, r.RechNr, r.Rechnung)

                    Using Bill As dbBill = Me.dbBill.getDbBill(r.dbBill)
                        dbBill.saveStornoRechNr(r.ID, Bill, sStornoRechNr)
                        Return sStornoRechNr
                    End Using

                Case eModify.rechDatum
                    Me.doBookmarks.setBookmark(fld, rechDat.Value.ToString("dd.MM.yyyy"), editor)
                    r.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                    If saveToDB Then Me.sql.saveBill(r.ID, r.Rechnung)
                    If saveRechDatumToDB Then Me.sql.saveBill(r.ID, rechDat.Value.Date)
                    Return ""

                Case eModify.field
                    If ReplaceTxt Then
                        If editor.Text.Contains(fld) Then
                            Dim iPosVar1 As Integer = 0
                            While iPosVar1 <> -1
                                iPosVar1 = editor.Find(fld, iPosVar1, TXTextControl.FindOptions.NoMessageBox)
                                If iPosVar1 <> -1 Then
                                    editor.SelectionViewMode = TXTextControl.SelectionViewMode.Classic
                                    editor.Selection.Start = iPosVar1
                                    editor.Selection.Length = fld.Trim().Length
                                    editor.Selection.Text = txt.Trim()
                                End If
                            End While
                        End If
                    Else
                        Me.doBookmarks.setBookmark(fld, txt, editor)
                    End If
                    r.Rechnung = Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)
                    If saveToDB Then Me.sql.saveBill(r.ID, r.Rechnung)

            End Select

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getRechNr(ByVal r As PMDS.Calc.Logic.dbPMDS.billsRow, ByVal modifyTyp As eModify, _
                              ByVal RechDatum As Date, ByVal TypRechNr As String) As String
        Try
            Dim rechNr As Integer = -1
            Dim sRechNr As String = ""

            If TypRechNr.Equals(PMDS.Calc.Logic.eTypRechNr.Standard.ToString(), StringComparison.CurrentCultureIgnoreCase) Or _
                    r.Typ = eBillTyp.Zahlungsbestätigung Or r.Typ = eBillTyp.Beilage Then

                rechNr = Me.sql.getRechNr(r.Typ, RechDatum.Year, RechDatum.Month, modifyTyp, TypRechNr)
                If modifyTyp = eModify.stornoRech Then
                    sRechNr = "ST-"
                Else
                    Select Case r.Typ
                        Case eBillTyp.Rechnung, eBillTyp.Sammelrechnung, eBillTyp.FreieRechnung
                            sRechNr = "AR-"
                        Case eBillTyp.Zahlungsbestätigung
                            sRechNr = "ZB-"
                        Case eBillTyp.Beilage
                            sRechNr = "BL-"
                    End Select
                End If
                sRechNr += RechDatum.Year.ToString + "-" + Right("00000" & rechNr.ToString(), 5)

            ElseIf TypRechNr.Equals(PMDS.Calc.Logic.eTypRechNr.lfdNr.ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                rechNr = Me.sql.getRechNr(eBillTyp.Rechnung, RechDatum.Year, RechDatum.Month, modifyTyp, TypRechNr)
                sRechNr += bill.Bereich + Right(RechDatum.Year.ToString, 2) + Right("00000" & rechNr.ToString(), 5)

            ElseIf TypRechNr.Equals(PMDS.Calc.Logic.eTypRechNr.Monatlich.ToString(), StringComparison.CurrentCultureIgnoreCase) Then        '<20121123>
                rechNr = Me.sql.getRechNr(eBillTyp.Rechnung, RechDatum.Year, RechDatum.Month, modifyTyp, TypRechNr)
                sRechNr += bill.Bereich + Right(RechDatum.Year.ToString, 4) + "-" + Right("00000" & rechNr.ToString(), 5)

            Else
                Throw New Exception("getRechNr: typRechNr '" + bill.typRechNr.ToLower() + "' not allowed!")
            End If

            Return sRechNr

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub saveTempBuchungen(ByRef dbCalc As dbCalc, ByRef r As dbPMDS.billsRow, _
                            ByVal sRechNr As String, ByVal typ As eModify, ByVal calcRun As eCalcRun)
        Try
            ''   ... Vorbereitete Buchungen von lokaler Tabelle in SQL-Server schreiben
            ''Buchungen vorbereiten
            ''ZahlungsbetragBrutto -> Kundenforderungen (S)
            ''Zahlungbetrag Netto -> Erlöse (H)
            ''MWSt -> USt (H)
            'Dim tBuch As New dbPMDS.arBuchungenDataTable

            Dim arrBuchungen As dbCalc.bookingsRow() = dbCalc.bookings.Select("IDKostenträger='" + r.IDKost + "'")
            For Each rBuch As dbCalc.bookingsRow In arrBuchungen
                'Dim rNew As dbPMDS.arBuchungenRow = tBuch.NewRow()
                'rNew.ItemArray = rBuch.ItemArray()
                rBuch.ID = Me.booking.getIDBooking(calcRun)
                rBuch.RechNr = sRechNr
                If typ = eModify.negativ Then rBuch.Betrag = rBuch.Betrag * -1

                Me.sql.insertBooking(rBuch)
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class
