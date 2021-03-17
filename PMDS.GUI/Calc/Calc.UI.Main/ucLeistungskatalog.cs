using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using PMDS.BusinessLogic.Abrechnung;
using Infragistics.Win.UltraWinGrid;
using PMDS.Abrechnung.Global;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.DB;
using System.Linq;


namespace PMDS.Calc.UI.Admin
{


    public class ucLeistungskatalog : QS2.Desktop.ControlManagment.BaseControl, ISave, IRefresh
	{
        private Leistungsgruppe _Leistungsgruppe = Leistungsgruppe.WohnkomponenteGrundleistung;
        public event EventHandler ValueChanged;
		private LeistungsKatalog		_leistungskatalog = new LeistungsKatalog();
        private bool _LeistungChenged = false;
        private dsLeistungskatalog.LeistungskatalogGueltigDataTable _Olddt;
        private List<Guid> _lAbrechnungen = new List<Guid>();
        private System.Collections.ArrayList arrToDelete = new System.Collections.ArrayList();

        private PatientLeistungsplan _dtPatLeist = new PatientLeistungsplan();


        private PMDS.Abrechnung.Global.dsLeistungskatalog dsLeistungskatalog1;
		private QS2.Desktop.ControlManagment.BaseLabel lblLeistungskatalog;
        private QS2.Desktop.ControlManagment.BaseLabel lblLeistungskatalogGruppe;
		private EnumOptionSet optionsGruppe;
        private ErrorProvider errorProvider1;
        private ucButton btnAdd;
        private ucButton btnDel;
        private ucButton btnAddPrice;
        private GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
		private IContainer components;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain2;
        public bool isLoaded = false;





		public ucLeistungskatalog()
		{
			InitializeComponent();
			if(DesignMode || !ENV.AppRunning)
				return;
	    }
        public void initControl()
        {
           if ( this.isLoaded)
               return;

            // scf

            optionsGruppe.SetEnumType(typeof(Leistungsgruppe));
            optionsGruppe.CheckedIndex = (int)_Leistungsgruppe;    // Wohnkomponente

            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();
            RefreshControl();

            this.isLoaded = true;
        }

        public bool Save() 
		{
            try
            {
                if (!ValidateFields())
                {
                    return false;
                }

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain2);
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (dsLeistungskatalog.LeistungskatalogRow rLeistCheck in dsLeistungskatalog1.Leistungskatalog)
                    {
                        if (rLeistCheck.RowState == DataRowState.Deleted)
                        {
                            Guid IDLeistCheck = (Guid)rLeistCheck["ID", DataRowVersion.Original];
                            var tLeistungen = (from pl in db.PatientLeistungsplan
                                               join l in db.Leistungskatalog on pl.IDLeistungskatalog equals l.ID
                                               join p in db.Patient on pl.IDPatient equals p.ID
                                               where l.ID == IDLeistCheck
                                               select new
                                               {
                                                   ID = l.ID,
                                                   IDPatientLeistungskatalog = pl.ID,
                                                   Bezeichnung = l.Bezeichnung,
                                                   Nachname = p.Nachname,
                                                   Vorname = p.Vorname
                                               });

                            if (tLeistungen.Count() > 0)
                            {
                                string sMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Leistungskatalog '{0}' kann nicht gelöscht werden, da er von folgenden Klienten verwendet wird:") + "\r\n";
                                sMsgBox = System.String.Format(sMsgBox, rLeistCheck["Bezeichnung", DataRowVersion.Original].ToString());
                                foreach (var rLeistung in tLeistungen)
                                {
                                    sMsgBox += rLeistung.Nachname.Trim() + " " + rLeistung.Vorname.Trim() + "\r\n";
                                }
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBox, "PMDS");
                                return false;
                            }
                        }
                    }


                }

                _leistungskatalog.Update(dsLeistungskatalog1);
                if (_LeistungChenged)
                {
                    _LeistungChenged = false;
                    _Olddt = (dsLeistungskatalog.LeistungskatalogGueltigDataTable)dsLeistungskatalog1.LeistungskatalogGueltig.Copy();
                }
                _lAbrechnungen.Clear();
                return true;
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
                return false;
            }
		}

        public void Undo()
        {
            _LeistungChenged = false;
            RefreshControl();
        }

        public bool IsChanged { get { return _LeistungChenged; } }

        public bool ValidateFields()
        {
            bool bError = false;

            if (dgMain2.ActiveRow == null || dgMain2.ActiveRow.ListObject == null)
                return !bError;

            foreach (UltraGridRow row in dgMain2.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (!ValidateField(cell))
                    {
                        bError = true;
                        break;
                    }
                }

                if (!bError)
                {
                    foreach (UltraGridChildBand cb in row.ChildBands)
                    {
                        foreach (UltraGridRow r in cb.Rows)
                        {
                            foreach (UltraGridCell c in r.Cells)
                            {
                                if (!ValidateField(c))
                                {
                                    bError = true;
                                    r.ParentRow.ExpandAll();
                                    break;
                                }
                            }

                            if (bError) break;
                        }

                        if (bError) break;
                    }
                }

                if (bError) break;
            }
            return !bError;
        }

        public void RefreshControl()
        {
            if (DesignMode || !ENV.AppRunning)
                return;

            this.arrToDelete.Clear();
            dsLeistungskatalog1 = _leistungskatalog.Read(optionsGruppe.Option);
            dsLeistungskatalog1.LeistungskatalogGueltig.GueltigAbColumn.AllowDBNull = true;
            dsLeistungskatalog1.LeistungskatalogGueltig.BetragColumn.AllowDBNull = true;
            dsLeistungskatalog1.LeistungskatalogGueltig.MWSTColumn.AllowDBNull = true;
            dsLeistungskatalog1.LeistungskatalogGueltig.GutschriftProTagAbwesendColumn.AllowDBNull = true;
            dgMain2.DataSource = dsLeistungskatalog1;
            dgMain2.Refresh();
            _Olddt = (dsLeistungskatalog.LeistungskatalogGueltigDataTable)dsLeistungskatalog1.LeistungskatalogGueltig.Copy();
            _lAbrechnungen.Clear();

            PMDS.Global.Leistungsgruppe leistungsGrp;
            leistungsGrp = (PMDS.Global.Leistungsgruppe)this.optionsGruppe.Value;
            
            if (   leistungsGrp == Leistungsgruppe.PeriodischeLeistungen  )
            {
                this.dgMain2.DisplayLayout.Bands[1].Columns["GutschriftProTagAbwesend"].Format = "###,###,##0.00";
                this.dgMain2.DisplayLayout.Bands[1].Columns["GutschriftProTagAbwesend"].MaskInput = "{double:-9.2}";

                this.dgMain2.DisplayLayout.Bands[1].Columns["Betrag"].Format = "###,###,##0.00";
                this.dgMain2.DisplayLayout.Bands[1].Columns["Betrag"].MaskInput = "{double:-9.2}";
            }
            else 
            {
                this.dgMain2.DisplayLayout.Bands[1].Columns["GutschriftProTagAbwesend"].Format = "###,###,##0.000";
                this.dgMain2.DisplayLayout.Bands[1].Columns["GutschriftProTagAbwesend"].MaskInput = "{double:-9.3}";

                this.dgMain2.DisplayLayout.Bands[1].Columns["Betrag"].Format = "###,###,##0.000";
                this.dgMain2.DisplayLayout.Bands[1].Columns["Betrag"].MaskInput = "{double:-9.3}";
            }

        }

        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            string error = "";

            if (cell.Band == dgMain2.DisplayLayout.Bands[0])
            {
                dsLeistungskatalog.LeistungskatalogRow r = (dsLeistungskatalog.LeistungskatalogRow)v.Row;
                dsLeistungskatalog.LeistungskatalogDataTable dt = (dsLeistungskatalog.LeistungskatalogDataTable)r.Table;

                if (cell.Column.Key == dt.BezeichnungColumn.ColumnName)
                {
                    r.SetColumnError(dt.BezeichnungColumn.ColumnName, "");
                    GuiUtil.ValidateField(dgMain2, cell.Text.Trim().Length > 0,
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                    if (bError)
                        r.SetColumnError(dt.BezeichnungColumn.ColumnName, ENV.String("GUI.E_NO_TEXT"));
                    //Doppelte Einträge
                    if (!bError)
                    {
                        error = "";
                        foreach (UltraGridRow row in dgMain2.Rows)
                        {
                            if (row == cell.Row || r.RowState == DataRowState.Unchanged) continue;
                            foreach (UltraGridCell c in row.Cells)
                            {
                                if (c.Column.Key == dt.BezeichnungColumn.ColumnName)
                                {
                                    error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Leistungskatalog ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                                    GuiUtil.ValidateField(dgMain2, c.Text.Trim() != cell.Text.Trim(), error, ref bError, false, null);
                                    if (bError)
                                        break;
                                }
                            }
                            if (bError)
                            {
                                r.SetColumnError(dt.BezeichnungColumn.ColumnName, error);
                                break;
                            }
                        }
                    }
                }
            }
            else if (cell.Band == dgMain2.DisplayLayout.Bands[1])
            {
                dsLeistungskatalog.LeistungskatalogGueltigRow r = (dsLeistungskatalog.LeistungskatalogGueltigRow)v.Row;
                dsLeistungskatalog.LeistungskatalogGueltigDataTable dt = (dsLeistungskatalog.LeistungskatalogGueltigDataTable)r.Table;

                r.SetColumnError(cell.Column.Index, "");

                if (cell.Column.Key == dt.GueltigAbColumn.ColumnName)
                {
                    //if (((DateTime )cell.Value).Day != 1)
                    //{
                    //    r.SetColumnError(cell.Column.Index, "Das 'Gültig ab' Datum kann nur mit Monatsbeginn (01.mm.yyyy) angegeben werden!");
                    //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das 'Gültig ab' Datum kann nur mit Monatsbeginn (01.mm.yyyy) angegeben werden!", "Eingabefehler GültigAb");
                    //    bError = true;
                    //}

                    DateTime t = new DateTime(1900, 1, 1);
                    GuiUtil.ValidateField(dgMain2, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                    if (bError)
                        r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                    //Doppelte Einträge
                    if (!bError)
                    {
                        error = "";
                        foreach (UltraGridRow row in dgMain2.Rows)
                        {
                            if (row != cell.Row.ParentRow) continue;
                            foreach (UltraGridChildBand cb in row.ChildBands)
                            {
                                foreach (UltraGridRow rr in cb.Rows)
                                {
                                    if (rr == cell.Row || r.RowState == DataRowState.Unchanged) continue;
                                    foreach (UltraGridCell c in rr.Cells)
                                    {
                                        if (c.Column.Key == dt.GueltigAbColumn.ColumnName)
                                        {
                                            error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig ab ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                                            GuiUtil.ValidateField(dgMain2, c.Text.Trim() != cell.Text.Trim(), error, ref bError, false, null);
                                            if (bError)
                                                break;
                                        }
                                    }

                                    if (bError)
                                    {
                                        r.SetColumnError(dt.GueltigAbColumn.ColumnName, error);
                                        break;
                                    }
                                }

                                if (bError)
                                    break;
                            }
                        }
                    }
                }
                else if (cell.Column.Key == dt.BetragColumn.ColumnName ||
                         cell.Column.Key == dt.MWSTColumn.ColumnName ||
                         cell.Column.Key == dt.GutschriftProTagAbwesendColumn.ColumnName
                        )
                {
                    bool valid;

                    try                    
                    {
                        if (cell.Editor != null && cell.Editor.IsInEditMode)
                            valid = cell.EditorResolved.IsValid;
                        else
                            valid = !String.IsNullOrWhiteSpace(cell.Value.ToString());
                    }
                    catch
                    {
                        valid = cell.Value.ToString().Trim() != "";
                    }

                    GuiUtil.ValidateField(dgMain2, valid,
                            ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                    if (bError)
                        r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
                }
            }

            if (bError)
            {
                dgMain2.ActiveCell = cell;
                dgMain2.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLeistungskatalog));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Leistungskatalog", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Barcode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FIBUKonto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("enumLeistungsgruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DivisorFuerMonatsleistung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MonatsleistungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaeglichJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WochenTage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VerrechnungImVorrausJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LeistungskatalogLeistungskatalogGueltig");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("LeistungskatalogLeistungskatalogGueltig", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLeistungskatalog");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MWST");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GutschriftProTagAbwesend");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TagsatzberechnungJN");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.dsLeistungskatalog1 = new PMDS.Abrechnung.Global.dsLeistungskatalog();
            this.lblLeistungskatalog = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblLeistungskatalogGruppe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnAddPrice = new PMDS.GUI.ucButton(this.components);
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.dgMain2 = new QS2.Desktop.ControlManagment.BaseGrid();
            this.optionsGruppe = new PMDS.Calc.UI.Admin.EnumOptionSet(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsLeistungskatalog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsGruppe)).BeginInit();
            this.SuspendLayout();
            // 
            // dsLeistungskatalog1
            // 
            this.dsLeistungskatalog1.DataSetName = "dsLeistungskatalog";
            this.dsLeistungskatalog1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsLeistungskatalog1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblLeistungskatalog
            // 
            this.lblLeistungskatalog.Location = new System.Drawing.Point(13, 102);
            this.lblLeistungskatalog.Name = "lblLeistungskatalog";
            this.lblLeistungskatalog.Size = new System.Drawing.Size(160, 16);
            this.lblLeistungskatalog.TabIndex = 6;
            this.lblLeistungskatalog.Text = "Leistungskatalog";
            // 
            // lblLeistungskatalogGruppe
            // 
            this.lblLeistungskatalogGruppe.Location = new System.Drawing.Point(13, 10);
            this.lblLeistungskatalogGruppe.Name = "lblLeistungskatalogGruppe";
            this.lblLeistungskatalogGruppe.Size = new System.Drawing.Size(176, 16);
            this.lblLeistungskatalogGruppe.TabIndex = 7;
            this.lblLeistungskatalogGruppe.Text = "Leistungskataloggruppe";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextVAlignAsString = "Middle";
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(519, 97);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(154, 24);
            this.btnDel.TabIndex = 9;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance2.TextVAlignAsString = "Middle";
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(219, 97);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 24);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Leistung hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextVAlignAsString = "Middle";
            this.btnAddPrice.Appearance = appearance1;
            this.btnAddPrice.AutoWorkLayout = false;
            this.btnAddPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPrice.DoOnClick = true;
            this.btnAddPrice.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddPrice.IsStandardControl = true;
            this.btnAddPrice.Location = new System.Drawing.Point(370, 97);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(148, 24);
            this.btnAddPrice.TabIndex = 11;
            this.btnAddPrice.TabStop = false;
            this.btnAddPrice.Text = "Preis hinzufügen";
            this.btnAddPrice.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddPrice.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddPrice_Click);
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(179, 97);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 163;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // dgMain2
            // 
            this.dgMain2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain2.AutoWork = true;
            this.dgMain2.DataSource = this.dsLeistungskatalog1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgMain2.DisplayLayout.Appearance = appearance4;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 269;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 3;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Caption = "FiBu";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 4;
            ultraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositive;
            ultraGridColumn23.Width = 123;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 6;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 7;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Caption = "Monatsleistung";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 5;
            ultraGridColumn26.Width = 105;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 8;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 9;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 10;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Caption = "Einrichtung";
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn30.Width = 212;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 11;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31});
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 0;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn32.Width = 188;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 1;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn33.Width = 311;
            ultraGridColumn34.Header.Caption = "Gültig ab";
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 2;
            ultraGridColumn34.Width = 92;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn35.CellAppearance = appearance5;
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn35.Header.Appearance = appearance6;
            ultraGridColumn35.Header.Caption = "Betrag E/H";
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 3;
            ultraGridColumn35.Width = 126;
            appearance7.TextHAlignAsString = "Right";
            ultraGridColumn36.CellAppearance = appearance7;
            appearance8.TextHAlignAsString = "Right";
            ultraGridColumn36.Header.Appearance = appearance8;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 4;
            ultraGridColumn36.Width = 80;
            ultraGridColumn37.Header.Caption = "Gutschrift pro Abwesenheitstag";
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 5;
            ultraGridColumn37.Width = 179;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 6;
            ultraGridColumn38.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38});
            this.dgMain2.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain2.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgMain2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain2.DisplayLayout.GroupByBox.Appearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance10;
            this.dgMain2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance11.BackColor2 = System.Drawing.SystemColors.Control;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain2.DisplayLayout.GroupByBox.PromptAppearance = appearance11;
            this.dgMain2.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain2.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance13.BackColor = System.Drawing.SystemColors.Highlight;
            appearance13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain2.DisplayLayout.Override.ActiveRowAppearance = appearance13;
            this.dgMain2.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.dgMain2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgMain2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain2.DisplayLayout.Override.CardAreaAppearance = appearance14;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain2.DisplayLayout.Override.CellAppearance = appearance15;
            this.dgMain2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain2.DisplayLayout.Override.CellPadding = 0;
            appearance16.BackColor = System.Drawing.SystemColors.Control;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain2.DisplayLayout.Override.GroupByRowAppearance = appearance16;
            appearance17.TextHAlignAsString = "Left";
            this.dgMain2.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.dgMain2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            this.dgMain2.DisplayLayout.Override.RowAppearance = appearance18;
            this.dgMain2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain2.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain2.DisplayLayout.Override.TemplateAddRowAppearance = appearance19;
            this.dgMain2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain2.Location = new System.Drawing.Point(13, 123);
            this.dgMain2.Name = "dgMain2";
            this.dgMain2.Size = new System.Drawing.Size(659, 327);
            this.dgMain2.TabIndex = 164;
            this.dgMain2.Text = "ultraGrid1";
            this.dgMain2.AfterRowActivate += new System.EventHandler(this.dgMain2_AfterRowActivate);
            this.dgMain2.AfterRowsDeleted += new System.EventHandler(this.dgMain2_AfterRowsDeleted);
            this.dgMain2.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain2_AfterRowUpdate);
            this.dgMain2.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain2_CellChange);
            this.dgMain2.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgMain2_BeforeExitEditMode);
            this.dgMain2.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain2_BeforeRowsDeleted);
            this.dgMain2.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgMain2_DoubleClickRow);
            this.dgMain2.DoubleClick += new System.EventHandler(this.dgMain2_DoubleClick);
            this.dgMain2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMain2_KeyDown);
            // 
            // optionsGruppe
            // 
            this.optionsGruppe.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optionsGruppe.ItemSpacingVertical = 4;
            this.optionsGruppe.Location = new System.Drawing.Point(34, 27);
            this.optionsGruppe.Name = "optionsGruppe";
            this.optionsGruppe.Option = -1;
            this.optionsGruppe.Size = new System.Drawing.Size(526, 60);
            this.optionsGruppe.TabIndex = 4;
            this.optionsGruppe.ValueChanged += new System.EventHandler(this.optionsGruppe_ValueChanged);
            // 
            // ucLeistungskatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLeistungskatalog);
            this.Controls.Add(this.ucKlinikDropDown1);
            this.Controls.Add(this.btnAddPrice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.optionsGruppe);
            this.Controls.Add(this.lblLeistungskatalogGruppe);
            this.Controls.Add(this.dgMain2);
            this.Name = "ucLeistungskatalog";
            this.Size = new System.Drawing.Size(681, 459);
            this.Load += new System.EventHandler(this.ucLeistungskatalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsLeistungskatalog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsGruppe)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		private void ExpandActiveRow()
		{
            if (dgMain2.ActiveRow != null)
                dgMain2.ActiveRow.ExpandAll();
		}


		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Guid ACTIVE_ID
		{
			get 
			{
                UltraGridRow r = dgMain2.ActiveRow;
				if(r.ParentRow != null)
					r = r.ParentRow;
				return (Guid)r.Cells["ID"].Value;
			}
		}

        //Neu nach 24.10.2007 MDA
        private void HandleDelete()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain2.Selected.Rows)
				al.Add(r);

            if (al.Count == 0 && dgMain2.ActiveRow != null && !dgMain2.ActiveRow.IsFilteredOut)
                al.Add(dgMain2.ActiveRow);

            UltraGridRow[] ra  = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if(ra.Length == 0) 
			{
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
           	}
            if(PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
				return;

			PatientLeistungsplan pL = new PatientLeistungsplan();
            dsPatientLeistungsplan.PatientLeistungsplanDataTable dt;
            //dsPatientLeistungsplan.PatientLeistungsplanRow[] lpRows;
            dsLeistungskatalog.LeistungskatalogRow rL;
            dsLeistungskatalog.LeistungskatalogGueltigRow gR;
            DataRowView v;
            //Patient p;
            //bool delete = true;
            StringBuilder sb = new StringBuilder();
            //string bezeichnung;
            foreach(UltraGridRow row in ra)
            {
                v = (DataRowView)row.ListObject;
                //delete = true;
                if (v.Row is dsLeistungskatalog.LeistungskatalogRow)
                {
                    rL = (dsLeistungskatalog.LeistungskatalogRow)v.Row;
                    arrToDelete.Add(rL.ID);
                    //dt = pL.ReadByLeistungskatalog(rL.ID);
                    //lpRows = (dsPatientLeistungsplan.PatientLeistungsplanRow[])dt.Select();
                    //bezeichnung = rL.Bezeichnung;
                }
                else //if(v.Row is dsLeistungskatalog.LeistungskatalogGueltigRow)
                {
                    gR = (dsLeistungskatalog.LeistungskatalogGueltigRow)v.Row;
                    rL = (dsLeistungskatalog.LeistungskatalogRow)((DataRowView)row.ParentRow.ListObject).Row;
                    //arrToDelete.Add(gR.IDLeistungskatalog);
                //    dt = pL.ReadByLeistungskatalog(gR.IDLeistungskatalog);
                //    lpRows = (dsPatientLeistungsplan.PatientLeistungsplanRow[])dt.Select("GueltigAb <= #" + gR.GueltigAb.ToString("MM/dd/yyyy HH:mm:ss") + "# and GueltigBis >= #" + gR.GueltigAb.ToString("MM/dd/yyyy HH:mm:ss") + "#");
                //    bezeichnung = rL.Bezeichnung + " Gültig ab: " + gR.GueltigAb.ToString("dd.MM.yyyy");
                }

                //if (lpRows.Length > 0)
                //{
                //    delete = false;
                //    if (sb.Length > 0) sb.Append(", ");
                //    sb.Append(bezeichnung);

                //    //Klienten anzeigen
                //    //if(sb.Length > 0) sb.Append("\n");
                //    //sb.Append("- " + rL.Bezeichnung + " ist zu folgende Klienten zugeordnet:\n\t");

                //    //foreach(dsPatientLeistungsplan.PatientLeistungsplanRow pRow in dt)
                //    //{
                //    //    p = new Patient(pRow.IDPatient);
                //    //    if (dt.Rows.IndexOf(pRow) > 0)
                //    //        sb.Append("\n\t");
                //    //    sb.Append("- " + p.FullName);
                //    //}

                //}

                //if (delete)
                //{
               
                    row.Delete(false);
                    _LeistungChenged = true;

                    if (ValueChanged != null)
                        ValueChanged(this, null);
                //}
            }

            //if (sb.Length > 0)
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Folgende Leistungskatalog(e) (" + sb.ToString() + ") ist(sind) zu Klienten zugeordenet, Daher kann(können) nicht gelöscht werden.", "Leistungskataloge löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }

		private void cbLeistungsgruppe_ValueChanged(object sender, System.EventArgs e)
		{
			Save();
			RefreshControl();
		}

		// scf
		private void radiosLeistungsgruppe_ValueChanged(object sender, EventArgs e)
		{
			Save();
			RefreshControl();
		}

		// scf
		private void optionsGruppe_ValueChanged(object sender, EventArgs e)
		{
            try
            {
                if ((int)_Leistungsgruppe == optionsGruppe.CheckedIndex)
                    return;

                if (IsChanged)
                {
                    DialogResult res = ENV.AskForSave();

                    if (res == DialogResult.Cancel)
                    {
                        optionsGruppe.Value = (int)_Leistungsgruppe;
                        optionsGruppe.Option = (int)_Leistungsgruppe;
                        return;
                    }
                    else if (res == DialogResult.Yes)
                        Save();
                    else
                        Undo();
                }
                _Leistungsgruppe = (Leistungsgruppe)Enum.Parse(typeof(Leistungsgruppe), optionsGruppe.CheckedIndex.ToString());
                if (_Leistungsgruppe == Leistungsgruppe.PeriodischeLeistungen)
                {
                    this.dgMain2.DisplayLayout.Bands[0].Columns["MonatsleistungJN"].Hidden = false;
                }
                else
                {
                    this.dgMain2.DisplayLayout.Bands[0].Columns["MonatsleistungJN"].Hidden = false;
                }
                RefreshControl();
            }
            catch
            {
            }
		}


		private void EnableDisableButtons()
		{
            if (dgMain2.ActiveRow == null)
			{
			    btnAddPrice.Enabled = false;
				btnDel.Enabled = false;
			}
			else
			{
			    btnAddPrice.Enabled = true;
				btnDel.Enabled = true;
			}
		}

        private void ucLeistungskatalog_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _leistungskatalog.NewLeistungskatalog(dsLeistungskatalog1.Leistungskatalog, optionsGruppe.Option);

            // scf: wenn man auf einem Preis steht, funktioniert die Funktion "SelectFieldInLastRowForEdit" nicht!
            if (dgMain2.ActiveRow != null && dgMain2.ActiveRow.ParentRow != null)
            {
                dgMain2.ActiveRow = dgMain2.ActiveRow.ParentRow;
            }

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain2, "Bezeichnung");
            ExpandActiveRow();
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain2, "Bezeichnung"); // weil nach Expand der focus weg ist
            _LeistungChenged = true;

            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            if (dgMain2.ActiveRow == null)
                return;
            _leistungskatalog.NewLeistungsgruppeGueltig(dsLeistungskatalog1, ACTIVE_ID);
            ExpandActiveRow();

            _LeistungChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            HandleDelete();
        }



        private void dgMain2_AfterRowActivate(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void dgMain2_AfterRowsDeleted(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void dgMain2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            _LeistungChenged = true;
        }

        private void dgMain2_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            if (dgMain2.ActiveCell.Column.Key == _Olddt.TagsatzberechnungJNColumn.ColumnName)
                return;
            Cursor = Cursors.Default;
        }

        private void dgMain2_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain2.Focused)
                e.Cancel = true;
        }

        private void dgMain2_CellChange(object sender, CellEventArgs e)
        {
            _LeistungChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgMain2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e.Row.IsExpanded)
                e.Row.Expanded = false;
            else
                e.Row.ExpandAll();
        }

        private void dgMain2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (dgMain.ActiveCell != null && dgMain.ActiveCell.IsInEditMode)
            //            return;
            //        e.Handled = true;
            //    }
            //    HandleDelete();
            //}
        }

	}
}
