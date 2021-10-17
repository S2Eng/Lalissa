using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.GUI;
using PMDS.Abrechnung.Global;
using PMDS.Global.db.Global.ds_abrechnung;




namespace PMDS.Calc.UI.Admin
{


	public class frmKostenträger : frmBase
	{
		private PMDS.GUI.ucButton btnCancel;
        private PMDS.GUI.ucButton btnOK;
        private System.ComponentModel.IContainer components;
        public ucKostenträgerKlientEdit ucPatientkostentraegerEdit1;
        private bool _CanClose = true;

        public PMDS.GUI.Kostentraeger.ucKostentraegerKlient2 mainWindow;
        public bool KlientIstZahler = false;
     

        




        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKostenträger));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucPatientkostentraegerEdit1 = new PMDS.Calc.UI.Admin.ucKostenträgerKlientEdit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(853, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(942, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucPatientkostentraegerEdit1
            // 
            this.ucPatientkostentraegerEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPatientkostentraegerEdit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPatientkostentraegerEdit1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientkostentraegerEdit1.Name = "ucPatientkostentraegerEdit1";
            this.ucPatientkostentraegerEdit1.Size = new System.Drawing.Size(998, 428);
            this.ucPatientkostentraegerEdit1.TabIndex = 5;
            // 
            // frmKostenträger
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(997, 473);
            this.Controls.Add(this.ucPatientkostentraegerEdit1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(896, 512);
            this.Name = "frmKostenträger";
            this.Text = "Kostenträger verwalten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKostentraeger_FormClosing);
            this.Load += new System.EventHandler(this.frmKostentraeger_Load);
            this.ResumeLayout(false);

        }
        #endregion

        public frmKostenträger()
		{
			InitializeComponent();
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            this.ucPatientkostentraegerEdit1.mainWindow = this;

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

		
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPatientKostentraeger.PatientKostentraegerRow PatientKostentraegerRow
        {
            get { return ucPatientkostentraegerEdit1.PatientKostentraegerRow; }
            set { ucPatientkostentraegerEdit1.PatientKostentraegerRow = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPatientKostentraeger.PatientKostentraegerDataTable KostentraegerDataTable
        {
            get { return ucPatientkostentraegerEdit1.KostentraegerDataTable; }
            set { ucPatientkostentraegerEdit1.KostentraegerDataTable = value; }
        }

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            _CanClose = true;
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            if (ucPatientkostentraegerEdit1.ValidateFields())
            {
                _CanClose = true;
                ucPatientkostentraegerEdit1.UpdateData();
                this.Close();
            }
            else
                _CanClose = false;
		}

        private void frmKostentraeger_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }


        private void frmKostentraeger_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
        }

	}
}
