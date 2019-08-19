

Public Class BaseDateTimeEditor

    Public doBaseElements1 As New doBaseElements()
    Public IsLoaded As Boolean = False
    Public rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public IDRes As String = ""
    Public DoIDResAuto As Boolean = True

    Public _ownFormat As String = ""
    Public _Maskinput As String = ""







    Private Sub BaseDateTimeEditor_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsLoaded Then
                'Me.FormatString = "dd.MM.yyyy"
                'Me.MaskInput = "dd.mm.yyyy"         '"{LOC}dd.MM.yyyy"
            End If

            Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Me.contextMenuStrip1, Me.IsLoaded, rRes, True, False, Me.DoIDResAuto, DesignMode)
            doBaseElements.SetRightContextMenü(Me)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub BaseDateTimeEditor_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try
            Me.doBaseElements1.CheckMouseEnter(sender, e, Me.IDRes)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub



    Public Property ownFormat() As String
        Get
            Return Me._ownFormat
        End Get
        Set
            Me._ownFormat = Value
        End Set
    End Property

    Public Property ownMaskInput() As String
        Get
            Return Me._Maskinput
        End Get
        Set
            Me._Maskinput = Value
        End Set
    End Property


End Class

