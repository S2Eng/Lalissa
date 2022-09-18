Partial Class sqlAddIns
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlAddIns))
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.daAddIns = New System.Data.SqlClient.SqlDataAdapter()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT        ID, Activated, AddInName, Dll, Type, Description, [Group], Place, A" & _
    "ctivatedAt, ActivatedFrom" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.AddIns"
        Me.SqlSelectCommand1.Connection = Me.dbConn
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Data Source=s2sty010;Initial Catalog=QS2_DEV2;Integrated Security=True"
        Me.dbConn.FireInfoMessageEventOnUserErrors = False
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Connection = Me.dbConn
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"), New System.Data.SqlClient.SqlParameter("@Activated", System.Data.SqlDbType.Bit, 0, "Activated"), New System.Data.SqlClient.SqlParameter("@AddInName", System.Data.SqlDbType.NVarChar, 0, "AddInName"), New System.Data.SqlClient.SqlParameter("@Dll", System.Data.SqlDbType.NVarChar, 0, "Dll"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@Group", System.Data.SqlDbType.NVarChar, 0, "Group"), New System.Data.SqlClient.SqlParameter("@Place", System.Data.SqlDbType.NVarChar, 0, "Place"), New System.Data.SqlClient.SqlParameter("@ActivatedAt", System.Data.SqlDbType.DateTime, 0, "ActivatedAt"), New System.Data.SqlClient.SqlParameter("@ActivatedFrom", System.Data.SqlDbType.NVarChar, 0, "ActivatedFrom")})
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.dbConn
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"), New System.Data.SqlClient.SqlParameter("@Activated", System.Data.SqlDbType.Bit, 0, "Activated"), New System.Data.SqlClient.SqlParameter("@AddInName", System.Data.SqlDbType.NVarChar, 0, "AddInName"), New System.Data.SqlClient.SqlParameter("@Dll", System.Data.SqlDbType.NVarChar, 0, "Dll"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@Group", System.Data.SqlDbType.NVarChar, 0, "Group"), New System.Data.SqlClient.SqlParameter("@Place", System.Data.SqlDbType.NVarChar, 0, "Place"), New System.Data.SqlClient.SqlParameter("@ActivatedAt", System.Data.SqlDbType.DateTime, 0, "ActivatedAt"), New System.Data.SqlClient.SqlParameter("@ActivatedFrom", System.Data.SqlDbType.NVarChar, 0, "ActivatedFrom"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM [qs2].[AddIns] WHERE (([ID] = @Original_ID))"
        Me.SqlDeleteCommand1.Connection = Me.dbConn
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAddIns
        '
        Me.daAddIns.DeleteCommand = Me.SqlDeleteCommand1
        Me.daAddIns.InsertCommand = Me.SqlInsertCommand1
        Me.daAddIns.SelectCommand = Me.SqlSelectCommand1
        Me.daAddIns.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AddIns", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Activated", "Activated"), New System.Data.Common.DataColumnMapping("AddInName", "AddInName"), New System.Data.Common.DataColumnMapping("Dll", "Dll"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("Group", "Group"), New System.Data.Common.DataColumnMapping("Place", "Place"), New System.Data.Common.DataColumnMapping("ActivatedAt", "ActivatedAt"), New System.Data.Common.DataColumnMapping("ActivatedFrom", "ActivatedFrom")})})
        Me.daAddIns.UpdateCommand = Me.SqlUpdateCommand1

    End Sub
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Public WithEvents daAddIns As System.Data.SqlClient.SqlDataAdapter

End Class
