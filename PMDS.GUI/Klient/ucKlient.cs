using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;
using System.Linq;



namespace PMDS.GUI
{


    public partial class ucKlient : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
    {

        public bool mainSystm = false;
        public bool isBewerberJN = false;


        private bool _bSignalInProgress = false;
        private bool _medDatenChanged = false;
        private int _iMedizinischerTyp = -1;
        private KlientDetails _klient;
        public event EventHandler ValueChanged;


        public PMDS.UI.Sitemap.UIFct _sitemap = new PMDS.UI.Sitemap.UIFct();
        public List<PMDS.UI.Sitemap.cButt> listButt = new List<PMDS.UI.Sitemap.cButt>();


        //public ucKlientStammdaten ucKlientStammdaten1;
        public ucMedizinischeDaten ucMedizinischeDaten1;
        public ucRegelungen ucRegelungen1;
        public ucDokumenteGegenstaende ucDokumenteGegenstaende1;
        public ucRehabilitation ucRehabilitation1;

        public bool bewerberbeuanlage = false;

        public ucSiteMapKlientenDetails MainWindow = null;
        public bool PictureHasChanged = false;
        public bool PictureDeleted = false;

        public eModeKlient _currentAction = eModeKlient.KlientStammdaten;
        public enum eModeKlient
        {
            KlientStammdaten = 0,
            MedizinischeDaten = 1,
            Regelungen = 2,
            DokuGegenstände = 3,
            Rehabilitation = 4
        }
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();








        public ucKlient()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public void initControl()
        {
            this.ucKlientStammdaten1.MainWindow = this;

            this.tabKlientenakt.Style = UltraTabControlStyle.Wizard;
            this.setUIButtons();
            if ( !this.isBewerberJN && this.mainSystm)
            {
                this.initKlientStammdaten();
                this.initMedizinischeDaten();
                this.initRegelungen();
                this.initDokumenteGegenstaende();
                this.initRehabilitation();

                ENV.MedizinischerStateChanged += new MedizinischeDatenStateChangedDelegate(ENV_MedizinischerStateChanged);
            }
            if (this.isBewerberJN)
            {
                this.panelDokGegen.Visible = false;
                this.panelRegelungen.Visible = false;

                this.initKlientStammdaten();
                this.initMedizinischeDaten();
                this.initRehabilitation();
            }

            this.SwitchTo(eModeKlient.KlientStammdaten);
        }

        void ENV_MedizinischerStateChanged(int iMedizinischerTyp)
        {
            if (_bSignalInProgress)
                return;

            if (_medDatenChanged)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Änderungen in Medizinische Daten gespeichert werden?", "Medizinische Daten", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                    Klient.MEDIZINISCHE_DATEN.Write();
                _medDatenChanged = false;
            }

            Klient.MEDIZINISCHE_DATEN.Read();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if (_klient == null)
                {
                    KlientDetails klientDetails = new KlientDetails();
                    klientDetails._Aerzte._doAllAdresseKontakte2 = true;
                    _klient = klientDetails;
                }
                return _klient;
            }
            set
            {
                _klient = value;
                this.PictureHasChanged = false;
                this.PictureDeleted = false;

                ucKlientStammdaten.lstKontakteChanged.Clear();
                this.ucKlientStammdaten1.Klient = value;
                if (this.ucMedizinischeDaten1 != null) ucMedizinischeDaten1.Klient = value;
                if (this.ucRegelungen1 != null) ucRegelungen1.Klient = value;
                if (this.ucDokumenteGegenstaende1 != null) ucDokumenteGegenstaende1.Klient = value;
                if (this.ucRehabilitation1 != null) ucRehabilitation1.Klient = value;
            }
        }

        public void UpdateGUI()
        {
            ucKlientStammdaten1.UpdateGUI();
            if (this.ucMedizinischeDaten1 != null) ucMedizinischeDaten1.UpdateGUI();
            if (this.ucRegelungen1 != null) ucRegelungen1.UpdateGUI();
            if (this.ucDokumenteGegenstaende1 != null) ucDokumenteGegenstaende1.UpdateGUI();
            if (this.ucRehabilitation1 != null) ucRehabilitation1.UpdateGUI();
        }

        public void setControlsAktivDisable(bool bOn)
        {
            this.ucKlientStammdaten1.setControlsAktivDisable(bOn);
            if (this.ucMedizinischeDaten1 != null) this.ucMedizinischeDaten1.setControlsAktivDisable(bOn);
            if (this.ucRegelungen1 != null) this.ucRegelungen1.setControlsAktivDisable(bOn);
            if (this.ucDokumenteGegenstaende1 != null) this.ucDokumenteGegenstaende1.setControlsAktivDisable(bOn);
            if (this.ucRehabilitation1 != null) this.ucRehabilitation1.setControlsAktivDisable(bOn);
        }

        public void UpdateDATA()
        {
            ucKlientStammdaten1.UpdateDATA();
            if (this.ucMedizinischeDaten1 != null) ucMedizinischeDaten1.UpdateDATA();
            if (this.ucRegelungen1 != null) ucRegelungen1.UpdateDATA();
            if (this.ucDokumenteGegenstaende1 != null) ucDokumenteGegenstaende1.UpdateDATA();
            if (this.ucRehabilitation1 != null) ucRehabilitation1.UpdateDATA();
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public bool ValidateFields()
        {
            return ucKlientStammdaten1.ValidateFields();

            ////Änderung nach 09.05.2007
            //foreach (UltraTab tab in tabKlientenakt.Tabs)
            //{
            //    foreach (Control c in tab.TabPage.Controls)
            //    {
            //        if (c is IWizardPage && !((IWizardPage)c).ValidateFields())
            //        {
            //            bError = true;
            //            return !bError;
            //        }
            //    }
            //}
        }

        public void Write()
        {
            try
            {
                Klient.Write(this.mainSystm, false, this.isBewerberJN);
                if (Klient.Aufenthalt == null)
                    Klient.newAufenthalt();
                if (!this.isBewerberJN)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rAufenthaltAct = (from a in db.Aufenthalt
                                   where a.ID == Klient.Aufenthalt.ID
                                        select new
                                           {
                                               ID = a.ID,
                                            IDUrlaub = a.IDUrlaub
                                           }).First();

                        if (rAufenthaltAct.IDUrlaub != null)
                        {
                            Klient.Aufenthalt.IDUrlaub = rAufenthaltAct.IDUrlaub.Value;
                        }
                        else
                        {
                            Klient.Aufenthalt.IDUrlaub = System.Guid.Empty;
                        }
                    }
                    Klient.WriteAufenthalt(bewerberbeuanlage);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlient.Write: " + ex.ToString());
            }
        }

        public void checkRefresMedDatentypen()
        {
            if (this.mainSystm)
            {
                if (_medDatenChanged)
                {
                    try
                    {
                        SignalMedizinischerStateChanged();
                        _medDatenChanged = false;
                    }
                    catch
                    {
                        _medDatenChanged = false;
                    }
                }
            }

        }
        private void SignalMedizinischerStateChanged()
        {
            try
            {
                _bSignalInProgress = true;          // um Zyklus zu vermeiden
                ENV.SignalMedizinischerStateChanged(_iMedizinischerTyp);
            }
            finally
            {
                _bSignalInProgress = false;
            }
        }

        private MedizinischerTyp GetMedizinischerTyp(int iMedizinischerTyp)
        {
            MedizinischerTyp medTyp = MedizinischerTyp.Sonstige;

            switch (iMedizinischerTyp)
            {
                case (int)MedizinischerTyp.AktuelleDiagnosen:
                    medTyp = MedizinischerTyp.AktuelleDiagnosen;
                    break;
                case (int)MedizinischerTyp.DauerDiagnosen:
                    medTyp = MedizinischerTyp.DauerDiagnosen;
                    break;
                case (int)MedizinischerTyp.Allergien:
                    medTyp = MedizinischerTyp.Allergien;
                    break;
                case (int)MedizinischerTyp.Antikoagulation:
                    medTyp = MedizinischerTyp.Antikoagulation;
                    break;
                case (int)MedizinischerTyp.Unvertraeglichkeiten:
                    medTyp = MedizinischerTyp.Unvertraeglichkeiten;
                    break;
                case (int)MedizinischerTyp.Diabetes:
                    medTyp = MedizinischerTyp.Diabetes;
                    break;
                case (int)MedizinischerTyp.Impfungen:
                    medTyp = MedizinischerTyp.Impfungen;
                    break;
                case (int)MedizinischerTyp.ImplentateProthesen:
                    medTyp = MedizinischerTyp.ImplentateProthesen;
                    break;
                case (int)MedizinischerTyp.Infektionen:
                    medTyp = MedizinischerTyp.Infektionen;
                    break;
                case (int)MedizinischerTyp.KathederSondenStomata:
                    medTyp = MedizinischerTyp.KathederSondenStomata;
                    break;
                case (int)MedizinischerTyp.Kostform:
                    medTyp = MedizinischerTyp.Kostform;
                    break;
                case (int)MedizinischerTyp.Nuechtern:
                    medTyp = MedizinischerTyp.Nuechtern;
                    break;
                case (int)MedizinischerTyp.Suchtmittel:
                    medTyp = MedizinischerTyp.Suchtmittel;
                    break;
                case (int)MedizinischerTyp.Befunde:
                    medTyp = MedizinischerTyp.Befunde;
                    break;
                default:
                    medTyp = MedizinischerTyp.Sonstige;
                    break;
            }

            return medTyp;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged(sender, e);
        }

         private void ucMedizinischeDaten1_MedizinischerStateChanged(int iMedizinischerTyp)
        {
            _iMedizinischerTyp = iMedizinischerTyp;
            _medDatenChanged = true;
        }

        public void layInfragisticOnOff(bool bOn)
        {
                tabKlientenakt.UseAppStyling = bOn;
                this.ucKlientStammdaten1.tabStammdaten.UseAppStyling = bOn;
        
        }

        private void clickButton(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int tabNr = Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag);
                this._sitemap.aktivateButton(this.listButt, tabNr);
                this.SwitchTo((eModeKlient)tabNr);
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
        private void setUIButtons()
        {
            PMDS.UI.Sitemap.cButt itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnKlientenakt;
            itm.nr = Convert.ToInt32(this.btnKlientenakt.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnMedizinischeDaten;
            itm.nr = Convert.ToInt32(this.btnMedizinischeDaten.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnRegelungen;
            itm.nr = Convert.ToInt32(this.btnRegelungen.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnDokGegen;
            itm.nr = Convert.ToInt32(this.btnDokGegen.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnRehabilitation;
            itm.nr = Convert.ToInt32(this.btnRehabilitation.Tag);
            this.listButt.Add(itm);

            this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(this.btnKlientenakt.Tag));

        }

        public void SwitchTo(eModeKlient mode)
        {
            try
            {
                this._currentAction = mode;
                switch (mode)
                {
                    case eModeKlient.KlientStammdaten:
                        if (this.ucKlientStammdaten1 == null) this.initKlientStammdaten();
                        break;

                    case eModeKlient.MedizinischeDaten:
                        if (this.ucMedizinischeDaten1 == null) this.initMedizinischeDaten();
                        break;

                    case eModeKlient.Regelungen:
                        if (this.ucRegelungen1 == null) this.initRegelungen();
                        break;

                    case eModeKlient.DokuGegenstände:
                        if (this.ucDokumenteGegenstaende1 == null) this.initDokumenteGegenstaende();
                        break;

                    case eModeKlient.Rehabilitation:
                        if (this.ucRehabilitation1 == null) this.initRehabilitation();
                        break;
                }

                this.tabKlientenakt.ActiveTab = this.tabKlientenakt.Tabs[(int)mode];
                this.tabKlientenakt.SelectedTab = this.tabKlientenakt.Tabs[(int)mode];
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
        }

        public void checkWriteÄrzteMehrfachauswahl()
        {
            try
            {
                KlientGuiAction KlientGuiAction1 = new KlientGuiAction();
                KlientGuiAction1.checkWriteÄrzteMehrfachauswahl(ref this.ucKlientStammdaten1.lstÄrzteMehrfachauswahl, this.Klient.ID);

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlient.checkWriteÄrzteMehrfachauswahl: " + ex.ToString());
            }
        }

        public void checkWriteDekurs(ref bool writeDekursSprachenChanged, ref string txtSprachenGeändert, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                if (writeDekursSprachenChanged)
                {
                    this.ucKlientStammdaten1.sbChanges.Append(txtSprachenGeändert);
                }
                if (this.ucKlientStammdaten1.sbChanges.ToString().Trim() != "")
                {
                    this.PMDSBusiness1.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientendaten wurden editiert.") + "\n\r" + this.ucKlientStammdaten1.sbChanges.ToString(), this.isBewerberJN, this.Klient.ID, PflegeEintragTyp.Klient);
                }

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "ucKlient.checkWriteDekurs"))
                {
                    this.checkWriteDekurs(ref writeDekursSprachenChanged, ref txtSprachenGeändert);
                }
            }
        }
        public bool writeDekursAbwesenheitsende(Guid IDAufenthalt)
        {
            try
            {
                if (!this.isBewerberJN)
                {
                    string sTxtLetzteAbwesenheit = "";
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.DB.PMDSBusiness b2 = new PMDS.DB.PMDSBusiness();
                        PMDS.db.Entities.UrlaubVerlauf rUrlaubVerlauf = b2.getLetzteAbwesenheit(this.Klient.Aufenthalt.ID, db);
                        if (rUrlaubVerlauf != null)
                        {
                            string sTxtStartDate = "";
                            if (rUrlaubVerlauf.StartDatum != null)
                            {
                                sTxtStartDate = " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("von") + " " + rUrlaubVerlauf.StartDatum.Value.ToString("dd.MM.yyyy HH:mm:ss");
                            }
                            string sTxtEndDate = "";
                            if (rUrlaubVerlauf.EndeDatum != null)
                            {
                                sTxtEndDate = " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("bis") + " " + rUrlaubVerlauf.EndeDatum.Value.ToString("dd.MM.yyyy HH:mm:ss");
                            }
                            sTxtLetzteAbwesenheit = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende für") + " " + rUrlaubVerlauf.Text.Trim() + sTxtStartDate + sTxtEndDate + " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("wurde bestätigt");
                        }

                        this.PMDSBusiness1.writeDekurs(sTxtLetzteAbwesenheit, QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende wurde zurückgesetzt!"), this.isBewerberJN, this.Klient.ID, PflegeEintragTyp.Klient);

                        PMDS.db.Entities.Aufenthalt rAufenthalt = b2.getAufenthalt(this.Klient.Aufenthalt.ID, db);
                        rAufenthalt.AbwesenheitBeendet = false;
                        db.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlient.writeDekursAbwesenheitsende: " + ex.ToString());
            }
        }


        private void initKlientStammdaten()
        {
            //this.ucKlientStammdaten1 = new PMDS.GUI.ucKlientStammdaten();
            //this.ucKlientStammdaten1.Dock = DockStyle.Fill;
            //this.panelKlientStammdaten2.Controls.Add(this.ucKlientStammdaten1);
            this.ucKlientStammdaten1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.ucKlientStammdaten1.initControl(this.mainSystm, this.isBewerberJN, false);
        }
        private void initMedizinischeDaten()
        {
            this.ucMedizinischeDaten1 = new PMDS.GUI.ucMedizinischeDaten();
            this.ucMedizinischeDaten1.Dock = DockStyle.Fill;
            this.ucMedizinischeDaten1.mainWindow = this;
            this.panelMedizinDaten2.Controls.Add(this.ucMedizinischeDaten1);
            this.ucMedizinischeDaten1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.ucMedizinischeDaten1.MedizinischerStateChanged += new PMDS.Global.MedizinischeDatenStateChangedDelegate(this.ucMedizinischeDaten1_MedizinischerStateChanged);
        }
        private void initRegelungen()
        {
            this.ucRegelungen1 = new PMDS.GUI.ucRegelungen();
            this.ucRegelungen1.Dock = DockStyle.Fill;
            this.panelRegelungen2.Controls.Add(this.ucRegelungen1);
            this.ucRegelungen1.ValueChanged += new System.EventHandler(this.OnValueChanged);
        }
        private void initDokumenteGegenstaende()
        {
            this.ucDokumenteGegenstaende1 = new PMDS.GUI.ucDokumenteGegenstaende();
            this.ucDokumenteGegenstaende1.Dock = DockStyle.Fill;
            this.panelDokumenteGegenstände2.Controls.Add(this.ucDokumenteGegenstaende1);
            this.ucDokumenteGegenstaende1.ValueChanged += new System.EventHandler(this.OnValueChanged);
        }
        private void initRehabilitation()
        {
            this.ucRehabilitation1 = new PMDS.GUI.ucRehabilitation();
            this.ucRehabilitation1.Dock = DockStyle.Fill;
            this.panelRehabilitation2.Controls.Add(this.ucRehabilitation1);
            this.ucRehabilitation1.ValueChanged += new System.EventHandler(this.OnValueChanged);
        }

    }
}
