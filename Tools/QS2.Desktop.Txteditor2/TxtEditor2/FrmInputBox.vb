'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				FrmInputBox.vb
' description:	This file contains a small dialog which lets the user enter text.
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Reflection
Imports System.Drawing


''' <summary>
''' Lets the user enter text.
''' </summary>
Public Class FrmInputBox
    Inherits Form
    Private WithEvents _txtInput As TextBox
    Private WithEvents _btnCancel As Button
    Private WithEvents _btnOK As Button
    Private WithEvents _btnFont As Button
    Private _components As Container = Nothing
    Private _bAllowEmptyString As Boolean = False

    Public Property HasFontButton() As Boolean
        Get
            Return _btnFont.Visible
        End Get
        Set(ByVal value As Boolean)
            _btnFont.Visible = value
        End Set
    End Property

    Public Property SelectedFont() As Font
        Get
            Return m_SelectedFont
        End Get
        Set(ByVal value As Font)
            m_SelectedFont = Value
        End Set
    End Property
    Private m_SelectedFont As Font

    Public ReadOnly Property TextInput() As String
        Get
            Return _txtInput.Text
        End Get
    End Property

    Public Property AllowEmptyString() As Boolean
        Get
            Return _bAllowEmptyString
        End Get

        Set(ByVal value As Boolean)
            _bAllowEmptyString = value
            If _bAllowEmptyString Then
                _btnOK.Enabled = True
            End If
        End Set
    End Property

    Public Sub New(ByVal strCaption As String, ByVal strText As String)
        InitializeComponent()

        AllowEmptyString = False
        SelectedFont = New System.Drawing.Font("Calibri", 12)
        ' Set an arbitrary font
        Text = strCaption
        _txtInput.Text = strText
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If _components IsNot Nothing Then
                _components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmInputBox))
        Me._txtInput = New System.Windows.Forms.TextBox()
        Me._btnCancel = New System.Windows.Forms.Button()
        Me._btnOK = New System.Windows.Forms.Button()
        Me._btnFont = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' _txtInput
        ' 
        Me._txtInput.Location = New System.Drawing.Point(12, 8)
        Me._txtInput.Name = "_txtInput"
        Me._txtInput.Size = New System.Drawing.Size(277, 20)
        Me._txtInput.TabIndex = 0
        ' 
        ' _btnCancel
        ' 
        Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me._btnCancel.Location = New System.Drawing.Point(209, 34)
        Me._btnCancel.Name = "_btnCancel"
        Me._btnCancel.Size = New System.Drawing.Size(80, 24)
        Me._btnCancel.TabIndex = 3
        Me._btnCancel.Text = "&Cancel"
        ' 
        ' _btnOK
        ' 
        Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me._btnOK.Enabled = False
        Me._btnOK.Location = New System.Drawing.Point(123, 34)
        Me._btnOK.Name = "_btnOK"
        Me._btnOK.Size = New System.Drawing.Size(80, 24)
        Me._btnOK.TabIndex = 2
        Me._btnOK.Text = "&OK"
        ' 
        ' _btnFont
        ' 
        Me._btnFont.Location = New System.Drawing.Point(12, 34)
        Me._btnFont.Name = "_btnFont"
        Me._btnFont.Size = New System.Drawing.Size(72, 24)
        Me._btnFont.TabIndex = 1
        Me._btnFont.Text = "&Font…"
        Me._btnFont.Visible = False
        ' 
        ' FrmInputBox
        ' 
        Me.AcceptButton = Me._btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me._btnCancel
        Me.ClientSize = New System.Drawing.Size(301, 67)
        Me.Controls.Add(Me._btnFont)
        Me.Controls.Add(Me._btnCancel)
        Me.Controls.Add(Me._btnOK)
        Me.Controls.Add(Me._txtInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInputBox"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "InputBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Shared Function ShowInputBox(ByVal strCaption As String, ByRef strInput As String, ByVal owner As Form) As Boolean
        Return ShowInputBox(strCaption, strInput, owner, False)
    End Function

    Public Shared Function ShowInputBox(ByVal strCaption As String, ByRef strInput As String, ByVal owner As Form, ByVal allowEmptyString As Boolean) As Boolean
        Dim result As DialogResult

        Dim box = New FrmInputBox(strCaption, strInput)
        If Not owner Is Nothing Then
            box.RightToLeft = owner.RightToLeft
        End If
        box.AllowEmptyString = allowEmptyString
        result = box.ShowDialog()

        If result = DialogResult.OK Then
            strInput = box._txtInput.Text
        End If

        Return (result = DialogResult.OK)
    End Function

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOK.Click
        Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
        Close()
    End Sub

    Private Sub TxtInput_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtInput.TextChanged
        If _bAllowEmptyString Then
            Return
        End If
        _btnOK.Enabled = (_txtInput.Text.Length > 0)
    End Sub

    Private Sub BtnFont_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim fntDlg = New FontDialog() With { _
				.Font = Me.SelectedFont _
			}
        If fntDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.SelectedFont = fntDlg.Font
        End If
    End Sub
End Class
