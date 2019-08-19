<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOffeneTermine2
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim UltraToolTipInfo7 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Planungseintrag öffnen", Infragistics.Win.ToolTipImage.[Default], "Planungseintrag öffnen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Alle ausgewählten Planungseinträge als erledigt markieren", Infragistics.Win.ToolTipImage.[Default], "Planungseinträge als erledigt markieren", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOffeneTermine))
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Art des Planungseintrages", Infragistics.Win.ToolTipImage.[Default], "Art", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Beginnt am des Planungseintrages größer als ...", Infragistics.Win.ToolTipImage.[Default], "Von", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Für Sachbearbeiter", Infragistics.Win.ToolTipImage.[Default], "Sachbearbeiter", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Beginnt am des Planungseintrages kleiner als ...", Infragistics.Win.ToolTipImage.[Default], "Bis", Infragistics.Win.DefaultableBoolean.[Default])
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche durchführen", Infragistics.Win.ToolTipImage.[Default], "Suchen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("plan", -1)
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BeginntAm", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FälligAm")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDArt", -1, 890876923)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Priorität")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailAn")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailCC")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("html")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Für")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("gesendetAm")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembJN")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembMinut")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("wichtig")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Teilnehmer")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDActivity")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStatus")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTyp")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KommStatus")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("db")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("deleted")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzObjects")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activity")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("design")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailBcc")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUserAccount")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailFrom")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("readed")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("empfangenAm")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MessageId")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzAnhänge")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPlanMain")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReplyTxt")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsOwner")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AwaitingResponse")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDFolder")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(890876923)
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WechelnZuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InNeuemTabÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GruppierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlsExcelExportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayoutManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnPlanEntyOpen = New Infragistics.Win.Misc.UltraButton()
        Me.lblInfo = New Infragistics.Win.Misc.UltraLabel()
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.btnEndPlanEntry = New Infragistics.Win.Misc.UltraButton()
        Me.PanelUntenREchts = New System.Windows.Forms.Panel()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.grpSearch = New Infragistics.Win.Misc.UltraGroupBox()
        Me.udtBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.cboUsers = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.cboArt = New contComboSelListGrid()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblArt = New Infragistics.Win.Misc.UltraLabel()
        Me.lblResetSearching = New Infragistics.Win.Misc.UltraLabel()
        Me.lblUsers = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSearch = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGridBagLayoutPanelMitte = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridPlans = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsPlanSearch1 = New dsPlanSearch()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnten.SuspendLayout()
        Me.PanelUntenREchts.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        CType(Me.udtBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridBagLayoutPanelMitte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelMitte.SuspendLayout()
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WechelnZuToolStripMenuItem, Me.InNeuemTabÖffnenToolStripMenuItem, Me.ToolStripMenuItem2, Me.AlleAuswählenToolStripMenuItem, Me.KeineAuswählenToolStripMenuItem, Me.ToolStripMenuItem1, Me.GruppierenToolStripMenuItem, Me.FilterToolStripMenuItem, Me.AlsExcelExportierenToolStripMenuItem, Me.LayoutManagerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 192)
        '
        'WechelnZuToolStripMenuItem
        '
        Me.WechelnZuToolStripMenuItem.Name = "WechelnZuToolStripMenuItem"
        Me.WechelnZuToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.WechelnZuToolStripMenuItem.Tag = "ResID.SwitchTo"
        Me.WechelnZuToolStripMenuItem.Text = "Wechseln zu"
        '
        'InNeuemTabÖffnenToolStripMenuItem
        '
        Me.InNeuemTabÖffnenToolStripMenuItem.Name = "InNeuemTabÖffnenToolStripMenuItem"
        Me.InNeuemTabÖffnenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.InNeuemTabÖffnenToolStripMenuItem.Tag = "ResID.OpenInANewTab"
        Me.InNeuemTabÖffnenToolStripMenuItem.Text = "In neuem Tab öffnen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 6)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AlleAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswählenToolStripMenuItem
        '
        Me.KeineAuswählenToolStripMenuItem.Name = "KeineAuswählenToolStripMenuItem"
        Me.KeineAuswählenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.KeineAuswählenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswählenToolStripMenuItem.Text = "Keine auswählen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 6)
        '
        'GruppierenToolStripMenuItem
        '
        Me.GruppierenToolStripMenuItem.CheckOnClick = True
        Me.GruppierenToolStripMenuItem.Name = "GruppierenToolStripMenuItem"
        Me.GruppierenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.GruppierenToolStripMenuItem.Tag = "ResID.Grouping"
        Me.GruppierenToolStripMenuItem.Text = "Gruppieren"
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.CheckOnClick = True
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.FilterToolStripMenuItem.Tag = "ResID.Filter"
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'AlsExcelExportierenToolStripMenuItem
        '
        Me.AlsExcelExportierenToolStripMenuItem.Name = "AlsExcelExportierenToolStripMenuItem"
        Me.AlsExcelExportierenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AlsExcelExportierenToolStripMenuItem.Tag = "ResID.ExportToExcel"
        Me.AlsExcelExportierenToolStripMenuItem.Text = "Als Excel exportieren"
        '
        'LayoutManagerToolStripMenuItem
        '
        Me.LayoutManagerToolStripMenuItem.Name = "LayoutManagerToolStripMenuItem"
        Me.LayoutManagerToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.LayoutManagerToolStripMenuItem.Tag = "ResID.LayoutManager"
        Me.LayoutManagerToolStripMenuItem.Text = "Layout-Manager"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(18, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(70, 24)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Tag = "ResID.Close"
        Me.btnClose.Text = "Schließen"
        '
        'btnPlanEntyOpen
        '
        Me.btnPlanEntyOpen.Location = New System.Drawing.Point(8, 2)
        Me.btnPlanEntyOpen.Name = "btnPlanEntyOpen"
        Me.btnPlanEntyOpen.Size = New System.Drawing.Size(88, 24)
        Me.btnPlanEntyOpen.TabIndex = 0
        Me.btnPlanEntyOpen.Tag = "ResID.OpenEntry"
        Me.btnPlanEntyOpen.Text = "Eintrag öffnen"
        UltraToolTipInfo7.ToolTipText = "Ausgewählten Planungseintrag öffnen"
        UltraToolTipInfo7.ToolTipTitle = "Planungseintrag öffnen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnPlanEntyOpen, UltraToolTipInfo7)
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(11, 14)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(266, 16)
        Me.lblInfo.TabIndex = 3
        Me.lblInfo.Tag = "ResID.ListOfOpenPlans"
        Me.lblInfo.Text = "Liste Ihrer offenen Planungen"
        Me.lblInfo.UseAppStyling = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(74, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(381, 21)
        Me.txtSearch.TabIndex = 0
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.btnEndPlanEntry)
        Me.PanelUnten.Controls.Add(Me.PanelUntenREchts)
        Me.PanelUnten.Controls.Add(Me.btnPlanEntyOpen)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 473)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(995, 32)
        Me.PanelUnten.TabIndex = 1
        Me.PanelUnten.TabStop = True
        '
        'btnEndPlanEntry
        '
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnEndPlanEntry.Appearance = Appearance16
        Me.btnEndPlanEntry.Location = New System.Drawing.Point(97, 2)
        Me.btnEndPlanEntry.Name = "btnEndPlanEntry"
        Me.btnEndPlanEntry.Size = New System.Drawing.Size(27, 24)
        Me.btnEndPlanEntry.TabIndex = 1
        UltraToolTipInfo6.ToolTipText = "Alle ausgewählten Planungseinträge als erledigt markieren"
        UltraToolTipInfo6.ToolTipTitle = "Planungseinträge als erledigt markieren"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnEndPlanEntry, UltraToolTipInfo6)
        '
        'PanelUntenREchts
        '
        Me.PanelUntenREchts.Controls.Add(Me.btnClose)
        Me.PanelUntenREchts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelUntenREchts.Location = New System.Drawing.Point(902, 0)
        Me.PanelUntenREchts.Name = "PanelUntenREchts"
        Me.PanelUntenREchts.Size = New System.Drawing.Size(93, 32)
        Me.PanelUntenREchts.TabIndex = 2
        Me.PanelUntenREchts.TabStop = True
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.grpSearch)
        Me.PanelTop.Controls.Add(Me.lblInfo)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(995, 105)
        Me.PanelTop.TabIndex = 0
        Me.PanelTop.TabStop = True
        '
        'grpSearch
        '
        Me.grpSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSearch.Controls.Add(Me.udtBis)
        Me.grpSearch.Controls.Add(Me.cboUsers)
        Me.grpSearch.Controls.Add(Me.udtVon)
        Me.grpSearch.Controls.Add(Me.cboArt)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Controls.Add(Me.UltraLabel1)
        Me.grpSearch.Controls.Add(Me.UltraLabel2)
        Me.grpSearch.Controls.Add(Me.lblArt)
        Me.grpSearch.Controls.Add(Me.lblResetSearching)
        Me.grpSearch.Controls.Add(Me.lblUsers)
        Me.grpSearch.Controls.Add(Me.UltraLabel5)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Location = New System.Drawing.Point(425, 4)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(576, 99)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.Tag = "ResID.Search"
        Me.grpSearch.Text = "Suche"
        '
        'udtBis
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColorDisabled = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtBis.Appearance = Appearance5
        Me.udtBis.AutoSize = False
        Me.udtBis.BackColor = System.Drawing.Color.White
        Me.udtBis.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.udtBis.DateTime = New Date(2006, 5, 29, 0, 0, 0, 0)
        Me.udtBis.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.udtBis.Location = New System.Drawing.Point(191, 44)
        Me.udtBis.Name = "udtBis"
        Me.udtBis.Size = New System.Drawing.Size(88, 21)
        Me.udtBis.TabIndex = 2
        Me.udtBis.Value = New Date(2006, 5, 29, 0, 0, 0, 0)
        '
        'cboUsers
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackColorDisabled = System.Drawing.Color.White
        Appearance6.BackColorDisabled2 = System.Drawing.Color.White
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboUsers.Appearance = Appearance6
        Me.cboUsers.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboUsers.AutoSize = False
        Me.cboUsers.BackColor = System.Drawing.Color.White
        Me.cboUsers.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboUsers.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.cboUsers.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboUsers.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboUsers.ItemAppearance = Appearance7
        Me.cboUsers.Location = New System.Drawing.Point(360, 44)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(95, 21)
        Me.cboUsers.TabIndex = 3
        Me.cboUsers.Tag = "AutoFill"
        Me.cboUsers.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.cboUsers.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'udtVon
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BackColorDisabled = System.Drawing.Color.White
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtVon.Appearance = Appearance8
        Me.udtVon.AutoSize = False
        Me.udtVon.BackColor = System.Drawing.Color.White
        Me.udtVon.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.udtVon.DateTime = New Date(2006, 5, 29, 0, 0, 0, 0)
        Me.udtVon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.udtVon.Location = New System.Drawing.Point(74, 44)
        Me.udtVon.Name = "udtVon"
        Me.udtVon.Size = New System.Drawing.Size(83, 21)
        Me.udtVon.TabIndex = 1
        Me.udtVon.Value = New Date(2006, 5, 29, 0, 0, 0, 0)
        '
        'cboArt
        '
        Me.cboArt.BackColor = System.Drawing.Color.Transparent
        Me.cboArt.Location = New System.Drawing.Point(74, 68)
        Me.cboArt.Name = "cboArt"
        Me.cboArt.Size = New System.Drawing.Size(267, 21)
        Me.cboArt.TabIndex = 4
        UltraToolTipInfo1.ToolTipText = "Art des Planungseintrages"
        UltraToolTipInfo1.ToolTipTitle = "Art"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.cboArt, UltraToolTipInfo1)
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 44)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabel1.TabIndex = 423
        Me.UltraLabel1.Tag = "ResID.From"
        Me.UltraLabel1.Text = "Von"
        UltraToolTipInfo2.ToolTipText = "Beginnt am des Planungseintrages größer als ..."
        UltraToolTipInfo2.ToolTipTitle = "Von"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraLabel1, UltraToolTipInfo2)
        '
        'UltraLabel2
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.Location = New System.Drawing.Point(10, 23)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabel2.TabIndex = 420
        Me.UltraLabel2.Tag = "ResID.Subject"
        Me.UltraLabel2.Text = "Betreff"
        '
        'lblArt
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblArt.Appearance = Appearance11
        Me.lblArt.Location = New System.Drawing.Point(10, 70)
        Me.lblArt.Name = "lblArt"
        Me.lblArt.Size = New System.Drawing.Size(60, 17)
        Me.lblArt.TabIndex = 419
        Me.lblArt.Tag = "ResID.Type"
        Me.lblArt.Text = "Typ"
        '
        'lblResetSearching
        '
        Me.lblResetSearching.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance12.FontData.SizeInPoints = 7.5!
        Appearance12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblResetSearching.Appearance = Appearance12
        Me.lblResetSearching.AutoSize = True
        Appearance13.FontData.UnderlineAsString = "True"
        Me.lblResetSearching.HotTrackAppearance = Appearance13
        Me.lblResetSearching.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblResetSearching.Location = New System.Drawing.Point(498, 70)
        Me.lblResetSearching.Name = "lblResetSearching"
        Me.lblResetSearching.Size = New System.Drawing.Size(66, 13)
        Me.lblResetSearching.TabIndex = 101
        Me.lblResetSearching.Tag = "ResID.Reset"
        Me.lblResetSearching.Text = "Zurücksetzen"
        Me.lblResetSearching.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblUsers
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.BackColor2 = System.Drawing.Color.Transparent
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblUsers.Appearance = Appearance14
        Me.lblUsers.Location = New System.Drawing.Point(274, 44)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.Size = New System.Drawing.Size(86, 21)
        Me.lblUsers.TabIndex = 421
        Me.lblUsers.Tag = "ResID.Clerk"
        Me.lblUsers.Text = "Sachbearb."
        UltraToolTipInfo3.ToolTipText = "Für Sachbearbeiter"
        UltraToolTipInfo3.ToolTipTitle = "Sachbearbeiter"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.lblUsers, UltraToolTipInfo3)
        '
        'UltraLabel5
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.ForeColorDisabled = System.Drawing.Color.Black
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance15
        Me.UltraLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UltraLabel5.Location = New System.Drawing.Point(155, 44)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 21)
        Me.UltraLabel5.TabIndex = 6
        Me.UltraLabel5.Tag = "ResID.To"
        Me.UltraLabel5.Text = "bis"
        UltraToolTipInfo4.ToolTipText = "Beginnt am des Planungseintrages kleiner als ..."
        UltraToolTipInfo4.ToolTipTitle = "Bis"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraLabel5, UltraToolTipInfo4)
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(493, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(74, 33)
        Me.btnSearch.TabIndex = 100
        Me.btnSearch.Tag = "ResID.Search"
        Me.btnSearch.Text = "Suchen"
        UltraToolTipInfo5.ToolTipText = "Suche durchführen"
        UltraToolTipInfo5.ToolTipTitle = "Suchen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSearch, UltraToolTipInfo5)
        '
        'UltraGridBagLayoutPanelMitte
        '
        Me.UltraGridBagLayoutPanelMitte.Controls.Add(Me.gridPlans)
        Me.UltraGridBagLayoutPanelMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelMitte.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelMitte.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelMitte.Location = New System.Drawing.Point(0, 105)
        Me.UltraGridBagLayoutPanelMitte.Name = "UltraGridBagLayoutPanelMitte"
        Me.UltraGridBagLayoutPanelMitte.Size = New System.Drawing.Size(995, 368)
        Me.UltraGridBagLayoutPanelMitte.TabIndex = 10
        Me.UltraGridBagLayoutPanelMitte.TabStop = True
        '
        'gridPlans
        '
        Me.gridPlans.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridPlans.DataMember = "plan"
        Me.gridPlans.DataSource = Me.DsPlanSearch1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Appearance = Appearance1
        Me.gridPlans.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn42.Header.VisiblePosition = 1
        UltraGridColumn42.Width = 217
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.Header.VisiblePosition = 2
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn43.Width = 115
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn44.Header.VisiblePosition = 3
        UltraGridColumn44.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn44.Width = 111
        UltraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn45.Header.Caption = "Art"
        UltraGridColumn45.Header.VisiblePosition = 11
        UltraGridColumn45.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn45.Width = 122
        UltraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn46.Header.VisiblePosition = 13
        UltraGridColumn46.Width = 82
        UltraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn47.Header.VisiblePosition = 12
        UltraGridColumn47.Width = 151
        UltraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn48.Header.VisiblePosition = 14
        UltraGridColumn48.Hidden = True
        UltraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn49.Header.VisiblePosition = 15
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn50.Header.VisiblePosition = 16
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn51.Header.VisiblePosition = 17
        UltraGridColumn51.Hidden = True
        UltraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn52.Header.VisiblePosition = 18
        UltraGridColumn52.Hidden = True
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn53.Header.Caption = "Für Sachb."
        UltraGridColumn53.Header.VisiblePosition = 8
        UltraGridColumn53.Width = 131
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn54.Header.Caption = "Gesendet am"
        UltraGridColumn54.Header.VisiblePosition = 5
        UltraGridColumn54.Width = 124
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn55.Header.VisiblePosition = 19
        UltraGridColumn55.Hidden = True
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn56.Header.VisiblePosition = 20
        UltraGridColumn56.Hidden = True
        UltraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn57.Header.Caption = "Wichtig"
        UltraGridColumn57.Header.VisiblePosition = 21
        UltraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn58.Header.VisiblePosition = 22
        UltraGridColumn58.Hidden = True
        UltraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn59.Header.Caption = "Erstellt von"
        UltraGridColumn59.Header.VisiblePosition = 23
        UltraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn60.Header.Caption = "Erstellt am"
        UltraGridColumn60.Header.VisiblePosition = 4
        UltraGridColumn60.Width = 111
        UltraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn61.Header.VisiblePosition = 24
        UltraGridColumn61.Hidden = True
        UltraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn62.Header.VisiblePosition = 25
        UltraGridColumn62.Hidden = True
        UltraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn63.Header.VisiblePosition = 26
        UltraGridColumn63.Hidden = True
        UltraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn64.Header.VisiblePosition = 27
        UltraGridColumn64.Hidden = True
        UltraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn65.Header.Caption = "Komm. Status"
        UltraGridColumn65.Header.VisiblePosition = 10
        UltraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn66.Header.VisiblePosition = 28
        UltraGridColumn66.Hidden = True
        UltraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn67.Header.VisiblePosition = 29
        UltraGridColumn67.Hidden = True
        UltraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn68.Header.VisiblePosition = 30
        UltraGridColumn68.Hidden = True
        UltraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn69.Header.VisiblePosition = 31
        UltraGridColumn69.Hidden = True
        UltraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn70.Header.VisiblePosition = 32
        UltraGridColumn70.Hidden = True
        UltraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn71.Header.VisiblePosition = 33
        UltraGridColumn71.Hidden = True
        UltraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn72.Header.VisiblePosition = 34
        UltraGridColumn72.Hidden = True
        UltraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn73.Header.Caption = "Mail von"
        UltraGridColumn73.Header.VisiblePosition = 7
        UltraGridColumn73.Width = 167
        UltraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn74.Header.Caption = "Gelesen"
        UltraGridColumn74.Header.VisiblePosition = 0
        UltraGridColumn74.Width = 51
        UltraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn75.Header.Caption = "Empfangen am"
        UltraGridColumn75.Header.VisiblePosition = 6
        UltraGridColumn75.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn75.Width = 108
        UltraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn76.Header.VisiblePosition = 35
        UltraGridColumn76.Hidden = True
        UltraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn77.Header.VisiblePosition = 36
        UltraGridColumn77.Hidden = True
        UltraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn78.Header.VisiblePosition = 37
        UltraGridColumn78.Hidden = True
        UltraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn79.Header.VisiblePosition = 38
        UltraGridColumn79.Hidden = True
        UltraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn80.Header.Caption = "Besitzer"
        UltraGridColumn80.Header.VisiblePosition = 9
        UltraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn81.Header.VisiblePosition = 39
        UltraGridColumn81.Hidden = True
        UltraGridColumn82.Header.VisiblePosition = 40
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82})
        Me.gridPlans.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridPlans.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridPlans.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.gridPlans.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.gridPlans.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.ActiveRowAppearance = Appearance4
        Me.gridPlans.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridPlans.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        ValueList1.Key = "IDArt"
        Me.gridPlans.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1})
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanelMitte.SetGridBagConstraint(Me.gridPlans, GridBagConstraint1)
        Me.gridPlans.Location = New System.Drawing.Point(5, 0)
        Me.gridPlans.Name = "gridPlans"
        Me.UltraGridBagLayoutPanelMitte.SetPreferredSize(Me.gridPlans, New System.Drawing.Size(617, 277))
        Me.gridPlans.Size = New System.Drawing.Size(985, 368)
        Me.gridPlans.TabIndex = 0
        Me.gridPlans.Text = "UltraGrid1"
        '
        'DsPlanSearch1
        '
        Me.DsPlanSearch1.DataSetName = "dsPlanSearch"
        Me.DsPlanSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmOffeneTermine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(995, 505)
        Me.Controls.Add(Me.UltraGridBagLayoutPanelMitte)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelUnten)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(893, 475)
        Me.Name = "frmOffeneTermine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Erinnerungsassistent"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUntenREchts.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.udtBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridBagLayoutPanelMitte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelMitte.ResumeLayout(False)
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridPlans As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPlanEntyOpen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblInfo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenREchts As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanelMitte As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents btnEndPlanEntry As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearch As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents DsPlanSearch1 As dsPlanSearch
    Public WithEvents udtBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboArt As contComboSelListGrid
    Friend WithEvents lblArt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpSearch As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboUsers As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblUsers As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblResetSearching As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GruppierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlsExcelExportierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents udtVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AlleAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WechelnZuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InNeuemTabÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LayoutManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
