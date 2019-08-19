Imports PMDS.Global
Imports System.Windows.Forms



Public Class frmOffeneTermine

    Private tblAufgaben As New sqlAufgaben
    Private gen As New GeneralArchiv

    Public isLoaded As Boolean = False





    Private Sub frmOffeneTermine_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Visible = False
            e.Cancel = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub



    Private Sub frmOffeneTermine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_OffeneMeldungen, 32, 32)
            Me.UltraPictureBox1.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_OffeneMeldungen, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub loadForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.CancelButton = Me.UButtonSchließen
            Me.initListe()
            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("loadForm: " + ex.ToString())
        End Try
    End Sub
    Private Sub UButtonSchließen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchließen.Click
        Try
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub loadListe(ByVal neuÖffnen As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            If neuÖffnen Then Me.txtSuche.Text = ""

            Me.tblAufgaben.tAufgaben.Rows.Clear()
            Dim ben As New PMDS.BusinessLogic.Benutzer(ENV.USERID)
            Me.tblAufgaben.listeOffeneTermine(New PMDS.BusinessLogic.Benutzer(ENV.USERID).BenutzerName, Me.txtSuche.Text, ben.BenutzerGruppe)

            'panelUser.Text		= ENV.String("GUI.STATUS_USER", new Benutzer(ENV.USERID).FullName);
            'panelAbt.Text		= ENV.String("GUI.STATUS_ABT", GuiUtil.Abteilung());
            Me.GridTasks.Refresh()

            Me.lblListTermine.Text = "Liste Ihrer offenen Termine (" + Me.tblAufgaben.tAufgaben.Rows.Count.ToString + ")"

            If Me.tblAufgaben.tAufgaben.Rows.Count > 0 Then
                Me.GridTasks.ActiveRow = Me.GridTasks.Rows(0)
                Me.GridTasks.Rows(0).Selected = True
            End If

        Catch ex As Exception
            Throw New Exception("loadListe: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub initListe()
        Try
            Me.tblAufgaben.listeOffeneTermine(System.Guid.NewGuid.ToString, "", New PMDS.Data.Global.dsBenutzerGruppe.BenutzerGruppeDataTable)
            Me.GridTasks.DataSource = Me.tblAufgaben.tAufgaben
            Me.GridTasks.DataBind()
            Me.initGrid()

        Catch ex As Exception
            Throw New Exception("initListe: " + ex.ToString())
        End Try
    End Sub
    Public Sub initGrid()
        Try
            Me.GridTasks.DisplayLayout.Bands(0).Columns("Betreff").Width = 290
            Me.GridTasks.DisplayLayout.Bands(0).Columns("Betreff").Header.Caption = "Betreff"
            Me.GridTasks.DisplayLayout.Bands(0).Columns("Betreff").DataType.GetType("System.String")

            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltVon").Width = 130
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltVon").Header.Caption = "Von"
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltVon").DataType.GetType("System.String")

            Me.GridTasks.DisplayLayout.Bands(0).Columns("Zusatz").Width = 140
            Me.GridTasks.DisplayLayout.Bands(0).Columns("Zusatz").Header.Caption = "Klient"
            Me.GridTasks.DisplayLayout.Bands(0).Columns("Zusatz").DataType.GetType("System.String")

            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns("").Width = 80
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns("").Header.Caption = ""
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns("").DataType.GetType("System.Int32")
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns("").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns("").Format = "###,###,##0"

            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Width = 135
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Header.Caption = "Erstellt am"
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").DataType.GetType("System.Date")
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Format = "yyyy-MM-dd HH:mm"
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left


            Me.GridTasks.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            Me.GridTasks.DisplayLayout.Bands(0).Columns("ErstelltAm").Hidden = True
            Me.GridTasks.DisplayLayout.Bands(0).Columns("EndDate").Hidden = True
            Me.GridTasks.DisplayLayout.Bands(0).Columns("StartDate").Hidden = True
            Me.GridTasks.DisplayLayout.Bands(0).Columns("StartTime").Hidden = True
            Me.GridTasks.DisplayLayout.Bands(0).Columns("EndTime").Hidden = True

            'Me.UltraGrid1.DisplayLayout.Appearance.BackColor = Color.White
            'Me.UltraGrid1.DisplayLayout.Appearance.BackColor2 = Color.White
            'Me.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.True
            'Me.UltraGrid1.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
            Me.GridTasks.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

        Catch ex As Exception
            Throw New Exception("initGrid: " + ex.ToString())
        End Try
    End Sub

    Private Sub UButtonTerminÖffnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonTerminÖffnen.Click
        Try
            Me.nachrichtÖffnen()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeRowActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridTasks.BeforeRowActivate
        Try
            e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTasks.DoubleClick
        Try
            Me.nachrichtÖffnen()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridTasks.InitializeLayout
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub nachrichtÖffnen()
        Try
            If Not Me.gen.IsNull(Me.GridTasks.ActiveRow) Then
                If Not Me.GridTasks.ActiveRow.IsGroupByRow Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim cl As New cMailTermine
                    cl.nachrichtÖffnen(GridTasks.ActiveRow.Cells("ID").Value, Nothing, "", Me)
                    Me.Cursor = Cursors.Default
                End If
            Else
                MsgBox("Keinen Termin ausgewählt!", MsgBoxStyle.Information, "Termin öffnen")
            End If

        Catch ex As Exception
            Throw New Exception("nachrichtÖffnen: " + ex.ToString())
        End Try
    End Sub

    Private Sub txtSuche_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuche.Enter
        Try
            Me.txtSuche.SelectAll()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub txtSuche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSuche.KeyPress
        Try
            Select Case Asc(e.KeyChar)
                Case 13
                    Me.loadListe(False)

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub txtSuche_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuche.Leave
        Try
            Me.loadListe(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub txtSuche_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuche.ValueChanged
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraButtonAbschließen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAbschließen.Click
        Try
            If Not Me.gen.IsNull(Me.GridTasks.ActiveRow) Then
                If Not Me.GridTasks.ActiveRow.IsGroupByRow Then
                    If MsgBox("Wollen Sie den Termin wirklich abschließen?", MsgBoxStyle.YesNo, "Termin abschließen") = MsgBoxResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim compSql1 As New compSql()
                        If compSql1.aufgabeAbschließen(GridTasks.ActiveRow.Cells("ID").Value) Then
                            Me.loadListe(False)
                        End If
                        Me.Cursor = Cursors.Default
                    End If
                Else
                    MsgBox("Keinen Termin ausgewählt!", MsgBoxStyle.Information, "Termin abschließen")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraButtonAktualisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAktualisieren.Click
        Try
            Me.loadListe(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class