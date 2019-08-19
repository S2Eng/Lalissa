Imports System.IO
Imports System.Resources
Imports System.Xml
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.OleDb




Public Class GeneralArchiv

    Public Shared EmptyGuid As System.Guid = Nothing

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32


    Public Class clAnhang
        Public datei As String = ""
        Public IDDokumenteneintrag As New System.Guid
        Public Anhang As Boolean = False
        Public NochSpeichern As Boolean = False
        Public löschen As Boolean = False
        Public bezeichnung As String = ""
        Public dateiAusArchiv As Boolean = False

        Public Sub New()
            IDDokumenteneintrag = Nothing
        End Sub
    End Class







    Public Sub initRow(ByRef r As DataRow)
        Try
            Dim db1 As New db()
            db1.initRow(r)

        Catch ex As Exception
            Throw New Exception("initRow: " + ex.ToString())
        End Try
    End Sub

    Public Function proveDateTime(ByVal dat As System.DateTime) As Object
        Try

            Dim d As New System.DateTime
            If Me.IsNull(dat) Then
                Return Nothing
            Else
                Return dat
            End If

        Catch ex As Exception
            Throw New Exception("proveDateTime: " + ex.ToString())
        End Try
    End Function


    Public Function SelectSaveFileDialog(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String, ByVal InitialDirectory As String) As String
        Try

            If withDefaultTypes Then
                DateiTyp = ("All Files (*.*)|*.*|" +
                            "Microsoft Word Files (*.doc)|*.doc|" +
                            "Microsoft Excel Files (*.xls)|*.xls|" +
                            "Text Files (*.txt)|*.txt|" +
                            "pdf Files (*.pdf)|*.pdf|" +
                            "rtf Files (*.Rtf)|*.rtf")
            End If

            Dim SaveFileDialog As New Windows.Forms.SaveFileDialog
            Dim File As String
            Dim Pfad As String

            SaveFileDialog.InitialDirectory = InitialDirectory

            SaveFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
            SaveFileDialog.FilterIndex = 1
            SaveFileDialog.RestoreDirectory = True

            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                File = SaveFileDialog.FileName
                If Not Me.IsNull(File) Then
                    Dim StringOperate As New clStringOperate
                    Return File
                End If
            End If

        Catch ex As Exception
            Throw New Exception("SelectSaveFileDialog: " + ex.ToString())
        End Try
    End Function

    Public Enum eTypPlanung
        termin = 0
        mail = 1
    End Enum

    Public Enum eTypMail
        an = 0
        cc = 1
        bcc = 2
    End Enum

    Public Enum InitApplicationAufgabenTermine
        Posteingang = 600
        Postausgang = 601
        PosteingangPostausgang = 602

        nachrichtAnzeigen = 640
        terminNeu = 661
        mailNeu = 703

    End Enum

    Public Enum eStatusForm
        neu = 1
        edit = 5
    End Enum

    Public Enum eAuswahlStatusMail
        gesendet = 0
        entwürfe = 1
        alle = 2
    End Enum



    Public Sub GetEcxeptionGeneral(ByVal ex As Exception)
        PMDS.Global.ENV.HandleException(ex)
    End Sub

    Public Sub GetEcxeptionArchiv(ByVal ex As Exception)
        Me.GetEcxeptionGeneral(ex)
    End Sub

    Public Function IsNull(ByVal Obj As Object) As Boolean
        Try

            IsNull = True

            If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                IsNull = True
            Else
                If Obj.GetType.ToString = "System.Guid" Then
                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                        IsNull = True
                    Else
                        If Obj.ToString = EmptyGuid.ToString Then
                            IsNull = True
                        Else
                            IsNull = False
                        End If
                    End If
                ElseIf Obj.GetType.ToString = "System.String" Then
                    If Object.Equals(Nothing, Trim(Obj)) Or Object.Equals(System.DBNull.Value, Trim(Obj)) Or Object.Equals("", Trim(Obj)) Then
                        IsNull = True
                    Else
                        If Obj.ToString = EmptyGuid.ToString Then
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

        Catch ex As Exception
            Throw New Exception("IsNull: " + ex.ToString())
        End Try
    End Function

    Public Function CheckDateNull(ByVal Dat As Date) As Object
        Try

            If Me.IsNull(Dat) Then Return Nothing

            If Dat < #1/1/0010# Then
                CheckDateNull = Nothing
            Else
                CheckDateNull = Dat
            End If

        Catch ex As Exception
            Throw New Exception("CheckDateNull: " + ex.ToString())
        End Try
    End Function

    Public Sub GarbColl()
        'System.GC.Collect(GC.MaxGeneration)
    End Sub


    Public Function StrToGuid(ByVal ID_str As String) As System.Guid
        Try

            If Not Me.IsNull(ID_str) Then
                Try
                    Dim ID As New System.Guid(ID_str)
                    Return ID
                Catch ex As Exception
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("StrToGuid: " + ex.ToString())
        End Try
    End Function


    Public Function SelectFile(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String) As String
        Try

            If withDefaultTypes Then
                DateiTyp = ("All Files (*.*)|*.*|" +
                            "Microsoft Word Files (*.doc)|*.doc|" +
                            "Microsoft Excel Files (*.xls)|*.xls|" +
                            "Text Files (*.txt)|*.txt|" +
                            "pdf Files (*.pdf)|*.pdf|" +
                            "rtf Files (*.Rtf)|*.rtf")
            End If

            Dim openFileDialog As New Windows.Forms.OpenFileDialog
            Dim File As String
            Dim Pfad As String

            openFileDialog.InitialDirectory = ""
            openFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                File = openFileDialog.FileName
                If Not Me.IsNull(File) Then
                    If System.IO.File.Exists(File) Then
                        Return File
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("SelectFile: " + ex.ToString())
        End Try
    End Function

    Public Function ClearOrdnerTEMP() As Boolean
        Try
            Dim datLastDel As Date
            Dim bLöschen As Boolean = False

            Dim allFiles() As String

            If Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                allFiles = System.IO.Directory.GetFiles(PMDS.Global.ENV.path_Temp)
                For Each f As String In allFiles
                    Try
                        System.IO.File.Delete(f)
                    Catch ex As Exception
                        'Ignore
                    Finally
                    End Try
                Next
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("ClearOrdnerTEMP: " + ex.ToString())
        End Try
    End Function


    Public Function getAllUserCbo(ByRef cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor) As Boolean
        Try
            cbo.Items.Clear()
            Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
            Dim dt As New DataTable
            dt = ben.AllEntries
            For Each r As DataRow In dt.Rows
                Dim u As New PMDS.BusinessLogic.Benutzer(r("ID"))
                cbo.Items.Add(u.BenutzerName, u.BenutzerName)
            Next

        Catch ex As Exception
            Throw New Exception("getAllUserCbo: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function OpenPostboxExplorer() As Boolean
        Try
            If System.IO.Directory.Exists(PMDS.Global.ENV.path_Temp) Then
                Shell("explorer " + Chr(34) + PMDS.Global.ENV.path_Temp + Chr(34), AppWinStyle.NormalFocus)
                Return True
            Else
                MsgBox("Postbox existiert nicht!", MsgBoxStyle.Information, "PMDS")
            End If

        Catch ex As Exception
            Throw New Exception("OpenPostboxExplorer: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Function actUser() As String
        Dim ben As New PMDS.BusinessLogic.Benutzer(PMDS.Global.ENV.USERID)
        Return ben.BenutzerName

    End Function

    Public Function getPatientName(ByVal idpatient As System.Guid) As String

        Dim pat As New PMDS.BusinessLogic.Patient(idpatient)
        Return pat.Vorname + " " + pat.Nachname

    End Function

End Class

Public Class clObject
    Public id As String = ""
    Public bezeichnung As String = ""
    Public ok As Boolean = False
End Class

