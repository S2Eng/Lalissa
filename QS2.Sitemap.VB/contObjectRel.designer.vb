<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contObjectRel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contObjectRel))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObjectRel", -1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObject", -1, 11494950)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObjectSub", -1, 11494950)
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
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(11494950)
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.PanelButt = New System.Windows.Forms.Panel()
        Me.btnDel2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnAdd2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanelGrid = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsObject1 = New qs2.core.vb.dsObjects()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.reloadListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelButt.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelGrid.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsObject1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButt
        '
        Me.PanelButt.Controls.Add(Me.btnDel2)
        Me.PanelButt.Controls.Add(Me.btnAdd2)
        Me.PanelButt.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButt.Location = New System.Drawing.Point(314, 0)
        Me.PanelButt.Name = "PanelButt"
        Me.PanelButt.Size = New System.Drawing.Size(22, 252)
        Me.PanelButt.TabIndex = 0
        '
        'btnDel2
        '
        Me.btnDel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnDel2.Appearance = Appearance1
        Me.btnDel2.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnDel2.Location = New System.Drawing.Point(1, 19)
        Me.btnDel2.Name = "btnDel2"
        Me.btnDel2.OwnAutoTextYN = False
        Me.btnDel2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Loeschen
        Me.btnDel2.OwnPictureTxt = ""
        Me.btnDel2.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnDel2.OwnTooltipText = ""
        Me.btnDel2.OwnTooltipTitle = Nothing
        Me.btnDel2.Size = New System.Drawing.Size(20, 19)
        Me.btnDel2.TabIndex = 11
        '
        'btnAdd2
        '
        Me.btnAdd2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnAdd2.Appearance = Appearance2
        Me.btnAdd2.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnAdd2.Location = New System.Drawing.Point(1, 1)
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.OwnAutoTextYN = False
        Me.btnAdd2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Plus
        Me.btnAdd2.OwnPictureTxt = ""
        Me.btnAdd2.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnAdd2.OwnTooltipText = ""
        Me.btnAdd2.OwnTooltipTitle = Nothing
        Me.btnAdd2.Size = New System.Drawing.Size(20, 19)
        Me.btnAdd2.TabIndex = 10
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanelGrid)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(314, 252)
        Me.PanelGrid.TabIndex = 1
        '
        'UltraGridBagLayoutPanelGrid
        '
        Me.UltraGridBagLayoutPanelGrid.Controls.Add(Me.UltraGrid1)
        Me.UltraGridBagLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelGrid.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelGrid.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelGrid.Name = "UltraGridBagLayoutPanelGrid"
        Me.UltraGridBagLayoutPanelGrid.Size = New System.Drawing.Size(314, 252)
        Me.UltraGridBagLayoutPanelGrid.TabIndex = 1
        '
        'UltraGrid1
        '
        Me.UltraGrid1.DataMember = "tblObjectRel"
        Me.UltraGrid1.DataSource = Me.DsObject1
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid1.DisplayLayout.Appearance = Appearance3
        Me.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeadersVisible = False
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn6.Width = 293
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance10
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance13
        Me.UltraGrid1.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "users"
        Me.UltraGrid1.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1})
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.OriginX = 1
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanelGrid.SetGridBagConstraint(Me.UltraGrid1, GridBagConstraint1)
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGridBagLayoutPanelGrid.SetPreferredSize(Me.UltraGrid1, New System.Drawing.Size(249, 197))
        Me.UltraGrid1.Size = New System.Drawing.Size(314, 252)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Represents"
        '
        'DsObject1
        '
        Me.DsObject1.DataSetName = "dsObject"
        Me.DsObject1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.reloadListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 26)
        '
        'reloadListToolStripMenuItem
        '
        Me.reloadListToolStripMenuItem.Name = "reloadListToolStripMenuItem"
        Me.reloadListToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.reloadListToolStripMenuItem.Text = "Reload list"
        '
        'contObjectRel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelButt)
        Me.Name = "contObjectRel"
        Me.Size = New System.Drawing.Size(336, 252)
        Me.PanelButt.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanelGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelGrid.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsObject1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelButt As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanelGrid As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsObject1 As qs2.core.vb.dsObjects
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents reloadListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDel2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnAdd2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton

End Class
