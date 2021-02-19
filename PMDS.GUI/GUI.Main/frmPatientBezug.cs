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
    
	public class frmPatientBezug : frmBase
	{
        public QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucBenutzerBezug ucBenutzerBezug1;
        public QS2.Desktop.ControlManagment.BaseButton btnOK2;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        private System.ComponentModel.IContainer components;
        
        public bool abort = true;




		public frmPatientBezug()
		{
			InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                this.ucBenutzerBezug1.mainWindow = this;
                ControlManagment1.autoTranslateForm(this);

                this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucBenutzerBezug1 = new PMDS.GUI.ucBenutzerBezug();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
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
            this.labInfo.Size = new System.Drawing.Size(1137, 72);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Bezugspersonen für {0}";
            // 
            // ucBenutzerBezug1
            // 
            this.ucBenutzerBezug1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBenutzerBezug1.BackColor = System.Drawing.Color.White;
            this.ucBenutzerBezug1.Location = new System.Drawing.Point(4, 76);
            this.ucBenutzerBezug1.Name = "ucBenutzerBezug1";
            this.ucBenutzerBezug1.Size = new System.Drawing.Size(1129, 651);
            this.ucBenutzerBezug1.TabIndex = 6;
            // 
            // btnOK2
            // 
            this.btnOK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK2.Appearance = appearance2;
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(1047, 731);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(74, 32);
            this.btnOK2.TabIndex = 11;
            this.btnOK2.Tag = "ResID.OK";
            this.btnOK2.Text = "OK";
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance3;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(971, 731);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(74, 32);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmPatientBezug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1137, 767);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.ucBenutzerBezug1);
            this.Controls.Add(this.labInfo);
            this.MinimumSize = new System.Drawing.Size(280, 296);
            this.Name = "frmPatientBezug";
            this.Text = "Klienten-Bezugspersonen ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientBezug_Load);
            this.ResumeLayout(false);

		}
        #endregion

        
        private void frmPatientBezug_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}



        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ucBenutzerBezug1.saveData())
                {
                    this.abort = false;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
