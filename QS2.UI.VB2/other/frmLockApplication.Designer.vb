<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLockApplication
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLockApplication))
        Me.btnUnlock = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPassword = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblUserLoggedOn = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCloseApp = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUnlock
        '
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnUnlock.Appearance = Appearance1
        Me.btnUnlock.Location = New System.Drawing.Point(187, 78)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.OwnAutoTextYN = False
        Me.btnUnlock.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnUnlock.OwnPictureTxt = ""
        Me.btnUnlock.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnUnlock.OwnTooltipText = ""
        Me.btnUnlock.OwnTooltipTitle = Nothing
        Me.btnUnlock.Size = New System.Drawing.Size(79, 24)
        Me.btnUnlock.TabIndex = 2
        Me.btnUnlock.Text = "Unlock"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblTitle.Appearance = Appearance2
        Me.lblTitle.Location = New System.Drawing.Point(14, 13)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(252, 15)
        Me.lblTitle.TabIndex = 244
        Me.lblTitle.Text = "Application is locked!"
        Me.lblTitle.UseAppStyling = False
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(14, 54)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(86, 17)
        Me.lblPassword.TabIndex = 246
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(80, 51)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(186, 21)
        Me.txtPassword.TabIndex = 0
        '
        'errorProvider1
        '
        Me.errorProvider1.ContainerControl = Me
        '
        'lblUserLoggedOn
        '
        Me.lblUserLoggedOn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserLoggedOn.Location = New System.Drawing.Point(80, 34)
        Me.lblUserLoggedOn.Name = "lblUserLoggedOn"
        Me.lblUserLoggedOn.Size = New System.Drawing.Size(186, 14)
        Me.lblUserLoggedOn.TabIndex = 247
        Me.lblUserLoggedOn.Text = "User: Admin"
        '
        'btnCloseApp
        '
        Me.btnCloseApp.Location = New System.Drawing.Point(80, 78)
        Me.btnCloseApp.Name = "btnCloseApp"
        Me.btnCloseApp.Size = New System.Drawing.Size(82, 24)
        Me.btnCloseApp.TabIndex = 248
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmLockApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(280, 105)
        Me.Controls.Add(Me.lblUserLoggedOn)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.btnCloseApp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLockApplication"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lock application"
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUnlock As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPassword As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents errorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblUserLoggedOn As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnCloseApp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
