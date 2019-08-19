Imports System.Data.OleDb


Public Class sqlAufgabeZuordnung

    Public dtAufgabeZuordnung As New DataTable
    Private cmdAufgabeZuordnung As New OleDbCommand
    Private daAufgabeZuordnung As New OleDbDataAdapter
    Private sqlAufgabeZuordnung As String

    Public gen As New GeneralArchiv()



#Region "COLUMNS"
    ' ROWS
    Public ID As System.Guid = Nothing
    Public IDAufgabe As System.Guid = Nothing
    Public IDZuordnung As System.Guid = Nothing
    Public Application As Integer = Nothing

#End Region


    Public Sub New()
        MyBase.New()
        Try
            ClearClassMembers()
            Me.cmdAufgabeZuordnung.CommandTimeout = 0

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub

    Public Sub ClearClassMembers()
        Try
            Me.cmdAufgabeZuordnung.Parameters.Clear()
            'Me.DataTable.Rows.Clear()
            ID = Nothing
            IDAufgabe = Nothing
            IDZuordnung = Nothing
            Application = Nothing

        Catch ex As Exception
            Throw New Exception("ClearClassMembers: " + ex.ToString())
        End Try
    End Sub


    Public Function SelectAllRows_IDAufgabe(ByVal IDAufgabe As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgabeZuordnung.Parameters.Clear()
            sqlAufgabeZuordnung = "SELECT ID, IDAufgabe, IDZuordnung, Application FROM tblAufgabeZuordnung  where IDAufgabe = ? "
            cmdAufgabeZuordnung = New OleDbCommand(sqlAufgabeZuordnung, db.getConnDB)
            Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabe", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabe")).Value = IDAufgabe
            daAufgabeZuordnung.SelectCommand = cmdAufgabeZuordnung
            daAufgabeZuordnung.Fill(dtAufgabeZuordnung)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectAllRows_IDAufgabe: " + ex.ToString())
        End Try
    End Function


    Public Function InsertRow() As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgabeZuordnung.Parameters.Clear()
            Me.cmdAufgabeZuordnung.CommandText = "INSERT INTO tblAufgabeZuordnung( ID, IDAufgabe, IDZuordnung, Application ) VALUES ( ?, ?, ?, ?)"
            Me.cmdAufgabeZuordnung.Connection = db.getConnDB

            Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabe", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabe")).Value = IDAufgabe
            If IDZuordnung.ToString = GeneralArchiv.EmptyGuid.ToString Then
                Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDZuordnung")).Value = Nothing
            Else
                Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDZuordnung")).Value = IDZuordnung
            End If
            Me.cmdAufgabeZuordnung.Parameters.Add(New System.Data.OleDb.OleDbParameter("Application", System.Data.OleDb.OleDbType.Integer, 16, "Application")).Value = Application

            Me.cmdAufgabeZuordnung.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("InsertRow: " + ex.ToString())
        End Try
    End Function

End Class
