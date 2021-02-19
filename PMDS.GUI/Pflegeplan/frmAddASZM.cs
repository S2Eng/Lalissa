using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PMDS.GUI
{
	/// <summary>
	/// Zusammenfassung für frmAddASZM.
	/// </summary>
	public class frmAddASZM : frmBase
	{
		public event AddSelectedASZMToPDXDelegate ASZMToPDXSelected;

		private PMDS.GUI.ucAddASZM ucAddASZM1;
		private ArrayList EintragGruppen;
		private PMDS.GUI.ucButton btnOk;
		private System.ComponentModel.IContainer components;

		private string ASZMAuswahl;

		public frmAddASZM()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();
            if (!DesignMode)
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

		public string ASZMAUSWAHL
		{
			set
			{
				ASZMAuswahl = value;
				ucAddASZM1.ASZMAUSWAHL = ASZMAuswahl;
				this.Text = ASZMAuswahl+" "+ENV.String("ASZM_TO_PDX"); 
			}
		}

		public ArrayList EINTRAGGRUPPEN
		{
			get
			{ 
				return EintragGruppen;
			}
			set
			{
				EintragGruppen = value;
				ucAddASZM1.EINTRAGGRUPPEN = value;							
			}
		}


		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddASZM));
            this.ucAddASZM1 = new PMDS.GUI.ucAddASZM();
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.SuspendLayout();
            // 
            // ucAddASZM1
            // 
            this.ucAddASZM1.ASZMAUSWAHL = null;
            this.ucAddASZM1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ucAddASZM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAddASZM1.EINTRAGGRUPPEN = null;
            this.ucAddASZM1.Location = new System.Drawing.Point(0, 0);
            this.ucAddASZM1.Name = "ucAddASZM1";
            this.ucAddASZM1.Size = new System.Drawing.Size(1008, 382);
            this.ucAddASZM1.TabIndex = 0;
            this.ucAddASZM1.ASZMToPDXSelected += new PMDS.Global.AddSelectedASZMToPDXDelegate(this.ucAddASZM1_ASZMToPDXSelected);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance1;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(896, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "&Schließen";
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAddASZM
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1008, 382);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ucAddASZM1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmAddASZM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ASZM zuordnen";
            this.Activated += new System.EventHandler(this.frmAddASZM_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAddASZM_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddASZM_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Signal an ucPDx, dass ASZM hinzugefügt wurden
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucAddASZM1_ASZMToPDXSelected(UltraGridRow[] rc)
		{
		    if(ASZMToPDXSelected != null)
				ASZMToPDXSelected(rc);
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmAddASZM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ucAddASZM1.CONTENTCHANGED)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_ASZMAUSWAHL_ZUORDNEN"), 
					                                                ENV.String("DIALOGTITLE_ASZMAUSWAHL_ZUORDNEN"), 
					                                                MessageBoxButtons.YesNoCancel, 
					                                                MessageBoxIcon.Question, true);
			
				if(res == DialogResult.Yes) 
				{
					ucAddASZM1.AddToPDX();				
					return;
				}
			
				if(res == DialogResult.No)
					return;

				e.Cancel = true;
			}
		}

		private void frmAddASZM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
				this.Close();
		}

		private void frmAddASZM_Activated(object sender, System.EventArgs e)
		{
			ucAddASZM1.FocusOntxtSearch();
		}
			
	}
}
