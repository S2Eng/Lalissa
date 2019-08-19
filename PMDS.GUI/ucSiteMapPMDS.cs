using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace PMDS.GUI
{
    

    public class ucSiteMapPMDS
    {

        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();


        





        public static void MainCallDel(PMDS.Global.ENV.eFctCallMainFctPlan TypeFctToCall, PMDS.Global.ENV.eCallMainFctPlan cCallMainFctPlan)
        {
            Guid IDCurrentPatientSave = PMDS.Global.ENV.CurrentIDPatient;
            try
            {
                if (TypeFctToCall == Global.ENV.eFctCallMainFctPlan.Dekurs)
                {
                    string DekursText = "";         //QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zu ");
                    Guid IDPatientFirst = cCallMainFctPlan.lstDekursInfo[0].ID;
                    
                    PMDS.Global.ENV.setCurrentIDPatient = IDPatientFirst;
                    GuiAction.PatientVermerk(IDPatientFirst, System.Guid.Empty, Global.eDekursherkunft.DekursAusTermin, DekursText, false, false, null, true, "Fct. ucSiteMapPMDS.DekursErstellen()", false, "", cCallMainFctPlan.lstDekursInfo);
                    PMDS.Global.ENV.setCurrentIDPatient = IDCurrentPatientSave;
                }
                else if (TypeFctToCall == Global.ENV.eFctCallMainFctPlan.DekursErstellen)
                {
                    string DekursText = "";         //QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zu ");
                    Guid IDPatientFirst = cCallMainFctPlan.lstDekursInfo[0].ID;

                    PMDS.Global.ENV.setCurrentIDPatient = IDPatientFirst;
                    GuiAction.PatientVermerk(IDPatientFirst, System.Guid.Empty, Global.eDekursherkunft.DekursAusTermin, DekursText, false, true, null, true, "Fct. ucSiteMapPMDS.DekursErstellen()", false, "", cCallMainFctPlan.lstDekursInfo);
                    PMDS.Global.ENV.setCurrentIDPatient = IDCurrentPatientSave;
                }
                else if (TypeFctToCall == Global.ENV.eFctCallMainFctPlan.DekursErstellenAls)
                {
                    string DekursText = "";         //QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zu ");
                    Guid IDPatientFirst = cCallMainFctPlan.lstDekursInfo[0].ID;

                    PMDS.Global.ENV.setCurrentIDPatient = IDPatientFirst;
                    GuiAction.PatientVermerk(IDPatientFirst, System.Guid.Empty, Global.eDekursherkunft.DekursAusTermin, DekursText, false, true, null, true, "Fct. ucSiteMapPMDS.DekursErstellen()", true, "", cCallMainFctPlan.lstDekursInfo);
                    PMDS.Global.ENV.setCurrentIDPatient = IDCurrentPatientSave;
                }
                else if (TypeFctToCall == Global.ENV.eFctCallMainFctPlan.PrintTermine)
                {
                    PMDS.Print.ReportManager.PrintTermine(cCallMainFctPlan.ds, cCallMainFctPlan.ViewMode, cCallMainFctPlan.Title, cCallMainFctPlan.IDKlinik, cCallMainFctPlan.IDAbteilung,
                                                            cCallMainFctPlan.IDBereich, cCallMainFctPlan.dFrom, cCallMainFctPlan.dTo, cCallMainFctPlan.UserLoggedOn, cCallMainFctPlan.lstKlients,
                                                            cCallMainFctPlan.lstUsers, cCallMainFctPlan.lstCategories, cCallMainFctPlan.Quickbutton.Trim());
                    
                }
                else
                {
                    PMDS.Global.ENV.setCurrentIDPatient = IDCurrentPatientSave;
                    throw new Exception("MainCallDel: TypeFctToCall '" + TypeFctToCall.ToString() + "' not allowed!");
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapPMDS.MainCallDel: " + ex.ToString());
            }
        }
        
        public bool checkAnonymLogIn(ref bool PwdNotSucessfullChanged)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                if (rUsr.IsGeneric)
                {
                    PMDS.GUI.GUI.Main.frmLogInAnonym frm = new GUI.Main.frmLogInAnonym();
                    frm.initControl();
                    PMDS.Global.UIGlobal.infoStart.Close();
                    frm.ShowDialog();
                    if (!frm.ucLogInAnonym1.abort)
                    {
                        PMDS.Global.ENV.IDAnmeldungen = frm.ucLogInAnonym1.IDAnmeldungenReturn;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (PMDS.Global.ENV.MaxPasswordAge > 0)
                    {
                        if (!PMDS.Global.ENV.adminSecure && !PMDS.Global.ENV.LoggedInAsSuperUser)
                        {
                            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                            DateTime dLastAnmeldung = b.getAnmeldungen(rUsr.Benutzer1.Trim());
                            DateTime Ablauf = dLastAnmeldung.Date.AddDays(PMDS.Global.ENV.MaxPasswordAge);
                            if (Ablauf < DateTime.Now.Date)
                            {
                                if (!GuiAction.ChangePassword())
                                {
                                    PwdNotSucessfullChanged = true;
                                    return false;
                                }
                            }             
                            else
                            {
                                if (Ablauf < DateTime.Now.Date.AddDays(7))
                                {
                                    System.Windows.Forms.DialogResult result = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Ihr Passwort läuft am ") + Ablauf.ToString("dd. MMMM yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ab.\n\rWollen Sie Ihr Passwort jetzt ändern?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), System.Windows.Forms.MessageBoxButtons.YesNo, true);
                                    if (result == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        GuiAction.ChangePassword();
                                    }
                                }
                            }
                        }
                    }

                    if (this.PMDSBusiness1.saveAnonymUser(ref PMDS.Global.ENV.IDAnmeldungen, "", ref rUsr))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("ucSiteMapPMDS.checkAnonymLogIn: Error this.PMDSBusiness1.saveAnonymUser!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapPMDS.checkAnonymLogIn: " + ex.ToString());
            }
        }

        public void getAllÄrzte(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, bool nurZugeordneteAerzte, Nullable<Guid> IDPatient)
        {
            try
            {
                cbo.Items.Clear();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PatientAerzte> tPatientAerzte = null;
                    tPatientAerzte = db.PatientAerzte.Where(o => o.IDPatient == (Guid)IDPatient); 

                    System.Linq.IQueryable<PMDS.db.Entities.Aerzte> tAerzte = null;
                    PMDSBusiness1.getAllÄrzte(db, ref tAerzte);
                    foreach (PMDS.db.Entities.Aerzte rArzt in tAerzte)
                    {
                        bool AddItm = !nurZugeordneteAerzte;
                        if (nurZugeordneteAerzte)
                        {
                            foreach (PMDS.db.Entities.PatientAerzte rPatientAerzte in tPatientAerzte)
                            {
                                if (rArzt.ID == rPatientAerzte.IDAerzte)
                                {
                                    AddItm = true;
                                }
                            }
                        }
                        if (AddItm)
                        {
                            string sFachrichtungTmp = rArzt.Fachrichtung.Trim() == "" ? "" : " (" + rArzt.Fachrichtung.Trim() + ")";
                            cbo.Items.Add(rArzt.ID, rArzt.Nachname + " " + rArzt.Vorname + sFachrichtungTmp);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapPMDS.getAllÄrzte: " + ex.ToString());
            }

        }
    }

}
