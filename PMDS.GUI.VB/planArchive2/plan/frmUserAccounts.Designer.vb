<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserAccounts
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
        Me.ContUserAccouts1 = New PMDS.GUI.VB.contUserAccouts()
        Me.SuspendLayout()
        '
        'ContUserAccouts1
        '
        Me.ContUserAccouts1.BackColor = System.Drawing.Color.Transparent
        Me.ContUserAccouts1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContUserAccouts1.Location = New System.Drawing.Point(0, 0)
        Me.ContUserAccouts1.MinimumSize = New System.Drawing.Size(572, 250)
        Me.ContUserAccouts1.Name = "ContUserAccouts1"
        Me.ContUserAccouts1.Size = New System.Drawing.Size(1062, 536)
        Me.ContUserAccouts1.TabIndex = 0
        '
        'frmUserAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1062, 536)
        Me.Controls.Add(Me.ContUserAccouts1)
        Me.Name = "frmUserAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "E-Mail Konten"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContUserAccouts1 As contUserAccouts
End Class
