

Public Class BaseTabControl

    Public doBaseElements1 As New doBaseElements()
    Public IsLoaded As Boolean = False

    Public ControlIsLoaded As Boolean = False

    Public rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public IDRes As String = ""
    Public DoIDResAuto As Boolean = True

    Public compLayout1 As QS2.core.vb.compLayout = Nothing
    Public cLayoutManager1 As QS2.core.vb.cLayoutManager = Nothing

    Public _AutoWork As Boolean = True










    Private Sub BaseTabControl_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not DesignMode Then
                Me.doVisibleChanged()
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Public Sub doVisibleChanged()
        Try
            If Not DesignMode And ENV._ApplicationIsRunning Then
                Me.initControl()
                Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Nothing, Me.IsLoaded, rRes, True, False, Me.DoIDResAuto, DesignMode)
            Else
                Dim str As String = ""
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub BaseGrid_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try
            Me.initControl()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Public Sub initControl()
        Try
            If Not Me.ControlIsLoaded Then
                If Me.compLayout1 Is Nothing Then
                    Me.compLayout1 = New core.vb.compLayout()
                    Me.compLayout1.initControl()
                End If
                If Me.cLayoutManager1 Is Nothing Then
                    Me.cLayoutManager1 = New core.vb.cLayoutManager()
                End If
                Me.ControlIsLoaded = True
            End If

        Catch ex As Exception
            Throw New Exception("BaseGrid.initControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub BaseTabControl_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try
            If UI.IsKeyPressed(Windows.Forms.Keys.F1) Then
                'Me.doBaseElements1.ShowInControlDesigner(Me.IDRes)
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
End Class
