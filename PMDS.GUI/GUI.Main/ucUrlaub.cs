//----------------------------------------------------------------------------
/// <summary>
///	ucUrlaub.cs
/// Erstellt am:	04.03.2005
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

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation eines Urlaubs
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucUrlaub : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool	_valueChangeEnabled = true;
		private UrlaubVerlauf	_Urlaub;
		public event EventHandler ValueChanged;
        private QS2.Desktop.ControlManagment.BaseLabel labUrlaub;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBeginn;
        public BaseControls.AuswahlGruppeCombo txtUrlaub;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnde;
		private System.ComponentModel.IContainer components = null;
		private QS2.Desktop.ControlManagment.BaseLabel labBeginn;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseLabel labEnde;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucUrlaub()
		{
			InitializeComponent();
			Urlaub = new UrlaubVerlauf();
			RequiredFields();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung der GUI
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucUrlaub_Load(object sender, System.EventArgs e)
		{
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
            this.labBeginn = new QS2.Desktop.ControlManagment.BaseLabel();
            this.labUrlaub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBeginn = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.txtUrlaub = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.labEnde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEnde = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labBeginn
            // 
            this.labBeginn.AutoSize = true;
            this.labBeginn.Location = new System.Drawing.Point(8, 11);
            this.labBeginn.Name = "labBeginn";
            this.labBeginn.Size = new System.Drawing.Size(40, 14);
            this.labBeginn.TabIndex = 0;
            this.labBeginn.Text = "Beginn";
            // 
            // labUrlaub
            // 
            this.labUrlaub.AutoSize = true;
            this.labUrlaub.Location = new System.Drawing.Point(8, 59);
            this.labUrlaub.Name = "labUrlaub";
            this.labUrlaub.Size = new System.Drawing.Size(74, 14);
            this.labUrlaub.TabIndex = 4;
            this.labUrlaub.Text = "Beschreibung";
            // 
            // dtpBeginn
            // 
            this.dtpBeginn.FormatString = "";
            this.dtpBeginn.Location = new System.Drawing.Point(104, 8);
            this.dtpBeginn.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpBeginn.Name = "dtpBeginn";
            this.dtpBeginn.Size = new System.Drawing.Size(128, 21);
            this.dtpBeginn.TabIndex = 1;
            this.dtpBeginn.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtUrlaub
            // 
            this.txtUrlaub.AddEmptyEntry = false;
            this.txtUrlaub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlaub.Group = "URL";
            this.txtUrlaub.ID_PEP = -1;
            this.txtUrlaub.Location = new System.Drawing.Point(104, 56);
            this.txtUrlaub.Name = "txtUrlaub";
            this.txtUrlaub.ShowAddButton = true;
            this.txtUrlaub.Size = new System.Drawing.Size(344, 21);
            this.txtUrlaub.TabIndex = 5;
            this.txtUrlaub.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(8, 35);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(31, 14);
            this.labEnde.TabIndex = 2;
            this.labEnde.Text = "Ende";
            // 
            // dtpEnde
            // 
            this.dtpEnde.FormatString = "";
            this.dtpEnde.Location = new System.Drawing.Point(104, 32);
            this.dtpEnde.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(128, 21);
            this.dtpEnde.TabIndex = 3;
            this.dtpEnde.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucUrlaub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.txtUrlaub);
            this.Controls.Add(this.labBeginn);
            this.Controls.Add(this.labUrlaub);
            this.Controls.Add(this.dtpBeginn);
            this.Name = "ucUrlaub";
            this.Size = new System.Drawing.Size(464, 88);
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// URLAUB setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public UrlaubVerlauf Urlaub
		{
			get	
			{	
				return _Urlaub;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Urlaub");

				_valueChangeEnabled = false;
				_Urlaub = value;
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
			if (Urlaub.IsOpenUrlaub)
			{
				// Urlaub beginn bearbeiten
				dtpBeginn.Value		= Urlaub.StartDatum;
				dtpEnde.Value		= null;
				txtUrlaub.Text		= Urlaub.Text;

				dtpBeginn.Enabled	= true;
				dtpEnde.Enabled		= false;
				txtUrlaub.Enabled	= true;
			}
			else
			{
				// Urlaub ende bearbeiten
				dtpBeginn.Value		= Urlaub.StartDatum;
				dtpEnde.Value		= Urlaub.EndeDatum;
				txtUrlaub.Text		= Urlaub.Text;

				dtpBeginn.Enabled	= false;
				dtpEnde.Enabled		= true;
				txtUrlaub.Enabled	= false;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			if (Urlaub.IsOpenUrlaub)
			{
				// Urlaub beginn bearbeiten
				Urlaub.StartDatum	= dtpBeginn.DateTime;
				Urlaub.Text			= txtUrlaub.Text;
			}
			else
			{
				// Urlaub ende bearbeiten
				Urlaub.EndeDatum	= dtpEnde.DateTime;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpBeginn);
			GuiUtil.ValidateRequired(dtpEnde);
			GuiUtil.ValidateRequired(txtUrlaub);
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
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// dtpBeginn
			if (dtpBeginn.Enabled)
			{
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                bool DatOK = b.checkDateRückmeldung(dtpBeginn.DateTime, PflegeEintragTyp.NONE);
                if (!DatOK)
                {
                    bError = true;
                }
			}


			// dtpEnde
			if (dtpEnde.Enabled)
			{
				GuiUtil.ValidateField(dtpEnde, (dtpBeginn.DateTime <= dtpEnde.DateTime) ,
					ENV.String("GUI.E_NO_FUTURE_DATE"), ref bError, bInfo, errorProvider1);
			}

			// txtUrlaub
			if (txtUrlaub.Enabled)
			{
				GuiUtil.ValidateField(txtUrlaub, (txtUrlaub.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}

			return !bError;
		}
	}
}
