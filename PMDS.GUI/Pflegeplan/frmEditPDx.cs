using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;


namespace PMDS.GUI
{

    
	public class frmEditPDx : QS2.Desktop.ControlManagment.baseForm 
	{
		private bool										_bCanclose = false;
		private bool										_bModeNew = false;		// Flag ob neue oder alte PDx 
		private PDXDef										_PDXDef;
        private bool _bCancel = false;		// signalisiert das Cancel ausgeführt wurde
        private QS2.Desktop.ControlManagment.BaseLableWin lblKlartext;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDefinition;
		private QS2.Desktop.ControlManagment.BaseLableWin lblPDxCode;
		private QS2.Desktop.ControlManagment.BaseLableWin lblThemGlied;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLableWin lblGruppe;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbGruppe;
        private QS2.Desktop.ControlManagment.BaseOptionSet osLokalisierung;
        private QS2.Desktop.ControlManagment.BaseLableWin lblLokalisierung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbDefinition;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbCode;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkEntferntJN;
        private System.ComponentModel.IContainer components;




		public frmEditPDx(bool bNewPDx, ref PDXDef def)
		{
			_bModeNew	= bNewPDx;
			_PDXDef		= def;
            
			InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            InitGruppeCombo();

            cbGruppe.SelectedIndex = 0;     // default Pflegediagnose

			if(bNewPDx == false) 
			{
				tbText.Text			            = def.Klartext;
				tbDefinition.Text	            = def.Definition;
				tbCode.Text			            = def.Code;
                cbGruppe.SelectedIndex          = (int)def.PDXGruppe;
                osLokalisierung.CheckedIndex    = (int)def.PDXLokalisierungsTyp;
                chkEntferntJN.Checked = def.EntferntJN;
			}
			
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary> 
        //----------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPDx));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            this.lblKlartext = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblDefinition = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblPDxCode = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblThemGlied = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.lblGruppe = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.cbGruppe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.osLokalisierung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblLokalisierung = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbDefinition = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbCode = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkEntferntJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKlartext
            // 
            this.lblKlartext.Location = new System.Drawing.Point(16, 26);
            this.lblKlartext.Name = "lblKlartext";
            this.lblKlartext.Size = new System.Drawing.Size(96, 24);
            this.lblKlartext.TabIndex = 6;
            this.lblKlartext.Text = "Klartext";
            this.lblKlartext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefinition
            // 
            this.lblDefinition.Location = new System.Drawing.Point(16, 55);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(96, 16);
            this.lblDefinition.TabIndex = 8;
            this.lblDefinition.Text = "Definition";
            this.lblDefinition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPDxCode
            // 
            this.lblPDxCode.Location = new System.Drawing.Point(16, 184);
            this.lblPDxCode.Name = "lblPDxCode";
            this.lblPDxCode.Size = new System.Drawing.Size(96, 16);
            this.lblPDxCode.TabIndex = 10;
            this.lblPDxCode.Text = "PDx Code";
            this.lblPDxCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThemGlied
            // 
            this.lblThemGlied.Location = new System.Drawing.Point(16, 208);
            this.lblThemGlied.Name = "lblThemGlied";
            this.lblThemGlied.Size = new System.Drawing.Size(96, 16);
            this.lblThemGlied.TabIndex = 51;
            this.lblThemGlied.Text = "Them.Glied. ID";
            this.lblThemGlied.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.btnCancel.Location = new System.Drawing.Point(462, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(462, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 24);
            this.btnOK.TabIndex = 6;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "Speichern";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblGruppe
            // 
            this.lblGruppe.Location = new System.Drawing.Point(16, 234);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(96, 16);
            this.lblGruppe.TabIndex = 56;
            this.lblGruppe.Text = "Gruppe";
            this.lblGruppe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbGruppe
            // 
            this.cbGruppe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbGruppe.Location = new System.Drawing.Point(118, 233);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(144, 21);
            this.cbGruppe.TabIndex = 4;
            // 
            // osLokalisierung
            // 
            this.osLokalisierung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osLokalisierung.CheckedIndex = 0;
            valueListItem4.DataValue = "Default Item";
            valueListItem4.DisplayText = "kann lokalisiert werden";
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "muß lokalisiert werden";
            valueListItem6.DataValue = "ValueListItem2";
            valueListItem6.DisplayText = "keine Lokalisierung möglich";
            this.osLokalisierung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.osLokalisierung.ItemSpacingVertical = 3;
            this.osLokalisierung.Location = new System.Drawing.Point(118, 264);
            this.osLokalisierung.Name = "osLokalisierung";
            this.osLokalisierung.Size = new System.Drawing.Size(245, 65);
            this.osLokalisierung.TabIndex = 5;
            this.osLokalisierung.Text = "kann lokalisiert werden";
            this.osLokalisierung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblLokalisierung
            // 
            this.lblLokalisierung.Location = new System.Drawing.Point(16, 263);
            this.lblLokalisierung.Name = "lblLokalisierung";
            this.lblLokalisierung.Size = new System.Drawing.Size(96, 16);
            this.lblLokalisierung.TabIndex = 58;
            this.lblLokalisierung.Text = "Lokalisierung";
            this.lblLokalisierung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(118, 29);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(432, 19);
            this.tbText.TabIndex = 8;
            this.tbText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(118, 56);
            this.tbDefinition.MaxLength = 2048;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(432, 122);
            this.tbDefinition.TabIndex = 1;
            this.tbDefinition.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(118, 184);
            this.tbCode.MaxLength = 255;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(146, 19);
            this.tbCode.TabIndex = 2;
            this.tbCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tbCode.Leave += new System.EventHandler(this.tbCode_Leave);
            // 
            // chkEntferntJN
            // 
            this.chkEntferntJN.Location = new System.Drawing.Point(291, 182);
            this.chkEntferntJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkEntferntJN.Name = "chkEntferntJN";
            this.chkEntferntJN.Size = new System.Drawing.Size(259, 25);
            this.chkEntferntJN.TabIndex = 59;
            this.chkEntferntJN.Text = "Entfernt (Nicht aktiv)";
            // 
            // frmEditPDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(568, 341);
            this.Controls.Add(this.chkEntferntJN);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblLokalisierung);
            this.Controls.Add(this.osLokalisierung);
            this.Controls.Add(this.cbGruppe);
            this.Controls.Add(this.lblGruppe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblThemGlied);
            this.Controls.Add(this.lblPDxCode);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblKlartext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPDx";
            this.ShowInTaskbar = false;
            this.Text = "PDx bearbeiten";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEditPDx_Closing);
            this.Load += new System.EventHandler(this.frmEditPDx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// OK - prüfen der Randbedingungen
		/// </summary> 
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_bCanclose = true;

			if(tbText.Text.Length == 0)  
			{
				errorProvider1.SetError(tbText, ENV.String("ERROR_BEZEICHNUNG"));
				_bCanclose = false;
			}
			else
				errorProvider1.SetError(tbText, "");

			if(tbDefinition.Text.Length == 0)
			{
				errorProvider1.SetError(tbDefinition, ENV.String("ERROR_PDXDEF"));
				_bCanclose = false;
			}
			else
				errorProvider1.SetError(tbDefinition, "");

			if(tbCode.Text.Length == 0)
			{
				errorProvider1.SetError(tbCode, ENV.String("ERROR_PDXCODE"));
				_bCanclose = false;
			}
			else
				errorProvider1.SetError(tbCode, "");

			if(CheckPDxCode() == true)
				_bCanclose = false;
			
			if(_bCanclose == false)
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);


		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Cancel
		/// </summary> 
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_bCanclose	= true;
			_bCancel	= true;
            this.Close();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Prüft ob der PDx Code (Neuanlage bereits in der DB vorhanden ist
		/// und setzt den Errorprovider
		/// liefert true wenn ODx schon in DB vorhanden ist
		/// </summary> 
		//----------------------------------------------------------------------------
		private bool CheckPDxCode() 
		{
			if(!_bModeNew)			// nur bei Neuanlage prüfen
				return false;
            bool bRet = PMDS.DB.DBUtil.PDXCodeExists(tbCode.Text);
			if(bRet) 
			{
				errorProvider1.SetError(tbCode, ENV.String("ERROR_PDX_CODE_EXISTS"));
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_PDX_CODE_EXISTS"), true);
			}	
			return bRet;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Prüfen ob Code schon in der DB vorhanden ist
		/// </summary> 
		//----------------------------------------------------------------------------
		private void tbCode_Leave(object sender, System.EventArgs e)
		{
			errorProvider1.SetError(tbCode, "");			// vorher löschen
			CheckPDxCode();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Verhindern das ungerechtfertigt geschlossen wird
		/// </summary> 
		//----------------------------------------------------------------------------
		private void frmEditPDx_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
			if(_bCanclose && !_bCancel) 
			{
				_PDXDef.Code			        = tbCode.Text;
				_PDXDef.Definition		        = tbDefinition.Text;
				_PDXDef.Klartext		        = tbText.Text;
                _PDXDef.PDXGruppe               = (PDXGruppe)cbGruppe.SelectedIndex;
                _PDXDef.PDXLokalisierungsTyp    = (PDxLokalisierungsTypen)osLokalisierung.CheckedIndex;
                _PDXDef.EntferntJN              = chkEntferntJN.Checked;
			}
		}

        private void frmEditPDx_Load(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Gruppenzugehörigkeitscombo intialisieren
        /// </summary> 
        //----------------------------------------------------------------------------
        private void InitGruppeCombo()
        {
            foreach (string s in Enum.GetNames(typeof(PDXGruppe)))
            {
                cbGruppe.Items.Add(s, s);
            }
        }
	}
}
