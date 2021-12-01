using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI.Admin
{


    public partial class ucCalcKlientenSelect : QS2.Desktop.ControlManagment.BaseControl
    {
        public bool IsLoaded = false;
        public PMDS.GUI.BaseControls.ucKlientenElement SavedSelectedTabPrev;
        public ucMainCalc mainWindow = null;


                
        public ucCalcKlientenSelect()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            this.ucKlientenverwaltung3.mainWindow = this;

            ucKlientenverwaltung3.loadFormInit();
            this.ucKlienten2.typ = eSendMain.abrechnung;
            
            //this.ucKlienten2.loadKlienten(true, new PMDS.Data.Patient.dsPatientStation.PatientDataTable(),
            //                                false , true , false, "Alle Klienten" );
            this.ucKlienten2.loadComboAuswahl();
            this.ucKlienten2.checkVonBis(true, false);

            ENV.evklinikChanged += new klinikChanged(this.klinikChanged);
            //<20120213>
            //dsKlinik.KlinikRow rKlinik = this.mainWindow.ucHeader1.ucKlinikCbo1.doSelectedKlinik(false);
            //if (rKlinik != null)
            //{
            //    //this.ucKlienten2.loadProdBewerber(false, "Alle Klienten");
            //}
            //else
            //{
            //    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Keine Kliniken vorhanden!");
            //}

            ENV.selKlienten += new selKlientenDelegate(this.setFilterKlienten);

            this.ucKlientenverwaltung3.setTabAktivFirst();
            this.setKlientenEinAus("1");
            this.ucKlientenverwaltung3.buttKlientOnOff(false, "");

            dsKlinik.KlinikRow rKlinik = this.mainWindow.ucHeader1.ucKlinikCbo1.doSelectedKlinik(false);
            if (rKlinik != null)
            {
                //this.ucKlienten2.loadProdBewerber(false, "Alle Klienten");
            }
            else
            {
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Keine Kliniken vorhanden!");
            }

            this.IsLoaded = true;

            this.ucKlientenverwaltung3.IsLoaded = true;
       }

        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {
            this.ucKlienten2.LoadListklienten(false);
        }
        public bool  setFilterKlienten(eSendMain typ, List<string> filterString, bool suche,   object obj)
        {
            this.ucKlientenverwaltung3.InitTabControl(this.ucKlientenverwaltung3._currentMode);

            if (typ == eSendMain.checkEdited)
                return this.isSaved();
            else if (typ == eSendMain.singleElementActivated )
            {
                if (!suche)
                {
                    this.ucKlientenverwaltung3.buttKlientOnOff(suche, "");
                    this.ucKlientenverwaltung3.activateControl((int)ErfassungMode.RechnungenKlient);
                }
                else
                {
                    this.ucKlientenverwaltung3.activateControl((int)this.ucKlientenverwaltung3._currentModePrevKlient);
                    this.ucKlientenverwaltung3.buttKlientOnOff(suche, (string)obj.ToString());
                }
                return true;
            }
            else
            {
                this.ucKlientenverwaltung3.checkKlientIsSelected(this.ucKlientenverwaltung3._currentMode);
                //if (typ == eSendMain.historieOnOff)
                this.ucKlientenverwaltung3.setUIHistorieOnOff();

                if (suche)
                {
                    this.ucKlientenverwaltung3.ucRechnungenKlient1.Klienten.Clear();
                    List<Guid> Klienten = new List<Guid>();
                    this.ucKlientenverwaltung3.ucRechnungenKlient1.Klienten = Klienten;

                    this.ucKlientenverwaltung3.activateControl((int)ErfassungMode.RechnungenKlient);
                    this.ucKlienten2.SavedSelectedTab = null;
                }
                //if (this.ucKlientenverwaltung3._currentMode == ErfassungMode.RechnungenKlient)
                if ( typ == eSendMain.setIDMultiElement )
                {
                    this.ucKlientenverwaltung3.activateControl((int)ErfassungMode.RechnungenKlient);
                    List<Guid> Klienten = new List<Guid>();
                    foreach (string sKlient in filterString)
                        Klienten.Add(new System.Guid(sKlient.ToString()));
                    this.ucKlientenverwaltung3.ucRechnungenKlient1.Klienten = Klienten;
                }
                else if ( typ == eSendMain.setIDSingleElement  )
                {
                    ucKlientenverwaltung3.doAction(this.ucKlientenverwaltung3._currentMode, ucCalcKlienten.eAction.changeID);
                }

                this.ucKlientenverwaltung3.ucRechnungenKlient1.ucCalcs1.doSum();

                this.SavedSelectedTabPrev = this.ucKlienten2.SavedSelectedTab;
                return true;
            }
        }
        public bool isSaved()
        {
            if (!this.ucKlientenverwaltung3.changingTab(this.ucKlientenverwaltung3._currentMode))
            {
                if (this.SavedSelectedTabPrev != null)
                    this.ucKlienten2.SetTabSelected(this.SavedSelectedTabPrev, true, false);
                return false ;
            }
            return true ;
        }
        private void btnListKlientenEinAus_Click(object sender, EventArgs e)
        {
            this.setKlientenEinAus((string)btnListKlientenEinAus.Tag);
        }
        public void setKlientenEinAus(string OnOff)
        {
            if (OnOff == "0")
            {
                this.panelKlienten.Width = 18;
                this.panelKlienten2.Visible = false;
                this.btnListKlientenEinAus.Tag = "1";
                this.btnListKlientenEinAus.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            }
            else
            {
                this.panelKlienten.Width = 205;
                this.panelKlienten2.Visible = true;
                this.btnListKlientenEinAus.Tag = "0";
                this.btnListKlientenEinAus.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);
            }
        }

        private void lblKlientenausahl_Click(object sender, EventArgs e)
        {
            this.setKlientenEinAus((string)btnListKlientenEinAus.Tag);
        }

        private void ucCalcKlientenSelect_VisibleChanged(object sender, EventArgs e)
        {

        }

    }
}
