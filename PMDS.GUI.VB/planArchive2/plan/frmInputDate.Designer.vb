<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputDate
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.lblDate = New Infragistics.Win.Misc.UltraLabel()
        Me.udteDateAt = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblTxt = New Infragistics.Win.Misc.UltraLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.udteDateAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(103, 115)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 26)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Tag = "OK"
        Me.btnOk.Text = "OK"
        '
        'btnAbrechen
        '
        Me.btnAbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbrechen.Location = New System.Drawing.Point(174, 115)
        Me.btnAbrechen.Name = "btnAbrechen"
        Me.btnAbrechen.Size = New System.Drawing.Size(81, 26)
        Me.btnAbrechen.TabIndex = 11
        Me.btnAbrechen.Tag = "ResID.Abort"
        Me.btnAbrechen.Text = "Abrechen"
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblDate.Appearance = Appearance1
        Me.lblDate.Location = New System.Drawing.Point(8, 77)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(91, 18)
        Me.lblDate.TabIndex = 13
        Me.lblDate.Text = "Änderungen ab"
        '
        'udteDateAt
        '
        Me.udteDateAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackColorDisabled = System.Drawing.Color.White
        Appearance2.BackColorDisabled2 = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.ItalicAsString = "False"
        Appearance2.FontData.Name = "Microsoft Sans Serif"
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.FontData.StrikeoutAsString = "False"
        Appearance2.FontData.UnderlineAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.udteDateAt.Appearance = Appearance2
        Me.udteDateAt.BackColor = System.Drawing.Color.White
        Me.udteDateAt.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.udteDateAt.Location = New System.Drawing.Point(103, 76)
        Me.udteDateAt.MaskInput = "{date} {time}"
        Me.udteDateAt.Name = "udteDateAt"
        Me.udteDateAt.Size = New System.Drawing.Size(121, 21)
        Me.udteDateAt.TabIndex = 0
        Me.udteDateAt.Value = Nothing
        '
        'lblTxt
        '
        Me.lblTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTxt.Location = New System.Drawing.Point(8, 8)
        Me.lblTxt.Name = "lblTxt"
        Me.lblTxt.Size = New System.Drawing.Size(350, 61)
        Me.lblTxt.TabIndex = 15
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmInputDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 147)
        Me.Controls.Add(Me.lblTxt)
        Me.Controls.Add(Me.udteDateAt)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnAbrechen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PMDS"
        CType(Me.udteDateAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblDate As Infragistics.Win.Misc.UltraLabel
    Public WithEvents udteDateAt As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblTxt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
End Class
