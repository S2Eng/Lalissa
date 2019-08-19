<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOffeneTermine
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Termin öffnen", Infragistics.Win.ToolTipImage.[Default], "Termin öffnen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Geben Sie einen Text ein nach dem Sie suchen wollen und drücken Sie Enter ...", Infragistics.Win.ToolTipImage.[Default], "Suche nach Betreff", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Termin abschließen", Infragistics.Win.ToolTipImage.[Default], "Termin abschließen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOffeneTermine))
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Liste der offenen Termine neu laden", Infragistics.Win.ToolTipImage.[Default], "Neu laden", Infragistics.Win.DefaultableBoolean.[Default])
        Me.GridTasks = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UButtonSchließen = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonTerminÖffnen = New Infragistics.Win.Misc.UltraButton()
        Me.lblListTermine = New Infragistics.Win.Misc.UltraLabel()
        Me.lblBetreffOffenTermine = New Infragistics.Win.Misc.UltraLabel()
        Me.txtSuche = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.UltraButtonAbschließen = New Infragistics.Win.Misc.UltraButton()
        Me.PanelUntenREchts = New System.Windows.Forms.Panel()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.UltraButtonAktualisieren = New Infragistics.Win.Misc.UltraButton()
        Me.PanelObenREchts = New System.Windows.Forms.Panel()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraGridBagLayoutPanelMitte = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.GridTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnten.SuspendLayout()
        Me.PanelUntenREchts.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.PanelObenREchts.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelMitte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelMitte.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridTasks
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.GridTasks.DisplayLayout.Appearance = Appearance1
        Me.GridTasks.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        Me.GridTasks.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridTasks.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.White
        Me.GridTasks.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.GridTasks.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.GridTasks.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.GridTasks.DisplayLayout.Override.ActiveRowAppearance = Appearance4
        Me.GridTasks.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.GridTasks.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.GridTasks.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanelMitte.SetGridBagConstraint(Me.GridTasks, GridBagConstraint1)
        Me.GridTasks.Location = New System.Drawing.Point(5, 0)
        Me.GridTasks.Name = "GridTasks"
        Me.UltraGridBagLayoutPanelMitte.SetPreferredSize(Me.GridTasks, New System.Drawing.Size(617, 277))
        Me.GridTasks.Size = New System.Drawing.Size(648, 277)
        Me.GridTasks.TabIndex = 0
        Me.GridTasks.Text = "UltraGrid1"
        '
        'UButtonSchließen
        '
        Me.UButtonSchließen.Location = New System.Drawing.Point(18, 2)
        Me.UButtonSchließen.Name = "UButtonSchließen"
        Me.UButtonSchließen.Size = New System.Drawing.Size(70, 24)
        Me.UButtonSchließen.TabIndex = 0
        Me.UButtonSchließen.Text = "Schließen"
        '
        'UButtonTerminÖffnen
        '
        Me.UButtonTerminÖffnen.Location = New System.Drawing.Point(5, 2)
        Me.UButtonTerminÖffnen.Name = "UButtonTerminÖffnen"
        Me.UButtonTerminÖffnen.Size = New System.Drawing.Size(88, 24)
        Me.UButtonTerminÖffnen.TabIndex = 0
        Me.UButtonTerminÖffnen.Text = "Termin öffnen"
        UltraToolTipInfo4.ToolTipText = "Ausgewählten Termin öffnen"
        UltraToolTipInfo4.ToolTipTitle = "Termin öffnen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonTerminÖffnen, UltraToolTipInfo4)
        '
        'lblListTermine
        '
        Me.lblListTermine.Location = New System.Drawing.Point(42, 20)
        Me.lblListTermine.Name = "lblListTermine"
        Me.lblListTermine.Size = New System.Drawing.Size(199, 16)
        Me.lblListTermine.TabIndex = 3
        Me.lblListTermine.Text = "Liste Ihrer offenen Termine"
        '
        'lblBetreffOffenTermine
        '
        Me.lblBetreffOffenTermine.Location = New System.Drawing.Point(5, 18)
        Me.lblBetreffOffenTermine.Name = "lblBetreffOffenTermine"
        Me.lblBetreffOffenTermine.Size = New System.Drawing.Size(55, 16)
        Me.lblBetreffOffenTermine.TabIndex = 5
        Me.lblBetreffOffenTermine.Text = "Betreff"
        '
        'txtSuche
        '
        Me.txtSuche.Location = New System.Drawing.Point(59, 14)
        Me.txtSuche.Name = "txtSuche"
        Me.txtSuche.Size = New System.Drawing.Size(142, 21)
        Me.txtSuche.TabIndex = 0
        UltraToolTipInfo2.ToolTipText = "Geben Sie einen Text ein nach dem Sie suchen wollen und drücken Sie Enter ..."
        UltraToolTipInfo2.ToolTipTitle = "Suche nach Betreff"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.txtSuche, UltraToolTipInfo2)
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.UltraButtonAbschließen)
        Me.PanelUnten.Controls.Add(Me.PanelUntenREchts)
        Me.PanelUnten.Controls.Add(Me.UButtonTerminÖffnen)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 316)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(658, 32)
        Me.PanelUnten.TabIndex = 1
        Me.PanelUnten.TabStop = True
        '
        'UltraButtonAbschließen
        '
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        Me.UltraButtonAbschließen.Appearance = Appearance6
        Me.UltraButtonAbschließen.Location = New System.Drawing.Point(93, 2)
        Me.UltraButtonAbschließen.Name = "UltraButtonAbschließen"
        Me.UltraButtonAbschließen.Size = New System.Drawing.Size(131, 24)
        Me.UltraButtonAbschließen.TabIndex = 1
        Me.UltraButtonAbschließen.Text = "Termin abschließen"
        UltraToolTipInfo3.ToolTipText = "Ausgewählten Termin abschließen"
        UltraToolTipInfo3.ToolTipTitle = "Termin abschließen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraButtonAbschließen, UltraToolTipInfo3)
        '
        'PanelUntenREchts
        '
        Me.PanelUntenREchts.Controls.Add(Me.UButtonSchließen)
        Me.PanelUntenREchts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelUntenREchts.Location = New System.Drawing.Point(565, 0)
        Me.PanelUntenREchts.Name = "PanelUntenREchts"
        Me.PanelUntenREchts.Size = New System.Drawing.Size(93, 32)
        Me.PanelUntenREchts.TabIndex = 2
        Me.PanelUntenREchts.TabStop = True
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.UltraButtonAktualisieren)
        Me.PanelTop.Controls.Add(Me.PanelObenREchts)
        Me.PanelTop.Controls.Add(Me.UltraPictureBox1)
        Me.PanelTop.Controls.Add(Me.lblListTermine)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(658, 39)
        Me.PanelTop.TabIndex = 0
        Me.PanelTop.TabStop = True
        '
        'UltraButtonAktualisieren
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.UltraButtonAktualisieren.Appearance = Appearance5
        Me.UltraButtonAktualisieren.Location = New System.Drawing.Point(245, 11)
        Me.UltraButtonAktualisieren.Name = "UltraButtonAktualisieren"
        Me.UltraButtonAktualisieren.Size = New System.Drawing.Size(27, 24)
        Me.UltraButtonAktualisieren.TabIndex = 1
        UltraToolTipInfo1.ToolTipText = "Liste der offenen Termine neu laden"
        UltraToolTipInfo1.ToolTipTitle = "Neu laden"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraButtonAktualisieren, UltraToolTipInfo1)
        '
        'PanelObenREchts
        '
        Me.PanelObenREchts.Controls.Add(Me.txtSuche)
        Me.PanelObenREchts.Controls.Add(Me.lblBetreffOffenTermine)
        Me.PanelObenREchts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelObenREchts.Location = New System.Drawing.Point(452, 0)
        Me.PanelObenREchts.Name = "PanelObenREchts"
        Me.PanelObenREchts.Size = New System.Drawing.Size(206, 39)
        Me.PanelObenREchts.TabIndex = 0
        Me.PanelObenREchts.TabStop = True
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Location = New System.Drawing.Point(5, 4)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.UltraPictureBox1.Size = New System.Drawing.Size(34, 33)
        Me.UltraPictureBox1.TabIndex = 2
        '
        'UltraGridBagLayoutPanelMitte
        '
        Me.UltraGridBagLayoutPanelMitte.Controls.Add(Me.GridTasks)
        Me.UltraGridBagLayoutPanelMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelMitte.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelMitte.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelMitte.Location = New System.Drawing.Point(0, 39)
        Me.UltraGridBagLayoutPanelMitte.Name = "UltraGridBagLayoutPanelMitte"
        Me.UltraGridBagLayoutPanelMitte.Size = New System.Drawing.Size(658, 277)
        Me.UltraGridBagLayoutPanelMitte.TabIndex = 10
        Me.UltraGridBagLayoutPanelMitte.TabStop = True
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmOffeneTermine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(658, 348)
        Me.Controls.Add(Me.UltraGridBagLayoutPanelMitte)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelUnten)
        Me.MinimumSize = New System.Drawing.Size(633, 336)
        Me.Name = "frmOffeneTermine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Erinnerung Termine"
        CType(Me.GridTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUntenREchts.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.PanelObenREchts.ResumeLayout(False)
        Me.PanelObenREchts.PerformLayout()
        CType(Me.UltraGridBagLayoutPanelMitte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelMitte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridTasks As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UButtonSchließen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonTerminÖffnen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents lblListTermine As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBetreffOffenTermine As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtSuche As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenREchts As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelObenREchts As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanelMitte As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents UltraButtonAbschließen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButtonAktualisieren As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
