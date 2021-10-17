using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI;
using Infragistics.Win;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Calc.UI.Admin;
using System.Linq;
using PMDS.DB;



namespace PMDS.GUI.Kostentraeger
{


    public partial class ucKostentraegerKlient2 : UserControl
    {

        private PMDS.Calc.Admin.DB.DBPatientKostentraeger _kost = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
        private dsPatientKostentraeger.PatientKostentraegerDataTable _dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
        private dsPatientKostentraeger.PatientKostentraegerErweitertDataTable _dtErweitert = new dsPatientKostentraeger.PatientKostentraegerErweitertDataTable();

        public event EventHandler ValueChanged;
        private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;
        private bool _TransferKostentraegerJN = false;
        private bool _readOnly = false;

        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();




        

        public ucKostentraegerKlient2()
        {
            InitializeComponent();
        }


        public void initControl()
        {
            this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
            this.btnAddKlient.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
            this.btnAddFSW.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
            this.btnAddErwachsenenvertreter.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
            this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
            this.btnUpdate.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);

            //this.btnAddFSW.Visible = ENV.FSW_IDIntern != Guid.Empty;
            this.btnAddFSW.Visible = false; //Ersetzt durch Auswahl der Zahlart im normalen Modus
            RefreshValueLists();
        }

        public bool TransferKostentraegerJN
        {
            get { return _TransferKostentraegerJN; }
            set
            {
                _TransferKostentraegerJN = value;
                ShowHideColumns();
            }
        }

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                //_kost.Update(_dtErweitert);
                //_kost.Update(_dt);

                _DataChenged = false;
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
        public void Undo()
        {
            RefreshControl();
        }
        public bool IsChanged { get { return _DataChenged; } }

        public void RefreshControl()
        {
         

            _DataChenged = false;
            _dt = _kost.Read(_IDPatient, TransferKostentraegerJN);
            _dt.IDKostentraegerColumn.AllowDBNull = true;
            _dt.GueltigAbColumn.AllowDBNull = true;

            _dtErweitert = _kost.ReadErweitert(_IDPatient, TransferKostentraegerJN);
            _dtErweitert.IDKostentraegerColumn.AllowDBNull = true;
            _dtErweitert.GueltigAbColumn.AllowDBNull = true;

            dgMain.DataSource = _dtErweitert;
            dgMain.Refresh();

            if (dgMain.ActiveRow != null)
            {
                dgMain.ActiveRow.Selected = true;
            }

            dgMain.DisplayLayout.ValueLists.Clear();

            Infragistics.Win.ValueList valList = new Infragistics.Win.ValueList();
            sitemap.fillEnumBillTyp(valList, false);
            dgMain.DisplayLayout.ValueLists.Add(valList);

            Infragistics.Win.ValueList valListDruckTyp = new Infragistics.Win.ValueList();
            sitemap.fillEnumDruckTyp(valListDruckTyp);
            dgMain.DisplayLayout.ValueLists.Add(valListDruckTyp);

            Infragistics.Win.ValueList valListIDKostentraegerSub = new Infragistics.Win.ValueList();
            sitemap.fillIDKostentraegerSub(valListIDKostentraegerSub);
            dgMain.DisplayLayout.ValueLists.Add(valListIDKostentraegerSub);

            this.dgMain.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            this.dgMain.DisplayLayout.Bands[0].Columns["IDPatientIstZahler"].Hidden = true;
            this.dgMain.DisplayLayout.Bands[0].Columns["VorauszahlungJN"].Hidden = true;
            this.dgMain.DisplayLayout.Bands[0].Columns["AbgerechnetBis"].Hidden = true;
            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Hidden = true;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungsdruckTyp"].Hidden = false;

            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungTyp"].ValueList = dgMain.DisplayLayout.ValueLists[0];
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungsdruckTyp"].ValueList = dgMain.DisplayLayout.ValueLists[1];
            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].ValueList = dgMain.DisplayLayout.ValueLists[2];

            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraeger"].Header.VisiblePosition = 0;
            this.dgMain.DisplayLayout.Bands[0].Columns["Vorname"].Header.VisiblePosition = 1;
            this.dgMain.DisplayLayout.Bands[0].Columns["Rechnungsempfaenger"].Header.VisiblePosition = 2;
            this.dgMain.DisplayLayout.Bands[0].Columns["FIBUKonto"].Header.VisiblePosition = 3;
            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Header.VisiblePosition = 4;
            this.dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].Header.VisiblePosition = 5;
            this.dgMain.DisplayLayout.Bands[0].Columns["GueltigBis"].Header.VisiblePosition = 6;
            this.dgMain.DisplayLayout.Bands[0].Columns["enumKostentraegerart"].Header.VisiblePosition = 7;
            this.dgMain.DisplayLayout.Bands[0].Columns["BetragErrechnetJN"].Header.VisiblePosition = 8;
            this.dgMain.DisplayLayout.Bands[0].Columns["Betrag"].Header.VisiblePosition = 9;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungJN"].Header.VisiblePosition = 10;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungTyp"].Header.VisiblePosition = 11;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungsdruckTyp"].Header.VisiblePosition = 12;
            this.dgMain.DisplayLayout.Bands[0].Columns["ErfasstAm"].Header.VisiblePosition = 13;
            this.dgMain.DisplayLayout.Bands[0].Columns["IDBenutzer"].Header.VisiblePosition = 14;

            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraeger"].Header.Caption = "Kostenträger";
            this.dgMain.DisplayLayout.Bands[0].Columns["Rechnungsempfaenger"].Header.Caption = "Rechnungsempfänger";
            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Header.Caption = "Rechnung an";
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungsdruckTyp"].Header.Caption = "Rechnungsdrucktyp";

            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraeger"].Width = 150;
            this.dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Width = 200;
            this.dgMain.DisplayLayout.Bands[0].Columns["Rechnungsempfaenger"].Width = 150;
            this.dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].Width = 80;
            this.dgMain.DisplayLayout.Bands[0].Columns["GueltigBis"].Width = 80;
            this.dgMain.DisplayLayout.Bands[0].Columns["BetragErrechnetJN"].Width = 80;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungTyp"].Width = 80;
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungsdruckTyp"].Width = 150;

            this.dgMain.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            Application.DoEvents();
            this.RefreshValueLists();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                RefreshControl();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        private void SetReadOnly()
        {
            btnAdd.Visible = !ReadOnly;
            btnDel.Visible = !ReadOnly;
            btnUpdate.Visible = !ReadOnly;
        }

        private void ShowHideColumns()
        {
            dgMain.DisplayLayout.Bands[0].Columns[_dt.enumKostentraegerartColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.BetragErrechnetJNColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.VorauszahlungJNColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.BetragColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.IDBenutzerColumn.ColumnName].Hidden = true;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.ErfasstAmColumn.ColumnName].Hidden = true;

            this.btnAddErwachsenenvertreter.Visible = !_TransferKostentraegerJN;
            this.btnAddKlient.Visible = !_TransferKostentraegerJN;
        }

        public bool ValidateFields()
        {
            //bool bError = false;

            //foreach (UltraGridRow row in dgMain.Rows)
            //{
            //    if (!ValidateField(row))
            //    {
            //        bError = true;
            //        break;
            //    }
            //}

            //return !bError;

            return true;
        }

        private bool ValidateField(UltraGridRow row)
        {
            //bool bError = false;

            //if (row == null || row.ListObject == null)
            //    return !bError;



            //DataRowView v = (DataRowView)row.ListObject;
            //dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)v.Row;

            //r.SetColumnError(_dt.GueltigAbColumn, "");
            //r.SetColumnError(_dt.GueltigBisColumn, "");

            //DateTime ab = r.GueltigAb;
            //DateTime bis = r.IsGueltigBisNull() ? abrech.GueltigBis : r.GueltigBis;
            //StringBuilder sb;
            //DateTime pBis;
            //foreach (dsPatientKostentraeger.PatientKostentraegerRow pr in _dt)
            //{
            //    if (pr.RowState == DataRowState.Deleted) continue;

            //    if (pr.ID == (Guid)row.Cells[_dt.IDColumn.ColumnName].Value) continue;

            //    pBis = pr.IsGueltigBisNull() ? abrech.GueltigBis : pr.GueltigBis;
            //    sb = new StringBuilder();

            //    if (pr.IDKostentraeger != r.IDKostentraeger)
            //    {
            //        if (r.enumKostentraegerart != (int)Kostentraegerart.Periodischeleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.Periodischeleistung &&
            //            r.enumKostentraegerart != (int)Kostentraegerart.Sonderleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.Sonderleistung &&
            //            r.enumKostentraegerart != (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung &&
            //            r.BetragErrechnetJN && pr.BetragErrechnetJN)
            //        {
            //            sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //            if (!r.IsGueltigBisNull())
            //                sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //            sb.Append(" existiert bereits ein Restzahler. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");
            //            GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //        }
            //    }
            //    else
            //    {
            //        if (r.enumKostentraegerart == (int)Kostentraegerart.Periodischeleistung ||
            //            r.enumKostentraegerart == (int)Kostentraegerart.Sonderleistung ||
            //            r.enumKostentraegerart == (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung
            //           )
            //        {
            //            if ((r.BetragErrechnetJN && !pr.BetragErrechnetJN) ||
            //                (!r.BetragErrechnetJN && pr.BetragErrechnetJN)
            //               )
            //            {
            //                sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //                if (!r.IsGueltigBisNull())
            //                    sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //                sb.Append(" existiert bereits der gleiche Kostenträger. Bitte entscheiden Sie zwichen Betragerrechnet oder Betrag.");

            //                GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //            }
            //        }
            //        else
            //        {
            //            sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //            if (!r.IsGueltigBisNull())
            //                sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //            sb.Append(" existiert bereits der gleiche Kostenträger. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");
            //            GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //        }
            //    }

            //    if (bError)
            //    {
            //        r.SetColumnError(_dt.GueltigAbColumn, sb.ToString());

            //        if(!r.IsGueltigBisNull())
            //            r.SetColumnError(_dt.GueltigBisColumn, sb.ToString());
            //        break;
            //    }
            //}

            //return !bError;

            return true;
        }

        private void RefreshValueLists()
        {
            try
            {
                dgMain.DisplayLayout.ValueLists.Clear();
                RefreshKostentraegerValueList();
                GuiTools.AddKostentraegerArtValueList(dgMain, "enumKostentraegerart");
                PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void RefreshKostentraegerValueList()
        {
            try
            {
                if (dgMain.DisplayLayout.ValueLists.Exists("KST"))
                    dgMain.DisplayLayout.ValueLists.Remove("KST");
                dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
                this.AddKostentraegerValueList(dgMain, dt.IDKostentraegerColumn.ColumnName);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public void AddKostentraegerValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("KST"))
                vl = vlc["KST"];
            else
            {
                vl = vlc.Add("KST");
                PMDS.DB.Global.DBKostentraeger k = new PMDS.DB.Global.DBKostentraeger();
                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Kostenträger wählen."));

                foreach (dsKostentraeger.KostentraegerRow r in k.Read(true, ENV.IDKlinik))
                    vl.ValueListItems.Add(r.ID, r.Name);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }

        private void RemoveSelected()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete("Wollen Sie diese Zuordnung(en) zum Kostenträger wirklich löschen?\n\nHinweis: Der Kostenträger wird dabei nicht gelöscht.\nUm auch den Kostenträger zu löschen, wechseln Sie zur Kostenträgerverwaltung.") != DialogResult.Yes)
                return;

            //dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            ArrayList al2 = new ArrayList();
            bool del = false;
            //PatientEinkommen pe = new PatientEinkommen();
            //dsPatientEinkommen.PatientEinkommenDataTable pedt = pe.Read(IDPatient, ENV.id);
            foreach (UltraGridRow r in ra)
            {
                r.Delete(false);
                del = true;
            }

            if (del)
            {
                _kost.Update(_dtErweitert);
                RefreshControl();

                //_DataChenged = true;

                //if (ValueChanged != null)
                //    ValueChanged(this, null);
            }

            if (dgMain.Rows.Count > 0)
            {
                dgMain.ActiveRow = dgMain.Rows[0];
                dgMain.ActiveRow.Selected = true;
            }
            else
            {
                dgMain.ActiveRow = null;
            }

        }

        private void AddElement(Guid IDKostentraeger, bool KlientIstZahler)
        {
            dsPatientKostentraeger.PatientKostentraegerRow r = _kost.New(_dt, _IDPatient, IDKostentraeger);
            Application.DoEvents();
            if (TransferKostentraegerJN)
                r.enumKostentraegerart = (int)Kostentraegerart.Transferleistung;

            if (dgMain.Rows.Count > 0)
                PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "IDKostentraeger");

            frmKostenträger frm = new frmKostenträger();
            frm.mainWindow = this;
            frm.ucPatientkostentraegerEdit1.ucKostenträger2.bKlientenzuordnung = true;
            frm.KlientIstZahler = KlientIstZahler;
            frm.ucPatientkostentraegerEdit1.neuanlage = true;
            frm.PatientKostentraegerRow = r;
            frm.KostentraegerDataTable = _dt;

            DialogResult res = frm.ShowDialog();

            RefreshKostentraegerValueList();

            if (res == DialogResult.OK)
            {
                _kost.Update(_dt);
                RefreshControl();
            }
            else
            {
                r.Delete();
                RefreshControl();
            }
        }
        private void UpdateElement()
        {
            if (dgMain.ActiveRow == null)
                return;

            dsPatientKostentraeger.PatientKostentraegerErweitertRow rErweitert = (dsPatientKostentraeger.PatientKostentraegerErweitertRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgMain);

            using (dsPatientKostentraeger.PatientKostentraegerDataTable dtTemp = new dsPatientKostentraeger.PatientKostentraegerDataTable())
            {
                dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)dtTemp.NewRow();

                if (!rErweitert.IsAbgerechnetBisNull()) r.AbgerechnetBis = rErweitert.AbgerechnetBis;
                r.Betrag = rErweitert.Betrag;
                r.BetragErrechnetJN = rErweitert.BetragErrechnetJN;
                r.enumKostentraegerart = rErweitert.enumKostentraegerart;
                if (!rErweitert.IsErfasstAmNull()) r.ErfasstAm = rErweitert.ErfasstAm;    
                r.GueltigAb = rErweitert.GueltigAb;
                if (!rErweitert.IsGueltigBisNull()) r.GueltigBis = rErweitert.GueltigBis;
                r.ID = rErweitert.ID;
                r.IDBenutzer = rErweitert.IDBenutzer;
                r.IDKostentraeger = rErweitert.IDKostentraeger;
                r.IDPatient = rErweitert.IDPatient;
                if (!rErweitert.IsIDPatientIstZahlerNull()) r.IDPatientIstZahler = rErweitert.IDPatientIstZahler;
                r.RechnungJN = rErweitert.RechnungJN;
                r.RechnungsdruckTyp = rErweitert.RechnungsdruckTyp;
                r.RechnungTyp = rErweitert.RechnungTyp;
                r.VorauszahlungJN = rErweitert.VorauszahlungJN;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rKostenträger = (from pk in db.PatientKostentraeger
                                         join k in db.Kostentraeger on pk.IDKostentraeger equals k.ID
                                         where pk.ID == r.ID && pk.IDPatient == this.IDPatient
                                         select new
                                         {
                                             k.ID,
                                             k.Name,
                                             pk.IDPatientIstZahler,
                                             IDPatientKostenträger = pk.ID,
                                             pk.IDPatient
                                         }).FirstOrDefault();

                    if (rKostenträger != null && rKostenträger.IDPatientIstZahler != null && rKostenträger.IDPatientIstZahler == this.IDPatient)
                    {
                        this.addEditKlientAsZahler(rKostenträger.IDPatient, rKostenträger.ID, rKostenträger.IDPatientKostenträger, false, false, false);
                    }

                    else if (rKostenträger != null)
                    {
                        this.addEditKlientAsZahler(rKostenträger.IDPatient, rKostenträger.ID, rKostenträger.IDPatientKostenträger, false, false, false);
                    }

                    else
                    {
                        using (frmKostenträger frm = new frmKostenträger())
                        {
                            frm.mainWindow = this;
                            frm.ucPatientkostentraegerEdit1.ucKostenträger2.bKlientenzuordnung = true;
                            frm.PatientKostentraegerRow = r;
                            frm.KostentraegerDataTable = _dt;

                            DialogResult res = frm.ShowDialog();
                            RefreshKostentraegerValueList();

                            if (res == DialogResult.OK)
                            {
                                _DataChenged = true;
                                //ValidateField(dgMain.ActiveRow);
                                if (ValueChanged != null)
                                    ValueChanged(this, null);
                            }
                        }
                    }
                }
            }
        }

        private void addEditKlientAsZahler(Guid IDPatient, Nullable<Guid> IDKostenträger, Nullable<Guid> IDPatientKostentraeger, bool IsNew, bool FSWMode, bool EVMode)
        {
            try
            {
                using (frmKostentraegerKlientEditSingle frmKostentraegerKlientEditSingle1 = new frmKostentraegerKlientEditSingle())
                {
                    frmKostentraegerKlientEditSingle1.initControl(IDPatient, IDKostenträger, IDPatientKostentraeger, IsNew, ucKostentraegerKlientEditSingle.eTypeUI.Klient, FSWMode, EVMode);
                    if (frmKostentraegerKlientEditSingle1.ucKostentraegerKlientEditSingle1._abortNoAufenthalt)
                    {
                        return;
                    }

                    frmKostentraegerKlientEditSingle1.ShowDialog(this);
                    if (!frmKostentraegerKlientEditSingle1.ucKostentraegerKlientEditSingle1.abort)
                    {
                        this.RefreshControl();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlient2.addEditKlientAsZahler: " + ex.ToString());
            }
        }              

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddElement(Guid.Empty, false);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;
            UpdateElement();
        }


        private void dgMain_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (ReadOnly) return;
                UpdateElement();
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlient2.dgMain_DoubleClick_1: " + ex.ToString());
            }
        }
        private void dgMain_BeforeRowsDeleted_1(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

        private void btnAddKlient_Click(object sender, EventArgs e)
        {
            try
            {
                this.addEditKlientAsZahler(this.IDPatient, null, null, true, false, false);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnAddFSW_Click(object sender, EventArgs e)
        {
            try
            {
                this.addEditKlientAsZahler(this.IDPatient, null, null, true, true, false);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnAddErwachsenenvertreter_Click(object sender, EventArgs e)
        {
            try
            {
                this.addEditKlientAsZahler(this.IDPatient, null, null, true, false, true);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void dgMain_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Activation = Activation.NoEdit;
        }
    }
}
