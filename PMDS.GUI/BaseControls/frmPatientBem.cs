//----------------------------------------------------------------------------
/// <summary>
///	frmPatientBem.cs
/// Erstellt am:	20.10.2004
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
	/// Form zum Erzeugung einer neuen Patienten Bemerkung
	/// </summary>
	//----------------------------------------------------------------------------


    


	public class frmPatientBem : frmBase
	{
		private bool _canClose = false;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private ucPatientBem ucPatientBem1;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.ComponentModel.IContainer components;

        public  _typBemerkung _typ = new _typBemerkung();
       


		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
        public frmPatientBem(Patient pat, _typBemerkung typBemerk)
		{
          
			InitializeComponent();

            this.ucPatientBem1.mainWindow = this;
            this._typ = typBemerk;
            if (this._typ == _typBemerkung.dekurs )
            {
                labInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärztlicher Dekurs für {0}");  
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten-Ärztlicher Dekurs ...");
            }
			labInfo.Text = string.Format(labInfo.Text, pat.FullInfo);
			ucPatientBem1.Bemerkung = pat.NewBemerkung(ENV.USERID);

        }

        public void loadData(System.Guid ID, string bem, DateTime   von)
        {
            //this.ucPatientBem1.dtpDatum.DateTime = von;
            //this.ucPatientBem1.txtBemerkung.Text = bem;
            this.ucPatientBem1.Read(ID);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientBem));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.PatientenBemerkung patientenBemerkung1 = new PMDS.BusinessLogic.PatientenBemerkung();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucPatientBem1 = new PMDS.GUI.ucPatientBem();
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
            this.labInfo.Size = new System.Drawing.Size(510, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Bemerkung für {0}";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 216);
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
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(448, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucPatientBem1
            // 
            this.ucPatientBem1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            patientenBemerkung1.Bemerkung = "";
            patientenBemerkung1.Datum = new System.DateTime(2009, 1, 12, 11, 55, 22, 662);
            patientenBemerkung1.ID = System.Guid.Empty;
            patientenBemerkung1.IDBenutzer = System.Guid.Empty;
            patientenBemerkung1.IDPatient = System.Guid.Empty;
            patientenBemerkung1.IstDekurs = false;
            this.ucPatientBem1.Bemerkung = patientenBemerkung1;
            this.ucPatientBem1.IDPatient = System.Guid.Empty;
            this.ucPatientBem1.Location = new System.Drawing.Point(0, 48);
            this.ucPatientBem1.Name = "ucPatientBem1";
            this.ucPatientBem1.ReadOnly = false;
            this.ucPatientBem1.Size = new System.Drawing.Size(512, 160);
            this.ucPatientBem1.TabIndex = 6;
            // 
            // frmPatientBem
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 252);
            this.ControlBox = false;
            this.Controls.Add(this.ucPatientBem1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientBem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klienten-Bemerkung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientBem_Load);
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
			e.Cancel = !_canClose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ucPatientBem1.ValidateFields())
				return;

			ucPatientBem1.UpdateDATA();
			ucPatientBem1.Bemerkung.Write();

			_canClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

        private void frmPatientBem_Load(object sender, EventArgs e)
        {

                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

        }


	}
}
