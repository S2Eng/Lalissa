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

namespace PMDS.GUI.STAMP
{
    public partial class ucSTAMPData : UserControl
    {
        private Guid IDAufenthalt = Guid.Empty;

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

        public void Init(Guid IDAufenthalt)
        {
            try
            {
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
                this.dgKostentragungen.DataSource = _dt;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSTAMPData.LoadData: " + ex.ToString());
            }
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
            int i = 0;
            UltraGridRow row = this.dgKostentragungen.ActiveRow;
            if (row != null)
            {
                //Reihenfolge einhalten, Finanzierung zum Schluss!!!
                this.txtFinanzierungSonstige.Text = row.Cells["FinanzierungSonstige"].Text;
                this.cmbGemeinde.Text = row.Cells["Gemeinde"].Text;
                this.cmbBundesland.Text = row.Cells["Bundesland"].Text;
                this.cmbLand.Text = row.Cells["Land"].Text;
                this.dtGueltigVon.Value = row.Cells["GueltigVon"].Value;
                this.dtGueltigBis.Value = row.Cells["GueltigBis"].Value;
                this.cmbFinanzierung.Text = row.Cells["Finanzierung"].Text;

                _r = _dt.FindByID(new Guid(row.Cells["ID"].Text));

            }
        }

        private void cmbFinanzierung_ValueChanged(object sender, EventArgs e)
        {
            if (cmbFinanzierung.Text.sEquals("Selbstzahler") || cmbFinanzierung.Text.sEquals("Bund") || cmbFinanzierung.Text.sEquals("Leistungszuerkennungsverfahren läuft"))
            {
                SetUI(false, true, true, true, true);
            }
            else if (cmbFinanzierung.Text.sEquals("§13(1) SHG") || cmbFinanzierung.Text.sEquals("§13(1) SHG iVm. §2(1) LEVO-SHG") || cmbFinanzierung.Text.sEquals("§19 StBHG"))
            {
                SetUI(false, false, true, true, true);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_r != null)
            {
                //in DB Speichern für geänderte Row (Insert oder Update)
                _r.Finanzierung = cmbFinanzierung.Text;
                _r.Finanzierung = cmbFinanzierung.Text;
                _r.FinanzierungSonstige = txtFinanzierungSonstige.Text;
                _r.GueltigVon = dtGueltigVon.DateTime;
                _r.GueltigBis = dtGueltigBis.DateTime;
                _r.Gemeinde = cmbGemeinde.Text;
                _r.Bundesland = cmbBundesland.Text;
                _r.Land = cmbLand.Text;
                _r.LastUpdateDate = DateTime.Now;
                dgKostentragungen.Refresh();

                SaveData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            _rNew = _dt.NewSTAMP_KostentragungenRow();
            _rNew.ID = Guid.NewGuid();
            _rNew.Finanzierung = "";
            _rNew.FinanzierungSonstige = "";
            _rNew.GueltigVon = DateTime.Now;
            //_rNew.GueltigBis = null;
            _rNew.Deleted = false;
            _rNew.IDAufenthalt = IDAufenthalt;
            _rNew.CreatedUser = Guid.NewGuid();
            _rNew.CreatedDate = DateTime.Now;
            _rNew.UpdatedUser = _r.CreatedUser;
            _rNew.LastUpdateDate = _r.CreatedDate;
            _dt.Rows.Add(_rNew);
            dgKostentragungen.Refresh();
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

        private void ucSTAMPData_Load(object sender, EventArgs e)
        {

        }
    }
}
