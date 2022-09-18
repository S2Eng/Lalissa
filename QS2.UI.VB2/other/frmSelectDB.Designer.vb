<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDB
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblDatabases = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSelect = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.cboDatabases = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.cboDatabases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDatabases
        '
        Me.lblDatabases.Location = New System.Drawing.Point(12, 22)
        Me.lblDatabases.Name = "lblDatabases"
        Me.lblDatabases.Size = New System.Drawing.Size(95, 15)
        Me.lblDatabases.TabIndex = 1
        Me.lblDatabases.Text = "Databases"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSelect.Appearance = Appearance1
        Me.btnSelect.Location = New System.Drawing.Point(182, 51)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(57, 27)
        Me.btnSelect.TabIndex = 100
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbort.Location = New System.Drawing.Point(132, 51)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(50, 27)
        Me.btnAbort.TabIndex = 101
        Me.btnAbort.Text = "Abort"
        '
        'cboDatabases
        '
        Me.cboDatabases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDatabases.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboDatabases.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboDatabases.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboDatabases.Location = New System.Drawing.Point(73, 20)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Size = New System.Drawing.Size(295, 21)
        Me.cboDatabases.TabIndex = 2
        '
        'frmSelectDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(376, 81)
        Me.Controls.Add(Me.cboDatabases)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblDatabases)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Database"
        CType(Me.cboDatabases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDatabases As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnSelect As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Public WithEvents cboDatabases As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
