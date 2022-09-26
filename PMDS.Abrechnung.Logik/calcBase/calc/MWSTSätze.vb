Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic




Public Class MWSTSätze
    Inherits calcBase


    Public Shared tMWSTSätzeFromFile As New dbPMDS.MWSTSätzeDataTable




    Public Sub init(ByRef tMWSTSätze As dbPMDS.MWSTSätzeDataTable)
        Try
            If MWSTSätze.tMWSTSätzeFromFile.Rows.Count > 0 Then
                For Each rMWStFromFile As dbPMDS.MWSTSätzeRow In MWSTSätze.tMWSTSätzeFromFile
                    Dim rNew As dbPMDS.MWSTSätzeRow = tMWSTSätze.NewRow()
                    rNew.Prozent = rMWStFromFile.Prozent
                    rNew.KontoExport = rMWStFromFile.KontoExport
                    tMWSTSätze.Rows.Add(rNew)
                Next
            Else
                Dim rNew As dbPMDS.MWSTSätzeRow = tMWSTSätze.NewRow()
                rNew.Prozent = 0
                rNew.KontoExport = ""
                tMWSTSätze.Rows.Add(rNew)

                rNew = tMWSTSätze.NewRow()
                rNew.Prozent = 10
                rNew.KontoExport = ""
                tMWSTSätze.Rows.Add(rNew)

                rNew = tMWSTSätze.NewRow()
                rNew.Prozent = 20
                rNew.KontoExport = ""
                tMWSTSätze.Rows.Add(rNew)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Shared Function loadMWSTSätzeFromFile() As Boolean
        Try
            Dim filToLoad As String = calculation.pathConfig + "\" + calcBase.fileMWStSätze
            If System.IO.File.Exists(filToLoad) Then
                MWSTSätze.tMWSTSätzeFromFile.Rows.Clear()
                Dim reader As New System.IO.StreamReader(filToLoad)
                Do While reader.Peek() >= 0
                    Dim sLine As String = reader.ReadLine
                    If (sLine.Trim() <> "") Then
                        If sLine.Trim().Substring(0, 2) <> ("//") Then
                            Dim fields As String() = sLine.Split(New Char() {";"})
                            If fields(0).Trim().Equals("MWST", StringComparison.CurrentCultureIgnoreCase) Then
                                Dim rNew As dbPMDS.MWSTSätzeRow = MWSTSätze.tMWSTSätzeFromFile.NewRow()
                                rNew.Prozent = System.Convert.ToInt32(fields(1).Trim())
                                rNew.KontoExport = fields(2).Trim()
                                MWSTSätze.tMWSTSätzeFromFile.Rows.Add(rNew)
                            End If
                        End If
                    End If
                Loop
                reader.Close()
                Return True
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        Finally
        End Try
    End Function

End Class