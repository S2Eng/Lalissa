Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.UltraWinTabControl

Imports System.Windows.Forms
Imports qs2.core.language
Imports qs2.core.license




Public Class doUI

    Public sqlLanguageWork As New sqlLanguage()

    Public Shared txtResID As String = "ResID."
    Public Shared txtResIDNoTranslate As String = "ResID.NoTranslate"

    Public Enum eTypUIPrefixe
        resID = 1
    End Enum




    Public Sub New()
        sqlLanguageWork.initControl()
    End Sub



    Public Function EnableControls(ByRef control As Control, enable As Boolean)

        For Each contFound As Control In control.Controls
            If contFound.GetType.Equals((GetType(UltraLabel))) Then
                Dim labelToFound As UltraLabel = contFound
                Me.EnableControl(labelToFound, True)

            ElseIf contFound.GetType.Equals((GetType(Label))) Then
                Dim labelWindowsFound As Label = contFound
                Me.EnableControl(labelWindowsFound, True)

            ElseIf contFound.GetType.Equals((GetType(UltraCheckEditor))) Then
                Dim checkBoxFound As UltraCheckEditor = contFound
                Me.EnableControl(checkBoxFound, True)

            ElseIf contFound.GetType.Equals((GetType(UltraGroupBox))) Then
                Dim groupBoxFound As UltraGroupBox = contFound
                Me.EnableControl(groupBoxFound, True)

            ElseIf contFound.GetType.Equals((GetType(UltraComboEditor))) Then
                Dim ComboBoxFound As UltraComboEditor = contFound
                Dim styleButtDropDown As New Infragistics.Win.ButtonDisplayStyle
                If enable Then
                    styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.Always
                Else
                    styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
                End If
                ComboBoxFound.DropDownButtonDisplayStyle = styleButtDropDown
                Me.EnableControl(ComboBoxFound, enable)

            Else
                Me.EnableControl(contFound, enable)

            End If

            Me.EnableControls(contFound, enable)
        Next

    End Function
    Public Function EnableControl(ByRef control As Control, enable As Boolean)
        control.Enabled = enable
    End Function
    Public Sub checkBoxes_BeforeCheckStateChanged(sender As System.Object, e As System.ComponentModel.CancelEventArgs, enabled As Boolean)
        Dim checkEditor As Infragistics.Win.UltraWinEditors.UltraCheckEditor = sender
        If checkEditor.Focused Then
            If Not enabled Then
                e.Cancel = True
            End If
        End If
    End Sub


    Public Function runxyxy(ByVal contToTranslate As Control, ByVal components As Object, _
                          ByVal tooltipManager1 As UltraToolTipManager, _
                          ByRef newRessourcesAdded As Integer, ByVal doGrid As Boolean, Optional ByVal doTree As Boolean = False, _
                          Optional ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String) = Nothing)

        Me.runControls_rek(contToTranslate, components, tooltipManager1, newRessourcesAdded, doGrid, doTree, lstControlNamesNoTranslate)
        Me.runComponents_rek(contToTranslate, components, tooltipManager1, newRessourcesAdded, lstControlNamesNoTranslate)

    End Function
    Public Function runControls_rek(ByRef contToTranslate As Control, ByRef components As Object, _
                            ByRef tooltipManager1 As UltraToolTipManager, _
                            ByRef newRessourcesAdded As Integer, ByVal doGrid As Boolean, ByVal doTree As Boolean, _
                            ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String))

        If Not Me.noTranslate(lstControlNamesNoTranslate, contToTranslate.Name) Then

            For Each contFound As Control In contToTranslate.Controls
                If contFound.GetType.Equals((GetType(UltraLabel))) Then
                    Dim labelToTranslate As UltraLabel = contFound
                    labelToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doLabel(labelToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(labelToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(Label))) Then
                    Dim labelWindowsToTranslate As Label = contFound
                    labelWindowsToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doLabelWindows(labelWindowsToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(labelWindowsToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(UltraCheckEditor))) Then
                    Dim checkBoxToTranslate As UltraCheckEditor = contFound
                    checkBoxToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doCheckBox(checkBoxToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(checkBoxToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(UltraGroupBox))) Then
                    Dim groupBoxToTranslate As UltraGroupBox = contFound
                    groupBoxToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doGroupBox(groupBoxToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(groupBoxToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(UltraExpandableGroupBox))) Then
                    Dim ExpandableGroupBoxToTranslate As UltraExpandableGroupBox = contFound
                    ExpandableGroupBoxToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doExpandableGroupBox(ExpandableGroupBoxToTranslate, tooltipManager1, newRessourcesAdded)

                ElseIf contFound.GetType.Equals((GetType(UltraGrid))) Then
                    If doGrid Then
                        Dim gridToTranslate As UltraGrid = contFound
                        gridToTranslate.Text = ""
                        Me.doGrid(gridToTranslate, tooltipManager1, newRessourcesAdded)
                    End If

                ElseIf contFound.GetType.Equals((GetType(UltraDropDown))) Then
                    If doGrid Then
                        Dim UltraDropDownToTranslate As UltraDropDown = contFound
                        UltraDropDownToTranslate.Text = ""
                        Me.doUltraDropDown(UltraDropDownToTranslate, tooltipManager1, newRessourcesAdded)
                    End If

                ElseIf contFound.GetType.Equals((GetType(UltraTree))) Then
                    If doTree Then
                        Dim treeToTranslate As UltraTree = contFound
                        'treeToTranslate.Text = ""
                        'If Not treeToTranslate.Tag Is Nothing Then
                        '    Dim TranslatedString As String = ""
                        '    Me.doText(treeToTranslate.Tag.ToString().Trim(), tooltipManager1, newRessourcesAdded, TranslatedString)
                        '    treeToTranslate.Text = TranslatedString
                        'End If
                        Me.doTree(treeToTranslate.Nodes, tooltipManager1, newRessourcesAdded)
                    End If

                ElseIf contFound.GetType.Equals((GetType(UltraCombo))) Then
                    Dim UltraComboToTranslate As UltraCombo = contFound
                    UltraComboToTranslate.Text = ""
                    Me.doUltraCombo(UltraComboToTranslate, tooltipManager1, newRessourcesAdded)

                ElseIf contFound.GetType.Equals((GetType(UltraButton))) Then
                    Dim ButtonToTranslate As UltraButton = contFound
                    If Not Me.noTranslate(lstControlNamesNoTranslate, ButtonToTranslate.Name) Then
                        ButtonToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doButton(ButtonToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(ButtonToTranslate, tooltipManager1)
                    Else
                        'MsgBox("NoTranslate " + ButtonToTranslate.Name, MsgBoxStyle.Information, "")
                    End If

                ElseIf contFound.GetType.Equals((GetType(UltraDropDownButton))) Then
                    Dim UltraDropDownButtonToTranslate As UltraDropDownButton = contFound
                    UltraDropDownButtonToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doDropDownButton(UltraDropDownButtonToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(UltraDropDownButtonToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(UltraExplorerBar))) Then
                    Dim UltraExplorerBarToTranslate As UltraExplorerBar = contFound
                    UltraExplorerBarToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doUltraExplorerBar(UltraExplorerBarToTranslate, tooltipManager1, newRessourcesAdded)

                ElseIf contFound.GetType.Equals((GetType(UltraOptionSet))) Then
                    Dim UltraOptionSetToTranslate As UltraOptionSet = contFound
                    UltraOptionSetToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doOptionSet(UltraOptionSetToTranslate, tooltipManager1, newRessourcesAdded)
                    Me.doToolTipForControl(UltraOptionSetToTranslate, tooltipManager1)

                ElseIf contFound.GetType.Equals((GetType(RadioButton))) Then
                    Dim RadioButtonToTranslate As RadioButton = contFound
                    RadioButtonToTranslate.Text = ""
                    If Not RadioButtonToTranslate.Tag Is Nothing Then
                        Dim TranslatedString As String = ""
                        Me.doText(RadioButtonToTranslate.Tag.ToString().Trim(), tooltipManager1, newRessourcesAdded, TranslatedString)
                        RadioButtonToTranslate.Text = TranslatedString
                        Me.doToolTipForControl(RadioButtonToTranslate, tooltipManager1)
                    End If

                ElseIf contFound.GetType.Equals((GetType(UltraTabControl))) Then
                    Dim UltraTabControlToTranslate As UltraTabControl = contFound
                    UltraTabControlToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doTabs(UltraTabControlToTranslate, tooltipManager1, newRessourcesAdded)

                ElseIf contFound.GetType.Equals((GetType(MenuStrip))) Then
                    Dim MenuStripToTranslate As MenuStrip = contFound
                    MenuStripToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doContextMenüStrip(MenuStripToTranslate.Items, tooltipManager1, newRessourcesAdded)

                ElseIf contFound.GetType.Equals((GetType(ToolStrip))) Then
                    Dim ToolStripToTranslate As ToolStrip = contFound
                    If Not Me.noTranslate(lstControlNamesNoTranslate, ToolStripToTranslate.Name) Then
                        ToolStripToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doContextMenüStrip(ToolStripToTranslate.Items, tooltipManager1, newRessourcesAdded)
                    Else
                        Dim str As String = ""
                    End If

                End If

                Me.runControls_rek(contFound, components, tooltipManager1, newRessourcesAdded, doGrid, doTree, lstControlNamesNoTranslate)
            Next

        Else
            Dim str As String = ""

        End If
    End Function
    Public Function runComponents_rek(ByRef contToTranslate As Control, ByRef components As Object, _
                          ByRef tooltipManager1 As UltraToolTipManager, _
                          ByRef newRessourcesAdded As Integer, _
                          ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String))

        If Not components Is Nothing Then
            Dim Container1 As New System.ComponentModel.Container
            Container1 = components
            For Each componentFound As Object In Container1.Components

                If componentFound.GetType.Equals((GetType(UltraToolbarsManager))) Then
                    Dim UltraToolbarsManagerToTranslate As UltraToolbarsManager = componentFound
                    Me.doToolbar(UltraToolbarsManagerToTranslate, tooltipManager1, newRessourcesAdded)

                ElseIf componentFound.GetType.Equals((GetType(ContextMenuStrip))) Then
                    Dim ContextMenuStripToTranslate As ContextMenuStrip = componentFound
                    ContextMenuStripToTranslate.Text = ""
                    Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                    Me.doContextMenüStrip(ContextMenuStripToTranslate.Items, tooltipManager1, newRessourcesAdded)

                ElseIf componentFound.GetType.Equals((GetType(MenuStrip))) Then
                    If Not Me.noTranslate(lstControlNamesNoTranslate, componentFound.Name) Then
                        Dim MenuStripToTranslate As MenuStrip = componentFound
                        MenuStripToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doContextMenüStrip(MenuStripToTranslate.Items, tooltipManager1, newRessourcesAdded)
                    End If

                Else
                    Dim xy As String = ""

                End If
                'If componentFound.GetType.Equals((GetType(System.ComponentModel.Container))) Then
                '    Me.runComponents_rek(componentFound, components, tooltipManager1, newRessourcesAdded)
                'End If
            Next

        End If
    End Function



    Public Function doText(ByRef tagToTranslate As String, ByVal tooltipManager1 As UltraToolTipManager, _
                               ByRef newRessourcesAdded As Integer, ByRef TranslatedString As String)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""
        If Not tagToTranslate Is Nothing Then
            If Me.analyseTag(tagToTranslate.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    TranslatedString = qs2.core.language.sqlLanguage.getRes(IDUI)
                Else
                    Throw New Exception(".doText: TypUIPrefixe '" + TypUIPrefixe.ToString() + "' not exists!")
                End If
            End If
        End If

    End Function
    Public Function doLabel(ByVal labelToTranslate As UltraLabel, ByVal tooltipManager1 As UltraToolTipManager, _
                                   ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""
        If Not labelToTranslate.Tag Is Nothing Then
            If Me.analyseTag(labelToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    labelToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doLabelWindows(ByVal WindowslabelToTranslate As Label, ByVal tooltipManager1 As UltraToolTipManager, _
                                   ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""
        If Not WindowslabelToTranslate.Tag Is Nothing Then
            If Me.analyseTag(WindowslabelToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    WindowslabelToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doButton(ByVal ButtonToTranslate As UltraButton, ByVal tooltipManager1 As UltraToolTipManager, _
                               ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""

        If Not ButtonToTranslate.Tag Is Nothing Then
            If Me.analyseTag(ButtonToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    ButtonToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)
                End If
            End If
        End If
    End Function

    Public Function doDropDownButton(ByVal DropDownButtonToTranslate As UltraDropDownButton, ByVal tooltipManager1 As UltraToolTipManager, _
                           ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""

        If Not DropDownButtonToTranslate.Tag Is Nothing Then
            If Me.analyseTag(DropDownButtonToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    DropDownButtonToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doCheckBox(ByVal checkBoxToTranslate As UltraCheckEditor, ByVal tooltipManager1 As UltraToolTipManager, _
                               ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""
        If Not checkBoxToTranslate.Tag Is Nothing Then
            If Me.analyseTag(checkBoxToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    checkBoxToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doGroupBox(ByVal groupBoxToTranslate As UltraGroupBox, ByVal tooltipManager1 As UltraToolTipManager, _
                             ByRef newRessourcesAdded As Integer)

        Dim IDUI As String = ""
        Dim eTypUIPrefixe As New eTypUIPrefixe()
        If Not groupBoxToTranslate.Tag Is Nothing Then
            If Me.analyseTag(groupBoxToTranslate.Tag.ToString().Trim(), IDUI, eTypUIPrefixe) Then
                If eTypUIPrefixe = eTypUIPrefixe.resID Then
                    groupBoxToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doExpandableGroupBox(ByVal ExpandableGroupBoxToTranslate As UltraExpandableGroupBox, ByVal tooltipManager1 As UltraToolTipManager, _
                         ByRef newRessourcesAdded As Integer)

        Dim IDUI As String = ""
        Dim eTypUIPrefixe As New eTypUIPrefixe()
        If Not ExpandableGroupBoxToTranslate.Tag Is Nothing Then
            If Me.analyseTag(ExpandableGroupBoxToTranslate.Tag.ToString().Trim(), IDUI, eTypUIPrefixe) Then
                If eTypUIPrefixe = eTypUIPrefixe.resID Then
                    ExpandableGroupBoxToTranslate.Text = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doGrid(ByVal gridToTranslate As UltraGrid, ByVal tooltipManager1 As UltraToolTipManager, _
                                  ByRef newRessourcesAdded As Integer)

        If Not gridToTranslate.Tag Is Nothing Then
            Dim TranslatedString As String = ""
            Me.doText(gridToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
            gridToTranslate.Text = TranslatedString
        End If

        gridToTranslate.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumnHeaderToGroupBy")

        Me.doBand(gridToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

    End Function
    Public Function doUltraDropDown(ByVal UltraDropDownToTranslate As UltraDropDown, ByVal tooltipManager1 As UltraToolTipManager, _
                              ByRef newRessourcesAdded As Integer)

        If Not UltraDropDownToTranslate.Tag Is Nothing Then
            Dim TranslatedString As String = ""
            Me.doText(UltraDropDownToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
            UltraDropDownToTranslate.Text = TranslatedString
        End If

        UltraDropDownToTranslate.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumnHeaderToGroupBy")

        Me.doBand(UltraDropDownToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

    End Function
    Public Function doUltraCombo(ByVal UltraComboToTranslate As UltraCombo, ByVal tooltipManager1 As UltraToolTipManager, _
                              ByRef newRessourcesAdded As Integer)

        If Not UltraComboToTranslate.Tag Is Nothing Then
            Dim TranslatedString As String = ""
            Me.doText(UltraComboToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
            UltraComboToTranslate.Text = TranslatedString
        End If

        UltraComboToTranslate.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumnHeaderToGroupBy")

        Me.doBand(UltraComboToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

    End Function
    Public Function doBand(ByVal BandsCollectionToTranslate As BandsCollection, ByVal tooltipManager1 As UltraToolTipManager, _
                              ByRef newRessourcesAdded As Integer)

        For Each bandFound As UltraGridBand In BandsCollectionToTranslate
            For Each colFound As UltraGridColumn In bandFound.Columns
                If Not colFound.IsChaptered And Not colFound.IsGroupByColumn Then
                    colFound.Header.Caption = ""
                    colFound.Header.ToolTipText = ""
                    Try
                        colFound.Header.Caption = qs2.core.language.sqlLanguage.getRes(bandFound.Key + "." + colFound.Key, False)
                        colFound.Header.ToolTipText = colFound.Header.Caption
                    Catch ex As Exception
                        If ENV.AdminSecure Then
                            Me.addRessourceAuto(newRessourcesAdded, bandFound.Key + "." + colFound.Key, colFound.Key, bandFound.Key)
                        Else
                            Throw New Exception("AutoUI.doBand: TranslateGridBand - ResID for Column '" + bandFound.Key + "." + colFound.Key + "' !")
                        End If
                    End Try
                End If
            Next
        Next

    End Function
    Public Function doTabs(ByVal UltraTaTranslate As UltraTabControl, ByVal tooltipManager1 As UltraToolTipManager, _
                                 ByRef newRessourcesAdded As Integer)

        If Not UltraTaTranslate.Tag Is Nothing Then
            'Dim TranslatedString As String = ""
            'Me.doText(UltraTaTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
        End If

        For Each tabFound As UltraTab In UltraTaTranslate.Tabs
            tabFound.Text = ""
            tabFound.ToolTipText = ""

            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not tabFound.Tag Is Nothing Then
                If Me.analyseTag(tabFound.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        tabFound.Text = Me.sqlLanguageWork.getRes(IDUI)

                    End If
                End If
            End If
        Next

    End Function
    Public Function doContextMenüStrip(ByVal ToolStripItemCollectionToTranslate As ToolStripItemCollection, ByVal tooltipManager1 As UltraToolTipManager, _
                              ByRef newRessourcesAdded As Integer)

        'If Not ContextMenuStripToTranslate.Tag Is Nothing Then
        '    Me.doText(ContextMenuStripToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded)
        'End If

        For Each ToolStripItem1 As ToolStripItem In ToolStripItemCollectionToTranslate
            If Not Me.checkTagNoTranslate(ToolStripItem1.Tag) Then
                ToolStripItem1.Text = ""
                ToolStripItem1.ToolTipText = ""

                Dim TypUIPrefixe As New eTypUIPrefixe()
                Dim IDUI As String = ""
                If Not ToolStripItem1.Tag Is Nothing Then
                    If Me.analyseTag(ToolStripItem1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                        If TypUIPrefixe = eTypUIPrefixe.resID Then
                            ToolStripItem1.Text = Me.sqlLanguageWork.getRes(IDUI)

                        End If
                    End If
                End If

                If ToolStripItem1.GetType.Equals((GetType(ToolStripMenuItem))) Then
                    Dim ToolStripMenuItem1 As ToolStripMenuItem = ToolStripItem1
                    Me.doContextMenüStrip(ToolStripMenuItem1.DropDownItems, tooltipManager1, newRessourcesAdded)
                End If
            End If
        Next

    End Function

    Public Function doToolbar(ByVal UltraToolbarsManagerToTranslate As UltraToolbarsManager, ByVal tooltipManager1 As UltraToolTipManager, _
                                 ByRef newRessourcesAdded As Integer)

        For Each ToolBaseFound As ToolBase In UltraToolbarsManagerToTranslate.Tools
            Me.doToolBase(ToolBaseFound, tooltipManager1, newRessourcesAdded)
        Next
        'For Each ToolBarToTranslate As UltraToolbar In UltraToolbarsManagerToTranslate.Toolbars
        '    For Each ToolBaseFound As ToolBase In ToolBarToTranslate.Tools
        '        Me.doToolbar(ToolBarToTranslate.Tools, tooltipManager1, newRessourcesAdded)
        '    Next
        'Next

        'For Each RibbonTab1 As RibbonTab In UltraToolbarsManagerToTranslate.Ribbon.Tabs
        '    If Not RibbonTab1.Tag Is Nothing Then
        '        Me.doText(RibbonTab1.Tag.ToString(), tooltipManager1, newRessourcesAdded)
        '    End If
        '    Me.doToolbarRibbon(RibbonTab1, tooltipManager1, newRessourcesAdded)
        'Next

    End Function
    Public Function doToolbar(ByVal ToolsCollectionToTranslate As ToolsCollection, ByVal tooltipManager1 As UltraToolTipManager, _
                                     ByRef newRessourcesAdded As Integer)

        For Each ToolBaseFound As ToolBase In ToolsCollectionToTranslate
            Me.doToolBase(ToolBaseFound, tooltipManager1, newRessourcesAdded)
        Next

    End Function
    Public Function doToolbar(ByVal ToolsCollectionToTranslate As RootToolsCollection, ByVal tooltipManager1 As UltraToolTipManager, _
                              ByRef newRessourcesAdded As Integer)

        For Each ToolBaseFound As ToolBase In ToolsCollectionToTranslate
            Me.doToolBase(ToolBaseFound, tooltipManager1, newRessourcesAdded)
        Next

    End Function
    Public Function doToolBase(ByVal ToolBaseFound As ToolBase, ByVal tooltipManager1 As UltraToolTipManager, _
                            ByRef newRessourcesAdded As Integer)

        ToolBaseFound.SharedProps.Caption = ""
        ToolBaseFound.SharedProps.ToolTipTitle = ""
        ToolBaseFound.SharedProps.ToolTipText = ""
        ToolBaseFound.SharedProps.ToolTipTextFormatted = ""

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""
        If Not ToolBaseFound.Tag Is Nothing Then
            If Me.analyseTag(ToolBaseFound.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                If TypUIPrefixe = eTypUIPrefixe.resID Then
                    ToolBaseFound.SharedProps.Caption = Me.sqlLanguageWork.getRes(IDUI)

                End If
            End If
        End If

    End Function
    Public Function doToolbarRibbon(ByVal RibbonTabToTranslate As RibbonTab, ByVal tooltipManager1 As UltraToolTipManager, _
                                 ByRef newRessourcesAdded As Integer)

        For Each RibbonGroup1 As RibbonGroup In RibbonTabToTranslate.Groups
            RibbonGroup1.Caption = ""
            If Not RibbonGroup1.Tag Is Nothing Then
                Dim TranslatedString As String = ""
                Me.doText(RibbonGroup1.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
                RibbonGroup1.Caption = TranslatedString
            End If

            Me.doToolbar(RibbonGroup1.Tools, tooltipManager1, newRessourcesAdded)
        Next

    End Function

    Public Function doOptionSet(ByVal UltraOptionSetToTranslate As UltraOptionSet, ByVal tooltipManager1 As UltraToolTipManager, _
                                  ByRef newRessourcesAdded As Integer)

        For Each ValueListItem1 As ValueListItem In UltraOptionSetToTranslate.Items
            ValueListItem1.DisplayText = ""
            If Not ValueListItem1.Tag Is Nothing Then
                Dim TypUIPrefixe As New eTypUIPrefixe()
                Dim IDUI As String = ""
                If Not ValueListItem1.Tag Is Nothing Then
                    If Me.analyseTag(ValueListItem1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                        If TypUIPrefixe = eTypUIPrefixe.resID Then
                            ValueListItem1.DisplayText = Me.sqlLanguageWork.getRes(IDUI)

                        End If
                    End If
                End If
            End If
        Next

    End Function
    Public Function doUltraExplorerBar(ByVal UltraExplorerBarToTranslate As UltraExplorerBar, ByVal tooltipManager1 As UltraToolTipManager, _
                       ByRef newRessourcesAdded As Integer)

        Dim TypUIPrefixe As New eTypUIPrefixe()
        Dim IDUI As String = ""

        For Each UltraExplorerBarGrp As UltraExplorerBarGroup In UltraExplorerBarToTranslate.Groups
            UltraExplorerBarGrp.Text = ""
            UltraExplorerBarGrp.ToolTipText = ""

            If Not UltraExplorerBarGrp.Tag Is Nothing Then
                If Me.analyseTag(UltraExplorerBarGrp.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        UltraExplorerBarGrp.Text = Me.sqlLanguageWork.getRes(IDUI)

                    End If
                End If
            End If

            For Each UltraExplorerBarItem1 As UltraExplorerBarItem In UltraExplorerBarGrp.Items
                UltraExplorerBarItem1.Text = ""
                UltraExplorerBarItem1.ToolTipText = ""

                If Not UltraExplorerBarItem1.Tag Is Nothing Then
                    If Me.analyseTag(UltraExplorerBarItem1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                        If TypUIPrefixe = eTypUIPrefixe.resID Then
                            UltraExplorerBarItem1.Text = Me.sqlLanguageWork.getRes(IDUI)

                        End If
                    End If
                End If
            Next
        Next

    End Function
    Public Function doTree(ByVal TreeNodesCollectionToTranslate As TreeNodesCollection, ByVal tooltipManager1 As UltraToolTipManager, _
                    ByRef newRessourcesAdded As Integer)

        For Each UltraTreeNode1 As UltraTreeNode In TreeNodesCollectionToTranslate
            UltraTreeNode1.Text = ""

            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""

            If Not UltraTreeNode1.Tag Is Nothing Then
                If Me.analyseTag(UltraTreeNode1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        UltraTreeNode1.Text = Me.sqlLanguageWork.getRes(IDUI)

                    End If
                End If
            End If

            Me.doTree(UltraTreeNode1.Nodes, tooltipManager1, newRessourcesAdded)
        Next

    End Function




    Public Function analyseTag(ByRef sTag As String, ByRef keyReturn As String, _
                                     ByRef TypUIPrefixeReturn As eTypUIPrefixe) As Boolean

        Try
            If sTag.ToString().Trim() <> "" Then
                Dim tagInfo As String = sTag.ToString().Trim()
                If tagInfo.Substring(0, doUI.txtResID.Length).ToLower() = doUI.txtResID.ToLower() Then
                    keyReturn = tagInfo.Substring(doUI.txtResID.Length, tagInfo.Length - doUI.txtResID.Length)
                    TypUIPrefixeReturn = eTypUIPrefixe.resID
                    Return True

                Else
                    Throw New Exception("analyseTag: Wrong Prefix in Control.Tag for auto-UI!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("analyseTag: Error for translating Tag '" + sTag.ToString().Trim() + "': " + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkTagNoTranslate(ByRef sTag As Object) As Boolean

        Try
            If Not sTag Is Nothing Then
                If sTag.ToString().Trim() <> "" Then
                    Dim tagInfo As String = sTag.ToString().Trim()
                    If tagInfo.ToLower() = doUI.txtResIDNoTranslate.Trim().ToLower() Then
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function noTranslate(ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String), _
                                                ByVal actuellControlName As String) As Boolean
        If Not lstControlNamesNoTranslate Is Nothing Then
            For Each contFoundNotTranslate As String In lstControlNamesNoTranslate
                If contFoundNotTranslate = actuellControlName Then
                    Return True
                End If
            Next
        End If

    End Function


    Public Function doToolTipForControl(ByVal ControlToTranslate As Control, ByVal tooltipManager1 As UltraToolTipManager) As Boolean
        Try
            Dim UltraToolTipInfoFound As UltraToolTipInfo = tooltipManager1.GetUltraToolTip(ControlToTranslate)
            If Not UltraToolTipInfoFound Is Nothing Then
                UltraToolTipInfoFound.ToolTipTitle = ""
                UltraToolTipInfoFound.ToolTipText = ""
                UltraToolTipInfoFound.ToolTipTextFormatted = ""
                'tooltipManager1.SetUltraToolTip(ControlToTranslate, UltraToolTipInfoFound)

                If Not UltraToolTipInfoFound.Tag Is Nothing Then
                    Dim tagInfo As String = UltraToolTipInfoFound.Tag.ToString()
                    If tagInfo.ToString().Trim() <> "" Then
                        tagInfo = tagInfo.ToString().Trim()
                        Dim lstIDRes As New System.Collections.Generic.List(Of String)
                        If Not tagInfo.Contains(";") Then
                            lstIDRes.Add(tagInfo)
                        Else
                            lstIDRes = qs2.core.generic.readStrVariables(tagInfo)
                        End If

                        Dim TypUIPrefixe As New eTypUIPrefixe()
                        Dim IDUI As String = ""
                        'Dim UltraToolTipInfo1 As New UltraToolTipInfo()
                        'UltraToolTipInfo1.Tag = tagInfo

                        If lstIDRes.Count = 1 Then
                            If Me.analyseTag(lstIDRes(0).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTitle = ""
                                UltraToolTipInfoFound.ToolTipTextFormatted = Me.sqlLanguageWork.getRes(IDUI)
                            End If
                            'tooltipManager1.SetUltraToolTip(ControlToTranslate, UltraToolTipInfo1)

                        ElseIf lstIDRes.Count = 2 Then
                            If Me.analyseTag(lstIDRes(0).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTitle = Me.sqlLanguageWork.getRes(IDUI)
                            End If
                            If Me.analyseTag(lstIDRes(1).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTextFormatted = Me.sqlLanguageWork.getRes(IDUI)
                            End If
                            'tooltipManager1.SetUltraToolTip(ControlToTranslate, UltraToolTipInfoFound)
                        Else
                            Throw New Exception("doToolTipForControl: lstIDRes.Count is > 2 for control '" + ControlToTranslate.Name + "'!")
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Sub setToolTipForControl(ByVal contToTranslate As Control, ByVal tooltipManager1 As UltraToolTipManager, _
                                    ByVal Title As String, ByVal Txt As String)
        'Dim infoToolTip As New UltraToolTipInfo()
        'infoToolTip.ToolTipTitle = Title
        'infoToolTip.ToolTipText = Txt
        'tooltipManager1.SetUltraToolTip(contToTranslate, infoToolTip)
    End Sub
    Public Sub clearToolTipForControl(ByVal contToTranslate As Control, ByVal tooltipManager1 As UltraToolTipManager)
        If Not tooltipManager1 Is Nothing Then
            'Dim infoToolTip As New UltraToolTipInfo()
            'infoToolTip.ToolTipTitle = ""
            'infoToolTip.ToolTipText = ""
            'tooltipManager1.SetUltraToolTip(contToTranslate, infoToolTip)
        End If
    End Sub

    Public Function addRessourceAuto(ByRef newRessourcesAdded As Integer, ByVal IDRes As String, ByVal ColumnName As String, ByVal TableName As String)

        MsgBox("Add Auto-Ressource for Translation: " + IDRes, MsgBoxStyle.Information, "addRessourceAuto")

        Dim dsLanguageWork As New dsLanguage()
        Me.sqlLanguageWork.getLanguage(System.Guid.NewGuid().ToString(), dsLanguageWork, sqlLanguage.eTypSelLang.IDRes, Enums.eResourceType.Label, System.Guid.NewGuid().ToString().ToString())

        Dim rNewRes As dsLanguage.RessourcenRow = Me.sqlLanguageWork.newRowLanguage(dsLanguageWork, "", "", "", "", "", Enums.eResourceType.Label, Enums.eTypeSub.User, "")
        rNewRes.IDRes = IDRes
        rNewRes.German = ColumnName
        rNewRes.English = ColumnName
        'rNewRes.IDLanguageUser = General.defaultCountry
        rNewRes.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()
        rNewRes.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
        rNewRes.CreatedUser = "Auto"

        Me.sqlLanguageWork.daLanguage.Update(dsLanguageWork.Ressourcen)
        newRessourcesAdded += 1

    End Function

    Public Sub autoAddResInGrid(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                ByRef AutoResOnReturn As Boolean, ByRef chkOnlyAdd As UltraWinEditors.UltraCheckEditor,
                                doOff As Boolean)
        Try
            Dim bOn As Boolean = False
            If doOff Then
                lblAutoResOnOff.Tag = 0
                lblAutoResOnOff.Text = "Auto-Res On"
                chkOnlyAdd.Visible = False
                bOn = False
            Else
                If lblAutoResOnOff.Tag = 0 Then
                    lblAutoResOnOff.Tag = 1
                    lblAutoResOnOff.Text = "Auto-Res Off"
                    chkOnlyAdd.Visible = True
                    bOn = True
                Else
                    lblAutoResOnOff.Tag = 0
                    lblAutoResOnOff.Text = "Auto-Res On"
                    chkOnlyAdd.Visible = False
                    bOn = False
                End If
            End If

            grid.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameEnglish.Trim()).Hidden = Not bOn
            grid.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameGerman.Trim()).Hidden = Not bOn
            AutoResOnReturn = bOn

        Catch ex As Exception
            Throw New Exception("doUI.AutoAddResInGrid: " + ex.ToString())
        End Try
    End Sub
    Public Sub addAutoRessources(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                    ByRef Application As String, ByRef sProt As String,
                                    ByRef iCounterInserted As Integer, ByRef iCounterUpdated As Integer, ByRef onlyAddRes As Boolean)
        Try
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            sqlLanguage1.initControl()
            Dim cTranslate1 As New cTranslate()

            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                If rSelList.IDRessource.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rSelList.IDRessource.Trim()='' not allowed!")
                End If

                Dim colEnglish As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value Is Nothing Then
                    colEnglish = rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value.Trim()
                End If
                Dim colGerman As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value Is Nothing Then
                    colGerman = rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value.Trim()
                End If

                If colEnglish.Trim() <> "" And colGerman.Trim() <> "" Then
                    cTranslate1.saveAutoTranslation(rSelList.IDRessource,
                                                    colGerman, colEnglish,
                                                    "", Application.Trim(),
                                                    iCounterInserted, iCounterUpdated, sProt, onlyAddRes)
                End If
            Next

            sqlLanguage1.loadAllRessources()
            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rSelList.IDRessource.Trim(), doLicense.eApp.ALL.ToString(), Application.Trim(), True)
                If resFound.Trim() <> "" Then
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = resFound
                Else
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = rSelList.IDRessource.Trim()
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.addAutoRessources: " + ex.ToString())
        End Try
    End Sub
    Public Sub addAutoRessources(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                    ByRef sProt As String,
                                    ByRef iCounterInserted As Integer, ByRef iCounterUpdated As Integer, onlyAddRes As Boolean)
        Try
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            sqlLanguage1.initControl()
            Dim cTranslate1 As New cTranslate()

            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                If rCriteria.FldShort.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rCriteria.FldShort.Trim()='' not allowed!")
                End If
                If rCriteria.IDApplication.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rCriteria.IDApplication.Trim()='' not allowed!")
                End If

                Dim colEnglish As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value Is Nothing Then
                    colEnglish = rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value.Trim()
                End If
                Dim colGerman As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value Is Nothing Then
                    colGerman = rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value.Trim()
                End If

                If colEnglish.Trim() <> "" And colGerman.Trim() <> "" Then
                    cTranslate1.saveAutoTranslation(rCriteria.FldShort,
                                                    colGerman, colEnglish,
                                                    "", rCriteria.IDApplication.Trim(),
                                                    iCounterInserted, iCounterUpdated, sProt, onlyAddRes)
                End If
            Next

            sqlLanguage1.loadAllRessources()
            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort.Trim(), doLicense.eApp.ALL.ToString(), rCriteria.IDApplication.Trim(), True)
                If resFound.Trim() <> "" Then
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = resFound
                Else
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = rCriteria.FldShort.Trim()
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.addAutoRessources: " + ex.ToString())
        End Try
    End Sub

End Class
