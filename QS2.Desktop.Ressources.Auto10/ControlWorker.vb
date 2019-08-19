

Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars



Public Class ControlWorker


    Public Shared isBack As Boolean = True
    Public Shared iCounterForms As Integer = 0

    Public Shared lstFormsDone As New System.Collections.Generic.List(Of frmInfo)
    Public Class frmInfo
        Public frm As Form = Nothing
        Public IsLoaded As Boolean = False
        Public iCounterControls As Integer = 0
    End Class
    Public Shared dsControlsxy As New dsControls()

    Public doRessourcesWork As New ControlManagment()






    Public Function runxy(FormCollection As FormCollection, components As Object, TypeRessourcesRun As String) As Boolean

        Try
            Dim contForms As Integer = Application.OpenForms.Count
            If contForms <> ControlWorker.iCounterForms Then
                For Each formFound As Form In FormCollection
                    Dim bIsInList As Boolean = False
                    For Each frmInfo As frmInfo In ControlWorker.lstFormsDone
                        If formFound.Name = frmInfo.frm.Name Then
                            bIsInList = True
                        End If
                    Next
                    If Not bIsInList And formFound.Name.Trim() <> "" Then
                        Dim NewFrmInfo As New frmInfo()
                        NewFrmInfo.frm = formFound
                        ControlWorker.lstFormsDone.Add(NewFrmInfo)
                    End If
                Next
            End If

            For Each frmInfo As frmInfo In ControlWorker.lstFormsDone
                If ControlWorker.isBack Then
                    Dim iControlsFoundInForm As Integer = 0
                    ControlWorker.isBack = False
                    Me.CheckNumberControls_rek(frmInfo.frm, iControlsFoundInForm)
                    If iControlsFoundInForm > frmInfo.iCounterControls Then
                        'Me.doRessourcesWork.run(frmInfo.frm, components, Nothing, TypeRessourcesRun,
                        '                    QS2.core.license.doLicense.eApp.PMDS.ToString(),
                        '                    QS2.Desktop.ControlManagment.ControlManagment.eControlGroup.MainSystem,
                        '                    QS2.core.Enums.eResourceType.None)
                        'frmInfo.iCounterControls = iControlsFoundInForm

                        'Dim rNewProt As dsControls.ProtocollRow = Me.addProtocoll(ControlWorker.dsControls)
                        'rNewProt.Txt = "Control-Worker was run for Form '" + frmInfo.frm.Name + "' (Number controls in form:" + frmInfo.iCounterControls.ToString() + ")"

                    Else
                        Dim str As String = ""
                    End If
                    ControlWorker.isBack = True
                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("ControlWorker.ControlWorker: " + ex.ToString())
        End Try
    End Function
    Public Sub CheckNumberControls_rek(ControlToCheck As Control, ByRef iContFound As Integer)
        For Each contFound As Control In ControlToCheck.Controls
            iContFound += 1
            Me.CheckNumberControls_rek(contFound, iContFound)
        Next
    End Sub



End Class
