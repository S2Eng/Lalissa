


Public Class sqlCARDIAC

    Public sel_daVLAD As String = ""


    Public Enum eTypSelCARDIAC
        VLAD = 0
        VLADSurgeon = 1
    End Enum

    Public database As New qs2.core.dbBase

    Public Sub initControl()
        Me.sel_daVLAD = Me.daVLADCardiacStays.SelectCommand.CommandText
    End Sub






    Public Function getVLAD(ByVal ds As dsCARDIAC, sqlWhereAutoGen As String, ByRef sqlVLADReturn As String) As Boolean
        Try
            Me.daVLADCardiacStays.SelectCommand.CommandText = Me.sel_daVLAD
            qs2.core.dbBase.setConnection(Me.daVLADCardiacStays)
            Me.daVLADCardiacStays.SelectCommand.Parameters.Clear()

            Dim sOrderBy As String = ""
            sOrderBy = " order by " + ds.VLADCARDIAC_STAYS.SurgDtStartColumn.ColumnName + " asc "
            Me.daVLADCardiacStays.SelectCommand.CommandText += " " + sqlWhereAutoGen + " " + sOrderBy
            Me.daVLADCardiacStays.SelectCommand.CommandTimeout = 0

            Me.daVLADCardiacStays.Fill(ds.VLADCARDIAC_STAYS)

            If ENV.adminSecure Or actUsr.rUsr.isAdmin Then
                Dim Protocol1 As New core.vb.Protocol()
                Dim sProt As String = "VLAD Report Sql-Command:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + Me.daVLADCardiacStays.SelectCommand.CommandText
                Protocol1.save2(core.vb.Protocol.eTypeProtocoll.RunQuery, System.Guid.Empty, -999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(),
                                qs2.core.license.doLicense.rApplication.IDApplication.Trim(), "", sProt.Trim(), core.vb.Protocol.eActionProtocol.None, "", "")

            End If

            sqlVLADReturn = Me.daVLADCardiacStays.SelectCommand.CommandText
            Return True

        Catch ex As Exception
            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("Error") + ": " + ex.ToString(), System.Windows.Forms.MessageBoxButtons.OK, "")
            Return False

            'Throw New Exception("sqlAdmin.getVLAD: " + ex.ToString())
        End Try
    End Function


End Class
