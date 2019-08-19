


Public Class PMDSBusinessVB


    Public gen As New General()





    Public Function genVODatumNaechsterAnspruch(dFrom As Nullable(Of Date), dActBiggerThan As Date, GültigAb As Date,
                                                SerienterminType As String,
                                                iWiedWertJeden As Nullable(Of Integer), TagWochenMonat As String,
                                                NTenMonat As Nullable(Of Integer), Wochentage As String,
                                                ByRef lstDatesResult As System.Collections.Generic.List(Of General.cSerientermine),
                                                SerienterminEndetAm As Nullable(Of Date)) As Boolean
        Try
            Dim iSerientermintype As Integer = System.Convert.ToInt32(SerienterminType.Trim())
            Dim dTo As Date = New Date(2000, 1, 1, 0, 0, 0)
            If iSerientermintype = 1 Then               'Täglich                    (Wochentage)
                Dim dFromTmp As Date = dFrom
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.gen.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, False)

                    If (Wochentage.Trim().Contains(("Mo;").Trim()) And dFromTmp.DayOfWeek = DayOfWeek.Monday) Or
                        (Wochentage.Trim().Contains(("Di;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Tuesday) Or
                        (Wochentage.Trim().Contains(("Mi;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Wednesday) Or
                        (Wochentage.Trim().Contains(("Do;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Thursday) Or
                        (Wochentage.Trim().Contains(("Fr;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Friday) Or
                        (Wochentage.Trim().Contains(("Sa;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Saturday) Or
                        (Wochentage.Trim().Contains(("So;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Sunday) Then

                        Dim newSerientermine As New General.cSerientermine()
                        newSerientermine.dFrom = actDateStartTmp
                        newSerientermine.dTo = actDateEndTmp
                        newSerientermine.IsGanzerTag = False
                        If newSerientermine.dFrom.Date >= dActBiggerThan Then
                            lstDatesResult.Add(newSerientermine)
                            Exit Function
                        End If
                    End If

                    dFromTmp = dFromTmp.AddDays(1)
                End While

            ElseIf iSerientermintype = 2 Then           'Alle Tage/Woche/Monat      (WiedWertJeden - Tage Wochen Monat >> Wochen=Wochentage)
                Dim iWeeksOver As Integer = 1
                Dim iTageAddedWeek As Integer = 1           ' (iWiedWertJeden - 1) * 7
                Dim iLastWeekDone As Integer = -1
                Dim bWeekOK As Boolean = False
                Dim dFromTmp As Date = dFrom
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.gen.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, False)

                    Dim bSerienterminOK As Boolean = True
                    If TagWochenMonat = 1 Then          'Tage
                        bSerienterminOK = False
                        If iWeeksOver = 1 Then
                            bWeekOK = True
                            iLastWeekDone = 1
                        Else
                            If iWeeksOver = (iWiedWertJeden.Value) + iLastWeekDone Then
                                bWeekOK = True
                                iLastWeekDone = iWeeksOver
                            End If
                        End If
                        If bWeekOK Then
                            If (Wochentage.Trim().Contains(("Mo;").Trim()) And dFromTmp.DayOfWeek = DayOfWeek.Monday) Or
                                (Wochentage.Trim().Contains(("Di;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Tuesday) Or
                                (Wochentage.Trim().Contains(("Mi;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Wednesday) Or
                                (Wochentage.Trim().Contains(("Do;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Thursday) Or
                                (Wochentage.Trim().Contains(("Fr;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Friday) Or
                                (Wochentage.Trim().Contains(("Sa;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Saturday) Or
                                (Wochentage.Trim().Contains(("So;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Sunday) Then      'Tag OK?)

                                bSerienterminOK = True
                            End If
                        End If
                    End If
                    If bSerienterminOK Then
                        Dim newSerientermine As New General.cSerientermine()
                        If TagWochenMonat = 2 Then
                            Dim lastDayOfMonth As Integer = DateTime.DaysInMonth(actDateStartTmp.Year, actDateStartTmp.Month)
                            If (GültigAb.Day = lastDayOfMonth) Then
                                Dim actDateStartTmp2 As New Date(actDateStartTmp.Year, actDateStartTmp.Month, lastDayOfMonth, 0, 0, 0)
                                newSerientermine.dFrom = actDateStartTmp2
                                newSerientermine.dTo = actDateEndTmp
                            Else
                                If (GültigAb.Day > actDateStartTmp.Day And lastDayOfMonth >= GültigAb.Day) Then
                                    Dim actDateStartTmp2 As New Date(actDateStartTmp.Year, actDateStartTmp.Month, GültigAb.Day, 0, 0, 0)
                                    newSerientermine.dFrom = actDateStartTmp2
                                    newSerientermine.dTo = actDateEndTmp
                                Else
                                    newSerientermine.dFrom = actDateStartTmp
                                    newSerientermine.dTo = actDateEndTmp
                                End If
                            End If
                        Else
                            newSerientermine.dFrom = actDateStartTmp
                            newSerientermine.dTo = actDateEndTmp
                        End If
                        newSerientermine.IsGanzerTag = False
                        If newSerientermine.dFrom.Date >= dActBiggerThan Then
                            lstDatesResult.Add(newSerientermine)
                            Exit Function
                        End If
                    End If

                    If TagWochenMonat = 0 Then          'Tage
                        dFromTmp = dFromTmp.AddDays(iWiedWertJeden.Value)
                    ElseIf TagWochenMonat = 1 Then      'Wochen
                        dFromTmp = dFromTmp.AddDays(1)
                        iTageAddedWeek += 1
                        If iTageAddedWeek > 7 Then
                            iTageAddedWeek = 1
                            iWeeksOver += 1
                            bWeekOK = False
                        End If
                    ElseIf TagWochenMonat = 2 Then      'Monat
                        dFromTmp = dFromTmp.AddMonths(iWiedWertJeden.Value)
                    Else
                        Throw New Exception("calcDateStartEnd: TagWochenMonat '" + TagWochenMonat.ToString() + "' not allowed!")
                    End If
                End While

            ElseIf iSerientermintype = 3 Then           'Jeden n-ten Monat          (iNTenMonat) 
                Dim dFromTmp As Date = dFrom
                Dim iLastMonth As Integer = -1
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.gen.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, False)

                    Dim NTenMonatTmp As Integer = NTenMonat.Value
                    Dim lastDayOfMonth As Integer = DateTime.DaysInMonth(actDateStartTmp.Year, actDateStartTmp.Month)
                    If NTenMonatTmp > lastDayOfMonth Then
                        NTenMonatTmp = lastDayOfMonth
                    End If
                    If actDateStartTmp.Day = NTenMonatTmp Then
                        Dim newSerientermine As New General.cSerientermine()
                        newSerientermine.dFrom = actDateStartTmp
                        newSerientermine.dTo = actDateEndTmp
                        newSerientermine.IsGanzerTag = False
                        If newSerientermine.dFrom.Date >= dActBiggerThan Then
                            lstDatesResult.Add(newSerientermine)
                            Exit Function
                        End If
                    End If

                    dFromTmp = dFromTmp.AddDays(1)
                End While
            End If

        Catch ex As Exception
            Throw New Exception("PMDSBusinessVB.genVODatumNaechsterAnspruch: " + ex.ToString())
        End Try
    End Function

    Public Function SaveFileToArchive(fileToSave As String, Bezeichnung As String, sOrdner As String) As Boolean
        Try
            Dim gen As New GeneralArchiv()

            Dim comp As New compSql()
            Dim IDOrdner As System.Guid = Nothing
            IDOrdner = comp.GetOrdnerBiografie(sOrdner)
            If gen.IsNull(IDOrdner) Then
                Dim sTxtTranslated As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert im Archiv kein Ordner {0}. " + "Bitte erstellen Sie den Ordner zum Ablegen ins Archiv!")
                sTxtTranslated = String.Format(sTxtTranslated, sOrdner)
                Dim sTxtTitleTranslated = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ins Archiv ablegen")
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(sTxtTranslated, MsgBoxStyle.Information, sTxtTitleTranslated, True)
                Return False
            End If

            If System.IO.File.Exists(fileToSave) Then
                If Not gen.IsNull(fileToSave) Then
                    Dim strOp As New clStringOperate
                    Dim filInfoProvNote As New System.IO.FileInfo(fileToSave)
                    Dim fileInfo As New clFileInfo

                    Dim fs As New System.IO.FileStream(fileToSave, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim r As New System.IO.BinaryReader(fs)
                    Dim fileByte(fs.Length) As Byte
                    fileByte = r.ReadBytes(fs.Length)
                    fileInfo.fileB = fileByte

                    fileInfo.file_Bezeichnung = Bezeichnung.Trim()

                    fileInfo.file_erstelltAm = Now
                    fileInfo.file_geändertAm = Now
                    fileInfo.file_größe = filInfoProvNote.Length
                    fileInfo.file_IDOrdner = IDOrdner
                    fileInfo.file_name = strOp.GetFileName(fileToSave, False)
                    fileInfo.file_origVerzeichnis = strOp.GetDir(fileToSave)
                    fileInfo.file_typ = strOp.GetFiletyp(fileToSave)
                    Dim arrFile As New ArrayList
                    arrFile.Add(fileInfo)
                    Dim obs As New ArrayList
                    Dim clObj As New clObject()
                    clObj.id = PMDS.Global.ENV.CurrentIDPatient.ToString
                    clObj.bezeichnung = gen.getPatientName(PMDS.Global.ENV.CurrentIDPatient)
                    obs.Add(clObj)

                    Dim dataSchlagwortKat As New dsPlanArchive
                    Dim clSave As New cArchive
                    Dim ret As New cArchive.clRet
                    ret = clSave.DokumentInsArchivAblegen(arrFile, "", Nothing, Nothing, "M", Nothing, obs, dataSchlagwortKat)
                    If ret.OK Then
                        Return True
                    Else
                        Throw New Exception("SaveFileToArchive: Error save file " + fileToSave.Trim() + " to archive!")
                    End If
                End If
            Else
                Throw New Exception("SaveFileToArchive: File " + fileToSave.Trim() + " not found to save to archive!")
            End If

        Catch ex As Exception
            Throw New Exception("SaveFileToArchive: " + ex.ToString())
        Finally
        End Try
    End Function

End Class
