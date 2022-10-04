using Chilkat;
using PMDS.db.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using S2Extensions;



namespace qs2.core.db.ERSystem
{

    public class businessFramework
    {

        public enum eTypIDGroup
        {
            Usergroups = 0,
            Roles = 1,
            Right = 2,
            Reports = 3,
            Queries = 4,
            Procedures = 5,
            Criteria = 6,
            CompletedChapter = 7,
            Chapters0 = 8,
            Chapters1 = 9,
            ProcGrp0 = 10,
            ProcGrp1 = 11
        }

        public class EACTSUser
        {
            public int ID;
            public Guid IDGuid;
            public string LastName = "";
            public string FirstName = "";
            public string EACTS_Role = "";
        }

        public static bool Stayinserted = false;
        public static bool StayAlreadyExists = false;
        public static bool StayAutoOpenError = false;

        private static string ConnString { get; set; }


        public EACTSUser getEACTSUserByRole(Guid IDObjectGuid, int IDObject, int Role)
        {
            //Role: Surgeon (1) = 10020001, Perfusionist (2) = 10020004 in Classification
           try
            {
               EACTSUser retClass = new EACTSUser();

               using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
               {
                    System.Linq.IQueryable<tblObject> tObject = null;

                    if (IDObject == 0)
                    {
                        tObject = db.tblObject.Where(p => p.IDGuid == IDObjectGuid);
                    }
                    else
                    {
                        tObject = db.tblObject.Where(p => p.ID == IDObject);
                    }
                    if (tObject.Count() == 1)
                    {
                        tblObject rObject = tObject.First();
                        if (Role == 10020001) retClass.EACTS_Role = "surgeon";
                        if (Role == 10020002) retClass.EACTS_Role = "perfusionist";
                        if (Role == 10020003) retClass.EACTS_Role = "anaesthesist";
                        retClass.LastName = rObject.LastName;
                        retClass.FirstName = rObject.FirstName;
                        retClass.ID = rObject.ID;
                        retClass.IDGuid = rObject.IDGuid;
                        return retClass;
                    }
                    else
                        return retClass;
               }

                return retClass;
           }

           //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
           //{
           //    throw new System.Data.Entity.Validation.DbEntityValidationException(dbBase.getDbEntityValidationException(ex), ex);
           //}

           catch (Exception ex)
           {
               throw new Exception("qs2.core.db.ERSystem.businessFramework.getEACTSUserByRole: " + ex.ToString());
           }
        }


        public List<Guid> GetSelListDocuments(string IDApplication, string IDParticipant)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    return (from s in db.tblSelListEntries
                            join g in db.tblSelListGroup on s.IDGroup equals g.ID
                            join sobj in db.tblSelListEntriesObj on s.ID equals sobj.IDSelListEntrySublist
                            where g.IDGroupStr == "Documents" && (g.IDApplication == IDApplication || g.IDApplication == "ALL") &&
                            g.IDParticipant == "ALL" && (s.IDParticipant == IDParticipant || s.IDParticipant == "ALL") &&
                            sobj.typIDGroup == "Queries"
                            select (Guid)sobj.IDGuid).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUsercode: " + ex.ToString());
            }
        }

        public bool checkUsercode(string Usercode, ref tblObject rObjectReturn, ref string MessageReturn)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.UserCode == Usercode) && o.UserCode != "" && 
                                                                ((o.IDParticipant == qs2.core.license.doLicense.rParticipant.IDParticipant.Trim() && o.UserName != "Supervisor") || 
                                                                (o.UserName == "Supervisor")));
                    if (tObject.Count() == 1)
                    {
                        tblObject rObject = tObject.First();
                        rObjectReturn = rObject;
                        return true;
                    }
                    else if (tObject.Count() > 1)
                    {
                        throw new Exception("checkUsercode: Usercode '" + Usercode.Trim() + "' exists more than one in Database!");
                    }
                    else
                    {
                        MessageReturn = "WrongUsercode";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUsercode: " + ex.ToString());
            }
        }

        public bool checkKavVidierungPwd(string KavVidierungPwd, ref tblObject rObjectReturn, ref string MessageReturn)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.KavVidierungPwd == KavVidierungPwd) && o.KavVidierungPwd != "" &&
                                                                ((o.IDParticipant == qs2.core.license.doLicense.rParticipant.IDParticipant.Trim() && o.UserName != "Supervisor") ||
                                                                (o.UserName == "Supervisor")));
                    if (tObject.Count() == 1)
                    {
                        tblObject rObject = tObject.First();
                        rObjectReturn = rObject;
                        return true;
                    }
                    else if (tObject.Count() > 1)
                    {
                        throw new Exception("checkKavVidierungPwd: KavVidierungPwd '" + KavVidierungPwd.Trim() + "' exists more than one in Database!");
                    }
                    else
                    {
                        MessageReturn = "WrongKavVidierungPwd";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkKavVidierungPwd: " + ex.ToString());
            }
        }
        public tblStay getAllStaysForPatient(Guid PatIDGuid, ref PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => o.PatIDGuid == PatIDGuid);
                return tStay.First();
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getAllStaysForPatient: " + ex.ToString());
            }
        }
        public bool checkUsercodeExistsInDb(string Usercode, Guid IDNotCheck)
        {
            try
            {
                if (Usercode.Trim() != "")
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                    {
                        System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => o.UserCode == Usercode && o.UserCode != "" && o.IDGuid != IDNotCheck &&
                                                                                        o.IDParticipant == qs2.core.license.doLicense.rParticipant.IDParticipant.Trim());
                        if (tObject.Count() == 1)
                        {
                            tblObject rObject = tObject.First();
                            return true;
                        }
                        else if (tObject.Count() > 1)
                        {
                            throw new Exception("UsercodeNotExists: Usercode '" + Usercode.Trim() + "' exists more than one in Database!");
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false; 
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUsercodeExistsInDb: " + ex.ToString());
            }
        }

        public System.Collections.Generic.Dictionary<int, tblObject> getAllUsersWithRole(string RoleIDOwnStr)
        {
            try
            {
                System.Collections.Generic.Dictionary<int, tblObject> tUsersWithRole = new System.Collections.Generic.Dictionary<int, tblObject>();
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr.ToLower().Trim() == "roles");
                    if (tSelListGroup.Count() > 0)
                    {
                        tblSelListGroup rSelListGroup = tSelListGroup.First();

                        System.Linq.IQueryable<tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGroup == rSelListGroup.ID && o.IDOwnStr.ToLower().Trim() == RoleIDOwnStr.ToLower().Trim());
                        if (tSelListEntries.Count() > 0)
                        {
                            tblSelListEntries rSelListEntries = tSelListEntries.First();

                            System.Linq.IQueryable<tblSelListEntriesObj> tSelListEntriesObj = db.tblSelListEntriesObj.Where(o => o.IDSelListEntry == rSelListEntries.ID && o.typIDGroup.ToLower().Trim() == "roles");
                            foreach (tblSelListEntriesObj rSelListEntriesObj in tSelListEntriesObj)
                            {
                                System.Linq.IQueryable<tblObject> tblObject = db.tblObject.Where(o => o.ID == rSelListEntriesObj.IDObject);
                                tblObject rObject = tblObject.First();
                                System.Diagnostics.Debug.Print(rObject.ID.ToString());

                                if (!tUsersWithRole.ContainsKey(rObject.ID))        //Keine doppelten Einträge!
                                    tUsersWithRole.Add(rObject.ID, rObject);
                            }

                        }
                    }
                }

                return tUsersWithRole;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getAllUsersWithRole: " + ex.ToString());
            }
        }

        public System.Collections.Generic.SortedDictionary<tblObject, System.Collections.Generic.SortedDictionary<string, tblStay>> getAllPatientsWithStaysCongenital(string RoleIDOwnStr)
        {
            try
            {
                System.Collections.Generic.SortedDictionary<tblObject, System.Collections.Generic.SortedDictionary<string, tblStay>> tPatientsWithStaysCongenital = new System.Collections.Generic.SortedDictionary<tblObject, System.Collections.Generic.SortedDictionary<string, tblStay>>();
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    //System.Linq.IQueryable<tblStay_CARDIAC_A_E> tStays = db.tblStay_CARDIAC_A_E.Where(o => o.sdfsdf
                    //tblStay_CARDIAC_A_E rSelListGroup = tSelListGroup.First();

                    //System.Linq.IQueryable<tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGroup == rSelListGroup.ID && o.IDOwnStr == RoleIDOwnStr.Trim());
                    //tblSelListEntries rSelListEntries = tSelListEntries.First();

                    //System.Linq.IQueryable<tblSelListEntriesObj> tSelListEntriesObj = db.tblSelListEntriesObj.Where(o => o.IDSelListEntry == rSelListEntries.ID &&
                    //                                                                                                    o.typIDGroup == eTypIDGroup.Roles.ToString());
                    //foreach (tblSelListEntriesObj rSelListEntriesObj in tSelListEntriesObj)
                    //{
                    //    System.Linq.IQueryable<tblObject> tblObject = db.tblObject.Where(o => o.ID == rSelListEntriesObj.IDObject);
                    //    tblObject rObject = tblObject.First();
                    //    tUsersWithRole.Add(rObject.ID, rObject);
                    //}
                }

                return tPatientsWithStaysCongenital;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getAllPatientsWithStaysCongenital: " + ex.ToString());
            }
        }
        public tblStay checkIsStay(Guid IDGuidStay)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.IDGuid == IDGuidStay));
                    if (tStay.Count() == 1)
                    {
                        tblStay rStay = tStay.First();
                        return rStay;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkIsStay: " + ex.ToString());
            }
        }
        public tblStay checkIsStay(int IDStay, string IDApplication, string IDParticipant)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.ID == IDStay && o.IDApplication == IDApplication && o.IDParticipant == IDParticipant));
                    if (tStay.Count() == 1)
                    {
                        tblStay rStay = tStay.First();
                        return rStay;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkIsStay: " + ex.ToString());
            }
        }
        public tblObject getObject(int IDObject)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.ID == IDObject));
                    tblObject rObject = tObject.First();
                    return rObject;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getObject: " + ex.ToString());
            }
        }
        public tblObject getObject2(int ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.ID == ID));
                if (tObject.Count() == 1)
                {
                    tblObject rObject = tObject.First();
                    return rObject;
                }
                else if (tObject.Count() == 0)
                {
                    return null;
                }
                else
                {
                    throw new Exception("tObject.Count()>1 not allowed for ID'" + ID.ToString() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getObject2: " + ex.ToString());
            }
        }
        public tblObject getObject(string ExtID, string IDParticipant, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (ExtID.Trim() == "")
                {
                    throw new Exception("getObject: ExtID='' not allowed!");
                }
                if (IDParticipant.Trim() == "")
                {
                    throw new Exception("getObject: IDParticipant='' not allowed!");
                }

                System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.ExtID == ExtID.Trim() && o.IDParticipant == IDParticipant.Trim()));
                if (tObject.Count() == 1)
                {
                    tblObject rObject = tObject.First();
                    return rObject;
                }
                else if (tObject.Count() == 0)
                {
                    return null;
                }
                else
                {
                    throw new Exception("tObject.Count()>1 not allowed for ID'" + ExtID.Trim() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getObject: " + ex.ToString());
            }
        }
        public tblStay getStay(int ID, string IDParticipant, string IDApplication, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (ID < 0 && IDParticipant.Trim() == "" && IDApplication.Trim() == "")
                {
                    throw new Exception("getStay: ID < 0 && IDParticipant.Trim()='' && IDApplication.Trim()= '' not allowed for ID'" + ID.ToString() + "'!");
                }

                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.ID == ID && o.IDApplication == IDApplication && o.IDParticipant == IDParticipant));
                tblStay rStay = tStay.First();
                return rStay;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getStay: " + ex.ToString());
            }
        }
        public tblStay getStay2(int ID, string IDParticipant, string IDApplication, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (ID < 0 && IDParticipant.Trim() == "" && IDApplication.Trim() == "")
                {
                    throw new Exception("getStay: ID < 0 && IDParticipant.Trim()='' && IDApplication.Trim()= '' not allowed for ID'" + ID.ToString() + "'!");
                }

                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.ID == ID && o.IDApplication == IDApplication && o.IDParticipant == IDParticipant));
                if (tStay.Count() == 1)
                {
                    tblStay rStay = tStay.First();
                    return rStay;
                }
                else if (tStay.Count() == 0)
                {
                    return null;
                }
                else
                {
                    throw new Exception("tStay.Count()>1 not allowed for ID'" + ID.ToString() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getStay2: " + ex.ToString());
            }
        }
        public tblStay getStay(string MedRecNr, string Application, string IDParticipant, int Incidence, PMDS.db.Entities.ERModellPMDSEntities db, ref int iStaysFound)
        {
            try
            {
                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.MedRecN == MedRecNr && o.IDApplication == Application && 
                                                                                o.IDParticipant == IDParticipant && o.Incidence == Incidence));
                if (tStay.Count() == 1)
                {
                    tblStay rStay = tStay.First();
                    iStaysFound = 1;
                    return rStay;
                }
                else if (tStay.Count() > 1)
                {
                    iStaysFound = 2;
                    return null;
                }
                else
                {
                    iStaysFound = 0;
                    return null;
                }
   
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getStay: " + ex.ToString());
            }
        }
        public tblStay getStay(string Application, string IDParticipant,  PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.IDApplication == Application &&
                                                                                o.IDParticipant == IDParticipant)).Take(1);
                if (tStay.Count() > 0)
                {
                    tblStay rStay = tStay.First();
                    return rStay;
                }
                else 
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getStay: " + ex.ToString());
            }
        }
        public bool checkMedRecNApplicationParticipantIncidenceExists(string MedRecN,  string IDApplication, string IDParticipant, int Incidence, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (MedRecN.Trim() == "" || IDApplication.Trim() == "" || IDParticipant.Trim() == "")
                {
                    throw new Exception("checkMedRecNApplicationParticipantIncidenceExists: (MedRecN.Trim()='' || IDApplication.Trim()='' || IDParticipant.Trim()='' not allowed for ID'" + MedRecN.Trim() + "'!");
                }

                System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.MedRecN == MedRecN.Trim() && o.IDApplication.Trim() == IDApplication && o.IDParticipant.Trim() == IDParticipant.Trim() && o.Incidence == Incidence));
                if (tStay.Count() == 1)
                {
                    tblStay rStay = tStay.First();
                    return true;
                }
                else if (tStay.Count() == 0)
                {
                    return false;
                }
                else
                {
                    throw new Exception("tStay.Count()>1 not allowed for MedRecN'" + MedRecN.Trim() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkMedRecNApplicationParticipantIncidenceExists: " + ex.ToString());
            }
        }
        public tblObject getUser(string UserNameDomain, PMDS.db.Entities.ERModellPMDSEntities db, string IDParticipant, ref int iUsersFound)
        {
            try
            {
                System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.UserNameDomain == UserNameDomain && o.IDParticipant == IDParticipant && o.IsUser == true));
                if (tObject.Count() == 1)
                {
                    tblObject rObject = tObject.First();
                    iUsersFound = 1;
                    return rObject;
                }
                else if (tObject.Count() > 1)
                {
                    iUsersFound = 2;
                    return null;
                }
                else
                {
                    iUsersFound = 0;
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getUser: " + ex.ToString());
            }
        }
        public bool checkUserNameParticipant(string UserName, string IDParticipant, Guid IDGuidObject, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.UserName == UserName && o.IDParticipant == IDParticipant && 
                                                                                o.IDGuid != IDGuidObject && o.IsUser == true));
                if (tObject.Count() == 1)
                {
                    return false;
                }
                else if (tObject.Count() > 1)
                {
                    throw new Exception("checkUserNameParticipant: tObject.Count() > 1 for UserName '" + UserName.Trim() + "'!");
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUserNameParticipant: " + ex.ToString());
            }
        }
        public bool checkUserNameDomainParticipant(string UserNameDomain, string IDParticipant, Guid IDGuidObject, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblObject> tObject = db.tblObject.Where(o => (o.UserNameDomain == UserNameDomain && o.IDParticipant == IDParticipant && 
                                                                                o.IDGuid != IDGuidObject && o.IsUser == true));
                if (tObject.Count() == 1)
                {
                    return false;
                }
                else if (tObject.Count() > 1)
                {
                    throw new Exception("checkUserNameDomainParticipant: tObject.Count() > 1 for UserNameDomain '" + UserNameDomain.Trim() + "'!");
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUserNameDomainParticipant: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<tblStay> getAllStaysForuserxy(Guid IDUser, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblStay> tStays = db.tblStay.Where(o => (o.IDGuid == IDUser));
                return tStays;

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getAllStaysForuser: " + ex.ToString());
            }
        }
        public void deletAllStaysForPatient(Guid PatIDGuid)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblStay> tStay = db.tblStay.Where(o => (o.PatIDGuid == PatIDGuid));
                    foreach (tblStay rStay in tStay)
                    {
                        System.Linq.IQueryable<tblStay> tStayChild = db.tblStay.Where(o => (o.IDStayParent == rStay.ID &&
                                                                                        o.IDApplicationParent == rStay.IDApplication &&
                                                                                        o.IDParticipantParent == rStay.IDParticipant));
                        foreach (tblStay rStayChild in tStayChild)
                        {
                            this.deletStayAdditions(rStayChild, PatIDGuid, db);
                            db.tblStay.Remove(rStayChild);
                        }

                        this.deletStayAdditions(rStay, PatIDGuid, db);
                        db.tblStay.Remove(rStay);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.deletAllStaysForPatient: " + ex.ToString());
            }
        }
        public void deletStayAdditions(tblStay rStay,Guid PatIDGuid, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblStayAdditions> tStayAdditions = db.tblStayAdditions.Where(o => (o.IDObject == PatIDGuid));
                foreach (tblStayAdditions rStayAdditions in tStayAdditions)
                {
                    db.tblStayAdditions.Remove(rStayAdditions);
                }
                tStayAdditions = db.tblStayAdditions.Where(o => (o.IDPatient == PatIDGuid));
                foreach (tblStayAdditions rStayAdditions in tStayAdditions)
                {
                    db.tblStayAdditions.Remove(rStayAdditions);
                }

                tStayAdditions = db.tblStayAdditions.Where(o => (o.IDStayParent == rStay.ID && o.IDApplicationStayParent == rStay.IDApplication &&
                                                                o.IDParticipantStayParent == rStay.IDParticipant));
                foreach (tblStayAdditions rStayAdditions in tStayAdditions)
                {
                    db.tblStayAdditions.Remove(rStayAdditions);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.deletStayAdditions: " + ex.ToString());
            }
        }

        public bool checkDBVersion(string ThisExeVersion, ref string DBExeVersion)
        {
            try
            {
                DBExeVersion = "";
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblDBVersion> tDBVersion = db.tblDBVersion.OrderByDescending(x => x.Description);

                    if (tDBVersion.Count() == 0)        // Wenn nichts in der DB eingetragen ist, keine Prüfung, sonst den letzten Eintrag vergleichen
                    {
                        return true;
                    }
                    else
                    {
                        tblDBVersion rDBVersion = tDBVersion.First();
                        DBExeVersion = rDBVersion.Description.Trim();
                    }
                    return CompareVersionStrings(ThisExeVersion, DBExeVersion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkDBVersion: " + ex.ToString());
            }
        }

        public bool checkReferenzVersion(string ThisExeVersion, string PathReferenzExe, ref string ReferenzExeVersion)
        {
            try
            {
                if (PathReferenzExe.Trim().Length == 0)    // Wenn keine Referenz-Exe angegeben ist, keine Prüfung
                    return true;

                if (System.IO.File.Exists(PathReferenzExe))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(PathReferenzExe);
                    ReferenzExeVersion = versionInfo.ProductVersion; 
                }
                else
                {
                    ReferenzExeVersion = "Reference not found";
                    return false;
                }
                return CompareVersionStrings(ThisExeVersion, ReferenzExeVersion);
            }

            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkReferenzVersion: " + ex.ToString());
            }
        }

        public bool CompareVersionStrings(string strA, string strB)
        {
            try
            {
                //Version liegt im Format xxx.xxx.xxx.xxx vor
                string[] vExe = strA.Split(new Char[] { '.' });
                string[] vDB = strB.Split(new Char[] { '.' });

                if (vExe.Length != vDB.Length)
                {
                    return false;
                    //throw new Exception("VersionCheck (format) failed. Please contact your Admin.");
                }

                for (int i = 0; i <= vExe.Length - 1; i++)
                {
                    string a = vExe[i];
                    string b = vDB[i];
                    int ia = 0;
                    int ib = 0;

                    bool aIsNumeric = Int32.TryParse(a, out ia);
                    bool bIsNumeric = Int32.TryParse(b, out ib);

                    if (aIsNumeric && bIsNumeric)
                    {
                        if (ia > ib)            //Wenn ein Nummernblock größer ist als der andere -> Prüfung positiv abbrechen
                            return true;

                        if (ia < ib)
                            return false;       
                    }
                    else
                    {
                        return false;
                        //throw new Exception("VersionCheck (numeric) failed. Please contact your Admin.");
                    }
                }
                return true;        //Alle Nummernblöcke sind gleich

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.CompareVersionStrings: " + ex.ToString());
            }
        }


        public bool CheckIfSelListIDResExists(string IDRes)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => (o.IDRessource == IDRes));
                    if (tSelListEntries.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.CheckIfSelListIDResExists: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<tblSelListEntriesObj> getSelListObjDoubledSelListsxy(int IDSelListEntry, int IDSelListEntrySublist, string typIDGroup,
                                                                                        PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblSelListEntriesObj> tSelListEntriesObj = db.tblSelListEntriesObj.Where(o => (o.IDSelListEntry == IDSelListEntry && o.IDSelListEntrySublist == IDSelListEntrySublist &&
                                                                                                o.typIDGroup == typIDGroup && o.FldShort == null && o.IDApplication == null && 
                                                                                                o.IDObject == null && 
                                                                                                o.IDStay == null && o.IDApplicationStay == null && o.IDParticipantStay == null &&
                                                                                                (o.IDParticipant == "" || o.IDParticipant == "All")));
                return tSelListEntriesObj;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getSelListObjDoubledSelLists: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<tblSelListEntriesObj> getSelListObjDoubledFldShortsxy(int IDSelListEntry, string FldShort, string IDApplication,  string typIDGroup,
                                                                                            PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblSelListEntriesObj> tSelListEntriesObj = db.tblSelListEntriesObj.Where(o => (o.IDSelListEntry == IDSelListEntry && o.IDSelListEntrySublist == null &&
                                                                                                o.typIDGroup == typIDGroup && o.FldShort == FldShort && o.IDApplication == IDApplication &&
                                                                                                o.IDObject == null &&
                                                                                                o.IDStay == null && o.IDApplicationStay == null && o.IDParticipantStay == null &&
                                                                                                (o.IDParticipant == "" || o.IDParticipant == "All")));
                return tSelListEntriesObj;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getSelListObjDoubledFldShorts: " + ex.ToString());
            }
        }
        
        public bool checkLicenseKey(System.Collections.Generic.List<string> lstLicenseKeys, string FldShort, string Application)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkLicenseKey - FldShort:" + FldShort.Trim() + ", Application:" + Application.Trim() + "\r\n" + ex.ToString());
            }
        }

        public static string getDbEntityValidationException(System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var failure in ex.EntityValidationErrors)
            {
                sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors)
                {
                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    sb.AppendLine();
                }
            }
            return "Entity Validation Failed - errors follow:\n" + sb.ToString();
        }

        public static PMDS.db.Entities.ERModellPMDSEntities getDBContext()
        {
            try
            {               
                PMDS.db.Entities.ERModellPMDSEntities DBContext = new PMDS.db.Entities.ERModellPMDSEntities();
                businessFramework.setERConnectionSqlDb(ref DBContext);
                return DBContext;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getDBContext: " + ex.ToString());
            }
        }

        public static void setERConnectionOleDb(ref PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                System.Data.Common.DbConnectionStringBuilder OLEDBBuilder = new System.Data.Common.DbConnectionStringBuilder();
                OLEDBBuilder["Data Source"] = dbBase.Server;
                OLEDBBuilder["Initial Catalog"] = dbBase.Database;
                OLEDBBuilder["Provider"] = dbBase.Provider;
                OLEDBBuilder["Persist Security Info"] = true;
                OLEDBBuilder["MARS Connection"] = true;
                if (dbBase.User != null)
                {
                    if (dbBase.User.Trim() != "")
                    {
                        OLEDBBuilder["User ID"] = dbBase.User;
                        OLEDBBuilder["Password"] = dbBase.PwdDecrypted;
                    }
                }
                else
                {
                    OLEDBBuilder["Integrated Security"] = "SSPI";
                }

                DBContext.Database.Connection.ConnectionString = OLEDBBuilder.ConnectionString;
                DBContext.Database.Connection.Open();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.setConnection: " + ex.ToString());
            }
        }

        public static void setERConnectionSqlDb(ref PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                SqlConnectionStringBuilder sqlDBBuilder = new SqlConnectionStringBuilder();
                System.Data.Common.DbConnectionStringBuilder SqlDBBuilder = new System.Data.Common.DbConnectionStringBuilder();
                sqlDBBuilder.DataSource = dbBase.Server;
                sqlDBBuilder.InitialCatalog = dbBase.Database;
                sqlDBBuilder.PersistSecurityInfo = true;
                sqlDBBuilder.MultipleActiveResultSets = true;
                if (!String.IsNullOrWhiteSpace(dbBase.User) && !String.IsNullOrWhiteSpace(dbBase.PwdDecrypted))
                {
                        sqlDBBuilder.UserID = dbBase.User;
                        sqlDBBuilder.Password = dbBase.PwdDecrypted;
                }
                else
                {
                    sqlDBBuilder.IntegratedSecurity = true;
                }

                DBContext.Database.Connection.ConnectionString = sqlDBBuilder.ConnectionString;
                DBContext.Database.Connection.Open();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.setConnection: " + ex.ToString());
            }
        }

        public static void InsertERConnections()
        {
            try
            {
                if (qs2.core.ENV.WriteERConnectionString)
                {
                    Boolean MustSaveQS2 = false;
                    MustSaveQS2 = WriteERConnectionSqlDb("ERModellPMDSEntities");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Main.InsertERConnection: " + ex.ToString());
            }
        }

        private static bool WriteERConnectionSqlDb(string ConnectionName)
        {
            try
            {
                string providerName = "System.Data.SqlClient";
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connection = config.ConnectionStrings.ConnectionStrings[ConnectionName];

                //Wenn es die Connection schon gibt, prüfen, ob die richtige DB und der richtige Server eingetragen sind
                if (connection != null && connection.ConnectionString.sContains(dbBase.Database) &&
                    connection.ConnectionString.sContains(dbBase.Server))
                {
                    return true;
                }
                else
                {
                    SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                    sqlBuilder.DataSource = dbBase.Server;
                    sqlBuilder.InitialCatalog = dbBase.Database;
                    sqlBuilder.ApplicationName = "EntityFramework";
                    sqlBuilder.MultipleActiveResultSets = true;
                    if (dbBase.User != null)
                    {
                        if (dbBase.User.Trim() != "")
                        {
                            sqlBuilder.UserID = dbBase.User;
                            sqlBuilder.Password = dbBase.PwdDecrypted;
                        }
                    }
                    else
                    {
                        sqlBuilder.IntegratedSecurity = true;
                    }

                    ConnectionStringsSection csSection = config.ConnectionStrings;
                    ConnectionStringSettingsCollection csCollection = csSection.ConnectionStrings;
                    ConnectionStringSettings cs = csCollection[ConnectionName];
                    if (cs != null)
                    {
                        csCollection.RemoveAt(csCollection.IndexOf(cs));
                        ConfigurationManager.RefreshSection("connectionStrings");
                    }

                    Configuration configNew = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    csSection.ConnectionStrings.Add(
                        new ConnectionStringSettings(ConnectionName,
                            sqlBuilder.ConnectionString,
                            providerName));

                    configNew.Save(ConfigurationSaveMode.Modified, false);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFranmework.WriteERConnectionSqlDb: " + ex.ToString());

            }
        }
    }
}
