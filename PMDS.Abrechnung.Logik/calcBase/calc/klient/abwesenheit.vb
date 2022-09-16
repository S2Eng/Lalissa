Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class abwesenheit
    Inherits calcBase




    Public Sub init(ByRef IDKlient As String, ByRef abrechVon As Date, ByRef abrechBis As Date, ByRef Calc As calcData, IDKlinik As System.Guid)
        Try
            'Abwesenheiten zum Aufenthalt auflisten
            Dim von As Object
            Dim bis As Date
            Dim i As Integer = 0

            Dim qryAbw As dbQuery = Me.sql.run("SELECT * FROM PatientAbwesenheit WHERE IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" & IDKlient & "' ORDER BY von", Nothing)
            If qryAbw.table.Rows.Count > 0 Then
                For Each r As DataRow In qryAbw.table.Rows

                    von = DateSerial(Year(r("von")), Month(r("von")), VB.Day(r("von")))
                    If IsDBNull(r("bis")) Then
                        bis = Me.dat2999
                    Else
                        bis = DateSerial(Year(r("bis")), Month(r("bis")), VB.Day(r("bis")))
                    End If

                    'Nur Abwesenheiten, die den Zeitraum betreffen berücksichtigen
                    If bis < abrechVon Or von > abrechBis Then
                        'Skip
                    Else
                        Dim rNew As dbCalc.AbwesenheitenRow = Calc.dbCalc.Abwesenheiten.NewRow()
                        i = i + 1
                        rNew.Von = von
                        rNew.Bis = bis
                        rNew.Nummer = i
                        rNew.ID = VB.LCase(r("ID").ToString())
                        rNew.IDKlient = IDKlient
                        rNew.Grund = r("Grund")
                        rNew.TageOhneKürzung = r("abTagN")
                        rNew.IDKlient = VB.LCase(IDKlient)
                        rNew.KuerzungGrundleistungLetzterTag = calcBase.KuerzungGrundleistungLetzterTag

                        Calc.dbCalc.Abwesenheiten.Rows.Add(rNew)
                    End If
                Next
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub
    Public Sub prepare(ByRef Calc As calcData)
        Try
            'Anwesenheiten im Monat eintragen
            Dim BeginnKuerzung As Date
            Dim EndeKuerzung As Date
            Dim LetzterTag As Date
            Dim KeineKürzung As Boolean = False

            'Abwesenheiten im collection Monat eintragen
            For Each rAbw As dbCalc.AbwesenheitenRow In Calc.dbCalc.Abwesenheiten
                BeginnKuerzung = Me.Max(System.DateTime.FromOADate(rAbw.Von.ToOADate + rAbw.TageOhneKürzung), Me.rowMonat(Calc.dbCalc).Beginn)

                If calcBase.KürzGrundLetztTag Then
                    EndeKuerzung = Me.Min((rAbw.Bis), Me.rowMonat(Calc.dbCalc).Ende)
                    LetzterTag = EndeKuerzung
                Else
                    If System.DateTime.FromOADate(rAbw.Bis.ToOADate) = Me.dat2999 Then                           'Wenn noch nicht zurückgekehrt, 
                        EndeKuerzung = Me.rowMonat(Calc.dbCalc).Ende
                        LetzterTag = Me.rowMonat(Calc.dbCalc).Ende
                    Else
                        EndeKuerzung = Me.Min(System.DateTime.FromOADate(rAbw.Bis.ToOADate - 1), Me.rowMonat(Calc.dbCalc).Ende) 'einen Tag abziehen, wenn letzter Tag nicht gekürzt wird.
                        LetzterTag = EndeKuerzung.AddDays(1)
                    End If
                End If

                If BeginnKuerzung > EndeKuerzung Then
                    KeineKürzung = True
                End If

                Dim dIterate As Date = BeginnKuerzung
                Dim rtag As dbCalc.TageRow
                While dIterate.Date <= EndeKuerzung.Date
                    rtag = Me.selectTag(dIterate, Calc.dbCalc, True)

                    If rtag.Anwesenheitsstatus = 1 Then
                        rtag.Anwesenheitsstatus = 2
                        rtag.Grund = rAbw.Grund.Trim()
                        rtag.AbwVon = rAbw.Von
                        rtag.IDAbwesenheit = rAbw.ID
                        rtag.AbwBis = rAbw.Bis
                    End If
                    dIterate = dIterate.AddDays(1)
                End While

                Dim dIterate2 As Date = rAbw.Von.Date
                While dIterate2.Date <= rAbw.Bis.Date
                    rtag = Me.selectTag(dIterate2, Calc.dbCalc, False)

                    If Not rtag Is Nothing Then
                        If rtag.Anwesenheitsstatus > 0 Then
                            rtag.Abwesenheitsstatus = 2
                            rtag.IDAbwesenheit = rAbw.ID
                        End If
                    End If
                    dIterate2 = dIterate2.AddDays(1)
                End While

                If LetzterTag > EndeKuerzung And LetzterTag <> Me.dat2999 Then
                    Dim abrechMonat As Date = Me.rowMonat(Calc.dbCalc).Beginn
                    Dim iLastDayInMonth As Integer = DateTime.DaysInMonth(abrechMonat.Year, abrechMonat.Month)
                    Dim dLastDayinMonth As New Date(abrechMonat.Year, abrechMonat.Month, iLastDayInMonth)
                    If LetzterTag.Date > dLastDayinMonth.Date Then
                        'rtag = Me.selectTag(LetzterTag, Calc.dbCalc)
                        rtag = Me.selectTag(dLastDayinMonth.Date, Calc.dbCalc, True)
                    Else
                        rtag = Me.selectTag(LetzterTag, Calc.dbCalc, True)
                    End If

                    If rtag.Anwesenheitsstatus = 3 Then         '= Entlassungstag

                        If Not KeineKürzung Then
                            rtag.Anwesenheitsstatus = 4         '= Patient ist extern entlassen (jedenfalls kürzen)
                            rtag.Abwesenheitsstatus = 4
                        End If

                        rtag.Grund = rAbw.Grund.Trim()
                        rtag.AbwVon = rAbw.Von
                        rtag.AbwBis = rAbw.Bis
                    End If
                End If
            Next

            'Kürzungen im ganzen Monat kennzeichnen
            For Each rtag As dbCalc.TageRow In Calc.dbCalc.Tage
                If rtag.Anwesenheitsstatus = 2 Then
                    rtag.KürzungJN = True
                End If

                'If rtag.Anwesenheitsstatus = 3 And (Me.rowKlient(Calc.dbCalc).KürzungLetzterTagAnwesenheit Or rtag.Abwesenheitsstatus = 2) Then  'Falsch: hier wird bei Abwesenheit am letzten Tag jedenfalls gekürzt!
                '
                If rtag.Anwesenheitsstatus = 3 And Me.rowKlient(Calc.dbCalc).KürzungLetzterTagAnwesenheit And (rtag.Abwesenheitsstatus = 2 Or rtag.Abwesenheitsstatus = 3) Then
                    rtag.KürzungJN = True
                    'rtag.Anwesenheitsstatus = 0            //os: Kürzung muss hier her, nicht Anwesenheitsstatus = 0
                End If

                '4.. Wenn der Patient extern verstorben ist -> Immer kürzen
                If rtag.Anwesenheitsstatus = 4 Then
                    rtag.KürzungJN = True
                End If
            Next

            ''Kürzungen kennzeichnen
            'von = Me.Max(BeginnKuerzung, Me.rowMonat(Calc.dbCalc).Beginn)
            'bis = Me.Min(EndeKuerzung, Me.rowMonat(Calc.dbCalc).Ende)
            'dIterate = von
            'While dIterate.Date <= bis.Date

            '    Dim rTag As dbCalc.TageRow = Me.selectTag(dIterate, Calc.dbCalc)
            '    'If m.Item(VB6.Format(i, "YYYYMMDD")).Anwesenheitsstatus = 2 Then
            '    If rTag.Anwesenheitsstatus = 2 Then
            '        rTag.KürzungJN = True
            '    End If
            '    dIterate = dIterate.AddDays(1)
            'End While

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class