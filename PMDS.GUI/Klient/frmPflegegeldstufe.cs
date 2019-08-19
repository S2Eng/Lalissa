using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.GUI;
using PMDS.Abrechnung.Global;

namespace PMDS.Calc.UI.Admin
{
	/// <summary>
	/// Summary description for frmPflegegeldstufe.
	/// </summary>
	public class frmPflegegeldstufe : frmBase
	{
		private PMDS.Calc.UI.Admin.ucPflegegeldstufe ucPflegegeldstufe1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private System.ComponentModel.IContainer components;
        private bool _CanClose = true;

        public frmPflegegeldstufe()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPflegegeldstufe));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ucPflegegeldstufe1 = new PMDS.Calc.UI.Admin.ucPflegegeldstufe();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.SuspendLayout();
            // 
            // ucPflegegeldstufe1
            // 
            this.ucPflegegeldstufe1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegegeldstufe1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPflegegeldstufe1.Location = new System.Drawing.Point(0, 0);
            this.ucPflegegeldstufe1.Name = "ucPflegegeldstufe1";
            this.ucPflegegeldstufe1.Size = new System.Drawing.Size(568, 376);
            this.ucPflegegeldstufe1.TabIndex = 0;
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
            this.btnCancel.Location = new System.Drawing.Point(416, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(512, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPflegegeldstufe
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(568, 430);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPflegegeldstufe1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmPflegegeldstufe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pflegegeldstufe verwalten";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPflegegeldstufe_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPflegegeldstufe_FormClosing);
            this.Load += new System.EventHandler(this.frmPflegegeldstufe_Load);
            this.ResumeLayout(false);

		}
		#endregion

        //Neu nach 23.05.2007 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPflegegeldstufe.PflegegeldstufeRow PFLEGEGELDSTUFE_ROW
        {
            get { return ucPflegegeldstufe1.PFLEGEGELDSTUFE_ROW; }
        }

		private void frmPflegegeldstufe_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            _CanClose = true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            if (ucPflegegeldstufe1.ValidateFields())
            {
                ucPflegegeldstufe1.Save();
                _CanClose = true;
            }
			else
                _CanClose = false;
		}

        private void frmPflegegeldstufe_Load(object sender, EventArgs e)
        {
            //ucPflegegeldstufe1.RefreshControl(Guid.Empty);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _CanClose = true;
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void frmPflegegeldstufe_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }
	}
}
