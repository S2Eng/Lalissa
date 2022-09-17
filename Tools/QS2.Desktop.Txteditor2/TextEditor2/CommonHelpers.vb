'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				CommonHelpers.vb
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports TXTextControl
Imports System.Reflection
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Threading


Partial Public Class FormMain
    Inherits System.Windows.Forms.UserControl
#Region "  Page numbers  "

    ''' <summary>
    ''' Inserts a page number field into the current section.
    ''' </summary>
    ''' <param name="headerFooterType__1">Only header or footer are allowed.</param>
    Private Sub InsertPageNumber(ByVal headerFooterType__1 As HeaderFooterType)
        Dim hdrFtr As HeaderFooter = Nothing

        Try
            ' Get current section
            Dim sect = _textControl.Sections.GetItem()
            If sect Is Nothing Then
                Return
            End If

            Select Case headerFooterType__1
                Case HeaderFooterType.Header
                    ' Create header if none exists
                    If Not HeaderExists() Then
                        sect.HeadersAndFooters.Add(headerFooterType__1)
                    End If

                    ' Use first page header if one exists and input position is on first page of section
                    If (sect.Start = _textControl.InputPosition.Page) AndAlso (sect.HeadersAndFooters.GetItem(HeaderFooterType.FirstPageHeader) IsNot Nothing) Then
                        headerFooterType__1 = HeaderFooterType.FirstPageHeader
                    End If

                    hdrFtr = sect.HeadersAndFooters.GetItem(headerFooterType__1)
                    Exit Select

                Case HeaderFooterType.Footer
                    ' Create footer if none exists
                    If Not FooterExists() Then
                        sect.HeadersAndFooters.Add(headerFooterType__1)
                    End If

                    ' Use first page header if one exists and input position is on first page of section
                    If (sect.Start = _textControl.InputPosition.Page) AndAlso (sect.HeadersAndFooters.GetItem(HeaderFooterType.FirstPageFooter) IsNot Nothing) Then
                        headerFooterType__1 = HeaderFooterType.FirstPageFooter
                    End If

                    hdrFtr = sect.HeadersAndFooters.GetItem(headerFooterType__1)
                    Exit Select
            End Select

            If hdrFtr Is Nothing Then
                Return
            End If

            ' If the header / footer already contains a page number, break
            If hdrFtr.PageNumberFields.Count > 0 Then
                Return
            End If

            Dim pgNumFld = New PageNumberField() With { _
               .StartNumber = 1, _
               .Editable = False, _
               .DoubledInputPosition = True, _
               .ShowActivated = True _
            }

            hdrFtr.PageNumberFields.Add(pgNumFld)
        Catch ex As Exception
            ' Display information if feature not enabled in current version
            MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try
    End Sub

    ''' <summary>
    ''' Removes all page number fields from all headers and footers of the current section.
    ''' </summary>
    Private Sub RemovePageNumbers()
        Dim sectCur As Section = Nothing

        Try
            sectCur = _textControl.Sections.GetItem()
            If sectCur Is Nothing Then
                Return
            End If

            For Each hdrFtr As HeaderFooter In sectCur.HeadersAndFooters
                hdrFtr.PageNumberFields.Clear(False)
            Next
        Catch ex As Exception
            ' Display information if feature not enabled in current version
            MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region


#Region "  Headers / Footers  "

    Private Function HeaderExists() As Boolean
        If _textControl Is Nothing Then
            Return False
        End If

        Try
            Return ((_textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) IsNot Nothing) OrElse (_textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) IsNot Nothing))
        Catch
        End Try

        Return False
    End Function

    Private Function FooterExists() As Boolean
        If _textControl Is Nothing Then
            Return False
        End If

        Try
            Return ((_textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) IsNot Nothing) OrElse (_textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) IsNot Nothing))
        Catch
        End Try

        Return False
    End Function

#End Region


#Region "  Embedded Resources  "

    Friend Shared Function GetResourceByName(ByVal resource As String) As String
        Dim assembly__1 = Assembly.GetExecutingAssembly()
        Dim reader = New StreamReader(assembly__1.GetManifestResourceStream(resource))
        Return reader.ReadToEnd()
    End Function

    Friend Shared Function GetBinaryResourceByName(ByVal resource As String) As Byte()
        Dim buffer = New Byte(4096) {}
        ' Data buffer for reading chunks from the binary stream
        Dim msResult = New MemoryStream()
        Dim reader As BinaryReader = Nothing
        Dim asm As Assembly = Nothing

        Try
            asm = Assembly.GetExecutingAssembly()
            reader = New BinaryReader(asm.GetManifestResourceStream(resource))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Binary Resources", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return Nothing
        End Try

        While True
            Dim bytesRead As Integer = reader.Read(buffer, 0, buffer.Length)
            If bytesRead <= 0 Then
                Exit While
            End If
            msResult.Write(buffer, 0, bytesRead)
        End While

        Return msResult.ToArray()
    End Function

    Private Sub LoadTemplateFile(ByVal fileName As String, ByVal streamType As TXTextControl.StreamType)
        If (Not String.IsNullOrEmpty(fileName)) AndAlso (Not _fileHandler.DocumentDirty OrElse (_fileHandler.DocumentDirty AndAlso FileSaveQuestion())) Then
            Try
                _textControl.Load(fileName, streamType, New LoadSettings() With { _
                 .ApplicationFieldFormat = ApplicationFieldFormat.MSWord _
                })
            Catch exc As Exception
                MessageBox.Show(exc.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try

            SetDefaultFieldProperties()
            _fileHandler.DocumentFileName = ""
            _fileHandler.DocumentDirty = False
        End If
    End Sub
    ' LoadTemplateData
    Private Sub LoadBlankDocTemplate()
        Dim ls = New LoadSettings() With { _
         .DocumentBasePath = "" _
        }

        _fileHandler.SuspendChangeEvents = True

        _textControl.Load(GetBinaryResourceByName("TX_Text_Control_Words.styles.docx"), BinaryStreamType.WordprocessingML, ls)

        Text = ProductName

        'Set language to user default language
        Dim curCult = Thread.CurrentThread.CurrentCulture
        _textControl.SelectAll()
        _textControl.Selection.Culture = curCult

        _fileHandler.SuspendChangeEvents = False
    End Sub
    ' LoadBlankDocTemplate
#End Region
End Class
