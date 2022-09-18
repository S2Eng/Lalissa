<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contLayout
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblLayoutName = New Infragistics.Win.Misc.UltraLabel()
        Me.txtLayoutName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udteCreateAt = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtCreateFrom = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCreateAt = New Infragistics.Win.Misc.UltraLabel()
        Me.lblCreateFrom = New Infragistics.Win.Misc.UltraLabel()
        Me.chkAllUsers = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtKey = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblKey = New Infragistics.Win.Misc.UltraLabel()
        Me.grpLayoutDetail = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cboAutoFitStyleGrid = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceGridRowMaxHeigth = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.uceGridRowMinHeigth = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.lblAutoFitStyleGrid = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGridRowMaxHeigth = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGridRowMinHeigth = New Infragistics.Win.Misc.UltraLabel()
        Me.chkAutoSizeWidthColumns = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkCaptionVisible = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkShowAlwaysGroupBy = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chkGridAutoNewline = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        CType(Me.txtLayoutName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udteCreateAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAllUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpLayoutDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLayoutDetail.SuspendLayout()
        CType(Me.cboAutoFitStyleGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceGridRowMaxHeigth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceGridRowMinHeigth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoSizeWidthColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCaptionVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowAlwaysGroupBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGridAutoNewline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLayoutName
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.lblLayoutName.Appearance = Appearance1
        Me.lblLayoutName.Location = New System.Drawing.Point(10, 25)
        Me.lblLayoutName.Name = "lblLayoutName"
        Me.lblLayoutName.Size = New System.Drawing.Size(101, 14)
        Me.lblLayoutName.TabIndex = 13
        Me.lblLayoutName.Text = "Name Layout"
        '
        'txtLayoutName
        '
        Me.txtLayoutName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLayoutName.Location = New System.Drawing.Point(105, 22)
        Me.txtLayoutName.Name = "txtLayoutName"
        Me.txtLayoutName.Size = New System.Drawing.Size(510, 21)
        Me.txtLayoutName.TabIndex = 0
        '
        'udteCreateAt
        '
        Me.udteCreateAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Me.udteCreateAt.Appearance = Appearance2
        Me.udteCreateAt.BackColor = System.Drawing.Color.White
        Me.udteCreateAt.FormatString = "dd.MM.yyyy HH:mm:ss"
        Me.udteCreateAt.Location = New System.Drawing.Point(473, 74)
        Me.udteCreateAt.Name = "udteCreateAt"
        Me.udteCreateAt.ReadOnly = True
        Me.udteCreateAt.Size = New System.Drawing.Size(142, 21)
        Me.udteCreateAt.TabIndex = 10
        '
        'txtCreateFrom
        '
        Me.txtCreateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Me.txtCreateFrom.Appearance = Appearance3
        Me.txtCreateFrom.BackColor = System.Drawing.Color.White
        Me.txtCreateFrom.Location = New System.Drawing.Point(473, 98)
        Me.txtCreateFrom.Name = "txtCreateFrom"
        Me.txtCreateFrom.ReadOnly = True
        Me.txtCreateFrom.Size = New System.Drawing.Size(142, 21)
        Me.txtCreateFrom.TabIndex = 11
        '
        'lblCreateAt
        '
        Me.lblCreateAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Me.lblCreateAt.Appearance = Appearance4
        Me.lblCreateAt.Location = New System.Drawing.Point(293, 74)
        Me.lblCreateAt.Name = "lblCreateAt"
        Me.lblCreateAt.Size = New System.Drawing.Size(174, 14)
        Me.lblCreateAt.TabIndex = 19
        Me.lblCreateAt.Text = "Created"
        '
        'lblCreateFrom
        '
        Me.lblCreateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.lblCreateFrom.Appearance = Appearance5
        Me.lblCreateFrom.Location = New System.Drawing.Point(293, 98)
        Me.lblCreateFrom.Name = "lblCreateFrom"
        Me.lblCreateFrom.Size = New System.Drawing.Size(174, 14)
        Me.lblCreateFrom.TabIndex = 20
        Me.lblCreateFrom.Text = "From"
        '
        'chkAllUsers
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.chkAllUsers.Appearance = Appearance6
        Me.chkAllUsers.BackColor = System.Drawing.Color.Transparent
        Me.chkAllUsers.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAllUsers.Location = New System.Drawing.Point(331, 179)
        Me.chkAllUsers.Name = "chkAllUsers"
        Me.chkAllUsers.Size = New System.Drawing.Size(120, 14)
        Me.chkAllUsers.TabIndex = 6
        Me.chkAllUsers.Text = "All users"
        Me.chkAllUsers.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtKey
        '
        Me.txtKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKey.Location = New System.Drawing.Point(105, 122)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(510, 21)
        Me.txtKey.TabIndex = 15
        '
        'lblKey
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.lblKey.Appearance = Appearance15
        Me.lblKey.Location = New System.Drawing.Point(10, 124)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(101, 14)
        Me.lblKey.TabIndex = 103
        Me.lblKey.Text = "Key"
        '
        'grpLayoutDetail
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.grpLayoutDetail.Appearance = Appearance7
        Me.grpLayoutDetail.Controls.Add(Me.cboAutoFitStyleGrid)
        Me.grpLayoutDetail.Controls.Add(Me.uceGridRowMaxHeigth)
        Me.grpLayoutDetail.Controls.Add(Me.uceGridRowMinHeigth)
        Me.grpLayoutDetail.Controls.Add(Me.lblAutoFitStyleGrid)
        Me.grpLayoutDetail.Controls.Add(Me.lblGridRowMaxHeigth)
        Me.grpLayoutDetail.Controls.Add(Me.lblGridRowMinHeigth)
        Me.grpLayoutDetail.Controls.Add(Me.chkAutoSizeWidthColumns)
        Me.grpLayoutDetail.Controls.Add(Me.chkCaptionVisible)
        Me.grpLayoutDetail.Controls.Add(Me.chkShowAlwaysGroupBy)
        Me.grpLayoutDetail.Controls.Add(Me.chkGridAutoNewline)
        Me.grpLayoutDetail.Controls.Add(Me.txtKey)
        Me.grpLayoutDetail.Controls.Add(Me.lblKey)
        Me.grpLayoutDetail.Controls.Add(Me.chkAllUsers)
        Me.grpLayoutDetail.Controls.Add(Me.txtLayoutName)
        Me.grpLayoutDetail.Controls.Add(Me.txtCreateFrom)
        Me.grpLayoutDetail.Controls.Add(Me.udteCreateAt)
        Me.grpLayoutDetail.Controls.Add(Me.lblCreateFrom)
        Me.grpLayoutDetail.Controls.Add(Me.lblCreateAt)
        Me.grpLayoutDetail.Controls.Add(Me.lblLayoutName)
        Me.grpLayoutDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLayoutDetail.Location = New System.Drawing.Point(0, 0)
        Me.grpLayoutDetail.Name = "grpLayoutDetail"
        Me.grpLayoutDetail.Size = New System.Drawing.Size(629, 150)
        Me.grpLayoutDetail.TabIndex = 104
        Me.grpLayoutDetail.Text = "Layout Detail"
        '
        'cboAutoFitStyleGrid
        '
        Me.cboAutoFitStyleGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAutoFitStyleGrid.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboAutoFitStyleGrid.Location = New System.Drawing.Point(473, 50)
        Me.cboAutoFitStyleGrid.Name = "cboAutoFitStyleGrid"
        Me.cboAutoFitStyleGrid.Size = New System.Drawing.Size(142, 21)
        Me.cboAutoFitStyleGrid.TabIndex = 7
        '
        'uceGridRowMaxHeigth
        '
        Me.uceGridRowMaxHeigth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uceGridRowMaxHeigth.Location = New System.Drawing.Point(214, 199)
        Me.uceGridRowMaxHeigth.Name = "uceGridRowMaxHeigth"
        Me.uceGridRowMaxHeigth.Size = New System.Drawing.Size(73, 21)
        Me.uceGridRowMaxHeigth.TabIndex = 9
        Me.uceGridRowMaxHeigth.Visible = False
        '
        'uceGridRowMinHeigth
        '
        Me.uceGridRowMinHeigth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uceGridRowMinHeigth.Location = New System.Drawing.Point(242, 176)
        Me.uceGridRowMinHeigth.Name = "uceGridRowMinHeigth"
        Me.uceGridRowMinHeigth.Size = New System.Drawing.Size(73, 21)
        Me.uceGridRowMinHeigth.TabIndex = 8
        Me.uceGridRowMinHeigth.Visible = False
        '
        'lblAutoFitStyleGrid
        '
        Me.lblAutoFitStyleGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Me.lblAutoFitStyleGrid.Appearance = Appearance8
        Me.lblAutoFitStyleGrid.Location = New System.Drawing.Point(293, 50)
        Me.lblAutoFitStyleGrid.Name = "lblAutoFitStyleGrid"
        Me.lblAutoFitStyleGrid.Size = New System.Drawing.Size(174, 14)
        Me.lblAutoFitStyleGrid.TabIndex = 110
        Me.lblAutoFitStyleGrid.Text = "Auto-fit-style grid"
        '
        'lblGridRowMaxHeigth
        '
        Me.lblGridRowMaxHeigth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Me.lblGridRowMaxHeigth.Appearance = Appearance9
        Me.lblGridRowMaxHeigth.Location = New System.Drawing.Point(34, 202)
        Me.lblGridRowMaxHeigth.Name = "lblGridRowMaxHeigth"
        Me.lblGridRowMaxHeigth.Size = New System.Drawing.Size(174, 14)
        Me.lblGridRowMaxHeigth.TabIndex = 105
        Me.lblGridRowMaxHeigth.Text = "Grid.Row max. Heigth"
        Me.lblGridRowMaxHeigth.Visible = False
        '
        'lblGridRowMinHeigth
        '
        Me.lblGridRowMinHeigth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Me.lblGridRowMinHeigth.Appearance = Appearance10
        Me.lblGridRowMinHeigth.Location = New System.Drawing.Point(62, 179)
        Me.lblGridRowMinHeigth.Name = "lblGridRowMinHeigth"
        Me.lblGridRowMinHeigth.Size = New System.Drawing.Size(174, 14)
        Me.lblGridRowMinHeigth.TabIndex = 104
        Me.lblGridRowMinHeigth.Text = "Grid.Row min. Heigth"
        Me.lblGridRowMinHeigth.Visible = False
        '
        'chkAutoSizeWidthColumns
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoSizeWidthColumns.Appearance = Appearance11
        Me.chkAutoSizeWidthColumns.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoSizeWidthColumns.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAutoSizeWidthColumns.Location = New System.Drawing.Point(105, 101)
        Me.chkAutoSizeWidthColumns.Name = "chkAutoSizeWidthColumns"
        Me.chkAutoSizeWidthColumns.Size = New System.Drawing.Size(212, 14)
        Me.chkAutoSizeWidthColumns.TabIndex = 5
        Me.chkAutoSizeWidthColumns.Text = "Auto size width columns"
        '
        'chkCaptionVisible
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Me.chkCaptionVisible.Appearance = Appearance12
        Me.chkCaptionVisible.BackColor = System.Drawing.Color.Transparent
        Me.chkCaptionVisible.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkCaptionVisible.Location = New System.Drawing.Point(105, 83)
        Me.chkCaptionVisible.Name = "chkCaptionVisible"
        Me.chkCaptionVisible.Size = New System.Drawing.Size(212, 14)
        Me.chkCaptionVisible.TabIndex = 4
        Me.chkCaptionVisible.Text = "Caption visible"
        '
        'chkShowAlwaysGroupBy
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Me.chkShowAlwaysGroupBy.Appearance = Appearance13
        Me.chkShowAlwaysGroupBy.BackColor = System.Drawing.Color.Transparent
        Me.chkShowAlwaysGroupBy.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkShowAlwaysGroupBy.Location = New System.Drawing.Point(105, 65)
        Me.chkShowAlwaysGroupBy.Name = "chkShowAlwaysGroupBy"
        Me.chkShowAlwaysGroupBy.Size = New System.Drawing.Size(212, 14)
        Me.chkShowAlwaysGroupBy.TabIndex = 3
        Me.chkShowAlwaysGroupBy.Text = "Show always group by"
        '
        'chkGridAutoNewline
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.chkGridAutoNewline.Appearance = Appearance14
        Me.chkGridAutoNewline.BackColor = System.Drawing.Color.Transparent
        Me.chkGridAutoNewline.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGridAutoNewline.Location = New System.Drawing.Point(105, 47)
        Me.chkGridAutoNewline.Name = "chkGridAutoNewline"
        Me.chkGridAutoNewline.Size = New System.Drawing.Size(212, 14)
        Me.chkGridAutoNewline.TabIndex = 2
        Me.chkGridAutoNewline.Text = "Grid auto newline"
        '
        'contLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.grpLayoutDetail)
        Me.Name = "contLayout"
        Me.Size = New System.Drawing.Size(629, 150)
        CType(Me.txtLayoutName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udteCreateAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAllUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpLayoutDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLayoutDetail.ResumeLayout(False)
        Me.grpLayoutDetail.PerformLayout()
        CType(Me.cboAutoFitStyleGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceGridRowMaxHeigth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceGridRowMinHeigth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoSizeWidthColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCaptionVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowAlwaysGroupBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGridAutoNewline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblLayoutName As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblCreateAt As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblCreateFrom As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udteCreateAt As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Private WithEvents txtCreateFrom As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkAllUsers As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Private WithEvents txtKey As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents lblKey As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpLayoutDetail As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents lblGridRowMaxHeigth As Infragistics.Win.Misc.UltraLabel
    Private WithEvents lblGridRowMinHeigth As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceGridRowMaxHeigth As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents uceGridRowMinHeigth As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Public WithEvents txtLayoutName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkShowAlwaysGroupBy As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkGridAutoNewline As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkCaptionVisible As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAutoSizeWidthColumns As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Private WithEvents lblAutoFitStyleGrid As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAutoFitStyleGrid As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
