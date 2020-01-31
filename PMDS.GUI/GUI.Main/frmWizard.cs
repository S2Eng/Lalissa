using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;


namespace PMDS.GUI
{

	public class frmWizard : frmBase
	{
		private bool			_bCanClose = true;
		private ArrayList		_pages = new ArrayList();	// Pages in deren Reihenfolge
		private ArrayList		_info = new ArrayList();	// Page-Beschreibung
		private int				_pageIdx = 0;				// aktuelle Page Index
		public UserControl		_activePage = null;			// aktive Page
        public ucPatientNew ucPatientNew1 = null;


        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBottom;
		private QS2.Desktop.ControlManagment.BasePanel panelButtons;
		private QS2.Desktop.ControlManagment.BaseLableWin lblKlickenSieWeiter;
		private QS2.Desktop.ControlManagment.BasePanel panelPage;
		private System.ComponentModel.IContainer components;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOk;
		private QS2.Desktop.ControlManagment.BaseButton btnNext;
		private QS2.Desktop.ControlManagment.BaseButton btnPrev;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;				







		public frmWizard()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWizard));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.grpBottom = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnPrev = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.btnNext = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblKlickenSieWeiter = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.panelPage = new QS2.Desktop.ControlManagment.BasePanel();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBottom
            // 
            this.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBottom.Location = new System.Drawing.Point(0, 495);
            this.grpBottom.Name = "grpBottom";
            this.grpBottom.Size = new System.Drawing.Size(400, 8);
            this.grpBottom.TabIndex = 3;
            this.grpBottom.TabStop = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnPrev);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Controls.Add(this.btnNext);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 503);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(400, 48);
            this.panelButtons.TabIndex = 4;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.AutoWorkLayout = false;
            this.btnPrev.IsStandardControl = false;
            this.btnPrev.Location = new System.Drawing.Point(96, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(96, 32);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "< &Zur¸ck";
            this.btnPrev.Visible = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(304, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance2;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DoOnClick = true;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(192, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoWorkLayout = false;
            this.btnNext.IsStandardControl = false;
            this.btnNext.Location = new System.Drawing.Point(192, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(96, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Weiter >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblKlickenSieWeiter
            // 
            this.lblKlickenSieWeiter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKlickenSieWeiter.Location = new System.Drawing.Point(0, 479);
            this.lblKlickenSieWeiter.Name = "lblKlickenSieWeiter";
            this.lblKlickenSieWeiter.Size = new System.Drawing.Size(400, 16);
            this.lblKlickenSieWeiter.TabIndex = 2;
            this.lblKlickenSieWeiter.Text = "klicken Sie auf \"Weiter\", um den Vorgang fortzusetzen";
            this.lblKlickenSieWeiter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelPage
            // 
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage.Location = new System.Drawing.Point(0, 70);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(400, 409);
            this.panelPage.TabIndex = 0;
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
            this.labInfo.Size = new System.Drawing.Size(400, 70);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Informationen ... ";
            // 
            // frmWizard
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 551);
            this.ControlBox = false;
            this.Controls.Add(this.panelPage);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.lblKlickenSieWeiter);
            this.Controls.Add(this.grpBottom);
            this.Controls.Add(this.panelButtons);
            this.KeyPreview = true;
            this.Name = "frmWizard";
            this.ShowInTaskbar = false;
            this.Text = "Wizard ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmWizard_Closing);
            this.Load += new System.EventHandler(this.ucWizard_Load);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		public string Description
		{
			get	{	return labInfo.Text;	}
			set	{	labInfo.Text = value;	}
		}

		public void AddPage(string info, UserControl page)
		{
			if (page == null)
				throw new ArgumentNullException("AddPage");

			if (!(page is IWizardPage))
				throw new ArgumentException("AddPage IWizardPage");

			_info.Add(info);
			_pages.Add(page);
		}

		public UserControl this[int idx]
		{
			get	{	return (UserControl)_pages[idx];	}
		}

		public int ActiveIndex
		{
			get	{	return _pageIdx;	}
			set	{	_pageIdx = value;	}
		}

		public int PageCount
		{
			get	{	return _pages.Count;	}
		}

		public bool HasPages
		{
			get	{	return PageCount > 0;	}
		}

		public bool IsFirstPage
		{
			get	{	return ActiveIndex == 0;	}
		}

		public bool IsLastPage
		{
			get	{	return !HasPages || (ActiveIndex == PageCount-1);	}
		}

		public void ActivatePage(int i)
		{
			ActivatePage(i, true);
		}

		private void ActivatePage(int i, bool validate)
		{
			// alte Page validieren - bei Fehler nicht wechseln
			if (_activePage != null)
			{
				if (validate && !((IWizardPage)_activePage).ValidateFields())
					return;

				panelPage.Controls.Remove(_activePage);
			}

			ActiveIndex = i;

			// neue Page aktivieren
			_activePage = this[i];
			_activePage.Dock = DockStyle.Fill;
			panelPage.Controls.Add(_activePage);
			Description = (string)_info[i];
			_activePage.Focus();

			UpdateButtons();
		}

		private bool IsActivePageValid
		{
			get
			{
				if (_activePage == null)
					return true;

				return ((IWizardPage)_activePage).ValidateFields();
			}
		}

		private void ucWizard_Load(object sender, System.EventArgs e)
		{
			// erste Page aktivieren
			if (HasPages)
				ActivatePage(0);

			UpdateButtons();
		}

		private void btnPrev_Click(object sender, System.EventArgs e)
		{
			if (!IsFirstPage)
				ActivatePage(ActiveIndex-1, false);
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (!IsLastPage)
				ActivatePage(ActiveIndex+1);
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			_bCanClose = false;

			if(!btnOk.Enabled)			// Infragistics schrott....
				return;

			if (!IsActivePageValid)
				return;

            if (!this.ucPatientNew1.validateDataVersNr(true))
            {
                return;
            }

			foreach(IWizardPage page in _pages)
				page.UpdateDATA();

			_bCanClose = true;

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		}

		private void frmWizard_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!_bCanClose)
				e.Cancel = true;

			_bCanClose = true;
		}

		private void UpdateButtons()
		{
			btnOk.Visible		= IsLastPage;
			btnOk.Enabled		= IsLastPage;
			btnCancel.Enabled	= true;

			btnPrev.Enabled		= !IsFirstPage;
			btnNext.Visible		=   !IsLastPage;
            AcceptButton = (IsLastPage ? (Infragistics.Win.Misc.UltraButton)btnOk : btnNext);

			if (IsLastPage)
				lblKlickenSieWeiter.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klicken Sie auf \"OK\", um den Vorgang abzuschlieﬂen");
            else
				lblKlickenSieWeiter.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klicken Sie auf \"Weiter\", um den Vorgang fortzusetzen");
        }

	}

}
