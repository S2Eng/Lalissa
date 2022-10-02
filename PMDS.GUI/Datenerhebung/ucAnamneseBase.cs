using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinTabControl;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Klient;
using Infragistics.Win.UltraWinToolTip;
using PMDS.DB;

namespace PMDS.GUI
{
    public partial class ucAnamneseBase : QS2.Desktop.ControlManagment.BaseControl, IAnamnese
    {
        private PflegeModelle _modell = PflegeModelle.Krohwinkel;
        private Guid _idPatient = Guid.Empty;
        private string _entryText = "";
        private bool _valueChangeEnabled = true;
        protected bool _loaded = false;
        protected bool _dataChanged = false;
        private int _anamneseAblauf = -1;
        private Modus _modus = Modus.Bearbeiten;
        public event DataChangedDelegate DataChanged;

        private bool _readOnly = false;
        private bool _DatenerhebungDrucken = true;
        private bool _DatenerhebungLoeschen = true;
        private DataRow _AnamneseRow;

        protected List<ucAnamneseModellgruppeBase> ListModellgruppenControl = new List<ucAnamneseModellgruppeBase>();
        protected IAnamneseObject AnamneseObject;
        //protected KlientDetails Klient;

        public bool _IsInitialized = false;
        
        public PMDSBusiness b = new PMDSBusiness();











        public ucAnamneseBase()
        {
            InitializeComponent();

            this.btnCopy.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegemodell setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public PflegeModelle Modell
        {
            get { return _modell; }
            set { _modell = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Guid IDPatient
        {
            get { return _idPatient; }
            set
            {
                _idPatient = value;

                if (AnamneseObject == null)
                    throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

                if (!this._IsInitialized)
                {
                    this.btnCopy.Visible = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.AnamnesenVorlagenVerwenden);

                    UltraToolTipInfo info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese kopieren");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnCopy, info);
                    
                    this._IsInitialized = true;
                }

                AnamneseObject.IDPatient = value;

                //if(Modell == PflegeModelle.Krohwinkel)
                //    Klient = new KlientDetails(value, Settings.IDAUFENTHALT);
                _valueChangeEnabled = false;
                _AnamneseRow = null;
                SetPDX();
                UpdateGUI();
                _valueChangeEnabled = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Text der Anamnese setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EntyText
        {
            get { return _entryText; }
            set { _entryText = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                btnNew.Enabled = !_readOnly;
                btnDelete.Enabled = !_readOnly;
                SetReadOnly(_readOnly);

                if (_readOnly)
                    UpdateInfoText();
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenerhebungDrucken setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DatenerhebungDrucken
        {
            get { return _DatenerhebungDrucken; }
            set
            {
                _DatenerhebungDrucken = value;
                btnPrint.Enabled = _DatenerhebungDrucken;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenerhebungLoeschen setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DatenerhebungLoeschen
        {
            get { return _DatenerhebungLoeschen; }
            set
            {
                _DatenerhebungLoeschen = value;
                btnDelete.Enabled = _DatenerhebungLoeschen;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AnamneseRow setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRow AnamneseRow
        {
            get { return _AnamneseRow; }
            set
            {
                if (AnamneseObject == null)
                    throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");
                _AnamneseRow = value;
                _valueChangeEnabled = false;

                if (_AnamneseRow != null)
                {
                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(_AnamneseRow["ErstelltAm"]);

                    if (!ReadOnly)
                        SetReadOnly(ts.TotalHours > _anamneseAblauf);
                }
                else
                {
                    SetReadOnly(true);
                }

                SetAnamneseRow();
                SetAnamnmese();

                if (_AnamneseRow != null)
                {
                    cmbPfleger.Value = AnamneseObject.GetIDBenutzer(new Guid(_AnamneseRow["ID"].ToString()));
                    dtpErstelltAm.Value = _AnamneseRow["ErstelltAm"];
                }
                else
                    cmbPfleger.Value = null;

                UpdateButtons();
                _valueChangeEnabled = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// true wenns was zu sichern gibt
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual bool ISTOSAVE
        {
            get
            {
                return _dataChanged == true;
            }
            set
            {
            }
        }

        private void SetReadOnly(bool readOnly)
        {
            cmbPfleger.ReadOnly = readOnly;
            dtpErstelltAm.ReadOnly = readOnly;

            foreach (ucAnamneseModellgruppeBase uc in ListModellgruppenControl)
            {
                uc.ReadOnly = readOnly;
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AnamneseRow für alle Kontrols setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetAnamneseRow()
        {
            foreach (ucAnamneseModellgruppeBase uc in ListModellgruppenControl)
            {
                uc.AnamneseRow = AnamneseRow;
            }
        }

        private void SetAnamnmese()
        {
            foreach (ucAnamneseModellgruppeBase uc in ListModellgruppenControl)
            {
                uc.PDXAnamnese = AnamneseObject.PDXAnamnese;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Pflegedefinitionen die zu Krohwinkel zugeordnet sind und PDXAnamnese
        /// für alle Kontrols setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetPDX()
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            foreach (ucAnamneseModellgruppeBase uc in ListModellgruppenControl)
            {
                uc.PDXTable = (dsPDXByPflegeModell.PDXPflegeModellDataTable)AnamneseObject.PDXByPflegeModell;
            }
        }

        //
        //lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        public void UpdateGUI()
        {
            InitErrorProvider();

            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            if (_anamneseAblauf == -1)
            {
                string sTemp = RBU.Log.LOG.ConfigFile["ANAMNESE_ABLAUF"];
                if (sTemp == null)
                    _anamneseAblauf = 72;
                else
                    _anamneseAblauf = (int)RBU.Log.LOG.ConfigFile.GetDoubleValue("ANAMNESE_ABLAUF");
            }

            InitPflegerCombo();
            InitErstelltAmCombo();
            cmbPfleger.Value = null;

            if (_modus == Modus.Bearbeiten && AnamneseRow != null)
            {
                cmbErstelltAm.Value = AnamneseRow["ID"];
            }
            else if (AnamneseObject.AnamneseDataTable.Rows.Count > 0)
            {
                Guid idAnamnese = new Guid(AnamneseObject.AnamneseDataTable.Rows[0]["ID"].ToString());
                cmbErstelltAm.Value = idAnamnese;
                AnamneseRow = AnamneseObject.GetAnamneseRow(idAnamnese);
            }

            UpdateButtons();

            this.btnCopy.Left = this.btnPrint.Left - this.btnCopy.Width - 10;
        }

        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public virtual void UpdateDATA()
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            AnamneseObject.UpdateDATA(new Guid(AnamneseRow["ID"].ToString()), (DateTime)dtpErstelltAm.Value, new Guid(cmbPfleger.Value.ToString()));

            foreach (ucAnamneseModellgruppeBase uc in ListModellgruppenControl)
            {
                uc.EndCurrentEdits();
            }

            //if (Klient != null && Modell == PflegeModelle.Krohwinkel)
            //{
            //    //Sterberegelung des Patienten aus der Betreuung in der Sterbephase übernehmen(13. Mit existentiellen Erfahrungen des lebens umgehen).
            //    if (AnamneseRow["SterbephaseBetreuung"] != DBNull.Value)
            //        Klient.SterbeRegel = AnamneseRow["SterbephaseBetreuung"].ToString().Trim();
            //    else
            //        Klient.SterbeRegel = "";
            //}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten schreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void Write()
        {
            AnamneseObject.Write();

            //if (Klient != null)
            //    Klient.Write(false, false, false );
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public virtual bool ValidateFields()
        {
            bool bError = false;

            InitErrorProvider();

            if (((DateTime)dtpErstelltAm.Value) > DateTime.Now)
            {
                bError = true;
                string error = "Das Erstellungsdatum darf nicht in der Zukunft liegen.";
                errorProvider1.SetError(dtpErstelltAm, error);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(error);
            }
            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten speichern
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void Save()
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            if (!ValidateFields())
                return;

            if (AnamneseRow != null && AnamneseRow.RowState != DataRowState.Deleted)
            {
                UpdateDATA();
            }
            Write();
            _dataChanged = false;
            AnamneseObject.Refresh();

            //if(Modell == PflegeModelle.Krohwinkel)
            //    Klient = new KlientDetails(IDPatient, Settings.IDAUFENTHALT);

            SetPDX();
            InitErstelltAmCombo();

            if (AnamneseRow != null)
                cmbErstelltAm.Value = AnamneseRow["ID"];

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            UpdateButtons();
            dtpErstelltAm.Visible = false;
            cmbErstelltAm.Visible = true;
            cmbErstelltAm.Enabled = true;
            _modus = Modus.Bearbeiten;

            if (DataChanged != null)
                DataChanged(false);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void Undo()
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            _dataChanged = false;
            AnamneseObject.Refresh();

            //if (Modell == PflegeModelle.Krohwinkel)
            //    Klient = new KlientDetails(IDPatient, Settings.IDAUFENTHALT);

            _valueChangeEnabled = false;
            SetPDX();
            UpdateGUI();
            _valueChangeEnabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            UpdateButtons();
            dtpErstelltAm.Visible = false;
            cmbErstelltAm.Visible = true;
            cmbErstelltAm.Enabled = true;

            if (DataChanged != null)
                DataChanged(false);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Datensatz löschen
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void Delete()
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            //Wenn JA Datensatz aus der DB löschen und GUI Aktualsieren
            AnamneseRow.Delete();
            Write();
            AnamneseObject.Refresh();

            //if (Modell == PflegeModelle.Krohwinkel)
            //    Klient = new KlientDetails(IDPatient, Settings.IDAUFENTHALT);

            SetPDX();
            InitErstelltAmCombo();

            if (cmbErstelltAm.Items.Count > 0)
            {
                cmbErstelltAm.Value = cmbErstelltAm.Items[0].DataValue;

                Guid id = new Guid(cmbErstelltAm.Value.ToString());
                AnamneseRow = AnamneseObject.GetAnamneseRow(id);

                if (AnamneseRow != null)
                    cmbPfleger.Value = AnamneseObject.GetIDBenutzer(new Guid(AnamneseRow["ID"].ToString()));
            }
            else
            {
                AnamneseRow = null;
                cmbErstelltAm.Value = null;
                cmbPfleger.Value = null;
            }

            if (!ReadOnly)
                btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            UpdateButtons();
            dtpErstelltAm.Visible = false;
            cmbErstelltAm.Visible = true;
            cmbErstelltAm.Enabled = true;
            _modus = Modus.Bearbeiten;
            _dataChanged = false;

            if (DataChanged != null)
                DataChanged(false);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ErrorProvider initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitErrorProvider()
        {
            errorProvider1.SetError(dtpErstelltAm, "");
        }

        private void UpdateButtons()
        {
            lblBearbeiten.Visible = false;

            if (cmbErstelltAm.Items.Count > 0)
            {
                if (AnamneseRow != null)
                {
                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(AnamneseRow["ErstelltAm"]);
                    if (DatenerhebungLoeschen)
                        btnDelete.Enabled = (ts.TotalHours < _anamneseAblauf);
                    else
                        btnDelete.Enabled = false;

                    if (ReadOnly)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Sie haben keine Berechtigung Daten zu ändern.");
                        if (DatenerhebungLoeschen && ts.TotalHours >= _anamneseAblauf)
                            sb.Append("\nDiese Anamnese kann nicht mehr gelöscht werden weil der Zeitraum von " + _anamneseAblauf + " Stunden für die Bearbeitung abgelaufen ist.");

                        lblBearbeiten.Text = sb.ToString();
                        lblBearbeiten.Visible = true;
                    }
                    else
                    {
                        lblBearbeiten.Text = string.Format(lblBearbeiten.Text, _anamneseAblauf);
                        lblBearbeiten.Visible = !(ts.TotalHours < _anamneseAblauf);
                    }
                }
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void UpdateInfoText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Es ist noch keine Anamnese erfasst");

            if (!ReadOnly)
                sb.Append(", drücken Sie Hinzufügen um eine Anamnese zu erfassen");

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pfleger Combo-Box befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitPflegerCombo()
        {
            try
            {
                cmbPfleger.Items.Clear();

                foreach (DataRow r in Benutzer.All().Rows)
                    cmbPfleger.Items.Add(r["ID"], (string)r["TEXT"]);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pfleger Combo-Box befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitErstelltAmCombo()
        {
            try
            {
                cmbErstelltAm.Items.Clear();
                DateTime datum;
                foreach (DataRow r in AnamneseObject.AnamneseDataTable.Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        datum = Convert.ToDateTime(r["ErstelltAm"]);
                        cmbErstelltAm.Items.Add(r["ID"], datum.ToString("dd.MM.yyyy HH:mm"));
                    }
                }

                if (cmbErstelltAm.Items.Count == 0)
                    AnamneseRow = null;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs e)
        {
            if (_loaded && _valueChangeEnabled)
            {
                _dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = false;
                cmbErstelltAm.Enabled = false;

                if (DataChanged != null)
                    DataChanged(true);
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (AnamneseObject == null)
                throw new Exception("ucAnamneseBase: AnamneseObject wurde nicht gesetzt.");

            _modus = Modus.Anlegen;
            dtpErstelltAm.Value = DateTime.Now;

            if (cmbPfleger.Items.Count > 0)
                cmbPfleger.Value = ENV.USERID;

            AnamneseRow = AnamneseObject.New();

            btnNew.Enabled = false;
            if (DatenerhebungLoeschen)
                btnDelete.Enabled = false;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
            SetReadOnly(false);
            dtpErstelltAm.Visible = true;
            cmbErstelltAm.Visible = false;

            if (DataChanged != null)
                DataChanged(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime datum = Convert.ToDateTime(AnamneseRow["ErstelltAm"]);
            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Pflegeanamnese \"" + datum.ToString("dd.MM.yyyy HH:mm") + "\" wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            Delete();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmbErstelltAm_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (_dataChanged)
            {
                DialogResult res = ENV.AskForSave();
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                else if (res == DialogResult.Yes)
                    Save();
                else
                    Undo();
            }
        }

        private void cmbErstelltAm_ValueChanged(object sender, EventArgs e)
        {
            if (cmbErstelltAm.Value != null)
            {
                Guid id = new Guid(cmbErstelltAm.Value.ToString());
                AnamneseRow = AnamneseObject.GetAnamneseRow(id);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.copyAnamnesen();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void copyAnamnesen()
        {
            try
            {
                if (this.AnamneseRow == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Anamnese ausgewählt!", "PMDS", MessageBoxButtons.OK);
                    return;
                }

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Anamnese wirklich kopieren?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        if (this.AnamneseRow.Table.TableName.Trim().ToLower().Contains(("Anamnese_Krohwinkel").Trim().ToLower()))
                        {
                            PMDS.DB.Patient.DBAnamneseKrohwinkel DBAnamneseKrohwinkelUpdate = new DB.Patient.DBAnamneseKrohwinkel();
                            DBAnamneseKrohwinkelUpdate.readDummy();

                            dsAnamneseKrohwinkel.Anamnese_KrohwinkelRow rNew = DBAnamneseKrohwinkelUpdate.New();
                            rNew.ItemArray = this.AnamneseRow.ItemArray;
                            rNew["ID"] = System.Guid.NewGuid();
                            rNew["IDBenutzer"] = PMDS.Global.ENV.USERID;
                            rNew["ErstelltAm"] = DateTime.Now;

                            DBAnamneseKrohwinkelUpdate.daAnamneseKrohwinkel.Update(DBAnamneseKrohwinkelUpdate.dsAnamneseKrohwinkel1);
                            this.b.copyPdxAnamnese((Guid)this.AnamneseRow["ID"], null, null, (Guid)rNew["ID"], db);

                            string sDekursTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese vom {0} als Vorlage für neue Anamnese verwendet.");
                            sDekursTxt = string.Format(sDekursTxt, ((DateTime)this.AnamneseRow["ErstelltAm"]).ToString("dd.MM.yyyy"));
                            this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), sDekursTxt, false, ENV.CurrentIDPatient, PflegeEintragTyp.Assessment);

                            this.IDPatient = this.IDPatient;
                        }
                        else if (this.AnamneseRow.Table.TableName.Trim().ToLower().Contains(("Anamnese_Orem").Trim().ToLower()))
                        {
                            PMDS.DB.Patient.DBAnamneseOREM DBAnamneseOREMUpdate = new DB.Patient.DBAnamneseOREM();
                            DBAnamneseOREMUpdate.readDummy();

                            dsAnamneseOrem.Anamnese_OremRow rNew = DBAnamneseOREMUpdate.New();
                            rNew.ItemArray = this.AnamneseRow.ItemArray;
                            rNew["ID"] = System.Guid.NewGuid();
                            rNew["IDBenutzerErstellt"] = PMDS.Global.ENV.USERID;
                            rNew["ErstelltAm"] = DateTime.Now;

                            DBAnamneseOREMUpdate.daAnamneseOREM.Update(DBAnamneseOREMUpdate.dsAnamneseOrem1);
                            this.b.copyPdxAnamnese(null, (Guid)this.AnamneseRow["ID"], null, (Guid)rNew["ID"], db);

                            string sDekursTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese vom {0} als Vorlage für neue Anamnese verwendet.");
                            sDekursTxt = string.Format(sDekursTxt, ((DateTime)this.AnamneseRow["ErstelltAm"]).ToString("dd.MM.yyyy"));
                            this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), sDekursTxt, false, ENV.CurrentIDPatient, PflegeEintragTyp.Assessment);

                            this.IDPatient = this.IDPatient;
                        }
                        else if (this.AnamneseRow.Table.TableName.Trim().ToLower().Contains(("Anamnese_POP").Trim().ToLower()))
                        {
                            PMDS.DB.Patient.DBAnamnesePOP DBAnamnesePOPUpdate = new DB.Patient.DBAnamnesePOP();
                            DBAnamnesePOPUpdate.readDummy();

                            PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow rNew = DBAnamnesePOPUpdate.New();
                            rNew.ItemArray = this.AnamneseRow.ItemArray;
                            rNew["ID"] = System.Guid.NewGuid();
                            rNew["IDBenutzerErstellt"] = PMDS.Global.ENV.USERID;
                            rNew["ErstelltAm"] = DateTime.Now;

                            DBAnamnesePOPUpdate.daAnamnesePOP.Update(DBAnamnesePOPUpdate.dsAnamnesePOP1);
                            this.b.copyPdxAnamnese(null, null, (Guid)this.AnamneseRow["ID"], (Guid)rNew["ID"], db);

                            string sDekursTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese vom {0} als Vorlage für neue Anamnese verwendet.");
                            sDekursTxt = string.Format(sDekursTxt, ((DateTime)this.AnamneseRow["ErstelltAm"]).ToString("dd.MM.yyyy"));
                            this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), sDekursTxt, false, ENV.CurrentIDPatient, PflegeEintragTyp.Assessment);

                            this.IDPatient = this.IDPatient;
                        }
                        else
                        {
                            throw new Exception("ucAnamneseBase.copyAnamnesen: this.AnamneseRow not allowed for Copy!");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucAnamneseBase.copyAnamnesen: " + ex.ToString());
            }
        }

    }

}
