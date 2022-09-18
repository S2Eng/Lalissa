<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contCboGroup
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListGroup", -1)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroupStr")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sys")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sublist")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeEnum")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SortColumn")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListGroup_tblSelListEntries")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListGroup_tblSelListEntries", 0)
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sort")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeStr")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Table")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortColumn")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("picture")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Private")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sql")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries1_tblSelListEntriesObj")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries_tblStayAdditions1")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries1_tblSelListEntriesObj", 1)
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntrySublist")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntry")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStay")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStay")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typIDGroup")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("From")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("To")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDClassification")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedBy")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Modified")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ModifiedBy")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active")
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries_tblStayAdditions1", 1)
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStay")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnIntMain")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStaySelected")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
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
        Me.cboGroup = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.SqlAdmin1 = New qs2.core.vb.sqlAdmin(Me.components)
        CType(Me.cboGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboGroup
        '
        Me.cboGroup.AutoSize = False
        Me.cboGroup.DataMember = "tblSelListGroup"
        Me.cboGroup.DataSource = Me.DsAdmin1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboGroup.DisplayLayout.Appearance = Appearance1
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn44.Header.VisiblePosition = 4
        UltraGridColumn44.Hidden = True
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Hidden = True
        UltraGridColumn45.Header.VisiblePosition = 2
        UltraGridColumn45.Width = 130
        UltraGridColumn46.Header.Caption = "Application"
        UltraGridColumn46.Header.VisiblePosition = 5
        UltraGridColumn46.Width = 140
        UltraGridColumn47.Header.Caption = "Participant"
        UltraGridColumn47.Header.VisiblePosition = 6
        UltraGridColumn47.Width = 130
        UltraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn48.Header.VisiblePosition = 7
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Width = 230
        UltraGridColumn49.Header.Caption = "Sys"
        UltraGridColumn49.Header.VisiblePosition = 8
        UltraGridColumn50.Header.VisiblePosition = 9
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.Header.VisiblePosition = 10
        UltraGridColumn51.Hidden = True
        UltraGridColumn52.Header.VisiblePosition = 11
        UltraGridColumn52.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 12
        UltraGridColumn2.Hidden = True
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn53.Header.VisiblePosition = 3
        UltraGridColumn53.Hidden = True
        UltraGridColumn53.Width = 230
        UltraGridColumn54.Header.VisiblePosition = 13
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn55.Header.VisiblePosition = 0
        UltraGridColumn55.Width = 270
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn44, UltraGridColumn1, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn2, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55})
        UltraGridColumn57.Header.VisiblePosition = 0
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn58.Header.VisiblePosition = 2
        UltraGridColumn60.Header.VisiblePosition = 3
        UltraGridColumn61.Header.VisiblePosition = 4
        UltraGridColumn62.Header.VisiblePosition = 5
        UltraGridColumn4.Header.VisiblePosition = 7
        UltraGridColumn63.Header.VisiblePosition = 6
        UltraGridColumn64.Header.VisiblePosition = 8
        UltraGridColumn65.Header.VisiblePosition = 9
        UltraGridColumn66.Header.VisiblePosition = 10
        UltraGridColumn67.Header.VisiblePosition = 11
        UltraGridColumn68.Header.VisiblePosition = 12
        UltraGridColumn69.Header.VisiblePosition = 13
        UltraGridColumn5.Header.VisiblePosition = 16
        UltraGridColumn70.Header.VisiblePosition = 14
        UltraGridColumn71.Header.VisiblePosition = 15
        UltraGridColumn72.Header.VisiblePosition = 17
        UltraGridColumn73.Header.VisiblePosition = 18
        UltraGridColumn74.Header.VisiblePosition = 19
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn57, UltraGridColumn3, UltraGridColumn58, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn4, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn5, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74})
        UltraGridColumn75.Header.VisiblePosition = 0
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn76.Header.VisiblePosition = 2
        UltraGridColumn77.Header.VisiblePosition = 3
        UltraGridColumn78.Header.VisiblePosition = 4
        UltraGridColumn79.Header.VisiblePosition = 5
        UltraGridColumn80.Header.VisiblePosition = 6
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn81.Header.VisiblePosition = 8
        UltraGridColumn82.Header.VisiblePosition = 10
        UltraGridColumn83.Header.VisiblePosition = 11
        UltraGridColumn92.Header.VisiblePosition = 12
        UltraGridColumn93.Header.VisiblePosition = 13
        UltraGridColumn10.Header.VisiblePosition = 16
        UltraGridColumn11.Header.VisiblePosition = 18
        UltraGridColumn12.Header.VisiblePosition = 19
        UltraGridColumn13.Header.VisiblePosition = 20
        UltraGridColumn94.Header.VisiblePosition = 14
        UltraGridColumn95.Header.VisiblePosition = 17
        UltraGridColumn14.Header.VisiblePosition = 21
        UltraGridColumn7.Header.VisiblePosition = 15
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn75, UltraGridColumn6, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn8, UltraGridColumn9, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn92, UltraGridColumn93, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn94, UltraGridColumn95, UltraGridColumn14, UltraGridColumn7})
        UltraGridColumn96.Header.VisiblePosition = 0
        UltraGridColumn97.Header.VisiblePosition = 1
        UltraGridColumn98.Header.VisiblePosition = 2
        UltraGridColumn99.Header.VisiblePosition = 3
        UltraGridColumn100.Header.VisiblePosition = 4
        UltraGridColumn101.Header.VisiblePosition = 5
        UltraGridColumn102.Header.VisiblePosition = 6
        UltraGridColumn103.Header.VisiblePosition = 7
        UltraGridColumn104.Header.VisiblePosition = 8
        UltraGridColumn105.Header.VisiblePosition = 9
        UltraGridColumn106.Header.VisiblePosition = 10
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106})
        Me.cboGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.cboGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.cboGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.cboGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.cboGroup.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboGroup.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cboGroup.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboGroup.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cboGroup.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboGroup.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cboGroup.DisplayLayout.MaxColScrollRegions = 1
        Me.cboGroup.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboGroup.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboGroup.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cboGroup.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboGroup.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cboGroup.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboGroup.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cboGroup.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboGroup.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cboGroup.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cboGroup.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cboGroup.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboGroup.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cboGroup.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cboGroup.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboGroup.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cboGroup.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboGroup.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboGroup.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboGroup.DisplayMember = "Text"
        Me.cboGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboGroup.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboGroup.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboGroup.Location = New System.Drawing.Point(0, 0)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(231, 40)
        Me.cboGroup.TabIndex = 11
        Me.cboGroup.ValueMember = "ID"
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAdmin"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contCboGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.cboGroup)
        Me.Name = "contCboGroup"
        Me.Size = New System.Drawing.Size(231, 40)
        CType(Me.cboGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents cboGroup As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents SqlAdmin1 As qs2.core.vb.sqlAdmin
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin

End Class
