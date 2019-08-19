Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic


Public Class anwesenheit
    Inherits calcBase


    Public Sub prepare(ByRef calc As calcData, IDKlinik As System.Guid)
        Try
            'Anwesenheiten im Monat eintragen

            'Abwesenheiten im collection Monat eintragen
            For Each rAnw As dbCalc.AufenthalteRow In calc.dbCalc.Aufenthalte
                If rAnw.IsIDKlinikNull() Then
                    Throw New Exception("anwesenheit.prepare: IDKlinik is null for IDAufenthalt '" + rAnw.ID.ToString() + "'!")
                End If
                If rAnw.IDKlinik = IDKlinik Then
                    Dim von As Date = Me.Max(rAnw.Von, Me.rowMonat(calc.dbCalc).Beginn)
                    Dim bis As Date = Me.Min(rAnw.Bis, Me.rowMonat(calc.dbCalc).Ende)
                    Dim dIterate As Date = von
                    While dIterate.Date <= bis.Date
                        Dim rTag As dbCalc.TageRow = Me.selectTag(dIterate, calc.dbCalc, True)
                        rTag.Anwesenheitsstatus = 1
                        rTag.Abwesenheitsstatus = 1
                        If dIterate.Date = von.Date Then
                            rTag.AbwVon = von.Date
                        End If
                        rTag.Grund = ""
                        rTag.SetAbwVonNull()
                        rTag.SetAbwBisNull()
                        rTag.SetIDAbwesenheitNull()
                        'Kennzeichen des Entlassungstages (wegen Kürzung - muss gekürzt werden, wenn extern verstorben und keine Rückkehr)
                        If rAnw.Bis = dIterate Then
                            rTag.Anwesenheitsstatus = 3
                            rTag.Abwesenheitsstatus = 3
                            rTag.Grund = "Entlassen"
                            rTag.AbwVon = rAnw.Bis
                            rTag.IsAbwBisNull()
                        End If
                        dIterate = dIterate.AddDays(1)
                    End While
                Else
                    Throw New Exception("anwesenheit.prepare:rAnw.IDKlinik <> IDKlinik  for IDAufenthalt '" + rAnw.ID.ToString() + "'!")
                End If

            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class
