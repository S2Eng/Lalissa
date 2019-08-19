<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextTemplates
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
        Me.ContTextTemplates1 = New contTextTemplates()
        Me.SuspendLayout()
        '
        'ContTextTemplates1
        '
        Me.ContTextTemplates1.BackColor = System.Drawing.Color.White
        Me.ContTextTemplates1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContTextTemplates1.Location = New System.Drawing.Point(0, 0)
        Me.ContTextTemplates1.MinimumSize = New System.Drawing.Size(572, 250)
        Me.ContTextTemplates1.Name = "ContTextTemplates1"
        Me.ContTextTemplates1.Size = New System.Drawing.Size(1111, 717)
        Me.ContTextTemplates1.TabIndex = 0
        '
        'frmTextTemplates2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 717)
        Me.Controls.Add(Me.ContTextTemplates1)
        Me.Name = "frmTextTemplates2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "ResID.TextTemplates"
        Me.Text = "Textvorlagen"
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents ContTextTemplates1 As contTextTemplates
End Class
