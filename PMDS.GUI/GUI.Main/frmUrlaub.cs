//----------------------------------------------------------------------------
/// <summary>
///	frmUrlaub.cs
/// Erstellt am:	04.03.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Bearbeiten der Aufenthalt-Urlaube
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmUrlaub : frmBase
	{
		private bool _bCanclose = false;

		private Patient _patient = null;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private PMDS.GUI.ucUrlaub ucUrlaub1;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmUrlaub(Patient patient)
		{
			_patient = patient;
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            labInfo.Text = string.Format(labInfo.Text, patient.FullInfo);

			// offenen Urlaub beenden, ansonsten neuen erzeugen
			if (patient.Aufenthalt.HasUrlaub)
				patient.Aufenthalt.EndUrlaub();
			else
				patient.Aufenthalt.NewUrlaub();

			ucUrlaub1.Urlaub = patient.Aufenthalt.Urlaub;

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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.UrlaubVerlauf urlaubVerlauf1 = new PMDS.BusinessLogic.UrlaubVerlauf();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucUrlaub1 = new PMDS.GUI.ucUrlaub();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = 5;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = 4;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOK.Appearance = appearance2;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(392, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labInfo
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance3;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(448, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Abwesenheit von {0}";
            // 
            // ucUrlaub1
            // 
            this.ucUrlaub1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUrlaub1.Location = new System.Drawing.Point(0, 48);
            this.ucUrlaub1.Name = "ucUrlaub1";
            this.ucUrlaub1.Size = new System.Drawing.Size(448, 94);
            this.ucUrlaub1.TabIndex = 1;
            urlaubVerlauf1.EndeDatum = null;
            urlaubVerlauf1.ID = new System.Guid("e2d46737-4ef7-4143-a152-34f6782d2608");
            urlaubVerlauf1.IDAufenthalt = System.Guid.Empty;
            urlaubVerlauf1.StartDatum = new System.DateTime(2008, 11, 27, 15, 22, 32, 519);
            urlaubVerlauf1.Text = "";
            this.ucUrlaub1.Urlaub = urlaubVerlauf1;
            // 
            // frmUrlaub
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(448, 182);
            this.ControlBox = false;
            this.Controls.Add(this.ucUrlaub1);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUrlaub";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abwesenheit  ...";
            this.Load += new System.EventHandler(this.frmUrlaub_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Felder vorher überprüfen
                if (!ucUrlaub1.ValidateFields())
                    return;

                ucUrlaub1.UpdateDATA();

                // ende datum für Rückmeldungen ermitteln
                UrlaubVerlauf u = ucUrlaub1.Urlaub;
                string text = (u.IsOpenUrlaub ? "" : u.Text);
                DateTime dtEnd = (u.IsOpenUrlaub ? u.StartDatum : (DateTime)u.EndeDatum);

                bool IsAbwesend = false;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    IsAbwesend = b.KlientIsAbwesend(db, _patient.Aufenthalt.ID);
                }

                if (u.IsOpenUrlaub && !IsAbwesend)
                {
                    Guid idAuf = _patient.Aufenthalt.ID;
                    DateTime DatBeginnUrlaub = this.ucUrlaub1.dtpBeginn.DateTime;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();   //lthok
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(_patient.ID, idAuf, DatBeginnUrlaub, ENV.IDKlinik);

                    PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                    PMDSBusiness1.AddPflegeeintrag(db, "Abwesenheitsbeginn " + u.Text + " - Alle Maßnahmen werden unterbrochen.", DatBeginnUrlaub, 
                        null, _patient.Aufenthalt.IDBereich,
                        _patient.Aufenthalt.ID, null, PflegeEintragTyp.PLANUNG,
                        null, _patient.Aufenthalt.IDAbteilung, "Planungsänderung");
                    db.SaveChanges();

                    _patient.Aufenthalt.Write();
                }
                else if (!u.IsOpenUrlaub && IsAbwesend)
                {
                    Guid idAuf = _patient.Aufenthalt.ID;
                    DateTime DatBeginnUrlaub = this.ucUrlaub1.dtpBeginn.DateTime;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();   //lthok
                    string sText = "Abwesenheitsende " + u.Text;
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.AbwesenheitsEnde(_patient.ID, idAuf, dtEnd, ENV.IDKlinik, sText);
                    _patient.Aufenthalt.Write();
                }
                else if (u.IsOpenUrlaub && IsAbwesend)         //Klient ist bereits abwesend, kann nicht nocheinmal abwesend gemacht werden
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Abwesend' geändert.", "Hinweis");
                }
                else if (!u.IsOpenUrlaub && !IsAbwesend)         //Klient ist bereits abwesend, kann nicht nocheinmal abwesend gemacht werden
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Anwesend' geändert.", "Hinweis");
                }
                else         //Irregulärer Zustand
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten kann nicht festgestellt werden. Bitte schließen Sie das Fenster und probieren Sie es nocheinmal", "Hinweis");
                }

                _bCanclose = true;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _bCanclose = true;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}

        private void frmUrlaub_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }
	}
}
