Imports Microsoft.Win32
Imports System.IO
Imports System.Xml
Imports System.Net
Imports System
Imports System.Globalization
Imports System.Resources
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports System.Text

Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinExplorerBar

Imports System.ComponentModel.Component





Public Class UI

    Public gen As New General

    Public Class cObjectsRow
        Public txt As String = ""
        Public lstObjects As New System.Collections.Generic.List(Of Guid)
    End Class













    Public Function openMessage(ByVal IDPlan As System.Guid, ByVal modalWindow As contPlanung2, ByRef asModalDialog As Boolean, TypeUI As contPlanungData.eTypeUI, PlanArchive As contPlanungData.cPlanArchive) As Boolean

        Try
            Dim exch As New General.exchPlan
            Dim compPlan1 As New compPlan()
            Dim rPlan As dsPlan.planRow = compPlan1.getPlanRow(IDPlan, compPlan.eTypSelPlan.id, True)
            If Not rPlan Is Nothing Then
                exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen
                exch.str = Me.gen.GuidToStr(rPlan.ID)

                Dim frm As frmNachricht3 = Nothing
                frm = HandleMessage.getMessage()
                If frm.Visible Then
                    frm.Visible = False
                End If

                frm.modalWindow = modalWindow
                frm.loadForm()
                frm.Init(exch, -999, TypeUI, PlanArchive)
                'If asModalDialog Then
                '    frm.ShowDialog()
                '    If Not frm.abort Then
                '        Return True
                '    End If
                'Else
                '    frm.Show()
                '    Return True
                'End If

                'If asModalDialog Then
                '    frm.Visible = True
                '    System.Windows.Forms.Application.DoEvents()
                '    frm.doLoad()

                '    frm.ShowDialog()
                '    If Not frm.abort Then
                '        Return True
                '    End If
                'Else
                '    frm.Show()
                '    System.Windows.Forms.Application.DoEvents()
                '    frm.doLoad()
                '    frm.Visible = True

                '    Return True
                'End If

                'If Not newInstanzWindow Then
                '    frm.ShowDialog()
                '    If Not frm.abort Then
                '        Return True
                '    End If
                'Else
                frm.Show()
                frm.Visible = True
                System.Windows.Forms.Application.DoEvents()
                Return True
                'End If

            Else
                doUI.doMessageBox2("PlanningEntryNoLongerExists", "", "!")
            End If

        Catch ex As Exception
            Throw New Exception("UI.openMessage: " + ex.ToString())
        Finally
        End Try
    End Function


    Public Function selectFolder() As String
        Try
            Dim FolderBrowser As New FolderBrowserDialog
            FolderBrowser.Description = doUI.getRes("SelectFolder")
            FolderBrowser.ShowNewFolderButton = True
            FolderBrowser.RootFolder = System.Environment.SpecialFolder.Desktop
            FolderBrowser.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop
            If FolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return FolderBrowser.SelectedPath
            End If
            Return ""

        Catch ex As Exception
            Throw New Exception("UI.selectFolder: " + ex.ToString())
        End Try
    End Function
    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean,
                           ByRef rDoku As dbArchiv.archDokuRow, ByVal openIntern As Boolean,
                           ByVal withMsgBox As Boolean, ByVal printFile As Boolean) As Boolean
        Try
            If System.IO.File.Exists(file) Then
                Dim dateiTemp As String = ""
                If openTemporär Then
                    Dim IDNewFileNameTemp As New System.Guid
                    IDNewFileNameTemp = System.Guid.NewGuid
                    dateiTemp = System.IO.Path.Combine(qs2.functions.vb.functOld.path_temp, IDNewFileNameTemp.ToString + dateiTyp)
                    System.IO.File.Copy(file, dateiTemp)
                Else
                    dateiTemp = file
                End If
                If Me.gen.IsNull(dateiTyp) Then
                    Dim cl As New QS2.functions.vb.functOld()
                    dateiTyp = cl.GetFiletyp(file)
                End If

                If openIntern Then
                    Return Me.openFileIntern(file, dateiTyp, openTemporär, rDoku, openIntern, withMsgBox)
                Else
                    If Not printFile Then
                        System.Diagnostics.Process.Start(file)
                        Return True
                    Else
                        Me.printFile(file)
                        Return True
                    End If
                End If

            Else
                If withMsgBox Then
                    doUI.doMessageBox2("FileDoesNotExist", "OpenFile", "!")
                End If
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("UI.openFile: " + ex.ToString())
        End Try
    End Function
    Public Function openFileIntern(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean,
                           ByRef rDoku As dbArchiv.archDokuRow,
                           ByVal openIntern As Boolean, ByVal withMsgBox As Boolean) As Boolean
        Try
            If Not rDoku Is Nothing Then
                If rDoku.IsbinInternNull() Then
                    If withMsgBox Then
                        doUI.doMessageBox2("DocumentIsNoInternDocument", "OpenInternDocument", "!")
                    End If
                Else
                    Dim frmTxtEditor1 As qs2.Desktop.Txteditor.frmTxtEditor = General.openTxtEditor(False)
                    Dim dOnSaveDocu As New qs2.Desktop.Txteditor.contTxtEditor.onSaveDocu(AddressOf Me.saveDocu)
                    frmTxtEditor1.ContTxtEditor1.delOnSaveDocu = dOnSaveDocu

                    frmTxtEditor1.ContTxtEditor1.IDDocu = rDoku.ID
                    frmTxtEditor1.ContTxtEditor1.TypDocu = rDoku.DateinameTyp
                    frmTxtEditor1.ContTxtEditor1.showUISaveDocuToDB(True)

                    frmTxtEditor1.Show()
                    'frm.openDokument(file, TXTextControl.StreamType.InternalFormat, False)
                    Dim doEditor1 As New qs2.Desktop.Txteditor.doEditor()
                    doEditor1.showText("", TXTextControl.StreamType.InternalFormat, True, TXTextControl.ViewMode.PageView, frmTxtEditor1.ContTxtEditor1.textControl1, rDoku.binIntern)
                End If
            Else
                Throw New Exception("openFileIntern: rDoku Is Nothing!")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("UI.openFileIntern: " + ex.ToString())
        End Try
    End Function
    Public Function saveDocu(ByRef IDDocu As System.Guid,
                                        ByRef binInt() As Byte, ByRef binExport() As Byte,
                                        ByRef typExport As String) As Boolean
        Try
            Dim compDokuSave As New compDoku()
            Dim dbArchivSave As New dbArchiv()
            compDokuSave.getDokuRow(IDDocu, dbArchivSave)
            Dim rDoku As dbArchiv.archDokuRow = dbArchivSave.archDoku.Rows(0)
            rDoku.binIntern = binInt
            rDoku.doku = binExport

            compDokuSave.daDoku.Update(dbArchivSave.archDoku)
            Return True

        Catch ex As Exception
            Throw New Exception("UI.saveDocu: " + ex.ToString())
        End Try
    End Function
    Public Function printFile(ByVal fileToPrint As String) As Boolean
        Try
            Dim startInfo As New ProcessStartInfo()

            startInfo.UseShellExecute = True
            startInfo.Verb = "Print"
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Minimized
            startInfo.FileName = fileToPrint

            Dim proc As New Process()
            proc.StartInfo = startInfo
            proc.Start()

            Return True

        Catch ex As Exception
            Throw New Exception("UI.printFile: " + ex.ToString())
        End Try
    End Function
    Public Sub SetClipboardText(ByVal obj As Object)

        Try

            If TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
                Clipboard.SetDataObject(obj.SelectedText)
            ElseIf TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraNumericEditor Then
                Clipboard.SetDataObject(obj.SelectedText)
            ElseIf TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraCurrencyEditor Then
                Clipboard.SetDataObject(obj.SelectedText)
            ElseIf TypeOf obj Is System.Windows.Forms.TextBox Then
                Clipboard.SetDataObject(obj.SelectedText)
            End If

        Catch ex As Exception
            Throw New Exception("UI.SetClipboardText: " + ex.ToString())
        End Try
    End Sub
    Public Sub GetClipboardText(ByVal obj As Object)
        Try

            Dim iData As IDataObject = Clipboard.GetDataObject()

            If iData.GetDataPresent(DataFormats.Text) Then
                If TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
                    obj.Text = CType(iData.GetData(DataFormats.Text), String)
                ElseIf TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraNumericEditor Then
                    obj.Text = CType(iData.GetData(DataFormats.Text), Integer)
                ElseIf TypeOf obj Is Infragistics.Win.UltraWinEditors.UltraCurrencyEditor Then
                    obj.Text = CType(iData.GetData(DataFormats.Text), Double)
                ElseIf TypeOf obj Is System.Windows.Forms.TextBox Then
                    obj.Text = CType(iData.GetData(DataFormats.Text), String)
                End If
            Else
                Throw New Exception("Error Fct. GetClipboardText")
            End If

        Catch ex As Exception
            Throw New Exception("UI.GetClipboardText: " + ex.ToString())
        End Try
    End Sub

    Public Function checkComboBox(ByRef cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal auswahlPflicht As Boolean,
                                  Optional ByVal setFocus As Boolean = True) As Boolean
        Try
            'If cmb.Focused Then

            Dim bFound As Boolean = False
            If auswahlPflicht Then
                If gen.IsNull(cmb.Value) Then

                    Dim sTitle As String = doUI.getRes("Selection")
                    Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                         doUI.getRes("PleaseDoARightSelection") + "!"
                    doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                    If setFocus Then cmb.Focus()
                    Return False
                End If
            Else
                If gen.IsNull(cmb.Value) Then
                    Return True
                End If
            End If

            For Each itm As Infragistics.Win.ValueListItem In cmb.Items
                If cmb.Value.ToString = itm.DataValue.ToString Then
                    cmb.SelectedItem = itm
                    Return True
                End If
            Next
            If Not bFound Then

                Dim sTitle As String = doUI.getRes("Selection")
                Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                     doUI.getRes("PleaseDoARightSelection") + "!"
                doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                If setFocus Then cmb.Focus()
                Return False
            End If
            Return False

        Catch ex As Exception
            Throw New Exception("UI.checkComboBox: " + ex.ToString())
        End Try
    End Function
    Public Function checkComboBox(ByVal cmb As Infragistics.Win.UltraWinGrid.UltraCombo,
                                  ByVal auswahlPflicht As Boolean,
                                  ByVal table As DataTable, ByVal key As String, Optional ShowMsgBox As Boolean = True) As Boolean
        Try
            'If cmb.Focused Then
            If auswahlPflicht Then
                If cmb.SelectedRow Is Nothing Then

                    Dim sTitle As String = doUI.getRes("Selection")
                    Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                         doUI.getRes("PleaseDoARightSelection") + "!"
                    doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                    cmb.Focus()
                    Return False
                End If
            Else
                If cmb.SelectedRow Is Nothing And cmb.Text = "" Then
                    Return True
                End If
            End If

            Dim keyToSearch As String = ""
            If Not cmb.SelectedRow Is Nothing Then
                keyToSearch = cmb.Value.ToString()
            End If

            Dim arrKeyFound() As DataRow = table.Select(key + "='" + keyToSearch + "'")
            If arrKeyFound.Length > 0 Then
                Return True
            Else
                Dim sTitle As String = doUI.getRes("Selection")
                Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                     doUI.getRes("PleaseDoARightSelection") + "!"

                If ShowMsgBox Then
                    doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)
                End If

                cmb.Focus()
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("UI.checkComboBox: " + ex.ToString())
        End Try
    End Function
    Public Function checkComboBoxDescription(ByVal cmb As Infragistics.Win.UltraWinGrid.UltraCombo,
                                ByVal auswahlPflicht As Boolean,
                                ByVal table As DataTable, ByVal key As String) As Boolean
        Try
            'If cmb.Focused Then
            If auswahlPflicht Then
                If cmb.Text.Trim() = "" Then

                    Dim sTitle As String = doUI.getRes("Selection")
                    Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                         doUI.getRes("PleaseDoARightSelection") + "!"
                    doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                    cmb.Focus()
                    Return False
                End If
            Else
                If cmb.Text = "" Then
                    Return True
                End If
            End If

            Dim keyToSearch As String = cmb.Text.Trim().ToString()
            Dim arrKeyFound() As DataRow = table.Select(key + "='" + keyToSearch + "'")
            If arrKeyFound.Length > 0 Then
                Return True
            Else
                Dim sTitle As String = doUI.getRes("Selection")
                Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                     doUI.getRes("PleaseDoARightSelection") + "!"
                doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                cmb.Focus()
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("UI.checkComboBoxDescription: " + ex.ToString())
        End Try
    End Function

    Public Sub setFilterGridKomplex(ByRef grd As UltraGrid, ByVal bIsOn As Boolean, ByVal doSplitterFunctions As Boolean)
        Try
            If bIsOn Then
                grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                grd.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden
                grd.DisplayLayout.Override.FilterRowPrompt = doUI.getRes("ClickHereToFilterData")
                grd.DisplayLayout.Override.FilterRowAppearance.ForeColor = Color.DarkGray
                grd.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.White
                grd.DisplayLayout.Override.FilterRowAppearance.FontData.Bold = DefaultableBoolean.False
                grd.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo
                grd.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.Row
                grd.DisplayLayout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Contains
                grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                grd.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
                grd.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.None
                'grd.DisplayLayout.Override.GroupByColumnsHidden = DefaultableBoolean.Default
                'grd.DisplayLayout.Override.GroupByRowExpansionStyle = GroupByRowExpansionStyle.Default
                'grd.DisplayLayout.Override.GroupByRowInitialExpansionState = GroupByRowInitialExpansionState.Default
                '      grd.DisplayLayout.Override.GroupBySummaryDisplayStyle = 
                grd.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                ' grd.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.LightSteelBlue
                Me.setMergeStyle(grd, True, doSplitterFunctions)
                'grd.DisplayLayout.Override.FilterRowPromptAppearance.FontData.SizeInPoints = 10
                grd.DisplayLayout.Override.FilterRowPromptAppearance.ForeColor = Color.DarkGray

            Else
                grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            End If

        Catch ex As Exception
            Throw New Exception("UI.setFilterGridKomplex: " + ex.ToString())
        End Try
    End Sub

    Public Sub setMergeStyle(ByRef grd As UltraGrid, ByVal setMergeOn As Boolean, ByVal doSplitterFunctions As Boolean)
        Try
            If setMergeOn Then
                grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
                'grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
                'grd.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.Beige
            Else
                grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
            End If

            grd.DisplayLayout.Override.RowSizing = RowSizing.Free
            grd.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True

            If doSplitterFunctions Then
                grd.DisplayLayout.MaxColScrollRegions = 2
                grd.DisplayLayout.MaxRowScrollRegions = 2
            Else
                grd.DisplayLayout.MaxColScrollRegions = 1
                grd.DisplayLayout.MaxRowScrollRegions = 1
            End If

        Catch ex As Exception
            Throw New Exception("UI.setMergeStyle: " + ex.ToString())
        End Try
    End Sub
    Public Sub lockUnlockOneControl(ByRef cont As Object, ByVal bEdit As Boolean)
        Try
            For Each ctl As Control In cont.controls
                If TypeOf ctl Is UltraCheckEditor Then
                    Dim chkEditor As UltraCheckEditor = ctl
                    chkEditor.Enabled = bEdit
                Else
                    If Not TypeOf ctl Is Label And
                        Not TypeOf ctl Is UltraDropDownButton And Not TypeOf ctl Is UltraButton And Not TypeOf ctl Is UltraCheckEditor Then
                        ctl.Enabled = bEdit
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("UI.lockUnlockOneControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub activateRowInGrid(ByVal grid As UltraWinGrid.UltraGrid, ByVal colName As String, ByVal value As String)
        Try
            For Each rSearch As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                If rSearch.Cells(colName).Value.ToString() = value.ToString() Then
                    grid.ActiveRow = rSearch
                End If
            Next

        Catch ex As Exception
            Throw New Exception("UI.activateRowInGrid: " + ex.ToString())
        End Try
    End Sub

    Public Function setFilter(ByVal col As String, ByVal oper As FilterLogicalOperator,
                      ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator,
                      ByVal grid As UltraGrid, ByVal bandIndex As Integer)
        Try
            Dim condition As FilterCondition
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.Or
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
            condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.Contains, filterVal)

        Catch ex As Exception
            Throw New Exception("UI.setFilter: " + ex.ToString())
        End Try
    End Function
    Public Function setFilterLessEquals(ByVal col As String, ByVal oper As FilterLogicalOperator,
                  ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator,
                  ByVal grid As UltraGrid, ByVal bandIndex As Integer)
        Try
            Dim condition As FilterCondition
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.And
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
            condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.LessThanOrEqualTo, filterVal)

        Catch ex As Exception
            Throw New Exception("UI.setFilterLessEquals: " + ex.ToString())
        End Try
    End Function
    Public Function setFilterGreaterEquals(ByVal col As String, ByVal oper As FilterLogicalOperator,
              ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator,
              ByVal grid As UltraGrid, ByVal bandIndex As Integer)
        Try
            Dim condition As FilterCondition
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.And
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
            condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.GreaterThanOrEqualTo, filterVal)

        Catch ex As Exception
            Throw New Exception("UI.setFilterGreaterEquals: " + ex.ToString())
        End Try
    End Function
    Public Function setFilterAnd(ByVal col As String, ByVal oper As FilterLogicalOperator,
                  ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator,
                  ByVal grid As UltraGrid, ByVal bandIndex As Integer)
        Try
            Dim condition As FilterCondition
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.And
            grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
            condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.Contains, filterVal)

        Catch ex As Exception
            Throw New Exception("UI.setFilterAnd: " + ex.ToString())
        End Try
    End Function
    Public Function clearAllFilter(ByVal grid As UltraGrid)
        Try
            For Each band As UltraGridBand In grid.DisplayLayout.Bands
                For Each colFilter As ColumnFilter In band.ColumnFilters
                    colFilter.ClearFilterConditions()
                Next
            Next

        Catch ex As Exception
            Throw New Exception("UI.clearAllFilter: " + ex.ToString())
        End Try
    End Function

    Public Sub gridErwSicht(ByVal bOn As Boolean, ByRef grid As UltraGrid,
                          ByVal lstColAktivate As System.Collections.Generic.List(Of String),
                          ByVal lstColDeaktivate As System.Collections.Generic.List(Of String),
                          Optional ByVal lstColAktivateErweitert As System.Collections.Generic.List(Of String) = Nothing)
        Try
            Me.gridErwSicht(bOn, grid.DisplayLayout.Bands(0), lstColAktivate, lstColDeaktivate, lstColAktivateErweitert)

        Catch ex As Exception
            Throw New Exception("UI.gridErwSicht: " + ex.ToString())
        End Try
    End Sub
    Public Sub gridErwSicht(ByVal bOn As Boolean, ByRef band As UltraGridBand,
                            ByVal lstColAktivate As System.Collections.Generic.List(Of String),
                            ByVal lstColDeaktivate As System.Collections.Generic.List(Of String),
                            Optional ByVal lstColAktivateErweitert As System.Collections.Generic.List(Of String) = Nothing,
                            Optional ByVal showAllColumns As Boolean = False,
                            Optional ByVal doNotChangeVisibilityState As Boolean = False)
        Try
            For Each col As UltraGridColumn In band.Columns
                Dim bDoFormat As Boolean = True
                If Not doNotChangeVisibilityState Then
                    If col.DataType.ToString().ToLower().Trim() = db.typeGuid.ToLower().Trim() Then
                        col.Hidden = True
                    Else
                        col.Hidden = Not bOn
                    End If
                Else
                    If col.Hidden Then
                        bDoFormat = False
                    End If
                End If

                If bDoFormat Then
                    If col.DataType.ToString().ToLower().Trim() = db.typeString.ToLower().Trim() Then
                        col.CellAppearance.TextHAlign = HAlign.Left
                        col.Header.Appearance.TextHAlign = HAlign.Left

                    End If
                    If col.DataType.ToString().ToLower().Trim() = db.typeDouble.ToLower().Trim() Or
                        col.DataType.ToString().ToLower().Trim() = db.typeInt32.ToLower().Trim() Or
                        col.DataType.ToString().ToLower().Trim() = db.typeDecimal.ToLower().Trim() Then

                        col.CellAppearance.TextHAlign = HAlign.Right
                        col.Header.Appearance.TextHAlign = HAlign.Right
                    End If

                    If col.DataType.ToString().ToLower().Trim() = db.typeDate.ToLower().Trim() Or
                        col.DataType.ToString().ToLower().Trim() = db.typeDateTime.ToLower().Trim() Then

                        col.CellAppearance.TextHAlign = HAlign.Center
                        col.Header.Appearance.TextHAlign = HAlign.Center
                    End If

                    For Each colDeaktivate As String In lstColDeaktivate
                        band.Columns(colDeaktivate).Hidden = True
                    Next
                End If
            Next

            If Not bOn Then
                For Each col As String In lstColAktivate
                    band.Columns(col).Hidden = False
                Next
            End If

            If Not lstColAktivateErweitert Is Nothing Then
                For Each col As String In lstColAktivateErweitert
                    band.Columns(col).Hidden = False
                Next
            End If

            If showAllColumns Then
                For Each col As UltraGridColumn In band.Columns
                    Try
                        If Not col.IsChaptered Then
                            col.Hidden = False
                        End If
                    Catch ex As Exception
                        gen.GetEcxeptionGeneral(ex)
                    End Try
                Next
            End If

        Catch ex As Exception
            Throw New Exception("UI.gridErwSicht: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadLstIntReleased(ByRef ImageList1 As System.Windows.Forms.ImageList,
                                  ByRef grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            grid.DisplayLayout.ValueLists("IntReleased").ValueListItems.Clear()
            Dim itmFalse As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IntReleased").ValueListItems.Add(False, " ")
            Dim itmTrue As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IntReleased").ValueListItems.Add(True, " ")
            itmTrue.Appearance.Image = ImageList1.Images(0)
            itmTrue.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center

        Catch ex As Exception
            Throw New Exception("UI.loadLstIntReleased: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadLstIDTyp(ByRef ImageList1 As System.Windows.Forms.ImageList,
                                  ByRef grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            grid.DisplayLayout.ValueLists("IDTyp").ValueListItems.Clear()
            Dim itmFalse As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IDTyp").ValueListItems.Add("", "  ")
            Dim itmTrue As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IDTyp").ValueListItems.Add("K", " ")
            itmTrue.Appearance.Image = ImageList1.Images(0)
            itmTrue.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center

        Catch ex As Exception
            Throw New Exception("UI.loadLstIDTyp: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadLstBinInternxy(ByRef ImageList1 As System.Windows.Forms.ImageList,
                              ByRef grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            'grid.DisplayLayout.Bands(0).Columns("binIntern").CellAppearance.Image = ImageList1.Images(1)

            'grid.DisplayLayout.ValueLists("binIntern").ValueListItems.Clear()
            'Dim itmNull As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IntReleased").ValueListItems.Add(Nothing, " ")
            'itmNull.Appearance.Image = Nothing

            'Dim bytes() As Byte = Me.gen.StringToByte("xy")
            'Dim itmBytes As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("IntReleased").ValueListItems.Add(bytes, " ")
            'itmBytes.Appearance.Image = ImageList1.Images(0)
            'itmBytes.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center

            'For i As Integer = 0 To 10
            '    Dim itm As Infragistics.Win.ValueListItem = grid.DisplayLayout.ValueLists("binIntern").ValueListItems.Add(i, " ")
            '    If i = 0 Then
            '        itm.Appearance.Image = ImageList1.Images(1)
            '        itm.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center
            '    End If
            'Next

        Catch ex As Exception
            Throw New Exception("UI.loadLstBinInternxy: " + ex.ToString())
        End Try
    End Sub

    Public Function saveFileAs(ByVal file As String, ByVal dateiTyp As String) As Boolean
        Try
            If Me.gen.IsNull(dateiTyp) Then
                Dim cl As New QS2.functions.vb.functOld()
                dateiTyp = cl.GetFiletyp(file)
            End If

            Dim fileList As String = ""
            If LCase(dateiTyp) = LCase(".doc") Then
                fileList = "Microsoft Word Files (*.doc)|*.doc"
            ElseIf LCase(dateiTyp) = LCase(".docx") Then
                fileList = "Microsoft Word Xml-Files (*.doc)|*.docx"
            ElseIf LCase(dateiTyp) = LCase(".rtf") Then
                fileList = "rtf Files (*.Rtf)|*.rtf"
            ElseIf LCase(dateiTyp) = LCase(".xls") Then
                fileList = "xls Files (*.xls)|*.xls"
            ElseIf LCase(dateiTyp) = LCase(".xsd") Then
                fileList = "xsd Files (*.xsd)|*.xsd"
            ElseIf LCase(dateiTyp) = LCase(".txt") Then
                fileList = "Text Files (*.txt)|*.txt"
            ElseIf LCase(dateiTyp) = LCase(".pdf") Then
                fileList = "pdf Files (*.pdf)|*.pdf"
            ElseIf LCase(dateiTyp) = LCase(".zip") Then
                fileList = "zip Files (*.zip)|*.zip"
            ElseIf LCase(dateiTyp) = LCase(".rar") Then
                fileList = "rar Files (*.rar)|*.rar"
            ElseIf LCase(dateiTyp) = LCase(".ppt") Then
                fileList = "Power Point Files (*.ppt)|*.ppt"

            ElseIf LCase(dateiTyp) = LCase(".tif") Then
                fileList = "tif Files (*.tif)|*.tif"
            ElseIf LCase(dateiTyp) = LCase(".tiff") Then
                fileList = "tif Files (*.tiff)|*.tiff"
            ElseIf LCase(dateiTyp) = LCase(".bmp") Then
                fileList = "bmp Files (*.bmp)|*.bmp"
            ElseIf LCase(dateiTyp) = LCase(".jpg") Then
                fileList = "jpg Files (*.jpg)|*.jpg"
            ElseIf LCase(dateiTyp) = LCase(".jpeg") Then
                fileList = "jpeg Files (*.jpeg)|*.jpeg"
            ElseIf LCase(dateiTyp) = LCase(".gif") Then
                fileList = "gif Files (*.gif)|*.gif"

            ElseIf LCase(dateiTyp) = LCase(".mp3") Then
                fileList = "mp3 Files (*.mp3)|*.mp3"
            ElseIf LCase(dateiTyp) = LCase(".wav") Then
                fileList = "wav Files (*.wav)|*.wav"

            Else
                fileList = "All Files (*.*)|*.*|" +
                            "bmp Files (*.bmp)|*.bmp|" +
                            "gif Files (*.gif)|*.gif|" +
                            "ini Files (*.ini)|*.ini|" +
                            "jpeg Files (*.jpeg)|*.jpeg|" +
                            "jpg Files (*.jpg)|*.jpg|" +
                            "Microsoft Excel Files (*.xls)|*.xls|" +
                            "Microsoft Word Files (*.doc)|*.doc|" +
                            "pdf Files (*.pdf)|*.pdf|" +
                            "Power Point Files (*.ppt)|*.ppt|" +
                            "rar Files (*.rar)|*.rar|" +
                            "Text Files (*.txt)|*.txt|" +
                            "tif Files (*.tif)|*.tif|" +
                            "rtf Files (*.Rtf)|*.rtf" +
                            "xls Files (*.xls)|*.xls|" +
                            "xsd Files (*.xsd)|*.xsd|" +
                            "zip Files (*.zip)|*.zip|"

            End If

            Dim FileName As String = ""
            If file.Trim() <> "" Then
                FileName = System.IO.Path.GetFileNameWithoutExtension(file)
            End If

            Dim xmlOp As New clFolder
            Dim fileToSave As String = ""
            fileToSave = Me.SaveFileDialog(fileList, "", FileName.Trim())
            If Not Me.gen.IsNull(fileToSave) Then
                If System.IO.File.Exists(fileToSave) Then
                    System.IO.File.Delete(fileToSave)
                End If
                System.IO.File.Copy(file, fileToSave)
                doUI.doMessageBox2("FileSaved", "", "!")
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("UI.saveFileAs: " + ex.ToString())
        End Try
    End Function

    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String, FileName As String) As String
        Try
            Dim SaveFileD As New Windows.Forms.SaveFileDialog
            Dim File As String
            Dim Pfad As String

            SaveFileD.InitialDirectory = rootVerzeichnis
            SaveFileD.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
            SaveFileD.FilterIndex = 1
            SaveFileD.RestoreDirectory = True
            SaveFileD.FileName = FileName.Trim()

            If SaveFileD.ShowDialog() = DialogResult.OK Then
                File = SaveFileD.FileName
                Return File
            End If

        Catch ex As Exception
            Throw New Exception("UI.SaveFileDialog: " + ex.ToString())
        End Try
    End Function

End Class
