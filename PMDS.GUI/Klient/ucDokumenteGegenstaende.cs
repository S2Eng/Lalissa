using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;





namespace PMDS.GUI
{



    public partial class ucDokumenteGegenstaende : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private KlientDetails _klient;
        public event EventHandler ValueChanged;
        //Neu nach 26.04.2007 MDA
        private bool _readOnly = false;
        private bool _lockValueChanges = false;



        public ucDokumenteGegenstaende()
        {
            InitializeComponent();
            SetFilter();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if (_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                _klient = value;
                //ucKontaktPersonen.Klient = value;
                UpdateGUI();
            }
        }

        //Neu nach 26.04.2007
        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                //ucKontaktPersonen.ReadOnly = value;
                SetReadOnly();
            }
        }

        //
        //lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        public void UpdateGUI()
        {
            this._lockValueChanges = true;

            //----------------------------------------------------
            //              Verwahrung
            //----------------------------------------------------
            gridVerwahrung.DataSource = Klient.GEGENSTAENDE.ALL;

            //DropDownList
            UltraGridTools.AddBenutzerValueList(gridVerwahrung, "IDBenutzerausgegeben");
            UltraGridTools.AddBenutzerValueList(gridVerwahrung, "IDBenutzerzurueck");

            //----------------------------------------------------
            //              Hilfsmittel
            //----------------------------------------------------
            gridHilfsmittel.DataSource = Klient.GEGENSTAENDE.ALL;

            //DropDownList
            UltraGridTools.AddBenutzerValueList(gridHilfsmittel, "IDBenutzerausgegeben");
            UltraGridTools.AddBenutzerValueList(gridHilfsmittel, "IDBenutzerzurueck");

            //Gewaschen von
            cmbGewVon.Text = Klient.WaescheWaschen;
            cmbMarkiert.Text = Klient.WaescheMarkiert;

            this._lockValueChanges = false;
        }

        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public void UpdateDATA()
        {
            //ucKontaktPersonen.UpdateDATA();

            if(cmbGewVon.Text.Trim() != "")
                Klient.WaescheWaschen = cmbGewVon.Text.Trim();

            if (cmbMarkiert.Text.Trim() != "")
                Klient.WaescheMarkiert = cmbMarkiert.Text.Trim();
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public bool ValidateFields()
        {
            return true;
        }

        //
        //Filter einsetzen
        private void SetFilter()
        {
            ColumnFiltersCollection verwColumnFilters = gridVerwahrung.DisplayLayout.Bands[0].ColumnFilters;
            ColumnFiltersCollection hilfsmColumnFilters = gridHilfsmittel.DisplayLayout.Bands[0].ColumnFilters;

            //Ressourcen
            verwColumnFilters.ClearAllFilters();
            verwColumnFilters["HilfesmittelJN"].FilterConditions.Add(FilterComparisionOperator.Equals, false);

            //Maßnahmen
            hilfsmColumnFilters.ClearAllFilters();
            hilfsmColumnFilters["HilfesmittelJN"].FilterConditions.Add(FilterComparisionOperator.Equals, true);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow GetAktivRow(UltraGrid g)
        {
            return (PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow)UltraGridTools.CurrentSelectedRow(g);
        }

        private DialogResult ValidateVerwahrungFields(frmVerwahrung frm)
        {
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK && !frm.ValidateFields())
            {
                res = ValidateVerwahrungFields(frm);
            }

            return res;
        }

        private DialogResult ValidateHilfsmittelFields(frmHilfsmittel frm)
        {
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK && !frm.ValidateFields())
            {
                res = ValidateHilfsmittelFields(frm);
            }

            return res;
        }

        private bool AddVerwahrung()
        {
            frmVerwahrung frm = new frmVerwahrung();
            DialogResult res = ValidateVerwahrungFields(frm);
            if (res != DialogResult.OK)
                return false;

            Klient.GEGENSTAENDE.New(false, frm.BESCHREIBUNGxy, frm.NUMMER, frm.VON, frm.BIS, frm.BENUTZER_AUSGEGEBEN, frm.BENUTZER_ZURUECK,
                                    false, true, false, "", DateTime.MinValue, DateTime.MinValue);

            return true;
            
        }

        private bool AddHilfsmittel()
        {
            frmHilfsmittel frm = new frmHilfsmittel();
            DialogResult res = ValidateHilfsmittelFields(frm);
            if (res != DialogResult.OK)
                return false;

            Klient.GEGENSTAENDE.New(true, frm.BESCHREIBUNG, frm.NUMMER, frm.VON, frm.BIS, frm.BENUTZER_AUSGEGEBEN, frm.BENUTZER_ZURUECK, 
                                frm.EIGENTUMKLINIKJN, frm.EIGENTUMKLIENTJN, frm.MIETEJN, frm.EIGENTUEMER, frm.LETZTEUEBERPRUEFUNGAM, frm.NAECHSTEUEBERPRUEFUNGAM);

            return true;

        }

        private bool UpdateVerwahrung()
        {
            PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow row = GetAktivRow(gridVerwahrung);

            if (row != null && !row.IsHilfesmittelJNNull() && !row.HilfesmittelJN)
            {
                frmVerwahrung frm = new frmVerwahrung();
                frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
                frm.GEGENSTAENDE_ROW = row;

                DialogResult res = ValidateVerwahrungFields(frm);
                if (res != DialogResult.OK)
                    return false;

                frm.UpdateData();

                return true;
            }
            return false;
        }

        private bool UpdateHilfsmittel()
        {
            PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow row = GetAktivRow(gridHilfsmittel);

            if (row != null && !row.IsHilfesmittelJNNull() && row.HilfesmittelJN)
            {
                frmHilfsmittel frm = new frmHilfsmittel();
                frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
                frm.GEGENSTAENDE_ROW = row;

                DialogResult res = ValidateHilfsmittelFields(frm);
                if (res != DialogResult.OK)
                    return false;

                frm.UpdateData();

                return true;
            }
            return false;
        }

        private bool Delete(UltraGrid g, bool hilfsmittelJN)
        {
            DataRow[] rows = KlientGuiAction.CurrentSelectedRows(g);

            if (rows != null && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                //
                //Sicherheitfrage
                DialogResult res = KlientGuiAction.DelDialogResult(rows.Length);

                if (res == DialogResult.Yes)
                {
                    PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow row;
                    foreach (DataRow r in rows)
                    {
                        row = (PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow)r;

                        if(!row.IsHilfesmittelJNNull() && row.HilfesmittelJN == hilfsmittelJN)
                            row.Delete();
                    }
                    return true;
                }
            }

            return false;
        }

        //neu nach 26.04.2007 MDA
        private void SetReadOnly()
        {
            cmbGewVon.ReadOnly = ReadOnly;
            cmbMarkiert.ReadOnly = ReadOnly;
            btnAddHilfsmittel.Enabled = !ReadOnly;
            btnAddVerwahrung.Enabled = !ReadOnly;
            btnDelHilfsmittel.Enabled = !ReadOnly;
            btnDelVerwahrung.Enabled = !ReadOnly;
            btnUpdateHilfsmittel.Enabled = !ReadOnly;
            btnUpdatelVerwahrung.Enabled = !ReadOnly;
        }

        private void btnAddVerwahrung_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (AddVerwahrung() && ValueChanged != null)
                    ValueChanged(sender, e);
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

        private void btnDelVerwahrung_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (Delete(gridVerwahrung, false) && ValueChanged != null)
                    ValueChanged(sender, e);
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

        private void btnUpdatelVerwahrung_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (UpdateVerwahrung())
                    ValueChanged(sender, e);
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

        private void btnAddHilfsmittel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (AddHilfsmittel() && ValueChanged != null)
                    ValueChanged(sender, e);
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

        private void btnDelHilfsmittel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (Delete(gridHilfsmittel, true) && ValueChanged != null)
                    ValueChanged(sender, e);
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

        private void btnUpdateHilfsmittel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (UpdateHilfsmittel() && ValueChanged != null)
                    ValueChanged(sender, e);
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (this._lockValueChanges) return;

            if (PMDS.Global.historie.HistorieOn) return;
            ValueChanged(sender, e);
        }

        private void gridVerwahrung_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (Delete(gridVerwahrung, false) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void gridHilfsmittel_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (Delete(gridHilfsmittel, true) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            if (!ReadOnly)
            {
                UltraGrid g = (UltraGrid)sender;
                bool update = false;

                switch (g.Name)
                {
                    case "gridVerwahrung":
                        update = UpdateVerwahrung();
                        break;
                    case "gridHilfsmittel":
                        update = UpdateHilfsmittel();
                        break;
                }

                if (update && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void ucDokumenteGegenstaende_Load(object sender, EventArgs e)
        {

        }

        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
            this.panelButtons.Visible = !bOn;
            this.panelButtons1.Visible = !bOn;
            //this.ucKontaktPersonen.panelButtons.Visible = !bOn;
        }

        private void gridVerwahrung_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

    }
}
