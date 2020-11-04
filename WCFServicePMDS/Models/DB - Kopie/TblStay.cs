using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblStay
    {
        public TblStay()
        {
            InverseIdNavigation = new HashSet<TblStay>();
            TblMedArchiv = new HashSet<TblMedArchiv>();
            TblSelListEntriesObj = new HashSet<TblSelListEntriesObj>();
            TblStayAdditions = new HashSet<TblStayAdditions>();
        }

        public int Id { get; set; }
        public string Idparticipant { get; set; }
        public Guid Idguid { get; set; }
        public string Idapplication { get; set; }
        public string MedRecN { get; set; }
        public int Incidence { get; set; }
        public int? IdstayParent { get; set; }
        public string IdparticipantParent { get; set; }
        public string IdapplicationParent { get; set; }
        public int StayTyp { get; set; }
        public int? Optyp { get; set; }
        public DateTime? SurgDtStart { get; set; }
        public DateTime? SurgDtEnd { get; set; }
        public DateTime? FupdtPlan { get; set; }
        public DateTime? Fupdt { get; set; }
        public int SurgDuratMin { get; set; }
        public DateTime? AdmitDt { get; set; }
        public string PatExtId { get; set; }
        public Guid PatIdguid { get; set; }
        public int PatAge { get; set; }
        public decimal PatHeight { get; set; }
        public decimal PatWeight { get; set; }
        public decimal PatBmi { get; set; }
        public int Bmigroup { get; set; }
        public DateTime? DischDt { get; set; }
        public bool IsActive { get; set; }
        public bool IsPlanned { get; set; }
        public bool StayComplete { get; set; }
        public string Idvendor { get; set; }
        public string DataVrsn { get; set; }
        public string SoftVrsn { get; set; }
        public string SoftVrsnTo { get; set; }
        public DateTime CreatedDt { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public int MtOpD { get; set; }
        public int Mt30Stat { get; set; }
        public int DisLocatn { get; set; }
        public int MtDcstat { get; set; }
        public string PatStreet { get; set; }
        public string PatZip { get; set; }
        public string PatCity { get; set; }
        public int PatCountryId { get; set; }
        public int HasComplications { get; set; }
        public int Surgeon { get; set; }
        public int SurgAssist1 { get; set; }
        public int SurgAssist2 { get; set; }
        public int SurgPartim { get; set; }
        public int SurgReOp { get; set; }
        public int Perfusionist { get; set; }
        public int PerfusionistAssist1 { get; set; }
        public int Anaesthesist { get; set; }
        public int AnaesthesistAssist1 { get; set; }
        public int Consultant { get; set; }
        public int Resident { get; set; }
        public int ScrubNurse { get; set; }
        public int StayDuratDays { get; set; }
        public int StayPostOpDuratDays { get; set; }
        public int PatOrigin { get; set; }
        public string PatTel { get; set; }
        public string Payor { get; set; }
        public bool IsCongenital { get; set; }
        public bool Sent { get; set; }
        public DateTime? SentDate { get; set; }
        public bool? IsAquired { get; set; }
        public string CongenitalData { get; set; }
        public string OrgUnitStay { get; set; }
        public string PatCountry { get; set; }
        public int SurgAssumption { get; set; }
        public DateTime? LastChange { get; set; }
        public DateTime? OpenSince { get; set; }
        public string Bpkzstatus { get; set; }
        public string Bpkz { get; set; }
        public int Bpkzdone { get; set; }
        public bool Bpkzok { get; set; }

        public virtual TblStay IdNavigation { get; set; }
        public virtual TblObject PatIdgu { get; set; }
        public virtual ICollection<TblStay> InverseIdNavigation { get; set; }
        public virtual ICollection<TblMedArchiv> TblMedArchiv { get; set; }
        public virtual ICollection<TblSelListEntriesObj> TblSelListEntriesObj { get; set; }
        public virtual ICollection<TblStayAdditions> TblStayAdditions { get; set; }
    }
}