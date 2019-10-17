using Infragistics.Win.UltraWinStatusBar;
using PMDS.DB;
using PMDS.GUI.ELGA;
using PMDSClient.Sitemap;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            public bool changedNoValue { get; set; }
        }

        public enum eTypeProt
        {
            UserSettingsChanged = 0,
            NewPassword = 1,
            UserRightsChanged = 2,
            QueryPatients = 3,
            Kontaktbestätigung = 4,
            KontaktbestätigungStorno = 5,
            SOO = 6,
            ELGAQueryGDAs = 7,
            ELGAQueryDocuments = 8,
            ELGARetrieveDocument = 9,
            ELGAAddDocument = 10,
            ELGAUpdateDocument = 11,
            genCDA = 12,
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

        public static string LoggedInBenutzer = "";

        public static bool? ELGALogInInitializedAtStart { get; set; }
        public static ELGABusiness.BenutzerDTOS1 ElgaDtoUsr { get; set; }

        public static cELGAStatusbarStatus ELGAStatusbarStatus { get; set; }
        public class cELGAStatusbarStatus
        {
            public bool Active { get; set; }
            public Nullable<DateTime> ELGASessionStarted { get; set; }
            public Nullable<DateTime> ELGASessionEnd { get; set; }
            public eTypeStatusELGA TypeStatusELGA { get; set; }
            public int iVerlängerungen { get; set; }
            public bool VerlängerungStatusRed { get; set; }
            public bool SessionStopped { get; set; }

            public WCFServiceClient.ELGALogInDto ELGALogInDto { get; set; }
        }
        public enum eTypeStatusELGA
        {
            red = 1,
            yellow = -1,
            green = 0,
            off = -100
        }

        public static WCFServiceClient WCFServiceClient1 { get; set; }
        public qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
        public static bool MsgBoxVerlängerungActive = false;
        public PMDSBusiness b = new PMDSBusiness();

        public static Dictionary<Guid, frmELGAMsgBox> lElgaMsgBoxOpend = new Dictionary<Guid, frmELGAMsgBox>();

        public enum eELGARight
        {
            ELGAAktionen = 105,
            ELGADokumenteErstellen = 106,
            ELGADokumenteSenden = 108,
            ELGADokumenteVidieren = 107,
            ELGAMedikamente = 102,
            ELGAPatientenSuchen = 101,
            ELGAPflegerischerEntlassungsbrief = 103,
            ELGAPflegezustandsbericht = 104
        }










        public void init()
        {
            if (ElgaDtoUsr == null)
            {
                ElgaDtoUsr = this.getELGASettingsForUser(ENV.USERID);
                LoggedInBenutzer = b.getUserName(ENV.USERID);
            }
            if (ELGAStatusbarStatus == null)
            {
                ELGAStatusbarStatus = new cELGAStatusbarStatus();
            }
            if (WCFServiceClient1 == null)
            {
                WCFServiceClient1 = new WCFServiceClient();
            }
        }


        public static void saveELGAProtocoll(string Title, System.Collections.Generic.List<ProtVar> flds, eTypeProt TypeProt, eELGAFunctions ELGAFunctions,
                                                string table = "", string ELGAErrors = "", Nullable<Guid> IDBenutzer = null, Nullable<Guid> IDPatient = null, Nullable<Guid> IDAufenthalt = null,
                                                string sProtAltern = "")
        {
            try
            {
                bool AnyChange = false;
                string sProt = "";
                if (flds != null)
                {
                    foreach (var r in flds)
                    {
                        if (!r.changedNoValue && !r.oValNew.Equals(r.oValOrig))
                        {
                            sProt += (table.Trim() == "" ? r.Table.Trim() : table) + "." + r.Fld.Trim() + " wurde von " + r.oValOrig.ToString() + " auf " + r.oValNew.ToString() + " geändert" + "\r\n";
                            AnyChange = true;
                        }
                        else if (r.changedNoValue)
                        {
                            sProt += (table.Trim() == "" ? r.Table.Trim() : table) + "." + r.Fld.Trim() + " changed" + "\r\n";
                            AnyChange = true;
                        }
                    }
                }
                if (sProtAltern.Trim() != "")
                {
                    sProt = sProtAltern.Trim();
                    AnyChange = true;
                }

                if (AnyChange)
                {
                    PMDSBusiness b = new PMDSBusiness();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.ELGAProtocoll rNewELGAProtocoll = PMDS.Global.db.ERSystem.EFEntities.newELGAProtocoll(db);
                        rNewELGAProtocoll.ID = System.Guid.NewGuid();
                        rNewELGAProtocoll.Type = TypeProt.ToString();
                        rNewELGAProtocoll.Title = Title.Trim();
                        rNewELGAProtocoll.Protocoll = sProt;
                        rNewELGAProtocoll.ELGAFunctions = ELGAFunctions.ToString();
                        rNewELGAProtocoll.Characteristics = "";
                        rNewELGAProtocoll.CreatedAt = DateTime.Now;
                        rNewELGAProtocoll.CreatedUser = b.getUserName(ENV.USERID);
                        rNewELGAProtocoll.ELGAErrors = ELGAErrors.Trim();

                        if (IDBenutzer != null)
                            rNewELGAProtocoll.IDBenutzer = IDBenutzer;
                        else
                            rNewELGAProtocoll.IDBenutzer = null;

                        if (IDPatient != null)
                            rNewELGAProtocoll.IDPatient = IDPatient;
                        else
                            rNewELGAProtocoll.IDPatient = null;

                        if (IDAufenthalt != null)
                            rNewELGAProtocoll.IDAufenthalt = IDAufenthalt;
                        else
                            rNewELGAProtocoll.IDAufenthalt = null;

                        db.ELGAProtocoll.Add(rNewELGAProtocoll);
                        db.SaveChanges();
                    }
                }

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

                    string ELGAPwdDecrypted = Encryption1.StringDecrypt(tUsr.First().ELGAPwd.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                    tUsr.First().ELGAPwd = ELGAPwdDecrypted.Trim();
                    return tUsr.First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.getELGASettingsForUser: " + ex.ToString());
            }
        }



        public void handleLogIn(UltraStatusBar statBar, bool UsrClicked, bool IsTimer)
        {
            try
            {
                if (ELGAStatusbarStatus != null && ELGAStatusbarStatus.SessionStopped != null && ELGAStatusbarStatus.SessionStopped)
                {
                    return;
                }
                this.init();
                UltraStatusPanel panelELGA = statBar.Panels["statELGA"];
                //statBar.Panels["statELGA"].Visible = true;

                if (IsTimer)
                {
                    if (ELGAStatusbarStatus.Active)
                    {
                        this.updateTxtStatusbarLogIn(statBar, panelELGA);
                    }
                    else
                    {
                        //this.ELGAOnStatusbarOff(statBar, panelELGA);
                    }
                }
                else if (UsrClicked)
                {
                    if (!ELGAStatusbarStatus.VerlängerungStatusRed)
                    {
                        if (!ELGAStatusbarStatus.Active)
                        {
                            if (ElgaDtoUsr.ElgaautoLogin)
                            {
                                this.LogInELGA(statBar, panelELGA);
                            }
                            else if (!ElgaDtoUsr.ElgaautoLogin)
                            {
                                PMDS.GUI.ELGA.frmELGALogIn frmELGALogIn1 = new GUI.ELGA.frmELGALogIn();
                                frmELGALogIn1.initControl();
                                frmELGALogIn1.ShowDialog();
                                if (!frmELGALogIn1.contELGALogIn1.abort)
                                {
                                    this.LogInELGA(statBar, panelELGA);
                                }
                                else
                                {
                                    //this.LogOutELGA(statBar, panelELGA);
                                    bool LogInNotOK = true;
                                }
                            }
                        }
                        else
                        {
                            if (ELGAStatusbarStatus.TypeStatusELGA == eTypeStatusELGA.green)
                            {
                                if (this.ElgaMessageBox("Derzeit ist eine ELGA-Sitzung aktiv." + "\r\n" + "Wollen Sie sich von der ELGA-Sitzung wirklich abmelden?"))
                                {
                                    this.LogOutELGA(statBar, panelELGA, true, false, false);
                                }
                            }
                            else if (ELGAStatusbarStatus.TypeStatusELGA == eTypeStatusELGA.yellow)
                            {
                                string sMsgBoxTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die ELGA-Sitzung verlängern?");
                                if (this.ElgaMessageBox(sMsgBoxTxt))
                                {
                                    this.LogInELGA(statBar, panelELGA);
                                    ELGAStatusbarStatus.iVerlängerungen += 1;
                                }
                                else
                                {
                                    if (this.ElgaMessageBox("Derzeit ist eine ELGA-Sitzung aktiv." + "\r\n" + "Wollen Sie sich von der ELGA-Sitzung wirklich abmelden?"))
                                    {
                                        this.LogOutELGA(statBar, panelELGA, true, false);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ENV.lic_ELGA && ElgaDtoUsr.Elgaactive)
                    {
                        statBar.Panels["statELGA"].Visible = true;
                        if (ElgaDtoUsr.ElgaautoLogin)
                        {
                            this.LogInELGA(statBar, panelELGA);
                        }
                        else
                        {
                            this.LogOutELGA(statBar, panelELGA, true, true, false);
                        }

                        //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //{
                        //}
                    }
                    else
                    {
                        this.ELGAOnStatusbarOff(statBar, panelELGA);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.handleLogIn: " + ex.ToString());
            }
        }
        public void LogInELGA(UltraStatusBar statBar, UltraStatusPanel panelELGA)
        {
            try
            {
                string sTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Sitzung aktiv");
                sTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("(noch " + ENV.ELGAStatusGreen.ToString() + " min aktiv)");
                statBar.Panels["statELGA"].Text = sTxt;

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var rKlinik = (from k in db.Klinik
                               where k.ID == ENV.IDKlinik
                               select new
                               {
                                    k.ID,
                                    k.Bezeichnung,
                                    k.ELGA_OID,
                                    k.ELGA_OrganizationName
                               }).First();

                    panelELGA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_green, 32, 32);
                    ELGAStatusbarStatus.ELGALogInDto = WCFServiceClient1.ELGALogInHCP(ENV.USERID, rKlinik.ELGA_OID, rKlinik.ID, rKlinik.ELGA_OrganizationName, "Pflegeeinrichtung");
                    if (!ELGAStatusbarStatus.ELGALogInDto.LogInOK)
                    {
                        throw new Exception("ELGABusiness.handleLogIn: WCFServiceClient1.logInELGA failed!");
                    }

                    ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.green;
                    ELGAStatusbarStatus.ELGASessionStarted = DateTime.Now;
                    ELGAStatusbarStatus.ELGASessionEnd = ELGAStatusbarStatus.ELGASessionStarted.Value.AddMinutes(ENV.ELGAStatusGreen);
                    ELGAStatusbarStatus.Active = true;

                    string sProt = "Benutzer " + LoggedInBenutzer.Trim() + " hat sich in ELGA angemeldet";
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer hat sich angemeldet"), null,
                                                    ELGABusiness.eTypeProt.NewPassword, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, null, null, sProt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.LogInELGA: " + ex.ToString());
            }
        }
        public void LogOutELGA(UltraStatusBar statBar, UltraStatusPanel panelELGA, bool CloseAllElgaMsgBoxes, bool LogOutAuto, bool setSessionStopped = true)
        {
            try
            {
                //if (setSessionStopped)
                //ELGAStatusbarStatus.SessionStopped = true;

                if (CloseAllElgaMsgBoxes)
                {
                    this.closeOpendElgaMsgBoxes();
                }

                ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.off;
                ELGAStatusbarStatus.ELGASessionStarted = null;
                ELGAStatusbarStatus.ELGASessionEnd = null;
                ELGAStatusbarStatus.Active = false;
                ELGAStatusbarStatus.ELGALogInDto = null;

                statBar.Panels["statELGA"].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine ELGA-Sitzung aktiv");
                panelELGA.Appearance.Image = null;

                WCFServiceClient WCFServiceClient1 = new WCFServiceClient();
                WCFServiceClient1.ELGALogOut(ENV.USERID, ENV.lic_ELGA);

                if (LogOutAuto)
                {
                    string sProt = "Benutzer " + LoggedInBenutzer.Trim() + " wurde automatisch von ELGA abgemeldet";
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer hat sich abgemeldet"), null,
                                                    ELGABusiness.eTypeProt.NewPassword, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, null, null, sProt);
                }
                else
                {
                    string sProt = "Benutzer " + LoggedInBenutzer.Trim() + " hat sich aus ELGA abgemeldet";
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer hat sich abgemeldet"), null,
                                                    ELGABusiness.eTypeProt.NewPassword, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, null, null, sProt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.LogOutELGA: " + ex.ToString());
            }
        }

        public void updateTxtStatusbarLogIn(UltraStatusBar statBar, UltraStatusPanel panelELGA)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                //ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.green;
                TimeSpan span = ELGAStatusbarStatus.ELGASessionEnd.Value.Subtract(dNow);

                if (ELGAStatusbarStatus.iVerlängerungen == 0)
                {
                    if (span.TotalMinutes <= ENV.ELGAStatusYellow && span.TotalMinutes > ENV.ELGAStatusRed)
                    {
                        this.setTxtStatusbarTime(statBar, panelELGA, span);
                        ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.yellow;
                        panelELGA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_yellow, 32, 32);
                    }
                    else if (span.TotalMinutes <= ENV.ELGAStatusRed && dNow <= ELGAStatusbarStatus.ELGASessionEnd.Value)
                    {
                        this.setTxtStatusbarTime(statBar, panelELGA, span);
                        ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.red;
                        panelELGA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_red, 32, 32);

                        if (!MsgBoxVerlängerungActive)
                        {
                            MsgBoxVerlängerungActive = true;
                            string sMsgBoxTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die ELGA-Sitzung läuft in {0} Minuten ab." + "\r\n" +
                                                                                                        "Soll die ELGA-Sitzung automatisch verlängert werden?");
                            sMsgBoxTxt = string.Format(sMsgBoxTxt, System.Convert.ToInt32(span.TotalMinutes).ToString());
                            if (this.ElgaMessageBox(sMsgBoxTxt))
                            {
                                this.LogInELGA(statBar, panelELGA);
                                this.setTxtStatusbarTime(statBar, panelELGA, span);
                                ELGAStatusbarStatus.iVerlängerungen += 1;
                            }
                            else
                            {
                                this.LogOutELGA(statBar, panelELGA, true, false);
                            }
                            MsgBoxVerlängerungActive = false;
                        }
                    }
                    else if (dNow > ELGAStatusbarStatus.ELGASessionEnd.Value)
                    {
                        this.LogOutELGA(statBar, panelELGA, true, true, false);
                    }
                    else
                    {
                        this.setTxtStatusbarTime(statBar, panelELGA, span);
                    }
                }
                else if (ELGAStatusbarStatus.iVerlängerungen == 1)
                {
                    if (!ELGAStatusbarStatus.VerlängerungStatusRed)
                    {
                        if (span.TotalMinutes <= ENV.ELGAStatusRed || dNow >= ELGAStatusbarStatus.ELGASessionEnd.Value)
                        {
                            this.setTxtStatusbarTime(statBar, panelELGA, span, QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Sitzung - keine Verlängerung mehr möglich"));
                            ELGAStatusbarStatus.VerlängerungStatusRed = true;
                            ELGAStatusbarStatus.TypeStatusELGA = eTypeStatusELGA.red;
                            panelELGA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_red, 32, 32);
                        }
                        else
                        {
                            this.setTxtStatusbarTime(statBar, panelELGA, span);
                        }
                    }
                    else
                    {
                        this.setTxtStatusbarTime(statBar, panelELGA, span);
                        if (dNow >= ELGAStatusbarStatus.ELGASessionEnd.Value)
                        {
                            this.LogOutELGA(statBar, panelELGA, true, true);
                        }
                    }
                }
                else
                {
                    throw new Exception("ELGABusiness.updateTxtStatusbarLogIn: ELGAStatusbarStatus.iVerlängerungen>1 not allowed!");
                }

            }
            catch (Exception ex)
            {
                MsgBoxVerlängerungActive = false;
                throw new Exception("ELGABusiness.updateTxtStatusbarLogIn: " + ex.ToString());
            }
        }
        public void setTxtStatusbarTime(UltraStatusBar statBar, UltraStatusPanel panelELGA, TimeSpan span, string txtAlternat = "")
        {
            try
            {
                string sDiff = "";
                if (ENV.adminSecure)
                {
                    sDiff = System.Convert.ToInt32(span.Minutes).ToString() + " min (" +System.Convert.ToInt32(span.TotalSeconds).ToString() + " sec)";
                }
                else
                {
                    sDiff = System.Convert.ToInt32(span.Minutes).ToString();
                }

                string sTxt = "";
                if (txtAlternat.Trim() != "")
                {
                    sTxt = txtAlternat;
                }
                else
                {
                    sTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Sitzung aktiv");
                    sTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("(noch {0} aktiv)");
                    sTxt = string.Format(sTxt, sDiff);
                }

                statBar.Panels["statELGA"].Text = sTxt;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.setTxtStatusbarTime: " + ex.ToString());
            }
        }
        public void ELGAOnStatusbarOff(UltraStatusBar statBar, UltraStatusPanel panelELGA)
        {
            try
            {
                ELGAStatusbarStatus.ELGASessionStarted = null;
                ELGAStatusbarStatus.Active = false;

                statBar.Panels["statELGA"].Visible = false;
                statBar.Panels["statELGA"].Text = "";
                panelELGA.Appearance.Image = null;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.ELGAOnStatusbarOff: " + ex.ToString());
            }
        }


        public void setStatusbarOnOff(UltraStatusBar statBar, bool bOn)
        {
            try
            {
                UltraStatusPanel panelELGA = statBar.Panels["statELGA"];
                if (bOn)
                {
                    statBar.Panels["statELGA"].Visible = true;
                    statBar.Panels["statELGA"].Text = "";
                    panelELGA.Appearance.Image = null;
                }
                else
                {
                    statBar.Panels["statELGA"].Visible = false;
                    statBar.Panels["statELGA"].Text = "";
                    panelELGA.Appearance.Image = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.setStatusbarOnOff: " + ex.ToString());
            }
        }

        public bool ElgaMessageBox(string Message)
        {
            try
            {
                frmELGAMsgBox frmELGAMsgBox1 = new frmELGAMsgBox();
                frmELGAMsgBox1.initControl(Message);
                lElgaMsgBoxOpend.Add(frmELGAMsgBox1.ID, frmELGAMsgBox1);
                frmELGAMsgBox1.ShowDialog();
                if (!frmELGAMsgBox1.abort)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.ElgaMessageBox: " + ex.ToString());
            }
        }

        public void closeOpendElgaMsgBoxes()
        {
            try
            {
                foreach (var pair in lElgaMsgBoxOpend)
                {
                    pair.Value.Close();
                }

                lElgaMsgBoxOpend = new Dictionary<Guid, frmELGAMsgBox>();
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.closeOpendElgaMsgBoxes: " + ex.ToString());
            }
        }




        public static bool HasELGARight(eELGARight ELGARight, bool WithMsgBox)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    int iRight = System.Convert.ToInt32(ELGARight);
                    var tUsrRights = (from br in db.BenutzerRechte
                                      join r in db.Recht on br.IDRecht equals r.ID
                                      where br.IDBenutzer == ENV.USERID && r.ELGA == true && r.ID == iRight
                                      select new
                                      {
                                          IDBenutzerRecht = br.ID,
                                          Bezeichnung = r.Bezeichnung
                                      });

                    if (tUsrRights.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (WithMsgBox)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Benutzer hat für diese ELGA-Aktivität kein Recht!", "ELGA", MessageBoxButtons.OK);
                        }
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.HasELGARight: " + ex.ToString());
            }
        }
        public static bool checkELGASessionActive(bool WithMsgBox)
        {
            try
            {
                if (ELGABusiness.ELGAStatusbarStatus.ELGALogInDto == null)
                {
                    if (WithMsgBox)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es ist keine ELGA-Sitzung aktiv" + "\r\n" + 
                                                                                "Aktion kann nicht ausgeführt werden.", "ELGA", MessageBoxButtons.OK);
                    }
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.checkELGASessionActive: " + ex.ToString());
            }
        }

    }

}

