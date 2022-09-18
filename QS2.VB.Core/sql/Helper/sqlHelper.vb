

Public Class sqlHelper

    Public sel_daSelListObjDoubledSelLists As String = ""
    Public sel_daSelListObjDoubledFldShorts As String = ""

    Public Enum eTypeSel
        All = 0
    End Enum

    Public database As New qs2.core.dbBase()







    Public Sub initControl()
        Me.sel_daSelListObjDoubledSelLists = Me.daSelListObjDoubledSelLists.SelectCommand.CommandText
        Me.sel_daSelListObjDoubledFldShorts = Me.daSelListObjDoubledFldShorts.SelectCommand.CommandText
    End Sub



    Public Function getSelListObjDoubledSelLists(ByRef eTypeSel As eTypeSel, ByRef ds As dsHelper) As Boolean
        Try
            Me.daSelListObjDoubledSelLists.SelectCommand.CommandText = Me.sel_daSelListObjDoubledSelLists
            database.setConnection(Me.daSelListObjDoubledSelLists)
            Me.daSelListObjDoubledSelLists.SelectCommand.Parameters.Clear()

            If eTypeSel = eTypeSel.All Then
                Dim xy As String = ""

            Else
                Throw New Exception("getSelListObjDoubledSelLists: eTypeSel '" + eTypeSel.ToString() + "' is wrong!")
            End If

            Me.daSelListObjDoubledSelLists.Fill(ds.tblSelListObjDoubledSelLists)
            Return True

        Catch ex As Exception
            Throw New Exception("getSelListObjDoubledSelLists: " + ex.ToString())
        End Try
    End Function

    Public Function getSelListObjDoubledFldShorts(ByRef eTypeSel As eTypeSel, ByRef ds As dsHelper) As Boolean
        Try
            Me.daSelListObjDoubledFldShorts.SelectCommand.CommandText = Me.sel_daSelListObjDoubledFldShorts
            database.setConnection(Me.daSelListObjDoubledFldShorts)
            Me.daSelListObjDoubledFldShorts.SelectCommand.Parameters.Clear()

            If eTypeSel = eTypeSel.All Then
                Dim xy As String = ""

            Else
                Throw New Exception("getSelListObjDoubledFldShorts: eTypeSel '" + eTypeSel.ToString() + "' is wrong!")
            End If

            Me.daSelListObjDoubledFldShorts.Fill(ds.tblSelListObjDoubledFldShorts)
            Return True

        Catch ex As Exception
            Throw New Exception("getSelListObjDoubledFldShorts: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowSettings(ByRef ds As dsHelper) As dsHelper.tblSettingsRow
        Try
            Dim rSetting As dsHelper.tblSettingsRow = ds.tblSettings.NewRow()
            rSetting.ID = System.Guid.NewGuid()
            rSetting.Variable = ""
            rSetting.Value = ""
            rSetting.validFor = ""
            rSetting.IDParticipant = ""
            rSetting.Product = ""

            ds.tblSettings.Rows.Add(rSetting)
            Return rSetting

        Catch ex As Exception
            Throw New Exception("getNewRowSettings: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowBrackets(ByRef ds As dsHelper) As dsHelper.QueriesClampsRow
        Try
            Dim rNew As dsHelper.QueriesClampsRow = ds.QueriesClamps.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.Sort = -1
            rNew.ClampKey = -1
            rNew.ClampEbene = -1
            rNew.rQry = ""

            ds.QueriesClamps.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("getNewRowBrackets: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowProtocol(ByRef ds As dsHelper) As dsHelper.ProtocolRow
        Try
            Dim rNew As dsHelper.ProtocolRow = ds.Protocol.NewRow()
            rNew.SetChangedAtNull()
            rNew.FromUser = ""
            rNew.MedRecNr = ""
            rNew.ColName = ""
            rNew.ImputType = ""
            rNew.OldValue = ""
            rNew.NewValue = ""
            rNew.NewValueDB = ""
            rNew.OldValueDB = ""
            rNew.IDStay = -1
            rNew.IDApplication = ""
            rNew.IDParticipant = ""
            rNew.SetProtFromNull()
            rNew.SqlTable = ""
            rNew.FldShort = ""

            ds.Protocol.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("getNewRowProtocol: " + ex.ToString())
        End Try
    End Function

End Class
