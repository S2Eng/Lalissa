<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTxtEditor2
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
        Me.contTxtEditor21 = New QS2.Desktop.Txteditor2.contTxtEditor2()
        Me.SuspendLayout()
        '
        'contTxtEditor21
        '
        Me.contTxtEditor21.AllowDrop = True
        Me.contTxtEditor21.BackColor = System.Drawing.Color.Transparent
        Me.contTxtEditor21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contTxtEditor21.Location = New System.Drawing.Point(0, 0)
        Me.contTxtEditor21.Name = "contTxtEditor21"
        Me.contTxtEditor21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.contTxtEditor21.Size = New System.Drawing.Size(847, 584)
        Me.contTxtEditor21.TabIndex = 0
        '
        'frmTxtEditor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(847, 584)
        Me.Controls.Add(Me.contTxtEditor21)
        Me.Name = "frmTxtEditor2"
        Me.Text = "Texteditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents contTxtEditor21 As QS2.Desktop.Txteditor2.contTxtEditor2
End Class
