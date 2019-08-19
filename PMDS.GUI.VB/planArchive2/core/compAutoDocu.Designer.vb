Partial Class compAutoDocu
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
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

        Me.sqldaAutoDocu = Me.daAutoDocu.SelectCommand.CommandText
        Me.sqldaTextTemplates = Me.daTextTemplates.SelectCommand.CommandText
        Me.sqldaTextTemplatesFiles = Me.daTextTemplatesFiles.SelectCommand.CommandText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compAutoDocu))
        Me.daAutoDocu = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand = New System.Data.OleDb.OleDbCommand()
        Me.conITSCont = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_GeschäftspartnerNr_IDObject = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand = New System.Data.OleDb.OleDbCommand()
        Me.daTextTemplates = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        Me.daTextTemplatesFiles = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        '
        'daAutoDocu
        '
        Me.daAutoDocu.DeleteCommand = Me.OleDbDeleteCommand
        Me.daAutoDocu.InsertCommand = Me.OleDbInsertCommand
        Me.daAutoDocu.SelectCommand = Me.OleDbSelectCommand_GeschäftspartnerNr_IDObject
        Me.daAutoDocu.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblAutoDoku", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("typ", "typ"), New System.Data.Common.DataColumnMapping("docuRtf", "docuRtf"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Html", "Html"), New System.Data.Common.DataColumnMapping("Txt", "Txt"), New System.Data.Common.DataColumnMapping("IDResTitle", "IDResTitle"), New System.Data.Common.DataColumnMapping("Language", "Language")})})
        Me.daAutoDocu.UpdateCommand = Me.OleDbUpdateCommand
        '
        'OleDbDeleteCommand
        '
        Me.OleDbDeleteCommand.CommandText = "DELETE FROM [tblAutoDoku] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand.Connection = Me.conITSCont
        Me.OleDbDeleteCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'conITSCont
        '
        Me.conITSCont.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=PMDSDev"
        '
        'OleDbInsertCommand
        '
        Me.OleDbInsertCommand.CommandText = "INSERT INTO [tblAutoDoku] ([ID], [typ], [docuRtf], [ErstelltAm], [ErstelltVon], [" &
    "Html], [Txt], [IDResTitle], [Language]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand.Connection = Me.conITSCont
        Me.OleDbInsertCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("docuRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "docuRtf"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Html", System.Data.OleDb.OleDbType.LongVarChar, 0, "Html"), New System.Data.OleDb.OleDbParameter("Txt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Txt"), New System.Data.OleDb.OleDbParameter("IDResTitle", System.Data.OleDb.OleDbType.VarChar, 0, "IDResTitle"), New System.Data.OleDb.OleDbParameter("Language", System.Data.OleDb.OleDbType.VarChar, 0, "Language")})
        '
        'OleDbSelectCommand_GeschäftspartnerNr_IDObject
        '
        Me.OleDbSelectCommand_GeschäftspartnerNr_IDObject.CommandText = "SELECT        ID, typ, docuRtf, ErstelltAm, ErstelltVon, Html, Txt, IDResTitle, L" &
    "anguage" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblAutoDoku"
        Me.OleDbSelectCommand_GeschäftspartnerNr_IDObject.Connection = Me.conITSCont
        '
        'OleDbUpdateCommand
        '
        Me.OleDbUpdateCommand.CommandText = "UPDATE [tblAutoDoku] SET [ID] = ?, [typ] = ?, [docuRtf] = ?, [ErstelltAm] = ?, [E" &
    "rstelltVon] = ?, [Html] = ?, [Txt] = ?, [IDResTitle] = ?, [Language] = ? WHERE (" &
    "([ID] = ?))"
        Me.OleDbUpdateCommand.Connection = Me.conITSCont
        Me.OleDbUpdateCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("docuRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "docuRtf"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Html", System.Data.OleDb.OleDbType.LongVarChar, 0, "Html"), New System.Data.OleDb.OleDbParameter("Txt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Txt"), New System.Data.OleDb.OleDbParameter("IDResTitle", System.Data.OleDb.OleDbType.VarChar, 0, "IDResTitle"), New System.Data.OleDb.OleDbParameter("Language", System.Data.OleDb.OleDbType.VarChar, 0, "Language"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daTextTemplates
        '
        Me.daTextTemplates.DeleteCommand = Me.OleDbCommand1
        Me.daTextTemplates.InsertCommand = Me.OleDbCommand2
        Me.daTextTemplates.SelectCommand = Me.OleDbCommand3
        Me.daTextTemplates.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblTextTemplates", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Txt", "Txt"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Betreff", "Betreff"), New System.Data.Common.DataColumnMapping("An", "An"), New System.Data.Common.DataColumnMapping("CC", "CC"), New System.Data.Common.DataColumnMapping("BCC", "BCC"), New System.Data.Common.DataColumnMapping("FromPostfach", "FromPostfach"), New System.Data.Common.DataColumnMapping("lstIDPatienten", "lstIDPatienten"), New System.Data.Common.DataColumnMapping("lstIDBenutzer", "lstIDBenutzer"), New System.Data.Common.DataColumnMapping("lstCategories", "lstCategories")})})
        Me.daTextTemplates.UpdateCommand = Me.OleDbCommand4
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "DELETE FROM [tblTextTemplates] WHERE (([ID] = ?))"
        Me.OleDbCommand1.Connection = Me.conITSCont
        Me.OleDbCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = resources.GetString("OleDbCommand2.CommandText")
        Me.OleDbCommand2.Connection = Me.conITSCont
        Me.OleDbCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarWChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Txt", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Txt"), New System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 0, "Type"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarWChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarWChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("An", System.Data.OleDb.OleDbType.LongVarWChar, 0, "An"), New System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.LongVarWChar, 0, "CC"), New System.Data.OleDb.OleDbParameter("BCC", System.Data.OleDb.OleDbType.LongVarWChar, 0, "BCC"), New System.Data.OleDb.OleDbParameter("FromPostfach", System.Data.OleDb.OleDbType.LongVarWChar, 0, "FromPostfach"), New System.Data.OleDb.OleDbParameter("lstIDPatienten", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDPatienten"), New System.Data.OleDb.OleDbParameter("lstIDBenutzer", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBenutzer"), New System.Data.OleDb.OleDbParameter("lstCategories", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstCategories")})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = "SELECT        ID, Bezeichnung, Txt, Type, ErstelltAm, ErstelltVon, Betreff, An, C" &
    "C, BCC, FromPostfach, lstIDPatienten, lstIDBenutzer, lstCategories" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        " &
    "    tblTextTemplates"
        Me.OleDbCommand3.Connection = Me.conITSCont
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = resources.GetString("OleDbCommand4.CommandText")
        Me.OleDbCommand4.Connection = Me.conITSCont
        Me.OleDbCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarWChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Txt", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Txt"), New System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 0, "Type"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarWChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Betreff", System.Data.OleDb.OleDbType.VarWChar, 0, "Betreff"), New System.Data.OleDb.OleDbParameter("An", System.Data.OleDb.OleDbType.LongVarWChar, 0, "An"), New System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.LongVarWChar, 0, "CC"), New System.Data.OleDb.OleDbParameter("BCC", System.Data.OleDb.OleDbType.LongVarWChar, 0, "BCC"), New System.Data.OleDb.OleDbParameter("FromPostfach", System.Data.OleDb.OleDbType.LongVarWChar, 0, "FromPostfach"), New System.Data.OleDb.OleDbParameter("lstIDPatienten", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDPatienten"), New System.Data.OleDb.OleDbParameter("lstIDBenutzer", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBenutzer"), New System.Data.OleDb.OleDbParameter("lstCategories", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstCategories"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daTextTemplatesFiles
        '
        Me.daTextTemplatesFiles.DeleteCommand = Me.OleDbCommand5
        Me.daTextTemplatesFiles.InsertCommand = Me.OleDbCommand6
        Me.daTextTemplatesFiles.SelectCommand = Me.OleDbCommand7
        Me.daTextTemplatesFiles.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblTextTemplatesFiles", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDTextTemplate", "IDTextTemplate"), New System.Data.Common.DataColumnMapping("Docu", "Docu"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("FileType", "FileType")})})
        Me.daTextTemplatesFiles.UpdateCommand = Me.OleDbCommand8
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = "DELETE FROM [tblTextTemplatesFiles] WHERE (([ID] = ?))"
        Me.OleDbCommand5.Connection = Me.conITSCont
        Me.OleDbCommand5.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = "INSERT INTO [tblTextTemplatesFiles] ([ID], [IDTextTemplate], [Docu], [Bezeichnung" &
    "], [FileType]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbCommand6.Connection = Me.conITSCont
        Me.OleDbCommand6.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDTextTemplate", System.Data.OleDb.OleDbType.Guid, 0, "IDTextTemplate"), New System.Data.OleDb.OleDbParameter("Docu", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Docu"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarWChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("FileType", System.Data.OleDb.OleDbType.VarWChar, 0, "FileType")})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = "SELECT        ID, IDTextTemplate, Docu, Bezeichnung, FileType" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tb" &
    "lTextTemplatesFiles"
        Me.OleDbCommand7.Connection = Me.conITSCont
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = "UPDATE [tblTextTemplatesFiles] SET [ID] = ?, [IDTextTemplate] = ?, [Docu] = ?, [B" &
    "ezeichnung] = ?, [FileType] = ? WHERE (([ID] = ?))"
        Me.OleDbCommand8.Connection = Me.conITSCont
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDTextTemplate", System.Data.OleDb.OleDbType.Guid, 0, "IDTextTemplate"), New System.Data.OleDb.OleDbParameter("Docu", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Docu"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarWChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("FileType", System.Data.OleDb.OleDbType.VarWChar, 0, "FileType"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Public WithEvents daAutoDocu As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand As OleDb.OleDbCommand
    Friend WithEvents conITSCont As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_GeschäftspartnerNr_IDObject As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand As OleDb.OleDbCommand
    Public WithEvents daTextTemplates As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand4 As OleDb.OleDbCommand
    Public WithEvents daTextTemplatesFiles As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand5 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand6 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand7 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand8 As OleDb.OleDbCommand
End Class
