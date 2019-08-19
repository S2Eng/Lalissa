Imports System.Data.OleDb


Public Class sqlAufgaben

    Public tAufgaben As New DataTable
    Private cmdAufgaben As New OleDbCommand
    Private daAufgaben As New OleDbDataAdapter
    Private sqlAufgaben As String = ""

    Public gen As New GeneralArchiv()


#Region "COLUMNS"
    ' ROWS
    Public ID As System.Guid = Nothing
    Public Betreff As String = ""
    Public IDArt As System.Guid = Nothing
    Public Priorität As String = ""
    Public StatusA As String = ""
    Public Dauer As Integer = 0
    Public Remember As String = ""
    Public Text As String = ""
    Public Zusatz As String = ""
    Public Abgeschlossen As Boolean = False
    Public ELODocu As String = ""
    Public ELOPfad As String = ""
    Public FürIDPerson As String = ""
    Public IDPerson As String = ""
    Public StartTime As Date = Nothing
    Public EndTime As Date = Nothing
    Public StartDate As Date = Nothing
    Public EndDate As Date = Nothing
    Public EventAction As String = ""
    Public EventAllDay As Boolean = False
    Public RememberYesNo As Boolean = False
    Public RemeberAllWeek As Boolean = False
    Public RemeberAllDay As Boolean = False
    Public EventOnOff As Boolean = False
    Public IDAufgabeZuordnung As System.Guid = Nothing
    Public DB As String = ""
    Public KeineAnzeige As Boolean = False

    ' Webaufträge
    Public WEBGesendet As Boolean = False
    Public WEBKommJN As Boolean = False
    Public WEBReaktion As Boolean = False
    Public NextAction As String = ""

    Public FürIDBMB As System.Guid = Nothing

    Public MailAn As String = ""
    Public MailCC As String = ""

    Public AlsHTML As Boolean = False
    Public ErinnerungMail As Boolean = False

    Public gesendetAm As Date = Nothing
    Public Teilnehmer As String = ""

#End Region





    Public Sub New()
        MyBase.New()
        Try
            ClearClassMembers()
            Me.cmdAufgaben.CommandTimeout = 0

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub
    Public Sub New(ByVal ID As System.Guid)
        MyBase.New()
        Try
            ClearClassMembers()
            getAufgaben(ID)

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub
    Public Sub ClearClassMembers()
        Try
            ID = Nothing
            Betreff = ""
            IDArt = Nothing
            Priorität = ""
            StatusA = ""
            Dauer = 0
            Remember = ""
            Text = ""
            Zusatz = ""
            Abgeschlossen = False
            ELODocu = ""
            ELOPfad = ""
            FürIDPerson = ""
            IDPerson = ""
            StartTime = Nothing
            EndTime = Nothing
            StartDate = Nothing
            EndDate = Nothing
            EventAction = ""
            EventAllDay = False
            RememberYesNo = False
            RemeberAllWeek = False
            RemeberAllDay = False
            EventOnOff = False
            IDAufgabeZuordnung = Nothing
            DB = ""
            KeineAnzeige = False

            WEBGesendet = False
            WEBKommJN = False
            WEBReaktion = False
            NextAction = ""

            FürIDBMB = Nothing

            MailAn = ""
            MailCC = ""

            AlsHTML = False
            ErinnerungMail = False

            gesendetAm = Nothing

        Catch ex As Exception
            Throw New Exception("ClearClassMembers: " + ex.ToString())
        End Try
    End Sub

    Public Function getAufgaben(ByVal ID As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            sqlAufgaben = "SELECT ID, Betreff, ErstelltVon, IDArt, Priorität, Status, Dauer, Remember, Text, Zusatz, Abge" &
            "schlossen, ELODocu, ELOPfad, FürIDPerson, IDPerson, StartTime, EndTime, StartDate, EndDate, EventAct" &
            "ion, EventAllDay, RememberYesNo, RemeberAllWeek, RemeberAllDay, EventOnOff, IDAufgabeZuordnung, DB, ErstelltAm, KeineAnzeige, " +
            " WEBGesendet, WEBKommJN, WEBReaktion, NextAction, FürIDBMB, MailAn, MailCC, AlsHTML, ErinnerungMail, gesendetAm, Teilnehmer  FROM " &
            "tblAufgaben  where ID = ? "
            cmdAufgaben = New OleDbCommand(sqlAufgaben, db.getConnDB)
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            daAufgaben.SelectCommand = cmdAufgaben
            daAufgaben.Fill(Me.tAufgaben)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectRow: " + ex.ToString())
        End Try
    End Function

    Public Function listeOffeneTermine(ByVal usrID As String, ByVal txtSearch As String, ByVal dtBenutzer As PMDS.Data.Global.dsBenutzerGruppe.BenutzerGruppeDataTable) As Boolean
        Try
            Me.cmdAufgaben.Parameters.Clear()
            Dim db As New db()

            Dim dbGrp As New PMDS.db.DBGruppe
            Dim sSQLGrp1 As String = ""
            For Each r As PMDS.Data.Global.dsBenutzerGruppe.BenutzerGruppeRow In dtBenutzer.Rows
                Dim rGrp As PMDS.Global.db.Patient.dsGruppe.GruppeRow = dbGrp.readGruppe(r.IDGruppe, True)
                If Not rGrp Is Nothing Then
                    sSQLGrp1 += " or Teilnehmer like '%" + rGrp.Bezeichnung + "%' "
                End If
            Next

            Dim b As New PMDS.db.PMDSBusiness()
            Dim rBenutzer As PMDS.db.Entities.Benutzer = b.LogggedOnUser()
            sSQLGrp1 += " or Teilnehmer like '%" + rBenutzer.Benutzer1.Trim() + "%' "

            Dim sSQLErstellt As String =
                "CONVERT(datetime, (CAST(Year(StartDate) AS Varchar(4)) + '-' + CAST(Month(StartDate) AS Varchar(2)) + '-' + CAST(day(StartDate) AS Varchar(2)) + ' ' + CAST(DATEPART(hh,StartTime)  AS Varchar(4)) + ':' +   CAST(DATEPART(n,StartTime)  AS Varchar(4)) + ':00'), 120 ) as ErstelltAmFormat "

            sqlAufgaben = " SELECT     dbo.tblAufgaben.Betreff, " + sSQLErstellt + ", dbo.tblAufgaben.ErstelltAm, dbo.tblAufgaben.ErstelltVon, dbo.tblAufgaben.Zusatz , " +
                    " dbo.tblAufgaben.ID, dbo.tblAufgaben.StartDate, dbo.tblAufgaben.StartTime,  " +
                    " dbo.tblAufgaben.EndDate, dbo.tblAufgaben.EndTime " +
                    " FROM         dbo.tblAufgaben INNER JOIN " +
                    " dbo.tblAufgabeArt ON dbo.tblAufgaben.IDArt = dbo.tblAufgabeArt.ID " +
                    " WHERE     (dbo.tblAufgabeArt.Beschreibung = 'Aufgabe') OR " +
                    " (dbo.tblAufgabeArt.Beschreibung = 'Termin') and " +
                    " ( IDPerson like '%" + usrID + "%' " + sSQLGrp1 + " or dbo.tblAufgaben.ErstelltVon = '" + usrID + "' ) and  " +
                    " Status <> 'Erledigt' "

            'Sql = " SELECT     dbo.tblAufgaben.Betreff, " + sSQLErstellt + ", dbo.tblAufgaben.ErstelltAm, dbo.tblAufgaben.ErstelltVon, dbo.tblAufgaben.Zusatz , " +
            '        " dbo.tblAufgaben.ID, dbo.tblAufgaben.StartDate, dbo.tblAufgaben.StartTime,  " +
            '        " dbo.tblAufgaben.EndDate, dbo.tblAufgaben.EndTime " +
            '        " FROM         dbo.tblAufgaben INNER JOIN " +
            '        " dbo.tblAufgabeArt ON dbo.tblAufgaben.IDArt = dbo.tblAufgabeArt.ID " +
            '        " WHERE     (dbo.tblAufgabeArt.Beschreibung = 'Aufgabe') OR " +
            '        " (dbo.tblAufgabeArt.Beschreibung = 'Termin') and " +
            '        " ( IDPerson like '%" + usrID + "%' " + sSQLGrp1 + " or dbo.tblAufgaben.ErstelltVon = '" + usrID + "' ) and  " +
            '        " StartTime < ? and Status <> 'Erledigt' "

            If txtSearch <> "" Then sqlAufgaben += " and dbo.tblAufgaben.Betreff like '%" + txtSearch + "%' "
            sqlAufgaben += " order by dbo.tblAufgaben.StartTime desc "

            cmdAufgaben = New OleDbCommand(sqlAufgaben, db.getConnDB)
            daAufgaben.SelectCommand = cmdAufgaben
            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 8, "StartTime")).Value = Now
            daAufgaben.Fill(Me.tAufgaben)
            Return True

        Catch ex As OleDbException
            Throw New Exception("listeOffeneTermine: " + ex.ToString())
        End Try
    End Function

    Public Function termineMailsSuchen(ByVal typPost As GeneralArchiv.InitApplicationAufgabenTermine,
                                                ByVal sqlArtID As String,
                                                ByVal Personen As ArrayList,
                                                ByVal sqlStatusTermine As String, ByVal sqlPriorität As String,
                                                ByVal Von As Date, ByVal Bis As Date,
                                                ByVal typ As GeneralArchiv.eTypPlanung,
                                                ByVal txt As String, ByVal betreffUndText As Boolean,
                                                ByVal IDZuordnung As System.Guid,
                                                ByVal isGesamt As Boolean, ByVal sqlStatusMail As String,
                                                ByVal imGesamtsystemSuchen As Boolean,
                                                ByVal typSucheDatumMail As String) As Boolean
        Try
            Me.cmdAufgaben.Parameters.Clear()
            Dim db As New db()

            If Not Me.gen.IsNull(Von) Then
                Dim nVon As New Date(Von.Year, Von.Month, Von.Day, 0, 0, 0)
                Von = nVon
            End If
            If Not Me.gen.IsNull(Bis) Then
                Dim nBis As New Date(Bis.Year, Bis.Month, Bis.Day, 23, 59, 59)
                Bis = nBis
            End If

            'Dim sSQLErstellt As String = _
            '    "  CASE WHEN  not StartDate IS NULL THEN   (CAST(Year(StartDate) AS Varchar(4))+'-' + CAST(Month(StartDate) AS Varchar(2)) + '-' + CAST(day(StartDate) AS Varchar(2)) + ' ' +   CAST(DATEPART(hh,StartTime)  AS Varchar(4)) + ':' +   CAST(DATEPART(mm,StartTime)  AS Varchar(4)) ) as ErstelltAmFormat ELSE '' as  ErstelltAmFormat END "

            Dim sSQLErstellt As String =
                "CONVERT(datetime, (CAST(Year(StartDate) AS Varchar(4))+'-' + CAST(Month(StartDate) AS Varchar(2)) + '-' + CAST(day(StartDate) AS Varchar(2)) + ' ' +   CAST(DATEPART(hh,StartTime)  AS Varchar(4)) + ':' +   CAST(DATEPART(n,StartTime)  AS Varchar(4)) + ':00' ), 120) as ErstelltAmFormat "

            sqlAufgaben = " SELECT tblAufgaben.Betreff, " + sSQLErstellt + ", tblAufgaben.ErstelltAm, gesendetAm, MailAn, " +
                    " MailCC,  AlsHTML, tblAufgaben.Zusatz as Patient, tblAufgaben.FürIDPerson as FürPfleger, tblAufgaben.ErstelltVon, " +
                    " tblAufgaben.Status,  " +
                    " tblAufgaben.Dauer,  tblAufgaben.Priorität, tblAufgaben.Abgeschlossen, " +
                    " '' as DateTime, " +
                    " tblAufgaben.StartTime, tblAufgaben.EndTime, tblAufgaben.StartDate, " +
                    " tblAufgaben.EndDate,  tblAufgaben.EventAction, tblAufgaben.IDPerson, " +
                    " tblAufgaben.ID, tblAufgaben.IDArt "

            If Not Me.gen.IsNull(IDZuordnung) Then sqlAufgaben += ", tblAufgabeZuordnung.IDZuordnung "
            sqlAufgaben += " FROM tblAufgaben, tblAufgabeArt  "
            If Not Me.gen.IsNull(IDZuordnung) Then sqlAufgaben += " , tblAufgabeZuordnung "
            sqlAufgaben += " where (" + sqlArtID + ") and tblAufgabeArt.ID = tblAufgaben.IDArt "

            If Not Me.gen.IsNull(IDZuordnung) Then
                sqlAufgaben += " and tblAufgabeZuordnung.IDAufgabe = tblAufgaben.ID  and tblAufgabeZuordnung.IDZuordnung = '" + IDZuordnung.ToString + "' "
            Else
                If Not imGesamtsystemSuchen Then
                    sqlAufgaben += " and tblAufgaben.ErstelltVon = '" + Me.gen.actUser + "' "
                End If
            End If

            If sqlStatusTermine <> "" Then sqlAufgaben += " and (" + sqlStatusTermine + ") "
            If sqlStatusMail <> "" Then sqlAufgaben += " and (" + sqlStatusMail + ") "
            'If sqlPriorität <> "" Then Sql += " and (" + sqlPriorität + ") "

            If typ = GeneralArchiv.eTypPlanung.termin Then
                If Not Me.gen.IsNull(Von) Then sqlAufgaben += " and StartTime >= ? "
                If Not Me.gen.IsNull(Bis) Then sqlAufgaben += " and EndDate <= ? "
            ElseIf typ = GeneralArchiv.eTypPlanung.mail Then
                If typSucheDatumMail = "gesendetAm" Then
                    If Not Me.gen.IsNull(Von) Then sqlAufgaben += " and gesendetAm >= ? "
                    If Not Me.gen.IsNull(Bis) Then sqlAufgaben += " and gesendetAm <= ? "
                ElseIf typSucheDatumMail = "ErstelltAm" Then
                    If Not Me.gen.IsNull(Von) Then sqlAufgaben += " and ErstelltAm >= ? "
                    If Not Me.gen.IsNull(Bis) Then sqlAufgaben += " and ErstelltAm <= ? "
                End If
            End If

            If txt <> "" Then
                If betreffUndText Then
                    sqlAufgaben += " and ( Betreff like '%" + txt + "%'  or Text like '%" + txt + "%' ) "
                Else
                    sqlAufgaben += " and ( Betreff like '%" + txt + "%' ) "
                End If
            End If

            sqlAufgaben = sqlAufgaben + " order by StartDate desc , StartTime desc  "

            cmdAufgaben = New OleDbCommand(sqlAufgaben, db.getConnDB)

            If typ = GeneralArchiv.eTypPlanung.termin Then
                If Not Me.gen.IsNull(Von) Then Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 8, "StartTime")).Value = Von
                If Not Me.gen.IsNull(Bis) Then Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.Date, 8, "EndDate")).Value = Bis
            ElseIf typ = GeneralArchiv.eTypPlanung.mail Then
                If Not Me.gen.IsNull(Von) Then Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter(typSucheDatumMail, System.Data.OleDb.OleDbType.Date, 8, typSucheDatumMail)).Value = Von
                If Not Me.gen.IsNull(Bis) Then Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter(typSucheDatumMail, System.Data.OleDb.OleDbType.Date, 8, typSucheDatumMail)).Value = Bis 'gesendetAm
            End If

            daAufgaben.SelectCommand = cmdAufgaben
            daAufgaben.Fill(Me.tAufgaben)
            Return True

        Catch ex As OleDbException
            Throw New Exception("termineMailsSuchen: " + ex.ToString())
        End Try
    End Function

    Public Function InsertRow() As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            Me.cmdAufgaben.CommandText = "INSERT INTO tblAufgaben(ID, Betreff, IDArt, Priorität, Status, Dauer, Remember, T" &
            "ext, Zusatz, Abgeschlossen, ELODocu, ELOPfad, FürIDPerson, IDPerson, StartTime, " &
            "EndTime, StartDate, EndDate, EventAction, EventAllDay, RememberYesNo, RemeberAllWeek, RemeberAllDay," &
            " EventOnOff, IDAufgabeZuordnung, DB, ErstelltVon, ErstelltAm , WEBGesendet, WEBKommJN, WEBReaktion, NextAction, FürIDBMB, MailAn, MailCC, AlsHTML, ErinnerungMail, Teilnehmer ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Me.cmdAufgaben.Connection = db.getConnDB

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 200, "Betreff")).Value = Betreff
            If IDArt.ToString = Me.gen.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.Guid, 16, "IDArt")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.Guid, 16, "IDArt")).Value = IDArt
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Priorität", System.Data.OleDb.OleDbType.VarChar, 50, "Priorität")).Value = Priorität
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 50, "Status")).Value = StatusA
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 4, "Dauer")).Value = Dauer
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Remember", System.Data.OleDb.OleDbType.VarChar, 100, "Remember")).Value = Remember
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = Text
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Zusatz", System.Data.OleDb.OleDbType.LongVarChar, 0, "Zusatz")).Value = Zusatz
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Abgeschlossen", System.Data.OleDb.OleDbType.Boolean, 1, "Abgeschlossen")).Value = Abgeschlossen
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ELODocu", System.Data.OleDb.OleDbType.VarChar, 100, "ELODocu")).Value = ELODocu
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ELOPfad", System.Data.OleDb.OleDbType.VarChar, 100, "ELOPfad")).Value = ELOPfad
            If FürIDPerson.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "FürIDPerson")).Value = ""
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "FürIDPerson")).Value = FürIDPerson
            End If
            If IDPerson.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "IDPerson")).Value = ""
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "IDPerson")).Value = IDPerson
            End If

            If Me.gen.IsNull(StartTime) Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 16, "StartTime")).Value = Nothing
            Else
                Dim dStartTimeTmp As New Date(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second)
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 16, "StartTime")).Value = dStartTimeTmp
            End If
            If Me.gen.IsNull(EndTime) Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 16, "EndTime")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 16, "EndTime")).Value = EndTime
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartDate", System.Data.OleDb.OleDbType.DBDate, 8, "StartDate")).Value = Me.gen.CheckDateNull(StartDate)
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBDate, 8, "EndDate")).Value = Me.gen.CheckDateNull(EndDate)

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventAction", System.Data.OleDb.OleDbType.VarChar, 100, "EventAction")).Value = EventAction
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventAllDay", System.Data.OleDb.OleDbType.Boolean, 1, "EventAllDay")).Value = EventAllDay
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RememberYesNo", System.Data.OleDb.OleDbType.Boolean, 1, "RememberYesNo")).Value = RememberYesNo
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RemeberAllWeek", System.Data.OleDb.OleDbType.Boolean, 1, "RemeberAllWeek")).Value = RemeberAllWeek
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RemeberAllDay", System.Data.OleDb.OleDbType.Boolean, 1, "RemeberAllDay")).Value = RemeberAllDay
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventOnOff", System.Data.OleDb.OleDbType.Boolean, 1, "EventOnOff")).Value = EventOnOff
            If IDAufgabeZuordnung.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = IDAufgabeZuordnung
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("DB", System.Data.OleDb.OleDbType.VarChar, 100, "DB")).Value = Me.cmdAufgaben.Connection.Database

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 150, "ErstelltVon")).Value = Me.gen.actUser
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = Now

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBGesendet", System.Data.OleDb.OleDbType.Boolean, 1, "WEBGesendet")).Value = WEBGesendet
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBKommJN", System.Data.OleDb.OleDbType.Boolean, 1, "WEBKommJN")).Value = WEBKommJN
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBReaktion", System.Data.OleDb.OleDbType.Boolean, 1, "WEBReaktion")).Value = WEBReaktion
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("NextAction", System.Data.OleDb.OleDbType.VarChar, 1, "NextAction")).Value = NextAction
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDBMB", System.Data.OleDb.OleDbType.Guid, 16, "FürIDBMB")).Value = Me.gen.CheckIsNull(FürIDBMB)

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("MailAn", System.Data.OleDb.OleDbType.VarChar, 150, "MailAn")).Value = MailAn
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("MailCC", System.Data.OleDb.OleDbType.VarChar, 800, "MailCC")).Value = MailCC

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("AlsHTML", System.Data.OleDb.OleDbType.Boolean, 1, "AlsHTML")).Value = AlsHTML
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErinnerungMail", System.Data.OleDb.OleDbType.Boolean, 1, "ErinnerungMail")).Value = ErinnerungMail
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.VarChar, 0, "Teilnehmer")).Value = Me.Teilnehmer

            Me.cmdAufgaben.ExecuteNonQuery()

            Return True

        Catch ex As OleDbException
            Throw New Exception("InsertRow: " + ex.ToString())
        Catch ex As Exception
            Throw New Exception("InsertRow: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateRow(ByVal ID As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            Me.cmdAufgaben.CommandText = "UPDATE tblAufgaben SET Betreff = ?, IDArt = ?, Priorität = ?, Status = ?," &
            " Dauer = ?, Remember = ?, Text = ?, Zusatz = ?, Abgeschlossen = ?, ELODocu = ?, " &
            "ELOPfad = ?, FürIDPerson = ?, IDPerson = ?, StartTime = ?, EndTime = ?, StartDate = ?, EndDate = ?, EventAct" &
            "ion = ?, EventAllDay = ?, RememberYesNo = ?, RemeberAllWeek = ?, RemeberAllDay =" &
            " ?, EventOnOff = ?, IDAufgabeZuordnung = ?, DB = ?,  WEBGesendet = ?, WEBKommJN = ?, WEBReaktion = ?, NextAction = ?, FürIDBMB = ?, MailAn = ?, MailCC = ?, AlsHTML = ?, ErinnerungMail = ?, Teilnehmer = ?  WHERE (ID = ?)"
            Me.cmdAufgaben.Connection = db.getConnDB

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 200, "Betreff")).Value = Betreff
            If IDArt.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.Guid, 16, "IDArt")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.Guid, 16, "IDArt")).Value = IDArt
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Priorität", System.Data.OleDb.OleDbType.VarChar, 50, "Priorität")).Value = Priorität
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 50, "Status")).Value = StatusA
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 4, "Dauer")).Value = Dauer
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Remember", System.Data.OleDb.OleDbType.VarChar, 100, "Remember")).Value = Remember
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = Text
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Zusatz", System.Data.OleDb.OleDbType.LongVarChar, 0, "Zusatz")).Value = Zusatz
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Abgeschlossen", System.Data.OleDb.OleDbType.Boolean, 1, "Abgeschlossen")).Value = Abgeschlossen
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ELODocu", System.Data.OleDb.OleDbType.VarChar, 100, "ELODocu")).Value = ELODocu
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ELOPfad", System.Data.OleDb.OleDbType.VarChar, 100, "ELOPfad")).Value = ELOPfad
            If FürIDPerson.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "FürIDPerson")).Value = ""
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "FürIDPerson")).Value = FürIDPerson
            End If
            If IDPerson.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "IDPerson")).Value = ""
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDPerson", System.Data.OleDb.OleDbType.VarChar, 80, "IDPerson")).Value = IDPerson
            End If

            If Me.gen.IsNull(StartTime) Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 16, "StartTime")).Value = Nothing
            Else
                Dim dStartTimeTmp As New Date(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second)
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 16, "StartTime")).Value = dStartTimeTmp
            End If
            If Me.gen.IsNull(EndTime) Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 16, "EndTime")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 16, "EndTime")).Value = EndTime
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartDate", System.Data.OleDb.OleDbType.DBDate, 8, "StartDate")).Value = Me.gen.CheckDateNull(StartDate)
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBDate, 8, "EndDate")).Value = Me.gen.CheckDateNull(EndDate)

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventAction", System.Data.OleDb.OleDbType.VarChar, 100, "EventAction")).Value = EventAction
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventAllDay", System.Data.OleDb.OleDbType.Boolean, 1, "EventAllDay")).Value = EventAllDay
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RememberYesNo", System.Data.OleDb.OleDbType.Boolean, 1, "RememberYesNo")).Value = RememberYesNo
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RemeberAllWeek", System.Data.OleDb.OleDbType.Boolean, 1, "RemeberAllWeek")).Value = RemeberAllWeek
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("RemeberAllDay", System.Data.OleDb.OleDbType.Boolean, 1, "RemeberAllDay")).Value = RemeberAllDay
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("EventOnOff", System.Data.OleDb.OleDbType.Boolean, 1, "EventOnOff")).Value = EventOnOff
            If IDAufgabeZuordnung.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = Nothing
            Else
                Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = IDAufgabeZuordnung
            End If
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("DB", System.Data.OleDb.OleDbType.VarChar, 100, "DB")).Value = Me.cmdAufgaben.Connection.Database

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBGesendet", System.Data.OleDb.OleDbType.Boolean, 1, "WEBGesendet")).Value = WEBGesendet
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBKommJN", System.Data.OleDb.OleDbType.Boolean, 1, "WEBKommJN")).Value = WEBKommJN
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBReaktion", System.Data.OleDb.OleDbType.Boolean, 1, "WEBReaktion")).Value = WEBReaktion
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("NextAction", System.Data.OleDb.OleDbType.VarChar, 1, "NextAction")).Value = NextAction
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDBMB", System.Data.OleDb.OleDbType.Guid, 16, "FürIDBMB")).Value = Me.gen.CheckIsNull(FürIDBMB)

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("MailAn", System.Data.OleDb.OleDbType.VarChar, 150, "MailAn")).Value = MailAn
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("MailCC", System.Data.OleDb.OleDbType.VarChar, 800, "MailCC")).Value = MailCC

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("AlsHTML", System.Data.OleDb.OleDbType.Boolean, 1, "AlsHTML")).Value = AlsHTML
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErinnerungMail", System.Data.OleDb.OleDbType.Boolean, 1, "ErinnerungMail")).Value = ErinnerungMail
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.VarChar, 0, "Teilnehmer")).Value = Me.Teilnehmer

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID

            Me.cmdAufgaben.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow: " + ex.ToString())
        End Try
    End Function

    Public Function UpdateRow_WEBGesendet_NextAction(ByVal ID As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            Me.cmdAufgaben.CommandText = "UPDATE tblAufgaben SET   WEBGesendet = ? , NextAction = ?, gesendetAm = ?  WHERE (ID = ?)"
            Me.cmdAufgaben.Connection = db.getConnDB

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("WEBGesendet", System.Data.OleDb.OleDbType.Boolean, 1, "WEBGesendet")).Value = Me.WEBGesendet
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("NextAction", System.Data.OleDb.OleDbType.VarChar, 1, "NextAction")).Value = Me.NextAction
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("gesendetAm", System.Data.OleDb.OleDbType.Date, 8, "gesendetAm")).Value = Me.gesendetAm

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID

            Me.cmdAufgaben.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow_WEBGesendet_NextAction: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateRow_Abgeschlossen(ByVal ID As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            Me.cmdAufgaben.CommandText = "UPDATE tblAufgaben SET  Abgeschlossen = ?, Status = ?  WHERE (ID = ?)"
            Me.cmdAufgaben.Connection = db.getConnDB

            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Abgeschlossen", System.Data.OleDb.OleDbType.Boolean, 1, "Abgeschlossen")).Value = True
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 50, "Status")).Value = StatusA
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID

            Me.cmdAufgaben.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow_Abgeschlossen: " + ex.ToString())
        End Try
    End Function

    Public Function DeleteRow(ByVal ID As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgaben.Parameters.Clear()
            Me.cmdAufgaben.CommandText = "DELETE FROM tblAufgaben WHERE (ID = ?)"
            Me.cmdAufgaben.Connection = db.getConnDB
            Me.cmdAufgaben.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.cmdAufgaben.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("DeleteRow: " + ex.ToString())
        End Try
    End Function

End Class
