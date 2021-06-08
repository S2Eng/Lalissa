Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic



Public Class calcBase


    Public Shared bookingJN As Boolean = True
    Public Shared KürzGrundLetztTag As Boolean = False
    Public Shared usr As String = ""
    Public Shared usrID As String = ""
    Public Shared errTxt As String = ""
    Public Shared Version As String = "1"
    Public Shared DepotgeldKontoTxt As String = ""
    Public Shared RechTitelDepotGeld As String = ""

    Public Shared pathConfig As String = ""
    Public Shared fileMWStSätze As String = "PMDS.Abrechnung.config"

    Public Shared TageOhneKuerzungGrundleistung As Integer = 0
    Public Shared KuerzungGrundleistungLetzterTag As Boolean = False

    Public Shared RechErwAbwesenheit As Boolean = False
    Public Shared SrErwAbwesenheit As Boolean = False

    Public sql As New Sql







    Public Function rowKlient(ByRef dbCalc As dbCalc) As dbCalc.KlientRow
        If dbCalc.Klient.Rows.Count <> 1 Then Throw New Exception("calc.rowKlient: no klient in dbCalc!")
        Return dbCalc.Klient.Rows(0)
    End Function
    Public Function rowMonat(ByRef dbCalc As dbCalc) As dbCalc.MonateRow
        If dbCalc.Monate.Rows.Count <> 1 Then Throw New Exception("calc.rowMonat: no month in dbCalc!")
        Return dbCalc.Monate.Rows(0)
    End Function
    Public Function selectTag(ByVal dat As Date, ByRef dbCalc As dbCalc, doExceptionWhenDayNotFound As Boolean) As dbCalc.TageRow

        Dim rTag As dbCalc.TageRow() = dbCalc.Tage.Select("Tag=" + dat.Day.ToString() + " and Monat=" + dat.Month.ToString() + " and Jahr=" + dat.Year.ToString())
        If rTag.Length > 1 Then
            Throw New Exception("Tage.Select: not exactly one row at " + dat.ToString())
        End If
        If rTag.Length = 1 Then
            Return rTag(0)
        Else
            If doExceptionWhenDayNotFound Then
                Throw New Exception("Tage.Select: not exactly one row at " + dat.ToString())
            End If
            Return Nothing
        End If
    End Function

    Public Function getHeader(ByVal idAbrechnung As String, IDKlinik As System.Guid) As dbPMDS.billHeaderRow
        Try
            Dim dbPMDS As New dbPMDS
            Me.sql.readBillHeader(idAbrechnung, dbPMDS, IDKlinik)
            Return dbPMDS.billHeader.Rows(0)

        Catch exept As Exception
            calcBase.doExept(exept)
            Return Nothing
        End Try
    End Function
    Public Function getDBCalc(ByVal xml As String) As dbCalc
        Try
            Dim dbCalc As New dbCalc
            Dim xmlStringReader As New System.IO.StringReader(xml)
            Dim xmlReader As New System.Xml.XmlTextReader(xmlStringReader)
            dbCalc.ReadXml(xmlReader)
            xmlReader.Close()
            Return dbCalc

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Sub addToProt(ByVal txt As String, ByVal anzEnter As Integer, ByRef calc As calcData, _
                                     Optional ByVal line As Boolean = False)

        Dim newTxt As String = ""
        If line Then
            newTxt += "----------------------------------------------------------------------------------------------------------"
        Else
            If txt <> "" Then
                newTxt += txt
            End If
        End If

        Me.addSpace(anzEnter, newTxt)
        calc.protokoll += newTxt
    End Sub

    Public Function IDIsCalculated(ByVal IDToCheck As String, ByRef listIDRechOK As System.Collections.Generic.List(Of String)) As Boolean
        Try
            For Each id As String In listIDRechOK
                If IDToCheck = id Then Return True
            Next

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Shared Function doExept(ByRef exept As Exception) As String
        If calcBase.errTxt = "" Then calcBase.errTxt = calcBase.exeptToStr(exept)
        Throw exept
    End Function
    Public Shared Function exeptToStr(ByRef ex As Exception) As String
        Return ex.ToString()
    End Function


    Public Function Min(ByRef p1 As Object, ByRef p2 As Object) As Object
        Try
            If p1 <= p2 Then
                Return p1
            Else
                Return p2
            End If
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function Max(ByRef p1 As Object, ByRef p2 As Object) As Object
        Try
            If p1 >= p2 Then
                Return p1
            Else
                Return p2
            End If
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function monatsende(ByVal abrechStart As DateTime) As DateTime
        Try
            Dim datBis As New DateTime(abrechStart.Year, abrechStart.Month, DateTime.DaysInMonth(abrechStart.Year, abrechStart.Month), 23, 59, 59)
            Return datBis
        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function

    Public Function addSpace(ByVal anz As Integer, ByRef newTxt As String) As String
        For i As Integer = 0 To anz - 1
            newTxt += Chr(13) + Chr(10)                 'Microsoft.VisualBasic.Constants.vbCrLf
        Next
        Return newTxt
    End Function
    Public Function addTab(ByVal anz As Integer) As String
        Dim str As String = ""
        For i As Integer = 0 To anz - 1
            str += vbTab
        Next
        Return str
    End Function

    Public Function dateFormat() As String
        Return "dd.MM.yyyy"
    End Function
    Public Function decFormat() As String
        Return "###,###,##0.00"
    End Function
    Public Function calcLfdNr(ByVal nr As Integer) As String

        Dim ret As String = ""
        Select Case nr
            Case Is < 10
                ret = "0000" + nr.ToString()
            Case Is < 100
                ret = "000" + nr.ToString()
            Case Is < 1000
                ret = "00" + nr.ToString()
            Case Is < 10000
                ret = "0" + nr.ToString()
            Case Is < 100000
                ret = "" + nr.ToString()
            Case Else
                Throw New Exception("calcLfdNr: Nummerkreis überschreitet die 10000-er Grenze!")
        End Select
        Return ret

    End Function

    Public Function dec3WithEuro(ByVal Zahl As Decimal) As String
        'Rückgabe einer Dezimalzahl als Euro-String
        Try
            Return Zahl.ToString("###,###,##0.000") + " €"

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function
    Public Function decWithEuro(ByVal Zahl As Decimal) As String
        'Rückgabe einer Dezimalzahl als Euro-String
        Try
            'Return String.Format("{0:c}", Zahl)
            Return (Math.Round(Zahl, 2)).ToString(Me.decFormat) + " €"

        Catch exept As Exception
            calcBase.doExept(exept)
        End Try
    End Function


    Public ReadOnly Property int99999999() As Integer
        Get
            int99999999 = 99999999
        End Get
    End Property

    Public Shared ReadOnly Property dat2999() As DateTime
        Get
            dat2999 = New Date(2999, 12, 31)
        End Get
    End Property
    Public Shared ReadOnly Property dat1900() As DateTime
        Get
            dat1900 = DateSerial(1900, 1, 1)
        End Get
    End Property

    Public Shared Function getBillStatusAsString(ByVal BillStatusToSearch As eBillStatus) As String
        For Each Val As Integer In [Enum].GetValues(GetType(eBillStatus))        '<20120111-2>
            If BillStatusToSearch = Val Then
                Dim strVal As String = [Enum].GetName(GetType(eBillStatus), Val)
                Return strVal
            End If
        Next
    End Function
    Public Shared Function getBillTypAsString(ByVal BillTypeToSearch As eBillTyp) As String
        For Each Val As Integer In [Enum].GetValues(GetType(eBillTyp))           '<20120111-2>
            If BillTypeToSearch = Val Then
                Dim strVal As String = [Enum].GetName(GetType(eBillTyp), Val)
                Return strVal
            End If
        Next
    End Function

End Class
