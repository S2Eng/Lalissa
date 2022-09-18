Imports qs2.core.vb
Imports System.Windows.Forms



Public Class contAddIns

    Public AddIn1 As New AddIn()





    Private Sub contAddIns_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.CompAddIns1.initControl()

            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.gridAddIns1.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.AddInNameColumn.ColumnName).Hidden = False
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.DllColumn.ColumnName).Hidden = False
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.GroupColumn.ColumnName).Hidden = False
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.TypeColumn.ColumnName).Hidden = False

            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.AddInNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("AddIn")
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.DllColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Place")
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.TypeColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Type")
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.GroupColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Group")
            Me.gridAddIns1.DisplayLayout.Bands(0).Columns(Me.DsAddIn1.AddIns.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")

            Me.CompAddIns1.getAllAddIns(System.Guid.NewGuid(), Me.DsAddIn1, sqlAddIns.eTypSelAddIn.ID, "")

            AddIn1.initControl()
            AddIn1.searchAddInsInFolders(Me.gridAddIns1, Me.DsAddIn1)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub runAddInManager()
        Try
       
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean) As dsAddIn.AddInsRow
        Try
            If Not Me.gridAddIns1 Is Nothing Then
                If Me.gridAddIns1.ActiveRow.IsGroupByRow Or Me.gridAddIns1.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    Dim v As DataRowView = Me.gridAddIns1.ActiveRow.ListObject
                    Dim rSelAddIn As dsAddIn.AddInsRow = v.Row
                    Return rSelAddIn
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function


    Private Sub btnRunAddIN_Click(sender As System.Object, e As System.EventArgs) Handles btnRunAddIN.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelAddIn As dsAddIn.AddInsRow = Me.getSelectedRow(True)
            If Not rSelAddIn Is Nothing Then
                Me.AddIn1.testAddIn(rSelAddIn, True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub gridAddIns1_Click(sender As System.Object, e As System.EventArgs) Handles gridAddIns1.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelAddIn As dsAddIn.AddInsRow = Me.getSelectedRow(False)
            If Not rSelAddIn Is Nothing Then
                Dim str As String = ""
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub gridAddIns1_BeforeRowActivate(sender As System.Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridAddIns1.BeforeRowActivate

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function saveData()
        Try
            For Each rAddInFound As dsAddIn.AddInsRow In Me.DsAddIn1.AddIns
                If rAddInFound.Activated Then

                Else
                    Me.CompAddIns1.deleteAddIn(rAddInFound.ID)
                End If
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

End Class
