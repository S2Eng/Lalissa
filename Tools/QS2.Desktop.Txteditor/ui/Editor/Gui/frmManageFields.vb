Imports System.IO
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports QS2.Resources



Public Class frmManageFields

    Public keyNr As Integer = 0
    Public lstCopiedRows As New System.Collections.Generic.List(Of dsManage.FieldsRow)











    Private Sub frmManageFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Sub initControl()
        Try
            Me.Icon = getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.btnAdd.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDel.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnSave.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

        Catch ex As Exception
            Throw New Exception("frmManageFields.initControl: " + ex.ToString())
        End Try
    End Sub


    Public Sub loadData()
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = Application.StartupPath()
            openFileDialog1.Filter = "Config Fields files (*.xml)|*.xml"
            openFileDialog1.RestoreDirectory = True
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.DsManage1.Clear()
                Me.gridFields.Refresh()

                Me.DsManage1.ReadXml(openFileDialog1.FileName.Trim(), XmlReadMode.IgnoreSchema)
                Me.gridFields.Refresh()
                Me.lblPath.Text = openFileDialog1.FileName.Trim()

                'For Each rGrid As UltraGridRow In Me.gridFields.Rows
                '    Dim v As DataRowView = rGrid.ListObject
                '    Dim rSelRow As dsManage.FieldsRow = v.Row

                '    If Not frmManageFields.delDoRes Is Nothing Then
                '        Dim sTranslated As String = ""
                '        sTranslated = frmManageFields.delDoRes(rSelRow.DataTable.Trim() + "" + rSelRow.ColumnName.Trim())
                '        If sTranslated.Trim() <> "" Then
                '            rSelRow.FieldNameUI = sTranslated.Trim()
                '        Else
                '            rSelRow.FieldNameUI = rSelRow.ColumnName.Trim()
                '        End If
                '    Else
                '        'If rSelRow.FieldNameUI.Trim().ToLower().Equals(("[AutoTranslate]").Trim().ToLower()) Then
                '        '    rSelRow.FieldNameUI = rSelRow.ColumnName.Trim()
                '        'End If
                '    End If
                'Next
            End If

        Catch ex As Exception
            Throw New Exception("frmManageFields.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Function saveData() As Boolean
        Try
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Config Fields files (*.xml)|*.xml"
            saveFileDialog1.Title = "Save Config-File Fields"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.FileName <> "" Then
                If System.IO.File.Exists(Me.lblPath.Text) Then
                    System.IO.File.Delete(Me.lblPath.Text)
                    System.GC.Collect()
                End If

                Me.DsManage1.WriteXml(saveFileDialog1.FileName, XmlWriteMode.IgnoreSchema)
                Me.lblPath.Text = saveFileDialog1.FileName

                MessageBox.Show("Data saved!")
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("frmManageFields.saveData: " + ex.ToString())
        End Try
    End Function

    Public Sub addRow()
        Try
            Dim rNew As dsManage.FieldsRow = generic.getNewRowField(Me.DsManage1, True, Me.keyNr)
            Me.gridFields.Refresh()

        Catch ex As Exception
            Throw New Exception("frmManageFields.addRow: " + ex.ToString())
        End Try
    End Sub


    Public Sub delRow()
        Try
            Dim selRowGrid As UltraGridRow = Nothing
            Dim rSelRow As dsManage.FieldsRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelRow Is Nothing Then
                rSelRow.Delete()
            End If

        Catch ex As Exception
            Throw New Exception("frmManageFields.delRow: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal withMsgBox As Boolean, ByRef selRowGrid As UltraGridRow) As dsManage.FieldsRow
        Try
            If Not Me.gridFields.ActiveRow Is Nothing Then
                If Me.gridFields.ActiveRow.IsGroupByRow Or Me.gridFields.ActiveRow.IsFilterRow Then
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridFields.ActiveRow.ListObject
                    Dim rSelRow As dsManage.FieldsRow = v.Row
                    selRowGrid = Me.gridFields.ActiveRow
                    Return rSelRow
                End If
            Else
                If withMsgBox Then
                    MessageBox.Show("No row selected!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("frmManageFields.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Public Sub CopyRows()
        Try
            Me.lstCopiedRows.Clear()
            For Each rSelRows As UltraGridRow In Me.gridFields.Selected.Rows
                Dim v As DataRowView = rSelRows.ListObject
                Dim rSelvpreCalc As dsManage.FieldsRow = v.Row

                Me.lstCopiedRows.Add(rSelvpreCalc)
            Next

        Catch ex As Exception
            Throw New Exception("frmManageFields.CopyRows: " + ex.ToString())
        End Try
    End Sub
    Public Sub PasteRows()
        Try
            For Each rSelRows As dsManage.FieldsRow In Me.lstCopiedRows
                Dim rNew As dsManage.FieldsRow = generic.getNewRowField(Me.DsManage1, False, -1)

                Me.keyNr += 1
                rNew.FieldKey = rSelRows.FieldKey + " " + Me.keyNr.ToString()
                rNew.FieldNameUI = rSelRows.FieldNameUI
                rNew.DataTable = rSelRows.DataTable
                rNew.ColumnName = rSelRows.ColumnName
                rNew.Category = rSelRows.Category
                rNew.IsTable = rSelRows.IsTable
                rNew.Sort = rSelRows.Sort
            Next
            Me.gridFields.Refresh()

        Catch ex As Exception
            Throw New Exception("frmManageFields.PasteRows: " + ex.ToString())
        End Try
    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.saveData()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Me.addRow()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.delRow()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Me.loadData()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub


    Private Sub gridFields_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles gridFields.BeforeCellActivate
        Try
            e.Cell.Activation = Activation.AllowEdit

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridFields_Click(sender As Object, e As EventArgs) Handles gridFields.Click
        Try


        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridFields_DoubleClick(sender As Object, e As EventArgs) Handles gridFields.DoubleClick
        Try


        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Me.CopyRows()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            Me.PasteRows()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class