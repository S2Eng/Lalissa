<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelListsObj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contSelListsObj))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sort")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeQry")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeStr")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Table")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortColumn")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("picture")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Private")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification", -1, 260517926)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sql")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UIType")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubQuery")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Published")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries_tblStayAdditions")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selection", 0)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("From", 1)
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("To", 2)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 3, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKey", 4)
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active", 5)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EditableWhenCompleted", 6)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries_tblStayAdditions", 0)
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayParent")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayParent")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayParent")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayChild")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayChild")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayChild")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListFirst")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(260517926)
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssignCriteriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelListObjToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelListObj2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelListObj3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelListObj4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace01 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuildSqlCheckedTrueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildSqlCheckedFalseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelOben = New System.Windows.Forms.Panel()
        Me.btnReload = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.ComboApplication = New qs2.sitemap.comboApplication()
        Me.lblApplication = New Infragistics.Win.Misc.UltraLabel()
        Me.ContCboGroup1 = New qs2.sitemap.vb.contCboGroup()
        Me.lblGroup = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridSelListObj = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAuswahllisten1 = New qs2.core.vb.dsAdmin()
        Me.AssignCriteriaCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PanelOben.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.gridSelListObj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignCriteriaToolStripMenuItem, Me.AssignCriteriaCustomerToolStripMenuItem, Me.OpenSelListObjToolStripMenuItem, Me.OpenSelListObj2ToolStripMenuItem, Me.OpenSelListObj3ToolStripMenuItem, Me.OpenSelListObj4ToolStripMenuItem, Me.OpenSelListToolStripMenuItem, Me.ToolStripMenuItemSpace01, Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripMenuItemSpace10, Me.BuildSqlCheckedTrueToolStripMenuItem, Me.BuildSqlCheckedFalseToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 280)
        '
        'AssignCriteriaToolStripMenuItem
        '
        Me.AssignCriteriaToolStripMenuItem.Name = "AssignCriteriaToolStripMenuItem"
        Me.AssignCriteriaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AssignCriteriaToolStripMenuItem.Text = "AssignCriteria"
        Me.AssignCriteriaToolStripMenuItem.Visible = False
        '
        'OpenSelListObjToolStripMenuItem
        '
        Me.OpenSelListObjToolStripMenuItem.Name = "OpenSelListObjToolStripMenuItem"
        Me.OpenSelListObjToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSelListObjToolStripMenuItem.Text = "OpenSelListObj"
        Me.OpenSelListObjToolStripMenuItem.Visible = False
        '
        'OpenSelListObj2ToolStripMenuItem
        '
        Me.OpenSelListObj2ToolStripMenuItem.Name = "OpenSelListObj2ToolStripMenuItem"
        Me.OpenSelListObj2ToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSelListObj2ToolStripMenuItem.Text = "OpenSelListObj2"
        Me.OpenSelListObj2ToolStripMenuItem.Visible = False
        '
        'OpenSelListObj3ToolStripMenuItem
        '
        Me.OpenSelListObj3ToolStripMenuItem.Name = "OpenSelListObj3ToolStripMenuItem"
        Me.OpenSelListObj3ToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSelListObj3ToolStripMenuItem.Text = "OpenSelListObj3"
        Me.OpenSelListObj3ToolStripMenuItem.Visible = False
        '
        'OpenSelListObj4ToolStripMenuItem
        '
        Me.OpenSelListObj4ToolStripMenuItem.Name = "OpenSelListObj4ToolStripMenuItem"
        Me.OpenSelListObj4ToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSelListObj4ToolStripMenuItem.Text = "OpenSelListObj4"
        Me.OpenSelListObj4ToolStripMenuItem.Visible = False
        '
        'OpenSelListToolStripMenuItem
        '
        Me.OpenSelListToolStripMenuItem.Name = "OpenSelListToolStripMenuItem"
        Me.OpenSelListToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSelListToolStripMenuItem.Text = "OpenSelList"
        '
        'ToolStripMenuItemSpace01
        '
        Me.ToolStripMenuItemSpace01.Name = "ToolStripMenuItemSpace01"
        Me.ToolStripMenuItemSpace01.Size = New System.Drawing.Size(200, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select all"
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
        Me.PanelOben.Controls.Add(Me.btnReload)
        Me.PanelOben.Controls.Add(Me.ComboApplication)
        Me.PanelOben.Controls.Add(Me.lblApplication)
        Me.PanelOben.Controls.Add(Me.ContCboGroup1)
        Me.PanelOben.Controls.Add(Me.lblGroup)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(631, 29)
        Me.PanelOben.TabIndex = 1
        Me.PanelOben.Visible = False
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnReload.Appearance = Appearance1
        Me.btnReload.Location = New System.Drawing.Point(602, 4)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.OwnAutoTextYN = False
        Me.btnReload.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Aktualisieren
        Me.btnReload.OwnPictureTxt = ""
        Me.btnReload.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnReload.OwnTooltipText = ""
        Me.btnReload.OwnTooltipTitle = Nothing
        Me.btnReload.Size = New System.Drawing.Size(23, 22)
        Me.btnReload.TabIndex = 595
        '
        'ComboApplication
        '
        Me.ComboApplication.BackColor = System.Drawing.Color.Transparent
        Me.ComboApplication.Location = New System.Drawing.Point(81, 5)
        Me.ComboApplication.Name = "ComboApplication"
        Me.ComboApplication.OwnLabelVisible = False
        Me.ComboApplication.Size = New System.Drawing.Size(103, 21)
        Me.ComboApplication.TabIndex = 593
        '
        'lblApplication
        '
        Me.lblApplication.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblApplication.Location = New System.Drawing.Point(6, 7)
        Me.lblApplication.Name = "lblApplication"
        Me.lblApplication.Size = New System.Drawing.Size(100, 16)
        Me.lblApplication.TabIndex = 594
        Me.lblApplication.Text = "Application"
        '
        'ContCboGroup1
        '
        Me.ContCboGroup1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContCboGroup1.BackColor = System.Drawing.Color.Transparent
        Me.ContCboGroup1.Location = New System.Drawing.Point(233, 5)
        Me.ContCboGroup1.Name = "ContCboGroup1"
        Me.ContCboGroup1.Size = New System.Drawing.Size(130, 21)
        Me.ContCboGroup1.TabIndex = 0
        '
        'lblGroup
        '
        Me.lblGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.TextHAlignAsString = "Right"
        Me.lblGroup.Appearance = Appearance2
        Me.lblGroup.Location = New System.Drawing.Point(179, 7)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(48, 16)
        Me.lblGroup.TabIndex = 592
        Me.lblGroup.Text = "Group"
        '
        'PanelUnten
        '
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 267)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(631, 23)
        Me.PanelUnten.TabIndex = 2
        Me.PanelUnten.Visible = False
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 29)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(631, 238)
        Me.PanelGrid.TabIndex = 3
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.gridSelListObj)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(631, 238)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'gridSelListObj
        '
        Me.gridSelListObj.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridSelListObj.DataMember = "tblSelListEntries"
        Me.gridSelListObj.DataSource = Me.DsAuswahllisten1
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSelListObj.DisplayLayout.Appearance = Appearance3
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance4
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn1.Header.Appearance = Appearance5
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 32
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Hidden = True
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn4.Header.Appearance = Appearance7
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 4
        UltraGridColumn6.Hidden = True
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance8
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance9
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 10
        UltraGridColumn7.Width = 69
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 131
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 11
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.Editor = Nothing
        UltraGridColumn10.Header.VisiblePosition = 12
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Editor = Nothing
        UltraGridColumn11.Header.VisiblePosition = 13
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.Editor = Nothing
        UltraGridColumn12.Header.VisiblePosition = 14
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Editor = Nothing
        UltraGridColumn13.Header.VisiblePosition = 15
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.Editor = Nothing
        UltraGridColumn14.Header.VisiblePosition = 16
        UltraGridColumn14.Hidden = True
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn15.Header.Appearance = Appearance11
        UltraGridColumn15.Header.Editor = Nothing
        UltraGridColumn15.Header.VisiblePosition = 18
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.Header.Editor = Nothing
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn17.Header.Editor = Nothing
        UltraGridColumn17.Header.VisiblePosition = 19
        UltraGridColumn18.Header.Editor = Nothing
        UltraGridColumn18.Header.VisiblePosition = 20
        UltraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn18.Width = 147
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn19.CellAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn19.Header.Appearance = Appearance13
        UltraGridColumn19.Header.Editor = Nothing
        UltraGridColumn19.Header.VisiblePosition = 21
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.Header.Editor = Nothing
        UltraGridColumn20.Header.VisiblePosition = 22
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.Header.Editor = Nothing
        UltraGridColumn21.Header.VisiblePosition = 23
        UltraGridColumn22.Header.Editor = Nothing
        UltraGridColumn22.Header.VisiblePosition = 33
        UltraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(271, 0)
        UltraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedText
        UltraGridColumn23.Header.Editor = Nothing
        UltraGridColumn23.Header.VisiblePosition = 24
        UltraGridColumn24.Header.Editor = Nothing
        UltraGridColumn24.Header.VisiblePosition = 25
        UltraGridColumn59.Header.Editor = Nothing
        UltraGridColumn59.Header.VisiblePosition = 26
        UltraGridColumn25.Header.Editor = Nothing
        UltraGridColumn25.Header.VisiblePosition = 28
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 27
        UltraGridColumn60.Header.Editor = Nothing
        UltraGridColumn60.Header.VisiblePosition = 34
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn61.CellAppearance = Appearance14
        UltraGridColumn61.DataType = GetType(Boolean)
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn61.Header.Appearance = Appearance15
        UltraGridColumn61.Header.Editor = Nothing
        UltraGridColumn61.Header.VisiblePosition = 5
        UltraGridColumn61.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(83, 0)
        UltraGridColumn61.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn61.Width = 58
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn62.CellAppearance = Appearance16
        UltraGridColumn62.DataType = GetType(Date)
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn62.Header.Appearance = Appearance17
        UltraGridColumn62.Header.Editor = Nothing
        UltraGridColumn62.Header.VisiblePosition = 29
        UltraGridColumn62.Hidden = True
        UltraGridColumn62.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownCalendar
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn63.CellAppearance = Appearance18
        UltraGridColumn63.DataType = GetType(Date)
        Appearance19.TextHAlignAsString = "Center"
        UltraGridColumn63.Header.Appearance = Appearance19
        UltraGridColumn63.Header.Editor = Nothing
        UltraGridColumn63.Header.VisiblePosition = 30
        UltraGridColumn63.Hidden = True
        UltraGridColumn63.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownCalendar
        UltraGridColumn64.Header.Editor = Nothing
        UltraGridColumn64.Header.VisiblePosition = 6
        UltraGridColumn64.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(299, 0)
        UltraGridColumn64.Width = 166
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance20
        UltraGridColumn65.DataType = GetType(Integer)
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn65.Header.Appearance = Appearance21
        UltraGridColumn65.Header.Editor = Nothing
        UltraGridColumn65.Header.VisiblePosition = 31
        UltraGridColumn65.Hidden = True
        UltraGridColumn65.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerWithSpin
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn66.CellAppearance = Appearance22
        UltraGridColumn66.DataType = GetType(Boolean)
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn66.Header.Appearance = Appearance23
        UltraGridColumn66.Header.Editor = Nothing
        UltraGridColumn66.Header.VisiblePosition = 9
        UltraGridColumn66.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn66.Width = 50
        UltraGridColumn26.Header.Caption = "Editable when completed"
        UltraGridColumn26.Header.Editor = Nothing
        UltraGridColumn26.Header.VisiblePosition = 7
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 69
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn59, UltraGridColumn25, UltraGridColumn27, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn26})
        UltraGridColumn67.Header.Editor = Nothing
        UltraGridColumn67.Header.VisiblePosition = 0
        UltraGridColumn67.Width = 39
        UltraGridColumn68.Header.Editor = Nothing
        UltraGridColumn68.Header.VisiblePosition = 1
        UltraGridColumn68.Width = 166
        UltraGridColumn69.Header.Editor = Nothing
        UltraGridColumn69.Header.VisiblePosition = 2
        UltraGridColumn69.Width = 69
        UltraGridColumn70.Header.Editor = Nothing
        UltraGridColumn70.Header.VisiblePosition = 3
        UltraGridColumn70.Width = 131
        UltraGridColumn71.Header.Editor = Nothing
        UltraGridColumn71.Header.VisiblePosition = 4
        UltraGridColumn71.Width = 50
        UltraGridColumn72.Header.Editor = Nothing
        UltraGridColumn72.Header.VisiblePosition = 5
        UltraGridColumn72.Width = 69
        UltraGridColumn73.Header.Editor = Nothing
        UltraGridColumn73.Header.VisiblePosition = 6
        UltraGridColumn74.Header.Editor = Nothing
        UltraGridColumn74.Header.VisiblePosition = 7
        UltraGridColumn75.Header.Editor = Nothing
        UltraGridColumn75.Header.VisiblePosition = 8
        UltraGridColumn76.Header.Editor = Nothing
        UltraGridColumn76.Header.VisiblePosition = 9
        UltraGridColumn76.Width = 137
        UltraGridColumn91.Header.Editor = Nothing
        UltraGridColumn91.Header.VisiblePosition = 10
        UltraGridColumn92.Header.Editor = Nothing
        UltraGridColumn92.Header.VisiblePosition = 11
        UltraGridColumn93.Header.Editor = Nothing
        UltraGridColumn93.Header.VisiblePosition = 12
        UltraGridColumn94.Header.Editor = Nothing
        UltraGridColumn94.Header.VisiblePosition = 13
        UltraGridColumn95.Header.Editor = Nothing
        UltraGridColumn95.Header.VisiblePosition = 14
        UltraGridColumn96.Header.Editor = Nothing
        UltraGridColumn96.Header.VisiblePosition = 15
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96})
        Me.gridSelListObj.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSelListObj.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridSelListObj.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSelListObj.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSelListObj.DisplayLayout.GroupByBox.Appearance = Appearance24
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSelListObj.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance25
        Me.gridSelListObj.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance26.BackColor2 = System.Drawing.SystemColors.Control
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSelListObj.DisplayLayout.GroupByBox.PromptAppearance = Appearance26
        Me.gridSelListObj.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSelListObj.DisplayLayout.MaxRowScrollRegions = 1
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridSelListObj.DisplayLayout.Override.ActiveCellAppearance = Appearance27
        Appearance28.BackColor = System.Drawing.SystemColors.Highlight
        Appearance28.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridSelListObj.DisplayLayout.Override.ActiveRowAppearance = Appearance28
        Me.gridSelListObj.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSelListObj.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Me.gridSelListObj.DisplayLayout.Override.CardAreaAppearance = Appearance29
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Appearance30.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSelListObj.DisplayLayout.Override.CellAppearance = Appearance30
        Me.gridSelListObj.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSelListObj.DisplayLayout.Override.CellPadding = 0
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSelListObj.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance32.TextHAlignAsString = "Left"
        Me.gridSelListObj.DisplayLayout.Override.HeaderAppearance = Appearance32
        Me.gridSelListObj.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSelListObj.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Me.gridSelListObj.DisplayLayout.Override.RowAppearance = Appearance33
        Me.gridSelListObj.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSelListObj.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSelListObj.DisplayLayout.Override.TemplateAddRowAppearance = Appearance34
        Me.gridSelListObj.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSelListObj.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Classification"
        Me.gridSelListObj.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1})
        Me.gridSelListObj.Dock = System.Windows.Forms.DockStyle.Fill
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.gridSelListObj, GridBagConstraint1)
        Me.gridSelListObj.Location = New System.Drawing.Point(0, 0)
        Me.gridSelListObj.Name = "gridSelListObj"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.gridSelListObj, New System.Drawing.Size(552, 133))
        Me.gridSelListObj.Size = New System.Drawing.Size(631, 238)
        Me.gridSelListObj.TabIndex = 0
        '
        'DsAuswahllisten1
        '
        Me.DsAuswahllisten1.DataSetName = "dsAuswahllisten"
        Me.DsAuswahllisten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AssignCriteriaCustomerToolStripMenuItem
        '
        Me.AssignCriteriaCustomerToolStripMenuItem.Name = "AssignCriteriaCustomerToolStripMenuItem"
        Me.AssignCriteriaCustomerToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AssignCriteriaCustomerToolStripMenuItem.Text = "AssignCriteriaCustomer"
        '
        'contSelListsObj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.Name = "contSelListsObj"
        Me.Size = New System.Drawing.Size(631, 290)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PanelOben.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.gridSelListObj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelOben As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContCboGroup1 As qs2.sitemap.vb.contCboGroup
    Friend WithEvents lblGroup As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents AssignCriteriaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace01 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComboApplication As qs2.sitemap.comboApplication
    Friend WithEvents lblApplication As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnReload As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents OpenSelListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents gridSelListObj As Infragistics.Win.UltraWinGrid.UltraGrid
    Public WithEvents OpenSelListObjToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DsAuswahllisten1 As qs2.core.vb.dsAdmin
    Public WithEvents OpenSelListObj2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents OpenSelListObj3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents OpenSelListObj4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace10 As Windows.Forms.ToolStripSeparator
    Friend WithEvents BuildSqlCheckedTrueToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuildSqlCheckedFalseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignCriteriaCustomerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
