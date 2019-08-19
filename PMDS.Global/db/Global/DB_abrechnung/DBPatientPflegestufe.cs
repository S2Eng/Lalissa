using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using RBU;
using PMDS.Data.Global;
using PMDS.Abrechnung.Global;


namespace PMDS.Calc.Admin.DB
{
	/// <summary>
	/// Summary description for DBPatientPflegestufe.
	/// </summary>
	public class DBPatientPflegestufe : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPatientPflegestufe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daByPflegestufe;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daPatienPflegestufeByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
		private System.ComponentModel.Container components = null;

		public DBPatientPflegestufe(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBPatientPflegestufe()
		{
			InitializeComponent();

		}

		public dsPatientPflegestufe.PatientPflegestufeDataTable Read(Guid IDPatient)
		{
			dsPatientPflegestufe.PatientPflegestufeDataTable dt = new dsPatientPflegestufe.PatientPflegestufeDataTable();
			daPatientPflegestufe.SelectCommand.Parameters[0].Value = IDPatient;
			DataBase.Fill(daPatientPflegestufe, dt);
			return dt;
		}

        //Neu nach 24.10.2007 MDA
        public dsPatientPflegestufe.PatientPflegestufeDataTable ReadByPflegestufe(Guid IDPflegestufe)
        {
            dsPatientPflegestufe.PatientPflegestufeDataTable dt = new dsPatientPflegestufe.PatientPflegestufeDataTable();
            daByPflegestufe.SelectCommand.Parameters[0].Value = IDPflegestufe;
            DataBase.Fill(daByPflegestufe, dt);
            return dt;
        }

        //Neu nach 05.02.2008 MDA
        public dsPatientPflegestufe.PatientPflegestufeRow ReadByID(Guid IDPatientPflegestufe)
        {
            dsPatientPflegestufe.PatientPflegestufeDataTable dt = new dsPatientPflegestufe.PatientPflegestufeDataTable();
            daPatienPflegestufeByID.SelectCommand.Parameters[0].Value = IDPatientPflegestufe;
            DataBase.Fill(daPatienPflegestufeByID, dt);
            
            if (dt.Count == 0)
                return null;
            return dt[0];
        }

		public void Update(dsPatientPflegestufe.PatientPflegestufeDataTable dt)
		{
			DataBase.Update(daPatientPflegestufe, dt);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientPflegestufe));
            this.daPatientPflegestufe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daByPflegestufe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPatienPflegestufeByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientPflegestufe
            // 
            this.daPatientPflegestufe.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientPflegestufe.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientPflegestufe.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientPflegestufe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientPflegestufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufe", "IDPflegegeldstufe"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GutschriftProTagAbwesend", "GutschriftProTagAbwesend"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger")})});
            this.daPatientPflegestufe.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientPflegestufe] WHERE (([ID] = ?))";
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
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Double, 0, "BetragVerwendbar"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Double, 0, "BetragVerwendbar"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daByPflegestufe
            // 
            this.daByPflegestufe.SelectCommand = this.oleDbCommand3;
            this.daByPflegestufe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientPflegestufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufe", "IDPflegegeldstufe"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GutschriftProTagAbwesend", "GutschriftProTagAbwesend"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegegeldstufe")});
            // 
            // daPatienPflegestufeByID
            // 
            this.daPatienPflegestufeByID.DeleteCommand = this.oleDbCommand1;
            this.daPatienPflegestufeByID.InsertCommand = this.oleDbCommand2;
            this.daPatienPflegestufeByID.SelectCommand = this.oleDbCommand4;
            this.daPatienPflegestufeByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientPflegestufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufe", "IDPflegegeldstufe"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GutschriftProTagAbwesend", "GutschriftProTagAbwesend"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger")})});
            this.daPatienPflegestufeByID.UpdateCommand = this.oleDbCommand5;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PatientPflegestufe] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Double, 0, "BetragVerwendbar"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Double, 0, "BetragVerwendbar"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

		}
		#endregion
	}
}
