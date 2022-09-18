<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelListsObj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelListsObj))
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.ContSelListsObj1 = New qs2.sitemap.vb.contSelListsObj()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.btnClose2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnSave2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.ContSelListsObj1)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(821, 366)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'ContSelListsObj1
        '
        Me.ContSelListsObj1.BackColor = System.Drawing.Color.White
        Me.ContSelListsObj1.Dock = System.Windows.Forms.DockStyle.Fill
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.ContSelListsObj1, GridBagConstraint1)
        Me.ContSelListsObj1.Location = New System.Drawing.Point(0, 0)
        Me.ContSelListsObj1.Name = "ContSelListsObj1"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.ContSelListsObj1, New System.Drawing.Size(435, 217))
        Me.ContSelListsObj1.Size = New System.Drawing.Size(821, 366)
        Me.ContSelListsObj1.TabIndex = 0
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.btnClose2)
        Me.PanelUnten.Controls.Add(Me.btnSave2)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 366)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(821, 34)
        Me.PanelUnten.TabIndex = 3
        '
        'btnClose2
        '
        Me.btnClose2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnClose2.Appearance = Appearance1
        Me.btnClose2.Location = New System.Drawing.Point(737, 3)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.OwnAutoTextYN = False
        Me.btnClose2.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnClose2.OwnPictureTxt = ""
        Me.btnClose2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnClose2.OwnTooltipText = ""
        Me.btnClose2.OwnTooltipTitle = Nothing
        Me.btnClose2.Size = New System.Drawing.Size(72, 28)
        Me.btnClose2.TabIndex = 586
        Me.btnClose2.Text = "Close"
        '
        'btnSave2
        '
        Me.btnSave2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSave2.Appearance = Appearance2
        Me.btnSave2.Location = New System.Drawing.Point(641, 3)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.OwnAutoTextYN = True
        Me.btnSave2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Speichern
        Me.btnSave2.OwnPictureTxt = ""
        Me.btnSave2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnSave2.OwnTooltipText = ""
        Me.btnSave2.OwnTooltipTitle = Nothing
        Me.btnSave2.Size = New System.Drawing.Size(96, 28)
        Me.btnSave2.TabIndex = 585
        Me.btnSave2.Text = "Speichern"
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(821, 366)
        Me.PanelGrid.TabIndex = 4
        '
        'frmSelListsObj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(821, 400)
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelUnten)
        Me.Name = "frmSelListsObj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign"
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel

    Public WithEvents ContSelListsObj1 As qs2.sitemap.vb.contSelListsObj
    Public WithEvents btnClose2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Public WithEvents btnSave2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
End Class
