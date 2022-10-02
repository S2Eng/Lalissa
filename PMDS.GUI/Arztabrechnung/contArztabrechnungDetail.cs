using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinGrid;
using PMDS.db.Entities;
using PMDS.DB;
using PMDS.Global;
using PMDS.Global.db.ERSystem;
//lthArztabrechnung       neues Form integrieren in PMDS.int (Neuer Ordner Arzabrechnung in PMDS.GUI)


namespace PMDS.GUI.Arztabrechnung
{

    public partial class contArztabrechnungDetail : UserControl
    {
        public bool _IsNew = false;
        public dsKlientenliste.ArztabrechnungRow rArztabrechnung = null;
        public Nullable<Guid> _IDArztabrechnung = null;
        public Nullable<Guid> _IDPatient;
        public Guid _IDBenutzer;
        //public Nullable<Guid> _IDArzt;
        public bool _Manage = false;

        public bool _KlientenzuordnungChanged = false;
        public bool _AuswahllistenzuordnungChanged = false;
        public bool abort = true;


        public frmArztabrechnungDetail MainWindow = null;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public class cTgPatient
        {
            public Guid IDPatient = System.Guid.NewGuid();
            public Guid IDAufenthalt = System.Guid.NewGuid();
        }
        public class cTgAuswahlliste2
        {
            public string BezeichnungOnly = "";
            public string BezeichnungAndBeschreibung = "";
            public Guid IDAuswahlliste = System.Guid.NewGuid();
            public int Hierarchie = -1;
            public string GehörtZurGruppe = "";
            public UltraListViewItem itmLeistung = null;
        }

        public PMDS.db.Entities.ERModellPMDSEntities db = null;
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected = new List<PMDS.Global.UIGlobal.eSelectedNodes>();








        public contArztabrechnungDetail()
        {
            InitializeComponent();
        }

        private void contArztabrechnung_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }






        public void initControl2(bool IsNew, Nullable<Guid> IDArztabrechnung, Nullable<Guid> IDPatient, Guid IDBenutzer, bool Manage)
        {
            try
            {
                this._IsNew = IsNew;
                this._IDArztabrechnung = IDArztabrechnung;
                this._IDPatient = IDPatient;
                this._IDBenutzer = IDBenutzer;
                this._Manage = Manage;

                this.MainWindow.AcceptButton = this.btnSave;
                this.MainWindow.CancelButton = this.btnAbort;

                this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, false, eTypePatientenUserPickerChanged.none);
                this.contPatientUserPicker1.selectUserPatient(null);

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                this.sqlManange1.initControl();

                if (Manage)
                {
                    this.contPatientUserPicker1.Enabled = true;
                    this.cboBenutzer.Enabled = true;
                }
                else
                {
                    this.contPatientUserPicker1.Enabled = false;
                    this.cboBenutzer.Enabled = false;
                }
                if (!this._IsNew)
                {
                    //this.ucPatientGroupPicker1.Enabled = false;
                    //this.cboBenutzer.Enabled = false;
                }

                this.db = PMDSBusiness.getDBContext();
                this.loadCombos();
                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.initControl: " + ex.ToString());
            }
        }

        public void clear()
        {
            try
            {
                this.txtAnmerkung.Text = "";
                this.selectLeistungen(CheckState.Unchecked);
                this.contPatientUserPicker1.selectUserPatient(null);
                this.dteDatum.Value = null;

                this._KlientenzuordnungChanged = false;
                this._AuswahllistenzuordnungChanged = false;

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.clear: " + ex.ToString());
            }
        }

        public void loadCombos()
        {
            try
            {
                this.lblFoundLeistungen.Text = "";

                //this.lvPatienten.Items.Clear();
                //this.dsKlientenliste1.vKlientenliste.Clear();
                //this.sqlManange1.getPatientenStart(Settings.USERID, 0, System.Guid.Empty, ref this.dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                //foreach (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in this.dsKlientenliste1.vKlientenliste)
                //{
                //    UltraListViewItem listItem = new UltraListViewItem(rKlient.PatientName.Trim(), null, null);
                //    listItem.Key = System.Guid.NewGuid().ToString();
                //    cTgPatient newTgPatient = new Arztabrechnung.contArztabrechnungDetail.cTgPatient();
                //    newTgPatient.IDPatient = rKlient.IDKlient;
                //    newTgPatient.IDAufenthalt = rKlient.IDAufenthalt;
                //    listItem.Tag = newTgPatient;
                //    listItem.CheckState = CheckState.Unchecked;
                //    this.lvPatienten.Items.Add(listItem);
                //}
                //this.lvPatienten.Refresh();
                //this.lblFoundKlienten.Text = "Gefunden: " + this.lvPatienten.Items.Count.ToString();

                this.lvLeistungen.Items.Clear();
                IQueryable<AuswahlListe> tAuswahlliste = db.AuswahlListe.Where(o => o.IDAuswahlListeGruppe == "AZA").OrderBy(p => p.Bezeichnung); ;
                if (tAuswahlliste.Count() > 0)
                {
                    foreach (AuswahlListe rAuswahlListe in tAuswahlliste)
                    {
                        string txtSelList = rAuswahlListe.Bezeichnung.Trim() + " " + rAuswahlListe.Beschreibung.Trim();
                        UltraListViewItem listItem = new UltraListViewItem(txtSelList, null, null);
                        listItem.Key = System.Guid.NewGuid().ToString();
                        cTgAuswahlliste2 newTgAuswahlliste = new cTgAuswahlliste2();
                        newTgAuswahlliste.BezeichnungOnly = rAuswahlListe.Bezeichnung.Trim();
                        newTgAuswahlliste.BezeichnungAndBeschreibung = txtSelList;
                        newTgAuswahlliste.IDAuswahlliste = rAuswahlListe.ID;
                        newTgAuswahlliste.GehörtZurGruppe = rAuswahlListe.GehörtzuGruppe;
                        newTgAuswahlliste.Hierarchie = rAuswahlListe.Hierarche;
                        newTgAuswahlliste.itmLeistung = listItem;
                        listItem.Tag = newTgAuswahlliste;
                        listItem.CheckState = CheckState.Unchecked;
                        this.lvLeistungen.Items.Add(listItem);
                    }
                }
                this.lvLeistungen.Refresh();
                this.lblFoundLeistungen.Text = "Gefunden: " + this.lvLeistungen.Items.Count.ToString();

                this.cboBenutzer.Items.Clear();
                IQueryable<Benutzer> tBenutzer = db.Benutzer.OrderBy(p => p.Vorname).OrderBy(p => p.Nachname);
                if (tBenutzer.Count() > 0)
                {
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {
                        bool bArztabrechnungErfassung = ENV.HasRightUser(UserRights.ArztabrechnungErfassung, rBenutzer.ID);               //lthArztabrechnung  
                        //if (rBenutzer.ArztabrechnungJN)
                        if (bArztabrechnungErfassung)
                        {
                            Infragistics.Win.ValueListItem itm = this.cboBenutzer.Items.Add(rBenutzer.ID, rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim());
                        }
                    }
                }

                //this.cboBenutzer.Items.Clear();
                //IQueryable<Aerzte> tAerzte = db.Aerzte.OrderBy(o => o.Nachname).OrderBy(o => o.Vorname);
                //if (tAerzte.Count() > 0)
                //{
                //    foreach (Aerzte rAerzte in tAerzte)
                //    {
                //        Infragistics.Win.ValueListItem itm = this.cboBenutzer.Items.Add(rAerzte.ID, rAerzte.Nachname.Trim() + " " + rAerzte.Vorname.Trim());
                //    }
                //}

                //System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                //this.setKlientenOnOff(true);
                //IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db);
                //foreach (Benutzer rBenutzer in tBenutzer)
                //{
                //    //UltraListViewItem listItem = new UltraListViewItem(rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " (" + rBenutzer.Benutzer1.Trim() + ")", null, null);
                //    UltraListViewItem listItem = new UltraListViewItem(rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "", null, null);
                //    listItem.Key = System.Guid.NewGuid().ToString();
                //    cTgUser newTgUser = new Arztabrechnung.contArztabrechnung.cTgUser();
                //    newTgUser.IDUser = rBenutzer.ID;
                //    newTgUser.IDAufenthalt = rBenutzer.idau
                //    listItem.Tag = newTgUser;
                //    listItem.CheckState = CheckState.Unchecked;
                //    this.lvBenutzer.Items.Add(listItem);
                //    lstBenutzerAll.Add(rBenutzer.ID);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.loadCombos: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clear();
                this._KlientenzuordnungChanged = false;
                this._AuswahllistenzuordnungChanged = false;
                this.btnSave.Enabled = true;
                this.dsKlientenliste1.Arztabrechnung.Clear();

                if (this._IsNew)
                {
                    this.sqlManange1.getArztabrechnung2(this.dsKlientenliste1, null, "", "", null, null, null, System.Guid.NewGuid(), "", null);
                    this.rArztabrechnung = this.sqlManange1.getNewArztabrechnung(ref this.dsKlientenliste1);
                    if (this._IDPatient != null)
                    {
                        this.rArztabrechnung.IDPatient = (Guid)this._IDPatient;
                    }
                    else
                    {
                        this.rArztabrechnung.IDPatient = System.Guid.Empty;
                    }
                    this.rArztabrechnung.IDBenutzer = this._IDBenutzer;
                }
                else
                {
                    this.sqlManange1.getArztabrechnung2(this.dsKlientenliste1, null, "", "", null, null, null, this._IDArztabrechnung, "", null);
                    if (this.dsKlientenliste1.Arztabrechnung.Rows.Count != 1)
                    {
                        throw new Exception("loadData: this.dsKlientenliste1.Arztabrechnung.Rows.Count<>1 for IDArztabrechnung '" + this._IDArztabrechnung.ToString() + "'!");
                    }
                    this.rArztabrechnung = (dsKlientenliste.ArztabrechnungRow)this.dsKlientenliste1.Arztabrechnung.Rows[0];
                }

                this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, false, eTypePatientenUserPickerChanged.none);
                this.contPatientUserPicker1.selectUserPatient(this.rArztabrechnung.IDPatient);

                this.cboBenutzer.Value = this.rArztabrechnung.IDBenutzer;
                this.txtAnmerkung.Text = this.rArztabrechnung.Anmerkung.Trim();
                this.dteDatum.Value = this.rArztabrechnung.Datum;

                foreach (UltraListViewItem rViewLeistung in this.lvLeistungen.Items)
                {
                    rViewLeistung.CheckState = CheckState.Unchecked;
                    cTgAuswahlliste2 tgAuswahlliste = (cTgAuswahlliste2)rViewLeistung.Tag;
                    if (tgAuswahlliste.BezeichnungOnly.Trim().ToLower().Equals(this.rArztabrechnung.Leistung1.Trim().ToLower()))
                    {
                        rViewLeistung.CheckState = CheckState.Checked;
                    }
                    if (tgAuswahlliste.BezeichnungOnly.Trim().ToLower().Equals(this.rArztabrechnung.Leistung2.Trim().ToLower()))
                    {
                        rViewLeistung.CheckState = CheckState.Checked;
                    }
                    if (tgAuswahlliste.BezeichnungOnly.Trim().ToLower().Equals(this.rArztabrechnung.Leistung3.Trim().ToLower()))
                    {
                        rViewLeistung.CheckState = CheckState.Checked;
                    }
                }

                //foreach (UltraListViewItem rViewPatient in this.lvPatienten.Items)
                //{
                //    rViewPatient.CheckState = CheckState.Unchecked;
                //    cTgPatient tgPatienten = (cTgPatient)rViewPatient.Tag;
                //    if (tgPatienten.IDPatient.Equals(this.rArztabrechnung.IDPatient))
                //    {
                //        rViewPatient.CheckState = CheckState.Checked;
                //    }
                //}


            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.cboBenutzer, "");
                this.errorProvider1.SetError(this.contPatientUserPicker1, "");
                this.errorProvider1.SetError(this.lvLeistungen, "");
                this.errorProvider1.SetError(this.cboBenutzer, "");
                this.errorProvider1.SetError(this.cboBenutzer, "");

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.clearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData(ref Nullable<Guid> IDPatientSelectedBack)
        {
            try
            {
                this.clearErrorProvider();

                if (this.cboBenutzer.Value == null)
                {                                                   
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    this.errorProvider1.SetError(this.cboBenutzer, "Error");
                    this.cboBenutzer.Focus();
                    return false;
                }

                System.Collections.Generic.List<Guid> lstSelectedUsersPatients = this.contPatientUserPicker1.contSelectPatienten.getList();
                if (lstSelectedUsersPatients.Count == 0)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    this.errorProvider1.SetError(this.contPatientUserPicker1, "Error");
                    this.contPatientUserPicker1.Focus();
                    return false;
                }
                else if (lstSelectedUsersPatients.Count > 1)
                {
                    throw new Exception("contArztabrechnung.validateData: lstSelectedUsersPatients2.Count>1 not allowed!");
                }
                IDPatientSelectedBack = lstSelectedUsersPatients[0];

                if (this.dteDatum.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.errorProvider1.SetError(this.dteDatum, "Error");
                    this.dteDatum.Focus();
                    return false;
                }
                DateTime datCheckHierarchie = this.rArztabrechnung.Datum.Date;
                Nullable<Guid> notIDArztabrechnung = null;
                if (!this._IsNew)
                {
                    notIDArztabrechnung = this.rArztabrechnung.ID;
                }
                System.Collections.Generic.List<cTgAuswahlliste2> lstLeistungenSelectedUnique = new List<cTgAuswahlliste2>();
                int iCounterLeistungenChecked = this.countSelectedItemsLeistungen(ref lstLeistungenSelectedUnique);
                //string sMsgBoxAllowedDaylyTxt = "";
                foreach (cTgAuswahlliste2 tgAuswahlliste in lstLeistungenSelectedUnique)
                {
                    if (tgAuswahlliste.Hierarchie > -1)
                    {
                        dsKlientenliste dsKlientenlistCheck = new dsKlientenliste();

                        this.sqlManange1.getArztabrechnung2(dsKlientenlistCheck, this.rArztabrechnung.IDBenutzer, "", "", datCheckHierarchie, datCheckHierarchie, IDPatientSelectedBack, null, 
                                                            tgAuswahlliste.BezeichnungOnly.Trim(), notIDArztabrechnung);
                        if (dsKlientenlistCheck.Arztabrechnung.Rows.Count > 0)
                        {
                            if (dsKlientenlistCheck.Arztabrechnung.Rows.Count >= tgAuswahlliste.Hierarchie)
                            {
                                tgAuswahlliste.itmLeistung.CheckState = CheckState.Unchecked;
                                //sMsgBoxAllowedDaylyTxt += "Die Leistung " + tgAuswahlliste.Bezeichnung.Trim() + " darf nur " + tgAuswahlliste.Hierarchie.ToString() + " mal pro Tag erfasst werden! (Bereits erfasst: " + dsKlientenlistCheck.Arztabrechnung.Rows.Count.ToString() + ")" + "\r\n";
                            }
                        }
                    }
                }
                //if (sMsgBoxAllowedDaylyTxt.Trim() != "")
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxAllowedDaylyTxt.Trim(), "", MessageBoxButtons.OK);
                //    this.errorProvider1.SetError(this.lvLeistungen, "Error");
                //    this.lvLeistungen.Focus();
                //    return false;
                //}

                lstLeistungenSelectedUnique = new List<cTgAuswahlliste2>();
                iCounterLeistungenChecked = this.countSelectedItemsLeistungen(ref lstLeistungenSelectedUnique);
                //if (iCounterLeistungenChecked == 0)
                //{                                                 
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Leistungen: Es muss mindestens eine Leistung ausgewählt werden!", "", MessageBoxButtons.OK);
                //    this.errorProvider1.SetError(this.lvLeistungen, "Error");
                //    this.lvLeistungen.Focus();
                //    return false;
                //}
                if (iCounterLeistungenChecked > 3)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Leistungen: Es dürfen nicht mehr als 3 Leistungen ausgewählt werden!", "", MessageBoxButtons.OK);
                    this.errorProvider1.SetError(this.lvLeistungen, "Error");
                    this.lvLeistungen.Focus();
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.validateData: " + ex.ToString());
            }
        }
        public int countSelectedItemsLeistungen(ref System.Collections.Generic.List<cTgAuswahlliste2> lstLeistungenSelectedUnique)
        {
            try
            {
                int iCounterLeistungenChecked = 0;
                foreach (UltraListViewItem itmLeistung in this.lvLeistungen.Items)
                {
                    cTgAuswahlliste2 TgAuswahlliste = (cTgAuswahlliste2)itmLeistung.Tag;
                    if (itmLeistung.CheckState == CheckState.Checked)
                    {
                        bool bLeistungFound = false;
                        foreach (cTgAuswahlliste2 tgAuswahlliste2 in lstLeistungenSelectedUnique)
                        {
                            if (TgAuswahlliste.BezeichnungOnly.Trim().ToLower().Equals(tgAuswahlliste2.BezeichnungOnly.Trim().ToLower()))
                            {
                                bLeistungFound = true;
                            }
                        }
                        if (!bLeistungFound)
                        {
                            lstLeistungenSelectedUnique.Add(TgAuswahlliste);
                        }
                        iCounterLeistungenChecked += 1;
                    }
                }

                return iCounterLeistungenChecked;

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.countSelectedItemsLeistungen: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                Nullable<Guid> IDPatientSelectedBack = null;
                if (!this.validateData(ref IDPatientSelectedBack))
                {
                    return false;
                }

                this.rArztabrechnung.Anmerkung = this.txtAnmerkung.Text.Trim();
                if (this._IsNew)
                {

                }
                else
                {

                }

                this.rArztabrechnung.IDPatient = IDPatientSelectedBack.Value;

                this.rArztabrechnung.IDBenutzer = (Guid)this.cboBenutzer.Value;
                this.rArztabrechnung.Datum = this.dteDatum.DateTime;

                this.rArztabrechnung.Leistung1 = "";
                this.rArztabrechnung.Leistung2 = "";
                this.rArztabrechnung.Leistung3 = "";

                int iCounterLeistungenChecked = 0;
                foreach (UltraListViewItem itmLeistung in this.lvLeistungen.Items)
                {
                    cTgAuswahlliste2 TgAuswahlliste = (cTgAuswahlliste2)itmLeistung.Tag;
                    if (itmLeistung.CheckState == CheckState.Checked)
                    {
                        if (iCounterLeistungenChecked == 0)
                        {
                            this.rArztabrechnung.Leistung1 = TgAuswahlliste.BezeichnungOnly.Trim();
                        }
                        else if (iCounterLeistungenChecked == 1)
                        {
                            this.rArztabrechnung.Leistung2 = TgAuswahlliste.BezeichnungOnly.Trim();
                        }
                        else if (iCounterLeistungenChecked == 2)
                        {
                            this.rArztabrechnung.Leistung3 = TgAuswahlliste.BezeichnungOnly.Trim();
                        }
                        else
                        {
                            throw new Exception("saveData: iCounterLeistungenChecked > 2 not allowed!");
                        }

                        iCounterLeistungenChecked += 1;
                    }
                }

                //os191224
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == this.rArztabrechnung.IDPatient
                                    select new
                                    { p.KrankenKasse, p.VersicherungsNr }
                                       ).First();
                    this.rArztabrechnung.Krankenkasse = rPatInfo.KrankenKasse.Trim();
                    this.rArztabrechnung.SVNr = rPatInfo.VersicherungsNr.Trim();
                }                
                //Patient rPatient = this.b.getPatient(this.rArztabrechnung.IDPatient, this.db);

                if (iCounterLeistungenChecked > 0)
                {
                    this.sqlManange1.d.Update(this.dsKlientenliste1.Arztabrechnung);
                    if (this.lstPatienteSelected.Count > 0)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                            PMDSBusiness1.CopyAndAddArztabrechnung(this.rArztabrechnung.ID, ref this.lstPatienteSelected, db, this.rArztabrechnung.IDPatient);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.saveData: " + ex.ToString());
            }
        }

        public void selectLeistungen(CheckState bOn)
        {
            try
            {
                foreach (UltraListViewItem listItem in this.lvLeistungen.Items)
                {
                    listItem.CheckState = bOn;
                }
                this.lvLeistungen.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.selectLeistungen: " + ex.ToString());
            }
        }
        public void valueChanged()
        {
            try
            {
                //this.btnSave.Enabled = true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnung.valueChanged: " + ex.ToString());
            }
        }




        private void lvLeistungen_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void lvLeistungen_ItemCheckStateChanged(object sender, ItemCheckStateChangedEventArgs e)
        {
            try
            {
                this.valueChanged();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void lvLeistungen_ItemCheckStateChanging(object sender, ItemCheckStateChangingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cboÄrzte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboBenutzer.Focused)
                {
                    this.valueChanged();
                }
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void txtAnmerkung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtAnmerkung.Focused)
                {
                    this.valueChanged();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void openMehrfachselektionPatients()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.MainWindow.Close();
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
                this.MainWindow.Close();
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


        private void ucPatientGroupPicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        
        private void klientenmehrfachauswahlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openMehrfachselektionPatients();

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

        private void contArztabrechnungDetail_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }

            
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.MainWindow.Close();
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
    }

}

