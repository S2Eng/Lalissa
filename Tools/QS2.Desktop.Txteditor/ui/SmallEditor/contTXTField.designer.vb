Partial Class contTXTField
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not disposing AndAlso (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contTXTField))
        Me.contextMenuStripSpell = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.sampleItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSpellChecking = New System.Windows.Forms.Button()
        Me.PanelAll = New System.Windows.Forms.Panel()
        Me.StatusBar2 = New TXTextControl.StatusBar()
        Me.TXTControlField = New TXTextControl.TextControl()
        Me.rulerBar1 = New TXTextControl.RulerBar()
        Me.rulerBar2 = New TXTextControl.RulerBar()
        Me.buttonBarFormat = New TXTextControl.ButtonBar()
        Me.toolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.toolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtonOpen = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparatorSaveDB = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripButtonCut = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtonCopy = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtonPaste = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripButtonUndo = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtonRedo = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButtoSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparatorSpaceLang = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripButtonLanguages = New System.Windows.Forms.ToolStripButton()
        Me.contextMenuStripSpell.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.PanelAll.SuspendLayout()
        Me.toolStripButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'contextMenuStripSpell
        '
        Me.contextMenuStripSpell.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sampleItemToolStripMenuItem})
        Me.contextMenuStripSpell.Name = "contextMenuStrip1"
        Me.contextMenuStripSpell.Size = New System.Drawing.Size(141, 26)
        '
        'sampleItemToolStripMenuItem
        '
        Me.sampleItemToolStripMenuItem.Name = "sampleItemToolStripMenuItem"
        Me.sampleItemToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.sampleItemToolStripMenuItem.Text = "Sample Item"
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnSpellChecking)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 380)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1052, 26)
        Me.PanelBottom.TabIndex = 10
        Me.PanelBottom.Visible = False
        '
        'btnSpellChecking
        '
        Me.btnSpellChecking.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSpellChecking.Location = New System.Drawing.Point(931, 2)
        Me.btnSpellChecking.Name = "btnSpellChecking"
        Me.btnSpellChecking.Size = New System.Drawing.Size(115, 21)
        Me.btnSpellChecking.TabIndex = 0
        Me.btnSpellChecking.Text = "Rechtschreibprüfung"
        Me.btnSpellChecking.UseVisualStyleBackColor = True
        Me.btnSpellChecking.Visible = False
        '
        'PanelAll
        '
        Me.PanelAll.BackColor = System.Drawing.Color.Transparent
        Me.PanelAll.Controls.Add(Me.StatusBar2)
        Me.PanelAll.Controls.Add(Me.TXTControlField)
        Me.PanelAll.Controls.Add(Me.rulerBar1)
        Me.PanelAll.Controls.Add(Me.rulerBar2)
        Me.PanelAll.Controls.Add(Me.buttonBarFormat)
        Me.PanelAll.Controls.Add(Me.toolStripButtons)
        Me.PanelAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAll.Location = New System.Drawing.Point(0, 0)
        Me.PanelAll.Name = "PanelAll"
        Me.PanelAll.Size = New System.Drawing.Size(1052, 380)
        Me.PanelAll.TabIndex = 11
        '
        'StatusBar2
        '
        Me.StatusBar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusBar2.BackColor = System.Drawing.SystemColors.Control
        Me.StatusBar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar2.ForeColor = System.Drawing.Color.DimGray
        Me.StatusBar2.Location = New System.Drawing.Point(845, 2)
        Me.StatusBar2.Name = "StatusBar2"
        Me.StatusBar2.ShowColumn = False
        Me.StatusBar2.ShowKeyStates = False
        Me.StatusBar2.ShowLine = False
        Me.StatusBar2.ShowPage = False
        Me.StatusBar2.ShowPageCounter = False
        Me.StatusBar2.ShowSection = False
        Me.StatusBar2.ShowSectionCounter = False
        Me.StatusBar2.ShowZoom = False
        Me.StatusBar2.ShowZoomTrackBar = False
        Me.StatusBar2.Size = New System.Drawing.Size(202, 19)
        Me.StatusBar2.TabIndex = 16
        '
        'TXTControlField
        '
        Me.TXTControlField.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXTControlField.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TXTControlField.IsHyphenationEnabled = True
        Me.TXTControlField.IsSpellCheckingEnabled = True
        Me.TXTControlField.Location = New System.Drawing.Point(25, 78)
        Me.TXTControlField.Name = "TXTControlField"
        Me.TXTControlField.Size = New System.Drawing.Size(1027, 302)
        Me.TXTControlField.TabIndex = 15
        Me.TXTControlField.ViewMode = TXTextControl.ViewMode.SimpleControl
        '
        'rulerBar1
        '
        Me.rulerBar1.Alignment = TXTextControl.RulerBarAlignment.Left
        Me.rulerBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.rulerBar1.Location = New System.Drawing.Point(0, 78)
        Me.rulerBar1.Name = "rulerBar1"
        Me.rulerBar1.Size = New System.Drawing.Size(25, 302)
        Me.rulerBar1.TabIndex = 14
        Me.rulerBar1.Text = "rulerBar1"
        Me.rulerBar1.Visible = False
        '
        'rulerBar2
        '
        Me.rulerBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.rulerBar2.Location = New System.Drawing.Point(0, 53)
        Me.rulerBar2.Name = "rulerBar2"
        Me.rulerBar2.Size = New System.Drawing.Size(1052, 25)
        Me.rulerBar2.TabIndex = 13
        Me.rulerBar2.Text = "rulerBar2"
        Me.rulerBar2.Visible = False
        '
        'buttonBarFormat
        '
        Me.buttonBarFormat.BackColor = System.Drawing.SystemColors.Control
        Me.buttonBarFormat.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonBarFormat.Location = New System.Drawing.Point(0, 25)
        Me.buttonBarFormat.Name = "buttonBarFormat"
        Me.buttonBarFormat.Size = New System.Drawing.Size(1052, 28)
        Me.buttonBarFormat.TabIndex = 12
        Me.buttonBarFormat.Text = "buttonBar1"
        '
        'toolStripButtons
        '
        Me.toolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonNew, Me.toolStripButtonOpen, Me.toolStripButtonSave, Me.ToolStripSeparatorSaveDB, Me.ToolStripButtonPrint, Me.toolStripSeparator2, Me.toolStripButtonCut, Me.toolStripButtonCopy, Me.toolStripButtonPaste, Me.toolStripSeparator3, Me.toolStripButtonUndo, Me.toolStripButtonRedo, Me.toolStripButtoSearch, Me.ToolStripSeparatorSpaceLang, Me.toolStripButtonLanguages})
        Me.toolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolStripButtons.Name = "toolStripButtons"
        Me.toolStripButtons.Size = New System.Drawing.Size(1052, 25)
        Me.toolStripButtons.TabIndex = 11
        '
        'toolStripButtonNew
        '
        Me.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonNew.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.newpage
        Me.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonNew.Name = "toolStripButtonNew"
        Me.toolStripButtonNew.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonNew.Tag = "ResID.NewDocument"
        Me.toolStripButtonNew.Text = "toolStripButton1"
        Me.toolStripButtonNew.ToolTipText = "Neues Dokument"
        '
        'toolStripButtonOpen
        '
        Me.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonOpen.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.open
        Me.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonOpen.Name = "toolStripButtonOpen"
        Me.toolStripButtonOpen.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonOpen.Tag = "ResID.OpenDocument"
        Me.toolStripButtonOpen.Text = "toolStripButton2"
        Me.toolStripButtonOpen.ToolTipText = "Dokument öffnen"
        '
        'toolStripButtonSave
        '
        Me.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonSave.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.save
        Me.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonSave.Name = "toolStripButtonSave"
        Me.toolStripButtonSave.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonSave.Tag = "ResID.SaveDocument"
        Me.toolStripButtonSave.Text = "toolStripButton3"
        Me.toolStripButtonSave.ToolTipText = "Dokument speichern"
        '
        'ToolStripSeparatorSaveDB
        '
        Me.ToolStripSeparatorSaveDB.Name = "ToolStripSeparatorSaveDB"
        Me.ToolStripSeparatorSaveDB.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonPrint
        '
        Me.ToolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPrint.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.print
        Me.ToolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPrint.Name = "ToolStripButtonPrint"
        Me.ToolStripButtonPrint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonPrint.Tag = "ResID.PrintDocument"
        Me.ToolStripButtonPrint.Text = "toolStripButton4"
        Me.ToolStripButtonPrint.ToolTipText = "Dokument drucken"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripButtonCut
        '
        Me.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonCut.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.cut
        Me.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonCut.Name = "toolStripButtonCut"
        Me.toolStripButtonCut.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonCut.Tag = "ResID.Cut"
        Me.toolStripButtonCut.Text = "toolStripButton6"
        Me.toolStripButtonCut.ToolTipText = "Ausschneiden"
        '
        'toolStripButtonCopy
        '
        Me.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonCopy.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.copy
        Me.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonCopy.Name = "toolStripButtonCopy"
        Me.toolStripButtonCopy.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonCopy.Tag = "ResID.Copy"
        Me.toolStripButtonCopy.Text = "toolStripButton7"
        Me.toolStripButtonCopy.ToolTipText = "Kopieren"
        '
        'toolStripButtonPaste
        '
        Me.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonPaste.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.paste
        Me.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonPaste.Name = "toolStripButtonPaste"
        Me.toolStripButtonPaste.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonPaste.Tag = "ResID.Paste"
        Me.toolStripButtonPaste.Text = "toolStripButton8"
        Me.toolStripButtonPaste.ToolTipText = "Einfügen"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripButtonUndo
        '
        Me.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonUndo.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.undo
        Me.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonUndo.Name = "toolStripButtonUndo"
        Me.toolStripButtonUndo.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonUndo.Tag = "ResID.Undo"
        Me.toolStripButtonUndo.Text = "toolStripButton10"
        Me.toolStripButtonUndo.ToolTipText = "Rückgängig machen"
        '
        'toolStripButtonRedo
        '
        Me.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonRedo.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.redo
        Me.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonRedo.Name = "toolStripButtonRedo"
        Me.toolStripButtonRedo.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonRedo.Tag = "ResID.Restore"
        Me.toolStripButtonRedo.Text = "toolStripButton11"
        Me.toolStripButtonRedo.ToolTipText = "Wiederherstellen"
        '
        'toolStripButtoSearch
        '
        Me.toolStripButtoSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtoSearch.Image = Global.QS2.Desktop.Txteditor.My.Resources.Resources.find
        Me.toolStripButtoSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtoSearch.Name = "toolStripButtoSearch"
        Me.toolStripButtoSearch.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtoSearch.Tag = "ResID.Search"
        Me.toolStripButtoSearch.Text = "toolStripButton12"
        Me.toolStripButtoSearch.ToolTipText = "Suchen"
        '
        'ToolStripSeparatorSpaceLang
        '
        Me.ToolStripSeparatorSpaceLang.Name = "ToolStripSeparatorSpaceLang"
        Me.ToolStripSeparatorSpaceLang.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripButtonLanguages
        '
        Me.toolStripButtonLanguages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonLanguages.Image = CType(resources.GetObject("toolStripButtonLanguages.Image"), System.Drawing.Image)
        Me.toolStripButtonLanguages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonLanguages.Name = "toolStripButtonLanguages"
        Me.toolStripButtonLanguages.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonLanguages.Text = "Languages"
        '
        'contTXTField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelAll)
        Me.Controls.Add(Me.PanelBottom)
        Me.DoubleBuffered = True
        Me.Name = "contTXTField"
        Me.Size = New System.Drawing.Size(1052, 406)
        Me.contextMenuStripSpell.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelAll.ResumeLayout(False)
        Me.PanelAll.PerformLayout()
        Me.toolStripButtons.ResumeLayout(False)
        Me.toolStripButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Friend WithEvents contextMenuStripSpell As System.Windows.Forms.ContextMenuStrip
    Private WithEvents sampleItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelAll As System.Windows.Forms.Panel

    Public WithEvents TXTControlField As TXTextControl.TextControl
    Public WithEvents rulerBar1 As TXTextControl.RulerBar
    Public WithEvents rulerBar2 As TXTextControl.RulerBar
    Public WithEvents buttonBarFormat As TXTextControl.ButtonBar
    Public WithEvents toolStripButtons As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripButtonNew As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtonOpen As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtonSave As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparatorSaveDB As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripButtonPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripButtonCut As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtonCopy As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtonPaste As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripButtonUndo As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtonRedo As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButtoSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSpellChecking As System.Windows.Forms.Button
    Friend WithEvents toolStripButtonLanguages As Windows.Forms.ToolStripButton
    Friend WithEvents StatusBar2 As TXTextControl.StatusBar
    Friend WithEvents ToolStripSeparatorSpaceLang As Windows.Forms.ToolStripSeparator
End Class

