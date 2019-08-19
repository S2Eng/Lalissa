Option Strict Off
Option Explicit On



Public Class doCalc
    Inherits calcBase


    Public Sub run(ByRef calc As calcData)
        Try
            'Reihenfolge der Leistungen:
            '1. Grundleistungen
            '1.a Monatliche
            '1.b Tägliche
            '2. Periodische Leistungen
            '2.a Monatliche
            '2.b Tägliche
            '3. Sonderleistungen

            'Reihenfolge der Leistungen bereits richtig in der Collection
            'Reihenfolge der Zahler nach Rang und GueltigAb aufsteigend bereits richtig in Collection Collection

            Me.kostenAufsummieren(calc)

            Dim arrLeistungen() As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.Select("", "Nummer asc")
            For Each rLeist As dbCalc.LeistungenRow In arrLeistungen           'Alle Leistungen iterieren

                Dim arrKostenträger() As dbCalc.KostenträgerRow = calc.dbCalc.Kostenträger.Select("Rang <> 10", "Rang asc")
                For Each rKost As dbCalc.KostenträgerRow In arrKostenträger

                    For Each rLeistInnen As dbCalc.LeistungenRow In arrLeistungen   'pro Kostenträger alle Leistungen iterieren
                        'notwendig, weil ein Kostenträger mehrere Leistungen bezahlen kann
                        'Wenn eine Leistung vollständig abgerechnet ist, ist der Betrag offen = 0
                        'damit zahlt kein anderer mehr.

                        If rLeistInnen.Leistungsgruppe = rLeist.Leistungsgruppe Then

                            'Wenn der Kostenträger die Leistungsart bezahlt
                            '0 = Grundleistung Wohnen, 1 = Grundleistung Pflege, 2 = Periodische Leistung, 3 = Sonderleistungen)
                            If rLeistInnen.Leistungsgruppe = (doCalc.Leistungsgruppe.Wohnkomponente) Or _
                                                              (rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente And rKost.GrundleistungJN = True) Or _
                                                              (rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen And rKost.PeriodischeLeistungJN = True) Or _
                                                              (rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen And rKost.SonderleistungJN = True) Then

                                'Wenn der Kostenträger noch etwas zahlen kann
                                If (rKost.MaxBetragBrutto > 0 And rKost.ZahlungsbetragBrutto < rKost.MaxBetragBrutto) Then

                                    Dim rOffLeist As dbPMDS.OffeneLeistungenRow
                                    rOffLeist = Me.getOffKosten(rLeistInnen, rKost, calc)

                                    If (rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente) And rKost.GrundleistungJN = True Then
                                        '--- Grundleistungen
                                        If rOffLeist.GrundleistungMonatlich <> 0 Or rOffLeist.GrundleistungTäglich <> 0 Then Me.ZahlAbziehen(rKost, rLeistInnen, 1, calc)

                                    ElseIf rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen And rKost.PeriodischeLeistungJN = True Then
                                        '--- Periodische Leistungen
                                        If rOffLeist.PeriodischeLeistungMonatlich <> 0 Or rOffLeist.PeriodischeLeistungTäglich <> 0 Then Me.ZahlAbziehen(rKost, rLeistInnen, 2, calc)

                                    ElseIf rLeistInnen.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen And rKost.SonderleistungJN = True Then
                                        '--- Sonderleistungen
                                        If rOffLeist.Sonderleistung <> 0 Then Me.ZahlAbziehen(rKost, rLeistInnen, 3, calc)

                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Next

            Me.calcZuschlag(calc)       ' Zuschläge berechnen
            Me.kumzahlProKost(calc)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub runFreeBill(ByRef calc As calcData)
        Try
            Me.kostenAufsummieren(calc)

            Dim arrLeistungen() As dbCalc.LeistungenRow = calc.dbCalc.Leistungen.Select("", "Nummer asc")
            For Each rLeist As dbCalc.LeistungenRow In arrLeistungen           'Alle Leistungen iterieren
                For Each rKost As dbCalc.KostenträgerRow In calc.dbCalc.Kostenträger

                    'os xy Fehlerbehebung: Prüfen, ob der Kostenträger zum Zeitpunkt der Leistung überhaupt zahlt.

                    If rLeist.IDKostentraegerFrBuch.Equals(rKost.IDKost) Then
                        Me.ZahlBuchen(rKost, rLeist, (rLeist.MonatspreisNetto), rLeist.MonatspreisNetto * (100 + rLeist.MWStSatz) / 100, calc)
                        'rKost.FreieBuchungBetragNetto += rLeist.MonatspreisNetto
                        'rLeist.OffenNetto = 0 'als bezahlt kennzeichnen
                    End If
                Next
            Next

            Me.kumzahlProKost(calc)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub kumzahlProKost(ByRef calc As calcData)
        Try
            'MWSt und Zahlungsbeträge pro Kostenträger kumulieren
            For Each rKost As dbCalc.KostenträgerRow In calc.dbCalc.Kostenträger
                Dim arrMWSTBasen As dbCalc.MWStBasenRow() = calc.dbCalc.MWStBasen.Select("IDKostIntern='" + rKost.IDKostIntern.ToString() + "'")
                For Each rMWStBasis As dbCalc.MWStBasenRow In arrMWSTBasen
                    rMWStBasis.MWSt = rMWStBasis.BruttoBetrag - rMWStBasis.NettoBetrag
                    'rKost.Rundungsausgleich += rMWStBasis.NettoBetrag + rMWStBasis.MWSt            'os 15-09-03: nicht mehr nötig, weil Netto nun korrekt gerechnet wird
                Next
                'rKost.Rundungsausgleich =  rKost.ZahlungsbetragBrutto - rKost.Rundungsausgleich
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Private Function getOffKosten(ByRef rLeist As dbCalc.LeistungenRow, ByRef rKost As dbCalc.KostenträgerRow, _
                                  ByRef calc As calcData) As dbPMDS.OffeneLeistungenRow
        Try
            'Gibt alle noch nicht bezahlten Leistungen der angegeben Art im jeweiligen Zeitraum aus
            '0,1 .. Grundleistung
            '2 .. Periodische Leistung
            '3 .. Sonderleistungen

            'ls: Bei Grund- und Periodischen Leistungen ... clsLeistung, bei Sonderleistungen clsSonderleistung
            'colSucheIn: Grund- und Per.Leist: ... colLeistungen,  bei Sonderleistung ... colSonderleistungen

            'Offene Leistungen in Grund- und periodischen Leistungen
            Dim dbHelp As New dbPMDS
            Dim rOffLeist As dbPMDS.OffeneLeistungenRow = dbHelp.OffeneLeistungen.NewRow()
            rOffLeist.GrundleistungMonatlich = 0
            rOffLeist.GrundleistungTäglich = 0
            rOffLeist.PeriodischeLeistungTäglich = 0
            rOffLeist.PeriodischeLeistungMonatlich = 0
            rOffLeist.Sonderleistung = 0
            rOffLeist.FreieBuchungen = 0

            For Each rLeistIterate As dbCalc.LeistungenRow In calc.dbCalc.Leistungen
                Dim ok As Boolean = False
                If rLeist.Nummer = rLeistIterate.Nummer Then
                    ' Monatsleistungen (Monatlich)
                    If rLeistIterate.MonatsleistungJN Then
                        Select Case rLeistIterate.Leistungsgruppe
                            Case -1
                                rOffLeist.FreieBuchungen += rLeistIterate.OffenNetto
                            Case 0, 1
                                rOffLeist.GrundleistungMonatlich += rLeistIterate.OffenNetto
                            Case 2
                                rOffLeist.PeriodischeLeistungMonatlich += rLeistIterate.OffenNetto
                            Case 3
                                rOffLeist.Sonderleistung += rLeistIterate.OffenNetto
                        End Select
                    Else
                        ' Tagesleistungen (Täglich)
                        Dim arrTagesLeist As dbCalc.TagesleistungenRow() = calc.dbCalc.Tagesleistungen.Select("IDLeistung='" + rLeist.ID.ToString() + "'")
                        For Each rTagesLeist As dbCalc.TagesleistungenRow In arrTagesLeist
                            If rTagesLeist.Datum >= rKost.von And rTagesLeist.Datum <= rKost.bis Then
                                Select Case rTagesLeist.Leistungsgruppe
                                    Case 0, 1               '0,1 .. Grundleistung
                                        rOffLeist.GrundleistungTäglich += rTagesLeist.OffenNetto

                                    Case 2                  '2 .. Periodische Leistung
                                        rOffLeist.PeriodischeLeistungTäglich += rTagesLeist.OffenNetto
                                        'es gibt keine täglichen Sonderleistungen
                                End Select
                            End If
                        Next
                    End If
                End If
            Next

            rOffLeist.GrundleistungTäglich = Math.Round(rOffLeist.GrundleistungTäglich, 2)
            rOffLeist.GrundleistungMonatlich = Math.Round(rOffLeist.GrundleistungMonatlich, 2)
            Return rOffLeist

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function ZahlAbziehen(ByRef rKost As dbCalc.KostenträgerRow, ByRef rLeist As dbCalc.LeistungenRow, _
                                     ByRef Leistungsart As Integer, ByRef calc As calcData) As Decimal
        Try
            ' Restbeträge
            Dim NochZahlbarNetto As Decimal = 0

            Dim ZahlungMonatlichBrutto As Decimal = 0
            Dim ZahlungTäglichBrutto As Decimal = 0

            Dim restTäglichBrutto As Decimal = 0
            Dim restTäglichNetto As Decimal = 0

            Dim ZahlungBrutto As Decimal = 0
            Dim ZahlungNetto As Decimal = 0

            Dim MWStBetragTgl As Decimal = 0
            Dim MWStBetragMntl As Decimal = 0

            Dim ZahlungMonatlichNetto As Decimal = 0
            Dim ZahlungTäglichNetto As Decimal = 0

            Dim arrTagesLeist As dbCalc.TagesleistungenRow() = calc.dbCalc.Tagesleistungen.Select("IDLeistung='" + rLeist.ID.ToString() + "'")
            If arrTagesLeist.Length = 0 Then    'Monatsleistungen

                ' Noch nicht bezahlte Leistung lesen
                Dim rOffenLeistHelper As dbPMDS.OffeneLeistungenHelperRow = Me.getOffKostenHelp(rLeist, rKost, calc) 'Restkosten für den Zeitraum holen

                'Max. Zahungen usw. sind brutto, Leistungen sind netto, je nach Leistung kann die MWSt 10 und 20% sein.
                MWStBetragTgl = Math.Round(rOffenLeistHelper.OffeneLeistungTäglich * (rLeist.MWStSatz) / 100, 2)

                NochZahlbarNetto = (rKost.MaxBetragBrutto - rKost.ZahlungsbetragBrutto) / ((100 + rLeist.MWStSatz) / 100) 'Netto

                ZahlungMonatlichNetto = Me.Min(NochZahlbarNetto, rOffenLeistHelper.OffeneLeistungMonatlich)
                MWStBetragMntl = Math.Round(rOffenLeistHelper.OffeneLeistungMonatlich * (rLeist.MWStSatz) / 100, 2)

                ZahlungMonatlichBrutto = ZahlungMonatlichNetto + MWStBetragTgl + MWStBetragMntl

                Me.ZahlBuchen(rKost, rLeist, ZahlungMonatlichNetto, ZahlungMonatlichBrutto, calc)

                rLeist.OffenNetto = rLeist.OffenNetto - ZahlungMonatlichNetto

            Else                                'Tagesleistungen

                Dim KorrekturFaktorGutschrift As Integer = 1

                Dim rOffenLeistHelper As dbPMDS.OffeneLeistungenHelperRow = Me.getOffKostenHelp(rLeist, rKost, calc) 'Restkosten für die Leistung und den Zeitraum holen

                MWStBetragTgl = 0
                MWStBetragTgl = Math.Round(rOffenLeistHelper.OffeneLeistungTäglich * (rLeist.MWStSatz) / 100, 2)

                NochZahlbarNetto = (rKost.MaxBetragBrutto - rKost.ZahlungsbetragBrutto) / ((100 + rLeist.MWStSatz) / 100) 'NettoBetrag, den der Kostenträger noch maximal zahlen kann
                ZahlungTäglichNetto = Me.Min(NochZahlbarNetto, rOffenLeistHelper.OffeneLeistungTäglich)
                ZahlungTäglichBrutto = ZahlungTäglichNetto + MWStBetragTgl 'Betrag, den der Kostenträger für diese Leistung zahlt

                Me.ZahlBuchen(rKost, rLeist, ZahlungTäglichNetto, ZahlungTäglichBrutto, calc)

                'Zuschlag zur Grundleistung berücksichtigen (Nettobetrag in den Klienten eintragen)
                'If rLeist.Leistungsgruppe < 2 And rKost.ZuschlagGrundleistungJN Then rKost.ZuschlagGrundleistungBetrag += rLeist.Kosten * (rKost.ZuschlagGrundleistungProzent / 100)

                'durch die einzelnen Tagesleistungen iterieren und solange abziehen, bis keine Leistung mehr offen ist oder der ZahlungsbetragNetto
                'des Kostenträgers aufgebraucht ist
                'Zeitraum berücksichtigen, in dem der Kostenträger diese Leistung übernimmt.

                restTäglichBrutto = ZahlungTäglichBrutto
                restTäglichNetto = ZahlungTäglichNetto
                For Each rTagLeist As dbCalc.TagesleistungenRow In arrTagesLeist

                    If ZahlungTäglichNetto < 0 Then  'Gutschrift pro Tag abwesend ist größer als Kosten pro Tag
                        KorrekturFaktorGutschrift = -1
                    End If

                    If rTagLeist.Datum >= rKost.von And rTagLeist.Datum <= rKost.bis And rTagLeist.OffenNetto * KorrekturFaktorGutschrift > 0 And ZahlungTäglichNetto * KorrekturFaktorGutschrift > 0 Then

                        MWStBetragTgl = Math.Round(rTagLeist.OffenNetto * (rLeist.MWStSatz) / 100, 2)
                        ZahlungNetto = Me.Min(restTäglichNetto, rTagLeist.OffenNetto)
                        ZahlungBrutto = ZahlungNetto + MWStBetragTgl

                        NochZahlbarNetto = NochZahlbarNetto - ZahlungNetto

                        rTagLeist.OffenNetto = rTagLeist.OffenNetto - ZahlungNetto
                        If rTagLeist.OffenNetto > 0 Then Exit For 'Obergrenze ZahlungsbetragBNetto erreicht, Kostenträger kann nichts mehr zahlen

                        'If NochZahlbarNetto > 0 Then
                        '    restTäglichNetto -= ZahlungNetto
                        '    'rTagLeist.OffenNetto = restTäglichNetto    'osxx
                        'Else
                        '    Exit For    'Obergrenze ZahlungsbetragNetto erreicht, Kostenträger kann nichts mehr zahlen
                        'End If


                    Else
                        'Außerhalb des Zeitraums oder bereits voll bezahlt
                    End If
                Next
            End If

            'Nur für Debug-Kontrolle
            Dim rOffenLeistHelperDebug As dbPMDS.OffeneLeistungenHelperRow = Me.getOffKostenHelp(rLeist, rKost, calc) 'Restkosten für den Zeitraum holen

            Return ZahlungMonatlichBrutto + ZahlungTäglichBrutto
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Private Function getOffKostenHelp(ByRef rLeist As dbCalc.LeistungenRow, ByRef rKost As dbCalc.KostenträgerRow, _
                                      ByRef calc As calcData) As dbPMDS.OffeneLeistungenHelperRow
        Try
            Dim dbHelp As New dbPMDS
            Dim rOffenLeistHelper As dbPMDS.OffeneLeistungenHelperRow = dbHelp.OffeneLeistungenHelper.NewRow()
            rOffenLeistHelper.OffeneLeistungMonatlich = 0
            rOffenLeistHelper.OffeneLeistungTäglich = 0

            Dim rOffLeist As dbPMDS.OffeneLeistungenRow
            rOffLeist = Me.getOffKosten(rLeist, rKost, calc)

            If rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Wohnkomponente Or rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Plegekomponente Then     'Grundleistung
                rOffenLeistHelper.OffeneLeistungMonatlich = rOffLeist.GrundleistungMonatlich
                rOffenLeistHelper.OffeneLeistungTäglich = rOffLeist.GrundleistungTäglich

            ElseIf rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.PeriodischeLeistungen Then  'Periodische Leistung
                rOffenLeistHelper.OffeneLeistungMonatlich = rOffLeist.PeriodischeLeistungMonatlich
                rOffenLeistHelper.OffeneLeistungTäglich = rOffLeist.PeriodischeLeistungTäglich

            ElseIf rLeist.Leistungsgruppe = doCalc.Leistungsgruppe.Sonderleistungen Then  'Sonderleistung
                rOffenLeistHelper.OffeneLeistungMonatlich = rOffLeist.Sonderleistung
                rOffenLeistHelper.OffeneLeistungTäglich = 0
            End If

            Return rOffenLeistHelper

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Sub ZahlBuchen(ByVal rKost As dbCalc.KostenträgerRow, ByVal rLeist As dbCalc.LeistungenRow, _
                                ByRef NettoBetrag As Decimal, ByRef BruttoBetrag As Decimal, ByRef calc As calcData)
        Try
            'Zahlung zur richtigen MWSTBasis hinzuzählen, gesamten BruttoNettoBetrag aktualisieren
            'MWST wird später von der gerundeten Gesamt-Nettosuemme berechnet
            ' Zahler zu Leistung suchen und in speichern

            Dim arrMWSTBasen As dbCalc.MWStBasenRow() = calc.dbCalc.MWStBasen.Select("IDKostIntern='" + rKost.IDKostIntern.ToString() + "'")
            For Each rMWStBasis As dbCalc.MWStBasenRow In arrMWSTBasen
                If rLeist.MWStSatz = rMWStBasis.MWStSatz Then
                    rMWStBasis.NettoBetrag += NettoBetrag
                    rKost.ZahlungsbetragNetto += NettoBetrag
                    rKost.ZahlungsbetragBrutto += BruttoBetrag
                    rMWStBasis.BruttoBetrag += BruttoBetrag
                End If
            Next

            If NettoBetrag <> 0 Then
                'Zahler und Betrag in Leistung eintragen
                Dim ZahlerFound As Boolean = False
                Dim ZahlerImZeitraum = False
                Dim arrZahler As dbCalc.ZahlerRow() = calc.dbCalc.Zahler.Select("IDLeistung='" + rLeist.ID.ToString() + "'")

                For Each rZahler As dbCalc.ZahlerRow In arrZahler
                    If rZahler.IDKostIntern = rKost.IDKostIntern Then
                        rZahler.NettoBetragProLeistung += NettoBetrag
                        rZahler.MWStProLeistung += (BruttoBetrag - NettoBetrag)
                        ZahlerFound = True
                        Exit For
                    End If
                Next

                If ZahlerFound = False Then
                    Dim rNew As dbCalc.ZahlerRow = calc.dbCalc.Zahler.NewRow()
                    rNew.IDKostIntern = rKost.IDKostIntern
                    rNew.IDLeistung = rLeist.ID
                    rNew.NettoBetragProLeistung = NettoBetrag
                    rNew.MWStProLeistung = BruttoBetrag - NettoBetrag
                    calc.dbCalc.Zahler.Rows.Add(rNew)
                End If
            End If
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function getAnwAbw(ByRef dbCalc As dbCalc) As anwAbw
        Try
            Dim res As New anwAbw
            For Each tag As dbCalc.TageRow In dbCalc.Tage
                If tag.Anwesenheitsstatus = 1 Or ((tag.Anwesenheitsstatus = 2 Or tag.Anwesenheitsstatus = 3) And tag.KürzungJN = False) Then
                    res.anw += 1
                ElseIf (tag.Anwesenheitsstatus = 2 Or tag.Anwesenheitsstatus = 3) And tag.KürzungJN = True Then
                    res.abw += 1
                End If
            Next
            Return res

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


    Public Sub kostenAufsummieren(ByRef calc As calcData)
        Try
            For Each rLeist As dbCalc.LeistungenRow In calc.dbCalc.Leistungen
                If rLeist.MonatsleistungJN Then
                    rLeist.Kosten = rLeist.MonatspreisNetto
                Else
                    rLeist.Kosten = 0
                    Dim arrTagesLeist As dbCalc.TagesleistungenRow() = calc.dbCalc.Tagesleistungen.Select("IDLeistung='" + rLeist.ID + "'", "")
                    For Each rTagesLeist As dbCalc.TagesleistungenRow In arrTagesLeist
                        rLeist.Kosten += rTagesLeist.Kosten
                    Next
                End If

                rLeist.Kosten = rLeist.Kosten        '<20120111>
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub calcZuschlag(ByRef calc As calcData)
        Try
            For Each rKost As dbCalc.KostenträgerRow In calc.dbCalc.Kostenträger
                If rKost.ZuschlagGrundleistungJN Then
                    For Each rLeist As dbCalc.LeistungenRow In calc.dbCalc.Leistungen
                        If rLeist.Leistungsgruppe < 2 Then
                            rKost.ZuschlagGrundleistungBetrag += rLeist.Kosten * (rKost.ZuschlagGrundleistungProzent / 100)
                        End If
                    Next
                End If
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Enum Leistungsgruppe As Integer
        Wohnkomponente = 0
        Plegekomponente = 1
        PeriodischeLeistungen = 2
        Sonderleistungen = 3
    End Enum

End Class


