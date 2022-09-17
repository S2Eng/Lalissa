<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertBreak
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public tx As TXTextControl.TextControl
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.BeginAtNewLineRadio = New System.Windows.Forms.RadioButton()
        Me.BeginAtNewPageRadio = New System.Windows.Forms.RadioButton()
        Me.SectionBreakGroupBox = New System.Windows.Forms.GroupBox()
        Me.BreakGroupBox = New System.Windows.Forms.GroupBox()
        Me.InsertTextBreakRadio = New System.Windows.Forms.RadioButton()
        Me.InsertPageBreakRadio = New System.Windows.Forms.RadioButton()
        Me.SectionBreakGroupBox.SuspendLayout()
        Me.BreakGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(102, 164)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(80, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(12, 164)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(80, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&OK"
        '
        'BeginAtNewLineRadio
        '
        Me.BeginAtNewLineRadio.AutoSize = True
        Me.BeginAtNewLineRadio.Location = New System.Drawing.Point(6, 42)
        Me.BeginAtNewLineRadio.Name = "BeginAtNewLineRadio"
        Me.BeginAtNewLineRadio.Size = New System.Drawing.Size(106, 17)
        Me.BeginAtNewLineRadio.TabIndex = 1
        Me.BeginAtNewLineRadio.Text = "Begin at &new line"
        Me.BeginAtNewLineRadio.UseVisualStyleBackColor = True
        '
        'BeginAtNewPageRadio
        '
        Me.BeginAtNewPageRadio.AutoSize = True
        Me.BeginAtNewPageRadio.Location = New System.Drawing.Point(6, 19)
        Me.BeginAtNewPageRadio.Name = "BeginAtNewPageRadio"
        Me.BeginAtNewPageRadio.Size = New System.Drawing.Size(114, 17)
        Me.BeginAtNewPageRadio.TabIndex = 0
        Me.BeginAtNewPageRadio.TabStop = True
        Me.BeginAtNewPageRadio.Text = "Begin &at new page"
        Me.BeginAtNewPageRadio.UseVisualStyleBackColor = True
        '
        'SectionBreakGroupBox
        '
        Me.SectionBreakGroupBox.Controls.Add(Me.BeginAtNewPageRadio)
        Me.SectionBreakGroupBox.Controls.Add(Me.BeginAtNewLineRadio)
        Me.SectionBreakGroupBox.Location = New System.Drawing.Point(12, 88)
        Me.SectionBreakGroupBox.Name = "SectionBreakGroupBox"
        Me.SectionBreakGroupBox.Size = New System.Drawing.Size(170, 70)
        Me.SectionBreakGroupBox.TabIndex = 3
        Me.SectionBreakGroupBox.TabStop = False
        Me.SectionBreakGroupBox.Text = "Section break types"
        '
        'BreakGroupBox
        '
        Me.BreakGroupBox.Controls.Add(Me.InsertTextBreakRadio)
        Me.BreakGroupBox.Controls.Add(Me.InsertPageBreakRadio)
        Me.BreakGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.BreakGroupBox.Name = "BreakGroupBox"
        Me.BreakGroupBox.Size = New System.Drawing.Size(170, 70)
        Me.BreakGroupBox.TabIndex = 2
        Me.BreakGroupBox.TabStop = False
        Me.BreakGroupBox.Text = "Break types"
        '
        'InsertTextBreakRadio
        '
        Me.InsertTextBreakRadio.AutoSize = True
        Me.InsertTextBreakRadio.Location = New System.Drawing.Point(6, 42)
        Me.InsertTextBreakRadio.Name = "InsertTextBreakRadio"
        Me.InsertTextBreakRadio.Size = New System.Drawing.Size(147, 17)
        Me.InsertTextBreakRadio.TabIndex = 1
        Me.InsertTextBreakRadio.Text = "Insert text &wrapping break"
        Me.InsertTextBreakRadio.UseVisualStyleBackColor = True
        '
        'InsertPageBreakRadio
        '
        Me.InsertPageBreakRadio.AutoSize = True
        Me.InsertPageBreakRadio.Checked = True
        Me.InsertPageBreakRadio.Location = New System.Drawing.Point(6, 19)
        Me.InsertPageBreakRadio.Name = "InsertPageBreakRadio"
        Me.InsertPageBreakRadio.Size = New System.Drawing.Size(108, 17)
        Me.InsertPageBreakRadio.TabIndex = 0
        Me.InsertPageBreakRadio.TabStop = True
        Me.InsertPageBreakRadio.Text = "Insert page &break"
        Me.InsertPageBreakRadio.UseVisualStyleBackColor = True
        '
        'frmInsertBreak
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(194, 199)
        Me.Controls.Add(Me.BreakGroupBox)
        Me.Controls.Add(Me.SectionBreakGroupBox)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInsertBreak"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insert Break"
        Me.TopMost = True
        Me.SectionBreakGroupBox.ResumeLayout(False)
        Me.SectionBreakGroupBox.PerformLayout()
        Me.BreakGroupBox.ResumeLayout(False)
        Me.BreakGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents BeginAtNewLineRadio As System.Windows.Forms.RadioButton
    Friend WithEvents BeginAtNewPageRadio As System.Windows.Forms.RadioButton
    Friend WithEvents SectionBreakGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents BreakGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents InsertTextBreakRadio As System.Windows.Forms.RadioButton
    Friend WithEvents InsertPageBreakRadio As System.Windows.Forms.RadioButton
End Class
