Imports System.Data.OleDb


Public Class tblAufgabeArt
    Inherits db

    Public DataTable As New DataTable
    Private Command As New OleDbCommand
    Private DataAdapter As New OleDbDataAdapter
    Private Sql As String

    Public gen As New GeneralArchiv()



#Region "COLUMNS"
    ' ROWS
    Public ID As System.Guid = Nothing
    Public Beschreibung As String = Nothing
    Public Color As String = Nothing
#End Region

    Public Sub New()
        MyBase.New()
        Try
            ClearClassMembers()
            Me.Command.CommandTimeout = 0

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub
    Public Sub New(ByVal ID As System.Guid)
        MyBase.New()
        Try
            ClearClassMembers()
            SelectRow(ID)

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub

    Public Sub ClearClassMembers()
        Try
            Me.Command.Parameters.Clear()
            'Me.DataTable.Rows.Clear()
            ID = Nothing
            Beschreibung = Nothing
            Color = Nothing

        Catch ex As Exception
            Throw New Exception("ClearClassMembers: " + ex.ToString())
        End Try
    End Sub

    Public Function SelectRow(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = "SELECT ID, Beschreibung, Color FROM tblAufgabeArt  where ID = ? "
            Command = New OleDbCommand(Sql, getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectRow: " + ex.ToString())
        End Try
    End Function

    Public Function SelectRow_Beschreibung(ByVal Beschreibung As String) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = "SELECT ID, Beschreibung, Color FROM tblAufgabeArt  where Beschreibung = ? "
            Command = New OleDbCommand(Sql, getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 100, "Beschreibung")).Value = Beschreibung
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectRow_Beschreibung: " + ex.ToString())
        End Try
    End Function

    Public Function SelectAllRows() As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = "SELECT ID, Beschreibung, Color FROM tblAufgabeArt order by Beschreibung "
            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectAllRows: " + ex.ToString())
        End Try
    End Function

    Public Function SelectAllRows_Art(ByVal SqlWhere As String) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = "SELECT ID, Beschreibung, Color FROM tblAufgabeArt where  " + SqlWhere
            Command = New OleDbCommand(Sql, getConnDB)
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectAllRows_Art: " + ex.ToString())
        End Try
    End Function

    Public Function InsertRowxy() As Boolean
        Try
            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "INSERT INTO tblAufgabeArt(ID, Beschreibung, Color ) VALUES (?, ?, ?)"
            Me.Command.Connection = Me.getConnDB

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 100, "Beschreibung")).Value = Beschreibung
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Color", System.Data.OleDb.OleDbType.VarChar, 100, "Color")).Value = Color

            Me.Command.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("InsertRow: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateRowxy(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "UPDATE tblAufgabeArt SET Beschreibung = ?, Color = ?  WHERE (ID = ?)"
            Me.Command.Connection = Me.getConnDB

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 100, "Beschreibung")).Value = Beschreibung
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Color", System.Data.OleDb.OleDbType.VarChar, 100, "Color")).Value = Color

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID

            Me.Command.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow: " + ex.ToString())
        End Try
    End Function

    Public Function DeleteRowxy(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "DELETE FROM tblAufgabeArt WHERE (ID = ?)"
            Me.Command.Connection = Me.getConnDB
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.Command.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("DeleteRow: " + ex.ToString())
        End Try
    End Function

End Class
