//----------------------------------------------------------------------------
/// <summary>
///	Legend.cs
/// Erstellt am:	15.7.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Lgenden Information
	/// </summary>
	//----------------------------------------------------------------------------
	public class Legend : QS2.Desktop.ControlManagment.BaseControl
	{
		private QS2.Desktop.ControlManagment.BaseLabel lblLegend;
		private QS2.Desktop.ControlManagment.BasePanel panelLeft;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public Legend()
		{
			InitializeComponent();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblLegend = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelLeft = new QS2.Desktop.ControlManagment.BasePanel();
            this.SuspendLayout();
            // 
            // lblLegend
            // 
            this.lblLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.TextVAlignAsString = "Middle";
            this.lblLegend.Appearance = appearance1;
            this.lblLegend.Location = new System.Drawing.Point(16, 0);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(128, 12);
            this.lblLegend.TabIndex = 0;
            this.lblLegend.Text = "ultraLabel1";
            this.lblLegend.DoubleClick += new System.EventHandler(this.ultraLabel1_DoubleClick);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Location = new System.Drawing.Point(3, 1);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 10);
            this.panelLeft.TabIndex = 1;
            this.panelLeft.Tag = "Dontpatch";
            this.panelLeft.DoubleClick += new System.EventHandler(this.ultraLabel1_DoubleClick);
            // 
            // Legend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.lblLegend);
            this.Name = "Legend";
            this.Size = new System.Drawing.Size(144, 12);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// COLOR
		/// </summary>
		//----------------------------------------------------------------------------
		public Color COLOR
		{
			get	{	return panelLeft.BackColor;	}
			set	{	panelLeft.BackColor = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// LEGEND
		/// </summary>
		//----------------------------------------------------------------------------
		public string LEGEND
		{
			get	{	return lblLegend.Text;	}
			set	{	lblLegend.Text = value;	}
		}

        private void ultraLabel1_DoubleClick(object sender, EventArgs e)
        {
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format("{0} / {1} / {2} / enabled:{3} / X:{4}, Y:{5} / X:{6}, Y:{7}", panelLeft.BorderStyle.ToString(), panelLeft.BackColor.ToString(), panelLeft.Visible.ToString(), panelLeft.Enabled.ToString(), panelLeft.Top, panelLeft.Left, lblLegend.Top, lblLegend.Left));
        }
	}
}
