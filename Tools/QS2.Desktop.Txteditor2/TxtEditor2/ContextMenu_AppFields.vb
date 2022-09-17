'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				ContextMenu_AppFields.vb
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Windows.Forms


Partial Public Class contTxtEditor2
    Inherits System.Windows.Forms.UserControl

    Private Sub DeleteFieldToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteFieldToolStripMenuItem.Click
        DeleteField()
    End Sub

    Private Sub FieldPropertiesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fieldPropertiesToolStripMenuItem.Click
        FieldSettings()
    End Sub
End Class
