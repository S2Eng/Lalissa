
Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports QS2.Desktop.Txteditor




Public Class booking
    Inherits calcBase


    Public Shared bookingRTF As String = "bookings.rtf"

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public print As New print()
    Public tBookingsPrint As New dbCalc.bookingsDataTable



    Public Function sollMinusHaben(ByVal IDKlient As String, ByVal klientIsEmpty As Boolean, ByVal IDKostenträger As String, ByRef von As Date, ByRef bis As Date, _
                    ByVal konto As String, ByVal text As String, ByVal calcRun As eCalcRun, IDKlinik As System.Guid) As Double
        Try
            Dim soll As Decimal = Me.readBookingSum(IDKlient, klientIsEmpty, IDKostenträger, konto, eKontoseite.soll, von, bis, text, calcRun, IDKlinik)
            Dim haben As Decimal = Me.readBookingSum(IDKlient, klientIsEmpty, IDKostenträger, konto, eKontoseite.haben, von, bis, text, calcRun, IDKlinik)
            Return haben - soll

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function readBookings(ByVal IDKlient As String, ByVal klientIsEmpty As Boolean, ByVal IDKostenträger As String, _
                ByVal konto As String, ByVal Kontoseite As eKontoseite, _
                ByRef von As Date, ByRef bis As Date, ByVal text As String, ByVal calcRun As eCalcRun, IDKlinik As System.Guid) As dbCalc.bookingsDataTable
        Try
            Dim dbCalc As New dbCalc
            sql.readBookings(IDKlient, klientIsEmpty, IDKostenträger, konto, Kontoseite, von, bis, text, dbCalc, calcRun, IDKlinik)
            Return dbCalc.bookings

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function readBookingSum(ByVal IDKlient As String, ByVal klientIsEmpty As Boolean, ByVal IDKostenträger As String, _
                ByVal konto As String, ByVal Kontoseite As eKontoseite, _
                ByRef von As Date, ByRef bis As Date, ByVal text As String, ByVal calcRun As eCalcRun, IDKlinik As System.Guid) As Decimal
        Try
            Dim dbCalc As New dbCalc
            Me.sql.readBookings(IDKlient, klientIsEmpty, IDKostenträger, konto, Kontoseite, von, bis, text, dbCalc, calcRun, IDKlinik)
            Dim betragSum As Decimal = 0
            For Each r As dbCalc.bookingsRow In dbCalc.bookings
                betragSum += r.Betrag
            Next
            Return betragSum

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub saveBooking(ByVal Sollkonto As eKonto, ByVal Habenkonto As eKonto, ByVal buchDatum As Date, _
                            ByVal Text As String, ByVal betrag As Decimal, _
                            ByVal MWStSatz As Integer, ByVal rechNr As String, ByVal IDKlient As String, _
                            ByVal IDKostenträger As String, ByRef calc As calcData, ByVal storeInDB As Boolean, _
                            ByVal calcRun As eCalcRun, ByVal IDKlinik As System.Guid)
        Try
            'Konto_Soll = ist jenes Konto, bei dem der Betrag auf der Sollseite steht
            'Konto_Haben = ist jenes Konto, bei dem der Betrag auf der Sollseite steht 

            If betrag = 0 Then Exit Sub 'Keine Buchungen mit Betrag = schreiben. os, 2009-10-08

            Dim rNew As dbCalc.bookingsRow = calc.dbCalc.bookings.NewRow()

            rNew.ID = Me.getIDBooking(calcRun)
            rNew.Buchungsdatum = buchDatum
            rNew.Text = Text
            rNew.Sollkonto = Sollkonto.ToString()
            rNew.Habenkonto = Habenkonto.ToString()
            rNew.Betrag = betrag
            rNew.MWStSatz = MWStSatz
            rNew.IDKlient = VB.LCase(IDKlient)
            rNew.IDKostenträger = VB.LCase(IDKostenträger)
            rNew.RechNr = rechNr

            rNew.Erstellt = calcBase.usr
            rNew.ErstellAm = Now
            rNew.IDKlinik = IDKlinik

            calc.dbCalc.bookings.Rows.Add(rNew)
            If storeInDB Then sql.insertBooking(rNew)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function newRowBooking(ByRef t As dbCalc.bookingsDataTable) As dbCalc.bookingsRow
        Try

            Dim rNew As dbCalc.bookingsRow = t.NewRow()
            rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
            rNew.SetIDKlinikNull()
            rNew.Buchungsdatum = Now
            rNew.Text = ""
            rNew.Sollkonto = 0
            rNew.Habenkonto = 0
            rNew.Betrag = 0
            rNew.MWStSatz = 0
            rNew.IDKlient = ""
            rNew.IDKostenträger = ""
            rNew.RechNr = ""
            rNew.Erstellt = ""
            rNew.ErstellAm = Now
            t.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getIDBooking(ByRef calcRun As eCalcRun) As String
        Try
            Select Case calcRun
                Case eCalcRun.month
                    Return VB.LCase(System.Guid.NewGuid.ToString())
                Case eCalcRun.freeBill
                    Return "fb-" + VB.LCase(System.Guid.NewGuid.ToString())
            End Select
            Throw New Exception("getIDBooking: Wrong RunTyp!")

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function





    Public Sub printBookings(ByVal db As dbCalc, ByVal von As Date, ByVal bis As Date, ByVal konto As String, ByVal editor As TXTextControl.TextControl)
        Try
            calcBase.errTxt = ""
            print.loadTempStream(booking.bookingRTF)
            Me.doEditor.showText(print.printTempStream, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, editor)

            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
            Dim cols() As tableColumn = Me.getPrintColumns()
            billFormat.columns = cols

            Me.doBookmarks.setBookmark("[usr]", calcBase.usr, editor)
            Me.doBookmarks.setBookmark("[von]", von.ToString("MM.yyyy"), editor)
            Me.doBookmarks.setBookmark("[bis]", von.ToString("MM.yyyy"), editor)
            Me.doBookmarks.setBookmark("[Konto]", "Konto: " + konto, editor)
            Me.tBookingsPrint = Me.getBookingsFilled(db)

            Dim SumHaben As Decimal = 0
            Dim SumSoll As Decimal = 0
            Dim Nr As Integer = 1
            For Each rBooking As dbCalc.bookingsRow In Me.tBookingsPrint
                Me.setPrintColumn(rBooking, billFormat)
                SumSoll += rBooking.Soll
                SumHaben += rBooking.Haben
                Me.print.addCollumn(Nothing, billFormat, editor)
                Nr += 1
            Next

            Dim billFormatSum As New QS2.Desktop.Txteditor.formatAttr()
            billFormatSum.rowTextIsItalic = True
            Dim colsSum() As tableColumn = Me.getPrintColumnsSum()
            billFormatSum.columns = colsSum
            billFormatSum.tableNr = 1

            Me.setPrintColumnSum(Me.decWithEuro(SumSoll), Me.decWithEuro(SumHaben), "Saldo: " + Me.decWithEuro((SumSoll - SumHaben)), billFormatSum)
            Me.print.addCollumn(Nothing, billFormatSum, editor, True)

            Me.print.doAutoSiteNummbering(editor)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function getBookingsFilled(ByRef db As dbCalc) As dbCalc.bookingsDataTable
        Try
            Dim tCopy As New dbCalc.bookingsDataTable
            For Each r As dbCalc.bookingsRow In db.bookings
                Dim rNew As dbCalc.bookingsRow = tCopy.NewRow
                rNew.ItemArray = r.ItemArray
                If rNew.IDKlient <> "" Then
                    Dim rKlient As PMDS.Calc.Logic.dbPMDS.PatientRow = Me.sql.readKlient(rNew.IDKlient)
                    rNew.IDKlient = rKlient.Nachname + " " + rKlient.Vorname
                End If
                If rNew.IDKostenträger = PMDS.Calc.Logic.kostenträger.IDKostKlient Then
                    rNew.IDKostenträger = ""
                End If
                If rNew.IDKostenträger <> "" Then
                    Dim rKost As PMDS.Calc.Logic.dbPMDS.KostentraegerRow = Me.sql.readKostenräger(rNew.IDKostenträger)
                    rNew.IDKostenträger = rKost.Name
                End If

                tCopy.Rows.Add(rNew)
            Next
            Return tCopy

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getPrintColumns() As QS2.Desktop.Txteditor.tableColumn()
        Try
            Dim columns(9) As QS2.Desktop.Txteditor.tableColumn

            Dim col As New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.BuchungsdatumColumn.ColumnName, 0)
            columns(0) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.SollkontoColumn.ColumnName, 1)
            columns(1) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.TextColumn.ColumnName, 2)
            columns(2) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.BetragColumn.ColumnName, 3)
            columns(3) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.HabenColumn.ColumnName, 4)
            columns(4) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.IDKlientColumn.ColumnName, 5)
            columns(5) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.IDKostenträgerColumn.ColumnName, 6)
            columns(6) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.RechNrColumn.ColumnName, 7)
            columns(7) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.ErstelltColumn.ColumnName, 8)
            columns(8) = col
            col = New QS2.Desktop.Txteditor.tableColumn(Me.tBookingsPrint.ErstellAmColumn.ColumnName, 9)
            columns(9) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumn(ByRef rBooking As dbCalc.bookingsRow, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn(Me.tBookingsPrint.BuchungsdatumColumn.ColumnName, rBooking.Buchungsdatum.ToString(Me.dateFormat))
            formatAttr.setColumn(Me.tBookingsPrint.SollkontoColumn.ColumnName, rBooking.Sollkonto)
            formatAttr.setColumn(Me.tBookingsPrint.TextColumn.ColumnName, rBooking.Text)
            formatAttr.setColumn(Me.tBookingsPrint.BetragColumn.ColumnName, rBooking.Soll.ToString())
            formatAttr.setColumn(Me.tBookingsPrint.HabenColumn.ColumnName, rBooking.Haben.ToString())
            formatAttr.setColumn(Me.tBookingsPrint.IDKlientColumn.ColumnName, rBooking.IDKlient)
            formatAttr.setColumn(Me.tBookingsPrint.IDKostenträgerColumn.ColumnName, rBooking.IDKostenträger)
            formatAttr.setColumn(Me.tBookingsPrint.RechNrColumn.ColumnName, rBooking.RechNr)
            formatAttr.setColumn(Me.tBookingsPrint.ErstelltColumn.ColumnName, rBooking.Erstellt)
            formatAttr.setColumn(Me.tBookingsPrint.ErstellAmColumn.ColumnName, rBooking.ErstellAm.ToString(Me.dateFormat))

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function getPrintColumnsSum() As tableColumn()
        Try
            Dim columns(3) As tableColumn

            Dim col As New tableColumn("txt", 0)
            columns(0) = col
            col = New tableColumn("sumSoll", 1)
            columns(1) = col
            col = New tableColumn("sumHaben", 2)
            columns(2) = col
            col = New tableColumn("Saldo", 3)
            columns(3) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumnSum(ByVal sumSoll As String, ByVal sumHaben As String, ByVal Saldo As String, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn("txt", "Summen")
            formatAttr.setColumn("sumSoll", sumSoll)
            formatAttr.setColumn("sumHaben", sumHaben)
            formatAttr.setColumn("Saldo", Saldo)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function doJahresAb(ByVal bis As DateTime, IDKlinik As System.Guid) As Boolean
        Try
            Dim dbPMDS As New dbPMDS()
            Dim tools As New tools()

            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
            Dim cols() As tableColumn = Me.getPrintColumnsJahresAb()
            billFormat.columns = cols

            Dim frmPrint As frmPrint = Me.openRepJahresab("Bericht Jahresabschluss Buchhaltung bis " + bis.ToString(Me.dateFormat))
            Me.print.removeTable(0, frmPrint.ucprint.editor.textControl1)
            Application.DoEvents()
            Dim errLog As String = ""
            Dim arrDBToDelete As New ArrayList()

            ' Alle Sollkonten durchgehen
            For Each valKto As eKonto In [Enum].GetValues(GetType(eKonto))
                If valKto = eKonto.Eröffnungsbilanz Then Continue For

                ' Kostenträger lesen
                ' Alle Klienten aus Tabelle Taschengel lesen, die jemals abgerechnet wurden
                Dim arrHelpKost() As dbPMDS.helpRow = Me.print.getKostSql("select distinct IDKostenträger from bookings")
                For Each rKost As dbPMDS.helpRow In arrHelpKost
                    If rKost.ID = "" Then
                        errLog = "Es existieren Buchungen in Ihrem Buchungssystem ohne Angabe eines Kostenträgers!"
                    Else
                        ' Buchungen Klienten lesen
                        Dim arrHelpKlient() As dbPMDS.helpRow = Me.print.getKlientenSql("select distinct IDKlient as IDPatient from bookings where IDKostenträger = '" + rKost.ID + "' ")
                        For Each rKlient As dbPMDS.helpRow In arrHelpKlient
                            'Dim sKto As String = [Enum].GetName(GetType(PMDS.Calc.Logic.eKonto), valKto)
                            Dim sumSoll As Decimal = 0
                            Dim sumHaben As Decimal = 0
                            Dim txtBuch As String = "Übertrag Jahresabschluss bis " + bis.ToString(Me.dateFormat)

                            ' Buchungen Soll und Haben lesen
                            Dim dbCalcSoll As New dbCalc()
                            Dim dbCalcHaben As New dbCalc()
                            Me.sql.readBookings(rKlient.ID, If(rKlient.ID = "", True, False), rKost.ID, valKto.ToString(), eKontoseite.soll, Nothing, tools.dat235959(bis.Date), "", dbCalcSoll, eCalcRun.all, IDKlinik)
                            For Each rBuch As dbCalc.bookingsRow In dbCalcSoll.bookings
                                sumSoll += rBuch.Betrag
                            Next
                            Me.sql.readBookings(rKlient.ID, If(rKlient.ID = "", True, False), rKost.ID, valKto.ToString(), eKontoseite.haben, Nothing, tools.dat235959(bis.Date), "", dbCalcHaben, eCalcRun.all, IDKlinik)
                            For Each rBuch As dbCalc.bookingsRow In dbCalcHaben.bookings
                                sumHaben += rBuch.Betrag
                            Next

                            If Not (dbCalcSoll.bookings.Rows.Count = 0 And dbCalcHaben.bookings.Rows.Count = 0) Then
                                Dim diff As Decimal = sumSoll - sumHaben
                                If diff <> 0 Then
                                    Dim datBuch As Date = bis.AddDays(1)
                                    Me.saveBooking(If(diff >= 0, valKto, eKonto.Eröffnungsbilanz), If(diff < 0, valKto, eKonto.Eröffnungsbilanz), _
                                                    datBuch, txtBuch, diff, -1, "", _
                                                    rKlient.ID, rKost.ID, New calcData, True, eCalcRun.month, IDKlinik)
                                End If

                                Me.setPrintColumnJahresAb(valKto.ToString(), rKost.Name, rKlient.Name, If(diff >= 0, "Soll ", "Haben ") + Me.decWithEuro(diff), billFormat)
                                Me.print.addCollumn(Nothing, billFormat, frmPrint.ucprint.editor.textControl1)

                                ' abgerechnete Buchungen löschen
                                arrDBToDelete.Add(dbCalcSoll)
                                arrDBToDelete.Add(dbCalcHaben)
                            End If
                        Next
                    End If
                Next
            Next

            ' Buchungen löschen
            For Each db As dbCalc In arrDBToDelete
                For Each rBooking As dbCalc.bookingsRow In db.bookings
                    Me.sql.delBooking(rBooking.ID.ToString())
                Next
            Next

            Me.print.doAutoSiteNummbering(frmPrint.ucprint.editor.textControl1)
            If errLog <> "" Then QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(errLog, MsgBoxStyle.Information, "Hinweis Jahresabschluss")
            Return True

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getPrintColumnsJahresAb() As tableColumn()
        Try
            Dim columns(3) As tableColumn

            Dim col As New tableColumn("Konto", 0)
            columns(0) = col
            col = New tableColumn("Kost", 1)
            columns(1) = col
            col = New tableColumn("Klient", 2)
            columns(2) = col
            col = New tableColumn("Text", 3)
            columns(3) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumnJahresAb(ByRef Konto As String, ByRef Kost As String, ByRef Klient As String, ByRef txt As String, _
                                      ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn("Konto", Konto)
            formatAttr.setColumn("Kost", Kost)
            formatAttr.setColumn("Klient", Klient)
            formatAttr.setColumn("Text", txt)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function openRepJahresab(ByVal titel As String) As frmPrint
        Try
            print.loadTempStream(PMDS.Calc.Logic.doDepotgeld.jahresAbRTF, True, True)
            Dim frmPrint As frmPrint = print.open("", etyp.calc)
            print.loadTempStreamToEditor(frmPrint.ucprint.editor.textControl1)
            Me.doBookmarks.setBookmark("[Titel]", titel, frmPrint.ucprint.editor.textControl1)
            Me.doBookmarks.setBookmark("[usr]", calcBase.usr, frmPrint.ucprint.editor.textControl1)
            Me.doBookmarks.setBookmark("[now]", DateTime.Now.ToString("dd.MM.yyyy HH:mm"), frmPrint.ucprint.editor.textControl1)
            Application.DoEvents()

            Return frmPrint

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class
