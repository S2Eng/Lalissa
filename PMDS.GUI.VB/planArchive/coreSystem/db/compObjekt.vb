

Public Class compTypObjekt
    Inherits System.ComponentModel.Component


    Private gen As New GeneralArchiv
    Public Enum eTyp
        guid = 0
        str = 1
        int = 2
    End Enum


#Region " Vom Component Designer generierter Code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Für Support von Windows.Forms-Klassenkompositions-Designer
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Komponenten-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Komponenten-Designer erforderlich
    'Sie kann mit dem Komponenten-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents daObjects_IDDokumenteintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_IDDokumenteintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_IDDokumenteintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_IDDokumenteintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_IDDokumenteintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents conArchiv As System.Data.OleDb.OleDbConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compTypObjekt))
        Me.daObjects_IDDokumenteintrag = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand
        Me.conArchiv = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand
        '
        'daObjects_IDDokumenteintrag
        '
        Me.daObjects_IDDokumenteintrag.DeleteCommand = Me.OleDbDeleteCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.InsertCommand = Me.OleDbInsertCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblObjekt", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("Datenbankidentität", "Datenbankidentität"), New System.Data.Common.DataColumnMapping("Server", "Server"), New System.Data.Common.DataColumnMapping("Datenbank", "Datenbank"), New System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"), New System.Data.Common.DataColumnMapping("Passwort", "Passwort"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("ID_guid", "ID_guid"), New System.Data.Common.DataColumnMapping("ID_str", "ID_str"), New System.Data.Common.DataColumnMapping("ID_int", "ID_int"), New System.Data.Common.DataColumnMapping("bezeichnung", "bezeichnung")})})
        Me.daObjects_IDDokumenteintrag.UpdateCommand = Me.OleDbUpdateCommand_IDDokumenteintrag
        '
        'OleDbDeleteCommand_IDDokumenteintrag
        '
        Me.OleDbDeleteCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbDeleteCommand_IDDokumenteintrag.CommandText")
        Me.OleDbDeleteCommand_IDDokumenteintrag.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDDokumenteintrag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbankidentität", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Server", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Server", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Datenbank", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Benutzer", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Passwort", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Passwort", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDTyp", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_guid", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_guid", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_str", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_str", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "bezeichnung", System.Data.DataRowVersion.Original, Nothing)})
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "Provider=SQLNCLI.1;Data Source=S2STY002\TEST;Persist Security Info=True;Password=" & _
            "test;User ID=sa;Initial Catalog=pmdsArchivPl"
        '
        'OleDbInsertCommand_IDDokumenteintrag
        '
        Me.OleDbInsertCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbInsertCommand_IDDokumenteintrag.CommandText")
        Me.OleDbInsertCommand_IDDokumenteintrag.Connection = Me.conArchiv
        Me.OleDbInsertCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, "Datenbankidentität"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, "Datenbank"), New System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"), New System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("ID_guid", System.Data.OleDb.OleDbType.Guid, 0, "ID_guid"), New System.Data.OleDb.OleDbParameter("ID_str", System.Data.OleDb.OleDbType.VarChar, 0, "ID_str"), New System.Data.OleDb.OleDbParameter("ID_int", System.Data.OleDb.OleDbType.[Integer], 0, "ID_int"), New System.Data.OleDb.OleDbParameter("bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "bezeichnung")})
        '
        'OleDbSelectCommand_IDDokumenteintrag
        '
        Me.OleDbSelectCommand_IDDokumenteintrag.CommandText = "SELECT ID, IDDokumenteintrag, Datenbankidentität, Server, Datenbank, Benutzer, Pa" & _
            "sswort, IDTyp, ID_guid, ID_str, ID_int, bezeichnung  FROM tblObjekt WHERE (IDDok" & _
            "umenteintrag = ?)"
        Me.OleDbSelectCommand_IDDokumenteintrag.Connection = Me.conArchiv
        Me.OleDbSelectCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")})
        '
        'OleDbUpdateCommand_IDDokumenteintrag
        '
        Me.OleDbUpdateCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbUpdateCommand_IDDokumenteintrag.CommandText")
        Me.OleDbUpdateCommand_IDDokumenteintrag.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, "Datenbankidentität"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, "Datenbank"), New System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"), New System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("ID_guid", System.Data.OleDb.OleDbType.Guid, 0, "ID_guid"), New System.Data.OleDb.OleDbParameter("ID_str", System.Data.OleDb.OleDbType.VarChar, 0, "ID_str"), New System.Data.OleDb.OleDbParameter("ID_int", System.Data.OleDb.OleDbType.[Integer], 0, "ID_int"), New System.Data.OleDb.OleDbParameter("bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "bezeichnung"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDDokumenteintrag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbankidentität", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Server", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Server", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Datenbank", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Benutzer", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Passwort", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Passwort", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDTyp", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_guid", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_guid", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_str", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_str", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "bezeichnung", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

#End Region


    Public Function LesenObjekte_IDDokumenteintrag(ByVal IDDokumenteintrag As System.Guid) As dsObjects
        Try

            Dim data As New dsObjects
            Dim conn As New db
            Me.OleDbSelectCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_IDDokumenteintrag.CommandTimeout = 0
            Me.daObjects_IDDokumenteintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteintrag
            Me.daObjects_IDDokumenteintrag.SelectCommand.Parameters("IDDokumenteintrag").Value = IDDokumenteintrag
            Me.daObjects_IDDokumenteintrag.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertObject(ByVal r_object As dsObjects.tblObjektRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbInsertCommand_IDDokumenteintrag.CommandTimeout = 0

            Dim db As New db
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID").Value = r_object.ID
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("IDDokumenteintrag").Value = r_object.IDDokumenteintrag
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Datenbankidentität").Value = r_object.Datenbankidentität
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Server").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Datenbank").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Benutzer").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("Passwort").Value = ""
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("IDTyp").Value = 0

            If Not gen.IsNull(r_object.ID_guid) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = r_object.ID_guid
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = Nothing
            ElseIf Not gen.IsNull(r_object.ID_str) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = r_object.ID_str
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = Nothing
            ElseIf Not gen.IsNull(r_object.ID_int) Then
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_int").Value = r_object.ID_int
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_guid").Value = Nothing
                Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("ID_str").Value = Nothing
            Else
                Throw New Exception("compObjekt.insertObject: kein Wert wurde für den Objecteintrag angegeben!")
            End If
            Me.OleDbInsertCommand_IDDokumenteintrag.Parameters("bezeichnung").Value = r_object.bezeichnung

            Me.OleDbInsertCommand_IDDokumenteintrag.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function deleteOrdner(ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_IDDokumenteintrag.CommandTimeout = 0

            Me.OleDbDeleteCommand_IDDokumenteintrag.Parameters("Original_ID").Value = IDOrdner
            Me.OleDbDeleteCommand_IDDokumenteintrag.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function ObjekteLöschen(ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try

            Dim conn As New db
            Me.OleDbDeleteCommand_IDDokumenteintrag.CommandText = "DELETE FROM tblObjekt WHERE (IDDokumenteintrag = ?)"
            Me.OleDbDeleteCommand_IDDokumenteintrag.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_IDDokumenteintrag.CommandTimeout = 0
            Me.OleDbDeleteCommand_IDDokumenteintrag.Parameters("IDDokumenteintrag").Value = IDDokumenteintrag
            Me.OleDbDeleteCommand_IDDokumenteintrag.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


End Class
