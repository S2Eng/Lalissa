Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System
Imports System.Xml
Imports Microsoft.Win32



Public Class dbGlobal

    Public gen As New General()

    Public Shared srv As String = ""
    Public Shared db As String = ""
    Public Shared usr As String = ""
    Public Shared pwd As String = ""
    Private Shared _connITSCont As New OleDbConnection

    Public Shared timeOutSql As Integer = 360
    Public Shared maxRowsDs As Integer = 5000

    Public Shared typeString As String = "System.String"

    Public Shared typeBoolean As String = "System.Boolean"

    Public Shared typeDate As String = "System.Date"
    Public Shared typeDateTime As String = "System.DateTime"

    Public Shared typeInteger As String = "System.Integer"
    Public Shared typeInt32 As String = "System.Int32"
    Public Shared typeInt64 As String = "System.Int64"

    Public Shared typeDouble As String = "System.Double"
    Public Shared typeDecimal As String = "System.Decimal"

    Public Shared typeGuid As String = "System.Guid"
    Public Shared typeDBNull As String = "System.DBNull"

    Public Shared typeSubtable As String = "System.Subtable"

    Public Shared intNull As Integer = -999
    Public Shared dateTimeNull As New DateTime(1900, 1, 1)


    Public Shared error_NoInput As String = "NoInput"
    Public Shared error_NotExists As String = "NotExists"
    Public Shared error_MoreThanOneFound As String = "MoreThanOneFound  "
    Public Shared error_InputWrong As String = "InputWrong"

    Public Shared usrWebservice As String = "Webservice"

    Public Enum eTypeSubtable
        Contracts = 0
        Objects = 1
    End Enum

    Public Class cSqlResultIntern
        Public IDHelp As System.Guid = Nothing
        Public strHelp As System.Guid = Nothing
        Public dsHelp As DataSet()
        Public cServiceResult1 As cServiceResult
    End Class
    Public Class eRowToDb
        Public row As System.Data.DataRow = Nothing
        Public tableNameSqlServer As String = ""
        Public addAutoRow As Boolean = True
    End Class


    Public Property ConnITSCont() As OleDbConnection
        Get
            If dbGlobal._connITSCont.State <> ConnectionState.Open Then
                Me.doConnect()
            End If
            Return dbGlobal._connITSCont

        End Get
        Set(ByVal Value As OleDbConnection)
            Throw New Exception("Error to connect to database! Property ConnITSCont")
        End Set
    End Property
    Public Function doConnect() As Boolean
        dbGlobal._connITSCont = New OleDbConnection

        'dbGlobal._connITSCont.ConnectionString = "User ID=" + dbGlobal.usr + ";" + _
        '"Tag with column collation when possible=False;Data Source=" + Trim(dbGlobal.srv) + ";" + _
        '"Password=" + dbGlobal.pwd + ";Initial Catalog=" + Trim(dbGlobal.db) + ";" + _
        '"Use Procedure for Prepare=1;Auto Translate=True;" + _
        '"Persist Security Info=True;Provider=""SQLOLEDB.1"";Workstation ID=" + My.Computer.Name + ";" + _
        '"Use Encryption for Data=False;Packet Size=4096;Connect Timeout=60000;"

        dbGlobal._connITSCont.ConnectionString = ENV.conntStr

        dbGlobal._connITSCont.Open()
        Return True
    End Function
    Public Sub disconnect()
        dbGlobal._connITSCont.Close()
    End Sub

    Public Sub setDBConnection_dataAdapter(ByRef da As System.Data.OleDb.OleDbDataAdapter)

        If Not da.SelectCommand Is Nothing Then da.SelectCommand.Connection = Me.ConnITSCont
        If Not da.InsertCommand Is Nothing Then da.InsertCommand.Connection = Me.ConnITSCont
        If Not da.UpdateCommand Is Nothing Then da.UpdateCommand.Connection = Me.ConnITSCont
        If Not da.DeleteCommand Is Nothing Then da.DeleteCommand.Connection = Me.ConnITSCont
    End Sub

    Public Shared Function getDate235959(ByVal datOrig As Date) As Date
        Dim datReturn As New Date(datOrig.Year, datOrig.Month, datOrig.Day, 23, 59, 59)
        Return datReturn
    End Function

    Public Function doArrayPhp(ByRef ds As DataSet, ByRef sql As String, _
                                 ByRef fct As String, _
                                 ByRef maxRows As Integer, _
                                 ByVal arrInfoTable As System.Collections.Generic.List(Of String), _
                                 ByVal arrSelListTypID As System.Collections.Generic.List(Of String)) As dbGlobal.cSqlResultIntern

        Dim cSqlResult1 As New dbGlobal.cSqlResultIntern()
        Dim cServiceResult1 As New cServiceResult()
        cSqlResult1.cServiceResult1 = cServiceResult1

        Dim retTables(ds.Tables.Count - 1) As cTable
        cServiceResult1.tables = retTables

        Dim sqlSum As String = ""
        Dim iTable As Integer = 0
        For Each rTableToConvert As DataTable In ds.Tables

            If toMuchRowsInSqlTable(rTableToConvert, True, maxRows) Then
                Exit Function
            End If

            Dim NewTable As New cTable()
            NewTable.tableName = rTableToConvert.TableName
            NewTable.tableNr = iTable
            If Not arrInfoTable Is Nothing Then
                NewTable.tableInfo = arrInfoTable(iTable)
            End If
            If Not arrSelListTypID Is Nothing Then
                NewTable.selListTypID = arrSelListTypID(iTable)
            End If

            Me.doArrayPhpRows(NewTable, rTableToConvert, sql)
            retTables(iTable) = NewTable

            sqlSum += NewTable.sql + vbNewLine + vbNewLine

            iTable += 1
        Next

        cSqlResult1.cServiceResult1.successful = True
        Return cSqlResult1
    End Function
    Public Function doArrayPhp(ByRef dataTableToConvert As DataTable, _
                               ByRef sql As String, _
                               ByRef fct As String, _
                               ByRef maxRows As Integer, _
                               ByVal tableInfo As String, _
                               ByVal selListTypID As String) As dbGlobal.cSqlResultIntern

        Dim cSqlResult1 As New dbGlobal.cSqlResultIntern()
        Dim cServiceResult1 As New cServiceResult()
        cSqlResult1.cServiceResult1 = cServiceResult1

        If Me.toMuchRowsInSqlTable(dataTableToConvert, True, maxRows) Then
            Exit Function
        End If

        Dim retTables(0) As cTable
        Dim NewTable As New cTable()
        cServiceResult1.tables = retTables
        NewTable.tableName = dataTableToConvert.TableName
        NewTable.tableNr = 0
        NewTable.tableInfo = tableInfo
        NewTable.selListTypID = selListTypID
        retTables(0) = NewTable
        Me.doArrayPhpRows(NewTable, dataTableToConvert, Sql)

        'sqlProtokoll1.newProtokoll(NewTable.sql, "Sql-Query Web", fct + "   (doArrayPhp)")   'OS
        cSqlResult1.cServiceResult1.successful = True

        Return cSqlResult1
    End Function
    Public Function doArrayPhpRows(ByRef NewTable As cTable, _
                                   ByRef dataTableToConvert As DataTable, _
                                   ByRef sql As String) As Boolean

        Try
            '            Dim sqlAuswahllisten1 As New sqlAuswahllisten()
            '            Dim dsSelListToDb As New dsAuswahllisten
            '            Dim rGrp As dsAuswahllisten.AuswahllisteGruppeRow = sqlAuswahllisten1.loadAuswahllisteGruppeRow("SelToDb", sqlAuswahllisten.eTypAuswahlList.idGruppe, True)
            '            sqlAuswahllisten1.loadAuswahllisten("SelToDb", dsSelListToDb, sqlAuswahllisten.eTypAuswahlList.idGruppe, "")

            Dim newRows(dataTableToConvert.Rows.Count - 1) As cRow
            Dim iRow As Integer = 0
            Dim IDSubtable As System.Guid = Nothing
            Dim TypeSubtable As New eTypeSubtable()

            For Each rRow As DataRow In dataTableToConvert.Rows
                Dim newRow As New cRow()
                newRow.tableName = NewTable.tableName
                newRow.rowNr = iRow

                Dim newValues(dataTableToConvert.Columns.Count) As cValue
                Dim iColumn As Integer = 0
                For Each rColumn As DataColumn In dataTableToConvert.Columns
                    Dim newValue As New cValue()
                    newValue.columnName = rColumn.ColumnName
                    newValue.tableName = NewTable.tableName
                    newValue.valueType = rRow(rColumn.ColumnName).GetType().ToString()
                    Me.doValue(rRow(rColumn.ColumnName), newValue, rRow, rColumn, iRow)
                    'OS                    Me.doInfoForField(newValue, dsSelListToDb)
                    newValues(iColumn) = newValue

                    'OS
                    'Dim cServiceResultSub(4) As cServiceResult
                    'If newValue.tableName.ToLower() = ("vVertragListSimple").ToLower() Then
                    '    If newValue.columnName.ToLower() = ("IDVertrag").ToLower() Then
                    '        TypeSubtable = eTypeSubtable.Contracts
                    '        IDSubtable = New System.Guid(newValue.valueGuid)
                    '    End If
                    'End If
                    'If newValue.tableName.ToLower() = ("vObjectList").ToLower() Then
                    '    If newValue.columnName.ToLower() = ("IDObject").ToLower() Then
                    '        TypeSubtable = eTypeSubtable.Objects
                    '        IDSubtable = New System.Guid(newValue.valueGuid)
                    '    End If
                    'End If
                    iColumn += 1
                Next

                If Not IDSubtable = Nothing Then
                End If

                newRow.Values = newValues
                newRows(iRow) = newRow
                iRow += 1
            Next

            NewTable.sql = Sql
            NewTable.rowsFound = iRow
            NewTable.rows = newRows
            NewTable.runEnd = System.Convert.ToDateTime(Now, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)

            Return True

        Catch ex As Exception
            Me.gen.doEcxept(ex)
        End Try
    End Function
 

    Public Function runSqlCommand(ByVal sqlCommand As String, _
                                  ByVal IDPar As System.Guid) As String
        Try
            Dim dt As New System.Data.DataTable()
            Dim da As New System.Data.OleDb.OleDbDataAdapter()
            Dim cmd As New System.Data.OleDb.OleDbCommand()

            sqlCommand = sqlCommand.Replace("?", "'" + IDPar.ToString() + "'")
            cmd.CommandText = sqlCommand
            da.SelectCommand = cmd
            Me.setDBConnection_dataAdapter(da)
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                Return dt.Rows(0)(0).ToString()
            ElseIf dt.Rows.Count = 0 Then
                Return ""
                'Throw New Exception("getSelListInfoForField.runSqlCommand: No Row found for Sql-Command '" + sqlCommand.ToLower + "'!")
            ElseIf dt.Rows.Count > 1 Then
                Throw New Exception("getSelListInfoForField.runSqlCommand: Morde than one Row found for Sql-Command '" + sqlCommand.ToLower + "'!")
            End If

        Catch ex As Exception
            Me.gen.doEcxept(ex)
        End Try
    End Function


    Public Function doValue(ByVal valObj As Object, ByRef newValue As cValue, _
                            ByRef rRow As DataRow, ByRef rColumn As DataColumn, _
                            ByRef rowNr As Integer) As Object

        Try
            Dim typeTemp As String = valObj.GetType().ToString().ToLower()

            If typeTemp = dbGlobal.typeString.ToLower() Then

                If dbGlobal.checkValueNull(valObj, True, False) Then
                    newValue.valueStr = ""
                Else
                    newValue.valueStr = System.Convert.ToString(rRow(rColumn.ColumnName))
                End If
                Return newValue.valueStr

            ElseIf typeTemp = dbGlobal.typeBoolean.ToLower() Then

                If dbGlobal.checkValueNull(valObj, False, False) Then
                    newValue.valueBool = False
                Else
                    newValue.valueBool = System.Convert.ToBoolean(rRow(rColumn.ColumnName))
                End If
                Return newValue.valueBool

            ElseIf typeTemp = dbGlobal.typeInt32.ToLower() Or _
                 typeTemp = dbGlobal.typeInt64.ToLower() Or _
                 typeTemp = dbGlobal.typeInteger.ToLower() Then

                If dbGlobal.checkValueNull(valObj, False, False) Then
                    newValue.valueInt = 0
                Else
                    newValue.valueInt = System.Convert.ToInt32(rRow(rColumn.ColumnName))
                End If
                Return newValue.valueInt

            ElseIf typeTemp = dbGlobal.typeDouble.ToLower() Or _
                typeTemp = dbGlobal.typeDecimal.ToLower() Then

                If dbGlobal.checkValueNull(valObj, False, False) Then
                    newValue.valueDbl = 0
                Else
                    'newValue.valueDbl = System.Convert.ToDouble(rRow(rColumn.ColumnName))
                    newValue.valueDbl = Convert.ToDouble(rRow(rColumn.ColumnName), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
                End If
                Return newValue.valueDbl

            ElseIf typeTemp = dbGlobal.typeDate.ToLower() Or _
                typeTemp = dbGlobal.typeDateTime.ToLower() Then

                If dbGlobal.checkValueNull(valObj, False, False) Then
                    newValue.valueDateTime = Nothing
                    newValue.isNull = True
                Else
                    'newValue.valueDateTime = System.Convert.ToDateTime(rRow(rColumn.ColumnName))
                    newValue.valueDateTime = System.Convert.ToDateTime(rRow(rColumn.ColumnName), System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                End If
                Return newValue.valueDateTime

            ElseIf typeTemp = dbGlobal.typeGuid.ToLower() Then

                If dbGlobal.checkValueNull(valObj, False, False) Then
                    newValue.valueGuid = Nothing
                    newValue.isNull = True
                Else
                    newValue.valueGuid = rRow(rColumn.ColumnName).ToString()
                End If
                Return newValue.valueGuid

            ElseIf typeTemp = dbGlobal.typeDBNull.ToLower() Then
                ' no Values to set
                Dim str As String = ""
                newValue.isNull = True
                Return System.DBNull.Value

            Else
                Throw New Exception("doValue: Wrong Type in Column '" + rColumn.ColumnName + "', RowNr '" + rowNr.ToString() + "'!")
                Return Nothing
            End If

        Catch ex As Exception
            Me.gen.doEcxept(ex)
            Return Nothing
        End Try
    End Function
    Public Function doValuePhp(ByRef valInput As String, _
                               ByRef typeTemp As String, ByRef columnName As String) As Object
        Try
            typeTemp = typeTemp.ToLower().Trim()
            valInput = valInput.Trim()

            If valInput.Trim().ToLower() = dbGlobal.typeDBNull.ToLower() Then
                Return System.DBNull.Value
            End If

            If typeTemp = dbGlobal.typeString.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return ""
                Else
                    If valInput.Trim().ToLower() = dbGlobal.typeDBNull.Trim().ToLower() Then
                        Return System.DBNull.Value
                    Else
                        Return System.Convert.ToString(valInput)
                    End If
                End If

            ElseIf typeTemp = dbGlobal.typeBoolean.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return False
                Else
                    If valInput.Trim() = "1" Then
                        Return True
                    Else
                        Throw New Exception("doValuePhp: Bool-Column from Php has wrong Value! Value is '" + valInput + "'!")
                    End If
                End If

            ElseIf typeTemp = dbGlobal.typeInteger.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return 0
                Else
                    Return System.Convert.ToInt32(valInput)
                End If

            ElseIf typeTemp = dbGlobal.typeDouble.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return 0
                Else
                    If Not valInput.Trim().Contains(".") Then
                        Throw New Exception("doValuePhp: Double-Column from Php has wrong Value! Value is '" + valInput + "'!")
                    Else
                        'newValue.valueDbl = System.Convert.ToDouble(rRow(rColumn.ColumnName))
                        Return Convert.ToDouble(valInput, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
                    End If
                End If

            ElseIf typeTemp = dbGlobal.typeDateTime.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return System.DBNull.Value
                Else
                    Return System.Convert.ToDateTime(valInput)
                    'Return System.Convert.ToDateTime(valInput, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                End If

            ElseIf typeTemp = dbGlobal.typeGuid.ToLower() Then
                If dbGlobal.checkValueNull(valInput, True, True) Then
                    Return System.DBNull.Value
                Else
                    Return New System.Guid(valInput)
                End If

            ElseIf typeTemp = dbGlobal.typeDBNull.ToLower() Then
                   Return System.DBNull.Value

            Else
                Throw New Exception("doValuePhp: Wrong Type " + typeTemp + " in Column '" + columnName + "'!")
            End If

        Catch ex As Exception
            Me.gen.doEcxept(ex)
        End Try
    End Function

 
  
    Public Shared Function checkValueNull(ByRef valueObj As Object, ByRef checkStrForEmpty As Boolean, _
                                   ByRef checkIntForEmpty As Boolean) As Boolean
        If valueObj Is Nothing Then
            Return True
        Else
            If valueObj Is System.DBNull.Value Then
                Return True
            End If

            If valueObj.GetType().ToString().ToLower() = dbGlobal.typeDate.ToLower() Or _
                valueObj.GetType().ToString().ToLower() = dbGlobal.typeDateTime.ToLower() Then

                Dim datTemp As Date = valueObj
                If datTemp.Year = 1900 Or (datTemp.Year = 1 And datTemp.Year = 1) Then
                    Return True
                End If

            End If

            If checkStrForEmpty Then
                If valueObj.GetType().ToString().ToLower() = dbGlobal.typeString.ToLower() Then
                    If System.Convert.ToString(valueObj) = "" Then
                        Return True
                    End If
                End If
            End If
            If checkIntForEmpty Then
                If valueObj.GetType().ToString().ToLower() = dbGlobal.typeInt32.ToLower() Or _
                    valueObj.GetType().ToString().ToLower() = dbGlobal.typeInt64.ToLower() Or _
                    valueObj.GetType().ToString().ToLower() = dbGlobal.typeInteger.ToLower() Or _
                    valueObj.GetType().ToString().ToLower() = dbGlobal.typeDouble.ToLower() Or _
                    valueObj.GetType().ToString().ToLower() = dbGlobal.typeDecimal.ToLower() Then
                    If System.Convert.ToInt32(valueObj) = dbGlobal.intNull Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function
 
    Public Function copyTable(ByRef fromDs As DataSet, ByRef tableName As String) As DataTable
        Dim dtResult As New DataTable()
        dtResult = fromDs.Tables(tableName).Copy()
        Return dtResult
    End Function
    Public Function getPhpInputClass(ByVal TblName As String, ByVal ColName As String, _
                                     ByVal ColValue As String, _
                                     ByVal InputRequired As Boolean, ByVal ColType As String) As cField

        Dim cFieldFromPHP1 As New cField()
        cFieldFromPHP1.ColName = ColName
        cFieldFromPHP1.ColValue = ColValue
        cFieldFromPHP1.ColType = ColType
        cFieldFromPHP1.InputRequired = InputRequired
        cFieldFromPHP1.TblName = TblName

        Return cFieldFromPHP1
    End Function
    Public Function toMuchRowsInSqlTable(ByRef dataTableToConvert As DataTable, _
                                            ByVal doException As Boolean, ByRef maxRowsFct As Integer) As Boolean


        Dim locMaxRows As Integer = dbGlobal.maxRowsDs
        If maxRowsFct <> dbGlobal.intNull Then
            locMaxRows = maxRowsFct
        End If
        If dataTableToConvert.Rows.Count > locMaxRows Then
            If doException Then
                Throw New Exception("toMuchRowsInSqlTable: For Table '" + dataTableToConvert.TableName + "' are more than " + locMaxRows.ToString() + " Rows found!" + vbNewLine + _
                                    "Please change Searching-Parameters!")
            End If
            Return True
        End If

    End Function


    Public Function copyRow(ByRef rowToCopy As DataRow, ByRef tableResult As DataTable) As DataRow

        Dim rNewRowResult As DataRow = tableResult.NewRow()
        For Each colToCopy As DataColumn In rowToCopy.Table.Columns
            For Each colResult As DataColumn In tableResult.Columns
                If colToCopy.ColumnName = colResult.ColumnName Then
                    If colToCopy.ColumnName = "ID" Then
                        rNewRowResult("ID") = System.Guid.NewGuid()
                    Else
                        rNewRowResult(colToCopy.ColumnName) = rowToCopy(colToCopy.ColumnName)
                    End If
                End If
            Next
        Next

        tableResult.Rows.Add(rNewRowResult)
        Return rNewRowResult
    End Function
    Public Shared Sub initRow(ByRef r As DataRow)



        For i As Integer = 0 To r.Table.Columns.Count - 1
            Dim col As New DataColumn
            col = r.Table.Columns(i)
            Dim typ As System.Type
            typ = col.DataType
            If typ.ToString().ToLower().Trim() = dbGlobal.typeBoolean.ToLower() Then
                r(col.ColumnName) = False
            ElseIf typ.ToString().ToLower().Trim() = dbGlobal.typeInt32.ToLower() Or typ.ToString().ToLower().Trim() = dbGlobal.typeInt64.ToLower() Or _
                typ.ToString().ToLower().Trim() = dbGlobal.typeDouble.ToLower() Or typ.ToString().ToLower().Trim() = dbGlobal.typeDecimal.ToLower() Then
                r(col.ColumnName) = 0
            ElseIf typ.ToString().ToLower().Trim() = dbGlobal.typeString.ToLower() Then
                r(col.ColumnName) = ""
            ElseIf typ.ToString().ToLower().Trim() = dbGlobal.typeDate.ToLower() Or typ.ToString().ToLower().Trim() = dbGlobal.typeDateTime.ToLower() Then
                Try
                    r(col.ColumnName) = System.DBNull.Value
                Catch ex As Exception
                    Dim d As New DateTime
                    r(col.ColumnName) = d
                End Try
            ElseIf typ.ToString().ToLower().Trim() = dbGlobal.typeGuid.ToLower() Then
                Try
                    r(col.ColumnName) = System.Guid.Empty
                Catch ex As Exception
                    r(col.ColumnName) = System.Guid.Empty
                End Try
            Else
                Throw New Exception("initRow: typ '" + typ.ToString() + "' not supported in function!")
            End If
        Next

    End Sub

End Class
