using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PMDS.GUI
{

	public class frmEinrichtung : frmBase
	{
		private PMDS.GUI.ucEinrichtungEdit ucEinrichtungEdit11;
		private PMDS.GUI.ucButton btnCancel;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        private Panel panelEinrichtung;
        private System.ComponentModel.IContainer components;



		public frmEinrichtung()
		{
			InitializeComponent();

            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEinrichtung));
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.panelEinrichtung = new System.Windows.Forms.Panel();
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
            this.labInfo.Size = new System.Drawing.Size(968, 48);
            this.labInfo.TabIndex = 3;
            this.labInfo.Text = "Einrichtungen";
            // 
            // btnCancel
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Visible = false;
            // 
            // panelEinrichtung
            // 
            this.panelEinrichtung.BackColor = System.Drawing.Color.Transparent;
            this.panelEinrichtung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEinrichtung.Location = new System.Drawing.Point(0, 48);
            this.panelEinrichtung.Name = "panelEinrichtung";
            this.panelEinrichtung.Size = new System.Drawing.Size(968, 511);
            this.panelEinrichtung.TabIndex = 5;
            // 
            // frmEinrichtung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(968, 559);
            this.Controls.Add(this.panelEinrichtung);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "frmEinrichtung";
            this.Text = "Einrichtungs-Verwaltung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmEinrichtung_Load);
            this.ResumeLayout(true);

		}
        #endregion

        public void initControl()
        {
            ucEinrichtungEdit11 = new ucEinrichtungEdit();
            ucEinrichtungEdit11.Dock = DockStyle.Fill;
            this.panelEinrichtung.Controls.Add(ucEinrichtungEdit11);
        }


		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (ucEinrichtungEdit11 != null)
			    e.Cancel = !ucEinrichtungEdit11.CanClose;
		}
            
        private void frmEinrichtung_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }
	}
}
