//----------------------------------------------------------------------------
/// <summary>
///	frmAskEndPDx.cs - Abfrage der Beendigung einer Pdx
/// Erstellt am:	14.10.2004
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using PMDS.Global;

namespace PMDS.GUI
{
	public class frmAskEndPDx : frmBase
	{

		private bool _bCanClose			= true;
		private PMDS.GUI.ucButton btnOK;
		private PMDS.GUI.ucButton btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseLabel lblEnddatum;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnd;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbReason;
		private QS2.Desktop.ControlManagment.BaseLabel lblGrundBeendigung;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.Windows.Forms.ListBox lbInfo;
		private QS2.Desktop.ControlManagment.BaseLabel lblInformation;
		private System.ComponentModel.IContainer components;

		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Übergeben werden die Texte der zu lokalisierenden Maßnahmen
		/// </summary>
		//----------------------------------------------------------------------------
		public frmAskEndPDx(string sHeader)
		{
			InitializeComponent();
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            dtpEnd.DateTime = DateTime.Now.Date;
			RequiredFields();	
			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Übergeben werden die Texte der zu lokalisierenden Maßnahmen
		/// </summary>
		//----------------------------------------------------------------------------
		public frmAskEndPDx(string sHeader, ASZMLokalisiert[] raszm)
		{
			InitializeComponent();
			dtpEnd.DateTime = DateTime.Now.Date;
			RequiredFields();

			ProcessInfo(raszm);
			
		}

		private void ProcessInfo(ASZMLokalisiert[] raszm)
		{
			
			lbInfo.Items.Add("---------------------------------------------------------------------");
			lbInfo.Items.Add(ENV.String("END_ASZMINFO"));
			lbInfo.Items.Add("---------------------------------------------------------------------");
			foreach(ASZMLokalisiert l in raszm)
				if(l._bCanPPFinished)
					lbInfo.Items.Add(l._Gruppe + " - " + l._Text + " (" + l._PDXText + " " + l._Lokalisierung + " " + l._LokalisierungSeite + ")");

			lbInfo.Items.Add("");
			lbInfo.Items.Add("");
			lbInfo.Items.Add("---------------------------------------------------------------------");
			lbInfo.Items.Add(ENV.String("END_NOT_ASZMINFO"));
			lbInfo.Items.Add("---------------------------------------------------------------------");
			foreach(ASZMLokalisiert l in raszm)
				if(!l._bCanPPFinished)
					lbInfo.Items.Add(l._Gruppe + " - " + l._Text + " (" + l._PDXText + " " + l._Lokalisierung + " " + l._LokalisierungSeite + ")");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Das Ende Datum
		/// </summary>
		//----------------------------------------------------------------------------
		public DateTime END_DATE
		{
			get 
			{
				return dtpEnd.DateTime;
			}
			set 
			{
				dtpEnd.DateTime = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Der Ende Grund
		/// </summary>
		//----------------------------------------------------------------------------
		public string REASON 
		{
			get 
			{
				return tbReason.Text.Trim();
			}
			set
			{
				tbReason.Text = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpEnd);
			GuiUtil.ValidateRequired(tbReason);
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

			// txtSexus
			GuiUtil.ValidateField(tbReason, (tbReason.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// dtpGebDatum
			GuiUtil.ValidateField(dtpEnd, (dtpEnd.Text.Length > 0),
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskEndPDx));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEnddatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEnd = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.tbReason = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGrundBeendigung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.lblInformation = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbReason)).BeginInit();
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
            this.labInfo.Size = new System.Drawing.Size(456, 48);
            this.labInfo.TabIndex = 3;
            this.labInfo.Text = "Pflegeproblem beenden";
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
            this.btnOK.Location = new System.Drawing.Point(400, 616);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance3;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(304, 616);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblEnddatum
            // 
            this.lblEnddatum.Location = new System.Drawing.Point(16, 56);
            this.lblEnddatum.Name = "lblEnddatum";
            this.lblEnddatum.Size = new System.Drawing.Size(64, 16);
            this.lblEnddatum.TabIndex = 12;
            this.lblEnddatum.Text = "Endedatum";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(16, 72);
            this.dtpEnd.MaskInput = "dd.mm.yyyy";
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(96, 21);
            this.dtpEnd.TabIndex = 0;
            // 
            // tbReason
            // 
            this.tbReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReason.Location = new System.Drawing.Point(16, 120);
            this.tbReason.MaxLength = 255;
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(432, 160);
            this.tbReason.TabIndex = 13;
            // 
            // lblGrundBeendigung
            // 
            this.lblGrundBeendigung.Location = new System.Drawing.Point(16, 104);
            this.lblGrundBeendigung.Name = "lblGrundBeendigung";
            this.lblGrundBeendigung.Size = new System.Drawing.Size(168, 16);
            this.lblGrundBeendigung.TabIndex = 14;
            this.lblGrundBeendigung.Text = "Grund der Beendigung";
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.HorizontalExtent = 2000;
            this.lbInfo.HorizontalScrollbar = true;
            this.lbInfo.Location = new System.Drawing.Point(16, 304);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(432, 288);
            this.lbInfo.TabIndex = 15;
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(16, 288);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(168, 16);
            this.lblInformation.TabIndex = 16;
            this.lblInformation.Text = "Information";
            // 
            // frmAskEndPDx
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 654);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lblGrundBeendigung);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnddatum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAskEndPDx";
            this.ShowInTaskbar = false;
            this.Text = "Beenden eines Pflegeproblemes";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAskEndPDx_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbReason)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Eingabefelder dürfen nicht leer sein
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_bCanClose = false;
			if(!ValidateFields())
				return;

			_bCanClose = true;

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abbruch
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_bCanClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Schließen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frmAskEndPDx_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!_bCanClose)
				e.Cancel = true;
		}

		
	}
}
