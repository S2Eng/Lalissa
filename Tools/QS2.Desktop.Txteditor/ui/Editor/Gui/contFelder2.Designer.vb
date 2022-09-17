<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contFelder2
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Me.treeFields = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.DsManage1 = New QS2.Desktop.Txteditor.dsManage()
        Me.optSetTypeGroup = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.lblFields = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        CType(Me.treeFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsManage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optSetTypeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeFields
        '
        Me.treeFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeFields.Location = New System.Drawing.Point(4, 150)
        Me.treeFields.Name = "treeFields"
        Me.treeFields.Size = New System.Drawing.Size(340, 460)
        Me.treeFields.TabIndex = 1
        '
        'DsManage1
        '
        Me.DsManage1.DataSetName = "dsManage"
        Me.DsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'optSetTypeGroup
        '
        Me.optSetTypeGroup.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optSetTypeGroup.CheckedIndex = 0
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = "obj"
        ValueListItem1.DisplayText = "Object"
        ValueListItem2.DataValue = "objCP"
        ValueListItem2.DisplayText = "Contact-Person"
        ValueListItem7.DataValue = "sv"
        ValueListItem7.DisplayText = "Supervisor"
        ValueListItem8.DataValue = "ag"
        ValueListItem8.DisplayText = "Agent"
        ValueListItem4.DataValue = "vn"
        ValueListItem4.DisplayText = "VN"
        ValueListItem9.DataValue = "vp"
        ValueListItem9.DisplayText = "VP"
        ValueListItem10.DataValue = "BZBErl"
        ValueListItem10.DisplayText = "BZB Erleben"
        ValueListItem11.DataValue = "BZBAbl"
        ValueListItem11.DisplayText = "BZB Ableben"
        ValueListItem12.DataValue = "termfix"
        ValueListItem12.DisplayText = "Terminus Fix"
        ValueListItem6.DataValue = "fo"
        ValueListItem6.DisplayText = "Fonds"
        ValueListItem5.DataValue = "cont"
        ValueListItem5.DisplayText = "Contract"
        ValueListItem3.DataValue = "sys"
        ValueListItem3.DisplayText = "Sys-Fields"
        Me.optSetTypeGroup.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem7, ValueListItem8, ValueListItem4, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12, ValueListItem6, ValueListItem5, ValueListItem3})
        Me.optSetTypeGroup.Location = New System.Drawing.Point(11, 19)
        Me.optSetTypeGroup.Name = "optSetTypeGroup"
        Me.optSetTypeGroup.Size = New System.Drawing.Size(319, 102)
        Me.optSetTypeGroup.TabIndex = 0
        Me.optSetTypeGroup.Text = "Object"
        '
        'lblFields
        '
        Me.lblFields.Location = New System.Drawing.Point(6, 134)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(129, 14)
        Me.lblFields.TabIndex = 2
        Me.lblFields.Text = "Fields"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.optSetTypeGroup)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(339, 127)
        Me.UltraGroupBox1.TabIndex = 3
        Me.UltraGroupBox1.Text = "Group"
        '
        'contFelder2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.lblFields)
        Me.Controls.Add(Me.treeFields)
        Me.Name = "contFelder2"
        Me.Size = New System.Drawing.Size(348, 613)
        CType(Me.treeFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsManage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optSetTypeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents treeFields As Infragistics.Win.UltraWinTree.UltraTree
    Public WithEvents DsManage1 As dsManage
    Friend WithEvents optSetTypeGroup As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblFields As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
