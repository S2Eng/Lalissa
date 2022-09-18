


Public Class frmSelectPatient

    Public rSelObjSelect As qs2.core.vb.dsObjects.tblObjectRow = Nothing
    Public abort As Boolean = True




    Private Sub frmSelectPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl(IDResTitle As String)
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.Text = qs2.core.language.sqlLanguage.getRes(IDResTitle.Trim())
            Me.lblPatients.Text = qs2.core.language.sqlLanguage.getRes("Patients")

            Me.btnOk.initControl()
            Me.btnCancel.initControl()

            Me.CancelButton = Me.btnCancel
            Me.AcceptButton = Me.btnOk

            Me.CboObjects1.initControls()

        Catch ex As Exception
            Throw New Exception("frmSelectPatient.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Function selectRow(ByRef rSelObj As qs2.core.vb.dsObjects.tblObjectRow) As Boolean
        Try
            rSelObj = Me.CboObjects1.getSelectedRow(True)
            If Not rSelObj Is Nothing Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("frmSelectPatient.selectRow: " + ex.ToString())
        End Try
    End Function


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.selectRow(Me.rSelObjSelect) Then
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.abort = True
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class