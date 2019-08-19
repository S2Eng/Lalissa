using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace PMDS.GUI.Klient
{


    public partial class cboAuswahllisteMulti : UserControl
    {
        public string _Gruppe = "";

        public bool isInitialized = false;
        public string colAuswahl = "Auswahl";
        public PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        public event EventHandler AfterCheck;





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
                    //foreach (PMDS.db.Entities.AuswahlListe rAuswahlListe in tAuswahlListe)
                    //{
                    //}
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
                string sSelectedRows = "";

                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
                    if ((bool)rowGrid.Cells[this.colAuswahl.Trim()].Value == true)
                    {
                        sSelectedRows += rAuswahlListe.Bezeichnung.ToString() + ";";
                    }
                }

                return sSelectedRows;
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
                string sSelectedRows = "";

                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
                    if ((bool)rowGrid.Cells[this.colAuswahl.Trim()].Value == true)
                    {
                        sSelectedRows += rAuswahlListe.ID.ToString() + ";";
                    }
                }

                return sSelectedRows;
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
                
                foreach (string IDSelList in lstSelLists)
                {
                    foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                    {
                        PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
                        if (rAuswahlListe.Bezeichnung.Trim().Equals(IDSelList.Trim()))
                        {
                            rowGrid.Cells[this.colAuswahl.Trim()].Value = true;
                        }
                    }
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

                foreach (string IDSelList in lstSelLists)
                {
                    Guid IDSelListGuid = new Guid(IDSelList.Trim());
                    foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                    {
                        PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
                        if (rAuswahlListe.ID.Equals(IDSelListGuid))
                        {
                            rowGrid.Cells[this.colAuswahl.Trim()].Value = true;
                        }
                    }
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
                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
                    if ((bool)rowGrid.Cells[this.colAuswahl.Trim()].Value == true)
                    {
                        this.dropDownSelList.Text += rowGrid.Cells["Bezeichnung"].Value.ToString().Trim() + ";";
                    }
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
                foreach (UltraGridRow rowGrid in this.gridAuswahllisten.Rows)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahlListe = (PMDS.db.Entities.AuswahlListe)(rowGrid.ListObject);
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
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colAuswahl.Trim().ToLower()))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

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
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colAuswahl.Trim().ToLower()))
                {
                    this.gridAuswahllisten.UpdateData();
                    this.setSelectedTxt();
                    if (this.AfterCheck != null)
                    {
                        this.AfterCheck(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
