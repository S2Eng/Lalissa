
Imports System.Windows.Forms


Public Class FrmPostbox
    Inherits System.Windows.Forms.Form

    Public dsPostbox1 As New dsPlanArchive
    Public IDOrdner As New System.Guid
    Public apport As Boolean = True

    Public arrÜbernehmen As New ArrayList

    Private IDWindow As New System.Guid(System.Guid.NewGuid.ToString)
    Public MeinePostboxxy As String = ""

    Public arrFiles_NewMulti As New SortedList
    Public arrFiles_NewMulti_lastKey As Integer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private usr As New GeneralArchiv()

    Private genMain As New GeneralArchiv()

    Public Enum typDateiVorschau
        MakeMultiTIFF = 0
    End Enum

    Public typ As New eTyp
    Public Enum eTyp
        Benutzer = 0
    End Enum




#Region " Vom Windows Form Designer generierter Code "

    Public Sub New(ByVal typ As eTyp)
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        Me.typ = typ
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
    Friend WithEvents ContextMenuPostbox As System.Windows.Forms.ContextMenu
    Friend WithEvents MItemAlleDateienÜbernehmen As System.Windows.Forms.MenuItem
    Friend WithEvents MItemKeineDateienÜbernehmen As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MItemAlleDateienMultiTIFF As System.Windows.Forms.MenuItem
    Friend WithEvents MItemKeineDateienMultiTIFF As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MItemDateiLöschen As System.Windows.Forms.MenuItem
    Public WithEvents UGridPostbox As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Postbox As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenGrid As System.Windows.Forms.Panel
    Friend WithEvents TimerLoadPostbox As System.Windows.Forms.Timer
    Friend WithEvents UltraButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonÜbernehmen As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxExplorer")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxAktualisieren")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MultiTIFFErzeugen")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MSDocumentImaging")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxAktualisieren")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxExplorer")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MultiTIFFErzeugen")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MSDocumentImaging")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Postbox = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UGridPostbox = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuPostbox = New System.Windows.Forms.ContextMenu()
        Me.MItemAlleDateienÜbernehmen = New System.Windows.Forms.MenuItem()
        Me.MItemKeineDateienÜbernehmen = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MItemAlleDateienMultiTIFF = New System.Windows.Forms.MenuItem()
        Me.MItemKeineDateienMultiTIFF = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MItemDateiLöschen = New System.Windows.Forms.MenuItem()
        Me.PanelUntenGrid = New System.Windows.Forms.Panel()
        Me.UltraButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonÜbernehmen = New Infragistics.Win.Misc.UltraButton()
        Me.UCheckEditorDateienLöschen = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._FrmPostbox_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._FrmPostbox_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.TimerLoadPostbox = New System.Windows.Forms.Timer(Me.components)
        Me.Postbox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UGridPostbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUntenGrid.SuspendLayout()
        CType(Me.UCheckEditorDateienLöschen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Postbox
        '
        Me.Postbox.Controls.Add(Me.Panel1)
        Me.Postbox.Controls.Add(Me.PanelUntenGrid)
        Me.Postbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Postbox.Location = New System.Drawing.Point(0, 75)
        Me.Postbox.Name = "Postbox"
        Me.Postbox.Size = New System.Drawing.Size(592, 307)
        Me.Postbox.TabIndex = 462
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UGridPostbox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(592, 266)
        Me.Panel1.TabIndex = 459
        '
        'UGridPostbox
        '
        Me.UGridPostbox.ContextMenu = Me.ContextMenuPostbox
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridPostbox.DisplayLayout.Appearance = Appearance1
        Me.UGridPostbox.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
        Me.UGridPostbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridPostbox.Location = New System.Drawing.Point(0, 0)
        Me.UGridPostbox.Name = "UGridPostbox"
        Me.UGridPostbox.Size = New System.Drawing.Size(592, 266)
        Me.UGridPostbox.TabIndex = 0
        Me.UGridPostbox.Text = "Postbox ..."
        Me.UGridPostbox.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate
        Me.UGridPostbox.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ContextMenuPostbox
        '
        Me.ContextMenuPostbox.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MItemAlleDateienÜbernehmen, Me.MItemKeineDateienÜbernehmen, Me.MenuItem1, Me.MItemAlleDateienMultiTIFF, Me.MItemKeineDateienMultiTIFF, Me.MenuItem2, Me.MItemDateiLöschen})
        '
        'MItemAlleDateienÜbernehmen
        '
        Me.MItemAlleDateienÜbernehmen.Index = 0
        Me.MItemAlleDateienÜbernehmen.Text = "Alle Dateien ins Archiv übernehmen ..."
        '
        'MItemKeineDateienÜbernehmen
        '
        Me.MItemKeineDateienÜbernehmen.Index = 1
        Me.MItemKeineDateienÜbernehmen.Text = "Keine Dateien ins Archiv übernehmen ..."
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "-"
        '
        'MItemAlleDateienMultiTIFF
        '
        Me.MItemAlleDateienMultiTIFF.Index = 3
        Me.MItemAlleDateienMultiTIFF.Text = "Alle Dateien für Multi-Tiff auswählen ..."
        Me.MItemAlleDateienMultiTIFF.Visible = False
        '
        'MItemKeineDateienMultiTIFF
        '
        Me.MItemKeineDateienMultiTIFF.Index = 4
        Me.MItemKeineDateienMultiTIFF.Text = "Keine Dateien für Multi-Tiff auswählen ..."
        Me.MItemKeineDateienMultiTIFF.Visible = False
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.Text = "-"
        Me.MenuItem2.Visible = False
        '
        'MItemDateiLöschen
        '
        Me.MItemDateiLöschen.Index = 6
        Me.MItemDateiLöschen.Text = "Datei löschen"
        '
        'PanelUntenGrid
        '
        Me.PanelUntenGrid.BackColor = System.Drawing.Color.White
        Me.PanelUntenGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelUntenGrid.Controls.Add(Me.UltraButtonAbbrechen)
        Me.PanelUntenGrid.Controls.Add(Me.UButtonÜbernehmen)
        Me.PanelUntenGrid.Controls.Add(Me.UCheckEditorDateienLöschen)
        Me.PanelUntenGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUntenGrid.Location = New System.Drawing.Point(0, 266)
        Me.PanelUntenGrid.Name = "PanelUntenGrid"
        Me.PanelUntenGrid.Size = New System.Drawing.Size(592, 41)
        Me.PanelUntenGrid.TabIndex = 1
        '
        'UltraButtonAbbrechen
        '
        Appearance13.BackColor = System.Drawing.Color.Black
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance13.TextHAlignAsString = "Center"
        Me.UltraButtonAbbrechen.Appearance = Appearance13
        Me.UltraButtonAbbrechen.BackColorInternal = System.Drawing.Color.White
        Me.UltraButtonAbbrechen.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraButtonAbbrechen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance14.FontData.BoldAsString = "False"
        Me.UltraButtonAbbrechen.HotTrackAppearance = Appearance14
        Me.UltraButtonAbbrechen.Location = New System.Drawing.Point(315, 5)
        Me.UltraButtonAbbrechen.Name = "UltraButtonAbbrechen"
        Me.UltraButtonAbbrechen.Padding = New System.Drawing.Size(2, 0)
        Me.UltraButtonAbbrechen.Size = New System.Drawing.Size(84, 28)
        Me.UltraButtonAbbrechen.TabIndex = 2
        Me.UltraButtonAbbrechen.Text = "Abbrechen"
        Me.UltraButtonAbbrechen.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraButtonAbbrechen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UButtonÜbernehmen
        '
        Appearance15.BackColor = System.Drawing.Color.Black
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.Image = "ICO_abrechnung übernehmen.ico"
        Appearance15.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance15.TextHAlignAsString = "Center"
        Me.UButtonÜbernehmen.Appearance = Appearance15
        Me.UButtonÜbernehmen.BackColorInternal = System.Drawing.Color.White
        Me.UButtonÜbernehmen.Cursor = System.Windows.Forms.Cursors.Default
        Me.UButtonÜbernehmen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance16.FontData.BoldAsString = "False"
        Me.UButtonÜbernehmen.HotTrackAppearance = Appearance16
        Me.UButtonÜbernehmen.Location = New System.Drawing.Point(202, 5)
        Me.UButtonÜbernehmen.Name = "UButtonÜbernehmen"
        Me.UButtonÜbernehmen.Padding = New System.Drawing.Size(2, 0)
        Me.UButtonÜbernehmen.Size = New System.Drawing.Size(112, 28)
        Me.UButtonÜbernehmen.TabIndex = 1
        Me.UButtonÜbernehmen.Text = "Übernehmen"
        Me.UButtonÜbernehmen.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UButtonÜbernehmen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UCheckEditorDateienLöschen
        '
        Me.UCheckEditorDateienLöschen.Checked = True
        Me.UCheckEditorDateienLöschen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UCheckEditorDateienLöschen.Location = New System.Drawing.Point(9, 12)
        Me.UCheckEditorDateienLöschen.Name = "UCheckEditorDateienLöschen"
        Me.UCheckEditorDateienLöschen.Size = New System.Drawing.Size(128, 16)
        Me.UCheckEditorDateienLöschen.TabIndex = 0
        Me.UCheckEditorDateienLöschen.Text = "Dateien löschen"
        Me.UCheckEditorDateienLöschen.Visible = False
        '
        'UltraToolbarsManager
        '
        Me.UltraToolbarsManager.DesignerFlags = 1
        Me.UltraToolbarsManager.DockWithinContainer = Me
        Me.UltraToolbarsManager.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager.LockToolbars = True
        Me.UltraToolbarsManager.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        ButtonTool5.InstanceProps.IsFirstInGroup = True
        ButtonTool6.InstanceProps.IsFirstInGroup = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool5, ButtonTool6})
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
        Appearance17.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance17
        Appearance18.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool7.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance18
        ButtonTool7.SharedPropsInternal.Caption = "Schließen"
        ButtonTool7.SharedPropsInternal.CustomizerCaption = "Schließen"
        ButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool9.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance19
        ButtonTool9.SharedPropsInternal.Caption = "Aktualisieren"
        ButtonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool9.SharedPropsInternal.ToolTipText = "Postbox aktualisieren"
        Appearance20.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool10.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance20
        ButtonTool10.SharedPropsInternal.Caption = "Postbox"
        ButtonTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance21.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool11.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance21
        ButtonTool11.SharedPropsInternal.Caption = "Multi-TIFF erzeugen"
        ButtonTool11.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance22.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool12.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance22
        ButtonTool12.SharedPropsInternal.Caption = "MS Document Imaging"
        ButtonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.UltraToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool9, ButtonTool10, ButtonTool11, ButtonTool12})
        Me.UltraToolbarsManager.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        '_FrmPostbox_Toolbars_Dock_Area_Top
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._FrmPostbox_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmPostbox_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Name = "_FrmPostbox_Toolbars_Dock_Area_Top"
        Me._FrmPostbox_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(592, 75)
        Me._FrmPostbox_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Bottom
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 382)
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Name = "_FrmPostbox_Toolbars_Dock_Area_Bottom"
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(592, 0)
        Me._FrmPostbox_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Left
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._FrmPostbox_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmPostbox_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 75)
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Name = "_FrmPostbox_Toolbars_Dock_Area_Left"
        Me._FrmPostbox_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 307)
        Me._FrmPostbox_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_FrmPostbox_Toolbars_Dock_Area_Right
        '
        Me._FrmPostbox_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPostbox_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._FrmPostbox_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmPostbox_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(592, 75)
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Name = "_FrmPostbox_Toolbars_Dock_Area_Right"
        Me._FrmPostbox_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 307)
        Me._FrmPostbox_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager
        '
        'TimerLoadPostbox
        '
        Me.TimerLoadPostbox.Interval = 15000
        '
        'FrmPostbox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(592, 382)
        Me.Controls.Add(Me.Postbox)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._FrmPostbox_Toolbars_Dock_Area_Top)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPostbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meine Postbox"
        Me.Postbox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UGridPostbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUntenGrid.ResumeLayout(False)
        CType(Me.UCheckEditorDateienLöschen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmPostbox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim gen As New GeneralArchiv
        Try
            Dim genMain As New GeneralArchiv()
            genMain.GarbColl()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub Postbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.UButtonÜbernehmen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            If Not System.IO.Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                MsgBox("Auf Ihre Postbox kann nicht zugegriffen werden!", MsgBoxStyle.Information, "Postbox öffnen")
                Try
                    Throw New Exception("Postbox_Load: Ihre Postbox existiert nicht! Pfad: '" + PMDS.Global.ENV.path_Temp + "'")
                Catch ex As Exception
                    gen.GetEcxeptionGeneral(ex)
                End Try
                Me.Close()
            End If

            Dim UIElements As New UIElements
            If gen.IsNull(Me.IDOrdner) Or Me.IDOrdner.ToString = gen.EmptyGuid.ToString Then

                Me.PanelUntenGrid.Visible = False
                Me.PanelUntenGrid.Height = 0
                Me.UGridPostbox.ContextMenu = Nothing

                UIElements.Menu_ItemOnOff(Me.UltraToolbarsManager, 0, "MultiTIFFErzeugen", False)
                Me.TimerLoadPostbox.Enabled = True
            Else
                Me.PanelUntenGrid.Visible = True
                UIElements.Menu_ItemOnOff(Me.UltraToolbarsManager, 0, "MultiTIFFErzeugen", True)

                Me.TimerLoadPostbox.Enabled = False

            End If

            Me.loadPostbox()
            Me.Refresh()
            Me.resizeForm()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FrmPostbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim gen As New GeneralArchiv
        Try

            Me.resizeForm()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Private Sub resizeForm()
        Dim gen As New GeneralArchiv
        Try

        Catch ex As Exception
            Throw New Exception("resizeForm: " + ex.ToString())
        Finally
        End Try
    End Sub
    Private Sub FrmPostbox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.TimerLoadPostbox.Enabled = False

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager.ToolClick
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "Schließen"
                    Me.Close()

                Case "MultiTIFFErzeugen"
                    Me.VorschauMultiTIFFERzeugen(typDateiVorschau.MakeMultiTIFF, "")

                Case "PostboxExplorer"
                    Dim clUsr As New GeneralArchiv
                    clUsr.OpenPostboxExplorer()

                Case "PostboxAktualisieren"
                    Me.loadPostbox()

                Case "MSDocumentImaging"
                    Me.MSDocuemntImagingÖffnen()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MSDocuemntImagingÖffnen()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim clOpen As New clFolder
            clOpen.MSDocumentImagingÖffnen()

        Catch ex As Exception
            Throw New Exception("MSDocuemntImagingÖffnen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub VorschauMultiTIFFERzeugen(ByVal typ As typDateiVorschau, ByVal filePreview As String)
        Dim gen As New GeneralArchiv
        Try
            Dim fileNameMULTI As String = ""
            Dim bMultiTiffGenerieren As Boolean = False
            If typ = typDateiVorschau.MakeMultiTIFF Then
                bMultiTiffGenerieren = True
                fileNameMULTI = "multiTiff_" + Now.Year.ToString + "_" + Now.Month.ToString + "_" + Now.Day.ToString + "_" +
                Now.Hour.ToString + "_" + Now.Minute.ToString + "_" + Now.Second.ToString + ".tiff"
                fileNameMULTI = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, fileNameMULTI)
                If Not gen.IsNull(Me.arrFiles_NewMulti) Then
                    If Me.arrFiles_NewMulti.Count > 0 Then
                        Dim editor As New contMultiTIFFEditor
                        For i As Integer = 0 To Me.arrFiles_NewMulti.Count - 1
                            editor.arrFiles.Add(Me.arrFiles_NewMulti.GetKey(i), Me.arrFiles_NewMulti.Item(Me.arrFiles_NewMulti.GetKey(i)))
                        Next
                        editor.refreshPreview(fileNameMULTI, bMultiTiffGenerieren)
                        editor = Nothing
                        Dim genMain As New GeneralArchiv
                        genMain.GarbColl()

                        If MsgBox("Sollen die ausgewählten Tiff-Dateien aus der Postbox gelöscht werden?", MsgBoxStyle.YesNo, "ITSCont - Postbox") = MsgBoxResult.Yes Then
                            For i As Integer = 0 To Me.arrFiles_NewMulti.Count - 1
                                If System.IO.File.Exists(Me.arrFiles_NewMulti.Item(Me.arrFiles_NewMulti.GetKey(i))) Then
                                    Try
                                        System.IO.File.Delete(Me.arrFiles_NewMulti.Item(Me.arrFiles_NewMulti.GetKey(i)))
                                    Catch ex As Exception
                                        'gen.GetEcxeptionArchiv(ex)
                                    End Try
                                End If
                            Next
                        End If

                        Me.arrFiles_NewMulti.Clear()
                        Me.loadPostbox()

                    Else
                        MsgBox("Keine Dateien ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                        Exit Sub
                    End If
                End If

                'ElseIf typ = typDateiVorschau.Vorschau Then

                '    bMultiTiffGenerieren = False
                '    fileNameMULTI = ""

                '    Dim strOp As New S2CoreSystem.StringOperate
                '    If LCase(strOp.GetFiletyp(filePreview)) = LCase(".bmp") Or _
                '            LCase(strOp.GetFiletyp(filePreview)) = LCase(".jpg") Or _
                '             LCase(strOp.GetFiletyp(filePreview)) = LCase(".gif") Or _
                '            LCase(strOp.GetFiletyp(filePreview)) = LCase(".tif") Or _
                '            LCase(strOp.GetFiletyp(filePreview)) = LCase(".tiff") Then

                '        fileNameMULTI = filePreview
                '        Me.editor.arrFiles.Add(0, filePreview)

                '    End If

                '    If Not gen.IsNull(Me.editor.arrFiles) Then
                '        If Me.editor.arrFiles.Count > 0 Then
                '            Me.editor.refreshPreview(fileNameMULTI, bMultiTiffGenerieren)
                '        End If
                '    End If

            End If

        Catch ex As Exception
            Throw New Exception("VorschauMultiTIFFERzeugen: " + ex.ToString())
        End Try
    End Sub

    Public Sub initPostbox()
        Dim gen As New GeneralArchiv
        Try
            Me.UGridPostbox.DataSource = Me.dsPostbox1.tblPostbox
            Me.UGridPostbox.DataBind()

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").Width = 200
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").Header.Appearance.BackColor = System.Drawing.Color.LightGray
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").Header.Appearance.ForeColor = System.Drawing.Color.Black
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").Header.Caption = "Datei"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").DataType.GetType("System.String")
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Datei").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Width = 60
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Header.Appearance.BackColor = System.Drawing.Color.LightGray
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Header.Appearance.ForeColor = System.Drawing.Color.Black
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Header.Caption = "Übernehmen"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").DataType.GetType("System.Booelan")
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Width = 55
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Appearance.BackColor = System.Drawing.Color.LightGray
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Appearance.ForeColor = System.Drawing.Color.Black
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Caption = "MultiTIFF"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").DataType.GetType("System.Booelan")
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Width = 65
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Appearance.BackColor = System.Drawing.Color.LightGray
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Appearance.ForeColor = System.Drawing.Color.Black
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Caption = "Erstellt"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").DataType.GetType("System.Date")
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Format = "dd.MM.yyyy"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Erstellt").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Width = 80
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Header.Appearance.BackColor = System.Drawing.Color.LightGray
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Header.Appearance.ForeColor = System.Drawing.Color.Black
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Header.Caption = "Grösse(kB)"
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").DataType.GetType("System.Double")
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Grösse").Format = "###,###,##0.0#"

            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            Me.UGridPostbox.DisplayLayout.Bands(0).Columns("DateiMitPfad").Hidden = True
            If gen.IsNull(Me.IDOrdner) Or Me.IDOrdner.ToString = gen.EmptyGuid.ToString Then
                Me.UGridPostbox.DisplayLayout.Bands(0).Columns("Übernehmen").Hidden = True
                Me.UGridPostbox.DisplayLayout.Bands(0).Columns("multiTIFF").Hidden = True
            End If

        Catch ex As Exception
            Throw New Exception("initPostbox: " + ex.ToString())
        End Try
    End Sub
    Public Function checkPostboxxy() As Boolean
        Dim gen As New GeneralArchiv
        Try
            'Dim genMain As New General

            'If Me.typ = eTyp.Benutzer Then
            '    Dim postBoxUsr As String = genMain.path_Postbox + "\" + usr.actUser
            '    If Not System.IO.Directory.Exists(postBoxUsr) Then
            '        System.IO.Directory.CreateDirectory(postBoxUsr)
            '    End If
            '    Me.MeinePostbox = postBoxUsr
            '    Me.Text = " Meine Postbox ..."

            'ElseIf Me.typ = eTyp.Allgemein Then
            '    Dim postBoxUsr As String = genMain.path_Postbox + "\AllgemeinePostbox"
            '    If Not System.IO.Directory.Exists(postBoxUsr) Then
            '        System.IO.Directory.CreateDirectory(postBoxUsr)
            '    End If
            '    Me.MeinePostbox = postBoxUsr
            '    Me.Text = " Allgemeine Postbox ..."
            'End If

            Return True

        Catch ex As Exception
            Throw New Exception("checkPostbox: " + ex.ToString())
        End Try
    End Function
    Public Function loadPostbox() As Boolean
        Dim gen As New GeneralArchiv
        Try
            If System.IO.Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                Me.dsPostbox1.Clear()

                Dim genMain As New GeneralArchiv
                genMain.GarbColl()

                Me.UGridPostbox.Text = "Postbox ..."
                Me.arrÜbernehmen.Clear()

                Dim files() As String = System.IO.Directory.GetFiles(PMDS.Global.ENV.path_Temp)
                For Each file As String In files
                    Dim r_file As dsPlanArchive.tblPostboxRow
                    r_file = Me.dsPostbox1.tblPostbox.NewRow
                    Dim db1 As New db()
                    db1.initRow(r_file)

                    Dim editDat As New clStringOperate
                    r_file.Übernehmen = False
                    r_file.multiTIFF = False
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

                    Me.dsPostbox1.tblPostbox.Rows.Add(r_file)
                Next
                Me.UGridPostbox.Text = "Meine Postbox (" + Me.dsPostbox1.tblPostbox.Rows.Count.ToString + ")"
                Me.initPostbox()
                Me.UGridPostbox.ActiveRow = Nothing
            End If

        Catch ex As Exception
            Throw New Exception("loadPostbox: " + ex.ToString())
        End Try
    End Function

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoadPostbox.Tick
        Dim gen As New GeneralArchiv
        Try

            Me.loadPostbox()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function CheckIfFileExists(ByVal file As String, ByVal withMsgBox As Boolean) As Boolean
        Dim gen As New GeneralArchiv
        Try

            If Not gen.IsNull(file) Then
                If Not System.IO.File.Exists(file) Then
                    If withMsgBox Then
                        MsgBox("Die Datei existiert nicht in der Postbox!", MsgBoxStyle.Information, "Archivsystem")
                    End If
                    Return False
                Else
                    Return True
                End If
            Else
                If withMsgBox Then
                    MsgBox("Die Datei existiert nicht in der Postbox!", MsgBoxStyle.Information, "Archivsystem")
                End If
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("CheckIfFileExists: " + ex.ToString())
        End Try
    End Function

    Private Sub MItemAlleDateienÜbernehmen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemAlleDateienÜbernehmen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPlanArchive.tblPostboxRow In Me.dsPostbox1.tblPostbox
                r.Übernehmen = True
            Next

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MItemKeineDateienÜbernehmen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemKeineDateienÜbernehmen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPlanArchive.tblPostboxRow In Me.dsPostbox1.tblPostbox
                r.Übernehmen = False
            Next

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemAlleDateienMultiTIFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemAlleDateienMultiTIFF.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPlanArchive.tblPostboxRow In Me.dsPostbox1.tblPostbox
                r.multiTIFF = True
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MItemKeineDateienMultiTIFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemKeineDateienMultiTIFF.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            For Each r As dsPlanArchive.tblPostboxRow In Me.dsPostbox1.tblPostbox
                r.multiTIFF = False
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MItemDateiLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemDateiLöschen.Click
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.UGridPostbox.ActiveRow) Then
                If Not gen.IsNull(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                    If System.IO.File.Exists(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                        Try
                            System.IO.File.Delete(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value)
                        Catch ex As Exception
                            gen.GetEcxeptionArchiv(ex)
                        End Try
                        Me.loadPostbox()
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Postbox_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridPostbox.InitializeLayout

    End Sub
    Private Sub Postbox_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGridPostbox.AfterRowActivate

    End Sub
    Private Sub Postbox_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles UGridPostbox.BeforeCellActivate
        Dim gen As New GeneralArchiv
        Try
            If e.Cell.Column.ToString() = "Übernehmen" Or e.Cell.Column.ToString() = "multiTIFF" Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Private Sub Postbox_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UGridPostbox.CellChange
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.UGridPostbox.UpdateData()

            If e.Cell.Column.ToString() = "multiTIFF" Then
                If Not gen.IsNull(e.Cell.Row.Cells("DateiMitPfad").Value) Then
                    'Datei öffnen
                    If e.Cell.Column.ToString = "multiTIFF" Then
                        If e.Cell.Value = True Then
                            Dim strOp As New clStringOperate
                            If LCase(strOp.GetFiletyp(e.Cell.Row.Cells("DateiMitPfad").Value)) = LCase(".tif") Or _
                                   LCase(strOp.GetFiletyp(e.Cell.Row.Cells("DateiMitPfad").Value)) = LCase(".tiff") Then

                                Dim cl As New contMultiTIFFEditor
                                If cl.GetCountSites(e.Cell.Row.Cells("DateiMitPfad").Value) <= 1 Then
                                    Me.arrFiles_NewMulti.Add(Me.arrFiles_NewMulti_lastKey, e.Cell.Row.Cells("DateiMitPfad").Value)
                                    Me.arrFiles_NewMulti_lastKey += 1
                                Else
                                    Dim strOperat As New clStringOperate
                                    Dim sText As String = ""
                                    sText = "Die Datei ´'" + strOperat.GetFileName(e.Cell.Row.Cells("DateiMitPfad").Value, False) + "' ist eine Multi-Tiff-Datei!" + vbNewLine + _
                                               "(Multi-Tiff-Dateien können nicht hinzugefügt werden!)"
                                    MsgBox(sText, MsgBoxStyle.Information, "Archivsystem")
                                    e.Cell.Value = False
                                End If
                            Else
                                Dim strOperat As New clStringOperate
                                Dim sText As String = ""
                                sText = "Die Datei ´'" + strOperat.GetFileName(e.Cell.Row.Cells("DateiMitPfad").Value, False) + "' kann nicht zum Multi-Tiff hinzugefügt werden!" + vbNewLine + _
                                           "(Zu einer Multi-Tiff können nur tif-Dateien hinzugefügt werden!)"
                                MsgBox(sText, MsgBoxStyle.Information, "Archivsystem")
                                e.Cell.Value = False
                            End If
                        ElseIf e.Cell.Value = False Then
                            For i As Integer = 0 To Me.arrFiles_NewMulti.Count - 1
                                Dim file As String = Me.arrFiles_NewMulti.Item(Me.arrFiles_NewMulti.GetKey(i))
                                If file = e.Cell.Row.Cells("DateiMitPfad").Value Then
                                    Me.arrFiles_NewMulti.RemoveAt(i)
                                    Exit For
                                End If

                            Next
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Postbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGridPostbox.Click
        Dim gen As New GeneralArchiv
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
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Postbox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGridPostbox.DoubleClick
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.UGridPostbox.ActiveRow) Then
                If Not gen.IsNull(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value) Then
                    If Not Me.CheckIfFileExists(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, True) Then Exit Sub
                    'Datei öffnen
                    Dim clOpen As New clFolder
                    If Not clOpen.openFile(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, False) Then
                        clOpen.DateiSpeichernUnter(Me.UGridPostbox.ActiveRow.Cells("DateiMitPfad").Value, "", False)
                        Exit Sub
                    End If
                End If
            End If


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraButtonVorschau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmPostbox_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub UButtonÜbernehmen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonÜbernehmen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.arrÜbernehmen.Clear()
            For Each r As dsPlanArchive.tblPostboxRow In Me.dsPostbox1.tblPostbox
                If r.Übernehmen Then
                    Me.arrÜbernehmen.Add(r.DateiMitPfad)
                End If
            Next

            Me.apport = False
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAbbrechen.Click
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.apport = True
            Me.arrÜbernehmen.Clear()
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmPostbox_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    End Sub

End Class
