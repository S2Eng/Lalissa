<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contObjects
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("planObject", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPlan")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", 0)
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gridObjects = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WechselnZuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InNeuemTabÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace0 = New System.Windows.Forms.ToolStripSeparator()
        Me.ObjektHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VertragHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ObjektbezugLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsPlan1 = New dsPlan()
        Me.PanelOben = New System.Windows.Forms.Panel()
        Me.btnAssignOrderTask = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAddContract = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAddObject = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.gridObjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DsPlan1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelOben.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridObjects
        '
        Me.gridObjects.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridObjects.DataMember = "planObject"
        Me.gridObjects.DataSource = Me.DsPlan1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridObjects.DisplayLayout.Appearance = Appearance1
        Me.gridObjects.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeadersVisible = False
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.Caption = "Auswahlliste"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 138
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 358
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.gridObjects.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridObjects.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridObjects.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridObjects.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridObjects.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridObjects.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridObjects.DisplayLayout.MaxColScrollRegions = 1
        Me.gridObjects.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridObjects.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridObjects.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridObjects.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridObjects.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridObjects.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridObjects.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridObjects.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridObjects.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridObjects.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridObjects.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridObjects.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridObjects.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridObjects.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridObjects.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.gridObjects, GridBagConstraint1)
        Me.gridObjects.Location = New System.Drawing.Point(5, 5)
        Me.gridObjects.Name = "gridObjects"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.gridObjects, New System.Drawing.Size(195, 151))
        Me.gridObjects.Size = New System.Drawing.Size(379, 187)
        Me.gridObjects.TabIndex = 0
        Me.gridObjects.Text = "Objekte zu Planungseintrag"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WechselnZuToolStripMenuItem, Me.InNeuemTabÖffnenToolStripMenuItem, Me.ToolStripMenuItemSpace0, Me.ObjektHinzufügenToolStripMenuItem, Me.VertragHinzufügenToolStripMenuItem, Me.ToolStripMenuItemSpace1, Me.ObjektbezugLöschenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 126)
        '
        'WechselnZuToolStripMenuItem
        '
        Me.WechselnZuToolStripMenuItem.Name = "WechselnZuToolStripMenuItem"
        Me.WechselnZuToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.WechselnZuToolStripMenuItem.Tag = "ResID.SwitchTo"
        Me.WechselnZuToolStripMenuItem.Text = "Wechseln zu"
        '
        'InNeuemTabÖffnenToolStripMenuItem
        '
        Me.InNeuemTabÖffnenToolStripMenuItem.Name = "InNeuemTabÖffnenToolStripMenuItem"
        Me.InNeuemTabÖffnenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.InNeuemTabÖffnenToolStripMenuItem.Tag = "ResID.NewTab"
        Me.InNeuemTabÖffnenToolStripMenuItem.Text = "In neuem Tab öffnen"
        '
        'ToolStripMenuItemSpace0
        '
        Me.ToolStripMenuItemSpace0.Name = "ToolStripMenuItemSpace0"
        Me.ToolStripMenuItemSpace0.Size = New System.Drawing.Size(181, 6)
        '
        'ObjektHinzufügenToolStripMenuItem
        '
        Me.ObjektHinzufügenToolStripMenuItem.Name = "ObjektHinzufügenToolStripMenuItem"
        Me.ObjektHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ObjektHinzufügenToolStripMenuItem.Tag = "ResID.NewObject"
        Me.ObjektHinzufügenToolStripMenuItem.Text = "Objekt hinzufügen"
        '
        'VertragHinzufügenToolStripMenuItem
        '
        Me.VertragHinzufügenToolStripMenuItem.Name = "VertragHinzufügenToolStripMenuItem"
        Me.VertragHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.VertragHinzufügenToolStripMenuItem.Tag = "ResID.AddContract"
        Me.VertragHinzufügenToolStripMenuItem.Text = "Vertrag hinzufügen"
        '
        'ToolStripMenuItemSpace1
        '
        Me.ToolStripMenuItemSpace1.Name = "ToolStripMenuItemSpace1"
        Me.ToolStripMenuItemSpace1.Size = New System.Drawing.Size(181, 6)
        '
        'ObjektbezugLöschenToolStripMenuItem
        '
        Me.ObjektbezugLöschenToolStripMenuItem.Name = "ObjektbezugLöschenToolStripMenuItem"
        Me.ObjektbezugLöschenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ObjektbezugLöschenToolStripMenuItem.Tag = "ResID.DeleteRelationship"
        Me.ObjektbezugLöschenToolStripMenuItem.Text = "Beziehung löschen"
        '
        'DsPlan1
        '
        Me.DsPlan1.DataSetName = "dsPlan"
        Me.DsPlan1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelOben
        '
        Me.PanelOben.Controls.Add(Me.btnAssignOrderTask)
        Me.PanelOben.Controls.Add(Me.lblAddContract)
        Me.PanelOben.Controls.Add(Me.lblAddObject)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(389, 25)
        Me.PanelOben.TabIndex = 2
        '
        'btnAssignOrderTask
        '
        Appearance13.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance13.FontData.SizeInPoints = 9.0!
        Appearance13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnAssignOrderTask.Appearance = Appearance13
        Me.btnAssignOrderTask.AutoSize = True
        Appearance14.FontData.UnderlineAsString = "True"
        Me.btnAssignOrderTask.HotTrackAppearance = Appearance14
        Me.btnAssignOrderTask.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAssignOrderTask.Location = New System.Drawing.Point(246, 3)
        Me.btnAssignOrderTask.Name = "btnAssignOrderTask"
        Me.btnAssignOrderTask.Size = New System.Drawing.Size(131, 16)
        Me.btnAssignOrderTask.TabIndex = 4
        Me.btnAssignOrderTask.Tag = "ResID.AddOrderTask"
        Me.btnAssignOrderTask.Text = "Order-Task hinzufügen"
        Me.btnAssignOrderTask.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblAddContract
        '
        Appearance15.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance15.FontData.SizeInPoints = 9.0!
        Appearance15.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAddContract.Appearance = Appearance15
        Me.lblAddContract.AutoSize = True
        Appearance16.FontData.UnderlineAsString = "True"
        Me.lblAddContract.HotTrackAppearance = Appearance16
        Me.lblAddContract.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddContract.Location = New System.Drawing.Point(126, 3)
        Me.lblAddContract.Name = "lblAddContract"
        Me.lblAddContract.Size = New System.Drawing.Size(109, 16)
        Me.lblAddContract.TabIndex = 3
        Me.lblAddContract.Tag = "ResID.AddContract"
        Me.lblAddContract.Text = "Vertrag hinzufügen"
        Me.lblAddContract.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblAddObject
        '
        Appearance17.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance17.FontData.SizeInPoints = 9.0!
        Appearance17.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAddObject.Appearance = Appearance17
        Me.lblAddObject.AutoSize = True
        Appearance18.FontData.UnderlineAsString = "True"
        Me.lblAddObject.HotTrackAppearance = Appearance18
        Me.lblAddObject.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddObject.Location = New System.Drawing.Point(4, 3)
        Me.lblAddObject.Name = "lblAddObject"
        Me.lblAddObject.Size = New System.Drawing.Size(104, 16)
        Me.lblAddObject.TabIndex = 2
        Me.lblAddObject.Tag = "ResID.NewObject"
        Me.lblAddObject.Text = "Objekt hinzufügen"
        Me.lblAddObject.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'PanelUnten
        '
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 222)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(389, 25)
        Me.PanelUnten.TabIndex = 3
        Me.PanelUnten.Visible = False
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.gridObjects)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(389, 197)
        Me.UltraGridBagLayoutPanel1.TabIndex = 4
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contObjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.DoubleBuffered = True
        Me.Name = "contObjects"
        Me.Size = New System.Drawing.Size(389, 247)
        CType(Me.gridObjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DsPlan1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelOben.ResumeLayout(False)
        Me.PanelOben.PerformLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelOben As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WechselnZuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DsPlan1 As dsPlan
    Friend WithEvents ObjektbezugLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ObjektHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InNeuemTabÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VertragHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents lblAddContract As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAddObject As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAssignOrderTask As Infragistics.Win.Misc.UltraLabel
    Public WithEvents gridObjects As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
