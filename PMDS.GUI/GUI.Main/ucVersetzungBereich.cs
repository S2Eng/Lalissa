//----------------------------------------------------------------------------
/// <summary>
///	ucVersetzungBereich.cs
/// Erstellt am:	10.1.2005
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
	/// UserControl zur Bearbeitung einer Bereichs - Versetzung
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucVersetzungBereich : QS2.Desktop.ControlManagment.BaseControl
	{
		private Aufenthalt _aufenthalt;

		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseLabel lblVerlegungNach;
        private PMDS.GUI.BaseControls.BereichsCombo cbBereichNach;
        private IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucVersetzungBereich()
		{
			InitializeComponent();
            cbBereichNach.RefreshList();
			Aufenthalt = new Aufenthalt();
			RequiredFields();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung der GUI
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucVersetzungBereich_Load(object sender, System.EventArgs e)
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblVerlegungNach = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBereichNach = new PMDS.GUI.BaseControls.BereichsCombo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBereichNach)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblVerlegungNach
            // 
            this.lblVerlegungNach.AutoSize = true;
            this.lblVerlegungNach.Location = new System.Drawing.Point(8, 35);
            this.lblVerlegungNach.Name = "lblVerlegungNach";
            this.lblVerlegungNach.Size = new System.Drawing.Size(83, 14);
            this.lblVerlegungNach.TabIndex = 2;
            this.lblVerlegungNach.Text = "Verlegung nach";
            // 
            // cbBereichNach
            // 
            this.cbBereichNach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBereichNach.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBereichNach.Location = new System.Drawing.Point(112, 32);
            this.cbBereichNach.Name = "cbBereichNach";
            this.cbBereichNach.Size = new System.Drawing.Size(128, 21);
            this.cbBereichNach.TabIndex = 3;
            // 
            // ucVersetzungBereich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cbBereichNach);
            this.Controls.Add(this.lblVerlegungNach);
            this.Name = "ucVersetzungBereich";
            this.Size = new System.Drawing.Size(256, 72);
            this.Load += new System.EventHandler(this.ucVersetzungBereich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBereichNach)).EndInit();
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

        public string BereichNachText
        {
            get
            {
                return cbBereichNach.Text;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
            cbBereichNach.IDABTEILUNG = Aufenthalt.Verlauf.IDAbteilung_Nach; 
			cbBereichNach.Value	= Aufenthalt.Verlauf.IDBereich;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Aufenthalt.Verlauf.IDBereich= (Guid)cbBereichNach.Value;
 
            //Alle Bezugspersonen löschen
            DataTable table = Aufenthalt.Verlauf.BenutzerBezug;
            if (table != null)
            {
                // get checkMarkers
                foreach (DataRow r in table.Rows)
                {
                        r.Delete();
                }
            }            
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(cbBereichNach);
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

			// cbBereichVon
			GuiUtil.ValidateField(cbBereichNach, (cbBereichNach.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}
	}
}
