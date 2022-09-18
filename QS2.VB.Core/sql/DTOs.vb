
Public Class DTOs

    Public Class StayDtoS1
        Public Property ID As Integer
        Public Property IDParticipant As String
        Public Property IDApplication As String
        Public Property IDGuid As Guid
        Public Property PatIDGuid As Guid
    End Class
    Public Class StaysRehangDto
        Public Property IDStayNew As Integer
        Public Property IDParticipantNew As String
        Public Property IDApplicationNew As String
        Public Property IDGuidNew As Guid


        Public Property IDStayOld As Integer
        Public Property IDParticipantOld As String
        Public Property IDApplicationOld As String
        Public Property IDGuidOld As Guid
    End Class
    Public Class ObjectCopiedDto
        Public Property IDOld As Integer
        Public Property IDNew As Integer
        Public Property IDGuidOld As Guid
        Public Property IDGuidNew As Guid
    End Class

    Public Class SelListEntriesDto
        Public Property ID As Integer
        Public Property IDGuid As System.Guid
        Public Property IDRes As String
        Public Property IDOwnInt As Integer
        Public Property IDOwnStr As String
    End Class

    Public Class tInt
        Public Property IDField As Integer
        Public Property ID As Integer
        Public Property IDParticipant As String
        Public Property IDApplication As String

    End Class

End Class
