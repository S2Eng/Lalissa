<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contAddIns
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("AddIns", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activated")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AddInName", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dll")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Type")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Group")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Place")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ActivatedAt")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ActivatedFrom")
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
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(86483507)
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnRunAddIN = New Infragistics.Win.Misc.UltraButton()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelCenterTop = New System.Windows.Forms.Panel()
        Me.gridAddIns1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAddIn1 = New qs2.core.vb.dsAddIn()
        Me.PanelCeterBottom = New System.Windows.Forms.Panel()
        Me.gridBagLayoutPanelListAddIns = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.CompAddIns1 = New qs2.core.vb.sqlAddIns(Me.components)
        Me.PanelBottom.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelCenterTop.SuspendLayout()
        CType(Me.gridAddIns1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAddIn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBagLayoutPanelListAddIns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Controls.Add(Me.btnRunAddIN)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 251)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(787, 36)
        Me.PanelBottom.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(580, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 26)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.Visible = False
        '
        'btnRunAddIN
        '
        Me.btnRunAddIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRunAddIN.Location = New System.Drawing.Point(687, 4)
        Me.btnRunAddIN.Name = "btnRunAddIN"
        Me.btnRunAddIN.Size = New System.Drawing.Size(87, 26)
        Me.btnRunAddIN.TabIndex = 0
        Me.btnRunAddIN.Text = "Run AddIn"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(787, 20)
        Me.PanelTop.TabIndex = 4
        Me.PanelTop.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PanelCenterTop)
        Me.Panel1.Controls.Add(Me.PanelCeterBottom)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 231)
        Me.Panel1.TabIndex = 6
        '
        'PanelCenterTop
        '
        Me.PanelCenterTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenterTop.Controls.Add(Me.gridAddIns1)
        Me.PanelCenterTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenterTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelCenterTop.Name = "PanelCenterTop"
        Me.PanelCenterTop.Size = New System.Drawing.Size(787, 156)
        Me.PanelCenterTop.TabIndex = 2
        '
        'gridAddIns1
        '
        Me.gridAddIns1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAddIns1.DataMember = "AddIns"
        Me.gridAddIns1.DataSource = Me.DsAddIn1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.gridAddIns1.DisplayLayout.Appearance = Appearance1
        Me.gridAddIns1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn1.Header.Appearance = Appearance3
        UltraGridColumn1.Header.VisiblePosition = 7
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 79
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Width = 65
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Width = 306
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor
        UltraGridColumn6.Width = 237
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn7.Width = 130
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.VisiblePosition = 5
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Me.gridAddIns1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridAddIns1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.Color.White
        Me.gridAddIns1.DisplayLayout.CaptionAppearance = Appearance4
        Me.gridAddIns1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridAddIns1.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridAddIns1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.gridAddIns1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.Control
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridAddIns1.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.gridAddIns1.DisplayLayout.MaxColScrollRegions = 1
        Me.gridAddIns1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Appearance8.TextHAlignAsString = "Left"
        Me.gridAddIns1.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.BorderColor = System.Drawing.Color.White
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridAddIns1.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.gridAddIns1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridAddIns1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridAddIns1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.gridAddIns1.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.White
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridAddIns1.DisplayLayout.Override.CellAppearance = Appearance11
        Me.gridAddIns1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridAddIns1.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.gridAddIns1.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.gridAddIns1.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.gridAddIns1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridAddIns1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.gridAddIns1.DisplayLayout.Override.RowAppearance = Appearance14
        Me.gridAddIns1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Me.gridAddIns1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridAddIns1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridAddIns1.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance15.BackColor = System.Drawing.Color.White
        Me.gridAddIns1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Me.gridAddIns1.DisplayLayout.Override.TemplateAddRowCellAppearance = Appearance16
        Me.gridAddIns1.DisplayLayout.Override.TemplateAddRowPrompt = "Click here to add a record ..."
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.BackColor2 = System.Drawing.Color.White
        Me.gridAddIns1.DisplayLayout.Override.TemplateAddRowPromptAppearance = Appearance17
        Me.gridAddIns1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridAddIns1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Type"
        Me.gridAddIns1.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1})
        Me.gridAddIns1.Font = New System.Drawing.Font("Segoe UI", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridAddIns1.Location = New System.Drawing.Point(4, 4)
        Me.gridAddIns1.Name = "gridAddIns1"
        Me.gridAddIns1.Size = New System.Drawing.Size(779, 147)
        Me.gridAddIns1.TabIndex = 4
        Me.gridAddIns1.Text = "List Entrys"
        '
        'DsAddIn1
        '
        Me.DsAddIn1.DataSetName = "dsAddIn"
        Me.DsAddIn1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelCeterBottom
        '
        Me.PanelCeterBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelCeterBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCeterBottom.Location = New System.Drawing.Point(0, 156)
        Me.PanelCeterBottom.Name = "PanelCeterBottom"
        Me.PanelCeterBottom.Size = New System.Drawing.Size(787, 75)
        Me.PanelCeterBottom.TabIndex = 1
        Me.PanelCeterBottom.Visible = False
        '
        'gridBagLayoutPanelListAddIns
        '
        Me.gridBagLayoutPanelListAddIns.BackColor = System.Drawing.Color.Transparent
        Me.gridBagLayoutPanelListAddIns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBagLayoutPanelListAddIns.ExpandToFitHeight = True
        Me.gridBagLayoutPanelListAddIns.ExpandToFitWidth = True
        Me.gridBagLayoutPanelListAddIns.Location = New System.Drawing.Point(0, 20)
        Me.gridBagLayoutPanelListAddIns.Name = "gridBagLayoutPanelListAddIns"
        Me.gridBagLayoutPanelListAddIns.Size = New System.Drawing.Size(787, 231)
        Me.gridBagLayoutPanelListAddIns.TabIndex = 5
        '
        'contAddIns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gridBagLayoutPanelListAddIns)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.Name = "contAddIns"
        Me.Size = New System.Drawing.Size(787, 287)
        Me.PanelBottom.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelCenterTop.ResumeLayout(False)
        CType(Me.gridAddIns1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAddIn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBagLayoutPanelListAddIns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents btnRunAddIN As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridBagLayoutPanelListAddIns As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents DsAddIn1 As qs2.core.vb.dsAddIn
    Friend WithEvents CompAddIns1 As qs2.core.vb.sqlAddIns
    Friend WithEvents PanelCenterTop As System.Windows.Forms.Panel
    Friend WithEvents PanelCeterBottom As System.Windows.Forms.Panel
    Friend WithEvents gridAddIns1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton

End Class
