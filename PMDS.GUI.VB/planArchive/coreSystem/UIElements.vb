Imports System.Windows.Forms
Imports System.IO
Imports System
Imports System.Resources
Imports System.ComponentModel.Component

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars




Public Class UIElements

    Public gen As New GeneralArchiv()

    Public Class cRetFindTool
        Public found As Boolean = False
        Public tool As ToolBase
    End Class






    Private Function Menu_IsFirstInGroup_Rek(ByRef Tools As ToolsCollection, ByVal MenueKey As String) As Boolean
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


    Public Function Menu_ItemOnOff(ByRef UltraToolbarsManager As UltraToolbarsManager, ByVal Band As Integer, ByVal MenueKey As String, ByVal Show As Boolean)
        Try

            Dim Tools As ToolsCollection
            Tools = UltraToolbarsManager.Toolbars(Band).Tools
            Menu_ItemOnOff_Rek(Tools, MenueKey, Show)

        Catch ex As Exception
            Throw New Exception("Menu_ItemOnOff: " + ex.ToString())
        End Try
    End Function

    Private Function Menu_ItemOnOff_Rek(ByRef Tools As ToolsCollection, ByVal MenueKey As String, ByVal Show As Boolean)
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

    Private Function MenuSetCaptionRek(ByRef Tools As ToolsCollection, ByVal MenueKey As String, ByVal Caption As String) As Boolean
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

    Private Function Menu_ShortKey_OnOff_Rek(ByRef Tools As ToolsCollection, ByVal MenueKey As String,
                                    ByVal Shortcut As System.Windows.Forms.Shortcut)
        Try

            Dim Key As String
            Dim Tool As ToolBase

            For Each Tool In Tools

                If Tool.Key = MenueKey Then
                    If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.ButtonTool" Then
                        Dim butt As Infragistics.Win.UltraWinToolbars.ButtonTool
                        butt = Tool
                        butt.SharedProps.Shortcut = Shortcut
                    End If
                End If
                If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupMenuTool" Then
                    Dim PopUp As PopupMenuTool
                    Dim Nexttools As ToolsCollection
                    PopUp = Tool
                    Nexttools = PopUp.Tools
                    Menu_ShortKey_OnOff_Rek(Nexttools, MenueKey, Shortcut)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Menu_ShortKey_OnOff_Rek: " + ex.ToString())
        End Try
    End Function

    Public Function FindToolInPopUps(ByRef Tools As ToolsCollection, ByVal SerchKey As String) As cRetFindTool
        Try
            Dim Tool As ToolBase
            For Each Tool In Tools
                If Tool.Key = SerchKey Then
                    Dim ret As New cRetFindTool
                    ret.found = True
                    ret.tool = Tool
                    Return ret
                End If
                If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupMenuTool" Then
                    Dim PopUp As PopupMenuTool
                    Dim Nexttools As ToolsCollection
                    PopUp = Tool
                    Nexttools = PopUp.Tools
                    Dim retRek As New cRetFindTool
                    retRek = FindToolInPopUps(Nexttools, SerchKey)
                    If retRek.found Then
                        Return retRek
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("FindToolInPopUps: " + ex.ToString())
        End Try
    End Function

    Public Function deleteTablesFromDataSet(ByRef ds As DataSet, ByRef lstTablesNotDelete As System.Collections.Generic.List(Of String)) As Boolean
        Try
            Dim lstTablesToRemove As New System.Collections.Generic.List(Of String)
            For Each table As DataTable In ds.Tables
                Dim bTableNotDelete As Boolean = False
                For Each tableNotDelete As String In lstTablesNotDelete
                    If table.TableName.Trim().ToLower() = tableNotDelete.Trim().ToLower() Then
                        bTableNotDelete = True
                    End If
                Next
                If Not bTableNotDelete Then
                    Dim bExistsForDelete As Boolean = False
                    For Each tableToDelete As String In lstTablesToRemove
                        If table.TableName.Trim().ToLower() = tableToDelete.Trim().ToLower() Then
                            bExistsForDelete = True
                        End If
                    Next
                    If Not bExistsForDelete Then
                        lstTablesToRemove.Add(table.TableName.Trim())
                    End If
                End If
            Next
            For Each table As String In lstTablesToRemove
                If ds.Tables.Contains(table.Trim()) Then
                    ds.Tables.Remove(table.Trim())
                End If
            Next

        Catch ex As Exception
            Throw New Exception("deleteTablesFromDataSet: " + ex.ToString())
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
