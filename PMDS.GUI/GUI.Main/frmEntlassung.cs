//----------------------------------------------------------------------------
/// <summary>
///	frmEntlassung.cs
/// Erstellt am:	13.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.DB;
using System.Linq;
using System.Data.OleDb;

namespace PMDS.GUI
{

	public class frmEntlassung : frmBase
	{
		private bool _canClose = false;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucEntlassung ucEntlassung1;
        private Infragistics.Win.Misc.UltraLabel lblWarning;
        private Infragistics.Win.Misc.UltraLabel lblKlientenWirklichEntlassen;
		private System.ComponentModel.IContainer components;


        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

        public ucMain mainWindow = null;







        public frmEntlassung(Patient patient)
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            labInfo.Text = string.Format(labInfo.Text, patient.FullInfo);

            this.ucEntlassung1.cbEinrichtung.RefreshList();
			patient.Aufenthalt.Entlassung(ENV.USERID);
			ucEntlassung1.Aufenthalt = patient.Aufenthalt;

		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntlassung));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Aufenthalt aufenthalt1 = new PMDS.BusinessLogic.Aufenthalt();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucEntlassung1 = new PMDS.GUI.ucEntlassung();
            this.lblWarning = new Infragistics.Win.Misc.UltraLabel();
            this.lblKlientenWirklichEntlassen = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(764, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Entlassung von {0}";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(664, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(664, 408);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucEntlassung1
            // 
            this.ucEntlassung1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            aufenthalt1.AufnahmeArt = 0;
            aufenthalt1.Aufnahmezeitpunkt = new System.DateTime(2008, 11, 27, 15, 20, 48, 732);
            aufenthalt1.Ausgleichszahlung = 0D;
            aufenthalt1.BegleitungVon = "";
            aufenthalt1.Bermerkung = "";
            aufenthalt1.Besuchsregelung = "";
            aufenthalt1.Entlassungsbemerkung = "";
            aufenthalt1.Entlassungszeitpunkt = null;
            aufenthalt1.Erwartungen = "";
            aufenthalt1.Fallnummer = 0D;
            aufenthalt1.Gewicht = 0D;
            aufenthalt1.Gruppenkennzahl = "";
            aufenthalt1.ID = new System.Guid("f1788b26-4378-4a20-b93f-3d0e279aec91");
            aufenthalt1.IDAbteilung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDAufenthaltVerlauf = new System.Guid("9106df53-c041-4144-be25-5db1372953fd");
            aufenthalt1.IDBenutzer_Aufnahme = new System.Guid("00000000-0000-0000-0000-000001000000");
            aufenthalt1.IDBenutzer_Entlassung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDBereich = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDEinrichtung_Aufnahme = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDEinrichtung_Entlassung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDErstkontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDKlinik = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDPatient = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDUrlaub = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.NaechsteEvaluierung = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.NaechsteEvaluierungBemerkung = "";
            aufenthalt1.Postregelung = "";
            aufenthalt1.PsychischeAuff = "";
            aufenthalt1.SofortMassnahmen = "";
            aufenthalt1.SomatischeAuff = "";
            aufenthalt1.SonstigeBesonderheiten = "";
            aufenthalt1.SonstigeRegelung = "";
            aufenthalt1.TaschegeldVortragDatum = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.TaschengeldSollstand = 0D;
            aufenthalt1.TaschengeldVortragBetrag = 0D;
            aufenthalt1.Verfuegungsdatum = null;
            aufenthalt1.VerhaltenAufnahme = "";
            this.ucEntlassung1.Aufenthalt = aufenthalt1;
            this.ucEntlassung1.Location = new System.Drawing.Point(0, 48);
            this.ucEntlassung1.Name = "ucEntlassung1";
            this.ucEntlassung1.ReadOnly = false;
            this.ucEntlassung1.Size = new System.Drawing.Size(766, 313);
            this.ucEntlassung1.TabIndex = 4;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BackColor = System.Drawing.Color.Red;
            appearance4.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Appearance = appearance4;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(12, 367);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(501, 35);
            this.lblWarning.TabIndex = 5;
            this.lblWarning.Text = "Dies ist der Dialog für die Entlassung. Wenn Sie bloß eine Abwesenheit erfassen w" +
    "ollen (z.B. einen Krankenhausaufenthalt), klicken Sie bitte auf Abbrechen.";
            // 
            // lblKlientenWirklichEntlassen
            // 
            this.lblKlientenWirklichEntlassen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.lblKlientenWirklichEntlassen.Appearance = appearance5;
            this.lblKlientenWirklichEntlassen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlientenWirklichEntlassen.Location = new System.Drawing.Point(12, 408);
            this.lblKlientenWirklichEntlassen.Name = "lblKlientenWirklichEntlassen";
            this.lblKlientenWirklichEntlassen.Size = new System.Drawing.Size(501, 32);
            this.lblKlientenWirklichEntlassen.TabIndex = 6;
            this.lblKlientenWirklichEntlassen.Text = "Nur wenn Sie den Klienten wirklich entlassen wollen (z.B. verstorben oder ausgezo" +
    "gen), klicken Sie auf OK.";
            // 
            // frmEntlassung
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(764, 460);
            this.Controls.Add(this.lblKlientenWirklichEntlassen);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.ucEntlassung1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntlassung";
            this.Text = "Entlassung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmEntlassung_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{

            string NachNameSecure = "";
            string Nachname = "";
            Guid IDKlient = Guid.Empty;

            NachNameSecure = Microsoft.VisualBasic.Interaction.InputBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie den Nachnamen ein: "), QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten entlassen. Sicherheitsabfrage!"), "");

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(o => o.ID == ucEntlassung1.Aufenthalt.IDPatient);
                PMDS.db.Entities.Patient rPatient = tPatient.First();
                IDKlient = rPatient.ID;
                Nachname = rPatient.Nachname;
                if (! NachNameSecure.Equals(Nachname, StringComparison.CurrentCultureIgnoreCase))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der von Ihnen eingebene Nachname '") + NachNameSecure + QS2.Desktop.ControlManagment.ControlManagment.getRes("' unterscheidet sich vom Nachnamen des zu entlassenden Klienten '") + rPatient.Nachname + QS2.Desktop.ControlManagment.ControlManagment.getRes("'. Bitte geben Sie den richtigen Nachnamen ein."), true);
                    return;                    
                }

                System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.ID == ucEntlassung1.Aufenthalt.ID);
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                if (ucEntlassung1.dtpDatum.DateTime < rAufenthalt.Aufnahmezeitpunkt)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Entlassungszeitpunkt darf nicht vor dem Aufnahmezeitpunkt liegen.", "PMDS", MessageBoxButtons.OK);
                    return;
                }


            }

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                System.Linq.IQueryable<PMDS.db.Entities.Unterbringung> tUnterbringung = this.PMDSBusiness1.checkOpenHAGMeldungenExists(IDKlient, db);
                if (tUnterbringung.Count() > 0)
                {
                    DialogResult resHAG = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es existieren offenen HAG Meldungen für diesen Klienten. Möchten Sie diese beenden?", "", MessageBoxButtons.YesNo);
                    if (resHAG == DialogResult.Yes)
                    {
                        _canClose = true;
                        this.Close();
                        if (this.mainWindow != null)
                        {
                            this.mainWindow.loadKlientenStammdaten();
                        }
                        return;
                    }
                }
            }


            if (!ucEntlassung1.ValidateFields())
			return;

			ucEntlassung1.UpdateDATA();
            
            PatientBewerber bewerber = new PatientBewerber();
            dsPatientBewerber.PatientRow row = bewerber.ReadByID(ucEntlassung1.Aufenthalt.IDPatient);

            DialogResult res = DialogResult.No;
            if (row != null &&  !row.IsBewerbungaktivJNNull() && row.BewerbungaktivJN)
            {
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Bewerbungsdaten zurückgesetzt werden?", "Klient ist aktiver Bewerber", MessageBoxButtons.YesNo);
            }

			Guid idAuf		= ucEntlassung1.Aufenthalt.ID;
			DateTime dtEnd	= ucEntlassung1.Aufenthalt.Verlauf.Datum;
            
            DateTime DatEntlassung = this.ucEntlassung1.dtpDatum.DateTime;
            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();   //lthok
            string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung (") + ucEntlassung1.cbEinrichtung.Text + "): " + ucEntlassung1.txtBemerkung.Text.Trim();
            PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(ucEntlassung1.Aufenthalt.IDPatient, ucEntlassung1.Aufenthalt.ID, DatEntlassung, ENV.IDKlinik);
            PMDS.Calc.Admin.DB.DBPatientKostentraeger dbPatKost = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
            if (dbPatKost.gültigBisAufEntl_alleLeistKost(ucEntlassung1.Aufenthalt.IDPatient, (DateTime )ucEntlassung1.Aufenthalt.Entlassungszeitpunkt ))
            {
                ucEntlassung1.Aufenthalt.Write();

                if (res == DialogResult.Yes)
                {
                    bewerber.InitBewerbungsdaten(row);
                    bewerber.Write();
                }
            }

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(o => o.ID == ucEntlassung1.Aufenthalt.IDPatient);
                PMDS.db.Entities.Patient rPatient = tPatient.First();
                rPatient.Verstorben = this.ucEntlassung1.chkVerstorben.Checked;

                //-- Pflegeeintrag schreiben
                sText += QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rEntlassungsstatus ist ") + (ucEntlassung1.chkVerstorben.Checked ? QS2.Desktop.ControlManagment.ControlManagment.getRes("verstorben ") : QS2.Desktop.ControlManagment.ControlManagment.getRes("lebend"));

                if (this.ucEntlassung1.chkVerstorben.Checked && this.ucEntlassung1.uceTodeszeitpunkt.Value != null)
                {
                    rPatient.Verstorben = true;
                    rPatient.Todeszeitpunkt = this.ucEntlassung1.uceTodeszeitpunkt.DateTime;
                    sText += QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rTodeszeitpunkt = ") + this.ucEntlassung1.uceTodeszeitpunkt.DateTime.ToString("dd.MM.yyyy HH:mm");
                    
                }
                else
                {
                    rPatient.Verstorben = false;
                    rPatient.Todeszeitpunkt = null;
                }
                db.SaveChanges();

                bool offeneTermineExists = PMDSBusiness1.checkOffeneTerminePatient(ucEntlassung1.Aufenthalt.IDPatient, ucEntlassung1.dtpDatum.DateTime, db);
                if (offeneTermineExists)
                {
                    DialogResult res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ex existieren offene Termine für den Klienten!" + "\r\n" + 
                                                                                    "Sollen diese beendet werden?", "Klient ist aktiver Bewerber", MessageBoxButtons.YesNo);
                    if (res2 == DialogResult.Yes)
                    {
                        PMDSBusiness1.updateOpendPlansPatient(ucEntlassung1.Aufenthalt.IDPatient, ucEntlassung1.dtpDatum.DateTime, db, true);
                    }
                }

                PMDSBusiness1.checkVOAndUpdate(ucEntlassung1.Aufenthalt.ID, ucEntlassung1.dtpDatum.DateTime, db);
            }
            //Entlassungs-Dekurs schreiben
            PMDSBusiness1.EntlassungWriteDekurs(ucEntlassung1.Aufenthalt.ID, ucEntlassung1.Aufenthalt.IDAbteilung, ucEntlassung1.Aufenthalt.IDBereich,
                                                    ENV.IDKlinik, DatEntlassung, sText);

            //Protokoll schreiben
            string strProtokoll = "";
            strProtokoll = QS2.Desktop.ControlManagment.ControlManagment.getRes("IDKlient: ") + IDKlient.ToString() + "\n\r";
            strProtokoll += QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname aus DB: ") + Nachname + "\n\r";
            strProtokoll += QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname eingegeben: ") + NachNameSecure;
            
            qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
            qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
            sqlProtocoll.initControl();
            string CmdReturn = "";
            sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

            qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
            rNewProt.Type = "Entlassung";
            rNewProt.IDApplication = "PMDS";
            PMDS.BusinessLogic.Benutzer ben = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
            rNewProt.Created = DateTime.Now;
            rNewProt.User = ben.FullName;
            rNewProt.Info = QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung Klient");
            rNewProt.Protocol = strProtokoll;
            rNewProt.IDGuid = System.Guid.NewGuid();

            sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.DB.PMDSBusinessComm.newCommAsyncToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll, db);
            }

            _canClose = true;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

        private void frmEntlassung_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }

	}
}
