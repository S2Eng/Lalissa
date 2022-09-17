'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				frmHyperlink.vb
' description:	This file contains the dialog which is shown when a hyperlink is created.
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Windows.Forms


''' <summary>
''' Is shown when a hyperlink is inserted into a document.
''' </summary>
Public Class FrmHyperlink
    Inherits Form
    Friend _lblLinkText As Label
    Friend _txtLinkTarget As TextBox
    Friend _txHidden As TXTextControl.TextControl
    Friend _grpBox01 As GroupBox
    Friend WithEvents _optSelFile As RadioButton
    Friend WithEvents _optCurPage As RadioButton
    Friend WithEvents _lstTargets As ListBox
    Friend _lblShowTargets As Label
    Friend _lblSelectTarget As Label
    Friend WithEvents _btnChooseFile As Button
    Friend _lblLinksTarget As Label
    Friend WithEvents _txtLinkedText As TextBox
    Friend _btnCancel As Button
    Friend WithEvents _btnOK As Button
    Private _strLoadedFile As String
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private _components As System.ComponentModel.Container = Nothing



    Public Overloads Shared Function ShowDialog(ByVal textControl As TXTextControl.TextControl, ByVal owner As Form) As DialogResult
        Dim frm = New FrmHyperlink

        If Not owner Is Nothing Then
            frm = New FrmHyperlink() With { _
                                             .TextControl = textControl, _
                                             .RightToLeft = owner.RightToLeft _
                                            }
        Else
            frm = New FrmHyperlink() With {.TextControl = textControl}
        End If

        Return frm.ShowDialog()
    End Function

    Private Sub New()
        '
        ' Required for Windows Form Designer support
        '
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo
    End Sub

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If _components IsNot Nothing Then
                _components.Dispose()
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
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmHyperlink))
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Me._txHidden = New TXTextControl.TextControl()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo
        Me._grpBox01 = New System.Windows.Forms.GroupBox()
        Me._optSelFile = New System.Windows.Forms.RadioButton()
        Me._optCurPage = New System.Windows.Forms.RadioButton()
        Me._lstTargets = New System.Windows.Forms.ListBox()
        Me._lblShowTargets = New System.Windows.Forms.Label()
        Me._lblSelectTarget = New System.Windows.Forms.Label()
        Me._btnChooseFile = New System.Windows.Forms.Button()
        Me._txtLinkTarget = New System.Windows.Forms.TextBox()
        Me._lblLinksTarget = New System.Windows.Forms.Label()
        Me._txtLinkedText = New System.Windows.Forms.TextBox()
        Me._lblLinkText = New System.Windows.Forms.Label()
        Me._btnCancel = New System.Windows.Forms.Button()
        Me._btnOK = New System.Windows.Forms.Button()
        Me._grpBox01.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' _txHidden
        ' 
        Me._txHidden.Font = New System.Drawing.Font("Arial", 10.0!)
        Me._txHidden.Location = New System.Drawing.Point(8, 240)
        Me._txHidden.Name = "_txHidden"
        Me._txHidden.PageMargins.Bottom = 79.03
        Me._txHidden.PageMargins.Left = 79.03
        Me._txHidden.PageMargins.Right = 79.03
        Me._txHidden.PageMargins.Top = 79.03
        Me._txHidden.Size = New System.Drawing.Size(184, 32)
        Me._txHidden.TabIndex = 0
        Me._txHidden.TabStop = False
        Me._txHidden.Text = "This Text Control is hidden at run time"
        ' 
        ' _grpBox01
        ' 
        Me._grpBox01.Controls.Add(Me._optSelFile)
        Me._grpBox01.Controls.Add(Me._optCurPage)
        Me._grpBox01.Controls.Add(Me._lstTargets)
        Me._grpBox01.Controls.Add(Me._lblShowTargets)
        Me._grpBox01.Controls.Add(Me._lblSelectTarget)
        Me._grpBox01.Controls.Add(Me._btnChooseFile)
        Me._grpBox01.Controls.Add(Me._txtLinkTarget)
        Me._grpBox01.Controls.Add(Me._lblLinksTarget)
        Me._grpBox01.Location = New System.Drawing.Point(8, 56)
        Me._grpBox01.Name = "_grpBox01"
        Me._grpBox01.Size = New System.Drawing.Size(404, 178)
        Me._grpBox01.TabIndex = 4
        Me._grpBox01.TabStop = False
        Me._grpBox01.Text = "Link to:"
        ' 
        ' _optSelFile
        ' 
        Me._optSelFile.Location = New System.Drawing.Point(280, 125)
        Me._optSelFile.Name = "_optSelFile"
        Me._optSelFile.Size = New System.Drawing.Size(96, 20)
        Me._optSelFile.TabIndex = 5
        Me._optSelFile.Text = "S&elected file"
        ' 
        ' _optCurPage
        ' 
        Me._optCurPage.Checked = True
        Me._optCurPage.Location = New System.Drawing.Point(280, 99)
        Me._optCurPage.Name = "_optCurPage"
        Me._optCurPage.Size = New System.Drawing.Size(96, 20)
        Me._optCurPage.TabIndex = 4
        Me._optCurPage.TabStop = True
        Me._optCurPage.Text = "C&urrent page"
        ' 
        ' _lstTargets
        ' 
        Me._lstTargets.Location = New System.Drawing.Point(8, 96)
        Me._lstTargets.Name = "_lstTargets"
        Me._lstTargets.Size = New System.Drawing.Size(244, 56)
        Me._lstTargets.TabIndex = 3
        ' 
        ' _lblShowTargets
        ' 
        Me._lblShowTargets.Location = New System.Drawing.Point(280, 80)
        Me._lblShowTargets.Name = "_lblShowTargets"
        Me._lblShowTargets.Size = New System.Drawing.Size(88, 16)
        Me._lblShowTargets.TabIndex = 4
        Me._lblShowTargets.Text = "Show targets in:"
        ' 
        ' _lblSelectTarget
        ' 
        Me._lblSelectTarget.Location = New System.Drawing.Point(8, 80)
        Me._lblSelectTarget.Name = "_lblSelectTarget"
        Me._lblSelectTarget.Size = New System.Drawing.Size(256, 16)
        Me._lblSelectTarget.TabIndex = 3
        Me._lblSelectTarget.Text = "&Select a named target in current page (optional):"
        ' 
        ' _btnChooseFile
        ' 
        Me._btnChooseFile.Location = New System.Drawing.Point(310, 15)
        Me._btnChooseFile.Name = "_btnChooseFile"
        Me._btnChooseFile.Size = New System.Drawing.Size(88, 24)
        Me._btnChooseFile.TabIndex = 3
        Me._btnChooseFile.Text = "Choose &file..."
        ' 
        ' _txtLinkTarget
        ' 
        Me._txtLinkTarget.Location = New System.Drawing.Point(8, 44)
        Me._txtLinkTarget.Name = "_txtLinkTarget"
        Me._txtLinkTarget.Size = New System.Drawing.Size(390, 20)
        Me._txtLinkTarget.TabIndex = 2
        ' 
        ' _lblLinksTarget
        ' 
        Me._lblLinksTarget.Location = New System.Drawing.Point(8, 24)
        Me._lblLinksTarget.Name = "_lblLinksTarget"
        Me._lblLinksTarget.Size = New System.Drawing.Size(184, 16)
        Me._lblLinksTarget.TabIndex = 7
        Me._lblLinksTarget.Text = "Li&nk to page location or local file:"
        ' 
        ' _txtLinkedText
        ' 
        Me._txtLinkedText.Location = New System.Drawing.Point(12, 27)
        Me._txtLinkedText.Name = "_txtLinkedText"
        Me._txtLinkedText.Size = New System.Drawing.Size(248, 20)
        Me._txtLinkedText.TabIndex = 1
        ' 
        ' _lblLinkText
        ' 
        Me._lblLinkText.Location = New System.Drawing.Point(8, 8)
        Me._lblLinkText.Name = "_lblLinkText"
        Me._lblLinkText.Size = New System.Drawing.Size(144, 16)
        Me._lblLinkText.TabIndex = 99
        Me._lblLinkText.Text = "Lin&ked text:"
        ' 
        ' _btnCancel
        ' 
        Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me._btnCancel.Location = New System.Drawing.Point(332, 240)
        Me._btnCancel.Name = "_btnCancel"
        Me._btnCancel.Size = New System.Drawing.Size(80, 24)
        Me._btnCancel.TabIndex = 0
        Me._btnCancel.TabStop = False
        Me._btnCancel.Text = "&Cancel"
        ' 
        ' _btnOK
        ' 
        Me._btnOK.Location = New System.Drawing.Point(246, 240)
        Me._btnOK.Name = "_btnOK"
        Me._btnOK.Size = New System.Drawing.Size(80, 24)
        Me._btnOK.TabIndex = 5
        Me._btnOK.Text = "&OK"
        ' 
        ' FrmHyperlink
        ' 
        Me.AcceptButton = Me._btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me._btnCancel
        Me.ClientSize = New System.Drawing.Size(424, 272)
        Me.Controls.Add(Me._txHidden)
        Me.Controls.Add(Me._grpBox01)
        Me.Controls.Add(Me._txtLinkedText)
        Me.Controls.Add(Me._lblLinkText)
        Me.Controls.Add(Me._btnCancel)
        Me.Controls.Add(Me._btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHyperlink"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hyperlinks"
        Me._grpBox01.ResumeLayout(False)
        Me._grpBox01.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Property TextControl() As TXTextControl.TextControl
        Get
            Return m_TextControl
        End Get
        Set(ByVal value As TXTextControl.TextControl)
            m_TextControl = value
        End Set
    End Property
    Private m_TextControl As TXTextControl.TextControl

    Private Sub FillTargetsListbox(ByVal tx As TXTextControl.TextControl)
        _lstTargets.Items.Clear()

        Try
            For Each dt As TXTextControl.DocumentTarget In tx.DocumentTargets
                _lstTargets.Items.Add(dt.TargetName)
            Next
        Catch
        End Try
    End Sub

    Private Function GetTargetID(ByVal tx As TXTextControl.TextControl, ByVal TargetName As String) As Integer
        For Each dt As TXTextControl.DocumentTarget In tx.DocumentTargets
            If dt.TargetName = TargetName Then
                Return dt.ID
            End If
        Next

        Return 0
    End Function

    ''' <summary>
    ''' Apply changes to the selected hyperlink, or insert a new hyperlink.
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event arguments</param>
    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOK.Click
        Dim linkCur As TXTextControl.HypertextLink = Nothing
        Dim bIsExternalLink As Boolean

        Try
            linkCur = TextControl.HypertextLinks.GetItem()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        ' Determine which type of link we have (see lstTargets_SelectedIndexChanged) and remove
        ' the '#' character.
        If _txtLinkTarget.Text.StartsWith("#") Then
            bIsExternalLink = False
            _txtLinkTarget.Text = _txtLinkTarget.Text.Remove(0, 1)
        Else
            bIsExternalLink = True
        End If

        If linkCur Is Nothing Then
            ' No existing Hypertext link at caret position, insert a new one. 
            If bIsExternalLink Then
                Dim linkExt As New TXTextControl.HypertextLink(_txtLinkedText.Text, _txtLinkTarget.Text)
                TextControl.HypertextLinks.Add(linkExt)
            Else
                Dim nTgtID As Integer = GetTargetID(TextControl, _txtLinkTarget.Text)
                Dim linkInt As New TXTextControl.DocumentLink(_txtLinkedText.Text, TextControl.DocumentTargets.GetItem(nTgtID))
                TextControl.DocumentLinks.Add(linkInt)
            End If
        Else
            ' Update existing Hypertext link
            linkCur.Text = _txtLinkedText.Text
            linkCur.Target = _txtLinkTarget.Text
        End If

        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub OptCurPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optCurPage.CheckedChanged
        If TextControl IsNot Nothing Then
            FillTargetsListbox(TextControl)
        End If
    End Sub

    Private Sub optSelFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optSelFile.CheckedChanged
        FillTargetsListbox(_txHidden)
    End Sub

    Private Sub BtnChooseFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnChooseFile.Click
        Dim ls As New TXTextControl.LoadSettings() With { _
         .ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord _
        }

        _txHidden.Load(TXTextControl.StreamType.All, ls)
        _txtLinkTarget.Text = ls.LoadedFile
        _strLoadedFile = ls.LoadedFile
    End Sub

    Private Sub LstTargets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lstTargets.SelectedIndexChanged
        _txtLinkTarget.Text = _strLoadedFile & "#" & Convert.ToString(_lstTargets.SelectedItem)
    End Sub

    ''' <summary>
    ''' Disable OK button if txtLinkedText or txtLinkTarget are empty
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event arguments</param>
    Private Sub RequiredFields_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLinkedText.TextChanged
        _btnOK.Enabled = (_txtLinkedText.Text <> "" AndAlso _txtLinkTarget.Text <> "")
    End Sub

    ''' <summary>
    ''' If the caret is inside an existing hyperlink, copy the hyperlink's text and link
    ''' information to the text boxes on the form.
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event arguments</param>
    Private Sub FrmHyperlink_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim linkExt As TXTextControl.HypertextLink = Nothing
        Dim linkInt As TXTextControl.DocumentLink = Nothing

        Try
            linkExt = TextControl.HypertextLinks.GetItem()
            linkInt = TextControl.DocumentLinks.GetItem()
        Catch
        End Try

        If linkExt IsNot Nothing Then
            _txtLinkedText.Text = linkExt.Text
            _txtLinkTarget.Text = linkExt.Target
            _optCurPage.Enabled = False
            _optSelFile.Checked = True
        ElseIf linkInt IsNot Nothing Then
            _txtLinkedText.Text = linkInt.Text
            _txtLinkTarget.Text = linkInt.DocumentTarget.TargetName
            _optCurPage.Checked = True
            _optSelFile.Enabled = False
        End If

        _btnOK.Enabled = (_txtLinkedText.Text <> "" AndAlso _txtLinkTarget.Text <> "")
        FillTargetsListbox(TextControl)
        _txHidden.Left = Width
        ' hide it
        _strLoadedFile = ""
    End Sub
End Class
