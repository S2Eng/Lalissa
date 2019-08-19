using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using Infragistics.Win;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;



namespace PMDS.GUI
{


	public class frmManageDienstZeiten : QS2.Desktop.ControlManagment.baseForm 
	{

		private DienstZeitenManager _manager = new DienstZeitenManager();

        private dsDienstZeiten.DienstzeitenDataTable _dt = null;
		private QS2.Desktop.ControlManagment.BaseLableWin label1;
		private QS2.Desktop.ControlManagment.BasePanel panel1;
		private PMDS.GUI.BaseControls.DienstZeitenCombo cbDienstZeiten;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpFrom;
		private QS2.Desktop.ControlManagment.BaseLableWin lblVorher;
		private QS2.Desktop.ControlManagment.BaseLableWin label2;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpTo;
        private ucButton btnDelete;
        private ucButton btnAdd;
        private ucButton btnUmbennen;
        private QS2.Desktop.ControlManagment.BaseLableWin label4;
        private QS2.Desktop.ControlManagment.BaseMaskEdit tbReihenfolge;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboEinrichtung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboAbteilung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboVerwendenIn;
        private QS2.Desktop.ControlManagment.BaseLableWin lblVerwendenIn;
        private IContainer components;





		public frmManageDienstZeiten()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
                this.loadEinrichtungen();
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
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDienstZeiten));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.cboVerwendenIn = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblVerwendenIn = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbReihenfolge = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.label4 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.label2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dtpTo = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblVorher = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dtpFrom = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cboEinrichtung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboAbteilung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnUmbennen = new PMDS.GUI.ucButton(this.components);
            this.cbDienstZeiten = new PMDS.GUI.BaseControls.DienstZeitenCombo();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerwendenIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDienstZeiten)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dienstzeiten";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboVerwendenIn);
            this.panel1.Controls.Add(this.lblVerwendenIn);
            this.panel1.Controls.Add(this.tbReihenfolge);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.lblVorher);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Location = new System.Drawing.Point(14, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 240);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // cboVerwendenIn
            // 
            this.cboVerwendenIn.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = "IM";
            valueListItem5.DisplayText = "Interventionen und Medikamente";
            valueListItem2.DataValue = "I";
            valueListItem2.DisplayText = "Interventionen";
            valueListItem1.DataValue = "M";
            valueListItem1.DisplayText = "Medikamente";
            valueListItem4.DataValue = " ";
            valueListItem4.DisplayText = "Immer anzeigen";
            valueListItem3.DataValue = "NA";
            valueListItem3.DisplayText = "Nie anzeigen";
            this.cboVerwendenIn.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem2,
            valueListItem1,
            valueListItem4,
            valueListItem3});
            this.cboVerwendenIn.Location = new System.Drawing.Point(92, 70);
            this.cboVerwendenIn.Name = "cboVerwendenIn";
            this.cboVerwendenIn.Size = new System.Drawing.Size(303, 21);
            this.cboVerwendenIn.TabIndex = 18;
            // 
            // lblVerwendenIn
            // 
            this.lblVerwendenIn.Location = new System.Drawing.Point(16, 72);
            this.lblVerwendenIn.Name = "lblVerwendenIn";
            this.lblVerwendenIn.Size = new System.Drawing.Size(138, 16);
            this.lblVerwendenIn.TabIndex = 19;
            this.lblVerwendenIn.Text = "Verwenden in";
            // 
            // tbReihenfolge
            // 
            this.tbReihenfolge.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.tbReihenfolge.Location = new System.Drawing.Point(325, 17);
            this.tbReihenfolge.Name = "tbReihenfolge";
            this.tbReihenfolge.NonAutoSizeHeight = 20;
            this.tbReihenfolge.Size = new System.Drawing.Size(70, 20);
            this.tbReihenfolge.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(191, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anzeigeposition von oben: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "bis";
            // 
            // dtpTo
            // 
            this.dtpTo.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.dtpTo.FormatString = "HH:mm ";
            this.dtpTo.Location = new System.Drawing.Point(92, 43);
            this.dtpTo.MaskInput = "hh:mm";
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ownFormat = "";
            this.dtpTo.ownMaskInput = "";
            this.dtpTo.Size = new System.Drawing.Size(60, 21);
            this.dtpTo.TabIndex = 6;
            // 
            // lblVorher
            // 
            this.lblVorher.Location = new System.Drawing.Point(16, 21);
            this.lblVorher.Name = "lblVorher";
            this.lblVorher.Size = new System.Drawing.Size(48, 16);
            this.lblVorher.TabIndex = 5;
            this.lblVorher.Text = "von";
            // 
            // dtpFrom
            // 
            this.dtpFrom.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.dtpFrom.FormatString = "HH:mm ";
            this.dtpFrom.Location = new System.Drawing.Point(92, 17);
            this.dtpFrom.MaskInput = "hh:mm";
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ownFormat = "";
            this.dtpFrom.ownMaskInput = "";
            this.dtpFrom.Size = new System.Drawing.Size(60, 21);
            this.dtpFrom.TabIndex = 0;
            // 
            // cboEinrichtung
            // 
            this.cboEinrichtung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboEinrichtung.Location = new System.Drawing.Point(14, 26);
            this.cboEinrichtung.Name = "cboEinrichtung";
            this.cboEinrichtung.Size = new System.Drawing.Size(237, 21);
            this.cboEinrichtung.TabIndex = 172;
            this.cboEinrichtung.ValueChanged += new System.EventHandler(this.cboEinrichtung_ValueChanged);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(14, 10);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(61, 14);
            this.ultraLabel4.TabIndex = 173;
            this.ultraLabel4.Text = "Einrichtung";
            // 
            // cboAbteilung
            // 
            this.cboAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboAbteilung.Location = new System.Drawing.Point(14, 69);
            this.cboAbteilung.Name = "cboAbteilung";
            this.cboAbteilung.Size = new System.Drawing.Size(237, 21);
            this.cboAbteilung.TabIndex = 174;
            this.cboAbteilung.ValueChanged += new System.EventHandler(this.cboAbteilung_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 52);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(52, 14);
            this.ultraLabel1.TabIndex = 175;
            this.ultraLabel1.Text = "Abteilung";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance1;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(106, 397);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 32);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Entfernen";
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(14, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 32);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUmbennen
            // 
            this.btnUmbennen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUmbennen.Appearance = appearance3;
            this.btnUmbennen.AutoWorkLayout = false;
            this.btnUmbennen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUmbennen.DoOnClick = true;
            this.btnUmbennen.IsStandardControl = true;
            this.btnUmbennen.Location = new System.Drawing.Point(197, 397);
            this.btnUmbennen.Name = "btnUmbennen";
            this.btnUmbennen.Size = new System.Drawing.Size(96, 32);
            this.btnUmbennen.TabIndex = 37;
            this.btnUmbennen.TabStop = false;
            this.btnUmbennen.Text = "Speichern";
            this.btnUmbennen.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnUmbennen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUmbennen.Click += new System.EventHandler(this.btnUmbennen_Click);
            // 
            // cbDienstZeiten
            // 
            this.cbDienstZeiten.DISPLAY_TEXT = "";
            this.cbDienstZeiten.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbDienstZeiten.Enabled = false;
            this.cbDienstZeiten.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbDienstZeiten.Location = new System.Drawing.Point(14, 109);
            this.cbDienstZeiten.Name = "cbDienstZeiten";
            this.cbDienstZeiten.Size = new System.Drawing.Size(400, 21);
            this.cbDienstZeiten.TabIndex = 16;
            this.cbDienstZeiten.ValueChanged += new System.EventHandler(this.cbDienstZeiten_ValueChanged);
            // 
            // frmManageDienstZeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(430, 436);
            this.Controls.Add(this.cboAbteilung);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.cboEinrichtung);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUmbennen);
            this.Controls.Add(this.cbDienstZeiten);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManageDienstZeiten";
            this.Text = "Dienstzeiten Verwaltung";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmManageQuickFilter_Closing);
            this.Load += new System.EventHandler(this.frmManageQuickFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerwendenIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDienstZeiten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmManageQuickFilter_Load(object sender, System.EventArgs e)
		{
			ShowHideMenu();

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
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

		private dsDienstZeiten.DienstzeitenRow ROW 
		{
			get 
			{
				return _dt[0];
			}
		}

		private void ProcessAdd() 
		{
			RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
			frm.Text	= ENV.String("DIALOGTITLE_NEWDIENSTZEITEN");
			DialogResult res =  frm.ShowDialog();
			if(res != DialogResult.OK || frm.TEXT.Length < 1)
				return;

			Guid ID = _manager.AddNew(frm.TEXT, (Guid)this.cboAbteilung.Value);
			_dt = _manager.Read(ID);
			RowToFields(ROW);
			RefreshList(ID);
		}

		private void RowToFields(dsDienstZeiten.DienstzeitenRow r)
		{
			dtpFrom.Value	= r.Von;
			dtpTo.Value		= r.Bis;
            tbReihenfolge.Value = r.Reihenfolge;
            this.cboVerwendenIn.Value = r.VerwendenIn;

        }

		private void FieldsToRow(dsDienstZeiten.DienstzeitenRow r)
		{
			r.Von	= dtpFrom.DateTime;
			r.Bis	= dtpTo.DateTime;
            r.Reihenfolge = (int)tbReihenfolge.Value;

            if (this.cboVerwendenIn.Value == null)
            {
                r.VerwendenIn = "";
            }
            else
            {
                r.VerwendenIn = this.cboVerwendenIn.Value.ToString();
            }
       
		}

		private void RefreshList()
		{
			RefreshList(Guid.Empty);
			
		}

		private void RefreshList(Guid id) 
		{
			if(id == Guid.Empty)
				cbDienstZeiten.RefreshList((Guid)this.cboAbteilung.Value, true, false);
			else
				cbDienstZeiten.RefreshList(id, (Guid)this.cboAbteilung.Value, true, false);

			ShowHidePanel();
			ShowHideMenu();
		}

		private void ShowHidePanel() 
		{
			if(cbDienstZeiten.Value == null) 
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
			bool bEnable = _dt == null ? false  : true;
			this.btnAdd.Enabled = bEnable;
            this.btnDelete .Enabled = bEnable;
            this.btnUmbennen .Enabled = bEnable;

            if (this.cboAbteilung.Value == null)
            {
                this.btnAdd.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnUmbennen.Enabled = false;
            }

            else
                if (cbDienstZeiten.Value == null)
                {
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnUmbennen.Enabled = false;
                }
                else
                {
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnUmbennen.Enabled = true;
                }

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
                this.cbDienstZeiten.Items.Clear();
                //this.cbM.Items.Clear();
                panel1.Visible = false;

                Global.db.Patient.dsAbteilung dsAbteilung1 = new Global.db.Patient.dsAbteilung();
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                foreach (Global.db.Patient.dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    ValueListItem itmAbt = this.cboAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung.Trim());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadAbteilung: " + ex.ToString());
            }
        }

        private void ClearFields()
		{
		}

		private void cbDienstZeiten_ValueChanged(object sender, System.EventArgs e)
		{
			ProcessSave();
			ClearFields();
			if(cbDienstZeiten.Value != null)
			{
				_dt = _manager.Read((Guid)cbDienstZeiten.Value);
				RowToFields(ROW);
			}
			ShowHidePanel();
			ShowHideMenu();			
		}

		private void frmManageQuickFilter_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ProcessSave();
		}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcessSave(); 
            ProcessAdd();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProcessDel();
        }

        private void btnUmbennen_Click(object sender, EventArgs e)
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
                if (this.cboAbteilung.Focused)
                {
                    cbDienstZeiten.Enabled = true;
                    ProcessSave();
                    RefreshList();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
