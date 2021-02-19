//----------------------------------------------------------------------------
/// <summary>
///	frmPrintPreview.cs
/// Erstellt am:	18.1.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.BusinessLogic;
using PMDS.GUI;
using PMDS.Print.DB;

using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Specialized;
using CrystalDecisions.Shared;
using PMDS.Global.db.Global;




namespace PMDS.Print
{


	public class frmPrintPreview : frmBase
	{

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.ComponentModel.Container components = null;

        public enum eTypReportMedikamenteBestellen
        {
            Rezeptanforderungsliste = 0,
            RezeptDrucken = 1,
            Medikamentenbestellliste = 2
        }




		 	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            //this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(925, 695);
            this.crystalReportViewer1.TabIndex = 0;
            //this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmPrintPreview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 695);
            this.Controls.Add(this.crystalReportViewer1);
            this.MinimumSize = new System.Drawing.Size(328, 352);
            this.Name = "frmPrintPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bericht PMDS";
            this.Load += new System.EventHandler(this.frmPrintPreview_Load);
            this.ResumeLayout(false);

		}
		#endregion
        public frmPrintPreview(ReportDocument rpt)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            crystalReportViewer1.ReportSource = rpt;
        }
       

		public static bool PreviewPflegerKarte(string Barcode, string Name, string KlinikName, string Klinikadresse) 
		{
			ReportDocument d = ReportManager.GetPflegerKarteReport(Barcode, Name, KlinikName, Klinikadresse);
			frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
			return true;
		}
        
        private static void ExportToPDF(ReportDocument d, string file)
        {
            //creating new instance representing disk file destination 
            //options such as filename, export type etc.
            CrystalDecisions.Shared.DiskFileDestinationOptions crDiskFileDestinationOptions =
             new CrystalDecisions.Shared.DiskFileDestinationOptions();
            CrystalDecisions.Shared.ExportOptions crExportOptions = d.ExportOptions;

            crDiskFileDestinationOptions.DiskFileName = file;
            crExportOptions.DestinationOptions =
             crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType =
             CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType =
             CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            
            //frmPrintPreview.setLogOnCR(d);
            d.Export();
        }

        public static bool LogOnCrystReport(ReportDocument ReportDocument1, DataTable dt, bool SetDataTableSourceToSubreports)
        {
            try
            {
                TableLogOnInfo info = new TableLogOnInfo();
                info.ConnectionInfo.DatabaseName = ENV.DB_DATABASE;
                info.ConnectionInfo.ServerName = ENV.DB_SERVER;

                if (ENV.DB_USER != null)
                {
                    info.ConnectionInfo.UserID = ENV.DB_USER;
                    info.ConnectionInfo.Password = ENV.DB_PASSWORD;
                }
                else
                {
                    info.ConnectionInfo.IntegratedSecurity = true;
                    info.ConnectionInfo.Password = string.Empty;
                    info.ConnectionInfo.UserID = string.Empty;
                }

                info.ConnectionInfo.ServerName = qs2.core.ENV.server;

                foreach (Table t in ReportDocument1.Database.Tables)
                {
                    t.ApplyLogOnInfo(info);
                }

                if (dt != null)
                    ReportDocument1.SetDataSource(dt);

                foreach (Section s in ReportDocument1.ReportDefinition.Sections)
                {
                    foreach (ReportObject o in s.ReportObjects)
                    {
                        if (o.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject so = (SubreportObject)o;
                            ReportDocument doc = so.OpenSubreport(so.SubreportName);
                            foreach (Table t in doc.Database.Tables)
                            {
                                t.ApplyLogOnInfo(info);
                            }
                            if (SetDataTableSourceToSubreports)
                            {
                                if (dt != null)
                                {
                                    doc.SetDataSource(dt);
                                }
                            }

                        }
                    }
                }
                //if (info.ConnectionInfo.IntegratedSecurity == true)
                //    ReportDocument1.SetDatabaseLogon(string.Empty, string.Empty, qs2.core.ENV.server, qs2.core.ENV.db);

                //else
                //    ReportDocument1.SetDatabaseLogon(qs2.core.ENV.userDb, qs2.core.ENV.pwdDbDecrypted, qs2.core.ENV.server, qs2.core.ENV.db);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.LogOnCrystReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


        public static bool PreviewManBuchungen(PMDS.Global.db.Global.ds_abrechnung.dsManBuch ds, string klient, PMDS.Calc.Logic.eCalcRun typ)
        {
            if (ds.manBuch .Count == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                                ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning, true);
                return false;
            }

            ReportDocument d = ReportManager.GetManBuchungen(ds);
            d.SetParameterValue("Klient", klient);
            d.SetParameterValue("MwSt", true);
            d.SetParameterValue("typ", (int)typ);

            frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
            return true;
        }


        public static bool PreviewTaschengeld(PMDS.Global.db.Global.ds_abrechnung.dsPrintTaschengeld ds, decimal saldo)
        {
            if (ds.Taschengeld.Count == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                                ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning, true);
                return false;
            }

            ReportDocument d = ReportManager.GetTaschengeldReport(ds);
            d.SetParameterValue("saldo", saldo);

            frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
            return true;
        }

  
        private static TextObject FindTextobject(ReportDocument rInfo, string sKey)
        {
            foreach (Section s in rInfo.ReportDefinition.Sections)
            {
                foreach (ReportObject o in s.ReportObjects)
                {
                    if (o is TextObject)
                    {
                        TextObject t = (TextObject)o;
                        if (t.Name == sKey)
                            return t;
                    }
                }
            }
            return null;
        }

        public static bool PreviewTerminliste(ref PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable dt, TerminlisteAnsichtsmodi Ansichtsinfo, eUITypeTermine UITypeTermine, bool ShowVitalzeichenJN)
		{
            return PreviewTerminliste(ref dt, false, Ansichtsinfo, UITypeTermine, ShowVitalzeichenJN);
		}

        private static bool PreviewTerminliste(ref PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable dt, bool bShowAbw, TerminlisteAnsichtsmodi Ansichtsinfo, eUITypeTermine UITypeTermine, bool ShowVitalzeichenJN)
		{
			if (dt.Rows.Count == 0)
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"), 
					                                                        ENV.String("REPORT.DIALOGTITLE_NO_DATA"), 
					                                                        MessageBoxButtons.OK, true);
				return false;
			}

			dsAuswahlGruppe.AuswahlListeDataTable t = new AuswahlGruppe("BER").AuswahlListe;
            ReportDocument d = ReportManager.GetTerminliste(dt, t, Ansichtsinfo, UITypeTermine);
            d.SetParameterValue("ShowVitalzeichenJN", ShowVitalzeichenJN);

			frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
			return true;
		}

        public static bool PrintBestellungMedikamente(ref DataTable tBestellungMedikamente,
                                                        Nullable<DateTime> dFrom, Nullable<DateTime> dTo,
                                                        Guid IDKlinik, Nullable<Guid> IDAbteilung,
                                                        ref frmPrintPreview frm, eTypReportMedikamenteBestellen TypReportMedikamenteBestellen)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();
                //case "BestellungMedikamente": return "BestellungMedikamente.rpt";
                //case "AnforderungRezepte": return "AnforderungRezepte.rpt";
                //case "DruckRezepte": return "DruckRezepte.rpt";

                string sFileReport = "";
                if (TypReportMedikamenteBestellen == eTypReportMedikamenteBestellen.Rezeptanforderungsliste)
                {
                    sFileReport = ENV.GetReportFileNameFromConfig("AnforderungRezepte");
                    rpt.Load(sFileReport);
                }
                else if (TypReportMedikamenteBestellen == eTypReportMedikamenteBestellen.RezeptDrucken)
                {
                    sFileReport = ENV.GetReportFileNameFromConfig("DruckRezepte");
                    rpt.Load(sFileReport);
                }
                else if (TypReportMedikamenteBestellen == eTypReportMedikamenteBestellen.Medikamentenbestellliste)
                {
                    sFileReport = ENV.GetReportFileNameFromConfig("BestellungMedikamente");
                    rpt.Load(sFileReport);
                }

                frmPrintPreview.LogOnCrystReport(rpt, tBestellungMedikamente, false);
                //PMDS.Print.CR.ReportManager.setDataSource(tBestellungMedikamente, sFileReport, rpt);

                rpt.SetParameterValue("IDKlinik", IDKlinik.ToString());
                rpt.SetParameterValue("IDAbteilung", IDAbteilung.ToString());

                frm = new frmPrintPreview(rpt);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PrintBestellungMedikamente: " + ex.ToString());
            }
        }
		private static void ReportZusatzWerte(dsRepZusatzWert.ZusatzWertDataTable zusatz, Guid id)
		{
			// Zusatzwerte ermitteln
			PflegeEintrag	pe;
			ZusatzWert		zwDefault;
			ZusatzWert		zwENVAbt;

			pe = new PflegeEintrag(id);
			ZusatzWert.AllZusatzWerte((IZusatz)pe, out zwDefault, out zwENVAbt);

			// generelle/Abteilungsspez Werte setzen
			AddReportZusatzWert(zusatz, ENV.String("INFO_ALL_ABTEILUNG"), id, zwDefault);
			AddReportZusatzWert(zusatz, ENV.String("INFO_CUR_ABTEILUNG"), id, zwENVAbt);
		}

		private static void AddReportZusatzWert(
			dsRepZusatzWert.ZusatzWertDataTable zusatz,
			string info,
			Guid idPflegeEintrag,
			ZusatzWert werte)
		{
			// alle Werte (nur druckbare) eintragen
			foreach(ZusatzWertPara para in werte.PrintableValues())
			{
				if (para.IsPrintable)
					zusatz.AddZusatzWertRow(idPflegeEintrag, info, para.Bezeichnung, para.Value);
			}
		}

       
        public static bool PreviewMedikamentenAusgabe(dsMedikationVonBis.MedikationDataTable dt)
        {
            if (dt.Count == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                                            ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                                            MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning, true);
                return false;
            }

            ReportDocument d = ReportManager.GetMedikamentenAusgabe(dt);
           
            frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
            return true;
        }
        public static bool PreviewMedikamentenBlatt(dsRezeptEintrag.RezeptEintragDataTable dt, Guid IDAufenthalt)
        {
            if (dt.Count == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                                            ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                                            MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning, true);
                return false;
            }


            ReportDocument d = ReportManager.GetMedikamentenBlatt(dt, IDAufenthalt, false);
            frmPrintPreview frm = new frmPrintPreview(d);
            frm.Show();
            return true;
        }

        public static bool PrintBewerberliste(dsPatientBewerber.PatientDataTable dt)
        {
            if (dt.Count == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                        ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Warning, true);
                return false;
            }

            ReportDocument d = ReportManager.GetBewerberliste(dt);

            frmPrintPreview frm = new frmPrintPreview(d);
            frm.ShowDialog();
            return true;
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Berichte, 32, 32);
        }


	}
}
