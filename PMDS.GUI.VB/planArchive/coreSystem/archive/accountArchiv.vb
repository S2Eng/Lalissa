Imports System.Xml


Public Class accountArchiv


    Public general As New GeneralArchiv


    Public Sub New()
        MyBase.New()
    End Sub

    Public Class cXmlFound
        Public result As String = ""
        Public found As Boolean = False
    End Class


    Public Function searchXML(ByVal searchText As String, ByVal file As String) As cXmlFound
        Try

            If Not System.IO.File.Exists(file) Then
                Throw New Exception("account.readXML: Config file '" + file + "' doesn't exist!")
            End If
            Dim XMLDoc As New XmlDocument
            XMLDoc.Load(file)

            Dim res As New cXmlFound
            res = Me.readConfigRek(searchText, XMLDoc.DocumentElement)
            Return res

        Catch ex As Exception
            general.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Private Function readConfigRek(ByRef searchText As String, ByRef Node As XmlNode) As cXmlFound
        Try

            For Each n As XmlNode In Node.ChildNodes
                If n.Name = searchText Then
                    Dim resFound As New cXmlFound
                    resFound.found = True
                    If Not general.IsNull(n.InnerText()) Then
                        resFound.result = Trim(n.InnerText())
                        Return resFound
                    Else
                        Return resFound
                    End If
                End If
                Dim res As New cXmlFound
                res = readConfigRek(searchText, n)
                If res.found Then Return res
            Next

            Dim emptyRes As New cXmlFound
            Return emptyRes

        Catch ex As Exception
            general.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


    Public Function writeXML(ByVal searchText As String, ByVal file As String, ByVal newValue As String) As Boolean
        Try

            If Not System.IO.File.Exists(file) Then
                Throw New Exception("account.readXML: Config file '" + file + "' doesn't exist!")
            End If
            Dim XMLDoc As New XmlDocument
            XMLDoc.Load(file)

            If Me.writeConfigRek(searchText, XMLDoc.DocumentElement, newValue) Then
                XMLDoc.Save(file)
                Return True
            End If


        Catch ex As Exception
            general.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Private Function writeConfigRek(ByRef searchText As String, ByRef Node As XmlNode, ByVal newValue As String) As Boolean
        Try

            For Each n As XmlNode In Node.ChildNodes
                If n.Name = searchText Then
                    n.InnerText = newValue
                    Return True
                End If
                If writeConfigRek(searchText, n, newValue) Then Return True
            Next

        Catch ex As Exception
            general.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


End Class
