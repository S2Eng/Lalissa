


Public Class ucprint


    Public editor As QS2.Desktop.Txteditor.contTxtEditor
    Private isLoaded As Boolean = False



    Private Sub ucRech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ByVal typ As QS2.Desktop.Txteditor.etyp)
        If Me.isLoaded Then Return

        Me.editor = New QS2.Desktop.Txteditor.contTxtEditor()
        Me.PanelEditor.Controls.Add(Me.editor)
        Me.editor.loadForm(False, Nothing, False)
        Me.editor.setControlTyp()
        Me.editor.FileNew(False, False)

        Me.isLoaded = True
    End Sub

    Public Sub ResizeControl(ByVal width As Integer, ByVal height As Integer)
        Me.Width = width
        Me.Height = height
        If Not Me.editor Is Nothing Then Me.editor.resizeControl(Me.PanelEditor.Width, Me.PanelEditor.Height)
    End Sub

    Private Sub ucRech_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    End Sub


End Class
