Partial Class sqlProtocoll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlProtocoll))
        Me.daProtocol = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        '
        'daProtocol
        '
        Me.daProtocol.DeleteCommand = Me.SqlDeleteCommand1
        Me.daProtocol.InsertCommand = Me.SqlInsertCommand1
        Me.daProtocol.SelectCommand = Me.SqlSelectCommand1
        Me.daProtocol.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Protocol", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("Protocol", "Protocol"), New System.Data.Common.DataColumnMapping("Info", "Info"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("IDGuidObject", "IDGuidObject"), New System.Data.Common.DataColumnMapping("IDStay", "IDStay"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("IDStayApplication", "IDStayApplication"), New System.Data.Common.DataColumnMapping("sKey", "sKey"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("User", "User"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("Sql", "Sql"), New System.Data.Common.DataColumnMapping("InfoFile", "InfoFile"), New System.Data.Common.DataColumnMapping("Db", "Db"), New System.Data.Common.DataColumnMapping("CreatedDay", "CreatedDay"), New System.Data.Common.DataColumnMapping("progress", "progress"), New System.Data.Common.DataColumnMapping("Patient", "Patient"), New System.Data.Common.DataColumnMapping("MedRecNr", "MedRecNr")})})
        Me.daProtocol.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM [qs2].[Protocol] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlDeleteCommand1.Connection = Me.dbConn
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Data Source=stysrv02v\sql2008r2;Initial Catalog=QS2_DEV;Integrated Security=True"
        Me.dbConn.FireInfoMessageEventOnUserErrors = False
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Connection = Me.dbConn
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@Protocol", System.Data.SqlDbType.NVarChar, 0, "Protocol"), New System.Data.SqlClient.SqlParameter("@Info", System.Data.SqlDbType.NVarChar, 0, "Info"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@IDGuidObject", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuidObject"), New System.Data.SqlClient.SqlParameter("@IDStay", System.Data.SqlDbType.Int, 0, "IDStay"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDStayApplication", System.Data.SqlDbType.NVarChar, 0, "IDStayApplication"), New System.Data.SqlClient.SqlParameter("@sKey", System.Data.SqlDbType.NVarChar, 0, "sKey"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@User", System.Data.SqlDbType.NVarChar, 0, "User"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@Sql", System.Data.SqlDbType.NVarChar, 0, "Sql"), New System.Data.SqlClient.SqlParameter("@InfoFile", System.Data.SqlDbType.NVarChar, 0, "InfoFile"), New System.Data.SqlClient.SqlParameter("@Db", System.Data.SqlDbType.NVarChar, 0, "Db"), New System.Data.SqlClient.SqlParameter("@CreatedDay", System.Data.SqlDbType.DateTime, 0, "CreatedDay"), New System.Data.SqlClient.SqlParameter("@progress", System.Data.SqlDbType.NVarChar, 0, "progress"), New System.Data.SqlClient.SqlParameter("@Patient", System.Data.SqlDbType.NVarChar, 0, "Patient"), New System.Data.SqlClient.SqlParameter("@MedRecNr", System.Data.SqlDbType.NVarChar, 0, "MedRecNr")})
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText")
        Me.SqlSelectCommand1.Connection = Me.dbConn
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.dbConn
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@Protocol", System.Data.SqlDbType.NVarChar, 0, "Protocol"), New System.Data.SqlClient.SqlParameter("@Info", System.Data.SqlDbType.NVarChar, 0, "Info"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@IDGuidObject", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuidObject"), New System.Data.SqlClient.SqlParameter("@IDStay", System.Data.SqlDbType.Int, 0, "IDStay"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDStayApplication", System.Data.SqlDbType.NVarChar, 0, "IDStayApplication"), New System.Data.SqlClient.SqlParameter("@sKey", System.Data.SqlDbType.NVarChar, 0, "sKey"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@User", System.Data.SqlDbType.NVarChar, 0, "User"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@Sql", System.Data.SqlDbType.NVarChar, 0, "Sql"), New System.Data.SqlClient.SqlParameter("@InfoFile", System.Data.SqlDbType.NVarChar, 0, "InfoFile"), New System.Data.SqlClient.SqlParameter("@Db", System.Data.SqlDbType.NVarChar, 0, "Db"), New System.Data.SqlClient.SqlParameter("@CreatedDay", System.Data.SqlDbType.DateTime, 0, "CreatedDay"), New System.Data.SqlClient.SqlParameter("@progress", System.Data.SqlDbType.NVarChar, 0, "progress"), New System.Data.SqlClient.SqlParameter("@Patient", System.Data.SqlDbType.NVarChar, 0, "Patient"), New System.Data.SqlClient.SqlParameter("@MedRecNr", System.Data.SqlDbType.NVarChar, 0, "MedRecNr"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})

    End Sub
    Public WithEvents daProtocol As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection

End Class
