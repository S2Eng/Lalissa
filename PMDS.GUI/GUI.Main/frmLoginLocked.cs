//----------------------------------------------------------------------------
/// <summary>
///	frmLoginLocked.cs
/// Erstellt am:	1.8.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zur Login-Sperre
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmLoginLocked : PMDS.GUI.frmLogin
    {
		private System.ComponentModel.IContainer components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmLoginLocked()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

		public static bool ProcessLocked() 
		{
			return ProcessLogin(new frmLoginLocked());
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
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.BackColor = System.Drawing.Color.Beige;
            this.txtBenutzer.Text = "admin";
            // 
            // txtPasswort
            // 
            this.txtPasswort.BackColor = System.Drawing.Color.Beige;
            // 
            // btnCancel
            // 
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmLoginLocked
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(242, 144);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLoginLocked";
            this.ShowInTaskbar = false;
            this.Text = "PMDS gesperrt von {0} ...";
            this.Load += new System.EventHandler(this.frmLoginLocked_Load);
            this.VisibleChanged += new System.EventHandler(this.frmLoginLocked_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void frmLogin_Load(object sender, EventArgs e)
		{
			string format = Text;
			base.frmLogin_Load (sender, e);
			Text = string.Format(format, txtBenutzer.Text);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Beim Sperren wird die Aktive Form minimiert und beim 
		/// Schlieﬂen wieder hergestellt.
		/// </summary>
		//----------------------------------------------------------------------------
		private void frmLoginLocked_VisibleChanged(object sender, System.EventArgs e)
		{
			Form f = Form.ActiveForm;
			if (f != null)
			{
				if (this.Visible)
				{
					f.WindowState = FormWindowState.Minimized;
					this.Show();
					this.Activate();
				}
				else
					f.WindowState = FormWindowState.Normal;
			}
		}

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmLoginLocked_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            btnCancel.Appearance.Image = null;

        }
	}
}

