Imports qs2.core.vb
Imports qs2.Resources


Public Class frmLicense


    Public licenseFile As String
    Public funct1 As New qs2.core.vb.funct()
    Public doLicense1 As New qs2.core.license.doLicense()
    Public infoLicense As Boolean = False

    Public NrNewParticipant As Integer = 0
    Public AutoControlsUI1 As New qs2.design.auto.workflowAssist.autoForm.AutoControlsUI()





    Private Sub frmLicense_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Me.UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

            Me.Icon = getRes.getIcon(qs2.Resources.getRes.ePicture.ico_license, 32, 32)
            Me.loadRes()
            Me.newLicense()
            If Me.infoLicense Then Me.setUILicenseInfo()

            Me.doLicense1.fillTableApplicationsxy(Me.DsLicense1, False, True)
            Me.UltraGrid1.DisplayLayout.ValueLists("Applications").ValueListItems.Clear()
            For Each rApp As qs2.core.license.dsLicense.ApplicationsRow In Me.DsLicense1.Applications
                Me.UltraGrid1.DisplayLayout.ValueLists("Applications").ValueListItems.Add(rApp.ID, rApp.Name)
            Next

            Dim License As New qs2.core.Enums.eLicense()
            qs2.core.vb.ui.getEnumAsList(License.GetType(), Me.UltraGrid1.DisplayLayout.ValueLists("LicenseVariables"), Nothing, False)
        
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("QS2Licensemanager")

            Me.UltraToolbarsManager1.Tools("btnNew").SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("New")
            Me.UltraToolbarsManager1.Tools("btnEncodeLicFile").SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Save")
            Me.UltraToolbarsManager1.Tools("btnDecode").SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("OpenLicFile")

            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.IDParticipantColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Participant")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicCustomerColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Customer")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.GültigBisColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ValidTo")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicCountryColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Country")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicZIPColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ZIP")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicCityColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("City")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicAdressColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Adress")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicPhoneColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("PhoneMobile")
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.LicWebColumn.ColumnName).Header.Caption = "Web"
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(Me.DsLicense1.Participant.UserGroupColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Usergroup")
            Me.UltraGrid1.DisplayLayout.Bands(1).Columns(Me.DsLicense1.Application.IDApplicationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Application")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "btnNew"
                    Me.newLicense()
                Case "btnDecode"
                    Me.OpenFileAndDecrypt()
                Case "btnEncodeLicFile"
                    Me.EncryptStringAndSaveFile()
            End Select

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub EncryptStringAndSaveFile()
        Try
            Me.UltraGrid1.UpdateData()
            Dim fileEncoded As String = Me.funct1.saveFile(False, qs2.core.license.doLicense.typFileCodedSel, "QS2", qs2.core.ENV.path_config)

            If Not fileEncoded = "" Then
                Dim sEncoded As String = ""
                Dim stringwriter As New System.IO.StringWriter
                Me.DsLicense1.WriteXml(stringwriter, XmlWriteMode.WriteSchema)

                If doLicense1.EncryptStringAndSaveFile("<?xml version=""1.0"" standalone=""yes""?>" + stringwriter.ToString(), fileEncoded) Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("LicensfileEncodSucc"), System.Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("EncryptStringAndSaveFile: " + ex.ToString())
        End Try
    End Sub

    Public Sub OpenFileAndDecrypt()     'Open encrypted license file
        Dim fileToDecode As String = Me.funct1.selectFile(False, qs2.core.license.doLicense.typFileCodedSel, qs2.core.ENV.path_config)
        If Not fileToDecode = "" Then
            Dim xmlString As String = doLicense1.OpenFileAndDecrypt(fileToDecode)
            Me.licenseFile = Nothing
            Me.newLicense()
            Dim strReader As New System.IO.StringReader(xmlString)
            Me.DsLicense1.ReadXml(strReader, XmlReadMode.ReadSchema)
            Me.UltraGrid1.Refresh()
            Me.setUI()
        End If
    End Sub

    Public Function newLicense() As Boolean
        Me.licenseFile = Nothing
        Me.DsLicense1.Clear()
        Me.UltraGrid1.Refresh()
        Me.setUI()
        Return True
    End Function

    Public Sub setUI()
        Dim bOn As Boolean = False
        If Me.licenseFile Is Nothing Then
            Me.UltraStatusBar1.Panels(0).Text = qs2.core.language.sqlLanguage.getRes("NewLicensefile") + " ..."
        Else
            Me.UltraStatusBar1.Panels(0).Text = Me.licenseFile
            bOn = True
        End If
    End Sub

    Public Sub setUILicenseInfo()

        Me.UltraToolbarsManager1.Visible = False
        Me.UltraStatusBar1.Visible = False
        Me.Text = qs2.core.language.sqlLanguage.getRes("InfoLicense")
        Me.UltraGrid1.DisplayLayout.AddNewBox.Hidden = True
        Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.UltraWinGrid.AllowAddNew.No

        Me.DsLicense1.Clear()
        Dim rNewPart As qs2.core.license.dsLicense.ParticipantRow = Me.DsLicense1.Participant.NewRow()
        rNewPart.ItemArray = qs2.core.license.doLicense.rParticipant.ItemArray
        Me.DsLicense1.Participant.Rows.Add(rNewPart)

        Dim rNewApp As qs2.core.license.dsLicense.ApplicationRow = Me.DsLicense1.Application.NewRow()
        rNewApp.ItemArray = qs2.core.license.doLicense.rApplication.ItemArray
        Me.DsLicense1.Application.Rows.Add(rNewApp)

        For Each rVar As qs2.core.license.dsLicense.VariablesRow In qs2.core.license.doLicense.tVariables.Rows
            Dim rNewVar As qs2.core.license.dsLicense.VariablesRow = Me.DsLicense1.Variables.NewRow()
            rNewVar.ItemArray = rVar.ItemArray
            Me.DsLicense1.Variables.Rows.Add(rNewVar)
        Next
        Me.UltraGrid1.Refresh()
        Me.UltraGrid1.Rows.ExpandAll(True)
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

    End Sub

    Private Sub UltraGrid1_BeforeRowActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid1.BeforeRowActivate
        If Me.infoLicense Then e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub


    Private Sub UltraGrid1_BeforeRowInsert(sender As System.Object, e As Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs) Handles UltraGrid1.BeforeRowInsert
    End Sub
    Private Sub UltraGrid1_AfterRowInsert(sender As System.Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid1.AfterRowInsert
        Try
            If e.Row.Band.Index = 0 Then
                Dim v As DataRowView = e.Row.ListObject
                Dim rNewPart As qs2.core.license.dsLicense.ParticipantRow = v.Row

                Me.NrNewParticipant += 1
                rNewPart.IDParticipant = "New Participant " + Me.NrNewParticipant.ToString()
                rNewPart.LicCustomer = ""
                rNewPart.LicCountry = ""
                rNewPart.LicZIP = ""
                rNewPart.LicCity = ""
                rNewPart.LicAdress = ""
                rNewPart.LicPhone = ""
                rNewPart.LicWeb = ""
                rNewPart.UserGroup = ""

            ElseIf e.Row.Band.Index = 1 Then
                Dim v As DataRowView = e.Row.ListObject
                Dim rNewApp As qs2.core.license.dsLicense.ApplicationRow = v.Row
                rNewApp.IDApplication = ""

            ElseIf e.Row.Band.Index = 2 Then
                Dim v As DataRowView = e.Row.ListObject
                Dim rNewVar As qs2.core.license.dsLicense.VariablesRow = v.Row
                rNewVar.VarName = ""
                rNewVar.VarValue = ""

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmLicense_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class