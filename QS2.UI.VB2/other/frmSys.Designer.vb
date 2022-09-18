<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSys
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
        Me.btnUpdate2018HerbstCheck = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpdate2018Herbst = New Infragistics.Win.Misc.UltraButton()
        Me.lblHerbst2018 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkNurESLog = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lblHerbst2018SP1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnUpdate2018SP1HerbstCheck = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpdate2018SP1Herbst = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnUpdate2020 = New Infragistics.Win.Misc.UltraButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ProgBar2020 = New qs2.core.ProgBar()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.chkNurESLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUpdate2018HerbstCheck
        '
        Me.btnUpdate2018HerbstCheck.Location = New System.Drawing.Point(193, 15)
        Me.btnUpdate2018HerbstCheck.Name = "btnUpdate2018HerbstCheck"
        Me.btnUpdate2018HerbstCheck.Size = New System.Drawing.Size(110, 26)
        Me.btnUpdate2018HerbstCheck.TabIndex = 0
        Me.btnUpdate2018HerbstCheck.Text = "Daten prüfen"
        '
        'btnUpdate2018Herbst
        '
        Me.btnUpdate2018Herbst.Location = New System.Drawing.Point(309, 15)
        Me.btnUpdate2018Herbst.Name = "btnUpdate2018Herbst"
        Me.btnUpdate2018Herbst.Size = New System.Drawing.Size(136, 26)
        Me.btnUpdate2018Herbst.TabIndex = 1
        Me.btnUpdate2018Herbst.Text = "Updates durchführen"
        '
        'lblHerbst2018
        '
        Me.lblHerbst2018.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHerbst2018.Location = New System.Drawing.Point(12, 19)
        Me.lblHerbst2018.Name = "lblHerbst2018"
        Me.lblHerbst2018.Size = New System.Drawing.Size(175, 21)
        Me.lblHerbst2018.TabIndex = 2
        Me.lblHerbst2018.Text = "Release Herbst 2018"
        '
        'chkNurESLog
        '
        Me.chkNurESLog.Checked = True
        Me.chkNurESLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNurESLog.Location = New System.Drawing.Point(462, 18)
        Me.chkNurESLog.Name = "chkNurESLog"
        Me.chkNurESLog.Size = New System.Drawing.Size(173, 20)
        Me.chkNurESLog.TabIndex = 3
        Me.chkNurESLog.Text = "Nur ES-relevante Logeinträge"
        '
        'lblHerbst2018SP1
        '
        Me.lblHerbst2018SP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHerbst2018SP1.Location = New System.Drawing.Point(13, 51)
        Me.lblHerbst2018SP1.Name = "lblHerbst2018SP1"
        Me.lblHerbst2018SP1.Size = New System.Drawing.Size(174, 21)
        Me.lblHerbst2018SP1.TabIndex = 4
        Me.lblHerbst2018SP1.Text = "Release Herbst 2018 SP1"
        '
        'btnUpdate2018SP1HerbstCheck
        '
        Me.btnUpdate2018SP1HerbstCheck.Location = New System.Drawing.Point(193, 47)
        Me.btnUpdate2018SP1HerbstCheck.Name = "btnUpdate2018SP1HerbstCheck"
        Me.btnUpdate2018SP1HerbstCheck.Size = New System.Drawing.Size(110, 26)
        Me.btnUpdate2018SP1HerbstCheck.TabIndex = 5
        Me.btnUpdate2018SP1HerbstCheck.Text = "Daten prüfen"
        '
        'btnUpdate2018SP1Herbst
        '
        Me.btnUpdate2018SP1Herbst.Location = New System.Drawing.Point(309, 47)
        Me.btnUpdate2018SP1Herbst.Name = "btnUpdate2018SP1Herbst"
        Me.btnUpdate2018SP1Herbst.Size = New System.Drawing.Size(136, 26)
        Me.btnUpdate2018SP1Herbst.TabIndex = 6
        Me.btnUpdate2018SP1Herbst.Text = "Updates durchführen"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 78)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(174, 21)
        Me.UltraLabel1.TabIndex = 7
        Me.UltraLabel1.Text = "Release Herbst 2020"
        '
        'btnUpdate2020
        '
        Me.btnUpdate2020.Location = New System.Drawing.Point(309, 79)
        Me.btnUpdate2020.Name = "btnUpdate2020"
        Me.btnUpdate2020.Size = New System.Drawing.Size(136, 26)
        Me.btnUpdate2020.TabIndex = 8
        Me.btnUpdate2020.Text = "Updates durchführen"
        '
        'ProgBar2020
        '
        Me.ProgBar2020.Location = New System.Drawing.Point(458, 78)
        Me.ProgBar2020.Name = "ProgBar2020"
        Me.ProgBar2020.Size = New System.Drawing.Size(176, 26)
        Me.ProgBar2020.TabIndex = 9
        '
        'frmSys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 432)
        Me.Controls.Add(Me.ProgBar2020)
        Me.Controls.Add(Me.btnUpdate2020)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnUpdate2018SP1Herbst)
        Me.Controls.Add(Me.btnUpdate2018SP1HerbstCheck)
        Me.Controls.Add(Me.lblHerbst2018SP1)
        Me.Controls.Add(Me.chkNurESLog)
        Me.Controls.Add(Me.lblHerbst2018)
        Me.Controls.Add(Me.btnUpdate2018Herbst)
        Me.Controls.Add(Me.btnUpdate2018HerbstCheck)
        Me.Name = "frmSys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System- und Wartungsfunktionen"
        CType(Me.chkNurESLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdate2018HerbstCheck As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpdate2018Herbst As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblHerbst2018 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkNurESLog As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents lblHerbst2018SP1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnUpdate2018SP1HerbstCheck As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpdate2018SP1Herbst As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnUpdate2020 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents ProgBar2020 As core.ProgBar
    Friend WithEvents SaveFileDialog2 As Windows.Forms.SaveFileDialog
End Class
