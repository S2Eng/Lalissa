Public Class Settings

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
            Settings._Application = Application
            Settings._TypeRessourcesRun = TypeRessourcesRun
            Settings._ExtendedView = ExtendedView
            Settings._ApplicationIsRunning = True
            Settings._DoNotShowRessources = DoNotShowRessources
            Settings._AutoAddNewRessources = AutoAddNewRessources
            Settings._IntDeactivated = IntDeactivated
            Settings._IsInitialized = True
            Settings._conn2 = conn
            Return True

        Catch ex As Exception
            Throw New Exception("Settings.init: " + ex.ToString())
        End Try
    End Function

    Public Shared Function initRigth(RigthLayoutmanager As Boolean, AdminSecure As Boolean) As Boolean
        Try
            Settings._AdminSecure = AdminSecure
            Settings._RigthLayoutmanager = RigthLayoutmanager
            Return True

        Catch ex As Exception
            Throw New Exception("Settings.init: " + ex.ToString())
        End Try
    End Function

    Public Shared Function setRights(EditGridLayouts As Boolean) As Boolean
        Try
            Settings._EditGridLayouts = EditGridLayouts
            Return True

        Catch ex As Exception
            Throw New Exception("Settings.setRights: " + ex.ToString())
        End Try

    End Function
End Class
