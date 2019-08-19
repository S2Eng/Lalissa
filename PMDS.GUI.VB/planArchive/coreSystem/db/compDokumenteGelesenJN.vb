


Public Class compDokumenteGelesenJN

    Private gen As New GeneralArchiv
    Private db As New db



    Public Function AlleDokumenteGelesenJN(ByVal gelesen As Boolean) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.Connection = conn.getConnDB
            Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.CommandTimeout = 0
            Me.daAlleDokumenteGelesenJaNein.SelectCommand = Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein
            Me.daAlleDokumenteGelesenJaNein.SelectCommand.Parameters("gelesen").Value = gelesen
            Me.daAlleDokumenteGelesenJaNein.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


    Public Function insertGelesenJN(ByVal r As dsPlanArchive.tblDokumenteGelesenRow) As Boolean
        Try

            Me.OleDbInsertCommand_IDDokumenteneintrag.Connection = db.getConnDB
            Me.OleDbInsertCommand_IDDokumenteneintrag.CommandTimeout = 0

            Me.OleDbInsertCommand_IDDokumenteneintrag.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_IDDokumenteneintrag.Parameters("IDDokumenteneintrag").Value = r.IDDokumenteneintrag
            Me.OleDbInsertCommand_IDDokumenteneintrag.Parameters("gelesen").Value = r.gelesen

            Me.OleDbInsertCommand_IDDokumenteneintrag.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function updateGelesenJN(ByVal r As dsPlanArchive.tblDokumenteGelesenRow) As Boolean
        Try

            Me.OleDbUpdateCommand_IDDokumenteneintrag.Connection = db.getConnDB
            Me.OleDbUpdateCommand_IDDokumenteneintrag.CommandTimeout = 0

            Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters("ID").Value = r.ID
            Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters("IDDokumenteneintrag").Value = r.IDDokumenteneintrag
            Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters("gelesen").Value = r.gelesen

            Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters("Original_ID").Value = r.ID
            Me.OleDbUpdateCommand_IDDokumenteneintrag.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

End Class
