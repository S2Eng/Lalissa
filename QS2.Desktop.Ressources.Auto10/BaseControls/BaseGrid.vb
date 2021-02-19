

Public Class BaseGrid

    Public doBaseElements1 As New doBaseElements()
    Public IsLoaded As Boolean = False
    Public rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public IDRes As String = ""
    Public DoIDResAuto As Boolean = True

    Public compLayout1 As QS2.core.vb.compLayout = Nothing
    'Public cLayoutManager2 As cLayoutManager = Nothing
    Public cLayoutManager1 As QS2.core.vb.cLayoutManager = Nothing
    Public ControlIsLoaded As Boolean = False
 
    Public _AutoWork As Boolean = True






    Private Sub BaseGrid_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Runtime And Me.AutoWork Then
                Me.doVisibleChanged()
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Public Sub doVisibleChanged()
        Try
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Runtime And ENV._ApplicationIsRunning Then
                Me.initControl()

                Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Me.contextMenuStrip1, Me.IsLoaded, rRes, True, True, Me.DoIDResAuto,
                                                       System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
                Me.DoLayoutGrid()
                doFormatDateTime(Me)
            Else
                Dim str As String = ""
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Public Shared Sub doFormatDateTime(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            'For Each band As Infragistics.Win.UltraWinGrid.UltraGridBand In grid.DisplayLayout.Bands
            '    For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In band.Columns
            '        If col.DataType.Name.ToString().Trim().ToLower().Equals(("DateTime").Trim().ToLower()) Then
            '            col.Format = "dd.MM.yyyy HH:mm"
            '            col.MaskInput = "dd.MM.yyyy HH:mm"
            '        End If
            '        If col.DataType.Name.ToString().Trim().ToLower().Equals(("Date").Trim().ToLower()) Then
            '            col.Format = "dd.MM.yyyy"
            '            col.MaskInput = "dd.MM.yyyy"
            '        End If

            '        If col.Style <> Infragistics.Win.UltraWinGrid.ColumnStyle.Default Then
            '            If col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime Then
            '                col.Format = "dd.MM.yyyy HH:mm"
            '                col.MaskInput = "dd.MM.yyyy HH:mm"
            '            End If
            '            If col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date Then
            '                col.Format = "dd.MM.yyyy"
            '                col.MaskInput = "dd.MM.yyyy"
            '            End If
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            Throw New Exception("doFormatDateTime: " + ex.ToString())
        End Try
    End Sub

    Private Sub BaseGrid_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try
            Me.initControl()
            Me.doBaseElements1.CheckMouseEnter(sender, e, Me.IDRes)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Public Sub DoLayoutGrid()
        Try
            If Me.Visible And Me.AutoWork Then
                Me.initControl()
                If Not Me.doBaseElements1.InfoControl.LastLoadedLayout.IsLoaded Then
                    Dim LayoutFound As Boolean = False
                    If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Runtime Then
                        Dim cLayoutManager1 As New QS2.Desktop.ControlManagment.cLayoutManager2()
                        cLayoutManager1.doLayoutGrid(Me, Me.IDRes.Trim(), Nothing, LayoutFound, True, Not ENV._IntDeactivated, ENV._AutoAddNewRessources)
                        'compLayout1.doLayoutGrid(Me, Me.IDRes.Trim(), Nothing, LayoutFound, True, Not ENV._IntDeactivated, ENV._AutoAddNewRessources)
                        QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(Me)
                    End If
                    Me.doBaseElements1.InfoControl.LastLoadedLayout.IsLoaded = True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("BaseGrid.DoLayoutGrid: " + ex.ToString())
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

    Public Property AutoWork() As Boolean
        Get
            Return Me._AutoWork
        End Get
        Set(value As Boolean)
            Me._AutoWork = value
        End Set
    End Property

End Class
