

Public Class doDoc

    Public gen As New General
    Public funct1 As New QS2.functions.vb.functOld()

    Public Enum eTypSaveDocu
        addFiles = 0
        selectOrdner = 1
    End Enum


    Public Function importDokuemte(ByVal IDOrdner As System.Guid,
                                   ByVal typToImport As String,
                                   ByRef protokoll As String,
                                   ByRef bezeichnungDokumente As String,
                                   ByRef objektNameInDokumentName As Boolean) As System.Collections.Generic.List(Of clFileInfo)
        Try
            Dim ret As New System.Collections.Generic.List(Of clFileInfo)
            Dim anz As Integer = 0
            Dim browse As New System.Windows.Forms.FolderBrowserDialog
            browse.Description = doUI.getRes("PleaseChooseThePathThatLieInTheDocumentsToBeImported")
            browse.ShowNewFolderButton = True
            browse.ShowDialog()
            Dim verz As String = browse.SelectedPath
            If Not verz = "" Then
                Dim allFilesVor() As String = System.IO.Directory.GetFiles(verz)
                For Each docuSerienbrief As String In allFilesVor
                    Dim fileName As String = ""
                    Try
                        Dim typ As String = funct1.GetFiletyp(docuSerienbrief)
                        fileName = funct1.GetFileName(docuSerienbrief, True)
                        Dim startIntNr As Integer = fileName.IndexOf(".", 0)

                        Dim tArchObjectTemp As New dbArchiv.archObjectDataTable()
                        Dim clFileInfo1 As New clFileInfo()

                        Dim tArchObjects As New dbArchiv.archObjectDataTable()
                        Dim compDoku1 As New compDoku()
                        Dim rNewObj As dbArchiv.archObjectRow = compDoku1.getNewRowArchObject(tArchObjects)

                        If typToImport = "O" Then
                            'Dim sZuweisung As String = fileName.Substring(startIntNr + 1, fileName.Length - startIntNr - 1)
                            'Dim ds As New ITSCont.core.SystemDb.dsObject()
                            'Dim compObject1 As New ITSCont.core.SystemDb.compObject()
                            'Dim rObj As ITSCont.core.SystemDb.dsObject.tblObjectRow = compObject1.getObjectRow(Nothing, core.SystemDb.compObject.eTypSelObj.autoNr, core.SystemDb.compObject.eTypObj.none, CInt(sZuweisung.Trim()))
                            'If Not rObj Is Nothing Then
                            '    rNewObj.IDObject = rObj.ID
                            '    Me.setFileInfo(docuSerienbrief, tArchObjects, clFileInfo1)
                            '    If bezeichnungDokumente.Trim() <> "" Then
                            '        clFileInfo1.bezeichnung = compAutoUI.getRes("NrObject") + " " + sZuweisung.Trim()
                            '        clFileInfo1.bezeichnung = bezeichnungDokumente.Trim() + "  " + clFileInfo1.bezeichnung
                            '    End If

                            '    ret.Add(clFileInfo1)
                            '    anz += 1
                            'Else
                            '    Dim strTemp As String = compAutoUI.getRes("ObjektWithTheIntNrXDoesNotExists")
                            '    strTemp = String.Format(strTemp, sZuweisung.Trim())
                            '    protokoll += strTemp + "!" + vbNewLine

                            'End If

                        End If

                    Catch ex As Exception
                        protokoll += "Error Import '" + fileName + "'!" + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
                        'MsgBox("Das Dokument '" + fileName + "' kann nicht importiert werden!", MsgBoxStyle.Information, "Archiv")
                        'gen.GetEcxeptionGeneral(ex)
                    End Try
                Next
            End If

            Return ret
        Catch ex As Exception
            Throw New Exception("UI.importDokuemte: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function setFileInfo(ByRef file As String, ByRef tArchObjects As dbArchiv.archObjectDataTable,
                            ByRef FileToAdd As clFileInfo) As Boolean
        Try
            FileToAdd.file_typ = funct1.GetFiletyp(file)
            FileToAdd.file_origVerzeichnis = funct1.GetDir(file)
            FileToAdd.file_name = funct1.GetFileName(file, False)

            Dim genMain As New General()
            FileToAdd.fileB = genMain.readByteStreamFile(file)

            ' fileInfos einlesen
            Dim FileInfo As New System.IO.FileInfo(file)
            FileToAdd.file_erstelltAm = FileInfo.CreationTime
            FileToAdd.file_größe = CStr(FileInfo.Length)
            FileToAdd.tArchObject = tArchObjects
            Return True

        Catch ex As Exception
            Throw New Exception("UI.setFileInfo: " + ex.ToString())
        End Try
    End Function


End Class