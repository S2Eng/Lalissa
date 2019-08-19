<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contTextTemplateFiles
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblTextTemplatesFiles", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTextTemplate")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Docu")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FileType")
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eintrag hinzufügen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Eintrag löschen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gridTextTemplatesFiles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CMenuStripTextTemplatesFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DateiÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsAutoDocu1 = New PMDS.GUI.VB.dsAutoDocu()
        Me.CompAutoDocu1 = New PMDS.GUI.VB.compAutoDocu(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblFiles = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.gridTextTemplatesFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripTextTemplatesFiles.SuspendLayout()
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridTextTemplatesFiles
        '
        Me.gridTextTemplatesFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridTextTemplatesFiles.ContextMenuStrip = Me.CMenuStripTextTemplatesFiles
        Me.gridTextTemplatesFiles.DataMember = "tblTextTemplatesFiles"
        Me.gridTextTemplatesFiles.DataSource = Me.DsAutoDocu1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridTextTemplatesFiles.DisplayLayout.Appearance = Appearance1
        Me.gridTextTemplatesFiles.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeadersVisible = False
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 194
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 235
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Width = 165
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 70
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn6, UltraGridColumn7, UltraGridColumn2, UltraGridColumn3})
        Me.gridTextTemplatesFiles.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridTextTemplatesFiles.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTextTemplatesFiles.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplatesFiles.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplatesFiles.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridTextTemplatesFiles.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTextTemplatesFiles.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridTextTemplatesFiles.DisplayLayout.MaxColScrollRegions = 1
        Me.gridTextTemplatesFiles.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridTextTemplatesFiles.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridTextTemplatesFiles.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridTextTemplatesFiles.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridTextTemplatesFiles.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplatesFiles.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridTextTemplatesFiles.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridTextTemplatesFiles.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridTextTemplatesFiles.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTextTemplatesFiles.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridTextTemplatesFiles.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridTextTemplatesFiles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridTextTemplatesFiles.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridTextTemplatesFiles.DisplayLayout.Override.RowAppearance = Appearance11
        Me.gridTextTemplatesFiles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridTextTemplatesFiles.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridTextTemplatesFiles.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridTextTemplatesFiles.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridTextTemplatesFiles.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridTextTemplatesFiles.Location = New System.Drawing.Point(3, 29)
        Me.gridTextTemplatesFiles.Name = "gridTextTemplatesFiles"
        Me.gridTextTemplatesFiles.Size = New System.Drawing.Size(237, 121)
        Me.gridTextTemplatesFiles.TabIndex = 2
        Me.gridTextTemplatesFiles.Text = "UltraGrid1"
        '
        'CMenuStripTextTemplatesFiles
        '
        Me.CMenuStripTextTemplatesFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiÖffnenToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem})
        Me.CMenuStripTextTemplatesFiles.Name = "CMenuStripAnhang"
        Me.CMenuStripTextTemplatesFiles.Size = New System.Drawing.Size(170, 48)
        '
        'DateiÖffnenToolStripMenuItem
        '
        Me.DateiÖffnenToolStripMenuItem.Name = "DateiÖffnenToolStripMenuItem"
        Me.DateiÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DateiÖffnenToolStripMenuItem.Tag = "ResID.OpenFile"
        Me.DateiÖffnenToolStripMenuItem.Text = "Datei öffnen"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernUnterToolStripMenuItem.Tag = "ResID.SaveFileAs"
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
        '
        'DsAutoDocu1
        '
        Me.DsAutoDocu1.DataSetName = "dsAutoDocu"
        Me.DsAutoDocu1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAdd.Appearance = Appearance14
        Me.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdd.Location = New System.Drawing.Point(185, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(26, 25)
        Me.btnAdd.TabIndex = 123
        UltraToolTipInfo1.ToolTipText = "Eintrag hinzufügen"
        UltraToolTipInfo1.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd, UltraToolTipInfo1)
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDel.Appearance = Appearance15
        Me.btnDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDel.Location = New System.Drawing.Point(211, 2)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(26, 25)
        Me.btnDel.TabIndex = 122
        UltraToolTipInfo2.ToolTipText = "Ausgewählten Eintrag löschen"
        UltraToolTipInfo2.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDel, UltraToolTipInfo2)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblFiles
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Appearance13.TextVAlignAsString = "Middle"
        Me.lblFiles.Appearance = Appearance13
        Me.lblFiles.Location = New System.Drawing.Point(5, 6)
        Me.lblFiles.Name = "lblFiles"
        Me.lblFiles.Size = New System.Drawing.Size(139, 17)
        Me.lblFiles.TabIndex = 383
        Me.lblFiles.Tag = "ResID.Files"
        Me.lblFiles.Text = "Dateien"
        '
        'contTextTemplateFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblFiles)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.gridTextTemplatesFiles)
        Me.Name = "contTextTemplateFiles"
        Me.Size = New System.Drawing.Size(242, 152)
        CType(Me.gridTextTemplatesFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripTextTemplatesFiles.ResumeLayout(False)
        CType(Me.DsAutoDocu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridTextTemplatesFiles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsAutoDocu1 As dsAutoDocu
    Friend WithEvents CompAutoDocu1 As compAutoDocu
    Friend WithEvents CMenuStripTextTemplatesFiles As Windows.Forms.ContextMenuStrip
    Friend WithEvents DateiÖffnenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Public WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Friend WithEvents lblFiles As Infragistics.Win.Misc.UltraLabel
End Class
