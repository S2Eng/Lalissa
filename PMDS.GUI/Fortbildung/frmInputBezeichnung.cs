using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;




namespace PMDS.GUI.Fortbildung
{


    public partial class frmInputBezeichnung : Form
    {

        public bool abort = true;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();








        public frmInputBezeichnung()
        {
            InitializeComponent();
        }

        private void frmSelectBenutzer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }


        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

            }
            catch (Exception ex)
            {
                throw new Exception("frmInputBezeichnung.initControl: " + ex.ToString());
            }
        }

        public bool selectData()
        {
            try
            {
                if (this.txtBezeichnung.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung.: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmInputBezeichnung.selectData: " + ex.ToString());
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.selectData())
                {
                    this.abort = false;
                    this.Close();
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
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

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
