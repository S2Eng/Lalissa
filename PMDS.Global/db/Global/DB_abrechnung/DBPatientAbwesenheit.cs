using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using RBU;
using PMDS.Abrechnung.Global;
using System.Data.OleDb;
using System.Data;

namespace PMDS.Calc.Admin.DB
{

	public class DBPatientAbwesenheit : System.ComponentModel.Component
    {
        public System.Data.OleDb.OleDbDataAdapter daPatientAbwesenheit;
		private System.Data.OleDb.OleDbConnection dbConn;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPatAbw‹berJN;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.ComponentModel.Container components = null;




        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientAbwesenheit));
            this.daPatientAbwesenheit = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatAbw‹berJN = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientAbwesenheit
            // 
            this.daPatientAbwesenheit.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientAbwesenheit.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientAbwesenheit.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientAbwesenheit.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientAbwesenheit", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("BetrifftPflegegeldJN", "BetrifftPflegegeldJN"),
                        new System.Data.Common.DataColumnMapping("abTagN", "abTagN"),
                        new System.Data.Common.DataColumnMapping("Grund", "Grund"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("ID‹ber", "ID‹ber"),
                        new System.Data.Common.DataColumnMapping("‹bersp", "‹bersp"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daPatientAbwesenheit.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientAbwesenheit] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.dbConn;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.dbConn;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("BetrifftPflegegeldJN", System.Data.OleDb.OleDbType.Boolean, 0, "BetrifftPflegegeldJN"),
            new System.Data.OleDb.OleDbParameter("abTagN", System.Data.OleDb.OleDbType.Integer, 0, "abTagN"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("ID‹ber", System.Data.OleDb.OleDbType.VarChar, 0, "ID‹ber"),
            new System.Data.OleDb.OleDbParameter("‹bersp", System.Data.OleDb.OleDbType.Boolean, 0, "‹bersp"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.dbConn;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.dbConn;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("BetrifftPflegegeldJN", System.Data.OleDb.OleDbType.Boolean, 0, "BetrifftPflegegeldJN"),
            new System.Data.OleDb.OleDbParameter("abTagN", System.Data.OleDb.OleDbType.Integer, 0, "abTagN"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("ID‹ber", System.Data.OleDb.OleDbType.VarChar, 0, "ID‹ber"),
            new System.Data.OleDb.OleDbParameter("‹bersp", System.Data.OleDb.OleDbType.Boolean, 0, "‹bersp"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatAbw‹berJN
            // 
            this.daPatAbw‹berJN.SelectCommand = this.oleDbCommand3;
            this.daPatAbw‹berJN.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientAbwesenheit", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("BetrifftPflegegeldJN", "BetrifftPflegegeldJN"),
                        new System.Data.Common.DataColumnMapping("abTagN", "abTagN"),
                        new System.Data.Common.DataColumnMapping("Grund", "Grund"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("ID‹ber", "ID‹ber"),
                        new System.Data.Common.DataColumnMapping("‹bersp", "‹bersp"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.dbConn;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID‹ber", System.Data.OleDb.OleDbType.Char, 50, "ID‹ber"),
            new System.Data.OleDb.OleDbParameter("‹bersp", System.Data.OleDb.OleDbType.Boolean, 1, "‹bersp")});

        }
        #endregion


		public DBPatientAbwesenheit()
		{
			InitializeComponent();
		}

		public dsPatientAbwesenheit.PatientAbwesenheitDataTable Read(Guid IDPatient, System.Guid IDKlinik)
		{
			dsPatientAbwesenheit.PatientAbwesenheitDataTable dt = new dsPatientAbwesenheit.PatientAbwesenheitDataTable();
			daPatientAbwesenheit.SelectCommand.Parameters[0].Value = IDPatient;
            daPatientAbwesenheit.SelectCommand.Parameters[1].Value = IDKlinik;
			DataBase.Fill(daPatientAbwesenheit, dt);
			return dt;
		}
        public dsPatientAbwesenheit.PatientAbwesenheitDataTable ReadOrderAsc(Guid IDPatient, System.Guid IDKlinik)
        {
            dsPatientAbwesenheit.PatientAbwesenheitDataTable dt = new dsPatientAbwesenheit.PatientAbwesenheitDataTable();
            daPatientAbwesenheit.SelectCommand.CommandText += " order by Von asc, Bis asc ";
            daPatientAbwesenheit.SelectCommand.Parameters[0].Value = IDPatient;
            daPatientAbwesenheit.SelectCommand.Parameters[1].Value = IDKlinik;
            DataBase.Fill(daPatientAbwesenheit, dt);
            return dt;
        }

        public dsPatientAbwesenheit.PatientAbwesenheitDataTable bereits‹bersp(string ID‹berspielt, System.Guid IDKlinik)
        {
            dsPatientAbwesenheit.PatientAbwesenheitDataTable dt = new dsPatientAbwesenheit.PatientAbwesenheitDataTable();
            this.daPatAbw‹berJN.SelectCommand.Parameters[0].Value = ID‹berspielt.ToString();
            this.daPatAbw‹berJN.SelectCommand.Parameters[1].Value = true;
            DataBase.Fill(daPatAbw‹berJN, dt);
            return dt;
            /*
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return false;
            */ 
        }
        public bool delete(string ID‹berspielt, System.Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = "delete  PatientAbwesenheit WHERE ID‹ber = ? and ‹bersp = 1 and IDKlinik =  '" + IDKlinik.ToString() + "' ";
            cmd.Parameters.Add("ID‹ber", System.Data.OleDb.OleDbType.VarChar, 50, "ID‹ber").Value = ID‹berspielt.ToLower();
            cmd.ExecuteNonQuery();
            return true;
        }

		public void Update(dsPatientAbwesenheit.PatientAbwesenheitDataTable dt)
		{
			DataBase.Update(daPatientAbwesenheit, dt);
		}

        public dsPatientAbwesenheit.PatientAbwesenheitRow New(dsPatientAbwesenheit.PatientAbwesenheitDataTable dt, Guid IDPatient, System.Guid  userID)
        {
            dsPatientAbwesenheit.PatientAbwesenheitRow r = dt.AddPatientAbwesenheitRow(Guid.NewGuid(), IDPatient, DateTime.Now.Date, DateTime.Now.Date, true, 4, "", DateTime.Now, userID , DateTime.Now, "", false, System.Guid.Empty);
            r.SetBisNull();
            r.SetAbgerechnetBisNull();
            r.abTagN = PMDS.Global.ENV.TageOhneKuerzungGrundleistung;
            r.SetIDKlinikNull();
            return r;
        }
        
	}
}
