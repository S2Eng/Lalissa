<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelLists
    Inherits System.Windows.Forms.UserControl

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries", -1)
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sort", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeQry", -1, 352029563)
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeStr")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Table")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortColumn")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("picture")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Private")
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sql")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UIType")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubQuery")
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Published")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ForServices")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries_tblStayAdditions")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0)
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("English", 1)
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("German", 2)
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SortCustomer", 3)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries_tblStayAdditions", 0)
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayParent")
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayParent")
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayParent")
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayChild")
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayChild")
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayChild")
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn145 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn146 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn147 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListFirst")
        Dim UltraGridColumn148 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient")
        Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(86483507)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(343142186)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(352029563)
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contSelLists))
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAssign")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAssign")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListGroup", -1)
        Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroupStr")
        Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication", -1, "ultraDropDownApp")
        Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sys")
        Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sublist")
        Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeEnum")
        Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SortColumn")
        Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn164 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn165 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListGroup_tblSelListEntries")
        Dim UltraGridColumn166 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListGroup_tblSelListEntries", 0)
        Dim UltraGridColumn167 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn168 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn169 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn170 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn171 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn172 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sort")
        Dim UltraGridColumn173 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsMain")
        Dim UltraGridColumn174 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeQry")
        Dim UltraGridColumn175 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeStr")
        Dim UltraGridColumn176 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Table")
        Dim UltraGridColumn177 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FldShortColumn")
        Dim UltraGridColumn178 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("picture")
        Dim UltraGridColumn179 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGroup")
        Dim UltraGridColumn180 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser")
        Dim UltraGridColumn181 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Private")
        Dim UltraGridColumn182 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrFrom")
        Dim UltraGridColumn183 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionNrTo")
        Dim UltraGridColumn184 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn185 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created")
        Dim UltraGridColumn186 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sql")
        Dim UltraGridColumn187 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UIType")
        Dim UltraGridColumn188 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn189 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant")
        Dim UltraGridColumn190 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim UltraGridColumn191 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubQuery")
        Dim UltraGridColumn192 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LicenseKey")
        Dim UltraGridColumn193 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Published")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ForServices")
        Dim UltraGridColumn194 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tblSelListEntries_tblStayAdditions")
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSelListEntries_tblStayAdditions", 1)
        Dim UltraGridColumn195 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn196 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayParent")
        Dim UltraGridColumn197 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayParent")
        Dim UltraGridColumn198 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayParent")
        Dim UltraGridColumn199 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStayChild")
        Dim UltraGridColumn200 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplicationStayChild")
        Dim UltraGridColumn201 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipantStayChild")
        Dim UltraGridColumn202 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelList")
        Dim UltraGridColumn207 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn208 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sort")
        Dim UltraGridColumn211 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Classification")
        Dim UltraGridColumn212 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn213 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSelListFirst")
        Dim UltraGridColumn214 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient")
        Dim UltraGridColumn215 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDApplication")
        Dim UltraGridColumn216 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelAll = New System.Windows.Forms.Panel()
        Me.PanelSelLists = New System.Windows.Forms.Panel()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridSelList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.menuStripGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.listOfSublistenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TranslateEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoRessourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace01 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopySellistAndRessourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignToMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsAdmin1 = New qs2.core.vb.dsAdmin()
        Me.PanelSelListTop = New System.Windows.Forms.Panel()
        Me.btnUserRights = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelButtonsSort = New System.Windows.Forms.Panel()
        Me.btnUp = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnDown = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelTollbar = New System.Windows.Forms.Panel()
        Me.PanelTollbar_Fill_Panel = New System.Windows.Forms.Panel()
        Me._PanelTollbar_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.toolbarsManagerAssigns = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelTollbar_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelTollbar_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.btnAdd = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnDel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelButt = New System.Windows.Forms.Panel()
        Me.PanelDoAutoRes = New System.Windows.Forms.Panel()
        Me.lblAutoAddRessources = New Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel()
        Me.chkAutoResOnlyAddRes = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.PanelSelect = New System.Windows.Forms.Panel()
        Me.btnSelect = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.DropDownApplications1 = New qs2.sitemap.dropDownApplications()
        Me.PanelButtEdit = New System.Windows.Forms.Panel()
        Me.btnEdit = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnSave2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnCancel = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.PanelClose = New System.Windows.Forms.Panel()
        Me.btnClose2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.UltraSplitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.PanelSelGroups = New System.Windows.Forms.Panel()
        Me.gridBagLayoutPanelGroups = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridGroup = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.btnEncryptsSaveToTheClipboardForDelivery = New Infragistics.Win.Misc.UltraButton()
        Me.ContextMenuStripTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearCopiedRowsInRamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EncryptedToClipboardNoLicenseKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEditGroup = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnDelGroup = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.btnAddGroup = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.txtSearchText = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelTopAll = New System.Windows.Forms.Panel()
        Me.ComboApplication1 = New qs2.sitemap.comboApplication()
        Me.btnReload2 = New qs2.sitemap.ownControls.inherit_Infrag.InfragButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.PanelAll.SuspendLayout()
        Me.PanelSelLists.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.gridSelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStripGrid.SuspendLayout()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSelListTop.SuspendLayout()
        Me.PanelButtonsSort.SuspendLayout()
        Me.PanelTollbar.SuspendLayout()
        CType(Me.toolbarsManagerAssigns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButt.SuspendLayout()
        Me.PanelDoAutoRes.SuspendLayout()
        CType(Me.chkAutoResOnlyAddRes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSelect.SuspendLayout()
        Me.PanelButtEdit.SuspendLayout()
        Me.PanelClose.SuspendLayout()
        Me.PanelSelGroups.SuspendLayout()
        CType(Me.gridBagLayoutPanelGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridBagLayoutPanelGroups.SuspendLayout()
        CType(Me.gridGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearch.SuspendLayout()
        Me.ContextMenuStripTop.SuspendLayout()
        CType(Me.txtSearchText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTopAll.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.PanelAll)
        Me.UltraTabPageControl1.Controls.Add(Me.PanelTopAll)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(868, 524)
        '
        'PanelAll
        '
        Me.PanelAll.Controls.Add(Me.PanelSelLists)
        Me.PanelAll.Controls.Add(Me.UltraSplitter1)
        Me.PanelAll.Controls.Add(Me.PanelSelGroups)
        Me.PanelAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAll.Location = New System.Drawing.Point(0, 27)
        Me.PanelAll.Name = "PanelAll"
        Me.PanelAll.Size = New System.Drawing.Size(868, 497)
        Me.PanelAll.TabIndex = 9
        '
        'PanelSelLists
        '
        Me.PanelSelLists.BackColor = System.Drawing.Color.Transparent
        Me.PanelSelLists.Controls.Add(Me.PanelGrid)
        Me.PanelSelLists.Controls.Add(Me.PanelButt)
        Me.PanelSelLists.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSelLists.Location = New System.Drawing.Point(0, 200)
        Me.PanelSelLists.Name = "PanelSelLists"
        Me.PanelSelLists.Size = New System.Drawing.Size(868, 297)
        Me.PanelSelLists.TabIndex = 6
        '
        'PanelGrid
        '
        Me.PanelGrid.BackColor = System.Drawing.Color.Transparent
        Me.PanelGrid.Controls.Add(Me.Panel1)
        Me.PanelGrid.Controls.Add(Me.PanelSelListTop)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(868, 264)
        Me.PanelGrid.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 241)
        Me.Panel1.TabIndex = 3
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.gridSelList)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(868, 241)
        Me.UltraGridBagLayoutPanel1.TabIndex = 1
        '
        'gridSelList
        '
        Me.gridSelList.ContextMenuStrip = Me.menuStripGrid
        Me.gridSelList.DataMember = "tblSelListEntries"
        Me.gridSelList.DataSource = Me.DsAdmin1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.gridSelList.DisplayLayout.Appearance = Appearance1
        UltraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn102.CellAppearance = Appearance2
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn102.Header.Appearance = Appearance3
        UltraGridColumn102.Header.VisiblePosition = 26
        UltraGridColumn102.Hidden = True
        UltraGridColumn102.Width = 79
        UltraGridColumn103.Header.VisiblePosition = 3
        UltraGridColumn103.Hidden = True
        UltraGridColumn104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn104.Header.VisiblePosition = 0
        UltraGridColumn104.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn104.Width = 264
        UltraGridColumn105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn105.Header.VisiblePosition = 10
        UltraGridColumn105.MaskInput = "-nnnnnnnnn"
        UltraGridColumn105.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerWithSpin
        UltraGridColumn105.Width = 137
        UltraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn106.Header.VisiblePosition = 11
        UltraGridColumn106.Width = 142
        UltraGridColumn107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn107.CellAppearance = Appearance4
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn107.Header.Appearance = Appearance5
        UltraGridColumn107.Header.VisiblePosition = 5
        UltraGridColumn107.MaskInput = "-nnnnnnnnn"
        UltraGridColumn107.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerWithSpin
        UltraGridColumn107.Width = 80
        UltraGridColumn108.Header.VisiblePosition = 12
        UltraGridColumn109.Header.VisiblePosition = 8
        UltraGridColumn109.Width = 151
        UltraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn110.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn110.Header.VisiblePosition = 7
        UltraGridColumn110.Width = 144
        UltraGridColumn111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn111.Header.VisiblePosition = 9
        UltraGridColumn111.Width = 190
        UltraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn112.Header.VisiblePosition = 13
        UltraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn113.Header.VisiblePosition = 14
        UltraGridColumn113.Hidden = True
        UltraGridColumn113.Width = 26
        UltraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn114.Header.VisiblePosition = 15
        UltraGridColumn114.Hidden = True
        UltraGridColumn114.Width = 117
        UltraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn115.Header.VisiblePosition = 16
        UltraGridColumn115.Width = 119
        UltraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn116.Header.VisiblePosition = 17
        UltraGridColumn117.Header.VisiblePosition = 18
        UltraGridColumn118.Header.VisiblePosition = 19
        UltraGridColumn119.Header.VisiblePosition = 20
        UltraGridColumn119.Width = 192
        UltraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn120.Header.VisiblePosition = 22
        UltraGridColumn120.MaskInput = "{date} {time}"
        UltraGridColumn120.Width = 245
        UltraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn121.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn121.Header.VisiblePosition = 23
        UltraGridColumn121.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor
        UltraGridColumn121.Width = 141
        UltraGridColumn122.Header.VisiblePosition = 24
        UltraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn123.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn123.Header.VisiblePosition = 25
        UltraGridColumn123.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor
        UltraGridColumn123.Width = 237
        UltraGridColumn124.Header.VisiblePosition = 29
        UltraGridColumn125.Header.VisiblePosition = 30
        UltraGridColumn126.Header.VisiblePosition = 31
        UltraGridColumn127.Header.VisiblePosition = 21
        UltraGridColumn127.Width = 185
        UltraGridColumn128.Header.VisiblePosition = 27
        UltraGridColumn1.Header.VisiblePosition = 28
        UltraGridColumn130.Header.VisiblePosition = 32
        UltraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn131.Header.VisiblePosition = 4
        UltraGridColumn131.Width = 301
        UltraGridColumn132.Header.VisiblePosition = 1
        UltraGridColumn132.Hidden = True
        UltraGridColumn132.Width = 301
        UltraGridColumn133.Header.VisiblePosition = 2
        UltraGridColumn133.Hidden = True
        UltraGridColumn133.Width = 284
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn134.CellAppearance = Appearance6
        UltraGridColumn134.DataType = GetType(Integer)
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn134.Header.Appearance = Appearance7
        UltraGridColumn134.Header.VisiblePosition = 6
        UltraGridColumn134.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerWithSpin
        UltraGridColumn134.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn1, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn133, UltraGridColumn134})
        UltraGridColumn135.Header.VisiblePosition = 0
        UltraGridColumn136.Header.VisiblePosition = 1
        UltraGridColumn136.Width = 301
        UltraGridColumn137.Header.VisiblePosition = 2
        UltraGridColumn137.Width = 80
        UltraGridColumn138.Header.VisiblePosition = 3
        UltraGridColumn138.Width = 95
        UltraGridColumn139.Header.VisiblePosition = 4
        UltraGridColumn140.Header.VisiblePosition = 5
        UltraGridColumn141.Header.VisiblePosition = 6
        UltraGridColumn142.Header.VisiblePosition = 7
        UltraGridColumn143.Header.VisiblePosition = 8
        UltraGridColumn144.Header.VisiblePosition = 9
        UltraGridColumn145.Header.VisiblePosition = 10
        UltraGridColumn146.Header.VisiblePosition = 11
        UltraGridColumn147.Header.VisiblePosition = 12
        UltraGridColumn148.Header.VisiblePosition = 13
        UltraGridColumn149.Header.VisiblePosition = 14
        UltraGridColumn149.Width = 192
        UltraGridColumn150.Header.VisiblePosition = 15
        UltraGridColumn150.Width = 192
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138, UltraGridColumn139, UltraGridColumn140, UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn145, UltraGridColumn146, UltraGridColumn147, UltraGridColumn148, UltraGridColumn149, UltraGridColumn150})
        Me.gridSelList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSelList.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridSelList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BackColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.CaptionAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSelList.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridSelList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.gridSelList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSelList.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.gridSelList.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSelList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Appearance12.TextHAlignAsString = "Left"
        Me.gridSelList.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.BorderColor = System.Drawing.Color.White
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSelList.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.gridSelList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridSelList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSelList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.gridSelList.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSelList.DisplayLayout.Override.CellAppearance = Appearance15
        Me.gridSelList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSelList.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSelList.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.gridSelList.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.gridSelList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSelList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.BackColor2 = System.Drawing.Color.White
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.gridSelList.DisplayLayout.Override.RowAppearance = Appearance18
        Me.gridSelList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Me.gridSelList.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance19.BackColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Override.TemplateAddRowCellAppearance = Appearance20
        Me.gridSelList.DisplayLayout.Override.TemplateAddRowPrompt = "Click here to add a record ..."
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColor2 = System.Drawing.Color.White
        Me.gridSelList.DisplayLayout.Override.TemplateAddRowPromptAppearance = Appearance21
        Me.gridSelList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSelList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Type"
        ValueList2.Key = "TablesQuery"
        ValueList3.Key = "TypeQry"
        Me.gridSelList.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3})
        Me.gridSelList.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.gridSelList, GridBagConstraint1)
        Me.gridSelList.Location = New System.Drawing.Point(5, 0)
        Me.gridSelList.Name = "gridSelList"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.gridSelList, New System.Drawing.Size(689, 281))
        Me.gridSelList.Size = New System.Drawing.Size(858, 241)
        Me.gridSelList.TabIndex = 3
        Me.gridSelList.Text = "List Entrys"
        '
        'menuStripGrid
        '
        Me.menuStripGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.listOfSublistenToolStripMenuItem, Me.SetPictureToolStripMenuItem, Me.ClearPictureToolStripMenuItem, Me.OpenPictureToolStripMenuItem, Me.TranslateEntryToolStripMenuItem, Me.InfoRessourceToolStripMenuItem, Me.ToolStripMenuItemSpace01, Me.CopySellistAndRessourceToolStripMenuItem, Me.AssignToMeToolStripMenuItem})
        Me.menuStripGrid.Name = "menuStripGrid"
        Me.menuStripGrid.Size = New System.Drawing.Size(211, 186)
        '
        'listOfSublistenToolStripMenuItem
        '
        Me.listOfSublistenToolStripMenuItem.Name = "listOfSublistenToolStripMenuItem"
        Me.listOfSublistenToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.listOfSublistenToolStripMenuItem.Text = "Assign Sublists"
        '
        'SetPictureToolStripMenuItem
        '
        Me.SetPictureToolStripMenuItem.Name = "SetPictureToolStripMenuItem"
        Me.SetPictureToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SetPictureToolStripMenuItem.Text = "Set Picture"
        '
        'ClearPictureToolStripMenuItem
        '
        Me.ClearPictureToolStripMenuItem.Name = "ClearPictureToolStripMenuItem"
        Me.ClearPictureToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ClearPictureToolStripMenuItem.Text = "Clear Picture"
        '
        'OpenPictureToolStripMenuItem
        '
        Me.OpenPictureToolStripMenuItem.Name = "OpenPictureToolStripMenuItem"
        Me.OpenPictureToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenPictureToolStripMenuItem.Text = "Open Picture"
        '
        'TranslateEntryToolStripMenuItem
        '
        Me.TranslateEntryToolStripMenuItem.Name = "TranslateEntryToolStripMenuItem"
        Me.TranslateEntryToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.TranslateEntryToolStripMenuItem.Text = "Translate Entry"
        Me.TranslateEntryToolStripMenuItem.Visible = False
        '
        'InfoRessourceToolStripMenuItem
        '
        Me.InfoRessourceToolStripMenuItem.Name = "InfoRessourceToolStripMenuItem"
        Me.InfoRessourceToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.InfoRessourceToolStripMenuItem.Text = "InfoRessource"
        Me.InfoRessourceToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItemSpace01
        '
        Me.ToolStripMenuItemSpace01.Name = "ToolStripMenuItemSpace01"
        Me.ToolStripMenuItemSpace01.Size = New System.Drawing.Size(207, 6)
        '
        'CopySellistAndRessourceToolStripMenuItem
        '
        Me.CopySellistAndRessourceToolStripMenuItem.Name = "CopySellistAndRessourceToolStripMenuItem"
        Me.CopySellistAndRessourceToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CopySellistAndRessourceToolStripMenuItem.Text = "Copy sellist and ressource"
        '
        'AssignToMeToolStripMenuItem
        '
        Me.AssignToMeToolStripMenuItem.Name = "AssignToMeToolStripMenuItem"
        Me.AssignToMeToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AssignToMeToolStripMenuItem.Text = "AssignToMe"
        Me.AssignToMeToolStripMenuItem.Visible = False
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAuswahllisten"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelSelListTop
        '
        Me.PanelSelListTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelSelListTop.Controls.Add(Me.btnUserRights)
        Me.PanelSelListTop.Controls.Add(Me.PanelButtonsSort)
        Me.PanelSelListTop.Controls.Add(Me.PanelTollbar)
        Me.PanelSelListTop.Controls.Add(Me.btnAdd)
        Me.PanelSelListTop.Controls.Add(Me.btnDel)
        Me.PanelSelListTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSelListTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelSelListTop.Name = "PanelSelListTop"
        Me.PanelSelListTop.Size = New System.Drawing.Size(868, 23)
        Me.PanelSelListTop.TabIndex = 2
        '
        'btnUserRights
        '
        Me.btnUserRights.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance22.Image = CType(resources.GetObject("Appearance22.Image"), Object)
        Appearance22.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnUserRights.Appearance = Appearance22
        Me.btnUserRights.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUserRights.Location = New System.Drawing.Point(785, 0)
        Me.btnUserRights.Name = "btnUserRights"
        Me.btnUserRights.OwnAutoTextYN = False
        Me.btnUserRights.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Bearbeiten
        Me.btnUserRights.OwnPictureTxt = ""
        Me.btnUserRights.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnUserRights.OwnTooltipText = ""
        Me.btnUserRights.OwnTooltipTitle = Nothing
        Me.btnUserRights.Size = New System.Drawing.Size(23, 22)
        Me.btnUserRights.TabIndex = 41
        Me.btnUserRights.Visible = False
        '
        'PanelButtonsSort
        '
        Me.PanelButtonsSort.Controls.Add(Me.btnUp)
        Me.PanelButtonsSort.Controls.Add(Me.btnDown)
        Me.PanelButtonsSort.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelButtonsSort.Location = New System.Drawing.Point(0, 0)
        Me.PanelButtonsSort.Name = "PanelButtonsSort"
        Me.PanelButtonsSort.Size = New System.Drawing.Size(57, 23)
        Me.PanelButtonsSort.TabIndex = 590
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance23.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnUp.Appearance = Appearance23
        Me.btnUp.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnUp.Location = New System.Drawing.Point(10, 2)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.OwnAutoTextYN = False
        Me.btnUp.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnUp.OwnPictureTxt = ""
        Me.btnUp.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnUp.OwnTooltipText = ""
        Me.btnUp.OwnTooltipTitle = Nothing
        Me.btnUp.Size = New System.Drawing.Size(22, 20)
        Me.btnUp.TabIndex = 588
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance24.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnDown.Appearance = Appearance24
        Me.btnDown.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnDown.Location = New System.Drawing.Point(32, 2)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.OwnAutoTextYN = False
        Me.btnDown.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnDown.OwnPictureTxt = ""
        Me.btnDown.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnDown.OwnTooltipText = ""
        Me.btnDown.OwnTooltipTitle = Nothing
        Me.btnDown.Size = New System.Drawing.Size(22, 20)
        Me.btnDown.TabIndex = 587
        '
        'PanelTollbar
        '
        Me.PanelTollbar.BackColor = System.Drawing.Color.Transparent
        Me.PanelTollbar.Controls.Add(Me.PanelTollbar_Fill_Panel)
        Me.PanelTollbar.Controls.Add(Me._PanelTollbar_Toolbars_Dock_Area_Left)
        Me.PanelTollbar.Controls.Add(Me._PanelTollbar_Toolbars_Dock_Area_Right)
        Me.PanelTollbar.Controls.Add(Me._PanelTollbar_Toolbars_Dock_Area_Bottom)
        Me.PanelTollbar.Controls.Add(Me._PanelTollbar_Toolbars_Dock_Area_Top)
        Me.PanelTollbar.Location = New System.Drawing.Point(66, 4)
        Me.PanelTollbar.Name = "PanelTollbar"
        Me.PanelTollbar.Size = New System.Drawing.Size(320, 18)
        Me.PanelTollbar.TabIndex = 589
        Me.PanelTollbar.Visible = False
        '
        'PanelTollbar_Fill_Panel
        '
        Me.PanelTollbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelTollbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTollbar_Fill_Panel.Location = New System.Drawing.Point(0, 21)
        Me.PanelTollbar_Fill_Panel.Name = "PanelTollbar_Fill_Panel"
        Me.PanelTollbar_Fill_Panel.Size = New System.Drawing.Size(320, 0)
        Me.PanelTollbar_Fill_Panel.TabIndex = 0
        '
        '_PanelTollbar_Toolbars_Dock_Area_Left
        '
        Me._PanelTollbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTollbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelTollbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelTollbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTollbar_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 21)
        Me._PanelTollbar_Toolbars_Dock_Area_Left.Name = "_PanelTollbar_Toolbars_Dock_Area_Left"
        Me._PanelTollbar_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 0)
        Me._PanelTollbar_Toolbars_Dock_Area_Left.ToolbarsManager = Me.toolbarsManagerAssigns
        Me._PanelTollbar_Toolbars_Dock_Area_Left.UseAppStyling = False
        '
        'toolbarsManagerAssigns
        '
        Me.toolbarsManagerAssigns.DesignerFlags = 1
        Me.toolbarsManagerAssigns.DockWithinContainer = Me.PanelTollbar
        Me.toolbarsManagerAssigns.LockToolbars = True
        Me.toolbarsManagerAssigns.ShowFullMenusDelay = 500
        Me.toolbarsManagerAssigns.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool2})
        UltraToolbar1.Text = "UltraToolbarAssigns"
        Me.toolbarsManagerAssigns.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        PopupMenuTool1.SharedPropsInternal.Caption = "Assign"
        Me.toolbarsManagerAssigns.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool1})
        Me.toolbarsManagerAssigns.UseAppStyling = False
        '
        '_PanelTollbar_Toolbars_Dock_Area_Right
        '
        Me._PanelTollbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTollbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelTollbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelTollbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTollbar_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(320, 21)
        Me._PanelTollbar_Toolbars_Dock_Area_Right.Name = "_PanelTollbar_Toolbars_Dock_Area_Right"
        Me._PanelTollbar_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 0)
        Me._PanelTollbar_Toolbars_Dock_Area_Right.ToolbarsManager = Me.toolbarsManagerAssigns
        Me._PanelTollbar_Toolbars_Dock_Area_Right.UseAppStyling = False
        '
        '_PanelTollbar_Toolbars_Dock_Area_Bottom
        '
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 18)
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.Name = "_PanelTollbar_Toolbars_Dock_Area_Bottom"
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(320, 0)
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.toolbarsManagerAssigns
        Me._PanelTollbar_Toolbars_Dock_Area_Bottom.UseAppStyling = False
        '
        '_PanelTollbar_Toolbars_Dock_Area_Top
        '
        Me._PanelTollbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTollbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelTollbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelTollbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTollbar_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelTollbar_Toolbars_Dock_Area_Top.Name = "_PanelTollbar_Toolbars_Dock_Area_Top"
        Me._PanelTollbar_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(320, 21)
        Me._PanelTollbar_Toolbars_Dock_Area_Top.ToolbarsManager = Me.toolbarsManagerAssigns
        Me._PanelTollbar_Toolbars_Dock_Area_Top.UseAppStyling = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.Image = CType(resources.GetObject("Appearance25.Image"), Object)
        Appearance25.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnAdd.Appearance = Appearance25
        Me.btnAdd.Location = New System.Drawing.Point(812, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.OwnAutoTextYN = False
        Me.btnAdd.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Plus
        Me.btnAdd.OwnPictureTxt = ""
        Me.btnAdd.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnAdd.OwnTooltipText = ""
        Me.btnAdd.OwnTooltipTitle = Nothing
        Me.btnAdd.Size = New System.Drawing.Size(23, 22)
        Me.btnAdd.TabIndex = 586
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Appearance26.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnDel.Appearance = Appearance26
        Me.btnDel.Location = New System.Drawing.Point(835, 0)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.OwnAutoTextYN = False
        Me.btnDel.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Loeschen
        Me.btnDel.OwnPictureTxt = ""
        Me.btnDel.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnDel.OwnTooltipText = ""
        Me.btnDel.OwnTooltipTitle = Nothing
        Me.btnDel.Size = New System.Drawing.Size(23, 22)
        Me.btnDel.TabIndex = 585
        '
        'PanelButt
        '
        Me.PanelButt.BackColor = System.Drawing.Color.Transparent
        Me.PanelButt.Controls.Add(Me.PanelDoAutoRes)
        Me.PanelButt.Controls.Add(Me.PanelSelect)
        Me.PanelButt.Controls.Add(Me.DropDownApplications1)
        Me.PanelButt.Controls.Add(Me.PanelButtEdit)
        Me.PanelButt.Controls.Add(Me.PanelClose)
        Me.PanelButt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelButt.Location = New System.Drawing.Point(0, 264)
        Me.PanelButt.Name = "PanelButt"
        Me.PanelButt.Size = New System.Drawing.Size(868, 33)
        Me.PanelButt.TabIndex = 2
        '
        'PanelDoAutoRes
        '
        Me.PanelDoAutoRes.BackColor = System.Drawing.Color.Transparent
        Me.PanelDoAutoRes.Controls.Add(Me.lblAutoAddRessources)
        Me.PanelDoAutoRes.Controls.Add(Me.chkAutoResOnlyAddRes)
        Me.PanelDoAutoRes.Location = New System.Drawing.Point(10, 6)
        Me.PanelDoAutoRes.Name = "PanelDoAutoRes"
        Me.PanelDoAutoRes.Size = New System.Drawing.Size(190, 21)
        Me.PanelDoAutoRes.TabIndex = 595
        '
        'lblAutoAddRessources
        '
        Appearance27.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance27.FontData.UnderlineAsString = "True"
        Appearance27.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAutoAddRessources.Appearance = Appearance27
        Me.lblAutoAddRessources.AutoSize = True
        Me.lblAutoAddRessources.Location = New System.Drawing.Point(3, 4)
        Me.lblAutoAddRessources.Name = "lblAutoAddRessources"
        Me.lblAutoAddRessources.Size = New System.Drawing.Size(70, 14)
        Me.lblAutoAddRessources.TabIndex = 591
        Me.lblAutoAddRessources.TabStop = True
        Me.lblAutoAddRessources.Tag = "0"
        Me.lblAutoAddRessources.Value = "Auto-Res On"
        '
        'chkAutoResOnlyAddRes
        '
        Appearance28.BackColor = System.Drawing.Color.Transparent
        Appearance28.FontData.SizeInPoints = 9.0!
        Me.chkAutoResOnlyAddRes.Appearance = Appearance28
        Me.chkAutoResOnlyAddRes.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoResOnlyAddRes.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkAutoResOnlyAddRes.Location = New System.Drawing.Point(79, 4)
        Me.chkAutoResOnlyAddRes.Name = "chkAutoResOnlyAddRes"
        Me.chkAutoResOnlyAddRes.Size = New System.Drawing.Size(100, 14)
        Me.chkAutoResOnlyAddRes.TabIndex = 592
        Me.chkAutoResOnlyAddRes.Text = "Only add Res"
        Me.chkAutoResOnlyAddRes.Visible = False
        '
        'PanelSelect
        '
        Me.PanelSelect.Controls.Add(Me.btnSelect)
        Me.PanelSelect.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelSelect.Location = New System.Drawing.Point(320, 0)
        Me.PanelSelect.Name = "PanelSelect"
        Me.PanelSelect.Size = New System.Drawing.Size(159, 33)
        Me.PanelSelect.TabIndex = 594
        Me.PanelSelect.Visible = False
        '
        'btnSelect
        '
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSelect.Appearance = Appearance29
        Me.btnSelect.Enabled = False
        Me.btnSelect.Location = New System.Drawing.Point(86, 2)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.OwnAutoTextYN = False
        Me.btnSelect.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnSelect.OwnPictureTxt = ""
        Me.btnSelect.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnSelect.OwnTooltipText = ""
        Me.btnSelect.OwnTooltipTitle = Nothing
        Me.btnSelect.Size = New System.Drawing.Size(67, 27)
        Me.btnSelect.TabIndex = 593
        Me.btnSelect.Text = "OK"
        '
        'DropDownApplications1
        '
        Me.DropDownApplications1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DropDownApplications1.Location = New System.Drawing.Point(263, 7)
        Me.DropDownApplications1.Name = "DropDownApplications1"
        Me.DropDownApplications1.Size = New System.Drawing.Size(49, 17)
        Me.DropDownApplications1.TabIndex = 591
        Me.DropDownApplications1.Visible = False
        '
        'PanelButtEdit
        '
        Me.PanelButtEdit.BackColor = System.Drawing.Color.Transparent
        Me.PanelButtEdit.Controls.Add(Me.btnEdit)
        Me.PanelButtEdit.Controls.Add(Me.btnSave2)
        Me.PanelButtEdit.Controls.Add(Me.btnCancel)
        Me.PanelButtEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButtEdit.Location = New System.Drawing.Point(479, 0)
        Me.PanelButtEdit.Name = "PanelButtEdit"
        Me.PanelButtEdit.Size = New System.Drawing.Size(295, 33)
        Me.PanelButtEdit.TabIndex = 590
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance30.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnEdit.Appearance = Appearance30
        Me.btnEdit.Location = New System.Drawing.Point(8, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.OwnAutoTextYN = False
        Me.btnEdit.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnEdit.OwnPictureTxt = ""
        Me.btnEdit.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnEdit.OwnTooltipText = ""
        Me.btnEdit.OwnTooltipTitle = Nothing
        Me.btnEdit.Size = New System.Drawing.Size(94, 27)
        Me.btnEdit.TabIndex = 592
        Me.btnEdit.Text = "Edit"
        '
        'btnSave2
        '
        Me.btnSave2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.Image = CType(resources.GetObject("Appearance31.Image"), Object)
        Appearance31.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSave2.Appearance = Appearance31
        Me.btnSave2.Location = New System.Drawing.Point(193, 2)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.OwnAutoTextYN = True
        Me.btnSave2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Speichern
        Me.btnSave2.OwnPictureTxt = ""
        Me.btnSave2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnSave2.OwnTooltipText = ""
        Me.btnSave2.OwnTooltipTitle = Nothing
        Me.btnSave2.Size = New System.Drawing.Size(96, 27)
        Me.btnSave2.TabIndex = 583
        Me.btnSave2.Text = "Speichern"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance32.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnCancel.Appearance = Appearance32
        Me.btnCancel.Location = New System.Drawing.Point(103, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OwnAutoTextYN = False
        Me.btnCancel.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnCancel.OwnPictureTxt = ""
        Me.btnCancel.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnCancel.OwnTooltipText = ""
        Me.btnCancel.OwnTooltipTitle = Nothing
        Me.btnCancel.Size = New System.Drawing.Size(89, 27)
        Me.btnCancel.TabIndex = 591
        Me.btnCancel.Text = "Cancel"
        '
        'PanelClose
        '
        Me.PanelClose.Controls.Add(Me.btnClose2)
        Me.PanelClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelClose.Location = New System.Drawing.Point(774, 0)
        Me.PanelClose.Name = "PanelClose"
        Me.PanelClose.Size = New System.Drawing.Size(94, 33)
        Me.PanelClose.TabIndex = 589
        '
        'btnClose2
        '
        Appearance33.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnClose2.Appearance = Appearance33
        Me.btnClose2.Location = New System.Drawing.Point(6, 2)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.OwnAutoTextYN = False
        Me.btnClose2.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnClose2.OwnPictureTxt = ""
        Me.btnClose2.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnClose2.OwnTooltipText = ""
        Me.btnClose2.OwnTooltipTitle = Nothing
        Me.btnClose2.Size = New System.Drawing.Size(72, 27)
        Me.btnClose2.TabIndex = 584
        Me.btnClose2.Text = "Close"
        '
        'UltraSplitter1
        '
        Me.UltraSplitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UltraSplitter1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.UltraSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraSplitter1.Location = New System.Drawing.Point(0, 195)
        Me.UltraSplitter1.Name = "UltraSplitter1"
        Me.UltraSplitter1.RestoreExtent = 195
        Me.UltraSplitter1.Size = New System.Drawing.Size(868, 5)
        Me.UltraSplitter1.TabIndex = 8
        '
        'PanelSelGroups
        '
        Me.PanelSelGroups.BackColor = System.Drawing.Color.Transparent
        Me.PanelSelGroups.Controls.Add(Me.gridBagLayoutPanelGroups)
        Me.PanelSelGroups.Controls.Add(Me.PanelSearch)
        Me.PanelSelGroups.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSelGroups.Location = New System.Drawing.Point(0, 0)
        Me.PanelSelGroups.Name = "PanelSelGroups"
        Me.PanelSelGroups.Size = New System.Drawing.Size(868, 195)
        Me.PanelSelGroups.TabIndex = 5
        '
        'gridBagLayoutPanelGroups
        '
        Me.gridBagLayoutPanelGroups.Controls.Add(Me.gridGroup)
        Me.gridBagLayoutPanelGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBagLayoutPanelGroups.ExpandToFitHeight = True
        Me.gridBagLayoutPanelGroups.ExpandToFitWidth = True
        Me.gridBagLayoutPanelGroups.Location = New System.Drawing.Point(0, 26)
        Me.gridBagLayoutPanelGroups.Name = "gridBagLayoutPanelGroups"
        Me.gridBagLayoutPanelGroups.Size = New System.Drawing.Size(868, 169)
        Me.gridBagLayoutPanelGroups.TabIndex = 593
        '
        'gridGroup
        '
        Me.gridGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridGroup.DataMember = "tblSelListGroup"
        Me.gridGroup.DataSource = Me.DsAdmin1
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance34.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.gridGroup.DisplayLayout.Appearance = Appearance34
        UltraGridColumn151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn151.CellAppearance = Appearance35
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn151.Header.Appearance = Appearance36
        UltraGridColumn151.Header.VisiblePosition = 14
        UltraGridColumn151.Width = 80
        UltraGridColumn152.Header.VisiblePosition = 1
        UltraGridColumn152.Hidden = True
        UltraGridColumn153.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn153.Header.VisiblePosition = 3
        UltraGridColumn153.Width = 118
        UltraGridColumn154.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn154.Header.Caption = "Application"
        UltraGridColumn154.Header.VisiblePosition = 4
        UltraGridColumn154.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn154.Width = 139
        UltraGridColumn155.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn155.Header.Caption = "Participant"
        UltraGridColumn155.Header.VisiblePosition = 5
        UltraGridColumn155.Width = 129
        UltraGridColumn156.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn156.Header.VisiblePosition = 0
        UltraGridColumn156.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn156.Width = 173
        UltraGridColumn157.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn157.Header.Caption = "Sys"
        UltraGridColumn157.Header.VisiblePosition = 11
        UltraGridColumn157.Width = 58
        UltraGridColumn158.Header.VisiblePosition = 7
        UltraGridColumn159.Header.VisiblePosition = 8
        UltraGridColumn160.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn160.Header.VisiblePosition = 6
        UltraGridColumn160.Width = 191
        UltraGridColumn161.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn161.Header.VisiblePosition = 9
        UltraGridColumn161.Width = 146
        UltraGridColumn162.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn162.Header.VisiblePosition = 10
        UltraGridColumn163.Header.VisiblePosition = 12
        UltraGridColumn163.Width = 210
        UltraGridColumn164.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn164.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn164.Header.VisiblePosition = 13
        UltraGridColumn164.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor
        UltraGridColumn164.Width = 224
        UltraGridColumn165.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn165.Header.VisiblePosition = 15
        UltraGridColumn166.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn166.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn166.Header.VisiblePosition = 2
        UltraGridColumn166.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor
        UltraGridColumn166.Width = 216
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn151, UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn162, UltraGridColumn163, UltraGridColumn164, UltraGridColumn165, UltraGridColumn166})
        UltraGridColumn167.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn167.Header.VisiblePosition = 0
        UltraGridColumn167.Width = 48
        UltraGridColumn168.Header.VisiblePosition = 1
        UltraGridColumn169.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn169.Header.VisiblePosition = 2
        UltraGridColumn169.Width = 96
        UltraGridColumn170.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn170.Header.VisiblePosition = 3
        UltraGridColumn170.Width = 67
        UltraGridColumn171.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn171.Header.VisiblePosition = 4
        UltraGridColumn171.Width = 94
        UltraGridColumn172.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn172.Header.VisiblePosition = 5
        UltraGridColumn172.Width = 55
        UltraGridColumn173.Header.VisiblePosition = 6
        UltraGridColumn174.Header.VisiblePosition = 7
        UltraGridColumn175.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn175.Header.VisiblePosition = 8
        UltraGridColumn176.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn176.Header.VisiblePosition = 9
        UltraGridColumn176.Width = 94
        UltraGridColumn177.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn177.Header.VisiblePosition = 10
        UltraGridColumn178.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn178.Header.VisiblePosition = 11
        UltraGridColumn178.Width = 55
        UltraGridColumn179.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn179.Header.VisiblePosition = 12
        UltraGridColumn179.Width = 64
        UltraGridColumn180.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn180.Header.VisiblePosition = 13
        UltraGridColumn181.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn181.Header.VisiblePosition = 14
        UltraGridColumn182.Header.VisiblePosition = 15
        UltraGridColumn183.Header.VisiblePosition = 17
        UltraGridColumn184.Header.VisiblePosition = 16
        UltraGridColumn185.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn185.Header.VisiblePosition = 19
        UltraGridColumn186.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn186.Header.VisiblePosition = 20
        UltraGridColumn187.Header.VisiblePosition = 21
        UltraGridColumn188.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn188.Header.VisiblePosition = 18
        UltraGridColumn188.Width = 94
        UltraGridColumn189.Header.VisiblePosition = 22
        UltraGridColumn190.Header.VisiblePosition = 23
        UltraGridColumn191.Header.VisiblePosition = 24
        UltraGridColumn192.Header.VisiblePosition = 25
        UltraGridColumn193.Header.VisiblePosition = 26
        UltraGridColumn2.Header.VisiblePosition = 27
        UltraGridColumn194.Header.VisiblePosition = 28
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn167, UltraGridColumn168, UltraGridColumn169, UltraGridColumn170, UltraGridColumn171, UltraGridColumn172, UltraGridColumn173, UltraGridColumn174, UltraGridColumn175, UltraGridColumn176, UltraGridColumn177, UltraGridColumn178, UltraGridColumn179, UltraGridColumn180, UltraGridColumn181, UltraGridColumn182, UltraGridColumn183, UltraGridColumn184, UltraGridColumn185, UltraGridColumn186, UltraGridColumn187, UltraGridColumn188, UltraGridColumn189, UltraGridColumn190, UltraGridColumn191, UltraGridColumn192, UltraGridColumn193, UltraGridColumn2, UltraGridColumn194})
        UltraGridBand4.Hidden = True
        UltraGridColumn195.Header.VisiblePosition = 0
        UltraGridColumn196.Header.VisiblePosition = 1
        UltraGridColumn197.Header.VisiblePosition = 2
        UltraGridColumn198.Header.VisiblePosition = 3
        UltraGridColumn199.Header.VisiblePosition = 4
        UltraGridColumn200.Header.VisiblePosition = 5
        UltraGridColumn201.Header.VisiblePosition = 6
        UltraGridColumn202.Header.VisiblePosition = 7
        UltraGridColumn207.Header.VisiblePosition = 8
        UltraGridColumn208.Header.VisiblePosition = 9
        UltraGridColumn211.Header.VisiblePosition = 10
        UltraGridColumn212.Header.VisiblePosition = 11
        UltraGridColumn213.Header.VisiblePosition = 12
        UltraGridColumn214.Header.VisiblePosition = 13
        UltraGridColumn215.Header.VisiblePosition = 14
        UltraGridColumn216.Header.VisiblePosition = 15
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn195, UltraGridColumn196, UltraGridColumn197, UltraGridColumn198, UltraGridColumn199, UltraGridColumn200, UltraGridColumn201, UltraGridColumn202, UltraGridColumn207, UltraGridColumn208, UltraGridColumn211, UltraGridColumn212, UltraGridColumn213, UltraGridColumn214, UltraGridColumn215, UltraGridColumn216})
        Me.gridGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridGroup.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.gridGroup.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.gridGroup.DisplayLayout.GroupByBox.Appearance = Appearance37
        Appearance38.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridGroup.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance38
        Me.gridGroup.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance39.BackColor2 = System.Drawing.SystemColors.Control
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridGroup.DisplayLayout.GroupByBox.PromptAppearance = Appearance39
        Me.gridGroup.DisplayLayout.MaxColScrollRegions = 1
        Me.gridGroup.DisplayLayout.MaxRowScrollRegions = 1
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Appearance40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridGroup.DisplayLayout.Override.ActiveCellAppearance = Appearance40
        Appearance41.BackColor = System.Drawing.SystemColors.Highlight
        Appearance41.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridGroup.DisplayLayout.Override.ActiveRowAppearance = Appearance41
        Me.gridGroup.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridGroup.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Me.gridGroup.DisplayLayout.Override.CardAreaAppearance = Appearance42
        Appearance43.BorderColor = System.Drawing.Color.Silver
        Appearance43.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridGroup.DisplayLayout.Override.CellAppearance = Appearance43
        Me.gridGroup.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridGroup.DisplayLayout.Override.CellPadding = 0
        Appearance44.BackColor = System.Drawing.SystemColors.Control
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.gridGroup.DisplayLayout.Override.GroupByRowAppearance = Appearance44
        Appearance45.TextHAlignAsString = "Left"
        Me.gridGroup.DisplayLayout.Override.HeaderAppearance = Appearance45
        Me.gridGroup.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridGroup.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.Color.Silver
        Me.gridGroup.DisplayLayout.Override.RowAppearance = Appearance46
        Me.gridGroup.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Me.gridGroup.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance47.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridGroup.DisplayLayout.Override.TemplateAddRowAppearance = Appearance47
        Me.gridGroup.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridGroup.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridGroup.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 3
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.Insets.Top = 2
        GridBagConstraint2.OriginX = 0
        GridBagConstraint2.OriginY = 0
        Me.gridBagLayoutPanelGroups.SetGridBagConstraint(Me.gridGroup, GridBagConstraint2)
        Me.gridGroup.Location = New System.Drawing.Point(5, 2)
        Me.gridGroup.Name = "gridGroup"
        Me.gridBagLayoutPanelGroups.SetPreferredSize(Me.gridGroup, New System.Drawing.Size(499, 119))
        Me.gridGroup.Size = New System.Drawing.Size(858, 164)
        Me.gridGroup.TabIndex = 10
        Me.gridGroup.Text = "Groups"
        '
        'PanelSearch
        '
        Me.PanelSearch.Controls.Add(Me.btnEncryptsSaveToTheClipboardForDelivery)
        Me.PanelSearch.Controls.Add(Me.btnEditGroup)
        Me.PanelSearch.Controls.Add(Me.btnDelGroup)
        Me.PanelSearch.Controls.Add(Me.btnAddGroup)
        Me.PanelSearch.Controls.Add(Me.txtSearchText)
        Me.PanelSearch.Controls.Add(Me.lblSearch)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearch.Location = New System.Drawing.Point(0, 0)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(868, 26)
        Me.PanelSearch.TabIndex = 592
        '
        'btnEncryptsSaveToTheClipboardForDelivery
        '
        Me.btnEncryptsSaveToTheClipboardForDelivery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance48.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnEncryptsSaveToTheClipboardForDelivery.Appearance = Appearance48
        Me.btnEncryptsSaveToTheClipboardForDelivery.ContextMenuStrip = Me.ContextMenuStripTop
        Me.btnEncryptsSaveToTheClipboardForDelivery.Location = New System.Drawing.Point(690, 3)
        Me.btnEncryptsSaveToTheClipboardForDelivery.Name = "btnEncryptsSaveToTheClipboardForDelivery"
        Me.btnEncryptsSaveToTheClipboardForDelivery.Size = New System.Drawing.Size(26, 22)
        Me.btnEncryptsSaveToTheClipboardForDelivery.TabIndex = 595
        Me.btnEncryptsSaveToTheClipboardForDelivery.TabStop = False
        '
        'ContextMenuStripTop
        '
        Me.ContextMenuStripTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearCopiedRowsInRamToolStripMenuItem, Me.ToolStripMenuItem1, Me.EncryptedToClipboardNoLicenseKeyToolStripMenuItem})
        Me.ContextMenuStripTop.Name = "menuStripGrid"
        Me.ContextMenuStripTop.Size = New System.Drawing.Size(287, 54)
        '
        'ClearCopiedRowsInRamToolStripMenuItem
        '
        Me.ClearCopiedRowsInRamToolStripMenuItem.Name = "ClearCopiedRowsInRamToolStripMenuItem"
        Me.ClearCopiedRowsInRamToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ClearCopiedRowsInRamToolStripMenuItem.Text = "Clear copied rows in Ram"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(283, 6)
        '
        'EncryptedToClipboardNoLicenseKeyToolStripMenuItem
        '
        Me.EncryptedToClipboardNoLicenseKeyToolStripMenuItem.Name = "EncryptedToClipboardNoLicenseKeyToolStripMenuItem"
        Me.EncryptedToClipboardNoLicenseKeyToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.EncryptedToClipboardNoLicenseKeyToolStripMenuItem.Text = "Encrypting to clipboard (No LicenseKey)"
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance49.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnEditGroup.Appearance = Appearance49
        Me.btnEditGroup.Location = New System.Drawing.Point(720, 3)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.OwnAutoTextYN = False
        Me.btnEditGroup.OwnPicture = qs2.Resources.getRes.ePicture.none
        Me.btnEditGroup.OwnPictureTxt = ""
        Me.btnEditGroup.OwnSizeMode = qs2.core.Enums.eSize.big
        Me.btnEditGroup.OwnTooltipText = ""
        Me.btnEditGroup.OwnTooltipTitle = Nothing
        Me.btnEditGroup.Size = New System.Drawing.Size(87, 22)
        Me.btnEditGroup.TabIndex = 593
        Me.btnEditGroup.Text = "Edit"
        '
        'btnDelGroup
        '
        Me.btnDelGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance50.Image = CType(resources.GetObject("Appearance50.Image"), Object)
        Appearance50.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnDelGroup.Appearance = Appearance50
        Me.btnDelGroup.Location = New System.Drawing.Point(835, 3)
        Me.btnDelGroup.Name = "btnDelGroup"
        Me.btnDelGroup.OwnAutoTextYN = False
        Me.btnDelGroup.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Loeschen
        Me.btnDelGroup.OwnPictureTxt = ""
        Me.btnDelGroup.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnDelGroup.OwnTooltipText = ""
        Me.btnDelGroup.OwnTooltipTitle = Nothing
        Me.btnDelGroup.Size = New System.Drawing.Size(23, 22)
        Me.btnDelGroup.TabIndex = 592
        '
        'btnAddGroup
        '
        Me.btnAddGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance51.Image = CType(resources.GetObject("Appearance51.Image"), Object)
        Appearance51.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnAddGroup.Appearance = Appearance51
        Me.btnAddGroup.Location = New System.Drawing.Point(812, 3)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.OwnAutoTextYN = False
        Me.btnAddGroup.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Plus
        Me.btnAddGroup.OwnPictureTxt = ""
        Me.btnAddGroup.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnAddGroup.OwnTooltipText = ""
        Me.btnAddGroup.OwnTooltipTitle = Nothing
        Me.btnAddGroup.Size = New System.Drawing.Size(23, 22)
        Me.btnAddGroup.TabIndex = 589
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance52.BackColor = System.Drawing.Color.White
        Me.txtSearchText.Appearance = Appearance52
        Me.txtSearchText.BackColor = System.Drawing.Color.White
        Me.txtSearchText.Location = New System.Drawing.Point(61, 1)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(244, 21)
        Me.txtSearchText.TabIndex = 590
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.Location = New System.Drawing.Point(6, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(139, 16)
        Me.lblSearch.TabIndex = 591
        Me.lblSearch.Text = "Search"
        '
        'PanelTopAll
        '
        Me.PanelTopAll.Controls.Add(Me.ComboApplication1)
        Me.PanelTopAll.Controls.Add(Me.btnReload2)
        Me.PanelTopAll.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTopAll.Location = New System.Drawing.Point(0, 0)
        Me.PanelTopAll.Name = "PanelTopAll"
        Me.PanelTopAll.Size = New System.Drawing.Size(868, 27)
        Me.PanelTopAll.TabIndex = 8
        '
        'ComboApplication1
        '
        Me.ComboApplication1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboApplication1.BackColor = System.Drawing.Color.Transparent
        Me.ComboApplication1.Location = New System.Drawing.Point(479, 3)
        Me.ComboApplication1.Name = "ComboApplication1"
        Me.ComboApplication1.OwnLabelVisible = True
        Me.ComboApplication1.Size = New System.Drawing.Size(354, 22)
        Me.ComboApplication1.TabIndex = 590
        '
        'btnReload2
        '
        Me.btnReload2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance53.Image = CType(resources.GetObject("Appearance53.Image"), Object)
        Appearance53.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnReload2.Appearance = Appearance53
        Me.btnReload2.Location = New System.Drawing.Point(835, 3)
        Me.btnReload2.Name = "btnReload2"
        Me.btnReload2.OwnAutoTextYN = False
        Me.btnReload2.OwnPicture = qs2.Resources.getRes.Allgemein.ico_Aktualisieren
        Me.btnReload2.OwnPictureTxt = ""
        Me.btnReload2.OwnSizeMode = qs2.core.Enums.eSize.small
        Me.btnReload2.OwnTooltipText = ""
        Me.btnReload2.OwnTooltipTitle = Nothing
        Me.btnReload2.Size = New System.Drawing.Size(23, 22)
        Me.btnReload2.TabIndex = 584
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ICO_Neu.ico")
        Me.ImageList1.Images.SetKeyName(1, "ICO_edit.ico")
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(870, 547)
        Me.UltraTabControl1.TabIndex = 8
        UltraTab1.Key = "selLists"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "SelLists"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(868, 524)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'contSelLists
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Name = "contSelLists"
        Me.Size = New System.Drawing.Size(870, 547)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.PanelAll.ResumeLayout(False)
        Me.PanelSelLists.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.gridSelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStripGrid.ResumeLayout(False)
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSelListTop.ResumeLayout(False)
        Me.PanelButtonsSort.ResumeLayout(False)
        Me.PanelTollbar.ResumeLayout(False)
        CType(Me.toolbarsManagerAssigns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButt.ResumeLayout(False)
        Me.PanelDoAutoRes.ResumeLayout(False)
        Me.PanelDoAutoRes.PerformLayout()
        CType(Me.chkAutoResOnlyAddRes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSelect.ResumeLayout(False)
        Me.PanelButtEdit.ResumeLayout(False)
        Me.PanelClose.ResumeLayout(False)
        Me.PanelSelGroups.ResumeLayout(False)
        CType(Me.gridBagLayoutPanelGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridBagLayoutPanelGroups.ResumeLayout(False)
        CType(Me.gridGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        Me.ContextMenuStripTop.ResumeLayout(False)
        CType(Me.txtSearchText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTopAll.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelSelLists As System.Windows.Forms.Panel
    Friend WithEvents PanelSelGroups As System.Windows.Forms.Panel
    Friend WithEvents DsAdmin1 As qs2.core.vb.dsAdmin
    Friend WithEvents gridSelList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PanelButt As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents menuStripGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents listOfSublistenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridGroup As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnClose2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnSave2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnReload2 As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnDel As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents PanelButtEdit As System.Windows.Forms.Panel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btnEdit As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnCancel As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents DropDownApplications1 As qs2.sitemap.dropDownApplications
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelSelListTop As System.Windows.Forms.Panel
    Friend WithEvents SetPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents txtSearchText As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAdd As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents gridBagLayoutPanelGroups As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnUp As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnDown As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnAddGroup As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnDelGroup As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents btnEditGroup As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents PanelAll As System.Windows.Forms.Panel
    Friend WithEvents PanelTopAll As System.Windows.Forms.Panel
    Friend WithEvents PanelTollbar As System.Windows.Forms.Panel
    Friend WithEvents PanelTollbar_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelTollbar_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents toolbarsManagerAssigns As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _PanelTollbar_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelTollbar_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelTollbar_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents PanelButtonsSort As System.Windows.Forms.Panel
    Friend WithEvents PanelSelect As System.Windows.Forms.Panel
    Friend WithEvents btnSelect As qs2.sitemap.ownControls.inherit_Infrag.InfragButton
    Friend WithEvents InfoRessourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranslateEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents PanelClose As System.Windows.Forms.Panel
    Public WithEvents ComboApplication1 As qs2.sitemap.comboApplication
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraSplitter1 As Infragistics.Win.Misc.UltraSplitter
    Friend WithEvents ToolStripMenuItemSpace01 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopySellistAndRessourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripTop As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearCopiedRowsInRamToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnEncryptsSaveToTheClipboardForDelivery As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAutoAddRessources As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel
    Public WithEvents chkAutoResOnlyAddRes As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents PanelDoAutoRes As Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents EncryptedToClipboardNoLicenseKeyToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignToMeToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Public WithEvents btnUserRights As ownControls.inherit_Infrag.InfragButton
End Class
