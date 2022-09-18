<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectObject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectObject))
        Me.ContSelectObject1 = New qs2.core.vb.contSelectObject()
        Me.SuspendLayout()
        '
        'ContSelectObject1
        '
        Me.ContSelectObject1.BackColor = System.Drawing.Color.Transparent
        Me.ContSelectObject1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContSelectObject1.Location = New System.Drawing.Point(0, 0)
        Me.ContSelectObject1.Name = "ContSelectObject1"
        Me.ContSelectObject1.Size = New System.Drawing.Size(877, 239)
        Me.ContSelectObject1.TabIndex = 0
        '
        'frmSelectObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(877, 239)
        Me.Controls.Add(Me.ContSelectObject1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectObject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select object"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContSelectObject1 As qs2.core.vb.contSelectObject
End Class
