//----------------------------------------------------------------------------
/// <summary>
///	DBMassnahmenserien.cs
/// Erstellt am:	24.8.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Massnahmenserien-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBMassnahmenserien : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daMassnahmenserien;
        private dsMassnahmenserien dsMassnahmenserien1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die UserDefinedID
		/// </summary>
		//----------------------------------------------------------------------------
		public static Guid UserDefinedID()
		{
			return Guid.Empty;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBMassnahmenserien()
		{
			InitializeComponent();
			IsSingleEntry = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMassnahmenserien));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daMassnahmenserien = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsMassnahmenserien1 = new dsMassnahmenserien();
            ((System.ComponentModel.ISupportInitialize)(this.dsMassnahmenserien1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daMassnahmenserien
            // 
            this.daMassnahmenserien.DeleteCommand = this.oleDbDeleteCommand1;
            this.daMassnahmenserien.InsertCommand = this.oleDbInsertCommand1;
            this.daMassnahmenserien.SelectCommand = this.oleDbSelectCommand1;
            this.daMassnahmenserien.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Massnahmenserien", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Z0", "Z0"),
                        new System.Data.Common.DataColumnMapping("Z1", "Z1"),
                        new System.Data.Common.DataColumnMapping("Z2", "Z2"),
                        new System.Data.Common.DataColumnMapping("Z3", "Z3"),
                        new System.Data.Common.DataColumnMapping("Z4", "Z4"),
                        new System.Data.Common.DataColumnMapping("Z5", "Z5"),
                        new System.Data.Common.DataColumnMapping("Z6", "Z6"),
                        new System.Data.Common.DataColumnMapping("Z7", "Z7")})});
            this.daMassnahmenserien.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z0", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z0", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z0", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z0", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z1", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z2", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z3", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z3", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z3", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z4", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z4", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z4", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z4", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z5", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z5", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z5", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z5", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z6", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z6", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z6", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z6", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z7", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z7", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z7", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z7", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Massnahmenserien] ([ID], [Bezeichnung], [Z0], [Z1], [Z2], [Z3], [Z4]" +
                ", [Z5], [Z6], [Z7]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Z0", System.Data.OleDb.OleDbType.Date, 16, "Z0"),
            new System.Data.OleDb.OleDbParameter("Z1", System.Data.OleDb.OleDbType.Date, 16, "Z1"),
            new System.Data.OleDb.OleDbParameter("Z2", System.Data.OleDb.OleDbType.Date, 16, "Z2"),
            new System.Data.OleDb.OleDbParameter("Z3", System.Data.OleDb.OleDbType.Date, 16, "Z3"),
            new System.Data.OleDb.OleDbParameter("Z4", System.Data.OleDb.OleDbType.Date, 16, "Z4"),
            new System.Data.OleDb.OleDbParameter("Z5", System.Data.OleDb.OleDbType.Date, 16, "Z5"),
            new System.Data.OleDb.OleDbParameter("Z6", System.Data.OleDb.OleDbType.Date, 16, "Z6"),
            new System.Data.OleDb.OleDbParameter("Z7", System.Data.OleDb.OleDbType.Date, 16, "Z7")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Bezeichnung, Z0, Z1, Z2, Z3, Z4, Z5, Z6, Z7\r\nFROM         Massnahm" +
                "enserien\r\nORDER BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Z0", System.Data.OleDb.OleDbType.Date, 16, "Z0"),
            new System.Data.OleDb.OleDbParameter("Z1", System.Data.OleDb.OleDbType.Date, 16, "Z1"),
            new System.Data.OleDb.OleDbParameter("Z2", System.Data.OleDb.OleDbType.Date, 16, "Z2"),
            new System.Data.OleDb.OleDbParameter("Z3", System.Data.OleDb.OleDbType.Date, 16, "Z3"),
            new System.Data.OleDb.OleDbParameter("Z4", System.Data.OleDb.OleDbType.Date, 16, "Z4"),
            new System.Data.OleDb.OleDbParameter("Z5", System.Data.OleDb.OleDbType.Date, 16, "Z5"),
            new System.Data.OleDb.OleDbParameter("Z6", System.Data.OleDb.OleDbType.Date, 16, "Z6"),
            new System.Data.OleDb.OleDbParameter("Z7", System.Data.OleDb.OleDbType.Date, 16, "Z7"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z0", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z0", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z0", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z0", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z1", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z2", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z3", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z3", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z3", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z4", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z4", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z4", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z4", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z5", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z5", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z5", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z5", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z6", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z6", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z6", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z6", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Z7", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Z7", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Z7", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Z7", System.Data.DataRowVersion.Original, null)});
            // 
            // dsMassnahmenserien1
            // 
            this.dsMassnahmenserien1.DataSetName = "dsMassnahmenserien";
            this.dsMassnahmenserien1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMassnahmenserien1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsMassnahmenserien1)).EndInit();

		}
		#endregion
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daMassnahmenserien;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue Massnahmenserien erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsMassnahmenserien.MassnahmenserienRow AddEntry()
		{
			dsMassnahmenserien.MassnahmenserienRow r = ITEM.NewMassnahmenserienRow();

			r.ID			= Guid.NewGuid();
			r.Bezeichnung	= "";

			ITEM.AddMassnahmenserienRow(r);
			return r;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern (mehere Einträge)
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsMassnahmenserien.MassnahmenserienDataTable ITEM
		{
			get	{	return dsMassnahmenserien1.Massnahmenserien;	}
		}

		#region IDBBase  Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}

		#endregion
	}
}
