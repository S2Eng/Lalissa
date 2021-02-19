//----------------------------------------------------------------------------
/// <summary>
///	frmASZM.cs
/// Erstellt am:	10.12.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zum Bearbeiten der ASZM-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmASZM : QS2.Desktop.ControlManagment.baseForm 
    {
		private PMDS.GUI.ucKatalogeEdit ucKatalogeEdit1;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        private ucButton btnCancel;
		private System.ComponentModel.IContainer components;

        private KatalogEditModes            _mode;
				
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmASZM(KatalogEditModes mode)
		{
            _mode = mode;
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucKatalogeEdit1.EditMode = mode;
            if (mode != KatalogEditModes.All)
            {
                labInfo.Visible = false;
                this.Width -= 216;                  // Die Explorer bar wird hier nicht dargestellt
                this.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} hinzufügen"), ENV.String(mode.ToString()));
            }
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public frmASZM()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die gerade ausgewählte ASZM (Für Mode != .ALL)
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid CURRENT_SELECTED
        {
            get
            {
                return ucKatalogeEdit1.CURRENT_SELECTED;
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmASZM));
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.ucKatalogeEdit1 = new PMDS.GUI.ucKatalogeEdit();
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
            this.labInfo.Size = new System.Drawing.Size(1124, 48);
            this.labInfo.TabIndex = 2;
            this.labInfo.Text = "Ätiologien/Risikofaktoren, Symptome, Ressourcen, Ziele, Maßnahmen - Verwaltung";
            // 
            // btnCancel
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucKatalogeEdit1
            // 
            this.ucKatalogeEdit1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucKatalogeEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKatalogeEdit1.EditMode = PMDS.Global.KatalogEditModes.All;
            this.ucKatalogeEdit1.Location = new System.Drawing.Point(0, 48);
            this.ucKatalogeEdit1.Name = "ucKatalogeEdit1";
            this.ucKatalogeEdit1.Size = new System.Drawing.Size(1124, 617);
            this.ucKatalogeEdit1.TabIndex = 4;
            this.ucKatalogeEdit1.Tag = "Dontpatch";
            this.ucKatalogeEdit1.Close += new System.EventHandler(this.ucKatalogeEdit1_Close);
            this.ucKatalogeEdit1.Load += new System.EventHandler(this.ucKatalogeEdit1_Load);
            // 
            // frmASZM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1124, 665);
            this.Controls.Add(this.ucKatalogeEdit1);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(966, 678);
            this.Name = "frmASZM";
            this.Text = "ASZM ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmASZM_Closing);
            this.Load += new System.EventHandler(this.frmASZM_Load);
            this.Enter += new System.EventHandler(this.frmASZM_Enter);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmASZM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (_mode != KatalogEditModes.All)          // Speichern bereits erfolgt bzw. Abbruch
                return;
        
			if(ucKatalogeEdit1.CONTENT_CHANGED)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
					                                                                        ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
					                                                                        MessageBoxButtons.YesNoCancel, 
					                                                                        MessageBoxIcon.Question, true);      

                if (res == DialogResult.Yes) 
				{
					ucKatalogeEdit1.Save();				

					return;
				}
				
				if(res == DialogResult.No)
					return;

				e.Cancel = true;
			}
		}

		private void ucKatalogeEdit1_Close(object sender, EventArgs e)
		{
			this.Close();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmASZM_Load(object sender, EventArgs e)
        {
            
        }

        private void ucKatalogeEdit1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmASZM_Enter(object sender, EventArgs e)
        {
            ucKatalogeEdit1.FocusOnASZMText();
        }
	}
}
