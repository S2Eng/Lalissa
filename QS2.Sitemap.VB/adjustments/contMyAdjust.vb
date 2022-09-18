Imports System.Windows.Forms
Imports System.IO
Imports System.Web

Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars

Imports qs2.core.vb
Imports qs2.core
Imports qs2.Resources



Public Class contMyAdjust
    Inherits System.Windows.Forms.UserControl


    Public actUsr1 As New actUsr()
    Public ui1 As New qs2.core.vb.ui()
    Public _IsInEditMode As Boolean = False
    Public doUI1 As New qs2.core.vb.doUI()
    Public b As New qs2.core.vb.businessFramework()




    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StyleNeuLadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StyleAusschlatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cboAutoStartUser As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAutoStart As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblStyle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblLanguage As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboLanguageUser As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents cboDefaultSearchPatients As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblDefaultSearchPatients As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelMySettings As System.Windows.Forms.Panel
    Public WithEvents checkDoNotShowAnymore As UltraWinEditors.UltraCheckEditor
    Public WithEvents cboStyle As Infragistics.Win.UltraWinEditors.UltraComboEditor





#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'UserControl überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cboStyle = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cboAutoStartUser = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StyleNeuLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StyleAusschlatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblAutoStart = New Infragistics.Win.Misc.UltraLabel()
        Me.lblStyle = New Infragistics.Win.Misc.UltraLabel()
        Me.lblLanguage = New Infragistics.Win.Misc.UltraLabel()
        Me.cboLanguageUser = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cboDefaultSearchPatients = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblDefaultSearchPatients = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelMySettings = New System.Windows.Forms.Panel()
        Me.checkDoNotShowAnymore = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        CType(Me.cboStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAutoStartUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLanguageUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDefaultSearchPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMySettings.SuspendLayout()
        CType(Me.checkDoNotShowAnymore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboStyle
        '
        Me.cboStyle.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboStyle.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboStyle.Location = New System.Drawing.Point(144, 33)
        Me.cboStyle.Name = "cboStyle"
        Me.cboStyle.Size = New System.Drawing.Size(125, 24)
        Me.cboStyle.TabIndex = 2
        '
        'cboAutoStartUser
        '
        Me.cboAutoStartUser.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboAutoStartUser.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboAutoStartUser.Location = New System.Drawing.Point(144, 60)
        Me.cboAutoStartUser.Name = "cboAutoStartUser"
        Me.cboAutoStartUser.Size = New System.Drawing.Size(125, 24)
        Me.cboAutoStartUser.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(9, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 23)
        Me.Label9.TabIndex = 563
        Me.Label9.Text = "Min. Versicherungen"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(228, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 23)
        Me.Label11.TabIndex = 565
        Me.Label11.Text = "Min. Vermittler"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(414, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 23)
        Me.Label10.TabIndex = 564
        Me.Label10.Text = "Min. Verträge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(228, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 23)
        Me.Label8.TabIndex = 562
        Me.Label8.Text = "Max. Vermittler"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(414, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 561
        Me.Label7.Text = "Max. Verträge"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(9, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 23)
        Me.Label6.TabIndex = 560
        Me.Label6.Text = "Max. Versicherungen"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StyleNeuLadenToolStripMenuItem
        '
        Me.StyleNeuLadenToolStripMenuItem.Name = "StyleNeuLadenToolStripMenuItem"
        Me.StyleNeuLadenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StyleNeuLadenToolStripMenuItem.Text = "Style neu laden"
        '
        'StyleAusschlatenToolStripMenuItem
        '
        Me.StyleAusschlatenToolStripMenuItem.Name = "StyleAusschlatenToolStripMenuItem"
        Me.StyleAusschlatenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StyleAusschlatenToolStripMenuItem.Text = "Style ausschalten"
        '
        'lblAutoStart
        '
        Me.lblAutoStart.Location = New System.Drawing.Point(5, 60)
        Me.lblAutoStart.Name = "lblAutoStart"
        Me.lblAutoStart.Size = New System.Drawing.Size(77, 18)
        Me.lblAutoStart.TabIndex = 39
        Me.lblAutoStart.Text = "AutoStart"
        '
        'lblStyle
        '
        Appearance1.TextHAlignAsString = "Left"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblStyle.Appearance = Appearance1
        Me.lblStyle.Location = New System.Drawing.Point(5, 33)
        Me.lblStyle.Name = "lblStyle"
        Me.lblStyle.Size = New System.Drawing.Size(67, 18)
        Me.lblStyle.TabIndex = 40
        Me.lblStyle.Text = "Style"
        '
        'lblLanguage
        '
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblLanguage.Appearance = Appearance2
        Me.lblLanguage.Location = New System.Drawing.Point(5, 5)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(69, 18)
        Me.lblLanguage.TabIndex = 41
        Me.lblLanguage.Text = "Language"
        '
        'cboLanguageUser
        '
        Me.cboLanguageUser.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboLanguageUser.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboLanguageUser.Location = New System.Drawing.Point(144, 6)
        Me.cboLanguageUser.Name = "cboLanguageUser"
        Me.cboLanguageUser.Size = New System.Drawing.Size(125, 24)
        Me.cboLanguageUser.TabIndex = 0
        '
        'cboDefaultSearchPatients
        '
        Me.cboDefaultSearchPatients.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
        Me.cboDefaultSearchPatients.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboDefaultSearchPatients.Location = New System.Drawing.Point(144, 87)
        Me.cboDefaultSearchPatients.Name = "cboDefaultSearchPatients"
        Me.cboDefaultSearchPatients.Size = New System.Drawing.Size(125, 24)
        Me.cboDefaultSearchPatients.TabIndex = 42
        '
        'lblDefaultSearchPatients
        '
        Me.lblDefaultSearchPatients.Location = New System.Drawing.Point(5, 87)
        Me.lblDefaultSearchPatients.Name = "lblDefaultSearchPatients"
        Me.lblDefaultSearchPatients.Size = New System.Drawing.Size(130, 18)
        Me.lblDefaultSearchPatients.TabIndex = 43
        Me.lblDefaultSearchPatients.Text = "Default search patients"
        '
        'PanelMySettings
        '
        Me.PanelMySettings.BackColor = System.Drawing.Color.Transparent
        Me.PanelMySettings.Controls.Add(Me.checkDoNotShowAnymore)
        Me.PanelMySettings.Controls.Add(Me.cboDefaultSearchPatients)
        Me.PanelMySettings.Controls.Add(Me.cboLanguageUser)
        Me.PanelMySettings.Controls.Add(Me.cboAutoStartUser)
        Me.PanelMySettings.Controls.Add(Me.cboStyle)
        Me.PanelMySettings.Controls.Add(Me.lblLanguage)
        Me.PanelMySettings.Controls.Add(Me.lblDefaultSearchPatients)
        Me.PanelMySettings.Controls.Add(Me.lblAutoStart)
        Me.PanelMySettings.Controls.Add(Me.lblStyle)
        Me.PanelMySettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMySettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelMySettings.Location = New System.Drawing.Point(0, 0)
        Me.PanelMySettings.Name = "PanelMySettings"
        Me.PanelMySettings.Size = New System.Drawing.Size(366, 252)
        Me.PanelMySettings.TabIndex = 44
        '
        'checkDoNotShowAnymore
        '
        Me.checkDoNotShowAnymore.Location = New System.Drawing.Point(7, 116)
        Me.checkDoNotShowAnymore.Name = "checkDoNotShowAnymore"
        Me.checkDoNotShowAnymore.Size = New System.Drawing.Size(353, 22)
        Me.checkDoNotShowAnymore.TabIndex = 250
        Me.checkDoNotShowAnymore.Text = "Do not show update news anymore"
        '
        'contMyAdjust
        '
        Me.Controls.Add(Me.PanelMySettings)
        Me.Name = "contMyAdjust"
        Me.Size = New System.Drawing.Size(366, 252)
        CType(Me.cboStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAutoStartUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLanguageUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDefaultSearchPatients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMySettings.ResumeLayout(False)
        Me.PanelMySettings.PerformLayout()
        CType(Me.checkDoNotShowAnymore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub EinstellungenITSCont_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl()
        Try
            Me.loadRes()
            qs2.core.generic.getFilesUIStyles(Nothing, Me.cboStyle)
            qs2.core.generic.getEnumLanguages(Nothing, Me.cboLanguageUser)
            Me.ui1.loadSearchPatients(False, Nothing, qs2.core.license.doLicense.rApplication.IDApplication.ToString(), Me.cboDefaultSearchPatients)
            Me.setUI(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.lblLanguage.Text = qs2.core.language.sqlLanguage.getRes("Language")
            Me.lblAutoStart.Text = qs2.core.language.sqlLanguage.getRes("AutoStart")
            Me.lblDefaultSearchPatients.Text = qs2.core.language.sqlLanguage.getRes("DefaultSearchPatients")

            Me.cboAutoStartUser.Items.Clear()
            Me.cboAutoStartUser.Items.Add(qs2.core.Enums.eApplicationAutoStart.SearchPatient.ToString(), qs2.core.language.sqlLanguage.getRes("SearchPatient"))
            Me.cboAutoStartUser.Items.Add(qs2.core.Enums.eApplicationAutoStart.UserDefinedQueries.ToString(), qs2.core.language.sqlLanguage.getRes("UserDefinedQueries"))

            Me.checkDoNotShowAnymore.Text = qs2.core.language.sqlLanguage.getRes("DoNotShowMeAnymore")

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
            Else
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadData(usrToLoad As String)
        Try
            Me.cboLanguageUser.Value = actUsr.adjustRead(usrToLoad, sqlAdmin.eAdjust.LanguageUser, sqlAdmin.eTypSelAdjust.forUsr, "")
            If Me.cboLanguageUser.Value Is Nothing Then
                Me.cboLanguageUser.Value = Nothing   'qs2.core.language.sqlLanguage.eLanguage.English.ToString()
            End If

            Me.cboAutoStartUser.Value = actUsr.adjustRead(usrToLoad, sqlAdmin.eAdjust.applicationAutoStart, sqlAdmin.eTypSelAdjust.forUsr, "")
            'If Me.cboAutoStartUser.Value Is Nothing Then
            '    Me.cboAutoStartUser.Value = qs2.core.Enums.eApplicationAutoStart.SearchPatient.ToString()
            'End If

            Dim sStyleUI As String = actUsr.adjustRead(usrToLoad, sqlAdmin.eAdjust.styleUI, sqlAdmin.eTypSelAdjust.forUsr, "")
            If sStyleUI Is Nothing Then
                Me.cboStyle.Value = ("Gray").ToString()
            Else
                Me.cboStyle.Value = sStyleUI
            End If

            Dim oDefaultSearchPatient As Object = actUsr.adjustRead(usrToLoad, sqlAdmin.eAdjust.defaultSearchUser, sqlAdmin.eTypSelAdjust.forUsr, "")
            If oDefaultSearchPatient <> Nothing Then
                Me.cboDefaultSearchPatients.Value = System.Convert.ToInt32(oDefaultSearchPatient)
            Else
                Me.cboDefaultSearchPatients.Value = Nothing
            End If

            Using db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                Dim bDoNotShowAnymore As Boolean = Me.b.checkShowUpdateNews(qs2.core.vb.actUsr.rUsr.IDGuid, db)
                Me.checkDoNotShowAnymore.Checked = Not bDoNotShowAnymore
            End Using

        Catch ex As Exception
            Throw New Exception("contMyAdjust.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub saveSettings(usrToSave As String)
        Try
            If Not Me.cboLanguageUser.Value Is Nothing Then
                actUsr.adjustSave(usrToSave, sqlAdmin.eAdjust.LanguageUser, sqlAdmin.eTypSelAdjust.forUsr, Me.cboLanguageUser.Value)
            Else

            End If
            If Not Me.cboAutoStartUser.Value Is Nothing Then
                actUsr.adjustSave(usrToSave, sqlAdmin.eAdjust.applicationAutoStart, sqlAdmin.eTypSelAdjust.forUsr, Me.cboAutoStartUser.Value)
            Else
            End If
            If Not Me.cboStyle.Value Is Nothing Then
                qs2.core.vb.actUsr.adjustSave(usrToSave, sqlAdmin.eAdjust.styleUI, sqlAdmin.eTypSelAdjust.forUsr, Me.cboStyle.Value)
            Else

            End If

            If Not Me.cboDefaultSearchPatients.Value Is Nothing Then
                qs2.core.vb.actUsr.adjustSave(usrToSave, sqlAdmin.eAdjust.defaultSearchUser, sqlAdmin.eTypSelAdjust.forUsr, System.Convert.ToInt32(Me.cboDefaultSearchPatients.Value))
            End If

            Using db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                Me.b.updateNewsShowOnOff(Not Me.checkDoNotShowAnymore.Checked, qs2.core.vb.actUsr.rUsr.IDGuid, db)
            End Using

        Catch ex As Exception
            Throw New Exception("contMyAdjust.saveSettings: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub setUI(ByVal editOn As Boolean)
        Try
            Me._IsInEditMode = editOn
            Me.doUI1.EnableControls(Me.PanelMySettings, editOn)
            Me.checkDoNotShowAnymore.Enabled = editOn

        Catch ex As Exception
            Throw New Exception("setUI: " + ex.ToString())
        End Try
    End Sub

    Public Sub ClearUI()
        Try
            Me.cboLanguageUser.Value = Nothing
            Me.cboAutoStartUser.Value = Nothing
            Me.cboStyle.Value = Nothing

        Catch ex As Exception
            Throw New Exception("contMyAdjust.ClearUI: " + ex.ToString())
        End Try
    End Sub

End Class
