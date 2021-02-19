using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDSClient.Sitemap;

namespace PMDS.GUI
{



	public class frmLogin : QS2.Desktop.ControlManagment.baseForm 
	{
		private Benutzer _ben = null;
        private bool _bCanclose = false;
        protected QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        protected QS2.Desktop.ControlManagment.BaseLabel lblPasswort;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtBenutzer;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswort;
		protected System.Windows.Forms.ErrorProvider errorProvider1;
		protected PMDS.GUI.ucButton btnCancel;
        protected PMDS.GUI.ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
		private System.ComponentModel.IContainer components;



		public frmLogin()
		{
			InitializeComponent();

            RequiredFields();
		}

		public static bool ProcessLogin() 
		{
			bool bRet = ProcessLogin(new frmLogin());
			ENV.SignalQuickfilterChanged(null);

            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
            QS2.Desktop.ControlManagment.ENV.initRigth(ENV.HasRight(UserRights.Layout), ENV.adminSecure);

            if (!bRet)
            {
                WCFServiceClient wcf = new WCFServiceClient();
                wcf.stopCheckWCFServiceLocal(false);
            }

            return bRet;
		}

		protected static bool ProcessLogin(frmLogin frm)
		{
            try
            {
                if (ENV.COMMANDLINE_USER.Length == 0)
                {
                    //qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                    //RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS");
                    cAdminFile ret = ENV.checkAutoLogIn();
                    if (ret.exists)
                    {
                        ENV.COMMANDLINE_USER = ret.usr;
                        ENV.COMMANDLINE_PWD = ret.pwd;

                        object IDBenutzer = Benutzer.UserID(ENV.COMMANDLINE_USER);
                        if (IDBenutzer == null)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (1)");
                            return false;
                        }

                        Benutzer ben2 = new Benutzer((Guid)IDBenutzer);
                        if (!ben2.HasPasswort(ENV.COMMANDLINE_PWD))
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (2)");
                            return false;
                        }
                        frm.User = ben2;
                    }
                    else
                    {
                        DialogResult res = frm.ShowDialog();
                        if (res != DialogResult.OK)
                            return false;
                        //else
                        //{
                        //    return true;
                        //}
                    }
                }
                else                        // Benutzer und Passwort sind über die Commandline übergeben worden
                {
                    object IDBenutzer = Benutzer.UserID(ENV.COMMANDLINE_USER);
                    if (IDBenutzer == null)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (3)");
                        return false;
                    }

                    Benutzer ben2 = new Benutzer((Guid)IDBenutzer);
                    if (!ben2.HasPasswort(ENV.COMMANDLINE_PWD))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (4)");
                        return false;
                    }
                    frm.User = ben2;
                }

                if (frmLogin.rechteLesen(frm))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("frmLogin.ProcessLogin: " + ex.ToString());
            }
        }
        protected static bool rechteLesen(frmLogin frm)
        {
            Benutzer ben = frm.User ;

            // Die dem Benutzer zugeordneten Abteilungen neu im ENV verspeichern
            ENV.CurrentUserAbteilungen.Clear();
            foreach (dsBenutzerAbteilung.BenutzerAbteilungRow r in ben.BenutzerAbteilung)
                ENV.CurrentUserAbteilungen.Add(r.IDAbteilung);

            ENV.UserWithAbteilungLoggedOn(ben.ID, ben.IDBerufsstand, Gruppe.ByBenutzer(ben.ID), ben.PflegerJN);

            ENV.COMMANDLINE_USER = "";
            ENV.COMMANDLINE_PWD = "";
            //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("osxy: Rechte wurden gelesen");
            return true;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual void frmLogin_Load(object sender, System.EventArgs e)
		{
			try
			{
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    //ControlManagment1.autoTranslateForm(this);
                }
                //Text = string.Format(Text, ENV.DATABASE);
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS");

                this.btnCancel.Appearance.Image = null;
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                //this.btnOK.Text = "OK";
                this.btnCancel.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abbrechen");

                // ENV user setzten
                if (ENV.USERID == Guid.Empty)
					User = null;
				else
				{
					User = new Benutzer(ENV.USERID);
					txtBenutzer.Text = User.BenutzerName;
				}

#if DEBUG
                //txtBenutzer.Text = "admin";
                //txtPasswort.Text = "admin";
#endif 

				UpdateGUI();

                this.TopMost = true;
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblPasswort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBenutzer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtPasswort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(9, 70);
            this.lblBenutzer.Margin = new System.Windows.Forms.Padding(4);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(60, 17);
            this.lblBenutzer.TabIndex = 9;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(9, 100);
            this.lblPasswort.Margin = new System.Windows.Forms.Padding(4);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(61, 17);
            this.lblPasswort.TabIndex = 10;
            this.lblPasswort.Text = "Passwort";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.Location = new System.Drawing.Point(105, 66);
            this.txtBenutzer.Margin = new System.Windows.Forms.Padding(4);
            this.txtBenutzer.MaxLength = 25;
            this.txtBenutzer.Name = "txtBenutzer";
            this.txtBenutzer.Size = new System.Drawing.Size(205, 24);
            this.txtBenutzer.TabIndex = 11;
            this.txtBenutzer.ValueChanged += new System.EventHandler(this.txtBenutzer_ValueChanged);
            // 
            // txtPasswort
            // 
            this.txtPasswort.Location = new System.Drawing.Point(105, 96);
            this.txtPasswort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswort.MaxLength = 25;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(205, 24);
            this.txtPasswort.TabIndex = 12;
            this.txtPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswort_KeyDown);
            // 
            // btnCancel
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(105, 133);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 34);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(229, 133);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 34);
            this.btnOK.TabIndex = 15;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblInfo
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Appearance = appearance3;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(9, 21);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(301, 28);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "Anmeldung an PMDS";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.Snow;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 182);
            this.Controls.Add(this.lblBenutzer);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtBenutzer);
            this.Controls.Add(this.txtPasswort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Login on {0} ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEditPassword_Closing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected bool ValidateFields()
		{

			bool bError = false;
			bool bInfo = true;

			txtBenutzer.Text = txtBenutzer.Text.Trim();
			txtPasswort.Text = txtPasswort.Text.Trim();

			// txtBenutzer
			GuiUtil.ValidateField(txtBenutzer, (txtBenutzer.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            object o = Benutzer.UserID(txtBenutzer.Text);

            if (o == null)
                User = null;
            else
                User = new Benutzer((Guid)o);

			if (txtBenutzer.Text.Length > 0)
			{
				// txtBenutzer existiert
				GuiUtil.ValidateField(txtBenutzer, (User != null),
					ENV.String("GUI.E_INVALID_USER"), ref bError, bInfo, errorProvider1);

				GuiUtil.ValidateField(txtBenutzer, ((User != null) && User.AktivJN),
					ENV.String("GUI.E_USER_DISABLED"), ref bError, bInfo, errorProvider1);
			}

			// Benutzer vorhanden
			if (User != null)
			{
                if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkClientsS2())
                {
                    // txtPasswort
                    GuiUtil.ValidateField(txtPasswort, (txtPasswort.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

                    if (txtPasswort.Text.Length > 0)
                    {
                        // txtPasswort korrekt
                        GuiUtil.ValidateField(txtPasswort, User.HasPasswort(txtPasswort.Text),
                            ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
                    }
                }
			}

			return !bError;
		}
		
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (ValidateFields())
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
		private void frmEditPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benutzer ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public Benutzer User
		{
			get	{	return _ben;	}
			set	{	_ben = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benutzer ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		private void txtBenutzer_ValueChanged(object sender, System.EventArgs e)
		{

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateGUI()
		{
		}

        private void txtPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            PMDS.Global.generic.TogglePassword(sender);
            //if (ModifierKeys.HasFlag(Keys.Control))
            //{
            //    QS2.Desktop.ControlManagment.BaseTextEditor ed = (QS2.Desktop.ControlManagment.BaseTextEditor)sender;
            //    if (ed.PasswordChar == '\0')
            //        ed.PasswordChar = '*';
            //    else
            //        ed.PasswordChar = '\0';
            //    Application.DoEvents();
            //}
        }
    }
}
