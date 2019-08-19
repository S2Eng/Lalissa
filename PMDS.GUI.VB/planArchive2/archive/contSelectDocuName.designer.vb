<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelectDocuName
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("EditSelList")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.cboDocumentNames = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblSelectDocuName = New Infragistics.Win.Misc.UltraLabel()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddNameToDocumentNameList = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumentNames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'cboDocumentNames
        '
        Me.cboDocumentNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackColorDisabled = System.Drawing.Color.White
        Appearance1.BackColorDisabled2 = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboDocumentNames.Appearance = Appearance1
        Me.cboDocumentNames.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboDocumentNames.AutoSize = False
        Me.cboDocumentNames.BackColor = System.Drawing.Color.White
        Me.cboDocumentNames.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        EditorButton1.Key = "EditSelList"
        Me.cboDocumentNames.ButtonsRight.Add(EditorButton1)
        Me.cboDocumentNames.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.cboDocumentNames.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboDocumentNames.ItemAppearance = Appearance2
        Me.cboDocumentNames.Location = New System.Drawing.Point(128, 18)
        Me.cboDocumentNames.Name = "cboDocumentNames"
        Me.cboDocumentNames.Size = New System.Drawing.Size(415, 23)
        Me.cboDocumentNames.TabIndex = 559
        Me.cboDocumentNames.Tag = "AutoFill"
        Me.cboDocumentNames.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.cboDocumentNames.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblSelectDocuName
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BackColor2 = System.Drawing.Color.Transparent
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblSelectDocuName.Appearance = Appearance3
        Me.lblSelectDocuName.Location = New System.Drawing.Point(12, 15)
        Me.lblSelectDocuName.Name = "lblSelectDocuName"
        Me.lblSelectDocuName.Size = New System.Drawing.Size(121, 28)
        Me.lblSelectDocuName.TabIndex = 560
        Me.lblSelectDocuName.Tag = "ResID.SelectDocuNameFromDocuTemplates"
        Me.lblSelectDocuName.Text = "Dokumentname aus Vorlagen auswählen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(207, 58)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 26)
        Me.btnOK.TabIndex = 561
        Me.btnOK.Tag = "ResID.OK"
        Me.btnOK.Text = "OK"
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbort.Location = New System.Drawing.Point(263, 58)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(67, 26)
        Me.btnAbort.TabIndex = 562
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abrechen"
        '
        'btnAddNameToDocumentNameList
        '
        Me.btnAddNameToDocumentNameList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNameToDocumentNameList.Location = New System.Drawing.Point(551, 18)
        Me.btnAddNameToDocumentNameList.Name = "btnAddNameToDocumentNameList"
        Me.btnAddNameToDocumentNameList.Size = New System.Drawing.Size(23, 23)
        Me.btnAddNameToDocumentNameList.TabIndex = 596
        Me.btnAddNameToDocumentNameList.Tag = ""
        '
        'contSelectDocuName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.cboDocumentNames)
        Me.Controls.Add(Me.btnAddNameToDocumentNameList)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.lblSelectDocuName)
        Me.Name = "contSelectDocuName"
        Me.Size = New System.Drawing.Size(587, 90)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumentNames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents lblSelectDocuName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddNameToDocumentNameList As Infragistics.Win.Misc.UltraButton
    Public WithEvents cboDocumentNames As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
