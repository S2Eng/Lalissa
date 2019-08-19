


Public Class cServiceResult

    Public successful As Boolean = False
    Public errorService = ""
    Public errorField = ""
    Public at As DateTime = Now.ToString()
    Public tables() As cTable

    Public document As System.Byte()
    Public ID As String = ""

    Public IDSubtable As String = ""
End Class



