using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Data.Global;
using RBU;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using PMDS.Abrechnung.Global;
using PMDS.Data.Patient;
using PMDS.Global;
using PMDS.Global.db.Global.ds_abrechnung;
using System.Data;

namespace PMDS.DB.Global
{
    
	public class DBKostentraeger : System.ComponentModel.Component
	{
        public string seldaKostentraeger = "";



		private System.Data.OleDb.OleDbDataAdapter daKostentraeger;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand_kostID;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1_kostID;
        private System.Data.OleDb.OleDbConnection dbConn;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand_kostID;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand_kost;
        private System.Data.OleDb.OleDbDataAdapter daKostSammJN;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
		private System.ComponentModel.Container components = null;


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKostentraeger));
            this.daKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1_kostID = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand_kostID = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand_kostID = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand_kost = new System.Data.OleDb.OleDbCommand();
            this.daKostSammJN = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            // 
            // daKostentraeger
            // 
            this.daKostentraeger.DeleteCommand = this.oleDbDeleteCommand1_kostID;
            this.daKostentraeger.InsertCommand = this.oleDbInsertCommand_kostID;
            this.daKostentraeger.SelectCommand = this.oleDbSelectCommand_kostID;
            this.daKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Anrede", "Anrede"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("PLZ", "PLZ"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"),
                        new System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"),
                        new System.Data.Common.DataColumnMapping("IDKostentraegerSub", "IDKostentraegerSub"),
                        new System.Data.Common.DataColumnMapping("UIDNr", "UIDNr"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("SammelabrechnungJN", "SammelabrechnungJN"),
                        new System.Data.Common.DataColumnMapping("GSBG", "GSBG"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("Bank", "Bank"),
                        new System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"),
                        new System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("IDPatientIstZahler", "IDPatientIstZahler")})});
            this.daKostentraeger.UpdateCommand = this.oleDbUpdateCommand_kost;
            // 
            // oleDbDeleteCommand1_kostID
            // 
            this.oleDbDeleteCommand1_kostID.CommandText = "DELETE FROM [Kostentraeger] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1_kostID.Connection = this.dbConn;
            this.oleDbDeleteCommand1_kostID.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand_kostID
            // 
            this.oleDbInsertCommand_kostID.CommandText = resources.GetString("oleDbInsertCommand_kostID.CommandText");
            this.oleDbInsertCommand_kostID.Connection = this.dbConn;
            this.oleDbInsertCommand_kostID.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("PLZ", System.Data.OleDb.OleDbType.VarChar, 0, "PLZ"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Rechnungsanschrift", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnungsanschrift"),
            new System.Data.OleDb.OleDbParameter("Rechnungsempfaenger", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnungsempfaenger"),
            new System.Data.OleDb.OleDbParameter("IDKostentraegerSub", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraegerSub"),
            new System.Data.OleDb.OleDbParameter("UIDNr", System.Data.OleDb.OleDbType.VarChar, 0, "UIDNr"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("SammelabrechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SammelabrechnungJN"),
            new System.Data.OleDb.OleDbParameter("GSBG", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GSBG", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("ErlagscheingebuehrJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErlagscheingebuehrJN"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("Bank", System.Data.OleDb.OleDbType.VarChar, 0, "Bank"),
            new System.Data.OleDb.OleDbParameter("Kontonr", System.Data.OleDb.OleDbType.VarChar, 0, "Kontonr"),
            new System.Data.OleDb.OleDbParameter("BLZ", System.Data.OleDb.OleDbType.VarChar, 0, "BLZ"),
            new System.Data.OleDb.OleDbParameter("TaschengeldJN", System.Data.OleDb.OleDbType.Boolean, 0, "TaschengeldJN"),
            new System.Data.OleDb.OleDbParameter("PatientbezogenJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientbezogenJN"),
            new System.Data.OleDb.OleDbParameter("TransferleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TransferleistungJN"),
            new System.Data.OleDb.OleDbParameter("IDPatientIstZahler", System.Data.OleDb.OleDbType.Guid, 0, "IDPatientIstZahler")});
            // 
            // oleDbSelectCommand_kostID
            // 
            this.oleDbSelectCommand_kostID.CommandText = resources.GetString("oleDbSelectCommand_kostID.CommandText");
            this.oleDbSelectCommand_kostID.Connection = this.dbConn;
            // 
            // oleDbUpdateCommand_kost
            // 
            this.oleDbUpdateCommand_kost.CommandText = resources.GetString("oleDbUpdateCommand_kost.CommandText");
            this.oleDbUpdateCommand_kost.Connection = this.dbConn;
            this.oleDbUpdateCommand_kost.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("PLZ", System.Data.OleDb.OleDbType.VarChar, 0, "PLZ"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Rechnungsanschrift", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnungsanschrift"),
            new System.Data.OleDb.OleDbParameter("Rechnungsempfaenger", System.Data.OleDb.OleDbType.VarChar, 0, "Rechnungsempfaenger"),
            new System.Data.OleDb.OleDbParameter("IDKostentraegerSub", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraegerSub"),
            new System.Data.OleDb.OleDbParameter("UIDNr", System.Data.OleDb.OleDbType.VarChar, 0, "UIDNr"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("SammelabrechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SammelabrechnungJN"),
            new System.Data.OleDb.OleDbParameter("GSBG", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GSBG", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("ErlagscheingebuehrJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErlagscheingebuehrJN"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("Bank", System.Data.OleDb.OleDbType.VarChar, 0, "Bank"),
            new System.Data.OleDb.OleDbParameter("Kontonr", System.Data.OleDb.OleDbType.VarChar, 0, "Kontonr"),
            new System.Data.OleDb.OleDbParameter("BLZ", System.Data.OleDb.OleDbType.VarChar, 0, "BLZ"),
            new System.Data.OleDb.OleDbParameter("TaschengeldJN", System.Data.OleDb.OleDbType.Boolean, 0, "TaschengeldJN"),
            new System.Data.OleDb.OleDbParameter("PatientbezogenJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientbezogenJN"),
            new System.Data.OleDb.OleDbParameter("TransferleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TransferleistungJN"),
            new System.Data.OleDb.OleDbParameter("IDPatientIstZahler", System.Data.OleDb.OleDbType.Guid, 0, "IDPatientIstZahler"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daKostSammJN
            // 
            this.daKostSammJN.SelectCommand = this.oleDbCommand5;
            this.daKostSammJN.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SammelabrechnungJN", "SammelabrechnungJN")})});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "SELECT         SammelabrechnungJN \r\nFROM            Kostentraeger\r\nWHERE        (" +
    "ID = ?)";
            this.oleDbCommand5.Connection = this.dbConn;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});

        }
        #endregion
        

        //public DBKostentraeger(System.ComponentModel.IContainer container)
        //{
        //    container.Add(this);
        //    InitializeComponent();
        //}

		public DBKostentraeger()
		{
			InitializeComponent();

            this.seldaKostentraeger = this.daKostentraeger.SelectCommand.CommandText;
		}

        public dsKostentraeger.KostentraegerDataTable Read(bool klinik, System.Guid IDKlinik)
		{
            //OleDbDataAdapter daRead = new OleDbDataAdapter();
            //OleDbCommand cmdRead = new OleDbCommand();
            //cmdRead.Connection = RBU.DataBase.CONNECTION;
            //cmdRead.CommandTimeout = 0;
            //daRead.SelectCommand = cmdRead;

            string sWhere = "";
            if (!klinik)
            {
                sWhere = " ORDER BY Name ";
            }
            else
            {
                sWhere = " WHERE (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
            }
            this.daKostentraeger.SelectCommand.CommandText =  this.seldaKostentraeger +  sWhere;
			dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
			DataBase.Fill(daKostentraeger, dt);
			return dt;
		}
        public bool Read(bool klinik, System.Guid IDKlinik, ref dsKostentraeger ds)
        {
            string sWhere = "";
            if (!klinik)
            {
                sWhere = " ORDER BY Name ";
            }
            else
            {
                sWhere = " WHERE (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
            }
            this.daKostentraeger.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
            dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
            DataBase.Fill(daKostentraeger, ds.Kostentraeger);
            return true;
        }
        public dsKostentraeger.KostentraegerRow ReadByID(Guid IDKostentraeger)
        {
            dsKostentraeger.KostentraegerDataTable dt = GetKostentraeger(IDKostentraeger);
            return dt[0];
        }

        public dsKostentraeger.KostentraegerDataTable ReadForPatient(bool forPatientExclusive, bool klinik, System.Guid IDKlinik)
        {
            dsKostentraeger.KostentraegerDataTable dt = Read(klinik, IDKlinik);
            foreach (dsKostentraeger.KostentraegerRow r in dt)                  // Alle rausfiltern die nicht dem richtigen Patienten zugeordnet sind
            {
                if (!r.PatientbezogenJN)
                {
                    if (forPatientExclusive)
                        r.Delete();
                    else
                        continue;
                }
            }
            dt.AcceptChanges();                                                 // nur im DataTable festschreiben
            return dt;
        }

        public dsKostentraeger.KostentraegerDataTable GetAlgemeinKostentraeger(bool klinik, System.Guid IDKlinik)
        {
            OleDbDataAdapter daRead = new OleDbDataAdapter();
            OleDbCommand cmdRead = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmdRead.Connection = RBU.DataBase.CONNECTION;
            cmdRead.CommandTimeout = 0;
            daRead.SelectCommand = cmdRead;

            string sWhere = "";
            if (!klinik)
            {
                sWhere = " WHERE (PatientbezogenJN = 0) ORDER BY Name ";
            }
            else
            {
                sWhere = " WHERE (PatientbezogenJN = 0) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
            }
            daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
            dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
            DataBase.Fill(daRead, dt);
            return dt;
        }

        public dsKostentraeger.KostentraegerDataTable GetOnlyAlgemeinKostentraeger(bool klinik, System.Guid IDKlinik, bool bSupressFSWAsSubKostentraeger = false)
        {
            using (OleDbDataAdapter daRead = new OleDbDataAdapter())
            {
                OleDbCommand cmdRead = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdRead.Connection = RBU.DataBase.CONNECTION;
                cmdRead.CommandTimeout = 0;
                daRead.SelectCommand = cmdRead;
                string sWhere = " WHERE ";
                if (!klinik)
                {
                    sWhere += "(PatientbezogenJN = 0) AND (TransferleistungJN = 0) ";
                }
                else
                {
                    sWhere += "(PatientbezogenJN = 0) AND (TransferleistungJN = 0) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ";
                }

                if (bSupressFSWAsSubKostentraeger)
                {
                    sWhere += "and (IDKostentraegerSub IS NUll or  IDKostentraegerSub <> '" + ENV.FSW_IDIntern.ToString() + "') ";
                }

                sWhere += "ORDER BY Name ";


                daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
                using (dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable())
                {
                    DataBase.Fill(daRead, dt);
                    return dt;
                }
            }
        }
        public dsKostentraeger.KostentraegerDataTable GetPatientKostentraeger(bool klinik, System.Guid IDKlinik)
        {
            OleDbDataAdapter daRead = new OleDbDataAdapter();
            OleDbCommand cmdRead = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmdRead.Connection = RBU.DataBase.CONNECTION;
            cmdRead.CommandTimeout = 0;
            daRead.SelectCommand = cmdRead;

            string sWhere = "";
            if (!klinik)
            {
                sWhere = " WHERE (PatientbezogenJN = 1) ORDER BY Name ";
            }
            else
            {
                sWhere = " WHERE (PatientbezogenJN = 1) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
            }
            daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
            dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
            DataBase.Fill(daRead, dt);
            return dt;
        }
        public dsKostentraeger.KostentraegerDataTable GetAlgemeinPatientBetzogeneKostentraeger(bool klinik, System.Guid IDKlinik)
        {
            OleDbDataAdapter daRead = new OleDbDataAdapter();
            OleDbCommand cmdRead = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmdRead.Connection = RBU.DataBase.CONNECTION;
            cmdRead.CommandTimeout = 0;
            daRead.SelectCommand = cmdRead;

            string sWhere = "";
            if (!klinik)
            {
                sWhere = " WHERE (TransferleistungJN = 0) ORDER BY Name ";
            }
            else
            {
                sWhere = " WHERE (TransferleistungJN = 0) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
            }
            daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
            dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
            DataBase.Fill(daRead, dt);
            return dt;
        }
        public bool  sammelabrechnungJN(System.Guid IDKostenträger)
        {
            System.Data.DataTable  dt = new System.Data.DataTable();
            daKostSammJN.SelectCommand.Parameters[0].Value = IDKostenträger;
            DataBase.Fill(daKostSammJN, dt);
            if (dt.Rows.Count > 0)
                return (bool)dt.Rows[0]["SammelabrechnungJN"];
            else
                return false;
        }
       
        public dsKostentraeger.KostentraegerDataTable GetKostentraeger(Guid IDKostentraeger)
        {
            OleDbDataAdapter daRead = new OleDbDataAdapter();
            OleDbCommand cmdRead = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmdRead.Connection = RBU.DataBase.CONNECTION;
            cmdRead.CommandTimeout = 0;
            daRead.SelectCommand = cmdRead;
           
            string sWhere = " WHERE (ID = ?) ";
            dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
            daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
            daRead.SelectCommand.Parameters.Add("ID", OleDbType.Guid, 16, "ID").Value = IDKostentraeger;
            DataBase.Fill(daRead, dt);
            return dt;
        }

        public void Update(dsKostentraeger.KostentraegerDataTable dt)
        {
            DataBase.Update(daKostentraeger, dt);
        }

        public dsKostentraeger.KostentraegerDataTable GetTransferKostentraeger(bool klinik, System.Guid IDKlinik)
        {
            using (OleDbDataAdapter daRead = new OleDbDataAdapter())
            {
                OleDbCommand cmdRead = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdRead.Connection = RBU.DataBase.CONNECTION;
                cmdRead.CommandTimeout = 0;
                daRead.SelectCommand = cmdRead;

                string sWhere = "";
                if (!klinik)
                {
                    sWhere = " WHERE (TransferleistungJN = 1) ORDER BY Name ";
                }
                else
                {
                    sWhere = " WHERE (TransferleistungJN = 1) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
                }
                daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;

                dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
                DataBase.Fill(daRead, dt);
                return dt;
            }
        }

        public dsKostentraeger.KostentraegerDataTable GetPatientTransferKostentraeger(bool klinik, System.Guid IDKlinik)
        {
            using (OleDbDataAdapter daRead = new OleDbDataAdapter())
            {
                OleDbCommand cmdRead = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdRead.Connection = RBU.DataBase.CONNECTION;
                cmdRead.CommandTimeout = 0;
                daRead.SelectCommand = cmdRead;

                string sWhere = "";
                if (!klinik)
                {
                    sWhere = " where (PatientbezogenJN = 1) ";
                }
                else
                {
                    sWhere = " where (PatientbezogenJN = 1) and IDKlinik = '" + IDKlinik.ToString() + "' ";
                }
                daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere + " Union ";

                if (!klinik)
                {
                    sWhere = " where (TransferleistungJN = 1) ORDER BY Name ";
                }
                else
                {
                    sWhere = " where (TransferleistungJN = 1) and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ORDER BY Name ";
                }
                daRead.SelectCommand.CommandText += this.seldaKostentraeger + sWhere;

                dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable();
                DataBase.Fill(daRead, dt);
                return dt;
            }
        }

        public dsKostentraeger.KostentraegerDataTable GetTaschengeldKostentraeger(bool klinik, System.Guid IDKlinik, Guid IDKlient)
        {
            using (OleDbDataAdapter daRead = new OleDbDataAdapter())
            {
                OleDbCommand cmdRead = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdRead.Connection = RBU.DataBase.CONNECTION;
                cmdRead.CommandTimeout = 0;
                daRead.SelectCommand = cmdRead;

                string sWhere = " WHERE (TaschengeldJN = 1) ";

                if (klinik)
                {
                    sWhere += " and (IDKlinik = '" + IDKlinik.ToString() + "' or IDKlinik is null) ";
                }
                sWhere += " ORDER BY CASE WHEN IDPatient = '" + IDKlient.ToString() + "' THEN 1 ELSE 0 END DESC, Name, Vorname";

                daRead.SelectCommand.CommandText = this.seldaKostentraeger + sWhere;
                using (dsKostentraeger.KostentraegerDataTable dt = new dsKostentraeger.KostentraegerDataTable())
                {

                    DataBase.Fill(daRead, dt);

                    //dsKostentraeger.KostentraegerDataTable dtSort = new dsKostentraeger.KostentraegerDataTable();
                    //foreach (DataRow r in dt.AsEnumerable().OrderBy(o => o.Vorname)){
                    //    dtSort.ImportRow(r);
                    //}

                    return (dsKostentraeger.KostentraegerDataTable) dt;
                }
            }
        }
        
        public dsKostentraeger.KostentraegerDataTable GetKostentraeger(bool Allgemein, bool Patientbezogene, bool Transfer, bool klinik, System.Guid  IDKlinik)
        {
            dsKostentraeger.KostentraegerDataTable dt;

            if (Allgemein && !Patientbezogene && !Transfer) //Nur Allgemeine Kostenträger
            {
                dt = this.GetOnlyAlgemeinKostentraeger(klinik, IDKlinik);
            }
            else if (!Allgemein && Patientbezogene && !Transfer) //Nur Patientenbezogenekostenträger
            {
                dt = this.GetPatientKostentraeger(klinik, IDKlinik);
            }
            else if (!Allgemein && !Patientbezogene && Transfer) //Nur Transfer Kostenträger
            {
                dt = GetTransferKostentraeger(klinik, IDKlinik);
            }
            else if (Allgemein && Patientbezogene && !Transfer) //Nur Allgemeine und Patientenbezogene Kostenträger
            {
                dt = this.GetAlgemeinPatientBetzogeneKostentraeger(klinik, IDKlinik);
            }
            else if (Allgemein && !Patientbezogene && Transfer) //Nur Allgemeine und Transfer Kostenträger
            {
                dt = this.GetAlgemeinKostentraeger(klinik, IDKlinik);
            }
            else if (!Allgemein && Patientbezogene && Transfer) //Nur Patientenbezogene und Transfer Kostenträger
            {
                dt = GetPatientTransferKostentraeger(klinik, IDKlinik);
            }
            else if (Allgemein && Patientbezogene && Transfer)//Alle Kostenträger
            {
                dt = this.Read(klinik, IDKlinik);
            }
            else
                dt = new dsKostentraeger.KostentraegerDataTable();

            return dt;
        }

        public dsKostentraeger.KostentraegerRow New(dsKostentraeger.KostentraegerDataTable dt )
        {
            dsKostentraeger.KostentraegerRow r = dt.AddKostentraegerRow(Guid.NewGuid(), "", "", "", "", "", "", "", "", "", System.Guid.Empty, "", System.Guid.Empty, false, 0, 0, false, 0, "", "", "", false, false, false, System.Guid.Empty);
            r.SetIDKlinikNull();
            r.SetZahlartNull();
            r.SetIDPatientIstZahlerNull();
            r.SetIDKostentraegerSubNull();
            return r;
        }
        public dsKostentraeger.KostentraegerRow NewPatientBetzogeneKostentraeger(dsKostentraeger.KostentraegerDataTable dt)
        {
            dsKostentraeger.KostentraegerRow r = dt.AddKostentraegerRow(Guid.NewGuid(), "", "", "", "", "", "", "", "", "", System.Guid.Empty, "", System.Guid.Empty, false, 0, 0, false, 0, "", "", "", true, true, false, System.Guid.Empty);
            r.SetIDKlinikNull();
            r.SetZahlartNull();
            r.SetIDPatientIstZahlerNull();
            r.SetIDKostentraegerSubNull();
            return r;
        }

        public dsKostentraeger GetTransferPatientkostentraeger(Guid IDPatien, DateTime gueltigab, bool klinik, System.Guid IDKlinik)
        {
            DateTime gueltigBis = new DateTime(gueltigab.Year, gueltigab.Month, DateTime.DaysInMonth(gueltigab.Year, gueltigab.Month));
            return GetTransferPatientkostentraeger(IDPatien, gueltigab, gueltigBis, klinik, IDKlinik);
        }

        public dsKostentraeger GetTransferPatientkostentraeger(Guid IDPatien, DateTime gueltigab, DateTime gueltigBis, bool klinik, System.Guid IDKlinik)
        {
            dsKostentraeger ds = new dsKostentraeger();

            OleDbCommand cmd = new OleDbCommand();
            StringBuilder sb = new StringBuilder();

            sb.Append("select * from kostentraeger where id in (");
            sb.Append("	select kostentraeger.id FROM Kostentraeger INNER JOIN ");
            sb.Append(" PatientKostentraeger ON PatientKostentraeger.IDKostentraeger = Kostentraeger.ID ");
            sb.Append(" WHERE (PatientKostentraeger.enumKostentraegerart = ?) AND ");
            sb.Append("(PatientKostentraeger.IDPatient = ?) ");
            sb.Append(" AND ((PatientKostentraeger.GueltigBis is null and PatientKostentraeger.GueltigAb < ?) ");
            sb.Append(" or  not(PatientKostentraeger.GueltigAb < ? and PatientKostentraeger.GueltigBis < ? )");
            sb.Append(" or (PatientKostentraeger.GueltigAb > ? and PatientKostentraeger.GueltigBis > ?))) ");
            if (klinik)
            {
                sb.Append(" AND (kostentraeger.IDKlinik = '" + IDKlinik.ToString() + "' or kostentraeger.IDKlinik is null) ");
            }

            sb.Append(" ORDER BY Kostentraeger.Name");

            cmd.CommandText = sb.ToString();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.SelectCommand.Parameters.AddWithValue("enumKostentraegerart", (int)Kostentraegerart.Transferleistung);
            da.SelectCommand.Parameters.AddWithValue("IDPatien", IDPatien);

            OleDbParameter pGueltigAb = new OleDbParameter { ParameterName = "GueltigAb", OleDbType = OleDbType.Date, Value = gueltigab };
            da.SelectCommand.Parameters.Add(pGueltigAb);
            OleDbParameter pGueltigAb1 = new OleDbParameter { ParameterName = "GueltigAb1", OleDbType = OleDbType.Date, Value = gueltigab };
            da.SelectCommand.Parameters.Add(pGueltigAb1);
            OleDbParameter pGueltigBis = new OleDbParameter { ParameterName = "GueltigBis", OleDbType = OleDbType.Date, Value = gueltigab };
            da.SelectCommand.Parameters.Add(pGueltigBis);
            OleDbParameter pGueltigAb2 = new OleDbParameter { ParameterName = "GueltigAb2", OleDbType = OleDbType.Date, Value = gueltigBis };
            da.SelectCommand.Parameters.Add(pGueltigAb2);
            OleDbParameter pGueltigBis1 = new OleDbParameter { ParameterName = "GueltigBis1", OleDbType = OleDbType.Date, Value = gueltigab };
            da.SelectCommand.Parameters.Add(pGueltigBis1);

            DataBase.Fill(da, ds.Kostentraeger);
            return ds;
        }
	}

    public class KostentraegerInfo
    {
        private static DBKostentraeger db = new DBKostentraeger();
        private dsKostentraeger.KostentraegerRow _r;

        public KostentraegerInfo(Guid IDKostentraeger)
        {
            _r = db.ReadByID(IDKostentraeger);
        }

        public dsKostentraeger.KostentraegerRow INFO
        {
            get
            {
                return _r;
            }
        }

        public override string ToString()
        {
            return _r.Name;
        }
    }
}
