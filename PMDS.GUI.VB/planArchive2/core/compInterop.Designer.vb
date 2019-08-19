Partial Class compInterop
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

        compInterop.daSelInterop = Me.daInterop.SelectCommand.CommandText
        compInterop.daSelInteropSmall = Me.daInteropSmall.SelectCommand.CommandText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compInterop))
        Me.daInterop = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.daInteropSmall = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        '
        'daInterop
        '
        Me.daInterop.DeleteCommand = Me.OleDbDeleteCommand2
        Me.daInterop.InsertCommand = Me.OleDbInsertCommand
        Me.daInterop.SelectCommand = Me.OleDbSelectCommand2
        Me.daInterop.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblInterop", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("createdAt", "createdAt"), New System.Data.Common.DataColumnMapping("doAt", "doAt"), New System.Data.Common.DataColumnMapping("typAction", "typAction"), New System.Data.Common.DataColumnMapping("fromUser", "fromUser"), New System.Data.Common.DataColumnMapping("fromClient", "fromClient"), New System.Data.Common.DataColumnMapping("dbPar", "dbPar"), New System.Data.Common.DataColumnMapping("done", "done"), New System.Data.Common.DataColumnMapping("doneAt", "doneAt"), New System.Data.Common.DataColumnMapping("ReplyToUser", "ReplyToUser"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("ReplyTxtDetail", "ReplyTxtDetail"), New System.Data.Common.DataColumnMapping("ReplyError", "ReplyError"), New System.Data.Common.DataColumnMapping("deleted", "deleted")})})
        Me.daInterop.UpdateCommand = Me.OleDbUpdateCommand2
        '
        'OleDbDeleteCommand2
        '
        Me.OleDbDeleteCommand2.CommandText = "DELETE FROM [tblInterop] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand2.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=ITSContDev"
        '
        'OleDbInsertCommand
        '
        Me.OleDbInsertCommand.CommandText = resources.GetString("OleDbInsertCommand.CommandText")
        Me.OleDbInsertCommand.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("createdAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "createdAt"), New System.Data.OleDb.OleDbParameter("doAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doAt"), New System.Data.OleDb.OleDbParameter("typAction", System.Data.OleDb.OleDbType.VarChar, 0, "typAction"), New System.Data.OleDb.OleDbParameter("fromUser", System.Data.OleDb.OleDbType.VarChar, 0, "fromUser"), New System.Data.OleDb.OleDbParameter("fromClient", System.Data.OleDb.OleDbType.VarChar, 0, "fromClient"), New System.Data.OleDb.OleDbParameter("dbPar", System.Data.OleDb.OleDbType.LongVarChar, 0, "dbPar"), New System.Data.OleDb.OleDbParameter("done", System.Data.OleDb.OleDbType.[Boolean], 0, "done"), New System.Data.OleDb.OleDbParameter("doneAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doneAt"), New System.Data.OleDb.OleDbParameter("ReplyToUser", System.Data.OleDb.OleDbType.[Boolean], 0, "ReplyToUser"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("ReplyTxtDetail", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxtDetail"), New System.Data.OleDb.OleDbParameter("ReplyError", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyError"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted")})
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = "SELECT        ID, createdAt, doAt, typAction, fromUser, fromClient, dbPar, done, " &
    "doneAt, ReplyToUser, ReplyTxt, ReplyTxtDetail, ReplyError, deleted" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        " &
    "    tblInterop"
        Me.OleDbSelectCommand2.Connection = Me.OleDbConnection1
        '
        'OleDbUpdateCommand2
        '
        Me.OleDbUpdateCommand2.CommandText = resources.GetString("OleDbUpdateCommand2.CommandText")
        Me.OleDbUpdateCommand2.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("createdAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "createdAt"), New System.Data.OleDb.OleDbParameter("doAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doAt"), New System.Data.OleDb.OleDbParameter("typAction", System.Data.OleDb.OleDbType.VarChar, 0, "typAction"), New System.Data.OleDb.OleDbParameter("fromUser", System.Data.OleDb.OleDbType.VarChar, 0, "fromUser"), New System.Data.OleDb.OleDbParameter("fromClient", System.Data.OleDb.OleDbType.VarChar, 0, "fromClient"), New System.Data.OleDb.OleDbParameter("dbPar", System.Data.OleDb.OleDbType.LongVarChar, 0, "dbPar"), New System.Data.OleDb.OleDbParameter("done", System.Data.OleDb.OleDbType.[Boolean], 0, "done"), New System.Data.OleDb.OleDbParameter("doneAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doneAt"), New System.Data.OleDb.OleDbParameter("ReplyToUser", System.Data.OleDb.OleDbType.[Boolean], 0, "ReplyToUser"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("ReplyTxtDetail", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxtDetail"), New System.Data.OleDb.OleDbParameter("ReplyError", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyError"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daInteropSmall
        '
        Me.daInteropSmall.DeleteCommand = Me.OleDbCommand5
        Me.daInteropSmall.InsertCommand = Me.OleDbCommand6
        Me.daInteropSmall.SelectCommand = Me.OleDbCommand7
        Me.daInteropSmall.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblInterop", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("createdAt", "createdAt"), New System.Data.Common.DataColumnMapping("doAt", "doAt"), New System.Data.Common.DataColumnMapping("typAction", "typAction"), New System.Data.Common.DataColumnMapping("fromUser", "fromUser"), New System.Data.Common.DataColumnMapping("fromClient", "fromClient"), New System.Data.Common.DataColumnMapping("dbPar", "dbPar"), New System.Data.Common.DataColumnMapping("done", "done"), New System.Data.Common.DataColumnMapping("doneAt", "doneAt"), New System.Data.Common.DataColumnMapping("ReplyToUser", "ReplyToUser"), New System.Data.Common.DataColumnMapping("ReplyTxt", "ReplyTxt"), New System.Data.Common.DataColumnMapping("deleted", "deleted")})})
        Me.daInteropSmall.UpdateCommand = Me.OleDbCommand8
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = "DELETE FROM [tblInterop] WHERE (([ID] = ?))"
        Me.OleDbCommand5.Connection = Me.OleDbConnection1
        Me.OleDbCommand5.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = "INSERT INTO [tblInterop] ([ID], [createdAt], [doAt], [typAction], [fromUser], [fr" &
    "omClient], [dbPar], [done], [doneAt], [ReplyToUser], [ReplyTxt], [deleted]) VALU" &
    "ES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbCommand6.Connection = Me.OleDbConnection1
        Me.OleDbCommand6.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("createdAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "createdAt"), New System.Data.OleDb.OleDbParameter("doAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doAt"), New System.Data.OleDb.OleDbParameter("typAction", System.Data.OleDb.OleDbType.VarChar, 0, "typAction"), New System.Data.OleDb.OleDbParameter("fromUser", System.Data.OleDb.OleDbType.VarChar, 0, "fromUser"), New System.Data.OleDb.OleDbParameter("fromClient", System.Data.OleDb.OleDbType.VarChar, 0, "fromClient"), New System.Data.OleDb.OleDbParameter("dbPar", System.Data.OleDb.OleDbType.LongVarChar, 0, "dbPar"), New System.Data.OleDb.OleDbParameter("done", System.Data.OleDb.OleDbType.[Boolean], 0, "done"), New System.Data.OleDb.OleDbParameter("doneAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doneAt"), New System.Data.OleDb.OleDbParameter("ReplyToUser", System.Data.OleDb.OleDbType.[Boolean], 0, "ReplyToUser"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted")})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = "SELECT        ID, createdAt, doAt, typAction, fromUser, fromClient, dbPar, done, " &
    "doneAt, ReplyToUser, ReplyTxt,   deleted" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblInterop"
        Me.OleDbCommand7.Connection = Me.OleDbConnection1
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = resources.GetString("OleDbCommand8.CommandText")
        Me.OleDbCommand8.Connection = Me.OleDbConnection1
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("createdAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "createdAt"), New System.Data.OleDb.OleDbParameter("doAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doAt"), New System.Data.OleDb.OleDbParameter("typAction", System.Data.OleDb.OleDbType.VarChar, 0, "typAction"), New System.Data.OleDb.OleDbParameter("fromUser", System.Data.OleDb.OleDbType.VarChar, 0, "fromUser"), New System.Data.OleDb.OleDbParameter("fromClient", System.Data.OleDb.OleDbType.VarChar, 0, "fromClient"), New System.Data.OleDb.OleDbParameter("dbPar", System.Data.OleDb.OleDbType.LongVarChar, 0, "dbPar"), New System.Data.OleDb.OleDbParameter("done", System.Data.OleDb.OleDbType.[Boolean], 0, "done"), New System.Data.OleDb.OleDbParameter("doneAt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "doneAt"), New System.Data.OleDb.OleDbParameter("ReplyToUser", System.Data.OleDb.OleDbType.[Boolean], 0, "ReplyToUser"), New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt"), New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.[Boolean], 0, "deleted"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Public WithEvents daInterop As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbConnection1 As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand2 As OleDb.OleDbCommand
    Public WithEvents daInteropSmall As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand5 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand6 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand7 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand8 As OleDb.OleDbCommand
End Class
