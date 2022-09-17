<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHyperlink
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
    Friend txHidden As TXTextControl.TextControl
    Friend GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optSelFile As System.Windows.Forms.RadioButton
    Friend WithEvents optCurPage As System.Windows.Forms.RadioButton
    Friend WithEvents lstTargets As System.Windows.Forms.ListBox
    Friend Label4 As System.Windows.Forms.Label
    Friend Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdChooseFile As System.Windows.Forms.Button
    Friend WithEvents txtLinkTarget As System.Windows.Forms.TextBox
    Friend Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLinkedText As System.Windows.Forms.TextBox
    Friend Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Me.txHidden = New TXTextControl.TextControl()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optSelFile = New System.Windows.Forms.RadioButton()
        Me.optCurPage = New System.Windows.Forms.RadioButton()
        Me.lstTargets = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdChooseFile = New System.Windows.Forms.Button()
        Me.txtLinkTarget = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLinkedText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txHidden
        '
        Me.txHidden.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txHidden.Location = New System.Drawing.Point(8, 240)
        Me.txHidden.Name = "txHidden"
        Me.txHidden.PageMargins.Bottom = 79.03R
        Me.txHidden.PageMargins.Left = 79.03R
        Me.txHidden.PageMargins.Right = 79.03R
        Me.txHidden.PageMargins.Top = 79.03R
        Me.txHidden.Size = New System.Drawing.Size(184, 32)
        Me.txHidden.TabIndex = 11
        Me.txHidden.TabStop = False
        Me.txHidden.Text = "This Text Control is hidden at run time"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optSelFile)
        Me.GroupBox1.Controls.Add(Me.optCurPage)
        Me.GroupBox1.Controls.Add(Me.lstTargets)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdChooseFile)
        Me.GroupBox1.Controls.Add(Me.txtLinkTarget)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 178)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Link to:"
        '
        'optSelFile
        '
        Me.optSelFile.Location = New System.Drawing.Point(280, 125)
        Me.optSelFile.Name = "optSelFile"
        Me.optSelFile.Size = New System.Drawing.Size(96, 20)
        Me.optSelFile.TabIndex = 4
        Me.optSelFile.Text = "S&elected file"
        '
        'optCurPage
        '
        Me.optCurPage.Checked = True
        Me.optCurPage.Location = New System.Drawing.Point(280, 99)
        Me.optCurPage.Name = "optCurPage"
        Me.optCurPage.Size = New System.Drawing.Size(96, 20)
        Me.optCurPage.TabIndex = 3
        Me.optCurPage.TabStop = True
        Me.optCurPage.Text = "C&urrent page"
        '
        'lstTargets
        '
        Me.lstTargets.Location = New System.Drawing.Point(8, 96)
        Me.lstTargets.Name = "lstTargets"
        Me.lstTargets.Size = New System.Drawing.Size(244, 56)
        Me.lstTargets.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(280, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Show targets in:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select a named target in current page (optional):"
        '
        'cmdChooseFile
        '
        Me.cmdChooseFile.Location = New System.Drawing.Point(280, 15)
        Me.cmdChooseFile.Name = "cmdChooseFile"
        Me.cmdChooseFile.Size = New System.Drawing.Size(118, 24)
        Me.cmdChooseFile.TabIndex = 0
        Me.cmdChooseFile.Text = "Select File ..."
        '
        'txtLinkTarget
        '
        Me.txtLinkTarget.Location = New System.Drawing.Point(8, 44)
        Me.txtLinkTarget.Name = "txtLinkTarget"
        Me.txtLinkTarget.Size = New System.Drawing.Size(390, 20)
        Me.txtLinkTarget.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Link to Site or URL:"
        '
        'txtLinkedText
        '
        Me.txtLinkedText.Location = New System.Drawing.Point(12, 27)
        Me.txtLinkedText.Name = "txtLinkedText"
        Me.txtLinkedText.Size = New System.Drawing.Size(248, 20)
        Me.txtLinkedText.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Linktext:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(332, 239)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(246, 239)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "&OK"
        '
        'frmHyperlink
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 317)
        Me.Controls.Add(Me.txHidden)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtLinkedText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHyperlink"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hyperlinks"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
