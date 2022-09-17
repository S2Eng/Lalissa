'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				FormMain.Designer.cs
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Drawing
Imports System

Partial Class contTxtEditor2
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Me._textControl = New TXTextControl.TextControl()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo
        Me.rulerBar2 = New TXTextControl.RulerBar()
        Me.rulerBar1 = New TXTextControl.RulerBar()
        Me.buttonBar1 = New TXTextControl.ButtonBar()
        Me.statusBar1 = New TXTextControl.StatusBar()
        Me._menuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_New = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.recentFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFile_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_SaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_Export = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFile_PageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_PrintPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_Print = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFile_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEdit_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEdit_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_SelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEdit_Find = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Replace = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem16 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEdit_Hyperlink = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit_Target = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_PageLayout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Draft = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuView_HeadersAndFooters = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuView_Toolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_ButtonBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_StatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_HorizontalRuler = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_VerticalRuler = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuView_TextFrameMarkerLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_DocumentTargetMarkers = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem19 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuView_Zoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_75 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_150 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_200 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_Zoom_300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuView_FormLayout = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuView_FormLayout_LTR = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuView_FormLayout_RTL = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInsert_Image = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert_TextFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_pageNum = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuItm_page_top = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuItm_page_bottom = New System.Windows.Forms.ToolStripMenuItem()
        Me._sep_pageNum01 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuPageNum_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSep_mnuInsert1 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuInsert_Fields = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertMergeField = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField_IF = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField_inclText = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField_date = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField_Next = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_insertSpecialField_NextIf = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_highlightMergeFields = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuInsert_Fields_showFieldCodes = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuInsert_Fields_showFieldText = New System.Windows.Forms.ToolStripMenuItem()
        Me._sep_field01 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuInsert_Fields_deleteField = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSep_mnuInsert2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInsert_Hyperlink = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert_Target = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSep_mnuInsert3 = New System.Windows.Forms.ToolStripSeparator()
        Me.sectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_Character = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_Paragraph = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_Attributes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_IncreaseLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_DecreaseLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem28 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormat_List_ArabicNumbers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_CapitalLetters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_Letters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_RomanNumbers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_SmallRomanNumbers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_List_Bullets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_Styles = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormat_HeadersAndFooters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_Columns = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_pageframe = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_Tabs = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem20 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormat_Image = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormat_TextFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormat_SetLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Insert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Insert_Table = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem21 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTable_Insert_ColumnToTheLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Insert_ColumnToTheRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem24 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTable_Insert_RowAbove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Insert_RowBelow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Table = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Column = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Rows = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Cells = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Cells_shiftLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Cells_entireRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Delete_Cells_entireColumn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Select = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Select_Table = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Select_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Select_Column = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Select_Cell = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Merge_Cells = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Split_Cells = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Split = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Split_Above = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_Split_Below = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTable_GridLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSep_mnuTable1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTable_Properties = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions_HTML = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions_PDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp_AboutTXTextControlWords = New System.Windows.Forms.ToolStripMenuItem()
        Me._toolStrip = New System.Windows.Forms.ToolStrip()
        Me.toolStripNewFile = New System.Windows.Forms.ToolStripButton()
        Me.toolStripOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSave = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPrintPreview = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripCut = New System.Windows.Forms.ToolStripButton()
        Me.toolStripCopy = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPaste = New System.Windows.Forms.ToolStripButton()
        Me.toolStripDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripUndo = New System.Windows.Forms.ToolStripButton()
        Me.toolStripRedo = New System.Windows.Forms.ToolStripButton()
        Me.toolStripFind = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator444 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripMarginsAndPaper = New System.Windows.Forms.ToolStripButton()
        Me.toolStripHeadersAndFooters = New System.Windows.Forms.ToolStripButton()
        Me.toolStripColumns = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPageBorders = New System.Windows.Forms.ToolStripButton()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me._contextMenuApplicationFields = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me._fieldPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._deleteFieldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelTxtEditor = New System.Windows.Forms.Panel()
        Me.toolStripContainer1.ContentPanel.SuspendLayout()
        Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.toolStripContainer1.SuspendLayout()
        Me._menuStrip.SuspendLayout()
        Me._toolStrip.SuspendLayout()
        Me._contextMenuApplicationFields.SuspendLayout()
        Me.PanelTxtEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStripContainer1
        '
        Me.toolStripContainer1.BottomToolStripPanelVisible = False
        '
        'toolStripContainer1.ContentPanel
        '
        Me.toolStripContainer1.ContentPanel.AutoScroll = True
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.PanelTxtEditor)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.rulerBar2)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.rulerBar1)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.buttonBar1)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.statusBar1)
        Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(958, 608)
        Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolStripContainer1.LeftToolStripPanelVisible = False
        Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.toolStripContainer1.Name = "toolStripContainer1"
        Me.toolStripContainer1.RightToolStripPanelVisible = False
        Me.toolStripContainer1.Size = New System.Drawing.Size(958, 657)
        Me.toolStripContainer1.TabIndex = 0
        Me.toolStripContainer1.Text = "toolStripContainer1"
        '
        'toolStripContainer1.TopToolStripPanel
        '
        Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me._menuStrip)
        Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me._toolStrip)
        '
        '_textControl
        '
        Me._textControl.AllowDrag = True
        Me._textControl.AllowDrop = True
        Me._textControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me._textControl.DocumentTargetMarkers = True
        Me._textControl.Font = New System.Drawing.Font("Arial", 10.0!)
        Me._textControl.Location = New System.Drawing.Point(0, 0)
        Me._textControl.Name = "_textControl"
        Me._textControl.PageMargins.Bottom = 79.03R
        Me._textControl.PageMargins.Left = 79.03R
        Me._textControl.PageMargins.Right = 79.03R
        Me._textControl.PageMargins.Top = 79.03R
        Me._textControl.Size = New System.Drawing.Size(933, 533)
        Me._textControl.TabIndex = 0
        '
        'rulerBar2
        '
        Me.rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left
        Me.rulerBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.rulerBar2.Location = New System.Drawing.Point(0, 53)
        Me.rulerBar2.Name = "rulerBar2"
        Me.rulerBar2.Size = New System.Drawing.Size(25, 533)
        Me.rulerBar2.TabIndex = 3
        Me.rulerBar2.Text = "rulerBar2"
        '
        'rulerBar1
        '
        Me.rulerBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.rulerBar1.Location = New System.Drawing.Point(0, 28)
        Me.rulerBar1.Name = "rulerBar1"
        Me.rulerBar1.Size = New System.Drawing.Size(958, 25)
        Me.rulerBar1.TabIndex = 2
        Me.rulerBar1.Text = "rulerBar1"
        '
        'buttonBar1
        '
        Me.buttonBar1.BackColor = System.Drawing.SystemColors.Control
        Me.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonBar1.Location = New System.Drawing.Point(0, 0)
        Me.buttonBar1.Name = "buttonBar1"
        Me.buttonBar1.Size = New System.Drawing.Size(958, 28)
        Me.buttonBar1.TabIndex = 0
        Me.buttonBar1.Text = "buttonBar1"
        '
        'statusBar1
        '
        Me.statusBar1.BackColor = System.Drawing.SystemColors.Control
        Me.statusBar1.ColumnText = "Column "
        Me.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statusBar1.LineText = "Line "
        Me.statusBar1.Location = New System.Drawing.Point(0, 586)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.PageText = "Page "
        Me.statusBar1.SectionText = "Section "
        Me.statusBar1.Size = New System.Drawing.Size(958, 22)
        Me.statusBar1.TabIndex = 4
        '
        '_menuStrip
        '
        Me._menuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me._menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuInsert, Me.mnuFormat, Me.mnuTable, Me.mnuOptions, Me.mnuHelp})
        Me._menuStrip.Location = New System.Drawing.Point(0, 0)
        Me._menuStrip.Name = "_menuStrip"
        Me._menuStrip.Size = New System.Drawing.Size(958, 24)
        Me._menuStrip.TabIndex = 1
        Me._menuStrip.Text = "menuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile_New, Me.mnuFile_Open, Me.recentFilesToolStripMenuItem, Me.toolStripMenuItem1, Me.mnuFile_Save, Me.mnuFile_SaveAs, Me.mnuFile_Export, Me.menuItem6, Me.mnuFile_PageSetup, Me.mnuFile_PrintPreview, Me.mnuFile_Print, Me.menuItem10, Me.mnuFile_Exit})
        Me.mnuFile.MergeIndex = 0
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFile_New
        '
        Me.mnuFile_New.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.newpage
        Me.mnuFile_New.Name = "mnuFile_New"
        Me.mnuFile_New.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFile_New.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_New.Text = "&New"
        '
        'mnuFile_Open
        '
        Me.mnuFile_Open.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.open
        Me.mnuFile_Open.Name = "mnuFile_Open"
        Me.mnuFile_Open.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuFile_Open.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_Open.Text = "&Open..."
        '
        'recentFilesToolStripMenuItem
        '
        Me.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem"
        Me.recentFilesToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.recentFilesToolStripMenuItem.Text = "&Recent Files"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(154, 6)
        '
        'mnuFile_Save
        '
        Me.mnuFile_Save.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.save
        Me.mnuFile_Save.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuFile_Save.MergeIndex = 1
        Me.mnuFile_Save.Name = "mnuFile_Save"
        Me.mnuFile_Save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuFile_Save.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_Save.Text = "&Save"
        '
        'mnuFile_SaveAs
        '
        Me.mnuFile_SaveAs.MergeIndex = 2
        Me.mnuFile_SaveAs.Name = "mnuFile_SaveAs"
        Me.mnuFile_SaveAs.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_SaveAs.Text = "Save &As..."
        '
        'mnuFile_Export
        '
        Me.mnuFile_Export.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources._export
        Me.mnuFile_Export.MergeIndex = 3
        Me.mnuFile_Export.Name = "mnuFile_Export"
        Me.mnuFile_Export.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_Export.Text = "&Export..."
        '
        'menuItem6
        '
        Me.menuItem6.MergeIndex = 4
        Me.menuItem6.Name = "menuItem6"
        Me.menuItem6.Size = New System.Drawing.Size(154, 6)
        '
        'mnuFile_PageSetup
        '
        Me.mnuFile_PageSetup.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagedialog
        Me.mnuFile_PageSetup.MergeIndex = 5
        Me.mnuFile_PageSetup.Name = "mnuFile_PageSetup"
        Me.mnuFile_PageSetup.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_PageSetup.Text = "Page Se&tup..."
        '
        'mnuFile_PrintPreview
        '
        Me.mnuFile_PrintPreview.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.printpreview
        Me.mnuFile_PrintPreview.MergeIndex = 6
        Me.mnuFile_PrintPreview.Name = "mnuFile_PrintPreview"
        Me.mnuFile_PrintPreview.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_PrintPreview.Text = "Print Pre&view..."
        '
        'mnuFile_Print
        '
        Me.mnuFile_Print.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.print
        Me.mnuFile_Print.MergeIndex = 7
        Me.mnuFile_Print.Name = "mnuFile_Print"
        Me.mnuFile_Print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuFile_Print.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_Print.Text = "&Print..."
        '
        'menuItem10
        '
        Me.menuItem10.MergeIndex = 8
        Me.menuItem10.Name = "menuItem10"
        Me.menuItem10.Size = New System.Drawing.Size(154, 6)
        '
        'mnuFile_Exit
        '
        Me.mnuFile_Exit.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources._exit
        Me.mnuFile_Exit.Name = "mnuFile_Exit"
        Me.mnuFile_Exit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.mnuFile_Exit.Size = New System.Drawing.Size(157, 22)
        Me.mnuFile_Exit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit_Undo, Me.mnuEdit_Redo, Me.menuItem4, Me.mnuEdit_Cut, Me.mnuEdit_Copy, Me.mnuEdit_Paste, Me.menuItem9, Me.mnuEdit_Delete, Me.mnuEdit_SelectAll, Me.menuItem13, Me.mnuEdit_Find, Me.mnuEdit_Replace, Me.menuItem16, Me.mnuEdit_Hyperlink, Me.mnuEdit_Target})
        Me.mnuEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuEdit.MergeIndex = 1
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuEdit_Undo
        '
        Me.mnuEdit_Undo.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.undo
        Me.mnuEdit_Undo.MergeIndex = 0
        Me.mnuEdit_Undo.Name = "mnuEdit_Undo"
        Me.mnuEdit_Undo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuEdit_Undo.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Undo.Text = "&Undo"
        '
        'mnuEdit_Redo
        '
        Me.mnuEdit_Redo.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.redo
        Me.mnuEdit_Redo.MergeIndex = 1
        Me.mnuEdit_Redo.Name = "mnuEdit_Redo"
        Me.mnuEdit_Redo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.mnuEdit_Redo.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Redo.Text = "&Redo"
        '
        'menuItem4
        '
        Me.menuItem4.MergeIndex = 2
        Me.menuItem4.Name = "menuItem4"
        Me.menuItem4.Size = New System.Drawing.Size(173, 6)
        '
        'mnuEdit_Cut
        '
        Me.mnuEdit_Cut.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.cut
        Me.mnuEdit_Cut.MergeIndex = 3
        Me.mnuEdit_Cut.Name = "mnuEdit_Cut"
        Me.mnuEdit_Cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuEdit_Cut.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Cut.Text = "Cu&t"
        '
        'mnuEdit_Copy
        '
        Me.mnuEdit_Copy.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.copy
        Me.mnuEdit_Copy.MergeIndex = 4
        Me.mnuEdit_Copy.Name = "mnuEdit_Copy"
        Me.mnuEdit_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuEdit_Copy.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Copy.Text = "&Copy"
        '
        'mnuEdit_Paste
        '
        Me.mnuEdit_Paste.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.paste
        Me.mnuEdit_Paste.MergeIndex = 5
        Me.mnuEdit_Paste.Name = "mnuEdit_Paste"
        Me.mnuEdit_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuEdit_Paste.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Paste.Text = "&Paste"
        '
        'menuItem9
        '
        Me.menuItem9.MergeIndex = 6
        Me.menuItem9.Name = "menuItem9"
        Me.menuItem9.Size = New System.Drawing.Size(173, 6)
        '
        'mnuEdit_Delete
        '
        Me.mnuEdit_Delete.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.delete
        Me.mnuEdit_Delete.MergeIndex = 7
        Me.mnuEdit_Delete.Name = "mnuEdit_Delete"
        Me.mnuEdit_Delete.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Delete.Text = "&Delete"
        '
        'mnuEdit_SelectAll
        '
        Me.mnuEdit_SelectAll.MergeIndex = 8
        Me.mnuEdit_SelectAll.Name = "mnuEdit_SelectAll"
        Me.mnuEdit_SelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnuEdit_SelectAll.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_SelectAll.Text = "Select &All"
        '
        'menuItem13
        '
        Me.menuItem13.MergeIndex = 9
        Me.menuItem13.Name = "menuItem13"
        Me.menuItem13.Size = New System.Drawing.Size(173, 6)
        '
        'mnuEdit_Find
        '
        Me.mnuEdit_Find.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.find
        Me.mnuEdit_Find.MergeIndex = 10
        Me.mnuEdit_Find.Name = "mnuEdit_Find"
        Me.mnuEdit_Find.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuEdit_Find.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Find.Text = "&Find"
        '
        'mnuEdit_Replace
        '
        Me.mnuEdit_Replace.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.replace
        Me.mnuEdit_Replace.MergeIndex = 11
        Me.mnuEdit_Replace.Name = "mnuEdit_Replace"
        Me.mnuEdit_Replace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuEdit_Replace.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Replace.Text = "R&eplace"
        '
        'menuItem16
        '
        Me.menuItem16.MergeIndex = 12
        Me.menuItem16.Name = "menuItem16"
        Me.menuItem16.Size = New System.Drawing.Size(173, 6)
        '
        'mnuEdit_Hyperlink
        '
        Me.mnuEdit_Hyperlink.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.edithyperlink
        Me.mnuEdit_Hyperlink.MergeIndex = 13
        Me.mnuEdit_Hyperlink.Name = "mnuEdit_Hyperlink"
        Me.mnuEdit_Hyperlink.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuEdit_Hyperlink.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Hyperlink.Text = "&Hyperlink..."
        '
        'mnuEdit_Target
        '
        Me.mnuEdit_Target.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.insertbookmark
        Me.mnuEdit_Target.MergeIndex = 14
        Me.mnuEdit_Target.Name = "mnuEdit_Target"
        Me.mnuEdit_Target.Size = New System.Drawing.Size(176, 22)
        Me.mnuEdit_Target.Text = "Tar&get…"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuView_PageLayout, Me.mnuView_Draft, Me.menuItem8, Me.mnuView_HeadersAndFooters, Me.menuItem12, Me.mnuView_Toolbar, Me.mnuView_ButtonBar, Me.mnuView_StatusBar, Me.mnuView_HorizontalRuler, Me.mnuView_VerticalRuler, Me.toolStripMenuItem2, Me.mnuView_TextFrameMarkerLines, Me.mnuView_DocumentTargetMarkers, Me.menuItem19, Me.mnuView_Zoom, Me.toolStripMenuItem4, Me._mnuView_FormLayout})
        Me.mnuView.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuView.MergeIndex = 2
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(44, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuView_PageLayout
        '
        Me.mnuView_PageLayout.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pageviewprint
        Me.mnuView_PageLayout.MergeIndex = 1
        Me.mnuView_PageLayout.Name = "mnuView_PageLayout"
        Me.mnuView_PageLayout.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.mnuView_PageLayout.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_PageLayout.Text = "&Page Layout"
        '
        'mnuView_Draft
        '
        Me.mnuView_Draft.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pageviewnormal
        Me.mnuView_Draft.MergeIndex = 0
        Me.mnuView_Draft.Name = "mnuView_Draft"
        Me.mnuView_Draft.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.mnuView_Draft.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_Draft.Text = "&Draft"
        '
        'menuItem8
        '
        Me.menuItem8.MergeIndex = 2
        Me.menuItem8.Name = "menuItem8"
        Me.menuItem8.Size = New System.Drawing.Size(199, 6)
        '
        'mnuView_HeadersAndFooters
        '
        Me.mnuView_HeadersAndFooters.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.header
        Me.mnuView_HeadersAndFooters.MergeIndex = 3
        Me.mnuView_HeadersAndFooters.Name = "mnuView_HeadersAndFooters"
        Me.mnuView_HeadersAndFooters.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_HeadersAndFooters.Text = "&Headers and Footers"
        '
        'menuItem12
        '
        Me.menuItem12.MergeIndex = 4
        Me.menuItem12.Name = "menuItem12"
        Me.menuItem12.Size = New System.Drawing.Size(199, 6)
        '
        'mnuView_Toolbar
        '
        Me.mnuView_Toolbar.MergeIndex = 5
        Me.mnuView_Toolbar.Name = "mnuView_Toolbar"
        Me.mnuView_Toolbar.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_Toolbar.Text = "&Toolbar"
        '
        'mnuView_ButtonBar
        '
        Me.mnuView_ButtonBar.MergeIndex = 6
        Me.mnuView_ButtonBar.Name = "mnuView_ButtonBar"
        Me.mnuView_ButtonBar.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_ButtonBar.Text = "&Button Bar"
        '
        'mnuView_StatusBar
        '
        Me.mnuView_StatusBar.MergeIndex = 7
        Me.mnuView_StatusBar.Name = "mnuView_StatusBar"
        Me.mnuView_StatusBar.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_StatusBar.Text = "&Status Bar"
        '
        'mnuView_HorizontalRuler
        '
        Me.mnuView_HorizontalRuler.MergeIndex = 8
        Me.mnuView_HorizontalRuler.Name = "mnuView_HorizontalRuler"
        Me.mnuView_HorizontalRuler.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_HorizontalRuler.Text = "H&orizontal Ruler"
        '
        'mnuView_VerticalRuler
        '
        Me.mnuView_VerticalRuler.MergeIndex = 9
        Me.mnuView_VerticalRuler.Name = "mnuView_VerticalRuler"
        Me.mnuView_VerticalRuler.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_VerticalRuler.Text = "&Vertical Ruler"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(199, 6)
        '
        'mnuView_TextFrameMarkerLines
        '
        Me.mnuView_TextFrameMarkerLines.Checked = True
        Me.mnuView_TextFrameMarkerLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuView_TextFrameMarkerLines.MergeIndex = 8
        Me.mnuView_TextFrameMarkerLines.Name = "mnuView_TextFrameMarkerLines"
        Me.mnuView_TextFrameMarkerLines.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_TextFrameMarkerLines.Text = "Text &Frame Marker Lines"
        '
        'mnuView_DocumentTargetMarkers
        '
        Me.mnuView_DocumentTargetMarkers.Name = "mnuView_DocumentTargetMarkers"
        Me.mnuView_DocumentTargetMarkers.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_DocumentTargetMarkers.Text = "Target &Markers"
        '
        'menuItem19
        '
        Me.menuItem19.MergeIndex = 10
        Me.menuItem19.Name = "menuItem19"
        Me.menuItem19.Size = New System.Drawing.Size(199, 6)
        '
        'mnuView_Zoom
        '
        Me.mnuView_Zoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuView_Zoom_25, Me.mnuView_Zoom_50, Me.mnuView_Zoom_75, Me.mnuView_Zoom_100, Me.mnuView_Zoom_150, Me.mnuView_Zoom_200, Me.mnuView_Zoom_300})
        Me.mnuView_Zoom.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.zoom
        Me.mnuView_Zoom.MergeIndex = 11
        Me.mnuView_Zoom.Name = "mnuView_Zoom"
        Me.mnuView_Zoom.Size = New System.Drawing.Size(202, 22)
        Me.mnuView_Zoom.Text = "&Zoom"
        '
        'mnuView_Zoom_25
        '
        Me.mnuView_Zoom_25.MergeIndex = 0
        Me.mnuView_Zoom_25.Name = "mnuView_Zoom_25"
        Me.mnuView_Zoom_25.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_25.Text = "&1  25%"
        '
        'mnuView_Zoom_50
        '
        Me.mnuView_Zoom_50.MergeIndex = 1
        Me.mnuView_Zoom_50.Name = "mnuView_Zoom_50"
        Me.mnuView_Zoom_50.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_50.Text = "&2  50%"
        '
        'mnuView_Zoom_75
        '
        Me.mnuView_Zoom_75.MergeIndex = 2
        Me.mnuView_Zoom_75.Name = "mnuView_Zoom_75"
        Me.mnuView_Zoom_75.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_75.Text = "&3  75%"
        '
        'mnuView_Zoom_100
        '
        Me.mnuView_Zoom_100.MergeIndex = 3
        Me.mnuView_Zoom_100.Name = "mnuView_Zoom_100"
        Me.mnuView_Zoom_100.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_100.Text = "&4  100%"
        '
        'mnuView_Zoom_150
        '
        Me.mnuView_Zoom_150.MergeIndex = 4
        Me.mnuView_Zoom_150.Name = "mnuView_Zoom_150"
        Me.mnuView_Zoom_150.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_150.Text = "&5  150%"
        '
        'mnuView_Zoom_200
        '
        Me.mnuView_Zoom_200.MergeIndex = 5
        Me.mnuView_Zoom_200.Name = "mnuView_Zoom_200"
        Me.mnuView_Zoom_200.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_200.Text = "&6  200%"
        '
        'mnuView_Zoom_300
        '
        Me.mnuView_Zoom_300.MergeIndex = 6
        Me.mnuView_Zoom_300.Name = "mnuView_Zoom_300"
        Me.mnuView_Zoom_300.Size = New System.Drawing.Size(114, 22)
        Me.mnuView_Zoom_300.Text = "&7  300%"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(199, 6)
        '
        '_mnuView_FormLayout
        '
        Me._mnuView_FormLayout.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuView_FormLayout_LTR, Me._mnuView_FormLayout_RTL})
        Me._mnuView_FormLayout.Name = "_mnuView_FormLayout"
        Me._mnuView_FormLayout.Size = New System.Drawing.Size(202, 22)
        Me._mnuView_FormLayout.Text = "&Form Layout"
        '
        '_mnuView_FormLayout_LTR
        '
        Me._mnuView_FormLayout_LTR.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.formlayoutltr
        Me._mnuView_FormLayout_LTR.Name = "_mnuView_FormLayout_LTR"
        Me._mnuView_FormLayout_LTR.Size = New System.Drawing.Size(139, 22)
        Me._mnuView_FormLayout_LTR.Text = "&Left to Right"
        '
        '_mnuView_FormLayout_RTL
        '
        Me._mnuView_FormLayout_RTL.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.formlayoutrtl
        Me._mnuView_FormLayout_RTL.Name = "_mnuView_FormLayout_RTL"
        Me._mnuView_FormLayout_RTL.Size = New System.Drawing.Size(139, 22)
        Me._mnuView_FormLayout_RTL.Text = "&Right to Left"
        '
        'mnuInsert
        '
        Me.mnuInsert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInsert_File, Me.menuItem3, Me.mnuInsert_Image, Me.mnuInsert_TextFrame, Me._mnuInsert_pageNum, Me.toolStripSep_mnuInsert1, Me._mnuInsert_Fields, Me.toolStripSep_mnuInsert2, Me.mnuInsert_Hyperlink, Me.mnuInsert_Target, Me.toolStripSep_mnuInsert3, Me.sectionToolStripMenuItem})
        Me.mnuInsert.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuInsert.MergeIndex = 3
        Me.mnuInsert.Name = "mnuInsert"
        Me.mnuInsert.Size = New System.Drawing.Size(48, 20)
        Me.mnuInsert.Text = "&Insert"
        '
        'mnuInsert_File
        '
        Me.mnuInsert_File.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.insertfile
        Me.mnuInsert_File.MergeIndex = 0
        Me.mnuInsert_File.Name = "mnuInsert_File"
        Me.mnuInsert_File.Size = New System.Drawing.Size(147, 22)
        Me.mnuInsert_File.Text = "&File..."
        '
        'menuItem3
        '
        Me.menuItem3.MergeIndex = 1
        Me.menuItem3.Name = "menuItem3"
        Me.menuItem3.Size = New System.Drawing.Size(144, 6)
        '
        'mnuInsert_Image
        '
        Me.mnuInsert_Image.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.image
        Me.mnuInsert_Image.MergeIndex = 2
        Me.mnuInsert_Image.Name = "mnuInsert_Image"
        Me.mnuInsert_Image.Size = New System.Drawing.Size(147, 22)
        Me.mnuInsert_Image.Text = "&Image..."
        '
        'mnuInsert_TextFrame
        '
        Me.mnuInsert_TextFrame.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.textframe
        Me.mnuInsert_TextFrame.MergeIndex = 3
        Me.mnuInsert_TextFrame.Name = "mnuInsert_TextFrame"
        Me.mnuInsert_TextFrame.Size = New System.Drawing.Size(147, 22)
        Me.mnuInsert_TextFrame.Text = "Te&xt Frame"
        '
        '_mnuInsert_pageNum
        '
        Me._mnuInsert_pageNum.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuItm_page_top, Me._mnuItm_page_bottom, Me._sep_pageNum01, Me._mnuPageNum_delete})
        Me._mnuInsert_pageNum.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.insertpagenumber
        Me._mnuInsert_pageNum.Name = "_mnuInsert_pageNum"
        Me._mnuInsert_pageNum.Size = New System.Drawing.Size(147, 22)
        Me._mnuInsert_pageNum.Text = "&Page Number"
        '
        '_mnuItm_page_top
        '
        Me._mnuItm_page_top.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagenumbertop
        Me._mnuItm_page_top.Name = "_mnuItm_page_top"
        Me._mnuItm_page_top.Size = New System.Drawing.Size(188, 22)
        Me._mnuItm_page_top.Text = "&Top of Page"
        '
        '_mnuItm_page_bottom
        '
        Me._mnuItm_page_bottom.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagenumberbottom
        Me._mnuItm_page_bottom.Name = "_mnuItm_page_bottom"
        Me._mnuItm_page_bottom.Size = New System.Drawing.Size(188, 22)
        Me._mnuItm_page_bottom.Text = "&Bottom of Page"
        '
        '_sep_pageNum01
        '
        Me._sep_pageNum01.Name = "_sep_pageNum01"
        Me._sep_pageNum01.Size = New System.Drawing.Size(185, 6)
        '
        '_mnuPageNum_delete
        '
        Me._mnuPageNum_delete.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletepagenumber
        Me._mnuPageNum_delete.Name = "_mnuPageNum_delete"
        Me._mnuPageNum_delete.Size = New System.Drawing.Size(188, 22)
        Me._mnuPageNum_delete.Text = "&Delete Page Numbers"
        '
        'toolStripSep_mnuInsert1
        '
        Me.toolStripSep_mnuInsert1.Name = "toolStripSep_mnuInsert1"
        Me.toolStripSep_mnuInsert1.Size = New System.Drawing.Size(144, 6)
        '
        '_mnuInsert_Fields
        '
        Me._mnuInsert_Fields.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuInsert_Fields_insertMergeField, Me._mnuInsert_Fields_insertSpecialField, Me._mnuInsert_Fields_highlightMergeFields, Me.toolStripSeparator14, Me._mnuInsert_Fields_showFieldCodes, Me._mnuInsert_Fields_showFieldText, Me._sep_field01, Me._mnuInsert_Fields_deleteField})
        Me._mnuInsert_Fields.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeinsertfield
        Me._mnuInsert_Fields.Name = "_mnuInsert_Fields"
        Me._mnuInsert_Fields.Size = New System.Drawing.Size(147, 22)
        Me._mnuInsert_Fields.Text = "Fi&elds"
        '
        '_mnuInsert_Fields_insertMergeField
        '
        Me._mnuInsert_Fields_insertMergeField.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeinsertfield
        Me._mnuInsert_Fields_insertMergeField.Name = "_mnuInsert_Fields_insertMergeField"
        Me._mnuInsert_Fields_insertMergeField.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_insertMergeField.Text = "&Insert Merge Field"
        '
        '_mnuInsert_Fields_insertSpecialField
        '
        Me._mnuInsert_Fields_insertSpecialField.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuInsert_Fields_insertSpecialField_IF, Me._mnuInsert_Fields_insertSpecialField_inclText, Me._mnuInsert_Fields_insertSpecialField_date, Me._mnuInsert_Fields_insertSpecialField_Next, Me._mnuInsert_Fields_insertSpecialField_NextIf})
        Me._mnuInsert_Fields_insertSpecialField.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeiffield
        Me._mnuInsert_Fields_insertSpecialField.Name = "_mnuInsert_Fields_insertSpecialField"
        Me._mnuInsert_Fields_insertSpecialField.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_insertSpecialField.Text = "Insert &Special Field"
        '
        '_mnuInsert_Fields_insertSpecialField_IF
        '
        Me._mnuInsert_Fields_insertSpecialField_IF.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeiffield
        Me._mnuInsert_Fields_insertSpecialField_IF.Name = "_mnuInsert_Fields_insertSpecialField_IF"
        Me._mnuInsert_Fields_insertSpecialField_IF.Size = New System.Drawing.Size(135, 22)
        Me._mnuInsert_Fields_insertSpecialField_IF.Text = "&IF"
        '
        '_mnuInsert_Fields_insertSpecialField_inclText
        '
        Me._mnuInsert_Fields_insertSpecialField_inclText.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeincludetextfield
        Me._mnuInsert_Fields_insertSpecialField_inclText.Name = "_mnuInsert_Fields_insertSpecialField_inclText"
        Me._mnuInsert_Fields_insertSpecialField_inclText.Size = New System.Drawing.Size(135, 22)
        Me._mnuInsert_Fields_insertSpecialField_inclText.Text = "I&ncludeText"
        '
        '_mnuInsert_Fields_insertSpecialField_date
        '
        Me._mnuInsert_Fields_insertSpecialField_date.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergedatefield
        Me._mnuInsert_Fields_insertSpecialField_date.Name = "_mnuInsert_Fields_insertSpecialField_date"
        Me._mnuInsert_Fields_insertSpecialField_date.Size = New System.Drawing.Size(135, 22)
        Me._mnuInsert_Fields_insertSpecialField_date.Text = "&Date"
        '
        '_mnuInsert_Fields_insertSpecialField_Next
        '
        Me._mnuInsert_Fields_insertSpecialField_Next.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergenextfield
        Me._mnuInsert_Fields_insertSpecialField_Next.Name = "_mnuInsert_Fields_insertSpecialField_Next"
        Me._mnuInsert_Fields_insertSpecialField_Next.Size = New System.Drawing.Size(135, 22)
        Me._mnuInsert_Fields_insertSpecialField_Next.Text = "N&ext"
        '
        '_mnuInsert_Fields_insertSpecialField_NextIf
        '
        Me._mnuInsert_Fields_insertSpecialField_NextIf.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergenextiffield
        Me._mnuInsert_Fields_insertSpecialField_NextIf.Name = "_mnuInsert_Fields_insertSpecialField_NextIf"
        Me._mnuInsert_Fields_insertSpecialField_NextIf.Size = New System.Drawing.Size(135, 22)
        Me._mnuInsert_Fields_insertSpecialField_NextIf.Text = "Ne&xtIf"
        '
        '_mnuInsert_Fields_highlightMergeFields
        '
        Me._mnuInsert_Fields_highlightMergeFields.Checked = True
        Me._mnuInsert_Fields_highlightMergeFields.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuInsert_Fields_highlightMergeFields.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergehighlightfields
        Me._mnuInsert_Fields_highlightMergeFields.Name = "_mnuInsert_Fields_highlightMergeFields"
        Me._mnuInsert_Fields_highlightMergeFields.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_highlightMergeFields.Text = "&Highlight Merge Fields"
        '
        'toolStripSeparator14
        '
        Me.toolStripSeparator14.Name = "toolStripSeparator14"
        Me.toolStripSeparator14.Size = New System.Drawing.Size(191, 6)
        '
        '_mnuInsert_Fields_showFieldCodes
        '
        Me._mnuInsert_Fields_showFieldCodes.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeshowfieldcodes
        Me._mnuInsert_Fields_showFieldCodes.Name = "_mnuInsert_Fields_showFieldCodes"
        Me._mnuInsert_Fields_showFieldCodes.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_showFieldCodes.Text = "Show Field &Codes"
        '
        '_mnuInsert_Fields_showFieldText
        '
        Me._mnuInsert_Fields_showFieldText.Checked = True
        Me._mnuInsert_Fields_showFieldText.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuInsert_Fields_showFieldText.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergeshowfieldtext
        Me._mnuInsert_Fields_showFieldText.Name = "_mnuInsert_Fields_showFieldText"
        Me._mnuInsert_Fields_showFieldText.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_showFieldText.Text = "Show Field &Text"
        '
        '_sep_field01
        '
        Me._sep_field01.Name = "_sep_field01"
        Me._sep_field01.Size = New System.Drawing.Size(191, 6)
        '
        '_mnuInsert_Fields_deleteField
        '
        Me._mnuInsert_Fields_deleteField.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergedeletefield
        Me._mnuInsert_Fields_deleteField.Name = "_mnuInsert_Fields_deleteField"
        Me._mnuInsert_Fields_deleteField.Size = New System.Drawing.Size(194, 22)
        Me._mnuInsert_Fields_deleteField.Text = "&Delete Field"
        '
        'toolStripSep_mnuInsert2
        '
        Me.toolStripSep_mnuInsert2.MergeIndex = 4
        Me.toolStripSep_mnuInsert2.Name = "toolStripSep_mnuInsert2"
        Me.toolStripSep_mnuInsert2.Size = New System.Drawing.Size(144, 6)
        '
        'mnuInsert_Hyperlink
        '
        Me.mnuInsert_Hyperlink.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.inserthyperlink
        Me.mnuInsert_Hyperlink.MergeIndex = 5
        Me.mnuInsert_Hyperlink.Name = "mnuInsert_Hyperlink"
        Me.mnuInsert_Hyperlink.Size = New System.Drawing.Size(147, 22)
        Me.mnuInsert_Hyperlink.Text = "&Hyperlink..."
        '
        'mnuInsert_Target
        '
        Me.mnuInsert_Target.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.insertbookmark
        Me.mnuInsert_Target.MergeIndex = 6
        Me.mnuInsert_Target.Name = "mnuInsert_Target"
        Me.mnuInsert_Target.Size = New System.Drawing.Size(147, 22)
        Me.mnuInsert_Target.Text = "&Target..."
        '
        'toolStripSep_mnuInsert3
        '
        Me.toolStripSep_mnuInsert3.MergeIndex = 7
        Me.toolStripSep_mnuInsert3.Name = "toolStripSep_mnuInsert3"
        Me.toolStripSep_mnuInsert3.Size = New System.Drawing.Size(144, 6)
        '
        'sectionToolStripMenuItem
        '
        Me.sectionToolStripMenuItem.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.insertlinebreak
        Me.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem"
        Me.sectionToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.sectionToolStripMenuItem.Text = "Brea&k..."
        '
        'mnuFormat
        '
        Me.mnuFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFormat_Character, Me.mnuFormat_Paragraph, Me.mnuFormat_List, Me.mnuFormat_Styles, Me.toolStripSeparator5, Me.mnuFormat_HeadersAndFooters, Me.mnuFormat_Columns, Me.mnuFormat_pageframe, Me.mnuFormat_Tabs, Me.menuItem20, Me.mnuFormat_Image, Me.mnuFormat_TextFrame, Me.toolStripMenuItem3, Me.mnuFormat_SetLanguage})
        Me.mnuFormat.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuFormat.MergeIndex = 4
        Me.mnuFormat.Name = "mnuFormat"
        Me.mnuFormat.Size = New System.Drawing.Size(57, 20)
        Me.mnuFormat.Text = "For&mat"
        '
        'mnuFormat_Character
        '
        Me.mnuFormat_Character.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.charactersettings
        Me.mnuFormat_Character.MergeIndex = 0
        Me.mnuFormat_Character.Name = "mnuFormat_Character"
        Me.mnuFormat_Character.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Character.Text = "&Character..."
        '
        'mnuFormat_Paragraph
        '
        Me.mnuFormat_Paragraph.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.paragraphsettings
        Me.mnuFormat_Paragraph.MergeIndex = 1
        Me.mnuFormat_Paragraph.Name = "mnuFormat_Paragraph"
        Me.mnuFormat_Paragraph.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Paragraph.Text = "&Paragraph..."
        '
        'mnuFormat_List
        '
        Me.mnuFormat_List.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFormat_List_Attributes, Me.mnuFormat_List_IncreaseLevel, Me.mnuFormat_List_DecreaseLevel, Me.menuItem28, Me.mnuFormat_List_ArabicNumbers, Me.mnuFormat_List_CapitalLetters, Me.mnuFormat_List_Letters, Me.mnuFormat_List_RomanNumbers, Me.mnuFormat_List_SmallRomanNumbers, Me.mnuFormat_List_Bullets})
        Me.mnuFormat_List.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.listdialog
        Me.mnuFormat_List.MergeIndex = 3
        Me.mnuFormat_List.Name = "mnuFormat_List"
        Me.mnuFormat_List.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_List.Text = "Bullets and &Numbering"
        '
        'mnuFormat_List_Attributes
        '
        Me.mnuFormat_List_Attributes.MergeIndex = 0
        Me.mnuFormat_List_Attributes.Name = "mnuFormat_List_Attributes"
        Me.mnuFormat_List_Attributes.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_Attributes.Text = "&Properties..."
        '
        'mnuFormat_List_IncreaseLevel
        '
        Me.mnuFormat_List_IncreaseLevel.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.indentincrease
        Me.mnuFormat_List_IncreaseLevel.MergeIndex = 1
        Me.mnuFormat_List_IncreaseLevel.Name = "mnuFormat_List_IncreaseLevel"
        Me.mnuFormat_List_IncreaseLevel.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_IncreaseLevel.Text = "&Increase Level"
        '
        'mnuFormat_List_DecreaseLevel
        '
        Me.mnuFormat_List_DecreaseLevel.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.indentdecrease
        Me.mnuFormat_List_DecreaseLevel.MergeIndex = 2
        Me.mnuFormat_List_DecreaseLevel.Name = "mnuFormat_List_DecreaseLevel"
        Me.mnuFormat_List_DecreaseLevel.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_DecreaseLevel.Text = "&Decrease Level"
        '
        'menuItem28
        '
        Me.menuItem28.MergeIndex = 3
        Me.menuItem28.Name = "menuItem28"
        Me.menuItem28.Size = New System.Drawing.Size(148, 6)
        '
        'mnuFormat_List_ArabicNumbers
        '
        Me.mnuFormat_List_ArabicNumbers.MergeIndex = 4
        Me.mnuFormat_List_ArabicNumbers.Name = "mnuFormat_List_ArabicNumbers"
        Me.mnuFormat_List_ArabicNumbers.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_ArabicNumbers.Text = "&1, 2, 3"
        '
        'mnuFormat_List_CapitalLetters
        '
        Me.mnuFormat_List_CapitalLetters.MergeIndex = 5
        Me.mnuFormat_List_CapitalLetters.Name = "mnuFormat_List_CapitalLetters"
        Me.mnuFormat_List_CapitalLetters.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_CapitalLetters.Text = "A, &B, C"
        '
        'mnuFormat_List_Letters
        '
        Me.mnuFormat_List_Letters.MergeIndex = 6
        Me.mnuFormat_List_Letters.Name = "mnuFormat_List_Letters"
        Me.mnuFormat_List_Letters.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_Letters.Text = "a, b, &c"
        '
        'mnuFormat_List_RomanNumbers
        '
        Me.mnuFormat_List_RomanNumbers.MergeIndex = 7
        Me.mnuFormat_List_RomanNumbers.Name = "mnuFormat_List_RomanNumbers"
        Me.mnuFormat_List_RomanNumbers.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_RomanNumbers.Text = "&I, II, III, IV"
        '
        'mnuFormat_List_SmallRomanNumbers
        '
        Me.mnuFormat_List_SmallRomanNumbers.MergeIndex = 8
        Me.mnuFormat_List_SmallRomanNumbers.Name = "mnuFormat_List_SmallRomanNumbers"
        Me.mnuFormat_List_SmallRomanNumbers.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_SmallRomanNumbers.Text = "i, ii, iii, i&v"
        '
        'mnuFormat_List_Bullets
        '
        Me.mnuFormat_List_Bullets.MergeIndex = 9
        Me.mnuFormat_List_Bullets.Name = "mnuFormat_List_Bullets"
        Me.mnuFormat_List_Bullets.Size = New System.Drawing.Size(151, 22)
        Me.mnuFormat_List_Bullets.Text = "B&ullets"
        '
        'mnuFormat_Styles
        '
        Me.mnuFormat_Styles.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.styledialog
        Me.mnuFormat_Styles.MergeIndex = 4
        Me.mnuFormat_Styles.Name = "mnuFormat_Styles"
        Me.mnuFormat_Styles.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Styles.Text = "&Styles..."
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.MergeIndex = 9
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(193, 6)
        '
        'mnuFormat_HeadersAndFooters
        '
        Me.mnuFormat_HeadersAndFooters.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.header
        Me.mnuFormat_HeadersAndFooters.Name = "mnuFormat_HeadersAndFooters"
        Me.mnuFormat_HeadersAndFooters.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_HeadersAndFooters.Text = "&Headers and Footers..."
        '
        'mnuFormat_Columns
        '
        Me.mnuFormat_Columns.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagecolumnstwo
        Me.mnuFormat_Columns.Name = "mnuFormat_Columns"
        Me.mnuFormat_Columns.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Columns.Text = "C&olumns..."
        '
        'mnuFormat_pageframe
        '
        Me.mnuFormat_pageframe.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pageframedialog
        Me.mnuFormat_pageframe.Name = "mnuFormat_pageframe"
        Me.mnuFormat_pageframe.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_pageframe.Text = "Page &Borders…"
        '
        'mnuFormat_Tabs
        '
        Me.mnuFormat_Tabs.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.tabs
        Me.mnuFormat_Tabs.MergeIndex = 2
        Me.mnuFormat_Tabs.Name = "mnuFormat_Tabs"
        Me.mnuFormat_Tabs.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Tabs.Text = "&Tabs..."
        '
        'menuItem20
        '
        Me.menuItem20.MergeIndex = 9
        Me.menuItem20.Name = "menuItem20"
        Me.menuItem20.Size = New System.Drawing.Size(193, 6)
        '
        'mnuFormat_Image
        '
        Me.mnuFormat_Image.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.image
        Me.mnuFormat_Image.MergeIndex = 6
        Me.mnuFormat_Image.Name = "mnuFormat_Image"
        Me.mnuFormat_Image.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_Image.Text = "&Image..."
        '
        'mnuFormat_TextFrame
        '
        Me.mnuFormat_TextFrame.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.textframe
        Me.mnuFormat_TextFrame.MergeIndex = 7
        Me.mnuFormat_TextFrame.Name = "mnuFormat_TextFrame"
        Me.mnuFormat_TextFrame.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_TextFrame.Text = "Te&xt Frame..."
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(193, 6)
        '
        'mnuFormat_SetLanguage
        '
        Me.mnuFormat_SetLanguage.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.setlanguage
        Me.mnuFormat_SetLanguage.Name = "mnuFormat_SetLanguage"
        Me.mnuFormat_SetLanguage.Size = New System.Drawing.Size(196, 22)
        Me.mnuFormat_SetLanguage.Text = "&Language…"
        '
        'mnuTable
        '
        Me.mnuTable.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Insert, Me.mnuTable_Delete, Me.mnuTable_Select, Me.mnuTable_Merge_Cells, Me.mnuTable_Split_Cells, Me.mnuTable_Split, Me.mnuTable_GridLines, Me.toolStripSep_mnuTable1, Me.mnuTable_Properties})
        Me.mnuTable.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuTable.MergeIndex = 5
        Me.mnuTable.Name = "mnuTable"
        Me.mnuTable.Size = New System.Drawing.Size(48, 20)
        Me.mnuTable.Text = "T&able"
        '
        'mnuTable_Insert
        '
        Me.mnuTable_Insert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Insert_Table, Me.menuItem21, Me.mnuTable_Insert_ColumnToTheLeft, Me.mnuTable_Insert_ColumnToTheRight, Me.menuItem24, Me.mnuTable_Insert_RowAbove, Me.mnuTable_Insert_RowBelow})
        Me.mnuTable_Insert.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.table
        Me.mnuTable_Insert.MergeIndex = 0
        Me.mnuTable_Insert.Name = "mnuTable_Insert"
        Me.mnuTable_Insert.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Insert.Text = "&Insert"
        '
        'mnuTable_Insert_Table
        '
        Me.mnuTable_Insert_Table.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.table
        Me.mnuTable_Insert_Table.MergeIndex = 0
        Me.mnuTable_Insert_Table.Name = "mnuTable_Insert_Table"
        Me.mnuTable_Insert_Table.Size = New System.Drawing.Size(188, 22)
        Me.mnuTable_Insert_Table.Text = "&Table"
        '
        'menuItem21
        '
        Me.menuItem21.MergeIndex = 1
        Me.menuItem21.Name = "menuItem21"
        Me.menuItem21.Size = New System.Drawing.Size(185, 6)
        '
        'mnuTable_Insert_ColumnToTheLeft
        '
        Me.mnuTable_Insert_ColumnToTheLeft.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.inserttablecolleft
        Me.mnuTable_Insert_ColumnToTheLeft.MergeIndex = 2
        Me.mnuTable_Insert_ColumnToTheLeft.Name = "mnuTable_Insert_ColumnToTheLeft"
        Me.mnuTable_Insert_ColumnToTheLeft.Size = New System.Drawing.Size(188, 22)
        Me.mnuTable_Insert_ColumnToTheLeft.Text = "Column To The &Left"
        '
        'mnuTable_Insert_ColumnToTheRight
        '
        Me.mnuTable_Insert_ColumnToTheRight.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.inserttablecolright
        Me.mnuTable_Insert_ColumnToTheRight.MergeIndex = 3
        Me.mnuTable_Insert_ColumnToTheRight.Name = "mnuTable_Insert_ColumnToTheRight"
        Me.mnuTable_Insert_ColumnToTheRight.Size = New System.Drawing.Size(188, 22)
        Me.mnuTable_Insert_ColumnToTheRight.Text = "Column To The &Right"
        '
        'menuItem24
        '
        Me.menuItem24.MergeIndex = 4
        Me.menuItem24.Name = "menuItem24"
        Me.menuItem24.Size = New System.Drawing.Size(185, 6)
        '
        'mnuTable_Insert_RowAbove
        '
        Me.mnuTable_Insert_RowAbove.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.inserttablerowabove
        Me.mnuTable_Insert_RowAbove.MergeIndex = 5
        Me.mnuTable_Insert_RowAbove.Name = "mnuTable_Insert_RowAbove"
        Me.mnuTable_Insert_RowAbove.Size = New System.Drawing.Size(188, 22)
        Me.mnuTable_Insert_RowAbove.Text = "Row &Above"
        '
        'mnuTable_Insert_RowBelow
        '
        Me.mnuTable_Insert_RowBelow.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.inserttablerowbelow
        Me.mnuTable_Insert_RowBelow.MergeIndex = 6
        Me.mnuTable_Insert_RowBelow.Name = "mnuTable_Insert_RowBelow"
        Me.mnuTable_Insert_RowBelow.Size = New System.Drawing.Size(188, 22)
        Me.mnuTable_Insert_RowBelow.Text = "Row &Below"
        '
        'mnuTable_Delete
        '
        Me.mnuTable_Delete.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Delete_Table, Me.mnuTable_Delete_Column, Me.mnuTable_Delete_Rows, Me.mnuTable_Delete_Cells})
        Me.mnuTable_Delete.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletetable
        Me.mnuTable_Delete.MergeIndex = 1
        Me.mnuTable_Delete.Name = "mnuTable_Delete"
        Me.mnuTable_Delete.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Delete.Text = "&Delete"
        '
        'mnuTable_Delete_Table
        '
        Me.mnuTable_Delete_Table.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletetable
        Me.mnuTable_Delete_Table.MergeIndex = 0
        Me.mnuTable_Delete_Table.Name = "mnuTable_Delete_Table"
        Me.mnuTable_Delete_Table.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Delete_Table.Text = "&Table"
        '
        'mnuTable_Delete_Column
        '
        Me.mnuTable_Delete_Column.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletetablecol
        Me.mnuTable_Delete_Column.MergeIndex = 1
        Me.mnuTable_Delete_Column.Name = "mnuTable_Delete_Column"
        Me.mnuTable_Delete_Column.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Delete_Column.Text = "&Column"
        '
        'mnuTable_Delete_Rows
        '
        Me.mnuTable_Delete_Rows.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletetablerow
        Me.mnuTable_Delete_Rows.MergeIndex = 2
        Me.mnuTable_Delete_Rows.Name = "mnuTable_Delete_Rows"
        Me.mnuTable_Delete_Rows.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Delete_Rows.Text = "&Rows"
        '
        'mnuTable_Delete_Cells
        '
        Me.mnuTable_Delete_Cells.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Delete_Cells_shiftLeft, Me.mnuTable_Delete_Cells_entireRow, Me.mnuTable_Delete_Cells_entireColumn})
        Me.mnuTable_Delete_Cells.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.deletetablecell
        Me.mnuTable_Delete_Cells.Name = "mnuTable_Delete_Cells"
        Me.mnuTable_Delete_Cells.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Delete_Cells.Text = "C&ells…"
        '
        'mnuTable_Delete_Cells_shiftLeft
        '
        Me.mnuTable_Delete_Cells_shiftLeft.Name = "mnuTable_Delete_Cells_shiftLeft"
        Me.mnuTable_Delete_Cells_shiftLeft.Size = New System.Drawing.Size(186, 22)
        Me.mnuTable_Delete_Cells_shiftLeft.Text = "Shift Cells &Left"
        '
        'mnuTable_Delete_Cells_entireRow
        '
        Me.mnuTable_Delete_Cells_entireRow.Name = "mnuTable_Delete_Cells_entireRow"
        Me.mnuTable_Delete_Cells_entireRow.Size = New System.Drawing.Size(186, 22)
        Me.mnuTable_Delete_Cells_entireRow.Text = "Delete Entire &Row"
        '
        'mnuTable_Delete_Cells_entireColumn
        '
        Me.mnuTable_Delete_Cells_entireColumn.Name = "mnuTable_Delete_Cells_entireColumn"
        Me.mnuTable_Delete_Cells_entireColumn.Size = New System.Drawing.Size(186, 22)
        Me.mnuTable_Delete_Cells_entireColumn.Text = "Delete Entire &Column"
        '
        'mnuTable_Select
        '
        Me.mnuTable_Select.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Select_Table, Me.mnuTable_Select_Row, Me.mnuTable_Select_Column, Me.mnuTable_Select_Cell})
        Me.mnuTable_Select.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.selecttablerow
        Me.mnuTable_Select.MergeIndex = 3
        Me.mnuTable_Select.Name = "mnuTable_Select"
        Me.mnuTable_Select.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Select.Text = "S&elect"
        '
        'mnuTable_Select_Table
        '
        Me.mnuTable_Select_Table.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.selecttable
        Me.mnuTable_Select_Table.MergeIndex = 0
        Me.mnuTable_Select_Table.Name = "mnuTable_Select_Table"
        Me.mnuTable_Select_Table.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Select_Table.Text = "&Table"
        '
        'mnuTable_Select_Row
        '
        Me.mnuTable_Select_Row.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.selecttablerow
        Me.mnuTable_Select_Row.MergeIndex = 1
        Me.mnuTable_Select_Row.Name = "mnuTable_Select_Row"
        Me.mnuTable_Select_Row.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Select_Row.Text = "&Row"
        '
        'mnuTable_Select_Column
        '
        Me.mnuTable_Select_Column.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.selecttablecol
        Me.mnuTable_Select_Column.MergeIndex = 2
        Me.mnuTable_Select_Column.Name = "mnuTable_Select_Column"
        Me.mnuTable_Select_Column.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Select_Column.Text = "&Column"
        '
        'mnuTable_Select_Cell
        '
        Me.mnuTable_Select_Cell.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.selecttablecell
        Me.mnuTable_Select_Cell.MergeIndex = 3
        Me.mnuTable_Select_Cell.Name = "mnuTable_Select_Cell"
        Me.mnuTable_Select_Cell.Size = New System.Drawing.Size(117, 22)
        Me.mnuTable_Select_Cell.Text = "C&ell"
        '
        'mnuTable_Merge_Cells
        '
        Me.mnuTable_Merge_Cells.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mergetablecells
        Me.mnuTable_Merge_Cells.Name = "mnuTable_Merge_Cells"
        Me.mnuTable_Merge_Cells.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Merge_Cells.Text = "&Merge Cells"
        '
        'mnuTable_Split_Cells
        '
        Me.mnuTable_Split_Cells.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.splittablecells
        Me.mnuTable_Split_Cells.Name = "mnuTable_Split_Cells"
        Me.mnuTable_Split_Cells.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Split_Cells.Text = "&Split Cells"
        '
        'mnuTable_Split
        '
        Me.mnuTable_Split.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTable_Split_Above, Me.mnuTable_Split_Below})
        Me.mnuTable_Split.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.splittable
        Me.mnuTable_Split.MergeIndex = 2
        Me.mnuTable_Split.Name = "mnuTable_Split"
        Me.mnuTable_Split.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Split.Text = "S&plit Table"
        '
        'mnuTable_Split_Above
        '
        Me.mnuTable_Split_Above.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.splittableabove
        Me.mnuTable_Split_Above.MergeIndex = 0
        Me.mnuTable_Split_Above.Name = "mnuTable_Split_Above"
        Me.mnuTable_Split_Above.Size = New System.Drawing.Size(108, 22)
        Me.mnuTable_Split_Above.Text = "&Above"
        '
        'mnuTable_Split_Below
        '
        Me.mnuTable_Split_Below.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.splittablebelow
        Me.mnuTable_Split_Below.MergeIndex = 1
        Me.mnuTable_Split_Below.Name = "mnuTable_Split_Below"
        Me.mnuTable_Split_Below.Size = New System.Drawing.Size(108, 22)
        Me.mnuTable_Split_Below.Text = "&Below"
        '
        'mnuTable_GridLines
        '
        Me.mnuTable_GridLines.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.tablegridlines
        Me.mnuTable_GridLines.MergeIndex = 4
        Me.mnuTable_GridLines.Name = "mnuTable_GridLines"
        Me.mnuTable_GridLines.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_GridLines.Text = "&Grid Lines"
        '
        'toolStripSep_mnuTable1
        '
        Me.toolStripSep_mnuTable1.Name = "toolStripSep_mnuTable1"
        Me.toolStripSep_mnuTable1.Size = New System.Drawing.Size(133, 6)
        '
        'mnuTable_Properties
        '
        Me.mnuTable_Properties.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.tabledialog
        Me.mnuTable_Properties.MergeIndex = 5
        Me.mnuTable_Properties.Name = "mnuTable_Properties"
        Me.mnuTable_Properties.Size = New System.Drawing.Size(136, 22)
        Me.mnuTable_Properties.Text = "&Properties..."
        '
        'mnuOptions
        '
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions_HTML, Me.mnuOptions_PDF})
        Me.mnuOptions.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuOptions.MergeIndex = 6
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(61, 20)
        Me.mnuOptions.Text = "&Options"
        '
        'mnuOptions_HTML
        '
        Me.mnuOptions_HTML.MergeIndex = 0
        Me.mnuOptions_HTML.Name = "mnuOptions_HTML"
        Me.mnuOptions_HTML.Size = New System.Drawing.Size(161, 22)
        Me.mnuOptions_HTML.Text = "&HTML Settings..."
        '
        'mnuOptions_PDF
        '
        Me.mnuOptions_PDF.MergeIndex = 1
        Me.mnuOptions_PDF.Name = "mnuOptions_PDF"
        Me.mnuOptions_PDF.Size = New System.Drawing.Size(161, 22)
        Me.mnuOptions_PDF.Text = "&PDF Settings..."
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelp_AboutTXTextControlWords})
        Me.mnuHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mnuHelp.MergeIndex = 8
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelp_AboutTXTextControlWords
        '
        Me.mnuHelp_AboutTXTextControlWords.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.help
        Me.mnuHelp_AboutTXTextControlWords.MergeIndex = 0
        Me.mnuHelp_AboutTXTextControlWords.Name = "mnuHelp_AboutTXTextControlWords"
        Me.mnuHelp_AboutTXTextControlWords.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuHelp_AboutTXTextControlWords.Size = New System.Drawing.Size(257, 22)
        Me.mnuHelp_AboutTXTextControlWords.Text = "&About TX Text Control Words..."
        '
        '_toolStrip
        '
        Me._toolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripNewFile, Me.toolStripOpenFile, Me.toolStripSave, Me.toolStripSeparator1, Me.toolStripPrint, Me.toolStripPrintPreview, Me.toolStripSeparator2, Me.toolStripCut, Me.toolStripCopy, Me.toolStripPaste, Me.toolStripDelete, Me.toolStripSeparator3, Me.toolStripUndo, Me.toolStripRedo, Me.toolStripFind, Me.toolStripSeparator444, Me.toolStripMarginsAndPaper, Me.toolStripHeadersAndFooters, Me.toolStripColumns, Me.toolStripPageBorders})
        Me._toolStrip.Location = New System.Drawing.Point(3, 24)
        Me._toolStrip.Name = "_toolStrip"
        Me._toolStrip.Size = New System.Drawing.Size(404, 25)
        Me._toolStrip.TabIndex = 0
        '
        'toolStripNewFile
        '
        Me.toolStripNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripNewFile.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.newpage
        Me.toolStripNewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripNewFile.Name = "toolStripNewFile"
        Me.toolStripNewFile.Size = New System.Drawing.Size(23, 22)
        Me.toolStripNewFile.Text = "New document"
        Me.toolStripNewFile.ToolTipText = "New document"
        '
        'toolStripOpenFile
        '
        Me.toolStripOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripOpenFile.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.open
        Me.toolStripOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripOpenFile.Name = "toolStripOpenFile"
        Me.toolStripOpenFile.Size = New System.Drawing.Size(23, 22)
        Me.toolStripOpenFile.Text = "Open document"
        Me.toolStripOpenFile.ToolTipText = "Open document"
        '
        'toolStripSave
        '
        Me.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripSave.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.save
        Me.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripSave.Name = "toolStripSave"
        Me.toolStripSave.Size = New System.Drawing.Size(23, 22)
        Me.toolStripSave.Text = "Save document"
        Me.toolStripSave.ToolTipText = "Save document"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripPrint
        '
        Me.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripPrint.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.print
        Me.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripPrint.Name = "toolStripPrint"
        Me.toolStripPrint.Size = New System.Drawing.Size(23, 22)
        Me.toolStripPrint.Text = "Print document"
        Me.toolStripPrint.ToolTipText = "Print document"
        '
        'toolStripPrintPreview
        '
        Me.toolStripPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripPrintPreview.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.printpreview
        Me.toolStripPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripPrintPreview.Name = "toolStripPrintPreview"
        Me.toolStripPrintPreview.Size = New System.Drawing.Size(23, 22)
        Me.toolStripPrintPreview.Text = "Print preview"
        Me.toolStripPrintPreview.ToolTipText = "Print preview"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripCut
        '
        Me.toolStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripCut.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.cut
        Me.toolStripCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripCut.Name = "toolStripCut"
        Me.toolStripCut.Size = New System.Drawing.Size(23, 22)
        Me.toolStripCut.Text = "Cut"
        Me.toolStripCut.ToolTipText = "Cut"
        '
        'toolStripCopy
        '
        Me.toolStripCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripCopy.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.copy
        Me.toolStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripCopy.Name = "toolStripCopy"
        Me.toolStripCopy.Size = New System.Drawing.Size(23, 22)
        Me.toolStripCopy.Text = "Copy"
        Me.toolStripCopy.ToolTipText = "Copy"
        '
        'toolStripPaste
        '
        Me.toolStripPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripPaste.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.paste
        Me.toolStripPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripPaste.Name = "toolStripPaste"
        Me.toolStripPaste.Size = New System.Drawing.Size(23, 22)
        Me.toolStripPaste.Text = "Paste"
        Me.toolStripPaste.ToolTipText = "Paste"
        '
        'toolStripDelete
        '
        Me.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripDelete.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.delete
        Me.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripDelete.Name = "toolStripDelete"
        Me.toolStripDelete.Size = New System.Drawing.Size(23, 22)
        Me.toolStripDelete.Text = "Delete selection"
        Me.toolStripDelete.ToolTipText = "Delete selection"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripUndo
        '
        Me.toolStripUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripUndo.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.undo
        Me.toolStripUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripUndo.Name = "toolStripUndo"
        Me.toolStripUndo.Size = New System.Drawing.Size(23, 22)
        Me.toolStripUndo.Text = "Undo"
        Me.toolStripUndo.ToolTipText = "Undo"
        '
        'toolStripRedo
        '
        Me.toolStripRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripRedo.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.redo
        Me.toolStripRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripRedo.Name = "toolStripRedo"
        Me.toolStripRedo.Size = New System.Drawing.Size(23, 22)
        Me.toolStripRedo.Text = "Redo"
        Me.toolStripRedo.ToolTipText = "Redo"
        '
        'toolStripFind
        '
        Me.toolStripFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripFind.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.find
        Me.toolStripFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripFind.Name = "toolStripFind"
        Me.toolStripFind.Size = New System.Drawing.Size(23, 22)
        Me.toolStripFind.Text = "Find"
        Me.toolStripFind.ToolTipText = "Find"
        '
        'toolStripSeparator444
        '
        Me.toolStripSeparator444.Name = "toolStripSeparator444"
        Me.toolStripSeparator444.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripMarginsAndPaper
        '
        Me.toolStripMarginsAndPaper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripMarginsAndPaper.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagedialog
        Me.toolStripMarginsAndPaper.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripMarginsAndPaper.Name = "toolStripMarginsAndPaper"
        Me.toolStripMarginsAndPaper.Size = New System.Drawing.Size(23, 22)
        Me.toolStripMarginsAndPaper.Text = "Margins and Paper"
        '
        'toolStripHeadersAndFooters
        '
        Me.toolStripHeadersAndFooters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripHeadersAndFooters.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.hfdialog
        Me.toolStripHeadersAndFooters.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripHeadersAndFooters.Name = "toolStripHeadersAndFooters"
        Me.toolStripHeadersAndFooters.Size = New System.Drawing.Size(23, 22)
        Me.toolStripHeadersAndFooters.Text = "Headers and Footers"
        '
        'toolStripColumns
        '
        Me.toolStripColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripColumns.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pagecolumnstwo
        Me.toolStripColumns.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripColumns.Name = "toolStripColumns"
        Me.toolStripColumns.Size = New System.Drawing.Size(23, 22)
        Me.toolStripColumns.Text = "Columns"
        Me.toolStripColumns.ToolTipText = "Columns"
        '
        'toolStripPageBorders
        '
        Me.toolStripPageBorders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripPageBorders.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.pageframedialog
        Me.toolStripPageBorders.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripPageBorders.Name = "toolStripPageBorders"
        Me.toolStripPageBorders.Size = New System.Drawing.Size(23, 22)
        Me.toolStripPageBorders.Text = "Page Borders"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(470, 77)
        '
        '_contextMenuApplicationFields
        '
        Me._contextMenuApplicationFields.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fieldPropertiesToolStripMenuItem, Me._deleteFieldToolStripMenuItem})
        Me._contextMenuApplicationFields.Name = "_contextMenuApplicationFields"
        Me._contextMenuApplicationFields.Size = New System.Drawing.Size(165, 48)
        '
        '_fieldPropertiesToolStripMenuItem
        '
        Me._fieldPropertiesToolStripMenuItem.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergefieldproperties
        Me._fieldPropertiesToolStripMenuItem.Name = "_fieldPropertiesToolStripMenuItem"
        Me._fieldPropertiesToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me._fieldPropertiesToolStripMenuItem.Text = "Field &Properties…"
        '
        '_deleteFieldToolStripMenuItem
        '
        Me._deleteFieldToolStripMenuItem.Image = Global.QS2.Desktop.Txteditor2.My.Resources.Resources.mailmergedeletefield
        Me._deleteFieldToolStripMenuItem.Name = "_deleteFieldToolStripMenuItem"
        Me._deleteFieldToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me._deleteFieldToolStripMenuItem.Text = "&Delete Field"
        '
        'PanelTxtEditor
        '
        Me.PanelTxtEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelTxtEditor.Controls.Add(Me._textControl)
        Me.PanelTxtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTxtEditor.Location = New System.Drawing.Point(25, 53)
        Me.PanelTxtEditor.Name = "PanelTxtEditor"
        Me.PanelTxtEditor.Size = New System.Drawing.Size(933, 533)
        Me.PanelTxtEditor.TabIndex = 5
        '
        'contTxtEditor2
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.toolStripContainer1)
        Me.Location = New System.Drawing.Point(50, 50)
        Me.Name = "contTxtEditor2"
        Me.Size = New System.Drawing.Size(958, 657)
        Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.toolStripContainer1.ResumeLayout(False)
        Me.toolStripContainer1.PerformLayout()
        Me._menuStrip.ResumeLayout(False)
        Me._menuStrip.PerformLayout()
        Me._toolStrip.ResumeLayout(False)
        Me._toolStrip.PerformLayout()
        Me._contextMenuApplicationFields.ResumeLayout(False)
        Me.PanelTxtEditor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Private _menuStrip As System.Windows.Forms.MenuStrip
    Private WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_Save As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_SaveAs As System.Windows.Forms.ToolStripMenuItem
    Private menuItem6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFile_PageSetup As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_PrintPreview As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_Print As System.Windows.Forms.ToolStripMenuItem
    Private menuItem10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Undo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Redo As System.Windows.Forms.ToolStripMenuItem
    Private menuItem4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuEdit_Cut As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Copy As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Paste As System.Windows.Forms.ToolStripMenuItem
    Private menuItem9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuEdit_Delete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_SelectAll As System.Windows.Forms.ToolStripMenuItem
    Private menuItem13 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuEdit_Find As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Replace As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Draft As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_PageLayout As System.Windows.Forms.ToolStripMenuItem
    Private menuItem8 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuView_Toolbar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_ButtonBar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_StatusBar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_HorizontalRuler As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_VerticalRuler As System.Windows.Forms.ToolStripMenuItem
    Private menuItem19 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuView_Zoom As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_25 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_50 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_75 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_100 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_150 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_200 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_Zoom_300 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuInsert As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuInsert_File As System.Windows.Forms.ToolStripMenuItem
    Private menuItem3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuInsert_Image As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSep_mnuInsert3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFormat As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_Character As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_Paragraph As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_Tabs As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_Attributes As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_IncreaseLevel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_DecreaseLevel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_ArabicNumbers As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_CapitalLetters As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_Letters As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_RomanNumbers As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_SmallRomanNumbers As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_List_Bullets As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_Styles As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_Image As System.Windows.Forms.ToolStripMenuItem
    Private menuItem20 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuTable As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert_Table As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert_ColumnToTheLeft As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert_ColumnToTheRight As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert_RowAbove As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Insert_RowBelow As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Table As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Column As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Rows As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Split As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Split_Above As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Split_Below As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Select As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Select_Table As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Select_Row As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Select_Cell As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_GridLines As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Properties As System.Windows.Forms.ToolStripMenuItem
    Private mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuHelp_AboutTXTextControlWords As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_New As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFile_Open As System.Windows.Forms.ToolStripMenuItem
    Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFile_Exit As System.Windows.Forms.ToolStripMenuItem
    Private _toolStrip As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripNewFile As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripOpenFile As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSave As System.Windows.Forms.ToolStripButton
    Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private statusBar1 As TXTextControl.StatusBar
    Private rulerBar2 As TXTextControl.RulerBar
    Private rulerBar1 As TXTextControl.RulerBar
    Private buttonBar1 As TXTextControl.ButtonBar
    Private WithEvents toolStripPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripPrintPreview As System.Windows.Forms.ToolStripButton
    Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripCut As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripCopy As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripPaste As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripDelete As System.Windows.Forms.ToolStripButton
    Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripUndo As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripRedo As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripFind As System.Windows.Forms.ToolStripButton
    Private menuItem28 As System.Windows.Forms.ToolStripSeparator
    Private menuItem21 As System.Windows.Forms.ToolStripSeparator
    Private menuItem24 As System.Windows.Forms.ToolStripSeparator
    Private recentFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Private TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Private RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Private LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Private ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Private WithEvents mnuTable_Select_Column As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Merge_Cells As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Split_Cells As System.Windows.Forms.ToolStripMenuItem
    Private mnuTable_Delete_Cells As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Cells_shiftLeft As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Cells_entireRow As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuTable_Delete_Cells_entireColumn As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSep_mnuTable1 As System.Windows.Forms.ToolStripSeparator

    Private WithEvents mnuFile_Export As System.Windows.Forms.ToolStripMenuItem
    Private menuItem16 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuEdit_Hyperlink As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit_Target As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuView_HeadersAndFooters As System.Windows.Forms.ToolStripMenuItem
    Private menuItem12 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuInsert_TextFrame As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSep_mnuInsert2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuInsert_Hyperlink As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuInsert_Target As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_TextFrame As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSeparator444 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents sectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_HeadersAndFooters As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripColumns As System.Windows.Forms.ToolStripButton
    Private WithEvents mnuFormat_Columns As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFormat_pageframe As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSep_mnuInsert1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _mnuInsert_Fields As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_insertMergeField As System.Windows.Forms.ToolStripMenuItem
    Private _mnuInsert_Fields_insertSpecialField As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_insertSpecialField_IF As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_insertSpecialField_inclText As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_insertSpecialField_date As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_highlightMergeFields As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _mnuInsert_Fields_showFieldCodes As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_showFieldText As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _contextMenuApplicationFields As System.Windows.Forms.ContextMenuStrip
    Private WithEvents _deleteFieldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _fieldPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _mnuInsert_pageNum As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuItm_page_top As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuItm_page_bottom As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_deleteField As ToolStripMenuItem
    Private WithEvents _mnuPageNum_delete As ToolStripMenuItem
    Private _sep_pageNum01 As ToolStripSeparator
    Private _sep_field01 As ToolStripSeparator

    Private mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuOptions_HTML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuOptions_PDF As System.Windows.Forms.ToolStripMenuItem
    Private toolStripMenuItem2 As ToolStripSeparator
    Private WithEvents mnuView_TextFrameMarkerLines As ToolStripMenuItem
    Private WithEvents mnuView_DocumentTargetMarkers As ToolStripMenuItem
    Private toolStripSeparator5 As ToolStripSeparator
    Private WithEvents toolStripMarginsAndPaper As ToolStripButton
    Private WithEvents toolStripHeadersAndFooters As ToolStripButton
    Private WithEvents toolStripPageBorders As ToolStripButton
    Private WithEvents _mnuInsert_Fields_insertSpecialField_Next As ToolStripMenuItem
    Private WithEvents _mnuInsert_Fields_insertSpecialField_NextIf As ToolStripMenuItem
    Private toolStripMenuItem3 As ToolStripSeparator
    Private WithEvents mnuFormat_SetLanguage As ToolStripMenuItem
    Private toolStripMenuItem4 As ToolStripSeparator
    Private WithEvents _mnuView_FormLayout As ToolStripMenuItem
    Private WithEvents _mnuView_FormLayout_LTR As ToolStripMenuItem
    Private WithEvents _mnuView_FormLayout_RTL As ToolStripMenuItem
    Public WithEvents _textControl As TXTextControl.TextControl
    Public WithEvents PanelTxtEditor As System.Windows.Forms.Panel
End Class
