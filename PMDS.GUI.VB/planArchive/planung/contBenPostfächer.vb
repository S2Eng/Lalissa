Imports System.Windows.Forms


Public Class contBenPostfächer

    Public fileBenutzerauswahl As String = PMDS.Global.ENV.path_data + "\PMDS.planung.postfächer"
    Public gen As New GeneralArchiv





    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Try
            Select Case e.Tool.Key
                Case "buttLadenBenutzer"
                    Me.benutzerauswahlLaden()

                Case "buttSpeichernBenutzer"
                    Me.benutzerauswahlSpeichern()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub contBenPostfächer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub benutzerauswahlSpeichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim cl As New GeneralArchiv()
            Dim datei As String = cl.SelectSaveFileDialog(False, "Postfach-Dateien (*.postfächer)|*.postfächer", "")
            If Not gen.IsNull(datei) Then
                Me.writeGewählteBenutzer()
                If System.IO.File.Exists(datei) Then
                    System.IO.File.Delete(datei)
                End If
                If System.IO.File.Exists(Me.fileBenutzerauswahl) Then
                    System.IO.File.Copy(Me.fileBenutzerauswahl, datei)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("benutzerauswahlSpeichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub benutzerauswahlLaden()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim cl As New GeneralArchiv()
            Dim datei As String = cl.SelectFile(False, "Postfach-Dateien (*.postfächer)|*.postfächer")
            If Not gen.IsNull(datei) Then
                If System.IO.File.Exists(Me.fileBenutzerauswahl) Then
                    System.IO.File.Delete(Me.fileBenutzerauswahl)
                End If
                If System.IO.File.Exists(datei) Then
                    System.IO.File.Copy(datei, Me.fileBenutzerauswahl)
                End If
                Me.loadGewählteBenutzer()
            End If

        Catch ex As Exception
            Throw New Exception("benutzerauswahlLaden: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub loadGewählteBenutzer()
        Try
            Dim arrBenutzer As New ArrayList

            If Me.fileBenutzerauswahl = "" Then Exit Sub
            If Not System.IO.File.Exists(Me.fileBenutzerauswahl) Then
                Exit Sub
            End If

            For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                nNode.CheckedState = CheckState.Unchecked
            Next

            Dim str As New System.IO.StreamReader(Me.fileBenutzerauswahl)
            Do While str.Peek() >= 0
                arrBenutzer.Add(str.ReadLine)
            Loop
            str.Close()

            For Each strBen As String In arrBenutzer
                For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                    If nNode.Key.ToString = strBen.ToString Then
                        nNode.CheckedState = CheckState.Checked
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("loadGewählteBenutzer: " + ex.ToString())
        End Try
    End Sub
    Public Sub writeGewählteBenutzer()
        Try
            If System.IO.File.Exists(Me.fileBenutzerauswahl) Then
                System.IO.File.Delete(Me.fileBenutzerauswahl)
            End If
            Dim str As System.IO.StreamWriter = System.IO.File.AppendText(Me.fileBenutzerauswahl)
            For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                If nNode.CheckedState = CheckState.Checked Then
                    str.WriteLine(nNode.Key)
                End If
            Next
            str.Close()

        Catch ex As Exception
            Throw New Exception("writeGewählteBenutzer: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function loadBenutzerauswahl() As Boolean
        Try
            Me.UTreeBenutzer.Nodes.Clear()
            Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
            Dim dt As New DataTable
            dt = ben.AllEntries
            For Each r As DataRow In dt.Rows
                Dim u As New PMDS.BusinessLogic.Benutzer(r("ID"))
                Dim node As Infragistics.Win.UltraWinTree.UltraTreeNode = Me.UTreeBenutzer.Nodes.Add(u.BenutzerName, u.BenutzerName)
                node.Override.NodeAppearance.Image = Me.ImageList1.Images(0)
                node.CheckedState = CheckState.Unchecked
            Next

        Catch ex As Exception
            Throw New Exception("loadBenutzerauswahl: " + ex.ToString())
        Finally
        End Try
    End Function


    Private Sub AlleBenutzerToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleBenutzerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                nNode.CheckedState = CheckState.Checked
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub KeineBenutzerToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineBenutzerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                nNode.CheckedState = CheckState.Unchecked
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MichAuswählenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MichAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each nNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.UTreeBenutzer.Nodes
                If nNode.Key.ToString = gen.actUser Then
                    nNode.CheckedState = CheckState.Checked
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
