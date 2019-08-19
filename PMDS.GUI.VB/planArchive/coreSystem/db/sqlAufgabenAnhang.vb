Imports System.Data.OleDb


Public Class sqlAufgabenAnhang

    Public dtAufgabenAnhang As New DataTable
    Private cmdAufgabenAnhang As New OleDbCommand
    Private daAufgabenAnhang As New OleDbDataAdapter
    Private sqlAufgabenAnhang As String

    Public gen As New GeneralArchiv()



#Region "COLUMNS"
    ' ROWS
    Public ID As System.Guid = Nothing
    Public IDAufgabe As System.Guid = Nothing
    Public IDDokumenteintrag As System.Guid
    Public Anhang As Boolean = False
#End Region


    Public Sub New()
        MyBase.New()
        Try
            ClearClassMembers()
            Me.cmdAufgabenAnhang.CommandTimeout = 0

        Catch ex As Exception
            Throw New Exception("New: " + ex.ToString())
        End Try
    End Sub


    Public Sub ClearClassMembers()
        Try
            ' Me.DataTable.Rows.Clear()
            Me.cmdAufgabenAnhang.Parameters.Clear()

            ID = Nothing
            IDAufgabe = Nothing
            IDDokumenteintrag = Nothing
            Anhang = False

        Catch ex As Exception
            Throw New Exception("ClearClassMembers: " + ex.ToString())
        End Try
    End Sub

    Public Function SelectRow_IDAufgabe(ByVal IDAufgabe As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgabenAnhang.Parameters.Clear()
            sqlAufgabenAnhang = "SELECT ID, IDAufgabe, IDDokumenteintrag, Anhang FROM tblAufgabenAnhang where IDAufgabe = ? "
            cmdAufgabenAnhang = New OleDbCommand(sqlAufgabenAnhang, db.getConnDB)
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabe", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabe")).Value = IDAufgabe
            daAufgabenAnhang.SelectCommand = cmdAufgabenAnhang
            daAufgabenAnhang.Fill(dtAufgabenAnhang)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectRow_IDAufgabe: " + ex.ToString())
        End Try
    End Function
    Public Function InsertRow() As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgabenAnhang.Parameters.Clear()
            Me.cmdAufgabenAnhang.CommandText = "INSERT INTO tblAufgabenAnhang (ID, IDAufgabe, IDDokumenteintrag, Anhang) VALUES (?, ?, ?, ?) "
            Me.cmdAufgabenAnhang.Connection = db.getConnDB

            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabe", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabe")).Value = IDAufgabe
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")).Value = IDDokumenteintrag
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("Anhang", System.Data.OleDb.OleDbType.Boolean, 1, "Anhang")).Value = Anhang

            Me.cmdAufgabenAnhang.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("InsertRow: " + ex.ToString())
        End Try
    End Function

    Public Function DeleteRow_IDAufgabe_IDDokumenteintrag(ByVal IDAufgabe As System.Guid, ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try
            Dim db As New db()
            Me.cmdAufgabenAnhang.Parameters.Clear()
            Me.cmdAufgabenAnhang.CommandText = "DELETE FROM tblAufgabenAnhang WHERE (IDAufgabe = ?) and (IDDokumenteintrag = ?)"
            Me.cmdAufgabenAnhang.Connection = db.getConnDB
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabe", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabe")).Value = IDAufgabe
            Me.cmdAufgabenAnhang.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")).Value = IDDokumenteintrag
            Me.cmdAufgabenAnhang.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("DeleteRow_IDAufgabe_IDDokumenteintrag: " + ex.ToString())
        End Try
    End Function

End Class

