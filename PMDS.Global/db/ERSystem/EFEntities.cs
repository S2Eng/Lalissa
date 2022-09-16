using PMDS.db.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using PMDS.db;
using System.Diagnostics;
using PMDS.DB;



namespace PMDS.Global.db.ERSystem
{



    public class EFEntities
    {

        public static System.Collections.Generic.Dictionary<string, efTable> lstEfTables = new System.Collections.Generic.Dictionary<string, efTable>();
        public static PMDS.db.Entities.ERModellPMDSEntities db = null;
        public class cCols
        {
            public string NameColOrig = "";
            public string NameColEF = "";
        }


            
        private static IEnumerable<PMDS.db.Entities.Abteilung> _Abteilung = null;
        public static IEnumerable<PMDS.db.Entities.Abteilung> Abteilung
        {
            get
            {
                return EFEntities._Abteilung;
            }
            set
            {
                EFEntities._Abteilung = value;
            }
        }
        public static Abteilung newAbteilung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAbteilung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Abteilung = from p in db.Abteilung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Abteilung newAbteilung = new PMDS.db.Entities.Abteilung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAbteilung, newAbteilung.GetType().Name.Trim(), EFEntities.Abteilung);
                return newAbteilung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Adresse> _Adresse = null;
        public static IEnumerable<PMDS.db.Entities.Adresse> Adresse
        {
            get
            {
                return EFEntities._Adresse;
            }
            set
            {
                EFEntities._Adresse = value;
            }
        }
        public static Adresse newAdresse(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAdresse";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Adresse = from p in db.Adresse.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Adresse newAdresse = new PMDS.db.Entities.Adresse();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAdresse, newAdresse.GetType().Name.Trim(), EFEntities.Adresse);
                return newAdresse;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Aerzte> _Aerzte = null;
        public static IEnumerable<PMDS.db.Entities.Aerzte> Aerzte
        {
            get
            {
                return EFEntities._Aerzte;
            }
            set
            {
                EFEntities._Aerzte = value;
            }
        }
        public static Aerzte newAerzte(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAerzte";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Aerzte = from p in db.Aerzte.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Aerzte newAerzte = new PMDS.db.Entities.Aerzte();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAerzte, newAerzte.GetType().Name.Trim(), EFEntities.Aerzte);
                return newAerzte;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Anamnese_Krohwinkel> _Anamnese_Krohwinkel = null;
        public static IEnumerable<PMDS.db.Entities.Anamnese_Krohwinkel> Anamnese_Krohwinkel
        {
            get
            {
                return EFEntities._Anamnese_Krohwinkel;
            }
            set
            {
                EFEntities._Anamnese_Krohwinkel = value;
            }
        }
        public static Anamnese_Krohwinkel newAnamnese_Krohwinkel(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAnamnese_Krohwinkel";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Anamnese_Krohwinkel = from p in db.Anamnese_Krohwinkel.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Anamnese_Krohwinkel newAnamnese_Krohwinkel = new PMDS.db.Entities.Anamnese_Krohwinkel();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_Krohwinkel, newAnamnese_Krohwinkel.GetType().Name.Trim(), EFEntities.Anamnese_Krohwinkel);
                return newAnamnese_Krohwinkel;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Anamnese_Orem> _Anamnese_Orem = null;
        public static IEnumerable<PMDS.db.Entities.Anamnese_Orem> Anamnese_Orem
        {
            get
            {
                return EFEntities._Anamnese_Orem;
            }
            set
            {
                EFEntities._Anamnese_Orem = value;
            }
        }
        public static Anamnese_Orem newAnamnese_Orem(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAnamnese_Orem";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Anamnese_Orem = from p in db.Anamnese_Orem.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Anamnese_Orem newAnamnese_Orem = new PMDS.db.Entities.Anamnese_Orem();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_Orem, newAnamnese_Orem.GetType().Name.Trim(), EFEntities.Anamnese_Orem);
                return newAnamnese_Orem;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Anamnese_POP> _Anamnese_POP = null;
        public static IEnumerable<PMDS.db.Entities.Anamnese_POP> Anamnese_POP
        {
            get
            {
                return EFEntities._Anamnese_POP;
            }
            set
            {
                EFEntities._Anamnese_POP = value;
            }
        }
        public static Anamnese_POP newAnamnese_POP(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAnamnese_POP";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Anamnese_POP = from p in db.Anamnese_POP.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Anamnese_POP newAnamnese_POP = new PMDS.db.Entities.Anamnese_POP();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_POP, newAnamnese_POP.GetType().Name.Trim(), EFEntities.Anamnese_POP);
                return newAnamnese_POP;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Anmeldungen> _Anmeldungen = null;
        public static IEnumerable<PMDS.db.Entities.Anmeldungen> Anmeldungen
        {
            get
            {
                return EFEntities._Anmeldungen;
            }
            set
            {
                EFEntities._Anmeldungen = value;
            }
        }
        public static Anmeldungen newAnmeldungen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAnmeldungen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Anmeldungen = from p in db.Anmeldungen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Anmeldungen newAnmeldungen = new PMDS.db.Entities.Anmeldungen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAnmeldungen, newAnmeldungen.GetType().Name.Trim(), EFEntities.Anmeldungen);
                return newAnmeldungen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Aufenthalt> _Aufenthalt = null;
        public static IEnumerable<PMDS.db.Entities.Aufenthalt> Aufenthalt
        {
            get
            {
                return EFEntities._Aufenthalt;
            }
            set
            {
                EFEntities._Aufenthalt = value;
            }
        }
        public static Aufenthalt newAufenthalt(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAufenthalt";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Aufenthalt = from p in db.Aufenthalt.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Aufenthalt newAufenthalt = new PMDS.db.Entities.Aufenthalt();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAufenthalt, newAufenthalt.GetType().Name.Trim(), EFEntities.Aufenthalt);
                return newAufenthalt;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.AufenthaltPDx> _AufenthaltPDx = null;
        public static IEnumerable<PMDS.db.Entities.AufenthaltPDx> AufenthaltPDx
        {
            get
            {
                return EFEntities._AufenthaltPDx;
            }
            set
            {
                EFEntities._AufenthaltPDx = value;
            }
        }
        public static AufenthaltPDx newAufenthaltPDx(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAufenthaltPDx";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.AufenthaltPDx = from p in db.AufenthaltPDx.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.AufenthaltPDx newAufenthaltPDx = new PMDS.db.Entities.AufenthaltPDx();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltPDx, newAufenthaltPDx.GetType().Name.Trim(), EFEntities.AufenthaltPDx);
                return newAufenthaltPDx;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.AufenthaltVerlauf> _AufenthaltVerlauf = null;
        public static IEnumerable<PMDS.db.Entities.AufenthaltVerlauf> AufenthaltVerlauf
        {
            get
            {
                return EFEntities._AufenthaltVerlauf;
            }
            set
            {
                EFEntities._AufenthaltVerlauf = value;
            }
        }
        public static AufenthaltVerlauf newAufenthaltVerlauf(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAufenthaltVerlauf";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.AufenthaltVerlauf = from p in db.AufenthaltVerlauf.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.AufenthaltVerlauf newAufenthaltVerlauf = new PMDS.db.Entities.AufenthaltVerlauf();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltVerlauf, newAufenthaltVerlauf.GetType().Name.Trim(), EFEntities.AufenthaltVerlauf);
                return newAufenthaltVerlauf;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.AufenthaltZusatz> _AufenthaltZusatz = null;
        public static IEnumerable<PMDS.db.Entities.AufenthaltZusatz> AufenthaltZusatz
        {
            get
            {
                return EFEntities._AufenthaltZusatz;
            }
            set
            {
                EFEntities._AufenthaltZusatz = value;
            }
        }
        public static AufenthaltZusatz newAufenthaltZusatz(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAufenthaltZusatz";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.AufenthaltZusatz = from p in db.AufenthaltZusatz.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.AufenthaltZusatz newAufenthaltZusatz = new PMDS.db.Entities.AufenthaltZusatz();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltZusatz, newAufenthaltZusatz.GetType().Name.Trim(), EFEntities.AufenthaltZusatz);
                return newAufenthaltZusatz;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.AuswahlListe> _AuswahlListe = null;
        public static IEnumerable<PMDS.db.Entities.AuswahlListe> AuswahlListe
        {
            get
            {
                return EFEntities._AuswahlListe;
            }
            set
            {
                EFEntities._AuswahlListe = value;
            }
        }
        public static AuswahlListe newAuswahlListe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAuswahlListe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.AuswahlListe = from p in db.AuswahlListe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.AuswahlListe newAuswahlListe = new PMDS.db.Entities.AuswahlListe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAuswahlListe, newAuswahlListe.GetType().Name.Trim(), EFEntities.AuswahlListe);
                return newAuswahlListe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.AuswahlListeGruppe> _AuswahlListeGruppe = null;
        public static IEnumerable<PMDS.db.Entities.AuswahlListeGruppe> AuswahlListeGruppe
        {
            get
            {
                return EFEntities._AuswahlListeGruppe;
            }
            set
            {
                EFEntities._AuswahlListeGruppe = value;
            }
        }
        public static AuswahlListeGruppe newAuswahlListeGruppe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newAuswahlListeGruppe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.AuswahlListeGruppe = from p in db.AuswahlListeGruppe.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.AuswahlListeGruppe newAuswahlListeGruppe = new PMDS.db.Entities.AuswahlListeGruppe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newAuswahlListeGruppe, newAuswahlListeGruppe.GetType().Name.Trim(), EFEntities.AuswahlListeGruppe);
                return newAuswahlListeGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Bank> _Bank = null;
        public static IEnumerable<PMDS.db.Entities.Bank> Bank
        {
            get
            {
                return EFEntities._Bank;
            }
            set
            {
                EFEntities._Bank = value;
            }
        }
        public static Bank newBank(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBank";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Bank = from p in db.Bank.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Bank newBank = new PMDS.db.Entities.Bank();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBank, newBank.GetType().Name.Trim(), EFEntities.Bank);
                return newBank;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BarcodeQ> _BarcodeQ = null;
        public static IEnumerable<PMDS.db.Entities.BarcodeQ> BarcodeQ
        {
            get
            {
                return EFEntities._BarcodeQ;
            }
            set
            {
                EFEntities._BarcodeQ = value;
            }
        }
        public static BarcodeQ newBarcodeQ(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBarcodeQ";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iInt = -999991;
                //EFEntities.BarcodeQ = from p in db.BarcodeQ.AsEnumerable() where p.ID == iInt select p;
                PMDS.db.Entities.BarcodeQ newBarcodeQ = new PMDS.db.Entities.BarcodeQ();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBarcodeQ, newBarcodeQ.GetType().Name.Trim(), EFEntities.BarcodeQ);
                return newBarcodeQ;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Belegung> _Belegung = null;
        public static IEnumerable<PMDS.db.Entities.Belegung> Belegung
        {
            get
            {
                return EFEntities._Belegung;
            }
            set
            {
                EFEntities._Belegung = value;
            }
        }
        public static Belegung newBelegung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBelegung";
            int FctNr = 250100;
            try
            {
                System.Collections.Generic.Dictionary<string, string> lstColsChange = new Dictionary<string, string>();
                lstColsChange = new Dictionary<string, string>();
                lstColsChange.Add("Belegung", "Belegung1");

                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Belegung = from p in db.Belegung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Belegung newBelegung = new PMDS.db.Entities.Belegung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBelegung, newBelegung.GetType().Name.Trim(), EFEntities.Belegung, lstColsChange);
                return newBelegung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Benutzer> _Benutzer = null;
        public static IEnumerable<PMDS.db.Entities.Benutzer> Benutzer
        {
            get
            {
                return EFEntities._Benutzer;
            }
            set
            {
                EFEntities._Benutzer = value;
            }
        }
        public static Benutzer newBenutzer(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBenutzer";
            int FctNr = 250100;
            try
            {
                System.Collections.Generic.Dictionary<string, string> lstColsChange = new Dictionary<string, string>();
                lstColsChange = new Dictionary<string, string>();
                lstColsChange.Add("Benutzer", "Benutzer1");

                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Benutzer = from p in db.Benutzer.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Benutzer newBenutzer = new PMDS.db.Entities.Benutzer();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBenutzer, newBenutzer.GetType().Name.Trim(), EFEntities.Benutzer, lstColsChange);
                return newBenutzer;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BenutzerAbteilung> _BenutzerAbteilung = null;
        public static IEnumerable<PMDS.db.Entities.BenutzerAbteilung> BenutzerAbteilung
        {
            get
            {
                return EFEntities._BenutzerAbteilung;
            }
            set
            {
                EFEntities._BenutzerAbteilung = value;
            }
        }
        public static BenutzerAbteilung newBenutzerAbteilung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBenutzerAbteilung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.BenutzerAbteilung = from p in db.BenutzerAbteilung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.BenutzerAbteilung newBenutzerAbteilung = new PMDS.db.Entities.BenutzerAbteilung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerAbteilung, newBenutzerAbteilung.GetType().Name.Trim(), EFEntities.BenutzerAbteilung);
                return newBenutzerAbteilung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BenutzerBezug> _BenutzerBezug = null;
        public static IEnumerable<PMDS.db.Entities.BenutzerBezug> BenutzerBezug
        {
            get
            {
                return EFEntities._BenutzerBezug;
            }
            set
            {
                EFEntities._BenutzerBezug = value;
            }
        }
        public static BenutzerBezug newBenutzerBezug(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBenutzerBezug";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.BenutzerBezug = from p in db.BenutzerBezug.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.BenutzerBezug newBenutzerBezug = new PMDS.db.Entities.BenutzerBezug();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerBezug, newBenutzerBezug.GetType().Name.Trim(), EFEntities.BenutzerBezug);
                return newBenutzerBezug;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BenutzerEinrichtung> _BenutzerEinrichtung = null;
        public static IEnumerable<PMDS.db.Entities.BenutzerEinrichtung> BenutzerEinrichtung
        {
            get
            {
                return EFEntities._BenutzerEinrichtung;
            }
            set
            {
                EFEntities._BenutzerEinrichtung = value;
            }
        }
        public static BenutzerEinrichtung newBenutzerEinrichtung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBenutzerEinrichtung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.BenutzerEinrichtung = from p in db.BenutzerEinrichtung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.BenutzerEinrichtung newBenutzerEinrichtung = new PMDS.db.Entities.BenutzerEinrichtung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerEinrichtung, newBenutzerEinrichtung.GetType().Name.Trim(), EFEntities.BenutzerEinrichtung);
                return newBenutzerEinrichtung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BenutzerGruppe> _BenutzerGruppe = null;
        public static IEnumerable<PMDS.db.Entities.BenutzerGruppe> BenutzerGruppe
        {
            get
            {
                return EFEntities._BenutzerGruppe;
            }
            set
            {
                EFEntities._BenutzerGruppe = value;
            }
        }
        public static BenutzerGruppe newBenutzerGruppe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBenutzerGruppe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.BenutzerGruppe = from p in db.BenutzerGruppe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.BenutzerGruppe newBenutzerGruppe = new PMDS.db.Entities.BenutzerGruppe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerGruppe, newBenutzerGruppe.GetType().Name.Trim(), EFEntities.BenutzerGruppe);
                return newBenutzerGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Bereich> _Bereich = null;
        public static IEnumerable<PMDS.db.Entities.Bereich> Bereich
        {
            get
            {
                return EFEntities._Bereich;
            }
            set
            {
                EFEntities._Bereich = value;
            }
        }
        public static Bereich newBereich(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBereich";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Bereich = from p in db.Bereich.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Bereich newBereich = new PMDS.db.Entities.Bereich();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBereich, newBereich.GetType().Name.Trim(), EFEntities.Bereich);
                return newBereich;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.BereichBenutzer> _BereichBenutzer = null;
        public static IEnumerable<PMDS.db.Entities.BereichBenutzer> BereichBenutzer
        {
            get
            {
                return EFEntities._BereichBenutzer;
            }
            set
            {
                EFEntities._BereichBenutzer = value;
            }
        }
        public static BereichBenutzer newBereichBenutzer(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newBereichBenutzer";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.BereichBenutzer = from p in db.BereichBenutzer.AsEnumerable() where p.IDBereich == gNewGuid select p;
                PMDS.db.Entities.BereichBenutzer newBereichBenutzer = new PMDS.db.Entities.BereichBenutzer();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newBereichBenutzer, newBereichBenutzer.GetType().Name.Trim(), EFEntities.BereichBenutzer);
                return newBereichBenutzer;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.billHeader> _billHeader = null;
        public static IEnumerable<PMDS.db.Entities.billHeader> billHeader
        {
            get
            {
                return EFEntities._billHeader;
            }
            set
            {
                EFEntities._billHeader = value;
            }
        }
        public static billHeader newbillHeader(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newbillHeader";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.billHeader = from p in db.billHeader.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.billHeader newbillHeader = new PMDS.db.Entities.billHeader();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newbillHeader, newbillHeader.GetType().Name.Trim(), EFEntities.billHeader);
                return newbillHeader;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.bills> _bills = null;
        public static IEnumerable<PMDS.db.Entities.bills> bills
        {
            get
            {
                return EFEntities._bills;
            }
            set
            {
                EFEntities._bills = value;
            }
        }
        public static bills newbills(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newbills";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.bills = from p in db.bills.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.bills newbills = new PMDS.db.Entities.bills();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newbills, newbills.GetType().Name.Trim(), EFEntities.bills);
                return newbills;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.bookings> _bookings = null;
        public static IEnumerable<PMDS.db.Entities.bookings> bookings
        {
            get
            {
                return EFEntities._bookings;
            }
            set
            {
                EFEntities._bookings = value;
            }
        }
        public static bookings newbookings(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newbookings";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.bookings = from p in db.bookings.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.bookings newbookings = new PMDS.db.Entities.bookings();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newbookings, newbookings.GetType().Name.Trim(), EFEntities.bookings);
                return newbookings;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.DBLizenz> _DBLizenz = null;
        public static IEnumerable<PMDS.db.Entities.DBLizenz> DBLizenz
        {
            get
            {
                return EFEntities._DBLizenz;
            }
            set
            {
                EFEntities._DBLizenz = value;
            }
        }
        public static DBLizenz newDBLizenz(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newDBLizenz";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iInt = -999992;
                //EFEntities.DBLizenz = from p in db.DBLizenz.AsEnumerable() where p.ID == iInt select p;
                PMDS.db.Entities.DBLizenz newDBLizenz = new PMDS.db.Entities.DBLizenz();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newDBLizenz, newDBLizenz.GetType().Name.Trim(), EFEntities.DBLizenz);
                return newDBLizenz;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.DBVersion> _DBVersion = null;
        public static IEnumerable<PMDS.db.Entities.DBVersion> DBVersion
        {
            get
            {
                return EFEntities._DBVersion;
            }
            set
            {
                EFEntities._DBVersion = value;
            }
        }
        public static DBVersion newDBVersion(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newDBVersion";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iInt = -999991;
                //EFEntities.DBVersion = from p in db.DBVersion.AsEnumerable() where p.ID == iInt select p;
                PMDS.db.Entities.DBVersion newDBVersion = new PMDS.db.Entities.DBVersion();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newDBVersion, newDBVersion.GetType().Name.Trim(), EFEntities.DBVersion);
                return newDBVersion;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Dienstzeiten> _Dienstzeiten = null;
        public static IEnumerable<PMDS.db.Entities.Dienstzeiten> Dienstzeiten
        {
            get
            {
                return EFEntities._Dienstzeiten;
            }
            set
            {
                EFEntities._Dienstzeiten = value;
            }
        }
        public static Dienstzeiten newDienstzeiten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newDienstzeiten";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Dienstzeiten = from p in db.Dienstzeiten.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Dienstzeiten newDienstzeiten = new PMDS.db.Entities.Dienstzeiten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newDienstzeiten, newDienstzeiten.GetType().Name.Trim(), EFEntities.Dienstzeiten);
                return newDienstzeiten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Dokumente> _Dokumente = null;
        public static IEnumerable<PMDS.db.Entities.Dokumente> Dokumente
        {
            get
            {
                return EFEntities._Dokumente;
            }
            set
            {
                EFEntities._Dokumente = value;
            }
        }
        public static Dokumente newDokumente(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newDokumente";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Dokumente = from p in db.Dokumente.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Dokumente newDokumente = new PMDS.db.Entities.Dokumente();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newDokumente, newDokumente.GetType().Name.Trim(), EFEntities.Dokumente);
                return newDokumente;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Dokumente2> _Dokumente2 = null;
        public static IEnumerable<PMDS.db.Entities.Dokumente2> Dokumente2
        {
            get
            {
                return EFEntities._Dokumente2;
            }
            set
            {
                EFEntities._Dokumente2 = value;
            }
        }
        public static Dokumente2 newDokumente2(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newDokumente2";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Dokumente2 = from p in db.Dokumente2.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Dokumente2 newDokumente2 = new PMDS.db.Entities.Dokumente2();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newDokumente2, newDokumente2.GetType().Name.Trim(), EFEntities.Dokumente2);
                return newDokumente2;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Einrichtung> _Einrichtung = null;
        public static IEnumerable<PMDS.db.Entities.Einrichtung> Einrichtung
        {
            get
            {
                return EFEntities._Einrichtung;
            }
            set
            {
                EFEntities._Einrichtung = value;
            }
        }
        public static Einrichtung newEinrichtung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newEinrichtung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Einrichtung = from p in db.Einrichtung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Einrichtung newEinrichtung = new PMDS.db.Entities.Einrichtung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newEinrichtung, newEinrichtung.GetType().Name.Trim(), EFEntities.Einrichtung);
                return newEinrichtung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Eintrag> _Eintrag = null;
        public static IEnumerable<PMDS.db.Entities.Eintrag> Eintrag
        {
            get
            {
                return EFEntities._Eintrag;
            }
            set
            {
                EFEntities._Eintrag = value;
            }
        }
        public static Eintrag newEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Eintrag = from p in db.Eintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Eintrag newEintrag = new PMDS.db.Entities.Eintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newEintrag, newEintrag.GetType().Name.Trim(), EFEntities.Eintrag);
                return newEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.EintragStandardprozeduren> _EintragStandardprozeduren = null;
        public static IEnumerable<PMDS.db.Entities.EintragStandardprozeduren> EintragStandardprozeduren
        {
            get
            {
                return EFEntities._EintragStandardprozeduren;
            }
            set
            {
                EFEntities._EintragStandardprozeduren = value;
            }
        }
        public static EintragStandardprozeduren newEintragStandardprozeduren(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newEintragStandardprozeduren";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.EintragStandardprozeduren = from p in db.EintragStandardprozeduren.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.EintragStandardprozeduren newEintragStandardprozeduren = new PMDS.db.Entities.EintragStandardprozeduren();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newEintragStandardprozeduren, newEintragStandardprozeduren.GetType().Name.Trim(), EFEntities.EintragStandardprozeduren);
                return newEintragStandardprozeduren;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.EintragZusatz> _EintragZusatz = null;
        public static IEnumerable<PMDS.db.Entities.EintragZusatz> EintragZusatz
        {
            get
            {
                return EFEntities._EintragZusatz;
            }
            set
            {
                EFEntities._EintragZusatz = value;
            }
        }
        public static EintragZusatz newEintragZusatz(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newEintragZusatz";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.EintragZusatz = from p in db.EintragZusatz.AsEnumerable() where p.IDEintrag == gNewGuid select p;
                PMDS.db.Entities.EintragZusatz newEintragZusatz = new PMDS.db.Entities.EintragZusatz();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newEintragZusatz, newEintragZusatz.GetType().Name.Trim(), EFEntities.EintragZusatz);
                return newEintragZusatz;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Essen> _Essen = null;
        public static IEnumerable<PMDS.db.Entities.Essen> Essen
        {
            get
            {
                return EFEntities._Essen;
            }
            set
            {
                EFEntities._Essen = value;
            }
        }
        public static Essen newEssen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newEssen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Essen = from p in db.Essen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Essen newEssen = new PMDS.db.Entities.Essen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newEssen, newEssen.GetType().Name.Trim(), EFEntities.Essen);
                return newEssen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Formular> _Formular = null;
        public static IEnumerable<PMDS.db.Entities.Formular> Formular
        {
            get
            {
                return EFEntities._Formular;
            }
            set
            {
                EFEntities._Formular = value;
            }
        }
        public static Formular newFormular(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newFormular";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Formular = from p in db.Formular.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Formular newFormular = new PMDS.db.Entities.Formular();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newFormular, newFormular.GetType().Name.Trim(), EFEntities.Formular);
                return newFormular;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.FormularDaten> _FormularDaten = null;
        public static IEnumerable<PMDS.db.Entities.FormularDaten> FormularDaten
        {
            get
            {
                return EFEntities._FormularDaten;
            }
            set
            {
                EFEntities._FormularDaten = value;
            }
        }
        public static FormularDaten newFormularDaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newFormularDaten";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.FormularDaten = from p in db.FormularDaten.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.FormularDaten newFormularDaten = new PMDS.db.Entities.FormularDaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newFormularDaten, newFormularDaten.GetType().Name.Trim(), EFEntities.FormularDaten);
                return newFormularDaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Gegenstaende> _Gegenstaende = null;
        public static IEnumerable<PMDS.db.Entities.Gegenstaende> Gegenstaende
        {
            get
            {
                return EFEntities._Gegenstaende;
            }
            set
            {
                EFEntities._Gegenstaende = value;
            }
        }
        public static Gegenstaende newGegenstaende(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newGegenstaende";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Gegenstaende = from p in db.Gegenstaende.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Gegenstaende newGegenstaende = new PMDS.db.Entities.Gegenstaende();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newGegenstaende, newGegenstaende.GetType().Name.Trim(), EFEntities.Gegenstaende);
                return newGegenstaende;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Gruppe> _Gruppe = null;
        public static IEnumerable<PMDS.db.Entities.Gruppe> Gruppe
        {
            get
            {
                return EFEntities._Gruppe;
            }
            set
            {
                EFEntities._Gruppe = value;
            }
        }
        public static Gruppe newGruppe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newGruppe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Gruppe = from p in db.Gruppe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Gruppe newGruppe = new PMDS.db.Entities.Gruppe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newGruppe, newGruppe.GetType().Name.Trim(), EFEntities.Gruppe);
                return newGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.GruppenRecht> _GruppenRecht = null;
        public static IEnumerable<PMDS.db.Entities.GruppenRecht> GruppenRecht
        {
            get
            {
                return EFEntities._GruppenRecht;
            }
            set
            {
                EFEntities._GruppenRecht = value;
            }
        }
        public static GruppenRecht newGruppenRecht(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newGruppenRecht";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.GruppenRecht = from p in db.GruppenRecht.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.GruppenRecht newGruppenRecht = new PMDS.db.Entities.GruppenRecht();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newGruppenRecht, newGruppenRecht.GetType().Name.Trim(), EFEntities.GruppenRecht);
                return newGruppenRecht;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Info> _Info = null;
        public static IEnumerable<PMDS.db.Entities.Info> Info
        {
            get
            {
                return EFEntities._Info;
            }
            set
            {
                EFEntities._Info = value;
            }
        }
        public static Info newInfo(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newInfo";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Info = from p in db.Info.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.Info newInfo = new PMDS.db.Entities.Info();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newInfo, newInfo.GetType().Name.Trim(), EFEntities.Info);
                return newInfo;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Klinik> _Klinik = null;
        public static IEnumerable<PMDS.db.Entities.Klinik> Klinik
        {
            get
            {
                return EFEntities._Klinik;
            }
            set
            {
                EFEntities._Klinik = value;
            }
        }
        public static Klinik newKlinik(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newKlinik";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Klinik = from p in db.Klinik.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Klinik newKlinik = new PMDS.db.Entities.Klinik();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newKlinik, newKlinik.GetType().Name.Trim(), EFEntities.Klinik);
                return newKlinik;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Kontakt> _Kontakt = null;
        public static IEnumerable<PMDS.db.Entities.Kontakt> Kontakt
        {
            get
            {
                return EFEntities._Kontakt;
            }
            set
            {
                EFEntities._Kontakt = value;
            }
        }
        public static Kontakt newKontakt(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newKontakt";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Kontakt = from p in db.Kontakt.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Kontakt newKontakt = new PMDS.db.Entities.Kontakt();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newKontakt, newKontakt.GetType().Name.Trim(), EFEntities.Kontakt);
                return newKontakt;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Kontaktperson> _Kontaktperson = null;
        public static IEnumerable<PMDS.db.Entities.Kontaktperson> Kontaktperson
        {
            get
            {
                return EFEntities._Kontaktperson;
            }
            set
            {
                EFEntities._Kontaktperson = value;
            }
        }
        public static Kontaktperson newKontaktperson(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newKontaktperson";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Kontaktperson = from p in db.Kontaktperson.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Kontaktperson newKontaktperson = new PMDS.db.Entities.Kontaktperson();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newKontaktperson, newKontaktperson.GetType().Name.Trim(), EFEntities.Kontaktperson);
                return newKontaktperson;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.KontaktpersonStammdaten> _KontaktpersonStammdaten = null;
        public static IEnumerable<PMDS.db.Entities.KontaktpersonStammdaten> KontaktpersonStammdaten
        {
            get
            {
                return EFEntities._KontaktpersonStammdaten;
            }
            set
            {
                EFEntities._KontaktpersonStammdaten = value;
            }
        }
        public static KontaktpersonStammdaten newKontaktpersonStammdaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newKontaktpersonStammdaten";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.KontaktpersonStammdaten = from p in db.KontaktpersonStammdaten.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.KontaktpersonStammdaten newKontaktpersonStammdaten = new PMDS.db.Entities.KontaktpersonStammdaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newKontaktpersonStammdaten, newKontaktpersonStammdaten.GetType().Name.Trim(), EFEntities.KontaktpersonStammdaten);
                return newKontaktpersonStammdaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Kostentraeger> _Kostentraeger = null;
        public static IEnumerable<PMDS.db.Entities.Kostentraeger> Kostentraeger
        {
            get
            {
                return EFEntities._Kostentraeger;
            }
            set
            {
                EFEntities._Kostentraeger = value;
            }
        }
        public static Kostentraeger newKostentraeger(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newKostentraeger";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Kostentraeger = from p in db.Kostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Kostentraeger newKostentraeger = new PMDS.db.Entities.Kostentraeger();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newKostentraeger, newKostentraeger.GetType().Name.Trim(), EFEntities.Kostentraeger);
                return newKostentraeger;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Leistungskatalog> _Leistungskatalog = null;
        public static IEnumerable<PMDS.db.Entities.Leistungskatalog> Leistungskatalog
        {
            get
            {
                return EFEntities._Leistungskatalog;
            }
            set
            {
                EFEntities._Leistungskatalog = value;
            }
        }
        public static Leistungskatalog newLeistungskatalog(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newLeistungskatalog";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Leistungskatalog = from p in db.Leistungskatalog.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Leistungskatalog newLeistungskatalog = new PMDS.db.Entities.Leistungskatalog();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newLeistungskatalog, newLeistungskatalog.GetType().Name.Trim(), EFEntities.Leistungskatalog);
                return newLeistungskatalog;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.LeistungskatalogGueltig> _LeistungskatalogGueltig = null;
        public static IEnumerable<PMDS.db.Entities.LeistungskatalogGueltig> LeistungskatalogGueltig
        {
            get
            {
                return EFEntities._LeistungskatalogGueltig;
            }
            set
            {
                EFEntities._LeistungskatalogGueltig = value;
            }
        }
        public static LeistungskatalogGueltig newLeistungskatalogGueltig(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newLeistungskatalogGueltig";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.LeistungskatalogGueltig = from p in db.LeistungskatalogGueltig.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.LeistungskatalogGueltig newLeistungskatalogGueltig = new PMDS.db.Entities.LeistungskatalogGueltig();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newLeistungskatalogGueltig, newLeistungskatalogGueltig.GetType().Name.Trim(), EFEntities.LeistungskatalogGueltig);
                return newLeistungskatalogGueltig;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.LinkDokumente> _LinkDokumente = null;
        public static IEnumerable<PMDS.db.Entities.LinkDokumente> LinkDokumente
        {
            get
            {
                return EFEntities._LinkDokumente;
            }
            set
            {
                EFEntities._LinkDokumente = value;
            }
        }
        public static LinkDokumente newLinkDokumente(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newLinkDokumente";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.LinkDokumente = from p in db.LinkDokumente.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.LinkDokumente newLinkDokumente = new PMDS.db.Entities.LinkDokumente();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newLinkDokumente, newLinkDokumente.GetType().Name.Trim(), EFEntities.LinkDokumente);
                return newLinkDokumente;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.manBuch> _manBuch = null;
        public static IEnumerable<PMDS.db.Entities.manBuch> manBuch
        {
            get
            {
                return EFEntities._manBuch;
            }
            set
            {
                EFEntities._manBuch = value;
            }
        }
        public static manBuch newmanBuch(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newmanBuch";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.manBuch = from p in db.manBuch.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.manBuch newmanBuch = new PMDS.db.Entities.manBuch();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newmanBuch, newmanBuch.GetType().Name.Trim(), EFEntities.manBuch);
                return newmanBuch;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Massnahmenserien> _Massnahmenserien = null;
        public static IEnumerable<PMDS.db.Entities.Massnahmenserien> Massnahmenserien
        {
            get
            {
                return EFEntities._Massnahmenserien;
            }
            set
            {
                EFEntities._Massnahmenserien = value;
            }
        }
        public static Massnahmenserien newMassnahmenserien(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMassnahmenserien";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Massnahmenserien = from p in db.Massnahmenserien.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Massnahmenserien newMassnahmenserien = new PMDS.db.Entities.Massnahmenserien();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMassnahmenserien, newMassnahmenserien.GetType().Name.Trim(), EFEntities.Massnahmenserien);
                return newMassnahmenserien;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Medikament> _Medikament = null;
        public static IEnumerable<PMDS.db.Entities.Medikament> Medikament
        {
            get
            {
                return EFEntities._Medikament;
            }
            set
            {
                EFEntities._Medikament = value;
            }
        }
        public static Medikament newMedikament(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMedikament";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Medikament = from p in db.Medikament.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Medikament newMedikament = new PMDS.db.Entities.Medikament();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMedikament, newMedikament.GetType().Name.Trim(), EFEntities.Medikament);
                return newMedikament;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.MedikationAbgabe> _MedikationAbgabe = null;
        public static IEnumerable<PMDS.db.Entities.MedikationAbgabe> MedikationAbgabe
        {
            get
            {
                return EFEntities._MedikationAbgabe;
            }
            set
            {
                EFEntities._MedikationAbgabe = value;
            }
        }
        public static MedikationAbgabe newMedikationAbgabe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMedikationAbgabe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.MedikationAbgabe = from p in db.MedikationAbgabe.AsEnumerable() where p.IDBenutzer == gNewGuid select p;
                PMDS.db.Entities.MedikationAbgabe newMedikationAbgabe = new PMDS.db.Entities.MedikationAbgabe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMedikationAbgabe, newMedikationAbgabe.GetType().Name.Trim(), EFEntities.MedikationAbgabe);
                return newMedikationAbgabe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.MedizinischeDaten> _MedizinischeDaten = null;
        public static IEnumerable<PMDS.db.Entities.MedizinischeDaten> MedizinischeDaten
        {
            get
            {
                return EFEntities._MedizinischeDaten;
            }
            set
            {
                EFEntities._MedizinischeDaten = value;
            }
        }
        public static MedizinischeDaten newMedizinischeDaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMedizinischeDaten";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.MedizinischeDaten = from p in db.MedizinischeDaten.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.MedizinischeDaten newMedizinischeDaten = new PMDS.db.Entities.MedizinischeDaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeDaten, newMedizinischeDaten.GetType().Name.Trim(), EFEntities.MedizinischeDaten);
                return newMedizinischeDaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.MedizinischeDatenLayout> _MedizinischeDatenLayout = null;
        public static IEnumerable<PMDS.db.Entities.MedizinischeDatenLayout> MedizinischeDatenLayout
        {
            get
            {
                return EFEntities._MedizinischeDatenLayout;
            }
            set
            {
                EFEntities._MedizinischeDatenLayout = value;
            }
        }
        public static MedizinischeDatenLayout newMedizinischeDatenLayout(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMedizinischeDatenLayout";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.MedizinischeDatenLayout = from p in db.MedizinischeDatenLayout.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.MedizinischeDatenLayout newMedizinischeDatenLayout = new PMDS.db.Entities.MedizinischeDatenLayout();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeDatenLayout, newMedizinischeDatenLayout.GetType().Name.Trim(), EFEntities.MedizinischeDatenLayout);
                return newMedizinischeDatenLayout;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.MedizinischeTypen> _MedizinischeTypen = null;
        public static IEnumerable<PMDS.db.Entities.MedizinischeTypen> MedizinischeTypen
        {
            get
            {
                return EFEntities._MedizinischeTypen;
            }
            set
            {
                EFEntities._MedizinischeTypen = value;
            }
        }
        public static MedizinischeTypen newMedizinischeTypen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newMedizinischeTypen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.MedizinischeTypen = from p in db.MedizinischeTypen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.MedizinischeTypen newMedizinischeTypen = new PMDS.db.Entities.MedizinischeTypen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeTypen, newMedizinischeTypen.GetType().Name.Trim(), EFEntities.MedizinischeTypen);
                return newMedizinischeTypen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Patient> _Patient = null;
        public static IEnumerable<PMDS.db.Entities.Patient> Patient
        {
            get
            {
                return EFEntities._Patient;
            }
            set
            {
                EFEntities._Patient = value;
            }
        }
        public static PMDS.db.Entities.Patient newPatient(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatient";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Patient = from p in db.Patient.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Patient newPatient = new PMDS.db.Entities.Patient();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatient, newPatient.GetType().Name.Trim(), EFEntities.Patient);
                return newPatient;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientAbwesenheit> _PatientAbwesenheit = null;
        public static IEnumerable<PMDS.db.Entities.PatientAbwesenheit> PatientAbwesenheit
        {
            get
            {
                return EFEntities._PatientAbwesenheit;
            }
            set
            {
                EFEntities._PatientAbwesenheit = value;
            }
        }
        public static PatientAbwesenheit newPatientAbwesenheit(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientAbwesenheit";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientAbwesenheit = from p in db.PatientAbwesenheit.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientAbwesenheit newPatientAbwesenheit = new PMDS.db.Entities.PatientAbwesenheit();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientAbwesenheit, newPatientAbwesenheit.GetType().Name.Trim(), EFEntities.PatientAbwesenheit);
                return newPatientAbwesenheit;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientAerzte> _PatientAerzte = null;
        public static IEnumerable<PMDS.db.Entities.PatientAerzte> PatientAerzte
        {
            get
            {
                return EFEntities._PatientAerzte;
            }
            set
            {
                EFEntities._PatientAerzte = value;
            }
        }
        public static PatientAerzte newPatientAerzte(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientAerzte";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientAerzte = from p in db.PatientAerzte.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientAerzte newPatientAerzte = new PMDS.db.Entities.PatientAerzte();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientAerzte, newPatientAerzte.GetType().Name.Trim(), EFEntities.PatientAerzte);
                return newPatientAerzte;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientEinkommen> _PatientEinkommen = null;
        public static IEnumerable<PMDS.db.Entities.PatientEinkommen> PatientEinkommen
        {
            get
            {
                return EFEntities._PatientEinkommen;
            }
            set
            {
                EFEntities._PatientEinkommen = value;
            }
        }
        public static PatientEinkommen newPatientEinkommen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientEinkommen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientEinkommen = from p in db.PatientEinkommen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientEinkommen newPatientEinkommen = new PMDS.db.Entities.PatientEinkommen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientEinkommen, newPatientEinkommen.GetType().Name.Trim(), EFEntities.PatientEinkommen);
                return newPatientEinkommen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientenBemerkung> _PatientenBemerkung = null;
        public static IEnumerable<PMDS.db.Entities.PatientenBemerkung> PatientenBemerkung
        {
            get
            {
                return EFEntities._PatientenBemerkung;
            }
            set
            {
                EFEntities._PatientenBemerkung = value;
            }
        }
        public static PatientenBemerkung newPatientenBemerkung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientenBemerkung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientenBemerkung = from p in db.PatientenBemerkung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientenBemerkung newPatientenBemerkung = new PMDS.db.Entities.PatientenBemerkung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientenBemerkung, newPatientenBemerkung.GetType().Name.Trim(), EFEntities.PatientenBemerkung);
                return newPatientenBemerkung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientKostentraeger> _PatientKostentraeger = null;
        public static IEnumerable<PMDS.db.Entities.PatientKostentraeger> PatientKostentraeger
        {
            get
            {
                return EFEntities._PatientKostentraeger;
            }
            set
            {
                EFEntities._PatientKostentraeger = value;
            }
        }
        public static PatientKostentraeger newPatientKostentraeger(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientKostentraeger";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientKostentraeger = from p in db.PatientKostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientKostentraeger newPatientKostentraeger = new PMDS.db.Entities.PatientKostentraeger();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientKostentraeger, newPatientKostentraeger.GetType().Name.Trim(), EFEntities.PatientKostentraeger);
                return newPatientKostentraeger;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientLeistungsplan> _PatientLeistungsplan = null;
        public static IEnumerable<PMDS.db.Entities.PatientLeistungsplan> PatientLeistungsplan
        {
            get
            {
                return EFEntities._PatientLeistungsplan;
            }
            set
            {
                EFEntities._PatientLeistungsplan = value;
            }
        }
        public static PatientLeistungsplan newPatientLeistungsplan(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientLeistungsplan";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientLeistungsplan = from p in db.PatientLeistungsplan.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientLeistungsplan newPatientLeistungsplan = new PMDS.db.Entities.PatientLeistungsplan();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientLeistungsplan, newPatientLeistungsplan.GetType().Name.Trim(), EFEntities.PatientLeistungsplan);
                return newPatientLeistungsplan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientPflegestufe> _PatientPflegestufe = null;
        public static IEnumerable<PMDS.db.Entities.PatientPflegestufe> PatientPflegestufe
        {
            get
            {
                return EFEntities._PatientPflegestufe;
            }
            set
            {
                EFEntities._PatientPflegestufe = value;
            }
        }
        public static PatientPflegestufe newPatientPflegestufe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientPflegestufe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientPflegestufe = from p in db.PatientPflegestufe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientPflegestufe newPatientPflegestufe = new PMDS.db.Entities.PatientPflegestufe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientPflegestufe, newPatientPflegestufe.GetType().Name.Trim(), EFEntities.PatientPflegestufe);
                return newPatientPflegestufe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientSonderleistung> _PatientSonderleistung = null;
        public static IEnumerable<PMDS.db.Entities.PatientSonderleistung> PatientSonderleistung
        {
            get
            {
                return EFEntities._PatientSonderleistung;
            }
            set
            {
                EFEntities._PatientSonderleistung = value;
            }
        }
        public static PatientSonderleistung newPatientSonderleistung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientSonderleistung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientSonderleistung = from p in db.PatientSonderleistung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientSonderleistung newPatientSonderleistung = new PMDS.db.Entities.PatientSonderleistung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientSonderleistung, newPatientSonderleistung.GetType().Name.Trim(), EFEntities.PatientSonderleistung);
                return newPatientSonderleistung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PatientTaschengeldKostentraeger> _PatientTaschengeldKostentraeger = null;
        public static IEnumerable<PMDS.db.Entities.PatientTaschengeldKostentraeger> PatientTaschengeldKostentraeger
        {
            get
            {
                return EFEntities._PatientTaschengeldKostentraeger;
            }
            set
            {
                EFEntities._PatientTaschengeldKostentraeger = value;
            }
        }
        public static PatientTaschengeldKostentraeger newPatientTaschengeldKostentraeger(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPatientTaschengeldKostentraeger";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PatientTaschengeldKostentraeger = from p in db.PatientTaschengeldKostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PatientTaschengeldKostentraeger newPatientTaschengeldKostentraeger = new PMDS.db.Entities.PatientTaschengeldKostentraeger();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPatientTaschengeldKostentraeger, newPatientTaschengeldKostentraeger.GetType().Name.Trim(), EFEntities.PatientTaschengeldKostentraeger);
                return newPatientTaschengeldKostentraeger;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDX> _PDX = null;
        public static IEnumerable<PMDS.db.Entities.PDX> PDX
        {
            get
            {
                return EFEntities._PDX;
            }
            set
            {
                EFEntities._PDX = value;
            }
        }
        public static PDX newPDX(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDX";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDX = from p in db.PDX.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDX newPDX = new PMDS.db.Entities.PDX();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDX, newPDX.GetType().Name.Trim(), EFEntities.PDX);
                return newPDX;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDXAnamnese> _PDXAnamnese = null;
        public static IEnumerable<PMDS.db.Entities.PDXAnamnese> PDXAnamnese
        {
            get
            {
                return EFEntities._PDXAnamnese;
            }
            set
            {
                EFEntities._PDXAnamnese = value;
            }
        }
        public static PDXAnamnese newPDXAnamnese(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDXAnamnese";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDXAnamnese = from p in db.PDXAnamnese.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDXAnamnese newPDXAnamnese = new PMDS.db.Entities.PDXAnamnese();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDXAnamnese, newPDXAnamnese.GetType().Name.Trim(), EFEntities.PDXAnamnese);
                return newPDXAnamnese;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDXEintrag> _PDXEintrag = null;
        public static IEnumerable<PMDS.db.Entities.PDXEintrag> PDXEintrag
        {
            get
            {
                return EFEntities._PDXEintrag;
            }
            set
            {
                EFEntities._PDXEintrag = value;
            }
        }
        public static PDXEintrag newPDXEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDXEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDXEintrag = from p in db.PDXEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDXEintrag newPDXEintrag = new PMDS.db.Entities.PDXEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDXEintrag, newPDXEintrag.GetType().Name.Trim(), EFEntities.PDXEintrag);
                return newPDXEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDXGruppe> _PDXGruppe = null;
        public static IEnumerable<PMDS.db.Entities.PDXGruppe> PDXGruppe
        {
            get
            {
                return EFEntities._PDXGruppe;
            }
            set
            {
                EFEntities._PDXGruppe = value;
            }
        }
        public static PMDS.db.Entities.PDXGruppe newPDXGruppe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDXGruppe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDXGruppe = from p in db.PDXGruppe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDXGruppe newPDXGruppe = new PMDS.db.Entities.PDXGruppe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDXGruppe, newPDXGruppe.GetType().Name.Trim(), EFEntities.PDXGruppe);
                return newPDXGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDXGruppeEintrag> _PDXGruppeEintrag = null;
        public static IEnumerable<PMDS.db.Entities.PDXGruppeEintrag> PDXGruppeEintrag
        {
            get
            {
                return EFEntities._PDXGruppeEintrag;
            }
            set
            {
                EFEntities._PDXGruppeEintrag = value;
            }
        }
        public static PDXGruppeEintrag newPDXGruppeEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDXGruppeEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDXGruppeEintrag = from p in db.PDXGruppeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDXGruppeEintrag newPDXGruppeEintrag = new PMDS.db.Entities.PDXGruppeEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDXGruppeEintrag, newPDXGruppeEintrag.GetType().Name.Trim(), EFEntities.PDXGruppeEintrag);
                return newPDXGruppeEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PDXPflegemodelle> _PDXPflegemodelle = null;
        public static IEnumerable<PMDS.db.Entities.PDXPflegemodelle> PDXPflegemodelle
        {
            get
            {
                return EFEntities._PDXPflegemodelle;
            }
            set
            {
                EFEntities._PDXPflegemodelle = value;
            }
        }
        public static PDXPflegemodelle newPDXPflegemodelle(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPDXPflegemodelle";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PDXPflegemodelle = from p in db.PDXPflegemodelle.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PDXPflegemodelle newPDXPflegemodelle = new PMDS.db.Entities.PDXPflegemodelle();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPDXPflegemodelle, newPDXPflegemodelle.GetType().Name.Trim(), EFEntities.PDXPflegemodelle);
                return newPDXPflegemodelle;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PflegeEintrag> _PflegeEintrag = null;
        public static IEnumerable<PMDS.db.Entities.PflegeEintrag> PflegeEintrag
        {
            get
            {
                return EFEntities._PflegeEintrag;
            }
            set
            {
                EFEntities._PflegeEintrag = value;
            }
        }
        private static IEnumerable<PMDS.db.Entities.PflegeEintragEntwurf> _PflegeEintragEntwurf = null;
        public static IEnumerable<PMDS.db.Entities.PflegeEintragEntwurf> PflegeEintragEntwurf
        {
            get
            {
                return EFEntities._PflegeEintragEntwurf;
            }
            set
            {
                EFEntities._PflegeEintragEntwurf = value;
            }
        }
        public static PflegeEintrag newPflegeEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegeEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegeEintrag newPflegeEintrag = new PMDS.db.Entities.PflegeEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegeEintrag, newPflegeEintrag.GetType().Name.Trim(), EFEntities.PflegeEintrag);
                return newPflegeEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        public static PflegeEintragEntwurf newPflegeEintragEntwurf(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegeEintragEntwurf";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegeEintragEntwurf newPflegeEintragEntwurf = new PMDS.db.Entities.PflegeEintragEntwurf();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegeEintragEntwurf, newPflegeEintragEntwurf.GetType().Name.Trim(), EFEntities.PflegeEintragEntwurf);
                return newPflegeEintragEntwurf;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.Pflegegeldstufe> _Pflegegeldstufe = null;
        public static IEnumerable<PMDS.db.Entities.Pflegegeldstufe> Pflegegeldstufe
        {
            get
            {
                return EFEntities._Pflegegeldstufe;
            }
            set
            {
                EFEntities._Pflegegeldstufe = value;
            }
        }
        public static Pflegegeldstufe newPflegegeldstufe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegegeldstufe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Pflegegeldstufe = from p in db.Pflegegeldstufe.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Pflegegeldstufe newPflegegeldstufe = new PMDS.db.Entities.Pflegegeldstufe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegegeldstufe, newPflegegeldstufe.GetType().Name.Trim(), EFEntities.Pflegegeldstufe);
                return newPflegegeldstufe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PflegegeldstufeGueltig> _PflegegeldstufeGueltig = null;
        public static IEnumerable<PMDS.db.Entities.PflegegeldstufeGueltig> PflegegeldstufeGueltig
        {
            get
            {
                return EFEntities._PflegegeldstufeGueltig;
            }
            set
            {
                EFEntities._PflegegeldstufeGueltig = value;
            }
        }
        public static PflegegeldstufeGueltig newPflegegeldstufeGueltig(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegegeldstufeGueltig";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegegeldstufeGueltig = from p in db.PflegegeldstufeGueltig.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegegeldstufeGueltig newPflegegeldstufeGueltig = new PMDS.db.Entities.PflegegeldstufeGueltig();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegegeldstufeGueltig, newPflegegeldstufeGueltig.GetType().Name.Trim(), EFEntities.PflegegeldstufeGueltig);
                return newPflegegeldstufeGueltig;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Pflegemodelle> _Pflegemodelle = null;
        public static IEnumerable<PMDS.db.Entities.Pflegemodelle> Pflegemodelle
        {
            get
            {
                return EFEntities._Pflegemodelle;
            }
            set
            {
                EFEntities._Pflegemodelle = value;
            }
        }
        public static Pflegemodelle newPflegemodelle(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegemodelle";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Pflegemodelle = from p in db.Pflegemodelle.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Pflegemodelle newPflegemodelle = new PMDS.db.Entities.Pflegemodelle();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegemodelle, newPflegemodelle.GetType().Name.Trim(), EFEntities.Pflegemodelle);
                return newPflegemodelle;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PflegePlan> _PflegePlan = null;
        public static IEnumerable<PMDS.db.Entities.PflegePlan> PflegePlan
        {
            get
            {
                return EFEntities._PflegePlan;
            }
            set
            {
                EFEntities._PflegePlan = value;
            }
        }
        public static PflegePlan newPflegePlan(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegePlan";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegePlan = from p in db.PflegePlan.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegePlan newPflegePlan = new PMDS.db.Entities.PflegePlan();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlan, newPflegePlan.GetType().Name.Trim(), EFEntities.PflegePlan);
                return newPflegePlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PflegePlanH> _PflegePlanH = null;
        public static IEnumerable<PMDS.db.Entities.PflegePlanH> PflegePlanH
        {
            get
            {
                return EFEntities._PflegePlanH;
            }
            set
            {
                EFEntities._PflegePlanH = value;
            }
        }
        public static PflegePlanH newPflegePlanH(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegePlanH";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegePlanH = from p in db.PflegePlanH.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegePlanH newPflegePlanH = new PMDS.db.Entities.PflegePlanH();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlanH, newPflegePlanH.GetType().Name.Trim(), EFEntities.PflegePlanH);
                return newPflegePlanH;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.PflegePlanPDx> _PflegePlanPDx = null;
        public static IEnumerable<PMDS.db.Entities.PflegePlanPDx> PflegePlanPDx
        {
            get
            {
                return EFEntities._PflegePlanPDx;
            }
            set
            {
                EFEntities._PflegePlanPDx = value;
            }
        }
        public static PflegePlanPDx newPflegePlanPDx(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPflegePlanPDx";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegePlanPDx = from p in db.PflegePlanPDx.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.PflegePlanPDx newPflegePlanPDx = new PMDS.db.Entities.PflegePlanPDx();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlanPDx, newPflegePlanPDx.GetType().Name.Trim(), EFEntities.PflegePlanPDx);
                return newPflegePlanPDx;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.QuickFilter> _QuickFilter = null;
        public static IEnumerable<PMDS.db.Entities.QuickFilter> QuickFilter
        {
            get
            {
                return EFEntities._QuickFilter;
            }
            set
            {
                EFEntities._QuickFilter = value;
            }
        }
        public static QuickFilter newQuickFilter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newQuickFilter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.QuickFilter = from p in db.QuickFilter.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.QuickFilter newQuickFilter = new PMDS.db.Entities.QuickFilter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newQuickFilter, newQuickFilter.GetType().Name.Trim(), EFEntities.QuickFilter);
                return newQuickFilter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.QuickMeldung> _QuickMeldung = null;
        public static IEnumerable<PMDS.db.Entities.QuickMeldung> QuickMeldung
        {
            get
            {
                return EFEntities._QuickMeldung;
            }
            set
            {
                EFEntities._QuickMeldung = value;
            }
        }
        public static QuickMeldung newQuickMeldung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newQuickMeldung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.QuickMeldung = from p in db.QuickMeldung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.QuickMeldung newQuickMeldung = new PMDS.db.Entities.QuickMeldung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newQuickMeldung, newQuickMeldung.GetType().Name.Trim(), EFEntities.QuickMeldung);
                return newQuickMeldung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.rechNr> _rechNr = null;
        public static IEnumerable<PMDS.db.Entities.rechNr> rechNr
        {
            get
            {
                return EFEntities._rechNr;
            }
            set
            {
                EFEntities._rechNr = value;
            }
        }
        public static rechNr newrechNr(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newrechNr";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iNr = -999991;
                //EFEntities.rechNr = from p in db.rechNr.AsEnumerable() where p.nr == iNr select p;
                PMDS.db.Entities.rechNr newrechNr = new PMDS.db.Entities.rechNr();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newrechNr, newrechNr.GetType().Name.Trim(), EFEntities.rechNr);
                return newrechNr;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Recht> _Recht = null;
        public static IEnumerable<PMDS.db.Entities.Recht> Recht
        {
            get
            {
                return EFEntities._Recht;
            }
            set
            {
                EFEntities._Recht = value;
            }
        }
        public static Recht newRecht(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newRecht";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iInt = -99999991;
                //EFEntities.Recht = from p in db.Recht.AsEnumerable() where p.ID == iInt select p;
                PMDS.db.Entities.Recht newRecht = new PMDS.db.Entities.Recht();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRecht, newRecht.GetType().Name.Trim(), EFEntities.Recht);
                return newRecht;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }


        private static IEnumerable<PMDS.db.Entities.Rehabilitation> _Rehabilitation = null;
        public static IEnumerable<PMDS.db.Entities.Rehabilitation> Rehabilitation
        {
            get
            {
                return EFEntities._Rehabilitation;
            }
            set
            {
                EFEntities._Rehabilitation = value;
            }
        }
        public static Rehabilitation newRehabilitation(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newRehabilitation";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Rehabilitation = from p in db.Rehabilitation.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Rehabilitation newRehabilitation = new PMDS.db.Entities.Rehabilitation();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRehabilitation, newRehabilitation.GetType().Name.Trim(), EFEntities.Rehabilitation);
                return newRehabilitation;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.RezeptBestellungPos> _RezeptBestellungPos = null;
        public static IEnumerable<PMDS.db.Entities.RezeptBestellungPos> RezeptBestellungPos
        {
            get
            {
                return EFEntities._RezeptBestellungPos;
            }
            set
            {
                EFEntities._RezeptBestellungPos = value;
            }
        }
        public static RezeptBestellungPos newRezeptBestellungPos(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newRezeptBestellungPos";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.RezeptBestellungPos = from p in db.RezeptBestellungPos.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.RezeptBestellungPos newRezeptBestellungPos = new PMDS.db.Entities.RezeptBestellungPos();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRezeptBestellungPos, newRezeptBestellungPos.GetType().Name.Trim(), EFEntities.RezeptBestellungPos);
                return newRezeptBestellungPos;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.RezeptEintrag> _RezeptEintrag = null;
        public static IEnumerable<PMDS.db.Entities.RezeptEintrag> RezeptEintrag
        {
            get
            {
                return EFEntities._RezeptEintrag;
            }
            set
            {
                EFEntities._RezeptEintrag = value;
            }
        }
        public static RezeptEintrag newRezeptEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newRezeptEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.RezeptEintrag = from p in db.RezeptEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.RezeptEintrag newRezeptEintrag = new PMDS.db.Entities.RezeptEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRezeptEintrag, newRezeptEintrag.GetType().Name.Trim(), EFEntities.RezeptEintrag);
                return newRezeptEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Sachwalter> _Sachwalter = null;
        public static IEnumerable<PMDS.db.Entities.Sachwalter> Sachwalter
        {
            get
            {
                return EFEntities._Sachwalter;
            }
            set
            {
                EFEntities._Sachwalter = value;
            }
        }
        public static Sachwalter newSachwalter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSachwalter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Sachwalter = from p in db.Sachwalter.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Sachwalter newSachwalter = new PMDS.db.Entities.Sachwalter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSachwalter, newSachwalter.GetType().Name.Trim(), EFEntities.Sachwalter);
                return newSachwalter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.SonderleistungsKatalog> _SonderleistungsKatalog = null;
        public static IEnumerable<PMDS.db.Entities.SonderleistungsKatalog> SonderleistungsKatalog
        {
            get
            {
                return EFEntities._SonderleistungsKatalog;
            }
            set
            {
                EFEntities._SonderleistungsKatalog = value;
            }
        }
        public static SonderleistungsKatalog newSonderleistungsKatalog(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSonderleistungsKatalog";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.SonderleistungsKatalog = from p in db.SonderleistungsKatalog.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.SonderleistungsKatalog newSonderleistungsKatalog = new PMDS.db.Entities.SonderleistungsKatalog();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSonderleistungsKatalog, newSonderleistungsKatalog.GetType().Name.Trim(), EFEntities.SonderleistungsKatalog);
                return newSonderleistungsKatalog;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.SP> _SP = null;
        public static IEnumerable<PMDS.db.Entities.SP> SP
        {
            get
            {
                return EFEntities._SP;
            }
            set
            {
                EFEntities._SP = value;
            }
        }
        public static SP newSP(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSP";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.SP = from p in db.SP.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.SP newSP = new PMDS.db.Entities.SP();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSP, newSP.GetType().Name.Trim(), EFEntities.SP);
                return newSP;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.SPDynRep> _SPDynRep = null;
        public static IEnumerable<PMDS.db.Entities.SPDynRep> SPDynRep
        {
            get
            {
                return EFEntities._SPDynRep;
            }
            set
            {
                EFEntities._SPDynRep = value;
            }
        }
        public static SPDynRep newSPDynRep(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSPDynRep";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.SPDynRep = from p in db.SPDynRep.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.SPDynRep newSPDynRep = new PMDS.db.Entities.SPDynRep();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSPDynRep, newSPDynRep.GetType().Name.Trim(), EFEntities.SPDynRep);
                return newSPDynRep;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.SPPE> _SPPE = null;
        public static IEnumerable<PMDS.db.Entities.SPPE> SPPE
        {
            get
            {
                return EFEntities._SPPE;
            }
            set
            {
                EFEntities._SPPE = value;
            }
        }
        public static SPPE newSPPE(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSPPE";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.SPPE = from p in db.SPPE.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.SPPE newSPPE = new PMDS.db.Entities.SPPE();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSPPE, newSPPE.GetType().Name.Trim(), EFEntities.SPPE);
                return newSPPE;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.SPPOS> _SPPOS = null;
        public static IEnumerable<PMDS.db.Entities.SPPOS> SPPOS
        {
            get
            {
                return EFEntities._SPPOS;
            }
            set
            {
                EFEntities._SPPOS = value;
            }
        }
        public static SPPOS newSPPOS(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newSPPOS";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.SPPOS = from p in db.SPPOS.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.SPPOS newSPPOS = new PMDS.db.Entities.SPPOS();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newSPPOS, newSPPOS.GetType().Name.Trim(), EFEntities.SPPOS);
                return newSPPOS;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.StandardProzeduren> _StandardProzeduren = null;
        public static IEnumerable<PMDS.db.Entities.StandardProzeduren> StandardProzeduren
        {
            get
            {
                return EFEntities._StandardProzeduren;
            }
            set
            {
                EFEntities._StandardProzeduren = value;
            }
        }
        public static StandardProzeduren newStandardProzeduren(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newStandardProzeduren";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.StandardProzeduren = from p in db.StandardProzeduren.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.StandardProzeduren newStandardProzeduren = new PMDS.db.Entities.StandardProzeduren();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newStandardProzeduren, newStandardProzeduren.GetType().Name.Trim(), EFEntities.StandardProzeduren);
                return newStandardProzeduren;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Standardzeiten> _Standardzeiten = null;
        public static IEnumerable<PMDS.db.Entities.Standardzeiten> Standardzeiten
        {
            get
            {
                return EFEntities._Standardzeiten;
            }
            set
            {
                EFEntities._Standardzeiten = value;
            }
        }
        public static Standardzeiten newStandardzeiten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newStandardzeiten";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //int iNewGuid = -999991;
                //EFEntities.Standardzeiten = from p in db.Standardzeiten.AsEnumerable() where p.ID == iNewGuid select p;
                PMDS.db.Entities.Standardzeiten newStandardzeiten = new PMDS.db.Entities.Standardzeiten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newStandardzeiten, newStandardzeiten.GetType().Name.Trim(), EFEntities.Standardzeiten);
                return newStandardzeiten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Taschengeld> _Taschengeld = null;
        public static IEnumerable<PMDS.db.Entities.Taschengeld> Taschengeld
        {
            get
            {
                return EFEntities._Taschengeld;
            }
            set
            {
                EFEntities._Taschengeld = value;
            }
        }
        public static Taschengeld newTaschengeld(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newTaschengeld";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Taschengeld = from p in db.Taschengeld.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Taschengeld newTaschengeld = new PMDS.db.Entities.Taschengeld();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newTaschengeld, newTaschengeld.GetType().Name.Trim(), EFEntities.Taschengeld);
                return newTaschengeld;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tbl_Nachricht> _tbl_Nachricht = null;
        public static IEnumerable<PMDS.db.Entities.tbl_Nachricht> tbl_Nachricht
        {
            get
            {
                return EFEntities._tbl_Nachricht;
            }
            set
            {
                EFEntities._tbl_Nachricht = value;
            }
        }
        public static tbl_Nachricht newtbl_Nachricht(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtbl_Nachricht";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tbl_Nachricht = from p in db.tbl_Nachricht.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tbl_Nachricht newtbl_Nachricht = new PMDS.db.Entities.tbl_Nachricht();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtbl_Nachricht, newtbl_Nachricht.GetType().Name.Trim(), EFEntities.tbl_Nachricht);
                return newtbl_Nachricht;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblDokumente> _tblDokumente = null;
        public static IEnumerable<PMDS.db.Entities.tblDokumente> tblDokumente
        {
            get
            {
                return EFEntities._tblDokumente;
            }
            set
            {
                EFEntities._tblDokumente = value;
            }
        }
        public static tblDokumente newtblDokumente(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblDokumente";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblDokumente = from p in db.tblDokumente.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblDokumente newtblDokumente = new PMDS.db.Entities.tblDokumente();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumente, newtblDokumente.GetType().Name.Trim(), EFEntities.tblDokumente);
                return newtblDokumente;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblDokumenteGelesen> _tblDokumenteGelesen = null;
        public static IEnumerable<PMDS.db.Entities.tblDokumenteGelesen> tblDokumenteGelesen
        {
            get
            {
                return EFEntities._tblDokumenteGelesen;
            }
            set
            {
                EFEntities._tblDokumenteGelesen = value;
            }
        }
        public static tblDokumenteGelesen newtblDokumenteGelesen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblDokumenteGelesen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblDokumenteGelesen = from p in db.tblDokumenteGelesen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblDokumenteGelesen newtblDokumenteGelesen = new PMDS.db.Entities.tblDokumenteGelesen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteGelesen, newtblDokumenteGelesen.GetType().Name.Trim(), EFEntities.tblDokumenteGelesen);
                return newtblDokumenteGelesen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblDokumenteintrag> _tblDokumenteintrag = null;
        public static IEnumerable<PMDS.db.Entities.tblDokumenteintrag> tblDokumenteintrag
        {
            get
            {
                return EFEntities._tblDokumenteintrag;
            }
            set
            {
                EFEntities._tblDokumenteintrag = value;
            }
        }
        public static tblDokumenteintrag newtblDokumenteintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblDokumenteintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblDokumenteintrag = from p in db.tblDokumenteintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblDokumenteintrag newtblDokumenteintrag = new PMDS.db.Entities.tblDokumenteintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteintrag, newtblDokumenteintrag.GetType().Name.Trim(), EFEntities.tblDokumenteintrag);
                return newtblDokumenteintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblDokumenteneintragSchlagwörter> _tblDokumenteneintragSchlagwörter = null;
        public static IEnumerable<PMDS.db.Entities.tblDokumenteneintragSchlagwörter> tblDokumenteneintragSchlagwörter
        {
            get
            {
                return EFEntities._tblDokumenteneintragSchlagwörter;
            }
            set
            {
                EFEntities._tblDokumenteneintragSchlagwörter = value;
            }
        }
        public static tblDokumenteneintragSchlagwörter newtblDokumenteneintragSchlagwörter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblDokumenteneintragSchlagwörter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblDokumenteneintragSchlagwörter = from p in db.tblDokumenteneintragSchlagwörter.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblDokumenteneintragSchlagwörter newtblDokumenteneintragSchlagwörter = new PMDS.db.Entities.tblDokumenteneintragSchlagwörter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteneintragSchlagwörter, newtblDokumenteneintragSchlagwörter.GetType().Name.Trim(), EFEntities.tblDokumenteneintragSchlagwörter);
                return newtblDokumenteneintragSchlagwörter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblFach> _tblFach = null;
        public static IEnumerable<PMDS.db.Entities.tblFach> tblFach
        {
            get
            {
                return EFEntities._tblFach;
            }
            set
            {
                EFEntities._tblFach = value;
            }
        }
        public static tblFach newtblFach(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblFach";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblFach = from p in db.tblFach.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblFach newtblFach = new PMDS.db.Entities.tblFach();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblFach, newtblFach.GetType().Name.Trim(), EFEntities.tblFach);
                return newtblFach;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblFortbildungBenutzer> _tblFortbildungBenutzer = null;
        public static IEnumerable<PMDS.db.Entities.tblFortbildungBenutzer> tblFortbildungBenutzer
        {
            get
            {
                return EFEntities._tblFortbildungBenutzer;
            }
            set
            {
                EFEntities._tblFortbildungBenutzer = value;
            }
        }
        public static tblFortbildungBenutzer newtblFortbildungBenutzer(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblFortbildungBenutzer";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblFortbildungBenutzer = from p in db.tblFortbildungBenutzer.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblFortbildungBenutzer newtblFortbildungBenutzer = new PMDS.db.Entities.tblFortbildungBenutzer();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblFortbildungBenutzer, newtblFortbildungBenutzer.GetType().Name.Trim(), EFEntities.tblFortbildungBenutzer);
                return newtblFortbildungBenutzer;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblFortbildungen> _tblFortbildungen = null;
        public static IEnumerable<PMDS.db.Entities.tblFortbildungen> tblFortbildungen
        {
            get
            {
                return EFEntities._tblFortbildungen;
            }
            set
            {
                EFEntities._tblFortbildungen = value;
            }
        }
        public static tblFortbildungen newtblFortbildungen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblFortbildungen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblFortbildungen = from p in db.tblFortbildungen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblFortbildungen newtblFortbildungen = new PMDS.db.Entities.tblFortbildungen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblFortbildungen, newtblFortbildungen.GetType().Name.Trim(), EFEntities.tblFortbildungen);
                return newtblFortbildungen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblObjekt> _tblObjekt = null;
        public static IEnumerable<PMDS.db.Entities.tblObjekt> tblObjekt
        {
            get
            {
                return EFEntities._tblObjekt;
            }
            set
            {
                EFEntities._tblObjekt = value;
            }
        }
        public static tblObjekt newtblObjekt(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblObjekt";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblObjekt = from p in db.tblObjekt.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblObjekt newtblObjekt = new PMDS.db.Entities.tblObjekt();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblObjekt, newtblObjekt.GetType().Name.Trim(), EFEntities.tblObjekt);
                return newtblObjekt;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblOrdner> _tblOrdner = null;
        public static IEnumerable<PMDS.db.Entities.tblOrdner> tblOrdner
        {
            get
            {
                return EFEntities._tblOrdner;
            }
            set
            {
                EFEntities._tblOrdner = value;
            }
        }
        public static tblOrdner newtblOrdner(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblOrdner";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblOrdner = from p in db.tblOrdner.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblOrdner newtblOrdner = new PMDS.db.Entities.tblOrdner();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblOrdner, newtblOrdner.GetType().Name.Trim(), EFEntities.tblOrdner);
                return newtblOrdner;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblParameter> _tblParameter = null;
        public static IEnumerable<PMDS.db.Entities.tblParameter> tblParameter
        {
            get
            {
                return EFEntities._tblParameter;
            }
            set
            {
                EFEntities._tblParameter = value;
            }
        }
        public static tblParameter newtblParameter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblParameter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblParameter = from p in db.tblParameter.AsEnumerable() where p.bezeichnung == gNewGuid.ToString() select p;
                PMDS.db.Entities.tblParameter newtblParameter = new PMDS.db.Entities.tblParameter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblParameter, newtblParameter.GetType().Name.Trim(), EFEntities.tblParameter);
                return newtblParameter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblPfad> _tblPfad = null;
        public static IEnumerable<PMDS.db.Entities.tblPfad> tblPfad
        {
            get
            {
                return EFEntities._tblPfad;
            }
            set
            {
                EFEntities._tblPfad = value;
            }
        }
        public static tblPfad newtblPfad(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblPfad";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblPfad = from p in db.tblPfad.AsEnumerable() where p.Archivpfad == gNewGuid.ToString() select p;
                PMDS.db.Entities.tblPfad newtblPfad = new PMDS.db.Entities.tblPfad();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblPfad, newtblPfad.GetType().Name.Trim(), EFEntities.tblPfad);
                return newtblPfad;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblProvKonfig> _tblProvKonfig = null;
        public static IEnumerable<PMDS.db.Entities.tblProvKonfig> tblProvKonfig
        {
            get
            {
                return EFEntities._tblProvKonfig;
            }
            set
            {
                EFEntities._tblProvKonfig = value;
            }
        }
        public static tblProvKonfig newtblProvKonfig(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblProvKonfig";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblProvKonfig = from p in db.tblProvKonfig.AsEnumerable() where p.key == gNewGuid.ToString() select p;
                PMDS.db.Entities.tblProvKonfig newtblProvKonfig = new PMDS.db.Entities.tblProvKonfig();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblProvKonfig, newtblProvKonfig.GetType().Name.Trim(), EFEntities.tblProvKonfig);
                return newtblProvKonfig;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblRechteOrdner> _tblRechteOrdner = null;
        public static IEnumerable<PMDS.db.Entities.tblRechteOrdner> tblRechteOrdner
        {
            get
            {
                return EFEntities._tblRechteOrdner;
            }
            set
            {
                EFEntities._tblRechteOrdner = value;
            }
        }
        public static tblRechteOrdner newtblRechteOrdner(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblRechteOrdner";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblRechteOrdner = from p in db.tblRechteOrdner.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblRechteOrdner newtblRechteOrdner = new PMDS.db.Entities.tblRechteOrdner();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblRechteOrdner, newtblRechteOrdner.GetType().Name.Trim(), EFEntities.tblRechteOrdner);
                return newtblRechteOrdner;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblSchlagwörter> _tblSchlagwörter = null;
        public static IEnumerable<PMDS.db.Entities.tblSchlagwörter> tblSchlagwörter
        {
            get
            {
                return EFEntities._tblSchlagwörter;
            }
            set
            {
                EFEntities._tblSchlagwörter = value;
            }
        }
        public static tblSchlagwörter newtblSchlagwörter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblSchlagwörter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblSchlagwörter = from p in db.tblSchlagwörter.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblSchlagwörter newtblSchlagwörter = new PMDS.db.Entities.tblSchlagwörter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblSchlagwörter, newtblSchlagwörter.GetType().Name.Trim(), EFEntities.tblSchlagwörter);
                return newtblSchlagwörter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblSchrank> _tblSchrank = null;
        public static IEnumerable<PMDS.db.Entities.tblSchrank> tblSchrank
        {
            get
            {
                return EFEntities._tblSchrank;
            }
            set
            {
                EFEntities._tblSchrank = value;
            }
        }
        public static tblSchrank newtblSchrank(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblSchrank";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblSchrank = from p in db.tblSchrank.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblSchrank newtblSchrank = new PMDS.db.Entities.tblSchrank();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblSchrank, newtblSchrank.GetType().Name.Trim(), EFEntities.tblSchrank);
                return newtblSchrank;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblSturzprotokoll> _tblSturzprotokoll = null;
        public static IEnumerable<PMDS.db.Entities.tblSturzprotokoll> tblSturzprotokoll
        {
            get
            {
                return EFEntities._tblSturzprotokoll;
            }
            set
            {
                EFEntities._tblSturzprotokoll = value;
            }
        }
        public static tblSturzprotokoll newtblSturzprotokoll(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblSturzprotokoll";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblSturzprotokoll = from p in db.tblSturzprotokoll.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblSturzprotokoll newtblSturzprotokoll = new PMDS.db.Entities.tblSturzprotokoll();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblSturzprotokoll, newtblSturzprotokoll.GetType().Name.Trim(), EFEntities.tblSturzprotokoll);
                return newtblSturzprotokoll;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblThemen> _tblThemen = null;
        public static IEnumerable<PMDS.db.Entities.tblThemen> tblThemen
        {
            get
            {
                return EFEntities._tblThemen;
            }
            set
            {
                EFEntities._tblThemen = value;
            }
        }
        public static tblThemen newtblThemen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblThemen";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblThemen = from p in db.tblThemen.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblThemen newtblThemen = new PMDS.db.Entities.tblThemen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblThemen, newtblThemen.GetType().Name.Trim(), EFEntities.tblThemen);
                return newtblThemen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblUIDefinitions> _tblUIDefinitions = null;
        public static IEnumerable<PMDS.db.Entities.tblUIDefinitions> tblUIDefinitions
        {
            get
            {
                return EFEntities._tblUIDefinitions;
            }
            set
            {
                EFEntities._tblUIDefinitions = value;
            }
        }
        public static tblUIDefinitions newtblUIDefinitions(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblUIDefinitions";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblUIDefinitions = from p in db.tblUIDefinitions.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblUIDefinitions newtblUIDefinitions = new PMDS.db.Entities.tblUIDefinitions();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblUIDefinitions, newtblUIDefinitions.GetType().Name.Trim(), EFEntities.tblUIDefinitions);
                return newtblUIDefinitions;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblVeranstalter> _tblVeranstalter = null;
        public static IEnumerable<PMDS.db.Entities.tblVeranstalter> tblVeranstalter
        {
            get
            {
                return EFEntities._tblVeranstalter;
            }
            set
            {
                EFEntities._tblVeranstalter = value;
            }
        }
        public static tblVeranstalter newtblVeranstalter(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblVeranstalter";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.tblVeranstalter = from p in db.tblVeranstalter.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblVeranstalter newtblVeranstalter = new PMDS.db.Entities.tblVeranstalter();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblVeranstalter, newtblVeranstalter.GetType().Name.Trim(), EFEntities.tblVeranstalter);
                return newtblVeranstalter;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Textbausteine> _Textbausteine = null;
        public static IEnumerable<PMDS.db.Entities.Textbausteine> Textbausteine
        {
            get
            {
                return EFEntities._Textbausteine;
            }
            set
            {
                EFEntities._Textbausteine = value;
            }
        }
        public static Textbausteine newTextbausteine(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newTextbausteine";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Textbausteine = from p in db.Textbausteine.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Textbausteine newTextbausteine = new PMDS.db.Entities.Textbausteine();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newTextbausteine, newTextbausteine.GetType().Name.Trim(), EFEntities.Textbausteine);
                return newTextbausteine;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Unterbringung> _Unterbringung = null;
        public static IEnumerable<PMDS.db.Entities.Unterbringung> Unterbringung
        {
            get
            {
                return EFEntities._Unterbringung;
            }
            set
            {
                EFEntities._Unterbringung = value;
            }
        }
        public static Unterbringung newUnterbringung(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newUnterbringung";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Unterbringung = from p in db.Unterbringung.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Unterbringung newUnterbringung = new PMDS.db.Entities.Unterbringung();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newUnterbringung, newUnterbringung.GetType().Name.Trim(), EFEntities.Unterbringung);
                return newUnterbringung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.UrlaubVerlauf> _UrlaubVerlauf = null;
        public static IEnumerable<PMDS.db.Entities.UrlaubVerlauf> UrlaubVerlauf
        {
            get
            {
                return EFEntities._UrlaubVerlauf;
            }
            set
            {
                EFEntities._UrlaubVerlauf = value;
            }
        }
        public static UrlaubVerlauf newUrlaubVerlauf(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newUrlaubVerlauf";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.UrlaubVerlauf = from p in db.UrlaubVerlauf.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.UrlaubVerlauf newUrlaubVerlauf = new PMDS.db.Entities.UrlaubVerlauf();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newUrlaubVerlauf, newUrlaubVerlauf.GetType().Name.Trim(), EFEntities.UrlaubVerlauf);
                return newUrlaubVerlauf;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.WundeKopf> _WundeKopf = null;
        public static IEnumerable<PMDS.db.Entities.WundeKopf> WundeKopf
        {
            get
            {
                return EFEntities._WundeKopf;
            }
            set
            {
                EFEntities._WundeKopf = value;
            }
        }
        public static WundeKopf newWundeKopf(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newWundeKopf";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.WundeKopf = from p in db.WundeKopf.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.WundeKopf newWundeKopf = new PMDS.db.Entities.WundeKopf();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newWundeKopf, newWundeKopf.GetType().Name.Trim(), EFEntities.WundeKopf);
                return newWundeKopf;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.WundePos> _WundePos = null;
        public static IEnumerable<PMDS.db.Entities.WundePos> WundePos
        {
            get
            {
                return EFEntities._WundePos;
            }
            set
            {
                EFEntities._WundePos = value;
            }
        }
        public static WundePos newWundePos(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newWundePos";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.WundePos = from p in db.WundePos.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.WundePos newWundePos = new PMDS.db.Entities.WundePos();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newWundePos, newWundePos.GetType().Name.Trim(), EFEntities.WundePos);
                return newWundePos;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.WundePosBilder> _WundePosBilder = null;
        public static IEnumerable<PMDS.db.Entities.WundePosBilder> WundePosBilder
        {
            get
            {
                return EFEntities._WundePosBilder;
            }
            set
            {
                EFEntities._WundePosBilder = value;
            }
        }
        public static WundePosBilder newWundePosBilder(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newWundePosBilder";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.WundePosBilder = from p in db.WundePosBilder.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.WundePosBilder newWundePosBilder = new PMDS.db.Entities.WundePosBilder();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newWundePosBilder, newWundePosBilder.GetType().Name.Trim(), EFEntities.WundePosBilder);
                return newWundePosBilder;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.WundeTherapie> _WundeTherapie = null;
        public static IEnumerable<PMDS.db.Entities.WundeTherapie> WundeTherapie
        {
            get
            {
                return EFEntities._WundeTherapie;
            }
            set
            {
                EFEntities._WundeTherapie = value;
            }
        }
        public static WundeTherapie newWundeTherapie(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newWundeTherapie";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.WundeTherapie = from p in db.WundeTherapie.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.WundeTherapie newWundeTherapie = new PMDS.db.Entities.WundeTherapie();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newWundeTherapie, newWundeTherapie.GetType().Name.Trim(), EFEntities.WundeTherapie);
                return newWundeTherapie;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Zeitbereich> _Zeitbereich = null;
        public static IEnumerable<PMDS.db.Entities.Zeitbereich> Zeitbereich
        {
            get
            {
                return EFEntities._Zeitbereich;
            }
            set
            {
                EFEntities._Zeitbereich = value;
            }
        }
        public static Zeitbereich newZeitbereich(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZeitbereich";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.Zeitbereich = from p in db.Zeitbereich.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Zeitbereich newZeitbereich = new PMDS.db.Entities.Zeitbereich();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZeitbereich, newZeitbereich.GetType().Name.Trim(), EFEntities.Zeitbereich);
                return newZeitbereich;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.ZeitbereichSerien> _ZeitbereichSerien = null;
        public static IEnumerable<PMDS.db.Entities.ZeitbereichSerien> ZeitbereichSerien
        {
            get
            {
                return EFEntities._ZeitbereichSerien;
            }
            set
            {
                EFEntities._ZeitbereichSerien = value;
            }
        }
        public static ZeitbereichSerien newZeitbereichSerien(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZeitbereichSerien";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZeitbereichSerien = from p in db.ZeitbereichSerien.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.ZeitbereichSerien newZeitbereichSerien = new PMDS.db.Entities.ZeitbereichSerien();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZeitbereichSerien, newZeitbereichSerien.GetType().Name.Trim(), EFEntities.ZeitbereichSerien);
                return newZeitbereichSerien;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.ZusatzEintrag> _ZusatzEintrag = null;
        public static IEnumerable<PMDS.db.Entities.ZusatzEintrag> ZusatzEintrag
        {
            get
            {
                return EFEntities._ZusatzEintrag;
            }
            set
            {
                EFEntities._ZusatzEintrag = value;
            }
        }
        public static ZusatzEintrag newZusatzEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZusatzEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzEintrag = from p in db.ZusatzEintrag.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.ZusatzEintrag newZusatzEintrag = new PMDS.db.Entities.ZusatzEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZusatzEintrag, newZusatzEintrag.GetType().Name.Trim(), EFEntities.ZusatzEintrag);
                return newZusatzEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.ZusatzGruppe> _ZusatzGruppe = null;
        public static IEnumerable<PMDS.db.Entities.ZusatzGruppe> ZusatzGruppe
        {
            get
            {
                return EFEntities._ZusatzGruppe;
            }
            set
            {
                EFEntities._ZusatzGruppe = value;
            }
        }
        public static ZusatzGruppe newZusatzGruppe(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZusatzGruppe";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzGruppe = from p in db.ZusatzGruppe.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                PMDS.db.Entities.ZusatzGruppe newZusatzGruppe = new PMDS.db.Entities.ZusatzGruppe();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZusatzGruppe, newZusatzGruppe.GetType().Name.Trim(), EFEntities.ZusatzGruppe);
                return newZusatzGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.ZusatzGruppeEintrag> _ZusatzGruppeEintrag = null;
        public static IEnumerable<PMDS.db.Entities.ZusatzGruppeEintrag> ZusatzGruppeEintrag
        {
            get
            {
                return EFEntities._ZusatzGruppeEintrag;
            }
            set
            {
                EFEntities._ZusatzGruppeEintrag = value;
            }
        }
        public static ZusatzGruppeEintrag newZusatzGruppeEintrag(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZusatzGruppeEintrag";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzGruppeEintrag = from p in db.ZusatzGruppeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.ZusatzGruppeEintrag newZusatzGruppeEintrag = new PMDS.db.Entities.ZusatzGruppeEintrag();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZusatzGruppeEintrag, newZusatzGruppeEintrag.GetType().Name.Trim(), EFEntities.ZusatzGruppeEintrag);
                return newZusatzGruppeEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.ZusatzWert> _ZusatzWert = null;
        public static IEnumerable<PMDS.db.Entities.ZusatzWert> ZusatzWert
        {
            get
            {
                return EFEntities._ZusatzWert;
            }
            set
            {
                EFEntities._ZusatzWert = value;
            }
        }
        public static ZusatzWert newZusatzWert(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newZusatzWert";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.ZusatzWert newZusatzWert = new PMDS.db.Entities.ZusatzWert();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newZusatzWert, newZusatzWert.GetType().Name.Trim(), EFEntities.ZusatzWert);
                return newZusatzWert;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.RezeptEintragMedDaten> _RezeptEintragMedDaten = null;
        public static IEnumerable<PMDS.db.Entities.RezeptEintragMedDaten> RezeptEintragMedDaten
        {
            get
            {
                return EFEntities._RezeptEintragMedDaten;
            }
            set
            {
                EFEntities._RezeptEintragMedDaten = value;
            }
        }
        public static RezeptEintragMedDaten newRezeptEintragMedDaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newRezeptEintragMedDaten";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.RezeptEintragMedDaten newRezeptEintragMedDaten = new PMDS.db.Entities.RezeptEintragMedDaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRezeptEintragMedDaten, newRezeptEintragMedDaten.GetType().Name.Trim(), EFEntities.RezeptEintragMedDaten);
                return newRezeptEintragMedDaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.VO> _VO = null;
        public static IEnumerable<PMDS.db.Entities.VO> VO
        {
            get
            {
                return EFEntities._VO;
            }
            set
            {
                EFEntities._VO = value;
            }
        }
        public static VO newVO(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.VO newVO = new PMDS.db.Entities.VO();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO, newVO.GetType().Name.Trim(), EFEntities.VO);
                return newVO;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.VO_MedizinischeDaten> _VO_MedizinischeDaten = null;
        public static IEnumerable<PMDS.db.Entities.VO_MedizinischeDaten> VO_MedizinischeDaten
        {
            get
            {
                return EFEntities._VO_MedizinischeDaten;
            }
            set
            {
                EFEntities._VO_MedizinischeDaten = value;
            }
        }
        public static VO_MedizinischeDaten newVO_MedizinischeDaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO_MedizinischeDaten";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.VO_MedizinischeDaten newVO_MedizinischeDaten = new PMDS.db.Entities.VO_MedizinischeDaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO_MedizinischeDaten, newVO_MedizinischeDaten.GetType().Name.Trim(), EFEntities.VO_MedizinischeDaten);
                return newVO_MedizinischeDaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.VO_PflegeplanPDX> _VO_PflegeplanPDX = null;
        public static IEnumerable<PMDS.db.Entities.VO_PflegeplanPDX> VO_PflegeplanPDX
        {
            get
            {
                return EFEntities._VO_PflegeplanPDX;
            }
            set
            {
                EFEntities._VO_PflegeplanPDX = value;
            }
        }
        public static VO_PflegeplanPDX newVO_PflegeplanPDX(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO_PflegeplanPDX";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.VO_PflegeplanPDX newVO_PflegeplanPDX = new PMDS.db.Entities.VO_PflegeplanPDX();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO_PflegeplanPDX, newVO_PflegeplanPDX.GetType().Name.Trim(), EFEntities.VO_PflegeplanPDX);
                return newVO_PflegeplanPDX;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.VO_Wunde> _VO_Wunde = null;
        public static IEnumerable<PMDS.db.Entities.VO_Wunde> VO_Wunde
        {
            get
            {
                return EFEntities._VO_Wunde;
            }
            set
            {
                EFEntities._VO_Wunde = value;
            }
        }
        public static VO_Wunde newVO_Wunde(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO_Wunde";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.VO_Wunde newVO_Wunde = new PMDS.db.Entities.VO_Wunde();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO_Wunde, newVO_Wunde.GetType().Name.Trim(), EFEntities.VO_Wunde);
                return newVO_Wunde;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.VO_Bestelldaten> _VO_Bestelldaten = null;
        public static IEnumerable<PMDS.db.Entities.VO_Bestelldaten> VO_Bestelldaten
        {
            get
            {
                return EFEntities._VO_Bestelldaten;
            }
            set
            {
                EFEntities._VO_Bestelldaten = value;
            }
        }
        public static VO_Bestelldaten newVO_Bestelldaten(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO_Bestelldaten";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.VO_Bestelldaten newVO_Bestelldaten = new PMDS.db.Entities.VO_Bestelldaten();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO_Bestelldaten, newVO_Bestelldaten.GetType().Name.Trim(), EFEntities.VO_Bestelldaten);
                return newVO_Bestelldaten;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.VO_Bestellpostitionen> _VO_Bestellpostitionen = null;
        public static IEnumerable<PMDS.db.Entities.VO_Bestellpostitionen> VO_Bestellpostitionen
        {
            get
            {
                return EFEntities._VO_Bestellpostitionen;
            }
            set
            {
                EFEntities._VO_Bestellpostitionen = value;
            }
        }
        public static VO_Bestellpostitionen newVO_Bestellpostitionen(ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newVO_Bestellpostitionen";
            int FctNr = 250101;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.VO_Bestellpostitionen newVO_Bestellpostitionen = new PMDS.db.Entities.VO_Bestellpostitionen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newVO_Bestellpostitionen, newVO_Bestellpostitionen.GetType().Name.Trim(), EFEntities.VO_Bestellpostitionen);
                return newVO_Bestellpostitionen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }


        private static IEnumerable<PMDS.db.Entities.plan> _plan = null;
        public static IEnumerable<PMDS.db.Entities.plan> plan
        {
            get
            {
                return EFEntities._plan;
            }
            set
            {
                EFEntities._plan = value;
            }
        }
        public static PMDS.db.Entities.plan newPlan(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPlan";
            int FctNr = 2501120;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.plan newPlan = new PMDS.db.Entities.plan();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPlan, newPlan.GetType().Name.Trim(), EFEntities.plan);
                return newPlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.planObject> _planObject = null;
        public static IEnumerable<PMDS.db.Entities.planObject> planObject
        {
            get
            {
                return EFEntities._planObject;
            }
            set
            {
                EFEntities._planObject = value;
            }
        }
        public static PMDS.db.Entities.planObject newPlanObject(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newplanObject";
            int FctNr = 2501112;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.planObject newPlanObject = new PMDS.db.Entities.planObject();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPlanObject, newPlanObject.GetType().Name.Trim(), EFEntities.planObject);
                return newPlanObject;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.planAnhang> _planAnhang = null;
        public static IEnumerable<PMDS.db.Entities.planAnhang> planAnhang
        {
            get
            {
                return EFEntities._planAnhang;
            }
            set
            {
                EFEntities._planAnhang = value;
            }
        }
        public static PMDS.db.Entities.planAnhang newPlanAnhang(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newPlanAnhang";
            int FctNr = 2501113;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.planAnhang newPlanAnhang = new PMDS.db.Entities.planAnhang();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newPlanAnhang, newPlanAnhang.GetType().Name.Trim(), EFEntities.planAnhang);
                return newPlanAnhang;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }


        private static IEnumerable<PMDS.db.Entities.tblSelListEntries> _tblSelListEntries = null;
        public static IEnumerable<PMDS.db.Entities.tblSelListEntries> tblSelListEntries
        {
            get
            {
                return EFEntities._tblSelListEntries;
            }
            set
            {
                EFEntities._tblSelListEntries = value;
            }
        }
        public static PMDS.db.Entities.tblSelListEntries newtblSelListEntries(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblSelListEntries";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.tblSelListEntries newtblSelListEntries = new PMDS.db.Entities.tblSelListEntries();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newtblSelListEntries, newtblSelListEntries.GetType().Name.Trim(), EFEntities.tblSelListEntries );
                return newtblSelListEntries;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }

        private static IEnumerable<PMDS.db.Entities.Ressourcen> _Ressourcen = null;
        public static IEnumerable<PMDS.db.Entities.Ressourcen> Ressourcen
        {
            get
            {
                return EFEntities._Ressourcen;
            }
            set
            {
                EFEntities._Ressourcen = value;
            }
        }
        public static PMDS.db.Entities.Ressourcen newRessourcen(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newtblSelListEntries";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Ressourcen newRessourcen = new PMDS.db.Entities.Ressourcen();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newRessourcen, newRessourcen.GetType().Name.Trim(), EFEntities.Ressourcen);
                return newRessourcen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.ELGAProtocoll> _ELGAProtocoll = null;
        public static IEnumerable<PMDS.db.Entities.ELGAProtocoll> ELGAProtocoll
        {
            get
            {
                return EFEntities._ELGAProtocoll;
            }
            set
            {
                EFEntities._ELGAProtocoll = value;
            }
        }
        public static PMDS.db.Entities.ELGAProtocoll newELGAProtocoll(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.ELGAProtocoll";
            int FctNr = 250106;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.ELGAProtocoll newELGAProtocoll = new PMDS.db.Entities.ELGAProtocoll();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newELGAProtocoll, newELGAProtocoll.GetType().Name.Trim(), EFEntities.ELGAProtocoll);
                return newELGAProtocoll;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }
        private static IEnumerable<PMDS.db.Entities.Protocol> _Protocol = null;
        public static IEnumerable<PMDS.db.Entities.Protocol> Protocol
        {
            get
            {
                return EFEntities._Protocol;
            }
            set
            {
                EFEntities._Protocol = value;
            }
        }
        public static PMDS.db.Entities.Protocol newProtocol(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.newProtocol";
            int FctNr = 250100;
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                //System.Guid gNewGuid = System.Guid.NewGuid();
                //EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                PMDS.db.Entities.Protocol newProtocol = new PMDS.db.Entities.Protocol();
                EFEntities1.efNewRow(ref EFEntities.lstEfTables, db, newProtocol, newProtocol.GetType().Name.Trim(), EFEntities.Protocol);
                return newProtocol;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
                return null;
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + ": " + ex.ToString(), FctNr);
                return null;
            }
        }











        public enum eTypeCol
        {
            tString = 0,
            tBoolean = 1,
            tInteger = 2,
            tDecimal1 = 3,
            tDateTime = 4,
            tGuid = 5,
            tImage = 6,
            tBinary = 7,
            tFloat = 8,
            tNumeric = 9,
            tXml =10,
        }









        public void init2(bool checkEF)
        {
            string FctName = "EFEntities.init";
            int FctNr = 257000001;
            try
            {
                PMDS.Global.db.ERSystem.EFEntities EFEntities = new PMDS.Global.db.ERSystem.EFEntities();
                PMDS.Global.db.ERSystem.ERHelper helper = new PMDS.Global.db.ERSystem.ERHelper();

                EFEntities.db = PMDSBusiness.getDBContext();
                helper.TemplateSqlCommandInEntityFramework2(db);

                EFEntities.initMetadata(ref EFEntities.lstEfTables, db, checkEF);
                EFEntities.initEFTables(db, checkEF);
                EFEntities.loadTablesIntoRAM(ref EFEntities.lstEfTables, db, checkEF);
                EFEntities.testNewRowsEF(db, checkEF);
                EFEntities.testEFBusinessLayer(ref EFEntities.lstEfTables, db, checkEF);

                //helper.testMetyEF(db);

                //PMDSBusinessRAM bRAM = new PMDSBusinessRAM();
                //bRAM.loadDataStart();
                TestUnits TestUnits1 = new ERSystem.TestUnits();
                TestUnits1.start();

                //Process currentProcess = Process.GetCurrentProcess();
                //currentProcess.Kill();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }


        public void initMetadata(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db,
                                    bool checkEF)
        {
            string FctName = "EFEntities.initMetadata";
            int FctNr = 257000002;
            try
            {
                //System.Collections.Generic.List<string> lstTables = new List<string>();

                var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
                var tables = metadata.GetItemCollection(DataSpace.SSpace)
                    .GetItems<EntityContainer>()
                    .Single()
                    .BaseEntitySets
                    .OfType<EntitySet>()
                    .Where(s => !s.MetadataProperties.Contains("Type")
                    || s.MetadataProperties["Type"].ToString() == "Tables");

                foreach (var table in tables)
                {
                    var tableName = table.MetadataProperties.Contains("Table")
                        && table.MetadataProperties["Table"].Value != null
                        ? table.MetadataProperties["Table"].Value.ToString()
                        : table.Name;

                    if (table.MetadataProperties["Schema"].Value != null)
                    {
                        var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
                        //lstTables.Add(tableSchema + "." + tableName);
                        if (tableName.Trim() == "ZusatzWert")
                        {
                            bool sStop = true;
                        }
                    }
                    else
                    {
                        //lstTables.Add(tableName);
                    }
                }

                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                foreach (var entity in entityProps)
                {
                    var personRightStorageMetadata2 = (from m in entityProps where m.Name == entity.Name.Trim() select m).Single();

                    efTable NewEfTable = new efTable();
                    NewEfTable.TableName = entity.Name.Trim();
                    NewEfTable.EntityType = entity;
                    lstTables.Add(NewEfTable.TableName, NewEfTable);

                    foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty infoCol in personRightStorageMetadata2.Properties)
                    {
                        eTypeCol TypeCol = new eTypeCol();
                        string tableName = "";
                        string colName = infoCol.Name;
                        bool IsNullable = infoCol.Nullable;

                        if (infoCol.Nullable)
                        {
                            IsNullable = true;
                        }

                        if (infoCol.PrimitiveType.ToString().EndsWith("varchar", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("varchar(max)", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("nchar", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("char", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("nvarchar(max)", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("text", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("bit", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tBoolean;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("int", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tInteger;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("float", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tFloat;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("numeric", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tNumeric;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("decimal", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDecimal1;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("datetime", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("datetime2", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("date", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("uniqueidentifier", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tGuid;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("image", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tImage;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("varbinary(max)", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tBinary;
                        }
                        else if (infoCol.TypeName.Trim().EndsWith("xml", StringComparison.OrdinalIgnoreCase))
                        {
                            TypeCol = eTypeCol.tXml;
                        }
                        else
                        {
                            throw new Exception("Type '' not possible for Field '" + colName.Trim() + "' in Table '" + tableName.Trim() + "'!");
                            //bool TypeNotDefined = true;
                        }

                        efColumn newEfColumn = new efColumn();
                        newEfColumn.ColumnName = colName.Trim();
                        newEfColumn.IsNullable = IsNullable;
                        newEfColumn.typeCol = TypeCol;
                        newEfColumn.EdmProperty = infoCol;
                        NewEfTable.lstCols.Add(newEfColumn);
                    }
                }

                bool bOK = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }

        public void initEFTables(PMDS.db.Entities.ERModellPMDSEntities db, bool checkEF)
        {
            string FctName = "EFEntities.initEFTables";
            int FctNr = 257000003;
            try
            {
                bool checkAddEF = true;         //=checkEF;
                bool runSql = false;

                int iFound = 0;
                System.Collections.Generic.Dictionary<string, string> lstColsChange = new Dictionary<string, string>();
                System.Guid gNewGuid = System.Guid.NewGuid();
                int iKey = -96949;
                string sKey = "xyxy376abc9";

                EFEntities.Abteilung = from p in db.Abteilung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Abteilung.Count();
                PMDS.db.Entities.Abteilung newAbteilung = new PMDS.db.Entities.Abteilung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAbteilung, newAbteilung.GetType().Name.Trim(), EFEntities.Abteilung);

                EFEntities.Adresse = from p in db.Adresse.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Adresse.Count();
                PMDS.db.Entities.Adresse newAdresse = new PMDS.db.Entities.Adresse();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAdresse, newAdresse.GetType().Name.Trim(), EFEntities.Adresse);

                EFEntities.Aerzte = from p in db.Aerzte.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Aerzte.Count();
                PMDS.db.Entities.Aerzte newAerzte = new PMDS.db.Entities.Aerzte();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAerzte, newAerzte.GetType().Name.Trim(), EFEntities.Aerzte);

                EFEntities.Anamnese_Krohwinkel = from p in db.Anamnese_Krohwinkel.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Anamnese_Krohwinkel.Count();
                PMDS.db.Entities.Anamnese_Krohwinkel newAnamnese_Krohwinkel = new PMDS.db.Entities.Anamnese_Krohwinkel();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_Krohwinkel, newAnamnese_Krohwinkel.GetType().Name.Trim(), EFEntities.Anamnese_Krohwinkel);

                EFEntities.Anamnese_Orem = from p in db.Anamnese_Orem.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Anamnese_Orem.Count();
                PMDS.db.Entities.Anamnese_Orem newAnamnese_Orem = new PMDS.db.Entities.Anamnese_Orem();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_Orem, newAnamnese_Orem.GetType().Name.Trim(), EFEntities.Anamnese_Orem);

                EFEntities.Anamnese_POP = from p in db.Anamnese_POP.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Anamnese_POP.Count();
                PMDS.db.Entities.Anamnese_POP newAnamnese_POP = new PMDS.db.Entities.Anamnese_POP();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAnamnese_POP, newAnamnese_POP.GetType().Name.Trim(), EFEntities.Anamnese_POP);

                EFEntities.Anmeldungen = from p in db.Anmeldungen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Anmeldungen.Count();
                PMDS.db.Entities.Anmeldungen newAnmeldungen = new PMDS.db.Entities.Anmeldungen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAnmeldungen, newAnmeldungen.GetType().Name.Trim(), EFEntities.Anmeldungen);

                EFEntities.Aufenthalt = from p in db.Aufenthalt.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Aufenthalt.Count();
                PMDS.db.Entities.Aufenthalt newAufenthalt = new PMDS.db.Entities.Aufenthalt();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAufenthalt, newAufenthalt.GetType().Name.Trim(), EFEntities.Aufenthalt);

                EFEntities.AufenthaltPDx = from p in db.AufenthaltPDx.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.AufenthaltPDx.Count();
                PMDS.db.Entities.AufenthaltPDx newAufenthaltPDx = new PMDS.db.Entities.AufenthaltPDx();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltPDx, newAufenthaltPDx.GetType().Name.Trim(), EFEntities.AufenthaltPDx);

                EFEntities.AufenthaltVerlauf = from p in db.AufenthaltVerlauf.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.AufenthaltVerlauf.Count();
                PMDS.db.Entities.AufenthaltVerlauf newAufenthaltVerlauf = new PMDS.db.Entities.AufenthaltVerlauf();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltVerlauf, newAufenthaltVerlauf.GetType().Name.Trim(), EFEntities.AufenthaltVerlauf);

                EFEntities.AufenthaltZusatz = from p in db.AufenthaltZusatz.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.AufenthaltZusatz.Count();
                PMDS.db.Entities.AufenthaltZusatz newAufenthaltZusatz = new PMDS.db.Entities.AufenthaltZusatz();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAufenthaltZusatz, newAufenthaltZusatz.GetType().Name.Trim(), EFEntities.AufenthaltZusatz);

                EFEntities.AuswahlListe = from p in db.AuswahlListe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.AuswahlListe.Count();
                PMDS.db.Entities.AuswahlListe newAuswahlListe = new PMDS.db.Entities.AuswahlListe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAuswahlListe, newAuswahlListe.GetType().Name.Trim(), EFEntities.AuswahlListe);

                EFEntities.AuswahlListeGruppe = from p in db.AuswahlListeGruppe.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.AuswahlListeGruppe.Count();
                PMDS.db.Entities.AuswahlListeGruppe newAuswahlListeGruppe = new PMDS.db.Entities.AuswahlListeGruppe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newAuswahlListeGruppe, newAuswahlListeGruppe.GetType().Name.Trim(), EFEntities.AuswahlListeGruppe);

                EFEntities.Bank = from p in db.Bank.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Bank.Count();
                PMDS.db.Entities.Bank newBank = new PMDS.db.Entities.Bank();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBank, newBank.GetType().Name.Trim(), EFEntities.Bank);

                EFEntities.BarcodeQ = from p in db.BarcodeQ.AsEnumerable() where p.ID == iKey select p;
                if (runSql) iFound = EFEntities.BarcodeQ.Count();
                PMDS.db.Entities.BarcodeQ newBarcodeQ = new PMDS.db.Entities.BarcodeQ();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBarcodeQ, newBarcodeQ.GetType().Name.Trim(), EFEntities.BarcodeQ);

                lstColsChange = new Dictionary<string, string>();
                lstColsChange.Add("Belegung", "Belegung1");
                EFEntities.Belegung = from p in db.Belegung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Belegung.Count();
                PMDS.db.Entities.Belegung newBelegung = new PMDS.db.Entities.Belegung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBelegung, newBelegung.GetType().Name.Trim(), EFEntities.Belegung, lstColsChange);

                lstColsChange = new Dictionary<string, string>();
                lstColsChange.Add("Benutzer", "Benutzer1");
                EFEntities.Benutzer = from p in db.Benutzer.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Benutzer.Count();
                PMDS.db.Entities.Benutzer newBenutzer = new PMDS.db.Entities.Benutzer();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBenutzer, newBenutzer.GetType().Name.Trim(), EFEntities.Benutzer, lstColsChange);

                EFEntities.BenutzerAbteilung = from p in db.BenutzerAbteilung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.BenutzerAbteilung.Count();
                PMDS.db.Entities.BenutzerAbteilung newBenutzerAbteilung = new PMDS.db.Entities.BenutzerAbteilung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerAbteilung, newBenutzerAbteilung.GetType().Name.Trim(), EFEntities.BenutzerAbteilung);

                EFEntities.BenutzerBezug = from p in db.BenutzerBezug.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.BenutzerBezug.Count();
                PMDS.db.Entities.BenutzerBezug newBenutzerBezug = new PMDS.db.Entities.BenutzerBezug();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerBezug, newBenutzerBezug.GetType().Name.Trim(), EFEntities.BenutzerBezug);

                EFEntities.BenutzerEinrichtung = from p in db.BenutzerEinrichtung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.BenutzerEinrichtung.Count();
                PMDS.db.Entities.BenutzerEinrichtung newBenutzerEinrichtung = new PMDS.db.Entities.BenutzerEinrichtung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerEinrichtung, newBenutzerEinrichtung.GetType().Name.Trim(), EFEntities.BenutzerEinrichtung);

                EFEntities.BenutzerGruppe = from p in db.BenutzerGruppe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.BenutzerGruppe.Count();
                PMDS.db.Entities.BenutzerGruppe newBenutzerGruppe = new PMDS.db.Entities.BenutzerGruppe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBenutzerGruppe, newBenutzerGruppe.GetType().Name.Trim(), EFEntities.BenutzerGruppe);

                EFEntities.Bereich = from p in db.Bereich.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Bereich.Count();
                PMDS.db.Entities.Bereich newBereich = new PMDS.db.Entities.Bereich();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBereich, newBereich.GetType().Name.Trim(), EFEntities.Bereich);

                EFEntities.BereichBenutzer = from p in db.BereichBenutzer.AsEnumerable() where p.IDBenutzer == gNewGuid select p;
                if (runSql) iFound = EFEntities.BereichBenutzer.Count();
                PMDS.db.Entities.BereichBenutzer newBereichBenutzer = new PMDS.db.Entities.BereichBenutzer();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newBereichBenutzer, newBereichBenutzer.GetType().Name.Trim(), EFEntities.BereichBenutzer);

                EFEntities.billHeader = from p in db.billHeader.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.billHeader.Count();
                PMDS.db.Entities.billHeader newbillHeader = new PMDS.db.Entities.billHeader();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newbillHeader, newbillHeader.GetType().Name.Trim(), EFEntities.billHeader);

                EFEntities.bills = from p in db.bills.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.bills.Count();
                PMDS.db.Entities.bills newbills = new PMDS.db.Entities.bills();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newbills, newbills.GetType().Name.Trim(), EFEntities.bills);

                EFEntities.bookings = from p in db.bookings.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.bookings.Count();
                PMDS.db.Entities.bookings newbookings = new PMDS.db.Entities.bookings();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newbookings, newbookings.GetType().Name.Trim(), EFEntities.bookings);

                EFEntities.DBLizenz = from p in db.DBLizenz.AsEnumerable() where p.ID == iKey select p;
                if (runSql) iFound = EFEntities.DBLizenz.Count();
                PMDS.db.Entities.DBLizenz newDBLizenz = new PMDS.db.Entities.DBLizenz();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newDBLizenz, newDBLizenz.GetType().Name.Trim(), EFEntities.DBLizenz);

                EFEntities.DBVersion = from p in db.DBVersion.AsEnumerable() where p.ID == iKey select p;
                if (runSql) iFound = EFEntities.DBVersion.Count();
                PMDS.db.Entities.DBVersion newDBVersion = new PMDS.db.Entities.DBVersion();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newDBVersion, newDBVersion.GetType().Name.Trim(), EFEntities.DBVersion);

                EFEntities.Dienstzeiten = from p in db.Dienstzeiten.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Dienstzeiten.Count();
                PMDS.db.Entities.Dienstzeiten newDienstzeiten = new PMDS.db.Entities.Dienstzeiten();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newDienstzeiten, newDienstzeiten.GetType().Name.Trim(), EFEntities.Dienstzeiten);

                EFEntities.Dokumente = from p in db.Dokumente.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Dokumente.Count();
                PMDS.db.Entities.Dokumente newDokumente = new PMDS.db.Entities.Dokumente();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newDokumente, newDokumente.GetType().Name.Trim(), EFEntities.Dokumente);

                EFEntities.Dokumente2 = from p in db.Dokumente2.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Dokumente2.Count();
                PMDS.db.Entities.Dokumente2 newDokumente2 = new PMDS.db.Entities.Dokumente2();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newDokumente2, newDokumente2.GetType().Name.Trim(), EFEntities.Dokumente2);

                EFEntities.Einrichtung = from p in db.Einrichtung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Einrichtung.Count();
                PMDS.db.Entities.Einrichtung newEinrichtung = new PMDS.db.Entities.Einrichtung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newEinrichtung, newEinrichtung.GetType().Name.Trim(), EFEntities.Einrichtung);

                EFEntities.Eintrag = from p in db.Eintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Eintrag.Count();
                PMDS.db.Entities.Eintrag newEintrag = new PMDS.db.Entities.Eintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newEintrag, newEintrag.GetType().Name.Trim(), EFEntities.Eintrag);

                EFEntities.EintragStandardprozeduren = from p in db.EintragStandardprozeduren.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.EintragStandardprozeduren.Count();
                PMDS.db.Entities.EintragStandardprozeduren newEintragStandardprozeduren = new PMDS.db.Entities.EintragStandardprozeduren();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newEintragStandardprozeduren, newEintragStandardprozeduren.GetType().Name.Trim(), EFEntities.EintragStandardprozeduren);

                EFEntities.EintragZusatz = from p in db.EintragZusatz.AsEnumerable() where p.IDEintrag == gNewGuid select p;
                if (runSql) iFound = EFEntities.EintragZusatz.Count();
                PMDS.db.Entities.EintragZusatz newEintragZusatz = new PMDS.db.Entities.EintragZusatz();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newEintragZusatz, newEintragZusatz.GetType().Name.Trim(), EFEntities.EintragZusatz);

                EFEntities.Essen = from p in db.Essen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Essen.Count();
                PMDS.db.Entities.Essen newEssen = new PMDS.db.Entities.Essen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newEssen, newEssen.GetType().Name.Trim(), EFEntities.Essen);

                EFEntities.Formular = from p in db.Formular.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Formular.Count();
                PMDS.db.Entities.Formular newFormular = new PMDS.db.Entities.Formular();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newFormular, newFormular.GetType().Name.Trim(), EFEntities.Formular);

                EFEntities.FormularDaten = from p in db.FormularDaten.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.FormularDaten.Count();
                PMDS.db.Entities.FormularDaten newFormularDaten = new PMDS.db.Entities.FormularDaten();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newFormularDaten, newFormularDaten.GetType().Name.Trim(), EFEntities.FormularDaten);

                EFEntities.Gegenstaende = from p in db.Gegenstaende.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Gegenstaende.Count();
                PMDS.db.Entities.Gegenstaende newGegenstaende = new PMDS.db.Entities.Gegenstaende();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newGegenstaende, newGegenstaende.GetType().Name.Trim(), EFEntities.Gegenstaende);

                EFEntities.Gruppe = from p in db.Gruppe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Gruppe.Count();
                PMDS.db.Entities.Gruppe newGruppe = new PMDS.db.Entities.Gruppe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newGruppe, newGruppe.GetType().Name.Trim(), EFEntities.Gruppe);

                EFEntities.GruppenRecht = from p in db.GruppenRecht.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.GruppenRecht.Count();
                PMDS.db.Entities.GruppenRecht newGruppenRecht = new PMDS.db.Entities.GruppenRecht();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newGruppenRecht, newGruppenRecht.GetType().Name.Trim(), EFEntities.GruppenRecht);

                EFEntities.Info = from p in db.Info.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.Info.Count();
                PMDS.db.Entities.Info newInfo = new PMDS.db.Entities.Info();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newInfo, newInfo.GetType().Name.Trim(), EFEntities.Info);

                EFEntities.Klinik = from p in db.Klinik.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Klinik.Count();
                PMDS.db.Entities.Klinik newKlinik = new PMDS.db.Entities.Klinik();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newKlinik, newKlinik.GetType().Name.Trim(), EFEntities.Klinik);

                EFEntities.Kontakt = from p in db.Kontakt.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Kontakt.Count();
                PMDS.db.Entities.Kontakt newKontakt = new PMDS.db.Entities.Kontakt();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newKontakt, newKontakt.GetType().Name.Trim(), EFEntities.Kontakt);

                EFEntities.Kontaktperson = from p in db.Kontaktperson.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Kontaktperson.Count();
                PMDS.db.Entities.Kontaktperson newKontaktperson = new PMDS.db.Entities.Kontaktperson();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newKontaktperson, newKontaktperson.GetType().Name.Trim(), EFEntities.Kontaktperson);

                EFEntities.KontaktpersonStammdaten = from p in db.KontaktpersonStammdaten.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.KontaktpersonStammdaten.Count();
                PMDS.db.Entities.KontaktpersonStammdaten newKontaktpersonStammdaten = new PMDS.db.Entities.KontaktpersonStammdaten();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newKontaktpersonStammdaten, newKontaktpersonStammdaten.GetType().Name.Trim(), EFEntities.KontaktpersonStammdaten);

                EFEntities.Kostentraeger = from p in db.Kostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Kostentraeger.Count();
                PMDS.db.Entities.Kostentraeger newKostentraeger = new PMDS.db.Entities.Kostentraeger();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newKostentraeger, newKostentraeger.GetType().Name.Trim(), EFEntities.Kostentraeger);

                EFEntities.Leistungskatalog = from p in db.Leistungskatalog.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Leistungskatalog.Count();
                PMDS.db.Entities.Leistungskatalog newLeistungskatalog = new PMDS.db.Entities.Leistungskatalog();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newLeistungskatalog, newLeistungskatalog.GetType().Name.Trim(), EFEntities.Leistungskatalog);

                EFEntities.LeistungskatalogGueltig = from p in db.LeistungskatalogGueltig.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.LeistungskatalogGueltig.Count();
                PMDS.db.Entities.LeistungskatalogGueltig newLeistungskatalogGueltig = new PMDS.db.Entities.LeistungskatalogGueltig();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newLeistungskatalogGueltig, newLeistungskatalogGueltig.GetType().Name.Trim(), EFEntities.LeistungskatalogGueltig);

                EFEntities.LinkDokumente = from p in db.LinkDokumente.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.LinkDokumente.Count();
                PMDS.db.Entities.LinkDokumente newLinkDokumente = new PMDS.db.Entities.LinkDokumente();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newLinkDokumente, newLinkDokumente.GetType().Name.Trim(), EFEntities.LinkDokumente);

                EFEntities.manBuch = from p in db.manBuch.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.manBuch.Count();
                PMDS.db.Entities.manBuch newmanBuch = new PMDS.db.Entities.manBuch();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newmanBuch, newmanBuch.GetType().Name.Trim(), EFEntities.manBuch);

                EFEntities.Massnahmenserien = from p in db.Massnahmenserien.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Massnahmenserien.Count();
                PMDS.db.Entities.Massnahmenserien newMassnahmenserien = new PMDS.db.Entities.Massnahmenserien();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMassnahmenserien, newMassnahmenserien.GetType().Name.Trim(), EFEntities.Massnahmenserien);

                EFEntities.Medikament = from p in db.Medikament.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Medikament.Count();
                PMDS.db.Entities.Medikament newMedikament = new PMDS.db.Entities.Medikament();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMedikament, newMedikament.GetType().Name.Trim(), EFEntities.Medikament);

                EFEntities.MedikationAbgabe = from p in db.MedikationAbgabe.AsEnumerable() where p.IDRezeptEintrag == gNewGuid select p;
                if (runSql) iFound = EFEntities.MedikationAbgabe.Count();
                PMDS.db.Entities.MedikationAbgabe newMedikationAbgabe = new PMDS.db.Entities.MedikationAbgabe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMedikationAbgabe, newMedikationAbgabe.GetType().Name.Trim(), EFEntities.MedikationAbgabe);

                EFEntities.MedizinischeDaten = from p in db.MedizinischeDaten.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.MedizinischeDaten.Count();
                PMDS.db.Entities.MedizinischeDaten newMedizinischeDaten = new PMDS.db.Entities.MedizinischeDaten();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeDaten, newMedizinischeDaten.GetType().Name.Trim(), EFEntities.MedizinischeDaten);

                EFEntities.MedizinischeDatenLayout = from p in db.MedizinischeDatenLayout.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.MedizinischeDatenLayout.Count();
                PMDS.db.Entities.MedizinischeDatenLayout newMedizinischeDatenLayout = new PMDS.db.Entities.MedizinischeDatenLayout();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeDatenLayout, newMedizinischeDatenLayout.GetType().Name.Trim(), EFEntities.MedizinischeDatenLayout);

                EFEntities.MedizinischeTypen = from p in db.MedizinischeTypen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.MedizinischeTypen.Count();
                PMDS.db.Entities.MedizinischeTypen newMedizinischeTypen = new PMDS.db.Entities.MedizinischeTypen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newMedizinischeTypen, newMedizinischeTypen.GetType().Name.Trim(), EFEntities.MedizinischeTypen);

                EFEntities.Patient = from p in db.Patient.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Patient.Count();
                PMDS.db.Entities.Patient newPatient = new PMDS.db.Entities.Patient();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatient, newPatient.GetType().Name.Trim(), EFEntities.Patient);

                EFEntities.PatientAbwesenheit = from p in db.PatientAbwesenheit.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientAbwesenheit.Count();
                PMDS.db.Entities.PatientAbwesenheit newPatientAbwesenheit = new PMDS.db.Entities.PatientAbwesenheit();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientAbwesenheit, newPatientAbwesenheit.GetType().Name.Trim(), EFEntities.PatientAbwesenheit);

                EFEntities.PatientAerzte = from p in db.PatientAerzte.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientAerzte.Count();
                PMDS.db.Entities.PatientAerzte newPatientAerzte = new PMDS.db.Entities.PatientAerzte();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientAerzte, newPatientAerzte.GetType().Name.Trim(), EFEntities.PatientAerzte);

                EFEntities.PatientEinkommen = from p in db.PatientEinkommen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientEinkommen.Count();
                PMDS.db.Entities.PatientEinkommen newPatientEinkommen = new PMDS.db.Entities.PatientEinkommen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientEinkommen, newPatientEinkommen.GetType().Name.Trim(), EFEntities.PatientEinkommen);

                EFEntities.PatientenBemerkung = from p in db.PatientenBemerkung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientenBemerkung.Count();
                PMDS.db.Entities.PatientenBemerkung newPatientenBemerkung = new PMDS.db.Entities.PatientenBemerkung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientenBemerkung, newPatientenBemerkung.GetType().Name.Trim(), EFEntities.PatientenBemerkung);

                EFEntities.PatientKostentraeger = from p in db.PatientKostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientKostentraeger.Count();
                PMDS.db.Entities.PatientKostentraeger newPatientKostentraeger = new PMDS.db.Entities.PatientKostentraeger();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientKostentraeger, newPatientKostentraeger.GetType().Name.Trim(), EFEntities.PatientKostentraeger);

                EFEntities.PatientLeistungsplan = from p in db.PatientLeistungsplan.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientLeistungsplan.Count();
                PMDS.db.Entities.PatientLeistungsplan newPatientLeistungsplan = new PMDS.db.Entities.PatientLeistungsplan();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientLeistungsplan, newPatientLeistungsplan.GetType().Name.Trim(), EFEntities.PatientLeistungsplan);

                EFEntities.PatientPflegestufe = from p in db.PatientPflegestufe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientPflegestufe.Count();
                PMDS.db.Entities.PatientPflegestufe newPatientPflegestufe = new PMDS.db.Entities.PatientPflegestufe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientPflegestufe, newPatientPflegestufe.GetType().Name.Trim(), EFEntities.PatientPflegestufe);

                EFEntities.PatientSonderleistung = from p in db.PatientSonderleistung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientSonderleistung.Count();
                PMDS.db.Entities.PatientSonderleistung newPatientSonderleistung = new PMDS.db.Entities.PatientSonderleistung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientSonderleistung, newPatientSonderleistung.GetType().Name.Trim(), EFEntities.PatientSonderleistung);

                EFEntities.PatientTaschengeldKostentraeger = from p in db.PatientTaschengeldKostentraeger.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PatientTaschengeldKostentraeger.Count();
                PMDS.db.Entities.PatientTaschengeldKostentraeger newPatientTaschengeldKostentraeger = new PMDS.db.Entities.PatientTaschengeldKostentraeger();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPatientTaschengeldKostentraeger, newPatientTaschengeldKostentraeger.GetType().Name.Trim(), EFEntities.PatientTaschengeldKostentraeger);

                EFEntities.PDX = from p in db.PDX.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDX.Count();
                PMDS.db.Entities.PDX newPDX = new PMDS.db.Entities.PDX();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDX, newPDX.GetType().Name.Trim(), EFEntities.PDX);

                EFEntities.PDXAnamnese = from p in db.PDXAnamnese.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDXAnamnese.Count();
                PMDS.db.Entities.PDXAnamnese newPDXAnamnese = new PMDS.db.Entities.PDXAnamnese();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDXAnamnese, newPDXAnamnese.GetType().Name.Trim(), EFEntities.PDXAnamnese);

                EFEntities.PDXEintrag = from p in db.PDXEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDXEintrag.Count();
                PMDS.db.Entities.PDXEintrag newPDXEintrag = new PMDS.db.Entities.PDXEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDXEintrag, newPDXEintrag.GetType().Name.Trim(), EFEntities.PDXEintrag);

                EFEntities.PDXGruppe = from p in db.PDXGruppe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDXGruppe.Count();
                PMDS.db.Entities.PDXGruppe newPDXGruppe = new PMDS.db.Entities.PDXGruppe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDXGruppe, newPDXGruppe.GetType().Name.Trim(), EFEntities.PDXGruppe);

                EFEntities.PDXGruppeEintrag = from p in db.PDXGruppeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDXGruppeEintrag.Count();
                PMDS.db.Entities.PDXGruppeEintrag newPDXGruppeEintrag = new PMDS.db.Entities.PDXGruppeEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDXGruppeEintrag, newPDXGruppeEintrag.GetType().Name.Trim(), EFEntities.PDXGruppeEintrag);

                EFEntities.PDXPflegemodelle = from p in db.PDXPflegemodelle.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PDXPflegemodelle.Count();
                PMDS.db.Entities.PDXPflegemodelle newPDXPflegemodelle = new PMDS.db.Entities.PDXPflegemodelle();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPDXPflegemodelle, newPDXPflegemodelle.GetType().Name.Trim(), EFEntities.PDXPflegemodelle);

                EFEntities.PflegeEintrag = from p in db.PflegeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PflegeEintrag.Count();
                PMDS.db.Entities.PflegeEintrag newPflegeEintrag = new PMDS.db.Entities.PflegeEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegeEintrag, newPflegeEintrag.GetType().Name.Trim(), EFEntities.PflegeEintrag);

                EFEntities.Pflegegeldstufe = from p in db.Pflegegeldstufe.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Pflegegeldstufe.Count();
                PMDS.db.Entities.Pflegegeldstufe newPflegegeldstufe = new PMDS.db.Entities.Pflegegeldstufe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegegeldstufe, newPflegegeldstufe.GetType().Name.Trim(), EFEntities.Pflegegeldstufe);

                EFEntities.PflegegeldstufeGueltig = from p in db.PflegegeldstufeGueltig.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PflegegeldstufeGueltig.Count();
                PMDS.db.Entities.PflegegeldstufeGueltig newPflegegeldstufeGueltig = new PMDS.db.Entities.PflegegeldstufeGueltig();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegegeldstufeGueltig, newPflegegeldstufeGueltig.GetType().Name.Trim(), EFEntities.PflegegeldstufeGueltig);

                EFEntities.Pflegemodelle = from p in db.Pflegemodelle.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Pflegemodelle.Count();
                PMDS.db.Entities.Pflegemodelle newPflegemodelle = new PMDS.db.Entities.Pflegemodelle();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegemodelle, newPflegemodelle.GetType().Name.Trim(), EFEntities.Pflegemodelle);

                EFEntities.PflegePlan = from p in db.PflegePlan.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PflegePlan.Count();
                PMDS.db.Entities.PflegePlan newPflegePlan = new PMDS.db.Entities.PflegePlan();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlan, newPflegePlan.GetType().Name.Trim(), EFEntities.PflegePlan);

                EFEntities.PflegePlanH = from p in db.PflegePlanH.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PflegePlanH.Count();
                PMDS.db.Entities.PflegePlanH newPflegePlanH = new PMDS.db.Entities.PflegePlanH();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlanH, newPflegePlanH.GetType().Name.Trim(), EFEntities.PflegePlanH);

                EFEntities.PflegePlanPDx = from p in db.PflegePlanPDx.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.PflegePlanPDx.Count();
                PMDS.db.Entities.PflegePlanPDx newPflegePlanPDx = new PMDS.db.Entities.PflegePlanPDx();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newPflegePlanPDx, newPflegePlanPDx.GetType().Name.Trim(), EFEntities.PflegePlanPDx);

                EFEntities.QuickFilter = from p in db.QuickFilter.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.QuickFilter.Count();
                PMDS.db.Entities.QuickFilter newQuickFilter = new PMDS.db.Entities.QuickFilter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newQuickFilter, newQuickFilter.GetType().Name.Trim(), EFEntities.QuickFilter);

                EFEntities.QuickMeldung = from p in db.QuickMeldung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.QuickMeldung.Count();
                PMDS.db.Entities.QuickMeldung newQuickMeldung = new PMDS.db.Entities.QuickMeldung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newQuickMeldung, newQuickMeldung.GetType().Name.Trim(), EFEntities.QuickMeldung);

                EFEntities.rechNr = from p in db.rechNr.AsEnumerable() where p.nr == iKey select p;
                if (runSql) iFound = EFEntities.rechNr.Count();
                PMDS.db.Entities.rechNr newrechNr = new PMDS.db.Entities.rechNr();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newrechNr, newrechNr.GetType().Name.Trim(), EFEntities.rechNr);

                EFEntities.Recht = from p in db.Recht.AsEnumerable() where p.ID == iKey select p;
                if (runSql) iFound = EFEntities.Recht.Count();
                PMDS.db.Entities.Recht newRecht = new PMDS.db.Entities.Recht();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newRecht, newRecht.GetType().Name.Trim(), EFEntities.Recht);

                EFEntities.Rehabilitation = from p in db.Rehabilitation.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Rehabilitation.Count();
                PMDS.db.Entities.Rehabilitation newRehabilitation = new PMDS.db.Entities.Rehabilitation();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newRehabilitation, newRehabilitation.GetType().Name.Trim(), EFEntities.Rehabilitation);

                EFEntities.RezeptBestellungPos = from p in db.RezeptBestellungPos.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.RezeptBestellungPos.Count();
                PMDS.db.Entities.RezeptBestellungPos newRezeptBestellungPos = new PMDS.db.Entities.RezeptBestellungPos();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newRezeptBestellungPos, newRezeptBestellungPos.GetType().Name.Trim(), EFEntities.RezeptBestellungPos);

                EFEntities.RezeptEintrag = from p in db.RezeptEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.RezeptEintrag.Count();
                PMDS.db.Entities.RezeptEintrag newRezeptEintrag = new PMDS.db.Entities.RezeptEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newRezeptEintrag, newRezeptEintrag.GetType().Name.Trim(), EFEntities.RezeptEintrag);

                EFEntities.Sachwalter = from p in db.Sachwalter.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Sachwalter.Count();
                PMDS.db.Entities.Sachwalter newSachwalter = new PMDS.db.Entities.Sachwalter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSachwalter, newSachwalter.GetType().Name.Trim(), EFEntities.Sachwalter);

                EFEntities.SonderleistungsKatalog = from p in db.SonderleistungsKatalog.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.SonderleistungsKatalog.Count();
                PMDS.db.Entities.SonderleistungsKatalog newSonderleistungsKatalog = new PMDS.db.Entities.SonderleistungsKatalog();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSonderleistungsKatalog, newSonderleistungsKatalog.GetType().Name.Trim(), EFEntities.SonderleistungsKatalog);

                EFEntities.SP = from p in db.SP.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.SP.Count();
                PMDS.db.Entities.SP newSP = new PMDS.db.Entities.SP();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSP, newSP.GetType().Name.Trim(), EFEntities.SP);

                EFEntities.SPDynRep = from p in db.SPDynRep.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.SPDynRep.Count();
                PMDS.db.Entities.SPDynRep newSPDynRep = new PMDS.db.Entities.SPDynRep();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSPDynRep, newSPDynRep.GetType().Name.Trim(), EFEntities.SPDynRep);

                EFEntities.SPPE = from p in db.SPPE.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.SPPE.Count();
                PMDS.db.Entities.SPPE newSPPE = new PMDS.db.Entities.SPPE();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSPPE, newSPPE.GetType().Name.Trim(), EFEntities.SPPE);

                EFEntities.SPPOS = from p in db.SPPOS.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.SPPOS.Count();
                PMDS.db.Entities.SPPOS newSPPOS = new PMDS.db.Entities.SPPOS();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newSPPOS, newSPPOS.GetType().Name.Trim(), EFEntities.SPPOS);

                EFEntities.StandardProzeduren = from p in db.StandardProzeduren.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.StandardProzeduren.Count();
                PMDS.db.Entities.StandardProzeduren newStandardProzeduren = new PMDS.db.Entities.StandardProzeduren();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newStandardProzeduren, newStandardProzeduren.GetType().Name.Trim(), EFEntities.StandardProzeduren);

                EFEntities.Standardzeiten = from p in db.Standardzeiten.AsEnumerable() where p.ID == iKey select p;
                if (runSql) iFound = EFEntities.Standardzeiten.Count();
                PMDS.db.Entities.Standardzeiten newStandardzeiten = new PMDS.db.Entities.Standardzeiten();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newStandardzeiten, newStandardzeiten.GetType().Name.Trim(), EFEntities.Standardzeiten);

                EFEntities.Taschengeld = from p in db.Taschengeld.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Taschengeld.Count();
                PMDS.db.Entities.Taschengeld newTaschengeld = new PMDS.db.Entities.Taschengeld();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newTaschengeld, newTaschengeld.GetType().Name.Trim(), EFEntities.Taschengeld);

                EFEntities.tbl_Nachricht = from p in db.tbl_Nachricht.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tbl_Nachricht.Count();
                PMDS.db.Entities.tbl_Nachricht newtbl_Nachricht = new PMDS.db.Entities.tbl_Nachricht();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtbl_Nachricht, newtbl_Nachricht.GetType().Name.Trim(), EFEntities.tbl_Nachricht);

                EFEntities.tblDokumente = from p in db.tblDokumente.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblDokumente.Count();
                PMDS.db.Entities.tblDokumente newtblDokumente = new PMDS.db.Entities.tblDokumente();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumente, newtblDokumente.GetType().Name.Trim(), EFEntities.tblDokumente);

                EFEntities.tblDokumenteGelesen = from p in db.tblDokumenteGelesen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblDokumenteGelesen.Count();
                PMDS.db.Entities.tblDokumenteGelesen newtblDokumenteGelesen = new PMDS.db.Entities.tblDokumenteGelesen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteGelesen, newtblDokumenteGelesen.GetType().Name.Trim(), EFEntities.tblDokumenteGelesen);

                EFEntities.tblDokumenteintrag = from p in db.tblDokumenteintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblDokumenteintrag.Count();
                PMDS.db.Entities.tblDokumenteintrag newtblDokumenteintrag = new PMDS.db.Entities.tblDokumenteintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteintrag, newtblDokumenteintrag.GetType().Name.Trim(), EFEntities.tblDokumenteintrag);

                EFEntities.tblDokumenteneintragSchlagwörter = from p in db.tblDokumenteneintragSchlagwörter.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblDokumenteneintragSchlagwörter.Count();
                PMDS.db.Entities.tblDokumenteneintragSchlagwörter newtblDokumenteneintragSchlagwörter = new PMDS.db.Entities.tblDokumenteneintragSchlagwörter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblDokumenteneintragSchlagwörter, newtblDokumenteneintragSchlagwörter.GetType().Name.Trim(), EFEntities.tblDokumenteneintragSchlagwörter);

                EFEntities.tblFach = from p in db.tblFach.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblFach.Count();
                PMDS.db.Entities.tblFach newtblFach = new PMDS.db.Entities.tblFach();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblFach, newtblFach.GetType().Name.Trim(), EFEntities.tblFach);

                EFEntities.tblFortbildungBenutzer = from p in db.tblFortbildungBenutzer.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblFortbildungBenutzer.Count();
                PMDS.db.Entities.tblFortbildungBenutzer newtblFortbildungBenutzer = new PMDS.db.Entities.tblFortbildungBenutzer();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblFortbildungBenutzer, newtblFortbildungBenutzer.GetType().Name.Trim(), EFEntities.tblFortbildungBenutzer);

                EFEntities.tblFortbildungen = from p in db.tblFortbildungen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblFortbildungen.Count();
                PMDS.db.Entities.tblFortbildungen newtblFortbildungen = new PMDS.db.Entities.tblFortbildungen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblFortbildungen, newtblFortbildungen.GetType().Name.Trim(), EFEntities.tblFortbildungen);

                EFEntities.tblObjekt = from p in db.tblObjekt.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblObjekt.Count();
                PMDS.db.Entities.tblObjekt newtblObjekt = new PMDS.db.Entities.tblObjekt();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblObjekt, newtblObjekt.GetType().Name.Trim(), EFEntities.tblObjekt);

                EFEntities.tblOrdner = from p in db.tblOrdner.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblOrdner.Count();
                PMDS.db.Entities.tblOrdner newtblOrdner = new PMDS.db.Entities.tblOrdner();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblOrdner, newtblOrdner.GetType().Name.Trim(), EFEntities.tblOrdner);

                EFEntities.tblParameter = from p in db.tblParameter.AsEnumerable() where p.bezeichnung == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.tblParameter.Count();
                PMDS.db.Entities.tblParameter newtblParameter = new PMDS.db.Entities.tblParameter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblParameter, newtblParameter.GetType().Name.Trim(), EFEntities.tblParameter);

                EFEntities.tblPfad = from p in db.tblPfad.AsEnumerable() where p.Archivpfad == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.tblPfad.Count();
                PMDS.db.Entities.tblPfad newtblPfad = new PMDS.db.Entities.tblPfad();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblPfad, newtblPfad.GetType().Name.Trim(), EFEntities.tblPfad);

                EFEntities.tblProvKonfig = from p in db.tblProvKonfig.AsEnumerable() where p.key == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.tblProvKonfig.Count();
                PMDS.db.Entities.tblProvKonfig newtblProvKonfig = new PMDS.db.Entities.tblProvKonfig();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblProvKonfig, newtblProvKonfig.GetType().Name.Trim(), EFEntities.tblProvKonfig);

                EFEntities.tblRechteOrdner = from p in db.tblRechteOrdner.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblRechteOrdner.Count();
                PMDS.db.Entities.tblRechteOrdner newtblRechteOrdner = new PMDS.db.Entities.tblRechteOrdner();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblRechteOrdner, newtblRechteOrdner.GetType().Name.Trim(), EFEntities.tblRechteOrdner);

                EFEntities.tblSchlagwörter = from p in db.tblSchlagwörter.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblSchlagwörter.Count();
                PMDS.db.Entities.tblSchlagwörter newtblSchlagwörter = new PMDS.db.Entities.tblSchlagwörter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblSchlagwörter, newtblSchlagwörter.GetType().Name.Trim(), EFEntities.tblSchlagwörter);

                EFEntities.tblSchrank = from p in db.tblSchrank.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblSchrank.Count();
                PMDS.db.Entities.tblSchrank newtblSchrank = new PMDS.db.Entities.tblSchrank();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblSchrank, newtblSchrank.GetType().Name.Trim(), EFEntities.tblSchrank);

                EFEntities.tblSturzprotokoll = from p in db.tblSturzprotokoll.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblSturzprotokoll.Count();
                PMDS.db.Entities.tblSturzprotokoll newtblSturzprotokoll = new PMDS.db.Entities.tblSturzprotokoll();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblSturzprotokoll, newtblSturzprotokoll.GetType().Name.Trim(), EFEntities.tblSturzprotokoll);

                EFEntities.tblThemen = from p in db.tblThemen.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblThemen.Count();
                PMDS.db.Entities.tblThemen newtblThemen = new PMDS.db.Entities.tblThemen();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblThemen, newtblThemen.GetType().Name.Trim(), EFEntities.tblThemen);

                EFEntities.tblUIDefinitions = from p in db.tblUIDefinitions.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblUIDefinitions.Count();
                PMDS.db.Entities.tblUIDefinitions newtblUIDefinitions = new PMDS.db.Entities.tblUIDefinitions();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblUIDefinitions, newtblUIDefinitions.GetType().Name.Trim(), EFEntities.tblUIDefinitions);

                EFEntities.tblVeranstalter = from p in db.tblVeranstalter.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.tblVeranstalter.Count();
                PMDS.db.Entities.tblVeranstalter newtblVeranstalter = new PMDS.db.Entities.tblVeranstalter();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newtblVeranstalter, newtblVeranstalter.GetType().Name.Trim(), EFEntities.tblVeranstalter);

                EFEntities.Textbausteine = from p in db.Textbausteine.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Textbausteine.Count();
                PMDS.db.Entities.Textbausteine newTextbausteine = new PMDS.db.Entities.Textbausteine();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newTextbausteine, newTextbausteine.GetType().Name.Trim(), EFEntities.Textbausteine);

                EFEntities.Unterbringung = from p in db.Unterbringung.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Unterbringung.Count();
                PMDS.db.Entities.Unterbringung newUnterbringung = new PMDS.db.Entities.Unterbringung();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newUnterbringung, newUnterbringung.GetType().Name.Trim(), EFEntities.Unterbringung);

                EFEntities.UrlaubVerlauf = from p in db.UrlaubVerlauf.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.UrlaubVerlauf.Count();
                PMDS.db.Entities.UrlaubVerlauf newUrlaubVerlauf = new PMDS.db.Entities.UrlaubVerlauf();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newUrlaubVerlauf, newUrlaubVerlauf.GetType().Name.Trim(), EFEntities.UrlaubVerlauf);

                EFEntities.WundeKopf = from p in db.WundeKopf.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.WundeKopf.Count();
                PMDS.db.Entities.WundeKopf newWundeKopf = new PMDS.db.Entities.WundeKopf();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newWundeKopf, newWundeKopf.GetType().Name.Trim(), EFEntities.WundeKopf);

                EFEntities.WundePos = from p in db.WundePos.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.WundePos.Count();
                PMDS.db.Entities.WundePos newWundePos = new PMDS.db.Entities.WundePos();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newWundePos, newWundePos.GetType().Name.Trim(), EFEntities.WundePos);

                EFEntities.WundePosBilder = from p in db.WundePosBilder.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.WundePosBilder.Count();
                PMDS.db.Entities.WundePosBilder newWundePosBilder = new PMDS.db.Entities.WundePosBilder();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newWundePosBilder, newWundePosBilder.GetType().Name.Trim(), EFEntities.WundePosBilder);

                EFEntities.WundeTherapie = from p in db.WundeTherapie.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.WundeTherapie.Count();
                PMDS.db.Entities.WundeTherapie newWundeTherapie = new PMDS.db.Entities.WundeTherapie();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newWundeTherapie, newWundeTherapie.GetType().Name.Trim(), EFEntities.WundeTherapie);

                EFEntities.Zeitbereich = from p in db.Zeitbereich.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.Zeitbereich.Count();
                PMDS.db.Entities.Zeitbereich newZeitbereich = new PMDS.db.Entities.Zeitbereich();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZeitbereich, newZeitbereich.GetType().Name.Trim(), EFEntities.Zeitbereich);

                EFEntities.ZeitbereichSerien = from p in db.ZeitbereichSerien.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.ZeitbereichSerien.Count();
                PMDS.db.Entities.ZeitbereichSerien newZeitbereichSerien = new PMDS.db.Entities.ZeitbereichSerien();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZeitbereichSerien, newZeitbereichSerien.GetType().Name.Trim(), EFEntities.ZeitbereichSerien);

                EFEntities.ZusatzEintrag = from p in db.ZusatzEintrag.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.ZusatzEintrag.Count();
                PMDS.db.Entities.ZusatzEintrag newZusatzEintrag = new PMDS.db.Entities.ZusatzEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZusatzEintrag, newZusatzEintrag.GetType().Name.Trim(), EFEntities.ZusatzEintrag);

                EFEntities.ZusatzGruppe = from p in db.ZusatzGruppe.AsEnumerable() where p.ID == gNewGuid.ToString() select p;
                if (runSql) iFound = EFEntities.ZusatzGruppe.Count();
                PMDS.db.Entities.ZusatzGruppe newZusatzGruppe = new PMDS.db.Entities.ZusatzGruppe();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZusatzGruppe, newZusatzGruppe.GetType().Name.Trim(), EFEntities.ZusatzGruppe);

                EFEntities.ZusatzGruppeEintrag = from p in db.ZusatzGruppeEintrag.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.ZusatzGruppeEintrag.Count();
                PMDS.db.Entities.ZusatzGruppeEintrag newZusatzGruppeEintrag = new PMDS.db.Entities.ZusatzGruppeEintrag();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZusatzGruppeEintrag, newZusatzGruppeEintrag.GetType().Name.Trim(), EFEntities.ZusatzGruppeEintrag);

                EFEntities.ZusatzWert = from p in db.ZusatzWert.AsEnumerable() where p.ID == gNewGuid select p;
                if (runSql) iFound = EFEntities.ZusatzWert.Count();
                PMDS.db.Entities.ZusatzWert newZusatzWert = new PMDS.db.Entities.ZusatzWert();
                if (checkAddEF) this.efNewRow(ref EFEntities.lstEfTables, db, newZusatzWert, newZusatzWert.GetType().Name.Trim(), EFEntities.ZusatzWert);

                //System.Windows.Forms.MessageBox.Show("OK");
                bool bOK = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }
        public void testNewRowsEF(PMDS.db.Entities.ERModellPMDSEntities db,
                                    bool checkEF)
        {
            string FctName = "EFEntities.testNewRowsEF";
            int FctNr = 257000004;
            try
            {
                PMDS.db.Entities.Abteilung newAbteilung = EFEntities.newAbteilung(db);
                PMDS.db.Entities.Adresse newAdresse = EFEntities.newAdresse(db);
                PMDS.db.Entities.Aerzte newAerzte = EFEntities.newAerzte(db);
                PMDS.db.Entities.Anamnese_Krohwinkel newAnamnese_Krohwinkel = EFEntities.newAnamnese_Krohwinkel(db);
                PMDS.db.Entities.Anamnese_Orem newAnamnese_Orem = EFEntities.newAnamnese_Orem(db);
                PMDS.db.Entities.Anamnese_POP newAnamnese_POP = EFEntities.newAnamnese_POP(db);
                PMDS.db.Entities.Anmeldungen newAnmeldungen = EFEntities.newAnmeldungen(db);
                PMDS.db.Entities.Aufenthalt newAufenthalt = EFEntities.newAufenthalt(db);
                PMDS.db.Entities.AufenthaltPDx newAufenthaltPDx = EFEntities.newAufenthaltPDx(db);
                PMDS.db.Entities.AufenthaltVerlauf newAufenthaltVerlauf = EFEntities.newAufenthaltVerlauf(db);
                PMDS.db.Entities.AufenthaltZusatz newAufenthaltZusatz = EFEntities.newAufenthaltZusatz(db);
                PMDS.db.Entities.AuswahlListe newAuswahlListe = EFEntities.newAuswahlListe(db);
                PMDS.db.Entities.AuswahlListeGruppe newAuswahlListeGruppe = EFEntities.newAuswahlListeGruppe(db);
                PMDS.db.Entities.Bank newBank = EFEntities.newBank(db);
                PMDS.db.Entities.BarcodeQ newBarcodeQ = EFEntities.newBarcodeQ(db);
                PMDS.db.Entities.Belegung newBelegung = EFEntities.newBelegung(db);
                PMDS.db.Entities.Benutzer newBenutzer = EFEntities.newBenutzer(db);
                PMDS.db.Entities.BenutzerAbteilung newBenutzerAbteilung = EFEntities.newBenutzerAbteilung(db);
                PMDS.db.Entities.BenutzerBezug newBenutzerBezug = EFEntities.newBenutzerBezug(db);
                PMDS.db.Entities.BenutzerEinrichtung newBenutzerEinrichtung = EFEntities.newBenutzerEinrichtung(db);
                PMDS.db.Entities.BenutzerGruppe newBenutzerGruppe = EFEntities.newBenutzerGruppe(db);
                PMDS.db.Entities.Bereich newBereich = EFEntities.newBereich(db);
                PMDS.db.Entities.BereichBenutzer newBereichBenutzer = EFEntities.newBereichBenutzer(db);
                PMDS.db.Entities.billHeader newbillHeader = EFEntities.newbillHeader(db);
                PMDS.db.Entities.bills newbills = EFEntities.newbills(db);
                PMDS.db.Entities.bookings newbookings = EFEntities.newbookings(db);
                PMDS.db.Entities.DBLizenz newDBLizenz = EFEntities.newDBLizenz(db);
                PMDS.db.Entities.DBVersion newDDBVersion = EFEntities.newDBVersion(db);
                PMDS.db.Entities.Dienstzeiten newDienstzeiten = EFEntities.newDienstzeiten(db);
                PMDS.db.Entities.Dokumente newDokumente = EFEntities.newDokumente(db);
                PMDS.db.Entities.Dokumente2 newDokumente2 = EFEntities.newDokumente2(db);
                PMDS.db.Entities.Einrichtung newEinrichtung = EFEntities.newEinrichtung(db);
                PMDS.db.Entities.Eintrag newEintrag = EFEntities.newEintrag(db);
                PMDS.db.Entities.EintragStandardprozeduren newEintragStandardprozeduren = EFEntities.newEintragStandardprozeduren(db);
                PMDS.db.Entities.EintragZusatz newEintragZusatz = EFEntities.newEintragZusatz(db);
                PMDS.db.Entities.Essen newEssen = EFEntities.newEssen(db);
                PMDS.db.Entities.Formular newFormular = EFEntities.newFormular(db);
                PMDS.db.Entities.FormularDaten newFormularDaten = EFEntities.newFormularDaten(db);
                PMDS.db.Entities.Gegenstaende newGegenstaende = EFEntities.newGegenstaende(db);
                PMDS.db.Entities.Gruppe newGruppe = EFEntities.newGruppe(db);
                PMDS.db.Entities.GruppenRecht newGruppenRecht = EFEntities.newGruppenRecht(db);
                PMDS.db.Entities.Klinik newKlinik = EFEntities.newKlinik(db);
                PMDS.db.Entities.Kontakt newKontakt = EFEntities.newKontakt(db);
                PMDS.db.Entities.Kontaktperson newKontaktperson = EFEntities.newKontaktperson(db);
                PMDS.db.Entities.KontaktpersonStammdaten newKontaktpersonStammdaten = EFEntities.newKontaktpersonStammdaten(db);
                PMDS.db.Entities.Kostentraeger newKostentraeger = EFEntities.newKostentraeger(db);
                PMDS.db.Entities.Leistungskatalog newLeistungskatalog = EFEntities.newLeistungskatalog(db);
                PMDS.db.Entities.LeistungskatalogGueltig newLeistungskatalogGueltig = EFEntities.newLeistungskatalogGueltig(db);
                PMDS.db.Entities.LinkDokumente newLinkDokumente = EFEntities.newLinkDokumente(db);
                PMDS.db.Entities.manBuch newmanBuch = EFEntities.newmanBuch(db);
                PMDS.db.Entities.Massnahmenserien newMassnahmenserien = EFEntities.newMassnahmenserien(db);
                PMDS.db.Entities.Medikament newMedikament = EFEntities.newMedikament(db);
                PMDS.db.Entities.MedikationAbgabe newMedikationAbgabe = EFEntities.newMedikationAbgabe(db);
                PMDS.db.Entities.MedizinischeDaten newMedizinischeDaten = EFEntities.newMedizinischeDaten(db);
                PMDS.db.Entities.MedizinischeDatenLayout newMedizinischeDatenLayout = EFEntities.newMedizinischeDatenLayout(db);
                PMDS.db.Entities.MedizinischeTypen newMedizinischeTypen = EFEntities.newMedizinischeTypen(db);
                PMDS.db.Entities.Patient newPatient = EFEntities.newPatient(db);
                PMDS.db.Entities.PatientAbwesenheit newPatientAbwesenheit = EFEntities.newPatientAbwesenheit(db);
                PMDS.db.Entities.PatientAerzte newPatientAerzte = EFEntities.newPatientAerzte(db);
                PMDS.db.Entities.PatientEinkommen newPatientEinkommen = EFEntities.newPatientEinkommen(db);
                PMDS.db.Entities.PatientenBemerkung newPatientenBemerkung = EFEntities.newPatientenBemerkung(db);
                PMDS.db.Entities.PatientKostentraeger newPatientKostentraeger = EFEntities.newPatientKostentraeger(db);
                PMDS.db.Entities.PatientLeistungsplan newPatientLeistungsplan = EFEntities.newPatientLeistungsplan(db);
                PMDS.db.Entities.PatientPflegestufe newPatientPflegestufe = EFEntities.newPatientPflegestufe(db);
                PMDS.db.Entities.PatientSonderleistung newPatientSonderleistung = EFEntities.newPatientSonderleistung(db);
                PMDS.db.Entities.PatientTaschengeldKostentraeger newPatientTaschengeldKostentraeger = EFEntities.newPatientTaschengeldKostentraeger(db);
                PMDS.db.Entities.PDX newPDX = EFEntities.newPDX(db);
                PMDS.db.Entities.PDXAnamnese newPDXAnamnese = EFEntities.newPDXAnamnese(db);
                PMDS.db.Entities.PDXEintrag newPDXEintrag = EFEntities.newPDXEintrag(db);
                PMDS.db.Entities.PDXGruppe newPDXGruppe = EFEntities.newPDXGruppe(db);
                PMDS.db.Entities.PDXGruppeEintrag newPDXGruppeEintrag = EFEntities.newPDXGruppeEintrag(db);
                PMDS.db.Entities.PDXPflegemodelle newPDXPflegemodelle = EFEntities.newPDXPflegemodelle(db);
                PMDS.db.Entities.PflegeEintrag newPflegeEintrag = EFEntities.newPflegeEintrag(db);
                PMDS.db.Entities.Pflegegeldstufe newPflegegeldstufe = EFEntities.newPflegegeldstufe(db);
                PMDS.db.Entities.PflegegeldstufeGueltig newPflegegeldstufeGueltig = EFEntities.newPflegegeldstufeGueltig(db);
                PMDS.db.Entities.Pflegemodelle newPflegemodelle = EFEntities.newPflegemodelle(db);
                PMDS.db.Entities.PflegePlan newPflegePlan = EFEntities.newPflegePlan(db);
                PMDS.db.Entities.PflegePlanH newPflegePlanH = EFEntities.newPflegePlanH(db);
                PMDS.db.Entities.PflegePlanPDx newPflegePlanPDx = EFEntities.newPflegePlanPDx(db);
                PMDS.db.Entities.QuickFilter newQuickFilter = EFEntities.newQuickFilter(db);
                PMDS.db.Entities.QuickMeldung newQuickMeldung = EFEntities.newQuickMeldung(db);
                PMDS.db.Entities.rechNr newrechNr = EFEntities.newrechNr(db);
                PMDS.db.Entities.Recht newRecht = EFEntities.newRecht(db);
                PMDS.db.Entities.Rehabilitation newRehabilitation = EFEntities.newRehabilitation(db);
                PMDS.db.Entities.RezeptBestellungPos newRezeptBestellungPos = EFEntities.newRezeptBestellungPos(db);
                PMDS.db.Entities.RezeptEintrag newRezeptEintrag = EFEntities.newRezeptEintrag(db);
                PMDS.db.Entities.Sachwalter newSachwalter = EFEntities.newSachwalter(db);
                PMDS.db.Entities.SonderleistungsKatalog newSonderleistungsKatalog = EFEntities.newSonderleistungsKatalog(db);
                PMDS.db.Entities.SP newSP = EFEntities.newSP(db);
                PMDS.db.Entities.SPDynRep newSPDynRep = EFEntities.newSPDynRep(db);
                PMDS.db.Entities.SPPE newSPPE = EFEntities.newSPPE(db);
                PMDS.db.Entities.SPPOS newSPPOS = EFEntities.newSPPOS(db);
                PMDS.db.Entities.StandardProzeduren newStandardProzeduren = EFEntities.newStandardProzeduren(db);
                PMDS.db.Entities.Standardzeiten newStandardzeiten = EFEntities.newStandardzeiten(db);
                PMDS.db.Entities.Taschengeld newTaschengeld = EFEntities.newTaschengeld(db);
                PMDS.db.Entities.tbl_Nachricht newtbl_Nachricht = EFEntities.newtbl_Nachricht(db);
                PMDS.db.Entities.tblDokumente newtblDokumente = EFEntities.newtblDokumente(db);
                PMDS.db.Entities.tblDokumenteGelesen newtblDokumenteGelesen = EFEntities.newtblDokumenteGelesen(db);
                PMDS.db.Entities.tblDokumenteintrag newtblDokumenteintrag = EFEntities.newtblDokumenteintrag(db);
                PMDS.db.Entities.tblDokumenteneintragSchlagwörter newtblDokumenteneintragSchlagwörter = EFEntities.newtblDokumenteneintragSchlagwörter(db);
                PMDS.db.Entities.tblFach newtblFach = EFEntities.newtblFach(db);
                PMDS.db.Entities.tblFortbildungBenutzer newtblFortbildungBenutzer = EFEntities.newtblFortbildungBenutzer(db);
                PMDS.db.Entities.tblFortbildungen newtblFortbildungen = EFEntities.newtblFortbildungen(db);
                PMDS.db.Entities.tblObjekt newtblObjekt = EFEntities.newtblObjekt(db);
                PMDS.db.Entities.tblOrdner newtblOrdner = EFEntities.newtblOrdner(db);
                PMDS.db.Entities.tblParameter newtblParameter = EFEntities.newtblParameter(db);
                PMDS.db.Entities.tblPfad newtblPfad = EFEntities.newtblPfad(db);
                PMDS.db.Entities.tblProvKonfig newtblProvKonfig = EFEntities.newtblProvKonfig(db);
                PMDS.db.Entities.tblRechteOrdner newtblRechteOrdner = EFEntities.newtblRechteOrdner(db);
                PMDS.db.Entities.tblSchlagwörter newtblSchlagwörter = EFEntities.newtblSchlagwörter(db);
                PMDS.db.Entities.tblSchrank newtblSchrank = EFEntities.newtblSchrank(db);
                PMDS.db.Entities.tblSturzprotokoll newtblSturzprotokoll = EFEntities.newtblSturzprotokoll(db);
                PMDS.db.Entities.tblThemen newtblThemen = EFEntities.newtblThemen(db);
                PMDS.db.Entities.tblUIDefinitions newtblUIDefinitions = EFEntities.newtblUIDefinitions(db);
                PMDS.db.Entities.tblVeranstalter newtblVeranstalter = EFEntities.newtblVeranstalter(db);
                PMDS.db.Entities.Textbausteine newTextbausteine = EFEntities.newTextbausteine(db);
                PMDS.db.Entities.Unterbringung newUnterbringung = EFEntities.newUnterbringung(db);
                PMDS.db.Entities.UrlaubVerlauf newUrlaubVerlauf = EFEntities.newUrlaubVerlauf(db);
                PMDS.db.Entities.WundeKopf newWundeKopf = EFEntities.newWundeKopf(db);
                PMDS.db.Entities.WundePosBilder newWundePosBilder = EFEntities.newWundePosBilder(db);
                PMDS.db.Entities.WundeTherapie newWundeTherapie = EFEntities.newWundeTherapie(db);
                PMDS.db.Entities.Zeitbereich newZeitbereich = EFEntities.newZeitbereich(db);
                PMDS.db.Entities.ZeitbereichSerien newZeitbereichSerien = EFEntities.newZeitbereichSerien(db);
                PMDS.db.Entities.ZusatzEintrag newZusatzEintrag = EFEntities.newZusatzEintrag(db);
                PMDS.db.Entities.ZusatzGruppe newZusatzGruppe = EFEntities.newZusatzGruppe(db);
                PMDS.db.Entities.ZusatzGruppeEintrag newZusatzGruppeEintrag = EFEntities.newZusatzGruppeEintrag(db);
                PMDS.db.Entities.ZusatzWert newZusatzWert = EFEntities.newZusatzWert(db);


                bool bOK = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }


        public void loadTablesIntoRAM(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db,
                          bool checkEF)
        {
            string FctName = "EFEntities.loadTablesIntoRAM";
            int FctNr = 257000005;
            try
            {
                //EFEntities.Abteilung = from p in db.Abteilung.AsEnumerable() where p.ID == System.Guid.NewGuid() select p;
                //PMDS.db.Entities.Abteilung newAbteilung = new PMDS.db.Entities.Abteilung();


            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }
        public void efNewRow<T>(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db,
                                object itm, string TableName, IEnumerable<T> items,
                                System.Collections.Generic.Dictionary<string, string> lstColsChange = null)
        {
            string FctName = "EFEntities.efNewRow";
            int FctNr = 257000004;
            try
            {
                ERHelper ERHelper = new ERHelper();
                efTable efTable;
                bool bFound = lstTables.TryGetValue(TableName.Trim(), out efTable);
                if (!bFound)
                {
                    throw new Exception("efNewRow: Table '" + TableName.ToString() + "' not found!");
                }
                var properties = typeof(T).GetProperties();

                foreach (efColumn efColumn in efTable.lstCols)
                {
                    string ColNameTmp = efColumn.ColumnName.Trim();
                    if (lstColsChange != null)
                    {
                        string ColNameEF = "";
                        bool bFoundCol = lstColsChange.TryGetValue(ColNameTmp.Trim(), out ColNameEF);
                        if (bFoundCol)
                        {
                            ColNameTmp = ColNameEF.Trim();
                        }
                    }

                    if (efColumn.IsNullable)
                    {
                        ERHelper.setValueColumn6(null, itm, ColNameTmp.Trim(), properties);
                    }
                    else
                    {
                        if (efColumn.typeCol == eTypeCol.tGuid)
                        {
                            System.Guid gEmptyGuid = new Guid("00100000-0000-1000-1000-123456789123");
                            ERHelper.setValueColumn6(gEmptyGuid, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tString)
                        {
                            ERHelper.setValueColumn6("", itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tInteger)
                        {
                            ERHelper.setValueColumn6(0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDecimal1)
                        {
                            ERHelper.setValueColumn6((Decimal)0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tFloat)
                        {
                            ERHelper.setValueColumn6((float)0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tNumeric)
                        {
                            ERHelper.setValueColumn6(0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBoolean)
                        {
                            ERHelper.setValueColumn6(false, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDateTime)
                        {
                            DateTime dat1900 = new DateTime(1900, 1, 1, 0, 0, 0);
                            ERHelper.setValueColumn6(dat1900, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tImage)
                        {
                            Byte[] bytes = null;
                            ERHelper.setValueColumn6(bytes, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBinary)
                        {
                            Byte[] bytes = null;
                            ERHelper.setValueColumn6(bytes, itm, ColNameTmp.Trim(), properties);
                        }
                        else
                        {
                            throw new Exception("Type '' not possible for Field '" + ColNameTmp.Trim() + "' in Table '" + efTable.TableName.Trim() + "'!");
                        }
                    }
                }


                //string strSQl = "Select * from " + tablePair.Value.TableName.Trim() + " ";
                //DbParameter[] pars = new DbParameter[]
                //{
                //    //new SqlParameter {ParameterName="Eintrittsdatum", Value=dat, DbType= DbType.Date, SourceColumn= "@Eintrittsdatum"}
                //};
                //object t = tablePair.Value.EntityType.GetReferenceType();
                //Abteilung a = (Abteilung)t;
                ////db.Database.SqlQuery(t, strSQl, pars).AsQueryable();
                ////foreach (vBenutzer r in t)
                ////{
                ////    string xyxy = "";
                ////}

                //object oType = typeof(PMDS.db.Entities.Patient);
                //var infoPatient4 = typeof(PMDS.db.Entities.Patient).GetProperties();
                //var infoPatient = tPatientTmp1.GetType().GetProperties();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }
        public void efNewRowQS2<T>(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, QS2.db.Entities.ERModellQS2Entities db,
                        object itm, string TableName, IEnumerable<T> items,
                        System.Collections.Generic.Dictionary<string, string> lstColsChange = null)
        {
            string FctName = "EFEntities.efNewRow";
            int FctNr = 257000004;
            try
            {
                ERHelper ERHelper = new ERHelper();
                efTable efTable;
                bool bFound = lstTables.TryGetValue(TableName.Trim(), out efTable);
                if (!bFound)
                {
                    throw new Exception("efNewRow: Table '" + TableName.ToString() + "' not found!");
                }
                var properties = typeof(T).GetProperties();

                foreach (efColumn efColumn in efTable.lstCols)
                {
                    string ColNameTmp = efColumn.ColumnName.Trim();
                    if (lstColsChange != null)
                    {
                        string ColNameEF = "";
                        bool bFoundCol = lstColsChange.TryGetValue(ColNameTmp.Trim(), out ColNameEF);
                        if (bFoundCol)
                        {
                            ColNameTmp = ColNameEF.Trim();
                        }
                    }

                    if (efColumn.IsNullable)
                    {
                        ERHelper.setValueColumn6(null, itm, ColNameTmp.Trim(), properties);
                    }
                    else
                    {
                        if (efColumn.typeCol == eTypeCol.tGuid)
                        {
                            System.Guid gEmptyGuid = new Guid("00100000-0000-1000-1000-123456789123");
                            ERHelper.setValueColumn6(gEmptyGuid, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tString)
                        {
                            ERHelper.setValueColumn6("", itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tInteger)
                        {
                            ERHelper.setValueColumn6(0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDecimal1)
                        {
                            ERHelper.setValueColumn6((Decimal)0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tFloat)
                        {
                            ERHelper.setValueColumn6((float)0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tNumeric)
                        {
                            ERHelper.setValueColumn6(0, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBoolean)
                        {
                            ERHelper.setValueColumn6(false, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDateTime)
                        {
                            DateTime dat1900 = new DateTime(1900, 1, 1, 0, 0, 0);
                            ERHelper.setValueColumn6(dat1900, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tImage)
                        {
                            Byte[] bytes = null;
                            ERHelper.setValueColumn6(bytes, itm, ColNameTmp.Trim(), properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBinary)
                        {
                            Byte[] bytes = null;
                            ERHelper.setValueColumn6(bytes, itm, ColNameTmp.Trim(), properties);
                        }
                        else
                        {
                            throw new Exception("Type '' not possible for Field '" + ColNameTmp.Trim() + "' in Table '" + efTable.TableName.Trim() + "'!");
                        }
                    }
                }


                //string strSQl = "Select * from " + tablePair.Value.TableName.Trim() + " ";
                //DbParameter[] pars = new DbParameter[]
                //{
                //    //new SqlParameter {ParameterName="Eintrittsdatum", Value=dat, DbType= DbType.Date, SourceColumn= "@Eintrittsdatum"}
                //};
                //object t = tablePair.Value.EntityType.GetReferenceType();
                //Abteilung a = (Abteilung)t;
                ////db.Database.SqlQuery(t, strSQl, pars).AsQueryable();
                ////foreach (vBenutzer r in t)
                ////{
                ////    string xyxy = "";
                ////}

                //object oType = typeof(PMDS.db.Entities.Patient);
                //var infoPatient4 = typeof(PMDS.db.Entities.Patient).GetProperties();
                //var infoPatient = tPatientTmp1.GetType().GetProperties();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }


        public void testEFBusinessLayer(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db,
                                        bool checkEF)
        {
            string FctName = "EFEntities.testEFBusinessLayer";
            int FctNr = 257000006;
            try
            {




            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }









    }




    public class efTable
    {
        public string TableName = "";
        public System.Data.Entity.Core.Metadata.Edm.EntityType EntityType = null;
        public System.Collections.Generic.List<efColumn> lstCols = new List<efColumn>();
    }

    public class efColumn
    {
        public string ColumnName = "";
        public bool IsNullable = false;
        public EFEntities.eTypeCol typeCol;
        public System.Data.Entity.Core.Metadata.Edm.EdmProperty EdmProperty = null;
    }

}






//            Adresse
//            Aerzte
//            Anamnese_Krohwinkel
//            Anamnese_Orem
//            Anamnese_POP
//            Anmeldungen
//            Aufenthalt
//            AufenthaltPDx
//            AufenthaltVerlauf
//            AufenthaltZusatz
//            AuswahlListe
//            AuswahlListeGruppe
//            Bank
//            BarcodeQ
//            Belegung
//            Benutzer
//            BenutzerAbteilung
//            BenutzerBezug
//            BenutzerEinrichtung
//            BenutzerGruppe
//            Bereich
//            BereichBenutzer
//            billHeader
//            bills
//            bookings
//            DBLizenz
//            DBVersion
//            Dienstzeiten
//            Dokumente
//            Dokumente2
//            Einrichtung
//            Eintrag
//            EintragStandardprozeduren
//            EintragZusatz
//            Essen
//            Formular
//            FormularDaten
//            Gegenstaende
//            Gruppe
//            GruppenRecht
//            Info
//            Klinik
//            Kontakt
//            Kontaktperson
//            KontaktpersonStammdaten
//            Kostentraeger
//            Leistungskatalog
//            LeistungskatalogGueltig
//            LinkDokumente
//            manBuch
//            Massnahmenserien
//            Medikament
//            MedikationAbgabe
//            MedizinischeDaten
//            MedizinischeDatenLayout
//            MedizinischeTypen
//            Patient
//            PatientAbwesenheit
//            PatientAerzte
//            PatientEinkommen
//            PatientenBemerkung
//            PatientKostentraeger
//            PatientLeistungsplan
//            PatientPflegestufe
//            PatientSonderleistung
//            PatientTaschengeldKostentraeger
//            PDX
//            PDXAnamnese
//            PDXEintrag
//            PDXGruppe
//            PDXGruppeEintrag
//            PDXPflegemodelle
//            PflegeEintrag
//            Pflegegeldstufe
//            PflegegeldstufeGueltig
//            Pflegemodelle
//            PflegePlan
//            PflegePlanH
//            PflegePlanPDx
//            QuickFilter
//            QuickMeldung
//            rechNr
//            Recht
//            Rehabilitation
//            RezeptBestellungPos
//            RezeptEintrag
//            Sachwalter
//            SonderleistungsKatalog
//            SP
//            SPDynRep
//            SPPE
//            SPPOS
//            StandardProzeduren
//            Standardzeiten
//            Taschengeld
//            tbl_Nachricht
//            tblAufgabeArt
//            tblAufgaben
//            tblAufgabenAnhang
//            tblAufgabenTextHist
//            tblAufgabeZuordnung
//            tblCC
//            tblDokumente
//            tblDokumenteGelesen
//            tblDokumenteintrag
//            tblDokumenteneintragSchlagwörter
//            tblFach
//            tblFortbildungBenutzer
//            tblFortbildungen
//            tblObjekt
//            tblOrdner
//            tblParameter
//            tblPfad
//            tblProvKonfig
//            tblRechteOrdner
//            tblSchlagwörter
//            tblSchrank
//            tblSturzprotokoll
//            tblThemen
//            tblUIDefinitions
//            tblVeranstalter
//            Textbausteine
//            Unterbringung
//            UrlaubVerlauf
//            WundeKopf
//            WundePos
//            WundePosBilder
//            WundeTherapie
//            Zeitbereich
//            ZeitbereichSerien
//            ZusatzEintrag
//            ZusatzGruppe
//            ZusatzGruppeEintrag
//            ZusatzWert
