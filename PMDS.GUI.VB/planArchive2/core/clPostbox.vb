

Public Class clPostbox
    Inherits General

    Private tmpOrdnerLöschenTage As Integer = 1





    Public Function ClearOrdnerTEMP() As Boolean
        Try
            'Dim Settings As New actUsr         'lthNotPossibleAK
            'Dim datLastDel As Date
            'Dim bLöschen As Boolean = False

            ''If withCheck Then
            ''    datLastDel = Settings.ClientSettingsRead("TmpDateien_zuletztGelöscht", db.SettingsTyp.SDate)
            ''    If Me.IsNull(datLastDel) Then
            ''        Settings.ClientSettingsSave("TmpDateien_zuletztGelöscht", db.SettingsTyp.SDate, Now.Date)
            ''        bLöschen = True
            ''    Else
            ''        datLastDel = datLastDel.AddDays(tmpOrdnerLöschenTage)
            ''        If datLastDel < Now.Date Then
            ''            Settings.ClientSettingsSave("TmpDateien_zuletztGelöscht", db.SettingsTyp.SDate, Now.Date)
            ''            bLöschen = True
            ''        End If
            ''    End If
            ''Else
            ''    bLöschen = True
            ''End If

            '' If bLöschen Then
            'Dim allFiles() As String
            'allFiles = System.IO.Directory.GetFiles(QS2.functions.vb.functOld.path_temp)
            'For Each f As String In allFiles
            '    Try
            '        System.IO.File.Delete(f)
            '    Catch ex As Exception
            '    Finally
            '    End Try
            'Next
            'Return True
            ''End If

        Catch ex As Exception
            Me.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function
    Public Function PostboxAlleBenutzerErstellen(ByVal withMsgBox As Boolean)
        Try
            'Dim Settings As New actUsr             'lthNotPossibleAK
            'Dim postbox As String = ""
            'postbox = Settings.adjustRead(compAdjust.eAdjust.postbox, compAdjust.eTypSelAdjust.all)
            'If postbox <> "" Then
            '    If System.IO.Directory.Exists(postbox) Then
            '        Dim compObject1 As New compObject()
            '        Dim dsAllUsr As dsObject = compObject1.getAllSachb(False)
            '        For Each rBen As dsObject.tblObjectRow In dsAllUsr.tblObject
            '            If Not System.IO.Directory.Exists(postbox + "\" + rBen.usr) Then
            '                System.IO.Directory.CreateDirectory(postbox + "\" + rBen.usr)
            '            End If
            '            If Not System.IO.Directory.Exists(postbox + "\" + rBen.usr + "\auto") Then
            '                System.IO.Directory.CreateDirectory(postbox + "\" + rBen.usr + "\auto")
            '            End If
            '        Next
            '        If Not System.IO.Directory.Exists(postbox + "\sys\Documents") Then
            '            System.IO.Directory.CreateDirectory(postbox + "\sys\Documents")
            '        End If
            '        If Not System.IO.Directory.Exists(postbox + "\sys\Auswertungen") Then
            '            System.IO.Directory.CreateDirectory(postbox + "\sys\Auswertungen")
            '        End If
            '        If Not System.IO.Directory.Exists(postbox + "\sys\Icons") Then
            '            System.IO.Directory.CreateDirectory(postbox + "\sys\Icons")
            '        End If
            '        If Not System.IO.Directory.Exists(postbox + "\sys\sichStruktur") Then
            '            System.IO.Directory.CreateDirectory(postbox + "\sys\sichStruktur")
            '        End If
            '        If withMsgBox Then doUI.doMessageBox("PostboxWasCreatedSuccessfully", "Postbox", "!")
            '    Else
            '        If withMsgBox Then doUI.doMessageBox("PostboxNotExists", "Postbox", "!")
            '    End If
            'Else
            '    If withMsgBox Then doUI.doMessageBox("NoPostboxPathExists", "Postbox", "!")
            'End If

        Catch ex As Exception
            Me.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function

    Public Function getPostboxFürBenutzer(ByVal mitMsgBox As Boolean) As String
        Try
            'Dim Settings As New actUsr            'lthNotPossibleAK
            'Dim postbox As String = ""
            'postbox = Settings.adjustRead(compAdjust.eAdjust.postbox, compAdjust.eTypSelAdjust.all)
            'If postbox <> "" Then
            '    If System.IO.Directory.Exists(postbox) Then
            '        Dim ben As New actUsr
            '        Return postbox + "\" + ben.rUsr.usr
            '    Else
            '        If mitMsgBox Then doUI.doMessageBox("PostboxNotExists", "Postbox", "!")
            '        Return ""
            '    End If
            'Else
            '    If mitMsgBox Then doMessageBox("NoPostboxPathExists", "Postbox", "!")
            '    Return ""
            'End If

        Catch ex As Exception
            Me.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function

    Public Function OpenPostboxExplorer() As Boolean
        Try
            'Dim Settings As New actUsr  'lthAKNotPossible
            'Dim postbox As String = ""
            'postbox = Settings.adjustRead(compAdjust.eAdjust.postbox, compAdjust.eTypSelAdjust.all)
            'If postbox <> "" Then
            '    If System.IO.Directory.Exists(postbox) Then
            '        Dim ben As New actUsr
            '        Return Me.OpenExplorerPostbox(postbox + "\" + ben.rUsr.usr)
            '    Else
            '        ITSCont.core.SystemDb.doUI.doMessageBox("PostboxNotExists", "Postbox", "!")
            '    End If
            'Else
            '    ITSCont.core.SystemDb.doUI.doMessageBox("NoPostboxPathExists", "Postbox", "!")
            'End If

        Catch ex As Exception
            Me.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function
    Public Function checkPostboxAndGetPostboxAutogenerierteBerichte() As String
        Try
            'Dim Settings As New actUsr         'lthNotPossibleAK
            'Dim postbox As String = ""
            'postbox = Settings.adjustRead(compAdjust.eAdjust.postbox, compAdjust.eTypSelAdjust.all)
            'If postbox <> "" Then
            '    If System.IO.Directory.Exists(postbox) Then
            '        Dim ben As New actUsr
            '        If System.IO.Directory.Exists(postbox + "\" + ben.rUsr.usr + "\auto") Then
            '            Return postbox + "\" + ben.rUsr.usr + "\auto"
            '        Else
            '            Return ""
            '        End If
            '    Else
            '        Return ""
            '    End If
            'Else
            '    Return ""
            'End If
            Return ""

        Catch ex As Exception
            Me.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function

End Class
