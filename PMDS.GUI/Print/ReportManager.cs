using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using PMDS.DynReportsForms;
using System.Text;
using Microsoft.Win32;
using PMDS.Print.CR;
using PMDS.Global.db.Global;
using PMDS.Global.db.ERSystem;
using System.Windows.Forms;
using System.Linq;
using S2Extensions;

namespace PMDS.Print
{



    public class ReportManager
    {

        private string THtyp;
        private string THReportPath;
        private Guid THIDKlient;
        private string THReportRoot;
        private bool THPrintJN;
        private bool THUsePDFPrinter;
        private System.Guid THIDAnamnese;
        private string THKlientNameGebDat;
        private ENV.eKlientenberichtTyp THKlientenberichtTyp;
        private Guid THIDAufenthalt;
        private string THPDFName;
        private int THcntAufenthalt;

        public ReportManager()
        {
        }

        public ReportManager(string typ, string ReportPath, Guid IDKlient, string ReportRoot, bool PrintJN, bool UsePDFPrinter, System.Guid IDAnamnese, string KlientNameGebDat, ENV.eKlientenberichtTyp KlientenberichtTyp)
        {
            THtyp = typ;
            THReportPath = ReportPath;
            THIDKlient = IDKlient;
            THReportRoot = ReportRoot;
            THPrintJN = PrintJN;
            THUsePDFPrinter = UsePDFPrinter;
            THIDAnamnese = IDAnamnese;
            THKlientNameGebDat = KlientNameGebDat;
            THKlientenberichtTyp = KlientenberichtTyp;
        }

        public ReportManager(string ReportPath, Guid IDKlient, Guid IDAufenthalt, string ReportRoot, bool PrintJN, string PDFName, ENV.eKlientenberichtTyp KlientenberichtTyp, int cntAufenthalt)
        {
            THReportPath = ReportPath;
            THIDKlient = IDKlient;
            THIDAufenthalt = IDAufenthalt;
            THReportRoot = ReportRoot;
            THPrintJN = PrintJN;
            THPDFName = PDFName;
            THKlientenberichtTyp = KlientenberichtTyp;
            THcntAufenthalt = cntAufenthalt;
        }

        private static DataSet GetDataSetFromList(List<BerichtDatenquelle> listds, string sCompareString)
        {
            if (listds == null)
                return null;
            foreach (BerichtDatenquelle q in listds)
            {
                if (q.Bereich == sCompareString)
                    return q.DATASET;
            }
            return null;
        }

        private static bool IsInList(List<BerichtDatenquelle> listds, string sCompareString)
        {
            if (listds == null)
                return false;
            foreach (BerichtDatenquelle q in listds)
            {
                if (q.Bereich == sCompareString)
                    return true;
            }
            return false;
        }

        public static void PrintUnterbringungReport(Guid IDUnterbringung, Guid IDKlinik_current, DateTime Beginn)
        {
            string sPath = Beginn >= DateTime.ParseExact("2010-07-01", "yyyy-MM-dd", null) ? ENV.CheckReportExists("UNTERBRINGUNG2010.rpt") : ENV.CheckReportExists("UNTERBRINGUNG.rpt");

            List<BerichtParameter> list = new List<BerichtParameter>();
            BerichtParameter b = new BerichtParameter("IDUnterbringung", BerichtParameter.BerichtParameterTyp.Text, "IDUnterbringung", IDUnterbringung.ToString());
            b.Value = "{" + IDUnterbringung.ToString() + "}";
            list.Add(b);

            BerichtParameter c = new BerichtParameter("IDKlinik_current", BerichtParameter.BerichtParameterTyp.Text, "IDKlinik_current", IDKlinik_current.ToString());
            c.Value = "{" + IDKlinik_current.ToString() + "}";
            list.Add(c);

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, "",
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);
        }

        public static void PrintNotfallBlattReport(Guid IDSP)
        {
            string sPath = ENV.CheckReportExists("NOTFALLBLATT.rpt");

            List<BerichtParameter> list = new List<BerichtParameter>();
            BerichtParameter b = new BerichtParameter("IDSP_Current", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDSP_Current", IDSP.ToString());
            b.Value = "{" + IDSP.ToString() + "}";
            list.Add(b);

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, "",
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);
        }


        public static void PrintPflegePlanPDxOrientated(Guid IDAufenthalt, bool bBeendeteAnzeigen)
        {
            ReportDocument rpt = ReportManager.GetPflegePlanPDxOrientated();
            //rpt.SetDatabaseLogon(Settings.DB_USER, Settings.DB_PASSWORD, Settings.DB_SERVER, Settings.DB_DATABASE);

            TableLogOnInfo info = new TableLogOnInfo();
            info.ConnectionInfo.DatabaseName = ENV.DB_DATABASE;
            info.ConnectionInfo.ServerName = ENV.DB_SERVER;


            if (ENV.INTEGRATED_SECURITY == null || ENV.INTEGRATED_SECURITY == "0")
            {
                info.ConnectionInfo.Password = ENV.DB_PASSWORD;
                info.ConnectionInfo.UserID = ENV.DB_USER;
            }

            else
            {
                info.ConnectionInfo.IntegratedSecurity = true;
                info.ConnectionInfo.Password = string.Empty;
                info.ConnectionInfo.UserID = string.Empty;
            }


            foreach (Table t in rpt.Database.Tables)
            {
                t.ApplyLogOnInfo(info);
                t.Location = t.Name;
                t.ApplyLogOnInfo(info);
            }

            Aufenthalt a = new Aufenthalt(IDAufenthalt);

            ReportManager.AddCrystalParameter(rpt, "IDAufenthalt_current", IDAufenthalt.ToString("B"));
            ReportManager.AddCrystalParameter(rpt, "IDKlinik_current", a.IDKlinik.ToString("B"));
            ReportManager.AddCrystalParameter(rpt, "IDAbteilung_current", a.IDAbteilung.ToString("B"));

            ReportManager.AddCrystalParameter(rpt, "SHOWALL", bBeendeteAnzeigen ? true : false);
            frmPrintPreview frm = new frmPrintPreview(rpt);
            frm.Show();
        }

        public static void AddCrystalParameter(ReportDocument crReport, string ParameterName, string ParameterValue)
        {
            ParameterFieldDefinitions crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields;

            ParameterValues crParameterValues = new ParameterValues();
            ParameterFieldDefinition param = crParameterFieldDefinitions[ParameterName];
            crParameterValues = param.CurrentValues;

            ParameterDiscreteValue param_Val = new ParameterDiscreteValue();
            param_Val.Value = ParameterValue;
            crParameterValues.Add(param_Val);

            param.ApplyCurrentValues(crParameterValues);
        }

        public static void AddCrystalParameter(ReportDocument crReport, string ParameterName, object oParameterValue)
        {
            if (!HasParameter(crReport, ParameterName))
                return;

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = oParameterValue.ToString();
            crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[ParameterName];
            crParameterFieldDefinition.CurrentValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

        }

        private static bool HasParameter(ReportDocument crReport, string ParameterName)
        {
            foreach (ParameterField f in crReport.ParameterFields)
            {

                if (String.Compare(f.Name, ParameterName, true) == 0)
                    return true;
            }
            return false;
        }

        public static ReportDocument GetPflegerKarteReport(string Barcode, string Name, string KlinikName, string Klinikadresse)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("PFLEGERKARTE.rpt"));
                AddCrystalParameter(rpt, "BARCODE", Barcode);
                AddCrystalParameter(rpt, "NAME", Name);
                AddCrystalParameter(rpt, "KLINIKNAME", KlinikName);
                AddCrystalParameter(rpt, "KLINIKADRESSE", Klinikadresse);
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }


        private static void SetActiveFormEnabled(bool bEnabled)
        {
            if (System.Windows.Forms.Form.ActiveForm != null)
            {
                if (bEnabled)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    System.Windows.Forms.Form.ActiveForm.Enabled = bEnabled;
                }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                }
            }
        }

        public static ReportDocument GetManBuchungen(PMDS.Global.db.Global.ds_abrechnung.dsManBuch ds)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("manBuchungen.rpt"));
                PMDS.Print.CR.ReportManager.setDataSource(ds, ENV.CheckReportExists("manBuchungen.rpt"), rpt);
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }

        }

        public static ReportDocument GetTaschengeldReport(PMDS.Global.db.Global.ds_abrechnung.dsPrintTaschengeld ds)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("TASCHENGELD.rpt"));
                PMDS.Print.CR.ReportManager.setDataSource(ds, ENV.CheckReportExists("TASCHENGELD.rpt"), rpt);
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }


        public static ReportDocument GetPflegePlanPDxOrientated()
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("PFLEGEPLAN.rpt"));
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }

        public static ReportDocument GetTerminliste(
                            DataTable dt,
                            dsAuswahlGruppe.AuswahlListeDataTable t, TerminlisteAnsichtsmodi Ansichtsinfo, eUITypeTermine UITypeTermine)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();

                rpt.Load(ENV.CheckReportExists("rptAUFGABENLISTE.rpt"));   // statt AUFGABENLISTE
                PMDS.Print.CR.ReportManager.setDataSource(dt, ENV.CheckReportExists("rptAUFGABENLISTE.rpt"), rpt);   //lthok

                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }

        public static void PrintMedvorbereitung(bool bKlientenansichtJN, Guid IDAbteilung, Guid IDBereich, Guid IDAufenthalt, DateTime dtVon, DateTime dtBis, int iVorberNein, int iVorberkurz, 
                                                int iVorberlang, int iVorberBedarf, int iVorberArzt, int iVorberSuchtgift, bool bAnmerkung, string lstPatients)
        {

            object[] ParameterArray = { bKlientenansichtJN, IDAbteilung, IDBereich, IDAufenthalt, dtVon, dtBis, iVorberNein, iVorberkurz, iVorberlang, iVorberBedarf, iVorberArzt, iVorberSuchtgift, bAnmerkung };
            PMDS.Print.CR.BerichtParameter.BerichtParameterTyp[] TypArray ={ PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean, BerichtParameter.BerichtParameterTyp.Abteilung,BerichtParameter.BerichtParameterTyp.Bereich,BerichtParameter.BerichtParameterTyp.Text,BerichtParameter.BerichtParameterTyp.DatumZeit,BerichtParameter.BerichtParameterTyp.DatumZeit,BerichtParameter.BerichtParameterTyp.Zahl,
                                            PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Zahl,BerichtParameter.BerichtParameterTyp.Zahl,BerichtParameter.BerichtParameterTyp.Zahl,BerichtParameter.BerichtParameterTyp.Zahl,BerichtParameter.BerichtParameterTyp.Zahl,BerichtParameter.BerichtParameterTyp .Boolean};
            string[] ParameterNameArray = { "bKlientenansichtJN", "IDAbteilung", "IDBereich", "IDAufenthalt", "dtVon", "dtBis", "iVorberNein", "iVorberkurz", "iVorberlang", "iVorberBedarf", "iVorberArzt", "iVorberSuchtgift", "bAnmerkung" };

            string sPath = ENV.CheckReportExists("MEDIKAMENTVORBEREITUNG.rpt");

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Irgendwas_mir_egal", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = ParameterArray[i].ToString();
                else
                    b.Value = ParameterArray[i];

                list.Add(b);

            }

            BerichtParameter b2 = new BerichtParameter("lstPatients", BerichtParameter.BerichtParameterTyp.Text, "lstPatients", "");
            b2.Value = lstPatients;
            list.Add(b2);

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, "",
                                               ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported, false, lstPatients);

        }

        public static ReportDocument GetMedikamentenAusgabe(dsMedikationVonBis.MedikationDataTable dt)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("MEDIKAMENTENAUSGABE.rpt"));
                PMDS.Print.CR.ReportManager.setDataSource((DataTable)dt, ENV.CheckReportExists("MEDIKAMENTENAUSGABE.rpt"), rpt);
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }
        public static ReportDocument GetMedikamentenBlatt(dsRezeptEintrag.RezeptEintragDataTable dt, Guid IDAufenthalt, bool AbgesetzteMedNo)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("MEDIKAMENTENBLATT.rpt"));
                dsRepMedikamentenBlatt ds = MedikamentenBlattDataSource.FilldsMBlatt(dt, IDAufenthalt, AbgesetzteMedNo);

                using (dsKlientenliste dsKlientenliste1 = new dsKlientenliste())
                {
                    using (sqlManange sqlManange1 = new sqlManange())
                    {
                        sqlManange1.initControl();
                        System.Collections.Generic.List<int> lstMedDaten = new List<int>();
                        lstMedDaten.Add(3);
                        lstMedDaten.Add(6);

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            var rAufenthalt = (from a2 in db.Aufenthalt
                                               where a2.ID == IDAufenthalt
                                               select new
                                               {
                                                   IDPatient = a2.IDPatient,
                                                   IDAufenthalt = a2.ID,
                                               }).First();

                            sqlManange1.getMedizinischeDaten(dsKlientenliste1, rAufenthalt.IDPatient.Value, lstMedDaten, sqlManange.eTypeMedDaten.MedDaten);
                            sqlManange1.getMedizinischeDatenLayout(dsKlientenliste1, sqlManange.eTypeMedDaten.All);
                        }
                    }
                    DataTable dtMedDaten = new DataTable();
                    DataTable dtMedDatenLayout = new DataTable();

                    if (dsKlientenliste1.MedizinischeDaten.Any())    //os 19-02-22 - Sonst gibt es ein Exception, wenn keine Unverträglichkeit oder Allerige vorliegt
                        dtMedDaten = dsKlientenliste1.MedizinischeDaten.CopyToDataTable();
                    if (dsKlientenliste1.MedizinischeDatenLayout.Any())
                        dtMedDatenLayout = dsKlientenliste1.MedizinischeDatenLayout.CopyToDataTable();

                    StartMedizinischeDaten:
                    foreach (DataTable t in ds.Tables)
                    {
                        if (t.TableName == "MedizinischeDaten")
                        {
                            ds.Tables.Remove(t);
                            goto StartMedizinischeDaten;
                        }
                    }
                    dtMedDaten.TableName = "MedizinischeDaten";
                    ds.Tables.Add(dtMedDaten);

                    StartMedizinischeDatenLayout:
                    foreach (DataTable t in ds.Tables)
                    {
                        if (t.TableName == "MedizinischeDatenLayout")
                        {
                            ds.Tables.Remove(t);
                            goto StartMedizinischeDatenLayout;
                        }
                    }
                    dtMedDatenLayout.TableName = "MedizinischeDatenLayout";
                    ds.Tables.Add(dtMedDatenLayout);
                }
                PMDS.Print.CR.ReportManager.setDataSource(ds, ENV.CheckReportExists("MEDIKAMENTENBLATT.rpt"), rpt);

                //<20120216>
                Aufenthalt a = new Aufenthalt(IDAufenthalt);
                Guid IDKlinik = System.Guid.NewGuid();
                Guid IDAbteilung = System.Guid.NewGuid();

                if (a.IDKlinik != null) IDKlinik = a.IDKlinik;
                if (a.IDAbteilung != null) IDAbteilung = a.IDAbteilung;

                rpt.Refresh();

                AddCrystalParameter(rpt, "vabgesetzeMed", true);
                AddCrystalParameter(rpt, "IDKlinik_current", IDKlinik);
                AddCrystalParameter(rpt, "IDAbteilung_current", IDAbteilung);

                //ds.WriteXml("F:\\dsMedikamentenBlatt.xml", XmlWriteMode.WriteSchema);
                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }

        public static ReportDocument GetBewerberliste(dsPatientBewerber.PatientDataTable dt)
        {
            SetActiveFormEnabled(false);
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("BEWERBERLISTE.rpt"));
                PMDS.Print.CR.ReportManager.setDataSource((DataTable)dt, ENV.CheckReportExists("BEWERBERLISTE.rpt"), rpt);

                return rpt;
            }
            finally
            {
                SetActiveFormEnabled(true);
            }
        }

        public static void PrintHeimVertrag(Guid IDPatient, DateTime Wirksamkeitvon, string zimmerart_txt, bool befristetJN, DateTime befristetbis, string Vertragspartner_txt, string Vertrauensperson_txt, bool unbefristetjn)
        {
            object[] ParameterArray = { IDPatient, Wirksamkeitvon, zimmerart_txt, befristetJN, befristetbis, Vertragspartner_txt, Vertrauensperson_txt, unbefristetjn };
            BerichtParameter.BerichtParameterTyp[] TypArray ={BerichtParameter.BerichtParameterTyp.Klient, BerichtParameter.BerichtParameterTyp.DatumZeit,BerichtParameter.BerichtParameterTyp.Text,BerichtParameter.BerichtParameterTyp.Boolean
                                             ,BerichtParameter.BerichtParameterTyp.DatumZeit,BerichtParameter.BerichtParameterTyp.Text,BerichtParameter.BerichtParameterTyp.Text,BerichtParameter.BerichtParameterTyp.Boolean};
            string[] ParameterNameArray = { "Klient", "Wirksamkeitvon", "zimmerart_txt", "befristetJN", "befristetbis", "Vertragspartner_txt", "Vertrauensperson_txt", "unbefristetjn" };

            string sPath = ENV.CheckReportExists("HEIMVERTRAG.rpt");

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Irgendwas_mir_egal", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = ParameterArray[i].ToString();
                else
                    b.Value = ParameterArray[i];

                list.Add(b);

            }

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, "",
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }

        public static void PrintStammdatenblatt(Guid IDPatient, Guid AufenthaltID, bool FreiheitsbeschränkendeMaßnahmenJN, bool VersicherungsdatenJN, bool Med_DatenJN, bool KontaktpersonJN, bool SachwalterJN, bool ÄrzteJN, bool RegelungenJN, bool PflegestufeJN, bool KostentraegerJN, bool VerwahrungJN, bool HilfsmittelJN, bool DienstleisterJN, bool RehamaßnahmenJN)
        {
            //<20120216> IDKlinik und IDAbteilung hinzufügen
            string sPath = "";
            Aufenthalt a;
            System.Guid IDKlinik_current = System.Guid.NewGuid();
            System.Guid IDAbteilung_current = System.Guid.NewGuid();

            if (AufenthaltID != Guid.Empty)
            {
                sPath = ENV.CheckReportExists("KLIENTENSTAMMDATENBLATT.rpt");
                a = new Aufenthalt(AufenthaltID);
                IDKlinik_current = a.IDKlinik;
                IDAbteilung_current = a.IDAbteilung;
            }
            else
            {
                sPath = ENV.CheckReportExists("BEWERBERSTAMMDATENBLATT.rpt");
            }


            object[] ParameterArray = { IDPatient, AufenthaltID, FreiheitsbeschränkendeMaßnahmenJN, VersicherungsdatenJN, Med_DatenJN, KontaktpersonJN, SachwalterJN, ÄrzteJN, RegelungenJN, 
                                          PflegestufeJN, KostentraegerJN, VerwahrungJN, HilfsmittelJN, DienstleisterJN, RehamaßnahmenJN, IDKlinik_current, IDAbteilung_current };

            BerichtParameter.BerichtParameterTyp[] TypArray ={BerichtParameter.BerichtParameterTyp.Klient,BerichtParameter.BerichtParameterTyp.Text, BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,
                                             BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,
                                             BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,BerichtParameter.BerichtParameterTyp.Boolean,
                                             BerichtParameter.BerichtParameterTyp.Abteilung,BerichtParameter.BerichtParameterTyp.Abteilung};

            string[] ParameterNameArray = { "IDKlient_current", "AufenthaltID", "FreiheitsbeschränkendeMaßnahmenJN", "VersicherungsdatenJN", "Med_DatenJN", "KontaktpersonJN", "SachwalterJN", "ÄrzteJN", 
                                            "RegelungenJN", "PflegestufeJN", "KostentraegerJN", "VerwahrungJN", "HilfsmittelJN", "DienstleisterJN", "RehamaßnahmenJN",
                                            "IDKlinik_current", "IDAbteilung_current"};



            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Dummy", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid) || ParameterNameArray[i].Equals("AufenthaltID"))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);

            }

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, "",
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }


        public static void PrintKlientenbericht(string ReportPath, Guid IDKlient, Guid IDAufenthalt, string ReportRoot, bool PrintJN, string PDFName, ENV.eKlientenberichtTyp KlientenberichtTyp, int cntAufenthalt, out string sFileFullNameExported)
        {
            object[] ParameterArray = { IDKlient, IDAufenthalt, ReportRoot, PrintJN };
            BerichtParameter.BerichtParameterTyp[] TypArray = {
                BerichtParameter.BerichtParameterTyp.Klient,
                BerichtParameter.BerichtParameterTyp.SQL_GUID,
                BerichtParameter.BerichtParameterTyp.Text,
                BerichtParameter.BerichtParameterTyp.Zahl
            };
            string[] ParameterNameArray = { "IDKlient", "IDAufenthalt", "ReportRoot", "PrintJN"};
            string sPath = ReportPath;

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Beschreibung", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);
            }
            BerichtParameter bT = new BerichtParameter("Beschreibung", BerichtParameter.BerichtParameterTyp.Zahl, "KlientenberichtTyp", "0");
            bT.Value = (int)KlientenberichtTyp;
            list.Add(bT);

            BerichtParameter bA = new BerichtParameter("AufenthaltNr", BerichtParameter.BerichtParameterTyp.Zahl, "AufenthaltNr", "0");
            bA.Value = cntAufenthalt;
            list.Add(bA);

            sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, false, list, null, PDFName,
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }

        public void PrintKlientenberichtAsThread()
        {
            object[] ParameterArray = { THIDKlient, THIDAufenthalt, THReportRoot, THPrintJN };
            BerichtParameter.BerichtParameterTyp[] TypArray = {
                BerichtParameter.BerichtParameterTyp.Klient,
                BerichtParameter.BerichtParameterTyp.SQL_GUID,
                BerichtParameter.BerichtParameterTyp.Text,
                BerichtParameter.BerichtParameterTyp.Zahl
            };
            string[] ParameterNameArray = { "IDKlient", "IDAufenthalt", "ReportRoot", "PrintJN" };
            string sPath = THReportPath;

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Beschreibung", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);
            }
            BerichtParameter bT = new BerichtParameter("Beschreibung", BerichtParameter.BerichtParameterTyp.Zahl, "KlientenberichtTyp", "0");
            bT.Value = (int)THKlientenberichtTyp;
            list.Add(bT);

            BerichtParameter bA = new BerichtParameter("AufenthaltNr", BerichtParameter.BerichtParameterTyp.Zahl, "AufenthaltNr", "0");
            bA.Value = THcntAufenthalt;
            list.Add(bA);

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, false, list, null, THPDFName,
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }

        public static void PrintBlisterliste(string ReportPath, Guid IDKlinik, Guid IDAbteilung, Guid IDKlient, string ReportRoot, bool PrintJN, string PDFName)
        {
            object[] ParameterArray = { IDKlinik , IDAbteilung, IDKlient, ReportRoot, PrintJN };
            BerichtParameter.BerichtParameterTyp[] TypArray = {
                BerichtParameter.BerichtParameterTyp.SQL_GUID,
                BerichtParameter.BerichtParameterTyp.SQL_GUID,
                BerichtParameter.BerichtParameterTyp.Klient,
                BerichtParameter.BerichtParameterTyp.Text,
                BerichtParameter.BerichtParameterTyp.Boolean
            };
            string[] ParameterNameArray = { "IDKlinik", "IDAbteilung", "IDKlient", "ReportRoot", "PrintJN" };
            string sPath = ReportPath;

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Beschreibung", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);

            }

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, false, list, null, PDFName,
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }

        public static void PrintAnamnese(string typ, string ReportPath, Guid IDKlient, string ReportRoot, bool PrintJN, bool UsePDFPrinter, System.Guid IDAnamnese, string KlientNameGebDat, ENV.eKlientenberichtTyp KlientenberichtTyp, out string sFileFullNameExported)
        {
            object[] ParameterArray = { IDKlient, ReportRoot, PrintJN, UsePDFPrinter, IDAnamnese };
            BerichtParameter.BerichtParameterTyp[] TypArray = { BerichtParameter.BerichtParameterTyp.Klient, BerichtParameter.BerichtParameterTyp.Text, BerichtParameter.BerichtParameterTyp.Boolean, BerichtParameter.BerichtParameterTyp.Boolean, BerichtParameter.BerichtParameterTyp.SQL_GUID };
            string pIDName = "";
            if (typ.sEquals("OREM"))
            {
                pIDName = "IDAnamneseOREM";
            }
            else if (typ.sEquals("Krohwinkel"))
            {
                pIDName = "IDAnamneseKrohwinkel";
            }
            else if (typ.sEquals("POP"))
            {
                pIDName = "IDAnamnesePOP";
            }

            string[] ParameterNameArray = { "IDKlient", "ReportRoot", "PrintJN", "UsePDFPrinter", pIDName };
            string sPath = ReportPath;

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Beschreibung", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);
            }
            BerichtParameter bT = new BerichtParameter("Beschreibung", BerichtParameter.BerichtParameterTyp.Zahl, "KlientenberichtTyp", "0");
            bT.Value = (int)KlientenberichtTyp;
            list.Add(bT);

            sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, KlientNameGebDat,
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);
        }

        public void PrintAnamneseAsThread()
        {
            object[] ParameterArray = { THIDKlient, THReportRoot, THPrintJN, THUsePDFPrinter, THIDAnamnese };
            BerichtParameter.BerichtParameterTyp[] TypArray = { BerichtParameter.BerichtParameterTyp.Klient, BerichtParameter.BerichtParameterTyp.Text, BerichtParameter.BerichtParameterTyp.Boolean, BerichtParameter.BerichtParameterTyp.Boolean, BerichtParameter.BerichtParameterTyp.SQL_GUID };
            string pIDName = "";
            if (THtyp.sEquals("OREM"))
            {
                pIDName = "IDAnamneseOREM";
            }
            else if (THtyp.sEquals("Krohwinkel"))
            {
                pIDName = "IDAnamneseKrohwinkel";
            }
            else if (THtyp.sEquals("POP"))
            {
                pIDName = "IDAnamnesePOP";
            }

            string[] ParameterNameArray = { "IDKlient", "ReportRoot", "PrintJN", "UsePDFPrinter", pIDName };
            string sPath = THReportPath;

            List<BerichtParameter> list = new List<BerichtParameter>();
            for (int i = 0; i < ParameterArray.Length; i++)
            {
                BerichtParameter b = new BerichtParameter("Beschreibung", TypArray[i], ParameterNameArray[i], ParameterArray[i].ToString());
                if (ParameterArray[i].GetType() == typeof(Guid))
                    b.Value = "{" + ParameterArray[i].ToString() + "}";
                else
                    b.Value = ParameterArray[i];

                list.Add(b);
            }
            BerichtParameter bT = new BerichtParameter("Beschreibung", BerichtParameter.BerichtParameterTyp.Zahl, "KlientenberichtTyp", "0");
            bT.Value = (int)THKlientenberichtTyp;
            list.Add(bT);

            string sFileFullNameExported = "";
            PMDS.Print.CR.ReportManager.PrintDynamicReport(sPath, true, list, null, THKlientNameGebDat,
                                                           ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, null, ref sFileFullNameExported);

        }

        public static void PrintArztbrief(string Einrichtung, string Anmerkung, Guid IDPatient, Guid IDUser, Guid IDAufenthalt,
                                            string Abteilung, bool DiagnosenJN, bool MedikamenteJN)
        {
            try
            {   //lthArztabrechnung
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("Arztbrief.rpt"));

                dsRezeptEintrag.RezeptEintragDataTable dt = null;
                dsRepMedikamentenBlatt dsMedBlatt = PMDS.DynReportsForms.MedikamentenBlattDataSource.FilldsMBlatt(dt, IDAufenthalt, false);
                frmPrintPreview.LogOnCrystReport(rpt, null, false);
                foreach (Section s in rpt.ReportDefinition.Sections)
                {
                    foreach (ReportObject o in s.ReportObjects)
                    {
                        if (o.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject so = (SubreportObject)o;
                            ReportDocument doc = so.OpenSubreport(so.SubreportName);
                            if (so.SubreportName.Trim().ToLower().Equals(("rptsubMedkimanetnblatt.rpt").Trim().ToLower()))
                            {
                                doc.SetDataSource(dsMedBlatt);
                            }
                        }
                    }
                }

                ReportManager.AddCrystalParameter(rpt, "IDPatient", IDPatient.ToString("B"));
                ReportManager.AddCrystalParameter(rpt, "IDUser", IDUser.ToString("B"));
                ReportManager.AddCrystalParameter(rpt, "IDAufenthalt", IDAufenthalt.ToString("B"));
                ReportManager.AddCrystalParameter(rpt, "Einrichtung", Einrichtung.Trim());
                ReportManager.AddCrystalParameter(rpt, "Anmerkung", Anmerkung.Trim());
                ReportManager.AddCrystalParameter(rpt, "Abteilung", Abteilung.Trim());
                ReportManager.AddCrystalParameter(rpt, "DiagnosenJN", (DiagnosenJN == true? 1:0));
                ReportManager.AddCrystalParameter(rpt, "MedikamenteJN", (MedikamenteJN == true ? 1 : 0));

                frmPrintPreview frm = new frmPrintPreview(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                throw new Exception("PrintArztbrief: " + ex.ToString());
            }
        }
        public static void PrintDiagnoseliste(Guid IDPatient, Guid IDUser, Guid IDAufenthalt)
        {
            try
            {     
                ReportDocument rpt = new ReportDocument();
                rpt.Load(ENV.CheckReportExists("Diagnoseliste.rpt"));
                frmPrintPreview.LogOnCrystReport(rpt, null, false);

                ReportManager.AddCrystalParameter(rpt, "IDPatient", IDPatient.ToString("B"));
                ReportManager.AddCrystalParameter(rpt, "IDUser", IDUser.ToString("B"));
                ReportManager.AddCrystalParameter(rpt, "IDAufenthalt", IDAufenthalt.ToString("B"));

                frmPrintPreview frm = new frmPrintPreview(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                throw new Exception("PrintDiagnoseliste: " + ex.ToString());
            }
        }

        public static void PrintTermine(DataSet dsTermine, string ViewMode, string Title, Guid IDKlinik, Guid IDAbteilung, Guid IDBereich, 
                                            Nullable<DateTime> dFrom, Nullable<DateTime> dTo, string UserLoggedOn,
                                            string lstKlients, string lstUsers, string lstCategories, string Quickbutton)
        {
            try
            {
                //dsTermine.WriteXml(Settings.pathConfig + "\\dsTermine.xml", XmlWriteMode.WriteSchema);
                //dsTermine.WriteXmlSchema(Settings.pathConfig + "\\dsTermine.xsd");
                //return;

                ReportDocument rpt = new ReportDocument();
                string ReportFile = "";

                string strCheck = Quickbutton.Trim().ToLower();
                switch (strCheck)
                {
                    case "resid.patientbeginn":
                        ReportFile = Path.Combine(ENV.ReportPath, "Termine1.rpt");
                        break;
                    case "resid.patientkategorie":
                        ReportFile = Path.Combine(ENV.ReportPath, "Termine2.rpt");
                        break;
                    case "resid.kategoriepatient":
                        ReportFile = Path.Combine(ENV.ReportPath, "Termine3.rpt");
                        break;
                    default:
                        ReportFile = Path.Combine(ENV.ReportPath, "Termine4.rpt");
                        break;
                }

                rpt.Load(ReportFile);
                frmPrintPreview.LogOnCrystReport(rpt, dsTermine.Tables["plan"], true);
                             
                ReportManager.AddCrystalParameter(rpt, "IDKlinik", IDKlinik.ToString());
                ReportManager.AddCrystalParameter(rpt, "IDAbteilung", IDAbteilung.ToString());
                ReportManager.AddCrystalParameter(rpt, "IDBereich", IDBereich.ToString());

                if (dFrom is null)
                {
                    ReportManager.AddCrystalParameter(rpt, "dFrom", DateTime.MinValue);
                }
                else
                {
                    ReportManager.AddCrystalParameter(rpt, "dFrom", dFrom);
                }
                if (dTo is null)
                {
                    ReportManager.AddCrystalParameter(rpt, "dTo", DateTime.MinValue);
                }
                else
                {
                    ReportManager.AddCrystalParameter(rpt, "dTo", dTo);
                }
           
                ReportManager.AddCrystalParameter(rpt, "UserLoggedOn", UserLoggedOn.Trim());
                ReportManager.AddCrystalParameter(rpt, "lstKlients", lstKlients.Trim());
                ReportManager.AddCrystalParameter(rpt, "lstUsers", lstUsers.Trim());
                ReportManager.AddCrystalParameter(rpt, "lstCategories", lstCategories.Trim());
                ReportManager.AddCrystalParameter(rpt, "Title", Title.Trim());
                ReportManager.AddCrystalParameter(rpt, "ViewMode", ViewMode.Trim());
                ReportManager.AddCrystalParameter(rpt, "Quickbutton", Quickbutton.Trim());

                frmPrintPreview frm = new frmPrintPreview(rpt);
                frm.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("ReportManager.PrintTermine: " + ex.ToString());
            }
        }
        public static void PrintTermineBereich(DataSet dsTermine, string ViewMode, string Title, Guid IDKlinik, 
                                    Nullable<DateTime> dFrom, Nullable<DateTime> dTo, string UserLoggedOn,
                                    string lstCategories, string Quickbutton)
        {
            try
            {                
                dsTermine.WriteXml(ENV.pathConfig + "\\dsTermineBereich.xml", XmlWriteMode.WriteSchema);
                dsTermine.WriteXmlSchema(ENV.pathConfig + "\\dsTermineBereich.xsd");
                //return;

                ReportDocument rpt = new ReportDocument();
                string ReportFile = "";

                switch (Quickbutton)
                {
                    case "AbtBereichPlan":
                        ReportFile = Path.Combine(ENV.ReportPath, "TermineBereich1.rpt");
                        break;
                    case "KatAbtBereichPlan":
                        ReportFile = Path.Combine(ENV.ReportPath, "TermineBereich2.rpt");
                        break;
                    case "Plan":
                        ReportFile = Path.Combine(ENV.ReportPath, "TermineBereich3.rpt");
                        break;
                    default:
                        ReportFile = Path.Combine(ENV.ReportPath, "TermineBereich1.rpt");
                        break;
                }

                rpt.Load(ReportFile);
                frmPrintPreview.LogOnCrystReport(rpt, dsTermine.Tables["planBereich"], true);

                ReportManager.AddCrystalParameter(rpt, "IDKlinik", IDKlinik.ToString());

                if (dFrom is null)
                {
                    ReportManager.AddCrystalParameter(rpt, "dFrom", DateTime.MinValue);
                }
                else
                {
                    ReportManager.AddCrystalParameter(rpt, "dFrom", dFrom);
                }
                if (dTo is null)
                {
                    ReportManager.AddCrystalParameter(rpt, "dTo", DateTime.MinValue);
                }
                else
                {
                    ReportManager.AddCrystalParameter(rpt, "dTo", dTo);
                }

                ReportManager.AddCrystalParameter(rpt, "UserLoggedOn", UserLoggedOn.Trim());
                ReportManager.AddCrystalParameter(rpt, "lstCategories", lstCategories.Trim());
                ReportManager.AddCrystalParameter(rpt, "Title", Title.Trim());
                ReportManager.AddCrystalParameter(rpt, "ViewMode", ViewMode.Trim());
                ReportManager.AddCrystalParameter(rpt, "Quickbutton", Quickbutton.Trim());

                frmPrintPreview frm = new frmPrintPreview(rpt);
                frm.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("ReportManager.PrintTermineBereich: " + ex.ToString());
            }
        }
        public static void PrintVOErfassen(dsVO dsVO, Guid IDKlinik, Guid IDAbteilung,
                                                Nullable<DateTime> dFrom, Nullable<DateTime> dTo, string lTyp, string UserLoggedOn, bool exportDS, bool DetailsJN,
                                                string lstIDs)
        {
            try
            {
                if (exportDS)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog1.Filter = "Xml-File|*.xml";
                    saveFileDialog1.Title = "Save Xml-File for Printing";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName.Trim() != "")
                    {
                        string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName.Trim());
                        string dirToSave = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName.Trim());
                        string XsdFile = System.IO.Path.Combine(dirToSave, filenameWithoutExtension.Trim() + ".xsd");
                        dsVO.WriteXml(saveFileDialog1.FileName.Trim(), XmlWriteMode.WriteSchema);
                        dsVO.WriteXmlSchema(XsdFile.Trim());
                        return;
                    }
                }
                else
                {
                    ReportDocument rpt = new ReportDocument();
                    string ReportFile = ENV.ReportPath + "\\" + "VOErfassen.rpt";

                    if (!System.IO.File.Exists(ReportFile.Trim()))
                    {
                        string txtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Reportdatei '{0}' wurde nicht gefunden!" + "\r\n" + "Es kann kein Druck durchgeführt werden!");
                        txtMsgBox = string.Format(txtMsgBox, ReportFile.Trim());
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtMsgBox, "", MessageBoxButtons.OK, true);
                        return;
                    }

                    rpt.Load(ReportFile);
                    frmPrintPreview.LogOnCrystReport(rpt, null, true);       //  frmPrintPreview.LogOnCrystReport(rpt, dsVO.VO, true);

                    ReportManager.AddCrystalParameter(rpt, "IDKlinik", IDKlinik.ToString());
                    ReportManager.AddCrystalParameter(rpt, "IDAbteilung", IDAbteilung.ToString());
                    ReportManager.AddCrystalParameter(rpt, "IDVO", lstIDs.Trim());
                    ReportManager.AddCrystalParameter(rpt, "DetailsJN", (DetailsJN ? "1" : "0"));
                    if (dFrom is null)
                    {
                        ReportManager.AddCrystalParameter(rpt, "dFrom", DateTime.MinValue);
                    }
                    else
                    {
                        ReportManager.AddCrystalParameter(rpt, "dFrom", dFrom);
                    }
                    if (dTo is null)
                    {
                        ReportManager.AddCrystalParameter(rpt, "dTo", DateTime.MinValue);
                    }
                    else
                    {
                        ReportManager.AddCrystalParameter(rpt, "dTo", dTo);
                    }
                    ReportManager.AddCrystalParameter(rpt, "Type", lTyp.Trim());
                    ReportManager.AddCrystalParameter(rpt, "UserLoggedOn", UserLoggedOn.Trim());

                    frmPrintPreview frm = new frmPrintPreview(rpt);
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ReportManager.PrintVOErfassen: " + ex.ToString());
            }
        }

        public static void PrintVOBestellvorschlägeLieferungen(dsVO dsVO, Guid IDKlinik, Guid IDAbteilung,
                                                                Nullable<DateTime> dFrom, Nullable<DateTime> dTo, string lstTyp, string UserLoggedOn, bool exportDS, bool IsLieferung,
                                                                string lstIDs)
        {
            try
            {
                if (exportDS)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog1.Filter = "Xml-File|*.xml";
                    saveFileDialog1.Title = "Save Xml-File for Printing";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName.Trim() != "")
                    {
                        string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName.Trim());
                        string dirToSave = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName.Trim());
                        string XsdFile = System.IO.Path.Combine(dirToSave, filenameWithoutExtension.Trim() + ".xsd");
                        dsVO.WriteXml(saveFileDialog1.FileName.Trim(), XmlWriteMode.WriteSchema);
                        dsVO.WriteXmlSchema(XsdFile.Trim());
                        return;
                    }
                }
                else
                {
                    ReportDocument rpt = new ReportDocument();
                    string ReportFile = "";
                    if (IsLieferung)
                    {
                        ReportFile = ENV.ReportPath + "\\" + "VOLieferungen.rpt";
                    }
                    else
                    {
                        ReportFile = ENV.ReportPath + "\\" + "VOBestellvorschläge.rpt";
                    }

                    if (!System.IO.File.Exists(ReportFile.Trim()))
                    {
                        string txtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Reportdatei '{0}' wurde nicht gefunden!" + "\r\n" + "Es kann kein Druck durchgeführt werden!");
                        txtMsgBox = string.Format(txtMsgBox, ReportFile.Trim());
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtMsgBox, "", MessageBoxButtons.OK, true);
                        return;
                    }

                    rpt.Load(ReportFile);
                    frmPrintPreview.LogOnCrystReport(rpt, null, true);       //   frmPrintPreview.LogOnCrystReport(rpt, dsVO.VO, true);

                    ReportManager.AddCrystalParameter(rpt, "IDKlinik", IDKlinik.ToString());
                    ReportManager.AddCrystalParameter(rpt, "IDAbteilung", Guid.Empty.ToString());
                    ReportManager.AddCrystalParameter(rpt, "IDVO", lstIDs.Trim());
                    if (dFrom is null)
                    {
                        ReportManager.AddCrystalParameter(rpt, "dFrom", DateTime.MinValue);
                    }
                    else
                    {
                        ReportManager.AddCrystalParameter(rpt, "dFrom", dFrom);
                    }
                    if (dTo is null)
                    {
                        ReportManager.AddCrystalParameter(rpt, "dTo", DateTime.MinValue);
                    }
                    else
                    {
                        ReportManager.AddCrystalParameter(rpt, "dTo", dTo);
                    }
                    ReportManager.AddCrystalParameter(rpt, "Type", lstTyp.Trim());
                    ReportManager.AddCrystalParameter(rpt, "UserLoggedOn", UserLoggedOn.Trim());

                    frmPrintPreview frm = new frmPrintPreview(rpt);
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ReportManager.PrintVOBestellvorschlägeLieferungen: " + ex.ToString());
            }
        }

    }
}
