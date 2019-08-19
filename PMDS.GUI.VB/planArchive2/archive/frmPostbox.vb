Imports System.Windows.Forms
Imports System.Drawing



Public Class FrmPostbox2
    Inherits System.Windows.Forms.Form

    Public IDOrdner As New System.Guid
    Public apport As Boolean = True

    Public arrÜbernehmen As New ArrayList

    Private usr As New General

    Public postboxverz As String = ""
    Public doUI1 As New doUI()



    Private genMain As New General
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MeUGridPostboxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineDateienInsArchivÜbernehmenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DateiLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents DsPostbox2 As dsPostbox





#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents UltraToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _FrmPostbox_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPostbox_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPostbox_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPostbox_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Public WithEvents UCheckEditorDateienLöschen As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents UGridPostbox As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Postbox As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenGrid As System.Windows.Forms.Panel
    Friend WithEvents UltraButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonÜbernehmen As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblPostbox", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Übernehmen")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Datei", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DateiMitPfad")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Erstellt")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Grösse")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxExplorer")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxAktualisieren")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Scannen")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MSDocumentImaging")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Scannen")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxAktualisieren")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxExplorer")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MSDocumentImaging")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Postbox = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.UGridPostbox = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MeUGridPostboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineDateienInsArchivÜbernehmenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DateiLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsPostbox2 = New dsPostbox()
        Me.PanelUntenGrid = New System.Windows.Forms.Panel()
        Me.UltraButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonÜbernehmen = New Infragistics.Win.Misc.UltraButton()
        Me.UCheckEditorDateienLöschen = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._FrmPostbox_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.Postbox.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.UGridPostbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DsPostbox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUntenGrid.SuspendLayout()
        CType(Me.UCheckEditorDateienLöschen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Postbox
        '
        Me.Postbox.Controls.Add(Me.Panel2)
        Me.Postbox.Controls.Add(Me.PanelUntenGrid)
        Me.Postbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Postbox.Location = New System.Drawing.Point(0, 29)
        Me.Postbox.Name = "Postbox"
        Me.Postbox.Size = New System.Drawing.Size(682, 353)
        Me.Postbox.TabIndex = 462
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(682, 317)
        Me.Panel2.TabIndex = 460
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.UGridPostbox)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(682, 317)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'UGridPostbox
        '
        Me.UGridPostbox.ContextMenuStrip = Me.ContextMenuStrip1
        Me.UGridPostbox.DataMember = "tblPostbox"
        Me.UGridPostbox.DataSource = Me.DsPostbox2
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridPostbox.DisplayLayout.Appearance = Appearance1
        Me.UGridPostbox.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 37
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 439
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 203
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 125
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 70
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 105
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.UGridPostbox.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UGridPostbox.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance2.BackColor = System.Drawing.Color.FloralWhite
        Me.UGridPostbox.DisplayLayout.CaptionAppearance = Appearance2
        Me.UGridPostbox.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridPostbox.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridPostbox.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.UGridPostbox.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridPostbox.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridPostbox.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.UGridPostbox.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridPostbox.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridPostbox.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Me.UGridPostbox.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridPostbox.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.UGridPostbox.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridPostbox.DisplayLayout.Override.CellAppearance = Appearance8
        Me.UGridPostbox.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridPostbox.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridPostbox.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.UGridPostbox.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.UGridPostbox.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridPostbox.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.UGridPostbox.DisplayLayout.Override.RowAppearance = Appearance11
        Me.UGridPostbox.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.UGridPostbox.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridPostbox.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.UGridPostbox.DisplayLayout.RowConnectorColor = System.Drawing.Color.FloralWhite
        Me.UGridPostbox.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.UGridPostbox.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridPostbox.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.UGridPostbox, GridBagConstraint1)
        Me.UGridPostbox.Location = New System.Drawing.Point(5, 5)
        Me.UGridPostbox.Name = "UGridPostbox"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.UGridPostbox, New System.Drawing.Size(258, 157))
        Me.UGridPostbox.Size = New System.Drawing.Size(672, 312)
        Me.UGridPostbox.TabIndex = 0
        Me.UGridPostbox.Tag = "ResID.Postbox"
        Me.UGridPostbox.Text = "Postbox"
        Me.UGridPostbox.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate
        Me.UGridPostbox.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MeUGridPostboxToolStripMenuItem, Me.KeineDateienInsArchivÜbernehmenToolStripMenuItem, Me.ToolStripMenuItem1, Me.DateiLöschenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(212, 76)
        '
        'MeUGridPostboxToolStripMenuItem
        '
        Me.MeUGridPostboxToolStripMenuItem.Name = "MeUGridPostboxToolStripMenuItem"
        Me.MeUGridPostboxToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.MeUGridPostboxToolStripMenuItem.Text = "Alle auf übernehmen"
        '
        'KeineDateienInsArchivÜbernehmenToolStripMenuItem
        '
        Me.KeineDateienInsArchivÜbernehmenToolStripMenuItem.Name = "KeineDateienInsArchivÜbernehmenToolStripMenuItem"
        Me.KeineDateienInsArchivÜbernehmenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.KeineDateienInsArchivÜbernehmenToolStripMenuItem.Text = "Keine auf übernehmen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(208, 6)
        '
        'DateiLöschenToolStripMenuItem
        '
        Me.DateiLöschenToolStripMenuItem.Name = "DateiLöschenToolStripMenuItem"
        Me.DateiLöschenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.DateiLöschenToolStripMenuItem.Text = "Datei aus Postbox löschen"
        '
        'DsPostbox2
        '
        Me.DsPostbox2.DataSetName = "dsPostbox"
        Me.DsPostbox2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelUntenGrid
        '
        Me.PanelUntenGrid.BackColor = System.Drawing.Color.White
        Me.PanelUntenGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelUntenGrid.Controls.Add(Me.UltraButtonAbbrechen)
        Me.PanelUntenGrid.Controls.Add(Me.UButtonÜbernehmen)
        Me.PanelUntenGrid.Controls.Add(Me.UCheckEditorDateienLöschen)
        Me.PanelUntenGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUntenGrid.Location = New System.Drawing.Point(0, 317)
        Me.PanelUntenGrid.Name = "PanelUntenGrid"
        Me.PanelUntenGrid.Size = New System.Drawing.Size(682, 36)
        Me.PanelUntenGrid.TabIndex = 1
        '
        'UltraButtonAbbrechen
        '
        Me.UltraButtonAbbrechen.BackColorInternal = System.Drawing.Color.White
        Me.UltraButtonAbbrechen.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraButtonAbbrechen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButtonAbbrechen.Location = New System.Drawing.Point(362, 4)
        Me.UltraButtonAbbrechen.Name = "UltraButtonAbbrechen"
        Me.UltraButtonAbbrechen.Padding = New System.Drawing.Size(2, 0)
        Me.UltraButtonAbbrechen.Size = New System.Drawing.Size(79, 27)
        Me.UltraButtonAbbrechen.TabIndex = 2
        Me.UltraButtonAbbrechen.Tag = "ResID.Abort"
        Me.UltraButtonAbbrechen.Text = "Abbrechen"
        '
        'UButtonÜbernehmen
        '
        Appearance13.TextHAlignAsString = "Center"
        Me.UButtonÜbernehmen.Appearance = Appearance13
        Me.UButtonÜbernehmen.BackColorInternal = System.Drawing.Color.White
        Me.UButtonÜbernehmen.Cursor = System.Windows.Forms.Cursors.Default
        Me.UButtonÜbernehmen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UButtonÜbernehmen.Location = New System.Drawing.Point(255, 4)
        Me.UButtonÜbernehmen.Name = "UButtonÜbernehmen"
        Me.UButtonÜbernehmen.Padding = New System.Drawing.Size(2, 0)
        Me.UButtonÜbernehmen.Size = New System.Drawing.Size(106, 27)
        Me.UButtonÜbernehmen.TabIndex = 1
        Me.UButtonÜbernehmen.Tag = "ResID.Take"
        Me.UButtonÜbernehmen.Text = "Übernehmen"
        '
        'UCheckEditorDateienLöschen
        '
        Me.UCheckEditorDateienLöschen.Checked = True
        Me.UCheckEditorDateienLöschen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UCheckEditorDateienLöschen.Location = New System.Drawing.Point(8, 8)
        Me.UCheckEditorDateienLöschen.Name = "UCheckEditorDateienLöschen"
        Me.UCheckEditorDateienLöschen.Size = New System.Drawing.Size(128, 16)
        Me.UCheckEditorDateienLöschen.TabIndex = 0
        Me.UCheckEditorDateienLöschen.Tag = "ResID.DeleteFiles"
        Me.UCheckEditorDateienLöschen.Text = "Dateien löschen"
        Me.UCheckEditorDateienLöschen.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UCheckEditorDateienLöschen.Visible = False
        '
        'UltraToolbarsManager
        '
        Me.UltraToolbarsManager.DesignerFlags = 1
        Me.UltraToolbarsManager.DockWithinContainer = Me
        Me.UltraToolbarsManager.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager.LockToolbars = True
        Me.UltraToolbarsManager.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        ButtonTool6.InstanceProps.IsFirstInGroup = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4, ButtonTool6})
        UltraToolbar1.Text = "UltraToolbar"
        Me.UltraToolbarsManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Me.UltraToolbarsManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraToolbarsManager.ToolbarSettings.BorderStyleDocked = Infragistics.Win.UIElementBorderStyle.None
        Appearance14.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        Appearance15.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool7.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance15
        ButtonTool7.SharedPropsInternal.Caption = "Schließen"
        ButtonTool7.SharedPropsInternal.CustomizerCaption = "Schließen"
        ButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool7.Tag = "ResID.Close"
        Appearance16.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool8.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance16
        ButtonTool8.SharedPropsInternal.Caption = "Scannen"
        ButtonTool8.SharedPropsInternal.CustomizerCaption = "Scannen"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool8.Tag = "ResID.Scan"
        Appearance17.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool9.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance17
        ButtonTool9.SharedPropsInternal.Caption = "Postbox aktualisieren"
        ButtonTool9.SharedPropsInternal.ToolTipText = "Postbox aktualisieren"
        ButtonTool9.Tag = "ResID.RefreshPostbox"
        Appearance18.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool10.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance18
        ButtonTool10.SharedPropsInternal.Caption = "Postbox"
        ButtonTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool10.Tag = "ResID.OpenPostbox"
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool12.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance19
        ButtonTool12.SharedPropsInternal.Caption = "MS Document Imaging"
        ButtonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool12.Tag = "ResID.OpenMSDocumentImaging"
        Me.UltraToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool10, ButtonTool12})
        '
        '_FrmPostbox_Toolbars_Dock_Area_Top
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._FrmPostbox_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmPostbox_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Name = "_FrmPostbox_Toolbars_Dock_Area_Top"
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(682, 29)
        Me._FrmPostbox_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Bottom
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 382)
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Name = "_FrmPostbox_Toolbars_Dock_Area_Bottom"
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(682, 0)
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Left
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._FrmPostbox_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmPostbox_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 29)
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Name = "_FrmPostbox_Toolbars_Dock_Area_Left"
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 353)
        Me._FrmPostbox_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Right
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._FrmPostbox_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmPostbox_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(682, 29)
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Name = "_FrmPostbox_Toolbars_Dock_Area_Right"
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 353)
        Me._FrmPostbox_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'FrmPostbox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(682, 382)
        Me.Controls.Add(Me.Postbox)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Top)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPostbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meine Postbox"
        Me.Postbox.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.UGridPostbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DsPostbox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUntenGrid.ResumeLayout(False)
        CType(Me.UCheckEditorDateienLöschen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmPostbox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Postbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.CancelButton = Me.UltraButtonAbbrechen

            Me.Text = compAutoUI.getRes("MyPostbox")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.UltraToolbarsManager.Tools("PostboxExplorer").SharedProps.AppearancesSmall.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_folder, 32, 32)
            Me.UltraToolbarsManager.Tools("Scannen").SharedProps.AppearancesSmall.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_scannen, 32, 32)

            Me.UltraToolbarsManager.Tools("PostboxAktualisieren").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32)
            Me.DateiLöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.UButtonÜbernehmen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Dim clUsr As New clPostbox()
            Me.postboxverz = clUsr.getPostboxFürBenutzer(True)

            Dim UIElements As New UI
            If gen.IsNull(Me.IDOrdner) Or Me.IDOrdner.ToString = gen.EmptyGuid.ToString Then
                Me.PanelUntenGrid.Visible = False
                Me.PanelUntenGrid.Height = 0
                Me.UGridPostbox.ContextMenu = Nothing
            Else
                Me.PanelUntenGrid.Visible = True
            End If

            Me.loadPostbox(Me.postboxverz)

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FrmPostbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    End Sub

    Private Sub FrmPostbox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager.ToolClick
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "Schließen"
                    Me.Close()

                Case "Scannen"
                    Me.Scan()

                Case "PostboxExplorer"
                    Dim clUsr As New clPostbox()
                    clUsr.OpenPostboxExplorer()
                Case "PostboxAktualisieren"
                    Me.loadPostbox(Me.postboxverz)

                Case "MSDocumentImaging"
                    Me.MSDocuemntImagingÖffnen()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MSDocuemntImagingÖffnen()
        Dim gen As New General
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim clOpen As New clFolder
            clOpen.MSDocumentImagingÖffnen()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub Scan()
        Dim gen As New General
        Try

            Dim frm As New ITSCont.ui.communication.scan.FrmScan()
            frm.ShowDialog(Me)
            If Not frm.apport Then
                Dim fileNameScan As String = ""
                fileNameScan = "Scan_" + Now.Year.ToString + "_" + Now.Month.ToString + "_" + Now.Day.ToString + "_" +
                                    Now.Hour.ToString + "_" + Now.Minute.ToString + "_" + Now.Second.ToString + ".jpg"
                fileNameScan = Me.postboxverz + "\" + fileNameScan
                Dim scanDokuWrite As System.Drawing.Image
                If Not gen.IsNull(frm.PictureBox1.Image) Then
                    scanDokuWrite = frm.PictureBox1.Image
                    scanDokuWrite.Save(fileNameScan)
                    Me.loadPostbox(Me.postboxverz)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub

    Public Function loadPostbox(ByVal postBox As String) As Boolean
        Dim gen As New General
        Try
            Me.DsPostbox2.Clear()
            Dim genMain As New General
            genMain.GarbColl()
            Me.arrÜbernehmen.Clear()


            Dim files() As String = System.IO.Directory.GetFiles(postBox)
            For Each file As String In files
                Dim r_file As dsPostbox.tblPostboxRow
                r_file = Me.DsPostbox2.tblPostbox.NewRow
                Dim initR As New db()
                initR.initRow(r_file)

                'Dim editDat As New ITSCont.core.SystemDb.funct
                Dim editDat As New QS2.functions.vb.functOld()
                r_file.Übernehmen = False
                r_file.Datei = editDat.GetFileName(file, False)
                r_file.ID = System.Guid.NewGuid
                r_file.DateiMitPfad = file

                ' fileInfos einlesen
                Dim FileInfo As New System.IO.FileInfo(file)
                r_file.Erstellt = FileInfo.CreationTime
                r_file.Grösse = FileInfo.Length / 1000
                Try
                    Dim infoFil As New System.IO.FileInfo(file)
                    infoFil.IsReadOnly = False
                Catch ex As Exception
                End Try

                Me.DsPostbox2.tblPostbox.Rows.Add(r_file)
            Next

            Me.UGridPostbox.Refresh()
            Me.UGridPostbox.Text = compAutoUI.getRes("MyPostbox") + " (" + Me.DsPostbox2.tblPostbox.Rows.Count.ToString + ")"
            Me.UGridPostbox.ActiveRow = Nothing

            'If Me.dsPostbox1.tblPostbox.Rows.Count = 0 Then
            '    MsgBox("Hinweis: Die Postbox ist leer!", MsgBoxStyle.Information, "Postbox")
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function

    Public Function CheckIfFileExists(ByVal file As String, ByVal withMsgBox As Boolean) As Boolean
        Dim gen As New General
        Try

            If Not gen.IsNull(file) Then
                If Not System.IO.File.Exists(file) Then
                    If withMsgBox Then
                        doUI.doMessageBox("FileDoesNotExist", "", "!")
                    End If
                    Return False
                Else
                    Return True
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox("FileDoesNotExist", "", "!")
                End If
                Return False
            End If


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function



    Private Sub Postbox_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles UGridPostbox.BeforeCellActivate
        Dim gen As New General
        Try

            If e.Cell.Column.ToString() = "Übernehmen" Or e.Cell.Column.ToString() = "multiTIFF" Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub Postbox_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UGridPostbox.CellChange
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.UGridPostbox.UpdateData()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Postbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGridPostbox.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridPostbox.ActiveRow) Then
                'Me.PBoxVorschau.Image = Nothing
                'If Not gen.IsNull(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                '    If Not Me.CheckIfFileExists(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, True) Then Exit Sub
                '    Try
                '        Dim bmp As New Bitmap(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value.ToString)
                '        Me.PBoxVorschau.Image = bmp
                '    Catch ex As Exception
                '    End Try
                'End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Postbox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGridPostbox.DoubleClick
        Dim gen As New General
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.UGridPostbox.ActiveRow) Then
                If Not gen.IsNull(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                    If Not Me.CheckIfFileExists(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, True) Then Exit Sub
                    'Datei öffnen
                    Dim clOpen As New clFolder
                    If Not clOpen.openFile(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, "", False, Nothing, False, True, False) Then
                        Dim ui1 As New UI()
                        ui1.saveFileAs(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, "")
                        Exit Sub
                    End If
                End If
            End If


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraButtonVorschau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmPostbox_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub UButtonÜbernehmen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonÜbernehmen.Click
        Dim gen As New General
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.arrÜbernehmen.Clear()
            For Each r As dsPostbox.tblPostboxRow In Me.DsPostbox2.tblPostbox
                If r.Übernehmen Then
                    Me.arrÜbernehmen.Add(r.DateiMitPfad)
                End If
            Next

            Me.apport = False
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAbbrechen.Click
        Dim gen As New General
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.apport = True
            Me.arrÜbernehmen.Clear()
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub FrmPostbox_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    End Sub

    Private Sub DateiLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiLöschenToolStripMenuItem.Click
        Dim gen As New General
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.UGridPostbox.ActiveRow) Then
                If Not gen.IsNull(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                    If System.IO.File.Exists(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                        Try
                            System.IO.File.Delete(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value)
                        Catch ex As Exception
                            gen.GetEcxeptionGeneral(ex)
                        End Try
                        Me.loadPostbox(Me.postboxverz)
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MeUGridPostboxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeUGridPostboxToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPostbox.tblPostboxRow In Me.DsPostbox2.tblPostbox
                r.Übernehmen = True
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub KeineDateienInsArchivÜbernehmenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineDateienInsArchivÜbernehmenToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPostbox.tblPostboxRow In Me.DsPostbox2.tblPostbox
                r.Übernehmen = False
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class
