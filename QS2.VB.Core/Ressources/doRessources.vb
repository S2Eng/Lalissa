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







    Public Function run2(ByVal contToTranslate As Control, ByVal components As Object, _
                        ByVal tooltipManager1 As UltraToolTipManager, _
                        ByVal TypeRessourcesRun As eTypeRessourcesRun, _
                        ByVal SystemGroup As eSystemGroup, _
                        ByVal ControlGroup As eControlGroup, _
                        ByVal ResType As eResType, _
                        ByVal ConnDb As OleDb.OleDbConnection)

        Try
            Dim iControlsDone As Integer = 0
            If doRessources.DesignMode Then
                Dim doControls As Boolean = True
                Dim Ebene As Integer = 0
                Me.runControls_rek(contToTranslate, components, tooltipManager1, Ebene, _
                                   TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                   iControlsDone, ConnDb)
                Me.runComponents_rek(contToTranslate, components, tooltipManager1, _
                                     TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                     iControlsDone, ConnDb)
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.run: " + ex.ToString())
        End Try
    End Function
    Public Function runControls_rek(ByRef contToTranslate As Control, ByRef components As Object, _
                            ByRef tooltipManager1 As UltraToolTipManager, _
                            ByVal Ebene As Integer, _
                            ByRef TypeRessourcesRun As eTypeRessourcesRun, _
                            ByRef SystemGroup As eSystemGroup, _
                            ByRef ControlGroup As eControlGroup, _
                            ByRef ResType As eResType, ByRef iControlsDone As Integer, _
                            ByRef ConnDb As OleDb.OleDbConnection)
        Try
            If contToTranslate.Name.Trim().ToLower().Equals(("ucRechnungenKlient1").Trim().ToLower()) Then
                Dim str As String = ""
            End If
            If contToTranslate.GetType().Name.Trim().ToLower().Equals(("ucRechnungenKlient").Trim().ToLower()) Then
                Dim str As String = ""
            End If

            Ebene += 1
            For Each contFound As Control In contToTranslate.Controls
                If contFound.Name.Trim().ToLower().Equals(("panelAbrechnungsdaten").Trim().ToLower()) Then
                    Dim str As String = ""
                End If
                If contFound.Name.Trim().ToLower().Equals(("ucKlientenverwaltung3").Trim().ToLower()) Then
                    Dim str As String = ""
                End If
                If contFound.Name.Trim().ToLower().Equals(("panelAbrechnungen2").Trim().ToLower()) Then
                    Dim str As String = ""
                End If

                If Not doRessources.checkIfControlIsLoaded(contToTranslate.Name + "_" + contFound.Name, contFound, doRessources.dsControls) Then

                    Dim ControlActionDone As Boolean = False
                    Dim doRek As Boolean = True
                    If contFound.GetType.Equals((GetType(UltraLabel))) Then
                        Dim labelToTranslate As UltraLabel = contFound


                    ElseIf contFound.GetType.Equals((GetType(Label))) Then
                        Dim labelWindowsToTranslate As Label = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraCheckEditor))) Then
                        Dim checkBoxToTranslate As UltraCheckEditor = contFound

                    ElseIf contFound.GetType.Equals((GetType(UltraGroupBox))) Then
                        Dim groupBoxToTranslate As UltraGroupBox = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraExpandableGroupBox))) Then
                        Dim ExpandableGroupBoxToTranslate As UltraExpandableGroupBox = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraGrid))) Then
                        Dim gridToTranslate As UltraGrid = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraDropDown))) Then
                        Dim UltraDropDownToTranslate As UltraDropDown = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraTree))) Then
                        Dim treeToTranslate As UltraTree = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraCombo))) Then
                        Dim UltraComboToTranslate As UltraCombo = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraButton))) Then
                        Dim ButtonToTranslate As UltraButton = contFound
                        Me.buildResManagerOnUI(contFound, components, tooltipManager1, TypeRessourcesRun, _
                                               SystemGroup, ControlGroup, ResType, iControlsDone, _
                                                ConnDb)
                        ControlActionDone = True

                    ElseIf contFound.GetType.Name.ToString().Trim().ToLower().Equals(("ucButton").Trim().ToLower()) Then
                        Dim ButtonToTranslate As UltraButton = contFound
                        Me.buildResManagerOnUI(contFound, components, tooltipManager1, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                               iControlsDone, ConnDb)
                        ControlActionDone = True

                    ElseIf contFound.GetType.Equals((GetType(UltraDropDownButton))) Then
                        Dim UltraDropDownButtonToTranslate As UltraDropDownButton = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraExplorerBar))) Then
                        Dim UltraExplorerBarToTranslate As UltraExplorerBar = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraOptionSet))) Then
                        Dim UltraOptionSetToTranslate As UltraOptionSet = contFound


                    ElseIf contFound.GetType.Equals((GetType(RadioButton))) Then
                        Dim RadioButtonToTranslate As RadioButton = contFound


                    ElseIf contFound.GetType.Equals((GetType(UltraTabControl))) Then
                        Dim UltraTabControlToTranslate As UltraTabControl = contFound
                        For Each tabInControl As UltraTab In UltraTabControlToTranslate.Tabs
                            Me.runControls_rek(tabInControl.TabControl, components, tooltipManager1, Ebene, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                                iControlsDone, ConnDb)
                        Next

                    ElseIf contFound.GetType.Equals((GetType(UltraTab))) Then
                        Dim str As String = ""

                    ElseIf contFound.GetType.Equals((GetType(MenuStrip))) Then
                        Dim MenuStripToTranslate As MenuStrip = contFound


                    ElseIf contFound.GetType.Equals((GetType(ToolStrip))) Then
                        Dim ToolStripToTranslate As ToolStrip = contFound

                    End If

                    If contFound.GetType.Equals((GetType(Panel))) Or _
                            contFound.GetType.Equals((GetType(UserControl))) Or _
                            contFound.GetType.Equals((GetType(UltraTabControl))) Or _
                            contFound.GetType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
                            contFound.GetType.Equals((GetType(UltraTabSharedControlsPage))) Or _
                            contFound.GetType.Equals((GetType(UltraTabPageControl))) Or _
                            contFound.GetType.Equals((GetType(UltraGrid))) Or _
                            contFound.GetType.Equals((GetType(UltraGridBand))) Or _
                            contFound.GetType.Equals((GetType(UltraGroupBox))) Or _
                            contFound.GetType.Equals((GetType(UltraExpandableGroupBox))) Or _
                            contFound.GetType.Equals((GetType(Form))) Or _
                            contFound.GetType.Equals((GetType(UltraTab))) Or _
                            contFound.GetType.Equals((GetType(UltraExplorerBar))) Or _
                            contFound.GetType.Equals((GetType(UltraDropDownBase))) Or _
                            contFound.GetType.Equals((GetType(Control))) Then

                    End If

                    If contFound.GetType.BaseType.Equals((GetType(Panel))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UserControl))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraTabControl))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraTabSharedControlsPage))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraTabPageControl))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraGrid))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraGridBand))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraGroupBox))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraExpandableGroupBox))) Or _
                            contFound.GetType.BaseType.Equals((GetType(Form))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraTab))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraExplorerBar))) Or _
                            contFound.GetType.BaseType.Equals((GetType(UltraDropDownBase))) Or _
                            contFound.GetType.BaseType.Equals((GetType(Control))) Then

                    End If

                    'Dim rNewControl As dsRessources.ControlsRow = doRessources.compRessourcesWork.addControl(contToTranslate.Name + "_" + contFound.Name, contFound, _
                    '                                                                                         doRessources.dsControls)
                    'rNewControl.Loaded = ControlActionDone

                    'Me.runControls_rek(contFound, components, tooltipManager1, Ebene, _
                    '                   TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                    '                   iControlsDone, ConnDb)

                    If doRek Then
                        Me.runControls_rek(contFound, components, tooltipManager1, Ebene, TypeRessourcesRun, SystemGroup, ControlGroup, ResType, _
                                           iControlsDone, ConnDb)
                    End If

                End If
            Next

            'If contToTranslate.GetType.Equals((GetType(Panel))) Or _
            '    contToTranslate.GetType.Equals((GetType(UserControl))) Or _
            '    contToTranslate.GetType.Equals((GetType(UltraTabControl))) Or _
            '    contToTranslate.GetType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
            '             contToTranslate.GetType.Equals((GetType(UltraDropDownBase))) Or _
            '    contToTranslate.GetType.Equals((GetType(Control))) Then

            'ElseIf contToTranslate.GetType.BaseType.Equals((GetType(Panel))) Or _
            '     contToTranslate.GetType.BaseType.Equals((GetType(UserControl))) Or _
            '     contToTranslate.GetType.BaseType.Equals((GetType(UltraTabControl))) Or _
            '     contToTranslate.GetType.BaseType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
            '  contToTranslate.GetType.BaseType.Equals((GetType(UltraDropDownBase))) Or _
            '     contToTranslate.GetType.BaseType.Equals((GetType(Control))) Then

            'Else
            '    If Ebene = 0 Or Ebene = 1 Then
            '        Dim str As String = ""
            '    End If

            'End If

        Catch ex As Exception
            Throw New Exception("doRessources.runControls_rek: " + ex.ToString())
        End Try
    End Function
    Public Function runComponents_rek(ByRef contToTranslate As Control, ByRef components As Object, _
                            ByRef tooltipManager1 As UltraToolTipManager, _
                            ByRef TypeRessourcesRun As eTypeRessourcesRun, _
                            ByRef SystemGroup As eSystemGroup, _
                            ByRef ControlGroup As eControlGroup, _
                            ByRef ResType As eResType, ByRef iControlsDone As Integer, _
                            ByRef ConnDb As OleDb.OleDbConnection)
        Try
            If Not components Is Nothing Then
                Dim Container1 As New System.ComponentModel.Container
                Container1 = components
                For Each componentFound As Object In Container1.Components

                    If componentFound.GetType.Equals((GetType(UltraToolbarsManager))) Then
                        Dim UltraToolbarsManagerToTranslate As UltraToolbarsManager = componentFound

                    ElseIf componentFound.GetType.Equals((GetType(ContextMenuStrip))) Then
                        Dim ContextMenuStripToTranslate As ContextMenuStrip = componentFound

                    ElseIf componentFound.GetType.Equals((GetType(MenuStrip))) Then
                        Dim MenuStripToTranslate As MenuStrip = componentFound

                    Else
                        Dim xy As String = ""

                    End If
                    'If componentFound.GetType.Equals((GetType(System.ComponentModel.Container))) Then
                    '    Me.runComponents_rek(componentFound, components, tooltipManager1)
                    'End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.runComponents_rek: " + ex.ToString())
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

    Friend WithEvents ContextMenuStrip As System.Windows.Forms.ContextMenuStrip = Nothing
    Friend WithEvents ToolStripMenuItem_CallResManager As System.Windows.Forms.ToolStripMenuItem = Nothing
    Public _forControl As Control = Nothing
    Public _components As Object = Nothing

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


    Public Sub ToolStripMenuItem_CallResManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CallResManager.Click
        Try
            Me.OpenResManager(Me._forControl, Me._components, Me._TypeRessourcesRun, Me._SystemGroup, _
                              Me._ControlGroup, Me._ResType, Me._ConnDb)

        Catch ex As Exception
            Throw New Exception("HandleEvent.ToolStripMenuItem_CallResManager_Click: " + ex.ToString())
        End Try
    End Sub

    Public Function OpenResManager(ByVal contToTranslate As Control, ByVal components As Object, _
                        ByRef TypeRessourcesRun As doRessources.eTypeRessourcesRun, _
                        ByRef SystemGroup As doRessources.eSystemGroup, _
                        ByRef ControlGroup As doRessources.eControlGroup, _
                        ByRef ResType As doRessources.eResType, _
                        ByRef ConnDb As OleDb.OleDbConnection) As Boolean
        Try
            'Dim frm As New frmHandleRessources()

            'frm.ContHandleRessources1._forControl = Me._forControl
            'frm.ContHandleRessources1._components = Me._components
            'frm.ContHandleRessources1._TypeRessourcesRun = Me._TypeRessourcesRun
            'frm.ContHandleRessources1._SystemGroup = Me._SystemGroup
            'frm.ContHandleRessources1._ControlGroup = Me._ControlGroup
            'frm.ContHandleRessources1._ResType = Me._ResType
            'frm.ContHandleRessources1._ConnDb = ConnDb

            'frm.InitControl()
            'frm.ShowDialog()
            'If Not frm.ContHandleRessources1.abort Then

            '    Return True
            'End If

        Catch ex As Exception
            Throw New Exception("HandleEvent.OpenResManager: " + ex.ToString())
        End Try
    End Function

End Class



