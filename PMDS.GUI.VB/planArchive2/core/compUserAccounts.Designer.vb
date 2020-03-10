Partial Class compUserAccounts
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

        Me.daSelUserAccounts = Me.daUserAccounts.SelectCommand.CommandText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compUserAccounts))
        Me.daUserAccounts = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        '
        'daUserAccounts
        '
        Me.daUserAccounts.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daUserAccounts.InsertCommand = Me.OleDbInsertCommand1
        Me.daUserAccounts.SelectCommand = Me.OleDbSelectCommand1
        Me.daUserAccounts.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblUserAccounts", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Usr", "Usr"), New System.Data.Common.DataColumnMapping("typ", "typ"), New System.Data.Common.DataColumnMapping("Name", "Name"), New System.Data.Common.DataColumnMapping("AdrFrom", "AdrFrom"), New System.Data.Common.DataColumnMapping("AdrTo", "AdrTo"), New System.Data.Common.DataColumnMapping("Server", "Server"), New System.Data.Common.DataColumnMapping("UsrAuthentication", "UsrAuthentication"), New System.Data.Common.DataColumnMapping("PwdAuthentication", "PwdAuthentication"), New System.Data.Common.DataColumnMapping("Port", "Port"), New System.Data.Common.DataColumnMapping("SSL", "SSL"), New System.Data.Common.DataColumnMapping("IDAccount", "IDAccount"), New System.Data.Common.DataColumnMapping("lastReceive", "lastReceive"), New System.Data.Common.DataColumnMapping("PostOfficeBoxForAll", "PostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("PreferPostOfficeBoxForAll", "PreferPostOfficeBoxForAll"), New System.Data.Common.DataColumnMapping("OutlookWebAPI", "OutlookWebAPI")})})
        Me.daUserAccounts.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [tblUserAccounts] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=ITSContDev"
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Usr", System.Data.OleDb.OleDbType.VarWChar, 0, "Usr"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarWChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 0, "Name"), New System.Data.OleDb.OleDbParameter("AdrFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "AdrFrom"), New System.Data.OleDb.OleDbParameter("AdrTo", System.Data.OleDb.OleDbType.VarWChar, 0, "AdrTo"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarWChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("UsrAuthentication", System.Data.OleDb.OleDbType.VarWChar, 0, "UsrAuthentication"), New System.Data.OleDb.OleDbParameter("PwdAuthentication", System.Data.OleDb.OleDbType.VarWChar, 0, "PwdAuthentication"), New System.Data.OleDb.OleDbParameter("Port", System.Data.OleDb.OleDbType.VarWChar, 0, "Port"), New System.Data.OleDb.OleDbParameter("SSL", System.Data.OleDb.OleDbType.[Boolean], 0, "SSL"), New System.Data.OleDb.OleDbParameter("IDAccount", System.Data.OleDb.OleDbType.Guid, 0, "IDAccount"), New System.Data.OleDb.OleDbParameter("lastReceive", System.Data.OleDb.OleDbType.Date, 16, "lastReceive"), New System.Data.OleDb.OleDbParameter("PostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "PostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("PreferPostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "PreferPostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("OutlookWebAPI", System.Data.OleDb.OleDbType.[Boolean], 0, "OutlookWebAPI")})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = resources.GetString("OleDbSelectCommand1.CommandText")
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = resources.GetString("OleDbUpdateCommand1.CommandText")
        Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Usr", System.Data.OleDb.OleDbType.VarWChar, 0, "Usr"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarWChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 0, "Name"), New System.Data.OleDb.OleDbParameter("AdrFrom", System.Data.OleDb.OleDbType.VarWChar, 0, "AdrFrom"), New System.Data.OleDb.OleDbParameter("AdrTo", System.Data.OleDb.OleDbType.VarWChar, 0, "AdrTo"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarWChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("UsrAuthentication", System.Data.OleDb.OleDbType.VarWChar, 0, "UsrAuthentication"), New System.Data.OleDb.OleDbParameter("PwdAuthentication", System.Data.OleDb.OleDbType.VarWChar, 0, "PwdAuthentication"), New System.Data.OleDb.OleDbParameter("Port", System.Data.OleDb.OleDbType.VarWChar, 0, "Port"), New System.Data.OleDb.OleDbParameter("SSL", System.Data.OleDb.OleDbType.[Boolean], 0, "SSL"), New System.Data.OleDb.OleDbParameter("IDAccount", System.Data.OleDb.OleDbType.Guid, 0, "IDAccount"), New System.Data.OleDb.OleDbParameter("lastReceive", System.Data.OleDb.OleDbType.Date, 16, "lastReceive"), New System.Data.OleDb.OleDbParameter("PostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "PostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("PreferPostOfficeBoxForAll", System.Data.OleDb.OleDbType.[Boolean], 0, "PreferPostOfficeBoxForAll"), New System.Data.OleDb.OleDbParameter("OutlookWebAPI", System.Data.OleDb.OleDbType.[Boolean], 0, "OutlookWebAPI"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Public WithEvents daUserAccounts As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbConnection1 As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As OleDb.OleDbCommand
End Class
