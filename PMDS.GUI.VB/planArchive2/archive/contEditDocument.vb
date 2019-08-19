

Public Class contEditDocument

    Public _lstDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)

    Public gen As New General()
    Public abort As Boolean = True

    Public doUI1 As New doUI()
    Public mainWindow As frmEditDocu = Nothing








    Private Sub contEditDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.mainWindow.AcceptButton = Me.btnSave
            Me.mainWindow.CancelButton = Me.btnAbort

            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.clearUI()

        Catch ex As Exception
            Throw New Exception("contEditDocument.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearErrProvider()
        Me.ErrorProvider1.SetError(Me.txtBezeichnung, "")
    End Sub

    Public Sub clearUI()
        Try
            Me.txtBezeichnung.Text = ""

        Catch ex As Exception
            Throw New Exception("contEditDocument.clearUI: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData(ByRef lstDocus As System.Collections.Generic.List(Of dsDokuSearch.archDokuRow))
        Try
            Me._lstDocus = lstDocus
            Me.clearUI()

            If Me._lstDocus.Count = 1 Then
                Dim dbArchivSave As New dbArchiv()
                Dim compDokuSave As New compDoku()

                Dim rDocuSearch As dsDokuSearch.archDokuRow = Me._lstDocus(0)
                Me.txtBezeichnung.Text = rDocuSearch.Bezeichnung.Trim()
            End If

        Catch ex As Exception
            Throw New Exception("contEditDocument.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            Me.clearErrProvider()

            If Me.txtBezeichnung.Text.Trim() = "" Then
                Dim str As String = doUI.getRes("DescriptionInputRequired")
                Me.ErrorProvider1.SetError(Me.txtBezeichnung, str)
                doUI.doMessageBox2("DescriptionInputRequired", "", "!")
                Me.txtBezeichnung.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contEditDocument.validateData: " + ex.ToString())
        End Try
    End Function
    Public Function saveData() As Boolean
        Try
            If Not Me.validateData() Then Return False
            'Dim rDocu As dbArchiv.archDokuRow = Me.dbArchivSave.archDoku.Rows(0)

            For Each rDocuSearch As dsDokuSearch.archDokuRow In Me._lstDocus
                Dim compDokuSave As New compDoku()
                compDokuSave.UpdateDoku(rDocuSearch.IDDoku, Me.txtBezeichnung.Text.Trim())
                rDocuSearch.Bezeichnung = Me.txtBezeichnung.Text.Trim()
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("contEditDocument.saveData: " + ex.ToString())
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.saveData() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
