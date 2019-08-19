using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Abrechnung.Global;
using RBU;



namespace PMDS.Calc.Admin.DB
{
	public class DBSonderleistungsKatalog : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daSonderleistungsKatalog;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daByID;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		
		private System.ComponentModel.Container components = null;






		public DBSonderleistungsKatalog(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBSonderleistungsKatalog()
		{
			InitializeComponent();

		}
		
		public dsSonderleistungsKatalog.SonderleistungsKatalogDataTable Read()
		{
			dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt = new dsSonderleistungsKatalog.SonderleistungsKatalogDataTable();
			DataBase.Fill(daSonderleistungsKatalog, dt);
			return dt;
		}

		public dsSonderleistungsKatalog.SonderleistungsKatalogRow ReadByID(Guid IDSonderleistungsKatalog)
		{
			dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt = new dsSonderleistungsKatalog.SonderleistungsKatalogDataTable();
			daByID.SelectCommand.Parameters[0].Value = IDSonderleistungsKatalog;
			DataBase.Fill(daByID, dt);
			return dt[0];
		}

		public void Update(dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt)
		{
			DataBase.Update(daSonderleistungsKatalog, dt);
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
            this.daSonderleistungsKatalog = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            // 
            // daSonderleistungsKatalog
            // 
            this.daSonderleistungsKatalog.DeleteCommand = this.oleDbDeleteCommand1;
            this.daSonderleistungsKatalog.InsertCommand = this.oleDbInsertCommand1;
            this.daSonderleistungsKatalog.SelectCommand = this.oleDbSelectCommand1;
            this.daSonderleistungsKatalog.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SonderleistungsKatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("Mwst", "Mwst"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("FIBU", "FIBU")})});
            this.daSonderleistungsKatalog.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [SonderleistungsKatalog] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [SonderleistungsKatalog] ([ID], [Bezeichnung], [Betrag], [Mwst], [IDK" +
    "linik], [FIBU]) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Mwst", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Mwst", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("FIBU", System.Data.OleDb.OleDbType.VarChar, 0, "FIBU")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, Bezeichnung, Betrag, Mwst, IDKlinik, FIBU\r\nFROM            Sond" +
    "erleistungsKatalog\r\nORDER BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [SonderleistungsKatalog] SET [ID] = ?, [Bezeichnung] = ?, [Betrag] = ?, [M" +
    "wst] = ?, [IDKlinik] = ?, [FIBU] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Mwst", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Mwst", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("FIBU", System.Data.OleDb.OleDbType.VarChar, 0, "FIBU"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daByID
            // 
            this.daByID.SelectCommand = this.oleDbCommand3;
            this.daByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SonderleistungsKatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("Mwst", "Mwst"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("FIBU", "FIBU")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Bezeichnung, Betrag, Mwst, IDKlinik, FIBU\r\nFROM            Sond" +
    "erleistungsKatalog\r\nWHERE        (ID = ?)\r\nORDER BY Bezeichnung";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});

		}
		#endregion
	}
}
