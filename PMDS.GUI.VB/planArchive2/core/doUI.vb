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
Imports System.Data.OleDb



Public Class doUI

    Public Shared sqlLanguageWork As QS2.core.language.sqlLanguage = Nothing
    Public Shared dsLanguageWork As QS2.core.language.dsLanguage = Nothing
    Public Shared txtResID As String = "ResID."
    Public Shared txtResIDNoTranslate As String = "ResID.NoTranslate"
    Public Shared newRessourcesAdded As Integer = 0

    Public Enum eTypUIPrefixe
        resID = 1
    End Enum

    Public gen As New General()







    Public Shared Function getRes(ByRef IDRes As String) As String
        Try
            Dim sTxtTranslated As String = QS2.core.language.sqlLanguage.getRes(IDRes.Trim(), False)
            If sTxtTranslated.Trim() <> "" Then
                Return sTxtTranslated.Trim()
            Else
                If PMDS.Global.ENV.adminSecure Then
                    doUI.addRessourceAuto(IDRes.Trim(), False, "Auto")
                    Dim newRessourcesAddedTmp As Integer = doUI.newRessourcesAdded
                    Return IDRes.Trim()
                Else
                    'Throw New Exception("doUI.getRes: No translation found for ResID for Column '" + IDRes.Trim() + "' !")
                    Return IDRes.Trim() + "(Resource missing)"
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.getRes: " + ex.ToString())
        End Try
    End Function



    Public Function run(ByVal contToTranslate As Control, ByVal components As Object,
                          ByVal tooltipManager1 As UltraToolTipManager,
                          ByRef newRessourcesAdded As Integer, ByVal doGrid As Boolean, Optional ByVal doTree As Boolean = False,
                          Optional ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String) = Nothing)
        ' ITSCont.core.SystemDb.compAutoUI.sqlTxtRes = ""
        Try
            If General.autoUI Then
                Dim doControls As Boolean = True
                If Not contToTranslate.Tag Is Nothing Then
                    If contToTranslate.Tag.ToString().Trim().ToLower().Equals(("translated").Trim.ToLower()) Then
                        doControls = False
                    End If
                End If
                If doControls Then
                    Dim Ebene As Integer = 0
                    Me.runControls_rek(contToTranslate, components, tooltipManager1, newRessourcesAdded, doGrid, doTree, lstControlNamesNoTranslate, Ebene)
                End If
                Me.runComponents_rek(contToTranslate, components, tooltipManager1, newRessourcesAdded, lstControlNamesNoTranslate)
            End If

        Catch ex As Exception
            Throw New Exception("doUI.run: " + ex.ToString())
        End Try
    End Function
    Public Function runControls_rek(ByRef contToTranslate As Control, ByRef components As Object,
                            ByRef tooltipManager1 As UltraToolTipManager,
                            ByRef newRessourcesAdded As Integer, ByVal doGrid As Boolean, ByVal doTree As Boolean,
                            ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String),
                            ByVal Ebene As Integer)
        Try
            Ebene += 1
            If Not Me.noTranslate(lstControlNamesNoTranslate, contToTranslate.Name) Then
                If Not contToTranslate.Tag Is Nothing Then
                    If contToTranslate.Tag.ToString().Trim().ToLower().Equals(("translated").Trim.ToLower()) Then
                        Exit Function
                    End If
                End If

                For Each contFound As Control In contToTranslate.Controls
                    Dim doRek As Boolean = True
                    If contFound.GetType.Equals((GetType(UltraLabel))) Then
                        Dim labelToTranslate As UltraLabel = contFound
                        If labelToTranslate.Name = "UltraLabel10" Then
                            Dim str As String = ""
                        End If
                        labelToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doLabel(labelToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(labelToTranslate, tooltipManager1)
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(Label))) Then
                        Dim labelWindowsToTranslate As Label = contFound
                        labelWindowsToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doLabelWindows(labelWindowsToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(labelWindowsToTranslate, tooltipManager1)
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(UltraCheckEditor))) Then
                        Dim checkBoxToTranslate As UltraCheckEditor = contFound
                        checkBoxToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doCheckBox(checkBoxToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(checkBoxToTranslate, tooltipManager1)
                        doRek = False

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
                        doRek = False

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
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(UltraDropDownButton))) Then
                        Dim UltraDropDownButtonToTranslate As UltraDropDownButton = contFound
                        UltraDropDownButtonToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doDropDownButton(UltraDropDownButtonToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(UltraDropDownButtonToTranslate, tooltipManager1)
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(UltraExplorerBar))) Then
                        Dim UltraExplorerBarToTranslate As UltraExplorerBar = contFound
                        UltraExplorerBarToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doUltraExplorerBar(UltraExplorerBarToTranslate, tooltipManager1, newRessourcesAdded)
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(UltraOptionSet))) Then
                        Dim UltraOptionSetToTranslate As UltraOptionSet = contFound
                        UltraOptionSetToTranslate.Text = ""
                        Me.clearToolTipForControl(contToTranslate, tooltipManager1)
                        Me.doOptionSet(UltraOptionSetToTranslate, tooltipManager1, newRessourcesAdded)
                        Me.doToolTipForControl(UltraOptionSetToTranslate, tooltipManager1)
                        doRek = False

                    ElseIf contFound.GetType.Equals((GetType(RadioButton))) Then
                        Dim RadioButtonToTranslate As RadioButton = contFound
                        RadioButtonToTranslate.Text = ""
                        If Not RadioButtonToTranslate.Tag Is Nothing Then
                            Dim TranslatedString As String = ""
                            Me.doText(RadioButtonToTranslate.Tag.ToString().Trim(), tooltipManager1, newRessourcesAdded, TranslatedString)
                            RadioButtonToTranslate.Text = TranslatedString
                            Me.doToolTipForControl(RadioButtonToTranslate, tooltipManager1)
                        End If
                        doRek = False

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

                    'Dim doRekControls As Boolean = False
                    'If contFound.GetType.Equals((GetType(Panel))) Or _
                    '     contFound.GetType.Equals((GetType(UserControl))) Or _
                    '     contFound.GetType.Equals((GetType(UltraTabControl))) Or _
                    '     contFound.GetType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
                    '     contFound.GetType.Equals((GetType(UltraTabSharedControlsPage))) Or _
                    '       contFound.GetType.Equals((GetType(UltraTabPageControl))) Or _
                    '     contFound.GetType.Equals((GetType(UltraGrid))) Or _
                    '     contFound.GetType.Equals((GetType(UltraGridBand))) Or _
                    '     contFound.GetType.Equals((GetType(UltraGroupBox))) Or _
                    '     contFound.GetType.Equals((GetType(UltraExpandableGroupBox))) Or _
                    '      contFound.GetType.Equals((GetType(Form))) Or _
                    '     contFound.GetType.Equals((GetType(UltraTab))) Or _
                    '     contFound.GetType.Equals((GetType(UltraExplorerBar))) Or _
                    '            contFound.GetType.Equals((GetType(UltraDropDownBase))) Or _
                    '     contFound.GetType.Equals((GetType(Control))) Then

                    '    doRekControls = True
                    'End If

                    'If contFound.GetType.BaseType.Equals((GetType(Panel))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UserControl))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraTabControl))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraGridBagLayoutPanel))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraTabSharedControlsPage))) Or _
                    '    contFound.GetType.BaseType.Equals((GetType(UltraTabPageControl))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraGrid))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraGridBand))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraGroupBox))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraExpandableGroupBox))) Or _
                    '    contFound.GetType.BaseType.Equals((GetType(Form))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraTab))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(UltraExplorerBar))) Or _
                    '              contFound.GetType.BaseType.Equals((GetType(UltraDropDownBase))) Or _
                    '     contFound.GetType.BaseType.Equals((GetType(Control))) Then

                    '    doRekControls = True
                    'End If
                    'If doRekControls Then
                    '    Me.runControls_rek(contFound, components, tooltipManager1, newRessourcesAdded, doGrid, doTree, lstControlNamesNoTranslate, Ebene)
                    'End If

                    If doRek Then
                        Me.runControls_rek(contFound, components, tooltipManager1, newRessourcesAdded, doGrid, doTree, lstControlNamesNoTranslate, Ebene)
                    End If

                Next

                If contToTranslate.GetType.Equals((GetType(Panel))) Or
                    contToTranslate.GetType.Equals((GetType(UserControl))) Or
                    contToTranslate.GetType.Equals((GetType(UltraTabControl))) Or
                    contToTranslate.GetType.Equals((GetType(UltraGridBagLayoutPanel))) Or
                             contToTranslate.GetType.Equals((GetType(UltraDropDownBase))) Or
                    contToTranslate.GetType.Equals((GetType(Control))) Then

                    contToTranslate.Tag = "translated"
                ElseIf contToTranslate.GetType.BaseType.Equals((GetType(Panel))) Or
                     contToTranslate.GetType.BaseType.Equals((GetType(UserControl))) Or
                     contToTranslate.GetType.BaseType.Equals((GetType(UltraTabControl))) Or
                     contToTranslate.GetType.BaseType.Equals((GetType(UltraGridBagLayoutPanel))) Or
                  contToTranslate.GetType.BaseType.Equals((GetType(UltraDropDownBase))) Or
                     contToTranslate.GetType.BaseType.Equals((GetType(Control))) Then

                    contToTranslate.Tag = "translated"
                Else
                    If Ebene = 0 Or Ebene = 1 Then
                        Dim str As String = ""
                    End If

                End If
            Else
                Dim str As String = ""
            End If

        Catch ex As Exception
            Throw New Exception("doUI.runControls_rek: " + ex.ToString())
        End Try
    End Function
    Public Function runComponents_rek(ByRef contToTranslate As Control, ByRef components As Object,
                          ByRef tooltipManager1 As UltraToolTipManager,
                          ByRef newRessourcesAdded As Integer,
                          ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String))
        Try
            If Not components Is Nothing Then
                Dim Container1 As New System.ComponentModel.Container
                Container1 = components
                For Each componentFound As Object In Container1.Components

                    If componentFound.GetType.Equals((GetType(UltraToolbarsManager))) Then
                        Dim UltraToolbarsManagerToTranslate As UltraToolbarsManager = componentFound
                        Me.doToolbar(UltraToolbarsManagerToTranslate, tooltipManager1, newRessourcesAdded)
                        General.lstToolbars.Add(UltraToolbarsManagerToTranslate)

                        UltraToolbarsManagerToTranslate.TouchEnabled = General.TouchToolBarManager

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

        Catch ex As Exception
            Throw New Exception("doUI.runComponents_rek: " + ex.ToString())
        End Try
    End Function



    Public Function doText(ByRef tagToTranslate As String, ByVal tooltipManager1 As UltraToolTipManager,
                               ByRef newRessourcesAdded As Integer, ByRef TranslatedString As String)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not tagToTranslate Is Nothing Then
                If Me.analyseTag(tagToTranslate.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        TranslatedString = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doText: " + ex.ToString())
        End Try
    End Function
    Public Function doLabel(ByVal labelToTranslate As UltraLabel, ByVal tooltipManager1 As UltraToolTipManager,
                                   ByRef newRessourcesAdded As Integer)
        Try
            If labelToTranslate.Name.Trim().ToLower().Equals(("lblInfoFondsChanged").Trim().ToLower()) Then
                Exit Function
            End If

            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not labelToTranslate.Tag Is Nothing Then
                If Me.analyseTag(labelToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        labelToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doLabel: " + ex.ToString())
        End Try
    End Function
    Public Function doLabelWindows(ByVal WindowslabelToTranslate As Label, ByVal tooltipManager1 As UltraToolTipManager,
                                   ByRef newRessourcesAdded As Integer)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not WindowslabelToTranslate.Tag Is Nothing Then
                If Me.analyseTag(WindowslabelToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        WindowslabelToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doLabelWindows: " + ex.ToString())
        End Try
    End Function
    Public Function doButton(ByVal ButtonToTranslate As UltraButton, ByVal tooltipManager1 As UltraToolTipManager,
                               ByRef newRessourcesAdded As Integer)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""

            If Not ButtonToTranslate.Tag Is Nothing Then
                If Me.analyseTag(ButtonToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        ButtonToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doButton: " + ex.ToString())
        End Try
    End Function

    Public Function doDropDownButton(ByVal DropDownButtonToTranslate As UltraDropDownButton, ByVal tooltipManager1 As UltraToolTipManager,
                           ByRef newRessourcesAdded As Integer)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""

            If Not DropDownButtonToTranslate.Tag Is Nothing Then
                If Me.analyseTag(DropDownButtonToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        DropDownButtonToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doDropDownButton: " + ex.ToString())
        End Try
    End Function
    Public Function doCheckBox(ByVal checkBoxToTranslate As UltraCheckEditor, ByVal tooltipManager1 As UltraToolTipManager,
                               ByRef newRessourcesAdded As Integer)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not checkBoxToTranslate.Tag Is Nothing Then
                If Me.analyseTag(checkBoxToTranslate.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        checkBoxToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doCheckBox: " + ex.ToString())
        End Try
    End Function
    Public Function doGroupBox(ByVal groupBoxToTranslate As UltraGroupBox, ByVal tooltipManager1 As UltraToolTipManager,
                             ByRef newRessourcesAdded As Integer)
        Try
            Dim IDUI As String = ""
            Dim eTypUIPrefixe As New eTypUIPrefixe()
            If Not groupBoxToTranslate.Tag Is Nothing Then
                If Me.analyseTag(groupBoxToTranslate.Tag.ToString().Trim(), IDUI, eTypUIPrefixe) Then
                    If eTypUIPrefixe = eTypUIPrefixe.resID Then
                        groupBoxToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doGroupBox: " + ex.ToString())
        End Try
    End Function
    Public Function doExpandableGroupBox(ByVal ExpandableGroupBoxToTranslate As UltraExpandableGroupBox, ByVal tooltipManager1 As UltraToolTipManager,
                         ByRef newRessourcesAdded As Integer)
        Try
            Dim IDUI As String = ""
            Dim eTypUIPrefixe As New eTypUIPrefixe()
            If Not ExpandableGroupBoxToTranslate.Tag Is Nothing Then
                If Me.analyseTag(ExpandableGroupBoxToTranslate.Tag.ToString().Trim(), IDUI, eTypUIPrefixe) Then
                    If eTypUIPrefixe = eTypUIPrefixe.resID Then
                        ExpandableGroupBoxToTranslate.Text = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doExpandableGroupBox: " + ex.ToString())
        End Try
    End Function
    Public Function doGrid(ByVal gridToTranslate As UltraGrid, ByVal tooltipManager1 As UltraToolTipManager,
                                  ByRef newRessourcesAdded As Integer)
        Try
            If Not gridToTranslate.Tag Is Nothing Then
                Dim TranslatedString As String = ""
                Me.doText(gridToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
                gridToTranslate.Text = TranslatedString
                gridToTranslate.Tag = Nothing
            End If

            gridToTranslate.DisplayLayout.GroupByBox.Prompt = doUI.getRes("DragAColumnHeaderToGroupBy")

            Me.doBand(gridToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

        Catch ex As Exception
            Throw New Exception("doUI.doGrid: " + ex.ToString())
        End Try
    End Function
    Public Function doUltraDropDown(ByVal UltraDropDownToTranslate As UltraDropDown, ByVal tooltipManager1 As UltraToolTipManager,
                              ByRef newRessourcesAdded As Integer)
        Try
            If Not UltraDropDownToTranslate.Tag Is Nothing Then
                Dim TranslatedString As String = ""
                Me.doText(UltraDropDownToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
                UltraDropDownToTranslate.Text = TranslatedString
                UltraDropDownToTranslate.Tag = Nothing
            End If

            UltraDropDownToTranslate.DisplayLayout.GroupByBox.Prompt = doUI.getRes("DragAColumnHeaderToGroupBy")

            Me.doBand(UltraDropDownToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

        Catch ex As Exception
            Throw New Exception("doUI.doUltraDropDown: " + ex.ToString())
        End Try
    End Function
    Public Function doUltraCombo(ByVal UltraComboToTranslate As UltraCombo, ByVal tooltipManager1 As UltraToolTipManager,
                              ByRef newRessourcesAdded As Integer)
        Try
            If Not UltraComboToTranslate.Tag Is Nothing Then
                Dim TranslatedString As String = ""
                Me.doText(UltraComboToTranslate.Tag.ToString(), tooltipManager1, newRessourcesAdded, TranslatedString)
                UltraComboToTranslate.Text = TranslatedString
                UltraComboToTranslate.Tag = Nothing
            End If

            UltraComboToTranslate.DisplayLayout.GroupByBox.Prompt = doUI.getRes("DragAColumnHeaderToGroupBy")

            Me.doBand(UltraComboToTranslate.DisplayLayout.Bands, tooltipManager1, newRessourcesAdded)

        Catch ex As Exception
            Throw New Exception("doUI.doUltraCombo: " + ex.ToString())
        End Try
    End Function
    Public Function doBand(ByVal BandsCollectionToTranslate As BandsCollection, ByVal tooltipManager1 As UltraToolTipManager,
                              ByRef newRessourcesAdded As Integer)
        Try
            For Each bandFound As UltraGridBand In BandsCollectionToTranslate
                Dim bTranslateBand As Boolean = True
                If Not bandFound.Tag Is Nothing Then
                    If bandFound.Tag.ToString().Trim().ToLower().Equals(("translated").Trim().ToLower()) Then
                        bTranslateBand = False
                    End If
                End If
                If bTranslateBand Then
                    For Each colFound As UltraGridColumn In bandFound.Columns
                        If Not colFound.IsChaptered And Not colFound.IsGroupByColumn Then
                            colFound.Header.Caption = ""
                            colFound.Header.ToolTipText = ""
                            Try
                                colFound.Header.Caption = doUI.getRes(bandFound.Key + "." + colFound.Key)
                                colFound.Header.ToolTipText = colFound.Header.Caption
                            Catch ex As Exception
                                If PMDS.Global.ENV.adminSecure Then
                                    doUI.addRessourceAuto(bandFound.Key + "." + colFound.Key, False, "Auto")
                                Else
                                    Throw New Exception("AutoUI.doBand: TranslateGridBand - ResID for Column '" + bandFound.Key + "." + colFound.Key + "' !")
                                End If
                            End Try
                        End If
                    Next
                    bandFound.Tag = "translated"
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doBand: " + ex.ToString())
        End Try
    End Function
    Public Function doTabs(ByVal UltraTaTranslate As UltraTabControl, ByVal tooltipManager1 As UltraToolTipManager,
                                 ByRef newRessourcesAdded As Integer)
        Try
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
                            tabFound.Text = doUI.getRes(IDUI)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doTabs: " + ex.ToString())
        End Try
    End Function
    Public Function doContextMenüStrip(ByVal ToolStripItemCollectionToTranslate As ToolStripItemCollection, ByVal tooltipManager1 As UltraToolTipManager,
                              ByRef newRessourcesAdded As Integer)
        Try
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
                                ToolStripItem1.Text = doUI.getRes(IDUI)
                            End If
                        End If
                    End If

                    If ToolStripItem1.GetType.Equals((GetType(ToolStripMenuItem))) Then
                        Dim ToolStripMenuItem1 As ToolStripMenuItem = ToolStripItem1
                        Me.doContextMenüStrip(ToolStripMenuItem1.DropDownItems, tooltipManager1, newRessourcesAdded)
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doContextMenüStrip: " + ex.ToString())
        End Try
    End Function

    Public Function doToolbar(ByVal UltraToolbarsManagerToTranslate As UltraToolbarsManager, ByVal tooltipManager1 As UltraToolTipManager,
                                 ByRef newRessourcesAdded As Integer)
        Try
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

        Catch ex As Exception
            Throw New Exception("doUI.doToolbar: " + ex.ToString())
        End Try
    End Function
    Public Function doToolBase(ByVal ToolBaseFound As ToolBase, ByVal tooltipManager1 As UltraToolTipManager,
                            ByRef newRessourcesAdded As Integer)
        Try
            ToolBaseFound.SharedProps.Caption = ""
            ToolBaseFound.SharedProps.ToolTipTitle = ""
            ToolBaseFound.SharedProps.ToolTipText = ""
            ToolBaseFound.SharedProps.ToolTipTextFormatted = ""

            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""
            If Not ToolBaseFound.Tag Is Nothing Then
                If Me.analyseTag(ToolBaseFound.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                    If TypUIPrefixe = eTypUIPrefixe.resID Then
                        ToolBaseFound.SharedProps.Caption = doUI.getRes(IDUI)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doUI.doToolBase: " + ex.ToString())
        End Try
    End Function

    Public Function doOptionSet(ByVal UltraOptionSetToTranslate As UltraOptionSet, ByVal tooltipManager1 As UltraToolTipManager,
                                  ByRef newRessourcesAdded As Integer)
        Try
            For Each ValueListItem1 As ValueListItem In UltraOptionSetToTranslate.Items
                ValueListItem1.DisplayText = ""
                If Not ValueListItem1.Tag Is Nothing Then
                    Dim TypUIPrefixe As New eTypUIPrefixe()
                    Dim IDUI As String = ""
                    If Not ValueListItem1.Tag Is Nothing Then
                        If Me.analyseTag(ValueListItem1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                            If TypUIPrefixe = eTypUIPrefixe.resID Then
                                ValueListItem1.DisplayText = doUI.getRes(IDUI)
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doOptionSet: " + ex.ToString())
        End Try
    End Function
    Public Function doUltraExplorerBar(ByVal UltraExplorerBarToTranslate As UltraExplorerBar, ByVal tooltipManager1 As UltraToolTipManager,
                       ByRef newRessourcesAdded As Integer)
        Try
            Dim TypUIPrefixe As New eTypUIPrefixe()
            Dim IDUI As String = ""

            For Each UltraExplorerBarGrp As UltraExplorerBarGroup In UltraExplorerBarToTranslate.Groups
                UltraExplorerBarGrp.Text = ""
                UltraExplorerBarGrp.ToolTipText = ""

                If Not UltraExplorerBarGrp.Tag Is Nothing Then
                    If Me.analyseTag(UltraExplorerBarGrp.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                        If TypUIPrefixe = eTypUIPrefixe.resID Then
                            UltraExplorerBarGrp.Text = doUI.getRes(IDUI)
                        End If
                    End If
                End If

                For Each UltraExplorerBarItem1 As UltraExplorerBarItem In UltraExplorerBarGrp.Items
                    UltraExplorerBarItem1.Text = ""
                    UltraExplorerBarItem1.ToolTipText = ""

                    If Not UltraExplorerBarItem1.Tag Is Nothing Then
                        If Me.analyseTag(UltraExplorerBarItem1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                            If TypUIPrefixe = eTypUIPrefixe.resID Then
                                UltraExplorerBarItem1.Text = doUI.getRes(IDUI)
                            End If
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doUltraExplorerBar: " + ex.ToString())
        End Try
    End Function
    Public Function doTree(ByVal TreeNodesCollectionToTranslate As TreeNodesCollection, ByVal tooltipManager1 As UltraToolTipManager,
                    ByRef newRessourcesAdded As Integer)
        Try
            For Each UltraTreeNode1 As UltraTreeNode In TreeNodesCollectionToTranslate
                UltraTreeNode1.Text = ""

                Dim TypUIPrefixe As New eTypUIPrefixe()
                Dim IDUI As String = ""

                If Not UltraTreeNode1.Tag Is Nothing Then
                    If Me.analyseTag(UltraTreeNode1.Tag.ToString().Trim(), IDUI, TypUIPrefixe) Then
                        If TypUIPrefixe = eTypUIPrefixe.resID Then
                            UltraTreeNode1.Text = doUI.getRes(IDUI)
                        End If
                    End If
                End If

                Me.doTree(UltraTreeNode1.Nodes, tooltipManager1, newRessourcesAdded)
            Next

        Catch ex As Exception
            Throw New Exception("doUI.doTree: " + ex.ToString())
        End Try
    End Function




    Public Function analyseTag(ByRef sTag As String, ByRef keyReturn As String,
                                     ByRef TypUIPrefixeReturn As eTypUIPrefixe) As Boolean

        Try
            If sTag.ToString().Trim() <> "" Then
                Dim tagInfo As String = sTag.ToString().Trim()
                If tagInfo.Length >= 6 AndAlso tagInfo.Substring(0, doUI.txtResID.Length).ToLower() = doUI.txtResID.ToLower() Then
                    keyReturn = tagInfo.Substring(doUI.txtResID.Length, tagInfo.Length - doUI.txtResID.Length)
                    TypUIPrefixeReturn = eTypUIPrefixe.resID
                    Return True

                Else
                    Dim sExcep As String = "analyseTag: Wrong Prefix in Control.Tag for auto-UI! sTag='" + sTag.Trim() + "'"
                    Throw New Exception(sExcep.Trim())
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
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Function
    Public Function noTranslate(ByVal lstControlNamesNoTranslate As System.Collections.Generic.List(Of String),
                                                ByVal actuellControlName As String) As Boolean
        Try
            If Not lstControlNamesNoTranslate Is Nothing Then
                For Each contFoundNotTranslate As String In lstControlNamesNoTranslate
                    If contFoundNotTranslate = actuellControlName Then
                        Return True
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception("doUI.noTranslate: " + ex.ToString())
        End Try
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
                            lstIDRes = PMDS.Global.generic.readStrVariables(tagInfo)
                        End If

                        Dim TypUIPrefixe As New eTypUIPrefixe()
                        Dim IDUI As String = ""
                        'Dim UltraToolTipInfo1 As New UltraToolTipInfo()
                        'UltraToolTipInfo1.Tag = tagInfo

                        If lstIDRes.Count = 1 Then
                            If Me.analyseTag(lstIDRes(0).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTitle = ""
                                UltraToolTipInfoFound.ToolTipTextFormatted = doUI.getRes(IDUI)

                            End If
                            'tooltipManager1.SetUltraToolTip(ControlToTranslate, UltraToolTipInfo1)

                        ElseIf lstIDRes.Count = 2 Then
                            If Me.analyseTag(lstIDRes(0).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTitle = doUI.getRes(IDUI)
                            End If
                            If Me.analyseTag(lstIDRes(1).Trim(), IDUI, TypUIPrefixe) Then
                                UltraToolTipInfoFound.ToolTipTextFormatted = doUI.getRes(IDUI)
                            End If

                            'tooltipManager1.SetUltraToolTip(ControlToTranslate, UltraToolTipInfoFound)
                        Else
                            Throw New Exception("doToolTipForControl: lstIDRes.Count is > 2 for control '" + ControlToTranslate.Name + "'!")
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Function

    Public Sub clearToolTipForControl(ByVal contToTranslate As Control, ByVal tooltipManager1 As UltraToolTipManager)
        Try
            If Not tooltipManager1 Is Nothing Then
                'Dim infoToolTip As New UltraToolTipInfo()
                'infoToolTip.ToolTipTitle = ""
                'infoToolTip.ToolTipText = ""
                'tooltipManager1.SetUltraToolTip(contToTranslate, infoToolTip)
            End If

        Catch ex As Exception
            Throw New Exception("doUI.clearToolTipForControl: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function addRessourceAuto(ByVal IDRes As String, WihtMsgBox As Boolean, ByRef CreatedUser As String)
        Try
            If doUI.sqlLanguageWork Is Nothing Then
                doUI.dsLanguageWork = New QS2.core.language.dsLanguage()
                doUI.sqlLanguageWork = New QS2.core.language.sqlLanguage()
                doUI.sqlLanguageWork.initControl()
            End If

            doUI.dsLanguageWork.Clear()
            doUI.sqlLanguageWork.getLanguage(System.Guid.NewGuid().ToString(), doUI.dsLanguageWork, QS2.core.language.sqlLanguage.eTypSelLang.IDRes, QS2.core.Enums.eResourceType.Label, "PMDS")
            If Not doUI.checkRessourceExists(IDRes.Trim()) Then
                Dim rNewRes As QS2.core.language.dsLanguage.RessourcenRow = doUI.sqlLanguageWork.newRowLanguage(doUI.dsLanguageWork, IDRes.Trim(), IDRes.Trim(), "Auto", "PMDS", "ALL", QS2.core.Enums.eResourceType.Label, QS2.core.Enums.eTypeSub.Supervisor, "")
                rNewRes.German = IDRes.Trim()
                rNewRes.English = IDRes.Trim()
                rNewRes.Type = General.eControlType.Label.ToString()
                rNewRes.TypeSub = "Admin"
                rNewRes.IDApplication = "ALL"                   'General.eApplications.PMDS.ToString()
                rNewRes.IDParticipant = "ALL"
                rNewRes.CreatedUser = "Auto"
                rNewRes.IDLanguageUser = "ALL"
                rNewRes.User = ""
                Dim dNow As DateTime = DateTime.Now
                rNewRes.Created = dNow
                rNewRes.LastChange = dNow

                doUI.sqlLanguageWork.daLanguage.Update(doUI.dsLanguageWork.Ressourcen)
                doUI.newRessourcesAdded += 1

                If WihtMsgBox Then
                    MsgBox("Auto-Ressource for Translation: '" + IDRes + "' added!", MsgBoxStyle.Information, "addRessourceAuto")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("addRessourceAuto: " + ex.ToString())
        End Try
    End Function
    Public Shared Function checkRessourceExists(ByVal idRes As String) As Boolean
        Try
            Dim database As New db()
            Dim dt As New DataTable()
            Dim cmd As New OleDb.OleDbCommand()

            Dim da As New OleDbDataAdapter()
            cmd.CommandText = "Select * from qs2.Ressourcen where IDRes='" + idRes.ToString() + "' and IDLanguageUser='ALL' and (IDApplication='PMDS' or IDApplication='ALL') and IDParticipant='ALL' and Type='Label' "
            cmd.Connection = database.getConnDB()
            da.SelectCommand = cmd
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                Return True
            ElseIf dt.Rows.Count = 0 Then
                Return False
            Else
                Throw New Exception("compAutoUI.checkRessourceExists: IDRes '" + idRes.Trim() + "' exists - not possible!")
            End If

        Catch ex As Exception
            Throw New Exception("compAutoUI.checkRessourceExists: " + ex.ToString())
        End Try
    End Function


    Public Shared Function doMessageBox2(ByVal IDResText As String, ByVal IDResTitle As String, ByVal postSignText As String) As MsgBoxResult
        Try
            If IDResTitle.Trim() = "" Then
                IDResTitle = "PMDS"
            End If
            Return MsgBox(doUI.getRes(IDResText) + "" + postSignText, MsgBoxStyle.Information, doUI.getRes(IDResTitle))

        Catch ex As Exception
            Throw New Exception("doMessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function doMessageBox3(ByVal IDResText As String, ByVal IDResTitle As String, ByVal MsgBoxStyle As MsgBoxStyle, ByVal postSignText As String) As MsgBoxResult
        Try
            If IDResTitle.Trim() = "" Then
                IDResTitle = "PMDS"
            End If
            Return MsgBox(doUI.getRes(IDResText) + "" + postSignText, MsgBoxStyle, doUI.getRes(IDResTitle))

        Catch ex As Exception
            Throw New Exception("doMessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function doMessageBoxTranslated(ByVal txt As String, ByVal title As String, ByVal MsgBoxStyle As MsgBoxStyle) As MsgBoxResult
        Try
            If title.Trim() = "" Then
                title = doUI.getRes("PMDS")
            End If
            Return MsgBox(txt, MsgBoxStyle, title)

        Catch ex As Exception
            Throw New Exception("doMessageBoxTranslated: " + ex.ToString())
        End Try
    End Function
    Public Shared Function doMessageBoxTranslated(ByVal txt As String, ByVal title As String, ByVal postSignText As String) As MsgBoxResult
        Try
            If title.Trim() = "" Then
                title = doUI.getRes("PMDS")
            End If
            Return MsgBox(txt + "" + postSignText, MsgBoxStyle.Information, title)

        Catch ex As Exception
            Throw New Exception("doMessageBoxTranslated: " + ex.ToString())
        End Try
    End Function

End Class
