<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSelList
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
        Me.ContAddSelList1 = New qs2.sitemap.vb.contAddSelList()
        Me.SuspendLayout()
        '
        'ContAddSelList1
        '
        Me.ContAddSelList1.BackColor = System.Drawing.Color.Transparent
        Me.ContAddSelList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContAddSelList1.Location = New System.Drawing.Point(0, 0)
        Me.ContAddSelList1.Name = "ContAddSelList1"
        Me.ContAddSelList1.Size = New System.Drawing.Size(610, 306)
        Me.ContAddSelList1.TabIndex = 0
        '
        'frmAddSelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(610, 306)
        Me.Controls.Add(Me.ContAddSelList1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddSelList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAddSelList"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContAddSelList1 As qs2.sitemap.vb.contAddSelList
End Class
