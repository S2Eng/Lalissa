//----------------------------------------------------------------------------
/// <summary>
///	frmBenutzerGruppe.cs
/// Erstellt am:	15.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Bearbeiten der BenutzerGruppen/Rechte.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmBenutzerGruppe : frmBase
	{
		private System.ComponentModel.IContainer components;
		private PMDS.GUI.ucBenutzerGruppeEdit ucBenutzerGruppeEdit1;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private PMDS.GUI.ucButton btnCancel;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmBenutzerGruppe()
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBenutzerGruppe));
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.ucBenutzerGruppeEdit1 = new PMDS.GUI.ucBenutzerGruppeEdit();
            this.SuspendLayout();
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
            this.labInfo.Size = new System.Drawing.Size(727, 40);
            this.labInfo.TabIndex = 1;
            this.labInfo.Text = "Benutzerrechte";
            // 
            // btnCancel
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance4;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Visible = false;
            // 
            // ucBenutzerGruppeEdit1
            // 
            this.ucBenutzerGruppeEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBenutzerGruppeEdit1.Location = new System.Drawing.Point(0, 40);
            this.ucBenutzerGruppeEdit1.Name = "ucBenutzerGruppeEdit1";
            this.ucBenutzerGruppeEdit1.Size = new System.Drawing.Size(727, 581);
            this.ucBenutzerGruppeEdit1.TabIndex = 2;
            // 
            // frmBenutzerGruppe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(727, 635);
            this.Controls.Add(this.ucBenutzerGruppeEdit1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 448);
            this.Name = "frmBenutzerGruppe";
            this.ShowInTaskbar = false;
            this.Text = "Benutzerrechte ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmBenutzerGruppe_Load);
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
			e.Cancel = !ucBenutzerGruppeEdit1.CanClose;
		}

        private void frmBenutzerGruppe_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }
	}
}
