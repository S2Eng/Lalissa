Public Class frmHyperlink

    Public txMain As TXTextControl.TextControl
    Private LoadedFile As String

    Private Sub FillTargetsListbox(ByVal tx As TXTextControl.TextControl)
        lstTargets.Items.Clear()
        For Each Target As TXTextControl.DocumentTarget In tx.DocumentTargets
            lstTargets.Items.Add(Target.TargetName)
        Next
    End Sub

    Private Function GetTargetID(ByVal tx As TXTextControl.TextControl, ByVal TargetName As String) As Integer
        For Each Target As TXTextControl.DocumentTarget In tx.DocumentTargets
            If Target.TargetName = TargetName Then
                Return Target.ID
            End If
        Next
        Return 0
    End Function

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim CurrentLink As TXTextControl.HypertextLink = txMain.HypertextLinks.GetItem
        Dim IsExternalLink As Boolean
        If txtLinkTarget.Text.StartsWith("#") Then
            IsExternalLink = False
            txtLinkTarget.Text = txtLinkTarget.Text.Remove(0, 1)
        Else
            IsExternalLink = True
        End If
        If CurrentLink Is Nothing Then
            If IsExternalLink Then
                Dim ExternalLink As TXTextControl.HypertextLink = New TXTextControl.HypertextLink(txtLinkedText.Text, txtLinkTarget.Text)
                txMain.HypertextLinks.Add(ExternalLink)
            Else
                Dim TargetID As Integer = GetTargetID(txMain, txtLinkTarget.Text)
                Dim InternalLink As TXTextControl.DocumentLink = New TXTextControl.DocumentLink(txtLinkedText.Text, txMain.DocumentTargets.GetItem(TargetID))
                txMain.DocumentLinks.Add(InternalLink)
            End If
        Else
            CurrentLink.Text = txtLinkedText.Text
            CurrentLink.Target = txtLinkTarget.Text
        End If
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub optCurPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCurPage.CheckedChanged
        If Not (txMain Is Nothing) Then
            FillTargetsListbox(txMain)
        End If
    End Sub

    Private Sub optSelFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSelFile.CheckedChanged
        FillTargetsListbox(txHidden)
    End Sub

    Private Sub cmdChooseFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdChooseFile.Click
        Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
        txHidden.Load(TXTextControl.StreamType.All, LoadSettings)
        txtLinkTarget.Text = LoadSettings.LoadedFile
        LoadedFile = LoadSettings.LoadedFile
    End Sub

    Private Sub lstTargets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTargets.SelectedIndexChanged
        txtLinkTarget.Text = LoadedFile + "#" + lstTargets.SelectedItem
    End Sub

    Private Sub RequiredFields_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLinkedText.TextChanged, txtLinkTarget.TextChanged
        cmdOK.Enabled = (Not (txtLinkedText.Text = "") And (Not (txtLinkTarget.Text = "")))
    End Sub

    Private Sub frmHyperlink_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ExternalLink As TXTextControl.HypertextLink = txMain.HypertextLinks.GetItem
        Dim InternalLink As TXTextControl.DocumentLink = txMain.DocumentLinks.GetItem
        If Not (ExternalLink Is Nothing) Then
            txtLinkedText.Text = ExternalLink.Text
            txtLinkTarget.Text = ExternalLink.Target
            optCurPage.Enabled = False
            optSelFile.Checked = True
        Else
            If Not (InternalLink Is Nothing) Then
                txtLinkedText.Text = InternalLink.Text
                txtLinkTarget.Text = InternalLink.DocumentTarget.TargetName
                optCurPage.Checked = True
                optSelFile.Enabled = False
            End If
        End If
        cmdOK.Enabled = (Not (txtLinkedText.Text = "") AndAlso Not (txtLinkTarget.Text = ""))
        FillTargetsListbox(txMain)
        txHidden.Left = Width
        LoadedFile = ""
    End Sub
End Class