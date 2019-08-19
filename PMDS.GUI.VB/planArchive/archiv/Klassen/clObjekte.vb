

Public Class clObjekte




    Public Function Info_ReadObjekteSuche(ByVal IDDokumenteintrag As System.Guid) As String
        Dim gen As New GeneralArchiv
        Try
            Dim ui As New UI
            Dim textTyp As String = ""
            Dim comp As New compSql
            Dim data As New dsObjects
            data = comp.LesenObjekte_IDDokumenteintrag(IDDokumenteintrag)
            For Each r As dsObjects.tblObjektRow In data.tblObjekt
                If Not r.IsID_guidNull Then
                    textTyp += "        Objekt guid: " + r.ID_guid.ToString + vbNewLine
                ElseIf Not r.IsID_intNull Then
                    textTyp += "        Objekt Int: " + r.ID_int.ToString + vbNewLine
                ElseIf Not r.IsID_strNull Then
                    textTyp += "        Objekt Text: " + r.ID_str + vbNewLine
                Else
                    Throw New Exception("clObjekte.Info_ReadObjekteSuche: kein Wert wurde für den Objecteintrag angegeben!")
                End If
            Next

            If Not gen.IsNull(textTyp) Then
                textTyp = "Beziehungen:" + vbNewLine + textTyp
            End If
            Return textTyp

        Catch ex As Exception
            Throw New Exception("Info_ReadObjekteSuche: " + ex.ToString())
        End Try
    End Function

    Public Sub ObjekteAblegen(ByRef objects As ArrayList, ByRef tree As Infragistics.Win.UltraWinTree.UltraTree)
        Dim gen As New GeneralArchiv
        Try
            Dim ui As New UI
            Dim comp As New compSql
            Dim key As Integer = 1
            Dim firstItem As Infragistics.Win.UltraWinTree.UltraTreeNode

            If Not tree.Nodes.Exists(key) Then
                firstItem = tree.Nodes.Add(key, "Beziehungen:")
            End If

            'For Each aktOb As Object In objects
            For act As Integer = 0 To objects.Count - 1
                Dim aktObj As New clObject
                aktObj = objects.Item(act)

                Dim typ As New compSql.eTypObj
                If aktObj.id.GetType.ToString = "System.String" Then
                    Try
                        Dim ID As New System.Guid(objects.Item(act).ToString)
                        typ = compSql.eTypObj.guid
                        If Not gen.IsNull(aktObj.id) Then
                            Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                            Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                            Item.Tag = aktObj.id.ToString

                        End If
                    Catch ex As Exception
                        Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                        Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                        Item.Tag = aktObj.id
                    End Try

                ElseIf aktObj.id.GetType.ToString = "System.Int32" Then
                    Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                    Item = firstItem.Nodes.Add(System.Guid.NewGuid.ToString, aktObj.bezeichnung)
                    Item.Tag = aktObj.id

                Else
                    Throw New Exception("clObjekte.Info_ReadObjekteAblegen: kein Wert wurde für den Objecteintrag angegeben!")
                End If

            Next

        Catch ex As Exception
            Throw New Exception("ObjekteAblegen: " + ex.ToString())
        End Try
    End Sub

End Class
