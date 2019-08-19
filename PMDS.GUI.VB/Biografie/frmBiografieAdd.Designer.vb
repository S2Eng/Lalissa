<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBiografieAdd
    Inherits QS2.Desktop.ControlManagment.baseForm

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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Me.PanelOben = New QS2.Desktop.ControlManagment.BasePanel()
        Me.PanelUnten = New QS2.Desktop.ControlManagment.BasePanel()
        Me.btnNeu = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnAbbrechen = New QS2.Desktop.ControlManagment.BaseButton()
        Me.PanelMitte = New QS2.Desktop.ControlManagment.BasePanel()
        Me.UltraGridBagLayoutPanelList = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.uTreeBiografien = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.PanelUnten.SuspendLayout()
        Me.PanelMitte.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelList.SuspendLayout()
        CType(Me.uTreeBiografien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelOben
        '
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(308, 30)
        Me.PanelOben.TabIndex = 0
        Me.PanelOben.Visible = False
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.btnNeu)
        Me.PanelUnten.Controls.Add(Me.btnAbbrechen)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 170)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(308, 34)
        Me.PanelUnten.TabIndex = 1
        '
        'btnNeu
        '
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnNeu.Appearance = Appearance1
        Me.btnNeu.AutoWorkLayout = False
        Me.btnNeu.IsStandardControl = False
        Me.btnNeu.Location = New System.Drawing.Point(151, 3)
        Me.btnNeu.Name = "btnNeu"
        Me.btnNeu.Size = New System.Drawing.Size(88, 26)
        Me.btnNeu.TabIndex = 28
        Me.btnNeu.Text = "Auswählen"
        '
        'btnAbbrechen
        '
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnAbbrechen.Appearance = Appearance2
        Me.btnAbbrechen.AutoWorkLayout = False
        Me.btnAbbrechen.IsStandardControl = False
        Me.btnAbbrechen.Location = New System.Drawing.Point(76, 3)
        Me.btnAbbrechen.Name = "btnAbbrechen"
        Me.btnAbbrechen.Size = New System.Drawing.Size(74, 26)
        Me.btnAbbrechen.TabIndex = 27
        Me.btnAbbrechen.Text = "&Abbrechen"
        '
        'PanelMitte
        '
        Me.PanelMitte.Controls.Add(Me.UltraGridBagLayoutPanelList)
        Me.PanelMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMitte.Location = New System.Drawing.Point(0, 30)
        Me.PanelMitte.Name = "PanelMitte"
        Me.PanelMitte.Size = New System.Drawing.Size(308, 140)
        Me.PanelMitte.TabIndex = 2
        '
        'UltraGridBagLayoutPanelList
        '
        Me.UltraGridBagLayoutPanelList.Controls.Add(Me.uTreeBiografien)
        Me.UltraGridBagLayoutPanelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelList.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelList.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelList.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelList.Name = "UltraGridBagLayoutPanelList"
        Me.UltraGridBagLayoutPanelList.Size = New System.Drawing.Size(308, 140)
        Me.UltraGridBagLayoutPanelList.TabIndex = 0
        '
        'uTreeBiografien
        '
        Me.uTreeBiografien.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutPanelList.SetGridBagConstraint(Me.uTreeBiografien, GridBagConstraint1)
        Me.uTreeBiografien.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.uTreeBiografien.Location = New System.Drawing.Point(5, 5)
        Me.uTreeBiografien.Name = "uTreeBiografien"
        Me.uTreeBiografien.NodeConnectorColor = System.Drawing.SystemColors.ControlDark
        Override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.SelectNodeOnly
        Override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.[Single]
        Me.uTreeBiografien.Override = Override1
        Me.UltraGridBagLayoutPanelList.SetPreferredSize(Me.uTreeBiografien, New System.Drawing.Size(121, 97))
        Me.uTreeBiografien.Size = New System.Drawing.Size(298, 130)
        Me.uTreeBiografien.TabIndex = 0
        '
        'frmBiografieAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(308, 204)
        Me.Controls.Add(Me.PanelMitte)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBiografieAdd"
        Me.Text = "Biografievorlage auswählen"
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelMitte.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelList.ResumeLayout(False)
        CType(Me.uTreeBiografien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnNeu As qs2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnAbbrechen As qs2.Desktop.ControlManagment.BaseButton
    Friend WithEvents UltraGridBagLayoutPanelList As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents uTreeBiografien As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents PanelOben As qs2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelUnten As qs2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelMitte As qs2.Desktop.ControlManagment.BasePanel
End Class
