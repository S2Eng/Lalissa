

Public Class tools


    Public ReadOnly Property dat235959(ByVal dat As Date) As Date
        Get
            Return New Date(dat.Year, dat.Month, dat.Day, 23, 59, 59)
        End Get
    End Property

End Class
