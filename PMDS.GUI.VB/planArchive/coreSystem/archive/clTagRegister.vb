

Public Class clTagSchrankFachOrdner

    Public ID As New System.Guid
    Public IDSystemordner As Integer = 0
    Public typ As New eTyp
    Public fileInfo As New clFileInfo

    Public Enum eTyp
        typSchrank = 0
        typFach = 1
        typOrdner = 2
        typDateiAblegen = 3
        typDateiSuchen = 4
        typGruppeRecht = 5
        keiner = 100
    End Enum
    Sub New()
        Me.ID = Nothing
        Me.typ = eTyp.keiner
    End Sub

End Class
