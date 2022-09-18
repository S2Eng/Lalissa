<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivity
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraActivityIndicator1 = New Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblInfo = New Infragistics.Win.Misc.UltraLabel()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraActivityIndicator1
        '
        Me.UltraActivityIndicator1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraActivityIndicator1.AnimationSpeed = 30
        Me.UltraActivityIndicator1.CausesValidation = True
        Me.UltraActivityIndicator1.Location = New System.Drawing.Point(3, 36)
        Me.UltraActivityIndicator1.Name = "UltraActivityIndicator1"
        Me.UltraActivityIndicator1.Size = New System.Drawing.Size(249, 18)
        Me.UltraActivityIndicator1.TabIndex = 594
        Me.UltraActivityIndicator1.TabStop = True
        Me.UltraActivityIndicator1.ViewStyle = Infragistics.Win.UltraActivityIndicator.ActivityIndicatorViewStyle.Aero
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.UltraActivityIndicator1)
        Me.Panel1.Controls.Add(Me.lblInfo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(257, 60)
        Me.Panel1.TabIndex = 595
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblInfo.Appearance = Appearance1
        Me.lblInfo.Location = New System.Drawing.Point(3, 4)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(249, 28)
        Me.lblInfo.TabIndex = 597
        '
        'Timer2
        '
        '
        'frmActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(257, 60)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmActivity"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraActivityIndicator1 As Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblInfo As Infragistics.Win.Misc.UltraLabel
End Class
