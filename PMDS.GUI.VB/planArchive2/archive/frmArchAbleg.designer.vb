<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchAbleg
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
        Me.ContArchAbleg1 = New contArchAbleg()
        Me.SuspendLayout()
        '
        'ContArchAbleg1
        '
        Me.ContArchAbleg1.BackColor = System.Drawing.Color.White
        Me.ContArchAbleg1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContArchAbleg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContArchAbleg1.Location = New System.Drawing.Point(0, 0)
        Me.ContArchAbleg1.Name = "ContArchAbleg1"
        Me.ContArchAbleg1.Size = New System.Drawing.Size(385, 515)
        Me.ContArchAbleg1.TabIndex = 0
        '
        'frmArchAbleg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(385, 515)
        Me.Controls.Add(Me.ContArchAbleg1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArchAbleg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dokumente ablegen"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContArchAbleg1 As contArchAbleg
End Class
