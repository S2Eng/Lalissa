using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Abrechnung.Global;
using RBU;
using PMDS.Abrechnung.Global;


namespace PMDS.Calc.Admin.DB
{
	/// <summary>
	/// Summary description for DBPflegegeldstufe.
	/// </summary>
	public class DBPflegegeldstufe : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPflegegeldstufe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daPflegegeldStufeByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daPflgestufeGueltig;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DBPflegegeldstufe(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBPflegegeldstufe()
		{
			InitializeComponent();

		}

        public dsPflegegeldstufe ReadByID(Guid IDPflegegeldstufe)
        {
            dsPflegegeldstufe ds = new PMDS.Abrechnung.Global.dsPflegegeldstufe();
            daPflegegeldStufeByID.SelectCommand.Parameters[0].Value = IDPflegegeldstufe;
            DataBase.Fill(daPflegegeldStufeByID, ds.Pflegegeldstufe);

            foreach (dsPflegegeldstufe.PflegegeldstufeRow r in ds.Pflegegeldstufe)
            {
                daPflgestufeGueltig.SelectCommand.Parameters[0].Value = r.ID;
                DataBase.Fill(daPflgestufeGueltig, ds.PflegegeldstufeGueltig);
            }

            return ds;
        }

        public dsPflegegeldstufe Read()
        {
            dsPflegegeldstufe ds = new PMDS.Abrechnung.Global.dsPflegegeldstufe();
            DataBase.Fill(daPflegegeldstufe, ds.Pflegegeldstufe);

            foreach (dsPflegegeldstufe.PflegegeldstufeRow r in ds.Pflegegeldstufe)
            {
                daPflgestufeGueltig.SelectCommand.Parameters[0].Value = r.ID;
                DataBase.Fill(daPflgestufeGueltig, ds.PflegegeldstufeGueltig);
            }
            return ds;
        }

        public void Update(dsPflegegeldstufe ds, bool bDeleteOnly)
		{
			if(bDeleteOnly) 
			{
                DataBase.Update(daPflgestufeGueltig, ds.PflegegeldstufeGueltig);
                DataBase.Update(daPflegegeldstufe, ds.Pflegegeldstufe);
			}
			else 
			{
                DataBase.Update(daPflegegeldstufe, ds.Pflegegeldstufe);
                DataBase.Update(daPflgestufeGueltig, ds.PflegegeldstufeGueltig);
			}
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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
            this.daPflegegeldstufe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegegeldStufeByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPflgestufeGueltig = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            // 
            // daPflegegeldstufe
            // 
            this.daPflegegeldstufe.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegegeldstufe.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegegeldstufe.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegegeldstufe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pflegegeldstufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("StufeNr", "StufeNr"),
                        new System.Data.Common.DataColumnMapping("Divisor", "Divisor"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daPflegegeldstufe.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Pflegegeldstufe] WHERE (([ID] = ?))";
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
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Pflegegeldstufe] ([ID], [StufeNr], [Divisor], [Bezeichnung]) VALUES " +
                "(?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, StufeNr, Divisor, Bezeichnung\r\nFROM         Pflegegeldstufe\r\nORDER" +
                " BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Pflegegeldstufe] SET [ID] = ?, [StufeNr] = ?, [Divisor] = ?, [Bezeichnung" +
                "] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegegeldStufeByID
            // 
            this.daPflegegeldStufeByID.DeleteCommand = this.oleDbDeleteCommand;
            this.daPflegegeldStufeByID.InsertCommand = this.oleDbInsertCommand;
            this.daPflegegeldStufeByID.SelectCommand = this.oleDbCommand3;
            this.daPflegegeldStufeByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pflegegeldstufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("StufeNr", "StufeNr"),
                        new System.Data.Common.DataColumnMapping("Divisor", "Divisor"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daPflegegeldStufeByID.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, StufeNr, Divisor, Bezeichnung\r\nFROM         Pflegegeldstufe\r\nWHERE" +
                "     (ID = ?)";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daPflgestufeGueltig
            // 
            this.daPflgestufeGueltig.DeleteCommand = this.oleDbCommand1;
            this.daPflgestufeGueltig.InsertCommand = this.oleDbCommand2;
            this.daPflgestufeGueltig.SelectCommand = this.oleDbCommand4;
            this.daPflgestufeGueltig.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegegeldstufeGueltig", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufe", "IDPflegegeldstufe"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag")})});
            this.daPflgestufeGueltig.UpdateCommand = this.oleDbCommand5;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PflegegeldstufeGueltig] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [PflegegeldstufeGueltig] ([ID], [IDPflegegeldstufe], [GueltigAb], [Be" +
                "trag]) VALUES (?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "SELECT     ID, IDPflegegeldstufe, GueltigAb, Betrag\r\nFROM         Pflegegeldstufe" +
                "Gueltig where IDPflegegeldstufe = ?";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegegeldstufe")});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "UPDATE [PflegegeldstufeGueltig] SET [ID] = ?, [IDPflegegeldstufe] = ?, [GueltigAb" +
                "] = ?, [Betrag] = ? WHERE (([ID] = ?))";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO [Pflegegeldstufe] ([ID], [StufeNr], [Divisor], [Bezeichnung]) VALUES " +
                "(?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [Pflegegeldstufe] SET [ID] = ?, [StufeNr] = ?, [Divisor] = ?, [Bezeichnung" +
                "] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Pflegegeldstufe] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

		}
		#endregion
	}
}
