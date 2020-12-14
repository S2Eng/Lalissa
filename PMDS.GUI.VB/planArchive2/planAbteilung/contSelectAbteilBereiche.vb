Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars


Public Class contSelectAbteilBereiche

    Public abort As Boolean = True

    Public _dropDownButton As UltraDropDownButton = Nothing
    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing

    Public IsInitialized As Boolean = False
    Public gen As New General()
    Public UIGlobal1 As New PMDS.Global.UIGlobal()
    Public b As New PMDS.db.PMDSBusiness()

    Public MainMessage As frmNachrichtBereich = Nothing
    Public MainPlanBereicheSearch As contPlanung2Bereich = Nothing

    Public funct1 As New QS2.core.vb.funct()

    Public _IDRes As String = "Abteilung/Bereiche"











    Private Sub contSelectSelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Public Sub initControl(dropDownButton As UltraDropDownButton)
            Try
                If Not Me.IsInitialized Then
                    Me._dropDownButton = dropDownButton

                    Me.btnSelectSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
                    Me.btnSelectSave.Text = doUI.getRes("OK")

                    Me.loadData()
                    Me.IsInitialized = True
                End If

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.initControl: " + ex.ToString())
            End Try
        End Sub

        Public Sub loadData()
            Try
                Me.txtSearch.Text = ""

                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim tAbt = (From o In db.Abteilung
                                Where o.IDKlinik = PMDS.Global.ENV.IDKlinik Order By o.Bezeichnung Ascending
                                Select o.ID, o.Bezeichnung).ToList()
                    For Each rAbt In tAbt
                        If rAbt.ID <> System.Guid.Empty Then
                            Dim itmAbt As Infragistics.Win.UltraWinTree.UltraTreeNode = Me.treeAbtBereiche.Nodes.Add(rAbt.ID.ToString(), rAbt.Bezeichnung.Trim())
                            itmAbt.CheckedState = Windows.Forms.CheckState.Unchecked

                            Dim tBereiche = (From o In db.Bereich
                                             Where o.IDAbteilung = rAbt.ID Order By o.Bezeichnung Ascending
                                             Select o.ID, o.Bezeichnung).ToList()
                            For Each rBereich In tBereiche
                                Dim itmBereicht As Infragistics.Win.UltraWinTree.UltraTreeNode = itmAbt.Nodes.Add(rBereich.ID.ToString(), rBereich.Bezeichnung.Trim())
                                itmBereicht.CheckedState = Windows.Forms.CheckState.Unchecked
                            Next
                        End If
                    Next
                End Using

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.loadData: " + ex.ToString())
            End Try
        End Sub

        Public Function getSelectedData2(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of String), getAbt As Boolean) As String
            Try
                Dim sAbtBereich As String = ""
                For Each nodAbt In treeAbtBereiche.Nodes
                    If nodAbt.CheckedState = Windows.Forms.CheckState.Checked Then
                        If getAbt Then
                            lstSelectedRowsReturn.Add(nodAbt.Text.Trim())
                            sAbtBereich += nodAbt.Text.Trim()
                        End If

                        For Each nodBereich In nodAbt.Nodes
                            If nodBereich.CheckedState = Windows.Forms.CheckState.Checked Then
                                If Not getAbt Then
                                    lstSelectedRowsReturn.Add(nodBereich.Text.Trim())
                                    sAbtBereich += nodBereich.Text.Trim()
                                End If
                            End If

                        Next
                    End If
                Next

                Return sAbtBereich

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.getSelectedData: " + ex.ToString())
            End Try
        End Function

        Public Sub setSelectionOnOff(bOn As Windows.Forms.CheckState)
            Try
                For Each nodAbt In treeAbtBereiche.Nodes
                    nodAbt.CheckedState = bOn
                    For Each nodBereich In nodAbt.Nodes
                        nodBereich.CheckedState = bOn
                    Next
                Next

                Me.setLabelCount2()

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.setSelectionOnOff: " + ex.ToString())
            End Try
        End Sub

    Public Sub getSelectedIDs(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of suchePlan.cAbtBereich), getAbt As Boolean)
        Try
            For Each nodAbt In treeAbtBereiche.Nodes
                If getAbt Then
                    If nodAbt.CheckedState = Windows.Forms.CheckState.Checked Then
                        Dim AbtBereichTree As New suchePlan.cAbtBereich()
                        AbtBereichTree.ID = New System.Guid(nodAbt.Key)
                        AbtBereichTree.isAbt = True
                        lstSelectedRowsReturn.Add(AbtBereichTree)
                    End If
                End If
                If Not getAbt Then
                    For Each nodBereich In nodAbt.Nodes
                        If nodBereich.CheckedState = Windows.Forms.CheckState.Checked Then
                            Dim AbtBereichTree As New suchePlan.cAbtBereich()
                            AbtBereichTree.IDParent = New System.Guid(nodBereich.Parent.Key)
                            AbtBereichTree.ID = New System.Guid(nodBereich.Key)
                            AbtBereichTree.isAbt = False
                            lstSelectedRowsReturn.Add(AbtBereichTree)
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.getSelectedIDs: " + ex.ToString())
        End Try
    End Sub

    Public Sub setLabelCount2()
            Try
                Dim AbtBereicheSelected As String = ""
                Dim iCountSelected As Integer = 0
                For Each nod In Me.treeAbtBereiche.Nodes
                    If nod.CheckedState = Windows.Forms.CheckState.Checked Then
                        iCountSelected += 1
                    End If
                    For Each nod2 In nod.Nodes
                        If nod2.CheckedState = Windows.Forms.CheckState.Checked Then
                            iCountSelected += 1
                        End If
                    Next
                Next

                Dim sTxtReturn As String = Me._IDRes + " (" + iCountSelected.ToString() + ")"
                Me._dropDownButton.Text = sTxtReturn.Trim()

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.setLabelCount: " + ex.ToString())
            End Try
        End Sub

        Public Function setAbtBereich(ByRef ID As Guid, setAbt As Boolean) As String
            Try
                Dim sAbtBereich As String = ""
                For Each nodAbt In treeAbtBereiche.Nodes
                    If setAbt Then
                        If nodAbt.Key.Equals(ID.ToString()) Then
                            nodAbt.CheckedState = Windows.Forms.CheckState.Checked
                        End If
                    End If
                    If Not setAbt Then
                        For Each nodBereich In nodAbt.Nodes
                            If nodBereich.Key.Equals(ID.ToString()) Then
                                nodBereich.CheckedState = Windows.Forms.CheckState.Checked
                            End If
                        Next
                    End If
                Next

                Return sAbtBereich

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.getSelectedData: " + ex.ToString())
            End Try
        End Function

        Public Sub clearFilterSearch()
            Try
                Me.txtSearch.Text = ""

            Catch ex As Exception
                Throw New Exception("contSelectAbteilBereiche.clearFilterSearch: " + ex.ToString())
            End Try
        End Sub

        Private Sub btnSelectSave_Click(sender As Object, e As EventArgs) Handles btnSelectSave.Click
            Try
                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                Me.abort = False
                If Not Me.popupContMainSearch Is Nothing Then
                    Me.popupContMainSearch.Close()
                End If

            Catch ex As Exception
                Me.gen.GetEcxeptionGeneral(ex)
            Finally
                Me.Cursor = Windows.Forms.Cursors.Default
            End Try
        End Sub

        Private Sub txtSearch_ValueChanged(sender As Object, e As EventArgs) Handles txtSearch.ValueChanged
            Try
                Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Catch ex As Exception
                Me.gen.GetEcxeptionGeneral(ex)
            Finally
                Me.Cursor = Windows.Forms.Cursors.Default
            End Try
        End Sub

        Private Sub treeAbtBereiche_CellValueChanged(sender As Object, e As UltraWinTree.CellValueChangedEventArgs) Handles treeAbtBereiche.CellValueChanged
            Try


            Catch ex As Exception
                Me.gen.GetEcxeptionGeneral(ex)
            End Try
        End Sub

    End Class

