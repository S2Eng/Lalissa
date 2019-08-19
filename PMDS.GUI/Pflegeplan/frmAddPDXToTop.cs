using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI
{
	/// <summary>
	/// Zusammenfassung für frmAddPDXToTop.
	/// </summary>
	public class frmAddPDXToTop : frmBase
	{
		public event AddSelectedPDXToTOPDelegate PDXToTOPSelected;

		private PMDS.GUI.ucAddPDXToTop ucAddPDXToTop1;
		private PMDS.GUI.ucButton btnOk;
		private System.ComponentModel.IContainer components;

		public frmAddPDXToTop()
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

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPDXToTop));
            this.ucAddPDXToTop1 = new PMDS.GUI.ucAddPDXToTop();
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.SuspendLayout();
            // 
            // ucAddPDXToTop1
            // 
            this.ucAddPDXToTop1.Location = new System.Drawing.Point(0, 0);
            this.ucAddPDXToTop1.Name = "ucAddPDXToTop1";
            this.ucAddPDXToTop1.Size = new System.Drawing.Size(864, 318);
            this.ucAddPDXToTop1.TabIndex = 0;
            this.ucAddPDXToTop1.PDXToTOPSelected += new PMDS.Global.AddSelectedPDXToTOPDelegate(this.ucAddPDXToTop1_PDXToTOPSelected);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance1;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(746, 275);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "&Schließen";
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAddPDXToTop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(864, 318);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ucAddPDXToTop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmAddPDXToTop";
            this.Text = "PDX zuordnen";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAddPDXToTop_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddPDXToTop_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		private void ucAddPDXToTop1_PDXToTOPSelected(Infragistics.Win.UltraWinGrid.UltraGridRow[] rc)
		{
			if(PDXToTOPSelected != null)
				PDXToTOPSelected(rc);
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmAddPDXToTop_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ucAddPDXToTop1.CONTENTCHANGED)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_PDXAUSWAHL_ZUORDNEN"), 
					                                                                    ENV.String("DIALOGTITLE_PDXAUSWAHL_ZUORDNEN"), 
					                                                                    MessageBoxButtons.YesNoCancel, 
					                                                                    MessageBoxIcon.Question, true);
			
				if(res == DialogResult.Yes) 
				{
					 ucAddPDXToTop1.AddToTop();				
						return;
				}
			
				if(res == DialogResult.No)
					return;

				e.Cancel = true;
			}
		
		}

		private void frmAddPDXToTop_Activated(object sender, System.EventArgs e)  
		{			
			ucAddPDXToTop1.FocusOntxtSearch();					
		}

		private void frmAddPDXToTop_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
				this.Close();
		}
		
	}
}
