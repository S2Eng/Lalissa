Partial Class compPlan
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        Me.sqldaPlan = Me.daPlan.SelectCommand.CommandText
        Me.sqldaPlanAnhang = Me.daPlanAnhang.SelectCommand.CommandText
        Me.sqldaPlanObject = Me.daPlanObject.SelectCommand.CommandText
        Me.sqldaPlanStatus = Me.daPlanStatus.SelectCommand.CommandText
        Me.sqldaPlanBereich = Me.daPlanBereich.SelectCommand.CommandText
        Me.sqldaSearchPlanBereich = Me.daSearchPlanBereich.SelectCommand.CommandText
    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compPlan))
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.daPlan = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanAnhang = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanObject = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanSearch = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand15 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanStatus = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand13 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand14 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand16 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand17 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanSearchPatients = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand9 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanSearchPatientsAll = New System.Data.OleDb.OleDbDataAdapter()
        Me.daSearchPlanBereich = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand12 = New System.Data.OleDb.OleDbCommand()
        Me.daPlanBereich = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand10 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand11 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand18 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand19 = New System.Data.OleDb.OleDbCommand()
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" &
    "s21+!;User ID=hl;Initial Catalog=PMDSDev"
        '
        'daPlan
        '
        Me.daPlan.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daPlan.InsertCommand = Me.OleDbInsertCommand1
        Me.daPlan.SelectCommand = Me.OleDbSelectCommand1
        Me.daPlan.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "plan", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("FälligAm", "FälligAm"), New System.Data.Common.DataColumnMapping("IDArt", "IDArt"), New System.Data.Common.DataColumnMapping("Priorität", "Priorität"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("readed", "readed"), New System.Data.Common.DataColumnMapping("deleted", "deleted"), New System.Data.Common.DataColumnMapping("design", "design"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Zusatz", "Zusatz"), New System.Data.Common.DataColumnMapping("MailFrom", "MailFrom"), New System.Data.Common.DataColumnMapping("MailAn", "MailAn"), New System.Data.Common.DataColumnMapping("MailCC", "MailCC"), New System.Data.Common.DataColumnMapping("MailBcc", "MailBcc"), New System.Data.Common.DataColumnMapping("html", "html"), New System.Data.Common.DataColumnMapping("Für", "Für"), New System.Data.Common.DataColumnMapping("gesendetAm", "gesendetAm"), New System.Data.Common.DataColumnMapping("empfangenAm", "empfangenAm"), New System.Data.Common.DataColumnMapping("wichtig", "wichtig"), New System.Data.Common.DataColumnMapping("remembJN", "remembJN"), New System.Data.Common.DataColumnMapping("remembMinut", "remembMinut"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("KommStatus", "KommStatus"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("IDUserAccount", "IDUserAccount"), New System.Data.Common.DataColumnMapping("MessageId", "MessageId"), New System.Data.Common.DataColumnMapping("DetailsMIME", "DetailsMIME"), New System.Data.Common.DataColumnMapping("IDPlanMain", "IDPlanMain"), New System.Data.Common.DataColumnMapping("AwaitingResponse", "AwaitingResponse"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("IsOwner", "IsOwner"), New System.Data.Common.DataColumnMapping("IDFolder", "IDFolder"), New System.Data.Common.DataColumnMapping("ID1Tmp", "ID1Tmp"), New System.Data.Common.DataColumnMapping("ID2Tmp", "ID2Tmp"), New System.Data.Common.DataColumnMapping("ID3Tmp", "ID3Tmp"), New System.Data.Common.DataColumnMapping("SendWithPostOfficeBoxForAll", "SendWithPostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("OutlookAPI", "OutlookAPI"), New System.Data.Common.DataColumnMapping("ConversationID", "ConversationID"), New System.Data.Common.DataColumnMapping("IDoutlook", "IDoutlook"), New System.Data.Common.DataColumnMapping("IDoutlookTicks", "IDoutlookTicks"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("LastChangeITSCont", "LastChangeITSCont"), New System.Data.Common.DataColumnMapping("LastSyncToExchange", "LastSyncToExchange"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})})
        Me.daPlan.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [plan] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.dbConn
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.dbConn
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.[Date], 16, "BeginntAm"), New System.Data.OleDb.OleDbParameter("FälligAm", System.Data.OleDb.OleDbType.[Date], 16, "FälligAm"), New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.[Integer], 0, "IDArt"), New System.Data.OleDb.OleDbParameter("Priorität", System.Data.OleDb.OleDbType.VarChar, 0, "Priorität"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("readed", System.Data.OleDb.OleDbType.[Boolean], 0, "readed"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted"), New System.Data.OleDb.OleDbParameter("design", System.Data.OleDb.OleDbType.[Boolean], 0, "design"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Zusatz", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz"), New System.Data.OleDb.OleDbParameter("MailFrom", System.Data.OleDb.OleDbType.VarChar, 0, "MailFrom"), New System.Data.OleDb.OleDbParameter("MailAn", System.Data.OleDb.OleDbType.VarChar, 0, "MailAn"), New System.Data.OleDb.OleDbParameter("MailCC", System.Data.OleDb.OleDbType.VarChar, 0, "MailCC"), New System.Data.OleDb.OleDbParameter("MailBcc", System.Data.OleDb.OleDbType.VarChar, 0, "MailBcc"), New System.Data.OleDb.OleDbParameter("html", System.Data.OleDb.OleDbType.[Boolean], 0, "html"), New System.Data.OleDb.OleDbParameter("Für", System.Data.OleDb.OleDbType.VarChar, 0, "Für"), New System.Data.OleDb.OleDbParameter("gesendetAm", System.Data.OleDb.OleDbType.[Date], 16, "gesendetAm"), New System.Data.OleDb.OleDbParameter("empfangenAm", System.Data.OleDb.OleDbType.[Date], 16, "empfangenAm"), New System.Data.OleDb.OleDbParameter("wichtig", System.Data.OleDb.OleDbType.[Boolean], 0, "wichtig"), New System.Data.OleDb.OleDbParameter("remembJN", System.Data.OleDb.OleDbType.[Boolean], 0, "remembJN"), New System.Data.OleDb.OleDbParameter("remembMinut", System.Data.OleDb.OleDbType.[Integer], 0, "remembMinut"), New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.VarChar, 0, "Teilnehmer"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.[Date], 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("IDActivity", System.Data.OleDb.OleDbType.Guid, 0, "IDActivity"), New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 0, "IDStatus"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.VarChar, 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("KommStatus", System.Data.OleDb.OleDbType.VarChar, 0, "KommStatus"), New System.Data.OleDb.OleDbParameter("db", System.Data.OleDb.OleDbType.LongVarBinary, 0, "db"), New System.Data.OleDb.OleDbParameter("IDUserAccount", System.Data.OleDb.OleDbType.Guid, 0, "IDUserAccount"), New System.Data.OleDb.OleDbParameter("MessageId", System.Data.OleDb.OleDbType.VarChar, 0, "MessageId"), New System.Data.OleDb.OleDbParameter("DetailsMIME", System.Data.OleDb.OleDbType.LongVarWChar, 0, "DetailsMIME"), New System.Data.OleDb.OleDbParameter("IDPlanMain", System.Data.OleDb.OleDbType.Guid, 0, "IDPlanMain"), New System.Data.OleDb.OleDbParameter("AwaitingResponse", System.Data.OleDb.OleDbType.VarChar, 0, "AwaitingResponse"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.VarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("IsOwner", System.Data.OleDb.OleDbType.[Boolean], 0, "IsOwner"), New System.Data.OleDb.OleDbParameter("IDFolder", System.Data.OleDb.OleDbType.[Integer], 0, "IDFolder"), New System.Data.OleDb.OleDbParameter("ID1Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID1Tmp"), New System.Data.OleDb.OleDbParameter("ID2Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID2Tmp"), New System.Data.OleDb.OleDbParameter("ID3Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID3Tmp"), New System.Data.OleDb.OleDbParameter("SendWithPostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "SendWithPostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("OutlookAPI", System.Data.OleDb.OleDbType.[Boolean], 0, "OutlookAPI"), New System.Data.OleDb.OleDbParameter("ConversationID", System.Data.OleDb.OleDbType.VarChar, 0, "ConversationID"), New System.Data.OleDb.OleDbParameter("IDoutlook", System.Data.OleDb.OleDbType.VarWChar, 0, "IDoutlook"), New System.Data.OleDb.OleDbParameter("IDoutlookTicks", System.Data.OleDb.OleDbType.VarWChar, 0, "IDoutlookTicks"), New System.Data.OleDb.OleDbParameter("Category", System.Data.OleDb.OleDbType.LongVarChar, 0, "Category"), New System.Data.OleDb.OleDbParameter("Folder", System.Data.OleDb.OleDbType.LongVarChar, 0, "Folder"), New System.Data.OleDb.OleDbParameter("LastChangeITSCont", System.Data.OleDb.OleDbType.[Date], 16, "LastChangeITSCont"), New System.Data.OleDb.OleDbParameter("LastSyncToExchange", System.Data.OleDb.OleDbType.[Date], 16, "LastSyncToExchange"), New System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarChar, 0, "Wochentage"), New System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.[Integer], 0, "nTenMonat"), New System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarChar, 0, "SerienterminType"), New System.Data.OleDb.OleDbParameter("IDSerientermin", System.Data.OleDb.OleDbType.Guid, 0, "IDSerientermin"), New System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.VarChar, 0, "TagWochenMonat"), New System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.[Integer], 0, "WiedWertJeden"), New System.Data.OleDb.OleDbParameter("EndetAm", System.Data.OleDb.OleDbType.[Date], 16, "EndetAm"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("GanzerTag", System.Data.OleDb.OleDbType.[Boolean], 0, "GanzerTag"), New System.Data.OleDb.OleDbParameter("IsSerientermin", System.Data.OleDb.OleDbType.[Boolean], 0, "IsSerientermin"), New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.[Date], 16, "SerienterminEndetAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = resources.GetString("OleDbSelectCommand1.CommandText")
        Me.OleDbSelectCommand1.Connection = Me.dbConn
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = resources.GetString("OleDbUpdateCommand1.CommandText")
        Me.OleDbUpdateCommand1.Connection = Me.dbConn
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.[Date], 16, "BeginntAm"), New System.Data.OleDb.OleDbParameter("FälligAm", System.Data.OleDb.OleDbType.[Date], 16, "FälligAm"), New System.Data.OleDb.OleDbParameter("IDArt", System.Data.OleDb.OleDbType.[Integer], 0, "IDArt"), New System.Data.OleDb.OleDbParameter("Priorität", System.Data.OleDb.OleDbType.VarChar, 0, "Priorität"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("readed", System.Data.OleDb.OleDbType.[Boolean], 0, "readed"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted"), New System.Data.OleDb.OleDbParameter("design", System.Data.OleDb.OleDbType.[Boolean], 0, "design"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Zusatz", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz"), New System.Data.OleDb.OleDbParameter("MailFrom", System.Data.OleDb.OleDbType.VarChar, 0, "MailFrom"), New System.Data.OleDb.OleDbParameter("MailAn", System.Data.OleDb.OleDbType.VarChar, 0, "MailAn"), New System.Data.OleDb.OleDbParameter("MailCC", System.Data.OleDb.OleDbType.VarChar, 0, "MailCC"), New System.Data.OleDb.OleDbParameter("MailBcc", System.Data.OleDb.OleDbType.VarChar, 0, "MailBcc"), New System.Data.OleDb.OleDbParameter("html", System.Data.OleDb.OleDbType.[Boolean], 0, "html"), New System.Data.OleDb.OleDbParameter("Für", System.Data.OleDb.OleDbType.VarChar, 0, "Für"), New System.Data.OleDb.OleDbParameter("gesendetAm", System.Data.OleDb.OleDbType.[Date], 16, "gesendetAm"), New System.Data.OleDb.OleDbParameter("empfangenAm", System.Data.OleDb.OleDbType.[Date], 16, "empfangenAm"), New System.Data.OleDb.OleDbParameter("wichtig", System.Data.OleDb.OleDbType.[Boolean], 0, "wichtig"), New System.Data.OleDb.OleDbParameter("remembJN", System.Data.OleDb.OleDbType.[Boolean], 0, "remembJN"), New System.Data.OleDb.OleDbParameter("remembMinut", System.Data.OleDb.OleDbType.[Integer], 0, "remembMinut"), New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.VarChar, 0, "Teilnehmer"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.[Date], 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("IDActivity", System.Data.OleDb.OleDbType.Guid, 0, "IDActivity"), New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 0, "IDStatus"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.VarChar, 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("KommStatus", System.Data.OleDb.OleDbType.VarChar, 0, "KommStatus"), New System.Data.OleDb.OleDbParameter("db", System.Data.OleDb.OleDbType.LongVarBinary, 0, "db"), New System.Data.OleDb.OleDbParameter("IDUserAccount", System.Data.OleDb.OleDbType.Guid, 0, "IDUserAccount"), New System.Data.OleDb.OleDbParameter("MessageId", System.Data.OleDb.OleDbType.VarChar, 0, "MessageId"), New System.Data.OleDb.OleDbParameter("DetailsMIME", System.Data.OleDb.OleDbType.LongVarWChar, 0, "DetailsMIME"), New System.Data.OleDb.OleDbParameter("IDPlanMain", System.Data.OleDb.OleDbType.Guid, 0, "IDPlanMain"), New System.Data.OleDb.OleDbParameter("AwaitingResponse", System.Data.OleDb.OleDbType.VarChar, 0, "AwaitingResponse"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.VarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("IsOwner", System.Data.OleDb.OleDbType.[Boolean], 0, "IsOwner"), New System.Data.OleDb.OleDbParameter("IDFolder", System.Data.OleDb.OleDbType.[Integer], 0, "IDFolder"), New System.Data.OleDb.OleDbParameter("ID1Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID1Tmp"), New System.Data.OleDb.OleDbParameter("ID2Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID2Tmp"), New System.Data.OleDb.OleDbParameter("ID3Tmp", System.Data.OleDb.OleDbType.Guid, 0, "ID3Tmp"), New System.Data.OleDb.OleDbParameter("SendWithPostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "SendWithPostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("OutlookAPI", System.Data.OleDb.OleDbType.[Boolean], 0, "OutlookAPI"), New System.Data.OleDb.OleDbParameter("ConversationID", System.Data.OleDb.OleDbType.VarChar, 0, "ConversationID"), New System.Data.OleDb.OleDbParameter("IDoutlook", System.Data.OleDb.OleDbType.VarWChar, 0, "IDoutlook"), New System.Data.OleDb.OleDbParameter("IDoutlookTicks", System.Data.OleDb.OleDbType.VarWChar, 0, "IDoutlookTicks"), New System.Data.OleDb.OleDbParameter("Category", System.Data.OleDb.OleDbType.LongVarChar, 0, "Category"), New System.Data.OleDb.OleDbParameter("Folder", System.Data.OleDb.OleDbType.LongVarChar, 0, "Folder"), New System.Data.OleDb.OleDbParameter("LastChangeITSCont", System.Data.OleDb.OleDbType.[Date], 16, "LastChangeITSCont"), New System.Data.OleDb.OleDbParameter("LastSyncToExchange", System.Data.OleDb.OleDbType.[Date], 16, "LastSyncToExchange"), New System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarChar, 0, "Wochentage"), New System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.[Integer], 0, "nTenMonat"), New System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarChar, 0, "SerienterminType"), New System.Data.OleDb.OleDbParameter("IDSerientermin", System.Data.OleDb.OleDbType.Guid, 0, "IDSerientermin"), New System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.VarChar, 0, "TagWochenMonat"), New System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.[Integer], 0, "WiedWertJeden"), New System.Data.OleDb.OleDbParameter("EndetAm", System.Data.OleDb.OleDbType.[Date], 16, "EndetAm"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("GanzerTag", System.Data.OleDb.OleDbType.[Boolean], 0, "GanzerTag"), New System.Data.OleDb.OleDbParameter("IsSerientermin", System.Data.OleDb.OleDbType.[Boolean], 0, "IsSerientermin"), New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.[Date], 16, "SerienterminEndetAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPlanAnhang
        '
        Me.daPlanAnhang.DeleteCommand = Me.OleDbCommand1
        Me.daPlanAnhang.InsertCommand = Me.OleDbCommand2
        Me.daPlanAnhang.SelectCommand = Me.OleDbCommand3
        Me.daPlanAnhang.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "planAnhang", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPlan", "IDPlan"), New System.Data.Common.DataColumnMapping("doku", "doku"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("DateiTyp", "DateiTyp")})})
        Me.daPlanAnhang.UpdateCommand = Me.OleDbCommand4
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "DELETE FROM [planAnhang] WHERE (([ID] = ?))"
        Me.OleDbCommand1.Connection = Me.dbConn
        Me.OleDbCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = "INSERT INTO [planAnhang] ([ID], [IDPlan], [doku], [Bezeichnung], [DateiTyp]) VALU" &
    "ES (?, ?, ?, ?, ?)"
        Me.OleDbCommand2.Connection = Me.dbConn
        Me.OleDbCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("doku", System.Data.OleDb.OleDbType.LongVarBinary, 0, "doku"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("DateiTyp", System.Data.OleDb.OleDbType.VarChar, 0, "DateiTyp")})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = "SELECT        ID, IDPlan, doku, Bezeichnung, DateiTyp" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            planAnhang" &
    ""
        Me.OleDbCommand3.Connection = Me.dbConn
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = "UPDATE [planAnhang] SET [ID] = ?, [IDPlan] = ?, [doku] = ?, [Bezeichnung] = ?, [D" &
    "ateiTyp] = ? WHERE (([ID] = ?))"
        Me.OleDbCommand4.Connection = Me.dbConn
        Me.OleDbCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("doku", System.Data.OleDb.OleDbType.LongVarBinary, 0, "doku"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("DateiTyp", System.Data.OleDb.OleDbType.VarChar, 0, "DateiTyp"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPlanObject
        '
        Me.daPlanObject.DeleteCommand = Me.OleDbCommand5
        Me.daPlanObject.InsertCommand = Me.OleDbCommand6
        Me.daPlanObject.SelectCommand = Me.OleDbCommand7
        Me.daPlanObject.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "planObject", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPlan", "IDPlan"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDSelList", "IDSelList"), New System.Data.Common.DataColumnMapping("Status", "Status")})})
        Me.daPlanObject.UpdateCommand = Me.OleDbCommand8
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = "DELETE FROM [planObject] WHERE (([ID] = ?))"
        Me.OleDbCommand5.Connection = Me.dbConn
        Me.OleDbCommand5.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = "INSERT INTO [planObject] ([ID], [IDPlan], [IDObject], [IDSelList], [Status]) VALU" &
    "ES (?, ?, ?, ?, ?)"
        Me.OleDbCommand6.Connection = Me.dbConn
        Me.OleDbCommand6.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDSelList", System.Data.OleDb.OleDbType.Guid, 0, "IDSelList"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status")})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = "SELECT        ID, IDPlan, IDObject, IDSelList, Status" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            planObject" &
    ""
        Me.OleDbCommand7.Connection = Me.dbConn
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = "UPDATE [planObject] SET [ID] = ?, [IDPlan] = ?, [IDObject] = ?, [IDSelList] = ?, " &
    "[Status] = ? WHERE (([ID] = ?))"
        Me.OleDbCommand8.Connection = Me.dbConn
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDSelList", System.Data.OleDb.OleDbType.Guid, 0, "IDSelList"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPlanSearch
        '
        Me.daPlanSearch.SelectCommand = Me.OleDbCommand15
        Me.daPlanSearch.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "plan", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("FälligAm", "FälligAm"), New System.Data.Common.DataColumnMapping("IDArt", "IDArt"), New System.Data.Common.DataColumnMapping("Priorität", "Priorität"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Zusatz", "Zusatz"), New System.Data.Common.DataColumnMapping("MailAn", "MailAn"), New System.Data.Common.DataColumnMapping("MailCC", "MailCC"), New System.Data.Common.DataColumnMapping("html", "html"), New System.Data.Common.DataColumnMapping("Für", "Für"), New System.Data.Common.DataColumnMapping("gesendetAm", "gesendetAm"), New System.Data.Common.DataColumnMapping("remembJN", "remembJN"), New System.Data.Common.DataColumnMapping("remembMinut", "remembMinut"), New System.Data.Common.DataColumnMapping("wichtig", "wichtig"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("KommStatus", "KommStatus"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("deleted", "deleted"), New System.Data.Common.DataColumnMapping("anzObjects", "anzObjects"), New System.Data.Common.DataColumnMapping("design", "design"), New System.Data.Common.DataColumnMapping("MailBcc", "MailBcc"), New System.Data.Common.DataColumnMapping("IDUserAccount", "IDUserAccount"), New System.Data.Common.DataColumnMapping("MailFrom", "MailFrom"), New System.Data.Common.DataColumnMapping("readed", "readed"), New System.Data.Common.DataColumnMapping("empfangenAm", "empfangenAm"), New System.Data.Common.DataColumnMapping("MessageId", "MessageId"), New System.Data.Common.DataColumnMapping("anzAnhänge", "anzAnhänge"), New System.Data.Common.DataColumnMapping("IDPlanMain", "IDPlanMain"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("IsOwner", "IsOwner"), New System.Data.Common.DataColumnMapping("AwaitingResponse", "AwaitingResponse"), New System.Data.Common.DataColumnMapping("IDFolder", "IDFolder"), New System.Data.Common.DataColumnMapping("SendWithPostOfficeBoxForAll", "SendWithPostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("OutlookAPI", "OutlookAPI"), New System.Data.Common.DataColumnMapping("ConversationID", "ConversationID"), New System.Data.Common.DataColumnMapping("IDoutlook", "IDoutlook"), New System.Data.Common.DataColumnMapping("IDoutlookTicks", "IDoutlookTicks"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("LastChangeITSCont", "LastChangeITSCont"), New System.Data.Common.DataColumnMapping("LastSyncToExchange", "LastSyncToExchange"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("PatientName", "PatientName"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("WithPatients", "WithPatients"), New System.Data.Common.DataColumnMapping("DauerStr", "DauerStr"), New System.Data.Common.DataColumnMapping("ObjectStatus", "ObjectStatus")})})
        '
        'OleDbCommand15
        '
        Me.OleDbCommand15.CommandText = resources.GetString("OleDbCommand15.CommandText")
        Me.OleDbCommand15.Connection = Me.dbConn
        '
        'daPlanStatus
        '
        Me.daPlanStatus.DeleteCommand = Me.OleDbCommand13
        Me.daPlanStatus.InsertCommand = Me.OleDbCommand14
        Me.daPlanStatus.SelectCommand = Me.OleDbCommand16
        Me.daPlanStatus.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "planStatus", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPlan", "IDPlan"), New System.Data.Common.DataColumnMapping("MessageId", "MessageId"), New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Usr", "Usr"), New System.Data.Common.DataColumnMapping("Am", "Am"), New System.Data.Common.DataColumnMapping("IsContact", "IsContact")})})
        Me.daPlanStatus.UpdateCommand = Me.OleDbCommand17
        '
        'OleDbCommand13
        '
        Me.OleDbCommand13.CommandText = "DELETE FROM [planStatus] WHERE (([ID] = ?))"
        Me.OleDbCommand13.Connection = Me.dbConn
        Me.OleDbCommand13.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand14
        '
        Me.OleDbCommand14.CommandText = "INSERT INTO [planStatus] ([ID], [IDPlan], [MessageId], [Betreff], [Status], [Usr]" &
    ", [Am], [IsContact]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbCommand14.Connection = Me.dbConn
        Me.OleDbCommand14.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("MessageId", System.Data.OleDb.OleDbType.VarChar, 0, "MessageId"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("Usr", System.Data.OleDb.OleDbType.VarChar, 0, "Usr"), New System.Data.OleDb.OleDbParameter("Am", System.Data.OleDb.OleDbType.[Date], 16, "Am"), New System.Data.OleDb.OleDbParameter("IsContact", System.Data.OleDb.OleDbType.[Boolean], 0, "IsContact")})
        '
        'OleDbCommand16
        '
        Me.OleDbCommand16.CommandText = "SELECT        ID, IDPlan, MessageId, Betreff, Status, Usr, Am, IsContact" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM   " &
    "         planStatus"
        Me.OleDbCommand16.Connection = Me.dbConn
        '
        'OleDbCommand17
        '
        Me.OleDbCommand17.CommandText = "UPDATE [planStatus] SET [ID] = ?, [IDPlan] = ?, [MessageId] = ?, [Betreff] = ?, [" &
    "Status] = ?, [Usr] = ?, [Am] = ?, [IsContact] = ? WHERE (([ID] = ?))"
        Me.OleDbCommand17.Connection = Me.dbConn
        Me.OleDbCommand17.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPlan"), New System.Data.OleDb.OleDbParameter("MessageId", System.Data.OleDb.OleDbType.VarChar, 0, "MessageId"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("Usr", System.Data.OleDb.OleDbType.VarChar, 0, "Usr"), New System.Data.OleDb.OleDbParameter("Am", System.Data.OleDb.OleDbType.[Date], 16, "Am"), New System.Data.OleDb.OleDbParameter("IsContact", System.Data.OleDb.OleDbType.[Boolean], 0, "IsContact"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPlanSearchPatients
        '
        Me.daPlanSearchPatients.SelectCommand = Me.OleDbCommand9
        Me.daPlanSearchPatients.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Patient", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("FälligAm", "FälligAm"), New System.Data.Common.DataColumnMapping("IDArt", "IDArt"), New System.Data.Common.DataColumnMapping("Priorität", "Priorität"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Zusatz", "Zusatz"), New System.Data.Common.DataColumnMapping("MailAn", "MailAn"), New System.Data.Common.DataColumnMapping("MailCC", "MailCC"), New System.Data.Common.DataColumnMapping("html", "html"), New System.Data.Common.DataColumnMapping("Für", "Für"), New System.Data.Common.DataColumnMapping("gesendetAm", "gesendetAm"), New System.Data.Common.DataColumnMapping("remembJN", "remembJN"), New System.Data.Common.DataColumnMapping("remembMinut", "remembMinut"), New System.Data.Common.DataColumnMapping("wichtig", "wichtig"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("KommStatus", "KommStatus"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("deleted", "deleted"), New System.Data.Common.DataColumnMapping("anzObjects", "anzObjects"), New System.Data.Common.DataColumnMapping("design", "design"), New System.Data.Common.DataColumnMapping("MailBcc", "MailBcc"), New System.Data.Common.DataColumnMapping("IDUserAccount", "IDUserAccount"), New System.Data.Common.DataColumnMapping("MailFrom", "MailFrom"), New System.Data.Common.DataColumnMapping("readed", "readed"), New System.Data.Common.DataColumnMapping("empfangenAm", "empfangenAm"), New System.Data.Common.DataColumnMapping("MessageId", "MessageId"), New System.Data.Common.DataColumnMapping("anzAnhänge", "anzAnhänge"), New System.Data.Common.DataColumnMapping("IDPlanMain", "IDPlanMain"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("IsOwner", "IsOwner"), New System.Data.Common.DataColumnMapping("AwaitingResponse", "AwaitingResponse"), New System.Data.Common.DataColumnMapping("IDFolder", "IDFolder"), New System.Data.Common.DataColumnMapping("SendWithPostOfficeBoxForAll", "SendWithPostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("OutlookAPI", "OutlookAPI"), New System.Data.Common.DataColumnMapping("ConversationID", "ConversationID"), New System.Data.Common.DataColumnMapping("IDoutlook", "IDoutlook"), New System.Data.Common.DataColumnMapping("IDoutlookTicks", "IDoutlookTicks"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("LastChangeITSCont", "LastChangeITSCont"), New System.Data.Common.DataColumnMapping("LastSyncToExchange", "LastSyncToExchange"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("PatientName", "PatientName"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("WithPatients", "WithPatients"), New System.Data.Common.DataColumnMapping("DauerStr", "DauerStr"), New System.Data.Common.DataColumnMapping("ObjectStatus", "ObjectStatus")})})
        '
        'OleDbCommand9
        '
        Me.OleDbCommand9.CommandText = resources.GetString("OleDbCommand9.CommandText")
        Me.OleDbCommand9.Connection = Me.dbConn
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = resources.GetString("OleDbSelectCommand2.CommandText")
        Me.OleDbSelectCommand2.Connection = Me.dbConn
        '
        'daPlanSearchPatientsAll
        '
        Me.daPlanSearchPatientsAll.SelectCommand = Me.OleDbSelectCommand2
        Me.daPlanSearchPatientsAll.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Patient", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("FälligAm", "FälligAm"), New System.Data.Common.DataColumnMapping("IDArt", "IDArt"), New System.Data.Common.DataColumnMapping("Priorität", "Priorität"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Zusatz", "Zusatz"), New System.Data.Common.DataColumnMapping("MailAn", "MailAn"), New System.Data.Common.DataColumnMapping("MailCC", "MailCC"), New System.Data.Common.DataColumnMapping("html", "html"), New System.Data.Common.DataColumnMapping("Für", "Für"), New System.Data.Common.DataColumnMapping("gesendetAm", "gesendetAm"), New System.Data.Common.DataColumnMapping("remembJN", "remembJN"), New System.Data.Common.DataColumnMapping("remembMinut", "remembMinut"), New System.Data.Common.DataColumnMapping("wichtig", "wichtig"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("KommStatus", "KommStatus"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("deleted", "deleted"), New System.Data.Common.DataColumnMapping("anzObjects", "anzObjects"), New System.Data.Common.DataColumnMapping("design", "design"), New System.Data.Common.DataColumnMapping("MailBcc", "MailBcc"), New System.Data.Common.DataColumnMapping("IDUserAccount", "IDUserAccount"), New System.Data.Common.DataColumnMapping("MailFrom", "MailFrom"), New System.Data.Common.DataColumnMapping("readed", "readed"), New System.Data.Common.DataColumnMapping("empfangenAm", "empfangenAm"), New System.Data.Common.DataColumnMapping("MessageId", "MessageId"), New System.Data.Common.DataColumnMapping("anzAnhänge", "anzAnhänge"), New System.Data.Common.DataColumnMapping("IDPlanMain", "IDPlanMain"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("IsOwner", "IsOwner"), New System.Data.Common.DataColumnMapping("AwaitingResponse", "AwaitingResponse"), New System.Data.Common.DataColumnMapping("IDFolder", "IDFolder"), New System.Data.Common.DataColumnMapping("SendWithPostOfficeBoxForAll", "SendWithPostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("OutlookAPI", "OutlookAPI"), New System.Data.Common.DataColumnMapping("ConversationID", "ConversationID"), New System.Data.Common.DataColumnMapping("IDoutlook", "IDoutlook"), New System.Data.Common.DataColumnMapping("IDoutlookTicks", "IDoutlookTicks"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("LastChangeITSCont", "LastChangeITSCont"), New System.Data.Common.DataColumnMapping("LastSyncToExchange", "LastSyncToExchange"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("PatientName", "PatientName"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("WithPatients", "WithPatients"), New System.Data.Common.DataColumnMapping("DauerStr", "DauerStr"), New System.Data.Common.DataColumnMapping("ObjectStatus", "ObjectStatus")})})
        '
        'daSearchPlanBereich
        '
        Me.daSearchPlanBereich.SelectCommand = Me.OleDbCommand12
        Me.daSearchPlanBereich.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "planBereich", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("lstAbteilungen", "lstAbteilungen"), New System.Data.Common.DataColumnMapping("lstBereiche", "lstBereiche"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("CreatedFrom", "CreatedFrom"), New System.Data.Common.DataColumnMapping("CreatedAt", "CreatedAt"), New System.Data.Common.DataColumnMapping("LastChangeFrom", "LastChangeFrom"), New System.Data.Common.DataColumnMapping("LastChangeAt", "LastChangeAt"), New System.Data.Common.DataColumnMapping("lstBerufsgruppen", "lstBerufsgruppen")})})
        '
        'OleDbCommand12
        '
        Me.OleDbCommand12.CommandText = resources.GetString("OleDbCommand12.CommandText")
        Me.OleDbCommand12.Connection = Me.dbConn
        '
        'daPlanBereich
        '
        Me.daPlanBereich.DeleteCommand = Me.OleDbCommand10
        Me.daPlanBereich.InsertCommand = Me.OleDbCommand11
        Me.daPlanBereich.SelectCommand = Me.OleDbCommand18
        Me.daPlanBereich.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "planBereich", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("BeginntAm", "BeginntAm"), New System.Data.Common.DataColumnMapping("EndetAm", "EndetAm"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("lstAbteilungen", "lstAbteilungen"), New System.Data.Common.DataColumnMapping("lstBereiche", "lstBereiche"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Category", "Category"), New System.Data.Common.DataColumnMapping("Folder", "Folder"), New System.Data.Common.DataColumnMapping("Teilnehmer", "Teilnehmer"), New System.Data.Common.DataColumnMapping("IDSerientermin", "IDSerientermin"), New System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"), New System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"), New System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"), New System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"), New System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("GanzerTag", "GanzerTag"), New System.Data.Common.DataColumnMapping("IsSerientermin", "IsSerientermin"), New System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("CreatedFrom", "CreatedFrom"), New System.Data.Common.DataColumnMapping("CreatedAt", "CreatedAt"), New System.Data.Common.DataColumnMapping("LastChangeFrom", "LastChangeFrom"), New System.Data.Common.DataColumnMapping("LastChangeAt", "LastChangeAt"), New System.Data.Common.DataColumnMapping("lstBerufsgruppen", "lstBerufsgruppen"), New System.Data.Common.DataColumnMapping("IDPlanMain", "IDPlanMain"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})})
        Me.daPlanBereich.UpdateCommand = Me.OleDbCommand19
        '
        'OleDbCommand10
        '
        Me.OleDbCommand10.CommandText = "DELETE FROM [planBereich] WHERE (([ID] = ?))"
        Me.OleDbCommand10.Connection = Me.dbConn
        Me.OleDbCommand10.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand11
        '
        Me.OleDbCommand11.CommandText = resources.GetString("OleDbCommand11.CommandText")
        Me.OleDbCommand11.Connection = Me.dbConn
        Me.OleDbCommand11.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarWChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BeginntAm"), New System.Data.OleDb.OleDbParameter("EndetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndetAm"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("lstAbteilungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstAbteilungen"), New System.Data.OleDb.OleDbParameter("lstBereiche", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstBereiche"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("Category", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Category"), New System.Data.OleDb.OleDbParameter("Folder", System.Data.OleDb.OleDbType.VarWChar, 0, "Folder"), New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Teilnehmer"), New System.Data.OleDb.OleDbParameter("IDSerientermin", System.Data.OleDb.OleDbType.Guid, 0, "IDSerientermin"), New System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.LongVarWChar, 0, "TagWochenMonat"), New System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.[Integer], 0, "WiedWertJeden"), New System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarWChar, 0, "Wochentage"), New System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.[Integer], 0, "nTenMonat"), New System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarWChar, 0, "SerienterminType"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("GanzerTag", System.Data.OleDb.OleDbType.[Boolean], 0, "GanzerTag"), New System.Data.OleDb.OleDbParameter("IsSerientermin", System.Data.OleDb.OleDbType.[Boolean], 0, "IsSerientermin"), New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SerienterminEndetAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("CreatedFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedFrom"), New System.Data.OleDb.OleDbParameter("CreatedAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "CreatedAt"), New System.Data.OleDb.OleDbParameter("LastChangeFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "LastChangeFrom"), New System.Data.OleDb.OleDbParameter("LastChangeAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LastChangeAt"), New System.Data.OleDb.OleDbParameter("lstBerufsgruppen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstBerufsgruppen"), New System.Data.OleDb.OleDbParameter("IDPlanMain", System.Data.OleDb.OleDbType.Guid, 0, "IDPlanMain"), New System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"), New System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich")})
        '
        'OleDbCommand18
        '
        Me.OleDbCommand18.CommandText = resources.GetString("OleDbCommand18.CommandText")
        Me.OleDbCommand18.Connection = Me.dbConn
        '
        'OleDbCommand19
        '
        Me.OleDbCommand19.CommandText = resources.GetString("OleDbCommand19.CommandText")
        Me.OleDbCommand19.Connection = Me.dbConn
        Me.OleDbCommand19.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarWChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BeginntAm"), New System.Data.OleDb.OleDbParameter("EndetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndetAm"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("lstAbteilungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstAbteilungen"), New System.Data.OleDb.OleDbParameter("lstBereiche", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstBereiche"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"), New System.Data.OleDb.OleDbParameter("Category", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Category"), New System.Data.OleDb.OleDbParameter("Folder", System.Data.OleDb.OleDbType.VarWChar, 0, "Folder"), New System.Data.OleDb.OleDbParameter("Teilnehmer", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Teilnehmer"), New System.Data.OleDb.OleDbParameter("IDSerientermin", System.Data.OleDb.OleDbType.Guid, 0, "IDSerientermin"), New System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.LongVarWChar, 0, "TagWochenMonat"), New System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.[Integer], 0, "WiedWertJeden"), New System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarWChar, 0, "Wochentage"), New System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.[Integer], 0, "nTenMonat"), New System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarWChar, 0, "SerienterminType"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("GanzerTag", System.Data.OleDb.OleDbType.[Boolean], 0, "GanzerTag"), New System.Data.OleDb.OleDbParameter("IsSerientermin", System.Data.OleDb.OleDbType.[Boolean], 0, "IsSerientermin"), New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SerienterminEndetAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("CreatedFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedFrom"), New System.Data.OleDb.OleDbParameter("CreatedAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "CreatedAt"), New System.Data.OleDb.OleDbParameter("LastChangeFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "LastChangeFrom"), New System.Data.OleDb.OleDbParameter("LastChangeAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LastChangeAt"), New System.Data.OleDb.OleDbParameter("lstBerufsgruppen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstBerufsgruppen"), New System.Data.OleDb.OleDbParameter("IDPlanMain", System.Data.OleDb.OleDbType.Guid, 0, "IDPlanMain"), New System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"), New System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Friend WithEvents dbConn As OleDb.OleDbConnection
    Public WithEvents daPlan As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As OleDb.OleDbCommand
    Public WithEvents daPlanAnhang As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand4 As OleDb.OleDbCommand
    Public WithEvents daPlanObject As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand5 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand6 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand7 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand8 As OleDb.OleDbCommand
    Public WithEvents daPlanSearch As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand15 As OleDb.OleDbCommand
    Public WithEvents daPlanStatus As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand13 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand14 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand16 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand17 As OleDb.OleDbCommand
    Public WithEvents daPlanSearchPatients As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand9 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand2 As OleDb.OleDbCommand
    Public WithEvents daPlanSearchPatientsAll As OleDb.OleDbDataAdapter
    Public WithEvents daSearchPlanBereich As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand12 As OleDb.OleDbCommand
    Public WithEvents daPlanBereich As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand10 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand11 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand18 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand19 As OleDb.OleDbCommand
End Class
