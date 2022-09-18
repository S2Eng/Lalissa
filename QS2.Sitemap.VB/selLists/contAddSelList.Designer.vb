<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contAddSelList
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contAddSelList))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkForServices = New System.Windows.Forms.CheckBox()
        Me.btnTakeOwnershipQuery = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.chkPublished = New System.Windows.Forms.CheckBox()
        Me.chkIsSubquery = New System.Windows.Forms.CheckBox()
        Me.ContAddQueryType1 = New qs2.sitemap.vb.contAddQueryType()
        Me.btnCancel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnSave = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.chkPrivate = New System.Windows.Forms.CheckBox()
        Me.ContCboSelList1 = New qs2.sitemap.vb.contCboSelList()
        Me.lblQueryGroup = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDescription = New Infragistics.Win.Misc.UltraLabel()
        Me.btnAssignToMe = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SqlAdmin1 = New qs2.core.vb.sqlAdmin(Me.components)
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.btnCopyQuery = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.btnCopyQuery)
        Me.UltraTabPageControl1.Controls.Add(Me.chkForServices)
        Me.UltraTabPageControl1.Controls.Add(Me.btnTakeOwnershipQuery)
        Me.UltraTabPageControl1.Controls.Add(Me.chkPublished)
        Me.UltraTabPageControl1.Controls.Add(Me.chkIsSubquery)
        Me.UltraTabPageControl1.Controls.Add(Me.ContAddQueryType1)
        Me.UltraTabPageControl1.Controls.Add(Me.btnCancel)
        Me.UltraTabPageControl1.Controls.Add(Me.btnSave)
        Me.UltraTabPageControl1.Controls.Add(Me.chkPrivate)
        Me.UltraTabPageControl1.Controls.Add(Me.ContCboSelList1)
        Me.UltraTabPageControl1.Controls.Add(Me.lblQueryGroup)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescription)
        Me.UltraTabPageControl1.Controls.Add(Me.lblDescription)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(610, 306)
        '
        'chkForServices
        '
        Me.chkForServices.AutoSize = True
        Me.chkForServices.Location = New System.Drawing.Point(478, 51)
        Me.chkForServices.Name = "chkForServices"
        Me.chkForServices.Size = New System.Drawing.Size(83, 17)
        Me.chkForServices.TabIndex = 600
        Me.chkForServices.Text = "For services"
        Me.chkForServices.UseVisualStyleBackColor = True
        '
        'btnTakeOwnershipQuery
        '
        Me.btnTakeOwnershipQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance1.TextVAlignAsString = "Middle"
        Me.btnTakeOwnershipQuery.Appearance = Appearance1
        Me.btnTakeOwnershipQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTakeOwnershipQuery.Location = New System.Drawing.Point(244, 273)
        Me.btnTakeOwnershipQuery.Name = "btnTakeOwnershipQuery"
        Me.btnTakeOwnershipQuery.OwnAutoTextYN = False
        Me.btnTakeOwnershipQuery.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnTakeOwnershipQuery.OwnPictureTxt = ""
        Me.btnTakeOwnershipQuery.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnTakeOwnershipQuery.OwnTooltipText = ""
        Me.btnTakeOwnershipQuery.OwnTooltipTitle = Nothing
        Me.btnTakeOwnershipQuery.Size = New System.Drawing.Size(130, 27)
        Me.btnTakeOwnershipQuery.TabIndex = 597
        Me.btnTakeOwnershipQuery.Text = "Take ownership"
        '
        'chkPublished
        '
        Me.chkPublished.AutoSize = True
        Me.chkPublished.Location = New System.Drawing.Point(277, 51)
        Me.chkPublished.Name = "chkPublished"
        Me.chkPublished.Size = New System.Drawing.Size(72, 17)
        Me.chkPublished.TabIndex = 599
        Me.chkPublished.Text = "Published"
        Me.chkPublished.UseVisualStyleBackColor = True
        '
        'chkIsSubquery
        '
        Me.chkIsSubquery.AutoSize = True
        Me.chkIsSubquery.Location = New System.Drawing.Point(184, 51)
        Me.chkIsSubquery.Name = "chkIsSubquery"
        Me.chkIsSubquery.Size = New System.Drawing.Size(71, 17)
        Me.chkIsSubquery.TabIndex = 598
        Me.chkIsSubquery.Text = "Subquery"
        Me.chkIsSubquery.UseVisualStyleBackColor = True
        '
        'ContAddQueryType1
        '
        Me.ContAddQueryType1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContAddQueryType1.BackColor = System.Drawing.Color.Transparent
        Me.ContAddQueryType1.Location = New System.Drawing.Point(110, 100)
        Me.ContAddQueryType1.Name = "ContAddQueryType1"
        Me.ContAddQueryType1.Size = New System.Drawing.Size(489, 163)
        Me.ContAddQueryType1.TabIndex = 597
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlignAsString = "Middle"
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(428, 273)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OwnAutoTextYN = False
        Me.btnCancel.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnCancel.OwnPictureTxt = ""
        Me.btnCancel.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnCancel.OwnTooltipText = ""
        Me.btnCancel.OwnTooltipTitle = Nothing
        Me.btnCancel.Size = New System.Drawing.Size(71, 27)
        Me.btnCancel.TabIndex = 101
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance3.TextVAlignAsString = "Middle"
        Me.btnSave.Appearance = Appearance3
        Me.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSave.Location = New System.Drawing.Point(505, 273)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.OwnAutoTextYN = True
        Me.btnSave.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Speichern
        Me.btnSave.OwnPictureTxt = ""
        Me.btnSave.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnSave.OwnTooltipText = ""
        Me.btnSave.OwnTooltipTitle = Nothing
        Me.btnSave.Size = New System.Drawing.Size(86, 27)
        Me.btnSave.TabIndex = 100
        Me.btnSave.Text = "Speichern"
        '
        'chkPrivate
        '
        Me.chkPrivate.AutoSize = True
        Me.chkPrivate.Location = New System.Drawing.Point(111, 51)
        Me.chkPrivate.Name = "chkPrivate"
        Me.chkPrivate.Size = New System.Drawing.Size(59, 17)
        Me.chkPrivate.TabIndex = 1
        Me.chkPrivate.Text = "Private"
        Me.chkPrivate.UseVisualStyleBackColor = True
        '
        'ContCboSelList1
        '
        Me.ContCboSelList1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContCboSelList1.BackColor = System.Drawing.Color.Transparent
        Me.ContCboSelList1.Location = New System.Drawing.Point(110, 73)
        Me.ContCboSelList1.Name = "ContCboSelList1"
        Me.ContCboSelList1.Size = New System.Drawing.Size(481, 24)
        Me.ContCboSelList1.TabIndex = 2
        Me.ContCboSelList1.UserEntry = "True"
        '
        'lblQueryGroup
        '
        Me.lblQueryGroup.Appearance = Appearance3
        Me.lblQueryGroup.Location = New System.Drawing.Point(12, 77)
        Me.lblQueryGroup.Name = "lblQueryGroup"
        Me.lblQueryGroup.Size = New System.Drawing.Size(179, 17)
        Me.lblQueryGroup.TabIndex = 596
        Me.lblQueryGroup.Text = "QueryGroup"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(110, 24)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(481, 21)
        Me.txtDescription.TabIndex = 0
        '
        'lblDescription
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblDescription.Appearance = Appearance4
        Me.lblDescription.Location = New System.Drawing.Point(12, 26)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(179, 17)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Description"
        '
        'btnAssignToMe
        '
        Me.btnAssignToMe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlignAsString = "Middle"
        Me.btnAssignToMe.Appearance = Appearance5
        Me.btnAssignToMe.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAssignToMe.Location = New System.Drawing.Point(133, 273)
        Me.btnAssignToMe.Name = "btnAssignToMe"
        Me.btnAssignToMe.OwnAutoTextYN = False
        Me.btnAssignToMe.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnAssignToMe.OwnPictureTxt = ""
        Me.btnAssignToMe.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnAssignToMe.OwnTooltipText = ""
        Me.btnAssignToMe.OwnTooltipTitle = Nothing
        Me.btnAssignToMe.Size = New System.Drawing.Size(105, 27)
        Me.btnAssignToMe.TabIndex = 110
        Me.btnAssignToMe.Text = "Assign to me"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(610, 306)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
        Me.UltraTabControl1.TabIndex = 596
        UltraTab1.Key = "AddSelList"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "AddSelList"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(610, 306)
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
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAdmin"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnCopyQuery
        '
        Me.btnCopyQuery.Location = New System.Drawing.Point(21, 273)
        Me.btnCopyQuery.Name = "btnCopyQuery"
        Me.btnCopyQuery.Size = New System.Drawing.Size(63, 27)
        Me.btnCopyQuery.TabIndex = 601
        Me.btnCopyQuery.Text = "Copy"
        '
        'contAddSelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnAssignToMe)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Name = "contAddSelList"
        Me.Size = New System.Drawing.Size(610, 306)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDescription As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents ContCboSelList1 As qs2.sitemap.vb.contCboSelList
    Friend WithEvents lblQueryGroup As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkPrivate As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents SqlAdmin1 As qs2.core.vb.sqlAdmin
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin
    Public WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private WithEvents btnSave As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnCancel As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents ContAddQueryType1 As qs2.sitemap.vb.contAddQueryType
    Friend WithEvents chkIsSubquery As System.Windows.Forms.CheckBox
    Public WithEvents chkPublished As Windows.Forms.CheckBox
    Private WithEvents btnAssignToMe As ownControls.inherit_Infrag.InfragButton
    Private WithEvents btnTakeOwnershipQuery As ownControls.inherit_Infrag.InfragButton
    Public WithEvents chkForServices As Windows.Forms.CheckBox
    Friend WithEvents btnCopyQuery As Infragistics.Win.Misc.UltraButton
End Class
