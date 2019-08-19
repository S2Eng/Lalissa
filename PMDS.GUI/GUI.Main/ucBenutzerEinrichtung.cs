using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;



namespace PMDS.GUI
{


	public class ucBenutzerEinrichtung : QS2.Desktop.ControlManagment.BaseControl
	{
		private Benutzer _benutzer;
        public event EventHandler ValueChanged;
        private bool _valueChangeEnabled = true;
        public bool isLoaded = false;


        private IContainer components;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBenutzerEinrichtungen;
        protected QS2.Desktop.ControlManagment.BaseGrid dgBenutzerEinrichtung;
        private dsBenutzerEinrichtung dsBenutzerEinrichtung1;
        private PMDS.DB.Patient.DBBenutzerEinrichtung dbBenutzerEinrichtung1;
        private ucButton btnAdd;
        private ucButton btnDel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
                


        public ucBenutzerEinrichtung()
		{
			InitializeComponent();
		}
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
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBenutzerEinrichtung));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BenutzerEinrichtung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEinrichtung", -1, 167056557, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Default");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(167056557);
            this.grpBenutzerEinrichtungen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.dgBenutzerEinrichtung = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dbBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung(this.components);
            this.grpBenutzerEinrichtungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBenutzerEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerEinrichtung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBenutzerEinrichtungen
            // 
            this.grpBenutzerEinrichtungen.Controls.Add(this.btnDel);
            this.grpBenutzerEinrichtungen.Controls.Add(this.btnAdd);
            this.grpBenutzerEinrichtungen.Controls.Add(this.dgBenutzerEinrichtung);
            this.grpBenutzerEinrichtungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBenutzerEinrichtungen.Location = new System.Drawing.Point(0, 0);
            this.grpBenutzerEinrichtungen.Name = "grpBenutzerEinrichtungen";
            this.grpBenutzerEinrichtungen.Size = new System.Drawing.Size(716, 476);
            this.grpBenutzerEinrichtungen.TabIndex = 1;
            this.grpBenutzerEinrichtungen.TabStop = false;
            this.grpBenutzerEinrichtungen.Text = "Benutzer-Einrichtungen";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance1;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(686, 10);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(22, 22);
            this.btnDel.TabIndex = 5;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(664, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 22);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgBenutzerEinrichtung
            // 
            this.dgBenutzerEinrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBenutzerEinrichtung.AutoWork = true;
            this.dgBenutzerEinrichtung.DataMember = "BenutzerEinrichtung";
            this.dgBenutzerEinrichtung.DataSource = this.dsBenutzerEinrichtung1;
            this.dgBenutzerEinrichtung.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgBenutzerEinrichtung.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(8, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Benutzer";
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(113, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Caption = "Einrichtung";
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(231, 0);
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "Standard";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(92, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgBenutzerEinrichtung.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgBenutzerEinrichtung.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgBenutzerEinrichtung.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.Color.White;
            this.dgBenutzerEinrichtung.DisplayLayout.GroupByBox.Appearance = appearance3;
            this.dgBenutzerEinrichtung.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.dgBenutzerEinrichtung.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.NullText = "";
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.White;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgBenutzerEinrichtung.DisplayLayout.Override.RowAppearance = appearance6;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.dgBenutzerEinrichtung.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Einrichtungen";
            this.dgBenutzerEinrichtung.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.dgBenutzerEinrichtung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgBenutzerEinrichtung.Location = new System.Drawing.Point(0, 42);
            this.dgBenutzerEinrichtung.Name = "dgBenutzerEinrichtung";
            this.dgBenutzerEinrichtung.Size = new System.Drawing.Size(716, 434);
            this.dgBenutzerEinrichtung.TabIndex = 1;
            this.dgBenutzerEinrichtung.Text = "Einrichtungen";
            this.dgBenutzerEinrichtung.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgBenutzerEinrichtung_AfterCellUpdate);
            this.dgBenutzerEinrichtung.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgBenutzerEinrichtung_CellChange);
            this.dgBenutzerEinrichtung.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgBenutzerEinrichtung_BeforeCellActivate);
            // 
            // dsBenutzerEinrichtung1
            // 
            this.dsBenutzerEinrichtung1.DataSetName = "dsBenutzerEinrichtung";
            this.dsBenutzerEinrichtung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBenutzerEinrichtung
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpBenutzerEinrichtungen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucBenutzerEinrichtung";
            this.Size = new System.Drawing.Size(716, 476);
            this.grpBenutzerEinrichtungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBenutzerEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerEinrichtung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
       


		private void InitControl()
		{
			try
			{
                if (this.isLoaded)
                    return;

                this.dbBenutzerEinrichtung1.initControl();
                //Benutzer = new Benutzer();
                this.loadEinrichtungen();

                this.isLoaded = true;
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}
        public void loadEinrichtungen()
        {
            this.dgBenutzerEinrichtung.DisplayLayout.ValueLists["Einrichtungen"].ValueListItems.Clear();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik dsKlinik1 = new dsKlinik();
            DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);
            foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
            {
                this.dgBenutzerEinrichtung.DisplayLayout.ValueLists["Einrichtungen"].ValueListItems.Add(rKlinik.ID, rKlinik.Bezeichnung.Trim());
            }
        }

        public Benutzer Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                if (value != null)
                {
                    _valueChangeEnabled = false;
                    _benutzer = value;
                    this.InitControl();
                    this.loadData();
                    _valueChangeEnabled = true;
                }

            }
        }


        public void loadData()
        {
            try
            {
                this.dsBenutzerEinrichtung1.Clear();
                this.dbBenutzerEinrichtung1.getBenutzerEinrichtung(Benutzer.ID,  this.dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
                this.dgBenutzerEinrichtung.Refresh();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public bool validateData()
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid in this.dgBenutzerEinrichtung.Rows)
                {
                    DataRowView v = (DataRowView)rowGrid.ListObject;
                    dsBenutzerEinrichtung.BenutzerEinrichtungRow rSelRowGrid = (dsBenutzerEinrichtung.BenutzerEinrichtungRow)v.Row;

                    rSelRowGrid.SetColumnError("IDEinrichtung", "");
                    if (rSelRowGrid.RowState != DataRowState.Deleted)
                    {
                        PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                        dsKlinik dsKlinik1 = new dsKlinik();
                        dsKlinik.KlinikRow rKlinikExists = DBKlinik1.loadKlinik(rSelRowGrid.IDEinrichtung, false);
                        if (rKlinikExists == null)
                        {
                            string txt = "Einrichtung: Auswahl erforderlich!";
                            rSelRowGrid.SetColumnError("IDEinrichtung", txt);
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Benutzer-Einrichtungen");
                            rowGrid.Selected = true;
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return false;
            }
        }
    
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                    return false;

                this.dbBenutzerEinrichtung1.daBenutzerEinrichtung.Update(this.dsBenutzerEinrichtung1.BenutzerEinrichtung);
                return true;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return false;
            }
        }

        public void addEinrichtung()
        {
            try
            {
                dsBenutzerEinrichtung.BenutzerEinrichtungRow rNew = this.dbBenutzerEinrichtung1.newRowBenutzerEinrichtung(this.dsBenutzerEinrichtung1);
                rNew.IDBenutzer = Benutzer.ID;
                if (this.dgBenutzerEinrichtung.DisplayLayout.ValueLists["Einrichtungen"].ValueListItems.Count > 0)
                {
                    rNew.IDEinrichtung = (System.Guid)this.dgBenutzerEinrichtung.DisplayLayout.ValueLists["Einrichtungen"].ValueListItems[0].DataValue;
                }
                else
                {
                    rNew.IDEinrichtung = System.Guid.NewGuid(); 
                }

                object sender = new object();
                OnValueChanged(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public void deleteEinrichtung()
        {
            try
            {
                dsBenutzerEinrichtung.BenutzerEinrichtungRow rSelectedRow = this.getSelectedRow(true);
                if (rSelectedRow != null)
                {
                    rSelectedRow.Delete();
                    this.dgBenutzerEinrichtung.Refresh();
                    object sender = new object();
                    OnValueChanged(sender, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public dsBenutzerEinrichtung.BenutzerEinrichtungRow getSelectedRow(bool msgBox)
        {
            try
            {
                if (this.dgBenutzerEinrichtung.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.dgBenutzerEinrichtung.ActiveRow.ListObject;
                    dsBenutzerEinrichtung.BenutzerEinrichtungRow rSelBenEinricht = (dsBenutzerEinrichtung.BenutzerEinrichtungRow)v.Row;
                    return rSelBenEinricht;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Einrichtung ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addEinrichtung();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.deleteEinrichtung();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgBenutzerEinrichtung_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
        }
        private void dgBenutzerEinrichtung_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Row.IsGroupByRow || e.Cell.IsFilterRowCell)
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                else
                {
                    if (e.Cell.Column.ToString() == "xy")
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void dgBenutzerEinrichtung_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                OnValueChanged(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

	}
}
