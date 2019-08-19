Imports Microsoft.VisualBasic


Public Class DoImport


    Public Function RunImport(ByRef frm As frmImportGibodat) As Boolean

        'Für jeden Datensatz
        ' wenn Datensatz nicht vorhanden ist
        '   Adresse anlegen und ID merken
        '   Patient anlegen und Adress-ID eintragen
        '   Aufenthalt anlegen und Patienten zuordnen (IDAufenthalt merken)
        '   Aufenthaltzusatz anlegen und Aufenthalt zuordnen

        ' wenn Datensatz vorhanden (IDPatient)
        '   Adresse zum Patient holen und Updaten (IDAdresse aus Patient)
        '   Patient updaten


        Dim daGibodat As New daGibodat
        Dim dsGibodat As New dsGibodat

        daGibodat.initControl()
        daGibodat.getKlientenstammdaten(dsGibodat, VB.daGibodat.eTypSel.all)
        daGibodat.getKontaktpersonenstammdaten(dsGibodat, VB.daGibodat.eTypSel.all)
        daGibodat.getSync(dsGibodat, VB.daGibodat.eTypSel.all)

        Dim daPMDS As New daPMDS
        daPMDS.initControl()

        Dim dsPMDSNew As New dsPMDS1

        Dim rAdresse As dsPMDS1.AdresseRow
        Dim rPatient As dsPMDS1.PatientRow
        Dim rAufenthalt As dsPMDS1.AufenthaltRow
        Dim rAufenthaltzusatz As dsPMDS1.AufenthaltZusatzRow
        Dim rAufenthaltVerlauf As dsPMDS1.AufenthaltVerlaufRow

        Dim rKontaktperson As dsPMDS1.KontaktpersonRow
        Dim rKontakt As dsPMDS1.KontaktRow

        Dim rSync As dsGibodat.tSync_PMDSRow


        '--------------------------------------------------------------------------------
        'Klienten
        '--------------------------------------------------------------------------------

        For Each rGiboKlient As dsGibodat.vPatienten_PMDSRow In dsGibodat.vPatienten_PMDS


            'Pflichtfelder: Vorname, Nachname, Geburtsdatum, Aufnahmedatum müssen befüllt sein
            If rGiboKlient.IsVornameNull Or rGiboKlient.IsNachnameNull Or rGiboKlient.IsGeburtsdatumNull Or rGiboKlient.IsAufnahmedatumNull Then
                'skip
                frm.txtErrors.Text += "Fehlerhafter Klient: " & rGiboKlient.Nachname & " " & rGiboKlient.Vorname & vbCrLf

            Else

                dbBase.CheckNulls(rGiboKlient)
                'IDAbteilung muss in Aufenthalt und Aufenthaltverlauf eingetragen werden! Sonst landet der datensatz in den Bewerbern.

                Dim dsPMDSCheck As New dsPMDS1

                rPatient = daPMDS.getPatient(dsPMDSCheck, daPMDS.eTypSel.byIDPatient, rGiboKlient.KlientID)
                rAdresse = daPMDS.getAdresse(dsPMDSCheck, daPMDS.eTypSel.byIDAdresse, rPatient.IDAdresse)
                rAufenthalt = daPMDS.getAufenthalt(dsPMDSCheck, daPMDS.eTypSel.byIDPatient, rGiboKlient.KlientID, rGiboKlient.IDAbteilung)
                rAufenthaltVerlauf = daPMDS.getAufenthaltVerlauf(dsPMDSCheck, daPMDS.eTypSel.byIDAufenthalt, rAufenthalt.ID, rGiboKlient.IDAbteilung)
                rAufenthaltzusatz = daPMDS.getAufenthaltZusatz(dsPMDSCheck, daPMDS.eTypSel.byIDAufenthalt, rAufenthalt.ID)

                UpdateAdresse(rAdresse, rGiboKlient, Nothing)
                UpdatePatient(rPatient, rGiboKlient, rAdresse.ID)
                UpdateAufenthalt(rAufenthalt, rGiboKlient, rAufenthaltVerlauf.ID)
                UpdateAufenthaltVerlauf(rAufenthaltVerlauf, rGiboKlient, rAufenthalt.ID)
                UpdateAufenthaltZusatz(rAufenthaltzusatz, rGiboKlient)


                daPMDS.daAdresse.Update(dsPMDSCheck.Adresse)
                daPMDS.daPatient.Update(dsPMDSCheck.Patient)

                If daPMDS.CheckAbteilung(dsPMDSCheck, rAufenthalt.IDAbteilung) = False Then
                    rAufenthalt.IDAbteilung = System.Guid.Empty
                    rAufenthaltVerlauf.IDAbteilung_Nach = System.Guid.Empty

                End If
                daPMDS.daAufenthalt.Update(dsPMDSCheck.Aufenthalt)

                daPMDS.daAufenthaltVerlauf.Update(dsPMDSCheck.AufenthaltVerlauf)
                daPMDS.daAufenthaltZusatz.Update(dsPMDSCheck.AufenthaltZusatz)
            End If
        Next


        '--------------------------------------------------------------------------------
        'Kontaktpersonen
        '--------------------------------------------------------------------------------

        For Each rGiboKontaktperson As dsGibodat.vAngehörige_PMDSRow In dsGibodat.vAngehörige_PMDS

            'wenn es einen Patienten zur Kontaktperson gibt
            Dim dsPMDSCheckPat As New dsPMDS1
            rPatient = daPMDS.getPatient(dsPMDSCheckPat, daPMDS.eTypSel.byIDPatient, rGiboKontaktperson.KlientID)

            If rPatient.Nachname = "" Then
                'skip
                frm.txtErrors.Text += "Fehlerhafte Kontaktperson (Klient fehlt): " & rGiboKontaktperson.Nachname & " " & rGiboKontaktperson.Vorname & vbCrLf

            Else

                dbBase.CheckNulls(rGiboKontaktperson)
                Dim dsPMDSCheck As New dsPMDS1

                rKontaktperson = daPMDS.getKontaktperson(dsPMDSCheck, daPMDS.eTypSel.byIDKontaktperson, rGiboKontaktperson.KontaktpersonID, rGiboKontaktperson.KlientID)
                rKontakt = daPMDS.getKontakt(dsPMDSCheck, daPMDS.eTypSel.byIDKontakt, rKontaktperson.IDKontakt)
                rAdresse = daPMDS.getAdresse(dsPMDSCheck, daPMDS.eTypSel.byIDAdresse, rKontaktperson.IDAdresse)

                UpdateAdresse(rAdresse, Nothing, rGiboKontaktperson)
                UpdateKontakt(rKontakt, rGiboKontaktperson)
                UpdateKontaktPerson(rKontaktperson, rGiboKontaktperson, rGiboKontaktperson.KlientID, rAdresse.ID, rKontakt.ID)

                daPMDS.daAdresse.Update(dsPMDSCheck.Adresse)
                daPMDS.daKontakt.Update(dsPMDSCheck.Kontakt)
                daPMDS.daKontaktperson.Update(dsPMDSCheck.Kontaktperson)

            End If

        Next

        '-------------------------------------------------------------------
        ' Update-Timestamp
        '-------------------------------------------------------------------
        rSync = daGibodat.getSync(dsGibodat, VB.daGibodat.eTypSel.all)
        daGibodat.daSyncPMDS.Update(dsGibodat.tSync_PMDS)

        Return True

    End Function


    Function UpdateAdresse(ByVal rAdresse As dsPMDS1.AdresseRow, ByVal rGiboKlient As dsGibodat.vPatienten_PMDSRow, ByVal rGiboKontakt As dsGibodat.vAngehörige_PMDSRow) As Boolean

        If rGiboKontakt Is Nothing Then
            rAdresse.Strasse = IIf(rGiboKlient.IsStrasseNull, "", Left(rGiboKlient.Strasse, 50))
            rAdresse.Plz = IIf(rGiboKlient.IsPLZNull, "", Left(rGiboKlient.PLZ, 6))
            rAdresse.Ort = IIf(rGiboKlient.IsOrtNull, "", Left(rGiboKlient.Ort, 50))
            rAdresse.LandKZ = IIf(rGiboKlient.IsLandNull, "", Left(rGiboKlient.Land, 3))

        Else
            rAdresse.Strasse = IIf(rGiboKontakt.IsStrasseNull, "", Left(rGiboKontakt.Strasse, 50))
            rAdresse.Plz = IIf(rGiboKontakt.IsPLZNull, "", Left(rGiboKontakt.PLZ, 6))
            rAdresse.Ort = IIf(rGiboKontakt.IsOrtNull, "", Left(rGiboKontakt.Ort, 50))
            rAdresse.LandKZ = IIf(rGiboKontakt.IsLandNull, "", Left(rGiboKontakt.Land, 3))

        End If

    End Function


    Function UpdatePatient(ByVal rPatient As dsPMDS1.PatientRow, ByVal rGiboKlient As dsGibodat.vPatienten_PMDSRow, ByVal IDAdresse As System.Guid) As Boolean

        rPatient.ID = rGiboKlient.KlientID
        rPatient.Nachname = Left(rGiboKlient.Nachname, 25)
        rPatient.Vorname = Left(rGiboKlient.Vorname, 25)
        rPatient.Titel = Left(rGiboKlient.AkadGrad, 40)

        rPatient.Anrede = Left(rGiboKlient.Anrede, 15)
        rPatient.Klientennummer = Left(rGiboKlient.KlientenNr, 20)
        rPatient.Sexus = Left(rGiboKlient.Geschlecht, 15)
        rPatient.Familienstand = Left(rGiboKlient.Familienstand, 255)
        rPatient.Konfision = Left(rGiboKlient.Konfession, 255)
        rPatient.LedigerName = Left(rGiboKlient.Geburtsname, 50)
        rPatient.Geburtsort = Left(rGiboKlient.Geburtsort, 50)
        rPatient.Staatsb = Left(rGiboKlient.Staatsbürgerschaft, 255)
        rPatient.Geburtsdatum = rGiboKlient.Geburtsdatum

        If rGiboKlient.IsNamenstagNull Then
            rPatient.SetNamenstagNull()
        Else
            rPatient.Namenstag = rGiboKlient.Namenstag
        End If

        If rGiboKlient.IsFotoNull Then
            rPatient.SetFotoNull()
        Else
            rPatient.Foto = rGiboKlient.Foto
        End If

        rPatient.Kosename = Left(rGiboKlient.Kosename, 50)
        rPatient.KrankenKasse = Left(rGiboKlient.Krankenkasse, 40)
        rPatient.VersicherungsNr = Left(rGiboKlient.SVNR, 50)
        rPatient.IDAdresse = IDAdresse

    End Function



    Function UpdateAufenthalt(ByVal rAufenthalt As dsPMDS1.AufenthaltRow, ByVal rGiboKlient As dsGibodat.vPatienten_PMDSRow, ByVal IDAufenthaltverlauf As System.Guid) As Boolean

        rAufenthalt.IDAufenthaltVerlauf = IDAufenthaltverlauf

        If rGiboKlient.IsAufnahmedatumNull Or rGiboKlient.Aufnahmedatum = "" Then
            rAufenthalt.SetAufnahmezeitpunktNull()
        Else
            rAufenthalt.Aufnahmezeitpunkt = rGiboKlient.Aufnahmedatum
        End If

    End Function


    Function UpdateAufenthaltVerlauf(ByVal rAufenthaltVerlauf As dsPMDS1.AufenthaltVerlaufRow, ByVal rGiboKlient As dsGibodat.vPatienten_PMDSRow, ByVal IDAufenthalt As System.Guid) As Boolean

        rAufenthaltVerlauf.IDAufenthalt = IDAufenthalt
        rAufenthaltVerlauf.Datum = IIf(rAufenthaltVerlauf.IsDatumNull, rGiboKlient.Aufnahmedatum, Date.Now)

    End Function


    Function UpdateAufenthaltZusatz(ByVal rAufenthaltZusatz As dsPMDS1.AufenthaltZusatzRow, ByVal rGiboKlient As dsGibodat.vPatienten_PMDSRow) As Boolean

        rAufenthaltZusatz.Zimmernummer = Left(rGiboKlient.ZimmerNr, 5)

    End Function


    Function UpdateKontakt(ByVal rKontakt As dsPMDS1.KontaktRow, ByVal rGiboKontaktperson As dsGibodat.vAngehörige_PMDSRow) As Boolean

        rKontakt.Tel = Left(rGiboKontaktperson.Telefon, 25)
        rKontakt.Fax = Left(rGiboKontaktperson.Fax, 25)
        rKontakt.Mobil = Left(rGiboKontaktperson.Mobiltelefon, 25)
        rKontakt.Email = Left(rGiboKontaktperson.Email, 50)

    End Function


    Function UpdateKontaktPerson(ByVal rKontaktPerson As dsPMDS1.KontaktpersonRow, ByVal rGiboKontaktperson As dsGibodat.vAngehörige_PMDSRow, _
                                    ByVal IDPatient As System.Guid, ByVal IDAdresse As System.Guid, ByVal IDKontakt As System.Guid) As Boolean

        rKontaktPerson.Nachname = Left(rGiboKontaktperson.Nachname, 25)
        rKontaktPerson.Vorname = Left(rGiboKontaktperson.Vorname, 25)
        rKontaktPerson.Verwandtschaft = Left(rGiboKontaktperson.VerwandVerh, 255)
        rKontaktPerson.IDPatient = IDPatient
        rKontaktPerson.IDAdresse = IDAdresse
        rKontaktPerson.IDKontakt = IDKontakt

    End Function


    Public Function Left(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(0, nLen))
    End Function

    Public Function Right(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(sText.Length - nLen))
    End Function

End Class
