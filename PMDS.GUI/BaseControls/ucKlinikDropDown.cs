using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Data.Global;
using PMDS.Global.db.Patient;



namespace PMDS.GUI.BaseControls
{


    public partial class ucKlinikDropDown : QS2.Desktop.ControlManagment.BaseControl
    {



        public ucKlinikDropDown()
        {
            InitializeComponent();
        }

        private void ucKlinikDropDown_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public void loadData()
        {
            try
            {
                this.dsKlinik1.Clear();



            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public void loadComboKlinikenUsr()
        {
            this.dsKlinik1.Clear();

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow> lstrBenutzerKlinikDistinct = new System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow>();
            dsBenutzerEinrichtung dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung();
            PMDS.DB.Patient.DBBenutzerEinrichtung DBBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung();
            DBBenutzerEinrichtung1.initControl();

            // IDKlinik default auslesen
            DBBenutzerEinrichtung1.getBenutzerEinrichtung(ENV.USERID, dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in dsBenutzerEinrichtung1.BenutzerEinrichtung)
            {
                bool IDKlinikExists = false;
                foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenutzerKlinik in lstrBenutzerKlinikDistinct)
                {
                    if (rBenutzerKlinik.IDEinrichtung.Equals(rBenEinr.IDEinrichtung))
                        IDKlinikExists = true;
                }
                if (!IDKlinikExists)
                    lstrBenutzerKlinikDistinct.Add(rBenEinr);
            }

            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in lstrBenutzerKlinikDistinct)
            {
                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(rBenEinr.IDEinrichtung, true);

                dsKlinik.KlinikRow rKlinikNew = (dsKlinik.KlinikRow)this.dsKlinik1.Klinik.NewRow();
                rKlinikNew.ItemArray = rKlinik.ItemArray;
                this.dsKlinik1.Klinik.Rows.Add(rKlinikNew);
            }

            this.dropDownKliniken.Refresh();
        }
        public void loadComboAllKliniken()
        {
            this.dsKlinik1.Clear();
            dsKlinik dsKlinik1 = new dsKlinik();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);

            foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
            {
                dsKlinik.KlinikRow rKlinikNew = (dsKlinik.KlinikRow)this.dsKlinik1.Klinik.NewRow();
                rKlinikNew.ItemArray = rKlinik.ItemArray;
                this.dsKlinik1.Klinik.Rows.Add(rKlinikNew);

            }
            this.dropDownKliniken.Refresh();
        }


        public void clearData()
        {
            this.dsKlinik1.Clear();
            this.dropDownKliniken.Refresh();
        }

    }
}
