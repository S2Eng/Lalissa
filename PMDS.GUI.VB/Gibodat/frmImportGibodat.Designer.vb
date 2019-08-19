<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportGibodat
    Inherits QS2.Desktop.ControlManagment.baseForm

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
        Me.txtErrors = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor()
        Me.btn_Start = New QS2.Desktop.ControlManagment.BaseButtonWin()
        Me.lblFertig = New QS2.Desktop.ControlManagment.BaseLableWin()
        Me.SuspendLayout()
        '
        'txtErrors
        '
        Me.txtErrors.Location = New System.Drawing.Point(13, 109)
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.Size = New System.Drawing.Size(436, 265)
        Me.txtErrors.TabIndex = 2
        Me.txtErrors.Value = ""
        '
        'btn_Start
        '
        Me.btn_Start.Location = New System.Drawing.Point(143, 33)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(167, 39)
        Me.btn_Start.TabIndex = 0
        Me.btn_Start.Text = "Jetzt starten!"
        Me.btn_Start.UseVisualStyleBackColor = True
        '
        'lblFertig
        '
        Me.lblFertig.AutoSize = True
        Me.lblFertig.Location = New System.Drawing.Point(147, 75)
        Me.lblFertig.Name = "lblFertig"
        Me.lblFertig.Size = New System.Drawing.Size(43, 13)
        Me.lblFertig.TabIndex = 1
        Me.lblFertig.Text = "lblFertig"
        Me.lblFertig.Visible = False
        '
        'frmImportGibodat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(461, 391)
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.lblFertig)
        Me.Controls.Add(Me.btn_Start)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 80)
        Me.Name = "frmImportGibodat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PMDS -Datenübernahme aus Gibodat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtErrors As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Friend WithEvents btn_Start As System.Windows.Forms.Button
    Friend WithEvents lblFertig As System.Windows.Forms.Label
End Class
