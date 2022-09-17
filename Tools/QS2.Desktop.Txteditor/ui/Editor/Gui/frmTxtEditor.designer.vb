<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTxtEditor
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTxtEditor))
        Me.PanelEditor = New System.Windows.Forms.Panel()
        Me.ContTxtEditor1 = New QS2.Desktop.Txteditor.contTxtEditor()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.lblProtocol = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelEditor.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEditor
        '
        Me.PanelEditor.Controls.Add(Me.ContTxtEditor1)
        Me.PanelEditor.Controls.Add(Me.PanelBottom)
        Me.PanelEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelEditor.Name = "PanelEditor"
        Me.PanelEditor.Size = New System.Drawing.Size(841, 632)
        Me.PanelEditor.TabIndex = 0
        '
        'ContTxtEditor1
        '
        Me.ContTxtEditor1.AllowDrop = True
        Me.ContTxtEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContTxtEditor1.ISTOSAVE = False
        Me.ContTxtEditor1.Location = New System.Drawing.Point(0, 0)
        Me.ContTxtEditor1.Name = "ContTxtEditor1"
        Me.ContTxtEditor1.Size = New System.Drawing.Size(841, 606)
        Me.ContTxtEditor1.TabIndex = 245
        Me.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.lblProtocol)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 606)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(841, 26)
        Me.PanelBottom.TabIndex = 244
        Me.PanelBottom.Visible = False
        '
        'lblProtocol
        '
        Me.lblProtocol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.BackColor2 = System.Drawing.Color.Transparent
        Appearance1.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance1.FontData.SizeInPoints = 10.0!
        Appearance1.FontData.UnderlineAsString = "False"
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.lblProtocol.Appearance = Appearance1
        Me.lblProtocol.AutoSize = True
        Appearance2.FontData.UnderlineAsString = "True"
        Appearance2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblProtocol.HotTrackAppearance = Appearance2
        Me.lblProtocol.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProtocol.Location = New System.Drawing.Point(751, 4)
        Me.lblProtocol.Name = "lblProtocol"
        Me.lblProtocol.Size = New System.Drawing.Size(42, 17)
        Me.lblProtocol.TabIndex = 242
        Me.lblProtocol.Text = "Errors"
        Me.lblProtocol.UseAppStyling = False
        Me.lblProtocol.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.lblProtocol.Visible = False
        '
        'frmTxtEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(841, 632)
        Me.Controls.Add(Me.PanelEditor)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(857, 668)
        Me.Name = "frmTxtEditor"
        Me.Text = "Texteditor"
        Me.PanelEditor.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEditor As System.Windows.Forms.Panel
    Public WithEvents PanelBottom As System.Windows.Forms.Panel
    Public WithEvents lblProtocol As Infragistics.Win.Misc.UltraLabel
    Public WithEvents ContTxtEditor1 As contTxtEditor
End Class
