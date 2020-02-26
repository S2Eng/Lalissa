//----------------------------------------------------------------------------
/// <summary>
///	frmLogin.cs
/// Erstellt am:	20.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;




namespace PMDS.GUI
{


	public class frmLock : QS2.Desktop.ControlManagment.baseForm 
	{
        private bool _bCanclose = false;



        protected QS2.Desktop.ControlManagment.BaseLabel lblPasswort;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtPasswort;
		protected System.Windows.Forms.ErrorProvider errorProvider1;
		protected PMDS.GUI.ucButton btnNewLogIn;
        protected PMDS.GUI.ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfoLocked;
        private Timer timerCloseApp;
        private System.ComponentModel.IContainer components;
        private QS2.Desktop.ControlManagment.BaseLabel lblTimeRemaining;
        private int iTimeOut = ENV.AutoCloseTime;  
        private int iTicks = 60000;      //Prod = 60000;
        public bool TimeOutElapsed = false;
        public bool PasswordOk = false;

        public frmLock()
		{
			InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            RequiredFields();
		}


		protected virtual void frmLogin_Load(object sender, System.EventArgs e)
		{
			try
			{

                this.timerCloseApp.Enabled = true;
                this.timerCloseApp.Interval = iTicks; //Minuten zum herunterzählen
                this.timerCloseApp.Start();

                string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Restliche Sperrzeit: {0} Minuten.");
                sText = string.Format(sText, iTimeOut.ToString());
                this.lblTimeRemaining.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes(sText);

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                
				//Text = string.Format(Text, ENV.DATABASE);
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Gesperrt");

                this.btnNewLogIn.Appearance.Image = null;
                this.btnNewLogIn.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Neu anmelden");

                PMDS.BusinessLogic.Benutzer usr = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
                this.lblInfoLocked.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gesperrt von ") + usr.BenutzerName;
                
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                txtPasswort.Text = "";
				UpdateGUI();	
                
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLock));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblPasswort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPasswort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnNewLogIn = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblInfoLocked = new QS2.Desktop.ControlManagment.BaseLabel();
            this.timerCloseApp = new System.Windows.Forms.Timer(this.components);
            this.lblTimeRemaining = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(7, 52);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(51, 14);
            this.lblPasswort.TabIndex = 10;
            this.lblPasswort.Text = "Passwort";
            // 
            // txtPasswort
            // 
            this.txtPasswort.Location = new System.Drawing.Point(79, 49);
            this.txtPasswort.MaxLength = 25;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(176, 21);
            this.txtPasswort.TabIndex = 12;
            // 
            // btnNewLogIn
            // 
            this.btnNewLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnNewLogIn.Appearance = appearance1;
            this.btnNewLogIn.AutoWorkLayout = false;
            this.btnNewLogIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNewLogIn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewLogIn.DoOnClick = true;
            this.btnNewLogIn.IsStandardControl = true;
            this.btnNewLogIn.Location = new System.Drawing.Point(79, 117);
            this.btnNewLogIn.Name = "btnNewLogIn";
            this.btnNewLogIn.Size = new System.Drawing.Size(99, 28);
            this.btnNewLogIn.TabIndex = 14;
            this.btnNewLogIn.TabStop = false;
            this.btnNewLogIn.TYPE = PMDS.GUI.ucButton.ButtonType.none;
            this.btnNewLogIn.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnNewLogIn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnNewLogIn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnNewLogIn.Click += new System.EventHandler(this.btnNewLogIn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnOK.Location = new System.Drawing.Point(181, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 28);
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
            // lblInfoLocked
            // 
            this.lblInfoLocked.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.lblInfoLocked.Appearance = appearance3;
            this.lblInfoLocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoLocked.Location = new System.Drawing.Point(7, 14);
            this.lblInfoLocked.Name = "lblInfoLocked";
            this.lblInfoLocked.Size = new System.Drawing.Size(257, 23);
            this.lblInfoLocked.TabIndex = 17;
            this.lblInfoLocked.Text = "Gesperrt";
            // 
            // timerCloseApp
            // 
            this.timerCloseApp.Tick += new System.EventHandler(this.timerCloseApp_Tick);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Location = new System.Drawing.Point(81, 80);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(173, 21);
            this.lblTimeRemaining.TabIndex = 18;
            // 
            // frmLock
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnNewLogIn;
            this.ClientSize = new System.Drawing.Size(268, 150);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblInfoLocked);
            this.Controls.Add(this.txtPasswort);
            this.Controls.Add(this.btnNewLogIn);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLock";
            this.Text = "Login on {0} ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEditPassword_Closing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtPasswort);
		}

		protected bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;
            PasswordOk = false;

			txtPasswort.Text = txtPasswort.Text.Trim();
            PMDS.BusinessLogic.Benutzer usr = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
		    // txtPasswort
		    GuiUtil.ValidateField(txtPasswort, (txtPasswort.Text.Length > 0),
			    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

		    if (txtPasswort.Text.Length > 0)
		    {
			    // txtPasswort korrekt
                GuiUtil.ValidateField(txtPasswort, usr.HasPasswort(txtPasswort.Text),
				    ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
		    }

            PasswordOk = !bError;
            return !bError;
		}
		
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (TimeOutElapsed | ValidateFields())
				_bCanclose = true;
		}

		private void frmEditPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}


		private void UpdateGUI()
		{
		}

        private void btnNewLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.Global.UIGlobal.NewLogIn("pmds", false);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void timerCloseApp_Tick(object sender, EventArgs e)
        {
            iTimeOut--;
            if (iTimeOut <= 0)
            {
                this.lblPasswort.Visible = false;
                this.txtPasswort.Visible = false;
                this.btnNewLogIn.Visible = false;
                this.lblTimeRemaining.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sperrzeit ist abgelaufen!");
                TimeOutElapsed = true;
                btnOK_Click(sender, e);
            }
            else
            {
                if (iTimeOut == 1)
                    this.lblTimeRemaining.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Restliche Sperrzeit: eine Minute."); 
                else
                {
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Restliche Sperrzeit: {0} Minuten.");
                    sText = string.Format(sText, iTimeOut.ToString());
                    this.lblTimeRemaining.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes(sText);
                }
            }
        }
    }
}
