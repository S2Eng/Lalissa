Partial Class compRecht
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        Container.Add(Me)

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
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner = New System.Data.OleDb.OleDbCommand
        Me.daRechteOrdner_IDOrdner = New System.Data.OleDb.OleDbDataAdapter
        Me.conDB = New System.Data.OleDb.OleDbConnection
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand
        Me.daRechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand
        '
        'OLEBSelectCommand_RechteOrdner_IDOrdner
        '
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner.CommandText = "SELECT     ID, IDOrdner, IDGruppe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblRechteOrdner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE     (IDOrd" & _
            "ner = ?)"
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner.Connection = Me.conDB
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")})
        '
        'daRechteOrdner_IDOrdner
        '
        Me.daRechteOrdner_IDOrdner.SelectCommand = Me.OLEBSelectCommand_RechteOrdner_IDOrdner
        Me.daRechteOrdner_IDOrdner.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblRechteOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe")})})
        '
        'conDB
        '
        Me.conDB.ConnectionString = "Provider=SQLNCLI.1;Data Source=s2sty002\test;Persist Security Info=True;Password=" & _
            "test;User ID=sa;Initial Catalog=Archiv"
        '
        'OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "SELECT     ID, IDOrdner, IDGruppe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblRechteOrdner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE     (IDOrd" & _
            "ner = ?) AND (IDGruppe = ?)"
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = Me.conDB
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")})
        '
        'daRechteOrdner_IDOrdnerIDGruppe
        '
        Me.daRechteOrdner_IDOrdnerIDGruppe.DeleteCommand = Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.InsertCommand = Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand = Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblRechteOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe")})})
        Me.daRechteOrdner_IDOrdnerIDGruppe.UpdateCommand = Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        'OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "INSERT INTO [tblRechteOrdner] ([ID], [IDOrdner], [IDGruppe]) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = Me.conDB
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDGruppe")})
        '
        'OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "UPDATE [tblRechteOrdner] SET [ID] = ?, [IDOrdner] = ?, [IDGruppe] = ? WHERE (([ID" & _
            "] = ?))"
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = Me.conDB
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDGruppe"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "DELETE FROM [tblRechteOrdner] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = Me.conDB
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub
    Friend WithEvents OLEBSelectCommand_RechteOrdner_IDOrdner As System.Data.OleDb.OleDbCommand
    Friend WithEvents conDB As System.Data.OleDb.OleDbConnection
    Friend WithEvents daRechteOrdner_IDOrdner As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe As System.Data.OleDb.OleDbCommand
    Friend WithEvents daRechteOrdner_IDOrdnerIDGruppe As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe As System.Data.OleDb.OleDbCommand

End Class
