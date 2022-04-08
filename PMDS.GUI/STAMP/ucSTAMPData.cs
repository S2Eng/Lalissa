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
using S2Extensions;

namespace PMDS.GUI.STAMP
{
    public partial class ucSTAMPData : UserControl
    {
        private Guid IDAufenthalt = Guid.Empty;
        private DataTable GridSource = new DataTable();

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
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var kts = (from kt in db.STAMP_Kostentragungen
                               where kt.IDAufenthalt == this.IDAufenthalt
                               select new
                               {
                                   kt.ID,
                                   kt.IDAufenthalt,
                                   kt.Finanzierung,
                                   kt.FinanzierungSonstige,
                                   kt.GueltigVon,
                                   kt.GueltigBis,
                                   kt.Bundesland,
                                   kt.Gemeinde,
                                   kt.CreatedUser,
                                   kt.CreatedDate,
                                   kt.LastUpdateDate,
                                   Modified = RowStatus.unchanged
                               }).ToList();

                    GridSource = LINQToDataTable(kts);
                    this.dgKostentragungen.DataSource = GridSource;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSTAMPData.LoadData: " + ex.ToString());
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

        private bool SaveData()
        {
            try
            {



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
                //this.cmbBundesland.Text = row.Cells["Land"].Text;
                this.dtGueltigVon.Value = row.Cells["GueltigVon"].Value;
                this.dtGueltigBis.Value = row.Cells["GueltigBis"].Value;
                this.cmbFinanzierung.Text = row.Cells["Finanzierung"].Text;
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
            UltraGridRow row = this.dgKostentragungen.ActiveRow;

            if (row != null)
            {
                row.Cells["Finanzierung"].Value = cmbFinanzierung.Text;
                row.Cells["FinanzierungSonstige"].Value = txtFinanzierungSonstige.Text;
                row.Cells["GueltigVon"].Value = dtGueltigVon.DateTime;
                row.Cells["GueltigBis"].Value = dtGueltigBis.DateTime;
                row.Cells["Gemeinde"].Value = cmbGemeinde.Text;
                row.Cells["Bundesland"].Value = cmbBundesland.Text;
                //row.Cells["Land"].Value = cmbLand.Text;
                row.Cells["LastUpdateDate"].Value = DateTime.Now; 
            }
            dgKostentragungen.Refresh();

            //in DB Speichern für geänderte Row (Insert oder Update)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GridSource.Rows.Add();
            foreach (DataRow r in GridSource.Rows)
            {

               

            }

        }
    }
}
