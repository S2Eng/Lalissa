using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Edit der Wochentage
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmIntervallEdit : frmBase
	{
		private int						_Intervall = 24;	// Default 24 Stunden

		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseNumericEditor tbIntervall;
		private QS2.Desktop.ControlManagment.BaseLabel lblintervall;
		private QS2.Desktop.ControlManagment.BaseOptionSet osIntervall;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Benötigt iWochentage BitCodiert Bit 0 = MO
		/// </summary>
		//----------------------------------------------------------------------------
		public frmIntervallEdit(int iStundenIntervall)
		{
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            _Intervall = iStundenIntervall;
			SetIntervall();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt die Richtigen Werte auf Tage/Wochen umgerechnet
		/// </summary>
		//----------------------------------------------------------------------------
		private void SetIntervall() 
		{
            if (_Intervall % 721 == 0)							// Monate
            {
                tbIntervall.Value = _Intervall / 721;
                osIntervall.CheckedIndex = 0;
            }
			else if( _Intervall % 168 == 0)							// woche
			{
				tbIntervall.Value = _Intervall / 168;			
				osIntervall.CheckedIndex = 1;
			} 
			else if (_Intervall % 24 == 0)							// Tage
			{
				tbIntervall.Value = _Intervall / 24;			
				osIntervall.CheckedIndex = 0;
			}

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Wochentage
		/// </summary>
		//----------------------------------------------------------------------------
		public int INTERVALL 
		{
			get 
			{
				return _Intervall;
			}
			set 
			{
				_Intervall = value;
				SetIntervall();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntervallEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.tbIntervall = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblintervall = new QS2.Desktop.ControlManagment.BaseLabel();
            this.osIntervall = new QS2.Desktop.ControlManagment.BaseOptionSet();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(30, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(126, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbIntervall
            // 
            this.tbIntervall.Location = new System.Drawing.Point(64, 16);
            this.tbIntervall.MaskInput = "nnnn";
            this.tbIntervall.MaxValue = 9999;
            this.tbIntervall.MinValue = 0;
            this.tbIntervall.Name = "tbIntervall";
            this.tbIntervall.Size = new System.Drawing.Size(48, 21);
            this.tbIntervall.TabIndex = 0;
            this.tbIntervall.Enter += new System.EventHandler(this.tbIntervall_Enter);
            // 
            // lblintervall
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblintervall.Appearance = appearance3;
            this.lblintervall.Location = new System.Drawing.Point(16, 16);
            this.lblintervall.Name = "lblintervall";
            this.lblintervall.Size = new System.Drawing.Size(56, 16);
            this.lblintervall.TabIndex = 6;
            this.lblintervall.Text = "Intervall";
            // 
            // osIntervall
            // 
            this.osIntervall.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "ValueListItem1";
            valueListItem1.DisplayText = "Tage";
            valueListItem2.DataValue = "ValueListItem2";
            valueListItem2.DisplayText = "Wochen";
            this.osIntervall.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.osIntervall.ItemSpacingVertical = 2;
            this.osIntervall.Location = new System.Drawing.Point(120, 8);
            this.osIntervall.Name = "osIntervall";
            this.osIntervall.Size = new System.Drawing.Size(64, 32);
            this.osIntervall.TabIndex = 1;
            // 
            // frmIntervallEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(182, 108);
            this.ControlBox = false;
            this.Controls.Add(this.tbIntervall);
            this.Controls.Add(this.lblintervall);
            this.Controls.Add(this.osIntervall);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmIntervallEdit";
            this.ShowInTaskbar = false;
            this.Text = "Intervall Auswahl";
            this.Load += new System.EventHandler(this.frmIntervallEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			switch(osIntervall.CheckedIndex)
			{
				case 0:
					_Intervall		= (int)tbIntervall.Value * 24;  // Tage
					break;
				case 1:	
					_Intervall		= (int)tbIntervall.Value * 168;	// Wochen
					break;
                case 2:
                    _Intervall      = (int)tbIntervall.Value * 721;	// Monate
                    break;
			}
		}

		private void frmIntervallEdit_Load(object sender, System.EventArgs e)
		{
		}

		private void tbIntervall_Enter(object sender, System.EventArgs e)
		{
			tbIntervall.SelectAll();
		}
	}
}
