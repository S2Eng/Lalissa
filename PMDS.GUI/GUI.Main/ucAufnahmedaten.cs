//----------------------------------------------------------------------------
/// <summary>
///	ucAufnahmedaten.cs
/// Erstellt am:	19.10.2004
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
	/// UserControl zur Bearbeitung der Aufnahmedaten
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucAufnahmedaten : QS2.Desktop.ControlManagment.BaseControl, IReadOnly, IWizardPage
	{
		private Aufenthalt	_aufenthalt;

		private System.Windows.Forms.ErrorProvider errorProvider1;
		private PMDS.GUI.BaseControls.BereichsCombo cbBereich;
		private QS2.Desktop.ControlManagment.BaseLabel ultraLabel10;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtAufGespraech;
		private QS2.Desktop.ControlManagment.BaseLabel lblAufnahmegespräch;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
		private QS2.Desktop.ControlManagment.BaseLabel ultraLabel7;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtZuwArzt;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpAufnahme;
		private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtAufArzt;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucAufnahmedaten()
		{
			InitializeComponent();
            cbBereich.RefreshList();
			Aufenthalt = new Aufenthalt();
			RequiredFields();
		}

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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbBereich = new PMDS.GUI.BaseControls.BereichsCombo();
            this.ultraLabel10 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAufGespraech = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblAufnahmegespräch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel7 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtZuwArzt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dtpAufnahme = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAufArzt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAufGespraech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZuwArzt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAufArzt)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbBereich
            // 
            this.cbBereich.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBereich.Location = new System.Drawing.Point(112, 88);
            this.cbBereich.Name = "cbBereich";
            this.cbBereich.Size = new System.Drawing.Size(128, 21);
            this.cbBereich.TabIndex = 19;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Location = new System.Drawing.Point(8, 91);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel10.TabIndex = 18;
            this.ultraLabel10.Text = "Bereich";
            // 
            // txtAufGespraech
            // 
            this.txtAufGespraech.AcceptsReturn = true;
            this.txtAufGespraech.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            this.txtAufGespraech.Appearance = appearance1;
            this.txtAufGespraech.BackColor = System.Drawing.Color.White;
            this.txtAufGespraech.Location = new System.Drawing.Point(112, 128);
            this.txtAufGespraech.Multiline = true;
            this.txtAufGespraech.Name = "txtAufGespraech";
            this.txtAufGespraech.Size = new System.Drawing.Size(392, 120);
            this.txtAufGespraech.TabIndex = 21;
            // 
            // lblAufnahmegespräch
            // 
            this.lblAufnahmegespräch.AutoSize = true;
            this.lblAufnahmegespräch.Location = new System.Drawing.Point(8, 128);
            this.lblAufnahmegespräch.Name = "lblAufnahmegespräch";
            this.lblAufnahmegespräch.Size = new System.Drawing.Size(102, 14);
            this.lblAufnahmegespräch.TabIndex = 20;
            this.lblAufnahmegespräch.Text = "Aufnahmegespräch";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.White;
            this.txtBemerkung.Appearance = appearance2;
            this.txtBemerkung.BackColor = System.Drawing.Color.White;
            this.txtBemerkung.Location = new System.Drawing.Point(112, 256);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(392, 152);
            this.txtBemerkung.TabIndex = 23;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 256);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 22;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Location = new System.Drawing.Point(8, 67);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(87, 14);
            this.ultraLabel7.TabIndex = 16;
            this.ultraLabel7.Text = "Aufnahmedatum";
            // 
            // txtZuwArzt
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.txtZuwArzt.Appearance = appearance3;
            this.txtZuwArzt.BackColor = System.Drawing.Color.White;
            this.txtZuwArzt.Location = new System.Drawing.Point(112, 16);
            this.txtZuwArzt.MaxLength = 50;
            this.txtZuwArzt.Name = "txtZuwArzt";
            this.txtZuwArzt.Size = new System.Drawing.Size(200, 21);
            this.txtZuwArzt.TabIndex = 13;
            // 
            // dtpAufnahme
            // 
            this.dtpAufnahme.FormatString = "";
            this.dtpAufnahme.Location = new System.Drawing.Point(112, 64);
            this.dtpAufnahme.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpAufnahme.Name = "dtpAufnahme";
            this.dtpAufnahme.Size = new System.Drawing.Size(128, 21);
            this.dtpAufnahme.TabIndex = 17;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 19);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(92, 14);
            this.ultraLabel3.TabIndex = 12;
            this.ultraLabel3.Text = "Zuweisender Arzt";
            // 
            // txtAufArzt
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.txtAufArzt.Appearance = appearance4;
            this.txtAufArzt.BackColor = System.Drawing.Color.White;
            this.txtAufArzt.Location = new System.Drawing.Point(112, 40);
            this.txtAufArzt.MaxLength = 50;
            this.txtAufArzt.Name = "txtAufArzt";
            this.txtAufArzt.Size = new System.Drawing.Size(200, 21);
            this.txtAufArzt.TabIndex = 15;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(8, 43);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(75, 14);
            this.ultraLabel1.TabIndex = 14;
            this.ultraLabel1.Text = "Aufnahmearzt";
            // 
            // ucAufnahmedaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cbBereich);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.txtAufGespraech);
            this.Controls.Add(this.lblAufnahmegespräch);
            this.Controls.Add(this.txtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.txtZuwArzt);
            this.Controls.Add(this.dtpAufnahme);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.txtAufArzt);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "ucAufnahmedaten";
            this.Size = new System.Drawing.Size(512, 416);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAufGespraech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZuwArzt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAufArzt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufenthalt setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public Aufenthalt Aufenthalt
		{
			get	
			{	
				return _aufenthalt;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Aufenthalt");

				_aufenthalt = value;
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
			txtZuwArzt.Text				= Aufenthalt.AufnahmeVerlauf.ZuweisenderArzt;
			txtAufArzt.Text				= Aufenthalt.AufnahmeVerlauf.AufnahmeArzt;
			dtpAufnahme.Value			= Aufenthalt.AufnahmeVerlauf.Datum;
			cbBereich.Value				= Aufenthalt.AufnahmeVerlauf.IDBereich;
			txtAufGespraech.Text		= Aufenthalt.AufnahmeVerlauf.Aufnahmegespraech;
			txtBemerkung.Text			= Aufenthalt.AufnahmeVerlauf.Bemerkung;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Aufenthalt.AufnahmeVerlauf.ZuweisenderArzt	= txtZuwArzt.Text;
			Aufenthalt.AufnahmeVerlauf.AufnahmeArzt		= txtAufArzt.Text;
			Aufenthalt.AufnahmeVerlauf.Datum			= (DateTime)dtpAufnahme.Value;
			Aufenthalt.AufnahmeVerlauf.Aufnahmegespraech= txtAufGespraech.Text;
			Aufenthalt.AufnahmeVerlauf.Bemerkung		= txtBemerkung.Text;

			if (cbBereich.Value == null)
				Aufenthalt.AufnahmeVerlauf.IDBereich = Guid.Empty;
			else
				Aufenthalt.AufnahmeVerlauf.IDBereich = (Guid)cbBereich.Value;

			Aufenthalt.Aufnahmezeitpunkt = (DateTime)dtpAufnahme.Value;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpAufnahme);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// dtpAufnahme
			GuiUtil.ValidateField(dtpAufnahme, (dtpAufnahme.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ReadOnly
		{
			get
			{
				return txtZuwArzt.ReadOnly;
			}
			set
			{
				txtZuwArzt.ReadOnly = value;
				txtAufArzt.ReadOnly = value;
				dtpAufnahme.ReadOnly = value;
				cbBereich.ReadOnly = value;
				txtAufGespraech.ReadOnly = value;
				txtBemerkung.ReadOnly = value;
			}
		}

		#endregion
	}
}
