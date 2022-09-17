Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class FrmPDFOptions
    Inherits System.Windows.Forms.Form
    Friend cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Private tabPDFSettings As TabControl
    Private tabPagePDFSecurity As TabPage
    Private labelDocumentPassword As Label
    Private WithEvents chkUserPassword As CheckBox
    Private groupBoxPDFSecurity As GroupBox
    Private cboChangesAllowed As ComboBox
    Private label5 As Label
    Private cboPrinting As ComboBox
    Private label6 As Label
    Private chkAllowExtractContents As CheckBox
    Private chkAllowContentAccessibility As CheckBox
    Private label7 As Label
    Private txtUserPassword As TextBox
    Private tabPagePDFImport As TabPage
    Private groupBoxPDFImport As GroupBox
    Private tabPagePDFExport As TabPage
    Private groupBoxPDFExport As GroupBox
    Private WithEvents chkPDFEmbeddableFontsOnly As CheckBox
    Private cboPDFImport As ComboBox
    Private WithEvents chkMasterPassword As CheckBox
    Private txtMasterPassword As TextBox
    Private groupBoxUserPassword As GroupBox
    Private groupBox1 As GroupBox
    Private lblCertPwd As Label
    Private lblCertFile As Label
    Private WithEvents tbCertFile As TextBox
    Private WithEvents btnBrowseCertFile As Button
    Private WithEvents tbCertPwd As TextBox
    Private components As System.ComponentModel.Container = Nothing

    Public Sub New(ByVal textControl__1 As TXTextControl.TextControl)
        InitializeComponent()
        TextControl = textControl__1
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmPDFOptions))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.tabPDFSettings = New System.Windows.Forms.TabControl()
        Me.tabPagePDFSecurity = New System.Windows.Forms.TabPage()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowseCertFile = New System.Windows.Forms.Button()
        Me.tbCertPwd = New System.Windows.Forms.TextBox()
        Me.lblCertPwd = New System.Windows.Forms.Label()
        Me.lblCertFile = New System.Windows.Forms.Label()
        Me.tbCertFile = New System.Windows.Forms.TextBox()
        Me.groupBoxUserPassword = New System.Windows.Forms.GroupBox()
        Me.txtUserPassword = New System.Windows.Forms.TextBox()
        Me.chkUserPassword = New System.Windows.Forms.CheckBox()
        Me.labelDocumentPassword = New System.Windows.Forms.Label()
        Me.groupBoxPDFSecurity = New System.Windows.Forms.GroupBox()
        Me.txtMasterPassword = New System.Windows.Forms.TextBox()
        Me.chkMasterPassword = New System.Windows.Forms.CheckBox()
        Me.cboChangesAllowed = New System.Windows.Forms.ComboBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.cboPrinting = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.chkAllowExtractContents = New System.Windows.Forms.CheckBox()
        Me.chkAllowContentAccessibility = New System.Windows.Forms.CheckBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tabPagePDFImport = New System.Windows.Forms.TabPage()
        Me.groupBoxPDFImport = New System.Windows.Forms.GroupBox()
        Me.cboPDFImport = New System.Windows.Forms.ComboBox()
        Me.tabPagePDFExport = New System.Windows.Forms.TabPage()
        Me.groupBoxPDFExport = New System.Windows.Forms.GroupBox()
        Me.chkPDFEmbeddableFontsOnly = New System.Windows.Forms.CheckBox()
        Me.tabPDFSettings.SuspendLayout()
        Me.tabPagePDFSecurity.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBoxUserPassword.SuspendLayout()
        Me.groupBoxPDFSecurity.SuspendLayout()
        Me.tabPagePDFImport.SuspendLayout()
        Me.groupBoxPDFImport.SuspendLayout()
        Me.tabPagePDFExport.SuspendLayout()
        Me.groupBoxPDFExport.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' cmdCancel
        ' 
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(301, 399)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        ' 
        ' cmdOK
        ' 
        Me.cmdOK.Location = New System.Drawing.Point(387, 399)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "&OK"
        ' 
        ' tabPDFSettings
        ' 
        Me.tabPDFSettings.Controls.Add(Me.tabPagePDFSecurity)
        Me.tabPDFSettings.Controls.Add(Me.tabPagePDFImport)
        Me.tabPDFSettings.Controls.Add(Me.tabPagePDFExport)
        Me.tabPDFSettings.Location = New System.Drawing.Point(12, 12)
        Me.tabPDFSettings.Name = "tabPDFSettings"
        Me.tabPDFSettings.SelectedIndex = 0
        Me.tabPDFSettings.Size = New System.Drawing.Size(455, 381)
        Me.tabPDFSettings.TabIndex = 2
        ' 
        ' tabPagePDFSecurity
        ' 
        Me.tabPagePDFSecurity.Controls.Add(Me.groupBox1)
        Me.tabPagePDFSecurity.Controls.Add(Me.groupBoxUserPassword)
        Me.tabPagePDFSecurity.Controls.Add(Me.groupBoxPDFSecurity)
        Me.tabPagePDFSecurity.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePDFSecurity.Name = "tabPagePDFSecurity"
        Me.tabPagePDFSecurity.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePDFSecurity.Size = New System.Drawing.Size(447, 355)
        Me.tabPagePDFSecurity.TabIndex = 0
        Me.tabPagePDFSecurity.Text = "Security"
        Me.tabPagePDFSecurity.UseVisualStyleBackColor = True
        ' 
        ' groupBox1
        ' 
        Me.groupBox1.Controls.Add(Me.btnBrowseCertFile)
        Me.groupBox1.Controls.Add(Me.tbCertPwd)
        Me.groupBox1.Controls.Add(Me.lblCertPwd)
        Me.groupBox1.Controls.Add(Me.lblCertFile)
        Me.groupBox1.Controls.Add(Me.tbCertFile)
        Me.groupBox1.Location = New System.Drawing.Point(6, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(435, 76)
        Me.groupBox1.TabIndex = 15
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Digital Signature"
        ' 
        ' btnBrowseCertFile
        ' 
        Me.btnBrowseCertFile.Location = New System.Drawing.Point(365, 16)
        Me.btnBrowseCertFile.Name = "btnBrowseCertFile"
        Me.btnBrowseCertFile.Size = New System.Drawing.Size(58, 24)
        Me.btnBrowseCertFile.TabIndex = 14
        Me.btnBrowseCertFile.Text = "Browse…"
        Me.btnBrowseCertFile.UseVisualStyleBackColor = True
        ' 
        ' tbCertPwd
        ' 
        Me.tbCertPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCertPwd.Location = New System.Drawing.Point(143, 45)
        Me.tbCertPwd.Name = "tbCertPwd"
        Me.tbCertPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbCertPwd.Size = New System.Drawing.Size(210, 20)
        Me.tbCertPwd.TabIndex = 13
        Me.tbCertPwd.UseSystemPasswordChar = True
        ' 
        ' lblCertPwd
        ' 
        Me.lblCertPwd.AutoSize = True
        Me.lblCertPwd.Location = New System.Drawing.Point(31, 47)
        Me.lblCertPwd.Name = "lblCertPwd"
        Me.lblCertPwd.Size = New System.Drawing.Size(106, 13)
        Me.lblCertPwd.TabIndex = 12
        Me.lblCertPwd.Text = "Certificate Password:"
        ' 
        ' lblCertFile
        ' 
        Me.lblCertFile.AutoSize = True
        Me.lblCertFile.Location = New System.Drawing.Point(31, 21)
        Me.lblCertFile.Name = "lblCertFile"
        Me.lblCertFile.Size = New System.Drawing.Size(106, 13)
        Me.lblCertFile.TabIndex = 11
        Me.lblCertFile.Text = "Certificate File (*.pfx):"
        ' 
        ' tbCertFile
        ' 
        Me.tbCertFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCertFile.Location = New System.Drawing.Point(143, 19)
        Me.tbCertFile.Name = "tbCertFile"
        Me.tbCertFile.Size = New System.Drawing.Size(210, 20)
        Me.tbCertFile.TabIndex = 11
        ' 
        ' groupBoxUserPassword
        ' 
        Me.groupBoxUserPassword.Controls.Add(Me.txtUserPassword)
        Me.groupBoxUserPassword.Controls.Add(Me.chkUserPassword)
        Me.groupBoxUserPassword.Controls.Add(Me.labelDocumentPassword)
        Me.groupBoxUserPassword.Location = New System.Drawing.Point(6, 88)
        Me.groupBoxUserPassword.Name = "groupBoxUserPassword"
        Me.groupBoxUserPassword.Size = New System.Drawing.Size(435, 75)
        Me.groupBoxUserPassword.TabIndex = 14
        Me.groupBoxUserPassword.TabStop = False
        Me.groupBoxUserPassword.Text = "PDF Document Password"
        ' 
        ' txtUserPassword
        ' 
        Me.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserPassword.Location = New System.Drawing.Point(143, 45)
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUserPassword.Size = New System.Drawing.Size(160, 20)
        Me.txtUserPassword.TabIndex = 10
        Me.txtUserPassword.UseSystemPasswordChar = True
        ' 
        ' chkUserPassword
        ' 
        Me.chkUserPassword.AutoSize = True
        Me.chkUserPassword.Location = New System.Drawing.Point(6, 19)
        Me.chkUserPassword.Name = "chkUserPassword"
        Me.chkUserPassword.Size = New System.Drawing.Size(227, 17)
        Me.chkUserPassword.TabIndex = 7
        Me.chkUserPassword.Text = "&Require a password to open the document"
        ' 
        ' labelDocumentPassword
        ' 
        Me.labelDocumentPassword.AutoSize = True
        Me.labelDocumentPassword.Location = New System.Drawing.Point(29, 47)
        Me.labelDocumentPassword.Name = "labelDocumentPassword"
        Me.labelDocumentPassword.Size = New System.Drawing.Size(108, 13)
        Me.labelDocumentPassword.TabIndex = 9
        Me.labelDocumentPassword.Text = "&Document Password:"
        ' 
        ' groupBoxPDFSecurity
        ' 
        Me.groupBoxPDFSecurity.Controls.Add(Me.txtMasterPassword)
        Me.groupBoxPDFSecurity.Controls.Add(Me.chkMasterPassword)
        Me.groupBoxPDFSecurity.Controls.Add(Me.cboChangesAllowed)
        Me.groupBoxPDFSecurity.Controls.Add(Me.label5)
        Me.groupBoxPDFSecurity.Controls.Add(Me.cboPrinting)
        Me.groupBoxPDFSecurity.Controls.Add(Me.label6)
        Me.groupBoxPDFSecurity.Controls.Add(Me.chkAllowExtractContents)
        Me.groupBoxPDFSecurity.Controls.Add(Me.chkAllowContentAccessibility)
        Me.groupBoxPDFSecurity.Controls.Add(Me.label7)
        Me.groupBoxPDFSecurity.Location = New System.Drawing.Point(6, 169)
        Me.groupBoxPDFSecurity.Name = "groupBoxPDFSecurity"
        Me.groupBoxPDFSecurity.Size = New System.Drawing.Size(435, 181)
        Me.groupBoxPDFSecurity.TabIndex = 13
        Me.groupBoxPDFSecurity.TabStop = False
        Me.groupBoxPDFSecurity.Text = "Permissions"
        ' 
        ' txtMasterPassword
        ' 
        Me.txtMasterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMasterPassword.Location = New System.Drawing.Point(143, 43)
        Me.txtMasterPassword.Name = "txtMasterPassword"
        Me.txtMasterPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMasterPassword.Size = New System.Drawing.Size(160, 20)
        Me.txtMasterPassword.TabIndex = 13
        Me.txtMasterPassword.TabStop = False
        Me.txtMasterPassword.UseSystemPasswordChar = True
        ' 
        ' chkMasterPassword
        ' 
        Me.chkMasterPassword.AutoSize = True
        Me.chkMasterPassword.Location = New System.Drawing.Point(6, 19)
        Me.chkMasterPassword.Name = "chkMasterPassword"
        Me.chkMasterPassword.Size = New System.Drawing.Size(347, 17)
        Me.chkMasterPassword.TabIndex = 12
        Me.chkMasterPassword.Text = "&Require Password for restricting printing and editing of the document"
        ' 
        ' cboChangesAllowed
        ' 
        Me.cboChangesAllowed.Location = New System.Drawing.Point(143, 100)
        Me.cboChangesAllowed.Name = "cboChangesAllowed"
        Me.cboChangesAllowed.Size = New System.Drawing.Size(280, 21)
        Me.cboChangesAllowed.TabIndex = 9
        Me.cboChangesAllowed.TabStop = False
        ' 
        ' label5
        ' 
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(45, 103)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(92, 13)
        Me.label5.TabIndex = 8
        Me.label5.Text = "Changes &Allowed:"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        ' 
        ' cboPrinting
        ' 
        Me.cboPrinting.Location = New System.Drawing.Point(143, 73)
        Me.cboPrinting.Name = "cboPrinting"
        Me.cboPrinting.Size = New System.Drawing.Size(280, 21)
        Me.cboPrinting.TabIndex = 8
        Me.cboPrinting.TabStop = False
        ' 
        ' label6
        ' 
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(52, 76)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(85, 13)
        Me.label6.TabIndex = 7
        Me.label6.Text = "Pri&nting Allowed:"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        ' 
        ' chkAllowExtractContents
        ' 
        Me.chkAllowExtractContents.AutoSize = True
        Me.chkAllowExtractContents.Location = New System.Drawing.Point(26, 127)
        Me.chkAllowExtractContents.Name = "chkAllowExtractContents"
        Me.chkAllowExtractContents.Size = New System.Drawing.Size(260, 17)
        Me.chkAllowExtractContents.TabIndex = 10
        Me.chkAllowExtractContents.TabStop = False
        Me.chkAllowExtractContents.Text = "&Enable copying of text, images, and other content"
        ' 
        ' chkAllowContentAccessibility
        ' 
        Me.chkAllowContentAccessibility.AutoSize = True
        Me.chkAllowContentAccessibility.Location = New System.Drawing.Point(26, 150)
        Me.chkAllowContentAccessibility.Name = "chkAllowContentAccessibility"
        Me.chkAllowContentAccessibility.Size = New System.Drawing.Size(351, 17)
        Me.chkAllowContentAccessibility.TabIndex = 11
        Me.chkAllowContentAccessibility.TabStop = False
        Me.chkAllowContentAccessibility.Text = "Enable text access for screen reader devices for the &visually impaired"
        ' 
        ' label7
        ' 
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(23, 45)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(114, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "&Permissions Password:"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        ' 
        ' tabPagePDFImport
        ' 
        Me.tabPagePDFImport.Controls.Add(Me.groupBoxPDFImport)
        Me.tabPagePDFImport.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePDFImport.Name = "tabPagePDFImport"
        Me.tabPagePDFImport.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePDFImport.Size = New System.Drawing.Size(447, 355)
        Me.tabPagePDFImport.TabIndex = 1
        Me.tabPagePDFImport.Text = "Import"
        Me.tabPagePDFImport.UseVisualStyleBackColor = True
        ' 
        ' groupBoxPDFImport
        ' 
        Me.groupBoxPDFImport.Controls.Add(Me.cboPDFImport)
        Me.groupBoxPDFImport.Location = New System.Drawing.Point(6, 6)
        Me.groupBoxPDFImport.Name = "groupBoxPDFImport"
        Me.groupBoxPDFImport.Size = New System.Drawing.Size(435, 343)
        Me.groupBoxPDFImport.TabIndex = 7
        Me.groupBoxPDFImport.TabStop = False
        Me.groupBoxPDFImport.Text = "PDF Import Options"
        ' 
        ' cboPDFImport
        ' 
        Me.cboPDFImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPDFImport.FormattingEnabled = True
        Me.cboPDFImport.Location = New System.Drawing.Point(6, 19)
        Me.cboPDFImport.MaxDropDownItems = 3
        Me.cboPDFImport.Name = "cboPDFImport"
        Me.cboPDFImport.Size = New System.Drawing.Size(180, 21)
        Me.cboPDFImport.TabIndex = 0
        ' 
        ' tabPagePDFExport
        ' 
        Me.tabPagePDFExport.Controls.Add(Me.groupBoxPDFExport)
        Me.tabPagePDFExport.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePDFExport.Name = "tabPagePDFExport"
        Me.tabPagePDFExport.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePDFExport.Size = New System.Drawing.Size(447, 355)
        Me.tabPagePDFExport.TabIndex = 2
        Me.tabPagePDFExport.Text = "Export"
        Me.tabPagePDFExport.UseVisualStyleBackColor = True
        ' 
        ' groupBoxPDFExport
        ' 
        Me.groupBoxPDFExport.Controls.Add(Me.chkPDFEmbeddableFontsOnly)
        Me.groupBoxPDFExport.Location = New System.Drawing.Point(6, 6)
        Me.groupBoxPDFExport.Name = "groupBoxPDFExport"
        Me.groupBoxPDFExport.Size = New System.Drawing.Size(435, 343)
        Me.groupBoxPDFExport.TabIndex = 8
        Me.groupBoxPDFExport.TabStop = False
        Me.groupBoxPDFExport.Text = "PDF Export Options"
        ' 
        ' chkPDFEmbeddableFontsOnly
        ' 
        Me.chkPDFEmbeddableFontsOnly.AutoSize = True
        Me.chkPDFEmbeddableFontsOnly.Location = New System.Drawing.Point(6, 19)
        Me.chkPDFEmbeddableFontsOnly.Name = "chkPDFEmbeddableFontsOnly"
        Me.chkPDFEmbeddableFontsOnly.Size = New System.Drawing.Size(95, 17)
        Me.chkPDFEmbeddableFontsOnly.TabIndex = 0
        Me.chkPDFEmbeddableFontsOnly.Text = "&Enable PDF/A"
        Me.chkPDFEmbeddableFontsOnly.UseVisualStyleBackColor = True
        ' 
        ' FrmPDFOptions
        ' 
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(479, 431)
        Me.Controls.Add(Me.tabPDFSettings)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPDFOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PDF Settings"
        Me.TopMost = True
        Me.tabPDFSettings.ResumeLayout(False)
        Me.tabPagePDFSecurity.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBoxUserPassword.ResumeLayout(False)
        Me.groupBoxUserPassword.PerformLayout()
        Me.groupBoxPDFSecurity.ResumeLayout(False)
        Me.groupBoxPDFSecurity.PerformLayout()
        Me.tabPagePDFImport.ResumeLayout(False)
        Me.groupBoxPDFImport.ResumeLayout(False)
        Me.tabPagePDFExport.ResumeLayout(False)
        Me.groupBoxPDFExport.ResumeLayout(False)
        Me.groupBoxPDFExport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Property FileHandler() As FileHandler
        Get
            Return m_FileHandler
        End Get
        Set(ByVal value As FileHandler)
            m_FileHandler = Value
        End Set
    End Property
    Private m_FileHandler As FileHandler

    Public Property TextControl() As TXTextControl.TextControl
        Get
            Return m_TextControl
        End Get
        Private Set(ByVal value As TXTextControl.TextControl)
            m_TextControl = Value
        End Set
    End Property
    Private m_TextControl As TXTextControl.TextControl

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If chkMasterPassword.Checked AndAlso txtMasterPassword.Text.Length = 0 Then
            MessageBox.Show("The 'Use a password to restrict printing and editing of the " & "document and its security settings' option is selected, but the Permissions " & "Password field is empty. Please enter a password or deselect the security option.", ProductName)
        ElseIf chkUserPassword.Checked AndAlso txtUserPassword.Text.Length = 0 Then
            MessageBox.Show("The 'Require a password to open the document' option is selected, " & "but the Document Open Password field is empty. Please enter a password or deselect " & "the security option.", ProductName)
        ElseIf chkMasterPassword.Checked AndAlso chkUserPassword.Checked AndAlso txtMasterPassword.Text = txtUserPassword.Text Then
            MessageBox.Show("The Document Open and Permissions passwords cannot be the same. " & "Please enter a different password in either the Document Open Password field or " & "the Permission Password field.", ProductName)
        Else
            FileHandler.PDFUserPassword = txtUserPassword.Text
            FileHandler.PDFMasterPassword = txtMasterPassword.Text

            Dim nFlags As Integer = 0

            ' Printing combo box
            If cboPrinting.SelectedIndex = 2 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting)
            ElseIf cboPrinting.SelectedIndex = 1 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting)
            End If

            ' Changes Allowed combo box
            If cboChangesAllowed.SelectedIndex = 4 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowAuthoring) + CInt(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly) + CInt(TXTextControl.DocumentAccessPermissions.AllowGeneralEditing)
            ElseIf cboChangesAllowed.SelectedIndex = 3 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowAuthoring)
            ElseIf cboChangesAllowed.SelectedIndex = 2 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowAuthoringFields)
            ElseIf cboChangesAllowed.SelectedIndex = 1 Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly)
            End If

            ' Remaining 2 checkboxes
            If chkAllowContentAccessibility.Checked Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowContentAccessibility)
            End If
            If chkAllowExtractContents.Checked Then
                nFlags += CInt(TXTextControl.DocumentAccessPermissions.AllowExtractContents)
            End If

            FileHandler.PDFDocumentAccessPermissions = DirectCast(nFlags, TXTextControl.DocumentAccessPermissions)

            ' Set PDFImportSettings
            Select Case cboPDFImport.SelectedIndex
                Case 0
                    FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateLines
                    Exit Select
                Case 1
                    FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateParagraphs
                    Exit Select
                Case 2
                    FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateTextFrames
                    Exit Select
            End Select
            ' PDF/A setting
            TextControl.FontSettings.EmbeddableFontsOnly = chkPDFEmbeddableFontsOnly.Checked

            ' Close the dialog finally
            Close()
        End If
    End Sub

    Private Sub frmPDFOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserPassword.Text = FileHandler.PDFUserPassword
        chkUserPassword.Checked = (FileHandler.PDFUserPassword.Length > 0)
        txtUserPassword.Enabled = chkUserPassword.Checked

        txtMasterPassword.Text = FileHandler.PDFMasterPassword
        chkMasterPassword.Checked = (FileHandler.PDFMasterPassword.Length > 0)
        txtMasterPassword.Enabled = chkMasterPassword.Checked

        tbCertFile.Text = FileHandler.PDFCertFilePath
        tbCertPwd.Text = FileHandler.PDFCertPasswd

        ' PDF import combo box
        cboPDFImport.Items.Clear()
        cboPDFImport.Items.Add("Plain text mode")
        cboPDFImport.Items.Add("Paragraph recognition mode")
        cboPDFImport.Items.Add("Text frame import mode")

        Select Case FileHandler.PDFImportSettings
            Case TXTextControl.PDFImportSettings.GenerateLines
                cboPDFImport.SelectedIndex = 0
                Exit Select
            Case TXTextControl.PDFImportSettings.GenerateParagraphs
                cboPDFImport.SelectedIndex = 1
                Exit Select
            Case TXTextControl.PDFImportSettings.GenerateTextFrames
                cboPDFImport.SelectedIndex = 2
                Exit Select
        End Select

        ' PDF export: EmbeddableFontsOnly = false by default
        chkPDFEmbeddableFontsOnly.Checked = TextControl.FontSettings.EmbeddableFontsOnly

        ' Printing combo box
        cboPrinting.Items.Clear()
        cboPrinting.Items.Add("None")
        cboPrinting.Items.Add("Low Resolution")
        cboPrinting.Items.Add("High Resolution")

        Dim Flags As UInteger = CUInt(FileHandler.PDFDocumentAccessPermissions)

        If (Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting)) <> 0 Then
            cboPrinting.SelectedIndex = 2
        ElseIf (Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting)) <> 0 Then
            cboPrinting.SelectedIndex = 1
        Else
            cboPrinting.SelectedIndex = 0
        End If
        cboPrinting.Enabled = chkMasterPassword.Checked

        ' Changes Allowed combo box
        cboChangesAllowed.Items.Clear()
        cboChangesAllowed.Items.Add("None")
        cboChangesAllowed.Items.Add("Inserting, deleting and rotating pages")
        cboChangesAllowed.Items.Add("Filling in form fields and signing")
        cboChangesAllowed.Items.Add("Commenting, filling in form fields and signing")
        cboChangesAllowed.Items.Add("Any except extracting pages")

        If ((Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowAuthoring)) <> 0) AndAlso ((Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly)) <> 0) AndAlso ((Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowGeneralEditing)) <> 0) Then
            cboChangesAllowed.SelectedIndex = 4
        ElseIf (Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowAuthoring)) <> 0 Then
            cboChangesAllowed.SelectedIndex = 3
        ElseIf (Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowAuthoringFields)) <> 0 Then
            cboChangesAllowed.SelectedIndex = 2
        ElseIf (Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly)) <> 0 Then
            cboChangesAllowed.SelectedIndex = 1
        Else
            cboChangesAllowed.SelectedIndex = 0
        End If
        cboChangesAllowed.Enabled = chkMasterPassword.Checked

        ' Remaining 2 checkboxes
        chkAllowContentAccessibility.Checked = ((Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowContentAccessibility)) <> 0)
        chkAllowExtractContents.Checked = ((Flags And CUInt(TXTextControl.DocumentAccessPermissions.AllowExtractContents)) <> 0)

        chkAllowContentAccessibility.Enabled = chkMasterPassword.Checked
        chkAllowExtractContents.Enabled = chkMasterPassword.Checked
    End Sub

    Private Sub btnBrowseCertFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseCertFile.Click
        Dim ofd As New OpenFileDialog()
        ofd.CheckPathExists = True
        ofd.Filter = "Personal Information Exchange File (*.pfx)|*.pfx"
        ofd.ValidateNames = True

        If ofd.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        tbCertFile.Text = ofd.FileName
    End Sub

    Private Sub tbCertFile_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbCertFile.TextChanged
        FileHandler.PDFCertFilePath = tbCertFile.Text
    End Sub

    Private Sub tbCertPwd_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbCertPwd.TextChanged
        FileHandler.PDFCertPasswd = tbCertPwd.Text
    End Sub

    Private Sub chkUserPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUserPassword.Click
        If Not chkUserPassword.Checked Then
            txtUserPassword.Text = ""
        End If
        txtUserPassword.Enabled = chkUserPassword.Checked
        chkPDFEmbeddableFontsOnly.Enabled = Not chkUserPassword.Checked
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
        chkPDFEmbeddableFontsOnly.Enabled = Not chkMasterPassword.Checked
    End Sub

    Private Sub chkPDFEmbeddableFontsOnly_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPDFEmbeddableFontsOnly.CheckedChanged
        groupBoxUserPassword.Enabled = Not chkPDFEmbeddableFontsOnly.Checked
        groupBoxPDFSecurity.Enabled = Not chkPDFEmbeddableFontsOnly.Checked
    End Sub
End Class
