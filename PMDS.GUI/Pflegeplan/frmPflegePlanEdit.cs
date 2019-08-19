//----------------------------------------------------------------------------
/// <summary>
///	frmPflegePlanEdit.cs - Bearbeiten eines Pflegeplaneintrages
/// Erstellt am:	25.10.2004
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Data.PflegePlan;
using PMDS.Global;

namespace PMDS.GUI
{
	public class frmPflegePlanEdit : QS2.Desktop.ControlManagment.baseForm , IReadOnly
	{

		private dsPflegePlan.PflegePlanRow		_row =null;
		private PMDS.GUI.ucPflegePlanSingleEdit ucPflegePlanSingleEdit1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private System.ComponentModel.IContainer components;


		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Übergeben wird die zu bearbeitende PflegeplanRow
		/// </summary>
		//----------------------------------------------------------------------------
		public frmPflegePlanEdit(dsPflegePlan.PflegePlanRow Row)
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            _row = Row;
            if (DesignMode)
                return;
            RefreshCaption();
		}

        private void RefreshCaption()
        {
            labInfo.Text = string.Format("{0} aktualisieren", ENV.String( _row.EintragGruppe+ "_single"));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPflegePlanEdit));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucPflegePlanSingleEdit1 = new PMDS.GUI.ucPflegePlanSingleEdit();
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
            this.labInfo.Size = new System.Drawing.Size(558, 42);
            this.labInfo.TabIndex = 4;
            this.labInfo.Text = "Bearbeiten eines Pflegeplaneintrages";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 658);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(502, 658);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucPflegePlanSingleEdit1
            // 
            this.ucPflegePlanSingleEdit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPflegePlanSingleEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPflegePlanSingleEdit1.Location = new System.Drawing.Point(0, 42);
            this.ucPflegePlanSingleEdit1.Name = "ucPflegePlanSingleEdit1";
            this.ucPflegePlanSingleEdit1.ReadOnly = false;
            this.ucPflegePlanSingleEdit1.Size = new System.Drawing.Size(558, 617);
            this.ucPflegePlanSingleEdit1.TabIndex = 5;
            this.ucPflegePlanSingleEdit1.TransferMode = false;
            // 
            // frmPflegePlanEdit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(558, 690);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPflegePlanSingleEdit1);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPflegePlanEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pflegeeintrag bearbeiten ...";
            this.Load += new System.EventHandler(this.frmPflegePlanEdit_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(ucPflegePlanSingleEdit1.IsOriginalModified()) 
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("PP_ORIGINAL_TEXT_CHANGED"), 
					                                                                ENV.String("DIALOGTITLE_PP_ORIGINAL_TEXT_CHANGED"), 
					                                                                MessageBoxButtons.YesNoCancel, 
					                                                                MessageBoxIcon.Question, true);
				if(res == DialogResult.Yes)
				{
					ucPflegePlanSingleEdit1.AcceptChanges();
					this.Close();
				}
				return;
			}

			ucPflegePlanSingleEdit1.AcceptChanges();
			this.Close();
		}

		private void frmPflegePlanEdit_Load(object sender, System.EventArgs e)
		{
				ucPflegePlanSingleEdit1.PFLEGEPLANROW = _row;
		}
		#region IReadOnly Members

		public bool ReadOnly
		{
			get
			{
				return ucPflegePlanSingleEdit1.ReadOnly;
			}
			set
			{
				ucPflegePlanSingleEdit1.ReadOnly = value;
			}
		}

		#endregion
	}
}
