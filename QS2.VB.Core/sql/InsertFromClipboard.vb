

Public Class InsertFromClipboard

    Public Shared tSelListEntries As New dsAdmin.tblSelListEntriesDataTable()
    Public Shared tRessourcen As New qs2.core.language.dsLanguage.RessourcenDataTable()






    Public Function CopySelList(ByRef rSelListEntry As qs2.core.vb.dsAdmin.tblSelListEntriesRow) As Boolean
        Try
            Dim arrSelLists As dsAdmin.tblSelListEntriesRow() = InsertFromClipboard.tSelListEntries.Select(InsertFromClipboard.tSelListEntries.IDColumn.ColumnName + "=" + rSelListEntry.ID.ToString(), "")
            If arrSelLists.Length >= 1 Then
                Dim rSelList As dsAdmin.tblSelListEntriesRow = arrSelLists(0)
                rSelList.Delete()
            End If
            InsertFromClipboard.tSelListEntries.AcceptChanges()

            Dim dsAdminRead As New dsAdmin()
            Dim sqlAdminRead As New sqlAdmin()
            sqlAdminRead.initControl()
            sqlAdminRead.getSelListGroup(dsAdminRead, sqlAdmin.eTypSelGruppen.IDGruppeNoAppPart, "", "", "", rSelListEntry.IDGroup)
            Dim rGroup As dsAdmin.tblSelListGroupRow = dsAdminRead.tblSelListGroup(0)

            Dim rSelListNew As dsAdmin.tblSelListEntriesRow = InsertFromClipboard.tSelListEntries.NewRow()
            rSelListNew.ItemArray = rSelListEntry.ItemArray
            InsertFromClipboard.tSelListEntries.Rows.Add(rSelListNew)

            Dim rLanguageReturn As qs2.core.language.dsLanguage.RessourcenRow = Nothing
            Me.CopyRessource(rSelListEntry.IDRessource, rGroup.IDApplication, rLanguageReturn)
            If (Not rGroup.IDApplication.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower())) Then
                Dim rLanguageReturn2 As qs2.core.language.dsLanguage.RessourcenRow = Nothing
                Me.CopyRessource(rSelListEntry.IDRessource, qs2.core.license.doLicense.eApp.ALL.ToString(), rLanguageReturn2)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("CopySelList: " + ex.ToString())
        End Try
    End Function
    Public Function CopyRessource(IDRessource As String, IDApplication As String, ByRef rLanguageReturn As qs2.core.language.dsLanguage.RessourcenRow,
                                  Optional addCopyToRes As Boolean = False, Optional IDParticipant As String = "") As Boolean
        Try
            Dim dsLanguageRead As New qs2.core.language.dsLanguage()
            Dim sqlLanguageRead As New qs2.core.language.sqlLanguage()
            sqlLanguageRead.initControl()
            sqlLanguageRead.getLanguageRow(IDRessource.Trim(), dsLanguageRead, IDApplication.Trim(), If(String.IsNullOrEmpty(IDParticipant), qs2.core.license.doLicense.eApp.ALL.ToString().Trim(), IDParticipant),
                                                "Label", Enums.eTypeSub.None, qs2.core.license.doLicense.eApp.ALL.ToString(), False, False)
            If dsLanguageRead.Ressourcen.Rows.Count > 0 Then
                For Each rLanguage As qs2.core.language.dsLanguage.RessourcenRow In dsLanguageRead.Ressourcen
                    Me.CopyRessource(rLanguage, rLanguageReturn, addCopyToRes)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("saveRessource: " + ex.ToString())
        End Try
    End Function
    Public Function CopyRessource(rLanguage As qs2.core.language.dsLanguage.RessourcenRow, ByRef rLanguageReturn As qs2.core.language.dsLanguage.RessourcenRow, Optional addCopyToRes As Boolean = False) As Boolean
        Try
            Dim sWhereLanguage As String = tRessourcen.IDResColumn.ColumnName + "='" + rLanguage.IDRes.Trim() + "' and " +
                                            tRessourcen.IDLanguageUserColumn.ColumnName + "='" + rLanguage.IDLanguageUser.Trim() + "' and " +
                                            tRessourcen.IDApplicationColumn.ColumnName + "='" + rLanguage.IDApplication.Trim() + "' and " +
                                            tRessourcen.IDParticipantColumn.ColumnName + "='" + rLanguage.IDParticipant.Trim() + "' and " +
                                            tRessourcen.TypeColumn.ColumnName + "='" + rLanguage.Type.Trim() + "' "

            Dim arrLanguage As qs2.core.language.dsLanguage.RessourcenRow() = InsertFromClipboard.tRessourcen.Select(sWhereLanguage.Trim(), "")
            If arrLanguage.Length = 1 Then
                arrLanguage(0).Delete()
            ElseIf arrLanguage.Length > 1 Then
                Throw New Exception("CopySelList: arrLanguage.Length>1 not allowed!")
            End If
            InsertFromClipboard.tRessourcen.AcceptChanges()

            Dim rRessourceNew As qs2.core.language.dsLanguage.RessourcenRow = InsertFromClipboard.tRessourcen.NewRow()
            rRessourceNew.ItemArray = rLanguage.ItemArray
            If addCopyToRes Then
                'rRessourceNew.German = "Kopie " + rRessourceNew.German
                'rRessourceNew.English = "Copy " + rRessourceNew.English
            End If
            InsertFromClipboard.tRessourcen.Rows.Add(rRessourceNew)

            rLanguageReturn = rRessourceNew

        Catch ex As Exception
            Throw New Exception("saveRessource: " + ex.ToString())
        End Try
    End Function

    Public Function encryptToClipboard(WithLicenseKey As Boolean, SelLists As Boolean) As Boolean
        Try
            Dim ds As New DataSet()

            Dim tSelListEntriesTmp As New dsAdmin.tblSelListEntriesDataTable()
            If SelLists Then
                tSelListEntriesTmp = InsertFromClipboard.tSelListEntries.Copy()
            End If
            Dim tRessourcenTmp As New qs2.core.language.dsLanguage.RessourcenDataTable()
            tRessourcenTmp = InsertFromClipboard.tRessourcen.Copy()

            If SelLists Then
                ds.Tables.Add(tSelListEntriesTmp)
            End If
            ds.Tables.Add(tRessourcenTmp)

            If Not WithLicenseKey And SelLists Then
                Dim dsAdminTmp As New dsAdmin()
                ds.Tables(dsAdminTmp.tblSelListEntries.TableName.Trim()).Columns.Remove(dsAdminTmp.tblSelListEntries.LicenseKeyColumn.ColumnName.Trim())
                ds.AcceptChanges()
            End If

            Dim writer As New System.IO.StringWriter()
            ds.WriteXml(writer, XmlWriteMode.WriteSchema)
            Dim XmlDS As String = writer.ToString()

            Dim Encryption1 As New qs2.license.core.Encryption()
            Dim XmlDSEncrypted As String = Encryption1.StringEncrypt(XmlDS, qs2.license.core.Encryption.keyForEncryptingStrings)
            System.Windows.Forms.Clipboard.SetText(XmlDSEncrypted)

            If SelLists Then
                qs2.core.generic.showMessageBox(tSelListEntriesTmp.Rows.Count.ToString() + " SelList-Entries encrypted!", Windows.Forms.MessageBoxButtons.OK, "")
            Else
                qs2.core.generic.showMessageBox(tRessourcenTmp.Rows.Count.ToString() + " SelList-Entries encrypted!", Windows.Forms.MessageBoxButtons.OK, "")
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("encryptToClipboard: " + ex.ToString())
        End Try
    End Function
    Public Function saveDataToDBFromClipboard(ByRef txtEncrypted As String, ByRef iCounterRowsUpdated As Integer) As Boolean
        Try
            Dim Encryption1 As New qs2.license.core.Encryption()
            Dim XmlDSDecrypted As String = Encryption1.StringDecrypt(txtEncrypted, qs2.license.core.Encryption.keyForEncryptingStrings)

            Dim ds As New DataSet()
            Dim decryptedClipboard As String = ""
            ds.ReadXml(New System.IO.StringReader(XmlDSDecrypted.Trim()))

            Dim doSelLists As Boolean = False
            'tSelListEntries = ds.Tables(InsertFromClipboard.tSelListEntries.TableName.Trim())
            'If tSelListEntries.Rows.Count > 0 Then
            If ds.Tables.Contains(InsertFromClipboard.tSelListEntries.TableName.Trim()) Then
                doSelLists = True
            Else
                doSelLists = False
            End If

            Dim tRessourcen As DataTable = Nothing
            If ds.Tables.Contains(InsertFromClipboard.tRessourcen.TableName.Trim()) Then
                tRessourcen = ds.Tables(InsertFromClipboard.tRessourcen.TableName.Trim())
                For Each rRessourceFromClipboard As DataRow In tRessourcen.Rows
                    Dim sWhereLanguage As String = InsertFromClipboard.tRessourcen.IDResColumn.ColumnName + "='" + rRessourceFromClipboard("IDRes").Trim() + "' and " +
                                InsertFromClipboard.tRessourcen.IDLanguageUserColumn.ColumnName + "='" + rRessourceFromClipboard("IDLanguageUser").Trim() + "' and " +
                                InsertFromClipboard.tRessourcen.IDApplicationColumn.ColumnName + "='" + rRessourceFromClipboard("IDApplication").Trim() + "' and " +
                                InsertFromClipboard.tRessourcen.IDParticipantColumn.ColumnName + "='" + rRessourceFromClipboard("IDParticipant").Trim() + "' and " +
                                InsertFromClipboard.tRessourcen.TypeColumn.ColumnName + "='" + rRessourceFromClipboard("Type").Trim() + "' "

                    Dim sqlLanguageUpdate As New qs2.core.language.sqlLanguage()
                    sqlLanguageUpdate.initControl()

                    sqlLanguageUpdate.deleteRessource(sWhereLanguage)

                    Dim dsLanguageUpdate As New qs2.core.language.dsLanguage()
                    sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), dsLanguageUpdate, language.sqlLanguage.eTypSelLang.IDRes, Enums.eResourceType.Label, "")

                    Dim rNew As qs2.core.language.dsLanguage.RessourcenRow = dsLanguageUpdate.Ressourcen.NewRow()
                    rNew.ItemArray = rRessourceFromClipboard.ItemArray
                    dsLanguageUpdate.Ressourcen.Rows.Add(rNew)
                    sqlLanguageUpdate.daLanguage.Update(dsLanguageUpdate.Ressourcen)

                    If Not doSelLists Then
                        iCounterRowsUpdated += 1
                    End If
                Next
            End If

            If doSelLists Then
                Dim tSelListEntries As DataTable = Nothing
                If ds.Tables.Contains(InsertFromClipboard.tSelListEntries.TableName.Trim()) Then
                    tSelListEntries = ds.Tables(InsertFromClipboard.tSelListEntries.TableName.Trim())
                    For Each rSelListFromClipboard As DataRow In tSelListEntries.Rows
                        Dim dsAdminUpdate As New dsAdmin()
                        Dim sqlAdminUpdate As New sqlAdmin()
                        sqlAdminUpdate.initControl()

                        Dim bAdded As Boolean = False
                        'sqlAdminUpdate.deleteSelListEntry(rSelListToUpdate("ID"))
                        Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                        sqlAdminUpdate.getSelListEntrys(Parameters, "", "", "", dsAdminUpdate, sqlAdmin.eTypAuswahlList.id, "", -999, "", rSelListFromClipboard("ID"))
                        Dim rSelListUpdate As dsAdmin.tblSelListEntriesRow = Nothing
                        If dsAdminUpdate.tblSelListEntries.Rows.Count = 1 Then
                            rSelListUpdate = dsAdminUpdate.tblSelListEntries.Rows(0)
                        Else
                            rSelListUpdate = dsAdminUpdate.tblSelListEntries.NewRow()
                            bAdded = True
                        End If

                        For Each col As DataColumn In tSelListEntries.Columns
                            rSelListUpdate(col.ColumnName) = rSelListFromClipboard(col.ColumnName)
                        Next
                        If bAdded Then
                            dsAdminUpdate.tblSelListEntries.Rows.Add(rSelListUpdate)
                        End If
                        sqlAdminUpdate.daSelListEntrys.Update(dsAdminUpdate.tblSelListEntries)
                        iCounterRowsUpdated += 1
                    Next
                End If
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("saveDataToDBFromClipboard: " + ex.ToString())
        End Try
    End Function

End Class
