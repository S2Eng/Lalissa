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
Imports S2Extensions


Public Class doRessources

    Public Shared DesignMode As Boolean = True
    Public Shared sLanguage As String = "DE"

    Public Enum eTypeRessourcesRun
        RessourcenManagement = 0
        DoRessources = 1
    End Enum

    Public Enum eSystemGroup
        PMDS = 0
    End Enum

    Public Enum eResType
        [Text] = 0
        [Image] = 1
    End Enum

    Public Enum eControlGroup
        MainSystem = 0
        Booking = 1
    End Enum

    Public Shared dsControls As New dsControls()
    Public Shared sqlLanguageWork As New qs2.core.language.sqlLanguage()

    Public Function runControls_rek(ByRef contToTranslate As Control, ByRef components As Object, _
                            ByRef tooltipManager1 As UltraToolTipManager, _
                            ByVal Ebene As Integer, _
                            ByRef TypeRessourcesRun As eTypeRessourcesRun, _
                            ByRef SystemGroup As eSystemGroup, _
                            ByRef ControlGroup As eControlGroup, _
                            ByRef ResType As eResType, ByRef iControlsDone As Integer, _
                            ByRef ConnDb As OleDb.OleDbConnection)
        Try


            Ebene += 1
            For Each contFound As Control In contToTranslate.Controls
                If Not doRessources.checkIfControlIsLoaded(contToTranslate.Name + "_" + contFound.Name, contFound, doRessources.dsControls) Then

                    Dim ControlActionDone As Boolean = False
                    Dim doRek As Boolean = True
                    If contFound.GetType.Equals(GetType(UltraLabel)) Then
                        Dim labelToTranslate As UltraLabel = contFound

                    ElseIf contFound.GetType.Equals(GetType(Label)) Then
                        Dim labelWindowsToTranslate As Label = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraCheckEditor)) Then
                        Dim checkBoxToTranslate As UltraCheckEditor = contFound

                    ElseIf contFound.GetType.Equals(GetType(UltraGroupBox)) Then
                        Dim groupBoxToTranslate As UltraGroupBox = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraExpandableGroupBox)) Then
                        Dim ExpandableGroupBoxToTranslate As UltraExpandableGroupBox = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraGrid)) Then
                        Dim gridToTranslate As UltraGrid = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraDropDown)) Then
                        Dim UltraDropDownToTranslate As UltraDropDown = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraTree)) Then
                        Dim treeToTranslate As UltraTree = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraCombo)) Then
                        Dim UltraComboToTranslate As UltraCombo = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraButton)) Then
                        Me.buildResManagerOnUI(contFound, components, tooltipManager1, TypeRessourcesRun, _
                                               SystemGroup, ControlGroup, ResType, iControlsDone, _
                                                ConnDb)
                        ControlActionDone = True

                    ElseIf contFound.GetType.Name.sEquals("ucButton") Then
                        Me.buildResManagerOnUI(contFound, components, tooltipManager1, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                               iControlsDone, ConnDb)
                        ControlActionDone = True

                    ElseIf contFound.GetType.Equals(GetType(UltraDropDownButton)) Then
                        Dim UltraDropDownButtonToTranslate As UltraDropDownButton = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraExplorerBar)) Then
                        Dim UltraExplorerBarToTranslate As UltraExplorerBar = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraOptionSet)) Then
                        Dim UltraOptionSetToTranslate As UltraOptionSet = contFound


                    ElseIf contFound.GetType.Equals(GetType(RadioButton)) Then
                        Dim RadioButtonToTranslate As RadioButton = contFound


                    ElseIf contFound.GetType.Equals(GetType(UltraTabControl)) Then
                        Dim UltraTabControlToTranslate As UltraTabControl = contFound
                        For Each tabInControl As UltraTab In UltraTabControlToTranslate.Tabs
                            Me.runControls_rek(tabInControl.TabControl, components, tooltipManager1, Ebene, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                                iControlsDone, ConnDb)
                        Next

                    ElseIf contFound.GetType.Equals(GetType(UltraTab)) Then
                        Dim str As String = ""

                    ElseIf contFound.GetType.Equals(GetType(MenuStrip)) Then
                        Dim MenuStripToTranslate As MenuStrip = contFound


                    ElseIf contFound.GetType.Equals(GetType(ToolStrip)) Then
                        Dim ToolStripToTranslate As ToolStrip = contFound

                    End If

                    If doRek Then
                        Me.runControls_rek(contFound, components, tooltipManager1, Ebene, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                           iControlsDone, ConnDb)
                    End If

                End If
            Next

        Catch ex As Exception
            Throw New Exception("doRessources.runControls_rek: " + ex.ToString())
        End Try
    End Function

    Public Sub buildResManagerOnUI(ByVal contToTranslate As Control, ByVal components As Object, _
                                ByVal tooltipManager1 As UltraToolTipManager, _
                                ByRef TypeRessourcesRun As eTypeRessourcesRun, _
                                ByRef SystemGroup As eSystemGroup, _
                                ByRef ControlGroup As eControlGroup, _
                                ByRef ResType As eResType, ByRef iControlsDone As Integer, _
                                ByRef ConnDb As OleDb.OleDbConnection)
        Try
            Dim HandleEvent1 As New HandleEvent(components, contToTranslate, iControlsDone, ConnDb)

        Catch ex As Exception
            Throw New Exception("doRessources.buildResManagerOnUI: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function checkIfControlIsLoaded(ByRef ControlKey As String, ByRef Ctrl As System.Windows.Forms.Control, ByRef ds As dsControls) As Boolean
        Dim arrControl() As dsControls.ControlsRow = ds.Controls.Select(ds.Controls.ControlKeyColumn.ColumnName + "='" + ControlKey.Trim() + "'", "")
        If arrControl.Length = 1 Then
            Return False
        End If
    End Function
End Class


Public Class HandleEvent
    Private WithEvents ContextMenuStrip As System.Windows.Forms.ContextMenuStrip = Nothing
    Private WithEvents ToolStripMenuItem_CallResManager As System.Windows.Forms.ToolStripMenuItem = Nothing
    Private _forControl As Control = Nothing
    Private _components As Object = Nothing

    Public _TypeRessourcesRun As doRessources.eTypeRessourcesRun = Nothing
    Public _SystemGroup As doRessources.eSystemGroup = Nothing
    Public _ControlGroup As doRessources.eControlGroup = Nothing
    Public _ResType As doRessources.eResType = Nothing

    Public _ConnDb As OleDb.OleDbConnection = Nothing

    Public Sub New(ByVal components As Object, forControl As Control, ByRef iControlsDone As Integer, ByRef ConnDb As OleDb.OleDbConnection)
        Try
            Me._forControl = forControl
            Me._components = components
            Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(components)
            Me._ConnDb = ConnDb
            ContextMenuStrip.Name = "MStripRessourcenHandler_" + System.Guid.NewGuid().ToString()
            Me.ToolStripMenuItem_CallResManager = Me.ContextMenuStrip.Items.Add("RessourcenHandler" + System.Guid.NewGuid().ToString())
            Me.ToolStripMenuItem_CallResManager.Text = "Ressourcen-Handler"

            forControl.ContextMenuStrip = Me.ContextMenuStrip

            iControlsDone += 1

        Catch ex As Exception
            Throw New Exception("HandleEvent.New: " + ex.ToString())
        End Try
    End Sub
End Class



