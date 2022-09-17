

Public Class doFormat


    Public Class retRowDrawed
        Public tableTxtControl As TXTextControl.Table = Nothing
        Public tableNr As Integer = -1
        Public rowNr As Integer = -1
        Public rowSelectionStart As Integer = -1
        Public FldSHort As String = ""
    End Class





    Public Function addRowToTable(ByRef formatAttr As formatAttr, ByRef textControl As TXTextControl.TextControl, addFieldAdVar As Boolean,
                                  Optional IDVar As Nullable(Of Guid) = Nothing, Optional colBezForIDVar As String = "", Optional TypeVar As Object = Nothing) As retRowDrawed
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

            Dim rowNr As Integer = Me.newRowToTable(formatAttr.tableNr, textControl, tActiv)
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
                                If Not TypeVar Is Nothing Then
                                    col.asField = "col_" + col.name.Trim() + "_" + TypeVar.ToString() + "_" + IDVar.ToString()
                                Else
                                    col.asField = "col_" + col.name.Trim() + "_" + IDVar.ToString()
                                End If
                            End If
                        Else
                            If IDVar Is Nothing Then
                                IDVar = System.Guid.NewGuid()
                            End If
                            If col.name.Trim() <> "" Then
                                If Not TypeVar Is Nothing Then
                                    col.asField = "col_" + col.name.Trim() + "_" + TypeVar.ToString() + "_" + IDVar.ToString()
                                Else
                                    col.asField = "col_" + col.name.Trim() + "_" + IDVar.ToString()
                                End If
                            Else
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

            Me.formatRow(formatAttr, rowNr, textControl, tActiv)
            Return retRowDrawed1

        Catch ex As Exception
            Throw New Exception("doFormat.addRowToTable: " + vbNewLine + vbNewLine + ex.ToString())
            Return Nothing
        End Try
    End Function
    Public Sub removeTable(ByRef nr As Integer, ByRef textControl As TXTextControl.TextControl)

        Dim anz As Integer = 0
        For Each t As TXTextControl.Table In textControl.Tables
            If anz = nr Then
                textControl.Selection.Start = t.Cells.GetItem(t.Rows.Count, 1).Start
                textControl.Selection.Length = 0
                textControl.Tables.Remove()
                Exit Sub
            End If
            anz += 1
        Next

    End Sub
    Public Function removeRowFromTable(ByRef retRowDrawed1 As retRowDrawed, ByRef textControl As TXTextControl.TextControl) As Boolean
        Try
            retRowDrawed1.tableTxtControl.Rows.GetItem(retRowDrawed1.rowNr).Select()
            textControl.Selection.Start = retRowDrawed1.rowSelectionStart
            textControl.Selection.Length = 0
            retRowDrawed1.tableTxtControl.Rows.Remove()

            Return True

        Catch ex As Exception
            Throw New Exception("doFormat.removeRowFromTable: " + vbNewLine + vbNewLine + ex.ToString())
            Return Nothing
        End Try
    End Function

    Public Function newRowToTable(ByVal tableNr As Integer, ByRef textControl As TXTextControl.TextControl, ByRef t As TXTextControl.Table) As Integer

        If t.Rows.Count < 1 Then Throw New Exception("newRowToTable: table has no row in Templatesheet!")
        textControl.Selection.Start = t.Cells.GetItem(t.Rows.Count, 1).Start
        textControl.Selection.Length = 0        't.Cells.GetItem(t.Rows.Count, t.Columns.Count).Length
        'bill.uiBill.editor.textControl1.Tables.GetItem(0).Cells.GetItem(row, 1).Select()
        't.Rows.GetItem(t.Rows.Count).Select()
        Dim res As Boolean = t.Rows.Add(TXTextControl.TableAddPosition.After, 1)
        Return t.Rows.Count
    End Function

    Public Sub formatRow(ByRef formatAttr As formatAttr, ByVal row As Integer, ByRef textControl As TXTextControl.TextControl,
                          ByRef t As TXTextControl.Table)
        Try

            'Dim rxy As TXTextControl.TableRow = t.Rows.GetItem(row)
            For i As Integer = 1 To t.Columns.Count
                t.Cells.GetItem(row, i).CellFormat = formatAttr.cellFormat
                Dim rCell As TXTextControl.TableCell = t.Cells.GetItem(row, i)
                rCell.Select()
                textControl.Selection.Bold = formatAttr.rowTextIsBold
                textControl.Selection.Italic = formatAttr.rowTextIsItalic
            Next

            textControl.Selection.Start = t.Cells.GetItem(t.Rows.Count, 1).Start
            textControl.Selection.Length = 0
            t.Rows.GetItem(t.Rows.Count).CellFormat.BackColor = Drawing.Color.White

        Catch ex As Exception
            Throw New Exception("doFormat.formatRow: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

End Class
