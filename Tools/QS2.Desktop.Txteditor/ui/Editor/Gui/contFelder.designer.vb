<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contFelder
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Einfügen")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ListeFelder")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar2")
        Dim PopupMenuTool3 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpHervorheben")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ListeFelder")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hervorheben")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("HervorhebenZurücksetzen")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpHervorheben")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hervorheben")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("HervorhebenZurücksetzen")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Einfügen")
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.uExpFelder = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar()
        Me.contFelder_Fill_Panel = New System.Windows.Forms.Panel()
        Me._contFelder_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._contFelder_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contFelder_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contFelder_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.uExpFelder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contFelder_Fill_Panel.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.uExpFelder)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(256, 517)
        Me.UltraGridBagLayoutPanel1.TabIndex = 6
        '
        'uExpFelder
        '
        Me.uExpFelder.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 10
        GridBagConstraint1.Insets.Left = 10
        GridBagConstraint1.Insets.Right = 10
        GridBagConstraint1.Insets.Top = 10
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.uExpFelder, GridBagConstraint1)
        Me.uExpFelder.GroupSettings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid
        Me.uExpFelder.GroupSettings.HeaderButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.uExpFelder.GroupSettings.ItemAreaInnerMargins.Bottom = 0
        Me.uExpFelder.GroupSettings.ItemAreaInnerMargins.Left = 0
        Me.uExpFelder.GroupSettings.ItemAreaInnerMargins.Right = 0
        Me.uExpFelder.GroupSettings.ItemAreaInnerMargins.Top = 0
        Me.uExpFelder.GroupSettings.ItemAreaOuterMargins.Bottom = 0
        Me.uExpFelder.GroupSettings.ItemAreaOuterMargins.Left = 0
        Me.uExpFelder.GroupSettings.ItemAreaOuterMargins.Right = 0
        Me.uExpFelder.GroupSettings.ItemAreaOuterMargins.Top = 0
        Me.uExpFelder.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText
        Me.uExpFelder.GroupSpacing = 0
        Me.uExpFelder.Location = New System.Drawing.Point(10, 10)
        Me.uExpFelder.Name = "uExpFelder"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.uExpFelder, New System.Drawing.Size(73, 137))
        Me.uExpFelder.Size = New System.Drawing.Size(236, 497)
        Me.uExpFelder.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox
        Me.uExpFelder.TabIndex = 0
        Me.uExpFelder.UseAppStyling = False
        Me.uExpFelder.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.uExpFelder.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XP
        '
        'contFelder_Fill_Panel
        '
        Me.contFelder_Fill_Panel.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.contFelder_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.contFelder_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contFelder_Fill_Panel.Location = New System.Drawing.Point(0, 46)
        Me.contFelder_Fill_Panel.Name = "contFelder_Fill_Panel"
        Me.contFelder_Fill_Panel.Size = New System.Drawing.Size(256, 517)
        Me.contFelder_Fill_Panel.TabIndex = 0
        '
        '_contFelder_Toolbars_Dock_Area_Left
        '
        Me._contFelder_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contFelder_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._contFelder_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contFelder_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contFelder_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 46)
        Me._contFelder_Toolbars_Dock_Area_Left.Name = "_contFelder_Toolbars_Dock_Area_Left"
        Me._contFelder_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 517)
        Me._contFelder_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        Me.UltraToolbarsManager1.LockToolbars = True
        Me.UltraToolbarsManager1.Office2007UICompatibility = False
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager1.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool6})
        UltraToolbar1.Text = "UltraToolbar1"
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 1
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool3})
        UltraToolbar2.Text = "UltraToolbar2"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1, UltraToolbar2})
        ButtonTool1.SharedPropsInternal.Caption = "Liste Felder"
        ButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool1.SharedPropsInternal.ToolTipTextFormatted = "Liste aller verwendeten Felder im Dokument bzw. suchen von Feldern im Dokument.<b" &
    "r/>"
        ButtonTool1.SharedPropsInternal.ToolTipTitle = "Liste Felder"
        ButtonTool1.Tag = "ResID.ListFields"
        ButtonTool2.SharedPropsInternal.Caption = "Hervorheben"
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool2.SharedPropsInternal.ToolTipText = "Farbliches hervorheben von Feldern im Dokument."
        ButtonTool2.SharedPropsInternal.ToolTipTitle = "Hervorheben von Feldern"
        ButtonTool2.Tag = "ResID.FieldsHighlight"
        ButtonTool3.SharedPropsInternal.Caption = "Hervorheben zurücksetzen"
        ButtonTool3.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool3.SharedPropsInternal.ToolTipText = "Hervorheben von Feldern im Dokument wieder zurücksetzen."
        ButtonTool3.SharedPropsInternal.ToolTipTitle = "Hervorheben von Feldern zurücksetzen"
        ButtonTool3.Tag = "ResID.ResetHighlighting"
        PopupMenuTool1.SharedPropsInternal.Caption = "Hervorheben"
        PopupMenuTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        PopupMenuTool1.SharedPropsInternal.ToolTipTextFormatted = "Farbliches hervorheben von verwendeten Feldern im Dokument."
        PopupMenuTool1.SharedPropsInternal.ToolTipTitle = "Felder hervorheben"
        PopupMenuTool1.Tag = "ResID.Highlighting"
        PopupMenuTool1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4, ButtonTool5})
        ButtonTool8.SharedPropsInternal.Caption = "Einfügen"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool8.Tag = "ResID.Insert"
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, PopupMenuTool1, ButtonTool8})
        '
        '_contFelder_Toolbars_Dock_Area_Right
        '
        Me._contFelder_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contFelder_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._contFelder_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contFelder_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contFelder_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(256, 46)
        Me._contFelder_Toolbars_Dock_Area_Right.Name = "_contFelder_Toolbars_Dock_Area_Right"
        Me._contFelder_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 517)
        Me._contFelder_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contFelder_Toolbars_Dock_Area_Top
        '
        Me._contFelder_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contFelder_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._contFelder_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contFelder_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contFelder_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contFelder_Toolbars_Dock_Area_Top.Name = "_contFelder_Toolbars_Dock_Area_Top"
        Me._contFelder_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(256, 46)
        Me._contFelder_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contFelder_Toolbars_Dock_Area_Bottom
        '
        Me._contFelder_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contFelder_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._contFelder_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contFelder_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contFelder_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 563)
        Me._contFelder_Toolbars_Dock_Area_Bottom.Name = "_contFelder_Toolbars_Dock_Area_Bottom"
        Me._contFelder_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(256, 0)
        Me._contFelder_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contFelder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.contFelder_Fill_Panel)
        Me.Controls.Add(Me._contFelder_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contFelder_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contFelder_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contFelder_Toolbars_Dock_Area_Top)
        Me.DoubleBuffered = True
        Me.Name = "contFelder"
        Me.Size = New System.Drawing.Size(256, 563)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.uExpFelder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contFelder_Fill_Panel.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents uExpFelder As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents contFelder_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _contFelder_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contFelder_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contFelder_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contFelder_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager

End Class
