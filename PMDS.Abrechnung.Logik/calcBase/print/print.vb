Option Strict Off
Option Explicit On
Imports QS2.Desktop.Txteditor
Imports QS2.Desktop.Txteditor.doFormat
Imports VB = Microsoft.VisualBasic




Public Class print
    Inherits calcBase


    Public Shared printTempStream As String = ""
    Public Shared reportPath As String = ""

    Public Shared pwd As String = "pmds1234"

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public doFormat As New QS2.Desktop.Txteditor.doFormat()
    Public doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()

    Public _editorTmp As TXTextControl.TextControl = Nothing





    Public Sub loadTempStream(ByVal file As String, Optional IsDepotgeld As Boolean = False, Optional IsJahresabschluss As Boolean = False)
        Try
            Dim retMainSystem1 As New calculation.retMainSystem()
            Dim bOK As Boolean = calculation.delCallFctMainSystem(calculation.eTypeMainFct.getIDKlinik, retMainSystem1)

            Dim fileTmp As String = file
            Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                Dim tKlinik As IQueryable(Of PMDS.db.Entities.Klinik) = From o In db.Klinik Where o.ID = retMainSystem1.ID.Value
                Dim rKlinik As PMDS.db.Entities.Klinik = tKlinik.First()
                If Not IsJahresabschluss Then
                    If Not IsDepotgeld Then
                        If rKlinik.Rechnungsformular.Trim() <> "" Then
                            fileTmp = rKlinik.Rechnungsformular.Trim()
                        End If
                    Else
                        If rKlinik.RechnungsformularDepot.Trim() <> "" Then
                            fileTmp = rKlinik.RechnungsformularDepot.Trim()
                        End If
                    End If
                End If
            End Using

            Dim fileBill As String = print.reportPath + "\" + fileTmp
            Dim strResult As String = ""

            If Not System.IO.File.Exists(fileBill) Then Throw New Exception("loadTempStream: RTF-Vorlage existiert nicht!")

            Dim srFile As New System.IO.StreamReader(fileBill)
            print.printTempStream = srFile.ReadToEnd()
            srFile.Close()

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub loadTempStreamToEditor(ByRef editor As TXTextControl.TextControl)
        Try
            bill.lfdNr = 0
            editor.Text = ""
            doEditor.showText(print.printTempStream, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editor)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub addCollumn(IDVar As Nullable(Of Guid), ByRef formatAttr As QS2.Desktop.Txteditor.formatAttr, ByRef editor As TXTextControl.TextControl,
             Optional ByVal lineTop As Boolean = False, Optional ByVal TextBold As Boolean = False, Optional TypProt As Nullable(Of eTypProt) = Nothing)
        Try
            If lineTop Then
                formatAttr.cellFormat.TopBorderWidth = 7
            Else
                formatAttr.cellFormat.TopBorderWidth = 0
            End If
            formatAttr.rowTextIsBold = TextBold

            For Each col As tableColumn In formatAttr.columns
                col.asField = ""
            Next
            doFormat.addRowToTable(formatAttr, editor, True, IDVar, "Bezeichnung", TypProt)
            'Me.addRowToTableTest(formatAttr, editor, True, IDVar, "Bezeichnung")

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function addRowToTableTest(ByRef formatAttr As formatAttr, ByRef textControl As TXTextControl.TextControl, addFieldAdVar As Boolean,
                                  Optional IDVar As Nullable(Of Guid) = Nothing, Optional colBezForIDVar As String = "") As retRowDrawed
        Try
            Dim retRowDrawed1 As New retRowDrawed()

            Dim tActiv As TXTextControl.Table
            Dim anz As Integer = 0
            Dim found As Boolean = False

            For Each t As TXTextControl.Table In textControl.Tables
                If anz = formatAttr.tableNr Then
                    tActiv = t
                    found = True
                End If
                If found Then Exit For
                anz += 1
            Next
            If tActiv Is Nothing Then
                Throw New Exception("doFormat.addRowToTable: TableNr not found in TXTextControl")
            End If

            Dim rowNr As Integer = doFormat.newRowToTable(formatAttr.tableNr, textControl, tActiv)
            retRowDrawed1.tableTxtControl = tActiv
            retRowDrawed1.tableNr = formatAttr.tableNr
            retRowDrawed1.rowNr = rowNr
            'rowNr = 1

            For Each col As tableColumn In formatAttr.columns
                If Not col.print Then Continue For
                Dim type As String = col.value.GetType.ToString()

                Dim fld As TXTextControl.TextField
                Dim asField As Boolean = False

                If addFieldAdVar Then
                    If col.asField = "" Then
                        If colBezForIDVar.Trim() <> "" AndAlso colBezForIDVar.Trim().ToLower().Equals(col.name.Trim().ToLower()) Then
                            If IDVar Is Nothing Then
                                IDVar = System.Guid.NewGuid()
                                col.asField = "auto_" + col.name.Trim() + "_" + IDVar.ToString()
                            Else
                                col.asField = "col_" + col.name.Trim() + "_" + IDVar.ToString()
                            End If
                        Else
                            IDVar = System.Guid.NewGuid()
                            If col.name.Trim() <> "" Then
                                col.asField = "auto_" + col.name.Trim() + "_" + IDVar.ToString()
                            Else
                                IDVar = System.Guid.NewGuid()
                                col.asField = "auto_" + IDVar.ToString()
                            End If
                        End If
                    End If

                    If col.asField <> "" Then
                        tActiv.Cells.GetItem(rowNr, col.nr + 1).Text = " "

                        textControl.Selection.Start = tActiv.Cells.GetItem(rowNr, col.nr + 1).Start - 1
                        textControl.Selection.Length = 0
                        retRowDrawed1.rowSelectionStart = textControl.Selection.Start
                        fld = New TXTextControl.TextField()
                        fld.Name = col.asField
                        Dim res As Boolean = textControl.TextFields.Add(fld)
                        asField = True
                        'txtControl.Selection.Start = Field.Start - 1
                        'txtControl.Selection.Length = Field.Length
                    End If
                End If

                Select Case type
                    Case "System.String"
                        If asField Then
                            fld.Text = col.value
                        Else
                            tActiv.Cells.GetItem(rowNr, col.nr + 1).Text = col.value
                        End If

                    Case "System.Int32"
                        If (col.value <> 0 And Not col.printNull) Or col.printNull Then
                            If asField Then
                                fld.Text = col.value.ToString()
                            Else
                                tActiv.Cells.GetItem(rowNr, col.nr + 1).Text = col.value.ToString() 'If col.value <> 0 Then 
                            End If
                        End If

                    Case "System.Decimal", "System.Double"
                        If (col.value <> 0 And Not col.printNull) Or col.printNull Then
                            If asField Then
                                fld.Text = String.Format("{0:c}", col.value)
                            Else
                                tActiv.Cells.GetItem(rowNr, col.nr + 1).Text = String.Format("{0:c}", col.value)
                            End If
                        End If

                    Case Else
                        Throw New Exception("doFormat.add: Typ not found to add columns-Value")
                End Select

            Next

            doFormat.formatRow(formatAttr, rowNr, textControl, tActiv)
            Return retRowDrawed1

        Catch ex As Exception
            Throw New Exception("doFormat.addRowToTable: " + vbNewLine + vbNewLine + ex.ToString())
            Return Nothing
        End Try
    End Function

    Public Sub removeTable(ByRef Nr As Integer, ByRef editor As TXTextControl.TextControl)
        Try
            doFormat.removeTable(Nr, editor)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub doAutoSiteNummbering(ByRef editor As TXTextControl.TextControl)
        Try
            'Me.doBookmarks.setPageOf(editor, TXTextControl.HeaderFooterType.Footer, TXTextControl.HorizontalAlignment.Right, 7.5)
            Me.setPageOf(editor, TXTextControl.HeaderFooterType.Footer, TXTextControl.HorizontalAlignment.Right, 7.5)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function setPageOf(ByRef textControl As TXTextControl.TextControl, ByVal HeaderFooter As TXTextControl.HeaderFooterType,
                           ByVal alignment As TXTextControl.HorizontalAlignment, ByVal fontSize As Double) As TXTextControl.TextField
        Try
            Dim oPageNumber As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            textControl.HeadersAndFooters.Add(HeaderFooter)
            Dim oHeader As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(HeaderFooter)

            Dim sSitenumber As String = "[Pagenumber]"
            If oHeader.Selection.Text.Trim().ToLower().Contains((sSitenumber).Trim().ToLower()) Then
                Dim iPosVar As Integer = 0
                While iPosVar <> -1
                    iPosVar = oHeader.Find(sSitenumber.Trim(), iPosVar, TXTextControl.FindOptions.NoMessageBox)
                    If iPosVar <> -1 Then
                        oHeader.Selection.Start = iPosVar
                        oHeader.Selection.Length = sSitenumber.Trim().Length
                        oHeader.Selection.Text = ("Seite" + " " + "/" + textControl.Pages.ToString()).Trim()
                        oHeader.Selection.Start = iPosVar + 6
                        oHeader.PageNumberFields.Add(oPageNumber)
                    End If
                End While
            Else
                Dim startSel As Integer = oHeader.Selection.Start
                oHeader.Selection.Start = startSel
                oHeader.Selection.Length = oHeader.Selection.Text.Length
                oHeader.Selection.FontSize = fontSize * 20

                oHeader.Selection.Text = "Seite" + " "
                oHeader.Selection.Start += 6
                oHeader.PageNumberFields.Add(oPageNumber)
                oHeader.Selection.Text = "/" + textControl.Pages.ToString()
                oHeader.Selection.ParagraphFormat.Alignment = alignment
            End If

        Catch ex As Exception
            Throw New Exception("doBookmarks.setPageOf: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function clearSiteNumbering(ByRef textControl As TXTextControl.TextControl, ByVal HeaderFooter As TXTextControl.HeaderFooterType,
                                        ByVal alignment As TXTextControl.HorizontalAlignment, ByVal fontSize As Double) As TXTextControl.TextField
        Try
            Dim oPageNumber As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            textControl.HeadersAndFooters.Add(HeaderFooter)
            Dim oHeader As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(HeaderFooter)

            Dim sSitenumber As String = "[Pagenumber]"
            If oHeader.Selection.Text.Trim().ToLower().Contains(("Seite").Trim().ToLower()) Then
                Dim iPosVar As Integer = 0
                While iPosVar <> -1
                    iPosVar = oHeader.Find(("Seite").Trim(), iPosVar, TXTextControl.FindOptions.NoMessageBox)
                    If iPosVar <> -1 Then
                        oHeader.Selection.Start = iPosVar
                        oHeader.Selection.Length = 60
                        oHeader.Selection.Text = ""
                    End If
                End While
            End If

        Catch ex As Exception
            Throw New Exception("doBookmarks.setPageOf: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function open(ByVal stream As String, ByVal typ As QS2.Desktop.Txteditor.etyp,
                         Optional editorTmp As TXTextControl.TextControl = Nothing, Optional IDBill As String = "") As frmPrint
        Try
            If IDBill.Trim() <> "" Then
                Dim dOnSaveDocu As New QS2.Desktop.Txteditor.contTxtEditor.onSaveDocu(AddressOf Me.saveDocu)
                Me._editorTmp = editorTmp

                Dim frmPrint As New frmPrint()
                frmPrint.initControl()
                frmPrint.ucprint.editor.clearForm()
                frmPrint.ucprint.editor.FileNew(False, False)
                frmPrint.ucprint.editor.setControlTyp()
                frmPrint.ucprint.editor.textControl1.ViewMode = TXTextControl.ViewMode.PageView
                frmPrint.ucprint.editor.delOnSaveDocu = dOnSaveDocu
                frmPrint.ucprint.editor.IDDocu = New Guid(IDBill)
                frmPrint.ucprint.editor.TypDocu = ""
                frmPrint.ucprint.editor.showUISaveDocuToDB(True)
                frmPrint.Show()
                If stream <> "" Then frmPrint.ucprint.editor.showText(stream, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView)
                Return frmPrint
            Else
                Dim frmPrint As New frmPrint()
                frmPrint.initControl()
                frmPrint.ucprint.editor.clearForm()
                frmPrint.ucprint.editor.FileNew(False, False)
                frmPrint.ucprint.editor.setControlTyp()
                frmPrint.ucprint.editor.textControl1.ViewMode = TXTextControl.ViewMode.PageView
                frmPrint.Show()
                If stream <> "" Then frmPrint.ucprint.editor.showText(stream, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView)
                Return frmPrint
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveDocu(ByRef IDBill As System.Guid,
                                ByRef binInt() As Byte, ByRef binExport() As Byte,
                                ByRef typExport As String) As Boolean
        Try
            Dim IDBillStr As String = IDBill.ToString()

            Dim bPdf() As Byte = Nothing
            Me.doEditor.showText("", TXTextControl.StreamType.InternalFormat, False, TXTextControl.ViewMode.PageView, Me._editorTmp, binInt, bPdf)

            Using db As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                Dim tBill As IQueryable(Of PMDS.db.Entities.bills) = From o In db.bills Where o.ID = IDBillStr
                Dim rBill As PMDS.db.Entities.bills = tBill.First()
                Dim txtRtf As String = Me.doEditor.getText(TXTextControl.StringStreamType.RichTextFormat, Me._editorTmp)
                rBill.Rechnung = txtRtf
                db.SaveChanges()

                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Dokument wurde gespeichert!", MsgBoxStyle.Information, "")
            End Using
            Dim retMainSystem1 As New calculation.retMainSystem()
            calculation.delCallFctCalcs.Invoke(calculation.eTypeCalcsFct.loadCalcs, retMainSystem1)
            Return True


            'Dim sql1 As New Sql()
            'Dim txtRtf As String = Me.doEditor.getText(TXTextControl.StringStreamType.RichTextFormat, Me._editorTmp)
            'sql1.updateBillRechnung(IDBillStr, txtRtf)

        Catch ex As Exception
            Throw New Exception("print.saveDocu: " + ex.ToString())
        End Try
    End Function

    Public Sub openTemp(ByVal file As String, ByVal pwdJN As Boolean)
        Try
            Dim pwdOK As Boolean = True
            If pwdJN Then
                pwdOK = Me.checkPwd()
            End If

            If pwdOK Then
                Dim frmPrint As frmPrint = Me.open("", QS2.Desktop.Txteditor.etyp.all)
                Dim rech As String = print.reportPath + "\" + file
                If System.IO.File.Exists(rech) Then
                    frmPrint.ucprint.editor.showFile(rech, False, TXTextControl.StreamType.RichTextFormat, TXTextControl.ViewMode.PageView, False)
                    'frmBill.bill.editor.speichernAls(True)
                    'frmBill.bill.editor.ExportPDF("C:\" + System.Guid.NewGuid.ToString() + ".pdf", True, True)
                Else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Vorlage '" + rech + "' existiert nicht!", MsgBoxStyle.Information, "Vorlage öffnen")
                End If
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function checkPwd() As Boolean
        Try
            Dim inputKey As New QS2.Desktop.Txteditor.InputBox("Passworteingabe")
            Dim pwd As String = ""
            If QS2.Desktop.Txteditor.InputBox.ShowInputBox("Geben Sie bitte das Passwort ein:", pwd) Then
                If pwd = print.pwd Then
                    Return True
                Else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Das Passwort ist falsch!", MsgBoxStyle.Information, "Passwort überprüfen")
                End If
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Sub printSites(ByVal listSites As System.Collections.Generic.List(Of dbPMDS.billsRow), ByVal editor As TXTextControl.TextControl,
                          ByVal title As String, ByVal parent As Object, ByVal selRow As Object, ByVal typ As eModify,
                          Optional editorTmp As TXTextControl.TextControl = Nothing, Optional IDBillStr As String = "", Optional IsDepot As Boolean = False)
        Try
            Dim frmPrint As frmPrint = Me.open("", QS2.Desktop.Txteditor.etyp.calc, editorTmp, IDBillStr)
            frmPrint.Text = "PMDS - Text wird geladen ..."
            Dim anz As Integer = 1
            For Each rBill As dbPMDS.billsRow In listSites
                Me.doEditor.showText(rBill.Rechnung, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, editor)

                Select Case typ
                    Case eModify.openBillRechStor
                        Me.doBookmarks.setBookmark("[StornoNr]", "", editor)
                        Me.doBookmarks.setBookmark("[RechTitel]", "", editor)
                    Case eModify.openBillRechStorStorno
                        Me.doBookmarks.setBookmark("[RechNr]", "", editor)
                        Me.doBookmarks.setBookmark("[RechTitel]", "", editor)
                        Me.doBookmarks.setBookmark("[ZahlBetragBez]", "Stornobetrag", editor)
                End Select

                If anz > 1 Then
                    Me.doEditor.insertPagebreak(frmPrint.ucprint.editor.textControl1)
                Else

                End If
                Me.doEditor.appendText(Me.doEditor.getText(TXTextControl.StringStreamType.RichTextFormat, editor), frmPrint.ucprint.editor.textControl1)
                anz += 1
                Application.DoEvents()
            Next

            If typ <> eModify.nichts Then
                Me.doAutoSiteNummbering(frmPrint.ucprint.editor.textControl1)
            End If
            If IsDepot Then
                Me.clearSiteNumbering(frmPrint.ucprint.editor.textControl1, TXTextControl.HeaderFooterType.Footer, TXTextControl.HorizontalAlignment.Right, 7.5)
            End If

            If Not parent Is Nothing Then frmPrint.ucprint.editor.setForSaveDB(parent, selRow)
            frmPrint.Text = title

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub




    Public Function getKlientenSql(ByVal selectRun As String) As dbPMDS.helpRow()
        Try
            Dim dtHelpKlient As New dbPMDS.helpDataTable()
            Dim qryIDKlient As dbQuery = sql.run(selectRun, Nothing)
            Dim dbPMDS As New dbPMDS()
            For Each rKlient As DataRow In qryIDKlient.table.Rows
                Dim rNew As dbPMDS.helpRow = dtHelpKlient.NewRow()
                rNew.ID = VB.LCase(rKlient("IDPatient").ToString())
                Try
                    sql.readKlient(rNew.ID, dbPMDS, True)
                    Dim rKlientDat As dbPMDS.PatientRow = dbPMDS.Patient.Rows(0)
                    rNew.Name = rKlientDat.Nachname + " " + rKlientDat.Vorname
                Catch ex As Exception
                    rNew.Name = rNew.ID
                End Try
                dtHelpKlient.Rows.Add(rNew)
            Next

            Return dtHelpKlient.Select("", "Name asc")

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getKostSql(ByVal selectRun As String) As dbPMDS.helpRow()
        Try
            Dim dtHelpKost As New dbPMDS.helpDataTable()
            Dim qryIDKost As dbQuery = sql.run(selectRun, Nothing)
            Dim dbPMDS As New dbPMDS()
            For Each rKost As DataRow In qryIDKost.table.Rows
                Dim rNew As dbPMDS.helpRow = dtHelpKost.NewRow()
                rNew.ID = VB.LCase(rKost("IDKostenträger").ToString())
                Try
                    If rNew.ID <> kostenträger.IDKostKlient Then
                        sql.readKostenräger(rNew.ID, dbPMDS, True)
                        Dim rKostDat As dbPMDS.KostentraegerRow = dbPMDS.Kostentraeger.Rows(0)
                        rNew.Name = rKostDat.Name + If(rKostDat.Vorname <> "", ", " + rKostDat.Vorname, "")
                    Else
                        rNew.Name = "Klient ist Kostenträger"
                    End If
                Catch ex As Exception
                    rNew.Name = rNew.ID
                End Try
                dtHelpKost.Rows.Add(rNew)
            Next

            Return dtHelpKost.Select("", "Name asc")

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


End Class
