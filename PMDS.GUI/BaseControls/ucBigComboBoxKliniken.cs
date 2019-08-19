using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using VirtualKeyboard;
using PMDS.Global.db.Patient;



namespace PMDS.GUI.BaseControls
{

    public partial class ucBigComboBoxKliniken : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler       SelectionChanged;
        public new event EventHandler   TextChanged;
        public event EventHandler       AfterDropDown;
        public event EventHandler       AfterCloseUp;
        public event EventHandler       SearchClicked;

        private bool _PlayClickSound = true;





        public bool PlayClickSound
        {
            get { return _PlayClickSound; }
            set { _PlayClickSound = value; }
        }

        public ucBigComboBoxKliniken()
        {
            InitializeComponent();
            cbMain.ButtonsRight[1].Visible = false;     // Default kein Suchenbutton sichtbar
        }

        public ValueListItemsCollection Items
        {
            get
            {
                return cbMain.Items;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Suchenbutton aktivieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ShowSearchButton
        {
            set
            {
                cbMain.ButtonsRight[1].Visible = value;
                cbMain.ButtonsRight[0].Visible = !value;
            }
        }


        private void cbMain_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if(e.Button.Key == "v")
                cbMain.DropDown();
            if (e.Button.Key == "s")
            {
                PlayClick();
                if (SearchClicked != null)
                    SearchClicked(this, EventArgs.Empty);
            }

        }

        public ValueListItem SelectedItem { get { return cbMain.SelectedItem; } set { cbMain.SelectedItem = value; } }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ID ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid ID
        {
            get
            {
                if (cbMain.Value == null)
                    return Guid.Empty;
                else
                    return (Guid)cbMain.Value;
            }
            set
            {
                PlayClickSound = false;
                if (value == Guid.Empty)
                    cbMain.Value = null;
                else
                    cbMain.Value = value;
                PlayClickSound = true ;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktueller Text der Combo
        /// </summary>
        //----------------------------------------------------------------------------
        public new string Text
        {
            get
            {
                return cbMain.Text;
            }
            set
            {
                cbMain.Text = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return cbMain.Appearance.BackColor;
            }
            set
            {
                cbMain.Appearance.BackColor = value;
            }
        }

        private void cbMain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PlayClick()
        {
            if (_PlayClickSound)
                ucVKey.PlayKlick();
        }

        private void cbMain_SelectionChanged(object sender, EventArgs e)
        {
            if (cbMain.Focused)
            {
                 dsKlinik.KlinikRow rKlinik = (dsKlinik.KlinikRow)this.cbMain.SelectedItem.Tag;
                this.KlinikSelectionChanged(rKlinik.ID);
            }
        }
        public  void KlinikSelectionChanged(System.Guid IDKlinik)
        {
            PMDS.Global.ENV.IDKlinik = IDKlinik;
            PlayClick();
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        private void cbMain_BeforeDropDown(object sender, CancelEventArgs e)
        {
            PlayClick();
        }

        private void cbMain_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, EventArgs.Empty);
        }

        private void cbMain_AfterDropDown(object sender, EventArgs e)
        {
            if (AfterDropDown != null)
                AfterDropDown(this, EventArgs.Empty);
        }

        private void cbMain_AfterCloseUp(object sender, EventArgs e)
        {
            if (AfterCloseUp != null)
                AfterCloseUp(this, EventArgs.Empty);
        }

        private void cbMain_AfterEditorButtonCloseUp(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
           
           
        }

        public void loadComboKlinikenUsr()
        {
            this.btnFocus.Focus();
            this.cbMain.Items.Clear();
            //this.tKlinikenUser.Clear();

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow> lstrBenutzerKlinikDistinct = new System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow>();
            dsBenutzerEinrichtung dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung();
            PMDS.DB.Patient.DBBenutzerEinrichtung DBBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung();
            DBBenutzerEinrichtung1.initControl();

            // IDKlinik default auslesen
            DBBenutzerEinrichtung1.getBenutzerEinrichtung(PMDS.Global.ENV.USERID, dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
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
                Infragistics.Win.ValueListItem itemKlinik = this.cbMain.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                itemKlinik.Tag = rKlinik;

                //PMDS.Data.Patient.dsKlinik.KlinikRow rKlinikNew = (PMDS.Data.Patient.dsKlinik.KlinikRow)this.tKlinikenUser.NewRow();
                //rKlinikNew.ItemArray = rKlinik.ItemArray;
                //this.tKlinikenUser.Rows.Add(rKlinikNew);

                if (rBenEinr.Default)
                {
                    this.cbMain.SelectedItem = itemKlinik;
                    rSelectKlinik = rKlinik;
                    PMDS.Global.ENV.IDKlinik = rSelectKlinik.ID;
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
                    this.cbMain.SelectedItem = firstKlinik;
                    rSelectKlinik = rFirstKlinik;
                    PMDS.Global.ENV.IDKlinik = rSelectKlinik.ID;
                }
            }

            if (rSelectKlinik != null)
                this.KlinikSelectionChanged(rSelectKlinik.ID);
        }
        public void loadComboAllKliniken()
        {
            this.btnFocus.Focus();
            this.cbMain.Items.Clear();
            //this.tKlinikenUser.Clear();

            // Cbo Heime befüllen
            dsKlinik dsKlinik1 = new dsKlinik();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);

            Infragistics.Win.ValueListItem firstKlinik = null;
             dsKlinik.KlinikRow rSelectKlinik = null;
            foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
            {
                Infragistics.Win.ValueListItem itemKlinik = this.cbMain.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                itemKlinik.Tag = rKlinik;

                //PMDS.Data.Patient.dsKlinik.KlinikRow rKlinikNew = (PMDS.Data.Patient.dsKlinik.KlinikRow)this.tKlinikenUser.NewRow();
                //rKlinikNew.ItemArray = rKlinik.ItemArray;
                //this.tKlinikenUser.Rows.Add(rKlinikNew);

                if (firstKlinik == null)
                {
                    firstKlinik = itemKlinik;
                    this.cbMain.SelectedItem = itemKlinik;
                    rSelectKlinik = rKlinik;
                    PMDS.Global.ENV.IDKlinik = rSelectKlinik.ID;
                }
            }
            if (rSelectKlinik != null)
                this.KlinikSelectionChanged(rSelectKlinik.ID);
        }

        private void klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadComboKlinikenUsr();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void alleKlinikenLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadComboAllKliniken();
            }
            catch (Exception ex)
            {
               PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
