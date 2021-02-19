using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace PMDS.Global
{



    public partial class frmProtDS : QS2.Desktop.ControlManagment.baseForm 
    {

        public   DataSet _db  = new DataSet ();


        public frmProtDS()
        {
            InitializeComponent();
        }

        private void frmProtDS_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public  void addLogDS(bool erwAnsicht )
        {
            this.cboDB.Items.Clear();
            foreach (DataTable t in _db.Tables)
            {
                Infragistics.Win.ValueListItem itm = this.cboDB.Items.Add(System.Guid .NewGuid ().ToString (), t.TableName);
                itm.Tag = t;
                if (t.TableName == "Klient")
                    cboDB.SelectedItem = itm;
                else if (t.TableName == "fields")
                    cboDB.SelectedItem = itm;
            }
           
            this.ultraGrid1.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            PMDS.Global.UIGlobal.setFilterGrid(this.ultraGrid1);
            this.loadDB();
        }
        public void loadTable(string tableName)
        {
            foreach (Infragistics.Win.ValueListItem itm in this.cboDB.Items)
            {
                DataTable t = (DataTable)itm.Tag;
                if (t.TableName == tableName)
                    cboDB.SelectedItem = itm;
            }

            this.loadDB();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cboDB_ValueChanged(object sender, EventArgs e)
        {
            if (cboDB.Focused)
            {
                this.loadDB();
            }
        }
        private void loadDB()
        {
            if ( cboDB.SelectedItem != null)
            {
                DataTable t = (DataTable)cboDB.SelectedItem.Tag;
                this.ultraGrid1.DataSource = t;
                this.ultraGrid1.DataBind();
            }
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpalteKopieren_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveCell != null)
            {
                Clipboard.SetDataObject((string)this.ultraGrid1.ActiveCell.Value.ToString (), true);
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Spalte ausgewählt!", "Spalte kopieren");
            }
            
        }

    }
}
