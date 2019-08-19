<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputPwdHour
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblEnterPwd = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPwdEntered = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ultraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.txtPwdEntered, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEnterPwd
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.lblEnterPwd.Appearance = Appearance1
        Me.lblEnterPwd.Location = New System.Drawing.Point(0, 16)
        Me.lblEnterPwd.Name = "lblEnterPwd"
        Me.lblEnterPwd.Size = New System.Drawing.Size(72, 18)
        Me.lblEnterPwd.TabIndex = 0
        Me.lblEnterPwd.Tag = "ResID.Password"
        Me.lblEnterPwd.Text = "Passwort"
        '
        'txtPwdEntered
        '
        Me.txtPwdEntered.Location = New System.Drawing.Point(75, 13)
        Me.txtPwdEntered.Name = "txtPwdEntered"
        Me.txtPwdEntered.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwdEntered.Size = New System.Drawing.Size(168, 21)
        Me.txtPwdEntered.TabIndex = 0
        '
        'ultraStatusBar1
        '
        Appearance2.FontData.SizeInPoints = 7.0!
        Me.ultraStatusBar1.Appearance = Appearance2
        Me.ultraStatusBar1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.ultraStatusBar1.Location = New System.Drawing.Point(0, 58)
        Me.ultraStatusBar1.Name = "ultraStatusBar1"
        Appearance3.BorderColor = System.Drawing.Color.White
        Me.ultraStatusBar1.PanelAppearance = Appearance3
        UltraStatusPanel1.Key = "time"
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        Me.ultraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.ultraStatusBar1.Size = New System.Drawing.Size(256, 14)
        Me.ultraStatusBar1.TabIndex = 11
        Me.ultraStatusBar1.UseAppStyling = False
        Me.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Standard
        '
        'btnOK
        '
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnOK.Appearance = Appearance4
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(220, 35)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(23, 21)
        Me.btnOK.TabIndex = 2
        '
        'btnAbort
        '
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnAbort.Appearance = Appearance5
        Me.btnAbort.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbort.Location = New System.Drawing.Point(151, 35)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(69, 21)
        Me.btnAbort.TabIndex = 1
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'frmInputPwdHour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(256, 72)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.ultraStatusBar1)
        Me.Controls.Add(Me.txtPwdEntered)
        Me.Controls.Add(Me.lblEnterPwd)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputPwdHour"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PMDS - Passworteingabe"
        CType(Me.txtPwdEntered, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEnterPwd As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtPwdEntered As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents ultraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Private WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
