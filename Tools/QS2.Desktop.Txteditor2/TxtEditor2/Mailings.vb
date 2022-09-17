'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				Mailings.vb
' description:	This file contains the implementation of the mail merge functions.
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Windows.Forms
Imports TXTextControl.DocumentServer.Fields
Imports System.Diagnostics
Imports System.Reflection
Imports System.Collections.Generic


Partial Public Class contTxtEditor2
    Inherits System.Windows.Forms.UserControl
    Private _fldDispModeCur As FieldDisplayMode
    Private _bHighlightFields As Boolean = True

    Private Const MsgNoFields As String = "The document does not contain any fields."

    Private Enum FieldDisplayMode
        ShowFieldText
        ShowFieldCodes
    End Enum

    ''' <summary>
    ''' Sets document wide default field properties.
    ''' </summary>
    Friend Sub SetDefaultFieldProperties()

        Try
            For Each textPart As TXTextControl.IFormattedText In _textControl.TextParts
                For Each fld As TXTextControl.ApplicationField In textPart.ApplicationFields
                    fld.Editable = False
                    fld.DoubledInputPosition = True
                    fld.ShowActivated = _bHighlightFields
                Next
            Next
        Catch
        End Try
    End Sub

    Private Function InsertMergeField(ByVal strName As String) As MergeField
        Dim mf As MergeField = CreateMergeField(strName)
        _textControl.ApplicationFields.Add(mf.ApplicationField)
        Return mf
    End Function

    Private Function CreateMergeField(ByVal strName As String) As MergeField
        Dim mf = New MergeField()

        mf.ApplicationField.DoubledInputPosition = True
        mf.ApplicationField.Editable = False
        mf.ApplicationField.ShowActivated = _bHighlightFields

        If strName <> String.Empty Then
            mf.Name = strName

            Select Case _fldDispModeCur
                Case FieldDisplayMode.ShowFieldCodes
                    Dim strSwitches As String = If((mf.ApplicationField.Parameters IsNot Nothing), String.Join(" ", mf.ApplicationField.Parameters), "")
                    mf.Text = "{" & Convert.ToString(mf.TypeName) & strSwitches & " }"
                    Exit Select

                Case FieldDisplayMode.ShowFieldText
                    mf.Text = "«" & strName & "»"
                    Exit Select
            End Select
        End If

        Return mf
    End Function

    Private Sub InsertMergeField()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Dim newMergeField = CreateMergeField("")
        If newMergeField.ShowDialog(bRTL) = TXTextControl.DocumentServer.Fields.DialogResult.OK Then
            newMergeField.Text = "«" & Convert.ToString(newMergeField.Name) & "»"
            _textControl.ApplicationFields.Add(newMergeField.ApplicationField)
        End If
    End Sub

    Private Sub InsertIfField()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Dim newIfField = New IfField()
        newIfField.ApplicationField.DoubledInputPosition = True
        newIfField.ApplicationField.Editable = False
        newIfField.ApplicationField.ShowActivated = _bHighlightFields

        If newIfField.ShowDialog(bRTL) = TXTextControl.DocumentServer.Fields.DialogResult.OK Then
            _textControl.ApplicationFields.Add(newIfField.ApplicationField)
        End If
    End Sub

    Private Sub InsertNextField()
        Dim newField = New NextField()
        newField.ApplicationField.DoubledInputPosition = True
        newField.ApplicationField.Editable = False
        newField.ApplicationField.ShowActivated = _bHighlightFields

        _textControl.ApplicationFields.Add(newField.ApplicationField)
    End Sub

    Private Sub InsertNextIfField()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Dim newField = New NextIfField()
        newField.ApplicationField.DoubledInputPosition = True
        newField.ApplicationField.Editable = False
        newField.ApplicationField.ShowActivated = _bHighlightFields

        If newField.ShowDialog(bRTL) = TXTextControl.DocumentServer.Fields.DialogResult.OK Then
            _textControl.ApplicationFields.Add(newField.ApplicationField)
        End If
    End Sub

    Private Sub InsertDateField()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Dim newDateField = New DateField() With { _
         .Format = "dd.MM.yyyy" _
        }
        newDateField.ApplicationField.DoubledInputPosition = True
        newDateField.ApplicationField.Editable = False
        newDateField.ApplicationField.ShowActivated = _bHighlightFields

        If newDateField.ShowDialog(bRTL) = TXTextControl.DocumentServer.Fields.DialogResult.OK Then
            _textControl.ApplicationFields.Add(newDateField.ApplicationField)
        End If
    End Sub

    Private Sub InsertIncludeTextField()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Dim newIncludeTextField = New IncludeText()
        newIncludeTextField.ApplicationField.DoubledInputPosition = True
        newIncludeTextField.ApplicationField.Editable = False
        newIncludeTextField.ApplicationField.ShowActivated = _bHighlightFields

        If newIncludeTextField.ShowDialog(bRTL) = TXTextControl.DocumentServer.Fields.DialogResult.OK Then
            _textControl.ApplicationFields.Add(newIncludeTextField.ApplicationField)
        End If
    End Sub

    Private Sub DeleteField()
        If Not FieldAtCurrentPos() Then
            MessageBox.Show("There is no field at the current input position.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim field = _textControl.ApplicationFields.GetItem()
            _textControl.ApplicationFields.Remove(field)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function FieldAtCurrentPos() As Boolean
        Try
            Dim field = _textControl.ApplicationFields.GetItem()
            Return field IsNot Nothing
        Catch
            Return False
        End Try
    End Function

    Private Sub FieldSettings()
        Dim bRTL As Boolean = Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Try
            Dim field = _textControl.ApplicationFields.GetItem()
            If field Is Nothing Then
                MessageBox.Show("There is no field at the current input position.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Select Case field.TypeName
                Case MergeField.TYPE_NAME
                    Dim mergeField__1 = New MergeField(field)
                    mergeField__1.ShowDialog(bRTL)
                    Exit Select

                Case DateField.TYPE_NAME
                    Dim dateField__2 = New DateField(field)
                    dateField__2.ShowDialog(bRTL)
                    Exit Select

                Case IncludeText.TYPE_NAME
                    Dim includeTextField = New IncludeText(field)
                    includeTextField.ShowDialog(bRTL)
                    Exit Select

                Case IfField.TYPE_NAME
                    Dim ifField__3 = New IfField(field)
                    ifField__3.ShowDialog(bRTL)
                    Exit Select

                Case NextIfField.TYPE_NAME
                    Dim nextIf = New NextIfField(field)
                    nextIf.ShowDialog(bRTL)
                    Exit Select
            End Select

            ' Update field values after editing field
            UpdateFieldValues()
        Catch
        End Try
    End Sub

    Private Sub UpdateFieldValues()
        If _textControl Is Nothing Then
            Return
        End If

        Try
            Select Case _fldDispModeCur
                Case FieldDisplayMode.ShowFieldCodes
                    For Each textPart As TXTextControl.IFormattedText In _textControl.TextParts
                        For Each appField As TXTextControl.ApplicationField In textPart.ApplicationFields
                            Dim fieldSwitches As String = If((appField.Parameters IsNot Nothing), String.Join(" ", appField.Parameters), "")
                            appField.Text = "{ " + appField.TypeName & " " & fieldSwitches & " }"
                        Next
                    Next

                    Exit Select

                Case FieldDisplayMode.ShowFieldText
                    For Each textPart As TXTextControl.IFormattedText In _textControl.TextParts
                        For Each appField As TXTextControl.ApplicationField In textPart.ApplicationFields
                            Select Case appField.TypeName
                                Case MergeField.TYPE_NAME
                                    Dim mergeField__1 = New MergeField(appField)
                                    mergeField__1.Text = "«" & Convert.ToString(mergeField__1.Name) & "»"
                                    Exit Select

                                Case IfField.TYPE_NAME
                                    Dim ifField__2 = New IfField(appField)
                                    ifField__2.Text = "{" & Convert.ToString(ifField__2.TypeName) & "}"
                                    Exit Select

                                Case DateField.TYPE_NAME
                                    Dim dateField__3 = New DateField(appField)
                                    dateField__3.Text = "{" & Convert.ToString(dateField__3.TypeName) & "}"
                                    Exit Select

                                Case IncludeText.TYPE_NAME
                                    Dim includeText__4 = New IncludeText(appField)
                                    includeText__4.ApplicationField.Text = "{" & Convert.ToString(includeText__4.TypeName) & "}"
                                    Exit Select

                                Case NextField.TYPE_NAME
                                    Dim [next] = New NextField(appField)
                                    [next].ApplicationField.Text = "{" & Convert.ToString([next].TypeName) & "}"
                                    Exit Select

                                Case NextIfField.TYPE_NAME
                                    Dim nextIf = New NextIfField(appField)
                                    nextIf.ApplicationField.Text = "{" & Convert.ToString(nextIf.TypeName) & "}"
                                    Exit Select
                            End Select
                        Next
                    Next

                    Exit Select
            End Select
        Catch
        End Try
    End Sub


    Private Function DocumentContainsFields() As Boolean
        For Each textPart As TXTextControl.IFormattedText In _textControl.TextParts
            If (textPart.ApplicationFields IsNot Nothing) AndAlso (textPart.ApplicationFields.Count > 0) Then
                Return True
            End If
        Next

        Return False
    End Function


    Private Function DocumentContainsNamedObjects() As Boolean
        For Each textPart As TXTextControl.IFormattedText In _textControl.TextParts
            For Each img As TXTextControl.Image In textPart.Images
                If Not String.IsNullOrEmpty(img.Name) Then
                    Return True
                End If
            Next
        Next

        For Each chart As TXTextControl.DataVisualization.ChartFrame In _textControl.Charts
            If Not String.IsNullOrEmpty(chart.Name) Then
                Return True
            End If
        Next

        For Each barcode As TXTextControl.DataVisualization.BarcodeFrame In _textControl.Barcodes
            If Not String.IsNullOrEmpty(barcode.Name) Then
                Return True
            End If
        Next

        Return False
    End Function
    ' DocumentContainsNamedObjects

    Private Function StreamTypeToFileExt(ByVal streamType As TXTextControl.StreamType) As String
        Select Case streamType
            Case TXTextControl.StreamType.AdobePDF, TXTextControl.StreamType.AdobePDFA
                Return "pdf"

            Case TXTextControl.StreamType.CascadingStylesheet
                Return "css"

            Case TXTextControl.StreamType.HTMLFormat
                Return "html"

            Case TXTextControl.StreamType.InternalFormat, TXTextControl.StreamType.InternalUnicodeFormat
                Return "tx"

            Case TXTextControl.StreamType.MSWord
                Return "doc"

            Case TXTextControl.StreamType.PlainAnsiText, TXTextControl.StreamType.PlainText
                Return "txt"

            Case TXTextControl.StreamType.RichTextFormat
                Return "rtf"

            Case TXTextControl.StreamType.WordprocessingML
                Return "docx"

            Case TXTextControl.StreamType.XMLFormat
                Return "xml"
        End Select

        Return String.Empty
    End Function
End Class
