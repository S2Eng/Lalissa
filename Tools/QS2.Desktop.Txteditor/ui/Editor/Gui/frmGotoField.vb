




Public Class frmGotoField
    Inherits System.Windows.Forms.Form



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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonLöschen As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGotoField))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.ButtonLöschen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBox1.Location = New System.Drawing.Point(8, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(287, 382)
        Me.ComboBox1.TabIndex = 5
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(301, 33)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(301, 7)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "Ok"
        '
        'ButtonLöschen
        '
        Me.ButtonLöschen.Location = New System.Drawing.Point(301, 81)
        Me.ButtonLöschen.Name = "ButtonLöschen"
        Me.ButtonLöschen.Size = New System.Drawing.Size(80, 24)
        Me.ButtonLöschen.TabIndex = 6
        Me.ButtonLöschen.Text = "Delete Field"
        '
        'frmGotoField
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(393, 394)
        Me.Controls.Add(Me.ButtonLöschen)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGotoField"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Go to Field"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public tx As TXTextControl.TextControl
    Public modalWindow As contTxtEditor



    Private Sub frmGotoDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.modalWindow.cTxtEditor1.loadTextmarken(modalWindow, tx, Me.ComboBox1)
    End Sub





    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.modalWindow.cTxtEditor1.geheZuFeld(Me.modalWindow, Me.tx, Me.ComboBox1) Then
                Me.Close()
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub ButtonLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLöschen.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.modalWindow.cTxtEditor1.feldLöschen(Me.modalWindow, Me.tx, Me.ComboBox1)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
