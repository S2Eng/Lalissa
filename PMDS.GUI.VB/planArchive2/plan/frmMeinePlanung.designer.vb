<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeinePlanung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMeinePlanung))
        Me.ContPlanungMain1 = New contPlanung2()
        Me.SuspendLayout()
        '
        'ContPlanungMain1
        '
        Me.ContPlanungMain1.BackColor = System.Drawing.Color.Transparent
        Me.ContPlanungMain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContPlanungMain1.Location = New System.Drawing.Point(0, 0)
        Me.ContPlanungMain1.Name = "ContPlanungMain1"
        Me.ContPlanungMain1.Size = New System.Drawing.Size(821, 445)
        Me.ContPlanungMain1.TabIndex = 0
        '
        'frmMeinePlanung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(821, 445)
        Me.Controls.Add(Me.ContPlanungMain1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMeinePlanung"
        Me.Text = "Termine und E-Mails"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContPlanungMain1 As contPlanung2
End Class
