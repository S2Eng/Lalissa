'Imports Microsoft.Win32
'Imports System.IO
'Imports System.Xml
'Imports System
'Imports Microsoft.VisualBasic
'Imports System.Windows.Forms
'Imports System.Data.OleDb




'Public Class clObject
'    Public id As String = ""
'    Public bezeichnung As String = ""
'    Public ok As Boolean = False
'End Class




'Public Class General
'    Inherits Object





'    Public IDMail As New System.Guid("{11111111-1111-1111-1111-111111111115}")
'    Public IDTermin As New System.Guid("{11111111-1111-1111-1111-111111111112}")
'    Public IDTermin2 As New System.Guid("{11111111-1111-1111-1111-111111111113}")

'    Public EmptyGuid As System.Guid = Nothing

'    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32



'    Public Class clAnhang
'        Public datei As String = ""
'        Public IDDokumenteneintrag As New System.Guid
'        Public Anhang As Boolean = False
'        Public NochSpeichern As Boolean = False
'        Public löschen As Boolean = False
'        Public bezeichnung As String = ""
'        Public dateiAusArchiv As Boolean = False

'        Public Sub New()
'            IDDokumenteneintrag = Nothing
'        End Sub
'    End Class



'    Public Function SelectSaveFileDialog(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String, ByVal InitialDirectory As String) As String
'        Try

'            If withDefaultTypes Then
'                DateiTyp = ("All Files (*.*)|*.*|" + _
'                            "Microsoft Word Files (*.doc)|*.doc|" + _
'                            "Microsoft Excel Files (*.xls)|*.xls|" + _
'                            "Text Files (*.txt)|*.txt|" + _
'                            "pdf Files (*.pdf)|*.pdf|" + _
'                            "rtf Files (*.Rtf)|*.rtf")
'            End If

'            Dim SaveFileDialog As New SaveFileDialog
'            Dim File As String
'            Dim Pfad As String

'            SaveFileDialog.InitialDirectory = InitialDirectory

'            SaveFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
'            SaveFileDialog.FilterIndex = 1
'            SaveFileDialog.RestoreDirectory = True

'            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
'                File = SaveFileDialog.FileName
'                If Not Me.IsNull(File) Then
'                    Dim StringOperate As New clStringOperate
'                    Return File
'                End If
'            End If

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try

'    End Function

'    Public Enum eTypPlanung
'        termin = 0
'        mail = 1
'    End Enum

'    Public Enum eTypMail
'        an = 0
'        cc = 1
'        bcc = 2
'    End Enum

'    Public Enum InitApplicationAufgabenTermine

'        Posteingang = 600
'        Postausgang = 601
'        PosteingangPostausgang = 602

'        nachrichtAnzeigen = 640
'        terminNeu = 661
'        mailNeu = 703

'    End Enum

'    Public Enum eStatusForm
'        neu = 1
'        edit = 5
'    End Enum

'    Public Enum eAuswahlStatusMail
'        gesendet = 0
'        entwürfe = 1
'        alle = 2
'    End Enum


'    Public Function IsNullDate(ByVal Dat As Object) As Boolean
'        Try
'            If IsNull(Dat) Then
'                Return True
'            End If

'            'If Dat.Year = 1 And Dat.Month = 1 And Dat.Day = 1 Then
'            '    IsNullDate = True
'            'Else
'            '    IsNullDate = False
'            'End If

'        Catch ex As Exception
'            GetEcxeptionGeneral(ex)
'            Return True
'        Finally
'        End Try
'    End Function

'    Public Sub GetEcxeptionGeneral(ByVal ex As Exception)
'        PMDS.Global.ENV.HandleException(ex)
'    End Sub


'    Public Function IsNull(ByVal Obj As Object) As Boolean
'        Try

'            IsNull = True

'            If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                IsNull = True
'            Else
'                If Obj.GetType.ToString = "System.Guid" Then
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        IsNull = True
'                    Else
'                        If Obj.ToString = EmptyGuid.ToString Then
'                            IsNull = True
'                        Else
'                            IsNull = False
'                        End If
'                    End If
'                ElseIf Obj.GetType.ToString = "System.String" Then
'                    If Object.Equals(Nothing, Trim(Obj)) Or Object.Equals(System.DBNull.Value, Trim(Obj)) Or Object.Equals("", Trim(Obj)) Then
'                        IsNull = True
'                    Else
'                        If Obj.ToString = EmptyGuid.ToString Then
'                            IsNull = True
'                        Else
'                            IsNull = False
'                        End If
'                    End If
'                ElseIf Obj.GetType.ToString = "System.DateTime" Then
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        IsNull = True
'                    Else
'                        If Obj.Year = 1 And Obj.Month = 1 And Obj.Day = 1 Then
'                            IsNull = True
'                        Else
'                            IsNull = False
'                        End If
'                    End If
'                Else
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        IsNull = True
'                    Else
'                        IsNull = False
'                    End If
'                End If
'            End If

'        Catch ex As Exception
'            GetEcxeptionGeneral(ex)
'        Finally
'        End Try

'    End Function
'    Public Function CheckIsNull(ByVal Obj As Object) As Object
'        Try

'            If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                Return Nothing
'            Else
'                If Obj.GetType.ToString = "System.Guid" Then
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        Return Nothing
'                    Else
'                        If Obj.ToString = EmptyGuid.ToString Then
'                            Return Nothing
'                        Else
'                            Return Obj
'                        End If
'                    End If
'                ElseIf Obj.GetType.ToString = "System.DateTime" Then
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        Return Nothing
'                    Else
'                        If Obj.Year = 1 And Obj.Month = 1 And Obj.Day = 1 Then
'                            Return Nothing
'                        Else
'                            Return Obj
'                        End If
'                    End If
'                Else
'                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
'                        Return Nothing
'                    Else
'                        Return Obj
'                    End If
'                End If
'            End If

'        Catch ex As Exception
'            GetEcxeptionGeneral(ex)
'        Finally
'        End Try

'    End Function
'    Public Function CheckDateNull(ByVal Dat As Date) As Object
'        Try

'            If Me.IsNull(Dat) Then Return Nothing

'            If Dat < #1/1/0010# Then
'                CheckDateNull = Nothing
'            Else
'                CheckDateNull = Dat
'            End If

'        Catch ex As Exception
'            GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Function

'    Public Sub GarbColl()
'        System.GC.Collect(GC.MaxGeneration)
'    End Sub

'    Public Function GetConnectionString(ByVal Server As String, ByVal Database As String, ByVal User As String, ByVal Password As String) As String
'        Try

'            Return "User ID=" + Trim(User) + ";" + "Password=" + Trim(Password) + ";" + _
'            "Tag with column collation when possible=False;Data Source=" + Trim(Server) + ";" + _
'            ";Initial Catalog=" + Trim(Database) + ";" + _
'            "Use Procedure for Prepare=1;Auto Translate=True;" & _
'            "Persist Security Info=True;Provider=""SQLOLEDB.1"";Workstation ID=" + Trim(Server) + ";" + _
'            "Use Encryption for Data=False;Packet Size=32767;Connect Timeout=0;OLE DB Services= -2;"

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Function
'    Public Function ReadKeyLocalMachine2(ByVal PathSearch As String, ByVal keySearch As String) As GetSubkey
'        Try
'            Dim res As New GetSubkey
'            Dim value As String
'            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(PathSearch, True)
'            res.Result = (CType(rk.GetValue(keySearch), String))
'            res.KeyExists = True
'            Return res

'        Catch ex As Exception
'            Dim res As New GetSubkey
'            'Me.GetEcxeption(ex)
'            Return res
'        Finally
'        End Try
'    End Function
'    Public Class GetSubkey
'        Public Result As String = ""
'        Public KeyExists As Boolean = False
'    End Class



'    Public Function StrToGuid(ByVal ID_str As String) As System.Guid
'        Try

'            If Not Me.IsNull(ID_str) Then
'                Try
'                    Dim ID As New System.Guid(ID_str)
'                    Return ID
'                Catch ex As Exception
'                    Return Nothing
'                End Try
'            Else
'                Return Nothing
'            End If

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'            Return Nothing
'        Finally
'        End Try
'    End Function
'    Public Function GuidToStr(ByVal ID As System.Guid) As String
'        Try

'            Return ID.ToString

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'            Return Nothing
'        Finally
'        End Try
'    End Function


'    Public Function SelectFile(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String) As String
'        Try

'            If withDefaultTypes Then
'                DateiTyp = ("All Files (*.*)|*.*|" + _
'                            "Microsoft Word Files (*.doc)|*.doc|" + _
'                            "Microsoft Excel Files (*.xls)|*.xls|" + _
'                            "Text Files (*.txt)|*.txt|" + _
'                            "pdf Files (*.pdf)|*.pdf|" + _
'                            "rtf Files (*.Rtf)|*.rtf")
'            End If

'            Dim openFileDialog As New OpenFileDialog
'            Dim File As String
'            Dim Pfad As String

'            openFileDialog.InitialDirectory = ""
'            openFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
'            openFileDialog.FilterIndex = 1
'            openFileDialog.RestoreDirectory = True

'            If openFileDialog.ShowDialog() = DialogResult.OK Then
'                File = openFileDialog.FileName
'                If Not Me.IsNull(File) Then
'                    If System.IO.File.Exists(File) Then
'                        Return File
'                    End If
'                End If
'            End If

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try

'    End Function

'    Public Sub SetProcessingWorkSizexy()
'        Try
'            Me.SetProcessWorkingSetSize(Diagnostics.Process.GetCurrentProcess.Handle, -1, -1)

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Sub

'    Public Function ClearOrdnerTEMP() As Boolean
'        Try
'            Dim datLastDel As Date
'            Dim bLöschen As Boolean = False

'            Dim allFiles() As String
'            allFiles = System.IO.Directory.GetFiles(PMDS.Global.ENV.path_Temp)
'            For Each f As String In allFiles
'                Try
'                    System.IO.File.Delete(f)
'                Catch ex As Exception
'                Finally
'                End Try
'            Next
'            Return True

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Function

'    Public Function ImageToIcon(ByVal SourceImage As System.Drawing.Image) As System.Drawing.Icon
'        Dim TempBitmap As New System.Drawing.Bitmap(SourceImage)
'        Return System.Drawing.Icon.FromHandle(TempBitmap.GetHicon())
'    End Function


'    Public Sub PostboxAlleBenutzerErstellenxy()
'        Try
'            'Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
'            'Dim dt As New DataTable
'            'dt = ben.AllEntries
'            'If dt.Rows.Count > 0 Then
'            '    For Each r As DataRow In dt.Rows
'            '        Dim u As New PMDS.BusinessLogic.Benutzer(r("ID"))
'            '        If Not System.IO.Directory.Exists(General.path_Postbox + "\" + u.BenutzerName) Then
'            '            System.IO.Directory.CreateDirectory(General.path_Postbox + "\" + u.BenutzerName)
'            '        End If
'            '        'u.HasRight(UserRights.ManageBaseData)
'            '    Next
'            'Else
'            '    MsgBox("Es existieren keine Benutzer!", MsgBoxStyle.Information, "PMDS")
'            '    Exit Sub
'            'End If

'            'System.IO.Directory.CreateDirectory(General.path_Postbox + "\AllgemeinePostbox")
'            'MsgBox("Für alle Benutzer wurde eine Postbox erstellt!", MsgBoxStyle.Information, "PMDS")

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Sub

'    Public Function getAllUserCbo(ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor) As Boolean
'        Try
'            cbo.Items.Clear()
'            Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
'            Dim dt As New DataTable
'            dt = ben.AllEntries
'            For Each r As DataRow In dt.Rows
'                Dim u As New PMDS.BusinessLogic.Benutzer(r("ID"))
'                cbo.Items.Add(u.BenutzerName, u.BenutzerName)
'            Next

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Function

'    Public Function OpenPostboxExplorer() As Boolean
'        Try
'            If System.IO.Directory.Exists(PMDS.Global.ENV.path_meinePostbox) Then
'                Shell("explorer " + Chr(34) + PMDS.Global.ENV.path_meinePostbox + Chr(34), AppWinStyle.NormalFocus)
'                Return True
'            Else
'                MsgBox("Postbox existiert nicht!", MsgBoxStyle.Information, "PMDS")
'            End If

'        Catch ex As Exception
'            Me.GetEcxeptionGeneral(ex)
'        Finally
'        End Try
'    End Function

'    Public Function actUser() As String
'        Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
'        Return ben.BenutzerName

'    End Function
'    Public Function userIsAdminxy() As Boolean
'        'Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
'        'Return ben.HasRight([Global].UserRights.ManageBaseData)
'        Return True
'    End Function


'    Public Function getPatientName(ByVal idpatient As System.Guid) As String

'        Dim pat As New PMDS.BusinessLogic.Patient(idpatient)
'        Return pat.Vorname + " " + pat.Nachname

'    End Function


'End Class


