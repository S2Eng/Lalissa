<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectPatient))
        Me.btnCancel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnOk = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.CboObjects1 = New qs2.sitemap.vb.cboObjects()
        Me.lblPatients = New System.Windows.Forms.Label()
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
        Me.btnCancel.Location = New System.Drawing.Point(211, 40)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OwnAutoTextYN = False
        Me.btnCancel.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnCancel.OwnPictureTxt = ""
        Me.btnCancel.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnCancel.OwnTooltipText = ""
        Me.btnCancel.OwnTooltipTitle = Nothing
        Me.btnCancel.Size = New System.Drawing.Size(69, 26)
        Me.btnCancel.TabIndex = 13
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
        Me.btnOk.Location = New System.Drawing.Point(154, 40)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OwnAutoTextYN = True
        Me.btnOk.OwnPicture = qs2.Resources.getRes.Allgemein.ico_OK
        Me.btnOk.OwnPictureTxt = ""
        Me.btnOk.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnOk.OwnTooltipText = ""
        Me.btnOk.OwnTooltipTitle = Nothing
        Me.btnOk.Size = New System.Drawing.Size(57, 26)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "Ok"
        '
        'CboObjects1
        '
        Me.CboObjects1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboObjects1.BackColor = System.Drawing.Color.Transparent
        Me.CboObjects1.Location = New System.Drawing.Point(69, 11)
        Me.CboObjects1.Name = "CboObjects1"
        Me.CboObjects1.Size = New System.Drawing.Size(325, 26)
        Me.CboObjects1.TabIndex = 14
        '
        'lblPatients
        '
        Me.lblPatients.AutoSize = True
        Me.lblPatients.Location = New System.Drawing.Point(7, 16)
        Me.lblPatients.Name = "lblPatients"
        Me.lblPatients.Size = New System.Drawing.Size(45, 13)
        Me.lblPatients.TabIndex = 15
        Me.lblPatients.Text = "Patients"
        '
        'frmSelectPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 71)
        Me.Controls.Add(Me.lblPatients)
        Me.Controls.Add(Me.CboObjects1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select patient"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents btnCancel As ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnOk As ownControls.inherit_Infrag.InfragButton
    Friend WithEvents CboObjects1 As cboObjects
    Friend WithEvents lblPatients As Windows.Forms.Label
End Class
