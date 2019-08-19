<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBiografie
    Inherits QS2.Desktop.ControlManagment.BaseControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucBiografie))
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Biografie hinzufügen", Infragistics.Win.ToolTipImage.[Default], "Hinzufügen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Biografie entfernen", Infragistics.Win.ToolTipImage.[Default], "Entfernen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Dokument wird ins Archiv in den Ordner 'Biografien' abgelegt", Infragistics.Win.ToolTipImage.[Default], "Ins Archiv als PDF ablegen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Als PDF sichern", Infragistics.Win.ToolTipImage.[Default], "PDF", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Liste der vorhandenen Biografien zum Klienten", Infragistics.Win.ToolTipImage.[Default], "Vorhandene Biografien", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Abbrechen und aktuelle Änderungen in der Biogafie verwerfen", Infragistics.Win.ToolTipImage.[Default], "Abbrechen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.PanelOben = New QS2.Desktop.ControlManagment.BasePanel()
        Me.PanelButtonMitte = New QS2.Desktop.ControlManagment.BasePanel()
        Me.PanelButtonRechts = New QS2.Desktop.ControlManagment.BasePanel()
        Me.PanelButtonOben2 = New QS2.Desktop.ControlManagment.BasePanel()
        Me.btnPlusxyxy = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnMinus = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnArchivAblegen = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnPrint = New QS2.Desktop.ControlManagment.BaseButton()
        Me.uDropDownButtVorhBiografien = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.PanelUnten = New QS2.Desktop.ControlManagment.BasePanel()
        Me.lblErstelltAm = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.lblErstelltVon = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.panelUntenRechts = New QS2.Desktop.ControlManagment.BasePanel()
        Me.btnSpeichern = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnAbbrechen = New QS2.Desktop.ControlManagment.BaseButton()
        Me.PanelEditor = New QS2.Desktop.ControlManagment.BasePanel()
        Me.UltraGridBagLayoutPanelEditor = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.PanelEditor2 = New QS2.Desktop.ControlManagment.BasePanel()
        Me.uPopupContContainerVorhBiografien = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.ultraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.PanelOben.SuspendLayout()
        Me.PanelButtonRechts.SuspendLayout()
        Me.PanelButtonOben2.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        Me.panelUntenRechts.SuspendLayout()
        Me.PanelEditor.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelOben
        '
        Me.PanelOben.Controls.Add(Me.PanelButtonMitte)
        Me.PanelOben.Controls.Add(Me.PanelButtonRechts)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(615, 37)
        Me.PanelOben.TabIndex = 0
        '
        'PanelButtonMitte
        '
        Me.PanelButtonMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelButtonMitte.Location = New System.Drawing.Point(0, 0)
        Me.PanelButtonMitte.Name = "PanelButtonMitte"
        Me.PanelButtonMitte.Size = New System.Drawing.Size(265, 37)
        Me.PanelButtonMitte.TabIndex = 1
        '
        'PanelButtonRechts
        '
        Me.PanelButtonRechts.Controls.Add(Me.PanelButtonOben2)
        Me.PanelButtonRechts.Controls.Add(Me.btnArchivAblegen)
        Me.PanelButtonRechts.Controls.Add(Me.btnPrint)
        Me.PanelButtonRechts.Controls.Add(Me.uDropDownButtVorhBiografien)
        Me.PanelButtonRechts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButtonRechts.Location = New System.Drawing.Point(265, 0)
        Me.PanelButtonRechts.Name = "PanelButtonRechts"
        Me.PanelButtonRechts.Size = New System.Drawing.Size(350, 37)
        Me.PanelButtonRechts.TabIndex = 0
        '
        'PanelButtonOben2
        '
        Me.PanelButtonOben2.Controls.Add(Me.btnPlusxyxy)
        Me.PanelButtonOben2.Controls.Add(Me.btnMinus)
        Me.PanelButtonOben2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButtonOben2.Location = New System.Drawing.Point(291, 0)
        Me.PanelButtonOben2.Name = "PanelButtonOben2"
        Me.PanelButtonOben2.Size = New System.Drawing.Size(59, 37)
        Me.PanelButtonOben2.TabIndex = 28
        '
        'btnPlusxyxy
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnPlusxyxy.Appearance = Appearance1
        Me.btnPlusxyxy.AutoWorkLayout = False
        Me.btnPlusxyxy.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnPlusxyxy.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnPlusxyxy.IsStandardControl = False
        Me.btnPlusxyxy.Location = New System.Drawing.Point(2, 4)
        Me.btnPlusxyxy.Name = "btnPlusxyxy"
        Me.btnPlusxyxy.Size = New System.Drawing.Size(26, 29)
        Me.btnPlusxyxy.TabIndex = 27
        UltraToolTipInfo2.ToolTipText = "Biografie hinzufügen"
        UltraToolTipInfo2.ToolTipTitle = "Hinzufügen"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.btnPlusxyxy, UltraToolTipInfo2)
        '
        'btnMinus
        '
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnMinus.Appearance = Appearance6
        Me.btnMinus.AutoWorkLayout = False
        Me.btnMinus.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnMinus.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnMinus.IsStandardControl = False
        Me.btnMinus.Location = New System.Drawing.Point(28, 4)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(26, 29)
        Me.btnMinus.TabIndex = 26
        UltraToolTipInfo3.ToolTipText = "Biografie entfernen"
        UltraToolTipInfo3.ToolTipTitle = "Entfernen"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.btnMinus, UltraToolTipInfo3)
        '
        'btnArchivAblegen
        '
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnArchivAblegen.Appearance = Appearance7
        Me.btnArchivAblegen.AutoWorkLayout = False
        Me.btnArchivAblegen.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnArchivAblegen.IsStandardControl = False
        Me.btnArchivAblegen.Location = New System.Drawing.Point(237, 4)
        Me.btnArchivAblegen.Name = "btnArchivAblegen"
        Me.btnArchivAblegen.Size = New System.Drawing.Size(26, 29)
        Me.btnArchivAblegen.TabIndex = 26
        Me.btnArchivAblegen.Text = "&Ablegen"
        UltraToolTipInfo4.ToolTipText = "Dokument wird ins Archiv in den Ordner 'Biografien' abgelegt"
        UltraToolTipInfo4.ToolTipTitle = "Ins Archiv als PDF ablegen"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.btnArchivAblegen, UltraToolTipInfo4)
        '
        'btnPrint
        '
        Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
        Appearance8.TextVAlignAsString = "Middle"
        Me.btnPrint.Appearance = Appearance8
        Me.btnPrint.AutoWorkLayout = False
        Me.btnPrint.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnPrint.IsStandardControl = False
        Me.btnPrint.Location = New System.Drawing.Point(263, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(26, 29)
        Me.btnPrint.TabIndex = 24
        UltraToolTipInfo5.ToolTipText = "Als PDF sichern"
        UltraToolTipInfo5.ToolTipTitle = "PDF"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.btnPrint, UltraToolTipInfo5)
        '
        'uDropDownButtVorhBiografien
        '
        Appearance9.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance9.BorderColor = System.Drawing.Color.Black
        Appearance9.BorderColor2 = System.Drawing.Color.Black
        Me.uDropDownButtVorhBiografien.Appearance = Appearance9
        Me.uDropDownButtVorhBiografien.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.uDropDownButtVorhBiografien.Location = New System.Drawing.Point(53, 4)
        Me.uDropDownButtVorhBiografien.Name = "uDropDownButtVorhBiografien"
        Me.uDropDownButtVorhBiografien.PopupItemKey = "ucFormAsses1"
        Me.uDropDownButtVorhBiografien.Size = New System.Drawing.Size(176, 29)
        Me.uDropDownButtVorhBiografien.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.uDropDownButtVorhBiografien.TabIndex = 21
        Me.uDropDownButtVorhBiografien.Text = "Vorhandene Biografien"
        UltraToolTipInfo6.ToolTipText = "Liste der vorhandenen Biografien zum Klienten"
        UltraToolTipInfo6.ToolTipTitle = "Vorhandene Biografien"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.uDropDownButtVorhBiografien, UltraToolTipInfo6)
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.lblErstelltAm)
        Me.PanelUnten.Controls.Add(Me.lblErstelltVon)
        Me.PanelUnten.Controls.Add(Me.panelUntenRechts)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 491)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(615, 40)
        Me.PanelUnten.TabIndex = 1
        '
        'lblErstelltAm
        '
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblErstelltAm.Appearance = Appearance2
        Me.lblErstelltAm.Location = New System.Drawing.Point(5, 21)
        Me.lblErstelltAm.Name = "lblErstelltAm"
        Me.lblErstelltAm.Size = New System.Drawing.Size(348, 14)
        Me.lblErstelltAm.TabIndex = 6
        Me.lblErstelltAm.Text = "Am: 23.03.2008 12:35"
        '
        'lblErstelltVon
        '
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblErstelltVon.Appearance = Appearance3
        Me.lblErstelltVon.Location = New System.Drawing.Point(5, 6)
        Me.lblErstelltVon.Name = "lblErstelltVon"
        Me.lblErstelltVon.Size = New System.Drawing.Size(348, 14)
        Me.lblErstelltVon.TabIndex = 5
        Me.lblErstelltVon.Text = "Von: Name Benutzer"
        '
        'panelUntenRechts
        '
        Me.panelUntenRechts.Controls.Add(Me.btnSpeichern)
        Me.panelUntenRechts.Controls.Add(Me.btnAbbrechen)
        Me.panelUntenRechts.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelUntenRechts.Location = New System.Drawing.Point(404, 0)
        Me.panelUntenRechts.Name = "panelUntenRechts"
        Me.panelUntenRechts.Size = New System.Drawing.Size(211, 40)
        Me.panelUntenRechts.TabIndex = 4
        '
        'btnSpeichern
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSpeichern.Appearance = Appearance4
        Me.btnSpeichern.AutoWorkLayout = False
        Me.btnSpeichern.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnSpeichern.IsStandardControl = False
        Me.btnSpeichern.Location = New System.Drawing.Point(117, 1)
        Me.btnSpeichern.Name = "btnSpeichern"
        Me.btnSpeichern.Size = New System.Drawing.Size(89, 32)
        Me.btnSpeichern.TabIndex = 26
        Me.btnSpeichern.Text = "&Speichern"
        '
        'btnAbbrechen
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnAbbrechen.Appearance = Appearance5
        Me.btnAbbrechen.AutoWorkLayout = False
        Me.btnAbbrechen.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnAbbrechen.IsStandardControl = False
        Me.btnAbbrechen.Location = New System.Drawing.Point(31, 1)
        Me.btnAbbrechen.Name = "btnAbbrechen"
        Me.btnAbbrechen.Size = New System.Drawing.Size(85, 32)
        Me.btnAbbrechen.TabIndex = 25
        Me.btnAbbrechen.Text = "&Abbrechen"
        UltraToolTipInfo1.ToolTipText = "Abbrechen und aktuelle Änderungen in der Biogafie verwerfen"
        UltraToolTipInfo1.ToolTipTitle = "Abbrechen"
        Me.ultraToolTipManager1.SetUltraToolTip(Me.btnAbbrechen, UltraToolTipInfo1)
        '
        'PanelEditor
        '
        Me.PanelEditor.Controls.Add(Me.UltraGridBagLayoutPanelEditor)
        Me.PanelEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEditor.Location = New System.Drawing.Point(0, 37)
        Me.PanelEditor.Name = "PanelEditor"
        Me.PanelEditor.Size = New System.Drawing.Size(615, 454)
        Me.PanelEditor.TabIndex = 2
        '
        'UltraGridBagLayoutPanelEditor
        '
        Me.UltraGridBagLayoutPanelEditor.Controls.Add(Me.PanelEditor2)
        Me.UltraGridBagLayoutPanelEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelEditor.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelEditor.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelEditor.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelEditor.Name = "UltraGridBagLayoutPanelEditor"
        Me.UltraGridBagLayoutPanelEditor.Size = New System.Drawing.Size(615, 454)
        Me.UltraGridBagLayoutPanelEditor.TabIndex = 0
        '
        'PanelEditor2
        '
        Me.PanelEditor2.BackColor = System.Drawing.Color.White
        Me.PanelEditor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanelEditor.SetGridBagConstraint(Me.PanelEditor2, GridBagConstraint1)
        Me.PanelEditor2.Location = New System.Drawing.Point(5, 5)
        Me.PanelEditor2.Name = "PanelEditor2"
        Me.UltraGridBagLayoutPanelEditor.SetPreferredSize(Me.PanelEditor2, New System.Drawing.Size(200, 100))
        Me.PanelEditor2.Size = New System.Drawing.Size(605, 444)
        Me.PanelEditor2.TabIndex = 0
        Me.PanelEditor2.Visible = False
        '
        'ultraToolTipManager1
        '
        Me.ultraToolTipManager1.ContainingControl = Me
        Me.ultraToolTipManager1.InitialDelay = 0
        '
        'ucBiografie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.PanelEditor)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.Name = "ucBiografie"
        Me.Size = New System.Drawing.Size(615, 531)
        Me.PanelOben.ResumeLayout(False)
        Me.PanelButtonRechts.ResumeLayout(False)
        Me.PanelButtonOben2.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.panelUntenRechts.ResumeLayout(False)
        Me.PanelEditor.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanelEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelEditor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridBagLayoutPanelEditor As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Private WithEvents btnPrint As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnAbbrechen As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnSpeichern As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents uPopupContContainerVorhBiografien As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents ultraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents uDropDownButtVorhBiografien As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents lblErstelltVon As QS2.Desktop.ControlManagment.BaseLabel
    Private WithEvents btnMinus As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnPlusxyxy As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents lblErstelltAm As QS2.Desktop.ControlManagment.BaseLabel
    Private WithEvents btnArchivAblegen As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents PanelOben As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelUnten As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelEditor As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelButtonMitte As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelButtonRechts As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelEditor2 As QS2.Desktop.ControlManagment.BasePanel
    Private WithEvents panelUntenRechts As QS2.Desktop.ControlManagment.BasePanel
    Friend WithEvents PanelButtonOben2 As QS2.Desktop.ControlManagment.BasePanel

End Class
