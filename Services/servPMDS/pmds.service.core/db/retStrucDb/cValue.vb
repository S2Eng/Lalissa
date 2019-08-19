

Public Class cValue

    Public columnName As String = Nothing
    Public tableName As String = Nothing

    Public valueStr As String = Nothing
    Public valueInt As Integer = Nothing
    Public valueDbl As Double = Nothing
    Public valueBool As Boolean = False
    Public valueDateTime As DateTime = Nothing
    Public valueGuid As String = Nothing

    Public isNull As Boolean = False
    Public valueType As String = ""

    Public valueUI As String = ""
    Public SelListID As String = ""

    Public cServiceResultSub() As cServiceResult

End Class
