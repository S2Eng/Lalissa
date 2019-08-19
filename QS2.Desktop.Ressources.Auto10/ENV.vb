


Public Class ENV

    Public Shared _Application As String = ""
    Public Shared _TypeRessourcesRun As String = ""
    Public Shared _EditGridLayouts As Boolean = False
    Public Shared _ExtendedView As Boolean = False
    Public Shared _ApplicationIsRunning As Boolean = False
    Public Shared _RigthLayoutmanager As Boolean = False
    Public Shared _AdminSecure As Boolean = False
    Public Shared _DoNotShowRessources As Boolean = False
    Public Shared _AutoAddNewRessources As Boolean = False

    Public Shared _IsInitialized As Boolean = False
    Public Shared _IntDeactivated As Boolean = True
    Public Shared _conn2 As System.Data.SqlClient.SqlConnection = Nothing





    Public Shared Function init(ByRef Application As String, ByRef TypeRessourcesRun As String, ExtendedView As Boolean,
                                DoNotShowRessources As Boolean, AutoAddNewRessources As Boolean, IntDeactivated As Boolean, conn As System.Data.SqlClient.SqlConnection) As Boolean
        Try
            ENV._Application = Application
            ENV._TypeRessourcesRun = TypeRessourcesRun
            ENV._ExtendedView = ExtendedView
            ENV._ApplicationIsRunning = True
            ENV._DoNotShowRessources = DoNotShowRessources
            ENV._AutoAddNewRessources = AutoAddNewRessources
            ENV._IntDeactivated = IntDeactivated
            ENV._IsInitialized = True
            ENV._conn2 = conn

            Return True

        Catch ex As Exception
            Throw New Exception("ENV.init: " + ex.ToString())
        End Try
    End Function
    Public Shared Function initRigth(RigthLayoutmanager As Boolean, AdminSecure As Boolean) As Boolean
        Try
            ENV._AdminSecure = AdminSecure
            ENV._RigthLayoutmanager = RigthLayoutmanager
            Return True

        Catch ex As Exception
            Throw New Exception("ENV.init: " + ex.ToString())
        End Try
    End Function

    Public Shared Function setRights(EditGridLayouts As Boolean) As Boolean
        Try
            ENV._EditGridLayouts = EditGridLayouts

            Return True

        Catch ex As Exception
            Throw New Exception("ENV.setRights: " + ex.ToString())
        End Try

    End Function
End Class
