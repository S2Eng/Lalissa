

Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Public Class Protocol : Implements IDisposable


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    Dim handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)
    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                handle.Dispose()
                ' TODO: dispose managed state (managed objects).
            End If

            _dsNew = Nothing
            _dsOrig = Nothing

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Enum eTypeProtocoll
        Stay = 60300
        Obj = 60301
        sKey = 60302
        RunQuery = 60303
        RunReport = 60304
        SearchPatient = 60305
        SearchUser = 60306
        DeletePatient = 60307
        DeleteUser = 60308
        DeleteStay = 60309

        Import = 60310
        PrepareUpload = 60311
        RunUpload = 60312

        Send = 60314
        Reset = 60315
        Completed = 60316

        LoggedIn = 60317
        LoggedOut = 60318
        StayOpen = 60319
        StayAutoResetFields = 60321

        RecalculateBulk = 60320
        ExceptionQS2 = 60322
        RigthRolesChanged = 60323
        ManageDeathStatus = 60324
        UpdateData = 60325
        SearchProtocoll = 60326
        HL7Send = 60328

        NotCompleted = 60327

    End Enum

    Private _dsNew As DataSet = Nothing
    Private _dsOrig As DataSet = Nothing

    Public Class table
        Public fields As New System.Collections.Generic.List(Of field)
        Public tableName As String = ""
        Public tableOrig As DataTable = Nothing
        Public tableNew As DataTable = Nothing
        Public arrKeysTable() As qs2.core.SysDB.dsSysDB.SysKeyColumnUsageRow
        Public sWherePrimaryKeys As String = ""
    End Class
    Public Class field
        Public rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow = Nothing
        Public dataColumn As DataColumn = Nothing
        Public isPrimaryKey As Boolean = False
        Public TypeField As qs2.core.dbBase.TypeField = Nothing
    End Class

    Public Enum eActionProtocol
        AddNew = 0
        Changed = 1
        DeleteRow = 2

        None = -100
    End Enum













    Public Shared Sub saveExceptionToProtocol(except As String, Info As String, IDStay As Integer, IDApplication As String, IDParticipant As String)
        Try
            Using Protocol1 As New qs2.core.vb.Protocol()
                Protocol1.save2(Protocol.eTypeProtocoll.ExceptionQS2, Nothing, IDStay, IDParticipant, IDApplication, "",
                            except, Protocol.eActionProtocol.None, "", "")
            End Using

        Catch ex As Exception
            Dim sExcept As String = ex.ToString()
            'Throw New Exception("Protocol.saveExceptionToProtocol: " + sExcept.Trim())
        End Try
    End Sub

    Public Shared Function savexy(ByRef ProtocolTxt As String,
                                     ByRef IDPatient As System.Guid,
                                     ByRef IDStay As Integer, ByRef IDApplication As String, IDParticipant As String,
                                     ByRef TypeProtocoll As qs2.core.vb.Protocol.eTypeProtocoll, Patient As String, MedRecNr As String) As Boolean
        Try
            Using ProtocollManager As New Protocol()
                ProtocollManager.save2(qs2.core.vb.Protocol.eTypeProtocoll.Obj, IDPatient, IDStay,
                                    IDParticipant, IDApplication, "", ProtocolTxt, vb.Protocol.eActionProtocol.None, Patient, MedRecNr)
            End Using
            Return True

        Catch ex As Exception
            Throw New Exception("Protocol.save: " + ex.ToString())
        End Try
    End Function

    Public Function save2(ByVal type As eTypeProtocoll,
                         ByVal IDGuidObject As System.Guid, ByVal IDStay As Integer, ByVal IDParticipant As String, ByVal IDApplication As String,
                         ByVal sKey As String, ByVal Info As String, ByVal ActionProtocol As eActionProtocol,
                         Patient As String, MedRecNr As String, Optional sProtocol As String = "", Optional sSQL As String = "", Optional InfoFile As String = "") As Boolean

        Try

            Using sqlProtocolSave As New sqlProtocoll()
                Dim dsProtocolToSave As New dsProtocol()

                Dim SqlCommand As String = ""
                sqlProtocolSave.initControl()
                sqlProtocolSave.getProtocol(System.Guid.NewGuid(), dsProtocolToSave, sqlProtocoll.eSelProtocoll.ID, "", System.Guid.Empty,
                                            qs2.core.generic.idMinus, "", "", Nothing, Nothing, "", SqlCommand, True)
                Dim rNewProt As dsProtocol.ProtocolRow = sqlProtocolSave.newProtocol(dsProtocolToSave)

                rNewProt.Type = type.ToString()
                rNewProt.IDParticipant = IDParticipant
                rNewProt.IDApplication = IDApplication
                rNewProt.Patient = Patient.Trim()
                rNewProt.MedRecNr = MedRecNr.Trim()

                If type = eTypeProtocoll.Stay Then
                    rNewProt.IDStay = IDStay
                    rNewProt.Info = Info.Trim()
                ElseIf type = eTypeProtocoll.Obj Then
                    rNewProt.IDGuidObject = IDGuidObject
                    rNewProt.Info = Info.Trim()
                ElseIf type = eTypeProtocoll.sKey Then
                    rNewProt.sKey = sKey
                    rNewProt.Info = Info.Trim()
                Else
                    'Throw New Exception("Protocoll.save: type '" + type.ToString() + "' not supported!")
                End If

                Dim sTxtChanged As String = ""
                If type = eTypeProtocoll.SearchPatient Or type = eTypeProtocoll.SearchUser Or type = eTypeProtocoll.RunQuery Or type = eTypeProtocoll.RunReport Then
                    rNewProt.Protocol = Info.Trim()
                    If IDGuidObject <> Nothing Then
                        rNewProt.IDGuidObject = IDGuidObject
                    End If
                    If IDStay > -9 Then
                        rNewProt.IDStay = IDStay
                    End If

                ElseIf type = eTypeProtocoll.ExceptionQS2 Then
                    rNewProt.Protocol = Info.Trim()

                ElseIf type = eTypeProtocoll.ManageDeathStatus Then
                    rNewProt.IDGuidObject = IDGuidObject
                    rNewProt.InfoFile = InfoFile
                    rNewProt.Sql = sSQL
                    rNewProt.Info = Info.Trim()
                    rNewProt.Protocol = sProtocol.Trim()

                ElseIf type = eTypeProtocoll.UpdateData Then
                    rNewProt.Info = Info.Trim()
                    rNewProt.Protocol = sProtocol.Trim()

                ElseIf type = eTypeProtocoll.HL7Send Then
                    rNewProt.Info = Info.Trim()
                    rNewProt.Protocol = sProtocol.Trim()

                ElseIf type = eTypeProtocoll.SearchProtocoll Then
                    rNewProt.Info = sProtocol.Trim()
                    rNewProt.Protocol = Info.Trim()

                ElseIf type = eTypeProtocoll.Import Or type = eTypeProtocoll.RecalculateBulk Then
                    rNewProt.Protocol = Info.Trim()

                ElseIf type = eTypeProtocoll.LoggedIn Or type = eTypeProtocoll.LoggedOut Then
                    rNewProt.Protocol = Info.Trim()

                ElseIf type = eTypeProtocoll.StayOpen Then
                    rNewProt.Protocol = Info.Trim()
                    rNewProt.IDStay = IDStay
                    rNewProt.IDGuidObject = IDGuidObject

                ElseIf type = eTypeProtocoll.RigthRolesChanged Then
                    rNewProt.Protocol = Info.Trim()
                    rNewProt.IDGuidObject = IDGuidObject

                ElseIf type = eTypeProtocoll.StayAutoResetFields Then
                    rNewProt.Protocol = sProtocol.Trim()
                    rNewProt.IDStay = IDStay
                    rNewProt.IDGuidObject = IDGuidObject
                    rNewProt.Info = Info.Trim()

                ElseIf type = eTypeProtocoll.DeletePatient Or type = eTypeProtocoll.DeleteUser Then
                    rNewProt.Protocol = Info.Trim()
                    rNewProt.IDGuidObject = IDGuidObject

                ElseIf type = eTypeProtocoll.DeleteStay Then
                    rNewProt.Protocol = Info.Trim()
                    rNewProt.IDStay = IDStay

                ElseIf type = eTypeProtocoll.PrepareUpload Or type = eTypeProtocoll.RunUpload Or type = eTypeProtocoll.Send _
                        Or type = eTypeProtocoll.Reset Or type = eTypeProtocoll.Completed Or type = eTypeProtocoll.NotCompleted Then
                    rNewProt.Protocol = Info.Trim()
                    rNewProt.IDStay = IDStay
                    rNewProt.IDParticipant = IDParticipant
                    rNewProt.IDApplication = IDApplication
                    rNewProt.IDGuidObject = IDGuidObject

                ElseIf type = eTypeProtocoll.Obj Then
                    Dim lstTables As New System.Collections.Generic.List(Of String)
                    Dim dsDefault As New DataSet()
                    Me.getLstTablesForObject(lstTables, dsDefault)
                    Me.getChanges(type, IDGuidObject, IDStay, IDParticipant, sKey, sTxtChanged, Info, sqlProtocolSave, dsProtocolToSave,
                                    rNewProt, lstTables, dsDefault, False, ActionProtocol)
                    'Me.getChangesSys(type, IDObject, IDStay, IDParticipant, sKey, sTxtChanged, Info, sqlProtocolSave, dsProtocolToSave, rNewProt, lstTables)

                ElseIf type = eTypeProtocoll.Stay Then
                    Dim lstTables As New System.Collections.Generic.List(Of String)
                    Dim dsDefault As New DataSet()
                    Me.getLstTablesForStay(lstTables, dsDefault)
                    Me.getLstTablesForObject(lstTables, dsDefault)
                    Me.getChanges(type, IDGuidObject, IDStay, IDParticipant, sKey, sTxtChanged, Info, sqlProtocolSave, dsProtocolToSave,
                                  rNewProt, lstTables, dsDefault, True, ActionProtocol)
                    'Me.getChangesSys(type, IDObject, IDStay, IDParticipant, sKey, sTxtChanged, Info, sqlProtocolSave, dsProtocolToSave, rNewProt, lstTables)

                Else
                    Throw New Exception("Protocol.save: type '" + type.ToString() + "' not supported!")

                End If

                If Not rNewProt.IsIDGuidObjectNull() Then
                    Me.setObjectForProtocoll(rNewProt.IDGuidObject, rNewProt)
                End If
                If Not rNewProt.IsIDStayNull() And rNewProt.IDApplication.Trim() <> "" And rNewProt.IDParticipant.Trim() <> "" Then

                    Using sqlObjectsReadTmp As New sqlObjects()
                        sqlObjectsReadTmp.initControl()
                        Dim rStay As dsObjects.tblStayRow = sqlObjectsReadTmp.getStaysRow(rNewProt.IDStay, sqlObjects.eTypSelStay.IDIDApplicationIDParticipant,
                                                                                       rNewProt.IDApplication.Trim(), Enums.eStayTyp.All, rNewProt.IDParticipant.Trim(), Nothing, False)
                        If Not rStay Is Nothing Then
                            rNewProt.MedRecNr = rStay.MedRecN.Trim()
                            Me.setObjectForProtocoll(rStay.PatIDGuid, rNewProt)
                        Else
                            Dim bNotFound As Boolean = True
                        End If

                    End Using
                End If

                'If dsProtocolToSave.ProtocolFields.Rows.Count > 0 Then
                If type = eTypeProtocoll.Obj Or type = eTypeProtocoll.Stay Then
                    If sTxtChanged.Trim() <> "" Then
                        rNewProt.Protocol = sTxtChanged.Trim()
                        sqlProtocolSave.daProtocol.Update(dsProtocolToSave.Protocol)
                    End If
                Else
                    sqlProtocolSave.daProtocol.Update(dsProtocolToSave.Protocol)
                End If

                Return True
            End Using



        Catch ex As Exception
            Throw New Exception("Protocol.save: " + ex.ToString())
        End Try
    End Function
    Public Sub setObjectForProtocoll(ByRef IDGuidObject As Guid, ByRef rNewProt As dsProtocol.ProtocolRow)
        Try
            Dim sqlObjectsReadTmp As New sqlObjects()
            sqlObjectsReadTmp.initControl()
            Dim rObj As dsObjects.tblObjectRow = sqlObjectsReadTmp.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none,
                                                                                "", "", IDGuidObject)
            If Not rObj Is Nothing Then
                If rObj.NameCombination.Trim() <> "" Then
                    rNewProt.Patient = rObj.NameCombination.Trim()
                Else
                    rNewProt.Patient = rObj.LastName.Trim() + " " + rObj.FirstName.Trim()
                End If
            Else
                Dim bNotFound As Boolean = True
            End If

        Catch ex As Exception
            Throw New Exception("setObjectForProtocoll: " + ex.ToString())
        End Try
    End Sub
    Public Function getChanges(ByRef type As eTypeProtocoll,
                                  ByRef IDGuidObject As System.Guid, ByRef IDStay As Integer, ByRef IDParticipant As String,
                                  ByRef sKey As String,
                                  ByRef sTxtChanged As String, Info As String,
                                  ByRef sqlProtocolSave As sqlProtocoll, ByRef dsProtocolToSave As dsProtocol,
                                  ByRef rNewProt As dsProtocol.ProtocolRow,
                                  ByRef lstTables As System.Collections.Generic.List(Of String), ByRef dsDefault As DataSet, ByRef isAutoDb As Boolean,
                                  ByVal ActionProtocol As eActionProtocol) As Boolean
        Try
            For Each tableNew As DataTable In Me.dsNew.Tables
                Dim IsStayTable As Boolean = False
                If Me.checkIfTableInListExists(tableNew.TableName, lstTables, IsStayTable) Then
                    If Me.checkIfTableInSysCatalogExists(tableNew.TableName) Then
                        'tableNew.AcceptChanges()
                        ' check different Values for all Rows
                        Dim RowNr As Integer = 0
                        For Each rowOrig As DataRow In tableNew.Rows
                            If rowOrig.RowState = DataRowState.Added Or rowOrig.RowState = DataRowState.Modified Or
                                ActionProtocol = eActionProtocol.AddNew Or ActionProtocol = eActionProtocol.Changed Then
                                Dim sTempExcep As String = "Error saving protocol!" + vbNewLine +
                                                        "       Info: '" + Info.Trim() + "'" + vbNewLine +
                                                        "       Table: '" + tableNew.TableName + "'" + vbNewLine +
                                                        "       {0}" + vbNewLine

                                For Each actColumn As DataColumn In tableNew.Columns
                                    Dim CompareValues As Boolean = True
                                    Dim valueOrig As Object = Nothing
                                    If rowOrig.RowState = DataRowState.Added Or ActionProtocol = eActionProtocol.AddNew Then
                                        Dim rowDefault As DataRow = dsDefault.Tables(tableNew.TableName).Rows(RowNr)
                                        valueOrig = rowDefault(actColumn.ColumnName)

                                    ElseIf rowOrig.RowState = DataRowState.Modified Or ActionProtocol = eActionProtocol.Changed Then
                                        If isAutoDb And IsStayTable Then
                                            Try
                                                valueOrig = Me.dsOrig.Tables(tableNew.TableName).Rows(RowNr)(actColumn.ColumnName)
                                            Catch ex As Exception
                                                valueOrig = "Exception in Field " + actColumn.ColumnName + ", Table" + tableNew.TableName + ""
                                                Dim sExcep As String = "Protocol.getChanges: " + valueOrig + "" + vbNewLine + vbNewLine + ex.ToString()
                                                Me.addToProtocol(tableNew.TableName, actColumn.ColumnName,
                                                             valueOrig.ToString(), "[Error]", sTxtChanged)

                                                Dim Protocol1 As New qs2.core.vb.Protocol()
                                                Protocol1.save2(Protocol.eTypeProtocoll.ExceptionQS2, IDGuidObject, IDStay, IDParticipant, "", "",
                                                                sExcep, Protocol.eActionProtocol.None, "", "")
                                                CompareValues = False
                                            End Try
                                        Else
                                            valueOrig = rowOrig(actColumn.ColumnName, DataRowVersion.Original)
                                        End If

                                    Else
                                        Throw New Exception("Protocol.getChanges: RowState '" + rowOrig.RowState.ToString() + "' is wrong for table '" + tableNew.TableName + "'!")
                                    End If

                                    If CompareValues Then
                                        Dim valueNew As Object = rowOrig(actColumn.ColumnName, DataRowVersion.Current)
                                        If Not (valueOrig Is System.DBNull.Value) And Not (valueNew Is System.DBNull.Value) Then
                                            If valueOrig <> valueNew Then
                                                Me.addToProtocol(tableNew.TableName, actColumn.ColumnName,
                                                                 valueOrig.ToString(), valueNew.ToString(), sTxtChanged)
                                            End If

                                        ElseIf (valueOrig Is System.DBNull.Value) And Not (valueNew Is System.DBNull.Value) Then
                                            Me.addToProtocol(tableNew.TableName, actColumn.ColumnName,
                                                             "null", valueNew.ToString(), sTxtChanged)

                                        ElseIf Not (valueOrig Is System.DBNull.Value) And (valueNew Is System.DBNull.Value) Then
                                            Me.addToProtocol(tableNew.TableName, actColumn.ColumnName,
                                                             valueOrig.ToString(), "null", sTxtChanged)

                                        ElseIf (valueOrig Is System.DBNull.Value) And (valueNew Is System.DBNull.Value) Then
                                        End If
                                    End If
                                Next
                            End If

                            RowNr += 1
                        Next
                    End If
                Else
                    'Throw New Exception("Protocol.getChanges: Table '" + tableNew.TableName + "' not exists in Db-Catalog!")
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Protocol.getChanges: " + ex.ToString())
        End Try
    End Function

    Public Function getChangesSys(ByRef type As eTypeProtocoll,
                     ByRef IDObject As Integer, ByRef IDStay As Integer, ByRef IDParticipant As String,
                     ByRef sKey As String,
                     ByRef sTxtChanged As String, Info As String,
                     ByRef sqlProtocolSave As sqlProtocoll, ByRef dsProtocolToSave As dsProtocol,
                     ByRef rNewProt As dsProtocol.ProtocolRow,
                     ByRef lstTables As System.Collections.Generic.List(Of String)) As Boolean

        Try
            For Each tableOrig As DataTable In Me.dsOrig.Tables
                If Me.checkIfTableInSysCatalogExists(tableOrig.TableName) Then
                    Dim table As New table()
                    table.tableName = tableOrig.TableName
                    table.tableOrig = tableOrig
                    Dim tableNew As DataTable = Me.dsNew.Tables(tableOrig.TableName)
                    table.tableNew = tableNew

                    ' get Sys-Columns
                    For Each columnToCheck As DataColumn In tableOrig.Columns
                        Dim field As New field()
                        field.rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(tableOrig.TableName, columnToCheck.ColumnName, qs2.core.SysDB.sqlSysDB.dsSysDBAll, True)
                        field.dataColumn = columnToCheck
                        table.fields.Add(field)
                    Next

                    ' build Tamplate-Where-Clausel (primary-keys)
                    Me.getPrimaryKeysWhere(table)

                    ' check different Values for all Rows
                    For Each rowOrig As DataRow In table.tableOrig.Rows

                        ' build where-Clausel Orig.Row
                        For Each actField As field In table.fields
                            If actField.isPrimaryKey Then
                                Dim valueOrigKey As Object = rowOrig(actField.rColSys.COLUMN_NAME)
                                Dim retValue As New qs2.core.generic.retValue()
                                dbBase.convertValue(actField.rColSys, valueOrigKey, retValue, actField.TypeField)
                                table.sWherePrimaryKeys += IIf(table.sWherePrimaryKeys.Trim() = "", " ", " and ") + actField.rColSys.COLUMN_NAME + "=" + retValue.valueSql + ""
                            End If
                        Next
                        Dim arrRowNew() As DataRow = table.tableNew.Select(table.sWherePrimaryKeys)
                        Dim sTempExcep As String = "Error saving protocol!" + vbNewLine +
                                                "       Info: '" + Info.Trim() + "'" + vbNewLine +
                                                "       Where-Clausel: '" + table.sWherePrimaryKeys.Trim() + "'" + vbNewLine +
                                                "       Table: '" + table.tableName + "'" + vbNewLine +
                                                "       {0}" + vbNewLine

                        If arrRowNew.Length = 1 Then
                            Dim RowNew As DataRow = arrRowNew(0)
                            For Each actField As field In table.fields
                                Dim valueOrig As Object = rowOrig(actField.rColSys.COLUMN_NAME)
                                Dim valueNew As Object = RowNew(actField.rColSys.COLUMN_NAME)

                                If Not (valueOrig Is System.DBNull.Value) And Not (valueNew Is System.DBNull.Value) Then
                                    If valueOrig <> valueNew Then
                                        Me.addToProtocol(table.tableName, actField.rColSys.COLUMN_NAME,
                                                         valueOrig.ToString(), valueNew.ToString(), sTxtChanged)
                                    End If

                                ElseIf (valueOrig Is System.DBNull.Value) And Not (valueNew Is System.DBNull.Value) Then
                                    Me.addToProtocol(table.tableName, actField.rColSys.COLUMN_NAME,
                                                     "null", valueNew.ToString(), sTxtChanged)

                                ElseIf Not (valueOrig Is System.DBNull.Value) And (valueNew Is System.DBNull.Value) Then
                                    Me.addToProtocol(table.tableName, actField.rColSys.COLUMN_NAME,
                                                     valueOrig.ToString(), "null", sTxtChanged)

                                ElseIf (valueOrig Is System.DBNull.Value) And (valueNew Is System.DBNull.Value) Then
                                End If

                            Next

                        ElseIf arrRowNew.Length > 1 Then
                            Throw New Exception(System.String.Format(sTempExcep, "arrRowNew.Length > 1"))
                        ElseIf arrRowNew.Length = 0 Then
                            Throw New Exception(System.String.Format(sTempExcep, "arrRowNew.Length = 0"))
                        End If
                    Next

                    'For Each columnToCheck As DataColumn In tableOrig.Columns
                    '    Dim actField As field = Me.getField(columnToCheck.ColumnName, table)
                    'Next
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Protocoll.getChanges: " + ex.ToString())
        End Try
    End Function

    Public Sub addToProtocol(ByRef tableName As String, ByRef COLUMN_NAME As String, ByRef valueOrig As String, ByRef valueNew As String,
                             ByRef sTxtChanged As String)
        'Dim rProtocolField As dsProtocol.ProtocolFieldsRow = sqlProtocolSave.newProtocolFields(dsProtocolToSave, table.tableName, actField.rColSys.COLUMN_NAME, _
        '                                                                          valueOrig, valueNew, _
        '                                                                          rNewProt.ID)

        Dim sb As New System.Text.StringBuilder()
        sb.Append("Table: ")
        sb.Append(tableName)
        sb.Append("      Column: ")
        sb.Append(COLUMN_NAME)
        sb.Append(vbNewLine)
        sb.Append("Original value: ")
        sb.Append(vbNewLine)
        sb.Append(valueOrig.Trim())
        sb.Append(vbNewLine)
        sb.Append("New value")
        sb.Append(vbNewLine)
        sb.Append(valueNew.Trim())
        sb.Append(vbNewLine)
        sb.Append(vbNewLine)
        sb.Append("----------------------------------------")
        sb.Append(vbNewLine)
        sTxtChanged += sb.ToString()
    End Sub
    Public Function getField(ByRef ColumnName As String, ByRef table As table) As field
        For Each field As field In table.fields
            If field.rColSys.COLUMN_NAME.Trim().ToLower() = ColumnName.Trim().ToLower() Then
                Return field
            End If
        Next
        Throw New Exception("Protocoll.getField: No Field found for ColumnName '" + ColumnName + "'!")
    End Function
    Public Function getPrimaryKeysWhere(ByRef table As table)
        Me.getPrimaryKeysForTable(table.arrKeysTable, table.tableName)
        For Each rKeyTable As qs2.core.SysDB.dsSysDB.SysKeyColumnUsageRow In table.arrKeysTable
            Dim FieldPrimarKey As field = Me.getField(rKeyTable.COLUMN_NAME, table)
            FieldPrimarKey.isPrimaryKey = True
        Next
    End Function
    Public Function getPrimaryKeysForTable(ByRef arrKeysTable() As qs2.core.SysDB.dsSysDB.SysKeyColumnUsageRow, tableName As String) As Boolean
        arrKeysTable = qs2.core.SysDB.sqlSysDB.dsSysDBAll.SysKeyColumnUsage.Select("TABLE_NAME='" + tableName.Trim().ToLower() + "'", " ORDINAL_POSITION asc ")
        If arrKeysTable.Length = 0 Then
            Throw New Exception("Protocoll.getPrimaryKeysForTable: No Primary keys found in Table '" + tableName + "'!")
        End If
    End Function
    Public Function getMemoryStreamDsFields(ByVal dsFields As dsProtocol) As System.Text.StringBuilder
        Dim str As New System.IO.StringWriter
        dsFields.WriteXml(str, XmlWriteMode.WriteSchema)
        Return str.GetStringBuilder()
    End Function
    Public Function checkIfTableInSysCatalogExists(ByRef tableName As String) As Boolean
        Dim arrTablesCatalog() As qs2.core.SysDB.dsSysDB.TablesCatalogRow = qs2.core.SysDB.sqlSysDB.dsSysDBAll.TablesCatalog.Select("TABLE_NAME='" + tableName.Trim().ToLower() + "'", "")
        If arrTablesCatalog.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function checkIfTableInListExists(ByRef tableNameSearch As String, ByRef lstTables As System.Collections.Generic.List(Of String),
                                                ByRef IsStayTable As Boolean) As Boolean
        If tableNameSearch.Trim().ToLower().StartsWith(("tblStay_").Trim().ToLower()) Then
            IsStayTable = True
            Return True
        End If
        For Each tableNameInList As String In lstTables
            If tableNameInList.Trim().ToLower() = tableNameSearch.Trim().ToLower() Then
                Return True
            End If
        Next
    End Function


    Public Sub getLstTablesForObject(ByRef lstTables As System.Collections.Generic.List(Of String),
                                     ByRef dsDefault As DataSet)

        Dim dsTemp As New dsObjects()
        lstTables.Add(dsTemp.tblObject.TableName)
        lstTables.Add(dsTemp.tblAdress.TableName)

        Dim sqlObjTemp As New sqlObjects()
        sqlObjTemp.initControl()

        sqlObjTemp.getNewRowObject(dsTemp)
        sqlObjTemp.getNewRowAdressen(dsTemp)

        Dim dt As DataTable = dsTemp.Tables(dsTemp.tblObject.TableName).Copy()
        dsDefault.Tables.Add(dt)
        dt = dsTemp.Tables(dsTemp.tblAdress.TableName).Copy()
        dsDefault.Tables.Add(dt)

    End Sub
    Public Sub getLstTablesForStay(ByRef lstTables As System.Collections.Generic.List(Of String),
                                   ByRef dsDefault As DataSet)

        Dim dsTemp As New dsObjects()
        lstTables.Add(dsTemp.tblStay.TableName)

        Dim sqlObjTemp As New sqlObjects()
        sqlObjTemp.initControl()
        sqlObjTemp.getNewRowStay(dsTemp)

        Dim dt As DataTable = dsTemp.Tables(dsTemp.tblStay.TableName).Copy()
        dsDefault.Tables.Add(dt)
    End Sub


    Public Property dsNew() As DataSet
        Get
            Return Me._dsNew
        End Get
        Set(value As DataSet)
            Me._dsNew = New DataSet()
            qs2.core.vb.funct.copyDataset(value, Me._dsNew)
        End Set
    End Property

    Public Property dsOrig() As DataSet
        Get
            Return Me._dsOrig
        End Get
        Set(value As DataSet)
            Me._dsOrig = New DataSet()
            qs2.core.vb.funct.copyDataset(value, Me._dsOrig)
        End Set
    End Property

End Class
