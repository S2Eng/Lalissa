using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;



namespace PMDS.GUI
{
	/// <summary>
	/// Zusammenfassung für frmMassnahmenZusatz.
	/// </summary>
	public class frmMassnahmenZusatz : frmBase
	{
		private PMDS.GUI.ucZusatz2 ucZusatz21;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private Guid mID;

		public frmMassnahmenZusatz()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            //
            // TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
            //
        }

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
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

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            PMDS.BusinessLogic.ZusatzGruppe zusatzGruppe1 = new PMDS.BusinessLogic.ZusatzGruppe();
            this.ucZusatz21 = new PMDS.GUI.ucZusatz2();
            this.SuspendLayout();
            // 
            // ucZusatz21
            // 
            this.ucZusatz21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatz21.Location = new System.Drawing.Point(6, 6);
            this.ucZusatz21.Name = "ucZusatz21";
            this.ucZusatz21.Size = new System.Drawing.Size(780, 247);
            this.ucZusatz21.TabIndex = 0;
            this.ucZusatz21.ZusatzGruppe = zusatzGruppe1;
            // 
            // frmMassnahmenZusatz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 259);
            this.Controls.Add(this.ucZusatz21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMassnahmenZusatz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zusatzwerte zur Maßnahme";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMassnahmenZusatz_Closing);
            this.Load += new System.EventHandler(this.frmMassnahmenZusatz_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMassnahmenZusatz_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMassnahmenZusatz_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ucZusatz21.CONTENT_CHANGED)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
					                                                                        ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
					                                                                        MessageBoxButtons.YesNoCancel, 
					                                                                        MessageBoxIcon.Question, true);      

                if (res == DialogResult.Yes) 
				{
					ucZusatz21.Write();
					return;
				}
				
				if(res == DialogResult.No)
					return;

				e.Cancel = true;
			}
		}

		private void frmMassnahmenZusatz_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
				this.Close();
		}

		public Guid MID //MaßnahmenID
		{
			get
			{
				return mID;
			}
			set
			{
				mID = value;
				ucZusatz21.ZusatzGruppe = new PMDS.BusinessLogic.ZusatzGruppe("MASS",mID);	

                foreach(var x in ucZusatz21.ZusatzGruppe.ZusatzEintraege)
                {
                    if (x.IsReihenfolgeNull())
                        x.Reihenfolge = 0;
                }
			}
		}

        private void frmMassnahmenZusatz_Load(object sender, EventArgs e)
        {

        }

	}
}
