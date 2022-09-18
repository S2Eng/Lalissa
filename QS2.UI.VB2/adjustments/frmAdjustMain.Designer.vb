<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustMain
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
        Me.PanelToLoad = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'PanelToLoad
        '
        Me.PanelToLoad.BackColor = System.Drawing.Color.Transparent
        Me.PanelToLoad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelToLoad.Location = New System.Drawing.Point(0, 0)
        Me.PanelToLoad.Name = "PanelToLoad"
        Me.PanelToLoad.Size = New System.Drawing.Size(758, 481)
        Me.PanelToLoad.TabIndex = 0
        '
        'frmAdjustMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(758, 481)
        Me.Controls.Add(Me.PanelToLoad)
        Me.Name = "frmAdjustMain"
        Me.Text = "Adjustments"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PanelToLoad As System.Windows.Forms.Panel
End Class
