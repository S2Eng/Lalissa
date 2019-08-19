


Public Class compAutoDocu

    Public Class typAutoDocu
        Public typ As String = ""
        Public description As String = ""
    End Class


    Public Enum eSelAutoDocu
        all = 0
        typ = 1
    End Enum
    Public Enum eSelTextTemplates
        ID = 0
        All = 1
        IDTextTemplate = 2
    End Enum

    Public sqldaAutoDocu As String = ""
    Public sqldaTextTemplates As String = ""
    Public sqldaTextTemplatesFiles As String = ""

    Public database As New db


    Public Enum eSubTypeDocu
        None = 100
    End Enum
    Public Enum eObjectTypeDocu
        None = 100
    End Enum

    Public gen As New General()







    Public Shared Function getNewRowTypAutoDocu(ByRef tTypAutoDocu As dsAutoDocu.typAutoDocuDataTable) As dsAutoDocu.typAutoDocuRow
        Try
            Dim rNew As dsAutoDocu.typAutoDocuRow = tTypAutoDocu.NewRow()
            rNew.typ = ""
            rNew.SubType = ""
            rNew.ObjectType = ""
            rNew.Description = ""

            tTypAutoDocu.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getNewRowTypAutoDocu: " + ex.ToString())
        End Try
    End Function

    Public Function getAutoDocu(ByRef ID As System.Guid, ByRef dsAutoDocu1 As dsAutoDocu,
                                 ByRef typAutoDocu As String, ByRef sel As eSelAutoDocu,
                                 ByRef LanguageBenachrichtigung As String) As Boolean
        Try
            Me.daAutoDocu.SelectCommand.CommandText = Me.sqldaAutoDocu
            Me.database.setDBConnection_dataAdapter(Me.daAutoDocu)
            Me.daAutoDocu.SelectCommand.Parameters.Clear()

            If sel = eSelAutoDocu.all Then
                Me.daAutoDocu.SelectCommand.CommandText += " order by typ asc "

            ElseIf sel = eSelAutoDocu.typ Then
                Dim sWhere As String = " where typ = ? "
                If LanguageBenachrichtigung.Trim() <> "" Then
                    sWhere += " and Language='" + LanguageBenachrichtigung.Trim() + "' "
                End If
                Me.daAutoDocu.SelectCommand.CommandText += sWhere + " order by ErstelltAm desc "
                Me.daAutoDocu.SelectCommand.Parameters.AddWithValue("typ", typAutoDocu)

            Else
                Throw New Exception("getAutoDocu: typ '" + sel.ToString() + "' not allowed!")
            End If

            Me.daAutoDocu.Fill(dsAutoDocu1.tblAutoDoku)
            Return True

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getAutoDocu: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowAutoDocu(ByVal dsAutoDocu1 As dsAutoDocu) As dsAutoDocu.tblAutoDokuRow
        Try
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            Dim rNew As dsAutoDocu.tblAutoDokuRow = dsAutoDocu1.tblAutoDoku.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.typ = ""
            rNew.docuRtf = ""
            rNew.ErstelltAm = Now
            rNew.ErstelltVon = UserLoggedIn.Trim()
            rNew.Html = ""
            rNew.Txt = ""
            rNew.IDResTitle = ""
            rNew.Language = ""

            dsAutoDocu1.tblAutoDoku.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getNewRowAutoDocu: " + ex.ToString())
        End Try
    End Function

    Public Function searchTypAutoDocu(ByRef dsAutoDocu1 As dsAutoDocu, ByRef typAutoDocuToSearch As String) As dsAutoDocu.typAutoDocuRow
        Try
            For Each rAutoDocu As dsAutoDocu.typAutoDocuRow In dsAutoDocu1.typAutoDocu
                If rAutoDocu.typ = typAutoDocuToSearch Then
                    Return rAutoDocu
                End If
            Next

        Catch ex As Exception
            Throw New Exception("compAutoDocu.searchTypAutoDocu: " + ex.ToString())
        End Try
    End Function


    Public Function getTextTamplates(ByRef ID As System.Guid, ByRef dsAutoDocu1 As dsAutoDocu, ByRef selType As eSelTextTemplates) As Boolean
        Try
            Me.daTextTemplates.SelectCommand.CommandText = Me.sqldaTextTemplates
            Me.database.setDBConnection_dataAdapter(Me.daTextTemplates)
            Me.daTextTemplates.SelectCommand.Parameters.Clear()

            If selType = eSelTextTemplates.All Then
                Me.daTextTemplates.SelectCommand.CommandText += " order by Bezeichnung asc "

            ElseIf selType = eSelTextTemplates.ID Then
                Dim sWhere As String = " where ID='" + ID.ToString() + "' "
                Me.daTextTemplates.SelectCommand.CommandText += sWhere + " order by Bezeichnung asc "

            Else
                Throw New Exception("getTextTamplates: selType '" + selType.ToString() + "' not allowed!")
            End If

            Me.daTextTemplates.Fill(dsAutoDocu1.tblTextTemplates)
            Return True

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getTextTamplates: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowTextTemplates(ByVal dsAutoDocu1 As dsAutoDocu) As dsAutoDocu.tblTextTemplatesRow
        Try
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            Dim rNew As dsAutoDocu.tblTextTemplatesRow = dsAutoDocu1.tblTextTemplates.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.Bezeichnung = ""
            rNew.Txt = ""
            rNew.Type = ""
            rNew.ErstelltAm = Now
            rNew.ErstelltVon = UserLoggedIn.Trim()
            rNew.Betreff = ""
            rNew.An = ""
            rNew.CC = ""
            rNew.BCC = ""
            rNew.FromPostfach = ""
            rNew.lstIDBenutzer = ""
            rNew.lstIDPatienten = ""
            rNew.lstCategories = ""

            dsAutoDocu1.tblTextTemplates.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getNewRowTextTemplates: " + ex.ToString())
        End Try
    End Function

    Public Function getTextTamplatesFiles(ByRef ID As System.Guid, ByRef dsAutoDocu1 As dsAutoDocu, ByRef selType As eSelTextTemplates) As Boolean
        Try
            Me.daTextTemplatesFiles.SelectCommand.CommandText = Me.sqldaTextTemplatesFiles
            Me.database.setDBConnection_dataAdapter(Me.daTextTemplatesFiles)
            Me.daTextTemplatesFiles.SelectCommand.Parameters.Clear()

            If selType = eSelTextTemplates.IDTextTemplate Then
                Dim sWhere As String = " where IDTextTemplate='" + ID.ToString() + "' "
                Me.daTextTemplatesFiles.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("getTextTamplates: selType '" + selType.ToString() + "' not allowed!")
            End If

            Me.daTextTemplatesFiles.Fill(dsAutoDocu1.tblTextTemplatesFiles)
            Return True

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getTextTamplatesFiles: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowTextTemplatesFiles(ByVal dsAutoDocu1 As dsAutoDocu) As dsAutoDocu.tblTextTemplatesFilesRow
        Try
            Dim rNew As dsAutoDocu.tblTextTemplatesFilesRow = dsAutoDocu1.tblTextTemplatesFiles.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.IDTextTemplate = System.Guid.NewGuid()
            rNew.SetDocuNull()
            rNew.Bezeichnung = ""
            rNew.FileType = ""

            dsAutoDocu1.tblTextTemplatesFiles.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compAutoDocu.getNewRowTextTemplatesFiles: " + ex.ToString())
        End Try
    End Function

End Class
