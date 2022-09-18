<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStayUIAsProcess
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.timerStartStayUI = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSetWindowForeground = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'timerStartStayUI
        '
        Me.timerStartStayUI.Enabled = True
        Me.timerStartStayUI.Interval = 3
        '
        'TimerSetWindowForeground
        '
        Me.TimerSetWindowForeground.Interval = 200
        '
        'frmStayUIAsProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 37)
        Me.Name = "frmStayUIAsProcess"
        Me.Text = "QS2 Controlcenter"
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents timerStartStayUI As Windows.Forms.Timer
    Friend WithEvents TimerSetWindowForeground As Windows.Forms.Timer
End Class
