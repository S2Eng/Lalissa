<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditDocu
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
        Me.components = New System.ComponentModel.Container()
        Me.ContEditDocument1 = New PMDS.GUI.VB.contEditDocument()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.SuspendLayout()
        '
        'ContEditDocument1
        '
        Me.ContEditDocument1.BackColor = System.Drawing.Color.Transparent
        Me.ContEditDocument1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContEditDocument1.Location = New System.Drawing.Point(0, 0)
        Me.ContEditDocument1.Name = "ContEditDocument1"
        Me.ContEditDocument1.Size = New System.Drawing.Size(572, 89)
        Me.ContEditDocument1.TabIndex = 0
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmEditDocu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(572, 89)
        Me.Controls.Add(Me.ContEditDocument1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditDocu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dokument editieren"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContEditDocument1 As contEditDocument
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
