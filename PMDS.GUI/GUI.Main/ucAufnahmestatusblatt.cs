//----------------------------------------------------------------------------
/// <summary>
///	ucAufnahmestatusblatt.cs
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
	/// UserControl zur Bearbeitung eines Aufnahmestatusblatt
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucAufnahmestatusblatt : QS2.Desktop.ControlManagment.BaseControl, IReadOnly, IWizardPage
	{
		private Aufenthalt	_aufenthalt;

		private System.Windows.Forms.ErrorProvider errorProvider1;
		private PMDS.GUI.BaseControls.EinrichtungsCombo cbEinrichtung;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbAufnahmeArt;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSofortmassnahmen;
		private QS2.Desktop.ControlManagment.BaseLabel lblRelevanteSofortmaﬂnahmen;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSonstBesonderheit;
		private QS2.Desktop.ControlManagment.BaseLabel lblSonstigeBesonderheiten;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtVerhalten;
		private QS2.Desktop.ControlManagment.BaseLabel lblVerhaltenAufnahme;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtPsychisch;
		private QS2.Desktop.ControlManagment.BaseLabel lblPSYCHISCHEAuff‰lligkeiten;
		private QS2.Desktop.ControlManagment.BaseLabel lblKommtWoher;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSomatisch;
		private QS2.Desktop.ControlManagment.BaseLabel SOMATISCHEAuff‰lligkeiten;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBegleitung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBegleitungVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblAufnahmeart;
        private IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucAufnahmestatusblatt()
		{
			InitializeComponent();
			Aufenthalt = new Aufenthalt();
			RequiredFields();
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbEinrichtung = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.cbAufnahmeArt = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.txtSofortmassnahmen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblRelevanteSofortmaﬂnahmen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSonstBesonderheit = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSonstigeBesonderheiten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVerhalten = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblVerhaltenAufnahme = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPsychisch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPSYCHISCHEAuff‰lligkeiten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKommtWoher = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSomatisch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.SOMATISCHEAuff‰lligkeiten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBegleitung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBegleitungVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAufnahmeart = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAufnahmeArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSofortmassnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstBesonderheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerhalten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPsychisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSomatisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBegleitung)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbEinrichtung
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.cbEinrichtung.Appearance = appearance1;
            this.cbEinrichtung.BackColor = System.Drawing.Color.White;
            this.cbEinrichtung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbEinrichtung.Location = new System.Drawing.Point(112, 56);
            this.cbEinrichtung.Name = "cbEinrichtung";
            this.cbEinrichtung.Size = new System.Drawing.Size(128, 21);
            this.cbEinrichtung.TabIndex = 21;
            // 
            // cbAufnahmeArt
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.cbAufnahmeArt.Appearance = appearance2;
            this.cbAufnahmeArt.BackColor = System.Drawing.Color.White;
            this.cbAufnahmeArt.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Rettung";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Polizei";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Privat";
            this.cbAufnahmeArt.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbAufnahmeArt.Location = new System.Drawing.Point(112, 8);
            this.cbAufnahmeArt.Name = "cbAufnahmeArt";
            this.cbAufnahmeArt.Size = new System.Drawing.Size(128, 21);
            this.cbAufnahmeArt.TabIndex = 17;
            this.cbAufnahmeArt.ValueChanged += new System.EventHandler(this.cbAufnahmeArt_ValueChanged);
            // 
            // txtSofortmassnahmen
            // 
            this.txtSofortmassnahmen.AcceptsReturn = true;
            this.txtSofortmassnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            this.txtSofortmassnahmen.Appearance = appearance3;
            this.txtSofortmassnahmen.BackColor = System.Drawing.Color.White;
            this.txtSofortmassnahmen.Location = new System.Drawing.Point(168, 352);
            this.txtSofortmassnahmen.Multiline = true;
            this.txtSofortmassnahmen.Name = "txtSofortmassnahmen";
            this.txtSofortmassnahmen.Size = new System.Drawing.Size(344, 72);
            this.txtSofortmassnahmen.TabIndex = 31;
            // 
            // lblRelevanteSofortmaﬂnahmen
            // 
            this.lblRelevanteSofortmaﬂnahmen.AutoSize = true;
            this.lblRelevanteSofortmaﬂnahmen.Location = new System.Drawing.Point(8, 352);
            this.lblRelevanteSofortmaﬂnahmen.Name = "lblRelevanteSofortmaﬂnahmen";
            this.lblRelevanteSofortmaﬂnahmen.Size = new System.Drawing.Size(152, 14);
            this.lblRelevanteSofortmaﬂnahmen.TabIndex = 30;
            this.lblRelevanteSofortmaﬂnahmen.Text = "Relevante Sofortmaﬂnahmen";
            // 
            // txtSonstBesonderheit
            // 
            this.txtSonstBesonderheit.AcceptsReturn = true;
            this.txtSonstBesonderheit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            this.txtSonstBesonderheit.Appearance = appearance4;
            this.txtSonstBesonderheit.BackColor = System.Drawing.Color.White;
            this.txtSonstBesonderheit.Location = new System.Drawing.Point(168, 288);
            this.txtSonstBesonderheit.Multiline = true;
            this.txtSonstBesonderheit.Name = "txtSonstBesonderheit";
            this.txtSonstBesonderheit.Size = new System.Drawing.Size(344, 56);
            this.txtSonstBesonderheit.TabIndex = 29;
            // 
            // lblSonstigeBesonderheiten
            // 
            this.lblSonstigeBesonderheiten.AutoSize = true;
            this.lblSonstigeBesonderheiten.Location = new System.Drawing.Point(8, 288);
            this.lblSonstigeBesonderheiten.Name = "lblSonstigeBesonderheiten";
            this.lblSonstigeBesonderheiten.Size = new System.Drawing.Size(131, 14);
            this.lblSonstigeBesonderheiten.TabIndex = 28;
            this.lblSonstigeBesonderheiten.Text = "Sonstige Besonderheiten";
            // 
            // txtVerhalten
            // 
            this.txtVerhalten.AcceptsReturn = true;
            this.txtVerhalten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            this.txtVerhalten.Appearance = appearance5;
            this.txtVerhalten.BackColor = System.Drawing.Color.White;
            this.txtVerhalten.Location = new System.Drawing.Point(168, 224);
            this.txtVerhalten.Multiline = true;
            this.txtVerhalten.Name = "txtVerhalten";
            this.txtVerhalten.Size = new System.Drawing.Size(344, 56);
            this.txtVerhalten.TabIndex = 27;
            // 
            // lblVerhaltenAufnahme
            // 
            this.lblVerhaltenAufnahme.AutoSize = true;
            this.lblVerhaltenAufnahme.Location = new System.Drawing.Point(8, 224);
            this.lblVerhaltenAufnahme.Name = "lblVerhaltenAufnahme";
            this.lblVerhaltenAufnahme.Size = new System.Drawing.Size(145, 14);
            this.lblVerhaltenAufnahme.TabIndex = 26;
            this.lblVerhaltenAufnahme.Text = "Verhalten bei der Aufnahme";
            // 
            // txtPsychisch
            // 
            this.txtPsychisch.AcceptsReturn = true;
            this.txtPsychisch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.White;
            this.txtPsychisch.Appearance = appearance6;
            this.txtPsychisch.BackColor = System.Drawing.Color.White;
            this.txtPsychisch.Location = new System.Drawing.Point(168, 160);
            this.txtPsychisch.Multiline = true;
            this.txtPsychisch.Name = "txtPsychisch";
            this.txtPsychisch.Size = new System.Drawing.Size(344, 56);
            this.txtPsychisch.TabIndex = 25;
            // 
            // lblPSYCHISCHEAuff‰lligkeiten
            // 
            this.lblPSYCHISCHEAuff‰lligkeiten.AutoSize = true;
            this.lblPSYCHISCHEAuff‰lligkeiten.Location = new System.Drawing.Point(8, 160);
            this.lblPSYCHISCHEAuff‰lligkeiten.Name = "lblPSYCHISCHEAuff‰lligkeiten";
            this.lblPSYCHISCHEAuff‰lligkeiten.Size = new System.Drawing.Size(152, 14);
            this.lblPSYCHISCHEAuff‰lligkeiten.TabIndex = 24;
            this.lblPSYCHISCHEAuff‰lligkeiten.Text = "PSYCHISCHE Auff‰lligkeiten";
            // 
            // lblKommtWoher
            // 
            this.lblKommtWoher.AutoSize = true;
            this.lblKommtWoher.Location = new System.Drawing.Point(8, 59);
            this.lblKommtWoher.Name = "lblKommtWoher";
            this.lblKommtWoher.Size = new System.Drawing.Size(74, 14);
            this.lblKommtWoher.TabIndex = 20;
            this.lblKommtWoher.Text = "Kommt woher";
            // 
            // txtSomatisch
            // 
            this.txtSomatisch.AcceptsReturn = true;
            this.txtSomatisch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            this.txtSomatisch.Appearance = appearance7;
            this.txtSomatisch.BackColor = System.Drawing.Color.White;
            this.txtSomatisch.Location = new System.Drawing.Point(168, 96);
            this.txtSomatisch.Multiline = true;
            this.txtSomatisch.Name = "txtSomatisch";
            this.txtSomatisch.Size = new System.Drawing.Size(344, 56);
            this.txtSomatisch.TabIndex = 23;
            // 
            // SOMATISCHEAuff‰lligkeiten
            // 
            this.SOMATISCHEAuff‰lligkeiten.AutoSize = true;
            this.SOMATISCHEAuff‰lligkeiten.Location = new System.Drawing.Point(8, 96);
            this.SOMATISCHEAuff‰lligkeiten.Name = "SOMATISCHEAuff‰lligkeiten";
            this.SOMATISCHEAuff‰lligkeiten.Size = new System.Drawing.Size(153, 14);
            this.SOMATISCHEAuff‰lligkeiten.TabIndex = 22;
            this.SOMATISCHEAuff‰lligkeiten.Text = "SOMATISCHE Auff‰lligkeiten";
            // 
            // txtBegleitung
            // 
            this.txtBegleitung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.White;
            this.txtBegleitung.Appearance = appearance8;
            this.txtBegleitung.BackColor = System.Drawing.Color.White;
            this.txtBegleitung.Location = new System.Drawing.Point(112, 32);
            this.txtBegleitung.MaxLength = 255;
            this.txtBegleitung.Name = "txtBegleitung";
            this.txtBegleitung.Size = new System.Drawing.Size(400, 21);
            this.txtBegleitung.TabIndex = 19;
            // 
            // lblBegleitungVon
            // 
            this.lblBegleitungVon.AutoSize = true;
            this.lblBegleitungVon.Location = new System.Drawing.Point(8, 35);
            this.lblBegleitungVon.Name = "lblBegleitungVon";
            this.lblBegleitungVon.Size = new System.Drawing.Size(79, 14);
            this.lblBegleitungVon.TabIndex = 18;
            this.lblBegleitungVon.Text = "Begleitung von";
            // 
            // lblAufnahmeart
            // 
            this.lblAufnahmeart.AutoSize = true;
            this.lblAufnahmeart.Location = new System.Drawing.Point(8, 11);
            this.lblAufnahmeart.Name = "lblAufnahmeart";
            this.lblAufnahmeart.Size = new System.Drawing.Size(69, 14);
            this.lblAufnahmeart.TabIndex = 16;
            this.lblAufnahmeart.Text = "Aufnahmeart";
            // 
            // ucAufnahmestatusblatt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cbEinrichtung);
            this.Controls.Add(this.cbAufnahmeArt);
            this.Controls.Add(this.txtSofortmassnahmen);
            this.Controls.Add(this.lblRelevanteSofortmaﬂnahmen);
            this.Controls.Add(this.txtSonstBesonderheit);
            this.Controls.Add(this.lblSonstigeBesonderheiten);
            this.Controls.Add(this.txtVerhalten);
            this.Controls.Add(this.lblVerhaltenAufnahme);
            this.Controls.Add(this.txtPsychisch);
            this.Controls.Add(this.lblPSYCHISCHEAuff‰lligkeiten);
            this.Controls.Add(this.lblKommtWoher);
            this.Controls.Add(this.txtSomatisch);
            this.Controls.Add(this.SOMATISCHEAuff‰lligkeiten);
            this.Controls.Add(this.txtBegleitung);
            this.Controls.Add(this.lblBegleitungVon);
            this.Controls.Add(this.lblAufnahmeart);
            this.Name = "ucAufnahmestatusblatt";
            this.Size = new System.Drawing.Size(528, 432);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAufnahmeArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSofortmassnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstBesonderheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerhalten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPsychisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSomatisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBegleitung)).EndInit();
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
		/// Daten nach GUI ¸bertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
			cbAufnahmeArt.Value			= Aufenthalt.AufnahmeArt;
			txtBegleitung.Text			= Aufenthalt.BegleitungVon;
			cbEinrichtung.Value			= Aufenthalt.IDEinrichtung_Aufnahme;
			txtSomatisch.Text			= Aufenthalt.SomatischeAuff;
			txtPsychisch.Text			= Aufenthalt.PsychischeAuff;
			txtVerhalten.Text			= Aufenthalt.VerhaltenAufnahme;
			txtSonstBesonderheit.Text	= Aufenthalt.SonstigeBesonderheiten;
			txtSofortmassnahmen.Text	= Aufenthalt.SofortMassnahmen;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten ¸bertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Aufenthalt.AufnahmeArt				= (int)cbAufnahmeArt.Value;
			Aufenthalt.BegleitungVon			= txtBegleitung.Text;
			Aufenthalt.IDEinrichtung_Aufnahme	= (Guid)cbEinrichtung.Value;
			Aufenthalt.SomatischeAuff			= txtSomatisch.Text;
			Aufenthalt.PsychischeAuff			= txtPsychisch.Text;
			Aufenthalt.VerhaltenAufnahme		= txtVerhalten.Text;
			Aufenthalt.SonstigeBesonderheiten	= txtSonstBesonderheit.Text;
			Aufenthalt.SofortMassnahmen			= txtSofortmassnahmen.Text;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benˆtigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(cbAufnahmeArt);
			GuiUtil.ValidateRequired(txtBegleitung);
			GuiUtil.ValidateRequired(cbEinrichtung);
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

			// cbAufnahmeArt
			GuiUtil.ValidateField(cbAufnahmeArt, (cbAufnahmeArt.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtBegleitung
			if (txtBegleitung.Enabled)
			{
				GuiUtil.ValidateField(txtBegleitung, (txtBegleitung.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}

			// cbEinrichtung
			GuiUtil.ValidateField(cbEinrichtung, (cbEinrichtung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AufnahmeArt ƒnderung
		/// </summary>
		//----------------------------------------------------------------------------
		private void cbAufnahmeArt_ValueChanged(object sender, System.EventArgs e)
		{
			AufnahmeArt art = (AufnahmeArt)cbAufnahmeArt.Value;
			txtBegleitung.Enabled = (art == AufnahmeArt.PRIVAT);
			if(!txtBegleitung.Enabled)
				txtBegleitung.Clear();
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
				return cbAufnahmeArt.ReadOnly;
			}
			set
			{
				cbAufnahmeArt.ReadOnly = value;
				txtBegleitung.ReadOnly = value;
				cbEinrichtung.ReadOnly = value;
				txtSomatisch.ReadOnly = value;
				txtPsychisch.ReadOnly = value;
				txtVerhalten.ReadOnly = value;
				txtSonstBesonderheit.ReadOnly = value;
				txtSofortmassnahmen.ReadOnly = value;
			}
		}

		#endregion
	}
}
