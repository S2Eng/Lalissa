Imports System.Reflection
Imports System.Drawing.Printing
Imports TXTextControl
Imports System.Globalization




Public Class contTxtEditor

    Private _typUI As New etyp

    Public mainForm As frmTxtEditor

    Delegate Sub delEditorKeyPress(ByVal OnOff As Boolean)
    Public callEditorKeyPress As delEditorKeyPress


    Public Delegate Sub textControl1_IsToSave_Delegate(ByVal Changed As Boolean)
    Public Event textControl1_IsToSave As textControl1_IsToSave_Delegate

    Public delOnNewClicked As onNewClicked
    Public Delegate Sub onNewClicked()

    Public lockEingbe As Boolean = False
    Public isDialogBookmarks As Boolean = False

    Public sNewDocuName As New System.Guid

    Public cTxtEditor1 As New clFields

    Public doEditor As New doEditor
    Public doBookmarks As New doBookmarks
    Public contFelder1 As contFelder
    Public contFelder2 As contFelder2 = Nothing

    Public mouseIsInFieldseditor As Boolean = False

    Public IDDocu As System.Guid = Nothing
    Public TypDocu As String = ""
    Public delOnSaveDocu As onSaveDocu
    Public Delegate Function onSaveDocu(ByRef IDDocu As System.Guid, _
                                        ByRef binInt() As Byte, ByRef binExport() As Byte, _
                                        ByRef typExport As String) As Boolean


    Public Protocoll As String = ""
    Public ProtocollTitle As String = ""
    Public ProtocollText As String = ""
    Public ProtocollCounter As Integer = 0

    Public doSpellChecking As Boolean = True

    Public delOnHyperlinkClicked As onHyperlinkClicked
    Public Delegate Function onHyperlinkClicked(ByRef ID As String) As String










#Region " Form Properties "
    Public FileHandler1 As FileHandler = New FileHandler(Me)
    Private m_LoadFileOnCreate As Boolean = False
    Public m_ActiveHeaderFooter As TXTextControl.HeaderFooter

    'Public doUI1 As New doUI()




    Public Sub New()
        MyBase.New()

        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo

        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")
    End Sub

    Public Sub doNew(ByVal fullEditor As Boolean)
        FileHandler1.RecentFilesMenuItem = RecentFilesToolStripMenuItem
        If fullEditor Then textControl1.ButtonBar = buttonBar1
        textControl1.RulerBar = rulerBar1
        textControl1.VerticalRulerBar = rulerBar2
        textControl1.StatusBar = statusBar1
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    Public Sub loadForm(ByVal bFelderEIn As Boolean, ByRef ds As DataSet, ByRef doCultureSelectedTxt As Boolean, ByVal bFelderEIn2 As Boolean)
        Try
            Me.textControl1.SpellChecker = Spelling.getSpellChecker()

            Dim newRessourcesAdded As Integer = 0
            'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Dim commands As String = Microsoft.VisualBasic.Command()
            FileHandler1.TextControl = textControl1
            ' Check if program has been started with a file name as a command line parameter
            Me.FileNew(True, False)
            FileHandler1.DocumentDirty = False
            UpdateSaveStatus()
            textControl1.ViewMode = TXTextControl.ViewMode.Normal
            If bFelderEIn Then
                Me.contFelder1 = New contFelder()
                Me.PanelFelder.Controls.Clear()
                Me.contFelder1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.PanelFelder.Controls.Add(Me.contFelder1)
                Me.contFelder1.modalWindow = Me
                If Not ds Is Nothing Then
                    contFelder1.initControl()
                    contFelder1.loadFields(ds)
                End If
                UExpandableGroupBoxFelder.Visible = True
            Else
                UExpandableGroupBoxFelder.Visible = False
            End If

            If bFelderEIn2 Then
                Me.contFelder2 = New contFelder2()
                contFelder2.initControl()
                Me.PanelFelder.Controls.Clear()
                Me.contFelder2.Dock = System.Windows.Forms.DockStyle.Fill
                Me.PanelFelder.Controls.Add(Me.contFelder2)
                Me.contFelder2.modalWindow = Me
                UExpandableGroupBoxFelder.Visible = True
            Else
                UExpandableGroupBoxFelder.Visible = False
            End If

            If doCultureSelectedTxt Then
                Dim cultEN = CultureInfo.GetCultureInfo("de-DE")    '("en-US")
                Me.textControl1.SelectAll()
                Me.textControl1.Selection.Culture = cultEN
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub LinealeOnOff(bOn As Boolean)
        Me.rulerBar2.Visible = False
        Me.rulerBar1.Visible = False
    End Sub
    Public Sub SetUIReadOnOff(bon As Boolean)
        Me.mnuFile_New.Visible = bon
        Me.mnuFile_Open.Visible = bon
        Me.mnuEdit.Visible = bon
        Me.mnuInsert.Visible = bon
        Me.mnuFormat.Visible = bon
        Me.mnuTable.Visible = bon
        Me.TextmarkenToolStripMenuItem.Visible = bon
        Me.toolStripButtonNew.Visible = bon
        Me.toolStripButtonOpen.Visible = bon
        Me.ToolStripButtonSaveDocuToDB.Visible = bon
        Me.toolStripButtonCut.Visible = bon
        Me.toolStripButtonCopy.Visible = bon
        Me.toolStripButtonPaste.Visible = bon
        Me.toolStripButton9.Visible = bon
        Me.toolStripButtonUndo.Visible = bon
        Me.toolStripButtonRedo.Visible = bon
        Me.toolStripButton13.Visible = bon
        Me.toolStripButton15.Visible = bon
        Me.toolStripButton16.Visible = bon
        Me.ToolStripButton14.Visible = bon
        Me.toolStripSeparator4.Visible = bon
    End Sub
    Public Property typUI() As etyp
        Get
            Return Me._typUI
        End Get
        Set(ByVal value As etyp)
            Me._typUI = value
            Me.setControlTyp()
        End Set
    End Property

    Public Sub setNewControlTyp(ByVal typ As etyp)
        Me.typUI = typ
    End Sub
    Public Sub setControlTyp()
        Try
            If Me._typUI = etyp.onlyShow Then
                'Me.diffResize = 24
                Me.statusBar1.Visible = False
                Me.buttonBar1.Visible = False
                Me.rulerBar1.Visible = False
                Me.rulerBar2.Visible = False
                'Me.textControl1.Height = Me.Height - Me.diffResize
                Me.menuStrip1.Visible = False
                Me.toolStrip1.Visible = False

            ElseIf Me._typUI = etyp.minimalForEdit Then
                Me.statusBar1.Visible = False
                Me.buttonBar1.Visible = False
                Me.rulerBar1.Visible = False
                Me.rulerBar2.Visible = False
                Me.menuStrip1.Visible = False
                Me.menuStrip1.Visible = False
                Me.toolStrip1.Visible = False
                textControl1.ZoomFactor = 100
                'Me.textControl1.ViewMode = TXTextControl.ViewMode.PageView

            ElseIf Me._typUI = etyp.all Then
                Me.statusBar1.Visible = True
                Me.buttonBar1.Visible = True
                Me.rulerBar1.Visible = True
                Me.rulerBar2.Visible = True
                Me.menuStrip1.Visible = True
                Me.menuStrip1.Visible = True
                Me.toolStrip1.Visible = True
                buttonBar1.Enabled = True
                textControl1.ZoomFactor = 100
                'Me.textControl1.ViewMode = TXTextControl.ViewMode.PageView

            ElseIf Me._typUI = etyp.calc Then
                Me.statusBar1.Visible = True
                Me.buttonBar1.Visible = True
                Me.rulerBar1.Visible = False
                Me.rulerBar2.Visible = False
                Me.menuStrip1.Visible = True
                Me.menuStrip1.Visible = True
                Me.toolStrip1.Visible = True
                Me.buttonBar1.Enabled = True
                'Me.textControl1.ViewMode = TXTextControl.ViewMode.PageView

            ElseIf Me._typUI = etyp.biografie Then
                Me.statusBar1.Visible = False
                Me.buttonBar1.Visible = True
                ' Me.buttonBar1.BackColor = Drawing.Color.DarkGray
                Me.rulerBar1.Visible = False
                Me.rulerBar2.Visible = False
                Me.menuStrip1.Visible = False
                Me.menuStrip1.Visible = False
                Me.toolStrip1.Visible = False
                buttonBar1.Enabled = True
                'Me.diffResize = 130
                'Me.RulerBarLineal.Visible = True
                'Me.TextControl1.Height = Me.Height - Me.diffResize
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub


    Public ReadOnly Property CanCopy() As Boolean
        Get
            Return textControl1.CanCopy
        End Get
    End Property

    Public ReadOnly Property CanPaste() As Boolean
        Get
            Return textControl1.CanPaste
        End Get
    End Property

    Public ReadOnly Property CanUndo() As Boolean
        Get
            Return textControl1.CanUndo
        End Get
    End Property

    Public ReadOnly Property CanRedo() As Boolean
        Get
            Return textControl1.CanRedo
        End Get
    End Property

    Public WriteOnly Property LoadFileOnCreate() As Boolean
        Set(ByVal value As Boolean)
            m_LoadFileOnCreate = value
        End Set
    End Property

    Public Property ISTOSAVE() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

#End Region

    Private Sub UpdateSaveStatus()
        ' Enable or disable the save button and menu entry
        toolStrip1.Items(2).Enabled = FileHandler1.DocumentDirty
        mnuFile.DropDownItems(4).Enabled = FileHandler1.DocumentDirty
    End Sub


#Region " Drag and Drop "

    Private Sub frmMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragOver
        If e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop, False) = True Then
            e.Effect = System.Windows.Forms.DragDropEffects.All
        End If
    End Sub

    Private Sub frmMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim files As String() = e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop)

        Dim Result As System.Windows.Forms.DialogResult

        If FileHandler1.DocumentDirty Then
            Dim sTxt As String = ""
            If Not Me.mainForm Is Nothing Then sTxt = Me.mainForm.Text

            Dim sTitle As String = generic.getRes("Save")
            Dim sText As String = generic.getRes("DoYouWantToSaveTheChangesToX")
            sText = String.Format(sText, sTxt)
            Result = generic.showMessageBox(sText, System.Windows.Forms.MessageBoxButtons.YesNo, "")
            If Result = System.Windows.Forms.DialogResult.Yes Then
                FileHandler1.FileSave()
            ElseIf Result = System.Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        End If

        For Each file As String In files
            FileHandler1.DocumentFileName = file
            If Not Me.mainForm Is Nothing Then Me.mainForm.Text = FileHandler1.DocumentFileName
            FileHandler1.FileOpen()
            ' loop through all files, if MDI is implemented
            Exit For
        Next
    End Sub

#End Region

#Region " File Menu "

    Private Sub mnuFile_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile.DropDownOpening
        FileHandler1.RecentFilesMenuItem = RecentFilesToolStripMenuItem
        'FileHandler1.InitRecentFiles()
    End Sub

    Private Sub mnuFile_Open_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile_Open.Click
        Me.FileNew(False, False)
        FileOpen()
        UpdateSaveStatus()
        If Not callEditorKeyPress Is Nothing Then callEditorKeyPress.Invoke(True)
    End Sub

    Private Sub mnuFile_New_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile_New.Click
        Me.FileNew(True, True)
        UpdateSaveStatus()
    End Sub

    Private Sub mnuFile_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Save.Click
        FileSave()
        UpdateSaveStatus()
    End Sub

    Private Sub mnuFile_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_SaveAs.Click
        Me.speichernAls()
    End Sub
    Public Sub speichernAls()
        Try
            FileHandler1.FileSaveAs()
            If Not (FileHandler1.DocumentFileName = "") Then
                If Not Me.mainForm Is Nothing Then Me.mainForm.Text = FileHandler1.DocumentFileName
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
        UpdateSaveStatus()
    End Sub

    Private Sub mnuFile_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Export.Click
        Me.Export()
    End Sub
    Public Sub Export()
        Try
            FileHandler1.Export()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub
    Public Sub ExportPDF(ByVal sName As String, ByVal öffnen As Boolean, ByVal withMsgBox As Boolean)
        Try
            FileHandler1.ExportPDF(sName)
            If withMsgBox Then generic.showMessageBox(generic.getRes("Dokument wurde gesichert!") + "!",
                                             System.Windows.Forms.MessageBoxButtons.OK, "")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub
    Private Sub mnuFile_PageSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_PageSetup.Click
        'Dim pd As System.Drawing.Printing.PrintDocument = Me.getPrintDocument()
        textControl1.SectionFormatDialog(0)
    End Sub

    Private Sub mnuFile_PrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_PrintPreview.Click
        PrintPreview()
    End Sub

    Private Sub mnuFile_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Print.Click
        Print()
    End Sub


#End Region

#Region " Table Menu "
    Private Sub mnuTable_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable.DropDownOpening
        Dim ThisTable As TXTextControl.Table = textControl1.Tables.GetItem
        mnuTable_Properties.Enabled = (Not (ThisTable Is Nothing))
        mnuTable_GridLines.Checked = textControl1.Tables.GridLines
        If Not (ThisTable Is Nothing) Then
            mnuTable_Split.Enabled = ThisTable.CanSplit
        Else
            mnuTable_Split.Enabled = False
        End If
    End Sub

    Private Sub mnuTable_Insert_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert.DropDownOpening
        mnuTable_Insert_Table.Enabled = textControl1.Tables.CanAdd
        Dim TableAtInputPosition As TXTextControl.Table = textControl1.Tables.GetItem
        If TableAtInputPosition Is Nothing Then
            mnuTable_Insert_ColumnToTheLeft.Enabled = False
            mnuTable_Insert_ColumnToTheRight.Enabled = False
            mnuTable_Insert_RowAbove.Enabled = False
            mnuTable_Insert_RowBelow.Enabled = False
        Else
            mnuTable_Insert_ColumnToTheLeft.Enabled = TableAtInputPosition.Columns.CanAdd
            mnuTable_Insert_ColumnToTheRight.Enabled = TableAtInputPosition.Columns.CanAdd
            mnuTable_Insert_RowAbove.Enabled = TableAtInputPosition.Rows.CanAdd
            mnuTable_Insert_RowBelow.Enabled = TableAtInputPosition.Rows.CanAdd
        End If
    End Sub

    Private Sub mnuTable_Insert_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_Table.Click
        Dim InsertTableDialog As frmInsertTable = New frmInsertTable
        InsertTableDialog.tx = textControl1
        InsertTableDialog.ShowDialog()
    End Sub

    Private Sub mnuTable_Insert_ColumnToTheLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_ColumnToTheLeft.Click
        textControl1.Tables.GetItem.Columns.Add(TXTextControl.TableAddPosition.Before)
    End Sub

    Private Sub mnuTable_Insert_ColumnToTheRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_ColumnToTheRight.Click
        textControl1.Tables.GetItem.Columns.Add(TXTextControl.TableAddPosition.After)
    End Sub

    Private Sub mnuTable_Insert_RowAbove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_RowAbove.Click
        textControl1.Tables.GetItem.Rows.Add(TXTextControl.TableAddPosition.Before, 1)
    End Sub

    Private Sub mnuTable_Insert_RowBelow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_RowBelow.Click
        textControl1.Tables.GetItem.Rows.Add(TXTextControl.TableAddPosition.After, 1)
    End Sub

    Private Sub mnuTable_Delete_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete.DropDownOpening
        Dim TableAtInputPosition As TXTextControl.Table = textControl1.Tables.GetItem
        If TableAtInputPosition Is Nothing Then
            mnuTable_Delete_Table.Enabled = False
            mnuTable_Delete_Column.Enabled = False
            mnuTable_Delete_Rows.Enabled = False
        Else
            mnuTable_Delete_Table.Enabled = TableAtInputPosition.Columns.CanRemove
            mnuTable_Delete_Column.Enabled = TableAtInputPosition.Columns.CanRemove
            mnuTable_Delete_Rows.Enabled = TableAtInputPosition.Rows.CanRemove
        End If
    End Sub

    Private Sub mnuTable_Delete_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Table.Click
        textControl1.Tables.Remove()
    End Sub

    Private Sub mnuTable_Delete_Column_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Column.Click
        textControl1.Tables.GetItem.Columns.Remove()
    End Sub

    Private Sub mnuTable_Delete_Rows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Rows.Click
        textControl1.Tables.GetItem.Rows.Remove()
    End Sub

    Private Sub mnuTable_Split_Above_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Split_Above.Click
        textControl1.Tables.GetItem.Split(TXTextControl.TableAddPosition.Before)
    End Sub

    Private Sub mnuTable_Split_Below_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Split_Below.Click
        textControl1.Tables.GetItem.Split(TXTextControl.TableAddPosition.After)
    End Sub

    Private Sub mnuTable_Select_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select.DropDownOpening
        Dim TableAtInputPosition As TXTextControl.Table = Nothing
        Dim RowAtInputPosition As TXTextControl.TableRow = Nothing
        Dim CellAtInputPosition As TXTextControl.TableCell = Nothing
        TableAtInputPosition = textControl1.Tables.GetItem
        If Not (TableAtInputPosition Is Nothing) Then
            RowAtInputPosition = TableAtInputPosition.Rows.GetItem
            CellAtInputPosition = TableAtInputPosition.Cells.GetItem
        End If
        mnuTable_Select_Table.Enabled = (Not (TableAtInputPosition Is Nothing))
        mnuTable_Select_Row.Enabled = (Not (RowAtInputPosition Is Nothing))
        mnuTable_Select_Cell.Enabled = (Not (CellAtInputPosition Is Nothing))
    End Sub

    Private Sub mnuTable_Select_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Table.Click
        textControl1.Tables.GetItem.Select()
    End Sub

    Private Sub mnuTable_Select_Row_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Row.Click
        textControl1.Tables.GetItem.Rows.GetItem.Select()
    End Sub

    Private Sub mnuTable_Select_Cell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Cell.Click
        textControl1.Tables.GetItem.Cells.GetItem.Select()
    End Sub

    Private Sub mnuTable_GridLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_GridLines.Click
        textControl1.Tables.GridLines = Not textControl1.Tables.GridLines
    End Sub

    Private Sub mnuTable_Properties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Properties.Click
        textControl1.TableFormatDialog()
    End Sub
#End Region

#Region " Options Menu "

    Private Sub mnuOptions_HTML_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptions_HTML.Click
        Dim HTMLOptionsDialog As frmHTMLOptions = New frmHTMLOptions
        HTMLOptionsDialog.FileHandler1 = FileHandler1
        HTMLOptionsDialog.ShowDialog()
    End Sub

    Private Sub mnuOptions_PDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptions_PDF.Click
        Dim PDFOptionsDialog As frmPDFOptions = New frmPDFOptions
        PDFOptionsDialog.FileHandler1 = FileHandler1
        PDFOptionsDialog.ShowDialog()
    End Sub
#End Region

#Region " Format Menu "

    Private Sub mnuFormat_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat.DropDownOpening
        mnuFormat_Image.Enabled = (Not (textControl1.Images.GetItem Is Nothing))
        mnuFormat_TextFrame.Enabled = (Not (textControl1.TextFrames.GetItem Is Nothing))
        mnuFormat_TextFrameMarkerLines.Checked = textControl1.TextFrameMarkerLines
        mnuFormat_DocumentTargetMarkers.Checked = textControl1.DocumentTargetMarkers
    End Sub

    Private Sub mnuFormat_Character_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Character.Click
        textControl1.FontDialog()
    End Sub

    Private Sub mnuFormat_Paragraph_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Paragraph.Click
        textControl1.ParagraphFormatDialog()
    End Sub

    Private Sub mnuFormat_Tabs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Tabs.Click
        textControl1.TabDialog()
    End Sub

    Private Sub mnuFormat_Styles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Styles.Click
        textControl1.FormattingStylesDialog()
    End Sub

    Private Sub mnuFormat_Image_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Image.Click
        textControl1.ImageAttributesDialog()
    End Sub

    Private Sub mnuFormat_TextFrame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_TextFrame.Click
        textControl1.TextFrameAttributesDialog()
    End Sub

    Private Sub mnuFormat_TextFrameMarkerLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_TextFrameMarkerLines.Click
        textControl1.TextFrameMarkerLines = Not textControl1.TextFrameMarkerLines
    End Sub

    Private Sub mnuFormat_DocumentTargetMarkers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormat_DocumentTargetMarkers.Click
        textControl1.DocumentTargetMarkers = Not (textControl1.DocumentTargetMarkers)
    End Sub

    Private Sub mnuFormat_TextColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_TextColor.Click
        ColorDialog1.ShowDialog()
        textControl1.Selection.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub mnuFormat_TextbackgroundColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_TextbackgroundColor.Click
        ColorDialog1.ShowDialog()
        textControl1.Selection.TextBackColor = ColorDialog1.Color
    End Sub

    Private Sub mnuFormat_DocumentBackgroundColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_DocumentBackgroundColor.Click
        ColorDialog1.ShowDialog()
        textControl1.BackColor = ColorDialog1.Color
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering.DropDownOpening
        mnuFormat_BulletsAndNumbering_IncreaseLevel.Enabled = (Not (textControl1.Selection.ListFormat.Type = TXTextControl.ListType.None)) AndAlso (textControl1.Selection.ListFormat.Level < TXTextControl.ListFormat.MaxLevel)
        mnuFormat_BulletsAndNumbering_DecreaseLevel.Enabled = (Not (textControl1.Selection.ListFormat.Type = TXTextControl.ListType.None)) AndAlso (textControl1.Selection.ListFormat.Level > 1)
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_Attributes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_Attributes.Click
        textControl1.ListFormatDialog()
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_IncreaseLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_IncreaseLevel.Click
        textControl1.Selection.ListFormat.Level += 1
        textControl1.Selection.ListFormat.LeftIndent += textControl1.Selection.ListFormat.HangingIndent
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_DecreaseLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_DecreaseLevel.Click
        textControl1.Selection.ListFormat.Level -= 1
        textControl1.Selection.ListFormat.LeftIndent -= textControl1.Selection.ListFormat.HangingIndent
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_ArabicNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_ArabicNumbers.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        textControl1.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.ArabicNumbers
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_CapitalLetters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_CapitalLetters.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        textControl1.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.CapitalLetters
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_Letters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_Letters.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        textControl1.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.Letters
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_RomanNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_RomanNumbers.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        textControl1.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.RomanNumbers
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_SmallRomanNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_SmallRomanNumbers.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        textControl1.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.SmallRomanNumbers
    End Sub

    Private Sub mnuFormat_BulletsAndNumbering_Bullets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_BulletsAndNumbering_Bullets.Click
        textControl1.Selection.ListFormat.Type = TXTextControl.ListType.Bulleted
    End Sub

    Private Sub mnuFormat_HeadersAndFooters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormat_HeadersAndFooters.Click
        textControl1.SectionFormatDialog(1)
    End Sub
#End Region

#Region " Insert Menu "

    Private Sub mnuInsert_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert.DropDownOpening
        Try
            mnuInsert_Hyperlink.Enabled = textControl1.HypertextLinks.CanAdd
            mnuInsert_Target.Enabled = textControl1.DocumentTargets.CanAdd
        Catch
        End Try
    End Sub

    Private Sub mnuInsert_File_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_File.Click
        Try
            FileHandler1.Insert()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Private Sub mnuInsert_Image_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Image.Click
        Dim NewImage As TXTextControl.Image = New TXTextControl.Image
        textControl1.Images.Add(NewImage, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText)
    End Sub

    Private Sub mnuInsert_TextFrame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_TextFrame.Click
        Dim TextFrameSize As System.Drawing.Size = New System.Drawing.Size(2000, 1000)
        Dim NewTextFrame As TXTextControl.TextFrame = New TXTextControl.TextFrame(TextFrameSize)
        textControl1.TextFrames.Add(NewTextFrame, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.TextFrameInsertionMode.DisplaceText)
    End Sub

    Private Sub mnuInsert_Hyperlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Hyperlink.Click
        Try
            Dim HyperlinksDialog As frmHyperlink = New frmHyperlink
            HyperlinksDialog.txMain = textControl1
            HyperlinksDialog.ShowDialog()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Private Sub mnuInsert_Target_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Target.Click
        Try
            Dim TargetName As String = ""
            If InputBox.ShowInputBox("Target Name:", TargetName) Then
                Dim Target As TXTextControl.DocumentTarget = New TXTextControl.DocumentTarget(TargetName)
                textControl1.DocumentTargets.Add(Target)
                FileHandler1.DocumentDirty = True
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Private Sub mnuInsert_Section_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInsert_Section.Click
        Dim InsertSectionDialog As frmInsertBreak = New frmInsertBreak
        InsertSectionDialog.tx = textControl1
        InsertSectionDialog.ShowDialog()
    End Sub
#End Region

#Region " View Menu "

    Private Sub mnuView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView.DropDownOpening
        mnuView_PageLayout.Checked = (textControl1.ViewMode = TXTextControl.ViewMode.PageView)
        mnuView_Normal.Checked = (textControl1.ViewMode = TXTextControl.ViewMode.Normal)
        mnuView_Toolbar.Checked = toolStrip1.Visible
        mnuView_ButtonBar.Checked = buttonBar1.Visible
        mnuView_StatusBar.Checked = statusBar1.Visible
        mnuView_HorizontalRuler.Checked = rulerBar1.Visible
        mnuView_VerticalRuler.Checked = rulerBar2.Visible
        mnuView_HeadersAndFooters.Enabled = (textControl1.ViewMode = TXTextControl.ViewMode.PageView)
    End Sub

    Private Sub mnuView_Normal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Normal.Click
        textControl1.ViewMode = TXTextControl.ViewMode.Normal
    End Sub

    Private Sub mnuView_PageLayout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_PageLayout.Click
        textControl1.ViewMode = TXTextControl.ViewMode.PageView
    End Sub

    Private Sub mnuView_HeadersAndFooters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_HeadersAndFooters.Click
        Try
            Dim Header As TXTextControl.HeaderFooter
            If textControl1.HeadersAndFooters.Count <> 0 Then
                textControl1.HeadersAndFooters.Remove(TXTextControl.HeaderFooterType.All)
            End If
            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header)
            textControl1.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick
            Header = textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header)
            If Not (Header Is Nothing) Then
                Header.Activate()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Private Sub mnuView_Toolbar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Toolbar.Click
        toolStrip1.Visible = Not toolStrip1.Visible
    End Sub

    Private Sub mnuView_ButtonBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_ButtonBar.Click
        buttonBar1.Visible = Not buttonBar1.Visible
    End Sub

    Private Sub mnuView_StatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_StatusBar.Click
        statusBar1.Visible = Not statusBar1.Visible
    End Sub

    Private Sub mnuView_HorizontalRuler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_HorizontalRuler.Click
        rulerBar1.Visible = Not rulerBar1.Visible
    End Sub

    Private Sub mnuView_VerticalRuler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_VerticalRuler.Click
        rulerBar2.Visible = Not rulerBar2.Visible
    End Sub

    Private Sub mnuView_Zoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom.Click
        mnuView_Zoom_25.Checked = (textControl1.ZoomFactor = 25)
        mnuView_Zoom_50.Checked = (textControl1.ZoomFactor = 50)
        mnuView_Zoom_75.Checked = (textControl1.ZoomFactor = 75)
        mnuView_Zoom_100.Checked = (textControl1.ZoomFactor = 100)
        mnuView_Zoom_150.Checked = (textControl1.ZoomFactor = 150)
        mnuView_Zoom_200.Checked = (textControl1.ZoomFactor = 200)
        mnuView_Zoom_300.Checked = (textControl1.ZoomFactor = 300)
    End Sub

    Private Sub mnuView_Zoom_25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_25.Click
        textControl1.ZoomFactor = 25
    End Sub

    Private Sub mnuView_Zoom_50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_50.Click
        textControl1.ZoomFactor = 50
    End Sub

    Private Sub mnuView_Zoom_75_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_75.Click
        textControl1.ZoomFactor = 75
    End Sub

    Private Sub mnuView_Zoom_100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_100.Click
        textControl1.ZoomFactor = 100
    End Sub

    Private Sub mnuView_Zoom_150_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_150.Click
        textControl1.ZoomFactor = 150
    End Sub

    Private Sub mnuView_Zoom_200_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_200.Click
        textControl1.ZoomFactor = 200
    End Sub

    Private Sub mnuView_Zoom_300_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_300.Click
        textControl1.ZoomFactor = 300
    End Sub

#End Region

#Region " Edit Menu "

    Private Sub mnuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.DropDownOpening
        mnuEdit_Undo.Enabled = textControl1.CanUndo
        mnuEdit_Redo.Enabled = textControl1.CanRedo
        mnuEdit_Cut.Enabled = textControl1.CanCopy
        mnuEdit_Copy.Enabled = textControl1.CanCopy
        mnuEdit_Paste.Enabled = textControl1.CanPaste
        mnuEdit_Undo.Text = "Undo " + textControl1.UndoActionName
        mnuEdit_Redo.Text = "Redo " + textControl1.RedoActionName
        Try
            mnuEdit_Hyperlink.Enabled = (Not (textControl1.HypertextLinks.GetItem Is Nothing)) OrElse (Not (textControl1.DocumentLinks.GetItem Is Nothing))
            mnuEdit_Target.Enabled = (Not (textControl1.DocumentTargets.GetItem Is Nothing))
        Catch
        End Try
    End Sub

    Private Sub mnuEdit_Undo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Undo.Click
        Undo()
    End Sub

    Private Sub mnuEdit_Redo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Redo.Click
        Redo()
    End Sub

    Private Sub mnuEdit_Cut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Cut.Click
        Cut()
    End Sub

    Private Sub mnuEdit_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Copy.Click
        Copy()
    End Sub

    Private Sub mnuEdit_Paste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Paste.Click
        Paste()
    End Sub

    Private Sub mnuEdit_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Delete.Click
        textControl1.Clear()
    End Sub

    Private Sub mnuEdit_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_SelectAll.Click
        textControl1.SelectAll()
    End Sub

    Private Sub mnuEdit_Find_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Find.Click
        Find()
    End Sub

    Private Sub mnuEdit_Replace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Replace.Click
        textControl1.Replace()
    End Sub

    Private Sub mnuEdit_Hyperlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Hyperlink.Click
        Try
            Dim HyperlinksDialog As frmHyperlink = New frmHyperlink
            HyperlinksDialog.txMain = textControl1
            HyperlinksDialog.ShowDialog()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Private Sub mnuEdit_Target_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Target.Click
        Try
            Dim TargetName As String = ""
            Dim Target As TXTextControl.DocumentTarget = textControl1.DocumentTargets.GetItem
            If Not (Target Is Nothing) Then
                TargetName = Target.Name
                If InputBox.ShowInputBox("Enter a name for this target:", TargetName) Then
                    Target.Name = TargetName
                End If
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

#End Region



#Region " Menu Functions "

    Public Sub FileSave()
        Try
            FileHandler1.FileSave()
            If Not (FileHandler1.DocumentFileName = "") Then
                If Not Me.mainForm Is Nothing Then Me.mainForm.Text = FileHandler1.DocumentFileName
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "TX Text Control Words")
        End Try
    End Sub

    Public Sub FileNew(ByVal alteSichern As Boolean, ByVal doDelegate As Boolean)
        Dim Result As System.Windows.Forms.DialogResult

        If alteSichern Then
            If FileHandler1.DocumentDirty Then
                Dim sTxt As String = ""
                If Not Me.mainForm Is Nothing Then sTxt = Me.mainForm.Text

                Dim sTitle As String = generic.getRes("Save")
                Dim sText As String = generic.getRes("SaveChangesToX")
                sText = String.Format(sText, sTxt)
                Result = generic.showMessageBox(sText, System.Windows.Forms.MessageBoxButtons.YesNo, "")

                If Result = System.Windows.Forms.DialogResult.Yes Then
                    FileHandler1.FileSave()
                    If FileHandler1.DocumentFileName = "" Then
                        Return
                    End If
                Else
                    If Result = System.Windows.Forms.DialogResult.Cancel Then
                        Return
                    End If
                End If
            End If
        Else

        End If

        FileHandler1.DocumentFileName = ""
        textControl1.ResetContents()
        If Not Me.mainForm Is Nothing Then Me.mainForm.Text = "[" + generic.getRes("EmptyDocument") + "]"
        FileHandler1.DocumentDirty = False

        UpdateSaveStatus()
        'Me.checkOrientation()

        If doDelegate Then
            If Not IsNothing(Me.delOnNewClicked) Then
                Me.delOnNewClicked.Invoke()
            End If
        End If

    End Sub


    Public Sub FileOpen()
        Dim Result As System.Windows.Forms.DialogResult

        If FileHandler1.DocumentDirty Then
            Dim sTxt As String = ""
            If Not Me.mainForm Is Nothing Then sTxt = Me.mainForm.Text

            Dim sTitle As String = generic.getRes("Save")
            Dim sText As String = generic.getRes("SaveChangesToX")
            sText = String.Format(sText, sTxt)
            Result = generic.showMessageBox(sText, System.Windows.Forms.MessageBoxButtons.YesNo, "")
            If Result = System.Windows.Forms.DialogResult.Yes Then
                FileHandler1.FileSave()
                If FileHandler1.DocumentFileName = "" Then
                    Return
                End If
            Else
                If Result = System.Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
            End If
        End If
        FileHandler1.DocumentFileName = ""
        If FileHandler1.FileOpen() Then
            If Not Me.mainForm Is Nothing Then Me.mainForm.Text = FileHandler1.DocumentFileName
        End If
    End Sub

    Public Sub Print()
        'Dim pd As System.Drawing.Printing.PrintDocument = Me.getPrintDocument()
        textControl1.Print("")
    End Sub

    Public Sub PrintPreview()
        'Dim pd As System.Drawing.Printing.PrintDocument = Me.getPrintDocument()
        textControl1.PrintPreview("")
    End Sub

    Public Sub Cut()
        textControl1.Cut()
    End Sub

    Public Sub Copy()
        textControl1.Copy()
    End Sub

    Public Sub Paste()
        textControl1.Paste()
    End Sub

    Public Sub Undo()
        textControl1.Undo()
    End Sub

    Public Sub Redo()
        textControl1.Redo()
    End Sub

    Public Sub Find()
        textControl1.Find()
    End Sub


    Public Sub SwitchBetweenHeaderAndFooter()
        If Not (m_ActiveHeaderFooter Is Nothing) Then
            Try
                Select Case m_ActiveHeaderFooter.Type
                    Case TXTextControl.HeaderFooterType.Footer
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate()
                        End If

                    Case TXTextControl.HeaderFooterType.Header
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Footer)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate()
                        End If

                    Case TXTextControl.HeaderFooterType.FirstPageFooter
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.FirstPageHeader)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate()
                        End If

                    Case TXTextControl.HeaderFooterType.FirstPageHeader
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.FirstPageFooter)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate()
                        End If
                End Select
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub GoToFirstPage()
        If Not (m_ActiveHeaderFooter Is Nothing) Then
            Try
                Select Case m_ActiveHeaderFooter.Type
                    Case TXTextControl.HeaderFooterType.Header
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate()
                        End If
                    Case TXTextControl.HeaderFooterType.Footer
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate()
                        End If
                End Select
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub RemoveHeaderFooter()
        If Not (m_ActiveHeaderFooter Is Nothing) Then
            textControl1.HeadersAndFooters.Remove(TXTextControl.HeaderFooterType.All)
            m_ActiveHeaderFooter = Nothing
            EnableToolbarButtons()
        End If
    End Sub

    Public Sub GoToDefault()
        If Not (m_ActiveHeaderFooter Is Nothing) Then
            Try
                Select Case m_ActiveHeaderFooter.Type
                    Case TXTextControl.HeaderFooterType.FirstPageHeader
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate()
                        End If
                    Case TXTextControl.HeaderFooterType.FirstPageFooter
                        If Not (textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) Is Nothing) Then
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate()
                        Else
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Footer)
                            textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate()
                        End If
                End Select
            Catch ex As Exception

            End Try
        End If
    End Sub

    Function GetNumberOfPages() As Integer
        Dim pages As Integer = 0
        For i As Integer = 1 To textControl1.Pages
            If textControl1.GetPages.Item(i).Section = textControl1.Sections.GetItem().Number Then
                pages += 1
            End If
        Next
        Return pages
    End Function

#End Region

#Region " Toolbar Events "

    Public Sub EnableToolbarButtons()
        toolStrip1.Items(10).Enabled = Me.CanCopy
        toolStrip1.Items(11).Enabled = Me.CanCopy
        toolStrip1.Items(12).Enabled = Me.CanPaste
        toolStrip1.Items(13).Enabled = Me.CanCopy
        toolStrip1.Items(15).Enabled = Me.CanUndo
        toolStrip1.Items(16).Enabled = Me.CanRedo
        If Not (m_ActiveHeaderFooter Is Nothing) Then
            toolStrip1.Items(19).Enabled = True
            toolStrip1.Items(20).Enabled = Not (IsNothing(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header))) And (GetNumberOfPages() >= 2) And m_ActiveHeaderFooter.Type <> TXTextControl.HeaderFooterType.Header
            toolStrip1.Items(21).Enabled = Not (IsNothing(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader))) And m_ActiveHeaderFooter.Type <> TXTextControl.HeaderFooterType.FirstPageHeader
            toolStrip1.Items(22).Enabled = True
        Else
            toolStrip1.Items(19).Enabled = False
            toolStrip1.Items(20).Enabled = False
            toolStrip1.Items(21).Enabled = False
            toolStrip1.Items(22).Enabled = False
        End If
    End Sub

    Private Sub toolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonNew.Click
        Me.FileNew(True, True)
    End Sub

    Private Sub toolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonOpen.Click
        Me.FileNew(False, False)
        FileOpen()
        If Not callEditorKeyPress Is Nothing Then callEditorKeyPress.Invoke(True)
    End Sub

    Private Sub toolStripButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton3.Click
        FileSave()
    End Sub

    Private Sub toolStripButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton4.Click
        Print()
    End Sub

    Private Sub toolStripButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton5.Click
        PrintPreview()
    End Sub

    Private Sub toolStripButton6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonCut.Click
        Cut()
    End Sub

    Private Sub toolStripButton7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonCopy.Click
        Copy()
    End Sub

    Private Sub toolStripButton8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonPaste.Click
        Paste()
    End Sub

    Private Sub toolStripButton9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton9.Click
        textControl1.Clear()
    End Sub

    Private Sub toolStripButton10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonUndo.Click
        Undo()
    End Sub

    Private Sub toolStripButton11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonRedo.Click
        Redo()
    End Sub

    Private Sub toolStripButton12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton12.Click
        Find()
    End Sub

    Private Sub toolStripButton13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton13.Click
        SwitchBetweenHeaderAndFooter()
    End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        RemoveHeaderFooter()
    End Sub

    Private Sub toolStripButton15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton15.Click
        GoToDefault()
    End Sub

    Private Sub toolStripButton16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton16.Click
        GoToFirstPage()
    End Sub

#End Region

#Region " Context Menus "

    Private Sub ContextMenu_Text_Popup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_Text.Opening
        ContextMenu_Text_TableProperties.Enabled = (Not (textControl1.Tables.GetItem Is Nothing))
        ContextMenu_Text_Cut.Enabled = textControl1.CanCopy
        ContextMenu_Text_Copy.Enabled = textControl1.CanCopy
        ContextMenu_Text_Paste.Enabled = textControl1.CanPaste
    End Sub

    Private Sub ContextMenu_Images_Popup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_Images.Opening
        ContextMenu_Images_Cut.Enabled = textControl1.CanCopy
        ContextMenu_Images_Copy.Enabled = textControl1.CanCopy
        ContextMenu_Images_Paste.Enabled = textControl1.CanPaste
    End Sub

    Private Sub ContextMenu_TextFrames_Popup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_TextFrames.Opening
        ContextMenu_TextFrames_Cut.Enabled = textControl1.CanCopy
        ContextMenu_TextFrames_Copy.Enabled = textControl1.CanCopy
        ContextMenu_TextFrames_Paste.Enabled = textControl1.CanPaste
    End Sub

    Private Sub ContextMenu_TextFrames_Cut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_TextFrames_Cut.Click
        Cut()
    End Sub

    Private Sub ContextMenu_TextFrames_Copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_TextFrames_Copy.Click
        Copy()
    End Sub

    Private Sub ContextMenu_TextFrames_Paste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_TextFrames_Paste.Click
        Paste()
    End Sub

    Private Sub ContextMenu_TextFrames_FormatTextFrame_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_TextFrames_FormatTextFrame.Click
        textControl1.TextFrameAttributesDialog()
    End Sub

    Private Sub ContextMenu_Images_Cut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Images_Cut.Click
        Cut()
    End Sub

    Private Sub ContextMenu_Images_Copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Images_Copy.Click
        Copy()
    End Sub

    Private Sub ContextMenu_Images_Paste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Images_Paste.Click
        Paste()
    End Sub

    Private Sub ContextMenu_Images_FormatImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Images_FormatImage.Click
        textControl1.ImageAttributesDialog()
    End Sub

    Private Sub ContextMenu_Text_Cut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_Cut.Click
        Cut()
    End Sub

    Private Sub ContextMenu_Text_Copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_Copy.Click
        Copy()
    End Sub

    Private Sub ContextMenu_Text_Paste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_Paste.Click
        Paste()
    End Sub

    Private Sub ContextMenu_Text_Character_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_Character.Click
        textControl1.FontDialog()
    End Sub

    Private Sub ContextMenu_Text_Paragraph_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_Paragraph.Click
        textControl1.ParagraphFormatDialog()
    End Sub

    Private Sub ContextMenu_Text_BulletsAndNumbering_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_BulletsAndNumbering.Click
        textControl1.ListFormatDialog()
    End Sub

    Private Sub ContextMenu_Text_InsertTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_InsertTable.Click
        Dim InsertTableDialog As frmInsertTable = New frmInsertTable
        InsertTableDialog.tx = textControl1
        InsertTableDialog.ShowDialog()
    End Sub

    Private Sub ContextMenu_Text_TableProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContextMenu_Text_TableProperties.Click
        textControl1.TableFormatDialog()
    End Sub
#End Region

    Public Sub resizeControl(ByVal w As Double, ByVal h As Double)
        Me.Width = w
        Me.Height = h
    End Sub

    Public Sub feldEinfügen()
        Try
            Me.cTxtEditor1.addFelder(Me, Me.textControl1)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub geheZuFeld()
        Try
            Me.textControl1.Focus()
            Me.cTxtEditor1.listeFelder(Me, Me.textControl1)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub textmarkenHervorheben()
        cTxtEditor1.textmarkenHervorheben(System.Drawing.Color.DarkRed, System.Drawing.Color.White, Me, Me.textControl1, True)
    End Sub

    Public Sub HervorhebenZurücksetzen()
        cTxtEditor1.textmarkenHervorheben(System.Drawing.Color.White, System.Drawing.Color.Black, Me, Me.textControl1, False)
    End Sub

    Private Sub setEditModeTextcontrol()
        Try
            If Me.lockEingbe Then Exit Sub

            If Not callEditorKeyPress Is Nothing Then
                callEditorKeyPress.Invoke(True)
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function showText(ByVal txt As String, ByVal typ As TXTextControl.StreamType, ByVal eingabeJN As Boolean,
            ByVal viewMod As TXTextControl.ViewMode, Optional ByRef bytes() As Byte = Nothing) As Boolean

        Me.FileNew(False, False)

        If eingabeJN Then
            Me.lockEingbe = False
        Else
            Me.lockEingbe = True
        End If

        If txt = "" And bytes Is Nothing Then Exit Function
        Me.doEditor.showText(txt, typ, eingabeJN, viewMod, Me.textControl1, bytes)

        FileHandler1.DocumentFileName = ""
        Return True
    End Function

    Public Function showFile(ByVal docu As String, ByVal lockEingbe As Boolean,
                            ByVal typ As TXTextControl.StreamType, ByVal view As TXTextControl.ViewMode,
                            ByVal temporär As Boolean) As Boolean

        Dim funct1 As New QS2.functions.vb.funct()
        Dim tmpFile As String = ""
        If temporär Then
            tmpFile = ENV._path_temp + "\" + funct1.getFileName(docu, True) + "_" + System.Guid.NewGuid.ToString + System.IO.Path.GetExtension(docu)
            System.IO.File.Copy(docu, tmpFile)
        Else
            tmpFile = docu
        End If

        Me.FileNew(False, False)
        Me.lockEingbe = lockEingbe

        FileHandler1.DocumentFileName = tmpFile
        'FileOpen()
        If FileHandler1.FileOpen() Then
            If Not Me.mainForm Is Nothing Then Me.mainForm.Text = FileHandler1.DocumentFileName
        End If

        textControl1.ViewMode = view

        Return True
    End Function

    Public Function clearForm() As Boolean
        Me.FileNew(False, False)
    End Function

    Private Sub AutomSeitennummerierungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomSeitennummerierungToolStripMenuItem.Click
        Me.doBookmarks.setPageOf(Me.textControl1, TXTextControl.HeaderFooterType.Footer, TXTextControl.HorizontalAlignment.Right, 7.5)
    End Sub

    Private Sub contTxtEditor_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.resizeControl()
    End Sub
    Public Sub resizeControl()
        If Not Me.contFelder1 Is Nothing Then Me.contFelder1.resizeControl(Me.PanelFelder.Width, Me.PanelFelder.Height)
    End Sub

    Private Sub UExpandableGroupBoxFelder_ExpandedStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UExpandableGroupBoxFelder.ExpandedStateChanged
        Me.resizeControl()
    End Sub

    Private Sub ToolStripButtonSaveDocuToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSaveDocuToDB.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim funct1 As New QS2.functions.vb.funct()
            Dim binInt() As Byte = Me.doEditor.getTextInByte(TXTextControl.BinaryStreamType.InternalFormat, Me.textControl1)
            Dim binExport() As Byte = Nothing

            If Me.TypDocu.Trim().ToLower() = (".pdf").ToLower() Then
                binExport = Me.doEditor.getTextInByte(TXTextControl.BinaryStreamType.AdobePDF, Me.textControl1)

            ElseIf Me.TypDocu.Trim().ToLower() = (".rtf").ToLower() Then
                Dim strDocu As String = Me.doEditor.getText(TXTextControl.StringStreamType.RichTextFormat, Me.textControl1)
                binExport = funct1.StringToByte(strDocu)

            ElseIf Me.TypDocu.Trim().ToLower() = (".html").ToLower() Then
                Dim strDocu As String = Me.doEditor.getText(TXTextControl.StringStreamType.HTMLFormat, Me.textControl1)
                binExport = funct1.StringToByte(strDocu)

            End If

            If Me.delOnSaveDocu(Me.IDDocu, binInt, binExport, Me.TypDocu) Then
                'generic.showMessageBox(generic.getRes("Dokument wurde gesichert!") + "!",
                '                     System.Windows.Forms.MessageBoxButtons.OK, "")
            Else
                Throw New Exception("ToolStripButtonSaveDocuToDB_Click: Error to save docu from editor to Db! (IDDocu='" + Me.IDDocu.ToString() + "')")
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub showUISaveDocuToDB(ByVal bOn As Boolean)
        Me.ToolStripButtonSaveDocuToDB.Visible = bOn
        Me.ToolStripSeparatorSpaceLast.Visible = bOn
    End Sub

#Region " TX Text Control Events "

    Private Sub textControl1_CausesValidationChanged_1(sender As System.Object, e As System.EventArgs) Handles textControl1.CausesValidationChanged

    End Sub

    Private Sub textControl1_Changed_1(sender As System.Object, e As System.EventArgs) Handles textControl1.Changed
        Try
            FileHandler1.DocumentDirty = True
            EnableToolbarButtons()
            UpdateSaveStatus()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_Click_1(sender As System.Object, e As System.EventArgs) Handles textControl1.Click

    End Sub

    Private Sub textControl1_DockChanged_1(sender As System.Object, e As System.EventArgs) Handles textControl1.DockChanged

    End Sub

    Private Sub textControl1_DocumentLinkClicked_1(sender As System.Object, e As TXTextControl.DocumentLinkEventArgs) Handles textControl1.DocumentLinkClicked
        Try
            e.DocumentLink.ScrollTo()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_HeaderFooterActivated_1(sender As System.Object, e As TXTextControl.HeaderFooterEventArgs) Handles textControl1.HeaderFooterActivated
        Try
            m_ActiveHeaderFooter = e.HeaderFooter
            EnableToolbarButtons()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_HeaderFooterDeactivated_1(sender As System.Object, e As TXTextControl.HeaderFooterEventArgs) Handles textControl1.HeaderFooterDeactivated
        Try
            If Not Me.mouseIsInFieldseditor Then           'Not Me.isDialogBookmarks And
                m_ActiveHeaderFooter = Nothing
                EnableToolbarButtons()
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_HypertextLinkClicked_1(sender As System.Object, e As TXTextControl.HypertextLinkEventArgs) Handles textControl1.HypertextLinkClicked
        Try
            If e.HypertextLink.Target.Trim().ToLower().StartsWith(("var_").Trim().ToLower()) Then
                If Not IsNothing(Me.delOnHyperlinkClicked) Then
                    Dim retStr As String = Me.delOnHyperlinkClicked.Invoke(e.HypertextLink.Target.Trim())
                End If
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_ImageRightClicked_1(sender As System.Object, e As TXTextControl.ImageEventArgs) Handles textControl1.ImageRightClicked
        Try
            ContextMenu_Images.Show(Me, Me.PointToClient(System.Windows.Forms.Cursor.Position))
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_InputPositionChanged_1(sender As System.Object, e As System.EventArgs) Handles textControl1.InputPositionChanged
        Try
            EnableToolbarButtons()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textControl1.KeyPress
        If Me.lockEingbe Then
            e.KeyChar = ""
        Else : RaiseEvent textControl1_IsToSave(True)
            ISTOSAVE = True
        End If
        Me.setEditModeTextcontrol()
    End Sub

    Private Sub textControl1_MouseDown_1(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles textControl1.MouseDown
        Try
            Dim pos As System.Drawing.Point = New System.Drawing.Point(e.X, e.Y)
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                ContextMenu_Text.Show(Me, pos)
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_MouseEnter_1(sender As System.Object, e As System.EventArgs) Handles textControl1.MouseEnter
        Me.mouseIsInFieldseditor = False
    End Sub

    Private Sub textControl1_TextFrameRightClicked_1(sender As System.Object, e As TXTextControl.TextFrameEventArgs) Handles textControl1.TextFrameRightClicked
        Try
            If textControl1.TextFrames.GetItem Is Nothing Then
                ContextMenu_Text.Show(Me, Me.PointToClient(System.Windows.Forms.Cursor.Position))
            Else
                ContextMenu_TextFrames.Show(Me, Me.PointToClient(System.Windows.Forms.Cursor.Position))
            End If
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_Validated_1(sender As System.Object, e As System.EventArgs) Handles textControl1.Validated
        If Me.lockEingbe Then
        End If
        'Me.setEditModeTextcontrol()
    End Sub

    Private Sub textControl1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            EnableToolbarButtons()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

#End Region



    Private Sub CheckRessourcenHandlerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CheckRessourcenHandlerToolStripMenuItem1.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim sTitle As String = generic.getRes("Save")
            Dim sText As String = generic.getRes("SaveChangesToX")
            Dim txtOptional As String = "ENV._path_log='" + ENV._path_log + "',  ENV._path_temp='" + ENV._path_temp + "'"
            sText = String.Format(sText, " [Any path] ")
            generic.showMessageBox(sText, System.Windows.Forms.MessageBoxButtons.OK, sTitle, txtOptional)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub TestExceptionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TestExceptionToolStripMenuItem1.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Throw New Exception("Test-exception from TxtEditor.dll")

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub setForSaveDB(ByVal uiParent As Object, ByVal selRow As Object)
        'Me.uiParent = uiParent
        'Me.selRow = selRow
        'Me.ToolStripButtonSaceTB.Enabled = True
    End Sub


    Sub spellCheckDialog_Click(ByVal sender As Object, ByVal e As EventArgs)
        Spelling.getSpellChecker.SpellCheckDialog.Show(Me.textControl1)
    End Sub

    ' Open the built-in options dialog when the "Options..." item was clicked
    Sub optionsDialog_Click(ByVal sender As Object, ByVal e As EventArgs)
        Spelling.getSpellChecker.OptionsDialog()
    End Sub

    Private Sub textControl1_TextContextMenuOpening(sender As Object, e As TextContextMenuEventArgs) Handles textControl1.TextContextMenuOpening
        Try
            Dim cContextMenü1 As New cContextMenü()
            cContextMenü1.TXTControlField_TextContextMenuOpening(sender, e, Me.contextMenuStripSpell, Spelling.getSpellChecker, Me.doSpellChecking, DesignMode, Me.textControl1)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub textControl1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles textControl1.KeyDown
        Try
            If e.KeyCode = System.Windows.Forms.Keys.F7 Then
                If Me.doSpellChecking Then
                    Spelling.getSpellChecker.SpellCheckDialog.Show(Me.textControl1)
                End If
            End If
            'If Me._bReadOnly Then
            '    e.SuppressKeyPress = True
            'End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub SpracheFestlegenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpracheFestlegenToolStripMenuItem.Click
        Me.textControl1.LanguageDialog()
    End Sub

End Class
