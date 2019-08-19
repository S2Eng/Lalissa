Imports System.Data.OleDb


Public Class tblDokumenteGelesen

    Public gen As New GeneralArchiv()

    Public DataTable As New DataTable
    Private Command As New OleDbCommand
    Private DataAdapter As New OleDbDataAdapter
    Private Sql As String

    Public ID As System.Guid = Nothing
    Public IDDokumenteneintrag As System.Guid = Nothing
    Public gelesen As Boolean = False





    Public Sub SelectAllRowsUngelesen(ByVal von As Date, ByVal bis As Date)
        Try
            Me.Command.Parameters.Clear()
            Dim conn As New db
            '0 as MailSenden,
            Sql = " SELECT     '' as Firmenname, dbo.tblOrdner.Bezeichnung AS BezeichnungOrdner,  dbo.tblDokumenteintrag.Bezeichnung, dbo.tblDokumenteintrag.ErstelltVon, '' as EMailMakler, dbo.tblDokumente.IDDokumenteintrag, dbo.tblDokumente.Archivordner, dbo.tblDokumente.DateinameArchiv, dbo.tblDokumente.DateinameTyp, " +
                            " dbo.tblDokumente.DokumentGröße, dbo.tblDokumenteGelesen.ID AS IDDokumentGelesen, dbo.tblDokumenteGelesen.gelesen,  " +
                            " dbo.tblDokumenteintrag.IDOrdner, dbo.tblDokumenteintrag.GültigVon, dbo.tblDokumenteintrag.GültigBis, " +
                            " dbo.tblDokumenteintrag.ErstelltAm,  " +
                            " dbo.tblObjekt.ID_guid, dbo.tblDokumenteGelesen.anzahlBenachrichtigt   " +
                            " FROM         dbo.tblDokumente INNER JOIN " +
                            " dbo.tblDokumenteintrag ON dbo.tblDokumente.IDDokumenteintrag = dbo.tblDokumenteintrag.ID INNER JOIN " +
                            " dbo.tblDokumenteGelesen ON dbo.tblDokumenteintrag.ID = dbo.tblDokumenteGelesen.IDDokumenteneintrag INNER JOIN " +
                            " dbo.tblObjekt ON dbo.tblDokumenteintrag.ID = dbo.tblObjekt.IDDokumenteintrag INNER JOIN " +
                            " dbo.tblOrdner ON dbo.tblDokumenteintrag.IDOrdner = dbo.tblOrdner.ID " +
                            " where dbo.tblDokumenteGelesen.gelesen = ? "

            If Not gen.IsNull(von) Then
                Sql += " and  dbo.tblDokumente.ErstelltAm >= ?  "
            End If
            If Not gen.IsNull(bis) Then
                Sql += " and  dbo.tblDokumente.ErstelltAm <= ?  "
            End If
            Command = New OleDbCommand(Sql, conn.getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.Boolean, 1, "gelesen")).Value = False
            If Not gen.IsNull(von) Then
                Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbo.tblDokumente.ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "dbo.tblDokumente.ErstelltAm")).Value = von
            End If
            If Not gen.IsNull(bis) Then
                Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbo.tblDokumente.ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "dbo.tblDokumente.ErstelltAm")).Value = bis
            End If
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)

        Catch ex As OleDbException
            Throw New Exception("SelectAllRowsUngelesen: " + ex.ToString())
        End Try
    End Sub
    Public Function readAnzahlBenachrichtigt(ByVal IDDokumenteneintrag As System.Guid) As Integer
        Try
            Me.Command.Parameters.Clear()
            Dim conn As New db

            Sql = "  select * from tblDokumenteGelesen where IDDokumenteneintrag = ? "
            Command = New OleDbCommand(Sql, conn.getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")).Value = IDDokumenteneintrag
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)

            If Me.DataTable.Rows.Count > 0 Then
                Return (Me.DataTable.Rows(0)("anzahlBenachrichtigt") + 1)
            End If

        Catch ex As OleDbException
            Throw New Exception("readAnzahlBenachrichtigt: " + ex.ToString())
        End Try
    End Function

    Public Function UpdateRow_gelesen(ByVal IDDokumenteneintrag As System.Guid) As Boolean
        Try
            Dim comm As New OleDbCommand
            Dim conn As New db

            comm.CommandText = "UPDATE tblDokumenteGelesen SET  gelesen = ? WHERE  IDDokumenteneintrag = ? "
            comm.Connection = conn.getConnDB

            comm.Parameters.Add(New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.Boolean, 1, "gelesen")).Value = gelesen
            comm.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")).Value = IDDokumenteneintrag
            comm.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow_gelesen: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateRow_AnzahlGelesen(ByVal IDDokumenteneintrag As System.Guid) As Boolean
        Try
            Dim comm As New OleDbCommand
            Dim conn As New db
            comm.CommandText = "UPDATE tblDokumenteGelesen SET  anzahlBenachrichtigt = ? WHERE  IDDokumenteneintrag = ? "
            comm.Connection = conn.getConnDB
            Dim anzGesendet As Integer = Me.readAnzahlBenachrichtigt(IDDokumenteneintrag)
            comm.Parameters.Add(New System.Data.OleDb.OleDbParameter("anzahlBenachrichtigt", System.Data.OleDb.OleDbType.Integer, 4, "anzahlBenachrichtigt")).Value = anzGesendet
            comm.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")).Value = IDDokumenteneintrag
            comm.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("UpdateRow_AnzahlGelesen: " + ex.ToString())
        End Try
    End Function

End Class
