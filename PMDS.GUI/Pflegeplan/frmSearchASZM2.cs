//----------------------------------------------------------------------------------------------
//	frmSearchASZM2.cs
//  Container Form für Control
//  Erstellt am:	28.03.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;

namespace PMDS.GUI
{
	public class frmSearchASZM2 : frmBase
	{

		public event ASZMSelectedDelegate	ASZMSelected;

		private PMDS.GUI.ucASZMSearchSelector2 ucASZMSearchSelector21;
		private PMDS.GUI.ucButton btnCancel;
		private System.ComponentModel.IContainer components;

		public frmSearchASZM2()
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchASZM2));
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.ucASZMSearchSelector21 = new PMDS.GUI.ucASZMSearchSelector2();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(720, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 40);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Fertig";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucASZMSearchSelector21
            // 
            this.ucASZMSearchSelector21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucASZMSearchSelector21.Location = new System.Drawing.Point(0, 0);
            this.ucASZMSearchSelector21.Name = "ucASZMSearchSelector21";
            this.ucASZMSearchSelector21.Size = new System.Drawing.Size(808, 638);
            this.ucASZMSearchSelector21.TabIndex = 0;
            this.ucASZMSearchSelector21.Load += new System.EventHandler(this.ucASZMSearchSelector21_Load);
            // 
            // frmSearchASZM2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 638);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ucASZMSearchSelector21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(648, 600);
            this.Name = "frmSearchASZM2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDx Suche ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSearchASZM2_Closing);
            this.Load += new System.EventHandler(this.frmSearchASZM2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchASZM2_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

        //Neu nach 07.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegePlan auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.BusinessLogic.PflegePlan PflegePlan
        {
            get { return ucASZMSearchSelector21.PflegePlan; }
            set { ucASZMSearchSelector21.PflegePlan = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ASZSearch
        {
            get { return ucASZMSearchSelector21.ASZSearch; }
            set { ucASZMSearchSelector21.ASZSearch = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs[] PDX_SELARGS
        {
            get { return ucASZMSearchSelector21.PDX_SELARGS; }
            set
            {
                ucASZMSearchSelector21.PDX_SELARGS = value;
            }
        }

		private void ucASZMSearchSelector21_Load(object sender, System.EventArgs e)
		{
			ucASZMSearchSelector21.ASZMSelected+=new PMDS.Global.ASZMSelectedDelegate(ucASZMSearchSelector21_ASZMSelected);
            ucASZMSearchSelector21.SetFocusToSearch();
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Dialog so preparieren dass schnell nach einer Massnahme gesucht werden kann
        /// </summary>
        //----------------------------------------------------------------------------
        public void SwitchToMassnahmeSearch()
        {
            ucASZMSearchSelector21.SwitchToMassnahmeSearch();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Dialog so preparieren dass schnell nach einer ASZ gesucht werden kann
        /// </summary>
        //----------------------------------------------------------------------------
        public void SwitchToASZSearch()
        {
            ucASZMSearchSelector21.SwitchToASZSearch();
        }

		private void frmSearchASZM2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Handled)
				return;
			if(e.KeyCode == Keys.Escape)
				this.Close();
		}

		private bool CanCloseWindow() 
		{
			if(ucASZMSearchSelector21.ISAnySelected)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_SCHLIESSENMITAUSWAHL"), ENV.String("DIALOGTITLE_SCHLIESSENMITAUSWAHL"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
				if(res == DialogResult.No || res == DialogResult.Cancel)
					return false;
				if(res == DialogResult.Yes)
					return true;
			}

			return true;
		}

		private void ucASZMSearchSelector21_ASZMSelected(PMDS.Global.ASZMSelectionArgs[] args, bool bAMDependet, bool bLokalisiert, string sLokalisierung, string sLokalisierungSeite)
		{
			if(ASZMSelected != null)
				ASZMSelected(args, bAMDependet , bLokalisiert, sLokalisierung, sLokalisierungSeite);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		}

		private void frmSearchASZM2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !CanCloseWindow();
		}

        private void frmSearchASZM2_Load(object sender, EventArgs e)
        {
            ucASZMSearchSelector21.SetFocusToSearch();
        }
	}
}
