'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				SaveDocumentFileDialog.vb
' description:	This file contains a replacement for Text Control's default file saving dialog.
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System.Windows.Forms


''' <summary>
''' A replacement for Text Control's default file saving dialog. Adds the possibility 
''' to get and set the selected file extension using TXTextControl.StreamType.
''' </summary>
Class SaveDocumentFileDialog
    Private _sfd As New SaveFileDialog() With { _
     .Filter = FilterString _
    }

    Private Const FilterString As String = "Rich Text Format (*.rtf)|*.rtf|" + "Hypertext Markup Language (*.htm, *.html)|*.htm;*.html" + "|Microsoft Word (*.docx)|*.docx|" + "Microsoft Word 97-2003 (*.doc)|*.doc|" + "Adobe PDF (*.pdf)|*.pdf|" + "Adobe PDF/A (*.pdf)|*.pdf|" + "Plain Unicode Text (*.txt)|*.txt|" + "Internal TX TextControl Unicode Format (*.tx)|*.tx"

    Public Property CheckFileExists() As Boolean
        Get
            Return _sfd.CheckFileExists
        End Get
        Set(ByVal value As Boolean)
            _sfd.CheckFileExists = value
        End Set
    End Property

    Public Property SelectedFileType() As TXTextControl.StreamType
        Get
            Return FilterIndexToStreamType(_sfd.FilterIndex)
        End Get
        Set(ByVal value As TXTextControl.StreamType)
            _sfd.FilterIndex = StreamTypeToFilterIndex(value)
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _sfd.FileName
        End Get
        Set(ByVal value As String)
            _sfd.FileName = value
        End Set
    End Property

    Public Function ShowDialog() As Boolean
        Return _sfd.ShowDialog() = DialogResult.OK
    End Function

    Private Function FilterIndexToStreamType(ByVal nIndex As Integer) As TXTextControl.StreamType
        Select Case nIndex
            Case 1
                Return TXTextControl.StreamType.RichTextFormat

            Case 2
                Return TXTextControl.StreamType.HTMLFormat
            Case 3
                Return TXTextControl.StreamType.WordprocessingML

            Case 4
                Return TXTextControl.StreamType.MSWord

            Case 5
                Return TXTextControl.StreamType.AdobePDF

            Case 6
                Return TXTextControl.StreamType.AdobePDFA

            Case 7
                Return TXTextControl.StreamType.PlainText

            Case 8
                Return TXTextControl.StreamType.InternalUnicodeFormat
        End Select

        Return TXTextControl.StreamType.RichTextFormat
    End Function

    Private Function StreamTypeToFilterIndex(ByVal streamType As TXTextControl.StreamType) As Integer
        Select Case streamType
            Case TXTextControl.StreamType.RichTextFormat
                Return 1

            Case TXTextControl.StreamType.HTMLFormat
                Return 2
            Case TXTextControl.StreamType.WordprocessingML
                Return 3

            Case TXTextControl.StreamType.MSWord
                Return 4

            Case TXTextControl.StreamType.AdobePDF
                Return 5

            Case TXTextControl.StreamType.AdobePDFA
                Return 6

            Case TXTextControl.StreamType.PlainText
                Return 7

            Case TXTextControl.StreamType.InternalUnicodeFormat
                Return 8
        End Select

        Return 1
    End Function
End Class
