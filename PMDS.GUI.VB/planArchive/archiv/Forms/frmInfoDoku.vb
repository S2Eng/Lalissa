
Imports System.Windows.Forms

Public Class frmInfoDoku
    Inherits System.Windows.Forms.Form

    Public gen As New GeneralArchiv()




#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents UltraToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _UGridGutschriften_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _UGridGutschriften_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _UGridGutschriften_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Public WithEvents TextInfoDatei2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents _UGridGutschriften_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("Aufgabe, Termin neu ...")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me._UGridGutschriften_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._UGridGutschriften_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._UGridGutschriften_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.TextInfoDatei2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInfoDatei2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_UGridGutschriften_Toolbars_Dock_Area_Top
        '
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.Name = "_UGridGutschriften_Toolbars_Dock_Area_Top"
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(363, 25)
        Me._UGridGutschriften_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager
        '
        'UltraToolbarsManager
        '
        Me.UltraToolbarsManager.DesignerFlags = 1
        Me.UltraToolbarsManager.DockWithinContainer = Me
        Me.UltraToolbarsManager.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager.LockToolbars = True
        Me.UltraToolbarsManager.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1})
        UltraToolbar1.Text = "Aufgabe, Termin neu ..."
        Me.UltraToolbarsManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool2.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance1
        ButtonTool2.SharedPropsInternal.Caption = "Schließen"
        ButtonTool2.SharedPropsInternal.CustomizerCaption = "Schließen"
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.UltraToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool2})
        '
        '_UGridGutschriften_Toolbars_Dock_Area_Bottom
        '
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 423)
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.Name = "_UGridGutschriften_Toolbars_Dock_Area_Bottom"
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(363, 0)
        Me._UGridGutschriften_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_UGridGutschriften_Toolbars_Dock_Area_Left
        '
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 25)
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.Name = "_UGridGutschriften_Toolbars_Dock_Area_Left"
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 398)
        Me._UGridGutschriften_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_UGridGutschriften_Toolbars_Dock_Area_Right
        '
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(363, 25)
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.Name = "_UGridGutschriften_Toolbars_Dock_Area_Right"
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 398)
        Me._UGridGutschriften_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager
        '
        'TextInfoDatei2
        '
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutManager1.SetGridBagConstraint(Me.TextInfoDatei2, GridBagConstraint1)
        Me.TextInfoDatei2.Location = New System.Drawing.Point(5, 5)
        Me.TextInfoDatei2.Multiline = True
        Me.TextInfoDatei2.Name = "TextInfoDatei2"
        Me.UltraGridBagLayoutManager1.SetPreferredSize(Me.TextInfoDatei2, New System.Drawing.Size(150, 206))
        Me.TextInfoDatei2.Size = New System.Drawing.Size(353, 413)
        Me.TextInfoDatei2.TabIndex = 1
        '
        'UltraGridBagLayoutManager1
        '
        Me.UltraGridBagLayoutManager1.ContainerControl = Me
        Me.UltraGridBagLayoutManager1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutManager1.ExpandToFitWidth = True
        '
        'frmInfoDoku
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(363, 423)
        Me.Controls.Add(Me.TextInfoDatei2)
        Me.Controls.Add(Me._UGridGutschriften_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._UGridGutschriften_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._UGridGutschriften_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._UGridGutschriften_Toolbars_Dock_Area_Top)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoDoku"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Information zum Dokument"
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInfoDatei2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub frmInfoDoku_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.TextInfoDatei2.SelectionStart = 0
            Me.TextInfoDatei2.SelectionLength = 0

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub InfoDatei_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager.ToolClick
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "Schließen"
                    Me.Close()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub InfoDatei_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    End Sub

    Private Sub TextInfoDatei_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextInfoDatei_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub TextInfoDatei2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextInfoDatei2.ValueChanged

    End Sub

End Class
