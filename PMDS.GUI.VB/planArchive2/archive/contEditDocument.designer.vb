<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contEditDocument
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.txtBezeichnung = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBezeichnung = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        CType(Me.txtBezeichnung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Controls.Add(Me.btnAbort)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 62)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(579, 32)
        Me.PanelBottom.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(204, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 25)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(281, 3)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(74, 25)
        Me.btnAbort.TabIndex = 11
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abrechen"
        '
        'txtBezeichnung
        '
        Me.txtBezeichnung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColorDisabled = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Appearance1.TextHAlignAsString = "Left"
        Me.txtBezeichnung.Appearance = Appearance1
        Me.txtBezeichnung.AutoSize = False
        Me.txtBezeichnung.BackColor = System.Drawing.Color.White
        Me.txtBezeichnung.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.txtBezeichnung.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBezeichnung.Location = New System.Drawing.Point(94, 9)
        Me.txtBezeichnung.Name = "txtBezeichnung"
        Me.txtBezeichnung.Size = New System.Drawing.Size(474, 20)
        Me.txtBezeichnung.TabIndex = 17
        Me.txtBezeichnung.Tag = ""
        Me.txtBezeichnung.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.txtBezeichnung.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblBezeichnung
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblBezeichnung.Appearance = Appearance2
        Me.lblBezeichnung.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBezeichnung.Location = New System.Drawing.Point(8, 9)
        Me.lblBezeichnung.Name = "lblBezeichnung"
        Me.lblBezeichnung.Size = New System.Drawing.Size(96, 21)
        Me.lblBezeichnung.TabIndex = 18
        Me.lblBezeichnung.Tag = "ResID.Description"
        Me.lblBezeichnung.Text = "Bezeichnung"
        '
        'contEditDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtBezeichnung)
        Me.Controls.Add(Me.lblBezeichnung)
        Me.Controls.Add(Me.PanelBottom)
        Me.Name = "contEditDocument"
        Me.Size = New System.Drawing.Size(579, 94)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        CType(Me.txtBezeichnung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Public WithEvents txtBezeichnung As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblBezeichnung As Infragistics.Win.Misc.UltraLabel

End Class
