//MDA am 09.10.2007
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinListView;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.DB;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucAnamnesePDXBase : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
    {
        protected PDx _PDx;
        protected bool _readOnly;
        protected bool _valueChangeEnabled = true;
        protected dsPDXByPflegeModell.PDXPflegeModellDataTable _PDXByPflegeModell;
        protected PDXAnamnese _PDXAnamnese;
        protected int _modellgruppe = -1;
        protected Guid _idAnamnese = Guid.Empty;
        public event EventHandler ValueChanged;

        public PMDS.db.Entities.ERModellPMDSEntities db = null;







        public ucAnamnesePDXBase()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;

            if (DesignMode)
                return;

            _PDx = new PDx();
          this.db = PMDSBusiness.getDBContext();
        }

        public virtual bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// PDXPflegeModell setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Modellgruppe
        {
            get { return _modellgruppe; }
            set
            {
                _modellgruppe = value;
                if (!DesignMode)
                    FillPDx(this.db);

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDAnamnese setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAnamnese
        {
            get { return _idAnamnese; }
            set
            {
                _idAnamnese = value;

                if (!DesignMode)
                    UpdateGUI();

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDXPflegeModell setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual dsPDXByPflegeModell.PDXPflegeModellDataTable PDXByPflegeModell
        {
            get { return _PDXByPflegeModell; }
            set
            {
                _PDXByPflegeModell = value;

                if (!DesignMode && _PDXByPflegeModell != null)
                    FillPDx(this.db);


            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDXAnamnese setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public PDXAnamnese PDXAnamnese
        {
            get { return _PDXAnamnese; }
            set
            {
                _PDXAnamnese = value;


                if (_PDXAnamnese != null)
                    UpdateGUI();

            }
        }

        private void FillPDx(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                _valueChangeEnabled = false;
                lvPDX.Items.Clear();

                if (Modellgruppe != -1 && PDXByPflegeModell != null)
                {
                    //Neu nach 10.05.2007 MDA
                    //Im Tag Eigenschaft eins  ein ListViewItems ein PDxSelectionArgs speichern.
                    //wird benutzt wenn ein PDx zu Planen ist.
                    PDxSelectionArgs arg;
                    dsPDx.PDXRow row;
                    dsPDXByPflegeModell.PDXPflegeModellRow[] rows = (dsPDXByPflegeModell.PDXPflegeModellRow[])PDXByPflegeModell.Select("Modellgruppe='" + Modellgruppe.ToString() + "'");

                    UltraListViewItem item;

                    foreach (dsPDXByPflegeModell.PDXPflegeModellRow r in rows)
                    {
                        item = lvPDX.Items.Add(r.IDPDX.ToString(), r.Code + " " + r.Klartext);
                        row = _PDx.ReadOne(r.IDPDX);
                        arg = new PDxSelectionArgs();
                        arg.IDPDX = r.IDPDX;
                        PMDS.db.Entities.PDX rPdx = b.getPDX(r.IDPDX, db);
                        if (rPdx.EntferntJN != null)
                            arg.pdx_EntferntJN = rPdx.EntferntJN.Value;
                        else
                            arg.pdx_EntferntJN = false;
                        arg.Klartext = r.Klartext;
                        arg.Text = row.Definition;
                        arg.LokalisierungsTyp = (PDxLokalisierungsTypen)r.LokalisierungsTyp;
                        arg.Code = r.Code;
                        item.Tag = arg;
                    }

                }

            }
            finally
            {
                _valueChangeEnabled = true;
            }
        }

        private dsPDXAnamnese.PDXAnamneseRow[] GetPDXAnamneseRows()
        {
            if (PDXAnamnese == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append("IDAnamnese");
            sb.Append(PDXAnamnese.PflegeModell.ToString());
            
            return (dsPDXAnamnese.PDXAnamneseRow[])PDXAnamnese.PDXAnamneseDataTable.Select(sb.ToString() + "='" + IDAnamnese.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' and Modellgruppe='") + Modellgruppe.ToString() + "'");
        }

        //
        //lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        public virtual void UpdateGUI()
        {
            try
            {
                _valueChangeEnabled = false;

                if (Modellgruppe != -1 && PDXAnamnese != null)
                {
                    dsPDXAnamnese.PDXAnamneseRow[] rows = null;

                    if (IDAnamnese != Guid.Empty)
                        rows = GetPDXAnamneseRows();

                    foreach (UltraListViewItem item in lvPDX.Items)
                    {
                        item.CheckState = CheckState.Unchecked;

                        ((PDxSelectionArgs)item.Tag).Resourceklient = "";
                        if (rows != null)
                        {
                            foreach (dsPDXAnamnese.PDXAnamneseRow r in rows)
                            {
                                if (((PDxSelectionArgs)item.Tag).IDPDX.Equals(r.IDPDX))
                                {
                                    item.CheckState = CheckState.Checked;

                                    //Neu nach 11.05.2007 MDA: Resoucen setzen
                                    if (!r.IsResourceklientNull())
                                        ((PDxSelectionArgs)item.Tag).Resourceklient = r.Resourceklient.Trim();
                                    break;
                                }
                            }
                        }
                    }

                    foreach (UltraListViewItem item in lvPDX.Items)
                    {
                        if (ReadOnly)
                        {
                            PMDS.Global.PDxSelectionArgs argTg = (PMDS.Global.PDxSelectionArgs)item.Tag;
                            if (item.CheckState == CheckState.Unchecked)
                                item.Visible = false;
                            else
                                item.Visible = true;
                        }
                        else
                        {
                            PMDS.Global.PDxSelectionArgs argTg = (PMDS.Global.PDxSelectionArgs)item.Tag;
                            if (argTg.pdx_EntferntJN == true && item.CheckState == CheckState.Unchecked)
                                item.Visible = false;
                            else
                                item.Visible = true;
                        }
                    }
                }
            }
            finally
            {
                _valueChangeEnabled = true;
            }
        }

        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public void UpdateDATA()
        {
            dsPDXAnamnese.PDXAnamneseRow[] rows = GetPDXAnamneseRows();
            
            bool found;
            Guid IDPDX = Guid.Empty;

            foreach (UltraListViewItem item in lvPDX.Items)
            {
                found = false;
                IDPDX = ((PDxSelectionArgs)item.Tag).IDPDX;

                if (rows != null)
                {
                    foreach (dsPDXAnamnese.PDXAnamneseRow r in rows)
                    {
                        if (r.RowState != DataRowState.Deleted && ((PDxSelectionArgs)item.Tag).IDPDX.Equals(r.IDPDX))
                        {
                            found = true;

                            if (item.CheckState == CheckState.Unchecked)
                                r.Delete();
                            else if (r.IsResourceklientNull() || r.Resourceklient.Trim() != ((PDxSelectionArgs)item.Tag).Resourceklient.Trim()) //Resource eintragen
                                r.Resourceklient = ((PDxSelectionArgs)item.Tag).Resourceklient.Trim();
                            break;
                        }
                    }
                }

                if (!found && item.CheckState == CheckState.Checked)
                    PDXAnamnese.NewPDXAnamnese(Modellgruppe, IDAnamnese, IDPDX, ((PDxSelectionArgs)item.Tag).Resourceklient.Trim());
            }
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public bool ValidateFields()
        {
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void OnValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && ValueChanged != null)
                ValueChanged(sender, e);
        }

        protected virtual void lvPDX_ItemCheckStateChanged(object sender, ItemCheckStateChangedEventArgs e)
        {
            OnValueChanged(sender, e);
        }

        private void lvPDX_ItemCheckStateChanging(object sender, ItemCheckStateChangingEventArgs e)
        {
            if (_valueChangeEnabled && ReadOnly)
            {
                e.Cancel = true;
                return;
            }

            OnValueChanged(sender, e);
        }
    }
}
