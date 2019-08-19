using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Data.Patient;

using PMDS.BusinessLogic;
using PMDS.Global;

using Infragistics.Win.UltraWinEditors;




namespace PMDS.GUI
{

    
	public class ucPatientHistorie : QS2.Desktop.ControlManagment.BaseControl
	{

		private Patient	_patient;
        private PMDS.BusinessLogic.Aufenthalt dbAuf = new PMDS.BusinessLogic.Aufenthalt();



        private PMDS.GUI.ucAufEntInfo ucAufEntInfo1;
        private PMDS.Data.Patient.dsAufenthalt dsAufenthalt1;
        private QS2.Desktop.ControlManagment.BaseGrid dgHistorie;
        private IContainer components;
        private Infragistics.Win.Misc.UltraPanel panelButt;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        public QS2.Desktop.ControlManagment.BaseButton btnundo2;
        public QS2.Desktop.ControlManagment.BaseButton btnSave2;
        public QS2.Desktop.ControlManagment.BaseButton btnCopyDekurse;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

        public PMDS.db.Entities.Aufenthalt rQuellAufenthalt;
        public PMDS.db.Entities.Aufenthalt rZielAufenthalt;


        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("History", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aufnahmezeitpunkt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Entlassungszeitpunkt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Entlassungsbemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPatientHistorie));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.dgHistorie = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAufenthalt1 = new PMDS.Data.Patient.dsAufenthalt();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.panelButt = new Infragistics.Win.Misc.UltraPanel();
            this.btnundo2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.btnCopyDekurse = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucAufEntInfo1 = new PMDS.GUI.ucAufEntInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthalt1)).BeginInit();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.panelButt.ClientArea.SuspendLayout();
            this.panelButt.SuspendLayout();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHistorie
            // 
            this.dgHistorie.AutoWork = true;
            this.dgHistorie.DataSource = this.dsAufenthalt1.History;
            this.dgHistorie.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.Black;
            this.dgHistorie.DisplayLayout.Appearance = appearance1;
            this.dgHistorie.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Format = "";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.MaskInput = "dd.mm.yyyy hh:mm:ss";
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(120, 0);
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MaskInput = "dd.mm.yyyy hh:mm:ss";
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(142, 0);
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(198, 0);
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgHistorie.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgHistorie.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgHistorie.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.dgHistorie.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgHistorie.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgHistorie.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgHistorie.DisplayLayout.Override.NullText = "";
            this.dgHistorie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHistorie.Location = new System.Drawing.Point(0, 0);
            this.dgHistorie.Name = "dgHistorie";
            this.dgHistorie.Size = new System.Drawing.Size(625, 174);
            this.dgHistorie.TabIndex = 50;
            this.dgHistorie.AfterRowActivate += new System.EventHandler(this.dgHistorie_AfterRowActivate);
            this.dgHistorie.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgHistorie_CellChange);
            this.dgHistorie.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgHistorie_BeforeCellActivate);
            // 
            // dsAufenthalt1
            // 
            this.dsAufenthalt1.DataSetName = "dsAufenthalt";
            this.dsAufenthalt1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAufenthalt1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.dgHistorie);
            this.ultraPanel1.Location = new System.Drawing.Point(3, 3);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(625, 174);
            this.ultraPanel1.TabIndex = 51;
            // 
            // panelButt
            // 
            this.panelButt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // panelButt.ClientArea
            // 
            this.panelButt.ClientArea.Controls.Add(this.btnCopyDekurse);
            this.panelButt.ClientArea.Controls.Add(this.btnundo2);
            this.panelButt.ClientArea.Controls.Add(this.btnSave2);
            this.panelButt.Location = new System.Drawing.Point(3, 428);
            this.panelButt.Name = "panelButt";
            this.panelButt.Size = new System.Drawing.Size(625, 38);
            this.panelButt.TabIndex = 52;
            // 
            // btnundo2
            // 
            this.btnundo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnundo2.Appearance = appearance3;
            this.btnundo2.AutoWorkLayout = false;
            this.btnundo2.Enabled = false;
            this.btnundo2.IsStandardControl = false;
            this.btnundo2.Location = new System.Drawing.Point(428, 3);
            this.btnundo2.Name = "btnundo2";
            this.btnundo2.Size = new System.Drawing.Size(92, 31);
            this.btnundo2.TabIndex = 53;
            this.btnundo2.Text = "Rückgängig";
            this.btnundo2.Click += new System.EventHandler(this.btnundo2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSave2.Appearance = appearance4;
            this.btnSave2.AutoWorkLayout = false;
            this.btnSave2.Enabled = false;
            this.btnSave2.IsStandardControl = false;
            this.btnSave2.Location = new System.Drawing.Point(530, 3);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(92, 31);
            this.btnSave2.TabIndex = 52;
            this.btnSave2.Text = "Speichern";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // ultraPanel3
            // 
            this.ultraPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ucAufEntInfo1);
            this.ultraPanel3.Location = new System.Drawing.Point(3, 183);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(625, 239);
            this.ultraPanel3.TabIndex = 52;
            // 
            // btnCopyDekurse
            // 
            this.btnCopyDekurse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = global::PMDS.GUI.Properties.Resources.Wichtig;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnCopyDekurse.Appearance = appearance2;
            this.btnCopyDekurse.AutoWorkLayout = false;
            this.btnCopyDekurse.Enabled = false;
            this.btnCopyDekurse.IsStandardControl = false;
            this.btnCopyDekurse.Location = new System.Drawing.Point(3, 3);
            this.btnCopyDekurse.Name = "btnCopyDekurse";
            this.btnCopyDekurse.Size = new System.Drawing.Size(263, 31);
            this.btnCopyDekurse.TabIndex = 54;
            this.btnCopyDekurse.Text = "Dekurse in aktuellen Aufenthalt übertragen";
            this.btnCopyDekurse.Visible = false;
            this.btnCopyDekurse.Click += new System.EventHandler(this.btnCopyDekurse_Click);
            // 
            // ucAufEntInfo1
            // 
            this.ucAufEntInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucAufEntInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAufEntInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucAufEntInfo1.Name = "ucAufEntInfo1";
            this.ucAufEntInfo1.Size = new System.Drawing.Size(625, 239);
            this.ucAufEntInfo1.TabIndex = 49;
            // 
            // ucPatientHistorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelButt);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this.ultraPanel1);
            this.Name = "ucPatientHistorie";
            this.Size = new System.Drawing.Size(631, 466);
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthalt1)).EndInit();
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.panelButt.ClientArea.ResumeLayout(false);
            this.panelButt.ResumeLayout(false);
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
                
		public ucPatientHistorie()
		{
			InitializeComponent();
		}

	
		public Patient Patient
		{
			get	
			{	
				return _patient;	
			}
			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Patient");

				_patient = value;
                loadData();
			}
		}
	    public void loadData()
		{
			try
			{
				dgHistorie.DataSource = Aufenthalt.HistoryByPatient(Patient.ID);
				ResfreshAufenthalt();
                setUIButtons(false, false);
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}


		private void dgHistorie_AfterRowActivate(object sender, System.EventArgs e)
		{
			ResfreshAufenthalt();
		}

		private void ResfreshAufenthalt()
		{
			if (CurrentRow != null)
			{
				Aufenthalt auf = new Aufenthalt(CurrentRow.ID);
				ucAufEntInfo1.Aufenthalt = auf;
                setUIButtons(false, false);

                if (CurrentRow.ID != ENV.IDAUFENTHALT)
                {
                    if (ENV.IDAUFENTHALT != null)
                    {
                        if (!ENV.IDAUFENTHALT.Equals(Guid.Empty))
                        {
                            rZielAufenthalt = PMDSBusiness1.getAufenthalt(ENV.IDAUFENTHALT);

                            if (rZielAufenthalt.Entlassungszeitpunkt == null && PMDS.Global.ENV.HasRight(UserRights.MenüStammdaten))
                            {
                                rQuellAufenthalt = PMDSBusiness1.getAufenthalt(CurrentRow.ID);
                                setUIButtons(false, true);
                            }
                        }
                    }
                }
			}
		}

		public dsAufenthalt.HistoryRow CurrentRow
		{
			get
			{
				return (dsAufenthalt.HistoryRow)UltraGridTools.CurrentSelectedRow(dgHistorie);
			}
		}

        private void dgHistorie_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            //if (e.Cell.Column.ToString() == "Aufnahmezeitpunkt" || e.Cell.Column.ToString() == "Entlassungszeitpunkt")
            //    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        private bool  save()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in this.dgHistorie.Rows)
            {
                dsAufenthalt.HistoryRow rDS = (dsAufenthalt.HistoryRow)((System.Data.DataRowView)r.ListObject).Row;
                if (rDS.IsAufnahmezeitpunktNull())
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Aufnahmezeitpunkt: Eingabe erforderlich!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!rDS.IsEntlassungszeitpunktNull())
                {
                    if (rDS.Entlassungszeitpunkt < rDS.Aufnahmezeitpunkt)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Aufnahmezeitpunkt liegt vor Entlassungszeitpunkt!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }

            int anzAktAufenth = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in this.dgHistorie.Rows)
            {
                dsAufenthalt.HistoryRow rDS = (dsAufenthalt.HistoryRow)((System.Data.DataRowView)r.ListObject).Row;
                if (rDS.IsEntlassungszeitpunktNull())
                    anzAktAufenth += 1;
            }
            if (anzAktAufenth > 1)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es darf nur einen aktuellen Aufenthalt (kein Entlassungszeitpunkt) geben!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in this.dgHistorie.Rows)
            {
                dsAufenthalt.HistoryRow rDS = (dsAufenthalt.HistoryRow)((System.Data.DataRowView)r.ListObject).Row;
                dbAuf.updateAufnahmeEntlassung(rDS.ID, rDS.Aufnahmezeitpunkt, rDS.IsEntlassungszeitpunktNull()? new DateTime(1900, 1, 1): rDS.Entlassungszeitpunkt);
            }
            return true;
        }



        public void setUIButtons(bool OnOff, bool CopyDekurseOnOff)
        {
            this.btnSave2.Enabled = OnOff;
            this.btnundo2.Enabled = OnOff;
            this.btnCopyDekurse.Visible = CopyDekurseOnOff;
            this.btnCopyDekurse.Enabled = CopyDekurseOnOff;

        }

        private void dgHistorie_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.dgHistorie.UpdateData();
            setUIButtons(true, false);
        }


        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.save()) this.loadData();
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
        private void btnundo2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
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

        private void btnCopyDekurse_Click(object sender, EventArgs e)
        {
            int iDekurse = PMDSBusiness1.CopyDekurse(rQuellAufenthalt.ID, rZielAufenthalt.ID);
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iDekurse.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Dekurse wurden kopiert."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurse von Voraufenthalt kopieren"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
        }
	}
}
