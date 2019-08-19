<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contBenPostfächer
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
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttLadenBenutzer")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichernBenutzer")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttLadenBenutzer")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contBenPostfächer))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichernBenutzer")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UTreeBenutzer = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.ContextMenuStripBenutzer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleBenutzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineBenutzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MichAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.contBenPostfächer_Fill_Panel = New System.Windows.Forms.Panel()
        Me._contBenPostfächer_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contBenPostfächer_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contBenPostfächer_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.UTreeBenutzer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripBenutzer.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contBenPostfächer_Fill_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UTreeBenutzer
        '
        Me.UTreeBenutzer.ContextMenuStrip = Me.ContextMenuStripBenutzer
        Me.UTreeBenutzer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UTreeBenutzer.Location = New System.Drawing.Point(0, 0)
        Me.UTreeBenutzer.Name = "UTreeBenutzer"
        Override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
        Me.UTreeBenutzer.Override = Override1
        Me.UTreeBenutzer.Size = New System.Drawing.Size(224, 232)
        Me.UTreeBenutzer.TabIndex = 0
        '
        'ContextMenuStripBenutzer
        '
        Me.ContextMenuStripBenutzer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleBenutzerToolStripMenuItem, Me.KeineBenutzerToolStripMenuItem, Me.ToolStripMenuItem1, Me.MichAuswählenToolStripMenuItem})
        Me.ContextMenuStripBenutzer.Name = "ContextMenuStripBenutzer"
        Me.ContextMenuStripBenutzer.Size = New System.Drawing.Size(273, 76)
        '
        'AlleBenutzerToolStripMenuItem
        '
        Me.AlleBenutzerToolStripMenuItem.Name = "AlleBenutzerToolStripMenuItem"
        Me.AlleBenutzerToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.AlleBenutzerToolStripMenuItem.Text = "Alle Benutzer ..."
        '
        'KeineBenutzerToolStripMenuItem
        '
        Me.KeineBenutzerToolStripMenuItem.Name = "KeineBenutzerToolStripMenuItem"
        Me.KeineBenutzerToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.KeineBenutzerToolStripMenuItem.Text = "Keine Benutzer ..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(269, 6)
        '
        'MichAuswählenToolStripMenuItem
        '
        Me.MichAuswählenToolStripMenuItem.Name = "MichAuswählenToolStripMenuItem"
        Me.MichAuswählenToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.MichAuswählenToolStripMenuItem.Text = "Angemeldeten Benutzer auswählen ..."
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
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3, ButtonTool4})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesLarge.Appearance = Appearance1
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        ButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool1.SharedPropsInternal.ToolTipTextFormatted = "Benutzerauswahl aus Datei laden"
        ButtonTool1.SharedPropsInternal.ToolTipTitle = "Laden"
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        ButtonTool2.SharedPropsInternal.AppearancesLarge.Appearance = Appearance3
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        ButtonTool2.SharedPropsInternal.AppearancesSmall.Appearance = Appearance4
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool2.SharedPropsInternal.ToolTipTextFormatted = "Benutzerauswahl aus Datei speichern"
        ButtonTool2.SharedPropsInternal.ToolTipTitle = "Speichern"
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2})
        '
        'contBenPostfächer_Fill_Panel
        '
        Me.contBenPostfächer_Fill_Panel.Controls.Add(Me.UTreeBenutzer)
        Me.contBenPostfächer_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.contBenPostfächer_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contBenPostfächer_Fill_Panel.Location = New System.Drawing.Point(0, 28)
        Me.contBenPostfächer_Fill_Panel.Name = "contBenPostfächer_Fill_Panel"
        Me.contBenPostfächer_Fill_Panel.Size = New System.Drawing.Size(224, 232)
        Me.contBenPostfächer_Fill_Panel.TabIndex = 0
        '
        '_contBenPostfächer_Toolbars_Dock_Area_Left
        '
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 28)
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.Name = "_contBenPostfächer_Toolbars_Dock_Area_Left"
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 232)
        Me._contBenPostfächer_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contBenPostfächer_Toolbars_Dock_Area_Right
        '
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(224, 28)
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.Name = "_contBenPostfächer_Toolbars_Dock_Area_Right"
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 232)
        Me._contBenPostfächer_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contBenPostfächer_Toolbars_Dock_Area_Top
        '
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.Name = "_contBenPostfächer_Toolbars_Dock_Area_Top"
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(224, 28)
        Me._contBenPostfächer_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contBenPostfächer_Toolbars_Dock_Area_Bottom
        '
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 260)
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.Name = "_contBenPostfächer_Toolbars_Dock_Area_Bottom"
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(224, 0)
        Me._contBenPostfächer_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ICO_sachbearbeiterverwaltung.ico")
        '
        'contBenPostfächer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.contBenPostfächer_Fill_Panel)
        Me.Controls.Add(Me._contBenPostfächer_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contBenPostfächer_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contBenPostfächer_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contBenPostfächer_Toolbars_Dock_Area_Top)
        Me.Name = "contBenPostfächer"
        Me.Size = New System.Drawing.Size(224, 260)
        CType(Me.UTreeBenutzer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripBenutzer.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contBenPostfächer_Fill_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UTreeBenutzer As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents contBenPostfächer_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _contBenPostfächer_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contBenPostfächer_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contBenPostfächer_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contBenPostfächer_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStripBenutzer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleBenutzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineBenutzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MichAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
