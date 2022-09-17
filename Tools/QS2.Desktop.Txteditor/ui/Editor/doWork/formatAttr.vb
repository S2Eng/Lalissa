

Public Class formatAttr


    Public columns() As tableColumn

    Public tableNr As Integer = 0
    Public cellFormat As New TXTextControl.TableCellFormat
    Public rowTextIsBold As Boolean = False
    Public rowTextIsItalic As Boolean = False



    Public Sub New()

        Me.cellFormat.TopTextDistance = 30
        Me.cellFormat.BottomTextDistance = 30

        Me.cellFormat.TopBorderWidth = 0
        Me.cellFormat.BottomBorderWidth = 0

    End Sub

    Public ReadOnly Property column(ByVal name As String) As tableColumn
        Get
            Dim found As Boolean = False
            For Each col As tableColumn In Me.columns
                If col.name = name Then
                    found = True
                    Return col
                End If
            Next
            If Not found Then Throw New Exception("formatAttr.column: Column '" + name + "' not found in Collection!")
        End Get
    End Property
    Public Sub setColumn(ByVal name As String, ByVal value As Object)
        Dim found As Boolean = False
        For Each col As tableColumn In Me.columns
            If col.name = name Then
                found = True
                col.value = value
            End If
        Next
        If Not found Then Throw New Exception("formatAttr.setColumn: Column '" + name + "' not found in Collection!")
    End Sub

End Class



Public Class tableColumn

    Public name As String = ""
    Public value As Object = ""
    Public nr As Integer = 0
    Public print As Boolean = True
    Public printNull As Boolean = True
    Public asField As String = ""


    Public Sub New(ByVal cName As String, ByVal cNr As Integer, Optional ByVal printJN As Boolean = True, _
                        Optional ByVal printNullJN As Boolean = True, Optional ByVal asFieldJN As String = "")
        Me.name = cName
        Me.nr = cNr
        Me.print = printJN
        Me.printNull = printNullJN
        Me.asField = asFieldJN
    End Sub

End Class
