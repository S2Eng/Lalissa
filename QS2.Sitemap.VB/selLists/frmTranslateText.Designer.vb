<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTranslateText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTranslateText))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnCancel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnOk = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.txtTranslationForIDResGerman = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblTranslationGerman = New Infragistics.Win.Misc.UltraLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.txtTranslationForIDResEnglish = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblTranslationEnglish = New Infragistics.Win.Misc.UltraLabel()
        Me.txtTranslationForIDResUser = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblTranslationUser = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.txtTranslationForIDResGerman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTranslationForIDResEnglish, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTranslationForIDResUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance1.TextVAlignAsString = "Middle"
        Me.btnCancel.Appearance = Appearance1
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(273, 86)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OwnAutoTextYN = False
        Me.btnCancel.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnCancel.OwnPictureTxt = ""
        Me.btnCancel.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnCancel.OwnTooltipText = ""
        Me.btnCancel.OwnTooltipTitle = Nothing
        Me.btnCancel.Size = New System.Drawing.Size(69, 25)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlignAsString = "Middle"
        Me.btnOk.Appearance = Appearance2
        Me.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOk.Location = New System.Drawing.Point(216, 86)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OwnAutoTextYN = True
        Me.btnOk.OwnPicture = qs2.Resources.getRes.Allgemein.ico_OK
        Me.btnOk.OwnPictureTxt = ""
        Me.btnOk.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnOk.OwnTooltipText = ""
        Me.btnOk.OwnTooltipTitle = Nothing
        Me.btnOk.Size = New System.Drawing.Size(57, 25)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Text = "Ok"
        '
        'txtTranslationForIDResGerman
        '
        Me.txtTranslationForIDResGerman.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTranslationForIDResGerman.Location = New System.Drawing.Point(81, 31)
        Me.txtTranslationForIDResGerman.Name = "txtTranslationForIDResGerman"
        Me.txtTranslationForIDResGerman.Size = New System.Drawing.Size(437, 21)
        Me.txtTranslationForIDResGerman.TabIndex = 1
        '
        'lblTranslationGerman
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblTranslationGerman.Appearance = Appearance3
        Me.lblTranslationGerman.Location = New System.Drawing.Point(12, 33)
        Me.lblTranslationGerman.Name = "lblTranslationGerman"
        Me.lblTranslationGerman.Size = New System.Drawing.Size(179, 17)
        Me.lblTranslationGerman.TabIndex = 601
        Me.lblTranslationGerman.Text = "German"
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
        'txtTranslationForIDResEnglish
        '
        Me.txtTranslationForIDResEnglish.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTranslationForIDResEnglish.Location = New System.Drawing.Point(81, 7)
        Me.txtTranslationForIDResEnglish.Name = "txtTranslationForIDResEnglish"
        Me.txtTranslationForIDResEnglish.Size = New System.Drawing.Size(437, 21)
        Me.txtTranslationForIDResEnglish.TabIndex = 0
        '
        'lblTranslationEnglish
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblTranslationEnglish.Appearance = Appearance5
        Me.lblTranslationEnglish.Location = New System.Drawing.Point(12, 9)
        Me.lblTranslationEnglish.Name = "lblTranslationEnglish"
        Me.lblTranslationEnglish.Size = New System.Drawing.Size(179, 17)
        Me.lblTranslationEnglish.TabIndex = 603
        Me.lblTranslationEnglish.Text = "English"
        '
        'txtTranslationForIDResUser
        '
        Me.txtTranslationForIDResUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTranslationForIDResUser.Location = New System.Drawing.Point(81, 55)
        Me.txtTranslationForIDResUser.Name = "txtTranslationForIDResUser"
        Me.txtTranslationForIDResUser.Size = New System.Drawing.Size(437, 21)
        Me.txtTranslationForIDResUser.TabIndex = 2
        '
        'lblTranslationUser
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblTranslationUser.Appearance = Appearance4
        Me.lblTranslationUser.Location = New System.Drawing.Point(12, 57)
        Me.lblTranslationUser.Name = "lblTranslationUser"
        Me.lblTranslationUser.Size = New System.Drawing.Size(179, 17)
        Me.lblTranslationUser.TabIndex = 605
        Me.lblTranslationUser.Text = "User"
        '
        'frmTranslateText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(539, 114)
        Me.Controls.Add(Me.txtTranslationForIDResUser)
        Me.Controls.Add(Me.txtTranslationForIDResEnglish)
        Me.Controls.Add(Me.txtTranslationForIDResGerman)
        Me.Controls.Add(Me.lblTranslationUser)
        Me.Controls.Add(Me.lblTranslationEnglish)
        Me.Controls.Add(Me.lblTranslationGerman)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTranslateText"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Translate Text"
        CType(Me.txtTranslationForIDResGerman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTranslationForIDResEnglish, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTranslationForIDResUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnCancel As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnOk As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Public WithEvents txtTranslationForIDResGerman As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblTranslationGerman As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents txtTranslationForIDResUser As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtTranslationForIDResEnglish As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblTranslationUser As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTranslationEnglish As Infragistics.Win.Misc.UltraLabel
End Class
