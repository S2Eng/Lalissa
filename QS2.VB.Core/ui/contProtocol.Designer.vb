<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class contProtocol
    Inherits System.Windows.Forms.UserControl

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Save as ...", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Save as ...", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo7 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Save as ...", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo8 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Save as ...", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelProtocol = New System.Windows.Forms.Panel()
        Me.PanelProt = New System.Windows.Forms.Panel()
        Me.TextControl1 = New TXTextControl.TextControl()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.UFormLinkZurücksetzen = New Infragistics.Win.Misc.UltraLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.btnPrintPrieview = New Infragistics.Win.Misc.UltraButton()
        Me.btnRefresh = New Infragistics.Win.Misc.UltraButton()
        Me.lblMonitoring = New Infragistics.Win.Misc.UltraLabel()
        Me.btnClear = New Infragistics.Win.Misc.UltraButton()
        Me.btnSaveAs = New Infragistics.Win.Misc.UltraButton()
        Me.lblTitleError = New Infragistics.Win.Misc.UltraLabel()
        Me.pictureBoxError = New System.Windows.Forms.PictureBox()
        Me.lblSendMessageAsEMail = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraPrintDocument1 = New Infragistics.Win.Printing.UltraPrintDocument(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.PanelProtocol.SuspendLayout()
        Me.PanelProt.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.pictureBoxError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.PanelProtocol)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(801, 392)
        '
        'PanelProtocol
        '
        Me.PanelProtocol.BackColor = System.Drawing.Color.Transparent
        Me.PanelProtocol.Controls.Add(Me.PanelProt)
        Me.PanelProtocol.Controls.Add(Me.PanelBottom)
        Me.PanelProtocol.Controls.Add(Me.PanelTop)
        Me.PanelProtocol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelProtocol.Location = New System.Drawing.Point(0, 0)
        Me.PanelProtocol.Name = "PanelProtocol"
        Me.PanelProtocol.Size = New System.Drawing.Size(801, 392)
        Me.PanelProtocol.TabIndex = 1
        '
        'PanelProt
        '
        Me.PanelProt.BackColor = System.Drawing.Color.Transparent
        Me.PanelProt.Controls.Add(Me.TextControl1)
        Me.PanelProt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelProt.Location = New System.Drawing.Point(0, 30)
        Me.PanelProt.Name = "PanelProt"
        Me.PanelProt.Size = New System.Drawing.Size(801, 334)
        Me.PanelProt.TabIndex = 4
        '
        'TextControl1
        '
        Me.TextControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextControl1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextControl1.Location = New System.Drawing.Point(1, 4)
        Me.TextControl1.Name = "TextControl1"
        Me.TextControl1.Size = New System.Drawing.Size(800, 326)
        Me.TextControl1.TabIndex = 0
        Me.TextControl1.TextBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextControl1.UserNames = Nothing
        Me.TextControl1.ViewMode = TXTextControl.ViewMode.Normal
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.UFormLinkZurücksetzen)
        Me.PanelBottom.Controls.Add(Me.btnClose)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 364)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(801, 28)
        Me.PanelBottom.TabIndex = 2
        '
        'UFormLinkZurücksetzen
        '
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance11.FontData.SizeInPoints = 8.0!
        Appearance11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.UFormLinkZurücksetzen.Appearance = Appearance11
        Me.UFormLinkZurücksetzen.AutoSize = True
        Appearance12.FontData.UnderlineAsString = "True"
        Me.UFormLinkZurücksetzen.HotTrackAppearance = Appearance12
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
        Me.btnClose.Location = New System.Drawing.Point(715, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.btnPrintPrieview)
        Me.PanelTop.Controls.Add(Me.btnRefresh)
        Me.PanelTop.Controls.Add(Me.lblMonitoring)
        Me.PanelTop.Controls.Add(Me.btnClear)
        Me.PanelTop.Controls.Add(Me.btnSaveAs)
        Me.PanelTop.Controls.Add(Me.lblTitleError)
        Me.PanelTop.Controls.Add(Me.pictureBoxError)
        Me.PanelTop.Controls.Add(Me.lblSendMessageAsEMail)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(801, 30)
        Me.PanelTop.TabIndex = 3
        '
        'btnPrintPrieview
        '
        Me.btnPrintPrieview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnPrintPrieview.Appearance = Appearance13
        Me.btnPrintPrieview.Location = New System.Drawing.Point(679, 3)
        Me.btnPrintPrieview.Name = "btnPrintPrieview"
        Me.btnPrintPrieview.Size = New System.Drawing.Size(25, 24)
        Me.btnPrintPrieview.TabIndex = 21
        UltraToolTipInfo5.ToolTipTitle = "Save as ..."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnPrintPrieview, UltraToolTipInfo5)
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnRefresh.Appearance = Appearance14
        Me.btnRefresh.Location = New System.Drawing.Point(767, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 24)
        Me.btnRefresh.TabIndex = 20
        UltraToolTipInfo6.ToolTipTitle = "Save as ..."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnRefresh, UltraToolTipInfo6)
        '
        'lblMonitoring
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.FontData.SizeInPoints = 10.0!
        Appearance15.ForeColor = System.Drawing.Color.DarkRed
        Appearance15.TextVAlignAsString = "Middle"
        Me.lblMonitoring.Appearance = Appearance15
        Me.lblMonitoring.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMonitoring.Location = New System.Drawing.Point(470, 0)
        Me.lblMonitoring.Name = "lblMonitoring"
        Me.lblMonitoring.Size = New System.Drawing.Size(99, 30)
        Me.lblMonitoring.TabIndex = 19
        Me.lblMonitoring.Text = "  Monitoring"
        Me.lblMonitoring.UseAppStyling = False
        Me.lblMonitoring.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnClear.Appearance = Appearance16
        Me.btnClear.Location = New System.Drawing.Point(736, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(25, 24)
        Me.btnClear.TabIndex = 18
        UltraToolTipInfo7.ToolTipTitle = "Save as ..."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnClear, UltraToolTipInfo7)
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance17.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnSaveAs.Appearance = Appearance17
        Me.btnSaveAs.Location = New System.Drawing.Point(711, 3)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(25, 24)
        Me.btnSaveAs.TabIndex = 17
        UltraToolTipInfo8.ToolTipTitle = "Save as ..."
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSaveAs, UltraToolTipInfo8)
        '
        'lblTitleError
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.FontData.SizeInPoints = 10.0!
        Appearance18.ForeColor = System.Drawing.Color.DarkRed
        Appearance18.TextVAlignAsString = "Middle"
        Me.lblTitleError.Appearance = Appearance18
        Me.lblTitleError.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitleError.Location = New System.Drawing.Point(82, 0)
        Me.lblTitleError.Name = "lblTitleError"
        Me.lblTitleError.Size = New System.Drawing.Size(388, 30)
        Me.lblTitleError.TabIndex = 16
        Me.lblTitleError.Text = "Unexpected errors occured. Please contact your administrator."
        Me.lblTitleError.UseAppStyling = False
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
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance19.FontData.SizeInPoints = 8.0!
        Appearance19.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSendMessageAsEMail.Appearance = Appearance19
        Me.lblSendMessageAsEMail.AutoSize = True
        Appearance20.FontData.UnderlineAsString = "True"
        Me.lblSendMessageAsEMail.HotTrackAppearance = Appearance20
        Me.lblSendMessageAsEMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSendMessageAsEMail.Location = New System.Drawing.Point(575, 8)
        Me.lblSendMessageAsEMail.Name = "lblSendMessageAsEMail"
        Me.lblSendMessageAsEMail.Size = New System.Drawing.Size(73, 14)
        Me.lblSendMessageAsEMail.TabIndex = 11
        Me.lblSendMessageAsEMail.Text = "Send Protocol"
        Me.lblSendMessageAsEMail.UseAppStyling = False
        Me.lblSendMessageAsEMail.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(805, 418)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.Key = "Protokoll"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Protokoll"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(801, 392)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contProtocol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Name = "contProtocol"
        Me.Size = New System.Drawing.Size(805, 418)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.PanelProtocol.ResumeLayout(False)
        Me.PanelProt.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.pictureBoxError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents PanelProtocol As System.Windows.Forms.Panel
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents lblSendMessageAsEMail As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UFormLinkZurücksetzen As Infragistics.Win.Misc.UltraLabel
    Public WithEvents pictureBoxError As System.Windows.Forms.PictureBox
    Friend WithEvents PanelProt As System.Windows.Forms.Panel
    Public WithEvents lblTitleError As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnSaveAs As Infragistics.Win.Misc.UltraButton
    Public WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnClear As Infragistics.Win.Misc.UltraButton
    Public WithEvents lblMonitoring As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnRefresh As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnPrintPrieview As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPrintDocument1 As Infragistics.Win.Printing.UltraPrintDocument
    Friend WithEvents TextControl1 As TXTextControl.TextControl
End Class
