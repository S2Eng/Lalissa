Public Class doDB

    Public Shared tableNameUser As String = "User"
    Public Shared tableNameUserAdress As String = "UserAdress"
    Public Shared tableNamePatients As String = "Patients"
    Public Shared tableNamePatientsAdress As String = "PatientsAdress"

    Public Shared Sub addObjectTablesToDataset(ByVal dsToAdd As System.Data.DataSet,
                                          ByVal tableNameObject As String, ByVal tableNameAdress As String, ByVal addAdressTable As Boolean)
        Try
            Dim tObjectUsr As New dsObjects.tblObjectDataTable
            tObjectUsr.TableName = tableNameObject
            If Not dsToAdd.Tables.Contains(tableNameObject) Then
                dsToAdd.Tables.Add(tObjectUsr)
            End If

        Catch ex As Exception
            Throw New Exception("doDB.addObjectTablesToDataset: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

    Public Shared Sub addObjectDataToDataset(ByVal dsToAdd As System.Data.DataSet, ByVal IDObject As Integer,
                                          ByVal tableNameObject As String, ByVal tableNameAdress As String, ByVal addAdressData As Boolean)
        Try
            Dim sqlObjects1 As New sqlObjects
            Dim dsObjectUsr As New dsObjects()
            dsObjectUsr.Clear()
            sqlObjects1.initControl()

            Dim rNewUsr As dsObjects.tblObjectRow = dsToAdd.Tables(tableNameObject).NewRow()
            rNewUsr.ItemArray = sqlObjects1.getObjectRow(IDObject, sqlObjects.eTypSelObj.ID).ItemArray
            dsToAdd.Tables(tableNameObject).Rows.Add(rNewUsr)

        Catch ex As Exception
            Throw New Exception("doDB.addObjectDataToDataset: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

    Public Shared Sub addParticipantTableToDataset(ByVal dsToAdd As System.Data.DataSet)
        Try
            Dim tParticipant As New license.dsLicense.ParticipantDataTable()
            If Not dsToAdd.Tables.Contains(tParticipant.TableName) Then
                dsToAdd.Tables.Add(tParticipant)
            End If

        Catch ex As Exception
            Throw New Exception("doDB.addParticipantTableToDataset: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

    Public Shared Sub addParticipantDataToDataset(ByVal dsToAdd As System.Data.DataSet)
        Try
            Dim tParticipant As New license.dsLicense.ParticipantDataTable()
            Dim rNewParticipant As license.dsLicense.ParticipantRow = dsToAdd.Tables(tParticipant.TableName).NewRow()
            rNewParticipant.ItemArray = license.doLicense.rParticipant.ItemArray
            dsToAdd.Tables(tParticipant.TableName).Rows.Add(rNewParticipant)

        Catch ex As Exception
            Throw New Exception("doDB.addParticipantDataToDataset: " + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub

End Class
