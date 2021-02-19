//----------------------------------------------------------------------------
/// <summary>
///	frmSelectOnePPEntry.cs - Auswahl einer von mehreren
/// Erstellt am:	20.12.2005
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using System.Text;

namespace PMDS.GUI
{
	public class frmSelectOnePPEntry : QS2.Desktop.ControlManagment.baseForm 
	{
		private System.Windows.Forms.ListBox listBox1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Klasse für die Listbox
		/// </summary>
		//----------------------------------------------------------------------------
		private class ppentry 
		{
			private string	_sText = "";
			public  Guid	_IDPflegePlan;

			public ppentry(dsPflegePlan.PflegePlanRow r) 
			{
				_IDPflegePlan = r.ID;
				StringBuilder sb = new StringBuilder();
				sb.Append(r.Text);
				if(r.LokalisierungJN)
				{
					sb.Append(", ");
					sb.Append(r.Lokalisierung.Trim());
					sb.Append(", ");
					sb.Append(r.LokalisierungSeite.Trim());
				}
				
				sb.Append (" - ");
				sb.Append(r.StartDatum.ToShortTimeString());
				_sText = sb.ToString();
			}

			public override string ToString()
			{
				return _sText;
			}

			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// liefert die ausgewählte ID
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid SELECTED_ID 
		{
			get 
			{
				if(listBox1.SelectedItem == null)
					return Guid.Empty;
				ppentry pe = (ppentry)listBox1.SelectedItem;
				return pe._IDPflegePlan;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Übergeben werden die auszuwählenden Rows
		/// </summary>
		//----------------------------------------------------------------------------
		public frmSelectOnePPEntry(dsPflegePlan.PflegePlanRow[] ar)
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            foreach (dsPflegePlan.PflegePlanRow r in ar)
			{
				listBox1.Items.Add(new ppentry(r));
			}
			listBox1.SelectedIndex = 0;
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectOnePPEntry));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCancel = new PMDS.GUI.ucButton();
            this.btnOK = new PMDS.GUI.ucButton();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(0, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(464, 407);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
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
            this.btnCancel.Location = new System.Drawing.Point(312, 472);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 6;
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
            this.btnOK.Location = new System.Drawing.Point(408, 472);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
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
            this.labInfo.Size = new System.Drawing.Size(464, 48);
            this.labInfo.TabIndex = 7;
            this.labInfo.Text = "Wählen Sie die Maßnahme zum Abzeichnen";
            // 
            // frmSelectOnePPEntry
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 510);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectOnePPEntry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wählen Sie einen Eintrag";
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			if(listBox1.SelectedItem != null) 
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
