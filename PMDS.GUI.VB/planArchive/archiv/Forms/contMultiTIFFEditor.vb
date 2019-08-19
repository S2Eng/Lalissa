Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms



Public Class contMultiTIFFEditor
    Inherits System.Windows.Forms.UserControl

    Private multiTIFF As System.Drawing.Image
    Private fileNameMULTI As String = ""

    Private aktSeite As Integer = 0
    Private anzahlSeiten As Integer = 0

    Private objDimension As System.Drawing.Imaging.FrameDimension
    Private objGuid As Guid

    Public arrFiles As New SortedList





#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'UserControl überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents UButtonZurück As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonVor As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SaveFileDialogSave As System.Windows.Forms.SaveFileDialog
    Public WithEvents pBoxPreview As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents lblAnzahl As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UButtonZurück = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonVor = New Infragistics.Win.Misc.UltraButton()
        Me.pBoxPreview = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.SaveFileDialogSave = New System.Windows.Forms.SaveFileDialog()
        Me.lblAnzahl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UButtonZurück
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance1.Image = 0
        Appearance1.TextHAlignAsString = "Center"
        Me.UButtonZurück.Appearance = Appearance1
        Me.UButtonZurück.BackColorInternal = System.Drawing.Color.White
        Me.UButtonZurück.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance2.BackColor = System.Drawing.Color.AliceBlue
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Me.UButtonZurück.HotTrackAppearance = Appearance2
        Me.UButtonZurück.Location = New System.Drawing.Point(6, 8)
        Me.UButtonZurück.Name = "UButtonZurück"
        Me.UButtonZurück.Padding = New System.Drawing.Size(2, 0)
        Me.UButtonZurück.Size = New System.Drawing.Size(28, 24)
        Me.UButtonZurück.TabIndex = 0
        Me.UButtonZurück.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UButtonZurück.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UButtonVor
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance3.Image = 1
        Appearance3.TextHAlignAsString = "Center"
        Me.UButtonVor.Appearance = Appearance3
        Me.UButtonVor.BackColorInternal = System.Drawing.Color.White
        Me.UButtonVor.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance4.BackColor = System.Drawing.Color.AliceBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Me.UButtonVor.HotTrackAppearance = Appearance4
        Me.UButtonVor.Location = New System.Drawing.Point(34, 8)
        Me.UButtonVor.Name = "UButtonVor"
        Me.UButtonVor.Padding = New System.Drawing.Size(2, 0)
        Me.UButtonVor.Size = New System.Drawing.Size(28, 24)
        Me.UButtonVor.TabIndex = 1
        Me.UButtonVor.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UButtonVor.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'pBoxPreview
        '
        Me.pBoxPreview.BorderShadowColor = System.Drawing.Color.Empty
        Me.pBoxPreview.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.pBoxPreview.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pBoxPreview.Location = New System.Drawing.Point(0, 38)
        Me.pBoxPreview.Name = "pBoxPreview"
        Me.pBoxPreview.Size = New System.Drawing.Size(560, 458)
        Me.pBoxPreview.TabIndex = 202
        Me.pBoxPreview.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblAnzahl
        '
        Me.lblAnzahl.BackColor = System.Drawing.Color.White
        Me.lblAnzahl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnzahl.ForeColor = System.Drawing.Color.Black
        Me.lblAnzahl.Location = New System.Drawing.Point(429, 12)
        Me.lblAnzahl.Name = "lblAnzahl"
        Me.lblAnzahl.Size = New System.Drawing.Size(120, 16)
        Me.lblAnzahl.TabIndex = 203
        Me.lblAnzahl.Text = "Seite 1 von 3"
        Me.lblAnzahl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contMultiTIFFEditor
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblAnzahl)
        Me.Controls.Add(Me.pBoxPreview)
        Me.Controls.Add(Me.UButtonVor)
        Me.Controls.Add(Me.UButtonZurück)
        Me.Name = "contMultiTIFFEditor"
        Me.Size = New System.Drawing.Size(560, 496)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub multiTIFFEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.UButtonVor.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Vorwaerts, 32, 32)
            Me.UButtonZurück.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Zurueck, 32, 32)

            Me.arrFiles.Clear()
            Me.ClearForm()

            'Dim genGen As New General
            'If Not System.IO.Directory.Exists(genGen.ComMultiTIFF_Path) Then
            '    System.IO.Directory.CreateDirectory(genGen.ComMultiTIFF_Path)
            'End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Private Sub UButtonZurück_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonZurück.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.aktSeite > 0 Then
                Me.aktSeite -= 1
                Me.ShowMultiTIFF()
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Private Sub UButtonVor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonVor.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.aktSeite < Me.anzahlSeiten Then
                Me.aktSeite += 1
                Me.ShowMultiTIFF()
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Public Sub refreshPreview(ByVal multiTiff As String, ByVal multiTIFFGenerieren As Boolean)
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearForm()
            Dim id As New System.Guid
            id = System.Guid.NewGuid
            'Me.fileNameMULTI = multiTiff
            Dim genGen As New GeneralArchiv

            Dim strOp As New clStringOperate
            Dim cl As New cArchive()
            'If LCase(strOp.GetFiletyp(multiTiff)) = LCase(".tif") Or _
            '            LCase(strOp.GetFiletyp(multiTiff)) = LCase(".tiff") Then
            If Not multiTIFFGenerieren Then
                Me.GenerateSites(multiTiff)
                id = System.Guid.NewGuid
                Me.fileNameMULTI = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, "multi_" + id.ToString + ".tiff")
                cl.writeMultiTIFF(Me.arrFiles, Me.fileNameMULTI)
            Else
                Me.fileNameMULTI = multiTiff
                cl.writeMultiTIFF(Me.arrFiles, Me.fileNameMULTI)
            End If
            'End If

            Me.aktSeite = 0
            'Me.ShowMultiTIFF()
            Me.SetPciture_null()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Throw New Exception("refreshPreview: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub GenerateSites(ByVal multiTiff As String)
        Dim gen As New GeneralArchiv
        Try

            Me.Visible = False
            Dim genGen As New GeneralArchiv
            Dim img As Image

            img = img.FromFile(multiTiff)
            Me.aktSeite = 0
            Me.arrFiles.Clear()

            Me.fileNameMULTI = multiTiff
            Dim objDimension As System.Drawing.Imaging.FrameDimension
            Dim objGuid As Guid
            objGuid = img.FrameDimensionsList(0)
            objDimension = New System.Drawing.Imaging.FrameDimension(objGuid)
            Me.anzahlSeiten = img.GetFrameCount(objDimension) - 1
            For i As Integer = 0 To Me.anzahlSeiten
                Me.aktSeite = i
                img.SelectActiveFrame(objDimension, Me.aktSeite)
                Me.ShowMultiTIFF()

                Dim id As New System.Guid
                id = System.Guid.NewGuid
                Dim file As String = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, id.ToString + ".tiff")
                Me.pBoxPreview.Image.Save(file)
                Me.arrFiles.Add(i, file)
            Next

        Catch ex As Exception
            Throw New Exception("GenerateSites: " + ex.ToString())
        Finally
            Me.Visible = True
        End Try
    End Sub
    Public Function GetCountSites(ByVal multiTiff As String) As Integer
        Dim gen As New GeneralArchiv
        Try

            Me.Visible = False
            Dim genGen As New GeneralArchiv
            Dim img As Image

            img = img.FromFile(multiTiff)
            Me.aktSeite = 0
            Me.arrFiles.Clear()

            Me.fileNameMULTI = multiTiff
            Dim objDimension As System.Drawing.Imaging.FrameDimension
            Dim objGuid As Guid
            objGuid = img.FrameDimensionsList(0)
            objDimension = New System.Drawing.Imaging.FrameDimension(objGuid)
            Return img.GetFrameCount(objDimension) - 1

        Catch ex As Exception
            Throw New Exception("GetCountSites: " + ex.ToString())
        Finally
            Me.Visible = True
        End Try
    End Function
    Public Sub ShowMultiTIFF()
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearForm()
            Me.multiTIFF = Me.multiTIFF.FromFile(fileNameMULTI)

            objGuid = Me.multiTIFF.FrameDimensionsList(0)
            objDimension = New System.Drawing.Imaging.FrameDimension(objGuid)

            Me.multiTIFF.SelectActiveFrame(objDimension, aktSeite)
            Me.pBoxPreview.Image = Me.multiTIFF

            Me.anzahlSeiten = Me.multiTIFF.GetFrameCount(objDimension) - 1
            Me.WritePanel()

            Me.Refresh()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Throw New Exception("ShowMultiTIFF: " + ex.ToString())
        End Try
    End Sub
    Public Sub SetPciture_null()
        Dim gen As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.pBoxPreview = Nothing
            Me.multiTIFF = Nothing

        Catch ex As Exception
            Throw New Exception("SetPciture_null: " + ex.ToString())
        End Try
    End Sub
    Public Sub WritePanel()
        Dim gen As New GeneralArchiv
        Try
            Me.lblAnzahl.Text = "Seite " + (aktSeite + 1).ToString + " von " + (anzahlSeiten + 1).ToString

        Catch ex As Exception
            Throw New Exception("WritePanel: " + ex.ToString())
        End Try
    End Sub
    Public Sub ClearForm()
        Dim gen As New GeneralArchiv
        Try

            'Me.pBoxPreview = New Infragistics.Win.UltraWinEditors.UltraPictureBox
            'Me.pBoxPreview.BorderShadowColor = System.Drawing.Color.Empty
            'Me.pBoxPreview.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted
            'Me.pBoxPreview.Dock = System.Windows.Forms.DockStyle.Bottom
            'Me.pBoxPreview.UseFlatMode = Infragistics.Win.DefaultableBoolean.True
            'Me.pBoxPreview.Location = New System.Drawing.Point(0, 40)
            'Me.pBoxPreview.Name = "pBoxPreview"
            'Me.pBoxPreview.Size = New System.Drawing.Size(560, 432)
            'Me.pBoxPreview.TabIndex = 202

            'Me.Controls.Add(Me.pBoxPreview)
            'Me.pBoxPreview.Show()
            'Me.ResizeForm()

            Me.lblAnzahl.Text = ""
            Me.pBoxPreview.Image = Nothing
            Me.multiTIFF = Nothing
            Me.Refresh()

        Catch ex As Exception
            Throw New Exception("ClearForm: " + ex.ToString())
        End Try
    End Sub

    Private Sub multiTIFFEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim gen As New GeneralArchiv
        Try

            ' Me.ResizeForm()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Public Sub ResizeForm(ByVal w As Double, ByVal h As Double)
        Dim gen As New GeneralArchiv
        Try

            Me.Width = w
            Me.Height = h

            Me.pBoxPreview.Height = Me.Height - 40
            Me.lblAnzahl.Left = Me.pBoxPreview.Left + Me.pBoxPreview.Width - Me.lblAnzahl.Width - 12

        Catch ex As Exception
            Throw New Exception("ResizeForm: " + ex.ToString())
        End Try

    End Sub

    Private Sub pBoxPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pBoxPreview.Click
        Dim gen As New GeneralArchiv
        Try


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

End Class
