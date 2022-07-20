//----------------------------------------------------------------------------
/// <summary>
///	frmBenutzer.cs
/// Erstellt am:	16.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;



namespace PMDS.GUI
{


	public class frmBenutzer : frmBase
    {
        public ucBenutzerEdit ucBenutzerEdit1;
		private System.ComponentModel.IContainer components;

        public bool _OnlyAbteilungBereiche = false;

		public frmBenutzer(bool OnlyAbteilungBereiche)
		{
            this._OnlyAbteilungBereiche = OnlyAbteilungBereiche;
			InitializeComponent();
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this._OnlyAbteilungBereiche = OnlyAbteilungBereiche;
            this.ucBenutzerEdit1._OnlyAbteilungBereiche = OnlyAbteilungBereiche;
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
            this.ucBenutzerEdit1 = new PMDS.GUI.ucBenutzerEdit();
            this.SuspendLayout();
            // 
            // ucBenutzerEdit1
            // 
            this.ucBenutzerEdit1.BackColor = System.Drawing.Color.Transparent;
            this.ucBenutzerEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucBenutzerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBenutzerEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBenutzerEdit1.Location = new System.Drawing.Point(0, 0);
            this.ucBenutzerEdit1.Name = "ucBenutzerEdit1";
            this.ucBenutzerEdit1.Size = new System.Drawing.Size(1004, 737);
            this.ucBenutzerEdit1.TabIndex = 0;
            this.ucBenutzerEdit1.Load += new System.EventHandler(this.ucBenutzerEdit1_Load);
            // 
            // frmBenutzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1004, 737);
            this.Controls.Add(this.ucBenutzerEdit1);
            this.Name = "frmBenutzer";
            this.Text = "Benutzerverwaltung ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmBenutzer_Load);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !ucBenutzerEdit1.CanClose;
		}

        private void frmBenutzer_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

        private void ucBenutzerEdit1_Load(object sender, EventArgs e)
        {

        }
	}
}
