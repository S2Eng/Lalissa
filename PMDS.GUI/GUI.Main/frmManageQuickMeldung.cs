using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Win;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{



	public class frmManageQuickMeldung : QS2.Desktop.ControlManagment.baseForm 
	{

		private QuickMeldungManager _manager = new QuickMeldungManager();

        private dsQuickMeldung.QuickMeldungDataTable _dt = null;
		private QS2.Desktop.ControlManagment.BaseLableWin label1;
		private QS2.Desktop.ControlManagment.BasePanel panel1;
		private PMDS.GUI.BaseControls.QuickMeldungCombo cbQuickMeldung;
		private PMDS.GUI.BaseControls.ASZMCombo cbM;
        private ucButton ucButton2;
        private ucButton ucButton1;
        private ucButton btnUmbennen;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboEinrichtung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboAbteilung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private IContainer components;

        




		public frmManageQuickMeldung()
		{
			InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            cbM.RefreshList();
			if(cbM.Items.Count > 0)
				cbM.SelectedIndex = 0;

            this.loadEinrichtungen();
        }

        public void loadEinrichtungen()
        {
            try
            {
                this.cboEinrichtung.Items.Clear();
                this.cboAbteilung.Items.Clear();
                //this.cbM.Items.Clear();

                dsKlinik dsKlinik1 = new dsKlinik();
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);
                foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
                {
                    ValueListItem itmKlinik = this.cboEinrichtung.Items.Add(rKlinik.ID, rKlinik.Bezeichnung.Trim());
                }
            }

            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void loadAbteilung(System.Guid IDKlinik)
        {
            try
            {
                this.cboAbteilung.Items.Clear();
                this.cbQuickMeldung.Items.Clear();
                //this.cbM.Items.Clear();

                dsAbteilung dsAbteilung1 = new dsAbteilung();
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    ValueListItem itmAbt = this.cboAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung.Trim());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadAbteilung: " + ex.ToString());
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageQuickMeldung));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbM = new PMDS.GUI.BaseControls.ASZMCombo();
            this.cbQuickMeldung = new PMDS.GUI.BaseControls.QuickMeldungCombo();
            this.ucButton2 = new PMDS.GUI.ucButton(this.components);
            this.ucButton1 = new PMDS.GUI.ucButton(this.components);
            this.btnUmbennen = new PMDS.GUI.ucButton(this.components);
            this.cboEinrichtung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboAbteilung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuickMeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Quickmeldung";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbM);
            this.panel1.Location = new System.Drawing.Point(12, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 247);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // cbM
            // 
            this.cbM.DISPLAY_TEXT = "Maßnahme";
            this.cbM.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbM.GROUP = PMDS.Global.EintragGruppe.M;
            this.cbM.Location = new System.Drawing.Point(8, 16);
            this.cbM.Name = "cbM";
            this.cbM.Size = new System.Drawing.Size(384, 21);
            this.cbM.TabIndex = 0;
            // 
            // cbQuickMeldung
            // 
            this.cbQuickMeldung.DISPLAY_TEXT = "";
            this.cbQuickMeldung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbQuickMeldung.Enabled = false;
            this.cbQuickMeldung.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbQuickMeldung.Location = new System.Drawing.Point(12, 112);
            this.cbQuickMeldung.Name = "cbQuickMeldung";
            this.cbQuickMeldung.Size = new System.Drawing.Size(400, 21);
            this.cbQuickMeldung.TabIndex = 12;
            this.cbQuickMeldung.ValueChanged += new System.EventHandler(this.cbQuickMeldung_ValueChanged);
            // 
            // ucButton2
            // 
            this.ucButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ucButton2.Appearance = appearance3;
            this.ucButton2.AutoWorkLayout = false;
            this.ucButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucButton2.DoOnClick = true;
            this.ucButton2.ImageSize = new System.Drawing.Size(12, 12);
            this.ucButton2.IsStandardControl = true;
            this.ucButton2.Location = new System.Drawing.Point(103, 401);
            this.ucButton2.Name = "ucButton2";
            this.ucButton2.Size = new System.Drawing.Size(91, 32);
            this.ucButton2.TabIndex = 40;
            this.ucButton2.TabStop = false;
            this.ucButton2.Text = "Entfernen";
            this.ucButton2.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.ucButton2.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.ucButton2.Click += new System.EventHandler(this.ucButton2_Click);
            // 
            // ucButton1
            // 
            this.ucButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ucButton1.Appearance = appearance4;
            this.ucButton1.AutoWorkLayout = false;
            this.ucButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucButton1.DoOnClick = true;
            this.ucButton1.ImageSize = new System.Drawing.Size(12, 12);
            this.ucButton1.IsStandardControl = true;
            this.ucButton1.Location = new System.Drawing.Point(11, 401);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(91, 32);
            this.ucButton1.TabIndex = 39;
            this.ucButton1.TabStop = false;
            this.ucButton1.Text = "Hinzufügen";
            this.ucButton1.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.ucButton1.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // btnUmbennen
            // 
            this.btnUmbennen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUmbennen.Appearance = appearance1;
            this.btnUmbennen.AutoWorkLayout = false;
            this.btnUmbennen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUmbennen.DoOnClick = true;
            this.btnUmbennen.IsStandardControl = true;
            this.btnUmbennen.Location = new System.Drawing.Point(195, 401);
            this.btnUmbennen.Name = "btnUmbennen";
            this.btnUmbennen.Size = new System.Drawing.Size(101, 32);
            this.btnUmbennen.TabIndex = 37;
            this.btnUmbennen.TabStop = false;
            this.btnUmbennen.Text = "Speichern";
            this.btnUmbennen.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnUmbennen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUmbennen.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboEinrichtung
            // 
            this.cboEinrichtung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboEinrichtung.Location = new System.Drawing.Point(12, 27);
            this.cboEinrichtung.Name = "cboEinrichtung";
            this.cboEinrichtung.Size = new System.Drawing.Size(237, 21);
            this.cboEinrichtung.TabIndex = 170;
            this.cboEinrichtung.ValueChanged += new System.EventHandler(this.cboEinrichtung_ValueChanged);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(12, 11);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(61, 14);
            this.ultraLabel4.TabIndex = 171;
            this.ultraLabel4.Text = "Einrichtung";
            // 
            // cboAbteilung
            // 
            this.cboAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboAbteilung.Location = new System.Drawing.Point(12, 70);
            this.cboAbteilung.Name = "cboAbteilung";
            this.cboAbteilung.Size = new System.Drawing.Size(237, 21);
            this.cboAbteilung.TabIndex = 172;
            this.cboAbteilung.ValueChanged += new System.EventHandler(this.cboAbteilung_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 53);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(52, 14);
            this.ultraLabel1.TabIndex = 173;
            this.ultraLabel1.Text = "Abteilung";
            // 
            // frmManageQuickMeldung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(425, 438);
            this.Controls.Add(this.cboAbteilung);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.cboEinrichtung);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ucButton2);
            this.Controls.Add(this.ucButton1);
            this.Controls.Add(this.btnUmbennen);
            this.Controls.Add(this.cbQuickMeldung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageQuickMeldung";
            this.ShowInTaskbar = false;
            this.Text = "Quickmeldung Verwaltung";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmManageQuickFilter_Closing);
            this.Load += new System.EventHandler(this.frmManageQuickFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuickMeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmManageQuickFilter_Load(object sender, System.EventArgs e)
		{
			ShowHideMenu();
		}

		private void ProcessSave() 
		{
			if(_dt == null)
				return;

			FieldsToRow(ROW);
			_manager.Write(_dt);
		}

		private void ProcessVerlassen()
		{
			ProcessSave();
			this.Close();
		}

		private dsQuickMeldung.QuickMeldungRow ROW 
		{
			get 
			{
				return _dt[0];
			}
		}

		private void ProcessAdd() 
		{
			RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
			frm.Text	= ENV.String("DIALOGTITLE_NEWQUICKMELDUNG");
			DialogResult res =  frm.ShowDialog();
			if(res != DialogResult.OK || frm.TEXT.Length < 1)
				return;

			Guid ID = _manager.AddNew(frm.TEXT, (Guid)cboAbteilung.SelectedItem.DataValue);
			_dt = _manager.Read(ID);
			RowToFields(ROW);
			RefreshList(ID);
		}

		private void RowToFields(dsQuickMeldung.QuickMeldungRow r)
		{
			if(!r.IsIDEintragNull())
				cbM.ID = r.IDEintrag;
		}

		private void FieldsToRow(dsQuickMeldung.QuickMeldungRow r)
		{
			r.IDEintrag = (Guid)cbM.Value;			
		}

		private void RefreshList()
		{
			RefreshList(Guid.Empty);
			
		}

		private void RefreshList(Guid id) 
		{
			if(id == Guid.Empty)
				cbQuickMeldung.RefreshList((Guid)this.cboAbteilung.SelectedItem.DataValue);
			else
				cbQuickMeldung.RefreshList(id, (Guid)this.cboAbteilung.SelectedItem.DataValue);

			ShowHidePanel();
			ShowHideMenu();
		}

		private void ShowHidePanel() 
		{
			if(cbQuickMeldung.Value == null) 
				panel1.Visible = false;
			else 
				panel1.Visible = true;	
		}

		private void ProcessDel() 
		{
			if(_dt == null)
				return;
			ROW.Delete();
			_manager.Write(_dt);
			_dt = null;

			RefreshList();	
		}

		private void ProcessRename() 
		{
			if(_dt == null)
				return;

            RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
			frm.TEXT = ROW.Bezeichnung;
			DialogResult res =  frm.ShowDialog();
			if(res != DialogResult.OK)
				return;

			ROW.Bezeichnung = frm.TEXT;
			_manager.Write(_dt);
			RefreshList(ROW.ID);
		}

		private void ShowHideMenu()
		{
			bool  bEnable = _dt == null ? false : true;
            this.ucButton1.Enabled = bEnable;
            this.ucButton2.Enabled = bEnable;
            this.btnUmbennen .Enabled = bEnable;

            if (this.cboAbteilung.Value == null)
            {
                this.ucButton1.Enabled = false;
                this.ucButton2.Enabled = false;
                this.btnUmbennen.Enabled = false;
            }
            else
            {
                if (cbQuickMeldung.Value == null)
                {
                    this.ucButton1.Enabled = true;
                    this.ucButton2.Enabled = false;
                    this.btnUmbennen.Enabled = false;
                }
                else
                {
                    this.ucButton1.Enabled = true;
                    this.ucButton2.Enabled = true;
                    this.btnUmbennen.Enabled = true;
                }
            }

		}    
           
		private void ClearFields()
		{

		}

		private void cbQuickMeldung_ValueChanged(object sender, System.EventArgs e)
		{
			ProcessSave();
			ClearFields();
			if(cbQuickMeldung.Value != null)
			{
				_dt = _manager.Read((Guid)cbQuickMeldung.Value);
				RowToFields(ROW);
			}
			ShowHidePanel();
			ShowHideMenu();			
		}

		private void frmManageQuickFilter_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ProcessSave();
		}


        private void ucButton1_Click(object sender, EventArgs e)
        {
            ProcessAdd();
        }

        private void ucButton2_Click(object sender, EventArgs e)
        {
            ProcessDel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessRename();
        }

        private void cboEinrichtung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEinrichtung.Focused)
                {
                    if (this.cboEinrichtung.SelectedItem != null)
                    {
                        this.loadAbteilung((System.Guid)this.cboEinrichtung.SelectedItem.DataValue);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cboAbteilung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbQuickMeldung.Enabled = true;
                ProcessSave();
                RefreshList();		 

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
