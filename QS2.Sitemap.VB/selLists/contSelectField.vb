


Public Class contSelectField

    Public IDApplication As String = ""
    Public IDParticipant As String = ""
    Public abort As Boolean = True

    Public mainWindow As frmSelectField

    Public selectedTab As New eTab
    Public Enum eTab
        Chapter = 0
        Database = 1
    End Enum

    Public onlyDBFields As Boolean = False
    Public lstTablesToShow As System.Collections.ArrayList
    Public doUnvisibleAllOtherTables As Boolean = False

    Public rSelQuery As qs2.core.vb.dsAdmin.tblSelListEntriesRow = Nothing
    Public SelectedTypQueryDef As String = ""
    Public modeQueryUI As qs2.core.Enums.eTypeQuery = Nothing

    Public lockToolBar = False
    Public SelectionWithoutClosing As Boolean = False

    Public add As Boolean = False








    Private Sub contSelectField_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl(ByVal typ As workflowAssist.contInfoFieldDB.eTypUI)
        Try
            Me.UltraTabControlAll.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
            Me.UltraTabControlSelectFrom.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard

            Me.selectedTab = eTab.Chapter
            Me.loadRes()

            Me.btnOK.Width = 130
            Me.btnCancel.Left = Me.btnOK.Left + Me.btnOK.Width + 2

            Me.ContInfoFieldDB1.withTranslation = True
            Me.ContInfoFieldDB1.IDApplication = Me.IDApplication
            Me.ContInfoFieldDB1.IDParticipant = Me.IDParticipant
            Me.ContInfoFieldDB1.typUI = typ
            Me.ContInfoFieldDB1.initControl(Me.lstTablesToShow, Me.doUnvisibleAllOtherTables)
            'Me.ContInfoFieldDB1.loadTables(Me.lstTablesToShow)

            If Not onlyDBFields Then
                Me.ContSelChaptFldShort1.IDApplication = Me.IDApplication
                Me.ContSelChaptFldShort1.IDParticipant = Me.IDParticipant
                Me.ContSelChaptFldShort1.initControl()

                Dim dOnValueChangedChapters As New contSelChaptFldShort.onSelection(AddressOf Me.onGridDoubleClick)
                Me.ContSelChaptFldShort1.delOnSelection = dOnValueChangedChapters
            End If

            Dim dOnValueChangedDatabase As New qs2.sitemap.workflowAssist.contInfoFieldDB.onSelection(AddressOf Me.onGridDoubleClick)
            Me.ContInfoFieldDB1.delOnSelection = dOnValueChangedDatabase

            Dim dOnTranslate1 As New qs2.sitemap.workflowAssist.contInfoFieldDB.onTranslate(AddressOf Me.ContSelChaptFldShort1.openTranslate)
            Me.ContInfoFieldDB1.delDoTranslate = dOnTranslate1

            If onlyDBFields Then
                Me.toolbarsManagerSelectFrom.Visible = False
                Me.selectTab(eTab.Database.ToString())
                Me.selectedTab = eTab.Database
            End If

            If Not Me.rSelQuery Is Nothing Then

                If Me.modeQueryUI = core.Enums.eTypeQuery.User And _
                        Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower()) And _
                        Me.rSelQuery.TypeStr.Trim().ToLower().Equals(core.Enums.eTypeQuery.User.ToString().Trim().ToLower()) Then

                    Me.toolbarsManagerSelectFrom.Visible = False
                    Me.selectTab(eTab.Chapter.ToString())
                    Me.selectedTab = eTab.Chapter

                ElseIf Me.modeQueryUI = core.Enums.eTypeQuery.Admin And _
                        Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower()) And _
                        Me.SelectedTypQueryDef.Trim().ToLower() = qs2.core.Enums.eTypQueryDef.SelectFields.ToString().Trim().ToLower() Then

                    Me.toolbarsManagerSelectFrom.Visible = True
                    Me.selectTab(eTab.Chapter.ToString())
                    Me.selectedTab = eTab.Chapter

                ElseIf Me.modeQueryUI = core.Enums.eTypeQuery.Admin And _
                        Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower()) And _
                        (Me.SelectedTypQueryDef.Trim().ToLower() = qs2.core.Enums.eTypQueryDef.SelectFields.ToString().Trim().ToLower() Or _
                        Me.SelectedTypQueryDef.Trim().ToLower() = qs2.core.Enums.eTypQueryDef.WhereConditions.ToString().Trim().ToLower()) Then

                    Me.selectTab(eTab.Database.ToString())
                    Me.selectedTab = eTab.Database

                ElseIf Me.modeQueryUI = core.Enums.eTypeQuery.Admin And _
                        Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower()) And _
                        (Me.SelectedTypQueryDef.Trim().ToLower() = qs2.core.Enums.eTypQueryDef.InputParameters.ToString().Trim().ToLower() Or _
                        Me.SelectedTypQueryDef.Trim().ToLower() = qs2.core.Enums.eTypQueryDef.InputParameters.ToString().Trim().ToLower()) Then

                    Me.selectTab(eTab.Database.ToString())
                    Me.selectedTab = eTab.Database

                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.btnCancel.initControl()
            Me.btnOK.initControl()

            If Me.SelectionWithoutClosing Then
                Me.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Close")
                Me.btnOK.Text = qs2.core.language.sqlLanguage.getRes("Take")
            Else
                Me.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel")
                Me.btnOK.Text = qs2.core.language.sqlLanguage.getRes("OK")
            End If

            Me.toolbarsManagerSelectFrom.Tools(eTab.Chapter.ToString()).SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Chapter")
            Me.toolbarsManagerSelectFrom.Tools(eTab.Database.ToString()).SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Database")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub toolbarsManagerSelectFrom_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles toolbarsManagerSelectFrom.ToolClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.lockToolBar Then
                Exit Sub
            End If

            Select Case e.Tool.Key
                Case eTab.Chapter.ToString()
                    Me.selectTab(e.Tool.Key)
                    Me.selectedTab = eTab.Chapter

                Case eTab.Database.ToString()
                    Me.selectTab(e.Tool.Key)
                    Me.selectedTab = eTab.Database

            End Select

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub selectTab(ByVal key As String)
        Try
            Me.UltraTabControlSelectFrom.ActiveTab = Me.UltraTabControlSelectFrom.Tabs(key)
            Me.UltraTabControlSelectFrom.SelectedTab = Me.UltraTabControlSelectFrom.Tabs(key)

            If key.Trim().ToLower() = eTab.Database.ToString().Trim().ToLower() Then
                Me.lockToolBar = True
                Dim toolBarButt As Infragistics.Win.UltraWinToolbars.StateButtonTool = Me.toolbarsManagerSelectFrom.Tools(eTab.Database.ToString())
                toolBarButt.Checked = True
                Me.lockToolBar = False
            End If

        Catch ex As Exception
            Me.lockToolBar = False
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.lockToolBar = False
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doSelect(Not Me.SelectionWithoutClosing, Me.ContSelChaptFldShort1.rSelListSelChapter2, Me.ContSelChaptFldShort1.StayTypeToShowChapters)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub onGridDoubleClick(ByVal close As Boolean)
        Try
            Me.doSelect(Not Me.SelectionWithoutClosing, Me.ContSelChaptFldShort1.rSelListSelChapter2, Me.ContSelChaptFldShort1.StayTypeToShowChapters)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub doSelect(ByVal close As Boolean, ByRef rSelListSelChapter As qs2.core.vb.dsAdmin.tblSelListEntriesRow, StayTypeToShowChapters As qs2.core.Enums.eStayTyp)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.selectedTab = eTab.Chapter Then
                If Me.ContSelChaptFldShort1.doSelectRows(True) Then
                    Me.abort = False
                    If (close) Then Me.mainWindow.Close()
                End If
                If Me.ContSelChaptFldShort1.SelectionWithoutClosing Then
                    'If Not Me.ContSelChaptFldShort1.delOnAddWithoutClosing Is Nothing Then
                    Me.ContSelChaptFldShort1.delOnAddWithoutClosing.Invoke(0, Me.ContSelChaptFldShort1.getSelectedRows(False), Me.ContSelChaptFldShort1.protocoll, Me.add, rSelListSelChapter, StayTypeToShowChapters, False)
                    'End If
                End If

            ElseIf Me.selectedTab = eTab.Database Then
                If Me.ContInfoFieldDB1.doSelectRows(True) Then
                    Me.abort = False
                    If (close) Then Me.mainWindow.Close()
                End If
                If Me.ContSelChaptFldShort1.SelectionWithoutClosing Then
                    'If Not Me.ContInfoFieldDB1.delOnAddWithoutClosing Is Nothing Then
                    Me.ContInfoFieldDB1.delOnAddWithoutClosing.Invoke(1, Me.ContInfoFieldDB1.getSelectedRowsColumns(False), Me.ContInfoFieldDB1.protocoll, Me.add, Nothing, StayTypeToShowChapters, False)
                    'End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
