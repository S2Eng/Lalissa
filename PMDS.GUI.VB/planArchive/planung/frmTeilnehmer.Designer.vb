<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeilnehmer
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeilnehmer))
        Me.UOptionSetArt = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.UTreeTeilnehmer = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.UButtonEinladen = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.txtSuche = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSuche = New Infragistics.Win.Misc.UltraLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.UOptionSetArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTreeTeilnehmer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UOptionSetArt
        '
        Me.UOptionSetArt.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        ValueListItem1.DataValue = "G"
        ValueListItem1.DisplayText = "Gruppe"
        ValueListItem2.DataValue = "B"
        ValueListItem2.DisplayText = "Benutzer"
        Me.UOptionSetArt.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.UOptionSetArt.Location = New System.Drawing.Point(7, 12)
        Me.UOptionSetArt.Name = "UOptionSetArt"
        Me.UOptionSetArt.Size = New System.Drawing.Size(138, 16)
        Me.UOptionSetArt.TabIndex = 0
        Me.UOptionSetArt.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UTreeTeilnehmer
        '
        Me.UTreeTeilnehmer.Location = New System.Drawing.Point(7, 63)
        Me.UTreeTeilnehmer.Name = "UTreeTeilnehmer"
        Override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
        Me.UTreeTeilnehmer.Override = Override1
        Me.UTreeTeilnehmer.Size = New System.Drawing.Size(179, 256)
        Me.UTreeTeilnehmer.TabIndex = 1
        Me.UTreeTeilnehmer.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UButtonEinladen
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.UButtonEinladen.Appearance = Appearance1
        Me.UButtonEinladen.Location = New System.Drawing.Point(7, 322)
        Me.UButtonEinladen.Name = "UButtonEinladen"
        Me.UButtonEinladen.Size = New System.Drawing.Size(89, 24)
        Me.UButtonEinladen.TabIndex = 2
        Me.UButtonEinladen.Text = "Einladen"
        '
        'UButtonAbbrechen
        '
        Me.UButtonAbbrechen.Location = New System.Drawing.Point(97, 322)
        Me.UButtonAbbrechen.Name = "UButtonAbbrechen"
        Me.UButtonAbbrechen.Size = New System.Drawing.Size(89, 24)
        Me.UButtonAbbrechen.TabIndex = 3
        Me.UButtonAbbrechen.Text = "Abbrechen"
        '
        'txtSuche
        '
        Me.txtSuche.Location = New System.Drawing.Point(46, 36)
        Me.txtSuche.Name = "txtSuche"
        Me.txtSuche.Size = New System.Drawing.Size(140, 21)
        Me.txtSuche.TabIndex = 4
        '
        'lblSuche
        '
        Me.lblSuche.Location = New System.Drawing.Point(7, 39)
        Me.lblSuche.Name = "lblSuche"
        Me.lblSuche.Size = New System.Drawing.Size(45, 16)
        Me.lblSuche.TabIndex = 5
        Me.lblSuche.Text = "Suche"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ICO_2 personen2.ico")
        Me.ImageList1.Images.SetKeyName(1, "ICO_sachbearbeiterverwaltung.ico")
        '
        'frmTeilnehmer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(193, 349)
        Me.Controls.Add(Me.txtSuche)
        Me.Controls.Add(Me.lblSuche)
        Me.Controls.Add(Me.UButtonAbbrechen)
        Me.Controls.Add(Me.UButtonEinladen)
        Me.Controls.Add(Me.UTreeTeilnehmer)
        Me.Controls.Add(Me.UOptionSetArt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTeilnehmer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Teilnehmer einladen"
        CType(Me.UOptionSetArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTreeTeilnehmer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UTreeTeilnehmer As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UButtonEinladen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtSuche As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSuche As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents UOptionSetArt As Infragistics.Win.UltraWinEditors.UltraOptionSet
End Class
