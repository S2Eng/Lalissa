//----------------------------------------------------------------------------
/// <summary>
///	frmPrintPflegebriefInfo.cs
/// Erstellt am:	9.2.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;

namespace PMDS.Print
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form für Druck-Vorschau.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmPrintPflegebriefInfo : frmBase
	{
		private bool _canClose = false;
		private QS2.Desktop.ControlManagment.BaseLabel lblAnEinrichtung;
		private PMDS.GUI.BaseControls.EinrichtungsCombo cbETo;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin groupBox3;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
		private QS2.Desktop.ControlManagment.BaseTextEditor ultraTextEditor1;
		private System.ComponentModel.IContainer components;


		//----------------------------------------------------------------------------
		/// <summary>
		/// Form zum Bearbeiten der Report Pflegebrief-Daten.
		/// </summary>
		//----------------------------------------------------------------------------
		public frmPrintPflegebriefInfo()
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            RequiredFields();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPflegebriefInfo));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cbETo = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.lblAnEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraTextEditor1 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbETo
            // 
            this.cbETo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbETo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbETo.Location = new System.Drawing.Point(96, 8);
            this.cbETo.Name = "cbETo";
            this.cbETo.Size = new System.Drawing.Size(256, 21);
            this.cbETo.TabIndex = 1;
            // 
            // lblAnEinrichtung
            // 
            this.lblAnEinrichtung.AutoSize = true;
            this.lblAnEinrichtung.Location = new System.Drawing.Point(8, 11);
            this.lblAnEinrichtung.Name = "lblAnEinrichtung";
            this.lblAnEinrichtung.Size = new System.Drawing.Size(81, 14);
            this.lblAnEinrichtung.TabIndex = 0;
            this.lblAnEinrichtung.Text = "An Einrichtung:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(214, 256);
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
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(310, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtBemerkung);
            this.groupBox3.Location = new System.Drawing.Point(8, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 208);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abschlussbermerkung";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBemerkung.Location = new System.Drawing.Point(16, 24);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(320, 176);
            this.txtBemerkung.TabIndex = 2;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Location = new System.Drawing.Point(16, 40);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(272, 21);
            this.ultraTextEditor1.TabIndex = 0;
            // 
            // frmPrintPflegebriefInfo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 300);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintPflegebriefInfo";
            this.ShowInTaskbar = false;
            this.Text = "Pflegebrief Informationen ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(cbETo);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		private bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// cbETo
			GuiUtil.ValidateField(cbETo, (cbETo.Value != null),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ValidateFields())
				return;

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

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einrichtung
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Einrichtung
		{
			get	{	return (Guid)cbETo.Value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bemerkung
		/// </summary>
		//----------------------------------------------------------------------------
		public string Bemerkung
		{
			get	{	return txtBemerkung.Text;	}
		}
	}
}
