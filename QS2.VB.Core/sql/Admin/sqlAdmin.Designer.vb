Partial Class sqlAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlAdmin))
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.daSelListEntrys = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand5 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand6 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand7 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand8 = New System.Data.SqlClient.SqlCommand()
        Me.daSelListGroup = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand4 = New System.Data.SqlClient.SqlCommand()
        Me.daSelListEntrysObj = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand13 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand14 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand15 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand16 = New System.Data.SqlClient.SqlCommand()
        Me.daAdjust = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.daCriteria = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand9 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand10 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand11 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand12 = New System.Data.SqlClient.SqlCommand()
        Me.daCriteriaOpt = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand17 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand18 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand19 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand20 = New System.Data.SqlClient.SqlCommand()
        Me.davListEntriesWithGroup = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand27 = New System.Data.SqlClient.SqlCommand()
        Me.daStayAdditions = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand25 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand26 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand28 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand29 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.daRelationship = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlInsertCommand = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand = New System.Data.SqlClient.SqlCommand()
        Me.daQueriesDef = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand21 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand22 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand23 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand24 = New System.Data.SqlClient.SqlCommand()
        Me.daQueryJoinsTemp = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand30 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand31 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand32 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand33 = New System.Data.SqlClient.SqlCommand()
        Me.daSideLogic = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand34 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand35 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand36 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand37 = New System.Data.SqlClient.SqlCommand()
        Me.daMaxSelListID = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand40 = New System.Data.SqlClient.SqlCommand()
        Me.daMaxSelListGroupID = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand38 = New System.Data.SqlClient.SqlCommand()
        Me.davSelListEntriesObj = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand42 = New System.Data.SqlClient.SqlCommand()
        Me.daGetAllUsersWithRoles = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand39 = New System.Data.SqlClient.SqlCommand()
        Me.daGetButtonsForUser = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand41 = New System.Data.SqlClient.SqlCommand()
        Me.daGetCriteriasForUser = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand43 = New System.Data.SqlClient.SqlCommand()
        Me.daGetAllUsersWithRights = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand44 = New System.Data.SqlClient.SqlCommand()
        Me.daGetChaptersAlwaysEditableAllUsers = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand45 = New System.Data.SqlClient.SqlCommand()
        Me.daSelListEntriesSort = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand46 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand47 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand48 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand49 = New System.Data.SqlClient.SqlCommand()
        Me.daGetCriteriasUserForUser = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand50 = New System.Data.SqlClient.SqlCommand()
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Data Source=192.168.80.210;Initial Catalog=QS2_DEV;Persist Security Info=True;Use" &
    "r ID=hl;Password=NiwQs21+!"
        Me.dbConn.FireInfoMessageEventOnUserErrors = False
        '
        'daSelListEntrys
        '
        Me.daSelListEntrys.DeleteCommand = Me.SqlCommand5
        Me.daSelListEntrys.InsertCommand = Me.SqlCommand6
        Me.daSelListEntrys.SelectCommand = Me.SqlCommand7
        Me.daSelListEntrys.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListEntries", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("IDRessource", "IDRessource"), New System.Data.Common.DataColumnMapping("IDOwnInt", "IDOwnInt"), New System.Data.Common.DataColumnMapping("IDOwnStr", "IDOwnStr"), New System.Data.Common.DataColumnMapping("sort", "sort"), New System.Data.Common.DataColumnMapping("IsMain", "IsMain"), New System.Data.Common.DataColumnMapping("TypeQry", "TypeQry"), New System.Data.Common.DataColumnMapping("TypeStr", "TypeStr"), New System.Data.Common.DataColumnMapping("Table", "Table"), New System.Data.Common.DataColumnMapping("FldShortColumn", "FldShortColumn"), New System.Data.Common.DataColumnMapping("picture", "picture"), New System.Data.Common.DataColumnMapping("IDGroup", "IDGroup"), New System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser"), New System.Data.Common.DataColumnMapping("Private", "Private"), New System.Data.Common.DataColumnMapping("VersionNrFrom", "VersionNrFrom"), New System.Data.Common.DataColumnMapping("VersionNrTo", "VersionNrTo"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("Sql", "Sql"), New System.Data.Common.DataColumnMapping("UIType", "UIType"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("Extern", "Extern"), New System.Data.Common.DataColumnMapping("SubQuery", "SubQuery"), New System.Data.Common.DataColumnMapping("LicenseKey", "LicenseKey"), New System.Data.Common.DataColumnMapping("Published", "Published"), New System.Data.Common.DataColumnMapping("ForServices", "ForServices")})})
        Me.daSelListEntrys.UpdateCommand = Me.SqlCommand8
        '
        'SqlCommand5
        '
        Me.SqlCommand5.CommandText = "DELETE FROM [qs2].[tblSelListEntries] WHERE (([ID] = @Original_ID))"
        Me.SqlCommand5.Connection = Me.dbConn
        Me.SqlCommand5.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand6
        '
        Me.SqlCommand6.CommandText = resources.GetString("SqlCommand6.CommandText")
        Me.SqlCommand6.Connection = Me.dbConn
        Me.SqlCommand6.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDRessource", System.Data.SqlDbType.NVarChar, 0, "IDRessource"), New System.Data.SqlClient.SqlParameter("@IDOwnInt", System.Data.SqlDbType.Int, 0, "IDOwnInt"), New System.Data.SqlClient.SqlParameter("@IDOwnStr", System.Data.SqlDbType.NVarChar, 0, "IDOwnStr"), New System.Data.SqlClient.SqlParameter("@sort", System.Data.SqlDbType.Int, 0, "sort"), New System.Data.SqlClient.SqlParameter("@IsMain", System.Data.SqlDbType.Bit, 0, "IsMain"), New System.Data.SqlClient.SqlParameter("@TypeQry", System.Data.SqlDbType.NVarChar, 0, "TypeQry"), New System.Data.SqlClient.SqlParameter("@TypeStr", System.Data.SqlDbType.NVarChar, 0, "TypeStr"), New System.Data.SqlClient.SqlParameter("@Table", System.Data.SqlDbType.NVarChar, 0, "Table"), New System.Data.SqlClient.SqlParameter("@FldShortColumn", System.Data.SqlDbType.NVarChar, 0, "FldShortColumn"), New System.Data.SqlClient.SqlParameter("@picture", System.Data.SqlDbType.VarBinary, 0, "picture"), New System.Data.SqlClient.SqlParameter("@IDGroup", System.Data.SqlDbType.Int, 0, "IDGroup"), New System.Data.SqlClient.SqlParameter("@CreatedUser", System.Data.SqlDbType.NVarChar, 0, "CreatedUser"), New System.Data.SqlClient.SqlParameter("@Private", System.Data.SqlDbType.Bit, 0, "Private"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@Sql", System.Data.SqlDbType.NVarChar, 0, "Sql"), New System.Data.SqlClient.SqlParameter("@UIType", System.Data.SqlDbType.NVarChar, 0, "UIType"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@Extern", System.Data.SqlDbType.Bit, 0, "Extern"), New System.Data.SqlClient.SqlParameter("@SubQuery", System.Data.SqlDbType.Bit, 0, "SubQuery"), New System.Data.SqlClient.SqlParameter("@LicenseKey", System.Data.SqlDbType.NVarChar, 0, "LicenseKey"), New System.Data.SqlClient.SqlParameter("@Published", System.Data.SqlDbType.Bit, 0, "Published"), New System.Data.SqlClient.SqlParameter("@ForServices", System.Data.SqlDbType.Bit, 0, "ForServices")})
        '
        'SqlCommand7
        '
        Me.SqlCommand7.CommandText = resources.GetString("SqlCommand7.CommandText")
        Me.SqlCommand7.Connection = Me.dbConn
        '
        'SqlCommand8
        '
        Me.SqlCommand8.CommandText = resources.GetString("SqlCommand8.CommandText")
        Me.SqlCommand8.Connection = Me.dbConn
        Me.SqlCommand8.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDRessource", System.Data.SqlDbType.NVarChar, 0, "IDRessource"), New System.Data.SqlClient.SqlParameter("@IDOwnInt", System.Data.SqlDbType.Int, 0, "IDOwnInt"), New System.Data.SqlClient.SqlParameter("@IDOwnStr", System.Data.SqlDbType.NVarChar, 0, "IDOwnStr"), New System.Data.SqlClient.SqlParameter("@sort", System.Data.SqlDbType.Int, 0, "sort"), New System.Data.SqlClient.SqlParameter("@IsMain", System.Data.SqlDbType.Bit, 0, "IsMain"), New System.Data.SqlClient.SqlParameter("@TypeQry", System.Data.SqlDbType.NVarChar, 0, "TypeQry"), New System.Data.SqlClient.SqlParameter("@TypeStr", System.Data.SqlDbType.NVarChar, 0, "TypeStr"), New System.Data.SqlClient.SqlParameter("@Table", System.Data.SqlDbType.NVarChar, 0, "Table"), New System.Data.SqlClient.SqlParameter("@FldShortColumn", System.Data.SqlDbType.NVarChar, 0, "FldShortColumn"), New System.Data.SqlClient.SqlParameter("@picture", System.Data.SqlDbType.VarBinary, 0, "picture"), New System.Data.SqlClient.SqlParameter("@IDGroup", System.Data.SqlDbType.Int, 0, "IDGroup"), New System.Data.SqlClient.SqlParameter("@CreatedUser", System.Data.SqlDbType.NVarChar, 0, "CreatedUser"), New System.Data.SqlClient.SqlParameter("@Private", System.Data.SqlDbType.Bit, 0, "Private"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@Sql", System.Data.SqlDbType.NVarChar, 0, "Sql"), New System.Data.SqlClient.SqlParameter("@UIType", System.Data.SqlDbType.NVarChar, 0, "UIType"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@Extern", System.Data.SqlDbType.Bit, 0, "Extern"), New System.Data.SqlClient.SqlParameter("@SubQuery", System.Data.SqlDbType.Bit, 0, "SubQuery"), New System.Data.SqlClient.SqlParameter("@LicenseKey", System.Data.SqlDbType.NVarChar, 0, "LicenseKey"), New System.Data.SqlClient.SqlParameter("@Published", System.Data.SqlDbType.Bit, 0, "Published"), New System.Data.SqlClient.SqlParameter("@ForServices", System.Data.SqlDbType.Bit, 0, "ForServices"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSelListGroup
        '
        Me.daSelListGroup.DeleteCommand = Me.SqlCommand1
        Me.daSelListGroup.InsertCommand = Me.SqlCommand2
        Me.daSelListGroup.SelectCommand = Me.SqlCommand3
        Me.daSelListGroup.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListGroup", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("IDGroupStr", "IDGroupStr"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("IDRessource", "IDRessource"), New System.Data.Common.DataColumnMapping("sys", "sys"), New System.Data.Common.DataColumnMapping("VersionNrFrom", "VersionNrFrom"), New System.Data.Common.DataColumnMapping("VersionNrTo", "VersionNrTo"), New System.Data.Common.DataColumnMapping("Sublist", "Sublist"), New System.Data.Common.DataColumnMapping("TypeEnum", "TypeEnum"), New System.Data.Common.DataColumnMapping("SortColumn", "SortColumn"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("Description", "Description")})})
        Me.daSelListGroup.UpdateCommand = Me.SqlCommand4
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "DELETE FROM [qs2].[tblSelListGroup] WHERE (([ID] = @Original_ID))"
        Me.SqlCommand1.Connection = Me.dbConn
        Me.SqlCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand2
        '
        Me.SqlCommand2.CommandText = resources.GetString("SqlCommand2.CommandText")
        Me.SqlCommand2.Connection = Me.dbConn
        Me.SqlCommand2.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDGroupStr", System.Data.SqlDbType.NVarChar, 0, "IDGroupStr"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDRessource", System.Data.SqlDbType.NVarChar, 0, "IDRessource"), New System.Data.SqlClient.SqlParameter("@sys", System.Data.SqlDbType.Bit, 0, "sys"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo"), New System.Data.SqlClient.SqlParameter("@Sublist", System.Data.SqlDbType.NVarChar, 0, "Sublist"), New System.Data.SqlClient.SqlParameter("@TypeEnum", System.Data.SqlDbType.NVarChar, 0, "TypeEnum"), New System.Data.SqlClient.SqlParameter("@SortColumn", System.Data.SqlDbType.NVarChar, 0, "SortColumn"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description")})
        '
        'SqlCommand3
        '
        Me.SqlCommand3.CommandText = resources.GetString("SqlCommand3.CommandText")
        Me.SqlCommand3.Connection = Me.dbConn
        '
        'SqlCommand4
        '
        Me.SqlCommand4.CommandText = resources.GetString("SqlCommand4.CommandText")
        Me.SqlCommand4.Connection = Me.dbConn
        Me.SqlCommand4.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDGroupStr", System.Data.SqlDbType.NVarChar, 0, "IDGroupStr"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDRessource", System.Data.SqlDbType.NVarChar, 0, "IDRessource"), New System.Data.SqlClient.SqlParameter("@sys", System.Data.SqlDbType.Bit, 0, "sys"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo"), New System.Data.SqlClient.SqlParameter("@Sublist", System.Data.SqlDbType.NVarChar, 0, "Sublist"), New System.Data.SqlClient.SqlParameter("@TypeEnum", System.Data.SqlDbType.NVarChar, 0, "TypeEnum"), New System.Data.SqlClient.SqlParameter("@SortColumn", System.Data.SqlDbType.NVarChar, 0, "SortColumn"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSelListEntrysObj
        '
        Me.daSelListEntrysObj.DeleteCommand = Me.SqlCommand13
        Me.daSelListEntrysObj.InsertCommand = Me.SqlCommand14
        Me.daSelListEntrysObj.SelectCommand = Me.SqlCommand15
        Me.daSelListEntrysObj.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListEntriesObj", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublist", "IDSelListEntrySublist"), New System.Data.Common.DataColumnMapping("IDSelListEntry", "IDSelListEntry"), New System.Data.Common.DataColumnMapping("IDStay", "IDStay"), New System.Data.Common.DataColumnMapping("IDParticipantStay", "IDParticipantStay"), New System.Data.Common.DataColumnMapping("IDApplicationStay", "IDApplicationStay"), New System.Data.Common.DataColumnMapping("typIDGroup", "typIDGroup"), New System.Data.Common.DataColumnMapping("From", "From"), New System.Data.Common.DataColumnMapping("To", "To"), New System.Data.Common.DataColumnMapping("IDClassification", "IDClassification"), New System.Data.Common.DataColumnMapping("IDOwnInt", "IDOwnInt"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("CreatedBy", "CreatedBy"), New System.Data.Common.DataColumnMapping("Modified", "Modified"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("IsMain", "IsMain"), New System.Data.Common.DataColumnMapping("Active", "Active"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("IDObjectGuid", "IDObjectGuid"), New System.Data.Common.DataColumnMapping("Transfered", "Transfered"), New System.Data.Common.DataColumnMapping("nVisible", "nVisible")})})
        Me.daSelListEntrysObj.UpdateCommand = Me.SqlCommand16
        '
        'SqlCommand13
        '
        Me.SqlCommand13.CommandText = "DELETE FROM [qs2].[tblSelListEntriesObj] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand13.Connection = Me.dbConn
        Me.SqlCommand13.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand14
        '
        Me.SqlCommand14.CommandText = resources.GetString("SqlCommand14.CommandText")
        Me.SqlCommand14.Connection = Me.dbConn
        Me.SqlCommand14.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDObject", System.Data.SqlDbType.Int, 0, "IDObject"), New System.Data.SqlClient.SqlParameter("@IDSelListEntrySublist", System.Data.SqlDbType.Int, 0, "IDSelListEntrySublist"), New System.Data.SqlClient.SqlParameter("@IDSelListEntry", System.Data.SqlDbType.Int, 0, "IDSelListEntry"), New System.Data.SqlClient.SqlParameter("@IDStay", System.Data.SqlDbType.Int, 0, "IDStay"), New System.Data.SqlClient.SqlParameter("@IDParticipantStay", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStay"), New System.Data.SqlClient.SqlParameter("@IDApplicationStay", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStay"), New System.Data.SqlClient.SqlParameter("@typIDGroup", System.Data.SqlDbType.NVarChar, 0, "typIDGroup"), New System.Data.SqlClient.SqlParameter("@From", System.Data.SqlDbType.DateTime, 0, "From"), New System.Data.SqlClient.SqlParameter("@To", System.Data.SqlDbType.DateTime, 0, "To"), New System.Data.SqlClient.SqlParameter("@IDClassification", System.Data.SqlDbType.NVarChar, 0, "IDClassification"), New System.Data.SqlClient.SqlParameter("@IDOwnInt", System.Data.SqlDbType.Int, 0, "IDOwnInt"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@CreatedBy", System.Data.SqlDbType.NVarChar, 0, "CreatedBy"), New System.Data.SqlClient.SqlParameter("@Modified", System.Data.SqlDbType.DateTime, 0, "Modified"), New System.Data.SqlClient.SqlParameter("@ModifiedBy", System.Data.SqlDbType.NVarChar, 0, "ModifiedBy"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IsMain", System.Data.SqlDbType.Bit, 0, "IsMain"), New System.Data.SqlClient.SqlParameter("@Active", System.Data.SqlDbType.Bit, 0, "Active"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDObjectGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDObjectGuid"), New System.Data.SqlClient.SqlParameter("@Transfered", System.Data.SqlDbType.DateTime, 0, "Transfered"), New System.Data.SqlClient.SqlParameter("@nVisible", System.Data.SqlDbType.Int, 0, "nVisible")})
        '
        'SqlCommand15
        '
        Me.SqlCommand15.CommandText = resources.GetString("SqlCommand15.CommandText")
        Me.SqlCommand15.Connection = Me.dbConn
        '
        'SqlCommand16
        '
        Me.SqlCommand16.CommandText = resources.GetString("SqlCommand16.CommandText")
        Me.SqlCommand16.Connection = Me.dbConn
        Me.SqlCommand16.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDObject", System.Data.SqlDbType.Int, 0, "IDObject"), New System.Data.SqlClient.SqlParameter("@IDSelListEntrySublist", System.Data.SqlDbType.Int, 0, "IDSelListEntrySublist"), New System.Data.SqlClient.SqlParameter("@IDSelListEntry", System.Data.SqlDbType.Int, 0, "IDSelListEntry"), New System.Data.SqlClient.SqlParameter("@IDStay", System.Data.SqlDbType.Int, 0, "IDStay"), New System.Data.SqlClient.SqlParameter("@IDParticipantStay", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStay"), New System.Data.SqlClient.SqlParameter("@IDApplicationStay", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStay"), New System.Data.SqlClient.SqlParameter("@typIDGroup", System.Data.SqlDbType.NVarChar, 0, "typIDGroup"), New System.Data.SqlClient.SqlParameter("@From", System.Data.SqlDbType.DateTime, 0, "From"), New System.Data.SqlClient.SqlParameter("@To", System.Data.SqlDbType.DateTime, 0, "To"), New System.Data.SqlClient.SqlParameter("@IDClassification", System.Data.SqlDbType.NVarChar, 0, "IDClassification"), New System.Data.SqlClient.SqlParameter("@IDOwnInt", System.Data.SqlDbType.Int, 0, "IDOwnInt"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@CreatedBy", System.Data.SqlDbType.NVarChar, 0, "CreatedBy"), New System.Data.SqlClient.SqlParameter("@Modified", System.Data.SqlDbType.DateTime, 0, "Modified"), New System.Data.SqlClient.SqlParameter("@ModifiedBy", System.Data.SqlDbType.NVarChar, 0, "ModifiedBy"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IsMain", System.Data.SqlDbType.Bit, 0, "IsMain"), New System.Data.SqlClient.SqlParameter("@Active", System.Data.SqlDbType.Bit, 0, "Active"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@IDObjectGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDObjectGuid"), New System.Data.SqlClient.SqlParameter("@Transfered", System.Data.SqlDbType.DateTime, 0, "Transfered"), New System.Data.SqlClient.SqlParameter("@nVisible", System.Data.SqlDbType.Int, 0, "nVisible"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAdjust
        '
        Me.daAdjust.DeleteCommand = Me.SqlDeleteCommand1
        Me.daAdjust.InsertCommand = Me.SqlInsertCommand1
        Me.daAdjust.SelectCommand = Me.SqlSelectCommand1
        Me.daAdjust.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblAdjust", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("setting", "setting"), New System.Data.Common.DataColumnMapping("client", "client"), New System.Data.Common.DataColumnMapping("usrSetting", "usrSetting"), New System.Data.Common.DataColumnMapping("type", "type"), New System.Data.Common.DataColumnMapping("str", "str"), New System.Data.Common.DataColumnMapping("dbl", "dbl"), New System.Data.Common.DataColumnMapping("bool", "bool"), New System.Data.Common.DataColumnMapping("dat", "dat"), New System.Data.Common.DataColumnMapping("byt", "byt")})})
        Me.daAdjust.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM [qs2].[tblAdjust] WHERE (([setting] = @Original_setting) AND ([client" &
    "] = @Original_client))"
        Me.SqlDeleteCommand1.Connection = Me.dbConn
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_setting", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "setting", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_client", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "client", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO [qs2].[tblAdjust] ([setting], [client], [usrSetting], [type], [str], " &
    "[dbl], [bool], [dat], [byt]) VALUES (@setting, @client, @usrSetting, @type, @str" &
    ", @dbl, @bool, @dat, @byt)"
        Me.SqlInsertCommand1.Connection = Me.dbConn
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@setting", System.Data.SqlDbType.NVarChar, 0, "setting"), New System.Data.SqlClient.SqlParameter("@client", System.Data.SqlDbType.NVarChar, 0, "client"), New System.Data.SqlClient.SqlParameter("@usrSetting", System.Data.SqlDbType.Bit, 0, "usrSetting"), New System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 0, "type"), New System.Data.SqlClient.SqlParameter("@str", System.Data.SqlDbType.NVarChar, 0, "str"), New System.Data.SqlClient.SqlParameter("@dbl", System.Data.SqlDbType.Float, 0, "dbl"), New System.Data.SqlClient.SqlParameter("@bool", System.Data.SqlDbType.Bit, 0, "bool"), New System.Data.SqlClient.SqlParameter("@dat", System.Data.SqlDbType.DateTime, 0, "dat"), New System.Data.SqlClient.SqlParameter("@byt", System.Data.SqlDbType.VarBinary, 0, "byt")})
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT        setting, client, usrSetting, type, str, dbl, bool, dat, byt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM  " &
    "         qs2.tblAdjust"
        Me.SqlSelectCommand1.Connection = Me.dbConn
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.dbConn
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@setting", System.Data.SqlDbType.NVarChar, 0, "setting"), New System.Data.SqlClient.SqlParameter("@client", System.Data.SqlDbType.NVarChar, 0, "client"), New System.Data.SqlClient.SqlParameter("@usrSetting", System.Data.SqlDbType.Bit, 0, "usrSetting"), New System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 0, "type"), New System.Data.SqlClient.SqlParameter("@str", System.Data.SqlDbType.NVarChar, 0, "str"), New System.Data.SqlClient.SqlParameter("@dbl", System.Data.SqlDbType.Float, 0, "dbl"), New System.Data.SqlClient.SqlParameter("@bool", System.Data.SqlDbType.Bit, 0, "bool"), New System.Data.SqlClient.SqlParameter("@dat", System.Data.SqlDbType.DateTime, 0, "dat"), New System.Data.SqlClient.SqlParameter("@byt", System.Data.SqlDbType.VarBinary, 0, "byt"), New System.Data.SqlClient.SqlParameter("@Original_setting", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "setting", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_client", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "client", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daCriteria
        '
        Me.daCriteria.DeleteCommand = Me.SqlCommand9
        Me.daCriteria.InsertCommand = Me.SqlCommand10
        Me.daCriteria.SelectCommand = Me.SqlCommand11
        Me.daCriteria.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblCriteria", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("ControlType", "ControlType"), New System.Data.Common.DataColumnMapping("SQLValueListSelect", "SQLValueListSelect"), New System.Data.Common.DataColumnMapping("AliasFldShort", "AliasFldShort"), New System.Data.Common.DataColumnMapping("SourceTable", "SourceTable"), New System.Data.Common.DataColumnMapping("ControlPattern", "ControlPattern"), New System.Data.Common.DataColumnMapping("MaskInput", "MaskInput"), New System.Data.Common.DataColumnMapping("ControlMinVal", "ControlMinVal"), New System.Data.Common.DataColumnMapping("ControlMaxVal", "ControlMaxVal"), New System.Data.Common.DataColumnMapping("ControlMinLength", "ControlMinLength"), New System.Data.Common.DataColumnMapping("ControlMaxLength", "ControlMaxLength"), New System.Data.Common.DataColumnMapping("Used", "Used"), New System.Data.Common.DataColumnMapping("Validate", "Validate"), New System.Data.Common.DataColumnMapping("Editable", "Editable"), New System.Data.Common.DataColumnMapping("UserDefined", "UserDefined"), New System.Data.Common.DataColumnMapping("UseInQueries", "UseInQueries"), New System.Data.Common.DataColumnMapping("LicenseKey", "LicenseKey"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("ShowAt", "ShowAt"), New System.Data.Common.DataColumnMapping("prefered", "prefered"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("DefaultValues", "DefaultValues"), New System.Data.Common.DataColumnMapping("DefaultValuesCustomer", "DefaultValuesCustomer"), New System.Data.Common.DataColumnMapping("UsedCustomer", "UsedCustomer")})})
        Me.daCriteria.UpdateCommand = Me.SqlCommand12
        '
        'SqlCommand9
        '
        Me.SqlCommand9.CommandText = "DELETE FROM [qs2].[tblCriteria] WHERE (([FldShort] = @Original_FldShort) AND ([ID" &
    "Application] = @Original_IDApplication))"
        Me.SqlCommand9.Connection = Me.dbConn
        Me.SqlCommand9.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_FldShort", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FldShort", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand10
        '
        Me.SqlCommand10.CommandText = resources.GetString("SqlCommand10.CommandText")
        Me.SqlCommand10.Connection = Me.dbConn
        Me.SqlCommand10.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@ControlType", System.Data.SqlDbType.NVarChar, 0, "ControlType"), New System.Data.SqlClient.SqlParameter("@SQLValueListSelect", System.Data.SqlDbType.NVarChar, 0, "SQLValueListSelect"), New System.Data.SqlClient.SqlParameter("@AliasFldShort", System.Data.SqlDbType.NVarChar, 0, "AliasFldShort"), New System.Data.SqlClient.SqlParameter("@SourceTable", System.Data.SqlDbType.NVarChar, 0, "SourceTable"), New System.Data.SqlClient.SqlParameter("@ControlPattern", System.Data.SqlDbType.NVarChar, 0, "ControlPattern"), New System.Data.SqlClient.SqlParameter("@MaskInput", System.Data.SqlDbType.NVarChar, 0, "MaskInput"), New System.Data.SqlClient.SqlParameter("@ControlMinVal", System.Data.SqlDbType.NVarChar, 0, "ControlMinVal"), New System.Data.SqlClient.SqlParameter("@ControlMaxVal", System.Data.SqlDbType.NVarChar, 0, "ControlMaxVal"), New System.Data.SqlClient.SqlParameter("@ControlMinLength", System.Data.SqlDbType.Int, 0, "ControlMinLength"), New System.Data.SqlClient.SqlParameter("@ControlMaxLength", System.Data.SqlDbType.Int, 0, "ControlMaxLength"), New System.Data.SqlClient.SqlParameter("@Used", System.Data.SqlDbType.Bit, 0, "Used"), New System.Data.SqlClient.SqlParameter("@Validate", System.Data.SqlDbType.Bit, 0, "Validate"), New System.Data.SqlClient.SqlParameter("@Editable", System.Data.SqlDbType.Bit, 0, "Editable"), New System.Data.SqlClient.SqlParameter("@UserDefined", System.Data.SqlDbType.Bit, 0, "UserDefined"), New System.Data.SqlClient.SqlParameter("@UseInQueries", System.Data.SqlDbType.Bit, 0, "UseInQueries"), New System.Data.SqlClient.SqlParameter("@LicenseKey", System.Data.SqlDbType.VarChar, 0, "LicenseKey"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@ShowAt", System.Data.SqlDbType.NVarChar, 0, "ShowAt"), New System.Data.SqlClient.SqlParameter("@prefered", System.Data.SqlDbType.Bit, 0, "prefered"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@DefaultValues", System.Data.SqlDbType.NVarChar, 0, "DefaultValues"), New System.Data.SqlClient.SqlParameter("@DefaultValuesCustomer", System.Data.SqlDbType.NVarChar, 0, "DefaultValuesCustomer"), New System.Data.SqlClient.SqlParameter("@UsedCustomer", System.Data.SqlDbType.Bit, 0, "UsedCustomer")})
        '
        'SqlCommand11
        '
        Me.SqlCommand11.CommandText = resources.GetString("SqlCommand11.CommandText")
        Me.SqlCommand11.Connection = Me.dbConn
        '
        'SqlCommand12
        '
        Me.SqlCommand12.CommandText = resources.GetString("SqlCommand12.CommandText")
        Me.SqlCommand12.Connection = Me.dbConn
        Me.SqlCommand12.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@ControlType", System.Data.SqlDbType.NVarChar, 0, "ControlType"), New System.Data.SqlClient.SqlParameter("@SQLValueListSelect", System.Data.SqlDbType.NVarChar, 0, "SQLValueListSelect"), New System.Data.SqlClient.SqlParameter("@AliasFldShort", System.Data.SqlDbType.NVarChar, 0, "AliasFldShort"), New System.Data.SqlClient.SqlParameter("@SourceTable", System.Data.SqlDbType.NVarChar, 0, "SourceTable"), New System.Data.SqlClient.SqlParameter("@ControlPattern", System.Data.SqlDbType.NVarChar, 0, "ControlPattern"), New System.Data.SqlClient.SqlParameter("@MaskInput", System.Data.SqlDbType.NVarChar, 0, "MaskInput"), New System.Data.SqlClient.SqlParameter("@ControlMinVal", System.Data.SqlDbType.NVarChar, 0, "ControlMinVal"), New System.Data.SqlClient.SqlParameter("@ControlMaxVal", System.Data.SqlDbType.NVarChar, 0, "ControlMaxVal"), New System.Data.SqlClient.SqlParameter("@ControlMinLength", System.Data.SqlDbType.Int, 0, "ControlMinLength"), New System.Data.SqlClient.SqlParameter("@ControlMaxLength", System.Data.SqlDbType.Int, 0, "ControlMaxLength"), New System.Data.SqlClient.SqlParameter("@Used", System.Data.SqlDbType.Bit, 0, "Used"), New System.Data.SqlClient.SqlParameter("@Validate", System.Data.SqlDbType.Bit, 0, "Validate"), New System.Data.SqlClient.SqlParameter("@Editable", System.Data.SqlDbType.Bit, 0, "Editable"), New System.Data.SqlClient.SqlParameter("@UserDefined", System.Data.SqlDbType.Bit, 0, "UserDefined"), New System.Data.SqlClient.SqlParameter("@UseInQueries", System.Data.SqlDbType.Bit, 0, "UseInQueries"), New System.Data.SqlClient.SqlParameter("@LicenseKey", System.Data.SqlDbType.VarChar, 0, "LicenseKey"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@ShowAt", System.Data.SqlDbType.NVarChar, 0, "ShowAt"), New System.Data.SqlClient.SqlParameter("@prefered", System.Data.SqlDbType.Bit, 0, "prefered"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@DefaultValues", System.Data.SqlDbType.NVarChar, 0, "DefaultValues"), New System.Data.SqlClient.SqlParameter("@DefaultValuesCustomer", System.Data.SqlDbType.NVarChar, 0, "DefaultValuesCustomer"), New System.Data.SqlClient.SqlParameter("@UsedCustomer", System.Data.SqlDbType.Bit, 0, "UsedCustomer"), New System.Data.SqlClient.SqlParameter("@Original_FldShort", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FldShort", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daCriteriaOpt
        '
        Me.daCriteriaOpt.DeleteCommand = Me.SqlCommand17
        Me.daCriteriaOpt.InsertCommand = Me.SqlCommand18
        Me.daCriteriaOpt.SelectCommand = Me.SqlCommand19
        Me.daCriteriaOpt.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblCriteriaOpt", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("Parameter", "Parameter"), New System.Data.Common.DataColumnMapping("Value", "Value"), New System.Data.Common.DataColumnMapping("Referenze", "Referenze"), New System.Data.Common.DataColumnMapping("VersionNrFrom", "VersionNrFrom"), New System.Data.Common.DataColumnMapping("VersionNrTo", "VersionNrTo")})})
        Me.daCriteriaOpt.UpdateCommand = Me.SqlCommand20
        '
        'SqlCommand17
        '
        Me.SqlCommand17.CommandText = "DELETE FROM [qs2].[tblCriteriaOpt] WHERE (([FldShort] = @Original_FldShort) AND (" &
    "[IDApplication] = @Original_IDApplication) AND ([Parameter] = @Original_Paramete" &
    "r))"
        Me.SqlCommand17.Connection = Me.dbConn
        Me.SqlCommand17.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_FldShort", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FldShort", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Parameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Parameter", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand18
        '
        Me.SqlCommand18.CommandText = resources.GetString("SqlCommand18.CommandText")
        Me.SqlCommand18.Connection = Me.dbConn
        Me.SqlCommand18.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@Parameter", System.Data.SqlDbType.NVarChar, 0, "Parameter"), New System.Data.SqlClient.SqlParameter("@Value", System.Data.SqlDbType.NVarChar, 0, "Value"), New System.Data.SqlClient.SqlParameter("@Referenze", System.Data.SqlDbType.NVarChar, 0, "Referenze"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo")})
        '
        'SqlCommand19
        '
        Me.SqlCommand19.CommandText = "SELECT        FldShort, IDApplication, Parameter, Value, Referenze, VersionNrFrom" &
    ", VersionNrTo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.tblCriteriaOpt"
        Me.SqlCommand19.Connection = Me.dbConn
        '
        'SqlCommand20
        '
        Me.SqlCommand20.CommandText = resources.GetString("SqlCommand20.CommandText")
        Me.SqlCommand20.Connection = Me.dbConn
        Me.SqlCommand20.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@Parameter", System.Data.SqlDbType.NVarChar, 0, "Parameter"), New System.Data.SqlClient.SqlParameter("@Value", System.Data.SqlDbType.NVarChar, 0, "Value"), New System.Data.SqlClient.SqlParameter("@Referenze", System.Data.SqlDbType.NVarChar, 0, "Referenze"), New System.Data.SqlClient.SqlParameter("@VersionNrFrom", System.Data.SqlDbType.NVarChar, 0, "VersionNrFrom"), New System.Data.SqlClient.SqlParameter("@VersionNrTo", System.Data.SqlDbType.NVarChar, 0, "VersionNrTo"), New System.Data.SqlClient.SqlParameter("@Original_FldShort", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FldShort", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Parameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Parameter", System.Data.DataRowVersion.Original, Nothing)})
        '
        'davListEntriesWithGroup
        '
        Me.davListEntriesWithGroup.SelectCommand = Me.SqlCommand27
        Me.davListEntriesWithGroup.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "vListEntriesWithGroup", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("s_ID", "s_ID"), New System.Data.Common.DataColumnMapping("s_IDGuid", "s_IDGuid"), New System.Data.Common.DataColumnMapping("s_IDRessource", "s_IDRessource"), New System.Data.Common.DataColumnMapping("s_IDOwnInt", "s_IDOwnInt"), New System.Data.Common.DataColumnMapping("s_IDOwnStr", "s_IDOwnStr"), New System.Data.Common.DataColumnMapping("s_sort", "s_sort"), New System.Data.Common.DataColumnMapping("s_IsMain", "s_IsMain"), New System.Data.Common.DataColumnMapping("s_TypeStr", "s_TypeStr"), New System.Data.Common.DataColumnMapping("s_Table", "s_Table"), New System.Data.Common.DataColumnMapping("s_FldShortColum", "s_FldShortColum"), New System.Data.Common.DataColumnMapping("s_picture", "s_picture"), New System.Data.Common.DataColumnMapping("s_IDGroup", "s_IDGroup"), New System.Data.Common.DataColumnMapping("s_CreatedUser", "s_CreatedUser"), New System.Data.Common.DataColumnMapping("s_Private", "s_Private"), New System.Data.Common.DataColumnMapping("s_Classification", "s_Classification"), New System.Data.Common.DataColumnMapping("s_Created", "s_Created"), New System.Data.Common.DataColumnMapping("s_Sql", "s_Sql"), New System.Data.Common.DataColumnMapping("s_VersionNrFrom", "s_VersionNrFrom"), New System.Data.Common.DataColumnMapping("s_VersionNrTo", "s_VersionNrTo"), New System.Data.Common.DataColumnMapping("s_TypeQry", "s_TypeQry"), New System.Data.Common.DataColumnMapping("s_UIType", "s_UIType"), New System.Data.Common.DataColumnMapping("s_Description", "s_Description"), New System.Data.Common.DataColumnMapping("g_IDGuid", "g_IDGuid"), New System.Data.Common.DataColumnMapping("g_IDGroupStr", "g_IDGroupStr"), New System.Data.Common.DataColumnMapping("g_IDApplication", "g_IDApplication"), New System.Data.Common.DataColumnMapping("g_IDParticipant", "g_IDParticipant"), New System.Data.Common.DataColumnMapping("g_IDRessource", "g_IDRessource"), New System.Data.Common.DataColumnMapping("g_sys", "g_sys"), New System.Data.Common.DataColumnMapping("g_Sublist", "g_Sublist"), New System.Data.Common.DataColumnMapping("g_TypeEnum", "g_TypeEnum"), New System.Data.Common.DataColumnMapping("g_SortColumn", "g_SortColumn"), New System.Data.Common.DataColumnMapping("g_Classification", "g_Classification"), New System.Data.Common.DataColumnMapping("g_VersionNrFrom", "g_VersionNrFrom"), New System.Data.Common.DataColumnMapping("g_VersionNrTo", "g_VersionNrTo"), New System.Data.Common.DataColumnMapping("g_Description", "g_Description")})})
        '
        'SqlCommand27
        '
        Me.SqlCommand27.CommandText = resources.GetString("SqlCommand27.CommandText")
        Me.SqlCommand27.Connection = Me.dbConn
        '
        'daStayAdditions
        '
        Me.daStayAdditions.DeleteCommand = Me.SqlCommand25
        Me.daStayAdditions.InsertCommand = Me.SqlCommand26
        Me.daStayAdditions.SelectCommand = Me.SqlCommand28
        Me.daStayAdditions.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblStayAdditions", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("IDStayParent", "IDStayParent"), New System.Data.Common.DataColumnMapping("IDApplicationStayParent", "IDApplicationStayParent"), New System.Data.Common.DataColumnMapping("IDParticipantStayParent", "IDParticipantStayParent"), New System.Data.Common.DataColumnMapping("IDStayChild", "IDStayChild"), New System.Data.Common.DataColumnMapping("IDApplicationStayChild", "IDApplicationStayChild"), New System.Data.Common.DataColumnMapping("IDParticipantStayChild", "IDParticipantStayChild"), New System.Data.Common.DataColumnMapping("IDSelList", "IDSelList"), New System.Data.Common.DataColumnMapping("typ", "typ"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("IDSelListFirst", "IDSelListFirst"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject")})})
        Me.daStayAdditions.UpdateCommand = Me.SqlCommand29
        '
        'SqlCommand25
        '
        Me.SqlCommand25.CommandText = "DELETE FROM [qs2].[tblStayAdditions] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand25.Connection = Me.dbConn
        Me.SqlCommand25.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand26
        '
        Me.SqlCommand26.CommandText = resources.GetString("SqlCommand26.CommandText")
        Me.SqlCommand26.Connection = Me.dbConn
        Me.SqlCommand26.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDStayParent", System.Data.SqlDbType.Int, 0, "IDStayParent"), New System.Data.SqlClient.SqlParameter("@IDApplicationStayParent", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStayParent"), New System.Data.SqlClient.SqlParameter("@IDParticipantStayParent", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStayParent"), New System.Data.SqlClient.SqlParameter("@IDStayChild", System.Data.SqlDbType.Int, 0, "IDStayChild"), New System.Data.SqlClient.SqlParameter("@IDApplicationStayChild", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStayChild"), New System.Data.SqlClient.SqlParameter("@IDParticipantStayChild", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStayChild"), New System.Data.SqlClient.SqlParameter("@IDSelList", System.Data.SqlDbType.Int, 0, "IDSelList"), New System.Data.SqlClient.SqlParameter("@typ", System.Data.SqlDbType.NVarChar, 0, "typ"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IDSelListFirst", System.Data.SqlDbType.Int, 0, "IDSelListFirst"), New System.Data.SqlClient.SqlParameter("@IDPatient", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPatient"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDObject", System.Data.SqlDbType.UniqueIdentifier, 0, "IDObject")})
        '
        'SqlCommand28
        '
        Me.SqlCommand28.CommandText = resources.GetString("SqlCommand28.CommandText")
        Me.SqlCommand28.Connection = Me.dbConn
        '
        'SqlCommand29
        '
        Me.SqlCommand29.CommandText = resources.GetString("SqlCommand29.CommandText")
        Me.SqlCommand29.Connection = Me.dbConn
        Me.SqlCommand29.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@IDStayParent", System.Data.SqlDbType.Int, 0, "IDStayParent"), New System.Data.SqlClient.SqlParameter("@IDApplicationStayParent", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStayParent"), New System.Data.SqlClient.SqlParameter("@IDParticipantStayParent", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStayParent"), New System.Data.SqlClient.SqlParameter("@IDStayChild", System.Data.SqlDbType.Int, 0, "IDStayChild"), New System.Data.SqlClient.SqlParameter("@IDApplicationStayChild", System.Data.SqlDbType.NVarChar, 0, "IDApplicationStayChild"), New System.Data.SqlClient.SqlParameter("@IDParticipantStayChild", System.Data.SqlDbType.NVarChar, 0, "IDParticipantStayChild"), New System.Data.SqlClient.SqlParameter("@IDSelList", System.Data.SqlDbType.Int, 0, "IDSelList"), New System.Data.SqlClient.SqlParameter("@typ", System.Data.SqlDbType.NVarChar, 0, "typ"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@IDSelListFirst", System.Data.SqlDbType.Int, 0, "IDSelListFirst"), New System.Data.SqlClient.SqlParameter("@IDPatient", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPatient"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@IDObject", System.Data.SqlDbType.UniqueIdentifier, 0, "IDObject"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2.CommandText = "SELECT        FldShortParent, IDApplicationParent, FldShortChild, IDApplicationCh" &
    "ild, Conditions, Type, TypeSub, IDKey, IDGuid, ConditionsSub, Sort" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        " &
    "    qs2.tblRelationship"
        Me.SqlSelectCommand2.Connection = Me.dbConn
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2.CommandText = "DELETE FROM [qs2].[tblRelationship] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlDeleteCommand2.Connection = Me.dbConn
        Me.SqlDeleteCommand2.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daRelationship
        '
        Me.daRelationship.DeleteCommand = Me.SqlDeleteCommand2
        Me.daRelationship.InsertCommand = Me.SqlInsertCommand
        Me.daRelationship.SelectCommand = Me.SqlSelectCommand2
        Me.daRelationship.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblRelationship", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FldShortParent", "FldShortParent"), New System.Data.Common.DataColumnMapping("IDApplicationParent", "IDApplicationParent"), New System.Data.Common.DataColumnMapping("FldShortChild", "FldShortChild"), New System.Data.Common.DataColumnMapping("IDApplicationChild", "IDApplicationChild"), New System.Data.Common.DataColumnMapping("Conditions", "Conditions"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("TypeSub", "TypeSub"), New System.Data.Common.DataColumnMapping("IDKey", "IDKey"), New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("ConditionsSub", "ConditionsSub"), New System.Data.Common.DataColumnMapping("Sort", "Sort")})})
        Me.daRelationship.UpdateCommand = Me.SqlUpdateCommand
        '
        'SqlInsertCommand
        '
        Me.SqlInsertCommand.CommandText = resources.GetString("SqlInsertCommand.CommandText")
        Me.SqlInsertCommand.Connection = Me.dbConn
        Me.SqlInsertCommand.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShortParent", System.Data.SqlDbType.NVarChar, 0, "FldShortParent"), New System.Data.SqlClient.SqlParameter("@IDApplicationParent", System.Data.SqlDbType.NVarChar, 0, "IDApplicationParent"), New System.Data.SqlClient.SqlParameter("@FldShortChild", System.Data.SqlDbType.NVarChar, 0, "FldShortChild"), New System.Data.SqlClient.SqlParameter("@IDApplicationChild", System.Data.SqlDbType.NVarChar, 0, "IDApplicationChild"), New System.Data.SqlClient.SqlParameter("@Conditions", System.Data.SqlDbType.NVarChar, 0, "Conditions"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@TypeSub", System.Data.SqlDbType.NVarChar, 0, "TypeSub"), New System.Data.SqlClient.SqlParameter("@IDKey", System.Data.SqlDbType.NVarChar, 0, "IDKey"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@ConditionsSub", System.Data.SqlDbType.NVarChar, 0, "ConditionsSub"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort")})
        '
        'SqlUpdateCommand
        '
        Me.SqlUpdateCommand.CommandText = resources.GetString("SqlUpdateCommand.CommandText")
        Me.SqlUpdateCommand.Connection = Me.dbConn
        Me.SqlUpdateCommand.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@FldShortParent", System.Data.SqlDbType.NVarChar, 0, "FldShortParent"), New System.Data.SqlClient.SqlParameter("@IDApplicationParent", System.Data.SqlDbType.NVarChar, 0, "IDApplicationParent"), New System.Data.SqlClient.SqlParameter("@FldShortChild", System.Data.SqlDbType.NVarChar, 0, "FldShortChild"), New System.Data.SqlClient.SqlParameter("@IDApplicationChild", System.Data.SqlDbType.NVarChar, 0, "IDApplicationChild"), New System.Data.SqlClient.SqlParameter("@Conditions", System.Data.SqlDbType.NVarChar, 0, "Conditions"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@TypeSub", System.Data.SqlDbType.NVarChar, 0, "TypeSub"), New System.Data.SqlClient.SqlParameter("@IDKey", System.Data.SqlDbType.NVarChar, 0, "IDKey"), New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@ConditionsSub", System.Data.SqlDbType.NVarChar, 0, "ConditionsSub"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daQueriesDef
        '
        Me.daQueriesDef.DeleteCommand = Me.SqlCommand21
        Me.daQueriesDef.InsertCommand = Me.SqlCommand22
        Me.daQueriesDef.SelectCommand = Me.SqlCommand23
        Me.daQueriesDef.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblQueriesDef", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("UserInput", "UserInput"), New System.Data.Common.DataColumnMapping("FunctionPar", "FunctionPar"), New System.Data.Common.DataColumnMapping("Combination", "Combination"), New System.Data.Common.DataColumnMapping("QryTable", "QryTable"), New System.Data.Common.DataColumnMapping("QryColumn", "QryColumn"), New System.Data.Common.DataColumnMapping("CriteriaFldShort", "CriteriaFldShort"), New System.Data.Common.DataColumnMapping("CriteriaApplication", "CriteriaApplication"), New System.Data.Common.DataColumnMapping("IsSQLServerField", "IsSQLServerField"), New System.Data.Common.DataColumnMapping("Label", "Label"), New System.Data.Common.DataColumnMapping("ControlType", "ControlType"), New System.Data.Common.DataColumnMapping("Typ", "Typ"), New System.Data.Common.DataColumnMapping("Condition", "Condition"), New System.Data.Common.DataColumnMapping("ValueMin", "ValueMin"), New System.Data.Common.DataColumnMapping("Max", "Max"), New System.Data.Common.DataColumnMapping("ValueMinIDRes", "ValueMinIDRes"), New System.Data.Common.DataColumnMapping("MaxIDRes", "MaxIDRes"), New System.Data.Common.DataColumnMapping("CombinationEnd", "CombinationEnd"), New System.Data.Common.DataColumnMapping("freeSql", "freeSql"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("IDSelList", "IDSelList"), New System.Data.Common.DataColumnMapping("ApplicationOwn", "ApplicationOwn"), New System.Data.Common.DataColumnMapping("ParticipantOwn", "ParticipantOwn"), New System.Data.Common.DataColumnMapping("All", "All"), New System.Data.Common.DataColumnMapping("SpecialDefinition", "SpecialDefinition"), New System.Data.Common.DataColumnMapping("ComboAsDropDown", "ComboAsDropDown"), New System.Data.Common.DataColumnMapping("ComboAsDropDownCondition", "ComboAsDropDownCondition"), New System.Data.Common.DataColumnMapping("SpecialDefinitionMax", "SpecialDefinitionMax"), New System.Data.Common.DataColumnMapping("Chapter", "Chapter"), New System.Data.Common.DataColumnMapping("Chapters", "Chapters"), New System.Data.Common.DataColumnMapping("ChaptersDone", "ChaptersDone"), New System.Data.Common.DataColumnMapping("Placeholder", "Placeholder")})})
        Me.daQueriesDef.UpdateCommand = Me.SqlCommand24
        '
        'SqlCommand21
        '
        Me.SqlCommand21.CommandText = "DELETE FROM [qs2].[tblQueriesDef] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand21.Connection = Me.dbConn
        Me.SqlCommand21.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand22
        '
        Me.SqlCommand22.CommandText = resources.GetString("SqlCommand22.CommandText")
        Me.SqlCommand22.Connection = Me.dbConn
        Me.SqlCommand22.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@UserInput", System.Data.SqlDbType.Bit, 0, "UserInput"), New System.Data.SqlClient.SqlParameter("@FunctionPar", System.Data.SqlDbType.Bit, 0, "FunctionPar"), New System.Data.SqlClient.SqlParameter("@Combination", System.Data.SqlDbType.NVarChar, 0, "Combination"), New System.Data.SqlClient.SqlParameter("@QryTable", System.Data.SqlDbType.NVarChar, 0, "QryTable"), New System.Data.SqlClient.SqlParameter("@QryColumn", System.Data.SqlDbType.NVarChar, 0, "QryColumn"), New System.Data.SqlClient.SqlParameter("@CriteriaFldShort", System.Data.SqlDbType.NVarChar, 0, "CriteriaFldShort"), New System.Data.SqlClient.SqlParameter("@CriteriaApplication", System.Data.SqlDbType.NVarChar, 0, "CriteriaApplication"), New System.Data.SqlClient.SqlParameter("@IsSQLServerField", System.Data.SqlDbType.Bit, 0, "IsSQLServerField"), New System.Data.SqlClient.SqlParameter("@Label", System.Data.SqlDbType.NVarChar, 0, "Label"), New System.Data.SqlClient.SqlParameter("@ControlType", System.Data.SqlDbType.NVarChar, 0, "ControlType"), New System.Data.SqlClient.SqlParameter("@Typ", System.Data.SqlDbType.NVarChar, 0, "Typ"), New System.Data.SqlClient.SqlParameter("@Condition", System.Data.SqlDbType.NVarChar, 0, "Condition"), New System.Data.SqlClient.SqlParameter("@ValueMin", System.Data.SqlDbType.NVarChar, 0, "ValueMin"), New System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.NVarChar, 0, "Max"), New System.Data.SqlClient.SqlParameter("@ValueMinIDRes", System.Data.SqlDbType.NVarChar, 0, "ValueMinIDRes"), New System.Data.SqlClient.SqlParameter("@MaxIDRes", System.Data.SqlDbType.NVarChar, 0, "MaxIDRes"), New System.Data.SqlClient.SqlParameter("@CombinationEnd", System.Data.SqlDbType.NVarChar, 0, "CombinationEnd"), New System.Data.SqlClient.SqlParameter("@freeSql", System.Data.SqlDbType.NVarChar, 0, "freeSql"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@IDSelList", System.Data.SqlDbType.Int, 0, "IDSelList"), New System.Data.SqlClient.SqlParameter("@ApplicationOwn", System.Data.SqlDbType.NVarChar, 0, "ApplicationOwn"), New System.Data.SqlClient.SqlParameter("@ParticipantOwn", System.Data.SqlDbType.NVarChar, 0, "ParticipantOwn"), New System.Data.SqlClient.SqlParameter("@All", System.Data.SqlDbType.Bit, 0, "All"), New System.Data.SqlClient.SqlParameter("@SpecialDefinition", System.Data.SqlDbType.NVarChar, 0, "SpecialDefinition"), New System.Data.SqlClient.SqlParameter("@ComboAsDropDown", System.Data.SqlDbType.Bit, 0, "ComboAsDropDown"), New System.Data.SqlClient.SqlParameter("@ComboAsDropDownCondition", System.Data.SqlDbType.NVarChar, 0, "ComboAsDropDownCondition"), New System.Data.SqlClient.SqlParameter("@SpecialDefinitionMax", System.Data.SqlDbType.NVarChar, 0, "SpecialDefinitionMax"), New System.Data.SqlClient.SqlParameter("@Chapter", System.Data.SqlDbType.NVarChar, 0, "Chapter"), New System.Data.SqlClient.SqlParameter("@Chapters", System.Data.SqlDbType.NVarChar, 0, "Chapters"), New System.Data.SqlClient.SqlParameter("@ChaptersDone", System.Data.SqlDbType.Bit, 0, "ChaptersDone"), New System.Data.SqlClient.SqlParameter("@Placeholder", System.Data.SqlDbType.Bit, 0, "Placeholder")})
        '
        'SqlCommand23
        '
        Me.SqlCommand23.CommandText = resources.GetString("SqlCommand23.CommandText")
        Me.SqlCommand23.Connection = Me.dbConn
        '
        'SqlCommand24
        '
        Me.SqlCommand24.CommandText = resources.GetString("SqlCommand24.CommandText")
        Me.SqlCommand24.Connection = Me.dbConn
        Me.SqlCommand24.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@UserInput", System.Data.SqlDbType.Bit, 0, "UserInput"), New System.Data.SqlClient.SqlParameter("@FunctionPar", System.Data.SqlDbType.Bit, 0, "FunctionPar"), New System.Data.SqlClient.SqlParameter("@Combination", System.Data.SqlDbType.NVarChar, 0, "Combination"), New System.Data.SqlClient.SqlParameter("@QryTable", System.Data.SqlDbType.NVarChar, 0, "QryTable"), New System.Data.SqlClient.SqlParameter("@QryColumn", System.Data.SqlDbType.NVarChar, 0, "QryColumn"), New System.Data.SqlClient.SqlParameter("@CriteriaFldShort", System.Data.SqlDbType.NVarChar, 0, "CriteriaFldShort"), New System.Data.SqlClient.SqlParameter("@CriteriaApplication", System.Data.SqlDbType.NVarChar, 0, "CriteriaApplication"), New System.Data.SqlClient.SqlParameter("@IsSQLServerField", System.Data.SqlDbType.Bit, 0, "IsSQLServerField"), New System.Data.SqlClient.SqlParameter("@Label", System.Data.SqlDbType.NVarChar, 0, "Label"), New System.Data.SqlClient.SqlParameter("@ControlType", System.Data.SqlDbType.NVarChar, 0, "ControlType"), New System.Data.SqlClient.SqlParameter("@Typ", System.Data.SqlDbType.NVarChar, 0, "Typ"), New System.Data.SqlClient.SqlParameter("@Condition", System.Data.SqlDbType.NVarChar, 0, "Condition"), New System.Data.SqlClient.SqlParameter("@ValueMin", System.Data.SqlDbType.NVarChar, 0, "ValueMin"), New System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.NVarChar, 0, "Max"), New System.Data.SqlClient.SqlParameter("@ValueMinIDRes", System.Data.SqlDbType.NVarChar, 0, "ValueMinIDRes"), New System.Data.SqlClient.SqlParameter("@MaxIDRes", System.Data.SqlDbType.NVarChar, 0, "MaxIDRes"), New System.Data.SqlClient.SqlParameter("@CombinationEnd", System.Data.SqlDbType.NVarChar, 0, "CombinationEnd"), New System.Data.SqlClient.SqlParameter("@freeSql", System.Data.SqlDbType.NVarChar, 0, "freeSql"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@IDSelList", System.Data.SqlDbType.Int, 0, "IDSelList"), New System.Data.SqlClient.SqlParameter("@ApplicationOwn", System.Data.SqlDbType.NVarChar, 0, "ApplicationOwn"), New System.Data.SqlClient.SqlParameter("@ParticipantOwn", System.Data.SqlDbType.NVarChar, 0, "ParticipantOwn"), New System.Data.SqlClient.SqlParameter("@All", System.Data.SqlDbType.Bit, 0, "All"), New System.Data.SqlClient.SqlParameter("@SpecialDefinition", System.Data.SqlDbType.NVarChar, 0, "SpecialDefinition"), New System.Data.SqlClient.SqlParameter("@ComboAsDropDown", System.Data.SqlDbType.Bit, 0, "ComboAsDropDown"), New System.Data.SqlClient.SqlParameter("@ComboAsDropDownCondition", System.Data.SqlDbType.NVarChar, 0, "ComboAsDropDownCondition"), New System.Data.SqlClient.SqlParameter("@SpecialDefinitionMax", System.Data.SqlDbType.NVarChar, 0, "SpecialDefinitionMax"), New System.Data.SqlClient.SqlParameter("@Chapter", System.Data.SqlDbType.NVarChar, 0, "Chapter"), New System.Data.SqlClient.SqlParameter("@Chapters", System.Data.SqlDbType.NVarChar, 0, "Chapters"), New System.Data.SqlClient.SqlParameter("@ChaptersDone", System.Data.SqlDbType.Bit, 0, "ChaptersDone"), New System.Data.SqlClient.SqlParameter("@Placeholder", System.Data.SqlDbType.Bit, 0, "Placeholder"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daQueryJoinsTemp
        '
        Me.daQueryJoinsTemp.DeleteCommand = Me.SqlCommand30
        Me.daQueryJoinsTemp.InsertCommand = Me.SqlCommand31
        Me.daQueryJoinsTemp.SelectCommand = Me.SqlCommand32
        Me.daQueryJoinsTemp.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblQueryJoinsTemp", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("FromTable", "FromTable"), New System.Data.Common.DataColumnMapping("FromColumn", "FromColumn"), New System.Data.Common.DataColumnMapping("ToTable", "ToTable"), New System.Data.Common.DataColumnMapping("ToColumn", "ToColumn"), New System.Data.Common.DataColumnMapping("Order", "Order"), New System.Data.Common.DataColumnMapping("TypJoin", "TypJoin"), New System.Data.Common.DataColumnMapping("alwaysDoJoin", "alwaysDoJoin")})})
        Me.daQueryJoinsTemp.UpdateCommand = Me.SqlCommand33
        '
        'SqlCommand30
        '
        Me.SqlCommand30.CommandText = "DELETE FROM [qs2].[tblQueryJoinsTemp] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand30.Connection = Me.dbConn
        Me.SqlCommand30.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand31
        '
        Me.SqlCommand31.CommandText = resources.GetString("SqlCommand31.CommandText")
        Me.SqlCommand31.Connection = Me.dbConn
        Me.SqlCommand31.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FromTable", System.Data.SqlDbType.NVarChar, 0, "FromTable"), New System.Data.SqlClient.SqlParameter("@FromColumn", System.Data.SqlDbType.NVarChar, 0, "FromColumn"), New System.Data.SqlClient.SqlParameter("@ToTable", System.Data.SqlDbType.NVarChar, 0, "ToTable"), New System.Data.SqlClient.SqlParameter("@ToColumn", System.Data.SqlDbType.NVarChar, 0, "ToColumn"), New System.Data.SqlClient.SqlParameter("@Order", System.Data.SqlDbType.Int, 0, "Order"), New System.Data.SqlClient.SqlParameter("@TypJoin", System.Data.SqlDbType.NVarChar, 0, "TypJoin"), New System.Data.SqlClient.SqlParameter("@alwaysDoJoin", System.Data.SqlDbType.Bit, 0, "alwaysDoJoin")})
        '
        'SqlCommand32
        '
        Me.SqlCommand32.CommandText = "SELECT        IDGuid, FromTable, FromColumn, ToTable, ToColumn, [Order], TypJoin," &
    " alwaysDoJoin" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.tblQueryJoinsTemp"
        Me.SqlCommand32.Connection = Me.dbConn
        '
        'SqlCommand33
        '
        Me.SqlCommand33.CommandText = resources.GetString("SqlCommand33.CommandText")
        Me.SqlCommand33.Connection = Me.dbConn
        Me.SqlCommand33.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FromTable", System.Data.SqlDbType.NVarChar, 0, "FromTable"), New System.Data.SqlClient.SqlParameter("@FromColumn", System.Data.SqlDbType.NVarChar, 0, "FromColumn"), New System.Data.SqlClient.SqlParameter("@ToTable", System.Data.SqlDbType.NVarChar, 0, "ToTable"), New System.Data.SqlClient.SqlParameter("@ToColumn", System.Data.SqlDbType.NVarChar, 0, "ToColumn"), New System.Data.SqlClient.SqlParameter("@Order", System.Data.SqlDbType.Int, 0, "Order"), New System.Data.SqlClient.SqlParameter("@TypJoin", System.Data.SqlDbType.NVarChar, 0, "TypJoin"), New System.Data.SqlClient.SqlParameter("@alwaysDoJoin", System.Data.SqlDbType.Bit, 0, "alwaysDoJoin"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSideLogic
        '
        Me.daSideLogic.DeleteCommand = Me.SqlCommand34
        Me.daSideLogic.InsertCommand = Me.SqlCommand35
        Me.daSideLogic.SelectCommand = Me.SqlCommand36
        Me.daSideLogic.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSideLogic", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("Action", "Action"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("Chapter", "Chapter"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("ID", "ID")})})
        Me.daSideLogic.UpdateCommand = Me.SqlCommand37
        '
        'SqlCommand34
        '
        Me.SqlCommand34.CommandText = "DELETE FROM [qs2].[tblSideLogic] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand34.Connection = Me.dbConn
        Me.SqlCommand34.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand35
        '
        Me.SqlCommand35.CommandText = "INSERT INTO [qs2].[tblSideLogic] ([IDGuid], [Type], [Action], [FldShort], [Chapte" &
    "r], [IDApplication], [ID]) VALUES (@IDGuid, @Type, @Action, @FldShort, @Chapter," &
    " @IDApplication, @ID)"
        Me.SqlCommand35.Connection = Me.dbConn
        Me.SqlCommand35.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@Action", System.Data.SqlDbType.NVarChar, 0, "Action"), New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@Chapter", System.Data.SqlDbType.NVarChar, 0, "Chapter"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID")})
        '
        'SqlCommand36
        '
        Me.SqlCommand36.CommandText = "SELECT        IDGuid, Type, Action, FldShort, Chapter, IDApplication, ID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM   " &
    "         qs2.tblSideLogic"
        Me.SqlCommand36.Connection = Me.dbConn
        '
        'SqlCommand37
        '
        Me.SqlCommand37.CommandText = resources.GetString("SqlCommand37.CommandText")
        Me.SqlCommand37.Connection = Me.dbConn
        Me.SqlCommand37.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"), New System.Data.SqlClient.SqlParameter("@Action", System.Data.SqlDbType.NVarChar, 0, "Action"), New System.Data.SqlClient.SqlParameter("@FldShort", System.Data.SqlDbType.NVarChar, 0, "FldShort"), New System.Data.SqlClient.SqlParameter("@Chapter", System.Data.SqlDbType.NVarChar, 0, "Chapter"), New System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"), New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 0, "ID"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daMaxSelListID
        '
        Me.daMaxSelListID.SelectCommand = Me.SqlCommand40
        Me.daMaxSelListID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Table", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("MaxID", "MaxID")})})
        '
        'SqlCommand40
        '
        Me.SqlCommand40.CommandText = "SELECT        MAX(ID) AS MaxID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.tblSelListEntries"
        Me.SqlCommand40.Connection = Me.dbConn
        '
        'daMaxSelListGroupID
        '
        Me.daMaxSelListGroupID.SelectCommand = Me.SqlCommand38
        Me.daMaxSelListGroupID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Table", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("MaxID", "MaxID")})})
        '
        'SqlCommand38
        '
        Me.SqlCommand38.CommandText = "SELECT        MAX(ID) AS MaxID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.tblSelListGroup"
        Me.SqlCommand38.Connection = Me.dbConn
        '
        'davSelListEntriesObj
        '
        Me.davSelListEntriesObj.SelectCommand = Me.SqlCommand42
        Me.davSelListEntriesObj.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "vSelListEntriesObj", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSelListEntryIDRes", "IDSelListEntryIDRes"), New System.Data.Common.DataColumnMapping("IDSelListEntryIDOwnInt", "IDSelListEntryIDOwnInt"), New System.Data.Common.DataColumnMapping("IDSelListEntryIDOwnStr", "IDSelListEntryIDOwnStr"), New System.Data.Common.DataColumnMapping("IDSelListEntryIDGroupStr", "IDSelListEntryIDGroupStr"), New System.Data.Common.DataColumnMapping("IDSelListEntryIDApplication", "IDSelListEntryIDApplication"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublistIDRes", "IDSelListEntrySublistIDRes"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublistIDOwnInt", "IDSelListEntrySublistIDOwnInt"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublistIDOwnStr", "IDSelListEntrySublistIDOwnStr"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublistIDGroupStr", "IDSelListEntrySublistIDGroupStr"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublistIDApplication", "IDSelListEntrySublistIDApplication"), New System.Data.Common.DataColumnMapping("CriteriaFldShort", "CriteriaFldShort"), New System.Data.Common.DataColumnMapping("CriteriaIDApplication", "CriteriaIDApplication"), New System.Data.Common.DataColumnMapping("CriteriaControlType", "CriteriaControlType"), New System.Data.Common.DataColumnMapping("ObjectNameCombination", "ObjectNameCombination"), New System.Data.Common.DataColumnMapping("StayMedRecN", "StayMedRecN"), New System.Data.Common.DataColumnMapping("ObjTypIDGroup", "ObjTypIDGroup"), New System.Data.Common.DataColumnMapping("ObjFrom", "ObjFrom"), New System.Data.Common.DataColumnMapping("ObjTo", "ObjTo"), New System.Data.Common.DataColumnMapping("ObjIDClassification", "ObjIDClassification"), New System.Data.Common.DataColumnMapping("ObjIDOwnInt", "ObjIDOwnInt"), New System.Data.Common.DataColumnMapping("ObjCreated", "ObjCreated"), New System.Data.Common.DataColumnMapping("ObjCreatedBy", "ObjCreatedBy"), New System.Data.Common.DataColumnMapping("ObjModified", "ObjModified"), New System.Data.Common.DataColumnMapping("ObjModifiedBy", "ObjModifiedBy"), New System.Data.Common.DataColumnMapping("ObjDescription", "ObjDescription"), New System.Data.Common.DataColumnMapping("ObjSort", "ObjSort"), New System.Data.Common.DataColumnMapping("ObjIDParticipant", "ObjIDParticipant")})})
        '
        'SqlCommand42
        '
        Me.SqlCommand42.CommandText = resources.GetString("SqlCommand42.CommandText")
        Me.SqlCommand42.Connection = Me.dbConn
        '
        'daGetAllUsersWithRoles
        '
        Me.daGetAllUsersWithRoles.SelectCommand = Me.SqlCommand39
        Me.daGetAllUsersWithRoles.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getAllUsersWithRoles", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDSelListEntry", "IDSelListEntry")})})
        '
        'SqlCommand39
        '
        Me.SqlCommand39.CommandText = "SELECT        ID, IDSelListEntry" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.getAllUsersWithRoles"
        Me.SqlCommand39.Connection = Me.dbConn
        '
        'daGetButtonsForUser
        '
        Me.daGetButtonsForUser.SelectCommand = Me.SqlCommand41
        Me.daGetButtonsForUser.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getButtonsForUser", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSelListChapter", "IDSelListChapter"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject")})})
        '
        'SqlCommand41
        '
        Me.SqlCommand41.CommandText = "SELECT        qs2.getButtonsForUser.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.getButtonsForUser"
        Me.SqlCommand41.Connection = Me.dbConn
        '
        'daGetCriteriasForUser
        '
        Me.daGetCriteriasForUser.SelectCommand = Me.SqlCommand43
        Me.daGetCriteriasForUser.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getCriteriasForUser", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication")})})
        '
        'SqlCommand43
        '
        Me.SqlCommand43.CommandText = "SELECT        IDObject, FldShort, IDApplication" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.getCriterias" &
    "ForUser"
        Me.SqlCommand43.Connection = Me.dbConn
        '
        'daGetAllUsersWithRights
        '
        Me.daGetAllUsersWithRights.SelectCommand = Me.SqlCommand44
        Me.daGetAllUsersWithRights.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getAllUsersWithRights", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOwnStr", "IDOwnStr")})})
        '
        'SqlCommand44
        '
        Me.SqlCommand44.CommandText = "SELECT        ID, IDOwnStr" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.getAllUsersWithRights"
        Me.SqlCommand44.Connection = Me.dbConn
        '
        'daGetChaptersAlwaysEditableAllUsers
        '
        Me.daGetChaptersAlwaysEditableAllUsers.SelectCommand = Me.SqlCommand45
        Me.daGetChaptersAlwaysEditableAllUsers.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getAllUsersWithRoles", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSelListChapter", "IDSelListChapter"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDClassification", "IDClassification")})})
        '
        'SqlCommand45
        '
        Me.SqlCommand45.CommandText = resources.GetString("SqlCommand45.CommandText")
        Me.SqlCommand45.Connection = Me.dbConn
        '
        'daSelListEntriesSort
        '
        Me.daSelListEntriesSort.DeleteCommand = Me.SqlCommand46
        Me.daSelListEntriesSort.InsertCommand = Me.SqlCommand47
        Me.daSelListEntriesSort.SelectCommand = Me.SqlCommand48
        Me.daSelListEntriesSort.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListEntriesSort", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDSelListEntry", "IDSelListEntry"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("Sort", "Sort")})})
        Me.daSelListEntriesSort.UpdateCommand = Me.SqlCommand49
        '
        'SqlCommand46
        '
        Me.SqlCommand46.CommandText = "DELETE FROM [qs2].[tblSelListEntriesSort] WHERE (([ID] = @Original_ID))"
        Me.SqlCommand46.Connection = Me.dbConn
        Me.SqlCommand46.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand47
        '
        Me.SqlCommand47.CommandText = "INSERT INTO [qs2].[tblSelListEntriesSort] ([ID], [IDSelListEntry], [IDParticipant" &
    "], [Sort]) VALUES (@ID, @IDSelListEntry, @IDParticipant, @Sort)"
        Me.SqlCommand47.Connection = Me.dbConn
        Me.SqlCommand47.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDSelListEntry", System.Data.SqlDbType.Int, 0, "IDSelListEntry"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort")})
        '
        'SqlCommand48
        '
        Me.SqlCommand48.CommandText = "SELECT        ID, IDSelListEntry, IDParticipant, Sort" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.tblSel" &
    "ListEntriesSort"
        Me.SqlCommand48.Connection = Me.dbConn
        '
        'SqlCommand49
        '
        Me.SqlCommand49.CommandText = "UPDATE [qs2].[tblSelListEntriesSort] SET [ID] = @ID, [IDSelListEntry] = @IDSelLis" &
    "tEntry, [IDParticipant] = @IDParticipant, [Sort] = @Sort WHERE (([ID] = @Origina" &
    "l_ID))"
        Me.SqlCommand49.Connection = Me.dbConn
        Me.SqlCommand49.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"), New System.Data.SqlClient.SqlParameter("@IDSelListEntry", System.Data.SqlDbType.Int, 0, "IDSelListEntry"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daGetCriteriasUserForUser
        '
        Me.daGetCriteriasUserForUser.SelectCommand = Me.SqlCommand50
        Me.daGetCriteriasUserForUser.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "getCriteriasUserForUser", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("nVisible", "nVisible")})})
        '
        'SqlCommand50
        '
        Me.SqlCommand50.CommandText = "SELECT        IDObject, FldShort, IDApplication, nVisible" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            qs2.ge" &
    "tCriteriasUserForUser"
        Me.SqlCommand50.Connection = Me.dbConn

    End Sub
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection
    Public WithEvents daSelListEntrys As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand5 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand6 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand7 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand8 As System.Data.SqlClient.SqlCommand
    Public WithEvents daSelListGroup As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand3 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand4 As System.Data.SqlClient.SqlCommand
    Public WithEvents daSelListEntrysObj As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand13 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand14 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand15 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand16 As System.Data.SqlClient.SqlCommand
    Public WithEvents daAdjust As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Public WithEvents daCriteria As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand9 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand10 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand11 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand12 As System.Data.SqlClient.SqlCommand
    Public WithEvents daCriteriaOpt As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand17 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand18 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand19 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand20 As System.Data.SqlClient.SqlCommand
    Public WithEvents davListEntriesWithGroup As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand27 As System.Data.SqlClient.SqlCommand
    Public WithEvents daStayAdditions As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand25 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand26 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand28 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand29 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand2 As System.Data.SqlClient.SqlCommand
    Public WithEvents daRelationship As System.Data.SqlClient.SqlDataAdapter
    Public WithEvents daQueriesDef As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand21 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand22 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand23 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand24 As System.Data.SqlClient.SqlCommand
    Public WithEvents daQueryJoinsTemp As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand30 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand31 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand32 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand33 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand As System.Data.SqlClient.SqlCommand
    Public WithEvents daSideLogic As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand34 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand35 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand36 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand37 As System.Data.SqlClient.SqlCommand
    Public WithEvents daMaxSelListID As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand40 As System.Data.SqlClient.SqlCommand
    Public WithEvents daMaxSelListGroupID As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand38 As System.Data.SqlClient.SqlCommand
    Public WithEvents davSelListEntriesObj As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand42 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand As System.Data.SqlClient.SqlCommand
    Public WithEvents daGetAllUsersWithRoles As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand39 As SqlClient.SqlCommand
    Public WithEvents daGetButtonsForUser As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand41 As SqlClient.SqlCommand
    Public WithEvents daGetCriteriasForUser As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand43 As SqlClient.SqlCommand
    Public WithEvents daGetAllUsersWithRights As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand44 As SqlClient.SqlCommand
    Public WithEvents daGetChaptersAlwaysEditableAllUsers As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand45 As SqlClient.SqlCommand
    Public WithEvents daSelListEntriesSort As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand46 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand47 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand48 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand49 As SqlClient.SqlCommand
    Public WithEvents daGetCriteriasUserForUser As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand50 As SqlClient.SqlCommand
End Class
