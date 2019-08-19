Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms
Imports System.Drawing



Public Class contOrdner
    Inherits System.Windows.Forms.UserControl

    Public delMouseUp As New dArchiv
    Public delClick As New dArchiv
    Public delDragDrop As New dArchiv

    Public fileDragDrop As String = ""

    Public dsGruppenDB As New dsPlanArchive

    Private Typ As New etyp
    Public BezeichnungAlt As String = ""
    Public Enum etyp
        Verwaltung = 0
        AuswahlSuche = 1
        Ablegen = 2
        SuchergebnisseAnzeigen = 3
    End Enum
    Private dataDokuErgebnisse As dsPlanArchive

    Public modalusrCont As contArchivAbleg

    Public Enum eTypSaveOrdner
        gesamteOrdner = 0
        nurExtern = 1
    End Enum
    Public Enum eDateiRausspielenName
        originalName = 0
        Bezeichnung = 1
        Archivname = 2
    End Enum

    Private protokoll As String = ""
    Private err_DateiRausspielen As Integer = 0
    Private usr As New GeneralArchiv()



    Friend WithEvents cboSystemordner As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblSystemordner As System.Windows.Forms.Label
    Friend WithEvents CMenuStripOrdner As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NeuenOrdnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager



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
    Public WithEvents UTreeOrdner As Infragistics.Win.UltraWinTree.UltraTree

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contOrdner))
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("Speichern")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Systemordner", Infragistics.Win.DefaultableBoolean.[Default])
        Me.UTreeOrdner = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.CMenuStripOrdner = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuenOrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.cboSystemordner = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblSystemordner = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.UTreeOrdner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripOrdner.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        CType(Me.cboSystemordner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UTreeOrdner
        '
        Me.UTreeOrdner.AllowDrop = True
        Me.UTreeOrdner.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UTreeOrdner.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista
        Me.UTreeOrdner.Dock = System.Windows.Forms.DockStyle.Top
        Me.UTreeOrdner.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UTreeOrdner.Location = New System.Drawing.Point(0, 0)
        Me.UTreeOrdner.Name = "UTreeOrdner"
        Me.UTreeOrdner.NodeConnectorColor = System.Drawing.SystemColors.ControlDark
        Override1.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Override1.HotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Override1.ImageSize = New System.Drawing.Size(16, 16)
        Override1.LabelEdit = Infragistics.Win.DefaultableBoolean.[True]
        Override1.NodeSpacingBefore = 2
        Override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.[Single]
        Me.UTreeOrdner.Override = Override1
        Me.UTreeOrdner.Size = New System.Drawing.Size(632, 346)
        Me.UTreeOrdner.TabIndex = 0
        Me.UTreeOrdner.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'CMenuStripOrdner
        '
        Me.CMenuStripOrdner.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuenOrdnerToolStripMenuItem, Me.OrdnerLöschenToolStripMenuItem})
        Me.CMenuStripOrdner.Name = "CMenuStripOrdner"
        Me.CMenuStripOrdner.Size = New System.Drawing.Size(156, 48)
        '
        'NeuenOrdnerToolStripMenuItem
        '
        Me.NeuenOrdnerToolStripMenuItem.Image = CType(resources.GetObject("NeuenOrdnerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuenOrdnerToolStripMenuItem.Name = "NeuenOrdnerToolStripMenuItem"
        Me.NeuenOrdnerToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.NeuenOrdnerToolStripMenuItem.Text = "Neuer Ordner"
        '
        'OrdnerLöschenToolStripMenuItem
        '
        Me.OrdnerLöschenToolStripMenuItem.Image = CType(resources.GetObject("OrdnerLöschenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OrdnerLöschenToolStripMenuItem.Name = "OrdnerLöschenToolStripMenuItem"
        Me.OrdnerLöschenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.OrdnerLöschenToolStripMenuItem.Text = "Ordner löschen"
        '
        'PanelUnten
        '
        Me.PanelUnten.BackColor = System.Drawing.Color.White
        Me.PanelUnten.Controls.Add(Me.cboSystemordner)
        Me.PanelUnten.Controls.Add(Me.lblSystemordner)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 352)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(632, 32)
        Me.PanelUnten.TabIndex = 1
        '
        'cboSystemordner
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        EditorButton1.Appearance = Appearance1
        EditorButton1.Key = "Speichern"
        EditorButton1.Text = ""
        Me.cboSystemordner.ButtonsRight.Add(EditorButton1)
        Me.cboSystemordner.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = -1
        ValueListItem1.DisplayText = "kein Systemordner"
        ValueListItem2.DataValue = 1
        ValueListItem2.DisplayText = "Papierkorb"
        ValueListItem3.DataValue = 2
        ValueListItem3.DisplayText = "Anhang Planungssystem"
        Me.cboSystemordner.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.cboSystemordner.Location = New System.Drawing.Point(134, 6)
        Me.cboSystemordner.Name = "cboSystemordner"
        Me.cboSystemordner.Size = New System.Drawing.Size(180, 21)
        Me.cboSystemordner.TabIndex = 0
        UltraToolTipInfo1.ToolTipTextFormatted = "Systemordner sind spezielle Ordner!<br/>(Papierkorb oder Ordner/Anhang für Termin" &
    "e bzw.&edsp;&edsp;E-Mails)<br/>"
        UltraToolTipInfo1.ToolTipTitle = "Systemordner"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.cboSystemordner, UltraToolTipInfo1)
        Me.cboSystemordner.Visible = False
        '
        'lblSystemordner
        '
        Me.lblSystemordner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemordner.Location = New System.Drawing.Point(9, 5)
        Me.lblSystemordner.Name = "lblSystemordner"
        Me.lblSystemordner.Size = New System.Drawing.Size(128, 21)
        Me.lblSystemordner.TabIndex = 386
        Me.lblSystemordner.Text = "Systemordner festlegen"
        Me.lblSystemordner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSystemordner.Visible = False
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'contOrdner
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.UTreeOrdner)
        Me.Controls.Add(Me.PanelUnten)
        Me.Name = "contOrdner"
        Me.Size = New System.Drawing.Size(632, 384)
        CType(Me.UTreeOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripOrdner.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUnten.PerformLayout()
        CType(Me.cboSystemordner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ArchivOrdner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gen As New GeneralArchiv
        Try
            Me.cboSystemordner.Value = -1

            'Me.UButtonPlus.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            'Me.UButtonMinus.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Public Sub initTree_icons(ByVal bBig As Boolean)
        Try
            Dim siz As New Size
            If bBig Then
                siz.Height = 32
                siz.Width = 32
            Else
                siz.Height = 16
                siz.Width = 16
            End If
            Me.UTreeOrdner.Override.ImageSize = siz

        Catch ex As Exception
            Throw New Exception("initTree_icons: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadOrdnerbaum(ByVal typ As etyp, ByVal IDOrdner As System.Guid)
        Dim gen As New GeneralArchiv
        Try
            Me.Typ = typ

            If typ = etyp.Ablegen Then
                Me.UTreeOrdner.ContextMenu = Nothing
                Me.UTreeOrdner.Override.SelectionType = SelectType.Single
                Me.UTreeOrdner.AllowDrop = True
                Me.UTreeOrdner.Dock = DockStyle.Fill

            ElseIf typ = etyp.AuswahlSuche Then
                Me.UTreeOrdner.ContextMenu = Nothing
                Me.UTreeOrdner.Override.SelectionType = SelectType.Single
                Me.UTreeOrdner.Override.NodeStyle = NodeStyle.CheckBox
                Me.UTreeOrdner.AllowDrop = False
                Me.UTreeOrdner.Dock = DockStyle.Fill

            ElseIf typ = etyp.Verwaltung Then
                Me.UTreeOrdner.Override.SelectionType = SelectType.Single
                Me.UTreeOrdner.Override.NodeStyle = NodeStyle.Default
                Me.UTreeOrdner.AllowDrop = False
                Me.lblSystemordner.Visible = True
                Me.cboSystemordner.Visible = True
                Me.cboSystemordner.Value = -1
                Me.UTreeOrdner.ContextMenuStrip = Me.CMenuStripOrdner

            End If
            Me.Load_SchränkeFächer(typ, False)
            Me.SelectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("LoadOrdnerbaum: " + ex.ToString())
        End Try
    End Sub
    Public Sub fill_DockStyle()
        Try
            Me.PanelUnten.Height = 0
            Me.UTreeOrdner.Dock = DockStyle.Fill

        Catch ex As Exception
            Throw New Exception("LoadOrdnerbaum: " + ex.ToString())
        End Try
    End Sub
    Public Sub resizeForVerwaltung()
        Try
            Me.UTreeOrdner.Height = Me.Height - Me.PanelUnten.Height

        Catch ex As Exception
            Throw New Exception("resizeForVerwaltung: " + ex.ToString())
        End Try
    End Sub
    Public Sub resizeForSucherergebnisse()
        Try
            'Me.UTreeOrdner.Height = Me.Height - Me.PanelUnten.Height
            'Me.lblSystemordner.Visible = False
            'Me.cboSystemordner.Visible = False
            'Me.UButtonSystemordnerSpeichern.Visible = False
            'Me.UButtonPlus.Visible = True
            'Me.UButtonMinus.Visible = True
            Me.PanelUnten.Height = 0
            Me.UTreeOrdner.Dock = DockStyle.Fill

        Catch ex As Exception
            Throw New Exception("resizeForSucherergebnisse: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadSuchergebnis(ByVal dataDokuErgeb As dsPlanArchive, ByVal typ As etyp,
                                ByVal NurDokumenteMitOrdner As Boolean)
        Dim gen As New GeneralArchiv
        Try
            Me.Typ = typ
            If typ = etyp.SuchergebnisseAnzeigen Then
                Me.UTreeOrdner.ContextMenu = Nothing
                Me.UTreeOrdner.Override.SelectionType = SelectType.Single

                'Me.UTreeOrdner.Override.NodeStyle = NodeStyle.CheckBox
                Me.dataDokuErgebnisse = New dsPlanArchive
                Me.dataDokuErgebnisse = dataDokuErgeb
                Me.Load_SchränkeFächer(typ, NurDokumenteMitOrdner)
            End If

        Catch ex As Exception
            Throw New Exception("LoadSuchergebnis: " + ex.ToString())
        End Try
    End Sub

    Public ReadOnly Property GetCheckedOrdner() As ArrayList
        Get
            Dim arr As New ArrayList
            Return Me.GetCheckedOrdner_rek(True, Nothing)
        End Get
    End Property
    Public ReadOnly Property GetSelectedOrdner() As System.Guid
        Get
            Return Me.GetSelectedOrd()
        End Get
    End Property
    Public Function GetSelectedOrd() As System.Guid
        Dim gen As New GeneralArchiv
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagOrdner As New clTagSchrankFachOrdner
                clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Return clTagOrdner.ID
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("GetSelectedOrd: " + ex.ToString())
        End Try
    End Function
    Public Function GetSelectedOrd_dokument() As System.Guid
        Dim gen As New GeneralArchiv
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagDoku As New clTagSchrankFachOrdner
                clTagDoku = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagDoku.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Or clTagDoku.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Dim clTagOrdner As New clTagSchrankFachOrdner
                    clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Parent.Tag
                    Return clTagOrdner.ID
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("GetSelectedOrd_dokument: " + ex.ToString())
        End Try
    End Function
    Public Function deleteSelectedFile() As Boolean
        Dim gen As New GeneralArchiv
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagOrdner As New clTagSchrankFachOrdner
                clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    Me.UTreeOrdner.SelectedNodes(0).Remove()
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("deleteSelectedFile: " + ex.ToString())
        End Try
    End Function
    Public Function GetCheckedOrdner_rek(ByVal first As Boolean, ByVal parent As UltraTreeNode) As ArrayList
        Dim gen As New GeneralArchiv
        Try

            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList

            If first Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If

            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New clTagSchrankFachOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    If item.CheckedState = CheckState.Checked Then
                        arr.Add(clTagOrdner.ID)
                    End If
                End If
                Dim arr_sub As New ArrayList
                arr_sub = Me.GetCheckedOrdner_rek(False, item)
                For Each o As Object In arr_sub
                    arr.Add(o)
                Next
            Next
            Return arr

        Catch ex As Exception
            Throw New Exception("GetCheckedOrdner_rek: " + ex.ToString())
        End Try
    End Function
    Public ReadOnly Property GetSelTagInfo() As clTagSchrankFachOrdner
        Get
            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                Return Nothing
            Else
                Dim clTag As New clTagSchrankFachOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen Or clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    Dim ret As New clFileInfo
                    Return clTag
                Else
                    Return Nothing
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property GetSelTreeNodexy() As UltraTreeNode
        Get
            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                Return Nothing
            Else
                Return Me.UTreeOrdner.SelectedNodes(0)
            End If
        End Get
    End Property

    Public Function DeleteSelectedDokumentBeforeInsert() As Boolean
        Dim gen As New GeneralArchiv
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagParent As New clTagSchrankFachOrdner
                clTagParent = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagParent.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen Then
                    If MsgBox("Wollen Sie die Datei wirklich löschen?" + vbNewLine +
                                "(Diese Datei wurde noch nicht im System gesichert!)", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Me.UTreeOrdner.SelectedNodes(0).Remove()
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DeleteSelectedDokumentBeforeInsert: " + ex.ToString())
        End Try
    End Function

    Public Function getIDOrdner_mitDokumente() As String
        Dim gen As New GeneralArchiv
        Try



        Catch ex As Exception
            Throw New Exception("getIDOrdner_mitDokumente: " + ex.ToString())
        End Try
    End Function
    Public Sub Load_SchränkeFächer(ByVal typ As etyp, ByVal NurDokumenteMitOrdner As Boolean)
        Dim gen As New GeneralArchiv
        Try

            Me.UTreeOrdner.Visible = False
            Me.UTreeOrdner.Nodes.Clear()

            Dim comp As New compSql
            Dim ds_schrank As New dsPlanArchive
            ds_schrank = comp.LesenAlleSchränke()
            For Each r_schrank As dsPlanArchive.tblSchrankRow In ds_schrank.tblSchrank.Rows
                Dim ds_fach As New dsPlanArchive
                ds_fach = comp.LesenAlleFächer(r_schrank.ID)
                Dim item_addSchrank As New UltraTreeNode

                Dim textSchrank As String = ""
                If r_schrank.Extern Then
                    textSchrank = r_schrank.Bezeichnung + " [" + "Extern" + "]"
                Else
                    textSchrank = r_schrank.Bezeichnung
                End If

                item_addSchrank = Me.UTreeOrdner.Nodes.Add(r_schrank.ID.ToString, textSchrank)
                'item_addSchrank.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_Schrank1

                'item_addSchrank.Override.NodeAppearance.Image = handRes.getIcon("schrank16.ico")
                'item_addSchrank.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_Schrank

                Dim clTagSchrank As New clTagSchrankFachOrdner
                clTagSchrank.typ = clTagSchrankFachOrdner.eTyp.typSchrank
                clTagSchrank.ID = r_schrank.ID
                item_addSchrank.Tag = clTagSchrank

                If typ = etyp.Verwaltung Then
                    If r_schrank.Extern Then
                        item_addSchrank.Override.NodeAppearance.ForeColor = System.Drawing.Color.Red
                        'item_addSchrank.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True
                    End If
                End If

                For Each r_fach As dsPlanArchive.tblFachRow In ds_fach.tblFach.Rows
                    Dim item_addFach As New UltraTreeNode

                    Dim textFach As String = ""
                    If r_fach.Extern Then
                        textFach = r_fach.Bezeichnung + " [" + "Extern" + "]"
                    Else
                        textFach = r_fach.Bezeichnung
                    End If

                    item_addFach = item_addSchrank.Nodes.Add(r_fach.ID.ToString, textFach)
                    'item_addFach.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_fach


                    'item_addFach.Override.NodeAppearance.Image = handRes.getIcon("fach16.ico")
                    'item_addFach.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_fach

                    Dim clTagFach As New clTagSchrankFachOrdner
                    clTagFach.typ = clTagSchrankFachOrdner.eTyp.typFach
                    clTagFach.ID = r_fach.ID
                    item_addFach.Tag = clTagFach

                    If typ = etyp.Verwaltung Then
                        If r_fach.Extern Then
                            item_addFach.Override.NodeAppearance.ForeColor = System.Drawing.Color.Red
                            'item_addFach.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True
                        End If
                    End If

                    Me.LoadOrdner_rek(clTagFach.ID, item_addFach, typ)
                Next
            Next
            Me.UTreeOrdner.ExpandAll(ExpandAllType.Always)

            If Me.Typ = etyp.SuchergebnisseAnzeigen Or Me.Typ = etyp.AuswahlSuche Or Me.Typ = etyp.Ablegen Then
                Dim typRecht As String = ""
                If Me.Typ = etyp.AuswahlSuche Or Me.Typ = etyp.SuchergebnisseAnzeigen Then
                    typRecht = "App_ArchivDokumenteSuchen"
                ElseIf Me.Typ = etyp.Ablegen Then
                    typRecht = "App_ArchivDokumenteAblegen"
                End If
                Me.onlyShowOrdnerMitRecht_rek(Me.UTreeOrdner.Nodes, typRecht)
                If NurDokumenteMitOrdner Then
                    Me.onlyShowOrdnerMitDokumente_rek(Me.UTreeOrdner.Nodes)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("Load_SchränkeFächer: " + ex.ToString())
        Finally
            Me.UTreeOrdner.Visible = True
        End Try
    End Sub
    Public Sub LoadOrdner_rek(ByVal IDParent As System.Guid, ByVal itemParent As UltraTreeNode, ByVal typ As etyp)
        Dim gen As New GeneralArchiv
        Try

            Dim comp As New compSql
            Dim ds_schrank As New dsPlanArchive
            ds_schrank = comp.LesenAlleOrdner(IDParent)
            For Each r_ordner As dsPlanArchive.tblOrdnerRow In ds_schrank.tblOrdner.Rows
                Dim bAddOrdnerToTree As Boolean = True
                If typ = etyp.SuchergebnisseAnzeigen Then
                    bAddOrdnerToTree = False
                    For Each r_ergebnisse As dsPlanArchive.tblDokumenteSuchenRow In Me.dataDokuErgebnisse.tblDokumenteSuchen.Rows
                        If r_ergebnisse.IDOrdner.Equals(r_ordner.ID) Then
                            bAddOrdnerToTree = True
                            Exit For
                        End If
                    Next
                End If
                'If bAddOrdnerToTree Then
                Dim ds_ordner As New dsPlanArchive
                ds_ordner = comp.LesenAlleFächer(r_ordner.ID)

                Dim textOrdner As String = ""
                If Me.Typ <> etyp.Verwaltung Then
                    If r_ordner.Extern Then
                        textOrdner = r_ordner.Bezeichnung + " [" + "Extern" + "]"
                    Else
                        textOrdner = r_ordner.Bezeichnung
                    End If
                Else
                    textOrdner = r_ordner.Bezeichnung
                End If

                Dim itemOrdner As New UltraTreeNode
                If typ <> etyp.Verwaltung And typ <> etyp.SuchergebnisseAnzeigen And (r_ordner.IDSystemordner = 1 Or r_ordner.IDSystemordner = 2) Then
                Else
                    itemOrdner = itemParent.Nodes.Add(r_ordner.ID.ToString, textOrdner)
                    Dim clTagOrdner As New clTagSchrankFachOrdner
                    clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typOrdner
                    clTagOrdner.ID = r_ordner.ID
                    clTagOrdner.IDSystemordner = r_ordner.IDSystemordner
                    itemOrdner.Tag = clTagOrdner

                    If clTagOrdner.IDSystemordner = 1 Then
                        ' itemOrdner.Override.NodeAppearance.Image = handRes.getIcon("papierkorb.ico")
                        'itemOrdner.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_Papierkorb_leer
                    ElseIf clTagOrdner.IDSystemordner = 2 Then
                        'itemOrdner.Override.NodeAppearance.Image = handRes.getIcon("SysPlanungssystem.ico")
                        'itemOrdner.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_termin
                        'ElseIf clTagOrdner.IDSystemordner = 3 Then
                        '    itemOrdner.Override.NodeAppearance.Image = handRes.getIcon("SysAutoBerichte.ico")
                    Else
                        ' itemOrdner.Override.NodeAppearance.Image = handRes.getIcon("ordner16.ico")
                        itemOrdner.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Ordner, 32, 32)
                    End If

                    If typ = etyp.Verwaltung Then
                        If r_ordner.Extern Then
                            itemOrdner.CheckedState = CheckState.Checked
                            itemOrdner.Override.NodeAppearance.ForeColor = System.Drawing.Color.Red
                        Else
                            itemOrdner.CheckedState = CheckState.Unchecked
                            itemOrdner.Override.NodeAppearance.ForeColor = System.Drawing.Color.Black
                        End If

                    End If

                    If typ = etyp.SuchergebnisseAnzeigen Then
                        If Me.checkRechtOrdner_DokumenteAnzeigen(r_ordner.ID) Then
                            Me.LoadDokumente(itemOrdner, r_ordner)
                        End If
                    End If
                    If typ = etyp.Verwaltung Then Me.loadGruppen(itemOrdner, r_ordner)
                End If

                LoadOrdner_rek(r_ordner.ID, itemOrdner, typ)
            Next

        Catch ex As Exception
            Throw New Exception("LoadOrdner_rek: " + ex.ToString())
        End Try
    End Sub
    Public Function loadGruppen(ByRef node As UltraTreeNode, ByRef r_ordner As dsPlanArchive.tblOrdnerRow) As Boolean
        Dim gen As New GeneralArchiv
        Try
            For Each r_gruppe As dsPlanArchive.tblGruppenRow In Me.dsGruppenDB.tblGruppen
                Dim itemNeu As New UltraTreeNode
                Dim clTag As New clTagSchrankFachOrdner
                clTag.ID = r_gruppe.ID
                clTag.typ = clTagSchrankFachOrdner.eTyp.typGruppeRecht
                itemNeu.Text = r_gruppe.Bezeichnung
                itemNeu.Key = System.Guid.NewGuid.ToString  ' r_gruppe.ID.ToString
                itemNeu.Tag = clTag

                'itemNeu.Override.NodeAppearance.Image = handRes.getIcon("recht.ico")
                itemNeu.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Rechte, 32, 32)

                node.Nodes.Add(itemNeu)
                Dim compRecht As New compSql
                If compRecht.getRechtOrdnerGruppe(r_ordner.ID, r_gruppe.ID) Then
                    itemNeu.CheckedState = CheckState.Checked
                Else
                    itemNeu.CheckedState = CheckState.Unchecked
                End If
                node.ExpandAll(ExpandAllType.Always)
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("loadGruppen: " + ex.ToString())
        End Try
    End Function

    Public Sub LoadDokumente(ByRef node As UltraTreeNode, ByRef r_ordner As dsPlanArchive.tblOrdnerRow)
        Dim gen As New GeneralArchiv
        Try

            For Each r_ergebnisse As dsPlanArchive.tblDokumenteSuchenRow In Me.dataDokuErgebnisse.tblDokumenteSuchen.Rows
                If LCase(r_ergebnisse.IDOrdner.ToString) = LCase(r_ordner.ID.ToString) Then
                    Dim FileToAdd As New clFileInfo
                    FileToAdd.file_Bezeichnung = r_ergebnisse.Bezeichnung
                    FileToAdd.file_erstelltAm = r_ergebnisse.ErstelltAm
                    FileToAdd.file_geändertAm = r_ergebnisse.DokumentGeändert
                    FileToAdd.file_größe = r_ergebnisse.DokumentGröße
                    Dim IDOrdner As New System.Guid(r_ergebnisse.IDOrdner)
                    FileToAdd.file_IDOrdner = IDOrdner
                    FileToAdd.file_name = r_ergebnisse.DateinameOrig
                    FileToAdd.file_origVerzeichnis = r_ergebnisse.VerzeichnisOrig
                    FileToAdd.file_typ = r_ergebnisse.DateinameTyp
                    Dim IDDokumenteintrag As New System.Guid(r_ergebnisse.IDDokumenteintrag)
                    Me.AddDokumente_item(FileToAdd, node, IDDokumenteintrag)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("LoadDokumente: " + ex.ToString())
        End Try
    End Sub

    Public Function DeleteDokument(ByVal ID As System.Guid, ByVal first As Boolean, ByVal parent As UltraTreeNode) As Boolean
        Dim gen As New GeneralArchiv
        Try

            Dim coll As TreeNodesCollection
            If first Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If
            For Each item As UltraTreeNode In coll
                Dim cltag As New clTagSchrankFachOrdner
                cltag = item.Tag
                If cltag.ID.ToString = ID.ToString Then
                    item.Remove()
                    Return True
                End If
                If Me.DeleteDokument(ID, False, item) Then Return True
            Next

        Catch ex As Exception
            Throw New Exception("DeleteDokument: " + ex.ToString())
        End Try
    End Function

    Public Sub OrdnerNeu()
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim data As New dsPlanArchive
            Dim r_ordner As dsPlanArchive.tblOrdnerRow
            Dim comp As New compSql

            r_ordner = data.tblOrdner.NewRow
            gen.initRow(r_ordner)

            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                MsgBox("Es wurde keine Auswahl getroffen!", MsgBoxStyle.Information, "Archivsystem")
                Exit Sub
            End If
            Dim clTagParent As New clTagSchrankFachOrdner
            clTagParent = Me.UTreeOrdner.ActiveNode.Tag
            If clTagParent.typ = clTagSchrankFachOrdner.eTyp.typSchrank Then
                MsgBox("Bitte Fach/Ordner auswählen!", MsgBoxStyle.Information, "Archivsystem")
                Exit Sub
            End If

            r_ordner.ID = System.Guid.NewGuid
            r_ordner.IDFach = clTagParent.ID
            r_ordner.Bezeichnung = "Ordnername"

            r_ordner.ErstelltVon = usr.actUser
            r_ordner.ErstelltAm = Now
            r_ordner.IDSystemordner = -1
            comp.insertOrdner(r_ordner)

            Dim itemNeu As New UltraTreeNode
            Dim clTag As New clTagSchrankFachOrdner
            clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner
            clTag.ID = r_ordner.ID

            itemNeu.Key = r_ordner.ID.ToString
            itemNeu.Text = r_ordner.Bezeichnung
            itemNeu.Tag = clTag

            'itemNeu.Override.NodeAppearance.Image = handRes.getIcon("ordner16.ico")
            itemNeu.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Ordner, 32, 32)
            Me.UTreeOrdner.SelectedNodes(0).Nodes.Add(itemNeu)
            Me.UTreeOrdner.SelectedNodes(0).ExpandAll(ExpandAllType.Always)
            Me.UTreeOrdner.SelectedNodes.Clear()
            itemNeu.Selected = True
            Me.cboSystemordner.Value = -1

        Catch ex As Exception
            Throw New Exception("OrdnerNeu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function updateOrdner(ByVal typ As eTypSaveOrdner, ByVal IDOrdner As System.Guid, ByVal IDParent As System.Guid, ByVal Bezeichnung As String,
                                    ByVal Extern As Boolean, ByVal IDSystemordner As Integer) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim data As New dsPlanArchive
            Dim r_ordner As dsPlanArchive.tblOrdnerRow
            Dim comp As New compSql

            r_ordner = data.tblOrdner.NewRow
            gen.initRow(r_ordner)

            r_ordner.ID = IDOrdner
            r_ordner.IDFach = IDParent
            r_ordner.Bezeichnung = Bezeichnung
            r_ordner.Extern = Extern
            r_ordner.ErstelltVon = usr.actUser
            r_ordner.ErstelltAm = Now
            If IDSystemordner <> 1 And IDSystemordner <> 2 Then IDSystemordner = -1
            r_ordner.IDSystemordner = IDSystemordner

            If typ = eTypSaveOrdner.gesamteOrdner Then
                If comp.updateOrdner(r_ordner) Then
                    Return True
                End If
            ElseIf typ = eTypSaveOrdner.nurExtern Then
                If comp.updateOrdnerExternIntern(r_ordner.ID, r_ordner.Extern) Then
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("updateOrdner: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Sub clearSystemordnerInDatabase(ByVal IDSystemordner As Integer)
        Dim gen As New GeneralArchiv
        Try

            Dim comp As New compSql
            comp.updateOrdner_CleyrSystemordner(IDSystemordner)

        Catch ex As Exception
            Throw New Exception("clearSystemordnerInDatabase: " + ex.ToString())
        End Try
    End Sub
    Public Function deleteOrdner(ByVal IDOrdner As System.Guid) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim comp As New compSql
            If comp.deleteOrdner(IDOrdner) Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("deleteOrdner: " + ex.ToString())
        End Try
    End Function



    Private Sub UTreeOrdner_AfterLabelEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles UTreeOrdner.AfterLabelEdit
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.Focused Then
                Me.UpdateOrdnerMain(e.TreeNode, eTypSaveOrdner.gesamteOrdner, False, False, False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_BeforeLabelEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.CancelableNodeEventArgs) Handles UTreeOrdner.BeforeLabelEdit
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(e.TreeNode) Then
                e.Cancel = True
                Exit Sub
            End If
            If Me.Typ = etyp.Verwaltung Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = e.TreeNode.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Me.BezeichnungAlt = e.TreeNode.Text
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            ElseIf Me.Typ = etyp.Ablegen Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = e.TreeNode.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            ElseIf Me.Typ = etyp.SuchergebnisseAnzeigen Then
                e.Cancel = True
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function AddDokumenteToInsert(ByRef fileInfo As clFileInfo) As Boolean
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                MsgBox("Keine Auswahl getroffen!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            Me.AddDokumente_item(fileInfo, Me.UTreeOrdner.SelectedNodes(0), Nothing)
            Return True

        Catch ex As Exception
            Throw New Exception("AddDokumenteToInsert: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Function AddDokumente_item(ByRef fileInfo As clFileInfo, ByRef node As UltraTreeNode, ByVal IDDokumenteintrag As System.Guid) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim clTagParent As New clTagSchrankFachOrdner
            clTagParent = node.Tag
            If clTagParent.typ = clTagSchrankFachOrdner.eTyp.typSchrank Or clTagParent.typ = clTagSchrankFachOrdner.eTyp.typFach Then
                MsgBox("Wählen Sie bitte einen Ordner aus!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            Dim itemNeu As New UltraTreeNode
            Dim clTag As New clTagSchrankFachOrdner
            If Not gen.IsNull(IDDokumenteintrag) Then
                clTag.ID = IDDokumenteintrag
                clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen
                itemNeu.Text = fileInfo.file_Bezeichnung
            Else
                clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen
                itemNeu.Text = fileInfo.file_name
            End If

            clTag.fileInfo = fileInfo
            clTag.fileInfo.file_IDOrdner = clTagParent.ID
            itemNeu.Key = System.Guid.NewGuid.ToString
            itemNeu.Tag = clTag

            If Me.Typ = etyp.Ablegen Then
                Me.initTree_icons(False)
            Else
                Me.initTree_icons(True)
            End If

            'cl.getIcontForFileTyp(LCase(clTag.fileInfo.file_typ), itemNeu)
            itemNeu.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)

            node.Nodes.Add(itemNeu)
            node.ExpandAll(ExpandAllType.Always)
            'itemNeu.Selected = True

            Return True

        Catch ex As Exception
            Throw New Exception("AddDokumente_item: " + ex.ToString())
        End Try
    End Function
    Public Function GetFileInfoDateiAblegen_rek(ByVal itemParent As UltraTreeNode, ByVal root As Boolean) As ArrayList
        Dim gen As New GeneralArchiv
        Try

            Dim ret As New ArrayList
            Dim coll As TreeNodesCollection
            If root Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = itemParent.Nodes
            End If
            For Each item As Infragistics.Win.UltraWinTree.UltraTreeNode In coll
                Dim clTag As New clTagSchrankFachOrdner
                clTag = item.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen Then
                    If gen.IsNull(Trim(item.Text)) Then
                        clTag.fileInfo.file_Bezeichnung = Trim(clTag.fileInfo.file_name)
                    Else
                        clTag.fileInfo.file_Bezeichnung = Trim(item.Text)
                    End If
                    ret.Add(clTag.fileInfo)
                End If
                Dim ret_det As New ArrayList
                ret_det = Me.GetFileInfoDateiAblegen_rek(item, False)
                For Each c As clFileInfo In ret_det
                    ret.Add(c)
                Next
            Next
            Return ret

        Catch ex As Exception
            Throw New Exception("GetFileInfoDateiAblegen_rek: " + ex.ToString())
        End Try
    End Function

    Private Sub ArchivOrdner_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub ResizeControl(ByVal w As Double, ByVal h As Double)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Width = w
            Me.Height = h

        Catch ex As Exception
            Throw New Exception("ResizeControl: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTreeOrdner.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Typ = etyp.SuchergebnisseAnzeigen Or Me.Typ = etyp.Ablegen Then
                Me.delClick.UseDelegate()
            ElseIf Me.Typ = etyp.Verwaltung Then
                Dim clTag As New clTagSchrankFachOrdner
                If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                    clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                    Me.cboSystemordner.Value = clTag.IDSystemordner
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_AfterCheck(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles UTreeOrdner.AfterCheck
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.Focused Then
                '    If Not gen.IsNull(e.TreeNode) Then
                '        Dim ui As New UI
                '        Dim clTag As New S2ArchivWork.clTagSchrankFachOrdner
                '        clTag = e.TreeNode.Tag
                '        If clTag.typ = S2ArchivWork.clTagSchrankFachOrdner.eTyp.typOrdner Then
                Me.UpdateOrdnerMain(e.TreeNode, eTypSaveOrdner.nurExtern, False, False, False)
                '        Else
                '            MsgBox(ui.GetResString("KeinOrdnerAusgewählt"), MsgBoxStyle.Information, "Archivsystem")
                '        End If
                '    End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_BeforeCheck(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.BeforeCheckEventArgs) Handles UTreeOrdner.BeforeCheck
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.Focused Then
                If Not gen.IsNull(e.TreeNode) Then
                    Dim clTag As New clTagSchrankFachOrdner
                    clTag = e.TreeNode.Tag
                    If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Or clTag.typ = clTagSchrankFachOrdner.eTyp.typGruppeRecht Then
                    Else
                        MsgBox("Es wurde kein Ordner bzw. keine Gruppe ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function UpdateOrdnerMain(ByRef node As UltraTreeNode, ByVal typ As eTypSaveOrdner, ByVal doUpdateSameBezeichnung As Boolean,
                                ByVal neuLaden As Boolean, ByVal systemordnerÄndern As Boolean)
        Dim gen As New GeneralArchiv
        Try
            If Me.Typ <> etyp.Verwaltung Then Exit Function
            If Not gen.IsNull(node) Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = node.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    If gen.IsNull(node.Text) Then
                        MsgBox("Es wurde keine Bezeichnung eingegeben!", MsgBoxStyle.Information, "Archivsystem")
                        node.Text = Me.BezeichnungAlt
                        Exit Function
                    End If
                    If Me.BezeichnungAlt = node.Text Then
                        If Not doUpdateSameBezeichnung Then Exit Function
                    End If
                    Dim clTagParent As New clTagSchrankFachOrdner
                    clTagParent = node.Parent.Tag
                    Dim bChecked As Boolean = False
                    If node.CheckedState = CheckState.Checked Then
                        bChecked = True
                    ElseIf node.CheckedState = CheckState.Unchecked Then
                        bChecked = False
                    End If
                    If Me.cboSystemordner.Value = 1 Or Me.cboSystemordner.Value = 2 Then
                        Me.clearSystemordnerInDatabase(Me.cboSystemordner.Value)
                    End If

                    If Me.updateOrdner(typ, clTag.ID, clTagParent.ID, node.Text, bChecked, Me.cboSystemordner.Value) Then
                        Dim infoText As String = ""
                        If node.CheckedState = CheckState.Checked Then
                            node.Override.NodeAppearance.ForeColor = System.Drawing.Color.Red
                            infoText = "  - externer Ordner!"
                        ElseIf node.CheckedState = CheckState.Unchecked Then
                            node.Override.NodeAppearance.ForeColor = System.Drawing.Color.Black
                            infoText = "  - interner Ordner!"
                        End If
                        clTag.IDSystemordner = Me.cboSystemordner.Value
                        node.Tag = clTag
                        Me.UTreeOrdner.SelectedNodes.Clear()
                        node.Selected = True
                        If systemordnerÄndern Then
                            MsgBox("Der Systemordner wurde gespeichert!", MsgBoxStyle.Information, "Archivsystem")
                        Else
                            MsgBox("Der Ordner wurde gespeichert", MsgBoxStyle.Information, "Archivsystem")
                        End If

                        If neuLaden Then
                            Me.LoadOrdnerbaum(etyp.Verwaltung, Nothing)
                        End If
                        Return True
                    End If

                ElseIf clTag.typ = clTagSchrankFachOrdner.eTyp.typGruppeRecht Then
                    Dim clTagParent As New clTagSchrankFachOrdner
                    clTagParent = node.Parent.Tag
                    If node.CheckedState = CheckState.Checked Then
                        Dim comp As New compSql
                        comp.writeRecht(clTagParent.ID, clTag.ID, True)
                    ElseIf node.CheckedState = CheckState.Unchecked Then
                        Dim comp As New compSql
                        comp.writeRecht(clTagParent.ID, clTag.ID, False)
                    End If
                    MsgBox("Recht wurde gesetzt!", MsgBoxStyle.Information, "Archivsystem")

                Else
                    MsgBox("Es wurde kein Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                    Return False

                End If
            End If

        Catch ex As Exception
            Throw New Exception("UpdateOrdnerMain: " + ex.ToString())
        End Try
    End Function


    Public Function VerzeichnisRausspielen(ByVal typ As eDateiRausspielenName) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim IDOrdner As New System.Guid
            IDOrdner = Me.GetSelectedOrd
            If gen.IsNull(IDOrdner) Then
                MsgBox("Keinen Ordner für den Export ausgewählt!", MsgBoxStyle.Information, "Archiv exportieren")
                Exit Function
            End If

            Me.FolderBrowserDialog.ShowDialog()
            If Not gen.IsNull(FolderBrowserDialog.SelectedPath) Then
                If Not System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath) Then
                    Exit Function
                End If
                If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                    Me.protokoll = ""
                    Me.err_DateiRausspielen = 0
                    Dim pathFirst As String = FolderBrowserDialog.SelectedPath + "\" + Me.UTreeOrdner.SelectedNodes(0).Text
                    If Not System.IO.Directory.Exists(pathFirst) Then
                        System.IO.Directory.CreateDirectory(pathFirst)
                    End If
                    Me.VerzeichnisRausspielen_rek(Me.UTreeOrdner.SelectedNodes(0), pathFirst, typ)
                    Me.VerzeichnisRausspielen_rek(Me.UTreeOrdner.SelectedNodes(0), pathFirst, typ)
                    If Me.err_DateiRausspielen = 0 Then
                        MsgBox("Das Verzeichnis wurde exportiert!", MsgBoxStyle.Information, "Archivsystem")
                    Else
                        MsgBox("Das Verzeichnis wurde exportiert!" + vbNewLine +
                                               "(" + Me.err_DateiRausspielen.ToString + " Dateien konnte nicht rausgespielt werden!)", MsgBoxStyle.Information, "Archivsystem")
                    End If
                Else
                    MsgBox("Es wurde kein Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("VerzeichnisRausspielen: " + ex.ToString())
        End Try
    End Function
    Public Sub VerzeichnisRausspielen_rek(ByVal parent As UltraTreeNode, ByVal currentDir As String, ByVal typ As eDateiRausspielenName)
        Dim gen As New GeneralArchiv
        Try
            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList
            coll = parent.Nodes

            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New clTagSchrankFachOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typSchrank Or
                            clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typFach Or
                            clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then

                    If Not System.IO.Directory.Exists(currentDir + "\" + item.Text) Then
                        System.IO.Directory.CreateDirectory(currentDir + "\" + item.Text)
                    End If
                    Me.VerzeichnisRausspielen_rek(item, currentDir + "\" + item.Text, typ)

                ElseIf clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    If Not Me.DateiRausspielen(clTagOrdner.ID, currentDir, typ) Then
                        Me.err_DateiRausspielen += 1
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("VerzeichnisRausspielen_rek: " + ex.ToString())
        End Try
    End Sub
    Public Function DateiRausspielen(ByVal IDDokumenteintrag As System.Guid, ByVal currentDirToSave As String,
                                        ByVal typ As eDateiRausspielenName) As Boolean
        Dim gen As New GeneralArchiv
        Try

            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compSql
                Dim r_Dokumenteintrag As dsPlanArchive.tblDokumenteintragRow
                r_Dokumenteintrag = comp.LesenDokumenteintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumenteintrag) Then
                    Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(r_Dokumenteintrag.ID)
                    If Not gen.IsNull(r_Dokumente) Then
                        Dim compPfad As New compSql
                        Dim dateiArchiv As String = compPfad.pfadLesen + "\" + r_Dokumente.Archivordner + "\" + r_Dokumente.DateinameArchiv
                        Dim clOpen As New clFolder
                        If System.IO.File.Exists(dateiArchiv) Then
                            If typ = eDateiRausspielenName.Bezeichnung Then
                                System.IO.File.Copy(dateiArchiv, currentDirToSave + "\" + r_Dokumenteintrag.Bezeichnung + "." + r_Dokumente.DateinameTyp)
                                Return True
                            ElseIf typ = eDateiRausspielenName.originalName Then
                                System.IO.File.Copy(dateiArchiv, currentDirToSave + "\" + r_Dokumente.DateinameOrig)
                                Return True
                            End If
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiRausspielen: " + ex.ToString())
        End Try
    End Function

    Public Function checkRechtOrdner_DokumenteAnzeigen(ByRef IDOrdner As System.Guid) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Return True

        Catch ex As Exception
            Throw New Exception("checkRechtOrdner_DokumenteAnzeigen: " + ex.ToString())
        End Try
    End Function
    Public Function onlyShowOrdnerMitRecht_rek(ByRef nodes As TreeNodesCollection, ByVal typRecht As String) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim hasRight As Boolean = False
            For Each node As UltraTreeNode In nodes
                Dim clTag As New clTagSchrankFachOrdner
                clTag = node.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    node.Visible = True
                Else
                    node.Visible = False
                End If

                If Me.onlyShowOrdnerMitRecht_rek(node.Nodes, typRecht) Then
                    hasRight = True
                    node.Visible = True
                End If

                If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    hasRight = True
                    node.Visible = True
                End If
            Next
            Return hasRight

        Catch ex As Exception
            Throw New Exception("onlyShowOrdnerMitRecht_rek: " + ex.ToString())
        End Try
    End Function
    Public Function onlyShowOrdnerMitDokumente_rek(ByRef nodes As TreeNodesCollection) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim hasDokumente As Boolean = False
            For Each node As UltraTreeNode In nodes
                node.Visible = False
                Dim clTag As New clTagSchrankFachOrdner
                clTag = node.Tag
                If Me.onlyShowOrdnerMitDokumente_rek(node.Nodes) Then
                    hasDokumente = True
                    node.Visible = True
                End If
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    hasDokumente = True
                    node.Visible = True
                End If
            Next
            Return hasDokumente

        Catch ex As Exception
            Throw New Exception("onlyShowOrdnerMitDokumente_rek: " + ex.ToString())
        End Try
    End Function

    Private Sub RButtonOrdnerMitDokumente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub RButtonAlleOrdner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UTreeOrdner.MouseDown
        Dim gen As New GeneralArchiv
        Try
            If Not gen.IsNull(Me.modalusrCont) Then
                Me.modalusrCont.acP = e.Location
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.delMouseUp.UseDelegate()

                'ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                '    Dim cTag As New clTagSchrankFachOrdner
                '    cTag = Me.GetSelTagInfo
                '    If gen.IsNull(cTag) Then Exit Sub
                '    If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                '        If Not gen.IsNull(cTag.ID) Then
                '            If Not gen.IsNull(cTag.ID) Then
                '                If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                '                    'Me.DokumentInZwischenablageLegen(cTag.ID, "O")
                '                    Me.UTreeOrdner.DoDragDrop(cTag.ID.ToString, DragDropEffects.Copy)
                '                Else
                '                    MsgBox("Sie haben keine Datei ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                '                End If
                '            End If
                '        End If
                '    End If

            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Private Sub UTreeOrdner_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeOrdner.DragEnter
        Dim gen As New GeneralArchiv
        Try
            'Dim gen As New GeneralArchiv
            'Try
            '    Me.Cursor = Cursors.WaitCursor

            '    ' See if the data includes text.
            '    If e.Data.GetDataPresent(DataFormats.Text) Then
            '        ' There is text. Allow copy.
            '        e.Effect = DragDropEffects.Copy
            '    Else
            '        ' There is no text. Prohibit drop.
            '        e.Effect = DragDropEffects.None
            '    End If

            'Catch ex As Exception
            '    gen.GetEcxeptionArchiv(ex)
            'Finally
            '    Me.Cursor = Cursors.Default
            'End Try

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Private Sub UTreeOrdner_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeOrdner.DragDrop
        Dim gen As New GeneralArchiv
        Try
            'Dim gen As New GeneralArchiv
            'Try
            '    Me.Cursor = Cursors.WaitCursor

            '    Me.fileDragDrop = ""
            '    If Me.Typ = etyp.Ablegen Then
            '        If gen.IsNull(e.Data.GetData(DataFormats.Text).ToString()) Then Exit Sub
            '        Me.fileDragDrop = e.Data.GetData(DataFormats.Text).ToString()
            '        Me.delDragDrop.UseDelegate()
            '    End If

            'Catch ex As Exception
            '    gen.GetEcxeptionArchiv(ex)
            'Finally
            '    Me.Cursor = Cursors.Default
            'End Try

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Private Sub NeuenOrdnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuenOrdnerToolStripMenuItem.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typFach Or
                        clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Me.OrdnerNeu()
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub OrdnerLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdnerLöschenToolStripMenuItem.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Dim clTagParent As New clTagSchrankFachOrdner
                    If MsgBox("Wollen Sie den Ordner wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        If Me.deleteOrdner(clTag.ID) Then
                            Me.UTreeOrdner.SelectedNodes(0).Remove()
                            MsgBox("Der Ordner wurde gelöscht!", MsgBoxStyle.Information, "Archivsystem")
                        End If
                    End If
                Else
                    MsgBox("Es wurde kein Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub UTreeOrdner_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UTreeOrdner.MouseClick

    End Sub

    Private Sub SystemordnerSpeichern()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim node As Infragistics.Win.UltraWinTree.UltraTreeNode
                node = Me.UTreeOrdner.SelectedNodes(0)
                Dim clTag As New clTagSchrankFachOrdner
                clTag = node.Tag
                If clTag.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    Me.UpdateOrdnerMain(node, eTypSaveOrdner.gesamteOrdner, True, True, True)
                Else
                    MsgBox("Es wurde kein Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
                End If
            Else
                MsgBox("Es wurde kein Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("SystemordnerSpeichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles UTreeOrdner.AfterSelect

    End Sub


    Private Sub UButtonPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.UTreeOrdner.ExpandAll(ExpandAllType.Always)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UButtonMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.UTreeOrdner.CollapseAll()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub SelectOrdner(ByVal IDOrdner As System.Guid)
        Dim gen As New GeneralArchiv
        Try
            Me.Show()
            If gen.IsNull(IDOrdner) Then Exit Sub
            Me.SelectOrdner_rek(Nothing, IDOrdner, True)

        Catch ex As Exception
            Throw New Exception("SelectOrdner: " + ex.ToString())
        End Try
    End Sub
    Public Function SelectOrdner_rek(ByVal parent As UltraTreeNode, ByVal IDOrdner As System.Guid, ByVal firstNode As Boolean) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList
            If firstNode Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If
            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New clTagSchrankFachOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = clTagSchrankFachOrdner.eTyp.typOrdner Then
                    If clTagOrdner.ID.ToString = IDOrdner.ToString Then
                        item.Selected = True
                        Me.Show()
                        'me.MousePosition = item.
                        Return True
                    End If
                End If
                item.Selected = False
                Me.SelectOrdner_rek(item, IDOrdner, False)
            Next

        Catch ex As Exception
            Throw New Exception("SelectOrdner_rek: " + ex.ToString())
        End Try
    End Function

    Private Sub cboSystemordner_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cboSystemordner.EditorButtonClick
        Dim gen As New GeneralArchiv
        Try
            Select Case e.Button.Key
                Case "Speichern"
                    Me.SystemordnerSpeichern()
            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UTreeOrdner_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTreeOrdner.DoubleClick
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Typ = etyp.SuchergebnisseAnzeigen Then
                Dim cTag As New clTagSchrankFachOrdner
                cTag = Me.GetSelTagInfo
                If gen.IsNull(cTag) Then Exit Sub
                If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                    If Not gen.IsNull(cTag.ID) Then
                        If Not gen.IsNull(cTag.ID) Then
                            Me.DokumentÖffnenSpeichern(cTag.ID, "O")
                        End If
                    End If
                End If
            ElseIf Me.Typ = etyp.Verwaltung Then

            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function DokumentÖffnenSpeichern(ByVal IDDokumenteintrag As System.Guid, ByVal action As String) As Boolean
        Dim gen As New GeneralArchiv
        Try

            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Kein Dokumentenpfad im Archiv angegeben!" + vbNewLine +
                       "Bitte dem Administrator melden!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Dokumentenpfad existiert nicht!" + vbNewLine +
                       "Bitte dem Administrator melden!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            'If Not gen.IsNull(Me.UGridDokumenteGefunden.ActiveRow) Then
            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compSql
                Dim r_Dokumenteintrag As dsPlanArchive.tblDokumenteintragRow
                r_Dokumenteintrag = comp.LesenDokumenteintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumenteintrag) Then
                    Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(r_Dokumenteintrag.ID)
                    If Not gen.IsNull(r_Dokumente) Then

                        ' Datei aus Archiv kopieren
                        Dim dateiArchiv As String = compPfad.pfadLesen + "\" + r_Dokumente.Archivordner + "\" + r_Dokumente.DateinameArchiv

                        If action = "O" Then
                            'Datei öffnen
                            Dim clOpen As New clFolder
                            If Not clOpen.openFile(dateiArchiv, False) Then
                                Me.DokumentÖffnenSpeichern(r_Dokumente.IDDokumenteintrag, "S")
                                Exit Function
                            End If

                        ElseIf action = "S" Then
                            Dim clOpen As New clFolder
                            clOpen.DateiSpeichernUnter(dateiArchiv, r_Dokumente.DateinameTyp, True)

                        End If
                    Else
                        MsgBox("Es wurden keine Dokumente gegeben!", MsgBoxStyle.Information, "Archivsystem")
                    End If
                Else
                    MsgBox("Es wurden keine Dokumente gegeben!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If
            'End If

        Catch ex As Exception
            Throw New Exception("DokumentÖffnenSpeichern: " + ex.ToString())
        End Try
    End Function


End Class
