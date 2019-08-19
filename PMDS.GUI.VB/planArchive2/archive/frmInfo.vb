

Public Class frmInfo
    Inherits System.Windows.Forms.Form

    Public gen As New General



#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Public WithEvents TextInfoDatei2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.TextInfoDatei2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        CType(Me.TextInfoDatei2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextInfoDatei2
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.TextInfoDatei2.Appearance = Appearance1
        Me.TextInfoDatei2.BackColor = System.Drawing.Color.White
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.UltraGridBagLayoutManager1.SetGridBagConstraint(Me.TextInfoDatei2, GridBagConstraint1)
        Me.TextInfoDatei2.Location = New System.Drawing.Point(5, 5)
        Me.TextInfoDatei2.Multiline = True
        Me.TextInfoDatei2.Name = "TextInfoDatei2"
        Me.UltraGridBagLayoutManager1.SetPreferredSize(Me.TextInfoDatei2, New System.Drawing.Size(150, 206))
        Me.TextInfoDatei2.Size = New System.Drawing.Size(669, 362)
        Me.TextInfoDatei2.TabIndex = 1
        '
        'UltraGridBagLayoutManager1
        '
        Me.UltraGridBagLayoutManager1.ContainerControl = Me
        Me.UltraGridBagLayoutManager1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutManager1.ExpandToFitWidth = True
        '
        'frmInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(679, 372)
        Me.Controls.Add(Me.TextInfoDatei2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Information zum Dokument"
        CType(Me.TextInfoDatei2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region




    Private Sub frmInfoDoku_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.Text = doUI.getRes("InformationAboutTheDocument")

            Me.TextInfoDatei2.SelectionStart = 0
            Me.TextInfoDatei2.SelectionLength = 0

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub InfoDatei_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub TextInfoDatei2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextInfoDatei2.KeyPress
        Try
            e.Handled = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
