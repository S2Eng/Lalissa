Imports System.Data.OleDb
Imports S2Extensions
Imports VB = Microsoft.VisualBasic

Public Class Sql

    Private Shared _CONNECTION As OleDbConnection
    Private _tools As New tools
    Private _SelBillsHeader As String = ""
    Private _SelBills As String = ""

    Public Shared Property CONNECTION As OleDbConnection
        Get
            Return _CONNECTION
        End Get
        Set(ByVal value As OleDbConnection)
            _CONNECTION = value
        End Set
    End Property

    Public Property tools As tools
        Get
            Return _tools
        End Get
        Set(ByVal value As tools)
            _tools = value
        End Set
    End Property

    Public Property SelBillsHeader As String
        Get
            Return _SelBillsHeader
        End Get
        Set(ByVal value As String)
            _SelBillsHeader = value
        End Set
    End Property

    Public Property SelBills As String
        Get
            Return _SelBills
        End Get
        Set(ByVal value As String)
            _SelBills = value
        End Set
    End Property

    Public Sub initControl()
        Me.SelBillsHeader = Me.daBillHeaderUpdate.SelectCommand.CommandText
        Me.SelBills = Me.daBillUpdate.SelectCommand.CommandText
    End Sub

    Public Function run(ByVal query As String, ByVal arrPar() As dbParameter) As dbQuery
        Try
            Dim dbQuery As New dbQuery
            dbQuery.dAdap.SelectCommand = dbQuery.cmd
            dbQuery.dAdap.SelectCommand.Connection = Sql.CONNECTION
            dbQuery.dAdap.SelectCommand.CommandText = query
            If Not arrPar Is Nothing Then
                For Each par As dbParameter In arrPar
                    dbQuery.dAdap.SelectCommand.Parameters.Add(par.parameter).Value = par.value
                Next
            End If
            dbQuery.dAdap.SelectCommand.CommandTimeout = 0
            dbQuery.dAdap.Fill(dbQuery.table)
            Return dbQuery

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readBillHeader(ByVal idAbrechnung As String, ByRef db As dbPMDS, IDKlinik As System.Guid)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daBillHeader.SelectCommand.CommandText + " where ID = ? and IDKlinik = ? "
                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION

                da.SelectCommand.Parameters.AddWithValue("ID", idAbrechnung)
                da.SelectCommand.Parameters.AddWithValue("IDKlinik", IDKlinik)
                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.billHeader)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub readBillHeader(ByVal idAbrechnung As String, ByRef db As dbPMDS)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daBillHeader.SelectCommand.CommandText + " where ID = ? "
                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION

                da.SelectCommand.Parameters.AddWithValue("ID", idAbrechnung)
                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.billHeader)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function insertBillHeader(ByRef rNew As dbPMDS.billHeaderRow) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "INSERT INTO billHeader(ID, dbCalc, protokoll, IDKlinik ) VALUES ( ?, ?, ?, ? )"

                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 50, "ID")).Value = VB.LCase(rNew.ID)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.VarChar, 0, "dbCalc")).Value = rNew.dbCalc
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("protokoll", System.Data.OleDb.OleDbType.VarChar, 0, "protokoll")).Value = rNew.protokoll
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")).Value = rNew.IDKlinik
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            If checkExceptionServerNotReachable(exept.ToString()) Then
                System.Threading.Thread.Sleep(200)
                Try
                    Return Me.insertBillHeader(rNew)
                Catch ex As Exception
                    If checkExceptionServerNotReachable(exept.ToString()) Then
                        System.Threading.Thread.Sleep(200)
                        Return Me.insertBillHeader(rNew)
                    Else
                        calcBase.doExept(exept)
                    End If
                End Try
            Else
                calcBase.doExept(exept)
            End If
        End Try
    End Function


    Private Function checkExceptionServerNotReachable(except As String) As Boolean
        If except.sContains("Server antwortet nicht") Or
           except.sContains("DBNETLIB") Or
           except.sContains("bereits ein geöffneter DataReader zugeordnet") Or
           except.sContains("Status der Verbindung ist 'Geschlossen'") Or
           except.sContains("Physische Verbindung nicht einsatzbereit") Or
           except.sContains("Abfragetimeout") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function delBillHeader(ByRef ID As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Delete from billHeader where ID = '" + ID.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveDbBillHeader(ByRef ID As String, ByVal xmlDbBill As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update billHeader set dbCalc = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.VarChar, 0, "dbCalc")).Value = xmlDbBill
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readBills(ByVal id As String, ByRef von As Date, ByRef bis As Date, ByRef vonRechDatum As Nullable(Of DateTime), ByRef bisRechDatum As Nullable(Of DateTime),
                         ByRef db As dbPMDS, ByVal rechTyp As PMDS.Calc.Logic.eBillTyp, ByVal status As PMDS.Calc.Logic.eBillStatus,
                         ByVal allKlients As Boolean, IDKlinik As System.Guid, showStornierte As Boolean, showExportierte As Boolean, RechNr As String)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daBill.SelectCommand.CommandText + Me.getWhereVonBis(id.ToLower(), von, bis, rechTyp, status, allKlients, IDKlinik, showStornierte)

                If vonRechDatum IsNot Nothing Then
                    cmd.CommandText += " and RechDatum >= ? "
                End If
                If (Not bisRechDatum Is Nothing) Then
                    cmd.CommandText += " and RechDatum <= ? "
                End If

                If Not showExportierte Then
                    cmd.CommandText += " and ExportiertJN = 0 "
                End If

                If Not String.IsNullOrWhiteSpace(RechNr) Then
                    cmd.CommandText += " and RechNr LIKE '%" + RechNr + "%'"
                End If

                cmd.CommandText += " order by datum "

                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION

                Dim pVon As New OleDbParameter With {.ParameterName = "Datum", .OleDbType = OleDbType.Date, .Value = von}
                da.SelectCommand.Parameters.Add(pVon)

                Dim pBis As New OleDbParameter With {.ParameterName = "Datum", .OleDbType = OleDbType.Date, .Value = bis}
                da.SelectCommand.Parameters.Add(pBis)

                If (Not vonRechDatum Is Nothing) Then
                    Dim pVonRechDatum As New OleDbParameter With {.ParameterName = "RechDatum", .OleDbType = OleDbType.Date, .Value = vonRechDatum.Value.Date}
                    da.SelectCommand.Parameters.Add(pVonRechDatum)
                End If

                If (Not bisRechDatum Is Nothing) Then
                    Dim pBisRechDatum As New OleDbParameter With {.ParameterName = "RechDatum", .OleDbType = OleDbType.Date, .Value = bisRechDatum.Value.Date}
                    da.SelectCommand.Parameters.Add(pBisRechDatum)
                End If

                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.bills)
            End Using
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readBillsDaylist(ByRef monat As Date, IDKlinik As System.Guid) As dbPMDS.billsDataTable
        Try
            Using db As New dbPMDS
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daBill.SelectCommand.CommandText +
                                " where Year(datum) = " + monat.Year.ToString() + " and Month(datum) = " + monat.Month.ToString() + " " +
                                " and Status <> " + CInt(eBillStatus.storniert).ToString() + " " +
                                " and Typ <> " + CInt(eBillTyp.Sammelrechnung).ToString() + " " +
                                " and IDKlinik = '" + IDKlinik.ToString() + "' "

                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(db.bills)
                    Return db.bills
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readBills(ByVal IDAbrechnung As String, ByRef db As dbPMDS)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daBill.SelectCommand.CommandText + " where IDAbrechnung = ? order by datum desc "
                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION

                da.SelectCommand.Parameters.AddWithValue("ID", IDAbrechnung)
                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.bills)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readBillsIDKostIntern(ByVal IDKostIntern As String, ByVal doExceptionNoBillFound As Boolean, IDKlinik As System.Guid, IDAbrechnung As System.Guid) As dbPMDS.billsRow
        Try
            Using db As New dbPMDS()
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daBill.SelectCommand.CommandText + " where IDKostIntern = ? and  IDKlinik = ? AND IDAbrechnung = ?"
                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION

                    da.SelectCommand.Parameters.AddWithValue("IDKostIntern", IDKostIntern)
                    da.SelectCommand.Parameters.AddWithValue("IDKlinik", IDKlinik)
                    da.SelectCommand.Parameters.AddWithValue("IDAbrechnung", IDAbrechnung)
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(db.bills)
                    If db.bills.Rows.Count <> 1 Then
                        If doExceptionNoBillFound Then
                            Throw New Exception("readBillsIDKostIntern: db.bills.Rows.Count <> 1 for IDKostIntern '" + IDKostIntern.ToString() + "'!")
                        End If
                    Else
                        Return db.bills.Rows(0)
                    End If
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readBillsSR(ByVal IDSR As String, ByRef db As dbPMDS, IDKlinik As System.Guid)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daBill.SelectCommand.CommandText + " where IDSR = ? and  IDKlinik = ?  "
                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION

                da.SelectCommand.Parameters.AddWithValue("IDSR", IDSR)
                da.SelectCommand.Parameters.AddWithValue("IDKlinik", IDKlinik)
                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.bills)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readBill(ByVal ID As String) As dbPMDS.billsRow
        Try
            Using dbPMDS As New dbPMDS
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daBill.SelectCommand.CommandText + " where ID = ? "
                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION
                    da.SelectCommand.Parameters.AddWithValue("ID", ID)
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(dbPMDS.bills)
                    Return dbPMDS.bills.Rows(0)
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function readBillsSR(ByRef monat As Date, ByVal IDKost As String, IDKlinik As System.Guid) As dbPMDS.billsDataTable
        Try
            Using db As New dbPMDS
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daBill.SelectCommand.CommandText + Me.getWhere_SR(monat, IDKost, False, IDKlinik)
                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(db.bills)
                    Return db.bills
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function insertBill(ByRef rNew As dbPMDS.billsRow) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "INSERT INTO bills(ID, Freigegeben, RechNr, Datum, KlientName, KostenträgerName,  Status,  Typ, Rechnung, IDKlient , IDKost, IDKostIntern,  betrag,  IDAbrechnung, IDSR, Erstellt, ErstellAm, dbBill, IDKlinik, RechDatum, IDBillStorno, RollungAnz ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? ) "

                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 50, "ID")).Value = VB.LCase(rNew.ID)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Freigegeben", System.Data.OleDb.OleDbType.Boolean, 1, "Freigegeben")).Value = rNew.Freigegeben
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 50, "RechNr")).Value = rNew.RechNr
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")).Value = rNew.datum
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("KlientName", System.Data.OleDb.OleDbType.VarChar, 100, "KlientName")).Value = rNew.KlientName
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("KostenträgerName", System.Data.OleDb.OleDbType.VarChar, 100, "KostenträgerName")).Value = rNew.KostenträgerName
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.Integer, 4, "Status")).Value = rNew.Status
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Integer, 4, "Typ")).Value = rNew.Typ
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnung")).Value = rNew.Rechnung
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 50, "IDKlient")).Value = VB.LCase(rNew.IDKlient)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKost", System.Data.OleDb.OleDbType.VarChar, 50, "IDKost")).Value = VB.LCase(rNew.IDKost)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKostIntern", System.Data.OleDb.OleDbType.VarChar, 50, "IDKostIntern")).Value = VB.LCase(rNew.IDKostIntern)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("betrag", System.Data.OleDb.OleDbType.Decimal, 21, "betrag")).Value = rNew.betrag
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDAbrechnung", System.Data.OleDb.OleDbType.VarChar, 50, "IDAbrechnung")).Value = VB.LCase(rNew.IDAbrechnung)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSR", System.Data.OleDb.OleDbType.VarChar, 50, "IDSR")).Value = VB.LCase(rNew.IDSR)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarChar, 150, "Erstellt")).Value = rNew.Erstellt
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 8, "ErstellAm")).Value = rNew.ErstellAm
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbBill", System.Data.OleDb.OleDbType.VarChar, 0, "dbBill")).Value = rNew.dbBill

                If rNew.IsIDKlinikNull() Then
                    Throw (New Exception("insertBill: IDKlinik is null!"))
                End If
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")).Value = rNew.IDKlinik
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RechDatum", System.Data.OleDb.OleDbType.Date, 8, "RechDatum")).Value = rNew.RechDatum.Date
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDBillStorno", System.Data.OleDb.OleDbType.VarChar, 0, "IDBillStorno")).Value = ""
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RollungAnz", System.Data.OleDb.OleDbType.Integer, 0, "RollungAnz")).Value = 0

                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveFreigabe(ByRef ID As String, ByVal sRechNr As String, ByVal rechnung As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set Freigegeben = 1, RechNr = '" + sRechNr + "', Status = " + CInt(eBillStatus.freigegeben).ToString() + ", Rechnung = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnung")).Value = rechnung
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveSetFreigegebenSR(ByRef ID As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set Freigegeben = 1, Status = " + CInt(eBillStatus.freigegeben).ToString() + "  where ID  = '" + ID.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveFreigabe(ByRef ID As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set Freigegeben = 1 where ID  = '" + ID.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveDbBill(ByRef ID As String, ByVal xmlDbBill As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set dbBill = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("dbBill", System.Data.OleDb.OleDbType.VarChar, 0, "dbBill")).Value = xmlDbBill
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveBill(ByRef ID As String, ByVal rechnung As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set  Rechnung = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnung")).Value = rechnung
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveBill(ByRef ID As String, ByVal RechDatum As Date) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set  RechDatum = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RechDatum", System.Data.OleDb.OleDbType.Date, 16, "RechDatum")).Value = RechDatum
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveBillRechNr(ByRef ID As String, ByVal RechNr As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set  RechNr = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 0, "RechNr")).Value = RechNr
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function stornieren(ByRef ID As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set Status = -10 where ID = '" + ID.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveRechnung(ByVal IDAbrechnung As String, ByVal Rechnung As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set Rechnung = ? where ID  = ? "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnung")).Value = Rechnung
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 50, "ID")).Value = IDAbrechnung
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveIDSR(ByVal ID As String, ByVal IDSR As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update bills set IDSR = ? where ID  = ? "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSR", System.Data.OleDb.OleDbType.VarChar, 50, "IDSR")).Value = IDSR
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 50, "ID")).Value = ID
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function delBill(ByRef ID As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Delete from bills where ID = '" + ID.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
            End Using
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub alleAllgKostSR_Klienten(ByRef db As dbPMDS, ByRef monat As Date, ByVal IDKost As String, IDKlinik As System.Guid)
        Try
            'Me.alleAllgKostSR(db, monat, IDKost)
            db.bills.Rows.Clear()
            db.Kostentraeger.Rows.Clear()
            db.Patient.Rows.Clear()

            Using dbContext As PMDS.db.Entities.ERModellPMDSEntities = calculation.delgetDBContext.Invoke()
                Dim tRech As dbPMDS.billsDataTable = Me.readBillsSR(monat, IDKost, IDKlinik)
                Dim dbTmp As New dbPMDS()
                For Each rRechOff As dbPMDS.billsRow In tRech
                    dbTmp.Clear()
                    Me.readKlient(rRechOff.IDKlient, dbTmp, True)
                    If dbTmp.Patient.Rows.Count() = 1 Then
                        Dim arrKost() As dbPMDS.KostentraegerRow = db.Kostentraeger.Select("ID = '" + rRechOff.IDKost + "' ")
                        If arrKost.Length = 0 Then
                            Dim rKostNew As dbPMDS.KostentraegerRow = db.Kostentraeger.NewRow()
                            Dim rKosRead As dbPMDS.KostentraegerRow = Me.readKostenräger(rRechOff.IDKost.ToString())
                            rKostNew.ItemArray = rKosRead.ItemArray()
                            db.Kostentraeger.Rows.Add(rKostNew)
                        End If

                        Dim rKlient As dbPMDS.PatientRow = db.Patient.NewRow()
                        Dim rKlienRead As dbPMDS.PatientRow = Me.readKlient(rRechOff.IDKlient)

                        If rKlienRead.WohnungAbgemeldetJN Then
                            readKlinik(db, IDKlinik)
                            Dim rKlinik As PMDS.Calc.Logic.dbPMDS.KlinikRow = db.Klinik.Rows(0)
                            rKlienRead.Strasse = rKlinik.Strasse
                            rKlienRead.Plz = rKlinik.Plz
                            rKlienRead.Ort = rKlinik.Ort
                            rKlienRead.LandKZ = rKlinik.LandKZ
                        End If

                        rKlient.ItemArray = rKlienRead.ItemArray()
                        rKlient.IDKost = rRechOff.IDKost.ToString()
                        db.Patient.Rows.Add(rKlient)
                        rKlient.Sollstand = rRechOff.betrag
                        rKlient.KrankenKasse = rRechOff.ID
                    End If
                Next
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Sub alleAllgKostSR(db As dbPMDS, ByRef monat As Date, ByVal IDKost As String, IDKlinik As System.Guid)
        Try
            db.Kostentraeger.Rows.Clear()

            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daKost.SelectCommand.CommandText + " WHERE (PatientbezogenJN = 0) AND (TransferleistungJN = 0) AND (SammelabrechnungJN = 1) " +
                                   " and " + Me.getWhere_SR(monat, IDKost, True, IDKlinik) + " ORDER BY Name "
                da.SelectCommand = cmd
                da.SelectCommand.Connection = Sql.CONNECTION
                da.SelectCommand.CommandTimeout = 0
                da.Fill(db.Kostentraeger)
            End Using
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Private Function getWhereVonBis(ByVal idKlient As String, ByRef von As Date, ByRef bis As Date,
                                ByVal rechTyp As PMDS.Calc.Logic.eBillTyp, ByVal status As PMDS.Calc.Logic.eBillStatus,
                                ByVal allKlients As Boolean, IDKlinik As System.Guid, showFreigegebenAndStorniert As Boolean) As String
        Try
            Dim sWhere As String = ""
            If idKlient = "" And Not allKlients Then                                ' SR
                sWhere = " where IDKlient = '' "
            ElseIf idKlient <> "" And Not allKlients Then                           ' Klientenrechnung
                sWhere = " where IDKlient = '" + idKlient.ToString() + "' "
            ElseIf idKlient = "" And allKlients Then                                ' Alle Rechnungen
                sWhere = " where IDKlient <> '" + System.Guid.NewGuid().ToString() + "' "
            End If

            If status <> eBillStatus.alle Then

                If showFreigegebenAndStorniert Then
                    sWhere += " and Freigegeben=1 "
                Else
                    If status = eBillStatus.freigegeben Then
                        sWhere += " and Freigegeben=1 "
                    ElseIf status = eBillStatus.storniert Then
                        sWhere += " and Freigegeben=1 "
                    Else
                        sWhere += " and Freigegeben=0 "
                    End If
                End If

                If showFreigegebenAndStorniert Then
                    sWhere += " and (Status=" + CInt(eBillStatus.freigegeben).ToString() + " or Status=" + CInt(eBillStatus.storniert).ToString() + ") "
                Else
                    If status = eBillStatus.freigegeben Or status = eBillStatus.storniert Then
                        If status = eBillStatus.freigegeben Then
                            sWhere += " and Status = " + CInt(status).ToString() + " "
                        ElseIf status = eBillStatus.storniert Then
                            sWhere += " and Status = " + CInt(status).ToString() + " "
                        End If
                    ElseIf status = eBillStatus.offen Then
                    End If
                End If

            End If

            If idKlient = "" And Not allKlients Then
                sWhere += " and Typ = " + CInt(eBillTyp.Sammelrechnung).ToString() + " "
            Else
                If showFreigegebenAndStorniert And rechTyp <> eBillTyp.Alle Then
                    sWhere += " and Typ = " + CInt(rechTyp).ToString() + " "
                Else
                    If ((status = eBillStatus.offen) And rechTyp <> eBillTyp.Depotgeld) Then      ' Freigegebene oder Deotgeld
                        sWhere += " and Typ <> " + CInt(PMDS.Calc.Logic.eBillTyp.Depotgeld).ToString() + " "
                    ElseIf ((status = eBillStatus.offen) And rechTyp = eBillTyp.Depotgeld) Then      ' Freigegebene oder Deotgeld
                        sWhere += " and Typ = " + CInt(rechTyp).ToString() + " "
                    ElseIf ((status = eBillStatus.freigegeben Or status = eBillStatus.storniert) And rechTyp <> eBillTyp.Alle) Then      ' Freigegebene oder Deotgeld
                        sWhere += " and Typ = " + CInt(rechTyp).ToString() + " "
                    End If
                End If
            End If

            sWhere += " and datum >= ? and datum <= ? "
            sWhere += " and IDKlinik = '" + IDKlinik.ToString() + "' "
            Return sWhere

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function getWhere_SR(ByRef monat As Date, ByVal IDKost As String,
                                ByVal subselect As Boolean, IDKlinik As System.Guid) As String
        Try
            Dim sWhere As String = ""
            sWhere = " where IDSR = '' and Typ <> " + CInt(eBillTyp.Sammelrechnung).ToString() + " and Month(datum) = " + monat.Month.ToString() +
                                            " and Year(datum) = " + monat.Year.ToString() + " and RechNr = '' and Freigegeben = 0 "
            If IDKost <> "" Then sWhere += " and IDKost = '" + IDKost + "' "

            If subselect Then
                sWhere = " (SELECT count(*) FROM  bills " + sWhere + " and bills.IDKost = Kostentraeger.ID ) > 0 "
            End If
            sWhere += " and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) "
            Return sWhere

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function readBookings(ByVal idKlient As String, ByVal klientIsEmpty As Boolean, ByVal idKostenträger As String,
                        ByVal konto As String, ByVal Kontoseite As eKontoseite,
                        ByVal von As Date, ByVal bis As Date, ByVal text As String, ByVal db As dbCalc,
                        ByVal calcRun As eCalcRun, IDKlinik As System.Guid) As OleDb.OleDbDataAdapter
        Try

            Using cmd As New OleDb.OleDbCommand(Me.daBooking.SelectCommand.CommandText, Sql.CONNECTION)
                Dim where As String = ""
                Dim str As String = ""

                str = " IDKlinik = ? "
                where += IIf(where = "", " where " + str, " and " + str)
                cmd.Parameters.AddWithValue("IDKlinik", OleDbType.Guid).Value = IDKlinik


                If calcRun <> eCalcRun.all Then
                    If calcRun = eCalcRun.month Then
                        str = " LEFT(ID, 3) <> 'fb-'"
                        where += IIf(where = "", " where " + str, " and " + str)
                    ElseIf calcRun = eCalcRun.freeBill Then
                        str = " LEFT(ID, 3) = 'fb-'"
                        where += IIf(where = "", " where " + str, " and " + str)
                    End If
                End If

                str = " IDKlient = ? "
                where += IIf(where = "", " where " + str, " and " + str)
                cmd.Parameters.AddWithValue("IDKlient", OleDbType.VarChar).Value = IIf(klientIsEmpty, "", idKlient)

                If idKostenträger <> "" Then
                    str = " IDKostenträger = ?"
                    where += IIf(where = "", " where " + str, " and " + str)
                    cmd.Parameters.AddWithValue("IDKostenträger", OleDbType.VarChar).Value = idKostenträger
                End If

                If konto <> "" Then
                    If Kontoseite = eKontoseite.soll Then
                        str = " Sollkonto = ? "
                        where += IIf(where = "", " where " + str, " and " + str)
                        cmd.Parameters.AddWithValue("Sollkonto", OleDbType.VarChar).Value = konto

                    ElseIf Kontoseite = eKontoseite.haben Then
                        str = " Habenkonto = ? "
                        where += IIf(where = "", " where " + str, " and " + str)
                        cmd.Parameters.AddWithValue("Habenkonto", OleDbType.VarChar).Value = konto

                    ElseIf Kontoseite = eKontoseite.beide Then
                        str = " (Sollkonto = ? or Habenkonto = ?) "
                        where += IIf(where = "", " where " + str, " and " + str)
                        cmd.Parameters.AddWithValue("Sollkonto", OleDbType.VarChar).Value = konto
                        cmd.Parameters.AddWithValue("Habenkonto", OleDbType.VarChar).Value = konto
                    End If
                End If

                If text <> "" Then
                    str = " (Text like ? or RechNr like ?) "
                    where += IIf(where = "", " where " + str, " and " + str)
                    cmd.Parameters.AddWithValue("Text", OleDbType.VarChar).Value = "%" + text.ToString() + "%"
                    cmd.Parameters.AddWithValue("RechNr", OleDbType.VarChar).Value = "%" + text.ToString() + "%"
                End If

                If von <> Nothing And von <> calcBase.dat1900 Then
                    str = " Buchungsdatum >= ? "
                    where += IIf(where = "", " where " + str, " and " + str)
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Buchungsdatum")).Value = von.Date

                End If

                If bis <> Nothing And bis <> calcBase.dat2999 Then
                    str = " Buchungsdatum <= ? "
                    where += IIf(where = "", " where " + str, " and " + str)
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Buchungsdatum")).Value = bis.Date
                End If

                cmd.CommandText += where
                cmd.CommandText += " order by Buchungsdatum desc "
                cmd.CommandTimeout = 0

                Dim da As New OleDb.OleDbDataAdapter(cmd)

                da.InsertCommand = Me.OleDbInsertCommand2
                da.InsertCommand.Connection = Sql.CONNECTION

                da.UpdateCommand = Me.OleDbUpdateCommand2
                da.UpdateCommand.Connection = Sql.CONNECTION

                da.DeleteCommand = Me.OleDbDeleteCommand2
                da.DeleteCommand.Connection = Sql.CONNECTION

                da.Fill(db.bookings)
                Return da
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function insertBooking(ByRef rNew As dbCalc.bookingsRow) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "INSERT INTO bookings(ID, Buchungsdatum, Text, Sollkonto, Habenkonto, Betrag, MWStSatz, IDKlient, IDKostenträger,  RechNr, Erstellt, ErstellAm, IDKlinik ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 50, "ID")).Value = VB.LCase(rNew.ID)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 8, "Buchungsdatum")).Value = rNew.Buchungsdatum
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 250, "Text")).Value = rNew.Text
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Sollkonto", System.Data.OleDb.OleDbType.VarChar, 50, "Sollkonto")).Value = rNew.Sollkonto
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Habenkonto", System.Data.OleDb.OleDbType.VarChar, 50, "Habenkonto")).Value = rNew.Habenkonto
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Decimal, 21, "Betrag")).Value = rNew.Betrag
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("MWStSatz", System.Data.OleDb.OleDbType.Integer, 4, "MWStSatz")).Value = rNew.MWStSatz
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 50, "IDKlient")).Value = VB.LCase(rNew.IDKlient)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKostenträger", System.Data.OleDb.OleDbType.VarChar, 50, "IDKostenträger")).Value = VB.LCase(rNew.IDKostenträger)
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 50, "RechNr")).Value = rNew.RechNr
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarChar, 150, "Erstellt")).Value = rNew.Erstellt
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 8, "ErstellAm")).Value = rNew.ErstellAm
                If rNew.IsIDKlinikNull() Then
                    Throw New Exception("Error insertBooking: IDKlinik is null!")
                End If
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")).Value = rNew.IDKlinik
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function delBooking(ByVal idBooking As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Delete from bookings where ID = '" + idBooking.ToString() + "' "
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()

                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function delDepot(ByVal idDepot As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Delete from Taschengeld where ID = '" + idDepot.ToString() + "' "
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readKostenräger(ByVal idKostenräger As String, ByRef db As dbPMDS, ByVal clearDB As Boolean)
        Try
            If clearDB Then
                db.Kostentraeger.Rows.Clear()
            End If

            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand
                cmd.CommandText = Me.daKost.SelectCommand.CommandText + " where LOWER(ID) = '" + idKostenräger + "' "
                da.SelectCommand = cmd
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.Connection = Sql.CONNECTION
                da.Fill(db.Kostentraeger)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readKostenräger(ByVal idKostenräger As String) As dbPMDS.KostentraegerRow
        Try
            Using db As New dbPMDS
                Me.readKostenräger(idKostenräger, db, True)
                Return db.Kostentraeger.Rows(0)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readKlient(ByVal idKlient As String, ByRef db As dbPMDS, ByVal clearDB As Boolean)
        Try
            If clearDB Then
                db.Patient.Rows.Clear()
            End If

            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand
                cmd.CommandText = Me.daKlient.SelectCommand.CommandText + " where Patient.ID = '" + idKlient + "' "
                da.SelectCommand = cmd
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.Connection = Sql.CONNECTION
                da.Fill(db.Patient)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readKlient(ByVal idKlient As String) As dbPMDS.PatientRow
        Try
            Using db As New dbPMDS
                Me.readKlient(idKlient, db, True)
                Return db.Patient.Rows(0)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readKlinik(ByRef db As dbPMDS, IDKlinik As System.Guid)
        Try
            db.Klinik.Rows.Clear()
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand
                cmd.CommandText = Me.daKlinik.SelectCommand.CommandText + " where Klinik.ID = '" + IDKlinik.ToString() + "'"
                da.SelectCommand = cmd
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.Connection = Sql.CONNECTION
                da.Fill(db.Klinik)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function readAufenthAct(ByRef IDKlient As String, IDKlinik As System.Guid) As dbPMDS.AufenthaltRow
        Try
            Using db As New dbPMDS
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daAufenthaltAct.SelectCommand.CommandText + " where IDKlinik = '" + IDKlinik.ToString() + "' and LOWER(IDPatient) = '" + IDKlient + "' and Entlassungszeitpunkt is null "

                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(db.Aufenthalt)
                    If db.Aufenthalt.Rows.Count > 0 Then
                        Return db.Aufenthalt.Rows(0)
                    Else
                        Return Nothing
                    End If
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function readPflegeStAct(ByRef IDKlient As String) As dbPMDS.PatientPflegestufeRow
        Try
            Using db As New dbPMDS
                Using da As New OleDb.OleDbDataAdapter
                    Dim cmd As New OleDb.OleDbCommand

                    cmd.CommandText = Me.daPflegeStAct.SelectCommand.CommandText + " where LOWER(IDPatient) = '" + IDKlient + "' order by PatientPflegestufe.GueltigAb desc "

                    da.SelectCommand = cmd
                    da.SelectCommand.Connection = Sql.CONNECTION
                    da.SelectCommand.CommandTimeout = 0
                    da.Fill(db.PatientPflegestufe)
                    If db.PatientPflegestufe.Rows.Count > 0 Then
                        Return db.PatientPflegestufe.Rows(0)
                    Else
                        Return Nothing
                    End If
                End Using
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function getRechNr(ByVal billTyp As eBillTyp, ByVal year As Integer, ByVal month As Integer,
                              ByVal modifyTyp As eModify, ByVal TypRechNr As String) As Integer
        Try
            Using db As New PMDS.Calc.Logic.dbPMDS
                Dim typ As String = If(billTyp = eBillTyp.Sammelrechnung, eBillTyp.Rechnung.ToString(), billTyp.ToString())
                If modifyTyp = eModify.stornoRech Then
                    typ = "Storno"
                End If

                'Freie Rechnung darf keinen eigenen Nummernkreis eröffnen, sondern als normale Rechnung hochzählen
                If billTyp = eBillTyp.FreieRechnung And modifyTyp <> eModify.stornoRech Then
                    typ = eBillTyp.Rechnung.ToString()
                End If

                Me.daRechNr.SelectCommand.Parameters(0).Value = typ
                Me.daRechNr.SelectCommand.Parameters(1).Value = year
                Me.daRechNr.SelectCommand.Connection = Sql.CONNECTION
                daRechNr.SelectCommand.CommandTimeout = 0
                Me.daRechNr.Fill(db)

                Dim rRechNr As dbPMDS.rechNrRow
                If db.rechNr.Rows.Count > 1 Then
                    Throw New Exception("getRechNr: RechNr für Typ und Jahr existiert mehrmals in DB!")
                ElseIf db.rechNr.Rows.Count = 1 Then
                    rRechNr = db.rechNr.Rows(0)
                ElseIf db.rechNr.Rows.Count = 0 Then
                    rRechNr = db.rechNr.NewRow()
                    rRechNr.typ = typ
                    rRechNr.nr = 0
                    rRechNr.year = year
                    Me.insertRechNr(rRechNr)
                End If

                If TypRechNr.Equals(eTypRechNr.lfdNr.ToString(), StringComparison.CurrentCultureIgnoreCase) Or TypRechNr.Equals(eTypRechNr.Standard.ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                    rRechNr.nr += 1     'Hochzählen innerhalb eines Jahres

                ElseIf TypRechNr.Equals(eTypRechNr.Monatlich.ToString(), StringComparison.CurrentCultureIgnoreCase) Then 'monatliche Rechnungsnummer:   MMnnn

                    Dim Monat As Integer = Int(rRechNr.nr / 1000)

                    If Monat = month Then               'Weitere Rechnung im laufenden Monat
                        rRechNr.nr += 1
                    Else                                'Erste Rechnung in neuem Monat
                        rRechNr.nr = month * 1000 + 1
                    End If
                End If

                Me.saveRechNr(typ, rRechNr.nr, year)
                Return rRechNr.nr
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function insertRechNr(ByRef rNew As dbPMDS.rechNrRow) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "INSERT INTO rechNr(typ, nr, year) VALUES ( ?, ?, ? )"
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 50, "typ")).Value = rNew.typ
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("nr", System.Data.OleDb.OleDbType.Integer, 4, "nr")).Value = rNew.nr
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("year", System.Data.OleDb.OleDbType.Integer, 4, "year")).Value = rNew.year
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Private Function saveRechNr(ByVal typ As String, ByVal aktNr As Integer, ByVal year As Integer) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update rechNr set nr = ? where typ  = ? and year = ? "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("nr", System.Data.OleDb.OleDbType.Integer, 0, "nr")).Value = aktNr
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 50, "typ")).Value = typ
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("year", System.Data.OleDb.OleDbType.Integer, 0, "year")).Value = year
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readDepotgeld(ByVal idKlient As String, ByVal AbrechnenBis As DateTime, ByRef db As dbPMDS, ByVal typ As eZahlEA, ByVal AbgerechnetJN As Boolean,
                             IDKlinik As System.Guid)
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand

                cmd.CommandText = Me.daDepotgeldIDKlient.SelectCommand.CommandText + " where LOWER(IDPatient) = '" + idKlient + "' and " +
                                " AbgerechnetJN = " + IIf(AbgerechnetJN, "1", "0") +
                                IIf(AbrechnenBis.Year <> 1900, " and Datum <= ? ", " ") +
                                IIf(typ = eZahlEA.Auszahlung, " and (Einzahlung = 0 or Einzahlung is null) ", "  and (Auszahlung = 0 or Auszahlung is null)  ") +
                                " and IDKlinik = '" + IDKlinik.ToString() + "' " +
                                " order by Datum asc "
                If AbrechnenBis.Year <> 1900 Then cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")).Value = tools.dat235959(AbrechnenBis)
                da.SelectCommand = cmd
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.Connection = Sql.CONNECTION
                da.Fill(db.Taschengeld)
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Sub

    Public Function getKostDepot(ByVal idKlient As String, ByVal AbrechnenBis As DateTime) As String
        Try
            Using da As New OleDb.OleDbDataAdapter
                Dim cmd As New OleDb.OleDbCommand
                Dim ret As New dbQuery()

                cmd.CommandText = " Select * from PatientTaschengeldKostentraeger where LOWER(IDPatient) = '" + idKlient + "' and " +
                                " GueltigAB <= ? and (GueltigBis >= ? or GueltigBis is null) "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("GueltigAB", System.Data.OleDb.OleDbType.Date, 8, "GueltigAB")).Value = AbrechnenBis.Date
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")).Value = AbrechnenBis.Date
                da.SelectCommand = cmd
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.Connection = Sql.CONNECTION
                da.Fill(ret.table)
                If ret.table.Rows.Count = 0 Then
                    Return kostenträger.IDKostKlient
                ElseIf ret.table.Rows.Count > 1 Then
                    Return ""
                Else
                    Return ret.table.Rows(0)("IDKostentraeger").ToString()
                End If
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function insertDepot(ByRef rNew As dbPMDS.TaschengeldRow) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "INSERT INTO Taschengeld(ID, IDPatient, IDBenutzerdurchgefuehrt, BelegNr, Datum, Grund,  Einzahlung,  Auszahlung, Saldo, Lieferant , Bemerkung, Zahlart,  AbgerechnetJN, IDKlinik ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? ) "
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = rNew.ID
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")).Value = rNew.IDPatient
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDBenutzerdurchgefuehrt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzerdurchgefuehrt")).Value = rNew.IDBenutzerdurchgefuehrt
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BelegNr", System.Data.OleDb.OleDbType.VarChar, 255, "BelegNr")).Value = rNew.BelegNr
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum")).Value = rNew.Datum
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 255, "Grund")).Value = rNew.Grund

                If rNew.IsEinzahlungNull() Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Decimal, 21, "Einzahlung")).Value = System.DBNull.Value
                Else
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Decimal, 21, "Einzahlung")).Value = rNew.Einzahlung
                End If
                If rNew.IsAuszahlungNull() Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Decimal, 21, "Auszahlung")).Value = System.DBNull.Value
                Else
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Decimal, 21, "Auszahlung")).Value = rNew.Auszahlung
                End If

                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Saldo", System.Data.OleDb.OleDbType.Decimal, 21, "Saldo")).Value = rNew.Saldo
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarChar, 255, "Lieferant")).Value = rNew.Lieferant
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 255, "Bemerkung")).Value = rNew.Bemerkung
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 4, "Zahlart")).Value = rNew.Zahlart
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 1, "AbgerechnetJN")).Value = rNew.AbgerechnetJN
                If rNew.IsIDKlinikNull() Then
                    Throw (New Exception("insertDepot: IDKlinik is null!"))
                End If
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")).Value = rNew.IDKlinik

                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function saveDepot(ByRef ID As String, ByVal abgerechnetJN As Boolean) As Boolean
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Update Taschengeld set  AbgerechnetJN = ?  where ID  = '" + ID.ToString() + "' "
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 1, "AbgerechnetJN")).Value = abgerechnetJN
                cmd.CommandTimeout = 0
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function admin_clearCalcDB() As Boolean
        Try
            Using cmd As New OleDbCommand

                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.CommandText = "delete bills;" +
                                "delete billHeader;" +
                                "delete bookings;" +
                                "delete rechNr;" +
                                "update Taschengeld  set AbgerechnetJN = 0;" +
                                "UPDATE PatientTaschengeldKostentraeger SET AbgerechnetBis = NULL"
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function admin_clearAllDepot() As Boolean
        Try
            Using cmd As New OleDbCommand
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.CommandText = "delete bills where Typ = 5;" +
                                "update Taschengeld  set AbgerechnetJN = 0;" +
                                "UPDATE PatientTaschengeldKostentraeger SET AbgerechnetBis = NULL"
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function admin_clearAllSR() As Boolean
        Try
            Using cmd As New OleDbCommand
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.CommandText = "delete bills where Typ = 3;" +
                                "update bills set IDSR =''"
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function admin_clearAllRechNr() As Boolean
        Try
            Using cmd As New OleDbCommand
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.CommandText = "delete rechNr"
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function executeCommand(ByVal sqlCmd As String) As Boolean
        Try
            Using cmd As New OleDbCommand
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION

                cmd.CommandText = sqlCmd
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                Return True
            End Using

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub readBillHeaderUpdate(ByVal ID As String, ByRef db As dbPMDS)
        Try
            Me.daBillHeaderUpdate.SelectCommand.CommandText = Me.SelBillsHeader

            Me.daBillHeaderUpdate.SelectCommand.Connection = Sql.CONNECTION
            Me.daBillHeaderUpdate.InsertCommand.Connection = Sql.CONNECTION
            Me.daBillHeaderUpdate.UpdateCommand.Connection = Sql.CONNECTION
            Me.daBillHeaderUpdate.DeleteCommand.Connection = Sql.CONNECTION

            Me.daBillHeaderUpdate.SelectCommand.Parameters.Clear()

            Me.daBillHeaderUpdate.SelectCommand.CommandText += " where ID = '" + ID.ToString() + "' "
            Me.daBillHeaderUpdate.SelectCommand.CommandTimeout = 0
            Me.daBillHeaderUpdate.Fill(db.billHeaderUpdate)

        Catch ex As Exception
            Throw New Exception("sql.readBillHeaderUpdate: " + ex.ToString())
        End Try
    End Sub

    Public Sub readBillUpdate(ByVal ID As String, ByRef db As dbPMDS)
        Try
            Me.daBillUpdate.SelectCommand.CommandText = Me.SelBills

            Me.daBillUpdate.SelectCommand.Connection = Sql.CONNECTION
            Me.daBillUpdate.InsertCommand.Connection = Sql.CONNECTION
            Me.daBillUpdate.UpdateCommand.Connection = Sql.CONNECTION
            Me.daBillUpdate.DeleteCommand.Connection = Sql.CONNECTION

            Me.daBillUpdate.SelectCommand.Parameters.Clear()

            Me.daBillUpdate.SelectCommand.CommandText += " where ID = '" + ID.ToString() + "' "
            Me.daBillUpdate.SelectCommand.CommandTimeout = 0
            Me.daBillUpdate.Fill(db.billsUpdate)

        Catch ex As Exception
            Throw New Exception("sql.readBillUpdate: " + ex.ToString())
        End Try
    End Sub

    Public Sub updateBillRechnung(ByVal ID As String, Rechnung As String)
        Try
            Dim cmd As New OleDb.OleDbCommand()
            cmd.CommandText = "Update bills set Rechnung='" + Rechnung + "' where ID='" + ID.ToString() + "'"
            If Sql.CONNECTION.State = ConnectionState.Closed Then
                Sql.CONNECTION.Open()
            End If
            cmd.Connection = Sql.CONNECTION
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("sql.updateBillRechnung: " + ex.ToString())
        End Try
    End Sub

    Public Sub updateBillSet_IDBillStorno(ByVal ID As String, IDBillStorno As String)
        Try
            Using cmd As New OleDb.OleDbCommand()
                cmd.CommandText = "Update bills set IDBillStorno='" + IDBillStorno.Trim() + "', RollungAnz=0 where ID='" + ID.ToString() + "'"
                If Sql.CONNECTION.State = ConnectionState.Closed Then
                    Sql.CONNECTION.Open()
                End If
                cmd.Connection = Sql.CONNECTION
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception("sql.updateBillSet_IDStorno: " + ex.ToString())
        End Try
    End Sub
End Class

Public Class dbQuery

    Private _table As New DataTable
    Private _dAdap As New OleDbDataAdapter
    Private _cmd As New OleDbCommand

    Public Property table As DataTable
        Get
            Return _table
        End Get
        Set(ByVal value As DataTable)
            _table = value
        End Set
    End Property

    Public Property dAdap As OleDbDataAdapter
        Get
            Return _dAdap
        End Get
        Set(ByVal value As OleDbDataAdapter)
            _dAdap = value
        End Set
    End Property

    Public Property cmd As OleDbCommand
        Get
            Return _cmd
        End Get
        Set(ByVal value As OleDbCommand)
            _cmd = value
        End Set
    End Property

End Class

Public Class dbParameter

    Private _parameter As OleDbParameter
    Private _value As New Object

    Public Property parameter As OleDbParameter
        Get
            Return _parameter
        End Get
        Set(ByVal value As OleDbParameter)
            _parameter = value
        End Set
    End Property

    Public Property value As Object
        Get
            Return _value
        End Get
        Set(ByVal val As Object)
            _value = val
        End Set
    End Property

End Class