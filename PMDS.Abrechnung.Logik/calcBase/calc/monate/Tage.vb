Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic




Public Class Tage
    Inherits calcBase


    Public Sub init(ByRef dat As Date, ByVal IDMonat As String, ByRef calc As calcData)
        Try
            Dim rNew As dbCalc.TageRow = calc.dbCalc.Tage.NewRow()
            rNew.Datum = dat
            rNew.Wochentag = dat.DayOfWeek   'Left(FormatDateTime(dat, 1), 2)
            rNew.Tag = dat.Day
            rNew.Monat = dat.Month
            rNew.Jahr = dat.Year
            rNew.Anwesenheitsstatus = 0
            rNew.Abwesenheitsstatus = 0
            rNew.KürzungJN = False
            rNew.IDMonat = VB.LCase(IDMonat)
            rNew.IDTagsatz = ""
            rNew.Grund = "Nicht aufgenommen"
            rNew.SetAbwVonNull()
            rNew.SetAbwBisNull()
            rNew.SetIDAbwesenheitNull()

            calc.dbCalc.Tage.Rows.Add(rNew)

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class