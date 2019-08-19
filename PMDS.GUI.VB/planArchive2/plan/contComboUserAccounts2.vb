Imports Infragistics.Win.UltraWinGrid



Public Class contComboUserAccounts2


    Public gen As New General()
    Public isLoaded As Boolean = False

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public doUI1 As New doUI()





    Public Sub initControl(ByRef ComboStyle As UltraComboStyle)
        Try
            If Me.isLoaded Then Return

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.cboComboBoxUsrAccounts.DropDownStyle = ComboStyle
            'Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.Auswahllisten.BezeichnungColumn.ColumnName).Hidden = False

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contComboUserAccounts2.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadUserAccounts(ByVal typ As compUserAccounts.eTypEMailAccount, ByVal usr As String)
        Try
            Me.DsUserAccounts1.tblUserAccounts.Clear()
            If usr.Trim() = "" Then
                Me.CompUserAccounts1.getUserAccounts(Nothing, "", Me.DsUserAccounts1, compUserAccounts.eTypSelUserAccounts.allTypEMailAccount, typ, False)
            Else
                Me.CompUserAccounts1.getUserAccounts(Nothing, usr, Me.DsUserAccounts1, compUserAccounts.eTypSelUserAccounts.usr, typ, False)
            End If
            Me.cboComboBoxUsrAccounts.Refresh()

            Me.cboComboBoxUsrAccounts.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cboComboBoxUsrAccounts.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsUserAccounts1.tblUserAccounts.NameColumn.ColumnName, False)

        Catch ex As Exception
            Throw New Exception("contComboUserAccounts2.loadUserAccounts: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedUserAccount(ByVal withMsgBox As Boolean) As dsUserAccounts.tblUserAccountsRow
        Try
            If Not Me.cboComboBoxUsrAccounts.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.cboComboBoxUsrAccounts.ActiveRow.ListObject
                Dim rSelUserAccounts As dsUserAccounts.tblUserAccountsRow = v.Row
                Return rSelUserAccounts
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Me.cboComboBoxUsrAccounts.Focus()
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contComboUserAccounts2.getSelectedUserAccount: " + ex.ToString())
        End Try
    End Function

    Private Sub AuswahlLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuswahlLöschenToolStripMenuItem.Click
        Try
            Me.clearSelection()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub cboComboBoxSelList_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComboBoxUsrAccounts.ValueChanged
        Try
            If Me.cboComboBoxUsrAccounts.Focused Then
                If Not Me.delonValueChanged Is Nothing Then
                    Me.delonValueChanged.Invoke()
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub clearSelection()
        Try
            'Me.cboComboBoxSelList.Value = Nothing
            Me.cboComboBoxUsrAccounts.SelectedRow = Nothing
            Me.cboComboBoxUsrAccounts.ActiveRow = Nothing
            Me.cboComboBoxUsrAccounts.Text = ""
            Me.cboComboBoxUsrAccounts.Refresh()

        Catch ex As Exception
            Throw New Exception("contComboUserAccounts2.clearSelection: " + ex.ToString())
        End Try
    End Sub

End Class
