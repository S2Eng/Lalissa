


Public Class clZwischenablage

    Private gen As New GeneralArchiv()


    Public Function DokumentInZwischenablageSpeichern(ByVal IDDokumenteintrag As System.Guid) As String
        Try

            Dim compPfad As New compPfad
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Es existiert kein Dokumentenpfad!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compDokumenteintrag
                Dim r_Dokumenteintrag As dsDokumenteintrag.tblDokumenteintragRow
                r_Dokumenteintrag = comp.LesenDokumenteintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumenteintrag) Then
                    Dim r_Dokumente As dsDokumente.tblDokumenteRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(r_Dokumenteintrag.ID)
                    If Not gen.IsNull(r_Dokumente) Then
                        ' Datei in die Zwischenablage kopieren
                        Dim dateiClipboard As String = PMDS.Global.ENV.path_clipboard + "\" + r_Dokumenteintrag.Bezeichnung + "." + r_Dokumente.DateinameTyp
                        Dim dateiArchiv As String = compPfad.pfadLesen + "\" + r_Dokumente.Archivordner + "\" + r_Dokumente.DateinameArchiv
                        If System.IO.File.Exists(dateiClipboard) Then
                            System.IO.File.Delete(dateiClipboard)
                        End If
                        System.IO.File.Copy(dateiArchiv, dateiClipboard)
                        'Dim fileToSave As New System.IO.FileStream(gen.path_clipboard + "\" + r_Dokumenteintrag.Bezeichnung, IO.FileMode.Open)
                        'Dim bw As New System.IO.BinaryWriter(fileToSave)
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
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function

    Public Function OpenZwischenablageExplorer() As Boolean
        Try

            If Not gen.IsNull(PMDS.Global.ENV.path_clipboard) Then
                If System.IO.Directory.Exists(PMDS.Global.ENV.path_clipboard) Then
                    Shell("explorer " + PMDS.Global.ENV.path_clipboard, AppWinStyle.NormalFocus)
                Else
                    MsgBox("Die Zwischenablage existiert nicht!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function


End Class
