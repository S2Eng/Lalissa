<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayoutManager
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.ContLayoutGrid1 = New qs2.core.vb.contLayoutManager()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.ContLayoutGrid1)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(964, 535)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'ContLayoutGrid1
        '
        Me.ContLayoutGrid1.BackColor = System.Drawing.Color.Transparent
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.ContLayoutGrid1, GridBagConstraint1)
        Me.ContLayoutGrid1.Location = New System.Drawing.Point(0, 0)
        Me.ContLayoutGrid1.Name = "ContLayoutGrid1"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.ContLayoutGrid1, New System.Drawing.Size(754, 217))
        Me.ContLayoutGrid1.Size = New System.Drawing.Size(964, 535)
        Me.ContLayoutGrid1.TabIndex = 0
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(964, 535)
        Me.PanelGrid.TabIndex = 4
        '
        'frmLayoutManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(964, 535)
        Me.Controls.Add(Me.PanelGrid)
        Me.Name = "frmLayoutManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Layout Grid"
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Public WithEvents ContLayoutGrid1 As contLayoutManager
End Class
