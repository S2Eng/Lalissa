<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputPwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputPwd))
        Me.btnCancel3 = New System.Windows.Forms.Button()
        Me.btnOK3 = New System.Windows.Forms.Button()
        Me.txtPwdEntered3 = New System.Windows.Forms.TextBox()
        Me.lblEnterPwd = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel3
        '
        Me.btnCancel3.Location = New System.Drawing.Point(211, 51)
        Me.btnCancel3.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel3.Name = "btnCancel3"
        Me.btnCancel3.Size = New System.Drawing.Size(82, 30)
        Me.btnCancel3.TabIndex = 12
        Me.btnCancel3.Text = "Cancel"
        Me.btnCancel3.UseVisualStyleBackColor = True
        '
        'btnOK3
        '
        Me.btnOK3.Location = New System.Drawing.Point(311, 51)
        Me.btnOK3.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK3.Name = "btnOK3"
        Me.btnOK3.Size = New System.Drawing.Size(55, 30)
        Me.btnOK3.TabIndex = 13
        Me.btnOK3.Text = "Ok"
        Me.btnOK3.UseVisualStyleBackColor = True
        '
        'txtPwdEntered3
        '
        Me.txtPwdEntered3.Location = New System.Drawing.Point(171, 16)
        Me.txtPwdEntered3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPwdEntered3.Name = "txtPwdEntered3"
        Me.txtPwdEntered3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwdEntered3.Size = New System.Drawing.Size(194, 25)
        Me.txtPwdEntered3.TabIndex = 14
        '
        'lblEnterPwd
        '
        Me.lblEnterPwd.AutoSize = True
        Me.lblEnterPwd.Location = New System.Drawing.Point(12, 19)
        Me.lblEnterPwd.Name = "lblEnterPwd"
        Me.lblEnterPwd.Size = New System.Drawing.Size(143, 17)
        Me.lblEnterPwd.TabIndex = 15
        Me.lblEnterPwd.Text = "Please enter password:"
        '
        'frmInputPwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(418, 111)
        Me.Controls.Add(Me.lblEnterPwd)
        Me.Controls.Add(Me.txtPwdEntered3)
        Me.Controls.Add(Me.btnOK3)
        Me.Controls.Add(Me.btnCancel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputPwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QS2 - Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel3 As Windows.Forms.Button
    Friend WithEvents btnOK3 As Windows.Forms.Button
    Friend WithEvents txtPwdEntered3 As Windows.Forms.TextBox
    Friend WithEvents lblEnterPwd As Windows.Forms.Label
End Class
