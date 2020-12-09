<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class contSelectAbteilBereiche
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSelectSave = New QS2.Desktop.ControlManagment.BaseButton()
        Me.PanelCenter = New System.Windows.Forms.Panel()
        Me.treeAbtBereiche = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelTop.SuspendLayout()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        CType(Me.treeAbtBereiche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.txtSearch)
        Me.PanelTop.Controls.Add(Me.lblSearch)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(503, 31)
        Me.PanelTop.TabIndex = 3
        Me.PanelTop.Visible = False
        '
        'txtSearch
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackColorDisabled = System.Drawing.Color.White
        Appearance1.BackColorDisabled2 = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.ItalicAsString = "False"
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.FontData.StrikeoutAsString = "False"
        Appearance1.FontData.UnderlineAsString = "False"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtSearch.Appearance = Appearance1
        Me.txtSearch.AutoSize = False
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(46, 4)
        Me.txtSearch.MaxLength = 0
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(261, 23)
        Me.txtSearch.TabIndex = 422
        Me.txtSearch.Tag = "Vorname"
        '
        'lblSearch
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblSearch.Appearance = Appearance2
        Me.lblSearch.Location = New System.Drawing.Point(5, 7)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(49, 17)
        Me.lblSearch.TabIndex = 423
        Me.lblSearch.Tag = "ResID.Search"
        Me.lblSearch.Text = "Suche"
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnSelectSave)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 333)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(503, 34)
        Me.PanelBottom.TabIndex = 4
        '
        'btnSelectSave
        '
        Me.btnSelectSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSelectSave.Appearance = Appearance3
        Me.btnSelectSave.AutoWorkLayout = False
        Me.btnSelectSave.IsStandardControl = False
        Me.btnSelectSave.Location = New System.Drawing.Point(414, 3)
        Me.btnSelectSave.Name = "btnSelectSave"
        Me.btnSelectSave.Size = New System.Drawing.Size(79, 27)
        Me.btnSelectSave.TabIndex = 10
        Me.btnSelectSave.Tag = "ResID.OK"
        Me.btnSelectSave.Text = "OK"
        '
        'PanelCenter
        '
        Me.PanelCenter.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenter.Controls.Add(Me.treeAbtBereiche)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 31)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(503, 302)
        Me.PanelCenter.TabIndex = 5
        '
        'treeAbtBereiche
        '
        Me.treeAbtBereiche.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeAbtBereiche.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.treeAbtBereiche.ContextMenuStrip = Me.ContextMenuStrip1
        Me.treeAbtBereiche.Location = New System.Drawing.Point(5, 3)
        Me.treeAbtBereiche.Name = "treeAbtBereiche"
        Override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.SelectNodeOnly
        Override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
        Me.treeAbtBereiche.Override = Override1
        Me.treeAbtBereiche.Size = New System.Drawing.Size(493, 295)
        Me.treeAbtBereiche.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(503, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 367)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'contSelectAbteilBereiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PanelCenter)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top)
        Me.Name = "contSelectAbteilBereiche"
        Me.Size = New System.Drawing.Size(503, 367)
        Me.PanelTop.ResumeLayout(False)
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        CType(Me.treeAbtBereiche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As Windows.Forms.Panel
    Friend WithEvents PanelBottom As Windows.Forms.Panel
    Friend WithEvents PanelCenter As Windows.Forms.Panel
    Public WithEvents btnSelectSave As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Public WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents treeAbtBereiche As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
End Class
