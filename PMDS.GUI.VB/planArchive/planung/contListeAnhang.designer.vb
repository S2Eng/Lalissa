<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contListeAnhang
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AnhangLöschen")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("InZwischenablageKopieren")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AnhangLöschen")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.listDateiAnhang = New Infragistics.Win.UltraWinListView.UltraListView
        Me.CMenuStripAnhang = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me._contListeAnhang_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._contListeAnhang_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._contListeAnhang_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.DateiÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.listDateiAnhang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripAnhang.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listDateiAnhang
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.listDateiAnhang.Appearance = Appearance7
        Me.listDateiAnhang.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.listDateiAnhang.ContextMenuStrip = Me.CMenuStripAnhang
        Me.listDateiAnhang.Dock = System.Windows.Forms.DockStyle.Fill
        Appearance59.BackColor = System.Drawing.Color.RoyalBlue
        Appearance59.ForeColor = System.Drawing.Color.Black
        Me.listDateiAnhang.ItemSettings.ActiveAppearance = Appearance59
        Appearance12.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
        Me.listDateiAnhang.ItemSettings.Appearance = Appearance12
        Appearance60.BackColor = System.Drawing.Color.RoyalBlue
        Appearance60.ForeColor = System.Drawing.Color.Black
        Me.listDateiAnhang.ItemSettings.SelectedAppearance = Appearance60
        Me.listDateiAnhang.Location = New System.Drawing.Point(0, 28)
        Me.listDateiAnhang.Name = "listDateiAnhang"
        Me.listDateiAnhang.Size = New System.Drawing.Size(317, 282)
        Me.listDateiAnhang.TabIndex = 0
        Me.listDateiAnhang.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Thumbnails
        '
        'CMenuStripAnhang
        '
        Me.CMenuStripAnhang.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiÖffnenToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem})
        Me.CMenuStripAnhang.Name = "CMenuStripAnhang"
        Me.CMenuStripAnhang.Size = New System.Drawing.Size(170, 48)
        '
        '_contListeAnhang_Toolbars_Dock_Area_Left
        '
        Me._contListeAnhang_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contListeAnhang_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contListeAnhang_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contListeAnhang_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contListeAnhang_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 28)
        Me._contListeAnhang_Toolbars_Dock_Area_Left.Name = "_contListeAnhang_Toolbars_Dock_Area_Left"
        Me._contListeAnhang_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 282)
        Me._contListeAnhang_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contListeAnhang_Toolbars_Dock_Area_Right
        '
        Me._contListeAnhang_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contListeAnhang_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contListeAnhang_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contListeAnhang_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contListeAnhang_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(317, 28)
        Me._contListeAnhang_Toolbars_Dock_Area_Right.Name = "_contListeAnhang_Toolbars_Dock_Area_Right"
        Me._contListeAnhang_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 282)
        Me._contListeAnhang_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contListeAnhang_Toolbars_Dock_Area_Top
        '
        Me._contListeAnhang_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contListeAnhang_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contListeAnhang_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contListeAnhang_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contListeAnhang_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contListeAnhang_Toolbars_Dock_Area_Top.Name = "_contListeAnhang_Toolbars_Dock_Area_Top"
        Me._contListeAnhang_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(317, 28)
        Me._contListeAnhang_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contListeAnhang_Toolbars_Dock_Area_Bottom
        '
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 310)
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.Name = "_contListeAnhang_Toolbars_Dock_Area_Bottom"
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(317, 0)
        Me._contListeAnhang_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        Me.UltraToolbarsManager1.LockToolbars = True
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager1.ShowQuickCustomizeButton = False
        Me.UltraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        ButtonTool1.SharedProps.Caption = "In Zwischenablage kopieren"
        ButtonTool1.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance23.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32)
        ButtonTool2.SharedProps.AppearancesLarge.Appearance = Appearance23
        Appearance22.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32)
        ButtonTool2.SharedProps.AppearancesSmall.Appearance = Appearance22
        ButtonTool2.SharedProps.Caption = "Anhang löschen"
        ButtonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2})
        '
        'DateiÖffnenToolStripMenuItem
        '
        Me.DateiÖffnenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Ordner, 32, 32)
        Me.DateiÖffnenToolStripMenuItem.Name = "DateiÖffnenToolStripMenuItem"
        Me.DateiÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DateiÖffnenToolStripMenuItem.Text = "Datei öffnen"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
        '
        'contListeAnhang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.listDateiAnhang)
        Me.Controls.Add(Me._contListeAnhang_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contListeAnhang_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contListeAnhang_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._contListeAnhang_Toolbars_Dock_Area_Bottom)
        Me.Name = "contListeAnhang"
        Me.Size = New System.Drawing.Size(317, 310)
        CType(Me.listDateiAnhang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripAnhang.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents listDateiAnhang As Infragistics.Win.UltraWinListView.UltraListView
    Friend WithEvents CMenuStripAnhang As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DateiÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _contListeAnhang_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contListeAnhang_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contListeAnhang_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contListeAnhang_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea

End Class
