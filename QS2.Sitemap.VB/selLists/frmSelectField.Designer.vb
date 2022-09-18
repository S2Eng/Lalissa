<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectField
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
        Me.ContSelectField1 = New qs2.sitemap.vb.contSelectField()
        Me.SuspendLayout()
        '
        'ContSelectField1
        '
        Me.ContSelectField1.BackColor = System.Drawing.Color.Transparent
        Me.ContSelectField1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContSelectField1.Location = New System.Drawing.Point(0, 0)
        Me.ContSelectField1.Name = "ContSelectField1"
        Me.ContSelectField1.Size = New System.Drawing.Size(969, 687)
        Me.ContSelectField1.TabIndex = 0
        '
        'frmSelectField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(969, 687)
        Me.Controls.Add(Me.ContSelectField1)
        Me.Name = "frmSelectField"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SelectField"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContSelectField1 As qs2.sitemap.vb.contSelectField
End Class
