


Public Class doCARDIAC_Statistik

    Structure structCUSUM
        Dim AvgObsMort As Double '(eine Zahl für alle Punkte!)
        Dim WorseningAlarm As Double 'am Punkt i
        Dim WorseningAlert As Double
        Dim ImprovementAlert As Double
        Dim ImprovementAlarm As Double
    End Structure

    Structure structVLAD
        Dim Beobachteter_VLAD As Double
        Dim Max_Saved_Lifes As Double
        Dim Anzahl_Tote As Integer
        Dim Reserviert As Integer
        Dim CUSUM As structCUSUM
        Dim RecordID As Integer
        Dim SurgDt As DateTime
        Dim SurgID As Integer
        Dim SurgName As String
        Dim VLADPositiv As Double
        Dim VLADNegativ As Double
    End Structure

    Structure structFunnel
        Dim M01 As Double   '0: - 1%, 
        Dim M05 As Double   '1: - 5%, 
        Dim M10 As Double   '2: -10%, 
        Dim M25 As Double   '3: -25%, 
        Dim P25 As Double   '4: +25%,
        Dim P10 As Double   '5: +10%, 
        Dim P05 As Double   '6: +5%, 
        Dim P01 As Double   '7: +1%, 

        Dim K99 As Double   '0: 99%, 
        Dim K95 As Double   '1: 95%, 
        Dim K90 As Double   '2: 90%, 
        Dim K75 As Double   '3: 75%, 
        Dim K25 As Double   '4: 25%,
        Dim K10 As Double   '5: 10%, 
        Dim K05 As Double   '6: 5%, 
        Dim K01 As Double   '7: 1%, 


    End Structure







    Public Function calcVLAD(sqlWhereAutoGen As String, EuroScoreVersion As qs2.core.Enums.iEuroSCOREVersion, ByRef sqlVLADReturn As String,
                             ByRef dsStatisticsReturn As qs2.core.vb.dsCARDIAC) As Boolean
        'Holen aller Cardiac-Stays (nicht FollowUp, Aktiv = 1) im angegeben Zeitraum 
        Try
            Dim dsCARDIAC1 As New dsCARDIAC()
            Dim sqlCARDIAC1 As New qs2.core.vb.sqlCARDIAC()
            sqlCARDIAC1.initControl()

            sqlCARDIAC1.getVLAD(dsCARDIAC1, sqlWhereAutoGen, sqlVLADReturn)

            Dim arrFunnel(dsCARDIAC1.VLADCARDIAC_STAYS.Rows.Count()) As structFunnel    'Funnel: 0: - 1%, 1: - 5%, 2: -10%, 3: -25%, 4: +25%, 5: +10%, 6: +5%, 7: +1%, 
            Dim arrVLAD(dsCARDIAC1.VLADCARDIAC_STAYS.Rows.Count) As structVLAD          'VLAD
            Dim arrProb(dsCARDIAC1.VLADCARDIAC_STAYS.Rows.Count())                      'Probability
            Dim arrProbNorm(dsCARDIAC1.VLADCARDIAC_STAYS.Rows.Count())                      'Probability


            arrProb(0) = 1                                                  ' Wahrscheinlichkeit an der Stelle 0 (0.te OP = 1)
            arrVLAD(0).Beobachteter_VLAD = 0        ' Beobachteter VLAD = 0
            arrVLAD(0).Max_Saved_Lifes = 0          ' Max Saved Lifes = 0 (Summe der Überlebenswahrscheinlichkeiten aller Klienten)
            arrVLAD(0).Anzahl_Tote = 0              ' Anzahl Tote = 0
            arrVLAD(0).Reserviert = 0               ' Reserviert
            arrVLAD(0).CUSUM.AvgObsMort = 0          ' CUSUMAvgObsMort (eine Zahl für alle Punkte!)
            arrVLAD(0).CUSUM.WorseningAlarm = 0      ' CUSUMWorseningAlarm am Punkt i
            arrVLAD(0).CUSUM.WorseningAlert = 0      ' CUSUMWorseningAlert
            arrVLAD(0).CUSUM.ImprovementAlert = 0    ' CUSUMImprovementAlert
            arrVLAD(0).CUSUM.ImprovementAlarm = 0    ' CUSUMImprovementAlarm
            arrVLAD(0).RecordID = 0                 ' RecordID
            arrVLAD(0).SurgDt = Nothing             ' SurgDt
            arrVLAD(0).SurgID = 0                   ' SurgID
            arrVLAD(0).SurgName = ""                ' SurgName
            arrVLAD(0).VLADPositiv = 0               'Absolute VLAD-Summe dieses Punktes für lebend
            arrVLAD(0).VLADNegativ = 0               'Absolute VLAD-Summe dieses Punktes für tot
            '-------- Funnel-Plot an der Stelle 0 initialisieren -----------------------
            arrFunnel(0).M01 = 0
            arrFunnel(0).M05 = 0
            arrFunnel(0).M10 = 0
            arrFunnel(0).M25 = 0
            arrFunnel(0).P25 = 0
            arrFunnel(0).P10 = 0
            arrFunnel(0).P05 = 0
            arrFunnel(0).P01 = 0

            '---- kumulierte Wahrscheinlichkeiten für Kurven 
            arrFunnel(0).K99 = 0
            arrFunnel(0).K95 = 0
            arrFunnel(0).K90 = 0
            arrFunnel(0).K75 = 0
            arrFunnel(0).K25 = 0
            arrFunnel(0).K10 = 0
            arrFunnel(0).K05 = 0
            arrFunnel(0).K01 = 0


            Dim i As Integer = 0
            Dim KonvIntervall As Double = 0
            For Each rVLAD As qs2.core.vb.dsCARDIAC.VLADCARDIAC_STAYSRow In dsCARDIAC1.VLADCARDIAC_STAYS
                i = i + 1
                If EuroScoreVersion = Enums.iEuroSCOREVersion.AddEuroSCORE Then
                    arrProb = CalcProb(arrProb, i, rVLAD.SumEuroScore / 100)
                    arrVLAD(i).Beobachteter_VLAD = arrVLAD(i - 1).Beobachteter_VLAD + (rVLAD.SumEuroScoreObserved / 100)
                    arrVLAD(i).Max_Saved_Lifes = arrVLAD(i - 1).Max_Saved_Lifes + (rVLAD.SumEuroScore / 100)

                ElseIf EuroScoreVersion = Enums.iEuroSCOREVersion.LogEuroSCORE Then
                    arrProb = CalcProb(arrProb, i, rVLAD.LogEuroScore / 100)
                    arrVLAD(i).Beobachteter_VLAD = arrVLAD(i - 1).Beobachteter_VLAD + (rVLAD.LogEuroScoreObserved / 100)
                    arrVLAD(i).Max_Saved_Lifes = arrVLAD(i - 1).Max_Saved_Lifes + (rVLAD.LogEuroScore / 100)

                ElseIf EuroScoreVersion = Enums.iEuroSCOREVersion.EuroSCOREII Then
                    arrProb = CalcProb(arrProb, i, rVLAD.LogEuroScore_II / 100)
                    arrVLAD(i).Beobachteter_VLAD = arrVLAD(i - 1).Beobachteter_VLAD + (rVLAD.LogEuroScoreObserved_II / 100)
                    arrVLAD(i).Max_Saved_Lifes = arrVLAD(i - 1).Max_Saved_Lifes + (rVLAD.LogEuroScore_II / 100)
                    arrVLAD(i).VLADPositiv = arrVLAD(i - 1).VLADPositiv + (rVLAD.LogEuroScore_II / 100)
                    arrVLAD(i).VLADNegativ = arrVLAD(i - 1).VLADNegativ + (rVLAD.LogEuroScore_II / 100 - 1)
                End If

                arrVLAD(i).Anzahl_Tote = arrVLAD(i - 1).Anzahl_Tote + IIf(rVLAD.Mt30Stat = 2, 1, 0)
                arrVLAD(i).RecordID = rVLAD.ID
                If Not rVLAD.IsSurgDtStartNull() Then
                    arrVLAD(i).SurgDt = rVLAD.SurgDtStart
                End If

                'ArrFunnel aufbereiten
                'Im ArrProb stehen die Wahrscheinlichkeit für die Anzahl der Überlebenden
                'Es muss gezählt werden, wieviele Kurven jeweils innerhalb der Grenzen liegen.
                If dsCARDIAC1.VLADCARDIAC_STAYS.Count >= 200 Then

                    Dim pKum As Double = 1
                    'Für jeden Datenpunkt die Wahrscheinlichkeit die kumulierte Wahrscheinlichkeit prüfen
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.995 Then
                            arrFunnel(i).P01 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.975 Then
                            arrFunnel(i).P05 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.95 Then
                            arrFunnel(i).P10 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.75 Then
                            arrFunnel(i).P25 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.25 Then
                            arrFunnel(i).M25 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.05 Then
                            arrFunnel(i).M10 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.025 Then
                            arrFunnel(i).M05 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next

                    pKum = 1
                    For k = 0 To i
                        pKum -= arrProb(k)
                        If pKum <= 0.005 Then
                            arrFunnel(i).M01 = arrVLAD(i).Max_Saved_Lifes - k
                            Exit For
                        End If
                    Next



                    'For k = i To 0 Step -1
                    '    KonvIntervall = 100 - arrProb(k) * 100
                    '    If KonvIntervall > 0 And KonvIntervall <= 0.5 Then
                    '        arrFunnel(i).P01 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 0.5 And KonvIntervall <= 5 Then
                    '        arrFunnel(i).P05 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 5 And KonvIntervall <= 10 Then
                    '        arrFunnel(i).P10 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 10 And KonvIntervall <= 25 Then
                    '        arrFunnel(i).P25 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 25 And KonvIntervall <= 75 Then
                    '        arrFunnel(i).M25 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 75 And KonvIntervall <= 90 Then
                    '        arrFunnel(i).M10 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 90 And KonvIntervall <= 95 Then
                    '        arrFunnel(i).M05 = arrVLAD(i).Max_Saved_Lifes - k
                    '    ElseIf KonvIntervall > 95 And KonvIntervall <= 99.5 Then
                    '        arrFunnel(i).M01 = arrVLAD(i).Max_Saved_Lifes - k
                    '    End If
                    'Next
                End If
            Next

            ''-------------------------------------------------------------
            '' CUSUM-Daten berechnen / wird nicht mehr angeboten
            ''-------------------------------------------------------------
            'Dim Cusum As structCUSUM

            'For i = 0 To arrVLAD.Count()
            '    Cusum.AvgObsMort = arrVLAD(arrVLAD.Count).Anzahl_Tote / arrVLAD.Count    'Durchschnittliche Beobachtete Mortalität
            '    Cusum = calcCUSUM(i, IIf(arrVLAD(i).Max_Saved_Lifes < 0, 0, 1), Cusum.AvgObsMort, 0.05, 0.2)

            '    arrVLAD(i).CUSUM.AvgObsMort = Cusum.AvgObsMort * i
            '    arrVLAD(i).CUSUM.WorseningAlarm = Cusum.WorseningAlarm
            '    arrVLAD(i).CUSUM.WorseningAlert = Cusum.WorseningAlert
            '    arrVLAD(i).CUSUM.ImprovementAlert = Cusum.ImprovementAlert
            '    arrVLAD(i).CUSUM.ImprovementAlarm = Cusum.ImprovementAlarm
            'Next

            'Dim sqlAdminWork As New sqlAdmin()
            'sqlAdminWork.initControl()

            For i = 0 To dsCARDIAC1.VLADCARDIAC_STAYS.Count - 1
                Dim rStat As qs2.core.vb.dsCARDIAC.tblStatisticsRow = Me.getNewRowStatistic(dsStatisticsReturn, i)
                'rStat.IDGuid = System.Guid.NewGuid()
                rStat.Nr = i
                rStat.SurgName = arrVLAD(i).SurgName
                rStat.SurgID = arrVLAD(i).SurgID
                'rStat.ID = arrVLAD(i).RecordID
                'rStat.IDParticipant = IDParticipant

                If arrVLAD(i).SurgDt <> Nothing Then
                    rStat.SurgDt = arrVLAD(i).SurgDt
                Else
                    rStat.SetSurgDtNull()
                End If
                rStat.VLAD = arrVLAD(i).Beobachteter_VLAD
                rStat.LogPredMort = arrVLAD(i).Max_Saved_Lifes

                '------ CUSUM -------
                'rStat.CUSUMCumDeads = arrVLAD(i).Anzahl_Tote
                'rStat.CUSUMAvgObsMort = arrVLAD(i).CUSUM.AvgObsMort
                'rStat.CUSUMWorseningAlarm = arrVLAD(i).CUSUM.WorseningAlarm
                'rStat.CUSUMWorseningAlert = arrVLAD(i).CUSUM.WorseningAlert
                'rStat.CUSUMImprovementAlert = arrVLAD(i).CUSUM.ImprovementAlert
                'rStat.CUSUMImprovementAlarm = arrVLAD(i).CUSUM.ImprovementAlarm

                '------ Funnel -----------
                rStat.ConfidenceIntervall1 = 99
                rStat.ConfidenceIntervall2 = 95
                rStat.ConfidenceIntervall3 = 90
                rStat.ConfidenceIntervall4 = 50
                rStat.Low1 = arrFunnel(i).M01
                rStat.Low2 = arrFunnel(i).M05
                rStat.Low3 = arrFunnel(i).M10
                rStat.Low4 = arrFunnel(i).M25
                rStat.High1 = arrFunnel(i).P01
                rStat.High2 = arrFunnel(i).P05
                rStat.High3 = arrFunnel(i).P10
                rStat.High4 = arrFunnel(i).P25
            Next

            'dsStatisticsReturn.WriteXml("Cardiac_Statistics.xml", XmlWriteMode.WriteSchema)

            Return True

        Catch ex As Exception
            Throw New Exception("doCARDIAC.calcVLAD:" + vbNewLine + vbNewLine + ex.ToString())
            Return False
        End Try
    End Function

    Public Function calcCUSUM(ByRef Cnt As Integer, ByRef Mt30Stat As Integer, ByRef AvgObsMort As Double, _
                    ByRef Alpha As Double, ByRef Beta As Double) As structCUSUM

        'CUSUM-Daten in CardStatDataArray eintragen

        'Parameter für Bounderies
        Dim a As Double
        Dim b As Double
        Dim PU As Double
        Dim PL As Double
        Dim p0 As Double
        Dim p1U As Double
        Dim p1L As Double
        Dim QU As Double
        Dim QL As Double
        Dim sU As Double
        Dim sL As Double
        Dim CUSUM As structCUSUM

        p0 = AvgObsMort            'Beobachte Sterblichkeitsrate
        p1U = p0 + 0.01
        p1L = p0 - 0.01

        a = Math.Log((1 - Beta) / Alpha)
        b = Math.Log(Beta / (1 - Alpha))

        If p0 > 0 Then PU = Math.Log(p1U / p0)
        If p0 > 0 Then PL = Math.Log(p1L / p0)

        If (1 - p1U) <> 0 Then QU = Math.Log((1 - p0) / (1 - p1U))
        If (1 - p1L) <> 0 Then QL = Math.Log((1 - p0) / (1 - p1L))

        If (PU + QU) <> 0 Then sU = QU / (PU + QU)
        If (PL + QL) <> 0 Then sL = QL / (PL + QL)


        CUSUM.ImprovementAlarm = Cnt * sL + (a / (PL + QL))     'Improvement Alarm
        CUSUM.ImprovementAlert = Cnt * sL - (b / (PL + QL))     'Improvement Alert
        CUSUM.WorseningAlert = Cnt * sU - (b / (PU + QU))     'Worsening Alert
        CUSUM.WorseningAlarm = Cnt * sU + (a / (PU + QU))     'Worsening Alarm

        CUSUM.ImprovementAlarm = IIf(CUSUM.ImprovementAlarm < 0, 0, CUSUM.ImprovementAlarm)
        CUSUM.ImprovementAlert = IIf(CUSUM.ImprovementAlert < 0, 0, CUSUM.ImprovementAlert)
        CUSUM.WorseningAlert = IIf(CUSUM.WorseningAlert < 0, 0, CUSUM.WorseningAlert)
        CUSUM.WorseningAlarm = IIf(CUSUM.WorseningAlarm < 0, 0, CUSUM.WorseningAlarm)

        CUSUM.AvgObsMort = AvgObsMort
        Return CUSUM

    End Function
    Public Function CalcProb(ByRef ArrProb As Array, ByRef i As Integer, ByRef ExpMort As Double) As Array

        ' Es wird das Array der Probability des Vorgängers übergeben
        ' von 1 bis i die Wahrscheinlichkeiten neu berechnen

        ' i = die i.te OP
        ' result = Ergebnis .. true = lebend, false = tot
        ' ExpMort = erwartete Mortalität

        Dim arrTemp(i)
        Dim k As Integer
        Dim ExpAlive As Double

        ExpAlive = 1 - ExpMort

        arrTemp(0) = ExpAlive * ArrProb(0)

        For k = 1 To i - 1
            arrTemp(k) = (ExpMort) * ArrProb(k - 1) + ExpAlive * ArrProb(k)
        Next

        arrTemp(i) = (ExpMort) * ArrProb(i - 1)

        'Übertragen der neuen Werte in ArrProb
        For k = 0 To i
            ArrProb(k) = arrTemp(k)
        Next

        Return ArrProb

    End Function

    Public Function getNewRowStatistic(ds As dsCARDIAC, ByRef ID As Integer) As dsCARDIAC.tblStatisticsRow
        Try
            Dim rNew As dsCARDIAC.tblStatisticsRow = ds.tblStatistics.NewRow()
            rNew.SetNrNull()
            rNew.SetSurgDtNull()
            rNew.SetVLADNull()
            rNew.SetLogPredMortNull()
            rNew.SetConfidenceIntervall1Null()
            rNew.SetLow1Null()
            rNew.SetHigh1Null()
            rNew.SetConfidenceIntervall2Null()
            rNew.SetLow2Null()
            rNew.SetHigh2Null()
            rNew.SetConfidenceIntervall3Null()
            rNew.SetLow3Null()
            rNew.SetHigh3Null()
            rNew.SetConfidenceIntervall4Null()
            rNew.SetLow4Null()
            rNew.SetHigh4Null()
            rNew.SetSurgIDNull()
            rNew.SetSurgNameNull()
            rNew.SetCUSUMCumDeadsNull()
            rNew.SetCUSUMAvgObsMortNull()
            rNew.SetCUSUMWorseningAlarmNull()
            rNew.SetCUSUMWorseningAlertNull()
            rNew.SetCUSUMImprovementAlarmNull()
            rNew.SetCUSUMImprovementAlertNull()
            rNew.ID = ID
            rNew.SetRecordIDNull()

            ds.tblStatistics.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("getNewRowStatistic: " + ex.ToString())
        End Try
    End Function
End Class
