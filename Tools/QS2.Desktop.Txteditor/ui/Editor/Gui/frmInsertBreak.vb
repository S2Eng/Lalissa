Public Class frmInsertBreak
    Dim BreakKind As TXTextControl.SectionBreakKind = TXTextControl.SectionBreakKind.BeginAtNewPage
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim dpi As Integer = (1440 / tx.CreateGraphics().DpiX)
        If (InsertPageBreakRadio.Checked) Then
            tx.Selection.Text = Chr(12)
        ElseIf (InsertTextBreakRadio.Checked) Then
            tx.Selection.Text = vbLf
        Else : tx.Sections.Add(BreakKind)
        End If
        tx.ScrollLocation = New System.Drawing.Point(tx.ScrollLocation.X, tx.InputPosition.Location.Y - (tx.Sections.GetItem().Format.PageMargins.Top * dpi))
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub InsertPageBreakRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertPageBreakRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = False
        InsertPageBreakRadio.Checked = True
        InsertTextBreakRadio.Checked = False
    End Sub

    Private Sub InsertTextBreakRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertTextBreakRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = False
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = True
    End Sub

    Private Sub BeginAtNewPageRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginAtNewPageRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = True
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = False
        BreakKind = TXTextControl.SectionBreakKind.BeginAtNewPage
    End Sub

    Private Sub BeginAtNewLineRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginAtNewLineRadio.Click
        BeginAtNewLineRadio.Checked = True
        BeginAtNewPageRadio.Checked = False
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = False
        BreakKind = TXTextControl.SectionBreakKind.BeginAtNewLine
    End Sub
End Class