using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.BusinessLogic;
using PMDS.Global;



namespace PMDS.GUI
{



	public class frmPatientHistorie : frmBase
    {
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucPatientHistorie ucPatientHistorie1;
        private QS2.Desktop.ControlManagment.BasePanel panelUntenButt;
        private QS2.Desktop.ControlManagment.BasePanel panelControl;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
		private System.ComponentModel.IContainer components;



        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Patient patient1 = new PMDS.BusinessLogic.Patient();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelUntenButt = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelControl = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucPatientHistorie1 = new PMDS.GUI.ucPatientHistorie();
            this.panelUntenButt.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.BackColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(690, 30);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Historie von {0}";
            // 
            // panelUntenButt
            // 
            this.panelUntenButt.Controls.Add(this.btnClose);
            this.panelUntenButt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUntenButt.Location = new System.Drawing.Point(0, 491);
            this.panelUntenButt.Name = "panelUntenButt";
            this.panelUntenButt.Size = new System.Drawing.Size(690, 33);
            this.panelUntenButt.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(611, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.ucPatientHistorie1);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 30);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(690, 461);
            this.panelControl.TabIndex = 7;
            // 
            // ucPatientHistorie1
            // 
            this.ucPatientHistorie1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucPatientHistorie1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientHistorie1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientHistorie1.Name = "ucPatientHistorie1";
            patient1.Angehörige = "";
            patient1.ArbeitslosBezSeit = "";
            patient1.Besonderheit = "";
            patient1.Betreuer = "";
            patient1.BlutGruppe = "";
            patient1.DatumPensionsteilungsantrag = null;
            patient1.DatumPflegegeldantrag = null;
            patient1.Depotinjektion = "";
            patient1.ErlernterBeruf = "";
            patient1.Familienstand = "";
            patient1.FIBUKonto = "";
            patient1.Geburtsdatum = null;
            patient1.Geburtsort = "";
            patient1.Hauptversicherung = "";
            patient1.Hausarzt = "";
            patient1.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            patient1.IDAdresse = new System.Guid("00000000-0000-0000-0000-000000000000");
            patient1.IDKontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            patient1.Klasse = "";
            patient1.Klientennummer = "";
            patient1.Konfession = "";
            patient1.KrankengeldSeit = "";
            patient1.KrankenKasse = "";
            patient1.LedigerName = "";
            patient1.Nachname = "";
            patient1.NameVollstaendig = "";
            patient1.PensionsteilungsantragJN = false;
            patient1.PflegegeldantragJN = false;
            patient1.Resusfaktor = "";
            patient1.RezeptGebuehrbefreiungJN = false;
            patient1.RollungBis = null;
            patient1.RollungVon = null;
            patient1.Sachwalter = "";
            patient1.SachWalterBelange = "";
            patient1.SachWalterBis = null;
            patient1.SachWalterVon = null;
            patient1.Sexus = "";
            patient1.Staatsb = "";
            patient1.SterbeRegel = "";
            patient1.Titel = "";
            patient1.Vermerk = "";
            patient1.VersicherungsNr = "";
            patient1.Vorname = "";
            this.ucPatientHistorie1.Patient = patient1;
            this.ucPatientHistorie1.Size = new System.Drawing.Size(690, 461);
            this.ucPatientHistorie1.TabIndex = 4;
            // 
            // frmPatientHistorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(690, 524);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelUntenButt);
            this.Controls.Add(this.labInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientHistorie";
            this.Text = "Historische Daten";
            this.Load += new System.EventHandler(this.frmPatientHistorie_Load);
            this.panelUntenButt.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

		public frmPatientHistorie(System.Guid IDKlient, bool  edit )
		{
			InitializeComponent();
            Patient pat = new Patient(IDKlient);
            labInfo.Text = string.Format(labInfo.Text, pat.FullInfo);
            ucPatientHistorie1.Patient = pat;
		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPatientHistorie_Load(object sender, EventArgs e)
        {
            this.panelUntenButt.BackColor = System.Drawing.Color.Gainsboro;

            QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
            ControlManagment1.autoTranslateForm(this);

        }


	}
}
