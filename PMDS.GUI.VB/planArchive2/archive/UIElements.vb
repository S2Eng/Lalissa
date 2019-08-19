Imports System.Windows.Forms
Imports System.IO
Imports System
Imports System.Resources
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree
Imports System.ComponentModel.Component




Public Class clUIElements



    Public Function Menu_loadContainer(ByRef UltraToolbarsManager As UltraToolbarsManager, ByVal Band As Integer,
                                                    ByRef pan As Control, ByVal keyToLoad As String)
        Try

            Dim Tools As ToolsCollection
            Tools = UltraToolbarsManager.Toolbars(Band).Tools
            Me.Menu_loadContainer_Rek(Tools, pan, keyToLoad)

        Catch ex As Exception
            Throw New Exception("clUIElements.Menu_loadContainer: " + ex.ToString())
        End Try
    End Function
    Private Sub Menu_loadContainer_Rek(ByRef Tools As ToolsCollection, ByRef pan As System.Windows.Forms.UserControl, ByVal keyToLoad As String)
        Try
            Dim Key As String
            Dim Tool As ToolBase

            For Each Tool In Tools
                If Tool.Key = keyToLoad Then
                    If Tool.GetType.ToString() = "Infragistics.Win.UltraWinToolbars.PopupControlContainerTool" Then

                        Dim PopupControlContainerTool As PopupControlContainerTool '= New PopupControlContainerTool("popup_control")
                        PopupControlContainerTool = Tool

                        PopupControlContainerTool.Control = pan
                        PopupControlContainerTool.DropDownArrowStyle = DropDownArrowStyle.Standard
                        PopupControlContainerTool.AllowTearaway = True
                        PopupControlContainerTool.SharedProps.Caption = doUI.getRes("Clipboard")
                        PopupControlContainerTool.SharedProps.DisplayStyle = ToolDisplayStyle.TextOnlyAlways
                        PopupControlContainerTool.InstanceProps.Visible = DefaultableBoolean.True
                        ' Add it to the component's tools collection.
                        ' Me.UltraToolbarsManager1.Tools.Add(PopupControlContainerTool)
                        ' Me.UltraToolbarsManager1.Toolbars(0).Tools.AddTool("popup_control")

                        'pan.Width = 300
                        'pan.Height = 500

                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("clUIElements.Menu_loadContainer_Rek: " + ex.ToString())
        End Try
    End Sub


End Class
