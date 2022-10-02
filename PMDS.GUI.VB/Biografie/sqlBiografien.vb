Imports System.Data.OleDb


Public Class sqlBiografien
    Inherits db

    Public DataTable As New DataTable
    Private Command As New OleDbCommand
    Private DataAdapter As New OleDbDataAdapter
    Private Sql As String = ""

    Public FormularName As String = "Biografie.S2frm"
    Public gen As New GeneralArchiv()






    Public Sub New()
        Me.Command.CommandTimeout = 0
    End Sub


    Public Function SelectRow(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = "SELECT ID " &
                    " " &
                    " FormularDaten  where ID = ? "
            Command = New OleDbCommand(Sql, getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("SelectRow: " + ex.ToString())
        End Try
    End Function

    Public Function loadAlleVorhadenenBiografien(ByVal IDPatient As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = " SELECT ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeaendert, " +
                    " IDBenutzer_Erstellt, IDBenutzer_Geaendert from FormularDaten " +
                    " where IDREF = ? and FormularName = ? " +
                    " order by Datumerstellt desc "

            Command = New OleDbCommand(Sql, getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF")).Value = IDPatient
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 200, "FormularName")).Value = Me.FormularName

            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("loadAlleVorhadenenBiografien: " + ex.ToString())
        End Try
    End Function
    Public Function loadFormular(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Sql = " SELECT ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeaendert, " +
                    " IDBenutzer_Erstellt, IDBenutzer_Geaendert from FormularDaten " +
                    " where ID = ? and FormularName = ? " +
                    " order by Datumerstellt desc "

            Command = New OleDbCommand(Sql, getConnDB)
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 200, "FormularName")).Value = Me.FormularName

            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(DataTable)
            Return True

        Catch ex As OleDbException
            Throw New Exception("loadAlleVorhadenenBiografien: " + ex.ToString())
        End Try
    End Function
    Public Function InsertRow(ByVal txtFormular As String, ByVal IDPatient As Guid) As clObject
        Try
            'PMDS.BusinessLogic.Patient pat = new PMDS.BusinessLogic.Patient(PMDS.Global.Settings.CurrentIDPatient);
            'return pat.Vorname + " " + pat.Nachname;
            Dim ret As New clObject

            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "INSERT INTO FormularDaten(ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeaendert, IDBenutzer_Erstellt, IDBenutzer_Geaendert ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ? )"
            Me.Command.Connection = Me.getConnDB

            Dim idNew As New System.Guid
            idNew = System.Guid.NewGuid

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idNew
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF")).Value = IDPatient 'PMDS.Global.Settings.CurrentIDPatient

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 50, "FormularName")).Value = Me.FormularName
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = txtFormular

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Datumerstellt", System.Data.OleDb.OleDbType.Date, 8, "Datumerstellt")).Value = Now
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert")).Value = Now

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt")).Value = PMDS.Global.ENV.USERID
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert")).Value = PMDS.Global.ENV.USERID


            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = Text
            'If Me.IsNull(EndTime) Then
            '    Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.DBTime, 8, "EndTime")).Value = Nothing
            'Else
            '    Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.DBTime, 8, "EndTime")).Value = EndTime.TimeOfDay
            'End If

            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBDate, 8, "EndDate")).Value = Me.CheckDateNull(EndDate)
            'If IDAufgabeZuordnung.ToString = EmptyGuid.ToString Then
            '    Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = Nothing
            'Else
            '    Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAufgabeZuordnung", System.Data.OleDb.OleDbType.Guid, 16, "IDAufgabeZuordnung")).Value = IDAufgabeZuordnung
            'End If

            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = Now
            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("FürIDBMB", System.Data.OleDb.OleDbType.Guid, 16, "FürIDBMB")).Value = Me.CheckIsNull(FürIDBMB)
            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("MailCC", System.Data.OleDb.OleDbType.VarChar, 800, "MailCC")).Value = MailCC

            'Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("AlsHTML", System.Data.OleDb.OleDbType.Boolean, 1, "AlsHTML")).Value = AlsHTML

            'PMDS.Global.Settings.USERID 

            Me.Command.ExecuteNonQuery()
            ret.id = idNew.ToString
            ret.ok = True
            Return ret

        Catch ex As OleDbException
            Throw New Exception("InsertRow: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateRowxy(ByVal ID As System.Guid) As Boolean
        Try
            'Me.Command.Parameters.Clear()
            'Me.Command.CommandText = "UPDATE FormularDaten SET Betreff = ? WHERE (ID = ?)"
            'Me.Command.Connection = Me.getConnDB

            'Me.Command.ExecuteNonQuery()
            'Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateRow: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateBiographie(ByVal ID As System.Guid, ByVal txtFormular As String) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "UPDATE FormularDaten set BLOP=?, DatumGeaendert=?,IDBenutzer_Geaendert=? WHERE (ID = ?)"

            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = txtFormular
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert")).Value = Now
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert")).Value = PMDS.Global.ENV.USERID
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID

            Me.Command.Connection = Me.getConnDB

            Me.Command.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("UpdateBiographie: " + ex.ToString())
        End Try
    End Function

    Public Function biografieLöschen(ByVal ID As System.Guid) As Boolean
        Try
            Me.Command.Parameters.Clear()
            Me.Command.CommandText = "DELETE FROM FormularDaten WHERE ID = ? "
            Me.Command.Connection = Me.getConnDB
            Me.Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
            Me.Command.ExecuteNonQuery()
            Return True

        Catch ex As OleDbException
            Throw New Exception("biografieLöschen: " + ex.ToString())
        End Try
    End Function

End Class
