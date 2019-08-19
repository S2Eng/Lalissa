//----------------------------------------------------------------------------
/// <summary>
///	DBAdresse.cs
/// Erstellt am:	14.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Adressinformationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBAdresse : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daAdresseByID;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        public dsAdresse dsAdresse1;
        public OleDbDataAdapter daAdresseWhere;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand3;
        private OleDbCommand oleDbCommand4;
        private System.ComponentModel.Container components = null;



        public string sSelAdressenWhere = "";




		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBAdresse()
		{
			InitializeComponent();
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
            this.daAdresseByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsAdresse1 = new PMDS.Global.db.Patient.dsAdresse();
            this.daAdresseWhere = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdresse1)).BeginInit();
            // 
            // daAdresseByID
            // 
            this.daAdresseByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daAdresseByID.InsertCommand = this.oleDbInsertCommand2;
            this.daAdresseByID.SelectCommand = this.oleDbSelectCommand1;
            this.daAdresseByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Adresse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("Plz", "Plz"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Region", "Region"),
                        new System.Data.Common.DataColumnMapping("LandKZ", "LandKZ")})});
            this.daAdresseByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Adresse] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [Adresse] ([ID], [Strasse], [Plz], [Ort], [Region], [LandKZ]) VALUES " +
    "(?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("Plz", System.Data.OleDb.OleDbType.VarChar, 0, "Plz"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarChar, 0, "Region"),
            new System.Data.OleDb.OleDbParameter("LandKZ", System.Data.OleDb.OleDbType.VarChar, 0, "LandKZ")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, Strasse, Plz, Ort, Region, LandKZ\r\nFROM            Adresse\r\nWHE" +
    "RE        (ID = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE [Adresse] SET [ID] = ?, [Strasse] = ?, [Plz] = ?, [Ort] = ?, [Region] = ?," +
    " [LandKZ] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("Plz", System.Data.OleDb.OleDbType.VarChar, 0, "Plz"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarChar, 0, "Region"),
            new System.Data.OleDb.OleDbParameter("LandKZ", System.Data.OleDb.OleDbType.VarChar, 0, "LandKZ"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsAdresse1
            // 
            this.dsAdresse1.DataSetName = "dsAdresse";
            this.dsAdresse1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAdresse1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAdresseWhere
            // 
            this.daAdresseWhere.DeleteCommand = this.oleDbCommand1;
            this.daAdresseWhere.InsertCommand = this.oleDbCommand2;
            this.daAdresseWhere.SelectCommand = this.oleDbCommand3;
            this.daAdresseWhere.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Adresse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("Plz", "Plz"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Region", "Region"),
                        new System.Data.Common.DataColumnMapping("LandKZ", "LandKZ")})});
            this.daAdresseWhere.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [Adresse] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [Adresse] ([ID], [Strasse], [Plz], [Ort], [Region], [LandKZ]) VALUES " +
    "(?, ?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("Plz", System.Data.OleDb.OleDbType.VarChar, 0, "Plz"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarChar, 0, "Region"),
            new System.Data.OleDb.OleDbParameter("LandKZ", System.Data.OleDb.OleDbType.VarChar, 0, "LandKZ")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Strasse, Plz, Ort, Region, LandKZ\r\nFROM            Adresse\r\n";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE [Adresse] SET [ID] = ?, [Strasse] = ?, [Plz] = ?, [Ort] = ?, [Region] = ?," +
    " [LandKZ] = ? WHERE (([ID] = ?))";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Strasse", System.Data.OleDb.OleDbType.VarChar, 0, "Strasse"),
            new System.Data.OleDb.OleDbParameter("Plz", System.Data.OleDb.OleDbType.VarChar, 0, "Plz"),
            new System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarChar, 0, "Ort"),
            new System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarChar, 0, "Region"),
            new System.Data.OleDb.OleDbParameter("LandKZ", System.Data.OleDb.OleDbType.VarChar, 0, "LandKZ"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsAdresse1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daAdresseByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
            ITEM.AddAdresseRow(Guid.NewGuid(), "", "", "", "", "");
		}
        public dsAdresse.AdresseRow loadAdresseKlinik(System.Guid IDAdresse, bool doExceptionNoKlinikFound)
        {
            dsAdresse.AdresseDataTable dtAdresseKlinik = new dsAdresse.AdresseDataTable();
            this.daAdresseByID.SelectCommand.Parameters[0].Value = IDAdresse;
            RBU.DataBase.Fill(this.daAdresseByID, dtAdresseKlinik);
            if (dtAdresseKlinik.Rows.Count != 1)
            {
                if (doExceptionNoKlinikFound)
                    throw new Exception("loadAdresseKlinik: dtAdresseKlinik.Rows.Count != 1 for IDAdresse '" + IDAdresse.ToString() + "'!");
                else
                    return null;
            }
            return (dsAdresse.AdresseRow)dtAdresseKlinik.Rows[0];
        }
        public void loadAdressenWhere(string sWhere, ref dsAdresse.AdresseDataTable dtAdresse)
        {
            if (sSelAdressenWhere.Trim() == "")
                sSelAdressenWhere = this.daAdresseWhere.SelectCommand.CommandText;

            this.daAdresseWhere.SelectCommand.CommandText = sSelAdressenWhere;
            this.daAdresseWhere.SelectCommand.CommandText += sWhere;
            RBU.DataBase.Fill(this.daAdresseWhere, dtAdresse);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenTabelle liefern
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual dsAdresse.AdresseDataTable ITEM
		{
			get	{	return dsAdresse1.Adresse;	}
		}

		#region IDBBase Members

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
