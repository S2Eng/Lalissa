

Public Class compPfad
    Inherits System.ComponentModel.Component

    Private gen As New GeneralArchiv


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
    Friend WithEvents daPfad As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents connArchiv As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand_Pfad As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Pfad As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Pfad As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Pfad As System.Data.OleDb.OleDbCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.daPfad = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.connArchiv = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        '
        'daPfad
        '
        Me.daPfad.DeleteCommand = Me.OleDbDeleteCommand_Pfad
        Me.daPfad.InsertCommand = Me.OleDbInsertCommand_Pfad
        Me.daPfad.SelectCommand = Me.OleDbSelectCommand_Pfad
        Me.daPfad.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblPfad", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Archivpfad", "Archivpfad")})})
        Me.daPfad.UpdateCommand = Me.OleDbUpdateCommand_Pfad
        '
        'OleDbDeleteCommand_Pfad
        '
        Me.OleDbDeleteCommand_Pfad.CommandText = "DELETE FROM [tblPfad] WHERE (([Archivpfad] = ?))"
        Me.OleDbDeleteCommand_Pfad.Connection = Me.connArchiv
        Me.OleDbDeleteCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Archivpfad", System.Data.DataRowVersion.Original, Nothing)})
        '
        'connArchiv
        '
        Me.connArchiv.ConnectionString = "Provider=SQLNCLI.1;Data Source=S2STY018\SQLEXPRESS;Persist Security Info=True;Pas" &
    "sword=adms2sty000;User ID=pmds;Initial Catalog=pmds"
        '
        'OleDbInsertCommand_Pfad
        '
        Me.OleDbInsertCommand_Pfad.CommandText = "INSERT INTO [tblPfad] ([Archivpfad]) VALUES (?)"
        Me.OleDbInsertCommand_Pfad.Connection = Me.connArchiv
        Me.OleDbInsertCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, "Archivpfad")})
        '
        'OleDbSelectCommand_Pfad
        '
        Me.OleDbSelectCommand_Pfad.CommandText = "SELECT Archivpfad FROM tblPfad"
        Me.OleDbSelectCommand_Pfad.Connection = Me.connArchiv
        '
        'OleDbUpdateCommand_Pfad
        '
        Me.OleDbUpdateCommand_Pfad.CommandText = "UPDATE [tblPfad] SET [Archivpfad] = ? WHERE (([Archivpfad] = ?))"
        Me.OleDbUpdateCommand_Pfad.Connection = Me.connArchiv
        Me.OleDbUpdateCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, "Archivpfad"), New System.Data.OleDb.OleDbParameter("Original_Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Archivpfad", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

#End Region




    Public Function pfadLesen() As String
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Pfad.CommandTimeout = 0
            Me.daPfad.SelectCommand = Me.OleDbSelectCommand_Pfad
            data.Clear()
            Me.daPfad.Fill(data)
            If data.tblPfad.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblPfadRow
                r = data.tblPfad.Rows(0)
                Return r.Archivpfad
            Else
                Return ""
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub WritePfad(ByVal pfad As String)
        Try

            Me.deletePfad()

            Dim conn As New db
            Me.OleDbInsertCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Pfad.CommandTimeout = 0
            Me.OleDbInsertCommand_Pfad.Parameters("Archivpfad").Value = pfad
            Me.OleDbInsertCommand_Pfad.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Function deletePfad() As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Pfad.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Pfad.CommandTimeout = 0
            Me.OleDbDeleteCommand_Pfad.CommandText = "DELETE FROM tblPfad "
            Me.OleDbDeleteCommand_Pfad.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function



End Class
