


Public Class clFields


    Public listFields As New ArrayList
    Public statFeldHervorge As Boolean = False
    Public Class cFld
        Public name As String = ""
        Public forCol As System.Drawing.Color
        Public backCol As System.Drawing.Color
    End Class




    Public Function insertField(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl, _
                         ByVal fld As String, ByVal txt As String, ByVal NumbField As Boolean) As TXTextControl.TextField
        Try
            Dim Field As New TXTextControl.TextField()
            If NumbField Then Field = New TXTextControl.PageNumberField(1, TXTextControl.NumberFormat.ArabicNumbers)

            Field.Name = fld
            Field.Text = txt

            If Not modalWindow.m_ActiveHeaderFooter Is Nothing Then
                If NumbField Then
                    If (Not modalWindow.m_ActiveHeaderFooter.PageNumberFields.Add(Field)) Then
                        generic.showMessageBox(generic.getRes("FieldCanNotInsertedTheCursorIsInAField") + "!", _
                                Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    If (Not modalWindow.m_ActiveHeaderFooter.TextFields.Add(Field)) Then
                        generic.showMessageBox(generic.getRes("FieldCanNotInsertedTheCursorIsInAField") + "!", _
                                Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                End If
            Else
                If (Not txtControl.TextFields.Add(Field)) Then
                    generic.showMessageBox(generic.getRes("FieldCanNotInsertedTheCursorIsInAField") + "!", _
                                                    Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If
            Return Field

        Catch ex As Exception
            Throw New Exception("clFields.insertField: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Sub addFelder(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl)
        Try
            'If txtControl.Text = "" Then
            '    MsgBox("Bitte zuerst einen Text markieren!")
            'ElseIf txtControl.Selection.Length = 0 Then
            '    MsgBox("Bitte zuerst einen Text markieren!")
            'Else
            modalWindow.isDialogBookmarks = True
            Dim InsertDialog As New frmInsertField()
            InsertDialog.modalWindow = modalWindow
            InsertDialog.tx = txtControl
            InsertDialog.ShowDialog()
            modalWindow.isDialogBookmarks = False

        Catch ex As Exception
            Throw New Exception("clFields.addFelder: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub listeFelder(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl)
        Try
            modalWindow.isDialogBookmarks = True
            Dim GotoDialog As New frmGotoField()
            GotoDialog.modalWindow = modalWindow
            GotoDialog.tx = txtControl
            GotoDialog.ShowDialog()
            modalWindow.isDialogBookmarks = True

        Catch ex As Exception
            Throw New Exception("clFields.listeFelder: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub textmarkenHervorheben(ByVal backCol As System.Drawing.Color, ByVal forCol As System.Drawing.Color, _
                                     ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl, _
                                     ByVal bHervorheben As Boolean)


        Dim Field As TXTextControl.TextField

        'If textControl1.HeadersAndFooters.Count() = 0 Then
        '    MsgBox("Es wurde keine Kopf bzw. Fußzeile eingefügt!", MsgBoxStyle.Information, "Texteditor")
        '    Exit Sub
        'End If

        modalWindow.isDialogBookmarks = True

        Dim col As New System.Drawing.Color()
        If bHervorheben Then
            col = Drawing.Color.LightBlue
        Else
            col = Drawing.Color.White
        End If

        If Not modalWindow.m_ActiveHeaderFooter Is Nothing Then
            For Each Field In modalWindow.m_ActiveHeaderFooter.TextFields
                txtControl.Selection.Start = Field.Start - 1
                txtControl.Selection.Length = Field.Length
                txtControl.Selection.TextBackColor = col
            Next
            For Each Field In modalWindow.m_ActiveHeaderFooter.PageNumberFields
                txtControl.Selection.Start = Field.Start - 1
                txtControl.Selection.Length = Field.Length
                txtControl.Selection.TextBackColor = col
            Next
        Else
            For Each Field In txtControl.TextFields
                txtControl.Selection.Start = Field.Start - 1
                txtControl.Selection.Length = Field.Length
                txtControl.Selection.TextBackColor = col
            Next
        End If

        modalWindow.isDialogBookmarks = False
    End Sub
    Public Sub feldLöschen(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl, _
                            ByRef cbo As System.Windows.Forms.ComboBox)
        Try
            If Not modalWindow.m_ActiveHeaderFooter Is Nothing Then
                For Each Field As TXTextControl.TextField In modalWindow.m_ActiveHeaderFooter.TextFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.TextFields.Remove(Field)
                        txtControl.Focus()
                        Exit For
                    End If
                Next
                For Each Field As TXTextControl.TextField In modalWindow.m_ActiveHeaderFooter.PageNumberFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.TextFields.Remove(Field)
                        txtControl.Focus()
                        Exit For
                    End If
                Next
            Else
                For Each Field As TXTextControl.TextField In txtControl.TextFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.TextFields.Remove(Field)
                        txtControl.Focus()
                        Exit For
                    End If
                Next
            End If

            Me.loadTextmarken(modalWindow, txtControl, cbo)

        Catch ex As Exception
            Throw New Exception("clFields.feldLöschen: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub loadTextmarken(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl, _
                            ByRef cbo As System.Windows.Forms.ComboBox)
        Try

            Dim field As TXTextControl.TextField
            cbo.Items.Clear()

            If Not modalWindow.m_ActiveHeaderFooter Is Nothing Then
                For Each field In modalWindow.m_ActiveHeaderFooter.TextFields
                    cbo.Items.Add(field.Name)
                Next
                For Each field In modalWindow.m_ActiveHeaderFooter.PageNumberFields
                    cbo.Items.Add(field.Name)
                Next
            Else
                For Each field In txtControl.TextFields
                    cbo.Items.Add(field.Name)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("clFields.loadTextmarken: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function geheZuFeld(ByRef modalWindow As contTxtEditor, ByRef txtControl As TXTextControl.TextControl, _
                            ByRef cbo As System.Windows.Forms.ComboBox) As Boolean
        Try

            Dim Field As TXTextControl.TextField

            If Not modalWindow.m_ActiveHeaderFooter Is Nothing Then
                For Each Field In modalWindow.m_ActiveHeaderFooter.TextFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Selection.Start = Field.Start - 1
                        txtControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Selection.Length = Field.Length
                    End If
                Next
                For Each Field In modalWindow.m_ActiveHeaderFooter.PageNumberFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Selection.Start = Field.Start - 1
                        txtControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Selection.Length = Field.Length
                    End If
                Next
            Else
                For Each Field In txtControl.TextFields
                    If (Field.Name = cbo.Text) Then
                        txtControl.Selection.Start = Field.Start - 1
                        txtControl.Selection.Length = Field.Length
                    End If
                Next
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("clFields.geheZuFeld: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

End Class
