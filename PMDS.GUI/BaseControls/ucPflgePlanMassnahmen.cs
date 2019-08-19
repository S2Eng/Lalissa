using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucPflgePlanMassnahmen : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
    {
        private PflegePlan _PflegePlan;
        private Guid _IDPDX = Guid.Empty;
        private PflegePlanModi _PflegePlanMode = PflegePlanModi.PflegePlan;
        private bool _bErledigte = false;
        private bool _UseMainBar = false;
        private bool _bReadOnly = false;
        private bool _bValueListInit = false;
        
        public event EventHandler ValueChanged;

        public ucPflgePlanMassnahmen()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;

            try
            {
                UltraGridTools.EnableColumns(dgM, false);
                UltraGridTools.AddWochentagValueList(dgM, "WochenTage");            //-IntVers=NoTranslation
                UltraGridTools.AddIntervallValueList(dgM, "Intervall");

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlan PFLEGEPLAN
        {
            get { return _PflegePlan; }
            set
            {
                _PflegePlan = value;
                RefreshControl();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegeplan nach eine Pflegedefinition filtern.
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPDX
        {
            get { return _IDPDX; }
            set
            {
                _IDPDX = value;
                SetFilter();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModi PflegePlanMode
        {
            get { return _PflegePlanMode; }
            set { _PflegePlanMode = value; PrepareControlsForMode(); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Beendete Einträge anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Erledigte
        {
            get { return _bErledigte; }
            set 
            { 
                _bErledigte = value;
                SetFilter();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Buttons nicht anzeigen wenn ein MainBar eingesetzt wird.
        /// </summary>
        //----------------------------------------------------------------------------
        public bool UseMainBar
        {
            get { return _UseMainBar; }
            set
            {
                _UseMainBar = value;
                btnEndM.Visible = !value;
                btnAddM.Visible = !value;
                btnUpdate.Visible = !value;
            }
        }

        #region IReadOnly Members

        public bool ReadOnly
        {
            get
            {
                return _bReadOnly;
            }
            set
            {
                _bReadOnly = value;
                btnAddM.Visible = !value && _PflegePlanMode == PflegePlanModi.PflegePlan;
                btnUpdate.Visible = !value && _PflegePlanMode == PflegePlanModi.PflegePlan;
                
                if (_bReadOnly == true)
                {
                    btnEndM.Visible = false;
                }
                else
                {
                    btnEndM.Visible = true;
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktalisiert die ValueList
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshValueList()
        {
            if (!_bValueListInit)
            {
                UltraGridTools.AddGuidTextValuListFromAuswahlGruppe("BER", dgM, "IDBerufsstand", true);
                UltraGridTools.AddBenutzerValueList(dgM, "IDBenutzer_erstellt");
                UltraGridTools.AddBenutzerValueList(dgM, "IDBenutzer_geaendert");
                _bValueListInit = true;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// aktualisieren des Controls
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshControl()
        {
            try
            {
                //_bGridChangeInProgress = true;
                //_aChangedASZM = new List<UltraGridRow>();

                RefreshValueList();

                dgM.DataSource = _PflegePlan.PFLEGEPLAN_EINTRAEGE;
                
                SetFilter();

                if (_PflegePlanMode == PflegePlanModi.PflegePlan)         // Evaluierung funktioniert Zielabhängig PflegePlan PDx abhängig
                {
                    //ProcessSelectedDependedASZM();
                    dgM.PerformAction(UltraGridAction.FirstRowInGrid);
                }
                else
                {
                    Application.DoEvents();
                    dgM.PerformAction(UltraGridAction.FirstRowInGrid);
                    dgM.PerformAction(UltraGridAction.ToggleRowSel);
                    //RefreshLastEval();
                }

                Application.DoEvents();
                //RefreshColors();
            }
            finally
            {
                //_bGridChangeInProgress = false;
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Setzt die Filter fürs Datengrid
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetFilter()
        {
            try
            {
                dgM.BeginUpdate();
                dgM.Rows.ColumnFilters.ClearAllFilters();
                dgM.Rows.ColumnFilters["EintragGruppe"].FilterConditions.Add(FilterComparisionOperator.Equals, "M");

                if (IDPDX != Guid.Empty)
                {
                    UltraGridTools.SetSelectedAndVisible(dgM, false, false);		    // Blaue Markierung löschen M Grid
                    ProcessSelectedDependedASZMSetSelectedVisible();
                }


                if (!Erledigte)					// Erledigte anzeigen
                    dgM.Rows.ColumnFilters["ErledigtJN"].FilterConditions.Add(FilterComparisionOperator.Equals, false);

                dgM.EndUpdate();
                RepositionGrid();
            }
            finally
            {
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die zu den PDx gehörenden ASZM markieren, die anderen verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSelectedDependedASZMSetSelectedVisible()
        {
            string sLokalisierung = "";
            string sLokalisierungSeite = "";
            Guid IDAufenthaltPDx = Guid.Empty;

            foreach (dsAufenthaltPDx.AufenthaltPDxRow r in PFLEGEPLAN.AUFENTHALTPDX)
            {
                foreach (dsPflegePlanPDx.PflegePlanPDxRow rp in _PflegePlan.PFLEGEPLANPDX.Rows)
                {

                    if (!Erledigte && rp.ErledigtJN)
                        continue;

                    IDAufenthaltPDx = r.ID;

                    if (rp.IDPDX == IDPDX && rp.IDPDX == r.IDPDX && rp.IDAufenthaltPDx == IDAufenthaltPDx)
                    {
                        sLokalisierung = r.Lokalisierung;
                        sLokalisierungSeite = r.LokalisierungSeite;

                        SetSelectedVisible(rp.IDPflegePlan, sLokalisierung, sLokalisierungSeite);
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle ASZM der selektierten PDx werden markiert dargestellt
        /// Die lokalisierung wird berücksichtigt
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetSelectedVisible(Guid IDPflegePlan, string sLokalisierung, string sLokalisierungSeite)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgM, false))
            {
                if ((string)r.Cells["EintragGruppe"].Value == "T")					// Termine haben keinen Bezug zum Eintrag
                    continue;

                DataRowView v = (DataRowView)r.ListObject;
                dsPflegePlan.PflegePlanRow rp = (dsPflegePlan.PflegePlanRow)v.Row;

                if (rp.ID == IDPflegePlan && sLokalisierung.Trim() == rp.Lokalisierung.Trim() && sLokalisierungSeite.Trim() == rp.LokalisierungSeite.Trim() && rp.PDXJN)
                {
                    r.Selected = true;
                    r.Hidden = false;

                    if (!rp.IsIDUntertaegigeGruppeNull())
                        SetSelectedVisibleDependedGroup(rp.IDUntertaegigeGruppe);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Zeigt alle zu einer UntertägigenGruppe gehörenden Einträge
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetSelectedVisibleDependedGroup(Guid IDUntertaegigGruppe)
        {
            DataRowView v;
            dsPflegePlan.PflegePlanRow rp;
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgM, false))
            {

                v = (DataRowView)r.ListObject;
                rp = (dsPflegePlan.PflegePlanRow)v.Row;

                if (rp.IsIDUntertaegigeGruppeNull())
                    continue;

                if (rp.IDUntertaegigeGruppe == IDUntertaegigGruppe)
                {
                    r.Selected = true;
                    r.Hidden = false;
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die einzelnen Grids Repositionieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void RepositionGrid()
        {
            if (dgM.Rows.Count > 0)
                dgM.ActiveRowScrollRegion.FirstRow = dgM.Rows[0];
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das Control für die entsprechenden Modi herrichten
        /// </summary>
        //----------------------------------------------------------------------------
        private void PrepareControlsForMode()
        {
            btnAddM.Visible = _PflegePlanMode == PflegePlanModi.PflegePlan;
            btnUpdate.Visible = _PflegePlanMode == PflegePlanModi.PflegePlan;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liedfert den richtigen Layoutnamen zum Grid
        /// </summary>
        //----------------------------------------------------------------------------
        private string GetLayoutName()
        {
            string s = _PflegePlanMode == PflegePlanModi.PflegePlan ? "PP_GRID_" : "PP_GRID_EVAL";
            return _bErledigte ? s + dgM.Name + "_Erledigt.lyt" : s + dgM.Name + ".lyt";
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Wird Aufgerufen wenn sich irgendwo was ändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ContentChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, null);

        }

        private void btnAddM_Click(object sender, EventArgs e)
        {

        }

        private void btnEndM_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgM_CellChange(object sender, CellEventArgs e)
        {
            ContentChanged();
        }

    }
}
