Public Class clFileInfo

    Public Sub New()

    End Sub

    Public file_name As String = ""
    Public file_größe As Double
    Public file_erstelltAm As DateTime
    Public file_geändertAm As DateTime

    Public file_origVerzeichnis As String = ""
    Public file_Bezeichnung As String = ""
    Public file_typ As String = ""
    Public file_IDOrdner As New System.Guid

    Public fileB() As Byte


End Class

