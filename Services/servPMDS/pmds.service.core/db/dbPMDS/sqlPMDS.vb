Public Class sqlPMDS


    Public db1 As New dbGlobal()

    Public ReadOnly sqldaBenutzer As String = ""
    Public ReadOnly sqldaAbteilungen As String = ""
    Public ReadOnly sqldaBereiche As String = ""

    Public ReadOnly sqldaPatienten As String = ""
    Public ReadOnly sqldaAufenthalte As String = ""
    Public ReadOnly sqldaAufenthaltVerläufe As String = ""

    Public ReadOnly sqldaAuswahllisten As String = ""

    Public ReadOnly sqldaTasks As String = ""

    Public ReadOnly sqldaPflegeplan As String = ""
    Public ReadOnly sqldaPflegeplanH As String = ""
    Public ReadOnly sqldaPflegeeintrag As String = ""
    Public ReadOnly sqldaZusatzwert As String = ""

    Public ReadOnly sqldaQuickMeldung As String = ""

    Public ReadOnly sqldaAufenthaltPDX As String = ""
    Public ReadOnly sqldaWundeKopf As String = ""
    Public ReadOnly sqldaWundePos As String = ""
    Public ReadOnly sqldaWundePosBilder As String = ""
    Public ReadOnly sqldaWunden As String = ""


    Public Enum eTypAuswahl
        no = 0
        yes = 1

        ID = 3
        IDPflegeeintrag = 4
        IDPflegePlan = 5

        ByAbteilung = 6     'GetQuickmeldung by AbteilungsID
        ByAufenthalt = 7    'GetQuickmeldung by AufenthaltsID
        Alle = 8

    End Enum

    Public Enum eTypRMTyp
        FreierBericht = 0
        Intervention = 1
    End Enum

    Dim sqlWhereClause As String




    Public Function getBenutzer(ByVal IDUser As String, ByRef ds As dsPMDS, ByVal UseID As eTypAuswahl) As Boolean


        Me.daBenutzer.SelectCommand.CommandText = Me.sqldaBenutzer
        db1.setDBConnection_dataAdapter(Me.daBenutzer)
        Me.daBenutzer.SelectCommand.Parameters.Clear()


        If UseID = eTypAuswahl.yes Then
            Dim sWhere As String = " where ID = ? "
            Me.daBenutzer.SelectCommand.CommandText += sWhere
            Me.daBenutzer.SelectCommand.Parameters.AddWithValue("ID", IDUser)
        End If

        Me.daBenutzer.SelectCommand.CommandText += " ORDER BY Benutzer "
        Me.daBenutzer.Fill(ds.Benutzer)
        Return True

    End Function

    Public Function getAbteilungen(ByVal IDUser As String, ByRef ds As dsPMDS, ByVal UseID As eTypAuswahl) As Boolean

        Me.daAbteilungen.SelectCommand.CommandText = Me.sqldaAbteilungen
        db1.setDBConnection_dataAdapter(Me.daAbteilungen)
        Me.daAbteilungen.SelectCommand.Parameters.Clear()


        If UseID = eTypAuswahl.yes Then

            Me.daAbteilungen.SelectCommand.CommandText += " INNER JOIN BenutzerAbteilung ON Abteilung.ID = BenutzerAbteilung.IDAbteilung "
            Me.daAbteilungen.SelectCommand.CommandText += " INNER JOIN Benutzer ON BenutzerAbteilung.IDBenutzer = Benutzer.ID  "

            Dim sWhere As String = " where Benutzer.ID = ? "
            Me.daAbteilungen.SelectCommand.CommandText += sWhere
            Me.daAbteilungen.SelectCommand.Parameters.AddWithValue("ID", IDUser)
        End If

        Me.daAbteilungen.SelectCommand.CommandText += " ORDER BY Bezeichnung "
        Me.daAbteilungen.Fill(ds.Abteilung)
        Return True

    End Function

    Public Function getBereiche(ByVal IDAbteilung As String, ByRef ds As dsPMDS) As Boolean


        Me.daBereiche.SelectCommand.CommandText = Me.sqldaBereiche
        db1.setDBConnection_dataAdapter(Me.daBereiche)
        Me.daBereiche.SelectCommand.Parameters.Clear()

        Dim sWhere As String = " where IDAbteilung = ? "
        Me.daBereiche.SelectCommand.CommandText += sWhere
        Me.daBereiche.SelectCommand.Parameters.AddWithValue("ID", IDAbteilung)

        Me.daBereiche.SelectCommand.CommandText += " ORDER BY Bezeichnung "
        Me.daBereiche.Fill(ds.Bereich)
        Return True

    End Function

    Public Function getKlienten(ByVal IDAbteilung As String, IDBereich As String, ByRef ds As dsPMDS) As Boolean


        Me.daAufenthalte.SelectCommand.CommandText = "SELECT Patient.Nachname, Patient.Vorname, Patient.ID AS ID, Aufenthalt.ID AS IDAufenthalt FROM Aufenthalt "
        db1.setDBConnection_dataAdapter(Me.daAufenthalte)
        Me.daAufenthalte.SelectCommand.Parameters.Clear()

        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN AufenthaltVerlauf ON Aufenthalt.ID = AufenthaltVerlauf.IDAufenthalt "
        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN Patient ON Aufenthalt.IDPatient = Patient.ID "

        Dim sWhere As String = "WHERE (Aufenthalt.Entlassungszeitpunkt IS NULL) AND "
        sWhere += "AufenthaltVerlauf.IDAbteilung_Nach = ? AND AufenthaltVerlauf.IDBereich = ? "

        Me.daAufenthalte.SelectCommand.CommandText += sWhere

        Me.daAufenthalte.SelectCommand.Parameters.AddWithValue("IDAbteilung_Nach", IDAbteilung)
        Me.daAufenthalte.SelectCommand.Parameters.AddWithValue("IDBereich", IDBereich)

        Me.daAufenthalte.SelectCommand.CommandText += " ORDER BY Patient.Nachname, Patient.Vorname "
        Me.daAufenthalte.Fill(ds.Aufenthalt)
        Return True

    End Function

    Function getTasks(ByVal IDAufenthalt As String, _
                      IDBerufsstand As String, UseBerufsstand As eTypAuswahl, _
                      IDEintrag As String, UseIDEintrag As eTypAuswahl, t As DataTable) As Boolean

        Me.daTasks.SelectCommand.CommandText = Me.sqldaTasks

        'Wenn nicht privilegierter Berufsstand (ID beginnt mit 10000000) dann filtern
        If IDBerufsstand.Substring(0, 8) <> "10000000" And UseBerufsstand = eTypAuswahl.yes Then
            Me.daTasks.SelectCommand.CommandText += "INNER JOIN PflegePlan ON vPflegePlanPDx.IDPflegePlan = PflegePlan.ID"
        End If

        db1.setDBConnection_dataAdapter(Me.daTasks)
        Me.daTasks.SelectCommand.Parameters.Clear()

        Dim sWhere As String = " WHERE Endedatum IS NULL And eintraggruppe = 'M' AND IDAufenthalt  = ? "
        Me.daTasks.SelectCommand.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt)

        If IDBerufsstand.Substring(0, 8) <> "10000000" And UseBerufsstand = eTypAuswahl.yes Then
            sWhere += "AND LEFT(Pflegeplan.IDBerufsstand,8) <> '10000000' "
        End If

        If UseIDEintrag = eTypAuswahl.yes Then
            sWhere += "AND IDEintrag = ? "
            Me.daTasks.SelectCommand.Parameters.AddWithValue("IDEintrag", IDEintrag)
        End If

        Me.daTasks.SelectCommand.CommandText += sWhere
        Me.daTasks.Fill(t)

        Return True

    End Function

    Public Function getZusatzeinträge(ByVal IDPflegeplan As String, t As DataTable) As Boolean

        Me.daAufenthalte.SelectCommand.CommandText = "SELECT ZusatzgruppeEintrag.ID AS IDZusatzgruppeEintrag, ZusatzEintrag.Bezeichnung AS Bezeichnung, ZusatzEintrag.Typ As Typ, ZusatzEintrag.MinValue, ZusatzEintrag.MaxValue, ZusatzEintrag.ListenEintraege, ZusatzGruppeEintrag.OptionalJN FROM ZusatzGruppeEintrag "
        db1.setDBConnection_dataAdapter(Me.daAufenthalte)
        Me.daAufenthalte.SelectCommand.Parameters.Clear()

        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN ZusatzEintrag ON ZusatzGruppeEintrag.IDZusatzEintrag = ZusatzEintrag.ID "
        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN PflegePlan "
        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN Eintrag ON PflegePlan.IDEintrag = Eintrag.ID "
        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN Patient "
        Me.daAufenthalte.SelectCommand.CommandText += " INNER JOIN Aufenthalt ON Patient.ID = Aufenthalt.IDPatient ON PflegePlan.IDAufenthalt = Aufenthalt.ID ON ZusatzGruppeEintrag.IDFilter = Eintrag.ID "

        Dim sWhere As String = "WHERE (Pflegeplan.ID = ?) "

        Me.daAufenthalte.SelectCommand.CommandText += sWhere

        Me.daAufenthalte.SelectCommand.Parameters.AddWithValue("IDPflegeplan", IDPflegeplan)

        Me.daAufenthalte.Fill(t)
        Return True

    End Function

    Function getAuswahllisten(ByVal Gruppe As String, ByRef ds As dsPMDS) As Boolean

        Me.daAuswahlliste.SelectCommand.CommandText = Me.sqldaAuswahllisten
        db1.setDBConnection_dataAdapter(Me.daAuswahlliste)
        Me.daAuswahlliste.SelectCommand.Parameters.Clear()

        Dim sWhere As String = " where IDAuswahlListeGruppe = ? "
        Me.daAuswahlliste.SelectCommand.CommandText += sWhere
        Me.daAuswahlliste.SelectCommand.Parameters.AddWithValue("IDAuswahlListeGruppe", Gruppe)

        Me.daAuswahlliste.SelectCommand.CommandText += " ORDER BY Reihenfolge "
        Me.daAuswahlliste.Fill(ds.AuswahlListe)
        Return True

    End Function

    Function getQuickMeldung(ByVal ID As String, ByRef ds As dsPMDS, ByVal typSel As eTypAuswahl) As Boolean

        Me.daQuickmeldung.SelectCommand.CommandText = Me.sqldaQuickMeldung
        db1.setDBConnection_dataAdapter(Me.daQuickmeldung)
        Me.daQuickmeldung.SelectCommand.Parameters.Clear()

        Dim sWhere As String = ""
        If typSel = eTypAuswahl.Alle Then   'alle definierten Quickmeldungen  (typSel = 1)
            'sWhere = " where IDAbteilung = '00000000-0000-0000-0000-000000000000' "
        End If

        If typSel = eTypAuswahl.ByAbteilung Then   'alle definierten Quickmeldungen für eine ABteilung, unabhängig ob im Pflegeplan enthalten (6)
            sWhere = " where IDAbteilung = '00000000-0000-0000-0000-000000000000' OR IDAbteilung = ? "
            Me.daQuickmeldung.SelectCommand.CommandText += sWhere
            Me.daQuickmeldung.SelectCommand.Parameters.AddWithValue("IDAbteilung", ID)
        End If

        If typSel = eTypAuswahl.ByAufenthalt Then   'alle definierten Quickmeldungen für einen Aufenthalt, wenn im Pflegeplan enthalten (7)
            Me.daQuickmeldung.SelectCommand.CommandText = "SELECT QuickMeldung.Bezeichnung, QuickMeldung.IDEintrag, QuickMeldung.IDAbteilung, QuickMeldung.ID " & _
                "FROM QuickMeldung " & _
                "WHERE IDEintrag IN (SELECT IDEintrag FROM PflegePlan WHERE IDAufenthalt = ? AND EndeDatum IS NULL)"
            Me.daQuickmeldung.SelectCommand.Parameters.AddWithValue("IDAufenthalt", ID)
        End If

        Me.daQuickmeldung.SelectCommand.CommandText += " ORDER BY Bezeichnung "
        Me.daQuickmeldung.Fill(ds.QuickMeldung)
        Return True

    End Function

    Public Function getPflegeplan(ByVal IDPflegeplan As String, ByRef ds As dsPMDS, ByVal typSel As eTypAuswahl) As Boolean

        Me.daPflegeplan.SelectCommand.CommandText = Me.sqldaPflegeplan
        db1.setDBConnection_dataAdapter(Me.daPflegeplan)
        Me.daPflegeplan.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahl.ID Then
            Dim sWhere As String = " where ID = ? "
            Me.daPflegeplan.SelectCommand.CommandText += sWhere
            Me.daPflegeplan.SelectCommand.Parameters.AddWithValue("ID", New System.Guid(IDPflegeplan))
        End If

        'Me.daPflegeplan.SelectCommand.CommandText += " ORDER BY Bezeichnung "
        Me.daPflegeplan.Fill(ds.PflegePlan)
        Return True

    End Function

    Public Function getPflegeplanH(ByVal ID As String, ByRef ds As dsPMDS, ByVal typSel As eTypAuswahl) As Boolean

        Me.daPflegeplanH.SelectCommand.CommandText = "SELECT * FROM PflegeplanH "
        db1.setDBConnection_dataAdapter(Me.daPflegeplanH)
        Me.daPflegeplanH.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahl.ID Then
            Dim sWhere As String = " where ID = ? "
            Me.daPflegeplanH.SelectCommand.CommandText += sWhere
            Me.daPflegeplanH.SelectCommand.Parameters.AddWithValue("ID", New System.Guid(ID))
        ElseIf typSel = eTypAuswahl.IDPflegePlan Then
            Dim sWhere As String = " where IDPflegeplan = ? "
            Me.daPflegeplanH.SelectCommand.CommandText += sWhere
            Me.daPflegeplanH.SelectCommand.Parameters.AddWithValue("IDPflegeplan", New System.Guid(ID))
            Me.daPflegeplanH.SelectCommand.CommandText += " ORDER BY DatumGeaendert DESC "
        End If


        Me.daPflegeplanH.Fill(ds.PflegePlanH)
        Return True

    End Function

    Public Function getZusatzwert(ByVal IDPflegeeintrag As String, ByVal IDZusatzgruppeeintrag As String, ByRef ds As dsPMDS, ByVal typSel As eTypAuswahl) As Boolean

        Me.daZusatzwert.SelectCommand.CommandText = Me.sqldaZusatzwert
        db1.setDBConnection_dataAdapter(Me.daZusatzwert)
        Me.daZusatzwert.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahl.IDPflegeeintrag Then
            Dim sWhere As String = " where IDObjekt  = ?  and IDZusatzGruppeEintrag =  ? "
            Me.daZusatzwert.SelectCommand.CommandText += sWhere
            Me.daZusatzwert.SelectCommand.Parameters.AddWithValue("IDObjekt", New System.Guid(IDPflegeeintrag))
            Me.daZusatzwert.SelectCommand.Parameters.AddWithValue("IDZusatzGruppeEintrag", New System.Guid(IDZusatzgruppeeintrag))
        End If

        Me.daZusatzwert.Fill(ds.ZusatzWert)
        Return True

    End Function

    Public Function getPflegeeintrag(ByVal ID As String, ByRef ds As dsPMDS, ByVal typSel As eTypAuswahl) As Boolean

        Me.daPflegeeintrag.SelectCommand.CommandText = Me.sqldaPflegeeintrag
        db1.setDBConnection_dataAdapter(Me.daPflegeeintrag)
        Me.daPflegeeintrag.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahl.ID Then
            Dim sWhere As String = " where ID = ? "
            Me.daPflegeeintrag.SelectCommand.CommandText += sWhere
            Me.daPflegeeintrag.SelectCommand.Parameters.AddWithValue("ID", New System.Guid(ID))
        End If

        Me.daPflegeeintrag.Fill(ds.PflegeEintrag)
        Return True

    End Function

    Public Function getWunden(ByVal IDAufenthalt As String, ByRef t As DataTable) As Boolean

        Me.daAufenthaltPDX.SelectCommand.CommandText = "SELECT WundeKopf.ID,  PDX.Klartext, WundeKopf.Wundart, " & _
                    "AufenthaltPDx.Lokalisierung, AufenthaltPDx.LokalisierungSeite, WundeKopf.Dekuskala, WundeKopf.Dekuwert " & _
                    "FROM AufenthaltPDx INNER JOIN WundeKopf ON AufenthaltPDx.ID = WundeKopf.IDAufenthaltPDx " & _
                    "INNER JOIN PDX ON AufenthaltPDx.IDPDX = PDX.ID "

        db1.setDBConnection_dataAdapter(Me.daAufenthaltPDX)
        Me.daAufenthaltPDX.SelectCommand.Parameters.Clear()

        Dim sWhere As String = " where EndeDatum IS NULL AND IDAufenthalt = ? "
        Me.daAufenthaltPDX.SelectCommand.CommandText += sWhere
        Me.daAufenthaltPDX.SelectCommand.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt)

        Me.daAufenthaltPDX.Fill(t)
        Return True

    End Function


    Sub Rueckmeldung(IDAufenthalt As String, IDPflegeplan As String, IDBenutzer As String, IDEintrag As String, Zeitpunkt As String, IDWichtig As String, Zusatzwerte As String)
        Throw New NotImplementedException
    End Sub


End Class


