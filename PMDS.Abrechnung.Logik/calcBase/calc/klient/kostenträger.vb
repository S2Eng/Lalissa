Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic


Public Class kostenträger
    Inherits calcBase


    Public Shared IDKostKlient As String = "00000000-0000-0000-0000-000000000001"
    Public Shared bezGSBG As String = "Zuschlag"
    Public Shared TransferTxt As String = "Pension 80% Eigenleistung"




    Public Sub init(ByRef IDKlient As String, ByRef abrechVon As Date, ByRef abrechBis As Date, ByRef calc As calcData, _
                    ByRef MWSTSätze As dbPMDS.MWSTSätzeDataTable, IDKlinik As System.Guid)
        Try
            Dim strSQL As String = ""
            Dim dbPMDSRead As New dbPMDS()

            Dim von As Object
            Dim bis As Date
            Dim i As Integer = 0

            'Sortierung in Collectionist schwierig, daher Kostenträger in Arrays zwischenspeichern und
            'sortiert in die colKostentrager schieben

            Dim tKost2 As New dbCalc.KostenträgerDataTable()        '2 .. Klientenbezogener Kostentraeger mit Betrag
            Dim tKost3 As New dbCalc.KostenträgerDataTable()        '3 .. Allgemeine Kostentraeger mit Betrag
            Dim tKost4 As New dbCalc.KostenträgerDataTable()        '4 .. Klientenbezogener Kostentraeger ohne Betrag (Restzahler)
            Dim tKost5 As New dbCalc.KostenträgerDataTable()        '5 .. Allgemeine Kostentrager ohne Betrag (Restzahler)
            '6 .. Klient selbst als letzter Zahler wird am Ende jedenfalls hinzugefügt
            Dim tKost1 As New dbCalc.KostenträgerDataTable()        '10 .. Transferkostentrager ...  nicht in Leistungsberechnungen enthalten, erst Summe Rechnung

            Dim qryKost As dbQuery = sql.run("SELECT PatientKostentraeger.IDKostentraeger, Kostentraeger.Name, Kostentraeger.SammelabrechnungJN, PatientKostentraeger.GueltigAb, " &
                                             "       PatientKostentraeger.GueltigBis, PatientKostentraeger.enumKostentraegerart, PatientKostentraeger.BetragErrechnetJN, " &
                                             "       PatientKostentraeger.Betrag, PatientKostentraeger.VorauszahlungJN, PatientKostentraeger.RechnungJN, " &
                                             "       PatientKostentraeger.RechnungTyp , PatientKostentraeger.IDPatient, Kostentraeger.PatientbezogenJN, Kostentraeger.FIBUKonto , Kostentraeger.GSBG, Kostentraeger.IDKlinik, Kostentraeger.IDKostentraegerSub " &
                                             "FROM   PatientKostentraeger INNER JOIN " &
                                             "       Kostentraeger ON PatientKostentraeger.IDKostentraeger = Kostentraeger.ID " &
                                             "WHERE  (Kostentraeger.IDKlinik = '" + IDKlinik.ToString() + "' or Kostentraeger.IDKlinik is null) and LOWER(PatientKostentraeger.IDPatient) = '" & IDKlient & "'", Nothing)
            If qryKost.table.Rows.Count > 0 Then
                For Each r As DataRow In qryKost.table.Rows

                    von = Me.Max(r("GueltigAb"), Me.rowMonat(calc.dbCalc).Beginn)
                    If IsDBNull(r("GueltigBis")) Then bis = Me.rowMonat(calc.dbCalc).Ende Else bis = r("GueltigBis")
                    bis = Me.Min(abrechBis, bis)

                    If bis < Me.rowMonat(calc.dbCalc).Beginn Or von > Me.rowMonat(calc.dbCalc).Ende Then
                        'Nichts tun, Zeitraum, in dem die Kosten getragen werdenliegt außerhalb des Abrechnungsmonats
                    Else
                        'Bei freien Rechnungen nur den Zahler hinzufügen, der tatsächlich zahlt
                        If Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then
                            If Not Me.checkKostFreeBill(VB.LCase(r("IDKostentraeger").ToString()), abrechVon, abrechBis, IDKlient, IDKlinik) Then _
                                Continue For
                        End If

                        Dim rNewKost As dbCalc.KostenträgerRow = Me.newKostenträger(calc.dbCalc)

                        rNewKost.FamName = r("Name")
                        rNewKost.FIBU = r("FIBUKonto").ToString().Trim()

                        dbPMDSRead.Clear()
                        sql.readKlinik(dbPMDSRead, IDKlinik)
                        If dbPMDSRead.Klinik.Rows.Count = 0 Then
                            rNewKost.SetIDKlinikNull()
                        ElseIf dbPMDSRead.Klinik.Rows.Count = 1 Then
                            Dim rKlinikDat As dbPMDS.KlinikRow = dbPMDSRead.Klinik.Rows(0)
                            rNewKost.IDKlinik = New System.Guid(rKlinikDat.ID)
                        ElseIf dbPMDSRead.Klinik.Rows.Count > 1 Then
                            Throw New Exception("kostenträger.init: dbPMDSRead.Klinik.Rows.Count > 1 for IDKlinik '" + IDKlinik.ToString() + "'!")
                        End If

                        rNewKost.von = von
                        rNewKost.bis = bis

                        If r("EnumKostentraegerart") = 0 Or r("EnumKostentraegerart") = 3 Or r("EnumKostentraegerart") = 5 Or r("EnumKostentraegerart") = 7 Or r("EnumKostentraegerart") = 9 Then
                            rNewKost.GrundleistungJN = True
                        End If
                        If r("EnumKostentraegerart") = 4 Or r("EnumKostentraegerart") = 5 Or r("EnumKostentraegerart") = 8 Or r("EnumKostentraegerart") = 9 Then
                            rNewKost.PeriodischeLeistungJN = True
                        End If
                        If r("EnumKostentraegerart") = 6 Or r("EnumKostentraegerart") = 7 Or r("EnumKostentraegerart") = 8 Or r("EnumKostentraegerart") = 9 Then
                            rNewKost.SonderleistungJN = True
                        End If

                        rNewKost.IDKostIntern = VB.LCase(System.Guid.NewGuid().ToString())
                        rNewKost.IDKost = VB.LCase(r("IDKostentraeger").ToString())
                        rNewKost.KlientenbezogenJN = r("PatientbezogenJN")
                        rNewKost.MaxBetragBrutto = r("Betrag")
                        rNewKost.RechnungJN = r("RechnungJN")
                        rNewKost.SammelabrechnungJN = r("SammelabrechnungJN")
                        rNewKost.RechnungTyp = r("RechnungTyp")

                        'Für freie Rechnung Einzel-Rechnung jedenfalls ausdrucken-unabhängig ob Kostenträger Sammelrechnung erhält.
                        If Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then
                            rNewKost.RechnungTyp = eBillTyp.FreieRechnung
                            rNewKost.RechnungJN = True
                            rNewKost.SammelabrechnungJN = False
                        End If


                        rNewKost.RestzahlerJN = r("BetragErrechnetJN")
                        rNewKost.VorauszahlungJN = r("VorauszahlungJN")
                        rNewKost.IDKlient = VB.LCase(IDKlient)
                        rNewKost.Rechnung = ""

                        'Ermittlung des Ranges
                        '10 .. Transferkostentrager
                        '2 .. Klientenbezogener Kostentraeger mit Betrag
                        '3 .. Allgemeine Kostentraeger mit Betrag
                        '4 .. Klientenbezogener Kostentraeger ohne Betrag (Restzahler)
                        '5 .. Allgemeine Kostentrager ohne Betrag (Restzahler)
                        '6 .. Klient (wird hier nicht behandelt

                        'Bei Zahlern im gleichen Rang später weitere Sortierung nach Betrag absteigend (meine eigene Definition!)

                        If r("EnumKostentraegerart") = 3 Then 'Transferkostentraeger sind IMMER die letzten

                            rNewKost.Rang = 10
                            rNewKost.TransferzahlerJN = True

                            'Transferzahlungen einlesen und in MaxBetrag beim Kienten summieren
                            Dim arrPar(4) As dbParameter

                            Dim par1 As New dbParameter
                            par1.parameter = New System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb")
                            par1.value = abrechVon : arrPar(0) = par1

                            Dim par2 As New dbParameter
                            par2.parameter = New System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")
                            par2.value = abrechBis : arrPar(1) = par2

                            Dim par3 As New dbParameter
                            par3.parameter = New System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb")
                            par3.value = abrechVon : arrPar(2) = par3

                            Dim par4 As New dbParameter
                            par4.parameter = New System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb")
                            par4.value = abrechVon : arrPar(3) = par4

                            Dim par5 As New dbParameter
                            par5.parameter = New System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")
                            par5.value = abrechBis : arrPar(4) = par5

                            Dim qryTransfer As dbQuery = sql.run("SELECT BetragVerwendbar AS MaxBetrag FROM PatientEinkommen WHERE IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" & IDKlient & "' " & "AND IDKostentraeger = '" & r("IDKostentraeger").ToString() & "' " & _
                                                                 " AND ((GueltigAb <= ? AND  GueltigBis >= ?)  OR " + _
                                                                 "      (GueltigAb <= ? AND GueltigBis IS NULL) OR " + _
                                                                 "      (GueltigAb = GueltigBis AND GueltigAb BETWEEN ?  AND ?) " + _
                                                                 "      ) ", arrPar)

                            If qryTransfer.table.Rows.Count > 0 Then
                                For Each rTransfer As DataRow In qryTransfer.table.Rows
                                    rNewKost.MaxBetragBrutto += rTransfer("MaxBetrag")
                                Next
                            End If

                            Dim rNewKost1 As dbCalc.KostenträgerRow = tKost1.NewRow()
                            rNewKost1.ItemArray = rNewKost.ItemArray()
                            tKost1.Rows.Add(rNewKost1)
                        Else

                            If rNewKost.KlientenbezogenJN = True And rNewKost.RestzahlerJN = False Then
                                rNewKost.Rang = 2
                                Dim rNewKost2 As dbCalc.KostenträgerRow = tKost2.NewRow()
                                rNewKost2.ItemArray = rNewKost.ItemArray()
                                tKost2.Rows.Add(rNewKost2)
                            End If

                            If rNewKost.KlientenbezogenJN = False And rNewKost.RestzahlerJN = False Then
                                rNewKost.Rang = 3
                                Dim rNewKost3 As dbCalc.KostenträgerRow = tKost3.NewRow()
                                If qryKost.table.Rows.Count = 1 Then
                                    rNewKost.MaxBetragBrutto = Me.int99999999()
                                End If
                                rNewKost3.ItemArray = rNewKost.ItemArray()
                                tKost3.Rows.Add(rNewKost3)
                            End If

                            If rNewKost.KlientenbezogenJN = True And rNewKost.RestzahlerJN = True Then
                                rNewKost.Rang = 4
                                rNewKost.MaxBetragBrutto = Me.int99999999()
                                Dim rNewKost4 As dbCalc.KostenträgerRow = tKost4.NewRow()
                                rNewKost4.ItemArray = rNewKost.ItemArray()
                                tKost4.Rows.Add(rNewKost4)
                            End If

                            If (rNewKost.KlientenbezogenJN = False And rNewKost.RestzahlerJN = True) Then

                                'Daten für Zuschlag zu Grundleistung berücksichtigen
                                If r("GSBG") <> 0 Then
                                    rNewKost.ZuschlagGrundleistungJN = True
                                    rNewKost.ZuschlagGrundleistungProzent = r("GSBG")
                                End If

                                rNewKost.Rang = 5
                                rNewKost.MaxBetragBrutto = Me.int99999999()
                                Dim rNewKost5 As dbCalc.KostenträgerRow = tKost5.NewRow()
                                rNewKost5.ItemArray = rNewKost.ItemArray()
                                tKost5.Rows.Add(rNewKost5)

                            End If
                        End If
                    End If
                Next


                For Each rKost As dbCalc.KostenträgerRow In tKost1
                    Dim rNewKost As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.NewRow()
                    rNewKost.ItemArray = rKost.ItemArray()
                    calc.dbCalc.Kostenträger.Rows.Add(rNewKost)
                    Me.addMWStBasen(rKost.IDKostIntern, calc, MWSTSätze)
                Next

                For Each rKost As dbCalc.KostenträgerRow In tKost2
                    Dim rNewKost As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.NewRow()
                    rNewKost.ItemArray = rKost.ItemArray()
                    calc.dbCalc.Kostenträger.Rows.Add(rNewKost)
                    Me.addMWStBasen(rKost.IDKostIntern, calc, MWSTSätze)
                Next

                For Each rKost As dbCalc.KostenträgerRow In tKost3
                    Dim rNewKost As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.NewRow()
                    rNewKost.ItemArray = rKost.ItemArray()
                    calc.dbCalc.Kostenträger.Rows.Add(rNewKost)
                    Me.addMWStBasen(rKost.IDKostIntern, calc, MWSTSätze)
                Next

                For Each rKost As dbCalc.KostenträgerRow In tKost4
                    Dim rNewKost As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.NewRow()
                    rNewKost.ItemArray = rKost.ItemArray()
                    calc.dbCalc.Kostenträger.Rows.Add(rNewKost)
                    Me.addMWStBasen(rKost.IDKostIntern, calc, MWSTSätze)
                Next

                For Each rKost As dbCalc.KostenträgerRow In tKost5
                    Dim rNewKost As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.NewRow()
                    rNewKost.ItemArray = rKost.ItemArray()
                    calc.dbCalc.Kostenträger.Rows.Add(rNewKost)
                    Me.addMWStBasen(rKost.IDKostIntern, calc, MWSTSätze)
                Next

            End If

            'Klienten als letzten Kostenträger hinzufügen
            'os 091220: Bringt Probleme, weil leere Rechnungen erzeugt werden.
            'Anstelle automatischem Hinzufügen Prüfung, ob alles verrechnet wurde

            'Dim rNewKostKlient As dbCalc.KostenträgerRow = Me.newKostenträger(calc)

            'rNewKostKlient.IDKostIntern = VB.LCase(System.Guid.NewGuid().ToString())

            'rNewKostKlient.FamName = calc.dbCalc.Klient.Rows(0)("Vorname") + " " + calc.dbCalc.Klient.Rows(0)("Nachname")
            'rNewKostKlient.Rang = 6
            'rNewKostKlient.MaxBetragBrutto = Me.int99999999()
            'rNewKostKlient.KlientenbezogenJN = True

            'rNewKostKlient.von = Me.rowMonat(calc.dbCalc).Beginn
            'rNewKostKlient.bis = Me.rowMonat(calc.dbCalc).Ende

            'rNewKostKlient.TransferzahlerJN = False
            'rNewKostKlient.ZahlungsbetragNetto = 0
            'rNewKostKlient.ZahlungsbetragBrutto = 0
            'rNewKostKlient.Rundungsausgleich = 0
            'rNewKostKlient.ZuschlagGrundleistungJN = False
            'rNewKostKlient.ZuschlagGrundleistungProzent = 0
            'rNewKostKlient.ZuschlagGrundleistungBetrag = 0
            'rNewKostKlient.FreieBuchungBetragNetto = 0

            'rNewKostKlient.GrundleistungJN = True
            'rNewKostKlient.PeriodischeLeistungJN = True
            'rNewKostKlient.SonderleistungJN = True


            'rNewKostKlient.IDKost = kostenträger.IDKostKlient
            'rNewKostKlient.RechnungJN = True
            'rNewKostKlient.RechnungTyp = eBillTyp.Rechnung
            'rNewKostKlient.RestzahlerJN = True
            'rNewKostKlient.SammelabrechnungJN = False
            'rNewKostKlient.VorauszahlungJN = False
            'rNewKostKlient.IDKlient = VB.LCase(IDKlient)
            'rNewKostKlient.Rechnung = ""

            'calc.dbCalc.Kostenträger.Rows.Add(rNewKostKlient)
            'Me.addMWStBasen(rNewKostKlient.IDKostIntern, calc, MWSTSätze)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Function checkKostFreeBill(ByVal IDKostToCheck As String, ByVal abrechVon As Date, ByVal abrechBis As Date, ByVal IDKlient As String, IDKlinik As System.Guid) As Boolean

        Dim arrPar(1) As dbParameter
        Dim par1 As New dbParameter
        par1.parameter = New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")
        par1.value = abrechVon : arrPar(0) = par1
        Dim par2 As New dbParameter
        par2.parameter = New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")
        par2.value = abrechBis : arrPar(1) = par2

        Dim selManFree As String = ""

        selManFree = " and typ = " + CInt(eCalcRun.freeBill).ToString() + " "        'nur die freien Buchungen

        Dim qryManBuch As dbQuery = sql.run("SELECT * FROM manBuch WHERE LOWER(IDKlient) = '" + IDKlient & "' " + selManFree + " AND IDKlinik = '" + IDKlinik.ToString() + "' and Datum BETWEEN ?  AND ? Order BY datum asc, am asc", arrPar)
        For Each r As DataRow In qryManBuch.table.Rows
            If r("IDRef").ToString().Equals(IDKostToCheck) Then
                Return True
            End If
        Next

    End Function
    Public Sub addMWStBasen(ByVal IDKostIntern As String, ByRef calc As calcData, ByRef MWSTSätze As dbPMDS.MWSTSätzeDataTable)
        Try
            'Collection MWStBasen hinzufügen
            'MWSTSaetze müssen vorher initialisiert worden sein.
            'Pro MWSTSatz einen Eintrag in die Collection MWSTBasen hinzufügen

            For Each rMWSTSatz As dbPMDS.MWSTSätzeRow In MWSTSätze
                Dim rNewMWSTBasen As dbCalc.MWStBasenRow = calc.dbCalc.MWStBasen.NewRow()
                rNewMWSTBasen.ID = VB.LCase(System.Guid.NewGuid().ToString())
                rNewMWSTBasen.MWStSatz = rMWSTSatz.Prozent
                rNewMWSTBasen.KontoExport = rMWSTSatz.KontoExport
                rNewMWSTBasen.NettoBetrag = 0
                rNewMWSTBasen.BruttoBetrag = 0
                rNewMWSTBasen.MWSt = 0
                rNewMWSTBasen.IDKostIntern = VB.LCase(IDKostIntern)
                calc.dbCalc.MWStBasen.Rows.Add(rNewMWSTBasen)
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function newKostenträger(ByRef dbCalc1 As dbCalc) As dbCalc.KostenträgerRow
        Try
            Dim rNew As dbCalc.KostenträgerRow = dbCalc1.Kostenträger.NewRow()
            rNew.IDKostIntern = ""
            rNew.IDKost = ""
            rNew.FamName = ""
            rNew.SammelabrechnungJN = False
            rNew.von = Now
            rNew.bis = Now
            rNew.GrundleistungJN = False
            rNew.PeriodischeLeistungJN = False
            rNew.SonderleistungJN = False
            rNew.VorauszahlungJN = False
            rNew.RechnungJN = False
            rNew.RechnungTyp = 0
            rNew.MaxBetragBrutto = 0
            rNew.RestzahlerJN = False
            rNew.Rang = 0
            rNew.KlientenbezogenJN = False
            rNew.TransferzahlerJN = False
            rNew.ZahlungsbetragNetto = 0
            rNew.ZahlungsbetragBrutto = 0
            rNew.Rundungsausgleich = 0
            rNew.ZuschlagGrundleistungJN = False
            rNew.ZuschlagGrundleistungProzent = 0
            rNew.ZuschlagGrundleistungBetrag = 0
            rNew.FreieBuchungBetragNetto = 0
            rNew.IDKlient = ""
            rNew.Ueberweisungsbetrag = 0
            rNew.RechnungTyp = eBillTyp.Rechnung
            rNew.Rechnung = ""
            rNew.sumNetto = 0
            rNew.sumBrutto = 0
            rNew.ForderungBruttoAlt = 0
            rNew.FIBU = ""
            rNew.SetIDKlinikNull()

            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class