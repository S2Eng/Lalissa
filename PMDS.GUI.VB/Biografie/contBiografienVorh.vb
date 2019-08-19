Imports Infragistics.Win.UltraWinExplorerBar




Public Class ucBiografienVorh


    Public modalWindow As ucBiografie
    Private dbBiografien As New sqlBiografien
    Private gen As New GeneralArchiv()



    Private Sub contListBiografien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadBiografien(ByVal laden As Boolean)

        Me.expBarBigrafien.Groups(0).Items.Clear()
        dbBiografien.DataTable.Rows.Clear()
        dbBiografien.loadAlleVorhadenenBiografien(PMDS.Global.ENV.CurrentIDPatient)

        For Each r As DataRow In Me.dbBiografien.DataTable.Rows
            Dim itm As UltraExplorerBarItem = Me.expBarBigrafien.Groups(0).Items.Add(r("ID").ToString, Format(r("Datumerstellt"), "dd.MM.yyyy HH:mm:ss").ToString)
            itm.Settings.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32)
            itm.Settings.AppearancesLarge.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32)
            itm.Tag = r("ID").ToString
        Next

        Me.modalWindow.uDropDownButtVorhBiografien.Text = "Vorhandene Biografien (" + Me.dbBiografien.DataTable.Rows.Count.ToString + ")"

        If (laden) Then
            If dbBiografien.DataTable.Rows.Count > 0 Then
                Me.modalWindow.loadFormular(gen.StrToGuid(dbBiografien.DataTable.Rows(0).Item("ID").ToString), False)

            End If
        End If


        'Me.modalWindow.btnPlusMinusVorhandeneBiographienVisible = Me.dbBiografien.DataTable.Rows.Count
        Me.modalWindow.RefreshbtnPlusMinusVisibity(dbBiografien.DataTable.Rows.Count, True)

       

    End Sub

    Private Sub expBarBigrafien_ActiveItemChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles expBarBigrafien.ActiveItemChanged
        If expBarBigrafien.Focused Then
            If Not e.Item Is Nothing Then
                Me.modalWindow.loadFormular(gen.StrToGuid(e.Item.Key.ToString), True)
                Me.modalWindow.RefreshbtnPlusMinusVisibity(dbBiografien.DataTable.Rows.Count, True)
                'Else
                '    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Biografie ausgewählt!", MsgBoxStyle.Information, "Biografie öffnen")
            End If
        End If
    End Sub

    Private Sub expBarBigrafien_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles expBarBigrafien.ItemClick

    End Sub
    
End Class
