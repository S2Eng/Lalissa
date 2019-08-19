Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class monate
    Inherits calcBase


    Public Sub init(ByRef von As Date, ByRef bis As Date, ByVal RechDatum As Date, ByRef calc As calcData)
        Try
            Dim rNew As dbCalc.MonateRow = calc.dbCalc.Monate.NewRow()
            rNew.ID = System.Guid.NewGuid.ToString()
            rNew.Erster = 1
            rNew.Letzter = System.DateTime.DaysInMonth(von.Year, von.Month)
            rNew.Beginn = von
            rNew.Ende = bis
            rNew.RechDatum = RechDatum

            calc.dbCalc.Monate.Rows.Add(rNew)

            Dim d As New Date
            d = von
            While d.Date <= bis.Date
                Dim t As New Tage()
                t.init(d, rNew.ID, calc)
                d = d.AddDays(1)
            End While

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

End Class