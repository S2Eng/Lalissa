



Public Class frmInsertField
    Inherits System.Windows.Forms.Form


    Public modalWindow As contTxtEditor
    Friend WithEvents chkAutoNumbering As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtText As System.Windows.Forms.TextBox



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFeld As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsertField))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFeld = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.chkAutoNumbering = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Field"
        '
        'txtFeld
        '
        Me.txtFeld.Location = New System.Drawing.Point(10, 24)
        Me.txtFeld.Name = "txtFeld"
        Me.txtFeld.Size = New System.Drawing.Size(345, 20)
        Me.txtFeld.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(182, 103)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(107, 103)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 24)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        '
        'chkAutoNumbering
        '
        Me.chkAutoNumbering.AutoSize = True
        Me.chkAutoNumbering.Location = New System.Drawing.Point(13, 98)
        Me.chkAutoNumbering.Name = "chkAutoNumbering"
        Me.chkAutoNumbering.Size = New System.Drawing.Size(73, 17)
        Me.chkAutoNumbering.TabIndex = 8
        Me.chkAutoNumbering.Text = "Auto-Num"
        Me.chkAutoNumbering.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Text"
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(10, 64)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(345, 20)
        Me.txtText.TabIndex = 9
        '
        'frmInsertField
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(365, 130)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.txtFeld)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkAutoNumbering)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInsertField"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insert Field"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public tx As TXTextControl.TextControl



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.tx.Selection.Text = " "
            Dim FieldNew As TXTextControl.TextField = Me.modalWindow.cTxtEditor1.insertField(Me.modalWindow, Me.tx, "[" + Me.txtFeld.Text + "]", "[" + Me.txtText.Text + "]", Me.chkAutoNumbering.Checked)
            Me.tx.Selection.Text = " "

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Close()
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

End Class
