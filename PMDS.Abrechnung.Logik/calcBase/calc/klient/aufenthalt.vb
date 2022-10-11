Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class Aufenthalt
    Inherits calcBase



    Public Sub init(ByRef IDKlient As String, ByRef abrechVon As Date, ByRef abrechBis As Date, ByRef calc As calcData, IDKlinik As System.Guid)
        Try
            Dim i As Integer = 0
            Dim von As Object
            Dim bis As Date

            Dim qryAuf As dbQuery = Me.sql.run("SELECT * FROM Aufenthalt WHERE IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" & IDKlient & "' ORDER BY Aufnahmezeitpunkt", Nothing)
            If qryAuf.table.Rows.Count > 0 Then
                For Each r As DataRow In qryAuf.table.Rows

                    von = DateSerial(Year(r("Aufnahmezeitpunkt")), Month(r("Aufnahmezeitpunkt")), VB.Day(r("Aufnahmezeitpunkt")))
                    If IsDBNull(r("Entlassungszeitpunkt")) Then
                        bis = dat2999
                    Else
                        bis = DateSerial(Year(r("Entlassungszeitpunkt")), Month(r("Entlassungszeitpunkt")), VB.Day(r("Entlassungszeitpunkt")))
                    End If

                    If von > abrechBis Or bis < abrechVon Then 'Nur Aufenthalte, die im Abrechnungszeitraum sind
                        'Skip
                    Else
                        Dim rNew As dbCalc.AufenthalteRow = calc.dbCalc.Aufenthalte.NewRow()
                        i = i + 1
                        rNew.Von = von
                        rNew.Bis = bis
                        rNew.Nummer = i
                        rNew.IDKlient = IDKlient
                        rNew.GSBG = IIf(IsDBNull(r("Ausgleichszahlung")), 0, r("Ausgleichszahlung"))
                        rNew.ID = VB.LCase(r("ID").ToString())
                        rNew.IDKlinik = r("IDKlinik")
                        calc.dbCalc.Aufenthalte.Rows.Add(rNew)
                    End If

                Next
            Else
                Dim rNew As dbCalc.AufenthalteRow = calc.dbCalc.Aufenthalte.NewRow()
                rNew.Von = abrechVon
                rNew.Bis = dat2999
                rNew.Nummer = 1
                rNew.IDKlient = IDKlient
                rNew.GSBG = 0
                rNew.ID = VB.LCase(System.Guid.NewGuid.ToString())
                rNew.IDKlinik = IDKlinik
                calc.dbCalc.Aufenthalte.Rows.Add(rNew)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class