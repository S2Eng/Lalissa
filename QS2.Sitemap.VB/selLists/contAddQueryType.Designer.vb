<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contAddQueryType
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
        Dim valueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("SimpleTables", -1)
        Dim ultraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TranslationTableName")
        Dim ultraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TableName")
        Dim ultraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
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
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.optQueryType = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.lblTypeOfQuery = New Infragistics.Win.Misc.UltraLabel()
        Me.panelTables = New System.Windows.Forms.Panel()
        Me.gridSimpleTables = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsSimpleQuerySelection1 = New qs2.core.print.dsSimpleQuerySelection()
        Me.lblTypeOfContent = New Infragistics.Win.Misc.UltraLabel()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.panelCenter = New System.Windows.Forms.Panel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.panelTop.SuspendLayout()
        CType(Me.optQueryType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelTables.SuspendLayout()
        CType(Me.gridSimpleTables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSimpleQuerySelection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelCenter.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.Transparent
        Me.panelTop.Controls.Add(Me.optQueryType)
        Me.panelTop.Controls.Add(Me.lblTypeOfQuery)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(407, 42)
        Me.panelTop.TabIndex = 1
        '
        'optQueryType
        '
        Me.optQueryType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optQueryType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        valueListItem2.DataValue = "QueryType1"
        Me.optQueryType.Items.AddRange(New Infragistics.Win.ValueListItem() {valueListItem2})
        Me.optQueryType.Location = New System.Drawing.Point(25, 23)
        Me.optQueryType.Name = "optQueryType"
        Me.optQueryType.Size = New System.Drawing.Size(378, 14)
        Me.optQueryType.TabIndex = 39
        '
        'lblTypeOfQuery
        '
        Me.lblTypeOfQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTypeOfQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTypeOfQuery.Location = New System.Drawing.Point(4, 2)
        Me.lblTypeOfQuery.Name = "lblTypeOfQuery"
        Me.lblTypeOfQuery.Size = New System.Drawing.Size(399, 14)
        Me.lblTypeOfQuery.TabIndex = 40
        Me.lblTypeOfQuery.Text = "Please select the type of your query"
        '
        'panelTables
        '
        Me.panelTables.BackColor = System.Drawing.Color.Transparent
        Me.panelTables.Controls.Add(Me.gridSimpleTables)
        Me.panelTables.Controls.Add(Me.lblTypeOfContent)
        Me.panelTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelTables.Location = New System.Drawing.Point(0, 0)
        Me.panelTables.Name = "panelTables"
        Me.panelTables.Size = New System.Drawing.Size(407, 212)
        Me.panelTables.TabIndex = 0
        '
        'gridSimpleTables
        '
        Me.gridSimpleTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridSimpleTables.DataMember = "SimpleTables"
        Me.gridSimpleTables.DataSource = Me.DsSimpleQuerySelection1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSimpleTables.DisplayLayout.Appearance = Appearance1
        Me.gridSimpleTables.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        ultraGridColumn12.Header.VisiblePosition = 1
        ultraGridColumn12.Width = 376
        ultraGridColumn2.Header.VisiblePosition = 3
        ultraGridColumn2.Hidden = True
        ultraGridColumn2.Width = 151
        ultraGridColumn3.Header.VisiblePosition = 0
        ultraGridColumn3.Hidden = True
        ultraGridColumn3.Width = 127
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 174
        UltraGridBand1.Columns.AddRange(New Object() {ultraGridColumn12, ultraGridColumn2, ultraGridColumn3, UltraGridColumn1})
        Me.gridSimpleTables.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSimpleTables.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSimpleTables.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSimpleTables.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSimpleTables.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridSimpleTables.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSimpleTables.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridSimpleTables.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSimpleTables.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridSimpleTables.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridSimpleTables.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridSimpleTables.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSimpleTables.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridSimpleTables.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSimpleTables.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridSimpleTables.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSimpleTables.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSimpleTables.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSimpleTables.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridSimpleTables.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridSimpleTables.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSimpleTables.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridSimpleTables.DisplayLayout.Override.RowAppearance = Appearance11
        Me.gridSimpleTables.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSimpleTables.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridSimpleTables.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSimpleTables.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridSimpleTables.Location = New System.Drawing.Point(23, 3)
        Me.gridSimpleTables.Name = "gridSimpleTables"
        Me.gridSimpleTables.Size = New System.Drawing.Size(378, 207)
        Me.gridSimpleTables.TabIndex = 0
        Me.gridSimpleTables.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
        '
        'DsSimpleQuerySelection1
        '
        Me.DsSimpleQuerySelection1.DataSetName = "dsSimpleQuerySelection"
        Me.DsSimpleQuerySelection1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblTypeOfContent
        '
        Me.lblTypeOfContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTypeOfContent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTypeOfContent.Location = New System.Drawing.Point(4, 5)
        Me.lblTypeOfContent.Name = "lblTypeOfContent"
        Me.lblTypeOfContent.Size = New System.Drawing.Size(398, 14)
        Me.lblTypeOfContent.TabIndex = 41
        Me.lblTypeOfContent.Text = "Please select the type of content"
        Me.lblTypeOfContent.Visible = False
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.Transparent
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 254)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(407, 16)
        Me.panelBottom.TabIndex = 46
        Me.panelBottom.Visible = False
        '
        'panelCenter
        '
        Me.panelCenter.BackColor = System.Drawing.Color.Transparent
        Me.panelCenter.Controls.Add(Me.panelTables)
        Me.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCenter.Location = New System.Drawing.Point(0, 42)
        Me.panelCenter.Name = "panelCenter"
        Me.panelCenter.Size = New System.Drawing.Size(407, 212)
        Me.panelCenter.TabIndex = 47
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'contAddQueryType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.panelCenter)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelTop)
        Me.Name = "contAddQueryType"
        Me.Size = New System.Drawing.Size(407, 270)
        Me.panelTop.ResumeLayout(False)
        CType(Me.optQueryType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelTables.ResumeLayout(False)
        CType(Me.gridSimpleTables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSimpleQuerySelection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelCenter.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelTop As System.Windows.Forms.Panel
    Private WithEvents lblTypeOfQuery As Infragistics.Win.Misc.UltraLabel
    Private WithEvents optQueryType As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Private WithEvents panelTables As System.Windows.Forms.Panel
    Private WithEvents lblTypeOfContent As Infragistics.Win.Misc.UltraLabel
    Private WithEvents gridSimpleTables As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsSimpleQuerySelection1 As qs2.core.print.dsSimpleQuerySelection
    Private WithEvents panelBottom As System.Windows.Forms.Panel
    Friend WithEvents panelCenter As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class
