


Public Class doBookmarks



    Public Function setBookmark2(ByVal fieldToFill As String, ByVal text As String, ByRef textControl As TXTextControl.TextControl) As TXTextControl.TextField
        Try
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl)
                Next
            End If
            For Each bMark As TXTextControl.TextField In textControl.TextFields
                Me.setBookmark(bMark, fieldToFill, text, textControl)
            Next

        Catch ex As Exception
            Throw New Exception("doBookmarks.setBookmark2: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function setBookmark(ByVal fieldToFill As String, ByVal text As String, ByRef textControl As TXTextControl.TextControl) As TXTextControl.TextField
        Try
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl)
                Next
            End If
            For Each bMark As TXTextControl.TextField In textControl.TextFields
                If Me.setBookmark(bMark, fieldToFill, text, textControl) Then Return bMark
            Next

            'If Not gen.IsNull(textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer)) Then
            '    For Each bMark As TXTextControl.TextField In textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
            '        If Me.setBookmark(bMark, fieldToFill, text, textControl) Then Return bMark
            '    Next
            'End If
            'If Not gen.IsNull(textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header)) Then
            '    For Each bMark As TXTextControl.TextField In textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFields
            '        If Me.setBookmark(bMark, fieldToFill, text, textControl) Then Return bMark
            '    Next
            'End If

        Catch ex As Exception
            Throw New Exception("doBookmarks.setBookmark: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Sub setBookmarks(ByVal r As DataRow, ByRef textControl As TXTextControl.TextControl)
        Try
            For Each bMark As TXTextControl.TextField In textControl.TextFields
                Me.setBookmark(bMark, r, textControl)
            Next
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
                    Me.setBookmark(bMark, r, textControl)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing Then
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFields
                    Me.setBookmark(bMark, r, textControl)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("doBookmarks.setBookmarks: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

    Public Function setBookmark(ByRef tField As TXTextControl.TextField, ByVal fieldToFill As String, ByVal text As String, ByRef textControl As TXTextControl.TextControl) As Boolean
        Try
            If tField.Name = "ActDate" Then
                tField.Text = Format(Now.Date, "dd.MM.yyyy")
                Return True
            End If
            If tField.Name = "CountPages" Then
                tField.Text = textControl.Pages
                Return True
            End If
            'If tField.Name = "[PageOf]" Then
            '    Dim hf As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header)
            '    'hf.Selection.Start = tField.Start
            '    'hf.Selection.Length = tField.Text.Length
            '    tField.Text = "Seite "
            '    Dim pnField As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            '    hf.PageNumberFields.Add(pnField)
            '    hf.Selection.Text = " "
            '    hf.Selection.Text = textControl.Pages.ToString()
            '    '     hf.TextFields.Add(New TextField() {Editable = False, Name = "PageCount", ShowActivated = False, Deleteable = True, Text = this.textControl.Pages.ToString()})
            'End If

            If UCase((tField.Name)) = Trim(UCase(fieldToFill)) Then
                tField.Text = text
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("doBookmarks.setBookmark: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Sub setBookmark(ByRef tField As TXTextControl.TextField, _
                 ByRef r As DataRow, ByRef textControl As TXTextControl.TextControl)
        Try
            Dim ret As New retCheckBookmark
            ret = Me.checkIfBookmarkExistisInRow(tField.Name, r)
            If ret.BookmarkOK Then
                If r(ret.Bookmark) Is System.DBNull.Value Then
                    tField.Text = ""
                Else
                    Select Case r(ret.Bookmark).GetType.Name
                        Case "String"
                            tField.Text = r(ret.Bookmark)
                        Case "DateTime"
                            tField.Text = Format(r(ret.Bookmark), "dd.MM.yyyy").ToString
                        Case "Boolean"
                            If r(ret.Bookmark) = True Then
                                tField.Text = "Ja"
                            Else
                                tField.Text = "Nein"
                            End If
                        Case "Double"
                            tField.Text = Format(r(ret.Bookmark), "###,###,##0.00").ToString
                        Case "Integer"
                            tField.Text = r(ret.Bookmark).ToString
                        Case Else
                            tField.Text = r(ret.Bookmark)
                    End Select
                End If
            Else
                tField.Text = "setBookmark: " + tField.Name + " - Bookmark not found in Database ..."
            End If
            If tField.Name = "ActDate" Then tField.Text = Format(Now.Date, "dd.MM.yyyy")
            If tField.Name = "CountPages" Then tField.Text = textControl.Pages

        Catch ex As Exception
            Throw New Exception("doBookmarks.setBookmark: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub
  
    Public Function checkIfBookmarkExistisInRow(ByVal bm As String, ByRef r As DataRow) As retCheckBookmark
        Try
            Dim ret As New retCheckBookmark

            For Each col As DataColumn In r.Table.Columns
                If UCase((col.ToString)) = Trim(UCase(bm)) Then
                    ret.BookmarkOK = True
                    ret.Bookmark = bm
                    Return ret
                End If
            Next
            Return ret

        Catch ex As Exception
            Throw New Exception("doBookmarks.checkIfBookmarkExistisInRow: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function setPageOf(ByRef textControl As TXTextControl.TextControl, ByVal HeaderFooter As TXTextControl.HeaderFooterType, _
                           ByVal alignment As TXTextControl.HorizontalAlignment, ByVal fontSize As Double) As TXTextControl.TextField
        Try
            Dim oPageNumber As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            textControl.HeadersAndFooters.Add(HeaderFooter)
            Dim oHeader As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(HeaderFooter)
            Dim startSel As Integer = oHeader.Selection.Start

            oHeader.Selection.Start = startSel
            oHeader.Selection.Length = oHeader.Selection.Text.Length
            oHeader.Selection.FontSize = fontSize * 20

            oHeader.Selection.Text = generic.getRes("Site") + " "
            oHeader.Selection.Start += 6
            oHeader.PageNumberFields.Add(oPageNumber)
            oHeader.Selection.Text = "/" + textControl.Pages.ToString()
            oHeader.Selection.ParagraphFormat.Alignment = alignment

        Catch ex As Exception
            Throw New Exception("doBookmarks.setPageOf: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function


    Public Function insertPageBreakBeforeTable(ByRef textControl As TXTextControl.TextControl, tableNr As Integer) As TXTextControl.TextField
        Try
            Dim doEditor As New doEditor()
            Dim doFormat As New doFormat()
            Dim table As TXTextControl.Table = Me.getTable(textControl, tableNr)
            textControl.Selection.Start = table.Cells.GetItem(1, 1).Start - 1
            textControl.Selection.Length = 1
            doEditor.insertPagebreak(textControl)

        Catch ex As Exception
            Throw New Exception("doBookmarks.insertPageBreakBeforeTable: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function getTable(ByRef textControl As TXTextControl.TextControl, tableNr As Integer) As TXTextControl.Table
        Try
            Dim tActiv As TXTextControl.Table
            Dim anz As Integer = 0
            Dim found As Boolean = False

            For Each t As TXTextControl.Table In textControl.Tables
                If anz = tableNr Then
                    tActiv = t
                    found = True
                End If
                If found Then
                    Exit For
                End If
                anz += 1
            Next
            If tActiv Is Nothing Then
                Throw New Exception("doBookmarks.getTable: TableNr not found in TXTextControl!")
            End If
            Return tActiv

        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try
    End Function

End Class
