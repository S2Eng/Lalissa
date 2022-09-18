<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckUsercode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckUsercode))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnCancel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnOK = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.txtUsercode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblUsercode = New Infragistics.Win.Misc.UltraLabel()
        Me.txtKavVidierungPwd = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblKavVidierungPwd = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.txtUsercode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKavVidierungPwd, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCancel.Location = New System.Drawing.Point(238, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OwnAutoTextYN = False
        Me.btnCancel.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnCancel.OwnPictureTxt = ""
        Me.btnCancel.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnCancel.OwnTooltipText = ""
        Me.btnCancel.OwnTooltipTitle = Nothing
        Me.btnCancel.Size = New System.Drawing.Size(71, 27)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlignAsString = "Middle"
        Me.btnOK.Appearance = Appearance2
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(152, 72)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.OwnAutoTextYN = True
        Me.btnOK.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Speichern
        Me.btnOK.OwnPictureTxt = ""
        Me.btnOK.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnOK.OwnTooltipText = ""
        Me.btnOK.OwnTooltipTitle = Nothing
        Me.btnOK.Size = New System.Drawing.Size(86, 27)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        '
        'txtUsercode
        '
        Me.txtUsercode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsercode.Location = New System.Drawing.Point(127, 16)
        Me.txtUsercode.Name = "txtUsercode"
        Me.txtUsercode.Size = New System.Drawing.Size(313, 21)
        Me.txtUsercode.TabIndex = 104
        '
        'lblUsercode
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblUsercode.Appearance = Appearance3
        Me.lblUsercode.Location = New System.Drawing.Point(10, 18)
        Me.lblUsercode.Name = "lblUsercode"
        Me.lblUsercode.Size = New System.Drawing.Size(122, 17)
        Me.lblUsercode.TabIndex = 105
        Me.lblUsercode.Text = "Usercode"
        '
        'txtKavVidierungPwd
        '
        Me.txtKavVidierungPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKavVidierungPwd.Location = New System.Drawing.Point(127, 40)
        Me.txtKavVidierungPwd.Name = "txtKavVidierungPwd"
        Me.txtKavVidierungPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtKavVidierungPwd.Size = New System.Drawing.Size(313, 21)
        Me.txtKavVidierungPwd.TabIndex = 106
        '
        'lblKavVidierungPwd
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblKavVidierungPwd.Appearance = Appearance4
        Me.lblKavVidierungPwd.Location = New System.Drawing.Point(10, 42)
        Me.lblKavVidierungPwd.Name = "lblKavVidierungPwd"
        Me.lblKavVidierungPwd.Size = New System.Drawing.Size(122, 17)
        Me.lblKavVidierungPwd.TabIndex = 107
        Me.lblKavVidierungPwd.Text = "KavVidierungPwd"
        '
        'frmCheckUsercode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(446, 104)
        Me.Controls.Add(Me.txtKavVidierungPwd)
        Me.Controls.Add(Me.lblKavVidierungPwd)
        Me.Controls.Add(Me.txtUsercode)
        Me.Controls.Add(Me.lblUsercode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckUsercode"
        Me.Text = "Check usercode"
        CType(Me.txtUsercode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKavVidierungPwd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnCancel As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnOK As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Public WithEvents txtUsercode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblUsercode As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtKavVidierungPwd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblKavVidierungPwd As Infragistics.Win.Misc.UltraLabel
End Class
