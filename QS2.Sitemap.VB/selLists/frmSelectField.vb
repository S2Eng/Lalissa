Imports qs2.core.vb
Imports qs2.sitemap
Imports qs2.Resources



Public Class frmSelectField


    Public typpUI As New sitemap.workflowAssist.contInfoFieldDB.eTypUI




    Private Sub frmSelChaptFldShort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)
            Me.loadRes()

            Me.AcceptButton = Me.ContSelectField1.btnOK
            Me.CancelButton = Me.ContSelectField1.btnCancel

            If Me.typpUI = workflowAssist.contInfoFieldDB.eTypUI.selectionTables Then
                Me.Width = 577
            End If
            Me.ContSelectField1.mainWindow = Me
            Me.ContSelectField1.initControl(Me.typpUI)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            If Me.typpUI = workflowAssist.contInfoFieldDB.eTypUI.selectionColumns Then
                Me.Text = qs2.core.language.sqlLanguage.getRes("SelectAField")

            ElseIf Me.typpUI = workflowAssist.contInfoFieldDB.eTypUI.selectionTables Then
                Me.Text = qs2.core.language.sqlLanguage.getRes("SelectATable")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmSelectField_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
End Class