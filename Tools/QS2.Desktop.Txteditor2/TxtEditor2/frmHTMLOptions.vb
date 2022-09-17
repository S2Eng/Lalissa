'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
' file:         FrmHTMLOptions.vb
'
' copyright:		© Text Control GmbH, 1991-2012
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Public Class FrmHTMLOptions
    Inherits System.Windows.Forms.Form
    Friend GroupBox1 As System.Windows.Forms.GroupBox
    Friend txtStylesheetFile As System.Windows.Forms.TextBox
    Friend lblStylesheetFile As System.Windows.Forms.Label
    Friend WithEvents optSaveButDoNotOverwriteExistingFile As System.Windows.Forms.RadioButton
    Friend WithEvents optSaveStylesheetInSeperateFile As System.Windows.Forms.RadioButton
    Friend WithEvents optInlineStylesheet As System.Windows.Forms.RadioButton
    Friend WithEvents optNoStylesheet As System.Windows.Forms.RadioButton
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend _fileHandler As FileHandler
    Private components As System.ComponentModel.Container = Nothing

    Public Sub New(ByVal fileHandler As FileHandler)
        InitializeComponent()
        _fileHandler = fileHandler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHTMLOptions))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtStylesheetFile = New System.Windows.Forms.TextBox
        Me.lblStylesheetFile = New System.Windows.Forms.Label
        Me.optSaveButDoNotOverwriteExistingFile = New System.Windows.Forms.RadioButton
        Me.optSaveStylesheetInSeperateFile = New System.Windows.Forms.RadioButton
        Me.optInlineStylesheet = New System.Windows.Forms.RadioButton
        Me.optNoStylesheet = New System.Windows.Forms.RadioButton
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
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
        Me.GroupBox1.Size = New System.Drawing.Size(252, 176)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HTML stylesheet save options"
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
        Me.lblStylesheetFile.Text = "Stylesheet file:"
        '
        'optSaveButDoNotOverwriteExistingFile
        '
        Me.optSaveButDoNotOverwriteExistingFile.Location = New System.Drawing.Point(8, 96)
        Me.optSaveButDoNotOverwriteExistingFile.Name = "optSaveButDoNotOverwriteExistingFile"
        Me.optSaveButDoNotOverwriteExistingFile.Size = New System.Drawing.Size(208, 18)
        Me.optSaveButDoNotOverwriteExistingFile.TabIndex = 3
        Me.optSaveButDoNotOverwriteExistingFile.Text = "Sa&ve but do not overwrite existing file"
        '
        'optSaveStylesheetInSeperateFile
        '
        Me.optSaveStylesheetInSeperateFile.Location = New System.Drawing.Point(8, 72)
        Me.optSaveStylesheetInSeperateFile.Name = "optSaveStylesheetInSeperateFile"
        Me.optSaveStylesheetInSeperateFile.Size = New System.Drawing.Size(208, 18)
        Me.optSaveStylesheetInSeperateFile.TabIndex = 2
        Me.optSaveStylesheetInSeperateFile.Text = "&Save stylesheet in seperate file"
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
        Me.optNoStylesheet.TabStop = True
        Me.optNoStylesheet.Text = "&No stylesheet"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(180, 190)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(94, 190)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "&OK"
        '
        'FrmHTMLOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(269, 223)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHTMLOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HTML Options"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        _fileHandler.CSSFileName = txtStylesheetFile.Text

        If optNoStylesheet.Checked Then
            _fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.None
        ElseIf optInlineStylesheet.Checked Then
            _fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.Inline
        ElseIf optSaveStylesheetInSeperateFile.Checked Then
            _fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.OverwriteFile
        Else
            _fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.CreateFile
        End If

        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub optNoStylesheet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNoStylesheet.CheckedChanged
        EnableFilename(False)
    End Sub

    Private Sub optInlineStylesheet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optInlineStylesheet.CheckedChanged
        EnableFilename(False)
    End Sub

    Private Sub optSaveStylesheetInSeperateFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSaveStylesheetInSeperateFile.CheckedChanged
        EnableFilename(True)
    End Sub

    Private Sub optSaveButDoNotOverwriteExistingFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSaveButDoNotOverwriteExistingFile.CheckedChanged
        EnableFilename(True)
    End Sub

    Private Sub EnableFilename(ByVal Enable As Boolean)
        lblStylesheetFile.Enabled = Enable
        txtStylesheetFile.Enabled = Enable
    End Sub

    Private Sub frmHTMLOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtStylesheetFile.Text = _fileHandler.CSSFileName

        Select Case _fileHandler.CSSSaveMode
            Case TXTextControl.CssSaveMode.None
                optNoStylesheet.Checked = True
                Exit Select
            Case TXTextControl.CssSaveMode.Inline
                optInlineStylesheet.Checked = True
                Exit Select
            Case TXTextControl.CssSaveMode.OverwriteFile
                optSaveStylesheetInSeperateFile.Checked = True
                Exit Select
            Case TXTextControl.CssSaveMode.CreateFile
                optSaveButDoNotOverwriteExistingFile.Checked = True
                Exit Select
        End Select
    End Sub
End Class
