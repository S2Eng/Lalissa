Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Imports QS2.Desktop.Txteditor




Public Class daylist
    Inherits calcBase


    Public tDaylist As dbPMDS.daylistDataTable
    Public Shared daylistRTF As String = "daylist.rtf"

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public print As New print()

    Public doCalc As New doCalc




    Public Sub run(ByVal monat As Date, ByVal editor As TXTextControl.TextControl, IDKlinik As System.Guid)
        Try
            calcBase.errTxt = ""
            editor.Text = ""

            print.loadTempStream(daylist.daylistRTF)
            Me.doEditor.showText(print.printTempStream, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, editor)
            Application.DoEvents()

            Dim listIDCalculated As New System.Collections.Generic.List(Of String)
            Me.tDaylist = New dbPMDS.daylistDataTable()

            Dim dbCalcMR As dbCalc
            Dim tRech As dbPMDS.billsDataTable = Me.sql.readBillsDaylist(monat, IDKlinik)
            Dim arrKost() As dbPMDS.billsRow = tRech.Select("", "IDKlient asc ")
            If tRech.Rows.Count > 0 Then
                Dim anz As Integer = 0
                Dim IDKlientLast As String = ""
                Dim rNew As dbPMDS.daylistRow
                For Each rRech As dbPMDS.billsRow In arrKost
                    If Me.IDIsCalculated(rRech.IDAbrechnung, listIDCalculated) Then Continue For

                    anz += 1
                    If IDKlientLast = "" Or IDKlientLast <> rRech.IDKlient Then     ' Nur bei neuem Klienten addRow, sonst aufsummieren
                        If IDKlientLast <> "" Then

                            ' Gesamt pro Klient
                            rNew.Gesamt += rNew.SummeGrundleistung + rNew.SummePeriodischeLeistungen + rNew.SummeSonderleistungen + rNew.GSGB

                        End If

                        rNew = Me.addColumnDaylist(anz, Me.tDaylist, IDKlinik)
                    End If

                    rNew.Klientenname = rRech.KlientName

                    Dim dbPMDS As New dbPMDS
                    sql.readKlient(rRech.IDKlient, dbPMDS, True)
                    Dim rKlientDat As dbPMDS.PatientRow = dbPMDS.Patient.Rows(0)
                    If Not rKlientDat.IsKlientennummerNull() Then rNew.KlientenNr = rKlientDat.Klientennummer

                    Dim rPflegeStAct As dbPMDS.PatientPflegestufeRow = Me.sql.readPflegeStAct(rRech.IDKlient)
                    If Not rPflegeStAct Is Nothing Then rNew.Pflegestufe = rPflegeStAct.Bezeichnung

                    Dim rAufenthAct As dbPMDS.AufenthaltRow = Me.sql.readAufenthAct(rRech.IDKlient, IDKlinik)
                    If Not rAufenthAct Is Nothing Then rNew.ZimmerNr = rAufenthAct.Zimmernummer

                    Dim rHeader As dbPMDS.billHeaderRow = Me.getHeader(rRech.IDAbrechnung, IDKlinik)
                    dbCalcMR = Me.getDBCalc(rHeader.dbCalc)

                    'If rNew.Klientenname = "Vezovnik Mathilde" Then
                    '    Dim x As String = ""
                    'End If

                    Dim res As anwAbw = Me.doCalc.getAnwAbw(dbCalcMR)
                    rNew.anw += res.anw : rNew.abw += res.abw

                    For Each rLeist As dbCalc.LeistungenRow In dbCalcMR.Leistungen

                        If rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente Or rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Then
                            Me.getSummenLeistungen(rLeist, dbCalcMR, rNew.SummeGrundleistung, _
                                                   rNew.SummeGrundleistungReduziert, rNew.SummeGrundleistungenMonatlich)

                        ElseIf rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Then
                            Me.getSummenLeistungen(rLeist, dbCalcMR, rNew.SummePeriodischeLeistungen, _
                                                    rNew.SummePeriodischeLeistungenReduziert, rNew.SummePeriodischeLeistungenMonatlich)

                        ElseIf rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen Then                                  ' Sonderleistungen
                            rNew.SummeSonderleistungen += rLeist.MonatspreisNetto
                        End If

                    Next

                    'GSBG
                    For Each rRechZeile As dbCalc.KostenKostenträgerRow In dbCalcMR.KostenKostenträger
                        If rRechZeile.Kennung = eTypProt.GSGB.ToString() Then rNew.GSGB += rRechZeile.Brutto
                    Next

                    If rNew.anw <> 0 Then
                        rNew.Tagsatz = (rNew.SummeGrundleistung + rNew.SummePeriodischeLeistungen) / rNew.anw
                    Else
                        rNew.Tagsatz = 0
                    End If
                    If rNew.abw <> 0 Then
                        rNew.TagsatzReduziert = (rNew.SummeGrundleistungReduziert + rNew.SummePeriodischeLeistungenReduziert) / rNew.abw
                    Else
                        rNew.TagsatzReduziert = 0
                    End If

                    rNew.SummeGrundleistung = rNew.SummeGrundleistung + rNew.SummeGrundleistungReduziert + rNew.SummeGrundleistungenMonatlich
                    rNew.SummePeriodischeLeistungen = rNew.SummePeriodischeLeistungen + rNew.SummePeriodischeLeistungenReduziert + rNew.SummePeriodischeLeistungenMonatlich

                    IDKlientLast = rRech.IDKlient
                    listIDCalculated.Add(rRech.IDAbrechnung)
                Next

                ' Gesamt für letzten Klietnen
                rNew.Gesamt += rNew.SummeGrundleistung + rNew.SummePeriodischeLeistungen + rNew.SummeSonderleistungen + rNew.GSGB


            End If

            Me.sortAndPrint(monat, editor, IDKlinik)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub getSummenLeistungen(ByRef rLeist As dbCalc.LeistungenRow, ByRef dbCalcRech As dbCalc, _
                                  ByRef summe As Decimal, ByRef summeRed As Decimal, ByRef summeMonatlich As Decimal)
        Try
            If rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente Or rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Then
                Dim arrTagesLeist() As dbCalc.TagesleistungenRow = dbCalcRech.Tagesleistungen.Select("IDLeistung='" + rLeist.ID + "'")
                'Tagesleistungen summieren
                If arrTagesLeist.Length > 0 Then
                    For Each rTagLeist As dbCalc.TagesleistungenRow In arrTagesLeist
                        If Not rTagLeist.ReduziertJNTagsatzliste Then
                            summe += rTagLeist.IstPreisNetto
                        Else
                            summeRed += rTagLeist.IstPreisNetto
                        End If
                    Next
                Else
                    'Monatsleistungen summieren
                    summeMonatlich += rLeist.MonatspreisNetto
                End If

            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function sortAndPrint(ByVal monat As Date, ByVal editor As TXTextControl.TextControl, IDKlinik As System.Guid) As calcData
        Try
            Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
            Dim cols() As QS2.Desktop.Txteditor.tableColumn = Me.getPrintColumns()
            billFormat.columns = cols
            Me.doBookmarks.setBookmark("[Monat]", Format(monat, monat.ToString("MM-yyyy")), editor)

            Dim arrDaylist() As dbPMDS.daylistRow = Me.tDaylist.Select("", "Klientenname asc ")
            Dim Nr As Integer = 1
            Dim tDaylistResult As New dbPMDS.daylistDataTable()
            Dim rSum As dbPMDS.daylistRow = Me.addColumnDaylist(-100, Me.tDaylist, IDKlinik)
            For Each rDaylist As dbPMDS.daylistRow In arrDaylist
                Dim rNew As dbPMDS.daylistRow = tDaylistResult.NewRow()
                rNew.ItemArray = rDaylist.ItemArray()
                rNew.Nr = Nr
                tDaylistResult.Rows.Add(rNew)

                rSum.SummeGrundleistung += rNew.SummeGrundleistung
                rSum.SummePeriodischeLeistungen += rNew.SummePeriodischeLeistungen
                rSum.SummeSonderleistungen += rNew.SummeSonderleistungen
                rSum.GSGB += rNew.GSGB
                rSum.Gesamt += rNew.Gesamt

                Me.setPrintColumn(rNew, billFormat)
                Me.print.addCollumn(Nothing, billFormat, editor)

                Nr += 1
            Next

            Dim rLeer As dbPMDS.daylistRow = Me.addColumnDaylist(-101, Me.tDaylist, IDKlinik)
            rLeer.Nr = ""
            Me.setPrintColumn(rLeer, billFormat)
            Me.print.addCollumn(Nothing, billFormat, editor)

            rSum.Klientenname = "Summen"
            rSum.Nr = ""
            Me.setPrintColumn(rSum, billFormat)
            billFormat.rowTextIsItalic = True
            Me.print.addCollumn(Nothing, billFormat, editor, True)
            Me.print.doAutoSiteNummbering(editor)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getPrintColumns() As QS2.Desktop.Txteditor.tableColumn()
        Try
            Dim columns(13) As QS2.Desktop.Txteditor.tableColumn

            Dim col As New QS2.Desktop.Txteditor.tableColumn(tDaylist.NrColumn.ColumnName, 0)
            columns(0) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.KlientenNrColumn.ColumnName, 1)
            columns(1) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.KlientennameColumn.ColumnName, 2)
            columns(2) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.PflegestufeColumn.ColumnName, 3)
            columns(3) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.ZimmerNrColumn.ColumnName, 4)
            columns(4) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.TagsatzColumn.ColumnName, 5, True, False)
            columns(5) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.anwColumn.ColumnName, 6, True, False)
            columns(6) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.TagsatzReduziertColumn.ColumnName, 7, True, False)
            columns(7) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.abwColumn.ColumnName, 8, True, False)
            columns(8) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.SummeGrundleistungColumn.ColumnName, 9, True, False)
            columns(9) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.SummePeriodischeLeistungenColumn.ColumnName, 10, True, False)
            columns(10) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.SummeSonderleistungenColumn.ColumnName, 11, True, False)
            columns(11) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.GSGBColumn.ColumnName, 12, True, False)
            columns(12) = col
            col = New QS2.Desktop.Txteditor.tableColumn(tDaylist.GesamtColumn.ColumnName, 13, True, False)
            columns(13) = col
            Return columns

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub setPrintColumn(ByRef r As dbPMDS.daylistRow, ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr)
        Try
            formatAttr.setColumn(tDaylist.NrColumn.ColumnName, r.Nr)
            formatAttr.setColumn(tDaylist.KlientenNrColumn.ColumnName, r.KlientenNr)
            formatAttr.setColumn(tDaylist.KlientennameColumn.ColumnName, r.Klientenname)
            formatAttr.setColumn(tDaylist.PflegestufeColumn.ColumnName, r.Pflegestufe)
            formatAttr.setColumn(tDaylist.ZimmerNrColumn.ColumnName, r.ZimmerNr)
            formatAttr.setColumn(tDaylist.TagsatzColumn.ColumnName, r.Tagsatz)
            formatAttr.setColumn(tDaylist.anwColumn.ColumnName, r.anw)
            formatAttr.setColumn(tDaylist.TagsatzReduziertColumn.ColumnName, r.TagsatzReduziert)
            formatAttr.setColumn(tDaylist.abwColumn.ColumnName, r.abw)
            formatAttr.setColumn(tDaylist.SummeGrundleistungColumn.ColumnName, r.SummeGrundleistung)
            formatAttr.setColumn(tDaylist.SummePeriodischeLeistungenColumn.ColumnName, r.SummePeriodischeLeistungen)
            formatAttr.setColumn(tDaylist.SummeSonderleistungenColumn.ColumnName, r.SummeSonderleistungen)
            formatAttr.setColumn(tDaylist.GSGBColumn.ColumnName, r.GSGB)
            formatAttr.setColumn(tDaylist.GesamtColumn.ColumnName, r.Gesamt)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function addColumnDaylist(ByVal anz As Integer, ByRef tDaylist As dbPMDS.daylistDataTable, IDKlinik As System.Guid) As dbPMDS.daylistRow
        Try
            Dim rNew As dbPMDS.daylistRow = tDaylist.NewRow()
            rNew.Nr = anz.ToString()
            rNew.KlientenNr = ""
            rNew.Klientenname = ""
            rNew.Pflegestufe = ""
            rNew.ZimmerNr = ""
            rNew.Tagsatz = 0
            rNew.anw = 0
            rNew.TagsatzReduziert = 0
            rNew.abw = 0
            rNew.SummeGrundleistung = 0
            rNew.SummeGrundleistungenMonatlich = 0
            rNew.SummeGrundleistungReduziert = 0
            rNew.SummePeriodischeLeistungen = 0
            rNew.SummePeriodischeLeistungenMonatlich = 0
            rNew.SummePeriodischeLeistungenReduziert = 0
            rNew.SummeSonderleistungen = 0
            rNew.GSGB = 0
            rNew.Gesamt = 0
            rNew.IDKlinik = IDKlinik
            tDaylist.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class
