Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Xml



Public Class cArchive

    Private gen As New GeneralArchiv
    Public Shared IDPapierkorb As New System.Guid("00000000-0000-7000-0000-000000000001")







    Public Function deleteDokument(ByVal IDDoku As System.Guid, ByVal withMsgBox As Boolean) As Boolean
        Try
            If Not gen.IsNull(IDDoku) Then
                Dim ret As MsgBoxResult
                If withMsgBox Then
                    ret = doUI.doMessageBox3("DoYouRealyWantToDeleteTheDocument", "DeleteDocument", MsgBoxStyle.YesNo, "?")
                Else
                    ret = MsgBoxResult.Yes
                End If
                If ret = MsgBoxResult.Yes Then
                    Dim compDoku1 As New compDoku()
                    Dim rDoku As dbArchiv.archDokuRow = compDoku1.getDokuRow(IDDoku, New dbArchiv())
                    If Not rDoku Is Nothing Then
                        If compDoku1.deleteDoku(rDoku.ID) Then
                            If withMsgBox Then
                                doUI.doMessageBox2("ActivityPerformed", "Delete", "!")
                            End If
                            Return True
                        End If
                    Else
                        If withMsgBox Then
                            doUI.doMessageBox2("DocumentNotFound", "Delete", "!")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.deleteDokument: " + ex.ToString())
        End Try
    End Function
    Public Function dokuInPapierkorb(ByVal IDDoku As System.Guid, ByVal msgBoxJN As Boolean) As Boolean
        Try
            Dim compDoku1 As New compDoku()
            Dim rPapierkorb As dbArchiv.archOrdnerRow = compDoku1.getOrdnerRow(System.Guid.NewGuid(), compDoku.eTypSelOrd.getIDSys, New dbArchiv, 1)
            If rPapierkorb Is Nothing Then
                doUI.doMessageBox2("TrashDoesNotExists", "", "!")
                Return False
            End If

            If Not gen.IsNull(IDDoku) Then
                Dim res As MsgBoxStyle = MsgBoxResult.Yes
                If msgBoxJN Then
                    res = doUI.doMessageBox3("MoveToTrash", "Document", MsgBoxStyle.YesNo, "?")
                End If
                If res = MsgBoxResult.Yes Then
                    compDoku1.UpdateOrdDoku(IDDoku, rPapierkorb.ID)
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.dokuInPapierkorb: " + ex.ToString())
        End Try
    End Function

    Public Function getFileFromDB(ByVal Bezeichnung As String, ByVal DateiTyp As String, ByVal byteStream() As Byte) As String
        Try
            Dim file As String = Me.getFilename(qs2.functions.vb.functOld.path_temp, Bezeichnung, DateiTyp, 0, False)
            Using fs As New IO.FileStream(file, IO.FileMode.Create)
                fs.Write(byteStream, 0, byteStream.Length)
                Return file
            End Using

            'Dim file As String = Me.getFilename(qs2.functions.vb.functOld.path_temp, Bezeichnung, DateiTyp, 0, False)
            'Dim fs As IO.FileStream = New IO.FileStream(file, IO.FileMode.Create)
            'Dim b() As Byte = byteStream
            'fs.Write(b, 0, b.Length)
            'fs.Close()
            'Return file

        Catch ex As Exception
            Throw New Exception("cArchive.getFileFromDB: " + ex.ToString())
        End Try
    End Function
    Public Function getFilename(ByVal path As String, ByVal Bezeichnung As String,
                                ByVal DateiTyp As String, ByVal nr As String, ByVal deleteExistingFile As Boolean) As String
        Dim gen As New General
        Try
            Dim strOp As New QS2.functions.vb.functOld()
            Dim file As String = path + "\" + Bezeichnung + If(nr = 0, "", "_" + nr.ToString()) + DateiTyp

            If System.IO.File.Exists(file) Then
                If deleteExistingFile Then
                    Try
                        System.IO.File.Delete(file)
                        Return file
                    Catch ex As Exception
                        Return Me.getFilename(path, Bezeichnung, DateiTyp, nr + 1, deleteExistingFile)
                    End Try
                Else
                    Return Me.getFilename(path, Bezeichnung, DateiTyp, nr + 1, deleteExistingFile)
                End If
            Else
                Return file
            End If

        Catch ex As Exception
            Return Me.getFilename(path, Bezeichnung, DateiTyp, nr + 1, deleteExistingFile)
        End Try
    End Function
    Public Function saveDoku(ByVal arrInfo As System.Collections.Generic.List(Of clFileInfo), ByVal Notiz As String,
                                            ByVal GültigVon As Date, ByVal GültigBis As Date,
                                            ByVal Wichtigkeit As String, ByVal arrFilesToDelete As ArrayList,
                                            ByVal Schlagwörter As ArrayList, ByVal sTyp As String, ByVal sStatus As String,
                                            ByRef IDActivity As System.Guid) As clRet
        Try
            Dim ret As New clRet

            Dim compDoku1 As New compDoku()
            Dim anzAbgel As Integer = 0
            Dim arrIDDokumenteintrag As New ArrayList
            For Each info As clFileInfo In arrInfo
                Dim gIDNeuerDateiname As New System.Guid
                gIDNeuerDateiname = System.Guid.NewGuid
                ' Dokument speichern
                Dim IDDoku As New System.Guid
                IDDoku = System.Guid.NewGuid()
                Dim ok As Boolean = Me.saveDoku(IDDoku, info, Notiz, GültigVon, GültigBis, Wichtigkeit, sTyp, sStatus, IDActivity)
                If ok Then
                    'If Me.saveFile(ablagepfad + "\" + DateinameArchiv, info.fileB) Then
                    If Me.saveSchlagw(IDDoku, Schlagwörter) Then
                        Me.saveObjects(IDDoku, info.tArchObject)
                        Me.delOrigFile(arrFilesToDelete)
                        anzAbgel += 1
                        arrIDDokumenteintrag.Add(IDDoku)
                    End If
                    'End If
                End If
            Next

            ret.anzAbgelegt = anzAbgel
            ret.OK = True
            ret.arrIDDoku = arrIDDokumenteintrag
            Return ret

        Catch ex As Exception
            Throw New Exception("cArchive.saveDoku: " + ex.ToString())
        End Try
    End Function
    Public Function saveDoku(ByVal IDDoku As System.Guid, ByVal info As clFileInfo,
                                        ByVal Notiz As String, ByVal GültigVon As Date, ByVal GültigBis As Date,
                                        ByVal Wichtigkeit As String, ByVal sTyp As String, ByVal sStatus As String,
                                        ByRef IDActivity As System.Guid) As Boolean
        Try
            Dim ret As New clRet
            Dim gen As New General()

            Dim dbArchiv1 As New dbArchiv()
            Dim compDoku1 As New compDoku()
            compDoku1.getDokuRow(System.Guid.NewGuid, dbArchiv1)
            Dim rNew As dbArchiv.archDokuRow = compDoku1.getNewRowDoku(dbArchiv1)
            rNew.ID = IDDoku
            rNew.IDOrdner = info.file_IDOrdner
            rNew.Bezeichnung = info.file_Bezeichnung
            rNew.Notiz = Trim(Notiz)
            If gen.IsNull(GültigVon) Then
                rNew.SetGültigVonNull()
            Else
                rNew.GültigVon = GültigVon
            End If
            If gen.IsNull(GültigBis) Then
                rNew.SetGültigBisNull()
            Else
                rNew.GültigBis = GültigBis
            End If

            rNew.intReleased = info.intReleased
            If Not info.binIntern Is Nothing Then
                rNew.binIntern = info.binIntern
            End If

            If gen.IsNull(IDActivity) Then
                rNew.SetIDActivityNull()
            Else
                rNew.IDActivity = IDActivity
            End If

            If sTyp.Trim() = "" Then
                rNew.IsIDTypNull()
            Else
                rNew.IDTyp = sTyp
            End If
            If sStatus.Trim() = "" Then
                rNew.IsIDStatusNull()
            Else
                rNew.IDStatus = sStatus
            End If

            rNew.Größe = info.file_größe
            rNew.Wichtigkeit = Wichtigkeit

            Dim UserLoggedIn As String = gen.getLoggedInUser()
            rNew.AbgelegtVon = UserLoggedIn.Trim()
            rNew.AbgelegtAm = Now
            rNew.Winzip = False
            rNew.DateinameArchiv = ""
            rNew.Archivordner = ""
            rNew.DateinameTyp = info.file_typ
            rNew.doku = info.fileB  ' Me.convertDokuToByte(info.file_origVerzeichnis + "\" + info.file_name)
            compDoku1.daDoku.Update(dbArchiv1.archDoku)
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.saveDoku: " + ex.ToString())
        End Try
    End Function
    Public Function saveSchlagw(ByVal IDDoku As System.Guid, ByVal Schlagwörter As ArrayList) As Boolean
        Try
            Dim compDoku1 As New compDoku()
            compDoku1.deleteDokuAllSchlagw(IDDoku)      ' alle Schlagwörter löschen
            For Each schlagw As String In Schlagwörter
                Dim dbNew As New dbArchiv()
                compDoku1.getDokuSchlag(System.Guid.NewGuid, compDoku.eTypSelDokuSchlagw.id, dbNew)
                Dim rNew As dbArchiv.archDokuSchlagRow = dbNew.archDokuSchlag.NewRow()
                rNew.ID = System.Guid.NewGuid
                rNew.IDDoku = IDDoku
                rNew.Schlagwort = schlagw
                dbNew.archDokuSchlag.Rows.Add(rNew)
                compDoku1.daDokuSchlag.Update(dbNew.archDokuSchlag)
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.saveSchlagw: " + ex.ToString())
        End Try
    End Function
    Public Function saveObjects(ByVal IDDokumenteintrag As System.Guid,
                                ByRef tArchObjects As dbArchiv.archObjectDataTable) As Boolean
        Try
            Dim compDoku1 As New compDoku()
            For Each rArchObject As dbArchiv.archObjectRow In tArchObjects
                Dim dbNew As New dbArchiv()
                compDoku1.getObject(System.Guid.NewGuid, compDoku.eTypSelObj.idDoku, dbNew)
                Dim rNew As dbArchiv.archObjectRow = dbNew.archObject.NewRow()
                rNew.ID = System.Guid.NewGuid
                rNew.IDDoku = IDDokumenteintrag
                'rNew.ObjectBezeichnung = ob.bezeichnung
                rNew.IDObject = rArchObject.IDObject
                If rArchObject.IsIDSelListNull() Then
                    rNew.SetIDSelListNull()
                Else
                    rNew.IDSelList = rArchObject.IDSelList
                End If
                dbNew.archObject.Rows.Add(rNew)
                compDoku1.daDocuObject.Update(dbNew.archObject)
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.saveObjects: " + ex.ToString())
        End Try
    End Function
    Private Sub delOrigFile(ByVal arrFilesToDelete As ArrayList)
        Try
            If gen.IsNull(arrFilesToDelete) Then Exit Sub

            Dim genMain As New General
            genMain.GarbColl()

            For Each file As String In arrFilesToDelete
                If System.IO.File.Exists(file) Then
                    Try
                        System.IO.File.Delete(file)
                    Catch ex As Exception
                    End Try
                End If
            Next

        Catch ex As Exception
            Throw New Exception("cArchive.delOrigFile: " + ex.ToString())
        End Try
    End Sub

    Public Function DokumentInsArchivAblegen(ByVal arrInfo As ArrayList, ByVal Notiz As String, ByVal GültigVon As Date, ByVal GültigBis As Date,
                                        ByVal Wichtigkeit As String, ByVal arrFilesToDelete As ArrayList,
                                        ByVal Objects As ArrayList,
                                        ByVal dataSchlagwortkatalog As dsPlanArchive, Optional ByVal alsUngelesenAblegen As Boolean = False) As clRet
        Try
            Dim ret As New clRet

            Dim compPfad As New compSql
            'If gen.IsNull(compPfad.pfadLesen()) Then
            '    MsgBox(gen.GetResString("ERRKeineAngabeDokuPfad"), MsgBoxStyle.Information, "Archivsystem")
            '    Return False
            'End If
            'If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
            '    MsgBox(gen.GetResString("ERRDokuPfadExistiertNicht"), MsgBoxStyle.Information,"Archivsystem")
            '    Return False
            'End If

            Dim anzAbgel As Integer = 0
            Dim arrIDDokumenteintrag As New ArrayList
            For Each info As clFileInfo In arrInfo

                'Pfade erstellen und überprüfen
                Dim db1 As New db()
                Dim aktTime As DateTime = db1.getAktTimeFromSQLServer()
                Dim ablagepfad_sub As String = aktTime.Year.ToString + "_" + aktTime.Month.ToString
                Dim ablagepfad As String = compPfad.pfadLesen() + "\" + ablagepfad_sub
                If Not System.IO.Directory.Exists(ablagepfad) Then
                    System.IO.Directory.CreateDirectory(ablagepfad)
                End If

                ' Dateinamen für Ablage ins Archiv erstellen
                Dim gIDNeuerDateiname As New System.Guid
                gIDNeuerDateiname = System.Guid.NewGuid
                Dim DateinameArchiv As String = aktTime.Year.ToString + aktTime.Month.ToString + aktTime.Day.ToString + "_" +
                                                aktTime.Hour.ToString + "_" + aktTime.Minute.ToString + "_" + aktTime.Second.ToString + "_" +
                                                gIDNeuerDateiname.ToString + info.file_typ
                Dim IDDokumenteintrag As New System.Guid
                IDDokumenteintrag = System.Guid.NewGuid

                ' Dokument speichern
                Dim retDokSp As New clRet
                retDokSp = Me.DokumentSpeichern(IDDokumenteintrag, DateinameArchiv, ablagepfad_sub, info, Notiz, GültigVon, GültigBis, Wichtigkeit)
                If retDokSp.OK Then
                    ' Datei physisch ablegen
                    If Me.DateiPhysischSpeichern(ablagepfad + "\" + DateinameArchiv, info.fileB) Then
                        ' Schlagwortkatalog
                        If Me.SchlagwortkatalogSpeichern(IDDokumenteintrag, dataSchlagwortkatalog) Then
                            Me.ObjectSpeichern(IDDokumenteintrag, Objects)
                            If alsUngelesenAblegen Then
                                Me.DokumentGelesenJN(IDDokumenteintrag, False)
                            End If
                            Me.Dateien_originalLöschen(arrFilesToDelete)
                            anzAbgel += 1
                            arrIDDokumenteintrag.Add(IDDokumenteintrag)
                        End If
                    End If
                End If
            Next

            ret.anzAbgelegt = anzAbgel
            ret.OK = True
            ret.arrIDDokumenteneintrag = arrIDDokumenteintrag
            Return ret

            'MsgBox(gen.GetResString("DateiWurdeInsArchivAbgelegt") + vbNewLine + _
            '           gen.GetResString("Anzahl") + " " + arrInfo.Count.ToString, MsgBoxStyle.Information, "Archivsystem")
            'arrInfo = Nothing

        Catch ex As Exception
            Throw New Exception("cArchive.DokumentInsArchivAblegen: " + ex.ToString())
        End Try
    End Function
    Public Sub Dateien_originalLöschen(ByVal arrFilesToDelete As ArrayList)
        Try
            If gen.IsNull(arrFilesToDelete) Then Exit Sub

            Dim genMain As New GeneralArchiv
            genMain.GarbColl()

            For Each file As String In arrFilesToDelete
                If System.IO.File.Exists(file) Then
                    Try
                        System.IO.File.Delete(file)
                    Catch ex As Exception
                    End Try
                End If
            Next

        Catch ex As Exception
            Throw New Exception("cArchive.Dateien_originalLöschen: " + ex.ToString())
        End Try
    End Sub
    Public Function DokumentSpeichern(ByVal IDDokumenteintrag As System.Guid, ByVal DateinameArchiv As String,
                                        ByVal ablagepfad_sub As String, ByVal info As clFileInfo,
                                        ByVal Notiz As String, ByVal GültigVon As Date, ByVal GültigBis As Date, ByVal Wichtigkeit As String) As clRet
        Try
            Dim ret As New clRet

            Dim compDoku As New compSql
            Dim r_Dokumenteintrag As dsPlanArchive.tblDokumenteintragRow
            Dim dataDokumenteintrag As New dsPlanArchive
            r_Dokumenteintrag = dataDokumenteintrag.tblDokumenteintrag.NewRow()
            Dim ini As New GeneralArchiv
            ini.initRow(r_Dokumenteintrag)
            r_Dokumenteintrag.ID = IDDokumenteintrag
            r_Dokumenteintrag.IDOrdner = info.file_IDOrdner
            r_Dokumenteintrag.Bezeichnung = info.file_Bezeichnung
            r_Dokumenteintrag.Notiz = Trim(Notiz)
            'r_Dokumenteintrag.NotizRTF = Nothing
            r_Dokumenteintrag.GültigVon = GültigVon
            r_Dokumenteintrag.GültigBis = GültigBis
            r_Dokumenteintrag.Wichtigkeit = Wichtigkeit
            r_Dokumenteintrag.ErstelltVon = gen.actUser
            r_Dokumenteintrag.ErstelltAm = Now
            If Not compDoku.insertDokumenteintrag(r_Dokumenteintrag) Then
                MsgBox("Fehler beim Speichern des Dokumentes!", MsgBoxStyle.Information, "Archivsystem")
                ret.OK = False
                Return ret
            End If

            Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
            Dim dataDokumente As New dsPlanArchive
            r_Dokumente = dataDokumente.tblDokumenteSmall.NewRow()
            ini.initRow(r_Dokumente)
            r_Dokumente.ID = System.Guid.NewGuid
            r_Dokumente.IDDokumenteintrag = r_Dokumenteintrag.ID
            r_Dokumente.DateinameOrig = info.file_name
            r_Dokumente.VerzeichnisOrig = info.file_origVerzeichnis
            r_Dokumente.DokumentGröße = info.file_größe
            r_Dokumente.DokumentErstellt = info.file_erstelltAm
            r_Dokumente.DokumentGeändert = info.file_geändertAm
            r_Dokumente.ErstelltAm = Now
            r_Dokumente.ErstelltVon = gen.actUser
            r_Dokumente.Winzip = False
            r_Dokumente.DateinameArchiv = DateinameArchiv
            r_Dokumente.Archivordner = ablagepfad_sub
            r_Dokumente.DateinameTyp = info.file_typ
            If Not compDoku.insertDokument(r_Dokumente) Then
                MsgBox("Fehler beim Speichern des Dokumentes!", MsgBoxStyle.Information, "Archivsystem")
                ret.OK = False
                Return ret
            End If
            ret.OK = True
            Return ret

        Catch ex As Exception
            Throw New Exception("cArchive.DokumentSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function SchlagwortkatalogSpeichern(ByVal IDDokumenteintrag As System.Guid, ByVal dataSchlagwortkatalog As dsPlanArchive) As Boolean
        Try

            ' Schlagwortkatalog speichern
            Dim comp As New compSql
            comp.deleteDokumenteneintragSchlagwörter(IDDokumenteintrag)      ' alle Schlagwörter löschen
            For Each r As dsPlanArchive.tblSchlagwörterRow In dataSchlagwortkatalog.tblSchlagwörter
                If r("Gültig") = True Then
                    Dim r_dokSchlagw As dsPlanArchive.tblDokumenteneintragSchlagwörterRow
                    Dim dataDokumenteneintragSchlagwörter As New dsPlanArchive
                    r_dokSchlagw = dataDokumenteneintragSchlagwörter.tblDokumenteneintragSchlagwörter.NewRow
                    Dim ini As New GeneralArchiv
                    ini.initRow(r_dokSchlagw)
                    r_dokSchlagw.ID = System.Guid.NewGuid
                    r_dokSchlagw.IDDokumenteneintrag = IDDokumenteintrag
                    r_dokSchlagw.IDSchlagwort = r.ID
                    comp.writeDokumenteneintragSchlagwörter(r_dokSchlagw)
                End If
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.SchlagwortkatalogSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function ObjectSpeichern(ByVal IDDokumenteintrag As System.Guid, ByVal Objects As ArrayList) As Boolean
        Try

            Dim comp As New compSql
            For Each ob As clObject In Objects
                Dim r_object As dsPlanArchive.tblObjektRow
                Dim data As New dsPlanArchive
                r_object = data.tblObjekt.NewRow
                Dim ini As New GeneralArchiv
                ini.initRow(r_object)

                r_object.ID = System.Guid.NewGuid
                r_object.IDDokumenteintrag = IDDokumenteintrag
                r_object.Datenbankidentität = True
                r_object.bezeichnung = ob.bezeichnung
                Dim typ As New compSql.eTypObj

                If ob.id.GetType.ToString = "System.Int32" Then
                    r_object.ID_int = ob.id
                    typ = compSql.eTypObj.int
                ElseIf ob.id.GetType.ToString = "System.String" Then
                    Try
                        Dim id As New System.Guid(ob.id.ToString)
                        r_object.ID_guid = id
                        typ = compSql.eTypObj.guid
                    Catch ex As Exception
                        r_object.ID_str = ob.id
                        typ = compSql.eTypObj.str
                    End Try
                End If

                comp.insertObject(r_object)
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.ObjectSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function DateiPhysischSpeichern(ByVal DateinameArchiv As String, ByVal fileB() As Byte) As Boolean
        Try

            Dim fileToSave As New System.IO.FileStream(DateinameArchiv, System.IO.FileMode.CreateNew)
            Dim bw As New System.IO.BinaryWriter(fileToSave)
            bw.Write(fileB)

            Dim info As New System.IO.FileInfo(DateinameArchiv)
            info.IsReadOnly = False

            bw.Close()
            fileToSave.Close()
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.DateiPhysischSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function DokumentGelesenJN(ByVal IDDokumenteintrag As System.Guid, ByVal gelesen As Boolean) As Boolean
        Try

            Dim compGelesen As New compSql
            Dim r_insert As dsPlanArchive.tblDokumenteGelesenRow
            Dim data As New dsPlanArchive
            r_insert = data.tblDokumenteGelesen.NewRow()
            Dim ini As New GeneralArchiv
            ini.initRow(r_insert)
            r_insert.ID = System.Guid.NewGuid
            r_insert.IDDokumenteneintrag = IDDokumenteintrag
            r_insert.gelesen = gelesen
            If Not compGelesen.insertGelesenJN(r_insert) Then
                Throw New Exception("DokumentGelesenJN: Dokument konnte nicht als gelesen abgelegt werden!")
                Return False
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.DokumentGelesenJN: " + ex.ToString())
        End Try
    End Function

    Public Function dateiAusArchivLöschen(ByVal IDDokumenteintrag As System.Guid, ByVal withMsgBox As Boolean) As Boolean
        Try

            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentepfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Der Archivpfad für diese Archivdatenbank existiert nicht!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim ret As MsgBoxResult
                If withMsgBox Then
                    ret = MsgBox("Wollen Sie das Dokument wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem")
                Else
                    ret = MsgBoxResult.Yes
                End If
                If ret = MsgBoxResult.Yes Then
                    Dim comp As New compSql
                    Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(IDDokumenteintrag)
                    If Not gen.IsNull(r_Dokumente) Then
                        Dim fileToDelete As String = compPfad.pfadLesen() + "\" + r_Dokumente.Archivordner + "\" + r_Dokumente.DateinameArchiv
                        'If MsgBox("Soll die Datei auch physisch aus dem Archivsystem gelöscht werden?", MsgBoxStyle.YesNo, "PMDS") = MsgBoxResult.Yes Then
                        '    If System.IO.File.Exists(fileToDelete) Then
                        '        System.IO.File.Delete(fileToDelete)
                        '    Else
                        '        MsgBox("Die Datei existiert nicht!", MsgBoxStyle.Information, "Archivsystem")
                        '    End If
                        'End If
                        If System.IO.File.Exists(fileToDelete) Then
                            System.IO.File.Delete(fileToDelete)
                        End If
                        'Dim compObj As New S2ArchivWork.compObjekt
                        'compObj.ObjekteLöschen(r_Dokumente.IDDokumenteintrag)
                        If comp.DokumenteneintragLöschen(r_Dokumente.IDDokumenteintrag) Then
                            MsgBox("Die Datei wurde gelöscht!", MsgBoxStyle.Information, "Archivsystem")
                            Return True
                        End If
                    Else
                        MsgBox("Das Dokument wurde nicht gefunden!", MsgBoxStyle.Information, "Archivsystem")
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.dateiAusArchivLöschen: " + ex.ToString())
        End Try
    End Function
    Public Function dateiInDenPapierkorbVerschieben(ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try

            Dim compOrd As New compSql
            If Not compOrd.ExistiertPapierkorbJN() Then
                MsgBox("Es existiert kein Papierkorb!" + vbNewLine +
                        "Die Datei kann nicht verschoben werden", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            If Not gen.IsNull(IDDokumenteintrag) Then
                If MsgBox("Soll die Datei wirklich in den Papierkorb verschoben werden?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                    Dim IDOrdnerPapierkorb As New System.Guid
                    IDOrdnerPapierkorb = compOrd.GetIDOrdnerPapierkorb()
                    If Not gen.IsNull(IDOrdnerPapierkorb) Then
                        compOrd.UpdateIDOrdner_Dokumenteintrag(IDDokumenteintrag, IDOrdnerPapierkorb)
                        MsgBox("Die Datei wurde in den Papierkorb verschoben!", MsgBoxStyle.Information, "Archivsystem")
                        Return True
                    Else
                        Throw New Exception("DateiInDenPapierkorbVerschieben: Die IDOrdner für den Papierkorb konnte nicht gelöscht werden!")
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.dateiInDenPapierkorbVerschieben: " + ex.ToString())
        End Try
    End Function

    Public Function dateiZurZwischenablageHinzufügen(ByVal fileOriginal As String, ByVal DateinameFürZwischenablage As String) As Boolean
        Try

            If Not gen.IsNull(fileOriginal) Then
                Dim xmlOp As New clStringOperate
                Dim fileName As String
                If gen.IsNull(DateinameFürZwischenablage) Then
                    fileName = xmlOp.GetFileName(fileOriginal, False)
                Else
                    fileName = DateinameFürZwischenablage + xmlOp.GetFiletyp(fileOriginal)
                End If
                If Not gen.IsNull(fileName) Then
                    Dim tmpFileName As String = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, fileName)
                    If System.IO.File.Exists(tmpFileName) Then
                        Try
                            System.IO.File.Delete(tmpFileName)
                        Catch ex As Exception
                            Throw New Exception("cArchive.dateiZurZwischenablageHinzufügen: Datei kann nicht gelöscht werden: " + tmpFileName)
                        End Try
                    End If
                    System.IO.File.Copy(fileOriginal, tmpFileName)
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.dateiZurZwischenablageHinzufügen: " + ex.ToString())
        End Try
    End Function


    Public Function checkSysOrdner_anhangPlanung() As Boolean
        Try
            Dim comp As New compSql
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            IDOrdner = comp.GetIDOrdnerAnhangPlanungssystem()
            If Not gen.IsNull(IDOrdner) Then
                Dim compPfad As New compSql
                Dim pfadArchivsystem As String = compPfad.pfadLesen()
                If gen.IsNull(pfadArchivsystem) Then
                    MsgBox("Es existiert Archivpfad im Archivsystem!" + vbNewLine +
                           "Somit können keine Dokumente an E-Mails bzw. Termine angefügt werden'!" + vbNewLine +
                                "Bitte melden Sie das Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
                    Return False
                End If
            Else
                MsgBox("Es existiert kein Systemordner 'Anhang Planungssystem' im Archivsystem!" + vbNewLine +
                       "Somit können keine Dokumente an E-Mails bzw. Termine angefügt werden'!" + vbNewLine +
                            "Bitte melden Sie das Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
                Return True
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("cArchive.checkSysOrdner_anhangPlanung: " + ex.ToString())
        End Try
    End Function

    Public Sub ClearDatabaseArchiv()
        Try
            Dim DataSet As New DataSet("Table")
            Dim DataTable As New DataTable
            Dim Command As New OleDb.OleDbCommand
            Dim Parameter As OleDb.OleDbParameter
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim DataRow As DataRow

            Dim conn As New db

            Command.Parameters.Clear()
            Command = New OleDb.OleDbCommand("ClearArchiv", conn.getConnDB)
            Command.CommandType = CommandType.StoredProcedure
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("cArchive.ClearDatabaseArchiv: " + ex.ToString())
        End Try
    End Sub


    Private Function readConfigRek(ByRef searchText As String, ByRef Node As XmlNode) As cXmlFound
        Try

            For Each n As XmlNode In Node.ChildNodes
                If n.Name = searchText Then
                    Dim resFound As New cXmlFound
                    resFound.found = True
                    If Not Me.gen.IsNull(n.InnerText()) Then
                        resFound.result = Trim(n.InnerText())
                        Return resFound
                    Else
                        Return resFound
                    End If
                End If
                Dim res As New cXmlFound
                res = readConfigRek(searchText, n)
                If res.found Then Return res
            Next

            Dim emptyRes As New cXmlFound
            Return emptyRes

        Catch ex As Exception
            Throw New Exception("cArchive.readConfigRek: " + ex.ToString())
        End Try
    End Function

    Private Function writeConfigRek(ByRef searchText As String, ByRef Node As XmlNode, ByVal newValue As String) As Boolean
        Try

            For Each n As XmlNode In Node.ChildNodes
                If n.Name = searchText Then
                    n.InnerText = newValue
                    Return True
                End If
                If writeConfigRek(searchText, n, newValue) Then Return True
            Next

        Catch ex As Exception
            Throw New Exception("cArchive.writeConfigRek: " + ex.ToString())
        End Try
    End Function


    Public Function DokumentInZwischenablageSpeichern(ByVal IDDokumenteintrag As System.Guid) As String
        Try

            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compSql
                Dim r_Dokumenteintrag As dsPlanArchive.tblDokumenteintragRow
                r_Dokumenteintrag = comp.LesenDokumenteintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumenteintrag) Then
                    Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(r_Dokumenteintrag.ID)
                    If Not gen.IsNull(r_Dokumente) Then
                        ' Datei in die Zwischenablage kopieren
                        Dim dateiClipboard As String = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, r_Dokumenteintrag.Bezeichnung + "." + r_Dokumente.DateinameTyp)
                        Dim dateiArchiv As String = System.IO.Path.Combine(compPfad.pfadLesen, r_Dokumente.Archivordner, r_Dokumente.DateinameArchiv)
                        If System.IO.File.Exists(dateiClipboard) Then
                            Try
                                System.IO.File.Delete(dateiClipboard)
                            Catch ex As Exception
                                Throw New Exception("cArchive.DokumentInZwischenablageSpeichern Datei kann nicht gelöscht werden: " + dateiClipboard)
                            End Try
                        End If
                        System.IO.File.Copy(dateiArchiv, dateiClipboard)
                        Dim info As New System.IO.FileInfo(dateiClipboard)
                        info.IsReadOnly = False
                        Return dateiClipboard
                    Else
                        MsgBox("Es existiert kein Dokuemtenpfad!", MsgBoxStyle.Information, "Archivsystem")
                    End If
                Else
                    MsgBox("Es existiert kein Dokuemtenpfad!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If
            Return ""

        Catch ex As Exception
            Throw New Exception("cArchive.DokumentInZwischenablageSpeichern: " + ex.ToString())
        End Try
    End Function

    Public Function importVerzeichnisse(ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim browse As New System.Windows.Forms.FolderBrowserDialog
            Dim verz As String = browse.ShowDialog()
            If Not Me.gen.IsNull(verz) Then

                MsgBox("Das Verzeichnis wurde erfolgreich importiert!" + vbNewLine +
                        "", MsgBoxStyle.Information, "Archivsystem")
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.importVerzeichnisse: " + ex.ToString())
        End Try
    End Function

    Public Function OpenZwischenablageExplorer() As Boolean
        Try

            If Not gen.IsNull(PMDS.Global.ENV.path_Temp) Then
                If System.IO.Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                    Shell("explorer " + PMDS.Global.ENV.path_Temp, AppWinStyle.NormalFocus)
                Else
                    MsgBox("Die Zwischenablage existiert nicht!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.OpenZwischenablageExplorer: " + ex.ToString())
        End Try
    End Function

    Public Sub writeMultiTIFF(ByVal fileList As SortedList, ByVal nameMultiTIFF As String)
        Dim gen As New GeneralArchiv
        Try

            If fileList.Count > 0 Then
                Dim multiTIFF As Bitmap
                Dim myImageCodecInfo As ImageCodecInfo
                Dim myEncoder As Encoder
                Dim myEncoderParameter As EncoderParameter
                Dim myEncoderParameters As EncoderParameters

                myImageCodecInfo = GetEncoderInfo("image/tiff")
                myEncoder = Encoder.SaveFlag
                myEncoderParameters = New EncoderParameters(1)

                Dim bFirstPageIsWritten As Boolean = False
                For i As Integer = 0 To fileList.Count - 1
                    Dim file As String = fileList.Item(fileList.GetKey(i))
                    If Not gen.IsNull(file) Then
                        If System.IO.File.Exists(file) Then
                            If Not bFirstPageIsWritten Then
                                'Save the first page (frame).
                                'If System.IO.File.Exists(nameMultiTIFF) Then
                                '    System.IO.File.Delete(nameMultiTIFF)
                                'End If
                                multiTIFF = New Bitmap(file)
                                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.MultiFrame)
                                myEncoderParameters.Param(0) = myEncoderParameter
                                multiTIFF.Save(nameMultiTIFF, myImageCodecInfo, myEncoderParameters)
                                bFirstPageIsWritten = True
                            Else
                                Dim newPage As Bitmap
                                newPage = New Bitmap(file)
                                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.FrameDimensionPage)
                                myEncoderParameters.Param(0) = myEncoderParameter
                                multiTIFF.SaveAdd(newPage, myEncoderParameters)
                            End If
                        End If
                    End If
                Next

                'Close the multiple-frame file.
                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.Flush)
                myEncoderParameters.Param(0) = myEncoderParameter
                multiTIFF.SaveAdd(myEncoderParameters)
                multiTIFF = Nothing
            End If

        Catch ex As Exception
            Throw New Exception("cArchive.writeMultiTIFF: " + ex.ToString())
        End Try
    End Sub
    Public Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim gen As New GeneralArchiv
        Try

            Dim j As Integer
            Dim encoders() As ImageCodecInfo
            encoders = ImageCodecInfo.GetImageEncoders()
            For j = 0 To encoders.Length
                If encoders(j).MimeType = mimeType Then
                    Return encoders(j)
                End If
            Next
            Return Nothing

        Catch ex As Exception
            Throw New Exception("cArchive.GetEncoderInfo: " + ex.ToString())
        End Try
    End Function






    Public Class cXmlFound
        Public result As String = ""
        Public found As Boolean = False
    End Class

    Public Class clRet
        Public OK As Boolean = False
        Public anzAbgelegt As Integer = 0
        Public arrIDDokumenteneintrag As ArrayList
        Public arrIDDoku As ArrayList

        Public Sub New()

        End Sub
    End Class

End Class




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

    Public binIntern() As Byte = Nothing
    Public intReleased As Boolean = True
    Public DocuAsPdf() As Byte = Nothing

    Public fileB() As Byte
    Public bezeichnung As String = ""

    Public tArchObject As New dbArchiv.archObjectDataTable()
End Class

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

Public Class dArchiv

    Private gen As New GeneralArchiv
    Private Deleg As Funct
    Delegate Sub Funct()





    Public Sub RegisterDelegate(ByVal d As Funct)
        Try
            Deleg = d

        Catch ex As Exception
            Throw New Exception("RegisterDelegate: " + ex.ToString())
        End Try
    End Sub
    Public Sub UnRegisterDelegate()
        Try
            Deleg = Nothing

        Catch ex As Exception
            Throw New Exception("UnRegisterDelegate: " + ex.ToString())
        End Try
    End Sub
    Public Sub UseDelegate()
        Try
            If Not Deleg Is Nothing Then
                Deleg.Invoke()
            End If

        Catch ex As Exception
            Throw New Exception("UseDelegate: " + ex.ToString())
        End Try
    End Sub

End Class