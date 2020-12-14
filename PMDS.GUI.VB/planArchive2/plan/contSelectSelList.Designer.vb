<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelectSelList
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntriesTmp", -1)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 0)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(955900011)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(955900292)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(957624478)
        Dim valueListItem31 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem32 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem33 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueList4 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(959010437)
        Dim ValueList5 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(101230219)
        Dim valueListItem34 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem35 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem36 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem37 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem38 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem39 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem40 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem41 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem42 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem43 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem44 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim valueListItem45 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueList6 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(101231296)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gridSelList = New QS2.Desktop.ControlManagment.BaseGrid()
        Me.DsClipboard1 = New PMDS.GUI.VB.dsClipboard()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.lblSelectNone = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.lblSelectAll = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.btnDel = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnAdd = New QS2.Desktop.ControlManagment.BaseButton()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSelectSave = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnAbort = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnEdit = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnSave = New QS2.Desktop.ControlManagment.BaseButton()
        Me.PanelCenter = New System.Windows.Forms.Panel()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CompPlan1 = New PMDS.GUI.VB.compPlan(Me.components)
        CType(Me.gridSelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsClipboard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridSelList
        '
        Me.gridSelList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridSelList.AutoWork = True
        Me.gridSelList.DataMember = "tblSelListEntriesTmp"
        Me.gridSelList.DataSource = Me.DsClipboard1
        Appearance1.BackColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Appearance = Appearance1
        Me.gridSelList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 52
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 421
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 62
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 112
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 355
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn8.DataType = GetType(Boolean)
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Width = 82
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Me.gridSelList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSelList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSelList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSelList.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen."
        Me.gridSelList.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.gridSelList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSelList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSelList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridSelList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance2.BorderColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Override.SummaryFooterAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gridSelList.DisplayLayout.Override.SummaryValueAppearance = Appearance4
        Me.gridSelList.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        ValueList1.Key = "Klienten"
        ValueList2.Key = "Kostenträger"
        ValueList3.Key = "MWSt"
        valueListItem31.DataValue = 10
        valueListItem31.DisplayText = "10"
        valueListItem32.DataValue = 20
        valueListItem32.DisplayText = "20"
        valueListItem33.DataValue = 30
        valueListItem33.DisplayText = "30"
        ValueList3.ValueListItems.AddRange(New Infragistics.Win.ValueListItem() {valueListItem31, valueListItem32, valueListItem33})
        ValueList4.Key = "eKonto"
        ValueList5.Key = "month"
        valueListItem34.DataValue = 1
        valueListItem34.DisplayText = "1"
        valueListItem35.DataValue = 2
        valueListItem35.DisplayText = "2"
        valueListItem36.DataValue = 3
        valueListItem36.DisplayText = "3"
        valueListItem37.DataValue = 4
        valueListItem37.DisplayText = "4"
        valueListItem38.DataValue = 5
        valueListItem38.DisplayText = "5"
        valueListItem39.DataValue = 6
        valueListItem39.DisplayText = "6"
        valueListItem40.DataValue = 7
        valueListItem40.DisplayText = "7"
        valueListItem41.DataValue = 8
        valueListItem41.DisplayText = "8"
        valueListItem42.DataValue = 9
        valueListItem42.DisplayText = "9"
        valueListItem43.DataValue = 10
        valueListItem43.DisplayText = "10"
        valueListItem44.DataValue = 11
        valueListItem44.DisplayText = "11"
        valueListItem45.DataValue = 12
        valueListItem45.DisplayText = "12"
        ValueList5.ValueListItems.AddRange(New Infragistics.Win.ValueListItem() {valueListItem34, valueListItem35, valueListItem36, valueListItem37, valueListItem38, valueListItem39, valueListItem40, valueListItem41, valueListItem42, valueListItem43, valueListItem44, valueListItem45})
        ValueList6.Key = "year"
        Me.gridSelList.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3, ValueList4, ValueList5, ValueList6})
        Me.gridSelList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridSelList.Location = New System.Drawing.Point(3, 1)
        Me.gridSelList.Name = "gridSelList"
        Me.gridSelList.Size = New System.Drawing.Size(495, 298)
        Me.gridSelList.TabIndex = 2
        Me.gridSelList.Text = "Kliniken"
        '
        'DsClipboard1
        '
        Me.DsClipboard1.DataSetName = "dsClipboard"
        Me.DsClipboard1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.lblSelectNone)
        Me.PanelTop.Controls.Add(Me.lblSelectAll)
        Me.PanelTop.Controls.Add(Me.txtSearch)
        Me.PanelTop.Controls.Add(Me.lblSearch)
        Me.PanelTop.Controls.Add(Me.btnDel)
        Me.PanelTop.Controls.Add(Me.btnAdd)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(503, 31)
        Me.PanelTop.TabIndex = 3
        '
        'lblSelectNone
        '
        Appearance5.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance5.FontData.SizeInPoints = 8.0!
        Appearance5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSelectNone.Appearance = Appearance5
        Me.lblSelectNone.AutoSize = True
        Appearance6.FontData.UnderlineAsString = "True"
        Me.lblSelectNone.HotTrackAppearance = Appearance6
        Me.lblSelectNone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectNone.Location = New System.Drawing.Point(340, 9)
        Me.lblSelectNone.Margin = New System.Windows.Forms.Padding(4)
        Me.lblSelectNone.Name = "lblSelectNone"
        Me.lblSelectNone.Size = New System.Drawing.Size(32, 14)
        Me.lblSelectNone.TabIndex = 425
        Me.lblSelectNone.Tag = "Res.ID.SelectNone"
        Me.lblSelectNone.Text = "Keine"
        Me.lblSelectNone.UseAppStyling = False
        Me.lblSelectNone.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblSelectAll
        '
        Appearance7.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance7.FontData.SizeInPoints = 8.0!
        Appearance7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSelectAll.Appearance = Appearance7
        Me.lblSelectAll.AutoSize = True
        Appearance8.FontData.UnderlineAsString = "True"
        Me.lblSelectAll.HotTrackAppearance = Appearance8
        Me.lblSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectAll.Location = New System.Drawing.Point(315, 9)
        Me.lblSelectAll.Margin = New System.Windows.Forms.Padding(4)
        Me.lblSelectAll.Name = "lblSelectAll"
        Me.lblSelectAll.Size = New System.Drawing.Size(23, 14)
        Me.lblSelectAll.TabIndex = 424
        Me.lblSelectAll.Tag = "Res.ID.SelectAll"
        Me.lblSelectAll.Text = "Alle"
        Me.lblSelectAll.UseAppStyling = False
        Me.lblSelectAll.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'txtSearch
        '
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColor2 = System.Drawing.Color.White
        Appearance9.BackColorDisabled = System.Drawing.Color.White
        Appearance9.BackColorDisabled2 = System.Drawing.Color.White
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.ItalicAsString = "False"
        Appearance9.FontData.Name = "Microsoft Sans Serif"
        Appearance9.FontData.SizeInPoints = 8.25!
        Appearance9.FontData.StrikeoutAsString = "False"
        Appearance9.FontData.UnderlineAsString = "False"
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtSearch.Appearance = Appearance9
        Me.txtSearch.AutoSize = False
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(46, 4)
        Me.txtSearch.MaxLength = 0
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(261, 23)
        Me.txtSearch.TabIndex = 422
        Me.txtSearch.Tag = "Vorname"
        '
        'lblSearch
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblSearch.Appearance = Appearance10
        Me.lblSearch.Location = New System.Drawing.Point(5, 7)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(49, 17)
        Me.lblSearch.TabIndex = 423
        Me.lblSearch.Tag = "ResID.Search"
        Me.lblSearch.Text = "Suche"
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDel.Appearance = Appearance11
        Me.btnDel.AutoWorkLayout = False
        Me.btnDel.IsStandardControl = False
        Me.btnDel.Location = New System.Drawing.Point(466, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(28, 26)
        Me.btnDel.TabIndex = 15
        Me.btnDel.Tag = ""
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAdd.Appearance = Appearance12
        Me.btnAdd.AutoWorkLayout = False
        Me.btnAdd.IsStandardControl = False
        Me.btnAdd.Location = New System.Drawing.Point(438, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(28, 26)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Tag = ""
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnSelectSave)
        Me.PanelBottom.Controls.Add(Me.btnEdit)
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Controls.Add(Me.btnAbort)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 333)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(503, 34)
        Me.PanelBottom.TabIndex = 4
        '
        'btnSelectSave
        '
        Me.btnSelectSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSelectSave.Appearance = Appearance13
        Me.btnSelectSave.AutoWorkLayout = False
        Me.btnSelectSave.IsStandardControl = False
        Me.btnSelectSave.Location = New System.Drawing.Point(414, 3)
        Me.btnSelectSave.Name = "btnSelectSave"
        Me.btnSelectSave.Size = New System.Drawing.Size(79, 27)
        Me.btnSelectSave.TabIndex = 10
        Me.btnSelectSave.Tag = "ResID.OK"
        Me.btnSelectSave.Text = "OK"
        '
        'btnAbort
        '
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAbort.Appearance = Appearance16
        Me.btnAbort.AutoWorkLayout = False
        Me.btnAbort.IsStandardControl = False
        Me.btnAbort.Location = New System.Drawing.Point(6, 4)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(83, 27)
        Me.btnAbort.TabIndex = 2
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'btnEdit
        '
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnEdit.Appearance = Appearance14
        Me.btnEdit.AutoWorkLayout = False
        Me.btnEdit.IsStandardControl = False
        Me.btnEdit.Location = New System.Drawing.Point(5, 4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(85, 27)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Tag = "ResID.Edit"
        Me.btnEdit.Text = "Editieren"
        '
        'btnSave
        '
        Appearance15.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSave.Appearance = Appearance15
        Me.btnSave.AutoWorkLayout = False
        Me.btnSave.IsStandardControl = False
        Me.btnSave.Location = New System.Drawing.Point(90, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 27)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'PanelCenter
        '
        Me.PanelCenter.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenter.Controls.Add(Me.gridSelList)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 31)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(503, 302)
        Me.PanelCenter.TabIndex = 5
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'contSelectSelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PanelCenter)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top)
        Me.Name = "contSelectSelList"
        Me.Size = New System.Drawing.Size(503, 367)
        CType(Me.gridSelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsClipboard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents gridSelList As QS2.Desktop.ControlManagment.BaseGrid
    Friend WithEvents PanelTop As Windows.Forms.Panel
    Friend WithEvents PanelBottom As Windows.Forms.Panel
    Friend WithEvents PanelCenter As Windows.Forms.Panel
    Public WithEvents btnSelectSave As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Friend WithEvents DsClipboard1 As dsClipboard
    Friend WithEvents CompPlan1 As compPlan
    Public WithEvents btnDel As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents btnAdd As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents btnAbort As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents btnSave As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents btnEdit As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblSelectNone As qs2.Desktop.ControlManagment.BaseLabel
    Friend WithEvents lblSelectAll As qs2.Desktop.ControlManagment.BaseLabel
End Class
