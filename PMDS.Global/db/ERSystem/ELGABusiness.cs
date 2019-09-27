using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDS.Global.db.ERSystem
{

    public class ELGABusiness
    {

        public class ProtVar
        {
            public string Fld { get; set; }
            public string Table { get; set; }
            public object oValOrig { get; set; }
            public object oValNew { get; set; }
        }

        public enum eTypeProt
        {
            UserSettingsChanged = 0,
            NewPassword = 0,
            none = -100,
        }

        public enum eELGAFunctions
        {

            none = -100,
        }

        [Serializable()]
        public class BenutzerDTOS1
        {
            public Guid Id { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public string Benutzer1 { get; set; }
            public bool? AktivJn { get; set; }
            public bool? PflegerJn { get; set; }
            public Guid? Idberufsstand { get; set; }
            public bool IsGeneric { get; set; }
            //public string Signatur { get; set; }
            public string Elgauser { get; set; }
            public string ELGAPwd { get; set; }
            public string ElgapatId { get; set; }
            public bool Elgaactive { get; set; }
            public bool ElgaautoLogin { get; set; }
            public bool ElgaautostartSession { get; set; }
            public DateTime? ElgavalidTrough { get; set; }
            public string ELGA_AuthorSpeciality { get; set; }
        }






        public static void saveELGAProtocoll(string Title, System.Collections.Generic.List<ProtVar> flds, eTypeProt TypeProt, eELGAFunctions ELGAFunctions, string table = "", string ELGAErrors = "")
        {
            try
            {
                string sProt = "";
                if (flds != null)
                {
                    foreach (var r in flds)
                    {
                        if (!r.oValNew.Equals(r.oValNew))
                        {
                            sProt += (table.Trim() == "" ? r.Table.Trim() : table) + "." + r.Fld.Trim() + " changed from " + r.oValOrig.ToString() + " to " + r.oValNew.ToString() + "" + "\r\n";
                        }
                    }
                }

                PMDSBusiness b = new PMDSBusiness();
                dsKlientenliste ds = new dsKlientenliste();
                sqlManange sqlManage1 = new sqlManange();
                sqlManage1.initControl();
                
                dsKlientenliste.ELGAProtocollRow rNewProt = sqlManage1.getNewELGAProtocoll(ref ds);
                rNewProt.Title = Title.Trim();
                rNewProt.Protocoll = sProt;
                rNewProt.CreatedUser = b.LogggedOnUser().Benutzer1.Trim();
                rNewProt.Type = TypeProt.ToString();
                rNewProt.ELGAFunctions = ELGAFunctions.ToString();
                rNewProt.ELGAErrors = ELGAErrors.Trim();

                sqlManage1.daELGAProtocoll.Update(ds.ELGAProtocoll);

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.saveProtocoll: " + ex.ToString());
            }
        }

        public BenutzerDTOS1 getELGASettingsForUser(Guid IDUsr)
        {
            try
            {
                BenutzerDTOS1 bDto = new BenutzerDTOS1();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    List<BenutzerDTOS1> tUsr = (from b in db.Benutzer
                                                   where b.ID == IDUsr
                                                   select new BenutzerDTOS1
                                                   {
                                                       Id = b.ID,
                                                       Vorname = b.Vorname,
                                                       Nachname = b.Nachname,
                                                       Benutzer1 = b.Benutzer1,
                                                       AktivJn = b.AktivJN,
                                                       PflegerJn = b.PflegerJN,
                                                       Idberufsstand = b.IDBerufsstand,
                                                       IsGeneric = b.IsGeneric,
                                                       Elgauser = b.ELGAUser,
                                                       ELGAPwd = b.ELGAPwd,
                                                       ElgapatId = b.ELGAPatID,
                                                       Elgaactive = b.ELGAActive,
                                                       ElgaautoLogin = b.ELGAAutoLogin,
                                                       ElgaautostartSession = b.ELGAAutostartSession,
                                                       ElgavalidTrough = b.ELGAValidTrough,
                                                       ELGA_AuthorSpeciality = b.ELGA_AuthorSpeciality
                                                   }).ToList();

                    return tUsr.First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.getELGASettingsForUser: " + ex.ToString());
            }
        }

    }

}

