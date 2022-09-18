Imports qs2.core.vb
Imports Infragistics.Win.grid
Imports Infragistics.Win
Imports System.Windows.Forms

Public Class contProducts

    Public IsInitialized As Boolean = False
    Public b As New businessFramework()

    Public _IDGuidObject As System.Guid = Nothing
    Public _bEdit As Boolean = False
    Public valueHasChangedInGrid As Boolean = False





    Private Sub contProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl()
        Try
            If Not Me.IsInitialized Then
                Me.gridProducts.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.Products.ActiveColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Active")
                Me.gridProducts.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.Products.ActiveColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Product")

                Me.gridProducts.UpdateMode = UltraWinGrid.UpdateMode.OnUpdate
                Me.AddApp(qs2.core.license.doLicense.eApp.CARDIAC.ToString().Trim())
                Me.AddApp(qs2.core.license.doLicense.eApp.VASCULAR.ToString().Trim())
                Me.AddApp(qs2.core.license.doLicense.eApp.NC.ToString().Trim())
                Me.AddApp(qs2.core.license.doLicense.eApp.QTH.ToString().Trim())

                Me.ClearUI()

                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contProducts.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub AddApp(ByRef AppToAdd As String)
        Try
            Dim rNewApp As dsAdmin.ProductsRow = Me.DsAdmin1.Products.NewRow()
            rNewApp.IDApplication = AppToAdd.ToString().Trim()
            Dim Translated As String = qs2.core.language.sqlLanguage.getRes(AppToAdd.ToString().Trim())
            rNewApp.Application = Translated.Trim()
            rNewApp.Active = False
            Me.DsAdmin1.Products.Rows.Add(rNewApp)

        Catch ex As Exception
            Throw New Exception("contProducts.AddApp: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData(ByRef IDGuidObject As Guid)
        Try
            Me._IDGuidObject = IDGuidObject
            Me.valueHasChangedInGrid = False
            Me.ClearUI()

            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim tObjectApplications As IQueryable(Of PMDS.db.Entities.tblObjectApplications) = b.getProductsForUser(Me._IDGuidObject, db)
                For Each rGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridProducts.Rows
                    Dim v As DataRowView = rGridRow.ListObject
                    Dim rProduct As dsAdmin.ProductsRow = v.Row

                    For Each rAppInDB As PMDS.db.Entities.tblObjectApplications In tObjectApplications
                        If rAppInDB.IDApplication.Trim().ToLower().Equals(rProduct.IDApplication.Trim().ToLower()) Then
                            rProduct.Active = True
                        End If
                    Next
                Next
            End With

            Me.gridProducts.Refresh()

        Catch ex As Exception
            Throw New Exception("contProducts.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            Dim bWrongProducts As Boolean = False
            Dim txtProductsWrong As String = ""
            If Not actUsr.IsAdminSecureOrSupervisor() And Not actUsr.IsSuperadmin() Then
                Dim dsLicense1 As New core.license.dsLicense()
                Dim doLicense1 As New core.license.doLicense()

                Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                With db
                    Dim tObjectApplicationsLoggedInUsr As IQueryable(Of PMDS.db.Entities.tblObjectApplications) = b.getProductsForUser(actUsr.rUsr.IDGuid, db)
                    doLicense1.getAppsLicensedForParticipant(dsLicense1, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), False)

                    If actUsr.rUsr.IDGuid.Equals(Me._IDGuidObject) Then
                        If Me.valueHasChangedInGrid Then
                            Dim txtMsgBox As String = qs2.core.language.sqlLanguage.getRes("YouCanNotChangeYourOwnProducts") + "!"
                            qs2.core.generic.showMessageBox(txtMsgBox, MessageBoxButtons.OK, "")
                            Return False
                        End If
                    Else
                        For Each rGrid As UltraWinGrid.UltraGridRow In Me.gridProducts.Rows
                            Dim vBefore As DataRowView = rGrid.ListObject
                            Dim rProduct As dsAdmin.ProductsRow = vBefore.Row
                            If rProduct.Active Then
                                Dim bAppIsInLicensedList As Boolean = False
                                For Each rAppLicensed As core.license.dsLicense.ApplicationsRow In dsLicense1.Applications
                                    If rAppLicensed.ID.Trim().ToLower().Equals(rProduct.Application.Trim().ToLower()) Then
                                        bAppIsInLicensedList = True
                                    End If
                                Next
                                Dim bAppIsInListLoggedOnUser As Boolean = False
                                For Each rAppLoggedInUsr As PMDS.db.Entities.tblObjectApplications In tObjectApplicationsLoggedInUsr
                                    If rAppLoggedInUsr.IDApplication.Trim().ToLower().Equals(rProduct.Application.Trim().ToLower()) Then
                                        bAppIsInListLoggedOnUser = True
                                    End If
                                Next

                                If (Not bAppIsInLicensedList) Or (Not bAppIsInListLoggedOnUser) Then
                                    bWrongProducts = True
                                    Dim appTranslated As String = qs2.core.language.sqlLanguage.getRes(rProduct.Application.Trim())
                                    If appTranslated.Trim() = "" Then
                                        appTranslated = rProduct.Application.Trim()
                                    End If
                                    txtProductsWrong += IIf(txtProductsWrong.Trim() = "", " ", ", ") + appTranslated.Trim()
                                End If
                            End If
                        Next
                    End If
                End With
            End If

            If bWrongProducts Then
                txtProductsWrong += " "
                Dim txtMsgBox As String = qs2.core.language.sqlLanguage.getRes("Product{0}CanNotBeGivenToUsersBecauseYouHaveNoRightForThisProduct") + "!"
                txtMsgBox = System.String.Format(txtMsgBox, txtProductsWrong)
                qs2.core.generic.showMessageBox(txtMsgBox, MessageBoxButtons.OK, "")
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contProducts.validateData: " + ex.ToString())
        End Try
    End Function

    Public Function saveData() As Boolean
        Try
            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim tObjectApplications As IQueryable(Of PMDS.db.Entities.tblObjectApplications) = b.getProductsForUser(Me._IDGuidObject, db)
                For Each rGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridProducts.Rows
                    Dim v As DataRowView = rGridRow.ListObject
                    Dim rProduct As dsAdmin.ProductsRow = v.Row

                    Dim AppInDbFound As PMDS.db.Entities.tblObjectApplications = Nothing
                    Dim AppIsInDB As Boolean = False
                    For Each rAppInDB As PMDS.db.Entities.tblObjectApplications In tObjectApplications
                        If rAppInDB.IDApplication.Trim().ToLower().Equals(rProduct.IDApplication.Trim().ToLower()) Then
                            AppInDbFound = rAppInDB
                            AppIsInDB = True
                        End If
                    Next

                    If rProduct.Active And Not AppIsInDB Then
                        Dim NewProduct As New PMDS.db.Entities.tblObjectApplications()
                        NewProduct.ID = System.Guid.NewGuid()
                        NewProduct.IDApplication = rProduct.IDApplication.Trim()
                        NewProduct.IDObjectGuid = Me._IDGuidObject
                        db.tblObjectApplications.Add(NewProduct)

                    ElseIf Not rProduct.Active And AppIsInDB Then
                        db.tblObjectApplications.Remove(AppInDbFound)
                    End If
                Next

                db.SaveChanges()
            End With

            Return True

        Catch ex As Exception
            Throw New Exception("contProducts.saveData: " + ex.ToString())
        End Try
    End Function

    Public Sub ClearUI()
        Try
            For Each rGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridProducts.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rProduct As dsAdmin.ProductsRow = v.Row

                rProduct.Active = False
            Next

            Me.gridProducts.Refresh()

        Catch ex As Exception
            Throw New Exception("contProducts.ClearUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub lockUnlock(bEdit As Boolean)
        Try
            Me._bEdit = bEdit

        Catch ex As Exception
            Throw New Exception("contProducts.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Private Sub gridProducts_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridProducts.BeforeCellActivate
        Try
            If Me._bEdit Then
                If e.Cell.Column.ToString() = Me.DsAdmin1.Products.ActiveColumn.ColumnName Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridProducts_CellChange(sender As Object, e As UltraWinGrid.CellEventArgs) Handles gridProducts.CellChange
        Try
            If Me._bEdit Then
                If e.Cell.Column.ToString().Trim().ToLower().Equals(Me.DsAdmin1.Products.ActiveColumn.ColumnName.Trim().ToLower()) Then
                    Me.gridProducts.UpdateData()
                    Me.valueHasChangedInGrid = True
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
