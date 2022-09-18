Imports System.Xml


Public Class XMLTools

    Public Function getXMLNodeValue(ByVal stream As System.IO.MemoryStream, ByVal strNodes As String) As String

        '       Gibt den text eines beliebigen Nodes zurück.
        '       Übergabe des XMLStrings als stream!
        '
        '       Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        '       Dim arrByteData() As Byte = enc.GetBytes(XMLString)
        '       Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(arrByteData)
        '       Wert = qs2.product.all.vb.XMLTools.getXMLNodeValue("Node1>Node2>Node3")   'Nodes durch ">" getrennt

        Try
            stream.Position = 0
            Dim reader As XmlReader = XmlReader.Create(stream)
            Dim arrNodes As Array = strNodes.Split(">")
            Dim i As Integer
            Dim found As Boolean = False



            For i = 0 To arrNodes.Length - 1
                found = False
                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            If reader.Name.ToLower() = arrNodes(i).ToString.ToLower() Then
                                found = True
                                Exit While
                            End If
                    End Select
                End While

            Next

            If found Then
                Return reader.ReadElementContentAsString()
            Else
                Return ""
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try

    End Function



    Public Function CreateXMLWriter(ByVal encoding As String) As Xml.XmlWriter

        Try
            If encoding = Nothing Then encoding = "ISO-8859-1"
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim streamreader As System.IO.StreamReader = New System.IO.StreamReader(stream)
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Encoding = System.Text.Encoding.GetEncoding(encoding)
            Dim writer As XmlWriter = XmlWriter.Create(stream, settings:=settings)

            Return writer

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)

        End Try
    End Function
End Class
