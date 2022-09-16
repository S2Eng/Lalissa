using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.BusinessLogic
{
	public class Aufenthalt : BusinessBase, IBusinessBase, IZusatz
	{
		private DBAufenthalt _db = new DBAufenthalt();
		private AufenthaltVerlauf _aufVerlauf;
		private AufenthaltVerlauf _curVerlauf;
		private UrlaubVerlauf	_urlaub;

		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsAufenthalt.AufenthaltDataTable ByPatient(Guid id)
		{
			using (DBAufenthalt db = new DBAufenthalt())
			{
				return db.ByPatient(id);
			}
		}

		public static dsAufenthalt.HistoryDataTable HistoryByPatient(Guid id)
		{
			using (DBAufenthalt db = new DBAufenthalt())
			{
				return db.HistoryByPatient(id);
			}
		}

        public bool updateAufnahmeEntlassung(Guid IDAufenthalt, DateTime Aufnahmezeitpunkt, DateTime Entlassungszeitpunkt)
        {
			using (DBAufenthalt db = new DBAufenthalt())
            {
				return db.updateAufnahmeEntlassung(IDAufenthalt, Aufnahmezeitpunkt, Entlassungszeitpunkt);
			}
        }

        public static Guid LastByPatient(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return Guid.Empty;

                PMDS.Global.historie hist = new PMDS.Global.historie();
                if (PMDS.Global.historie.HistorieOn && hist.IDAufenthalt != System.Guid.Empty)
                {
                    return hist.IDAufenthalt;
                }
                else
                {
                    return Aufenthalt.LastByAufenthaltByView(id);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("LastByPatient: " + ex.ToString());
            }
        }
        public static Guid LastByAufenthaltByView(Guid id)
        {
            try
            {
				Guid retValue = Guid.Empty;
				if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
					using (PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange())
					{
						sqlManange1.initControl();
						PMDS.Global.db.ERSystem.dsKlientenliste ds = new Global.db.ERSystem.dsKlientenliste();
						sqlManange1.getPatientActAufenthalt(id, 0, ref ds);
						if (ds.AktAufenthaltPatient.Rows.Count != 1)
						{
							return retValue;
						}
						PMDS.Global.db.ERSystem.dsKlientenliste.AktAufenthaltPatientRow rvKlientenliste = (PMDS.Global.db.ERSystem.dsKlientenliste.AktAufenthaltPatientRow)ds.AktAufenthaltPatient.Rows[0];
						retValue = rvKlientenliste.ID;
					}
				}
				return retValue;
            }
            catch (Exception ex)
            {
                throw new Exception("Aufenthalt.LastByAufenthaltByView: " + "\r\n" + ex.ToString());
            }
        }

		public Aufenthalt()
		{
			New();
		}

		public Aufenthalt(Guid id)
		{
			Read(id);
		}

		public override void New()
		{
			_urlaub = null;
			base.New();
			NewVerlauf();
		}

		public override void Read()
		{
			_urlaub = null;
            base.Read();

			using (DBAufenthaltVerlauf dbVerlauf = new DBAufenthaltVerlauf())
            {
				dsAufenthaltVerlauf.AufenthaltVerlaufDataTable dt = dbVerlauf.ByAufenthalt(this.ID);
				if (dt.Rows.Count > 0)
				{
					_curVerlauf = new AufenthaltVerlauf(IDAufenthaltVerlauf);

					Guid id = AufenthaltVerlauf.FirsByAufenthalt(ID);
					if (id == IDAufenthaltVerlauf)
						_aufVerlauf = _curVerlauf;
					else
						_aufVerlauf = new AufenthaltVerlauf(id);
				}
			}
		}

		public override void Write()
		{
			base.Write();
            if (_curVerlauf != null) 
            {
                _curVerlauf.Write();

                if (_urlaub != null)
                {
                    _urlaub.Write();
                    _urlaub = null;
                }
            }
		}
        public void WriteBewerberneuanlage()
        {
            base.Write();
        }
		#region Datenbank-Mapper
		protected dsAufenthalt.AufenthaltRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES

        public DateTime NaechsteEvaluierung
        {
            get
            {
                if (DB_ROW.IsNaechsteEvaluierungNull())
                    return new DateTime(1900, 1, 1);
                return DB_ROW.NaechsteEvaluierung;
            }
            set
            {
                DB_ROW.NaechsteEvaluierung = value;
            }
        }

        public string NaechsteEvaluierungBemerkung
        {
            get
            {
                return DB_ROW.NaechsteEvaluierungBemerkung;
            }
            set
            {
                DB_ROW.NaechsteEvaluierungBemerkung = value;
            }
        }

        public bool IsNaechsteEvaluierung
        {
            get
            {
                return !DB_ROW.IsNaechsteEvaluierungNull();
            }
        }

		public Guid ID
		{
			get	{	return DB_ROW.ID;	}
			set	{	DB_ROW.ID = value;	}
		}
		public Guid IDPatient
		{
			get	{	return DB_ROW.IDPatient;	}
			set	{	DB_ROW.IDPatient = value;	}
		}
		public Guid IDAbteilung
		{
			get	{	return DB_ROW.IDAbteilung;	}
			set	{	DB_ROW.IDAbteilung = value;	}
		}

        public Guid IDKlinik
        {
            get { return DB_ROW.IDKlinik; }
            set { DB_ROW.IDKlinik = value; }
        }
        public Guid IDBereich
        {
            get { return DB_ROW.IDBereich; }
            set { DB_ROW.IDBereich = value; }
        }

		public Guid IDAufenthaltVerlauf
		{
			get	{	return DB_ROW.IDAufenthaltVerlauf;	}
			set	{	DB_ROW.IDAufenthaltVerlauf = value;	}
		}
		public Guid IDBenutzer_Aufnahme
		{
			get	
			{
                if (DB_ROW.IDBenutzer_Aufnahme.Equals(System.Guid.Empty))
                {
                    throw new Exception("Aufenthalt: IDBenutzer_Aufnahme.get can not be Guid.Emtpy()");
                }
				return DB_ROW.IDBenutzer_Aufnahme;
			}

			set
			{
                if (value == Guid.Empty)
                {
                    throw new Exception("Aufenthalt: IDBenutzer_Aufnahme.set can not be Guid.Emtpy()");
                }
                else
                    DB_ROW.IDBenutzer_Aufnahme = value;
			}
		}
		public Guid IDBenutzer_Entlassung
		{
			get	
			{
				if (DB_ROW.IsIDBenutzer_EntlassungNull())
					return Guid.Empty;

				return DB_ROW.IDBenutzer_Entlassung;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDBenutzer_EntlassungNull();
				else
					DB_ROW.IDBenutzer_Entlassung = value;
			}
		}
		public Guid IDEinrichtung_Aufnahme
		{
			get	
			{
				if (DB_ROW.IsIDEinrichtung_AufnahmeNull())
					return Guid.Empty;

				return DB_ROW.IDEinrichtung_Aufnahme;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDEinrichtung_AufnahmeNull();
				else
					DB_ROW.IDEinrichtung_Aufnahme = value;
			}
		}
		public Guid IDEinrichtung_Entlassung
		{
			get	
			{
				if (DB_ROW.IsIDEinrichtung_EntlassungNull())
					return Guid.Empty;

				return DB_ROW.IDEinrichtung_Entlassung;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDEinrichtung_EntlassungNull();
				else
					DB_ROW.IDEinrichtung_Entlassung = value;
			}
		}
		public DateTime Aufnahmezeitpunkt
		{
			get	{	return DB_ROW.Aufnahmezeitpunkt;	}
			set	{	DB_ROW.Aufnahmezeitpunkt = value;	}
		}

		public object Entlassungszeitpunkt
		{
			get	
			{
				if (DB_ROW.IsEntlassungszeitpunktNull())
					return null;

				return DB_ROW.Entlassungszeitpunkt;
			}

			set
			{
				if (value == null)
					DB_ROW.SetEntlassungszeitpunktNull();
				else
					DB_ROW.Entlassungszeitpunkt = (DateTime)value;
			}
		}
		public int AufnahmeArt
		{
			get	{	return DB_ROW.AufnahmeArt;	}
			set	{	DB_ROW.AufnahmeArt = value;	}
		}
		public string BegleitungVon
		{
			get	{	return DB_ROW.BegleitungVon;	}
			set	{	DB_ROW.BegleitungVon = value;	}
		}
		public string Entlassungsbemerkung
		{
			get	{	return DB_ROW.Entlassungsbemerkung;	}
			set	{	DB_ROW.Entlassungsbemerkung = value;	}
		}
		public string SomatischeAuff
		{
			get	{	return DB_ROW.SomatischeAuff;	}
			set	{	DB_ROW.SomatischeAuff = value;	}
		}
		public string PsychischeAuff
		{
			get	{	return DB_ROW.PsychischeAuff;	}
			set	{	DB_ROW.PsychischeAuff = value;	}
		}
		public string VerhaltenAufnahme
		{
			get	{	return DB_ROW.VerhaltenAufnahme;	}
			set	{	DB_ROW.VerhaltenAufnahme = value;	}
		}
		public string SonstigeBesonderheiten
		{
			get	{	return DB_ROW.SonstigeBesonderheiten;	}
			set	{	DB_ROW.SonstigeBesonderheiten = value;	}
		}
		public string SofortMassnahmen
		{
			get	{	return DB_ROW.SofortMassnahmen;	}
			set	{	DB_ROW.SofortMassnahmen = value;	}
		}
		public Guid IDUrlaub
		{
			get	
			{
				if (DB_ROW.IsIDUrlaubNull())
					return Guid.Empty;

				return DB_ROW.IDUrlaub;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDUrlaubNull();
				else
					DB_ROW.IDUrlaub = value;
			}
		}

        public double Fallnummer
        {
            get { return DB_ROW.IsFallnummerNull() ? 0 : DB_ROW.Fallnummer; }
            set { DB_ROW.Fallnummer = value; }
        }

        public string Gruppenkennzahl
        {
            get { return DB_ROW.IsGruppenkennzahlNull() ? "" : DB_ROW.Gruppenkennzahl; }
            set { DB_ROW.Gruppenkennzahl = value; }
        }

       

        public object Verfuegungsdatum
        {
            get
            {
                if (DB_ROW.IsVerfuegungsdatumNull())
                    return null;

                return DB_ROW.Verfuegungsdatum;
            }

            set
            {
                if (value == null)
                    DB_ROW.SetVerfuegungsdatumNull();
                else
                    DB_ROW.Verfuegungsdatum = (DateTime)value;
            }
        }

        

        public string Bermerkung
        {
            get { return DB_ROW.IsBermerkungNull() ? "" : DB_ROW.Bermerkung; }
            set { DB_ROW.Bermerkung = value; }
        }

        public string Besuchsregelung
        {
            get { return DB_ROW.IsBesuchsregelungNull() ? "" : DB_ROW.Besuchsregelung; }
            set { DB_ROW.Besuchsregelung = value; }
        }

        public string Postregelung
        {
            get { return DB_ROW.IsPostregelungNull() ? "" : DB_ROW.Postregelung; }
            set { DB_ROW.Postregelung = value; }
        }

        public string SonstigeRegelung
        {
            get { return DB_ROW.IsSonstigeRegelungNull() ? "" : DB_ROW.SonstigeRegelung; }
            set { DB_ROW.SonstigeRegelung = value; }
        }

        public string Erwartungen
        {
            get { return DB_ROW.IsErwartungenNull() ? "" : DB_ROW.Erwartungen; }
            set { DB_ROW.Erwartungen = value; }
        }

        public Guid IDErstkontakt
        {
            get
            {
                if (DB_ROW.IsIDErstkontaktNull())
                    return Guid.Empty;

                return DB_ROW.IDErstkontakt;
            }

            set
            {
                if (value == Guid.Empty)
                    DB_ROW.SetIDErstkontaktNull();
                else
                    DB_ROW.IDErstkontakt = value;
            }
        }

        public double Gewicht
        {
            get { return DB_ROW.IsGewichtNull() ? 0 : DB_ROW.Gewicht; }
            set { DB_ROW.Gewicht = value; }
        }

        public double TaschengeldSollstand
        {
            get { return DB_ROW.IsTaschengeldSollstandNull() ? 0 : DB_ROW.TaschengeldSollstand; }
            set { DB_ROW.TaschengeldSollstand = value; }
        }

        public DateTime TaschegeldVortragDatum
        {
            get
            {
                if (DB_ROW.IsTaschegeldVortragDatumNull())
                    return new DateTime(1900, 1, 1);
                return DB_ROW.TaschegeldVortragDatum;
            }
            set
            {
                DB_ROW.TaschegeldVortragDatum = value;
            }
        }

        public double TaschengeldVortragBetrag
        {
            get { return DB_ROW.IsTaschengeldVortragBetragNull() ? 0 : DB_ROW.TaschengeldVortragBetrag; }
            set { DB_ROW.TaschengeldVortragBetrag = value; }
        }

        public double Ausgleichszahlung
        {
            get { return DB_ROW.Ausgleichszahlung; }
            set { DB_ROW.Ausgleichszahlung = value; }
        }

        #endregion

		#region IBusinessBase Members

		DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		#region IZusatz Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzwerte anhand der Abteilung 
		/// für den aktuellen Aufenthalt ermitteln 
		/// </summary>
		//----------------------------------------------------------------------------
		object IZusatz.ZusatzWertForAbteilung(Guid idAbteilung)
		{
			return new ZusatzWert("AUF", idAbteilung, ID);
		}

		#endregion

		public void NewVerlauf()
		{
			AufenthaltVerlauf auf = new AufenthaltVerlauf();

			auf.IDAufenthalt	= ID;
			_curVerlauf			= auf;
			_aufVerlauf			= auf;

			IDAufenthaltVerlauf = auf.ID;
		}

		public void Versetzung(Guid idUser)
		{
			AufenthaltVerlauf auf = new AufenthaltVerlauf();

			auf.IDAufenthalt		= ID;
			auf.IDAbteilung_Von		= Verlauf.IDAbteilung_Nach;
			auf.IDBenutzer			= idUser;

			_curVerlauf = auf;

			IDAufenthaltVerlauf = auf.ID;
		}

		public void Entlassung(Guid idUser)
		{
			AufenthaltVerlauf auf = new AufenthaltVerlauf();

			auf.IDAufenthalt			= ID;
			auf.IDAbteilung_Von			= Verlauf.IDAbteilung_Nach;
			auf.IDBenutzer				= idUser;
			this.IDBenutzer_Entlassung	= idUser;
			this.Entlassungszeitpunkt	= DateTime.Now;

			_curVerlauf = auf;

			IDAufenthaltVerlauf = auf.ID;
		}

		public AufenthaltVerlauf Verlauf
		{
			get	{	return _curVerlauf;	}
		}

		public AufenthaltVerlauf AufnahmeVerlauf
		{
			get	{	return _aufVerlauf;	}
		}

		public bool HasUrlaub
		{
            get 
            { 
                return UrlaubVerlauf.ByAufenthalt(ID).Select("EndeDatum IS NULL").Length == 0 ? false : true;
            }
		}

		public UrlaubVerlauf Urlaub
		{
			get	
			{	
				if ((_urlaub == null) && HasUrlaub)
                    _urlaub = new UrlaubVerlauf(IDUrlaub);
				return _urlaub;	
			}
		}


        public static PDxResource[] GetAllResourceEntries(Guid IDAufenthalt)
        {
            return DBAufenthaltPDx.GetAllResourceEntries(IDAufenthalt);
        }

	}
}
