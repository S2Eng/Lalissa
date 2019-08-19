//----------------------------------------------------------------------------
/// <summary>
///	ucGruppe.cs
/// Erstellt am:	14.10.2004
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
	/// UserControl zur Manipulation eines GruppenRechts
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucGruppe : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private Gruppe _gruppe;
		private bool _valueChangeEnabled = true;
        private IContainer components;
        public event EventHandler ValueChanged;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpGruppenRechte;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBezeichnung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
		private PMDS.GUI.ucRecht ucRecht1;
		private System.Windows.Forms.ErrorProvider errorProvider1;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucGruppe()
		{
			InitializeComponent();
			New();
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
            this.grpGruppenRechte = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucRecht1 = new PMDS.GUI.ucRecht();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpGruppenRechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGruppenRechte
            // 
            this.grpGruppenRechte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGruppenRechte.Controls.Add(this.ucRecht1);
            this.grpGruppenRechte.Controls.Add(this.lblBezeichnung);
            this.grpGruppenRechte.Controls.Add(this.txtBezeichnung);
            this.grpGruppenRechte.Location = new System.Drawing.Point(8, 8);
            this.grpGruppenRechte.Name = "grpGruppenRechte";
            this.grpGruppenRechte.Size = new System.Drawing.Size(472, 288);
            this.grpGruppenRechte.TabIndex = 0;
            this.grpGruppenRechte.TabStop = false;
            this.grpGruppenRechte.Text = "Gruppen-Rechte";
            // 
            // ucRecht1
            // 
            this.ucRecht1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRecht1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucRecht1.Location = new System.Drawing.Point(16, 48);
            this.ucRecht1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRecht1.Name = "ucRecht1";
            this.ucRecht1.ReadOnly = false;
            this.ucRecht1.Size = new System.Drawing.Size(448, 232);
            this.ucRecht1.TabIndex = 4;
            this.ucRecht1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(16, 27);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(54, 14);
            this.lblBezeichnung.TabIndex = 2;
            this.lblBezeichnung.Text = "Bezeichn.";
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            this.txtBezeichnung.Appearance = appearance1;
            this.txtBezeichnung.BackColor = System.Drawing.Color.White;
            this.txtBezeichnung.Location = new System.Drawing.Point(80, 24);
            this.txtBezeichnung.MaxLength = 255;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Size = new System.Drawing.Size(376, 21);
            this.txtBezeichnung.TabIndex = 3;
            this.txtBezeichnung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucGruppe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.grpGruppenRechte);
            this.Name = "ucGruppe";
            this.Size = new System.Drawing.Size(488, 304);
            this.grpGruppenRechte.ResumeLayout(false);
            this.grpGruppenRechte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppe setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public Gruppe Gruppe
		{
			get	
			{	
				return _gruppe;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Gruppe");

				_valueChangeEnabled = false;
				_gruppe = value;
				UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
			txtBezeichnung.Text	= Gruppe.Bezeichnung;
			ucRecht1.SetGruppe(Gruppe, true);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Gruppe.Bezeichnung	= txtBezeichnung.Text;
            ucRecht1.GetGruppe(Gruppe);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element
		/// </summary>
		//----------------------------------------------------------------------------
		public bool New()
		{
			Gruppe = new Gruppe();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(object id)
		{
			Gruppe obj = new Gruppe((Guid)id);
			Gruppe = obj;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read()
		{
			Gruppe.Read();
			Gruppe = Gruppe;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten schreiben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
			Gruppe.Write();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten löschen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Delete()
		{
			Gruppe.Delete();
			New();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtBezeichnung);
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

			txtBezeichnung.Text = txtBezeichnung.Text.Trim();

			// txtBezeichnung
			GuiUtil.ValidateField(txtBezeichnung, (txtBezeichnung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return Gruppe.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return Gruppe;					}
			set	{	Gruppe = (Gruppe)value;	}
		}

		#endregion
	}
}
