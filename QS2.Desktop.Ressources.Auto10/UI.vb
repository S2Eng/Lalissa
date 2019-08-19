Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System

Imports System.Text
Imports Microsoft.VisualBasic

Imports Microsoft.Win32
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win




Public Class UI

    Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal nVirtKey As System.Windows.Forms.Keys) As Short
    Public Const VK_LBUTTON As Long = &H1 'Left mouse button





    Public Shared AllFileTypes As String = ("All Files (*.*)|*.*|" + _
                                    "Microsoft Word Files (*.doc)|*.doc|" + _
                                    "Microsoft Excel Files (*.xls)|*.xls|" + _
                                    "Text Files (*.txt)|*.txt|" + _
                                    "pdf Files (*.pdf)|*.pdf|" + _
                                    "rtf Files (*.Rtf)|*.rtf")




    Public Shared Function IsKeyPressed(ByVal vKey As System.Windows.Forms.Keys) As Boolean
        Return (GetAsyncKeyState(vKey) And &H8000) = &H8000
    End Function

    Public Function getEnumAsList(ByRef typEnum As Type, _
                                  ByRef valList As Infragistics.Win.ValueList, _
                                  ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor, _
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


    Public Function readByteStreamFile(ByVal file As String) As Byte()

        ' Read File into byte Array
        Dim fs As New System.IO.FileStream(file, FileMode.Open, FileAccess.Read)
        Dim r As New BinaryReader(fs)
        Dim fileByte(fs.Length) As Byte
        fileByte = r.ReadBytes(fs.Length)
        fs.Close()
        r.Close()
        Return fileByte

    End Function
    Public Function GetFiletyp(ByVal File As String) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, ".", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Return Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - ((pos_Prev) - 1))
        Else
            Return ""
        End If

    End Function

    Public Function saveFileFromBytes(ByVal fileToSave As String, ByVal byteStream() As Byte, ByVal msgBox As Boolean) As Boolean

        Dim fileTyp As String = Me.GetFiletyp(fileToSave)
        Dim dirToSave As String = Me.GetDir(fileToSave)
        Dim fileName As String = Me.GetFileName(fileToSave, True)
        Me.saveFileFromBytes(fileToSave, byteStream)
        Return True

    End Function
    Public Function saveFileFromBytes(ByVal fileToSave As String, ByVal byteStream() As Byte) As Boolean

        'Dim file As String = Me.GetFileName(path, True)
        Dim fs As IO.FileStream = New IO.FileStream(fileToSave, IO.FileMode.Create)
        Dim b() As Byte = byteStream
        fs.Write(b, 0, b.Length)
        fs.Close()
        Return True

    End Function

    Public Function GetFileName(ByVal File As String, ByVal ohneEndung As Boolean) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Dim sName As String = Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - (pos_Prev))
            If ohneEndung Then
                sName = Me.GetFileName_ohneTyp(sName)
            End If
            Return sName
        Else
            Return ""
        End If

    End Function

    Public Function GetFileName_ohneTyp(ByVal sName As String) As String

        If sName = "" Then Return sName

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, sName, ".", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Return Microsoft.VisualBasic.Left(sName, pos_Prev - 1)
        Else
            Return ""
        End If

    End Function

    Public Function GetDir(ByVal File As String) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Return Microsoft.VisualBasic.Left(File, pos_Prev)
        Else
            Return ""
        End If

    End Function

    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean, _
                        ByVal withMsgBox As Boolean) As Boolean

        If System.IO.File.Exists(file) Then
            Dim dateiTemp As String = ""
            If openTemporär Then
                Dim IDNewFileNameTemp As New System.Guid
                IDNewFileNameTemp = System.Guid.NewGuid
                dateiTemp = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + IDNewFileNameTemp.ToString + dateiTyp
                System.IO.File.Copy(file, dateiTemp)
            Else
                dateiTemp = file
            End If
            If Me.IsNull(dateiTyp) Then
                dateiTyp = Me.GetFiletyp(file)
            End If

            System.Diagnostics.Process.Start(file)
            Return True

        Else
            If withMsgBox Then
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("File does not exist!", MsgBoxStyle.Information, "Open file")
            End If
            Return False
        End If

    End Function



    Public Function setFilter(ByVal col As String, ByVal oper As FilterLogicalOperator, _
                      ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator, _
                      ByVal grid As UltraGrid, ByVal bandIndex As Integer)

        Dim condition As FilterCondition
        grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.Or
        grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
        condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.Contains, filterVal)

    End Function
    Public Function clearAllFilter(ByVal grid As UltraGrid)
        For Each band As UltraGridBand In grid.DisplayLayout.Bands
            For Each colFilter As ColumnFilter In band.ColumnFilters
                colFilter.ClearFilterConditions()
            Next
        Next
    End Function

    Public Sub setFilterGridKomplex(ByRef grd As UltraGrid, ByVal bIsOn As Boolean, ByVal doSplitterFunctions As Boolean)

        If bIsOn Then
            grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grd.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden
            grd.DisplayLayout.Override.FilterRowPrompt = "Click here to filter data"
            grd.DisplayLayout.Override.FilterRowAppearance.ForeColor = System.Drawing.Color.DarkGray
            grd.DisplayLayout.Override.FilterRowAppearance.BackColor = System.Drawing.Color.White
            grd.DisplayLayout.Override.FilterRowAppearance.FontData.Bold = DefaultableBoolean.False
            grd.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo
            grd.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.Row
            grd.DisplayLayout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Contains
            grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grd.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
            grd.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.None
            'grd.DisplayLayout.Override.GroupByColumnsHidden = DefaultableBoolean.Default
            'grd.DisplayLayout.Override.GroupByRowExpansionStyle = GroupByRowExpansionStyle.Default
            'grd.DisplayLayout.Override.GroupByRowInitialExpansionState = GroupByRowInitialExpansionState.Default
            '      grd.DisplayLayout.Override.GroupBySummaryDisplayStyle = 
            grd.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            ' grd.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.LightSteelBlue
            Me.setMergeStyle(grd, True, doSplitterFunctions)
            'grd.DisplayLayout.Override.FilterRowPromptAppearance.FontData.SizeInPoints = 10
            grd.DisplayLayout.Override.FilterRowPromptAppearance.ForeColor = System.Drawing.Color.DarkGray

        Else
            grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        End If

    End Sub

    Public Sub setMergeStyle(ByRef grd As UltraGrid, ByVal setMergeOn As Boolean, ByVal doSplitterFunctions As Boolean)

        If setMergeOn Then
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
            grd.DisplayLayout.Override.MergedCellAppearance.BackColor = System.Drawing.Color.Beige
        Else
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
        End If

        grd.DisplayLayout.Override.RowSizing = RowSizing.Free
        grd.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True

        If doSplitterFunctions Then
            grd.DisplayLayout.MaxColScrollRegions = 2
            grd.DisplayLayout.MaxRowScrollRegions = 2
        Else
            grd.DisplayLayout.MaxColScrollRegions = 1
            grd.DisplayLayout.MaxRowScrollRegions = 1
        End If

    End Sub

    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String
        Dim SaveFileD As New SaveFileDialog
        Dim File As String
        Dim Pfad As String

        SaveFileD.InitialDirectory = rootVerzeichnis
        SaveFileD.Filter = DateiTyp
        SaveFileD.FilterIndex = 1
        SaveFileD.RestoreDirectory = True

        If SaveFileD.ShowDialog() = DialogResult.OK Then
            File = SaveFileD.FileName
            Return File
        End If

    End Function

    Public Function getFileTypForDialog(ByVal typFile As String) As String
        Return "*" + typFile + "|*" + typFile

    End Function
    Public Function SelectFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String
        Dim openFileDialog As New OpenFileDialog
        Dim File As String
        Dim Pfad As String
        openFileDialog.InitialDirectory = ""
        If Not Me.IsNull(rootVerzeichnis) And System.IO.Directory.Exists(rootVerzeichnis) Then
            openFileDialog.InitialDirectory = rootVerzeichnis
        End If
        openFileDialog.Filter = DateiTyp
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = True
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            File = openFileDialog.FileName
            Return File
        End If
        Return ""
    End Function

    Public Function IsNull(ByVal Obj As Object) As Boolean

        IsNull = True

        If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
            IsNull = True
        Else
            If Obj.GetType.ToString = "System.Guid" Then
                If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                    IsNull = True
                Else
                    If Obj.ToString = System.Guid.Empty.ToString Then
                        IsNull = True
                    Else
                        IsNull = False
                    End If
                End If
            ElseIf Obj.GetType.ToString = "System.String" Then
                If Object.Equals(Nothing, Trim(Obj)) Or Object.Equals(System.DBNull.Value, Trim(Obj)) Or Object.Equals("", Trim(Obj)) Then
                    IsNull = True
                Else
                    If Obj.ToString = System.Guid.Empty.ToString Then
                        IsNull = True
                    Else
                        IsNull = False
                    End If
                End If
            ElseIf Obj.GetType.ToString = "System.DateTime" Then
                If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                    IsNull = True
                Else
                    If Obj.Year = 1 And Obj.Month = 1 And Obj.Day = 1 Then
                        IsNull = True
                    Else
                        IsNull = False
                    End If
                End If
            Else
                If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                    IsNull = True
                Else
                    IsNull = False
                End If
            End If
        End If

    End Function

    Public Function evDoubleClickOK(sender As Object, ev As EventArgs, grid As UltraGrid) As Boolean
        If Not grid.DisplayLayout.UIElement.LastElementEntered Is Nothing Then
            If grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) And _
                grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) And _
                grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement) Then

                Return True
            End If
        End If
        Return False
    End Function
    Public Function evClickOK(sender As Object, ev As EventArgs, grid As UltraGrid) As Boolean
        If Not grid.DisplayLayout.UIElement.LastElementEntered Is Nothing Then
            If grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) And _
                grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) And _
                grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) And _
                grid.DisplayLayout.UIElement.LastElementEntered.GetType() <> GetType(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement) Then

                Return True
            End If
        End If
        Return False
    End Function



End Class
