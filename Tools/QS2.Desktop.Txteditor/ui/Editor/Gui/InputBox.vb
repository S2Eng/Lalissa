Public Class InputBox
    Public Sub New(ByVal Caption As String)
        InitializeComponent()
        Me.Text = Caption
    End Sub

    Public Shared Function ShowInputBox(ByVal Caption As String, ByRef Input As String) As Boolean
        Dim Result As System.Windows.Forms.DialogResult
        Dim box As InputBox = New InputBox(Caption)
        Result = box.ShowDialog
        If Result = System.Windows.Forms.DialogResult.OK Then
            Input = box.textBox1.Text
        End If
        Return (Result = System.Windows.Forms.DialogResult.OK)
    End Function

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
        cmdOK.Enabled = (textBox1.Text.Length > 0)
    End Sub

    Private Sub InputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class