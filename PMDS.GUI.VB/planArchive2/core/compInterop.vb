Imports System.Data.OleDb
Imports VB = Microsoft.VisualBasic



Public Class compInterop

    Public gen As New General()
    Public database As New db()

    Public Shared daSelInterop As String = ""
    Public Shared daSelInteropSmall As String = ""

    Public Enum eSelInterop
        allPast = 0
        all = 100
    End Enum
    Public Enum eTypActionInterop
        sendEMails = 0
        ServerISAvailable = 100
    End Enum
    Public Enum eMachine
        server = 0
        client = 1
        all = 100
    End Enum








    Public Function getInterop(ByRef dsInterop1 As dsInterop, ByVal ID As System.Guid, ByVal tDone As Integer,
                                ByVal eTypSel As eSelInterop, ByVal typMachine As eMachine, ByVal tDeleted As Integer,
                                ByVal fromUser As String, ByVal fromClient As String,
                                ByVal typAction As String,
                                ByVal notIDLast As System.Guid, ByVal NotTypAction As String, doSmallDataAdapter As Boolean) As Boolean

        Try
            Dim where As String = ""
            Dim daTmp As OleDbDataAdapter = Nothing

            If doSmallDataAdapter Then
                daTmp = Me.daInteropSmall
                daTmp.SelectCommand.CommandText = compInterop.daSelInteropSmall
            Else
                daTmp = Me.daInterop
                daTmp.SelectCommand.CommandText = compInterop.daSelInterop
            End If

            daTmp.SelectCommand.Parameters.Clear()
            Me.database.setDBConnection_dataAdapter(daTmp)

            If eTypSel = eSelInterop.allPast Then
                Dim str As String = " doAt <= ? "
                General.addStrToSql(str, where)
            End If
            If Not Me.gen.IsNull(ID) Then
                Dim str As String = " ID = '" + ID.ToString() + "'"
                General.addStrToSql(str, where)
            End If
            If Not Me.gen.IsNull(notIDLast) Then
                Dim str As String = " ID <> '" + notIDLast.ToString() + "'"
                General.addStrToSql(str, where)
            End If
            If tDone = 0 Then
                Dim str As String = " done=0 "
                General.addStrToSql(str, where)
            ElseIf tDone = 1 Then
                Dim str As String = " done=1 "
                General.addStrToSql(str, where)
            End If

            If tDeleted = 0 Then
                Dim str As String = " deleted=0 "
                General.addStrToSql(str, where)
            ElseIf tDeleted = 1 Then
                Dim str As String = " deleted=1 "
                General.addStrToSql(str, where)
            End If

            If Not fromUser.Trim() = "" Then
                Dim str As String = " fromUser = '" + fromUser.Trim() + "'"
                General.addStrToSql(str, where)
            End If
            If Not fromClient.Trim() = "" Then
                Dim str As String = " fromClient = '" + fromClient.Trim() + "'"
                General.addStrToSql(str, where)
            End If

            If Not typAction.Trim() = "" Then
                Dim str As String = " typAction = '" + typAction.Trim() + "'"
                General.addStrToSql(str, where)
            End If
            If Not NotTypAction.Trim() = "" Then
                Dim str As String = " typAction <> '" + NotTypAction.Trim() + "'"
                General.addStrToSql(str, where)
            End If
            If typMachine = eMachine.server Then

            ElseIf typMachine = eMachine.client Then

            End If

            daTmp.SelectCommand.CommandText += where
            daTmp.SelectCommand.CommandText += " order by doAt asc "
            daTmp.SelectCommand.CommandTimeout = 0

            If eTypSel = eSelInterop.allPast Then
                daTmp.SelectCommand.Parameters.AddWithValue("doAt", Now)
            End If

            If doSmallDataAdapter Then
                daTmp.Fill(dsInterop1.tblInteropSmall)
            Else
                daTmp.Fill(dsInterop1.tblInterop)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.getInterop: " + ex.ToString())
        End Try
    End Function

    Public Function newRowInterop(ByRef t As dsInterop.tblInteropDataTable,
                                  ByVal typActionInterop As eTypActionInterop,
                                  ByVal doPromptly As Boolean,
                                  ByRef dbPar As dsInteropPar,
                                  ByVal ReplyToUser As Boolean) As dsInterop.tblInteropRow
        Try
            Dim rNew As dsInterop.tblInteropRow = t.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.createdAt = Now
            If doPromptly Then
                rNew.doAt = New DateTime(1900, 1, 1)
            Else
                rNew.doAt = Now
            End If
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            rNew.typAction = typActionInterop.ToString()
            rNew.fromUser = UserLoggedIn.Trim()
            rNew.fromClient = My.Computer.Name

            rNew.dbPar = Me.getXMLInteropDb(dbPar)
            rNew.done = False
            rNew.SetdoneAtNull()

            rNew.ReplyToUser = ReplyToUser
            rNew.ReplyTxt = ""
            rNew.ReplyTxtDetail = ""
            rNew.ReplyError = ""
            rNew.deleted = False

            t.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compInterop.newRowInterop: " + ex.ToString())
        End Try
    End Function

    Public Function updateInterop(ByVal id As System.Guid,
                                  ByVal done As Boolean, ByVal doneAt As Date,
                                  ByRef ReplyTxt As String, ByRef ReplyTxtDetail As String, ByRef ReplyError As String) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "update tblInterop set done=?, doneAt=?, ReplyTxt=?, ReplyTxtDetail=?, ReplyError=? where ID=?"
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("done", System.Data.OleDb.OleDbType.Boolean, 1, "done")).Value = done
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("doneAt", System.Data.OleDb.OleDbType.Date, 8, "doneAt")).Value = doneAt
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt")).Value = ReplyTxt
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ReplyTxtDetail", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxtDetail")).Value = ReplyTxtDetail
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ReplyError", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyError")).Value = ReplyError
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID")).Value = id
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.updateInterop: " + ex.ToString())
        End Try
    End Function
    Public Function updateInterop(ByVal id As System.Guid, ByVal deleted As Boolean) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "update tblInterop set deleted=? where ID=?"
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.Boolean, 1, "deleted")).Value = deleted
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID")).Value = id
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.updateInterop: " + ex.ToString())
        End Try
    End Function
    Public Function deleteInterop(ByVal id As System.Guid) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "Delete from tblInterop where ID = '" + id.ToString() + "' "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.deleteInterop: " + ex.ToString())
        End Try
    End Function
    Public Function deleteInteropTypAction(ByVal typAction As eTypActionInterop) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "Delete from tblInterop where typAction = '" + typAction.ToString() + "' "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.deleteInteropTypAction: " + ex.ToString())
        End Try
    End Function
    Public Function deleteAllInterop() As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "Delete from tblInterop "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.deleteAllInterop: " + ex.ToString())
        End Try
    End Function
    Public Function deleteAllInterop(ByVal fromUser As String) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = "Delete from tblInterop where fromUser = '" + fromUser + "' "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compInterop.deleteAllInterop: " + ex.ToString())
        End Try
    End Function

    Public Function getXMLInteropDb(ByVal db As dsInteropPar) As String
        Try
            Dim xml As String = ""
            Dim xmlStrWriter As New System.IO.StringWriter()
            Dim xmlWriter As New System.Xml.XmlTextWriter(xmlStrWriter)
            xmlWriter.WriteStartDocument(True)

            db.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)
            xml = xmlStrWriter.ToString()
            xmlWriter.Close()
            Return xml

        Catch ex As Exception
            Throw New Exception("compInterop.getXMLInteropDb: " + ex.ToString())
        End Try
    End Function
    Public Function getDsInteropParFromStr(ByVal dbStr As String) As dsInteropPar
        Try
            Dim ds As New dsInteropPar()
            Dim str As New System.IO.StringReader(dbStr)
            ds.ReadXml(str, XmlReadMode.ReadSchema)
            Return ds

        Catch ex As Exception
            Throw New Exception("compInterop.getDsInteropParFromStr: " + ex.ToString())
        End Try
    End Function

End Class
