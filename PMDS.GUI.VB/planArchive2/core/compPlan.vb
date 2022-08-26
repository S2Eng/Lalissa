Imports System.Data.OleDb


Public Class compPlan

    Public ReadOnly sqldaPlan As String = ""
    Public ReadOnly sqldaPlanAnhang As String = ""
    Public ReadOnly sqldaPlanObject As String = ""
    Public ReadOnly sqldaPlanStatus As String = ""
    Public ReadOnly sqldaPlanBereich As String = ""
    Public ReadOnly sqldaSearchPlanBereich As String = ""


    Public Enum eTypSelPlan
        id = 0
        MessageIdMIME = 1
        EMailsNotReadedUser = 2
        IDPlanMain = 3
        MessageId = 4
        MessageIdNoUser = 5
        EmpfangenAmBigger = 6
        IDPlan = 7
    End Enum
    Public Enum eTypSelPlanAnhang
        id = 0
        idPlan = 1
    End Enum
    Public Enum eTypSelPlanObject
        id = 0
        allIDPlan = 1
        IDObject = 2
    End Enum
    Public Enum eTypSelPlanTextHist
        id = 0
    End Enum

    Public Enum eStatusPlan
        deleted = 0
        bodyEmpty = 1
        sent = 2
    End Enum

    Public Enum eTypSelPlanBereich
        IDPlanMain = 0
        IDPlan = 1
    End Enum


    Public database As New db()
    Public gen As New General()










    Public Function getPlanRow2(ByRef ds As dsPlan, ByVal id As System.Guid, ByVal typSel As eTypSelPlan, ByVal doExcepFoundMoreThanOne As Boolean,
                                Optional ByVal str As String = "", Optional ByVal Für As String = "") As dsPlan.planRow
        Try
            Me.getPlan(id, typSel, ds, str, Für)
            If ds.plan.Rows.Count = 0 Then
                Return Nothing
            ElseIf ds.plan.Rows.Count = 1 Then
                Return ds.plan.Rows(0)
            ElseIf ds.plan.Rows.Count > 1 Then
                If doExcepFoundMoreThanOne Then
                    Throw New Exception("getPlanRow.id: More than one Plan to idPlan '" + id.ToString() + "' found!")
                End If
                Return ds.plan.Rows(0)
            End If

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanRow2: " + ex.ToString())
        End Try
    End Function
    Public Function getPlanRow(ByVal id As System.Guid, ByVal typSel As eTypSelPlan, ByVal doExcepFoundMoreThanOne As Boolean,
                               Optional ByVal str As String = "", Optional ByVal Für As String = "") As dsPlan.planRow
        Try
            Dim ds As New dsPlan
            Me.getPlan(id, typSel, ds, str, Für)
            If ds.plan.Rows.Count = 0 Then
                Return Nothing
            ElseIf ds.plan.Rows.Count = 1 Then
                Return ds.plan.Rows(0)
            ElseIf ds.plan.Rows.Count > 1 Then
                If doExcepFoundMoreThanOne Then
                    Throw New Exception("getPlanRow.id: More than one Plan to idPlan '" + id.ToString() + "' found!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanRow: " + ex.ToString())
        End Try
    End Function
    Public Function getPlan(ByVal id As System.Guid, ByVal typSel As eTypSelPlan, ByVal db As dsPlan,
                            Optional ByVal str As String = "", Optional ByVal Für As String = "", Optional dat As Date = Nothing) As Boolean
        Try
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            Me.daPlan.SelectCommand.CommandText = Me.sqldaPlan
            Me.database.setDBConnection_dataAdapter(Me.daPlan)
            Me.daPlan.SelectCommand.Parameters.Clear()

            If typSel = eTypSelPlan.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daPlan.SelectCommand.CommandText += sWhere
                Me.daPlan.SelectCommand.Parameters.AddWithValue("ID", id)

            ElseIf typSel = eTypSelPlan.MessageIdMIME Then
                Dim sWhere As String = " where MessageId = ? and Für = ? "
                Me.daPlan.SelectCommand.CommandText += sWhere
                Me.daPlan.SelectCommand.Parameters.AddWithValue("MessageId", str.Trim())
                Me.daPlan.SelectCommand.Parameters.AddWithValue("Für", Für.Trim())

            ElseIf typSel = eTypSelPlan.EMailsNotReadedUser Then
                Dim sWhere As String = " where readed = ? and IDArt = 1 and Für = '" + UserLoggedIn.Trim() + "' "
                Me.daPlan.SelectCommand.CommandText += sWhere
                Me.daPlan.SelectCommand.Parameters.AddWithValue("readed", False)

            ElseIf typSel = eTypSelPlan.IDPlanMain Then
                Dim sWhere As String = " where IDPlanMain = ? "
                Me.daPlan.SelectCommand.CommandText += sWhere
                Me.daPlan.SelectCommand.Parameters.AddWithValue("IDPlanMain", id)

            ElseIf typSel = eTypSelPlan.MessageIdMIME Then
                Dim sWhere As String = " where MessageId = ? and Für = ? "
                Me.daPlan.SelectCommand.CommandText += sWhere
                Me.daPlan.SelectCommand.Parameters.AddWithValue("MessageId", str.Trim())
                Me.daPlan.SelectCommand.Parameters.AddWithValue("Für", Für.Trim())

            ElseIf typSel = eTypSelPlan.EmpfangenAmBigger Then
                Dim sWhere As String = " where empfangenAm >= ? "
                Me.daPlan.SelectCommand.CommandText += sWhere

                Dim pempfangenAm As New OleDbParameter With {.ParameterName = "empfangenAm", .OleDbType = OleDbType.Date, .Value = dat.Date}
                Me.daPlan.SelectCommand.Parameters.Add(pempfangenAm)
            Else
                Throw New Exception("getPlan: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daPlan.Fill(db.plan)
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.getPlan: " + ex.ToString())
        End Try
    End Function

    Public Function updatePlanStatus(ByVal idPlan As System.Guid, ByVal status As String) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [plan] set status = '" + status + "'  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.AddWithValue("ID", idPlan)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updatePlanStatus: " + ex.ToString())
        End Try
    End Function
    Public Function updatePlanObjectStatus(ByVal idPlan As System.Guid, ByVal IDObject As System.Guid, ByVal status As String) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [planObject] set status = '" + status + "'  WHERE IDPlan='" + idPlan.ToString() + "' and IDObject='" + IDObject.ToString() + "'"
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.AddWithValue("ID", idPlan)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updatePlanStatus: " + ex.ToString())
        End Try
    End Function
    Public Function updateGesendetAm(ByVal idPlan As System.Guid, ByVal gesendetAm As Date) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [plan] set gesendetAm = ?  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()

            Dim pgesendetAm As New OleDbParameter With {.ParameterName = "gesendetAm", .OleDbType = OleDbType.Date, .Value = gesendetAm}
            cmd.Parameters.Add(pgesendetAm)

            cmd.Parameters.AddWithValue("ID", idPlan)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updateGesendetAm: " + ex.ToString())
        End Try
    End Function
    Public Function updateEmpfangenAm(ByVal idPlan As System.Guid, ByVal empfangenAm As Date) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [plan] set empfangenAm = ?  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()

            Dim pempfangenAm As New OleDbParameter With {.ParameterName = "empfangenAm", .OleDbType = OleDbType.Date, .Value = empfangenAm}
            cmd.Parameters.Add(pempfangenAm)

            cmd.Parameters.AddWithValue("ID", idPlan)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updateEmpfangenAm: " + ex.ToString())
        End Try
    End Function
    Public Function updateLstChangeToOutlook(ByVal idPlan As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [plan] set LastChangeITSCont=?, LastSyncToExchange=?  WHERE ID='" + idPlan.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            Dim dNow As Date = Now.AddSeconds(2)

            Dim pLastChangeITSCont As New OleDbParameter With {.ParameterName = "LastChangeITSCont", .OleDbType = OleDbType.Date, .Value = dNow}
            cmd.Parameters.Add(pLastChangeITSCont)

            Dim pLastSyncToExchange As New OleDbParameter With {.ParameterName = "LastSyncToExchange", .OleDbType = OleDbType.Date, .Value = dNow}
            cmd.Parameters.Add(pLastSyncToExchange)

            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updateLstChangeToOutlook: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanIDStatus(ByVal IDPlan As System.Guid, ByVal IDStatus As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  IDStatus = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 120, "IDStatus")).Value = IDStatus
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanIDStatus: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanFür(ByVal IDPlan As System.Guid, ByVal Für As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  Für = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Für", System.Data.OleDb.OleDbType.VarChar, 150, "Für")).Value = Für
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanFür: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanMoveIntoFolder2(ByVal IDPlan As System.Guid, ByVal Folder As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  Folder = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Folder", System.Data.OleDb.OleDbType.VarChar, 600, "Folder")).Value = Folder.Trim()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanMoveIntoFolder2: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateDeleteFromFolder2(ByVal IDPlan As System.Guid) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  Folder = ''  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compPlan.UpdateDeleteFromFolder2: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanPapierkorb(ByVal idPlan As System.Guid, ByVal deleted As Boolean) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  deleted = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("deleted", System.Data.OleDb.OleDbType.Boolean, 1, "deleted")).Value = deleted
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanPapierkorb: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanReaded(ByVal idPlan As System.Guid, ByVal readed As Boolean) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  readed = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("readed", System.Data.OleDb.OleDbType.Boolean, 1, "readed")).Value = readed
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanReaded: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanDesign(ByVal idPlan As System.Guid, ByVal design As Boolean) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  design = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("design", System.Data.OleDb.OleDbType.Boolean, 1, "design")).Value = design
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanDesign: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanIsOwner(ByVal idPlan As System.Guid, ByVal IsOwner As Boolean) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  IsOwner = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IsOwner", System.Data.OleDb.OleDbType.Boolean, 1, "IsOwner")).Value = IsOwner
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanIsOwner: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanIDUserAccount(ByVal IDPlan As System.Guid, ByVal IDUserAccount As System.Guid) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  IDUserAccount = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDUserAccount", System.Data.OleDb.OleDbType.Guid, 16, "IDUserAccount")).Value = IDUserAccount
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanIDUserAccount: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanReplyTxt(ByVal IDPlan As System.Guid, ByVal ReplyTxt As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
        Command.CommandTimeout = 0
        Command.CommandText = "UPDATE [plan] SET  ReplyTxt = ?  WHERE ID = ? "
        Command.Connection = Me.database.getConnDB()
        Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ReplyTxt", System.Data.OleDb.OleDbType.LongVarChar, 0, "ReplyTxt")).Value = ReplyTxt
        Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
        Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanReplyTxt: " + ex.ToString())
        End Try
    End Function
    Public Function UpdatePlanTextxy(ByVal IDPlan As System.Guid, ByVal txt As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE [plan] SET  Text = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarChar, 0, "Text")).Value = txt
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDPlan
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlanText: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlan(ByVal idPlan As System.Guid, ByVal MessageId As String, ByVal Usr As String,
                               ByVal IDArt As Integer, ByVal Betreff As String) As Boolean
        Try
            If IDArt = clPlan.typPlan_EMailEmpfangen Then
                If Usr.Trim() = "" Then
                    Throw New Exception("deletePlan: Usr for IDPlan '" + idPlan.ToString() + "' is null!")
                End If
                If MessageId.Trim() = "" Then
                    Throw New Exception("deletePlan: MessageId for IDPlan '" + idPlan.ToString() + "' is null!")
                End If

                Dim dsPlanStatus As New dsPlan()
                Me.getPlanStatus(System.Guid.NewGuid().ToString(), eTypSelPlan.MessageId, dsPlanStatus, eStatusPlan.deleted, System.Guid.NewGuid.ToString(), Nothing)
                Dim rNewPlanStatus As dsPlan.planStatusRow = Me.getNewRowPlanStatus(dsPlanStatus.planStatus, MessageId, idPlan, Usr, eStatusPlan.deleted, Betreff)
                Me.daPlanStatus.Update(dsPlanStatus.planStatus)
            End If

            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [plan]  WHERE ID = '" + idPlan.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlan: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanSerientermine(IDSerientermin As Guid) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [plan]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanSerientermine: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanSerientermin(IDSerientermin As Guid, BeginntAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [plan]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' and [plan].BeginntAm > ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 8, "BeginntAm")).Value = BeginntAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanSerientermin: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanSerienterminEndetAm(IDSerientermin As Guid, SerienterminEndetAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [plan]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' and CONVERT(date, [plan].BeginntAm) > ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = SerienterminEndetAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanSerienterminEndetAm: " + ex.ToString())
        End Try
    End Function
    Public Function updatePlanSerienterminEndetAm(IDSerientermin As Guid, SerienterminEndetAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update [plan] set [plan].SerienterminEndetAm = ? where IDSerientermin='" + IDSerientermin.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.Date, 8, "SerienterminEndetAm")).Value = SerienterminEndetAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanSerienterminEndetAm: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlan(ByVal id As System.Guid) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = " Delete from [plan] where ID = '" + id.ToString() + "' "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlan: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowPlan(ByVal dsPlan As dsPlan) As dsPlan.planRow
        Try
            Dim rNew As dsPlan.planRow = dsPlan.plan.NewRow()

            rNew.ID = System.Guid.NewGuid()
            rNew.Betreff = ""
            rNew.IsBeginntAmNull()
            rNew.IsFälligAmNull()
            rNew.SetIDArtNull()
            rNew.Priorität = ""
            rNew.Status = ""
            rNew.Text = ""
            rNew.Zusatz = ""
            rNew.MailFrom = ""
            rNew.MailAn = ""
            rNew.MailCC = ""
            rNew.MailBcc = ""
            rNew.html = False
            rNew.Für = ""
            rNew.IsgesendetAmNull()
            rNew.IsempfangenAmNull()
            rNew.wichtig = False
            rNew.remembJN = False
            rNew.IsremembMinutNull()
            rNew.Teilnehmer = ""
            rNew.ErstelltVon = ""
            rNew.ErstelltAm = Now
            rNew.SetIDActivityNull()
            rNew.SetIDStatusNull()
            rNew.SetIDTypNull()
            rNew.KommStatus = ""
            rNew.SetdbNull()
            rNew.readed = True
            rNew.deleted = False
            rNew.design = False
            rNew.MessageId = ""
            rNew.SetIDUserAccountNull()
            rNew.DetailsMIME = ""
            rNew.SetIDPlanMainNull()
            rNew.ReplyTxt = ""
            rNew.IsOwner = False
            rNew.AwaitingResponse = ""
            rNew.SetIDFolderNull()

            rNew.SetID1TmpNull()
            rNew.SetID2TmpNull()
            rNew.SetID3TmpNull()
            rNew.SendWithPostOfficeBoxForAll = False
            rNew.OutlookAPI = False
            rNew.ConversationID = ""
            rNew.IDoutlook = ""
            rNew.IDoutlookTicks = ""
            rNew.Category = ""
            rNew.Folder = ""
            rNew.SetLastChangeITSContNull()
            rNew.SetLastSyncToExchangeNull()

            rNew.IsSerientermin = False
            rNew.Wochentage = ""
            rNew.SetnTenMonatNull()
            rNew.SerienterminType = ""
            rNew.SetIDSerienterminNull()
            rNew.TagWochenMonat = ""
            rNew.SetWiedWertJedenNull()
            rNew.SetEndetAmNull()
            rNew.Dauer = -1
            rNew.GanzerTag = 0
            rNew.SetSerienterminEndetAmNull()
            rNew.IDKlinik = System.Guid.NewGuid()

            dsPlan.plan.Rows.Add(rNew)

            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowPlan: " + ex.ToString())
        End Try
    End Function

    Public Function deletePlans(ByVal sWhere As String) As Boolean
        Try
            If sWhere.Trim() = "" Then
                Throw New Exception("deletePlans: sWhere='' not allowed!")
            End If

            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "delete [plan] where " + sWhere
            Command.Connection = Me.database.getConnDB()
            Command.CommandTimeout = 0
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.UpdatePlans: " + ex.ToString())
        End Try
    End Function

    Public Function getPlanObject(ByVal id As System.Guid, ByVal typSel As eTypSelPlanObject, ByVal db As dsPlan) As Boolean
        Try
            Me.daPlanObject.SelectCommand.CommandText = Me.sqldaPlanObject
            Me.database.setDBConnection_dataAdapter(Me.daPlanObject)
            Me.daPlanObject.SelectCommand.Parameters.Clear()

            If typSel = eTypSelPlanObject.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daPlanObject.SelectCommand.CommandText += sWhere
                Me.daPlanObject.SelectCommand.Parameters.AddWithValue("ID", id)

            ElseIf typSel = eTypSelPlanObject.allIDPlan Then
                Dim sWhere As String = " where IDPlan = ? "
                Me.daPlanObject.SelectCommand.CommandText += sWhere
                Me.daPlanObject.SelectCommand.Parameters.AddWithValue("IDPlan", id)

            ElseIf typSel = eTypSelPlanObject.IDObject Then
                Dim sWhere As String = " where IDObject = ? "
                Me.daPlanObject.SelectCommand.CommandText += sWhere
                Me.daPlanObject.SelectCommand.Parameters.AddWithValue("IDObject", id)

            Else
                Throw New Exception("getPlanObject: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daPlanObject.Fill(db.planObject)
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanObject: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowPlanObject(tPlanObjects As dsPlan.planObjectDataTable) As dsPlan.planObjectRow
        Try
            Dim rNew As dsPlan.planObjectRow = tPlanObjects.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.IDObject = System.Guid.NewGuid()
            rNew.IDPlan = System.Guid.NewGuid()
            rNew.SetIDSelListNull()
            rNew.Status = ""

            tPlanObjects.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowPlanObject: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanObject(ByVal idPlan As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  planObject  WHERE IDPlan = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("idPlan", System.Data.OleDb.OleDbType.Guid, 16, "idPlan")).Value = idPlan
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanObject: " + ex.ToString())
        End Try
    End Function


    Public Function getPlanAnhang(ByVal id As System.Guid, ByVal typSel As eTypSelPlanAnhang, ByVal db As dsPlan) As Boolean
        Try
            Me.daPlanAnhang.SelectCommand.CommandText = Me.sqldaPlanAnhang
            Me.database.setDBConnection_dataAdapter(Me.daPlanAnhang)
            Me.daPlanAnhang.SelectCommand.Parameters.Clear()

            If typSel = eTypSelPlanAnhang.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daPlanAnhang.SelectCommand.CommandText += sWhere
                Me.daPlanAnhang.SelectCommand.Parameters.AddWithValue("ID", id)

            ElseIf typSel = eTypSelPlanAnhang.idPlan Then
                Dim sWhere As String = " where IDPlan = ? "
                Me.daPlanAnhang.SelectCommand.CommandText += sWhere
                Me.daPlanAnhang.SelectCommand.Parameters.AddWithValue("IDPlan", id)

            Else
                Throw New Exception("getPlanAnhang: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daPlanAnhang.Fill(db.planAnhang)
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanAnhang: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowPlanAnhang(ByRef tPlanAnhang As dsPlan.planAnhangDataTable,
                                        ByRef idPlan As System.Guid) As dsPlan.planAnhangRow
        Try
            Dim rNew As dsPlan.planAnhangRow = tPlanAnhang.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.IDPlan = idPlan
            rNew.Bezeichnung = ""
            rNew.DateiTyp = ""
            rNew.SetdokuNull()
            tPlanAnhang.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowPlanAnhang: " + ex.ToString())
        End Try
    End Function

    Public Function deletePlanAnhang(ByVal idPlan As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  planAnhang  WHERE IDPlan = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("idPlan", System.Data.OleDb.OleDbType.Guid, 16, "idPlan")).Value = idPlan
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanAnhang: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanAnhang(ByVal idPlan As System.Guid, ByVal IDDoku As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  planAnhang  WHERE IDPlan = ? and IDDoku = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("idPlan", System.Data.OleDb.OleDbType.Guid, 16, "idPlan")).Value = idPlan
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 16, "IDDoku")).Value = IDDoku
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanAnhang: " + ex.ToString())
        End Try
    End Function

    Public Function getPlanStatus(ByVal MessageId As String, ByVal typSel As eTypSelPlan, ByVal db As dsPlan,
                                  ByVal StatusPlan As eStatusPlan, ByVal Usr As String, ByVal IDPlan As System.Guid) As Boolean
        Try
            Me.daPlanStatus.SelectCommand.CommandText = Me.sqldaPlanStatus
            Me.database.setDBConnection_dataAdapter(Me.daPlanStatus)
            Me.daPlanStatus.SelectCommand.Parameters.Clear()

            If typSel = eTypSelPlan.MessageId Then
                Dim sWhere As String = " where MessageId = ? and Status = ? and Usr = ? "
                Me.daPlanStatus.SelectCommand.CommandText += sWhere
                Me.daPlanStatus.SelectCommand.Parameters.AddWithValue("MessageId", MessageId)
                Me.daPlanStatus.SelectCommand.Parameters.AddWithValue("Status", StatusPlan.ToString())
                Me.daPlanStatus.SelectCommand.Parameters.AddWithValue("Usr", Usr)

            ElseIf typSel = eTypSelPlan.MessageIdNoUser Then
                Dim sWhere As String = " where MessageId = ? and Status = ? "
                Me.daPlanStatus.SelectCommand.CommandText += sWhere
                Me.daPlanStatus.SelectCommand.Parameters.AddWithValue("MessageId", MessageId)
                Me.daPlanStatus.SelectCommand.Parameters.AddWithValue("Status", StatusPlan.ToString())

            ElseIf typSel = eTypSelPlan.IDPlan Then
                Dim sWhere As String = " where IDPlan = '" + IDPlan.ToString() + "' and Status='" + StatusPlan.ToString() + "' "
                Me.daPlanStatus.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("getPlanStatus: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daPlanStatus.Fill(db.planStatus)
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanStatus: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowPlanStatus(ByRef tPlanStatus As dsPlan.planStatusDataTable,
                                        ByRef MessageId As String,
                                        ByRef IDPlan As System.Guid,
                                        ByRef Usr As String, ByRef Status As eStatusPlan, ByVal Betreff As String) As dsPlan.planStatusRow
        Try
            Dim rNew As dsPlan.planStatusRow = tPlanStatus.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.IDPlan = IDPlan
            rNew.MessageId = MessageId
            rNew.Betreff = Betreff
            rNew.Status = Status.ToString()
            rNew.Usr = Usr
            rNew.Am = Now
            rNew.IsContact = False
            tPlanStatus.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowPlanStatus: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanStatus(ByVal idPlan As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  planStatus  WHERE idPlan = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("idPlan", System.Data.OleDb.OleDbType.Guid, 16, "idPlan")).Value = idPlan
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanStatus: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanStatus(ByVal idPlan As System.Guid, Status As String) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  planStatus  WHERE idPlan='" + idPlan.ToString() + "' and Status='" + Status.Trim() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanStatus: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowSelListEntriesTmp(ByRef ds As dsClipboard) As dsClipboard.tblSelListEntriesTmpRow
        Try
            Dim rNew As dsClipboard.tblSelListEntriesTmpRow = ds.tblSelListEntriesTmp.NewRow()
            rNew.ID = -999
            rNew.Bezeichnung = ""
            rNew.IDOwnInt = -1
            rNew.IDOwnStr = ""
            rNew.IDGuid = System.Guid.NewGuid()
            rNew.IDGroup = -999

            ds.tblSelListEntriesTmp.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowSelListEntriesTmp: " + ex.ToString())
        End Try
    End Function



    Public Function getPlanBereich(ByVal id As System.Guid, ByVal typSel As eTypSelPlanBereich, ByVal db As dsPlan) As Boolean
        Try
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            Me.daPlanBereich.SelectCommand.CommandText = Me.sqldaPlanBereich
            Me.database.setDBConnection_dataAdapter(Me.daPlanBereich)
            Me.daPlanBereich.SelectCommand.Parameters.Clear()

            If typSel = eTypSelPlanBereich.IDPlan Then
                Dim sWhere As String = " where ID = ? "
                Me.daPlanBereich.SelectCommand.CommandText += sWhere
                Me.daPlanBereich.SelectCommand.Parameters.AddWithValue("ID", id)

            ElseIf typSel = eTypSelPlanBereich.IDPlanMain Then
                Dim sWhere As String = " where IDPlanMain = ? "
                Me.daPlanBereich.SelectCommand.CommandText += sWhere
                Me.daPlanBereich.SelectCommand.Parameters.AddWithValue("IDPlanMain", id)

            Else
                Throw New Exception("getPlanBereich: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daPlanBereich.Fill(db.planBereich)
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.getPlanBereich: " + ex.ToString())
        End Try
    End Function

    Public Function updatePlanBereichStatus(ByVal idPlan As System.Guid, ByVal status As String) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update  [planBereich] set status = '" + status + "'  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.AddWithValue("ID", idPlan)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updatePlanBereichStatus: " + ex.ToString())
        End Try
    End Function
    Public Function updatePlanBereichSerienterminEndetAm(IDSerientermin As Guid, SerienterminEndetAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update [planBereich] set [planBereich].SerienterminEndetAm = ? where IDSerientermin='" + IDSerientermin.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.Date, 8, "SerienterminEndetAm")).Value = SerienterminEndetAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.updatePlanBereichSerienterminEndetAm: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanBereichSerientermine(IDSerientermin As Guid) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [planBereich]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanBereichSerientermine: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanBereichSerientermin(IDSerientermin As Guid, BeginntAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [planBereich]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' and [planBereich].BeginntAm > ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 8, "BeginntAm")).Value = BeginntAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanBereichSerientermin: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanBereichSerienterminEndetAm(IDSerientermin As Guid, SerienterminEndetAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  [planBereich]  WHERE IDSerientermin = '" + IDSerientermin.ToString() + "' and CONVERT(date, [planBereich].BeginntAm) > ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = SerienterminEndetAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanBereichSerienterminEndetAm: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanBereichSerienterminEndetAm2(IDSerientermin As Guid, SerienterminEndetAm As Date) As Boolean
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "update [planBereich] set [planBereich].SerienterminEndetAm = ? where IDSerientermin='" + IDSerientermin.ToString() + "' "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.Date, 8, "SerienterminEndetAm")).Value = SerienterminEndetAm.Date
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanBereichSerienterminEndetAm2: " + ex.ToString())
        End Try
    End Function
    Public Function deletePlanBereich(ByVal id As System.Guid) As Boolean
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = " Delete from [planBereich] where ID = '" + id.ToString() + "' "
            cmd.CommandTimeout = 0
            cmd.Connection = Me.database.getConnDB()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("compPlan.deletePlanBereich: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowPlanBereich(ByVal dsPlan As dsPlan) As dsPlan.planBereichRow
        Try
            Dim dNow As DateTime = DateTime.Now

            Dim rNew As dsPlan.planBereichRow = dsPlan.planBereich.NewRow()

            rNew.ID = System.Guid.NewGuid()
            rNew.Betreff = ""
            rNew.SetBeginntAmNull()
            rNew.SetEndetAmNull()
            rNew.Text = ""
            rNew.lstAbteilungen = ""
            rNew.lstBereiche = ""
            rNew.Status = ""
            rNew.Category = ""
            rNew.Folder = ""
            rNew.Teilnehmer = ""
            rNew.SetIDSerienterminNull()
            rNew.TagWochenMonat = ""
            rNew.SetWiedWertJedenNull()
            rNew.Wochentage = ""
            rNew.SetnTenMonatNull()
            rNew.SerienterminType = ""
            rNew.Dauer = 0
            rNew.GanzerTag = False
            rNew.IsSerientermin = False
            rNew.SetSerienterminEndetAmNull()
            rNew.IDKlinik = System.Guid.NewGuid()
            rNew.CreatedFrom = ""
            rNew.CreatedAt = dNow
            rNew.LastChangeFrom = ""
            rNew.LastChangeAt = dNow
            rNew.SetIDPlanMainNull()
            rNew.SetIDAbteilungNull()
            rNew.SetIDBereichNull()
            rNew.lstBerufsgruppen = ""

            dsPlan.planBereich.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compPlan.getNewRowPlanBereich: " + ex.ToString())
        End Try
    End Function

End Class

