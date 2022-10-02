
Public Class generic

    Public Shared Sub getExcept(ex As String, sTitle As String)

        QS2.Logging.ENV.init(Settings._path_log, True, Settings._adminSecure)

        Dim frmErr As New QS2.Logging.frmError()
        frmErr.setData(sTitle, ex, "QS2.Desktop.Txteditor", True)
        frmErr.ShowDialog()
    End Sub

    Public Shared Function getRes(IDRes As String) As String
        If Not Settings.delDoRes Is Nothing Then
            Return Settings.delDoRes.Invoke(IDRes)
        Else
            Return IDRes
        End If
    End Function

    Public Shared Function showMessageBox(IDResTxt As String, MessageBoxButtons As Windows.Forms.MessageBoxButtons, IDResTitle As String,
                                          Optional TxtOptional As String = "") As MsgBoxResult
        If Not Settings.delDoRes Is Nothing Then
            Dim IDTxtTranslated As String = Settings.delDoRes.Invoke(IDResTxt)
            If TxtOptional.Trim() <> "" Then
                IDTxtTranslated += vbNewLine + vbNewLine + TxtOptional
            End If
            Return MsgBox(IDTxtTranslated, MessageBoxButtons, Settings.delDoRes.Invoke(IDResTitle))
        Else
            Dim IDTxtTmp As String = IDResTxt
            If TxtOptional.Trim() <> "" Then
                IDTxtTmp += vbNewLine + vbNewLine + TxtOptional
            End If
            Return MsgBox(IDTxtTmp, MessageBoxButtons, IDResTitle)
        End If

    End Function

    Public Shared Function getNewRowField(ByRef ds As dsManage, ByRef Newkey As Boolean, ByRef keyNr As Integer) As dsManage.FieldsRow
        Try
            Dim rNew As dsManage.FieldsRow = ds.Fields.NewRow()
            If Newkey Then
                keyNr += 1
                rNew.FieldKey = "Key " + keyNr.ToString()
            Else
                rNew.FieldKey = ""
            End If
            rNew.FieldNameUI = ""
            rNew.DataTable = ""
            rNew.ColumnName = ""
            rNew.ColumnNameSelList = ""
            rNew.Category = ""
            rNew.IsTable = False
            rNew.Sql = ""
            rNew.IDRes = ""
            rNew.Sort = 10000

            ds.Fields.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("generic.getNewRow: " + ex.ToString())
        End Try
    End Function

End Class
