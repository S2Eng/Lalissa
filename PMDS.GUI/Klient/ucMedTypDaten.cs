using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.Klient;
using PMDS.BusinessLogic;
using PMDS.GUI.Klient;
using PMDS.DB;
using System.Linq;
using PMDS.GUI.ELGA;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI
{
    public partial class ucMedTypDaten : QS2.Desktop.ControlManagment.BaseControl
    {
        private PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow _MedizinischeDatenLayoutRow;
        private dsMedizinischeDaten _dsMedizinischeDaten;
        private bool _readOnly = false;
        private MedizinischerTyp _medTyp;
        public event EventHandler ValueChanged;
        public event MedizinischeDatenStateChangedDelegate MedizinischerStateChanged;
        public event AddMedizinischeDatenDelegate AddMedizinischeDaten;
        public event EndMedizinischeDatenDelegate EndMedizinischeDaten;
        public event UpdateMedizinischeDatenDelegate UpdateMedizinischeDaten;
        public event DeleteMedizinischeDatenDelegate DeleteMedizinischeDaten;

        public delegate void AddMedizinischeDatenDelegate(MedDatenArgs args);
        public delegate void EndMedizinischeDatenDelegate(MedDatenArgs args);
        public delegate void UpdateMedizinischeDatenDelegate(MedDatenArgs args);
        public delegate void DeleteMedizinischeDatenDelegate(MedDatenArgs[] args);

        public bool IsInitialiyed = false;

        public System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy> lstPatienteSelected = new List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy>();

        public PMDS.GUI.ucMedizinischeDaten _mainWindow = null;
        public  PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new Global.db.ERSystem.PMDSBusinessUI();

        public string colBenutzerGeändert = "BenutzerGeändert";

        public ELGABusiness bELGA = new ELGABusiness();







        public ucMedTypDaten(ucMedizinischeDaten mainWindow)
        {
            InitializeComponent();

            this._mainWindow = mainWindow;
            //this.grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.btnMedikamente.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Medikamente_01, QS2.Resources.getRes.ePicTyp.ico);
            this.btnVOErfassen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verordnungen_03, QS2.Resources.getRes.ePicTyp.ico);
            this.btnSearchELGADocuments.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, QS2.Resources.getRes.ePicTyp.ico);
            this.btnVOErfassen.Visible = PMDS.Global.ENV.lic_VO;
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow MedizinischeDatenLayoutRow
        {
            get { return _MedizinischeDatenLayoutRow; }
            set 
            { 
                _MedizinischeDatenLayoutRow = value;

                if(_MedizinischeDatenLayoutRow != null)
                    _medTyp = (MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), _MedizinischeDatenLayoutRow.MedizinischerTyp.ToString(), true);
                InitializeLayout();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsMedizinischeDaten MEDIZINISCHEDATEN
        {
            get { return _dsMedizinischeDaten; }
        }
        public void loadMEDIZINISCHEDATEN(dsMedizinischeDaten ds, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            _dsMedizinischeDaten = ds;
            UpdateGUI(db);
        }
        public void UpdateGUI(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            this.lstPatienteSelected.Clear();
            db.Configuration.LazyLoadingEnabled = false;

            if (!_dsMedizinischeDaten.MedizinischeDaten.Columns.Contains(this.colBenutzerGeändert))
            {
                _dsMedizinischeDaten.MedizinischeDaten.Columns.Add(this.colBenutzerGeändert, typeof(string));
            }

            //Benuzernamen zu Med.Daten IDBenutzergeändert (für Grid-Anzeige) 
            DataTable medDaten = _dsMedizinischeDaten.MedizinischeDaten;
            var md_ex3 = medDaten.AsEnumerable().
                Select(md => new
                {
                    ID = md.Field<Guid>("ID"),
                    IDBenutzerGeaendert = md.Field<Guid?>("IdBenutzergeaendert")
                });

            //left outer join auf Benutzer (einmal pro med.Typ statt vorher pro Eintrag in Med Daten)
            var md_ex0 = from md in md_ex3
                        join ben in db.Benutzer on md.IDBenutzerGeaendert equals ben.ID
                        into md_ben
                        from bg in md_ben.DefaultIfEmpty()
                        select new
                        {
                            md.ID,
                            Nachname = bg?.Nachname ?? "",
                            Vorname = bg?.Vorname ?? "",
                            Benutzer1 = bg?.Benutzer1 ?? ""
                        };

            foreach (dsMedizinischeDaten.MedizinischeDatenRow rMedDaten in _dsMedizinischeDaten.MedizinischeDaten)
            {
                rMedDaten[this.colBenutzerGeändert] = "";

                if (!rMedDaten.IsIDBenutzergeaendertNull())
                {
                    var rUser = (from ben in md_ex0
                                 where ben.ID == rMedDaten.ID
                                 select new { ben.Nachname, ben.Vorname, ben.Benutzer1 }).First();

                    rMedDaten[this.colBenutzerGeändert] = rUser.Nachname.Trim() + " " + rUser.Vorname.Trim() + " (" + rUser.Benutzer1 + ")";
                }
            }

            grid.DataSource = _dsMedizinischeDaten;
            grid.Refresh();

            //this.initControl();
            //foreach (UltraGridRow rGridRow in grid.Rows)
            //{
            //    DataRowView v = (DataRowView)rGridRow.ListObject;
            //    dsMedizinischeDaten.MedizinischeDatenRow rMedDaten = (dsMedizinischeDaten.MedizinischeDatenRow)v.Row;

            //    string sInfoVO = this.b3.getInfoVO(rMedDaten.ID, db);
            //    rGridRow.Cells["Verordnungen"].Value = sInfoVO;

            //    if (!rMedDaten.IsIDBenutzergeaendertNull())
            //    {
            //        var rUser = (from b in db.Benutzer
            //                    where b.ID == rMedDaten.IDBenutzergeaendert
            //                    select new { b.ID, b.Nachname, b.Vorname, b.Benutzer1 }).First();

            //        rGridRow.Cells[this.colBenutzerGeändert].Value = rUser.Nachname.Trim() + " " + rUser.Vorname.Trim() + " (" + rUser.Benutzer1.Trim() + ")";
            //    }
            //    else
            //    {
            //        rGridRow.Cells[this.colBenutzerGeändert].Value = "";
            //    }
            //} 
        }



        private void SetReadOnly()
        {
            btnAdd.Enabled = !ReadOnly;
            btnDel.Enabled = !ReadOnly;
            btnEnd.Enabled = !ReadOnly;
            btnUpdate.Enabled = !ReadOnly;
        }
        

        private bool Einschalten()
        {
            try
            {
                Guid NewIDMedDaten = Guid.NewGuid();

                frmMedizinDaten frm = new frmMedizinDaten(State.On, _medTyp, _MedizinischeDatenLayoutRow.Bezeichnung, _MedizinischeDatenLayoutRow);
                frm.BEGINN = DateTime.Now;
                frm.IDMedDaten = NewIDMedDaten;

                frm.btnKlientenMehrfachauswahl.Visible = true;
                DialogResult res = frm.ShowDialog();
                if (res != DialogResult.OK)
                {
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.b.CopyMedDatenToERRowAndSave(NewIDMedDaten, (int)_medTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG, frm.BEENDIGUNGSGRUND,
                                                        frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG, frm.MODELL, frm.HANDLING,
                                                        frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE, frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, ENV.CurrentIDPatient, db, true);
                }

                MedDatenArgs arg = new MedDatenArgs(NewIDMedDaten, (int)_medTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG, frm.BEENDIGUNGSGRUND,
                      frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG, frm.MODELL, frm.HANDLING,
                      frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE, frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, "", 0);

                if (AddMedizinischeDaten != null)
                {
                    ucMedizinischeDaten.IDMedDatenNew = NewIDMedDaten;
                    AddMedizinischeDaten(arg);
                    ucMedizinischeDaten.IDMedDatenNew = null;
                    this.copyMehrfachauswahl(ref NewIDMedDaten, ENV.CurrentIDPatient, ref frm.lstPatienteSelected);
                    this.UpdateMehrfachauswahlPatienten();
                    this.lstPatienteSelected.Clear();
                }
                else
                {
                    return false;
                }

                ucMedizinischeDaten.IDMedDatenNew = null;
                ENV.SignalMedizinDatenChanged();
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    this.UpdateGUI(db);
                }

                return true;
            }
            catch (Exception ex)
            {
                ucMedizinischeDaten.IDMedDatenNew = null;
                throw new Exception("ucMedTypDaten.Einschalten: " + ex.ToString());
            }
        }

        private bool Ausschalten()
        {
            dsMedizinischeDaten.MedizinischeDatenRow row = (dsMedizinischeDaten.MedizinischeDatenRow)UltraGridTools.CurrentSelectedRow(grid);
            if (row != null)
            {
                frmMedizinDaten frm = new frmMedizinDaten(State.Off, _medTyp, _MedizinischeDatenLayoutRow.Bezeichnung, _MedizinischeDatenLayoutRow);
                frm.MED_DATEN_ROW = row;
                frm.IDMedDaten = row.ID;
                frm.btnKlientenMehrfachauswahl.Visible = false;
                DialogResult res = frm.ShowDialog();
                if (res != DialogResult.OK)
                    return false;

                Guid IDMedDatenOrig = row.ID;
                Guid IDPatientOrig = row.IDPatient;

                MedDatenArgs arg = new MedDatenArgs(row.ID, (int)_medTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG, frm.BEENDIGUNGSGRUND,
                                  frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG, frm.MODELL, frm.HANDLING,
                                  frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE, frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, row.lstRezepteinträge, row.NumberRezepteinträge);

                //this.copyMehrfachauswahl(ref IDMedDatenOrig, IDPatientOrig, ref frm.lstPatienteSelected2);

                if (EndMedizinischeDaten != null)
                {
                    EndMedizinischeDaten(arg);

                    if (!arg.Bis.Equals(DateTime.MinValue))
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.b2.checkMedDatenAbgesetzt2(arg.ID, db, ENV.CurrentIDPatient, 1);
                        }
                    }
                }
                else
                {
                    return false;
                }

                ENV.SignalMedizinDatenChanged();
                return true;
            }
            return false;
        }

        private bool UpdateDaten()
        {
            try
            {
                dsMedizinischeDaten.MedizinischeDatenRow row = (dsMedizinischeDaten.MedizinischeDatenRow)UltraGridTools.CurrentSelectedRow(grid);

                if (row != null)
                {
                    this.lstPatienteSelected.Clear();

                    frmMedizinDaten frm = new frmMedizinDaten(State.Update, _medTyp, _MedizinischeDatenLayoutRow.Bezeichnung, _MedizinischeDatenLayoutRow);
                    frm.btnKlientenMehrfachauswahl.Visible = true;
                    frm.AllowEdit(ENV.HasRight(UserRights.RezepteVerwalten));
                    frm.MED_DATEN_ROW = row;
                    frm.IDMedDaten = row.ID;
                    frm.btnOK.ContextMenuStrip = null;
                    DialogResult res = frm.ShowDialog();
                    if (res != DialogResult.OK)
                    {
                        return false;
                    }

                    Guid IDMedDatenOrig = row.ID;
                    Guid IDPatientOrig = row.IDPatient;

                    PMDSBusiness b = new PMDSBusiness();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        b.CopyMedDatenToERRowAndSave(row.ID, row.MedizinischerTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG, frm.BEENDIGUNGSGRUND,
                                                            frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG, frm.MODELL, frm.HANDLING,
                                                            frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE, frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, ENV.CurrentIDPatient, db, false);
                    }

                    MedDatenArgs arg = new MedDatenArgs(row.ID, (int)_medTyp, frm.BEGINN, frm.ENDE, frm.BESCHREIBUNG, frm.BEMERKUNG,
                                               frm.BEENDIGUNGSGRUND, frm.LETZTE_VERSORGUNG, frm.NAECHSTE_VERSORGUNG,
                                               frm.MODELL, frm.HANDLING, frm.THERAPIE, frm.ICDCode, frm.AUFNAHMEDIAGNOSE,
                                               frm.ANTIKOAGULIERT, frm.TYP, frm.ANZAHL, frm.NUECHTERN, frm.GROESSE, row.lstRezepteinträge, row.NumberRezepteinträge);


                    ucMedizinischeDaten.IDMedDatenNew = null;
                    //ENV.SignalMedizinDatenChanged();
                    //this.UpdateGUI();

                    this.copyMehrfachauswahl(ref IDMedDatenOrig, IDPatientOrig, ref frm.lstPatienteSelected);

                    if (UpdateMedizinischeDaten != null)
                        UpdateMedizinischeDaten(arg);

                    if (!arg.Bis.Equals(DateTime.MinValue))
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.b2.checkMedDatenAbgesetzt2(arg.ID, db, IDPatientOrig, 1);
                        }
                    }

                    //ENV.SignalMedizinDatenChanged();
                    //this.UpdateGUI();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("UpdateDaten: " + ex.ToString());
            }
        }

        public void copyMehrfachauswahl(ref Guid IDMedDatenOrig, Guid IDPatientOrig, 
                                            ref System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy> lstPatienteSelected2)
        {
            try
            {
                foreach (PMDS.DB.PMDSBusiness.cMedTypDatenCopy MedTypDatenCopyAct in lstPatienteSelected2)
                {
                    PMDS.DB.PMDSBusiness.cMedTypDatenCopy newMedTypDatenCopy = new PMDS.DB.PMDSBusiness.cMedTypDatenCopy();
                    newMedTypDatenCopy.SelectedNodes = MedTypDatenCopyAct.SelectedNodes;
                    newMedTypDatenCopy.IDMedDatenOrig2 = IDMedDatenOrig;
                    newMedTypDatenCopy.IDPatientOrig2 = IDPatientOrig;
            
                    this.lstPatienteSelected.Add(newMedTypDatenCopy);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("copyMehrfachauswahl: " + ex.ToString());
            }
        }
        public void UpdateMehrfachauswahlPatienten()
        {
            try
            {
                if (this.lstPatienteSelected.Count > 0)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        PMDSBusiness1.CopyAndAddMedTypDaten(ref this.lstPatienteSelected, db);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UpdateMehrfachauswahlPatienten: " + ex.ToString());
            }
        }

        public void initControlxz()
        {
            if (!this.IsInitialiyed)
            {
                this.alleZeilenEinerZelleKopierenToolStripMenuItem.Click += new System.EventHandler(this.alleZeilenEinerZelleKopierenToolStripMenuItem_Click);
                this.contextMenuStrip1.Items.Add(this.alleZeilenEinerZelleKopierenToolStripMenuItem);

                IsInitialiyed = true;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Löscht Daetensätze
        /// </summary>
        //----------------------------------------------------------------------------
        private bool DeleteDaten(bool bZuordnungMedDatenExists)
        {
            dsMedizinischeDaten.MedizinischeDatenRow[] rows = CurrentSelectedRows();
            if (rows != null && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                DialogResult res;
                if (rows.Length > 1)
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                else
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    List<MedDatenArgs> list = new List<MedDatenArgs>();
                    MedDatenArgs arg;
                    foreach (dsMedizinischeDaten.MedizinischeDatenRow r in rows)
                    {
                        if (this.b2.checkDeleteMedDatenRezeptEinträgeExists(r.ID))
                        {
                            bZuordnungMedDatenExists = true;
                        }

                        arg = new MedDatenArgs();
                        arg.ID = r.ID;
                        arg.MedTyp = (int)_medTyp;
                        list.Add(arg);
                        r.AcceptChanges();
                    }

                    if (bZuordnungMedDatenExists)
                    {
                        if (!this.b2.showMsgBoxDeleteMedDatenRezeptEinträgeExists())
                        {
                            return false;
                        }
                    }
                    
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        foreach (MedDatenArgs rMedDatenArg in list)
                        {
                            this.b.DeleteMedDatenRezeptEintragsZuordnungen(rMedDatenArg.ID, db);
                            this.b.DeleteMedizinischeDaten(rMedDatenArg.ID, db);
                        }
                    }

                    DeleteMedizinischeDaten(list.ToArray());
                    ENV.SignalMedizinDatenChanged();
                    return true;
                }
            }

            return false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Row ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsMedizinischeDaten.MedizinischeDatenRow[] CurrentSelectedRows()
        {
            dsMedizinischeDaten.MedizinischeDatenRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in grid.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsMedizinischeDaten.MedizinischeDatenRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsMedizinischeDaten.MedizinischeDatenRow)v.Row;
                    i++;
                }

            }

            return list;
        }

        private void InitializeLayout()
        {
            if (_MedizinischeDatenLayoutRow == null)
                return;

            grpBox.Text = _MedizinischeDatenLayoutRow.Bezeichnung;

            if (_MedizinischeDatenLayoutRow.MedizinischerTyp == (int)MedizinischerTyp.Impfungen)
            {
                btnEnd.Visible = false;
                btnDel.Visible = true;
                btnDel.Location = btnEnd.Location;
            }
            else
            {
                btnEnd.Visible = true;
                btnDel.Visible = false;
            }

            InitializeGridLayout();
        }

        private void InitializeGridLayout()
        {
            grid.DisplayLayout.Bands[0].Columns["Beschreibung"].Hidden = _MedizinischeDatenLayoutRow.IsBeschreibungNull();
            grid.DisplayLayout.Bands[0].Columns["Bemerkung"].Hidden = _MedizinischeDatenLayoutRow.IsBemerkungNull();
            grid.DisplayLayout.Bands[0].Columns["Beendigungsgrund"].Hidden = _MedizinischeDatenLayoutRow.IsBeendigungsgrundNull();
            grid.DisplayLayout.Bands[0].Columns["Therapie"].Hidden = _MedizinischeDatenLayoutRow.IsTherapieNull();
            grid.DisplayLayout.Bands[0].Columns["Typ"].Hidden = _MedizinischeDatenLayoutRow.IsTypNull();

            if (!_MedizinischeDatenLayoutRow.IsBeschreibungNull())
                grid.DisplayLayout.Bands[0].Columns["Beschreibung"].RowLayoutColumnInfo.OriginX = 2 + 2 * _MedizinischeDatenLayoutRow.Beschreibung;

            if (!_MedizinischeDatenLayoutRow.IsBemerkungNull())
                grid.DisplayLayout.Bands[0].Columns["Bemerkung"].RowLayoutColumnInfo.OriginX = 2 + 2 * _MedizinischeDatenLayoutRow.Bemerkung;

            if (!_MedizinischeDatenLayoutRow.IsBeendigungsgrundNull())
                grid.DisplayLayout.Bands[0].Columns["Beendigungsgrund"].RowLayoutColumnInfo.OriginX = 2 + 2 * _MedizinischeDatenLayoutRow.Beendigungsgrund;

            if (!_MedizinischeDatenLayoutRow.IsTherapieNull())
                grid.DisplayLayout.Bands[0].Columns["Therapie"].RowLayoutColumnInfo.OriginX = 2 + 2 * _MedizinischeDatenLayoutRow.Therapie;

            if (!_MedizinischeDatenLayoutRow.IsTypNull())
                grid.DisplayLayout.Bands[0].Columns["Typ"].RowLayoutColumnInfo.OriginX = 2 + 2 * _MedizinischeDatenLayoutRow.Typ;
        }

        private void grid_AfterRowActivate(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                dsMedizinischeDaten.MedizinischeDatenRow row = (dsMedizinischeDaten.MedizinischeDatenRow)UltraGridTools.CurrentSelectedRow(grid);

                if (row != null)
                {
                    if (!row.IsBisNull())
                    {
                        btnEnd.Enabled = false;
                        btnDel.Enabled = false;
                    }
                    else
                    {
                        btnEnd.Enabled = true;
                        btnDel.Enabled = true;
                    }
                }
            }
        }

        private void grid_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (!ReadOnly)
            {
                if (UpdateDaten())
                {
                    //if (ValueChanged != null)
                    //    ValueChanged(sender, e);

                    //this.UpdateGUI();

                    if (MedizinischerStateChanged != null)
                        MedizinischerStateChanged((int)_medTyp);

                    this._mainWindow.mainWindow.MainWindow.btnSave2.Enabled = false;
                    this._mainWindow.mainWindow.MainWindow.btnundo2.Enabled = false;
                    this._mainWindow.mainWindow.MainWindow.Undo();

                }
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly)
            {
                bool bZuordnungMedDatenExists = false;
                if (DeleteDaten(bZuordnungMedDatenExists))
                {
                    if (ValueChanged != null)
                        ValueChanged(sender, e);
                    if (MedizinischerStateChanged != null)
                        MedizinischerStateChanged((int)_medTyp);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Einschalten())
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    this.UpdateGUI(db);
                }

                //if (ValueChanged != null)
                //    ValueChanged(sender, e);
                //if (MedizinischerStateChanged != null)
                //    MedizinischerStateChanged((int)_medTyp);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (Ausschalten())
            {
                if (ValueChanged != null)
                    ValueChanged(sender, e);
                if (MedizinischerStateChanged != null)
                    MedizinischerStateChanged((int)_medTyp);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDaten())
            {
                if (ValueChanged != null)
                    ValueChanged(sender, e);
                if (MedizinischerStateChanged != null)
                    MedizinischerStateChanged((int)_medTyp);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool bZuordnungMedDatenExists = false;
            if (DeleteDaten(bZuordnungMedDatenExists))
            {
                //if (ValueChanged != null)
                //    ValueChanged(sender, e);
                //if (MedizinischerStateChanged != null)
                //    MedizinischerStateChanged((int)_medTyp);
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            this.panelButtons.Height   = bOn ? 0 : 24;

            this.btnAdd.Visible = !bOn;
            this.btnDel.Visible = !bOn;
            this.btnEnd.Visible = !bOn;
            this.btnUpdate.Visible = !bOn;
        }

        private void grpBox_Click(object sender, EventArgs e)
        {

        }
        private void alleZeilenEinerZelleKopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ucMedTypDaten_VisibleChanged(object sender, EventArgs e)
        {
            this.initControlxz();
        }

        private void btnMedikamente_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsMedizinischeDaten.MedizinischeDatenRow rSelRow = this.getSelectedRow(true, ref gridRow);
                if (rSelRow != null)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rSelRow.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.MedDaten2);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        string lstRezepteinträge = "";
                        int NumberRezepteinträge = 0;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.b2.saveAnzeigeGridMedDaten(rSelRow.ID, db, ref lstRezepteinträge, ref NumberRezepteinträge);
                            db.SaveChanges();

                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == rSelRow.ID && o.IDRezepteintrag != null && o.IDVerordnung == null);
                            if (tRezeptEintragMedDaten.Count() > 0)
                            {
                                foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                                {
                                    string lstMedDaten = "";
                                    int NumberMedDaten = 0;
                                    string lstWunden = "";
                                    int NumberWunden = 0;
                                    this.b2.saveAnzeigeGridRezeptEintrag(rRezeptEintragMedDaten2.IDRezepteintrag.Value, db,ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                                }
                                db.SaveChanges();
                            }
                        }

                        rSelRow.lstRezepteinträge = lstRezepteinträge;
                        rSelRow.NumberRezepteinträge = NumberRezepteinträge;
                        this.grid.Refresh();

                        if (!rSelRow.IsBisNull())
                        {
                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                            {
                                this.b2.checkMedDatenAbgesetzt2(null, db, ENV.CurrentIDPatient, 0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public dsMedizinischeDaten.MedizinischeDatenRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.grid.ActiveRow != null)
                {
                    if (this.grid.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.grid.ActiveRow.ListObject;
                        dsMedizinischeDaten.MedizinischeDatenRow rSelRow = (dsMedizinischeDaten.MedizinischeDatenRow)v.Row;
                        gridRow = this.grid.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedTypDaten.getSelectedRow: " + ex.ToString());
            }
        }

        private void btnVOErfassen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsMedizinischeDaten.MedizinischeDatenRow rSelRow = this.getSelectedRow(true, ref gridRow);
                if (rSelRow != null)
                {
                    Guid IDAufenthaltTmp;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(ENV.CurrentIDPatient, false, db);
                        IDAufenthaltTmp = rAufenthalt.ID;
                    }
                    
                    PMDS.GUI.Verordnungen.frmVOErfassen frmVOErfassen1 = new Verordnungen.frmVOErfassen();
                    frmVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten, true, false, null);
                    frmVOErfassen1.ucVOErfassen1.search2(IDAufenthaltTmp, null, rSelRow.ID, null);
                    frmVOErfassen1.ShowDialog(this);
                    //if (!frmVOErfassen1.ucVOErfassen1.abort)
                    //{
                        DataRowView v = (DataRowView)gridRow.ListObject;
                        dsMedizinischeDaten.MedizinischeDatenRow rMedDaten = (dsMedizinischeDaten.MedizinischeDatenRow)v.Row;

                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        string sInfoVO = this.b3.getInfoVO(rMedDaten.ID, db);
                        gridRow.Cells["Verordnungen"].Value = sInfoVO;
                    }

                    //}
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSearchELGADocuments_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }

                frmELGASearchDocuments frmELGASearchDocuments1 = new frmELGASearchDocuments();
                frmELGASearchDocuments1.initControl(ENV.CurrentIDPatient);
                frmELGASearchDocuments1.ShowDialog();
                if (!frmELGASearchDocuments1.contELGASearchDocuments1.abort)
                {
                    this.bELGA.saveELGADocuToArchive(ref frmELGASearchDocuments1.contELGASearchDocuments1.lDocusSelected);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
