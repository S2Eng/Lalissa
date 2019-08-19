Imports System.Windows.Forms



Public Class clManageTerminMail

    Public Shared listeOffenTermine As New frmOffeneTermine




    Public Sub Termin_Neu(ByVal Dat As Date, ByVal Time As Date, _
                          ByVal idobject As String, ByVal patient As String, _
                              ByVal modalWindow As contPlanungMain, ByVal modalWindowErinnerung As frmOffeneTermine)
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            exch.app = General.InitApplicationAufgabenTermine.terminNeu
            Dim frm As New frmNachricht
            frm._typ = General.eTypPlanung.termin
            frm.dateTemp = Dat
            frm.timeTemp = Time
            frm.modalWindow = modalWindow
            frm.modalWindowErinnerung = modalWindowErinnerung
            frm.IDobject = idobject
            frm.patient = patient

            frm.Show()
            frm.Init(exch)

        Catch ex As Exception
            Throw New Exception("Termin_Neu: " + ex.ToString())
        End Try
    End Sub
    Public Sub Mail_Neu(ByVal Dat As Date, ByVal Time As Date,
                         ByVal idobject As String, ByVal patient As String,
                         ByVal modalWindow As contPlanungMain,
                         ByVal typMail As GeneralArchiv.eTypMail, ByRef modalWindowErinnerung As frmOffeneTermine)
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            exch.app = General.InitApplicationAufgabenTermine.mailNeu
            exch.typMail = typMail
            Dim frm As New frmNachricht
            frm._typ = General.eTypPlanung.mail
            frm.dateTemp = Nothing      'Dat
            frm.timeTemp = Nothing      'Time
            frm.modalWindow = modalWindow
            frm.modalWindowErinnerung = modalWindowErinnerung

            frm.IDobject = idobject
            frm.patient = patient

            frm.Show()
            frm.Init(exch)

        Catch ex As Exception
            Throw New Exception("Mail_Neu: " + ex.ToString())
        End Try
    End Sub

    Public Function nachricht÷ffnen(ByVal IDAufgabe As System.Guid, ByVal modalWindow As contPlanungMain, _
                                          ByVal IDobject As String, ByRef modalWindowErinnerung As frmOffeneTermine) As Boolean
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            Dim tblAdminAufgaben As New tblAufgaben
            tblAdminAufgaben.SelectRow(IDAufgabe)
            If tblAdminAufgaben.DataTable.Rows.Count = 1 Then
                Dim DataRow As DataRow = tblAdminAufgaben.DataTable.Rows(0)
                Dim tblAdminAufgabeArt As New tblAufgabeArt
                tblAdminAufgabeArt.SelectRow(DataRow("IDArt"))
                If tblAdminAufgabeArt.DataTable.Rows.Count = 1 Then
                    Dim r As DataRow = tblAdminAufgabeArt.DataTable.Rows(0)
                    exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen
                    exch.str = General.GuidToStr(IDAufgabe)
                    Dim frm As New frmNachricht
                    If r("ID").ToString = General.IDMail.ToString Then
                        frm._typ = General.eTypPlanung.mail
                    ElseIf r("ID").ToString = General.IDTermin.ToString Or r("ID").ToString = General.IDTermin2.ToString Then
                        frm._typ = General.eTypPlanung.termin
                    Else
                        Try
                            Throw New Exception("nachricht÷ffnen: Nachricht hat falsche IDArt! IDAufgabe: '" + IDAufgabe.ToString + "'")
                        Catch ex As Exception
                            General.GetEcxeptionGeneral(ex)
                        End Try
                    End If
                    frm.IDobject = ""
                    frm.patient = ""
                    frm.modalWindow = modalWindow
                    frm.modalWindowErinnerung = modalWindowErinnerung
                    frm.Show()
                    frm.Init(exch)
                End If
            Else
                MsgBox("Termin bzw. E-Mail existiert nicht mehr!", MsgBoxStyle.Information, "PMDS")
            End If

        Catch ex As Exception
            Throw New Exception("nachricht÷ffnen: " + ex.ToString())
        End Try
    End Function

End Class
