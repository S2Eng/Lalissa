<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProtocol
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
        Me.ContProtocol1 = New contProtocol()
        Me.SuspendLayout()
        '
        'ContProtocol1
        '
        Me.ContProtocol1.BackColor = System.Drawing.Color.White
        Me.ContProtocol1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContProtocol1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContProtocol1.Location = New System.Drawing.Point(0, 0)
        Me.ContProtocol1.Name = "ContProtocol1"
        Me.ContProtocol1.Size = New System.Drawing.Size(829, 496)
        Me.ContProtocol1.TabIndex = 0
        '
        'frmProtocol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(829, 496)
        Me.Controls.Add(Me.ContProtocol1)
        Me.Name = "frmProtocol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Protocol"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContProtocol1 As contProtocol
End Class
