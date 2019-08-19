


Public Class doPmds

    Public db1 As New dbGlobal()



    Function Rueckmeldung(ByRef IDAufenthalt As String, ByRef IDPflegeplan As String, ByRef IDBereich As String, ByRef IDAbteilung As String, _
                          ByRef IDBenutzer As String, ByRef IDEintrag As String, ByRef IDBerufsstand As String, _
                          ByRef Zeitpunkt As String, ByRef IDWichtig As String, ByRef Zusatzwerte As String, _
                          ByRef Text As String, ByRef OhneZeitbezug As String,
                          ByRef RMTyp As sqlPMDS.eTypRMTyp) As Boolean

        ' init Db
        Dim sqlPMDSUpdate As New sqlPMDS()
        Dim dsPMDSUpdate As New dsPMDS()
        sqlPMDSUpdate.getPflegeplan(System.Guid.NewGuid.ToString(), dsPMDSUpdate, sqlPMDS.eTypAuswahl.ID)
        sqlPMDSUpdate.getPflegeplanH(System.Guid.NewGuid.ToString(), dsPMDSUpdate, sqlPMDS.eTypAuswahl.ID)
        sqlPMDSUpdate.getPflegeeintrag(System.Guid.NewGuid.ToString(), dsPMDSUpdate, sqlPMDS.eTypAuswahl.ID)
        sqlPMDSUpdate.getZusatzwert(System.Guid.NewGuid.ToString(), System.Guid.NewGuid.ToString(), dsPMDSUpdate, sqlPMDS.eTypAuswahl.IDPflegeeintrag)

        Dim dsPMDSRead As New dsPMDS()
        '1. Pflegeplan in PflegeplanH kopieren (feldweise mit Überprüfung des Feldnamen, Nicht ID, PflegeplanH.IDPflegeplan = Pflegeplan.ID, Aktion = "A")
        'sqlPMDSUpdate.getPflegeplan(IDPflegeplan, dsPMDSRead, sqlPMDS.eTypAuswahl.ID)
        'Dim rPflegeplan As dsPMDS.PflegePlanRow = dsPMDSRead.PflegePlan.Rows(0)
        'If dsPMDSRead.PflegePlan.Rows.Count <> 1 Then
        '    Throw New Exception("dsPMDSRead.PflegePlan.Rows.Count <> 1 IDPflegeplan='" + IDPflegeplan.ToString() + "'!")
        'End If
        'Dim rNewPflegePlanH As dsPMDS.PflegePlanHRow = Me.db1.copyRow(rPflegeplan, dsPMDSUpdate.PflegePlanH)
        'rNewPflegePlanH.Aktion = "A"
        'sqlPMDSUpdate.daPflegeplanH.Update(dsPMDSUpdate.PflegePlanH)

        Dim rPflegeplan As dsPMDS.PflegePlanRow = Nothing
        Dim rPflegeplanH As dsPMDS.PflegePlanHRow = Nothing

        '1. Im Pflegeplan LetztesDatum = geplantes Startdatum setzen
        If RMTyp = sqlPMDS.eTypRMTyp.Intervention Then
            sqlPMDSUpdate.getPflegeplan(IDPflegeplan, dsPMDSUpdate, sqlPMDS.eTypAuswahl.ID)
            rPflegeplan = dsPMDSUpdate.PflegePlan.Rows(0)
            rPflegeplan.LetztesDatum = CDate(Zeitpunkt)
            sqlPMDSUpdate.daPflegeplan.Update(dsPMDSUpdate.PflegePlan)

            '2. PflegeplanH-ID suchen (letzte Referenz nach DatumGeaendert Desc)
            sqlPMDSUpdate.getPflegeplanH(IDPflegeplan, dsPMDSRead, sqlPMDS.eTypAuswahl.IDPflegePlan)
            rPflegeplanH = dsPMDSRead.PflegePlanH.Rows(0)
        End If

        '3. Pflegeeintrag einfügen
        Dim rNewPflegeeintrag As dsPMDS.PflegeEintragRow = dsPMDSUpdate.PflegeEintrag.NewRow()
        'dbGlobal.initRow(rNewPflegeeintrag)

        Dim IDNewPflegeEintrag As Guid = System.Guid.NewGuid()

        rNewPflegeeintrag.ID = IDNewPflegeEintrag
        rNewPflegeeintrag.IDAufenthalt = New System.Guid(IDAufenthalt)
        If RMTyp = sqlPMDS.eTypRMTyp.Intervention Then
            If OhneZeitbezug = "0" Then
                rNewPflegeeintrag.IDPflegePlan = New System.Guid(IDPflegeplan)
                rNewPflegeeintrag.IDEintrag = New System.Guid(IDEintrag)
            End If
        ElseIf RMTyp = sqlPMDS.eTypRMTyp.FreierBericht Then
            'rNewPflegeeintrag.IDPflegePlan = System.Guid.Empty
            'rNewPflegeeintrag.IDEintrag = System.Guid.Empty
        End If

        rNewPflegeeintrag.IDBenutzer = New System.Guid(IDBenutzer)
        rNewPflegeeintrag.IDBerufsstand = New System.Guid(IDBerufsstand)
        rNewPflegeeintrag.DatumErstellt = Now

        rNewPflegeeintrag.Zeitpunkt = IIf(RMTyp = sqlPMDS.eTypRMTyp.Intervention, CDate(Zeitpunkt), Now)
        rNewPflegeeintrag.Text = Text
        rNewPflegeeintrag.IstDauer = 0
        rNewPflegeeintrag.DurchgefuehrtJN = True
        rNewPflegeeintrag.EintragsTyp = RMTyp
        rNewPflegeeintrag.EvalStatus = -1

        rNewPflegeeintrag.Wichtig = 0
        Dim gIDWichtig As New System.Guid(IDWichtig)
        If gIDWichtig <> System.Guid.Empty Then
            rNewPflegeeintrag.IDWichtig = gIDWichtig
        End If

        If RMTyp = sqlPMDS.eTypRMTyp.Intervention Then
            rNewPflegeeintrag.PflegeplanText = rPflegeplan.Text    '"" bei Freier Bericht
            rNewPflegeeintrag.IDSollberufsstand = rPflegeplan.IDBerufsstand         'In Ermangelung des Sollberufsstandes aus Eintrag
            rNewPflegeeintrag.IDPflegePlanBerufsstand = rPflegeplan.IDBerufsstand   '
            rNewPflegeeintrag.IDPflegeplanH = rPflegeplanH.ID
            rNewPflegeeintrag.PflegePlanDauer = rPflegeplan.Dauer
        ElseIf RMTyp = sqlPMDS.eTypRMTyp.FreierBericht Then
            rNewPflegeeintrag.PflegeplanText = ""
            'rNewPflegeeintrag.IDSollberufsstand = System.Guid.Empty
            'rNewPflegeeintrag.IDPflegePlanBerufsstand = System.Guid.Empty
            'rNewPflegeeintrag.IDPflegeplanH = System.Guid.Empty
            rNewPflegeeintrag.PflegePlanDauer = 0
        End If

        rNewPflegeeintrag.Solldauer = 0
        rNewPflegeeintrag.IDBereich = New System.Guid(IDBereich)
        rNewPflegeeintrag.IDAbteilung = New System.Guid(IDAbteilung)


        dsPMDSUpdate.PflegeEintrag.Rows.Add(rNewPflegeeintrag)

        Try
            sqlPMDSUpdate.daPflegeeintrag.Update(dsPMDSUpdate.PflegeEintrag)

        Catch ex As Exception
            Throw New Exception(Err.Description)
        End Try


        '4. Für alle Zusatzwerte: Zusatzwert einfügen (Typ prüfen und Wert in die richtige Spalte schreiben)
        'Werte kommen im Parameter als Paare mit = getrennt, Werte sind mit | getrennt
        If Zusatzwerte.Length > 0 Then

            Dim arrZusatzwerte As Array
            Dim arrZusatzwert As Array
            Dim arrZusatzwertTyp As Array

            arrZusatzwerte = Zusatzwerte.Split("|".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)

            For i = 0 To arrZusatzwerte.GetLength(0) - 1
                Dim strZusatzwert As String = arrZusatzwerte(i)
                arrZusatzwert = strZusatzwert.Split("=".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)                  'arrZusatzWert(0) enthält die ID, arrZusatzwert(1)  Wert~Typ

                If arrZusatzwert.GetLength(0) = 2 Then                          'Type des Zusatzwertes holen, dazu Wert splitten
                    Dim strZusatzwertTyp As String = arrZusatzwert(1)
                    arrZusatzwertTyp = strZusatzwertTyp.Split("~".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)

                    If arrZusatzwertTyp.GetLength(0) = 2 Then                   'Zusatzwert in Tabelle schreiben

                        Dim rNewZusatzwert As dsPMDS.ZusatzWertRow = dsPMDSUpdate.ZusatzWert.NewRow()
                        'dbGlobal.initRow(rNewZusatzwert)

                        rNewZusatzwert.ID = System.Guid.NewGuid()
                        rNewZusatzwert.IDZusatzGruppeEintrag = New System.Guid(arrZusatzwert(0).ToString)
                        rNewZusatzwert.IDObjekt = IDNewPflegeEintrag

                        Dim raw As Byte() = Nothing

                        rNewZusatzwert.Wert = ""
                        rNewZusatzwert.ZahlenWert = -1
                        rNewZusatzwert.ZahlenWertFloat = -1
                        rNewZusatzwert.RawFormat = raw

                        Select Case arrZusatzwertTyp(1)

                            Case 0, 2   'Text, BigText
                                rNewZusatzwert.Wert = arrZusatzwertTyp(0).ToString()
                            Case 1      'Integer
                                rNewZusatzwert.ZahlenWert = Int(arrZusatzwertTyp(0))
                            Case 3      'Label
                            Case 4      'Image
                            Case 5      'Float
                                rNewZusatzwert.ZahlenWertFloat = CDbl(arrZusatzwertTyp(0).ToString)
                        End Select

                        dsPMDSUpdate.ZusatzWert.Rows.Add(rNewZusatzwert)

                        Try
                            sqlPMDSUpdate.daZusatzwert.Update(dsPMDSUpdate.ZusatzWert)

                        Catch ex As Exception
                            Throw New Exception(Err.Description)
                        End Try

                    End If

                End If
            Next

        End If

        Return True

    End Function



End Class
