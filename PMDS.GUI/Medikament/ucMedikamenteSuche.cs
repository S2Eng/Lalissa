using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.ERSystem;
using System.Data.SqlClient;
using System.Data.Common;



namespace PMDS.GUI.Medikament
{
    public partial class ucMedikamenteSuche : UserControl
    {

        public frmMedikamenteSuche mainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        




        public ucMedikamenteSuche()
        {
            InitializeComponent();
        }

        private void ucMedikamenteSuche_Load(object sender, EventArgs e)
        {

        }



        public void initControl()
        {
            try
            {
                this.mainWindow.CancelButton = this.btnClose;
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                foreach (UltraGridColumn col in this.gridSearch.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }

                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten");
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Hidden = false;
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Width = 180;
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Header.VisiblePosition = 1;

                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Hidden = false;
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Width = 300;
                this.gridSearch.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Header.VisiblePosition = 2;

                this.dsKlientenliste1.Clear();
                this.lblFound.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteSuche.initControl: " + ex.ToString());
            }
        }

        public void search()
        {
            try
            {
                if (this.txtSearch.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Suchtext: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return;
                }

                this.dsKlientenliste1.Clear();
                this.lblFound.Text = "";

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    DataTable dt = this.b.getPatientsByMedikament(this.txtSearch.Text.Trim(), db);
                    foreach (DataRow r in dt.Rows)
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNewUI = this.sqlManange1.getNewUI(ref this.dsKlientenliste1);
                        rNewUI.Bezeichnung = r["Patient"].ToString();
                        rNewUI.Beschreibung = r["Medikament"].ToString();
                        rNewUI.ID = System.Guid.NewGuid();
                        rNewUI.IDMedDatenWundeKopf = new System.Guid(r["IDAufenthalt"].ToString());
                        rNewUI.ID2 = new System.Guid(r["IDMedikament"].ToString()); 
                    }
                }

                this.gridSearch.Refresh();
                this.gridSearch.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.gridSearch.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BezeichnungColumn.ColumnName, false);
                this.gridSearch.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BeschreibungColumn.ColumnName, false);

                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsKlientenliste1.UI.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteSuche.search: " + ex.ToString());
            }
        }


        private void gridPatients_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(("xyxy").ToLower()))
                {
                    e.Cell.Activation = Activation.NoEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridPatients_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = true;
        }
        private void gridPatients_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridSearch))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void gridPatients_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridSearch))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.search();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
