using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{



	public class ucEinrichtung : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private bool		_valueChangeEnabled = true;
		private Einrichtung _einrichtung;
        private IContainer components;
        public event EventHandler ValueChanged;
		private PMDS.GUI.ucKontakt ucKontakt1;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpEinrichtungAdresse;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpKontakt;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtEinrichtung;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtRegion;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtOrt;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtPLZ;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtStrasse;
        private QS2.Desktop.ControlManagment.BaseLabel lblRegion;
		private QS2.Desktop.ControlManagment.BaseLabel lblOrt;
		private QS2.Desktop.ControlManagment.BaseLabel lblPLZ;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIstKrankenkasse;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtELGAGdaOid;
        private QS2.Desktop.ControlManagment.BaseLabel lblELGA_OID;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkELGAAbgeglichen;
        public BaseControls.AuswahlGruppeCombo cboLand;
        private QS2.Desktop.ControlManagment.BaseLabel lblLand;
        private QS2.Desktop.ControlManagment.BaseLabel lblStrasse;






		public ucEinrichtung()
		{
			InitializeComponent();
			New();
			RequiredFields();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.grpEinrichtungAdresse = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblLand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.chkELGAAbgeglichen = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtELGAGdaOid = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblELGA_OID = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkIstKrankenkasse = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtEinrichtung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPLZ = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblRegion = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblPLZ = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblStrasse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtRegion = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.grpKontakt = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucKontakt1 = new PMDS.GUI.ucKontakt();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpEinrichtungAdresse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAbgeglichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAGdaOid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIstKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegion)).BeginInit();
            this.grpKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEinrichtungAdresse
            // 
            this.grpEinrichtungAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpEinrichtungAdresse.Controls.Add(this.lblLand);
            this.grpEinrichtungAdresse.Controls.Add(this.cboLand);
            this.grpEinrichtungAdresse.Controls.Add(this.chkELGAAbgeglichen);
            this.grpEinrichtungAdresse.Controls.Add(this.txtELGAGdaOid);
            this.grpEinrichtungAdresse.Controls.Add(this.lblELGA_OID);
            this.grpEinrichtungAdresse.Controls.Add(this.chkIstKrankenkasse);
            this.grpEinrichtungAdresse.Controls.Add(this.txtOrt);
            this.grpEinrichtungAdresse.Controls.Add(this.txtStrasse);
            this.grpEinrichtungAdresse.Controls.Add(this.txtEinrichtung);
            this.grpEinrichtungAdresse.Controls.Add(this.txtPLZ);
            this.grpEinrichtungAdresse.Controls.Add(this.lblRegion);
            this.grpEinrichtungAdresse.Controls.Add(this.lblOrt);
            this.grpEinrichtungAdresse.Controls.Add(this.lblPLZ);
            this.grpEinrichtungAdresse.Controls.Add(this.lblStrasse);
            this.grpEinrichtungAdresse.Controls.Add(this.lblBezeichnung);
            this.grpEinrichtungAdresse.Controls.Add(this.txtRegion);
            this.grpEinrichtungAdresse.Location = new System.Drawing.Point(8, 8);
            this.grpEinrichtungAdresse.Name = "grpEinrichtungAdresse";
            this.grpEinrichtungAdresse.Size = new System.Drawing.Size(448, 354);
            this.grpEinrichtungAdresse.TabIndex = 0;
            this.grpEinrichtungAdresse.TabStop = false;
            this.grpEinrichtungAdresse.Text = "Einrichtung-Adresse";
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(9, 112);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(35, 17);
            this.lblLand.TabIndex = 25;
            this.lblLand.Text = "Land";
            // 
            // cboLand
            // 
            this.cboLand.AddEmptyEntry = false;
            this.cboLand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLand.AutoOpenCBO = true;
            this.cboLand.BerufsstandGruppeJNA = 0;
            this.cboLand.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboLand.ExactMatch = false;
            this.cboLand.Group = "LND";
            this.cboLand.ID_PEP = -1;
            this.cboLand.Location = new System.Drawing.Point(100, 108);
            this.cboLand.Name = "cboLand";
            this.cboLand.PflichtJN = false;
            this.cboLand.ShowAddButton = true;
            this.cboLand.Size = new System.Drawing.Size(339, 24);
            this.cboLand.sys = false;
            this.cboLand.TabIndex = 4;
            this.cboLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkELGAAbgeglichen
            // 
            this.chkELGAAbgeglichen.Enabled = false;
            this.chkELGAAbgeglichen.Location = new System.Drawing.Point(100, 188);
            this.chkELGAAbgeglichen.Name = "chkELGAAbgeglichen";
            this.chkELGAAbgeglichen.Size = new System.Drawing.Size(173, 23);
            this.chkELGAAbgeglichen.TabIndex = 7;
            this.chkELGAAbgeglichen.Text = "Mit Elga abgeglichen";
            // 
            // txtELGAGdaOid
            // 
            this.txtELGAGdaOid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            this.txtELGAGdaOid.Appearance = appearance1;
            this.txtELGAGdaOid.BackColor = System.Drawing.Color.White;
            this.txtELGAGdaOid.Location = new System.Drawing.Point(100, 216);
            this.txtELGAGdaOid.MaxLength = 20;
            this.txtELGAGdaOid.Name = "txtELGAGdaOid";
            this.txtELGAGdaOid.ReadOnly = true;
            this.txtELGAGdaOid.Size = new System.Drawing.Size(339, 24);
            this.txtELGAGdaOid.TabIndex = 8;
            // 
            // lblELGA_OID
            // 
            this.lblELGA_OID.AutoSize = true;
            this.lblELGA_OID.Location = new System.Drawing.Point(9, 220);
            this.lblELGA_OID.Name = "lblELGA_OID";
            this.lblELGA_OID.Size = new System.Drawing.Size(93, 17);
            this.lblELGA_OID.TabIndex = 12;
            this.lblELGA_OID.Text = "ELGA GDA-ID";
            // 
            // chkIstKrankenkasse
            // 
            this.chkIstKrankenkasse.Location = new System.Drawing.Point(100, 165);
            this.chkIstKrankenkasse.Name = "chkIstKrankenkasse";
            this.chkIstKrankenkasse.Size = new System.Drawing.Size(173, 23);
            this.chkIstKrankenkasse.TabIndex = 6;
            this.chkIstKrankenkasse.Text = "Ist Krankenkasse";
            this.chkIstKrankenkasse.CheckedChanged += new System.EventHandler(this.ChkIstKrankenkasse_CheckedChanged);
            // 
            // txtOrt
            // 
            this.txtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrt.Location = new System.Drawing.Point(199, 80);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(240, 24);
            this.txtOrt.TabIndex = 3;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtStrasse
            // 
            this.txtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStrasse.Location = new System.Drawing.Point(100, 52);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(339, 24);
            this.txtStrasse.TabIndex = 1;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtEinrichtung
            // 
            this.txtEinrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEinrichtung.Location = new System.Drawing.Point(100, 24);
            this.txtEinrichtung.MaxLength = 255;
            this.txtEinrichtung.Name = "txtEinrichtung";
            this.txtEinrichtung.Size = new System.Drawing.Size(339, 24);
            this.txtEinrichtung.TabIndex = 0;
            this.txtEinrichtung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(100, 80);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(66, 24);
            this.txtPLZ.TabIndex = 2;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(9, 141);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(49, 17);
            this.lblRegion.TabIndex = 9;
            this.lblRegion.Text = "Region";
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(172, 84);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(24, 17);
            this.lblOrt.TabIndex = 7;
            this.lblOrt.Text = "Ort";
            // 
            // lblPLZ
            // 
            this.lblPLZ.AutoSize = true;
            this.lblPLZ.Location = new System.Drawing.Point(9, 84);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(30, 17);
            this.lblPLZ.TabIndex = 4;
            this.lblPLZ.Text = "PLZ";
            // 
            // lblStrasse
            // 
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Location = new System.Drawing.Point(9, 56);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(52, 17);
            this.lblStrasse.TabIndex = 2;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(9, 28);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(84, 17);
            this.lblBezeichnung.TabIndex = 0;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // txtRegion
            // 
            this.txtRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegion.Location = new System.Drawing.Point(100, 137);
            this.txtRegion.MaxLength = 20;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(339, 24);
            this.txtRegion.TabIndex = 5;
            this.txtRegion.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpKontakt
            // 
            this.grpKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKontakt.Controls.Add(this.ucKontakt1);
            this.grpKontakt.Location = new System.Drawing.Point(462, 8);
            this.grpKontakt.Name = "grpKontakt";
            this.grpKontakt.Size = new System.Drawing.Size(539, 354);
            this.grpKontakt.TabIndex = 20;
            this.grpKontakt.TabStop = false;
            this.grpKontakt.Text = "Kontakt";
            // 
            // ucKontakt1
            // 
            this.ucKontakt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKontakt1.BackColor = System.Drawing.Color.Transparent;
            this.ucKontakt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucKontakt1.Location = new System.Drawing.Point(10, 24);
            this.ucKontakt1.Name = "ucKontakt1";
            this.ucKontakt1.Size = new System.Drawing.Size(518, 268);
            this.ucKontakt1.TabIndex = 0;
            this.ucKontakt1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucEinrichtung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.grpKontakt);
            this.Controls.Add(this.grpEinrichtungAdresse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucEinrichtung";
            this.Size = new System.Drawing.Size(1009, 370);
            this.grpEinrichtungAdresse.ResumeLayout(false);
            this.grpEinrichtungAdresse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAbgeglichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAGdaOid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIstKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegion)).EndInit();
            this.grpKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public Einrichtung Einrichtung
		{
			get	
			{	
				return _einrichtung;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Einrichtung");

				_valueChangeEnabled = false;
				_einrichtung = value;
				UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

		public void UpdateGUI()
		{
			ucKontakt1.Kontakt = Einrichtung.Kontakt;

			txtEinrichtung.Text	= Einrichtung.Bezeichnung;
			txtStrasse.Text		= Einrichtung.Adresse.Strasse;
			txtPLZ.Text			= Einrichtung.Adresse.Plz;
			txtOrt.Text			= Einrichtung.Adresse.Ort;
			txtRegion.Text		= Einrichtung.Adresse.Region;
            cboLand.Value = Einrichtung.Adresse.LandKZ.Trim();

            this.txtELGAGdaOid.Text = Einrichtung.ELGA_OID;
            this.chkELGAAbgeglichen.Checked = Einrichtung.ELGAAbgeglichen;
            this.chkIstKrankenkasse.Checked = Einrichtung.IstKrankenkasse;
        }

		public void UpdateDATA()
		{
			ucKontakt1.UpdateDATA();

			Einrichtung.Bezeichnung		= txtEinrichtung.Text;
			Einrichtung.Adresse.Strasse	= txtStrasse.Text;
			Einrichtung.Adresse.Plz	    = txtPLZ.Text;
			Einrichtung.Adresse.Ort		= txtOrt.Text;
			Einrichtung.Adresse.Region  = txtRegion.Text;
            Einrichtung.Adresse.LandKZ = cboLand.Value.ToString().Trim();

            Einrichtung.ELGA_OID = this.txtELGAGdaOid.Text.Trim();
            Einrichtung.ELGAAbgeglichen = this.chkELGAAbgeglichen.Checked;
            Einrichtung.IstKrankenkasse = this.chkIstKrankenkasse.Checked;
        }

		public bool New()
		{
			Einrichtung = new Einrichtung();
			return true;
		}

		public void Read(object id)
		{
			Einrichtung obj = new Einrichtung((Guid)id);
			Einrichtung = obj;
		}

		public void Read()
		{
			Einrichtung.Read();
			Einrichtung = Einrichtung;
		}

		public void Write()
		{
			Einrichtung.Write();
		}

		public void Delete()
		{
			Einrichtung.Delete();
			New();
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtEinrichtung);
			GuiUtil.ValidateRequired(txtStrasse);
			//GuiUtil.ValidateRequired(cboLand);
			GuiUtil.ValidateRequired(txtPLZ);
			GuiUtil.ValidateRequired(txtOrt);
		}

		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// txtEinrichtung
			GuiUtil.ValidateField(txtEinrichtung, (txtEinrichtung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtStrasse
			GuiUtil.ValidateField(txtStrasse, (txtStrasse.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtLand
			//GuiUtil.ValidateField(cboLand, (cboLand.Text.Length > 0),
			//	ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtPLZ
			GuiUtil.ValidateField(txtPLZ, (txtPLZ.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtOrt
			GuiUtil.ValidateField(txtOrt, (txtOrt.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            string MsgTxt2 = "";
            bool cbLandOK = PMDSBusinessUI.checkCboBox(this.cboLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt2);
            if (!cbLandOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            return !bError;
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return Einrichtung.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return Einrichtung;					}
			set	{	Einrichtung = (Einrichtung)value;	}
		}

        #endregion


        private void ChkIstKrankenkasse_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIstKrankenkasse.Focused)
            {
                OnValueChanged(sender, e);
            }

        }

    }

}
