<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHTMLOptions
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
    Friend GroupBox1 As System.Windows.Forms.GroupBox
    Friend txtStylesheetFile As System.Windows.Forms.TextBox
    Friend lblStylesheetFile As System.Windows.Forms.Label
    Friend WithEvents optSaveButDoNotOverwriteExistingFile As System.Windows.Forms.RadioButton
    Friend WithEvents optSaveStylesheetInSeperateFile As System.Windows.Forms.RadioButton
    Friend WithEvents optInlineStylesheet As System.Windows.Forms.RadioButton
    Friend WithEvents optNoStylesheet As System.Windows.Forms.RadioButton
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStylesheetFile = New System.Windows.Forms.TextBox()
        Me.lblStylesheetFile = New System.Windows.Forms.Label()
        Me.optSaveButDoNotOverwriteExistingFile = New System.Windows.Forms.RadioButton()
        Me.optSaveStylesheetInSeperateFile = New System.Windows.Forms.RadioButton()
        Me.optInlineStylesheet = New System.Windows.Forms.RadioButton()
        Me.optNoStylesheet = New System.Windows.Forms.RadioButton()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStylesheetFile)
        Me.GroupBox1.Controls.Add(Me.lblStylesheetFile)
        Me.GroupBox1.Controls.Add(Me.optSaveButDoNotOverwriteExistingFile)
        Me.GroupBox1.Controls.Add(Me.optSaveStylesheetInSeperateFile)
        Me.GroupBox1.Controls.Add(Me.optInlineStylesheet)
        Me.GroupBox1.Controls.Add(Me.optNoStylesheet)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 176)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HTML Stylesheet Saveoptions"
        '
        'txtStylesheetFile
        '
        Me.txtStylesheetFile.Location = New System.Drawing.Point(8, 144)
        Me.txtStylesheetFile.Name = "txtStylesheetFile"
        Me.txtStylesheetFile.Size = New System.Drawing.Size(224, 20)
        Me.txtStylesheetFile.TabIndex = 5
        '
        'lblStylesheetFile
        '
        Me.lblStylesheetFile.Location = New System.Drawing.Point(8, 128)
        Me.lblStylesheetFile.Name = "lblStylesheetFile"
        Me.lblStylesheetFile.Size = New System.Drawing.Size(224, 16)
        Me.lblStylesheetFile.TabIndex = 4
        Me.lblStylesheetFile.Text = "Stylesheet File:"
        '
        'optSaveButDoNotOverwriteExistingFile
        '
        Me.optSaveButDoNotOverwriteExistingFile.Location = New System.Drawing.Point(8, 96)
        Me.optSaveButDoNotOverwriteExistingFile.Name = "optSaveButDoNotOverwriteExistingFile"
        Me.optSaveButDoNotOverwriteExistingFile.Size = New System.Drawing.Size(284, 18)
        Me.optSaveButDoNotOverwriteExistingFile.TabIndex = 3
        Me.optSaveButDoNotOverwriteExistingFile.Text = "Save but dont overwrite existing File"
        '
        'optSaveStylesheetInSeperateFile
        '
        Me.optSaveStylesheetInSeperateFile.Location = New System.Drawing.Point(8, 72)
        Me.optSaveStylesheetInSeperateFile.Name = "optSaveStylesheetInSeperateFile"
        Me.optSaveStylesheetInSeperateFile.Size = New System.Drawing.Size(208, 18)
        Me.optSaveStylesheetInSeperateFile.TabIndex = 2
        Me.optSaveStylesheetInSeperateFile.Text = "&Save Stylesheet in own File"
        '
        'optInlineStylesheet
        '
        Me.optInlineStylesheet.Location = New System.Drawing.Point(8, 48)
        Me.optInlineStylesheet.Name = "optInlineStylesheet"
        Me.optInlineStylesheet.Size = New System.Drawing.Size(208, 18)
        Me.optInlineStylesheet.TabIndex = 1
        Me.optInlineStylesheet.Text = "&Inline stylesheet"
        '
        'optNoStylesheet
        '
        Me.optNoStylesheet.Location = New System.Drawing.Point(8, 24)
        Me.optNoStylesheet.Name = "optNoStylesheet"
        Me.optNoStylesheet.Size = New System.Drawing.Size(208, 18)
        Me.optNoStylesheet.TabIndex = 0
        Me.optNoStylesheet.Text = "&No Stylesheet"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(324, 44)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(324, 12)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 9
        Me.cmdOK.Text = "&OK"
        '
        'frmHTMLOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(416, 193)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHTMLOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HTML Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
