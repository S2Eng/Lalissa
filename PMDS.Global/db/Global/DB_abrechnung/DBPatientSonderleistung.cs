using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Abrechnung.Global;
using RBU;




namespace PMDS.Calc.Admin.DB
{

	public class DBPatientSonderleistung : System.ComponentModel.Component
	{


		private System.Data.OleDb.OleDbDataAdapter daPatientSonderleistung;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbConnection dbConn;
		
		private System.ComponentModel.Container components = null;
        


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientSonderleistung));
            this.daPatientSonderleistung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientSonderleistung
            // 
            this.daPatientSonderleistung.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientSonderleistung.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientSonderleistung.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientSonderleistung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientSonderleistung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Anzahl", "Anzahl"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("MWST", "MWST"),
                        new System.Data.Common.DataColumnMapping("Datum", "Datum"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetJN", "AbgerechnetJN"),
                        new System.Data.Common.DataColumnMapping("IDSonderleistungskatalog", "IDSonderleistungskatalog"),
                        new System.Data.Common.DataColumnMapping("Belegnummer", "Belegnummer"),
                        new System.Data.Common.DataColumnMapping("JahrAbrechnung", "JahrAbrechnung"),
                        new System.Data.Common.DataColumnMapping("MonatAbrechnung", "MonatAbrechnung"),
                        new System.Data.Common.DataColumnMapping("EinzelPreis", "EinzelPreis"),
                        new System.Data.Common.DataColumnMapping("datumVerrech", "datumVerrech"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daPatientSonderleistung.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientSonderleistung] WHERE (([ID] = ?))";
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
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Integer, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("MWST", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "MWST", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgerechnetJN"),
            new System.Data.OleDb.OleDbParameter("IDSonderleistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDSonderleistungskatalog"),
            new System.Data.OleDb.OleDbParameter("Belegnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Belegnummer"),
            new System.Data.OleDb.OleDbParameter("JahrAbrechnung", System.Data.OleDb.OleDbType.Integer, 0, "JahrAbrechnung"),
            new System.Data.OleDb.OleDbParameter("MonatAbrechnung", System.Data.OleDb.OleDbType.Integer, 0, "MonatAbrechnung"),
            new System.Data.OleDb.OleDbParameter("EinzelPreis", System.Data.OleDb.OleDbType.Double, 0, "EinzelPreis"),
            new System.Data.OleDb.OleDbParameter("datumVerrech", System.Data.OleDb.OleDbType.Date, 16, "datumVerrech"),
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
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Integer, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("MWST", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "MWST", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgerechnetJN"),
            new System.Data.OleDb.OleDbParameter("IDSonderleistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDSonderleistungskatalog"),
            new System.Data.OleDb.OleDbParameter("Belegnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Belegnummer"),
            new System.Data.OleDb.OleDbParameter("JahrAbrechnung", System.Data.OleDb.OleDbType.Integer, 0, "JahrAbrechnung"),
            new System.Data.OleDb.OleDbParameter("MonatAbrechnung", System.Data.OleDb.OleDbType.Integer, 0, "MonatAbrechnung"),
            new System.Data.OleDb.OleDbParameter("EinzelPreis", System.Data.OleDb.OleDbType.Double, 0, "EinzelPreis"),
            new System.Data.OleDb.OleDbParameter("datumVerrech", System.Data.OleDb.OleDbType.Date, 16, "datumVerrech"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }
        #endregion


		public DBPatientSonderleistung()
		{
			InitializeComponent();

		}

		public dsPatientSonderleistung.PatientSonderleistungDataTable Read(Guid IDPatient, Guid IDKlinik)
		{
			PMDS.Abrechnung.Global .dsPatientSonderleistung.PatientSonderleistungDataTable dt = new PMDS.Abrechnung.Global.dsPatientSonderleistung.PatientSonderleistungDataTable();
			daPatientSonderleistung.SelectCommand.Parameters[0].Value = IDPatient;
            daPatientSonderleistung.SelectCommand.Parameters[1].Value = IDKlinik;
			DataBase.Fill(daPatientSonderleistung, dt);
			return dt;
		}


		public void Update(dsPatientSonderleistung.PatientSonderleistungDataTable dt)
		{
			DataBase.Update(daPatientSonderleistung, dt);
		}
		
	}
}
