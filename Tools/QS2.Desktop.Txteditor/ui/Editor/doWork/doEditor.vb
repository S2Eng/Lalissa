

Public Class doEditor




    Public Function showText(ByVal txt As String, ByVal typ As TXTextControl.StreamType, ByVal eingabeJN As Boolean, _
                ByVal viewMod As TXTextControl.ViewMode, ByVal editor As TXTextControl.TextControl, _
                Optional ByRef bytes() As Byte = Nothing, Optional ByRef bytesPdf() As Byte = Nothing) As Boolean
        Try
            If Not bytes Is Nothing Then
                editor.Load(bytes, TXTextControl.BinaryStreamType.InternalFormat)
            Else
                Dim settings As New TXTextControl.LoadSettings
                Select Case typ
                    Case TXTextControl.StreamType.HTMLFormat
                        editor.Load(txt, TXTextControl.StringStreamType.HTMLFormat, settings)
                    Case TXTextControl.StreamType.PlainText
                        editor.Load(txt, TXTextControl.StringStreamType.PlainText, settings)
                    Case TXTextControl.StreamType.RichTextFormat
                        editor.Load(txt, TXTextControl.StringStreamType.RichTextFormat, settings)
                    Case TXTextControl.StreamType.AdobePDF
                        editor.Load(bytesPdf, TXTextControl.StreamType.AdobePDF)
                End Select
            End If

            'editor.PageSize = settings.PageSize
            'editor.PageMargins.Bottom = settings.PageMargins.Bottom
            'editor.PageMargins.Top = settings.PageMargins.Top
            'editor.PageMargins.Right = settings.PageMargins.Right
            'editor.PageMargins.Left = settings.PageMargins.Left
            'editor.ViewMode = viewMod
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.showText: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function showFile(ByRef fileName As String, _
                             ByRef StreamType As TXTextControl.StreamType, _
                             ByRef editor As TXTextControl.TextControl) As Boolean
        Try
            editor.Load(fileName, StreamType)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.showFile: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function saveDocument(ByVal docuToSave As String, ByVal typ As TXTextControl.StreamType, _
                                 ByVal editor As TXTextControl.TextControl) As Boolean

        Dim SaveSettings As New TXTextControl.SaveSettings()
        If System.IO.File.Exists(docuToSave) Then
            System.IO.File.Delete(docuToSave)
        End If
        editor.Save(docuToSave, typ, SaveSettings)
        Return True

    End Function

    Public Function getText(ByVal typ As TXTextControl.StringStreamType, ByVal editor As TXTextControl.TextControl) As String
        Try
            Dim strData As String = ""
            editor.Save(strData, typ)
            Return strData

        Catch ex As Exception
            Throw New Exception("doEditor.getText: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function getTextInByte(ByVal typ As TXTextControl.BinaryStreamType, ByVal editor As TXTextControl.TextControl) As Byte()
        Try
            Dim b() As Byte
            editor.Save(b, typ)
            Return b

        Catch ex As Exception
            Throw New Exception("doEditor.getTextInByte: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
 
    Public Function appendText(ByVal rtf As String, ByVal editor As TXTextControl.TextControl) As Boolean
        Try
            editor.Append(rtf, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewSection)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.appendText: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function appendPlainTxt(ByVal txt As String, ByVal editor As TXTextControl.TextControl) As Boolean
        Try
            editor.Selection.Start = 0
            editor.Selection.Length = 0
            editor.Selection.ParagraphFormat.TopDistance = 0
            editor.Selection.ParagraphFormat.BottomDistance = 0
            editor.Selection.ForeColor = System.Drawing.Color.Black
            editor.Selection.FontName = "Arial"
            editor.Selection.FontSize = 200

            editor.Selection.Text = txt
            'editor.Append(txt, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.None)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.appendPlainTxt: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function appendPlainTxtSrv(ByVal txt As String, ByVal editor As TXTextControl.ServerTextControl) As Boolean
        Try
            editor.Selection.Start = 0
            editor.Selection.Length = 0
            editor.Selection.ParagraphFormat.TopDistance = 0
            editor.Selection.ParagraphFormat.BottomDistance = 0
            editor.Selection.ForeColor = System.Drawing.Color.Black
            editor.Selection.FontName = "Arial"
            editor.Selection.FontSize = 200

            editor.Selection.Text = txt
            'editor.Append(txt, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.None)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.appendPlainTxtSrv: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function appendText(ByVal b() As Byte, ByVal editor As TXTextControl.TextControl) As Boolean
        Try
            editor.Append(b, TXTextControl.BinaryStreamType.InternalFormat, TXTextControl.AppendSettings.StartWithNewSection)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.appendText: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function appendText2(ByVal txt As String, ByVal editor As TXTextControl.TextControl, typ As TXTextControl.StringStreamType) As Boolean
        Try
            Dim appSett As New TXTextControl.AppendSettings()
            editor.Append(txt, typ, appSett)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.appendText: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function insertPagebreak(ByVal editor As TXTextControl.TextControl) As Boolean
        Try
            Dim BreakKind As TXTextControl.SectionBreakKind = TXTextControl.SectionBreakKind.BeginAtNewPage
            editor.Sections.Add(BreakKind)
            'Me.textControl1.Selection.Text = Chr(12)
            editor.Selection.Text = Chr(13) + Chr(10)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.insertPagebreak: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function insertLinebreakxy(ByVal editor As TXTextControl.TextControl) As Boolean
        Try
            editor.Selection.Text = Chr(13) + Chr(10)
            Return True

        Catch ex As Exception
            Throw New Exception("doEditor.insertLinebreakxy: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

End Class
