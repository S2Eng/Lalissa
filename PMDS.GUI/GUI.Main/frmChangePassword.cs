//----------------------------------------------------------------------------
/// <summary>
///	frmChangePassword.cs
/// Erstellt am:	06.04.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Ändern des Benutzer-Passwortes
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmChangePassword : frmEditPassword
	{
        private Benutzer _ben;
        private bool _bELGAMode;

        protected QS2.Desktop.ControlManagment.BaseLabel lblPasswortAlt;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswortOld;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswortHinweisChange;
		private System.ComponentModel.IContainer components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmChangePassword(Benutzer user, bool ELGAMode) : base(ELGAMode, user.BenutzerName)
		{
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            this._bELGAMode = ELGAMode;
            UserObj = user;
			InitializeComponent();
            SetCaption();
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblPasswortAlt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPasswortOld = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPasswortHinweisChange = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            this.grpLoginInformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweisChange)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel3
            // 
            this.lblBenutzer.Location = new System.Drawing.Point(8, 35);
            this.lblBenutzer.TabIndex = 0;
            // 
            // ultraLabel4
            // 
            this.lblPasswort.Location = new System.Drawing.Point(8, 99);
            this.lblPasswort.Size = new System.Drawing.Size(73, 14);
            this.lblPasswort.TabIndex = 4;
            this.lblPasswort.Text = "Passwort neu";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.BackColor = System.Drawing.Color.LightYellow;
            this.txtBenutzer.TabIndex = 1;
            // 
            // txtPasswort
            // 
            this.txtPasswort.BackColor = System.Drawing.Color.LightYellow;
            this.txtPasswort.Location = new System.Drawing.Point(88, 96);
            this.txtPasswort.TabIndex = 5;
            this.txtPasswort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort_KeyUp_1);
            // 
            // groupBox1
            // 
            this.grpLoginInformationen.Controls.Add(this.lblPasswortAlt);
            this.grpLoginInformationen.Controls.Add(this.txtPasswortOld);
            this.grpLoginInformationen.Size = new System.Drawing.Size(272, 152);
            this.grpLoginInformationen.TabIndex = 0;
            this.grpLoginInformationen.Controls.SetChildIndex(this.txtPasswort, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.txtBenutzer, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.lblPasswort, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.lblBenutzer, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.txtPasswort2, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.lblBestätigung, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.txtPasswortOld, 0);
            this.grpLoginInformationen.Controls.SetChildIndex(this.lblPasswortAlt, 0);
            // 
            // ultraLabel1
            // 
            this.lblBestätigung.Location = new System.Drawing.Point(8, 123);
            this.lblBestätigung.TabIndex = 6;
            // 
            // txtPasswort2
            // 
            this.txtPasswort2.BackColor = System.Drawing.Color.LightYellow;
            this.txtPasswort2.Location = new System.Drawing.Point(88, 120);
            this.txtPasswort2.TabIndex = 7;
            this.txtPasswort2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort2_KeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(136, 165);
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 165);
            this.btnOK.TabIndex = 2;
            // 
            // txtPasswortHinweis
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswortHinweis.Appearance = appearance1;
            this.txtPasswortHinweis.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswortHinweis.Location = new System.Drawing.Point(8, 248);
            // 
            // lblPasswortAlt
            // 
            this.lblPasswortAlt.AutoSize = true;
            this.lblPasswortAlt.Location = new System.Drawing.Point(8, 75);
            this.lblPasswortAlt.Name = "lblPasswortAlt";
            this.lblPasswortAlt.Size = new System.Drawing.Size(66, 14);
            this.lblPasswortAlt.TabIndex = 2;
            this.lblPasswortAlt.Text = "Passwort alt";
            // 
            // txtPasswortOld
            // 
            this.txtPasswortOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswortOld.Location = new System.Drawing.Point(88, 72);
            this.txtPasswortOld.MaxLength = 25;
            this.txtPasswortOld.Name = "txtPasswortOld";
            this.txtPasswortOld.PasswordChar = '*';
            this.txtPasswortOld.Size = new System.Drawing.Size(168, 21);
            this.txtPasswortOld.TabIndex = 3;
            this.txtPasswortOld.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswortOld_KeyUp);
            // 
            // txtPasswortHinweisChange
            // 
            this.txtPasswortHinweisChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswortHinweisChange.Enabled = false;
            this.txtPasswortHinweisChange.Location = new System.Drawing.Point(8, 221);
            this.txtPasswortHinweisChange.MaxLength = 25;
            this.txtPasswortHinweisChange.Name = "txtPasswortHinweisChange";
            this.txtPasswortHinweisChange.Size = new System.Drawing.Size(268, 21);
            this.txtPasswortHinweisChange.TabIndex = 17;
            this.txtPasswortHinweisChange.Visible = false;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 351);
            this.ControlBox = true;
            this.Controls.Add(this.txtPasswortHinweisChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChangePassword";
            this.Text = "Passwort ändern ...";
            this.Controls.SetChildIndex(this.grpLoginInformationen, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtPasswortHinweis, 0);
            this.Controls.SetChildIndex(this.txtPasswortHinweisChange, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).EndInit();
            this.grpLoginInformationen.ResumeLayout(false);
            this.grpLoginInformationen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweisChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benutzer ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		protected Benutzer UserObj
		{
			get	{	return _ben;	}
			set	{	_ben = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected new void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtPasswortOld);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected override bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;
            txtPasswortOld.Text = txtPasswortOld.Text.Trim();

            if (this._bELGAMode)
            {
                // ELGA: txtPasswortOld korrekt
                GuiUtil.ValidateField(txtPasswortOld, UserObj.HasELGAPasswort("", txtPasswortOld.Text), ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
                if (!bError)
                    bError = !base.ValidateFields();
            }
            else
            {
                // PMDS: txtPasswortOld korrekt
                GuiUtil.ValidateField(txtPasswortOld, UserObj.HasPasswort(txtPasswortOld.Text), ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);

                // Passwort korrekt -> weiter validieren
                if (!bError)
                    bError = !base.ValidateFields();
            }
            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI nach Daten übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        protected override void UpdateDATA()
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
                UserObj.Passwort = txtPasswort.Text;
        }

        private void txtPasswort_KeyUp_1(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void txtPasswortOld_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void txtPasswort2_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void SetCaption()
        {
            if (this._bELGAMode)
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort ändern");
            else
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS-Passwort ändern");
        }

        private void CheckOkButton()
        {
            this.txtPasswortHinweisChange.Text = "";
            this.txtPasswortHinweisChange.Visible = false;
            PasswordScore MinpasswordStrengthScore = ENV.PasswordStrength;

            PasswordScore passwordStrengthScore = PMDS.Global.Tools.CheckPasswordStrength(txtPasswort.Text.Trim());

            if (_bELGAMode)
                MinpasswordStrengthScore = PasswordScore.VeryStrong;

            bool compPasswords = true;

            if (MinpasswordStrengthScore >= PasswordScore.Strong)
                compPasswords = PMDS.Global.Tools.ComparePasswords(this.txtPasswortOld.Text.Trim(), this.txtPasswort.Text.Trim(), 6); // Wenn im alten und neuen Passwort 6 gleiche Zeichen hintereinader sind -> Passwort ist nicht erlaubt

            if (compPasswords == false)
            {
                this.txtPasswortHinweisChange.Visible = true;
                this.txtPasswortHinweisChange.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Altes und neues Passwort sind zu ähnlich!");

                this.btnOK.Enabled = false;
                Application.DoEvents();
            }
        }



    }
}

