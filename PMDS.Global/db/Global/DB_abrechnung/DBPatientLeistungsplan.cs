using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Abrechnung.Global;
using RBU;



namespace PMDS.Calc.Admin.DB
{
	/// <summary>
	/// Summary description for DBPatientLeistungsplan.
	/// </summary>
	public class DBPatientLeistungsplan : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPatientLeistungsplan;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.ComponentModel.Container components = null;

		public DBPatientLeistungsplan(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBPatientLeistungsplan()
		{
			InitializeComponent();

		}

		public dsPatientLeistungsplan.PatientLeistungsplanDataTable Read(Guid IDPatient, System.Guid IDKlinik)
		{
			dsPatientLeistungsplan.PatientLeistungsplanDataTable dt = new dsPatientLeistungsplan.PatientLeistungsplanDataTable();
			daPatientLeistungsplan.SelectCommand.Parameters[0].Value = IDPatient;
            daPatientLeistungsplan.SelectCommand.Parameters[1].Value = IDKlinik;
			DataBase.Fill(daPatientLeistungsplan, dt);
			return dt;
		}

		public void Update(dsPatientLeistungsplan.PatientLeistungsplanDataTable dt)
		{
			DataBase.Update(daPatientLeistungsplan, dt);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientLeistungsplan));
            this.daPatientLeistungsplan = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientLeistungsplan
            // 
            this.daPatientLeistungsplan.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientLeistungsplan.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientLeistungsplan.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientLeistungsplan.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientLeistungsplan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDLeistungskatalog", "IDLeistungskatalog"),
                        new System.Data.Common.DataColumnMapping("ImVorausJN", "ImVorausJN"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("StornoJN", "StornoJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daPatientLeistungsplan.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientLeistungsplan] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDLeistungskatalog"),
            new System.Data.OleDb.OleDbParameter("ImVorausJN", System.Data.OleDb.OleDbType.Boolean, 0, "ImVorausJN"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("StornoJN", System.Data.OleDb.OleDbType.Boolean, 0, "StornoJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDLeistungskatalog"),
            new System.Data.OleDb.OleDbParameter("ImVorausJN", System.Data.OleDb.OleDbType.Boolean, 0, "ImVorausJN"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("StornoJN", System.Data.OleDb.OleDbType.Boolean, 0, "StornoJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

		}
		#endregion
	}
}
