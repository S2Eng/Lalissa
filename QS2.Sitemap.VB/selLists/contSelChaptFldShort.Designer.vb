<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelChaptFldShort
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries", -1)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sort")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeQry")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeStr")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Table")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortColumn")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("picture")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Private")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sql")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UIType")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubQuery")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Published")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ForServices")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries_tblStayAdditions")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries_tblStayAdditions", 0)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayParent")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayParent")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayParent")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayChild")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayChild")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayChild")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListFirst")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria", -1)
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication", -1, "ultraDropDownApp")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlType")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SQLValueListSelect")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AliasFldShort")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SourceTable")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlPattern")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MaskInput")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMinVal")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMaxVal")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMinLength")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlMaxLength")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Used")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Validate")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Editable")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserDefined")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UseInQueries")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ShowAt")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("prefered")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DefaultValues")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DefaultValuesCustomer")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UsedCustomer")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblSelListEntriesObj")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblRelationship1")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblCriteriaOpt")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblCriteria_tblQueriesDef")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selection", 1)
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblSelListEntriesObj", 0)
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntrySublist")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListEntry")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStay")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStay")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStay")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typIDGroup")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("From")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("To")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDClassification")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedBy")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Modified")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ModifiedBy")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Active")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObjectGuid")
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Transfered")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nVisible")
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblRelationship1", 0)
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortParent")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationParent")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortChild")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationChild")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conditions")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Type")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeSub")
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKey")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConditionsSub")
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblCriteriaOpt", 0)
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShort")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Parameter")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Value")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Referenze")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblCriteria_tblQueriesDef", 0)
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserInput")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FunctionPar")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Combination")
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("QryTable")
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("QryColumn")
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CriteriaFldShort")
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CriteriaApplication")
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsSQLServerField")
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Label")
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlType")
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Typ")
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Condition")
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValueMin")
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Max")
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValueMinIDRes")
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MaxIDRes")
        Dim UltraGridColumn289 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CombinationEnd")
        Dim UltraGridColumn290 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("freeSql")
        Dim UltraGridColumn291 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn292 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn293 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ApplicationOwn")
        Dim UltraGridColumn294 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ParticipantOwn")
        Dim UltraGridColumn295 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("All")
        Dim UltraGridColumn296 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SpecialDefinition")
        Dim UltraGridColumn297 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ComboAsDropDown")
        Dim UltraGridColumn298 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ComboAsDropDownCondition")
        Dim UltraGridColumn299 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SpecialDefinitionMax")
        Dim UltraGridColumn300 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Chapter")
        Dim UltraGridColumn301 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Chapters")
        Dim UltraGridColumn302 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChaptersDone")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Placeholder")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.ContextMenuStripFields = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TranslateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpaceTranslate = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkAsPreferedFieldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkNotAsPreferedFieldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.optionSetChaptersYN = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.btnAddPlaceholder = New Infragistics.Win.Misc.UltraButton()
        Me.chkOnlyShowPreferedFields = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.DropDownApplications1 = New qs2.sitemap.dropDownApplications()
        Me.txtSearchCriteria = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.gridBagLayoutPanelChapters = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridChapter = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.gridBagLayoutPanelCriterias = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridCriterias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SqlAdmin1 = New qs2.core.vb.sqlAdmin(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.ContextMenuStripFields.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.optionSetChaptersYN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOnlyShowPreferedFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBagLayoutPanelChapters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridBagLayoutPanelChapters.SuspendLayout()
        CType(Me.gridChapter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBagLayoutPanelCriterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridBagLayoutPanelCriterias.SuspendLayout()
        CType(Me.gridCriterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripFields
        '
        Me.ContextMenuStripFields.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TranslateToolStripMenuItem, Me.ToolStripMenuItemSpaceTranslate, Me.MarkAsPreferedFieldToolStripMenuItem, Me.MarkNotAsPreferedFieldToolStripMenuItem})
        Me.ContextMenuStripFields.Name = "ContextMenuStrip1"
        Me.ContextMenuStripFields.Size = New System.Drawing.Size(212, 76)
        '
        'TranslateToolStripMenuItem
        '
        Me.TranslateToolStripMenuItem.Name = "TranslateToolStripMenuItem"
        Me.TranslateToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.TranslateToolStripMenuItem.Text = "Translate Entry"
        '
        'ToolStripMenuItemSpaceTranslate
        '
        Me.ToolStripMenuItemSpaceTranslate.Name = "ToolStripMenuItemSpaceTranslate"
        Me.ToolStripMenuItemSpaceTranslate.Size = New System.Drawing.Size(208, 6)
        '
        'MarkAsPreferedFieldToolStripMenuItem
        '
        Me.MarkAsPreferedFieldToolStripMenuItem.Name = "MarkAsPreferedFieldToolStripMenuItem"
        Me.MarkAsPreferedFieldToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.MarkAsPreferedFieldToolStripMenuItem.Text = "Mark as prefered Field"
        '
        'MarkNotAsPreferedFieldToolStripMenuItem
        '
        Me.MarkNotAsPreferedFieldToolStripMenuItem.Name = "MarkNotAsPreferedFieldToolStripMenuItem"
        Me.MarkNotAsPreferedFieldToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.MarkNotAsPreferedFieldToolStripMenuItem.Text = "Mark not as prefered Field"
        '
        'PanelUnten
        '
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 330)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(975, 30)
        Me.PanelUnten.TabIndex = 4
        Me.PanelUnten.Visible = False
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.optionSetChaptersYN)
        Me.PanelTop.Controls.Add(Me.btnAddPlaceholder)
        Me.PanelTop.Controls.Add(Me.chkOnlyShowPreferedFields)
        Me.PanelTop.Controls.Add(Me.DropDownApplications1)
        Me.PanelTop.Controls.Add(Me.txtSearchCriteria)
        Me.PanelTop.Controls.Add(Me.lblSearch)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(975, 39)
        Me.PanelTop.TabIndex = 6
        '
        'optionSetChaptersYN
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.optionSetChaptersYN.Appearance = Appearance1
        Me.optionSetChaptersYN.BackColor = System.Drawing.Color.Transparent
        Me.optionSetChaptersYN.BackColorInternal = System.Drawing.Color.Transparent
        Me.optionSetChaptersYN.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optionSetChaptersYN.CheckedIndex = 0
        ValueListItem1.DataValue = 1
        ValueListItem1.DisplayText = "WithChapters"
        ValueListItem2.DataValue = 0
        ValueListItem2.DisplayText = "NoChapters"
        Me.optionSetChaptersYN.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optionSetChaptersYN.Location = New System.Drawing.Point(12, 6)
        Me.optionSetChaptersYN.Name = "optionSetChaptersYN"
        Me.optionSetChaptersYN.Size = New System.Drawing.Size(128, 32)
        Me.optionSetChaptersYN.TabIndex = 0
        Me.optionSetChaptersYN.Text = "WithChapters"
        '
        'btnAddPlaceholder
        '
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAddPlaceholder.Appearance = Appearance2
        Me.btnAddPlaceholder.Location = New System.Drawing.Point(232, 10)
        Me.btnAddPlaceholder.Name = "btnAddPlaceholder"
        Me.btnAddPlaceholder.Size = New System.Drawing.Size(22, 22)
        Me.btnAddPlaceholder.TabIndex = 595
        '
        'chkOnlyShowPreferedFields
        '
        Me.chkOnlyShowPreferedFields.Location = New System.Drawing.Point(268, 15)
        Me.chkOnlyShowPreferedFields.Name = "chkOnlyShowPreferedFields"
        Me.chkOnlyShowPreferedFields.Size = New System.Drawing.Size(316, 17)
        Me.chkOnlyShowPreferedFields.TabIndex = 594
        Me.chkOnlyShowPreferedFields.Text = "OnlyShowPreferedFields"
        '
        'DropDownApplications1
        '
        Me.DropDownApplications1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DropDownApplications1.Location = New System.Drawing.Point(99, 11)
        Me.DropDownApplications1.Name = "DropDownApplications1"
        Me.DropDownApplications1.Size = New System.Drawing.Size(13, 17)
        Me.DropDownApplications1.TabIndex = 587
        Me.DropDownApplications1.Visible = False
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Me.txtSearchCriteria.Appearance = Appearance3
        Me.txtSearchCriteria.BackColor = System.Drawing.Color.White
        Me.txtSearchCriteria.Location = New System.Drawing.Point(721, 13)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(244, 21)
        Me.txtSearchCriteria.TabIndex = 592
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.TextHAlignAsString = "Right"
        Me.lblSearch.Appearance = Appearance4
        Me.lblSearch.Location = New System.Drawing.Point(606, 17)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(109, 16)
        Me.lblSearch.TabIndex = 593
        Me.lblSearch.Text = "Search"
        '
        'gridBagLayoutPanelChapters
        '
        Me.gridBagLayoutPanelChapters.Controls.Add(Me.gridChapter)
        Me.gridBagLayoutPanelChapters.Dock = System.Windows.Forms.DockStyle.Left
        Me.gridBagLayoutPanelChapters.ExpandToFitHeight = True
        Me.gridBagLayoutPanelChapters.ExpandToFitWidth = True
        Me.gridBagLayoutPanelChapters.Location = New System.Drawing.Point(0, 0)
        Me.gridBagLayoutPanelChapters.Name = "gridBagLayoutPanelChapters"
        Me.gridBagLayoutPanelChapters.Size = New System.Drawing.Size(263, 291)
        Me.gridBagLayoutPanelChapters.TabIndex = 587
        '
        'gridChapter
        '
        Me.gridChapter.DataMember = "tblSelListEntries"
        Me.gridChapter.DataSource = Me.DsAdmin1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridChapter.DisplayLayout.Appearance = Appearance5
        Me.gridChapter.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 99
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.Editor = Nothing
        UltraGridColumn10.Header.VisiblePosition = 3
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 60
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.Header.Editor = Nothing
        UltraGridColumn11.Header.VisiblePosition = 4
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.Editor = Nothing
        UltraGridColumn12.Header.VisiblePosition = 5
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.Editor = Nothing
        UltraGridColumn13.Header.VisiblePosition = 6
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.Editor = Nothing
        UltraGridColumn14.Header.VisiblePosition = 7
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 41
        UltraGridColumn15.Header.Editor = Nothing
        UltraGridColumn15.Header.VisiblePosition = 8
        UltraGridColumn15.Width = 14
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.Header.Editor = Nothing
        UltraGridColumn16.Header.VisiblePosition = 9
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 71
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.Header.Editor = Nothing
        UltraGridColumn17.Header.VisiblePosition = 10
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.Header.Editor = Nothing
        UltraGridColumn18.Header.VisiblePosition = 11
        UltraGridColumn18.Width = 14
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.Header.Editor = Nothing
        UltraGridColumn19.Header.VisiblePosition = 12
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.Header.Editor = Nothing
        UltraGridColumn20.Header.VisiblePosition = 13
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.Header.Editor = Nothing
        UltraGridColumn21.Header.VisiblePosition = 14
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 44
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.Header.Editor = Nothing
        UltraGridColumn22.Header.VisiblePosition = 15
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 48
        UltraGridColumn23.Header.Editor = Nothing
        UltraGridColumn23.Header.VisiblePosition = 16
        UltraGridColumn23.Width = 14
        UltraGridColumn24.Header.Editor = Nothing
        UltraGridColumn24.Header.VisiblePosition = 17
        UltraGridColumn24.Width = 14
        UltraGridColumn25.Header.Editor = Nothing
        UltraGridColumn25.Header.VisiblePosition = 19
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 72
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.Header.Editor = Nothing
        UltraGridColumn26.Header.VisiblePosition = 18
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 49
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 20
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 59
        UltraGridColumn28.Header.Editor = Nothing
        UltraGridColumn28.Header.VisiblePosition = 21
        UltraGridColumn28.Width = 14
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.Header.Editor = Nothing
        UltraGridColumn29.Header.VisiblePosition = 22
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(59, 0)
        UltraGridColumn30.Header.Editor = Nothing
        UltraGridColumn30.Header.VisiblePosition = 23
        UltraGridColumn30.Width = 14
        UltraGridColumn31.Header.Editor = Nothing
        UltraGridColumn31.Header.VisiblePosition = 24
        UltraGridColumn31.Width = 23
        UltraGridColumn32.Header.Editor = Nothing
        UltraGridColumn32.Header.VisiblePosition = 25
        UltraGridColumn32.Width = 23
        UltraGridColumn33.Header.Editor = Nothing
        UltraGridColumn33.Header.VisiblePosition = 26
        UltraGridColumn33.Width = 25
        UltraGridColumn34.Header.Editor = Nothing
        UltraGridColumn34.Header.VisiblePosition = 27
        UltraGridColumn34.Width = 23
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 28
        UltraGridColumn1.Width = 45
        UltraGridColumn35.Header.Editor = Nothing
        UltraGridColumn35.Header.VisiblePosition = 29
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn36.Header.Editor = Nothing
        UltraGridColumn36.Header.VisiblePosition = 0
        UltraGridColumn36.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(94, 0)
        UltraGridColumn36.Width = 14
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn1, UltraGridColumn35, UltraGridColumn36})
        UltraGridColumn37.Header.Editor = Nothing
        UltraGridColumn37.Header.VisiblePosition = 0
        UltraGridColumn37.Width = 14
        UltraGridColumn38.Header.Editor = Nothing
        UltraGridColumn38.Header.VisiblePosition = 1
        UltraGridColumn38.Width = 14
        UltraGridColumn39.Header.Editor = Nothing
        UltraGridColumn39.Header.VisiblePosition = 2
        UltraGridColumn39.Width = 14
        UltraGridColumn40.Header.Editor = Nothing
        UltraGridColumn40.Header.VisiblePosition = 3
        UltraGridColumn40.Width = 14
        UltraGridColumn41.Header.Editor = Nothing
        UltraGridColumn41.Header.VisiblePosition = 4
        UltraGridColumn41.Width = 14
        UltraGridColumn42.Header.Editor = Nothing
        UltraGridColumn42.Header.VisiblePosition = 5
        UltraGridColumn42.Width = 14
        UltraGridColumn43.Header.Editor = Nothing
        UltraGridColumn43.Header.VisiblePosition = 6
        UltraGridColumn43.Width = 14
        UltraGridColumn44.Header.Editor = Nothing
        UltraGridColumn44.Header.VisiblePosition = 7
        UltraGridColumn44.Width = 14
        UltraGridColumn45.Header.Editor = Nothing
        UltraGridColumn45.Header.VisiblePosition = 8
        UltraGridColumn45.Width = 14
        UltraGridColumn46.Header.Editor = Nothing
        UltraGridColumn46.Header.VisiblePosition = 9
        UltraGridColumn46.Width = 14
        UltraGridColumn47.Header.Editor = Nothing
        UltraGridColumn47.Header.VisiblePosition = 10
        UltraGridColumn47.Width = 14
        UltraGridColumn48.Header.Editor = Nothing
        UltraGridColumn48.Header.VisiblePosition = 11
        UltraGridColumn48.Width = 14
        UltraGridColumn49.Header.Editor = Nothing
        UltraGridColumn49.Header.VisiblePosition = 12
        UltraGridColumn49.Width = 14
        UltraGridColumn50.Header.Editor = Nothing
        UltraGridColumn50.Header.VisiblePosition = 13
        UltraGridColumn50.Width = 14
        UltraGridColumn51.Header.Editor = Nothing
        UltraGridColumn51.Header.VisiblePosition = 14
        UltraGridColumn51.Width = 14
        UltraGridColumn52.Header.Editor = Nothing
        UltraGridColumn52.Header.VisiblePosition = 15
        UltraGridColumn52.Width = 14
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52})
        Me.gridChapter.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridChapter.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridChapter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.gridChapter.DisplayLayout.GroupByBox.Appearance = Appearance6
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridChapter.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.gridChapter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridChapter.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.gridChapter.DisplayLayout.MaxColScrollRegions = 1
        Me.gridChapter.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridChapter.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridChapter.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.gridChapter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridChapter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.gridChapter.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridChapter.DisplayLayout.Override.CellAppearance = Appearance12
        Me.gridChapter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridChapter.DisplayLayout.Override.CellPadding = 0
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.gridChapter.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Left"
        Me.gridChapter.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.gridChapter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridChapter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.gridChapter.DisplayLayout.Override.RowAppearance = Appearance15
        Me.gridChapter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridChapter.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.gridChapter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridChapter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.gridBagLayoutPanelChapters.SetGridBagConstraint(Me.gridChapter, GridBagConstraint1)
        Me.gridChapter.Location = New System.Drawing.Point(5, 0)
        Me.gridChapter.Name = "gridChapter"
        Me.gridBagLayoutPanelChapters.SetPreferredSize(Me.gridChapter, New System.Drawing.Size(233, 133))
        Me.gridChapter.Size = New System.Drawing.Size(258, 286)
        Me.gridChapter.TabIndex = 5
        Me.gridChapter.Text = "Chapters"
        Me.gridChapter.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAuswahllisten"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gridBagLayoutPanelCriterias
        '
        Me.gridBagLayoutPanelCriterias.Controls.Add(Me.gridCriterias)
        Me.gridBagLayoutPanelCriterias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBagLayoutPanelCriterias.ExpandToFitHeight = True
        Me.gridBagLayoutPanelCriterias.ExpandToFitWidth = True
        Me.gridBagLayoutPanelCriterias.Location = New System.Drawing.Point(263, 0)
        Me.gridBagLayoutPanelCriterias.Name = "gridBagLayoutPanelCriterias"
        Me.gridBagLayoutPanelCriterias.Size = New System.Drawing.Size(712, 291)
        Me.gridBagLayoutPanelCriterias.TabIndex = 588
        '
        'gridCriterias
        '
        Me.gridCriterias.ContextMenuStrip = Me.ContextMenuStripFields
        Me.gridCriterias.DataMember = "tblCriteria"
        Me.gridCriterias.DataSource = Me.DsAdmin1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCriterias.DisplayLayout.Appearance = Appearance17
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn53.Header.Editor = Nothing
        UltraGridColumn53.Header.VisiblePosition = 2
        UltraGridColumn53.Width = 145
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn54.Header.Caption = "Application"
        UltraGridColumn54.Header.Editor = Nothing
        UltraGridColumn54.Header.VisiblePosition = 3
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn55.Header.Editor = Nothing
        UltraGridColumn55.Header.VisiblePosition = 4
        UltraGridColumn55.Width = 131
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn56.Header.Editor = Nothing
        UltraGridColumn56.Header.VisiblePosition = 6
        UltraGridColumn56.Hidden = True
        UltraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn57.Header.Editor = Nothing
        UltraGridColumn57.Header.VisiblePosition = 5
        UltraGridColumn57.Hidden = True
        UltraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn58.Header.Editor = Nothing
        UltraGridColumn58.Header.VisiblePosition = 19
        UltraGridColumn58.Width = 180
        UltraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn59.Header.Editor = Nothing
        UltraGridColumn59.Header.VisiblePosition = 7
        UltraGridColumn59.Hidden = True
        UltraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn60.Header.Editor = Nothing
        UltraGridColumn60.Header.VisiblePosition = 8
        UltraGridColumn60.Hidden = True
        UltraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn61.Header.Editor = Nothing
        UltraGridColumn61.Header.VisiblePosition = 9
        UltraGridColumn61.Hidden = True
        UltraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn62.Header.Editor = Nothing
        UltraGridColumn62.Header.VisiblePosition = 10
        UltraGridColumn62.Hidden = True
        UltraGridColumn63.Header.Editor = Nothing
        UltraGridColumn63.Header.VisiblePosition = 11
        UltraGridColumn64.Header.Editor = Nothing
        UltraGridColumn64.Header.VisiblePosition = 12
        UltraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn65.Header.Editor = Nothing
        UltraGridColumn65.Header.VisiblePosition = 14
        UltraGridColumn65.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(59, 0)
        UltraGridColumn65.Width = 74
        UltraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn66.Header.Editor = Nothing
        UltraGridColumn66.Header.VisiblePosition = 15
        UltraGridColumn66.Hidden = True
        UltraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn67.Header.Editor = Nothing
        UltraGridColumn67.Header.VisiblePosition = 17
        UltraGridColumn67.Hidden = True
        UltraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn68.Header.Editor = Nothing
        UltraGridColumn68.Header.VisiblePosition = 16
        UltraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn69.Header.Editor = Nothing
        UltraGridColumn69.Header.VisiblePosition = 18
        UltraGridColumn69.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(103, 0)
        UltraGridColumn69.Width = 130
        UltraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn70.Header.Editor = Nothing
        UltraGridColumn70.Header.VisiblePosition = 20
        UltraGridColumn70.Hidden = True
        UltraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn71.Header.Editor = Nothing
        UltraGridColumn71.Header.VisiblePosition = 24
        UltraGridColumn71.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(120, 0)
        UltraGridColumn71.Width = 136
        UltraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn72.Header.Editor = Nothing
        UltraGridColumn72.Header.VisiblePosition = 13
        UltraGridColumn72.Hidden = True
        UltraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn73.Header.Editor = Nothing
        UltraGridColumn73.Header.VisiblePosition = 21
        UltraGridColumn74.Header.Editor = Nothing
        UltraGridColumn74.Header.VisiblePosition = 22
        UltraGridColumn75.Header.Editor = Nothing
        UltraGridColumn75.Header.VisiblePosition = 23
        UltraGridColumn76.Header.Editor = Nothing
        UltraGridColumn76.Header.VisiblePosition = 26
        UltraGridColumn77.Header.Editor = Nothing
        UltraGridColumn77.Header.VisiblePosition = 25
        UltraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn78.Header.Editor = Nothing
        UltraGridColumn78.Header.VisiblePosition = 30
        UltraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn79.Header.Editor = Nothing
        UltraGridColumn79.Header.VisiblePosition = 28
        UltraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn80.Header.Editor = Nothing
        UltraGridColumn80.Header.VisiblePosition = 27
        UltraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn81.Header.Editor = Nothing
        UltraGridColumn81.Header.VisiblePosition = 29
        UltraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn82.Header.Editor = Nothing
        UltraGridColumn82.Header.VisiblePosition = 0
        UltraGridColumn82.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(189, 0)
        UltraGridColumn82.Width = 231
        UltraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn83.DataType = GetType(Boolean)
        UltraGridColumn83.Header.Editor = Nothing
        UltraGridColumn83.Header.VisiblePosition = 1
        UltraGridColumn83.Hidden = True
        UltraGridColumn83.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83})
        UltraGridColumn84.Header.Editor = Nothing
        UltraGridColumn84.Header.VisiblePosition = 0
        UltraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn85.Header.Editor = Nothing
        UltraGridColumn85.Header.VisiblePosition = 1
        UltraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn86.Header.Editor = Nothing
        UltraGridColumn86.Header.VisiblePosition = 2
        UltraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn87.Header.Editor = Nothing
        UltraGridColumn87.Header.VisiblePosition = 3
        UltraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn88.Header.Editor = Nothing
        UltraGridColumn88.Header.VisiblePosition = 4
        UltraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn89.Header.Editor = Nothing
        UltraGridColumn89.Header.VisiblePosition = 5
        UltraGridColumn90.Header.Editor = Nothing
        UltraGridColumn90.Header.VisiblePosition = 6
        UltraGridColumn91.Header.Editor = Nothing
        UltraGridColumn91.Header.VisiblePosition = 7
        UltraGridColumn92.Header.Editor = Nothing
        UltraGridColumn92.Header.VisiblePosition = 9
        UltraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn93.Header.Editor = Nothing
        UltraGridColumn93.Header.VisiblePosition = 8
        UltraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn94.Header.Editor = Nothing
        UltraGridColumn94.Header.VisiblePosition = 10
        UltraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn95.Header.Editor = Nothing
        UltraGridColumn95.Header.VisiblePosition = 12
        UltraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn96.Header.Editor = Nothing
        UltraGridColumn96.Header.VisiblePosition = 13
        UltraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn97.Header.Editor = Nothing
        UltraGridColumn97.Header.VisiblePosition = 14
        UltraGridColumn98.Header.Editor = Nothing
        UltraGridColumn98.Header.VisiblePosition = 16
        UltraGridColumn99.Header.Editor = Nothing
        UltraGridColumn99.Header.VisiblePosition = 18
        UltraGridColumn100.Header.Editor = Nothing
        UltraGridColumn100.Header.VisiblePosition = 19
        UltraGridColumn101.Header.Editor = Nothing
        UltraGridColumn101.Header.VisiblePosition = 20
        UltraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn102.Header.Editor = Nothing
        UltraGridColumn102.Header.VisiblePosition = 17
        UltraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn103.Header.Editor = Nothing
        UltraGridColumn103.Header.VisiblePosition = 11
        UltraGridColumn104.Header.Editor = Nothing
        UltraGridColumn104.Header.VisiblePosition = 21
        UltraGridColumn105.Header.Editor = Nothing
        UltraGridColumn105.Header.VisiblePosition = 15
        UltraGridColumn106.Header.Editor = Nothing
        UltraGridColumn106.Header.VisiblePosition = 22
        UltraGridColumn107.Header.Editor = Nothing
        UltraGridColumn107.Header.VisiblePosition = 23
        UltraGridColumn108.Header.Editor = Nothing
        UltraGridColumn108.Header.VisiblePosition = 24
        UltraGridColumn109.Header.Editor = Nothing
        UltraGridColumn109.Header.VisiblePosition = 25
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109})
        UltraGridBand4.Hidden = True
        UltraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn110.Header.Editor = Nothing
        UltraGridColumn110.Header.VisiblePosition = 0
        UltraGridColumn111.Header.Editor = Nothing
        UltraGridColumn111.Header.VisiblePosition = 1
        UltraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn112.Header.Editor = Nothing
        UltraGridColumn112.Header.VisiblePosition = 2
        UltraGridColumn113.Header.Editor = Nothing
        UltraGridColumn113.Header.VisiblePosition = 3
        UltraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn114.Header.Editor = Nothing
        UltraGridColumn114.Header.VisiblePosition = 4
        UltraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn115.Header.Editor = Nothing
        UltraGridColumn115.Header.VisiblePosition = 5
        UltraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn116.Header.Editor = Nothing
        UltraGridColumn116.Header.VisiblePosition = 6
        UltraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn117.Header.Editor = Nothing
        UltraGridColumn117.Header.VisiblePosition = 7
        UltraGridColumn118.Header.Editor = Nothing
        UltraGridColumn118.Header.VisiblePosition = 8
        UltraGridColumn119.Header.Editor = Nothing
        UltraGridColumn119.Header.VisiblePosition = 9
        UltraGridColumn120.Header.Editor = Nothing
        UltraGridColumn120.Header.VisiblePosition = 10
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120})
        UltraGridBand5.Hidden = True
        UltraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn121.Header.Editor = Nothing
        UltraGridColumn121.Header.VisiblePosition = 0
        UltraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn122.Header.Editor = Nothing
        UltraGridColumn122.Header.VisiblePosition = 1
        UltraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn123.Header.Editor = Nothing
        UltraGridColumn123.Header.VisiblePosition = 2
        UltraGridColumn124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn124.Header.Editor = Nothing
        UltraGridColumn124.Header.VisiblePosition = 3
        UltraGridColumn125.Header.Editor = Nothing
        UltraGridColumn125.Header.VisiblePosition = 4
        UltraGridColumn126.Header.Editor = Nothing
        UltraGridColumn126.Header.VisiblePosition = 5
        UltraGridColumn127.Header.Editor = Nothing
        UltraGridColumn127.Header.VisiblePosition = 6
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127})
        UltraGridBand6.Hidden = True
        UltraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn128.Header.Editor = Nothing
        UltraGridColumn128.Header.VisiblePosition = 0
        UltraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn129.Header.Editor = Nothing
        UltraGridColumn129.Header.VisiblePosition = 1
        UltraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn130.Header.Editor = Nothing
        UltraGridColumn130.Header.VisiblePosition = 2
        UltraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn131.Header.Editor = Nothing
        UltraGridColumn131.Header.VisiblePosition = 3
        UltraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn132.Header.Editor = Nothing
        UltraGridColumn132.Header.VisiblePosition = 4
        UltraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn133.Header.Editor = Nothing
        UltraGridColumn133.Header.VisiblePosition = 5
        UltraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn134.Header.Editor = Nothing
        UltraGridColumn134.Header.VisiblePosition = 6
        UltraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn135.Header.Editor = Nothing
        UltraGridColumn135.Header.VisiblePosition = 7
        UltraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn136.Header.Editor = Nothing
        UltraGridColumn136.Header.VisiblePosition = 9
        UltraGridColumn137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn137.Header.Editor = Nothing
        UltraGridColumn137.Header.VisiblePosition = 8
        UltraGridColumn138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn138.Header.Editor = Nothing
        UltraGridColumn138.Header.VisiblePosition = 10
        UltraGridColumn139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn139.Header.Editor = Nothing
        UltraGridColumn139.Header.VisiblePosition = 11
        UltraGridColumn140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn140.Header.Editor = Nothing
        UltraGridColumn140.Header.VisiblePosition = 12
        UltraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn141.Header.Editor = Nothing
        UltraGridColumn141.Header.VisiblePosition = 13
        UltraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn142.Header.Editor = Nothing
        UltraGridColumn142.Header.VisiblePosition = 14
        UltraGridColumn143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn143.Header.Editor = Nothing
        UltraGridColumn143.Header.VisiblePosition = 15
        UltraGridColumn144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn144.Header.Editor = Nothing
        UltraGridColumn144.Header.VisiblePosition = 16
        UltraGridColumn289.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn289.Header.Editor = Nothing
        UltraGridColumn289.Header.VisiblePosition = 17
        UltraGridColumn290.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn290.Header.Editor = Nothing
        UltraGridColumn290.Header.VisiblePosition = 19
        UltraGridColumn291.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn291.Header.Editor = Nothing
        UltraGridColumn291.Header.VisiblePosition = 18
        UltraGridColumn292.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn292.Header.Editor = Nothing
        UltraGridColumn292.Header.VisiblePosition = 20
        UltraGridColumn293.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn293.Header.Editor = Nothing
        UltraGridColumn293.Header.VisiblePosition = 21
        UltraGridColumn294.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn294.Header.Editor = Nothing
        UltraGridColumn294.Header.VisiblePosition = 22
        UltraGridColumn295.Header.Editor = Nothing
        UltraGridColumn295.Header.VisiblePosition = 23
        UltraGridColumn296.Header.Editor = Nothing
        UltraGridColumn296.Header.VisiblePosition = 24
        UltraGridColumn297.Header.Editor = Nothing
        UltraGridColumn297.Header.VisiblePosition = 25
        UltraGridColumn298.Header.Editor = Nothing
        UltraGridColumn298.Header.VisiblePosition = 26
        UltraGridColumn299.Header.Editor = Nothing
        UltraGridColumn299.Header.VisiblePosition = 27
        UltraGridColumn300.Header.Editor = Nothing
        UltraGridColumn300.Header.VisiblePosition = 28
        UltraGridColumn301.Header.Editor = Nothing
        UltraGridColumn301.Header.VisiblePosition = 29
        UltraGridColumn302.Header.Editor = Nothing
        UltraGridColumn302.Header.VisiblePosition = 30
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 31
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn133, UltraGridColumn134, UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138, UltraGridColumn139, UltraGridColumn140, UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn289, UltraGridColumn290, UltraGridColumn291, UltraGridColumn292, UltraGridColumn293, UltraGridColumn294, UltraGridColumn295, UltraGridColumn296, UltraGridColumn297, UltraGridColumn298, UltraGridColumn299, UltraGridColumn300, UltraGridColumn301, UltraGridColumn302, UltraGridColumn2})
        UltraGridBand7.Hidden = True
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.gridCriterias.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.gridCriterias.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCriterias.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.gridCriterias.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCriterias.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.gridCriterias.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCriterias.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridCriterias.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridCriterias.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.gridCriterias.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCriterias.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCriterias.DisplayLayout.Override.CellAppearance = Appearance24
        Me.gridCriterias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridCriterias.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCriterias.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.gridCriterias.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.gridCriterias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridCriterias.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.gridCriterias.DisplayLayout.Override.RowAppearance = Appearance27
        Me.gridCriterias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCriterias.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.gridCriterias.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCriterias.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridCriterias.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 5
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.OriginX = 0
        GridBagConstraint2.OriginY = 0
        Me.gridBagLayoutPanelCriterias.SetGridBagConstraint(Me.gridCriterias, GridBagConstraint2)
        Me.gridCriterias.Location = New System.Drawing.Point(5, 0)
        Me.gridCriterias.Name = "gridCriterias"
        Me.gridBagLayoutPanelCriterias.SetPreferredSize(Me.gridCriterias, New System.Drawing.Size(728, 133))
        Me.gridCriterias.Size = New System.Drawing.Size(702, 286)
        Me.gridCriterias.TabIndex = 1
        Me.gridCriterias.Text = "Fields"
        Me.gridCriterias.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridBagLayoutPanelCriterias)
        Me.Panel1.Controls.Add(Me.gridBagLayoutPanelChapters)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 291)
        Me.Panel1.TabIndex = 589
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'contSelChaptFldShort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelUnten)
        Me.Name = "contSelChaptFldShort"
        Me.Size = New System.Drawing.Size(975, 360)
        Me.ContextMenuStripFields.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.optionSetChaptersYN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOnlyShowPreferedFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBagLayoutPanelChapters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridBagLayoutPanelChapters.ResumeLayout(False)
        CType(Me.gridChapter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBagLayoutPanelCriterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridBagLayoutPanelCriterias.ResumeLayout(False)
        CType(Me.gridCriterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin
    Friend WithEvents gridCriterias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents gridChapter As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents SqlAdmin1 As qs2.core.vb.sqlAdmin
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents optionSetChaptersYN As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents txtSearchCriteria As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridBagLayoutPanelCriterias As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents gridBagLayoutPanelChapters As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DropDownApplications1 As qs2.sitemap.dropDownApplications
    Friend WithEvents ContextMenuStripFields As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarkAsPreferedFieldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkNotAsPreferedFieldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkOnlyShowPreferedFields As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ToolStripMenuItemSpaceTranslate As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TranslateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddPlaceholder As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
