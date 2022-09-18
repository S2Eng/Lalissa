

Public Class frmLayoutManager



    Private Sub frmAuswahlistenObj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(IDResGridxy As String, ManageMode As Boolean, NameLayout As String, ExtendedView As Boolean)
        Try
            Me.CancelButton = Me.ContLayoutGrid1.btnClose

            Me.ContLayoutGrid1.mainWindow = Me
            If IDResGridxy.Trim() = "" Then
                Me.Text = qs2.core.language.sqlLanguage.getRes("LayoutManager")
            Else
                Dim NameTmp As String = ""
                If NameLayout.Trim() <> "" Then
                    NameTmp = NameLayout.Trim()
                Else
                    NameTmp = IDResGridxy.Trim()
                End If
                Me.Text = qs2.core.language.sqlLanguage.getRes("LayoutManager") + " " + qs2.core.language.sqlLanguage.getRes(NameTmp)
            End If
            If Me.ContLayoutGrid1.cLayoutManager1._LayoutKey.Trim() <> "" Then
                Me.Text += "  (" + Me.ContLayoutGrid1.cLayoutManager1._LayoutKey + ")"
            End If

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.ContLayoutGrid1.mainWindow = Me
            Me.ContLayoutGrid1.initControl(ManageMode, ExtendedView)
            Me.ContLayoutGrid1.lockUnlock(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

End Class