Imports qs2.core.vb
Imports qs2.Resources



Public Class frmSelLists


    Public doSearchAuto As Boolean = False
    Public searchAuto As String = ""
    Public typeQuery As New qs2.core.Enums.eTypeQuery()
    Public _Private As Boolean = False
    Public TypeStr As String = ""

    Public typeUI As New eTypeUI()
    Public Enum eTypeUI
        manageQueriesUser = 0
        manageQueriesAdmin = 1
        manageQueryGroups = 2

        selectRow = 3

        Administration = 100
    End Enum

    Public UnvisibleOnClose As Boolean = False
    Public _OnlyOwnSelListsEditable As Boolean = True
    Public _OnlyUserSelListsEditable As Boolean = True








    Private Sub frmAuswahllisten2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadForm()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub loadForm()
        Try

            Me.CancelButton = Me.ContSelList1.btnClose2

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)
            Me.loadRes()

            Me.ContSelList1.mainWindow = Me

            Dim alwaysShowApplicationSelection As Boolean = True
            If Me.typeUI = eTypeUI.manageQueriesUser Or Me.typeUI = eTypeUI.selectRow Or Me.typeUI = eTypeUI.manageQueryGroups Then
                alwaysShowApplicationSelection = False
            End If
            Me.ContSelList1.initControl(alwaysShowApplicationSelection)
            Me.ContSelList1.compSelListEntrys.initControl()

            Me.ContSelList1.loadGroups(Me.ContSelList1.IDGruppeStr)

            If Me.doSearchAuto Then
                Me.ContSelList1.txtSearchText.Text = Me.searchAuto.Trim()
                Me.ContSelList1.doSearch()
            End If

            If Me.ContSelList1.IDGruppeStr.Trim() <> "" Then

                'Me.ContSelList1.loadSelListxy()

                If Me.typeUI = eTypeUI.manageQueriesAdmin Or Me.typeUI = eTypeUI.manageQueryGroups Or Me.typeUI = eTypeUI.selectRow Then
                    Me.Width = 950
                Else
                    Me.Width = 800
                End If

                Me.Height = 570

                Me.MinimizeBox = True
                Me.MaximizeBox = True
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                'Me.ContSelList1.rSelListLastAdded = Me.ContSelList1.addSelListEntry(Me._Private, Me.TypeStr)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Public Sub loadRes()
        Try
            If Me.ContSelList1.IDGruppeStr.Trim() <> "" Then
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(Me.ContSelList1.IDGruppeStr, Me.ContSelList1.IDParticipant, Me.ContSelList1.defaultApplication)
                Me.Text = qs2.core.language.sqlLanguage.getRes("SelList") + " "
                If resFound.Trim() = "" Then
                    Me.Text += Me.ContSelList1.IDGruppeStr
                Else
                    Me.Text += resFound
                End If
            Else
                Me.Text = qs2.core.language.sqlLanguage.getRes("SelectionLists") + " (" + _
                           qs2.core.language.sqlLanguage.getRes("ActiveLanguage") + ": " + qs2.core.language.sqlLanguage.getRes(qs2.core.ENV.language.ToString()) + ")"

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmSelLists_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Me.UnvisibleOnClose Then
                Me.Visible = False
                e.Cancel = True
            Else

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmSelLists_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
                'Dim pars As New qs2.core.Settings.cParsCalMainFunction()
                'pars.UICoontrol = Me
                'pars.UIComponents = Me.components
                'qs2.core.Settings.CallFunctionMain(core.Settings.eTypeFunction.doColorManagment, pars)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class