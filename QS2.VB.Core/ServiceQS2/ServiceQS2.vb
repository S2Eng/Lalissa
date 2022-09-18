Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel



Public Class cServiceQS2

    Public b As New qs2.core.vb.businessFramework()












    Public Shared Function getServiceReference() As qs2.core.vb.QS2Service1.ServiceClient
        Try
            Dim address As New EndpointAddress(qs2.core.ENV.UrlQS2Service.Trim())
            Dim binding As New BasicHttpBinding()
            binding.OpenTimeout = New TimeSpan(0, 5, 0)
            binding.CloseTimeout = New TimeSpan(0, 5, 0)
            binding.SendTimeout = New TimeSpan(0, 5, 0)
            binding.ReceiveTimeout = New TimeSpan(0, 5, 0)

            If qs2.core.ENV.UrlQS2Service.Trim().ToLower().Contains(("https").Trim().ToLower()) Then
                binding.Security.Mode = BasicHttpSecurityMode.Transport
            End If

            binding.MaxReceivedMessageSize = 2147483647         ' 6553600
            Dim Service1 As New qs2.core.vb.QS2Service1.ServiceClient(binding, address)
            'cServiceQS2.setInitiateSSLTrust()
            TrustAllCertificatePolicy.OverrideCertificateValidation()

            Return Service1

        Catch ex As Exception
            Throw New Exception("cServiceQS2.getServiceReference: " + ex.ToString())
        End Try
    End Function
    Public Shared Function setInitiateSSLTrust() As Boolean
        Try
            If (qs2.core.ENV.UrlQS2Service.Trim().ToLower().Contains("s2e") Or qs2.core.ENV.UrlQS2Service.Trim().ToLower().Contains("styhl2") Or qs2.core.ENV.UrlQS2Service.Trim().ToLower().Contains("localhost")) Then
                qs2.core.generic.InitiateSSLTrust()
            End If

        Catch ex As Exception
            Throw New Exception("cServiceQS2.setInitiateSSLTrust: " + ex.ToString())
        End Try
    End Function


    Public Function CheckQS2Service() As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            Dim ServiceResult As New qs2.core.vb.QS2Service1.cServiceResult
            ServiceResult.OK = True

            Dim v As String = New String("A", 70000)
            ServiceInput.AllParametersAsTxtReturn = v
            ServiceResult = Service1.CheckQS2Service(ServiceInput)
            If ServiceResult.Exception.Trim() <> "" Then
                Throw New Exception(ServiceResult.Exception.Trim())
            End If
            Return ServiceResult.OK

        Catch ex As Exception
            Throw New Exception("cServiceQS2.CheckQS2Service: " + ex.ToString())
        End Try
    End Function

    Public Function TestService() As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim bOK As Boolean = Service1.TestService("Inp")
            Return bOK

        Catch ex As Exception
            Throw New Exception("cServiceQS2.TestService: " + ex.ToString())
        End Try
    End Function
    Public Function TestService2() As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim ServiceInput As New QS2Service1.cServiceInput()
            Dim ServiceResult As QS2Service1.cServiceResult = Service1.TestService2(ServiceInput)
            Return True

        Catch ex As Exception
            Throw New Exception("cServiceQS2.TestService2: " + ex.ToString())
        End Try
    End Function
    Public Function TestService3() As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim ServiceInput As New QS2Service1.cServiceInput()
            Dim ServiceResult As QS2Service1.cServiceResult12 = Service1.TestService3(ServiceInput)
            Return True

        Catch ex As Exception
            Throw New Exception("cServiceQS2.TestService3: " + ex.ToString())
        End Try
    End Function


    Public Function getStaysIncorrectlyTransfered(ByRef IDParticipant As String, ByRef IDApplication As String,
                                                  ByRef dFrom As Nullable(Of DateTime), ByRef dTo As Nullable(Of DateTime), ByRef sWhereBack As String,
                                                  ByRef ServiceResult As qs2.core.vb.QS2Service1.cServiceResult) As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()

            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            ServiceInput.IDParticipant = IDParticipant.Trim()
            ServiceInput.IDApplication = IDApplication.Trim()
            ServiceInput.dFrom = dFrom
            ServiceInput.dTo = dTo
            ServiceInput.dNow = DateTime.Now
            ServiceResult = Service1.getStaysIncorrectlyTransfered(ServiceInput)
            If ServiceResult.Exception.Trim() <> "" Then
                Throw New Exception(ServiceResult.Exception.Trim())
            End If

            sWhereBack = ServiceResult.sWhere
            Return ServiceResult.OK

        Catch ex As Exception
            Throw New Exception("cServiceQS2.getStaysIncorrectlyTransfered: " + ex.ToString())
        End Try
    End Function
    Public Function getStaysBPKZWrong(ByRef IDParticipant As String, ByRef IDApplication As String,
                                        ByRef dFrom As Nullable(Of DateTime), ByRef dTo As Nullable(Of DateTime), ByRef sWhereBack As String,
                                        ByRef ServiceResult As qs2.core.vb.QS2Service1.cServiceResult) As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()

            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            ServiceInput.IDParticipant = IDParticipant.Trim()
            ServiceInput.IDApplication = IDApplication.Trim()
            ServiceInput.dFrom = dFrom
            ServiceInput.dTo = dTo
            ServiceInput.dNow = DateTime.Now
            ServiceResult = Service1.getBPKZWrong(ServiceInput)
            If ServiceResult.Exception.Trim() <> "" Then
                Throw New Exception(ServiceResult.Exception.Trim())
            End If

            sWhereBack = ServiceResult.sWhere
            Return ServiceResult.OK

        Catch ex As Exception
            Throw New Exception("cServiceQS2.getStaysBPKZWrong: " + ex.ToString())
        End Try
    End Function

    Public Function updateStaySetBPKZFinishedClient(ByRef StayIDGuid As Guid, ByRef bValue As Boolean) As Boolean
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim ServiceResult As qs2.core.vb.QS2Service1.cServiceResult = Service1.updateStaySetBPKZFinishedClient(StayIDGuid.ToString(), bValue)
            If ServiceResult.Exception.Trim() <> "" Then
                Throw New Exception(ServiceResult.Exception.Trim())
            End If

            Return ServiceResult.OK

        Catch ex As Exception
            Throw New Exception("cServiceQS2.updateStaySetBPKZFinishedClient: " + ex.ToString())
        End Try
    End Function

    Public Sub SendSTSStay(ByRef rStayFound As qs2.core.vb.dsObjects.tblStayRow, ByRef iSent As Integer, ByRef iCounterColumnsAnonymoused As Integer,
                           ByRef Service1 As qs2.core.vb.QS2Service1.ServiceClient, ByRef SendStayOK As Boolean,
                           ByRef ServiceResult2 As qs2.core.vb.QS2Service1.cServiceResult12, ByRef lstErrorFields As System.Collections.Generic.List(Of String),
                           ByRef TransferProtocolColNotOnClient As String, ByRef TransferProtocolColNotOnServer As String, ByRef ProtocollListStay As String, ByRef ProtExceptions As String, ByRef ProtocollSum As String,
                           ByRef iStaysSent As Integer, ByRef iFUPSSent As Integer, ByRef iExceptions As Integer)
        Try
            'Dim binding As New System.ServiceModel.BasicHttpBinding()
            'binding.MaxReceivedMessageSize = 2147483647
            'binding.MaxBufferSize = 2147483647
            'binding.ReceiveTimeout = New System.TimeSpan(0, 10, 0)
            'binding.SendTimeout = New System.TimeSpan(0, 10, 0)
            'binding.ReaderQuotas.MaxDepth = 2147483647
            'binding.ReaderQuotas.MaxStringContentLength = 2147483647
            'binding.ReaderQuotas.MaxArrayLength = 2147483647
            'binding.ReaderQuotas.MaxBytesPerRead = 2147483647
            'binding.ReaderQuotas.MaxNameTableCharCount = 2147483647

            ' ''Dim endpointAddress As New EndpointAddress("http:/localhost/servQS2/Service.svc")
            Dim SendStay As New cSendStay()
            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            Dim dsToSend As New DataSet()
            SendStay.SendStay(rStayFound, iSent, dsToSend, iCounterColumnsAnonymoused)

            Dim dsAdminObjectFields As New dsAdmin()
            b.getObjectFields(ServiceInput, False, True, dsAdminObjectFields)
            b.GetGuidsForObjectFields(ServiceInput, dsToSend, dsAdminObjectFields)

            Dim sw As New System.IO.StringWriter()
            dsToSend.WriteXml(sw, XmlWriteMode.WriteSchema)
            ServiceInput.dsXML = sw.ToString()

            'Gültigkeit des SSL-Zertifikats ignorieren in der Testumgebung

            'os 160129: Proxy verwenden
            'Dim ncr As NetworkCredential = qs2.core.generic.SetProxyCredentials(Service1.Url)
            'If Not ncr Is Nothing Then
            '    Service1.Credentials = ncr
            'End If
            'Dim dsCheckTmp As New DataSet()
            'dsCheckTmp.ReadXml(New System.IO.StringReader(ServiceInput.dsXML))
            'Dim rObj As DataRow = dsCheckTmp.Tables("tblObject").Rows(0)
            'dsToSend.WriteXml("H:\\test99.xml", XmlWriteMode.WriteSchema)



            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()
            Dim rPatient As dsObjects.tblObjectRow = sqlObjectsTmp.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", rStayFound.PatIDGuid)

            Dim Protocol1 As New qs2.core.vb.Protocol()
            ServiceInput.dNow = DateTime.Now
            'ServiceResult = Service1.CheckQS2Service(ServiceInput)
            ServiceResult2 = Service1.SendStay2(ServiceInput)

            Dim sInfoStay2 As String = qs2.core.language.sqlLanguage.getRes("MedRecNr") + ": " + "" + rStayFound.MedRecN + ", " +
                                                                   qs2.core.language.sqlLanguage.getRes("Incidence") + ": " + rStayFound.Incidence.ToString() + " " +
                                                                    " (" + IIf(rStayFound.StayTyp = 0, qs2.core.language.sqlLanguage.getRes("Stay"), qs2.core.language.sqlLanguage.getRes("cmb_FollowUp")) + "), " + qs2.core.language.sqlLanguage.getRes("grpInfoPatient") + ": " + rPatient.NameCombination + ""

            If Not String.IsNullOrEmpty(ServiceResult2.Exception) Or Not ServiceResult2.OK Then
                iExceptions += 1

                If Not ServiceResult2.OK Then
                    ServiceResult2.Exception += vbNewLine + vbNewLine + "Error - ServiceResult.OK is not true for " + sInfoStay2 + "!"
                End If
                Protocol1.save2(Protocol.eTypeProtocoll.RunUpload, rStayFound.PatIDGuid, rStayFound.ID, rStayFound.IDParticipant, rStayFound.IDApplication, "Send STS", "STS no service", Protocol.eActionProtocol.None, rPatient.NameCombination.Trim(), rStayFound.MedRecN.Trim())
                'frmProtokoll1.ContProtocol1.txtProtokoll.Text = qs2.core.language.sqlLanguage.getRes("NoSTSService")
                ProtExceptions += iExceptions.ToString() + ". Error Send Stay:" + sInfoStay2 + " (" + rStayFound.IDParticipant.Trim() + ")" + vbNewLine +
                                  "Exception: " + ServiceResult2.Exception.Trim() + vbNewLine + vbNewLine
            Else
                If Not IsNothing(ServiceResult2.lstErrorColumnsSum) AndAlso ServiceResult2.lstErrorColumnsSum.Count > 0 Then
                    For Each ColumnsTransferNotOK In ServiceResult2.lstErrorColumnsSum
                        If Not lstErrorFields.Contains(ColumnsTransferNotOK.Value.TableName + "." + ColumnsTransferNotOK.Value.ColumnName) Then
                            Dim sFieldTransl As String = qs2.core.language.sqlLanguage.getRes(ColumnsTransferNotOK.Value.ColumnName)
                            If String.IsNullOrEmpty(sFieldTransl) Then
                                sFieldTransl = ColumnsTransferNotOK.Value.ColumnName
                            End If
                            If ColumnsTransferNotOK.Value.eErrorTypeTransfer = QS2Service1.cUpdateDataeErrorTypeTransfer.Client Then
                                TransferProtocolColNotOnClient += IIf(String.IsNullOrEmpty(TransferProtocolColNotOnClient), "", " ,") + sFieldTransl + " (" + ColumnsTransferNotOK.Value.TableName + "." + ColumnsTransferNotOK.Value.ColumnName + ")"
                            ElseIf ColumnsTransferNotOK.Value.eErrorTypeTransfer = QS2Service1.cUpdateDataeErrorTypeTransfer.Server Then
                                TransferProtocolColNotOnServer += IIf(String.IsNullOrEmpty(TransferProtocolColNotOnServer), "", " ,") + sFieldTransl + " (" + ColumnsTransferNotOK.Value.TableName + "." + ColumnsTransferNotOK.Value.ColumnName + ")"
                            Else
                                Throw New Exception("ServiceQS2.SendSTSStay: eErrorTypeTransfer '" + ColumnsTransferNotOK.Value.eErrorTypeTransfer.ToString() + "' not allowed!")
                            End If

                            lstErrorFields.Add(ColumnsTransferNotOK.Value.TableName + "." + ColumnsTransferNotOK.Value.ColumnName)
                        End If
                    Next
                End If
            End If

            If Not String.IsNullOrEmpty(ServiceResult2.BPKServiceResult.ErrorMessageFromBPKService) Then
                ProtExceptions += "Error from BPK-Service: " + vbNewLine + sInfoStay2 + vbNewLine + ServiceResult2.BPKServiceResult.ErrorMessageFromBPKService.Trim() + "" + vbNewLine + vbNewLine
                iExceptions += 1
            End If
            If String.IsNullOrEmpty(ServiceResult2.Exception) Then
                If rStayFound.StayTyp = qs2.core.Enums.eStayTyp.Stay Then
                    iStaysSent += 1
                ElseIf rStayFound.StayTyp = qs2.core.Enums.eStayTyp.FollowUp Then
                    iFUPSSent += 1
                End If

                ProtocollListStay += sInfoStay2 + vbNewLine
                iSent += 1
            End If
            SendStayOK = True

        Catch ex As Exception
            Throw New Exception("cServiceQS2.SendSTSStay: " + ex.ToString())
        End Try
    End Sub


    Public Function fillDataSetExtern(ByRef sqlCommand As String, parameters As System.Collections.Generic.List(Of System.Data.SqlClient.SqlParameter),
                                      ByRef dsQryAuto1 As DataSet, tableName As String, datasetName As String, ByRef AllParametersAsTxtReturn As String,
                                      ByRef isFct As Boolean,
                                      ByRef lstParForExternFct As System.Collections.Generic.List(Of qs2.core.vb.QS2Service1.cSqlParameter)) As qs2.core.vb.QS2Service1.cServiceResult
        Try
            Dim Service1 As qs2.core.vb.QS2Service1.ServiceClient = qs2.core.vb.cServiceQS2.getServiceReference()
            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            ServiceInput.dNow = DateTime.Now
            ServiceInput.sqlCommand = sqlCommand
            ServiceInput.IsFunction = isFct
            ServiceInput.IsHeadquarter = ENV.IsHeadquarter
            ServiceInput.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()

            Dim iCounterParameter As Integer = 0
            If parameters.Count > 0 Then
                Dim ParService(parameters.Count - 1) As qs2.core.vb.QS2Service1.cSqlParameter
                For Each sqlPar As System.Data.SqlClient.SqlParameter In parameters
                    Dim TypeIntern As qs2.core.dbBase.eTypeInt = qs2.core.dbBase.getType(sqlPar.Value.GetType())
                    Dim sqlParServ As New qs2.core.vb.QS2Service1.cSqlParameter
                    If TypeIntern = core.dbBase.eTypeInt.t_int Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_dbl Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_string Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_DateTime Then
                        Dim dDat As Date = sqlPar.Value
                        sqlParServ.sValue = dDat.Year.ToString() + b.CheckAddNull(dDat.Month.ToString()) + b.CheckAddNull(dDat.Day.ToString()) +
                                            b.CheckAddNull(dDat.Hour.ToString()) + b.CheckAddNull(dDat.Minute.ToString()) + b.CheckAddNull(dDat.Second.ToString())

                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_Guid Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_DBNull Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    ElseIf TypeIntern = core.dbBase.eTypeInt.t_Boolean Then
                        sqlParServ.sValue = sqlPar.Value.ToString()
                    Else
                        Throw New Exception("cServiceQS2.fillDataSetExtern: TypeIntern '" + TypeIntern.ToString() + "' not allowed!")
                    End If
                    sqlParServ.TypeIntern = TypeIntern
                    sqlParServ.DbType = sqlPar.DbType
                    sqlParServ.ParameterName = sqlPar.ParameterName
                    sqlParServ.SourceColumn = sqlPar.SourceColumn
                    sqlParServ.IsObjectFieldForChange = False
                    sqlParServ.IDObjectGuid = System.Guid.Empty.ToString()
                    ParService(iCounterParameter) = sqlParServ
                    iCounterParameter += 1
                Next
                ServiceInput.parameters = ParService
            End If

            Dim dsAdminObjectFields As New dsAdmin()
            b.getObjectFields(ServiceInput, isFct, False, dsAdminObjectFields)

            If lstParForExternFct.Count > 0 Then
                iCounterParameter = 0
                Dim ParServiceFct(lstParForExternFct.Count - 1) As qs2.core.vb.QS2Service1.cSqlParameter
                For Each SqlParameterFoundForFct As qs2.core.vb.QS2Service1.cSqlParameter In lstParForExternFct
                    ParServiceFct(iCounterParameter) = SqlParameterFoundForFct
                    iCounterParameter += 1
                Next
                ServiceInput.lstListparametersForFunctions = ParServiceFct
            End If

            ServiceInput.tableName = tableName
            ServiceInput.datasetName = datasetName
            ServiceInput.AllParametersAsTxtReturn = AllParametersAsTxtReturn

            'os 160129: Proxy verwenden
            'Dim ncr As NetworkCredential = qs2.core.generic.SetProxyCredentials(Service1.Url)
            'If Not ncr Is Nothing Then
            '    Service1.Credentials = ncr
            'End If

            Dim ServiceResult As qs2.core.vb.QS2Service1.cServiceResult = Service1.ExecuteCommand(ServiceInput)
            sqlCommand = ServiceResult.sCommand
            If ServiceResult.Exception.Trim() <> "" Then
                Throw New Exception(ServiceResult.Exception.Trim())
            End If
            AllParametersAsTxtReturn = ServiceResult.AllParametersAsTxtReturn
            dsQryAuto1.ReadXml(New System.IO.StringReader(ServiceResult.dsXML), XmlReadMode.ReadSchema)

            Return ServiceResult

        Catch ex As Exception
            Throw New Exception("cServiceQS2.fillDataSetExtern: " + ex.ToString())
        End Try
    End Function


    Public Function newRowObjectService(ByRef ds As QS2Service1.dsService)
        Try
            Dim rNew As QS2Service1.dsService.tblObjectRow = ds.tblObject.NewRow()
            rNew.ID = -999
            rNew.IDGuid = System.Guid.Empty
            rNew.FirstName = ""
            rNew.LastName = ""
            rNew.NameCombination = ""
            rNew.IsPatient = False
            rNew.SetDOBNull()
            rNew.MtStat = -999
            rNew.SetMtDateNull()
            rNew.MTLocatn = -999
            rNew.MtCause = -999
            rNew.ICD9 = ""
            rNew.IDParticipant = ""
            rNew.ExtIDNr = -999
            rNew.Active = False
            rNew.ExtID = ""

            ds.tblObject.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("cServiceQS2.newRowObjectService: " + ex.ToString())
        End Try
    End Function


End Class



Public Class TrustAllCertificatePolicy

    Public Shared Sub OverrideCertificateValidation()
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf RemoteCertValidate)
    End Sub

    Private Shared Function RemoteCertValidate(ByVal sender As Object, ByVal cert As X509Certificate, ByVal chain As X509Chain, ByVal [error] As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

End Class