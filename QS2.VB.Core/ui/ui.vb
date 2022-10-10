Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win


Public Class ui


    Public Shared Sub loadStyleInfrag(bUserdefined As Boolean, loadDefaultStyle As String, app As String)
        Try
            If qs2.core.ENV.ColorSchema = 1 Then
                Infragistics.Win.AppStyling.StyleManager.Load(System.IO.Path.Combine(core.ENV.path_config, "Dark.isl"))
            ElseIf qs2.core.ENV.ColorSchema = 2 Then
                Infragistics.Win.AppStyling.StyleManager.Load(System.IO.Path.Combine(core.ENV.path_config, "Light.isl"))
            End If

        Catch ex As Exception
            Throw New Exception("loadStyleInfrag: " + ex.ToString())
        End Try
    End Sub
    Public Shared Sub getWatchProtokoll()
        Try
            Dim frmProtocol1 As New qs2.core.vb.frmProtocol()
            frmProtocol1.ContProtocol1.TypeProtocolWindow = contProtocol.eTypeProtocolWindow.protocol
            frmProtocol1.initControl()

            frmProtocol1.ContProtocol1.lblTitleError.Visible = True
            frmProtocol1.ContProtocol1.pictureBoxError.Visible = True
            frmProtocol1.Text = "Protocol Watch Functions"
            frmProtocol1.Show()
            frmProtocol1.ContProtocol1.setText(qs2.core.ui.watchResult.Trim())

            qs2.core.ui.watchResult = ""

        Catch ex As Exception
            Throw New Exception("getWatchProtokoll: " + ex.ToString())
        End Try
    End Sub

    Public Shared Function loadImagesFromRessources(cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                                                     ValueListToLoad As Infragistics.Win.ValueList) As Boolean

        ValueListToLoad.ValueListItems.Clear()

        Dim eAllgemein As New qs2.Resources.getRes.Allgemein
        ui.getEnumAsList(eAllgemein.GetType(), ValueListToLoad, cbo, False)

        Dim eAllgemein2 As New qs2.Resources.getRes.Allgemein2
        ui.getEnumAsList(eAllgemein2.GetType(), ValueListToLoad, cbo, False)

        Dim eLauncher As New qs2.Resources.getRes.Launcher
        ui.getEnumAsList(eLauncher.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Abrechnung As New qs2.Resources.getRes.PMDS_Abrechnung
        ui.getEnumAsList(ePMDS_Abrechnung.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Intervention As New qs2.Resources.getRes.PMDS_Intervention
        ui.getEnumAsList(ePMDS_Intervention.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Klientenakt As New qs2.Resources.getRes.PMDS_Klientenakt
        ui.getEnumAsList(ePMDS_Klientenakt.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_Klientenliste As New qs2.Resources.getRes.PMDS_Klientenliste
        ui.getEnumAsList(ePMDS_Klientenliste.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_MedizinischeTypen As New qs2.Resources.getRes.PMDS_MedizinischeTypen
        ui.getEnumAsList(ePMDS_MedizinischeTypen.GetType(), ValueListToLoad, cbo, False)

        Dim ePMDS_TouchDoku As New qs2.Resources.getRes.PMDS_TouchDoku
        ui.getEnumAsList(ePMDS_TouchDoku.GetType(), ValueListToLoad, cbo, False)

        Return True

    End Function
    Public Shared Function getEnumAsList(ByRef typEnum As Type,
                                  ByRef valList As Infragistics.Win.ValueList,
                                  ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                                  ByRef clearLists As Boolean) As System.Collections.Generic.List(Of String)

        If clearLists Then
            If Not valList Is Nothing Then
                valList.ValueListItems.Clear()
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Clear()
            End If
        End If

        Dim result As New System.Collections.Generic.List(Of String)()
        For Each val As Integer In [Enum].GetValues(typEnum)
            Dim strEnum As String = [Enum].GetName(typEnum, val)
            result.Add(strEnum)
            If Not valList Is Nothing Then
                valList.ValueListItems.Add(strEnum, strEnum)
            End If
            If Not cbo Is Nothing Then
                Dim itm As Infragistics.Win.ValueListItem = cbo.Items.Add(strEnum, strEnum)
            End If
        Next
        Return result

    End Function


    Public Shared Function ExportGridToXml(grid As UltraGrid, DsToExport As DataSet) As Boolean
        Try
            Dim funct1 As New funct()
            Dim fileSelected As String = funct1.SaveFileDialog("Xml-Files (*.Xml)|*.xml", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "")
            If fileSelected.Trim() <> "" Then
                Dim xsdFile As String = fileSelected.Substring(0, fileSelected.Length - 3) + ".xsd"
                DsToExport.WriteXml(fileSelected)
                DsToExport.WriteXmlSchema(xsdFile)
                grid.Refresh()

                Microsoft.VisualBasic.Interaction.MsgBox("Data exported!", MsgBoxStyle.Information, "Export data")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("ui.ExportGridToXml: " + ex.ToString())
        End Try
    End Function

    Public Shared Function ImportGridToXml(grid As UltraGrid, DsToImport As DataSet) As Boolean
        Try
            Dim funct1 As New funct()
            Dim fileSelected As String = funct1.SelectFileDialog("Xml-Files (*.Xml)|*.xml", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            If fileSelected.Trim() <> "" Then
                Dim xsdFile As String = fileSelected.Substring(0, fileSelected.Length - 3) + ".xsd"
                DsToImport.ReadXml(fileSelected)
                DsToImport.ReadXmlSchema(xsdFile)
                grid.Refresh()

                Microsoft.VisualBasic.Interaction.MsgBox("Data imported!", MsgBoxStyle.Information, "Import data")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("ui.ImportGridToXml: " + ex.ToString())
        End Try
    End Function


    Public Shared Sub gridLayoutGrid_SelectionDrag(sender As Object, e As ComponentModel.CancelEventArgs)
        Try
            Dim grid As UltraGrid = sender
            grid.DoDragDrop(grid.Selected.Rows, Windows.Forms.DragDropEffects.Move)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Shared Sub gridLayoutGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs)
        Try
            e.Effect = Windows.Forms.DragDropEffects.Move
            Dim grid As UltraGrid = TryCast(sender, UltraGrid)
            Dim pointInGridCoords As System.Drawing.Point = grid.PointToClient(New System.Drawing.Point(e.X, e.Y))

            If pointInGridCoords.Y < 20 Then
                'Scroll up
                grid.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
            ElseIf pointInGridCoords.Y > grid.Height - 20 Then
                'Scroll down
                grid.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Shared Sub gridLayoutGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs, ByRef SelRows As SelectedRowsCollection,
                                               ByRef ugrOver As UltraGridRow)
        Try
            Dim grid As UltraGrid = sender
            Dim dropIndex As Integer
            Dim uieOver As UIElement = grid.DisplayLayout.UIElement.ElementFromPoint(grid.PointToClient(New System.Drawing.Point(e.X, e.Y)))

            ugrOver = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

            If ugrOver IsNot Nothing Then
                dropIndex = ugrOver.Index    'index/position of drop zone in grid 

                SelRows = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
                For Each aRow As UltraGridRow In SelRows
                    grid.Rows.Move(aRow, dropIndex)
                    grid.UpdateData()
                Next
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
