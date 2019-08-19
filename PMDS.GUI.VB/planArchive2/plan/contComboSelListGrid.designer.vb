<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contComboSelListGrid
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
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("search")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("SelListHelper", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
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
        Me.DsAuswahllisten1 = New PMDS.GUI.VB.dsAuswahllisten()
        Me.cboComboBoxSelList = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AuswahlLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ImageListSmall = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboComboBoxSelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsAuswahllisten1
        '
        Me.DsAuswahllisten1.DataSetName = "dsAuswahllisten"
        Me.DsAuswahllisten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboComboBoxSelList
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColorDisabled = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboComboBoxSelList.Appearance = Appearance1
        Me.cboComboBoxSelList.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboComboBoxSelList.AutoSize = False
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        EditorButton1.Appearance = Appearance2
        EditorButton1.Key = "search"
        Me.cboComboBoxSelList.ButtonsRight.Add(EditorButton1)
        Me.cboComboBoxSelList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.cboComboBoxSelList.DataMember = "SelListHelper"
        Me.cboComboBoxSelList.DataSource = Me.DsAuswahllisten1
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboComboBoxSelList.DisplayLayout.Appearance = Appearance3
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn7.Width = 60
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 180
        UltraGridColumn6.Header.Caption = "Entry"
        UltraGridColumn6.Header.VisiblePosition = 4
        UltraGridColumn6.Width = 220
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn7, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.cboComboBoxSelList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.cboComboBoxSelList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboComboBoxSelList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.cboComboBoxSelList.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboComboBoxSelList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.cboComboBoxSelList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboComboBoxSelList.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.cboComboBoxSelList.DisplayLayout.MaxColScrollRegions = 1
        Me.cboComboBoxSelList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboComboBoxSelList.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboComboBoxSelList.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.cboComboBoxSelList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboComboBoxSelList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.cboComboBoxSelList.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboComboBoxSelList.DisplayLayout.Override.CellAppearance = Appearance10
        Me.cboComboBoxSelList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboComboBoxSelList.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.cboComboBoxSelList.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.cboComboBoxSelList.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.cboComboBoxSelList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboComboBoxSelList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.cboComboBoxSelList.DisplayLayout.Override.RowAppearance = Appearance13
        Me.cboComboBoxSelList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboComboBoxSelList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.cboComboBoxSelList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboComboBoxSelList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboComboBoxSelList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboComboBoxSelList.DisplayMember = "Description"
        Me.cboComboBoxSelList.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboComboBoxSelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboComboBoxSelList.Location = New System.Drawing.Point(0, 0)
        Me.cboComboBoxSelList.Name = "cboComboBoxSelList"
        Me.cboComboBoxSelList.Size = New System.Drawing.Size(231, 24)
        Me.cboComboBoxSelList.TabIndex = 11
        Me.cboComboBoxSelList.ValueMember = "IDOnwInt"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuswahlLöschenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(164, 26)
        '
        'AuswahlLöschenToolStripMenuItem
        '
        Me.AuswahlLöschenToolStripMenuItem.Name = "AuswahlLöschenToolStripMenuItem"
        Me.AuswahlLöschenToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AuswahlLöschenToolStripMenuItem.Tag = "ResID.ClearSelection"
        Me.AuswahlLöschenToolStripMenuItem.Text = "Auswahl löschen"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'ImageListSmall
        '
        Me.ImageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListSmall.ImageSize = New System.Drawing.Size(12, 12)
        Me.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent
        '
        'contComboSelListGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.cboComboBoxSelList)
        Me.DoubleBuffered = True
        Me.Name = "contComboSelListGrid"
        Me.Size = New System.Drawing.Size(231, 24)
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboComboBoxSelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents DsAuswahllisten1 As dsAuswahllisten
    Public WithEvents cboComboBoxSelList As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AuswahlLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents ImageListSmall As System.Windows.Forms.ImageList

End Class
