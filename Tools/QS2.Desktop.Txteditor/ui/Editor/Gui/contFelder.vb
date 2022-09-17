


Public Class contFelder

    Public modalWindow As contTxtEditor



    Private Sub contFelder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub uExpFelder_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles uExpFelder.ItemClick

    End Sub

    Public Sub initControl()
        Try
            Dim newRessourcesAdded As Integer = 0
            'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Function loadFields(ByVal ds As DataSet) As Boolean
        Try
            Me.uExpFelder.Groups.Clear()
            'Dim dsPatientInfo As New dsPatientInfo
            For Each t As DataTable In ds.Tables
                Dim grp As New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup
                Dim grpTxt As String = ""
                'If t.TableName.Trim().ToLower() = ("tblObject").Trim().ToLower() Then
                '    grpTxt = compAutoUI.getRes("Object")
                'Else
                grpTxt = t.TableName
                'End If

                grp.Text = grpTxt.Trim()
                grp.Key = t.TableName
                grp.ToolTipText = "Document-Printing-Fields for " + " " + t.TableName
                Me.uExpFelder.Groups.Add(grp)
                For Each col As System.Data.DataColumn In t.Columns              'dsPatientInfo.Abteilung.Columns
                    Dim itm As New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem
                    itm.Text = col.ToString
                    itm.Key = "[" + t.TableName + "_" + col.ToString + "]"
                    itm.Tag = "fld_" + t.TableName + "_" + System.Guid.NewGuid.ToString
                    itm.Settings.AppearancesSmall.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ICO_weis, 32, 32)
                    grp.Items.Add(itm)
                    itm.Settings.AppearancesSmall.HotTrackAppearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Zurueck, 32, 32)
                Next
                grp.Expanded = False
            Next

            'Me.mnuTable.MergeIndex = 5
            'Me.mnuTable.Name = "mnuTable"
            'Me.mnuTable.Size = New System.Drawing.Size(57, 20)
            'Me.mnuTable.Text = "Tabelle"

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Function
    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick

        Select Case e.Tool.Key

            Case "Einfügen"
                Me.modalWindow.feldEinfügen()

            Case "ListeFelder"
                Me.modalWindow.geheZuFeld()
                ' Me.clField.listeFelder(modalWindow, txtCont)

            Case "popUpHervorheben"

            Case "Hervorheben"
                Me.modalWindow.textmarkenHervorheben()

            Case "HervorhebenZurücksetzen"
                Me.modalWindow.HervorhebenZurücksetzen()

        End Select

    End Sub

    Private Sub uExpFelder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uExpFelder.Click

    End Sub

    Private Sub uExpFelder_ActiveItemChanging(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.CancelableItemEventArgs) Handles uExpFelder.ActiveItemChanging
        Try
            If Me.modalWindow.lockEingbe Then Exit Sub

            If uExpFelder.Focused Then
                If Microsoft.VisualBasic.Left(e.Item.Tag, 4) = "fld_" Then
                    ' Me.textControl1.Text.Insert(Me.textControl1.Selection.Start, e.Item.Text.ToString)

                    Dim FieldNew As TXTextControl.TextField
                    If Not Me.modalWindow.m_ActiveHeaderFooter Is Nothing And Me.modalWindow.mouseIsInFieldseditor Then
                        If Me.modalWindow.m_ActiveHeaderFooter.Selection Is Nothing Then
                            generic.showMessageBox(generic.getRes("NoTextpositionSelected"), Windows.Forms.MessageBoxButtons.OK, generic.getRes("InsertField"))
                            Exit Sub
                        End If

                        'Dim selBefor As Integer = Me.modalWindow.m_ActiveHeaderFooter.Selection.Start
                        'Me.modalWindow.m_ActiveHeaderFooter.Selection.Length = 0
                        Me.modalWindow.m_ActiveHeaderFooter.Selection.Text = " "
                    Else
                        If Me.modalWindow.textControl1.Selection Is Nothing Then
                            generic.showMessageBox(generic.getRes("NoTextpositionSelected"), Windows.Forms.MessageBoxButtons.OK, _
                                                            generic.getRes("InsertField"))
                            Exit Sub
                        End If

                        'Dim selBefor As Integer = Me.modalWindow.textControl1.Selection.Start
                        'Me.modalWindow.textControl1.Selection.Length = 0
                        Me.modalWindow.textControl1.Selection.Text = " "
                    End If

                    'Me.modalWindow.textControl1.InsertionMode = TXTextControl.InsertionMode.Insert
                    'Me.modalWindow.textControl1.Text = Me.modalWindow.textControl1.Selection.Text.Insert(Me.modalWindow.textControl1.Selection.Start, " ")
                    'Me.modalWindow.textControl1.Selection.Start = selBefor + 1

                    'Dim selStart As Integer = txtCont.Selection.Start

                    'txtCont.Select(selStart + 1, e.Item.Key.Length - 2)

                    If e.Item.Key.Trim() = "[System_AutoNumber]" Then
                        FieldNew = Me.modalWindow.cTxtEditor1.insertField(modalWindow, Me.modalWindow.textControl1, e.Item.Key.ToString, e.Item.Key.ToString, True)
                    Else
                        FieldNew = Me.modalWindow.cTxtEditor1.insertField(modalWindow, Me.modalWindow.textControl1, e.Item.Key.ToString, e.Item.Key.ToString, False)
                    End If
                    If Not FieldNew Is Nothing Then
                        'selBefor = Me.modalWindow.textControl1.Selection.Start
                        'Me.modalWindow.textControl1.Text = Me.modalWindow.textControl1.Text.Insert(Me.modalWindow.textControl1.Selection.Start, " ")
                        'Me.modalWindow.textControl1.Selection.Start = selBefor + 1

                        'txtCont.Focus()
                        'txtCont.Selection.Start = selStart + e.Item.Key.Length

                        If Not Me.modalWindow.m_ActiveHeaderFooter Is Nothing And Me.modalWindow.mouseIsInFieldseditor Then
                            Me.modalWindow.m_ActiveHeaderFooter.Selection.Text = " "
                        Else
                            Me.modalWindow.textControl1.Selection.Text = " "
                        End If
                        Me.modalWindow.textControl1.Focus()

                        uExpFelder.ActiveItem = Nothing
                        If Not Me.modalWindow.callEditorKeyPress Is Nothing Then Me.modalWindow.callEditorKeyPress.Invoke(True)
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub resizeControl(ByVal w As Integer, ByVal h As Integer)
        Me.Width = w
        Me.Height = h
    End Sub


    Private Sub uExpFelder_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uExpFelder.MouseLeave
        Me.modalWindow.mouseIsInFieldseditor = False
    End Sub
    Private Sub uExpFelder_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uExpFelder.MouseEnter
        Me.modalWindow.mouseIsInFieldseditor = True
    End Sub


End Class
