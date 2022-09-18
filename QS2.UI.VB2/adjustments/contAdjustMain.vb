Imports qs2.core.vb
Imports System.Windows.Forms
Imports qs2.Resources

Public Class contAdjustMain
    Inherits System.Windows.Forms.UserControl



    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents lblAktivRechnerVermittlerstrukturZurücksetzen2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FormPanel As System.Windows.Forms.Panel

    Public isLoaded As Boolean = False


    Friend WithEvents ContextMenuStripAdministration As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TestErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRefresh As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents AppStylistRuntime1 As Infragistics.Win.AppStyling.Runtime.AppStylistRuntime
    Friend WithEvents AdministratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenHistoryOfAllUsersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetStyleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AppStylingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowUIElementViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadAllRessourcesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadStyleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadedEnvironmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteWholeProtocolFromDataServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents btnOpenMyHistorie As qs2.sitemap.ownControls.inherit_Infrag.contInfragLblButton
    Friend WithEvents btnReload As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnManageLayouts As qs2.sitemap.ownControls.inherit_Infrag.contInfragLblButton
    Friend WithEvents ClearDoublesRowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSave3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ContAdjust1 As qs2.sitemap.vb.contAdjust








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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contAdjustMain))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStripAdministration = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TestErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenHistoryOfAllUsersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AppStylingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowUIElementViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadAllRessourcesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadedEnvironmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearDoublesRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSave3 = New Infragistics.Win.Misc.UltraButton()
        Me.btnManageLayouts = New qs2.sitemap.ownControls.inherit_Infrag.contInfragLblButton()
        Me.btnOpenMyHistorie = New qs2.sitemap.ownControls.inherit_Infrag.contInfragLblButton()
        Me.btnReload = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnRefresh = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2 = New Infragistics.Win.Misc.UltraLabel()
        Me.FormPanel = New System.Windows.Forms.Panel()
        Me.ContAdjust1 = New qs2.sitemap.vb.contAdjust()
        Me.AppStylistRuntime1 = New Infragistics.Win.AppStyling.Runtime.AppStylistRuntime(Me.components)
        Me.PanelBottom.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStripAdministration.SuspendLayout()
        Me.FormPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.Panel1)
        Me.PanelBottom.Controls.Add(Me.btnRefresh)
        Me.PanelBottom.Controls.Add(Me.lblAktivRechnerVermittlerstrukturZurücksetzen2)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 329)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(705, 32)
        Me.PanelBottom.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.ContextMenuStrip = Me.ContextMenuStripAdministration
        Me.Panel1.Controls.Add(Me.btnSave3)
        Me.Panel1.Controls.Add(Me.btnManageLayouts)
        Me.Panel1.Controls.Add(Me.btnOpenMyHistorie)
        Me.Panel1.Controls.Add(Me.btnReload)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(705, 32)
        Me.Panel1.TabIndex = 585
        '
        'ContextMenuStripAdministration
        '
        Me.ContextMenuStripAdministration.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestErrorToolStripMenuItem, Me.AdministratorToolStripMenuItem})
        Me.ContextMenuStripAdministration.Name = "ContextMenuStrip1"
        Me.ContextMenuStripAdministration.Size = New System.Drawing.Size(154, 48)
        '
        'TestErrorToolStripMenuItem
        '
        Me.TestErrorToolStripMenuItem.Name = "TestErrorToolStripMenuItem"
        Me.TestErrorToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.TestErrorToolStripMenuItem.Text = "TestError"
        '
        'AdministratorToolStripMenuItem
        '
        Me.AdministratorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenHistoryOfAllUsersToolStripMenuItem1, Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem, Me.ToolStripMenuItem5, Me.LoadStyleToolStripMenuItem, Me.ResetStyleToolStripMenuItem, Me.ToolStripMenuItem1, Me.AppStylingToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ShowUIElementViewerToolStripMenuItem, Me.ToolStripMenuItem2, Me.LoadAllRessourcesToolStripMenuItem1, Me.ToolStripMenuItem6, Me.LoadedEnvironmentToolStripMenuItem, Me.ToolStripMenuItem4, Me.ClearDoublesRowsToolStripMenuItem})
        Me.AdministratorToolStripMenuItem.Name = "AdministratorToolStripMenuItem"
        Me.AdministratorToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AdministratorToolStripMenuItem.Text = "Administration"
        '
        'OpenHistoryOfAllUsersToolStripMenuItem1
        '
        Me.OpenHistoryOfAllUsersToolStripMenuItem1.Name = "OpenHistoryOfAllUsersToolStripMenuItem1"
        Me.OpenHistoryOfAllUsersToolStripMenuItem1.Size = New System.Drawing.Size(286, 22)
        Me.OpenHistoryOfAllUsersToolStripMenuItem1.Text = "OpenHistoryOfAllUsers"
        '
        'DeleteWholeProtocolFromDataServiceToolStripMenuItem
        '
        Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem.Name = "DeleteWholeProtocolFromDataServiceToolStripMenuItem"
        Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem.Text = "Delete whole protocol from data-service"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(283, 6)
        '
        'LoadStyleToolStripMenuItem
        '
        Me.LoadStyleToolStripMenuItem.Name = "LoadStyleToolStripMenuItem"
        Me.LoadStyleToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.LoadStyleToolStripMenuItem.Text = "Load Style"
        '
        'ResetStyleToolStripMenuItem
        '
        Me.ResetStyleToolStripMenuItem.Name = "ResetStyleToolStripMenuItem"
        Me.ResetStyleToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ResetStyleToolStripMenuItem.Text = "Reset Style"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(283, 6)
        '
        'AppStylingToolStripMenuItem1
        '
        Me.AppStylingToolStripMenuItem1.Name = "AppStylingToolStripMenuItem1"
        Me.AppStylingToolStripMenuItem1.Size = New System.Drawing.Size(286, 22)
        Me.AppStylingToolStripMenuItem1.Text = "Application-Styler"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(283, 6)
        '
        'ShowUIElementViewerToolStripMenuItem
        '
        Me.ShowUIElementViewerToolStripMenuItem.Name = "ShowUIElementViewerToolStripMenuItem"
        Me.ShowUIElementViewerToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ShowUIElementViewerToolStripMenuItem.Text = "Show UI Element Viewer"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(283, 6)
        '
        'LoadAllRessourcesToolStripMenuItem1
        '
        Me.LoadAllRessourcesToolStripMenuItem1.Name = "LoadAllRessourcesToolStripMenuItem1"
        Me.LoadAllRessourcesToolStripMenuItem1.Size = New System.Drawing.Size(286, 22)
        Me.LoadAllRessourcesToolStripMenuItem1.Text = "Load all Ressources"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(283, 6)
        '
        'LoadedEnvironmentToolStripMenuItem
        '
        Me.LoadedEnvironmentToolStripMenuItem.Name = "LoadedEnvironmentToolStripMenuItem"
        Me.LoadedEnvironmentToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.LoadedEnvironmentToolStripMenuItem.Text = "Loaded environment"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(283, 6)
        '
        'ClearDoublesRowsToolStripMenuItem
        '
        Me.ClearDoublesRowsToolStripMenuItem.Name = "ClearDoublesRowsToolStripMenuItem"
        Me.ClearDoublesRowsToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ClearDoublesRowsToolStripMenuItem.Text = "Clear doubles rows"
        '
        'btnSave3
        '
        Me.btnSave3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave3.Location = New System.Drawing.Point(598, 0)
        Me.btnSave3.Name = "btnSave3"
        Me.btnSave3.Size = New System.Drawing.Size(91, 28)
        Me.btnSave3.TabIndex = 584
        Me.btnSave3.Text = "Save"
        '
        'btnManageLayouts
        '
        Me.btnManageLayouts.BackColor = System.Drawing.Color.Transparent
        Me.btnManageLayouts.Location = New System.Drawing.Point(187, 9)
        Me.btnManageLayouts.Name = "btnManageLayouts"
        Me.btnManageLayouts.OwnAutoTextYN = True
        Me.btnManageLayouts.OwnForeColorLabel = System.Drawing.Color.Black
        Me.btnManageLayouts.OwnIDRessourceText = "ManageLayouts"
        Me.btnManageLayouts.OwnIDRessourceToolTipText = ""
        Me.btnManageLayouts.OwnIDRessourceToolTipTitle = "Manage Layouts"
        Me.btnManageLayouts.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnManageLayouts.OwnTextHAlign = Infragistics.Win.HAlign.Left
        Me.btnManageLayouts.Size = New System.Drawing.Size(159, 16)
        Me.btnManageLayouts.TabIndex = 583
        '
        'btnOpenMyHistorie
        '
        Me.btnOpenMyHistorie.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenMyHistorie.Location = New System.Drawing.Point(17, 9)
        Me.btnOpenMyHistorie.Name = "btnOpenMyHistorie"
        Me.btnOpenMyHistorie.OwnAutoTextYN = True
        Me.btnOpenMyHistorie.OwnForeColorLabel = System.Drawing.Color.Black
        Me.btnOpenMyHistorie.OwnIDRessourceText = "MyHistory"
        Me.btnOpenMyHistorie.OwnIDRessourceToolTipText = "OpenMyHistories"
        Me.btnOpenMyHistorie.OwnIDRessourceToolTipTitle = "MyHistory"
        Me.btnOpenMyHistorie.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnOpenMyHistorie.OwnTextHAlign = Infragistics.Win.HAlign.Left
        Me.btnOpenMyHistorie.Size = New System.Drawing.Size(159, 16)
        Me.btnOpenMyHistorie.TabIndex = 0
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnReload.Appearance = Appearance1
        Me.btnReload.Location = New System.Drawing.Point(566, 0)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.OwnAutoTextYN = False
        Me.btnReload.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Aktualisieren
        Me.btnReload.OwnPictureTxt = ""
        Me.btnReload.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnReload.OwnTooltipText = ""
        Me.btnReload.OwnTooltipTitle = Nothing
        Me.btnReload.Size = New System.Drawing.Size(31, 28)
        Me.btnReload.TabIndex = 582
        '
        'UltraLabel1
        '
        Appearance2.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance2.FontData.SizeInPoints = 9.0!
        Appearance2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.AutoSize = True
        Appearance3.FontData.UnderlineAsString = "True"
        Me.UltraLabel1.HotTrackAppearance = Appearance3
        Me.UltraLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UltraLabel1.Location = New System.Drawing.Point(217, -139)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(332, 16)
        Me.UltraLabel1.TabIndex = 13
        Me.UltraLabel1.Text = "Aktive Rechner Bearbeitung/Vermittlerstruktur zurücksetzen"
        Me.UltraLabel1.UseAppStyling = False
        Me.UltraLabel1.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnRefresh.Appearance = Appearance4
        Me.btnRefresh.Location = New System.Drawing.Point(566, 0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.OwnAutoTextYN = False
        Me.btnRefresh.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Aktualisieren
        Me.btnRefresh.OwnPictureTxt = ""
        Me.btnRefresh.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnRefresh.OwnTooltipText = ""
        Me.btnRefresh.OwnTooltipTitle = Nothing
        Me.btnRefresh.Size = New System.Drawing.Size(31, 28)
        Me.btnRefresh.TabIndex = 582
        '
        'lblAktivRechnerVermittlerstrukturZurücksetzen2
        '
        Appearance5.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance5.FontData.SizeInPoints = 9.0!
        Appearance5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.Appearance = Appearance5
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.AutoSize = True
        Appearance6.FontData.UnderlineAsString = "True"
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.HotTrackAppearance = Appearance6
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.Location = New System.Drawing.Point(217, -139)
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.Name = "lblAktivRechnerVermittlerstrukturZurücksetzen2"
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.Size = New System.Drawing.Size(332, 16)
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.TabIndex = 13
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.Text = "Aktive Rechner Bearbeitung/Vermittlerstruktur zurücksetzen"
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.UseAppStyling = False
        Me.lblAktivRechnerVermittlerstrukturZurücksetzen2.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'FormPanel
        '
        Me.FormPanel.BackColor = System.Drawing.Color.Transparent
        Me.FormPanel.ContextMenuStrip = Me.ContextMenuStripAdministration
        Me.FormPanel.Controls.Add(Me.ContAdjust1)
        Me.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormPanel.Location = New System.Drawing.Point(0, 0)
        Me.FormPanel.Name = "FormPanel"
        Me.FormPanel.Size = New System.Drawing.Size(705, 329)
        Me.FormPanel.TabIndex = 29
        '
        'ContAdjust1
        '
        Me.ContAdjust1.BackColor = System.Drawing.Color.Transparent
        Me.ContAdjust1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContAdjust1.Location = New System.Drawing.Point(0, 0)
        Me.ContAdjust1.Name = "ContAdjust1"
        Me.ContAdjust1.Size = New System.Drawing.Size(705, 329)
        Me.ContAdjust1.TabIndex = 0
        '
        'contAdjustMain
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.FormPanel)
        Me.Controls.Add(Me.PanelBottom)
        Me.Name = "contAdjustMain"
        Me.Size = New System.Drawing.Size(705, 361)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStripAdministration.ResumeLayout(False)
        Me.FormPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region




    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.loadRes()

            Me.ContAdjust1.initControl()

            Me.ContAdjust1.loadData()

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.AdministratorToolStripMenuItem.Visible = True
            Else
                Me.AdministratorToolStripMenuItem.Visible = False
            End If

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.TestErrorToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("TestError")

            Me.LoadStyleToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("LoadStyle")
            Me.ResetStyleToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ResetStyle")
            Me.ShowUIElementViewerToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ShowUIElementViewer")
            Me.LoadAllRessourcesToolStripMenuItem1.Text = qs2.core.language.sqlLanguage.getRes("LoadAllRessources")
            Me.OpenHistoryOfAllUsersToolStripMenuItem1.Text = qs2.core.language.sqlLanguage.getRes("OpenHistoryOfAllUsers")
            Me.AdministratorToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Administration")
            Me.OpenHistoryOfAllUsersToolStripMenuItem1.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)
            Me.LoadedEnvironmentToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("LoadedEnvironment")
            Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("DeleteWholeProtocolFromDataService")

            Me.DeleteWholeProtocolFromDataServiceToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Minus, 32, 32)

            Me.btnSave3.Text = qs2.core.language.sqlLanguage.getRes("Save")
            Me.btnSave3.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

            Me.btnSave3.Enabled = (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin)

            'Me.AppStylingToolStripMenuItem1.Text = qs2.core.language.sqlLanguage.getRes("AppStyling")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Function speichern() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not Me.ContAdjust1.validateData() Then
                Return False
            End If

            Me.ContAdjust1.saveSettings2()
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function



    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContAdjust1.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub OpenHistorieUsers(ofAllUsers As Boolean, IDRessourceTitle As String)
        Try
            Dim sqlProtocollWork As New sqlProtocoll()
            Dim dsProtocollWork As New dsProtocol()
            sqlProtocollWork.initControl()
            Dim SqlCommand As String = ""
            If ofAllUsers Then
                sqlProtocollWork.getProtocol(System.Guid.NewGuid(), dsProtocollWork, sqlProtocoll.eSelProtocoll.All, "", System.Guid.Empty,
                                             qs2.core.generic.idMinus, "", "", Nothing, Nothing, "", SqlCommand, Not ofAllUsers)
            Else
                sqlProtocollWork.getProtocol(System.Guid.NewGuid(), dsProtocollWork, sqlProtocoll.eSelProtocoll.OfUser, actUsr.rUsr.UserName,
                                             System.Guid.Empty, qs2.core.generic.idMinus, "", "", Nothing, Nothing, "", SqlCommand, Not ofAllUsers)
            End If

            Dim sAdditionalTxt As String = ""
            qs2.design.auto.ui.openTableViewer(dsProtocollWork, IDRessourceTitle, sAdditionalTxt.Trim(), qs2.core.license.doLicense.rParticipant.IDParticipant, "QS2",
                                             dsProtocollWork.Protocol.TableName, qs2.ui.print.contTable.eTypeUI.History, False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub OpenHistoryOfAllUsersToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles OpenHistoryOfAllUsersToolStripMenuItem1.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.OpenHistorieUsers(True, "HistoryOfAllUsers")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub ResetStyleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResetStyleToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.ContAdjust1.noStyle()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AppStylingToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AppStylingToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.AppStylistRuntime1.ShowRuntimeApplicationStylingEditor(qs2.core.ENV.MainForm, "QS2 - Dynamic Styling")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ShowUIElementViewerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowUIElementViewerToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            'Dim uiElementViewer1 As New Infragistics.Win.UIElementViewer.UIElementViewerForm()
            'uiElementViewer1.Show()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub LoadAllRessourcesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LoadAllRessourcesToolStripMenuItem1.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            sqlLanguage1.loadAllRessources()

            Dim sqlAdmin1 As New qs2.core.vb.sqlAdmin()
            sqlAdmin1.initControl()
            sqlAdmin1.loadAll(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub LoadStyleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadStyleToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.ContAdjust1.Loadstyle()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub LoadedEnvironmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadedEnvironmentToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim sInfo As String = qs2.core.vb.ui.getInfoEnvironment()
            Dim frmProtocol1 As New frmProtocol()
            frmProtocol1.initControl()
            frmProtocol1.Text = "Loaded Environment"
            qs2.core.ENV.lstOpendChildForms.Add(frmProtocol1)
            frmProtocol1.ShowDialog(Me)
            frmProtocol1.ContProtocol1.setText(sInfo.Trim())

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub DeleteWholeProtocolFromDataServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteWholeProtocolFromDataServiceToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ret As MsgBoxResult
            ret = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToDoThisActivity") + "?", System.Windows.Forms.MessageBoxButtons.YesNo, "")
            If ret = MsgBoxResult.Yes Then
                Dim sqlProtocoll1 As New sqlProtocoll()
                sqlProtocoll1.sys_deleteWholeProtocolFromDataService()
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ActivityPerformed"), System.Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnOpenMyHistorie_LabelCLicked(sender As Object, e As EventArgs) Handles btnOpenMyHistorie.LabelCLicked
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.OpenHistorieUsers(False, "MyHistory")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnManageLayouts_LabelCLicked(sender As Object, e As EventArgs) Handles btnManageLayouts.LabelCLicked
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim frmLayoutGrid As New qs2.core.vb.frmLayoutManager()
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1._LayoutKey = ""
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1.gridUIToSave = Nothing
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = cLayoutManager.eTypLayoutGrid.onlyFirstBand
            frmLayoutGrid.initControl("", True, "", qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
            frmLayoutGrid.Show()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub TestErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestErrorToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Throw New Exception("This is a Test-Exception!")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub ClearDoublesRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearDoublesRowsToolStripMenuItem.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If qs2.core.generic.showMessageBox("Would you realy clear doubled rows?", MessageBoxButtons.YesNo, "") = DialogResult.Yes Then
                Dim b As New businessFramework()
                b.checkDoubledRows()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnSave3_Click(sender As Object, e As EventArgs) Handles btnSave3.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.speichern() Then
                Me.ContAdjust1.loadData()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.ContAdjust1.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class
