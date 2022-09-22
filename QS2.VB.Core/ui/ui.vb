Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win


Public Class ui


    Public Shared Sub loadStyleInfrag(bUserdefined As Boolean, loadDefaultStyle As String, app As String)
        Try
            If qs2.core.ENV.ColorSchema = 1 Then
                Infragistics.Win.AppStyling.StyleManager.Load(System.IO.Path.Combine(core.ENV.path_config, "Dark.isl"))
            ElseIf qs2.core.ENV.ColorSchema = 2 Then
                Infragistics.Win.AppStyling.StyleManager.Load(System.IO.Path.Combine(core.ENV.path_config, "Light.isl"))
            End If

        Catch ex As Exception
            Throw New Exception("loadStyleInfrag: " + ex.ToString())
        End Try
    End Sub
    Public Shared Sub getWatchProtokoll()
        Try
            Dim frmProtocol1 As New qs2.core.vb.frmProtocol()
            frmProtocol1.ContProtocol1.TypeProtocolWindow = contProtocol.eTypeProtocolWindow.protocol
            frmProtocol1.initControl()

            frmProtocol1.ContProtocol1.lblTitleError.Visible = True
            frmProtocol1.ContProtocol1.pictureBoxError.Visible = True
            frmProtocol1.Text = "Protocol Watch Functions"
            frmProtocol1.Show()
            frmProtocol1.ContProtocol1.setText(qs2.core.ui.watchResult.Trim())

            qs2.core.ui.watchResult = ""

        Catch ex As Exception
            Throw New Exception("getWatchProtokoll: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function loadImagesFromRessources(cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                                                     ValueListToLoad As Infragistics.Win.ValueList) As Boolean

        ValueListToLoad.ValueListItems.Clear()

        Dim eAllgemein As New qs2.Resources.getRes.Allgemein
        ui.getEnumAsList(eAllgemein.GetType(), ValueListToLoad, cbo, False)

        Dim eAllgemein2 As New qs2.Resources.getRes.Allgemein2
        ui.getEnumAsList(eAllgemein2.GetType(), ValueListToLoad, cbo, False)

        Dim eLauncher As New qs2.Resources.getRes.Launcher
        ui.getEnumAsList(eLauncher.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Abrechnung As New qs2.Resources.getRes.PMDS_Abrechnung
        ui.getEnumAsList(ePMDS_Abrechnung.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Intervention As New qs2.Resources.getRes.PMDS_Intervention
        ui.getEnumAsList(ePMDS_Intervention.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Klientenakt As New qs2.Resources.getRes.PMDS_Klientenakt
        ui.getEnumAsList(ePMDS_Klientenakt.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Klientenliste As New qs2.Resources.getRes.PMDS_Klientenliste
        ui.getEnumAsList(ePMDS_Klientenliste.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_MedizinischeTypen As New qs2.Resources.getRes.PMDS_MedizinischeTypen
        ui.getEnumAsList(ePMDS_MedizinischeTypen.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_TouchDoku As New qs2.Resources.getRes.PMDS_TouchDoku
        ui.getEnumAsList(ePMDS_TouchDoku.GetType(), ValueListToLoad, cbo, False)

        Return True

    End Function
    Public Shared Function getEnumAsList(ByRef typEnum As Type, _
                                  ByRef valList As Infragistics.Win.ValueList, _
                                  ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor, _
                                  ByRef clearLists As Boolean) As System.Collections.Generic.List(Of String)

        If clearLists Then
            If Not valList Is Nothing Then
                valList.ValueListItems.Clear()
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Clear()
            End If
        End If

        Dim result As New System.Collections.Generic.List(Of String)()
        For Each val As Integer In [Enum].GetValues(typEnum)
            Dim strEnum As String = [Enum].GetName(typEnum, val)
            result.Add(strEnum)
            If Not valList Is Nothing Then
                valList.ValueListItems.Add(strEnum, strEnum)
            End If
            If Not cbo Is Nothing Then
                Dim itm As Infragistics.Win.ValueListItem = cbo.Items.Add(strEnum, strEnum)
            End If
        Next
        Return result

    End Function


    Public Shared Function ExportGridToXml(grid As UltraGrid, DsToExport As DataSet) As Boolean
        Try
            Dim funct1 As New funct()
            Dim fileSelected As String = funct1.SaveFileDialog("Xml-Files (*.Xml)|*.xml", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "")
            If fileSelected.Trim() <> "" Then
                Dim xsdFile As String = fileSelected.Substring(0, fileSelected.Length - 3) + ".xsd"
                DsToExport.WriteXml(fileSelected)
                DsToExport.WriteXmlSchema(xsdFile)
                grid.Refresh()

                Microsoft.VisualBasic.Interaction.MsgBox("Data exported!", MsgBoxStyle.Information, "Export data")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("ui.ExportGridToXml: " + ex.ToString())
        End Try
    End Function
    Public Shared Function ImportGridToXml(grid As UltraGrid, DsToImport As DataSet) As Boolean
        Try
            Dim funct1 As New funct()
            Dim fileSelected As String = funct1.SelectFileDialog("Xml-Files (*.Xml)|*.xml", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            If fileSelected.Trim() <> "" Then
                Dim xsdFile As String = fileSelected.Substring(0, fileSelected.Length - 3) + ".xsd"
                DsToImport.ReadXml(fileSelected)
                DsToImport.ReadXmlSchema(xsdFile)
                grid.Refresh()

                Microsoft.VisualBasic.Interaction.MsgBox("Data imported!", MsgBoxStyle.Information, "Import data")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("ui.ImportGridToXml: " + ex.ToString())
        End Try
    End Function

    Public Shared Function getInfoEnvironment() As String
        Try
            Dim sInfo As String = ""

            sInfo += "VersionQS2: " + qs2.core.ENV.AssemblyVersion + vbNewLine
            sInfo += "VersionDB: " + qs2.core.ENV.DBVersionFromDatabase + vbNewLine
            sInfo += "SystemIsInitialized: " + qs2.core.ENV.SystemIsInitialized.ToString().Trim() + vbNewLine
            sInfo += "Product: " + qs2.core.ENV.Product.ToString().Trim() + vbNewLine
            sInfo += "path_rootBin: " + qs2.core.ENV.path_rootBin.ToString().Trim() + vbNewLine
            sInfo += "path_bin: " + qs2.core.ENV.path_bin.ToString().Trim() + vbNewLine
            sInfo += "path_configStyles: " + qs2.core.ENV.path_config.ToString().Trim() + vbNewLine
            sInfo += "path_reports: " + qs2.core.ENV.path_reports.ToString().Trim() + vbNewLine
            sInfo += "path_log: " + qs2.core.ENV.path_log.ToString().Trim() + vbNewLine
            sInfo += "path_temp: " + qs2.core.ENV.path_temp.ToString().Trim() + vbNewLine
            If qs2.core.ENV.path_AddInsDevelop.Count > 0 Then
                sInfo += "path_AddInsDevelop.Count: " + qs2.core.ENV.path_AddInsDevelop.Count.ToString() + vbNewLine
                For Each AddInFound As String In qs2.core.ENV.path_AddInsDevelop
                    sInfo += "path_AddInsDevelop: " + AddInFound.ToString().Trim() + vbNewLine
                Next
            End If
            sInfo += "fileConfig: " + qs2.core.ENV.fileConfig.ToString().Trim() + vbNewLine
            sInfo += "configFile: " + qs2.core.ENV.configFile.ToString().Trim() + vbNewLine
            sInfo += "connStr: " + qs2.core.ENV.connStr.ToString().Trim() + vbNewLine
            sInfo += "trustedConnection: " + qs2.core.ENV.TrustedConnection.ToString().Trim() + vbNewLine
            sInfo += "CheckWindowsPassword: " + qs2.core.ENV.CheckWindowsPassword.ToString().Trim() + vbNewLine
            sInfo += "UseDomain: " + qs2.core.ENV.UseDomain.ToString().Trim() + vbNewLine
            sInfo += "rightIsAdmin: " + qs2.core.ENV.rightIsAdmin.ToString().Trim() + vbNewLine
            sInfo += "AutoNumberPatients: " + qs2.core.ENV.AutoNumberPatients.ToString().Trim() + vbNewLine
            sInfo += "AutoNumberStays: " + qs2.core.ENV.AutoNumberStays.ToString().Trim() + vbNewLine
            sInfo += "NoQS2LicenceNecessary: " + qs2.core.ENV.NoQS2LicenceNecessary.ToString().Trim() + vbNewLine
            sInfo += "XMonthDeleteStaysStartUp: " + qs2.core.ENV.XMonthDeleteStaysStartUp.ToString().Trim() + vbNewLine
            sInfo += "DeletePatientsNoStayStartUp: " + qs2.core.ENV.DeletePatientsNoStayStartUp.ToString().Trim() + vbNewLine
            sInfo += "NumberFieldsInAStayReportLine: " + qs2.core.ENV.NumberFieldsInAStayReportLine.ToString().Trim() + vbNewLine
            sInfo += "ViewUserDefined: " + qs2.core.ENV.ViewUserDefined.ToString().Trim() + vbNewLine
            sInfo += "EasyFunctions: " + qs2.core.ENV.EasyFunctions.ToString().Trim() + vbNewLine
            sInfo += "ButtProcGrpWidth: " + qs2.core.ENV.ButtProcGrpWidth.ToString().Trim() + vbNewLine
            sInfo += "ButtChapterHeigth: " + qs2.core.ENV.ButtChapterHeigth.ToString().Trim() + vbNewLine
            sInfo += "ButtProcGrpImageSizeWidth: " + qs2.core.ENV.ButtProcGrpImageSizeWidth.ToString().Trim() + vbNewLine
            sInfo += "ButtProcGrpImageSizeHeigth: " + qs2.core.ENV.ButtProcGrpImageSizeHeigth.ToString().Trim() + vbNewLine
            sInfo += "autoLogIn: " + qs2.core.ENV.autoLogIn.ToString().Trim() + vbNewLine
            sInfo += "autoLogInUser: " + qs2.core.ENV.autoLogInUser.ToString().Trim() + vbNewLine
            sInfo += "autoLogInPwdEncrypted: " + qs2.core.ENV.autoLogInPwdEncrypted.ToString().Trim() + vbNewLine
            sInfo += "autoLogInPwdDecrypted: " + qs2.core.ENV.autoLogInPwdDecrypted.ToString().Trim() + vbNewLine
            sInfo += "db: " + qs2.core.ENV.Database.ToString().Trim() + vbNewLine
            sInfo += "server: " + qs2.core.ENV.server.ToString().Trim() + vbNewLine
            sInfo += "userDb: " + qs2.core.ENV.userDb.ToString().Trim() + vbNewLine
            sInfo += "pwdDbEncrypted: " + qs2.core.ENV.pwdDbEncrypted.ToString().Trim() + vbNewLine
            sInfo += "adminSecure: " + qs2.core.ENV.adminSecure.ToString().Trim() + vbNewLine
            sInfo += "developModus: " + qs2.core.ENV.developModus.ToString().Trim() + vbNewLine
            sInfo += "protocolAllTranslationErrors: " + qs2.core.ENV.protocolAllTranslationErrors.ToString().Trim() + vbNewLine
            sInfo += "Domäne: " + qs2.core.ENV.Domäne.ToString().Trim() + vbNewLine
            sInfo += "language: " + qs2.core.ENV.language.ToString().Trim() + vbNewLine
            sInfo += "autoJoin: " + qs2.core.ENV.autoJoin.ToString().Trim() + vbNewLine
            sInfo += "monitoring: " + qs2.core.ENV.monitoring.ToString().Trim() + vbNewLine
            sInfo += "TagForMonitoring: " + qs2.core.ENV.TagForMonitoring.ToString().Trim() + vbNewLine
            sInfo += "countryDefault: " + qs2.core.ENV.countryDefault.ToString().Trim() + vbNewLine
            sInfo += "EMailService: " + qs2.core.ENV.EMailService.ToString().Trim() + vbNewLine
            sInfo += "configFileDevelop: " + qs2.core.ENV.configFileDevelop.ToString().Trim() + vbNewLine
            sInfo += "developPath: " + qs2.core.ENV.developPath.ToString().Trim() + vbNewLine
            sInfo += "developApplication: " + qs2.core.ENV.developApplication.ToString().Trim() + vbNewLine
            sInfo += "developParticipant: " + qs2.core.ENV.developParticipant.ToString().Trim() + vbNewLine
            sInfo += "developSimulateControls: " + qs2.core.ENV.developSimulateControls.ToString().Trim() + vbNewLine
            sInfo += "developCopnnected: " + qs2.core.ENV.developCopnnected.ToString().Trim() + vbNewLine
            sInfo += "fileNameConfig: " + qs2.core.ENV.fileNameConfig.ToString().Trim() + vbNewLine
            sInfo += "CountAutoForm: " + qs2.core.ENV.CountAutoForm.ToString().Trim() + vbNewLine
            sInfo += "showTabOrderAsToolTip: " + qs2.core.ENV.ExtendedUI.ToString().Trim() + vbNewLine
            sInfo += "typeLoading: " + qs2.core.ENV.typeLoading.ToString().Trim() + vbNewLine
            sInfo += "autoLoadPatients: " + qs2.core.ENV.autoLoadPatients.ToString().Trim() + vbNewLine
            sInfo += "ApplicationSelection: " + qs2.core.ENV.ApplicationSelection.ToString().Trim() + vbNewLine
            sInfo += "StandardFieldsQueries: " + qs2.core.ENV.StandardFieldsQueries.ToString().Trim() + vbNewLine
            sInfo += "ShowAllRowsQueryResult: " + qs2.core.ENV.ShowAllRowsQueryResult.ToString().Trim() + vbNewLine

            Return sInfo

        Catch ex As Exception
            Throw New Exception(ex.ToString())
        End Try
    End Function


    Public Shared Sub gridLayoutGrid_SelectionDrag(sender As Object, e As ComponentModel.CancelEventArgs)
        Try
            Dim grid As UltraGrid = sender
            grid.DoDragDrop(grid.Selected.Rows, Windows.Forms.DragDropEffects.Move)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Shared Sub gridLayoutGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs)
        Try
            e.Effect = Windows.Forms.DragDropEffects.Move
            Dim grid As UltraGrid = TryCast(sender, UltraGrid)
            Dim pointInGridCoords As System.Drawing.Point = grid.PointToClient(New System.Drawing.Point(e.X, e.Y))

            If pointInGridCoords.Y < 20 Then
                'Scroll up
                grid.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
            ElseIf pointInGridCoords.Y > grid.Height - 20 Then
                'Scroll down
                grid.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Shared Sub gridLayoutGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs, ByRef SelRows As SelectedRowsCollection, _
                                               ByRef ugrOver As UltraGridRow)
        Try
            Dim grid As UltraGrid = sender
            Dim dropIndex As Integer

            'Get the position on the grid where the dragged row(s) are to be dropped. 
            'get the grid coordinates of the row (the drop zone) 
            Dim uieOver As UIElement = grid.DisplayLayout.UIElement.ElementFromPoint(grid.PointToClient(New System.Drawing.Point(e.X, e.Y)))

            'get the row that is the drop zone/or where the dragged row is to be dropped 
            ugrOver = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

            If ugrOver IsNot Nothing Then
                dropIndex = ugrOver.Index    'index/position of drop zone in grid 

                'get the dragged row(s)which are to be dragged to another position in the grid 
                SelRows = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
                'get the count of selected rows and drop each starting at the dropIndex 
                For Each aRow As UltraGridRow In SelRows
                    'move the selected row(s) to the drop zone 
                    grid.Rows.Move(aRow, dropIndex)
                    grid.UpdateData()
                Next
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadSearchPatients(FillOptionBox As Boolean, ByRef optBoxPatient As Infragistics.Win.UltraWinEditors.UltraOptionSet, _
                                  Application As String, ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor)
        Try
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Clear()
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Clear()
            End If

            Dim opt As New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.likeName
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("PatientsName")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            opt = New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.PatID
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("PatientsID")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            opt = New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.MedRecN
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("MedicalRecordNo")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            'Im AKH Wien kann man auch nach Barcode suchen (ist im Feld OrgUnitStay gespeichert)
            If qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_HL7_SOCKET).bValue And _
                qs2.core.license.doLicense.rParticipant.IDParticipant = "91090" Then
                opt = New ValueListItem
                opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.OrgUnitStay
                opt.DisplayText = qs2.core.language.sqlLanguage.getRes("OrgUnitStay")
                If Not optBoxPatient Is Nothing Then
                    optBoxPatient.Items.Add(opt)
                End If
                If Not cbo Is Nothing Then
                    cbo.Items.Add(opt)
                End If
            End If

            opt = New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.RecordID
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("ID")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            opt = New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.DOB
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("DateOfBirth")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            Dim b As New qs2.core.db.ERSystem.businessFramework()
            Dim lstLicenseKeys As New System.Collections.Generic.List(Of String)()
            lstLicenseKeys.Add(qs2.core.Enums.eLicense.LIC_FOLLOW_UPS.ToString().Trim())
            Dim bHasLicenseFollowUp As Boolean = b.checkLicenseKey(lstLicenseKeys, "", "")
            If bHasLicenseFollowUp Then
                opt = New ValueListItem
                opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.FollowUpDate
                opt.DisplayText = qs2.core.language.sqlLanguage.getRes("FUPDt")
                If Not optBoxPatient Is Nothing Then
                    optBoxPatient.Items.Add(opt)
                End If
                If Not cbo Is Nothing Then
                    cbo.Items.Add(opt)
                End If
            End If

            opt = New ValueListItem
            opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.SurgeryDate
            opt.DisplayText = qs2.core.language.sqlLanguage.getRes("SurgDtStart")
            If Not optBoxPatient Is Nothing Then
                optBoxPatient.Items.Add(opt)
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Add(opt)
            End If

            If Application.Trim().ToLower() = qs2.core.license.doLicense.eApp.CARDIAC.ToString().Trim().ToLower() Then
                If qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_CARDIO_TECH).bValue Then
                    opt = New ValueListItem
                    opt.DataValue = qs2.core.vb.sqlObjects.eTypSelObj.CPBSerialNumber
                    opt.DisplayText = qs2.core.language.sqlLanguage.getRes("CPBSerialNo")
                    If Not optBoxPatient Is Nothing Then
                        optBoxPatient.Items.Add(opt)
                    End If
                    If Not cbo Is Nothing Then
                        cbo.Items.Add(opt)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("ui.loadSearchPatients: " + ex.ToString())
        End Try
    End Sub

    Public Function getQueryChapterType(Classification As String) As core.Enums.eStayTyp
        Try
            Dim lstClassification As System.Collections.Generic.List(Of String) = qs2.core.generic.readStrVariables(Classification.Trim())
            For Each entryClassification As String In lstClassification
                Dim sValue As String = ""
                qs2.core.vb.funct.getVariablesLefRightOfPoint(entryClassification.Trim(), "Type", sValue, "=")
                If sValue.Trim.ToLower().Equals(core.Enums.eTypList.PROCGRP.ToString().Trim().ToLower() + "0") Then
                    Return Enums.eStayTyp.Stay
                ElseIf sValue.Trim.ToLower().Equals(core.Enums.eTypList.PROCGRP.ToString().Trim().ToLower() + "1") Then
                    Return Enums.eStayTyp.FollowUp
                Else
                    Return Enums.eStayTyp.All
                End If
            Next

            Return Enums.eStayTyp.All

        Catch ex As Exception
            Throw New Exception("ui.getQueryChapterType: " + ex.ToString())
        End Try
    End Function
End Class
