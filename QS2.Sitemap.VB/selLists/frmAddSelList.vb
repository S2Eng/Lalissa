Imports qs2.core.vb
Imports qs2.sitemap
Imports qs2.Resources


Public Class frmAddSelList



    Private Sub frmAddSelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.loadRes()

            Me.ContAddSelList1.mainWindow = Me
            Me.ContAddSelList1.initControl()

            Me.ContAddSelList1.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            If Me.ContAddSelList1.typUI = contAddSelList.eTypUI.newQueryUser Then
                Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
                If Me.ContAddSelList1.isNew Then
                    Me.Text = qs2.core.language.sqlLanguage.getRes("AddNewQuery")
                Else
                    Me.Text = qs2.core.language.sqlLanguage.getRes("EditQuery")
                End If


                If Me.ContAddSelList1.typUI = contAddSelList.eTypUI.newQueryGroup Then
                    Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
                    Me.Text = qs2.core.language.sqlLanguage.getRes("AddNewQueryGroup")

                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmAddSelList_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            Me.ContAddSelList1.txtDescription.Focus()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmAddSelList_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class