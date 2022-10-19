using System;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using S2Extensions;

namespace PMDS.GUI.Klient
{
    public partial class cboAuswahllisteMulti : UserControl
    {
        private string _Gruppe = "";
        private string colAuswahl = "Auswahl";
        private PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();

        public event EventHandler AfterCheck;
        public bool isInitialized;
        
        public cboAuswahllisteMulti()
        {
            InitializeComponent();
        }

        private void cboSprachenMulti_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string Gruppe)
        {
            try
            {
                if (!this.isInitialized)
                {
                    this._Gruppe = Gruppe;
                    this.dropDownSelList.PopupItem = (Infragistics.Win.IPopupItem)this.ultraToolbarsManager1.Tools["popSelList"];
                    this.dropDownSelList.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.initControl: " + ex.ToString());
            }
        }
        
        public void loadData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    IQueryable <PMDS.db.Entities.AuswahlListe> tAuswahlListe = this.b.GetAuswahlliste(db, this._Gruppe.Trim(), -100000, false);
                    this.auswahlListeBindingSource.DataSource = tAuswahlListe.ToList();
                    this.gridAuswahllisten.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.loadData: " + ex.ToString());
            }
        }

        public string getSelectedRows()
        {
            try
            {
                return (from rowGrid in this.gridAuswahllisten.Rows 
                        let rAuswahlListe = (PMDS.db.Entities.AuswahlListe) (rowGrid.ListObject) 
                        where (bool) rowGrid.Cells[this.colAuswahl.Trim()].Value 
                        select rAuswahlListe).Aggregate("", (current, rAuswahlListe) => current + (rAuswahlListe.Bezeichnung + ";"));
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.getSelectedRows: " + ex.ToString());
            }
        }

        public string getSelectedRowsID()
        {
            try
            {
                return (from rowGrid in this.gridAuswahllisten.Rows 
                    let rAuswahlListe = (PMDS.db.Entities.AuswahlListe) (rowGrid.ListObject) 
                    where (bool) rowGrid.Cells[this.colAuswahl.Trim()].Value 
                    select rAuswahlListe).Aggregate("", (current, rAuswahlListe) => current + (rAuswahlListe.ID + ";"));
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.getSelectedRowsID: " + ex.ToString());
            }
        }

        public void setSelectedRows(string lstColumns)
        {
            try
            {
                this.dropDownSelList.Text = "";
                System.Collections.Generic.List<string> lstSelLists = qs2.core.generic.readStrVariables(lstColumns.Trim());

                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                     rowGrid.Cells[this.colAuswahl.Trim()].Value = false;
                }
                
                foreach (var rowGrid in from IDSelList in lstSelLists 
                            from rowGrid in this.gridAuswahllisten.Rows 
                            let rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject) 
                            where rAuswahlListe.Bezeichnung.Trim().Equals(IDSelList.Trim()) 
                            select rowGrid)
                {
                    rowGrid.Cells[this.colAuswahl.Trim()].Value = true;
                }

                this.setSelectedTxt();
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.setSelectedRows: " + ex.ToString());
            }
        }
        public void setSelectedRowsID(string lstIDColumns)
        {
            try
            {
                this.dropDownSelList.Text = "";
                System.Collections.Generic.List<string> lstSelLists = qs2.core.generic.readStrVariables(lstIDColumns.Trim());

                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                    rowGrid.Cells[this.colAuswahl.Trim()].Value = false;
                }

                foreach (var rowGrid in from IDSelList in lstSelLists select new Guid(IDSelList.Trim()) into IDSelListGuid from rowGrid in this.gridAuswahllisten.Rows let rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject) where rAuswahlListe.ID.Equals(IDSelListGuid) select rowGrid)
                {
                    rowGrid.Cells[this.colAuswahl.Trim()].Value = true;
                }

                this.setSelectedTxt();
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.setSelectedRowsID: " + ex.ToString());
            }
        }

        public void setSelectedTxt()
        {
            try
            {
                this.dropDownSelList.Text = "";
                foreach (var rowGrid in this.gridAuswahllisten.Rows.Where(rowGrid => (bool)rowGrid.Cells[this.colAuswahl.Trim()].Value))
                {
                    this.dropDownSelList.Text += rowGrid.Cells["Bezeichnung"].Value.ToString().Trim() + ";";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.setSelectedTxt: " + ex.ToString());
            }
        }

        public void setAllSelectedOnOff(bool bOn)
        {
            try
            {
                this.dropDownSelList.Text = "";
                foreach (var rowGrid in from rowGrid in this.gridAuswahllisten.Rows let rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject) select rowGrid)
                {
                    rowGrid.Cells[this.colAuswahl.Trim()].Value = bOn;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cboSprachenMulti.setAllSelectedOnOff: " + ex.ToString());
            }
        }


        private void gridAuswahllisten_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                e.Cell.Activation = e.Cell.Column.sEquals(this.colAuswahl) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridAuswahllisten_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridAuswahllisten_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.sEquals(this.colAuswahl))
                {
                    this.gridAuswahllisten.UpdateData();
                    this.setSelectedTxt();
                    this.AfterCheck?.Invoke(sender, e);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}
