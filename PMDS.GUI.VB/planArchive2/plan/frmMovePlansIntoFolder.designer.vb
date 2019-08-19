<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovePlansIntoFolder
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
        Me.cboFolders = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.cboFolders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(153, 55)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 26)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Tag = "ResID.Take"
        Me.btnOk.Text = "Auswählen"
        '
        'btnAbrechen
        '
        Me.btnAbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbrechen.Location = New System.Drawing.Point(239, 55)
        Me.btnAbrechen.Name = "btnAbrechen"
        Me.btnAbrechen.Size = New System.Drawing.Size(68, 26)
        Me.btnAbrechen.TabIndex = 9
        Me.btnAbrechen.Tag = "ResID.Abort"
        Me.btnAbrechen.Text = "Abrechen"
        '
        'cboFolders
        '
        Me.cboFolders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFolders.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboFolders.AutoSize = False
        Me.cboFolders.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboFolders.Location = New System.Drawing.Point(66, 20)
        Me.cboFolders.Name = "cboFolders"
        Me.cboFolders.Size = New System.Drawing.Size(381, 21)
        Me.cboFolders.TabIndex = 385
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(12, 19)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(51, 23)
        Me.Label54.TabIndex = 386
        Me.Label54.Tag = "ResID.Folder"
        Me.Label54.Text = "Ordner"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmMovePlansIntoFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(461, 85)
        Me.Controls.Add(Me.cboFolders)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnAbrechen)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovePlansIntoFolder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "ResID.SelectUser"
        Me.Text = "In Ordner verschieben"
        CType(Me.cboFolders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents cboFolders As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
