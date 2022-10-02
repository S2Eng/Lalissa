Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree
Imports PMDS.db
Imports PMDS.Global.db.ERSystem
Imports System.Linq



Public Class contSelectPatientenBenutzer

    Public _IDPlan As Guid = Nothing
    Public _TypeUI As eTypeUI

    Public _IsSearch As Boolean = False
    Public _IsTextTemplate As Boolean = False

    Public _SingleSelect As Boolean = False
    Public _UserCanChangeBenutzerPatients As Boolean = True
    Public _IDToSelect As Nullable(Of Guid) = Nothing
    Public _TypeUIMain As contPlanungData.eTypeUI

    Public MainNachricht As frmNachricht3 = Nothing
    Public MainPlanungGesamt As contPlanung2 = Nothing
    Public MainTextTemplates As contTextTemplates = Nothing

    Public abort As Boolean = True
    Public IsInitialized As Boolean = False
    Public _dropDownButton As UltraDropDownButton = Nothing
    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing
    Public TreeLockItemChanged As Boolean = False
    Public TreeLockItemChangedReadyLoad As Boolean = False

    Public bShowAlleWhen0Selected As Boolean = False

    Public firstLoad As Boolean = True


    Public Enum eTypeUI
        Patients = 0
        Users = 1
        AbtBereich = 2
    End Enum

    Public Class cTgListViews
        Public TypeListViewTag As eTypeListViewTag
        Public ID As System.Guid = Nothing
        Public abwesend As Boolean = False
    End Class
    Public Enum eTypeListViewTag
        Klinik = 0
        Abteilung = 1
        Bereich = 2
        Benutzer = 3
        Patient = 4
    End Enum

    Public Class cBerufsgruppe
        Public Bezeichnung As String = ""
        Public IDAuswahliste As Guid = Nothing
        Public IstGruppe As Boolean = False
        Public GehörtzuGruppe As String = ""
    End Class

    Public gen As New General()

    Public b As New PMDS.db.PMDSBusiness()
    Public bRAM As New PMDSBusinessRAM()

    Public IDUserLoggedOn As Guid = Nothing


    Public _IDAbteilung As Nullable(Of Guid) = Nothing
    Public _IDBereich As Nullable(Of Guid) = Nothing
    Public _IDBerufsgruppe As Nullable(Of Guid) = Nothing
    Public _SelectAll As Boolean
    Public _clearTreeSelected As Boolean

    Public LabelPickerAlternate As String = ""
    Public setSelectededTxt_Name As Boolean = False
    Public SendEventAbtBereicheWhenSelectChanged As Boolean = False
    Public SendEventPatientUsersWhenSelectChanged As Boolean = False
    Public _TypePatientenUserPickerChanged As PMDS.Global.eTypePatientenUserPickerChanged

    Public lstAbteilungenUserHasRight As New System.Collections.Generic.List(Of Guid)()
    Public lstBereicheUserHasRight As New System.Collections.Generic.List(Of Guid)()

    Public noExceptionIfUserNotFound As Boolean = False








    Private Sub contSelectPatientenBenutzer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Public Sub initControl(TypeUI As eTypeUI, IsSearch As Boolean, IsTextTemplate As Boolean, dropDownButton As UltraDropDownButton)
        Try
            If Not Me.IsInitialized Then
                Me._TypeUI = TypeUI
                Me._IsSearch = IsSearch
                Me._IsTextTemplate = IsTextTemplate
                Me._dropDownButton = dropDownButton

                Me.btnSelectSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
                Me.LöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

                If Me._IsSearch Then
                    Me.btnSelectSave.Text = doUI.getRes("OK")
                    'Me.btnSelectSave.Text = doUI.getRes("Search")
                Else
                    Me.btnSelectSave.Text = doUI.getRes("OK")
                End If

                Me.lblSearch.Visible = True
                Me.txtSearch.Visible = True
                If Me._TypeUI = eTypeUI.Patients Then
                    Me.lblBerufsgruppen.Visible = False
                    Me.cboBerufsgruppen.Visible = False
                    Me.chkShowOnlyAnwesendePatienten.Visible = True
                    Me.chkShowNotActiveUsers.Visible = False

                ElseIf Me._TypeUI = eTypeUI.Users Then
                    Me.lblBerufsgruppen.Visible = True
                    Me.cboBerufsgruppen.Visible = True
                    Me.chkShowOnlyAnwesendePatienten.Visible = False
                    Me.chkShowNotActiveUsers.Visible = True

                ElseIf Me._TypeUI = eTypeUI.AbtBereich Then
                    Me.lblBerufsgruppen.Visible = False
                    Me.cboBerufsgruppen.Visible = False
                    Me.chkShowOnlyAnwesendePatienten.Visible = False
                    Me.chkShowNotActiveUsers.Visible = False

                    Me.treeBenutzerPatients.Visible = False
                    Me.treeBenutzerPatientsSelected.Visible = False
                    Me.lblSelectAll.Visible = False
                    Me.lblSelectNone.Visible = False
                    Me.lblSelected.Visible = False
                    Me.cboBerufsgruppen.Visible = False
                    Me.lblBerufsgruppen.Visible = False
                    Me.chkShowNotActiveUsers.Visible = False
                    Me.txtSearch.Visible = False
                    Me.lblSearch.Visible = False
                    Me.PanelBottom.Visible = False

                    Me.utreeAbtBereiche.Width = Me.PanelCenter.Width - 4
                    Me.utreeAbtBereiche.Dock = Windows.Forms.DockStyle.Fill

                End If

                If Me._IsTextTemplate Then
                    Me._IDPlan = System.Guid.NewGuid()
                    Me.btnSelectSave.Visible = False
                End If

                'Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                '    Dim rUser As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)
                '    Me.IDUserLoggedOn = rUser.ID
                'End Using

                Me.IDUserLoggedOn = PMDS.Global.ENV.USERID

                Me.initControlData()

                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub initControlData()
        Try
            Me.loadCboBerufsstand()
            Me.cboBerufsgruppen.Value = Nothing
            Me.loadAbtBereicheUserHasRight()
            Me.loadDataAbtBereiche()
            Me.loadBenutzerPatients(Nothing, Nothing, Nothing, Me._IsSearch, True)

            Me.DsPlan1.Clear()
            Me.CompPlan1.getPlanObject(System.Guid.NewGuid(), compPlan.eTypSelPlanObject.IDObject, Me.DsPlan1)

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.initControlData: " + ex.ToString())
        End Try
    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try


        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadDataAbtBereiche()
        Try

            'Me.lstIDsSelected.Clear()
            'Me.lstDescriptionsSelected.Clear()
            'Me.treeBenutzerPatients.Items.Clear()
            Me.utreeAbtBereiche.Nodes.Clear()

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False

                Dim rKlinik As PMDS.db.Entities.Klinik = Me.bRAM.getKlinik(PMDS.Global.ENV.IDKlinik, db)
                Dim treeNodeKlinik As UltraTreeNode = Me.utreeAbtBereiche.Nodes.Add(System.Guid.NewGuid().ToString(), rKlinik.Bezeichnung.Trim())
                Dim TgListViewKlinik As New cTgListViews()
                TgListViewKlinik.TypeListViewTag = eTypeListViewTag.Klinik
                TgListViewKlinik.ID = rKlinik.ID
                treeNodeKlinik.Tag = TgListViewKlinik

                Dim tAbteilung As List(Of PMDS.db.Entities.Abteilung) = Me.bRAM.getAllAbteilungen(rKlinik.ID, db)
                For Each rAbteilung As PMDS.db.Entities.Abteilung In tAbteilung
                    If rAbteilung.IDKlinik.Equals(rKlinik.ID) Then
                        If PMDS.Global.ENV.adminSecure Or Me.bRAM.checkRightAbteilungenUser(rAbteilung.ID, PMDS.Global.ENV.IDKlinik, Me.IDUserLoggedOn, db) Then
                            Dim treeNodeAbteilung As UltraTreeNode = treeNodeKlinik.Nodes.Add(System.Guid.NewGuid().ToString(), rAbteilung.Bezeichnung.Trim())
                            Dim TgListViewAbteilung As New cTgListViews()
                            TgListViewAbteilung.TypeListViewTag = eTypeListViewTag.Abteilung
                            TgListViewAbteilung.ID = rAbteilung.ID
                            treeNodeAbteilung.Tag = TgListViewAbteilung
                            If Me.firstLoad Then
                                'treeNodeAbteilung.CollapseAll()
                            End If
                            treeNodeKlinik.Expanded = False

                            Dim tBereichForAbteilung As List(Of PMDS.db.Entities.Bereich) = Nothing
                            Dim bBereichOK As Boolean = Me.bRAM.getAllBereichForAbteilung(rAbteilung.ID, tBereichForAbteilung, db)
                            For Each rBereich As PMDS.db.Entities.Bereich In tBereichForAbteilung
                                Dim treeNodeBereich As UltraTreeNode = treeNodeAbteilung.Nodes.Add(System.Guid.NewGuid().ToString(), rBereich.Bezeichnung.Trim())
                                Dim TgListViewBereich As New cTgListViews()
                                TgListViewBereich.TypeListViewTag = eTypeListViewTag.Bereich
                                TgListViewBereich.ID = rBereich.ID
                                treeNodeBereich.Tag = TgListViewBereich
                                'treeNodeBereich.ExpandAll()
                            Next
                        End If
                    End If
                Next

                treeNodeKlinik.Expanded = True
            End Using

            If Me.firstLoad Then
                'Me.utreeAbtBereiche.ExpandAll()
            End If

            Me.firstLoad = False

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadDataAbtBereiche: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadAbtBereicheUserHasRight()
        Try
            Me.lstAbteilungenUserHasRight.Clear()
            Me.lstBereicheUserHasRight.Clear()

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False

                Dim tAbteilungUser As System.Linq.IQueryable(Of PMDS.db.Entities.BenutzerAbteilung) = Me.b.getBenutzerAbteilung(PMDS.Global.ENV.USERID, db)
                Dim tBereichUser As System.Linq.IQueryable(Of PMDS.db.Entities.BereichBenutzer) = Me.b.getBereichBenutzer(PMDS.Global.ENV.USERID, db)

                For Each rBenutzerAbteilung As PMDS.db.Entities.BenutzerAbteilung In tAbteilungUser
                    Me.lstAbteilungenUserHasRight.Add(rBenutzerAbteilung.IDAbteilung)
                Next
                For Each rBereichBenutzer As PMDS.db.Entities.BereichBenutzer In tBereichUser
                    Me.lstBereicheUserHasRight.Add(rBereichBenutzer.IDBereich)
                Next
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadAbtBereicheUserHasRight: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadBenutzerPatients(ByRef IDAbteilung As Nullable(Of Guid), ByRef IDBereich As Nullable(Of Guid), ByRef IDBerufsgruppe As Nullable(Of Guid), SelectAll As Boolean, clearTreeSelected As Boolean,
                                    Optional ByRef IDFoundInTree As Boolean = False, Optional SelectID As Boolean = True)
        Try
            Me._IDAbteilung = IDAbteilung
            Me._IDBereich = IDBereich
            Me._IDBerufsgruppe = IDBerufsgruppe
            Me._SelectAll = SelectAll
            Me._clearTreeSelected = clearTreeSelected

            If Me._TypeUI = eTypeUI.AbtBereich Then
                Throw New Exception("loadBenutzerPatients: Fct. not allowed for Me._TypeUI '" + Me._TypeUI.ToString() + "'!")
            Else
                If Me._TypeUIMain = contPlanungData.eTypeUI.PlanMy And Me._TypeUI = eTypeUI.Users Then
                    Me.lblSelectAll.Visible = False
                    Me.lblSelectNone.Visible = False
                ElseIf Me._TypeUIMain = contPlanungData.eTypeUI.IDKlient And Me._TypeUI = eTypeUI.Patients Then
                    Me.lblSelectAll.Visible = False
                    Me.lblSelectNone.Visible = False
                Else
                    Me.lblSelectAll.Visible = True
                    Me.lblSelectNone.Visible = True
                End If
            End If

            Me.txtSearch.Text = ""
            If clearTreeSelected Then
                Me.treeBenutzerPatientsSelected.Items.Clear()
            End If

            Dim UserCanChangeBenutzerPatientsTmp As Boolean = Me._UserCanChangeBenutzerPatients
            Me._UserCanChangeBenutzerPatients = True
            Me.treeBenutzerPatients.Items.Clear()
            If (Not Me._IDToSelect Is Nothing) And (Me._TypeUIMain = contPlanungData.eTypeUI.PlanMy Or Me._TypeUIMain = contPlanungData.eTypeUI.IDKlient) Then
                Me.DsPlan1.Clear()
            End If
            If Me._IsSearch And Me._TypeUIMain = contPlanungData.eTypeUI.PlanKlienten Then
                Me.DsPlan1.Clear()
            ElseIf Me._IsSearch And Me._TypeUIMain = contPlanungData.eTypeUI.PlansAll Then
                Me.DsPlan1.Clear()
            ElseIf Me._IsSearch And Me._TypeUIMain = contPlanungData.eTypeUI.PlanMy And Me._TypeUI = eTypeUI.Patients Then
                Me.DsPlan1.Clear()
            End If

            Using db2 As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db2.Configuration.LazyLoadingEnabled = False

                If Me._TypeUI = eTypeUI.Users Then
                    Dim lstBenutzerReturn As New System.Collections.Generic.List(Of Guid)
                    If ((IDAbteilung Is Nothing) Or IDAbteilung.Equals(System.Guid.Empty)) And IDBereich Is Nothing Then
                        Me.bRAM.getAllUsersKlinik(db2, PMDS.Global.ENV.IDKlinik, lstBenutzerReturn)
                    ElseIf (Not IDAbteilung Is Nothing) And IDBereich Is Nothing Then
                        Me.bRAM.getAllUsersForAbteilung(IDAbteilung.Value, PMDS.Global.ENV.IDKlinik, db2, lstBenutzerReturn)
                    ElseIf (IDAbteilung Is Nothing) And (Not IDBereich Is Nothing) Then
                        Me.bRAM.getAllUsersForBereich(IDBereich.Value, PMDS.Global.ENV.IDKlinik, db2, lstBenutzerReturn)
                    ElseIf (Not IDAbteilung Is Nothing) And (Not IDBereich Is Nothing) Then
                        Me.bRAM.getAllUsersForBereich(IDBereich.Value, PMDS.Global.ENV.IDKlinik, db2, lstBenutzerReturn)
                    End If

                    Dim rAuswahlliste As PMDS.db.Entities.AuswahlListe = Nothing
                    Dim lstBerufsstand As New System.Collections.Generic.List(Of Guid)()
                    If Not IDBerufsgruppe Is Nothing Then
                        rAuswahlliste = Me.bRAM.GetAuswahllisteByID(IDBerufsgruppe, db2)
                        lstBerufsstand.Add(rAuswahlliste.ID)
                        If rAuswahlliste.IstGruppe Then
                            Dim tAuswahllistenZuGruppen As List(Of PMDS.db.Entities.AuswahlListe) = Me.bRAM.GetAuswahllistenByIDGruppe(rAuswahlliste.Bezeichnung.Trim(), db2)
                            For Each rAuswahllisteZuGruppe As PMDS.db.Entities.AuswahlListe In tAuswahllistenZuGruppen
                                If Not lstBerufsstand.Contains(rAuswahllisteZuGruppe.ID) Then
                                    lstBerufsstand.Add(rAuswahllisteZuGruppe.ID)
                                End If
                            Next
                        End If
                    End If

                    For Each IDBenutzer As Guid In lstBenutzerReturn
                        Dim rBenutzer As PMDS.db.Entities.Benutzer = Me.bRAM.getUser(IDBenutzer, db2)
                        Dim bBerufsstandOK As Boolean = True
                        If (Not IDBerufsgruppe Is Nothing) AndAlso (Not rBenutzer.IDBerufsstand Is Nothing) Then
                            If Not lstBerufsstand.Contains(rBenutzer.IDBerufsstand.Value) Then
                                bBerufsstandOK = False
                            End If
                        End If
                        If bBerufsstandOK Then
                            Dim bShowActiveUser As Boolean = False
                            If Me.chkShowNotActiveUsers.Checked Then
                                bShowActiveUser = True
                            Else
                                If rBenutzer.AktivJN Then
                                    bShowActiveUser = True
                                End If
                            End If
                            If bShowActiveUser Then
                                Dim itmBenutzer As UltraListViewItem = Me.treeBenutzerPatients.Items.Add(System.Guid.NewGuid().ToString(), rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " [" + rBenutzer.Benutzer1.Trim() + "]")
                                Dim TgListViewBenutzer As New cTgListViews()
                                TgListViewBenutzer.TypeListViewTag = eTypeListViewTag.Benutzer
                                TgListViewBenutzer.ID = rBenutzer.ID
                                itmBenutzer.Tag = TgListViewBenutzer
                                If Not rBenutzer.AktivJN Then
                                    itmBenutzer.Appearance.ForeColor = Drawing.Color.Red
                                End If
                                If SelectAll And (Not Me._TypeUIMain = contPlanungData.eTypeUI.PlanMy) And (Not Me._TypeUIMain = contPlanungData.eTypeUI.IDKlient) Then
                                    itmBenutzer.CheckState = Windows.Forms.CheckState.Checked
                                    If Not Me.checkPlanExistsInDataSet(TgListViewBenutzer.ID) Then
                                        Me.addObjectToSelected(TgListViewBenutzer.ID, Me._IDPlan, itmBenutzer.Text.Trim())
                                    End If
                                Else
                                    itmBenutzer.CheckState = Windows.Forms.CheckState.Unchecked
                                End If
                            End If
                        End If
                    Next

                ElseIf Me._TypeUI = eTypeUI.Patients Then
                    'Dim dsKlientenliste1 As New dsKlientenliste()
                    'Dim sqlManangeWork As New sqlManange()
                    'sqlManangeWork.initControl()

                    Dim IDAbteilungTmp As Guid = Guid.Empty
                    If Not IDAbteilung Is Nothing Then
                        IDAbteilungTmp = IDAbteilung
                    End If

                    Dim IDBereichTmp As Guid = Guid.Empty
                    If Not IDBereich Is Nothing Then
                        IDBereichTmp = IDBereich
                    End If

                    'sqlManangeWork.getPatientenStart(PMDS.Global.Settings.USERID, 0, System.Guid.Empty, dsKlientenliste1, IDAbteilungTmp, IDBereichTmp, System.Guid.Empty)
                    'Dim arrKlientenlisteOnline() As dsKlientenliste.vKlientenlisteRow = dsKlientenliste1.vKlientenliste.Select("", dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc")
                    Dim arrKlientenliste As List(Of PMDSBusinessStructures.cPatients) = Me.bRAM.getPatientenStart(IDAbteilungTmp, IDBereichTmp, db2)
                    Dim listAbwesPatients As List(Of Guid) = Me.bRAM.getListAbwesendePatients()

                    For Each rKlient As PMDSBusinessStructures.cPatients In arrKlientenliste
                        Dim bShowPatient As Boolean = True
                        Dim PatientIsAbwesend As Boolean = False
                        If Me.chkShowOnlyAnwesendePatienten.Checked Then
                            If listAbwesPatients.Contains(rKlient.IDPatient) Then
                                bShowPatient = False
                            End If
                        Else
                            If listAbwesPatients.Contains(rKlient.IDPatient) Then
                                PatientIsAbwesend = True
                            End If
                        End If

                        Dim bShowPatientAbteilung As Boolean = False
                        If (Not rKlient.IDAbteilung Is Nothing) AndAlso (Not rKlient.IDAbteilung.Equals(System.Guid.Empty)) Then
                            If Me.lstAbteilungenUserHasRight.Contains(rKlient.IDAbteilung.Value) Then
                                bShowPatientAbteilung = True
                            End If
                        Else
                            bShowPatientAbteilung = True
                        End If
                        Dim bShowPatientBereich As Boolean = False
                        If (Not rKlient.IDBereich Is Nothing) AndAlso (Not rKlient.IDBereich.Equals(System.Guid.Empty)) Then
                            If Me.lstBereicheUserHasRight.Contains(rKlient.IDBereich.Value) Then
                                bShowPatientBereich = True
                            End If
                        Else
                            bShowPatientBereich = True
                        End If

                        If bShowPatient And bShowPatientAbteilung And bShowPatientBereich Then
                            Dim itmPatients As UltraListViewItem = Me.treeBenutzerPatients.Items.Add(System.Guid.NewGuid().ToString(), rKlient.PatientNachname.Trim() + " " + rKlient.PatientVorname.Trim())
                            If PatientIsAbwesend Then
                                itmPatients.Appearance.ForeColor = Drawing.Color.Red
                            End If

                            Dim TgListViewPatients As New cTgListViews()
                            TgListViewPatients.TypeListViewTag = eTypeListViewTag.Patient
                            TgListViewPatients.ID = rKlient.IDPatient
                            TgListViewPatients.abwesend = PatientIsAbwesend
                            itmPatients.Tag = TgListViewPatients
                            If Me._IsSearch And (Not Me._TypeUIMain = contPlanungData.eTypeUI.PlanMy) And (Not Me._TypeUIMain = contPlanungData.eTypeUI.IDKlient) And (Not Me._SingleSelect) Then
                                itmPatients.CheckState = Windows.Forms.CheckState.Checked
                                If Not Me.checkPlanExistsInDataSet(TgListViewPatients.ID) Then
                                    Me.addObjectToSelected(TgListViewPatients.ID, Me._IDPlan, itmPatients.Text.Trim())
                                End If
                            Else
                                itmPatients.CheckState = Windows.Forms.CheckState.Unchecked
                            End If
                        End If
                    Next

                    'Dim tBenutzer As IQueryable(Of PMDS.db.Entities.Patient) = Me.b.getAllPatients(db)
                    'For Each rPatient As PMDS.db.Entities.Patient In tBenutzer
                    '    Dim itmPatients As UltraListViewItem = Me.treeBenutzerPatients.Items.Add(System.Guid.NewGuid().ToString(), rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim())
                    '    Dim TgListViewPatients As New cTgListViews()
                    '    TgListViewPatients.TypeListViewTag = eTypeListViewTag.Patient
                    '    TgListViewPatients.ID = rPatient.ID
                    '    itmPatients.Tag = TgListViewPatients
                    'Next
                Else
                    Throw New Exception("contSelectPatientenBenutzer.loadData: Me._TypeUI '" + Me._TypeUI.ToString() + "' not allowed!")
                End If
            End Using

            'Me.DsPlan1.AcceptChanges()
            Me.setCheckBoxesPatientsUsers()
            If SelectID And Not Me._IDToSelect Is Nothing Then
                Me.SelectListViewItemBenutzerPatient(Me._IDToSelect, IDFoundInTree)
            End If
            Me.setLabelCount2()

            Me._UserCanChangeBenutzerPatients = UserCanChangeBenutzerPatientsTmp

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadBenutzerPatients: " + ex.ToString())
        End Try
    End Sub

    Public Sub autoSelectAllForAbtBereich(IDAbteilung As Guid, IDBereich As Guid, SelectAll As Boolean, IDToSelect As Nullable(Of Guid),
                                          bEditable As Boolean, TypeUIMain As contPlanungData.eTypeUI, ByRef IDFoundInTree As Boolean)
        Try
            Me._UserCanChangeBenutzerPatients = True
            Me.DsPlan1.Clear()
            Me._IDToSelect = IDToSelect
            Me._TypeUIMain = TypeUIMain

            Dim nodeAbtBereicheReturn As UltraTreeNode = Nothing
            If IDAbteilung.Equals(Guid.Empty) And IDBereich.Equals(Guid.Empty) Then
                Me.loadBenutzerPatients(Nothing, Nothing, Nothing, SelectAll, True, IDFoundInTree)
                Me.utreeAbtBereiche.ActiveNode = Me.utreeAbtBereiche.Nodes(0)

            ElseIf (Not IDAbteilung.Equals(Guid.Empty)) And IDBereich.Equals(Guid.Empty) Then
                Me.loadBenutzerPatients(IDAbteilung, Nothing, Nothing, SelectAll, True, IDFoundInTree)
                Me.selectAbteilungBereich(IDAbteilung, Me.utreeAbtBereiche.Nodes(0), True, nodeAbtBereicheReturn)

            ElseIf IDAbteilung.Equals(Guid.Empty) And (Not IDBereich.Equals(Guid.Empty)) Then
                Me.loadBenutzerPatients(Nothing, IDBereich, Nothing, SelectAll, True, IDFoundInTree)
                Me.selectAbteilungBereich(IDBereich, Me.utreeAbtBereiche.Nodes(0), True, nodeAbtBereicheReturn)

            ElseIf (Not IDAbteilung.Equals(Guid.Empty)) And (Not IDBereich.Equals(Guid.Empty)) Then
                Me.loadBenutzerPatients(IDAbteilung, IDBereich, Nothing, SelectAll, True, IDFoundInTree)
                Me.selectAbteilungBereich(IDBereich, Me.utreeAbtBereiche.Nodes(0), True, nodeAbtBereicheReturn)
            End If

            If Not nodeAbtBereicheReturn Is Nothing Then
                Me.utreeAbtBereiche.ActiveNode = nodeAbtBereicheReturn
            End If
            If Not IDToSelect Is Nothing Then
                IDFoundInTree = False
                Me.SelectListViewItemBenutzerPatient(IDToSelect, IDFoundInTree)
            End If

            Me.setLabelCount2()
            Me._UserCanChangeBenutzerPatients = bEditable

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadBenutzerPatients: " + ex.ToString())
        End Try
    End Sub
    Public Sub SelectListViewItemBenutzerPatient(ID As Guid, Optional ByRef IDFoundInTree As Boolean = False)
        Try
            For Each lstNodBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatients.Items
                Dim tgBenutzerPatient As cTgListViews = lstNodBenutzerPatient.Tag
                If tgBenutzerPatient.ID.Equals(ID) Then
                    lstNodBenutzerPatient.CheckState = Windows.Forms.CheckState.Checked
                    If Not Me.checkPlanExistsInDataSet(tgBenutzerPatient.ID) Then
                        Me.addObjectToSelected(tgBenutzerPatient.ID, Me._IDPlan, lstNodBenutzerPatient.Text.Trim())
                    End If

                    If SendEventPatientUsersWhenSelectChanged Then
                        Me.treeBenutzerPatients.ActiveItem = lstNodBenutzerPatient
                    End If

                    IDFoundInTree = True
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.SelectListViewItemBenutzerPatient: " + ex.ToString())
        End Try
    End Sub
    Public Sub addIDObjectToList(ByRef IDObjectToAdd As Guid)
        Try
            Me.addObjectToSelected(IDObjectToAdd, Me._IDPlan, "")

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.addIDObjectToList: " + ex.ToString())
        End Try
    End Sub

    Public Sub selectAbteilungBereich(ByRef ID As Guid, ByRef nodParent As UltraTreeNode, isFirst As Boolean, ByRef nodeAbtBereicheReturn As UltraTreeNode)
        Try
            If isFirst Then
                Me.utreeAbtBereiche.SelectedNodes.Clear()
                Me.utreeAbtBereiche.ActiveNode = Nothing
            End If
            For Each nodeAbtBereiche As UltraTreeNode In nodParent.Nodes
                Dim TgTreeNodeAbtBereiche As cTgListViews = nodeAbtBereiche.Tag
                If TgTreeNodeAbtBereiche.ID.Equals(ID) Then
                    nodeAbtBereicheReturn = nodeAbtBereiche
                    Me.utreeAbtBereiche.ActiveNode = nodeAbtBereiche
                End If

                Me.selectAbteilungBereich(ID, nodeAbtBereiche, False, nodeAbtBereicheReturn)
            Next

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.selectAbteilungBereich_rek: " + ex.ToString())
        End Try
    End Sub
    Public Sub getSelectedAbtBereich(ByRef IDKlinikReturn As Nullable(Of Guid), ByRef IDAbteilungReturn As Nullable(Of Guid), ByRef IDBereichReturn As Nullable(Of Guid),
                                        ByRef nodParent As UltraTreeNode, isFirst As Boolean)
        Try
            If isFirst Then
                nodParent = Me.utreeAbtBereiche.Nodes(0)
            End If
            For Each nodeAbtBereiche As UltraTreeNode In nodParent.Nodes
                Dim TgTreeNodeAbtBereiche As cTgListViews = nodeAbtBereiche.Tag
                If nodeAbtBereiche.IsActive() Then
                    If TgTreeNodeAbtBereiche.TypeListViewTag = eTypeListViewTag.Klinik Then
                        IDKlinikReturn = TgTreeNodeAbtBereiche.ID
                        IDAbteilungReturn = System.Guid.Empty
                        IDBereichReturn = System.Guid.Empty

                    ElseIf TgTreeNodeAbtBereiche.TypeListViewTag = eTypeListViewTag.Abteilung Then
                        Dim TgTreeNodeParentklinik As cTgListViews = nodeAbtBereiche.Parent.Tag
                        IDKlinikReturn = TgTreeNodeParentklinik.ID
                        IDAbteilungReturn = TgTreeNodeAbtBereiche.ID
                        IDBereichReturn = System.Guid.Empty

                    ElseIf TgTreeNodeAbtBereiche.TypeListViewTag = eTypeListViewTag.Bereich Then
                        Dim TgTreeNodeParentklinik As cTgListViews = nodeAbtBereiche.Parent.Parent.Tag
                        IDKlinikReturn = TgTreeNodeParentklinik.ID
                        Dim TgTreeNodeParentAbt As cTgListViews = nodeAbtBereiche.Parent.Tag
                        IDAbteilungReturn = TgTreeNodeParentAbt.ID
                        IDBereichReturn = TgTreeNodeAbtBereiche.ID

                    Else
                        Throw New Exception("getSelectedAbtBereich: TgTreeNodeAbtBereiche.TypeListViewTag '" + TgTreeNodeAbtBereiche.TypeListViewTag.ToString() + "' not allowed!")
                    End If
                End If

                Me.getSelectedAbtBereich(IDKlinikReturn, IDAbteilungReturn, IDBereichReturn, nodeAbtBereiche, False)
            Next

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadBenutzerPatientsClick: " + ex.ToString())
        End Try
    End Sub
    Public Function getSelectedBenutzerPatient(ByRef WithMsgBox As Boolean) As UltraListViewItem
        Try
            If Me.treeBenutzerPatients.SelectedItems.Count = 1 Then
                Return Me.treeBenutzerPatients.SelectedItems(0)
            ElseIf Me.treeBenutzerPatients.SelectedItems.Count = 0 Then
                If WithMsgBox Then
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "PMDS", MessageBoxButtons.OK)
                End If
                Return Nothing
            Else
                Throw New Exception("contSelectPatientenBenutzer.getSelectedBenutzerPatient: Me.treeBenutzerPatients.SelectedItems.Count>1 not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getSelectedBenutzerPatient: " + ex.ToString())
        End Try
    End Function
    Public Function getSelectedTreeSelected(ByRef WithMsgBox As Boolean) As UltraListViewItem
        Try
            If Me.treeBenutzerPatientsSelected.SelectedItems.Count = 1 Then
                Return Me.treeBenutzerPatientsSelected.SelectedItems(0)
            ElseIf Me.treeBenutzerPatientsSelected.SelectedItems.Count = 0 Then
                If WithMsgBox Then
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "PMDS", MessageBoxButtons.OK)
                End If
                Return Nothing
            Else
                Throw New Exception("contSelectPatientenBenutzer.getSelectedTreeSelected: Me.treeBenutzerPatientsSelected.SelectedItems.Count>1 not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getSelectedTreeSelected: " + ex.ToString())
        End Try
    End Function

    Public Sub setCheckBoxesPatientsUsers()
        Try
            For Each itmBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatients.Items
                Dim tbBenutzerPatient As cTgListViews = itmBenutzerPatient.Tag
                Dim arrPlanObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + tbBenutzerPatient.ID.ToString() + "'", "")
                If arrPlanObjects.Length >= 1 Then
                    itmBenutzerPatient.CheckState = Windows.Forms.CheckState.Checked
                    Me.addObjectToSelected(tbBenutzerPatient.ID, Me._IDPlan, itmBenutzerPatient.Text.Trim(), True)

                    'ElseIf arrPlanObjects.Length > 1 Then
                    '    Throw New Exception("setCheckBoxesPatientsUsers: arrPlanObjects.Length>1 not allowed!")
                End If
            Next

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rPlanObject As dsPlan.planObjectRow In Me.DsPlan1.planObject.Rows
                    If rPlanObject.RowState <> DataRowState.Deleted Then
                        Me.addObjectToSelected2(rPlanObject.IDObject, False)
                    End If
                Next
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.setCheckBoxesPatientsUsers: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadCboBerufsstand()
        Try
            Me.cboBerufsgruppen.Items.Clear()

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False

                Dim tAuswahlListe As List(Of PMDS.db.Entities.AuswahlListe) = Me.bRAM.GetAuswahlliste(db, "BER", 0)
                For Each rAuswahlliste As PMDS.db.Entities.AuswahlListe In tAuswahlListe
                    Dim itm As ValueListItem = Me.cboBerufsgruppen.Items.Add(rAuswahlliste.ID, rAuswahlliste.Bezeichnung.Trim())

                    Dim Berufsgruppe As New cBerufsgruppe()
                    Berufsgruppe.IDAuswahliste = rAuswahlliste.ID
                    Dim txtIstGruppe As String = ""
                    If rAuswahlliste.IstGruppe Then
                        txtIstGruppe = " (Group)"
                    End If
                    Berufsgruppe.Bezeichnung = rAuswahlliste.Bezeichnung.Trim() + txtIstGruppe
                    Berufsgruppe.GehörtzuGruppe = rAuswahlliste.GehörtzuGruppe.Trim()
                    Berufsgruppe.IstGruppe = rAuswahlliste.IstGruppe
                    itm.Tag = Berufsgruppe
                Next
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadCboBerufsstand: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData2(ByRef IDPlan As Guid, ByRef tPlanObjectsAllCopy As dsPlan.planObjectDataTable, ByRef doNew As Boolean)
        Try
            Me._IDPlan = IDPlan

            Me.DsPlan1.Clear()
            Me.CompPlan1.getPlanObject(Me._IDPlan, compPlan.eTypSelPlanObject.allIDPlan, Me.DsPlan1)

            Dim lstPlansObjToDelete As New System.Collections.Generic.List(Of dsPlan.planObjectRow)
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False

                For Each rPlanObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                    If Me._TypeUI = eTypeUI.Patients Then
                        If Not Me.b.checkIDIsPatient(rPlanObj.IDObject, db) Then
                            lstPlansObjToDelete.Add(rPlanObj)
                        End If
                    ElseIf Me._TypeUI = eTypeUI.Users Then
                        If Not Me.b.checkIDIsBenutzer(rPlanObj.IDObject, db) Then
                            lstPlansObjToDelete.Add(rPlanObj)
                        End If
                    End If
                Next
            End Using

            For Each rPlanObjectToDelete As dsPlan.planObjectRow In lstPlansObjToDelete
                Me.deleteObjectFromSelected(rPlanObjectToDelete.IDObject)
                rPlanObjectToDelete.Delete()
            Next
            Me.DsPlan1.planObject.AcceptChanges()

            Me.setCheckBoxesPatientsUsers()

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadDataColl(ByRef sGuids As String)
        Try
            Me.initControlData()

            Me.DsPlan1.Clear()
            Dim lstGuid As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(sGuids.Trim())
            For Each sGuid As String In lstGuid
                Me.addObjectToSelected(New System.Guid(sGuid.Trim()), Me._IDPlan, "")
            Next
            'Me.DsPlan1.AcceptChanges()

            Me.setCheckBoxesPatientsUsers()
            If Me._IsTextTemplate Then
                Me.genDescriptionForSelections()
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadDataColl: " + ex.ToString())
        End Try
    End Sub

    Public Function getList() As System.Collections.Generic.List(Of Guid)
        Try
            Dim lst As New System.Collections.Generic.List(Of Guid)()
            For Each rPlanObject As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rPlanObject.RowState <> DataRowState.Deleted Then
                    lst.Add(rPlanObject.IDObject)
                End If
            Next

            Return lst

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getList: " + ex.ToString())
        End Try
    End Function
    Public Function getObjectInfo(ByRef getInfoPatients As Boolean, getInfoUsers As Boolean, ByRef iCounter As Integer) As String
        Try
            Dim clPlan1 As New clPlan()
            Dim sInfo As String = clPlan1.getObjectsPlanInfos(Me.DsPlan1, getInfoPatients, getInfoUsers, iCounter)
            Return sInfo

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getObjectInfo: " + ex.ToString())
        End Try
    End Function

    Public Function validatedata() As Boolean
        Try
            For Each rPlanObject As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rPlanObject.RowState <> DataRowState.Deleted Then
                    Dim arrPlanObjectsCheckDoubledIDObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + rPlanObject.IDObject.ToString() + "' and ID<>'" + rPlanObject.ID.ToString() + "'", "")
                    If arrPlanObjectsCheckDoubledIDObjects.Length > 0 Then
                        Throw New Exception("contSelectPatientenBenutzer.validatedata: arrPlanObjectsCheckDoubledIDObjects.Length>0 in IDPlan'" + Me._IDPlan.ToString() + "', TypeUI:'" + Me._TypeUI.ToString() + "' not allowed!")
                    End If
                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.validatedata: " + ex.ToString())
        End Try
    End Function
    Public Function saveData() As Boolean
        Try
            If Not Me.validatedata() Then
                Return False
            End If

            Me.CompPlan1.daPlanObject.Update(Me.DsPlan1.planObject)
            Return True

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.saveData: " + ex.ToString())
        End Try
    End Function
    Public Function getDataColl() As String
        Try
            Dim sGuidsReturn As String = ""
            For Each rPlanObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rPlanObj.RowState <> DataRowState.Deleted Then
                    sGuidsReturn += rPlanObj.IDObject.ToString() + ";"
                End If
            Next
            Return sGuidsReturn.Trim()

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getDataColl: " + ex.ToString())
        End Try
    End Function

    Public Sub copyPlanObjects(ByRef dsToCopy As dsPlan, ByRef IDPlan As Guid)
        Try
            For Each rPlanObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rPlanObj.RowState <> DataRowState.Deleted Then
                    Dim rNewPlanObject As dsPlan.planObjectRow = Me.CompPlan1.getNewRowPlanObject(dsToCopy.planObject)
                    rNewPlanObject.ID = System.Guid.NewGuid()
                    rNewPlanObject.IDObject = rPlanObj.IDObject
                    rNewPlanObject.IDPlan = IDPlan
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.copyPlanObjects: " + ex.ToString())
        End Try
    End Sub

    Public Sub SelectAllNoneBenutzerPatients(bOn As System.Windows.Forms.CheckState)
        Try
            For Each itm As UltraListViewItem In Me.treeBenutzerPatients.Items
                If itm.Visible Then
                    itm.CheckState = bOn
                    Dim itmSel As cTgListViews = itm.Tag

                    If bOn = Windows.Forms.CheckState.Checked Then
                        If Not Me.checkPlanExistsInDataSet(itmSel.ID) Then
                            Me.addObjectToSelected(itmSel.ID, Me._IDPlan, itm.Text.Trim())
                            If Me._IsTextTemplate Then
                                Me.genDescriptionForSelections()
                            End If
                        End If
                    Else
                        Dim arrPlanObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + itmSel.ID.ToString() + "'", "")
                        If arrPlanObjects.Length >= 1 Then
                            For Each rPlan In arrPlanObjects
                                Dim rPlanObject As dsPlan.planObjectRow = arrPlanObjects(0)
                                Me.deleteObjectFromSelected(rPlanObject.IDObject)
                                rPlanObject.Delete()
                            Next
                            If Me._IsTextTemplate Then
                                Me.genDescriptionForSelections()
                            End If

                        ElseIf arrPlanObjects.Length > 1 Then
                            Throw New Exception("treeBenutzerPatients_ItemCheckStateChanged: arrPlanObjects.Length>1 not allowed!")
                        End If
                    End If
                End If
            Next

            Me.setLabelCount2()

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.SelectAllNoneBenutzerPatients: " + ex.ToString())
        End Try
    End Sub

    Public Function checkPlanExistsInDataSet(ByRef IDObject As Guid) As Boolean
        Try
            Dim arrPlanObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + IDObject.ToString() + "'", "")
            If arrPlanObjects.Length = 0 Then
                Return False
            ElseIf arrPlanObjects.Length = 1 Then
                Return True
            Else
                Throw New Exception("contSelectPatientenBenutzer.checkPlanExistsInDataSet: arrPlanObjects.Length>1 not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.checkPlanExistsInDataSet: " + ex.ToString())
        End Try
    End Function


    Public Function getSelectedBerufsgruppe(ByRef SelectOK As Boolean) As Nullable(Of Guid)
        Try
            If Me.cboBerufsgruppen.Value Is Nothing Then
                SelectOK = True
                Return Nothing
            Else
                If Me.cboBerufsgruppen.Value.GetType().Equals(GetType(Guid)) Then
                    Dim Berufsgruppe As cBerufsgruppe = Me.cboBerufsgruppen.SelectedItem.Tag
                    SelectOK = True
                    Return Berufsgruppe.IDAuswahliste
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.getSelectedBerufsgruppe: " + ex.ToString())
        End Try
    End Function


    Public Sub loadBenutzerPatientsClick()
        Try
            If Not Me.utreeAbtBereiche.ActiveNode Is Nothing Then
                Dim itmSel As cTgListViews = Me.utreeAbtBereiche.ActiveNode.Tag

                If Me._TypeUI <> eTypeUI.AbtBereich Then
                    Dim SelectOK As Boolean = False
                    Dim IDBerufsgruppe As Nullable(Of Guid) = Me.getSelectedBerufsgruppe(SelectOK)
                    If SelectOK Then
                        If itmSel.TypeListViewTag = eTypeListViewTag.Klinik Then
                            Me.loadBenutzerPatients(Nothing, Nothing, IDBerufsgruppe, Me._IsSearch, Me._clearTreeSelected, False, False)
                        ElseIf itmSel.TypeListViewTag = eTypeListViewTag.Abteilung Then
                            Me.loadBenutzerPatients(itmSel.ID, Nothing, IDBerufsgruppe, Me._IsSearch, Me._clearTreeSelected, False, False)
                        ElseIf itmSel.TypeListViewTag = eTypeListViewTag.Bereich Then
                            Me.loadBenutzerPatients(Nothing, itmSel.ID, IDBerufsgruppe, Me._IsSearch, Me._clearTreeSelected, False, False)
                        Else
                            Throw New Exception("treeAbtBereiche_ItemCheckStateChanged: itmSel.TypeListViewTag '" + itmSel.TypeListViewTag.ToString() + "' not allowed!")
                        End If
                    End If
                Else
                    If Me.SendEventAbtBereicheWhenSelectChanged Then
                        Dim IDKlinik As Nullable(Of Guid) = Nothing
                        Dim IDAbteilung As Nullable(Of Guid) = Nothing
                        Dim IDBereich As Nullable(Of Guid) = Nothing
                        Dim treeNode As UltraTreeNode = Nothing
                        Me.getSelectedAbtBereich(IDKlinik, IDAbteilung, IDBereich, treeNode, True)

                        PMDS.Global.ENV.AbtBereichPickerValueChanged(IDKlinik, IDAbteilung, IDBereich, treeNode)
                    End If
                End If
            Else
                Dim SelectOK As Boolean = False
                Dim IDBerufsgruppe As Nullable(Of Guid) = Me.getSelectedBerufsgruppe(SelectOK)
                If SelectOK Then
                    If Me._TypeUI <> eTypeUI.AbtBereich Then
                        Me.loadBenutzerPatients(Nothing, Nothing, IDBerufsgruppe, Me._IsSearch, Me._clearTreeSelected)
                    Else
                        If Me.SendEventAbtBereicheWhenSelectChanged Then
                            Dim IDKlinik As Nullable(Of Guid) = Nothing
                            Dim IDAbteilung As Nullable(Of Guid) = Nothing
                            Dim IDBereich As Nullable(Of Guid) = Nothing
                            Dim treeNode As UltraTreeNode = Nothing
                            Me.getSelectedAbtBereich(IDKlinik, IDAbteilung, IDBereich, treeNode, True)

                            PMDS.Global.ENV.AbtBereichPickerValueChanged(IDKlinik, IDAbteilung, IDBereich, treeNode)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.loadBenutzerPatientsClick: " + ex.ToString())
        End Try
    End Sub

    Public Function setLabelCount2() As String
        Try
            Dim IDTransTxt As String = ""
            Dim IDRes As String = ""

            If Me._TypeUI = eTypeUI.Patients Then
                IDRes = "Patienten"
                IDTransTxt = doUI.getRes(IDRes.Trim())
            ElseIf Me._TypeUI = eTypeUI.Users Then
                IDRes = "Benutzer"
                IDTransTxt = doUI.getRes(IDRes.Trim())
            End If
            If Me.LabelPickerAlternate.Trim() <> "" Then
                IDTransTxt = doUI.getRes(Me.LabelPickerAlternate.Trim())
            End If

            Dim sNamesSelected As String = ""
            Dim iCounter As Integer = 0
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim iCounterFoundSelected As Integer = 0
                For Each rPlanObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                    If rPlanObj.RowState <> DataRowState.Deleted Then
                        If Me.setSelectededTxt_Name Then
                            Dim sNamesSelectedTmp As String = Me.b.getPatientsName(rPlanObj.IDObject, db)
                            sNamesSelected += IIf(sNamesSelected.Trim() = "", sNamesSelectedTmp.Trim(), ";" + sNamesSelectedTmp.Trim())
                            iCounterFoundSelected += 1
                        End If
                        iCounter += 1
                    End If
                Next

                If Me._SingleSelect Then
                    If iCounterFoundSelected > 1 Then
                        Throw New Exception("contSelectPatientBenutzer.setLabelCount2: iCounterFoundSelected > 1 not allowed!")
                    End If
                End If
            End Using

            Dim sTxtReturn As String = ""
            If Me.bShowAlleWhen0Selected And iCounter = 0 Then
                sTxtReturn = IDTransTxt + " (" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle") + ")"
            Else
                sTxtReturn = IDTransTxt + " (" + iCounter.ToString() + ")"
            End If

            If Not Me._dropDownButton Is Nothing Then
                If Me.setSelectededTxt_Name Then
                    If sNamesSelected.Trim() <> "" Then
                        Me._dropDownButton.Text = sNamesSelected
                    End If
                Else
                    Me._dropDownButton.Text = sTxtReturn
                End If
            End If
            Return sTxtReturn.Trim()

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.setLabelCount: " + ex.ToString())
        End Try
    End Function

    Public Sub searchInTree(ByRef txtToSearch As String)
        Try
            For Each nodeBenPatient As UltraListViewItem In Me.treeBenutzerPatients.Items
                If txtToSearch.Trim() = "" Then
                    nodeBenPatient.Visible = True
                Else
                    If nodeBenPatient.Text.Trim().ToLower().Contains(txtToSearch.Trim().ToLower()) Then
                        nodeBenPatient.Visible = True
                    Else
                        nodeBenPatient.Visible = False
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.searchInTree: " + ex.ToString())
        End Try
    End Sub

    Private Sub cboBerufsgruppen_ValueChanged(sender As Object, e As EventArgs) Handles cboBerufsgruppen.ValueChanged
        Try
            If Me.cboBerufsgruppen.Focused Then
                Me.loadBenutzerPatientsClick()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub utreeAbtBereiche_Click(sender As Object, e As EventArgs) Handles utreeAbtBereiche.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim sitemap1 As New PMDS.Global.UIGlobal()
            If sitemap1.evClickOKTree(sender, e, Me.utreeAbtBereiche) Then
                If Not Me.utreeAbtBereiche.ActiveNode Is Nothing Then
                    Me.loadBenutzerPatientsClick()
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub treeBenutzerPatients_Click(sender As Object, e As EventArgs) Handles treeBenutzerPatients.Click
        Try


        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub treeBenutzerPatients_ItemCheckStateChanging(sender As Object, e As ItemCheckStateChangingEventArgs) Handles treeBenutzerPatients.ItemCheckStateChanging
        Try
            If Me.TreeLockItemChangedReadyLoad Then
                'e.Item.CheckState = CheckState.Unchecked
                Exit Sub
            End If

            If Me.TreeLockItemChanged Then
                Exit Sub
            End If

            If Not Me._UserCanChangeBenutzerPatients Then
                e.Cancel = True
            End If

            'If Me._SingleSelect Then
            '    Me.TreeLockItemChanged = True
            '    Me.SelectAllNoneBenutzerPatients(Windows.Forms.CheckState.Unchecked)
            '    e.Item.CheckState = Windows.Forms.CheckState.Checked
            '    Me.TreeLockItemChanged = False
            'End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub treeBenutzerPatients_ItemCheckStateChanged(sender As Object, e As Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventArgs) Handles treeBenutzerPatients.ItemCheckStateChanged
        Try
            If Me.TreeLockItemChangedReadyLoad Then
                Exit Sub
            End If

            If Me.TreeLockItemChanged Then
                Exit Sub
            End If

            Dim sitemap1 As New PMDS.Global.UIGlobal()
            If sitemap1.evClickOKListView(sender, e, Me.treeBenutzerPatients) Then
                If Not e.Item Is Nothing Then
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Application.DoEvents()
                    Me.treeBenutzerPatientsItemCheckStateChanged(e.Item, True)
                End If
            End If

        Catch ex As Exception
            Me.TreeLockItemChanged = False
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            If Not Me.TreeLockItemChanged And Me.SendEventPatientUsersWhenSelectChanged Then
                If Not Me._dropDownButton Is Nothing Then
                    Me._dropDownButton.CloseUp()
                End If
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub treeBenutzerPatientsItemCheckStateChanged(ByRef itm As UltraListViewItem, mustChecked As Boolean)
        Try
            If Me.TreeLockItemChangedReadyLoad Then
                Exit Sub
            End If

            Me.TreeLockItemChangedReadyLoad = True
            Dim sitemap1 As New PMDS.Global.UIGlobal()

            Dim itmSel As cTgListViews = itm.Tag
            Me.treeBenutzerPatients.ActiveItem = itm

            If (itm.CheckState = Windows.Forms.CheckState.Checked And mustChecked) Or (Not mustChecked) Then
                If Me._SingleSelect Then
                    Me.TreeLockItemChanged = True
                    Me.SelectAllNoneBenutzerPatients(Windows.Forms.CheckState.Unchecked)
                    If Me._clearTreeSelected Then
                        Me.treeBenutzerPatientsSelected.Items.Clear()
                        Me.DsPlan1.planObject.Rows.Clear()
                        Me.DsPlan1.planObject.AcceptChanges()
                    End If
                    itm.CheckState = Windows.Forms.CheckState.Checked
                    Me.TreeLockItemChanged = False

                End If
                If Not Me.checkPlanExistsInDataSet(itmSel.ID) Then
                    If Me._SingleSelect Then
                        Me._IDToSelect = itmSel.ID
                    End If
                    Me.addObjectToSelected(itmSel.ID, Me._IDPlan, itm.Text.Trim())
                    If Me._IsTextTemplate Then
                        Me.genDescriptionForSelections()
                    End If
                End If
            Else
                Dim arrPlanObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + itmSel.ID.ToString() + "'", "")
                If arrPlanObjects.Length >= 1 Then
                    For Each rPlan In arrPlanObjects
                        Dim rPlanObject As dsPlan.planObjectRow = arrPlanObjects(0)
                        Me.deleteObjectFromSelected(rPlanObject.IDObject)
                        rPlanObject.Delete()
                    Next
                    If Me._IsTextTemplate Then
                        Me.genDescriptionForSelections()
                    End If

                ElseIf arrPlanObjects.Length > 1 Then
                    Throw New Exception("treeBenutzerPatients_ItemCheckStateChanged: arrPlanObjects.Length>1 not allowed!")
                End If
            End If

            Me.setLabelCount2()

            Dim IDKlinik As Nullable(Of Guid) = Nothing
            Dim IDAbteilung As Nullable(Of Guid) = Nothing
            Dim IDBereich As Nullable(Of Guid) = Nothing
            Dim treeNode As UltraTreeNode = Nothing
            Me.getSelectedAbtBereich(IDKlinik, IDAbteilung, IDBereich, treeNode, True)

            If Me.SendEventPatientUsersWhenSelectChanged Then
                Dim lstSelectedUsersPatients As System.Collections.Generic.List(Of Guid) = Me.getList()
                PMDS.Global.ENV.PatientenUersPickerValueChanged(IDAbteilung, IDBereich, Nothing, lstSelectedUsersPatients, treeNode, Me._TypePatientenUserPickerChanged)
            End If

            Me.TreeLockItemChangedReadyLoad = False

        Catch ex As Exception
            Me.TreeLockItemChangedReadyLoad = False
            Me.TreeLockItemChanged = False
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            If Me.SendEventPatientUsersWhenSelectChanged Then
                If Not Me._dropDownButton Is Nothing Then
                    Me._dropDownButton.CloseUp()
                End If
            End If
        End Try
    End Sub

    Private Sub treeBenutzerPatients_DoubleClick(sender As Object, e As EventArgs) Handles treeBenutzerPatients.DoubleClick
        Try
            Dim selItmUserPatient As UltraListViewItem = Me.getSelectedBenutzerPatient(False)
            If Not selItmUserPatient Is Nothing Then
                Me.treeBenutzerPatientsItemCheckStateChanged(selItmUserPatient, False)
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub addObjectToSelected(ByRef IDObject As Guid, ByRef IDPlan As Guid, ByRef txt As String, Optional OnlyAddToTreeSelected As Boolean = False)
        Try
            If Not OnlyAddToTreeSelected Then
                Dim rNewPlanObject As dsPlan.planObjectRow = Me.CompPlan1.getNewRowPlanObject(Me.DsPlan1.planObject)
                rNewPlanObject.IDObject = IDObject
                rNewPlanObject.IDPlan = IDPlan
            End If

            If txt.Trim() <> "" Then
                Dim bObjectExists As Boolean = False
                For Each lstNodBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatientsSelected.Items
                    If lstNodBenutzerPatient.Key.Trim().ToLower().Equals(IDObject.ToString().Trim().ToLower()) Then
                        bObjectExists = True
                    End If
                Next

                If Not bObjectExists Then
                    Dim itmBenutzerPatients As UltraListViewItem = Me.treeBenutzerPatientsSelected.Items.Add(IDObject.ToString(), txt.Trim())
                    itmBenutzerPatients.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32)
                    If Me.checkPatientIsAbwesend(IDObject) Then
                        itmBenutzerPatients.Appearance.ForeColor = Drawing.Color.Red
                    Else
                        itmBenutzerPatients.Appearance.ForeColor = Drawing.Color.Black
                    End If
                    Me.treeBenutzerPatients.Items.RefreshSort(True)
                End If

                'If Not Me.treeBenutzerPatientsSelected.Items.Contains(IDObject) Then
                '    Dim itmBenutzerPatients As UltraListViewItem = Me.treeBenutzerPatientsSelected.Items.Add(IDObject.ToString(), txt.Trim())
                '    Me.treeBenutzerPatients.Items.RefreshSort(True)
                'End If
            End If

        Catch ex As Exception
            Throw New Exception("addObjectToSelected: " + ex.ToString())
        End Try
    End Sub
    Public Sub addObjectToSelected2(IDObject As Guid, addToDsPlanSelected As Boolean)
        Try
            Dim bObjectExists As Boolean = False
            For Each lstNodBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatientsSelected.Items
                If lstNodBenutzerPatient.Key.Trim().ToLower().Equals(IDObject.ToString().Trim().ToLower()) Then
                    bObjectExists = True
                End If
            Next

            If Not bObjectExists Then
                If addToDsPlanSelected Then
                    Dim rNewPlanObject As dsPlan.planObjectRow = Me.CompPlan1.getNewRowPlanObject(Me.DsPlan1.planObject)
                    rNewPlanObject.IDObject = IDObject
                    rNewPlanObject.IDPlan = Me._IDPlan
                End If

                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    If Me._TypeUI = eTypeUI.Patients Then
                        Dim sNamesSelectedTmp As String = Me.b.getPatientsName(IDObject, db)
                        Dim itmBenutzerPatients As UltraListViewItem = Me.treeBenutzerPatientsSelected.Items.Add(IDObject.ToString(), sNamesSelectedTmp.Trim())
                        If Me.checkPatientIsAbwesend(IDObject) Then
                            itmBenutzerPatients.Appearance.ForeColor = Drawing.Color.Red
                        Else
                            itmBenutzerPatients.Appearance.ForeColor = Drawing.Color.Black
                        End If
                        itmBenutzerPatients.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32)
                        Me.treeBenutzerPatients.Items.RefreshSort(True)

                    ElseIf Me._TypeUI = eTypeUI.Users Then
                        Dim bAdd As Boolean = True
                        If Me.noExceptionIfUserNotFound Then
                            Dim UserExists As Boolean = Me.b.checkIfUserExists(IDObject, db)
                            If Not UserExists Then
                                bAdd = False
                            End If
                        End If
                        If bAdd Then
                            Dim rBenutzer As PMDS.db.Entities.Benutzer = Me.b.getUser(IDObject, db)
                            Dim sNameSelectedTmp As String = rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " (" + rBenutzer.Benutzer1.Trim() + ")"
                            Dim itmBenutzerPatients As UltraListViewItem = Me.treeBenutzerPatientsSelected.Items.Add(IDObject.ToString(), sNameSelectedTmp.Trim())
                            itmBenutzerPatients.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32)
                            Me.treeBenutzerPatients.Items.RefreshSort(True)
                        End If
                    Else
                        Throw New Exception("addObjectToSelected2: not allowed!")
                    End If
                End Using
            End If

        Catch ex As Exception
            Throw New Exception("addObjectToSelected2: " + ex.ToString())
        End Try
    End Sub

    Public Function checkPatientIsAbwesend(ByRef IDPatient As Guid) As Boolean
        Try
            Dim listAbwesPatients As List(Of Guid) = Me.bRAM.getListAbwesendePatients()
            If listAbwesPatients.Contains(IDPatient) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("checkPatientIsAbwesend: " + ex.ToString())
        End Try
    End Function

    Public Sub setIconToSelectedObjects(IDObject As Nullable(Of Guid), clearIcon As Boolean, SetTransparentIconWhenNoKey As Boolean)
        Try
            For Each lstNodBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatientsSelected.Items
                If clearIcon Then
                    lstNodBenutzerPatient.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32)
                Else
                    If lstNodBenutzerPatient.Key.Trim().ToLower().Equals(IDObject.Value.ToString().Trim().ToLower()) Then
                        lstNodBenutzerPatient.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32)
                    Else
                        If SetTransparentIconWhenNoKey Then
                            lstNodBenutzerPatient.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("setIconToSelectedObjects: " + ex.ToString())
        End Try
    End Sub

    Public Sub deleteObjectFromSelected2(ByRef IDObjectToDelete As Guid)
        Try
            Dim arrPlanObjects() As dsPlan.planObjectRow = Me.DsPlan1.planObject.Select("IDObject='" + IDObjectToDelete.ToString() + "'", "")
            If arrPlanObjects.Length >= 1 Then
                For Each rPlan In arrPlanObjects
                    For Each itmBenutzerPatients As UltraListViewItem In Me.treeBenutzerPatients.Items
                        Dim tgListViewBenutzerUsers As cTgListViews = itmBenutzerPatients.Tag
                        If tgListViewBenutzerUsers.ID.Equals(rPlan.IDObject) Then
                            itmBenutzerPatients.CheckState = CheckState.Unchecked
                        End If
                    Next

                    Me.deleteObjectFromSelected(rPlan.IDObject)
                    rPlan.Delete()
                Next
                If Me._IsTextTemplate Then
                    Me.genDescriptionForSelections()
                End If

            ElseIf arrPlanObjects.Length > 1 Then
                Throw New Exception("deleteObjectFromSelected2: arrPlanObjects.Length>1 not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("deleteObjectFromSelected2: " + ex.ToString())
        End Try
    End Sub

    Public Sub deleteObjectFromSelected(ByRef IDObject As Guid)
        Try
            Dim lstItemsToRemove As New System.Collections.Generic.List(Of UltraListViewItem)
            For Each lstNodBenutzerPatient As UltraListViewItem In Me.treeBenutzerPatientsSelected.Items
                If lstNodBenutzerPatient.Key.ToLower().Equals(IDObject.ToString().ToLower()) Then
                    lstItemsToRemove.Add(lstNodBenutzerPatient)
                End If
            Next

            For Each lstNodBenutzerPatient As UltraListViewItem In lstItemsToRemove
                Me.treeBenutzerPatientsSelected.Items.Remove(lstNodBenutzerPatient)
            Next

        Catch ex As Exception
            Throw New Exception("deleteObjectFromSelected: " + ex.ToString())
        End Try
    End Sub

    Public Sub genDescriptionForSelections()
        Try
            If Me._TypeUI = eTypeUI.Users Then
                Me.MainTextTemplates.txtBenutzer.Text = ""
            ElseIf Me._TypeUI = eTypeUI.Patients Then
                Me.MainTextTemplates.txtPatienten.Text = ""
            End If

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim sDescription As String = ""
                For Each rPlanObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                    If rPlanObj.RowState <> DataRowState.Deleted Then
                        If Me._TypeUI = eTypeUI.Users Then
                            Dim rUsr As PMDS.db.Entities.Benutzer = Me.b.getUser(rPlanObj.IDObject, db)
                            sDescription += rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim() + ";"
                        ElseIf Me._TypeUI = eTypeUI.Patients Then
                            Dim rPatient As PMDS.db.Entities.Patient = Me.b.getPatient(rPlanObj.IDObject, db)
                            sDescription += rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + ";"
                        Else
                            Throw New Exception("genDescriptionForSelections.loadData: Me._TypeUI '" + Me._TypeUI.ToString() + "' not allowed!")
                        End If
                    End If
                Next

                If Me._TypeUI = eTypeUI.Users Then
                    Me.MainTextTemplates.txtBenutzer.Text = sDescription.Trim()
                ElseIf Me._TypeUI = eTypeUI.Patients Then
                    Me.MainTextTemplates.txtPatienten.Text = sDescription.Trim()
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.genDescriptionForSelections: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIEditable(bOn As Boolean)
        Try
            Me.lblSelectAll.Visible = bOn
            Me.lblSelectNone.Visible = bOn

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.setUIEditable: " + ex.ToString())
        End Try
    End Sub

    Private Sub lblSelectAll_Click(sender As Object, e As EventArgs) Handles lblSelectAll.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.SelectAllNoneBenutzerPatients(Windows.Forms.CheckState.Checked)
            Me.checkSendEvent()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub lblSelectNone_Click(sender As Object, e As EventArgs) Handles lblSelectNone.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.SelectAllNoneBenutzerPatients(Windows.Forms.CheckState.Unchecked)
            Me.checkSendEvent()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnSelectSave_Click_1(sender As Object, e As EventArgs) Handles btnSelectSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.abort = False
            If Not Me.popupContMainSearch Is Nothing Then
                If Me.SendEventPatientUsersWhenSelectChanged Then
                    Dim selItmUserPatient As UltraListViewItem = Me.getSelectedBenutzerPatient(False)
                    If Not selItmUserPatient Is Nothing Then
                        Me.treeBenutzerPatientsItemCheckStateChanged(selItmUserPatient, False)
                    End If
                End If
                Me.popupContMainSearch.Close()
            End If

            If Me._IsSearch Then
                'Me.MainPlanungGesamt.ContPlanung1.search(False, False, True, False)
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub checkSendEvent()
        Try
            Dim IDKlinik As Nullable(Of Guid) = Nothing
            Dim IDAbteilung As Nullable(Of Guid) = Nothing
            Dim IDBereich As Nullable(Of Guid) = Nothing
            Dim treeNode As UltraTreeNode = Nothing
            Me.getSelectedAbtBereich(IDKlinik, IDAbteilung, IDBereich, treeNode, True)

            If Me.SendEventPatientUsersWhenSelectChanged And Me._TypePatientenUserPickerChanged = [Global].eTypePatientenUserPickerChanged.none Then
                Dim lstSelectedUsersPatients As System.Collections.Generic.List(Of Guid) = Me.getList()
                PMDS.Global.ENV.PatientenUersPickerValueChanged(IDAbteilung, IDBereich, Nothing, lstSelectedUsersPatients, treeNode, Me._TypePatientenUserPickerChanged)
            End If

        Catch ex As Exception
            Throw New Exception("contSelectPatientenBenutzer.checkSendEvent: " + ex.ToString())
        End Try
    End Sub

    Private Sub txtSearch_ValueChanged(sender As Object, e As EventArgs) Handles txtSearch.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.txtSearch.Focused Then
                Me.searchInTree(Me.txtSearch.Text.Trim())
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub chkShowOnlyAnwesendePatienten_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOnlyAnwesendePatienten.CheckedChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.chkShowOnlyAnwesendePatienten.Focused Then
                Me.TreeLockItemChanged = True
                Dim lstPatientsUsers As List(Of Guid) = Me.getList()
                Me.loadBenutzerPatients(Me._IDAbteilung, Me._IDBereich, Me._IDBerufsgruppe, Me._SelectAll, Me._clearTreeSelected)

                Me.SelectAllNoneBenutzerPatients(Windows.Forms.CheckState.Unchecked)
                For Each IDPatientUserSelected As Guid In lstPatientsUsers
                    Me.SelectListViewItemBenutzerPatient(IDPatientUserSelected)
                Next
            End If

        Catch ex As Exception
            Me.TreeLockItemChanged = False
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.TreeLockItemChanged = False
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub chkShowNotActiveUsers_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowNotActiveUsers.CheckedChanged
        Try
            If Me.chkShowNotActiveUsers.Focused Then
                Me.loadBenutzerPatientsClick()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim nodSel As UltraListViewItem = Me.getSelectedTreeSelected(True)
            If Not nodSel Is Nothing Then
                Dim IDObjectSelected As Guid = New System.Guid(nodSel.Key.ToString().Trim())
                Me.deleteObjectFromSelected2(IDObjectSelected)
                Me.checkSendEvent()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
