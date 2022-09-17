<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTxtEditorField
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
        Me.ContTXTField1 = New QS2.Desktop.Txteditor.contTXTField()
        Me.SuspendLayout()
        '
        'ContTXTField1
        '
        Me.ContTXTField1.bReadOnly = False
        Me.ContTXTField1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContTXTField1.Location = New System.Drawing.Point(0, 0)
        Me.ContTXTField1.Name = "ContTXTField1"
        Me.ContTXTField1.Size = New System.Drawing.Size(843, 583)
        Me.ContTXTField1.TabIndex = 0
        '
        'frmTxtEditorField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(843, 583)
        Me.Controls.Add(Me.ContTXTField1)
        Me.DoubleBuffered = True
        Me.Name = "frmTxtEditorField"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Texteditor"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ContTXTField1 As QS2.Desktop.Txteditor.contTXTField
End Class
