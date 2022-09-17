

Public Class Spelling


    Private Shared TXSpellChecker1 As TXTextControl.Proofing.TXSpellChecker = Nothing




    Public Shared Function getSpellChecker() As TXTextControl.Proofing.TXSpellChecker
        Try
            If Spelling.TXSpellChecker1 Is Nothing Then
                Spelling.TXSpellChecker1 = New TXTextControl.Proofing.TXSpellChecker()
                'Spelling.TXSpellChecker1.Language = "de-DE"
            End If

            Return Spelling.TXSpellChecker1

        Catch ex As Exception
            Throw New Exception("Spelling.getSpellChecker:" + ex.ToString())
        End Try
    End Function

End Class
