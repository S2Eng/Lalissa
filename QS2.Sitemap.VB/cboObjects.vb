
Imports Infragistics.Win.UltraWinGrid



Public Class cboObjects



    Private Sub cboObjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControls()
        Try

            For Each col As UltraGridColumn In Me.cbObjects.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Hidden = False
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Header.VisiblePosition = 0
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Width = 150
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LastName")

            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Hidden = False
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Header.VisiblePosition = 1
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Width = 130
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("FirstName")

            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Hidden = False
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Header.VisiblePosition = 2
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Width = 100
            Me.cbObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("DOB")

            Me.SqlObjects1.initControl()
            Me.loadData()

        Catch ex As Exception
            Throw New Exception("cboObjects.initControls: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData()
        Try
            Me.DsObjects1.Clear()
            Me.SqlObjects1.getObject(-999, Me.DsObjects1, core.vb.sqlObjects.eTypSelObj.All, core.vb.sqlObjects.eTypObj.IsPatient, "", "", False, Nothing, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim())
            Me.cbObjects.Refresh()

            Me.cbObjects.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cbObjects.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsObjects1.tblObject.LastNameColumn.ColumnName, False)
            Me.cbObjects.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName, False)

        Catch ex As Exception
            Throw New Exception("cboObjects.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean) As qs2.core.vb.dsObjects.tblObjectRow
        Try
            If Not Me.cbObjects.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.cbObjects.ActiveRow.ListObject
                Dim rSelRow As qs2.core.vb.dsObjects.tblObjectRow = v.Row
                Return rSelRow
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK,
                                                    qs2.core.language.sqlLanguage.getRes("Sort"))
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("cboObjects.getSelectedRow: " + ex.ToString())
        End Try
    End Function

End Class
