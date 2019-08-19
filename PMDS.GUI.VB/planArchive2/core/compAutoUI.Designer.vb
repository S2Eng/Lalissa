Partial Class compAutoUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compAutoUI))
        Me.daAutoUI = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.daRessourcen = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        '
        'daAutoUI
        '
        Me.daAutoUI.DeleteCommand = Me.OleDbDeleteCommand2
        Me.daAutoUI.InsertCommand = Me.OleDbInsertCommand2
        Me.daAutoUI.SelectCommand = Me.OleDbSelectCommand2
        Me.daAutoUI.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "autoUI", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDUI", "IDUI"), New System.Data.Common.DataColumnMapping("IDResAlias", "IDResAlias"), New System.Data.Common.DataColumnMapping("ControlType", "ControlType"), New System.Data.Common.DataColumnMapping("TableName", "TableName"), New System.Data.Common.DataColumnMapping("ColumnName", "ColumnName"), New System.Data.Common.DataColumnMapping("ToolTipTitleIDRes", "ToolTipTitleIDRes"), New System.Data.Common.DataColumnMapping("ToolTipTextIDRes", "ToolTipTextIDRes"), New System.Data.Common.DataColumnMapping("Visible", "Visible"), New System.Data.Common.DataColumnMapping("Enabled", "Enabled"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser")})})
        Me.daAutoUI.UpdateCommand = Me.OleDbUpdateCommand2
        '
        'OleDbDeleteCommand2
        '
        Me.OleDbDeleteCommand2.CommandText = "DELETE FROM [autoUI] WHERE (([IDUI] = ?))"
        Me.OleDbDeleteCommand2.Connection = Me.dbConn
        Me.OleDbDeleteCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_IDUI", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDUI", System.Data.DataRowVersion.Original, Nothing)})
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02\SQL2008R2;Integrated Security=SSPI;Initia" &
    "l Catalog=ITSContDev"
        '
        'OleDbInsertCommand2
        '
        Me.OleDbInsertCommand2.CommandText = resources.GetString("OleDbInsertCommand2.CommandText")
        Me.OleDbInsertCommand2.Connection = Me.dbConn
        Me.OleDbInsertCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDUI", System.Data.OleDb.OleDbType.VarWChar, 0, "IDUI"), New System.Data.OleDb.OleDbParameter("IDResAlias", System.Data.OleDb.OleDbType.VarWChar, 0, "IDResAlias"), New System.Data.OleDb.OleDbParameter("ControlType", System.Data.OleDb.OleDbType.VarWChar, 0, "ControlType"), New System.Data.OleDb.OleDbParameter("TableName", System.Data.OleDb.OleDbType.VarWChar, 0, "TableName"), New System.Data.OleDb.OleDbParameter("ColumnName", System.Data.OleDb.OleDbType.VarWChar, 0, "ColumnName"), New System.Data.OleDb.OleDbParameter("ToolTipTitleIDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "ToolTipTitleIDRes"), New System.Data.OleDb.OleDbParameter("ToolTipTextIDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "ToolTipTextIDRes"), New System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.[Boolean], 0, "Visible"), New System.Data.OleDb.OleDbParameter("Enabled", System.Data.OleDb.OleDbType.[Boolean], 0, "Enabled"), New System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"), New System.Data.OleDb.OleDbParameter("Created", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Created"), New System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedUser")})
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = "SELECT        IDUI, IDResAlias, ControlType, TableName, ColumnName, ToolTipTitleI" &
    "DRes, ToolTipTextIDRes, Visible, Enabled, Description, Created, CreatedUser" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FRO" &
    "M            autoUI"
        Me.OleDbSelectCommand2.Connection = Me.dbConn
        '
        'OleDbUpdateCommand2
        '
        Me.OleDbUpdateCommand2.CommandText = resources.GetString("OleDbUpdateCommand2.CommandText")
        Me.OleDbUpdateCommand2.Connection = Me.dbConn
        Me.OleDbUpdateCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDUI", System.Data.OleDb.OleDbType.VarWChar, 0, "IDUI"), New System.Data.OleDb.OleDbParameter("IDResAlias", System.Data.OleDb.OleDbType.VarWChar, 0, "IDResAlias"), New System.Data.OleDb.OleDbParameter("ControlType", System.Data.OleDb.OleDbType.VarWChar, 0, "ControlType"), New System.Data.OleDb.OleDbParameter("TableName", System.Data.OleDb.OleDbType.VarWChar, 0, "TableName"), New System.Data.OleDb.OleDbParameter("ColumnName", System.Data.OleDb.OleDbType.VarWChar, 0, "ColumnName"), New System.Data.OleDb.OleDbParameter("ToolTipTitleIDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "ToolTipTitleIDRes"), New System.Data.OleDb.OleDbParameter("ToolTipTextIDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "ToolTipTextIDRes"), New System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.[Boolean], 0, "Visible"), New System.Data.OleDb.OleDbParameter("Enabled", System.Data.OleDb.OleDbType.[Boolean], 0, "Enabled"), New System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"), New System.Data.OleDb.OleDbParameter("Created", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Created"), New System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedUser"), New System.Data.OleDb.OleDbParameter("Original_IDUI", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDUI", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daRessourcen
        '
        Me.daRessourcen.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daRessourcen.InsertCommand = Me.OleDbInsertCommand1
        Me.daRessourcen.SelectCommand = Me.OleDbSelectCommand1
        Me.daRessourcen.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Ressourcen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDRes", "IDRes"), New System.Data.Common.DataColumnMapping("English", "English"), New System.Data.Common.DataColumnMapping("German", "German"), New System.Data.Common.DataColumnMapping("User", "User"), New System.Data.Common.DataColumnMapping("IDLanguageUser", "IDLanguageUser"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("TypeSub", "TypeSub"), New System.Data.Common.DataColumnMapping("fileBytes", "fileBytes"), New System.Data.Common.DataColumnMapping("fileType", "fileType"), New System.Data.Common.DataColumnMapping("Created", "Created"), New System.Data.Common.DataColumnMapping("Changed", "Changed"), New System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser"), New System.Data.Common.DataColumnMapping("autoNr", "autoNr"), New System.Data.Common.DataColumnMapping("TableName", "TableName"), New System.Data.Common.DataColumnMapping("ColumnName", "ColumnName")})})
        Me.daRessourcen.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [Ressourcen] WHERE (([IDRes] = ?) AND ([IDLanguageUser] = ?) AND ([ID" &
    "Application] = ?) AND ([IDParticipant] = ?) AND ([Type] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.dbConn
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_IDRes", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDRes", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDLanguageUser", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDLanguageUser", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDApplication", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDParticipant", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDParticipant", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Type", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Type", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.dbConn
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "IDRes"), New System.Data.OleDb.OleDbParameter("English", System.Data.OleDb.OleDbType.LongVarWChar, 0, "English"), New System.Data.OleDb.OleDbParameter("German", System.Data.OleDb.OleDbType.LongVarWChar, 0, "German"), New System.Data.OleDb.OleDbParameter("User", System.Data.OleDb.OleDbType.LongVarWChar, 0, "User"), New System.Data.OleDb.OleDbParameter("IDLanguageUser", System.Data.OleDb.OleDbType.VarWChar, 0, "IDLanguageUser"), New System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"), New System.Data.OleDb.OleDbParameter("IDApplication", System.Data.OleDb.OleDbType.VarWChar, 0, "IDApplication"), New System.Data.OleDb.OleDbParameter("IDParticipant", System.Data.OleDb.OleDbType.VarWChar, 0, "IDParticipant"), New System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 0, "Type"), New System.Data.OleDb.OleDbParameter("TypeSub", System.Data.OleDb.OleDbType.VarWChar, 0, "TypeSub"), New System.Data.OleDb.OleDbParameter("fileBytes", System.Data.OleDb.OleDbType.LongVarBinary, 0, "fileBytes"), New System.Data.OleDb.OleDbParameter("fileType", System.Data.OleDb.OleDbType.VarWChar, 0, "fileType"), New System.Data.OleDb.OleDbParameter("Created", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Created"), New System.Data.OleDb.OleDbParameter("Changed", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Changed"), New System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedUser"), New System.Data.OleDb.OleDbParameter("TableName", System.Data.OleDb.OleDbType.VarWChar, 0, "TableName"), New System.Data.OleDb.OleDbParameter("ColumnName", System.Data.OleDb.OleDbType.VarWChar, 0, "ColumnName")})
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
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDRes", System.Data.OleDb.OleDbType.VarWChar, 0, "IDRes"), New System.Data.OleDb.OleDbParameter("English", System.Data.OleDb.OleDbType.LongVarWChar, 0, "English"), New System.Data.OleDb.OleDbParameter("German", System.Data.OleDb.OleDbType.LongVarWChar, 0, "German"), New System.Data.OleDb.OleDbParameter("User", System.Data.OleDb.OleDbType.LongVarWChar, 0, "User"), New System.Data.OleDb.OleDbParameter("IDLanguageUser", System.Data.OleDb.OleDbType.VarWChar, 0, "IDLanguageUser"), New System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"), New System.Data.OleDb.OleDbParameter("IDApplication", System.Data.OleDb.OleDbType.VarWChar, 0, "IDApplication"), New System.Data.OleDb.OleDbParameter("IDParticipant", System.Data.OleDb.OleDbType.VarWChar, 0, "IDParticipant"), New System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 0, "Type"), New System.Data.OleDb.OleDbParameter("TypeSub", System.Data.OleDb.OleDbType.VarWChar, 0, "TypeSub"), New System.Data.OleDb.OleDbParameter("fileBytes", System.Data.OleDb.OleDbType.LongVarBinary, 0, "fileBytes"), New System.Data.OleDb.OleDbParameter("fileType", System.Data.OleDb.OleDbType.VarWChar, 0, "fileType"), New System.Data.OleDb.OleDbParameter("Created", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Created"), New System.Data.OleDb.OleDbParameter("Changed", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Changed"), New System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.VarWChar, 0, "CreatedUser"), New System.Data.OleDb.OleDbParameter("TableName", System.Data.OleDb.OleDbType.VarWChar, 0, "TableName"), New System.Data.OleDb.OleDbParameter("ColumnName", System.Data.OleDb.OleDbType.VarWChar, 0, "ColumnName"), New System.Data.OleDb.OleDbParameter("Original_IDRes", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDRes", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDLanguageUser", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDLanguageUser", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDApplication", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDApplication", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDParticipant", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDParticipant", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Type", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Type", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Public WithEvents daAutoUI As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand2 As OleDb.OleDbCommand
    Friend WithEvents dbConn As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand2 As OleDb.OleDbCommand
    Public WithEvents daRessourcen As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As OleDb.OleDbCommand
End Class
