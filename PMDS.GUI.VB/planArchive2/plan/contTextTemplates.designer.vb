<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class contTextTemplates
    Inherits System.Windows.Forms.UserControl

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eintrag hinzufügen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Eintrag löschen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblTextTemplates", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Txt")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Type")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("An")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CC")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BCC")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FromPostfach")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstIDPatienten")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstIDBenutzer")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstCategories")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PanelOben = New System.Windows.Forms.Panel()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.PanelButtEdit = New System.Windows.Forms.Panel()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnApport = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.dropDownEdit2 = New Infragistics.Win.Misc.UltraButton()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelGrid2 = New System.Windows.Forms.Panel()
        Me.ContTextTemplateFiles1 = New PMDS.GUI.VB.contTextTemplateFiles()
        Me.gridTextTemplates = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAutoDocu1 = New PMDS.GUI.VB.dsAutoDocu()
        Me.PanelEditor = New System.Windows.Forms.Panel()
        Me.PanelEditor3 = New System.Windows.Forms.Panel()
        Me.ContTxtEditor1 = New QS2.Desktop.Txteditor.contTxtEditor()
        Me.PanelEditorTop = New System.Windows.Forms.Panel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.dropDownPatienten = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.dropDownUsers = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.txtPatienten = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtBenutzer = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PanelAnCCBcc = New System.Windows.Forms.Panel()
        Me.btnSearchAn = New Infragistics.Win.Misc.UltraButton()
        Me.txtMailAn = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtMailCC = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtMailBCC = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnBcc = New Infragistics.Win.Misc.UltraButton()
        Me.btnSearchCc = New Infragistics.Win.Misc.UltraButton()
        Me.txtBetreff = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblFiles = New Infragistics.Win.Misc.UltraLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.CompAutoDocu1 = New PMDS.GUI.VB.compAutoDocu(Me.components)
        Me.uPopupContPatienten = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopupContUser = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelOben.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        Me.PanelButtEdit.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelGrid2.SuspendLayout()
        CType(Me.gridTextTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEditor.SuspendLayout()
        Me.PanelEditor3.SuspendLayout()
        Me.PanelEditorTop.SuspendLayout()
        CType(Me.txtPatienten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBenutzer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAnCCBcc.SuspendLayout()
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelOben
        '
        Me.PanelOben.Controls.Add(Me.btnAdd)
        Me.PanelOben.Controls.Add(Me.btnDel)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(964, 31)
        Me.PanelOben.TabIndex = 0
        '
        'btnAdd
        '
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAdd.Appearance = Appearance1
        Me.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdd.Location = New System.Drawing.Point(211, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 26)
        Me.btnAdd.TabIndex = 121
        UltraToolTipInfo4.ToolTipText = "Eintrag hinzufügen"
        UltraToolTipInfo4.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd, UltraToolTipInfo4)
        '
        'btnDel
        '
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance29.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDel.Appearance = Appearance29
        Me.btnDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDel.Location = New System.Drawing.Point(238, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(27, 26)
        Me.btnDel.TabIndex = 120
        UltraToolTipInfo5.ToolTipText = "Ausgewählten Eintrag löschen"
        UltraToolTipInfo5.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDel, UltraToolTipInfo5)
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.lblCount)
        Me.PanelUnten.Controls.Add(Me.PanelButtEdit)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 582)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(964, 39)
        Me.PanelUnten.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCount.Location = New System.Drawing.Point(6, 4)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(72, 13)
        Me.lblCount.TabIndex = 224
        Me.lblCount.Text = "Gefunden: 12"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelButtEdit
        '
        Me.PanelButtEdit.Controls.Add(Me.btnClose)
        Me.PanelButtEdit.Controls.Add(Me.btnApport)
        Me.PanelButtEdit.Controls.Add(Me.btnSave)
        Me.PanelButtEdit.Controls.Add(Me.dropDownEdit2)
        Me.PanelButtEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButtEdit.Location = New System.Drawing.Point(600, 0)
        Me.PanelButtEdit.Name = "PanelButtEdit"
        Me.PanelButtEdit.Size = New System.Drawing.Size(364, 39)
        Me.PanelButtEdit.TabIndex = 10
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnClose.Appearance = Appearance25
        Me.btnClose.Location = New System.Drawing.Point(276, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 29)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Tag = "ResID.Close"
        Me.btnClose.Text = "Schließen"
        '
        'btnApport
        '
        Appearance26.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnApport.Appearance = Appearance26
        Me.btnApport.Enabled = False
        Me.btnApport.Location = New System.Drawing.Point(81, 4)
        Me.btnApport.Name = "btnApport"
        Me.btnApport.Size = New System.Drawing.Size(71, 29)
        Me.btnApport.TabIndex = 1
        Me.btnApport.Tag = "ResID.Abort"
        Me.btnApport.Text = "Abbrechen"
        '
        'btnSave
        '
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSave.Appearance = Appearance27
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(153, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 29)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'dropDownEdit2
        '
        Appearance28.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.dropDownEdit2.Appearance = Appearance28
        Me.dropDownEdit2.Location = New System.Drawing.Point(8, 4)
        Me.dropDownEdit2.Name = "dropDownEdit2"
        Me.dropDownEdit2.Size = New System.Drawing.Size(72, 29)
        Me.dropDownEdit2.TabIndex = 0
        Me.dropDownEdit2.Tag = "ResID.Edit"
        Me.dropDownEdit2.Text = "Editieren"
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.SplitContainer1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 31)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(964, 551)
        Me.PanelGrid.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelGrid2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelEditor)
        Me.SplitContainer1.Size = New System.Drawing.Size(964, 551)
        Me.SplitContainer1.SplitterDistance = 269
        Me.SplitContainer1.TabIndex = 3
        '
        'PanelGrid2
        '
        Me.PanelGrid2.BackColor = System.Drawing.Color.Transparent
        Me.PanelGrid2.Controls.Add(Me.ContTextTemplateFiles1)
        Me.PanelGrid2.Controls.Add(Me.gridTextTemplates)
        Me.PanelGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid2.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid2.Name = "PanelGrid2"
        Me.PanelGrid2.Size = New System.Drawing.Size(269, 551)
        Me.PanelGrid2.TabIndex = 1
        '
        'ContTextTemplateFiles1
        '
        Me.ContTextTemplateFiles1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContTextTemplateFiles1.BackColor = System.Drawing.Color.White
        Me.ContTextTemplateFiles1.Location = New System.Drawing.Point(5, 433)
        Me.ContTextTemplateFiles1.Name = "ContTextTemplateFiles1"
        Me.ContTextTemplateFiles1.Size = New System.Drawing.Size(260, 116)
        Me.ContTextTemplateFiles1.TabIndex = 122
        '
        'gridTextTemplates
        '
        Me.gridTextTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridTextTemplates.DataMember = "tblTextTemplates"
        Me.gridTextTemplates.DataSource = Me.DsAutoDocu1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridTextTemplates.DisplayLayout.Appearance = Appearance2
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 204
        UltraGridColumn15.Header.VisiblePosition = 5
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 70
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 159
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.VisiblePosition = 3
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn12.Width = 106
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridColumn13.Width = 74
        UltraGridColumn1.Header.VisiblePosition = 6
        UltraGridColumn4.Header.VisiblePosition = 7
        UltraGridColumn5.Header.VisiblePosition = 8
        UltraGridColumn6.Header.VisiblePosition = 9
        UltraGridColumn7.Header.VisiblePosition = 10
        UltraGridColumn8.Header.VisiblePosition = 11
        UltraGridColumn10.Header.VisiblePosition = 12
        UltraGridColumn11.Header.VisiblePosition = 13
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn2, UltraGridColumn15, UltraGridColumn3, UltraGridColumn12, UltraGridColumn13, UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn10, UltraGridColumn11})
        Me.gridTextTemplates.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridTextTemplates.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTextTemplates.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplates.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.gridTextTemplates.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTextTemplates.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplates.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.gridTextTemplates.DisplayLayout.MaxColScrollRegions = 1
        Me.gridTextTemplates.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridTextTemplates.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridTextTemplates.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.gridTextTemplates.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridTextTemplates.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridTextTemplates.DisplayLayout.Override.CellAppearance = Appearance9
        Me.gridTextTemplates.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridTextTemplates.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.gridTextTemplates.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.gridTextTemplates.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridTextTemplates.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.gridTextTemplates.DisplayLayout.Override.RowAppearance = Appearance12
        Me.gridTextTemplates.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Me.gridTextTemplates.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridTextTemplates.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.gridTextTemplates.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridTextTemplates.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridTextTemplates.Location = New System.Drawing.Point(3, 1)
        Me.gridTextTemplates.Name = "gridTextTemplates"
        Me.gridTextTemplates.Size = New System.Drawing.Size(265, 428)
        Me.gridTextTemplates.TabIndex = 0
        Me.gridTextTemplates.Tag = "ResID.TextTemplates"
        Me.gridTextTemplates.Text = "Textvorlagen"
        '
        'DsAutoDocu1
        '
        Me.DsAutoDocu1.DataSetName = "dsAutoDocu"
        Me.DsAutoDocu1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelEditor
        '
        Me.PanelEditor.BackColor = System.Drawing.Color.White
        Me.PanelEditor.Controls.Add(Me.PanelEditor3)
        Me.PanelEditor.Controls.Add(Me.PanelEditorTop)
        Me.PanelEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelEditor.Name = "PanelEditor"
        Me.PanelEditor.Size = New System.Drawing.Size(691, 551)
        Me.PanelEditor.TabIndex = 3
        '
        'PanelEditor3
        '
        Me.PanelEditor3.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditor3.Controls.Add(Me.ContTxtEditor1)
        Me.PanelEditor3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEditor3.Location = New System.Drawing.Point(0, 117)
        Me.PanelEditor3.Name = "PanelEditor3"
        Me.PanelEditor3.Size = New System.Drawing.Size(691, 434)
        Me.PanelEditor3.TabIndex = 3
        '
        'ContTxtEditor1
        '
        Me.ContTxtEditor1.AllowDrop = True
        Me.ContTxtEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContTxtEditor1.ISTOSAVE = False
        Me.ContTxtEditor1.Location = New System.Drawing.Point(0, 0)
        Me.ContTxtEditor1.Name = "ContTxtEditor1"
        Me.ContTxtEditor1.Size = New System.Drawing.Size(691, 434)
        Me.ContTxtEditor1.TabIndex = 0
        Me.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
        Me.ContTxtEditor1.Visible = False
        '
        'PanelEditorTop
        '
        Me.PanelEditorTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditorTop.Controls.Add(Me.dropDownCategories)
        Me.PanelEditorTop.Controls.Add(Me.dropDownPatienten)
        Me.PanelEditorTop.Controls.Add(Me.dropDownUsers)
        Me.PanelEditorTop.Controls.Add(Me.txtPatienten)
        Me.PanelEditorTop.Controls.Add(Me.txtBenutzer)
        Me.PanelEditorTop.Controls.Add(Me.PanelAnCCBcc)
        Me.PanelEditorTop.Controls.Add(Me.txtBetreff)
        Me.PanelEditorTop.Controls.Add(Me.lblFiles)
        Me.PanelEditorTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEditorTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelEditorTop.Name = "PanelEditorTop"
        Me.PanelEditorTop.Size = New System.Drawing.Size(691, 117)
        Me.PanelEditorTop.TabIndex = 2
        '
        'dropDownCategories
        '
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(4, 5)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(119, 22)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 399
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'dropDownPatienten
        '
        Appearance14.TextHAlignAsString = "Left"
        Me.dropDownPatienten.Appearance = Appearance14
        Me.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownPatienten.Location = New System.Drawing.Point(4, 74)
        Me.dropDownPatienten.Name = "dropDownPatienten"
        Me.dropDownPatienten.Size = New System.Drawing.Size(119, 21)
        Me.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownPatienten.TabIndex = 397
        Me.dropDownPatienten.Tag = "ResID.plan.Patienten"
        Me.dropDownPatienten.Text = "Patienten"
        '
        'dropDownUsers
        '
        Appearance15.TextHAlignAsString = "Left"
        Me.dropDownUsers.Appearance = Appearance15
        Me.dropDownUsers.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownUsers.Location = New System.Drawing.Point(4, 31)
        Me.dropDownUsers.Name = "dropDownUsers"
        Me.dropDownUsers.Size = New System.Drawing.Size(119, 21)
        Me.dropDownUsers.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownUsers.TabIndex = 396
        Me.dropDownUsers.Tag = "ResID.plan.Benutzer"
        Me.dropDownUsers.Text = "Benutzer"
        '
        'txtPatienten
        '
        Me.txtPatienten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BackColorDisabled = System.Drawing.Color.White
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.ItalicAsString = "False"
        Appearance16.FontData.Name = "Microsoft Sans Serif"
        Appearance16.FontData.SizeInPoints = 8.25!
        Appearance16.FontData.StrikeoutAsString = "False"
        Appearance16.FontData.UnderlineAsString = "False"
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtPatienten.Appearance = Appearance16
        Me.txtPatienten.AutoSize = False
        Me.txtPatienten.BackColor = System.Drawing.Color.White
        Me.txtPatienten.Location = New System.Drawing.Point(128, 74)
        Me.txtPatienten.MaxLength = 0
        Me.txtPatienten.Multiline = True
        Me.txtPatienten.Name = "txtPatienten"
        Me.txtPatienten.ReadOnly = True
        Me.txtPatienten.Size = New System.Drawing.Size(556, 41)
        Me.txtPatienten.TabIndex = 2
        Me.txtPatienten.Tag = ""
        '
        'txtBenutzer
        '
        Me.txtBenutzer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.BackColorDisabled = System.Drawing.Color.White
        Appearance17.FontData.BoldAsString = "False"
        Appearance17.FontData.ItalicAsString = "False"
        Appearance17.FontData.Name = "Microsoft Sans Serif"
        Appearance17.FontData.SizeInPoints = 8.25!
        Appearance17.FontData.StrikeoutAsString = "False"
        Appearance17.FontData.UnderlineAsString = "False"
        Appearance17.ForeColor = System.Drawing.Color.Black
        Appearance17.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBenutzer.Appearance = Appearance17
        Me.txtBenutzer.AutoSize = False
        Me.txtBenutzer.BackColor = System.Drawing.Color.White
        Me.txtBenutzer.Location = New System.Drawing.Point(128, 30)
        Me.txtBenutzer.MaxLength = 0
        Me.txtBenutzer.Multiline = True
        Me.txtBenutzer.Name = "txtBenutzer"
        Me.txtBenutzer.ReadOnly = True
        Me.txtBenutzer.Size = New System.Drawing.Size(556, 41)
        Me.txtBenutzer.TabIndex = 1
        Me.txtBenutzer.Tag = ""
        '
        'PanelAnCCBcc
        '
        Me.PanelAnCCBcc.BackColor = System.Drawing.Color.Transparent
        Me.PanelAnCCBcc.Controls.Add(Me.btnSearchAn)
        Me.PanelAnCCBcc.Controls.Add(Me.txtMailAn)
        Me.PanelAnCCBcc.Controls.Add(Me.txtMailCC)
        Me.PanelAnCCBcc.Controls.Add(Me.txtMailBCC)
        Me.PanelAnCCBcc.Controls.Add(Me.btnBcc)
        Me.PanelAnCCBcc.Controls.Add(Me.btnSearchCc)
        Me.PanelAnCCBcc.Location = New System.Drawing.Point(666, 127)
        Me.PanelAnCCBcc.Name = "PanelAnCCBcc"
        Me.PanelAnCCBcc.Size = New System.Drawing.Size(202, 81)
        Me.PanelAnCCBcc.TabIndex = 391
        Me.PanelAnCCBcc.Visible = False
        '
        'btnSearchAn
        '
        Appearance18.ForeColor = System.Drawing.Color.Black
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Appearance18.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchAn.Appearance = Appearance18
        Me.btnSearchAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAn.Location = New System.Drawing.Point(5, 8)
        Me.btnSearchAn.Name = "btnSearchAn"
        Me.btnSearchAn.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchAn.TabIndex = 385
        Me.btnSearchAn.Tag = "ResID.To3"
        Me.btnSearchAn.Text = "An"
        UltraToolTipInfo1.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSearchAn, UltraToolTipInfo1)
        '
        'txtMailAn
        '
        Me.txtMailAn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.BackColorDisabled = System.Drawing.Color.White
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.ItalicAsString = "False"
        Appearance19.FontData.Name = "Microsoft Sans Serif"
        Appearance19.FontData.SizeInPoints = 8.25!
        Appearance19.FontData.StrikeoutAsString = "False"
        Appearance19.FontData.UnderlineAsString = "False"
        Appearance19.ForeColor = System.Drawing.Color.Black
        Appearance19.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailAn.Appearance = Appearance19
        Me.txtMailAn.AutoSize = False
        Me.txtMailAn.BackColor = System.Drawing.Color.White
        Me.txtMailAn.Location = New System.Drawing.Point(45, 6)
        Me.txtMailAn.MaxLength = 0
        Me.txtMailAn.Multiline = True
        Me.txtMailAn.Name = "txtMailAn"
        Me.txtMailAn.Size = New System.Drawing.Size(404, 33)
        Me.txtMailAn.TabIndex = 386
        Me.txtMailAn.Tag = ""
        '
        'txtMailCC
        '
        Me.txtMailCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance20.BackColor = System.Drawing.Color.White
        Appearance20.BackColor2 = System.Drawing.Color.White
        Appearance20.BackColorDisabled = System.Drawing.Color.White
        Appearance20.BackColorDisabled2 = System.Drawing.Color.White
        Appearance20.FontData.BoldAsString = "False"
        Appearance20.FontData.ItalicAsString = "False"
        Appearance20.FontData.Name = "Microsoft Sans Serif"
        Appearance20.FontData.SizeInPoints = 8.25!
        Appearance20.FontData.StrikeoutAsString = "False"
        Appearance20.FontData.UnderlineAsString = "False"
        Appearance20.ForeColor = System.Drawing.Color.Black
        Appearance20.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailCC.Appearance = Appearance20
        Me.txtMailCC.AutoSize = False
        Me.txtMailCC.BackColor = System.Drawing.Color.White
        Me.txtMailCC.Location = New System.Drawing.Point(45, 41)
        Me.txtMailCC.MaxLength = 0
        Me.txtMailCC.Multiline = True
        Me.txtMailCC.Name = "txtMailCC"
        Me.txtMailCC.Size = New System.Drawing.Size(150, 30)
        Me.txtMailCC.TabIndex = 388
        Me.txtMailCC.Tag = ""
        '
        'txtMailBCC
        '
        Me.txtMailBCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColorDisabled = System.Drawing.Color.White
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.ItalicAsString = "False"
        Appearance21.FontData.Name = "Microsoft Sans Serif"
        Appearance21.FontData.SizeInPoints = 8.25!
        Appearance21.FontData.StrikeoutAsString = "False"
        Appearance21.FontData.UnderlineAsString = "False"
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailBCC.Appearance = Appearance21
        Me.txtMailBCC.AutoSize = False
        Me.txtMailBCC.BackColor = System.Drawing.Color.White
        Me.txtMailBCC.Location = New System.Drawing.Point(236, 41)
        Me.txtMailBCC.MaxLength = 0
        Me.txtMailBCC.Multiline = True
        Me.txtMailBCC.Name = "txtMailBCC"
        Me.txtMailBCC.Size = New System.Drawing.Size(213, 30)
        Me.txtMailBCC.TabIndex = 390
        Me.txtMailBCC.Tag = ""
        '
        'btnBcc
        '
        Me.btnBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.ForeColorDisabled = System.Drawing.Color.Black
        Appearance22.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnBcc.Appearance = Appearance22
        Me.btnBcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBcc.Location = New System.Drawing.Point(200, 42)
        Me.btnBcc.Name = "btnBcc"
        Me.btnBcc.Size = New System.Drawing.Size(34, 19)
        Me.btnBcc.TabIndex = 389
        Me.btnBcc.Tag = "ResID.Bcc"
        Me.btnBcc.Text = "Bcc"
        UltraToolTipInfo2.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnBcc, UltraToolTipInfo2)
        '
        'btnSearchCc
        '
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ForeColorDisabled = System.Drawing.Color.Black
        Appearance23.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchCc.Appearance = Appearance23
        Me.btnSearchCc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchCc.Location = New System.Drawing.Point(5, 41)
        Me.btnSearchCc.Name = "btnSearchCc"
        Me.btnSearchCc.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchCc.TabIndex = 387
        Me.btnSearchCc.Tag = "ResID.Cc"
        Me.btnSearchCc.Text = "Cc"
        UltraToolTipInfo3.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSearchCc, UltraToolTipInfo3)
        '
        'txtBetreff
        '
        Me.txtBetreff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBetreff.Location = New System.Drawing.Point(177, 6)
        Me.txtBetreff.Name = "txtBetreff"
        Me.txtBetreff.Size = New System.Drawing.Size(507, 21)
        Me.txtBetreff.TabIndex = 0
        '
        'lblFiles
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.ForeColorDisabled = System.Drawing.Color.Black
        Appearance24.TextVAlignAsString = "Middle"
        Me.lblFiles.Appearance = Appearance24
        Me.lblFiles.Location = New System.Drawing.Point(128, 8)
        Me.lblFiles.Name = "lblFiles"
        Me.lblFiles.Size = New System.Drawing.Size(70, 17)
        Me.lblFiles.TabIndex = 384
        Me.lblFiles.Tag = "ResID.plan.Betreff"
        Me.lblFiles.Text = "Betreff"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleAuswählenToolStripMenuItem, Me.KeineAuswählenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(163, 48)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AlleAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswählenToolStripMenuItem
        '
        Me.KeineAuswählenToolStripMenuItem.Name = "KeineAuswählenToolStripMenuItem"
        Me.KeineAuswählenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.KeineAuswählenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswählenToolStripMenuItem.Text = "Keine auswählen"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contTextTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(572, 250)
        Me.Name = "contTextTemplates"
        Me.Size = New System.Drawing.Size(964, 621)
        Me.PanelOben.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUnten.PerformLayout()
        Me.PanelButtEdit.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelGrid2.ResumeLayout(False)
        CType(Me.gridTextTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEditor.ResumeLayout(False)
        Me.PanelEditor3.ResumeLayout(False)
        Me.PanelEditorTop.ResumeLayout(False)
        Me.PanelEditorTop.PerformLayout()
        CType(Me.txtPatienten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBenutzer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAnCCBcc.ResumeLayout(False)
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelOben As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents gridTextTemplates As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents btnApport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelButtEdit As System.Windows.Forms.Panel
    Public WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelGrid2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ContTxtEditor1 As qs2.Desktop.Txteditor.contTxtEditor
    Friend WithEvents DsAutoDocu1 As dsAutoDocu
    Friend WithEvents CompAutoDocu1 As compAutoDocu
    Public WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelEditor As System.Windows.Forms.Panel
    Friend WithEvents PanelEditorTop As Windows.Forms.Panel
    Friend WithEvents PanelEditor3 As Windows.Forms.Panel
    Friend WithEvents txtBetreff As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblFiles As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnSearchAn As Infragistics.Win.Misc.UltraButton
    Public WithEvents txtMailCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnBcc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearchCc As Infragistics.Win.Misc.UltraButton
    Public WithEvents txtMailBCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtMailAn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ContTextTemplateFiles1 As contTextTemplateFiles
    Public WithEvents txtPatienten As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtBenutzer As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents PanelAnCCBcc As Windows.Forms.Panel
    Friend WithEvents dropDownPatienten As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents dropDownUsers As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContPatienten As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents uPopupContUser As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents dropDownEdit2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
End Class
