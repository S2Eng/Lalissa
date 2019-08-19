

Public Class frmPrint

    Public ucprint As ucprint
    Private isLoaded As Boolean = False



    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)
    End Sub

    Public Sub initControl()
        If Me.isLoaded Then Return
        Me.ucprint = New ucprint()
        Me.PanelEditor.Controls.Add(Me.ucprint)
        Me.ucprint.initControl(QS2.Desktop.Txteditor.etyp.calc)
        Me.resizeControl()
        Me.isLoaded = True
    End Sub

    Private Sub frmBill_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.resizeControl()
    End Sub
    Private Sub resizeControl()
        If Not Me.ucprint Is Nothing Then Me.ucprint.ResizeControl(Me.PanelEditor.Width, Me.PanelEditor.Height)
    End Sub

    Private Sub frmPrint_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

End Class