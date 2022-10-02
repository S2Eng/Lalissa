Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared


Public Class contUserAccouts

    Public gen As New General()
    Public editable As Boolean = False

    Public lstColSmallViewGrid As New System.Collections.Generic.List(Of String)
    Public lstColBigViewGridDeaktivate As New System.Collections.Generic.List(Of String)
    Public lstColBigViewGridErw As New System.Collections.Generic.List(Of String)

    Public isLoaded As Boolean = False

    Public doUI1 As New doUI()
    Public SupervisorModeOnOff As Boolean = False
    Private uiElem As New UI()






    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.cboTyp.Items.Add(compUserAccounts.eTypEMailAccount.SMTP.ToString(), compUserAccounts.eTypEMailAccount.SMTP.ToString())
            Me.cboTyp.Items.Add(compUserAccounts.eTypEMailAccount.Pop3.ToString(), compUserAccounts.eTypEMailAccount.Pop3.ToString())
            Me.cboTyp.Value = compUserAccounts.eTypEMailAccount.SMTP.ToString()

            'If Not ITSCont.core.SystemDb.actUsr.rUsr.IsAdmin And Not Settings.adminSecure Then
            '    Me.PanelButtEdit.Visible = False
            '    Me.GesamtesServiceProtokollLöschenToolStripMenuItem.Visible = False
            'End If
            Me.gridUserAccounts.DisplayLayout.ValueLists("Users").ValueListItems.Clear()
            Me.gen.getAllSachb(Nothing, Me.gridUserAccounts.DisplayLayout.ValueLists("Users"))
            'Me.ui1.setMergeStyle(Me.gridUserAccounts, True, True)
            Me.doGridUI(False, compUserAccounts.eTypEMailAccount.SMTP)

            Me.PanelButtEditUserAccounts.Visible = True

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contUserAccouts.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub doValueListSMTPUserAccounts()
        Try
            Dim compUserAccountsRead As New compUserAccounts()
            Dim dsUserAccountsRead As New dsUserAccounts()

            Me.gridUserAccounts.DisplayLayout.ValueLists("SMTPAccounts").ValueListItems.Clear()
            compUserAccountsRead.getUserAccounts(Nothing, "", dsUserAccountsRead, compUserAccounts.eTypSelUserAccounts.allTypEMailAccount, compUserAccounts.eTypEMailAccount.SMTP, False)
            For Each rSmtpUserAccount As dsUserAccounts.tblUserAccountsRow In dsUserAccountsRead.tblUserAccounts
                Me.gridUserAccounts.DisplayLayout.ValueLists("SMTPAccounts").ValueListItems.Add(rSmtpUserAccount.ID, rSmtpUserAccount.Name)
            Next

        Catch ex As Exception
            Throw New Exception("contUserAccouts.doValueListSMTPUserAccounts: " + ex.ToString())
        End Try
    End Sub

    Public Sub doGridUI(ByVal erweitert As Boolean, ByVal typ As compUserAccounts.eTypEMailAccount)
        Try
            Me.lstColSmallViewGrid.Clear()
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.UsrColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.NameColumn.ColumnName)

            If typ = compUserAccounts.eTypEMailAccount.SMTP Then
                Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.AdrFromColumn.ColumnName)
                'Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.AdrToColumn.ColumnName)

            ElseIf typ = compUserAccounts.eTypEMailAccount.Pop3 Then
                Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.IDAccountColumn.ColumnName)
                Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.lastReceiveColumn.ColumnName)

            End If

            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.ServerColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.PortColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.UsrAuthenticationColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.PwdAuthenticationColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.SSLColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.PostOfficeBoxForAllColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.PreferPostOfficeBoxForAllColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsUserAccounts1.tblUserAccounts.OutlookWebAPIColumn.ColumnName)

            Me.uiElem.gridErwSicht(False, Me.gridUserAccounts.DisplayLayout.Bands(0), Me.lstColSmallViewGrid, Me.lstColBigViewGridDeaktivate)

            'Me.gridUserAccounts.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Catch ex As Exception
            Throw New Exception("contUserAccouts.doGridUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData()
        Try
            Me.doValueListSMTPUserAccounts()
            Me.lockUnlock(False)

            If Me.getSelectedEMailAccount() = compUserAccounts.eTypEMailAccount.Pop3 Then
                Me.doGridUI(False, Me.getSelectedEMailAccount())
            ElseIf Me.getSelectedEMailAccount() = compUserAccounts.eTypEMailAccount.SMTP Then
                Me.doGridUI(True, Me.getSelectedEMailAccount())
            End If

            Dim LoggedOnUser As String = ""
            If Not PMDS.Global.ENV.adminSecure Then
                LoggedOnUser = Me.gen.getLoggedInUser()
            End If

            Me.DsUserAccounts1.tblUserAccounts.Clear()
            Me.CompUserAccounts1.getUserAccounts(Nothing, LoggedOnUser, Me.DsUserAccounts1, compUserAccounts.eTypSelUserAccounts.allTypEMailAccount, Me.getSelectedEMailAccount(), False)

            Me.gridUserAccounts.Refresh()
            Me.lockUnlock(editable)

            Me.lblCount.Text = "Gefunden: " + Me.DsUserAccounts1.tblUserAccounts.Rows.Count.ToString()

        Catch ex As Exception
            Throw New Exception("contUserAccouts.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearErrProvider()
        Try
            Me.ErrorProvider1.SetError(Me.btnAdd, "")
            For Each rGrid As UltraGridRow In Me.gridUserAccounts.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = v.Row
                If rUserAccount.RowState <> DataRowState.Deleted Then
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.AdrFromColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.AdrToColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.UsrColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.ServerColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.UsrAuthenticationColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.PwdAuthenticationColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.NameColumn.ColumnName, "")
                    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.IDAccountColumn.ColumnName, "")
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contUserAccouts.clearErrProvider: " + ex.ToString())
        End Try
    End Sub
    Public Function validate() As Boolean
        Try
            Me.clearErrProvider()

            For Each rGrid As UltraGridRow In Me.gridUserAccounts.Rows
                For Each r As dsUserAccounts.tblUserAccountsRow In Me.DsUserAccounts1.tblUserAccounts
                    Dim v As DataRowView = rGrid.ListObject
                    Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = v.Row

                    If r.RowState <> DataRowState.Deleted Then

                        If r.Name.Trim() = "" Then
                            Dim txt As String = "Name Postfach: Eingabe erforderlich!"
                            rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.NameColumn.ColumnName, txt)
                            MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                            Return False

                        ElseIf r.Usr.Trim() = "" Then
                            Dim txt As String = "Benutzer: Auswahl erforderlich!"
                            rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.UsrColumn.ColumnName, txt)
                            MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                            Return False

                        ElseIf r.Server.Trim() = "" Then
                            Dim txt As String = "Server: Eingabe erforderlich!"
                            rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.ServerColumn.ColumnName, txt)
                            MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                            Return False

                        ElseIf r.UsrAuthentication.Trim() = "" Then
                            Dim txt As String = "Benutzer-Authentifizierung: Eingabe erforderlich!"
                            rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.UsrAuthenticationColumn.ColumnName, txt)
                            MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                            Return False

                        ElseIf r.PwdAuthentication.Trim() = "" Then
                            Dim txt As String = "Pwd.-Authentifizierung: Eingabe erforderlich!"
                            rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.PwdAuthenticationColumn.ColumnName, txt)
                            MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                            Return False

                        End If

                        If Me.getSelectedEMailAccount() = compUserAccounts.eTypEMailAccount.SMTP Then
                            If r.AdrFrom.Trim() = "" Then
                                Dim txt As String = "E-Mail Adresse Absender: Eingabe erforderlich!"
                                rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.AdrFromColumn.ColumnName, txt)
                                MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                                Return False

                                'ElseIf r.AdrTo.Trim() = "" Then
                                '    Dim txt As String = "E-Mail Adresse Empfänger: Eingabe erforderlich!"
                                '    rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.AdrToColumn.ColumnName, txt)
                                '    MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                                '    Return False

                            End If

                        ElseIf Me.getSelectedEMailAccount() = compUserAccounts.eTypEMailAccount.Pop3 Then
                            If r.IsIDAccountNull() Then
                                Dim txt As String = "Smtp-Postfach: Auswahl erforderlich!"
                                rUserAccount.SetColumnError(Me.DsUserAccounts1.tblUserAccounts.IDAccountColumn.ColumnName, txt)
                                MsgBox(txt, MsgBoxStyle.Information, "Speichern")
                                Return False

                            End If
                        End If
                    End If
                Next
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contUserAccouts.validate: " + ex.ToString())
        End Try
    End Function
    Public Function save() As Boolean
        Try
            If Not Me.validate() Then Return False

            Me.CompUserAccounts1.daUserAccounts.Update(Me.DsUserAccounts1.tblUserAccounts)
            Return True

        Catch ex As Exception
            Throw New Exception("contUserAccouts.save: " + ex.ToString())
        End Try
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.save() Then
                Me.loadData()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub add()
        Try
            Dim rNew As dsUserAccounts.tblUserAccountsRow = Me.CompUserAccounts1.getNewRowUserAccounts(Me.DsUserAccounts1.tblUserAccounts)
            rNew.typ = Me.getSelectedEMailAccount().ToString()
            rNew.Port = "25"

            Dim gridRowToSelect As UltraGridRow = Me.gridUserAccounts.Rows.GetRowWithListIndex(Me.DsUserAccounts1.tblUserAccounts.Rows.IndexOf(rNew))
            Me.gridUserAccounts.ActiveRow = gridRowToSelect

        Catch ex As Exception
            Throw New Exception("contUserAccouts.add: " + ex.ToString())
        End Try
    End Sub
    Public Sub delete()
        Try
            Dim arrSelected As New System.Collections.Generic.List(Of UltraGridRow)
            Dim sitemap1 As New PMDS.Global.generic()
            Dim res As System.Windows.Forms.DialogResult = sitemap1.doAction([Global].generic.eAction.print, "", "", "", Me.gridUserAccounts, Nothing, arrSelected, False, True)
            Dim listID As New System.Collections.Generic.List(Of System.Guid)
            If arrSelected.Count = 0 Then
                MsgBox("Keinen Eintrag ausgewählt!", MsgBoxStyle.Information, "Löschen")
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub

            Else
                If MsgBox("Wollen Sie das Postfach wirklich löschen?" + vbNewLine +
                          "(Achtung: Es werden alle E-Mails dieses Postfaches ebenfalls gelöscht!)", MsgBoxStyle.YesNo, "Postfach löschen") = vbYes Then
                    For Each r As UltraGridRow In arrSelected
                        r.Delete()
                    Next
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contUserAccouts.delete: " + ex.ToString())
        End Try
    End Sub
    Public Function getSelectedEMailAccount() As compUserAccounts.eTypEMailAccount
        Try
            Dim typTemp As New compUserAccounts.eTypEMailAccount
            Return General.searchEnumTypEMailAccount(Me.cboTyp.Value, typTemp.GetType)

        Catch ex As Exception
            Throw New Exception("contUserAccouts.getSelectedEMailAccount: " + ex.ToString())
        End Try
    End Function

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.delete()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.btnAdd.Visible = bEdit
            Me.btnDel.Visible = bEdit
            Me.btnSave.Enabled = bEdit
            Me.btnApport.Enabled = bEdit
            Me.editable = bEdit
            If Me.editable Then
                Me.gridUserAccounts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.gridUserAccounts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

        Catch ex As Exception
            Throw New Exception("contUserAccouts.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridUserAccounts.BeforeCellActivate
        Try
            If e.Cell.Row.IsFilterRow Or e.Cell.Row.IsGroupByRow Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            End If

            If Not Me.editable Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridUserAccounts.BeforeRowsDeleted
        Try
            If Me.gridUserAccounts.Focused Then
                e.DisplayPromptMsg = True
                e.Cancel = True
            Else
                e.DisplayPromptMsg = False
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub dropDownEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropDownEdit.Click
        Try
            Me.lockUnlock(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub btnApport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApport.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadData()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AlleAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        Try
            Me.AlleAuswählen(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub KeineAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswählenToolStripMenuItem.Click
        Try
            Me.AlleAuswählen(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub AlleAuswählen(ByVal JaNein As Boolean)
        Try
            For Each r As UltraGridRow In PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridUserAccounts, False, True)
                If PMDS.Global.generic.IsInExpandedGroup(r) Then
                    r.Selected = JaNein
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contUserAccouts.AlleAuswählen: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraGrid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridUserAccounts.DoubleClick
        Try
            Dim ui1 As New PMDS.Global.UIGlobal()
            If ui1.evDoubleClickOK(sender, e, Me.gridUserAccounts) Then
                If Not Me.gridUserAccounts.ActiveRow Is Nothing Then
                    If Not Me.gridUserAccounts.ActiveRow.Expanded Then
                        Me.gridUserAccounts.ActiveRow.Expanded = True
                    Else
                        Me.gridUserAccounts.ActiveRow.Expanded = False
                    End If
                    'Dim v As DataRowView = Me.UltraGrid1.ActiveRow.ListObject
                    'Dim rRight As dsAuswahllisten.AuswahllistenRow = v.Row
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub groupGrid(ByVal bOn As Boolean)
        Try
            If bOn Then
                Me.gridUserAccounts.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            Else
                Me.gridUserAccounts.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.add()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboTyp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTyp.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.cboTyp.Focused Then
                Me.loadData()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SupervisorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupervisorToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim frmInputPwdHour1 As New frmInputPwdHour()
            frmInputPwdHour1.ShowDialog(Me)
            If Not frmInputPwdHour1.abort Then
                If frmInputPwdHour1.pwdOK Then
                    Me.PanelButtEditUserAccounts.Visible = True
                    Me.SupervisorModeOnOff = True
                    doUI.doMessageBox2("AdvancedFunctionalityIsActivated", "", "!")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class