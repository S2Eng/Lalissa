Imports System.Data.OleDb


Public Class compRecht

    Private gen As New GeneralArchiv


    Public Function getRechteOrdner(ByVal IDOrdner As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OLEBSelectCommand_RechteOrdner_IDOrdner.Connection = conn.getConnDB
            Me.OLEBSelectCommand_RechteOrdner_IDOrdner.CommandTimeout = 0
            Me.daRechteOrdner_IDOrdner.SelectCommand = Me.OLEBSelectCommand_RechteOrdner_IDOrdner
            Me.daRechteOrdner_IDOrdner.SelectCommand.Parameters("IDOrdner").Value = IDOrdner
            Me.daRechteOrdner_IDOrdner.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function getRechtOrdnerGruppe(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = conn.getConnDB
            Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.CommandTimeout = 0
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand = Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand.Parameters("IDOrdner").Value = IDOrdner
            Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand.Parameters("IDGruppe").Value = IDGruppe
            Me.daRechteOrdner_IDOrdnerIDGruppe.Fill(data)
            If data.Tables(0).Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblRechteOrdnerRow
                r = data.Tables(0).Rows(0)
                Return True
            End If
            Return False

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function writeRecht(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid, ByVal RechtJN As Boolean) As Boolean
        Try

            If RechtJN Then
                Dim r_recht As dsPlanArchive.tblRechteOrdnerRow
                Dim data As New dsPlanArchive
                r_recht = data.tblRechteOrdner.NewRow
                r_recht.ID = System.Guid.NewGuid
                r_recht.IDOrdner = IDOrdner
                r_recht.IDGruppe = IDGruppe
                Me.insertRecht(r_recht)
            Else
                Me.deleteRecht(IDOrdner, IDGruppe)
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertRecht(ByVal r_recht As dsPlanArchive.tblRechteOrdnerRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = conn.getConnDB
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.CommandTimeout = 0

            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("ID").Value = r_recht.ID
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDOrdner").Value = r_recht.IDOrdner
            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDGruppe").Value = r_recht.IDGruppe

            Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateRecht(ByVal r_recht As dsPlanArchive.tblRechteOrdnerRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.CommandTimeout = 0

            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("ID").Value = r_recht.ID
            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDOrdner").Value = r_recht.IDOrdner
            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("IDGruppe").Value = r_recht.IDGruppe
            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters("ID").Value = r_recht.ID

            Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Function deleteRecht(ByVal IDOrdner As System.Guid, ByVal IDGruppe As System.Guid) As Boolean
        Try
            Dim Command As New OleDbCommand
            Dim conn As New db

            Command.Parameters.Clear()
            Command.CommandText = "DELETE FROM  tblRechteOrdner  WHERE  IDOrdner  = ? and IDGruppe = ? "
            Command.Connection = conn.getConnDB
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")).Value = IDOrdner
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")).Value = IDGruppe
            Command.ExecuteNonQuery()

        Catch ex As OleDbException
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function



End Class
