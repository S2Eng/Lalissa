//----------------------------------------------------------------------------
/// <summary>
///	ucPatientBem.cs
/// Erstellt am:	20.10.2004
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
	/// UserControl zur Bearbeitung einer Patienten Bemerkung
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucPatientBem : QS2.Desktop.ControlManagment.BaseControl, IUCBase, IReadOnly
	{
		private bool	_valueChangeEnabled = true;
		private PatientenBemerkung _bemerkung;
		public event EventHandler ValueChanged;
        public frmPatientBem mainWindow;

        private System.Windows.Forms.ErrorProvider errorProvider1;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblDatum;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpDatum;
        private IContainer components;



		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucPatientBem()
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBemerkung.Location = new System.Drawing.Point(112, 32);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(384, 120);
            this.txtBemerkung.TabIndex = 5;
            this.txtBemerkung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 32);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 4;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(8, 11);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(38, 14);
            this.lblDatum.TabIndex = 0;
            this.lblDatum.Text = "Datum";
            // 
            // dtpDatum
            // 
            this.dtpDatum.FormatString = "";
            this.dtpDatum.Location = new System.Drawing.Point(112, 8);
            this.dtpDatum.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(128, 21);
            this.dtpDatum.TabIndex = 1;
            this.dtpDatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ucPatientBem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.txtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.dtpDatum);
            this.Name = "ucPatientBem";
            this.Size = new System.Drawing.Size(512, 160);
            this.Load += new System.EventHandler(this.ucPatientBem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufenthalt setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public PatientenBemerkung Bemerkung
		{
			get	
			{	
				return _bemerkung;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Bemerkung");

				_valueChangeEnabled = false;
				_bemerkung = value;
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
			dtpDatum.Value		= Bemerkung.Datum;
			txtBemerkung.Text	= Bemerkung.Bemerkung;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Bemerkung.Datum		= (DateTime)dtpDatum.Value;
			Bemerkung.Bemerkung	= txtBemerkung.Text;
            if (this.mainWindow._typ == _typBemerkung.bemerkung)
            {
                Bemerkung.IstDekurs = false ;
            }
            else if (this.mainWindow._typ == _typBemerkung.dekurs)
            {
                Bemerkung.IstDekurs = true;
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpDatum);
			GuiUtil.ValidateRequired(txtBemerkung);
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

			// dtpDatum
			GuiUtil.ValidateField(dtpDatum, (dtpDatum.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtBemerkung
			GuiUtil.ValidateField(txtBemerkung, (txtBemerkung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element
		/// </summary>
		//----------------------------------------------------------------------------
		public bool New()
		{
			PatientenBemerkung obj = new PatientenBemerkung();

			obj.IDPatient = IDPatient;
			obj.IDBenutzer= ENV.USERID;

			Bemerkung = obj;
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(object id)
		{
			PatientenBemerkung obj = new PatientenBemerkung((Guid)id);
			Bemerkung = obj;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read()
		{
			Bemerkung.Read();
			Bemerkung = Bemerkung;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten schreiben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
			Bemerkung.Write();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten löschen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Delete()
		{
			Bemerkung.Delete();
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
		/// Filter für ucPatientBemEdit
		/// </summary>
		//----------------------------------------------------------------------------
		private Guid _patient = Guid.Empty;
		public Guid IDPatient
		{
			get	{	return _patient;	}
			set	{	_patient = value;	}
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			//return  PatientenBemerkung.alleBemerkungenPatient(IDPatient,false );
            return new DataTable();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return Bemerkung;				}
			set	{	Bemerkung = (PatientenBemerkung)value;	}
		}

		#endregion

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
				return dtpDatum.ReadOnly;
			}
			set
			{
				dtpDatum.ReadOnly = value;
				txtBemerkung.ReadOnly = value;
			}
		}

		#endregion

        private void ucPatientBem_Load(object sender, EventArgs e)
        {

        }


	}
}
