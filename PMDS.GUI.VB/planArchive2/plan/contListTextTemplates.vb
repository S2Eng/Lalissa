Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing




Public Class contListTextTemplates

    Public mainWindow As frmNachricht3 = Nothing
    Public isLoaded As Boolean = False
    Public doUI1 As New doUI()
    Public sitemap1 As New PMDS.Global.UIGlobal()

    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing





    Private Sub contObjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub


    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.btnEdit.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32)

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo
            info.ToolTipText = doUI.getRes("EditTextTemplates")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnEdit, info)

            Me.loadData()
            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contListTextTemplates.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData()
        Try
            Me.DsAutoDocu1.Clear()
            Me.CompAutoDocu1.getTextTamplates(Nothing, Me.DsAutoDocu1, compAutoDocu.eSelTextTemplates.All)
            Me.gridTextTemplates.Refresh()

        Catch ex As Exception
            Throw New Exception("contListTextTemplates.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal withMsgBox As Boolean) As dsAutoDocu.tblTextTemplatesRow
        Try
            If Not Me.gridTextTemplates.ActiveRow Is Nothing Then
                If Me.gridTextTemplates.ActiveRow.IsGroupByRow Or Me.gridTextTemplates.ActiveRow.IsFilterRow Then
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridTextTemplates.ActiveRow.ListObject
                    Dim rSelRow As dsAutoDocu.tblTextTemplatesRow = v.Row
                    Return rSelRow
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contListTextTemplates.getSelectedRow:" + ex.ToString())
        End Try
    End Function

    Public Sub FileOpenxy(ByRef showMsgBox As Boolean)
        Try
            'Dim rTextTemplateFile As dsAutoDocu.tblTextTemplatesRow = Me.getSelectedRow(showMsgBox)
            'If Not rTextTemplateFile Is Nothing Then
            '    Dim clOpen As New ITSCont.core.SystemDb.clFolder
            '    Dim clArchiv As New ITSCont.core.SystemDb.cArchiv()
            '    clOpen.openFile(clArchiv.getFileFromDB(rTextTemplateFile.Bezeichnung, rTextTemplateFile.FileType, rTextTemplateFile.Docu), "", False, Nothing, False, True, False)
            'End If

        Catch ex As Exception
            Throw New Exception("contListTextTemplates.FileOpen: " + ex.ToString())
        End Try
    End Sub
    Public Sub SaveFileAsxy()
        Try
            'Dim rTextTemplateFile As dsAutoDocu.tblTextTemplatesRow = Me.getSelectedRow(True)
            'If Not rTextTemplateFile Is Nothing Then
            '    Dim clOpen As New ITSCont.core.SystemDb.clFolder
            '    Dim clArchiv As New ITSCont.core.SystemDb.cArchiv()
            '    clOpen.saveFileAs(clArchiv.getFileFromDB(rTextTemplateFile.Bezeichnung, rTextTemplateFile.FileType, rTextTemplateFile.Docu), rTextTemplateFile.FileType)
            'End If

        Catch ex As Exception
            Throw New Exception("contListTextTemplates.SaveFileAs: " + ex.ToString())
        End Try
    End Sub



    Private Sub gridTextTemplates_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles gridTextTemplates.BeforeCellActivate
        Try
            e.Cell.Activation = Activation.NoEdit

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub gridTextTemplates_DoubleClick(sender As Object, e As EventArgs) Handles gridTextTemplates.DoubleClick
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.sitemap1.evDoubleClickOK(sender, e, Me.gridTextTemplates) Then
                Dim rTextTemplateFile As dsAutoDocu.tblTextTemplatesRow = Me.getSelectedRow(False)
                If Not rTextTemplateFile Is Nothing Then
                    Me.mainWindow.SetTextTemplate(rTextTemplateFile.ID, Me.chkTextIsHtml.Checked)
                End If
            End If

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub gridTextTemplates_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridTextTemplates.BeforeRowsDeleted
        Try
            e.DisplayPromptMsg = False
            e.Cancel = True

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub


    Private Sub NeuLadenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuLadenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.loadData()

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateiÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.FileOpen(True)

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub SpeichernUnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.SaveFileAs()

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim frmTextTemplates1 As New frmTextTemplates()
            frmTextTemplates1.ShowDialog()
            Me.loadData()

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
