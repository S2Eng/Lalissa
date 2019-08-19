Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System
Imports System.Xml
Imports Microsoft.Win32

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols



Public Class General

    Public Declare Sub MDStringFix Lib "aamd532.dll" (ByVal f As String, ByVal t As Integer, ByVal r As String)

    Public Shared pwdSecretLogInIntern As String = "9ffd9a2ee2186d45558a8f13168cb384"



    Public Function calcMD5(ByVal p As String) As String
        Dim r As String = ""
        Dim t As Integer = ""
        r = Space(32)
        t = Len(p)
        MDStringFix(p, t, r)
        Return r
    End Function

    Public Function calcMD5Net(ByVal Str As String) As String
        'Kunden:    EBN="ITSCont_adm000EBN"
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        If Str <> "" Then
            Return Me.ByteToString(md5.ComputeHash(Me.StringToByte(Str)))
        Else
            Return ""
        End If
    End Function

    Public Function ByteToString(ByVal bytes() As Byte) As String
        Dim str As String = ""
        Dim i As Integer
        For i = 0 To bytes.Length - 1
            str += Chr(bytes(i))
        Next i
        Return str
    End Function
    Public Function StringToByte(ByVal Str As String) As Byte()
        Dim ByteStrings() As Char
        ByteStrings = Str.ToCharArray()
        Dim ByteOut(ByteStrings.Length - 1) As Byte
        For i As Integer = 0 To ByteStrings.Length - 1
            ByteOut(i) = Convert.ToByte(ByteStrings(i))
        Next
        Return ByteOut
    End Function

    Public Sub getTableColumnFromStr(ByVal str As String, _
                                     ByRef tableName As String, ByRef columnName As String)

        If str.Trim() = "" Then Exit Sub

        Dim posPoint As Integer = str.IndexOf(".")
        If posPoint <> -1 Then
            tableName = str.Substring(0, posPoint).Trim()
            columnName = str.Substring(posPoint + 1, str.Length - (posPoint + 1)).Trim()
        Else
            Throw New Exception("getTableColumnFromStr: No Point in Variable '" + str + "'!")
        End If

    End Sub

    Public Shared Function readRegistryxy() As Boolean
        Try
            Dim rk As RegistryKey

            rk = Registry.LocalMachine.OpenSubKey("Software\servITSCont", False)
            dbGlobal.db = (CType(rk.GetValue("db"), String))
            dbGlobal.srv = (CType(rk.GetValue("srv"), String))
            dbGlobal.usr = (CType(rk.GetValue("usr"), String))
            dbGlobal.pwd = (CType(rk.GetValue("pwd"), String))
            'ENV.path_doku = (CType(rk.GetValue("pfadDoku"), String))
            Return True

        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Public Shared Function getAppPath() As String
        Dim direct As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return direct.Substring(6)
    End Function

    Public Function doEcxept(ByVal ex As Exception) As SoapException
        If Not ENV.adminSecure Then
            Me.writeExcept(ex)
        End If
        'Return RaiseException("setAdminDatabase", "http://tempuri.org/S2ITSContDATAExchange", _
        '                ex.Message, "1000", ex.Source)
        Throw New Exception(ex.ToString())
    End Function
    Public Shared Function RaiseException(ByVal uri As String, _
                              ByVal webServiceNamespace As String, _
                              ByVal errorMessage As String, _
                              ByVal errorNumber As String, _
                              ByVal errorSource As String ) As SoapException


        Dim faultCodeLocation As XmlQualifiedName = Nothing
        'Identify the location of the FaultCode

        'faultCodeLocation = SoapException.ClientFaultCode
        faultCodeLocation = SoapException.ServerFaultCode

        Dim xmlDoc As XmlDocument = New XmlDocument
        'Create the Detail node
        Dim rootNode As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, _
                        SoapException.DetailElementName.Name, _
                        SoapException.DetailElementName.Namespace)
        'Build specific details for the SoapException
        'Add first child of detail XML element.
        Dim errorNode As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error", webServiceNamespace)
        'Create and set the value for the ErrorNumber node
        Dim errorNumberNode As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber", webServiceNamespace)
        errorNumberNode.InnerText = errorNumber
        'Create and set the value for the ErrorMessage node
        Dim errorMessageNode As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", webServiceNamespace)
        errorMessageNode.InnerText = errorMessage
        'Create and set the value for the ErrorSource node
        Dim errorSourceNode As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource", webServiceNamespace)
        errorSourceNode.InnerText = errorSource
        'Append the Error child element nodes to the root detail node.
        errorNode.AppendChild(errorNumberNode)
        errorNode.AppendChild(errorMessageNode)
        errorNode.AppendChild(errorSourceNode)
        'Append the Detail node to the root node
        rootNode.AppendChild(errorNode)
        'Construct the exception
        Dim soapEx As SoapException = New SoapException(errorMessage, faultCodeLocation, uri, rootNode)
        'Raise the exception  back to the caller
        Return soapEx

    End Function
    Public Sub writeExcept(ByVal ex As Exception)
        Dim newGuidFile As New System.Guid
        newGuidFile = System.Guid.NewGuid()
        Dim errorFile As String = Microsoft.VisualBasic.Left(ENV.path_logging, Microsoft.VisualBasic.Len(ENV.path_logging) - 4) + "\log\error_" + newGuidFile.ToString + ".log"

        Dim fileExcept As StreamWriter = File.AppendText(errorFile)
        fileExcept.WriteLine("--------------------------------------------------------------------------------------------------------------------")
        fileExcept.WriteLine("Time: " + CStr(DateTime.Now) + "   Database:" + dbGlobal.db + vbNewLine)
        fileExcept.WriteLine(ex.Message + vbNewLine)
        fileExcept.WriteLine(ex.Source + vbNewLine)
        fileExcept.WriteLine(ex.StackTrace + vbNewLine + vbNewLine)
        fileExcept.Close()
    End Sub

End Class
