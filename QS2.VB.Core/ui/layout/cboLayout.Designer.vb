<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cboLayout
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Layout", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LayoutName")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AllUsers")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateFrom")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreateAt")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Key")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GridRowMinHeigth")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GridRowMaxHeigth")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AutoFitStyleGrid")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GridAutoNewline")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ShowAlwaysGroupBy")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CaptionVisible")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AutoSizeWidthColumns")
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cboLay = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DsLayout1 = New qs2.core.vb.dsLayout()
        Me.lblLayoutName = New Infragistics.Win.Misc.UltraLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CompLayout1 = New qs2.core.vb.compLayout(Me.components)
        Me.btnDeleteSelection = New Infragistics.Win.Misc.UltraButton()
        Me.PanelDeleteSelectionLayoutManager = New System.Windows.Forms.Panel()
        Me.btnOpenLayoutManager = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.cboLay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsLayout1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDeleteSelectionLayoutManager.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboLay
        '
        Me.cboLay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLay.DataMember = "Layout"
        Me.cboLay.DataSource = Me.DsLayout1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboLay.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Caption = "Layout-Name"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 180
        UltraGridColumn3.Header.Caption = "All users"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn4.Header.Caption = "Create from"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn5.Header.Caption = "Create at"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn5.Width = 120
        UltraGridColumn18.Header.VisiblePosition = 2
        UltraGridColumn18.Width = 130
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn18, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
        Me.cboLay.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.cboLay.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboLay.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cboLay.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboLay.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cboLay.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboLay.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cboLay.DisplayLayout.MaxColScrollRegions = 1
        Me.cboLay.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboLay.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboLay.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cboLay.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboLay.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cboLay.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboLay.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cboLay.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboLay.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cboLay.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cboLay.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cboLay.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboLay.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cboLay.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cboLay.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboLay.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cboLay.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboLay.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboLay.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboLay.DisplayMember = "LayoutName"
        Me.cboLay.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboLay.Location = New System.Drawing.Point(92, 3)
        Me.cboLay.Name = "cboLay"
        Me.cboLay.Size = New System.Drawing.Size(243, 22)
        Me.cboLay.TabIndex = 0
        Me.cboLay.ValueMember = "IDGuid"
        '
        'DsLayout1
        '
        Me.DsLayout1.DataSetName = "dsLayout"
        Me.DsLayout1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblLayoutName
        '
        Me.lblLayoutName.Location = New System.Drawing.Point(2, 7)
        Me.lblLayoutName.Name = "lblLayoutName"
        Me.lblLayoutName.Size = New System.Drawing.Size(146, 14)
        Me.lblLayoutName.TabIndex = 14
        Me.lblLayoutName.Text = "Name Layout"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnDeleteSelection
        '
        Me.btnDeleteSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDeleteSelection.Appearance = Appearance14
        Me.btnDeleteSelection.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnDeleteSelection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDeleteSelection.Location = New System.Drawing.Point(1, 4)
        Me.btnDeleteSelection.Name = "btnDeleteSelection"
        Me.btnDeleteSelection.Size = New System.Drawing.Size(22, 21)
        Me.btnDeleteSelection.TabIndex = 0
        '
        'PanelDeleteSelectionLayoutManager
        '
        Me.PanelDeleteSelectionLayoutManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDeleteSelectionLayoutManager.BackColor = System.Drawing.Color.Transparent
        Me.PanelDeleteSelectionLayoutManager.Controls.Add(Me.btnOpenLayoutManager)
        Me.PanelDeleteSelectionLayoutManager.Controls.Add(Me.btnDeleteSelection)
        Me.PanelDeleteSelectionLayoutManager.Location = New System.Drawing.Point(337, 0)
        Me.PanelDeleteSelectionLayoutManager.Name = "PanelDeleteSelectionLayoutManager"
        Me.PanelDeleteSelectionLayoutManager.Size = New System.Drawing.Size(48, 28)
        Me.PanelDeleteSelectionLayoutManager.TabIndex = 1
        '
        'btnOpenLayoutManager
        '
        Me.btnOpenLayoutManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnOpenLayoutManager.Appearance = Appearance13
        Me.btnOpenLayoutManager.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnOpenLayoutManager.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOpenLayoutManager.Location = New System.Drawing.Point(23, 4)
        Me.btnOpenLayoutManager.Name = "btnOpenLayoutManager"
        Me.btnOpenLayoutManager.Size = New System.Drawing.Size(22, 21)
        Me.btnOpenLayoutManager.TabIndex = 1
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'cboLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PanelDeleteSelectionLayoutManager)
        Me.Controls.Add(Me.cboLay)
        Me.Controls.Add(Me.lblLayoutName)
        Me.Name = "cboLayout"
        Me.Size = New System.Drawing.Size(388, 31)
        CType(Me.cboLay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsLayout1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDeleteSelectionLayoutManager.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsLayout1 As qs2.core.vb.dsLayout
    Private WithEvents lblLayoutName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CompLayout1 As qs2.core.vb.compLayout
    Public WithEvents cboLay As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnDeleteSelection As Infragistics.Win.Misc.UltraButton
    Public WithEvents PanelDeleteSelectionLayoutManager As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents btnOpenLayoutManager As Infragistics.Win.Misc.UltraButton

End Class
