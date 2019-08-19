//----------------------------------------------------------------------------------------------
//  Erstellt am:	25.1.2006
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Global;using PMDS.Data.Patient;
using RBU;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DB Zugriffsklasse auf die Dienstzeiten
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBDienstZeiten : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daDienstZeitenAll;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbDataAdapter daDienstZeitenAbteilung;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbDataAdapter daDienstZeitenOne;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private System.ComponentModel.Container components = null;






		public DBDienstZeiten(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBDienstZeiten()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Dienstzeiten in der DB: Alle der generellen und alle der 
		/// übergebenen Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsDienstZeiten.DienstzeitenDataTable ReadAll(Guid IDAbteilung)
		{
			dsDienstZeiten.DienstzeitenDataTable dt = new dsDienstZeiten.DienstzeitenDataTable();
			daDienstZeitenAll.SelectCommand.Parameters[0].Value = IDAbteilung;
            daDienstZeitenAll.SelectCommand.Parameters[1].Value = IDAbteilung;
            DataBase.Fill(daDienstZeitenAll, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Dienstzeiten in der DB: alle der übergebenen Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsDienstZeiten.DienstzeitenDataTable ReadAllAbteilung(Guid IDAbteilung)
		{
			dsDienstZeiten.DienstzeitenDataTable dt = new dsDienstZeiten.DienstzeitenDataTable();
			daDienstZeitenAbteilung.SelectCommand.Parameters[0].Value = IDAbteilung;
			DataBase.Fill(daDienstZeitenAbteilung, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen einzelnen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsDienstZeiten.DienstzeitenDataTable Read(Guid ID)
		{
			dsDienstZeiten.DienstzeitenDataTable dt = new dsDienstZeiten.DienstzeitenDataTable();
			daDienstZeitenOne.SelectCommand.Parameters[0].Value = ID;
			DataBase.Fill(daDienstZeitenOne, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ab in die DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsDienstZeiten.DienstzeitenDataTable dt)
		{
			DataBase.Update(daDienstZeitenOne, dt); 
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBDienstZeiten));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daDienstZeitenAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daDienstZeitenAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daDienstZeitenOne = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // daDienstZeitenAll
            // 
            this.daDienstZeitenAll.SelectCommand = this.oleDbCommand3;
            this.daDienstZeitenAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Dienstzeiten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("VerwendenIn", "VerwendenIn")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daDienstZeitenAbteilung
            // 
            this.daDienstZeitenAbteilung.SelectCommand = this.oleDbCommand1;
            this.daDienstZeitenAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Dienstzeiten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("VerwendenIn", "VerwendenIn")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT        ID, IDAbteilung, Bezeichnung, Von, Bis, Reihenfolge, VerwendenIn\r\nF" +
    "ROM            Dienstzeiten\r\nWHERE        (IDAbteilung = ?)\r\nORDER BY Reihenfolg" +
    "e";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT        ID, IDAbteilung, Bezeichnung, Von, Bis, Reihenfolge, VerwendenIn\r\nF" +
    "ROM            Dienstzeiten WHERE        (ID = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [Dienstzeiten] ([ID], [IDAbteilung], [Bezeichnung], [Von], [Bis], [Re" +
    "ihenfolge], [VerwendenIn]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("VerwendenIn", System.Data.OleDb.OleDbType.VarChar, 0, "VerwendenIn")});
            // 
            // daDienstZeitenOne
            // 
            this.daDienstZeitenOne.DeleteCommand = this.oleDbDeleteCommand;
            this.daDienstZeitenOne.InsertCommand = this.oleDbInsertCommand2;
            this.daDienstZeitenOne.SelectCommand = this.oleDbSelectCommand2;
            this.daDienstZeitenOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Dienstzeiten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("VerwendenIn", "VerwendenIn")})});
            this.daDienstZeitenOne.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Dienstzeiten] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [Dienstzeiten] SET [ID] = ?, [IDAbteilung] = ?, [Bezeichnung] = ?, [Von] =" +
    " ?, [Bis] = ?, [Reihenfolge] = ?, [VerwendenIn] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("VerwendenIn", System.Data.OleDb.OleDbType.VarChar, 0, "VerwendenIn"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

		}
		#endregion
	}
}
