


Public Class cSendStay



    Public Sub SendStay(ByRef rStayFound As qs2.core.vb.dsObjects.tblStayRow, ByRef iSent As Integer, ByRef dsToSend As DataSet,
                        ByRef iCounterColumnsAnonymoused As Integer)
        Try
            Dim dsObjectEmpty As New dsObjects()
            Dim dsObjects1 As New dsObjects
            Dim sqlObjects1 As New sqlObjects()
            sqlObjects1.initControl()
            Dim rStay As dsObjects.tblStayRow = sqlObjects1.getStaysRow(-999, sqlObjects.eTypSelStay.IDGuidStay, license.doLicense.eApp.ALL.ToString(), Enums.eStayTyp.All, "", rStayFound.IDGuid, False)
            Dim newTable As DataTable = dsObjectEmpty.tblStay.Copy()
            dsToSend.Tables.Add(newTable)
            Dim rNew As DataRow = dsToSend.Tables(dsObjects1.tblStay.TableName.Trim()).NewRow()
            rNew.ItemArray = rStay.ItemArray
            dsToSend.Tables(dsObjects1.tblStay.TableName.Trim()).Rows.Add(rNew)

            Dim rPatient As dsObjects.tblObjectRow = sqlObjects1.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", rStayFound.PatIDGuid)
            newTable = dsObjectEmpty.tblObject.Copy()
            dsToSend.Tables.Add(newTable)
            rNew = dsToSend.Tables(dsObjects1.tblObject.TableName.Trim()).NewRow()
            rNew.ItemArray = rPatient.ItemArray
            dsToSend.Tables(dsObjects1.tblObject.TableName.Trim()).Rows.Add(rNew)

            Dim rPatientMainAdress As dsObjects.tblAdressRow = sqlObjects1.getAdressMain(rStayFound.PatIDGuid)
            newTable = dsObjectEmpty.tblAdress.Copy()
            dsToSend.Tables.Add(newTable)
            rNew = dsToSend.Tables(dsObjects1.tblAdress.TableName.Trim()).NewRow()
            rNew.ItemArray = rPatientMainAdress.ItemArray
            dsToSend.Tables(dsObjects1.tblAdress.TableName.Trim()).Rows.Add(rNew)

            Dim iCounterTable As Integer = 1
            Dim dsSysDB1 As New core.SysDB.dsSysDB()
            Dim sqlSysDB1 As New core.SysDB.sqlSysDB()
            sqlSysDB1.initControl()
            sqlSysDB1.getTables(dsSysDB1, SysDB.sqlSysDB.eTypSelColumns.likeTableName, rStayFound.IDApplication.Trim())
            For Each rTableToSend As qs2.core.SysDB.dsSysDB.TablesCatalogRow In dsSysDB1.TablesCatalog
                Dim dsStays As New DataSet()
                Dim parameters As New System.Collections.Generic.List(Of System.Data.SqlClient.SqlParameter)
                Dim ParametersAsTxt As String = ""
                qs2.core.dbBase.fillDataSet("Select * from " + qs2.core.dbBase.dbSchema + rTableToSend.TABLE_NAME.Trim() + " where ID=" + rStay.ID.ToString() + " and " + _
                                            " IDApplication='" + rStay.IDApplication.Trim() + "' and IDParticipant='" + rStay.IDParticipant.Trim() + "'", parameters, dsStays, rTableToSend.TABLE_NAME.Trim(), "dsProductStays", ParametersAsTxt, False)
                If dsStays.Tables(0).Rows.Count <> 1 Then
                    Throw New Exception("cSendStay.SendStay: dsStays.Tables(0).Rows.Count <> 1 for IDStayGuid'" + rStay.IDGuid.ToString() + "'!")
                End If
                Dim rproductStay As DataRow = dsStays.Tables(0).Rows(0)
                newTable = dsStays.Tables(0).Copy()
                dsToSend.Tables.Add(newTable)
                iCounterTable += 1
            Next

            Dim dsAdminEmpty As New dsAdmin()
            Dim dsAdmin1 As New dsAdmin()
            Dim sqlAdmin1 As New sqlAdmin()
            sqlAdmin1.initControl()
            sqlAdmin1.getStayAdditions(rStay.ID, rStay.IDParticipant.Trim(), dsAdmin1, sqlAdmin.eTypSelStayAdditions.idStayAll, _
                                        sqlAdmin.eTypStayAdditions.assignStay, rStay.IDApplication.Trim(), Nothing, "", True)
            newTable = dsAdmin1.tblStayAdditions.Copy()
            dsToSend.Tables.Add(newTable)
            iCounterTable += 1

            dsAdmin1 = New dsAdmin()
            sqlAdmin1.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.ProceduresToStay, sqlAdmin.eDbTypAuswObj.ProceduresToStay.ToString(), dsAdmin1, sqlAdmin.eTypAuswahlObj.IDStayTypIDGroup,
                                          rStay.IDApplication.Trim(), -999, "", rStay.ID, rStay.IDParticipant.Trim())
            newTable = dsAdmin1.tblSelListEntriesObj.Copy()
            dsToSend.Tables.Add(newTable)

            dsAdmin1 = New dsAdmin()
            sqlAdmin1.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.CompletedChapter, sqlAdmin.eDbTypAuswObj.CompletedChapter.ToString(), dsAdmin1, sqlAdmin.eTypAuswahlObj.IDStayTypIDGroup,
                                          rStay.IDApplication.Trim(), -999, "", rStay.ID, rStay.IDParticipant.Trim())
            For Each rSelListObjToCopy As dsAdmin.tblSelListEntriesObjRow In dsAdmin1.tblSelListEntriesObj
                Dim rNewSelListObj As DataRow = newTable.NewRow()
                rNewSelListObj.ItemArray = rSelListObjToCopy.ItemArray
                newTable.Rows.Add(rNewSelListObj)
            Next
            iCounterTable += 1

            Me.anonymization(rStayFound, dsToSend, iCounterColumnsAnonymoused)
            'dsToSend.WriteXml("H:\\ds.xml")

        Catch ex As Exception
            Throw New Exception("cSendStay.SendStay: " + ex.ToString())
        End Try
    End Sub

    Public Sub anonymization(ByRef rStayFound As qs2.core.vb.dsObjects.tblStayRow, ByRef dsToSend As DataSet, _
                             ByRef iCounterColumnsAnonymoused As Integer)
        Try
            Dim dsAdmin1 As New dsAdmin()
            Dim sqlAdmin1 As New qs2.core.vb.sqlAdmin()

            qs2.core.vb.sqlAdmin.getSelList(Nothing, Nothing, "AnonymousColumns", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAdmin1, sqlAdmin.eTypAuswahlList.groupParticipantOwnOrAll)
            For Each TableFound As DataTable In dsToSend.Tables
                Dim lstColumnsToAnonymize As New System.Collections.Generic.List(Of dsAdmin.tblSelListEntriesRow)
                For Each ColumnFound As DataColumn In TableFound.Columns
                    If ColumnFound.ColumnName.Trim().ToLower().Equals(("PatZIP").Trim().ToLower()) Then
                        Dim xy As String = ""
                    End If
                    For Each rSelListAnonymousColumn As dsAdmin.tblSelListEntriesRow In dsAdmin1.tblSelListEntries
                        If rSelListAnonymousColumn.FldShortColumn.Trim().ToLower().Equals(("PatZIP").Trim().ToLower()) Then
                            Dim xy As String = ""
                        End If
                        If rSelListAnonymousColumn.FldShortColumn.Trim().ToLower().Equals(ColumnFound.ColumnName.Trim().ToLower()) And _
                            rSelListAnonymousColumn._Table.Trim().ToLower().Equals(ColumnFound.Table.TableName.Trim().ToLower()) Then
                            lstColumnsToAnonymize.Add(rSelListAnonymousColumn)
                        End If
                    Next
                Next

                For Each rFound As DataRow In TableFound.Rows
                    For Each rSelListAnonymousColumn As dsAdmin.tblSelListEntriesRow In lstColumnsToAnonymize
                        Dim oValueColumn As Object = rFound(rSelListAnonymousColumn.FldShortColumn.Trim())
                        Dim TypeIntern As qs2.core.dbBase.eTypeInt = qs2.core.dbBase.GetType(oValueColumn.GetType())
                        If TypeIntern = core.dbBase.eTypeInt.t_int Or TypeIntern = core.dbBase.eTypeInt.t_dbl Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = -1
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_string Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = "***"
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_DateTime Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = New Date(1900, 1, 1)
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_Guid Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = System.Guid.Empty
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_DBNull Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = System.DBNull.Value
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_Binary Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = System.DBNull.Value
                        ElseIf TypeIntern = core.dbBase.eTypeInt.t_Boolean Then
                            rFound(rSelListAnonymousColumn.FldShortColumn.Trim()) = False
                        Else
                            Throw New Exception("anonymization: TypeIntern '" + TypeIntern.ToString() + "' not allowed!")
                        End If
                        iCounterColumnsAnonymoused += 1
                    Next
                Next
            Next

        Catch ex As Exception
            Throw New Exception("cSendStay.anonymization: " + ex.ToString())
        End Try
    End Sub

End Class
