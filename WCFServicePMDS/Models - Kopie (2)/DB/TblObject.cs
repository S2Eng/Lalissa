using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblObject
    {
        public TblObject()
        {
            TblMedArchiv = new HashSet<TblMedArchiv>();
            TblObjectApplications = new HashSet<TblObjectApplications>();
            TblObjectRelIdguidObjectNavigation = new HashSet<TblObjectRel>();
            TblObjectRelIdguidObjectSubNavigation = new HashSet<TblObjectRel>();
            TblParticipants = new HashSet<TblParticipants>();
            TblSelListEntriesObj = new HashSet<TblSelListEntriesObj>();
            TblStay = new HashSet<TblStay>();
        }

        public int Id { get; set; }
        public Guid Idguid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameCombination { get; set; }
        public bool IsPatient { get; set; }
        public bool IsPersonal { get; set; }
        public bool IsUser { get; set; }
        public string Title { get; set; }
        public DateTime? Dob { get; set; }
        public int Role { get; set; }
        public int? Gender { get; set; }
        public int? Race { get; set; }
        public string Ssn { get; set; }
        public int IsJehova { get; set; }
        public string KavVidierungPwd { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string UserShort { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string UserNameDomain { get; set; }
        public bool IsImported { get; set; }
        public int Sort { get; set; }
        public string ExtId { get; set; }
        public bool Active { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime Created { get; set; }
        public string Idparticipant { get; set; }
        public int MtStat { get; set; }
        public DateTime? MtDate { get; set; }
        public int Mtlocatn { get; set; }
        public int MtCause { get; set; }
        public string Icd9 { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public string MtCauseDescription { get; set; }
        public int PatOrigin { get; set; }
        public bool Systemuser { get; set; }
        public string CongenitalData { get; set; }
        public int ExtIdnr { get; set; }
        public bool ConAntDiag { get; set; }
        public int ConGestAge { get; set; }
        public string UserCode { get; set; }
        public string MaidenName { get; set; }
        public string Bpkz { get; set; }
        public string Bpkz1 { get; set; }
        public string Bpkz2 { get; set; }
        public bool ShowUpdateNewsAtStartup { get; set; }

        public virtual TblAdress TblAdress { get; set; }
        public virtual ICollection<TblMedArchiv> TblMedArchiv { get; set; }
        public virtual ICollection<TblObjectApplications> TblObjectApplications { get; set; }
        public virtual ICollection<TblObjectRel> TblObjectRelIdguidObjectNavigation { get; set; }
        public virtual ICollection<TblObjectRel> TblObjectRelIdguidObjectSubNavigation { get; set; }
        public virtual ICollection<TblParticipants> TblParticipants { get; set; }
        public virtual ICollection<TblSelListEntriesObj> TblSelListEntriesObj { get; set; }
        public virtual ICollection<TblStay> TblStay { get; set; }
    }
}