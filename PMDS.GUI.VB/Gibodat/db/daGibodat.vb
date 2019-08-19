Public Class daGibodat

    Public sel_daKlientenstammdaten As String
    Public sel_daKontaktpersonenstammdaten As String
    Public sel_daSync As String


    Public Enum eTypSel
        all = 0
        byIDPatient = 1
    End Enum


    Public Sub initControl()

        Me.sel_daKlientenstammdaten = Me.daPatienten.SelectCommand.CommandText
        Me.sel_daKontaktpersonenstammdaten = Me.daAngehoerige.SelectCommand.CommandText
        Me.sel_daSync = Me.daAngehoerige.SelectCommand.CommandText

    End Sub


    Public Sub getKlientenstammdaten(ByRef ds As dsGibodat, ByVal typ As eTypSel)

        Me.daPatienten.SelectCommand.CommandText = Me.sel_daKlientenstammdaten
        dbBase.setDBConnection_dataAdapterGiboDat(Me.daPatienten)
        If typ = eTypSel.all Then
            'Me.daKlientenstammdaten.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        End If

        Me.daPatienten.Fill(ds.vPatienten_PMDS)

    End Sub


    Public Sub getKontaktpersonenstammdaten(ByRef ds As dsGibodat, ByVal typ As eTypSel)

        Me.daAngehoerige.SelectCommand.CommandText = Me.sel_daKontaktpersonenstammdaten
        dbBase.setDBConnection_dataAdapterGiboDat(Me.daAngehoerige)
        If typ = eTypSel.all Then
            'Me.daKontaktpersonenstammdaten.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        End If

        Me.daAngehoerige.Fill(ds.vAngehörige_PMDS)

    End Sub




    Public Function getSync(ByRef ds As dsGibodat, ByVal typ As eTypSel) As dsGibodat.tSync_PMDSRow

        dbBase.setDBConnection_dataAdapterGiboDat(Me.daSyncPMDS)

        ds.tSync_PMDS.Rows.Clear()
        Dim rSync_PMDS As dsGibodat.tSync_PMDSRow

        Me.daSyncPMDS.SelectCommand.CommandText = Me.sel_daSync

        Me.daSyncPMDS.SelectCommand.CommandText = "SELECT TOP 0 * FROM tSync_PMDS"
        Me.daSyncPMDS.Fill(ds.tSync_PMDS)

        'ds ist sicher leer
        rSync_PMDS = addNewSync_PMDS(ds)
        Return rSync_PMDS

    End Function


    Public Function addNewSync_PMDS(ByVal ds As dsGibodat) As dsGibodat.tSync_PMDSRow

        Dim rNew As dsGibodat.tSync_PMDSRow = ds.tSync_PMDS.NewRow
        dbBase.initRow(rNew)

        rNew.LastUpdate = Now()

        ds.tSync_PMDS.Rows.Add(rNew)
        Return rNew

    End Function

End Class
