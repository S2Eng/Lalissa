using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Abrechnung.Global;
using RBU;


namespace PMDS.Calc.Admin.DB
{
	/// <summary>
	/// Summary description for DBLeistungskatalog.
	/// </summary>
	public class DBLeistungskatalog : System.ComponentModel.Component
	{
		private PMDS.Abrechnung.Global.dsLeistungskatalog dsLeistungskatalog1;
		private System.Data.OleDb.OleDbDataAdapter daLeistungskatalog;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daLeistungskatalogGueltig;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter daLeistungskatalogAll;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbDataAdapter daByID;
		private System.Data.OleDb.OleDbCommand oleDbCommand4;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DBLeistungskatalog(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBLeistungskatalog()
		{
			InitializeComponent();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Eine Bestimmte Leistungsgruppe lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog Read(int Leistungsgruppe)
		{
			dsLeistungskatalog ds = new dsLeistungskatalog();
			daLeistungskatalog.SelectCommand.Parameters[0].Value = Leistungsgruppe;
			DataBase.Fill(daLeistungskatalog, ds.Leistungskatalog);
			foreach(dsLeistungskatalog.LeistungskatalogRow r in ds.Leistungskatalog)
			{
				daLeistungskatalogGueltig.SelectCommand.Parameters[0].Value = r.ID;
				DataBase.Fill(daLeistungskatalogGueltig, ds.LeistungskatalogGueltig);
			}
			return ds;
		}
		
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Einen bestimmten Eintrag inkl. Childs lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog ReadByID(Guid IDLeistungskatalog)
		{
			dsLeistungskatalog ds = new dsLeistungskatalog();
			daByID.SelectCommand.Parameters[0].Value = IDLeistungskatalog;
			DataBase.Fill(daByID, ds.Leistungskatalog);
			foreach(dsLeistungskatalog.LeistungskatalogRow r in ds.Leistungskatalog)
			{
				daLeistungskatalogGueltig.SelectCommand.Parameters[0].Value = r.ID;
				DataBase.Fill(daLeistungskatalogGueltig, ds.LeistungskatalogGueltig);
			}
			return ds;
		}
        public dsLeistungskatalog ReadByIDDesc(Guid IDLeistungskatalog)
        {
            dsLeistungskatalog ds = new dsLeistungskatalog();
            daByID.SelectCommand.Parameters[0].Value = IDLeistungskatalog;
            DataBase.Fill(daByID, ds.Leistungskatalog);
            foreach (dsLeistungskatalog.LeistungskatalogRow r in ds.Leistungskatalog)
            {
                daLeistungskatalogGueltig.SelectCommand.CommandText += " order by GueltigAb desc ";
                daLeistungskatalogGueltig.SelectCommand.Parameters[0].Value = r.ID;
                DataBase.Fill(daLeistungskatalogGueltig, ds.LeistungskatalogGueltig);
            }
            return ds;
        }
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog.LeistungskatalogDataTable ReadAll()
		{
			dsLeistungskatalog.LeistungskatalogDataTable dt = new dsLeistungskatalog.LeistungskatalogDataTable();
			DataBase.Fill(daLeistungskatalogAll, dt);
			return dt;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Änderungen in die DB
		/// </summary>
		//--------------------------------------------------------------------------------
		public void Update(dsLeistungskatalog ds, bool bDeleteOnly)
		{
			if(bDeleteOnly) 
			{
				DataBase.Update(daLeistungskatalogGueltig, ds.LeistungskatalogGueltig);
				DataBase.Update(daLeistungskatalog, ds.Leistungskatalog);
			}
			else 
			{
				DataBase.Update(daLeistungskatalog, ds.Leistungskatalog);
				DataBase.Update(daLeistungskatalogGueltig, ds.LeistungskatalogGueltig);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBLeistungskatalog));
            this.dsLeistungskatalog1 = new PMDS.Abrechnung.Global.dsLeistungskatalog();
            this.daLeistungskatalog = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.daLeistungskatalogGueltig = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daLeistungskatalogAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsLeistungskatalog1)).BeginInit();
            // 
            // dsLeistungskatalog1
            // 
            this.dsLeistungskatalog1.DataSetName = "dsLeistungskatalog";
            this.dsLeistungskatalog1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsLeistungskatalog1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daLeistungskatalog
            // 
            this.daLeistungskatalog.DeleteCommand = this.oleDbDeleteCommand1;
            this.daLeistungskatalog.InsertCommand = this.oleDbInsertCommand1;
            this.daLeistungskatalog.SelectCommand = this.oleDbSelectCommand1;
            this.daLeistungskatalog.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Leistungskatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Barcode", "Barcode"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("enumLeistungsgruppe", "enumLeistungsgruppe"),
                        new System.Data.Common.DataColumnMapping("DivisorFuerMonatsleistung", "DivisorFuerMonatsleistung"),
                        new System.Data.Common.DataColumnMapping("MonatsleistungJN", "MonatsleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaeglichJN", "TaeglichJN"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("VerrechnungImVorrausJN", "VerrechnungImVorrausJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daLeistungskatalog.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Leistungskatalog] WHERE (([ID] = ?))";
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
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Barcode", System.Data.OleDb.OleDbType.VarChar, 0, "Barcode"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("enumLeistungsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "enumLeistungsgruppe"),
            new System.Data.OleDb.OleDbParameter("DivisorFuerMonatsleistung", System.Data.OleDb.OleDbType.Integer, 0, "DivisorFuerMonatsleistung"),
            new System.Data.OleDb.OleDbParameter("MonatsleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MonatsleistungJN"),
            new System.Data.OleDb.OleDbParameter("TaeglichJN", System.Data.OleDb.OleDbType.Boolean, 0, "TaeglichJN"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("VerrechnungImVorrausJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerrechnungImVorrausJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("enumLeistungsgruppe", System.Data.OleDb.OleDbType.Integer, 4, "enumLeistungsgruppe")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Barcode", System.Data.OleDb.OleDbType.VarChar, 0, "Barcode"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("enumLeistungsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "enumLeistungsgruppe"),
            new System.Data.OleDb.OleDbParameter("DivisorFuerMonatsleistung", System.Data.OleDb.OleDbType.Integer, 0, "DivisorFuerMonatsleistung"),
            new System.Data.OleDb.OleDbParameter("MonatsleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MonatsleistungJN"),
            new System.Data.OleDb.OleDbParameter("TaeglichJN", System.Data.OleDb.OleDbType.Boolean, 0, "TaeglichJN"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("VerrechnungImVorrausJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerrechnungImVorrausJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection2
            // 
            this.oleDbConnection2.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daLeistungskatalogGueltig
            // 
            this.daLeistungskatalogGueltig.DeleteCommand = this.oleDbDeleteCommand2;
            this.daLeistungskatalogGueltig.InsertCommand = this.oleDbInsertCommand2;
            this.daLeistungskatalogGueltig.SelectCommand = this.oleDbSelectCommand2;
            this.daLeistungskatalogGueltig.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "LeistungskatalogGueltig", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDLeistungskatalog", "IDLeistungskatalog"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("MWST", "MWST"),
                        new System.Data.Common.DataColumnMapping("GutschriftProTagAbwesend", "GutschriftProTagAbwesend"),
                        new System.Data.Common.DataColumnMapping("TagsatzberechnungJN", "TagsatzberechnungJN")})});
            this.daLeistungskatalogGueltig.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [LeistungskatalogGueltig] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [LeistungskatalogGueltig] ([ID], [IDLeistungskatalog], [GueltigAb], [" +
    "Betrag], [MWST], [GutschriftProTagAbwesend], [TagsatzberechnungJN]) VALUES (?, ?" +
    ", ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDLeistungskatalog"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("MWST", System.Data.OleDb.OleDbType.Double, 0, "MWST"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("TagsatzberechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TagsatzberechnungJN")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     ID, IDLeistungskatalog, GueltigAb, Betrag, MWST, GutschriftProTagAbwes" +
    "end, TagsatzberechnungJN\r\nFROM         LeistungskatalogGueltig\r\nWHERE     (IDLei" +
    "stungskatalog = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 16, "IDLeistungskatalog")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE [LeistungskatalogGueltig] SET [ID] = ?, [IDLeistungskatalog] = ?, [Gueltig" +
    "Ab] = ?, [Betrag] = ?, [MWST] = ?, [GutschriftProTagAbwesend] = ?, [Tagsatzberec" +
    "hnungJN] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 0, "IDLeistungskatalog"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("MWST", System.Data.OleDb.OleDbType.Double, 0, "MWST"),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Double, 0, "GutschriftProTagAbwesend"),
            new System.Data.OleDb.OleDbParameter("TagsatzberechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TagsatzberechnungJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daLeistungskatalogAll
            // 
            this.daLeistungskatalogAll.SelectCommand = this.oleDbCommand3;
            this.daLeistungskatalogAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Leistungskatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Barcode", "Barcode"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("enumLeistungsgruppe", "enumLeistungsgruppe"),
                        new System.Data.Common.DataColumnMapping("DivisorFuerMonatsleistung", "DivisorFuerMonatsleistung"),
                        new System.Data.Common.DataColumnMapping("MonatsleistungJN", "MonatsleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaeglichJN", "TaeglichJN"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("VerrechnungImVorrausJN", "VerrechnungImVorrausJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // daByID
            // 
            this.daByID.SelectCommand = this.oleDbCommand4;
            this.daByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Leistungskatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Barcode", "Barcode"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("enumLeistungsgruppe", "enumLeistungsgruppe"),
                        new System.Data.Common.DataColumnMapping("DivisorFuerMonatsleistung", "DivisorFuerMonatsleistung"),
                        new System.Data.Common.DataColumnMapping("MonatsleistungJN", "MonatsleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaeglichJN", "TaeglichJN"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("VerrechnungImVorrausJN", "VerrechnungImVorrausJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            ((System.ComponentModel.ISupportInitialize)(this.dsLeistungskatalog1)).EndInit();

		}
		#endregion
	}
}
