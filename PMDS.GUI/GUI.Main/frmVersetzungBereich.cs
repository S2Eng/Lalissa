//----------------------------------------------------------------------------
/// <summary>
///	frmVersetzungBereich.cs
/// Erstellt am:	10.1.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
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
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zur Bereichs - Versetzung eines Patienten
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmVersetzungBereich : frmBase
	{
		private bool _canClose = false;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private PMDS.GUI.ucVersetzungBereich ucVersetzungBereich1;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmVersetzungBereich(Patient patient)
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            labInfo.Text = string.Format(labInfo.Text, patient.FullInfo);

			ucVersetzungBereich1.Aufenthalt = patient.Aufenthalt;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Bereich
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid IDBereich
        {
            get
            {
                return ucVersetzungBereich1.Aufenthalt.Verlauf.IDBereich;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Bereich als Text
        /// </summary>
        //----------------------------------------------------------------------------
        public string BereichNachText
        {
            get
            {
                return ucVersetzungBereich1.BereichNachText;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersetzungBereich));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Aufenthalt aufenthalt1 = new PMDS.BusinessLogic.Aufenthalt();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucVersetzungBereich1 = new PMDS.GUI.ucVersetzungBereich();
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
            this.labInfo.Size = new System.Drawing.Size(310, 88);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Bereichsverlegung von {0}";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(152, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(248, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucVersetzungBereich1
            // 
            this.ucVersetzungBereich1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            aufenthalt1.AufnahmeArt = 0;
            aufenthalt1.Aufnahmezeitpunkt = new System.DateTime(2008, 11, 27, 15, 21, 39, 432);
            aufenthalt1.Ausgleichszahlung = 0D;
            aufenthalt1.BegleitungVon = "";
            aufenthalt1.Bermerkung = "";
            aufenthalt1.Besuchsregelung = "";
            aufenthalt1.Entlassungsbemerkung = "";
            aufenthalt1.Entlassungszeitpunkt = null;
            aufenthalt1.Erwartungen = "";
            aufenthalt1.Fallnummer = 0D;
            aufenthalt1.Gewicht = 0D;
            aufenthalt1.Gruppenkennzahl = "";
            aufenthalt1.ID = new System.Guid("574caa49-8526-4ede-bf15-c90891688b88");
            aufenthalt1.IDAbteilung = System.Guid.Empty;
            aufenthalt1.IDAufenthaltVerlauf = new System.Guid("25bd4410-b714-4930-8f7f-3e6a12f5dcd4");
            aufenthalt1.IDBenutzer_Aufnahme = System.Guid.Empty;
            aufenthalt1.IDBenutzer_Entlassung = System.Guid.Empty;
            aufenthalt1.IDBereich = System.Guid.Empty;
            aufenthalt1.IDEinrichtung_Aufnahme = System.Guid.Empty;
            aufenthalt1.IDEinrichtung_Entlassung = System.Guid.Empty;
            aufenthalt1.IDErstkontakt = System.Guid.Empty;
            aufenthalt1.IDKlinik = System.Guid.Empty;
            aufenthalt1.IDPatient = System.Guid.Empty;
            aufenthalt1.IDUrlaub = System.Guid.Empty;
            aufenthalt1.NaechsteEvaluierung = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.NaechsteEvaluierungBemerkung = "";
            aufenthalt1.Postregelung = "";
            aufenthalt1.PsychischeAuff = "";
            aufenthalt1.SofortMassnahmen = "";
            aufenthalt1.SomatischeAuff = "";
            aufenthalt1.SonstigeBesonderheiten = "";
            aufenthalt1.SonstigeRegelung = "";
            aufenthalt1.TaschegeldVortragDatum = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.TaschengeldSollstand = 0D;
            aufenthalt1.TaschengeldVortragBetrag = 0D;
            aufenthalt1.Verfuegungsdatum = null;
            aufenthalt1.VerhaltenAufnahme = "";
            this.ucVersetzungBereich1.Aufenthalt = aufenthalt1;
            this.ucVersetzungBereich1.Location = new System.Drawing.Point(0, 88);
            this.ucVersetzungBereich1.Name = "ucVersetzungBereich1";
            this.ucVersetzungBereich1.Size = new System.Drawing.Size(312, 64);
            this.ucVersetzungBereich1.TabIndex = 4;
            // 
            // frmVersetzungBereich
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(310, 196);
            this.ControlBox = false;
            this.Controls.Add(this.ucVersetzungBereich1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVersetzungBereich";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bereichsverlegung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmVersetzungBereich_Load);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ucVersetzungBereich1.ValidateFields())
				return;

			ucVersetzungBereich1.UpdateDATA();
    		ucVersetzungBereich1.Aufenthalt.Write();

            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            PMDSBusiness1.UpdateAufenthaltID(ucVersetzungBereich1.Aufenthalt.ID, ucVersetzungBereich1.Aufenthalt.Verlauf.IDBereich); 
			_canClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

        private void frmVersetzungBereich_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }
	}
}
