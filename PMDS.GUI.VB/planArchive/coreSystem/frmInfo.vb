Imports System.Windows.Forms



Public Class Info
    Inherits System.Windows.Forms.Form


    Private gen As New GeneralArchiv
    Private Time As Integer
    Private bClose As Boolean
    Private ITimeToShow As Integer


    Friend WithEvents PanelPicture As System.Windows.Forms.Panel
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents LabelInfoAction As System.Windows.Forms.Label


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        Me.Visible = False
        Me.TopMost = True
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
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Info))
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.LabelInfoAction = New System.Windows.Forms.Label()
        Me.PanelPicture = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelInfo.SuspendLayout()
        Me.PanelPicture.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(5, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PanelInfo
        '
        Me.PanelInfo.Controls.Add(Me.LabelInfoAction)
        Me.PanelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelInfo.Location = New System.Drawing.Point(36, 0)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(213, 27)
        Me.PanelInfo.TabIndex = 4
        '
        'LabelInfoAction
        '
        Me.LabelInfoAction.AutoSize = True
        Me.LabelInfoAction.BackColor = System.Drawing.Color.White
        Me.LabelInfoAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelInfoAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfoAction.ForeColor = System.Drawing.Color.Black
        Me.LabelInfoAction.Location = New System.Drawing.Point(6, 5)
        Me.LabelInfoAction.Name = "LabelInfoAction"
        Me.LabelInfoAction.Size = New System.Drawing.Size(52, 13)
        Me.LabelInfoAction.TabIndex = 0
        Me.LabelInfoAction.Text = "Gesichert"
        Me.LabelInfoAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelPicture
        '
        Me.PanelPicture.Controls.Add(Me.PictureBox1)
        Me.PanelPicture.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelPicture.Location = New System.Drawing.Point(0, 0)
        Me.PanelPicture.Name = "PanelPicture"
        Me.PanelPicture.Size = New System.Drawing.Size(36, 27)
        Me.PanelPicture.TabIndex = 3
        '
        'Info
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(249, 27)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelInfo)
        Me.Controls.Add(Me.PanelPicture)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Info"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelInfo.ResumeLayout(False)
        Me.PanelInfo.PerformLayout()
        Me.PanelPicture.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region





    Private Sub InfoAction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Info, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub showInfo(ByVal TimerOn As Boolean, ByVal TimeToShow As Integer, ByRef oParent As Form, _
                                               ByVal txt As String)
        Try

            'If txt = "" Then Me.LabelInfoAction.Text = "Gesichert"
            'Me.SetPosition(oParent)
            'Me.CheckTimer(TimerOn, TimeToShow)

        Catch ex As Exception
            Throw New Exception("showInfo: " + ex.ToString())
        End Try
    End Sub
    Public Sub CloseInfoAction()
        Try
            Me.Visible = False

        Catch ex As Exception
            Throw New Exception("CloseInfoAction: " + ex.ToString())
        End Try
    End Sub

    Private Sub CheckTimer(ByVal TimerOn As Boolean, ByVal TimeToShow As Integer)
        Try

            If TimerOn Then
                ITimeToShow = TimeToShow
                Time = 0
                Timer.Enabled = True
            Else
                Time = 0
                ITimeToShow = 0
                Timer.Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception("CheckTimer: " + ex.ToString())
        End Try
    End Sub
    Public Sub SetPosition(ByRef oParent As Form)
        Try
            Me.Visible = True
            Me.TopMost = True
            Me.Top = oParent.Top + ((oParent.Height / 2) - (Me.Height / 2))
            Me.Left = oParent.Left + ((oParent.Width / 2) - (Me.Width / 2))
            Me.setSize()
            Me.Refresh()

        Catch ex As Exception
            Throw New Exception("SetPosition: " + ex.ToString())
        End Try
    End Sub

    Public Sub setSize()
        Try
            Me.PanelInfo.Width = Me.LabelInfoAction.Width
            Me.Width = Me.PanelPicture.Width + Me.LabelInfoAction.Width + 20

        Catch ex As Exception
            Throw New Exception("setSize: " + ex.ToString())
        End Try
    End Sub

End Class
