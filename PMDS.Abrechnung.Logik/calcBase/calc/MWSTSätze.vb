Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic




Public Class MWSTS�tze
    Inherits calcBase


    Public Shared tMWSTS�tzeFromFile As New dbPMDS.MWSTS�tzeDataTable




    Public Sub init(ByRef tMWSTS�tze As dbPMDS.MWSTS�tzeDataTable)
        Try
            If MWSTS�tze.tMWSTS�tzeFromFile.Rows.Count > 0 Then
                For Each rMWStFromFile As dbPMDS.MWSTS�tzeRow In MWSTS�tze.tMWSTS�tzeFromFile
                    Dim rNew As dbPMDS.MWSTS�tzeRow = tMWSTS�tze.NewRow()
                    rNew.Prozent = rMWStFromFile.Prozent
                    rNew.KontoExport = rMWStFromFile.KontoExport
                    tMWSTS�tze.Rows.Add(rNew)
                Next
            Else
                Dim rNew As dbPMDS.MWSTS�tzeRow = tMWSTS�tze.NewRow()
                rNew.Prozent = 0
                rNew.KontoExport = ""
                tMWSTS�tze.Rows.Add(rNew)

                rNew = tMWSTS�tze.NewRow()
                rNew.Prozent = 10
                rNew.KontoExport = ""
                tMWSTS�tze.Rows.Add(rNew)

                rNew = tMWSTS�tze.NewRow()
                rNew.Prozent = 20
                rNew.KontoExport = ""
                tMWSTS�tze.Rows.Add(rNew)
            End If

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Shared Function loadMWSTS�tzeFromFile() As Boolean
        Try
            Dim filToLoad As String = calculation.pathConfig + "\" + calcBase.fileMWStS�tze
            If System.IO.File.Exists(filToLoad) Then
                MWSTS�tze.tMWSTS�tzeFromFile.Rows.Clear()
                Dim reader As New System.IO.StreamReader(filToLoad)
                Do While reader.Peek() >= 0
                    Dim sLine As String = reader.ReadLine
                    If (sLine.Trim() <> "") Then
                        If sLine.Trim().Substring(0, 2) <> ("//") Then
                            Dim fields As String() = sLine.Split(New Char() {";"})
                            If fields(0).Trim().Equals("MWST", StringComparison.CurrentCultureIgnoreCase) Then
                                Dim rNew As dbPMDS.MWSTS�tzeRow = MWSTS�tze.tMWSTS�tzeFromFile.NewRow()
                                rNew.Prozent = System.Convert.ToInt32(fields(1).Trim())
                                rNew.KontoExport = fields(2).Trim()
                                MWSTS�tze.tMWSTS�tzeFromFile.Rows.Add(rNew)
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