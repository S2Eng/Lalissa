Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports itscont.service.core
Imports System.Data
Imports System.IO



Public Class doService

    Private db1 As New itscont.service.core.dbGlobal()
    Private gen As New General()



    Public Function doLogInService() As Boolean
        itscont.service.core.ENV.doStartUp()
        Me.db1.doConnect()
        Return True
    End Function

End Class
