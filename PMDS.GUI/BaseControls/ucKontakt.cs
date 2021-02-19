//----------------------------------------------------------------------------
/// <summary>
///	ucKontakt.cs
/// Erstellt am:	15.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
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
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation eines Kontaktes
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucKontakt : QS2.Desktop.ControlManagment.BaseControl
	{
		private Kontakt _kontakt;
		public event EventHandler ValueChanged;

		private QS2.Desktop.ControlManagment.BaseLabel lblTelefon;
		private QS2.Desktop.ControlManagment.BaseLabel lblFax;
		private QS2.Desktop.ControlManagment.BaseLabel lblMobil;
		private QS2.Desktop.ControlManagment.BaseLabel lblAndere;
		private QS2.Desktop.ControlManagment.BaseLabel lblEMail;
		private System.ComponentModel.Container components = null;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtTelefon;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtFax;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtMobil;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtAndere;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtEMail;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtZusatz3;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtZusatz2;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtZusatz1;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtAnsprechpartner;
		private QS2.Desktop.ControlManagment.BaseLabel lblZusatz;
		private QS2.Desktop.ControlManagment.BaseLabel lblGeschäftsführer;
		private QS2.Desktop.ControlManagment.BaseLabel lblHandelsregister;
		private QS2.Desktop.ControlManagment.BaseLabel lblWWW;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucKontakt()
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
			Init();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung
		/// </summary>
		//----------------------------------------------------------------------------
		private void Init()
		{
			Kontakt = new Kontakt();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            this.lblTelefon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFax = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMobil = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAndere = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEMail = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtTelefon = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtFax = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtMobil = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtAndere = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtEMail = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtZusatz3 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtZusatz2 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtZusatz1 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtAnsprechpartner = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblZusatz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGeschäftsführer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHandelsregister = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblWWW = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAndere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsprechpartner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(0, 3);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(51, 17);
            this.lblTelefon.TabIndex = 0;
            this.lblTelefon.Text = "Telefon";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(0, 34);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(28, 17);
            this.lblFax.TabIndex = 1;
            this.lblFax.Text = "Fax";
            // 
            // lblMobil
            // 
            this.lblMobil.AutoSize = true;
            this.lblMobil.Location = new System.Drawing.Point(0, 64);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(38, 17);
            this.lblMobil.TabIndex = 2;
            this.lblMobil.Text = "Mobil";
            // 
            // lblAndere
            // 
            this.lblAndere.AutoSize = true;
            this.lblAndere.Location = new System.Drawing.Point(0, 94);
            this.lblAndere.Name = "lblAndere";
            this.lblAndere.Size = new System.Drawing.Size(49, 17);
            this.lblAndere.TabIndex = 3;
            this.lblAndere.Text = "Andere";
            // 
            // lblEMail
            // 
            this.lblEMail.AutoSize = true;
            this.lblEMail.Location = new System.Drawing.Point(0, 124);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(44, 17);
            this.lblEMail.TabIndex = 4;
            this.lblEMail.Text = "E-Mail";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefon.Location = new System.Drawing.Point(98, 0);
            this.txtTelefon.MaxLength = 25;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(369, 24);
            this.txtTelefon.TabIndex = 9;
            this.txtTelefon.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(98, 30);
            this.txtFax.MaxLength = 25;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(369, 24);
            this.txtFax.TabIndex = 10;
            this.txtFax.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtMobil
            // 
            this.txtMobil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobil.Location = new System.Drawing.Point(98, 60);
            this.txtMobil.MaxLength = 25;
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.Size = new System.Drawing.Size(369, 24);
            this.txtMobil.TabIndex = 11;
            this.txtMobil.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtAndere
            // 
            this.txtAndere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAndere.Location = new System.Drawing.Point(98, 90);
            this.txtAndere.MaxLength = 25;
            this.txtAndere.Name = "txtAndere";
            this.txtAndere.Size = new System.Drawing.Size(369, 24);
            this.txtAndere.TabIndex = 12;
            this.txtAndere.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtEMail
            // 
            this.txtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMail.Location = new System.Drawing.Point(98, 120);
            this.txtEMail.MaxLength = 50;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(369, 24);
            this.txtEMail.TabIndex = 13;
            this.txtEMail.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtZusatz3
            // 
            this.txtZusatz3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZusatz3.Location = new System.Drawing.Point(98, 240);
            this.txtZusatz3.MaxLength = 75;
            this.txtZusatz3.Name = "txtZusatz3";
            this.txtZusatz3.Size = new System.Drawing.Size(369, 24);
            this.txtZusatz3.TabIndex = 17;
            this.txtZusatz3.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtZusatz2
            // 
            this.txtZusatz2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZusatz2.Location = new System.Drawing.Point(98, 210);
            this.txtZusatz2.MaxLength = 75;
            this.txtZusatz2.Name = "txtZusatz2";
            this.txtZusatz2.Size = new System.Drawing.Size(369, 24);
            this.txtZusatz2.TabIndex = 16;
            this.txtZusatz2.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtZusatz1
            // 
            this.txtZusatz1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZusatz1.Location = new System.Drawing.Point(98, 180);
            this.txtZusatz1.MaxLength = 75;
            this.txtZusatz1.Name = "txtZusatz1";
            this.txtZusatz1.Size = new System.Drawing.Size(369, 24);
            this.txtZusatz1.TabIndex = 15;
            this.txtZusatz1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtAnsprechpartner
            // 
            this.txtAnsprechpartner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnsprechpartner.Location = new System.Drawing.Point(98, 150);
            this.txtAnsprechpartner.MaxLength = 50;
            this.txtAnsprechpartner.Name = "txtAnsprechpartner";
            this.txtAnsprechpartner.Size = new System.Drawing.Size(369, 24);
            this.txtAnsprechpartner.TabIndex = 14;
            this.txtAnsprechpartner.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblZusatz
            // 
            this.lblZusatz.AutoSize = true;
            this.lblZusatz.Location = new System.Drawing.Point(0, 244);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(46, 17);
            this.lblZusatz.TabIndex = 8;
            this.lblZusatz.Text = "Zusatz";
            // 
            // lblGeschäftsführer
            // 
            this.lblGeschäftsführer.AutoSize = true;
            this.lblGeschäftsführer.Location = new System.Drawing.Point(-2, 214);
            this.lblGeschäftsführer.Name = "lblGeschäftsführer";
            this.lblGeschäftsführer.Size = new System.Drawing.Size(103, 17);
            this.lblGeschäftsführer.TabIndex = 7;
            this.lblGeschäftsführer.Text = "Geschäftsführer";
            // 
            // lblHandelsregister
            // 
            this.lblHandelsregister.AutoSize = true;
            this.lblHandelsregister.Location = new System.Drawing.Point(0, 184);
            this.lblHandelsregister.Name = "lblHandelsregister";
            this.lblHandelsregister.Size = new System.Drawing.Size(101, 17);
            this.lblHandelsregister.TabIndex = 6;
            this.lblHandelsregister.Text = "Handelsregister";
            // 
            // lblWWW
            // 
            this.lblWWW.AutoSize = true;
            this.lblWWW.Location = new System.Drawing.Point(0, 154);
            this.lblWWW.Name = "lblWWW";
            this.lblWWW.Size = new System.Drawing.Size(44, 17);
            this.lblWWW.TabIndex = 5;
            this.lblWWW.Text = "WWW";
            // 
            // ucKontakt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtZusatz3);
            this.Controls.Add(this.txtZusatz2);
            this.Controls.Add(this.txtZusatz1);
            this.Controls.Add(this.txtAnsprechpartner);
            this.Controls.Add(this.lblZusatz);
            this.Controls.Add(this.lblGeschäftsführer);
            this.Controls.Add(this.lblHandelsregister);
            this.Controls.Add(this.lblWWW);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.txtAndere);
            this.Controls.Add(this.txtMobil);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.lblAndere);
            this.Controls.Add(this.lblMobil);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.lblTelefon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucKontakt";
            this.Size = new System.Drawing.Size(467, 266);
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAndere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZusatz1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsprechpartner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// KONTAKT setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Kontakt Kontakt
		{
			get	
			{	
				return _kontakt;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Kontakt");

				_kontakt = value;
				UpdateGUI();
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
			txtTelefon.Text			= Kontakt.Tel;
			txtFax.Text				= Kontakt.Fax;
			txtMobil.Text			= Kontakt.Mobil;
			txtAndere.Text			= Kontakt.Andere;
			txtEMail.Text			= Kontakt.Email;
			txtAnsprechpartner.Text	= Kontakt.Ansprechpartner;
			txtZusatz1.Text			= Kontakt.Zusatz1;
			txtZusatz2.Text			= Kontakt.Zusatz2;
			txtZusatz3.Text			= Kontakt.Zusatz3;
		}
        public void clearUI()
        {
            txtTelefon.Text = "";
            txtFax.Text = "";
            txtMobil.Text = "";
            txtAndere.Text = "";
            txtEMail.Text = "";
            txtAnsprechpartner.Text = "";
            txtZusatz1.Text = "";
            txtZusatz2.Text = "";
            txtZusatz3.Text = "";
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Kontakt.Tel				= txtTelefon.Text;
			Kontakt.Fax				= txtFax.Text; 
			Kontakt.Mobil			= txtMobil.Text;
			Kontakt.Andere			= txtAndere.Text;
			Kontakt.Email			= txtEMail.Text;
			Kontakt.Ansprechpartner	= txtAnsprechpartner.Text;
			Kontakt.Zusatz1			= txtZusatz1.Text;
			Kontakt.Zusatz2			= txtZusatz2.Text;
			Kontakt.Zusatz3			= txtZusatz3.Text;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);
		}


	}
}
