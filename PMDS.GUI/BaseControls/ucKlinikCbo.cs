using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Patient;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.Patient;
using PMDS.Global.db.ERSystem;
using PMDS.DB;


namespace PMDS.GUI.BaseControls
{
    
    //Kennung=<20120213>
    public partial class ucKlinikCbo : QS2.Desktop.ControlManagment.BaseControl
    {

        //public PMDS.Data.Patient.dsKlinik.KlinikDataTable tKlinikenUser = new PMDS.Data.Patient.dsKlinik.KlinikDataTable();

        public bool allKliniken = false;

        public eTyp typ = new eTyp();
        public enum eTyp
        {
            Calc = 0
        }
        private eTypUI _typUI = eTypUI.none;
        public enum eTypUI
        {
            main = 0,
            sub = 1,

            none = 10
        }


        public ucKlinikCbo()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            try
            {
                if (ENV.adminSecure)
                {
                    this.klinikenNeuLadenToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.klinikenNeuLadenToolStripMenuItem.Visible = true;
                }

                if (ENV.HasRight(UserRights.AlleEinrichtungen))
                {
                    this.alleKlinikenLadenToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.alleKlinikenLadenToolStripMenuItem.Visible = false;
                }

                this.loadComboKlinikenUsr();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void cbKlinik_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbKlinik.Focused)
                {
                    dsKlinik.KlinikRow rSelectKlinik = this.doSelectedKlinik(false);
                 }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public dsKlinik.KlinikRow doSelectedKlinik(bool WithMsgBox)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Infragistics.Win.ValueListItem itemKlinik = this.cbKlinik.SelectedItem;
                dsKlinik.KlinikRow rSelectKlinik = (dsKlinik.KlinikRow)itemKlinik.Tag;
                if (rSelectKlinik != null)
                {
                    if (this.typUI == eTypUI.main)
                    {
                        ENV.IDKlinik = rSelectKlinik.ID;
                        ENV.setCurrentIDAbteilung = System.Guid.Empty;
                        ENV.setIDBereich = System.Guid.Empty;

                        PMDSBusinessRAM bRAM = new PMDSBusinessRAM();
                        bRAM.loadDataStart(true, false, false, true);
                        ENV.fireEventKlinikChanged(rSelectKlinik, this.allKliniken);
                    }
                    return rSelectKlinik;
                }
                else
                {
                    if (this.typUI == eTypUI.main)
                    {
                        ENV.IDKlinik = ENV.IDKlinikNoKlinikSelected;
                        ENV.setCurrentIDAbteilung = System.Guid.Empty;
                        ENV.setIDBereich = System.Guid.Empty;
                        ENV.fireEventKlinikChanged(rSelectKlinik, this.allKliniken);
                    }
                    if (WithMsgBox)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Klinik ausgewählt!");
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public dsKlinik.KlinikRow loadComboKlinikenUsr()
        {
            this.cbKlinik.Items.Clear();
            //this.tKlinikenUser.Clear();

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

            // Cbo Heime befüllen
            bool bKlinikSelected = false;
            Infragistics.Win.ValueListItem firstKlinik = null;
            dsKlinik.KlinikRow rSelectKlinik = null;
            dsKlinik.KlinikRow rFirstKlinik = null;
            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in lstrBenutzerKlinikDistinct)
            {
                 dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(rBenEinr.IDEinrichtung, true);
                Infragistics.Win.ValueListItem itemKlinik = this.cbKlinik.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                itemKlinik.Tag = rKlinik;

                //PMDS.Data.Patient.dsKlinik.KlinikRow rKlinikNew = (PMDS.Data.Patient.dsKlinik.KlinikRow)this.tKlinikenUser.NewRow();
                //rKlinikNew.ItemArray = rKlinik.ItemArray;
                //this.tKlinikenUser.Rows.Add(rKlinikNew);

                if (rBenEinr.Default)
                {
                    this.cbKlinik.SelectedItem = itemKlinik;
                    rSelectKlinik = rKlinik;
                    bKlinikSelected = true;
                }
                if (firstKlinik == null)
                {
                    firstKlinik = itemKlinik;
                    rFirstKlinik = rKlinik;
                }
            }
            if (!bKlinikSelected)
            {
                if (firstKlinik != null)
                {
                    this.cbKlinik.SelectedItem = firstKlinik;
                    rSelectKlinik = rFirstKlinik;
                }
            }

            return rSelectKlinik;
        }
        public dsKlinik.KlinikRow loadComboAllKliniken() 
        {
            this.cbKlinik.Items.Clear();
            //this.tKlinikenUser.Clear();

            // Cbo Heime befüllen
            dsKlinik dsKlinik1 = new dsKlinik();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);

            Infragistics.Win.ValueListItem firstKlinik = null;
            dsKlinik.KlinikRow rSelectKlinik = null;
            foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
            {
                Infragistics.Win.ValueListItem itemKlinik = this.cbKlinik.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                itemKlinik.Tag = rKlinik;

                //PMDS.Data.Patient.dsKlinik.KlinikRow rKlinikNew = (PMDS.Data.Patient.dsKlinik.KlinikRow)this.tKlinikenUser.NewRow();
                //rKlinikNew.ItemArray = rKlinik.ItemArray;
                //this.tKlinikenUser.Rows.Add(rKlinikNew);

                if (firstKlinik == null)
                {
                    firstKlinik = itemKlinik;
                    this.cbKlinik.SelectedItem = itemKlinik;
                    rSelectKlinik = rKlinik;
                }
            }
            return rSelectKlinik;
        }

        private void klinikenNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.allKliniken = false;
                this.loadComboKlinikenUsr();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void alleKlinikenLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.allKliniken = true;
                this.loadComboAllKliniken();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public eTypUI typUI
        {
            get
            {
                return this._typUI;
            }
            set
            {
                this._typUI = value;
            }

        }
    }
}
