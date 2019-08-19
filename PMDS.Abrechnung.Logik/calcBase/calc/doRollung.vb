Imports System.Collections.Generic
Imports QS2.Desktop.Txteditor
Imports System.Linq
Imports PMDS.db.Entities
Imports PMDS.Calc.Logic.calculation

Public Class doRollung
    Inherits calcBase

    Public doEditor1 As New doEditor()
    Public dbBill As New dbBill()
    Public bill As New bill()
    Public print As New print()

    Public Class cSumLeistungen
        Public IDLeistungskatalogIDSonderleistung As String = ""
        Public IsSonderleistung As Boolean = False

        Public Netto As Decimal = 0
        Public Bezeichnung As String = ""
        Public Brutto As Decimal = 0

        Public lstKostKostenträger As New System.Collections.Generic.List(Of dbCalc.KostenKostenträgerRow)()
    End Class
    Public Class cBillsGerollt
        Public IDBill As String = ""
        Public RollungAnz As Integer = 0

        Public lstLZs As New System.Collections.Generic.List(Of dbCalc.KostenKostenträgerRow)
        Public dbCalcCopied As New dbCalc()
    End Class







    Public Sub run(rBillsOld As dbPMDS.billsRow, rBillsNewOrig3 As PMDS.db.Entities.bills, ByRef editor As TXTextControl.TextControl, db As PMDS.db.Entities.ERModellPMDSEntities)
        Try
            Dim AnyChanges As Boolean = False
            Dim RollungAnz As Integer = 0

            'If rBillAufSR.Status = 1 Then
            Dim tBillsNew As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = rBillsNewOrig3.ID
            Dim rBillsNew As PMDS.db.Entities.bills = tBillsNew.First()
            Dim tBillsHeaderNew As IQueryable(Of PMDS.db.Entities.billHeader) = From o In db.billHeader Where o.ID = rBillsNew.IDAbrechnung
            Dim rBillsHeaderNew As PMDS.db.Entities.billHeader = tBillsHeaderNew.First()
            Dim dbCalcNew As dbCalc = Me.getDBCalc(rBillsHeaderNew.dbCalc)

            Dim tBillsHeaderOld As IQueryable(Of PMDS.db.Entities.billHeader) = From o In db.billHeader Where o.ID = rBillsOld.IDAbrechnung
            Dim rBillsHeaderOld As PMDS.db.Entities.billHeader = tBillsHeaderOld.First()
            Dim dbCalcOld As dbCalc = Me.getDBCalc(rBillsHeaderOld.dbCalc)

            Dim arrKostKostenträgerNew() As DataRow = dbCalcNew.Tables(dbCalcNew.KostenKostenträger.TableName).Select(dbCalcNew.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsNew.IDKost.ToString() + "' and Kennung='" + eTypProt.LZ.ToString() + "'",
                                                                                                                        dbCalcNew.KostenKostenträger.lfdNrColumn.ColumnName + " asc")
            Dim arrKostKostenträgerOld() As DataRow = dbCalcOld.Tables(dbCalcOld.KostenKostenträger.TableName).Select(dbCalcOld.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsOld.IDKost.ToString() + "' and Kennung='" + eTypProt.LZ.ToString() + "'",
                                                                                                                        dbCalcOld.KostenKostenträger.lfdNrColumn.ColumnName + " asc")

            For Each rKostKostenträgerOld As dbCalc.KostenKostenträgerRow In arrKostKostenträgerOld
                Me.copyKostKostenträger(dbCalcNew, rKostKostenträgerOld, dbCalcOld.Kostenträger, dbCalcOld.Zahler, dbCalcOld.Leistungen, True)
            Next
            dbCalcNew.AcceptChanges()

            arrKostKostenträgerNew = dbCalcNew.Tables(dbCalcNew.KostenKostenträger.TableName).Select(dbCalcNew.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsNew.IDKost.ToString() + "' and Kennung='" + eTypProt.LZ.ToString() + "'",
                                                                                                                        dbCalcNew.KostenKostenträger.lfdNrColumn.ColumnName + " asc")


            Dim arrKostKostenträgerDelete() As DataRow = dbCalcNew.Tables(dbCalcNew.KostenKostenträger.TableName).Select(dbCalcNew.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsNew.IDKost.ToString() + "' and Kennung<>'" + eTypProt.LZ.ToString() + "'",
                                                                                                                        dbCalcNew.KostenKostenträger.lfdNrColumn.ColumnName + " asc")
            Dim lstToDelete As New System.Collections.Generic.List(Of dbCalc.KostenKostenträgerRow)
            For Each rKostKostenträgerDelete As dbCalc.KostenKostenträgerRow In arrKostKostenträgerDelete
                If rKostKostenträgerDelete.Kennung <> eTypProt.selbstbehalt.ToString() And rKostKostenträgerDelete.Kennung <> eTypProt.GSGB.ToString() Then
                    lstToDelete.Add(rKostKostenträgerDelete)
                End If
            Next
            For Each rKostKostenträgerDelete As dbCalc.KostenKostenträgerRow In lstToDelete
                rKostKostenträgerDelete.Delete()
            Next
            dbCalcNew.AcceptChanges()

            RollungAnz += 1
            Dim lstGerolltPrev As New System.Collections.Generic.List(Of cBillsGerollt)()
            Dim iCountRek As Integer = 0
            Me.getLZBillsGerollt_rek(rBillsOld.ID, rBillsNew.IDKost, lstGerolltPrev, iCountRek, db)
            For Each BillsGerollt As cBillsGerollt In lstGerolltPrev
                For Each rKostKostenträgerGerolltPrev As dbCalc.KostenKostenträgerRow In BillsGerollt.dbCalcCopied.KostenKostenträger
                    Me.copyKostKostenträger(dbCalcNew, rKostKostenträgerGerolltPrev, BillsGerollt.dbCalcCopied.Kostenträger, BillsGerollt.dbCalcCopied.Zahler, BillsGerollt.dbCalcCopied.Leistungen, False)
                Next
                RollungAnz += 1
                BillsGerollt.RollungAnz = RollungAnz
            Next
            AnyChanges = True

            arrKostKostenträgerNew = dbCalcNew.Tables(dbCalcNew.KostenKostenträger.TableName).Select(dbCalcNew.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsNew.IDKost.ToString() + "' and Kennung='" + eTypProt.LZ.ToString() + "'",
                                                                                                                        dbCalcNew.KostenKostenträger.lfdNrColumn.ColumnName + " asc")

            Dim lstCollSum As New System.Collections.Generic.Dictionary(Of String, cSumLeistungen)()
            Me.readSumProLeistung(arrKostKostenträgerNew, lstCollSum)

            For Each pairSumLeist As KeyValuePair(Of String, cSumLeistungen) In lstCollSum
                If pairSumLeist.Value.Netto = 0 Then
                    For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In pairSumLeist.Value.lstKostKostenträger
                        rKostKostenträger.Delete()
                    Next
                End If
            Next
            dbCalcNew.AcceptChanges()

            If AnyChanges Then
                Dim billFormat As New QS2.Desktop.Txteditor.formatAttr()
                billFormat.tableNr = 0
                billFormat.cellFormat.TopTextDistance = 80
                billFormat.cellFormat.BottomTextDistance = 80
                Dim cols() As tableColumn = Me.bill.getPrintColumns()
                billFormat.columns = cols

                Dim lfdNrLast As Integer = 0
                Dim SumNetto As Double = 0
                Dim lstMwstDistinct As New System.Collections.Generic.List(Of calculation.cMwst)
                Me.addMwstToList(lstMwstDistinct, dbCalcOld)
                Me.addMwstToList(lstMwstDistinct, dbCalcNew)
                Me.prepareRechZR(lstMwstDistinct, dbCalcNew, lfdNrLast, SumNetto, False, rBillsNew.IDKost)

                Dim IDNewIDRechZ As Guid = Guid.NewGuid()
                Me.bill.setPrintColumn(IDNewIDRechZ, eTypProt.SumLeistNetto, 0, "Summe der Leistungen netto gesamt", SumNetto, 0, 0, 0, billFormat)
                bill.add(IDNewIDRechZ, eTypProt.SumLeistNetto, billFormat, dbCalcNew, rBillsNew.IDKostIntern, rBillsNew.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, True, False, "", "", "", "", "", True)

                Dim sumMwSt As Double = 0
                For Each cMwst As calculation.cMwst In lstMwstDistinct
                    IDNewIDRechZ = Guid.NewGuid()
                    If cMwst.sum <> 0 Then
                        Dim Mwst As Double = Math.Round((Math.Round(cMwst.sum, 2) / 100) * cMwst.MwstSatz, 2)
                        sumMwSt += Mwst
                        bill.setPrintColumn(IDNewIDRechZ, eTypProt.MWStSatz, 0, "+ " + Me.decWithEuro(cMwst.MwstSatz) + "%  MwSt von " + Me.decWithEuro(cMwst.sum), Mwst, 0, 0, cMwst.MwstSatz, billFormat)
                        bill.add(IDNewIDRechZ, eTypProt.MWStSatz, billFormat, dbCalcNew, rBillsNew.IDKostIntern, rBillsNew.IDKost, eCalcTyp.abrechnung,
                                    Me.decWithEuro(cMwst.sum), 0, Me.decWithEuro(cMwst.MwstSatz), "", editor, False, False, "", "", "", "", "", True)
                    End If
                Next

                Dim sumBrutto As Double = SumNetto + sumMwSt
                IDNewIDRechZ = Guid.NewGuid()
                bill.setPrintColumn(IDNewIDRechZ, eTypProt.SumLeistBrutto, 0, "Summe Ihrer Leistungen brutto", 0, 0, sumBrutto, 0, billFormat)
                bill.add(IDNewIDRechZ, eTypProt.SumLeistBrutto, billFormat, dbCalcNew, rBillsNew.IDKostIntern, rBillsNew.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, True, False, "", "", "", "", "", True)

                Me.checkSumRechOldNew(dbCalcOld, dbCalcNew, rBillsNew.IDKostIntern, rBillsOld.IDKostIntern, sumBrutto, eTypProt.selbstbehalt)

                'IDNewIDRechZ = Guid.NewGuid()
                'bill.setPrintColumn(IDNewIDRechZ, eTypProt.Gesamtkosten, 0, "Gesamtkosten = Rechnungsbetrag", 0, 0, sumBrutto, 0, billFormat)
                'bill.add(IDNewIDRechZ, eTypProt.Gesamtkosten, billFormat, dbCalcNew, rBillsNew.IDKostIntern, rBillsNew.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, False, False, "", "", "", "", "", True)

                Me.checkSumRechOldNew(dbCalcOld, dbCalcNew, rBillsNew.IDKostIntern, rBillsOld.IDKostIntern, sumBrutto, eTypProt.GSGB)

                IDNewIDRechZ = Guid.NewGuid()
                bill.setPrintColumn(IDNewIDRechZ, eTypProt.Zahlungsbetrag, 0, "Zahlungsbetrag", 0, 0, sumBrutto, 0, billFormat)
                billFormat.columns(0).asField = "[ZahlBetragBez]"
                billFormat.columns(4).asField = "[ZahlBetrag]"
                bill.add(IDNewIDRechZ, eTypProt.Zahlungsbetrag, billFormat, dbCalcNew, rBillsNew.IDKostIntern, rBillsNew.IDKost, eCalcTyp.abrechnung, 0, 0, 0, "", editor, True, True, "", "", "", "", "", True, "", "", 2000)
                billFormat.columns(0).asField = ""
                billFormat.columns(4).asField = ""
                billFormat.columns(4).printNull = False

                Me.saveNewBeilage(rBillsNew, rBillsOld, dbCalcNew, db, editor, billFormat, sumBrutto, lstGerolltPrev)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub checkSumRechOldNew(ByRef dbCalcOld As dbCalc, ByRef dbCalcNew As dbCalc, IDKostInternNew As String, IDKostInternOld As String, ByRef sumBrutto As Double, TypProt As eTypProt)
        Try
            Dim rAbzAndKostOld As cSelObj = (From k In dbCalcOld.KostenKostenträger Where k.Kennung = TypProt.ToString().Trim() And k.IDKostIntern = IDKostInternOld
                                             Select New cSelObj With {.ID = k.ID, .Brutto = k.Brutto, .IDKost = k.IDKost, .IDKostIntern = k.IDKostIntern, .lfdNr = k.lfdNr}).FirstOrDefault()

            Dim rAbzAndKostNew As cSelObj = (From k In dbCalcNew.KostenKostenträger Where k.Kennung = TypProt.ToString().Trim() And k.IDKostIntern = IDKostInternNew
                                             Select New cSelObj With {.ID = k.ID, .Brutto = k.Brutto, .IDKost = k.IDKost, .IDKostIntern = k.IDKostIntern, .lfdNr = k.lfdNr}).FirstOrDefault()

            Dim diff As Decimal = 0
            If Not rAbzAndKostOld Is Nothing And rAbzAndKostNew Is Nothing Then
                diff = rAbzAndKostOld.Brutto * -1
            ElseIf rAbzAndKostOld Is Nothing And Not rAbzAndKostNew Is Nothing Then
                diff = rAbzAndKostNew.Brutto
            ElseIf (Not rAbzAndKostOld Is Nothing And Not rAbzAndKostNew Is Nothing) AndAlso (rAbzAndKostOld.Brutto <> rAbzAndKostNew.Brutto) Then
                diff = rAbzAndKostNew.Brutto - rAbzAndKostOld.Brutto
            End If

            If diff <> 0 Then
                Dim b As New bill()
                Dim rNewRechZeile As dbCalc.KostenKostenträgerRow
                If rAbzAndKostNew Is Nothing Then
                    rNewRechZeile = b.newRechZeile(dbCalcNew)
                    dbCalcNew.KostenKostenträger.Rows.Add(rNewRechZeile)
                Else
                    rNewRechZeile = (From o In dbCalcNew.KostenKostenträger Where o.ID = rAbzAndKostNew.ID And o.IDKostIntern = IDKostInternNew).First()
                End If

                rNewRechZeile.IDKost = rAbzAndKostNew.IDKost
                rNewRechZeile.IDKostIntern = rAbzAndKostNew.IDKostIntern
                rNewRechZeile.Brutto = diff
                rNewRechZeile.Kennung = TypProt.ToString()

                If TypProt = eTypProt.selbstbehalt Then
                    Dim rGesamtkostenNew As cSelObj = (From k In dbCalcNew.KostenKostenträger Where k.Kennung = eTypProt.SumLeistBrutto.ToString().Trim() And k.IDKostIntern = IDKostInternNew
                                                       Select New cSelObj With {.ID = k.ID, .Brutto = k.Brutto, .IDKost = k.IDKost, .IDKostIntern = k.IDKostIntern, .lfdNr = k.lfdNr}).FirstOrDefault()
                    rGesamtkostenNew.Brutto += diff
                    sumBrutto += diff
                    rNewRechZeile.lfdNr = rGesamtkostenNew.lfdNr + 1
                    Me.reorgLfdNrInCalcDB(dbCalcNew, rNewRechZeile.lfdNr)

                ElseIf TypProt = eTypProt.GSGB Then
                    sumBrutto += diff
                    'Dim rGesamtkostenNew As cSelObj = (From k In dbCalcNew.KostenKostenträger Where k.Kennung = eTypProt.Gesamtkosten.ToString().Trim() And k.IDKostIntern = IDKostInternNew
                    '                                   Select New cSelObj With {.ID = k.ID, .Brutto = k.Brutto, .IDKost = k.IDKost, .IDKostIntern = k.IDKostIntern, .lfdNr = k.lfdNr}).FirstOrDefault()
                    rNewRechZeile.lfdNr = 1000 + 1
                    Me.reorgLfdNrInCalcDB(dbCalcNew, rNewRechZeile.lfdNr)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("checkSumRechOldNew: " + ex.ToString())
        End Try
    End Sub

    Public Sub reorgLfdNrInCalcDB(ByRef dbCalc As dbCalc, ByRef lfddNrFrom As Integer)
        Try
            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In dbCalc.KostenKostenträger
                If rKostKostenträger.lfdNr > lfddNrFrom Then
                    rKostKostenträger.lfdNr += 1
                End If
            Next

        Catch ex As Exception
            Throw New Exception("checkSumRechOldNew: " + ex.ToString())
        End Try
    End Sub
    Public Sub getLZBillsGerollt_rek(IDBill As String, ByRef IDKost As String, ByRef lstGerolltPrev As System.Collections.Generic.List(Of cBillsGerollt),
                                     ByRef iCountRek As Integer, ByRef db As PMDS.db.Entities.ERModellPMDSEntities)
        Try
            If iCountRek > 5 Then
                Throw New Exception("getLZBillsGerollt_rek: iCountRek > 5 not allowed for IDBill '" + IDBill.ToString() + "'!")
            End If

            Dim tBillGerollt As IQueryable(Of PMDS.db.Entities.bills) = (From o In db.bills Where o.IDBillStorno = IDBill)
            For Each rBillGerollt As PMDS.db.Entities.bills In tBillGerollt

                'Prüfen ob die zu rollende Rechnung bereits gerollt wurde (alte kreuzweise Verlinkung)
                Dim bBreak As Boolean = False
                For Each checkPrev As cBillsGerollt In lstGerolltPrev
                    If checkPrev.IDBill = IDBill Then
                        bBreak = True
                        Exit For
                    End If
                Next

                If Not bBreak Then
                    Dim rBillHeaderGerollt As PMDS.db.Entities.billHeader = (From o In db.billHeader Where o.ID = rBillGerollt.IDAbrechnung).First()
                    Dim dbCalcGerollt As dbCalc = Me.getDBCalc(rBillHeaderGerollt.dbCalc)

                    Dim arrKostKostenträgerGerollt() As DataRow = dbCalcGerollt.Tables(dbCalcGerollt.KostenKostenträger.TableName).Select(dbCalcGerollt.KostenKostenträger.IDKostColumn.ColumnName + "='" + IDKost.ToString() + "' and Kennung='" + eTypProt.LZ.ToString() + "'",
                                                                                                                            dbCalcGerollt.KostenKostenträger.lfdNrColumn.ColumnName + " asc")

                    Dim BillsGerolltNew As New cBillsGerollt()
                    BillsGerolltNew.IDBill = rBillGerollt.ID
                    For Each rKostKostenträgerGerollt As dbCalc.KostenKostenträgerRow In arrKostKostenträgerGerollt
                        Me.copyKostKostenträger(BillsGerolltNew.dbCalcCopied, rKostKostenträgerGerollt, dbCalcGerollt.Kostenträger, dbCalcGerollt.Zahler, dbCalcGerollt.Leistungen, True)
                    Next
                    lstGerolltPrev.Add(BillsGerolltNew)

                    Me.getLZBillsGerollt_rek(rBillGerollt.ID, IDKost, lstGerolltPrev, iCountRek + 1, db)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("getLZBillsGerollt: " + ex.ToString())
        End Try
    End Sub

    Public Sub copyKostKostenträger(ByRef dbCalcNew As dbCalc, ByRef rKostKostenträgerOld As dbCalc.KostenKostenträgerRow, ByRef KostenträgerOld As dbCalc.KostenträgerDataTable,
                                    ByRef ZahlerOld As dbCalc.ZahlerDataTable, ByRef LeistungenOld As dbCalc.LeistungenDataTable, ByRef doMinus As Boolean)
        Try
            Dim arrKostToCopy() As dbCalc.KostenträgerRow = KostenträgerOld.Select("IDKostIntern='" + rKostKostenträgerOld.IDKostIntern.Trim() + "'", "")
            Dim rKostenträgerAdd As dbCalc.KostenträgerRow = Nothing
            If arrKostToCopy.Length = 1 Then
                Dim rKostToCopy As dbCalc.KostenträgerRow = arrKostToCopy(0)
                rKostenträgerAdd = dbCalcNew.Kostenträger.NewRow()
                rKostenträgerAdd.ItemArray = rKostToCopy.ItemArray
                rKostenträgerAdd.IDKostIntern = LCase(System.Guid.NewGuid.ToString())
                dbCalcNew.Kostenträger.Rows.Add(rKostenträgerAdd)
            Else
                Dim bNoKostenträger As Boolean = True
            End If

            Dim rKostKostenträgerNewAdd As dbCalc.KostenKostenträgerRow = dbCalcNew.KostenKostenträger.NewRow()
            rKostKostenträgerNewAdd.ItemArray = rKostKostenträgerOld.ItemArray
            rKostKostenträgerNewAdd.ID = System.Guid.NewGuid().ToString()
            If Not rKostenträgerAdd Is Nothing Then
                rKostKostenträgerNewAdd.IDKostIntern = rKostenträgerAdd.IDKostIntern
            Else
                rKostKostenträgerNewAdd.IDKostIntern = ""
            End If
            If doMinus Then
                rKostKostenträgerNewAdd.Netto *= -1
                rKostKostenträgerNewAdd.Brutto *= -1
                'rKostKostenträgerNewAdd.tempMWSt *= -1
            End If
            rKostKostenträgerNewAdd.lfdNr = 0
            rKostKostenträgerNewAdd.Classification += "Storno;"
            dbCalcNew.KostenKostenträger.Rows.Add(rKostKostenträgerNewAdd)

            Dim arrZahlerToCopy() As dbCalc.ZahlerRow = ZahlerOld.Select("IDKostIntern='" + rKostKostenträgerOld.IDKostIntern.Trim() + "'", "")
            For Each rZahlerOld As dbCalc.ZahlerRow In arrZahlerToCopy
                Dim rNewZahler As dbCalc.ZahlerRow = dbCalcNew.Zahler.NewRow()
                rNewZahler.ItemArray = rZahlerOld.ItemArray
                rNewZahler.IDKostIntern = rKostKostenträgerNewAdd.IDKostIntern
                If doMinus Then
                    rNewZahler.NettoBetragProLeistung *= -1
                    rNewZahler.MWStProLeistung *= -1
                End If
                dbCalcNew.Zahler.Rows.Add(rNewZahler)

                Dim arrLeistungenNew() As dbCalc.LeistungenRow = dbCalcNew.Leistungen.Select("ID='" + rZahlerOld.IDLeistung.Trim() + "'", "")
                If arrLeistungenNew.Length = 0 Then
                    Dim arrLeistungenToCopy() As dbCalc.LeistungenRow = LeistungenOld.Select("ID='" + rZahlerOld.IDLeistung.Trim() + "'", "")
                    Dim rNewLeistungen As dbCalc.LeistungenRow = dbCalcNew.Leistungen.NewRow()
                    rNewLeistungen.ItemArray = arrLeistungenToCopy(0).ItemArray
                    dbCalcNew.Leistungen.Rows.Add(rNewLeistungen)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("copyKostKostenträger: " + ex.ToString())
        End Try
    End Sub

    Public Sub readSumProLeistung(arrKostKostenträger() As DataRow, ByRef lstCollSumNew As System.Collections.Generic.Dictionary(Of String, cSumLeistungen))
        Try
            For Each rKostKostenträgerNew As dbCalc.KostenKostenträgerRow In arrKostKostenträger
                Dim bExists As Boolean = False

                If rKostKostenträgerNew.IDLeistungsKatalog.Trim() <> "" And rKostKostenträgerNew.IDSonderLeistungskatalog.Trim() = "" Then
                    If lstCollSumNew.ContainsKey(rKostKostenträgerNew.IDLeistungsKatalog) Then
                        lstCollSumNew(rKostKostenträgerNew.IDLeistungsKatalog).lstKostKostenträger.Add(rKostKostenträgerNew)

                        lstCollSumNew(rKostKostenträgerNew.IDLeistungsKatalog).Netto += rKostKostenträgerNew.Netto
                        lstCollSumNew(rKostKostenträgerNew.IDLeistungsKatalog).Brutto += rKostKostenträgerNew.Brutto
                        bExists = True
                    End If
                ElseIf rKostKostenträgerNew.IDLeistungsKatalog.Trim() = "" And rKostKostenträgerNew.IDSonderLeistungskatalog.Trim() <> "" Then
                    If lstCollSumNew.ContainsKey(rKostKostenträgerNew.IDSonderLeistungskatalog) Then
                        lstCollSumNew(rKostKostenträgerNew.IDLeistungsKatalog).lstKostKostenträger.Add(rKostKostenträgerNew)

                        lstCollSumNew(rKostKostenträgerNew.IDSonderLeistungskatalog).Netto += rKostKostenträgerNew.Netto
                        lstCollSumNew(rKostKostenträgerNew.IDLeistungsKatalog).Brutto += rKostKostenträgerNew.Brutto
                        bExists = True
                    End If
                End If

                If Not bExists Then
                    Dim cSumLeistungenNew As New cSumLeistungen()
                    If rKostKostenträgerNew.IDLeistungsKatalog.Trim() <> "" Then
                        cSumLeistungenNew.IDLeistungskatalogIDSonderleistung = rKostKostenträgerNew.IDLeistungsKatalog
                        cSumLeistungenNew.IsSonderleistung = False
                    Else
                        cSumLeistungenNew.IDLeistungskatalogIDSonderleistung = rKostKostenträgerNew.IDSonderLeistungskatalog
                        cSumLeistungenNew.IsSonderleistung = True
                    End If
                    cSumLeistungenNew.Bezeichnung = rKostKostenträgerNew.Bezeichnung.Trim()
                    cSumLeistungenNew.Netto = rKostKostenträgerNew.Netto
                    cSumLeistungenNew.Brutto = rKostKostenträgerNew.Brutto
                    cSumLeistungenNew.lstKostKostenträger.Add(rKostKostenträgerNew)
                    If rKostKostenträgerNew.IDLeistungsKatalog.Trim() <> "" Then
                        lstCollSumNew.Add(rKostKostenträgerNew.IDLeistungsKatalog, cSumLeistungenNew)
                    Else
                        lstCollSumNew.Add(rKostKostenträgerNew.IDSonderLeistungskatalog, cSumLeistungenNew)
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doRollung.readSumProLeistung: " + ex.ToString())
        End Try
    End Sub

    Private Function SetStornoRow(dbCalcNew As dbCalc, rKostKostenträgerOld As dbCalc.KostenKostenträgerRow, IDKostInternNew As String) As dbCalc.KostenKostenträgerRow
        Try
            Dim rKostKostenträgerNewAdd As dbCalc.KostenKostenträgerRow = dbCalcNew.KostenKostenträger.NewRow()
            rKostKostenträgerNewAdd.ItemArray = rKostKostenträgerOld.ItemArray
            rKostKostenträgerNewAdd.ID = IDKostInternNew
            rKostKostenträgerNewAdd.IDKostIntern = rKostKostenträgerOld.IDKostIntern
            rKostKostenträgerNewAdd.Netto *= -1
            rKostKostenträgerNewAdd.lfdNr = 0
            rKostKostenträgerNewAdd.Classification += "Storno;"
            Return rKostKostenträgerNewAdd

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
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

    Public Sub prepareRechZR(ByRef lstMwstDistinct As System.Collections.Generic.List(Of calculation.cMwst), ByRef dbCalc As dbCalc, ByRef lfdNrLast As Integer, ByRef SumNetto As Double,
                            ByRef doNotDeleteRows As Boolean, Optional IDKost As String = "")
        Try
            Dim lstRowsToDelete As New System.Collections.Generic.List(Of dbCalc.KostenKostenträgerRow)

            Dim arrKostKostenträger() As dbCalc.KostenKostenträgerRow = dbCalc.KostenKostenträger.Select("", dbCalc.KostenKostenträger.lfdNrColumn.ColumnName + " asc")
            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In arrKostKostenträger
                If IDKost.Trim() = "" Or (IDKost.Trim() <> "" And rKostKostenträger.IDKost.Trim().Equals(IDKost.Trim())) Then
                    If rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.LZ.ToString().Trim().ToLower()) Then
                        For Each Mwst As calculation.cMwst In lstMwstDistinct
                            If Mwst.MwstSatz.Equals(rKostKostenträger.MWSt) Then
                                Mwst.sum += rKostKostenträger.Netto
                            End If
                        Next

                        SumNetto += rKostKostenträger.Netto
                        If rKostKostenträger.lfdNr > lfdNrLast Then lfdNrLast = rKostKostenträger.lfdNr

                    Else
                        If Not doNotDeleteRows Then
                            'lstRowsToDelete.Add(rKostKostenträger)
                        End If
                    End If
                End If
            Next

            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In lstRowsToDelete
                'rKostKostenträger.Delete()
            Next
            dbCalc.AcceptChanges()

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


    Public Sub addKostenträgerToDBCalc(ByRef IDKostInternToCopy As String, ByRef dbCalcOld As dbCalc, ByRef dbCalcNew As dbCalc, ByRef IDKostNewReturn As String)
        Try
            Dim arrKostToCopy() As dbCalc.KostenträgerRow = dbCalcOld.Kostenträger.Select("IDKostIntern='" + IDKostInternToCopy.Trim() + "'", "")
            Dim rKostToCopy As dbCalc.KostenträgerRow = arrKostToCopy(0)

            Dim rKostenträgerAdd As dbCalc.KostenträgerRow = dbCalcNew.Kostenträger.NewRow()
            rKostenträgerAdd.ItemArray = rKostToCopy.ItemArray
            rKostenträgerAdd.IDKostIntern = LCase(System.Guid.NewGuid.ToString())
            dbCalcNew.Kostenträger.Rows.Add(rKostenträgerAdd)

            IDKostNewReturn = rKostenträgerAdd.IDKostIntern

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


    Public Sub saveNewBeilage(rBillsNew As PMDS.db.Entities.bills, rBillsOld As dbPMDS.billsRow, dbCalcNew As dbCalc, db As PMDS.db.Entities.ERModellPMDSEntities, ByRef editor As TXTextControl.TextControl,
                                ByRef billFormat As QS2.Desktop.Txteditor.formatAttr, ByRef summeBrutto As Double,
                                ByRef lstGerolltPrev As System.Collections.Generic.List(Of cBillsGerollt))
        Try
            editor.Text = ""
            Me.doEditor1.showText(rBillsNew.Rechnung, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editor)

            Dim tTableNr2 As Integer = 0
            Dim nRowNr As Integer = 0
            For Each tTable As TXTextControl.Table In editor.Tables
                nRowNr = 1
                If nRowNr = 1 Then
                    Dim iCounterCells As Integer = 0
                    For Each tcCell As TXTextControl.TableCell In tTable.Cells
                        If tcCell.Row = nRowNr Then
                            iCounterCells += 1
                            Dim sCellTxt As String = tcCell.Text.Trim()
                        End If
                    Next
                    If iCounterCells = 5 Then
                        billFormat.tableNr = tTableNr2 + 1
                        Exit For
                    End If
                End If
                tTableNr2 += 1
            Next

            Dim lstRowsToDeleteTXTControl As New System.Collections.Generic.List(Of TXTextControl.TableRow)
            nRowNr = 0
            Dim tTxtTableCalc As TXTextControl.Table = editor.Tables(billFormat.tableNr)
            For Each rRow As TXTextControl.TableRow In tTxtTableCalc.Rows
                nRowNr += 1
                If nRowNr > 1 Then
                    'Dim nCellNr As Integer = 0
                    'For Each tcCell As TXTextControl.TableCell In tTxtTableCalc.Cells
                    '    If tcCell.Row = nRowNr Then
                    '        nCellNr += 1
                    '        Dim sCellTxt As String = tcCell.Text.Trim()
                    '    End If
                    'Next
                    lstRowsToDeleteTXTControl.Add(rRow)
                End If
            Next

            For i As Integer = lstRowsToDeleteTXTControl.Count - 1 To 0 Step -1
                Dim rRow As TXTextControl.TableRow = lstRowsToDeleteTXTControl(i)
                rRow.Select()
                'If editor.Selection.Length = tTxtTableCalc.Columns.Count Then
                editor.Selection.Length = 0
                tTxtTableCalc.Rows.Remove()
                'End If
            Next

            'For Each rRow As TXTextControl.TableRow In lstRowsToDeleteTXTControl
            '    rRow.Select()
            '    If editor.Selection.Length = tTxtTableCalc.Columns.Count Then
            '        editor.Selection.Length = 0
            '        tTxtTableCalc.Rows.Remove()
            '    End If
            'Next
            billFormat.tableNr -= 1
            Dim TypProtTmp As eTypProt
            Dim arrRechZeilen() As dbCalc.KostenKostenträgerRow = dbCalcNew.KostenKostenträger.Select(dbCalcNew.KostenKostenträger.IDKostColumn.ColumnName + "='" + rBillsNew.IDKost.ToString() + "'", "lfdNr asc")
            For Each rKostKostenträger As dbCalc.KostenKostenträgerRow In arrRechZeilen
                Dim typProt As eTypProt = Me.getEnumAsListTypProt(rKostKostenträger.Kennung, TypProtTmp.GetType())

                Dim LineTop As Boolean = False
                Dim TxtBold As Boolean = False
                If rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.SumLeistNetto.ToString().Trim().ToLower()) Or
                    rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.SumLeistBrutto.ToString().Trim().ToLower()) Or
                    rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.Zahlungsbetrag.ToString().Trim().ToLower()) Then

                    LineTop = True
                End If
                If rKostKostenträger.Kennung.Trim().ToLower().Equals(eTypProt.Zahlungsbetrag.ToString().Trim().ToLower()) Then
                    TxtBold = True
                End If

                bill.setPrintColumn(New System.Guid(rKostKostenträger.ID), eTypProt.LZ, rKostKostenträger.Anzahl, rKostKostenträger.Bezeichnung, rKostKostenträger.Netto, rKostKostenträger.MWSt, rKostKostenträger.Brutto, rKostKostenträger.MWStSatz, billFormat)
                Me.print.addCollumn(New System.Guid(rKostKostenträger.ID), billFormat, editor, LineTop, TxtBold, eTypProt.LZ)
            Next


            db.Configuration.LazyLoadingEnabled = False
            db.Configuration.LazyLoadingEnabled = False

            Dim tBillHeaderUpdate As IQueryable(Of PMDS.db.Entities.billHeader) = From o In db.billHeader Where o.ID = rBillsNew.IDAbrechnung
            Dim rBillHeaderUpdate As PMDS.db.Entities.billHeader = tBillHeaderUpdate.First()
            rBillHeaderUpdate.dbCalc = Me.bill.getXMLDbCalc(dbCalcNew)

            Dim tbillsUpdate As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = rBillsNew.ID
            Dim rBillsUpdate As PMDS.db.Entities.bills = tbillsUpdate.First()
            rBillsUpdate.Rechnung = doEditor1.getText(TXTextControl.StreamType.RichTextFormat, editor)
            rBillsUpdate.betrag = summeBrutto
            'rBillsUpdate.IDBillStorno = rBillsOld.ID
            rBillsUpdate.RollungAnz = 0
            db.SaveChanges()

            db.Configuration.LazyLoadingEnabled = False

            Dim tBillsOldUpdate As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = rBillsOld.ID
            Dim rBillsOldUpdate As PMDS.db.Entities.bills = tBillsOldUpdate.First()
            rBillsOldUpdate.IDBillStorno = rBillsNew.ID
            rBillsOldUpdate.IDBillsGerollt += rBillsUpdate.ID + ";"
            rBillsOldUpdate.RollungAnz = 1
            db.SaveChanges()

            For Each BillsGerollt As cBillsGerollt In lstGerolltPrev
                Dim tBillsGerolltUpdate As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = rBillsOld.ID
                Dim rBillsGerolltUpdate As PMDS.db.Entities.bills = tBillsGerolltUpdate.First()
                rBillsGerolltUpdate.RollungAnz = BillsGerollt.RollungAnz
                rBillsGerolltUpdate.IDBillsGerollt += rBillsUpdate.ID + ";"
                db.SaveChanges()
            Next

            'If (rBillsUpdate.betrag = rBillsOldUpdate.betrag) Then
            '    db.bills.Remove(rBillsOldUpdate)
            '    db.bills.Remove(rBillsUpdate)
            '    dbUpdate.SaveChanges()
            'End If


            'Dim dbPmdsUpdate As New dbPMDS()
            'Dim sqlUpdate As New Sql()
            'sqlUpdate.initControl()

            'sqlUpdate.readBillHeaderUpdate(rBillsNew.IDAbrechnung, dbPmdsUpdate)
            'sqlUpdate.readBillUpdate(rBillsNew.ID, dbPmdsUpdate)
            'Dim rBillHeaderUpdate As dbPMDS.billHeaderUpdateRow = dbPmdsUpdate.billHeaderUpdate.Rows(0)
            'Dim rBillUpdate As dbPMDS.billsUpdateRow = dbPmdsUpdate.billsUpdate.Rows(0)


            'rBillHeaderUpdate.dbCalc = Me.bill.getXMLDbCalc(dbCalcNew)
            'rBillUpdate.Rechnung = doEditor1.getText(TXTextControl.StreamType.RichTextFormat, editor)
            'rBillUpdate.betrag = summeBrutto
            'rBillUpdate.IDBillStorno = rBillsOld.ID
            'sqlUpdate.daBillHeaderUpdate.Update(dbPmdsUpdate.billHeaderUpdate)
            'sqlUpdate.daBillUpdate.Update(dbPmdsUpdate.billsUpdate)

            'Dim dbPmdsUpdate2 As New dbPMDS()
            'Dim sqlUpdate1 As New Sql()
            'sqlUpdate1.initControl()

            'sqlUpdate1.readBillUpdate(rBillsOld.ID, dbPmdsUpdate2)
            'Dim rBillUpdate2 As dbPMDS.billsUpdateRow = dbPmdsUpdate2.billsUpdate.Rows(0)
            'rBillUpdate2.IDBillStorno = rBillsNew.ID
            'sqlUpdate1.daBillUpdate.Update(dbPmdsUpdate2.billsUpdate)
            ''sqlUpdate1.updateBillSet_IDBillStorno(rBillsOld.ID, rBillUpdate.ID + ";")

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function getEnumAsListTypProt(ByRef strToSearch As String, typ As Type) As eTypProt
        For Each val As Integer In [Enum].GetValues(typ)
            Dim strEnum As String = [Enum].GetName(typ, val)
            If strEnum.Trim().ToLower().Equals(strToSearch.Trim().ToLower()) Then
                Return val
            End If
        Next

        Throw New Exception("doRollung.getEnumAsListTypProt: strToSearch '" + strToSearch.Trim() + "' not found in Enum-Type eTypProt!")
    End Function


End Class
