Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic




Public Class dbBill


    Public Shared idStornoRechNr As String = "StornoRechNr"

    Public sql As New Sql()


    Public Function getID(ByVal dbBill As dbBill, ByVal id As String) As dbBill.fieldsRow
        Try
            Dim arrR As dbBill.fieldsRow() = dbBill.fields.Select("ID = '" + id + "'")
            If arrR.Length = 1 Then Return arrR(0)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getRechDatum(ByVal dbCalc As dbCalc) As dbCalc.MonateRow
        Try
            Dim arrMonate As dbCalc.MonateRow() = dbCalc.Monate.Select("")
            If arrMonate.Length <> 1 Then
                Throw New Exception("dbBill.getRechDatum: arrR.Length <> 1 for dbCalc")
            End If
            Dim rMonat As dbCalc.MonateRow = arrMonate(0)
            Return rMonat

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function checkNewRowDbBill(ByRef dbBill As dbBill, ByVal id As String) As dbBill.fieldsRow
        Try

            Dim arrR As dbBill.fieldsRow() = dbBill.fields.Select("ID = '" + id + "'")
            If arrR.Length = 0 Then
                Return Me.newRowDbBill(dbBill)
            Else
                Return arrR(0)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function newRowDbBill(ByRef dbBill As dbBill) As dbBill.fieldsRow
        Try
            Dim rNew As dbBill.fieldsRow = dbBill.fields.NewRow()
            rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
            rNew.txt = ""
            rNew.dec = 0
            rNew.dbl = 0
            rNew.SetdatNull()
            rNew.bool = False
            dbBill.fields.Rows.Add(rNew)
            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getDbBill(ByVal xml As String) As dbBill
        Try
            Dim dbBill As New dbBill
            Dim xmlStringReader As New System.IO.StringReader(xml)
            Dim xmlReader As New System.Xml.XmlTextReader(xmlStringReader)
            dbBill.ReadXml(xmlReader)
            xmlReader.Close()
            Return dbBill

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function getXMLDbBill(ByVal dbBill As dbBill) As String
        Try
            Dim xml As String = ""
            Dim xmlStrWriter As New System.IO.StringWriter()
            Dim xmlWriter As New System.Xml.XmlTextWriter(xmlStrWriter)
            xmlWriter.WriteStartDocument(True)

            dbBill.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)
            xml = xmlStrWriter.ToString()
            xmlWriter.Close()
            Return xml

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub saveStornoRechNr(ByVal idBill As String, ByVal dbBill As dbBill, ByVal StornoRechNr As String)
        Try
            Dim rNew As dbBill.fieldsRow = Me.checkNewRowDbBill(dbBill, dbBill.idStornoRechNr)
            rNew.ID = dbBill.idStornoRechNr
            rNew.txt = StornoRechNr
            Me.sql.saveDbBill(idBill, Me.getXMLDbBill(dbBill))

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


End Class
