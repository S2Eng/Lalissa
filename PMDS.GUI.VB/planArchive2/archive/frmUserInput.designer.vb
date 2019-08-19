<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserInput
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("EditSelList")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.txtName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkAutoObjectName = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.cboDocumentNames = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoObjectName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumentNames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAbort
        '
        Me.btnAbort.BackColorInternal = System.Drawing.Color.White
        Me.btnAbort.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance1.FontData.BoldAsString = "False"
        Me.btnAbort.HotTrackAppearance = Appearance1
        Me.btnAbort.Location = New System.Drawing.Point(270, 82)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Padding = New System.Drawing.Size(2, 0)
        Me.btnAbort.Size = New System.Drawing.Size(78, 25)
        Me.btnAbort.TabIndex = 6
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.BackColorInternal = System.Drawing.Color.White
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.FontData.BoldAsString = "False"
        Me.btnOK.HotTrackAppearance = Appearance2
        Me.btnOK.Location = New System.Drawing.Point(203, 82)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(2, 0)
        Me.btnOK.Size = New System.Drawing.Size(66, 25)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Tag = "ResID.Ok"
        Me.btnOK.Text = "OK"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(146, 20)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(395, 21)
        Me.txtName.TabIndex = 0
        '
        'UltraLabel1
        '
        Appearance3.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(4, 24)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(138, 14)
        Me.UltraLabel1.TabIndex = 6
        Me.UltraLabel1.Tag = "ResID.DocumentTitle"
        Me.UltraLabel1.Text = "Bezeichnung Dokumente"
        '
        'chkAutoObjectName
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.chkAutoObjectName.Appearance = Appearance4
        Me.chkAutoObjectName.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoObjectName.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAutoObjectName.Location = New System.Drawing.Point(146, 47)
        Me.chkAutoObjectName.Name = "chkAutoObjectName"
        Me.chkAutoObjectName.Size = New System.Drawing.Size(395, 18)
        Me.chkAutoObjectName.TabIndex = 2
        Me.chkAutoObjectName.Tag = "ResID.AddObjectNameToDocumentNameAutomatically"
        Me.chkAutoObjectName.Text = "Objekt-Name in Dokumenten-Bezeichnung autom. hinten anfügen"
        Me.chkAutoObjectName.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'cboDocumentNames
        '
        Me.cboDocumentNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackColorDisabled = System.Drawing.Color.White
        Appearance5.BackColorDisabled2 = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboDocumentNames.Appearance = Appearance5
        Me.cboDocumentNames.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboDocumentNames.AutoSize = False
        Me.cboDocumentNames.BackColor = System.Drawing.Color.White
        Me.cboDocumentNames.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        EditorButton1.Key = "EditSelList"
        Me.cboDocumentNames.ButtonsRight.Add(EditorButton1)
        Me.cboDocumentNames.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.cboDocumentNames.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboDocumentNames.ItemAppearance = Appearance6
        Me.cboDocumentNames.Location = New System.Drawing.Point(148, 19)
        Me.cboDocumentNames.Name = "cboDocumentNames"
        Me.cboDocumentNames.Size = New System.Drawing.Size(394, 23)
        Me.cboDocumentNames.TabIndex = 597
        Me.cboDocumentNames.Tag = "AutoFill"
        Me.cboDocumentNames.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.cboDocumentNames.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.cboDocumentNames.Visible = False
        '
        'frmUserInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(557, 113)
        Me.Controls.Add(Me.cboDocumentNames)
        Me.Controls.Add(Me.chkAutoObjectName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Dokumente"
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoObjectName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumentNames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Public WithEvents txtName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents chkAutoObjectName As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public WithEvents cboDocumentNames As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
