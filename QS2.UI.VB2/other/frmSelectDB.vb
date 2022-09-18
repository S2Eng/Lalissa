Imports qs2.core.vb
Imports qs2.Resources



Public Class frmSelectDB

    Public abort As Boolean = True
    Public AutoControlsUI1 As New qs2.design.auto.workflowAssist.autoForm.AutoControlsUI()




    Private Sub frmSelectDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)
            Me.btnSelect.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.AcceptButton = Me.btnSelect
            Me.CancelButton = Me.btnAbort

        Catch ex As Exception
            Throw New Exception("frmSelectDB.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadData(ByRef lstConnStr As System.Collections.Generic.List(Of String))
        Try
            Me.cboDatabases.Items.Clear()
            For Each connStr As String In lstConnStr
                Dim OLEDBBuilder As New System.Data.Common.DbConnectionStringBuilder()
                OLEDBBuilder.ConnectionString = connStr.Trim()
                Dim db As String = OLEDBBuilder("Data Source").ToString()
                Dim Srv As String = OLEDBBuilder("Initial Catalog").ToString()
                Me.cboDatabases.Items.Add(connStr.Trim(), db.Trim() + "::" + Srv.Trim())
            Next

        Catch ex As Exception
            Throw New Exception("frmSelectDB.LoadData: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If (Me.cboDatabases.SelectedItem Is Nothing) Then
                System.Windows.Forms.MessageBox.Show("Please select a database!", "QS2")
                Exit Sub
            End If

            qs2.core.ENV.connStr = Me.cboDatabases.SelectedItem.DataValue.ToString.Trim()
            Me.abort = False
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class