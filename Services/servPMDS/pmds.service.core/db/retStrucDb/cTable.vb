

Public Class cTable

    Public tableName As String = ""
    Public tableNr As Integer = -1
    Public tableInfo As String = ""
    Public selListTypID As String = ""
    Public rowsFound As Integer = 0
    Public sql As String = ""
    Public runStart As DateTime = Now
    Public runEnd As DateTime
    Public rows() As cRow


    Public Sub New()
        Me.runStart = System.Convert.ToDateTime(Now, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
    End Sub

End Class
