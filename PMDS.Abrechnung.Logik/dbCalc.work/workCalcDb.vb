Option Strict Off

Imports System.Collections.Generic



Public Class workCalcDb

    Public Shared lineBreakHtml As String = "<br/>"
    Public Shared prefixTable As String = "calc_"

    Public Shared temp_sqlTableCheck As String = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='{0}')" + vbNewLine +
                                                   "DROP TABLE [dbo].[{1}]" + vbNewLine

    Public Shared temp_sqlInsertRow As String = " INSERT {0} "
    Private Shared BMDExportTyp As PMDS.Calc.Logic.workCalcDb.eBMDExportTyp = eBMDExportTyp.Standard
    Private Shared FSW_FibuKonto As String

    Public Enum eTypUI
        CopyDb = 0
        ExportCalcs = 1
    End Enum

    Public Enum eBMDExportTyp
        Standard = 1    'adcura)
        MZ = 2
    End Enum

    Public tCalcDocu As String = "KostenKostenträger"
    Public dbExport1 As New dbExport()
    Public dbPMDS As New dbPMDS()
    Public dbCalcTemp As New dbCalc()

    Public Class lineExport
        Public expMwst As Decimal = 0
        Public expBetrag As Decimal = 0
        Public expSteuer As Decimal = 0
        Public expOpbetrag As Decimal = 0
        Public expMWStSatzKonto As String = ""
        Public FIBU As String = ""
        Public NameKost As String = ""
        Public FIBUKost As String = ""
        Public bDone As Boolean = False
    End Class

    Public dbBill1 As New dbBill()

    Public Class cSelObj
        Public db As String = ""
        Public IDBill As Guid
        Public RechNr As String = ""
        Public ExportiertJN As Boolean
        Public IDKost As Guid
        Public FiBuKost = ""
        Public IDKostSub As Guid = Guid.Empty
        Public FiBuKostSub = ""
    End Class

    Public Class cSelBillInfo
        Public IDBill As String
        Public RechNr As String
        Public ExportiertJN As Boolean
        Public IDKost As String
        Public IDKlinik? As Guid
        Public IDKlient As String
    End Class

    Public Class cSelKostentraegerInfo
        Public IDKost As Guid
        Public FiBuKost As String
        Public IDKostSub? As Guid
    End Class




    '<20120101>
    Public Function createTablesFromDs(ByRef sqlTotalResult As String) As Boolean
        Try
            Dim dbCalcToCreate As New dbCalc()

            Dim sqlDelTables As String = ""
            For Each tableToCreate As DataTable In dbCalcToCreate.Tables
                sqlDelTables += String.Format(workCalcDb.temp_sqlTableCheck, workCalcDb.prefixTable + tableToCreate.TableName, workCalcDb.prefixTable + tableToCreate.TableName) + vbNewLine
            Next
            If sqlDelTables.Trim() <> "" Then
                Dim sqlCalc As New Sql()
                sqlCalc.executeCommand(sqlDelTables.Trim())
                sqlTotalResult += sqlDelTables
                sqlTotalResult += "-- OLD TABLES SUCCESSFULL DELETED" + vbNewLine + vbNewLine
            End If

            For Each tableToCreate As DataTable In dbCalcToCreate.Tables
                Dim sqlTableCreate As String = "CREATE TABLE [dbo].[" + workCalcDb.prefixTable + tableToCreate.TableName + "](" + vbNewLine +
                                               " "
                Dim sqlCols As String = ""
                sqlCols += " [IDCalc] [uniqueidentifier] NOT NULL , " + vbNewLine
                sqlCols += " [IDBillHeader] [varchar](50) NOT NULL DEFAULT (''), " + vbNewLine
                sqlCols += " [CalcDescription] [varchar](200) NOT NULL DEFAULT ('') "

                For Each columnToCreate As DataColumn In tableToCreate.Columns
                    'Dim sqlCol As String = ""
                    'sqlCols += IIf(sqlCols.Trim() = "", vbNewLine, "," + vbNewLine)
                    sqlCols = sqlCols + "," + vbNewLine
                    sqlCols += " [" + columnToCreate.ColumnName + "]"

                    If columnToCreate.DataType.Name.Equals("String", StringComparison.CurrentCultureIgnoreCase) Then
                        Dim sLength As String = ""
                        Dim SqlNullable As String = ""
                        If Not columnToCreate.AllowDBNull Then
                            SqlNullable = " NOT NULL DEFAULT ('') "
                        Else
                            SqlNullable = " NULL "
                        End If
                        If columnToCreate.MaxLength > 0 And columnToCreate.MaxLength < 8000 Then
                            sLength = columnToCreate.MaxLength.ToString()
                            sqlCols += " [varchar](" + sLength + ") " + SqlNullable
                        ElseIf columnToCreate.MaxLength > 8000 Then
                            sLength = columnToCreate.MaxLength.ToString()
                            sqlCols += " [varchar](max)  " + SqlNullable
                        Else
                            sLength = "500"
                            sqlCols += " [varchar](" + sLength + ") " + SqlNullable
                        End If

                    ElseIf columnToCreate.DataType.Name.Equals("Guid", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [uniqueidentifier] "
                        If Not columnToCreate.AllowDBNull Then
                            sqlCols += " NOT NULL "
                        Else
                            sqlCols += " NULL "
                        End If

                    ElseIf columnToCreate.DataType.Name.Equals("Boolean", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [bit] DEFAULT (0) "
                    ElseIf columnToCreate.DataType.Name.Equals("Int32", StringComparison.CurrentCultureIgnoreCase) Or columnToCreate.DataType.FullName.Equals("Int64", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [int] DEFAULT (0) "
                    ElseIf columnToCreate.DataType.Name.Equals("Decimal", StringComparison.CurrentCultureIgnoreCase) Or columnToCreate.DataType.Name.Equals("Double", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [decimal](18, 3) DEFAULT (0) "
                    ElseIf columnToCreate.DataType.Name.Equals("Float", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [float]  DEFAULT (0) "
                    ElseIf columnToCreate.DataType.Name.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase) Then
                        sqlCols += " [datetime] "
                        If Not columnToCreate.AllowDBNull Then
                            sqlCols += " NOT NULL "
                        Else
                            sqlCols += " NULL "
                        End If

                    Else
                        Throw New Exception("createOnSqlServer: Type '" + columnToCreate.DataType.Name.ToString() + "' for Column '" + columnToCreate.ColumnName + "' in Table '" + tableToCreate.TableName + "' not supported!")
                    End If

                    'If columnToCreate.AllowDBNull Then
                    '    sqlTempCols += " NOT NULL "
                    'Else
                    '    sqlTempCols += " NULL "
                    'End If

                    If columnToCreate.Unique Then
                    End If
                Next

                sqlTableCreate += sqlCols + " ) " + vbNewLine
                If sqlTableCreate.Trim() <> "" Then
                    Dim sqlCalc As New Sql()
                    sqlCalc.executeCommand(sqlTableCreate.Trim())
                    sqlTotalResult += sqlTableCreate
                    sqlTotalResult += "-- NEW TABLE SUCESSFULL CREATED" + vbNewLine + vbNewLine
                End If
            Next

            Return True

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function

    Public Function SetBMDExportTyp(NewBMDExportTyp As PMDS.Calc.Logic.workCalcDb.eBMDExportTyp, FSW_FibuKonto As String)
        Try
            Me.FSW_FibuKonto = FSW_FibuKonto
            BMDExportTyp = NewBMDExportTyp
        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function

    Public Function doCalcDatabases(ByVal typ As eTypUI, ByRef dFrom As Object, ByRef dTo As Object, ByRef dFromRechDatum As Nullable(Of Date), ByRef dToRechDatum As Nullable(Of Date), ByRef dsExportResult As dsExport,
                                      ByRef sqlTotalResult As String,
                                      ByRef countRowsTotalCopied As Integer, ByRef countDbTotalCopied As Integer,
                                      ByVal billTyp As eBillTyp, ByVal billStatus As eBillStatus,
                                      ByVal bereich As String,
                                      ByVal typRechNr As String,
                                      ByRef nErrors As Integer, IDKlinik As System.Guid, ByRef sProt As String, ByRef SumBruttoSRAll As Double, showExportierte As Boolean) As Boolean
        Try

            Using lstCalcsFounded As New dbPMDS()
                Using dbPMDSFound As New dbPMDS()

                    If dFrom = Nothing Then
                        dFrom = New Date(1900, 1, 1)
                    End If

                    If dTo = Nothing Then
                        dTo = New Date(2049, 31, 12)
                    End If

                    Using sqlCalc As New Sql()
                        sqlCalc.readBills("", dFrom, dTo, dFromRechDatum, dToRechDatum, dbPMDSFound, billTyp, billStatus, True, IDKlinik, False, showExportierte, "")
                    End Using

                    For Each rBillFound As dbPMDS.billsRow In dbPMDSFound.bills
                        dbPMDSFound.billHeader.Rows.Clear()
                        Using sqlCalcRead As New Sql()
                            sqlCalcRead.readBillHeader(rBillFound.IDAbrechnung, dbPMDSFound, IDKlinik)
                        End Using

                        If dbPMDSFound.billHeader.Rows.Count <> 1 Then
                            sqlTotalResult += "INFO: NO CALC-DB found for Header " + "" + "!" + vbNewLine + vbNewLine
                        Else
                            Dim rBillHeaderFound As dbPMDS.billHeaderRow = dbPMDSFound.billHeader.Rows(0)
                            Select Case typ
                                Case eTypUI.CopyDb
                                    Dim bExists As Boolean
                                    For Each rBillHeaderExistsInLst As dbPMDS.billHeaderRow In lstCalcsFounded.billHeader
                                        If rBillHeaderExistsInLst.ID.Equals(rBillHeaderFound.ID) Then
                                            bExists = True
                                        End If
                                    Next
                                    If Not bExists Then
                                        Dim rBillHeaderToAdd As dbPMDS.billHeaderRow = lstCalcsFounded.billHeader.NewRow()
                                        rBillHeaderToAdd.ItemArray = rBillHeaderFound.ItemArray
                                        lstCalcsFounded.billHeader.Rows.Add(rBillHeaderToAdd)
                                    End If

                                Case eTypUI.ExportCalcs
                                    Dim xmlStringReader As New System.IO.StringReader(rBillHeaderFound.dbCalc)
                                    Using dbCalcFound As New DataSet()
                                        Using xmlReader As New System.Xml.XmlTextReader(xmlStringReader)
                                            dbCalcFound.ReadXml(xmlReader)
                                        End Using

                                        Me.doExportCalcDb(dbCalcFound, rBillFound, rBillHeaderFound, dsExportResult,
                                                  billTyp, billStatus, bereich, typRechNr,
                                                  nErrors, sProt, SumBruttoSRAll)
                                    End Using

                                Case Else
                                    Throw New Exception("doCalcDatabases: Type '" + typ.ToString() + "' does not exist!")
                            End Select
                        End If
                    Next
                End Using

                If typ = eTypUI.CopyDb Then
                    If lstCalcsFounded.billHeader.Rows.Count > 0 Then
                        Using dbCalcTemp As New dbCalc()
                            Me.deleteAllTables(dbCalcTemp, sqlTotalResult)
                        End Using

                        For Each rBillHeaderFound As dbPMDS.billHeaderRow In lstCalcsFounded.billHeader
                            Dim xmlStringReader As New System.IO.StringReader(rBillHeaderFound.dbCalc)

                            Using dbCalcFound As New DataSet()
                                Using xmlReader As New System.Xml.XmlTextReader(xmlStringReader)
                                    dbCalcFound.ReadXml(xmlReader)
                                End Using

                                Me.copyDataToSqlServer(dbCalcFound, System.Guid.NewGuid, "", sqlTotalResult, countRowsTotalCopied, countDbTotalCopied,
                                                    rBillHeaderFound.ID)
                            End Using
                        Next
                    Else
                        sqlTotalResult += "INFO: NO CALCS FOUND FOR TRANSFER!" + vbNewLine + vbNewLine
                    End If
                    sqlTotalResult += "INFO: " + countDbTotalCopied.ToString() + " DATABASES SUCCESSFULL TRANSFERED!" + vbNewLine + vbNewLine
                End If
            End Using

            Return True

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function

    Public Function deleteAllTables(ByRef dbCalcToCopy As dbCalc, ByRef sqlTotalResult As String) As Boolean
        Try
            Dim slqDeleteAllRows As String = ""
            For Each tableToCreate As DataTable In dbCalcToCopy.Tables

                slqDeleteAllRows += "IF (EXISTS(SELECT * From INFORMATION_SCHEMA.TABLES Where TABLE_SCHEMA = 'dbo' "
                slqDeleteAllRows += "    AND TABLE_NAME = '" + workCalcDb.prefixTable + tableToCreate.TableName + "'))" + vbNewLine
                slqDeleteAllRows += " BEGIN" + vbNewLine
                slqDeleteAllRows += " DELETE FROM " + workCalcDb.prefixTable + tableToCreate.TableName + "" + vbNewLine
                slqDeleteAllRows += " END" + vbNewLine
            Next
            Dim sqlCalc As New Sql()
            sqlCalc.executeCommand(slqDeleteAllRows.Trim())
            sqlTotalResult += slqDeleteAllRows
            sqlTotalResult += "-- ALL ROWS FROM TABLES SUCESSFULLY DELETED" + vbNewLine + vbNewLine

            Return True

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function

    Public Function copyDataToSqlServer(ByRef dbCalcToCopy As DataSet,
                                        ByRef IDCalc As System.Guid, ByRef CalcDescription As String,
                                        ByRef sqlTotalResult As String,
                                        ByRef countRowsTotalCopied As Integer, ByRef countDbTotalCopied As Integer,
                                        ByRef IDBillHeader As String) As Boolean
        Try
            For Each tableToCreate As DataTable In dbCalcToCopy.Tables
                Dim sqlColsArray As String = " (" + vbNewLine
                sqlColsArray += " [IDCalc], " + vbNewLine
                sqlColsArray += " [IDBillHeader], " + vbNewLine
                sqlColsArray += " [CalcDescription] "
                For Each columnToCreate As DataColumn In tableToCreate.Columns
                    sqlColsArray += "," + vbNewLine
                    sqlColsArray += " [" + columnToCreate.ColumnName + "]"
                Next
                sqlColsArray += " ) Values " + vbNewLine

                If tableToCreate.Rows.Count > 0 Then
                    Dim sqlInsertRows As String = ""
                    For Each rowToCopy As DataRow In tableToCreate.Rows

                        sqlInsertRows += "IF (EXISTS(SELECT * From INFORMATION_SCHEMA.TABLES Where TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '" + workCalcDb.prefixTable + tableToCreate.TableName + "'))" + vbCrLf
                        sqlInsertRows += "BEGIN" + vbCrLf
                        'sqlInsertRows += IIf(sqlInsertRows.Trim() = "", vbNewLine, "," + vbNewLine)
                        sqlInsertRows += String.Format(workCalcDb.temp_sqlInsertRow, workCalcDb.prefixTable + tableToCreate.TableName) + sqlColsArray + " (" + vbNewLine
                        sqlInsertRows += "'" + IDCalc.ToString() + "'," + vbNewLine
                        sqlInsertRows += "'" + IDBillHeader.ToString() + "'," + vbNewLine
                        sqlInsertRows += "'" + CalcDescription.Trim().ToString() + "'"

                        Dim sqlCols As String = ""
                        For Each columnForRow As DataColumn In tableToCreate.Columns
                            sqlCols += "," + vbNewLine

                            If rowToCopy(columnForRow.ColumnName) Is System.DBNull.Value Then
                                sqlCols += "null"
                            Else
                                If columnForRow.DataType.Name.Equals("String", StringComparison.CurrentCultureIgnoreCase) Then
                                    Dim sStr As String = rowToCopy(columnForRow.ColumnName).Replace("'", Chr(34))
                                    sqlCols += "'" + sStr + "'"
                                ElseIf columnForRow.DataType.Name.Equals("Guid", StringComparison.CurrentCultureIgnoreCase) Then
                                    sqlCols += "'" + rowToCopy(columnForRow.ColumnName).ToString() + "'"
                                ElseIf columnForRow.DataType.Name.Equals("Boolean", StringComparison.CurrentCultureIgnoreCase) Then
                                    If rowToCopy(columnForRow.ColumnName) Then
                                        sqlCols += "1"
                                    Else
                                        sqlCols += "0"
                                    End If
                                ElseIf columnForRow.DataType.Name.Equals("Int32", StringComparison.CurrentCultureIgnoreCase) Or
                                       columnForRow.DataType.Name.Equals("Int64", StringComparison.CurrentCultureIgnoreCase) Or
                                       columnForRow.DataType.Name.Equals("Decimal", StringComparison.CurrentCultureIgnoreCase) Or
                                       columnForRow.DataType.Name.Equals("Double", StringComparison.CurrentCultureIgnoreCase) Or
                                       columnForRow.DataType.Name.Equals("Float", StringComparison.CurrentCultureIgnoreCase) Then

                                    Dim sDecimal As String = rowToCopy(columnForRow.ColumnName).ToString()
                                    sDecimal = sDecimal.Replace(",", ".")
                                    sqlCols += "" + sDecimal + ""
                                ElseIf columnForRow.DataType.Name.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase) Then
                                    Dim dDate As Date = rowToCopy(columnForRow.ColumnName)
                                    sqlCols += "'" + dDate.ToString() + "'"
                                Else
                                    Throw New Exception("copyDataToSqlServer: Type '" + columnForRow.DataType.ToString() + "' for Column '" + columnForRow.ColumnName + "' in Table '" + tableToCreate.TableName + "' not supported!")
                                End If
                            End If
                        Next
                        sqlInsertRows += sqlCols + ") " + vbNewLine
                        sqlInsertRows += "END" + vbCrLf
                        countRowsTotalCopied += 1
                    Next
                    If Not String.IsNullOrWhiteSpace(sqlInsertRows) Then
                        'sqlTotalResult += sqlInsertRows + vbNewLine + vbNewLine
                        Using sqlCalc As New Sql()
                            sqlCalc.executeCommand(sqlInsertRows)
                        End Using
                    End If
                End If
            Next

            countDbTotalCopied += 1
            Return True

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function

    Public Function doExportCalcDb(ByRef dbCalcFound As DataSet,
                                     ByVal rBill As dbPMDS.billsRow, ByVal rBillHeaderFound As dbPMDS.billHeaderRow,
                                     ByRef dsExportResult As dsExport,
                                     ByVal billTyp As eBillTyp, ByVal billStatus As eBillStatus,
                                     ByVal bereich As String,
                                     ByVal typRechNr As String,
                                     ByRef nErrors As Integer, ByRef sProt As String, ByRef SumBruttoSRAll As Double) As Boolean
        Try
            If (billTyp = eBillTyp.Rechnung Or billTyp = eBillTyp.Sammelrechnung Or
                billTyp = eBillTyp.FreieRechnung) And
                (billStatus = eBillStatus.freigegeben Or billStatus = eBillStatus.storniert) Then

                Dim rKlientCalc As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.Klient.TableName)(0)
                Dim monat As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.Monate.TableName)(0)

                'Dim dbCalcFoundTyp As dbCalc = dbCalcFound
                If rBill.IDKostIntern.Trim() = "" Then
                    Throw New Exception("doExportCalcDb: rBill.IDKostIntern.Trim()='' for rBill.ID='" + rBill.ID.ToString() + "'!")
                End If
                Dim tKostenträgerCalc As DataTable = dbCalcFound.Tables(Me.dbCalcTemp.Kostenträger.TableName)
                Dim arrKostenträgerCalc() As DataRow = tKostenträgerCalc.Select(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName + "='" + rBill.IDKostIntern + "'", "")
                If arrKostenträgerCalc.Length <> 1 Then
                    Throw New Exception("doExportCalcDb: arrKostenträgerCalc.Length <> 1 for rBill.ID='" + rBill.ID.ToString() + "' and rBill.IDKostIntern='" + rBill.IDKostIntern.ToString() + "'!")
                End If
                Dim rKostenträgerCalc As DataRow = arrKostenträgerCalc(0)               '<20120111-2>
                'For Each rKostenträgerCalc As DataRow In tKostenträgerCalc.Rows
                Dim IDKost As String = rKostenträgerCalc(Me.dbCalcTemp.Kostenträger.IDKostColumn.ColumnName)
                Dim IDKostIntern As String = rKostenträgerCalc(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName)

                'Dim SR As Boolean = rKostenträgerCalc(Me.dbCalcTemp.Kostenträger.SammelabrechnungJNColumn.ColumnName)
                Dim arrCalcDocu() As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.KostenKostenträger.TableName).Select(Me.dbCalcTemp.KostenKostenträger.IDKostInternColumn.ColumnName + "='" + rKostenträgerCalc(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName) + "'",
                                                                                                                     Me.dbCalcTemp.KostenKostenträger.lfdNrColumn.ColumnName + " asc")

                Dim linesToExportAll As New System.Collections.Generic.List(Of lineExport)
                Dim linesToExportSRTmp As New System.Collections.Generic.List(Of lineExport)
                Dim lstSRFibuDistinct As New System.Collections.Generic.List(Of String)

                If billTyp = eBillTyp.Rechnung Or billTyp = eBillTyp.FreieRechnung Then
                    For Each rCalcDocu As DataRow In arrCalcDocu
                        If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.KennungColumn.ColumnName) = eTypProt.LZ.ToString() Then

                            'If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDKostInternBillColumn.ColumnName).ToString().Trim() = "" Then
                            '    sProt += "Fehler: Rechnung " + rBill.RechNr.Trim() + " Für LZ " + rCalcDocu("IDKostIntern").ToString() + " wurde kein interner Kostenträger gefunden! Bitte kontaktieren Sie S2-Engineering GmbH!" + vbNewLine
                            'End If

                            'Dim sWhereZahler As String = "IDKostIntern='" + rCalcDocu("IDKostIntern") + "' and " + "IDLeistung='" + rCalcDocu("IDLeistung") + "'"
                            'Dim arrZahler() As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.Zahler.TableName).Select(sWhereZahler, "")
                            'If arrZahler.Length <> 1 Then
                            '    Throw New Exception("doExportCalcDb: arrZahler.Length <> 1 for IDKostInten " + rCalcDocu("IDKostIntern").ToString() + "!")
                            'End If

                            Dim lineExport1 As New lineExport()
                            'Dim BruttoBetrag As Decimal = 0
                            'Dim NettoBetrag As Decimal = 0
                            'Dim MwStBetrag As Decimal = 0
                            'For Each rZahler As DataRow In arrZahler
                            '    NettoBetrag += rZahler("NettoBetragProLeistung")
                            '    MwStBetrag += rZahler("MWStProLeistung")
                            '    BruttoBetrag += rZahler("NettoBetragProLeistung") + rZahler("MWStProLeistung")
                            'Next
                            'lineExport1.expBetrag = Math.Round(BruttoBetrag, 2)
                            'lineExport1.expSteuer = Math.Round(MwStBetrag, 2)
                            lineExport1.expMwst = rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName)

                            Dim Mwst As Double = 0
                            If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) <> 0 Then
                                Mwst = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName) * (rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) / 100), 2)
                                lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName), 2) + Mwst
                            Else
                                lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName), 2)
                            End If
                            lineExport1.expSteuer = Mwst

                            lineExport1.FIBU = rCalcDocu(Me.dbCalcTemp.KostenKostenträger.FIBUColumn.ColumnName)

                            Dim arrKost() As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.Kostenträger.TableName).Select(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName + "='" + rCalcDocu(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName) + "'", "")
                            Dim rKost As DataRow = arrKost(0)
                            lineExport1.NameKost = rKost(Me.dbCalcTemp.Kostenträger.FamNameColumn.ColumnName)
                            lineExport1.FIBUKost = rKost(Me.dbCalcTemp.Kostenträger.FIBUColumn.ColumnName)
                            lineExport1.expSteuer *= -1

                            linesToExportAll.Add(lineExport1)
                            'If Not lstLinesExportFIBI.Contains(lineExport1.FIBU.Trim()) Then
                            '    lstLinesExportFIBI.Add(lineExport1.FIBU.Trim())
                            'End If

                            Dim bNoCheckSumme As Boolean = False
                            'Ausnahme für Bernstein, weil die erste Abrechnung noch falsch war. 
                            If rBill.RechNr.Trim().Equals(("AR-2018-00017")) Or rBill.RechNr.Trim().Equals(("ST-2018-00002")) Then
                                lineExport1.expBetrag = 0
                                lineExport1.expSteuer = 0
                                bNoCheckSumme = True
                            End If

                            Dim sWhere As String = "IDKostIntern='" + rKostenträgerCalc("IDKostIntern") + "' and " + "Kennung='" + eTypProt.Zahlungsbetrag.ToString() + "'"
                            Dim arrKostenKostenträger() As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.KostenKostenträger.TableName).Select(sWhere, "")
                            If arrKostenKostenträger.Length <> 1 Then
                                Throw New Exception("doExportCalcDb: arrKostenKostenträger.Length <> 1  for IDKostIntern '" + rKostenträgerCalc("IDKostIntern").Trim() + "'!")
                            End If

                            Dim rKostenKostenträger As DataRow = arrKostenKostenträger(0)
                            If rKostenKostenträger("Brutto") = 0 And (Not bNoCheckSumme) Then
                                'sProt += rBill.RechNr.Trim() + " - Brutto for bill = 0" + vbNewLine
                            End If
                            If Math.Round(rKostenKostenträger("Brutto"), 2) = lineExport1.expBetrag And (Not bNoCheckSumme) Then
                                'sProt += rBill.RechNr.Trim() + " - Brutto Export <> (Rech.Betrag+Rech.MwSt) = 0" + vbNewLine
                            End If
                        End If
                    Next

                ElseIf billTyp = eBillTyp.Sammelrechnung Then
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                        For Each rCalcDocu As DataRow In arrCalcDocu
                            If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.KennungColumn.ColumnName) = eTypProt.LZ.ToString() Then
                                Dim lineExport1 As New lineExport()
                                lineExport1.expMwst = rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName)

                                ' Orig. Beilage für SR-Position öffnen und aus Tabelle Zahler Kosten pro Leistung (tatsächl. Tage)
                                Dim bSRLZOK As Boolean = False
                                If rCalcDocu.Table.Columns.Contains(Me.dbCalcTemp.KostenKostenträger.IDBillColumn.ColumnName) Then
                                    Dim IDBillOrig As String = rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDBillColumn.ColumnName).ToString()
                                    Dim tBillOrig As List(Of cSelObj) = (From b In db.bills
                                                                         Join bh In db.billHeader On b.IDAbrechnung Equals bh.ID
                                                                         Where b.ID = IDBillOrig
                                                                         Select New cSelObj With {
                                                                                    .IDBill = New Guid(b.ID),
                                                                                    .RechNr = b.RechNr,
                                                                                    .db = bh.dbCalc
                                                                                 }).ToList()
                                    Dim rBillOrig As cSelObj = tBillOrig.First()

                                    Dim xmlStringReader As New System.IO.StringReader(rBillOrig.db)
                                    Dim xmlReader As New System.Xml.XmlTextReader(xmlStringReader)
                                    Dim dbCalcOrig As New DataSet()
                                    dbCalcOrig.ReadXml(xmlReader)

                                    Dim bDoOldVersion As Boolean = False
                                    Dim sWhereKostenträgerOrig As String = "IDKostintern='" + rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDKostInternBillColumn.ColumnName) + "'"
                                    Dim arrKostenträgerOrig() As DataRow = Nothing
                                    If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDKostInternBillColumn.ColumnName).ToString().Trim() = "" Then
                                        bDoOldVersion = True
                                        'sProt += "Fehler: Sammelrechnung " + rBill.RechNr.Trim() + " Für LZ " + rCalcDocu(Me.dbCalcTemp.KostenKostenträger.BezeichnungColumn.ColumnName).ToString() + " wurde kein interner Kostenträger gefunden! Bitte kontaktieren Sie S2-Engineering GmbH!" + vbNewLine
                                    Else
                                        arrKostenträgerOrig = dbCalcOrig.Tables(dbCalcOrig.Tables("Kostenträger").TableName).Select(sWhereKostenträgerOrig, "")
                                        If arrKostenträgerOrig.Length = 0 Then
                                            bDoOldVersion = True
                                        End If
                                    End If
                                    bDoOldVersion = True
                                    If bDoOldVersion Then
                                        'Throw New Exception("doExportCalcDb: arrKostenträgerOrig.Length <> 1 not allowed for IDIDKost '" + rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDKostColumn.ColumnName).ToString() + "'!")

                                        Dim Mwst As Double = 0
                                        If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) <> 0 Then
                                            Mwst = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName) * (rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) / 100), 2)
                                            lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName) + Mwst, 2)
                                        Else
                                            lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName), 2)
                                        End If
                                        lineExport1.expSteuer = Mwst

                                    Else
                                        Dim IDKostInternOrig As String = arrKostenträgerOrig(0)(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName).ToString()

                                        Dim sWhereLeistungenOrig As String = ""
                                        If (rCalcDocu(Me.dbCalcTemp.Leistungen.IDLeistungskatalogColumn.ColumnName).ToString().Trim() <> "") Then
                                            sWhereLeistungenOrig = "IDLeistungskatalog='" + rCalcDocu(Me.dbCalcTemp.Leistungen.IDLeistungskatalogColumn.ColumnName) + "'"
                                        ElseIf (rCalcDocu(Me.dbCalcTemp.Leistungen.IDSonderleistungColumn.ColumnName).ToString().Trim() <> "") Then
                                            sWhereLeistungenOrig = "IDSonderleistung='" + rCalcDocu(Me.dbCalcTemp.KostenKostenträger.IDSonderLeistungskatalogColumn.ColumnName) + "'"
                                        End If

                                        If sWhereLeistungenOrig.Trim() = "" Then
                                            Throw New Exception("sWhereLeistungenOrig='' not allowed for RechNr " + rBill.RechNr.Trim() + "not allowed!")
                                        End If

                                        Dim bZahlerFound As Boolean = False
                                        Dim arrLeistungenOrig() As DataRow = dbCalcOrig.Tables(dbCalcOrig.Tables("Leistungen").TableName).Select(sWhereLeistungenOrig, "")
                                        Dim expBetragOrig As Decimal = 0
                                        Dim expSteuerOrig As Decimal = 0
                                        For Each rLeistungenOrig As DataRow In arrLeistungenOrig
                                            Dim sWhereZahlerOrig As String = "IDLeistung='" + rLeistungenOrig(Me.dbCalcTemp.Leistungen.IDColumn.ColumnName) + "' and IDKostIntern ='" + IDKostInternOrig.Trim() + "'"
                                            Dim arrZahlerOrig() As DataRow = dbCalcOrig.Tables(dbCalcOrig.Tables("Zahler").TableName).Select(sWhereZahlerOrig, "")
                                            For Each rZahlerOrig As DataRow In arrZahlerOrig
                                                expBetragOrig += rZahlerOrig(Me.dbCalcTemp.Zahler.NettoBetragProLeistungColumn.ColumnName)
                                                expSteuerOrig += rZahlerOrig(Me.dbCalcTemp.Zahler.MWStProLeistungColumn.ColumnName)
                                                bZahlerFound = True
                                            Next
                                        Next
                                        lineExport1.expSteuer = Math.Round(expSteuerOrig, 2)
                                        lineExport1.expBetrag = Math.Round(expBetragOrig + lineExport1.expSteuer, 2)


                                        If Not bZahlerFound Then
                                            sProt += "Fehler: Sammelrechnung " + rBill.RechNr.Trim() + " bei Klient '" + rBill.KlientName + "' Für LZ " + rCalcDocu(Me.dbCalcTemp.KostenKostenträger.BezeichnungColumn.ColumnName).ToString() + " wurde kein Zahler gefunden! Bitte überprüfen Sie den Export!" + vbNewLine
                                        End If
                                    End If
                                Else
                                    Dim Mwst As Double = 0
                                    If rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) <> 0 Then
                                        Mwst = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName) * (rCalcDocu(Me.dbCalcTemp.KostenKostenträger.MWStColumn.ColumnName) / 100), 2)
                                        lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName) + Mwst, 2)
                                    Else
                                        lineExport1.expBetrag = Math.Round(rCalcDocu(Me.dbCalcTemp.KostenKostenträger.NettoColumn.ColumnName), 2)
                                    End If
                                    lineExport1.expSteuer = Mwst
                                End If

                                lineExport1.FIBU = rCalcDocu(Me.dbCalcTemp.KostenKostenträger.FIBUColumn.ColumnName)

                                Dim arrKost() As DataRow = dbCalcFound.Tables(Me.dbCalcTemp.Kostenträger.TableName).Select(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName + "='" + rCalcDocu(Me.dbCalcTemp.Kostenträger.IDKostInternColumn.ColumnName) + "'", "")
                                Dim rKost As DataRow = arrKost(0)
                                lineExport1.NameKost = rKost(Me.dbCalcTemp.Kostenträger.FamNameColumn.ColumnName)
                                lineExport1.FIBUKost = rKost(Me.dbCalcTemp.Kostenträger.FIBUColumn.ColumnName)

                                If billStatus = eBillStatus.storniert Then
                                    'lineExport1.expBetrag *= -1
                                    lineExport1.expSteuer *= -1
                                Else
                                    'lineExport1.expBetrag *= -1
                                    lineExport1.expSteuer *= -1
                                End If

                                linesToExportSRTmp.Add(lineExport1)
                                If Not lstSRFibuDistinct.Contains(lineExport1.FIBU.Trim()) Then
                                    lstSRFibuDistinct.Add(lineExport1.FIBU.Trim())
                                End If
                            End If
                        Next
                    End Using
                End If

                Dim sumBruttoSR As Double = 0
                Dim sumNettoSRMwSt As Double = 0
                If billTyp = eBillTyp.Sammelrechnung Then
                    Dim linesToExportTmpSR As New System.Collections.Generic.List(Of lineExport)
                    For Each sFIBUDistinct As String In lstSRFibuDistinct
                        For Each lineExportTmp As lineExport In linesToExportSRTmp
                            If sFIBUDistinct.Trim().Equals(lineExportTmp.FIBU.Trim()) And (Not lineExportTmp.bDone) Then
                                Dim lineExportFoundNew As lineExport = Nothing
                                For Each lineExportSR As lineExport In linesToExportTmpSR
                                    If lineExportSR.FIBU.Trim().Equals(lineExportTmp.FIBU.Trim()) And lineExportSR.expMwst.Equals(lineExportTmp.expMwst) Then
                                        lineExportFoundNew = lineExportSR
                                    End If
                                Next

                                If lineExportFoundNew Is Nothing Then
                                    lineExportFoundNew = New lineExport()
                                    lineExportFoundNew.expMwst += lineExportTmp.expMwst
                                    lineExportFoundNew.FIBU = lineExportTmp.FIBU.Trim()
                                    lineExportFoundNew.FIBUKost = lineExportTmp.FIBUKost.Trim()
                                    lineExportFoundNew.NameKost = lineExportTmp.NameKost.Trim()
                                    linesToExportTmpSR.Add(lineExportFoundNew)
                                End If

                                lineExportFoundNew.expBetrag += Math.Round(lineExportTmp.expBetrag, 2)
                                lineExportFoundNew.expSteuer += Math.Round(lineExportTmp.expSteuer, 2)

                                sumBruttoSR += lineExportFoundNew.expBetrag
                                sumNettoSRMwSt += lineExportFoundNew.expSteuer

                                lineExportTmp.bDone = True
                            End If
                        Next
                    Next

                    For Each lineExportSr As lineExport In linesToExportTmpSR
                        linesToExportAll.Add(lineExportSr)
                    Next
                End If

                If billTyp = eBillTyp.Sammelrechnung Then
                    'sProt += rBill.RechNr.Trim() + " - Sum Brutto SR = " + sumBruttoSR.ToString() + " (MwSt:" + (sumNettoSRMwSt * -1).ToString() + ")" + vbNewLine
                    SumBruttoSRAll += sumBruttoSR
                End If

                Dim NameKlient As String = ""
                If (billTyp = eBillTyp.Rechnung Or billTyp = eBillTyp.FreieRechnung) Then
                    NameKlient = rKlientCalc(Me.dbCalcTemp.Klient.NachnameColumn.ColumnName)
                    If rKlientCalc(Me.dbCalcTemp.Klient.VornameColumn.ColumnName).ToString().Trim() <> "" Then
                        NameKlient += " " + rKlientCalc(Me.dbCalcTemp.Klient.VornameColumn.ColumnName)
                    End If
                End If

                For Each lineToExport As lineExport In linesToExportAll
                    Dim rNewRowExport As dsExport.ExportBMDRow = Nothing
                    rNewRowExport = Me.addRowExport(dbCalcFound, dsExportResult,
                                                        rBillHeaderFound.ID.ToString, bereich, typRechNr,
                                                        nErrors,
                                                        rKlientCalc, monat, NameKlient,
                                                        lineToExport,
                                                        IDKost, IDKostIntern,
                                                        rBill)
                Next
                'countRowsTotalCopied += 1
                'Next
            End If

            'countDbTotalCopied += 1
            Return True

        Catch ex As Exception
            calcBase.doExept(ex)
        End Try
    End Function
    Public Function addRowExport(ByRef dbCalcFoundxy As DataSet, ByRef dsExportResult As dsExport,
                                 ByRef IDBillHeader As String,
                                 ByVal bereichxy As String, ByVal typRechNrxy As String,
                                 ByRef nErrors As Integer,
                                 ByRef rKlientCalcxy As DataRow, ByRef monat As DataRow,
                                 ByRef NameKlient As String,
                                 ByRef lineExport1 As lineExport,
                                 ByRef IDKost As String, ByRef IDKostIntern As String,
                                 rBill As PMDS.Calc.Logic.dbPMDS.billsRow) As dsExport.ExportBMDRow
        Try
            Me.dbPMDS.Clear()

            Dim rNewRowExport As dsExport.ExportBMDRow = Me.dbExport1.getNewRowExportBMD(dsExportResult, BMDExportTyp)
            rNewRowExport.IDBill = rBill.ID

            Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                Dim rB1 As cSelBillInfo = (From b In db.bills
                                           Where b.ID = rBill.ID
                                           Select New cSelBillInfo With {.IDBill = b.ID, .RechNr = b.RechNr, .ExportiertJN = b.ExportiertJN, .IDKost = b.IDKost, .IDKlinik = b.IDKlinik, .IDKlient = b.IDKlient}).FirstOrDefault()

                If Not IsNothing(rB1) Then
                    rNewRowExport.IDBill = rB1.IDBill
                    rNewRowExport.ExportiertJN = rB1.ExportiertJN

                    Dim IDKostBill As Guid = New Guid(rB1.IDKost)

                    Dim rK1 As cSelKostentraegerInfo
                    Dim rK1Sub As cSelKostentraegerInfo
                    Try
                        rK1 = (From k In db.Kostentraeger
                               Where k.ID = IDKostBill
                               Select New cSelKostentraegerInfo With {.IDKost = k.ID, .FiBuKost = k.FIBUKonto, .IDKostSub = k.IDKostentraegerSub}).FirstOrDefault()

                        If Not IsNothing(rK1) Then
                            rK1Sub = (From k In db.Kostentraeger
                                      Where k.ID = rK1.IDKostSub
                                      Select New cSelKostentraegerInfo With {.IDKost = k.ID, .FiBuKost = k.FIBUKonto}).FirstOrDefault()
                        End If
                    Catch ex As Exception
                        rK1 = (From k In db.Kostentraeger
                               Where k.ID = IDKostBill
                               Select New cSelKostentraegerInfo With {.IDKost = k.ID, .FiBuKost = k.FIBUKonto}).FirstOrDefault()
                    End Try

                    If Not IsNothing(rK1) Then
                        rNewRowExport.IDKost = rK1.IDKost
                        rNewRowExport.FiBuKost = rK1.FiBuKost
                        If Not IsNothing(rK1Sub) Then
                            rNewRowExport.IDKostSub = rK1Sub.IDKost
                            rNewRowExport.FiBuKostSub = rK1Sub.FiBuKost
                        End If
                    End If

                    Dim IDPatient As Guid = New Guid(rB1.IDKlient)
                    If BMDExportTyp = eBMDExportTyp.MZ Then     'interne Kostenstelle (Abteilung) des Klienten suchen
                        Dim AbteilungKostenstelle = (From a In db.Aufenthalt
                                                     Join abt In db.Abteilung On abt.ID Equals a.IDAbteilung
                                                     Join kon In db.Kontakt On kon.ID Equals abt.IDKontakt
                                                     Where a.IDPatient = IDPatient And abt.IDKlinik = rB1.IDKlinik
                                                     Order By a.Aufnahmezeitpunkt Descending
                                                     Select New With {.abtkost = kon.Zusatz3}).FirstOrDefault()

                        If Not IsNothing(AbteilungKostenstelle) Then
                            rNewRowExport.AbteilungCode = AbteilungKostenstelle.abtkost.ToString()
                        End If
                    End If
                End If
            End Using

            rNewRowExport.konto = lineExport1.FIBUKost.Trim()
            rNewRowExport.gkonto = lineExport1.FIBU.Trim()

            Dim StornoNr As String = ""
            Dim dbBillDB As PMDS.Calc.Logic.dbBill = Me.dbBill1.getDbBill(rBill.dbBill)
            Dim rField As PMDS.Calc.Logic.dbBill.fieldsRow = Me.dbBill1.getID(dbBillDB, PMDS.Calc.Logic.dbBill.idStornoRechNr)
            If (Not rField Is Nothing) Then
                StornoNr = rField.txt
            End If

            Dim calcBase1 As New calcBase()
            'Dim RechDat As Date = monat(Me.dbCalcTemp.Monate.RechDatumColumn.ColumnName)

            rNewRowExport.buchdatum = rBill.RechDatum.Date.ToString(calcBase1.dateFormat)
            rNewRowExport.prozent = lineExport1.expMwst

            rNewRowExport.belegnr = rBill.RechNr.Trim()
            rNewRowExport.TypBill = calcBase.getBillTypAsString(rBill.Typ)

            rNewRowExport.belegdatum = rBill.RechDatum.Date.ToString(calcBase1.dateFormat)

            rNewRowExport.buchcode = "1"
            rNewRowExport.betrag = lineExport1.expBetrag
            rNewRowExport.steuer = Math.Round(((lineExport1.expBetrag * -1) / (100 + lineExport1.expMwst)) * lineExport1.expMwst, 2, MidpointRounding.ToEven)

            'Maximal 18 Zeichen des Kostenträgers
            rNewRowExport.text = ("RE " + lineExport1.NameKost.Trim()).Substring(0, Math.Min(18, lineExport1.NameKost.Trim().Length + 3))

            rNewRowExport.zziel = "0"
            rNewRowExport.skontopz = "0"
            rNewRowExport.skontotage = "0"

            rNewRowExport.IDBillHeader = IDBillHeader
            rNewRowExport.IDKostIntern = IDKostIntern
            rNewRowExport.IDSR = ""

            rNewRowExport.steuercode = IIf(rNewRowExport.prozent > 0, 1, 0)

            If BMDExportTyp = eBMDExportTyp.MZ Then
                'MZ-spezifische Spalten sezen
                rNewRowExport.periode = rBill.RechDatum.Month().ToString()
                rNewRowExport.benutzer = "99"
                rNewRowExport.text = ("ZIVK-" + lineExport1.NameKost.Trim()).Substring(0, Math.Min(18, lineExport1.NameKost.Trim().Length + 5))

                If rNewRowExport.FiBuKostSub = Me.FSW_FibuKonto Then
                    'Umbuchung hinzufügen
                    Dim rUmbuchung As dsExport.ExportBMDRow = Me.dbExport1.getNewRowExportBMD(dsExportResult, BMDExportTyp)
                    rUmbuchung.Satzart = rNewRowExport.Satzart
                    rUmbuchung.konto = rNewRowExport.FiBuKostSub
                    rUmbuchung.buchdatum = rNewRowExport.buchdatum
                    rUmbuchung.belegnr = rNewRowExport.belegnr
                    rUmbuchung.periode = rNewRowExport.periode
                    rUmbuchung.belegdatum = rNewRowExport.belegdatum
                    rUmbuchung.buchsymbol = rNewRowExport.buchsymbol
                    rUmbuchung.gkonto = rNewRowExport.konto
                    rUmbuchung.buchcode = rNewRowExport.buchcode
                    rUmbuchung.betrag = rNewRowExport.betrag
                    rUmbuchung.prozent = 0
                    rUmbuchung.steuer = 0
                    rUmbuchung.text = ("FSW-" + lineExport1.NameKost.Trim()).Substring(0, Math.Min(18, lineExport1.NameKost.Trim().Length + 4))
                    rUmbuchung.benutzer = rNewRowExport.benutzer
                    rUmbuchung.steuercode = 0
                    rUmbuchung.AbteilungCode = ""
                    rUmbuchung.ExportiertJN = rNewRowExport.ExportiertJN
                End If
            End If

            Return rNewRowExport

        Catch ex As Exception
            calcBase.doExept(ex)
            Return Nothing
        End Try
    End Function

End Class
