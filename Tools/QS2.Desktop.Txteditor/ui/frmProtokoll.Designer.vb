<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProtokoll
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.txtProtokoll = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.UFormLinkZurücksetzen = New Infragistics.Win.Misc.UltraLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.lblTitleError = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor()
        Me.pictureBoxError = New System.Windows.Forms.PictureBox()
        Me.lblSendMessageAsEMail = New Infragistics.Win.Misc.UltraLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.pictureBoxError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(801, 335)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(801, 335)
        Me.Panel1.TabIndex = 1
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.txtProtokoll)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(801, 335)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'txtProtokoll
        '
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.ItalicAsString = "False"
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.FontData.StrikeoutAsString = "False"
        Appearance1.FontData.UnderlineAsString = "False"
        Me.txtProtokoll.Appearance = Appearance1
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 2
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.txtProtokoll, GridBagConstraint1)
        Me.txtProtokoll.Location = New System.Drawing.Point(5, 5)
        Me.txtProtokoll.Name = "txtProtokoll"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.txtProtokoll, New System.Drawing.Size(283, 116))
        Me.txtProtokoll.Size = New System.Drawing.Size(791, 328)
        Me.txtProtokoll.TabIndex = 0
        Me.txtProtokoll.Value = ""
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(805, 361)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.Key = "Protokoll"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Protokoll"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.UseAppStyling = False
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(801, 335)
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.UFormLinkZurücksetzen)
        Me.PanelBottom.Controls.Add(Me.btnClose)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 391)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(805, 28)
        Me.PanelBottom.TabIndex = 2
        '
        'UFormLinkZurücksetzen
        '
        Appearance2.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance2.FontData.SizeInPoints = 8.0!
        Appearance2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.UFormLinkZurücksetzen.Appearance = Appearance2
        Me.UFormLinkZurücksetzen.AutoSize = True
        Appearance3.FontData.UnderlineAsString = "True"
        Me.UFormLinkZurücksetzen.HotTrackAppearance = Appearance3
        Me.UFormLinkZurücksetzen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UFormLinkZurücksetzen.Location = New System.Drawing.Point(12, 6)
        Me.UFormLinkZurücksetzen.Name = "UFormLinkZurücksetzen"
        Me.UFormLinkZurücksetzen.Size = New System.Drawing.Size(54, 14)
        Me.UFormLinkZurücksetzen.TabIndex = 4
        Me.UFormLinkZurücksetzen.Text = "Copy Text"
        Me.UFormLinkZurücksetzen.UseAppStyling = False
        Me.UFormLinkZurücksetzen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(719, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.lblTitleError)
        Me.PanelTop.Controls.Add(Me.pictureBoxError)
        Me.PanelTop.Controls.Add(Me.lblSendMessageAsEMail)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(805, 30)
        Me.PanelTop.TabIndex = 3
        '
        'lblTitleError
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BackColorDisabled = System.Drawing.Color.White
        Appearance4.BorderColor = System.Drawing.Color.White
        Appearance4.FontData.SizeInPoints = 8.0!
        Appearance4.ForeColor = System.Drawing.Color.Red
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblTitleError.Appearance = Appearance4
        Me.lblTitleError.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.lblTitleError.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitleError.Location = New System.Drawing.Point(82, 0)
        Me.lblTitleError.Name = "lblTitleError"
        Me.lblTitleError.ReadOnly = True
        Me.lblTitleError.Size = New System.Drawing.Size(460, 30)
        Me.lblTitleError.TabIndex = 14
        Me.lblTitleError.UseAppStyling = False
        Me.lblTitleError.Value = "<span style=""color:DarkRed; background-color:White; font-family:Arial; font-size:" & _
    "10pt;"">Unexpected errors occured. Please contact your administrator.</span><br/>" & _
    ""
        Me.lblTitleError.Visible = False
        '
        'pictureBoxError
        '
        Me.pictureBoxError.Dock = System.Windows.Forms.DockStyle.Left
        Me.pictureBoxError.Location = New System.Drawing.Point(0, 0)
        Me.pictureBoxError.Name = "pictureBoxError"
        Me.pictureBoxError.Size = New System.Drawing.Size(82, 30)
        Me.pictureBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBoxError.TabIndex = 13
        Me.pictureBoxError.TabStop = False
        Me.pictureBoxError.Visible = False
        '
        'lblSendMessageAsEMail
        '
        Me.lblSendMessageAsEMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance5.FontData.SizeInPoints = 8.0!
        Appearance5.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance5.TextHAlignAsString = "Right"
        Me.lblSendMessageAsEMail.Appearance = Appearance5
        Appearance6.FontData.UnderlineAsString = "True"
        Me.lblSendMessageAsEMail.HotTrackAppearance = Appearance6
        Me.lblSendMessageAsEMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSendMessageAsEMail.Location = New System.Drawing.Point(650, 9)
        Me.lblSendMessageAsEMail.Name = "lblSendMessageAsEMail"
        Me.lblSendMessageAsEMail.Size = New System.Drawing.Size(135, 14)
        Me.lblSendMessageAsEMail.TabIndex = 11
        Me.lblSendMessageAsEMail.Text = "Send Protocol"
        Me.lblSendMessageAsEMail.UseAppStyling = False
        Me.lblSendMessageAsEMail.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.UltraTabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(805, 361)
        Me.Panel2.TabIndex = 4
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmProtokoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(805, 419)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.Name = "frmProtokoll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Protokoll"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.pictureBoxError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Public WithEvents txtProtokoll As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblSendMessageAsEMail As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UFormLinkZurücksetzen As Infragistics.Win.Misc.UltraLabel
    Public WithEvents lblTitleError As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Public WithEvents pictureBoxError As System.Windows.Forms.PictureBox
End Class
