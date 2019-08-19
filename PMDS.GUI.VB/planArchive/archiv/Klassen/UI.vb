Imports System.IO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms




Public Class UI

    Private gen As New GeneralArchiv


    Public Function Menu_IsFirstInGroup(ByVal UltraToolbarsManager As UltraToolbarsManager, ByVal MenueKey As String)
        Try

            Dim Tools As ToolsCollection
            Tools = UltraToolbarsManager.Toolbars(0).Tools
            Menu_IsFirstInGroup_Rek(Tools, MenueKey)

        Catch ex As Exception
            Throw New Exception("Menu_IsFirstInGroup: " + ex.ToString())
        End Try
    End Function
    Private Function Menu_IsFirstInGroup_Rek(ByVal Tools As ToolsCollection, ByVal MenueKey As String) As Boolean
        Try
            Dim Key As String
            Dim Tool As ToolBase

            For Each Tool In Tools

                If Tool.Key = MenueKey Then
                    Tool.InstanceProps.Visible = DefaultableBoolean.True
                    Tool.InstanceProps.IsFirstInGroup = True
                End If

                If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupMenuTool" Then

                    Dim PopUp As PopupMenuTool
                    Dim Nexttools As ToolsCollection
                    PopUp = Tool
                    Nexttools = PopUp.Tools

                    Menu_IsFirstInGroup_Rek(Nexttools, MenueKey)

                End If

            Next

        Catch ex As Exception
            Throw New Exception("Menu_IsFirstInGroup_Rek: " + ex.ToString())
        End Try
    End Function

    Public Function Menu_ItemOnOff(ByVal UltraToolbarsManager As UltraToolbarsManager, ByVal Band As Integer, ByVal MenueKey As String, ByVal Show As Boolean)
        Try

            Dim Tools As ToolsCollection
            Tools = UltraToolbarsManager.Toolbars(Band).Tools
            Menu_ItemOnOff_Rek(Tools, MenueKey, Show)

        Catch ex As Exception
            Throw New Exception("Menu_ItemOnOff: " + ex.ToString())
        End Try
    End Function
    Private Function Menu_ItemOnOff_Rek(ByVal Tools As ToolsCollection, ByVal MenueKey As String, ByVal Show As Boolean)
        Try
            Dim Key As String
            Dim Tool As ToolBase

            For Each Tool In Tools

                If Tool.Key = MenueKey Then
                    If Show Then
                        Tool.InstanceProps.Visible = DefaultableBoolean.True
                    Else
                        Tool.InstanceProps.Visible = DefaultableBoolean.False
                    End If

                End If

                If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupMenuTool" Then

                    Dim PopUp As PopupMenuTool
                    Dim Nexttools As ToolsCollection
                    PopUp = Tool
                    Nexttools = PopUp.Tools

                    Menu_ItemOnOff_Rek(Nexttools, MenueKey, Show)

                End If

            Next

        Catch ex As Exception
            Throw New Exception("Menu_ItemOnOff_Rek: " + ex.ToString())
        End Try
    End Function

    Public Function MenuSetCaption(ByVal MenueKey As String, ByVal Caption As String, ByRef ToolBar As UltraToolbarsManager, ByVal Band As Integer)
        Try

            Dim Tools As ToolsCollection

            Tools = ToolBar.Toolbars(Band).Tools
            MenuSetCaptionRek(Tools, MenueKey, Caption)

        Catch ex As Exception
            Throw New Exception("MenuSetCaption: " + ex.ToString())
        End Try
    End Function
    Private Function MenuSetCaptionRek(ByVal Tools As ToolsCollection, ByVal MenueKey As String, ByVal Caption As String) As Boolean
        Try
            Dim Key As String
            Dim Tool As ToolBase
            Dim OnOffInfrag As DefaultableBoolean

            For Each Tool In Tools

                If Tool.Key = MenueKey Then
                    Tool.InstanceProps.Caption = Caption
                End If

                If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupMenuTool" Then

                    Dim PopUp As PopupMenuTool
                    Dim Nexttools As ToolsCollection
                    PopUp = Tool
                    Nexttools = PopUp.Tools

                    MenuSetCaptionRek(Nexttools, MenueKey, Caption)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("MenuSetCaptionRek: " + ex.ToString())
        End Try
    End Function

    Public Function SelectFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String
        Try
            Dim openFileDialog As New OpenFileDialog
            Dim File As String
            Dim Pfad As String
            openFileDialog.InitialDirectory = ""
            If Not gen.IsNull(rootVerzeichnis) And System.IO.Directory.Exists(rootVerzeichnis) Then
                openFileDialog.InitialDirectory = rootVerzeichnis
            End If
            openFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                File = openFileDialog.FileName
                Return File
            End If
            Return ""

        Catch ex As Exception
            Throw New Exception("SelectFileDialog: " + ex.ToString())
        End Try
    End Function

    Public Function GetDir(ByVal File As String) As String
        Try
            If gen.IsNull(File) Then Return ""

            Dim pos As Integer = 1
            Dim pos_Prev As Integer = 0
            Dim Apport As Boolean = False
            While pos <> 0
                pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
                If pos <> 0 Then pos_Prev = pos
            End While

            If pos_Prev > 0 Then
                Return Microsoft.VisualBasic.Left(File, pos_Prev)
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("GetDir: " + ex.ToString())
        End Try
    End Function
    Public Function GetFileName(ByVal File As String) As String
        Try
            If gen.IsNull(File) Then Return ""

            Dim pos As Integer = 1
            Dim pos_Prev As Integer = 0
            Dim Apport As Boolean = False
            While pos <> 0
                pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
                If pos <> 0 Then pos_Prev = pos
            End While

            If pos_Prev > 0 Then
                Return Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - (pos_Prev))
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("GetFileName: " + ex.ToString())
        End Try
    End Function
    Public Function GetFiletyp(ByVal File As String) As String
        Try
            If gen.IsNull(File) Then Return ""

            Dim pos As Integer = 1
            Dim pos_Prev As Integer = 0
            Dim Apport As Boolean = False
            While pos <> 0
                pos = Microsoft.VisualBasic.InStr(pos + 1, File, ".", CompareMethod.Text)
                If pos <> 0 Then pos_Prev = pos
            End While

            If pos_Prev > 0 Then
                Return Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - ((pos_Prev) - 1))
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("GetFiletyp: " + ex.ToString())
        End Try
    End Function

End Class
