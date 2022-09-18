Imports Infragistics.Win.UltraWinGrid



Public Class AddIn

    Public compAddInsWork As New sqlAddIns()
    Public gen As New generic()

    Public Enum eGroupsAddIns
        Queries = 90100
        ProductUI = 90101
        generic = 90102
    End Enum

    Public funct1 As New qs2.core.vb.funct()




    Public Sub initControl()
        Try


        Catch ex As Exception
            Throw New Exception("AddIn.initControl" + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Sub searchAddInsInFolders(grid As UltraGrid, dsAddInFound As dsAddIn)
        Try
            dsAddInFound.Clear()
            For Each fileAddInFound As String In System.IO.Directory.GetFiles(ENV.path_config)
                Me.loadAddIns(dsAddInFound, fileAddInFound)
            Next
            Me.searchInSubfolders_rek(dsAddInFound, ENV.path_config)
            For Each dirToSearchAddIn As String In ENV.path_AddInsDevelop
                For Each fileAddInFound As String In System.IO.Directory.GetFiles(dirToSearchAddIn)
                    Me.loadAddIns(dsAddInFound, fileAddInFound)
                Next
            Next
            If Not grid Is Nothing Then
                grid.Refresh()
            End If

        Catch ex As Exception
            Throw New Exception("AddIn.loadAddIns" + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub searchInSubfolders_rek(dsAddInFound As dsAddIn, dirToSearch As String)
        Try
            For Each subDirectory As String In System.IO.Directory.GetDirectories(dirToSearch)
                For Each fileAddInFoundInSubDir As String In System.IO.Directory.GetFiles(subDirectory)
                    Me.loadAddIns(dsAddInFound, fileAddInFoundInSubDir)
                Next
                Me.searchInSubfolders_rek(dsAddInFound, subDirectory)
            Next

        Catch ex As Exception
            Throw New Exception("AddIn.loadAddIns" + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub loadAddIns(dsAddInFound As dsAddIn, fileAddInFound As String)
        Try
            Dim typeFile As String = LCase(Microsoft.VisualBasic.Right(fileAddInFound, 4))
            If typeFile.ToLower() = (".dll").ToLower() Then
                Dim fileName As String = Me.funct1.getFileName(fileAddInFound, True)
                If fileName.Contains("qs2.AddIn.") Then
                    Dim rNewAddIn As dsAddIn.AddInsRow = Me.compAddInsWork.newRowAddIn(dsAddInFound)
                    rNewAddIn.AddInName = fileName
                    rNewAddIn.Dll = fileAddInFound
                    rNewAddIn.Type = typeFile
                    rNewAddIn.Description = "Generic QS2-AddIn"
                    rNewAddIn.Group = eGroupsAddIns.generic.ToString()

                    'Dim dsAddInCheck As New dsAddIn()
                    'Dim sqlAddInsCheck As New sqlAddIns()
                    'sqlAddInsCheck.getAddIn(Nothing, dsAddInCheck, sqlAddIns.eTypSelAddIn.AddInName, fileName)
                    'If dsAddInCheck.AddIns.Rows.Count = 1 Then

                    'ElseIf dsAddInCheck.AddIns.Rows.Count > 1 Then
                    '    Throw New Exception("loadAddIns: AddIn '" + fileName + "' is more than once in Db saved!")
                    'End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("AddIn.loadAddIns" + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Sub testAddIns(dsAddInFound As dsAddIn, withMsgBox As Boolean)
        Try
            For Each rAddIn As dsAddIn.AddInsRow In dsAddInFound.AddIns
                Me.testAddIn(rAddIn, withMsgBox)
            Next

        Catch ex As Exception
            Throw New Exception("AddIn.testAddIns" + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Function testAddIn(rSelAddIn As dsAddIn.AddInsRow, withMsgBox As Boolean) As Boolean
        Try
            If Me.runAddIn(rSelAddIn) Then
                If withMsgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("TestAddInSuccessfull") + "!", Windows.Forms.MessageBoxButtons.OK, "AddIn")
                End If
                Return True
            Else
                Throw New Exception("AddIn.testAddIn: Error testing AddIn '" + rSelAddIn.AddInName + "'!")
            End If

        Catch ex As Exception
            Throw New Exception("testAddIn.testAddIns" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function runAddIn(rSelAddIn As dsAddIn.AddInsRow) As Boolean
        Try
            Dim assemblyLoaded As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(rSelAddIn.Dll)
            If Me.initAddIn(assemblyLoaded) Then
                Dim assemblyClassLoaded As Object = assemblyLoaded.CreateInstance("qs2.AddIn.runAddIn")
                Dim RefType As Type = assemblyClassLoaded.GetType()

                Dim MethodInfo As System.Reflection.MethodInfo = RefType.GetMethod("test")

                ' Parameters for Function
                Dim parLst(0) As Object
                'Dim ds As New DataSet
                'Dim dt As New DataTable("xy")
                'ds.Tables.Add(dt)
                'parLst(0) = ds

                Dim oRes As String = MethodInfo.Invoke(assemblyClassLoaded, Nothing)
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("AddIn.runAddIn" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function initAddIn(assemblyLoaded As System.Reflection.Assembly) As Boolean
        Try
            Dim bOk As Boolean = False

            Dim assemblyClassLoaded As Object = assemblyLoaded.CreateInstance("qs2.AddIn.initAddIn")
            Dim RefType As Type = assemblyClassLoaded.GetType()

            Dim MethodInfo As System.Reflection.MethodInfo = RefType.GetMethod("init")

            ' Parameters for Function
            Dim parLst(0) As Object
            parLst(0) = ENV.fileConfig
            bOk = MethodInfo.Invoke(assemblyClassLoaded, parLst)
            Return bOk

        Catch ex As Exception
            Throw New Exception("AddIn.runAddIn" + vbNewLine + ex.ToString())
        End Try
    End Function

End Class
