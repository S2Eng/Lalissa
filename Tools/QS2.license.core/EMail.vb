

Public Class EMail


    Public Shared Sub openNewEMail(ByVal sTo As String, Optional ByVal sTitle As String = "", Optional ByVal sText As String = "")

        Dim sParam As String

        ' Betreff
        If sTitle.Length > 0 Then AddMailParam(sParam, "subject=" + sTitle)

        ' Nachrichtentext
        If sText.Length > 0 Then AddMailParam(sParam, "body=" + sText.Replace(Chr(10), "%0d").Replace(Chr(13), "%0a"))

        ' Fenster "Neue Nachricht" öffnen
        Process.Start("mailto: " + sTo + sParam)

    End Sub
    Private Shared Sub AddMailParam(ByRef sAllParam As String, ByVal sParam As String)
        If sAllParam = String.Empty Then
            sAllParam = "?" + sParam
        Else
            sAllParam &= "&" + sParam
        End If
    End Sub



End Class
