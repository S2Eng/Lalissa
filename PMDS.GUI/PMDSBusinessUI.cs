using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;

using PMDS.Global.db.ERSystem;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.DB.Global;
using PMDS.DB;
using PMDS.Calc.UI.Admin;
using PMDS.GUI.ELGA;
using System.Text.RegularExpressions;
using PMDSClient.Sitemap;
using PMDS.DynReportsForms;
using QS2.Desktop.ControlManagment.ServiceReference_01;

namespace PMDS.GUI
{

    public class PMDSBusinessUI
    {

        public PMDSBusiness b = new PMDSBusiness();

        public static event SelListChanged dSelListChanged;
        public delegate void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val);

        public static int SupressLevelHierarchieActiveInUI = 0;







        public void loadSelList(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val, object objCboSelected, ref List<PMDS.db.Entities.AuswahlListe> lstReturn, bool BezeichnungIsKey = false)
        {
            try
            {
                if (cbo != null)
                {
                    cbo.Items.Clear();
                }
                if (val != null)
                {
                    val.ValueListItems.Clear();
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlListe = this.b.GetAuswahlliste(db, Grp.Trim(), -100000, false);
                    foreach (AuswahlListe rAuswahlListe in tAuswahlListe)
                    {
                        if (!BezeichnungIsKey)
                        {
                            if (cbo != null)
                            {
                                Infragistics.Win.ValueListItem itm = cbo.Items.Add(rAuswahlListe.ID, rAuswahlListe.Bezeichnung.Trim());
                            }
                            if (val != null)
                            {
                                Infragistics.Win.ValueListItem itm2 = val.ValueListItems.Add(rAuswahlListe.ID, rAuswahlListe.Bezeichnung.Trim());
                            }
                        }
                        else
                        {
                            if (cbo != null)
                            {
                                Infragistics.Win.ValueListItem itm = cbo.Items.Add(rAuswahlListe.Bezeichnung.Trim(), rAuswahlListe.Bezeichnung.Trim());
                            }
                            if (val != null)
                            {
                                Infragistics.Win.ValueListItem itm2 = val.ValueListItems.Add(rAuswahlListe.Bezeichnung.Trim(), rAuswahlListe.Bezeichnung.Trim());
                            }
                        }

                    }

                    if (lstReturn != null)
                    {
                        lstReturn = tAuswahlListe.ToList();
                    }
                }

                if (cbo != null && objCboSelected != null)
                {
                    cbo.Value = objCboSelected;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.loadSelList: " + ex.ToString());
            }
        }

        public static void doSelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                PMDSBusinessUI.dSelListChanged.Invoke(Grp, cbo, val);

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.SelListChanged: " + ex.ToString());
            }
        }

        public bool OpenFormRezeptEintrag(Guid IDRezepteintrag)
        {
            try
            {
                PMDS.Data.Global.dsRezeptEintrag ds = new dsRezeptEintrag();
                PMDS.DB.DBRezept DBRezept1 = new DB.DBRezept();
                DBRezept1.ReadRezeptEintragbyID(IDRezepteintrag, ref ds);
                dsRezeptEintrag.RezeptEintragRow rRezeptEintrag = (dsRezeptEintrag.RezeptEintragRow)ds.RezeptEintrag[0];

                frmRezeptEintrag frm = new frmRezeptEintrag(rRezeptEintrag, BearbeitungsModus.edit);
                frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung einer Medikation!");

                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    DBRezept1.daRezeptEintrag.Update(ds.RezeptEintrag);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.OpenFormRezeptEintrag: " + ex.ToString());
            }
        }

        public bool OpenFormMedDaten(Guid IDMedDaten)
        {
            try
            {
                Klient.dsMedizinischeDaten ds = new Klient.dsMedizinischeDaten();
                PMDS.Klient.DBMedizinischeDaten DBMedizinischeDaten1 = new PMDS.Klient.DBMedizinischeDaten();
                DBMedizinischeDaten1.getMedDatenByID(IDMedDaten, ds);
                Klient.dsMedizinischeDaten.MedizinischeDatenRow rMedizinischeDaten = (Klient.dsMedizinischeDaten.MedizinischeDatenRow)ds.MedizinischeDaten.Rows[0];

                PMDS.DB.Global.DBMedizinischeDatenLayout DBMedizinischeDatenLayout1 = new DBMedizinischeDatenLayout();
                PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow rMedizinischeDatenLayout = DBMedizinischeDatenLayout1.ReadByType(rMedizinischeDaten.MedizinischerTyp);

                frmMedizinDaten frm = new frmMedizinDaten(State.Update, (MedizinischerTyp)rMedizinischeDaten.MedizinischerTyp, rMedizinischeDatenLayout.Bezeichnung, rMedizinischeDatenLayout);
                frm.AllowEdit(ENV.HasRight(UserRights.RezepteVerwalten));
                frm.MED_DATEN_ROW = rMedizinischeDaten;
                frm.IDMedDaten = rMedizinischeDaten.ID;
                frm.btnOK.ContextMenuStrip = null;
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    //DBMedizinischeDaten1.daMedizinischeDatenByID.Update(ds.MedizinischeDaten);
                    //Guid IDMedDatenOrig = rMedizinischeDaten.ID;
                    //Guid IDPatientOrig = rMedizinischeDaten.IDPatient;

                    PMDSBusiness b = new PMDSBusiness();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        b.CopyMedDatenToERRowAndSave(rMedizinischeDaten.ID, rMedizinischeDaten.MedizinischerTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG, frm.BEENDIGUNGSGRUND,
                                                            frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG, frm.MODELL, frm.HANDLING,
                                                            frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE, frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, ENV.CurrentIDPatient, db, false);
                    }

                    //MedDatenArgs arg = new MedDatenArgs(rMedizinischeDaten.ID, (int)rMedizinischeDaten.MedizinischerTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG,
                    //                            frm.BEENDIGUNGSGRUND, frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG,
                    //                            frm.MODELL, frm.HANDLING, frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE,
                    //                            frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN);

                    //if (UpdateMedizinischeDaten != null)
                    //    UpdateMedizinischeDaten(arg);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.OpenFormMedDaten: " + ex.ToString());
            }
        }

        public void saveAnzeigeGridRezeptEintrag(Guid IDRezepteintrag, PMDS.db.Entities.ERModellPMDSEntities db, 
                                                    ref string lstMedDatenReturn, ref int NumberMedDatenReturn, 
                                                    ref string lstWundenReturn, ref int NumberWundenReturn, bool doOnlyWunde = false)
        {
            try
            {
                bool anyChanged = false;

                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == IDRezepteintrag);
                PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();
                rRezeptEintrag.lstMedDaten = "";
                rRezeptEintrag.lstWunden = "";

                int NumberWundeTmp = 0;
                int NumberMedDatenTmp = 0;
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == IDRezepteintrag && o.IDVerordnung == null);
                if (tRezeptEintragMedDaten.Count() > 0)
                {
                    foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                    {
                        if (!doOnlyWunde && rRezeptEintragMedDaten2.IDMedDaten != null)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == rRezeptEintragMedDaten2.IDMedDaten);
                            PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

                            string lstMedDatenTmp = "";

                            string sMedTyp = "";
                            System.Linq.IQueryable<PMDS.db.Entities.MedizinischeTypen> tMedizinischeTypen = null;
                            if (rMedizinischeDaten.MedizinischerTyp != null)
                            {
                                tMedizinischeTypen = db.MedizinischeTypen.Where(o => o.MedizinischerTyp == rMedizinischeDaten.MedizinischerTyp);
                                PMDS.db.Entities.MedizinischeTypen rMedizinischeTypen = tMedizinischeTypen.First();
                                sMedTyp = rMedizinischeTypen.Beschreibung.Trim();
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Med.Typ") + ":" + sMedTyp.Trim() + ", ";
                            }

                            if (rMedizinischeDaten.Beschreibung.Trim() != "")
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung") + ":" + rMedizinischeDaten.Beschreibung.Trim() + ", ";

                            string sVon = "";
                            if (rMedizinischeDaten.Von != null)
                            {
                                sVon = rMedizinischeDaten.Von.Value.ToString("dd.MM.yyyy");
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Von") + ":" + sVon.Trim() + ", ";
                            }

                            string sBis = "";
                            if (rMedizinischeDaten.Bis != null)
                            {
                                sBis = rMedizinischeDaten.Bis.Value.ToString("dd.MM.yyyy");
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis") + ":" + sBis.Trim() + ", ";
                            }

                            if (rMedizinischeDaten.Bemerkung.Trim() != "")
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung") + ":" + rMedizinischeDaten.Bemerkung.Trim() + ", ";

                            if (rMedizinischeDaten.Therapie.Trim() != "")
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie") + ":" + rMedizinischeDaten.Therapie.Trim() + ", ";

                            if (rMedizinischeDaten.Beendigungsgrund.Trim() != "")
                                lstMedDatenTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund") + ":" + rMedizinischeDaten.Beendigungsgrund.Trim() + ", ";

                            rRezeptEintrag.lstMedDaten += lstMedDatenTmp + "\r\n";
                            NumberMedDatenTmp += 1;
                            anyChanged = true;
                        }
                        else if (rRezeptEintragMedDaten2.IDWundeKopf != null)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = db.WundeKopf.Where(o => o.ID == rRezeptEintragMedDaten2.IDWundeKopf);
                            PMDS.db.Entities.WundeKopf rWundeKopf = tWundeKopf.First();

                            var tJoinWundeKopf = (from wk in db.WundeKopf
                                       join apx in db.AufenthaltPDx on wk.IDAufenthaltPDx equals apx.ID
                                       join pdx in db.PDX on apx.IDPDX equals pdx.ID
                                       where wk.ID == rWundeKopf.ID
                                       select new
                                       {
                                           PDXKlartext = pdx.Klartext,
                                           Lokalisierung = apx.Lokalisierung,
                                           LokalisierungSeite = apx.LokalisierungSeite,
                                           WKDatumErstellt = wk.DatumErstellt
                                       });

                            string lstWundeTmp = "";
                            foreach (var r in tJoinWundeKopf)
                            {
                                string sTmpErstellt = "";
                                if (r.WKDatumErstellt != null)
                                {
                                    sTmpErstellt = ", " + r.WKDatumErstellt.Value.ToString("dd.MM.yyyy") + "";
                                }
                                lstWundeTmp += "Wunde:" + r.PDXKlartext.Trim() + " (" + r.Lokalisierung.Trim() + ", " + r.LokalisierungSeite.Trim() +  sTmpErstellt + ")" + "\r\n";
                            }

                            rRezeptEintrag.lstWunden += lstWundeTmp + "\r\n";
                            NumberWundeTmp += 1;
                            anyChanged = true;
                        }

                    }
                }

                rRezeptEintrag.NumberMedDaten = NumberMedDatenTmp;
                rRezeptEintrag.NumberWunden = NumberWundeTmp;

                NumberMedDatenReturn = rRezeptEintrag.NumberMedDaten;
                lstMedDatenReturn = rRezeptEintrag.lstMedDaten;
                NumberWundenReturn = rRezeptEintrag.NumberWunden;
                lstWundenReturn = rRezeptEintrag.lstWunden;

                if (anyChanged)
                {
                    //db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.saveAnzeigeGridRezeptEintrag: " + ex.ToString());
            }
        }
        public void saveAnzeigeGridMedDaten(Guid IDMedDaten, PMDS.db.Entities.ERModellPMDSEntities db, ref string lstRezepteinträge, ref int NumberRezepteinträge)
        {
            try
            {
                bool anyChanged = false;
                DateTime dNow = DateTime.Now.Date;

                System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == IDMedDaten);
                PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();
                rMedizinischeDaten.lstRezepteinträge = "";

                int NumberRezepteinträgeTmp = 0;
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == IDMedDaten && o.IDVerordnung == null && o.IDRezepteintrag != null);
                if (tRezeptEintragMedDaten.Count() > 0)
                {
                    foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == rRezeptEintragMedDaten2.IDRezepteintrag);
                        PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();

                        if (rRezeptEintrag.AbzugebenBis >= dNow)
                        {
                            string lstRezepteinträgeTmp = "";

                            System.Linq.IQueryable<PMDS.db.Entities.Medikament> tMedikament = db.Medikament.Where(o => o.ID == rRezeptEintrag.IDMedikament);
                            PMDS.db.Entities.Medikament rMedikament = tMedikament.First();

                            lstRezepteinträgeTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament") + ":" + rMedikament.Bezeichnung.Trim() + ", ";
                            lstRezepteinträgeTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Von") + ":" + rRezeptEintrag.AbzugebenVon.ToString("dd.MM.yyyy") + ", ";
                            if (rRezeptEintrag.AbzugebenBis.Year != 3000)
                                lstRezepteinträgeTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis") + ":" + rRezeptEintrag.AbzugebenBis.ToString("dd.MM.yyyy") + ", ";
                            lstRezepteinträgeTmp += QS2.Desktop.ControlManagment.ControlManagment.getRes("Signatur") + ":" + rRezeptEintrag.DosierungASString.Trim() + ", ";


                            rMedizinischeDaten.lstRezepteinträge += lstRezepteinträgeTmp + "\r\n";
                            NumberRezepteinträgeTmp += 1;
                            anyChanged = true;
                        }

                    }
                }

                rMedizinischeDaten.NumberRezepteinträge = NumberRezepteinträgeTmp;
                lstRezepteinträge = rMedizinischeDaten.lstRezepteinträge;
                NumberRezepteinträge = rMedizinischeDaten.NumberRezepteinträge;

                if (anyChanged)
                {
                    //db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.saveAnzeigeGridMedDaten: " + ex.ToString());
            }
        }
  
        public void checkMedDatenAbgesetzt2(Nullable<Guid> IDMedDaten, PMDS.db.Entities.ERModellPMDSEntities db, Guid IDPatient, int iCheckFound)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstRezepteAbsetzen = new List<Guid>();
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == IDMedDaten && o.IDRezepteintrag != null && o.IDVerordnung == null);
                foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == rRezeptEintragMedDaten2.IDRezepteintrag);
                    PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();


                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten2 = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == rRezeptEintrag.ID);

                    if (rRezeptEintrag.AbzugebenBis.Year == 3000)
                    {
                        var tRezepteintragCheck = (from r in db.RezeptEintrag
                                                    join a in db.Aufenthalt on r.IDAufenthalt equals a.ID
                                                    join mer in db.RezeptEintragMedDaten on r.ID equals mer.IDRezepteintrag
                                                    join med in db.MedizinischeDaten on mer.IDMedDaten equals med.ID
                                                    where a.IDPatient == IDPatient && r.AbzugebenBis.Year == 3000 && r.ID == rRezeptEintrag.ID && med.Bis == null
                                                    orderby r.AbzugebenVon ascending, r.AbzugebenBis ascending
                                                    select new { IDRezeptEintrag = r.ID }).ToList();

                        foreach (var rRE in tRezepteintragCheck)
                        {
                            string rtmp = rRE.IDRezeptEintrag.ToString();  
                        }

                        if (tRezepteintragCheck.Count == iCheckFound)
                        {
                            lstRezepteAbsetzen.Add(rRezeptEintrag.ID);
                        }
                    }
                }

                if (lstRezepteAbsetzen.Count() > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die medizinischen Daten wurden abgesetzt!" + "\r\n" +
                                                                                                "Wollen Sie das Medikament auch absetzen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        foreach (Guid IDRezeptEintrag in lstRezepteAbsetzen)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == IDRezeptEintrag);
                            PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();

                            this.OpenFormRezeptEintrag(rRezeptEintrag.ID);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkMedDatenAbgesetzt2: " + ex.ToString());
            }
        }
        public void checkRezeptEintragAbgesetzt(Guid IDRezeptEintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstMedDatenAbgesetzt = new List<Guid>();
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == IDRezeptEintrag && o.IDVerordnung == null && o.IDMedDaten != null);
                foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == rRezeptEintragMedDaten2.IDMedDaten);
                    PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

                    if (rMedizinischeDaten.Bis == null)
                    {
                        var tIDMedDatenCheck = (from m in db.MedizinischeDaten
                                                join p in db.Patient on m.IDPatient equals p.ID
                                                join mer in db.RezeptEintragMedDaten on m.ID equals mer.IDMedDaten
                                                join rz in db.RezeptEintrag on mer.IDRezepteintrag equals rz.ID
                                                where p.ID == rMedizinischeDaten.IDPatient && m.Bis == null && mer.IDMedDaten == rMedizinischeDaten.ID && rz.AbzugebenBis.Year == 3000 && m.Bis == null
                                                orderby m.Von ascending, m.Bis ascending
                                                select new { IDMedDaten = m.ID }).ToList();

                        foreach (var rMD in tIDMedDatenCheck)
                        {
                            string rIDMedTmp = rMD.IDMedDaten.ToString();
                        }

                        if (tIDMedDatenCheck.Count == 0)
                        {
                            lstMedDatenAbgesetzt.Add(rMedizinischeDaten.ID);
                        }
                    }
                }

                if (lstMedDatenAbgesetzt.Count() > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das Medikament wurde abgesetzt!" + "\r\n" +
                                                                                                "Wollen Sie die medizinischen Daten auch absetzen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        foreach (Guid IDMedDaten in lstMedDatenAbgesetzt)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == IDMedDaten);
                            PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

                            this.OpenFormMedDaten(rMedizinischeDaten.ID);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkRezeptEintragAbgesetzt: " + ex.ToString());
            }
        }

        
        public Global.db.ERSystem.dsKlientenliste.UIRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, UltraGrid grid)
        {
            try
            {
                if (grid.ActiveRow != null)
                {
                    if (grid.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)grid.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.UIRow rSelRow = (Global.db.ERSystem.dsKlientenliste.UIRow)v.Row;
                        gridRow = grid.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getSelectedRow: " + ex.ToString());
            }
        }

        public bool abgesetzteAnzeigenJN(PMDS.db.Entities.RezeptEintrag rRezeptEintrag, bool bBeendeteAnzeigen, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (!bBeendeteAnzeigen)
                {
                    if (rRezeptEintrag.AbzugebenBis < DateTime.Now)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.abgesetzteAnzeigenJN: " + ex.ToString());
            }
        }
        
        public bool checkDeleteMedDatenRezeptEinträgeExists(Guid IDMedDaten)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == IDMedDaten && o.IDVerordnung == null);
                    if (tRezeptEintragMedDaten.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkRezepteinträgeExists: " + ex.ToString());
            }
        }
        public bool showMsgBoxDeleteMedDatenRezeptEinträgeExists()
        {
            try
            {
                DialogResult res = DialogResult.Yes;
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Es existieren zu diesem med. Datensatz Medikamentzuordnungen!" + "\r\n" +
                                                                                "Falls Sie diesen Datensatz löschen werden die Zuordnungen ebenfalls gelöscht." + "\r\n" + "\r\n" + "Wollen Sie die Aktivität wirklich durchführen?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
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
                throw new Exception("PMDSBusinessUI.showMsgBoxDeleteMedDatenRezeptEinträgeExists: " + ex.ToString());
            }
        }

        public bool checkDeleteRezepteinträgeMedDatenExists(Guid IDRezeptEintrag)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == IDRezeptEintrag && o.IDVerordnung  != null);
                    if (tRezeptEintragMedDaten.Count() > 0)
                    {
                        DialogResult res = DialogResult.Yes;
                        res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Es existieren zu diesem Medikmanent " + tRezeptEintragMedDaten.Count().ToString() + ". med. Datenzuordnungen!" + "\r\n" +
                                                                                        "Falls Sie diesen Datensatz löschen werden die Zuordnungen ebenfalls gelöscht." + "\r\n" + "\r\n" + "Wollen Sie die Aktivität wirklich durchführen?", "", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkDeleteRezepteinträgeMedDatenExists: " + ex.ToString());
            }
        }

        public bool checkBestellvorschlag(VO_Bestelldaten rVO_Bestelldaten, Nullable<Guid> IDVOBestelldatenNotCheck)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.VO rVO = db.VO.Where(o => o.ID == rVO_Bestelldaten.IDVerordnung).First();
                    PMDS.db.Entities.Aufenthalt rAufenthalt = db.Aufenthalt.Where(o => o.ID == rVO.IDAufenthalt).First();
                    PMDS.db.Entities.Patient rPatient = db.Patient.Where(o => o.ID == rAufenthalt.IDPatient).First();

                    var tVO_BestelldatenCheck = (from b in db.VO_Bestelldaten
                                                 join v in db.VO on b.IDVerordnung equals v.ID
                                                 where b.IDMedikament == rVO_Bestelldaten.IDMedikament && v.IDAufenthalt == rVO.IDAufenthalt
                                                 select new
                                                 {
                                                     IDVO_Bestelldaten = b.ID,
                                                     IDMedikament = b.IDMedikament,
                                                     GültigAb = b.GueltigAb,
                                                     GültigBis = b.GueltigBis
                                                 });

                    bool bVOBestelldatenExists = false;
                    foreach (var rVO_BestelldatenCheckInDB in tVO_BestelldatenCheck)
                    {
                        if (IDVOBestelldatenNotCheck == null || (!IDVOBestelldatenNotCheck.Equals(rVO_Bestelldaten.ID)))
                        {
                            DateTime GültigBisDB = new DateTime(3000, 1, 1, 0, 0, 0);
                            if (rVO_BestelldatenCheckInDB.GültigBis != null)
                                GültigBisDB = rVO_BestelldatenCheckInDB.GültigBis.Value.Date;

                            DateTime GültigBisAct = new DateTime(3000, 1, 1, 0, 0, 0);
                            if (rVO_Bestelldaten.GueltigBis != null)
                                GültigBisAct = rVO_Bestelldaten.GueltigBis.Value.Date;

                            if ((rVO_Bestelldaten.GueltigAb.Date >= rVO_BestelldatenCheckInDB.GültigAb.Date && rVO_Bestelldaten.GueltigAb.Date <= GültigBisDB.Date))
                            {
                                bVOBestelldatenExists = true;
                            }
                            if ((GültigBisAct.Date >= rVO_BestelldatenCheckInDB.GültigAb.Date && GültigBisAct.Date <= GültigBisDB.Date))
                            {
                                bVOBestelldatenExists = true;
                            }

                            if ((rVO_Bestelldaten.GueltigAb.Date <= rVO_BestelldatenCheckInDB.GültigAb.Date && GültigBisAct.Year == 3000))
                            {
                                bVOBestelldatenExists = true;
                            }
                        }
                    }

                    if (bVOBestelldatenExists)
                    {
                        string txtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren für dieses Medikament und den Klienten '{0}' mehr als eine Bestellvorschrift in diesem Zeitraum!" + "\r\n" + "\r\n" +
                                                                                                    "Wollen Sie die Bestellvorschrift trotzdem speichern?");
                        txtMsgBox = string.Format(txtMsgBox, rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim());
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtMsgBox, "", MessageBoxButtons.YesNo, true);
                        if (res == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "checkBestellvorschlag"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkBestellvorschlag: " + ex.ToString());
            }
        }

        public string checkDeleteVO(Guid IDVO)
        {
            try
            {
                string txtReturn = "";

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.VO_Bestelldaten> tVO_Bestelldaten = db.VO_Bestelldaten.Where(o => o.IDVerordnung == IDVO);
                    foreach (var rVO_Bestelldaten in tVO_Bestelldaten)
                    {
                        PMDS.db.Entities.Medikament rMedikament = db.Medikament.Where(o => o.ID == rVO_Bestelldaten.IDMedikament).First();
                        var rPatient = (from v in db.VO
                                       join a in db.Aufenthalt on v.IDAufenthalt equals a.ID
                                       join p in db.Patient on a.IDPatient equals p.ID
                                       where v.ID == rVO_Bestelldaten.IDVerordnung
                                       select new
                                       {
                                           Nachname = p.Nachname,
                                           Vorname = p.Vorname,
                                           IDPatient = p.ID
                                       }).First();

                        txtReturn += QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung:") + rMedikament.Bezeichnung.Trim() + " - " + 
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient:") + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + " - " + 
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig ab:") + rVO_Bestelldaten.GueltigAb.ToString("dd.MM.yyyy") + "\r\n";

                        string InfoBestellpositionen = this.checkDeleteVO_Bestelldaten(rVO_Bestelldaten.ID, false);
                        if (InfoBestellpositionen.Trim() != "")
                        {
                            txtReturn += InfoBestellpositionen + "\r\n";
                        }
                    }

                    if (txtReturn.Trim() != "")
                    {
                        txtReturn = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren folgende Bestelldaten zu der Verordnung:") + txtReturn;
                    }
                }

                return txtReturn;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "checkDeleteVO"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkDeleteVO: " + ex.ToString());
            }
        }
        public string checkDeleteVO_Bestelldaten(Guid IDVO_Bestelldaten, bool fullInfo)
        {
            try
            {
                string txtReturn = "";

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.VO_Bestellpostitionen> tVO_Bestellpostitionen = db.VO_Bestellpostitionen.Where(o => o.IDBestelldaten_VO == IDVO_Bestelldaten);
                    foreach (var rVO_Bestellpostitionen in tVO_Bestellpostitionen)
                    {
                        PMDS.db.Entities.Medikament rMedikament = db.Medikament.Where(o => o.ID == rVO_Bestellpostitionen.IDMedikament).First();

                        var rPatient = (from v in db.VO
                                        join bd2 in db.VO_Bestelldaten on v.ID equals bd2.IDVerordnung
                                        join a in db.Aufenthalt on v.IDAufenthalt equals a.ID
                                        join p in db.Patient on a.IDPatient equals p.ID
                                        where bd2.ID == rVO_Bestellpostitionen.IDBestelldaten_VO
                                        select new
                                        {
                                            Nachname = p.Nachname,
                                            Vorname = p.Vorname,
                                            IDPatient = p.ID
                                        }).First();

                        txtReturn += QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung:") + rMedikament.Bezeichnung.Trim() + " - " + 
                                       QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient:") + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + " - " + 
                                       QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig ab:") + rVO_Bestellpostitionen.DatumErstellt.ToString("dd.MM.yyyy") + "\r\n";
                    }

                    if (txtReturn.Trim() != "")
                    {
                        if (fullInfo)
                            txtReturn = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren folgende Bestellpositionen zu den Bestelldaten:") + txtReturn;
                        else
                            txtReturn = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestelldaten:") + "\r\n" + txtReturn + "\r\n";
                    }
                }

                return txtReturn;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "checkDeleteVO_Bestelldaten"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkDeleteVO_Bestelldaten: " + ex.ToString());
            }
        }



        public void InitListKostentraegerart(UltraComboEditor cbo, bool activeRowIsNull, bool TransferleistungJN, bool PatientbezogenJN, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                cbo.Items.Clear();

                if (activeRowIsNull)
                {
                    PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbo, true);
                }
                else if (TransferleistungJN) 
                {
                    cbo.Items.Add((int)Kostentraegerart.Transferleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung"));
                }
                else
                {
                    cbo.Items.Add((int)Kostentraegerart.Grundkosten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"));
                    if (PatientbezogenJN)   
                    {
                        PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbo, false);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.InitListKostentraegerart: " + ex.ToString());
            }
        }

        public void getAllUsersCbo(UltraComboEditor cbo, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                cbo.Items.Clear();
                PMDSBusiness b = new PMDSBusiness();
                IQueryable<PMDS.db.Entities.Benutzer> tAllUsers = b.getAllUsers2(db);
                dsGUIDListe.IDListeDataTable t = PMDS.BusinessLogic.Benutzer.All();
                foreach (PMDS.db.Entities.Benutzer rBenutzer in tAllUsers)
                {
                    cbo.Items.Add(rBenutzer.ID, rBenutzer.Benutzer1.Trim() + " (" + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + ")");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getAllUsersCbo: " + ex.ToString());
            }
        }

        public void loadZahlartCbo(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            ValueListItem itm = cbo.Items.Add((int)PMDS.Calc.Logic.eZahlart.Bankeinzug, PMDS.Calc.Logic.eZahlart.Bankeinzug.ToString());
            itm = cbo.Items.Add((int)PMDS.Calc.Logic.eZahlart.Bar, PMDS.Calc.Logic.eZahlart.Bar.ToString());
            itm = cbo.Items.Add((int)PMDS.Calc.Logic.eZahlart.Erlagschein, PMDS.Calc.Logic.eZahlart.Erlagschein.ToString());
            itm = cbo.Items.Add((int)PMDS.Calc.Logic.eZahlart.Überweisung, PMDS.Calc.Logic.eZahlart.Überweisung.ToString());

        }

        public static void getListHerrichtenMedikamente(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            try
            {
                cbo.Items.Clear();

                cbo.Items.Add(0, QS2.Desktop.ControlManagment.ControlManagment.getRes("nein (z.B. Salben)"));
                cbo.Items.Add(1, QS2.Desktop.ControlManagment.ControlManagment.getRes("kurzfristig (z.B. Tropfen)"));
                cbo.Items.Add(2, QS2.Desktop.ControlManagment.ControlManagment.getRes("langfristig (Dispenser)"));
                cbo.Items.Add(3, QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung"));
                cbo.Items.Add(4, QS2.Desktop.ControlManagment.ControlManagment.getRes("ärztlich"));
                cbo.Items.Add(5, QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchtgift"));

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getListHerrichtenMedikamente: " + ex.ToString());
            }
        }
        public static string getTxtHerrichten(int iHerrichten)
        {
            try
            {
                string txtHerrichten = "";

                if (iHerrichten == 0)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("nein (z.B. Salben)");
                }
                else if (iHerrichten == 1)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("kurzfristig (z.B. Tropfen)");
                }
                else if (iHerrichten == 2)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("langfristig (Dispenser)");
                }
                else if (iHerrichten == 3)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung");
                }
                else if (iHerrichten == 4)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("ärztlich");
                }
                else if (iHerrichten == 5)
                {
                    txtHerrichten = QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchtgift");
                }
                else
                {
                    throw new Exception("getTxtHerrichten: Text for iHerrichten '" + iHerrichten.ToString() + "' not defined!");
                }

                return txtHerrichten.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getTxtHerrichten: " + ex.ToString());
            }
        }

        public static bool checkCboBox(PMDS.GUI.BaseControls.AuswahlGruppeCombo cbo, string TitleMsg, bool getOnlyMsgTxt, ref string MsgTxtBack, bool useColorWrong = false)
        {
            try
            {
                if (cbo.ExactMatch)
                {
                    if (!cbo.PflichtJN && cbo.SelectedItem == null && cbo.Text.Trim() != "")
                    {
                        if (useColorWrong)
                        {
                            cbo.Appearance.BackColor = Color.Yellow;
                            cbo.UseAppStyling = false;
                        }
                        string MsgTxtTmp = TitleMsg.Trim() + ": " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Falsche Eingabe!");
                        if (getOnlyMsgTxt)
                        {
                            MsgTxtBack += MsgTxtTmp + "\r\n";
                            cbo.Focus();
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxtTmp, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
                            cbo.Focus();
                        }
                        return false;
                    }
                    else if (cbo.PflichtJN && cbo.SelectedItem == null)
                    {
                        if (useColorWrong)
                        {
                            cbo.Appearance.BackColor = Color.Yellow;
                            cbo.UseAppStyling = false;
                        }
                        string MsgTxtTmp = TitleMsg.Trim() + ": " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl erforderlich!");
                        if (getOnlyMsgTxt)
                        {
                            MsgTxtBack += (MsgTxtTmp + "\r\n");
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxtTmp, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
                            cbo.Focus();
                        }
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkCboBox: " + ex.ToString());
            }
        }
        public static bool checkCboBoxWrongInput(UltraComboEditor cbo, string TitleMsg, bool getOnlyMsgTxt, ref string MsgTxtBack, bool useColorWrong = false)
        {
            try
            {
                if (cbo.SelectedItem == null && cbo.Text.Trim() != "")
                {
                    if (useColorWrong)
                    {
                        cbo.Appearance.BackColor = Color.Yellow;
                        cbo.UseAppStyling = false;
                    }

                    string MsgTxtTmp = TitleMsg.Trim() + ": " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Falsche Eingabe!");
                    if (getOnlyMsgTxt)
                    {
                        MsgTxtBack += MsgTxtTmp + "\r\n";
                        cbo.Focus();
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxtTmp, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
                        cbo.Focus();
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
                throw new Exception("PMDSBusinessUI.checkCboBoxWrongInput: " + ex.ToString());
            }
        }

        public static string getDekursKontaktperson(bool bAdded, PMDS.BusinessLogic.Kontaktperson Kontaktperson)
        {
            string txtDekurs = "";
            if (bAdded)
            {
                if (Kontaktperson.Nachname.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ") + " -> " + Kontaktperson.Nachname.Trim();
                if (Kontaktperson.Vorname.Trim() != "") txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ") + Kontaktperson.Vorname.Trim();
                if (Kontaktperson.Titel.Trim() != "") txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ") + Kontaktperson.Titel.Trim();
                if (Kontaktperson.Kontaktart.Trim() != "") txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktart: ") + Kontaktperson.Kontaktart.Trim();
                if (Kontaktperson.Verwandschaft.Trim() != "") txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwandtschaft: ") + Kontaktperson.Verwandschaft.Trim();
                txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vertrauensperson: ") + getTxtBool(Kontaktperson.VerstaendigenJN);
                txtDekurs += "\r\n" + " -> " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Externer Dienstleister: ") + getTxtBool(Kontaktperson.ExternerDienstleisterJN);

                txtDekurs += getDekursKontakteAdress(bAdded, Kontaktperson.Adresse);
                txtDekurs += getDekursKontakteKontakt(bAdded, Kontaktperson.Kontakt);
            }
            else
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Kontaktperson rKontaktpersonDB = db.Kontaktperson.Where(o => o.ID == Kontaktperson.ID).First();

                    if (rKontaktpersonDB.Nachname.Trim() != Kontaktperson.Nachname.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ") + rKontaktpersonDB.Nachname.Trim() + " -> " + Kontaktperson.Nachname.Trim();
                    }
                    if (rKontaktpersonDB.Vorname.Trim() != Kontaktperson.Vorname.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ") + rKontaktpersonDB.Vorname.Trim() + " -> " + Kontaktperson.Vorname.Trim();
                    }
                    if (rKontaktpersonDB.Titel.Trim() != Kontaktperson.Titel.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ") + rKontaktpersonDB.Titel.Trim() + " -> " + Kontaktperson.Titel.Trim();
                    }
                    if (rKontaktpersonDB.Kontaktart.Trim() != Kontaktperson.Kontaktart.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktart: ") + rKontaktpersonDB.Kontaktart.Trim() + " -> " + Kontaktperson.Kontaktart.Trim();
                    }
                    if (rKontaktpersonDB.Verwandtschaft.Trim() != Kontaktperson.Verwandschaft.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwandtschaft: ") + rKontaktpersonDB.Verwandtschaft.Trim() + " -> " + Kontaktperson.Verwandschaft.Trim();
                    }
                    if (rKontaktpersonDB.VerstaendigenJN != Kontaktperson.VerstaendigenJN)
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vertrauensperson: ") + getTxtBool(rKontaktpersonDB.VerstaendigenJN) + " -> " + getTxtBool(Kontaktperson.VerstaendigenJN);
                    }
                    if (rKontaktpersonDB.ExternerDienstleisterJN != Kontaktperson.ExternerDienstleisterJN)
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Externer Dienstleister: ") + getTxtBool(rKontaktpersonDB.ExternerDienstleisterJN) + " -> " + getTxtBool(Kontaktperson.ExternerDienstleisterJN);
                    }

                    if (Kontaktperson.IDAdresse != null)
                    {
                        txtDekurs += getDekursKontakteAdress(bAdded, Kontaktperson.Adresse);
                    }
                    if (Kontaktperson.IDKontakt != null)
                    {
                        txtDekurs += getDekursKontakteKontakt(bAdded, Kontaktperson.Kontakt);
                    }
                }
            }

            return txtDekurs.Trim();
        }
        public static string getDekursAerzte(dsAerzte.AerzteRow rArzt, PMDS.BusinessLogic.Adresse rAdress, PMDS.BusinessLogic.Kontakt rKontakt)
        {
            string txtDekurs = "";
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Aerzte rAerzteDB = db.Aerzte.Where(o => o.ID == rArzt.ID).First();

                if (rAerzteDB.Nachname.Trim() != rArzt.Nachname.Trim())
                {
                    txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ") + rAerzteDB.Nachname.Trim() + " -> " + rArzt.Nachname.Trim();
                }
                if (rAerzteDB.Vorname.Trim() != rArzt.Vorname.Trim())
                {
                    txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ") + rAerzteDB.Vorname.Trim() + " -> " + rArzt.Vorname.Trim();
                }
                if (rAerzteDB.Titel.Trim() != rArzt.Titel.Trim())
                {
                    txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ") + rAerzteDB.Titel.Trim() + " -> " + rArzt.Titel.Trim();
                }
                if (rAerzteDB.Fachrichtung.Trim() != rArzt.Fachrichtung.Trim())
                {
                    txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Fachrichtung: ") + rAerzteDB.Fachrichtung.Trim() + " -> " + rArzt.Fachrichtung.Trim();
                }

                if (rArzt.IDAdresse != null)
                {
                    txtDekurs += getDekursKontakteAdress(false, rAdress);
                }
                if (rArzt.IDKontakt != null)
                {
                    txtDekurs += getDekursKontakteKontakt(false, rKontakt);
                }
            }

            return txtDekurs.Trim();
        }

        public static string getDekursKontakteAdress(bool bAdded, PMDS.BusinessLogic.Adresse rAdress)
        {
            string txtDekurs = "";
            if (bAdded)
            {
                if (rAdress.Strasse.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Strasse: ") + " -> " + rAdress.Strasse.Trim();
                if (rAdress.Plz.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Plz: ") + " -> " + rAdress.Plz.Trim();
                if (rAdress.Ort.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Ort: ") + " -> " + rAdress.Ort.Trim();
                if (rAdress.LandKZ.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Land: ") + " -> " + rAdress.LandKZ.Trim();
            }
            else
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdressDB = db.Adresse.Where(o => o.ID == rAdress.ID).First();

                    if (rAdressDB.Strasse.Trim() != rAdress.Strasse.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Strasse: ") + rAdressDB.Strasse.Trim() + " -> " + rAdress.Strasse.Trim();
                    }
                    if (rAdressDB.Plz.Trim() != rAdress.Plz.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Plz: ") + rAdressDB.Plz.Trim() + " -> " + rAdress.Plz.Trim();
                    }
                    if (rAdressDB.Ort.Trim() != rAdress.Ort.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Ort: ") + rAdressDB.Ort.Trim() + " -> " + rAdress.Ort.Trim();
                    }
                    if (rAdressDB.LandKZ.Trim() != rAdress.LandKZ.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Land: ") + rAdressDB.LandKZ.Trim() + " -> " + rAdress.LandKZ.Trim();
                    }
                }
            }

            return txtDekurs.Trim();
        }
        public static string getDekursKontakteKontakt(bool bAdded, PMDS.BusinessLogic.Kontakt Kontakt)
        {
            string txtDekurs = "";
            if (bAdded)
            {
                if (Kontakt.Tel.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Telefon: ") + " -> " + Kontakt.Tel.Trim();
                if (Kontakt.Mobil.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Mobil: ") + " -> " + Kontakt.Mobil.Trim();
                if (Kontakt.Fax.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Fax: ") + " -> " + Kontakt.Fax.Trim();
                if (Kontakt.Email.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("E-Mail: ") + " -> " + Kontakt.Email.Trim();
                if (Kontakt.Andere.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Andere: ") + " -> " + Kontakt.Andere.Trim();
                if (Kontakt.Ansprechpartner.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Ansprechpartner: ") + " -> " + Kontakt.Ansprechpartner.Trim();
                if (Kontakt.Zusatz1.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz1: ") + " -> " + Kontakt.Zusatz1.Trim();
                if (Kontakt.Zusatz2.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz2: ") + " -> " + Kontakt.Zusatz2.Trim();
                if (Kontakt.Zusatz3.Trim() != "") txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz3: ") + " -> " + Kontakt.Zusatz3.Trim();

                //txtDekurs += "Name: " + name.Trim() + "\r\n";
                //txtDekurs += "Adresse: " + adresse.Trim() + "\r\n";
                //txtDekurs += "E-Mail: " + row.EMail.Trim();
            }
            else
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Kontakt rKontaktDB = db.Kontakt.Where(o => o.ID == Kontakt.ID).First();

                    if (rKontaktDB.Tel.Trim() != Kontakt.Tel.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Telefon: ") + rKontaktDB.Tel.Trim() + " -> " + Kontakt.Tel.Trim();
                    }
                    if (rKontaktDB.Mobil.Trim() != Kontakt.Mobil.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Mobil: ") + rKontaktDB.Mobil.Trim() + " -> " + Kontakt.Mobil.Trim();
                    }
                    if (rKontaktDB.Fax.Trim() != Kontakt.Fax.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Fax: ") + rKontaktDB.Fax.Trim() + " -> " + Kontakt.Fax.Trim();
                    }
                    if (rKontaktDB.Email.Trim() != Kontakt.Email.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("E-Mail: ") + rKontaktDB.Email.Trim() + " -> " + Kontakt.Email.Trim();
                    }
                    if (rKontaktDB.Andere.Trim() != Kontakt.Andere.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Andere: ") + rKontaktDB.Andere.Trim() + " -> " + Kontakt.Andere.Trim();
                    }
                    if (rKontaktDB.Ansprechpartner.Trim() != Kontakt.Ansprechpartner.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Ansprechpartner: ") + rKontaktDB.Ansprechpartner.Trim() + " -> " + Kontakt.Ansprechpartner.Trim();
                    }
                    if (rKontaktDB.Zusatz1.Trim() != Kontakt.Zusatz1.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz1: ") + rKontaktDB.Zusatz1.Trim() + " -> " + Kontakt.Zusatz1.Trim();
                    }
                    if (rKontaktDB.Zusatz2.Trim() != Kontakt.Zusatz2.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz2: ") + rKontaktDB.Zusatz2.Trim() + " -> " + Kontakt.Zusatz2.Trim();
                    }
                    if (rKontaktDB.Zusatz3.Trim() != Kontakt.Zusatz3.Trim())
                    {
                        txtDekurs += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz3: ") + rKontaktDB.Zusatz3.Trim() + " -> " + Kontakt.Zusatz3.Trim();
                    }
                }
            }

            return txtDekurs.Trim();
        }

        public static string getTxtBool(Nullable<bool> bVal)
        {
            string sJa = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
            string sNein = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");

            if (bVal == null || bVal == false)
                return sNein;
            else
                return sJa;
        }


        public static bool checkAerzteELGAHausarztOKInDB(Guid IDPatient, ref UltraGrid gridÄrzte)
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                var t = db.PatientAerzte.Where(o => o.IDPatient == IDPatient && o.ELGA_HausarztJN == true);
                if (t.Count() != 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Patienten existiert bereits ein ELGA-Hausarzt!" + "\r\n" +
                                                                                                    "Soll dieser als Hausarzt gespeichert werden und der neue Arzt als ELGA-Hausarzt gespeichert werden?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        if (gridÄrzte != null)
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in gridÄrzte.Rows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                var rPatAerzte = (PMDS.Global.db.Global.dsPatientAerzte.PatientAerzteRow)v.Row;
                                if (rPatAerzte.RowState != DataRowState.Deleted)
                                {
                                    if (rPatAerzte.ELGA_HausarztJN)
                                    {
                                        rPatAerzte.ELGA_HausarztJN = false;
                                        rPatAerzte.HausarztJN = true;
                                    }
                                }
                            }

                            gridÄrzte.Refresh();
                        }

                        db.SaveChanges();
                        return true;

                        //System.Collections.Generic.List<Guid> lÄrzteChanged = new List<Guid>();
                        //foreach (var r in t)
                        //{
                        //    r.ELGA_HausarztJN = false;
                        //    r.HausarztJN = true;
                        //    lÄrzteChanged.Add(r.IDAerzte);
                        //}
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return true;
            }
        }

        public bool checkTexteditorForStern(UltraTextEditor txtEditor, ErrorProvider errorProvider1, string NameField)
        {
            try
            {
                if (txtEditor.Text.Trim().Contains(("*")))
                {
                    int posStern = Regex.Matches(txtEditor.Text.Trim(), Regex.Escape("*")).Count;
                    if (posStern > 1)
                    {
                        errorProvider1.SetError(txtEditor, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(NameField + QS2.Desktop.ControlManagment.ControlManagment.getRes(": *-Zeichen darf nur einmal und nur am Ende in der Eingabe vorkommen!"), true);
                        return false;
                    }
                    else if (posStern == 1)
                    {
                        int posStern2 = txtEditor.Text.Trim().IndexOf("*");
                        if (posStern2 != txtEditor.Text.Trim().Length - 1)
                        {
                            errorProvider1.SetError(txtEditor, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(NameField + QS2.Desktop.ControlManagment.ControlManagment.getRes(": *-Zeichen darf nur am Ende in der Eingabe vorkommen!"), true);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkTexteditorForStern: " + ex.ToString());
            }
        }

        public void genCDA(Guid IDPatient, Guid IDAufenthalt, QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA CDAeTypeCDA, bool verstorbenJN)
        {
            try
            {
                if (!ENV.lic_ELGA)
                {
                    return;
                }

                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }

                ELGABusiness bElga = new ELGABusiness();
                if (!bElga.ELGAIsActive(IDPatient, IDAufenthalt, false))
                {
                    return;
                }

                WCFServiceClient wcf = new WCFServiceClient();
                DateTime dNow = DateTime.Now;

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    string ClinicalDocumentSetID = System.Guid.NewGuid().ToString();
                    Guid IDDocument = System.Guid.NewGuid();
                    int VersionsNr = 0;

                    var rPatient = (from p in db.Patient
                                    where p.ID == IDPatient
                                    select new
                                    {
                                        p.ID,
                                        p.Nachname,
                                        p.Vorname,
                                        p.ELGAAbgemeldet
                                    }).First();

                    var rAufenthalt = (from a in db.Aufenthalt
                                       where a.ID == IDAufenthalt
                                       select new
                                       {
                                           a.ID,
                                           a.ELGALocalID,
                                           a.ELGAKontaktbestätigungJN,
                                           a.ELGAKontaktbestätigungContactID
                                       }).First();

                    if (CDAeTypeCDA == QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA.Entlassungsbrief)
                    {
                        string Documentname = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegerischer Entlassungsbrief");
                        string Stylesheet = "ELGA_Stylesheet_v1.0.xsl";
                        bool hasRight = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPflegerischerEntlassungsbrief, false);

                        this.prieviewSendSaveCDA(IDPatient, IDAufenthalt, CDAeTypeCDA, IDDocument, ClinicalDocumentSetID, VersionsNr, Documentname, Stylesheet, rAufenthalt.ELGALocalID.Trim(), db, dNow, hasRight, 
                                                    null, verstorbenJN);

                        if (rAufenthalt.ELGAKontaktbestätigungJN)
                        {
                            ELGAParOutDto parOuot = wcf.ELGAAddContactDischarge(rAufenthalt.ELGAKontaktbestätigungContactID.Trim());

                            string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Kontakt für Patient {0} wurde beendet");
                            sProt = string.Format(sProt, (rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim()));
                            ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Kontakt beendet"), null,
                                                            ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, IDPatient, IDAufenthalt, sProt);

                            string msgOKEndContact = QS2.Desktop.ControlManagment.ControlManagment.getRes("Elga-Kontakt für Patient wurde erfolgreich beendet!");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgOKEndContact, "", MessageBoxButtons.OK, true);
                        }
                    }
                    else if (CDAeTypeCDA == QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA.Pflegesituationbericht)
                    {
                        string Documentname = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegezustandsbericht");
                        string Stylesheet = "ELGA_Stylesheet_v1.0.xsl";
                        bool hasRight = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPflegezustandsbericht, false);

                        frmPrintPflegebegleitschreibenInfo frmPrintPflegebegleitschreibenInfo1 = new PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo();
                        frmPrintPflegebegleitschreibenInfo1.btnSaveToArchive.Visible = true;
                        DialogResult res = frmPrintPflegebegleitschreibenInfo1.ShowDialog();
                        if (res != DialogResult.OK && !frmPrintPflegebegleitschreibenInfo1.saveToArchive)
                        {
                            this.prieviewSendSaveCDA(IDPatient, IDAufenthalt, CDAeTypeCDA, IDDocument, ClinicalDocumentSetID, VersionsNr, Documentname, Stylesheet, rAufenthalt.ELGALocalID.Trim(), db, dNow, hasRight,
                                                        (Guid)frmPrintPflegebegleitschreibenInfo1.cbETo.Value, verstorbenJN);
                        }
                        else
                        {
                            this.prieviewSendSaveCDA(IDPatient, IDAufenthalt, CDAeTypeCDA, IDDocument, ClinicalDocumentSetID, VersionsNr, Documentname, Stylesheet, rAufenthalt.ELGALocalID.Trim(), db, dNow, hasRight,
                                                        null, verstorbenJN);
                        }
                    }
                    else
                    {
                        throw new Exception("PMDSBusinessUI.genCDA: CDAeTypeCDA '" + CDAeTypeCDA.ToString() + "' not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.genCDA: " + ex.ToString());
            }
        }
        public void prieviewSendSaveCDA(Guid IDPatient, Guid IDAufenthalt, QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA CDAeTypeCDA, 
                                        Guid IDDocument, string ClinicalDocumentSetID, int VersionsNr,
                                        string Documentname, string Stylesheet, string PatientELGALocalID, PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                        bool hasRight, Nullable<Guid> IDEinrichtungEmpfänger, bool verstorbenJN)
        {
            try
            {
                WCFServiceClient wcf = new WCFServiceClient();
                ELGABusiness bElga = new ELGABusiness();

                string ArchivePath = "";
                Nullable<Guid> IDOrdnerArchiv = null;
                if (!bElga.checkArchivesystem(ref ArchivePath, ref IDOrdnerArchiv))
                {
                    throw new Exception("PMDSBusinessUI.prieviewSendSaveCDA: ArchivePath not correct!" + "\r\n" + "Please contact your Administrator!");
                }

                WCFServiceClient.genCDARes resCda = wcf.genCDA(CDAeTypeCDA, IDEinrichtungEmpfänger, IDDocument, ClinicalDocumentSetID, VersionsNr, Stylesheet, IDPatient, IDAufenthalt, Documentname);

                bool SavedToELGA = false;
                string msg1 = "";
                frmCDAViewer frmCDAViewer1 = new frmCDAViewer();
                frmCDAViewer1.initControl(Documentname, "", ClinicalDocumentSetID, resCda.xml, CDAeTypeCDA.ToString(), Stylesheet, contCDAViewer.eTypeUI.SaveToElga);
                frmCDAViewer1.contCDAViewer1.btnSaveDocuToELGA.Visible = !verstorbenJN;
                frmCDAViewer1.ShowDialog();
                if (!frmCDAViewer1.contCDAViewer1.abort)
                {
                    if (frmCDAViewer1.contCDAViewer1.saveToElgaClicked)
                    {
                        if (hasRight)
                        {
                            bool bSaveDocuOK = bElga.saveDocuToELGA(IDPatient, IDAufenthalt, Documentname, resCda.xml, resCda.bXml, Stylesheet, ClinicalDocumentSetID, CDAeTypeCDA);
                            string msgOK = QS2.Desktop.ControlManagment.ControlManagment.getRes("CDA-Dokument wurde erfogreich generiert, nach ELGA hochgeladen und im Dokumentenarchiv gespeichert!");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgOK, "", MessageBoxButtons.OK, true);
                            SavedToELGA = true;
                        }
                        else
                        {
                            msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen, da Sie hierfür keine Rechte besitzen!");
                            bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, ref IDOrdnerArchiv, db, ref dNow, ref wcf, IDAufenthalt,
                                                                    IDPatient, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), true, 0);
                        }
                    }
                    else
                    {
                        msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen!");
                        bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, ref IDOrdnerArchiv, db, ref dNow, ref wcf, IDAufenthalt,
                                                            IDPatient, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), true, 0);
                    }
                }
                else
                {
                    msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen!");
                    bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, ref IDOrdnerArchiv, db, ref dNow, ref wcf, IDAufenthalt,
                                                            IDPatient, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), true, 0);
                }

                if (!SavedToELGA)
                {
                    string msg2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es kann später jederzeit im Dokumentenarchiv nachübertragen werden!");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msg1 + "\r\n" +  msg2, "", MessageBoxButtons.OK, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.prieviewSendSaveCDA: " + ex.ToString());
            }
        }
    }

}
