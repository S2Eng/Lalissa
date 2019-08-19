Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Imports QS2.Desktop.Txteditor




Public Class doDepotgeld
    Inherits calcBase


    Public bill As New bill()
    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public print As New print()
    Public tDepotPrint As New dbPMDS.TaschengeldDataTable

    Public Shared jahresAbRTF As String = "jahresAb.rtf"




    Public Function run(ByVal idKlient As String, ByVal AbrechnenBis As DateTime, ByVal rechDatum As DateTime, _
                          ByVal editor As TXTextControl.TextControl, ByVal IDKlinik As System.Guid) As calcData
        Try
            Dim calc As New calcData
            idKlient = idKlient.ToLower()

            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
            billFormat.tableNr = 2
            Dim cols() As tableColumn = Me.getPrintColumns()
            billFormat.columns = cols

            Dim IDBill As String = VB.LCase(System.Guid.NewGuid.ToString())
            Dim db As New dbPMDS()

            sql.readKlient(idKlient, db, True)
            Dim rKlientDat As dbPMDS.PatientRow = db.Patient.Rows(0)
            Dim klientenname As String = rKlientDat.Nachname + " " + rKlientDat.Vorname
            Dim kostName As String = klientenname
            Dim IDKost As String = Me.getKostAct(idKlient, AbrechnenBis, kostName)

            print.loadTempStreamToEditor(editor)

            Dim sumAusz As Decimal = 0
            Dim sumEinz As Decimal = 0
            Dim IDListAbgerech As New ArrayList()

            ' Alter Saldo
            Dim alterSaldo As Decimal = Me.readDepotgeldSum(idKlient, eZahlEA.Einzahlung, AbrechnenBis, True, IDKlinik) - Me.readDepotgeldSum(idKlient, eZahlEA.Auszahlung, AbrechnenBis, True, IDKlinik)
            Me.setPrintColumn("Alter Saldo", alterSaldo, billFormat)
            Me.print.addCollumn(Nothing, billFormat, editor)

            ' Alle Ausgaben auf Beleg drucken
            Me.printEA(idKlient, AbrechnenBis, eZahlEA.Auszahlung, db, billFormat, sumAusz, IDListAbgerech, editor, calc, IDKlinik)
            ' Alle Einnahmen auf Beleg drucken
            Me.printEA(idKlient, AbrechnenBis, eZahlEA.Einzahlung, db, billFormat, sumEinz, IDListAbgerech, editor, calc, IDKlinik)

            calc.anz = IDListAbgerech.Count
            'If IDListAbgerech.Count > 0 Then

            ' Neuer Saldo
            Dim neuerSaldo As Decimal = alterSaldo + (sumEinz + sumAusz)
            Me.setPrintColumn("Neuer Saldo", neuerSaldo, billFormat)
            Me.print.addCollumn(Nothing, billFormat, editor, True, False)

            ' Sollstand
            If rKlientDat.Sollstand <> 0 Then
                Me.setPrintColumn("Sollstand", rKlientDat.Sollstand, billFormat)
                Me.print.addCollumn(Nothing, billFormat, editor)
            End If

            ' Zahlungsbetrag
            Dim Zahlungsbetrag As Decimal = IIf(neuerSaldo < rKlientDat.Sollstand, rKlientDat.Sollstand - neuerSaldo, 0)
            Me.setPrintColumn("Zahlungsbetrag", Zahlungsbetrag, billFormat)
            Me.print.addCollumn(Nothing, billFormat, editor, True, True)

            ' Header drucken
            bill.fillFields(IDKost, idKlient, eCalcTyp.abrechnung, rechDatum, rechDatum, editor, eBillTyp.Depotgeld, IDKlinik)
            Me.doBookmarks.setBookmark("[RechTitelDetail]", "", editor)
            Me.doBookmarks.setBookmark("[RechTitel]", calculation.RechTitelDepotGeld, editor)
            print.removeTable(3, editor)
            print.removeTable(1, editor)
            print.removeTable(0, editor)
            Me.print.doAutoSiteNummbering(editor)
            Dim beleg As String = doEditor.getText(TXTextControl.StreamType.RichTextFormat, editor)

            calc.protokoll = IDListAbgerech.Count.ToString() + " Positionen wurden abgerechnet!"

            ' Speichern
            Me.bill.save(eBillStatus.offen, Now, beleg, IDBill, IDKost, "", kostName, Zahlungsbetrag, calc, eBillTyp.Depotgeld,
                         klientenname, rKlientDat.ID, AbrechnenBis, rechDatum, IDKlinik)

            ' AbgerechnetJN auf 1
            For Each id As String In IDListAbgerech
                Me.sql.saveDepot(id, True)
            Next

            'Else
            'calc.protokoll = "Es wurden keine Zahlungen gefunden!"
            'End If

            Return calc

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub printEA(ByRef idKlient As String, ByRef AbrechnenBis As DateTime, ByVal typ As eZahlEA, ByRef db As dbPMDS, ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, _
                         ByRef summe As Decimal, ByRef IDListAbgerech As ArrayList, ByRef editor As TXTextControl.TextControl, _
                         ByRef calc As calcData, IDKlinik As System.Guid)
        Try
            db.Taschengeld.Rows.Clear()
            Me.sql.readDepotgeld(idKlient, AbrechnenBis, db, typ, False, IDKlinik)
            If db.Taschengeld.Rows.Count Then
                billFormat.columns(4).printNull = False
                Me.setPrintColumn(IIf(typ = eZahlEA.Auszahlung, "Auszahlungen", "Einzahlungen"), 0, billFormat)
                Me.print.addCollumn(Nothing, billFormat, editor, False, True)
                billFormat.columns(4).printNull = True
                For Each rDepot As dbPMDS.TaschengeldRow In db.Taschengeld
                    Dim betrag As Decimal = 0
                    If typ = eZahlEA.Auszahlung Then
                        If Not rDepot.IsAuszahlungNull() Then betrag = rDepot.Auszahlung * -1
                    Else
                        If Not rDepot.IsEinzahlungNull() Then betrag = rDepot.Einzahlung
                    End If

                    'Einzahlung mit 0 oder Empty unterdrücken, Auszahlung mit Null erlauben (z.B. Rezeptgebührenbefreiung von Apotheken)
                    If (typ = eZahlEA.Einzahlung And betrag <> 0) Or typ = eZahlEA.Auszahlung Then
                        Me.setPrintColumn(rDepot, betrag, billFormat)
                        Me.print.addCollumn(Nothing, billFormat, editor, False, False)
                        summe += betrag
                        IDListAbgerech.Add(rDepot.ID.ToString())

                        ' IDDepotgeld in db sichern (Rücksetzung AbgerechnetJN löschen Rechnung)
                        Dim rNew As dbCalc.KostenKostenträgerRow = Me.bill.newRechZeile(calc.dbCalc)
                        rNew.IDKostIntern = rDepot.ID.ToString()
                        calc.dbCalc.KostenKostenträger.Rows.Add(rNew)
                    End If

                Next
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readDepotgeldSum(ByVal idKlient As String, ByVal typ As eZahlEA, ByVal bis As Date, ByVal AbgerechnetJN As Boolean, _
                                     IDKlinik As System.Guid) As Decimal
        Try
            Dim db As New dbPMDS
            Me.sql.readDepotgeld(idKlient.ToLower(), bis, db, typ, AbgerechnetJN, IDKlinik)
            Dim betragSum As Decimal = 0
            For Each rDepot As dbPMDS.TaschengeldRow In db.Taschengeld
                If typ = eZahlEA.Auszahlung Then
                    If Not rDepot.IsAuszahlungNull() Then betragSum += rDepot.Auszahlung
                ElseIf typ = eZahlEA.Einzahlung Then
                    If Not rDepot.IsEinzahlungNull() Then betragSum += rDepot.Einzahlung
                End If
            Next
            Return betragSum

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getPrintColumns() As tableColumn()
        Try
            Dim columns(4) As tableColumn

            Dim col As New tableColumn(Me.tDepotPrint.DatumColumn.ColumnName, 0)
            columns(0) = col
            col = New tableColumn(Me.tDepotPrint.GrundColumn.ColumnName, 1)
            columns(1) = col
            col = New tableColumn(Me.tDepotPrint.LieferantColumn.ColumnName, 2)
            columns(2) = col
            col = New tableColumn(Me.tDepotPrint.BelegNrColumn.ColumnName, 3)
            columns(3) = col
            col = New tableColumn(Me.tDepotPrint.AuszahlungColumn.ColumnName, 4)
            columns(4) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumn(ByRef rDepot As dbPMDS.TaschengeldRow, ByVal betrag As Decimal, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try

            Dim datum As String = ""
            If Not rDepot.IsDatumNull() Then datum = rDepot.Datum.ToString(Me.dateFormat)
            formatAttr.setColumn(Me.tDepotPrint.DatumColumn.ColumnName, datum)

            Dim grund As String = ""
            If Not rDepot.IsGrundNull() Then grund = rDepot.Grund
            formatAttr.setColumn(Me.tDepotPrint.GrundColumn.ColumnName, grund)

            Dim lieferant As String = ""
            If Not rDepot.IsLieferantNull() Then lieferant = rDepot.Lieferant
            formatAttr.setColumn(Me.tDepotPrint.LieferantColumn.ColumnName, lieferant)

            Dim BelegNr As String = ""
            If Not rDepot.IsBelegNrNull() Then BelegNr = rDepot.BelegNr
            formatAttr.setColumn(Me.tDepotPrint.BelegNrColumn.ColumnName, BelegNr)

            formatAttr.setColumn(Me.tDepotPrint.AuszahlungColumn.ColumnName, betrag)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub setPrintColumn(ByRef txt As String, ByVal betrag As Decimal, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn(Me.tDepotPrint.DatumColumn.ColumnName, txt)
            formatAttr.setColumn(Me.tDepotPrint.GrundColumn.ColumnName, "")
            formatAttr.setColumn(Me.tDepotPrint.LieferantColumn.ColumnName, "")
            formatAttr.setColumn(Me.tDepotPrint.BelegNrColumn.ColumnName, "")
            formatAttr.setColumn(Me.tDepotPrint.AuszahlungColumn.ColumnName, betrag)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


    Public Sub printEinzelbeleg(ByVal idKlient As String, ByVal betrag As Decimal, ByVal AbrechnenBis As DateTime, ByVal typZahl As eZahlEA, IDKlinik As System.Guid)
        Try
            Dim db As New dbPMDS()
            sql.readKlient(idKlient, db, True)
            Dim rKlientDat As dbPMDS.PatientRow = db.Patient.Rows(0)
            Dim klientenname As String = rKlientDat.Nachname + " " + rKlientDat.Vorname

            Dim kostName As String = klientenname
            Dim IDKost As String = Me.getKostAct(idKlient, AbrechnenBis, kostName)

            print.loadTempStream(PMDS.Calc.Logic.bill.rechnungRTF, True)
            Dim frmPrint As frmPrint = print.open("", etyp.calc)
            print.loadTempStreamToEditor(frmPrint.ucprint.editor.textControl1)

            bill.fillFields(IDKost, idKlient, eCalcTyp.abrechnung, AbrechnenBis, AbrechnenBis, frmPrint.ucprint.editor.textControl1, eBillTyp.Depotgeld, IDKlinik)
            Me.doBookmarks.setBookmark("[Zahlkond]", "", frmPrint.ucprint.editor.textControl1)
            Me.doBookmarks.setBookmark("[RechTitelDetail]", "", frmPrint.ucprint.editor.textControl1)

            print.removeTable(3, frmPrint.ucprint.editor.textControl1)
            print.removeTable(2, frmPrint.ucprint.editor.textControl1)
            print.removeTable(1, frmPrint.ucprint.editor.textControl1)
            print.removeTable(0, frmPrint.ucprint.editor.textControl1)
            Me.bill.fillFieldZahlungsbest(betrag, klientenname, typZahl, frmPrint.ucprint.editor.textControl1)
            Me.print.doAutoSiteNummbering(frmPrint.ucprint.editor.textControl1)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function getKostAct(ByVal idKlient As String, ByVal AbrechnenBis As DateTime, ByRef kostName As String) As String
        Try
            ' Kostenträger einlesen, wenn keiner -> Kost=Klient, wenn keiner -> Exeption und Abbruch der Abrechnung

            Dim IDKost As String = Me.sql.getKostDepot(idKlient, AbrechnenBis)
            If IDKost = "" Then
                Throw New Exception("Fehler in der Abrechnung!" + vbNewLine + _
                                    "Für Klient '" + kostName + "' wurden mehr als ein Depotgeldkostenträger definiert!")
            End If

            Dim db As New dbPMDS()
            If IDKost <> kostenträger.IDKostKlient Then
                Me.sql.readKostenräger(IDKost, db, True)
                Dim rKostDat As dbPMDS.KostentraegerRow = db.Kostentraeger.Rows(0)
                kostName = rKostDat.Name
            End If

            Return IDKost

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function doJahresAb(ByVal bis As DateTime, ByVal nurAbgerech As Boolean, IDKlinik As System.Guid) As Boolean
        Try
            Dim dbKlient As New dbPMDS()

            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
            Dim cols() As tableColumn = Me.getPrintColumnsJahresAb()
            billFormat.columns = cols

            Dim booking As New booking()
            Dim frmPrint As frmPrint = booking.openRepJahresab("Bericht Jahresabschluss Depotgeld bis " + bis.ToString(Me.dateFormat))
            Me.print.removeTable(1, frmPrint.ucprint.editor.textControl1)
            Application.DoEvents()

            ' Alle Klienten aus Tabelle Taschengel lesen, die jemals abgerechnet wurden
            Dim arrHelpKlient() As dbPMDS.helpRow = Me.print.getKlientenSql("select distinct IDPatient from Taschengeld where IDKlinik = '" + IDKlinik.ToString() + "' ")
            For Each rKlient As dbPMDS.helpRow In arrHelpKlient

                Dim txtOffZahl As String = ""
                If nurAbgerech Then txtOffZahl = Me.offeneZahlungen(bis, rKlient.ID, IDKlinik)

                ' alle abgerechneten Einzahlungen einlesen
                Dim dbEinz As New dbPMDS()
                Dim sumEinz As Decimal = 0
                Me.sql.readDepotgeld(rKlient.ID, bis, dbEinz, eZahlEA.Einzahlung, True, IDKlinik)
                If Not nurAbgerech Then Me.sql.readDepotgeld(rKlient.ID, bis, dbEinz, eZahlEA.Einzahlung, False, IDKlinik)
                For Each rDepot As dbPMDS.TaschengeldRow In dbEinz.Taschengeld
                    If Not rDepot.IsEinzahlungNull() Then sumEinz += rDepot.Einzahlung
                Next

                ' alle abgerechneten Auszahlungen einlesen
                Dim dbAusz As New dbPMDS()
                Dim sumAusz As Decimal = 0
                Me.sql.readDepotgeld(rKlient.ID, bis, dbAusz, eZahlEA.Auszahlung, True, IDKlinik)
                If Not nurAbgerech Then Me.sql.readDepotgeld(rKlient.ID, bis, dbAusz, eZahlEA.Auszahlung, False, IDKlinik)
                For Each rDepot As dbPMDS.TaschengeldRow In dbAusz.Taschengeld
                    If Not rDepot.IsAuszahlungNull() Then sumAusz += rDepot.Auszahlung
                Next

                If dbEinz.Taschengeld.Rows.Count = 0 And dbAusz.Taschengeld.Rows.Count = 0 Then
                    Me.setPrintColumnJahresAb(rKlient.Name, "Keine Zahlungen gefunden", txtOffZahl, billFormat)
                    Me.print.addCollumn(Nothing, billFormat, frmPrint.ucprint.editor.textControl1)
                Else
                    Dim diff As Decimal = sumEinz - sumAusz
                    If diff <> 0 Then                                           ' Übertrag als neuen Depoteintrag schreiben
                        Dim dbJahrAb As New dbPMDS()
                        Dim rJahrAb As dbPMDS.TaschengeldRow = Me.newRowDepot(dbJahrAb.Taschengeld)
                        rJahrAb.IDKlinik = IDKlinik
                        rJahrAb.IDPatient = New System.Guid(rKlient.ID)
                        rJahrAb.Grund = "Übertrag Jahresabschluss bis " + bis.ToString(Me.dateFormat)
                        rJahrAb.AbgerechnetJN = True
                        rJahrAb.Datum = bis.Date.AddDays(1)

                        Dim txtÜbertrag As String = ""
                        If diff > 0 Then
                            rJahrAb.Einzahlung = diff
                            txtÜbertrag = "Einzahlung mit Betrag " + Me.decWithEuro(rJahrAb.Einzahlung) + " gebucht"
                        Else
                            rJahrAb.Auszahlung = diff * -1
                            txtÜbertrag = "Auszahlung mit Betrag " + Me.decWithEuro(rJahrAb.Auszahlung) + " gebucht"
                        End If
                        Me.sql.insertDepot(rJahrAb)

                        Me.setPrintColumnJahresAb(rKlient.Name, txtÜbertrag, txtOffZahl, billFormat)
                        Me.print.addCollumn(Nothing, billFormat, frmPrint.ucprint.editor.textControl1)
                    Else
                        Me.setPrintColumnJahresAb(rKlient.Name, "Übertrag ist 0", txtOffZahl, billFormat)
                        Me.print.addCollumn(Nothing, billFormat, frmPrint.ucprint.editor.textControl1)
                    End If

                    ' abgerechnete Zahlungen löschen
                    For Each rDepot As dbPMDS.TaschengeldRow In dbEinz.Taschengeld
                        Me.sql.delDepot(rDepot.ID.ToString())
                    Next
                    For Each rDepot As dbPMDS.TaschengeldRow In dbAusz.Taschengeld
                        Me.sql.delDepot(rDepot.ID.ToString())
                    Next
                End If
            Next

            Me.print.doAutoSiteNummbering(frmPrint.ucprint.editor.textControl1)

            Return True

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function offeneZahlungen(ByVal bis As DateTime, ByVal idKlient As String, IDKlinik As System.Guid) As String
        Try
            Dim txt As String = ""
            Dim offZahl As Boolean = False
            Dim dbOffeneZahl As New dbPMDS()
            Me.sql.readDepotgeld(idKlient, bis, dbOffeneZahl, eZahlEA.Einzahlung, False, IDKlinik)
            If dbOffeneZahl.Taschengeld.Rows.Count > 0 Then _
                txt += dbOffeneZahl.Taschengeld.Rows.Count.ToString() + " Einzahlungen"

            dbOffeneZahl.Taschengeld.Rows.Clear()
            Me.sql.readDepotgeld(idKlient, bis, dbOffeneZahl, eZahlEA.Auszahlung, False, IDKlinik)
            If dbOffeneZahl.Taschengeld.Rows.Count > 0 Then _
                txt += IIf(txt = "", "", ", ") + dbOffeneZahl.Taschengeld.Rows.Count.ToString() + " Auszahlungen"

            Return txt

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function newRowDepot(ByRef t As dbPMDS.TaschengeldDataTable) As dbPMDS.TaschengeldRow
        Try

            Dim rNew As dbPMDS.TaschengeldRow = t.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.IDPatient = System.Guid.NewGuid
            rNew.IDBenutzerdurchgefuehrt = New System.Guid(calcBase.usrID)
            rNew.BelegNr = ""
            rNew.Datum = Now.Date
            rNew.Grund = ""
            rNew.SetEinzahlungNull()
            rNew.SetAuszahlungNull()
            rNew.Saldo = 0
            rNew.Lieferant = ""
            rNew.Bemerkung = ""
            rNew.Zahlart = 0
            rNew.AbgerechnetJN = False
            rNew.SetIDKlinikNull()
            t.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getPrintColumnsJahresAb() As tableColumn()
        Try
            Dim columns(2) As tableColumn

            Dim col As New tableColumn("Klient", 0)
            columns(0) = col
            col = New tableColumn("Text", 1)
            columns(1) = col
            col = New tableColumn("OffeneZahl", 2)
            columns(2) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumnJahresAb(ByRef Klient As String, ByRef txt As String, ByRef OffeneZahl As String, _
                                      ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn("Klient", Klient)
            formatAttr.setColumn("Text", txt)
            formatAttr.setColumn("OffeneZahl", OffeneZahl)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class
