Partial Class sqlCARDIAC
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlCARDIAC))
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.daVLADCardiacStays = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand()
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=STYSRV02V\SQL2008R2;Initial Catalog=QS2_DEV;Integrated Security=True"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'daVLADCardiacStays
        '
        Me.daVLADCardiacStays.SelectCommand = Me.SqlCommand1
        Me.daVLADCardiacStays.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "CARDIAC_STAYS", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EuroScoreVersion", "EuroScoreVersion"), New System.Data.Common.DataColumnMapping("LogEuroScore", "LogEuroScore"), New System.Data.Common.DataColumnMapping("LogEuroScoreObserved", "LogEuroScoreObserved"), New System.Data.Common.DataColumnMapping("LogEuroScore_II", "LogEuroScore_II"), New System.Data.Common.DataColumnMapping("LogEuroScoreObserved_II", "LogEuroScoreObserved_II"), New System.Data.Common.DataColumnMapping("SumEuroScore", "SumEuroScore"), New System.Data.Common.DataColumnMapping("SumEuroScoreObserved", "SumEuroScoreObserved"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"), New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("MedRecN", "MedRecN"), New System.Data.Common.DataColumnMapping("Incidence", "Incidence"), New System.Data.Common.DataColumnMapping("IDStayParent", "IDStayParent"), New System.Data.Common.DataColumnMapping("IDParticipantParent", "IDParticipantParent"), New System.Data.Common.DataColumnMapping("IDApplicationParent", "IDApplicationParent"), New System.Data.Common.DataColumnMapping("StayTyp", "StayTyp"), New System.Data.Common.DataColumnMapping("OPTyp", "OPTyp"), New System.Data.Common.DataColumnMapping("SurgDtStart", "SurgDtStart"), New System.Data.Common.DataColumnMapping("SurgDtEnd", "SurgDtEnd"), New System.Data.Common.DataColumnMapping("FUPDtPlan", "FUPDtPlan"), New System.Data.Common.DataColumnMapping("FUPDt", "FUPDt"), New System.Data.Common.DataColumnMapping("SurgDuratMin", "SurgDuratMin"), New System.Data.Common.DataColumnMapping("AdmitDt", "AdmitDt"), New System.Data.Common.DataColumnMapping("PatExtID", "PatExtID"), New System.Data.Common.DataColumnMapping("PatIDGuid", "PatIDGuid"), New System.Data.Common.DataColumnMapping("PatAge", "PatAge"), New System.Data.Common.DataColumnMapping("PatHeight", "PatHeight"), New System.Data.Common.DataColumnMapping("PatWeight", "PatWeight"), New System.Data.Common.DataColumnMapping("PatBMI", "PatBMI"), New System.Data.Common.DataColumnMapping("BMIGroup", "BMIGroup"), New System.Data.Common.DataColumnMapping("DischDt", "DischDt"), New System.Data.Common.DataColumnMapping("IsActive", "IsActive"), New System.Data.Common.DataColumnMapping("IsPlanned", "IsPlanned"), New System.Data.Common.DataColumnMapping("StayComplete", "StayComplete"), New System.Data.Common.DataColumnMapping("IDVendor", "IDVendor"), New System.Data.Common.DataColumnMapping("DataVrsn", "DataVrsn"), New System.Data.Common.DataColumnMapping("SoftVrsn", "SoftVrsn"), New System.Data.Common.DataColumnMapping("SoftVrsnTo", "SoftVrsnTo"), New System.Data.Common.DataColumnMapping("CreatedDt", "CreatedDt"), New System.Data.Common.DataColumnMapping("Classification", "Classification"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("MtOpD", "MtOpD"), New System.Data.Common.DataColumnMapping("Mt30Stat", "Mt30Stat"), New System.Data.Common.DataColumnMapping("DisLocatn", "DisLocatn"), New System.Data.Common.DataColumnMapping("MtDCStat", "MtDCStat"), New System.Data.Common.DataColumnMapping("PatStreet", "PatStreet"), New System.Data.Common.DataColumnMapping("PatZIP", "PatZIP"), New System.Data.Common.DataColumnMapping("PatCity", "PatCity"), New System.Data.Common.DataColumnMapping("PatCountry", "PatCountry"), New System.Data.Common.DataColumnMapping("PatCountryID", "PatCountryID"), New System.Data.Common.DataColumnMapping("PatOrigin", "PatOrigin"), New System.Data.Common.DataColumnMapping("PatTel", "PatTel"), New System.Data.Common.DataColumnMapping("HasComplications", "HasComplications"), New System.Data.Common.DataColumnMapping("Surgeon", "Surgeon"), New System.Data.Common.DataColumnMapping("Surg_Assist1", "Surg_Assist1"), New System.Data.Common.DataColumnMapping("Surg_Assist2", "Surg_Assist2"), New System.Data.Common.DataColumnMapping("Surg_Partim", "Surg_Partim"), New System.Data.Common.DataColumnMapping("Surg_ReOp", "Surg_ReOp"), New System.Data.Common.DataColumnMapping("Surg_Assumption", "Surg_Assumption"), New System.Data.Common.DataColumnMapping("Perfusionist", "Perfusionist"), New System.Data.Common.DataColumnMapping("Perfusionist_Assist1", "Perfusionist_Assist1"), New System.Data.Common.DataColumnMapping("Anaesthesist", "Anaesthesist"), New System.Data.Common.DataColumnMapping("Anaesthesist_Assist1", "Anaesthesist_Assist1"), New System.Data.Common.DataColumnMapping("Consultant", "Consultant"), New System.Data.Common.DataColumnMapping("Resident", "Resident"), New System.Data.Common.DataColumnMapping("ScrubNurse", "ScrubNurse"), New System.Data.Common.DataColumnMapping("StayDuratDays", "StayDuratDays"), New System.Data.Common.DataColumnMapping("StayPostOpDuratDays", "StayPostOpDuratDays"), New System.Data.Common.DataColumnMapping("Payor", "Payor"), New System.Data.Common.DataColumnMapping("Sent", "Sent"), New System.Data.Common.DataColumnMapping("SentDate", "SentDate"), New System.Data.Common.DataColumnMapping("CongenitalData", "CongenitalData"), New System.Data.Common.DataColumnMapping("OrgUnitStay", "OrgUnitStay"), New System.Data.Common.DataColumnMapping("IsSurgical", "IsSurgical"), New System.Data.Common.DataColumnMapping("IsCardiological", "IsCardiological"), New System.Data.Common.DataColumnMapping("IsCongenital", "IsCongenital"), New System.Data.Common.DataColumnMapping("MajorProcedure", "MajorProcedure")})})
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = resources.GetString("SqlCommand1.CommandText")
        Me.SqlCommand1.Connection = Me.SqlConnection1

    End Sub
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Public WithEvents daVLADCardiacStays As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand1 As SqlClient.SqlCommand
End Class
