<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelLists
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
        Me.ContSelList1 = New qs2.sitemap.vb.contSelLists()
        Me.SuspendLayout()
        '
        'ContSelList1
        '
        Me.ContSelList1.BackColor = System.Drawing.Color.Transparent
        Me.ContSelList1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContSelList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContSelList1.Location = New System.Drawing.Point(0, 0)
        Me.ContSelList1.Name = "ContSelList1"
        Me.ContSelList1.Size = New System.Drawing.Size(906, 579)
        Me.ContSelList1.TabIndex = 0
        '
        'frmSelLists
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(906, 579)
        Me.Controls.Add(Me.ContSelList1)
        Me.Name = "frmSelLists"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selection Lists"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContSelList1 As qs2.sitemap.vb.contSelLists
End Class
