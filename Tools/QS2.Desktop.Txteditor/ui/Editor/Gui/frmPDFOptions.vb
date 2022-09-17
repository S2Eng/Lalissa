Public Class frmPDFOptions
    Public FileHandler1 As FileHandler

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If chkMasterPassword.Checked AndAlso txtMasterPassword.Text.Length = 0 Then
            System.Windows.Forms.MessageBox.Show("The 'Use a password to restrict printing and editing of the " + "document and its security settings' option is selected, but the Permissions " + "Password field is empty. Please enter a password or deselect the security option.", "TX Text Control Words")
        Else
            If chkUserPassword.Checked AndAlso txtUserPassword.Text.Length = 0 Then
                System.Windows.Forms.MessageBox.Show("The 'Require a password to open the document' option is selected, " + "but the Document Open Password field is empty. Please enter a password or deselect " + "the security option.", "TX Text Control Words")
            Else
                If chkMasterPassword.Checked AndAlso chkUserPassword.Checked AndAlso txtMasterPassword.Text = txtUserPassword.Text Then
                    System.Windows.Forms.MessageBox.Show("The Document Open and Permissions passwords cannot be the same. " + "Please enter a different password in either the Document Open Password field or " + "the Permission Password field.", "TX Text Control Words")
                Else
                    FileHandler1.PDFUserPassword = txtUserPassword.Text
                    FileHandler1.PDFMasterPassword = txtMasterPassword.Text
                    Dim Flags As System.UInt32 = 0
                    If cboPrinting.SelectedIndex = 2 Then
                        Flags += CType(TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting, System.UInt32)
                    Else
                        If cboPrinting.SelectedIndex = 1 Then
                            Flags += CType(TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting, System.UInt32)
                        End If
                    End If
                    If cboChangesAllowed.SelectedIndex = 4 Then
                        Flags += CType(TXTextControl.DocumentAccessPermissions.AllowAuthoring, System.UInt32) + CType(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly, System.UInt32) + CType(TXTextControl.DocumentAccessPermissions.AllowGeneralEditing, System.UInt32)
                    Else
                        If cboChangesAllowed.SelectedIndex = 3 Then
                            Flags += CType(TXTextControl.DocumentAccessPermissions.AllowAuthoring, System.UInt32)
                        Else
                            If cboChangesAllowed.SelectedIndex = 2 Then
                                Flags += CType(TXTextControl.DocumentAccessPermissions.AllowAuthoringFields, System.UInt32)
                            Else
                                If cboChangesAllowed.SelectedIndex = 1 Then
                                    Flags += CType(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly, System.UInt32)
                                End If
                            End If
                        End If
                    End If
                    If chkAllowContentAccessibility.Checked Then
                        Flags += CType(TXTextControl.DocumentAccessPermissions.AllowContentAccessibility, System.UInt32)
                    End If
                    If chkAllowExtractContents.Checked Then
                        Flags += CType(TXTextControl.DocumentAccessPermissions.AllowExtractContents, System.UInt32)
                    End If
                    FileHandler1.PDFDocumentAccessPermissions = CType(Flags, TXTextControl.DocumentAccessPermissions)
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub frmPDFOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUserPassword.Text = FileHandler1.PDFUserPassword
        chkUserPassword.Checked = (FileHandler1.PDFUserPassword.Length > 0)
        txtUserPassword.Enabled = chkUserPassword.Checked
        txtMasterPassword.Text = FileHandler1.PDFMasterPassword
        chkMasterPassword.Checked = (FileHandler1.PDFMasterPassword.Length > 0)
        txtMasterPassword.Enabled = chkMasterPassword.Checked
        cboPrinting.Items.Clear()
        cboPrinting.Items.Add("None")
        cboPrinting.Items.Add("Low Resolution")
        cboPrinting.Items.Add("High Resolution")
        Dim Flags As System.UInt32 = CType(FileHandler1.PDFDocumentAccessPermissions, System.UInt32)
        If Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting, System.UInt32)) = 0) Then
            cboPrinting.SelectedIndex = 2
        Else
            If Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting, System.UInt32)) = 0) Then
                cboPrinting.SelectedIndex = 1
            Else
                cboPrinting.SelectedIndex = 0
            End If
        End If
        cboPrinting.Enabled = chkMasterPassword.Checked
        cboChangesAllowed.Items.Clear()
        cboChangesAllowed.Items.Add("None")
        cboChangesAllowed.Items.Add("Inserting, deleting and rotating pages")
        cboChangesAllowed.Items.Add("Filling in form fields and signing")
        cboChangesAllowed.Items.Add("Commenting, filling in form fields and signing")
        cboChangesAllowed.Items.Add("Any except extracting pages")
        If (Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowAuthoring, System.UInt32)) = 0)) AndAlso (Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly, System.UInt32)) = 0)) AndAlso (Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowGeneralEditing, System.UInt32)) = 0)) Then
            cboChangesAllowed.SelectedIndex = 4
        Else
            If Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowAuthoring, System.UInt32)) = 0) Then
                cboChangesAllowed.SelectedIndex = 3
            Else
                If Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowAuthoringFields, System.UInt32)) = 0) Then
                    cboChangesAllowed.SelectedIndex = 2
                Else
                    If Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly, System.UInt32)) = 0) Then
                        cboChangesAllowed.SelectedIndex = 1
                    Else
                        cboChangesAllowed.SelectedIndex = 0
                    End If
                End If
            End If
        End If
        cboChangesAllowed.Enabled = chkMasterPassword.Checked
        chkAllowContentAccessibility.Checked = (Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowContentAccessibility, System.UInt32)) = 0))
        chkAllowExtractContents.Checked = (Not ((Flags And CType(TXTextControl.DocumentAccessPermissions.AllowExtractContents, System.UInt32)) = 0))
        chkAllowContentAccessibility.Enabled = chkMasterPassword.Checked
        chkAllowExtractContents.Enabled = chkMasterPassword.Checked
    End Sub

    Private Sub chkUserPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUserPassword.Click
        If Not chkUserPassword.Checked Then
            txtUserPassword.Text = ""
        End If
        txtUserPassword.Enabled = chkUserPassword.Checked
    End Sub

    Private Sub chkMasterPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMasterPassword.Click
        If Not chkMasterPassword.Checked Then
            txtMasterPassword.Text = ""
        End If
        txtMasterPassword.Enabled = chkMasterPassword.Checked
        cboPrinting.Enabled = chkMasterPassword.Checked
        cboChangesAllowed.Enabled = chkMasterPassword.Checked
        chkAllowContentAccessibility.Enabled = chkMasterPassword.Checked
        chkAllowExtractContents.Enabled = chkMasterPassword.Checked
    End Sub
End Class