<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelListsChapter
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlType")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SQLValueListSelect")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AliasFldShort")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SourceTable")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlPattern")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MaskInput")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMinVal")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMaxVal")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMinLength")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMaxLength")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Used")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Validate")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Editable")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserDefined")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UseInQueries")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ShowAt")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("prefered")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DefaultValues")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DefaultValuesCustomer")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UsedCustomer")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblSelListEntriesObj")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblRelationship1")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblCriteriaOpt")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblQueriesDef")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selection", 1)
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("iSelection", 2)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblSelListEntriesObj", 0)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntrySublist")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntry")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStay")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStay")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStay")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typIDGroup")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("From")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("To")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDClassification")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedBy")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Modified")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ModifiedBy")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObjectGuid")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Transfered")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nVisible")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblRelationship1", 0)
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortParent")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationParent")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortChild")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationChild")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conditions")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Type")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeSub")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKey")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConditionsSub")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblCriteriaOpt", 0)
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Parameter")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Value")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Referenze")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblQueriesDef", 0)
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserInput")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FunctionPar")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Combination")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("QryTable")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("QryColumn")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CriteriaFldShort")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CriteriaApplication")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsSQLServerField")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Label")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlType")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Typ")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Condition")
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValueMin")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Max")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValueMinIDRes")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MaxIDRes")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CombinationEnd")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("freeSql")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ApplicationOwn")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ParticipantOwn")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("All")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SpecialDefinition")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ComboAsDropDown")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ComboAsDropDownCondition")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SpecialDefinitionMax")
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuildSqlCheckedTrueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildSqlCheckedFalseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelOben = New System.Windows.Forms.Panel()
        Me.ComboApplication1 = New qs2.sitemap.comboApplication()
        Me.optChapterStayFollowUp = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.ContCboSelListChapters = New qs2.sitemap.vb.contCboSelList()
        Me.lblChapters = New Infragistics.Win.Misc.UltraLabel()
        Me.txtSearchText = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridCriterias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PanelOben.SuspendLayout()
        CType(Me.optChapterStayFollowUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearchText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelGrid.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.gridCriterias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripMenuItemSpace10, Me.BuildSqlCheckedTrueToolStripMenuItem, Me.BuildSqlCheckedFalseToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 98)
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AllToolStripMenuItem.Text = "Select all"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Select none"
        '
        'ToolStripMenuItemSpace10
        '
        Me.ToolStripMenuItemSpace10.Name = "ToolStripMenuItemSpace10"
        Me.ToolStripMenuItemSpace10.Size = New System.Drawing.Size(200, 6)
        '
        'BuildSqlCheckedTrueToolStripMenuItem
        '
        Me.BuildSqlCheckedTrueToolStripMenuItem.Name = "BuildSqlCheckedTrueToolStripMenuItem"
        Me.BuildSqlCheckedTrueToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.BuildSqlCheckedTrueToolStripMenuItem.Text = "Build Sql Checked=True"
        '
        'BuildSqlCheckedFalseToolStripMenuItem
        '
        Me.BuildSqlCheckedFalseToolStripMenuItem.Name = "BuildSqlCheckedFalseToolStripMenuItem"
        Me.BuildSqlCheckedFalseToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.BuildSqlCheckedFalseToolStripMenuItem.Text = "Build Sql Checked=False"
        '
        'PanelOben
        '
        Me.PanelOben.Controls.Add(Me.ComboApplication1)
        Me.PanelOben.Controls.Add(Me.optChapterStayFollowUp)
        Me.PanelOben.Controls.Add(Me.ContCboSelListChapters)
        Me.PanelOben.Controls.Add(Me.lblChapters)
        Me.PanelOben.Controls.Add(Me.txtSearchText)
        Me.PanelOben.Controls.Add(Me.lblSearch)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(758, 72)
        Me.PanelOben.TabIndex = 1
        '
        'ComboApplication1
        '
        Me.ComboApplication1.BackColor = System.Drawing.Color.Transparent
        Me.ComboApplication1.Location = New System.Drawing.Point(6, 3)
        Me.ComboApplication1.Name = "ComboApplication1"
        Me.ComboApplication1.OwnLabelVisible = True
        Me.ComboApplication1.Size = New System.Drawing.Size(353, 24)
        Me.ComboApplication1.TabIndex = 596
        '
        'optChapterStayFollowUp
        '
        Me.optChapterStayFollowUp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optChapterStayFollowUp.CheckedIndex = 0
        valueListItem2.DataValue = "Chapters0"
        valueListItem2.DisplayText = "Stay"
        ValueListItem1.DataValue = "Chapters1"
        ValueListItem1.DisplayText = "FollowUp"
        Me.optChapterStayFollowUp.Items.AddRange(New Infragistics.Win.ValueListItem() {valueListItem2, ValueListItem1})
        Me.optChapterStayFollowUp.Location = New System.Drawing.Point(145, 30)
        Me.optChapterStayFollowUp.Name = "optChapterStayFollowUp"
        Me.optChapterStayFollowUp.Size = New System.Drawing.Size(179, 14)
        Me.optChapterStayFollowUp.TabIndex = 597
        Me.optChapterStayFollowUp.Text = "Stay"
        '
        'ContCboSelListChapters
        '
        Me.ContCboSelListChapters.BackColor = System.Drawing.Color.Transparent
        Me.ContCboSelListChapters.Location = New System.Drawing.Point(145, 47)
        Me.ContCboSelListChapters.Name = "ContCboSelListChapters"
        Me.ContCboSelListChapters.Size = New System.Drawing.Size(214, 22)
        Me.ContCboSelListChapters.TabIndex = 594
        Me.ContCboSelListChapters.UserEntry = "False"
        '
        'lblChapters
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.lblChapters.Appearance = Appearance1
        Me.lblChapters.Location = New System.Drawing.Point(57, 50)
        Me.lblChapters.Name = "lblChapters"
        Me.lblChapters.Size = New System.Drawing.Size(84, 16)
        Me.lblChapters.TabIndex = 595
        Me.lblChapters.Text = "Chapters"
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Me.txtSearchText.Appearance = Appearance2
        Me.txtSearchText.BackColor = System.Drawing.Color.White
        Me.txtSearchText.Location = New System.Drawing.Point(550, 45)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(200, 21)
        Me.txtSearchText.TabIndex = 592
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.Location = New System.Drawing.Point(508, 48)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(139, 16)
        Me.lblSearch.TabIndex = 593
        Me.lblSearch.Text = "Search"
        '
        'PanelUnten
        '
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 366)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(758, 25)
        Me.PanelUnten.TabIndex = 2
        Me.PanelUnten.Visible = False
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 72)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(758, 294)
        Me.PanelGrid.TabIndex = 3
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.gridCriterias)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(758, 294)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'gridCriterias
        '
        Me.gridCriterias.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridCriterias.DataMember = "tblCriteria"
        Me.gridCriterias.DataSource = Me.DsAdmin1
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCriterias.DisplayLayout.Appearance = Appearance3
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 3
        UltraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(131, 0)
        UltraGridColumn1.Width = 167
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.Caption = "Application"
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 116
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 132
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 7
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 193
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(143, 0)
        UltraGridColumn6.Width = 167
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 10
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 11
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.Editor = Nothing
        UltraGridColumn10.Header.VisiblePosition = 13
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Editor = Nothing
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn12.Header.Editor = Nothing
        UltraGridColumn12.Header.VisiblePosition = 14
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.Editor = Nothing
        UltraGridColumn13.Header.VisiblePosition = 16
        UltraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(55, 0)
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.Header.Editor = Nothing
        UltraGridColumn14.Header.VisiblePosition = 18
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.Header.Editor = Nothing
        UltraGridColumn15.Header.VisiblePosition = 19
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.Header.Editor = Nothing
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.Header.Editor = Nothing
        UltraGridColumn17.Header.VisiblePosition = 20
        UltraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(86, 0)
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.Header.Editor = Nothing
        UltraGridColumn18.Header.VisiblePosition = 21
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.Header.Editor = Nothing
        UltraGridColumn19.Header.VisiblePosition = 22
        UltraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(210, 0)
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.Header.Editor = Nothing
        UltraGridColumn20.Header.VisiblePosition = 15
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.Header.Editor = Nothing
        UltraGridColumn21.Header.VisiblePosition = 23
        UltraGridColumn22.Header.Editor = Nothing
        UltraGridColumn22.Header.VisiblePosition = 27
        UltraGridColumn22.Width = 293
        UltraGridColumn23.Header.Editor = Nothing
        UltraGridColumn23.Header.VisiblePosition = 24
        UltraGridColumn24.Header.Editor = Nothing
        UltraGridColumn24.Header.VisiblePosition = 25
        UltraGridColumn102.Header.Editor = Nothing
        UltraGridColumn102.Header.VisiblePosition = 26
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.Header.Editor = Nothing
        UltraGridColumn25.Header.VisiblePosition = 31
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.Header.Editor = Nothing
        UltraGridColumn26.Header.VisiblePosition = 30
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 29
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn28.Header.Editor = Nothing
        UltraGridColumn28.Header.VisiblePosition = 28
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.Header.Editor = Nothing
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(186, 0)
        UltraGridColumn29.Width = 313
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.DataType = GetType(Boolean)
        UltraGridColumn30.Header.Editor = Nothing
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn103.DataType = GetType(Integer)
        UltraGridColumn103.Header.Caption = "Selection"
        UltraGridColumn103.Header.Editor = Nothing
        UltraGridColumn103.Header.VisiblePosition = 1
        UltraGridColumn103.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TriStateCheckBox
        UltraGridColumn103.Width = 71
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn102, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn103})
        UltraGridColumn31.Header.Editor = Nothing
        UltraGridColumn31.Header.VisiblePosition = 0
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn32.Header.Editor = Nothing
        UltraGridColumn32.Header.VisiblePosition = 1
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn33.Header.Editor = Nothing
        UltraGridColumn33.Header.VisiblePosition = 2
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn34.Header.Editor = Nothing
        UltraGridColumn34.Header.VisiblePosition = 3
        UltraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn35.Header.Editor = Nothing
        UltraGridColumn35.Header.VisiblePosition = 4
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn36.Header.Editor = Nothing
        UltraGridColumn36.Header.VisiblePosition = 5
        UltraGridColumn37.Header.Editor = Nothing
        UltraGridColumn37.Header.VisiblePosition = 7
        UltraGridColumn38.Header.Editor = Nothing
        UltraGridColumn38.Header.VisiblePosition = 10
        UltraGridColumn39.Header.Editor = Nothing
        UltraGridColumn39.Header.VisiblePosition = 8
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn40.Header.Editor = Nothing
        UltraGridColumn40.Header.VisiblePosition = 6
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn41.Header.Editor = Nothing
        UltraGridColumn41.Header.VisiblePosition = 9
        UltraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn42.Header.Editor = Nothing
        UltraGridColumn42.Header.VisiblePosition = 12
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.Header.Editor = Nothing
        UltraGridColumn43.Header.VisiblePosition = 13
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn44.Header.Editor = Nothing
        UltraGridColumn44.Header.VisiblePosition = 14
        UltraGridColumn45.Header.Editor = Nothing
        UltraGridColumn45.Header.VisiblePosition = 16
        UltraGridColumn46.Header.Editor = Nothing
        UltraGridColumn46.Header.VisiblePosition = 17
        UltraGridColumn47.Header.Editor = Nothing
        UltraGridColumn47.Header.VisiblePosition = 18
        UltraGridColumn48.Header.Editor = Nothing
        UltraGridColumn48.Header.VisiblePosition = 19
        UltraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn49.Header.Editor = Nothing
        UltraGridColumn49.Header.VisiblePosition = 15
        UltraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn50.Header.Editor = Nothing
        UltraGridColumn50.Header.VisiblePosition = 11
        UltraGridColumn51.Header.Editor = Nothing
        UltraGridColumn51.Header.VisiblePosition = 20
        UltraGridColumn52.Header.Editor = Nothing
        UltraGridColumn52.Header.VisiblePosition = 21
        UltraGridColumn53.Header.Editor = Nothing
        UltraGridColumn53.Header.VisiblePosition = 22
        UltraGridColumn54.Header.Editor = Nothing
        UltraGridColumn54.Header.VisiblePosition = 23
        UltraGridColumn55.Header.Editor = Nothing
        UltraGridColumn55.Header.VisiblePosition = 24
        UltraGridColumn104.Header.Editor = Nothing
        UltraGridColumn104.Header.VisiblePosition = 25
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn104})
        UltraGridBand2.Hidden = True
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn56.Header.Editor = Nothing
        UltraGridColumn56.Header.VisiblePosition = 0
        UltraGridColumn57.Header.Editor = Nothing
        UltraGridColumn57.Header.VisiblePosition = 1
        UltraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn58.Header.Editor = Nothing
        UltraGridColumn58.Header.VisiblePosition = 2
        UltraGridColumn59.Header.Editor = Nothing
        UltraGridColumn59.Header.VisiblePosition = 3
        UltraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn60.Header.Editor = Nothing
        UltraGridColumn60.Header.VisiblePosition = 4
        UltraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn61.Header.Editor = Nothing
        UltraGridColumn61.Header.VisiblePosition = 5
        UltraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn62.Header.Editor = Nothing
        UltraGridColumn62.Header.VisiblePosition = 6
        UltraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn63.Header.Editor = Nothing
        UltraGridColumn63.Header.VisiblePosition = 7
        UltraGridColumn64.Header.Editor = Nothing
        UltraGridColumn64.Header.VisiblePosition = 8
        UltraGridColumn65.Header.Editor = Nothing
        UltraGridColumn65.Header.VisiblePosition = 9
        UltraGridColumn66.Header.Editor = Nothing
        UltraGridColumn66.Header.VisiblePosition = 10
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66})
        UltraGridBand3.Hidden = True
        UltraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn67.Header.Editor = Nothing
        UltraGridColumn67.Header.VisiblePosition = 0
        UltraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn68.Header.Editor = Nothing
        UltraGridColumn68.Header.VisiblePosition = 1
        UltraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn69.Header.Editor = Nothing
        UltraGridColumn69.Header.VisiblePosition = 2
        UltraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn70.Header.Editor = Nothing
        UltraGridColumn70.Header.VisiblePosition = 3
        UltraGridColumn71.Header.Editor = Nothing
        UltraGridColumn71.Header.VisiblePosition = 4
        UltraGridColumn72.Header.Editor = Nothing
        UltraGridColumn72.Header.VisiblePosition = 5
        UltraGridColumn73.Header.Editor = Nothing
        UltraGridColumn73.Header.VisiblePosition = 6
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73})
        UltraGridBand4.Hidden = True
        UltraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn74.Header.Editor = Nothing
        UltraGridColumn74.Header.VisiblePosition = 0
        UltraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn75.Header.Editor = Nothing
        UltraGridColumn75.Header.VisiblePosition = 1
        UltraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn76.Header.Editor = Nothing
        UltraGridColumn76.Header.VisiblePosition = 3
        UltraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn77.Header.Editor = Nothing
        UltraGridColumn77.Header.VisiblePosition = 2
        UltraGridColumn77.Width = 59
        UltraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn78.Header.Editor = Nothing
        UltraGridColumn78.Header.VisiblePosition = 4
        UltraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn79.Header.Editor = Nothing
        UltraGridColumn79.Header.VisiblePosition = 5
        UltraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn80.Header.Editor = Nothing
        UltraGridColumn80.Header.VisiblePosition = 7
        UltraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn81.Header.Editor = Nothing
        UltraGridColumn81.Header.VisiblePosition = 9
        UltraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn82.Header.Editor = Nothing
        UltraGridColumn82.Header.VisiblePosition = 11
        UltraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn83.Header.Editor = Nothing
        UltraGridColumn83.Header.VisiblePosition = 13
        UltraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn84.Header.Editor = Nothing
        UltraGridColumn84.Header.VisiblePosition = 15
        UltraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn85.Header.Editor = Nothing
        UltraGridColumn85.Header.VisiblePosition = 6
        UltraGridColumn85.Width = 53
        UltraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn86.Header.Editor = Nothing
        UltraGridColumn86.Header.VisiblePosition = 8
        UltraGridColumn86.Width = 53
        UltraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn87.Header.Editor = Nothing
        UltraGridColumn87.Header.VisiblePosition = 10
        UltraGridColumn87.Width = 53
        UltraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn88.Header.Editor = Nothing
        UltraGridColumn88.Header.VisiblePosition = 12
        UltraGridColumn88.Width = 53
        UltraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn89.Header.Editor = Nothing
        UltraGridColumn89.Header.VisiblePosition = 14
        UltraGridColumn89.Width = 56
        UltraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn90.Header.Editor = Nothing
        UltraGridColumn90.Header.VisiblePosition = 16
        UltraGridColumn90.Width = 53
        UltraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn91.Header.Editor = Nothing
        UltraGridColumn91.Header.VisiblePosition = 18
        UltraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn92.Header.Editor = Nothing
        UltraGridColumn92.Header.VisiblePosition = 19
        UltraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn93.Header.Editor = Nothing
        UltraGridColumn93.Header.VisiblePosition = 17
        UltraGridColumn93.Width = 31
        UltraGridColumn94.Header.Editor = Nothing
        UltraGridColumn94.Header.VisiblePosition = 20
        UltraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn95.Header.Editor = Nothing
        UltraGridColumn95.Header.VisiblePosition = 21
        UltraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn96.Header.Editor = Nothing
        UltraGridColumn96.Header.VisiblePosition = 22
        UltraGridColumn97.Header.Editor = Nothing
        UltraGridColumn97.Header.VisiblePosition = 23
        UltraGridColumn98.Header.Editor = Nothing
        UltraGridColumn98.Header.VisiblePosition = 24
        UltraGridColumn99.Header.Editor = Nothing
        UltraGridColumn99.Header.VisiblePosition = 25
        UltraGridColumn100.Header.Editor = Nothing
        UltraGridColumn100.Header.VisiblePosition = 26
        UltraGridColumn101.Header.Editor = Nothing
        UltraGridColumn101.Header.VisiblePosition = 27
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101})
        UltraGridBand5.Hidden = True
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.gridCriterias.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCriterias.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCriterias.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.gridCriterias.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCriterias.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.gridCriterias.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCriterias.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridCriterias.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridCriterias.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.gridCriterias.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCriterias.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCriterias.DisplayLayout.Override.CellAppearance = Appearance10
        Me.gridCriterias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridCriterias.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.gridCriterias.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.gridCriterias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridCriterias.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.gridCriterias.DisplayLayout.Override.RowAppearance = Appearance13
        Me.gridCriterias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCriterias.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.gridCriterias.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCriterias.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.gridCriterias, GridBagConstraint1)
        Me.gridCriterias.Location = New System.Drawing.Point(5, 5)
        Me.gridCriterias.Name = "gridCriterias"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.gridCriterias, New System.Drawing.Size(284, 97))
        Me.gridCriterias.Size = New System.Drawing.Size(748, 289)
        Me.gridCriterias.TabIndex = 0
        Me.gridCriterias.Text = "Gruppen"
        Me.gridCriterias.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAuswahllisten"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'contSelListsChapter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.Name = "contSelListsChapter"
        Me.Size = New System.Drawing.Size(758, 391)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PanelOben.ResumeLayout(False)
        Me.PanelOben.PerformLayout()
        CType(Me.optChapterStayFollowUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearchText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.gridCriterias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridCriterias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelOben As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents txtSearchText As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblChapters As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ContCboSelListChapters As qs2.sitemap.vb.contCboSelList
    Friend WithEvents ComboApplication1 As qs2.sitemap.comboApplication
    Private WithEvents optChapterStayFollowUp As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ToolStripMenuItemSpace10 As Windows.Forms.ToolStripSeparator
    Friend WithEvents BuildSqlCheckedTrueToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuildSqlCheckedFalseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
