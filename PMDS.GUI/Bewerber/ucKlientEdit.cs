using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Print;
using PMDS.GUI.BaseControls;
using System.Linq;




namespace PMDS.GUI
{


    public delegate void PatientDetailsDelegate(Guid IDPatient, bool BewerberJN);
    public delegate void PatientDeletedDelegate(Guid IDPatient);
    public delegate void BewerberChangedDelegate(Guid IDPatient);
    public delegate void BewebungsdatenDetailsDelegate(Guid IDPatient);
    public delegate void BewerberstatusChangedDelegate(Guid IDPatient);



    public partial class ucKlientEdit : QS2.Desktop.ControlManagment.BaseControl
    {


        private Guid _IDPatient = Guid.Empty;
        private bool _ContentChanged = false;
        bool _NewPatient = false;
        private bool _ValueChangeEnabled = true;
        public ucKlient ucKlient1;
        public frmKlientEdit mainWindow;
        public bool isBewerberverwaltung = false;






        public ucKlientEdit()
        {
            InitializeComponent();
            this.initControl();
        }

        public void initControl()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                this.ucKlient1 = new ucKlient();
                this.ucKlient1.isBewerberJN = true;
                this.ucKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
                this.ucKlient1.Dock = DockStyle.Fill;
                this.ucKlient1.ValueChanged += new System.EventHandler(this.ucKlient1_ValueChanged);
                this.ucKlient1.initControl();
                this.panelKlientenakt.Controls.Add(this.ucKlient1);

#if DEBUG
                ENV.eMailStammdaten = "os@s2-engineering.com";
#endif
                if (ENV.eMailStammdaten.Trim() == "" || ENV.lic_eMailBewerber == 0) 
                    this.btnAufnahmeblatt.Visible = false;

                UpdateActions();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;

                if (_IDPatient == Guid.Empty) //Änderung nach 02.07.2007 MDA
                    InitKlientDatenControl();
                else if (ucKlient1.Klient.ID != _IDPatient)
                {
                    _ValueChangeEnabled = false;
                    _NewPatient = false;
                    KlientDetails klient = _IDPatient == Guid.Empty ? new KlientDetails() : new KlientDetails(_IDPatient, Aufenthalt.LastByPatient(_IDPatient));
                    ucKlient1.Klient = klient;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    _ContentChanged = false;
                    _ValueChangeEnabled = true;
                }
                else
                    Undo();
            }
        }

        public void clearIDKlient()
        {
            try
            {
                ucKlient1.Klient.ID = new System.Guid();
            }
            catch (Exception ex)
            {
                throw new Exception("clearIDKlient: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// erlaubte Aktionen ein/ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateActions()
        {
            //neu nach 26.04.2007 MDA

            //nach User Rechte Tab Stammdaten anzeigen oder ausblenden
            //ucKlient1.StammdatenVisible = ENV.HasRight(UserRights.KlientenAktStammdatenAnzeigen);

            //Stammdaten ReadOnly setzen
            //ucKlient1.StammdatenReadOnly = !ENV.HasRight(UserRights.KlientenAktStammdatenAendern);

            //Sonstige Visible
            //ucKlient1.SonstigeVisible = ENV.HasRight(UserRights.KlientenAktSonstigeAnzeigen);

            //Sonstige ReadOnly
            //ucKlient1.SonstigeReadOnly = !ENV.HasRight(UserRights.KlientenAktSonstigeAendern);


            //if (!ucKlient1.StammdatenVisible && !ucKlient1.SonstigeVisible)
            //{
            //    panel1.Visible = true;
            //    panel1.Size = ucKlient1.Size;
            //}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// BewerbungaktivJN setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BewerbungaktivJN
        {
            get { return ucKlient1.Klient.BewerbungaktivJN; }
            set
            {
                ucKlient1.Klient.BewerbungaktivJN = value;
                ucKlient1.UpdateGUI();
            }
        }

        public void NewBewerber()
        {
            KlientDetails klient = new KlientDetails();
            klient.BewerbungaktivJN = true;
            ucKlient1.bewerberbeuanlage = true;
            klient.BewerbungDatum = DateTime.Now;
            ucKlient1.Klient = klient;
            _IDPatient = klient.ID;
            _NewPatient = true;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            _ContentChanged = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// True wird zurückgegeben wenn Änderungen vorhanden sind.
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ContentChanged
        {
            get { return _ContentChanged; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Falls Änderungen vorhanden sind, eine Abfrage wegen Speichern anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public DialogResult AskForSave()
        {
            DialogResult res = DialogResult.None;
            if (_ContentChanged)
            {
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                MessageBoxButtons.YesNoCancel,
                                                                                MessageBoxIcon.Question, true);

                if (res == DialogResult.Yes)
                    ProcessSave(true);
                else if (res == DialogResult.No)
                    ProcessSave(false);
            }

            return res;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen speichern oder verwerfen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSave(bool save)
        {
            if (save)
                Save();
            else
                Undo();
        }

        public void Undo()
        {
            if (_NewPatient)
            {
                NewBewerber();
            }
            else
            {
                if (this.isBewerberverwaltung)
                {
                    //KlientDetails klient = _IDPatient == Guid.Empty ? new KlientDetails() : new KlientDetails(_IDPatient, Aufenthalt.LastByPatient(_IDPatient));
                    //Guid currentAufenthalt = ucKlient1.Klient.Aufenthalt != null ? ucKlient1.Klient.Aufenthalt.ID : Guid.Empty;
                    ucKlient1.Klient = new KlientDetails(_IDPatient, Aufenthalt.LastByPatient(_IDPatient));
                }
                else
                {
                    Guid currentAufenthalt = ucKlient1.Klient.Aufenthalt != null ? ucKlient1.Klient.Aufenthalt.ID : Guid.Empty;
                    ucKlient1.Klient = new KlientDetails(_IDPatient, currentAufenthalt);
                }
            }

            //Änderung nach 02.07.2007 MDA
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            _ContentChanged = false;
        }
        //Neu nach 29.10.2007 MDA
        public bool ValidateFields()
        {
            return ucKlient1.ValidateFields();
        }

        public bool Save()
        {
            try
            {
                string MessageTxt = "";
                if (!ValidateFields())
                    return false;

                if (!this.ucKlient1.ucKlientStammdaten1.ucAbrechAufenthKlient1.validateDataVersNr(ref MessageTxt, true))
                {
                    this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Aufenthalt"];
                    return false;
                }

                ucKlient1.UpdateDATA();
                ucKlient1.Write();
                string txtSprachenGeändert = "";
                bool writeDekursSprachenChanged = false;
                bool abweseneheitBeendetChanged = false;
                this.ucKlient1.ucKlientStammdaten1.SaveER(ref writeDekursSprachenChanged, ref abweseneheitBeendetChanged, ucKlient1.Klient.Aufenthalt.ID, ref txtSprachenGeändert);

                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                _ContentChanged = false;
                _NewPatient = false;

                this.ucKlient1.checkWriteDekurs(ref writeDekursSprachenChanged, ref txtSprachenGeändert);
                this.ucKlient1.checkWriteÄrzteMehrfachauswahl();

                //Neu nach 03.07.2007 MDA
                ENV.SignalPatientDatenChanged(ucKlient1.Klient.ID);
                this.ucKlient1.ucKlientStammdaten1.resetColor();
                this.ucKlient1.ucKlientStammdaten1.ucAbrechAufenthKlient1.resetColor();

                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }


        private void InitKlientDatenControl()
        {

        }

        private void ucKlient1_ValueChanged(object sender, EventArgs e)
        {
            if (!_ValueChangeEnabled)
                return;
            _ContentChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                Undo();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }        
      
        //----------------------------------------------------------------------------
        /// <summary>
        /// StammDatenBlatt drucken  {{{eng}}} 24.10.2007
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPrintStammDatenBlatt1_btnPrintStammdatenKlicked(bool FreiheitsbeschränkendeMaßnahmenJN, bool VersicherungsdatenJN, bool Med_DatenJN, bool KontaktpersonJN, bool SachwalterJN, bool AerzteJN,bool Regelung,bool Pflegestufe,bool Kostentraeger,bool Verwahrung,bool Hilfsmittel,bool Dienstleister,bool Reha)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.Print.ReportManager.PrintStammdatenblatt(IDPatient, Guid.Empty, FreiheitsbeschränkendeMaßnahmenJN, VersicherungsdatenJN, Med_DatenJN, KontaktpersonJN, SachwalterJN, AerzteJN, Regelung, Pflegestufe, false, false, false, Dienstleister, Reha);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void ucKlient1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                mainWindow.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnAufnahmeblatt_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.BewerberStammblatt Stammblatt = PMDSBusiness1.GetBewerberStammblatt(IDPatient);
                string command = "";
                string lb =  "%0a%0d";
                string dlb = lb + lb;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    //os191224
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == (Guid)IDPatient
                                    select new
                                    { p.Nachname, 
                                        p.Vorname,
                                        p.IDAbteilung,
                                        p.IDBereich,
                                        p.Selbstzahler}
                                    ).First();
                    //PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient((Guid)IDPatient, db);

                    PMDS.db.Entities.Abteilung a = new PMDS.db.Entities.Abteilung();
                    a.Bezeichnung = rPatInfo.IDAbteilung != null ? PMDSBusiness1.getAbteilung((Guid)rPatInfo.IDAbteilung, db).Bezeichnung.ToString().Trim() : "";

                    PMDS.db.Entities.Bereich b = new PMDS.db.Entities.Bereich();
                    if (rPatInfo.IDBereich != null && rPatInfo.IDBereich != Guid.Empty)
                        b.Bezeichnung = rPatInfo.IDBereich != null ? PMDSBusiness1.getBereich((Guid)rPatInfo.IDBereich, db).Bezeichnung.ToString().Trim() : "";
                    else
                        b.Bezeichnung = "";

                    if (Stammblatt.ID == IDPatient)                
                    {
                        string Subject = QS2.Desktop.ControlManagment.ControlManagment.getRes("Aufnahmedaten für ") + Stammblatt.PatientName.Trim();
                        string Body = Subject + lb;
                        Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplante Aufnahme am: ") + lb;
                        if (a.Bezeichnung != "")
                           Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplante Abteilung: ") +  a.Bezeichnung.ToString() +  lb;
                        // Lt. Mail I.Rauch vom 24.4.2018, 12:08 Uhr wegen DSGVO nicht mehr andrucken
                        if (ENV.lic_eMailBewerber == 2)
                        {
                            if (b.Bezeichnung != "")
                                Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplanter Bereich (Zi: ") + b.Bezeichnung.ToString() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Geboren am: ") + Stammblatt.Geburtsdatum + (Stammblatt.Geburtsort.Trim() != "" ? " in " + Stammblatt.Geburtsort.Trim() : "") + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Soz.Vers.Nr.: ") + Stammblatt.Vers_Nr_.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Familienstand: ") + Stammblatt.Familienstand.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Religionsbekenntnis: ") + Stammblatt.Religionsbekenntnis.Trim() + lb;
                            //Body += "Adresse: " + Stammblatt.Adresse;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsangehörigkeit: ") + Stammblatt.Staastangehörigkeit.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Pension:") + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Versichert: ") + Stammblatt.versichert.Trim() + (rPatInfo.Selbstzahler ? " (Selbstzahler)" : "") + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Rezeptgebührenbefreiung: ") + Stammblatt.Rezeptgebührenbefreiung.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzversicherung: ") + Stammblatt.Zusatzversicherung.Trim() + lb;

                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Angehörige: ");
                            string[] Angehörige = Stammblatt.Angehörige.Trim().Split('|');
                            foreach (string Angehöriger in Angehörige)
                            {
                                Body += Angehöriger.Trim() == "" ? "" : lb + "    " + Angehöriger;
                            }
                            Body += lb;

                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter: ");
                            string[] Sachwalter = Stammblatt.Sachwalter.Trim().Split('|');
                            foreach (string rSachwalter in Sachwalter)
                            {
                                Body += rSachwalter.Trim() == "" ? "" : lb + "    " + rSachwalter;
                            }
                            Body += lb;

                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegestufe: ") + Stammblatt.Pflegestufe.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("FSW: ") + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Kommt von: ") + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientennummer: ") + Stammblatt.Klientennummer.Trim() + lb;
                            Body += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: ") + Stammblatt.Bemerkung.Trim() + lb;
                        }

                        Body = Body.Replace("\"", "%22");
                        command = @"mailto:" + ENV.eMailStammdaten + "?subject=" + Subject + "&body=" + @Body;
                        System.Diagnostics.Process.Start(command);
                    }

                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnArztbriefDrucken_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

    }

}
