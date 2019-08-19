Imports System.IO
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms



Public Class contZwischenablage

    Private gen As New GeneralArchiv
    Dim genMain As New GeneralArchiv

    Public DateiKopieren As String = ""
    Public DateiAusschneiden As String = ""


    Public typ As New eTyp
    Public Enum eTyp
        ablegen = 0
        suche = 1
        stammdaten = 2
    End Enum

    Private Sub contZwischenablage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.loadClipboard()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Public Sub loadClipboard()
        Try

            If Directory.Exists(PMDS.Global.ENV.path_Temp) Then

                Dim genMain As New GeneralArchiv
                genMain.GarbColl()

                Me.UTreeZwischenablage.Nodes.Clear()
                Me.checkVerzeichnis_Zwischenablage()
                Dim files() As String = System.IO.Directory.GetFiles(PMDS.Global.ENV.path_Temp)
                For Each filWithPfad As String In files
                    Dim cl As New clStringOperate
                    Dim fileName As String = cl.GetFileName(filWithPfad, False)
                    If Not gen.IsNull(fileName) Then
                        Dim node As UltraTreeNode = Me.UTreeZwischenablage.Nodes.Add(System.Guid.NewGuid.ToString, fileName)
                        node.Tag = filWithPfad
                        Dim clOp As New clStringOperate
                        Dim info As New System.IO.FileInfo(filWithPfad)
                        info.IsReadOnly = False
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception("loadClipboard: " + ex.ToString())
        End Try
    End Sub
    Private Sub UTreeZwischenablage_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles UTreeZwischenablage.AfterSelect

    End Sub
    Public Function checkVerzeichnis_Zwischenablage() As Boolean
        Try

            If Not System.IO.Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                System.IO.Directory.CreateDirectory(PMDS.Global.ENV.path_Temp)
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("checkVerzeichnis_Zwischenablage: " + ex.ToString())
        End Try
    End Function

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "Explorer"
                    Dim cl As New cArchive
                    cl.OpenZwischenablageExplorer()

                Case "DateiAusschneiden"
                    Me.dateiKopierenAusschneiden("A")

                Case "DateiKopieren"
                    Me.dateiKopierenAusschneiden("K")

                Case "DateiHinzufügen"
                    Me.DateiZurZwischenablageHinzufügen()

                Case "ZwischenablageNeuLaden"
                    Me.loadClipboard()

                Case "GesamteZwischenablageLeeren"
                    Me.clearClipboard()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub clearClipboard()
        Try
            If MsgBox("Wollen Sie wirklich die gesamte Zwischenablage leeren?", MsgBoxStyle.YesNo, "Zwischenablage leeren") = MsgBoxResult.Yes Then
                Dim mainGen As New GeneralArchiv
                mainGen.GarbColl()
                For Each n As UltraTreeNode In Me.UTreeZwischenablage.Nodes
                    If System.IO.File.Exists(n.Tag) Then
                        Try
                            System.IO.File.Delete(n.Tag)
                        Catch ex As Exception
                        End Try
                    End If
                Next
                Me.loadClipboard()
                MsgBox("Die Zwischenablage wurde geleert!", MsgBoxStyle.Information, "Zwischenablage leeren")
            End If

        Catch ex As Exception
            Throw New Exception("clearClipboard: " + ex.ToString())
        End Try
    End Sub

    Public Sub DateiZurZwischenablageHinzufügen()
        Try
            Dim selectedFile As String = ""
            Dim ui As New UIElements()
            selectedFile = ui.SelectFileDialog("All Files (*.*)|*.*|" +
                        "Microsoft Word Files (*.doc)|*.doc|" +
                        "Microsoft Excel Files (*.xls)|*.xls|" +
                        "Text Files (*.txt)|*.txt|" +
                        "pdf Files (*.pdf)|*.pdf|" +
                        "rtf Files (*.Rtf)|*.rtf", "")

            If Not gen.IsNull(selectedFile) Then
                Dim cl As New cArchive
                If cl.dateiZurZwischenablageHinzufügen(selectedFile, "") Then
                    Me.loadClipboard()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiZurZwischenablageHinzufügen: " + ex.ToString())
        End Try
    End Sub

    Private Sub dateiKopierenAusschneiden(ByVal typ As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeZwischenablage.SelectedNodes.Count > 0 Then
                Dim node As UltraTreeNode = Me.UTreeZwischenablage.SelectedNodes(0)
                Dim clOpen As New clFolder
                Me.DateiAusschneiden = ""
                Me.DateiKopieren = ""
                If typ = "A" Then
                    Me.DateiAusschneiden = node.Tag.ToString
                ElseIf typ = "K" Then
                    Me.DateiKopieren = node.Tag.ToString
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Zwischenablage")
            End If

        Catch ex As Exception
            Throw New Exception("dateiKopierenAusschneiden: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub contZwischenablage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.resizeControl(Me.Height, Me.Width)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub resizeControl(ByVal h As Double, ByVal w As Double)
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.Height = h
            Me.Width = w
            ' Me.UTreeZwischenablage.Height = Me.Height - Me.UltraExplorerBarMain.Height - 25

        Catch ex As Exception
            Throw New Exception("resizeControl: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeZwischenablage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTreeZwischenablage.DoubleClick
        Try
            Me.Cursor = Cursors.WaitCursor

            '    If Me.UTreeZwischenablage.SelectedNodes.Count > 0 Then
            '        Dim node As UltraTreeNode = Me.UTreeZwischenablage.SelectedNodes(0)
            '        Dim clOpen As New S2CoreSystem.clFolder
            '        If Not clOpen.DateiÖffnen(node.Tag.ToString, "", False) Then
            '            clOpen.DateiSpeichernUnter(node.Tag.ToString, "")
            '        End If
            '    End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub UTreeZwischenablage_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeZwischenablage.DragDrop
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(e.Data.GetData(DataFormats.Text).ToString) Then Exit Sub
            Dim cl As New cArchive
            Dim IDDok As New System.Guid
            Try
                IDDok = New System.Guid(e.Data.GetData(DataFormats.Text).ToString)
            Catch ex As Exception
                Exit Sub
            End Try
            Dim fileClipboard As String = cl.DokumentInZwischenablageSpeichern(IDDok)
            If Not gen.IsNull(fileClipboard) Then
                'UTreeZwischenablage.Nodes.Add(System.Guid.NewGuid.ToString, e.Data.GetData(DataFormats.Text).ToString)
                'If MsgBox("Soll die Datei aus dem Archivsystem gelöscht werden?", MsgBoxStyle.YesNo, "Zwischenablage") = MsgBoxResult.Yes Then

                'End If
                Me.loadClipboard()
            Else
                MsgBox("Ablegen in die Zwischenablage fehlgeschlagen!", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTreeZwischenablage_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UTreeZwischenablage.DragEnter
        Try
            Me.Cursor = Cursors.WaitCursor

            ' See if the data includes text.
            If e.Data.GetDataPresent(DataFormats.Text) Then
                ' There is text. Allow copy.
                e.Effect = DragDropEffects.Copy
            Else
                ' There is no text. Prohibit drop.
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub DateiLöschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeZwischenablage.SelectedNodes.Count > 0 Then
                If MsgBox("Soll die Datei wirklich aus der Zwischenablage gelöscht werden?", MsgBoxStyle.YesNo, "Zwischenablage") = MsgBoxResult.Yes Then
                    Dim node As UltraTreeNode = Me.UTreeZwischenablage.SelectedNodes(0)
                    Dim clOpen As New clFolder
                    Try
                        System.IO.File.Delete(node.Tag.ToString)
                        Me.loadClipboard()
                    Catch ex As System.IO.IOException
                        MsgBox("Die Datei konnte nicht gelöscht werden!" + vbNewLine +
                                "Bitte achten Sie darauf, dass die Datei in keinem anderem Programm geöffnet ist!", MsgBoxStyle.Information, "Archivsystem")
                        'MsgBox(ex.ToString, MsgBoxStyle.Information, "Archivsystem")
                    End Try
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Zwischenablage")
            End If

        Catch ex As Exception
            Throw New Exception("DateiLöschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiLöschenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiLöschen()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeZwischenablage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UTreeZwischenablage.MouseDown
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If e.Button = Windows.Forms.MouseButtons.Left Then
                If Me.UTreeZwischenablage.SelectedNodes.Count > 0 Then
                    Me.UTreeZwischenablage.DoDragDrop(Me.UTreeZwischenablage.SelectedNodes(0).Tag.ToString, DragDropEffects.Copy)
                End If

            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                Me.UTreeZwischenablage.ContextMenuStrip = Me.CMenuStripZwischenablage
                Me.CMenuStripZwischenablage.Show()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeZwischenablage_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTreeZwischenablage.MouseLeave

    End Sub
    Private Sub TeiÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeiÖffnenToolStripMenuItem.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DateiÖffnenSpeichern()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub DateiÖffnenSpeichern()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeZwischenablage.SelectedNodes.Count > 0 Then
                Dim node As UltraTreeNode = Me.UTreeZwischenablage.SelectedNodes(0)
                Dim clOpen As New clFolder
                If Not clOpen.openFile(node.Tag.ToString, False) Then
                    clOpen.DateiSpeichernUnter(node.Tag.ToString, "", False)
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Zwischenablage")
            End If

        Catch ex As Exception
            Throw New Exception("DateiÖffnenSpeichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiEinfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiEinfügenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DateiEinfügenInZwischenablage()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub DateiEinfügenInZwischenablage()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim selectedFile As String = ""
            Dim ui As New UIElements()
            selectedFile = ui.SelectFileDialog("All Files (*.*)|*.*|" +
                        "Microsoft Word Files (*.doc)|*.doc|" +
                        "Microsoft Excel Files (*.xls)|*.xls|" +
                        "Text Files (*.txt)|*.txt|" +
                        "pdf Files (*.pdf)|*.pdf|" +
                        "rtf Files (*.Rtf)|*.rtf", "")

            If Not gen.IsNull(selectedFile) Then
                If System.IO.File.Exists(selectedFile) Then
                    Dim xlOp As New clStringOperate
                    Dim fileName As String = xlOp.GetFileName(selectedFile, False)
                    Dim tmpFileName As String = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, fileName)
                    If System.IO.File.Exists(tmpFileName) Then
                        Try
                            System.IO.File.Delete(tmpFileName)
                        Catch ex As Exception
                            Throw New Exception("contZwischenablage.DateiEinfügenInZwischenablage: Datei kann nicht gelöscht werden: " + tmpFileName)
                        End Try
                    End If
                    System.IO.File.Copy(selectedFile, tmpFileName)
                    Me.loadClipboard()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiEinfügenInZwischenablage: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraExplorerBar1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            'Select Case Me.UltraExplorerBar1.Groups(0).Items(0).Key
            '    Case "Löschen"
            '        Me.DateiLöschen()

            '    Case "Hinzufügen"
            '        Me.DateiEinfügenInZwischenablage()

            '    Case "Öffnen"
            '        Me.DateiÖffnenSpeichern()

            'End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraExplorerBarMain_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Item.Key
                Case "DateiLöschen"
                    Me.DateiLöschen()

                Case "DateiEinfügenInZwischenablage"
                    Me.DateiEinfügenInZwischenablage()

                Case "DateiÖffnen"
                    Me.DateiÖffnenSpeichern()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DateiKopierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiKopierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dateiKopierenAusschneiden("K")

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DateiAusschneidenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiAusschneidenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dateiKopierenAusschneiden("A")

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


End Class
