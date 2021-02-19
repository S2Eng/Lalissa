using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using UWG = Infragistics.Win.UltraWinGrid;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using System.Linq;
using PMDS.GUI.Datenerhebung;

namespace PMDS.GUI
{

    public class frmPatientRueckmeldung : QS2.Desktop.ControlManagment.baseForm 
	{

		private bool						_bMorgenWieder = false;
		private Guid						_IDPflegePlan;
		private Patient						_pat;

        private bool                        _editinprogress = false;
        public bool EintragDeleted = false;
        

		private string _text = "";
		private bool _finish = false;
        protected QS2.Desktop.ControlManagment.BaseGroupBoxWin grpDokumentation;
        public ucPflegeEintragEx ucPflegeEintrag1;
        protected QS2.Desktop.ControlManagment.BasePanel panelCenter;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo1;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo2;
        public QS2.Desktop.ControlManagment.BaseButton btnMorgenwieder;
        private QS2.Desktop.ControlManagment.BaseButton btnDelete;
        public QS2.Desktop.ControlManagment.BaseButton btnOK2;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel2;
        public QS2.Desktop.ControlManagment.BaseButton btnEdit2;
        private QS2.Desktop.ControlManagment.BaseButton btnSonderterminErstellen2;
		private System.ComponentModel.IContainer components;
        internal Infragistics.Win.Misc.UltraButton btnOpenBefund;

        public bool abort = true;

        public Nullable<Guid> IDBefund = System.Guid.Empty;
        private QS2.Desktop.ControlManagment.BaseButton btnFormulare;
        public PMDSBusiness b = new PMDSBusiness();







		public frmPatientRueckmeldung()
		{
			InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

		public frmPatientRueckmeldung(Patient pat, PflegeEintrag pe, string text, 
			                            bool bFinish, bool RMOptional, bool bEditT, bool RMDatumAufHeuteSetzen, 
                                        bool MOhneZeitbezug, bool IsBefund) : this(pat,pe, text, bFinish, RMOptional, bEditT)
		{
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            if (IsBefund)
                ucPflegeEintrag1.SetZeitpunktDerRueckmeldungAufJetzt();

			if(RMDatumAufHeuteSetzen)
				ucPflegeEintrag1.SetZeitpunktDerRueckmeldungAufHeute();

            if (MOhneZeitbezug)
            {
                ucPflegeEintrag1.ProcessMOhneZeitbezug();
                btnMorgenwieder.Visible = false;
            }

            if (pe.EintragsTyp == PflegeEintragTyp.MASSNAHME)
            {
                this.showHideButtonFormulare(pe.IDEintrag);
            }
        }

		public frmPatientRueckmeldung(Patient pat, PflegeEintrag pe, string text, 
									bool bFinish, bool RMOptional, bool bEditT)
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            _pat = pat;
			_IDPflegePlan = pe.IDPflegePlan;
			

			_finish		= bFinish;
			_text		= text;

			labInfo1.Text						= string.Format(labInfo1.Text, text);
			labInfo2.Text						= string.Format(labInfo2.Text, pat.FullInfo);
			ucPflegeEintrag1.Eintrag			= pe;
			ucPflegeEintrag1.RM_OPTIONAL		= RMOptional;
			ucPflegeEintrag1.EnableEditTime		= bEditT;

            this.btnDelete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
            this.ucPflegeEintrag1.btnDelete = this.btnDelete;

            if (pe.EintragsTyp == PflegeEintragTyp.MASSNAHME)
            {
                this.showHideButtonFormulare(pe.IDEintrag);
            }
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.labInfo1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.grpDokumentation = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucPflegeEintrag1 = new PMDS.GUI.ucPflegeEintragEx();
            this.panelCenter = new QS2.Desktop.ControlManagment.BasePanel();
            this.labInfo2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnMorgenwieder = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelete = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnEdit2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSonderterminErstellen2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOpenBefund = new Infragistics.Win.Misc.UltraButton();
            this.btnFormulare = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpDokumentation.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo1
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo1.Appearance = appearance1;
            this.labInfo1.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo1.Location = new System.Drawing.Point(0, 0);
            this.labInfo1.Name = "labInfo1";
            this.labInfo1.Size = new System.Drawing.Size(1134, 49);
            this.labInfo1.TabIndex = 0;
            this.labInfo1.Text = "{0}";
            // 
            // grpDokumentation
            // 
            this.grpDokumentation.Controls.Add(this.ucPflegeEintrag1);
            this.grpDokumentation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDokumentation.Location = new System.Drawing.Point(0, 0);
            this.grpDokumentation.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.grpDokumentation.Name = "grpDokumentation";
            this.grpDokumentation.Size = new System.Drawing.Size(1120, 537);
            this.grpDokumentation.TabIndex = 0;
            this.grpDokumentation.TabStop = false;
            this.grpDokumentation.Text = "Dokumentation";
            // 
            // ucPflegeEintrag1
            // 
            this.ucPflegeEintrag1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegeEintrag1.EnableEditTime = true;
            this.ucPflegeEintrag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucPflegeEintrag1.Location = new System.Drawing.Point(8, 24);
            this.ucPflegeEintrag1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPflegeEintrag1.Medikation = false;
            this.ucPflegeEintrag1.Name = "ucPflegeEintrag1";
            this.ucPflegeEintrag1.ReadOnly = false;
            this.ucPflegeEintrag1.RM_OPTIONAL = false;
            this.ucPflegeEintrag1.Size = new System.Drawing.Size(1104, 504);
            this.ucPflegeEintrag1.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCenter.Controls.Add(this.grpDokumentation);
            this.panelCenter.Location = new System.Drawing.Point(8, 72);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1120, 537);
            this.panelCenter.TabIndex = 5;
            // 
            // labInfo2
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.labInfo2.Appearance = appearance2;
            this.labInfo2.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo2.Location = new System.Drawing.Point(0, 49);
            this.labInfo2.Name = "labInfo2";
            this.labInfo2.Size = new System.Drawing.Size(1134, 25);
            this.labInfo2.TabIndex = 6;
            this.labInfo2.Text = "für {0}";
            // 
            // btnMorgenwieder
            // 
            this.btnMorgenwieder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMorgenwieder.AutoWorkLayout = false;
            this.btnMorgenwieder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMorgenwieder.IsStandardControl = false;
            this.btnMorgenwieder.Location = new System.Drawing.Point(838, 615);
            this.btnMorgenwieder.Name = "btnMorgenwieder";
            this.btnMorgenwieder.Size = new System.Drawing.Size(94, 33);
            this.btnMorgenwieder.TabIndex = 101;
            this.btnMorgenwieder.Text = "Morgen wieder";
            this.btnMorgenwieder.Click += new System.EventHandler(this.btnMorgenwieder_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.IsStandardControl = false;
            this.btnDelete.Location = new System.Drawing.Point(748, 615);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 33);
            this.btnDelete.TabIndex = 104;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK2
            // 
            this.btnOK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK2.Appearance = appearance3;
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(1035, 615);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(90, 33);
            this.btnOK2.TabIndex = 106;
            this.btnOK2.Text = "OK";
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.AutoWorkLayout = false;
            this.btnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel2.IsStandardControl = false;
            this.btnCancel2.Location = new System.Drawing.Point(938, 615);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(94, 33);
            this.btnCancel2.TabIndex = 105;
            this.btnCancel2.Text = "Abbrechen";
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnEdit2
            // 
            this.btnEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnEdit2.Appearance = appearance4;
            this.btnEdit2.AutoWorkLayout = false;
            this.btnEdit2.IsStandardControl = false;
            this.btnEdit2.Location = new System.Drawing.Point(677, 615);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(92, 33);
            this.btnEdit2.TabIndex = 107;
            this.btnEdit2.Text = "&Bearbeiten";
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // btnSonderterminErstellen2
            // 
            this.btnSonderterminErstellen2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSonderterminErstellen2.Appearance = appearance5;
            this.btnSonderterminErstellen2.AutoWorkLayout = false;
            this.btnSonderterminErstellen2.IsStandardControl = false;
            this.btnSonderterminErstellen2.Location = new System.Drawing.Point(16, 615);
            this.btnSonderterminErstellen2.Name = "btnSonderterminErstellen2";
            this.btnSonderterminErstellen2.Size = new System.Drawing.Size(108, 33);
            this.btnSonderterminErstellen2.TabIndex = 108;
            this.btnSonderterminErstellen2.Text = "Termin erstellen";
            this.btnSonderterminErstellen2.Click += new System.EventHandler(this.btnSonderterminErstellen2_Click);
            // 
            // btnOpenBefund
            // 
            this.btnOpenBefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance6.BorderColor = System.Drawing.Color.Black;
            this.btnOpenBefund.Appearance = appearance6;
            this.btnOpenBefund.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenBefund.Location = new System.Drawing.Point(126, 615);
            this.btnOpenBefund.Name = "btnOpenBefund";
            this.btnOpenBefund.Size = new System.Drawing.Size(59, 33);
            this.btnOpenBefund.TabIndex = 109;
            this.btnOpenBefund.Tag = "";
            this.btnOpenBefund.Text = "Befund";
            this.btnOpenBefund.Visible = false;
            this.btnOpenBefund.Click += new System.EventHandler(this.btnOpenBefund_Click);
            // 
            // btnFormulare
            // 
            this.btnFormulare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnFormulare.Appearance = appearance7;
            this.btnFormulare.AutoWorkLayout = false;
            this.btnFormulare.IsStandardControl = false;
            this.btnFormulare.Location = new System.Drawing.Point(187, 615);
            this.btnFormulare.Name = "btnFormulare";
            this.btnFormulare.Size = new System.Drawing.Size(86, 33);
            this.btnFormulare.TabIndex = 110;
            this.btnFormulare.Text = "Assessments";
            this.btnFormulare.Visible = false;
            this.btnFormulare.Click += new System.EventHandler(this.btnFormulare_Click);
            // 
            // frmPatientRueckmeldung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel2;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.btnFormulare);
            this.Controls.Add(this.btnOpenBefund);
            this.Controls.Add(this.btnSonderterminErstellen2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnMorgenwieder);
            this.Controls.Add(this.labInfo2);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.labInfo1);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.btnEdit2);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "frmPatientRueckmeldung";
            this.ShowInTaskbar = false;
            this.Text = "Dokumentation ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientRueckmeldung_Load);
            this.grpDokumentation.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

        private void ProcessOK(bool bMorgenWieder)
        {
            bool bFinish = false;								// Flag zum rücksetzen von morgen wieder
            try
            {
                if (!ReadOnly)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.PflegePlan rPflegePlan = db.PflegePlan.Where(pe => pe.ID == this._IDPflegePlan).First();
                        if ((rPflegePlan.RMOptionalJN && this.ucPflegeEintrag1.contTXTFieldBeschreibung.TXTControlField.Text.Trim() != "") || !rPflegePlan.RMOptionalJN)
                        {
                            if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkTxtRegex(this.ucPflegeEintrag1.contTXTFieldBeschreibung.TXTControlField.Text, true))
                            {
                                return;
                            }
                        }
                    }

                    if (!ucPflegeEintrag1.ValidateFields())
                        return;

                    ucPflegeEintrag1.UpdateDATA();

                    DateTime NächstesDatum = DateTime.MinValue;
                    Guid IDGruppe = System.Guid.NewGuid();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        ucPflegeEintrag1.Write();       // Änderungen speichern inkl. Zusatzwerte

                        PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();    
                        PMDS.db.Entities.PflegePlan rPflegeplan = null;
                        b.UpdatePflegePlanBeiRückmeldung(this._IDPflegePlan, db, ref  NächstesDatum, rPflegeplan, bMorgenWieder, this.ucPflegeEintrag1.Eintrag.Zeitpunkt, true);

                        IQueryable<PMDS.db.Entities.PflegeEintrag> lstPEorig = db.PflegeEintrag.Where(pe => pe.ID == this.ucPflegeEintrag1.Eintrag.ID);
                        PMDS.db.Entities.PflegeEintrag rPEeOriginal = lstPEorig.First();
                        rPEeOriginal.IDGruppe = IDGruppe;
                        db.SaveChanges();
                        
                        System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                        this.ucPflegeEintrag1.auswahlGruppeComboMulti1.AddCC2(this.ucPflegeEintrag1.Eintrag.ID, this.ucPflegeEintrag1.IsNew,
                                                                                this.ucPflegeEintrag1.chkAlsDekursKopieren.Checked, this.ucPflegeEintrag1.Eintrag.AbzeichnenJN,
                                                                                this.ucPflegeEintrag1.Eintrag.IDWichtig, ref lstPEToCopy, false, ref IDGruppe);

                        if (ENV.HasRight(UserRights.AutomatischeArztabrechungseinträge))
                        {
                            int iCounterArtzabrechnungen = 0;
                            PMDS.db.Entities.Aufenthalt rAufenthalt = b.getAufenthalt(rPEeOriginal.IDAufenthalt);
                            if (rAufenthalt != null)
                            {
                                DateTime dNow = DateTime.Now;
                                string ProtocolHeader = "Termin ID " + rPEeOriginal.ID.ToString() + ", Zeitpunkt: " + rPEeOriginal.Zeitpunkt.ToString();
                                if (b.doArztabrechnungen(db, (Guid)rAufenthalt.IDPatient, dNow, ref iCounterArtzabrechnungen, (Guid)rPEeOriginal.IDBenutzer, ProtocolHeader))
                                {
                                    db.SaveChanges();
                                }
                            }
                        }

                    }


                    //using (PMDS.db.Entities.ERModellPMDSEntities dbZW = PMDS.DB.PMDSBusiness.getDBContext())
                    //{
                    //    this.b.copyUpdateZusatzwertePEIDGruppe(this.ucPflegeEintrag1.Eintrag.ID, dbZW);
                    //}






                }
                bFinish = true;
                this.abort = false;
                this.Close();

            }
            finally
            {
                if (!bFinish)
                    _bMorgenWieder = false;
            }
        }


        public bool ReadOnly
		{
			get	
            {	
                return ucPflegeEintrag1.ReadOnly;
            }
			set	
			{	
				ucPflegeEintrag1.ReadOnly	= value;	
				btnOK2.Visible				= !value;
				btnMorgenwieder.Visible		= !value;
			}
		}

        private void frmPatientRueckmeldung_Load(object sender, EventArgs e)
        {
            this.ucPflegeEintrag1.frmPatientRueckmeldung1 = this;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table , 32, 32);

            this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            this.btnCancel2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
        }

        private void btnMorgenwieder_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ProcessOK(true);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void SonderterminErstellen()
        {
            try
            {
                ucSiteMapTermine ucSiteMap = null;
                GuiAction.InsertTermin(ucPflegeEintrag1.Eintrag.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, ucSiteMap, ucPflegeEintrag1.Eintrag.ID, null);
                
            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientRueckmeldung.SonderterminErstellen: " + ex.ToString());
            }
        }
        public void showHideButtonFormulare(Guid IDEintrag)
        {
            try
            {
                Control[] controls = Controls.Find("btnFormulare", true);
                if (controls.Length > 0)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var rEintrag = (from e in db.Eintrag
                                        where e.ID == IDEintrag
                                        select new
                                        {
                                            IDEintrag = e.ID,
                                            lstFormulare = e.lstFormulare
                                        }).First();
                        this.btnFormulare.Visible = rEintrag.lstFormulare.Trim() != "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientRueckmeldung.showHideButtonFormulare: " + ex.ToString());
            }
        }
        public void openFormulare()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rEintrag = (from e in db.Eintrag
                                    where e.ID == this.ucPflegeEintrag1.Eintrag.IDEintrag
                                    select new
                                    {
                                        IDEintrag = e.ID,
                                        lstFormulare = e.lstFormulare
                                    }).First();

                    frmDatenErhebung frmDatenErhebung1 = new frmDatenErhebung();
                    frmDatenErhebung1.initControl(rEintrag.lstFormulare.Trim());
                    frmDatenErhebung1.Show();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientRueckmeldung.openFormulare: " + ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDSBusiness();

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Eintrag wirklich löschen?", "Eintrag löschen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (PMDSBusiness1.DeletePflegeeintrag(this.ucPflegeEintrag1.Eintrag.ID))
                    {
                        int iCounter = 0;
                        string prot = "";
                        PMDS.DB.PMDSBusiness.eModeUpdateNächstesDatum ModeUpdateNächstesDatum = PMDSBusiness.eModeUpdateNächstesDatum.IDPflegeplan;
                        PMDSBusiness1.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb(ref iCounter, ref prot, null, ref ModeUpdateNächstesDatum,
                                                    this.ucPflegeEintrag1.Eintrag.IDPflegePlan);

                        this.EintragDeleted = true;
                        this.abort = false;
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ProcessOK(false);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_editinprogress)
                {
                    ucPflegeEintrag1.PrepareForEdit3();
                    _editinprogress = true;
                    btnEdit2.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderungen speichern");

                    if (!this.ucPflegeEintrag1.HistorischerModus || ENV.adminSecure)
                    {
                        this.btnDelete.Visible = true;
                    }
                    else
                    {
                        this.btnDelete.Visible = false;
                    }
                }
                else
                {
                    ProcessOK(false);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSonderterminErstellen2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.SonderterminErstellen();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void SetUIInterventionen(PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rInterventionen)
        {
            try
            {
                if (!rInterventionen.IsIDBefundNull())
                {
                    this.btnOpenBefund.Visible = true;
                    this.IDBefund = rInterventionen.IDBefund;
                }
                else
                {
                    this.btnOpenBefund.Visible = false;
                    this.IDBefund = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientRueckmeldung.SetUIInterventionen: " + ex.ToString());
            }
        }
        public void SetUIÜbergabe(PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow vÜbergabe)
        {
            try
            {
                if (!vÜbergabe.IsIDBefundNull())
                {
                    this.btnOpenBefund.Visible = true;
                    this.IDBefund = vÜbergabe.IDBefund;
                }
                else
                {
                    this.btnOpenBefund.Visible = false;
                    this.IDBefund = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientRueckmeldung.SetUIÜbergabe: " + ex.ToString());
            }
        }

        private void btnOpenBefund_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                EDIFact1.openBefund((Guid)this.IDBefund);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnFormulare_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.openFormulare();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
