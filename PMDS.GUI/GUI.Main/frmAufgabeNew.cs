//----------------------------------------------------------------------------
/// <summary>
///	frmUrlaub.cs
/// Erstellt am:	04.03.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Bearbeiten der Aufenthalt-Urlaube
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmAufgabeNew : frmBase
	{
		private bool _bCanclose = false;

		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private QS2.Desktop.ControlManagment.BaseLabel lblAufgabe;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbAufgabe;
		private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbBemerkung;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmAufgabeNew()
		{
			
			InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            RequiredFields();
			
		}
		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufgaentext
		/// </summary>
		//----------------------------------------------------------------------------
		public string AUFGABE 
		{
			get 
			{
				return tbAufgabe.Text.Trim();
			}
			set
			{
				tbAufgabe.Text = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bemerkung
		/// </summary>
		//----------------------------------------------------------------------------
		public string BEMERKUNG
		{
			get 
			{
				return tbBemerkung.Text.Trim();
			}
			set
			{
				tbBemerkung.Text = value;
			}
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(tbAufgabe);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			GuiUtil.ValidateField(tbAufgabe, (tbAufgabe.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAufgabeNew));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAufgabe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbAufgabe = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.tbAufgabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBemerkung)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(272, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 2;
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
            this.btnOK.Location = new System.Drawing.Point(368, 252);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labInfo
            // 
            appearance3.BackColor = System.Drawing.Color.DarkGray;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance3;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(448, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Aufgabe";
            // 
            // lblAufgabe
            // 
            this.lblAufgabe.Location = new System.Drawing.Point(16, 64);
            this.lblAufgabe.Name = "lblAufgabe";
            this.lblAufgabe.Size = new System.Drawing.Size(168, 16);
            this.lblAufgabe.TabIndex = 16;
            this.lblAufgabe.Text = "Aufgabe";
            // 
            // tbAufgabe
            // 
            this.tbAufgabe.Location = new System.Drawing.Point(16, 80);
            this.tbAufgabe.MaxLength = 255;
            this.tbAufgabe.Multiline = true;
            this.tbAufgabe.Name = "tbAufgabe";
            this.tbAufgabe.Size = new System.Drawing.Size(396, 64);
            this.tbAufgabe.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(16, 152);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(168, 16);
            this.lblBemerkung.TabIndex = 18;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // tbBemerkung
            // 
            this.tbBemerkung.Location = new System.Drawing.Point(16, 168);
            this.tbBemerkung.MaxLength = 255;
            this.tbBemerkung.Multiline = true;
            this.tbBemerkung.Name = "tbBemerkung";
            this.tbBemerkung.Size = new System.Drawing.Size(396, 64);
            this.tbBemerkung.TabIndex = 17;
            // 
            // frmAufgabeNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(448, 292);
            this.ControlBox = false;
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.tbBemerkung);
            this.Controls.Add(this.lblAufgabe);
            this.Controls.Add(this.tbAufgabe);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAufgabeNew";
            this.ShowInTaskbar = false;
            this.Text = "Aufgabe";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmAufgabeNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbAufgabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBemerkung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_bCanclose = false;
			if(!ValidateFields())
				return;
			_bCanclose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_bCanclose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}

        private void frmAufgabeNew_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;

        }
	}
}
