using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PMDS.DB.Global;
using S2Extensions;

using System.Data.Entity;

namespace PMDS.GUI.STAMP
{
    public partial class ucSTAMPData : UserControl
    {
        public event EventHandler ValueChanged;
        private bool _lockValueChanges;
        private bool _valueChangeEnabled = true;
        public bool STAMPDataHasChanged { get; set; }
        public bool IsDirty { get; set; }

        private Guid IDAufenthalt = Guid.Empty;
        private string LetzteHWSGemeinde = "";
        private DateTime AufenthaltVon = DateTime.Now;
        private DateTime? AufenthaltBis;

        private DBSTAMP_Kostentragungen _db = new DBSTAMP_Kostentragungen();
        private Global.dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable _dt = new Global.dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable();
        private Global.dsSTAMP_Kostentragungen.STAMP_KostentragungenRow _r;
        private Global.dsSTAMP_Kostentragungen.STAMP_KostentragungenRow _rNew;


        private enum RowStatus
        {
            unchanged = 0,
            modified = 1,
            added = 2
        }

        public ucSTAMPData()
        {
            InitializeComponent();
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges || _r == null || _r.RowState == DataRowState.Detached) 
                return;

            DateTime chkDateBis = _r.IsGueltigBisNull() ? DateTime.MinValue : _r.GueltigBis;
            if (cmbFinanzierung.Text != _r.Finanzierung ||
                dtGueltigVon.DateTime != _r.GueltigVon ||
                (dtGueltigBis.Value != null && dtGueltigBis.DateTime != chkDateBis) ||
                (dtGueltigBis.Value == null && !_r.IsGueltigBisNull()) ||
                cmbGemeinde.Text != _r.Gemeinde ||
                cmbBundesland.Text != _r.Bundesland ||
                cmbLand.Text != _r.Land ||
                txtFinanzierungSonstige.Text != _r.FinanzierungSonstige
                )
            {
                _r.Finanzierung = cmbFinanzierung.Text;
                _r.GueltigVon = dtGueltigVon.DateTime;
                if (dtGueltigBis.Value != null && dtGueltigBis.DateTime != DateTime.MinValue)
                {
                    _r.GueltigBis = dtGueltigBis.DateTime;
                }
                else
                {
                    _r.SetGueltigBisNull();
                }
                _r.Gemeinde = cmbGemeinde.Text;
                _r.Bundesland = cmbBundesland.Text;
                _r.Land = cmbLand.Text;
                _r.FinanzierungSonstige = txtFinanzierungSonstige.Text;
                _r.LastUpdateDate = DateTime.Now;
                _r.UpdatedUser = PMDS.Global.ENV.USERID;

                dgKostentragungen.Refresh();

                STAMPDataHasChanged = true;

                IsDirty = !CheckData(false);

                if (_valueChangeEnabled && (ValueChanged != null))
                    ValueChanged(sender, args);
            }
        }

        public void Init(Guid IDAufenthalt)
        {
            try
            {
                
                gbDetails.Visible = false;
                this.IDAufenthalt = IDAufenthalt;
                cmbFinanzierung.initControl();
                cmbGemeinde.initControl();
                cmbBundesland.initControl();
                cmbLand.initControl();

                pnlBundesland.Left = pnlGemeinde.Left;
                pnlBundesland.Top = pnlGemeinde.Top;
                pnlLand.Left = pnlGemeinde.Left;
                pnlLand.Top = pnlGemeinde.Top;
                pnlFinanzierungSonstige.Left = pnlGemeinde.Left;
                pnlFinanzierungSonstige.Top = pnlGemeinde.Top;

                SetUI(true, true, true, true, true);

                dtGueltigVon.Value = null;
                dtGueltigBis.Value = null;

                dgKostentragungen.DisplayLayout.Bands[0].Override.CellClickAction = CellClickAction.RowSelect;
                this.dgKostentragungen.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;

                LoadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucSTAMPData.Init: " + ex.ToString());
            }
        }

        private bool LoadData()
        {
            try
            {
                _dt = _db.Read(IDAufenthalt);
                this.bindingSource.DataSource = _dt;
                LetzteHWSGemeinde = "";

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var hws = (from a in db.Aufenthalt
                                        where a.ID == IDAufenthalt
                                        select new { hws = a.Hauptwohnsitzgemeinde, AufenthaltVon = a.Aufnahmezeitpunkt, AufenthaltBis = a.Entlassungszeitpunkt }).FirstOrDefault();
                    if (hws != null)
                    {
                        LetzteHWSGemeinde = hws.hws;
                        AufenthaltVon = (DateTime)hws.AufenthaltVon;
                        AufenthaltBis = hws.AufenthaltBis;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSTAMPData.LoadData: " + ex.ToString());
            }
        }

        private bool CheckData(bool ShowMsg)
        {
            //Datenprüfung
            string strError = "";
            foreach (Global.dsSTAMP_Kostentragungen.STAMP_KostentragungenRow rowCheck in _dt)
            {
                if (rowCheck.RowState != DataRowState.Deleted)
                {
                    if (rowCheck.Finanzierung.sEquals("§13(1) SHG") || rowCheck.Finanzierung.sEquals("§13(1) SHG iVm. §2(1) LEVO-SHG") || rowCheck.Finanzierung.sEquals("§19 StBHG"))
                    {
                        if (String.IsNullOrWhiteSpace(rowCheck.Gemeinde))
                        {
                            strError += "Gemeinde darf nicht leer sein bei Kostentragung vom " + rowCheck.GueltigVon.ToString("dd.MM.yyyy") + "\n";
                        }
                    }
                    else if (rowCheck.Finanzierung.sEquals("Anderes Bundesland"))
                    {
                        if (String.IsNullOrWhiteSpace(rowCheck.Bundesland))
                        {
                            strError += "Bundesland darf nicht leer sein bei Kostentragung vom " + rowCheck.GueltigVon.ToString("dd.MM.yyyy") + "\n";
                        }
                    }
                    else if (rowCheck.Finanzierung.sEquals("Anderer Staat"))
                    {
                        if (String.IsNullOrWhiteSpace(rowCheck.Land))
                        {
                            strError += "Anderer Staat darf nicht leer sein bei Kostentragung vom " + rowCheck.GueltigVon.ToString("dd.MM.yyyy") + "\n";
                        }
                    }
                    else if (rowCheck.Finanzierung.sEquals("Sonstige"))
                    {
                        if (String.IsNullOrWhiteSpace(rowCheck.FinanzierungSonstige))
                        {
                            strError += "Finanzierungsbeschreibung darf nicht leer sein bei Kostentragung vom " + rowCheck.GueltigVon.ToString("dd.MM.yyyy") + "\n";
                        }
                    }

                    if (!String.IsNullOrEmpty(strError))
                    {
                        txtErrLog.Text = strError + "\n\nBitte ergänzen Sie die Daten, damit die Änderungen gespeichert werden können.";
                        txtErrLog.Visible = true;
                    }
                    else
                    {
                        txtErrLog.Text = "";
                        txtErrLog.Visible = false;
                    }
                }
            }

            if (!String.IsNullOrEmpty(strError))
            {
                if (ShowMsg)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(strError, "Eingabefehler bei Kostentragungen", System.Windows.Forms.MessageBoxButtons.OK);
                }
                return false;
            }
            return true;
        }

        public bool SaveData()
        {
            try
            {
                _db.Write(_dt);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSTAMPData.SaveData: " + ex.ToString());
            }
        }

        private void dgKostentragungen_ClickCell(object sender, ClickCellEventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            int i = 0;
            gbDetails.Visible = true;
            UltraGridRow row = this.dgKostentragungen.ActiveRow;
            if (row != null)
            {
                this._lockValueChanges = true;
                _r = _dt.FindByID(new Guid(row.Cells["ID"].Text));

                //Reihenfolge einhalten, Finanzierung zum Schluss!!!
                this.txtFinanzierungSonstige.Text = row.Cells["FinanzierungSonstige"].Text;
                this.cmbGemeinde.Text = row.Cells["Gemeinde"].Text;
                this.cmbBundesland.Text = row.Cells["Bundesland"].Text;
                this.cmbLand.Text = row.Cells["Land"].Text;
                this.dtGueltigVon.Value = row.Cells["GueltigVon"].Value;
                this.dtGueltigBis.Value = row.Cells["GueltigBis"].Value;
                this.cmbFinanzierung.Text = row.Cells["Finanzierung"].Text;
                Application.DoEvents();

                this._lockValueChanges = false;
            }
        }

        private void cmbFinanzierung_ValueChanged(object sender, EventArgs e)
        {
            if (_r == null)
                return;

            if (cmbFinanzierung.Text.sEquals("Selbstzahler") || cmbFinanzierung.Text.sEquals("Bund") || cmbFinanzierung.Text.sEquals("Leistungszuerkennungsverfahren läuft"))
            {
                SetUI(false, true, true, true, true);
            }
            else if (cmbFinanzierung.Text.sEquals("§13(1) SHG") || cmbFinanzierung.Text.sEquals("§13(1) SHG iVm. §2(1) LEVO-SHG") || cmbFinanzierung.Text.sEquals("§19 StBHG"))
            {
                SetUI(false, false, true, true, true);
                if (String.IsNullOrWhiteSpace(cmbGemeinde.Text) && !String.IsNullOrWhiteSpace(LetzteHWSGemeinde))
                {
                    cmbGemeinde.Text = LetzteHWSGemeinde;
                }
            }
            else if(cmbFinanzierung.Text.sEquals("Anderes Bundesland"))
            {
                SetUI(false, true, false, true, true);
            }
            else if (cmbFinanzierung.Text.sEquals("Anderer Staat"))
            {
                SetUI(false, true, true, false, true);
            }
            else if (cmbFinanzierung.Text.sEquals("Sonstige"))
            {
                SetUI(false, true, true, true, false);
            }

            if (cmbFinanzierung.Text != _r.Finanzierung)
            {
                this.OnValueChanged(sender, e);
            }
        }

        private void SetUI (bool resetFinanzierung, bool hideGemeinde, bool hideBundesland, bool hideLand, bool hideSonstiges)
        {
            pnlGemeinde.Visible = !hideGemeinde;
            pnlBundesland.Visible = !hideBundesland;
            pnlLand.Visible = !hideLand;
            pnlFinanzierungSonstige.Visible = !hideSonstiges;

            cmbFinanzierung.Text = resetFinanzierung ? "" : cmbFinanzierung.Text;
            cmbGemeinde.Text = hideGemeinde ?  "" : cmbGemeinde.Text;
            cmbBundesland.Text = hideBundesland? "" : cmbBundesland.Text;
            cmbLand.Text = hideLand ? "" : cmbLand.Text;
            txtFinanzierungSonstige.Text = hideSonstiges ? "" : txtFinanzierungSonstige.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            _rNew = _dt.NewSTAMP_KostentragungenRow();
            _rNew.ID = Guid.NewGuid();
            _rNew.Finanzierung = "";
            _rNew.FinanzierungSonstige = "";
            _rNew.GueltigVon = AufenthaltVon;
            if (AufenthaltBis != null)
            {
                _rNew.GueltigBis = (DateTime) AufenthaltBis;
            }
            else
            {
                _rNew.SetGueltigBisNull();
            }
            _rNew.Deleted = false;
            _rNew.IDAufenthalt = IDAufenthalt;
            _rNew.CreatedUser = Guid.NewGuid();
            _rNew.CreatedDate = DateTime.Now;
            _rNew.UpdatedUser = _rNew.CreatedUser;
            _rNew.LastUpdateDate = _rNew.CreatedDate;
            _dt.Rows.Add(_rNew);
            dgKostentragungen.Refresh();

            IsDirty = true;

            foreach (UltraGridRow row in dgKostentragungen.Rows)
            {
                if ((Guid)row.Cells["ID"].Value == _rNew.ID)
                {
                    row.Activated = true;
                    row.Selected = true;
                    ShowDetails();
                    //SetUI(false, true, true, true, true);
                    //cmbFinanzierung_ValueChanged(sender, e);
                    ValueChanged(sender, e);
                    break;
                }
            }
        }

        private DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (_r != null)
            {
                UltraGridTools.DeleteCurrentSelectedRow(dgKostentragungen, true);
                _r = null;
                OnValueChanged(sender, e);
                ValueChanged(sender, e);
                gbDetails.Visible = false;
            }
        }
    }
}
