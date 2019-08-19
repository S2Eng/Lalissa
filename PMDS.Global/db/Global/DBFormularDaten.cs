//----------------------------------------------------------------------------------------------
//  Erstellt am:	27.10.2005
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
	/// DB Zugriffsklasse auf die Formulardaten
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBFormularData : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daFormularDatenAll;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsFormularDaten dsFormularDaten1;
		private System.Data.OleDb.OleDbDataAdapter daFormularDatenForm;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbCommand oleDbCommand4;
		private System.ComponentModel.Container components = null;

		public DBFormularData(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBFormularData()
		{
			InitializeComponent();
		}

		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Formularedaten zur Referenz in der DB
		/// </summary>
		//----------------------------------------------------------------------------
		public dsFormularDaten.FormularDatenDataTable Read(Guid IDRef) 
		{
			dsFormularDaten.FormularDatenDataTable dt = new dsFormularDaten.FormularDatenDataTable();
			daFormularDatenAll.SelectCommand.Parameters[0].Value = IDRef;
			DataBase.Fill(daFormularDatenAll, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Formularedaten zur Referenz in der DB gefiltert aus ein 
		/// bestimmtes Formulat
		/// </summary>
		//----------------------------------------------------------------------------
		public dsFormularDaten.FormularDatenDataTable Read(Guid IDRef, string Formularname) 
		{
			dsFormularDaten.FormularDatenDataTable dt = new dsFormularDaten.FormularDatenDataTable();
			daFormularDatenForm.SelectCommand.Parameters[0].Value = IDRef;
			daFormularDatenForm.SelectCommand.Parameters[1].Value = Formularname;
			DataBase.Fill(daFormularDatenForm, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Schreibt die Daten in die Datenbank
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsFormularDaten.FormularDatenDataTable dt)
		{
			DataBase.Update(daFormularDatenAll, dt);
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
            this.daFormularDatenAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsFormularDaten1 = new dsFormularDaten();
            this.daFormularDatenForm = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularDaten1)).BeginInit();
            // 
            // daFormularDatenAll
            // 
            this.daFormularDatenAll.DeleteCommand = this.oleDbDeleteCommand1;
            this.daFormularDatenAll.InsertCommand = this.oleDbInsertCommand1;
            this.daFormularDatenAll.SelectCommand = this.oleDbSelectCommand1;
            this.daFormularDatenAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "FormularDaten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDREF", "IDREF"),
                        new System.Data.Common.DataColumnMapping("FormularName", "FormularName"),
                        new System.Data.Common.DataColumnMapping("BLOP", "BLOP"),
                        new System.Data.Common.DataColumnMapping("Datumerstellt", "Datumerstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert")})});
            this.daFormularDatenAll.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM FormularDaten WHERE (ID = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO FormularDaten(ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeae" +
    "ndert, IDBenutzer_Erstellt, IDBenutzer_Geaendert) VALUES (?, ?, ?, ?, ?, ?, ?, ?" +
    ")";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF"),
            new System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 255, "FormularName"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.VarChar, 2147483647, "BLOP"),
            new System.Data.OleDb.OleDbParameter("Datumerstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datumerstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeaendert, IDBenutzer_E" +
    "rstellt, IDBenutzer_Geaendert FROM FormularDaten WHERE (IDREF = ?) ORDER BY Datu" +
    "merstellt DESC";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE FormularDaten SET ID = ?, IDREF = ?, FormularName = ?, BLOP = ?, Datumerst" +
    "ellt = ?, DatumGeaendert = ?, IDBenutzer_Erstellt = ?, IDBenutzer_Geaendert = ? " +
    "WHERE (ID = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF"),
            new System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 255, "FormularName"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.VarChar, 2147483647, "BLOP"),
            new System.Data.OleDb.OleDbParameter("Datumerstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datumerstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsFormularDaten1
            // 
            this.dsFormularDaten1.DataSetName = "dsFormularDaten";
            this.dsFormularDaten1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsFormularDaten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daFormularDatenForm
            // 
            this.daFormularDatenForm.DeleteCommand = this.oleDbCommand1;
            this.daFormularDatenForm.InsertCommand = this.oleDbCommand2;
            this.daFormularDatenForm.SelectCommand = this.oleDbCommand3;
            this.daFormularDatenForm.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "FormularDaten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDREF", "IDREF"),
                        new System.Data.Common.DataColumnMapping("FormularName", "FormularName"),
                        new System.Data.Common.DataColumnMapping("BLOP", "BLOP"),
                        new System.Data.Common.DataColumnMapping("Datumerstellt", "Datumerstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert")})});
            this.daFormularDatenForm.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM FormularDaten WHERE (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO FormularDaten(ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeae" +
    "ndert, IDBenutzer_Erstellt, IDBenutzer_Geaendert) VALUES (?, ?, ?, ?, ?, ?, ?, ?" +
    ")";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF"),
            new System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 255, "FormularName"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.VarChar, 2147483647, "BLOP"),
            new System.Data.OleDb.OleDbParameter("Datumerstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datumerstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT ID, IDREF, FormularName, BLOP, Datumerstellt, DatumGeaendert, IDBenutzer_E" +
    "rstellt, IDBenutzer_Geaendert FROM FormularDaten WHERE (IDREF = ?) AND (Formular" +
    "Name = ?) ORDER BY Datumerstellt DESC";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF"),
            new System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 255, "FormularName")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE FormularDaten SET ID = ?, IDREF = ?, FormularName = ?, BLOP = ?, Datumerst" +
    "ellt = ?, DatumGeaendert = ?, IDBenutzer_Erstellt = ?, IDBenutzer_Geaendert = ? " +
    "WHERE (ID = ?)";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDREF", System.Data.OleDb.OleDbType.Guid, 16, "IDREF"),
            new System.Data.OleDb.OleDbParameter("FormularName", System.Data.OleDb.OleDbType.VarChar, 255, "FormularName"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.VarChar, 2147483647, "BLOP"),
            new System.Data.OleDb.OleDbParameter("Datumerstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datumerstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularDaten1)).EndInit();

		}
		#endregion
	}
}
