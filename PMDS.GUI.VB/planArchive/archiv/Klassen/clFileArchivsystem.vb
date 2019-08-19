Imports Infragistics.Win.UltraWinTree


Public Class clFileArchivsystem

    Private gen As New GeneralArchiv



    Public Function getIcontForFileTypxy(ByVal file_typ As String, ByRef item As UltraTreeNode)
        Try

            'Dim handRes As New handRessourcen
            'If LCase(file_typ) = LCase(".doc") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("word16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_word
            'ElseIf LCase(file_typ) = LCase(".xls") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("excel16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_excel
            'ElseIf LCase(file_typ) = LCase(".txt") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("text16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel
            'ElseIf LCase(file_typ) = LCase(".bmp") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("bitmap16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel
            'ElseIf LCase(file_typ) = LCase(".tif") Or _
            '          LCase(file_typ) = LCase(".tiff") Or LCase(file_typ) = LCase(".gif") Then

            '    'item.Override.NodeAppearance.Image = handRes.getIcon("bitmap16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel
            'ElseIf LCase(file_typ) = LCase(".pdf") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("acrobat16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_pdf
            'ElseIf LCase(file_typ) = LCase(".htm") Or LCase(file_typ) = LCase(".html") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("html16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_word
            'ElseIf LCase(file_typ) = LCase(".rar") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("text16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel
            'ElseIf LCase(file_typ) = LCase(".zip") Then
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("text16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel2
            'Else
            '    'item.Override.NodeAppearance.Image = handRes.getIcon("text16.ico")
            '    item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel2
            'End If

            'item.Override.NodeAppearance.Image = Global.PMDS.plan.archiv.My.Resources.Resources.ICO_zettel2

        Catch ex As Exception
            Throw New Exception("getIcontForFileTyp: " + ex.ToString())
        End Try
    End Function


End Class
