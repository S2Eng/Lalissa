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
Imports QS2.core.vb
Imports QS2.core
Imports S2Extensions

Public Class ControlManagment

    Public Shared defaultParticipant As String = QS2.core.license.doLicense.eApp.ALL.ToString()
    Public Shared iCounterDepthControlForIDRes As Integer = 5
    Public Shared prefControlNameAutoAdded As String = "AddedFromQS2"
    Public Shared prefixNoRes As String = "NR-"

    Public Shared dsControls As New dsControls()
    Public Shared compRessourcesWork As New QS2.core.language.sqlLanguage()

    Public Shared dsLanguageUpdate As QS2.core.language.dsLanguage = Nothing
    Public Shared sqlLanguageUpdate As QS2.core.language.sqlLanguage = Nothing

    Public Enum eTypeRessourcesRun
        DesktopManagement = 0
        ProductiveFull = 1
        ProductiveSmall = 2
        Off = 10
    End Enum
    Public Enum eControlGroup
        MainSystem = 0
        Booking = 1
    End Enum

    Public delOnSaveLayoutClick As onSaveLayoutClick
    Public Delegate Sub onSaveLayoutClick(IDQuickFilter As System.Guid, ByVal rLayout As QS2.core.vb.dsLayout.LayoutRow)



    Public Shared Sub LoadControlDesigner(IDRes As String)
        Try

        Catch ex As Exception
            Throw New Exception("ControlManagment.LoadControlDesigner: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function openLayoutmanager(ByRef grid As BaseGrid, sKey As String) As Boolean
        Try
            Dim frmLayoutManager1 As New core.vb.frmLayoutManager()
            frmLayoutManager1.ContLayoutGrid1.cLayoutManager1._LayoutKey = sKey.Trim()
            frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.gridUIToSave = grid
            frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = core.vb.cLayoutManager.eTypLayoutGrid.onlyFirstBand
            frmLayoutManager1.initControl(sKey.Trim(), False, "", True)
            frmLayoutManager1.ContLayoutGrid1.loadData(sKey.Trim(), "", True, True, False)
            frmLayoutManager1.ShowDialog()

        Catch ex As Exception
            Throw New Exception("HandleEvent.DoActionForGrid: " + ex.ToString())
        End Try
    End Function

    Public Sub doControl(ByRef IDRes As String, ByRef Description As String, ByRef cont As Control, ByRef components As Object,
                            ByVal ControlGroup As eControlGroup,
                            ByRef iControlsDone As Integer,
                            ByRef rActControl As dsControls.ControlsRow, ByRef ContextMenuStrip As ContextMenuStrip,
                            ByVal ResourceTypeToInsertxyxy As core.Enums.eResourceType,
                            ByRef TxtEnglish As String, ByRef TxtGerman As String,
                            ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow,
                            ByRef doContextMenü As Boolean, ByRef IsStandardControl As Boolean,
                            ByRef InfoControl As doBaseElements.cInfoControl, ByRef DoIDResAuto As Boolean,
                            ByRef ExtendedView As Boolean)
        Try
            Dim ModusDesktopManagment As Boolean = False
            Dim ProductiveFull As Boolean = False
            If Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.DesktopManagement) Then
                ModusDesktopManagment = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveFull) Then
                ProductiveFull = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveSmall) Then
                ProductiveFull = False
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.Off) Then
                Exit Sub
            End If

            Dim IDResKeyForControlDB As String = ""
            If DoIDResAuto Then
                If Not IsStandardControl Then
                    ControlManagment.getIDREsForControlxy(cont, IDResKeyForControlDB, Description)
                    IDRes = IDResKeyForControlDB
                Else
                    ControlManagment.getIDREsForControlxy(cont, IDResKeyForControlDB, Description)
                    IDRes = IDResKeyForControlDB
                End If
            Else
                IDResKeyForControlDB = IDRes.Trim()
            End If
            If IDRes.Trim() <> "" Then
                rActControl = Me.getRowControlFromDb(IDResKeyForControlDB, cont, ControlManagment.dsControls)
                If rActControl Is Nothing Then
                    rActControl = Me.addControl(IDResKeyForControlDB, cont, ControlManagment.dsControls)
                    rActControl.IsStandardControl = IsStandardControl
                    rActControl.Description = Description
                Else
                    Dim str As String = ""
                End If

                Dim TextControlOnUIActuell As String = ""
                If ProductiveFull Or ModusDesktopManagment Then
                    Me.doResAuto(IDRes, Description, cont, components, ControlGroup,
                                        iControlsDone, rActControl, core.Enums.eResourceType.Label, ContextMenuStrip, TxtEnglish, TxtGerman,
                                        rRes, IsStandardControl, ModusDesktopManagment,
                                        TextControlOnUIActuell)
                    rActControl.ControlText = TextControlOnUIActuell
                End If

                If Not cont.GetType.Equals(GetType(BaseTabControl)) Then
                    Dim HandleEvent1 As New HandleEvent(components, cont, iControlsDone, IDRes, Description,
                                                    ContextMenuStrip, rRes, IsStandardControl, "", rActControl, TextControlOnUIActuell,
                                                     ProductiveFull,
                                                     InfoControl, Me, DoIDResAuto, ExtendedView)
                End If

                rActControl.ActionPerformed = True
            Else
                Dim bIsTabControl As Boolean = True
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.doControl: " + ex.ToString())
        End Try
    End Sub

    Private Function doResAuto(ByRef IDRes As String, ByRef Description As String, ByRef cont As Control, ByRef components As Object,
                            ByRef ControlGroup As eControlGroup,
                            ByRef iControlsDone As Integer,
                            ByRef rActControl As dsControls.ControlsRow,
                            ByRef ResourceTypeToLoad As core.Enums.eResourceType,
                            ByRef ContextMenuStrip As ContextMenuStrip,
                            ByRef TxtEnglish As String, ByRef TxtGerman As String,
                            ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow, ByRef IsStandardControlxy As Boolean,
                            ByRef ModusDesktopManagmentxy As Boolean,
                            ByRef TextControlOnUIActuell As String) As Boolean
        Try
            If cont.GetType.Equals((GetType(BaseComboEditor))) Or cont.GetType.Equals((GetType(BaseDateTimeEditor))) Or
                    cont.GetType.Equals((GetType(BaseDateTimeEditorWin))) Or cont.GetType.Equals((GetType(BaseMaskEdit))) Or
                    cont.GetType.Equals((GetType(BaseNumericEditor))) Or cont.GetType.Equals((GetType(BaseDateTimeEditor))) Or
                    cont.GetType.Equals((GetType(BaseMaskEdit))) Then

                Return True
            End If

            If ControlManagment.sqlLanguageUpdate Is Nothing Then
                ControlManagment.sqlLanguageUpdate = New core.language.sqlLanguage()
                ControlManagment.dsLanguageUpdate = New core.language.dsLanguage()
                ControlManagment.sqlLanguageUpdate.initControl()
                ControlManagment.sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), ControlManagment.dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, Settings._Application)
            End If

            If cont.GetType.Equals((GetType(BaseOptionSet))) Then
                Dim optionSet As BaseOptionSet = cont
                For Each itmValList As Infragistics.Win.ValueListItem In optionSet.Items
                    ControlManagment.dsLanguageUpdate.Clear()
                    Dim IDResFound As Boolean = False
                    Dim translatedTxt As String = ""
                    Dim IDResTmp As String = IDRes + "_" + itmValList.DataValue.ToString()
                    Me.getRes(IDResTmp, IDResFound, translatedTxt, ControlGroup, ResourceTypeToLoad, rRes)
                    If rRes Is Nothing Then
                        If Me.isControlForTxt(cont) Then
                            If Not itmValList.DisplayText Is Nothing Then
                                TxtGerman = itmValList.DisplayText.Trim()
                            Else
                                TxtGerman = itmValList.DataValue.Trim()
                            End If
                        End If

                        If Settings._AutoAddNewRessources Then
                            Me.addNewResAuto(IDResTmp, Description, cont, components, ControlGroup, iControlsDone,
                                                rActControl, ResourceTypeToLoad, ContextMenuStrip, TxtEnglish, TxtGerman, rRes, IsStandardControlxy, "")
                            translatedTxt = TxtGerman
                        End If

                        'End If
                    End If
                    Me.setResControl(IDResTmp, IDResFound, Description, cont, components,
                                        ControlGroup, iControlsDone, rActControl, ResourceTypeToLoad,
                                        ContextMenuStrip, TxtEnglish, TxtGerman, rRes, translatedTxt, IsStandardControlxy,
                                        TextControlOnUIActuell, Nothing, itmValList)
                Next

                Return True

            ElseIf cont.GetType.Equals((GetType(BaseTabControl))) Then
                Dim tabCont As BaseTabControl = cont
                For Each tab As UltraTab In tabCont.Tabs
                    ControlManagment.dsLanguageUpdate.Clear()
                    Dim IDResFound As Boolean = False
                    Dim translatedTxt As String = ""
                    Dim IDResTmp As String = IDRes + "_" + tab.Key.ToString()
                    Me.getRes(IDResTmp, IDResFound, translatedTxt, ControlGroup, ResourceTypeToLoad, rRes)
                    If rRes Is Nothing Then
                        'If ModusDesktopManagment Then
                        If Me.isControlForTxt(cont) Then
                            TxtGerman = tab.Text.Trim()
                        End If

                        If Settings._AutoAddNewRessources Then
                            Me.addNewResAuto(IDResTmp, Description, cont, components, ControlGroup, iControlsDone,
                                                rActControl, ResourceTypeToLoad, ContextMenuStrip, TxtEnglish, TxtGerman, rRes, IsStandardControlxy, "")
                            translatedTxt = TxtGerman
                        End If

                        'End If
                    End If
                    Me.setResControl(IDResTmp, IDResFound, Description, cont, components,
                                        ControlGroup, iControlsDone, rActControl, ResourceTypeToLoad,
                                        ContextMenuStrip, TxtEnglish, TxtGerman, rRes, translatedTxt, IsStandardControlxy,
                                        TextControlOnUIActuell, tab, Nothing)
                Next

                Return True

            Else
                ControlManagment.dsLanguageUpdate.Clear()
                Dim IDResFound As Boolean = False
                Dim translatedTxt As String = ""
                Me.getRes(IDRes, IDResFound, translatedTxt, ControlGroup, ResourceTypeToLoad, rRes)
                If rRes Is Nothing Then
                    'If ModusDesktopManagment Then
                    If Me.isControlForTxt(cont) Then
                        TxtGerman = cont.Text.Trim()
                    End If

                    If Settings._AutoAddNewRessources Then
                        Me.addNewResAuto(IDRes, Description, cont, components, ControlGroup, iControlsDone,
                                            rActControl, ResourceTypeToLoad, ContextMenuStrip, TxtEnglish, TxtGerman, rRes, IsStandardControlxy, "")
                        translatedTxt = TxtGerman
                    End If

                    'End If
                End If
                Me.setResControl(IDRes, IDResFound, Description, cont, components,
                                    ControlGroup, iControlsDone, rActControl, ResourceTypeToLoad,
                                    ContextMenuStrip, TxtEnglish, TxtGerman, rRes, translatedTxt, IsStandardControlxy,
                                    TextControlOnUIActuell, Nothing, Nothing)
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.doResAuto: " + ex.ToString())
        End Try
    End Function
    Private Function setResControl(ByRef IDRes As String, ByRef IDResFound As Boolean, ByRef Description As String, ByRef cont As Control, ByRef components As Object,
                                    ByRef ControlGroup As eControlGroup,
                                    ByRef iControlsDone As Integer,
                                    ByRef rActControl As dsControls.ControlsRow,
                                    ByRef ResourceTypeToLoad As core.Enums.eResourceType,
                                    ByRef ContextMenuStrip As ContextMenuStrip,
                                    ByRef TxtEnglish As String, ByRef TxtGerman As String,
                                    ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow,
                                    ByRef translatedTxt As String, ByRef IsStandardControlxy As Boolean,
                                    ByRef TextControlOnUIActuell As String,
                                    ByRef tab As UltraTab, ByRef ValueListItem As Infragistics.Win.ValueListItem) As Boolean
        Try
            If (Me.isControlForTxt(cont)) Then
                If rRes Is Nothing Then
                    Try
                        If Not tab Is Nothing Then
                            TxtGerman = tab.Text.Trim()
                            tab.Text = ""    'ControlManagment.prefixNoRes + cont.Text.Trim()
                            TextControlOnUIActuell = ""

                        ElseIf Not ValueListItem Is Nothing Then
                            TxtGerman = tab.Text.Trim()
                            ValueListItem.DisplayText = ""    'ControlManagment.prefixNoRes + cont.Text.Trim()
                            TextControlOnUIActuell = ""

                        Else
                            TxtGerman = cont.Text.Trim()
                            cont.Text = ""    'ControlManagment.prefixNoRes + cont.Text.Trim()
                            TextControlOnUIActuell = ""
                        End If

                    Catch ex As Exception
                        Throw New Exception("setResControl: " + ex.ToString())
                    End Try
                Else
                    Try
                        If Settings._DoNotShowRessources Then
                            translatedTxt = ""     '"---"
                        End If
                        If Not tab Is Nothing Then
                            tab.Text = translatedTxt
                            TextControlOnUIActuell = translatedTxt
                            IDResFound = True

                        ElseIf Not ValueListItem Is Nothing Then
                            ValueListItem.DisplayText = translatedTxt
                            TextControlOnUIActuell = translatedTxt
                            IDResFound = True
                        Else
                            cont.Text = translatedTxt
                            TextControlOnUIActuell = translatedTxt
                            IDResFound = True
                        End If

                    Catch ex As Exception
                        Throw New Exception("setResControl: " + ex.ToString())
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("doRessources.setResControl: " + ex.ToString())
        End Try
    End Function

    Private Function getRes(ByRef IDRes As String, ByRef IDResFound As Boolean, ByRef translatedTxt As String,
                          ByRef ControlGroup As eControlGroup,
                          ByRef ResourceTypeToLoad As core.Enums.eResourceType,
                          ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow) As Boolean
        Try
            translatedTxt = QS2.core.language.sqlLanguage.getRes(IDRes, ResourceTypeToLoad, ControlManagment.defaultParticipant, Settings._Application, rRes, False, False)
            If rRes Is Nothing Then
                IDResFound = False
            Else
                IDResFound = True
            End If
            Return IDResFound

        Catch ex As Exception
            Throw New Exception("doRessources.getRes: " + ex.ToString())
        End Try
    End Function

    Private Function addNewResAuto(ByRef IDRes As String, ByRef Description As String, ByRef cont As Control, ByRef components As Object,
                      ByRef ControlGroup As eControlGroup,
                      ByRef iControlsDone As Integer,
                      ByRef rActControl As dsControls.ControlsRow,
                      ByRef ResourceTypeToLoad As core.Enums.eResourceType,
                      ByRef ContextMenuStrip As ContextMenuStrip,
                      ByRef TxtEnglish As String, ByRef TxtGerman As String,
                      ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow, ByRef IsStandardControlxy As Boolean, ControlName As String) As Boolean
        Try
            If Settings._IntDeactivated Then
                Exit Function
            End If

            rRes = ControlManagment.sqlLanguageUpdate.newRowLanguage(ControlManagment.dsLanguageUpdate,
                                                           "", IDRes,
                                                           "", Settings._Application, ControlManagment.defaultParticipant,
                                                           ResourceTypeToLoad,
                                                           core.Enums.eTypeSub.User, "")

            rRes.English = TxtEnglish.Trim()
            rRes.German = TxtGerman.Trim()
            rRes.User = ""
            rRes.IDLanguageUser = QS2.core.license.doLicense.eApp.ALL.ToString()
            rRes.Description = Description
            rRes.CreatedUser = "Auto-Res-Managment"
            rRes.TypeSub = ""
            If Not cont Is Nothing Then
                rRes.Classification = "ControlType=" + cont.GetType().Name + ";"
            Else
                rRes.Classification = "ControlType=" + ControlName + ";"
            End If
            Try
                ControlManagment.sqlLanguageUpdate.daLanguage.Update(ControlManagment.dsLanguageUpdate.Ressourcen)
                Dim rNewResToAdd As QS2.core.language.dsLanguage.RessourcenRow = QS2.core.language.sqlLanguage.dsLanguageAll.Ressourcen.NewRow()
                rNewResToAdd.ItemArray = rRes.ItemArray
                QS2.core.language.sqlLanguage.dsLanguageAll.Ressourcen.Rows.Add(rNewResToAdd)
            Catch ex As Exception
                ControlManagment.sqlLanguageUpdate.loadAllRessources()
                ControlManagment.dsLanguageUpdate.Clear()
                Dim IDResFound As Boolean = False
                Me.getRes(IDRes, IDResFound, TxtGerman, ControlGroup, ResourceTypeToLoad, rRes)
                If rRes Is Nothing Then
                    Dim rNewProt As dsControls.ProtocollRow = ControlManagment.addProtocoll(ControlManagment.dsControls)
                    rNewProt.IDRes = IDRes
                    rNewProt.Txt = "IDRes '" + IDRes.Trim() + "' could not added to QS2-Database! (Table=Ressources, Application='" + Settings._Application.ToString() + "', TypeRes='" + ResourceTypeToLoad.ToString() + "'" + vbNewLine +
                                    "TxtGerman='" + TxtGerman + "')"
                    If Not cont Is Nothing Then
                        rNewProt.Cont = cont
                        rNewProt.ControlType = cont.GetType().ToString()
                    End If
                Else
                    Dim str As String = ""
                End If
            End Try

            Return True

        Catch ex As Exception
            Throw New Exception("doRessources.doResAuto: " + ex.ToString())
        End Try
    End Function
    Public Function getTypeRessourcesRun(ByRef ModusDesktopManagment As Boolean, ByRef ProductiveFull As Boolean) As Boolean
        Try
            If Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.DesktopManagement) Then
                ModusDesktopManagment = True
                Return True

            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveFull) Then
                ProductiveFull = True
                Return True

            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveSmall) Then
                ProductiveFull = False
                Return True

            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.Off) Then
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.getTypeRessourcesRun: " + ex.ToString())
        End Try
    End Function

    Public Function autoTranslateForm(Form As Form) As Boolean
        Try
            If Settings._IntDeactivated Then
                Exit Function
            End If

            Dim ModusDesktopManagment As Boolean = False
            Dim ProductiveFull As Boolean = False
            If Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.DesktopManagement) Then
                ModusDesktopManagment = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveFull) Then
                ProductiveFull = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveSmall) Then
                ProductiveFull = False
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.Off) Then
                Return False
            End If

            If ControlManagment.sqlLanguageUpdate Is Nothing Then
                ControlManagment.sqlLanguageUpdate = New core.language.sqlLanguage()
                ControlManagment.dsLanguageUpdate = New core.language.dsLanguage()
                ControlManagment.sqlLanguageUpdate.initControl()
                ControlManagment.sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), ControlManagment.dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, Settings._Application)
            End If

            ControlManagment.dsLanguageUpdate.Clear()
            Dim rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
            Dim IDResFound As Boolean = False
            Dim translatedTxt As String = ""

            Dim IDRes As String = Form.Name + "_" + "FormCaption"
            Me.getRes(IDRes, IDResFound, translatedTxt, eControlGroup.MainSystem, core.Enums.eResourceType.Label, rRes)
            If rRes Is Nothing Then
                If Settings._AutoAddNewRessources Then
                    Me.addNewResAuto(IDRes, "", Nothing, Nothing, eControlGroup.MainSystem, True,
                                             Nothing, core.Enums.eResourceType.Label, Nothing, "", Form.Text.Trim(), rRes, True, "WindowsForm")
                    translatedTxt = Form.Text.Trim()
                    IDResFound = True
                End If
            End If

            If IDResFound Then
                If Settings._DoNotShowRessources Then
                    translatedTxt = ""     '"---"
                End If
                Form.Text = translatedTxt.Trim()
            Else
                If Not Settings._DoNotShowRessources Then
                    Form.Text = ""
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.autoTranslateForm: " + ex.ToString())
        End Try
    End Function
    Public Function autoTranslateToolbars(toolBarMang As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager, parentControl As Control, parentForm As Form) As Boolean
        Try
            If Settings._IntDeactivated Then
                Exit Function
            End If

            Dim ModusDesktopManagment As Boolean = False
            Dim ProductiveFull As Boolean = False

            If Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.DesktopManagement) Then
                ModusDesktopManagment = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveFull) Then
                ProductiveFull = True
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.ProductiveSmall) Then
                ProductiveFull = False
            ElseIf Settings._TypeRessourcesRun.sEquals(eTypeRessourcesRun.Off) Then
                Return False
            End If

            If ControlManagment.sqlLanguageUpdate Is Nothing Then
                ControlManagment.sqlLanguageUpdate = New core.language.sqlLanguage()
                ControlManagment.dsLanguageUpdate = New core.language.dsLanguage()
                ControlManagment.sqlLanguageUpdate.initControl()
                ControlManagment.sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), ControlManagment.dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, Settings._Application)
            End If

            For Each toolBase As ToolBase In toolBarMang.Tools
                ControlManagment.dsLanguageUpdate.Clear()
                Dim rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
                Dim IDResFound As Boolean = False
                Dim translatedTxt As String = ""

                Dim IDRes As String = ""
                If Not parentForm Is Nothing Then
                    IDRes = parentForm.Name + "_" + "UltraToolbarsManager" + "_" + toolBase.Key.Trim()
                End If
                If Not parentControl Is Nothing Then
                    IDRes = parentControl.Name + "_" + "UltraToolbarsManager" + "_" + toolBase.Key.Trim()
                End If
                Me.getRes(IDRes, IDResFound, translatedTxt, eControlGroup.MainSystem, core.Enums.eResourceType.Label, rRes)
                If rRes Is Nothing Then
                    If Settings._AutoAddNewRessources Then
                        Me.addNewResAuto(IDRes, "", Nothing, Nothing, eControlGroup.MainSystem, True,
                                             Nothing, core.Enums.eResourceType.Label, Nothing, "", toolBase.SharedProps.Caption.Trim(), rRes, True, "UltraToolbarsManager")
                        translatedTxt = toolBase.SharedProps.Caption.Trim()
                        IDResFound = True
                    End If
                End If

                If IDResFound Then
                    If Settings._DoNotShowRessources Then
                        translatedTxt = ""     '"---"
                    End If
                    toolBase.SharedProps.Caption = translatedTxt.Trim()
                Else
                    If Not Settings._DoNotShowRessources Then
                        toolBase.SharedProps.Caption = ""
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doRessources.autoTranslateToolbars: " + ex.ToString())
        End Try
    End Function
    Public Shared Function MessageBox(Txt As String, Caption As String, Buttons As MessageBoxButtons, ico As MessageBoxIcon,
                                        Optional NoTranslation As Boolean = False, Optional Password As String = "") As DialogResult
        Try
            If Settings._IntDeactivated Or NoTranslation Then
                Return MsgBox(Txt.Trim(), Buttons, Caption.Trim())
            End If

            If ControlManagment.sqlLanguageUpdate Is Nothing Then
                ControlManagment.sqlLanguageUpdate = New core.language.sqlLanguage()
                ControlManagment.dsLanguageUpdate = New core.language.dsLanguage()
                ControlManagment.sqlLanguageUpdate.initControl()
                ControlManagment.sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), ControlManagment.dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, Settings._Application)
            End If

            Dim ControlManagment1 As New ControlManagment()
            Dim ModusDesktopManagment As Boolean = False
            Dim ProductiveFull As Boolean = False
            Dim AutoTranslateIsOn As Boolean = ControlManagment1.getTypeRessourcesRun(ModusDesktopManagment, ProductiveFull)
            If Not AutoTranslateIsOn Or (Not Settings._IsInitialized) Then
                Return MsgBox(Txt.Trim(), Buttons, Caption.Trim())
            End If


            ControlManagment.dsLanguageUpdate.Clear()
            Dim rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
            Dim IDResFound As Boolean = False
            Dim translatedTxt As String = ""

            Dim IDRes As String = Txt + "_" + "MessageBoxText"
            ControlManagment1.getRes(IDRes, IDResFound, translatedTxt, eControlGroup.MainSystem, core.Enums.eResourceType.Label, rRes)
            If rRes Is Nothing Then
                If Settings._AutoAddNewRessources Then
                    ControlManagment1.addNewResAuto(IDRes, "", Nothing, Nothing, eControlGroup.MainSystem, True,
                                             Nothing, core.Enums.eResourceType.Label, Nothing, "", Txt.Trim(), rRes, True, "MessageBoxText")
                    translatedTxt = Txt.Trim()
                    IDResFound = True
                End If
            End If

            ControlManagment.dsLanguageUpdate.Clear()
            Dim translatedCaption As String = ""
            If Caption.Trim() <> "" Then
                rRes = Nothing
                IDResFound = False
                IDRes = Caption + "_" + "MessageBoxCaption"
                ControlManagment1.getRes(IDRes, IDResFound, translatedCaption, eControlGroup.MainSystem, core.Enums.eResourceType.Label, rRes)
                If rRes Is Nothing Then
                    If Settings._AutoAddNewRessources Then
                        ControlManagment1.addNewResAuto(IDRes, "", Nothing, Nothing, eControlGroup.MainSystem, True,
                                            Nothing, core.Enums.eResourceType.Label, Nothing, "", Caption.Trim(), rRes, True, "MessageBoxCaption")
                        translatedCaption = Caption.Trim()
                        IDResFound = True
                    End If
                End If
            End If

            If IDResFound Then
                If Settings._DoNotShowRessources Then
                    translatedTxt = ""
                    translatedCaption = ""
                End If
                Return MsgBox(translatedTxt.Trim(), Buttons, translatedCaption.Trim())
            Else
                If Not Settings._DoNotShowRessources Then
                    Return MsgBox("", Buttons, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function

    Public Shared Function getRes(Txt2 As String, ParamArray pars() As Object) As String
        Try
            If Settings._IntDeactivated Then
                If pars.Length > 0 Then
                    ControlManagment.doParsMsgBox(Txt2, pars)
                End If
                Return Txt2
            End If

            If ControlManagment.sqlLanguageUpdate Is Nothing Then
                ControlManagment.sqlLanguageUpdate = New core.language.sqlLanguage()
                ControlManagment.dsLanguageUpdate = New core.language.dsLanguage()
                ControlManagment.sqlLanguageUpdate.initControl()
                ControlManagment.sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), ControlManagment.dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, Settings._Application)
            End If

            Dim ControlManagment1 As New ControlManagment()
            Dim ModusDesktopManagment As Boolean = False
            Dim ProductiveFull As Boolean = False
            Dim AutoTranslateIsOn As Boolean = ControlManagment1.getTypeRessourcesRun(ModusDesktopManagment, ProductiveFull)
            If Not AutoTranslateIsOn Or (Not Settings._IsInitialized) Then
                Return Txt2
            End If

            ControlManagment.dsLanguageUpdate.Clear()
            Dim rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
            Dim IDResFound As Boolean = False
            Dim translatedTxt As String = ""

            Dim IDRes As String = Txt2 + "_" + "AutoRes"
            ControlManagment1.getRes(IDRes, IDResFound, translatedTxt, eControlGroup.MainSystem, core.Enums.eResourceType.Label, rRes)
            If rRes Is Nothing Then
                If Settings._AutoAddNewRessources Then
                    ControlManagment1.addNewResAuto(IDRes, "", Nothing, Nothing, eControlGroup.MainSystem, True,
                                             Nothing, core.Enums.eResourceType.Label, Nothing, "", Txt2.Trim(), rRes, True, "AutoRes")
                    translatedTxt = Txt2.Trim()
                    IDResFound = True
                End If
            End If

            If IDResFound Then
                If Settings._DoNotShowRessources Then
                    translatedTxt = ""
                End If

                Dim iCounterPars As Integer = 0
                If pars.Length > 0 Then
                    For Each par As Object In pars
                        Dim sReplace As String = "{" + iCounterPars.ToString() + "}"
                        translatedTxt = translatedTxt.Replace(sReplace, par.ToString())
                        iCounterPars += 1
                    Next
                End If
                Return translatedTxt.Trim()
            Else
                If Not Settings._DoNotShowRessources Then
                    Return "[ResNotFound_" + Txt2.Trim() + "]"
                Else
                    Return "[ResNotFound]"
                End If
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.getRes: " + ex.ToString())
        End Try
    End Function
    Public Shared Sub doParsMsgBox(ByRef translatedTxt As String, ParamArray pars() As Object)
        Try

            Dim iCounterPars As Integer = 0
            If pars.Length > 0 Then
                For Each par As Object In pars
                    Dim sReplace As String = "{" + iCounterPars.ToString() + "}"
                    translatedTxt = translatedTxt.Replace(sReplace, par.ToString())
                    iCounterPars += 1
                Next
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.doParsMsgBox: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function MessageBox(Txt As String, Caption As String, Optional NoTranslation As Boolean = False) As DialogResult
        Try
            Dim ico As MessageBoxIcon = MessageBoxIcon.Information
            Return ControlManagment.MessageBox(Txt, Caption, MessageBoxButtons.OK, ico, NoTranslation)

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function MessageBox(Txt As String, Optional NoTranslation As Boolean = False) As DialogResult
        Try
            Dim ico As MessageBoxIcon = MessageBoxIcon.Information
            Return ControlManagment.MessageBox(Txt, "", MessageBoxButtons.OK, ico, NoTranslation)

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function MessageBox(Txt As String, Caption As String, Buttons As MessageBoxButtons, Optional NoTranslation As Boolean = False, Optional Password As String = "") As DialogResult
        Try
            Dim ico As MessageBoxIcon = MessageBoxIcon.Information
            Return ControlManagment.MessageBox(Txt, Caption, Buttons, ico, NoTranslation)

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function MessageBoxVB(Txt As String, Buttons As MessageBoxButtons, Caption As String, Optional NoTranslation As Boolean = False) As DialogResult
        Try
            Dim ico As MessageBoxIcon = MessageBoxIcon.Information
            Return ControlManagment.MessageBox(Txt, Caption, Buttons, ico, NoTranslation)

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function
    Public Shared Function MessageBoxVB(Txt As String, Optional NoTranslation As Boolean = False) As DialogResult
        Try
            Dim ico As MessageBoxIcon = MessageBoxIcon.Information
            Return ControlManagment.MessageBox(Txt, "", MessageBoxButtons.OK, ico, NoTranslation)

        Catch ex As Exception
            Throw New Exception("doRessources.MessageBox: " + ex.ToString())
        End Try
    End Function




    Private Function isControlForTxt(Cont As Control) As Boolean
        Try

            If Cont.GetType.Equals(GetType(BaseButton)) Or Cont.GetType.Equals(GetType(BaseButtonWin)) Or
                    Cont.GetType.Equals(GetType(BaseCheckBox)) Or Cont.GetType.Equals(GetType(BaseCheckBoxWin)) Or
                    Cont.GetType.Equals(GetType(BaseComboEditor)) Or Cont.GetType.Equals(GetType(BaseDateTimeEditor)) Or
                    Cont.GetType.Equals(GetType(BaseDateTimeEditorWin)) Or Cont.GetType.Equals(GetType(BaseGroupBox)) Or
                    Cont.GetType.Equals(GetType(BaseGroupBoxWin)) Or Cont.GetType.Equals(GetType(BaseGroupBoxWin)) Or
                    Cont.GetType.Equals(GetType(BaseLabel)) Or Cont.GetType.Equals(GetType(BaseLableWin)) Or
                    Cont.GetType.Equals(GetType(BaseLabel)) Or Cont.GetType.Equals(GetType(BaseTabControl)) Or
                    Cont.GetType.Equals(GetType(BaseOptionSet)) Or Cont.GetType.Equals(GetType(baseForm)) Then
                Return True
            Else
                Dim bNoControlForTxt As Boolean = True
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.isControlForTxt: " + ex.ToString())
        End Try
    End Function
    Private Function addControl(ControlKey As String, Ctrl As System.Windows.Forms.Control, ds As dsControls) As dsControls.ControlsRow
        Try
            Dim rNew As dsControls.ControlsRow = ds.Controls.NewRow()
            rNew.IDRes = ControlKey
            rNew.ControlText = ""
            rNew.IsStandardControl = False
            rNew.Created = Now
            rNew.ControlTypeShort = Ctrl.GetType().Name.ToString()
            rNew.ControlType = Ctrl.GetType().ToString()
            rNew.Ctrl = Ctrl
            rNew.HandleEvent = ""
            rNew.ActionPerformed = False
            rNew.Description = ""

            ds.Controls.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("doRessources.addControl: " + ex.ToString())
        End Try
    End Function
    Private Function checkIfControlIsLoaded(ByRef IDRes As String, ByRef Ctrl As System.Windows.Forms.Control, ByRef ds As dsControls) As Boolean
        Dim arrControl() As dsControls.ControlsRow = ds.Controls.Select(ds.Controls.IDResColumn.ColumnName + "='" + IDRes.Trim() + "'", "")
        If arrControl.Length = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function getRowControlFromDb(ByRef IDRes As String, ByRef Ctrl As System.Windows.Forms.Control, ByRef ds As dsControls) As dsControls.ControlsRow
        Dim arrControl() As dsControls.ControlsRow = ds.Controls.Select(ds.Controls.IDResColumn.ColumnName + "='" + IDRes.Trim() + "'", "")
        If arrControl.Length = 1 Then
            Return arrControl(0)
        Else
            Return Nothing
            'Throw New Exception("doRessources.getRowControlFromDb: Control '" + IDRes + "' not found in Db!")
        End If
    End Function

    Public Shared Function getIDREsForControlxy(ByVal contToTranslate As Control, ByRef IDResReturn As String, ByRef DescriptionReturn As String) As Boolean
        Try
            Dim IDRes As String = ""
            Dim CounterControl As Integer = 0
            ControlManagment.getIDResForControl_rek(contToTranslate, IDRes, DescriptionReturn, CounterControl)
            If IDRes.Trim() = "" Then
                IDResReturn = ""
                DescriptionReturn = ""
                Return False
            End If
            DescriptionReturn = "Number controls: " + CounterControl.ToString() + vbNewLine + DescriptionReturn
            IDResReturn = IDRes

            Return True

        Catch ex As Exception
            Throw New Exception("doRessources.getIDREsForControl: " + ex.ToString())
        End Try
    End Function

    Private Shared Function getIDResForControl_rek(ByRef contToTranslate As Control, ByRef IDRes As String, ByRef Description As String,
                                                  ByRef CounterControl As Integer) As String
        Try
            CounterControl += 1
            If CounterControl <= ControlManagment.iCounterDepthControlForIDRes Then
                IDRes += IIf(IDRes.Trim() = "", "", "_") + contToTranslate.Name.Trim()
            End If
            Description += contToTranslate.Name.Trim() + vbNewLine
            If Not contToTranslate.Parent Is Nothing Then
                ControlManagment.getIDResForControl_rek(contToTranslate.Parent, IDRes, Description, CounterControl)
            End If

        Catch ex As Exception
            Throw New Exception("doRessources.getIDREsForControl_rek: " + ex.ToString())
        End Try
    End Function

    Private Shared Function addProtocoll(ds As dsControls) As dsControls.ProtocollRow
        Try
            Dim rNew As dsControls.ProtocollRow = ds.Protocoll.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.ControlKey = ""
            rNew.Txt = ""
            rNew.dat = Now
            rNew.IDRes = ""
            rNew.Cont = ""
            rNew.ControlType = ""

            ds.Protocoll.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("doRessources.addControl: " + ex.ToString())
        End Try
    End Function
End Class

Public Class HandleEvent
    Friend WithEvents ToolStripMenuItem_LayoutSave As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_LayoutReset As System.Windows.Forms.ToolStripMenuItem = Nothing

    Friend WithEvents ToolStripMenuItem_LayoutManagerGrid As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_ExportGridAsExcel As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_ExportGridAsWord As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_ExportGridAsPdf As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_PrintGrid As System.Windows.Forms.ToolStripMenuItem = Nothing

    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator = Nothing
    Friend WithEvents ToolStripMenuItem_CallResManager As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_CriteriaManager As System.Windows.Forms.ToolStripMenuItem = Nothing

    Friend WithEvents ToolStripMenuItem_ControlInfo As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_ControlDatabase As System.Windows.Forms.ToolStripMenuItem = Nothing

    Friend WithEvents ToolStripMenuItem_CopyCell As System.Windows.Forms.ToolStripMenuItem = Nothing
    Friend WithEvents ToolStripMenuItem_CopyAllRowsFromCell As System.Windows.Forms.ToolStripMenuItem = Nothing

    Friend WithEvents ToolStripMenuItem_EndTask As System.Windows.Forms.ToolStripMenuItem = Nothing

    Public Enum eActionType
        LayoutSave = 0
        LayoutReset = 1
        LayoutManager = 2
        ExportAsExcel = 3
        ExprotAsPdf = 4
        ExprotAsWord = 5
        PrintGrid = 6
    End Enum

    Public WithEvents _forControl As Control = Nothing
    Public _componentsxy As Object = Nothing
    Public _IDRes As String = ""
    Public _Description As String = ""
    Public _DoIDResAuto As Boolean = False
    Public _rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public _ControlGroup As ControlManagment.eControlGroup = Nothing
    Public _ResType As QS2.core.Enums.eResourceType = Nothing
    Public _compLayout As New QS2.core.vb.compLayout()
    Public _rControl As dsControls.ControlsRow = Nothing
    Public _IDResStandardControl As String = ""
    Public _IsStandardControl As Boolean = False
    Public _ProductiveFull As Boolean = False
    Public _ExtendedView As Boolean = False
    Public WithEvents _grid As UltraGrid = Nothing
    Public _TextControlOnUIActuell As String = ""
    Public _InfoControl As doBaseElements.cInfoControl = Nothing
    Public _ControlManagment As ControlManagment = Nothing
    Public WithEvents _ContextMenuStrip As ContextMenuStrip = Nothing
    Public doBaseElements1 As New doBaseElements()

    Public Sub New(ByVal components As Object, forControl As Control, ByRef iControlsDone As Integer,
                   ByRef IDRes As String, Description As String, ByRef ContextMenuStrip As ContextMenuStrip,
                   ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow, ByRef IsStandardControl As Boolean,
                   ByRef IDResStandardControl As String, rControl As dsControls.ControlsRow,
                   ByRef TextControlOnUIActuellxy As String, ProductiveFull As Boolean,
                   ByRef InfoControl As doBaseElements.cInfoControl,
                   ByRef ControlManagment As ControlManagment, ByRef DoIDResAuto As Boolean, ExtendedView As Boolean)
        Try
            Me._ControlManagment = ControlManagment

            Me._ProductiveFull = ProductiveFull
            Me._forControl = forControl
            Me._rControl = rControl
            Me._componentsxy = components
            Me._ContextMenuStrip = ContextMenuStrip
            Me._rRes = rRes

            Me._IDRes = IDRes
            Me._Description = Description
            Me._DoIDResAuto = DoIDResAuto

            Me._IsStandardControl = IsStandardControl
            Me._IDResStandardControl = IDResStandardControl
            Me._compLayout.initControl()

            Me._rControl.HandleEvent = Me
            Me._InfoControl = InfoControl

            Me._ExtendedView = ExtendedView

            Dim ContextMenuStripToAdd As System.Windows.Forms.ContextMenuStrip = Nothing

            If forControl.GetType.Equals((GetType(UltraGrid))) Or forControl.GetType.Name.Trim().ToLower().Equals(("BaseGrid").Trim().ToLower().ToString()) Or
                Me._InfoControl._IsQuickFilter Then

                If Me._InfoControl._IsQuickFilter Then
                    Me._grid = Me._InfoControl.grid
                Else
                    Me._grid = forControl
                End If
                ContextMenuStripToAdd = ContextMenuStrip

                If Settings._RigthLayoutmanager Then
                    Me.ToolStripMenuItem_LayoutManagerGrid = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                    Me.ToolStripMenuItem_LayoutManagerGrid.Text = "Layout-Manager"
                    Me.ToolStripMenuItem_LayoutManagerGrid.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)
                Else
                    Dim str As String = ""
                End If

                If Not Me._InfoControl._IsQuickFilter Then
                    Me.ToolStripMenuItem_ExportGridAsExcel = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                    Me.ToolStripMenuItem_ExportGridAsExcel.Text = "Export Excel"
                    Me.ToolStripMenuItem_ExportGridAsExcel.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Excel, 32, 32)

                    Me.ToolStripMenuItem_ExportGridAsWord = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                    Me.ToolStripMenuItem_ExportGridAsWord.Text = "Export Word"
                    Me.ToolStripMenuItem_ExportGridAsWord.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Winword, 32, 32)

                    Me.ToolStripMenuItem_ExportGridAsPdf = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                    Me.ToolStripMenuItem_ExportGridAsPdf.Text = "Export Pdf"
                    Me.ToolStripMenuItem_ExportGridAsPdf.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32)

                    If Settings._RigthLayoutmanager Then
                        Me.ToolStripMenuItem_PrintGrid = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                        Me.ToolStripMenuItem_PrintGrid.Text = "Print Grid"
                        Me.ToolStripMenuItem_PrintGrid.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32)
                    End If

                    If Me._grid.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.CellSelect Or
                        Me._grid.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText Or
                        Me._grid.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.Edit Then

                        Me.ToolStripMenuItem_CopyCell = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                        Me.ToolStripMenuItem_CopyCell.Text = "Wert in ausgewählter Zelle kopieren"
                        Me.ToolStripMenuItem_CopyCell.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32)

                        Me.ToolStripMenuItem_CopyAllRowsFromCell = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                        Me.ToolStripMenuItem_CopyAllRowsFromCell.Text = "Alle Werte in ausgewählter Spalte kopieren"
                        Me.ToolStripMenuItem_CopyAllRowsFromCell.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32)
                    End If
                End If
            End If

            If QS2.Desktop.ControlManagment.Settings._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.DesktopManagement.ToString().Trim().ToLower()) Then
                ContextMenuStripToAdd = ContextMenuStrip

                Me.ToolStripMenuItem_CallResManager = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                Me.ToolStripMenuItem_CallResManager.Text = "Ressources"

                Me.ToolStripMenuItem_CriteriaManager = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                Me.ToolStripMenuItem_CriteriaManager.Text = "Criterias"

                Me.ToolStripMenuItem_ControlDatabase = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                Me.ToolStripMenuItem_ControlDatabase.Text = "Control-Database"

                Me.ToolStripMenuItem_ControlInfo = ContextMenuStripToAdd.Items.Add(Me.getControlNameAutoAdded())
                Me.ToolStripMenuItem_ControlInfo.Text = "Control-Info (Control-Type: " + forControl.GetType().Name.ToString() + ")"

            End If

            iControlsDone += 1

        Catch ex As Exception
            Throw New Exception("HandleEvent.New: " + ex.ToString())
        End Try
    End Sub

    Public Function getControlNameAutoAdded() As String
        Dim newControlName As String = ControlManagment.prefControlNameAutoAdded + "_" + Me._forControl.Name + "_" + System.Guid.NewGuid().ToString()
        Return newControlName.Trim()
    End Function

    Private Sub _grid_BeforeAutoSizeEdit(sender As Object, e As CancelableAutoSizeEditEventArgs) Handles _grid.BeforeAutoSizeEdit
        Try
            e.StartHeight = 200

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub ToolStripMenuItem_LayoutSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_LayoutSave.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.LayoutSave)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_LayoutSave_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_LayoutReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_LayoutReset.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.LayoutReset)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_LayoutReset_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_LayoutManagerGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_LayoutManagerGrid.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.LayoutManager)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_LayoutManagerGrid_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_ExportGridAsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_ExportGridAsExcel.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.ExportAsExcel)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_ExportGridAsExcel_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_ExportGridAsWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_ExportGridAsWord.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.ExprotAsWord)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_ExportGridAsWord_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_ExportGridAsPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_ExportGridAsPdf.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.ExprotAsPdf)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_ExportGridAsPdf_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_PrintGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_PrintGrid.Click
        Try
            Me.DoActionForGrid(Me._rControl, eActionType.PrintGrid)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_PrintGrid_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_CallResManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CallResManager.Click
        Try
            Me.OpenResManager(Me._rControl)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_CallResManager_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_CallCriterias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CriteriaManager.Click
        Try
            Me.OpenCriterias(Me._rControl)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_CallCriterias_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_ControlDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_ControlDatabase.Click
        Try
            Me.OpenTableViewer(Me._rControl)

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_ProtocollControlWorker_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_ControlInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_ControlInfo.Click
        Try

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_ControlInfo_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_CopyAllRowsFromCell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CopyAllRowsFromCell.Click
        Try
            If Not Me._grid Is Nothing Then
                If Not Me._grid.ActiveCell Is Nothing Then
                    Dim sProt As String = ""
                    For Each rowGrid In Me._grid.Rows
                        If Not rowGrid.Cells(Me._grid.ActiveCell.Column.ToString()) Is Nothing Then
                            If Not rowGrid.Cells(Me._grid.ActiveCell.Column.ToString()).Value Is System.DBNull.Value Then
                                sProt += rowGrid.Cells(Me._grid.ActiveCell.Column.ToString()).Value.ToString() + vbNewLine
                            Else
                                sProt += "DBNull" + vbNewLine
                            End If
                        Else
                            sProt += "null" + vbNewLine
                        End If
                    Next
                    Clipboard.SetDataObject(sProt)
                Else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Zelle ausgewählt!", MsgBoxStyle.OkOnly, "")
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_CopyAllRowsFromCell_Click: " + ex.ToString(), "")
        End Try
    End Sub
    Public Sub ToolStripMenuItem_CopyCell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CopyCell.Click
        Try
            If Not Me._grid Is Nothing Then
                If Not Me._grid.ActiveCell Is Nothing Then
                    If Not Me._grid.ActiveCell.Value Is Nothing Then
                        Clipboard.SetDataObject(Me._grid.ActiveCell.Value.ToString())
                    Else
                        Clipboard.SetDataObject("null")
                    End If
                Else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Zelle ausgewählt!", MsgBoxStyle.OkOnly, "")
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep("HandleEvent.ToolStripMenuItem_CopyCell_Click: " + ex.ToString(), "")
        End Try
    End Sub

    Public Sub ToolStripMenuItem_EndTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_EndTask.Click
        Try
            If Not Me._grid Is Nothing Then
                If Not Me._grid.ActiveCell Is Nothing Then
                    If Not Me._grid.ActiveCell.Value Is Nothing Then

                        Dim IDPflegeplanx As Guid = Me._grid.ActiveRow.ListObject.Row.Item("IDPflegeplan")
                        Dim sTextForPE = "Maßnahme wurde direkt aus der Interventionsliste beendet."

                        Dim res As DialogResult = QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Wollen Sie diese Maßnahme jetzt wirklich beenden?", MsgBoxStyle.YesNo, "Maßnahme direkt beenden")
                    Else
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Pflegeplan gefunden", MsgBoxStyle.OkOnly, "")
                    End If
                Else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Zelle ausgewählt!", MsgBoxStyle.OkOnly, "")
                End If
            End If

        Catch ex As Exception
            'Do Nothing
        End Try
    End Sub

    Public Function DoActionForGrid(ByRef rControl As dsControls.ControlsRow, ActionType As eActionType) As Boolean
        Try
            Dim gridTmp As UltraGrid = Nothing
            If Me._InfoControl._IsQuickFilter Then
                gridTmp = Me._InfoControl.grid
            Else
                gridTmp = rControl.Ctrl
            End If

            Dim export1 As New QS2.sitemap.export()
            If ActionType = eActionType.LayoutManager Then
                Dim frmLayoutManager1 As New core.vb.frmLayoutManager()
                Dim dOnSaveLayout As New core.vb.contLayoutManager.onValueSave(AddressOf Me.LayoutSaved)
                frmLayoutManager1.ContLayoutGrid1.delonSaveClick = dOnSaveLayout

                Dim DefaultNameQuickfilterTmp As String = ""
                Dim sKey As String = ""
                If Not IsNothing(Me._InfoControl.dGetLastClickedQuickfilter) Then
                    Dim retGetQuickfilter As doBaseElements.cInfoControl.retGetQuickfilter
                    retGetQuickfilter = Me._InfoControl.dGetLastClickedQuickfilter.Invoke()
                    If retGetQuickfilter.LastClickedQuickfilter.Trim() <> "" Then
                        sKey = retGetQuickfilter.LastClickedQuickfilter.Trim()
                        DefaultNameQuickfilterTmp = retGetQuickfilter.NameDefaultQuickfilter.Trim()
                        Me._InfoControl.IDQuickfilterToSave = retGetQuickfilter.IDQuickFilterToSave
                    End If
                End If
                If sKey.Trim() = "" Then
                    DefaultNameQuickfilterTmp = Me._InfoControl.defaultLayoutNamexy.Trim()
                    If Me._InfoControl.KeyLayoutFromQuickfilter.Trim() <> "" Then
                        sKey = Me._InfoControl.KeyLayoutFromQuickfilter.Trim()
                    Else
                        If Me._InfoControl.QuickFilterKey.Trim() = "" Then
                            sKey = Me._IDRes.Trim()
                        Else
                            sKey = Me._IDRes.Trim()
                        End If
                    End If
                End If

                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1._LayoutKey = sKey.Trim()
                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.gridUIToSave = gridTmp
                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = core.vb.cLayoutManager.eTypLayoutGrid.onlyFirstBand
                frmLayoutManager1.initControl(Me._IDRes.Trim(), False, DefaultNameQuickfilterTmp, Me._ExtendedView)
                frmLayoutManager1.ContLayoutGrid1.loadData(sKey.Trim(), DefaultNameQuickfilterTmp, True, True, False)
                frmLayoutManager1.ShowDialog()
                Me._InfoControl.LastLoadedLayout.IsLoaded = False

            ElseIf ActionType = eActionType.ExportAsExcel Then
                Dim lstColTranslated As New System.Collections.Generic.Dictionary(Of String, String)
                export1.doExport(gridTmp, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.excel, Nothing, "", "", lstColTranslated)

            ElseIf ActionType = eActionType.ExprotAsPdf Then
                Dim lstColTranslated As New System.Collections.Generic.Dictionary(Of String, String)
                export1.doExport(gridTmp, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.pdf, Nothing, "", "", lstColTranslated)

            ElseIf ActionType = eActionType.ExprotAsWord Then
                Dim lstColTranslated As New System.Collections.Generic.Dictionary(Of String, String)
                export1.doExport(gridTmp, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.word, Nothing, "", "", lstColTranslated)

            ElseIf ActionType = eActionType.PrintGrid Then
                Dim PrintGrid1 As New QS2.core.vb.PrintGrid()
                PrintGrid1.print(gridTmp)

            End If

        Catch ex As Exception
            Throw New Exception("HandleEvent.DoActionForGrid: " + ex.ToString())
        End Try
    End Function


    Public Sub LayoutSaved(rLayout As QS2.core.vb.dsLayout.LayoutRow)
        Try
            If Me._InfoControl._IsQuickFilter Or Me._InfoControl.SaveLastQuickfilter Then
                If Not Me._ControlManagment.delOnSaveLayoutClick Is Nothing Then
                    Me._ControlManagment.delOnSaveLayoutClick.Invoke(Me._InfoControl.IDQuickfilterToSave, rLayout)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("HandleEvent.LayoutSaved: " + ex.ToString())
        End Try
    End Sub

    Public Function OpenResManager(ByRef rControl As dsControls.ControlsRow) As Boolean
        Try
            Dim frmRes As New QS2.sitemap.manage.wizardsDevelop.frmRessourcen()
            frmRes.contRessourcen1.IDApplication = Settings._Application
            frmRes.contRessourcen1.IDParticipant = ControlManagment.defaultParticipant
            frmRes.doSearchAuto = True
            frmRes.searchAuto = Me._IDRes
            frmRes.defaultApplication = Settings._Application
            If frmRes.ShowDialog() = DialogResult.OK Then
            End If

            Me.doBaseElements1.runControlManagment(Me._IDRes, Me._forControl, Me._ContextMenuStrip, False, Me._rRes, False, Me._IsStandardControl,
                                                    Me._DoIDResAuto)
            Return True

        Catch ex As Exception
            Throw New Exception("HandleEvent.OpenResManager: " + ex.ToString())
        End Try
    End Function

    Public Function OpenCriterias(ByRef rControl As dsControls.ControlsRow) As Boolean
        Try
            Dim frmCrit As New QS2.sitemap.manage.wizardsDevelop.frmCriterias()
            frmCrit.contCriterias1.IDApplication = Settings._Application
            frmCrit.contCriterias1.IDParticipant = ControlManagment.defaultParticipant
            frmCrit.doSearchAuto = True
            frmCrit.searchAuto = Me._IDRes
            frmCrit.defaultApplication = Settings._Application
            frmCrit.ShowDialog()
            Me.doBaseElements1.runControlManagment(Me._IDRes, Me._forControl, Me._ContextMenuStrip, False, Me._rRes, False, Me._IsStandardControl,
                                                   Me._DoIDResAuto)
            Return True

        Catch ex As Exception
            Throw New Exception("HandleEvent.OpenCriterias: " + ex.ToString())
        End Try
    End Function

    Public Function OpenTableViewer(ByRef rControl As dsControls.ControlsRow) As Boolean
        Try
            Dim frmTable1 As New QS2.ui.print.frmTable()
            frmTable1.contTable1.infoQryRunPar = Nothing
            frmTable1.selectDatasets = True
            Dim lstDatasets As New System.Collections.ArrayList()
            lstDatasets.Add(ControlManagment.dsControls)
            frmTable1.lstDatasets = lstDatasets
            frmTable1.IDParticipant = ControlManagment.defaultParticipant
            frmTable1.IDApplication = Settings._Application
            frmTable1.initControl(QS2.ui.print.contTable.eTypeUI.Query, "", True)
            frmTable1.Show()
            frmTable1.Text = "Control-Database"

        Catch ex As Exception
            Throw New Exception("HandleEvent.OpenTableViewer: " + ex.ToString())
        End Try
    End Function

End Class


