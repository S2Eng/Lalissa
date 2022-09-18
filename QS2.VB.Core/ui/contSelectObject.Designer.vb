<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelectObject
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject", -1)
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FirstName", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastName", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NameCombination")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsPatient")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsPersonal")
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsUser")
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Title")
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DOB")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Role")
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Gender")
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Race")
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SSN")
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsJehova")
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KavVidierungPwd")
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName")
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("isAdmin")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserShort")
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn145 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Domain")
        Dim UltraGridColumn146 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserNameDomain")
        Dim UltraGridColumn147 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsImported")
        Dim UltraGridColumn148 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ExtID")
        Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUserID")
        Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtStat")
        Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtDate")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MTLocatn")
        Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtCause")
        Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ICD9")
        Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatOrigin")
        Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MtCauseDescription")
        Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Systemuser")
        Dim UltraGridColumn164 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CongenitalData")
        Dim UltraGridColumn165 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConAntDiag")
        Dim UltraGridColumn166 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConGestAge")
        Dim UltraGridColumn167 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserCode")
        Dim UltraGridColumn168 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ExtIDNr")
        Dim UltraGridColumn169 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblObject_tblObjectRel")
        Dim UltraGridColumn170 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblObject_tblAdress")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZIP", 0)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("City", 1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Street", 2)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject_tblObjectRel", 0)
        Dim UltraGridColumn171 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn172 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObject")
        Dim UltraGridColumn173 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObjectSub")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblObject_tblAdress", 0)
        Dim UltraGridColumn174 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn175 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CountryID")
        Dim UltraGridColumn176 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZIP")
        Dim UltraGridColumn177 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("City")
        Dim UltraGridColumn178 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Street")
        Dim UltraGridColumn179 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhonePrivat")
        Dim UltraGridColumn180 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhoneBusiness")
        Dim UltraGridColumn181 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PhoneMobil")
        Dim UltraGridColumn182 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail")
        Dim UltraGridColumn183 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Web")
        Dim UltraGridColumn184 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fax")
        Dim UltraGridColumn185 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMainAdress")
        Dim UltraGridColumn186 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuidObject")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnNewObject = New Infragistics.Win.Misc.UltraButton()
        Me.PanelCenter = New Infragistics.Win.Misc.UltraPanel()
        Me.grpNewObject = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnAbort2 = New Infragistics.Win.Misc.UltraButton()
        Me.txtPhonePrivat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblPhonePrivate = New Infragistics.Win.Misc.UltraLabel()
        Me.cboRace = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblRace = New Infragistics.Win.Misc.UltraLabel()
        Me.udteDOB = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDOB = New Infragistics.Win.Misc.UltraLabel()
        Me.cboGender = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cboCountry = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.txtZIP = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtStreet = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtSSN = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtLastNameU = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtFirstNameU = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCountry = New Infragistics.Win.Misc.UltraLabel()
        Me.lblStreet = New Infragistics.Win.Misc.UltraLabel()
        Me.lblCity = New Infragistics.Win.Misc.UltraLabel()
        Me.lblZIP = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGender = New Infragistics.Win.Misc.UltraLabel()
        Me.lblSSN = New Infragistics.Win.Misc.UltraLabel()
        Me.lblLastNameU = New Infragistics.Win.Misc.UltraLabel()
        Me.lblFirstNameU = New Infragistics.Win.Misc.UltraLabel()
        Me.gridObjects = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsObjects1 = New qs2.core.vb.dsObjects()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SqlObjects1 = New qs2.core.vb.sqlObjects(Me.components)
        Me.PanelCenter.ClientArea.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        CType(Me.grpNewObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNewObject.SuspendLayout()
        CType(Me.txtPhonePrivat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udteDOB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtZIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStreet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSSN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastNameU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstNameU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridObjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsObjects1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(380, 182)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 27)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbort.Location = New System.Drawing.Point(447, 182)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(67, 27)
        Me.btnAbort.TabIndex = 18
        Me.btnAbort.Text = "Abort"
        '
        'btnNewObject
        '
        Me.btnNewObject.Location = New System.Drawing.Point(343, 140)
        Me.btnNewObject.Name = "btnNewObject"
        Me.btnNewObject.Size = New System.Drawing.Size(229, 27)
        Me.btnNewObject.TabIndex = 20
        Me.btnNewObject.Text = "Create and take new Patient"
        '
        'PanelCenter
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenter.Appearance = Appearance1
        '
        'PanelCenter.ClientArea
        '
        Me.PanelCenter.ClientArea.Controls.Add(Me.btnOK)
        Me.PanelCenter.ClientArea.Controls.Add(Me.btnAbort)
        Me.PanelCenter.ClientArea.Controls.Add(Me.grpNewObject)
        Me.PanelCenter.ClientArea.Controls.Add(Me.gridObjects)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 0)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(904, 215)
        Me.PanelCenter.TabIndex = 30
        '
        'grpNewObject
        '
        Me.grpNewObject.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.grpNewObject.Appearance = Appearance2
        Me.grpNewObject.Controls.Add(Me.btnAbort2)
        Me.grpNewObject.Controls.Add(Me.txtPhonePrivat)
        Me.grpNewObject.Controls.Add(Me.lblPhonePrivate)
        Me.grpNewObject.Controls.Add(Me.cboRace)
        Me.grpNewObject.Controls.Add(Me.lblRace)
        Me.grpNewObject.Controls.Add(Me.udteDOB)
        Me.grpNewObject.Controls.Add(Me.lblDOB)
        Me.grpNewObject.Controls.Add(Me.cboGender)
        Me.grpNewObject.Controls.Add(Me.cboCountry)
        Me.grpNewObject.Controls.Add(Me.txtZIP)
        Me.grpNewObject.Controls.Add(Me.txtCity)
        Me.grpNewObject.Controls.Add(Me.txtStreet)
        Me.grpNewObject.Controls.Add(Me.txtSSN)
        Me.grpNewObject.Controls.Add(Me.txtLastNameU)
        Me.grpNewObject.Controls.Add(Me.txtFirstNameU)
        Me.grpNewObject.Controls.Add(Me.lblCountry)
        Me.grpNewObject.Controls.Add(Me.lblStreet)
        Me.grpNewObject.Controls.Add(Me.lblCity)
        Me.grpNewObject.Controls.Add(Me.lblZIP)
        Me.grpNewObject.Controls.Add(Me.lblGender)
        Me.grpNewObject.Controls.Add(Me.lblSSN)
        Me.grpNewObject.Controls.Add(Me.lblLastNameU)
        Me.grpNewObject.Controls.Add(Me.lblFirstNameU)
        Me.grpNewObject.Controls.Add(Me.btnNewObject)
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 9.5!
        Me.grpNewObject.HeaderAppearance = Appearance4
        Me.grpNewObject.Location = New System.Drawing.Point(6, 6)
        Me.grpNewObject.Name = "grpNewObject"
        Me.grpNewObject.Size = New System.Drawing.Size(893, 203)
        Me.grpNewObject.TabIndex = 5
        Me.grpNewObject.Text = "Creating a new object"
        '
        'btnAbort2
        '
        Me.btnAbort2.Location = New System.Drawing.Point(573, 140)
        Me.btnAbort2.Name = "btnAbort2"
        Me.btnAbort2.Size = New System.Drawing.Size(67, 27)
        Me.btnAbort2.TabIndex = 63
        Me.btnAbort2.Text = "Abort"
        '
        'txtPhonePrivat
        '
        Me.txtPhonePrivat.Location = New System.Drawing.Point(6, 146)
        Me.txtPhonePrivat.Name = "txtPhonePrivat"
        Me.txtPhonePrivat.Size = New System.Drawing.Size(211, 21)
        Me.txtPhonePrivat.TabIndex = 10
        '
        'lblPhonePrivate
        '
        Me.lblPhonePrivate.Location = New System.Drawing.Point(6, 132)
        Me.lblPhonePrivate.Name = "lblPhonePrivate"
        Me.lblPhonePrivate.Size = New System.Drawing.Size(135, 18)
        Me.lblPhonePrivate.TabIndex = 62
        Me.lblPhonePrivate.Text = "Phone private"
        '
        'cboRace
        '
        Me.cboRace.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboRace.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboRace.Location = New System.Drawing.Point(62, 73)
        Me.cboRace.Name = "cboRace"
        Me.cboRace.Size = New System.Drawing.Size(155, 21)
        Me.cboRace.TabIndex = 5
        '
        'lblRace
        '
        Me.lblRace.Location = New System.Drawing.Point(62, 61)
        Me.lblRace.Name = "lblRace"
        Me.lblRace.Size = New System.Drawing.Size(115, 14)
        Me.lblRace.TabIndex = 60
        Me.lblRace.Text = "Race"
        '
        'udteDOB
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Me.udteDOB.Appearance = Appearance3
        Me.udteDOB.BackColor = System.Drawing.Color.White
        Me.udteDOB.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.udteDOB.Location = New System.Drawing.Point(434, 35)
        Me.udteDOB.Name = "udteDOB"
        Me.udteDOB.Size = New System.Drawing.Size(88, 21)
        Me.udteDOB.TabIndex = 2
        '
        'lblDOB
        '
        Me.lblDOB.Location = New System.Drawing.Point(434, 21)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(80, 18)
        Me.lblDOB.TabIndex = 58
        Me.lblDOB.Text = "DOB"
        '
        'cboGender
        '
        Me.cboGender.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboGender.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboGender.Location = New System.Drawing.Point(526, 35)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(114, 21)
        Me.cboGender.TabIndex = 3
        '
        'cboCountry
        '
        Me.cboCountry.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboCountry.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboCountry.Location = New System.Drawing.Point(6, 110)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(211, 21)
        Me.cboCountry.TabIndex = 6
        '
        'txtZIP
        '
        Me.txtZIP.Location = New System.Drawing.Point(220, 110)
        Me.txtZIP.Name = "txtZIP"
        Me.txtZIP.Size = New System.Drawing.Size(57, 21)
        Me.txtZIP.TabIndex = 7
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(280, 110)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(151, 21)
        Me.txtCity.TabIndex = 8
        '
        'txtStreet
        '
        Me.txtStreet.Location = New System.Drawing.Point(434, 110)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(206, 21)
        Me.txtStreet.TabIndex = 9
        '
        'txtSSN
        '
        Me.txtSSN.Location = New System.Drawing.Point(6, 73)
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.Size = New System.Drawing.Size(53, 21)
        Me.txtSSN.TabIndex = 4
        '
        'txtLastNameU
        '
        Me.txtLastNameU.Location = New System.Drawing.Point(6, 35)
        Me.txtLastNameU.Name = "txtLastNameU"
        Me.txtLastNameU.Size = New System.Drawing.Size(211, 21)
        Me.txtLastNameU.TabIndex = 0
        '
        'txtFirstNameU
        '
        Me.txtFirstNameU.Location = New System.Drawing.Point(220, 35)
        Me.txtFirstNameU.Name = "txtFirstNameU"
        Me.txtFirstNameU.Size = New System.Drawing.Size(211, 21)
        Me.txtFirstNameU.TabIndex = 1
        '
        'lblCountry
        '
        Me.lblCountry.Location = New System.Drawing.Point(6, 96)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(134, 18)
        Me.lblCountry.TabIndex = 53
        Me.lblCountry.Text = "Country"
        '
        'lblStreet
        '
        Me.lblStreet.Location = New System.Drawing.Point(434, 96)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(165, 18)
        Me.lblStreet.TabIndex = 56
        Me.lblStreet.Text = "Street"
        '
        'lblCity
        '
        Me.lblCity.Location = New System.Drawing.Point(280, 96)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(97, 18)
        Me.lblCity.TabIndex = 55
        Me.lblCity.Text = "City"
        '
        'lblZIP
        '
        Me.lblZIP.Location = New System.Drawing.Point(220, 96)
        Me.lblZIP.Name = "lblZIP"
        Me.lblZIP.Size = New System.Drawing.Size(53, 18)
        Me.lblZIP.TabIndex = 54
        Me.lblZIP.Text = "ZIP"
        '
        'lblGender
        '
        Me.lblGender.Location = New System.Drawing.Point(526, 21)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(85, 18)
        Me.lblGender.TabIndex = 48
        Me.lblGender.Text = "Gender"
        '
        'lblSSN
        '
        Me.lblSSN.Location = New System.Drawing.Point(6, 59)
        Me.lblSSN.Name = "lblSSN"
        Me.lblSSN.Size = New System.Drawing.Size(38, 19)
        Me.lblSSN.TabIndex = 46
        Me.lblSSN.Text = "SSN"
        '
        'lblLastNameU
        '
        Me.lblLastNameU.Location = New System.Drawing.Point(6, 21)
        Me.lblLastNameU.Name = "lblLastNameU"
        Me.lblLastNameU.Size = New System.Drawing.Size(135, 18)
        Me.lblLastNameU.TabIndex = 43
        Me.lblLastNameU.Text = "Last Name"
        '
        'lblFirstNameU
        '
        Me.lblFirstNameU.Location = New System.Drawing.Point(220, 21)
        Me.lblFirstNameU.Name = "lblFirstNameU"
        Me.lblFirstNameU.Size = New System.Drawing.Size(135, 18)
        Me.lblFirstNameU.TabIndex = 44
        Me.lblFirstNameU.Text = "First Name"
        '
        'gridObjects
        '
        Me.gridObjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridObjects.DataMember = "tblObject"
        Me.gridObjects.DataSource = Me.DsObjects1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridObjects.DisplayLayout.Appearance = Appearance5
        UltraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn125.Header.VisiblePosition = 0
        UltraGridColumn125.Hidden = True
        UltraGridColumn126.Header.VisiblePosition = 15
        UltraGridColumn126.Hidden = True
        UltraGridColumn126.Width = 161
        UltraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn127.Header.Caption = "Firstname"
        UltraGridColumn127.Header.VisiblePosition = 3
        UltraGridColumn127.Width = 99
        UltraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn128.Header.Caption = "Lastname"
        UltraGridColumn128.Header.VisiblePosition = 2
        UltraGridColumn128.Width = 172
        UltraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn129.Header.VisiblePosition = 5
        UltraGridColumn129.Hidden = True
        UltraGridColumn130.Header.VisiblePosition = 6
        UltraGridColumn130.Hidden = True
        UltraGridColumn131.Header.VisiblePosition = 7
        UltraGridColumn131.Hidden = True
        UltraGridColumn132.Header.VisiblePosition = 9
        UltraGridColumn132.Hidden = True
        UltraGridColumn133.Header.VisiblePosition = 4
        UltraGridColumn133.Width = 59
        UltraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn134.CellAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn134.Header.Appearance = Appearance7
        UltraGridColumn134.Header.Caption = "Date of Birth"
        UltraGridColumn134.Header.VisiblePosition = 8
        UltraGridColumn134.Width = 91
        UltraGridColumn135.Header.VisiblePosition = 13
        UltraGridColumn135.Hidden = True
        UltraGridColumn136.Header.VisiblePosition = 16
        UltraGridColumn136.Hidden = True
        UltraGridColumn137.Header.VisiblePosition = 17
        UltraGridColumn137.Hidden = True
        UltraGridColumn138.Header.VisiblePosition = 19
        UltraGridColumn138.Hidden = True
        UltraGridColumn139.Header.VisiblePosition = 21
        UltraGridColumn139.Hidden = True
        UltraGridColumn140.Header.VisiblePosition = 23
        UltraGridColumn140.Hidden = True
        UltraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn141.Header.VisiblePosition = 1
        UltraGridColumn141.Hidden = True
        UltraGridColumn141.Width = 119
        UltraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn142.CellAppearance = Appearance8
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn142.Header.Appearance = Appearance9
        UltraGridColumn142.Header.VisiblePosition = 14
        UltraGridColumn142.Hidden = True
        UltraGridColumn142.Width = 80
        UltraGridColumn143.Header.VisiblePosition = 25
        UltraGridColumn143.Hidden = True
        UltraGridColumn144.Header.VisiblePosition = 26
        UltraGridColumn144.Hidden = True
        UltraGridColumn145.Header.VisiblePosition = 18
        UltraGridColumn145.Hidden = True
        UltraGridColumn145.Width = 99
        UltraGridColumn146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn146.Header.VisiblePosition = 20
        UltraGridColumn146.Hidden = True
        UltraGridColumn146.Width = 133
        UltraGridColumn147.Header.VisiblePosition = 27
        UltraGridColumn147.Hidden = True
        UltraGridColumn148.Header.VisiblePosition = 28
        UltraGridColumn148.Hidden = True
        UltraGridColumn149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn149.Header.VisiblePosition = 12
        UltraGridColumn149.Hidden = True
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn150.CellAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn150.Header.Appearance = Appearance11
        UltraGridColumn150.Header.VisiblePosition = 22
        UltraGridColumn150.Hidden = True
        UltraGridColumn150.Width = 63
        UltraGridColumn151.Header.VisiblePosition = 29
        UltraGridColumn151.Hidden = True
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn152.CellAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn152.Header.Appearance = Appearance13
        UltraGridColumn152.Header.VisiblePosition = 24
        UltraGridColumn152.Width = 79
        UltraGridColumn153.Header.VisiblePosition = 30
        UltraGridColumn153.Hidden = True
        UltraGridColumn154.Header.VisiblePosition = 10
        UltraGridColumn154.Hidden = True
        UltraGridColumn154.Width = 24
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn155.CellAppearance = Appearance14
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn155.Header.Appearance = Appearance15
        UltraGridColumn155.Header.VisiblePosition = 11
        UltraGridColumn155.Hidden = True
        UltraGridColumn155.Width = 38
        UltraGridColumn156.Header.VisiblePosition = 31
        UltraGridColumn156.Hidden = True
        UltraGridColumn157.Header.VisiblePosition = 32
        UltraGridColumn157.Hidden = True
        UltraGridColumn158.Header.VisiblePosition = 33
        UltraGridColumn158.Hidden = True
        UltraGridColumn159.Header.VisiblePosition = 34
        UltraGridColumn159.Hidden = True
        UltraGridColumn160.Header.VisiblePosition = 35
        UltraGridColumn160.Hidden = True
        UltraGridColumn161.Header.VisiblePosition = 36
        UltraGridColumn161.Hidden = True
        UltraGridColumn162.Header.VisiblePosition = 37
        UltraGridColumn162.Hidden = True
        UltraGridColumn163.Header.VisiblePosition = 38
        UltraGridColumn163.Hidden = True
        UltraGridColumn164.Header.VisiblePosition = 39
        UltraGridColumn164.Hidden = True
        UltraGridColumn165.Header.VisiblePosition = 40
        UltraGridColumn165.Hidden = True
        UltraGridColumn166.Header.VisiblePosition = 41
        UltraGridColumn166.Hidden = True
        UltraGridColumn167.Header.VisiblePosition = 42
        UltraGridColumn167.Hidden = True
        UltraGridColumn168.Header.VisiblePosition = 43
        UltraGridColumn168.Hidden = True
        UltraGridColumn169.Header.VisiblePosition = 47
        UltraGridColumn170.Header.VisiblePosition = 48
        UltraGridColumn1.Header.VisiblePosition = 44
        UltraGridColumn1.Width = 71
        UltraGridColumn2.Header.VisiblePosition = 45
        UltraGridColumn2.Width = 133
        UltraGridColumn3.Header.VisiblePosition = 46
        UltraGridColumn3.Width = 220
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn133, UltraGridColumn134, UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138, UltraGridColumn139, UltraGridColumn140, UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn145, UltraGridColumn146, UltraGridColumn147, UltraGridColumn148, UltraGridColumn149, UltraGridColumn150, UltraGridColumn151, UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn162, UltraGridColumn163, UltraGridColumn164, UltraGridColumn165, UltraGridColumn166, UltraGridColumn167, UltraGridColumn168, UltraGridColumn169, UltraGridColumn170, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        UltraGridColumn171.Header.VisiblePosition = 0
        UltraGridColumn172.Header.VisiblePosition = 1
        UltraGridColumn173.Header.VisiblePosition = 2
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn171, UltraGridColumn172, UltraGridColumn173})
        UltraGridBand2.Hidden = True
        UltraGridColumn174.Header.VisiblePosition = 0
        UltraGridColumn175.Header.VisiblePosition = 1
        UltraGridColumn176.Header.VisiblePosition = 2
        UltraGridColumn177.Header.VisiblePosition = 3
        UltraGridColumn178.Header.VisiblePosition = 4
        UltraGridColumn179.Header.VisiblePosition = 5
        UltraGridColumn180.Header.VisiblePosition = 6
        UltraGridColumn181.Header.VisiblePosition = 7
        UltraGridColumn182.Header.VisiblePosition = 8
        UltraGridColumn183.Header.VisiblePosition = 9
        UltraGridColumn184.Header.VisiblePosition = 10
        UltraGridColumn185.Header.VisiblePosition = 11
        UltraGridColumn186.Header.VisiblePosition = 12
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn174, UltraGridColumn175, UltraGridColumn176, UltraGridColumn177, UltraGridColumn178, UltraGridColumn179, UltraGridColumn180, UltraGridColumn181, UltraGridColumn182, UltraGridColumn183, UltraGridColumn184, UltraGridColumn185, UltraGridColumn186})
        UltraGridBand3.Hidden = True
        Me.gridObjects.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridObjects.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridObjects.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridObjects.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridObjects.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.gridObjects.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridObjects.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.gridObjects.DisplayLayout.MaxColScrollRegions = 1
        Me.gridObjects.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridObjects.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridObjects.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.gridObjects.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridObjects.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridObjects.DisplayLayout.Override.CellAppearance = Appearance22
        Me.gridObjects.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridObjects.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.gridObjects.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.gridObjects.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.gridObjects.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridObjects.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.gridObjects.DisplayLayout.Override.RowAppearance = Appearance25
        Me.gridObjects.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridObjects.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridObjects.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridObjects.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridObjects.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridObjects.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.gridObjects.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridObjects.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridObjects.Font = New System.Drawing.Font("Segoe UI", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridObjects.Location = New System.Drawing.Point(6, 3)
        Me.gridObjects.Name = "gridObjects"
        Me.gridObjects.Size = New System.Drawing.Size(893, 175)
        Me.gridObjects.TabIndex = 1
        Me.gridObjects.Text = "Patients found in Database"
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
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAdmin"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'contSelectObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PanelCenter)
        Me.Name = "contSelectObject"
        Me.Size = New System.Drawing.Size(904, 215)
        Me.PanelCenter.ClientArea.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        CType(Me.grpNewObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNewObject.ResumeLayout(False)
        Me.grpNewObject.PerformLayout()
        CType(Me.txtPhonePrivat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udteDOB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtZIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStreet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSSN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastNameU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstNameU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridObjects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsObjects1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelCenter As Infragistics.Win.Misc.UltraPanel
    Private WithEvents btnNewObject As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents gridObjects As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents DsObjects1 As qs2.core.vb.dsObjects
    Public WithEvents SqlObjects1 As qs2.core.vb.sqlObjects
    Friend WithEvents grpNewObject As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents txtLastNameU As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtFirstNameU As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblLastNameU As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblFirstNameU As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtSSN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSSN As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboGender As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblGender As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin
    Public WithEvents cboCountry As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents txtZIP As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtStreet As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblCountry As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblStreet As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblCity As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblZIP As Infragistics.Win.Misc.UltraLabel
    Public WithEvents udteDOB As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDOB As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents cboRace As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblRace As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtPhonePrivat As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPhonePrivate As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnAbort2 As Infragistics.Win.Misc.UltraButton

End Class
