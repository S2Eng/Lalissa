'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				FrmInsertBreak.cs
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Summary description for frmInsertSection.
''' </summary>
Public Class FrmInsertBreak
    Inherits System.Windows.Forms.Form
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Private WithEvents BeginAtNewLineRadio As RadioButton
    Private WithEvents BeginAtNewPageRadio As RadioButton
    Private WithEvents InsertPageBreakRadio As RadioButton
    Private SectionBreakGroupBox As GroupBox
    Private BreakGroupBox As GroupBox
    Private WithEvents InsertTextBreakRadio As RadioButton
    Private WithEvents InsertColumnRadio As RadioButton
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.Container = Nothing

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmInsertBreak))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.BeginAtNewLineRadio = New System.Windows.Forms.RadioButton()
        Me.BeginAtNewPageRadio = New System.Windows.Forms.RadioButton()
        Me.SectionBreakGroupBox = New System.Windows.Forms.GroupBox()
        Me.InsertPageBreakRadio = New System.Windows.Forms.RadioButton()
        Me.BreakGroupBox = New System.Windows.Forms.GroupBox()
        Me.InsertColumnRadio = New System.Windows.Forms.RadioButton()
        Me.InsertTextBreakRadio = New System.Windows.Forms.RadioButton()
        Me.SectionBreakGroupBox.SuspendLayout()
        Me.BreakGroupBox.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' cmdCancel
        ' 
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(102, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        ' 
        ' cmdOK
        ' 
        Me.cmdOK.Location = New System.Drawing.Point(12, 185)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "&OK"
        ' 
        ' BeginAtNewLineRadio
        ' 
        Me.BeginAtNewLineRadio.AutoCheck = False
        Me.BeginAtNewLineRadio.AutoSize = True
        Me.BeginAtNewLineRadio.Location = New System.Drawing.Point(6, 42)
        Me.BeginAtNewLineRadio.Name = "BeginAtNewLineRadio"
        Me.BeginAtNewLineRadio.Size = New System.Drawing.Size(106, 17)
        Me.BeginAtNewLineRadio.TabIndex = 4
        Me.BeginAtNewLineRadio.TabStop = True
        Me.BeginAtNewLineRadio.Text = "Begin at &new line"
        Me.BeginAtNewLineRadio.UseVisualStyleBackColor = True
        ' 
        ' BeginAtNewPageRadio
        ' 
        Me.BeginAtNewPageRadio.AutoCheck = False
        Me.BeginAtNewPageRadio.Location = New System.Drawing.Point(6, 19)
        Me.BeginAtNewPageRadio.Name = "BeginAtNewPageRadio"
        Me.BeginAtNewPageRadio.Size = New System.Drawing.Size(158, 17)
        Me.BeginAtNewPageRadio.TabIndex = 3
        Me.BeginAtNewPageRadio.TabStop = True
        Me.BeginAtNewPageRadio.Text = "Begin &at new page"
        Me.BeginAtNewPageRadio.UseVisualStyleBackColor = True
        ' 
        ' SectionBreakGroupBox
        ' 
        Me.SectionBreakGroupBox.Controls.Add(Me.BeginAtNewLineRadio)
        Me.SectionBreakGroupBox.Controls.Add(Me.BeginAtNewPageRadio)
        Me.SectionBreakGroupBox.Location = New System.Drawing.Point(12, 109)
        Me.SectionBreakGroupBox.Name = "SectionBreakGroupBox"
        Me.SectionBreakGroupBox.Size = New System.Drawing.Size(170, 70)
        Me.SectionBreakGroupBox.TabIndex = 3
        Me.SectionBreakGroupBox.TabStop = False
        Me.SectionBreakGroupBox.Text = "Section break types"
        ' 
        ' InsertPageBreakRadio
        ' 
        Me.InsertPageBreakRadio.AutoCheck = False
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
        ' BreakGroupBox
        ' 
        Me.BreakGroupBox.Controls.Add(Me.InsertColumnRadio)
        Me.BreakGroupBox.Controls.Add(Me.InsertTextBreakRadio)
        Me.BreakGroupBox.Controls.Add(Me.InsertPageBreakRadio)
        Me.BreakGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.BreakGroupBox.Name = "BreakGroupBox"
        Me.BreakGroupBox.Size = New System.Drawing.Size(170, 92)
        Me.BreakGroupBox.TabIndex = 2
        Me.BreakGroupBox.TabStop = False
        Me.BreakGroupBox.Text = "Break types"
        ' 
        ' InsertColumnRadio
        ' 
        Me.InsertColumnRadio.AutoCheck = False
        Me.InsertColumnRadio.AutoSize = True
        Me.InsertColumnRadio.Location = New System.Drawing.Point(6, 42)
        Me.InsertColumnRadio.Name = "InsertColumnRadio"
        Me.InsertColumnRadio.Size = New System.Drawing.Size(118, 17)
        Me.InsertColumnRadio.TabIndex = 1
        Me.InsertColumnRadio.TabStop = True
        Me.InsertColumnRadio.Text = "Insert &column break"
        Me.InsertColumnRadio.UseVisualStyleBackColor = True
        ' 
        ' InsertTextBreakRadio
        ' 
        Me.InsertTextBreakRadio.AutoCheck = False
        Me.InsertTextBreakRadio.AutoSize = True
        Me.InsertTextBreakRadio.Location = New System.Drawing.Point(6, 65)
        Me.InsertTextBreakRadio.Name = "InsertTextBreakRadio"
        Me.InsertTextBreakRadio.Size = New System.Drawing.Size(147, 17)
        Me.InsertTextBreakRadio.TabIndex = 2
        Me.InsertTextBreakRadio.TabStop = True
        Me.InsertTextBreakRadio.Text = "Insert text &wrapping break"
        Me.InsertTextBreakRadio.UseVisualStyleBackColor = True
        ' 
        ' FrmInsertBreak
        ' 
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(194, 219)
        Me.Controls.Add(Me.BreakGroupBox)
        Me.Controls.Add(Me.SectionBreakGroupBox)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInsertBreak"
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
#End Region

    Public tx As TXTextControl.TextControl
    Private breakKind As TXTextControl.SectionBreakKind

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim dpi As Integer = CInt(1440 / tx.CreateGraphics().DpiX)

        If InsertPageBreakRadio.Checked Then
            tx.Selection.Text = vbFormFeed
        ElseIf InsertColumnRadio.Checked Then
            tx.Selection.Text = ChrW(14)
        ElseIf InsertTextBreakRadio.Checked Then
            tx.Selection.Text = vbVerticalTab
        Else
            Try
                tx.Sections.Add(breakKind)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName)
                Return
            End Try
        End If

        tx.ScrollLocation = New Point(tx.ScrollLocation.X, CInt(tx.InputPosition.Location.Y - (tx.Selection.SectionFormat.PageMargins.Top * dpi)))
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub InsertPageRadio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InsertPageBreakRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = False
        InsertColumnRadio.Checked = False
        InsertPageBreakRadio.Checked = True
        InsertTextBreakRadio.Checked = False
    End Sub

    Private Sub InsertColumnRadio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InsertColumnRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = False
        InsertColumnRadio.Checked = True
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = False
    End Sub

    Private Sub BeginAtNewPageRadio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAtNewPageRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = True
        InsertColumnRadio.Checked = False
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = False
        breakKind = TXTextControl.SectionBreakKind.BeginAtNewPage
    End Sub

    Private Sub BeginAtNewLineRadio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAtNewLineRadio.Click
        BeginAtNewLineRadio.Checked = True
        BeginAtNewPageRadio.Checked = False
        InsertColumnRadio.Checked = False
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = False
        breakKind = TXTextControl.SectionBreakKind.BeginAtNewLine
    End Sub

    Private Sub InsertTextBreakRadio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InsertTextBreakRadio.Click
        BeginAtNewLineRadio.Checked = False
        BeginAtNewPageRadio.Checked = False
        InsertColumnRadio.Checked = False
        InsertPageBreakRadio.Checked = False
        InsertTextBreakRadio.Checked = True
    End Sub
End Class
