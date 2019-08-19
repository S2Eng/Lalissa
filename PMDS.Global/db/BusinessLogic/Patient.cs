using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using System.Data.OleDb;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;



namespace PMDS.BusinessLogic
{



	public class Patient : AdresseKontaktBasis, IBusinessBase, IZusatz
	{
		private DBPatient	_db = new DBPatient();
		private Aufenthalt	_auf = null;



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

        public  byte[] GetFoto(Guid IDPatient)
        {
            return _db.GetFoto(IDPatient);
        }

		public static dsGUIDListe.IDListeDataTable All()
		{
			return (dsGUIDListe.IDListeDataTable)new Patient().AllEntries();
		}


        // Alle Einträge mit dem gesuchten Filter ermitteln 
        public static dsPatientStation.PatientDataTable ByFilter(string pattern,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, bool bShowEntlassene, System.Guid IDKlinik)
        {
            return ByFilter(pattern, bKlinik, idAbteilung, idBereich, bShowEntlassene, Guid.Empty, IDKlinik);
        }
        public static dsPatientStation.PatientDataTable GetKlientenNurBewerber()
        {
            return new Patient()._db.GetKlientenNurBewerber();
        }

        // Alle Einträge mit dem gesuchten Filter ermitteln
        public static dsPatientStation.PatientDataTable ByFilter(string pattern,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, bool bShowEntlassene, Guid CurrentIDBezugsPfleger, System.Guid IDKlinik)
        {
            return new Patient()._db.ByFilter(pattern, bKlinik, idAbteilung, idBereich, bShowEntlassene, CurrentIDBezugsPfleger, IDKlinik);
        }

		public static dsPatientStation.PatientDataTable ByFilter(Guid idPatient)
		{
			return new Patient()._db.ByFilter(idPatient);
		}

        
		public static bool IsUserDefined(string vorname, string nachname, DateTime gebDatum)
		{
			return DBPatient.IsUserDefined(vorname, nachname, gebDatum);
		}

		public Patient()
		{
			New();
		}

		public Patient(Guid id)
		{
			Read(id);
		}

		public override void New()
		{
			base.New();
			_auf = null;
		}

		public override void Read()
		{
			base.Read();
			_auf = null;
		}

		public override void Write()
		{
			base.Write();

			if (_auf != null)
				_auf.Write();
		}

		#region Datenbank-Mapper
		protected dsPatient.PatientRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
		public Guid ID
		{
			get	{	return DB_ROW.ID;	}
            set	{	DB_ROW.ID = value;	}
		}
		public override Guid IDAdresse
		{
			get	{	return DB_ROW.IDAdresse;	}
			set	{	DB_ROW.IDAdresse = value;	}
		}
		public override Guid IDKontakt
		{
			get	{	return DB_ROW.IDKontakt;	}
			set	{	DB_ROW.IDKontakt = value;	}
		}
		public string Nachname
		{
			get	{	return DB_ROW.Nachname;	}
			set	{	DB_ROW.Nachname = value;	}
		}
        public string NameVollstaendig
        {
            get {
                String str = DB_ROW.Titel + " " + DB_ROW.Nachname + " " + DB_ROW.Vorname;
                return str.Trim(); 
            }
            set { DB_ROW.Nachname = value; }
        }
        public string Vorname
		{
			get	{	return DB_ROW.Vorname;	}
			set	{	DB_ROW.Vorname = value;	}
		}
		public string Titel
		{
			get	{	
                
                if (DB_ROW.IsTitelNull())
                {
                  return "";
                }
                else
                {
                  return DB_ROW.Titel;
                }

              	}
			set	{	DB_ROW.Titel = value;	}
		}

		public string Angehörige
		{
			get	
            {
                if (DB_ROW.IsAngehörigeNull())
                    return "";
                return DB_ROW.Angehörige;	
            }
			set	{	DB_ROW.Angehörige = value;	}
		}
		public string Betreuer
		{
			get	{	return DB_ROW.Betreuer;	}
			set	{	DB_ROW.Betreuer = value;	}
		}
		public string Besonderheit
		{
			get	{	return DB_ROW.Besonderheit;	}
			set	{	DB_ROW.Besonderheit = value;	}
		}
		public string BlutGruppe
		{
			get	{	return DB_ROW.BlutGruppe;	}
			set	{	DB_ROW.BlutGruppe = value;	}
		}
		public string Resusfaktor
		{
			get	{	return DB_ROW.Resusfaktor;	}
			set	{	DB_ROW.Resusfaktor = value;	}
		}
		public string Depotinjektion
		{
			get	{	return DB_ROW.Depotinjektion;	}
			set	{	DB_ROW.Depotinjektion = value;	}
		}
		public string Hausarzt
		{
			get	{	return DB_ROW.Hausarzt;	}
			set	{	DB_ROW.Hausarzt = value;	}
		}
		public string Staatsb
		{
			get	{	return DB_ROW.Staatsb;	}
			set	{	DB_ROW.Staatsb = value;	}
		}
		public string Konfession
		{
			get	{	return DB_ROW.Konfision;	}
			set	{	DB_ROW.Konfision = value;	}
		}
		public string Familienstand
		{
			get	{	return DB_ROW.Familienstand;	}
			set	{	DB_ROW.Familienstand = value;	}
		}
		public string KrankenKasse
		{
			get	{	return DB_ROW.KrankenKasse;	}
			set	{	DB_ROW.KrankenKasse = value;	}
		}
		public string VersicherungsNr
		{
			get	{	return DB_ROW.VersicherungsNr;	}
			set	{	DB_ROW.VersicherungsNr = value;	}
		}
		public string Klasse
		{
			get	{	return DB_ROW.Klasse;	}
			set	{	DB_ROW.Klasse = value;	}
		}
		public string Geburtsort
		{
			get	{	return DB_ROW.Geburtsort;	}
			set	{	DB_ROW.Geburtsort = value;	}
		}
		public string LedigerName
		{
			get	{	return DB_ROW.LedigerName;	}
			set	{	DB_ROW.LedigerName = value;	}
		}
		public string ErlernterBeruf
		{
			get	{	return DB_ROW.ErlernterBeruf;	}
			set	{	DB_ROW.ErlernterBeruf = value;	}
		}
		public string KrankengeldSeit
		{
			get	{	return DB_ROW.KrankengeldSeit;	}
			set	{	DB_ROW.KrankengeldSeit = value;	}
		}
		public string ArbeitslosBezSeit
		{
			get	{	return DB_ROW.ArbeitslosBezSeit;	}
			set	{	DB_ROW.ArbeitslosBezSeit = value;	}
		}
		public string Hauptversicherung
		{
			get	{	return DB_ROW.Hauptversicherung;	}
			set	{	DB_ROW.Hauptversicherung = value;	}
		}
		public string SterbeRegel
		{
			get	{	return DB_ROW.SterbeRegel;	}
			set	{	DB_ROW.SterbeRegel = value;	}
		}
		public string Vermerk
		{
			get	{	return DB_ROW.Vermerk;	}
			set	{	DB_ROW.Vermerk = value;	}
		}
		public string Sachwalter
		{
			get	
            {
                if (DB_ROW.IsSachwalterNull())
                    return "";
                return DB_ROW.Sachwalter;	
            }
			set	{	DB_ROW.Sachwalter = value;	}
		}
		public string SachWalterBelange
		{
			get	{	return DB_ROW.SachWalterBelange;	}
			set	{	DB_ROW.SachWalterBelange = value;	}
		}
		public string Sexus
		{
			get	{	return DB_ROW.Sexus;	}
			set	{	DB_ROW.Sexus = value;	}
		}

		public object Geburtsdatum
		{
			get	
			{
				if (DB_ROW.IsGeburtsdatumNull())
					return null;

				return DB_ROW.Geburtsdatum;
			}

			set
			{
				if (value == null)
					DB_ROW.SetGeburtsdatumNull();
				else
					DB_ROW.Geburtsdatum = (DateTime)value;
			}
		}
		public object SachWalterVon
		{
			get	
			{
				if (DB_ROW.IsSachWalterVonNull())
					return null;

				return DB_ROW.SachWalterVon;
			}

			set
			{
				if (value == null)
					DB_ROW.SetSachWalterVonNull();
				else
					DB_ROW.SachWalterVon = (DateTime)value;
			}
		}

		public object SachWalterBis
		{
			get	
			{
				if (DB_ROW.IsSachWalterBisNull())
					return null;

				return DB_ROW.SachWalterBis;
			}

			set
			{
				if (value == null)
					DB_ROW.SetSachWalterBisNull();
				else
					DB_ROW.SachWalterBis = (DateTime)value;
			}
		}

        public bool WohnungAbgemeldetJN
        {
            get { return DB_ROW.WohnungAbgemeldetJN; }
            set { DB_ROW.WohnungAbgemeldetJN = value; }
        }

        public bool RezeptGebuehrbefreiungJN
        {
            get { return DB_ROW.RezeptgebuehrbefreiungJN; }
            set { DB_ROW.RezeptgebuehrbefreiungJN = value; }
        }

        public bool PflegegeldantragJN
        {
            get { return DB_ROW.PflegegeldantragJN;}
            set { DB_ROW.PflegegeldantragJN = value; }
        }

        public object DatumPflegegeldantrag
        {
            get
            {
                if (DB_ROW.IsDatumPflegegeldantragNull())
                    return null;

                return DB_ROW.DatumPflegegeldantrag;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetDatumPflegegeldantragNull();
                else
                    DB_ROW.DatumPflegegeldantrag = (DateTime)value;
            }
        }

        public bool PensionsteilungsantragJN
        {
            get { return DB_ROW.PensionsteilungsantragJN; }
            set { DB_ROW.PensionsteilungsantragJN = value; }
        }


        public object DatumPensionsteilungsantrag
        {
            get
            {
                if (DB_ROW.IsDatumPensionsteilungsantragNull())
                    return null;

                return DB_ROW.DatumPensionsteilungsantrag;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetDatumPensionsteilungsantragNull();
                else
                    DB_ROW.DatumPensionsteilungsantrag = (DateTime)value;
            }
        }       

        public string FIBUKonto
        {
            get { return DB_ROW.IsFIBUKontoNull() ? "" : DB_ROW.FIBUKonto; }
            set { DB_ROW.FIBUKonto = value; }
        }

        public object RollungVon
        {
            get
            {
                if (DB_ROW.IsRollungVonNull())
                    return null;

                return DB_ROW.RollungVon;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetRollungVonNull();
                else
                    DB_ROW.RollungVon = (DateTime)value;
            }
        }

        public object RollungBis
        {
            get
            {
                if (DB_ROW.IsRollungBisNull())
                    return null;

                return DB_ROW.RollungBis;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetRollungBisNull();
                else
                    DB_ROW.RollungBis = (DateTime)value;
            }
        }

        public string Klientennummer
        {
            get { return DB_ROW.IsKlientennummerNull() ? "" : DB_ROW.Klientennummer; }
            set { DB_ROW.Klientennummer = value; }
        }

        public Nullable<Guid> IDAbteilung
        {
            get
            {
                if (DB_ROW.IsIDAbteilungNull())
                    return null;

                return DB_ROW.IDAbteilung;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetIDAbteilungNull();
                else
                    DB_ROW.IDAbteilung = (Guid)value;
            }
        }
        public Nullable<Guid> IDBereich
        {
            get
            {
                if (DB_ROW.IsIDBereichNull())
                    return null;

                return DB_ROW.IDBereich;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetIDBereichNull();
                else
                    DB_ROW.IDBereich = (Guid)value;
            }
        }
        public bool abwesenheitenHändBerech
        {
            get
            {
                return DB_ROW.abwesenheitenHändBerech;
            }

            set
            {
                DB_ROW.abwesenheitenHändBerech = value;
            }
        }
        public decimal minSaldo
        {
            get
            {
                return DB_ROW.minSaldo;
            }

            set
            {
                DB_ROW.minSaldo = value;
            }
        }
        public string Kennwort
        {
            get
            {
                return DB_ROW.Kennwort;
            }

            set
            {
                DB_ROW.Kennwort = value;
            }
        }
        public byte[] blob_Einverständniserklärung
        {
            get
            {
                if (DB_ROW.Isblob_EinverständniserklärungNull())
                    return null;

                return DB_ROW.blob_Einverständniserklärung;
            }

            set
            {
                if (value == null)
                    DB_ROW.Setblob_EinverständniserklärungNull();
                else
                    DB_ROW.blob_Einverständniserklärung = value;
            }
        }
        public string EinverständniserklärungFileType
        {
            get
            {
                return DB_ROW.EinverständniserklärungFileType;
            }

            set
            {
                DB_ROW.EinverständniserklärungFileType = value;
            }
        }
        public byte[] jpg_Einverständniserklärung
        {
            get
            {
                if (DB_ROW.Isjpg_EinverständniserklärungNull())
                    return null;

                return DB_ROW.jpg_Einverständniserklärung;
            }

            set
            {
                if (value == null)
                    DB_ROW.Setjpg_EinverständniserklärungNull();
                else
                    DB_ROW.jpg_Einverständniserklärung = value;
            }
        }

        public bool Verstorben
        {
            get
            {
                return DB_ROW.Verstorben;
            }

            set
            {
                DB_ROW.Verstorben = value;
            }
        }
        public Nullable<DateTime> Todeszeitpunkt
        {
            get
            {
                if (DB_ROW.IsTodeszeitpunktNull())
                    return null;

                return DB_ROW.Todeszeitpunkt;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetTodeszeitpunktNull();
                else
                    DB_ROW.Todeszeitpunkt = (DateTime)value;
            }
        }
        public bool DNR
        {
            get
            {
                return DB_ROW.DNR;
            }

            set
            {
                DB_ROW.DNR = value;
            }
        }

        public bool Milieubetreuung
        {
            get
            {
                return DB_ROW.Milieubetreuung;
            }

            set
            {
                DB_ROW.Milieubetreuung = value;
            }
        }
        public bool KZUeberlebender
        {
            get
            {
                return DB_ROW.KZUeberlebender;
            }

            set
            {
                DB_ROW.KZUeberlebender = value;
            }
        }
        public bool Anatomie
        {
            get
            {
                return DB_ROW.Anatomie;
            }

            set
            {
                DB_ROW.Anatomie = value;
            }
        }
        public bool Einzelzimmer
        {
            get
            {
                return DB_ROW.Einzelzimmer;
            }

            set
            {
                DB_ROW.Einzelzimmer = value;
            }
        }
        public bool Selbstzahler
        {
            get
            {
                return DB_ROW.Selbstzahler;
            }

            set
            {
                DB_ROW.Selbstzahler = value;
            }
        }

        #endregion

        #region IBusinessBase Members

        DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		#region IZusatz Members
        
		// Zusatzwerte anhand der Abteilung 
		object IZusatz.ZusatzWertForAbteilung(Guid idAbteilung)
		{
			return new ZusatzWert("PAT", idAbteilung, ID);
		}

		#endregion


		public PatientenBemerkung NewBemerkung(Guid idUser)
		{
			PatientenBemerkung bem = new PatientenBemerkung();

			bem.IDPatient	= ID;
			bem.IDBenutzer	= idUser;
			return bem;
		}

		public PflegeEintrag NewVermerk(string DekursText, bool GegenzeichnenJN)
		{
            return PflegeEintrag.NewByAufenthalt(Aufenthalt.ID, "Dekurs", PflegeEintragTyp.DEKURS, DekursText, GegenzeichnenJN);
		}

		public PflegeEintrag NewMassnahme()
		{
			return PflegeEintrag.NewByMassnahme(Aufenthalt.ID, Guid.Empty);
		}

		public void NewAufenthalt(Guid idAbteilung, Guid idUser)
		{
			Aufenthalt auf = new Aufenthalt();

			auf.IDPatient					= ID;
			auf.IDAbteilung					= idAbteilung;
            auf.IDKlinik                    = ENV.IDKlinik;
            auf.IDBereich                   = ENV.IDBereich;
			auf.IDBenutzer_Aufnahme			= idUser;
			auf.Verlauf.IDBenutzer			= idUser;
			auf.Verlauf.IDAbteilung_Nach	= idAbteilung;

			_auf = auf;
		}

		public Aufenthalt Aufenthalt
		{
			get	
			{	
				if (_auf == null)
				{
					Guid id = Aufenthalt.LastByPatient(ID);
                    _auf = new Aufenthalt(id);
				}

				return _auf;	
			}
		}
        public System.Guid checkAufenthalt(System.Guid IDPat )
        {
            return Aufenthalt.LastByPatient(IDPat);
        }
		public string FullName
		{
			get	{	return Nachname+" "+Vorname;	}
		}

		// wichtige Informationen
		public string FullInfo
		{
            get { return FullInfoWithFormat(ENV.String("PATIENT_BASEINFO")); }         
        }

        public string FullInfoNoAge
        {
            get { return FullInfoWithFormat(ENV.String("PATIENT.INFO_NOAGE")); }         
        }

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
				int years = DateTime.Now.Year-birth.Year;
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

			return string.Format(sFormat, Titel, Nachname, Vorname, 
									Sexus, gebDatum, age);
		}
        public dsAerzte.AerzteDataTable GetAllAerzte(DateTime datum)
        {
            return _db.GetAllAerzte(datum);
        }

        // Liefert alle nicht gerade aufgenommenen Klienten
        public static dsPatientNichtAufgenommen.PatientDataTable GetAlleNichtAufgenommenen()
        {
            DBPatient dbpat = new DBPatient();
            return dbpat.GetAlleNichtAufgenommenen();
        }
        
        // Liefert zum Klienten die aktuelle Pflegegeldstufe oder -1 wenn noch keine Pflegestufe defineirt ist
        public static int AktuellePflegeStufe(Guid IDPatient)
        {
            return DBPatient.AktuellePflegeStufe(IDPatient);
        }

        public static string AktuellePflegeStufeText(Guid IDPatient)
        {
            int i = AktuellePflegeStufe(IDPatient);
            if( i == -1)
                return "keine PS";

            return string.Format("PS:{0}", i);
        }

        public static string SachwalterIconText(Guid IDPatient)
        {
            return DBPatient.SachwalterIconText(IDPatient);
        }

        public static PMDS.Global.retFkt   freiheitsbeschränkungJN(Guid IDAufenthalt)
        {
            return DBPatient.freiheitsbeschränkungJN(IDAufenthalt);
        }

        public bool updatePatient(Guid IDPatient, bool  abwesenheitenHändBerech)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = "UPDATE  Patient  SET  abwesenheitenHändBerech = ?  WHERE ID = ? ";
            cmd.Parameters.Add("abwesenheitenHändBerech", System.Data.OleDb.OleDbType.Boolean , 1, "abwesenheitenHändBerech").Value = abwesenheitenHändBerech;
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDPatient;
            cmd.ExecuteNonQuery();
            return true;
        }

        public DataTable abwHändBerech(System.Guid IDPatient)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = "Select   abwesenheitenHändBerech from   Patient  WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDPatient;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public bool  abwHändBerechJN(System.Guid IDPatient)
        {
            Patient pat = new Patient();
            DataTable dt = this.abwHändBerech(IDPatient);
            if (dt.Rows.Count > 0)
            {
                return (bool)dt.Rows[0]["abwesenheitenHändBerech"];
            }
            else
                return false;
        }


        public    dsPatientZusaätzlicheDatenByID.PatientRow getPatDatenZusätzlich(System.Guid IDPatient)
        {
            return _db.getPatDatenZusätzlich(IDPatient);
        }
        public bool updatePatient(Guid IDPatient, decimal Sollstand, decimal minSaldo)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = "UPDATE  Patient  SET  Sollstand = ?, minSaldo = ?  WHERE ID = ? ";
            cmd.Parameters.Add("Sollstand", System.Data.OleDb.OleDbType.Decimal, 21, "Sollstand").Value = Sollstand;
            cmd.Parameters.Add("minSaldo", System.Data.OleDb.OleDbType.Decimal, 21, "minSaldo").Value = minSaldo;
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDPatient;
            cmd.ExecuteNonQuery();
            return true;
        }

	}
}
