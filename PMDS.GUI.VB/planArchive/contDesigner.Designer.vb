<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contDesigner
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Controls", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRes", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlText")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsStandardControl")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ActionPerformed")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlTypeShort", -1, Nothing, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlType")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ctrl")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HandleEvent")
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
        Me.gridDesigner = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyCellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsControls1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsControls1 = New QS2.Desktop.ControlManagment.dsControls()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelDetailBar = New System.Windows.Forms.Panel()
        Me.btnControlInfo = New System.Windows.Forms.Button()
        Me.btnControlDatabase = New System.Windows.Forms.Button()
        Me.btnCriterias = New System.Windows.Forms.Button()
        Me.btnRessourcen = New System.Windows.Forms.Button()
        Me.btnRefresh = New Infragistics.Win.Misc.UltraButton()
        Me.lblFound = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.gridDesigner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DsControls1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsControls1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetailBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridDesigner
        '
        Me.gridDesigner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDesigner.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridDesigner.DataMember = "Controls"
        Me.gridDesigner.DataSource = Me.DsControls1BindingSource
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDesigner.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "ID Ressource"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 333
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn2.Width = 107
        UltraGridColumn3.Header.Caption = "Text on UI"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 297
        UltraGridColumn4.Header.Caption = "Is Standard-Control"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 112
        UltraGridColumn5.Header.Caption = "Action performed"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 104
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 215
        UltraGridColumn9.Header.Caption = "Control-Type short"
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.Width = 166
        UltraGridColumn10.Header.Caption = "Control-Type"
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Width = 181
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 215
        UltraGridColumn8.Header.Caption = "Handle-Event"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn9, UltraGridColumn10, UltraGridColumn7, UltraGridColumn8})
        Me.gridDesigner.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridDesigner.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDesigner.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDesigner.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDesigner.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridDesigner.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDesigner.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridDesigner.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDesigner.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridDesigner.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridDesigner.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridDesigner.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDesigner.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridDesigner.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDesigner.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridDesigner.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDesigner.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDesigner.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridDesigner.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridDesigner.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridDesigner.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridDesigner.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDesigner.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridDesigner.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDesigner.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDesigner.Location = New System.Drawing.Point(6, 32)
        Me.gridDesigner.Name = "gridDesigner"
        Me.gridDesigner.Size = New System.Drawing.Size(856, 265)
        Me.gridDesigner.TabIndex = 0
        Me.gridDesigner.Text = "UI-Elemente"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilterToolStripMenuItem, Me.GroupToolStripMenuItem, Me.ToolStripMenuItem1, Me.CopyCellToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(124, 76)
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.CheckOnClick = True
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'GroupToolStripMenuItem
        '
        Me.GroupToolStripMenuItem.CheckOnClick = True
        Me.GroupToolStripMenuItem.Name = "GroupToolStripMenuItem"
        Me.GroupToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.GroupToolStripMenuItem.Text = "Group"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(120, 6)
        '
        'CopyCellToolStripMenuItem
        '
        Me.CopyCellToolStripMenuItem.Name = "CopyCellToolStripMenuItem"
        Me.CopyCellToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.CopyCellToolStripMenuItem.Text = "Copy cell"
        '
        'DsControls1BindingSource
        '
        Me.DsControls1BindingSource.DataSource = Me.DsControls1
        Me.DsControls1BindingSource.Position = 0
        '
        'DsControls1
        '
        Me.DsControls1.DataSetName = "dsControls"
        Me.DsControls1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(807, 337)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(47, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(52, 7)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(760, 21)
        Me.txtSearch.TabIndex = 0
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(10, 11)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(52, 14)
        Me.lblSearch.TabIndex = 3
        Me.lblSearch.Text = "Search"
        '
        'PanelDetailBar
        '
        Me.PanelDetailBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDetailBar.BackColor = System.Drawing.Color.Transparent
        Me.PanelDetailBar.Controls.Add(Me.btnControlInfo)
        Me.PanelDetailBar.Controls.Add(Me.btnControlDatabase)
        Me.PanelDetailBar.Controls.Add(Me.btnCriterias)
        Me.PanelDetailBar.Controls.Add(Me.btnRessourcen)
        Me.PanelDetailBar.Location = New System.Drawing.Point(6, 298)
        Me.PanelDetailBar.Name = "PanelDetailBar"
        Me.PanelDetailBar.Size = New System.Drawing.Size(856, 36)
        Me.PanelDetailBar.TabIndex = 4
        '
        'btnControlInfo
        '
        Me.btnControlInfo.Location = New System.Drawing.Point(238, 3)
        Me.btnControlInfo.Name = "btnControlInfo"
        Me.btnControlInfo.Size = New System.Drawing.Size(72, 30)
        Me.btnControlInfo.TabIndex = 3
        Me.btnControlInfo.Text = "Control-Info"
        Me.btnControlInfo.UseVisualStyleBackColor = True
        '
        'btnControlDatabase
        '
        Me.btnControlDatabase.Location = New System.Drawing.Point(140, 3)
        Me.btnControlDatabase.Name = "btnControlDatabase"
        Me.btnControlDatabase.Size = New System.Drawing.Size(98, 30)
        Me.btnControlDatabase.TabIndex = 2
        Me.btnControlDatabase.Text = "Control-Database"
        Me.btnControlDatabase.UseVisualStyleBackColor = True
        '
        'btnCriterias
        '
        Me.btnCriterias.Location = New System.Drawing.Point(81, 3)
        Me.btnCriterias.Name = "btnCriterias"
        Me.btnCriterias.Size = New System.Drawing.Size(59, 30)
        Me.btnCriterias.TabIndex = 1
        Me.btnCriterias.Text = "Criterias"
        Me.btnCriterias.UseVisualStyleBackColor = True
        '
        'btnRessourcen
        '
        Me.btnRessourcen.Location = New System.Drawing.Point(7, 3)
        Me.btnRessourcen.Name = "btnRessourcen"
        Me.btnRessourcen.Size = New System.Drawing.Size(74, 30)
        Me.btnRessourcen.TabIndex = 0
        Me.btnRessourcen.Text = "Ressourcen"
        Me.btnRessourcen.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(835, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(27, 23)
        Me.btnRefresh.TabIndex = 5
        '
        'lblFound
        '
        Me.lblFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFound.AutoSize = True
        Me.lblFound.Location = New System.Drawing.Point(13, 342)
        Me.lblFound.Name = "lblFound"
        Me.lblFound.Size = New System.Drawing.Size(55, 14)
        Me.lblFound.TabIndex = 6
        Me.lblFound.Text = "Found: 12"
        '
        'contDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblFound)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.PanelDetailBar)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gridDesigner)
        Me.Name = "contDesigner"
        Me.Size = New System.Drawing.Size(868, 362)
        CType(Me.gridDesigner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DsControls1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsControls1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetailBar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridDesigner As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsControls1 As QS2.Desktop.ControlManagment.dsControls
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelDetailBar As System.Windows.Forms.Panel
    Friend WithEvents btnControlInfo As System.Windows.Forms.Button
    Friend WithEvents btnControlDatabase As System.Windows.Forms.Button
    Friend WithEvents btnCriterias As System.Windows.Forms.Button
    Friend WithEvents btnRessourcen As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DsControls1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnRefresh As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblFound As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyCellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
