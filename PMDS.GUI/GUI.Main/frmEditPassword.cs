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
		private bool _bCanclose = false;
        private bool _bEditUser = false;
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
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmEditPassword()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }


            RequiredFields();
			EditUser = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmEditPassword(string aUser) : this()
		{
			txtBenutzer.Text = aUser;
			EditUser = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPassword));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            this.grpLoginInformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswortHinweis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(16, 35);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(50, 14);
            this.lblBenutzer.TabIndex = 9;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(16, 67);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(51, 14);
            this.lblPasswort.TabIndex = 10;
            this.lblPasswort.Text = "Passwort";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBenutzer.Location = new System.Drawing.Point(88, 32);
            this.txtBenutzer.MaxLength = 25;
            this.txtBenutzer.Name = "txtBenutzer";
            this.txtBenutzer.Size = new System.Drawing.Size(168, 21);
            this.txtBenutzer.TabIndex = 11;
            this.txtBenutzer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBenutzer_KeyUp);
            // 
            // txtPasswort
            // 
            this.txtPasswort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswort.Location = new System.Drawing.Point(88, 64);
            this.txtPasswort.MaxLength = 25;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(168, 21);
            this.txtPasswort.TabIndex = 12;
            this.txtPasswort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort_KeyUp);
            // 
            // grpLoginInformationen
            // 
            this.grpLoginInformationen.Controls.Add(this.lblBestätigung);
            this.grpLoginInformationen.Controls.Add(this.txtPasswort2);
            this.grpLoginInformationen.Controls.Add(this.lblBenutzer);
            this.grpLoginInformationen.Controls.Add(this.lblPasswort);
            this.grpLoginInformationen.Controls.Add(this.txtBenutzer);
            this.grpLoginInformationen.Controls.Add(this.txtPasswort);
            this.grpLoginInformationen.Location = new System.Drawing.Point(8, 8);
            this.grpLoginInformationen.Name = "grpLoginInformationen";
            this.grpLoginInformationen.Size = new System.Drawing.Size(272, 128);
            this.grpLoginInformationen.TabIndex = 13;
            this.grpLoginInformationen.TabStop = false;
            this.grpLoginInformationen.Text = "Login Informationen";
            // 
            // lblBestätigung
            // 
            this.lblBestätigung.AutoSize = true;
            this.lblBestätigung.Location = new System.Drawing.Point(16, 89);
            this.lblBestätigung.Name = "lblBestätigung";
            this.lblBestätigung.Size = new System.Drawing.Size(64, 14);
            this.lblBestätigung.TabIndex = 13;
            this.lblBestätigung.Text = "Bestätigung";
            // 
            // txtPasswort2
            // 
            this.txtPasswort2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswort2.Location = new System.Drawing.Point(88, 86);
            this.txtPasswort2.MaxLength = 25;
            this.txtPasswort2.Name = "txtPasswort2";
            this.txtPasswort2.PasswordChar = '*';
            this.txtPasswort2.Size = new System.Drawing.Size(168, 21);
            this.txtPasswort2.TabIndex = 14;
            this.txtPasswort2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswort2_KeyUp);
            // 
            // btnCancel
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(137, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.Enabled = false;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(233, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 15;
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
            appearance3.BackColorDisabled = System.Drawing.Color.Transparent;
            this.txtPasswortHinweis.Appearance = appearance3;
            this.txtPasswortHinweis.Enabled = false;
            this.txtPasswortHinweis.Location = new System.Drawing.Point(12, 189);
            this.txtPasswortHinweis.MaxLength = 0;
            this.txtPasswortHinweis.Multiline = true;
            this.txtPasswortHinweis.Name = "txtPasswortHinweis";
            this.txtPasswortHinweis.Size = new System.Drawing.Size(268, 89);
            this.txtPasswortHinweis.TabIndex = 16;
            this.txtPasswortHinweis.UseAppStyling = false;
            this.txtPasswortHinweis.Visible = false;
            // 
            // frmEditPassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(304, 290);
            this.ControlBox = false;
            this.Controls.Add(this.txtPasswortHinweis);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpLoginInformationen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual void UpdateDATA()
		{
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

        private void txtPasswort_KeyUp(object sender, KeyEventArgs e)
        {
            CheckOkButton();
        }

        private void txtBenutzer_KeyUp(object sender, KeyEventArgs e)
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
            this.txtPasswortHinweis.Visible = false;
            Application.DoEvents();


            PasswordScore passwordStrengthScore = PMDS.Global.Tools.CheckPasswordStrength(txtPasswort.Text.Trim());

            if (passwordStrengthScore >= ENV.PasswordStrength)
            {
                if (txtPasswort.Text == txtPasswort2.Text)
                {
                    if (ENV.PasswordStrength > PasswordScore.Blank)
                    {
                        this.txtPasswortHinweis.Visible = true;
                        int Punkte = (int)passwordStrengthScore;
                        this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Das neue Passwort ist stark genug (") + Punkte.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Punkte)\n\r");

                        this.btnOK.Enabled = true;
                        Application.DoEvents();
                    }
                    else
                    {
                        if (txtPasswort.Text != "")
                        {
                            this.txtPasswortHinweis.Visible = false;
                            this.txtPasswortHinweis.Text += "";
                            this.btnOK.Enabled = true;
                            Application.DoEvents();
                        }
                        else
                        {
                            this.txtPasswortHinweis.Visible = true;
                            this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Das neue Passwort darf nicht leer sein.\n\r");
                            this.btnOK.Enabled = false;
                            Application.DoEvents();
                        }
                    }
                }
                else
                {
                    this.txtPasswortHinweis.Visible = true;
                    this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Passwort und Passwortwiederholung sind unterschiedlich.\n\r");
                    this.btnOK.Enabled = false;
                    Application.DoEvents();
                }
            }
            else
            {
                this.txtPasswortHinweis.Visible = true;
                this.txtPasswortHinweis.Text += QS2.Desktop.ControlManagment.ControlManagment.getRes("Passwort ist zu schwach.\n\r");
                this.btnOK.Enabled = false;
                Application.DoEvents();
            }                    
        }


	}
}
