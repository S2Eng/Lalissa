Partial Class daGibodat
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand
        Me.daPatienten = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand
        Me.daAngehoerige = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.daSyncPMDS = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand = New System.Data.OleDb.OleDbCommand
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=GiboDat"

        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = "SELECT     vPatienten_PMDS.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         vPatienten_PMDS"
        Me.OleDbSelectCommand2.Connection = Me.OleDbConnection1
        '
        'daPatienten
        '
        Me.daPatienten.SelectCommand = Me.OleDbSelectCommand2
        Me.daPatienten.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "vPatienten_PMDS", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KlientID", "KlientID"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("AkadGrad", "AkadGrad"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("KlientenNr", "KlientenNr"), New System.Data.Common.DataColumnMapping("ZimmerNr", "ZimmerNr"), New System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"), New System.Data.Common.DataColumnMapping("Geschlecht", "Geschlecht"), New System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"), New System.Data.Common.DataColumnMapping("Konfession", "Konfession"), New System.Data.Common.DataColumnMapping("Geburtsname", "Geburtsname"), New System.Data.Common.DataColumnMapping("Geburtsort", "Geburtsort"), New System.Data.Common.DataColumnMapping("Staatsbürgerschaft", "Staatsbürgerschaft"), New System.Data.Common.DataColumnMapping("Namenstag", "Namenstag"), New System.Data.Common.DataColumnMapping("Foto", "Foto"), New System.Data.Common.DataColumnMapping("Kosename", "Kosename"), New System.Data.Common.DataColumnMapping("Aufnahmedatum", "Aufnahmedatum"), New System.Data.Common.DataColumnMapping("Krankenkasse", "Krankenkasse"), New System.Data.Common.DataColumnMapping("SVNR", "SVNR"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("PLZ", "PLZ"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Land", "Land")})})
        '
        'OleDbSelectCommand3
        '
        Me.OleDbSelectCommand3.CommandText = "SELECT     vAngehörige_PMDS.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         vAngehörige_PMDS"
        Me.OleDbSelectCommand3.Connection = Me.OleDbConnection1
        '
        'daAngehoerige
        '
        Me.daAngehoerige.SelectCommand = Me.OleDbSelectCommand3
        Me.daAngehoerige.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "vAngehörige_PMDS", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KlientID", "KlientID"), New System.Data.Common.DataColumnMapping("KontaktpersonID", "KontaktpersonID"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("AkadGrad", "AkadGrad"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("VerwandVerh", "VerwandVerh"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("PLZ", "PLZ"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Land", "Land"), New System.Data.Common.DataColumnMapping("Telefon", "Telefon"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("Mobiltelefon", "Mobiltelefon"), New System.Data.Common.DataColumnMapping("Email", "Email")})})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT     LastUpdate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        tSync_PMDS"
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO [tSync_PMDS] ([LastUpdate]) VALUES (?)"
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("LastUpdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LastUpdate")})
        '
        'daSyncPMDS
        '
        Me.daSyncPMDS.DeleteCommand = Me.OleDbDeleteCommand
        Me.daSyncPMDS.InsertCommand = Me.OleDbInsertCommand1
        Me.daSyncPMDS.SelectCommand = Me.OleDbSelectCommand1
        Me.daSyncPMDS.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tSync_PMDS", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("LastUpdate", "LastUpdate")})})
        Me.daSyncPMDS.UpdateCommand = Me.OleDbUpdateCommand
        '
        'OleDbDeleteCommand
        '
        Me.OleDbDeleteCommand.CommandText = "DELETE FROM [tSync_PMDS] WHERE (([LastUpdate] = ?))"
        Me.OleDbDeleteCommand.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_LastUpdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastUpdate", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbUpdateCommand
        '
        Me.OleDbUpdateCommand.CommandText = "UPDATE [tSync_PMDS] SET [LastUpdate] = ? WHERE (([LastUpdate] = ?))"
        Me.OleDbUpdateCommand.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("LastUpdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LastUpdate"), New System.Data.OleDb.OleDbParameter("Original_LastUpdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastUpdate", System.Data.DataRowVersion.Original, Nothing)})

    End Sub
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
    Public WithEvents daPatienten As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand3 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAngehoerige As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Public WithEvents daSyncPMDS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand As System.Data.OleDb.OleDbCommand

End Class
