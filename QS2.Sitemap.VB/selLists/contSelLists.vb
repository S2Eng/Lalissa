Imports qs2.core.vb
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports qs2.Resources
Imports PMDS.db.Entities
Imports System.Runtime.CompilerServices
Imports S2Extensions

Public Class contSelLists

    Public gen As New qs2.core.generic

    Public compSelListEntrys As New qs2.core.vb.sqlAdmin()

    Private uiGrid As New qs2.sitemap.ui()
    Public mainWindow As frmSelLists
    Public ui1 As New qs2.core.ui()

    Public isInEditMode As Boolean = False
    Public isInEditModeGroup As Boolean = True

    Public doLicense1 As New core.license.doLicense()

    Public funct1 As New qs2.core.vb.funct()

    Public defaultApplication As String = ""
    Public IDParticipant = ""

    Public IDGruppeStr As String = ""

    Public rSelListLastAdded As qs2.core.vb.dsAdmin.tblSelListEntriesRow

    Public savedClicked As Boolean = False
    Public Username As String = ""

    Public abort As Boolean = True
    Public rSelectedSelList As qs2.core.vb.dsAdmin.tblSelListEntriesRow
    Public SelectedRowGridSelList As UltraGridRow

    Public doExecptIfGroupNotFound As Boolean = True
    Public TypeStr As String = ""

    Public doAutoRessource As Boolean = False

    Public Class tagMenü
        Public sublist As String = ""
        Public rGroup As dsAdmin.tblSelListGroupRow = Nothing
    End Class

    Public sqlAdminWork As New sqlAdmin()
    Public tmpLastIDGroupAdded As Integer = 0

    ' Queries
    Public printWork As qs2.core.print.print = Nothing
    Public lstTypeQueries As System.Collections.Generic.List(Of KeyValuePair(Of String, String)) = Nothing

    Public dsAdminWork As qs2.core.vb.dsAdmin = Nothing
    Public IDParticipantToAdd As String = ""
    Public lstAddedRows As New System.Collections.Generic.List(Of System.Guid)

    Public IDApplicationCalled As String = ""
    Public _IsAdministrationSelList As Boolean = False
    Public doUI1 As New doUI()

    Public AutoResOn As Boolean = False
    Public columnSortCustomer As String = "SortCustomer"

    Public businessFramework1 As New qs2.core.vb.businessFramework()
    Public doSortCustomer As Boolean = False
    Public _ShowOnlyUserSelLists As Boolean = False

    Public IDGuidStay As Nullable(Of Guid) = Nothing








    Public Sub initControl(ByVal alwaysShowApplicationSelection As Boolean)
        Try
            Me.UltraTabControl1.Style = UltraWinTabControl.UltraTabControlStyle.Wizard

            Me.btnReload2.initControl()
            Me.btnAdd.initControl()
            Me.btnDel.initControl()
            Me.btnSave2.initControl()
            Me.btnClose2.initControl()
            Me.btnUp.initControl()
            Me.btnDown.initControl()
            Me.btnEditGroup.initControl()
            Me.btnSelect.initControl()

            Me.btnAddGroup.initControl()
            Me.btnDelGroup.initControl()

            Me.sqlAdminWork.initControl()

            Me.printWork = New core.print.print()
            Me.lstTypeQueries = New System.Collections.Generic.List(Of KeyValuePair(Of String, String))

            Me.dsAdminWork = New qs2.core.vb.dsAdmin()

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.mainWindow._OnlyOwnSelListsEditable = False
            Else
                Me.mainWindow._OnlyOwnSelListsEditable = True
            End If

            Me.DropDownApplications1.initControl(False)
            Me.DropDownApplications1.loadData()

            Me.loadRes()

            Me.editSelList(False)
            Me.editGroup()

            Me.ComboApplication1.initControlxy(alwaysShowApplicationSelection, False, True)
            Me.ComboApplication1.setApplication(Me.defaultApplication)

            Me.btnUserRights.Appearance.Image = getRes.getImage(getRes.Allgemein.ico_OK, 32, 32)

            Me.listOfSublistenToolStripMenuItem.Visible = False
            Me.ClearPictureToolStripMenuItem.Visible = False
            Me.OpenPictureToolStripMenuItem.Visible = False
            Me.SetPictureToolStripMenuItem.Visible = False

            'Me.TranslateEntryToolStripMenuItem.Visible = True

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.CopySellistAndRessourceToolStripMenuItem.Visible = True
                Me.btnEncryptsSaveToTheClipboardForDelivery.Visible = True
                Me.ClearCopiedRowsInRamToolStripMenuItem.Visible = True
                Me.ToolStripMenuItemSpace01.Visible = True

                Me.btnAddGroup.Visible = True
                Me.btnDelGroup.Visible = True
                Me.btnEditGroup.Visible = True

                Me.btnDelGroup.Enabled = True

            Else
                Me.CopySellistAndRessourceToolStripMenuItem.Visible = False
                Me.btnEncryptsSaveToTheClipboardForDelivery.Visible = False
                Me.ClearCopiedRowsInRamToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace01.Visible = False

                Me.btnAddGroup.Visible = False
                Me.btnDelGroup.Visible = False
                Me.btnEditGroup.Visible = False

                Me.btnAddGroup.Enabled = False
                Me.btnDelGroup.Enabled = False
            End If

            If qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev Then
                Me.lblAutoAddRessources.Visible = True
            Else
                Me.lblAutoAddRessources.Visible = False
            End If

            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.columnSortCustomer.Trim()).Hidden = Not Me.doSortCustomer
            'Me.gridSelList.DisplayLayout.Bands(0).Columns("ID").Hidden = False

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("SelectionLists")
            Me.btnClose2.Text = qs2.core.language.sqlLanguage.getRes("Close")
            Me.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel")
            Me.btnEdit.Text = qs2.core.language.sqlLanguage.getRes("Edit")
            Me.btnEditGroup.Text = qs2.core.language.sqlLanguage.getRes("Edit")
            Me.btnSelect.Text = qs2.core.language.sqlLanguage.getRes("OK")
            Me.AssignToMeToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("AssignToMe")

            Me.TranslateEntryToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("TranslateEntry")
            Me.TranslateEntryToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32)

            Me.btnUp.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_up, 32, 32)
            Me.btnDown.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_down, 32, 32)
            Me.btnSelect.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.listOfSublistenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Assigns")                               '"AssignSublists"
            Me.toolbarsManagerAssigns.Tools("popUpAssign").SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Assigns")
            Me.toolbarsManagerAssigns.Tools("popUpAssign").SharedProps.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("Assigns")
            Me.toolbarsManagerAssigns.Tools("popUpAssign").SharedProps.ToolTipText = qs2.core.language.sqlLanguage.getRes("SaveAssignsToSelListEntries")

            Me.CopySellistAndRessourceToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("CopySellistAndRessource")

            Dim info As New UltraToolTipInfo()
            info.ToolTipText = qs2.core.language.sqlLanguage.getRes("EncryptSaveToTheClipboardForDelivery")
            info.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnEncryptsSaveToTheClipboardForDelivery, info)

            Me.ClearCopiedRowsInRamToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ClearCopiedRowsInRam")

            Me.btnEncryptsSaveToTheClipboardForDelivery.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_lock, 32, 32)
            Me.CopySellistAndRessourceToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32)
            Me.ClearCopiedRowsInRamToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.gridGroup.Text = qs2.core.language.sqlLanguage.getRes("Groups")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDRessourceColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IDRessource")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDParticipantColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Participant")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDApplicationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Application")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.SublistColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Sublist")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Group")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.TypeEnumColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeEnum")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.SortColumnColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("SortColumn")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Nr")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.ClassificationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Classification")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.VersionNrFromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionFrom")
            Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.VersionNrToColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionTo")

            Me.gridSelList.Text = qs2.core.language.sqlLanguage.getRes("ListEntrys")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IDRessource")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("OwnKeyInt")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("OwnKeyStr")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Sort")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.pictureColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Picture")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Table")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShortColumn")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Nr")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("User")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("CreatedDt")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("StringCalculated")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Private")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SqlColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Sql")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Classification")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IsMain")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrFromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionFrom")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrToColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionTo")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SubQueryColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Subquery")
            'Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SubQueryColumn.ColumnName).Width = 60
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.LicenseKeyColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LicenseKey")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.columnSortCustomer.Trim()).Header.Caption = qs2.core.language.sqlLanguage.getRes("SortCustomer")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PublishedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Published")
            Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ForServicesColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ForServices")

            If Me.IDGruppeStr.Trim() <> "" Then

                Me.PanelSearch.Visible = False

                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDRessourceColumn.ColumnName).Hidden = False
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDParticipantColumn.ColumnName).Hidden = False
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDApplicationColumn.ColumnName).Hidden = False
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.SublistColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.DescriptionColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.TypeEnumColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.SortColumnColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.sysColumn.ColumnName).Hidden = True
                Me.gridGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.ClassificationColumn.ColumnName).Hidden = True

                Me.gridGroup.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn

                'Me.gridGroup.DisplayLayout.Bands(0).ColHeadersVisible = False
                Me.gridGroup.DisplayLayout.CaptionVisible = DefaultableBoolean.False

                Me.PanelSearch.Visible = False
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Entry")
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("OwnKeyInt")
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnStrColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Sort")
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.pictureColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SqlColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = True

                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.LicenseKeyColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ForServicesColumn.ColumnName).Hidden = True

                If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesAdmin Then
                    Me.UltraSplitter1.Collapsed = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Header.VisiblePosition = 5
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key")
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SubQueryColumn.ColumnName).Header.VisiblePosition = 6
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ForServicesColumn.ColumnName).Hidden = False

                ElseIf Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups Or Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow Then
                    Me.UltraSplitter1.Collapsed = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Header.VisiblePosition = 5
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
                    Me.PanelButtonsSort.Visible = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key")
                    'Me.gridSelList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrFromColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrToColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDParticipantColumn.ColumnName).Hidden = False

                ElseIf Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesUser Then
                    Me.UltraSplitter1.Collapsed = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PrivateColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = True

                    'Me.gridSelList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                    Me.PanelTopAll.Visible = False
                    Me.PanelButtonsSort.Visible = False
                    'Me.gridGroup.DisplayLayout.Bands(0).ColHeadersVisible = False

                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrFromColumn.ColumnName).Hidden = True
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrToColumn.ColumnName).Hidden = True

                End If

                If Me.doAutoRessource Then
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Hidden = True
                End If

                If Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow Then
                    Me.PanelSelect.Visible = True
                End If
            Else
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
            End If

            If Me.mainWindow.typeUI = frmSelLists.eTypeUI.Administration Then
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = False
                Else
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = True
                End If
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.LicenseKeyColumn.ColumnName).Hidden = False
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ForServicesColumn.ColumnName).Hidden = False
            Else
                'Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDColumn.ColumnName).Hidden = True
            End If

            If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups Then
                Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
            End If

            Dim ToolTipInfo As New UltraToolTipInfo()
            Me.btnReload2.OwnTooltipTitle = qs2.core.language.sqlLanguage.getRes("Reload")
            Me.btnReload2.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ReloadGroups")

            ToolTipInfo = New UltraToolTipInfo()
            Me.btnDel.OwnTooltipTitle = qs2.core.language.sqlLanguage.getRes("Delete")
            Me.btnDel.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("DeleteSelectedEntry")

            Me.gridSelList.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ..."
            Me.gridSelList.DisplayLayout.Override.TemplateAddRowPrompt = qs2.core.language.sqlLanguage.getRes("ClickHereToAddARecord") + " ..."

            Me.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search")

            Me.SetPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SetPicture")
            Me.ClearPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ClearPicture")
            Me.OpenPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenPicture")
            Me.InfoRessourceToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("InfoTranslation")

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.InfoRessourceToolStripMenuItem.Visible = True
            End If

            If (Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()) And Me.mainWindow.typeUI = frmSelLists.eTypeUI.Administration Then
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrFromColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrToColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.LicenseKeyColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SqlColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.SubQueryColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ExternColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.PublishedColumn.ColumnName).Hidden = True
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.UITypeColumn.ColumnName).Hidden = True
            End If

            If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups Then
                Me.gridSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadGroups(ByVal IDGrpStr As String)
        Try
            Me.tmpLastIDGroupAdded = 0

            Dim sqlAdminWork As New sqlAdmin()

            Me.IDGruppeStr = IDGrpStr
            Me.DsAdmin1.tblSelListGroup.Rows.Clear()

            Me.DsAdmin1.tblSelListEntries.Rows.Clear()
            Me.gridSelList.Refresh()

            Dim enumAppFound As core.license.doLicense.eApp = Me.ComboApplication1.getSelectedApplication()

            If Me.IDGruppeStr.Trim() = "" Then
                Me.compSelListEntrys.getSelListGroup(Me.DsAdmin1, sqlAdmin.eTypSelGruppen.all, "NONE", "", enumAppFound.ToString())
            Else
                If Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow Then
                    Me.editSelList(False)
                Else
                    Me.editSelList(True)
                End If

                Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.compSelListEntrys.getSelListGroupRow_ParticAppl(Parameters, Me.IDGruppeStr, Me.IDParticipant, enumAppFound.ToString(), Me.doExecptIfGroupNotFound)
                If Not rGroup Is Nothing Then
                    Dim rNewGroup As dsAdmin.tblSelListGroupRow = sqlAdminWork.getNewRowSelListGroup(Me.DsAdmin1)
                    rNewGroup.ItemArray = rGroup.ItemArray
                End If

            End If

            'uiGrid.setFilterGridKomplex(Me.UGridAuswahlisten)
            Me.gridGroup.Refresh()

            Dim firstRow As UltraGridRow
            For Each rGridGrp As UltraGridRow In Me.gridGroup.Rows
                Dim v As DataRowView = rGridGrp.ListObject
                Dim rGroup As dsAdmin.tblSelListGroupRow = v.Row
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rGroup.IDRessource, rGroup.IDParticipant, rGroup.IDApplication)
                If resFound.Trim() = "" Then
                    rGridGrp.Cells(qs2.core.generic.columnNameText).Value = ""   'rGroup.IDRessource
                Else
                    rGridGrp.Cells(qs2.core.generic.columnNameText).Value = resFound
                End If
                If firstRow Is Nothing Then firstRow = rGridGrp
            Next

            Me.btnDel.Visible = False
            Me.btnAdd.Visible = False
            Me.btnSave2.Visible = False
            Me.PanelButtEdit.Visible = False
            Me.btnUp.Visible = False
            Me.btnDown.Visible = False
            Me.listOfSublistenToolStripMenuItem.Visible = False

            Me.ClearPictureToolStripMenuItem.Visible = False
            Me.OpenPictureToolStripMenuItem.Visible = False
            Me.btnSelect.Enabled = False
            Me.rSelectedSelList = Nothing
            Me.SelectedRowGridSelList = Nothing

            Me.gridGroup.Selected.Rows.Clear()
            Me.gridGroup.ActiveRow = Nothing

            Me.gridGroup.Text = qs2.core.language.sqlLanguage.getRes("Groups") + " (" + Me.DsAdmin1.tblSelListGroup.Rows.Count.ToString() + ")"

            Me.doSearch()

            If Not firstRow Is Nothing And Me.IDGruppeStr.Trim() <> "" Then
                Me.gridGroup.ActiveRow = firstRow
                Me.loadSelList()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadSelList()
        Try
            Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
            If Not rGroup Is Nothing Then
                Me.DsAdmin1.tblSelListEntries.Rows.Clear()
                'Dim rGrpxy As dsAuswahllisten.AuswahllisteGruppeRow = Me.cboAuswahlisten.SelectedItem.Tag
                'Dim grpSelected As qs2.core.vb.sqlAdmin.eGroups = qs2.sitemap.ui.searchEnum(rGroup.IDGroup, GetType(qs2.core.vb.sqlAdmin.eGroups))

                Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                Dim bSelListRowIdEditablt As Boolean = False
                If Me.checkIsQueryGroupsEditable(rGroup.IDGroupStr, Nothing, bSelListRowIdEditablt) And Not Me._ShowOnlyUserSelLists Then
                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, "", "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroup, "", 0, "", rGroup.ID)
                Else
                    If Not qs2.core.ENV.adminSecure And Me._ShowOnlyUserSelLists Then
                        Me.compSelListEntrys.getSelListEntrys(Parameters, 0, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroupParticipantAndAll, "", 0, "", rGroup.ID)
                    Else
                        Select Case Me.mainWindow.typeUI
                            Case frmSelLists.eTypeUI.Administration, frmSelLists.eTypeUI.manageQueriesAdmin
                                If Not Me.mainWindow._OnlyOwnSelListsEditable And Not Me._ShowOnlyUserSelLists Then
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, "", "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroup, "", 0, "", rGroup.ID)
                                Else
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroupParticipantAndAll, "", 0, "", rGroup.ID)
                                End If

                            Case frmSelLists.eTypeUI.manageQueryGroups
                                If Not Me.mainWindow._OnlyOwnSelListsEditable And Not Me._ShowOnlyUserSelLists Then
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, "", "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroup, "", 0, "", rGroup.ID)
                                Else
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroupParticipantAndAll, "", 0, "", rGroup.ID)
                                End If
                        'Me.compSelListEntrys.getSelListEntrys(0, "", "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroup, core.Enums.eTypeQuery.User.ToString(), 0, "", rGroup.ID)

                            Case frmSelLists.eTypeUI.selectRow
                                If Not Me.mainWindow._OnlyOwnSelListsEditable Then
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, "", "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroup, "", 0, "", rGroup.ID)
                                Else
                                    Me.compSelListEntrys.getSelListEntrys(Parameters, 0, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "", Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroupParticipantAndAll, "", 0, "", rGroup.ID)
                                End If

                            Case frmSelLists.eTypeUI.manageQueriesUser
                                Me.compSelListEntrys.getSelListEntrys(Parameters, Me.IDGruppeStr, Me.IDParticipant, rGroup.IDApplication, Me.DsAdmin1, sqlAdmin.eTypAuswahlList.groupTypEnum, qs2.core.Enums.eTypeQuery.User.ToString())

                        End Select


                    End If
                End If


                Me.gridSelList.Refresh()
                Me.gridSelList.Text = qs2.core.language.sqlLanguage.getRes("ListEntrys") + " (" + Me.DsAdmin1.tblSelListEntries.Rows.Count.ToString() + ")"

                If rGroup.sys Then
                    Me.gridSelList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
                    Me.btnDel.Visible = False
                    Me.btnAdd.Visible = False
                    Me.btnSave2.Visible = False
                    Me.PanelButtEdit.Visible = False
                    Me.btnUp.Visible = False
                    Me.btnDown.Visible = False
                Else
                    Me.gridSelList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups Then
                        Me.btnDel.Visible = True
                    Else
                        Me.btnDel.Visible = False
                    End If
                    Me.btnAdd.Visible = True
                    Me.btnSave2.Visible = True
                    Me.PanelButtEdit.Visible = IIf(Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow, False, True)
                    Me.btnUp.Visible = True
                    Me.btnDown.Visible = True
                End If

                If rGroup.Sublist.Trim() <> "" Then
                    Me.listOfSublistenToolStripMenuItem.Visible = True
                    Me.readSublists(rGroup.Sublist.Trim(), Me.listOfSublistenToolStripMenuItem)
                    Me.PanelTollbar.Visible = True
                Else
                    Me.listOfSublistenToolStripMenuItem.Visible = False
                    Me.PanelTollbar.Visible = False
                End If

                If rGroup.TypeEnum.Trim() <> "" Then
                    Me.readTypesEnum(rGroup.TypeEnum)
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
                    If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesAdmin Then
                        Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypQuery")
                    Else
                        Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeEnum")
                    End If
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Style = ColumnStyle.DropDownList
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).ValueList = Me.gridSelList.DisplayLayout.ValueLists("Type")
                Else
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Style = ColumnStyle.Default
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeEnum")
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).ValueList = Nothing
                End If

                'If Me.IDGruppeStr.Trim() <> "" Then
                If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups Then
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
                ElseIf Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesUser Or Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow Then
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
                End If
                'End If

                For Each rGridSelEntry As UltraGridRow In Me.gridSelList.Rows
                    Dim v As DataRowView = rGridSelEntry.ListObject
                    Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row

                    Dim IDApplicationTmp As String = rGroup.IDApplication
                    If Me.IDApplicationCalled.Trim() <> "" Then
                        IDApplicationTmp = Me.IDApplicationCalled.Trim()
                    End If
                    Dim resFound As String = ""
                    If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesAdmin Or Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueriesUser Then
                        resFound = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, rGroup.IDParticipant, IDApplicationTmp, True, True)
                    Else
                        resFound = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, rGroup.IDParticipant, IDApplicationTmp)
                    End If

                    If resFound.Trim() = "" Then
                        rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = rSelEntry.IDRessource
                    Else
                        rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = resFound
                    End If

                Next

                If Me.doSortCustomer Then
                    Me.loadSortCustomer()
                End If

                Me.SetPictureToolStripMenuItem.Visible = False
                Me.ClearPictureToolStripMenuItem.Visible = False
                Me.OpenPictureToolStripMenuItem.Visible = False

                Me.gridSelList.DisplayLayout.Bands(0).SortedColumns.Clear()
                If rGroup.SortColumn.Trim() <> "" Then
                    Me.gridSelList.DisplayLayout.Bands(0).SortedColumns.Add(rGroup.SortColumn, False)
                Else
                    Me.gridSelList.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)
                End If

                Me.gridSelList.Selected.Rows.Clear()
                Me.gridSelList.ActiveRow = Nothing
                Me.lstAddedRows.Clear()
                Me.UIForSelList(rGroup)

                If actUsr.IsAdminSecureOrSupervisor() Then
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Hidden = False
                    Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Type")
                Else

                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadSortCustomer()
        Try
            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                For Each rowGrid As UltraGridRow In Me.gridSelList.Rows
                    Dim v As DataRowView = rowGrid.ListObject
                    Dim rSelListGrid As dsAdmin.tblSelListEntriesRow = v.Row

                    Dim tSelListEntriesSort As IQueryable(Of PMDS.db.Entities.tblSelListEntriesSort) = From rSelListEntrySorto In db.tblSelListEntriesSort
                                                                                                       Where rSelListEntrySorto.IDSelListEntry = rSelListGrid.ID And
                                                                                                          rSelListEntrySorto.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                    If tSelListEntriesSort.Count > 1 Then
                        Throw New Exception("contSelLists.loadSortCustomer: tSelListEntriesSort.Count>1 ' for IDSelList" + rSelListGrid.ID.ToString() + "' and IDParticipant '" + qs2.core.license.doLicense.rParticipant.IDParticipant.Trim() + "' not allowed!")
                    ElseIf tSelListEntriesSort.Count = 1 Then
                        Dim rSelListEntrySort As PMDS.db.Entities.tblSelListEntriesSort = tSelListEntriesSort.First()
                        rowGrid.Cells(Me.columnSortCustomer.Trim()).Value = rSelListEntrySort.Sort
                    ElseIf tSelListEntriesSort.Count = 0 Then
                        rowGrid.Cells(Me.columnSortCustomer.Trim()).Value = System.DBNull.Value
                    End If
                Next
            End With

        Catch ex As Exception
            Throw New Exception("contSelLists.loadSortCustomer: " + ex.ToString())
        End Try
    End Sub

    Public Sub editSelList(ByVal bEdit As Boolean)
        Try
            Me.isInEditMode = bEdit

            Me.btnSave2.Enabled = bEdit
            Me.btnCancel.Enabled = bEdit
            Me.btnEdit.Enabled = Not bEdit
            Me.btnAdd.Enabled = bEdit
            Me.btnDel.Enabled = bEdit
            Me.btnUp.Enabled = bEdit
            Me.btnDown.Enabled = bEdit
            Me.PanelDoAutoRes.Visible = True    'bEdit

            qs2.core.ui.editGrid(bEdit, Me.gridSelList, False, Infragistics.Win.UltraWinGrid.AllowAddNew.No)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub editGroup()
        Try
            If Not Me.isInEditModeGroup Then
                Me.btnEditGroup.Text = qs2.core.language.sqlLanguage.getRes("Cancel")
                Me.isInEditModeGroup = True
                Me.btnSave2.Enabled = True
            Else
                Me.btnEditGroup.Text = qs2.core.language.sqlLanguage.getRes("Edit")
                Me.isInEditModeGroup = False
            End If

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.btnAddGroup.Enabled = Me.isInEditModeGroup
                Me.btnDelGroup.Enabled = Me.isInEditModeGroup
            Else
                Me.btnAddGroup.Enabled = False
                Me.btnDelGroup.Enabled = False
            End If
            qs2.core.ui.editGrid(Me.isInEditModeGroup, Me.gridGroup, False, Infragistics.Win.UltraWinGrid.AllowAddNew.No)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub



    Public Sub fillEnumType(ByVal TypeEnum As String)



    End Sub
    Public Function getSelGroupRow(ByVal MsgBox As Boolean) As dsAdmin.tblSelListGroupRow
        Try
            If Not Me.gridGroup.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.gridGroup.ActiveRow.ListObject
                Dim rGroup As dsAdmin.tblSelListGroupRow = v.Row
                Return rGroup
            Else
                If MsgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoGroup"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function getSelListEntry(ByVal msgBox As Boolean, ByRef activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsAdmin.tblSelListEntriesRow
        Try
            If Not Me.gridSelList.ActiveRow Is Nothing Then
                If Me.gridSelList.ActiveRow.IsGroupByRow Or Me.gridSelList.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridSelList.ActiveRow.ListObject
                    Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row
                    activeRow = Me.gridSelList.ActiveRow
                    Return rSelList
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function saveGroups() As Boolean
        Try
            Me.compSelListEntrys.daSelListGroup.Update(Me.DsAdmin1.tblSelListGroup)
            Me.gridGroup.Refresh()
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Function saveSelListEntries() As Boolean
        Try
            'If Me.DsAdmin1.tblSelListEntries.Rows.Count = 0 Then
            '    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecords"), Windows.Forms.MessageBoxButtons.OK, "")
            '    Exit Function
            'End If
            Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
            For Each rSelList As dsAdmin.tblSelListEntriesRow In Me.DsAdmin1.tblSelListEntries
                If rSelList.RowState = DataRowState.Deleted Then
                    'If rGrp.IDGroupStr = "Queries" Then
                    '    rSelList.RejectChanges()
                    '    qs2.core.vb.sqlAdmin.deleteSelListEntryAllQryAdminxy(rSelList.ID, rGrp.IDApplication)
                    '    rSelList.Delete()
                    'End If
                End If
            Next

            For Each rowGrid As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rowGrid.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row
                rSelList.SetColumnError(rowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Column.Index, "")

                If Not rSelList.RowState = DataRowState.Deleted Then
                    If rSelList.ID < 0 Then
                        Throw New Exception("contSelList.saveSelListEntries: rSelList.ID < 0 !")
                    End If
                    Dim sIDSelList As String = rSelList.ID
                    If sIDSelList.Length <> 8 And qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        'Throw New Exception("contSelList.saveSelListEntries: sIDSelList.Length <> 8 !")
                    End If
                    Dim IDSelListLast As Integer = -999
                    Dim sIDSelListLLast As String = sIDSelList.Substring(4, sIDSelList.Length - 4)
                    IDSelListLast = sIDSelListLLast

                    'If (rSelList.IDOwnInt <> IDSelListLast And rSelList.IDOwnInt <> -1) Or _
                    '    (IDSelListLast <> 9999 And rSelList.IDOwnInt = -1) Then                    'lthxy

                    '    Dim txt As String = qs2.core.language.sqlLanguage.getRes("IDOwnIntNotEqualWithID")
                    '    rSelList.SetColumnError(rowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Column.Index, txt)
                    '    Me.gridSelList.ActiveRow = rowGrid
                    '    Me.gridSelList.ActiveRow.Activate()
                    '    Me.gridSelList.ActiveCell = rowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName)
                    '    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    '    Return False

                    'End If

                    If rSelList.IDRessource = "" Then
                        Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoDescription")
                        rSelList.SetColumnError(rowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Column.Index, txt)
                        Me.gridSelList.ActiveRow = rowGrid
                        Me.gridSelList.ActiveRow.Activate()
                        Me.gridSelList.ActiveCell = rowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName)
                        qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                        Return False
                    End If

                    If Me.doAutoRessource Then
                        If System.Convert.ToString(rowGrid.Cells(qs2.core.generic.columnNameText).Value).Trim() = "" Then
                            Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoText")
                            'rSelList.SetColumnError(rowGrid.Cells(qs2.core.generic.columnNameText).Column.Index, txt)
                            Me.gridSelList.ActiveRow = rowGrid
                            Me.gridSelList.ActiveRow.Activate()
                            Me.gridSelList.ActiveCell = rowGrid.Cells(qs2.core.generic.columnNameText)
                            qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                            Return False
                        End If
                    End If

                    'rSelList.IDRessource = rSelList.IDRessource.Trim()
                Else

                End If
            Next

            Dim dsResAdded As qs2.core.language.dsLanguage
            Dim dsResModified As qs2.core.language.dsLanguage
            Dim dsResDeleted As qs2.core.language.dsLanguage
            If Me.doAutoRessource Then
                dsResAdded = New qs2.core.language.dsLanguage()
                dsResModified = New qs2.core.language.dsLanguage()
                dsResDeleted = New qs2.core.language.dsLanguage()
                If Not Me.getAutoRessourcen(rGrp, dsResAdded, dsResModified, dsResDeleted) Then
                    Throw New Exception("saveSelListEntries: Error Fct. getAutoRessourcen!")
                End If
            End If

            Me.compSelListEntrys.daSelListEntrys.Update(Me.DsAdmin1.tblSelListEntries)
            Me.gridSelList.Refresh()
            If Me.doSortCustomer Then
                Me.saveSortCustomer()
            End If

            If Me.IDGruppeStr.Trim() = "" Then
                'Dim sqlAdmin1 As New qs2.core.vb.sqlAdmin()
                'sqlAdmin1.initControl()
                'sqlAdmin1.loadAll(True)
            End If

            If Me.doAutoRessource Then
                If Me.checkIsQueryGroupsEditable(Me.IDGruppeStr, Nothing, Nothing) Then
                    Me.saveAutoRessourcen(rGrp, dsResAdded, dsResModified, dsResDeleted, True)
                Else
                    Me.saveAutoRessourcen(rGrp, dsResAdded, dsResModified, dsResDeleted, False)
                End If
            End If

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Sub saveSortCustomer()
        Try
            Dim sqlAdminUpdate As New sqlAdmin()
            sqlAdminUpdate.initControl()
            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                For Each rowGrid As UltraGridRow In Me.gridSelList.Rows
                    Dim v As DataRowView = rowGrid.ListObject
                    Dim rSelListGrid As dsAdmin.tblSelListEntriesRow = v.Row

                    Dim iSortCustomerInGrid As Integer = -1
                    If (Not rowGrid.Cells(Me.columnSortCustomer.Trim()).Value Is Nothing) AndAlso (Not rowGrid.Cells(Me.columnSortCustomer.Trim()).Value Is System.DBNull.Value) AndAlso
                                        (rowGrid.Cells(Me.columnSortCustomer.Trim()).Value > 0) Then
                        iSortCustomerInGrid = rowGrid.Cells(Me.columnSortCustomer.Trim()).Value
                    End If

                    Dim tSelListEntriesSort As IQueryable(Of PMDS.db.Entities.tblSelListEntriesSort) = From rSelListEntrySorto In db.tblSelListEntriesSort
                                                                                                       Where rSelListEntrySorto.IDSelListEntry = rSelListGrid.ID And
rSelListEntrySorto.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                    If tSelListEntriesSort.Count > 1 Then
                        Throw New Exception("contSelLists.saveSortCustomer: tSelListEntriesSort.Count>1 ' for IDSelList" + rSelListGrid.ID.ToString() + "' and IDParticipant '" + qs2.core.license.doLicense.rParticipant.IDParticipant.Trim() + "' not allowed!")
                    Else
                        If iSortCustomerInGrid > 0 Then
                            Dim rSelListEntrySort As PMDS.db.Entities.tblSelListEntriesSort = Nothing
                            If tSelListEntriesSort.Count = 1 Then
                                rSelListEntrySort = tSelListEntriesSort.First()
                            ElseIf tSelListEntriesSort.Count = 0 Then
                                rSelListEntrySort = New PMDS.db.Entities.tblSelListEntriesSort()
                                rSelListEntrySort.ID = System.Guid.NewGuid()
                                rSelListEntrySort.IDSelListEntry = rSelListGrid.ID
                                rSelListEntrySort.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                                rSelListEntrySort.Sort = -1
                                db.tblSelListEntriesSort.Add(rSelListEntrySort)
                            End If
                            rSelListEntrySort.Sort = iSortCustomerInGrid
                            db.SaveChanges()
                        Else
                            sqlAdminUpdate.deleteSelListEntriesSort(rSelListGrid.ID, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim())
                        End If
                    End If
                Next
            End With

        Catch ex As Exception
            Throw New Exception("contSelLists.saveSortCustomer: " + ex.ToString())
        End Try
    End Sub
    Public Function saveAutoRessources() As Boolean
        Try
            If Me.AutoResOn Then
                Dim rGroupSelected As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                Dim sProt As String = ""
                Dim iCounterInserted As Integer = 0
                Dim iCounterUpdated As Integer = 0
                Me.doUI1.addAutoRessources(Me.gridSelList, Me.lblAutoAddRessources, rGroupSelected.IDApplication.Trim(), sProt,
                                            iCounterInserted, iCounterUpdated, Me.chkAutoResOnlyAddRes.Checked)

                If sProt.Trim() <> "" Then
                    Dim frmProtocol1 As New frmProtocol()
                    frmProtocol1.initControl()
                    frmProtocol1.Text = "Auto-Insert-Update Ressources"
                    Dim sProtAll As String = iCounterInserted.ToString() + " Ressources inserted" + vbNewLine +
                                                                    iCounterUpdated.ToString() + " Ressources updated" + vbNewLine +
                                                                    vbNewLine + vbNewLine + sProt.Trim()
                    frmProtocol1.Show()
                    frmProtocol1.ContProtocol1.setText(sProtAll)
                End If

                Return True
            End If

        Catch ex As Exception
            Throw New Exception("saveAutoRessources: " + ex.ToString())
        End Try
    End Function

    Public Function getAutoRessourcen(ByVal rGrp As dsAdmin.tblSelListGroupRow,
                                      ByRef dsResAdded As qs2.core.language.dsLanguage,
                                      ByRef dsResModified As qs2.core.language.dsLanguage,
                                      ByRef dsResDeleted As qs2.core.language.dsLanguage) As Boolean
        Try
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            For Each rowGrid As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rowGrid.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                If rSelList.RowState <> DataRowState.Deleted Then
                    If rSelList.RowState = DataRowState.Added Then
                        Dim rNewRes As qs2.core.language.dsLanguage.RessourcenRow = Me.addRowRessourcen(rGrp, dsResAdded, rowGrid.Cells(qs2.core.generic.columnNameText).Value, rSelList.IDParticipant.Trim(), rSelList.IDRessource, sqlLanguage1)
                    ElseIf rSelList.RowState = DataRowState.Modified Then
                        Dim rNewRes As qs2.core.language.dsLanguage.RessourcenRow = Me.addRowRessourcen(rGrp, dsResModified, rowGrid.Cells(qs2.core.generic.columnNameText).Value, rSelList.IDParticipant.Trim(), rSelList.IDRessource, sqlLanguage1)
                    End If
                End If
            Next

            Dim arrToDelete As New ArrayList()
            For Each rSelList As dsAdmin.tblSelListEntriesRow In Me.DsAdmin1.tblSelListEntries
                If rSelList.RowState = DataRowState.Deleted Then
                    rSelList.RejectChanges()
                    Dim rNewRes As qs2.core.language.dsLanguage.RessourcenRow = Me.addRowRessourcen(rGrp, dsResDeleted, "", rSelList.IDParticipant.Trim(), rSelList.IDRessource, sqlLanguage1)
                    arrToDelete.Add(rSelList)
                End If
            Next

            For Each rSelList As dsAdmin.tblSelListEntriesRow In arrToDelete
                rSelList.Delete()
            Next

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function addRowRessourcen(ByRef rGrp As dsAdmin.tblSelListGroupRow,
                                  ByRef dsToAdd As qs2.core.language.dsLanguage,
                                  ByRef txt As String, ByRef IDPartipant As String,
                                  ByRef IDRes As String, ByRef sqlLanguage1 As qs2.core.language.sqlLanguage) As qs2.core.language.dsLanguage.RessourcenRow
        Try
            Return sqlLanguage1.newRowLanguage(dsToAdd, txt, IDRes, qs2.core.vb.actUsr.rUsr.UserName,
                                               rGrp.IDApplication, IDPartipant, core.Enums.eResourceType.Label,
                                               core.Enums.eTypeSub.User, qs2.core.license.doLicense.eApp.ALL.ToString())
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function saveAutoRessourcen(ByVal rGrp As dsAdmin.tblSelListGroupRow,
                                      ByRef dsResAdded As qs2.core.language.dsLanguage,
                                      ByRef dsResModified As qs2.core.language.dsLanguage,
                                      ByRef dsResDeleted As qs2.core.language.dsLanguage,
                                      ByRef SearchWithparticipantAllEmpty As Boolean) As Boolean
        Try
            Dim doLanguage1 As New qs2.core.language.doLanguage()
            doLanguage1.doAuto(dsResAdded, dsResModified, dsResDeleted, rGrp.IDApplication,
                               qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), True,
                               qs2.core.vb.actUsr.IsAdminSecureOrSupervisor, SearchWithparticipantAllEmpty)    'qs2.core.license.doLicense.eApp.ALL.ToString()
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function checkIsQueryGroupsEditable(ByRef IDGroupStr As String, ByRef rSelList As qs2.core.vb.dsAdmin.tblSelListEntriesRow,
                                               ByRef SelListRowIsEditable As Boolean) As Boolean
        Try
            If Me.mainWindow._OnlyUserSelListsEditable Then
                If Not rSelList Is Nothing AndAlso rSelList.TypeStr.Trim().ToLower().Equals(("User").Trim().ToLower()) Then
                    SelListRowIsEditable = True
                End If
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("contSelList.checkIsQueryGroupsEditable: " + ex.ToString())
        End Try
    End Function

    Private Sub deleteRows()
        Try
            Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
            Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
            qs2.core.ui.getSelectedGridRows(Me.gridSelList, rSelected, True)
            If (rSelected.Count > 0 And Not rGroup Is Nothing) Then
                Dim res As New MsgBoxResult()
                res = MsgBoxResult.Yes
                If Me.IDGruppeStr.Trim() = "" Then
                    res = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("SelListDeleteRecord"), Windows.Forms.MessageBoxButtons.YesNo, "")
                End If

                If res = MsgBoxResult.Yes Then
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                        Dim sProt2 As String = ""
                        Dim sDeleteOK As Boolean = True
                        Dim sProt As String = ""
                        Dim b As New qs2.core.vb.businessFramework()
                        If Me.mainWindow._OnlyOwnSelListsEditable Then
                            For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                                Dim v As DataRowView = rGrid.ListObject
                                Dim rSelList As qs2.core.vb.dsAdmin.tblSelListEntriesRow = v.Row

                                Dim bIsQueryGroup As Boolean = False
                                Dim bSelListRowIdEditable As Boolean = False
                                If Me.checkIsQueryGroupsEditable(Me.IDGruppeStr, rSelList, bSelListRowIdEditable) Then
                                    bIsQueryGroup = True
                                End If

                                If Me.mainWindow._OnlyOwnSelListsEditable Then
                                    If bIsQueryGroup Then
                                        If Not rSelList.TypeStr.sEquals("User") Then
                                            sDeleteOK = False
                                        End If
                                    Else
                                        If b.checkSelListIsUsedInStays(rSelList.ID, sProt) Then
                                            sDeleteOK = False
                                        End If
                                        If rSelList.TypeStr.sEquals("User") Then
                                            If Not rSelList.IDParticipant.sEquals(qs2.core.license.doLicense.rParticipant.IDParticipant) Then
                                                sDeleteOK = False
                                            End If
                                        Else
                                            sDeleteOK = False
                                        End If
                                    End If

                                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                                        sDeleteOK = True
                                    End If
                                Else
                                    sDeleteOK = True
                                End If
                            Next
                        End If

                        If sDeleteOK Then
                            Dim bStaysOK As Boolean = b.CheckSelListNrInStays(rGroup.IDApplication, qs2.core.license.doLicense.rParticipant.IDParticipant, rGroup.IDGroupStr,
                                                                              rSelectedSelList.ID, rSelectedSelList.IDOwnInt, Me.IDGuidStay, db, sProt2)
                            If bStaysOK Then
                                For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                                    'Me.compSelListEntrys.deleteSelListEntry(Me.UltraGrid1.ActiveRow.Cells(Me.DsAuswahllisten1.tblSelListEntrys.IDColumn.ColumnName).Value)
                                    rGrid.Delete(False)
                                    'Me.UltraGrid1.DeleteSelectedRows(False)
                                Next
                            Else
                                Dim frmProtocol1 As New frmProtocol()
                                frmProtocol1.initControl()
                                frmProtocol1.Text = qs2.core.language.sqlLanguage.getRes("DeleteSelListEntry")
                                frmProtocol1.Show()
                                frmProtocol1.ContProtocol1.setText(sProt2)
                            End If
                        Else
                            'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("SelListIsUsedInStaysAndCanNotDelete") + "!" + vbNewLine + vbNewLine + sProt.Trim(), Windows.Forms.MessageBoxButtons.OK, "")
                            Dim sInfoSum As String = qs2.core.language.sqlLanguage.getRes("SelListCanNotDeletedWrongParticipant") + vbNewLine + vbNewLine +
                                                 "" + sProt.Trim()

                            Dim frmProt As New frmProtocol()
                            frmProt.initControl()
                            frmProt.Show()
                            frmProt.Text = qs2.core.language.sqlLanguage.getRes("DeleteSelListEntry")
                            frmProt.ContProtocol1.setText(sInfoSum.Trim())
                            Exit Sub
                        End If
                        'Me.loadAuswahllistenByGruppe()
                    End Using
                End If
            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub deleteRowsGroup()
        Try
            Dim b As New qs2.core.vb.businessFramework()

            Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
            qs2.core.ui.getSelectedGridRows(Me.gridGroup, rSelected, True)
            If (rSelected.Count > 0) Then
                Dim res As New MsgBoxResult()
                res = MsgBoxResult.No
                res = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("SelListDeleteRecord"), Windows.Forms.MessageBoxButtons.YesNo, "")
                If res = MsgBoxResult.Yes Then
                    For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                        rGrid.Delete(False)
                    Next
                End If

                Me.DsAdmin1.tblSelListEntries.Rows.Clear()
                Me.gridSelList.Refresh()
            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub UltraGrid1_BeforeRowInsert(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs) Handles gridSelList.BeforeRowInsert
        If Not Me.gruppeSelected(True) Then
            e.Cancel = True
        End If
    End Sub
    Public Function gruppeSelected(ByVal withMsgBox As Boolean) As Boolean
        Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
        If rGroup Is Nothing Then
            If withMsgBox Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoGroup"), Windows.Forms.MessageBoxButtons.OK, "")
            Return False
        Else
            Return True
        End If
    End Function
    Public Function gridSelected(ByVal withMsgBox As Boolean) As Boolean
        If Me.gridSelList.ActiveRow Is Nothing Then
            If withMsgBox Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridSelList.BeforeRowsDeleted
        'qs2.sitemap.ui.delGridRowYN(e)
        e.DisplayPromptMsg = False
        If Me.gridSelList.Focused Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub UltraGrid1_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridSelList.CellChange
        Try
            If Me.doAutoRessource Then
                ' Me.UltraGrid1.UpdateData()
                If e.Cell.Column.ToString() = qs2.core.generic.columnNameText Then
                    Dim v As DataRowView = e.Cell.Row.ListObject
                    Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row
                    If rSelEntry.RowState <> DataRowState.Added And rSelEntry.RowState <> DataRowState.Deleted Then
                        Dim IDRes As String = rSelEntry.IDRessource
                        rSelEntry.IDRessource = System.Guid.NewGuid().ToString()
                        rSelEntry.IDRessource = IDRes
                    End If
                End If
            End If

            Me.gridSelList.UpdateData()
            If e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName Then
                Me.gridValueHasChanged(e.Cell.Row, False, "")
            ElseIf e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName Then
                If Not e.Cell.Value Is System.DBNull.Value Then
                    Dim rSelListSimpleDef As dsAdmin.tblSelListEntriesRow = Me.gridValueHasChanged(e.Cell.Row, True, e.Cell.Value.ToString())
                    If Not rSelListSimpleDef Is Nothing Then
                        e.Cell.Row.Cells(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Value = rSelListSimpleDef.Classification.Trim()
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSelList_AfterSelectChange(sender As System.Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles gridSelList.AfterSelectChange
        Try


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridGroup.Click
        If Me.ui1.evClickOK(sender, e, Me.gridGroup) Then
            Me.loadSelList()
        End If
    End Sub
    Private Sub gridGroup_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridGroup.DoubleClick
        'If Me.ui1.evDoubleClickOK(sender, e, Me.gridGroup) Then

        'End If
    End Sub
    Private Sub gridGroup_BeforeRowRegionScroll(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs) Handles gridGroup.BeforeRowRegionScroll
        'Me.ui1.evBeforeRowRegionScrollAuto(sender, e, Me.gridGroup)
    End Sub
    Private Sub UltraGrid1_BeforeRowRegionScroll(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs) Handles gridSelList.BeforeRowRegionScroll
        'Me.ui1.evBeforeRowRegionScrollAuto(sender, e, Me.UltraGrid1)
    End Sub


    Private Sub btnClose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Not Me.mainWindow Is Nothing Then Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim res As New MsgBoxResult()
            res = MsgBoxResult.Yes
            If Me.IDGruppeStr.Trim() = "" Then
                res = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("SelListSave"), Windows.Forms.MessageBoxButtons.YesNo, "")
            End If

            If res = MsgBoxResult.Yes Then
                If Me.isInEditModeGroup Then
                    If Me.saveGroups() Then
                        Me.editGroup()
                    End If
                End If
                'If Me.isInEditMode Then
                If Me.saveSelListEntries() Then
                    Me.savedClicked = True
                    Me.lstAddedRows.Clear()
                    If Me.IDGruppeStr.Trim() <> "" Then
                        'Me.savedClicked = True
                        If Me.mainWindow.typeUI <> frmSelLists.eTypeUI.manageQueryGroups Then
                            Me.editSelList(False)
                            'If Not Me.mainWindow Is Nothing Then Me.mainWindow.Close()
                        Else
                            Me.editSelList(False)
                        End If
                    Else
                        Me.editSelList(False)
                    End If
                    Me.lstAddedRows.Clear()

                    Me.saveAutoRessources()
                    'Me.doUI1.autoAddResInGrid(Me.gridSelList, Me.lblAutoAddRessources, Me.AutoResOn, Me.chkAutoResOnlyAddRes, True)
                End If
                'End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnReload2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadGroups(Me.IDGruppeStr)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.deleteRows()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub readSublists(ByVal strSemikolon As String, ByVal mainStripMenuItem As System.Windows.Forms.ToolStripMenuItem)
        Try
            mainStripMenuItem.DropDownItems.Clear()
            Dim popUp As Infragistics.Win.UltraWinToolbars.PopupMenuTool = Me.toolbarsManagerAssigns.Tools("popUpAssign")
            popUp.Tools.Clear()

            Dim sublists As System.Collections.Generic.List(Of String) = qs2.core.generic.readStrVariables(strSemikolon)
            For Each sublist As String In sublists
                Dim tagMenü As New tagMenü()

                Dim startIndex As Integer = 0
                Dim subTag As String = qs2.core.generic.readStrBetween(sublist, startIndex, "[", "]", True, True, True)
                If subTag.Trim() <> "" Then
                    sublist = sublist.Substring(0, sublist.IndexOf("["))
                End If
                Dim sqlAdminCheck As New sqlAdmin()
                sqlAdminCheck.initControl()

                Dim sublistStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
                mainStripMenuItem.DropDownItems.Add(sublistStripMenuItem)

                Dim rGroupSelected As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)

                Dim rGroup As dsAdmin.tblSelListGroupRow = Nothing
                Dim GroupFound As Boolean = False
                Dim txt As String = ""
                If sublist.ToLower().Trim() = qs2.core.vb.sqlAdmin.groupNameCriterias.ToLower().Trim() Then
                    sublistStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes(qs2.core.vb.sqlAdmin.groupNameCriterias).Trim()
                    txt = qs2.core.language.sqlLanguage.getRes(qs2.core.vb.sqlAdmin.groupNameCriterias).Trim()
                    rGroup = rGroupSelected
                    GroupFound = True
                Else
                    Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                    Dim apps As New qs2.core.license.doLicense.eApp()
                    If subTag.Trim() <> "" Then
                        Dim lstApps As System.Collections.Generic.List(Of String) = qs2.core.generic.getEnumValues(apps.GetType())
                        For Each sApplicationFound As String In lstApps
                            If rGroup Is Nothing Then
                                rGroup = sqlAdminCheck.getSelListGroupRow_ParticAppl(Parameters, sublist, rGroupSelected.IDParticipant, sApplicationFound, False)
                                If Not rGroup Is Nothing Then
                                    GroupFound = True
                                End If
                            End If
                        Next
                    Else
                        rGroup = sqlAdminCheck.getSelListGroupRow_ParticAppl(Parameters, sublist, rGroupSelected.IDParticipant, rGroupSelected.IDApplication, True)
                        GroupFound = True
                    End If
                    If Not rGroup Is Nothing Then
                        sublistStripMenuItem.Name = sublist
                        Dim sGroupnameLang As String = qs2.core.language.sqlLanguage.getRes(rGroup.IDRessource).Trim()
                        sublistStripMenuItem.Text = IIf(sGroupnameLang = "", rGroup.IDRessource, sGroupnameLang)
                        txt = IIf(sGroupnameLang.Trim() = "", rGroup.IDRessource, sGroupnameLang)
                    End If
                End If

                If GroupFound Then
                    tagMenü.sublist = sublist
                    tagMenü.rGroup = rGroup

                    sublistStripMenuItem.Tag = tagMenü

                    Dim keyButt As String = System.Guid.NewGuid.ToString()
                    Dim newToolbarButton As New Infragistics.Win.UltraWinToolbars.ButtonTool(keyButt)
                    Me.toolbarsManagerAssigns.Tools.Add(newToolbarButton)
                    popUp.Tools.AddTool(keyButt)
                    newToolbarButton.SharedProps.Tag = tagMenü
                    newToolbarButton.SharedProps.Caption = txt
                    popUp.SharedProps.Visible = True
                    newToolbarButton.SharedProps.AppearancesSmall.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)

                    AddHandler sublistStripMenuItem.Click, AddressOf Me.sublistStripMenuItem_Click
                End If
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub
    Public Sub readTypesEnum(ByVal TypeEnum As String)
        Try
            Me.gridSelList.DisplayLayout.ValueLists(qs2.core.generic.columnNameType).ValueListItems.Clear()
            Dim listEnum As System.Collections.Generic.List(Of String) = qs2.core.generic.readStrVariables(TypeEnum)
            For Each enumStr As String In listEnum
                Me.gridSelList.DisplayLayout.ValueLists(qs2.core.generic.columnNameType).ValueListItems.Add(enumStr, enumStr)
            Next
            Me.gridSelList.DisplayLayout.ValueLists(qs2.core.generic.columnNameType).ValueListItems.Add("", qs2.core.language.sqlLanguage.getRes("NoSelection"))

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub
    Private Sub sublistStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim itemToolStrip As System.Windows.Forms.ToolStripMenuItem = sender
            Dim tagMenü As tagMenü = itemToolStrip.Tag
            tagMenü.rGroup.IDParticipant = qs2.core.license.doLicense.rApplication.IDParticipant
            Me.openSublisten(tagMenü, Me.TypeStr)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub openSublisten(tagMenü As tagMenü, ByVal TypeStrxy As String)
        Try
            If Me.gruppeSelected(True) Then
                If Me.gridSelected(True) Then
                    Dim sqlAdminWork As New sqlAdmin()
                    sqlAdminWork.initControl()
                    'Dim rGroup As dsAdmin.tblSelListGroupRow = sqlAdminWork.getSelListGroupRowID(tagMenü.nIDGroup)
                    'Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                    Dim v As DataRowView = Me.gridSelList.ActiveRow.ListObject
                    Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row

                    If tagMenü.sublist.Trim().ToLower() = qs2.core.vb.sqlAdmin.groupNameCriterias.Trim().ToLower() Then
                        Dim frm As New frmSelListsChapter()
                        frm.ContSelListsChapter1.rGroupSelected = tagMenü.rGroup
                        If tagMenü.rGroup.IDGroupStr.Trim().ToLower().StartsWith(("Chapters").Trim().ToLower()) Then
                            frm.ContSelListsChapter1.typIDGroup = qs2.core.vb.sqlAdmin.eDbTypAuswObj.Criterias.ToString()
                        Else
                            frm.ContSelListsChapter1.typIDGroup = qs2.core.vb.sqlAdmin.eDbTypAuswObj.Criterias.ToString() + "_" + tagMenü.rGroup.IDGroupStr.Trim()
                        End If
                        frm.ContSelListsChapter1.rSelEntry = rSelEntry
                        frm.ShowDialog(Me)

                    Else
                        Dim frm As New frmSelListsObj()
                        frm.ContSelListsObj1.TypeStr = ""
                        frm.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelEntry.ID
                        frm.ContSelListsObj1.grpToLoad = tagMenü.rGroup.IDGroupStr
                        Dim lstClassification As New System.Collections.ArrayList()
                        If tagMenü.rGroup.IDGroupStr.ToLower().Trim() = ("Queries").ToLower().Trim() Then
                            lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString())
                            lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString())
                            lstClassification.Add("")
                        End If

                        frm.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList
                        frm.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList
                        frm.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, contSelListsObj.eTypUI.normal,
                                      True, tagMenü.rGroup.IDApplication, tagMenü.rGroup.IDParticipant, tagMenü.sublist, rSelEntry.IDRessource)

                        frm.ShowDialog(Me)

                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridSelList.BeforeCellActivate
        Try

            Dim Edit As Infragistics.Win.UltraWinGrid.Activation
            If Me.isInEditMode Then
                If e.Cell.Row.IsFilterRow Or e.Cell.Row.IsGroupByRow Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Exit Sub
                End If

                If actUsr.IsAdminSecureOrSupervisor() Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Exit Sub
                End If

                If e.Cell.Column.ToString() = qs2.core.generic.columnNameEnglish.Trim() Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Exit Sub
                End If

                If e.Cell.Column.ToString() = qs2.core.generic.columnNameGerman.Trim() Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Exit Sub
                End If

                If Me.lstAddedRows.Contains(e.Cell.Row.Cells(Me.DsAdmin1.tblSelListEntries.IDGuidColumn.ColumnName).Value) Then         'Row is added
                    e.Cell.Activation = IIf(e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText, StringComparison.OrdinalIgnoreCase) Or
                        e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameSort, StringComparison.OrdinalIgnoreCase) Or
                        e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameSortCustomer, StringComparison.OrdinalIgnoreCase), Edit.AllowEdit, Edit.NoEdit)

                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    End If
                Else
                    If Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        Select Case e.Cell.Column.ToString().Trim().ToUpperInvariant()
                            Case qs2.core.generic.columnNameSortCustomer.ToUpperInvariant()
                                e.Cell.Activation = Edit.AllowEdit

                            Case qs2.core.generic.columnNameText.ToUpperInvariant()
                                e.Cell.Activation = IIf(e.Cell.Row.Cells(Me.DsAdmin1.tblSelListEntries.IDParticipantColumn.ColumnName).Value.ToString().Trim().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), StringComparison.OrdinalIgnoreCase), Edit.AllowEdit, Edit.NoEdit)

                            Case Else
                                e.Cell.Activation = Edit.NoEdit
                        End Select
                    Else

                        e.Cell.Activation = IIf(e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText, StringComparison.OrdinalIgnoreCase), Edit.AllowEdit, Edit.NoEdit)

                        If Not Me.doAutoRessource Then
                            If e.Cell.Column.ToString() <> Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName Then
                                Dim v As DataRowView = e.Cell.Row.ListObject
                                Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row

                                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                                e.Cell.Row.Cells(qs2.core.generic.columnNameText).Value = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, rGroup.IDParticipant, rGroup.IDApplication).Trim()
                            End If
                        Else
                            If e.Cell.Row.Cells(Me.DsAdmin1.tblSelListEntries.IDParticipantColumn.ColumnName).Value.ToString().Trim().ToLower() = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower() Then
                                If e.Cell.Column.ToString().Trim().ToLower() = ("Text").Trim().ToLower() Then
                                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                                Else
                                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                                End If
                            Else
                                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                            End If

                            If e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName Then
                                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                            End If
                        End If

                        If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        End If
                        If Me.IsQuery() Then
                            If e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName Or
                                e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName Then
                                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                            End If
                        End If
                    End If
                    If Me.mainWindow.typeUI = frmSelLists.eTypeUI.manageQueryGroups And e.Cell.Column.ToString().Trim().ToLower() = qs2.core.generic.columnNameText.Trim().ToLower() Then
                        If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        Else
                            If e.Cell.Row.Cells(Me.DsAdmin1.tblSelListEntries.IDParticipantColumn.ColumnName).Value.ToString().Trim().ToLower() = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower() Then
                                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                            Else
                                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                            End If
                        End If

                        Dim bSelListRowIdEditable As Boolean = False
                        Dim v As DataRowView = e.Cell.Row.ListObject
                        Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row
                        Me.checkIsQueryGroupsEditable(Me.IDGruppeStr, rSelList, bSelListRowIdEditable)
                        If bSelListRowIdEditable Then
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                        End If
                    End If
                End If
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSelList_Click(sender As System.Object, e As System.EventArgs) Handles gridSelList.Click
        Try
            Me.AssignToMeToolStripMenuItem.Visible = False

            Dim b As New qs2.core.vb.businessFramework()
            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                Me.gridValueHasChanged(actGridRow, False, "")

                Dim bIsQueryGroup As Boolean = False
                Dim bSelListRowIdEditable As Boolean = False
                If Me.checkIsQueryGroupsEditable(Me.IDGruppeStr, rSelSelListEntry, bSelListRowIdEditable) Then
                    bIsQueryGroup = True
                End If

                If (Me.IDGruppeStr.Trim().Equals("QueryGroups", StringComparison.CurrentCulture.OrdinalIgnoreCase) Or Me.IDGruppeStr.Trim().Equals("Queries", StringComparison.OrdinalIgnoreCase)) And
                        String.IsNullOrWhiteSpace(rSelSelListEntry.IDParticipant) Then
                    Me.AssignToMeToolStripMenuItem.Visible = True
                End If

                If Me.mainWindow._OnlyOwnSelListsEditable Or bIsQueryGroup Then
                    Dim sProt As String = ""
                    Dim sDeleteOK As Boolean = True

                    'If b.checkSelListIsUsedInStays(rSelSelListEntry.ID, sProt) Then
                    '    sDeleteOK = False
                    'End If
                    If Not bIsQueryGroup Then
                        If rSelSelListEntry.TypeStr.Trim().Equals("User", StringComparison.OrdinalIgnoreCase) Then
                            If Not rSelSelListEntry.IDParticipant.Trim().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant, StringComparison.OrdinalIgnoreCase) Then
                                sDeleteOK = False
                            End If
                        Else
                            sDeleteOK = False
                        End If
                    Else
                        If Not rSelSelListEntry.TypeStr.Trim().Equals("User", StringComparison.OrdinalIgnoreCase) Then
                            sDeleteOK = False
                        End If
                    End If

                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        sDeleteOK = True
                    End If
                    If sDeleteOK Then
                        Me.btnDel.Visible = True
                    Else
                        Me.btnDel.Visible = False
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadSelList()
            Me.editSelList(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnEdit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.editSelList(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub txtSearchText_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.txtSearchText.Focused Then
                Me.doSearch()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub doSearch()
        Try
            Me.funct1.clearAllFilter(Me.gridGroup)
            'Me.funct1.clearFilter(Me.DsAuswahllisten1.tblSelListGroup.IDGroupStrColumn, Me.gridGroup)

            If Me.txtSearchText.Text.Trim() <> "" Then

                Me.funct1.setFilter(Me.DsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName,
                                                FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(),
                                                FilterComparisionOperator.StartsWith, Me.gridGroup,
                                                Me.gridGroup.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(Me.DsAdmin1.tblSelListGroup.IDRessourceColumn.ColumnName,
                            FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(),
                            FilterComparisionOperator.StartsWith, Me.gridGroup,
                            Me.gridGroup.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(qs2.core.generic.columnNameText,
                            FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(),
                            FilterComparisionOperator.StartsWith, Me.gridGroup,
                            Me.gridGroup.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(Me.DsAdmin1.tblSelListGroup.SublistColumn.ColumnName,
                            FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(),
                            FilterComparisionOperator.StartsWith, Me.gridGroup,
                            Me.gridGroup.DisplayLayout.Bands(0).Index)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub SetPictureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetPictureToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                Dim selFile As String = Me.funct1.selectFile(False, funct.ressourcenFileType, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop))
                If Not selFile Is Nothing Then
                    rSelSelListEntry.picture = Me.funct1.readByteStreamFile(selFile)
                    Me.ClearPictureToolStripMenuItem.Visible = False
                    Me.OpenPictureToolStripMenuItem.Visible = False
                    Me.editSelList(True)
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub gridSelList_BeforeRowActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridSelList.BeforeRowActivate
        Try
            If Not e.Row.IsFilterRow And Not e.Row.IsTemplateAddRow Then
                Dim v As DataRowView = e.Row.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                Me.ClearPictureToolStripMenuItem.Visible = False    ' Not rSelList.IspictureNull()
                Me.OpenPictureToolStripMenuItem.Visible = False     ' Not rSelList.IspictureNull()
                Me.SetPictureToolStripMenuItem.Visible = False

                Me.rSelectedSelList = rSelList
                Me.SelectedRowGridSelList = e.Row
                Me.btnSelect.Enabled = True

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub ClearPictureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearPictureToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                rSelSelListEntry.SetpictureNull()
                Me.editSelList(True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub OpenPictureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPictureToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                Me.funct1.openFile(Me.funct1.saveFileFromBytes(qs2.core.ENV.path_temp, "picture for entry " + rSelSelListEntry.IDRessource, funct.fileTypeJpg, rSelSelListEntry.picture), "", True, False, True, False, Nothing)
                'Process.Start(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\mspaint.exe", "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.rSelListLastAdded = Me.addSelListEntry(Me.mainWindow._Private, Me.mainWindow.TypeStr)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function addSelListEntry(ByVal _Private As Boolean, ByVal TypeStr As String) As dsAdmin.tblSelListEntriesRow
        Try
            Dim sqlAdminAdd As New sqlAdmin()

            Dim rNew As dsAdmin.tblSelListEntriesRow = sqlAdminAdd.getNewRowSelList(Me.DsAdmin1, True)

            Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
            Dim NextIDOwnInt As Integer = Me.getNextIDOwnInt(rGrp.ID)
            Dim IDOwnStrNext As String = ""
            Dim IDSelListNextCalculated As Integer = -999
            Me.sqlAdminWork.getNextIDSelListGeneric(IDSelListNextCalculated, IDOwnStrNext, NextIDOwnInt, rGrp.ID)
            rNew.ID = IDSelListNextCalculated
            rNew.IDOwnStr = IDOwnStrNext
            rNew.IDOwnInt = NextIDOwnInt

            rNew.IDRessource = ""
            rNew.sort = Me.getLastSortNumber()

            If Me.IsQuery() Then
                rNew.TypeQry = qs2.core.print.print.eQueryType.SimpleView.ToString()
                Dim tSimpleViews As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Me.loadSelListForQuery("SimpleQueries", rGrp)
                Me.loadTableList(tSimpleViews, False, "")
            End If
            rNew.TypeStr = TypeStr
            rNew._Table = ""
            rNew.FldShortColumn = ""
            rNew.SetpictureNull()
            rNew.IDGroup = rGrp.ID
            rNew.CreatedUser = Me.Username
            rNew._Private = _Private
            rNew.Classification = ""
            rNew.Created = Now
            rNew.Sql = ""
            rNew.Description = ""
            'If Me.IDParticipantToAdd.Trim() <> "" Then
            '    rNew.IDParticipant = Me.IDParticipantToAdd.Trim()
            'Else
            '    rNew.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
            'End If

            If Me.doAutoRessource Then
                rNew.IDRessource = qs2.core.Enums.ePrefix.auto.ToString() + "_" + qs2.core.vb.actUsr.rUsr.UserName + "_" + System.Guid.NewGuid().ToString()
            End If

            Dim selRowGrid As UltraGridRow = Me.gridSelList.Rows.GetRowWithListIndex(Me.DsAdmin1.tblSelListEntries.Rows.IndexOf(rNew))
            Me.gridSelList.ActiveRow = selRowGrid
            'Me.gridSelList.ActiveCell = selRowGrid.Cells(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName)

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                rNew.TypeStr = qs2.core.Enums.eTypeSub.Supervisor.ToString()
                rNew.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
            Else
                rNew.TypeStr = qs2.core.Enums.eTypeSub.User.ToString()
                rNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
            End If

            lstAddedRows.Add(rNew.IDGuid)
            Return rNew

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function addGroup() As dsAdmin.tblSelListGroupRow
        Try
            Dim sqlAdminWork As New sqlAdmin()

            Dim IDGroupNew As Integer = Me.sqlAdminWork.getNextIDSelListGroupGeneric()

            Dim rNew As dsAdmin.tblSelListGroupRow = sqlAdminWork.getNewRowSelListGroup(Me.DsAdmin1)
            rNew.ID = IDGroupNew + Me.tmpLastIDGroupAdded
            rNew.IDRessource = ""
            rNew.IDGroupStr = qs2.core.language.sqlLanguage.getRes("NewKey") + " ..."
            rNew.IDApplication = Me.ComboApplication1.getSelectedApplication().ToString()
            rNew.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
            rNew.sys = False

            Dim selRowGrid As UltraGridRow = Me.gridGroup.Rows.GetRowWithListIndex(Me.DsAdmin1.tblSelListGroup.Rows.IndexOf(rNew))
            Me.gridGroup.ActiveRow = selRowGrid

            Me.tmpLastIDGroupAdded += 1
            Return rNew

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Sub doSort(ByVal toTop As Boolean)
        Try
            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelList As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelList Is Nothing Then
                Dim newNr As Integer = 0
                Dim reached As Boolean = False
                Dim orderBy As String
                If toTop Then
                    orderBy = " desc "
                Else
                    orderBy = " asc "
                End If
                Dim colNewOrder As String = "NewOrder"
                Me.DsAdmin1.tblSelListEntries.Columns.Add(colNewOrder, newNr.GetType())
                Dim arrActualSelList() As dsAdmin.tblSelListEntriesRow = Me.DsAdmin1.tblSelListEntries.Select("", Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName + orderBy)
                For Each rActualSelList As dsAdmin.tblSelListEntriesRow In arrActualSelList
                    newNr += 1
                    If (Not reached) And (rActualSelList.ID = rSelSelList.ID) Then
                        reached = True
                        rActualSelList(colNewOrder) = (newNr + 1)
                    ElseIf reached And (rActualSelList.ID <> rSelSelList.ID) Then
                        reached = False
                        rActualSelList(colNewOrder) = (newNr - 1)
                    ElseIf (Not reached) And (rActualSelList.ID <> rSelSelList.ID) Then
                        rActualSelList(colNewOrder) = newNr
                    End If
                Next

                newNr = 0
                Dim arrActualSelListWrite() As dsAdmin.tblSelListEntriesRow = Me.DsAdmin1.tblSelListEntries.Select("", colNewOrder + orderBy)
                For Each rActualSelListWrite As dsAdmin.tblSelListEntriesRow In arrActualSelListWrite
                    newNr += 1
                    rActualSelListWrite.sort = newNr
                Next

                Me.DsAdmin1.tblSelListEntries.Columns.Remove(colNewOrder)
                Me.gridSelList.DisplayLayout.Bands(0).SortedColumns.Clear()
                Me.gridSelList.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsAdmin1.tblSelListEntries.sortColumn.ColumnName, False)

            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Function getLastSortNumber() As Integer
        Try
            Dim lastNr As Integer = 0
            For Each rSelList As dsAdmin.tblSelListEntriesRow In Me.DsAdmin1.tblSelListEntries
                If Not rSelList.IssortNull() Then _
                    lastNr = IIf(lastNr < rSelList.sort, rSelList.sort, lastNr)
            Next
            Return (lastNr + 1)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return 5000
        End Try
    End Function
    Public Function getNextIDOwnInt(IDGroup As Integer) As Integer
        Try
            Dim retValue As Integer
            Using db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()     'Gesamte Datenbank für alle Participants
                With db
                    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                        Dim MaxIDInt? = 0
                        MaxIDInt = (From t In db.tblSelListEntries
                                    Where t.IDGroup = IDGroup And t.IDOwnInt < 999
                                    Order By t.ID Descending
                                    Select t.IDOwnInt).FirstOrDefault + 1
                        If Not IsNothing(MaxIDInt) Then
                            Return MaxIDInt
                        Else
                            Return 1
                        End If
                    Else
                        Dim MaxIDOwnInt? = 0
                        MaxIDOwnInt = (From t In db.tblSelListEntries
                                       Where t.IDGroup = IDGroup
                                       Order By t.ID Descending
                                       Select t.IDOwnInt).FirstOrDefault + 1

                        If Not IsNothing(MaxIDOwnInt) Then

                            retValue = Math.Max(10001, IIf(MaxIDOwnInt > 10000, 0, 10000) + Convert.ToInt32(MaxIDOwnInt))

                            'Einträge ohne Commit in der DsAdmin sind berücksichtigen (mehrere Einträge ohne speichern)
                            Dim LastSel = From sel In Me.DsAdmin1.tblSelListEntries
                                          Where Not String.IsNullOrEmpty(sel.IDRessource)
                                          Select sel

                            If (LastSel.Count > 0) Then
                                For Each s In LastSel
                                    If s.IDOwnInt >= retValue Then
                                        retValue = s.IDOwnInt + 1
                                    End If
                                Next
                            End If

                            Return retValue
                        Else
                            Return 10001
                        End If
                    End If
                End With
            End Using

            'Dim nextIDOwnInt As Integer = 0
            'If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
            '    nextIDOwnInt = 0
            'Else
            '    nextIDOwnInt = 10000
            'End If


            'For Each rSelList As dsAdmin.tblSelListEntriesRow In Me.DsAdmin1.tblSelListEntries
            '    If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
            '        If Not rSelList.IsIDOwnIntNull() Then
            '            If rSelList.IDOwnInt < 999 Then
            '                nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
            '            End If
            '        End If
            '    Else
            '        If Not rSelList.IsIDOwnIntNull() Then
            '            If rSelList.IDOwnInt >= 10000 Then
            '                nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDOwnInt, rSelList.IDOwnInt, nextIDOwnInt)
            '            End If
            '        End If

            '    End If
            'Next
            'Return (nextIDOwnInt + 1)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return 5000
        End Try
    End Function
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doSort(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doSort(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGroup.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.addGroup()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDelGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGroup.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.deleteRowsGroup()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnEditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditGroup.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.editGroup()

            If Not Me.isInEditModeGroup Then
                Me.loadGroups(Me.IDGruppeStr)
                Me.editSelList(False)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub gridGroup_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridGroup.BeforeCellActivate
        If Me.isInEditModeGroup Then
            If Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                If e.Cell.Column.ToString() = qs2.core.generic.columnNameText Or e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListGroup.IDColumn.ColumnName Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                End If
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    If e.Cell.Column.ToString() = Me.DsAdmin1.tblSelListGroup.IDColumn.ColumnName Then
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    End If
                End If
            End If
        Else
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
    End Sub
    Private Sub gridGroup_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridGroup.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub toolbarsManagerAssigns_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles toolbarsManagerAssigns.ToolClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim butt As Infragistics.Win.UltraWinToolbars.ButtonTool = e.Tool
            Dim tagMenü As tagMenü = e.Tool.SharedProps.Tag
            tagMenü.rGroup.IDParticipant = qs2.core.license.doLicense.rApplication.IDParticipant
            Me.openSublisten(tagMenü, Me.TypeStr)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Me.closeIfSelecteSelList()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSelList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridSelList.DoubleClick
        Try
            Me.closeIfSelecteSelList()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub closeIfSelecteSelList()
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Not Me.rSelectedSelList Is Nothing Then
                Me.abort = False
                If Not Me.mainWindow Is Nothing Then
                    If Me.mainWindow.typeUI = frmSelLists.eTypeUI.selectRow Then
                        Me.mainWindow.Close()
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub ComboApplication1_evOnChange(ByVal selectedApplication As System.String) Handles ComboApplication1.evOnChange
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadGroups(Me.IDGruppeStr)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub InfoRessourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoRessourceToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(True)
            If Not rGrp Is Nothing Then
                Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
                Dim rSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(True, actGridRow)
                If Not rSelListEntry Is Nothing Then
                    Dim frmRes As New qs2.sitemap.manage.wizardsDevelop.frmRessourcen()
                    frmRes.contRessourcen1.IDApplication = rGrp.IDApplication
                    frmRes.defaultApplication = rGrp.IDApplication
                    frmRes.contRessourcen1.IDParticipant = rGrp.IDParticipant
                    frmRes.doSearchAuto = True
                    frmRes.searchAuto = rSelListEntry.IDRessource
                    frmRes.ShowDialog(Me)
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub TranslateEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TranslateEntryToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelList As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(True, actGridRow)
            If Not rSelList Is Nothing Then
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                If Not rGroup Is Nothing Then
                    Dim frmTranslateText1 As New frmTranslateText()
                    frmTranslateText1.IDResToTranslate = rSelList.IDRessource
                    frmTranslateText1.Application = rGroup.IDApplication
                    frmTranslateText1.txtTranslationForIDResGerman.Text = actGridRow.Cells(qs2.core.generic.columnNameText).Value.ToString().Trim()
                    frmTranslateText1.ShowDialog(Me)
                    If Not frmTranslateText1.abort Then
                        Me.loadSelList()
                    End If
                Else
                    Throw New Exception("TranslateEntryToolStripMenuItem_Click: Selected rGroup is null in SelList")
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub






    Public Function gridValueHasChanged(ByRef actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow,
                                   ByRef SearchForSimpleDefinition As Boolean, ByRef ViewNameToSearch As String) As dsAdmin.tblSelListEntriesRow
        Try
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(False, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                If Me.IsQuery() Then
                    Dim rGroup As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                    If Not rGroup Is Nothing Then
                    End If
                    If Not SearchForSimpleDefinition Then
                        Me.loadSimpleTables(rSelSelListEntry, actGridRow, rGroup, SearchForSimpleDefinition, ViewNameToSearch)
                    Else
                        Return Me.loadSimpleTables(rSelSelListEntry, actGridRow, rGroup, SearchForSimpleDefinition, ViewNameToSearch)
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function IsQuery() As Boolean
        Try
            Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
            If rGrp.IDRessource.Trim().ToLower().StartsWith(("Queries").Trim().ToLower()) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Sub UIForSelList(ByRef rGroup As dsAdmin.tblSelListGroupRow)
        Try
            If Me.IsQuery Then
                Me.gridSelList.DisplayLayout.ValueLists("TypeQry").ValueListItems.Clear()
                Me.gridSelList.DisplayLayout.ValueLists("TablesQuery").ValueListItems.Clear()

                Me.lstTypeQueries.Clear()
                Me.printWork.getQueryTypes(Me.lstTypeQueries)

                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName).Hidden = False
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Hidden = False
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.ClassificationColumn.ColumnName).Hidden = False

                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Type")
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeQuery")
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TableQuery")

                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName).Style = ColumnStyle.DropDownList
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName).ValueList = Me.gridSelList.DisplayLayout.ValueLists("TypeQry")

                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Style = ColumnStyle.DropDown
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).ValueList = Me.gridSelList.DisplayLayout.ValueLists("TablesQuery")

                Dim firstItm As Boolean = True
                For Each itm As System.Collections.Generic.KeyValuePair(Of String, String) In Me.lstTypeQueries
                    Dim bShow As Boolean = True
                    If Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() And
                        (itm.Key.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower() Or
                          itm.Key.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.FullMode.ToString().ToLower()) Then
                        bShow = False
                    End If
                    bShow = True
                    If bShow Then
                        Dim item As ValueListItem = Me.gridSelList.DisplayLayout.ValueLists("TypeQry").ValueListItems.Add(itm.Key, itm.Value)
                        If firstItm Then
                        End If
                        firstItm = False
                    End If
                Next
            Else
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TableColumn.ColumnName).Style = ColumnStyle.DropDown
                Me.gridSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeEnum")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Function loadSimpleTables(ByRef rSelSelListEntry As dsAdmin.tblSelListEntriesRow, ByRef actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow,
                                ByRef rGroup As dsAdmin.tblSelListGroupRow,
                                   ByRef SearchForSimpleDefinition As Boolean, ByRef ViewNameToSearch As String) As dsAdmin.tblSelListEntriesRow
        Try
            If rSelSelListEntry.TypeQry.Trim() = "" Then
                rSelSelListEntry.TypeQry = core.print.print.eQueryType.SimpleView.ToString().Trim()
            End If

            If rSelSelListEntry.TypeQry.Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower() Then
                Dim tSimpleViews As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Nothing
                tSimpleViews = Me.loadSelListForQuery("SimpleQueries", rGroup)
                Return Me.loadTableList(tSimpleViews, SearchForSimpleDefinition, ViewNameToSearch)

            ElseIf rSelSelListEntry.TypeQry.Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower() Then
                Dim tSimpleFunctions As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Nothing
                tSimpleFunctions = Me.loadSelListForQuery("SimpleFunctions", rGroup)
                Return Me.loadTableList(tSimpleFunctions, SearchForSimpleDefinition, ViewNameToSearch)

            ElseIf rSelSelListEntry.TypeQry.Trim().ToLower() = qs2.core.print.print.eQueryType.FullMode.ToString().ToLower() Then
                Me.gridSelList.DisplayLayout.ValueLists("TablesQuery").ValueListItems.Clear()
                rSelSelListEntry._Table = ""

            Else
                Throw New Exception("contSelLists.getQueryType: itmValList.DataValue '" + rSelSelListEntry.TypeQry + "' not exists in Enum QueryType!")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function loadSelListForQuery(ByRef IDGroupStr As String, ByRef rGroup As dsAdmin.tblSelListGroupRow) As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable
        Try
            Dim tToLoad As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Nothing
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.dsAdminWork.tblSelListEntries.Clear()
            Me.sqlAdminWork.getSelListEntrys(Parameters, IDGroupStr.Trim(), rGroup.IDParticipant, rGroup.IDApplication, Me.dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.group)
            tToLoad = Me.dsAdminWork.tblSelListEntries.Copy()
            Return tToLoad

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function loadTableList(ByRef tViewFunctions As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable,
                                   ByRef SearchForSimpleDefinition As Boolean, ByRef ViewNameToSearch As String) As dsAdmin.tblSelListEntriesRow
        Try
            If Not SearchForSimpleDefinition Then
                Me.gridSelList.DisplayLayout.ValueLists("TablesQuery").ValueListItems.Clear()
            End If
            For Each rSelList As dsAdmin.tblSelListEntriesRow In tViewFunctions
                If Not SearchForSimpleDefinition Then
                    Dim Translated As String = qs2.core.language.sqlLanguage.getRes(rSelList._Table.Trim())
                    If Translated.Trim() = "" Then
                        Translated = rSelList._Table.Trim()
                    End If
                    Dim item As ValueListItem = Me.gridSelList.DisplayLayout.ValueLists("TablesQuery").ValueListItems.Add(rSelList._Table.Trim(), Translated.Trim())
                    item.Tag = rSelList
                Else
                    If ViewNameToSearch.Trim().ToLower().Equals(rSelList._Table.Trim().ToLower()) Then
                        Return rSelList
                    End If
                End If
            Next

            Me.gridSelList.Refresh()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Private Sub CopySellistAndRessourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySellistAndRessourceToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
            qs2.core.ui.getSelectedGridRows(Me.gridSelList, rSelected, True)
            If (rSelected.Count = 0) Then
                'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            End If
            If rSelected.Count > 0 Then
                For Each rSelField As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                    Dim v As DataRowView = rSelField.ListObject
                    Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                    Dim InsertFromClipboard1 As New InsertFromClipboard()
                    InsertFromClipboard1.CopySelList(rSelList)
                Next
            End If

            'Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            'Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(True, actGridRow)
            'If Not rSelSelListEntry Is Nothing Then
            '    Dim InsertFromClipboard1 As New InsertFromClipboard()
            '    InsertFromClipboard1.CopySelList(rSelSelListEntry)
            'End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub ClearCopiedRowsInRamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearCopiedRowsInRamToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            InsertFromClipboard.tSelListEntries.Clear()
            InsertFromClipboard.tRessourcen.Clear()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnEncryptsSaveToTheClipboardForDelivery_Click(sender As Object, e As EventArgs) Handles btnEncryptsSaveToTheClipboardForDelivery.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim InsertFromClipboard1 As New InsertFromClipboard()
            InsertFromClipboard1.encryptToClipboard(True, True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub lblAutoAddRessources_Click(sender As Object, e As EventArgs) Handles lblAutoAddRessources.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doUI1.autoAddResInGrid(Me.gridSelList, Me.lblAutoAddRessources, Me.AutoResOn, Me.chkAutoResOnlyAddRes, False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub EncryptedToClipboardNoLicenseKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptedToClipboardNoLicenseKeyToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim InsertFromClipboard1 As New InsertFromClipboard()
            InsertFromClipboard1.encryptToClipboard(False, True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AssignToMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignToMeToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(True, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                If rSelSelListEntry.IDParticipant.Trim() = "" Then
                    rSelSelListEntry.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnUserRights_Click(sender As Object, e As EventArgs) Handles btnUserRights.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelSelListEntry As dsAdmin.tblSelListEntriesRow = Me.getSelListEntry(True, actGridRow)
            If Not rSelSelListEntry Is Nothing Then
                Dim frmUserSelList1 As New qs2.sitemap.vb.frmUserSelList()

                Dim rGrp As dsAdmin.tblSelListGroupRow = Me.getSelGroupRow(False)
                frmUserSelList1.ContUserSelList1._eDbTypAuswObj = sqlAdmin.eDbTypAuswObj.UserDocuments
                Dim sTransNameQuery As String = qs2.core.language.sqlLanguage.getRes(rSelSelListEntry.IDRessource.Trim())
                Dim TitleWindow As String = qs2.core.language.sqlLanguage.getRes("RightsDocuments") + " - " + sTransNameQuery
                frmUserSelList1.initControl(rSelSelListEntry.ID, rGrp.IDApplication.Trim(), sTransNameQuery, TitleWindow)
                frmUserSelList1.ShowDialog(Me)
                If Not frmUserSelList1.ContUserSelList1.abort Then

                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
