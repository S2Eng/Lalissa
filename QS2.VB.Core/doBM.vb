


Public Class doBM



    Public Function setBookmark2(ByVal fieldToFill As String, ByVal text As String, ByRef textControl As TXTextControl.TextControl, _
                                 IDApplication As String, IDParticipant As String, ByRef SiteNumberingDone As Boolean) As TXTextControl.TextField
        Try
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each tab As TXTextControl.Table In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Tables

                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenFooter) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenFooter).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each tab As TXTextControl.Table In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenFooter).Tables

                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenFooter).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each tab As TXTextControl.Table In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Tables

                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If



            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.All) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.All).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.All).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If
            If Not textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenHeader) Is Nothing Then
                For Each fr As TXTextControl.TextFrame In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenHeader).TextFrames
                    For Each bMark As TXTextControl.TextField In fr.TextFields
                        Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                    Next
                Next
                For Each bMark As TXTextControl.TextField In textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.EvenHeader).TextFields
                    Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                Next
            End If


            For Each sect As TXTextControl.Section In textControl.Sections
                Dim str As String = ""
            Next
            For Each bMark As TXTextControl.TextField In textControl.TextFields
                Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
            Next
            For Each obj As Object In textControl.Frames
                If obj.GetType().Name.Trim().ToLower().Equals(("TextFrame").Trim().ToLower()) Then
                    Dim fr As TXTextControl.TextFrame = obj
                    If Not fr.TextFields Is Nothing Then
                        For Each bMark As TXTextControl.TextField In fr.TextFields
                            Me.setBookmark(bMark, fieldToFill, text, textControl, SiteNumberingDone)
                        Next
                    End If

                ElseIf obj.GetType().Name.Trim().ToLower().Equals(("Image").Trim().ToLower()) Then
                    'Dim img As TXTextControl.Image = obj
                    'Dim NameImg As String = img.Name
                    'Dim picFound As System.Drawing.Image = Nothing
                    'If Me.getPictureFromRes("AKHStaySheetLogo", IDParticipant, IDApplication, picFound) Then
                    '    'Dim p As TXTextControl.Paragraph = textControl.Paragraphs.Item(5)
                    '    'textControl.Images.Add(picFound, TXTextControl.HorizontalAlignment.Left, p.Start - 1, TXTextControl.ImageInsertionMode.DisplaceText)
                    '    'Me.InsertTxtControlImageFromMemory(picFound, False, textControl)
                    '    Dim str As String = ""
                    'End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doBM.setBookmark2: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function getPictureFromRes(IDRes As String, IDParticipant As String, IDApplication As String, ByRef picToSet As System.Drawing.Image) As Boolean
        Try
            'AKHStaySheetFooter
            'AKHStaySheetLogo
            'KAVStaySheetLogo

            Dim rResSel As qs2.core.language.dsLanguage.RessourcenRow = qs2.core.language.sqlLanguage.getResRow(IDRes, Enums.eResourceType.PictureEnabled, IDParticipant, IDApplication)
            If Not rResSel Is Nothing Then
                If Not rResSel.IsfileBytesNull() Then
                    Dim stream As System.IO.MemoryStream
                    stream = New System.IO.MemoryStream(rResSel.fileBytes)
                    picToSet = System.Drawing.Image.FromStream(stream)
                    Return True
                End If
            End If
            Return False

        Catch ex As Exception
            Throw New Exception("doBM.getPictureFromRes: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Private Sub InsertTxtControlImageFromMemory(ByVal image As System.Drawing.Image, ByVal AsFixedImage As Boolean, ByVal tx As TXTextControl.TextControl)
        Try
            Dim stream As New System.IO.MemoryStream
            Dim buffer() As Byte
            Dim RTFString As String
            Dim ImageString As New System.Text.StringBuilder

            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            buffer = stream.ToArray()

            For Each nbyte As Byte In buffer
                ImageString.Append(nbyte.ToString("x2"))
            Next

            RTFString = "{\rtf1" + vbCr

            If AsFixedImage = True Then
                RTFString += "{\shp{\*\shpinst\shpfhdr0\shpbxcolumn\shpbypara\shpwr2\shpwrk0\shpfblwtxt0\shplid1025{\sp{\sn shapeType}{\sv 75}}{\sp{\sn dxWrapDistLeft}{\sv 0}}{\sp{\sn dxWrapDistRight}{\sv 0}}{\sp{\sn pib}{\sv "
            End If

            RTFString += "{\pict\jpegblip\picscalex100\picscaley100" + vbCr
            RTFString += ImageString.ToString()
            RTFString += "}}"

            If AsFixedImage = True Then RTFString += "\par}"

            tx.Selection.Load(RTFString, TXTextControl.StringStreamType.RichTextFormat)

        Catch ex As Exception
            Throw New Exception("doBM.InsertTxtControlImageFromMemory: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function setBookmark(ByRef tField As TXTextControl.TextField, ByVal fieldToFill As String, ByVal text As String, _
                                ByRef textControl As TXTextControl.TextControl, ByRef SiteNumberingDone As Boolean) As Boolean
        Try
            'If tField.Name = "[ActDate]" Then
            '    tField.Text = Format(Now.Date, "dd.MM.yyyy")
            '    Return True
            'End If
            'If tField.Name = "[CP]" Then
            '    tField.Text = textControl.Pages
            '    tField.Text = ""
            '    Return True
            'End If
            'If tField.Name = "[PNr]" Then
            '    'If Not SiteNumberingDone Then
            '    tField.Text = textControl.Pages.ToString()
            '    'SiteNumberingDone = True

            '    'Dim oPageNumber As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            '    'textControl.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Footer)
            '    'Dim oHeader As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer)
            '    'Dim startSel As Integer = oHeader.Selection.Start

            '    'oHeader.Selection.Start = tField.Start - 1
            '    'oHeader.Selection.Length = tField.Length
            '    ''oHeader.Selection.FontSize = 7.5 * 20

            '    'oHeader.Selection.Text = qs2.core.language.sqlLanguage.getRes("Site")
            '    'oHeader.Selection.Start += 6
            '    ''oHeader.PageNumberFields.Add(oPageNumber)
            '    'oHeader.Selection.Text = "/" + textControl.Pages.ToString()
            '    'oHeader.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right

            '    ''tField.Text = ""
            '    'SiteNumberingDone = True

            '    'Dim hf As TXTextControl.HeaderFooter = textControl.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer)
            '    ''hf.Selection.Start = tField.Start
            '    ''hf.Selection.Length = tField.Text.Length
            '    ''tField.Text = "Seite "
            '    'Dim pnField As New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)
            '    'pnField.pa()
            '    'hf.PageNumberFields.Add(pnField)
            '    'hf.Selection.Text = " "
            '    'hf.Selection.Text = textControl.Pages.ToString()
            '    '     hf.TextFields.Add(New TextField() {Editable = False, Name = "PageCount", ShowActivated = False, Deleteable = True, Text = this.textControl.Pages.ToString()})

            '    'End If
            'End If

            If tField.Name.Trim().ToLower().Equals(fieldToFill.Trim().ToLower()) And tField.Name.Trim().ToLower().Equals(("[PNr]").Trim().ToLower()) Then
                tField.Text = textControl.Pages.ToString()
                Return True
            Else
                If tField.Name.Trim().ToLower().Equals(fieldToFill.Trim().ToLower()) Then
                    tField.Text = text
                    Return True
                End If
            End If

            'textControl.Selection.Start = tField.Start - 1
            'textControl.Selection.Length = tField.Length
            'tField.Text = ""

        Catch ex As Exception
            Throw New Exception("doBM.setBookmark: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

End Class
