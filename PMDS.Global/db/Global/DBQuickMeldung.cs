//----------------------------------------------------------------------------------------------
//  Erstellt am:	25.10.2005
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DB Zugriffsklasse auf die Formularverwaltung
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBQuickMeldung : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daQuickMeldungAll;
		private System.Data.OleDb.OleDbDataAdapter daQuickMeldungOne;
        private dsQuickMeldung dsQuickMeldung1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter daQuickMeldungAbteilung;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbCommand oleDbCommand4;
		private System.ComponentModel.Container components = null;

		public DBQuickMeldung(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBQuickMeldung()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle QuickMeldungen in der DB: Alle der generellen und alle der 
		/// übergebenen Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsQuickMeldung.QuickMeldungDataTable ReadAll(Guid IDAbteilung)
		{
			dsQuickMeldung.QuickMeldungDataTable dt = new dsQuickMeldung.QuickMeldungDataTable();
			daQuickMeldungAll.SelectCommand.Parameters[0].Value = IDAbteilung;
			DataBase.Fill(daQuickMeldungAll, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle QuickMeldungen in der DB: alle der übergebenen Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsQuickMeldung.QuickMeldungDataTable ReadAllAbteilung(Guid IDAbteilung)
		{
			dsQuickMeldung.QuickMeldungDataTable dt = new dsQuickMeldung.QuickMeldungDataTable();
			daQuickMeldungAbteilung.SelectCommand.Parameters[0].Value = IDAbteilung;
			DataBase.Fill(daQuickMeldungAbteilung, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen einzelnen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsQuickMeldung.QuickMeldungDataTable Read(Guid ID)
		{
			dsQuickMeldung.QuickMeldungDataTable dt = new dsQuickMeldung.QuickMeldungDataTable();
			daQuickMeldungOne.SelectCommand.Parameters[0].Value = ID;
			DataBase.Fill(daQuickMeldungOne, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ab in die DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsQuickMeldung.QuickMeldungDataTable dt)
		{
			DataBase.Update(daQuickMeldungAll, dt); 
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
            this.daQuickMeldungAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daQuickMeldungOne = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsQuickMeldung1 = new dsQuickMeldung();
            this.daQuickMeldungAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsQuickMeldung1)).BeginInit();
            // 
            // daQuickMeldungAll
            // 
            this.daQuickMeldungAll.DeleteCommand = this.oleDbDeleteCommand1;
            this.daQuickMeldungAll.InsertCommand = this.oleDbInsertCommand1;
            this.daQuickMeldungAll.SelectCommand = this.oleDbSelectCommand1;
            this.daQuickMeldungAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickMeldung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daQuickMeldungAll.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [QuickMeldung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [QuickMeldung] ([ID], [Bezeichnung], [IDEintrag], [IDAbteilung]) VALU" +
    "ES (?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, Bezeichnung, IDEintrag, IDAbteilung\r\nFROM            QuickMeldu" +
    "ng\r\nWHERE        (IDAbteilung = ?)\r\nORDER BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [QuickMeldung] SET [ID] = ?, [Bezeichnung] = ?, [IDEintrag] = ?, [IDAbteil" +
    "ung] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daQuickMeldungOne
            // 
            this.daQuickMeldungOne.DeleteCommand = this.oleDbDeleteCommand2;
            this.daQuickMeldungOne.InsertCommand = this.oleDbInsertCommand2;
            this.daQuickMeldungOne.SelectCommand = this.oleDbSelectCommand2;
            this.daQuickMeldungOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickMeldung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daQuickMeldungOne.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM QuickMeldung WHERE (ID = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO QuickMeldung(ID, Bezeichnung, IDEintrag, IDAbteilung) VALUES (?, ?, ?" +
    ", ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 50, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ID, Bezeichnung, IDEintrag, IDAbteilung FROM QuickMeldung WHERE (ID = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE QuickMeldung SET ID = ?, Bezeichnung = ?, IDEintrag = ?, IDAbteilung = ? W" +
    "HERE (ID = ?)";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 50, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsQuickMeldung1
            // 
            this.dsQuickMeldung1.DataSetName = "dsQuickMeldung";
            this.dsQuickMeldung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsQuickMeldung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daQuickMeldungAbteilung
            // 
            this.daQuickMeldungAbteilung.DeleteCommand = this.oleDbCommand1;
            this.daQuickMeldungAbteilung.InsertCommand = this.oleDbCommand2;
            this.daQuickMeldungAbteilung.SelectCommand = this.oleDbCommand3;
            this.daQuickMeldungAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickMeldung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daQuickMeldungAbteilung.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM QuickMeldung WHERE (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO QuickMeldung(ID, Bezeichnung, IDEintrag, IDAbteilung) VALUES (?, ?, ?" +
    ", ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 50, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT ID, Bezeichnung, IDEintrag, IDAbteilung FROM QuickMeldung WHERE (IDAbteilu" +
    "ng = ?) ORDER BY Bezeichnung";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE QuickMeldung SET ID = ?, Bezeichnung = ?, IDEintrag = ?, IDAbteilung = ? W" +
    "HERE (ID = ?)";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 50, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsQuickMeldung1)).EndInit();

		}
		#endregion
	}
}
