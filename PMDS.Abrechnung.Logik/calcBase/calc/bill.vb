Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic




Public Class bill
    Inherits calcBase


    Public Shared rechnungRTF As String = "rechnung.rtf"

    Public Shared header As Boolean = True
    Public Shared rechFloskel As Boolean = True
    Public Shared zahlTage As String = ""
    Public Shared MyDepotgeldKontoTxt As String = ""

    Public Shared typRechNr As String = ""
    Public Shared Bereich As String = ""

    Public Shared fldPos As TXTextControl.TextField
    Public Shared lfdNr As Integer = 0

    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public print As New print()
    Public dbBill As New dbBill()

    Public tKostKostenträger As New PMDS.Calc.Logic.dbCalc.KostenKostenträgerDataTable





    Public Sub fillFields(ByRef IDKost As String, ByVal IDKlient As String, ByVal calcTyp As eCalcTyp, _
                         ByVal monat As DateTime, ByVal rechDatum As DateTime, ByRef editor As TXTextControl.TextControl, ByRef BillTyp As eBillTyp, _
                         IDKlinik As System.Guid)
        Dim strExcep As String = ""
        Try
            'If calcTyp = eCalcTyp.vorauszahlung Then Exit Sub

            Dim dbHelp As New dbPMDS()
            strExcep += "1;"
            Me.doBookmarks.setBookmark("[Zahlkond]", "", editor)
            Me.doBookmarks.setBookmark("[Handelsregister]", "", editor)
            Me.doBookmarks.setBookmark("[BankUID]", "", editor)
            strExcep += "2;"
            Dim person As String = ""
            Dim anrede As String = ""

            sql.readKlinik(dbHelp, IDKlinik)
            Dim rKlinikDat As dbPMDS.KlinikRow = dbHelp.Klinik.Rows(0)
            strExcep += "3;"
            If IDKlient <> "" Then
                sql.readKlient(IDKlient, dbHelp, True)
                Dim rKlientDat As dbPMDS.PatientRow = dbHelp.Patient.Rows(0)
                person = IIf(rKlientDat.Titel <> "", rKlientDat.Titel + " ", "") + rKlientDat.Vorname + " " + rKlientDat.Nachname
                anrede = If(rKlientDat.IsAnredeNull(), "", rKlientDat.Anrede)
                If IDKost <> "" And IDKost = kostenträger.IDKostKlient Then
                    Me.doBookmarks.setBookmark("[KostAnrede]", anrede, editor)
                    Me.doBookmarks.setBookmark("[KostName]", person, editor)
                    Me.doBookmarks.setBookmark("[KostEmpf]", "", editor)
                    If (Not rKlientDat.IsWohnungAbgemeldetJNNull()) AndAlso rKlientDat.WohnungAbgemeldetJN = False Then
                        Me.doBookmarks.setBookmark("[KostStrasse]", rKlientDat.Strasse, editor)
                        Me.doBookmarks.setBookmark("[KostAnschrift]", rKlientDat.Plz + " " + rKlientDat.Ort, editor)
                    Else
                        Me.doBookmarks.setBookmark("[KostStrasse]", rKlinikDat.Strasse, editor)
                        Me.doBookmarks.setBookmark("[KostAnschrift]", rKlinikDat.Plz + " " + rKlinikDat.Ort, editor)
                    End If
                End If
                strExcep += "4;"
                Me.doBookmarks.setBookmark("[KostAnrede2]", "", editor)
                Me.doBookmarks.setBookmark("[KostName2]", "", editor)
                Me.doBookmarks.setBookmark("[KostEmpf2]", "", editor)
                Me.doBookmarks.setBookmark("[KostStrasse2]", "", editor)
                Me.doBookmarks.setBookmark("[KostAnschrift2]", "", editor)
                strExcep += "5;"
            End If
            strExcep += "6.0;"
            If IDKost <> "" And IDKost <> kostenträger.IDKostKlient Then
                sql.readKostenräger(IDKost, dbHelp, True)
                strExcep += "6.1;"
                Dim rKostDat As dbPMDS.KostentraegerRow = dbHelp.Kostentraeger.Rows(0)

                Me.doBookmarks.setBookmark("[KostAnrede]", rKostDat.Anrede, editor)
                Me.doBookmarks.setBookmark("[KostName]", If(rKostDat.Vorname = "", "", rKostDat.Vorname + " ") + rKostDat.Name, editor)
                Me.doBookmarks.setBookmark("[KostEmpf]", rKostDat.Rechnungsempfaenger, editor)
                Me.doBookmarks.setBookmark("[KostStrasse]", rKostDat.Strasse, editor)
                Me.doBookmarks.setBookmark("[KostAnschrift]", rKostDat.PLZ + " " + rKostDat.Ort, editor)
                strExcep += "6.2;"
                Me.doBookmarks.setBookmark("[Zahlkond]", Me.getZahlart(rKostDat.ID), editor)
                If rKlinikDat.Zusatz1 <> "" Then
                    Me.doBookmarks.setBookmark("[Handelsregister]", rKlinikDat.Bezeichnung + " " + rKlinikDat.Zusatz3 + ", Handelsregister: " + rKlinikDat.Zusatz1, editor)
                End If
                Me.doBookmarks.setBookmark("[BankUID]", If(rKostDat.UIDNr <> "", "Ihre UID-Nr: " + rKostDat.UIDNr, ""), editor)
                strExcep += "6.3;"
                If Not rKostDat.IsIDKostentraegerSubNull() Then
                    If rKostDat.IDKostentraegerSub <> System.Guid.Empty Then
                        sql.readKostenräger(rKostDat.IDKostentraegerSub.ToString(), dbHelp, True)
                        Dim rKostDat2 As dbPMDS.KostentraegerRow = dbHelp.Kostentraeger.Rows(0)
                        strExcep += "6.4;"
                        Me.doBookmarks.setBookmark("[KostAnrede2]", rKostDat2.Anrede, editor)
                        Me.doBookmarks.setBookmark("[KostName2]", If(rKostDat2.Vorname = "", "", rKostDat2.Vorname + " ") + rKostDat2.Name, editor)
                        Me.doBookmarks.setBookmark("[KostEmpf2]", rKostDat2.Rechnungsempfaenger, editor)
                        Me.doBookmarks.setBookmark("[KostStrasse2]", rKostDat2.Strasse, editor)
                        Me.doBookmarks.setBookmark("[KostAnschrift2]", rKostDat2.PLZ + " " + rKostDat2.Ort, editor)
                    End If
                Else
                    strExcep += "6.5;"
                    Me.doBookmarks.setBookmark("[KostAnrede2]", "", editor)
                    Me.doBookmarks.setBookmark("[KostName2]", "", editor)
                    Me.doBookmarks.setBookmark("[KostEmpf2]", "", editor)
                    Me.doBookmarks.setBookmark("[KostStrasse2]", "", editor)
                    Me.doBookmarks.setBookmark("[KostAnschrift2]", "", editor)
                End If
            End If
            strExcep += "7.0;"
            If bill.header Then
                Me.doBookmarks.setBookmark("[Heimname]", rKlinikDat.Bezeichnung, editor)
                Me.doBookmarks.setBookmark("[HeimStrasse]", rKlinikDat.Strasse, editor)
                Me.doBookmarks.setBookmark("[HeimPLZOrt]", rKlinikDat.Plz + " " + rKlinikDat.Ort, editor)
                Me.doBookmarks.setBookmark("[HeimTelefon]", "Tel.:" + rKlinikDat.Tel, editor)
                Me.doBookmarks.setBookmark("[HeimFax]", "Fax:" + rKlinikDat.Fax, editor)
                Me.doBookmarks.setBookmark("[HeimEMail]", "E-Mail:" + rKlinikDat.Email, editor)
                strExcep += "7.1;"
            Else
                Me.doBookmarks.setBookmark("[Heimname]", "", editor)
                Me.doBookmarks.setBookmark("[HeimStrasse]", "", editor)
                Me.doBookmarks.setBookmark("[HeimPLZOrt]", "", editor)
                Me.doBookmarks.setBookmark("[HeimTelefon]", "", editor)
                Me.doBookmarks.setBookmark("[HeimFax]", "", editor)
                Me.doBookmarks.setBookmark("[HeimEMail]", "", editor)
                strExcep += "7.2;"
            End If
            strExcep += "8.0;"
            If Not editor.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing Then
                strExcep += "8.1;"
                For Each bMark As TXTextControl.TextField In editor.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
                    If bMark.Name.Trim().ToLower().Equals(("[Footer]").Trim().ToLower()) Then
                        Dim sFooter As String = rKlinikDat.Bezeichnung.Trim() + ", " + rKlinikDat.Plz.Trim() + " " + rKlinikDat.Ort.Trim() + ", " + rKlinikDat.Strasse.Trim() + ", Tel.: " + rKlinikDat.Tel.Trim() + vbNewLine
                        strExcep += "8.2;"
                        Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                            Dim tKlinik As IQueryable(Of PMDS.db.Entities.Klinik) = From o In db.Klinik Where o.ID = IDKlinik
                            Dim rKlinik As PMDS.db.Entities.Klinik = tKlinik.First()
                            sFooter += IIf(rKlinik.ZVR.Trim() <> "", "" + rKlinik.ZVR.Trim(), "")
                            strExcep += "8.3;"
                            If Not rKlinik.IDKontakt Is Nothing Then
                                strExcep += "8.4;"
                                Dim tKontakt As IQueryable(Of PMDS.db.Entities.Kontakt) = (From o In db.Kontakt Where o.ID = rKlinik.IDKontakt)
                                If tKontakt.Count > 0 Then
                                    Dim rKontakt As PMDS.db.Entities.Kontakt = tKontakt.First
                                    sFooter += IIf(rKontakt.Zusatz1.Trim() <> "", ", " + rKontakt.Zusatz1.Trim(), "")
                                    sFooter += IIf(rKlinikDat.Email.Trim() <> "", ", " + rKlinikDat.Email.Trim(), "")
                                    sFooter += IIf(rKontakt.Ansprechpartner.Trim() <> "", ", " + rKontakt.Ansprechpartner.Trim(), "")
                                    strExcep += "8.5;"
                                End If
                            End If
                            If Not rKlinik.IDBank Is Nothing Then
                                strExcep += "8.6;"
                                Dim tBank As IQueryable(Of PMDS.db.Entities.Bank) = (From o In db.Bank Where o.ID = rKlinik.IDBank)
                                If tBank.Count > 0 Then
                                    Dim rBank As PMDS.db.Entities.Bank = tBank.First()
                                    sFooter += vbNewLine + "Bankverbindung: " + rBank.Bezeichnung.Trim() + ", IBAN: " + rBank.IBAN.Trim() + ", BIC: " + rBank.BIC.Trim()
                                End If
                            End If
                        End Using
                        strExcep += "8.7;"
                        Me.doBookmarks.setBookmark("[Footer]", sFooter, editor)
                        strExcep += "8.8;"
                    End If
                Next
            End If

            Dim sIBANTmp As String = ""
            If Not rKlinikDat.IsIBANNull() Then
                sIBANTmp = rKlinikDat.IBAN.Trim()
            End If
            Dim sIBICTmp As String = ""
            If Not rKlinikDat.IsBICNull() Then
                sIBICTmp = rKlinikDat.BIC.Trim()
            End If
            strExcep += "9.0;"
            Dim bankKlinik As String = ""
            If BillTyp = eBillTyp.Depotgeld And bill.DepotgeldKontoTxt <> "" Then
                bankKlinik = "Unsere Bankverbindung: " + bill.DepotgeldKontoTxt
            Else
                If rKlinikDat.Bank.Trim <> "" Or sIBANTmp.Trim <> "" Or sIBICTmp.Trim <> "" Then
                    If rKlinikDat.Bank.Trim <> "" Then
                        bankKlinik += rKlinikDat.Bank.Trim
                    End If
                    If sIBANTmp.Trim <> "" Then
                        If bankKlinik <> "" Then bankKlinik += ", "
                        bankKlinik += "IBAN: " + sIBANTmp
                    End If
                    If sIBICTmp.Trim <> "" Then
                        If bankKlinik <> "" Then bankKlinik += ", "
                        bankKlinik += "BIC: " + sIBICTmp
                    End If
                    bankKlinik = "Unsere Bankverbindung: " + bankKlinik
                End If
            End If
            strExcep += "10.0;"
            Me.doBookmarks.setBookmark("[BankKlinik]", bankKlinik, editor)

            Me.doBookmarks.setBookmark("[StornoNr]", "", editor)
            Me.doBookmarks.setBookmark("[RechTitel]", "", editor)
            Me.doBookmarks.setBookmark("[RechNr]", "", editor)
            Me.doBookmarks.setBookmark("[Klientenname]", IIf(person = "", "", "Klient: " + If(anrede = "", "", anrede + " ") + person), editor)
            Me.doBookmarks.setBookmark("[RechDatum]", rechDatum.ToString(Me.dateFormat), editor)
            Me.doBookmarks.setBookmark("[RechZeitraum]", monat.Month.ToString() + "/" + monat.Year.ToString, editor)
            strExcep += "10.1;"
            Me.doBookmarks.setBookmark("[Titel]", "", editor)

            Dim txtHeaderPosZusatz As String = ""
            If BillTyp = eBillTyp.Rechnung Then
                strExcep += "11.0;"
                Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                    Dim IDKlientTmp As New Guid(IDKlient.Trim())
                    Dim tPatient As IQueryable(Of PMDS.db.Entities.Patient) = From o In db.Patient Where o.ID = IDKlientTmp
                    Dim rPatient As PMDS.db.Entities.Patient = tPatient.First()
                    If Not rPatient.Klientennummer Is Nothing Then
                        txtHeaderPosZusatz += IIf(rPatient.Klientennummer.Trim() <> "", ", " + rPatient.Klientennummer.Trim() + " ", "")
                    End If
                    strExcep += "11.1;"
                End Using
            End If
            strExcep += "12.0;"
            Dim txtHeaderPos As String = IIf(person = "", "", "Pflegeleistung für " + If(anrede = "", "", anrede + " ") + person)      '+ Me.addTab(1))
            Me.doBookmarks.setBookmark("[RechTitelDetail]", txtHeaderPos + txtHeaderPosZusatz, editor)
            strExcep += "12.1;"
            Me.doBookmarks.setBookmark("[Zahlungsbestätigung]", "", editor)
            Me.doBookmarks.setBookmark("[RechFloskel]", IIf(bill.rechFloskel, "Mit freundlichen Grüßen", ""), editor)
            strExcep += "13.0;"
            'If BillTyp = eBillTyp.Rechnung Or BillTyp = eBillTyp.Sammelrechnung Then
            '    Const quote As String = """"
            '    Dim sFloskel2 As String = "Wir ersuchen oben ausgewiesenen Betrag sofort nach Erhalt einzuzahlen!" + vbNewLine +
            '                                "Bei Telebanking geben Sie bitte die Rechnungsnummer und die Bewohnernummer bei " + quote + "Zahlungsreferenz" + quote + " ein." + vbNewLine + vbNewLine +
            '                                "Wir bedanken uns für Ihr entgegengebrachtes Vertrauen."
            '    Me.doBookmarks.setBookmark("[RechFloskel2]", sFloskel2, editor)
            'Else
            '    Me.doBookmarks.setBookmark("[RechFloskel2]", "", editor)
            'End If


            Me.doBookmarks.setBookmark("[ZVRHeim]", "Unsere " + rKlinikDat.ZVR, editor)

        Catch exept As Exception
            Throw New Exception("bill.fillFields: Exception-Marker: " + strExcep + "" + vbNewLine + vbNewLine + exept.ToString())
            'calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub fillFieldZahlungsbest(ByRef betrag As Decimal, ByRef editor As TXTextControl.TextControl, ByVal txt As String)

        Try
            Me.doBookmarks.setBookmark("[Zahlungsbestätigung]", txt, editor)
            Me.doBookmarks.setBookmark("[RechTitelDetail]", "", editor)
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub fillFieldZahlungsbest(ByRef betrag As Decimal, ByVal klientName As String, ByVal typZahl As eZahlEA, ByRef editor As TXTextControl.TextControl)

        Try
            Dim txt As String = "Hiermit bestätigen wir die " + typZahl.ToString() + " von " + Me.decWithEuro(betrag) + " für " + klientName + IIf(typZahl = eZahlEA.Einzahlung, " zur Aufstockung des Depotgelds.", " aus dem Depotgeldkonto.")
            Me.doBookmarks.setBookmark("[Zahlungsbestätigung]", txt, editor)
            Me.doBookmarks.setBookmark("[RechTitelDetail]", "", editor)
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub add(ID As Guid, TypProt As eTypProt, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr, ByRef dbCalc As dbCalc,
                    ByRef IDKostIntern As String, ByRef IDKost As String, ByVal calcTyp As eCalcTyp,
                    ByRef tempNetto As Decimal, ByRef tempBrutto As Decimal, ByRef tempMWSt As Decimal, ByRef tempKontoExport As String,
                    ByRef editor As TXTextControl.TextControl,
                    Optional ByVal lineTop As Boolean = False, Optional ByVal TextBold As Boolean = False,
                    Optional ByVal FIBU As String = "", Optional IDLeistung As String = "",
                    Optional IDLeistungsKatalog As String = "", Optional IDSonderLeistungskatalog As String = "",
                    Optional IDKlient As String = "", Optional doNotPrint As Boolean = False, Optional IDManBuch As String = "", Optional IDBill As String = "", Optional lfdNr As Integer = -1)
        Try

            'If calcTyp = eCalcTyp.vorauszahlung Then Exit Sub

            '<20120111>      3 Eingangsparameter neu (ByRef tempNetto As Decimal, ByRef tempBrutto As Decimal, ByRef tempMWSt As Decimal)
            '                für temp Sicherung BMD-Export nach Brutto pro MWSt

            Dim rowNewRechZ As dbCalc.KostenKostenträgerRow
            If IDKostIntern <> "" And IDKost <> "" Then
                rowNewRechZ = Me.newRechZeile(dbCalc)
                rowNewRechZ.ID = VB.LCase(ID.ToString())
                'rowNewRechZ.ID = VB.LCase(System.Guid.NewGuid().ToString())
                rowNewRechZ.IDKostIntern = IDKostIntern.ToString()
                rowNewRechZ.IDKost = IDKost.ToString()
                rowNewRechZ.Kennung = formatAttr.column(tKostKostenträger.KennungColumn.ColumnName).value
                rowNewRechZ.Anzahl = formatAttr.column(tKostKostenträger.AnzahlColumn.ColumnName).value
                rowNewRechZ.Bezeichnung = formatAttr.column(tKostKostenträger.BezeichnungColumn.ColumnName).value
                rowNewRechZ.Netto = formatAttr.column(tKostKostenträger.NettoColumn.ColumnName).value
                rowNewRechZ.MWSt = formatAttr.column(tKostKostenträger.MWStColumn.ColumnName).value
                rowNewRechZ.Brutto = formatAttr.column(tKostKostenträger.BruttoColumn.ColumnName).value
                rowNewRechZ.MWStSatz = formatAttr.column(tKostKostenträger.MWStSatzColumn.ColumnName).value
                rowNewRechZ.FIBU = FIBU.Trim()
                rowNewRechZ.IDLeistung = IDLeistung.Trim()
                rowNewRechZ.IDLeistungsKatalog = IDLeistungsKatalog.Trim()
                rowNewRechZ.IDSonderLeistungskatalog = IDSonderLeistungskatalog.Trim()
                rowNewRechZ.IDManBuch = IDManBuch.Trim()
                rowNewRechZ.IDBill = IDBill.Trim()
                If rowNewRechZ.Kennung = eTypProt.MWStSatz.ToString() Then
                    rowNewRechZ.tempNetto = tempNetto
                    rowNewRechZ.tempBrutto = tempBrutto
                    rowNewRechZ.tempMWSt = tempMWSt
                    rowNewRechZ.tempKontoExport = tempKontoExport       '<20120111-2>

                End If

                If lfdNr <> -1 Then
                    bill.lfdNr = lfdNr
                Else
                    bill.lfdNr += 1
                End If

                rowNewRechZ.lfdNr = bill.lfdNr
                If Not dbCalc Is Nothing Then dbCalc.KostenKostenträger.Rows.Add(rowNewRechZ)
            Else
                Dim str As String = ""
            End If

            If Not doNotPrint Then
                Me.print.addCollumn(ID, formatAttr, editor, lineTop, TextBold, TypProt)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function getPrintColumns() As QS2.Desktop.Txteditor.tableColumn()
        Try
            Dim columns(6) As QS2.Desktop.Txteditor.tableColumn

            Dim col As New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.BezeichnungColumn.ColumnName, 0)
            columns(0) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.AnzahlColumn.ColumnName, 1, True, False)
            columns(1) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.NettoColumn.ColumnName, 2, True, False)
            columns(2) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.MWStColumn.ColumnName, 3, True, False)
            columns(3) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.BruttoColumn.ColumnName, 4, True, False)
            columns(4) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.KennungColumn.ColumnName, 5, False)
            columns(5) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tKostKostenträger.MWStSatzColumn.ColumnName, 6, False)
            columns(6) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function setPrintColumn(IDKostenKostenträger As Guid, ByVal Kennung As eTypProt, ByVal Anzahl As Integer, ByVal Bezeichnung As String,
                                ByVal Netto As Decimal, ByVal MWSt As Integer, ByVal Brutto As Decimal, ByVal MWStSatz As Decimal,
                                ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr) As QS2.Desktop.Txteditor.formatAttr
        Try
            formatAttr.setColumn(tKostKostenträger.BezeichnungColumn.ColumnName, Bezeichnung)
            formatAttr.setColumn(tKostKostenträger.NettoColumn.ColumnName, Math.Round(Netto, 2))
            formatAttr.setColumn(tKostKostenträger.MWStColumn.ColumnName, MWSt)
            formatAttr.setColumn(tKostKostenträger.BruttoColumn.ColumnName, Math.Round(Brutto, 2))
            formatAttr.setColumn(tKostKostenträger.KennungColumn.ColumnName, Kennung.ToString())
            formatAttr.setColumn(tKostKostenträger.AnzahlColumn.ColumnName, Anzahl)
            formatAttr.setColumn(tKostKostenträger.MWStSatzColumn.ColumnName, Math.Round(MWStSatz, 2))
            Return formatAttr

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


    Public Function getPrintColumnsAbw() As QS2.Desktop.Txteditor.tableColumn()
        Try
            Dim columns(0) As QS2.Desktop.Txteditor.tableColumn

            Dim col As New QS2.Desktop.Txteditor.tableColumn("Abwesenheit", 0)
            columns(0) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function setPrintColumnAbwSimple(ByVal txt As String, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr) As QS2.Desktop.Txteditor.formatAttr
        Try
            formatAttr.setColumn("Abwesenheit", txt)
            Return formatAttr

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getPrintColumnsAbw2() As QS2.Desktop.Txteditor.tableColumn()
        Try
            Dim columns(5) As QS2.Desktop.Txteditor.tableColumn

            Dim col As New QS2.Desktop.Txteditor.tableColumn("Patient", 0)
            columns(0) = col

            col = New QS2.Desktop.Txteditor.tableColumn("Abwesenheit", 1)
            columns(1) = col

            col = New QS2.Desktop.Txteditor.tableColumn("OhneKürzung", 2)
            columns(2) = col

            col = New QS2.Desktop.Txteditor.tableColumn("TageReservierung", 3)
            columns(3) = col

            col = New QS2.Desktop.Txteditor.tableColumn("NichtAufgenommen", 4)
            columns(4) = col

            col = New QS2.Desktop.Txteditor.tableColumn("Abwesendheitsgrund", 5)
            columns(5) = col

            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function setPrintColumnAbwExtended(ByRef abwFound As doBill.cAbw, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr) As QS2.Desktop.Txteditor.formatAttr
        Try
            If abwFound.NewPatient Then
                formatAttr.rowTextIsBold = True
            End If
            formatAttr.setColumn("Patient", abwFound.Patient.Trim())
            formatAttr.setColumn("Abwesenheit", abwFound.Text.Trim())
            formatAttr.setColumn("OhneKürzung", abwFound.ohneKürzung.Trim())
            formatAttr.setColumn("TageReservierung", abwFound.TageReservierung.Trim())
            formatAttr.setColumn("NichtAufgenommen", abwFound.NichtAufgenommen.Trim())
            formatAttr.setColumn("Abwesendheitsgrund", abwFound.Abwesendheitsgrund.Trim())

            Return formatAttr

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function newRechZeile(ByRef dbCalc As dbCalc) As dbCalc.KostenKostenträgerRow
        Try
            Dim rNew As dbCalc.KostenKostenträgerRow = dbCalc.KostenKostenträger.NewRow()
            rNew.ID = VB.LCase(System.Guid.NewGuid().ToString())
            rNew.IDKostIntern = ""
            rNew.IDKost = ""
            rNew.Kennung = ""
            rNew.Anzahl = 0
            rNew.Bezeichnung = ""
            rNew.Netto = 0
            rNew.MWSt = 0
            rNew.Brutto = 0
            rNew.lfdNr = 0
            rNew.MWStSatz = 0
            rNew.tempNetto = 0
            rNew.tempBrutto = 0
            rNew.tempMWSt = 0
            rNew.tempKontoExport = ""
            rNew.FIBU = ""
            rNew.IDLeistung = ""
            rNew.IDSonderLeistungskatalog = ""
            rNew.IDLeistungsKatalog = ""
            rNew.IDKlient = ""
            rNew.Classification = ""
            rNew.IDManBuch = ""
            rNew.IDKostInternBill = ""
            rNew.IDKostBill = ""

            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getZahlart(ByVal IDKost As String) As String
        Try
            Dim dbPMDS As New dbPMDS
            sql.readKostenräger(IDKost, dbPMDS, True)
            Dim rKostDat As dbPMDS.KostentraegerRow = dbPMDS.Kostentraeger.Rows(0)
            If rKostDat.IsZahlartNull Then Return ""

            Dim zahlart As eZahlart = rKostDat.Zahlart
            Dim sZahlart As String = Me.zahlartText(zahlart)
            If zahlart = eZahlart.Bankeinzug Then
                If rKostDat.Bank <> "" And rKostDat.Kontonr <> "" Then
                    Return String.Format(sZahlart, " " + rKostDat.Kontonr + " (Bank:" + rKostDat.Bank + ", BLZ:" + rKostDat.BLZ + ") ")
                Else
                    Return String.Format(sZahlart, "")
                End If
            ElseIf zahlart = eZahlart.Erlagschein Or zahlart = eZahlart.Überweisung Or zahlart = eZahlart.Bar Then
                Return sZahlart
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function zahlartText(ByVal zahlart As eZahlart) As String
        Dim sReturn As String = ""
        Select Case zahlart
            Case eZahlart.Bankeinzug
                sReturn = calculation.ZahlKondBankeinzug
            Case eZahlart.Erlagschein
                sReturn = calculation.ZahlKondErlagschein
            Case eZahlart.Überweisung
                sReturn = calculation.ZahlKondÜberweisung
            Case eZahlart.Bar
                sReturn = calculation.ZahlKondBar
            Case Else
                sReturn = "Keine Zahlart angegeben."
        End Select

        sReturn = sReturn.Replace("vbNewLine", vbNewLine)
        Return sReturn

    End Function



    Public Function save(ByVal status As eBillStatus, ByVal monat As DateTime,
                            ByVal rechnung As String, ByVal IDNew As String, ByRef IDKost As String, ByVal IDKostIntern As String, ByVal KostName As String,
                            ByVal gesSum As Decimal, ByRef calc As calcData, ByVal billTyp As eBillTyp,
                            ByVal Klientenname As String, ByVal IDKlient As String, ByVal datum As DateTime, ByVal rechDatum As DateTime, IDKlinik As System.Guid) As String
        Try
            Return Me.saveBill(Me.saveRechKopf(calc, IDKlient, monat.Month, monat.Year, IDKlinik),
                               status, False, monat, rechnung, IDNew, IDKost, IDKostIntern, KostName, gesSum, billTyp, Klientenname, IDKlient, datum,
                               calc, rechDatum, IDKlinik)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function saveRechKopf(ByRef calc As calcData, ByVal IDKlient As String, _
                            ByVal Monat As Integer, ByVal year As Integer, IDKlinik As System.Guid) As String
        Try
            Dim rNew As dbPMDS.billHeaderRow = Me.newRowBillHeader(IDKlinik)
            rNew.dbCalc = Me.getXMLDbCalc(calc.dbCalc)
            rNew.protokoll = calc.protokoll
            rNew.IDKlinik = IDKlinik
            If Me.sql.insertBillHeader(rNew) Then
                Return rNew.ID.ToString
            Else
                Throw New Exception("saveRechKopf: Error")
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getXMLDbCalc(ByVal dbCalc As dbCalc) As String
        Try
            Dim xml As String = ""
            Dim xmlStrWriter As New System.IO.StringWriter()
            Dim xmlWriter As New System.Xml.XmlTextWriter(xmlStrWriter)
            xmlWriter.WriteStartDocument(True)

            dbCalc.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)
            xml = xmlStrWriter.ToString()
            xmlWriter.Close()
            Return xml

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Private Function saveBill(ByVal IDAbrechnung As String,
                                    ByVal status As eBillStatus, ByVal freigegeben As Boolean,
                                    ByVal monat As DateTime, ByVal rechnung As String, ByVal IDNew As String,
                                    ByRef IDKost As String, ByVal IDKostIntern As String, ByVal KostName As String,
                                    ByVal gesSum As Decimal, ByVal billTyp As eBillTyp,
                                    ByVal Klientenname As String, ByVal IDKlient As String, ByVal datum As DateTime, ByVal calc As calcData, ByVal rechDatum As DateTime,
                                    ByVal IDKlinik As System.Guid) As String
        Try
            Dim rNew As dbPMDS.billsRow = Me.newRowBill(IDKlinik)
            rNew.IDKlinik = IDKlinik
            rNew.ID = IDNew
            rNew.Freigegeben = freigegeben
            rNew.datum = datum.Date
            rNew.KostenträgerName = KostName
            rNew.Status = CInt(status)
            rNew.KlientName = Klientenname
            rNew.IDKlient = IDKlient
            rNew.Typ = CInt(billTyp)
            rNew.Rechnung = rechnung
            rNew.IDKost = VB.LCase(IDKost)
            rNew.IDKostIntern = VB.LCase(IDKostIntern)
            rNew.betrag = gesSum
            rNew.IDAbrechnung = IDAbrechnung
            rNew.dbBill = Me.dbBill.getXMLDbBill(calc.dbBill)
            rNew.RechDatum = rechDatum.Date
            Me.sql.insertBill(rNew)
            Return rNew.ID

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function newRowBillHeader(IDKlinik As System.Guid) As dbPMDS.billHeaderRow
        Try
            Dim dbPMDS As New dbPMDS()
            Dim rNew As dbPMDS.billHeaderRow = dbPMDS.billHeader.NewRow()
            rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
            rNew.dbCalc = ""
            rNew.protokoll = ""
            rNew.IDKlinik = IDKlinik
            dbPMDS.billHeader.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function newRowBill(IDKlinik As System.Guid) As dbPMDS.billsRow
        Try
            Dim dbPMDS As New dbPMDS()
            Dim rNew As dbPMDS.billsRow = dbPMDS.bills.NewRow()
            rNew.IDKlinik = IDKlinik
            rNew.ID = VB.LCase(System.Guid.NewGuid().ToString())
            rNew.Freigegeben = False
            rNew.RechNr = ""
            rNew.datum = Now.Date
            rNew.KlientName = ""
            rNew.KostenträgerName = ""
            rNew.Status = CInt(eBillStatus.offen)
            rNew.Typ = CInt(eBillTyp.Rechnung)
            rNew.Rechnung = ""
            rNew.IDKlient = ""
            rNew.IDKost = ""
            rNew.IDKostIntern = ""
            rNew.betrag = 0
            rNew.IDAbrechnung = ""
            rNew.IDSR = ""
            rNew.Erstellt = calcBase.usr
            rNew.ErstellAm = Now
            rNew.dbBill = ""
            rNew.IDBillStorno = ""
            rNew.ExportiertJN = False
            rNew.RollungAnz = 0

            dbPMDS.bills.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class
