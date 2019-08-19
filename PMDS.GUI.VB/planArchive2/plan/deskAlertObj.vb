Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinExplorerBar



Public Class deskAlertObj

    Public gen As New General
    Public info As New Infragistics.Win.Misc.UltraDesktopAlert
    Public ret As Infragistics.Win.Misc.UltraDesktopAlertWindowInfo


    Private popupMenuTool As PopupMenuTool = Nothing
    Private IDObject As New System.Guid

    Public delonOpenEinträge As onOpenEinträge
    Public Delegate Sub onOpenEinträge()


    Public typ As New eTyp
    Public Enum eTyp
        schnellnotiz = 0
    End Enum

    Public dropDownButton As Infragistics.Win.Misc.UltraDropDownButton







    Private Sub contDesktopAlert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Function showInfo(ByVal caption As String, ByVal txt As String, _
                            ByVal popupMenuTool As PopupMenuTool, ByVal IDObject As System.Guid, _
                            ByVal html As Boolean, ByVal typ As eTyp) As Boolean
        Try
            Me.ImageList1.Images.Clear()
            Me.ImageList1.Images.Add(QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32))
            Me.ImageList1.Images.Add(QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32))


            Me.IDObject = IDObject
            Me.typ = typ

            If Me.typ = eTyp.schnellnotiz Then
                If Not popupMenuTool Is Nothing Then
                    Me.popupMenuTool = popupMenuTool
                    Me.info.DropDownButtonVisible = DefaultableBoolean.True
                Else
                    Me.info.DropDownButtonVisible = DefaultableBoolean.False
                End If
                Me.info.AutoClose = DefaultableBoolean.False
                Me.info.Style = DesktopAlertStyle.Office2007
                Me.info.AutoClose = DefaultableBoolean.True
                Me.info.AutoCloseDelay = 15000
                Me.info.MultipleWindowDisplayStyle = MultipleWindowDisplayStyle.Tiled

                Dim winInfo As New Infragistics.Win.Misc.UltraDesktopAlertShowWindowInfo
                AddHandler Me.info.DesktopAlertLinkClicked, AddressOf Me.OnLinkClicked
                AddHandler Me.info.DesktopAlertClosing, AddressOf Me.OnDesktopAlertClosing
                AddHandler Me.info.AlertButtonClicked, AddressOf Me.OnAlertButtonClicked
                AddHandler Me.info.DropDownButtonClicked, AddressOf Me.OnDropDownButtonClicked
                If Not Me.popupMenuTool Is Nothing Then
                    AddHandler Me.popupMenuTool.ToolbarsManager.ToolClick, AddressOf Me.OnToolClick
                    AddHandler Me.info.DropDownButtonClicked, AddressOf Me.OnDropDownButtonClicked
                End If
                winInfo.Image = Me.ImageList1.Images(1)
                winInfo.Caption = caption
                winInfo.Text = txt
                winInfo.Sound = Me.getSound

                Me.showButtonsAllert()
                'winInfo.Pinned = False

                Me.info.AnimationStyleShow = AnimationStyle.Fade
                Me.info.AnimationStyleAutoClose = AnimationStyle.Fade

                Me.info.Show(winInfo)
            End If

        Catch ex As Exception
            Throw New Exception("deskAlertObj.showInfo: " + ex.ToString())
        End Try
    End Function

    Private ReadOnly Property getSound() As System.IO.Stream
        Get
            Dim resourceName As String = "S2Notizen.ATTENTION.WAV"
            Dim thisExe As System.Reflection.Assembly
            thisExe = System.Reflection.Assembly.GetExecutingAssembly()
            Return thisExe.GetManifestResourceStream(resourceName)
        End Get
    End Property
    Public Sub showButtonsAllert()
        Try
            If Not Me.info.AlertButtons.Exists("schließen") Then
                Dim deleteButton As UltraDesktopAlertButton = Me.info.AlertButtons.Add("schließen")
                deleteButton.ToolTipText = doUI.getRes("CloseEntry")
                deleteButton.Appearance.Image = Me.ImageList1.Images(0)

                'Dim öffnenButton As UltraDesktopAlertButton = Me.info.AlertButtons.Add("öffnen")
                'öffnenButton.ToolTipText = "Notiz öffnen"
                'öffnenButton.Appearance.Image = Me.ImageList1.Images(1)
            End If

        Catch ex As Exception
            Throw New Exception("deskAlertObj.showButtonsAllert: " + ex.ToString())
        End Try
    End Sub
    Private Sub OnLinkClicked(ByVal sender As Object, ByVal e As DesktopAlertLinkClickedEventArgs)
        Try
            If e.LinkType = DesktopAlertLinkType.Caption Or e.LinkType = DesktopAlertLinkType.Text Then
                'Dim txt As String = e.WindowInfo.Text
                If Not Me.dropDownButton Is Nothing Then
                    'Me.dropDownButton.DropDown()
                End If
                If Not delonOpenEinträge Is Nothing Then
                    Me.delonOpenEinträge.Invoke()
                End If
            End If

            e.CloseWindow = True

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub OnDesktopAlertClosing(ByVal sender As Object, ByVal e As DesktopAlertClosingEventArgs)
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub OnAlertButtonClicked(ByVal sender As Object, ByVal e As AlertButtonClickedEventArgs)
        Try
            Dim buttonKey As String = e.Button.Key.ToLower()

            Select Case buttonKey

                Case "schließen"
                    If Me.typ = eTyp.schnellnotiz Then
                        e.CloseWindow = True
                    End If

                    'Case "öffnen"
                    '    If Not Me.grpNotizen.Selected Then
                    '        Me.grpNotizen.Selected = True
                    '    End If
                    '    e.CloseWindow = True

                Case Else
                    e.CloseWindow = False

            End Select

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub OnReminderDue(ByVal sender As Object)
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub OnDropDownButtonClicked(ByVal sender As Object, ByVal e As DropDownButtonClickedEventArgs)
        Try
            '  Store a reference to the UltraDesktopAlertWindowInfo in
            '  the popupMenuTool's Tag property, which we can use in the
            '  ToolClick event handler.
            'Me.popupMenuTool.Tag = e.WindowInfo

            ''  Get the screen location of the dropdown button's lower right corner
            ''  this is where we will display the PopupMenuTool.
            'Dim buttonRect As Rectangle = e.ButtonScreenRect
            'Dim screenLocation As Point = buttonRect.Location
            'screenLocation.Offset(buttonRect.Width, buttonRect.Height)

            ''  Show the popup menu tool at the lower right corner of the dropdown button,
            ''  using the DesktopAlertWindow control as the owner, and the button's bounds
            ''  as the exclusion rectangle.
            'Me.popupMenuTool.ShowPopup(screenLocation, buttonRect, DropDownPosition.BelowExclusionRect, e.WindowInfo.DesktopAlertWindow)

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub OnToolClick(ByVal sender As Object, ByVal e As ToolClickEventArgs)
        Try
            Select Case e.Tool.Key
                Case ""

            End Select

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub

End Class
