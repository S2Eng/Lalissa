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



	public class ucAdresse : QS2.Desktop.ControlManagment.BaseControl
	{
		private Adresse _adr;
		public event EventHandler ValueChanged;

		private QS2.Desktop.ControlManagment.BaseLabel lblStrasse;
		private QS2.Desktop.ControlManagment.BaseLabel lblLand;
		private QS2.Desktop.ControlManagment.BaseLabel lblOrt;
		private QS2.Desktop.ControlManagment.BaseLabel lblRegion;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtStrasse;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtPLZ;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtOrt;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtRegion;
        private QS2.Desktop.ControlManagment.BaseLabel lblPLZ;
        public BaseControls.AuswahlGruppeCombo cboLand;
        private System.ComponentModel.Container components = null;





		public ucAdresse()
		{
			InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning) return;
			Init();
		}


		private void Init()
		{
			Adresse = new Adresse();
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
            this.lblStrasse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblLand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblRegion = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtStrasse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPLZ = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtRegion = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPLZ = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStrasse
            // 
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Location = new System.Drawing.Point(10, 4);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(52, 17);
            this.lblStrasse.TabIndex = 0;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(10, 65);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(35, 17);
            this.lblLand.TabIndex = 2;
            this.lblLand.Text = "Land";
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(166, 34);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(24, 17);
            this.lblOrt.TabIndex = 5;
            this.lblOrt.Text = "Ort";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(10, 95);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(49, 17);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Region";
            // 
            // txtStrasse
            // 
            this.txtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStrasse.Location = new System.Drawing.Point(90, 0);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(300, 24);
            this.txtStrasse.TabIndex = 0;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(90, 30);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(73, 24);
            this.txtPLZ.TabIndex = 1;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtOrt
            // 
            this.txtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrt.Location = new System.Drawing.Point(190, 30);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(200, 24);
            this.txtOrt.TabIndex = 2;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtRegion
            // 
            this.txtRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegion.Location = new System.Drawing.Point(90, 91);
            this.txtRegion.MaxLength = 20;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(300, 24);
            this.txtRegion.TabIndex = 4;
            this.txtRegion.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPLZ
            // 
            this.lblPLZ.AutoSize = true;
            this.lblPLZ.Location = new System.Drawing.Point(10, 34);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(30, 17);
            this.lblPLZ.TabIndex = 9;
            this.lblPLZ.Text = "PLZ";
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
            this.cboLand.Location = new System.Drawing.Point(90, 61);
            this.cboLand.Name = "cboLand";
            this.cboLand.PflichtJN = false;
            this.cboLand.ShowAddButton = true;
            this.cboLand.Size = new System.Drawing.Size(300, 24);
            this.cboLand.sys = false;
            this.cboLand.TabIndex = 3;
            this.cboLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ucAdresse
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.txtStrasse);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.cboLand);
            this.Controls.Add(this.lblPLZ);
            this.Controls.Add(this.txtOrt);
            this.Controls.Add(this.txtPLZ);
            this.Controls.Add(this.lblOrt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucAdresse";
            this.Size = new System.Drawing.Size(396, 120);
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Adresse Adresse
		{
			get	
			{	
				return _adr;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Adresse");

				_adr = value;
				UpdateGUI();
			}
		}


		public void UpdateGUI()
		{
			txtStrasse.Text	= Adresse.Strasse;
			txtPLZ.Text		= Adresse.Plz;
			txtOrt.Text		= Adresse.Ort;
			txtRegion.Text	= Adresse.Region;
            cboLand.Value = Adresse.LandKZ.Trim();
        }
        public void clearUI()
        {
            txtStrasse.Text = "";
            txtPLZ.Text = "";
            txtOrt.Text = "";
            txtRegion.Text = "";
            cboLand.Text = "";
            cboLand.Text = "";
            cboLand.Value = null;
        }

		public void UpdateDATA()
		{
			Adresse.Strasse	= txtStrasse.Text;
			Adresse.Plz	    = txtPLZ.Text;
			Adresse.Ort		= txtOrt.Text;
			Adresse.Region  = txtRegion.Text;
            Adresse.LandKZ = cboLand.Text.Trim();
        }

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);
		}

	}
}
