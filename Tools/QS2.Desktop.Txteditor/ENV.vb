﻿

Public Class ENV

    Public Shared _path_temp As String = ""
    Public Shared _path_log As String = ""
    Public Shared _path_Config As String = ""
    Public Shared _SystemIsInitialized As Boolean = False
    Public Shared _adminSecure As Boolean = False

    Public Shared delDoRes As dGetRes
    Public Delegate Function dGetRes(ByVal IDRes As String) As String





    Public Shared Sub init(path_temp As String, path_log As String, SystemIsInitialized As Boolean, adminSecure As Boolean)

        If Not System.IO.Directory.Exists(path_temp) Then
            Throw New Exception("QS2.Desktop.Txteditor.ENV.init: path_temp '" + path_temp + "' not exists!")
        End If
        If Not System.IO.Directory.Exists(path_log) Then
            Throw New Exception("QS2.Desktop.Txteditor.ENV.init: path_log '" + path_log + "' not exists!")
        End If
        If Not SystemIsInitialized Then
            Throw New Exception("QS2.Desktop.Txteditor.ENV.init: Variable SystemIsInitialized=false!")
        End If

        ENV._path_temp = path_temp
        ENV._path_log = path_log
        ENV._SystemIsInitialized = SystemIsInitialized
        ENV._adminSecure = adminSecure

        QS2.Logging.ENV.init(path_log, SystemIsInitialized, adminSecure)
    End Sub


End Class
