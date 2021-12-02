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

	public class frmPatientNew : frmBase
	{
		private bool _canClose = false;
		private QS2.Desktop.ControlManagment.BaseLabel lblInfo1;
		private QS2.Desktop.ControlManagment.BaseLabel lblInfo2;
		private PMDS.GUI.ucPatientNew ucPatientNew1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.ComponentModel.IContainer components;


		public frmPatientNew(Patient pat)
		{
			InitializeComponent();
            
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }


            ucPatientNew1.Patient = pat;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
                    if (lblInfo1 != null) lblInfo1.Dispose();
                    if (lblInfo2 != null) lblInfo2.Dispose();
                    if (ucPatientNew1 != null) ucPatientNew1.Dispose();
                    if (btnCancel != null) btnCancel.Dispose();
                    if (btnCancel != null) btnCancel.Dispose();
                    if (btnOK != null) btnOK.Dispose();
                    if (labInfo != null) labInfo.Dispose();
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
            PMDS.BusinessLogic.Patient patient1 = new PMDS.BusinessLogic.Patient();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientNew));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInfo1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInfo2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPatientNew1 = new PMDS.GUI.ucPatientNew();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
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
            this.labInfo.Size = new System.Drawing.Size(574, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Neuaufnahme";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblInfo1.Appearance = appearance2;
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(0, 64);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(574, 24);
            this.lblInfo1.TabIndex = 1;
            this.lblInfo1.Text = "Klient(in) wird im System neu erfasst";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblInfo2.Appearance = appearance3;
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.Location = new System.Drawing.Point(0, 88);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(574, 32);
            this.lblInfo2.TabIndex = 2;
            this.lblInfo2.Text = "(keine Wiederaufnahme)";
            // 
            // ucPatientNew1
            // 
            this.ucPatientNew1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPatientNew1.Location = new System.Drawing.Point(0, 136);
            this.ucPatientNew1.Name = "ucPatientNew1";
            patient1.abwesenheitenHändBerech = false;
            patient1.Anatomie = false;
            patient1.Angehörige = "";
            patient1.ArbeitslosBezSeit = "";
            patient1.Besonderheit = "";
            patient1.Betreuer = "";
            patient1.blob_Einverständniserklärung = null;
            patient1.BlutGruppe = "";
            patient1.DatumPensionsteilungsantrag = null;
            patient1.DatumPflegegeldantrag = null;
            patient1.Depotinjektion = "";
            patient1.DNR = false;
            patient1.EinverständniserklärungFileType = "";
            patient1.Einzelzimmer = false;
            patient1.ErlernterBeruf = "";
            patient1.Familienstand = "";
            patient1.FIBUKonto = "";
            patient1.Geburtsdatum = null;
            patient1.Geburtsort = "";
            patient1.Hauptversicherung = "";
            patient1.Hausarzt = "";
            patient1.ID = new System.Guid("c8bf197a-7f07-4ec8-a1fc-5ff78ca72f74");
            patient1.IDAbteilung = null;
            patient1.IDAdresse = new System.Guid("5fa4373a-dce3-4188-b2d6-7ee19dbcd1a5");
            patient1.IDBereich = null;
            patient1.IDKontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            patient1.jpg_Einverständniserklärung = null;
            patient1.Kennwort = "";
            patient1.Klasse = "";
            patient1.Klientennummer = "";
            patient1.Konfession = "";
            patient1.KrankengeldSeit = "";
            patient1.KrankenKasse = "";
            patient1.KZUeberlebender = false;
            patient1.LedigerName = "";
            patient1.Milieubetreuung = false;
            patient1.minSaldo = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            patient1.Selbstzahler = false;
            patient1.Sexus = "";
            patient1.Staatsb = "";
            patient1.SterbeRegel = "";
            patient1.Titel = "";
            patient1.Todeszeitpunkt = null;
            patient1.Vermerk = "";
            patient1.VersicherungsNr = "";
            patient1.Verstorben = false;
            patient1.Vorname = "";
            patient1.WohnungAbgemeldetJN = false;
            this.ucPatientNew1.Patient = patient1;
            this.ucPatientNew1.ReadOnlyVersDat = false;
            this.ucPatientNew1.Size = new System.Drawing.Size(574, 528);
            this.ucPatientNew1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance4;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(424, 672);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
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
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance5;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(520, 672);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPatientNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(574, 716);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPatientNew1);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientNew";
            this.ShowInTaskbar = false;
            this.Text = "Klienten-Verwaltung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientNew_Load);
            this.ResumeLayout(false);

		}
		#endregion


		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ucPatientNew1.ValidateFields())
				return;

			ucPatientNew1.UpdateDATA();
            ucPatientNew1.Patient.Write();
			_canClose = true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

        private void frmPatientNew_Load(object sender, EventArgs e)
        {

        }

	}

}

