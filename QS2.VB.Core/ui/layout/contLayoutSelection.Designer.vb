<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contLayoutSelection
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
        Me.PanelComboLayout = New System.Windows.Forms.Panel()
        Me.btnRefresh = New Infragistics.Win.Misc.UltraButton()
        Me.btnNewLayout = New Infragistics.Win.Misc.UltraButton()
        Me.btnDeleteLayout = New Infragistics.Win.Misc.UltraButton()
        Me.CboLayout1 = New qs2.core.vb.cboLayout()
        Me.CompLayout1 = New qs2.core.vb.compLayout(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DsLayout1 = New qs2.core.vb.dsLayout()
        Me.PanelComboLayout.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsLayout1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelComboLayout
        '
        Me.PanelComboLayout.BackColor = System.Drawing.Color.Transparent
        Me.PanelComboLayout.Controls.Add(Me.btnRefresh)
        Me.PanelComboLayout.Controls.Add(Me.btnNewLayout)
        Me.PanelComboLayout.Controls.Add(Me.btnDeleteLayout)
        Me.PanelComboLayout.Controls.Add(Me.CboLayout1)
        Me.PanelComboLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelComboLayout.Location = New System.Drawing.Point(0, 0)
        Me.PanelComboLayout.Name = "PanelComboLayout"
        Me.PanelComboLayout.Size = New System.Drawing.Size(516, 27)
        Me.PanelComboLayout.TabIndex = 5
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnRefresh.Appearance = Appearance1
        Me.btnRefresh.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefresh.Location = New System.Drawing.Point(442, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(22, 21)
        Me.btnRefresh.TabIndex = 0
        '
        'btnNewLayout
        '
        Me.btnNewLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnNewLayout.Appearance = Appearance2
        Me.btnNewLayout.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnNewLayout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNewLayout.Location = New System.Drawing.Point(468, 3)
        Me.btnNewLayout.Name = "btnNewLayout"
        Me.btnNewLayout.Size = New System.Drawing.Size(22, 21)
        Me.btnNewLayout.TabIndex = 1
        '
        'btnDeleteLayout
        '
        Me.btnDeleteLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDeleteLayout.Appearance = Appearance3
        Me.btnDeleteLayout.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnDeleteLayout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDeleteLayout.Location = New System.Drawing.Point(490, 3)
        Me.btnDeleteLayout.Name = "btnDeleteLayout"
        Me.btnDeleteLayout.Size = New System.Drawing.Size(22, 21)
        Me.btnDeleteLayout.TabIndex = 2
        '
        'CboLayout1
        '
        Me.CboLayout1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CboLayout1.Location = New System.Drawing.Point(3, -1)
        Me.CboLayout1.Name = "CboLayout1"
        Me.CboLayout1.Size = New System.Drawing.Size(441, 25)
        Me.CboLayout1.TabIndex = 0
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DsLayout1
        '
        Me.DsLayout1.DataSetName = "dsLayout"
        Me.DsLayout1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'contLayoutSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PanelComboLayout)
        Me.Name = "contLayoutSelection"
        Me.Size = New System.Drawing.Size(516, 27)
        Me.PanelComboLayout.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsLayout1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents PanelComboLayout As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnNewLayout As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDeleteLayout As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CompLayout1 As qs2.core.vb.compLayout
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DsLayout1 As qs2.core.vb.dsLayout
    Public WithEvents CboLayout1 As qs2.core.vb.cboLayout

End Class
