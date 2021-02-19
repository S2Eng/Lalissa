//----------------------------------------------------------------------------
/// <summary>
///	frmTop10.cs
/// Erstellt am:	10.12.2004
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

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Bearbeiten der Top10-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmTop10 : frmBase
    {
		private PMDS.GUI.ucTopTen ucTopTen1;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private PMDS.GUI.ucButton btnOK;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmTop10()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTop10));
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucTopTen1 = new PMDS.GUI.ucTopTen();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
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
            this.labInfo.Size = new System.Drawing.Size(601, 48);
            this.labInfo.TabIndex = 2;
            this.labInfo.Text = "Favoriten - Verwaltung";
            // 
            // ucTopTen1
            // 
            this.ucTopTen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTopTen1.Location = new System.Drawing.Point(0, 48);
            this.ucTopTen1.Name = "ucTopTen1";
            this.ucTopTen1.Size = new System.Drawing.Size(601, 579);
            this.ucTopTen1.TabIndex = 4;
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
            this.btnOK.Location = new System.Drawing.Point(541, 591);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 18;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmTop10
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(601, 627);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucTopTen1);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmTop10";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favoriten ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.ResumeLayout(false);

		}
		#endregion
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ucTopTen1.CONTENT_CHANGED)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
					                                                                        ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
					                                                                        MessageBoxButtons.YesNoCancel, 
					                                                                        MessageBoxIcon.Question, true);      

                if (res == DialogResult.Yes) 
				{
					ucTopTen1.Save();
					return;
				}
				
				if(res == DialogResult.No)
					return;

				e.Cancel = true;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }	
	}
}
