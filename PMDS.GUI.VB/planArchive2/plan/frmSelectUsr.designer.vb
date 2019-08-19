<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectUsr
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
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.cboUsers = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(47, 71)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(97, 26)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Tag = "ResID.Take"
        Me.btnOk.Text = "Auswählen"
        '
        'btnAbrechen
        '
        Me.btnAbrechen.Location = New System.Drawing.Point(145, 71)
        Me.btnAbrechen.Name = "btnAbrechen"
        Me.btnAbrechen.Size = New System.Drawing.Size(81, 26)
        Me.btnAbrechen.TabIndex = 9
        Me.btnAbrechen.Tag = "ResID.Abort"
        Me.btnAbrechen.Text = "Abrechen"
        '
        'cboUsers
        '
        Me.cboUsers.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboUsers.AutoSize = False
        Me.cboUsers.Location = New System.Drawing.Point(73, 25)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(153, 21)
        Me.cboUsers.TabIndex = 385
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(-1, 24)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(72, 23)
        Me.Label54.TabIndex = 386
        Me.Label54.Tag = "ResID.User"
        Me.Label54.Text = "Benutzer"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmSelectUsr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(264, 101)
        Me.Controls.Add(Me.cboUsers)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnAbrechen)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectUsr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "ResID.SelectUser"
        Me.Text = "Benutzer auswählen"
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents cboUsers As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
