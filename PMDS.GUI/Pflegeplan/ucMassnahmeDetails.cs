//----------------------------------------------------------------------------------------------
//  Erstellt am:	24.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using Infragistics.Win;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucMassnahmeDetails : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
    {
        private dsEintrag.EintragRow _EintragRow;
        private dsEintragZusatz.EintragZusatzRow _eintragZusRow;
        public event EventHandler ValueChanged;
        private bool _preventValueChanged = false;

        public ucMassnahmeDetails()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                cbSicht.Items.Add(ENV.String("CBPatient"));
                cbSicht.Items.Add(ENV.String("CBPfleger"));
                cbSicht.Items.Add(ENV.String("CBArzt"));
                RefreshZeitbereichList(null);
                RequiredFields();
            }
        }
        #region IReadOnly Members

        public bool ReadOnly
        {
            get
            {
                return tbText.ReadOnly;
            }
            set
            {
                tbText.ReadOnly = value;
                tbWarnung.ReadOnly = value;
                cbParalell.Enabled = !value;
                tbIntervall.ReadOnly = value;
                osIntervall.Enabled = !value;
                ucWochenTage21.Enabled = !value;
                tbDauer.ReadOnly = value;
                cbBerufsstand.ReadOnly = value;
                cbRMOptionalJN.Enabled = !value;
                cbLinkDokument.ReadOnly = value;
            }
        }

        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die zu bearbeitende EintragRow
        /// ACHTUNG die Daten der EintragRow werden aktuaisiert wenn AcceptChanges ausgeführt wird
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsEintrag.EintragRow EINTRAGROW
        {
            get
            {
                return _EintragRow;
            }
            set
            {
                if (value == null)
                    return;
                _EintragRow = value;
                RefreshControl();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die zu bearbeitende EintragZusatzRow
        /// ACHTUNG die Daten der EintragZusatzRow werden aktuaisiert wenn AcceptChanges ausgeführt wird
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsEintragZusatz.EintragZusatzRow EITRAGZUSATZROW
        {
            get
            {
                return _eintragZusRow;
            }
            set
            {
                if (value == null)
                    return;
                _eintragZusRow = value;
                RefreshControl();
            }
        }

        //Neu nach 26.08.2008 MDA
        /// <summary>
        /// Alle Zeitbereiche und Zeitbereichserien
        /// </summary>
        private void RefreshZeitbereichList(ZeitbereichHelper zbHelper)
        {
            cbZeitBereiche.Items.Clear();
            ValueListItem item;
            ZeitbereichHelper zHelper;
            zHelper = new ZeitbereichHelper(Guid.Empty, ZeitbereichTyp.Zeitbereich);
            item = cbZeitBereiche.Items.Add(zHelper, " ");
            item.Tag = zHelper;

            // Zeitbereich hinzufügen
            Zeitbereich zb = new Zeitbereich();
            dsZeitbereich.ZeitbereichDataTable dtz = zb.Read();
            foreach (dsZeitbereich.ZeitbereichRow rz in dtz)
            {
                zHelper = new ZeitbereichHelper(rz.ID, ZeitbereichTyp.Zeitbereich);
                item = cbZeitBereiche.Items.Add(zHelper, rz.Bezeichnung);
                item.Tag = zHelper;
            }

            // Zeitbereichserien hinzufügen
            ZeitbereichSerien z = new ZeitbereichSerien();
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = z.Read();

            foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)
            {
                zHelper = new ZeitbereichHelper(r.ID, ZeitbereichTyp.ZeitbereichSerien);
                item = cbZeitBereiche.Items.Add(zHelper, r.Bezeichnung);
                item.Tag = zHelper;
            }

            if (zbHelper != null)
            {
                //bool changed = false;
                //if (!_preventValueChanged)
                //{
                //    _preventValueChanged = true;
                //    changed = true;
                //}

                _preventValueChanged = true;
                cbZeitBereiche.Value = GetZeitbereichValueFromValueList(zbHelper._ID, zbHelper._TYP);
                _preventValueChanged = false;
                //if(changed)
                //    _preventValueChanged = false;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisiert das Control
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshControl()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            errorProvider1.SetError(tbText, "");
            errorProvider1.SetError(cbBerufsstand, "");

            if (EINTRAGROW == null || _eintragZusRow == null)
                return;
            cbSerie.RefreshList();
            _preventValueChanged = true;
            tbText.Text = EINTRAGROW.Text;
            cbSicht.Text = EINTRAGROW.Sicht;
            tbWarnung.Text = EINTRAGROW.Warnhinweis;
            eintragtypCombo1.RefreshList();
            eintragtypCombo1.EintragTyp = (EintragFlag)EINTRAGROW.flag;

            if (EINTRAGROW.IsIDLinkDokumentNull())
                cbLinkDokument.IDLinkDokument = Guid.Empty;
            else
                cbLinkDokument.IDLinkDokument = EINTRAGROW.IDLinkDokument;

            cbBedarfsmedikation.Checked = EINTRAGROW.BedarfsMedikationJN;

            cbRMOptionalJN.Checked = _eintragZusRow.RMOptionalJN;
            cbParalell.Checked = _eintragZusRow.ParalellJN;
            ucWochenTage21.WOCHENTAGE = _eintragZusRow.WochenTage;
            tbDauer.Value = _eintragZusRow.Dauer;

            if (!_eintragZusRow.IsIDBerufsstandNull())
                cbBerufsstand.ID = _eintragZusRow.IDBerufsstand;
            else
                cbBerufsstand.ID = Guid.Empty;

            if (_eintragZusRow.Intervall % (721) == 0)							// Monate
            {
                tbIntervall.Value = _eintragZusRow.Intervall / 721;
                osIntervall.CheckedIndex = 1;
            } 
            else if (_eintragZusRow.Intervall % (168) == 0)							// woche
            {
                tbIntervall.Value = _eintragZusRow.Intervall / 168;
                osIntervall.CheckedIndex = 1;
            }
            else if (_eintragZusRow.Intervall % 24 == 0)							// Tage
            {
                tbIntervall.Value = _eintragZusRow.Intervall / 24;
                osIntervall.CheckedIndex = 0;
            }

            if (_eintragZusRow.IsIDMassnahmenserienNull())
                cbSerie.Value = null;
            else
                cbSerie.Value = _eintragZusRow.IDMassnahmenserien;

            //Neu nach 26.08.2008
            if (_eintragZusRow.IsIDZeitbereichNull() && _eintragZusRow.IsIDZeitbereichSerienNull())
                cbZeitBereiche.Value = null;
            else if (!_eintragZusRow.IsIDZeitbereichNull())
            {
                cbZeitBereiche.Value = GetZeitbereichValueFromValueList(_eintragZusRow.IDZeitbereich, ZeitbereichTyp.Zeitbereich);
            }
            else
            {
                cbZeitBereiche.Value = GetZeitbereichValueFromValueList(_eintragZusRow.IDZeitbereichSerien, ZeitbereichTyp.ZeitbereichSerien);
            }

            SetShowbuttonEnabled();
            _preventValueChanged = false;
        }
        //Neu nach 27.08.2008 MDA
        /// <summary>
        /// Ein ZeitbereichHelper aus der Liste der Zeitbereiche und Zeitbereichserien zurückgeben
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zeitbereichTyp"></param>
        /// <returns></returns>
        private ZeitbereichHelper GetZeitbereichValueFromValueList(Guid id, ZeitbereichTyp zeitbereichTyp)
        {
            ZeitbereichHelper helper;
            foreach (ValueListItem item in cbZeitBereiche.Items)
            {
                if (item.Tag == null) continue;
                helper = (ZeitbereichHelper)item.Tag;
                if (helper._ID == id && helper._TYP == zeitbereichTyp)
                    return helper;
            }

            return null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(tbText);
            GuiUtil.ValidateRequired(cbBerufsstand);
        }


        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            if (EINTRAGROW == null || _eintragZusRow == null)
                return !bError;

            // tbText
            GuiUtil.ValidateField(tbText, (tbText.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // tbText
            GuiUtil.ValidateField(cbBerufsstand, (cbBerufsstand.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //Neu nach 27.08.2008 MDA
            GuiUtil.ValidateField(cbZeitBereiche, !(cbSerie.Value != null && (Guid)cbSerie.Value != Guid.Empty && cbZeitBereiche.SelectedIndex != 0 && cbZeitBereiche.SelectedIndex != -1),
                ENV.String("ERROR_MS_ORZB"), ref bError, bInfo, errorProvider1);

            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Schreibt die Änderungen in die Row
        /// </summary>
        //----------------------------------------------------------------------------
        public void AcceptChanges()
        {
            if (EINTRAGROW == null || _eintragZusRow == null)
                return;
            EINTRAGROW.Text = tbText.Text.Trim();
            EINTRAGROW.Warnhinweis = tbWarnung.Text.Trim();
            EINTRAGROW.Sicht = cbSicht.Text.Trim();

            if (cbLinkDokument.IDLinkDokument == Guid.Empty)
                EINTRAGROW.SetIDLinkDokumentNull();
            else
                EINTRAGROW.IDLinkDokument = cbLinkDokument.IDLinkDokument;

            EINTRAGROW.BedarfsMedikationJN = cbBedarfsmedikation.Checked;
            EINTRAGROW.flag = (int)eintragtypCombo1.EintragTyp;

            _eintragZusRow.RMOptionalJN = cbRMOptionalJN.Checked ? true : false;
            _eintragZusRow.ParalellJN = cbParalell.Checked ? true : false;
            _eintragZusRow.WochenTage = ucWochenTage21.WOCHENTAGE;
            _eintragZusRow.Dauer = (int)tbDauer.Value;

            if (cbBerufsstand.ID != Guid.Empty)
                _eintragZusRow.IDBerufsstand = cbBerufsstand.ID;
            else
                _eintragZusRow.SetIDBerufsstandNull();

            switch (osIntervall.CheckedIndex)
            {
                case 0:
                    _eintragZusRow.Intervall = (int)tbIntervall.Value * 24;		// Tage
                    break;
                case 1:
                    _eintragZusRow.Intervall = (int)tbIntervall.Value * 168;	// Wochen
                    break;
                case 2:
                    _eintragZusRow.Intervall = (int)tbIntervall.Value * 720;	// Monate
                    break;

            }

            //Änderung nach 27.08.2008
            if (cbSerie.Text.Length > 0)
                _eintragZusRow.IDMassnahmenserien = (Guid)cbSerie.Value;
            else
                _eintragZusRow.SetIDMassnahmenserienNull();

            //Neu nach 26.08.2008
            _eintragZusRow.SetIDZeitbereichNull();
            _eintragZusRow.SetIDZeitbereichSerienNull();
            if (cbZeitBereiche.Value != null)
            {
                ZeitbereichHelper h = new ZeitbereichHelper(cbZeitBereiche.Value.ToString());
                if (h._ID != Guid.Empty)
                {
                    if (h._TYP == ZeitbereichTyp.Zeitbereich)
                        _eintragZusRow.IDZeitbereich = h._ID;
                    else
                        _eintragZusRow.IDZeitbereichSerien = h._ID;

                    _eintragZusRow.SetIDMassnahmenserienNull();
                }
            }
        }


        private void SetShowbuttonEnabled()
        {
            btnShow.Enabled = cbLinkDokument.IDLinkDokument != Guid.Empty;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GuiUtil.ShowLinkDokument(cbLinkDokument.IDLinkDokument);
        }

        private void ucMassnahmeDetails_Load(object sender, EventArgs e)
        {
            cbBerufsstand.Group = "BER";
            cbLinkDokument.RefreshList();
        }

        private void cbLinkDokument_ValueChanged(object sender, EventArgs e)
        {
            DataChanged();
            bool b = cbLinkDokument.IDLinkDokument != Guid.Empty;
            btnShow.Enabled = b;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Signalisiert das sich was geändert hat
        /// </summary>
        //----------------------------------------------------------------------------
        private void Control_ValueChanged(object sender, System.EventArgs e)
        {
            DataChanged();
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        private void DataChanged()
        {
            if (ValueChanged != null && _preventValueChanged == false)
                ValueChanged(this, null);

        }

        private void cbZeitBereiche_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            ZeitbereichHelper zbHelper = null;

            if (cbZeitBereiche.Value != null && cbZeitBereiche.Value is ZeitbereichHelper)
                zbHelper = (ZeitbereichHelper)cbZeitBereiche.Value;

            frmZeitbereicheZeitbereichserien frm = new frmZeitbereicheZeitbereichserien();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
                RefreshZeitbereichList(zbHelper);
        }
    }
}
