Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinTree
Imports QS2.Desktop.Txteditor.generic




Public Class contFelder2

    Public sConfigFile As String = ""


    Public arrFieldsObj() As dsManage.FieldsRow = Nothing
    Public nodObj As UltraTreeNode = Nothing

    Public arrFieldsContracts() As dsManage.FieldsRow = Nothing
    Public nodContract As UltraTreeNode = Nothing

    Public arrFieldsFonds() As dsManage.FieldsRow = Nothing
    Public nodFonds As UltraTreeNode

    Public arrFieldsSysFields() As dsManage.FieldsRow = Nothing
    Public nodSysFields As UltraTreeNode = Nothing


    Public modalWindow As contTxtEditor = Nothing
    Public IsFirstVisible As Boolean = False
    Public IsInitialized As Boolean = False

    Public Shared delDoRes As dGetRes
    Public Delegate Function dGetRes(ByVal IDRes As String) As String







    Private Sub contFelder2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    Public Sub initControl()
        Try
            Me.sConfigFile = ENV._path_Config.Trim() + "\" + "PrintFieldsDef.xml"
            Me.loadData()

        Catch ex As Exception
            Throw New Exception("contFelder2.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData()
        Try
            Me.DsManage1.Clear()
            Me.DsManage1.ReadXml(Me.sConfigFile.Trim(), XmlReadMode.IgnoreSchema)

            Me.arrFieldsObj = Me.DsManage1.Fields.Select(Me.DsManage1.Fields.CategoryColumn.ColumnName + "='Object'", Me.DsManage1.Fields.SortColumn.ColumnName + " asc")
            Me.arrFieldsContracts = Me.DsManage1.Fields.Select(Me.DsManage1.Fields.CategoryColumn.ColumnName + "='Contract'", Me.DsManage1.Fields.SortColumn.ColumnName + " asc")
            Me.arrFieldsFonds = Me.DsManage1.Fields.Select(Me.DsManage1.Fields.CategoryColumn.ColumnName + "='Fonds'", Me.DsManage1.Fields.ColumnNameColumn.ColumnName + " asc")
            Me.arrFieldsSysFields = Me.DsManage1.Fields.Select(Me.DsManage1.Fields.CategoryColumn.ColumnName + "='SysFields'", Me.DsManage1.Fields.FieldNameUIColumn.ColumnName + " asc")


            Dim TgFieldObj As New cTgFields()
            Me.nodObj = Me.treeFields.Nodes.Add(System.Guid.NewGuid.ToString(), "Object")
            nodObj.Tag = TgFieldObj
            For Each rField As dsManage.FieldsRow In arrFieldsObj
                Dim TgFields As New cTgFields()
                TgFields.rField = rField
                TgFields.ParentTgFields = TgFieldObj
                Dim nodObjField As UltraTreeNode = nodObj.Nodes.Add(System.Guid.NewGuid.ToString(), rField.FieldNameUI.Trim())
                nodObjField.Tag = TgFields

                Me.translateField(rField.ColumnName.Trim(), rField.DataTable.Trim(), rField.FieldNameUI.Trim())
            Next

            Dim TgFieldFonds As New cTgFields()
            Me.nodFonds = Me.treeFields.Nodes.Add(System.Guid.NewGuid.ToString(), "Fonds")
            Me.nodFonds.Tag = TgFieldFonds
            For Each rField As dsManage.FieldsRow In arrFieldsFonds
                Dim TgFields As New cTgFields()
                TgFields.rField = rField
                TgFields.ParentTgFields = TgFieldFonds
                Dim nodField As UltraTreeNode = Me.nodFonds.Nodes.Add(System.Guid.NewGuid.ToString(), rField.ColumnName.Trim())
                nodField.Tag = TgFields

                Me.translateField(rField.ColumnName.Trim(), rField.DataTable.Trim(), rField.FieldNameUI.Trim())
            Next

            Dim TgFieldContract As New cTgFields()
            Me.nodContract = Me.treeFields.Nodes.Add(System.Guid.NewGuid.ToString(), "Contract")
            nodContract.Tag = TgFieldContract
            For Each rField As dsManage.FieldsRow In arrFieldsContracts
                Dim TgFields As New cTgFields()
                TgFields.rField = rField
                TgFields.ParentTgFields = TgFieldContract
                Dim nodField As UltraTreeNode = nodContract.Nodes.Add(System.Guid.NewGuid.ToString(), rField.FieldNameUI.Trim())
                nodField.Tag = TgFields

                Me.translateField(rField.ColumnName.Trim(), rField.DataTable.Trim(), rField.FieldNameUI.Trim())
            Next

            Dim TgFieldSysFields As New cTgFields()
            Me.nodSysFields = Me.treeFields.Nodes.Add(System.Guid.NewGuid.ToString(), "Sys-Fields")
            nodSysFields.Tag = TgFieldSysFields
            For Each rField As dsManage.FieldsRow In arrFieldsSysFields
                Dim TgFields As New cTgFields()
                TgFields.rField = rField
                TgFields.ParentTgFields = TgFieldSysFields
                Dim nodField As UltraTreeNode = nodSysFields.Nodes.Add(System.Guid.NewGuid.ToString(), rField.FieldNameUI.Trim())
                nodField.Tag = TgFields

                Me.translateField(rField.ColumnName.Trim(), rField.DataTable.Trim(), rField.FieldNameUI.Trim())
            Next

        Catch ex As Exception
            Throw New Exception("contFelder2.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function translateField(ByRef ColumnName As String, ByRef TableName As String, ByRef FieldNameUI As String) As String
        Try
            If Not contFelder2.delDoRes Is Nothing Then
                Dim sTranslated As String = ""
                sTranslated = contFelder2.delDoRes(TableName.Trim() + "" + ColumnName.Trim())
                If sTranslated.Trim() <> "" Then
                    Return sTranslated.Trim()
                Else
                    Return ColumnName.Trim()
                End If
            Else
                If FieldNameUI.Trim().ToLower().Equals(("[AutoTranslate]").Trim().ToLower()) Then
                    Return ColumnName.Trim()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contFelder2.translateField: " + ex.ToString())
        End Try
    End Function


    Private Sub setUI(ByRef Type As String)
        Try
            If Type.ToString().Trim().ToLower().Equals(ePrintGroup.obj.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodObj.ExpandAll()

            ElseIf Type.ToString().Trim().ToLower().Equals(ePrintGroup.objCP.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodObj.ExpandAll()

            ElseIf Type.ToString().Trim().ToLower().Equals(ePrintGroup.sv.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodObj.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.ag.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodObj.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.vn.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.vp.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.bzberl.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.bzbabl.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.termfix.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = True
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.fo.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = False
                Me.nodContract.Visible = True
                Me.nodFonds.Visible = True
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()
                Me.nodFonds.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.cont.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = False
                Me.nodContract.Visible = True
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = False
                Me.nodContract.ExpandAll()

            ElseIf Type.Trim().ToLower().Equals(ePrintGroup.sys.ToString().Trim().ToLower()) Then
                Me.nodObj.Visible = False
                Me.nodContract.Visible = False
                Me.nodFonds.Visible = False
                Me.nodSysFields.Visible = True
                Me.nodSysFields.ExpandAll()

            Else
                Throw New Exception("contFelder2.setUI: Me.optSetTypeGroup.Value.ToString() '" + Me.optSetTypeGroup.Value.ToString() + "' not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("contFelder2.setUI: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedGroup(ByRef withMsgBox As Boolean) As String
        Try
            If Not Me.optSetTypeGroup.Value Is Nothing Then
                Dim sSelGroup As String = Me.optSetTypeGroup.Value.ToString().Trim()
                Return sSelGroup
            Else
                If withMsgBox Then
                    MessageBox.Show("No group selected!")
                End If
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("contFelder2.getSelectedGroup: " + ex.ToString())
        End Try
    End Function
    Public Function getSelectedField(ByRef withMsgBox As Boolean) As cTgFields
        Try
            If Not Me.treeFields.ActiveNode Is Nothing Then
                Dim cTgFields As cTgFields = Me.treeFields.ActiveNode.Tag
                Return cTgFields
            Else
                If withMsgBox Then
                    MessageBox.Show("No field selected!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contFelder2.getSelectedField: " + ex.ToString())
        End Try
    End Function

    Public Sub insertField(ByRef Group As String, ByRef tgField As cTgFields)
        Try
            If Me.modalWindow.lockEingbe Then Exit Sub

            If Me.treeFields.Focused Then
                If Group.Trim() = "" Then
                    Throw New Exception("contFelder2.insertField: Group.Trim()='' not allowed!")
                End If
                If tgField.rField.FieldKey.Trim() = "" Then
                    Throw New Exception("contFelder2.insertField: tgField.rField.FieldKey.Trim()='' not allowed!")
                End If

                Dim sKeyTmp As String = " [" + Group + "_" + tgField.rField.FieldKey.Trim() + "] "
                Me.modalWindow.textControl1.Selection.Text = sKeyTmp





                'Me.modalWindow.ActiveControl = Me.modalWindow.textControl1
                'System.Windows.Forms.Application.DoEvents()
                'Me.modalWindow.textControl1.Focus()
                'System.Windows.Forms.Application.DoEvents()

                'Me.treeFields.ActiveNode = Nothing
                'If Not Me.modalWindow.callEditorKeyPress Is Nothing Then Me.modalWindow.callEditorKeyPress.Invoke(True)

                'Me.modalWindow.textControl1.InsertionMode = TXTextControl.InsertionMode.Insert
                'Me.modalWindow.textControl1.Selection.Start = 2

                'Me.modalWindow.textControl1.Selection.Text = sKeyTmp.Trim()
                'Me.modalWindow.textControl1.Text.Insert(Me.modalWindow.textControl1.Selection.Start, sKeyTmp.Trim())





                'Dim FieldNew As TXTextControl.TextField
                'If Not Me.modalWindow.m_ActiveHeaderFooter Is Nothing And Me.modalWindow.mouseIsInFieldseditor Then
                '    If Me.modalWindow.m_ActiveHeaderFooter.Selection Is Nothing Then
                '        generic.showMessageBox(generic.getRes("NoTextpositionSelected"), Windows.Forms.MessageBoxButtons.OK, generic.getRes("InsertField"))
                '        Exit Sub
                '    End If
                '    Me.modalWindow.m_ActiveHeaderFooter.Selection.Text = " "
                'Else
                '    If Me.modalWindow.textControl1.Selection Is Nothing Then
                '        generic.showMessageBox(generic.getRes("NoTextpositionSelected"), Windows.Forms.MessageBoxButtons.OK,
                '                                        generic.getRes("InsertField"))
                '        Exit Sub
                '    End If
                '    Me.modalWindow.textControl1.Selection.Text = " "
                'End If

                'If e.Item.Key.Trim() = "[System_AutoNumber]" Then
                '    FieldNew = Me.modalWindow.cTxtEditor1.insertField(modalWindow, Me.modalWindow.textControl1, e.Item.Key.ToString, e.Item.Key.ToString, True)
                'Else
                '    FieldNew = Me.modalWindow.cTxtEditor1.insertField(modalWindow, Me.modalWindow.textControl1, e.Item.Key.ToString, e.Item.Key.ToString, False)
                'End If
                'If Not FieldNew Is Nothing Then
                '    If Not Me.modalWindow.m_ActiveHeaderFooter Is Nothing And Me.modalWindow.mouseIsInFieldseditor Then
                '        Me.modalWindow.m_ActiveHeaderFooter.Selection.Text = " "
                '    Else
                '        Me.modalWindow.textControl1.Selection.Text = " "
                '    End If
                '    Me.modalWindow.textControl1.Focus()

                '    uExpFelder.ActiveItem = Nothing
                '    If Not Me.modalWindow.callEditorKeyPress Is Nothing Then Me.modalWindow.callEditorKeyPress.Invoke(True)
                '    e.Cancel = True
                'End If
            End If

        Catch ex As Exception
            Throw New Exception("contFelder2.insertFieldIntoDocument: " + ex.ToString())
        End Try
    End Sub


    Private Sub treeFields_Click(sender As Object, e As EventArgs) Handles treeFields.Click
        Try

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub treeFields_DoubleClick(sender As Object, e As EventArgs) Handles treeFields.DoubleClick
        Try
            If Me.modalWindow.lockEingbe Then
                Exit Sub
            End If

            If Me.treeFields.Focused Then
                Dim sGroup As String = Me.getSelectedGroup(False)
                Dim TgSelFields As cTgFields = Me.getSelectedField(False)
                If sGroup.Trim() <> "" And (Not TgSelFields Is Nothing) Then
                    Me.insertField(sGroup.Trim(), TgSelFields)
                Else
                    Dim bNotFieldSelected As Boolean = True
                End If
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub optSetTypeGroup_ValueChanged(sender As Object, e As EventArgs) Handles optSetTypeGroup.ValueChanged
        Try
            If Me.IsFirstVisible Then
                Me.setUI(Me.optSetTypeGroup.Value.ToString().Trim())
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub contFelder2_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
                Me.IsFirstVisible = True
                If Not Me.IsInitialized Then
                    Me.setUI(ePrintGroup.obj.ToString().Trim().ToLower())
                End If
                Me.IsInitialized = True
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
