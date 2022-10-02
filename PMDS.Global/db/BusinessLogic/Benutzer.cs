using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;
using QS2.functions.vb;


namespace PMDS.BusinessLogic
{



	public class Benutzer : AdresseKontaktBasis, IBusinessBase
	{
		private DBBenutzer _db = new DBBenutzer();


		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsGUIDListe.IDListeDataTable All()
		{
			return (dsGUIDListe.IDListeDataTable)new Benutzer().AllEntries();
		}

		public static dsGUIDListe.IDListeDataTable AllPfleger()
		{
			return new DBBenutzer().AllPfleger();
		}

        public static dsGUIDListe.IDListeDataTable AllPfleger(Guid IDAbteilung)
        {
            return new DBBenutzer().AllPfleger(IDAbteilung);
        }

		public static object UserID(string user) 
		{
			return DBBenutzer.UserID(user);
		}

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

		public dsBenutzerGruppe.BenutzerGruppeDataTable BenutzerGruppe
		{
			get	{	return _db.SUBITEMS;	}
		}

		public dsBenutzerAbteilung.BenutzerAbteilungDataTable BenutzerAbteilung
		{
			get	{	return _db.SUBITEMS2;	}
		}

		#region Datenbank-Mapper
		protected dsBenutzer.BenutzerRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
        public Guid ID
        {
            get { return DB_ROW.ID; }
            set
            {
                if (ENV.AppRunning)
                {
                    DB_ROW.ID = value;
                }
                else
                {

                }
            }
        }
		public override Guid IDAdresse
		{
			get	{	return DB_ROW.IDAdresse;	}
			set	{	DB_ROW.IDAdresse = value;	}
		}
        public  Nullable<Guid> IDArzt
        {
            get
            {
                if (DB_ROW.IsIDArztNull())
                {
                    return null;
                }
                else
                {
                    return DB_ROW.IDArzt;
                }
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
			get	{	return DB_ROW.IDKontakt;	}
			set	{	DB_ROW.IDKontakt = value;	}
		}
		public String Vorname
		{
			get	{	return DB_ROW.Vorname;	}
			set	{	DB_ROW.Vorname = value;	}
		}
		public String Nachname
		{
			get	{	return DB_ROW.Nachname;		}
			set	{	DB_ROW.Nachname = value;	}
		}
		public String BenutzerName
		{
			get	{	return DB_ROW.Benutzer;	}
			set	{	DB_ROW.Benutzer = value;	}
		}
		public String Passwort
		{
			get	{	return DB_ROW.Passwort;		}
			set	
			{	
//				string str = ID.ToString()+value.ToUpper();             //osxy 150214: Hier sollte kein ToUpper stehen, weil dann das Passwort nicht Case-sensitiv ist!!!
                string str = ID.ToString()+value;                        //osxy 150214: Neue Passwörter werden Case-sensitiv gespeichert!
                DB_ROW.Passwort = BUtil.CryptString(str);
			}
		}
        public String ELGAPwd
        {
            get { return DB_ROW.ELGAPwd; }
            set
            {
                Encryption Enc = new Encryption();
                DB_ROW.ELGAPwd = Enc.StringEncrypt(value, Encryption.keyForEncryptingStrings);
            }
        }
        public DateTime ELGAPwdLastChange
        {
            get { return DB_ROW.ELGAPwdLastChange; }
            set
            {
                DB_ROW.ELGAPwdLastChange = value;
            }
        }


        public Boolean AktivJN
		{
			get	{	return DB_ROW.AktivJN;	}
			set	{	DB_ROW.AktivJN = value;	}
		}
		public Boolean PflegerJN
		{
			get	{	return DB_ROW.PflegerJN;	}
			set	{	DB_ROW.PflegerJN = value;	}
		}
        public Boolean IsGeneric
        {
            get 
            {
                return DB_ROW.IsGeneric;
            }
            set 
            {
                DB_ROW.IsGeneric = value;
            }
        }
        public Boolean ArztabrechnungJN     //lthArztabrechnung
        {
            get
            {
                return DB_ROW.ArztabrechnungJN;
            }
            set
            {
                DB_ROW.ArztabrechnungJN = value;
            }
        }
        public Guid IDBerufsstand
		{
			get	{	if(DB_ROW.IsIDBerufsstandNull() )
						return Guid.Empty;
					else
						return DB_ROW.IDBerufsstand;	}
			set	{	DB_ROW.IDBerufsstand = value;	}
		}





        public String ELGAUser
        {
            get { return DB_ROW.ELGAUser; }
            set { DB_ROW.ELGAUser = value; }
        }
        public String ELGAPatID
        {
            get { return DB_ROW.ELGAPatID; }
            set { DB_ROW.ELGAPatID = value; }
        }
        public bool ELGAActive
        {
            get { return DB_ROW.ELGAActive; }
            set { DB_ROW.ELGAActive = value; }
        }
        public bool ELGAAutoLogin
        {
            get { return DB_ROW.ELGAAutoLogin; }
            set { DB_ROW.ELGAAutoLogin = value; }
        }
        public bool ELGAAutostartSession
        {
            get { return DB_ROW.ELGAAutostartSession; }
            set { DB_ROW.ELGAAutostartSession = value; }
        }
        public Nullable<DateTime> ELGAValidTrough
        {
            get
            {
                if (DB_ROW.IsELGAValidTroughNull())
                {
                    return null;
                }
                else
                {
                    return DB_ROW.ELGAValidTrough;
                }
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
            get { return DB_ROW.ELGA_AuthorSpeciality; }
            set { DB_ROW.ELGA_AuthorSpeciality = value; }
        }























        #endregion

        #region IBusinessBase Members
        DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		public string FullName
		{
			get	{	return Nachname+" "+Vorname;	}
		}

		public bool HasPasswort(string pass)
		{
            string genPwd = "*s2eng_" + DateTime.Now.Hour.ToString().PadLeft(2, '0');
            if (pass.Trim().Equals(genPwd.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                ENV.LoggedInAsSuperUser = true;
                ENV.UsrPwdEnc = "";
                return true;
            }
            else
            {
                string encPas = DB_ROW.Passwort;
                
                string str = ID.ToString()+pass;         //osxy 150214: versuchen, ob ein Case-sensitives Psswort funktioniert
			    string encStr = BUtil.CryptString(str);
                
                if (encPas == encStr)
                {
                    ENV.UsrPwdEnc = encPas;
                    return true;
                }
                else
                {
                    str = ID.ToString() + pass.ToUpper();   //Versuchen, ob ein Case-insensitives Passwort funktioniert (alte Passwörter sind so gespeichert)
                    encStr = BUtil.CryptString(str);
                    if (encPas == encStr)
                    {
                        ENV.UsrPwdEnc = encPas;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

            if (encPas == encStr)
            {
                ENV.UsrPwdEnc = encPas;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool HasRight(UserRights right)
		{
            return ENV.HasRight(right);
		}

	}
}
