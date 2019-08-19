

Public Class cService

    Public Enum eTypService
        startService = 0
        stopService = 1
    End Enum

    Public Class retService
        Public MessageIDResBack As String = ""
        Public ok As Boolean = False
    End Class




    Public Function doService(ByVal ServerName As String, ByVal NameService As String, ByVal typService As eTypService, _
                              ByVal checkExeIsRunningAsAdmin As Boolean) As retService

        Dim ret As New retService()
        'Dim CreateManifest1 As New CreateManifest()
        'CreateManifest1.createManifest(Application.StartupPath, Application.ProductName)

        Dim bDo As Boolean = True
        'If checkExeIsRunningAsAdmin Then
        '    If Not ITSCont.core.cs.generic.ExeIsAdmin() Then
        '        If withMsgBox Then ITSCont.core.SystemDb.doUI.doMessageBox("ITSContIsNotRunningInAdminMode", "", "!")
        '    Else
        '        bDo = True
        '    End If
        'Else
        '    bDo = True
        'End If

        If bDo Then
            Dim sc As New System.ServiceProcess.ServiceController(NameService.Trim(), ServerName.Trim())
            If typService = eTypService.startService Then
                If sc.Status <> ServiceProcess.ServiceControllerStatus.Running Then
                    sc.Start()
                    ret.MessageIDResBack = "ServiceStarted"
                    ret.ok = True
                Else
                    ret.MessageIDResBack = "ServiceIsAlreadyRunning"
                End If

            ElseIf typService = eTypService.stopService Then
                If sc.Status = ServiceProcess.ServiceControllerStatus.Running Then
                    sc.Stop()
                    ret.MessageIDResBack = "ServiceStopped"
                    ret.ok = True
                Else
                    ret.MessageIDResBack = "ServiceIsNotRunning"
                End If
            End If

        End If

        Return ret

    End Function

End Class
