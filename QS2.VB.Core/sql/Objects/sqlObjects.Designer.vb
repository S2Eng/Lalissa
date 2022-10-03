Partial Class sqlObjects
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlObjects))
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.daObject = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlInsertCommand = New System.Data.SqlClient.SqlCommand()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText")
        Me.SqlSelectCommand1.Connection = Me.dbConn
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Data Source=STYSRV10V;Initial Catalog=QS2_DEV;Integrated Security=True"
        Me.dbConn.FireInfoMessageEventOnUserErrors = False
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.dbConn
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 0, "FirstName"), New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 0, "LastName"), New System.Data.SqlClient.SqlParameter("@NameCombination", System.Data.SqlDbType.NVarChar, 0, "NameCombination"), New System.Data.SqlClient.SqlParameter("@IsPatient", System.Data.SqlDbType.Bit, 0, "IsPatient"), New System.Data.SqlClient.SqlParameter("@IsPersonal", System.Data.SqlDbType.Bit, 0, "IsPersonal"), New System.Data.SqlClient.SqlParameter("@IsUser", System.Data.SqlDbType.Bit, 0, "IsUser"), New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 0, "Title"), New System.Data.SqlClient.SqlParameter("@DOB", System.Data.SqlDbType.DateTime, 0, "DOB"), New System.Data.SqlClient.SqlParameter("@Role", System.Data.SqlDbType.Int, 0, "Role"), New System.Data.SqlClient.SqlParameter("@Gender", System.Data.SqlDbType.Int, 0, "Gender"), New System.Data.SqlClient.SqlParameter("@Race", System.Data.SqlDbType.Int, 0, "Race"), New System.Data.SqlClient.SqlParameter("@SSN", System.Data.SqlDbType.NVarChar, 0, "SSN"), New System.Data.SqlClient.SqlParameter("@IsJehova", System.Data.SqlDbType.Int, 0, "IsJehova"), New System.Data.SqlClient.SqlParameter("@KavVidierungPwd", System.Data.SqlDbType.NVarChar, 0, "KavVidierungPwd"), New System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName"), New System.Data.SqlClient.SqlParameter("@isAdmin", System.Data.SqlDbType.Bit, 0, "isAdmin"), New System.Data.SqlClient.SqlParameter("@UserShort", System.Data.SqlDbType.NVarChar, 0, "UserShort"), New System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 0, "Password"), New System.Data.SqlClient.SqlParameter("@Domain", System.Data.SqlDbType.NVarChar, 0, "Domain"), New System.Data.SqlClient.SqlParameter("@UserNameDomain", System.Data.SqlDbType.NVarChar, 0, "UserNameDomain"), New System.Data.SqlClient.SqlParameter("@IsImported", System.Data.SqlDbType.Bit, 0, "IsImported"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@ExtID", System.Data.SqlDbType.NVarChar, 0, "ExtID"), New System.Data.SqlClient.SqlParameter("@Active", System.Data.SqlDbType.Bit, 0, "Active"), New System.Data.SqlClient.SqlParameter("@CreatedUserID", System.Data.SqlDbType.NVarChar, 0, "CreatedUserID"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@MtStat", System.Data.SqlDbType.Int, 0, "MtStat"), New System.Data.SqlClient.SqlParameter("@MtDate", System.Data.SqlDbType.DateTime, 0, "MtDate"), New System.Data.SqlClient.SqlParameter("@MTLocatn", System.Data.SqlDbType.Int, 0, "MTLocatn"), New System.Data.SqlClient.SqlParameter("@MtCause", System.Data.SqlDbType.Int, 0, "MtCause"), New System.Data.SqlClient.SqlParameter("@ICD9", System.Data.SqlDbType.NVarChar, 0, "ICD9"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@PatOrigin", System.Data.SqlDbType.Int, 0, "PatOrigin"), New System.Data.SqlClient.SqlParameter("@MtCauseDescription", System.Data.SqlDbType.NVarChar, 0, "MtCauseDescription"), New System.Data.SqlClient.SqlParameter("@Systemuser", System.Data.SqlDbType.Bit, 0, "Systemuser"), New System.Data.SqlClient.SqlParameter("@CongenitalData", System.Data.SqlDbType.NVarChar, 0, "CongenitalData"), New System.Data.SqlClient.SqlParameter("@ConAntDiag", System.Data.SqlDbType.Bit, 0, "ConAntDiag"), New System.Data.SqlClient.SqlParameter("@ConGestAge", System.Data.SqlDbType.Int, 0, "ConGestAge"), New System.Data.SqlClient.SqlParameter("@UserCode", System.Data.SqlDbType.NVarChar, 0, "UserCode"), New System.Data.SqlClient.SqlParameter("@ExtIDNr", System.Data.SqlDbType.Int, 0, "ExtIDNr"), New System.Data.SqlClient.SqlParameter("@MaidenName", System.Data.SqlDbType.NVarChar, 0, "MaidenName"), New System.Data.SqlClient.SqlParameter("@BPKZ", System.Data.SqlDbType.NVarChar, 0, "BPKZ"), New System.Data.SqlClient.SqlParameter("@BPKZ1", System.Data.SqlDbType.NVarChar, 0, "BPKZ1"), New System.Data.SqlClient.SqlParameter("@BPKZ2", System.Data.SqlDbType.NVarChar, 0, "BPKZ2"), New System.Data.SqlClient.SqlParameter("@ShowUpdateNewsAtStartup", System.Data.SqlDbType.Bit, 0, "ShowUpdateNewsAtStartup"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM [qs2].[tblObject] WHERE (([ID] = @Original_ID))"
        Me.SqlDeleteCommand1.Connection = Me.dbConn
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daObject
        '
        Me.daObject.DeleteCommand = Me.SqlDeleteCommand1
        Me.daObject.InsertCommand = Me.SqlInsertCommand
        Me.daObject.SelectCommand = Me.SqlSelectCommand1
        Me.daObject.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblObject", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("NameCombination", "NameCombination"), New System.Data.Common.DataColumnMapping("IsPatient", "IsPatient"), New System.Data.Common.DataColumnMapping("IsPersonal", "IsPersonal"), New System.Data.Common.DataColumnMapping("IsUser", "IsUser"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("DOB", "DOB"), New System.Data.Common.DataColumnMapping("Role", "Role"), New System.Data.Common.DataColumnMapping("Gender", "Gender"), New System.Data.Common.DataColumnMapping("Race", "Race"), New System.Data.Common.DataColumnMapping("SSN", "SSN"), New System.Data.Common.DataColumnMapping("IsJehova", "IsJehova"), New System.Data.Common.DataColumnMapping("KavVidierungPwd", "KavVidierungPwd"), New System.Data.Common.DataColumnMapping("UserName", "UserName"), New System.Data.Common.DataColumnMapping("isAdmin", "isAdmin"), New System.Data.Common.DataColumnMapping("UserShort", "UserShort"), New System.Data.Common.DataColumnMapping("Password", "Password"), New System.Data.Common.DataColumnMapping("Domain", "Domain"), New System.Data.Common.DataColumnMapping("UserNameDomain", "UserNameDomain"), New System.Data.Common.DataColumnMapping("IsImported", "IsImported"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("ExtID", "ExtID"), New System.Data.Common.DataColumnMapping("Active", "Active"), New System.Data.Common.DataColumnMapping("CreatedUserID", "CreatedUserID"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("MtStat", "MtStat"), New System.Data.Common.DataColumnMapping("MtDate", "MtDate"), New System.Data.Common.DataColumnMapping("MTLocatn", "MTLocatn"), New System.Data.Common.DataColumnMapping("MtCause", "MtCause"), New System.Data.Common.DataColumnMapping("ICD9", "ICD9"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("PatOrigin", "PatOrigin"), New System.Data.Common.DataColumnMapping("MtCauseDescription", "MtCauseDescription"), New System.Data.Common.DataColumnMapping("Systemuser", "Systemuser"), New System.Data.Common.DataColumnMapping("CongenitalData", "CongenitalData"), New System.Data.Common.DataColumnMapping("ConAntDiag", "ConAntDiag"), New System.Data.Common.DataColumnMapping("ConGestAge", "ConGestAge"), New System.Data.Common.DataColumnMapping("UserCode", "UserCode"), New System.Data.Common.DataColumnMapping("ExtIDNr", "ExtIDNr"), New System.Data.Common.DataColumnMapping("MaidenName", "MaidenName"), New System.Data.Common.DataColumnMapping("BPKZ", "BPKZ"), New System.Data.Common.DataColumnMapping("BPKZ1", "BPKZ1"), New System.Data.Common.DataColumnMapping("BPKZ2", "BPKZ2"), New System.Data.Common.DataColumnMapping("ShowUpdateNewsAtStartup", "ShowUpdateNewsAtStartup")})})
        Me.daObject.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlInsertCommand
        '
        Me.SqlInsertCommand.CommandText = resources.GetString("SqlInsertCommand.CommandText")
        Me.SqlInsertCommand.Connection = Me.dbConn
        Me.SqlInsertCommand.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 0, "FirstName"), New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 0, "LastName"), New System.Data.SqlClient.SqlParameter("@NameCombination", System.Data.SqlDbType.NVarChar, 0, "NameCombination"), New System.Data.SqlClient.SqlParameter("@IsPatient", System.Data.SqlDbType.Bit, 0, "IsPatient"), New System.Data.SqlClient.SqlParameter("@IsPersonal", System.Data.SqlDbType.Bit, 0, "IsPersonal"), New System.Data.SqlClient.SqlParameter("@IsUser", System.Data.SqlDbType.Bit, 0, "IsUser"), New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 0, "Title"), New System.Data.SqlClient.SqlParameter("@DOB", System.Data.SqlDbType.DateTime, 0, "DOB"), New System.Data.SqlClient.SqlParameter("@Role", System.Data.SqlDbType.Int, 0, "Role"), New System.Data.SqlClient.SqlParameter("@Gender", System.Data.SqlDbType.Int, 0, "Gender"), New System.Data.SqlClient.SqlParameter("@Race", System.Data.SqlDbType.Int, 0, "Race"), New System.Data.SqlClient.SqlParameter("@SSN", System.Data.SqlDbType.NVarChar, 0, "SSN"), New System.Data.SqlClient.SqlParameter("@IsJehova", System.Data.SqlDbType.Int, 0, "IsJehova"), New System.Data.SqlClient.SqlParameter("@KavVidierungPwd", System.Data.SqlDbType.NVarChar, 0, "KavVidierungPwd"), New System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName"), New System.Data.SqlClient.SqlParameter("@isAdmin", System.Data.SqlDbType.Bit, 0, "isAdmin"), New System.Data.SqlClient.SqlParameter("@UserShort", System.Data.SqlDbType.NVarChar, 0, "UserShort"), New System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 0, "Password"), New System.Data.SqlClient.SqlParameter("@Domain", System.Data.SqlDbType.NVarChar, 0, "Domain"), New System.Data.SqlClient.SqlParameter("@UserNameDomain", System.Data.SqlDbType.NVarChar, 0, "UserNameDomain"), New System.Data.SqlClient.SqlParameter("@IsImported", System.Data.SqlDbType.Bit, 0, "IsImported"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@ExtID", System.Data.SqlDbType.NVarChar, 0, "ExtID"), New System.Data.SqlClient.SqlParameter("@Active", System.Data.SqlDbType.Bit, 0, "Active"), New System.Data.SqlClient.SqlParameter("@CreatedUserID", System.Data.SqlDbType.NVarChar, 0, "CreatedUserID"), New System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"), New System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"), New System.Data.SqlClient.SqlParameter("@MtStat", System.Data.SqlDbType.Int, 0, "MtStat"), New System.Data.SqlClient.SqlParameter("@MtDate", System.Data.SqlDbType.DateTime, 0, "MtDate"), New System.Data.SqlClient.SqlParameter("@MTLocatn", System.Data.SqlDbType.Int, 0, "MTLocatn"), New System.Data.SqlClient.SqlParameter("@MtCause", System.Data.SqlDbType.Int, 0, "MtCause"), New System.Data.SqlClient.SqlParameter("@ICD9", System.Data.SqlDbType.NVarChar, 0, "ICD9"), New System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"), New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"), New System.Data.SqlClient.SqlParameter("@PatOrigin", System.Data.SqlDbType.Int, 0, "PatOrigin"), New System.Data.SqlClient.SqlParameter("@MtCauseDescription", System.Data.SqlDbType.NVarChar, 0, "MtCauseDescription"), New System.Data.SqlClient.SqlParameter("@Systemuser", System.Data.SqlDbType.Bit, 0, "Systemuser"), New System.Data.SqlClient.SqlParameter("@CongenitalData", System.Data.SqlDbType.NVarChar, 0, "CongenitalData"), New System.Data.SqlClient.SqlParameter("@ConAntDiag", System.Data.SqlDbType.Bit, 0, "ConAntDiag"), New System.Data.SqlClient.SqlParameter("@ConGestAge", System.Data.SqlDbType.Int, 0, "ConGestAge"), New System.Data.SqlClient.SqlParameter("@UserCode", System.Data.SqlDbType.NVarChar, 0, "UserCode"), New System.Data.SqlClient.SqlParameter("@ExtIDNr", System.Data.SqlDbType.Int, 0, "ExtIDNr"), New System.Data.SqlClient.SqlParameter("@MaidenName", System.Data.SqlDbType.NVarChar, 0, "MaidenName"), New System.Data.SqlClient.SqlParameter("@BPKZ", System.Data.SqlDbType.NVarChar, 0, "BPKZ"), New System.Data.SqlClient.SqlParameter("@BPKZ1", System.Data.SqlDbType.NVarChar, 0, "BPKZ1"), New System.Data.SqlClient.SqlParameter("@BPKZ2", System.Data.SqlDbType.NVarChar, 0, "BPKZ2"), New System.Data.SqlClient.SqlParameter("@ShowUpdateNewsAtStartup", System.Data.SqlDbType.Bit, 0, "ShowUpdateNewsAtStartup")})

    End Sub
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Public WithEvents daObject As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlInsertCommand As System.Data.SqlClient.SqlCommand
End Class
