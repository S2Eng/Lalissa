Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class leistung
    Inherits calcBase



    Public Sub init(ByRef IDKlient As String, ByRef abrechVon As Date, ByRef abrechBis As Date, ByRef calc As calcData, IDKlinik As System.Guid, ByVal calcRun As PMDS.Calc.Logic.eCalcRun)
        Try

            'Ermittelt alle Leistungen und die jeweils gültigen Preise
            Dim von, bis As Object
            Dim Leistungsgruppe As Integer = 0
            Dim i As Integer = 0

            'Leistungen sortiert in Collection schieben
            'Dazu arrays von Cls verwenden, weil Collection sortieren schwierig ist.

            'Reihenfolge der Leistungen:
            '1. Grundleistungen
            '1.a Monatliche
            '1.b Tägliche
            '2. Periodische Leistungen
            '2.a Monatliche
            '2.b Tägliche
            '3. Sonderleistungen

            Dim tGrundleistungenMonatlich As New dbCalc.LeistungenDataTable
            Dim tGrundleistungenTäglich As New dbCalc.LeistungenDataTable
            Dim tPeriodLeistungMonatlich As New dbCalc.LeistungenDataTable
            Dim tPeriodLeistungTäglich As New dbCalc.LeistungenDataTable
            Dim tFreieRechnungen As New dbCalc.LeistungenDataTable

            If Me.rowKlient(calc.dbCalc).calcRun <> eCalcRun.freeBill Then
                '0 = Grundleistung Wohnen, 1 = Grundleistung Pflege, 2 = Periodische Leistung)
                Dim qryLeist As dbQuery = sql.run("Select PatientLeistungsplan.*, Leistungskatalog.Bezeichnung, Leistungskatalog.FIBUKonto, enumLeistungsgruppe, MonatsleistungJN FROM dbo.Leistungskatalog INNER JOIN " & "PatientLeistungsplan ON Leistungskatalog.ID = PatientLeistungsplan.IDLeistungskatalog  WHERE PatientLeistungsplan.IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" & IDKlient & "' " & "ORDER by enumLeistungsgruppe, PatientLeistungsplan.GueltigAb, Leistungskatalog.Bezeichnung", Nothing)
                If qryLeist.table.Rows.Count > 0 Then
                    For Each r As DataRow In qryLeist.table.Rows
                        von = Me.Max((abrechVon), DateSerial(Year(r("GueltigAb")), Month(r("GueltigAb")), VB.Day(r("GueltigAb"))))
                        If IsDBNull(r("GueltigBis")) Then
                            bis = dat2999
                        Else
                            bis = DateSerial(Year(r("GueltigBis")), Month(r("GueltigBis")), VB.Day(r("GueltigBis")))
                        End If

                        'Nur Leistungen, die den Zeitraum betreffen berücksichtigen
                        If bis < abrechVon Or von > abrechBis Then
                            'Skip
                        Else
                            ' Bei Monatsleistungen - wird keine ABwesenheit berücksichtigt

                            ' Monat                        |---------------------------------------------------|
                            ' Preise         X                   X                     X
                            ' = drei Eintrgäge              111112222222222222222222222333333333333333333333333

                            ' an jedem Tag den vollen
                            ' und den reduzierten Preis
                            ' eintragen

                            'Preise holen und Leistungen zuordnen.

                            Dim arrPar1(0) As dbParameter
                            Dim par As New dbParameter
                            par.parameter = New System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb")
                            par.value = abrechBis
                            arrPar1(0) = par
                            Dim qryPreise As dbQuery = sql.run("SELECT ID, IDLeistungskatalog, GueltigAb, GueltigBis,  Betrag, MWST, GutschriftProTagAbwesend, TagsatzberechnungJN  FROM LeistungskatalogGueltig WHERE IDLeistungskatalog = '" & r("IDLeistungskatalog").ToString() & "' " & "AND GueltigAb <= ? ORDER BY GueltigAb desc ", arrPar1)
                            If qryPreise.table.Rows.Count > 0 Then
                                'Preise haben nur ein von-Datum. Bis Datum einfügen, damit das Matchen einfacher geht.
                                Dim bFirst As Boolean = False
                                Dim GueltigAbNext As Date

                                If qryPreise.table.Rows.Count > 0 Then
                                    For Each rPreise As DataRow In qryPreise.table.Rows

                                        If Not bFirst Then
                                            rPreise("GueltigBis") = Me.Min(IIf(rPreise("GueltigBis") Is System.DBNull.Value, dat2999, rPreise("GueltigBis")), abrechBis)
                                            bFirst = True
                                            GueltigAbNext = rPreise("GueltigAb")
                                        Else

                                            rPreise("GueltigBis") = GueltigAbNext.AddDays(-1)
                                            GueltigAbNext = rPreise("GueltigAb")

                                        End If
                                    Next
                                End If

                                For Each rPreise As DataRow In qryPreise.table.Rows
                                    'Preise die Außerhalb des Abrechnungszeitraums liegen nicht berücksichtigen
                                    If rPreise("GueltigBis") < abrechVon Or rPreise("GueltigAb") > abrechBis Then Continue For

                                    rPreise("GueltigAb") = DateSerial(Year(rPreise("GueltigAb")), Month(rPreise("GueltigAb")), VB.Day(rPreise("GueltigAb"))) 'Uhrzeit wegschneiden

                                    rPreise("GueltigAb") = Me.Max(rPreise("GueltigAb"), von)
                                    rPreise("GueltigBis") = Me.Min(rPreise("GueltigBis"), bis)

                                    Dim rNew As dbCalc.LeistungenRow = Me.newLeistung(calc)
                                    i = i + 1
                                    rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
                                    rNew.LeistungBezeichnung = r("Bezeichnung")
                                    rNew.IDLeistungskatalog = VB.LCase(rPreise("IDLeistungskatalog").ToString())
                                    rNew.MonatsleistungJN = r("MonatsleistungJN")
                                    rNew.Leistungsgruppe = r("enumLeistungsgruppe") '0 = Grundleistung, 1 = Grundleistung, 2 = Periodische Leistung
                                    If Not r("FIBUKonto") Is System.DBNull.Value Then
                                        rNew.FIBU = r("FIBUKonto")
                                    End If
                                    If rNew.MonatsleistungJN = True Then
                                        rNew.MonatspreisNetto = rPreise("Betrag")
                                    Else
                                        rNew.TagespreisNetto = rPreise("Betrag")
                                    End If

                                    rNew.OffenNetto = rPreise("Betrag")
                                    rNew.Kosten = 0
                                    rNew.TagespreisReduziertNetto = rPreise("Betrag") - rPreise("GutschriftProTagAbwesend")
                                    rNew.MWStSatz = rPreise("MWSt")

                                    rNew.Von = Me.Max(rPreise("GueltigAb"), (abrechVon))
                                    rNew.Bis = Me.Min(rPreise("GueltigBis"), (abrechBis))
                                    rNew.Nummer = i

                                    If rNew.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rNew.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente Then
                                        If rNew.MonatsleistungJN = False Then
                                            Dim rGrundleistungenTäglich As dbCalc.LeistungenRow = tGrundleistungenTäglich.NewRow()
                                            rGrundleistungenTäglich.ItemArray = rNew.ItemArray()
                                            tGrundleistungenTäglich.Rows.Add(rGrundleistungenTäglich)
                                        Else
                                            Dim rGrundleistungenMonatlich As dbCalc.LeistungenRow = tGrundleistungenMonatlich.NewRow()
                                            rGrundleistungenMonatlich.ItemArray = rNew.ItemArray()
                                            tGrundleistungenMonatlich.Rows.Add(rGrundleistungenMonatlich)
                                        End If

                                    ElseIf rNew.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Then
                                        If rNew.MonatsleistungJN = False Then
                                            Dim rPeriodLeistungTäglich As dbCalc.LeistungenRow = tPeriodLeistungTäglich.NewRow()
                                            rPeriodLeistungTäglich.ItemArray = rNew.ItemArray()
                                            tPeriodLeistungTäglich.Rows.Add(rPeriodLeistungTäglich)
                                        Else
                                            Dim rPeriodLeistungMonatlich As dbCalc.LeistungenRow = tPeriodLeistungMonatlich.NewRow()
                                            rPeriodLeistungMonatlich.ItemArray = rNew.ItemArray()
                                            tPeriodLeistungMonatlich.Rows.Add(rPeriodLeistungMonatlich)
                                        End If
                                    Else
                                        Throw New Exception("leistung.New: Keine leistung für IDLeistungskatalog '" + rNew.IDLeistungskatalog.ToString() + "'")
                                    End If
                                    '                        ln.Add l

                                Next
                            Else
                                'kein Preis = keine Leistungsverrechnung
                            End If

                        End If
                    Next
                End If
            End If
            '-------------- Manuelle und freie Buchungen

            'Trägt die manuellen Buchungen in die Leistungen des Klienten als Monatsleistung ein
            'Es kann kein Tagsatz errechnet werden, weil direkt ein Preis mitgegeben wird, daher keine Collection colTageleistung nötig

            'Sonderleistungen werden im Sonderleistungesbereich erfasst, werden hier nicht mehr berücksichtigt.
            'Erfassungsmaske ändern

            'Freie Buchungen haben einen bestimmten Kostenträger.
            'i = Me.calc.dbCalc.Leistungen.Rows.Count

            Dim arrPar(1) As dbParameter
            Dim par1 As New dbParameter
            par1.parameter = New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")
            par1.value = abrechVon : arrPar(0) = par1
            Dim par2 As New dbParameter
            par2.parameter = New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")
            par2.value = abrechBis : arrPar(1) = par2

            Dim selManFree As String = ""
            If Me.rowKlient(calc.dbCalc).calcRun = eCalcRun.freeBill Then
                selManFree = " and typ = " + CInt(eCalcRun.freeBill).ToString() + " "        'nur die freien Buchungen
            Else
                selManFree = " and typ <> " + CInt(eCalcRun.freeBill).ToString() + " "       'Alle außer freie Buchungen
            End If

            Dim qryManBuch As dbQuery = sql.run("SELECT * FROM manBuch WHERE IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDKlient) = '" + IDKlient & "' " + selManFree + "AND Datum BETWEEN ?  AND ? Order BY datum asc, am asc", arrPar)
            If qryManBuch.table.Rows.Count > 0 Then

                For Each r As DataRow In qryManBuch.table.Rows

                    Select Case r("abrechGruppe")
                        Case 0
                            Leistungsgruppe = 0 '(0 .. Wohnkomp., 1 .. Pflegekomp.)
                        Case 2
                            Leistungsgruppe = 2
                        Case Else
                            Leistungsgruppe = -1 'Freie Buchung
                    End Select

                    Dim rNew As dbCalc.LeistungenRow = Me.newLeistung(calc)

                    i = i + 1
                    rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
                    rNew.LeistungBezeichnung = r("BuchText")
                    rNew.MonatsleistungJN = True
                    rNew.Leistungsgruppe = Leistungsgruppe
                    rNew.MonatspreisNetto = r("Betrag")
                    rNew.MWStSatz = r("MWSt")
                    rNew.Nummer = i
                    rNew.Von = r("Datum")
                    rNew.Bis = r("Datum")
                    rNew.ZeitraumDetail = r("ZeitraumDetail")
                    rNew.IDManBuch = VB.LCase(r("ID").ToString())
                    rNew.OffenNetto = rNew.MonatspreisNetto
                    rNew.FIBU = r("FIBUKonto")
                    If Not IsDBNull(r("IDRef")) Then
                        rNew.IDKostentraegerFrBuch = r("IDRef").ToString() 'Freie Buchung -> ID des Kostenträgers (nicht von PatientKostentraeger!)
                        rNew.LeistungBezeichnung = r("BuchText") & ", " & r("ZeitraumDetail")
                    End If

                    If rNew.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rNew.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente Then
                        Dim rGrundleistungenMonatlich As dbCalc.LeistungenRow = tGrundleistungenMonatlich.NewRow()
                        rGrundleistungenMonatlich.ItemArray = rNew.ItemArray()
                        tGrundleistungenMonatlich.Rows.Add(rGrundleistungenMonatlich)
                    ElseIf rNew.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Then
                        Dim rPeriodLeistungMonatlich As dbCalc.LeistungenRow = tPeriodLeistungMonatlich.NewRow()
                        rPeriodLeistungMonatlich.ItemArray = rNew.ItemArray()
                        tPeriodLeistungMonatlich.Rows.Add(rPeriodLeistungMonatlich)
                    Else
                        Dim rFreieRechnungen As dbCalc.LeistungenRow = tFreieRechnungen.NewRow()
                        rFreieRechnungen.ItemArray = rNew.ItemArray()
                        tFreieRechnungen.Rows.Add(rFreieRechnungen)
                    End If

                Next
            End If

            'Daten sortiert in die table Leistungen schreiben
            For Each r As dbCalc.LeistungenRow In tFreieRechnungen
                Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
                rNew.ItemArray = r.ItemArray()
                calc.dbCalc.Leistungen.Rows.Add(rNew)
            Next

            For Each r As dbCalc.LeistungenRow In tGrundleistungenMonatlich
                Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
                rNew.ItemArray = r.ItemArray()
                calc.dbCalc.Leistungen.Rows.Add(rNew)
            Next

            For Each r As dbCalc.LeistungenRow In tGrundleistungenTäglich
                Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
                rNew.ItemArray = r.ItemArray()
                calc.dbCalc.Leistungen.Rows.Add(rNew)
            Next

            For Each r As dbCalc.LeistungenRow In tPeriodLeistungMonatlich
                Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
                rNew.ItemArray = r.ItemArray()
                calc.dbCalc.Leistungen.Rows.Add(rNew)
            Next

            For Each r As dbCalc.LeistungenRow In tPeriodLeistungTäglich
                Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
                rNew.ItemArray = r.ItemArray()
                calc.dbCalc.Leistungen.Rows.Add(rNew)
            Next

            If calcRun <> eCalcRun.freeBill Then
                Me.initSonderLeist(IDKlient, abrechVon, abrechBis, i, calc, IDKlinik, calcRun)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Private Sub initSonderLeist(ByRef IDKlient As String, ByRef abrechVon As Date, ByRef abrechBis As Date, ByRef i As Integer,
                                ByRef calc As calcData, IDKlinik As System.Guid, ByVal calcRun As PMDS.Calc.Logic.eCalcRun)
        Try

            'Ermittelt alle Sonderleistungen im Abrechnungszeitraum
            Dim arrPar(1) As dbParameter
            Dim par1 As New dbParameter
            par1.parameter = New System.Data.OleDb.OleDbParameter("datumVerrech", System.Data.OleDb.OleDbType.Date, 8, "datumVerrech")
            par1.value = abrechVon : arrPar(0) = par1
            Dim par2 As New dbParameter
            par2.parameter = New System.Data.OleDb.OleDbParameter("datumVerrech", System.Data.OleDb.OleDbType.Date, 8, "datumVerrech")
            par2.value = abrechBis : arrPar(1) = par2

            Dim qrySonderLeist As dbQuery = sql.run("SELECT PatientSonderleistung.*, SonderleistungsKatalog.FIBU, SonderleistungsKatalog.Mwst as Mwst2 FROM PatientSonderleistung, SonderleistungsKatalog WHERE PatientSonderleistung.IDSonderleistungskatalog=SonderleistungsKatalog.ID and PatientSonderleistung.IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" & IDKlient & "' " & "AND datumVerrech BETWEEN ? AND ? Order BY Datum", arrPar)
            If qrySonderLeist.table.Rows.Count > 0 Then
                For Each r As DataRow In qrySonderLeist.table.Rows

                    Dim rNew As dbCalc.LeistungenRow = Me.newLeistung(calc)
                    rNew.ID = System.Guid.NewGuid.ToString()
                    i = i + 1

                    Dim dat As New Date()
                    dat = r("datumVerrech")

                    rNew.Von = dat.Date
                    rNew.Bis = dat.Date
                    rNew.Anzahl = r("Anzahl")
                    rNew.LeistungBezeichnung = r("Bezeichnung")
                    rNew.TagespreisNetto = r("Einzelpreis")
                    rNew.TagespreisReduziertNetto = r("Einzelpreis")
                    rNew.MonatspreisNetto = r("Betrag")
                    If ((Not r("MWSt") Is Nothing) AndAlso r("MWSt").ToString().Trim() <> "") Then
                        rNew.MWStSatz = r("MWSt")
                    End If
                    'If ((Not r("Mwst2") Is Nothing) AndAlso r("Mwst2").ToString().Trim() <> "") Then
                    '    rNew.MWStSatz = r("Mwst2")
                    'Else
                    '    If ((Not r("MWSt") Is Nothing) AndAlso r("MWSt").ToString().Trim() <> "") Then
                    '        rNew.MWStSatz = r("MWSt")
                    '    End If
                    'End If

                    rNew.IDSonderleistung = VB.LCase(r("ID").ToString())
                    rNew.OffenNetto = rNew.MonatspreisNetto
                    rNew.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen
                    rNew.Nummer = i
                    rNew.MonatsleistungJN = True
                    rNew.FIBU = r("FIBU")

                    calc.dbCalc.Leistungen.Rows.Add(rNew)
                Next
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub doTagesLeist(ByRef calc As calcData)
        Try

            Dim j As Integer = 0
            Dim IstPreis As Decimal = 0
            Dim TageVoll As Integer = 0
            Dim TageReduziert As Integer = 0
            Dim ReduziertJN As Boolean = False
            Dim ReduziertJNTagsatzliste As Boolean = False

            For Each rLeist As dbCalc.LeistungenRow In calc.dbCalc.Leistungen

                TageVoll = 0
                TageReduziert = 0

                If rLeist.MonatsleistungJN = False Then 'Tagesleistung und NICHT manuelle Buchung

                    Dim von As Date = Me.Max(rLeist.Von, Me.rowMonat(calc.dbCalc).Beginn)
                    Dim bis As Date = Me.Min(rLeist.Bis, Me.rowMonat(calc.dbCalc).Ende)
                    Dim d As Date = von
                    While d.Date <= bis.Date

                        'IstPreis am jeweiligen Tag berechnen:
                        'Wenn Aufenthalt (Status <> 0) und nicht gekürzt -> Normalpreis
                        'Wenn Aufenthalt (Status = 1,2,3)  und gekürzt -> Reduzierter Preis
                        'Wenn nicht anwesend = 0 Euro.

                        ' Anwesenheitsstatus   0 .. Bewohner ist nicht aufgenommen
                        '                      1 ... Bewohner ist anwesend, keine Kürzung
                        '                      2´... Bewohner ist abwesend, Kürzung
                        '                      3 ... Bewohner ist abwesend, kein Kürzung

                        Dim rTag As dbCalc.TageRow = Me.selectTag(d, calc.dbCalc, True)
                        If rTag.Anwesenheitsstatus <> 0 And rTag.KürzungJN = True Then
                            ' Bei Vorrauszahlung keinen reduz. Tagespreis berücksichtigen
                            If Me.rowKlient(calc.dbCalc).calcTyp = PMDS.Calc.Logic.eCalcTyp.vorauszahlung Then
                                IstPreis = rLeist.TagespreisNetto
                                ReduziertJN = False
                            Else
                                IstPreis = rLeist.TagespreisReduziertNetto
                                ReduziertJN = True
                            End If
                        ElseIf rTag.Anwesenheitsstatus <> 0 And rTag.KürzungJN = False Then
                            IstPreis = rLeist.TagespreisNetto
                            ReduziertJN = False
                        Else
                            IstPreis = 0
                        End If

                        'Leistungspreis erfassen, wenn <> 0
                        If IstPreis <> 0 Then

                            'Keine Zeilen zusammenfassen für Tagsatzliste
                            ReduziertJNTagsatzliste = ReduziertJN

                            If ReduziertJN = True Then
                                If rLeist.TagespreisReduziertNetto = rLeist.TagespreisNetto Then
                                    ReduziertJN = False
                                Else 'Reduzierte Tage nur ausweisen, wenn der Tagsatz wirklich reduziert ist
                                    ReduziertJN = True
                                End If
                            Else
                                ReduziertJN = False
                            End If

                            Dim rNewTagesLeist As dbCalc.TagesleistungenRow = calc.dbCalc.Tagesleistungen.NewRow()
                            j += 1
                            rNewTagesLeist.Leistungsgruppe = rLeist.Leistungsgruppe
                            rNewTagesLeist.MWStSatz = rLeist.MWStSatz
                            rNewTagesLeist.TagespreisNetto = rLeist.TagespreisNetto
                            rNewTagesLeist.TagespreisReduziertNetto = rLeist.TagespreisReduziertNetto
                            rNewTagesLeist.IDLeistungskatalog = rLeist.IDLeistungskatalog
                            rNewTagesLeist.LeistungBezeichnung = rLeist.LeistungBezeichnung
                            rNewTagesLeist.Nummer = j

                            rNewTagesLeist.IstPreisNetto = IstPreis
                            rNewTagesLeist.Kosten = IstPreis
                            rNewTagesLeist.OffenNetto = IstPreis

                            rNewTagesLeist.ReduziertJN = ReduziertJN
                            rNewTagesLeist.ReduziertJNTagsatzliste = ReduziertJNTagsatzliste

                            Dim rTag2 As dbCalc.TageRow = Me.selectTag(d, calc.dbCalc, True)
                            rNewTagesLeist.Datum = rTag2.Datum
                            rNewTagesLeist.Jahr = rTag2.Jahr
                            rNewTagesLeist.Monat = rTag2.Monat
                            rNewTagesLeist.Tag = rTag2.Tag
                            rNewTagesLeist.Wochentag = rTag2.Wochentag
                            rNewTagesLeist.IDLeistung = rLeist.ID

                            calc.dbCalc.Tagesleistungen.Rows.Add(rNewTagesLeist)

                        End If
                        d = d.AddDays(1)
                    End While

                Else 'Monatsleistung oder manuelle Buchung

                    'Keine Tagespreise ermitteln

                End If

            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub


    Public Function newLeistung(ByRef calc As calcData) As dbCalc.LeistungenRow
        Try
            Dim rNew As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.NewRow()
            rNew.ID = ""
            rNew.LeistungBezeichnung = ""
            rNew.IDLeistungskatalog = ""
            rNew.MonatsleistungJN = False
            rNew.Leistungsgruppe = 0
            rNew.Anzahl = 0
            rNew.ZeitraumDetail = ""
            rNew.IDManBuch = ""
            rNew.IDSonderleistung = ""
            rNew.IDKostentraegerFrBuch = ""
            rNew.MonatspreisNetto = 0
            rNew.TagespreisNetto = 0
            rNew.MonatspreisNetto = 0
            rNew.OffenNetto = 0
            rNew.TagespreisReduziertNetto = 0
            rNew.MWStSatz = 0
            rNew.Kosten = 0
            rNew.SetVonNull()
            rNew.SetBisNull()
            rNew.Nummer = 0
            rNew.FIBU = ""

            Return rNew

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

End Class