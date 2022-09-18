<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contUserSelList
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FirstName", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastName", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NameCombination")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsPatient")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsPersonal")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsUser")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Title")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DOB")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Role")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Gender")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Race")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SSN")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsJehova")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KavVidierungPwd")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName", -1, Nothing, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("isAdmin")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserShort")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Domain")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserNameDomain")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsImported")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ExtID")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUserID")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtStat")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtDate")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MTLocatn")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtCause")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ICD9")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatOrigin")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtCauseDescription")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Systemuser")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CongenitalData")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConAntDiag")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConGestAge")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserCode")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ExtIDNr")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MaidenName")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BPKZ")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BPKZ1")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BPKZ2")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblObject_tblObjectRel")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblObject_tblAdress")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selection", 0)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject_tblObjectRel", 0)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObject")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObjectSub")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject_tblAdress", 0)
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CountryID")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZIP")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("City")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Street")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhonePrivat")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhoneBusiness")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhoneMobil")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Web")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fax")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMainAdress")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObject")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contUserSelList))
        Me.gridUsers = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStripGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsObjects1 = New qs2.core.vb.dsObjects()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.btnAbort2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnOK2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.SqlObjects1 = New qs2.core.vb.sqlObjects(Me.components)
        Me.SqlAdmin1 = New qs2.core.vb.sqlAdmin(Me.components)
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        CType(Me.gridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripGrid.SuspendLayout()
        CType(Me.DsObjects1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridUsers
        '
        Me.gridUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridUsers.ContextMenuStrip = Me.ContextMenuStripGrid
        Me.gridUsers.DataMember = "tblObject"
        Me.gridUsers.DataSource = Me.DsObjects1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridUsers.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 16
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 161
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.Caption = "Firstname"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 139
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.Caption = "Lastname"
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Width = 136
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn8.Header.VisiblePosition = 10
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Width = 69
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance2
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance3
        UltraGridColumn10.Header.Caption = "Date of Birth"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 89
        UltraGridColumn11.Header.VisiblePosition = 14
        UltraGridColumn12.Header.VisiblePosition = 17
        UltraGridColumn13.Header.VisiblePosition = 18
        UltraGridColumn14.Header.VisiblePosition = 20
        UltraGridColumn15.Header.VisiblePosition = 22
        UltraGridColumn16.Header.VisiblePosition = 24
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.Header.VisiblePosition = 4
        UltraGridColumn17.Width = 108
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance4
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn18.Header.Appearance = Appearance5
        UltraGridColumn18.Header.VisiblePosition = 15
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 80
        UltraGridColumn19.Header.VisiblePosition = 26
        UltraGridColumn20.Header.VisiblePosition = 27
        UltraGridColumn21.Header.VisiblePosition = 19
        UltraGridColumn21.Width = 99
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.Header.VisiblePosition = 21
        UltraGridColumn22.Width = 133
        UltraGridColumn23.Header.VisiblePosition = 28
        UltraGridColumn24.Header.VisiblePosition = 29
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.Header.VisiblePosition = 13
        UltraGridColumn25.Hidden = True
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn26.CellAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn26.Header.Appearance = Appearance7
        UltraGridColumn26.Header.VisiblePosition = 23
        UltraGridColumn26.Width = 63
        UltraGridColumn27.Header.VisiblePosition = 30
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance8
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn28.Header.Appearance = Appearance9
        UltraGridColumn28.Header.VisiblePosition = 25
        UltraGridColumn28.Width = 99
        UltraGridColumn29.Header.VisiblePosition = 31
        UltraGridColumn30.Header.VisiblePosition = 11
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 24
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn31.CellAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn31.Header.Appearance = Appearance11
        UltraGridColumn31.Header.VisiblePosition = 12
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 38
        UltraGridColumn32.Header.VisiblePosition = 32
        UltraGridColumn33.Header.VisiblePosition = 33
        UltraGridColumn34.Header.VisiblePosition = 34
        UltraGridColumn35.Header.VisiblePosition = 35
        UltraGridColumn36.Header.VisiblePosition = 36
        UltraGridColumn37.Header.VisiblePosition = 37
        UltraGridColumn38.Header.VisiblePosition = 38
        UltraGridColumn39.Header.VisiblePosition = 39
        UltraGridColumn40.Header.VisiblePosition = 40
        UltraGridColumn41.Header.VisiblePosition = 41
        UltraGridColumn42.Header.VisiblePosition = 42
        UltraGridColumn43.Header.VisiblePosition = 43
        UltraGridColumn44.Header.VisiblePosition = 44
        UltraGridColumn45.Header.VisiblePosition = 45
        UltraGridColumn46.Header.VisiblePosition = 46
        UltraGridColumn65.Header.VisiblePosition = 47
        UltraGridColumn66.Header.VisiblePosition = 48
        UltraGridColumn47.Header.VisiblePosition = 49
        UltraGridColumn48.Header.VisiblePosition = 50
        UltraGridColumn67.DataType = GetType(Boolean)
        UltraGridColumn67.Header.VisiblePosition = 0
        UltraGridColumn67.Width = 71
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn65, UltraGridColumn66, UltraGridColumn47, UltraGridColumn48, UltraGridColumn67})
        UltraGridColumn49.Header.VisiblePosition = 0
        UltraGridColumn50.Header.VisiblePosition = 1
        UltraGridColumn51.Header.VisiblePosition = 2
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn49, UltraGridColumn50, UltraGridColumn51})
        UltraGridBand2.Hidden = True
        UltraGridColumn52.Header.VisiblePosition = 0
        UltraGridColumn53.Header.VisiblePosition = 1
        UltraGridColumn54.Header.VisiblePosition = 2
        UltraGridColumn55.Header.VisiblePosition = 3
        UltraGridColumn56.Header.VisiblePosition = 4
        UltraGridColumn57.Header.VisiblePosition = 5
        UltraGridColumn58.Header.VisiblePosition = 6
        UltraGridColumn59.Header.VisiblePosition = 7
        UltraGridColumn60.Header.VisiblePosition = 8
        UltraGridColumn61.Header.VisiblePosition = 9
        UltraGridColumn62.Header.VisiblePosition = 10
        UltraGridColumn63.Header.VisiblePosition = 11
        UltraGridColumn64.Header.VisiblePosition = 12
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64})
        UltraGridBand3.Hidden = True
        Me.gridUsers.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridUsers.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridUsers.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridUsers.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridUsers.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.gridUsers.DisplayLayout.GroupByBox.Appearance = Appearance12
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridUsers.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
        Me.gridUsers.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance14.BackColor2 = System.Drawing.SystemColors.Control
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridUsers.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
        Me.gridUsers.DisplayLayout.MaxColScrollRegions = 1
        Me.gridUsers.DisplayLayout.MaxRowScrollRegions = 1
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridUsers.DisplayLayout.Override.ActiveCellAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.SystemColors.Highlight
        Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridUsers.DisplayLayout.Override.ActiveRowAppearance = Appearance16
        Me.gridUsers.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridUsers.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Me.gridUsers.DisplayLayout.Override.CardAreaAppearance = Appearance17
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridUsers.DisplayLayout.Override.CellAppearance = Appearance18
        Me.gridUsers.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridUsers.DisplayLayout.Override.CellPadding = 0
        Appearance19.BackColor = System.Drawing.SystemColors.Control
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.gridUsers.DisplayLayout.Override.GroupByRowAppearance = Appearance19
        Appearance20.TextHAlignAsString = "Left"
        Me.gridUsers.DisplayLayout.Override.HeaderAppearance = Appearance20
        Me.gridUsers.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridUsers.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Me.gridUsers.DisplayLayout.Override.RowAppearance = Appearance21
        Me.gridUsers.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridUsers.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridUsers.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridUsers.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridUsers.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridUsers.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
        Me.gridUsers.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridUsers.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridUsers.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridUsers.Location = New System.Drawing.Point(6, 7)
        Me.gridUsers.Name = "gridUsers"
        Me.gridUsers.Size = New System.Drawing.Size(686, 565)
        Me.gridUsers.TabIndex = 11
        Me.gridUsers.Text = "UltraGrid1"
        '
        'ContextMenuStripGrid
        '
        Me.ContextMenuStripGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem})
        Me.ContextMenuStripGrid.Name = "ContextMenuStripGrid"
        Me.ContextMenuStripGrid.Size = New System.Drawing.Size(136, 48)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select all"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Select none"
        '
        'DsObjects1
        '
        Me.DsObjects1.DataSetName = "dsObjects"
        Me.DsObjects1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        Me.UltraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info
        '
        'btnAbort2
        '
        Me.btnAbort2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance23.TextVAlignAsString = "Middle"
        Me.btnAbort2.Appearance = Appearance23
        Me.btnAbort2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbort2.Location = New System.Drawing.Point(344, 577)
        Me.btnAbort2.Name = "btnAbort2"
        Me.btnAbort2.OwnAutoTextYN = False
        Me.btnAbort2.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnAbort2.OwnPictureTxt = ""
        Me.btnAbort2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnAbort2.OwnTooltipText = ""
        Me.btnAbort2.OwnTooltipTitle = Nothing
        Me.btnAbort2.Size = New System.Drawing.Size(72, 30)
        Me.btnAbort2.TabIndex = 15
        Me.btnAbort2.Text = "Cancel"
        '
        'btnOK2
        '
        Me.btnOK2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.Image = CType(resources.GetObject("Appearance24.Image"), Object)
        Appearance24.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance24.TextVAlignAsString = "Middle"
        Me.btnOK2.Appearance = Appearance24
        Me.btnOK2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK2.Location = New System.Drawing.Point(281, 577)
        Me.btnOK2.Name = "btnOK2"
        Me.btnOK2.OwnAutoTextYN = True
        Me.btnOK2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_OK
        Me.btnOK2.OwnPictureTxt = ""
        Me.btnOK2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnOK2.OwnTooltipText = ""
        Me.btnOK2.OwnTooltipTitle = Nothing
        Me.btnOK2.Size = New System.Drawing.Size(62, 30)
        Me.btnOK2.TabIndex = 14
        Me.btnOK2.Text = "Ok"
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAdmin"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'contUserSelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnAbort2)
        Me.Controls.Add(Me.btnOK2)
        Me.Controls.Add(Me.gridUsers)
        Me.Name = "contUserSelList"
        Me.Size = New System.Drawing.Size(697, 613)
        CType(Me.gridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripGrid.ResumeLayout(False)
        CType(Me.DsObjects1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridUsers As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents DsObjects1 As core.vb.dsObjects
    Private WithEvents btnAbort2 As ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnOK2 As ownControls.inherit_Infrag.InfragButton
    Friend WithEvents SqlObjects1 As core.vb.sqlObjects
    Friend WithEvents ContextMenuStripGrid As Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SqlAdmin1 As core.vb.sqlAdmin
    Friend WithEvents DsAdmin1 As core.vb.dsAdmin
End Class
