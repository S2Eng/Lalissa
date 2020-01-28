<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocuEdit
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocuEdit))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraButtonSpeichern = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.txtDocuName = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor()
        Me.lblDocuName = New Infragistics.Win.Misc.UltraLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraButtonSpeichern
        '
        Me.UltraButtonSpeichern.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.UltraButtonSpeichern.Appearance = Appearance3
        Me.UltraButtonSpeichern.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonSpeichern.Location = New System.Drawing.Point(156, 52)
        Me.UltraButtonSpeichern.Name = "UltraButtonSpeichern"
        Me.UltraButtonSpeichern.Size = New System.Drawing.Size(86, 27)
        Me.UltraButtonSpeichern.TabIndex = 2
        Me.UltraButtonSpeichern.Text = "Speichern"
        '
        'UltraButtonAbbrechen
        '
        Me.UltraButtonAbbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UltraButtonAbbrechen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonAbbrechen.Location = New System.Drawing.Point(242, 52)
        Me.UltraButtonAbbrechen.Name = "UltraButtonAbbrechen"
        Me.UltraButtonAbbrechen.Size = New System.Drawing.Size(74, 27)
        Me.UltraButtonAbbrechen.TabIndex = 3
        Me.UltraButtonAbbrechen.Text = "Abbrechen"
        '
        'txtDocuName
        '
        Me.txtDocuName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtDocuName.Appearance = Appearance4
        Me.txtDocuName.Location = New System.Drawing.Point(110, 16)
        Me.txtDocuName.Name = "txtDocuName"
        Me.txtDocuName.Size = New System.Drawing.Size(360, 22)
        Me.txtDocuName.TabIndex = 0
        Me.txtDocuName.Value = ""
        '
        'lblDocuName
        '
        Me.lblDocuName.Location = New System.Drawing.Point(9, 19)
        Me.lblDocuName.Name = "lblDocuName"
        Me.lblDocuName.Size = New System.Drawing.Size(111, 16)
        Me.lblDocuName.TabIndex = 10
        Me.lblDocuName.Tag = ""
        Me.lblDocuName.Text = "Dokumentenname"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmDocuEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(479, 84)
        Me.Controls.Add(Me.txtDocuName)
        Me.Controls.Add(Me.lblDocuName)
        Me.Controls.Add(Me.UltraButtonSpeichern)
        Me.Controls.Add(Me.UltraButtonAbbrechen)
        Me.Name = "frmDocuEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dokumentenbezeichnung ändern"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents UltraButtonSpeichern As Infragistics.Win.Misc.UltraButton
    Public WithEvents UltraButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblDocuName As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtDocuName As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
End Class
