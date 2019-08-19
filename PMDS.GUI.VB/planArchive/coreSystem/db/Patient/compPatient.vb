Imports RBU



Public Class compPatient


    Public Function getPatientendaten(ByVal IDPatient As System.Guid) As dsPatientInfo

        Dim db As New db
        Dim data As New dsPatientInfo
        Me.daPatientByID.SelectCommand.Connection = db.getConnDB
        Me.daPatientByID.SelectCommand.Parameters(0).Value = IDPatient
        Me.daPatientByID.Fill(data)
        Return data

    End Function


End Class
