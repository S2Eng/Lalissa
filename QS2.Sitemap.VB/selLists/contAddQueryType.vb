Imports System.Collections.Generic
Imports qs2.core
Imports qs2.core.print




Public Class contAddQueryType

    Public _IsNewQuery As Boolean = False

    Public Application As String = ""
    Public Participant As String = ""

    Public MainWindow As contAddSelList = Nothing

    Public lstTypeQueries As System.Collections.Generic.List(Of KeyValuePair(Of String, String)) = Nothing

    Public tSimpleViews As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Nothing
    Public tSimpleFunctions As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable = Nothing

    Public printWork As qs2.core.print.print = Nothing
    Public IsInitialized As Boolean = False
    Public abort As Boolean = True

    Public sqlAdminWork As qs2.core.vb.sqlAdmin = Nothing
    Public dsAdminWork As qs2.core.vb.dsAdmin = Nothing

    Public Enum eTypeAction
        DeselectAll = 0
        SelectByTableName = 1
    End Enum

    Public lockOptionBox As Boolean = False
    Public b As New qs2.core.db.ERSystem.businessFramework()






    Private Sub contQuerySelectType_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub

    Public Sub initControl()
        Try
            If Me.IsInitialized Then
                Exit Sub
            End If

            Me.printWork = New core.print.print()
            Me.lstTypeQueries = New System.Collections.Generic.List(Of KeyValuePair(Of String, String))

            Dim newCol As Infragistics.Win.UltraWinGrid.UltraGridColumn = Me.gridSimpleTables.DisplayLayout.Bands(0).Columns.Add(qs2.core.generic.columnNameSelection, qs2.core.language.sqlLanguage.getRes("Selection"))
            newCol.DataType = GetType(String)
            newCol.Header.VisiblePosition = 0
            newCol.Width = 80
            newCol.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            Me.doRes()

            Me.dsAdminWork = New qs2.core.vb.dsAdmin()
            Me.sqlAdminWork = New qs2.core.vb.sqlAdmin()
            Me.sqlAdminWork.initControl()

            Me.IsInitialized = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub initDefaultTables()
        Try
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.dsAdminWork.tblSelListEntries.Clear()
            Me.sqlAdminWork.getSelListEntrys(Parameters, "SimpleQueries", Me.Participant, Me.Application, Me.dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.group)
            Me.tSimpleViews = Me.dsAdminWork.tblSelListEntries.Copy()

            Parameters = New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.dsAdminWork.tblSelListEntries.Clear()
            Me.sqlAdminWork.getSelListEntrys(Parameters, "SimpleFunctions", Me.Participant, Me.Application, Me.dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.group)
            Me.tSimpleFunctions = Me.dsAdminWork.tblSelListEntries.Copy()

            Me.IsInitialized = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub doRes()
        Try
            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.gridSimpleTables.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.gridSimpleTables.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection).Hidden = False
            Me.gridSimpleTables.DisplayLayout.Bands(0).Columns(Me.DsSimpleQuerySelection1.SimpleTables.TranslationTableNameColumn.ColumnName).Hidden = False

            Me.lblTypeOfQuery.Text = qs2.core.language.sqlLanguage.getRes("PleaseSelectTheTypeOfYourNewQuery") + ":"
            Me.lblTypeOfContent.Text = qs2.core.language.sqlLanguage.getRes("PleaseSelectTheTypeOfContent") + ":"

            Me.gridSimpleTables.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection).Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection")
            Me.gridSimpleTables.DisplayLayout.Bands(0).Columns(Me.DsSimpleQuerySelection1.SimpleTables.TranslationTableNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Query")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try

    End Sub
    Public Sub resetTableSelection()
        Try
            Me.panelTables.Visible = False

            Me.DsSimpleQuerySelection1.SimpleTables.Clear()
            Me.gridSimpleTables.Refresh()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadData(ByRef QueryType As String, ByRef TableNameToLoad As String, ByRef NewQuery As Boolean)
        Try
            Me._IsNewQuery = NewQuery

            Me.resetTableSelection()
            Me.optQueryType.Items.Clear()
            'If NewQuery Then
            '    QueryType = qs2.core.print.print.eQueryType.SimpleFunction.ToString()
            'End If

            Dim firstItm As Boolean = True
            Me.lstTypeQueries.Clear()
            Me.printWork.getQueryTypes(Me.lstTypeQueries)
            For Each itm As System.Collections.Generic.KeyValuePair(Of String, String) In Me.lstTypeQueries
                Dim bShow As Boolean = True
                ' And Not qs2.core.vb.actUsr.rUsr.isAdmin 
                If Not qs2.core.ENV.adminSecure And _
                    (itm.Key.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower() Or _
                      itm.Key.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.FullMode.ToString().ToLower()) Then
                    bShow = False
                End If
                If bShow Then
                    Dim itmValList As Infragistics.Win.ValueListItem = Me.optQueryType.Items.Add(itm.Key, itm.Value)
                    If firstItm And NewQuery Then
                        Me.optQueryType.CheckedIndex = 0
                    End If
                    firstItm = False
                End If
            Next

            Dim index As Integer = 0
            For Each itmSelected As Infragistics.Win.ValueListItem In Me.optQueryType.Items
                If itmSelected.DataValue.ToString().Trim().ToLower().Equals((QueryType).Trim().ToLower()) Then
                    Me.lockOptionBox = True
                    itmSelected.CheckState = Windows.Forms.CheckState.Checked
                    Me.optQueryType.CheckedIndex = index
                End If
                index += 1
            Next
            Me.lockOptionBox = False
            Me.optQueryType.Refresh()

            'If Me.optQueryType.Items.Count > 0 Then
            Me.loadTableSelection(QueryType, TableNameToLoad, NewQuery)
            'End If

        Catch ex As Exception
            Me.lockOptionBox = False
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.lockOptionBox = False
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            Me.ErrorProvider1.SetError(Me.optQueryType, "")
            Me.ErrorProvider1.SetError(Me.gridSimpleTables, "")

            Dim SelectedQueryType As String = Me.getSelectedQueryType()
            If SelectedQueryType.Trim() = "" Then
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoQueryTypeSelection") + "!"
                Me.ErrorProvider1.SetError(Me.optQueryType, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False

            End If

            If SelectedQueryType.ToString().Trim().ToLower() <> qs2.core.print.print.eQueryType.FullMode.ToString().ToLower() Then
                Dim rActSimpTable As dsSimpleQuerySelection.SimpleTablesRow = Me.getSelectedSelList()
                Dim selectedTableName As String = rActSimpTable.TableName.Trim()
                If selectedTableName.Trim() = "" Then
                    Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoTableSelection") + "!"
                    Me.ErrorProvider1.SetError(Me.gridSimpleTables, txt)
                    qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                    Return False

                End If
            End If

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Sub loadTableSelection(QueryTypeToLoad As String, TableNameToLoad As String, NewQuery As Boolean)
        Try
            Me.resetTableSelection()

            If QueryTypeToLoad.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower() Then
                Me.loadTableList(tSimpleViews, QueryTypeToLoad, TableNameToLoad, NewQuery)
                Me.doAction(Nothing, TableNameToLoad, eTypeAction.SelectByTableName, NewQuery)

            ElseIf QueryTypeToLoad.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower() Then
                Me.loadTableList(tSimpleFunctions, QueryTypeToLoad, TableNameToLoad, NewQuery)
                Me.doAction(Nothing, TableNameToLoad, eTypeAction.SelectByTableName, NewQuery)

            ElseIf QueryTypeToLoad.ToString().Trim().ToLower() = qs2.core.print.print.eQueryType.FullMode.ToString().ToLower() Then
                Me.panelTables.Visible = False

            Else
                Throw New Exception("contQuerySelectType.loadTableSelection: itmValList.DataValue '" + QueryTypeToLoad.ToString() + "' not exists in Enum QueryType!")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadTableList(ByRef tViewFunctions As qs2.core.vb.dsAdmin.tblSelListEntriesDataTable, _
                             ByRef QueryTypeToLoad As String, ByRef TableNameToLoad As String, ByRef NewQuery As Boolean)
        Try
            Me.resetTableSelection()
            For Each rSelList As qs2.core.vb.dsAdmin.tblSelListEntriesRow In tViewFunctions
                Dim Translated As String = qs2.core.language.sqlLanguage.getRes(rSelList.IDRessource.Trim())
                If Translated.Trim() = "" Then
                    Translated = rSelList._Table.Trim()
                End If

                Dim bHasLicense As Boolean = False
                If rSelList.LicenseKey.Trim() = "" Then
                    bHasLicense = True
                Else
                    Dim lstLicenseKeys As New System.Collections.Generic.List(Of String)()
                    lstLicenseKeys.Add(rSelList.LicenseKey.Trim())
                    bHasLicense = Me.b.checkLicenseKey(lstLicenseKeys, "", "")
                End If
                If bHasLicense Then
                    Dim rNewRow As dsSimpleQuerySelection.SimpleTablesRow = Me.printWork.newRowSimpleQuery(Me.DsSimpleQuerySelection1)    'Me.DsSimpleQuerySelection1.SimpleTables.NewRow()
                    rNewRow.ID = System.Guid.NewGuid()
                    rNewRow.TranslationTableName = Translated.Trim()
                    rNewRow.TableName = rSelList._Table.Trim()
                    rNewRow.Classification = rSelList.Classification
                    rNewRow.Description = ""
                End If
            Next

            Me.gridSimpleTables.ActiveRow = Nothing
            Me.gridSimpleTables.Refresh()
            Me.gridSimpleTables.ActiveRow = Nothing

            Me.panelTables.Visible = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function getSelectedRow(msgBox As Boolean, SelRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsSimpleQuerySelection.SimpleTablesRow
        Try
            If Not Me.gridSimpleTables.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.gridSimpleTables.ActiveRow.ListObject
                Dim rSelectedTable As dsSimpleQuerySelection.SimpleTablesRow = v.Row
                Return rSelectedTable
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub optQueryType_ValueChanged(sender As System.Object, e As System.EventArgs) Handles optQueryType.ValueChanged
        Try
            If Me.lockOptionBox Then
                Exit Sub
            End If

            If Me.optQueryType.Focused Then
                Dim itmSelected As Infragistics.Win.ValueListItem = Me.optQueryType.Items(Me.optQueryType.CheckedIndex)
                Me.lockOptionBox = True
                Me.loadTableSelection(itmSelected.DataValue, "", Me._IsNewQuery)
                'itmSelected.CheckState = Windows.Forms.CheckState.Checked
            End If

        Catch ex As Exception
            Me.lockOptionBox = False
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.lockOptionBox = False
        End Try
    End Sub


    Private Sub gridSimpleTables_BeforeRowsDeleted(sender As System.Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridSimpleTables.BeforeRowsDeleted
        Try
            e.Cancel = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSimpleTables_BeforeCellActivate(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridSimpleTables.BeforeCellActivate
        Try
            If e.Cell.Column.ToString().Trim().ToLower.Equals((qs2.core.generic.columnNameSelection).Trim().ToLower()) Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSimpleTables_Click(sender As System.Object, e As System.EventArgs) Handles gridSimpleTables.Click
        Try
            Dim SelRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            'Me.rSelectedSimpleTable = Me.getSelectedRow(True, SelRowGrid)
            'If Not Me.rSelectedSimpleTable Is Nothing Then
            '    'Me.btnOK.Enabled = True
            'End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSimpleTables_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gridSimpleTables.DoubleClick
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSimpleTables_CellChange(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridSimpleTables.CellChange
        Try
            Me.gridSimpleTables.UpdateData()
            Me.doAction(e.Cell.Row.Cells(Me.DsSimpleQuerySelection1.SimpleTables.IDColumn.ColumnName).Value, "", eTypeAction.DeselectAll, Me._IsNewQuery)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub doAction(ByRef IDIsOn As System.Guid, ByRef tableNameToSelect As String, ByRef TypeAction As eTypeAction, _
                        ByRef NewQuery As Boolean)
        Try
            If tableNameToSelect.Trim() = "" Then
                If Me.gridSimpleTables.Rows.Count > 0 Then
                    Dim v As DataRowView = Me.gridSimpleTables.Rows(0).ListObject
                    Dim rActSimpTable As dsSimpleQuerySelection.SimpleTablesRow = v.Row
                    If TypeAction = eTypeAction.SelectByTableName Then
                        tableNameToSelect = rActSimpTable.TableName.Trim()
                    End If
                End If
            End If

            Dim TableIsSelected As Boolean = False
            For Each SelRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSimpleTables.Rows
                Dim v As DataRowView = SelRowGrid.ListObject
                Dim rActSimpTable As dsSimpleQuerySelection.SimpleTablesRow = v.Row

                If TypeAction = eTypeAction.DeselectAll Then
                    If rActSimpTable.ID.Equals(IDIsOn) Then
                        SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = True
                    Else
                        SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = False
                    End If

                ElseIf TypeAction = eTypeAction.SelectByTableName Then
                    If rActSimpTable.TableName.Trim.ToLower().Equals(tableNameToSelect.Trim().ToLower()) And Not TableIsSelected Then
                        SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = True
                        TableIsSelected = True
                    Else
                        SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = False
                    End If

                End If
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function getSelectedSelList() As dsSimpleQuerySelection.SimpleTablesRow
        Try
            Dim nSelListsChecked As Integer = 0
            For Each SelRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSimpleTables.Rows
                Dim v As DataRowView = SelRowGrid.ListObject
                Dim rActSimpTable As dsSimpleQuerySelection.SimpleTablesRow = v.Row
                If SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = True Then
                    nSelListsChecked += 1
                End If
            Next
            If nSelListsChecked > 1 Then
                Throw New Exception("contAddQueryType.getSelectedTableName: Error - More than one SelList checked!")
            End If

            Dim TableIsSelected As Boolean = False
            For Each SelRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSimpleTables.Rows
                Dim v As DataRowView = SelRowGrid.ListObject
                Dim rActSimpTable As dsSimpleQuerySelection.SimpleTablesRow = v.Row
                If SelRowGrid.Cells(qs2.core.generic.columnNameSelection).Value = True Then
                    Return rActSimpTable
                End If
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function getSelectedQueryType() As String
        Try
            Dim itmSelected As Infragistics.Win.ValueListItem = Me.optQueryType.Items(Me.optQueryType.CheckedIndex)
            If itmSelected Is Nothing Then
                Return ""
            Else
                Return itmSelected.DataValue.ToString()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
            Return ""
        End Try
    End Function

End Class
