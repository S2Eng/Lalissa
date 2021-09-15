


Public Class doBaseElements

    Public ControlManagment1 As New qs2.Desktop.ControlManagment.ControlManagment()

    Public InfoControl As New cInfoControl()
    Public Class cInfoControl
        Public LastLoadedLayout As New QS2.core.vb.compLayout.cLoadedLayout()
        Public _IsQuickFilter As Boolean = False
        Public SaveLastQuickfilter As Boolean = False
        Public grid As BaseGrid = Nothing
        Public defaultLayoutNamexy As String = ""
        Public QuickFilterKey As String = ""
        Public KeyLayoutFromQuickfilter As String = ""

        Public dGetLastClickedQuickfilter As GetLastClickedQuickfilter
        Public Delegate Function GetLastClickedQuickfilter() As retGetQuickfilter

        Public IDQuickfilterToSave As System.Guid = Nothing

        Public Class retGetQuickfilter
            Public LastClickedQuickfilter As String = ""
            Public NameDefaultQuickfilter As String = ""
            Public IDQuickFilterToSave As System.Guid = Nothing
        End Class
    End Class







    Public Function runControlManagment(ByRef IDRes As String, cont As System.Windows.Forms.Control, ContextMenuStripNew As System.Windows.Forms.ContextMenuStrip, _
                                          ByRef IsLoaded As Boolean, _
                                          ByRef rRes As QS2.core.language.dsLanguage.RessourcenRow, _
                                          ByRef doContextMenü As Boolean, ByRef IsStandardControl As Boolean, _
                                          ByRef DoIDResAuto As Boolean, bDesignMode As Boolean) As cInfoControl

        Try
            If System.Diagnostics.Process.GetCurrentProcess().ProcessName = "devenv" Then
                Exit Function
            End If

            If Not IsLoaded And qs2.core.ENV.SystemIsInitialized Then
                If TypeOf cont Is Infragistics.Win.UltraWinGrid.UltraGrid Then
                    Dim grd As Infragistics.Win.UltraWinGrid.UltraGrid = cont
                    grd.DisplayLayout.Override.RowSpacingAfter = 2
                    grd.DisplayLayout.Override.RowSpacingBefore = 2
                    grd.DisplayLayout.Override.DefaultRowHeight = 18
                    'grd.DisplayLayout.Appearance.FontData.SizeInPoints = 12
                    'grd.DisplayLayout.Override.CellAppearance.FontData.SizeInPoints = 12

                    For Each bnd As Infragistics.Win.UltraWinGrid.UltraGridBand In grd.DisplayLayout.Bands
                        bnd.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.None
                    Next
                End If

                Dim ContextMenüStripToTake As System.Windows.Forms.ContextMenuStrip = Nothing
                If QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.DesktopManagement.ToString().Trim().ToLower()) Then
                    If cont.ContextMenuStrip Is Nothing Then
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                    Else
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                        'ContextMenüStripToTake = cont.ContextMenuStrip
                    End If

                ElseIf QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.ProductiveFull.ToString().Trim().ToLower()) Then
                    If cont.ContextMenuStrip Is Nothing Then
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                    Else
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                        'ContextMenüStripToTake = cont.ContextMenuStrip
                    End If

                ElseIf QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.ProductiveSmall.ToString().Trim().ToLower()) Then
                    If cont.ContextMenuStrip Is Nothing Then
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                    Else
                        cont.ContextMenuStrip = ContextMenuStripNew
                        ContextMenüStripToTake = cont.ContextMenuStrip
                        'ContextMenüStripToTake = cont.ContextMenuStrip
                    End If

                ElseIf QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.Off.ToString().Trim().ToLower()) Then
                    Exit Function
                Else
                    Throw New Exception("doBaseElements.runControlManagment: ENV._TypeRessourcesRun.Trim() '" + qs2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim() + "' not supported!")
                End If

                Dim bControlIsDone As Integer = -1
                Dim rActControl As qs2.Desktop.ControlManagment.dsControls.ControlsRow = Nothing
                Dim Description As String = ""
                Dim TxtEnglish As String = ""
                Dim TxtGerman As String = ""

                Me.ControlManagment1.doControl(IDRes, Description, cont, Nothing,
                                        qs2.Desktop.ControlManagment.ControlManagment.eControlGroup.MainSystem,
                                        bControlIsDone, rActControl, ContextMenüStripToTake, qs2.core.Enums.eResourceType.Label, _
                                        TxtEnglish, TxtGerman, rRes, doContextMenü, IsStandardControl, _
                                        Me.InfoControl, DoIDResAuto, ENV._ExtendedView)

                IsLoaded = True
            End If

        Catch ex As Exception
            Throw New Exception("doBaseElements.runControlManagment: " + ex.ToString())
        End Try
    End Function

    Public Sub CheckMouseEnter(sender As Object, e As EventArgs, IDRes As String)
        Try
            If Not QS2.Desktop.ControlManagment.ControlManagment.frmDesigner Is Nothing Then
                If QS2.Desktop.ControlManagment.ControlManagment.frmDesigner.Visible Then
                    If UI.IsKeyPressed(Windows.Forms.Keys.F3) Then
                        QS2.Desktop.ControlManagment.ControlManagment.LoadControlDesigner(IDRes)
                    End If
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub


    Public Sub runControlManagmentBaseGridManual(grid As Infragistics.Win.UltraWinGrid.UltraGrid, NameDefaultLayout As String)
        Try
            Dim baseGrid As QS2.Desktop.ControlManagment.BaseGrid = grid

            Dim DoIDResAuto As Boolean = False
            baseGrid.rRes = Nothing
            baseGrid.IDRes = grid.Name.ToString().Trim()
            baseGrid.IsLoaded = False
            Dim IsStandardControl As Boolean = False
            Dim doContextMenü As Boolean = True
            baseGrid.contextMenuStrip1.Items.Clear()
            baseGrid.doBaseElements1.InfoControl.defaultLayoutNamexy = NameDefaultLayout.Trim()
            Me.runControlManagment(baseGrid.IDRes, grid, baseGrid.contextMenuStrip1,
                                                                       baseGrid.IsLoaded, baseGrid.rRes, doContextMenü,
                                                                       IsStandardControl, DoIDResAuto, False)

        Catch ex As Exception
            Throw New Exception("doBaseElements.runControlManagmentBaseGrid: " + ex.ToString())
        End Try
    End Sub

    Public Shared Sub SetRightContextMenü(ByRef cont As System.Windows.Forms.Control)
        Try
            If QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.ProductiveSmall.ToString().Trim().ToLower()) Or _
                QS2.Desktop.ControlManagment.ENV._TypeRessourcesRun.Trim().ToLower().Equals(QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.Off.ToString().Trim().ToLower()) Then
                cont.ContextMenuStrip = Nothing
            Else
                If Not ENV._AdminSecure Then
                    cont.ContextMenuStrip = Nothing
                End If
                Dim str As String = ""
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

End Class
