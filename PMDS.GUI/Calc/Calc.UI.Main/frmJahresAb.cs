using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI.Admin
{


    public partial class frmJahresAb : QS2.Desktop.ControlManagment.baseForm 
    {

        private PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
        public bool apport = true;



        public eTyp typ = new eTyp();
        public enum eTyp
        {
            depot = 0,
            booking = 1
        }

        public frmJahresAb()
        {
            InitializeComponent();
        }

        private void frmJahresAb_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            this.dtBis.DateTime = DateTime.Now.Date;
            
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rActuelKlinik = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

            if (this.typ == eTyp.depot  )
            {
                this.chkNurAbgerech.Visible  = true;
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahresabschluss Depotgeld für ") + rActuelKlinik.Bezeichnung.Trim() + "";
            }

            else if (this.typ == eTyp.booking)
            {
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahreabschluß Buchungen");
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahreabschluß Buchungen für ") + rActuelKlinik.Bezeichnung.Trim() + "";
            }

        }

        private void butStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.dtBis.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Datum eingegeben!", "Jahresabschluß");
                    return;
                }
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Jahresabschluss wirklich durchführen?", "Jahresabschluß", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.apport = false;
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

        private void btnApport_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
