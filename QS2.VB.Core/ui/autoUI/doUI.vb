Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports qs2.core.language
Imports qs2.core.license

Public Class doUI

    Public sqlLanguageWork As New sqlLanguage()

    Public Sub New()
        sqlLanguageWork.initControl()
    End Sub

    Public Sub autoAddResInGrid(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                ByRef AutoResOnReturn As Boolean, ByRef chkOnlyAdd As UltraWinEditors.UltraCheckEditor,
                                doOff As Boolean)
        Try
            Dim bOn As Boolean = False
            If doOff Then
                lblAutoResOnOff.Tag = 0
                lblAutoResOnOff.Text = "Auto-Res On"
                chkOnlyAdd.Visible = False
                bOn = False
            Else
                If lblAutoResOnOff.Tag = 0 Then
                    lblAutoResOnOff.Tag = 1
                    lblAutoResOnOff.Text = "Auto-Res Off"
                    chkOnlyAdd.Visible = True
                    bOn = True
                Else
                    lblAutoResOnOff.Tag = 0
                    lblAutoResOnOff.Text = "Auto-Res On"
                    chkOnlyAdd.Visible = False
                    bOn = False
                End If
            End If

            grid.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameEnglish.Trim()).Hidden = Not bOn
            grid.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameGerman.Trim()).Hidden = Not bOn
            AutoResOnReturn = bOn

        Catch ex As Exception
            Throw New Exception("doUI.AutoAddResInGrid: " + ex.ToString())
        End Try
    End Sub

    Public Sub addAutoRessources(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                    ByRef Application As String, ByRef sProt As String,
                                    ByRef iCounterInserted As Integer, ByRef iCounterUpdated As Integer, ByRef onlyAddRes As Boolean)
        Try
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            sqlLanguage1.initControl()
            Dim cTranslate1 As New cTranslate()

            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                If rSelList.IDRessource.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rSelList.IDRessource.Trim()='' not allowed!")
                End If

                Dim colEnglish As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value Is Nothing Then
                    colEnglish = rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value.Trim()
                End If
                Dim colGerman As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value Is Nothing Then
                    colGerman = rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value.Trim()
                End If

                If colEnglish.Trim() <> "" And colGerman.Trim() <> "" Then
                    cTranslate1.saveAutoTranslation(rSelList.IDRessource,
                                                    colGerman, colEnglish,
                                                    "", Application.Trim(),
                                                    iCounterInserted, iCounterUpdated, sProt, onlyAddRes)
                End If
            Next

            sqlLanguage1.loadAllRessources()
            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rSelList As dsAdmin.tblSelListEntriesRow = v.Row

                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rSelList.IDRessource.Trim(), doLicense.eApp.ALL.ToString(), Application.Trim(), True)
                If resFound.Trim() <> "" Then
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = resFound
                Else
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = rSelList.IDRessource.Trim()
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.addAutoRessources: " + ex.ToString())
        End Try
    End Sub

    Public Sub addAutoRessources(ByRef grid As UltraGrid, ByRef lblAutoResOnOff As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel,
                                    ByRef sProt As String,
                                    ByRef iCounterInserted As Integer, ByRef iCounterUpdated As Integer, onlyAddRes As Boolean)
        Try
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            sqlLanguage1.initControl()
            Dim cTranslate1 As New cTranslate()

            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                If rCriteria.FldShort.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rCriteria.FldShort.Trim()='' not allowed!")
                End If
                If rCriteria.IDApplication.Trim() = "" Then
                    Throw New Exception("addAutoRessources: rCriteria.IDApplication.Trim()='' not allowed!")
                End If

                Dim colEnglish As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value Is Nothing Then
                    colEnglish = rowGridSelList.Cells(qs2.core.generic.columnNameEnglish.Trim()).Value.Trim()
                End If
                Dim colGerman As String = ""
                If Not rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value Is Nothing Then
                    colGerman = rowGridSelList.Cells(qs2.core.generic.columnNameGerman.Trim()).Value.Trim()
                End If

                If colEnglish.Trim() <> "" And colGerman.Trim() <> "" Then
                    cTranslate1.saveAutoTranslation(rCriteria.FldShort,
                                                    colGerman, colEnglish,
                                                    "", rCriteria.IDApplication.Trim(),
                                                    iCounterInserted, iCounterUpdated, sProt, onlyAddRes)
                End If
            Next

            sqlLanguage1.loadAllRessources()
            For Each rowGridSelList As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
                Dim v As DataRowView = rowGridSelList.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort.Trim(), doLicense.eApp.ALL.ToString(), rCriteria.IDApplication.Trim(), True)
                If resFound.Trim() <> "" Then
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = resFound
                Else
                    rowGridSelList.Cells(qs2.core.generic.columnNameText.Trim()).Value = rCriteria.FldShort.Trim()
                End If
            Next

        Catch ex As Exception
            Throw New Exception("doUI.addAutoRessources: " + ex.ToString())
        End Try
    End Sub

End Class
