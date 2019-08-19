


Public Class frmPdfViewer



    Private Sub frmPdfViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(sFileName As String, fileStream As System.IO.Stream)
        Try
            Me.Text = doUI.getRes("PdfViewer")
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            If fileStream Is Nothing Then
                Me.PdfViewerControl1.Load(sFileName, "")
            Else
                Me.PdfViewerControl1.Load(fileStream)
            End If

            Me.PdfViewerControl1.ShowVerticalScrollBar = True
            Me.PdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.FitWidth

        Catch ex As Exception
            Throw New Exception("frmPdfViewer.initControl: " + ex.ToString())
        End Try
    End Sub

End Class