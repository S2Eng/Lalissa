//----------------------------------------------------------------------------
/// <summary>
///	frmEditPassword.cs
/// Erstellt am:	06.10.2004
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
	/// Form zum Bearbeiten der Benutzer Login-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmEditPassword : frmBase
	{
		private bool _bCanclose;
        private bool _bEditUser;
        private bool _bELGAMode;
        private bool _bNeedOldPassword;
        private Benutzer _ben;

        protected QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        protected QS2.Desktop.ControlManagment.BaseLabel lblPasswort;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtBenutzer;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswort;
        protected QS2.Desktop.ControlManagment.BaseGroupBoxWin grpLoginInformationen;
        protected QS2.Desktop.ControlManagment.BaseLabel lblBestätigung;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswort2;
		protected System.Windows.Forms.ErrorProvider errorProvider1;
		protected PMDS.GUI.ucButton btnCancel;
		protected PMDS.GUI.ucButton btnOK;
        protected Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager2;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswortHinweis;
        protected QS2.Desktop.ControlManagment.BaseLabel lblPasswortAlt;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswortAlt;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswortHinweisChange;
        private System.ComponentModel.IContainer components;


        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public frmEditPassword() {}

        public frmEditPassword(bool ELGAMode, bool NeedOldPassword)
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            this._bELGAMode = ELGAMode;
            this._bNeedOldPassword = NeedOldPassword;
            RequiredFields();
			EditUser = true;
            SetUI();

        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmEditPassword(bool ELGAMode, bool NeedOldPassword, Benutzer User) : this(ELGAMode, NeedOldPassword)
		{
			txtBenutzer.Text = User.BenutzerName;
			EditUser = false;
            this._bELGAMode = ELGAMode;
            this._bNeedOldPassword = NeedOldPassword;
            _ben = User;
            SetUI();
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPassword));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblPasswort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBenutzer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPasswort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.grpLoginInformationen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblBestätigung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPasswort2 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraToolTipManager2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.txtPasswortHinweis = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPasswortAlt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPasswortAlt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPasswortHinweisChange = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            this.grpLoginInformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweisChange)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(20, 27);
            this.lblBenutzer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(58, 17);
            this.lblBenutzer.TabIndex = 9;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(21, 103);
            this.lblPasswort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(86, 17);
            this.lblPasswort.TabIndex = 10;
            this.lblPasswort.Text = "Passwort neu";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBenutzer.Location = new System.Drawing.Point(116, 23);
            this.txtBenutzer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBenutzer.MaxLength = 25;
            this.txtBenutzer.Name = "txtBenutzer";
            this.txtBenutzer.Size = new System.Drawing.Size(264, 24);
            this.txtBenutzer.TabIndex = 0;
            // 
            // txtPasswort
            // 
            this.txtPasswort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswort.Location = new System.Drawing.Point(117, 100);
            this.txtPasswort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswort.MaxLength = 25;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(263, 24);
            this.txtPasswort.TabIndex = 2;
            this.txtPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswort_KeyDown);
            this.txtPasswort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort_KeyUp);
            // 
            // grpLoginInformationen
            // 
            this.grpLoginInformationen.Controls.Add(this.lblPasswortAlt);
            this.grpLoginInformationen.Controls.Add(this.txtPasswortAlt);
            this.grpLoginInformationen.Controls.Add(this.lblBestätigung);
            this.grpLoginInformationen.Controls.Add(this.txtPasswort2);
            this.grpLoginInformationen.Controls.Add(this.lblBenutzer);
            this.grpLoginInformationen.Controls.Add(this.lblPasswort);
            this.grpLoginInformationen.Controls.Add(this.txtBenutzer);
            this.grpLoginInformationen.Controls.Add(this.txtPasswort);
            this.grpLoginInformationen.Location = new System.Drawing.Point(11, 10);
            this.grpLoginInformationen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLoginInformationen.Name = "grpLoginInformationen";
            this.grpLoginInformationen.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLoginInformationen.Size = new System.Drawing.Size(388, 166);
            this.grpLoginInformationen.TabIndex = 13;
            this.grpLoginInformationen.TabStop = false;
            this.grpLoginInformationen.Text = "Login Informationen";
            // 
            // lblBestätigung
            // 
            this.lblBestätigung.AutoSize = true;
            this.lblBestätigung.Location = new System.Drawing.Point(21, 136);
            this.lblBestätigung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblBestätigung.Name = "lblBestätigung";
            this.lblBestätigung.Size = new System.Drawing.Size(76, 17);
            this.lblBestätigung.TabIndex = 13;
            this.lblBestätigung.Text = "Bestätigung";
            // 
            // txtPasswort2
            // 
            this.txtPasswort2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswort2.Location = new System.Drawing.Point(117, 132);
            this.txtPasswort2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswort2.MaxLength = 25;
            this.txtPasswort2.Name = "txtPasswort2";
            this.txtPasswort2.PasswordChar = '*';
            this.txtPasswort2.Size = new System.Drawing.Size(263, 24);
            this.txtPasswort2.TabIndex = 3;
            this.txtPasswort2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswort2_KeyDown);
            this.txtPasswort2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort2_KeyUp);
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
            this.btnCancel.Location = new System.Drawing.Point(207, 322);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance5;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.Enabled = false;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(335, 322);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 39);
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
            // ultraToolTipManager2
            // 
            this.ultraToolTipManager2.ContainingControl = this;
            // 
            // txtPasswortHinweis
            // 
            this.txtPasswortHinweis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColorDisabled = System.Drawing.Color.Transparent;
            this.txtPasswortHinweis.Appearance = appearance2;
            this.txtPasswortHinweis.Enabled = false;
            this.txtPasswortHinweis.Location = new System.Drawing.Point(11, 184);
            this.txtPasswortHinweis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswortHinweis.MaxLength = 0;
            this.txtPasswortHinweis.Multiline = true;
            this.txtPasswortHinweis.Name = "txtPasswortHinweis";
            this.txtPasswortHinweis.Size = new System.Drawing.Size(388, 66);
            this.txtPasswortHinweis.TabIndex = 16;
            this.txtPasswortHinweis.UseAppStyling = false;
            this.txtPasswortHinweis.Visible = false;
            // 
            // lblPasswortAlt
            // 
            this.lblPasswortAlt.AutoSize = true;
            this.lblPasswortAlt.Location = new System.Drawing.Point(21, 71);
            this.lblPasswortAlt.Margin = new System.Windows.Forms.Padding(4);
            this.lblPasswortAlt.Name = "lblPasswortAlt";
            this.lblPasswortAlt.Size = new System.Drawing.Size(78, 17);
            this.lblPasswortAlt.TabIndex = 15;
            this.lblPasswortAlt.Text = "Passwort alt";
            // 
            // txtPasswortAlt
            // 
            this.txtPasswortAlt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswortAlt.Location = new System.Drawing.Point(117, 68);
            this.txtPasswortAlt.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswortAlt.MaxLength = 25;
            this.txtPasswortAlt.Name = "txtPasswortAlt";
            this.txtPasswortAlt.PasswordChar = '*';
            this.txtPasswortAlt.Size = new System.Drawing.Size(263, 24);
            this.txtPasswortAlt.TabIndex = 1;
            this.txtPasswortAlt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswortAlt_KeyDown);
            this.txtPasswortAlt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswortAlt_KeyUp);
            // 
            // txtPasswortHinweisChange
            // 
            this.txtPasswortHinweisChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColorDisabled = System.Drawing.Color.Transparent;
            this.txtPasswortHinweisChange.Appearance = appearance1;
            this.txtPasswortHinweisChange.Enabled = false;
            this.txtPasswortHinweisChange.Location = new System.Drawing.Point(11, 258);
            this.txtPasswortHinweisChange.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswortHinweisChange.MaxLength = 0;
            this.txtPasswortHinweisChange.Multiline = true;
            this.txtPasswortHinweisChange.Name = "txtPasswortHinweisChange";
            this.txtPasswortHinweisChange.Size = new System.Drawing.Size(388, 56);
            this.txtPasswortHinweisChange.TabIndex = 17;
            this.txtPasswortHinweisChange.UseAppStyling = false;
            this.txtPasswortHinweisChange.Visible = false;
            // 
            // frmEditPassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 369);
            this.ControlBox = false;
            this.Controls.Add(this.txtPasswortHinweisChange);
            this.Controls.Add(this.txtPasswortHinweis);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpLoginInformationen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPassword";
            this.ShowInTaskbar = false;
            this.Text = "Benutzer ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEditPassword_Closing);
            this.Load += new System.EventHandler(this.frmEditPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).EndInit();
            this.grpLoginInformationen.ResumeLayout(false);
            this.grpLoginInformationen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweisChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        protected Benutzer UserObj
        {
            get { return _ben; }
            set { _ben = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
		{
            GuiUtil.ValidateRequired(txtPasswortAlt);
            GuiUtil.ValidateRequired(txtBenutzer);
			GuiUtil.ValidateRequired(txtPasswort);
			GuiUtil.ValidateRequired(txtPasswort2);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

            txtPasswortAlt.Text = txtPasswortAlt.Text.Trim();
            txtBenutzer.Text = txtBenutzer.Text.Trim();
			txtPasswort.Text = txtPasswort.Text.Trim();
			txtPasswort2.Text = txtPasswort2.Text.Trim();

			if (EditUser)
			{
				// txtBenutzer
				GuiUtil.ValidateField(txtBenutzer, (txtBenutzer.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

				if (txtBenutzer.Text.Length > 0)
				{
					GuiUtil.ValidateField(txtBenutzer, Guid.Equals(Benutzer.UserID(txtBenutzer.Text), null),
						ENV.String("GUI.E_USER_EXIST"), ref bError, bInfo, errorProvider1);
				}
			}

            if (_bNeedOldPassword)
            {
                if (this._bELGAMode)
                    GuiUtil.ValidateField(txtPasswortAlt, UserObj.HasELGAPasswort("", txtPasswortAlt.Text), ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
                else
                    GuiUtil.ValidateField(txtPasswortAlt, UserObj.HasPasswort(txtPasswortAlt.Text), ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
            }

            // txtPasswort
            GuiUtil.ValidateField(txtPasswort, (txtPasswort.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtPasswort2
			GuiUtil.ValidateField(txtPasswort2, (txtPasswort2.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			if (txtPasswort.Text.Length > 0)
			{
				GuiUtil.ValidateField(txtPasswort, (txtPasswort.Text == txtPasswort2.Text),
					ENV.String("GUI.E_PASSWORD"), ref bError, bInfo, errorProvider1);
			}

			return !bError;
		}

        private void SetUI()
        {
            this.txtPasswortAlt.Visible = _bNeedOldPassword;
            this.lblPasswortAlt.Visible = _bNeedOldPassword;
            
            if (this._bELGAMode)
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort ändern");
            else
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS-Passwort ändern");

        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual void UpdateDATA()
		{
            if (this._bELGAMode)
            {
                UserObj.ELGAPwd = txtPasswort.Text;
                UserObj.ELGAPwdLastChange = DateTime.Now;

                DB.PMDSBusiness b = new DB.PMDSBusiness();
                string sProt = "Benutzer " + b.getUserName(ENV.USERID) + " hat das ELGA-Passwort geändert.";
                Global.db.ERSystem.ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort wurde geändert"), null,
                                                Global.db.ERSystem.ELGABusiness.eTypeProt.NewPassword, Global.db.ERSystem.ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, null, null, sProt);
            }
            else
            {
                if (UserObj != null)
                    UserObj.Passwort = txtPasswort.Text;
            }
            // KEINE Felder für Übertragung
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (ValidateFields())
			{
				UpdateDATA();                
				_bCanclose = true;
			}
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
		private void frmEditPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// BENUTZER
		/// </summary>
		//----------------------------------------------------------------------------
		public string User
		{
			get	{	return txtBenutzer.Text;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// PASSWORD
		/// </summary>
		//----------------------------------------------------------------------------
		public string Password
		{
			get	{	return txtPasswort.Text;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// EDITUSER
		/// </summary>
		//----------------------------------------------------------------------------
		protected bool EditUser
		{
			get	{	return _bEditUser;	}
			set	
			{	
				_bEditUser = value;	
				txtBenutzer.Enabled = _bEditUser;
			}
		}

        private void frmEditPassword_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void txtPasswortAlt_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void txtPasswort_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void txtPasswort2_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void CheckOkButton()
        {
            this.txtPasswortHinweis.Text = "";
            this.txtPasswortHinweis.Visible = true;
            Application.DoEvents();

            PasswordScore passwordMinStrength = this._bELGAMode ? PasswordScore.VeryStrong : ENV.PasswordStrength;
            PasswordScore passwordStrengthScore = PMDS.Global.Tools.CheckPasswordStrength(txtPasswort.Text.Trim());
            int Punkte = (int)passwordStrengthScore;

            if (passwordStrengthScore >= passwordMinStrength)
            {
                if (txtPasswort.Text == txtPasswort2.Text)
                {
                    if (passwordMinStrength > PasswordScore.Blank)
                    {
                        this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Das neue Passwort ist stark genug (") + Punkte.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Punkte)\n\r");

                        if (_bNeedOldPassword && !PMDS.Global.Tools.ComparePasswords(this.txtPasswortAlt.Text.Trim(), this.txtPasswort.Text.Trim(), 6)) // Wenn altes und neues Passwort zu ähnlich ist
                        {
                            this.txtPasswortHinweis.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Altes und neues Passwort sind zu ähnlich!\n\r");
                            this.btnOK.Enabled = false;
                        }
                        else
                            this.btnOK.Enabled = true;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(txtPasswort.Text))
                        {
                            this.btnOK.Enabled = true;
                        }
                        else
                        {
                            this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Das neue Passwort darf nicht leer sein.\n\r");
                            this.btnOK.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.txtPasswortHinweis.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Passwort und Passwortwiederholung sind unterschiedlich.\n\r");
                    this.btnOK.Enabled = false;
                }
            }
            else
            {
                this.txtPasswortHinweis.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Passwort ist zu schwach: (" + Punkte.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Punkte)\n\r"));
                this.btnOK.Enabled = false;
            }
            Application.DoEvents();
        }

        private void txtPasswortAlt_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }

        private void txtPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }

        private void txtPasswort2_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }
    }
}
