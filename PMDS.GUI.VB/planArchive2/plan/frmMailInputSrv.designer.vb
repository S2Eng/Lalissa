<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMailInputSrv
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
        Me.ContMailInputSrv1 = New contMailInputSrv()
        Me.SuspendLayout()
        '
        'ContMailInputSrv1
        '
        Me.ContMailInputSrv1.BackColor = System.Drawing.Color.Transparent
        Me.ContMailInputSrv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContMailInputSrv1.Location = New System.Drawing.Point(0, 0)
        Me.ContMailInputSrv1.Name = "ContMailInputSrv1"
        Me.ContMailInputSrv1.Size = New System.Drawing.Size(991, 686)
        Me.ContMailInputSrv1.TabIndex = 0
        '
        'frmMailInputSrv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(991, 686)
        Me.Controls.Add(Me.ContMailInputSrv1)
        Me.DoubleBuffered = True
        Me.Name = "frmMailInputSrv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "E-Mails von einem Posteingangs-Server einspielen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContMailInputSrv1 As contMailInputSrv
End Class
