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
using PMDS.GUI.Klient;

namespace PMDS.GUI
{


    public partial class ucRehabilitation : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {

        private KlientDetails _klient;
        public event EventHandler ValueChanged;

        private bool _readOnly = false;
        private bool _lockValueChanges = false;



        public ucRehabilitation()
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
                UpdateGUI();
               
            }
        }
        //Neu nach 27.04.2007
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
                SetReadOnly();
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
            panelButtons1.Visible = !bOn;
            panelButtons2.Visible = !bOn;
        }
        //
        //l‰dt die Daten aus einem Businessobject und aktualisiert die GUI.
        public void UpdateGUI()
        {
            this._lockValueChanges = true;

            //----------------------------------------------------
            //              Ressourcen
            //----------------------------------------------------
            gridRessourcen.DataSource = Klient.REHABILITATION.ALL;

            //----------------------------------------------------
            //              Maﬂnahmen
            //----------------------------------------------------
            gridMaﬂnahmen.DataSource = Klient.REHABILITATION.ALL;

            this._lockValueChanges = false;
        }

        //
        //Aktualisiert die Gui Daten ¸ber das Businessobject in die Datenbank.
        public void UpdateDATA()
        {

        }

        //
        //pr¸ft ob alle Eingaben richtig sind.
        public bool ValidateFields()
        {
            return true;
        }

        //
        //Filter einsetzen
        private void SetFilter()
        {
            ColumnFiltersCollection ressColumnFilters = gridRessourcen.DisplayLayout.Bands[0].ColumnFilters;
            ColumnFiltersCollection maﬂnColumnFilters = gridMaﬂnahmen.DisplayLayout.Bands[0].ColumnFilters;

            //Ressourcen
            ressColumnFilters.ClearAllFilters();
            ressColumnFilters["MassnahmeJN"].FilterConditions.Add(FilterComparisionOperator.Equals, false);

            //Maﬂnahmen
            maﬂnColumnFilters.ClearAllFilters();
            maﬂnColumnFilters["MassnahmeJN"].FilterConditions.Add(FilterComparisionOperator.Equals, true);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsRehabilitation.RehabilitationRow GetAktivRow(UltraGrid g)
        {
            return (dsRehabilitation.RehabilitationRow)UltraGridTools.CurrentSelectedRow(g);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einschalten
        /// </summary>
        //----------------------------------------------------------------------------
        private bool AddRehabilitation(bool massnahmeJN)
        {
            frmRehabilitation frm = new frmRehabilitation(massnahmeJN, false);

            if (massnahmeJN)
                frm.Von = DateTime.Now;

            frm.Bis = DateTime.Now;

            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return false;

            Klient.REHABILITATION.New(massnahmeJN, frm.Von, frm.Bis, frm.Beschreibung, frm.Ziel, frm.Institution,
                                      frm.EndeGrund, frm.Bemerkung);
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einschalten
        /// </summary>
        //----------------------------------------------------------------------------
        private bool UpdateRehabilitation(bool massnahmeJN, dsRehabilitation.RehabilitationRow row)
        {
            if(row == null)
                return false;

            if (massnahmeJN && !row.MassnahmeJN)
                return false;

            if (!massnahmeJN && row.MassnahmeJN)
                return false;

            frmRehabilitation frm = new frmRehabilitation(massnahmeJN, true);
            frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
            frm.REHABILITATION_ROW = row;

            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return false;

            frm.UpdateData();
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Rows ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsRehabilitation.RehabilitationRow[] CurrentSelectedRows(UltraGrid g)
        {
            dsRehabilitation.RehabilitationRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in g.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsRehabilitation.RehabilitationRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsRehabilitation.RehabilitationRow)v.Row;
                    i++;
                }

            }

            return list;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Lˆscht Daetens‰tze
        /// </summary>
        //----------------------------------------------------------------------------
        private bool DeleteDaten(UltraGrid g)
        {
            dsRehabilitation.RehabilitationRow[] rows = CurrentSelectedRows(g);

            if (rows != null && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                //
                //Sicherheitfrage
                DialogResult res;
                if (rows.Length > 1)
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datens‰tze gelˆscht werden?", "Datens‰tze lˆschen", MessageBoxButtons.YesNo);
                else
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelˆscht werden?", "Datensatz lˆschen", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    foreach (dsRehabilitation.RehabilitationRow r in rows)
                    {
                        r.Delete();
                    }
                    return true;
                }
            }

            return false;
        }

        //neu nach 26.04.2007 MDA
        private void SetReadOnly()
        {
            btnAddMaﬂnahme.Enabled = !ReadOnly;
            btnAddRessource.Enabled = !ReadOnly;
            btnDelMaﬂnahme.Enabled = !ReadOnly;
            btnDelRessource.Enabled = !ReadOnly;
            btnUpdateMaﬂnahme.Enabled = !ReadOnly;
            btnUpdateRessource.Enabled = !ReadOnly;
        }


        private void btnAddRessource_Click(object sender, EventArgs e)
        {
            if(AddRehabilitation(false))
                ValueChanged(sender, e);
        }

        private void btnDelRessource_Click(object sender, EventArgs e)
        {
            if (DeleteDaten(gridRessourcen) && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnUpdateRessource_Click(object sender, EventArgs e)
        {
            dsRehabilitation.RehabilitationRow row = GetAktivRow(gridRessourcen);

            if(UpdateRehabilitation(false, row))
                ValueChanged(sender, e);
        }

        private void btnAddMaﬂnahme_Click(object sender, EventArgs e)
        {
            if (AddRehabilitation(true))
                ValueChanged(sender, e);
        }

        private void btnDelMaﬂnahme_Click(object sender, EventArgs e)
        {
            if (DeleteDaten(gridMaﬂnahmen) && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnUpdateMaﬂnahme_Click(object sender, EventArgs e)
        {
            dsRehabilitation.RehabilitationRow row = GetAktivRow(gridMaﬂnahmen);
            if (UpdateRehabilitation(true, row))
                ValueChanged(sender, e);
        }

        private void gridRessourcen_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (DeleteDaten(gridRessourcen) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void gridMaﬂnahmen_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (DeleteDaten(gridMaﬂnahmen) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (this._lockValueChanges) return;
            if (!ReadOnly)
            {
                UltraGrid g = (UltraGrid)sender;
                dsRehabilitation.RehabilitationRow row = GetAktivRow(g);
                bool massnahmeJN = (g.Name != "gridRessourcen");

                if (UpdateRehabilitation(massnahmeJN, row))
                    ValueChanged(sender, e);
            }
        }

        private void pnlRessourcen_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void ultraGroupBox28_Click(object sender, EventArgs e)
        {

        }

        private void ucRehabilitation_Load(object sender, EventArgs e)
        {
        }

        private void ultraGridBagLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
