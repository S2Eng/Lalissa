Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class calcData

    Public dbCalc As dbCalc
    Public dbBill As New dbBill()
    Public tTransferAlleKost As New dbPMDS.helpDataTable

    Public protokoll As String = ""
    Public anz As Integer = 0



    Public Sub New()
        Me.dbCalc = New dbCalc
        Me.dbBill = New dbBill()
    End Sub

End Class
