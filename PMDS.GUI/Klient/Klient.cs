using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using PMDS.Global;
using PMDS.DB.Global;
using PMDS.Klient;
using PMDS.Data.Global;
using PMDS.Abrechnung.Global;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.GUI.Klient;
using PMDS.DB;

namespace PMDS.BusinessLogic
{
    public class KlientDetails
    {
        private DBKlient _db;
        private Guid _idPatient = Guid.NewGuid();
        private Guid _idAufenthalt = Guid.NewGuid();
        
        private Adresse _adresse;
        private Kontakt _kontak;
        private Aufenthalt _aufenthalt;
        private KlientKlinik _klinik;
        private KlientMedizinischeDaten _medDaten;
        private KlientPflegestufe _pateintPflegestufe;
        private Rehabilitation _rehabilitation;
        private Gegenstaende _gegenstaende;
        public Unterbringung _unterbringung;
        private List<Kontaktperson> _kontaktpersonen;
        public Aerzte _Aerzte; //Neu nach 13,06.2007 MDA
        private List<Sachwalter> _listSachwalter;

        private dsAufenthaltZusatz _dsAufenthaltZusatz = new dsAufenthaltZusatz();
        private AufenthaltZusatz _AufenthaltZusatz = new AufenthaltZusatz();

        public PMDSBusiness b = new PMDSBusiness();

        public static bool searchLastEntlassenenAufenthalt;


        public KlientDetails()
        {
            _db = new DBKlient();
            _adresse = new Adresse();
            _kontak = new Kontakt();
            _aufenthalt = new Aufenthalt();
            _klinik = new KlientKlinik();
            _medDaten = new KlientMedizinischeDaten();
            _medDaten.IDBenutzer = ENV.USERID; //Neu nach 23.05.2008 MDA
            _pateintPflegestufe = new KlientPflegestufe();
            _rehabilitation = new Rehabilitation();
            _gegenstaende = new Gegenstaende();
            _unterbringung = new Unterbringung();
            _Aerzte = new Aerzte();//Neu nach 13,06.2007 MDA
            _Aerzte.Read();
            _dsAufenthaltZusatz = new dsAufenthaltZusatz();
            _AufenthaltZusatz.New(_dsAufenthaltZusatz, _aufenthalt.ID);
            New();
        }

        /// <summary>
        /// Konstruktor zum lesen eines bestimmten Eintrages
        /// </summary>
        public KlientDetails(Guid idPatient, Guid idAufenthalt, bool doAllAerzteAdressenKontakte  = false)
        {
            _db = new DBKlient();
            _idPatient = idPatient;
            _idAufenthalt = idAufenthalt;
            _db.IDPatient = idPatient;
            _db.IDAufenthalt = idAufenthalt;
            _Aerzte = new Aerzte();//Neu nach 13,06.2007 MDA
            _Aerzte._doAllAdresseKontakte2 = doAllAerzteAdressenKontakte;
            _Aerzte.Read();                              
            _Aerzte.ReadByPatient(idPatient);
            Read();
            _adresse = new Adresse(IDAdresse);
            _kontak = new Kontakt(IDKontakt);

            if (_idAufenthalt != Guid.Empty)
            {
                _aufenthalt = new Aufenthalt(_idAufenthalt);

                _dsAufenthaltZusatz = _AufenthaltZusatz.ReadByAufenthalt(_idAufenthalt);

                if (_dsAufenthaltZusatz.AufenthaltZusatz.Count == 0)
                {
                    _AufenthaltZusatz.New(_dsAufenthaltZusatz, _idAufenthalt);
                }
            }

            _medDaten = new KlientMedizinischeDaten(idPatient, ENV.USERID);
            _pateintPflegestufe = new KlientPflegestufe(_idPatient);
            _rehabilitation = new Rehabilitation(_idPatient);
            _gegenstaende = new Gegenstaende(_idAufenthalt);
            _unterbringung = new Unterbringung(_idAufenthalt);
            _klinik = new KlientKlinik(idAufenthalt);            
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set 
            { 
                _idPatient = value;
                _db.IDPatient = value;
                _medDaten.IDPatient = value;
                _pateintPflegestufe.IDpatient = value;
                _rehabilitation.IDPatient = value;
                _Aerzte.ReadByPatient(_idPatient);//Neu nach 13,06.2007 MDA
            }
        }

        public Guid IDAuenthalt
        {
            get { return _idAufenthalt; }
            set
            {
                _idAufenthalt = value;
                _db.IDAufenthalt = value;
                _gegenstaende.IDAufenthalt = value;
                _unterbringung.IDAufenthalt = value;
                _klinik.IDAufenthalt = value;

                _aufenthalt = null;
                if (_idAufenthalt != Guid.Empty)
                {
                    _aufenthalt = new Aufenthalt(_idAufenthalt);

                    _dsAufenthaltZusatz = _AufenthaltZusatz.ReadByAufenthalt(_idAufenthalt);

                    if (_dsAufenthaltZusatz.AufenthaltZusatz.Count == 0)
                    {
                        _AufenthaltZusatz.New(_dsAufenthaltZusatz, _idAufenthalt);
                    }
                }
            }
        }

        private dsKlient.KlientRow DB_KLIENT_ROW
        {
            get { return _db.KLIENT.Klient[0]; }
        }

        /// <summary>
        /// Alle Kontaktpersonen eines Klients
        /// </summary>
        public dsKontaktpersonen KLIENT_KONTAKTPERSONEN
        {
            get { return _db.KLIENT_KONTAKTPERSONEN; }
        }

        /// <summary>
        /// Alle Dienstleiste eines Klients
        /// </summary>
        public dsKontaktpersonen KLIENT_DIENSTLEISTER
        {
            get { return _db.KLIENT_DIENSTLEISTER; }
        }

        /// <summary>
        /// Alle Sachwalter eines Klients
        /// </summary>
        public dsKlientSachwalter KLIENT_SACHWALTER
        {
            get { return _db.KLIENT_SACHWALTER; }
        }

        /// <summary>
        /// Liste alle Kontaktpersonen eines Klients
        /// </summary>
        public List<Kontaktperson> KONTAKTPERSONEN
        {
            get { return _kontaktpersonen; }
            set { _kontaktpersonen = value; }
        }

        /// <summary>
        /// Liste alle Sachwalter eines Klients
        /// </summary>
        public List<Sachwalter> LIST_SACHWALTER
        {
            get { return _listSachwalter; }
            set { _listSachwalter = value; }
        }

        /// <summary>
        /// Aufenthal Zusatzinformationen
        /// </summary>
        public dsAufenthaltZusatz.AufenthaltZusatzDataTable AufenthaltZusatz
        {
            get { return _dsAufenthaltZusatz.AufenthaltZusatz; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            _db.Read();
            
            InitKontaktpersonen();
            InitSachwalter();
            
            FillKontaktpersonen();
            FillKlientSachwalter();
        }

        /// <summary>
        /// Neues Eintrag
        /// </summary>
        public void New()
        {
            _db.New();
            IDPatient = ID; //Neu nach 23.05.2008 MDA die Neu Erzeugte ID übernehmen
            IDAdresse = Adresse.ID;
            IDKontakt = Kontakt.ID;
            
            //Neu nach 28.06.2007 MDA
            Aufenthalt.IDPatient = DB_KLIENT_ROW.ID; 

            InitKontaktpersonen();
            InitSachwalter();

            FillKontaktpersonen();
            FillKlientSachwalter();
        }

        public void Write(bool mainSystm, bool isAbrechnung, bool isBewerberJN)
        {           
            //Änderung nach 28.06.2007 MDA
            //Bei neuem Klient muß zuerst Adresse und Kontakt angelegt werden.
            Adresse.Write();
            Kontakt.Write();

            _db.Write();

            //if (Aufenthalt != null)
            //    Aufenthalt.Write();

            List<Kontaktperson> listKp = new List<Kontaktperson>();
            //Änderungen in Kontaktpersonen speichern
            foreach (Kontaktperson Kontaktp in KONTAKTPERSONEN)
            {
                Kontaktp.Write();
                if (Kontaktp.DELETED) listKp.Add(Kontaktp);
            }
            //Gelöschte kontaktpersonen aus der liste entfernen
            foreach (Kontaktperson Kontaktp in listKp)
            {
                KONTAKTPERSONEN.Remove(Kontaktp);
            }

            //Neu nach 14.06.2007 MDA Zuordnung Ärzte Aufenthalt speichern
            CLASS_AERZTE.Write();

            List<Sachwalter> listSw = new List<Sachwalter>();
            //Änderungen in Sachwalter speichern
            foreach (Sachwalter sw in LIST_SACHWALTER)
            {
                sw.Write();
                if (sw.DELETED) listSw.Add(sw);
            }

            //Gelöschte Sachwalter aus der liste entfernen
            foreach (Sachwalter sw in listSw)
            {
                LIST_SACHWALTER.Remove(sw);
            }

            if (mainSystm)
            {
                MEDIZINISCHE_DATEN.Write();
                UNTERBRINGUNG.Write();
                GEGENSTAENDE.Write();
                REHABILITATION.Write();
            }
            if (isBewerberJN)
            {
                MEDIZINISCHE_DATEN.Write();
                REHABILITATION.Write();
            }

            PATIENTPFLEGESTUFE.Write();
        }

        public void WriteAufenthalt(bool bewerberbeuanlage)
        {
            if (bewerberbeuanlage)
                Aufenthalt.WriteBewerberneuanlage();
            else
                Aufenthalt.Write();
            _AufenthaltZusatz.Update(_dsAufenthaltZusatz, AufenthaltZusatzMode.Klient);
        }

        public dsKontaktpersonen GetkontalPersonen(bool ExternerDienstleister)
        {
            if (ExternerDienstleister)
                return KLIENT_DIENSTLEISTER;

            return KLIENT_KONTAKTPERSONEN;
        }

        private void FillKontaktpersonen()
        {
            Kontaktperson Kontaktperson;
            StringBuilder sbName, sbAdresse;
            KLIENT_KONTAKTPERSONEN.Kontaktperson.Clear();
            KLIENT_DIENSTLEISTER.Kontaktperson.Clear();

            foreach (dsKontaktperson.KontaktpersonRow r in _db.KOTAKTPERSONEN.Kontaktperson)
            {
                sbName = new StringBuilder();
                sbAdresse = new StringBuilder();
                
                Kontaktperson = new Kontaktperson(r.ID);
            
                sbName.Append(Kontaktperson.Nachname + " " + Kontaktperson.Vorname);

                if (!String.IsNullOrWhiteSpace(Kontaktperson.Titel))
                    sbName.Append(", " + Kontaktperson.Titel);
                
                if (!String.IsNullOrWhiteSpace(Kontaktperson.Kontakt.Tel))
                    sbAdresse.Append("Tel:" + Kontaktperson.Kontakt.Tel + " /");
                
                if(!String.IsNullOrWhiteSpace(Kontaktperson.Kontakt.Mobil))
                {
                    if(!String.IsNullOrWhiteSpace(Kontaktperson.Kontakt.Tel))
                        sbAdresse.Append(" ");
                    sbAdresse.Append("Mobil" +Kontaktperson.Kontakt.Mobil+" /");
                }
                
                if (!String.IsNullOrWhiteSpace(Kontaktperson.Adresse.Strasse))
                    sbAdresse.Append(" " + Kontaktperson.Adresse.Strasse);
                
                if (!String.IsNullOrWhiteSpace(Kontaktperson.Adresse.Plz))
                    sbAdresse.Append(" " + Kontaktperson.Adresse.Plz);
                
                if (!String.IsNullOrWhiteSpace(Kontaktperson.Adresse.Ort))
                    sbAdresse.Append(" " + Kontaktperson.Adresse.Ort);

                StringBuilder sMail = new StringBuilder();
                if (Kontaktperson.Kontakt.Email != null && !String.IsNullOrWhiteSpace(Kontaktperson.Kontakt.Email))
                    sMail.Append(" " + Kontaktperson.Kontakt.Email.Trim());
                

                if (!r.ExternerDienstleisterJN)
                {
                    KLIENT_KONTAKTPERSONEN.Kontaktperson.AddKontaktpersonRow(r.ID, r.IDPatient, r.IDAdresse, r.IDKontakt,
                                          r.VerstaendigenJN, sbName.ToString(), r.Kontaktart, sbAdresse.ToString(), Kontaktperson.Verwandschaft.Trim(), sMail.ToString().Trim());
                }
                else
                {
                    KLIENT_DIENSTLEISTER.Kontaktperson.AddKontaktpersonRow(r.ID, r.IDPatient, r.IDAdresse, r.IDKontakt,
                                          r.VerstaendigenJN, sbName.ToString(), r.Kontaktart, sbAdresse.ToString(), Kontaktperson.Verwandschaft.Trim(), sMail.ToString().Trim());
                }
            }

            KLIENT_KONTAKTPERSONEN.Kontaktperson.AcceptChanges();
            KLIENT_DIENSTLEISTER.Kontaktperson.AcceptChanges();
        }

        private void FillKlientSachwalter()
        {
            Sachwalter Sachwalter;
            StringBuilder sbName, sbBelange;
            KLIENT_SACHWALTER.Sachwalter.Clear();

            foreach (dsSachwalter.SachwalterRow r in _db.SACHWALTER.Sachwalter)
            {
                sbName = new StringBuilder();
                sbBelange = new StringBuilder();

                Sachwalter = new Sachwalter(r.ID);

                sbName.Append(Sachwalter.Nachname + " " + Sachwalter.Vorname);

                if (!String.IsNullOrWhiteSpace(Sachwalter.Titel))
                    sbName.Append(", " + Sachwalter.Titel);
                
                if (r.SachwalterJN)
                    sbBelange.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter "));
                else
                    sbBelange.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgebevollmächtigte "));
                
                if (!String.IsNullOrWhiteSpace(r.Belange))
                    sbBelange.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("für ") + r.Belange.Trim());
                
                if (!r.IsVonNull())
                {
                    if (r.IsBisNull())
                        sbBelange.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ") + r.Von.Date.ToShortDateString());
                    else
                        sbBelange.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" von ") + r.Von.Date.ToShortDateString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ") + r.Bis.Date.ToShortDateString());
                }

                dsKlientSachwalter.SachwalterRow row = KLIENT_SACHWALTER.Sachwalter.AddSachwalterRow(r.ID, r.IDPatient, r.IDAdresse, r.IDKontakt,
                                      sbName.ToString(), sbBelange.ToString(), DateTime.MinValue);

                if (!r.IsBestimmtAmNull())
                    row.BestimmtAm = r.BestimmtAm;
                else
                    row.SetBestimmtAmNull();
            }

            KLIENT_SACHWALTER.Sachwalter.AcceptChanges();
        }

        /// <summary>
        /// Liste alle Kontaktpersonen eines Klients füllen
        /// </summary>
        private void InitKontaktpersonen()
        {
            _kontaktpersonen = new List<Kontaktperson>();

            foreach (dsKontaktperson.KontaktpersonRow row in _db.KOTAKTPERSONEN.Kontaktperson)
            {
                _kontaktpersonen.Add(new Kontaktperson(row.ID));
            }
        }

        /// <summary>
        /// Liste alle Sachwalter eines Klients füllen
        /// </summary>
        private void InitSachwalter()
        {
            _listSachwalter = new List<Sachwalter>();

            foreach (dsSachwalter.SachwalterRow row in _db.SACHWALTER.Sachwalter)
            {
                _listSachwalter.Add(new Sachwalter(row.ID));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// vollständiger Name
        /// </summary>
        //----------------------------------------------------------------------------
        public string FullName
        {
            get { return Titel + " " + Nachname + " " + Vorname; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// wichtige Informationen
        /// </summary>
        //----------------------------------------------------------------------------
        public string FullInfo
        {
            get { return FullInfoWithFormat(ENV.String("PATIENT_BASEINFO")); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// wichtige Informationen
        /// </summary>
        //----------------------------------------------------------------------------
        public string FullInfoNoAge
        {
            get { return FullInfoWithFormat(ENV.String("PATIENT.INFO_NOAGE")); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// wichtige Informationen mit Formatierung ausgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public string FullInfoWithFormat(string sFormat)
        {
            string gebDatum = "?";
            string age = "?";

            if (Geburtsdatum != null)
            {
                DateTime birth = (DateTime)Geburtsdatum;
                gebDatum = birth.ToShortDateString();
                // rtf: Berechnung ungenau. Es wird nicht beachtet, in welchem Monat und an welchem Tag der Geb-Tag ist
                //age = (DateTime.Now.Year-birth.Year).ToString();
                int years = DateTime.Now.Year - birth.Year;
                if (DateTime.Now.Month < birth.Month)
                {
                    years--;
                }
                else if (DateTime.Now.Month == birth.Month)
                {
                    if (DateTime.Now.Day < birth.Day)
                        years--;
                }
                age = years.ToString();
            }

            return string.Format(sFormat, Titel, Nachname, Vorname, Sexus, gebDatum, age);
        }

        #region PROPERTIES
        public Adresse Adresse
        {
            get { return _adresse; }
        }

        public Kontakt Kontakt
        {
            get { return _kontak; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// aktueller Aufenthalt
        /// </summary>
        //----------------------------------------------------------------------------
        public void newAufenthalt()
        {
            this._aufenthalt = new Aufenthalt();
        }
        public Aufenthalt Aufenthalt
        {
            get
            {
                if (_aufenthalt == null)
                {
                    Guid id = Aufenthalt.LastByPatient(ID);

                    if (id.Equals(System.Guid.Empty) && KlientDetails.searchLastEntlassenenAufenthalt)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getLastAufenthaltEntlassen(this.IDPatient, db);
                            _aufenthalt = new Aufenthalt(rAufenthalt.ID);
                        }
                    }
                    else
                    {
                        if (id == System.Guid.Empty)
                        {
                            _aufenthalt = new Aufenthalt();
                            _aufenthalt.IDPatient = this.IDPatient;
                        }

                        else
                            _aufenthalt = new Aufenthalt(id);
                    }
                }

                return _aufenthalt;
            }
        }
        public KlientKlinik KLINIK
        {
            get { return _klinik; }
        }

        public Aerzte CLASS_AERZTE
        {
            get { return _Aerzte; }
        }

        public KlientMedizinischeDaten MEDIZINISCHE_DATEN
        {
            get { return _medDaten; }
        }

        public KlientPflegestufe PATIENTPFLEGESTUFE
        {
            get { return _pateintPflegestufe; }
        }

        public Rehabilitation REHABILITATION
        {
            get { return _rehabilitation; }
        }

        public Gegenstaende GEGENSTAENDE
        {
            get { return _gegenstaende; }
        }

        public Unterbringung UNTERBRINGUNG
        {
            get { return _unterbringung; }
        }

        public Guid ID
        {
            get { return DB_KLIENT_ROW.ID; }
            set { DB_KLIENT_ROW.ID = value; }
        }
        public Guid IDAdresse
        {
            get { return DB_KLIENT_ROW.IDAdresse; }
            set { DB_KLIENT_ROW.IDAdresse = value; }
        }

        public Nullable<Guid> IDAdresseSub
        {
            get
            {
                if (DB_KLIENT_ROW.IsIDAdresseSubNull())
                {
                    return null;
                }
                else
                {
                    return DB_KLIENT_ROW.IDAdresseSub;
                }
            }
            set
            {
                if (value == null)
                {
                    DB_KLIENT_ROW.SetIDAdresseSubNull();
                }
                else
                {
                    DB_KLIENT_ROW.IDAdresseSub = value.Value;
                }
                
            }
        }
        public Nullable<Guid> IDKontaktSub
        {
            get
            {
                if (DB_KLIENT_ROW.IsIDKontaktSubNull())
                {
                    return null;
                }
                else
                {
                    return DB_KLIENT_ROW.IDKontaktSub;
                }
            }
            set
            {
                if (value == null)
                {
                    DB_KLIENT_ROW.SetIDKontaktSubNull();
                }
                else
                {
                    DB_KLIENT_ROW.IDKontaktSub = value.Value;
                }

            }
        }

        public object IDBenutzer
        {
            get 
            { 
                if(DB_KLIENT_ROW.IsIDBenutzerNull())
                    return null;
                else
                    return DB_KLIENT_ROW.IDBenutzer; 
            }
            set 
            {
                if (value != null)
                    DB_KLIENT_ROW.IDBenutzer = (Guid)value;
                else
                    DB_KLIENT_ROW.SetIDBenutzerNull();
            }
        }

        public Guid IDKontakt
        {
            get { return DB_KLIENT_ROW.IDKontakt; }
            set { DB_KLIENT_ROW.IDKontakt = value; }
        }
        
        public string Nachname
        {
            get 
            { 
                if(!DB_KLIENT_ROW.IsNachnameNull())
                    return DB_KLIENT_ROW.Nachname.Trim();
                return "";
            }
            set { DB_KLIENT_ROW.Nachname = value.Trim(); }
        }
        public string Vorname
        {
            get 
            { 
                if(!DB_KLIENT_ROW.IsVornameNull())
                    return DB_KLIENT_ROW.Vorname.Trim();
                return "";
            }
            set { DB_KLIENT_ROW.Vorname = value.Trim(); }
        }
        public string Titel
        {
            get 
            {
                if(!DB_KLIENT_ROW.IsTitelNull())
                    return DB_KLIENT_ROW.Titel.Trim();
                return "";
            }
            set { DB_KLIENT_ROW.Titel = value; }
        }

        /// <summary>
        /// Liefert Herr oder Frau
        /// </summary>
        public string Anrede
        {
            get { return DB_KLIENT_ROW.IsAnredeNull() ? "" : DB_KLIENT_ROW.Anrede.Trim(); }
            set { DB_KLIENT_ROW.Anrede = value; }
        }

        /// <summary>
        /// Liefert Titel, Vorname, Nachname
        /// </summary>
        public string Briefname
        {
            get
            {
                if (Titel.Trim().Length > 0)
                    return Titel + " " + Vorname.Trim() + " " + Nachname.Trim();
                else
                    return Vorname.Trim() + " " + Nachname.Trim();
            }
        }

        public string Angehörige
        {
            get
            {
                if (DB_KLIENT_ROW.IsAngehörigeNull())
                    return "";
                return DB_KLIENT_ROW.Angehörige.Trim();
            }
            set { DB_KLIENT_ROW.Angehörige = value; }
        }
        public string Betreuer
        {
            get { return DB_KLIENT_ROW.IsBetreuerNull() ? "" : DB_KLIENT_ROW.Betreuer.Trim(); }
            set { DB_KLIENT_ROW.Betreuer = value; }
        }
        public string Besonderheit
        {
            get { return DB_KLIENT_ROW.IsBesonderheitNull() ? "" : DB_KLIENT_ROW.Besonderheit.Trim(); }
            set { DB_KLIENT_ROW.Besonderheit = value; }
        }
        public string BlutGruppe
        {
            get 
            {
                if (!DB_KLIENT_ROW.IsBlutGruppeNull())
                    return DB_KLIENT_ROW.BlutGruppe.Trim();
                else
                    return "";
            }
            set { DB_KLIENT_ROW.BlutGruppe = value; }
        }
        public string Rhesusfaktor
        {
            get 
            {
                if (!DB_KLIENT_ROW.IsResusfaktorNull())
                    return DB_KLIENT_ROW.Resusfaktor.Trim();
                else
                    return "";
            }
            set { DB_KLIENT_ROW.Resusfaktor = value; }
        }
        public string Depotinjektion
        {
            get { return DB_KLIENT_ROW.IsDepotinjektionNull() ? "" : DB_KLIENT_ROW.Depotinjektion.Trim(); }
            set { DB_KLIENT_ROW.Depotinjektion = value; }
        }
        public string Hausarzt
        {
            get { return DB_KLIENT_ROW.IsHausarztNull() ? "" : DB_KLIENT_ROW.Hausarzt.Trim(); }
            set { DB_KLIENT_ROW.Hausarzt = value; }
        }
        public string Staatsb
        {
            get { return DB_KLIENT_ROW.IsStaatsbNull() ? "" : DB_KLIENT_ROW.Staatsb.Trim(); }
            set { DB_KLIENT_ROW.Staatsb = value; }
        }
        public string Konfision
        {
            get { return DB_KLIENT_ROW.IsKonfisionNull() ? "" : DB_KLIENT_ROW.Konfision.Trim(); }
            set { DB_KLIENT_ROW.Konfision = value; }
        }
        public string Familienstand
        {
            get { return DB_KLIENT_ROW.IsFamilienstandNull() ? "" : DB_KLIENT_ROW.Familienstand.Trim(); }
            set { DB_KLIENT_ROW.Familienstand = value; }
        }
        public string KrankenKasse
        {
            get { return DB_KLIENT_ROW.IsKrankenKasseNull() ? "" : DB_KLIENT_ROW.KrankenKasse.Trim(); }
            set { DB_KLIENT_ROW.KrankenKasse = value; }
        }
        public string VersicherungsNr
        {
            get { return DB_KLIENT_ROW.IsVersicherungsNrNull() ? "" : DB_KLIENT_ROW.VersicherungsNr.Trim(); }
            set { DB_KLIENT_ROW.VersicherungsNr = value; }
        }
        public string Klasse
        {
            get { return DB_KLIENT_ROW.IsKlasseNull() ? "" : DB_KLIENT_ROW.Klasse.Trim(); }
            set { DB_KLIENT_ROW.Klasse = value; }
        }
        public string Geburtsort
        {
            get { return DB_KLIENT_ROW.IsGeburtsortNull() ? "" : DB_KLIENT_ROW.Geburtsort.Trim(); }
            set { DB_KLIENT_ROW.Geburtsort = value; }
        }
        public string LedigerName
        {
            get { return DB_KLIENT_ROW.IsLedigerNameNull() ? "" : DB_KLIENT_ROW.LedigerName.Trim(); }
            set { DB_KLIENT_ROW.LedigerName = value; }
        }
        public string ErlernterBeruf
        {
            get { return DB_KLIENT_ROW.IsErlernterBerufNull() ? "" : DB_KLIENT_ROW.ErlernterBeruf.Trim(); }
            set { DB_KLIENT_ROW.ErlernterBeruf = value; }
        }
        public string KrankengeldSeit
        {
            get { return DB_KLIENT_ROW.IsKrankengeldSeitNull() ? "" : DB_KLIENT_ROW.KrankengeldSeit.Trim(); }
            set { DB_KLIENT_ROW.KrankengeldSeit = value; }
        }
        public string ArbeitslosBezSeit
        {
            get { return DB_KLIENT_ROW.IsArbeitslosBezSeitNull()? "" : DB_KLIENT_ROW.ArbeitslosBezSeit.Trim(); }
            set { DB_KLIENT_ROW.ArbeitslosBezSeit = value; }
        }
        public string Hauptversicherung
        {
            get { return DB_KLIENT_ROW.IsHauptversicherungNull() ? "" : DB_KLIENT_ROW.Hauptversicherung.Trim(); }
            set { DB_KLIENT_ROW.Hauptversicherung = value; }
        }
        public string SterbeRegel
        {
            get { return DB_KLIENT_ROW.IsSterbeRegelNull() ? "" : DB_KLIENT_ROW.SterbeRegel.Trim(); }
            set { DB_KLIENT_ROW.SterbeRegel = value; }
        }
        public string Vermerk
        {
            get { return DB_KLIENT_ROW.IsVermerkNull() ? "" : DB_KLIENT_ROW.Vermerk.Trim(); }
            set { DB_KLIENT_ROW.Vermerk = value; }
        }
        public string Sachwalter
        {
            get
            {
                if (DB_KLIENT_ROW.IsSachwalterNull())
                    return "";
                return DB_KLIENT_ROW.Sachwalter.Trim();
            }
            set { DB_KLIENT_ROW.Sachwalter = value; }
        }
        public string SachWalterBelange
        {
            get { return DB_KLIENT_ROW.IsSachWalterBelangeNull() ? "" : DB_KLIENT_ROW.SachWalterBelange.Trim(); }
            set { DB_KLIENT_ROW.SachWalterBelange = value; }
        }
        public string Sexus
        {
            get { return DB_KLIENT_ROW.IsSexusNull() ? "" : DB_KLIENT_ROW.Sexus.Trim(); }
            set { DB_KLIENT_ROW.Sexus = value; }
        }

        public object Geburtsdatum
        {
            get
            {
                if (DB_KLIENT_ROW.IsGeburtsdatumNull())
                    return null;

                return DB_KLIENT_ROW.Geburtsdatum;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetGeburtsdatumNull();
                else
                    DB_KLIENT_ROW.Geburtsdatum = (DateTime)value;
            }
        }
        public object SachWalterVon
        {
            get
            {
                if (DB_KLIENT_ROW.IsSachWalterVonNull())
                    return null;

                return DB_KLIENT_ROW.SachWalterVon;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetSachWalterVonNull();
                else
                    DB_KLIENT_ROW.SachWalterVon = (DateTime)value;
            }
        }
        public object SachWalterBis
        {
            get
            {
                if (DB_KLIENT_ROW.IsSachWalterBisNull())
                    return null;

                return DB_KLIENT_ROW.SachWalterBis;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetSachWalterBisNull();
                else
                    DB_KLIENT_ROW.SachWalterBis = (DateTime)value;
            }
        }

        public bool RezeptGebuehrbefreiungJN
        {
            get { return DB_KLIENT_ROW.RezeptgebuehrbefreiungJN; }
            set 
            {
                DB_KLIENT_ROW.RezeptgebuehrbefreiungJN = value;
            }
        }
        //public bool AbwesenheitenHändischBerechJN
        //{
        //    get { return DB_KLIENT_ROW.AbwesenheitenHändischBerechJN; }
        //    set { DB_KLIENT_ROW.AbwesenheitenHändischBerechJN = value; }
        //}
        public bool PflegegeldantragJN
        {
            get { return DB_KLIENT_ROW.PflegegeldantragJN; }
            set { DB_KLIENT_ROW.PflegegeldantragJN = value; }
        }

        public bool Verstorben
        {
            get { return DB_KLIENT_ROW.Verstorben; }
            set { DB_KLIENT_ROW.Verstorben = value; }
        }

        public object Todeszeitpunkt
        {
            get
            {
                if (DB_KLIENT_ROW.IsTodeszeitpunktNull())
                    return null;

                return DB_KLIENT_ROW.Todeszeitpunkt;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetTodeszeitpunktNull();
                else
                    DB_KLIENT_ROW.Todeszeitpunkt = (DateTime)value;
            }
        }
        public bool DNR
        {
            get { return DB_KLIENT_ROW.DNR; }
            set { DB_KLIENT_ROW.DNR = value; }
        }

        public object DatumPflegegeldantrag
        {
            get
            {
                if (DB_KLIENT_ROW.IsDatumPflegegeldantragNull())
                    return null;

                return DB_KLIENT_ROW.DatumPflegegeldantrag;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetDatumPflegegeldantragNull();
                else
                    DB_KLIENT_ROW.DatumPflegegeldantrag = (DateTime)value;
            }
        }

        public bool PensionsteilungsantragJN
        {
            get { return DB_KLIENT_ROW.PensionsteilungsantragJN; }
            set { DB_KLIENT_ROW.PensionsteilungsantragJN = value; }
        }

        public object DatumPensionsteilungsantrag
        {
            get
            {
                if (DB_KLIENT_ROW.IsDatumPensionsteilungsantragNull())
                    return null;

                return DB_KLIENT_ROW.DatumPensionsteilungsantrag;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetDatumPensionsteilungsantragNull();
                else
                    DB_KLIENT_ROW.DatumPensionsteilungsantrag = (DateTime)value;
            }
        }

        public string FIBUKonto
        {
            get { return DB_KLIENT_ROW.IsFIBUKontoNull() ? "" : DB_KLIENT_ROW.FIBUKonto.Trim(); }
            set { DB_KLIENT_ROW.FIBUKonto = value; }
        }

        public object RollungVon
        {
            get
            {
                if (DB_KLIENT_ROW.IsRollungVonNull())
                    return null;

                return DB_KLIENT_ROW.RollungVon;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetRollungVonNull();
                else
                    DB_KLIENT_ROW.RollungVon = (DateTime)value;
            }
        }

        public object RollungBis
        {
            get
            {
                if (DB_KLIENT_ROW.IsRollungBisNull())
                    return null;

                return DB_KLIENT_ROW.RollungBis;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetRollungBisNull();
                else
                    DB_KLIENT_ROW.RollungBis = (DateTime)value;
            }
        }

        public int Groesse
        {
            get { return DB_KLIENT_ROW.IsGroesseNull() ? 0 : DB_KLIENT_ROW.Groesse; }
            set { DB_KLIENT_ROW.Groesse = value; }
        }

        public string Statur
        {
            get { return DB_KLIENT_ROW.IsStaturNull() ? "" : DB_KLIENT_ROW.Statur.Trim(); }
            set { DB_KLIENT_ROW.Statur = value; }
        }

        public object Namenstag
        {
            get
            {
                if (DB_KLIENT_ROW.IsNamenstagNull())
                    return null;

                return DB_KLIENT_ROW.Namenstag;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetNamenstagNull();
                else
                    DB_KLIENT_ROW.Namenstag = (DateTime)value;
            }
        }

        public string Kosename
        {
            get { return DB_KLIENT_ROW.IsKosenameNull() ? "" : DB_KLIENT_ROW.Kosename.Trim(); }
            set { DB_KLIENT_ROW.Kosename = value; }
        }

        public string Privatversicherung
        {
            get { return DB_KLIENT_ROW.IsPrivatversicherungNull() ? "" : DB_KLIENT_ROW.Privatversicherung.Trim(); }
            set { DB_KLIENT_ROW.Privatversicherung = value; }
        }

        public string PrivPolNr
        {
            get { return DB_KLIENT_ROW.IsPrivPolNrNull() ? "" : DB_KLIENT_ROW.PrivPolNr.Trim(); }
            set { DB_KLIENT_ROW.PrivPolNr = value; }
        }

        public string Augenfarbe
        {
            get { return DB_KLIENT_ROW.IsAugenfarbeNull() ? "" : DB_KLIENT_ROW.Augenfarbe.Trim(); }
            set { DB_KLIENT_ROW.Augenfarbe = value; }
        }

        public string Haarfarbe
        {
            get { return DB_KLIENT_ROW.IsHaarfarbeNull() ? "" : DB_KLIENT_ROW.Haarfarbe.Trim(); }
            set { DB_KLIENT_ROW.Haarfarbe = value; }
        }

        //public byte[] Foto2
        //{
        //    get { return DB_KLIENT_ROW.IsFotoNull() ? null : DB_KLIENT_ROW.Foto; }
        //    set 
        //    {
        //        if (value == null)
        //            DB_KLIENT_ROW.SetFotoNull();
        //        else
        //            DB_KLIENT_ROW.Foto = value;            
        //    }
        //}

        public bool FernsehgebuehrbefreiungJN
        {
            get { return DB_KLIENT_ROW.IsFernsehgebuehrbefreiungJNNull() ? false : DB_KLIENT_ROW.FernsehgebuehrbefreiungJN; }
            set { DB_KLIENT_ROW.FernsehgebuehrbefreiungJN = value; }
        }

        public bool TelefongebuehrbefreiungJN
        {
            get { return DB_KLIENT_ROW.IsTelefongebuehrbefreiungJNNull() ? false : DB_KLIENT_ROW.TelefongebuehrbefreiungJN; }
            set { DB_KLIENT_ROW.TelefongebuehrbefreiungJN = value; }
        }
        
        public string BesondereAeusserlicheKennzeichen
        {
            get { return DB_KLIENT_ROW.IsBesondereAeusserlicheKennzeichenNull() ? "" : DB_KLIENT_ROW.BesondereAeusserlicheKennzeichen.Trim(); }
            set { DB_KLIENT_ROW.BesondereAeusserlicheKennzeichen = value; }
        }

        public string Initialberuehrung
        {
            get { return DB_KLIENT_ROW.IsInitialberuehrungNull() ? "" : DB_KLIENT_ROW.Initialberuehrung.Trim(); }
            set { DB_KLIENT_ROW.Initialberuehrung = value; }
        }

        public string Kennwort
        {
            get {
                if (DB_KLIENT_ROW.Kennwort.Equals(System.DBNull.Value))
                {
                    return "";
                }
                else
                {
                    return DB_KLIENT_ROW.Kennwort.Trim();
                }
            ;
            }
            //get { return DB_KLIENT_ROW.IsKennwortNull() ? "" : DB_KLIENT_ROW.Kennwort.Trim(); }
            set { DB_KLIENT_ROW.Kennwort = value; }
        }

        public string Krankenkasse
        {
            get { return DB_KLIENT_ROW.IsKrankenKasseNull() ? "" : DB_KLIENT_ROW.KrankenKasse.Trim(); }
            set { DB_KLIENT_ROW.KrankenKasse = value; }
        }

        public bool WohnungAbgemeldetJN
        {
            get { return DB_KLIENT_ROW.IsWohnungAbgemeldetJNNull() ? false : DB_KLIENT_ROW.WohnungAbgemeldetJN; }
            set { DB_KLIENT_ROW.WohnungAbgemeldetJN = value; }
        }

        public bool LiftJN
        {
            get { return DB_KLIENT_ROW.IsLiftJNNull() ? false : DB_KLIENT_ROW.LiftJN; }
            set { DB_KLIENT_ROW.LiftJN = value; }
        }

        public string Wohnsituation
        {
            get { return DB_KLIENT_ROW.IsWohnsituationNull() ? "" : DB_KLIENT_ROW.Wohnsituation.Trim(); }
            set { DB_KLIENT_ROW.Wohnsituation = value; }
        }

        public string Zustaendigestelle
        {
            get { return DB_KLIENT_ROW.IsZustaendige_StelleNull() ? "" : DB_KLIENT_ROW.Zustaendige_Stelle.Trim(); }
            set { DB_KLIENT_ROW.Zustaendige_Stelle = value; }
        }

        public string Klingeln
        {
            get { return DB_KLIENT_ROW.IsKlingelnNull() ? "" : DB_KLIENT_ROW.Klingeln.Trim(); }
            set { DB_KLIENT_ROW.Klingeln = value; }
        }

        public string Haustier
        {
            get { return DB_KLIENT_ROW.IsHaustierNull() ? "" : DB_KLIENT_ROW.Haustier.Trim(); }
            set { DB_KLIENT_ROW.Haustier = value; }
        }

        public bool BewerbungaktivJN
        {
            get { return DB_KLIENT_ROW.IsBewerbungaktivJNNull() ? false : DB_KLIENT_ROW.BewerbungaktivJN; }
            set { DB_KLIENT_ROW.BewerbungaktivJN = value; }
        }

        public object BewerbungDatum
        {
            get
            {
                if (DB_KLIENT_ROW.IsBewerbungDatumNull())
                    return null;

                return DB_KLIENT_ROW.BewerbungDatum;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetBewerbungDatumNull();
                else
                    DB_KLIENT_ROW.BewerbungDatum = (DateTime)value;
            }
        }

        public string Prioritaet
        {
            get { return DB_KLIENT_ROW.IsPrioritaetNull() ? "" : DB_KLIENT_ROW.Prioritaet.Trim(); }
            set { DB_KLIENT_ROW.Prioritaet = value; }
        }

        public string PflegeArt
        {
            get { return DB_KLIENT_ROW.IsPflegeArtNull() ? "" : DB_KLIENT_ROW.PflegeArt.Trim(); }
            set { DB_KLIENT_ROW.PflegeArt = value; }
        }

        public object EinzugswunschDatum
        {
            get
            {
                if (DB_KLIENT_ROW.IsEinzugswunschDatumNull())
                    return null;

                return DB_KLIENT_ROW.EinzugswunschDatum;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetEinzugswunschDatumNull();
                else
                    DB_KLIENT_ROW.EinzugswunschDatum = (DateTime)value;
            }
        }
        public object AuszugswunschDatum
        {
            get
            {
                if (DB_KLIENT_ROW.IsAuszugswunschDatumNull())
                    return null;

                return DB_KLIENT_ROW.AuszugswunschDatum;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetAuszugswunschDatumNull();
                else
                    DB_KLIENT_ROW.AuszugswunschDatum = (DateTime)value;
            }
        }
        public string BewerbungsGrund
        {
            get { return DB_KLIENT_ROW.IsBewerbungsGrundNull() ? "" : DB_KLIENT_ROW.BewerbungsGrund.Trim(); }
            set { DB_KLIENT_ROW.BewerbungsGrund = value; }
        }
        public string Zimmerwunsch
        {
            get { return DB_KLIENT_ROW.IsZimmerwunschNull() ? "" : DB_KLIENT_ROW.Zimmerwunsch.Trim(); }
            set { DB_KLIENT_ROW.Zimmerwunsch = value; }
        }
        public string SonstigeWuensche
        {
            get { return DB_KLIENT_ROW.IsSonstigeWuenscheNull() ? "" : DB_KLIENT_ROW.SonstigeWuensche.Trim(); }
            set { DB_KLIENT_ROW.SonstigeWuensche = value; }
        }
        public string BewerberBemerkung
        {
            get { return DB_KLIENT_ROW.IsBewerberBemerkungNull() ? "" : DB_KLIENT_ROW.BewerberBemerkung.Trim(); }
            set { DB_KLIENT_ROW.BewerberBemerkung = value; }
        }

        public string WaescheMarkiert
        {
            get { return DB_KLIENT_ROW.IsWaescheMarkiertNull() ? "" : DB_KLIENT_ROW.WaescheMarkiert.Trim(); }
            set { DB_KLIENT_ROW.WaescheMarkiert = value; }
        }

        public string WaescheWaschen
        {
            get { return DB_KLIENT_ROW.IsWaescheWaschenNull() ? "" : DB_KLIENT_ROW.WaescheWaschen.Trim(); }
            set { DB_KLIENT_ROW.WaescheWaschen = value; }
        }

        public string ReligionWunsch
        {
            get { return DB_KLIENT_ROW.IsReligionWunschNull() ? "" : DB_KLIENT_ROW.ReligionWunsch.Trim(); }
            set { DB_KLIENT_ROW.ReligionWunsch = value; }
        }

        public bool KrankensalbungJN
        {
            get {
                if (DB_KLIENT_ROW.IsKrankensalbungJNNull())
                    return false;
                else
                    return DB_KLIENT_ROW.KrankensalbungJN; 
            }
            set { DB_KLIENT_ROW.KrankensalbungJN = value; }
        }

        public bool KommunionJN
        {
            get
            {
                if (DB_KLIENT_ROW.IsKommunionJNNull())
                    return false;
                else
                    return DB_KLIENT_ROW.KommunionJN;
            }
            set { DB_KLIENT_ROW.KommunionJN = value; }
        }

        public bool PatientenverfuegungJN
        {
            get
            {
                if (DB_KLIENT_ROW.IsPatientenverfuegungJNNull())
                    return false;
                else
                    return DB_KLIENT_ROW.PatientenverfuegungJN;
            }
            set { DB_KLIENT_ROW.PatientenverfuegungJN = value; }
        }

        public bool PatientenverfuegungBeachtlichJN
        {
            get
            {
                if (DB_KLIENT_ROW.IsPatientverfuegungAnmerkungNull())
                    return false;
                else
                    return DB_KLIENT_ROW.PatientenverfuegungBeachtlichJN;
            }
            set { DB_KLIENT_ROW.PatientenverfuegungBeachtlichJN = value; }
        }

        public object PatientverfuegungDatum
        {
            get
            {
                if (DB_KLIENT_ROW.IsPatientverfuegungDatumNull())
                    return null;

                return DB_KLIENT_ROW.PatientverfuegungDatum;
            }

            set
            {
                if (value == null)
                    DB_KLIENT_ROW.SetPatientverfuegungDatumNull();
                else
                    DB_KLIENT_ROW.PatientverfuegungDatum = (DateTime)value;
            }
        }

        public string PatientverfuegungAnmerkung
        {
            get { return DB_KLIENT_ROW.IsPatientverfuegungAnmerkungNull() ? "" : DB_KLIENT_ROW.PatientverfuegungAnmerkung.Trim(); }
            set { DB_KLIENT_ROW.PatientverfuegungAnmerkung = value; }
        }

        public string Klientennummer
        {
            get { return DB_KLIENT_ROW.IsKlientennummerNull() ? "" : DB_KLIENT_ROW.Klientennummer.Trim(); }
            set { DB_KLIENT_ROW.Klientennummer = value; }
        }

        //Neu nach 03.09.2008 MDA
        public Guid IDAbteilung
        {
            get { return DB_KLIENT_ROW.IsIDAbteilungNull() ? Guid.Empty : DB_KLIENT_ROW.IDAbteilung; }
            set { DB_KLIENT_ROW.IDAbteilung = value; }
        }

        public Guid IDBereich
        {
            get { return DB_KLIENT_ROW.IsIDBereichNull() ? Guid.Empty : DB_KLIENT_ROW.IDBereich; }
            set { DB_KLIENT_ROW.IDBereich = value; }
        }

        public bool Milieubetreuung
        {
            get
            {
                return DB_KLIENT_ROW.Milieubetreuung;
            }
            set
            {
                DB_KLIENT_ROW.Milieubetreuung = value;
            }
        }
        public bool KZUeberlebender
        {
            get
            {
                return DB_KLIENT_ROW.KZUeberlebender;
            }
            set
            {
                DB_KLIENT_ROW.KZUeberlebender = value;
            }
        }
        public bool Anatomie
        {
            get
            {
                return DB_KLIENT_ROW.Anatomie;
            }
            set
            {
                DB_KLIENT_ROW.Anatomie = value;
            }
        }
        public bool Einzelzimmer
        {
            get
            {
                return DB_KLIENT_ROW.Einzelzimmer;
            }
            set
            {
                DB_KLIENT_ROW.Einzelzimmer = value;
            }
        }
        public bool Selbstzahler
        {
            get
            {
                return DB_KLIENT_ROW.Selbstzahler;
            }
            set
            {
                DB_KLIENT_ROW.Selbstzahler = value;
            }
        }


        public bool KürzungLetzterTagAnwesenheit
        {
            get
            {
                return DB_KLIENT_ROW.KürzungLetzterTagAnwesenheit;
            }
            set
            {
                DB_KLIENT_ROW.KürzungLetzterTagAnwesenheit = value;
            }
        }
        public bool Behindertenausweis
        {
            get
            {
                return DB_KLIENT_ROW.Behindertenausweis;
            }
            set
            {
                DB_KLIENT_ROW.Behindertenausweis = value;
            }
        }
        public bool Sozialcard
        {
            get
            {
                return DB_KLIENT_ROW.Sozialcard;
            }
            set
            {
                DB_KLIENT_ROW.Sozialcard = value;
            }
        }

        #endregion
    }
}
