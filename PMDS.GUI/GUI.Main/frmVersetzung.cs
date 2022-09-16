//----------------------------------------------------------------------------
/// <summary>
///	frmVersetzung.cs
/// Erstellt am:	13.10.2004
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
using PMDS.DB;
using System.Linq;



namespace PMDS.GUI
{
    

	public class frmVersetzung : frmBase
	{
		private bool _canClose = false;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucVersetzung ucVersetzung1;
		private System.ComponentModel.IContainer components;






		public frmVersetzung(Patient patient)
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            labInfo.Text = string.Format(labInfo.Text, patient.FullInfo);

			patient.Aufenthalt.Versetzung(ENV.USERID);
			ucVersetzung1.Aufenthalt = patient.Aufenthalt;
		}






        public Guid IDAbteilung
        {
            get
            {
                return ucVersetzung1.IDAbteilungNach;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersetzung));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucVersetzung1 = new PMDS.GUI.ucVersetzung();
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
            this.labInfo.Size = new System.Drawing.Size(653, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Verlegung von {0}";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(503, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(599, 314);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucVersetzung1
            // 
            this.ucVersetzung1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVersetzung1.Location = new System.Drawing.Point(0, 48);
            this.ucVersetzung1.Name = "ucVersetzung1";
            this.ucVersetzung1.Size = new System.Drawing.Size(655, 258);
            this.ucVersetzung1.TabIndex = 4;
            // 
            // frmVersetzung
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(653, 350);
            this.ControlBox = false;
            this.Controls.Add(this.ucVersetzung1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVersetzung";
            this.ShowInTaskbar = false;
            this.Text = "Verlegung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmVersetzung_Load);
            this.ResumeLayout(false);

		}
		#endregion


        

		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ucVersetzung1.ValidateFields())
				return;

            Patient pat = new Patient(ENV.CurrentIDPatient);
            Guid IDAufenthalt = Aufenthalt.LastByPatient(pat.ID);
            Aufenthalt auf = new Aufenthalt(IDAufenthalt);

            Guid IDAbteilung_Von = auf.IDAbteilung;
            Guid IDBereich_Von = auf.IDBereich;
            Guid IDAbteilung_Nach = (Guid)this.ucVersetzung1.cbAbteilung.Value;
            Guid IDBereich_Nach = (Guid)this.ucVersetzung1.cboBereich.Value;
            string Bemerkung = this.ucVersetzung1.txtBemerkung.Text.ToString().Trim();
            DateTime Datum = this.ucVersetzung1.dtpVersetzung.DateTime;

            if (!auf.IDAbteilung.Equals(IDAbteilung_Nach))
            {
                int CountBezugspersonen = 0;
                //Alle Bezugspersonen löschen
                DataTable table = auf.Verlauf.BenutzerBezug;
                if (table != null)
                {
                    foreach (DataRow r in table.Rows)
                    {
                        CountBezugspersonen++;
                        r.Delete();
                    }
                }

                string txtBezugspersonen = CountBezugspersonen > 0 ? "\n\r" + CountBezugspersonen.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bezugspersonenzuordnung werden gelöscht. ") : "";
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben die Abteilung geändert!") + txtBezugspersonen + 
                                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rBitte überprüfen Sie die Pflegeplanung auf abteilungsspezifische Planungseinträge!\n\r\n\rWollen Sie fortfahren?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), MessageBoxButtons.YesNo, true);
                if (res == DialogResult.No)
                {
                    _canClose = true;
                    return;
                }
            }
            auf.IDAbteilung = IDAbteilung_Nach;
            auf.IDBereich = IDBereich_Nach;
        
            //Neuen Aufenthaltsverlauf für Versetzung erzeugen
            auf.NewVerlauf();

            Guid IDAufenthaltVerlauf = auf.Verlauf.ID;
            auf.Verlauf.IDAufenthalt = IDAufenthalt;
            auf.Verlauf.IDAbteilung_Von = IDAbteilung_Von;
            auf.Verlauf.IDAbteilung_Nach = IDAbteilung_Nach;
            auf.Verlauf.IDBereich = IDBereich_Nach;
            auf.Verlauf.Bemerkung = Bemerkung;
            auf.Verlauf.Datum = Datum;
            auf.Verlauf.IDBenutzer = ENV.USERID;

            auf.IDAufenthaltVerlauf = IDAufenthaltVerlauf;
            auf.Write();

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                PMDS.db.Entities.Patient rPatient = b.getPatient(pat.ID, db);
                rPatient.IDAbteilung = auf.IDAbteilung;
                rPatient.IDBereich = auf.IDBereich;
                db.SaveChanges();
            }

            PMDS.DB.DBAbteilung abt = new DB.DBAbteilung();               
            string AbteilungBez = abt.getAbteilungBez(IDAbteilung_Nach).Trim();
            string BereichBez = abt.getBereichBez(IDBereich_Nach).Trim();
            string Text = "";
            if (IDAbteilung_Von != IDAbteilung_Nach)
                Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Abteilung ist ") + AbteilungBez;

            if (Text == "")
                Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Neuer");
            else
                Text += QS2.Desktop.ControlManagment.ControlManagment.getRes(", neuer");
            Text += QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bereich ist ") + BereichBez + ". ";

            if (Bemerkung != "")
                Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: ") + Bemerkung;

            
            PflegeEintrag pe = PflegeEintrag.NewByAufenthalt(IDAufenthalt, QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), PflegeEintragTyp.DEKURS, "", false);
            pe.Text = Text;
            pe.Write();
                
            _canClose = true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

        private void frmVersetzung_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }

	}
}
