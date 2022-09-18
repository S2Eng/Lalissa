<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserSelList
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
        Me.ContUserSelList1 = New qs2.sitemap.vb.contUserSelList()
        Me.SuspendLayout()
        '
        'ContUserSelList1
        '
        Me.ContUserSelList1.BackColor = System.Drawing.Color.Transparent
        Me.ContUserSelList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContUserSelList1.Location = New System.Drawing.Point(0, 0)
        Me.ContUserSelList1.Name = "ContUserSelList1"
        Me.ContUserSelList1.Size = New System.Drawing.Size(681, 574)
        Me.ContUserSelList1.TabIndex = 0
        '
        'frmUserSelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(681, 574)
        Me.Controls.Add(Me.ContUserSelList1)
        Me.Name = "frmUserSelList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign User-SelLists"
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents ContUserSelList1 As contUserSelList
End Class
