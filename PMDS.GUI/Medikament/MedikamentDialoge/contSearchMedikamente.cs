using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Patient;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;




namespace PMDS.GUI.Medikament
{



    public partial class contSearchMedikamente : UserControl
    {

        public bool abort = true;
        public frmSearchMedikamente MainWindow = null;
        public dsMedikament.MedikamentRow rSelMedikament = null;
        PMDS.DB.DBMedikament db = new DB.DBMedikament();
        public PMDS.UI.Sitemap.UIFct UIFct1 = new UI.Sitemap.UIFct();
        public static bool refreshMedikamenteInGrid = false;








        public contSearchMedikamente()
        {
            InitializeComponent();
        }

        private void contSearchMedikamente_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.db.initControl();

                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                this.btnAddMedikament.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);

                foreach (UltraGridColumn col in this.dgMedikamente.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }

                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.BezeichnungColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.PackungsgroesseColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.PackungseinheitColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.PackungsanzahlColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.BezeichnungColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.ErstattungscodeColumn.ColumnName].Hidden = false;
                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.KassenzeichenColumn.ColumnName].Hidden = false;

                this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.BezeichnungColumn.ColumnName].Width = 150;
            }
            catch (Exception ex)
            {
                throw new Exception("contSearchMedikamente.initControl: " + ex.ToString());
            }
            finally
            {
            }
        }

        public void SelectMedikament(bool ShowMsgBox)
        {
            try
            {
                this.rSelMedikament = null;
                this.rSelMedikament = this.getSelectedRow(ShowMsgBox);
                if (this.rSelMedikament != null)
                {
                    this.abort = false;
                    this.MainWindow.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contSearchMedikamente.SelectMedikament: " + ex.ToString());
            }
        }

        public dsMedikament.MedikamentRow getSelectedRow(bool msgBox)
        {
            try
            {
                if (this.dgMedikamente.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.dgMedikamente.ActiveRow.ListObject;
                    dsMedikament.MedikamentRow rSelBenEinricht = (dsMedikament.MedikamentRow)v.Row;
                    return rSelBenEinricht;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contSearchMedikamente.getSelectedRow: " + ex.ToString());
            }
        }

        public void SearchMedikamente()
        {
            try
            {
                this.dsMedikament1.Clear();
                this.db.getMedikament(System.Guid.Empty, this.dsMedikament1, DB.DBMedikament.eTypeSelMedikament.Bezeichnung, "", this.txtMedikament.Text.Trim());
                this.dgMedikamente.Refresh();

                if (this.dsMedikament1.Medikament.Rows.Count > 0)
                {
                    this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.BezeichnungColumn.ColumnName].Header.Caption = "Bezeichnung (" + this.dsMedikament1.Medikament.Rows.Count.ToString() + ")";
                }
                else
                {
                    this.dgMedikamente.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.BezeichnungColumn.ColumnName].Header.Caption = "Bezeichnung";
                }

                this.dgMedikamente.ActiveRow = null;

            }
            catch (Exception ex)
            {
                throw new Exception("contSearchMedikamente.SearchMedikamente: " + ex.ToString());
            }
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SearchMedikamente();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SelectMedikament(true);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.MainWindow.Close();


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgMedikamente_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIFct1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgMedikamente))
                {
                    this.SelectMedikament(false);
                }
               
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnAddMedikament_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedikamentEdit frm = new frmMedikamentEdit();
                frm.New();

                DialogResult res = frm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    //this.rSelMedikament = frm.ucMedikamentEdit1.ROW;
                    this.dsMedikament1.Clear();
                    this.db.getMedikament(frm.ucMedikamentEdit1.ROW.ID, this.dsMedikament1, DB.DBMedikament.eTypeSelMedikament.ID , "", "");
                    this.dgMedikamente.Refresh();
                    contSearchMedikamente.refreshMedikamenteInGrid = true;

                    //this.abort = false;
                    //this.MainWindow.Close();
                }
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}
