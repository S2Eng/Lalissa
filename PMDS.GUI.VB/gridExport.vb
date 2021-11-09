Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree
Imports System.Drawing

Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid



Public Class gridExport

    Public gen As New GeneralArchiv

    Public Enum eTyp
        excel = 0
        pdf = 1
        xps = 2
        csv = 3
    End Enum






    Public Function exportGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal typ As eTyp,
                               ByVal dsToExport As System.Data.DataSet, ByVal TableNameToExport As String,
                               ByVal lstColsNotExport As System.Collections.Generic.List(Of String),
                               ByVal columnCheckIfRowExport As String, ByVal ExportPath As String) As Boolean
        Try
            Dim clFold As New GeneralArchiv
            Dim filName As String = ""
            If typ = eTyp.excel Then
                filName = clFold.SelectSaveFileDialog(False, "Microsoft Excel Dateien (*.xls)|*.xls", ExportPath)
            ElseIf typ = eTyp.pdf Then
                filName = clFold.SelectSaveFileDialog(False, "Acrobat Reader Dateien (*.pdf)|*.pdf", ExportPath)
            ElseIf typ = eTyp.xps Then
                filName = clFold.SelectSaveFileDialog(False, "XPS Dateien (*.xps)|*.xps", ExportPath)
            ElseIf typ = eTyp.csv Then
                filName = clFold.SelectSaveFileDialog(False, "Csv Dateien (*.csv)|*.csv", ExportPath)
            End If
            If filName <> "" Then
                'If columnCheckIfRowExport.Trim() <> "" Then
                '    For Each rGrid As UltraGridRow In grid.Rows
                '        If rGrid.Cells(columnCheckIfRowExport.Trim()).Value = False Then
                '            rGrid.Hidden = True
                '            rGrid.Tag = "NoExport"
                '        End If
                '    Next
                'End If

                'grid.DataSource = dsToExport

                If typ = eTyp.excel Then
                    Me.UltraGridExcelExporter1.Export(grid, filName)
                ElseIf typ = eTyp.pdf Then
                    Me.UltraGridDocumentExporter1.Export(grid, filName, DocumentExport.GridExportFileFormat.PDF)
                ElseIf typ = eTyp.xps Then
                    Me.UltraGridDocumentExporter1.Export(grid, filName, DocumentExport.GridExportFileFormat.XPS)
                ElseIf typ = eTyp.csv Then
                    Dim exportCsv1 As New PMDS.Global.ExportCsv.exportCsv()
                    exportCsv1.doCSV(grid, Environment.SpecialFolder.DesktopDirectory, dsToExport, filName,
                                TableNameToExport, lstColsNotExport, columnCheckIfRowExport)
                End If

                'If columnCheckIfRowExport.Trim() <> "" Then
                '    For Each rGrid As UltraGridRow In grid.Rows
                '        If rGrid.Tag = "NoExport" Then
                '            rGrid.Hidden = False
                '        End If
                '    Next
                'End If

                If QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Daten wurden exportiert!" + vbNewLine +
                        "Soll die Datei geöffnet werden?", MsgBoxStyle.YesNo, "Export") = MsgBoxResult.Yes Then
                    If filName <> "" Then
                        Dim clOpenFile As New clFolder()
                        clOpenFile.openFile(filName, False)
                    End If
                End If
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("exportGrid: " + ex.ToString())
            Return ""
        End Try
    End Function

    Public Function printPreviewGrid(ByVal uref As Infragistics.Win.UltraWinGrid.UltraGrid) As Boolean
        Try
            Me.UltraGridPrintDocument1.Grid = uref
            Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
            Me.UltraPrintPreviewDialog1.ShowDialog(Me)

        Catch ex As Exception
            Throw New Exception("printPreviewGrid: " + ex.ToString())
            Return ""
        End Try
    End Function

End Class
