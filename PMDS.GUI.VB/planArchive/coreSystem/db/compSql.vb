Imports System.Data.OleDb
Imports RBU


Public Class compSql

    Public dtGruppen As New DataTable
    Public tBenutzer As New DataTable

    Private gen As New GeneralArchiv
    Private db As New db


    Public Enum etyp
        dokumente = 0
    End Enum
    Public Enum eTypObj
        guid = 0
        str = 1
        int = 2
    End Enum





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
            Throw New Exception("insertGelesenJN: " + ex.ToString())
        End Try
    End Function


    Public Function LesenDokument_IDDokueintrag(ByVal IDDokumenteintrag As System.Guid) As dsPlanArchive.tblDokumenteSmallRow
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumente_IDDokueintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumente_IDDokueintrag.CommandTimeout = 0
            Me.daDokumente_IDDokueintrag.SelectCommand = Me.OleDbSelectCommand_Dokumente_IDDokueintrag
            Me.daDokumente_IDDokueintrag.SelectCommand.Parameters("IDDokumenteintrag").Value = IDDokumenteintrag
            Me.daDokumente_IDDokueintrag.Fill(data.tblDokumenteSmall)

            If data.tblDokumenteSmall.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblDokumenteSmallRow
                r = data.tblDokumenteSmall.NewRow
                r = data.tblDokumenteSmall.Rows(0)
                Return r
            End If

            Return Nothing

        Catch ex As Exception
            Throw New Exception("LesenDokument_IDDokueintrag: " + ex.ToString())
        End Try
    End Function

    Public Function LesenDokumenteintrag(ByVal ID As System.Guid) As dsPlanArchive.tblDokumenteintragRow
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumenteintrag_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumenteintrag_ID.CommandTimeout = 0
            Me.daDokumenteintrag_ID.SelectCommand = Me.OleDbSelectCommand_Dokumenteintrag_ID
            Me.daDokumenteintrag_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daDokumenteintrag_ID.Fill(data)

            Dim ret As New ArrayList
            If data.tblDokumenteintrag.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblDokumenteintragRow
                r = data.tblDokumenteintrag.NewRow
                r = data.tblDokumenteintrag.Rows(0)
                Return r
            End If

        Catch ex As Exception
            Throw New Exception("LesenDokumenteintrag: " + ex.ToString())
        End Try
    End Function

    Public Function insertDokument(ByVal r As dsPlanArchive.tblDokumenteSmallRow) As Boolean
        Try

            Me.OleDbInsertCommand_Dokumente_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_Dokumente_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("IDDokumenteintrag").Value = r.IDDokumenteintrag
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameOrig").Value = r.DateinameOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("VerzeichnisOrig").Value = r.VerzeichnisOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGröße").Value = r.DokumentGröße
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentErstellt").Value = r.DokumentErstellt
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGeändert").Value = r.DokumentGeändert
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltVon").Value = r.ErstelltVon
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Winzip").Value = r.Winzip
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Archivordner").Value = r.Archivordner
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameArchiv").Value = r.DateinameArchiv
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameTyp").Value = r.DateinameTyp

            Me.OleDbInsertCommand_Dokumente_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("insertDokument: " + ex.ToString())
        End Try
    End Function

    Public Function insertDokumenteintrag(ByVal r As dsPlanArchive.tblDokumenteintragRow) As Boolean
        Try

            Me.OleDbInsertCommand_Dokumenteintrag_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_Dokumenteintrag_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("IDOrdner").Value = r.IDOrdner
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Bezeichnung").Value = r.Bezeichnung
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Notiz").Value = r.Notiz
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("NotizRTF").Value = System.DBNull.Value
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigVon").Value = gen.proveDateTime(r.GültigVon)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigBis").Value = gen.proveDateTime(r.GültigBis)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Wichtigkeit").Value = r.Wichtigkeit
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltVon").Value = r.ErstelltVon

            Me.OleDbInsertCommand_Dokumenteintrag_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("insertDokumenteintrag: " + ex.ToString())
        End Try
    End Function
    Public Function DokumenteneintragLöschen(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.CommandTimeout = 0
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.Parameters("Original_ID").Value = ID
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("DokumenteneintragLöschen: " + ex.ToString())
        End Try
    End Function





    Public Function pfadLesen() As String
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Pfad.CommandTimeout = 0
            Me.daPfad.SelectCommand = Me.OleDbSelectCommand_Pfad
            data.Clear()
            Me.daPfad.Fill(data)
            If data.tblPfad.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblPfadRow
                r = data.tblPfad.Rows(0)
                Return r.Archivpfad
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("pfadLesen: " + ex.ToString())
        End Try
    End Function
    Public Sub WritePfad(ByVal pfad As String)
        Try

            Me.deletePfad()

            Dim conn As New db
            Me.OleDbInsertCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Pfad.CommandTimeout = 0
            Me.OleDbInsertCommand_Pfad.Parameters("Archivpfad").Value = pfad
            Me.OleDbInsertCommand_Pfad.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("WritePfad: " + ex.ToString())
        End Try
    End Sub
    Public Function deletePfad() As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Pfad.CommandTimeout = 0
            Me.OleDbDeleteCommand_Pfad.CommandText = "DELETE FROM tblPfad "
            Me.OleDbDeleteCommand_Pfad.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deletePfad: " + ex.ToString())
        End Try
    End Function


    Public Function getRechtOrdnerGruppe(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = conn.getConnDB
            Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.CommandTimeout = 0
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand = Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand.Parameters("IDOrdner").Value = IDOrdner
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand.Parameters("IDGruppe").Value = IDGruppe
            Me.daRechteOrdner_IDOrdnerIDGruppe.Fill(data)
            If data.Tables(0).Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblRechteOrdnerRow
                r = data.Tables(0).Rows(0)
                Return True
            End If
            Return False

        Catch ex As Exception
            Throw New Exception("getRechtOrdnerGruppe: " + ex.ToString())
        End Try
    End Function

    Public Function writeRecht(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid, ByVal RechtJN As Boolean) As Boolean
        Try

            If RechtJN Then
                Dim r_recht As dsPlanArchive.tblRechteOrdnerRow
                Dim data As New dsPlanArchive
                r_recht = data.tblRechteOrdner.NewRow
                r_recht.ID = System.Guid.NewGuid
                r_recht.IDOrdner = IDOrdner
                r_recht.IDGruppe = IDGruppe
                Me.insertRecht(r_recht)
            Else
                Me.deleteRecht(IDOrdner, IDGruppe)
            End If

        Catch ex As Exception
            Throw New Exception("writeRecht: " + ex.ToString())
        End Try
    End Function
    Public Sub insertRecht(ByVal r_recht As dsPlanArchive.tblRechteOrdnerRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = conn.getConnDB
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.CommandTimeout = 0

            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("ID").Value = r_recht.ID
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDOrdner").Value = r_recht.IDOrdner
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDGruppe").Value = r_recht.IDGruppe

            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertRecht: " + ex.ToString())
        End Try
    End Sub
    Public Function deleteRecht(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid) As Boolean
        Try
            Using Command As New OleDbCommand
                Dim conn As New db

                Command.Parameters.Clear()
                Command.CommandText = "DELETE FROM  tblRechteOrdner  WHERE  IDOrdner  = ? and IDGruppe = ? "
                Command.Connection = conn.getConnDB
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")).Value = IDOrdner
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")).Value = IDGruppe
                Command.ExecuteNonQuery()
            End Using

        Catch ex As OleDbException
            Throw New Exception("deleteRecht: " + ex.ToString())
        End Try
    End Function





    Public Function LesenAlleSchränke() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schränke.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schränke.CommandTimeout = 0
            Me.daSchränkeAlle.SelectCommand = Me.OleDbSelectCommand_Schränke
            data.Clear()
            Me.daSchränkeAlle.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenAlleSchränke: " + ex.ToString())
        Finally
        End Try
    End Function
    Public Function AlleDateienAusPapierkorbLesen() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_AlleDateienPapierkorb.Connection = conn.getConnDB
            Me.OleDbSelectCommand_AlleDateienPapierkorb.CommandTimeout = 0
            Me.daAlleDateienPapierkorb.SelectCommand = Me.OleDbSelectCommand_AlleDateienPapierkorb
            Me.daAlleDateienPapierkorb.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("AlleDateienAusPapierkorbLesen: " + ex.ToString())
        End Try
    End Function

    Public Function ExistiertSchrank(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schrank_ID.CommandTimeout = 0
            Me.daSchrank_ID.SelectCommand = Me.OleDbSelectCommand_Schrank_ID
            Me.daSchrank_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daSchrank_ID.Fill(data)
            If data.tblSchrank.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ExistiertSchrank: " + ex.ToString())
        End Try
    End Function
    Public Function SchränkeSpeichern(ByRef dsSchränke As dsPlanArchive) As Boolean
        Try

            For Each r_schrank As dsPlanArchive.tblSchrankRow In dsSchränke.tblSchrank
                If Me.ExistiertSchrank(r_schrank.ID) Then
                    Me.updateSchrank(r_schrank)
                Else
                    Me.insertSchrank(r_schrank)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("SchränkeSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Sub insertSchrank(ByVal r_schrank As dsPlanArchive.tblSchrankRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Schrank_ID.Parameters("ID").Value = r_schrank.ID
            Me.OleDbInsertCommand_Schrank_ID.Parameters("Bezeichnung").Value = r_schrank.Bezeichnung
            Me.OleDbInsertCommand_Schrank_ID.Parameters("ErstelltAm").Value = r_schrank.ErstelltAm
            Me.OleDbInsertCommand_Schrank_ID.Parameters("ErstelltVon").Value = r_schrank.ErstelltVon
            Me.OleDbInsertCommand_Schrank_ID.Parameters("Extern").Value = r_schrank.Extern

            Me.OleDbInsertCommand_Schrank_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertSchrank: " + ex.ToString())
        End Try
    End Sub
    Public Sub updateSchrank(ByVal r_schrank As dsPlanArchive.tblSchrankRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ID").Value = r_schrank.ID
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Bezeichnung").Value = r_schrank.Bezeichnung
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ErstelltAm").Value = r_schrank.ErstelltAm
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ErstelltVon").Value = r_schrank.ErstelltVon
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Extern").Value = r_schrank.Extern
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Original_ID").Value = r_schrank.ID

            Me.OleDbUpdateCommand_Schrank_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("updateSchrank: " + ex.ToString())
        End Try
    End Sub

    Public Function LesenDatenFürDokument(ByVal IDDokumenteneintrag As System.Guid) As dsPlanArchive
        Try
            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandTimeout = 0
            Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
            Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand.Parameters("ID").Value = IDDokumenteneintrag
            Me.daDokumentendaten_IDDokumenteneintrag.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenDatenFürDokument: " + ex.ToString())
        End Try
    End Function

    Public Function LesenAlleFächer(ByVal IDSchrank As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Fächer_IDSchrank.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Fächer_IDSchrank.CommandTimeout = 0
            Me.daFächer_IDSchrank.SelectCommand = Me.OleDbSelectCommand_Fächer_IDSchrank
            Me.daFächer_IDSchrank.SelectCommand.Parameters("IDSchrank").Value = IDSchrank
            Me.daFächer_IDSchrank.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenAlleFächer: " + ex.ToString())
        End Try
    End Function
    Public Function ExistiertFach(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Fächer_ID.CommandTimeout = 0
            Me.daFächer_ID.SelectCommand = Me.OleDbSelectCommand_Fächer_ID
            Me.daFächer_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daFächer_ID.Fill(data)
            If data.tblFach.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ExistiertFach: " + ex.ToString())
        End Try
    End Function
    Public Function FächerSpeichern(ByRef dsFächer As dsPlanArchive) As Boolean
        Try

            For Each r_fach As dsPlanArchive.tblFachRow In dsFächer.tblFach
                If Me.ExistiertFach(r_fach.ID) Then
                    Me.updateFach(r_fach)
                Else
                    Me.insertFach(r_fach)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("FächerSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Sub insertFach(ByVal r_fach As dsPlanArchive.tblFachRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Fächer_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbInsertCommand_Fächer_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbInsertCommand_Fächer_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbInsertCommand_Fächer_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbInsertCommand_Fächer_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbInsertCommand_Fächer_ID.Parameters("Extern").Value = r_fach.Extern

            Me.OleDbInsertCommand_Fächer_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertFach: " + ex.ToString())
        End Try
    End Sub
    Public Sub updateFach(ByVal r_fach As dsPlanArchive.tblFachRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Original_ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Extern").Value = r_fach.Extern
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Original_ID").Value = r_fach.ID

            Me.OleDbUpdateCommand_Fächer_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("updateFach: " + ex.ToString())
        End Try
    End Sub

    Public Function LesenAlleOrdner(ByVal IDFach As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Ordner_IDFach.CommandTimeout = 0
            Me.daOrdner_IDFach.SelectCommand = Me.OleDbSelectCommand_Ordner_IDFach
            Me.daOrdner_IDFach.SelectCommand.Parameters("IDFach").Value = IDFach
            Me.daOrdner_IDFach.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenAlleOrdner: " + ex.ToString())
        End Try
    End Function
    Public Function ExistiertPapierkorbJN() As Boolean
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Using data As New DataTable
                Dim conn As New db
                Dim Sql As String = "SELECT *  FROM tblOrdner where IDSystemordner = 1 "
                Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
                Command.CommandTimeout = 0
                DataAdapter.SelectCommand = Command
                DataAdapter.Fill(data)
                If data.Rows.Count = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("ExistiertPapierkorbJN: " + ex.ToString())
        End Try
    End Function
    Public Function GetIDOrdnerPapierkorb() As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Using data As New DataTable
                Dim conn As New db
                Dim Sql As String = "SELECT ID  FROM tblOrdner where IDSystemordner = 1 "
                Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
                Command.CommandTimeout = 0
                DataAdapter.SelectCommand = Command
                DataAdapter.Fill(data)
                If data.Rows.Count = 1 Then
                    Return data.Rows(0)("ID")
                End If
            End Using
            Return Nothing

        Catch ex As Exception
            Throw New Exception("GetIDOrdnerPapierkorb: " + ex.ToString())
        End Try
    End Function
    Public Function GetIDOrdnerAnhangPlanungssystem() As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Using data As New DataTable
                Dim conn As New db
                Dim Sql As String = "SELECT ID  FROM tblOrdner where IDSystemordner = 2 "
                Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
                Command.CommandTimeout = 0
                DataAdapter.SelectCommand = Command
                DataAdapter.Fill(data)
                If data.Rows.Count = 1 Then
                    Return data.Rows(0)("ID")
                End If
            End Using
            Return Nothing

        Catch ex As Exception
            Throw New Exception("GetIDOrdnerAnhangPlanungssystem: " + ex.ToString())
        End Try
    End Function
    Public Function GetOrdnerBiografie(ByVal bez As String) As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Using data As New DataTable
                Dim conn As New db
                Dim Sql As String = "SELECT ID  FROM tblOrdner where Bezeichnung = '" + bez + "' "
                Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
                Command.CommandTimeout = 0
                DataAdapter.SelectCommand = Command
                DataAdapter.Fill(data)
                If data.Rows.Count = 1 Then
                    Return data.Rows(0)("ID")
                End If
            End Using
            Return Nothing

        Catch ex As Exception
            Throw New Exception("GetOrdnerBiografie: " + ex.ToString())
        End Try
    End Function

    Public Sub insertOrdner(ByVal r_ordner As dsPlanArchive.tblOrdnerRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ID").Value = r_ordner.ID
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Bezeichnung").Value = r_ordner.Bezeichnung
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("IDFach").Value = r_ordner.IDFach
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ErstelltAm").Value = r_ordner.ErstelltAm
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ErstelltVon").Value = r_ordner.ErstelltVon
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Icon").Value = Nothing
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Extern").Value = r_ordner.Extern
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("IDSystemordner").Value = r_ordner.IDSystemordner

            Me.OleDbInsertCommand_Ordner_IDFach.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertOrdner: " + ex.ToString())
        End Try
    End Sub
    Public Function updateOrdner(ByVal r_ordner As dsPlanArchive.tblOrdnerRow) As Boolean
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ID").Value = r_ordner.ID
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Bezeichnung").Value = r_ordner.Bezeichnung
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("IDFach").Value = r_ordner.IDFach
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ErstelltAm").Value = r_ordner.ErstelltAm
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ErstelltVon").Value = r_ordner.ErstelltVon
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Icon").Value = Nothing
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Extern").Value = r_ordner.Extern
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Original_ID").Value = r_ordner.ID
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("IDSystemordner").Value = r_ordner.IDSystemordner

            Me.OleDbUpdateCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("updateOrdner: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateIDOrdner_Dokumenteintrag(ByVal IDDokumenteintrag As System.Guid, ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New dsPlanArchive
            Dim conn As New db
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0

            Command.CommandText = "UPDATE tblDokumenteintrag SET  IDOrdner = ?  WHERE ID = ? "
            Command.Connection = conn.getConnDB
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")).Value = IDOrdner
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDokumenteintrag
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("UpdateIDOrdner_Dokumenteintrag: " + ex.ToString())
        End Try
    End Function
    Public Function updateOrdner_CleyrSystemordner(ByVal IDSystemordner As Integer) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand
            Dim conn As New db
            Command.CommandText = "UPDATE tblOrdner SET  IDSystemordner = -1  WHERE IDSystemordner = ? "
            Command.Connection = conn.getConnDB
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.Integer, 4, "IDSystemordner")).Value = IDSystemordner
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("updateOrdner_CleyrSystemordner: " + ex.ToString())
        End Try
    End Function
    Public Function updateOrdnerExternIntern(ByVal IDOrdner As System.Guid, ByVal extern As Boolean) As Boolean
        Try
            Dim conn As New db

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Clear()
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandText = "UPDATE tblOrdner SET   Extern = ? WHERE (ID = ?)"
            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = conn.getConnDB

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Add(New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.Boolean, 1, "Extern"))
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))

            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Extern").Value = extern
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Original_ID").Value = IDOrdner

            Me.OleDbUpdateCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("updateOrdnerExternIntern: " + ex.ToString())
        End Try
    End Function
    Public Function deleteOrdner(ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbDeleteCommand_Ordner_IDFach.Parameters("Original_ID").Value = IDOrdner
            Me.OleDbDeleteCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteOrdner: " + ex.ToString())
        End Try
    End Function



    Public Function deleteSchrank(ByVal IDSchrank As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Schrank_ID.Parameters("Original_ID").Value = IDSchrank
            Me.OleDbDeleteCommand_Schrank_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteSchrank: " + ex.ToString())
        End Try
    End Function
    Public Function deleteFächer(ByVal IDFach As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Fächer_ID.Parameters("Original_ID").Value = IDFach
            Me.OleDbDeleteCommand_Fächer_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteFächer: " + ex.ToString())
        End Try
    End Function






    Public Function LesenAllerThemenUndSchlagwörter() As dsPlanArchive
        Try
            Dim data As New dsPlanArchive
            Dim UIElements1 As New UIElements()
            Dim lstTablesNotDelete As New System.Collections.Generic.List(Of String)()
            lstTablesNotDelete.Add(data.tblThemen.TableName.Trim())
            lstTablesNotDelete.Add(data.tblSchlagwörter.TableName.Trim())
            UIElements1.deleteTablesFromDataSet(data, lstTablesNotDelete)

            Dim conn As New db
            Me.OleDbSelectCommand_Thema_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_All.CommandTimeout = 0
            Me.daThema_All.SelectCommand = Me.OleDbSelectCommand_Thema_All
            Me.daThema_All.Fill(data.tblThemen)

            Me.OleDbSelectCommand_Schlagwort_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_All.CommandTimeout = 0
            Me.daSchlagwort_All.SelectCommand = Me.OleDbSelectCommand_Schlagwort_All
            Me.daSchlagwort_All.Fill(data.tblSchlagwörter)

            Dim view As New DataView
            Dim rel_thema As New DataRelation("RelAufgabenArt", data.tblThemen.Columns("ID"), data.tblSchlagwörter.Columns("IDThema"))
            data.Relations.Add(rel_thema)

            Return data

        Catch ex As Exception
            Throw New Exception("LesenAllerThemenUndSchlagwörter: " + ex.ToString())
        End Try
    End Function
    Public Function LesenAllerThemen() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Thema_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_All.CommandTimeout = 0
            Me.daThema_All.SelectCommand = Me.OleDbSelectCommand_Thema_All
            Me.daThema_All.Fill(data.tblThemen)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenAllerThemen: " + ex.ToString())
        End Try
    End Function
    Public Function ExistiertThema(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_ID.CommandTimeout = 0
            Me.daThema_ID.SelectCommand = Me.OleDbSelectCommand_Thema_ID
            Me.daThema_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daThema_ID.Fill(data)
            If data.tblThemen.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ExistiertThema: " + ex.ToString())
        End Try
    End Function
    Public Function LesenAlleSchlagwörter(ByVal IDThema As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_IDThema.CommandTimeout = 0
            Me.daSchlagwort_IDThema.SelectCommand = Me.OleDbSelectCommand_Schlagwort_IDThema
            Me.daSchlagwort_IDThema.SelectCommand.Parameters("IDThema").Value = IDThema
            Me.daSchlagwort_IDThema.Fill(data.tblSchlagwörter)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenAlleSchlagwörter: " + ex.ToString())
        End Try
    End Function

    Public Function ThemaSpeichern(ByRef dsThema As dsPlanArchive) As Boolean
        Try

            For Each r_thema As dsPlanArchive.tblThemenRow In dsThema.tblThemen
                If Not Me.ExistiertThema(r_thema.ID) Then
                    Me.insertThema(r_thema)
                Else
                    Me.updateThema(r_thema)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("ThemaSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Sub insertThema(ByVal r_thema As dsPlanArchive.tblThemenRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Thema_ID.Parameters("ID").Value = r_thema.ID
            Me.OleDbInsertCommand_Thema_ID.Parameters("Thema").Value = r_thema.Thema
            Me.OleDbInsertCommand_Thema_ID.Parameters("ErstelltAm").Value = r_thema.ErstelltAm
            Me.OleDbInsertCommand_Thema_ID.Parameters("ErstelltVon").Value = r_thema.ErstelltVon

            Me.OleDbInsertCommand_Thema_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertThema: " + ex.ToString())
        End Try
    End Sub
    Public Sub updateThema(ByVal r_thema As dsPlanArchive.tblThemenRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Thema_ID.Parameters("ID").Value = r_thema.ID
            Me.OleDbUpdateCommand_Thema_ID.Parameters("Thema").Value = r_thema.Thema
            Me.OleDbUpdateCommand_Thema_ID.Parameters("ErstelltAm").Value = r_thema.ErstelltAm
            Me.OleDbUpdateCommand_Thema_ID.Parameters("ErstelltVon").Value = r_thema.ErstelltVon
            Me.OleDbUpdateCommand_Thema_ID.Parameters("Original_ID").Value = r_thema.ID

            Me.OleDbUpdateCommand_Thema_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("updateThema: " + ex.ToString())
        End Try
    End Sub

    Public Function ExistiertSchlagwort(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schlagwort_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_ID.CommandTimeout = 0
            Me.daSchlagwort_ID.SelectCommand = Me.OleDbSelectCommand_Schlagwort_ID
            Me.daSchlagwort_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daSchlagwort_ID.Fill(data)
            If data.tblSchlagwörter.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ExistiertSchlagwort: " + ex.ToString())
        End Try
    End Function
    Public Function SchlagwörterSpeichern(ByRef dsSchlagwörter As dsPlanArchive) As Boolean
        Try

            For Each r_schlagwort As dsPlanArchive.tblSchlagwörterRow In dsSchlagwörter.tblSchlagwörter
                If Not Me.ExistiertSchlagwort(r_schlagwort.ID) Then
                    Me.insertSchlagwörter(r_schlagwort)
                Else
                    Me.updateSchlagwörter(r_schlagwort)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("SchlagwörterSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Sub insertSchlagwörter(ByVal r_schlagwort As dsPlanArchive.tblSchlagwörterRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ID").Value = r_schlagwort.ID
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("IDThema").Value = r_schlagwort.IDThema
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("Schlagwort").Value = r_schlagwort.Schlagwort
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ErstelltAm").Value = r_schlagwort.ErstelltAm
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ErstelltVon").Value = r_schlagwort.ErstelltVon

            Me.OleDbInsertCommand_Schlagwort_IDThema.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertSchlagwörter: " + ex.ToString())
        End Try
    End Sub
    Public Sub updateSchlagwörter(ByVal r_schlagwort As dsPlanArchive.tblSchlagwörterRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ID").Value = r_schlagwort.ID
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("IDThema").Value = r_schlagwort.IDThema
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("Schlagwort").Value = r_schlagwort.Schlagwort
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ErstelltAm").Value = r_schlagwort.ErstelltAm
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ErstelltVon").Value = r_schlagwort.ErstelltVon
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("Original_ID").Value = r_schlagwort.ID

            Me.OleDbUpdateCommand_Schlagwort_IDThema.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("updateSchlagwörter: " + ex.ToString())
        End Try
    End Sub

    Public Function writeDokumenteneintragSchlagwörter(ByVal r As dsPlanArchive.tblDokumenteneintragSchlagwörterRow) As Boolean
        Try

            Me.insertDokumenteneintragSchlagwörter(r)

        Catch ex As Exception
            Throw New Exception("writeDokumenteneintragSchlagwörter: " + ex.ToString())
        End Try
    End Function

    Public Function insertDokumenteneintragSchlagwörter(ByVal r As dsPlanArchive.tblDokumenteneintragSchlagwörterRow)
        Try

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDSchlagwort").Value = r.IDSchlagwort
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDDokumenteneintrag").Value = r.IDDokumenteneintrag

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertDokumenteneintragSchlagwörter: " + ex.ToString())
        End Try
    End Function

    Public Sub deleteDokumenteneintragSchlagwörter(ByVal IDDokumenteneintrag As System.Guid)
        Try
            Dim conn As New db

            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandTimeout = 0
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters("Original_ID").Value = IDDokumenteneintrag
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("deleteDokumenteneintragSchlagwörter: " + ex.ToString())
        End Try
    End Sub

    Public Function deleteThema(ByVal IDThema As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Thema_ID.Parameters("Original_ID").Value = IDThema
            Me.OleDbDeleteCommand_Thema_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteThema: " + ex.ToString())
        End Try
    End Function
    Public Function deleteSchlagwort(ByVal IDSchlagwort As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbDeleteCommand_Schlagwort_IDThema.Parameters("Original_ID").Value = IDSchlagwort
            Me.OleDbDeleteCommand_Schlagwort_IDThema.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("deleteSchlagwort: " + ex.ToString())
        End Try
    End Function


    Public Sub qryDokumenteSuchen(ByVal Bezeichnung As String,
                                        ByVal Ordner As ArrayList, ByVal IDSchlagwörter As ArrayList,
                                        ByVal GültigVon As DateTime, ByVal GültigBis As DateTime,
                                        ByVal Wichtigkeit As String, ByVal objects As ArrayList,
                                        ByVal TypObjects As ArrayList,
                                        ByVal typSuche As etyp,
                                        ByVal AbgelegtVon As DateTime, ByVal AbgelegtBis As DateTime, ByVal benutzer As String,
                                        ByVal Papierkorb As Boolean, ByVal AnhangPlanungssystem As Boolean, ByVal nurPapierkorb As Boolean,
                                        ByVal imGesamtsystemSuchen As Boolean, ByRef data As dsPlanArchive, doInit As Boolean)
        Try
            Using DataTable As New DataTable
                Using Command As New OleDbCommand
                    Dim Parameter As OleDbParameter
                    Using DataAdapter As New OleDbDataAdapter
                        Dim Sql As String = ""
                        Dim SQL_where As String = ""

                        If typSuche = etyp.dokumente Then
                            Sql = "SELECT  dbo.tblDokumenteintrag.Bezeichnung, dbo.tblDokumente.Archivordner, dbo.tblDokumente.DateinameArchiv, dbo.tblDokumente.Winzip,  dbo.tblDokumente.DateinameOrig, dbo.tblDokumente.VerzeichnisOrig, dbo.tblDokumente.DokumentGröße, dbo.tblDokumente.DokumentErstellt, " +
                            " dbo.tblObjekt.ID_guid, (dbo.Patient.Vorname  + ' ' +  dbo.Patient.Nachname) as Patient," +
                            " dbo.tblDokumente.DokumentGeändert, dbo.tblDokumente.ErstelltAm, dbo.tblDokumente.ErstelltVon,   " +
                            " CAST(dbo.tblDokumente.IDDokumenteintrag AS Varchar(50)) AS IDDokumenteintrag, CAST(dbo.tblDokumente.ID AS Varchar(50)) AS IDDokument, dbo.tblDokumenteintrag.Notiz, dbo.tblDokumenteintrag.GültigVon,  " +
                            " dbo.tblDokumenteintrag.GültigBis, dbo.tblDokumenteintrag.Wichtigkeit, CAST(dbo.tblDokumenteintrag.IDOrdner AS Varchar(50)) AS IDOrdner, " +
                            " dbo.tblOrdner.Bezeichnung AS BezeichnungOrdner, dbo.tblOrdner.Extern , dbo.tblDokumente.DateinameTyp " +
                            " FROM dbo.Patient RIGHT OUTER JOIN " +
                            " dbo.tblObjekt ON dbo.Patient.ID = dbo.tblObjekt.ID_guid RIGHT OUTER JOIN " +
                            " dbo.tblDokumente INNER JOIN " +
                            " dbo.tblDokumenteintrag ON dbo.tblDokumente.IDDokumenteintrag = dbo.tblDokumenteintrag.ID INNER JOIN " +
                            " dbo.tblOrdner ON dbo.tblDokumenteintrag.IDOrdner = dbo.tblOrdner.ID ON dbo.tblObjekt.IDDokumenteintrag = dbo.tblDokumenteintrag.ID "
                        End If

                        If nurPapierkorb Then
                            Dim sql_subIDSystemordner As String = " orSys.IDSystemordner = 1 "
                            SQL_where += " where dbo.tblDokumenteintrag.IDOrdner IN ( SELECT distinct orSys.ID FROM  dbo.tblOrdner orSys where dbo.tblDokumenteintrag.IDOrdner = orSys.ID and ( " + sql_subIDSystemordner + " ))  "
                        Else
                            Dim sql_subIDSystemordner As String = " orSys.IDSystemordner = -1 "
                            If Papierkorb Then sql_subIDSystemordner += " or orSys.IDSystemordner = 1 "
                            If AnhangPlanungssystem Then sql_subIDSystemordner += " or orSys.IDSystemordner = 2 "
                            SQL_where += " where dbo.tblDokumenteintrag.IDOrdner IN ( SELECT distinct orSys.ID FROM  dbo.tblOrdner orSys where dbo.tblDokumenteintrag.IDOrdner = orSys.ID and ( " + sql_subIDSystemordner + " ))  "

                        End If

                        If doInit Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.ID='" + System.Guid.NewGuid.ToString() + "' "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(Bezeichnung) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.Bezeichnung LIKE '%" + Bezeichnung + "%' "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(Wichtigkeit) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.Wichtigkeit = '" + Wichtigkeit + "' "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(GültigVon) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.GültigVon >= ? "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(GültigBis) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.GültigBis <= ? "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(AbgelegtVon) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltAm >= ? "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(AbgelegtBis) Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltAm <= ? "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        If Not gen.IsNull(IDSchlagwörter) Then
                            If IDSchlagwörter.Count > 0 Then
                                Dim sql_id As String = ""
                                For Each id As System.Guid In IDSchlagwörter
                                    Dim id_str As String = " ds.IDSchlagwort = '" + id.ToString + "' "
                                    sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
                                Next
                                Dim sql_sub As String = " ( SELECT Count(*) FROM  dbo.tblDokumenteneintragSchlagwörter ds " +
                                            " where ds.IDDokumenteneintrag = dbo.tblDokumente.IDDokumenteintrag and ( " + sql_id + ")) > 0 "
                                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                            End If
                        End If
                        If objects.Count > 0 Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.ID IN (Select IDDokumenteintrag from tblObjekt "
                            Dim sql_ID As String = " "
                            For Each ob As clObject In objects
                                sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                                If ob.id.GetType.ToString = "System.Int32" Then
                                    sql_ID += " ID_int = " + ob.id.ToString + " "
                                ElseIf ob.id.GetType.ToString = "System.String" Then
                                    Try
                                        Dim str As String = ""
                                        Dim id As New System.Guid(ob.id.ToString)
                                        sql_ID += " ID_guid = '" + id.ToString + "' "
                                    Catch ex As Exception
                                        sql_ID += " ID_str = '" + ob.id + "' "
                                    End Try
                                End If
                            Next
                            sql_sub += sql_ID + ") "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        Else
                            If imGesamtsystemSuchen Then
                                If Not gen.IsNull(Trim(benutzer)) Then
                                    Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltVon = '" + benutzer + "' "
                                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                                End If
                            Else
                                Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltVon = '" + Me.gen.actUser + "' "
                                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                            End If
                        End If

                        If Ordner.Count > 0 Then
                            Dim sql_sub As String = " dbo.tblDokumenteintrag.IDOrdner IN (Select ID from tblOrdner "
                            Dim sql_ID As String = " "
                            For Each IDOrdner As Object In Ordner
                                Dim typ As New compSql.eTypObj
                                sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                                sql_ID += " ID = '" + IDOrdner.ToString + "' "
                            Next
                            sql_sub += sql_ID + ") "
                            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                        End If
                        Sql += SQL_where

                        Using Command1 = New OleDbCommand(Sql, db.getConnDB)
                            Command1.CommandTimeout = 0
                            If Not gen.IsNull(GültigVon) Then
                                Command1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 8, "GültigVon")).Value = GültigVon
                            End If
                            If Not gen.IsNull(GültigBis) Then
                                Command1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 8, "GültigBis")).Value = GültigBis
                            End If
                            If Not gen.IsNull(AbgelegtVon) Then
                                Command1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = AbgelegtVon
                            End If
                            If Not gen.IsNull(AbgelegtBis) Then
                                Command1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = AbgelegtBis
                            End If
                            DataAdapter.SelectCommand = Command

                            DataAdapter.Fill(data.tblDokumenteSuchen)
                        End Using
                    End Using
                End Using
            End Using


        Catch ex As OleDbException
            Throw New Exception("qryDokumenteSuchen: " + ex.ToString())
        End Try
    End Sub


    Public Function LesenObjekte_IDDokumenteintrag(ByVal IDDokumenteintrag As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_IDDokumenteintrag.CommandTimeout = 0
            Me.daObjects_IDDokumenteintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteintrag
            Me.daObjects_IDDokumenteintrag.SelectCommand.Parameters("IDDokumenteintrag").Value = IDDokumenteintrag
            Me.daObjects_IDDokumenteintrag.Fill(data)
            Return data

        Catch ex As Exception
            Throw New Exception("LesenObjekte_IDDokumenteintrag: " + ex.ToString())
        End Try
    End Function
    Public Sub insertObject(ByVal r_object As dsPlanArchive.tblObjektRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbInsertCommand_IDDokumenteintrag.CommandTimeout = 0

            Dim db As New db
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID").Value = r_object.ID
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("IDDokumenteintrag").Value = r_object.IDDokumenteintrag
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Datenbankidentität").Value = r_object.Datenbankidentität
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Server").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Datenbank").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Benutzer").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Passwort").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("IDTyp").Value = 0

            If Not gen.IsNull(r_object.ID_guid) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = r_object.ID_guid
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = Nothing
            ElseIf Not gen.IsNull(r_object.ID_str) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = r_object.ID_str
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = Nothing
            ElseIf Not gen.IsNull(r_object.ID_int) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = r_object.ID_int
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = Nothing
            Else
                Throw New Exception("compObjekt.insertObject: kein Wert wurde für den Objecteintrag angegeben!")
            End If
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("bezeichnung").Value = r_object.bezeichnung

            Me.OleDbInsertCommand_IDDokumenteintrag.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("insertObject: " + ex.ToString())
        End Try
    End Sub

    Public Function Info_ReadObjekteSuche(ByVal IDDokumenteintrag As System.Guid) As String
        Dim gen As New GeneralArchiv
        Try
            Dim ui As New UIElements()
            Dim textTyp As String = ""
            Dim comp As New compSql
            Dim data As New dsPlanArchive
            data = comp.LesenObjekte_IDDokumenteintrag(IDDokumenteintrag)
            For Each r As dsPlanArchive.tblObjektRow In data.tblObjekt
                If Not r.IsID_guidNull Then
                    textTyp += "        Objekt guid: " + r.ID_guid.ToString + vbNewLine
                ElseIf Not r.IsID_intNull Then
                    textTyp += "        Objekt Int: " + r.ID_int.ToString + vbNewLine
                ElseIf Not r.IsID_strNull Then
                    textTyp += "        Objekt Text: " + r.ID_str + vbNewLine
                Else
                    Throw New Exception("clObjekte.Info_ReadObjekteSuche: kein Wert wurde für den Objecteintrag angegeben!")
                End If
            Next

            If Not gen.IsNull(textTyp) Then
                textTyp = "Beziehungen:" + vbNewLine + textTyp
            End If
            Return textTyp

        Catch ex As Exception
            Throw New Exception("Info_ReadObjekteSuche: " + ex.ToString())
        End Try
    End Function

    Public Sub ObjekteAblegen(ByRef objects As ArrayList, ByRef tree As Infragistics.Win.UltraWinTree.UltraTree)
        Dim gen As New GeneralArchiv
        Try
            Dim comp As New compSql
            Dim key As Integer = 1
            Dim firstItem As Infragistics.Win.UltraWinTree.UltraTreeNode

            If Not tree.Nodes.Exists(key) Then
                firstItem = tree.Nodes.Add(key, "Beziehungen:")
            End If

            'For Each aktOb As Object In objects
            For act As Integer = 0 To objects.Count - 1
                Dim aktObj As New clObject
                aktObj = objects.Item(act)

                Dim typ As New compSql.eTypObj
                If aktObj.id.GetType.ToString = "System.String" Then
                    Try
                        'Dim ID As New System.Guid(objects.Item(act).ToString)
                        typ = compSql.eTypObj.guid
                        If Not gen.IsNull(aktObj.id) Then
                            Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                            Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                            Item.Tag = aktObj.id.ToString

                        End If
                    Catch ex As Exception
                        Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                        Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                        Item.Tag = aktObj.id
                    End Try

                ElseIf aktObj.id.GetType.ToString = "System.Int32" Then
                    Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                    Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                    Item.Tag = aktObj.id

                Else
                    Throw New Exception("clObjekte.Info_ReadObjekteAblegen: kein Wert wurde für den Objecteintrag angegeben!")
                End If

            Next

        Catch ex As Exception
            Throw New Exception("ObjekteAblegen: " + ex.ToString())
        End Try
    End Sub

End Class
