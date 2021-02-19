


Public Class BaseButton

    Public doBaseElements1 As New doBaseElements()
    Public IsLoaded As Boolean = False
    Public rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public IDRes As String = ""
    'Public IDResStandardControl As String = ""

    Public _IsStandardControl As Boolean = False

    Public compLayout1 As QS2.core.vb.compLayout = Nothing
    Public cLayoutManager1 As QS2.core.vb.cLayoutManager = Nothing
    Public ControlIsLoaded As Boolean = False

    Public _AutoWorkLayout As Boolean = False

    Public DoIDResAuto As Boolean = True







    Private Sub BaseButton_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            Me.doVisible()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Public Sub doVisible()
        Try
            Me.initControl()
            If Not Me.IsStandardControl Then
                Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Me.contextMenuStrip1, Me.IsLoaded, rRes, True, Me.IsStandardControl, Me.DoIDResAuto,
                                                       System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
            Else
                Dim str As String = ""
            End If

        Catch ex As Exception
            Throw New Exception("BaseButton.doVisible: " + ex.ToString())
        End Try
    End Sub

    Private Sub BaseButton_BindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        'Dim sTypeParent As String = Me.GetType().Name.ToString().Trim()
        'If sTypeParent.Trim().ToLower().Contains(("ucButton").Trim().ToLower()) Then
        '    Me.NoImageForButton = True
        'End If
    End Sub
    Private Sub BaseButton_ControlAdded(sender As Object, e As Windows.Forms.ControlEventArgs) Handles MyBase.ControlAdded

    End Sub
    Private Sub BaseButton_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint

    End Sub
    Private Sub BaseButton_ParentChanged(sender As Object, e As EventArgs) Handles MyBase.ParentChanged
    End Sub

    Public Property IsStandardControl() As Boolean
        Get
            Return Me._IsStandardControl
        End Get
        Set(value As Boolean)
            Me._IsStandardControl = value
        End Set
    End Property
    Public ReadOnly Property setStandardControl(IDResStandardControl As String, IsQuickFilter As Boolean) As Boolean
        Get
            Me.doBaseElements1.InfoControl._IsQuickFilter = IsQuickFilter
            If Not Me.doBaseElements1.InfoControl._IsQuickFilter Then
                Me.IDRes = IDResStandardControl
                'Me.IsLoaded = False
                Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Me.contextMenuStrip1, Me.IsLoaded, rRes, True, True, Me.DoIDResAuto,
                                                       System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
            Else
                Dim str As String = ""
            End If
            Return True
        End Get
    End Property

    Private Sub BaseButton_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try
            Me.doBaseElements1.CheckMouseEnter(sender, e, Me.IDRes)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub BaseButton_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Try
            Me.DoLayoutGrid()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Public Sub DoLayoutGrid()
        Try
            Me.initControl()
            If Not Me.doBaseElements1.InfoControl.LastLoadedLayout.IsLoaded And Me.AutoWorkLayout Then
                Dim LayoutFound As Boolean = False
                If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Runtime Then
                    compLayout1.doLayoutGrid(Me.doBaseElements1.InfoControl.grid, Me.IDRes.Trim(), Nothing, LayoutFound, True, Not ENV._IntDeactivated, ENV._AutoAddNewRessources)
                    QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(Me.doBaseElements1.InfoControl.grid)
                End If
                Me.doBaseElements1.InfoControl.LastLoadedLayout.IsLoaded = True
            End If

        Catch ex As Exception
            Throw New Exception("BaseButton.DoLayoutGrid: " + ex.ToString())
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
            Throw New Exception("BaseButton.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Property AutoWorkLayout() As Boolean
        Get
            Return Me._AutoWorkLayout
        End Get
        Set(value As Boolean)
            Me._AutoWorkLayout = value
        End Set
    End Property

End Class
