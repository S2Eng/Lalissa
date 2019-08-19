<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStammDat
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ContStammdaten1 = New contStammDat()
        Me.SuspendLayout()
        '
        'ContStammdaten1
        '
        Me.ContStammdaten1.BackColor = System.Drawing.Color.Transparent
        Me.ContStammdaten1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContStammdaten1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContStammdaten1.Location = New System.Drawing.Point(0, 0)
        Me.ContStammdaten1.Name = "ContStammdaten1"
        Me.ContStammdaten1.Size = New System.Drawing.Size(566, 549)
        Me.ContStammdaten1.TabIndex = 0
        '
        'frmStammDat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(566, 549)
        Me.Controls.Add(Me.ContStammdaten1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStammDat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archiv Ordner"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContStammdaten1 As contStammDat
End Class
