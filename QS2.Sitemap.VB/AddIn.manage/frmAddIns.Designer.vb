<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddIns
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.ContAddIns1 = New qs2.sitemap.vb.contAddIns()
        Me.SuspendLayout()
        '
        'ContAddIns1
        '
        Me.ContAddIns1.BackColor = System.Drawing.Color.White
        Me.ContAddIns1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContAddIns1.Location = New System.Drawing.Point(0, 0)
        Me.ContAddIns1.Name = "ContAddIns1"
        Me.ContAddIns1.Size = New System.Drawing.Size(710, 293)
        Me.ContAddIns1.TabIndex = 0
        '
        'frmAddIns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(710, 293)
        Me.Controls.Add(Me.ContAddIns1)
        Me.Name = "frmAddIns"
        Me.Text = "Adjustments"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents ContAddIns1 As qs2.sitemap.vb.contAddIns
End Class
