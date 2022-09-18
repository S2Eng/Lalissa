

Public Class dbBase

    Public Shared ReadOnly DateTimeFormatSqlSrvIso As String = "yyyy.MM.dd HH:mm:ss"
    Public Shared ReadOnly DateTimeFormatSqlSrvIsoNr As Integer = 120







    Public Shared Function convertValue(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, _
                                        ByRef valueToConvert As Object, ByRef retValue As qs2.core.generic.retValue, _
                                        ByRef TypeField As qs2.core.dbBase.TypeField) As Boolean

        dbBase.setResultDbNull(retValue)
        If valueToConvert Is System.DBNull.Value Then
            retValue.valueSql = "null"
        End If
        dbBase.convertValue2(rColSys, valueToConvert, retValue, TypeField)
        Return True

    End Function
    Public Shared Sub convertValue2(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, _
                                        ByRef valueToConvert As Object, ByRef retValue As qs2.core.generic.retValue, _
                                        ByRef TypeField As qs2.core.dbBase.TypeField)
        Dim ExcepFunct As String = "dbBase.convertValue2: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': "

        If rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.bit.ToString().ToLower() Then
            If System.Convert.ToBoolean(valueToConvert) = True Then
                retValue.valueObj = True
                retValue.valueStr = "1"
                retValue.valueSql = "1"
            Else
                retValue.valueObj = False
                retValue.valueStr = "0"
                retValue.valueSql = "0"
            End If
            TypeField = core.dbBase.TypeField.tbool

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.datetime.ToString().ToLower() Or
               rColSys.DATA_TYPE.ToLower() = "smalldatetime" Then

            Dim dat As Date = System.Convert.ToDateTime(valueToConvert, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            retValue.valueStr = dat.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            retValue.valueObj = dat
            retValue.valueSql = "'" + retValue.valueStr + "'"
            TypeField = core.dbBase.TypeField.datetime

        ElseIf rColSys.DATA_TYPE.ToLower() = "int" Or
            rColSys.DATA_TYPE.ToLower() = "smallint" Or
             rColSys.DATA_TYPE.ToLower() = "tinyint" Or
             rColSys.DATA_TYPE.ToLower() = "bigint" Then

            retValue.valueStr = System.Convert.ToString(valueToConvert)
            retValue.valueObj = valueToConvert
            retValue.valueSql = "" + retValue.valueStr + ""
            TypeField = core.dbBase.TypeField.tint

        ElseIf rColSys.DATA_TYPE.ToLower() = "float" Or
               rColSys.DATA_TYPE.ToLower() = "decimal" Or
               rColSys.DATA_TYPE.ToLower() = "smallmoney" Or
                rColSys.DATA_TYPE.ToLower() = "numeric" Or
                rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.numeric.ToString().ToLower() Then

            Dim dbl As Double = Convert.ToDouble(valueToConvert, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            retValue.valueStr = dbl.ToString().Replace(",", ".")
            retValue.valueSql = "" + retValue.valueStr + ""
            retValue.valueObj = valueToConvert
            TypeField = core.dbBase.TypeField.dec

        ElseIf dbBase.checkDBFieldTypeString(rColSys) Then
            retValue.valueStr = System.Convert.ToString(valueToConvert)
            retValue.valueSql = "'" + retValue.valueStr + "'"
            retValue.valueObj = valueToConvert
            TypeField = core.dbBase.TypeField.str

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.uniqueidentifier.ToString().ToLower() Then
            retValue.valueObj = New System.Guid(valueToConvert.ToString())
            retValue.valueStr = retValue.valueObj.ToString()
            retValue.valueSql = "'" + retValue.valueStr + "'"
            TypeField = core.dbBase.TypeField.guid

        Else
            Throw New Exception(ExcepFunct + "Data-Type '" + rColSys.DATA_TYPE.ToLower() + "' for Column '" + rColSys.COLUMN_NAME + "' in Table '" + rColSys.TABLE_NAME + "' not supported!")
        End If

    End Sub

    Public Shared Sub setResultDbNull(ByRef retValue As qs2.core.generic.retValue)
        retValue.valueObj = System.DBNull.Value
        retValue.valueStr = ""
        retValue.valueSql = "null"
    End Sub
    Public Shared Function checkDBFieldTypeString(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow) As Boolean

        If rColSys.DATA_TYPE.ToLower() = "nvarchar" Or
               rColSys.DATA_TYPE.ToLower() = "varchar" Or
               rColSys.DATA_TYPE.ToLower() = "nchar" Or
               rColSys.DATA_TYPE.ToLower() = "char" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function getDateConvertSqlFromQS2Service(dat As Date) As String
        Dim strDat As String = ""
        strDat = "CONVERT(datetime,'" + Format(dat, dbBase.DateTimeFormatSqlSrvIso) + "', " + dbBase.DateTimeFormatSqlSrvIsoNr.ToString() + ")"
        Return strDat
    End Function
    Public Shared Function getDateConvertSql(dat As Date) As String
        Dim strDat As String = ""
        strDat = "CONVERT(datetime,'" + Format(dat, "MM-dd-yyyy HH:mm:ss") + "', 120)"
        Return strDat
    End Function
    Public Shared Function getDateConvertSqlWithDelimiter(dat As Date, Delimiter As String) As String
        Dim strDat As String = ""
        strDat = "CONVERT(datetime," + Delimiter.Trim() + "" + Format(dat, "MM-dd-yyyy HH:mm:ss") + "" + Delimiter.Trim() + ", 120)"
        Return strDat
    End Function

    Public Shared Function getDateConvertSqlSimple(dat As Date) As String
        Dim strDat As String = ""
        strDat = "CONVERT(datetime,'" + Format(dat, "MM-dd-yyyy") + "', 120)"
        Return strDat
    End Function
    Public Shared Function getDateConvertSqlSimpleWithDelimiter(dat As Date, Delimiter As String) As String
        Dim strDat As String = ""
        strDat = "CONVERT(datetime," + Delimiter.Trim() + "" + Format(dat, "MM-dd-yyyy") + "" + Delimiter.Trim() + ", 120)"
        Return strDat
    End Function

    Public Shared Function getDefaultValueDb(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, ByRef DbFieldInfo As DbField) As DbField

        Dim ExcepFunct As String = "dbBase.getDefaultValueDb: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': "
        Dim startIndex As Integer = 0

        dbBase.setResultDbNullDbFieldInfo(DbFieldInfo)

        If Not rColSys.IsCOLUMN_DEFAULTNull() Then
            DbFieldInfo.ColumnDefaultDB = rColSys.COLUMN_DEFAULT
        End If
        If Not rColSys.IsIS_NULLABLENull() Then
            If rColSys.IS_NULLABLE.ToLower() = qs2.core.dbBase.Yes.ToLower() Then
                dbBase.setResultDbNullDbFieldInfo(DbFieldInfo)
                dbBase.getDataType(rColSys, DbFieldInfo)
                DbFieldInfo.IsNullableDB = True
                Return DbFieldInfo
                'If rColSys.DATA_TYPE.ToLower() = dbBase.DBTypeSqlServer.datetime.ToString().ToLower() Then
                '       dbBase.getDefaultDBValueDateTime(rColSys, resultValue)
                'End If
            End If
        End If

        dbBase.getDefaultValueDb2(rColSys, DbFieldInfo)
        Return DbFieldInfo

    End Function
    Public Shared Sub getDefaultValueDb2(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, ByRef DbField As DbField)
        Dim ExcepFunct As String = "dbBase.getDefaultValueDb2: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': "
        Dim startIndex As Integer = 0

        If rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.bit.ToString().ToLower() Then
            If DbField.ColumnDefaultDB.Trim() = "" Then
                DbField.valueObj = False
                DbField.valueStr = "0"
                DbField.valueSql = "0"
            Else
                If DbField.ColumnDefaultDB.Contains("1") Then
                    DbField.valueObj = True
                    DbField.valueStr = "1"
                    DbField.valueSql = "1"
                Else
                    DbField.valueObj = False
                    DbField.valueStr = "0"
                    DbField.valueSql = "0"
                End If
            End If
            DbField.TypeField = core.dbBase.TypeField.tbool

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.datetime.ToString().ToLower() Or
               rColSys.DATA_TYPE.ToLower() = "smalldatetime" Then
            dbBase.getDefaultDBValueDateTime(rColSys, DbField)
            DbField.TypeField = core.dbBase.TypeField.datetime

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.typInt.ToString().ToLower() Or
            rColSys.DATA_TYPE.ToLower() = "smallint" Or
             rColSys.DATA_TYPE.ToLower() = "tinyint" Or
             rColSys.DATA_TYPE.ToLower() = "bigint" Then

            If DbField.ColumnDefaultDB.Trim() = "" Then
                DbField.valueObj = 0
                DbField.valueStr = "0"
                DbField.valueSql = "0"
            Else
                startIndex = 0
                DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "(", ")", True, True, True)
                DbField.valueObj = System.Convert.ToInt32(DbField.valueStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
                DbField.valueSql = DbField.valueStr
            End If
            DbField.TypeField = core.dbBase.TypeField.tint

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.typFloat.ToString().ToLower() Or
               rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.typDecimal.ToString().ToLower() Or
               rColSys.DATA_TYPE.ToLower() = "smallmoney" Or
                rColSys.DATA_TYPE.ToLower() = "numeric" Or
                rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.numeric.ToString().ToLower() Then

            If DbField.ColumnDefaultDB.Trim() = "" Then
                DbField.valueObj = 0
                DbField.valueStr = "0"
                DbField.valueSql = "0"
            Else
                startIndex = 0
                DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "(", ")", True, True, True)
                If DbField.valueStr.Trim().Contains("'") Then
                    startIndex = 0
                    DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "'", "'", True, True, True)
                End If
                DbField.valueStr = DbField.valueStr.ToString().Replace(",", ".")
                DbField.valueSql = DbField.valueStr
                Dim dbl As Double = Convert.ToDouble(DbField.valueStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
                DbField.valueObj = dbl
            End If
            DbField.TypeField = core.dbBase.TypeField.dec

        ElseIf dbBase.checkDBFieldTypeString(rColSys) Then
            If DbField.ColumnDefaultDB.Trim() = "" Then
                DbField.valueStr = ""
                DbField.valueObj = ""
                DbField.valueSql = "''"
            Else
                If (DbField.ColumnDefaultDB.Equals("''") Or DbField.ColumnDefaultDB.Equals("('')")) Then
                    DbField.valueStr = ""
                    DbField.valueObj = ""
                    DbField.valueSql = "''"
                Else
                    startIndex = 0
                    DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "'", "", True, True, True)
                    DbField.valueObj = DbField.valueStr
                    DbField.valueSql = "'" + DbField.valueStr + "'"
                End If
            End If
            DbField.TypeField = core.dbBase.TypeField.str

        ElseIf rColSys.DATA_TYPE.ToLower() = qs2.core.dbBase.DBTypeSqlServer.uniqueidentifier.ToString().ToLower() Then
            DbField.TypeField = core.dbBase.TypeField.guid
            If DbField.ColumnDefaultDB.Contains(qs2.core.dbBase.DBTypeSqlServer.newid.ToString()) Then
                Dim IDNew As System.Guid = System.Guid.NewGuid()
                DbField.valueStr = IDNew.ToString()
                DbField.valueObj = IDNew
                DbField.valueSql = "'" + DbField.valueStr + "'"
            Else
                If DbField.IsNullableDB Then
                    dbBase.setResultDbNullDbFieldInfo(DbField)
                Else
                    If (DbField.ColumnDefaultDB.Contains("''")) Then
                        startIndex = 0
                        DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "'", "", True, True, True)
                        DbField.valueObj = New System.Guid(DbField.valueStr)
                        DbField.valueSql = "'" + DbField.valueStr + "'"
                    Else
                        Throw New Exception(ExcepFunct + "No value for Guid for updateing Db!")
                    End If
                End If
            End If

        ElseIf rColSys.DATA_TYPE.ToLower() = "image" Then
            DbField.TypeField = core.dbBase.TypeField.image
            If DbField.IsNullableDB Then
                dbBase.setResultDbNullDbFieldInfo(DbField)
            Else
                Throw New Exception(ExcepFunct + "Nullabel not possible for Db-Type image or varbinary for Service-Update to DB!")
            End If

        ElseIf rColSys.DATA_TYPE.ToLower() = "varbinary" Then
            DbField.TypeField = core.dbBase.TypeField.varbinary
            If DbField.IsNullableDB Then
                dbBase.setResultDbNullDbFieldInfo(DbField)
            Else
                Throw New Exception(ExcepFunct + "Nullabel not possible for Db-Type image or varbinary for Service-Update to DB!")
            End If

        ElseIf rColSys.DATA_TYPE.ToLower() = "xml" Then
            DbField.TypeField = core.dbBase.TypeField.xml
            If DbField.IsNullableDB Then
                dbBase.setResultDbNullDbFieldInfo(DbField)
            Else
                DbField.valueStr = ""
                DbField.valueObj = ""
                DbField.valueSql = "''"
                DbField.TypeField = core.dbBase.TypeField.str
            End If

        Else
            Throw New Exception(ExcepFunct + "Data-Type '" + rColSys.DATA_TYPE.ToLower() + "' not supported for Service-Update to DB!")
        End If

    End Sub
    Public Shared Sub getDefaultDBValueDateTime(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, ByRef DbField As DbField)

        Dim ExcepFunct As String = "dbBase.getDefaultDBValueDateTime: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': "
        Dim startIndex As Integer = 0

        If DbField.ColumnDefaultDB.Trim() <> "" Then
            If DbField.ColumnDefaultDB.Contains(qs2.core.dbBase.DBTypeSqlServer.getdate.ToString()) Then
                Dim dat As Date = System.DateTime.Now.Date
                Dim strDat As String = dbBase.getDateConvertSql(dat)
                DbField.valueStr = strDat
                DbField.valueObj = dat
                DbField.valueSql = DbField.valueStr
                Exit Sub
            Else
                startIndex = 0
                DbField.valueStr = qs2.core.generic.readStrBetween(DbField.ColumnDefaultDB, startIndex, "'", "", True, True, True)
                Dim dat As DateTime = System.Convert.ToDateTime(DbField.valueStr, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                Dim strDat As String = dbBase.getDateConvertSql(dat)
                DbField.valueObj = dat
                DbField.valueSql = DbField.valueStr
                Exit Sub
            End If
        Else
            If DbField.IsNullableDB Then
                dbBase.setResultDbNullDbFieldInfo(DbField)
                Exit Sub
            Else
                Dim dat As Date = System.DateTime.Now.Date
                Dim strDat As String = dbBase.getDateConvertSql(dat)
                DbField.valueStr = strDat
                DbField.valueObj = dat
                DbField.valueSql = DbField.valueStr
                Exit Sub
            End If
        End If

        Throw New Exception(ExcepFunct + " No DateTime-Value for Field found for Service-Update to DB!!")
    End Sub
    Public Shared Sub getDataType(ByRef rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow, ByRef DbField As DbField)
        Dim ExcepFunct As String = "dbBase.getDataType: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': "

        If rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.bit.ToString(), StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.tbool

        ElseIf rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.datetime.ToString(), StringComparison.OrdinalIgnoreCase) Or
               rColSys.DATA_TYPE.Equals("smalldatetime", StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.datetime

        ElseIf rColSys.DATA_TYPE.Equals(qs2.core.dbBase.typInt.ToString(), StringComparison.OrdinalIgnoreCase) Or
            rColSys.DATA_TYPE.Equals("smallint", StringComparison.OrdinalIgnoreCase) Or
             rColSys.DATA_TYPE.Equals("tinyint", StringComparison.OrdinalIgnoreCase) Or
             rColSys.DATA_TYPE.Equals("bigint", StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.tint

        ElseIf rColSys.DATA_TYPE.Equals(qs2.core.dbBase.typFloat.ToString(), StringComparison.OrdinalIgnoreCase) Or
               rColSys.DATA_TYPE.Equals(qs2.core.dbBase.typDecimal.ToString(), StringComparison.OrdinalIgnoreCase) Or
               rColSys.DATA_TYPE.Equals("smallmoney", StringComparison.OrdinalIgnoreCase) Or
                rColSys.DATA_TYPE.Equals("numeric", StringComparison.OrdinalIgnoreCase) Or
                rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.numeric.ToString(), StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.dec

        ElseIf dbBase.checkDBFieldTypeString(rColSys) Then
            DbField.TypeField = core.dbBase.TypeField.str

        ElseIf rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.uniqueidentifier.ToString(), StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.guid

        ElseIf rColSys.DATA_TYPE.Equals("image", StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.image
        ElseIf rColSys.DATA_TYPE.Equals("varbinary", StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.varbinary
        ElseIf rColSys.DATA_TYPE.Equals("xml", StringComparison.OrdinalIgnoreCase) Then
            DbField.TypeField = core.dbBase.TypeField.xml
        Else
            Throw New Exception(ExcepFunct + "Data-Type '" + rColSys.DATA_TYPE.ToLower() + "' not supported for Service-Update to DB!")
        End If

    End Sub

    Public Shared Sub setResultDbNullDbFieldInfo(ByRef DbField As DbField)
        DbField.valueObj = System.DBNull.Value
        DbField.valueStr = ""
        DbField.valueSql = "null"
        'DbField.TypeField = TypeField.DBNull
    End Sub

    Public Function callTableFunctions(ByRef TableName As String, sParameter As String) As System.Data.DataTable
        Try
            Dim database As New qs2.core.dbBase
            Dim da As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmdSel As New System.Data.SqlClient.SqlCommand()

            cmdSel.CommandText = "Select " + TableName.Trim() + " (" + sParameter.Trim() + ")"
            da.SelectCommand = cmdSel

            database.setConnection(da)
            da.SelectCommand.Parameters.Clear()

            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw New Exception("dbBase.callFctView: " + ex.ToString())
        End Try
    End Function

End Class



Public Class DbField

    Public ColumnName As String = ""

    Public valueStr As String = ""
    Public valueObj As Object = System.DBNull.Value
    Public valueSql As String = ""
    Public TypeField As qs2.core.dbBase.TypeField = Nothing
    Public rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow = Nothing

    Public IsPrimaryKey As Boolean = False
    Public ColumnDefaultDB As String = ""
    Public IsNullableDB As Boolean = False
    Public MaximumLength As Integer = -1
    Public IsIdentityColumn As Boolean = False
    Public IsComputedColumn As Boolean = False

End Class
