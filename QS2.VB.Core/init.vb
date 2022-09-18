


Public Class init


    Public Shared Function initSystem() As Boolean

        Dim autoLogInPwdDecrypted As String = ""
        If qs2.core.ENV.autoLogInPwdEncrypted <> "" Then
            Dim Encryption1 As New qs2.license.core.Encryption()
            qs2.core.ENV.autoLogInPwdDecrypted = Encryption1.StringDecrypt(qs2.core.ENV.autoLogInPwdEncrypted, qs2.license.core.Encryption.keyForEncryptingStrings)
        End If

        Return True

    End Function

End Class
