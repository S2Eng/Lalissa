<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contZwischenablage
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Explorer")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiKopieren")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiAusschneiden")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ZwischenablageNeuLaden")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("GesamteZwischenablageLeeren")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Explorer")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contZwischenablage))
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiKopieren")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiAusschneiden")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim LabelTool3 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space02")
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ZwischenablageNeuLaden")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("GesamteZwischenablageLeeren")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UTreeZwischenablage = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.CMenuStripZwischenablage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TeiÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiEinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DateiKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiAusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._contZwischenablage_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contZwischenablage_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contZwischenablage_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.UTreeZwischenablage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripZwischenablage.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UTreeZwischenablage
        '
        Me.UTreeZwischenablage.AllowDrop = True
        Me.UTreeZwischenablage.ContextMenuStrip = Me.CMenuStripZwischenablage
        Me.UTreeZwischenablage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UTreeZwischenablage.Location = New System.Drawing.Point(0, 27)
        Me.UTreeZwischenablage.Name = "UTreeZwischenablage"
        Override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.[Single]
        Me.UTreeZwischenablage.Override = Override1
        Me.UTreeZwischenablage.Size = New System.Drawing.Size(268, 448)
        Me.UTreeZwischenablage.TabIndex = 0
        '
        'CMenuStripZwischenablage
        '
        Me.CMenuStripZwischenablage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TeiÖffnenToolStripMenuItem, Me.DateiLöschenToolStripMenuItem, Me.DateiEinfügenToolStripMenuItem, Me.ToolStripMenuItem1, Me.DateiKopierenToolStripMenuItem, Me.DateiAusschneidenToolStripMenuItem})
        Me.CMenuStripZwischenablage.Name = "CMenuStripZwischenablage"
        Me.CMenuStripZwischenablage.Size = New System.Drawing.Size(284, 120)
        '
        'TeiÖffnenToolStripMenuItem
        '
        Me.TeiÖffnenToolStripMenuItem.Name = "TeiÖffnenToolStripMenuItem"
        Me.TeiÖffnenToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.TeiÖffnenToolStripMenuItem.Text = "Datei öffnen ..."
        '
        'DateiLöschenToolStripMenuItem
        '
        Me.DateiLöschenToolStripMenuItem.Name = "DateiLöschenToolStripMenuItem"
        Me.DateiLöschenToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.DateiLöschenToolStripMenuItem.Text = "Datei löschen ..."
        '
        'DateiEinfügenToolStripMenuItem
        '
        Me.DateiEinfügenToolStripMenuItem.Name = "DateiEinfügenToolStripMenuItem"
        Me.DateiEinfügenToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.DateiEinfügenToolStripMenuItem.Text = "Datei zur Zwischenablage hinzufügen ..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(280, 6)
        '
        'DateiKopierenToolStripMenuItem
        '
        Me.DateiKopierenToolStripMenuItem.Name = "DateiKopierenToolStripMenuItem"
        Me.DateiKopierenToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.DateiKopierenToolStripMenuItem.Text = "Datei kopieren ..."
        '
        'DateiAusschneidenToolStripMenuItem
        '
        Me.DateiAusschneidenToolStripMenuItem.Name = "DateiAusschneidenToolStripMenuItem"
        Me.DateiAusschneidenToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.DateiAusschneidenToolStripMenuItem.Text = "Datei ausschneiden ..."
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        Me.UltraToolbarsManager1.LockToolbars = True
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, LabelTool1, ButtonTool3, ButtonTool4, ButtonTool5, ButtonTool6})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        ButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance1
        ButtonTool7.SharedPropsInternal.Caption = "Zwischenablage öffnen"
        ButtonTool7.SharedPropsInternal.ToolTipText = "Zwischenablage öffnen"
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        ButtonTool8.SharedPropsInternal.Caption = "Datei kopieren"
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        ButtonTool9.SharedPropsInternal.AppearancesSmall.Appearance = Appearance3
        ButtonTool9.SharedPropsInternal.Caption = "Datei ausschneiden"
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        ButtonTool10.SharedPropsInternal.AppearancesSmall.Appearance = Appearance4
        ButtonTool10.SharedPropsInternal.Caption = "Datei in die Zwischenablage einfügen ..."
        LabelTool2.SharedPropsInternal.Width = 30
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool11.SharedPropsInternal.AppearancesSmall.Appearance = Appearance5
        ButtonTool11.SharedPropsInternal.Caption = "Zwischenablage neu laden"
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        ButtonTool12.SharedPropsInternal.AppearancesSmall.Appearance = Appearance6
        ButtonTool12.SharedPropsInternal.Caption = "Gesamte Zwischenablage leeren ..."
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool10, LabelTool2, LabelTool3, ButtonTool11, ButtonTool12})
        '
        '_contZwischenablage_Toolbars_Dock_Area_Left
        '
        Me._contZwischenablage_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contZwischenablage_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._contZwischenablage_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contZwischenablage_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contZwischenablage_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._contZwischenablage_Toolbars_Dock_Area_Left.Name = "_contZwischenablage_Toolbars_Dock_Area_Left"
        Me._contZwischenablage_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 448)
        Me._contZwischenablage_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contZwischenablage_Toolbars_Dock_Area_Right
        '
        Me._contZwischenablage_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contZwischenablage_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._contZwischenablage_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contZwischenablage_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contZwischenablage_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(268, 27)
        Me._contZwischenablage_Toolbars_Dock_Area_Right.Name = "_contZwischenablage_Toolbars_Dock_Area_Right"
        Me._contZwischenablage_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 448)
        Me._contZwischenablage_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contZwischenablage_Toolbars_Dock_Area_Top
        '
        Me._contZwischenablage_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contZwischenablage_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._contZwischenablage_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contZwischenablage_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contZwischenablage_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contZwischenablage_Toolbars_Dock_Area_Top.Name = "_contZwischenablage_Toolbars_Dock_Area_Top"
        Me._contZwischenablage_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(268, 27)
        Me._contZwischenablage_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contZwischenablage_Toolbars_Dock_Area_Bottom
        '
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 475)
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.Name = "_contZwischenablage_Toolbars_Dock_Area_Bottom"
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(268, 0)
        Me._contZwischenablage_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'contZwischenablage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.UTreeZwischenablage)
        Me.Controls.Add(Me._contZwischenablage_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contZwischenablage_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contZwischenablage_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contZwischenablage_Toolbars_Dock_Area_Top)
        Me.Name = "contZwischenablage"
        Me.Size = New System.Drawing.Size(268, 475)
        CType(Me.UTreeZwischenablage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripZwischenablage.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _contZwischenablage_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contZwischenablage_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contZwischenablage_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contZwischenablage_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents CMenuStripZwischenablage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DateiEinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateiLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Public WithEvents UTreeZwischenablage As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TeiÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DateiKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateiAusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
