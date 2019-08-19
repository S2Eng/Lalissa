Public Class daPMDS

    Public sel_daPatient As String
    Public sel_daAufenthalt As String
    Public sel_daAufenthaltZusatz As String
    Public sel_daAufenthaltVerlauf As String
    Public sel_daKontaktperson As String
    Public sel_daAdresse As String
    Public sel_daKontakt As String
    Public sel_daAbteilung As String


    Public Enum eTypSel
        all = 0
        byIDPatient = 1
        byIDAufenthalt = 2
        byIDKontakt = 3
        byIDAdresse = 4
        byIDKontaktperson = 5
    End Enum

    Public Sub initControl()

        Me.sel_daPatient = Me.daPatient.SelectCommand.CommandText
        Me.sel_daAufenthaltzusatz = Me.daAufenthaltZusatz.SelectCommand.CommandText
        Me.sel_daAufenthalt = Me.daAufenthalt.SelectCommand.CommandText
        Me.sel_daAufenthaltVerlauf = Me.daAufenthaltVerlauf.SelectCommand.CommandText
        Me.sel_daKontaktperson = Me.daKontaktperson.SelectCommand.CommandText
        Me.sel_daAdresse = Me.daAdresse.SelectCommand.CommandText
        Me.sel_daKontakt = Me.daKontakt.SelectCommand.CommandText
        Me.sel_daAbteilung = Me.daAbteilung.SelectCommand.CommandText

    End Sub

    Public Function CheckAbteilung(ByRef ds As dsPMDS1, ByVal IDAbteilung As System.Guid) As Boolean

        ds.Abteilung.Rows.Clear()
        Me.daAbteilung.SelectCommand.Parameters.Clear()

        Me.daAbteilung.SelectCommand.CommandText = Me.sel_daAbteilung
        dbBase.setDBConnection_dataAdapter(Me.daAbteilung)
        Me.daAbteilung.SelectCommand.CommandText += " WHERE ID = ?"
        Me.daAbteilung.SelectCommand.Parameters.AddWithValue("ID", IDAbteilung)
        Me.daAbteilung.Fill(ds.Abteilung)

        If ds.Abteilung.Rows.Count = 0 Then
            Return False
        ElseIf ds.Patient.Rows.Count = 1 Then
            Return True
        End If

    End Function

    Public Function getPatient(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDPatient As System.Guid) As dsPMDS1.PatientRow

        ds.Patient.Rows.Clear()
        Me.daPatient.SelectCommand.Parameters.Clear()

        Dim rPatient As dsPMDS1.PatientRow

        Me.daPatient.SelectCommand.CommandText = Me.sel_daPatient
        dbBase.setDBConnection_dataAdapter(Me.daPatient)
        If typ = eTypSel.all Then
            Me.daPatient.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        ElseIf typ = eTypSel.byIDPatient Then
            Me.daPatient.SelectCommand.CommandText += " WHERE ID = ?  "
            Me.daPatient.SelectCommand.Parameters.AddWithValue("ID", IDPatient)
        End If

        Me.daPatient.Fill(ds.Patient)

        If ds.Patient.Rows.Count = 0 Then              'neue leere Adresse-Row anlegen mit GUID von Gibodat  
            rPatient = addNewPatient(ds)
            rPatient.ID = IDPatient
            rPatient.IDAdresse = System.Guid.NewGuid
            rPatient.IDKontakt = System.Guid.Empty
            Return rPatient

        ElseIf ds.Patient.Rows.Count = 1 Then           'bestehende Adresse-Row benutzen
            rPatient = ds.Patient.Rows(0)
            Return rPatient
        End If



    End Function

    Public Function addNewPatient(ByRef ds As dsPMDS1) As dsPMDS1.PatientRow

        Dim rNew As dsPMDS1.PatientRow = ds.Patient.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        ds.Patient.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getAufenthalt(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDPatient As System.Guid, ByVal IDAbteilung As System.Guid) As dsPMDS1.AufenthaltRow

        ds.Aufenthalt.Rows.Clear()
        Me.daAufenthalt.SelectCommand.Parameters.Clear()

        Dim rAufenthalt As dsPMDS1.AufenthaltRow

        Me.daAufenthalt.SelectCommand.CommandText = Me.sel_daAufenthalt
        dbBase.setDBConnection_dataAdapter(Me.daAufenthalt)
        If typ = eTypSel.all Then
            Me.daAufenthalt.SelectCommand.CommandText += " ORDER BY Aufnahmezeitpunkt "
        ElseIf typ = eTypSel.byIDPatient Then
            Me.daAufenthalt.SelectCommand.CommandText += " WHERE IDPatient = ? AND Entlassungszeitpunkt IS NULL"
            Me.daAufenthalt.SelectCommand.Parameters.AddWithValue("IDPatient", IDPatient)
        End If

        'Dim Pat As New PMDS.BusinessLogic.Patient(IDPatient)
        'Pat.Aufenthalt.

        'Dim aufenthalt As New PMDS.BusinessLogic.Aufenthalt(


        Me.daAufenthalt.Fill(ds.Aufenthalt)


        If ds.Aufenthalt.Rows.Count = 0 Then                'neue leere Aufenthalt-Row anlegen   
            rAufenthalt = addNewAufenthalt(ds)
            rAufenthalt.IDPatient = IDPatient
            rAufenthalt.ID = System.Guid.NewGuid
            rAufenthalt.SetAufnahmezeitpunktNull()
            rAufenthalt.IDAbteilung = IDAbteilung

        Else                                                'bestehende Adresse-Row benutzen
            rAufenthalt = ds.Aufenthalt.Rows(0)

        End If

        Return rAufenthalt


    End Function

    Public Function addNewAufenthalt(ByRef ds As dsPMDS1) As dsPMDS1.AufenthaltRow

        Dim rNew As dsPMDS1.AufenthaltRow = ds.Aufenthalt.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        rNew.IDKlinik = PMDS.Global.ENV.IDKlinik
        rNew.IDBereich = PMDS.Global.ENV.IDBereich
        ds.Aufenthalt.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getAufenthaltVerlauf(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDAufenthalt As System.Guid, ByVal IDAbteilung As System.Guid) As dsPMDS1.AufenthaltVerlaufRow

        ds.AufenthaltVerlauf.Rows.Clear()
        Me.daAufenthaltVerlauf.SelectCommand.Parameters.Clear()

        Dim rAufenthaltVerlauf As dsPMDS1.AufenthaltVerlaufRow

        Me.daAufenthaltVerlauf.SelectCommand.CommandText = Me.sel_daAufenthaltVerlauf
        dbBase.setDBConnection_dataAdapter(Me.daAufenthaltVerlauf)
        If typ = eTypSel.all Then
            'Keine Sortierung
        ElseIf typ = eTypSel.byIDAufenthalt Then
            Me.daAufenthaltVerlauf.SelectCommand.CommandText += " WHERE IDAufenthalt = ? ORDER BY Datum DESC "
            Me.daAufenthaltVerlauf.SelectCommand.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt)
        End If

        Me.daAufenthaltVerlauf.Fill(ds.AufenthaltVerlauf)

        Dim AktuelleAbteilungID As System.Guid = System.Guid.Empty

        If ds.AufenthaltVerlauf.Rows.Count >= 1 Then                   'ggf. bestehende Adresse-Row benutzen

            For Each rAufenthaltVerlauf In ds.AufenthaltVerlauf.Rows
                If IsDBNull(rAufenthaltVerlauf.IDAbteilung_Nach) Then
                    'Entlassen -> neuen Datensatz anlegen
                ElseIf rAufenthaltVerlauf.IDAbteilung_Nach <> IDAbteilung Then
                    'Pat liegt in einer anderen Abteilung
                    AktuelleAbteilungID = rAufenthaltVerlauf.IDAbteilung_Nach
                Else
                    Return rAufenthaltVerlauf
                End If
            Next

        End If

        'Neuen Datensatz anlegen
        rAufenthaltVerlauf = addNewAufenthaltVerlauf(ds)
        rAufenthaltVerlauf.IDAufenthalt = IDAufenthalt
        rAufenthaltVerlauf.ID = System.Guid.NewGuid
        rAufenthaltVerlauf.IDAbteilung_Von = AktuelleAbteilungID
        rAufenthaltVerlauf.IDAbteilung_Nach = IDAbteilung
        Return rAufenthaltVerlauf

    End Function

    Public Function addNewAufenthaltVerlauf(ByRef ds As dsPMDS1) As dsPMDS1.AufenthaltVerlaufRow

        Dim rNew As dsPMDS1.AufenthaltVerlaufRow = ds.AufenthaltVerlauf.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        rNew.IDAufenthalt = System.Guid.NewGuid
        ds.AufenthaltVerlauf.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getAufenthaltZusatz(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDAufenthalt As System.Guid) As dsPMDS1.AufenthaltZusatzRow

        ds.AufenthaltZusatz.Rows.Clear()
        Me.daAufenthaltZusatz.SelectCommand.Parameters.Clear()

        Dim rAufenthaltZusatz As dsPMDS1.AufenthaltZusatzRow

        Me.daAufenthaltZusatz.SelectCommand.CommandText = Me.sel_daAufenthaltZusatz
        dbBase.setDBConnection_dataAdapter(Me.daAufenthaltZusatz)
        If typ = eTypSel.all Then
            'Keine Sortierung
        ElseIf typ = eTypSel.byIDAufenthalt Then
            Me.daAufenthaltZusatz.SelectCommand.CommandText += " WHERE IDAufenthalt = ?"
            Me.daAufenthaltZusatz.SelectCommand.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt)
        End If

        Me.daAufenthaltZusatz.Fill(ds.AufenthaltZusatz)

        If ds.AufenthaltZusatz.Rows.Count = 0 Then              'neue leere Aufenthalt-Row anlegen   
            rAufenthaltZusatz = addNewAufenthaltZusatz(ds)
            rAufenthaltZusatz.IDAufenthalt = IDAufenthalt
            rAufenthaltZusatz.ID = System.Guid.NewGuid


        ElseIf ds.AufenthaltZusatz.Rows.Count = 1 Then           'bestehende Adresse-Row benutzen
            rAufenthaltZusatz = ds.AufenthaltZusatz.Rows(0)

        End If

        Return rAufenthaltZusatz

    End Function

    Public Function addNewAufenthaltZusatz(ByRef ds As dsPMDS1) As dsPMDS1.AufenthaltZusatzRow

        Dim rNew As dsPMDS1.AufenthaltZusatzRow = ds.AufenthaltZusatz.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        rNew.IDAufenthalt = System.Guid.NewGuid
        ds.AufenthaltZusatz.Rows.Add(rNew)
        Return rNew

    End Function


    Public Function getKontaktperson(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDKontaktperson As System.Guid, ByVal IDPatient As System.Guid) As dsPMDS1.KontaktpersonRow

        ds.Kontaktperson.Rows.Clear()
        Me.daKontaktperson.SelectCommand.Parameters.Clear()

        Dim rKontaktPerson As dsPMDS1.KontaktpersonRow

        Me.daKontaktperson.SelectCommand.CommandText = Me.sel_daKontaktperson
        dbBase.setDBConnection_dataAdapter(Me.daKontaktperson)
        If typ = eTypSel.all Then
            '  Me.daKontaktperson.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        ElseIf typ = eTypSel.byIDKontaktperson Then
            Me.daKontaktperson.SelectCommand.CommandText += " WHERE ID = ?"
            Me.daKontaktperson.SelectCommand.Parameters.AddWithValue("ID", IDKontaktperson)
        End If

        Me.daKontaktperson.Fill(ds.Kontaktperson)

        If ds.Kontaktperson.Rows.Count = 0 Then              'neue leere Row anlegen mit neuer GUID  
            rKontaktPerson = addNewKontaktPerson(ds, IDKontaktperson, IDPatient)

        ElseIf ds.Kontaktperson.Rows.Count = 1 Then           'bestehende Row benutzen
            rKontaktPerson = ds.Kontaktperson.Rows(0)

        End If

        Return rKontaktPerson


    End Function

    Public Function addNewKontaktPerson(ByRef ds As dsPMDS1, ByVal IDKontaktperson As System.Guid, ByVal IDPatient As System.Guid) As dsPMDS1.KontaktpersonRow

        Dim rNew As dsPMDS1.KontaktpersonRow = ds.Kontaktperson.NewRow
        dbBase.initRow(rNew)

        rNew.ID = IDKontaktperson
        rNew.IDPatient = IDPatient
        rNew.IDKontakt = System.Guid.NewGuid()
        rNew.IDAdresse = System.Guid.NewGuid()

        ds.Kontaktperson.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getKontakt(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDKontakt As System.Guid) As dsPMDS1.KontaktRow

        ds.Kontakt.Rows.Clear()
        Me.daKontakt.SelectCommand.Parameters.Clear()

        Dim rKontakt As dsPMDS1.KontaktRow

        Me.daKontakt.SelectCommand.CommandText = Me.sel_daKontakt
        dbBase.setDBConnection_dataAdapter(Me.daKontakt)
        If typ = eTypSel.all Then
            'Me.daKontakt.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        ElseIf typ = eTypSel.byIDKontakt Then
            Me.daKontakt.SelectCommand.CommandText += " WHERE ID = ?"
            Me.daKontakt.SelectCommand.Parameters.AddWithValue("ID", IDKontakt)
        End If

        Me.daKontakt.Fill(ds.Kontakt)

        If ds.Kontakt.Rows.Count = 0 Then              'neue leere Row anlegen mit neuer GUID  
            rKontakt = addNewKontakt(ds)
            rKontakt.ID = IDKontakt

        ElseIf ds.Kontakt.Rows.Count = 1 Then           'bestehende Row benutzen
            rKontakt = ds.Kontakt.Rows(0)

        End If

        Return rKontakt


    End Function

    Public Function addNewKontakt(ByRef ds As dsPMDS1) As dsPMDS1.KontaktRow

        Dim rNew As dsPMDS1.KontaktRow = ds.Kontakt.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        ds.Kontakt.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function getAdresse(ByRef ds As dsPMDS1, ByVal typ As eTypSel, ByVal IDAdresse As System.Guid) As dsPMDS1.AdresseRow

        ds.Adresse.Rows.Clear()
        Me.daAdresse.SelectCommand.Parameters.Clear()

        Dim rAdresse As dsPMDS1.AdresseRow

        Me.daAdresse.SelectCommand.CommandText = Me.sel_daAdresse
        dbBase.setDBConnection_dataAdapter(Me.daAdresse)
        If typ = eTypSel.all Then
            'Me.daKontakt.SelectCommand.CommandText += " ORDER BY Nachname ASC, Vorname ASC"
        ElseIf typ = eTypSel.byIDAdresse Then
            Me.daAdresse.SelectCommand.CommandText += " WHERE ID = ?"
            Me.daAdresse.SelectCommand.Parameters.AddWithValue("ID", IDAdresse)
        End If

        Me.daAdresse.Fill(ds.Adresse)

        If ds.Adresse.Rows.Count = 0 Then              'neue leere Adresse-Row anlegen mit neuer GUID  
            rAdresse = addNewAdresse(ds)
            rAdresse.ID = System.Guid.NewGuid

        ElseIf ds.Adresse.Rows.Count = 1 Then           'bestehende Adresse-Row benutzen
            rAdresse = ds.Adresse.Rows(0)

        End If

        Return rAdresse

    End Function

    Public Function addNewAdresse(ByRef ds As dsPMDS1) As dsPMDS1.AdresseRow

        Dim rNew As dsPMDS1.AdresseRow = ds.Adresse.NewRow
        dbBase.initRow(rNew)
        rNew.ID = System.Guid.NewGuid
        ds.Adresse.Rows.Add(rNew)
        Return rNew

    End Function


End Class
