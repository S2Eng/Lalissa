Imports Microsoft.Win32
Imports System.Configuration
Imports System.IO
Imports System.Xml
Imports System



Public Class ENV


    Public Shared conntStr As String = ""
    Public Shared adminSecure As Boolean = False

    Public Shared path_root As String = ""
    Public Shared path_bin As String = ""
    Public Shared path_logging As String = ""
    Public Shared path_config As String = ""
    Public Shared file_config As String = ""
    Public Shared path_data As String = ""
    Public Shared path_temp As String = ""
    Public Shared path_doku As String = ""



    Public Shared Sub doStartUp()

        ENV.path_bin = General.getAppPath()
        ENV.path_root = ENV.path_bin.Substring(0, ENV.path_bin.LastIndexOf("\"))

        ENV.path_logging = ENV.path_root + "\log"
        ENV.path_config = ENV.path_root + "\config"
        ENV.file_config = ENV.path_config + "\service.config"
        ENV.path_data = ENV.path_root + "\data"
        ENV.path_temp = ENV.path_data + "\temp"
        ENV.path_doku = ENV.path_data + "\doku"

        'dbGlobal.readRegistry()
        ENV.readITSContConfig()
    End Sub

    Public Shared Function readITSContConfig() As Boolean

        Dim str As New StreamReader(ENV.file_config)
        Do While str.Peek() >= 0
            Dim line As String = str.ReadLine.Trim()
            If line.Length > 2 Then
                If Not line.Trim().Substring(0, 2).Equals("//") Then
                    Dim posEquals As Integer = line.IndexOf("=")
                    If posEquals <> -1 Then
                        Dim sVar As String = line.Substring(0, posEquals).Trim()
                        Dim sValue As String = line.Substring(posEquals + 1, line.Length - (posEquals + 1)).Trim()
                        Select Case sVar
                            Case "db"
                                ENV.conntStr = sValue.Trim()
                            Case "adminSecure"
                                Dim nValue As Integer = System.Convert.ToInt32(sValue.Trim())
                                If nValue = 1 Then
                                    ENV.adminSecure = True
                                End If


                        End Select
                    End If
                End If
            End If
        Loop
        str.Close()
        Return True

    End Function

End Class
