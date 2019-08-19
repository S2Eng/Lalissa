Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms
Imports System.Drawing




Public Class contOrdner2
    Inherits System.Windows.Forms.UserControl

    Public delMouseUp As New dArchiv
    Public delClick As New dArchiv
    Public delDragDrop As New dArchiv

    Public fileDragDrop As String = ""

    Private Typ As New etyp
    Public BezeichnungAlt As String = ""
    Public Enum etyp
        Verwaltung = 0
        AuswahlSuche = 1
        Ablegen = 2
        SuchergebnisseAnzeigen = 3
    End Enum

    Private dsDokuSearch As New dsDokuSearch()
    Private compDoku1 As New compDoku()

    Public modalusrCont As contArchAbleg

    Public Enum eTypSaveOrdner
        gesamteOrdner = 0
        nurExtern = 1
    End Enum
    Public Enum eDateiRausspielenName
        Bezeichnung = 1
        Archivname = 2
    End Enum

    Private protokoll As String = ""
    Private err_DateiRausspielen As Integer = 0
    Private gen As New General
    Private usr As New General
    Public doUI1 As New doUI()

    Public isLoaded As Boolean = False
    Public IsInitializedVisible As Boolean = False



    Friend WithEvents cboSystemordner As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblSystemordner As System.Windows.Forms.Label
    Friend WithEvents CMenuStripOrdner As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NeuenOrdnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuerOrdnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
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
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("Speichern")
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Systemordner", Infragistics.Win.DefaultableBoolean.[Default])
        Me.UTreeOrdner = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.CMenuStripOrdner = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuerOrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuenOrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.UTreeOrdner.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.UTreeOrdner.Size = New System.Drawing.Size(632, 351)
        Me.UTreeOrdner.TabIndex = 0
        Me.UTreeOrdner.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'CMenuStripOrdner
        '
        Me.CMenuStripOrdner.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuerOrdnerToolStripMenuItem, Me.NeuenOrdnerToolStripMenuItem, Me.ToolStripMenuItem1, Me.OrdnerLöschenToolStripMenuItem})
        Me.CMenuStripOrdner.Name = "CMenuStripOrdner"
        Me.CMenuStripOrdner.Size = New System.Drawing.Size(327, 76)
        '
        'NeuerOrdnerToolStripMenuItem
        '
        Me.NeuerOrdnerToolStripMenuItem.Name = "NeuerOrdnerToolStripMenuItem"
        Me.NeuerOrdnerToolStripMenuItem.Size = New System.Drawing.Size(326, 22)
        Me.NeuerOrdnerToolStripMenuItem.Tag = "ResID.CreateANewFolderAtTheTop"
        Me.NeuerOrdnerToolStripMenuItem.Text = "Neuen Ordner ganz oben erstellen"
        '
        'NeuenOrdnerToolStripMenuItem
        '
        Me.NeuenOrdnerToolStripMenuItem.Name = "NeuenOrdnerToolStripMenuItem"
        Me.NeuenOrdnerToolStripMenuItem.Size = New System.Drawing.Size(326, 22)
        Me.NeuenOrdnerToolStripMenuItem.Tag = "ResID.CreateANewFolderBelowTheSelected"
        Me.NeuenOrdnerToolStripMenuItem.Text = "Neuen Ordner unterhalb ausgewählten erstellen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(323, 6)
        '
        'OrdnerLöschenToolStripMenuItem
        '
        Me.OrdnerLöschenToolStripMenuItem.Name = "OrdnerLöschenToolStripMenuItem"
        Me.OrdnerLöschenToolStripMenuItem.Size = New System.Drawing.Size(326, 22)
        Me.OrdnerLöschenToolStripMenuItem.Tag = "ResID.DeleteSelectedFolders"
        Me.OrdnerLöschenToolStripMenuItem.Text = "Ausgewählten Ordner löschen"
        '
        'PanelUnten
        '
        Me.PanelUnten.BackColor = System.Drawing.Color.White
        Me.PanelUnten.Controls.Add(Me.cboSystemordner)
        Me.PanelUnten.Controls.Add(Me.lblSystemordner)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 351)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(632, 30)
        Me.PanelUnten.TabIndex = 1
        Me.PanelUnten.Visible = False
        '
        'cboSystemordner
        '
        Me.cboSystemordner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        EditorButton1.Key = "Speichern"
        EditorButton1.Text = ""
        Me.cboSystemordner.ButtonsRight.Add(EditorButton1)
        Me.cboSystemordner.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = -1
        ValueListItem1.DisplayText = "kein Systemordner"
        ValueListItem3.DataValue = 2
        ValueListItem3.DisplayText = "Anhang"
        Me.cboSystemordner.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem3})
        Me.cboSystemordner.Location = New System.Drawing.Point(447, 4)
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
        Me.lblSystemordner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSystemordner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemordner.Location = New System.Drawing.Point(327, 3)
        Me.lblSystemordner.Name = "lblSystemordner"
        Me.lblSystemordner.Size = New System.Drawing.Size(114, 21)
        Me.lblSystemordner.TabIndex = 386
        Me.lblSystemordner.Tag = "ResID.Systemfolder"
        Me.lblSystemordner.Text = "Systemordner"
        Me.lblSystemordner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSystemordner.Visible = False
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contOrdner2
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.UTreeOrdner)
        Me.Controls.Add(Me.PanelUnten)
        Me.DoubleBuffered = True
        Me.Name = "contOrdner2"
        Me.Size = New System.Drawing.Size(632, 381)
        CType(Me.UTreeOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripOrdner.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUnten.PerformLayout()
        CType(Me.cboSystemordner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region





    Private Sub ArchivOrdner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.cboSystemordner.Value = -1
            Me.cboSystemordner.ButtonsRight(0).Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.NeuerOrdnerToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.NeuenOrdnerToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.OrdnerLöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contOrdner2.initControl: " + ex.ToString())
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
            Throw New Exception("contOrdner2.initTree_icons: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadOrdnerbaum(ByVal typ As etyp, ByVal IDOrdner As System.Guid)
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
                Me.UTreeOrdner.Override.NodeStyle = NodeStyle.CheckBox
                Me.UTreeOrdner.AllowDrop = False
                Me.lblSystemordner.Visible = True
                Me.cboSystemordner.Visible = True
                Me.cboSystemordner.Value = -1
                Me.UTreeOrdner.ContextMenuStrip = Me.CMenuStripOrdner

            End If
            Me.LoadOrdner(typ, False, False)
            Me.SelectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("contOrdner2.LoadOrdnerbaum: " + ex.ToString())
        End Try
    End Sub
    Public Sub hidePanelUnten()
        Try
            Me.PanelUnten.Height = 0

        Catch ex As Exception
            Throw New Exception("contOrdner2.hidePanelUnten: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadSuchergebnis(ByVal dsSearch As dsDokuSearch, ByVal typ As etyp,
                                ByVal NurDokumenteMitOrdner As Boolean, ByVal NurPapierkorb As Boolean)
        Try

            Me.Typ = typ
            If typ = etyp.SuchergebnisseAnzeigen Then
                Me.UTreeOrdner.ContextMenu = Nothing
                Me.UTreeOrdner.Override.SelectionType = SelectType.Single

                'Me.UTreeOrdner.Override.NodeStyle = NodeStyle.CheckBox
                Me.dsDokuSearch = New dsDokuSearch
                Me.dsDokuSearch = dsSearch
                Me.LoadOrdner(typ, NurDokumenteMitOrdner, NurPapierkorb)
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.LoadSuchergebnis: " + ex.ToString())
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
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagOrdner As New General.clTagOrdner
                clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagOrdner.typ = General.clTagOrdner.eTyp.typOrdner Then
                    Return clTagOrdner.ID
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.GetSelectedOrd: " + ex.ToString())
        End Try
    End Function
    Public Function GetSelectedOrd_dokument() As System.Guid
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagDoku As New General.clTagOrdner
                clTagDoku = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagDoku.typ = General.clTagOrdner.eTyp.typDateiSuchen Or clTagDoku.typ = General.clTagOrdner.eTyp.typOrdner Then
                    Dim clTagOrdner As New General.clTagOrdner
                    clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Parent.Tag
                    Return clTagOrdner.ID
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.GetSelectedOrd_dokument: " + ex.ToString())
        End Try
    End Function
    Public Function deleteSelectedFile() As Boolean
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTagOrdner As New General.clTagOrdner
                clTagOrdner = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagOrdner.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                    Me.UTreeOrdner.SelectedNodes(0).Remove()
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.deleteSelectedFile: " + ex.ToString())
        End Try
    End Function
    Public Function GetCheckedOrdner_rek(ByVal first As Boolean, ByVal parent As UltraTreeNode) As ArrayList
        Try

            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList

            If first Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If

            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New General.clTagOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = General.clTagOrdner.eTyp.typOrdner Then
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
            Throw New Exception("contOrdner2.GetCheckedOrdner_rek: " + ex.ToString())
        End Try
    End Function
    Public ReadOnly Property GetSelTagInfo() As General.clTagOrdner
        Get
            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                Return Nothing
            Else
                Dim clTag As New General.clTagOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = General.clTagOrdner.eTyp.typDateiAblegen Or clTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
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
        Try

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then

                Dim clTagParent As New General.clTagOrdner
                clTagParent = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTagParent.typ = General.clTagOrdner.eTyp.typDateiAblegen Then
                    If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                        Me.UTreeOrdner.SelectedNodes(0).Remove()
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.DeleteSelectedDokumentBeforeInsert: " + ex.ToString())
        End Try
    End Function


    Public Sub LoadOrdner(ByVal typ As etyp, ByVal NurDokumenteMitOrdner As Boolean, ByVal NurPapierkorb As Boolean)
        Try
            Me.UTreeOrdner.Visible = False
            Me.UTreeOrdner.Nodes.Clear()
            Me.LoadOrdner_rek(Nothing, Nothing, typ, NurPapierkorb)
            Me.UTreeOrdner.ExpandAll(ExpandAllType.Always)

            If NurDokumenteMitOrdner Then
                Me.onlyShowOrdnerMitDokumente_rek(Me.UTreeOrdner.Nodes)
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.LoadOrdner: " + ex.ToString())
        Finally
            Me.UTreeOrdner.Visible = True
        End Try
    End Sub
    Public Sub LoadOrdner_rek(ByVal IDParent As System.Guid, ByVal itemParent As UltraTreeNode, ByVal typ As etyp,
                              ByVal NurPapierkorb As Boolean)
        Try
            Dim dbOrd As New dbArchiv()
            Me.compDoku1.getOrdner(IDParent, compDoku.eTypSelOrd.idMain, dbOrd)
            For Each r_ordner As dbArchiv.archOrdnerRow In dbOrd.archOrdner.Rows
                If (r_ordner.IDSystemordner <> 1 And Not NurPapierkorb) Or (r_ordner.IDSystemordner = 1 And NurPapierkorb) Then
                    Dim textOrdner As String = ""
                    If Me.Typ <> etyp.Verwaltung Then
                        If r_ordner.Extern Then
                            textOrdner = r_ordner.Bezeichnung + " [" + "" + doUI.getRes("Extern") + "" + "]"
                        Else
                            textOrdner = r_ordner.Bezeichnung
                        End If
                    Else
                        textOrdner = r_ordner.Bezeichnung
                    End If

                    Dim itemOrdner As New UltraTreeNode
                    If typ <> etyp.Verwaltung And typ <> etyp.SuchergebnisseAnzeigen And (r_ordner.IDSystemordner = 1 Or r_ordner.IDSystemordner = 2) Then
                    Else
                        If itemParent Is Nothing Then
                            itemOrdner = Me.UTreeOrdner.Nodes.Add(r_ordner.ID.ToString, textOrdner)
                        Else
                            itemOrdner = itemParent.Nodes.Add(r_ordner.ID.ToString, textOrdner)
                        End If

                        Dim clTagOrdner As New General.clTagOrdner
                        clTagOrdner.typ = General.clTagOrdner.eTyp.typOrdner
                        clTagOrdner.ID = r_ordner.ID
                        clTagOrdner.IDSyOrdner = r_ordner.IDSystemordner
                        itemOrdner.Tag = clTagOrdner

                        If clTagOrdner.IDSyOrdner = 1 Then
                            itemOrdner.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_trash, 32, 32)
                        ElseIf clTagOrdner.IDSyOrdner = 2 Then
                            itemOrdner.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_historie, 32, 32)
                        Else
                            itemOrdner.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_folder, 32, 32)
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
                        If typ = etyp.Verwaltung Then

                        End If
                    End If

                    LoadOrdner_rek(r_ordner.ID, itemOrdner, typ, NurPapierkorb)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contOrdner2.LoadOrdner_rek: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadDokumente(ByRef node As UltraTreeNode, ByRef r_ordner As dbArchiv.archOrdnerRow)
        Try
            Dim arrToDelete As New ArrayList()
            For Each rDoku As dsDokuSearch.archDokuRow In Me.dsDokuSearch.archDoku.Rows
                If rDoku.IDOrdner.ToString = r_ordner.ID.ToString Then
                    Dim FileToAdd As New clFileInfo
                    FileToAdd.file_Bezeichnung = rDoku.Bezeichnung
                    FileToAdd.file_erstelltAm = rDoku.AbgelegtAm
                    FileToAdd.file_größe = rDoku.Größe
                    Dim IDOrdner As New System.Guid(rDoku.IDOrdner.ToString())
                    FileToAdd.file_IDOrdner = IDOrdner
                    FileToAdd.file_typ = rDoku.DateinameTyp
                    Me.AddDokumente_item(FileToAdd, node, rDoku.IDDoku, "")
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contOrdner2.LoadDokumente: " + ex.ToString())
        End Try
    End Sub
    Public Function onlyShowOrdnerMitDokumente_rek(ByRef nodes As TreeNodesCollection) As Boolean
        Try
            Dim hasDokumente As Boolean = False
            For Each node As UltraTreeNode In nodes
                node.Visible = False
                Dim clTag As New General.clTagOrdner
                clTag = node.Tag
                If Me.onlyShowOrdnerMitDokumente_rek(node.Nodes) Then
                    hasDokumente = True
                    node.Visible = True
                End If
                If clTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                    hasDokumente = True
                    node.Visible = True
                End If
            Next
            Return hasDokumente

        Catch ex As Exception
            Throw New Exception("contOrdner2.onlyShowOrdnerMitDokumente_rek: " + ex.ToString())
        End Try
    End Function
    Public Function DeleteDokument(ByVal ID As System.Guid, ByVal first As Boolean, ByVal parent As UltraTreeNode) As Boolean
        Try
            Dim coll As TreeNodesCollection
            If first Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If
            For Each item As UltraTreeNode In coll
                Dim cltag As New General.clTagOrdner
                cltag = item.Tag
                If cltag.ID.ToString = ID.ToString Then
                    item.Remove()
                    Return True
                End If
                If Me.DeleteDokument(ID, False, item) Then Return True
            Next

        Catch ex As Exception
            Throw New Exception("contOrdner2.DeleteDokument: " + ex.ToString())
        End Try
    End Function

    Public Sub OrdnerNeu(ByVal ganzOben As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dbNewOrdner As New dbArchiv()
            Me.compDoku1.getOrdnerRow(System.Guid.NewGuid, compDoku.eTypSelOrd.id, dbNewOrdner)
            Dim rOrd As dbArchiv.archOrdnerRow = Me.compDoku1.getNewRowOrdner(dbNewOrdner)

            If ganzOben Then
                rOrd.SetIDOrdnerMainNull()
            Else
                If Me.UTreeOrdner.ActiveNode Is Nothing Then
                    rOrd.SetIDOrdnerMainNull()
                Else
                    Dim clTagParent As New General.clTagOrdner
                    clTagParent = Me.UTreeOrdner.ActiveNode.Tag
                    rOrd.ID = System.Guid.NewGuid
                    rOrd.IDOrdnerMain = clTagParent.ID
                    If clTagParent.ID.Equals(cArchive.IDPapierkorb) Then
                        MsgBox("Unterhalb des Papierkorbs kann kein Ordner angelegt werden!", MsgBoxStyle.Information, "Archivsystem")
                        Exit Sub
                    End If
                End If
            End If

            rOrd.Bezeichnung = doUI.getRes("NameFolder")

            Dim UserLoggedIn As String = gen.getLoggedInUser()
            rOrd.ErstelltVon = UserLoggedIn.Trim()
            rOrd.ErstelltAm = Now
            rOrd.IDSystemordner = -1

            Me.compDoku1.daOrdner.Update(dbNewOrdner.archOrdner)

            Dim itemNeu As New UltraTreeNode
            Dim clTag As New General.clTagOrdner
            clTag.typ = General.clTagOrdner.eTyp.typOrdner
            clTag.ID = rOrd.ID

            itemNeu.Key = rOrd.ID.ToString
            itemNeu.Text = rOrd.Bezeichnung
            itemNeu.Tag = clTag

            itemNeu.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_folder, 32, 32)
            If ganzOben Then
                Me.UTreeOrdner.Nodes.Add(itemNeu)
            Else
                Me.UTreeOrdner.SelectedNodes(0).Nodes.Add(itemNeu)
                Me.UTreeOrdner.SelectedNodes.Clear()
                itemNeu.Selected = True
                itemNeu.Parent.ExpandAll()
            End If

            itemNeu.Selected = True
            Me.cboSystemordner.Value = -1

        Catch ex As Exception
            Throw New Exception("contOrdner2.OrdnerNeu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function updateOrdner(ByVal typ As eTypSaveOrdner, ByVal IDOrdner As System.Guid, ByVal IDParent As System.Guid, ByVal Bezeichnung As String,
                                    ByVal Extern As Boolean, ByVal IDSystemordner As Integer) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dbNewOrdner As New dbArchiv()
            Dim rOrd As dbArchiv.archOrdnerRow = Me.compDoku1.getOrdnerRow(IDOrdner, compDoku.eTypSelOrd.id, dbNewOrdner)
            rOrd.Bezeichnung = Bezeichnung
            rOrd.Extern = Extern
            If IDSystemordner <> 1 And IDSystemordner <> 2 Then IDSystemordner = -1
            rOrd.IDSystemordner = IDSystemordner
            Me.compDoku1.daOrdner.Update(dbNewOrdner.archOrdner)
            Return True

        Catch ex As Exception
            Throw New Exception("contOrdner2.updateOrdner: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Sub clearSystemordnerInDatabase(ByVal IDSystemordner As Integer)
        Try
            Me.compDoku1.clearSystemordner(IDSystemordner)

        Catch ex As Exception
            Throw New Exception("contOrdner2.clearSystemordnerInDatabase: " + ex.ToString())
        End Try
    End Sub
    Public Function deleteOrdner(ByVal IDOrdner As System.Guid) As Boolean
        Try
            If Me.compDoku1.deleteOrdner(IDOrdner) Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.deleteOrdner: " + ex.ToString())
        End Try
    End Function


    Private Sub UTreeOrdner_AfterLabelEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles UTreeOrdner.AfterLabelEdit
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.Focused Then
                Me.UpdateOrdnerMain(e.TreeNode, eTypSaveOrdner.gesamteOrdner, False, False, False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_BeforeLabelEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.CancelableNodeEventArgs) Handles UTreeOrdner.BeforeLabelEdit
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(e.TreeNode) Then
                e.Cancel = True
                Exit Sub
            End If
            If Me.Typ = etyp.Verwaltung Then
                Dim clTag As New General.clTagOrdner
                clTag = e.TreeNode.Tag
                If clTag.ID.Equals(cArchive.IDPapierkorb) Then
                    e.Cancel = True
                Else
                    If clTag.typ = General.clTagOrdner.eTyp.typOrdner Then
                        Me.BezeichnungAlt = e.TreeNode.Text
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If

            ElseIf Me.Typ = etyp.Ablegen Then
                Dim clTag As New General.clTagOrdner
                clTag = e.TreeNode.Tag
                If clTag.ID.Equals(cArchive.IDPapierkorb) Then
                    e.Cancel = True
                Else
                    If clTag.typ = General.clTagOrdner.eTyp.typDateiAblegen Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If

            ElseIf Me.Typ = etyp.SuchergebnisseAnzeigen Then
                e.Cancel = True
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function AddDokumenteToInsertxy(ByRef fileInfo As clFileInfo, ByRef FileNameSelecteFromDocuNameList As String) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count = 0 Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Return False
            End If
            Me.AddDokumente_item(fileInfo, Me.UTreeOrdner.SelectedNodes(0), Nothing, FileNameSelecteFromDocuNameList)
            Return True

        Catch ex As Exception
            Throw New Exception("contOrdner2.AddDokumenteToInsertxy: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Function AddDokumente_item(ByRef fileInfo As clFileInfo, ByRef node As UltraTreeNode,
                                      ByVal IDDoku As System.Guid, ByRef FileNameSelecteFromDocuNameList As String) As Boolean
        Try
            Dim clTagParent As New General.clTagOrdner
            clTagParent = node.Tag

            Dim itemNeu As New UltraTreeNode
            Dim clTag As New General.clTagOrdner
            If Not gen.IsNull(IDDoku) Then
                clTag.ID = IDDoku
                clTag.typ = General.clTagOrdner.eTyp.typDateiSuchen
                If fileInfo.bezeichnung.Trim() <> "" Then
                    itemNeu.Text = fileInfo.bezeichnung.Trim()
                Else
                    itemNeu.Text = fileInfo.file_Bezeichnung
                End If
            Else
                clTag.typ = General.clTagOrdner.eTyp.typDateiAblegen
                If fileInfo.bezeichnung.Trim() <> "" Then
                    itemNeu.Text = fileInfo.bezeichnung.Trim()
                Else
                    itemNeu.Text = fileInfo.file_name
                End If
            End If

            If FileNameSelecteFromDocuNameList.Trim() <> "" Then
                itemNeu.Text = FileNameSelecteFromDocuNameList.Trim()
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
            itemNeu.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            node.Nodes.Add(itemNeu)
            node.ExpandAll(ExpandAllType.Always)
            'itemNeu.Selected = True

            Return True

        Catch ex As Exception
            Throw New Exception("contOrdner2.AddDokumente_item: " + ex.ToString())
        End Try
    End Function
    Public Function GetFileInfoDateiAblegen_rek(ByVal itemParent As UltraTreeNode, ByVal root As Boolean) As System.Collections.Generic.List(Of clFileInfo)
        Try
            Dim ret As New System.Collections.Generic.List(Of clFileInfo)
            Dim coll As TreeNodesCollection
            If root Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = itemParent.Nodes
            End If
            For Each item As Infragistics.Win.UltraWinTree.UltraTreeNode In coll
                Dim clTag As New General.clTagOrdner
                clTag = item.Tag
                If clTag.typ = General.clTagOrdner.eTyp.typDateiAblegen Then
                    If gen.IsNull(Trim(item.Text)) Then
                        clTag.fileInfo.file_Bezeichnung = Trim(clTag.fileInfo.file_Bezeichnung)
                    Else
                        clTag.fileInfo.file_Bezeichnung = Trim(item.Text)
                    End If
                    ret.Add(clTag.fileInfo)
                End If
                Dim ret_det As New System.Collections.Generic.List(Of clFileInfo)
                ret_det = Me.GetFileInfoDateiAblegen_rek(item, False)
                For Each c As clFileInfo In ret_det
                    ret.Add(c)
                Next
            Next
            Return ret

        Catch ex As Exception
            Throw New Exception("contOrdner2.GetFileInfoDateiAblegen_rek: " + ex.ToString())
        End Try
    End Function

    Private Sub UTreeOrdner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTreeOrdner.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Typ = etyp.SuchergebnisseAnzeigen Or Me.Typ = etyp.Ablegen Then
                Me.delClick.UseDelegate()
            ElseIf Me.Typ = etyp.Verwaltung Then
                Dim clTag As New General.clTagOrdner
                If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                    clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                    Me.cboSystemordner.Value = clTag.IDSyOrdner
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_AfterCheck(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles UTreeOrdner.AfterCheck
        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.Focused Then
                '    If Not gen.IsNull(e.TreeNode) Then
                '        Dim ui As New UI
                '        Dim clTag As New S2ArchivITSCont.core.SystemDb.clTagOrdner
                '        clTag = e.TreeNode.Tag
                '        If clTag.typ = S2ArchivITSCont.core.SystemDb.clTagOrdner.eTyp.typOrdner Then
                Me.UpdateOrdnerMain(e.TreeNode, eTypSaveOrdner.nurExtern, False, False, False)
                '        Else
                '            MsgBox(ui.GetResString("KeinOrdnerAusgewählt"), MsgBoxStyle.Information, "Archivsystem")
                '        End If
                '    End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_BeforeCheck(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.BeforeCheckEventArgs) Handles UTreeOrdner.BeforeCheck
        Try
            Me.Cursor = Cursors.WaitCursor

            'If Me.UTreeOrdner.Focused Then
            '    If Not gen.IsNull(e.TreeNode) Then
            '        Dim ui As New UI
            '        Dim clTag As New ITSCont.core.SystemDb.clTagOrdner
            '        clTag = e.TreeNode.Tag
            '        MsgBox("Es wurde kein Ordner bzw. keine Gruppe ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
            '        e.Cancel = True
            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function UpdateOrdnerMain(ByRef node As UltraTreeNode, ByVal typ As eTypSaveOrdner, ByVal doUpdateSameBezeichnung As Boolean,
                                ByVal neuLaden As Boolean, ByVal systemordnerÄndern As Boolean) As Boolean
        Try
            If Me.Typ <> etyp.Verwaltung Then Exit Function
            If Not gen.IsNull(node) Then

                Dim clTag As New General.clTagOrdner
                clTag = node.Tag
                If clTag.typ = General.clTagOrdner.eTyp.typOrdner Then

                    If clTag.ID.Equals(cArchive.IDPapierkorb) Then
                        Return False
                    End If

                    If gen.IsNull(node.Text) Then
                        doUI.doMessageBox2("DescriptionInputRequired", "", "!")
                        node.Text = Me.BezeichnungAlt
                        Exit Function
                    End If
                    If Me.BezeichnungAlt = node.Text Then
                        If Not doUpdateSameBezeichnung Then Exit Function
                    End If

                    Dim clTagParent As New General.clTagOrdner
                    If Not node.Parent Is Nothing Then
                        clTagParent = node.Parent.Tag
                        If Me.cboSystemordner.Value = 2 Then
                            Me.clearSystemordnerInDatabase(Me.cboSystemordner.Value)
                        End If
                    End If

                    If Me.updateOrdner(typ, clTag.ID, clTagParent.ID, node.Text, node.CheckedState, Me.cboSystemordner.Value) Then
                        Dim infoText As String = ""
                        If node.CheckedState = CheckState.Checked Then
                            node.Override.NodeAppearance.ForeColor = System.Drawing.Color.Red
                            infoText = doUI.getRes("ExternFolder")
                        ElseIf node.CheckedState = CheckState.Unchecked Then
                            node.Override.NodeAppearance.ForeColor = System.Drawing.Color.Black
                            infoText = doUI.getRes("InternFolder")
                        End If
                        clTag.IDSyOrdner = Me.cboSystemordner.Value
                        node.Tag = clTag
                        Me.UTreeOrdner.SelectedNodes.Clear()
                        node.Selected = True
                        If systemordnerÄndern Then
                            doUI.doMessageBox2("TheSystemFolderWasSaved", "", "!")
                        Else
                            'MsgBox("Der Ordner wurde gespeichert" + _
                            '       If(node.CheckedState = CheckState.Checked, vbNewLine + "(Hinweis: Externer Ordner)", ""), _
                            '       MsgBoxStyle.Information, "Archivsystem")
                        End If

                        If neuLaden Then
                            Me.LoadOrdnerbaum(etyp.Verwaltung, Nothing)
                        End If
                        Return True
                    End If

                Else
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Return False
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.UpdateOrdnerMain: " + ex.ToString())
        End Try
    End Function


    Public Function VerzeichnisRausspielen(ByVal typ As eDateiRausspielenName) As Boolean
        Try
            Dim IDOrdner As New System.Guid
            IDOrdner = Me.GetSelectedOrd
            If gen.IsNull(IDOrdner) Then
                doUI.doMessageBox2("NoFolderSelected", "", "!")
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
                        doUI.doMessageBox2("TheFolderWasExported", "", "!")
                    Else
                        Dim txtNotSaved As String = doUI.getRes("XFilesCoudNotBeSaved")
                        txtNotSaved = String.Format(txtNotSaved, Me.err_DateiRausspielen.ToString)
                        Dim resTxt As String = doUI.getRes("TheFolderWasExported") + vbNewLine +
                                               "(" + txtNotSaved + ")"
                        doUI.doMessageBoxTranslated(resTxt, "", "!")
                    End If
                Else
                    doUI.doMessageBox2("NoFolderSelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.VerzeichnisRausspielen: " + ex.ToString())
        End Try
    End Function
    Public Sub VerzeichnisRausspielen_rek(ByVal parent As UltraTreeNode, ByVal currentDir As String, ByVal typ As eDateiRausspielenName)
        Try
            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList
            coll = parent.Nodes

            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New General.clTagOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = General.clTagOrdner.eTyp.typOrdner Then

                    If Not System.IO.Directory.Exists(currentDir + "\" + item.Text) Then
                        System.IO.Directory.CreateDirectory(currentDir + "\" + item.Text)
                    End If
                    Me.VerzeichnisRausspielen_rek(item, currentDir + "\" + item.Text, typ)

                ElseIf clTagOrdner.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                    If Not Me.DateiRausspielen(clTagOrdner.ID, currentDir, typ) Then
                        Me.err_DateiRausspielen += 1
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contOrdner2.VerzeichnisRausspielen_rek: " + ex.ToString())
        End Try
    End Sub
    Public Function DateiRausspielen(ByVal IDDoku As System.Guid, ByVal currentDirToSave As String,
                                        ByVal typ As eDateiRausspielenName) As Boolean
        Try

            If Not gen.IsNull(IDDoku) Then
                Dim comp As New compDoku
                Dim rDoku As dbArchiv.archDokuRow = Me.compDoku1.getDokuRow(IDDoku, New dbArchiv)
                If Not gen.IsNull(rDoku) Then
                    Dim clArchiv As New cArchive()
                    Dim dateiArchiv As String = clArchiv.getFileFromDB(rDoku.Bezeichnung, rDoku.DateinameTyp, rDoku.doku)
                    Dim clOpen As New clFolder
                    If System.IO.File.Exists(dateiArchiv) Then
                        If typ = eDateiRausspielenName.Bezeichnung Then
                            System.IO.File.Copy(dateiArchiv, currentDirToSave + "\" + rDoku.Bezeichnung + "." + rDoku.DateinameTyp)
                            Return True
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.DateiRausspielen: " + ex.ToString())
        End Try
    End Function

    Public Function checkRechtOrdner_DokumenteAnzeigen(ByRef IDOrdner As System.Guid) As Boolean
        Try

            Return True

        Catch ex As Exception
            Throw New Exception("contOrdner2.checkRechtOrdner_DokumenteAnzeigen: " + ex.ToString())
        End Try
    End Function


    Private Sub UTreeOrdner_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UTreeOrdner.MouseDown
        Try
            If Not gen.IsNull(Me.modalusrCont) Then
                Me.modalusrCont.acP = e.Location
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then


                'ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                '    Dim cTag As New ITSCont.core.SystemDb.clTagOrdner
                '    cTag = Me.GetSelTagInfo
                '    If gen.IsNull(cTag) Then Exit Sub
                '    If cTag.typ = ITSCont.core.SystemDb.clTagOrdner.eTyp.typDateiSuchen Then
                '        If Not gen.IsNull(cTag.ID) Then
                '            If Not gen.IsNull(cTag.ID) Then
                '                If cTag.typ = ITSCont.core.SystemDb.clTagOrdner.eTyp.typDateiSuchen Then
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
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UTreeOrdner_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeOrdner.DragEnter
        Try
            'Me.Cursor = Cursors.WaitCursor

            '' See if the data includes text.
            'If e.Data.GetDataPresent(DataFormats.Text) Then
            '    ' There is text. Allow copy.
            '    e.Effect = DragDropEffects.Copy
            'Else
            '    ' There is no text. Prohibit drop.
            '    e.Effect = DragDropEffects.None
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            'Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeOrdner_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeOrdner.DragDrop
        Try
            'Me.Cursor = Cursors.WaitCursor

            'Me.fileDragDrop = ""
            'If Me.Typ = etyp.Ablegen Then
            '    If gen.IsNull(e.Data.GetData(DataFormats.Text).ToString()) Then Exit Sub
            '    Me.fileDragDrop = e.Data.GetData(DataFormats.Text).ToString()
            '    Me.delDragDrop.UseDelegate()
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            'Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NeuenOrdnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuenOrdnerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.UTreeOrdner.ActiveNode Is Nothing Then
                Me.OrdnerNeu(True)
            Else
                Dim clTag As New General.clTagOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = General.clTagOrdner.eTyp.typOrdner Then
                    Me.OrdnerNeu(False)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub OrdnerLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdnerLöschenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim clTag As New General.clTagOrdner
                clTag = Me.UTreeOrdner.SelectedNodes(0).Tag
                If clTag.typ = General.clTagOrdner.eTyp.typOrdner Then
                    Dim clTagParent As New General.clTagOrdner
                    If clTag.ID.Equals(cArchive.IDPapierkorb) Then
                        doUI.doMessageBox2("TheTrashCouldNotBeDeleted", "", "!")
                        Exit Sub
                    End If

                    If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                        If Me.deleteOrdner(clTag.ID) Then
                            Me.UTreeOrdner.SelectedNodes(0).Remove()
                            'MsgBox("Der Ordner wurde gelöscht!", MsgBoxStyle.Information, "Archivsystem")
                        End If
                    End If
                Else
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SystemordnerSpeichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeOrdner.SelectedNodes.Count > 0 Then
                Dim node As Infragistics.Win.UltraWinTree.UltraTreeNode
                node = Me.UTreeOrdner.SelectedNodes(0)
                Dim clTag As New General.clTagOrdner
                clTag = node.Tag
                If clTag.typ = General.clTagOrdner.eTyp.typOrdner Then
                    Me.UpdateOrdnerMain(node, eTypSaveOrdner.gesamteOrdner, True, True, True)
                Else
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            Else
                doUI.doMessageBox2("NoEntrySelected", "", "!")
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.SystemordnerSpeichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub SelectOrdner(ByVal IDOrdner As System.Guid)
        Try
            If gen.IsNull(IDOrdner) Then Exit Sub
            Me.SelectOrdner_rek(Nothing, IDOrdner, True)

        Catch ex As Exception
            Throw New Exception("contOrdner2.SelectOrdner: " + ex.ToString())
        End Try
    End Sub
    Public Function SelectOrdner_rek(ByVal parent As UltraTreeNode, ByVal IDOrdner As System.Guid, ByVal firstNode As Boolean) As Boolean
        Try
            Dim coll As TreeNodesCollection
            Dim arr As New ArrayList
            If firstNode Then
                coll = Me.UTreeOrdner.Nodes
            Else
                coll = parent.Nodes
            End If
            For Each item As UltraTreeNode In coll
                Dim clTagOrdner As New General.clTagOrdner
                clTagOrdner = item.Tag
                If clTagOrdner.typ = General.clTagOrdner.eTyp.typOrdner Then
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
            Throw New Exception("contOrdner2.SelectOrdner_rek: " + ex.ToString())
        End Try
    End Function

    Private Sub cboSystemordner_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cboSystemordner.EditorButtonClick
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
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Typ = etyp.SuchergebnisseAnzeigen Then
                Dim cTag As New General.clTagOrdner
                cTag = Me.GetSelTagInfo
                If gen.IsNull(cTag) Then Exit Sub
                If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                    If Not gen.IsNull(cTag.ID) Then
                        If Not gen.IsNull(cTag.ID) Then
                            Me.openSaveDocu(cTag.ID, "O", False, True, False)
                        End If
                    End If
                End If
            ElseIf Me.Typ = etyp.Verwaltung Then

            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function openSaveDocu(ByVal IDDoku As System.Guid, ByVal action As String, ByVal openIntern As Boolean,
                                 ByVal withMsgBox As Boolean, ByVal printDocu As Boolean) As Boolean
        Try

            'If Not gen.IsNull(Me.UGridDokumenteGefunden.ActiveRow) Then
            If Not gen.IsNull(IDDoku) Then
                Dim rDoku As dbArchiv.archDokuRow = Me.compDoku1.getDokuRow(IDDoku, New dbArchiv)
                If Not rDoku Is Nothing Then
                    ' Datei aus Archiv kopieren
                    'Dim dateiArchiv As String = Me.compDoku1.getPath + "\" + rDoku.Archivordner + "\" + rDoku.DateinameArchiv
                    If action = "O" Then
                        'Datei öffnen
                        Dim clOpen As New clFolder
                        'If Not clOpen.DateiÖffnen(dateiArchiv, rDoku.DateinameTyp, True) Then
                        Dim clArchiv As New cArchive()

                        Dim generalMain As New General()
                        Dim strFilename As String = generalMain.checkSonderSigns(rDoku.Bezeichnung)

                        If Not clOpen.openFile(clArchiv.getFileFromDB(strFilename, rDoku.DateinameTyp, rDoku.doku), rDoku, openIntern, withMsgBox, printDocu) Then
                            Me.openSaveDocu(rDoku.ID, "S", False, True, False)
                            Exit Function
                        End If

                    ElseIf action = "S" Then
                        Dim clArchiv As New cArchive()
                        Dim clOpen As New clFolder
                        Dim ui1 As New UI()
                        ui1.saveFileAs(clArchiv.getFileFromDB(rDoku.Bezeichnung, rDoku.DateinameTyp, rDoku.doku), rDoku.DateinameTyp)

                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.openSaveDocu: " + ex.ToString())
        End Try
    End Function


    Public Sub neueNachrichtZuDokumentErstellen(ByVal IDDoku As System.Guid)
        Try
            Dim rDoku As dbArchiv.archDokuRow = Me.compDoku1.getDokuRow(IDDoku, New dbArchiv)
            If Not rDoku Is Nothing Then
                Dim db As New dbArchiv()
                Me.compDoku1.getObject(rDoku.ID, compDoku.eTypSelObj.idDoku, db)

                gen.newMessage(Now, Now, Nothing, Nothing, False, False,
                                          rDoku.Bezeichnung, rDoku.DateinameTyp, rDoku.doku, False, False, contPlanungData.eTypeUI.PlanMy, New contPlanungData.cPlanArchive())
            End If

        Catch ex As Exception
            Throw New Exception("contOrdner2.neueNachrichtZuDokumentErstellen: " + ex.ToString())
        End Try
    End Sub

    Private Sub NeuerOrdnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuerOrdnerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.UTreeOrdner.ActiveNode = Nothing
            Me.OrdnerNeu(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub contOrdner_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Dim newRessourcesAdded As Integer = 0
                'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
                Me.IsInitializedVisible = True
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
