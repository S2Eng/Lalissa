Imports qs2.core.vb


Public Class contObject


    Public typSearch As New qs2.core.vb.sqlObjects.eTypObj()
    Public isNew As Boolean = False

    Public sqlObjects1 As New qs2.core.vb.sqlObjects()
    Public sqlAdmin1 As New qs2.core.vb.sqlAdmin()
    Public funct1 As New qs2.core.vb.funct()
    Public Encryption1 As New qs2.license.core.Encryption()

    Public rObjLoaded As dsObjects.tblObjectRow

    Public isLoaded As Boolean = False
    Public ProtocollManager As Protocol = Nothing

    Public _IsInEditMode As Boolean = False

    Public doUI1 As New qs2.core.vb.doUI()

    Public lockToolBar As Boolean = False
    Public _OwnIsEmbedded As Boolean = False

    Public ExtIDChangedByUser As Boolean = False

    Public businessFramework1 As New qs2.core.db.ERSystem.businessFramework()







    Private Sub usrObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.ContSearchObjects1.txtSearch.Focus()


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            If Not Me._OwnIsEmbedded Then
                Me.sqlObjects1.initControl()
            End If

            Me.sqlAdmin1.initControl()
            Me.resetProtocoll()

            Me.loadRes()

            'Me.txtLastName.UseAppStyling = False
            'Me.udteDOB.UseAppStyling = False
            'Me.txtLastName.Appearance.BackColor = qs2.core.Colors.backColImportantFields
            'Me.txtLastName.Appearance.BackColorDisabled = qs2.core.Colors.backColImportantFields
            'Me.txtLastName.Appearance.ForeColor = System.Drawing.Color.Black
            'Me.txtLastName.Appearance.ForeColorDisabled = System.Drawing.Color.Black

            'Me.udteDOB.Appearance.BackColor = qs2.core.Colors.backColImportantFields
            'Me.udteDOB.Appearance.BackColorDisabled = qs2.core.Colors.backColImportantFields
            'Me.udteDOB.Appearance.ForeColor = System.Drawing.Color.Black
            'Me.udteDOB.Appearance.ForeColorDisabled = System.Drawing.Color.Black

            'Me.txtLastNameU.UseAppStyling = False
            'Me.txtLastNameU.Appearance.BackColor = qs2.core.Colors.backColImportantFields
            'Me.txtLastNameU.Appearance.BackColorDisabled = qs2.core.Colors.backColImportantFields
            'Me.txtLastNameU.Appearance.ForeColor = System.Drawing.Color.Black
            'Me.txtLastNameU.Appearance.ForeColorDisabled = System.Drawing.Color.Black

            Dim dsAdmin1 As New dsAdmin()
            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then

                Me.tabObjectBottom.Tabs("Adress").Visible = True
                Me.tabObjectBottom.Tabs("OtherData").Visible = True

                Me.tabObjectBottom.Tabs("Represents").Visible = False
                Me.tabObjectBottom.Tabs("UsergroupsAndRights").Visible = False
                Me.tabObjectBottom.Tabs("Rights").Visible = False
                Me.tabObjectBottom.Tabs("Roles").Visible = False
                Me.tabObjectBottom.Tabs("SettingsUser").Visible = False
                Me.tabObjectBottom.Tabs("Products").Visible = False
                Me.tabObjectBottom.Tabs("Classification").Visible = False

                Me.grpUser.Visible = False
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboGender, "Gender", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboCountry, "CountryID", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)

                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboMtStat, "MtStat", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboMtCause, "MtCause", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboMTLocatn, "MTLocatn", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)

                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboRace, "Race", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)

                Me.tabObjectBottom.ActiveTab = Me.tabObjectBottom.Tabs("Adress")
                Me.showTab("Adress")

            ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
                Me.grpPatientData.Visible = False

                Me.tabObjectBottom.Tabs("Adress").Visible = True
                Me.tabObjectBottom.Tabs("OtherData").Visible = False
                Me.tabObjectBottom.Tabs("Products").Visible = True

                Me.tabObjectBottom.Tabs("Represents").Visible = True
                Me.tabObjectBottom.Tabs("UsergroupsAndRights").Visible = True
                Me.tabObjectBottom.Tabs("Rights").Visible = True
                Me.tabObjectBottom.Tabs("Roles").Visible = True
                Me.tabObjectBottom.Tabs("SettingsUser").Visible = True
                Me.tabObjectBottom.Tabs("Classification").Visible = True

                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboCountry, "CountryID", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)

                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboRace, "Race", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.group)

                Me.ContObjectRepresents.initControl()

                Me.ContSelListsObjRightsUsergroups.typDB = sqlAdmin.eDbTypAuswObj.Usergroups
                Me.ContSelListsObjRightsUsergroups.grpToLoad = "Usergroups"
                Me.ContSelListsObjRightsUsergroups.typ = qs2.sitemap.vb.contSelListsObj.eTyp.savedForObject
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.ContSelListsObjRightsUsergroups.OpenSelListObjToolStripMenuItem.Visible = True
                Else
                    Me.ContSelListsObjRightsUsergroups.OpenSelListObjToolStripMenuItem.Visible = qs2.core.vb.actUsr.rUsr.isAdmin
                End If

                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin Then
                    Me.ContSelListsObjRightsUsergroups.OpenSelListToolStripMenuItem.Visible = True
                Else
                    Me.ContSelListsObjRightsUsergroups.OpenSelListToolStripMenuItem.Visible = False
                End If

                Me.ContSelListsObjRightsUsergroups.SubListObjToLoad = "Right"
                Me.ContSelListsObjRightsUsergroups.OpenSelListObj2ToolStripMenuItem.Visible = False           'qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()
                Me.ContSelListsObjRightsUsergroups.OpenSelListObjToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("AssignRightsToGroup")
                Me.ContSelListsObjRightsUsergroups.IDApplicationToAssignForSublists = qs2.core.license.doLicense.eApp.ALL.ToString()
                Me.ContSelListsObjRightsUsergroups.initControl(Infragistics.Win.DefaultableBoolean.False, "", False, False, New ArrayList(), Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns,
                                                     qs2.sitemap.vb.contSelListsObj.eTypUI.normal, False,
                                                     qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.rParticipant.IDParticipant)

                Me.ContSelListsObjRightsUsergroups.OpenSelListToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("EditUserGroup")


                Me.ContSelListsObjRights.typDB = sqlAdmin.eDbTypAuswObj.Userrights
                Me.ContSelListsObjRights.grpToLoad = "Right"
                Me.ContSelListsObjRights.typ = qs2.sitemap.vb.contSelListsObj.eTyp.savedForObject
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.ContSelListsObjRights.OpenSelListObjToolStripMenuItem.Visible = True
                Else
                    Me.ContSelListsObjRights.OpenSelListObjToolStripMenuItem.Visible = qs2.core.vb.actUsr.rUsr.isAdmin
                End If

                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin Then
                    Me.ContSelListsObjRights.OpenSelListToolStripMenuItem.Visible = True
                Else
                    Me.ContSelListsObjRights.OpenSelListToolStripMenuItem.Visible = False
                End If

                Me.ContSelListsObjRights.SubListObjToLoad = ""
                Me.ContSelListsObjRights.OpenSelListObj2ToolStripMenuItem.Visible = False           'qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()
                Me.ContSelListsObjRights.OpenSelListObjToolStripMenuItem.Text = ""  'qs2.core.language.sqlLanguage.getRes("AssignRightsToGroup")
                'Me.ContSelListsObjRights.IDApplicationToAssignForSublists = qs2.core.license.doLicense.eApp.ALL.ToString()
                Me.ContSelListsObjRights.initControl(Infragistics.Win.DefaultableBoolean.False, "", False, False, New ArrayList(), Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns,
                                                     qs2.sitemap.vb.contSelListsObj.eTypUI.normal, False,
                                                     qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.rParticipant.IDParticipant)

                'Me.ContSelListsObjRights.OpenSelListToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("EditUserGroup")

                Me.ContSelListsObjRules.IDApplicationToAssignForSublists = qs2.core.license.doLicense.rApplication.IDApplication.Trim()
                Me.ContSelListsObjRules.IDParticipantToAssignForSublists = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                Me.ContSelListsObjRules.typDB = sqlAdmin.eDbTypAuswObj.Roles
                Me.ContSelListsObjRules.grpToLoad = "Roles"

                Me.ContSelListsObjRules.SubListObjToLoad = qs2.core.db.ERSystem.businessFramework.eTypIDGroup.Chapters0.ToString()
                Me.ContSelListsObjRules.OpenSelListObjToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Chapters0")
                Me.ContSelListsObjRules.OpenSelListObjToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin

                Me.ContSelListsObjRules.SubListObjToLoad2 = qs2.core.db.ERSystem.businessFramework.eTypIDGroup.Chapters1.ToString()
                Me.ContSelListsObjRules.OpenSelListObj2ToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Chapters1")
                Me.ContSelListsObjRules.OpenSelListObj2ToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin

                Me.ContSelListsObjRules.SubListObjToLoad3 = qs2.core.db.ERSystem.businessFramework.eTypIDGroup.ProcGrp0.ToString()
                Me.ContSelListsObjRules.OpenSelListObj3ToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ProcGrp0")
                Me.ContSelListsObjRules.OpenSelListObj3ToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin

                Me.ContSelListsObjRules.SubListObjToLoad4 = qs2.core.db.ERSystem.businessFramework.eTypIDGroup.ProcGrp1.ToString()
                Me.ContSelListsObjRules.OpenSelListObj4ToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ProcGrp1")
                Me.ContSelListsObjRules.OpenSelListObj4ToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin

                Me.ContSelListsObjRules.OpenSelListToolStripMenuItem.Visible = False

                Me.ContSelListsObjRules.typ = qs2.sitemap.vb.contSelListsObj.eTyp.savedForObject
                Me.ContSelListsObjRules.initControl(Infragistics.Win.DefaultableBoolean.False, "", False, False, New ArrayList(), Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns,
                                                    qs2.sitemap.vb.contSelListsObj.eTypUI.Roles, False,
                                                    qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.rParticipant.IDParticipant)

                Me.tabObjectBottom.ActiveTab = Me.tabObjectBottom.Tabs("Represents")
                Me.showTab("Represents")

                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.txtIDParticipant.ReadOnly = False
                ElseIf qs2.core.vb.actUsr.rUsr.isAdmin Then
                    Me.txtIDParticipant.ReadOnly = True
                Else
                    Me.txtIDParticipant.ReadOnly = True
                End If
                Me.txtID.ReadOnly = True
            End If

            Me.clearControl()
            Me.setControlsDead(False)

            Me.isNew = True
            Me.setUI(True)

            If qs2.core.ENV.rightIsAdmin = 1 Then
                If qs2.core.vb.actUsr.rUsr.UserName.Trim().ToLower() = sqlObjects.userName_Supervisor.Trim().ToLower() Or
                    qs2.core.vb.actUsr.rUsr.UserName.Trim().ToLower() = sqlObjects.userName_Admin.Trim().ToLower() Then
                    chkIsAdmin.Enabled = True
                Else
                    chkIsAdmin.Enabled = False
                End If
            ElseIf qs2.core.ENV.rightIsAdmin = 0 Then
                chkIsAdmin.Enabled = True
            End If

            Me.ContMyAdjust1.initControl()
            Me.ContProducts1.initControl()
            Me.setControlsOnOff(False)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contObject.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.grpPatientData.Text = qs2.core.language.sqlLanguage.getRes("PatientData")

            Me.tabObjectBottom.Tabs("Adress").Text = qs2.core.language.sqlLanguage.getRes("Adress")
            Me.tabObjectBottom.Tabs("OtherData").Text = qs2.core.language.sqlLanguage.getRes("OtherData")
            Me.tabObjectBottom.Tabs("Products").Text = qs2.core.language.sqlLanguage.getRes("Products")

            Me.tabObjectBottom.Tabs("Represents").Text = qs2.core.language.sqlLanguage.getRes("Represents")
            Me.tabObjectBottom.Tabs("UsergroupsAndRights").Text = qs2.core.language.sqlLanguage.getRes("UsergroupsAndRights")
            Me.tabObjectBottom.Tabs("Rights").Text = qs2.core.language.sqlLanguage.getRes("Rights")
            Me.tabObjectBottom.Tabs("Roles").Text = qs2.core.language.sqlLanguage.getRes("Roles")
            Me.tabObjectBottom.Tabs("SettingsUser").Text = qs2.core.language.sqlLanguage.getRes("Settings")
            Me.tabObjectBottom.Tabs("Classification").Text = qs2.core.language.sqlLanguage.getRes("Classification")

            Me.grpUser.Text = qs2.core.language.sqlLanguage.getRes("User")

            Me.lblLastName.Text = qs2.core.language.sqlLanguage.getRes("LastName")
            Me.lblFirstName.Text = qs2.core.language.sqlLanguage.getRes("FirstName")
            Me.lblMaidenName.Text = qs2.core.language.sqlLanguage.getRes("MaidenName")
            Me.lblTitle.Text = qs2.core.language.sqlLanguage.getRes("Title")
            Me.lblGender.Text = qs2.core.language.sqlLanguage.getRes("Gender")
            Me.lblPatientID.Text = qs2.core.language.sqlLanguage.getRes("PatientID")
            Me.lblSSN.Text = qs2.core.language.sqlLanguage.getRes("SSN")
            Me.lblDOB.Text = qs2.core.language.sqlLanguage.getRes("DOB")
            Me.chkIsJehova.Text = qs2.core.language.sqlLanguage.getRes("Jehova")
            Me.lblSince.Text = qs2.core.language.sqlLanguage.getRes("Since")

            Me.lblMTLocatn.Text = qs2.core.language.sqlLanguage.getRes("MTLocatn")
            Me.lblMtCause.Text = qs2.core.language.sqlLanguage.getRes("MtCause")
            Me.lblICD9.Text = qs2.core.language.sqlLanguage.getRes("ICD9")

            Me.chkActive.Text = qs2.core.language.sqlLanguage.getRes("Active")
            Me.lblStatus.Text = qs2.core.language.sqlLanguage.getRes("Status")

            Me.lblCountry.Text = qs2.core.language.sqlLanguage.getRes("CountryID")
            Me.lblZIP.Text = qs2.core.language.sqlLanguage.getRes("ZIP")
            Me.lblCity.Text = qs2.core.language.sqlLanguage.getRes("City")
            Me.lblStreet.Text = qs2.core.language.sqlLanguage.getRes("Street")
            Me.lblPhonePrivate.Text = qs2.core.language.sqlLanguage.getRes("PhonePrivate")
            Me.lblPhoneMobile.Text = qs2.core.language.sqlLanguage.getRes("PhoneMobile")
            Me.lblEMail.Text = qs2.core.language.sqlLanguage.getRes("EMail")

            Me.lblRace.Text = qs2.core.language.sqlLanguage.getRes("Race")

            Me.lblLastNameU.Text = qs2.core.language.sqlLanguage.getRes("LastName")
            Me.lblFirstNameU.Text = qs2.core.language.sqlLanguage.getRes("FirstName")
            Me.lblTitleU.Text = qs2.core.language.sqlLanguage.getRes("Title")
            Me.lblUserName.Text = qs2.core.language.sqlLanguage.getRes("UserName")
            Me.lblPassword.Text = qs2.core.language.sqlLanguage.getRes("Password")
            Me.lblUserShort.Text = qs2.core.language.sqlLanguage.getRes("UserShort")
            Me.chkIsAdmin.Text = qs2.core.language.sqlLanguage.getRes("Admin")
            Me.lblUserNameDomain.Text = qs2.core.language.sqlLanguage.getRes("UserNameDomain")
            Me.lblDomain.Text = qs2.core.language.sqlLanguage.getRes("Domain")
            Me.lblKAVPassword.Text = qs2.core.language.sqlLanguage.getRes("KAVValidation")
            Me.lblUserCode.Text = qs2.core.language.sqlLanguage.getRes("UserCode")
            Me.chkSystemuser.Text = qs2.core.language.sqlLanguage.getRes("Systemuser")
            Me.lblIDParticipant.Text = qs2.core.language.sqlLanguage.getRes("IDParticipant")
            Me.lblID.Text = qs2.core.language.sqlLanguage.getRes("ID")

        Catch ex As Exception
            Throw New Exception("contObject.loadRes: " + ex.ToString())
        End Try
    End Sub

    Public Property OwnIsEmbedded() As Boolean
        Get
            Return Me._OwnIsEmbedded
        End Get
        Set(value As Boolean)
            Me._OwnIsEmbedded = value
        End Set
    End Property

    Public Sub setControlsOnOff(ByVal bOn As Boolean)

        If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
            Me.grpPatientData.Location = New Drawing.Point(0, 0)
            Me.grpPatientData.Visible = bOn
            'Me.grpAdress.Visible = bOn
            Me.tabObjectBottom.Visible = bOn

        ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
            Me.grpUser.Location = New Drawing.Point(0, 0)
            Me.grpUser.Visible = bOn
            Me.Visible = bOn
            Me.tabObjectBottom.Visible = bOn

            If Me.isNew Then
                Me.tabObjectBottom.Tabs("UsergroupsAndRights").Visible = False
                Me.tabObjectBottom.Tabs("Rights").Visible = False
                Me.tabObjectBottom.Tabs("Roles").Visible = False
            Else
                Me.tabObjectBottom.Tabs("UsergroupsAndRights").Visible = True
                Me.tabObjectBottom.Tabs("Rights").Visible = True
                Me.tabObjectBottom.Tabs("Roles").Visible = True
            End If
        End If
    End Sub

    Public Sub clearControl()
        Try
            Me.resetProtocoll()

            Me.clearErrorProvider()

            If Not Me._OwnIsEmbedded Then
                Me.DsObjects1.tblObject.Rows.Clear()
                Me.DsObjects1.tblAdress.Rows.Clear()
            End If

            Me.ExtIDChangedByUser = False

            Me.txtFirstName.Text = ""
            Me.txtLastName.Text = ""
            Me.txtMaidenName.Text = ""
            Me.txtTitle.Text = ""

            Me.txtFirstNameU.Text = ""
            Me.txtLastNameU.Text = ""
            Me.txtTitleU.Text = ""
            Me.chkIsAdmin.Checked = False

            Me.udteDOB.Value = Nothing
            Me.cboGender.Value = Nothing

            Me.cboMtStat.Value = -1
            Me.udteMtDate.Value = Nothing
            Me.cboMtCause.Value = -1
            Me.cboMTLocatn.Value = -1
            Me.txtICD9.Text = ""

            Me.cboRace.Value = Nothing
            Me.setControlsDead(False)

            Me.chkActive.Checked = False

            Me.txtSSN.Text = ""
            Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Indeterminate

            Me.txtExtID.Text = ""

            Me.txtUserName.Text = ""
            Me.txtUserShort.Text = ""
            Me.txtPassword.Text = ""
            Me.txtDomain.Text = ""
            Me.txtUserNameDomain.Text = ""
            Me.txtKavVidierungPwd.Text = ""

            Me.chkSystemuser.Checked = False
            Me.txtUserCode.Text = ""
            Me.txtIDParticipant.Text = ""
            Me.txtID.Text = ""

            Me.cboCountry.Value = -1
            Me.txtZIP.Text = ""
            Me.txtCity.Text = ""
            Me.txtStreet.Text = ""
            Me.txtPhonePrivat.Text = ""
            Me.txtPhoneMobil.Text = ""
            Me.txtEMail.Text = ""

            Me.txtClassification.Text = ""

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
                Me.ContObjectRepresents.clearControl()
                Dim dsAdminSub As New dsAdmin()
                Me.ContSelListsObjRightsUsergroups.loadData(qs2.core.generic.idMinus, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)
                Me.ContSelListsObjRights.loadData(qs2.core.generic.idMinus, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)
                Me.ContSelListsObjRules.loadData(qs2.core.generic.idMinus, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)
            End If

            Me.ContMyAdjust1.ClearUI()
            Me.ContProducts1.ClearUI()

        Catch ex As Exception
            Throw New Exception("contObject.clearControl: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub setControlsDead(ByVal isDead As Integer)

        Dim bIsDead As Boolean = False
        If isDead = 2 Then
            bIsDead = True
        Else
            Me.txtICD9.Text = ""
            Me.udteMtDate.Value = Nothing
            Me.cboMtCause.Value = -1
            Me.cboMTLocatn.Value = -1
        End If

        Me.udteMtDate.Visible = bIsDead
        Me.cboMtCause.Visible = bIsDead
        Me.lblMtCause.Visible = bIsDead
        Me.cboMTLocatn.Visible = bIsDead
        Me.lblMTLocatn.Visible = bIsDead
        Me.txtICD9.Visible = bIsDead
        Me.lblICD9.Visible = bIsDead
        Me.lblSince.Visible = bIsDead
    End Sub

    Public Function loadData(ByVal IDGuid As System.Guid, loadByIDObject As Boolean, IDObject As Integer) As dsObjects.tblObjectRow
        Try
            Me.clearErrorProvider()
            Me.setUI(False)
            Me.setControlsOnOff(True)

            If Not Me._OwnIsEmbedded Then
                Me.DsObjects1.tblObject.Rows.Clear()
                Me.DsObjects1.tblAdress.Rows.Clear()
                If loadByIDObject Then
                    Me.sqlObjects1.getObject(IDObject, Me.DsObjects1, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none, "", "", False, Nothing)
                Else
                    Me.sqlObjects1.getObject(-999, Me.DsObjects1, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", False, IDGuid)
                End If
            End If
            rObjLoaded = Me.DsObjects1.tblObject.Rows(0)

            'If rObj.IsPatient Then
            '    Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient
            'ElseIf rObj.IsPersonal Then
            '    Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPersonal
            'ElseIf rObj.IsUser Then
            '    Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser
            'End If

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then

                Me.txtFirstName.Text = rObjLoaded.FirstName
                Me.txtLastName.Text = rObjLoaded.LastName
                Me.txtMaidenName.Text = rObjLoaded.MaidenName
                Me.txtTitle.Text = rObjLoaded.Title

                If rObjLoaded.IsDOBNull() Then
                    Me.udteDOB.Value = Nothing
                Else
                    Me.udteDOB.Value = rObjLoaded.DOB
                End If
                If rObjLoaded.IsGenderNull() Then
                    Me.cboGender.Value = Nothing
                Else
                    Me.cboGender.Value = rObjLoaded.Gender
                End If

                Me.cboMtStat.Value = rObjLoaded.MtStat
                Me.chkActive.Checked = rObjLoaded.Active
                If rObjLoaded.IsMtDateNull() Then
                    Me.udteMtDate.Value = Nothing
                Else
                    Me.udteMtDate.Value = rObjLoaded.MtDate
                End If
                Me.cboMtCause.Value = rObjLoaded.MtCause
                Me.cboMTLocatn.Value = rObjLoaded.MTLocatn
                Me.txtICD9.Text = rObjLoaded.ICD9

                Me.setControlsDead(rObjLoaded.MtStat)

                Me.txtSSN.Text = rObjLoaded.SSN
                If rObjLoaded.IsJehova = 1 Then
                    Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Checked
                ElseIf rObjLoaded.IsJehova = 0 Then
                    Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Unchecked
                ElseIf rObjLoaded.IsJehova = -1 Then
                    Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Indeterminate
                Else
                    Throw New Exception("loadData: Wrong Value for IsJehova '" + rObjLoaded.IsJehova.ToString() + "' in Db!")
                End If

                Me.txtExtID.Text = rObjLoaded.ExtID

                If rObjLoaded.IsRaceNull() Then
                    Me.cboRace.Value = Nothing
                Else
                    Me.cboRace.Value = rObjLoaded.Race
                End If

            ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then

                Me.txtFirstNameU.Text = rObjLoaded.FirstName
                Me.txtLastNameU.Text = rObjLoaded.LastName
                Me.txtTitleU.Text = rObjLoaded.Title
                Me.chkIsAdmin.Checked = rObjLoaded.isAdmin

                Me.txtUserName.Text = rObjLoaded.UserName
                Me.txtUserShort.Text = rObjLoaded.UserShort
                Me.txtPassword.Text = Me.Encryption1.StringDecrypt(rObjLoaded.Password, qs2.license.core.Encryption.keyForEncryptingStrings)
                Me.txtDomain.Text = rObjLoaded.Domain
                Me.txtUserNameDomain.Text = rObjLoaded.UserNameDomain
                Me.chkSystemuser.Checked = rObjLoaded.Systemuser
                Me.txtUserCode.Text = rObjLoaded.UserCode
                Me.txtIDParticipant.Text = rObjLoaded.IDParticipant
                Me.txtID.Text = rObjLoaded.ID.ToString()

                Me.txtKavVidierungPwd.Text = Me.Encryption1.StringDecrypt(rObjLoaded.KavVidierungPwd, qs2.license.core.Encryption.keyForEncryptingStrings)

                Me.txtClassification.Text = rObjLoaded.Classification

                Me.ContObjectRepresents.loadData(Me.rObjLoaded.IDGuid)
                Dim dsAdminSub As New dsAdmin()
                Me.ContSelListsObjRightsUsergroups.loadData(Me.rObjLoaded.ID, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)
                Me.ContSelListsObjRights.loadData(Me.rObjLoaded.ID, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)
                Me.ContSelListsObjRules.loadData(Me.rObjLoaded.ID, dsAdminSub, qs2.core.license.doLicense.eApp.ALL.ToString(), "", -999, -999, True)

                Me.ContMyAdjust1.loadData(Me.rObjLoaded.UserName)
                Me.ContProducts1.loadData(rObjLoaded.IDGuid)

                Me.tabObjectBottom.Tabs("UsergroupsAndRights").Visible = True
                Me.tabObjectBottom.Tabs("Rights").Visible = True
                Me.tabObjectBottom.Tabs("Roles").Visible = True

            End If

            'Adress (User and Patients!)
            If Not Me._OwnIsEmbedded Then
                Me.sqlObjects1.getAdress(rObjLoaded.IDGuid, Me.DsObjects1, sqlObjects.eTypSelAdr.IsMainAdress)
            End If

            Dim rAdrMain As dsObjects.tblAdressRow
            If Me.DsObjects1.tblAdress.Rows.Count = 0 Then
                'leere Main-Adress-Row einfügen und speichern
                Me.sqlObjects1.getAdress(System.Guid.NewGuid(), Me.DsObjects1, sqlObjects.eTypSelAdr.IsMainAdress)
                rAdrMain = Me.sqlObjects1.getNewRowAdressen(Me.DsObjects1)
                rAdrMain.IDGuidObject = Me.rObjLoaded.IDGuid
                rAdrMain.IsMainAdress = True
                Dim arrAdr(0) As dsObjects.tblAdressRow
                arrAdr(0) = rAdrMain
                If Not Me._OwnIsEmbedded Then
                    Me.sqlObjects1.daAdress.Update(arrAdr)
                End If
            End If

            rAdrMain = Me.DsObjects1.tblAdress.Rows(0)
            Me.cboCountry.Value = rAdrMain.CountryID
            Me.txtZIP.Text = rAdrMain.ZIP
            Me.txtCity.Text = rAdrMain.City
            Me.txtStreet.Text = rAdrMain.Street
            Me.txtPhonePrivat.Text = rAdrMain.PhonePrivat
            Me.txtPhoneMobil.Text = rAdrMain.PhoneMobil
            Me.txtEMail.Text = rAdrMain.EMail

            'rObj.SetCreatedUserIDNull()
            'rObj.Created = Now

            Me.isNew = False
            Me.resetProtocoll()

            Return rObjLoaded

        Catch ex As Exception
            Throw New Exception("contObject.loadData: " + ex.ToString())
        Finally
        End Try
    End Function
    Public Function save() As dsObjects.tblObjectRow
        Try
            Dim rObjNew As dsObjects.tblObjectRow
            Dim rAdrMain As dsObjects.tblAdressRow

            If Me.isNew Then
                Me.sqlObjects1.getObject(qs2.core.generic.idMinus, Me.DsObjects1, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
                rObjNew = Me.sqlObjects1.getNewRowObject(Me.DsObjects1)
            Else
                rObjNew = Me.DsObjects1.tblObject.Rows(0)
            End If

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
                rObjNew.FirstName = Me.txtFirstName.Text.Trim()
                rObjNew.LastName = Me.txtLastName.Text.Trim()
                rObjNew.MaidenName = Me.txtMaidenName.Text.Trim()
                rObjNew.Title = Me.txtTitle.Text.Trim()

                If Me.isNew Then
                    rObjNew.IsPatient = True
                    rObjNew.ExtID = System.Guid.NewGuid().ToString()
                End If

                If Me.udteDOB.Value Is Nothing Then
                    rObjNew.SetDOBNull()
                Else
                    rObjNew.DOB = Me.udteDOB.Value
                End If
                If Me.cboGender.Value Is Nothing Then
                    rObjNew.SetGenderNull()
                Else
                    rObjNew.Gender = Me.cboGender.Value
                End If

                rObjNew.MtStat = Me.cboMtStat.Value
                rObjNew.Active = Me.chkActive.Checked
                If Me.udteMtDate.Value Is Nothing Then
                    rObjNew.SetMtDateNull()
                Else
                    rObjNew.MtDate = Me.udteMtDate.Value
                End If
                rObjNew.MtCause = Me.cboMtCause.Value
                rObjNew.MTLocatn = Me.cboMTLocatn.Value
                rObjNew.ICD9 = Me.txtICD9.Text.Trim()

                rObjNew.SSN = Me.txtSSN.Text
                If Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Checked Then
                    rObjNew.IsJehova = 1
                ElseIf Me.chkIsJehova.CheckState = Windows.Forms.CheckState.Unchecked Then
                    rObjNew.IsJehova = 0
                Else
                    rObjNew.IsJehova = -1
                End If

                rObjNew.ExtID = Me.txtExtID.Text

                If Me.cboRace.Value Is Nothing Then
                    rObjNew.SetRaceNull()
                Else
                    rObjNew.Race = Me.cboRace.Value
                End If


            ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
                If Me.isNew Then
                    rObjNew.IsUser = True
                    rObjNew.ExtID = System.Guid.NewGuid().ToString()
                End If

                rObjNew.FirstName = Me.txtFirstNameU.Text.Trim()
                rObjNew.LastName = Me.txtLastNameU.Text.Trim()
                rObjNew.Title = Me.txtTitleU.Text.Trim()
                rObjNew.isAdmin = Me.chkIsAdmin.Checked

                rObjNew.UserName = Me.txtUserName.Text.Trim()
                rObjNew.UserShort = Me.txtUserShort.Text.Trim()
                rObjNew.Password = IIf(Me.txtPassword.Text.Trim() = "", "", Me.Encryption1.StringEncrypt(Me.txtPassword.Text.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings))
                rObjNew.Domain = Me.txtDomain.Text.Trim()
                rObjNew.UserNameDomain = Me.txtUserNameDomain.Text.Trim()
                rObjNew.KavVidierungPwd = IIf(Me.txtKavVidierungPwd.Text.Trim() = "", "", Encryption1.StringEncrypt(Me.txtKavVidierungPwd.Text.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings))

                rObjNew.Systemuser = Me.chkSystemuser.Checked
                rObjNew.UserCode = Me.txtUserCode.Text.Trim()

                rObjNew.Classification = Me.txtClassification.Text.Trim()

                If Me.isNew Then
                    rObjNew.IDParticipant = Me.txtIDParticipant.Text.Trim()
                Else
                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        rObjNew.IDParticipant = Me.txtIDParticipant.Text.Trim()
                    End If
                End If

                Me.ContObjectRepresents.save(rObjNew.IDGuid)
                Me.ContSelListsObjRightsUsergroups.save(rObjNew.ID)
                Me.ContSelListsObjRights.save(rObjNew.ID)
                Me.ContSelListsObjRules.save(rObjNew.ID)
            End If


            ' Adress (Users and patients!)
            If Me.isNew Then
                Me.sqlObjects1.getAdress(System.Guid.NewGuid(), Me.DsObjects1, sqlObjects.eTypSelAdr.IsMainAdress)
                rAdrMain = Me.sqlObjects1.getNewRowAdressen(Me.DsObjects1)
            Else
                rAdrMain = Me.DsObjects1.tblAdress.Rows(0)
            End If

            rAdrMain.CountryID = Me.cboCountry.Value
            rAdrMain.ZIP = Me.txtZIP.Text
            rAdrMain.City = Me.txtCity.Text
            rAdrMain.Street = Me.txtStreet.Text
            rAdrMain.PhonePrivat = Me.txtPhonePrivat.Text
            rAdrMain.PhoneMobil = Me.txtPhoneMobil.Text
            rAdrMain.EMail = Me.txtEMail.Text
            rAdrMain.IsMainAdress = True
            If Me.isNew Then
                rObjNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant
            End If

            rAdrMain.ZIP = rAdrMain.ZIP.Replace("'", "''")
            rAdrMain.City = rAdrMain.City.Replace("'", "''")
            rAdrMain.Street = rAdrMain.Street.Replace("'", "''")
            rAdrMain.PhonePrivat = rAdrMain.PhonePrivat.Replace("'", "''")
            rAdrMain.PhoneMobil = rAdrMain.PhoneMobil.Replace("'", "''")
            rAdrMain.EMail = rAdrMain.EMail.Replace("'", "''")


            rObjNew.NameCombination = sqlObjects.getNameCombination(rObjNew)

            If Me.isNew Then
                'rObj.CreatedUserID = qs2.core.vb.actUsr.rUsr.UserName.Trim()
                rObjNew.Created = Now
                'rObjNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant
            End If

            'Replace Quotation marks
            rObjNew.FirstName = rObjNew.FirstName.Replace("'", "''")
            rObjNew.LastName = rObjNew.LastName.Replace("'", "''")
            rObjNew.NameCombination = rObjNew.NameCombination.Replace("'", "''")
            rObjNew.Title = rObjNew.Title.Replace("'", "''")
            rObjNew.MaidenName = rObjNew.MaidenName.Replace("'", "''")
            'rObjNew.ExtID = rObjNew.ExtID.Replace("'", "''")
            rObjNew.SSN = rObjNew.SSN.Replace("'", "''")
            rObjNew.ICD9 = rObjNew.ICD9.Replace("'", "''")
            'rObjNew.UserCode = rObjNew.UserCode.Replace("'", "''")

            'rObjNew.UserName = rObjNew.UserName.Replace("'", "''")
            'rObjNew.UserShort = rObjNew.UserShort.Replace("'", "''")
            'rObjNew.Password = rObjNew.Password.Replace("""", "''")
            'rObjNew.UserNameDomain = rObjNew.UserNameDomain.Replace("'", "''")
            'rObjNew.Domain = rObjNew.Domain.Replace("'", "''")


            Dim arrObj(0) As dsObjects.tblObjectRow
            arrObj(0) = rObjNew
            If Not Me._OwnIsEmbedded Then
                Me.sqlObjects1.daObject.Update(arrObj)
                rObjNew.AcceptChanges()
            End If

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
                If Me.isNew Then
                    Dim sqlObjReadTemp As New sqlObjects()
                    sqlObjReadTemp.initControl()
                    Dim rObjTemp As dsObjects.tblObjectRow = sqlObjReadTemp.getObjectRow(-99, sqlObjects.eTypSelObj.IDGuid,
                                                                                         sqlObjects.eTypObj.none, "", "", rObjNew.IDGuid)
                    rAdrMain.IDGuidObject = rObjTemp.IDGuid
                End If
                Dim arrAdr(0) As dsObjects.tblAdressRow
                arrAdr(0) = rAdrMain
                If Not Me._OwnIsEmbedded Then
                    Me.sqlObjects1.daAdress.Update(arrAdr)
                End If

            ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
                If rObjNew.UserName.Trim() = "" Then
                    Throw New Exception("save: rObjNew.UserName.Trim() = '' for IDObject '" + rObjNew.ID.ToString() + "'!")
                End If

                If Me.isNew Then
                    Dim sqlObjReadTemp As New sqlObjects()
                    sqlObjReadTemp.initControl()
                    Dim rObjTemp As dsObjects.tblObjectRow = sqlObjReadTemp.getObjectRow(-99, sqlObjects.eTypSelObj.IDGuid,
                                                                                         sqlObjects.eTypObj.none, "", "", rObjNew.IDGuid)
                    rAdrMain.IDGuidObject = rObjTemp.IDGuid
                End If
                Dim arrAdr(0) As dsObjects.tblAdressRow
                arrAdr(0) = rAdrMain
                If Not Me._OwnIsEmbedded Then
                    Me.sqlObjects1.daAdress.Update(arrAdr)
                End If

                Me.ContMyAdjust1.saveSettings(rObjNew.UserName.Trim())
                Me.ContProducts1.saveData()

                If Me.ContSelListsObjRightsUsergroups.protToSave.Trim() <> "" Then
                    Me.saveProtocoll2(Me.ContSelListsObjRightsUsergroups.protToSave, "Rights changed", rObjNew, Me.isNew, qs2.core.vb.Protocol.eActionProtocol.None)
                End If
                If Me.ContSelListsObjRights.protToSave.Trim() <> "" Then
                    Me.saveProtocoll2(Me.ContSelListsObjRights.protToSave, "Rights changed", rObjNew, Me.isNew, qs2.core.vb.Protocol.eActionProtocol.None)
                End If
                If Me.ContSelListsObjRules.protToSave.Trim() <> "" Then
                    Me.saveProtocoll2(Me.ContSelListsObjRules.protToSave, "Rules changed", rObjNew, Me.isNew, qs2.core.vb.Protocol.eActionProtocol.None)
                End If
            End If

            Me.rObjLoaded = rObjNew

            Return rObjNew

        Catch ex As Exception
            Throw New Exception("contObject.save: " + ex.ToString())
        Finally
        End Try
    End Function
    Public Sub resetProtocoll()
        Me.ProtocollManager = New Protocol()
        Me.ProtocollManager.dsOrig = Me.DsObjects1

    End Sub
    Public Sub saveProtocoll(rObj As dsObjects.tblObjectRow, isNew As Boolean, ByRef ActionProtocol As Protocol.eActionProtocol)

        Me.ProtocollManager.dsNew = Me.DsObjects1
        Dim sKey As String = ""
        Dim sInfo As String = ""
        If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
            sInfo = "Patient " + sqlObjects.getNameCombination(rObj)
        ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
            sInfo = "User " + sqlObjects.getNameCombination(rObj)
        End If
        If isNew Then
            sInfo = "New " + sInfo.Trim()
        Else
            sInfo = "Change " + sInfo.Trim()
        End If
        Me.ProtocollManager.save2(qs2.core.vb.Protocol.eTypeProtocoll.Obj, rObj.IDGuid, qs2.core.generic.idMinus,
                                 qs2.core.license.doLicense.rParticipant.IDParticipant, "", "", sInfo, ActionProtocol, rObj.NameCombination.Trim(), "")

    End Sub
    Public Sub saveProtocoll2(ByRef Prot As String, ProtPrefix As String, rObj As dsObjects.tblObjectRow, isNew As Boolean, ByRef ActionProtocol As Protocol.eActionProtocol)
        Try
            Dim sInfoPref As String = ProtPrefix + " " + " for User " + sqlObjects.getNameCombination(rObj)
            Me.ProtocollManager.save2(qs2.core.vb.Protocol.eTypeProtocoll.RigthRolesChanged, rObj.IDGuid, qs2.core.generic.idMinus,
                                 qs2.core.license.doLicense.rParticipant.IDParticipant, "", "", sInfoPref + " - " + Prot, ActionProtocol, "", "")

        Catch ex As Exception
            Throw New Exception("saveProtocoll2: " + ex.ToString())
        End Try
    End Sub
    Public Function validate() As Boolean
        Try
            Me.clearErrorProvider()

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
                If Me.txtFirstName.Text = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoFirstName") + "!"
                    Me.ErrorProvider1.SetError(Me.txtFirstName, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtFirstName.Focus()
                    Return False
                ElseIf Me.txtLastName.Text = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoLastName") + "!"
                    Me.ErrorProvider1.SetError(Me.txtLastName, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtLastName.Focus()
                    Return False
                ElseIf Me.cboGender.Value Is Nothing Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoGender") + "!"
                    Me.ErrorProvider1.SetError(Me.cboGender, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.cboGender.Focus()
                    Return False
                ElseIf Me.udteDOB.Value Is Nothing Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoDOB") + "!"
                    Me.ErrorProvider1.SetError(Me.udteDOB, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.udteDOB.Focus()
                    Return False
                End If

                If Not Me.funct1.checkComboBox(Me.cboGender, False) Then
                    Me.ErrorProvider1.SetError(Me.cboGender, qs2.core.generic.incorrSel)
                    Return False
                ElseIf Not Me.funct1.checkComboBox(Me.cboCountry, True) Then
                    Me.tabObjectBottom.SelectedTab = Me.tabObjectBottom.Tabs("Adress")
                    Me.tabObjectBottom.ActiveTab = Me.tabObjectBottom.Tabs("Adress")
                    Me.ErrorProvider1.SetError(Me.cboCountry, qs2.core.generic.incorrSel)
                    Return False

                ElseIf Not Me.funct1.checkComboBox(Me.cboMtStat, False) Then
                    Me.ErrorProvider1.SetError(Me.cboMtStat, qs2.core.generic.incorrSel)
                    Return False

                ElseIf Not Me.funct1.checkComboBox(Me.cboMTLocatn, False) Then
                    Me.ErrorProvider1.SetError(Me.cboMTLocatn, qs2.core.generic.incorrSel)
                    Return False
                ElseIf Not Me.funct1.checkComboBox(Me.cboMtCause, False) Then
                    Me.ErrorProvider1.SetError(Me.cboMtCause, qs2.core.generic.incorrSel)
                    Return False

                ElseIf Not Me.funct1.checkComboBox(Me.cboRace, False) Then
                    Me.tabObjectBottom.SelectedTab = Me.tabObjectBottom.Tabs("OtherData")
                    Me.tabObjectBottom.ActiveTab = Me.tabObjectBottom.Tabs("OtherData")
                    Me.ErrorProvider1.SetError(Me.cboRace, qs2.core.generic.incorrSel)
                    Return False
                End If

            ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
                If Me.txtFirstNameU.Text = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoFirstName") + "!"
                    Me.ErrorProvider1.SetError(Me.txtFirstNameU, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtFirstNameU.Focus()
                    Return False
                ElseIf Me.txtLastNameU.Text = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoLastName") + "!"
                    Me.ErrorProvider1.SetError(Me.txtLastNameU, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtLastNameU.Focus()
                    Return False
                ElseIf Me.txtUserName.Text = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoUserName") + "!"
                    Me.ErrorProvider1.SetError(Me.txtUserName, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtUserName.Focus()
                    Return False
                End If

                Dim IDGuidTmp As System.Guid = Nothing
                If Me.isNew Then
                    IDGuidTmp = New System.Guid()
                Else
                    IDGuidTmp = Me.rObjLoaded.IDGuid
                End If
                Dim bUserCodeExistsInDb As Boolean = Me.businessFramework1.checkUsercodeExistsInDb(Me.txtUserCode.Text.Trim(), IDGuidTmp)
                If bUserCodeExistsInDb Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("UsercodeExists") + "!"
                    Me.ErrorProvider1.SetError(Me.txtUserCode, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Me.txtUserCode.Focus()
                    Return False
                End If

                If Not Me.ContObjectRepresents.validate() Then Return False

                Dim b As New qs2.core.db.ERSystem.businessFramework()
                Using db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                    Dim IDGuidObj As System.Guid = Nothing
                    If Not Me.isNew Then
                        IDGuidObj = Me.rObjLoaded.IDGuid
                    End If

                    If Me.txtUserName.Text.Trim() <> "" Then
                        If Not b.checkUserNameParticipant(Me.txtUserName.Text.Trim(), Me.txtIDParticipant.Text.Trim(), IDGuidObj, db) Then
                            Dim txt As String = qs2.core.language.sqlLanguage.getRes("Username{0}AndParticipants{1}AlreadyExists") + "!"
                            txt = System.String.Format(txt, Me.txtUserName.Text.Trim(), Me.txtIDParticipant.Text.Trim())
                            Me.ErrorProvider1.SetError(Me.txtUserName, txt)
                            qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                            Me.txtUserName.Focus()
                            Return False
                        End If
                    End If

                    If Me.txtUserNameDomain.Text.Trim() <> "" Then
                        If Not b.checkUserNameDomainParticipant(Me.txtUserNameDomain.Text.Trim(), Me.txtIDParticipant.Text.Trim(), IDGuidObj, db) Then
                            Dim txt As String = qs2.core.language.sqlLanguage.getRes("UsernameDomain{0}AndParticipant{1}AlreadyExists") + "!"
                            txt = System.String.Format(txt, Me.txtUserNameDomain.Text.Trim(), Me.txtIDParticipant.Text.Trim())
                            Me.ErrorProvider1.SetError(Me.txtUserNameDomain, txt)
                            qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                            Me.txtUserNameDomain.Focus()
                            Return False
                        End If
                    End If
                End Using

                If Not Me.ContProducts1.validateData() Then
                    Return False
                End If

            End If

            Dim sqlObjectsTmp As New sqlObjects()
            Dim dsObjectsTmp As New dsObjects()
            sqlObjectsTmp.initControl()

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
                If Me.ExtIDChangedByUser Then
                    If Me.isNew Then
                        sqlObjectsTmp.getObject(Nothing, dsObjectsTmp, sqlObjects.eTypSelObj.CheckExtNrNoIDObject, sqlObjects.eTypObj.none, Me.txtExtID.Text.Trim())
                    Else
                        sqlObjectsTmp.getObject(rObjLoaded.ID, dsObjectsTmp, sqlObjects.eTypSelObj.CheckExtNr, sqlObjects.eTypObj.none, Me.txtExtID.Text.Trim())
                    End If
                    If dsObjectsTmp.tblObject.Rows.Count > 0 Then
                        Dim txt As String = qs2.core.language.sqlLanguage.getRes("ExtNrExists") + "!"
                        Me.ErrorProvider1.SetError(Me.txtExtID, txt)
                        qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                        Me.txtUserName.Focus()
                        Return False
                    End If
                End If
            End If

            If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("contObject.validate: " + ex.ToString())
        Finally
        End Try
    End Function
    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.txtFirstName, "")
            Me.ErrorProvider1.SetError(Me.txtFirstNameU, "")
            Me.ErrorProvider1.SetError(Me.txtLastName, "")
            Me.ErrorProvider1.SetError(Me.txtLastNameU, "")
            Me.ErrorProvider1.SetError(Me.cboGender, "")
            Me.ErrorProvider1.SetError(Me.txtSSN, "")
            Me.ErrorProvider1.SetError(Me.udteDOB, "")

            Me.ErrorProvider1.SetError(Me.cboMtStat, "")
            Me.ErrorProvider1.SetError(Me.udteMtDate, "")
            Me.ErrorProvider1.SetError(Me.cboMtCause, "")
            Me.ErrorProvider1.SetError(Me.cboMTLocatn, "")
            Me.ErrorProvider1.SetError(Me.txtICD9, "")

            Me.ErrorProvider1.SetError(Me.chkActive, "")
            Me.ErrorProvider1.SetError(Me.chkIsJehova, "")
            Me.ErrorProvider1.SetError(Me.cboCountry, "")
            Me.ErrorProvider1.SetError(Me.txtZIP, "")
            Me.ErrorProvider1.SetError(Me.txtCity, "")
            Me.ErrorProvider1.SetError(Me.txtStreet, "")

            Me.ErrorProvider1.SetError(Me.txtUserName, "")
            Me.ErrorProvider1.SetError(Me.txtUserShort, "")
            Me.ErrorProvider1.SetError(Me.txtPassword, "")
            Me.ErrorProvider1.SetError(Me.txtDomain, "")
            Me.ErrorProvider1.SetError(Me.txtUserNameDomain, "")
            Me.ErrorProvider1.SetError(Me.txtKavVidierungPwd, "")

            Me.ErrorProvider1.SetError(Me.cboRace, "")

            Me.ErrorProvider1.SetError(Me.txtExtID, "")

        Catch ex As Exception
            Throw New Exception("contObject.clearErrorProvider: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Function deleteGuid(ByVal IDGuid As System.Guid, ByRef IDObject As Integer) As Boolean
        Try
            If IDObject <= 0 Then
                Throw New Exception("deleteGuid: IDObject<=0 not allowed!")
            End If

            If qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DeleteRecord"), Windows.Forms.MessageBoxButtons.YesNo, "") = Windows.Forms.DialogResult.Yes Then
                Dim b1 As New qs2.core.vb.businessFramework()
                Dim dsAdminObjectFields As New dsAdmin()
                If b1.checkIDObjectSavedInStay(IDObject) Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("UserExistsInStays") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                    Return False
                End If

                Me.resetProtocoll2()
                Me.saveProtocollxy(qs2.core.generic.idMinus, "", IDGuid, qs2.core.vb.Protocol.eActionProtocol.None)

                Dim b As New qs2.core.db.ERSystem.businessFramework()
                b.deletAllStaysForPatient(IDGuid)
                Me.sqlObjects1.deleteGuid(IDGuid)
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("contObject.deleteGuid: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Sub saveProtocollxy(Found As Integer, Name As String, IDGuidObject As System.Guid, ByRef ActionProtocol As Protocol.eActionProtocol)
        Me.resetProtocoll2()

        Me.ProtocollManager.dsNew = Me.DsObjects1
        Dim typeToSave As New Protocol.eTypeProtocoll()

        Dim sInfo As String = ""
        If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsPatient Then
            typeToSave = Protocol.eTypeProtocoll.DeletePatient
            sInfo = "Delete Patient: " + Name.Trim() + vbNewLine
        ElseIf Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
            typeToSave = Protocol.eTypeProtocoll.DeleteUser
            sInfo = "Delete User: " + Name.Trim() + vbNewLine
        End If

        Me.ProtocollManager.save2(typeToSave, IDGuidObject, qs2.core.generic.idMinus,
                                 qs2.core.license.doLicense.rParticipant.IDParticipant, "", "", sInfo, ActionProtocol, Name.Trim(), "")
    End Sub
    Public Sub resetProtocoll2()
        Me.ProtocollManager = New Protocol()
        Me.ProtocollManager.dsOrig = New DataSet()
        Me.ProtocollManager.dsNew = New DataSet()
    End Sub

    Public Sub setUI(ByVal editOn As Boolean)

        Me._IsInEditMode = editOn
        If Me.isNew Then
        Else
        End If

        Me.doUI1.EnableControls(Me.grpUser, editOn)
        Me.doUI1.EnableControls(Me.grpPatientData, editOn)
        'Me.txtLastName.ReadOnly = Not editOn

        'Me.doUI1.EnableControls(Me.PanelAdress, editOn)
        Me.txtZIP.Enabled = editOn
        Me.txtCity.Enabled = editOn
        Me.txtStreet.Enabled = editOn
        Me.cboCountry.Enabled = editOn
        Me.txtPhonePrivat.Enabled = editOn
        Me.txtPhoneMobil.Enabled = editOn
        Me.txtEMail.Enabled = editOn

        Me.txtClassification.Enabled = editOn

        'Me.doUI1.EnableControls(Me.PanelOtherData, editOn)
        cboRace.Enabled = editOn
        chkIsJehova.Enabled = editOn

        Me.doUI1.EnableControls(Me.ContMyAdjust1.PanelMySettings, editOn)
        Me.ContMyAdjust1.checkDoNotShowAnymore.Enabled = editOn
        'Me.doUI1.EnableControls(Me.PanelProducts, editOn)

        If Me.typSearch = qs2.core.vb.sqlObjects.eTypObj.IsUser Then
            Me.ContObjectRepresents.lockUnlock(editOn)
            Me.ContSelListsObjRightsUsergroups.lockUnlock(editOn)
            Me.ContSelListsObjRights.lockUnlock(editOn)
            Me.ContSelListsObjRules.lockUnlock(editOn)
        Else
        End If
        Me.ContProducts1.lockUnlock(editOn)

        Me.ContMyAdjust1.cboLanguageUser.Enabled = editOn
        Me.ContMyAdjust1.cboAutoStartUser.Enabled = editOn
        Me.ContMyAdjust1.cboStyle.Enabled = editOn

    End Sub

    Private Sub cboMtStat_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cboMtStat.ValueChanged
        Try
            If Me.cboMtStat.Focused Then
                Me.setControlsDead(Me.cboMtStat.Value)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub checkBoxes_BeforeCheckStateChanged(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles chkActive.BeforeCheckStateChanged, chkIsAdmin.BeforeCheckStateChanged
        Try
            Me.doUI1.checkBoxes_BeforeCheckStateChanged(sender, e, Me._IsInEditMode)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Private Sub toolbarBottom_ToolClick(sender As System.Object, e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Try
            If Me.lockToolBar Then
                Exit Sub
            End If
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.showTab(e.Tool.Key)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub showTab(TabTg As String)
        Try
            Me.tabObjectBottom.SelectedTab = Me.tabObjectBottom.Tabs(TabTg)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub txtTitle_Enter(sender As System.Object, e As System.EventArgs) Handles txtTitle.Enter
        Try
            Me.txtTitle.SelectAll()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub txtTitleU_Enter(sender As System.Object, e As System.EventArgs) Handles txtTitleU.Enter
        Try
            Me.txtTitleU.SelectAll()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub txtExtID_ValueChanged(sender As Object, e As EventArgs) Handles txtExtID.ValueChanged
        Try
            If Me.txtExtID.Focused Then
                Me.ExtIDChangedByUser = True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub txtIDParticipant_ValueChanged(sender As Object, e As EventArgs) Handles txtIDParticipant.ValueChanged

    End Sub

    Private Sub contObject_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
                Dim pars As New qs2.core.ENV.cParsCalMainFunction()
                pars.UICoontrol = Me
                pars.UIComponents = Me.components
                qs2.core.ENV.CallFunctionMain(core.ENV.eTypeFunction.doColorManagment, pars)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub Label_MouseEnter(sender As Object, e As EventArgs) Handles lblZIP.MouseEnter, lblUserShort.MouseEnter, lblUserNameDomain.MouseEnter, lblUserName.MouseEnter, lblUserCode.MouseEnter, lblTitleU.MouseEnter, lblStreet.MouseEnter, lblPhonePrivate.MouseEnter, lblPhoneMobile.MouseEnter, lblPassword.MouseEnter, lblLastNameU.MouseEnter, lblKAVPassword.MouseEnter, lblIDParticipant.MouseEnter, lblID.MouseEnter, lblFirstNameU.MouseEnter, lblEMail.MouseEnter, lblDomain.MouseEnter, lblCountry.MouseEnter, lblCity.MouseEnter, chkSystemuser.MouseEnter, chkIsAdmin.MouseEnter, lblTitle.MouseEnter, lblStatus.MouseEnter, lblSSN.MouseEnter, lblSince.MouseEnter, lblPatientID.MouseEnter, lblMTLocatn.MouseEnter, lblMtCause.MouseEnter, lblMaidenName.MouseEnter, lblLastName.MouseEnter, lblICD9.MouseEnter, lblGender.MouseEnter, lblFirstName.MouseEnter, lblDOB.MouseEnter, chkActive.MouseEnter, chkIsJehova.MouseEnter, lblRace.MouseEnter
        Try
            qs2.core.ui.CheckMouseHoverLeaveContr(sender, e, True, DirectCast(sender, System.Windows.Forms.Control).Tag, qs2.core.license.doLicense.rApplication.IDApplication)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub Label_MouseLeave(sender As Object, e As EventArgs) Handles lblZIP.MouseLeave, lblUserShort.MouseLeave, lblUserNameDomain.MouseLeave, lblUserName.MouseLeave, lblUserCode.MouseLeave, lblTitleU.MouseLeave, lblStreet.MouseLeave, lblPhonePrivate.MouseLeave, lblPhoneMobile.MouseLeave, lblPassword.MouseLeave, lblLastNameU.MouseLeave, lblKAVPassword.MouseLeave, lblIDParticipant.MouseLeave, lblID.MouseLeave, lblFirstNameU.MouseLeave, lblEMail.MouseLeave, lblDomain.MouseLeave, lblCountry.MouseLeave, lblCity.MouseLeave, chkSystemuser.MouseLeave, chkIsAdmin.MouseLeave, lblTitle.MouseLeave, lblStatus.MouseLeave, lblSSN.MouseLeave, lblSince.MouseLeave, lblPatientID.MouseLeave, lblMTLocatn.MouseLeave, lblMtCause.MouseLeave, lblMaidenName.MouseLeave, lblLastName.MouseLeave, lblICD9.MouseLeave, lblGender.MouseLeave, lblFirstName.MouseLeave, lblDOB.MouseLeave, chkActive.MouseLeave, lblRace.MouseLeave, chkIsJehova.MouseLeave
        Try
            qs2.core.ui.CheckMouseHoverLeaveContr(sender, e, False, DirectCast(sender, System.Windows.Forms.Control).Tag, qs2.core.license.doLicense.rApplication.IDApplication)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub UIControl_MouseEnter(sender As Object, e As Infragistics.Win.UIElementEventArgs) Handles udteMtDate.MouseEnterElement, udteDOB.MouseEnterElement, txtZIP.MouseEnterElement, txtTitle.MouseEnterElement, txtStreet.MouseEnterElement, txtSSN.MouseEnterElement, txtPhonePrivat.MouseEnterElement, txtPhoneMobil.MouseEnterElement, txtMaidenName.MouseEnterElement, txtLastName.MouseEnterElement, txtICD9.MouseEnterElement, txtFirstName.MouseEnterElement, txtExtID.MouseEnterElement, txtEMail.MouseEnterElement, txtCity.MouseEnterElement, cboMtStat.MouseEnterElement, cboMTLocatn.MouseEnterElement, cboMtCause.MouseEnterElement, cboGender.MouseEnterElement, cboCountry.MouseEnterElement, txtUserShort.MouseEnterElement, txtUserNameDomain.MouseEnterElement, txtUserName.MouseEnterElement, txtUserCode.MouseEnterElement, txtTitleU.MouseEnterElement, txtPassword.MouseEnterElement, txtLastNameU.MouseEnterElement, txtKavVidierungPwd.MouseEnterElement, txtIDParticipant.MouseEnterElement, txtID.MouseEnterElement, txtFirstNameU.MouseEnterElement, txtDomain.MouseEnterElement, cboRace.MouseEnterElement, txtClassification.MouseEnterElement
        Try
            qs2.core.ui.CheckMouseHoverLeaveContr(sender, e, True, DirectCast(sender, System.Windows.Forms.Control).Tag, qs2.core.license.doLicense.rApplication.IDApplication)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub UIControl_MouseLeave(sender As Object, e As Infragistics.Win.UIElementEventArgs) Handles udteMtDate.MouseLeaveElement, udteDOB.MouseLeaveElement, txtZIP.MouseLeaveElement, txtTitle.MouseLeaveElement, txtStreet.MouseLeaveElement, txtSSN.MouseLeaveElement, txtPhonePrivat.MouseLeaveElement, txtPhoneMobil.MouseLeaveElement, txtMaidenName.MouseLeaveElement, txtLastName.MouseLeaveElement, txtICD9.MouseLeaveElement, txtFirstName.MouseLeaveElement, txtExtID.MouseLeaveElement, txtEMail.MouseLeaveElement, txtCity.MouseLeaveElement, cboMtStat.MouseLeaveElement, cboMTLocatn.MouseLeaveElement, cboMtCause.MouseLeaveElement, cboGender.MouseLeaveElement, cboCountry.MouseLeaveElement, txtUserShort.MouseLeaveElement, txtUserNameDomain.MouseLeaveElement, txtUserName.MouseLeaveElement, txtUserCode.MouseLeaveElement, txtTitleU.MouseLeaveElement, txtPassword.MouseLeaveElement, txtLastNameU.MouseLeaveElement, txtKavVidierungPwd.MouseLeaveElement, txtIDParticipant.MouseLeaveElement, txtID.MouseLeaveElement, txtFirstNameU.MouseLeaveElement, txtDomain.MouseLeaveElement, cboRace.MouseLeaveElement, txtClassification.MouseLeaveElement
        Try
            qs2.core.ui.CheckMouseHoverLeaveContr(sender, e, False, DirectCast(sender, System.Windows.Forms.Control).Tag, qs2.core.license.doLicense.rApplication.IDApplication)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        qs2.core.generic.TogglePassword(sender)
    End Sub

    Private Sub txtKavVidierungPwd_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtKavVidierungPwd.KeyDown
        qs2.core.generic.TogglePassword(sender)
    End Sub
End Class

