<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class contListTextTemplates
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblTextTemplates", -1)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Txt")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Type")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("An")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CC")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BCC")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FromPostfach")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstIDPatienten")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstIDBenutzer")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstCategories")
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
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eintrag hinzufügen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Me.gridTextTemplates = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CMenuStripTextTemplatesFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DateiÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace01 = New System.Windows.Forms.ToolStripSeparator()
        Me.NeuLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsAutoDocu1 = New PMDS.GUI.VB.dsAutoDocu()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.chkTextIsHtml = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.CompAutoDocu1 = New PMDS.GUI.VB.compAutoDocu(Me.components)
        CType(Me.gridTextTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripTextTemplatesFiles.SuspendLayout()
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridTextTemplates
        '
        Me.gridTextTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridTextTemplates.ContextMenuStrip = Me.CMenuStripTextTemplatesFiles
        Me.gridTextTemplates.DataMember = "tblTextTemplates"
        Me.gridTextTemplates.DataSource = Me.DsAutoDocu1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridTextTemplates.DisplayLayout.Appearance = Appearance1
        Me.gridTextTemplates.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn14.Header.VisiblePosition = 0
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 77
        UltraGridColumn15.Header.VisiblePosition = 1
        UltraGridColumn15.Width = 598
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 37
        UltraGridColumn17.Header.VisiblePosition = 2
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 97
        UltraGridColumn18.Header.VisiblePosition = 3
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 74
        UltraGridColumn19.Header.VisiblePosition = 4
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 98
        UltraGridColumn20.Header.VisiblePosition = 6
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 71
        UltraGridColumn21.Header.VisiblePosition = 7
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 55
        UltraGridColumn22.Header.VisiblePosition = 8
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 47
        UltraGridColumn23.Header.VisiblePosition = 9
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 39
        UltraGridColumn24.Header.VisiblePosition = 10
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.HiddenWhenGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn24.Width = 158
        UltraGridColumn25.Header.VisiblePosition = 11
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 36
        UltraGridColumn26.Header.VisiblePosition = 12
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 33
        UltraGridColumn1.Header.VisiblePosition = 13
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 85
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn1})
        Me.gridTextTemplates.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridTextTemplates.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTextTemplates.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplates.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridTextTemplates.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplates.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridTextTemplates.DisplayLayout.MaxColScrollRegions = 1
        Me.gridTextTemplates.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridTextTemplates.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridTextTemplates.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridTextTemplates.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridTextTemplates.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridTextTemplates.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridTextTemplates.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridTextTemplates.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplates.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridTextTemplates.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridTextTemplates.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridTextTemplates.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridTextTemplates.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridTextTemplates.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridTextTemplates.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridTextTemplates.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridTextTemplates.Location = New System.Drawing.Point(5, 4)
        Me.gridTextTemplates.Name = "gridTextTemplates"
        Me.gridTextTemplates.Size = New System.Drawing.Size(619, 335)
        Me.gridTextTemplates.TabIndex = 0
        Me.gridTextTemplates.Text = "Objekte zu Planungseintrag"
        '
        'CMenuStripTextTemplatesFiles
        '
        Me.CMenuStripTextTemplatesFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiÖffnenToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.ToolStripMenuItemSpace01, Me.NeuLadenToolStripMenuItem})
        Me.CMenuStripTextTemplatesFiles.Name = "CMenuStripAnhang"
        Me.CMenuStripTextTemplatesFiles.Size = New System.Drawing.Size(170, 76)
        '
        'DateiÖffnenToolStripMenuItem
        '
        Me.DateiÖffnenToolStripMenuItem.Name = "DateiÖffnenToolStripMenuItem"
        Me.DateiÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DateiÖffnenToolStripMenuItem.Tag = "ResID.OpenFile"
        Me.DateiÖffnenToolStripMenuItem.Text = "Datei öffnen"
        Me.DateiÖffnenToolStripMenuItem.Visible = False
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernUnterToolStripMenuItem.Tag = "ResID.SaveFileAs"
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
        Me.SpeichernUnterToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItemSpace01
        '
        Me.ToolStripMenuItemSpace01.Name = "ToolStripMenuItemSpace01"
        Me.ToolStripMenuItemSpace01.Size = New System.Drawing.Size(166, 6)
        Me.ToolStripMenuItemSpace01.Visible = False
        '
        'NeuLadenToolStripMenuItem
        '
        Me.NeuLadenToolStripMenuItem.Name = "NeuLadenToolStripMenuItem"
        Me.NeuLadenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NeuLadenToolStripMenuItem.Tag = "ResID.Refresh"
        Me.NeuLadenToolStripMenuItem.Text = "Neu Laden"
        '
        'DsAutoDocu1
        '
        Me.DsAutoDocu1.DataSetName = "dsAutoDocu"
        Me.DsAutoDocu1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelBottom
        '
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 373)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(631, 28)
        Me.PanelBottom.TabIndex = 2
        Me.PanelBottom.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnEdit.Appearance = Appearance13
        Me.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEdit.Location = New System.Drawing.Point(596, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(25, 24)
        Me.btnEdit.TabIndex = 122
        UltraToolTipInfo2.ToolTipText = "Eintrag hinzufügen"
        UltraToolTipInfo2.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnEdit, UltraToolTipInfo2)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'chkTextIsHtml
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkTextIsHtml.Appearance = Appearance14
        Me.chkTextIsHtml.BackColor = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTextIsHtml.Location = New System.Drawing.Point(12, 8)
        Me.chkTextIsHtml.Name = "chkTextIsHtml"
        Me.chkTextIsHtml.Size = New System.Drawing.Size(141, 15)
        Me.chkTextIsHtml.TabIndex = 123
        Me.chkTextIsHtml.Tag = "ResID.WithSignature"
        Me.chkTextIsHtml.Text = "Mit Signatur"
        UltraToolTipInfo1.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo1.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkTextIsHtml, UltraToolTipInfo1)
        Me.chkTextIsHtml.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkTextIsHtml.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.chkTextIsHtml.Visible = False
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.chkTextIsHtml)
        Me.PanelTop.Controls.Add(Me.btnEdit)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(631, 29)
        Me.PanelTop.TabIndex = 5
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.gridTextTemplates)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 29)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(631, 344)
        Me.PanelGrid.TabIndex = 6
        '
        'contListTextTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.DoubleBuffered = True
        Me.Name = "contListTextTemplates"
        Me.Size = New System.Drawing.Size(631, 401)
        CType(Me.gridTextTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripTextTemplatesFiles.ResumeLayout(False)
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents gridTextTemplates As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsAutoDocu1 As dsAutoDocu
    Friend WithEvents CompAutoDocu1 As compAutoDocu
    Friend WithEvents CMenuStripTextTemplatesFiles As Windows.Forms.ContextMenuStrip
    Friend WithEvents DateiÖffnenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace01 As Windows.Forms.ToolStripSeparator
    Friend WithEvents NeuLadenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelGrid As Windows.Forms.Panel
    Friend WithEvents PanelTop As Windows.Forms.Panel
    Friend WithEvents chkTextIsHtml As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
