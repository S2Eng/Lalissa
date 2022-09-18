

Public Class contLayout


    Public _OnlyEditLayoutNamexy As Boolean = False
    Public mainWindow As contLayoutManager = Nothing









    Private Sub contLayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(OnlyEditLayoutNamexy As Boolean, ExtendedView As Boolean)
        Try
            'Me._OnlyEditLayoutName = OnlyEditLayoutName

            qs2.core.generic.getAutoFitStyleGrid(Nothing, Me.cboAutoFitStyleGrid)

            Me.grpLayoutDetail.Text = qs2.core.language.sqlLanguage.getRes("Layout")

            Me.lblLayoutName.Text = qs2.core.language.sqlLanguage.getRes("Name")
            Me.chkAllUsers.Text = qs2.core.language.sqlLanguage.getRes("AllUsers")
            Me.lblCreateFrom.Text = qs2.core.language.sqlLanguage.getRes("CreatedUser")
            Me.lblCreateAt.Text = qs2.core.language.sqlLanguage.getRes("Created")
            Me.lblKey.Text = qs2.core.language.sqlLanguage.getRes("Key")

            Me.lblGridRowMinHeigth.Text = qs2.core.language.sqlLanguage.getRes("GridRowMinHeigth")
            Me.lblGridRowMaxHeigth.Text = qs2.core.language.sqlLanguage.getRes("GridRowMaxHeigth")

            Me.chkGridAutoNewline.Text = qs2.core.language.sqlLanguage.getRes("GridAutoNewline")
            Me.chkShowAlwaysGroupBy.Text = qs2.core.language.sqlLanguage.getRes("ShowAlwaysGroupBy")
            Me.chkCaptionVisible.Text = qs2.core.language.sqlLanguage.getRes("CaptionVisible")
            Me.chkAutoSizeWidthColumns.Text = qs2.core.language.sqlLanguage.getRes("AutoSizeWidthColumns")
            Me.lblAutoFitStyleGrid.Text = qs2.core.language.sqlLanguage.getRes("AutoFitStyleGrid")

            'Me.txtKey.ReadOnly = Me._OnlyEditLayoutNamexy
            'Me.chkAllUsers.Enabled = Me._OnlyEditLayoutName

            If ExtendedView Then
                Me.lblKey.Visible = True
                Me.txtKey.Visible = True
            Else
                Me.lblKey.Visible = False
                Me.txtKey.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("contLayout.initControl: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub ClearUI()
        Try
            Me.ClearErrorProvider()

            Me.mainWindow.cLayoutManager1.rLayout = Nothing
            Me.txtLayoutName.Text = ""
            Me.chkAllUsers.Checked = False
            Me.txtKey.Text = ""
            Me.txtCreateFrom.Text = ""
            Me.udteCreateAt.Value = Nothing

            Me.uceGridRowMinHeigth.Value = -1
            Me.uceGridRowMaxHeigth.Value = -1

            Me.chkGridAutoNewline.Checked = False
            Me.chkShowAlwaysGroupBy.Checked = False
            Me.chkCaptionVisible.Checked = False
            Me.chkAutoSizeWidthColumns.Checked = False
            Me.cboAutoFitStyleGrid.Value = Nothing

        Catch ex As Exception
            Throw New Exception("contLayout.ClearUI: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function SetRowToUI() As Boolean
        Try
            'Me.mainWindow.CompLayout1.getLayout(Me.mainWindow.DsLayout1, "", compLayout.eSelLayoutGrid.IDLayout, IDLayout, "")
            If Me.mainWindow.DsLayout1.Layout.Rows.Count = 1 Then
                Me.txtLayoutName.Text = Me.mainWindow.cLayoutManager1.rLayout.LayoutName
                Me.chkAllUsers.Checked = Me.mainWindow.cLayoutManager1.rLayout.AllUsers
                Me.txtKey.Text = Me.mainWindow.cLayoutManager1.rLayout.Key
                Me.txtCreateFrom.Text = Me.mainWindow.cLayoutManager1.rLayout.CreateFrom
                Me.udteCreateAt.DateTime = Me.mainWindow.cLayoutManager1.rLayout.CreateAt

                Me.uceGridRowMinHeigth.Value = Me.mainWindow.cLayoutManager1.rLayout.GridRowMinHeigth
                Me.uceGridRowMaxHeigth.Value = Me.mainWindow.cLayoutManager1.rLayout.GridRowMaxHeigth

                Me.chkGridAutoNewline.Checked = Me.mainWindow.cLayoutManager1.rLayout.GridAutoNewline
                Me.chkShowAlwaysGroupBy.Checked = Me.mainWindow.cLayoutManager1.rLayout.ShowAlwaysGroupBy
                Me.chkCaptionVisible.Checked = Me.mainWindow.cLayoutManager1.rLayout.CaptionVisible
                Me.chkAutoSizeWidthColumns.Checked = Me.mainWindow.cLayoutManager1.rLayout.AutoSizeWidthColumns
                Me.cboAutoFitStyleGrid.Value = Me.mainWindow.cLayoutManager1.rLayout.AutoFitStyleGrid

            Else
                Throw New Exception("loadData: Me.DsLayout1.Layout.Rows.Count = 0 for IDLayout '" + Me.mainWindow.cLayoutManager1.rLayout.IDGuid.ToString() + "'!")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contLayout.loadData: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function ClearErrorProvider() As Boolean
        Me.ErrorProvider1.SetError(Me.txtLayoutName, "")
        Me.ErrorProvider1.SetError(Me.txtKey, "")
    End Function
    Public Function validateData() As Boolean
        Try
            Me.ClearErrorProvider()

            If Me.txtLayoutName.Text.Trim() = "" Then
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("InputRequired") + "!"
                Me.ErrorProvider1.SetError(Me.txtLayoutName, txt)
                Me.txtLayoutName.Focus()
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False

            ElseIf Me.txtKey.Text.Trim() = "" Then
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("InputRequired") + "!"
                Me.ErrorProvider1.SetError(Me.txtKey, txt)
                Me.txtKey.Focus()
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            Dim dsLayoutCheck As New dsLayout()
            Dim compLayoutCheck As New compLayout()
            compLayoutCheck.initControl()
            compLayoutCheck.getLayout(dsLayoutCheck, Me.txtLayoutName.Text.Trim(), compLayout.eSelLayoutGrid.LayoutNameNotIDGuid, Me.mainWindow.cLayoutManager1.rLayout.IDGuid, "")
            If dsLayoutCheck.Layout.Rows.Count > 0 Then
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("LayoutnameAlreadyExists") + "!"
                Me.ErrorProvider1.SetError(Me.txtLayoutName, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            compLayoutCheck.getLayout(dsLayoutCheck, "", compLayout.eSelLayoutGrid.KeyNotIDGuid, Me.mainWindow.cLayoutManager1.rLayout.IDGuid, Me.txtKey.Text.Trim())
            If dsLayoutCheck.Layout.Rows.Count > 0 Then
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("KeyAlreadyExists") + "!"
                Me.ErrorProvider1.SetError(Me.txtKey, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contLayout.validateData: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function GetUIToRow() As Boolean
        Try
            Me.mainWindow.cLayoutManager1.rLayout.LayoutName = Me.txtLayoutName.Text
            Me.mainWindow.cLayoutManager1.rLayout.AllUsers = Me.chkAllUsers.Checked
            Me.mainWindow.cLayoutManager1.rLayout.Key = Me.txtKey.Text.Trim()
            Me.mainWindow.cLayoutManager1.rLayout.CreateFrom = qs2.core.vb.actUsr.rUsr.UserName
            Me.mainWindow.cLayoutManager1.rLayout.CreateAt = Now

            Me.mainWindow.cLayoutManager1.rLayout.GridRowMinHeigth = Me.uceGridRowMinHeigth.Value
            Me.mainWindow.cLayoutManager1.rLayout.GridRowMaxHeigth = Me.uceGridRowMaxHeigth.Value

            'Me.mainWindow.CompLayout1.daLayout.Update(Me.mainWindow.DsLayout1.Layout)

            Me.mainWindow.cLayoutManager1.rLayout.GridAutoNewline = Me.chkGridAutoNewline.Checked
            Me.mainWindow.cLayoutManager1.rLayout.ShowAlwaysGroupBy = Me.chkShowAlwaysGroupBy.Checked
            Me.mainWindow.cLayoutManager1.rLayout.CaptionVisible = Me.chkCaptionVisible.Checked
            Me.mainWindow.cLayoutManager1.rLayout.AutoSizeWidthColumns = Me.chkAutoSizeWidthColumns.Checked
            If Me.cboAutoFitStyleGrid.Value Is Nothing Then
                Me.mainWindow.cLayoutManager1.rLayout.AutoFitStyleGrid = qs2.core.ui.eAutoFitStyle.None.ToString()
            Else
                Me.mainWindow.cLayoutManager1.rLayout.AutoFitStyleGrid = Me.cboAutoFitStyleGrid.Value
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contLayout.saveData: " + ex.ToString())
        Finally
        End Try
    End Function

End Class
