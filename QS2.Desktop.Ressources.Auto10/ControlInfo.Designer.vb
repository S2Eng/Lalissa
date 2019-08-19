<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlInfo
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTypeControl = New System.Windows.Forms.Label()
        Me.lblIDRes = New System.Windows.Forms.Label()
        Me.lblIsStandardControl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(581, 102)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(43, 22)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTypeControl
        '
        Me.lblTypeControl.AutoSize = True
        Me.lblTypeControl.Location = New System.Drawing.Point(14, 12)
        Me.lblTypeControl.Name = "lblTypeControl"
        Me.lblTypeControl.Size = New System.Drawing.Size(70, 13)
        Me.lblTypeControl.TabIndex = 1
        Me.lblTypeControl.Text = "Type-Control:"
        '
        'lblIDRes
        '
        Me.lblIDRes.AutoSize = True
        Me.lblIDRes.Location = New System.Drawing.Point(14, 33)
        Me.lblIDRes.Name = "lblIDRes"
        Me.lblIDRes.Size = New System.Drawing.Size(72, 13)
        Me.lblIDRes.TabIndex = 2
        Me.lblIDRes.Text = "IDRessource:"
        '
        'lblIsStandardControl
        '
        Me.lblIsStandardControl.AutoSize = True
        Me.lblIsStandardControl.Location = New System.Drawing.Point(14, 54)
        Me.lblIsStandardControl.Name = "lblIsStandardControl"
        Me.lblIsStandardControl.Size = New System.Drawing.Size(94, 13)
        Me.lblIsStandardControl.TabIndex = 3
        Me.lblIsStandardControl.Text = "IsStandardControl:"
        '
        'ControlInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(628, 127)
        Me.Controls.Add(Me.lblIsStandardControl)
        Me.Controls.Add(Me.lblIDRes)
        Me.Controls.Add(Me.lblTypeControl)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ControlInfo"
        Me.Text = "Control-Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblTypeControl As System.Windows.Forms.Label
    Friend WithEvents lblIDRes As System.Windows.Forms.Label
    Friend WithEvents lblIsStandardControl As System.Windows.Forms.Label
End Class
