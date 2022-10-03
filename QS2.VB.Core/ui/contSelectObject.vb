Imports qs2.core.vb
Imports qs2.Resources



Public Class contSelectObject

    Public IsInitialized As Boolean = False
    Public abort As Boolean = True

    Public mainWindow As frmSelectObject = Nothing
    Public funct1 As New qs2.core.vb.funct()

    Public rObjectSelected As dsObjects.tblObjectRow = Nothing
    Public _Editable As Boolean = False




    Private Sub contSelectObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl()
        Try
            If Not Me.IsInitialized Then
                Me.SqlObjects1.initControl()

                Me.btnOK.Text = qs2.core.language.sqlLanguage.getRes("OK")
                Me.btnAbort.Text = qs2.core.language.sqlLanguage.getRes("Abort")
                Me.btnAbort2.Text = qs2.core.language.sqlLanguage.getRes("Abort")
                Me.grpNewObject.Text = qs2.core.language.sqlLanguage.getRes("CreatingANewObject")
                Me.btnNewObject.Text = qs2.core.language.sqlLanguage.getRes("CreateAndTakeNewPatient")
                Me.TxtGrid(0)

                Me.mainWindow.AcceptButton = Me.btnOK
                Me.mainWindow.CancelButton = Me.btnAbort

                Me.btnOK.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)
                Me.btnNewObject.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

                For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.gridObjects.DisplayLayout.Bands(0).Columns
                    col.Hidden = True
                Next
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Hidden = False
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Hidden = False
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Hidden = False
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.TitleColumn.ColumnName).Hidden = False
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.CreatedColumn.ColumnName).Hidden = False

                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Lastname")
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Firstname")
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("DateOfBirth")
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.TitleColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Title")
                Me.gridObjects.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.CreatedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Created")

                Me.lblLastNameU.Text = qs2.core.language.sqlLanguage.getRes("LastName")
                Me.lblFirstNameU.Text = qs2.core.language.sqlLanguage.getRes("FirstName")
                Me.lblSSN.Text = qs2.core.language.sqlLanguage.getRes("SSN")
                Me.lblGender.Text = qs2.core.language.sqlLanguage.getRes("Gender")
                Me.lblCountry.Text = qs2.core.language.sqlLanguage.getRes("Country")
                Me.lblZIP.Text = qs2.core.language.sqlLanguage.getRes("ZIP")
                Me.lblCity.Text = qs2.core.language.sqlLanguage.getRes("City")
                Me.lblStreet.Text = qs2.core.language.sqlLanguage.getRes("Street")
                Me.lblRace.Text = qs2.core.language.sqlLanguage.getRes("Race")
                Me.lblPhonePrivate.Text = qs2.core.language.sqlLanguage.getRes("PhonePrivate")

                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboGender, "Gender", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, Me.DsAdmin1, sqlAdmin.eTypAuswahlList.group)
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboCountry, "CountryID", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, DsAdmin1, sqlAdmin.eTypAuswahlList.group)
                qs2.core.vb.sqlAdmin.getSelList(Nothing, Me.cboRace, "Race", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, DsAdmin1, sqlAdmin.eTypAuswahlList.group)

                Me.editUI(False)

                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contSelectObject.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearData()
        Try
            Me.txtLastNameU.Text = ""
            Me.txtFirstNameU.Text = ""
            Me.txtSSN.Text = ""
            Me.udteDOB.Value = Nothing
            Me.cboGender.Value = Nothing

            Me.cboCountry.Value = -1
            Me.txtZIP.Text = ""
            Me.txtCity.Text = ""
            Me.txtStreet.Text = ""
            Me.cboRace.Value = Nothing
            Me.txtPhonePrivat.Text = ""

        Catch ex As Exception
            Throw New Exception("contSelectObject.clearData: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUI(ByRef bNewPatient As Boolean)
        Try
            Me.grpNewObject.Visible = bNewPatient
            Me.btnOK.Visible = Not bNewPatient
            Me.btnAbort.Visible = Not bNewPatient
            Me.gridObjects.Visible = Not bNewPatient

        Catch ex As Exception
            Throw New Exception("contSelectObject.setUI: " + ex.ToString())
        End Try
    End Sub

    Public Sub editUI(ByRef bEdit As Boolean)
        Try
            Me._Editable = bEdit

            Me.txtLastNameU.Enabled = bEdit
            Me.txtFirstNameU.Enabled = bEdit
            Me.txtSSN.Enabled = bEdit
            Me.udteDOB.Enabled = bEdit
            Me.cboGender.Enabled = bEdit

            Me.cboCountry.Enabled = bEdit
            Me.txtZIP.Enabled = bEdit
            Me.txtCity.Enabled = bEdit
            Me.txtStreet.Enabled = bEdit
            Me.cboRace.Enabled = bEdit

            Me.txtPhonePrivat.Enabled = bEdit

        Catch ex As Exception
            Throw New Exception("contSelectObject.editUI: " + ex.ToString())
        End Try
    End Sub

    Public Sub TxtGrid(iCountPatientsFound As Integer)
        Try
            If iCountPatientsFound > 0 Then
                Me.gridObjects.Text = qs2.core.language.sqlLanguage.getRes("PatientsFounfInDatabase") + " (" + iCountPatientsFound.ToString() + ")"
            Else
                Me.gridObjects.Text = qs2.core.language.sqlLanguage.getRes("PatientsFounfInDatabase")
            End If

        Catch ex As Exception
            Throw New Exception("contSelectObject.TxtGrid: " + ex.ToString())
        End Try
    End Sub

    Public Function SelectRow() As Boolean
        Try
            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelObj As dsObjects.tblObjectRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelObj Is Nothing Then
                Me.rObjectSelected = rSelObj
                Return True
            End If


        Catch ex As Exception
            Throw New Exception("contSelectObject.SelectRow: " + ex.ToString())
        End Try
    End Function

    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.txtFirstNameU, "")
            Me.ErrorProvider1.SetError(Me.txtLastNameU, "")
            Me.ErrorProvider1.SetError(Me.cboGender, "")
            Me.ErrorProvider1.SetError(Me.txtSSN, "")
            Me.ErrorProvider1.SetError(Me.udteDOB, "")

            Me.ErrorProvider1.SetError(Me.cboCountry, "")
            Me.ErrorProvider1.SetError(Me.txtZIP, "")
            Me.ErrorProvider1.SetError(Me.txtCity, "")
            Me.ErrorProvider1.SetError(Me.txtStreet, "")
            Me.ErrorProvider1.SetError(Me.txtPhonePrivat, "")

        Catch ex As Exception
            Throw New Exception("contSelectObject.clearErrorProvider: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function validateData() As Boolean
        Try
            Me.clearErrorProvider()

            If Me.txtFirstNameU.Text = "" Then
                Me.txtFirstNameU.Enabled = True
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoFirstName") + "!"
                Me.ErrorProvider1.SetError(Me.txtFirstNameU, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Me.txtFirstNameU.Focus()
                Return False
            ElseIf Me.txtLastNameU.Text = "" Then
                Me.txtLastNameU.Enabled = True
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoLastName") + "!"
                Me.ErrorProvider1.SetError(Me.txtLastNameU, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Me.txtLastNameU.Focus()
                Return False
            ElseIf Me.cboGender.Value Is Nothing Then
                Me.cboGender.Enabled = True
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoGender") + "!"
                Me.ErrorProvider1.SetError(Me.cboGender, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Me.cboGender.Focus()
                Return False
            ElseIf Me.udteDOB.Value Is Nothing Then
                Me.udteDOB.Enabled = True
                Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoDOB") + "!"
                Me.ErrorProvider1.SetError(Me.udteDOB, txt)
                qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                Me.udteDOB.Focus()
                Return False
            End If

            If Not Me.funct1.checkComboBox(Me.cboGender, False) Then
                Me.cboGender.Enabled = True
                Me.ErrorProvider1.SetError(Me.cboGender, qs2.core.generic.incorrSel)
                Return False
            ElseIf Not Me.funct1.checkComboBox(Me.cboCountry, True) Then
                Me.cboCountry.Enabled = True
                Me.ErrorProvider1.SetError(Me.cboCountry, qs2.core.generic.incorrSel)
                Return False

            ElseIf Not Me.funct1.checkComboBox(Me.cboRace, False) Then
                Me.cboRace.Enabled = True
                Me.ErrorProvider1.SetError(Me.cboRace, qs2.core.generic.incorrSel)
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectObject.validateData: " + ex.ToString())
        End Try
    End Function
    Public Function NewObject() As Boolean
        Try
            If Not Me.validateData() Then
                Return False
            End If

            Dim rObjNew As dsObjects.tblObjectRow = Nothing
            Me.SqlObjects1.getObject(qs2.core.generic.idMinus, Me.DsObjects1, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
            rObjNew = Me.SqlObjects1.getNewRowObject(Me.DsObjects1)

            rObjNew.FirstName = Me.txtFirstNameU.Text.Trim()
            rObjNew.LastName = Me.txtLastNameU.Text.Trim()

            rObjNew.IsPatient = True
            rObjNew.ExtID = System.Guid.NewGuid().ToString()

            If Me.udteDOB.Value Is Nothing Then
                rObjNew.SetDOBNull()
            Else
                rObjNew.DOB = Me.udteDOB.Value
            End If
            If Me.cboGender.Value Is Nothing Then
                rObjNew.SetGenderNull()
            Else
                rObjNew.Gender = Me.cboGender.Value
            End If
            rObjNew.Active = True

            rObjNew.SSN = Me.txtSSN.Text
            rObjNew.IsJehova = -1
            rObjNew.ExtID = System.Guid.NewGuid().ToString()

            If Me.cboRace.Value Is Nothing Then
                rObjNew.SetRaceNull()
            Else
                rObjNew.Race = Me.cboRace.Value
            End If

            rObjNew.NameCombination = sqlObjects.getNameCombination(rObjNew)

            rObjNew.Created = Now
            rObjNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant

            Dim arrObj(0) As dsObjects.tblObjectRow
            arrObj(0) = rObjNew
            Me.SqlObjects1.daObject.Update(arrObj)
            rObjNew.AcceptChanges()

            Dim sqlObjReadTemp As New sqlObjects()
            sqlObjReadTemp.initControl()
            Dim rObjTemp As dsObjects.tblObjectRow = sqlObjReadTemp.getObjectRow(-99, sqlObjects.eTypSelObj.IDGuid, _
                                                                                 sqlObjects.eTypObj.none, "", "", rObjNew.IDGuid)

            Me.rObjectSelected = rObjNew
            Return True

        Catch ex As Exception
            Throw New Exception("contSelectObject.NewObject: " + ex.ToString())
        End Try
    End Function

    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsObjects.tblObjectRow
        Try
            If Not Me.gridObjects.ActiveRow Is Nothing Then
                If Me.gridObjects.ActiveRow.IsGroupByRow Or Me.gridObjects.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    Dim v As DataRowView = Me.gridObjects.ActiveRow.ListObject
                    Dim rSelObj As dsObjects.tblObjectRow = v.Row
                    selRowGrid = Me.gridObjects.ActiveRow
                    Return rSelObj
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelectObject.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.SelectRow() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort2_Click(sender As Object, e As EventArgs) Handles btnAbort2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnNewObject_Click(sender As Object, e As EventArgs) Handles btnNewObject.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.NewObject() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridObjects.BeforeCellActivate
        Try
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridObjects_DoubleClick(sender As Object, e As EventArgs) Handles gridObjects.DoubleClick
        Try
            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelObj As dsObjects.tblObjectRow = Me.getSelectedRow(False, selRowGrid)
            If Not rSelObj Is Nothing Then
                Me.rObjectSelected = rSelObj
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
