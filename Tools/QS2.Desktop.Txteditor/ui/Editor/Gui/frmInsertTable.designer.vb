<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertTable
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
    Public tx As TXTextControl.TextControl
    Friend updownColumns As System.Windows.Forms.NumericUpDown
    Friend updownRows As System.Windows.Forms.NumericUpDown
    Friend Label2 As System.Windows.Forms.Label
    Friend Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.updownColumns = New System.Windows.Forms.NumericUpDown()
        Me.updownRows = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.updownColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updownRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'updownColumns
        '
        Me.updownColumns.Location = New System.Drawing.Point(64, 40)
        Me.updownColumns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updownColumns.Name = "updownColumns"
        Me.updownColumns.Size = New System.Drawing.Size(64, 20)
        Me.updownColumns.TabIndex = 13
        Me.updownColumns.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'updownRows
        '
        Me.updownRows.Location = New System.Drawing.Point(64, 16)
        Me.updownRows.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.updownRows.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updownRows.Name = "updownRows"
        Me.updownRows.Size = New System.Drawing.Size(64, 20)
        Me.updownRows.TabIndex = 12
        Me.updownRows.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Columns"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Rows"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(184, 40)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(184, 8)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "&OK"
        '
        'frmInsertTable
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(272, 71)
        Me.Controls.Add(Me.updownColumns)
        Me.Controls.Add(Me.updownRows)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInsertTable"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insert Table"
        Me.TopMost = True
        CType(Me.updownColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.updownRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
