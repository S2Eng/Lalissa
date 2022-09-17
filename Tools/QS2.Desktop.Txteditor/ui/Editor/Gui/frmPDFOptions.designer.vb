<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDFOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private label1 As System.Windows.Forms.Label
    Private txtMasterPassword As System.Windows.Forms.TextBox
    Private WithEvents chkAllowContentAccessibility As System.Windows.Forms.CheckBox
    Private WithEvents chkAllowExtractContents As System.Windows.Forms.CheckBox
    Private txtUserPassword As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private WithEvents chkUserPassword As System.Windows.Forms.CheckBox
    Private WithEvents chkMasterPassword As System.Windows.Forms.CheckBox
    Private label3 As System.Windows.Forms.Label
    Private cboPrinting As System.Windows.Forms.ComboBox
    Private label4 As System.Windows.Forms.Label
    Private cboChangesAllowed As System.Windows.Forms.ComboBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboChangesAllowed = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.cboPrinting = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.chkMasterPassword = New System.Windows.Forms.CheckBox()
        Me.chkAllowExtractContents = New System.Windows.Forms.CheckBox()
        Me.chkAllowContentAccessibility = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtMasterPassword = New System.Windows.Forms.TextBox()
        Me.txtUserPassword = New System.Windows.Forms.TextBox()
        Me.chkUserPassword = New System.Windows.Forms.CheckBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(420, 46)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(420, 16)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.cboChangesAllowed)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.cboPrinting)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.chkMasterPassword)
        Me.groupBox2.Controls.Add(Me.chkAllowExtractContents)
        Me.groupBox2.Controls.Add(Me.chkAllowContentAccessibility)
        Me.groupBox2.Controls.Add(Me.label1)
        Me.groupBox2.Controls.Add(Me.txtMasterPassword)
        Me.groupBox2.Location = New System.Drawing.Point(12, 84)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(488, 192)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Permissions"
        '
        'cboChangesAllowed
        '
        Me.cboChangesAllowed.Location = New System.Drawing.Point(184, 106)
        Me.cboChangesAllowed.Name = "cboChangesAllowed"
        Me.cboChangesAllowed.Size = New System.Drawing.Size(280, 21)
        Me.cboChangesAllowed.TabIndex = 9
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(32, 107)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(136, 16)
        Me.label4.TabIndex = 8
        Me.label4.Text = "Changes &Allowed:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPrinting
        '
        Me.cboPrinting.Location = New System.Drawing.Point(184, 80)
        Me.cboPrinting.Name = "cboPrinting"
        Me.cboPrinting.Size = New System.Drawing.Size(280, 21)
        Me.cboPrinting.TabIndex = 8
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(32, 85)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(136, 16)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Pri&nting Allowed:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkMasterPassword
        '
        Me.chkMasterPassword.Location = New System.Drawing.Point(16, 24)
        Me.chkMasterPassword.Name = "chkMasterPassword"
        Me.chkMasterPassword.Size = New System.Drawing.Size(420, 20)
        Me.chkMasterPassword.TabIndex = 3
        Me.chkMasterPassword.Text = "&Use a password to restrict printing and editing of the document and its security" & _
    " settings"
        '
        'chkAllowExtractContents
        '
        Me.chkAllowExtractContents.Location = New System.Drawing.Point(35, 144)
        Me.chkAllowExtractContents.Name = "chkAllowExtractContents"
        Me.chkAllowExtractContents.Size = New System.Drawing.Size(420, 20)
        Me.chkAllowExtractContents.TabIndex = 10
        Me.chkAllowExtractContents.Text = "&Enable copying of text, images, and other content"
        '
        'chkAllowContentAccessibility
        '
        Me.chkAllowContentAccessibility.Location = New System.Drawing.Point(35, 168)
        Me.chkAllowContentAccessibility.Name = "chkAllowContentAccessibility"
        Me.chkAllowContentAccessibility.Size = New System.Drawing.Size(420, 20)
        Me.chkAllowContentAccessibility.TabIndex = 11
        Me.chkAllowContentAccessibility.Text = "Enable text access for screen reader devices for the &visually impaired"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(32, 60)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(140, 16)
        Me.label1.TabIndex = 4
        Me.label1.Text = "&Permissions Password:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMasterPassword
        '
        Me.txtMasterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMasterPassword.Location = New System.Drawing.Point(184, 56)
        Me.txtMasterPassword.Name = "txtMasterPassword"
        Me.txtMasterPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMasterPassword.Size = New System.Drawing.Size(128, 20)
        Me.txtMasterPassword.TabIndex = 5
        '
        'txtUserPassword
        '
        Me.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserPassword.Location = New System.Drawing.Point(196, 44)
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUserPassword.Size = New System.Drawing.Size(128, 20)
        Me.txtUserPassword.TabIndex = 2
        '
        'chkUserPassword
        '
        Me.chkUserPassword.Location = New System.Drawing.Point(12, 16)
        Me.chkUserPassword.Name = "chkUserPassword"
        Me.chkUserPassword.Size = New System.Drawing.Size(300, 20)
        Me.chkUserPassword.TabIndex = 0
        Me.chkUserPassword.Text = "&Require a password to open the document"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(46, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(144, 16)
        Me.label2.TabIndex = 1
        Me.label2.Text = "&Document Open Password:"
        '
        'frmPDFOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(509, 287)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.chkUserPassword)
        Me.Controls.Add(Me.txtUserPassword)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPDFOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PDF Export Password Security Settings"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
