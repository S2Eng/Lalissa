using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using System.IO;
using FormularGen;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public class frmFormularVerwaltung : QS2.Desktop.ControlManagment.baseForm 
	{

		private FormularManager					_manager = new FormularManager();
		private dsFormular.FormularDataTable	_dt = new dsFormular.FormularDataTable();

		private bool							_LoadInProgress = false;
        private bool _changed = false;
		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnSave;
		private QS2.Desktop.ControlManagment.BaseLabel lblComboFormular;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private FormularGen.ucFormular ucFormular1;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbBezeichnung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbGUI;
		private PMDS.GUI.BaseControls.FormularCombo cbFormular;
        private ucButton btnAdd;
        private ucButton btnDel;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbInNotfallAnzeigenJN;
		private System.ComponentModel.IContainer components;

		public frmFormularVerwaltung()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            if (DesignMode)
				return;
			
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

		private void RefreshCombo() 
		{
		}

		private void FormularNeu()
		{
			dlgOpen.InitialDirectory = ".\\";
			DialogResult res =  dlgOpen.ShowDialog();
			
			if(res != DialogResult.OK)
				return;

			string sFile = dlgOpen.FileName;
			string sFileOnly = Path.GetFileNameWithoutExtension(sFile);
			string sFileExt = Path.GetFileName(sFile);

			Formular f = new Formular();
			f.LoadFormular(sFile);
			//			ucFormular1.FORMULAR = f;
			//			ucFormular1.PAGEMODE = PageMode.Readonly;
			//		
			dsFormular.FormularRow r = _dt.NewFormularRow();
			r.ID			= Guid.NewGuid();
			r.Bezeichnung	= sFileOnly;
			r.Name			= sFileExt;
			r.BLOP			= f.SaveFormularToString(sFileExt);
			r.GUI			= true;
            r.InNotfallAnzeigenJN = false;
			_dt.AddFormularRow(r);
			_manager.Write(_dt);
			cbFormular.RefreshList(r.ID);
		}

		private void FormularLoeschen() 
		{
			DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEFORMULAR"), ENV.String("DIALOGTITLE_DELETEFORMULAR"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
			if(res != DialogResult.Yes)
				return;

			_manager.Delete((Guid)cbFormular.Value);
			cbFormular.RefreshList();
			RefreshFields();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormularVerwaltung));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.lblComboFormular = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.ucFormular1 = new FormularGen.ucFormular();
            this.tbBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbGUI = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.cbFormular = new PMDS.GUI.BaseControls.FormularCombo();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.cbInNotfallAnzeigenJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInNotfallAnzeigenJN)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComboFormular
            // 
            this.lblComboFormular.Location = new System.Drawing.Point(12, 12);
            this.lblComboFormular.Name = "lblComboFormular";
            this.lblComboFormular.Size = new System.Drawing.Size(296, 16);
            this.lblComboFormular.TabIndex = 29;
            this.lblComboFormular.Text = "Wählen Sie das zu bearbeitende Formular aus";
            // 
            // dlgOpen
            // 
            this.dlgOpen.CheckFileExists = false;
            this.dlgOpen.Filter = "Formulardateien|*.S2frm";
            // 
            // ucFormular1
            // 
            this.ucFormular1.ADDPICTURESALLOWED = false;
            this.ucFormular1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFormular1.BackColor = System.Drawing.Color.Transparent;
            this.ucFormular1.FORMULAR = null;
            this.ucFormular1.FORMULARSTYLE = FormularGen.FormularStyle.Tab;
            this.ucFormular1.Location = new System.Drawing.Point(12, 124);
            this.ucFormular1.Name = "ucFormular1";
            this.ucFormular1.PAGEMODE = FormularGen.PageMode.Readonly;
            this.ucFormular1.ReadOnly = true;
            this.ucFormular1.SELECTBOX = false;
            this.ucFormular1.Size = new System.Drawing.Size(614, 464);
            this.ucFormular1.TabIndex = 31;
            this.ucFormular1.ZOOM = 34;
            // 
            // tbBezeichnung
            // 
            this.tbBezeichnung.Location = new System.Drawing.Point(92, 60);
            this.tbBezeichnung.MaxLength = 50;
            this.tbBezeichnung.Name = "tbBezeichnung";
            this.tbBezeichnung.Size = new System.Drawing.Size(322, 21);
            this.tbBezeichnung.TabIndex = 32;
            this.tbBezeichnung.ValueChanged += new System.EventHandler(this.tbBezeichnung_ValueChanged);
            // 
            // lblBezeichnung
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance1;
            this.lblBezeichnung.Location = new System.Drawing.Point(12, 60);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(112, 21);
            this.lblBezeichnung.TabIndex = 33;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // cbGUI
            // 
            this.cbGUI.Location = new System.Drawing.Point(12, 98);
            this.cbGUI.Name = "cbGUI";
            this.cbGUI.Size = new System.Drawing.Size(183, 20);
            this.cbGUI.TabIndex = 34;
            this.cbGUI.Text = "Als Assessment anzeigen";
            this.cbGUI.CheckedChanged += new System.EventHandler(this.cbGUI_CheckedChanged);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance2;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(104, 594);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(91, 32);
            this.btnDel.TabIndex = 36;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.ucButton2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance3;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(12, 594);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 32);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // cbFormular
            // 
            this.cbFormular.DISPLAY_TEXT = "";
            this.cbFormular.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFormular.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbFormular.Location = new System.Drawing.Point(12, 28);
            this.cbFormular.Name = "cbFormular";
            this.cbFormular.Size = new System.Drawing.Size(402, 21);
            this.cbFormular.TabIndex = 30;
            this.cbFormular.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbFormular_BeforeDropDown);
            this.cbFormular.ValueChanged += new System.EventHandler(this.cbFormular_ValueChanged);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance4;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(501, 594);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 28;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance5;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(405, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 27;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbInNotfallAnzeigenJN
            // 
            this.cbInNotfallAnzeigenJN.Location = new System.Drawing.Point(231, 98);
            this.cbInNotfallAnzeigenJN.Name = "cbInNotfallAnzeigenJN";
            this.cbInNotfallAnzeigenJN.Size = new System.Drawing.Size(183, 20);
            this.cbInNotfallAnzeigenJN.TabIndex = 37;
            this.cbInNotfallAnzeigenJN.Text = "In Notfall anzeigen";
            this.cbInNotfallAnzeigenJN.CheckedChanged += new System.EventHandler(this.cbInNotfallAnzeigenJN_CheckedChanged);
            // 
            // frmFormularVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 633);
            this.Controls.Add(this.cbInNotfallAnzeigenJN);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbGUI);
            this.Controls.Add(this.tbBezeichnung);
            this.Controls.Add(this.lblBezeichnung);
            this.Controls.Add(this.ucFormular1);
            this.Controls.Add(this.cbFormular);
            this.Controls.Add(this.lblComboFormular);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(646, 669);
            this.Name = "frmFormularVerwaltung";
            this.ShowInTaskbar = false;
            this.Text = "Formularverwaltung";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmFormularVerwaltung_Closing);
            this.Load += new System.EventHandler(this.frmFormularVerwaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInNotfallAnzeigenJN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		private void RefreshFields() 
		{
			try 
			{
				_LoadInProgress = true;
				ResetSignalChange();
				_dt.Clear();
				tbBezeichnung.Clear();
				cbGUI.Checked = false;
				ucFormular1.FORMULAR = new Formular();
				if(cbFormular.Value == null)
					return;

				_dt = _manager.Read((Guid)cbFormular.Value);
				dsFormular.FormularRow r = _dt[0];
				tbBezeichnung.Text		= r.Bezeichnung;
				cbGUI.Checked			= r.GUI;
                cbInNotfallAnzeigenJN.Checked = r.InNotfallAnzeigenJN;
				Formular f = new Formular();
				f.LoadFromularFromString(r.BLOP);
				ucFormular1.FORMULAR = f;
				ucFormular1.PAGEMODE = PageMode.Readonly;
			}
			finally
			{
				_LoadInProgress = false;
			}
		}

		private void frmFormularVerwaltung_Load(object sender, System.EventArgs e)
		{
			RefreshCombo();
		}

		private void cbFormular_ValueChanged(object sender, System.EventArgs e)
		{
			RefreshFields();
		}

		private void ResetSignalChange() 
		{
			_changed = false;
			btnSave.Visible = false;
			btnUndo.Visible = false;
		}

		private void SignalChange() 
		{
			if(_LoadInProgress)
				return;
			_changed = true;
			btnSave.Visible = true;
			btnUndo.Visible = true;
		}

		private void tbBezeichnung_ValueChanged(object sender, System.EventArgs e)
		{
			SignalChange();
		}

		private void cbGUI_CheckedChanged(object sender, System.EventArgs e)
		{
			SignalChange();
		}

		private void ProcessSave() 
		{
			if(cbFormular.Value == null)
				return;

			_dt							= _manager.Read((Guid)cbFormular.Value);
			dsFormular.FormularRow r	= _dt[0];
			r.Bezeichnung				= tbBezeichnung.Text.Trim();
			r.GUI						= cbGUI.Checked;
            r.InNotfallAnzeigenJN       = cbInNotfallAnzeigenJN.Checked;
			_manager.Write(_dt);
			ResetSignalChange();

		}

		private void ProcessUndo() 
		{
			RefreshFields();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			ProcessSave();			
		}

		private void btnUndo_Click(object sender, System.EventArgs e)
		{
			ProcessUndo();
		}

		private DialogResult AskSaving()
		{
			DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true); 
            if (res == DialogResult.Yes)
			{
				ProcessSave();
			}
			
			return res;
		}

		private void frmFormularVerwaltung_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!_changed)
				return;

			DialogResult res = AskSaving();
			if(res == DialogResult.Cancel)
				e.Cancel = true;

		}

		private void cbFormular_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			if(_changed) 
			{
				DialogResult res = AskSaving();
				if(res == DialogResult.Cancel)
					e.Cancel = true;
			}
		}

        private void ucButton1_Click(object sender, EventArgs e)
        {
            FormularNeu();
        }

        private void ucButton2_Click(object sender, EventArgs e)
        {
            FormularLoeschen();
        }

        private void cbInNotfallAnzeigenJN_CheckedChanged(object sender, EventArgs e)
        {
            SignalChange();
        }


	}
}
